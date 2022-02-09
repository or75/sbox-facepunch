using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Sandbox
{
	// Token: 0x0200028E RID: 654
	[Hotload.SkipAttribute]
	internal class CompileManager
	{
		/// <summary>
		/// Returns true if we have compiles pending
		/// </summary>
		// Token: 0x17000323 RID: 803
		// (get) Token: 0x0600106E RID: 4206 RVA: 0x0001E4EC File Offset: 0x0001C6EC
		public static bool NeedsBuild
		{
			get
			{
				return CompileManager.Recompile.Count<Compiler>() > 0;
			}
		}

		/// <summary>
		/// Returns true if we are currently in the process of building
		/// </summary>
		// Token: 0x17000324 RID: 804
		// (get) Token: 0x0600106F RID: 4207 RVA: 0x0001E4FB File Offset: 0x0001C6FB
		// (set) Token: 0x06001070 RID: 4208 RVA: 0x0001E502 File Offset: 0x0001C702
		public static bool IsBuilding { get; private set; }

		/// <summary>
		/// Reset to initial state
		/// </summary>
		// Token: 0x06001071 RID: 4209 RVA: 0x0001E50A File Offset: 0x0001C70A
		public static void Shutdown()
		{
			CompileManager.All = new List<Compiler>();
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x0001E518 File Offset: 0x0001C718
		public static Compiler CreateCompiler(string name, BaseFileSystem filesystem)
		{
			Compiler compiler = new Compiler(name, filesystem);
			compiler.GlobalNamespaces.Add("static Sandbox.Internal.GlobalGameNamespace");
			List<Compiler> all = CompileManager.All;
			lock (all)
			{
				CompileManager.All.Add(compiler);
			}
			return compiler;
		}

		/// <summary>
		/// Mark this assembly as changed. 
		/// </summary>
		// Token: 0x06001073 RID: 4211 RVA: 0x0001E578 File Offset: 0x0001C778
		public static bool MarkForRecompile(Compiler compiler)
		{
			if (CompileManager.Recompile.Contains(compiler))
			{
				return false;
			}
			CompileManager.Recompile.Add(compiler);
			List<Compiler> all = CompileManager.All;
			Compiler[] dependants;
			lock (all)
			{
				dependants = CompileManager.All.Where((Compiler x) => x.Dependancies.Contains(compiler)).ToArray<Compiler>();
			}
			Compiler[] array = dependants;
			for (int i = 0; i < array.Length; i++)
			{
				CompileManager.MarkForRecompile(array[i]);
			}
			compiler.Building = true;
			compiler.BuildSuccess = false;
			return true;
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x0001E638 File Offset: 0x0001C838
		internal static void OnCompilerDisposed(Compiler compiler)
		{
			List<Compiler> all = CompileManager.All;
			lock (all)
			{
				CompileManager.All.Remove(compiler);
			}
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x0001E680 File Offset: 0x0001C880
		internal static Compiler FindCompilerByName(string name)
		{
			List<Compiler> all = CompileManager.All;
			Compiler result;
			lock (all)
			{
				result = CompileManager.All.SingleOrDefault((Compiler x) => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
			}
			return result;
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x0001E6E0 File Offset: 0x0001C8E0
		internal static Compiler FindCompilerByDll(string name)
		{
			List<Compiler> all = CompileManager.All;
			Compiler result;
			lock (all)
			{
				result = CompileManager.All.SingleOrDefault((Compiler x) => string.Equals(x.DllName, name, StringComparison.OrdinalIgnoreCase));
			}
			return result;
		}

		/// <summary>
		/// Build the compilers. This should only be manually in unit tests.
		/// </summary>
		// Token: 0x06001077 RID: 4215 RVA: 0x0001E740 File Offset: 0x0001C940
		public static async Task<Compiler[]> BuildAsync()
		{
			if (CompileManager.IsBuilding)
			{
				throw new Exception("Tried to build but a build is already in process");
			}
			Compiler[] result;
			if (!CompileManager.NeedsBuild)
			{
				result = Array.Empty<Compiler>();
			}
			else
			{
				CompileManager.IsBuilding = true;
				try
				{
					List<Compiler> compileList = CompileManager.Recompile.ToList<Compiler>();
					int totalCompilers = compileList.Count<Compiler>();
					if (compileList == null)
					{
						CompileManager.log.Error("Addon dependencies have a cyclic reference?");
						result = null;
					}
					else
					{
						string category = "compiler";
						string icon = "\ud83e\udd28";
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
						defaultInterpolatedStringHandler.AppendLiteral("Compiling [0/");
						defaultInterpolatedStringHandler.AppendFormatted<int>(totalCompilers);
						defaultInterpolatedStringHandler.AppendLiteral("]");
						Development.Notice(category, icon, defaultInterpolatedStringHandler.ToStringAndClear(), 30, "working", null);
						if (compileList.Count == 0)
						{
							throw new Exception("Compile list is empty - this should never happen (NeedsBuild check should prevent it)");
						}
						CompileManager.log.Trace(FormattableStringFactory.Create("Building {0} compilers", new object[] { compileList.Count<Compiler>() }));
						Task<bool>[] tasks = (from x in compileList
							where x.Active
							select Task.Run<bool>(new Func<Task<bool>>(x.Build))).ToArray<Task<bool>>();
						for (;;)
						{
							if (!tasks.Any((Task<bool> x) => !x.IsCompleted))
							{
								break;
							}
							await Task.Delay(50);
							string category2 = "compiler";
							string icon2 = "\ud83e\udd28";
							defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
							defaultInterpolatedStringHandler.AppendLiteral("Compiling [");
							defaultInterpolatedStringHandler.AppendFormatted<int>(tasks.Count((Task<bool> x) => x.IsCompleted));
							defaultInterpolatedStringHandler.AppendLiteral("/");
							defaultInterpolatedStringHandler.AppendFormatted<int>(totalCompilers);
							defaultInterpolatedStringHandler.AppendLiteral("]");
							Development.Notice(category2, icon2, defaultInterpolatedStringHandler.ToStringAndClear(), 30, "working", null);
						}
						if (compileList.Any((Compiler x) => !x.BuildSuccess))
						{
							Development.Notice("compiler", "\ud83d\udc80", "Compile Failed", 60, "error", string.Join("\n\n", compileList.Where((Compiler x) => !x.BuildSuccess).SelectMany((Compiler x) => x.GetErrors())));
							result = null;
						}
						else
						{
							string category3 = "compiler";
							string icon3 = "\ud83d\ude0d";
							defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
							defaultInterpolatedStringHandler.AppendLiteral("Compiling [");
							defaultInterpolatedStringHandler.AppendFormatted<int>(totalCompilers);
							defaultInterpolatedStringHandler.AppendLiteral("/");
							defaultInterpolatedStringHandler.AppendFormatted<int>(totalCompilers);
							defaultInterpolatedStringHandler.AppendLiteral("]");
							Development.Notice(category3, icon3, defaultInterpolatedStringHandler.ToStringAndClear(), 5, "success", null);
							result = compileList.OrderBy((Compiler x) => x.DependancyIndex()).ToArray<Compiler>();
						}
					}
				}
				finally
				{
					CompileManager.Recompile.Clear();
					CompileManager.IsBuilding = false;
				}
			}
			return result;
		}

		// Token: 0x04001273 RID: 4723
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x04001274 RID: 4724
		internal static List<Compiler> All = new List<Compiler>();

		// Token: 0x04001275 RID: 4725
		internal static List<Compiler> Recompile = new List<Compiler>();
	}
}
