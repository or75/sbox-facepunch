using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Sandbox.DataModel;
using Sandbox.Engine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000280 RID: 640
	internal static class ServerAddons
	{
		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x06000F97 RID: 3991 RVA: 0x0001C1E0 File Offset: 0x0001A3E0
		// (set) Token: 0x06000F98 RID: 3992 RVA: 0x0001C1E7 File Offset: 0x0001A3E7
		internal static List<Addon> All { get; private set; } = new List<Addon>();

		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x06000F99 RID: 3993 RVA: 0x0001C1EF File Offset: 0x0001A3EF
		internal static IEnumerable<Addon> Active
		{
			get
			{
				return ServerAddons.All.Where((Addon x) => x.IsActive);
			}
		}

		/// <summary>
		/// Initialize the addon manager
		/// </summary>
		// Token: 0x06000F9A RID: 3994 RVA: 0x0001C21A File Offset: 0x0001A41A
		internal static void Init()
		{
			ServerAddons.AddFolder(EngineFileSystem.Root, "/addons/base");
			ServerAddons.AddFolder(EngineFileSystem.Root, "/addons/citizen");
			ServerAddons.AddFolder(EngineFileSystem.Root, "/addons/rust");
		}

		/// <summary>
		/// Remove all addons
		/// </summary>
		// Token: 0x06000F9B RID: 3995 RVA: 0x0001C24C File Offset: 0x0001A44C
		internal static void ClearTransients()
		{
			foreach (Addon t in ServerAddons.All.Where((Addon x) => x.IsTransient).ToArray<Addon>())
			{
				t.Dispose();
				ServerAddons.All.Remove(t);
			}
		}

		// Token: 0x06000F9C RID: 3996 RVA: 0x0001C2AC File Offset: 0x0001A4AC
		internal static bool TryLoadLocal(string title)
		{
			return LocalAddon.All.FirstOrDefault((LocalAddon x) => x.Active && string.Equals(x.Config.FullIdent, title, StringComparison.OrdinalIgnoreCase)) != null;
		}

		/// <summary>
		/// Add a new addon from a filesystem
		/// </summary>
		// Token: 0x06000F9D RID: 3997 RVA: 0x0001C2E4 File Offset: 0x0001A4E4
		public static Addon Add(string name, BaseFileSystem fileSystem, bool transient = false)
		{
			Addon result;
			try
			{
				AddonConfig config = Addon.TryLoadConfig(fileSystem);
				if (config == null)
				{
					GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't find {0}", new object[] { fileSystem.GetFullPath("/.addon") }));
					result = null;
				}
				else
				{
					Addon addon = new Addon(name, config, fileSystem, transient);
					ServerAddons.All.Add(addon);
					result = addon;
				}
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(e, FormattableStringFactory.Create("Couldn't mount addon", Array.Empty<object>()));
				result = null;
			}
			return result;
		}

		/// <summary>
		/// Add all child folders as addons
		/// </summary>
		// Token: 0x06000F9E RID: 3998 RVA: 0x0001C370 File Offset: 0x0001A570
		public static Addon AddFolder(BaseFileSystem fs, string subfolder)
		{
			BaseFileSystem filesystem = fs.CreateSubSystem(subfolder);
			return ServerAddons.Add(Path.GetFileName(subfolder), filesystem, false);
		}

		/// <summary>
		/// Add all child folders as addons
		/// </summary>
		// Token: 0x06000F9F RID: 3999 RVA: 0x0001C394 File Offset: 0x0001A594
		public static Addon TryAdd(LocalAddon localaddon)
		{
			string folder = Path.GetDirectoryName(localaddon.Path);
			string name = localaddon.Config.FullIdent;
			if (ServerAddons.All.Any((Addon x) => x.Name == name))
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Addon {0} already mounted - skipping", new object[] { name }));
				return null;
			}
			if (!Directory.Exists(folder))
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Addon at {0} not found", new object[] { folder }));
				return null;
			}
			List<Addon> list = new List<Addon>();
			RootFileSystem filesystem = new RootFileSystem(folder);
			Addon addon = ServerAddons.Add(name, filesystem, false);
			list.Add(addon);
			return addon;
		}

		/// <summary>
		/// This function is made to run in a tick so we can call it in a sensible place
		/// and not have hotloading start randomly in a task, where it might be unsafe.
		/// </summary>
		// Token: 0x06000FA0 RID: 4000 RVA: 0x0001C44A File Offset: 0x0001A64A
		internal static void Tick()
		{
			if (ServerAddons.compileTask != null && !ServerAddons.compileTask.IsCompleted)
			{
				return;
			}
			ServerAddons.compileTask = null;
			if (CompileManager.NeedsBuild)
			{
				ServerAddons.compileTask = ServerAddons.CompileAndHotloadAsync();
			}
		}

		/// <summary>
		/// Compile all pending compiles and do the hotload. This function
		/// is used in unit tests.
		/// </summary>
		// Token: 0x06000FA1 RID: 4001 RVA: 0x0001C478 File Offset: 0x0001A678
		public static async Task<bool> CompileAndHotloadAsync()
		{
			bool result;
			try
			{
				Compiler[] array = await CompileManager.BuildAsync();
				Compiler[] compiled = array;
				if (compiled == null || compiled.Length == 0)
				{
					GlobalSystemNamespace.Log.Warning("Nothing compiled");
					result = false;
				}
				else
				{
					await Task.Delay(10);
					IServerDll serverDll = IServerDll.Current;
					TaskAwaiter<bool> taskAwaiter = ((serverDll != null) ? serverDll.OnAddonsCompiled(compiled) : null).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<bool> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<bool>);
					}
					if (!taskAwaiter.GetResult())
					{
						result = false;
					}
					else
					{
						result = true;
					}
				}
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Error(e);
				result = false;
			}
			return result;
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x0001C4B4 File Offset: 0x0001A6B4
		public static Addon FindAddonsWithName(string name)
		{
			return ServerAddons.All.FirstOrDefault((Addon x) => x.Name == name || x.Ident == name || x.Name.EndsWith("." + name, StringComparison.OrdinalIgnoreCase) || x.Ident.EndsWith("." + name, StringComparison.OrdinalIgnoreCase));
		}

		/// <summary>
		/// The last activated gamemode addon (serverside)
		/// </summary>
		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x06000FA3 RID: 4003 RVA: 0x0001C4E4 File Offset: 0x0001A6E4
		// (set) Token: 0x06000FA4 RID: 4004 RVA: 0x0001C4EB File Offset: 0x0001A6EB
		internal static Addon LastGamemodeAddon { get; set; }

		/// <summary>
		/// Switch the gamemode to this one (if found).
		/// This means activating this gamemode addon, and any
		/// other addons that want to be activated when this one is.
		/// </summary>
		// Token: 0x06000FA5 RID: 4005 RVA: 0x0001C4F4 File Offset: 0x0001A6F4
		public static bool SwitchGamemode(string name, bool isClient)
		{
			ServerAddons.LastGamemodeAddon = null;
			ServerAddons.DeactivateAll();
			ServerAddons.TryMountLocalAddon(name);
			Addon addon = ServerAddons.FindAddonsWithName(name);
			if (addon == null)
			{
				ServerAddons.log.Error(FormattableStringFactory.Create("Couldn't find addon with gamemode named {0}", new object[] { name }));
				return false;
			}
			ServerAddons.LastGamemodeAddon = addon;
			addon.ActivateWithDependancies();
			if (!isClient)
			{
				addon.Recompile();
			}
			return true;
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x0001C554 File Offset: 0x0001A754
		internal static void TryMountLocalAddon(string ident)
		{
			LocalAddon addon = LocalAddon.FindByIdent(ident);
			if (addon == null)
			{
				return;
			}
			ServerAddons.TryAdd(addon);
		}

		/// <summary>
		/// Fuck all addon off
		/// </summary>
		// Token: 0x06000FA7 RID: 4007 RVA: 0x0001C574 File Offset: 0x0001A774
		public static void DeactivateAll()
		{
			ServerAddons.LastGamemodeAddon = null;
			foreach (Addon addon in ServerAddons.All)
			{
				addon.Deactivate();
			}
		}

		/// <summary>
		/// For client - return all the paths associated
		/// </summary>
		// Token: 0x06000FA8 RID: 4008 RVA: 0x0001C5CC File Offset: 0x0001A7CC
		public static IEnumerable<BaseFileSystem> FindAddonPaths(string addonName)
		{
			Addon addon = ServerAddons.All.FirstOrDefault((Addon x) => x.Name == addonName);
			if (addon == null)
			{
				yield break;
			}
			if (addon.content != null)
			{
				yield return addon.content;
			}
			if (addon.code != null)
			{
				yield return addon.code;
			}
			yield break;
		}

		// Token: 0x04001220 RID: 4640
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x04001222 RID: 4642
		private static Task compileTask;
	}
}
