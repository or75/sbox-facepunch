using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Loader;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x02000073 RID: 115
	public class ToolAddon : IDisposable
	{
		/// <summary>
		/// The absolute filesystem path to this addon
		/// </summary>
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06001290 RID: 4752 RVA: 0x000509C8 File Offset: 0x0004EBC8
		// (set) Token: 0x06001291 RID: 4753 RVA: 0x000509D0 File Offset: 0x0004EBD0
		public string Path { get; protected set; }

		/// <summary>
		/// The path to a data folder if added
		/// </summary>
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06001292 RID: 4754 RVA: 0x000509D9 File Offset: 0x0004EBD9
		// (set) Token: 0x06001293 RID: 4755 RVA: 0x000509E1 File Offset: 0x0004EBE1
		public string AssetPath { get; protected set; }

		/// <summary>
		/// The title of this addon
		/// </summary>
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06001294 RID: 4756 RVA: 0x000509EA File Offset: 0x0004EBEA
		// (set) Token: 0x06001295 RID: 4757 RVA: 0x000509F2 File Offset: 0x0004EBF2
		public string Name { get; protected set; }

		/// <summary>
		/// This addon's root folder
		/// </summary>
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06001296 RID: 4758 RVA: 0x000509FB File Offset: 0x0004EBFB
		// (set) Token: 0x06001297 RID: 4759 RVA: 0x00050A03 File Offset: 0x0004EC03
		public BaseFileSystem FileSystem { get; protected set; }

		/// <summary>
		/// This addon's resources folder
		/// </summary>
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06001298 RID: 4760 RVA: 0x00050A0C File Offset: 0x0004EC0C
		// (set) Token: 0x06001299 RID: 4761 RVA: 0x00050A14 File Offset: 0x0004EC14
		public BaseFileSystem Resources { get; protected set; }

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600129A RID: 4762 RVA: 0x00050A1D File Offset: 0x0004EC1D
		// (set) Token: 0x0600129B RID: 4763 RVA: 0x00050A25 File Offset: 0x0004EC25
		internal Compiler Compiler { get; set; }

		/// <summary>
		/// True if the compiler is compiling
		/// </summary>
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600129C RID: 4764 RVA: 0x00050A2E File Offset: 0x0004EC2E
		public bool IsBuilding
		{
			get
			{
				return this.Compiler.Building;
			}
		}

		/// <summary>
		/// Set when the addon assembly needs to be loaded from the compiler.
		/// </summary>
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x0600129D RID: 4765 RVA: 0x00050A3B File Offset: 0x0004EC3B
		// (set) Token: 0x0600129E RID: 4766 RVA: 0x00050A43 File Offset: 0x0004EC43
		public bool NeedsHotload { get; protected set; }

		/// <summary>
		/// Set when the contents have changed and we will require a rebuild
		/// </summary>
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x0600129F RID: 4767 RVA: 0x00050A4C File Offset: 0x0004EC4C
		// (set) Token: 0x060012A0 RID: 4768 RVA: 0x00050A54 File Offset: 0x0004EC54
		public bool ContentsChanged { get; protected set; }

		/// <summary>
		/// If compiled this will contain the current assembly
		/// </summary>
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x060012A1 RID: 4769 RVA: 0x00050A5D File Offset: 0x0004EC5D
		// (set) Token: 0x060012A2 RID: 4770 RVA: 0x00050A65 File Offset: 0x0004EC65
		public Assembly Assembly { get; protected set; }

		/// <summary>
		/// Creates an addon and starts to compile it
		/// </summary>
		// Token: 0x060012A3 RID: 4771 RVA: 0x00050A70 File Offset: 0x0004EC70
		public ToolAddon(string folder)
		{
			GlobalToolsNamespace.Log.Info(FormattableStringFactory.Create("Tools Addon: {0}", new object[] { folder }));
			this.Path = folder;
			DirectoryInfo directoryInfo = new DirectoryInfo(this.Path);
			this.FileSystem = new RootFileSystem(folder);
			string dataFolder = System.IO.Path.Combine(this.Path, "resources");
			if (Directory.Exists(dataFolder))
			{
				this.AssetPath = dataFolder;
				WidgetUtil.AddSearchPath(this.AssetPath);
				this.Resources = ((AggFileSystem)Sandbox.FileSystem.Mounted).CreateAndMount(this.FileSystem, "/resources/");
			}
			this.FileSystem.Watch("*.cs").OnChanges += delegate(FileWatch x)
			{
				this.ContentsChanged = true;
			};
			this.Name = directoryInfo.Name;
			string compilerName = "Tools." + this.Name.ToLower();
			this.Compiler = new Compiler(compilerName, this.FileSystem);
			this.Compiler.References.Add("Sandbox.Tools");
			this.Compiler.References.Remove("Sandbox.Game");
			this.Compiler.GlobalNamespaces.Add("static Sandbox.Internal.GlobalToolsNamespace");
			this.Compiler.Build();
			this.NeedsHotload = true;
		}

		/// <summary>
		/// Should be called every frame, lets the addon hotload etc
		/// </summary>
		// Token: 0x060012A4 RID: 4772 RVA: 0x00050BB4 File Offset: 0x0004EDB4
		public void Frame()
		{
			if (this.IsBuilding)
			{
				return;
			}
			if (!this.NeedsHotload)
			{
				if (this.ContentsChanged)
				{
					this.ContentsChanged = false;
					this.Compiler.Build();
					this.NeedsHotload = true;
				}
				return;
			}
			this.NeedsHotload = false;
			if (this.Compiler.BuildSuccess)
			{
				AssemblyLoadContext context = AssemblyLoadContext.GetLoadContext(Global.Assembly);
				using (MemoryStream asm = new MemoryStream(this.Compiler.AsmBinary, false))
				{
					using (MemoryStream sym = new MemoryStream(this.Compiler.SymBinary, false))
					{
						Assembly assembly = context.LoadFromStream(asm, sym);
						this.Onboard(assembly);
					}
				}
				return;
			}
			string[] errors = this.Compiler.GetErrors();
			string parts = string.Join("\n", errors);
			TrayIcon toolsTrayIcon = GlobalToolsNamespace.ToolsTrayIcon;
			if (toolsTrayIcon == null)
			{
				return;
			}
			toolsTrayIcon.ShowMessage("Tools Compile Failed", parts, "tray/compile_error.png", 5f);
		}

		// Token: 0x060012A5 RID: 4773 RVA: 0x00050CB8 File Offset: 0x0004EEB8
		private void Onboard(Assembly incoming)
		{
			this.Assembly != null;
			GlobalToolsNamespace.Reflection.AddDynamicAssembly(this.Assembly, incoming);
			Event.RegisterAssembly(this.Assembly, incoming);
			Global.HotloadManager.Replace(this.Assembly, incoming);
			this.Assembly = incoming;
		}

		/// <summary>
		/// Kill the addon
		/// </summary>
		// Token: 0x060012A6 RID: 4774 RVA: 0x00050D08 File Offset: 0x0004EF08
		public void Dispose()
		{
			BaseFileSystem resources = this.Resources;
			if (resources != null)
			{
				resources.Dispose();
			}
			this.Resources = null;
			BaseFileSystem fileSystem = this.FileSystem;
			if (fileSystem != null)
			{
				fileSystem.Dispose();
			}
			this.FileSystem = null;
			Compiler compiler = this.Compiler;
			if (compiler != null)
			{
				compiler.Dispose();
			}
			this.Compiler = null;
			if (this.AssetPath != null)
			{
				WidgetUtil.RemoveSearchPath(this.AssetPath);
			}
		}
	}
}
