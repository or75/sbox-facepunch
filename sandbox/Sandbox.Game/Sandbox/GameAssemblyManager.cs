using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// Handles the storage and loading of assemblies sent from the server via string tables
	/// </summary>
	// Token: 0x02000065 RID: 101
	internal static class GameAssemblyManager
	{
		/// <summary>
		/// This is a hash of loaded assembly names. We can use it to make sure we're using
		/// the same code as the server. This is important when it comes to things like decoding
		/// network messages and datatables - because if the code is different we're going to 
		/// get errors, because it could expect different data.
		/// </summary>
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x06000BCF RID: 3023 RVA: 0x0003D8E0 File Offset: 0x0003BAE0
		// (set) Token: 0x06000BD0 RID: 3024 RVA: 0x0003D8E7 File Offset: 0x0003BAE7
		internal static int Hash { get; private set; }

		/// <summary>
		/// Called on Game Loop Init
		/// </summary>
		// Token: 0x06000BD1 RID: 3025 RVA: 0x0003D8F0 File Offset: 0x0003BAF0
		internal static void Init()
		{
			GameAssemblyManager.Hash = -1;
			GameAssemblyManager.Loaded.Clear();
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 2);
			defaultInterpolatedStringHandler.AppendFormatted(Host.Name);
			defaultInterpolatedStringHandler.AppendLiteral(" Gen ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(++GameAssemblyManager.Generation);
			GameAssemblyManager.LoadContext = new GameLoadContext(defaultInterpolatedStringHandler.ToStringAndClear());
			GameAssemblyManager.AccessControl = new AccessControl();
			GameAssemblyManager.AccessControl.LoadFromConfig(EngineFileSystem.Root, GameAssemblyManager.AccessConfig);
		}

		/// <summary>
		/// The client has ended the loading and downloading session and is now ready to enter the server
		/// </summary>
		// Token: 0x06000BD2 RID: 3026 RVA: 0x0003D974 File Offset: 0x0003BB74
		public static void ClientSignonFull()
		{
			Host.AssertClient("ClientSignonFull");
			StringTables.Assemblies.OnStringAddedOrChanged = new Action<int>(GameAssemblyManager.OnAssemblyFromServer);
			for (int i = 0; i < StringTables.Assemblies.Count(); i++)
			{
				GameAssemblyManager.OnAssemblyFromServer(i);
			}
			GameAssemblyManager.UpdateHash();
		}

		/// <summary>
		/// Called on Game Loop Deactivate
		/// </summary>
		// Token: 0x06000BD3 RID: 3027 RVA: 0x0003D9C4 File Offset: 0x0003BBC4
		internal static void Shutdown()
		{
			foreach (KeyValuePair<string, ValueTuple<Assembly, int>> asm in GameAssemblyManager.Loaded)
			{
				GlobalGameNamespace.Global.GameInterface.OnNewAssembly(null, asm.Value.Item1);
			}
			GameAssemblyManager.Loaded.Clear();
			if (Host.IsClient)
			{
				StringTables.Assemblies.OnStringAddedOrChanged = null;
			}
			AssemblyLoadContext previousLoadContext = GameAssemblyManager.PreviousLoadContext;
			if (previousLoadContext != null)
			{
				previousLoadContext.Unload();
			}
			GameAssemblyManager.PreviousLoadContext = null;
			AssemblyLoadContext loadContext = GameAssemblyManager.LoadContext;
			if (loadContext != null)
			{
				loadContext.Unload();
			}
			GameAssemblyManager.LoadContext = null;
			GameAssemblyManager.AccessControl = null;
			GameAssemblyManager.Hash = 0;
		}

		/// <summary>
		/// Called by the string table when an assembly is recieved/added
		/// </summary>
		// Token: 0x06000BD4 RID: 3028 RVA: 0x0003DA80 File Offset: 0x0003BC80
		internal unsafe static void OnAssemblyFromServer(int entryId)
		{
			string name = StringTables.Assemblies.GetString(entryId);
			int datalen;
			IntPtr data = StringTables.Assemblies.GetData(entryId, out datalen);
			if (data == IntPtr.Zero || datalen <= 0)
			{
				return;
			}
			Stream dll;
			Stream pdb;
			AssemblyTransport.Read((byte*)(void*)data, datalen, out dll, out pdb);
			if (!GameAssemblyManager.TestAccessControl(dll, null))
			{
				return;
			}
			dll.Position = 0L;
			pdb.Position = 0L;
			GameAssemblyManager.OnAssembly(name, dll, pdb);
		}

		/// <summary>
		/// Make sure we should be able to load this dll
		/// </summary>
		// Token: 0x06000BD5 RID: 3029 RVA: 0x0003DAF0 File Offset: 0x0003BCF0
		internal static bool TestAccessControl(Stream dll, List<string> errors = null)
		{
			GameAssemblyManager.AccessControl.InitTouches(dll);
			if (errors == null)
			{
				errors = new List<string>();
			}
			if (GameAssemblyManager.AccessControl.CheckRules(true, errors))
			{
				return true;
			}
			foreach (string error in errors)
			{
				GlobalGameNamespace.Log.Error(FormattableStringFactory.Create("Not in whitelist: {0}", new object[] { error }));
			}
			return false;
		}

		/// <summary>
		/// Assembly is ready to load. Will return false on fail.
		/// </summary>
		// Token: 0x06000BD6 RID: 3030 RVA: 0x0003DB7C File Offset: 0x0003BD7C
		internal static bool OnAssembly(string name, Stream dll, Stream pdb)
		{
			ValueTuple<Assembly, int> old_assembly;
			GameAssemblyManager.Loaded.TryGetValue(name, out old_assembly);
			Assembly asm = GameAssemblyManager.LoadContext.LoadFromStream(dll, pdb);
			GlobalGameNamespace.Reflection.AddDynamicAssembly(old_assembly.Item1, asm);
			GlobalGameNamespace.Global.GameInterface.OnNewAssembly(asm, old_assembly.Item1);
			GlobalGameNamespace.Global.HotloadManager.Replace(old_assembly.Item1, asm);
			GameAssemblyManager.Loaded[name] = new ValueTuple<Assembly, int>(asm, 1);
			if (old_assembly.Item1 != null)
			{
				GameAssemblyManager.AccessControl.ForgetAssembly(old_assembly.Item1.GetName().Name);
			}
			if (Host.IsServer)
			{
				Addon sad = ServerAddons.All.FirstOrDefault((Addon x) => x.Ident == name);
				if (sad == null && name == "base")
				{
					sad = ServerAddons.All.FirstOrDefault((Addon x) => x.Name == name);
				}
				if (sad != null && sad.content != null)
				{
					try
					{
						FgdWriter.WriteForAssembly(sad.content, "/config", name, asm);
					}
					catch (Exception e)
					{
						GlobalGameNamespace.Log.Error(e, FormattableStringFactory.Create("Error when writing FGDs for addon {0}", new object[] { name }));
					}
				}
			}
			return true;
		}

		/// <summary>
		/// Called by the menu to load its dlls
		/// </summary>
		// Token: 0x06000BD7 RID: 3031 RVA: 0x0003DCE0 File Offset: 0x0003BEE0
		internal static bool ForceLoadCompiler(Compiler compiler, List<string> errors = null)
		{
			if (!compiler.BuildSuccess)
			{
				return false;
			}
			using (MemoryStream dll_stream = new MemoryStream(compiler.AsmBinary))
			{
				using (MemoryStream pdb_stream = new MemoryStream(compiler.SymBinary))
				{
					if (!GameAssemblyManager.TestAccessControl(dll_stream, errors))
					{
						return false;
					}
					dll_stream.Position = 0L;
					pdb_stream.Position = 0L;
					GameAssemblyManager.OnAssembly(compiler.Name, dll_stream, pdb_stream);
				}
			}
			return true;
		}

		/// <summary>
		/// Update the hash, based on loaded assemblies.
		/// </summary>
		// Token: 0x06000BD8 RID: 3032 RVA: 0x0003DD70 File Offset: 0x0003BF70
		internal static void UpdateHash()
		{
			GameAssemblyManager.Hash = 0;
			GameAssemblyManager.Hash = string.Join(";", from x in GameAssemblyManager.Loaded
				orderby x.Key
				select x.Value.Item1.FullName).FastHash();
		}

		// Token: 0x04000167 RID: 359
		public static string AccessConfig = "/config/accessgroups/baseaccess.txt";

		// Token: 0x04000168 RID: 360
		private static readonly Logger log = Logging.GetLogger(null);

		// Token: 0x04000169 RID: 361
		[TupleElementNames(new string[] { "Assembly", "Hash" })]
		internal static readonly Dictionary<string, ValueTuple<Assembly, int>> Loaded = new Dictionary<string, ValueTuple<Assembly, int>>();

		// Token: 0x0400016A RID: 362
		private static AccessControl AccessControl;

		// Token: 0x0400016B RID: 363
		private static AssemblyLoadContext LoadContext;

		// Token: 0x0400016C RID: 364
		private static AssemblyLoadContext PreviousLoadContext;

		// Token: 0x0400016D RID: 365
		private static int Generation = 0;
	}
}
