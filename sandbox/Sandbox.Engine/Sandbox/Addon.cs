using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox.DataModel;
using Sandbox.Engine;

namespace Sandbox
{
	// Token: 0x0200027E RID: 638
	[Hotload.SkipAttribute]
	internal class Addon : IDisposable
	{
		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x06000F60 RID: 3936 RVA: 0x0001B5AC File Offset: 0x000197AC
		// (set) Token: 0x06000F61 RID: 3937 RVA: 0x0001B5B4 File Offset: 0x000197B4
		private AddonConfig Config { get; set; }

		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x06000F62 RID: 3938 RVA: 0x0001B5BD File Offset: 0x000197BD
		public bool ShouldSendFiles
		{
			get
			{
				return !string.IsNullOrWhiteSpace(this.SharedAssetFilter);
			}
		}

		// Token: 0x170002D3 RID: 723
		// (get) Token: 0x06000F63 RID: 3939 RVA: 0x0001B5CD File Offset: 0x000197CD
		public string SharedAssetFilter
		{
			get
			{
				AddonConfig config = this.Config;
				if (config == null)
				{
					return null;
				}
				return config.SharedAssets;
			}
		}

		/// <summary>
		/// Tries to load the addon config from the passed path. Returns null on fail.
		/// </summary>
		// Token: 0x06000F64 RID: 3940 RVA: 0x0001B5E0 File Offset: 0x000197E0
		internal static AddonConfig TryLoadConfig(BaseFileSystem filesystem)
		{
			return filesystem.ReadJsonOrDefault<AddonConfig>("/.addon", null);
		}

		// Token: 0x170002D4 RID: 724
		// (get) Token: 0x06000F65 RID: 3941 RVA: 0x0001B5EE File Offset: 0x000197EE
		// (set) Token: 0x06000F66 RID: 3942 RVA: 0x0001B5F6 File Offset: 0x000197F6
		public bool IsActive { get; private set; }

		// Token: 0x170002D5 RID: 725
		// (get) Token: 0x06000F67 RID: 3943 RVA: 0x0001B5FF File Offset: 0x000197FF
		public bool IsCompiled
		{
			get
			{
				return this.compiler != null && this.compiler.BuildSuccess;
			}
		}

		// Token: 0x170002D6 RID: 726
		// (get) Token: 0x06000F68 RID: 3944 RVA: 0x0001B616 File Offset: 0x00019816
		// (set) Token: 0x06000F69 RID: 3945 RVA: 0x0001B61E File Offset: 0x0001981E
		public string Name { get; internal set; }

		// Token: 0x170002D7 RID: 727
		// (get) Token: 0x06000F6A RID: 3946 RVA: 0x0001B627 File Offset: 0x00019827
		public string Ident
		{
			get
			{
				AddonConfig config = this.Config;
				if (config == null)
				{
					return null;
				}
				return config.FullIdent;
			}
		}

		/// <summary>
		/// True if this is a an addon that was downloaded and 
		/// should be unmounted and destroyed when leaving the game.
		/// </summary>
		// Token: 0x170002D8 RID: 728
		// (get) Token: 0x06000F6B RID: 3947 RVA: 0x0001B63A File Offset: 0x0001983A
		// (set) Token: 0x06000F6C RID: 3948 RVA: 0x0001B642 File Offset: 0x00019842
		public bool IsTransient { get; set; }

		// Token: 0x170002D9 RID: 729
		// (get) Token: 0x06000F6D RID: 3949 RVA: 0x0001B64B File Offset: 0x0001984B
		// (set) Token: 0x06000F6E RID: 3950 RVA: 0x0001B653 File Offset: 0x00019853
		public string RootNamespace { get; internal set; }

		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06000F6F RID: 3951 RVA: 0x0001B65C File Offset: 0x0001985C
		public Exception CompileError
		{
			get
			{
				Compiler compiler = this.compiler;
				if (compiler == null)
				{
					return null;
				}
				return compiler.BuildException;
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06000F70 RID: 3952 RVA: 0x0001B66F File Offset: 0x0001986F
		// (set) Token: 0x06000F71 RID: 3953 RVA: 0x0001B677 File Offset: 0x00019877
		internal BaseFileSystem fileSystem { get; set; }

		// Token: 0x06000F72 RID: 3954 RVA: 0x0001B680 File Offset: 0x00019880
		public override string ToString()
		{
			return "[Addon:" + this.Name + "]";
		}

		// Token: 0x06000F73 RID: 3955 RVA: 0x0001B698 File Offset: 0x00019898
		public Addon(string name, AddonConfig config, BaseFileSystem fileSystem, bool transient = false)
		{
			this.Name = name;
			this.Config = config;
			this.fileSystem = fileSystem;
			this.IsTransient = transient;
			this.RootNamespace = config.RootNamespace ?? "$(MSBuildProjectName.Replace(\" \", \"_\"))";
			if (config != null)
			{
				if (config.Ident == null)
				{
					config.Ident = this.Name.ToLower();
				}
				config.Upgrade();
			}
			this.log = Logging.GetLogger("Addon/" + this.Name);
			this.Initialize();
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x0001B728 File Offset: 0x00019928
		public void Initialize()
		{
			string codeFolder = "/" + this.Config.CodePath;
			if (this.code == null && this.Config.HasCode && this.fileSystem.DirectoryExists(codeFolder) && this.fileSystem.FindFile(codeFolder + "/", "*.cs", true).Any<string>())
			{
				this.code = this.fileSystem.CreateSubSystem(codeFolder);
				this.code_watch = this.code.Watch("*.cs");
				this.code_watch.OnChanges += delegate(FileWatch w)
				{
					this.OnCodeChanged();
				};
			}
			if (this.content == null && this.Config.HasAssets)
			{
				this.content = this.fileSystem;
				this.shader_watch = this.content.Watch("*.vfx");
				this.shader_watch.OnChanges += delegate(FileWatch w)
				{
					this.OnShaderChanges(w.Changes);
				};
			}
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x0001B820 File Offset: 0x00019A20
		private void OnShaderChanges(List<string> changes)
		{
			foreach (string change in changes)
			{
				this.log.Info(FormattableStringFactory.Create("OnShaderChanges: {0}", new object[] { change }));
				string shaderName = Path.GetFileNameWithoutExtension(change);
				InputService.InsertCommand(InputCommandSource.ICS_CONSOLE, "mat_compileshaders " + shaderName, 0, 0);
			}
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x0001B8A0 File Offset: 0x00019AA0
		public void Dispose()
		{
			this.Deactivate();
			this.DestroyCode();
			BaseFileSystem baseFileSystem = this.content;
			if (baseFileSystem != null)
			{
				baseFileSystem.Dispose();
			}
			this.content = null;
			BaseFileSystem baseFileSystem2 = this.code;
			if (baseFileSystem2 != null)
			{
				baseFileSystem2.Dispose();
			}
			this.code = null;
			FileWatch fileWatch = this.code_watch;
			if (fileWatch != null)
			{
				fileWatch.Dispose();
			}
			this.code_watch = null;
			FileWatch fileWatch2 = this.shader_watch;
			if (fileWatch2 != null)
			{
				fileWatch2.Dispose();
			}
			this.shader_watch = null;
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x0001B91C File Offset: 0x00019B1C
		public void Activate()
		{
			if (this.IsActive)
			{
				return;
			}
			this.ActiveFileSystem = EngineFileSystem.Server;
			if (this.content != null)
			{
				if (!this.IsTransient)
				{
					this.ActiveFileSystem.Mount(this.content);
				}
				if (this.IsTransient)
				{
					SearchPath.Add(this.content.GetFullPath("/"), "GAME", true);
				}
			}
			this.ActiveFileSystem.Mount(this.code);
			this.IsActive = true;
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x0001B99C File Offset: 0x00019B9C
		public void ActivateWithDependancies()
		{
			if (this.IsActive)
			{
				return;
			}
			if (this.dependantDepth > 5)
			{
				throw new Exception("Cyclic addon dependancies detected!");
			}
			this.Activate();
			this.dependantDepth++;
			Addon[] dependancies = this.GetDependancies();
			for (int i = 0; i < dependancies.Length; i++)
			{
				dependancies[i].ActivateWithDependancies();
			}
			this.dependantDepth--;
		}

		/// <summary>
		/// Return a list of installed addons that we depend on. This will only return installed addons.
		/// If we have missing dependancies you won't find out about it here.
		/// </summary>
		// Token: 0x06000F79 RID: 3961 RVA: 0x0001BA08 File Offset: 0x00019C08
		public Addon[] GetDependancies()
		{
			if (this.Name == "base" || this.Name == "citizen" || this.Name == "rust")
			{
				return Array.Empty<Addon>();
			}
			return ServerAddons.All.Where((Addon x) => x.Name != this.Name && (x.Name == "base" || x.Name == "citizen" || x.Name == "rust")).ToArray<Addon>();
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x0001BA6C File Offset: 0x00019C6C
		public void Deactivate()
		{
			if (!this.IsActive)
			{
				return;
			}
			if (this.ActiveFileSystem != null && this.ActiveFileSystem.IsValid)
			{
				this.ActiveFileSystem.UnMount(this.content);
				this.ActiveFileSystem.UnMount(this.code);
			}
			this.ActiveFileSystem = null;
			this.DestroyCode();
			this.IsActive = false;
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x0001BAD0 File Offset: 0x00019CD0
		internal void InitCode()
		{
			if (this.code == null)
			{
				return;
			}
			if (this.compiler != null)
			{
				return;
			}
			this.compiler = CompileManager.CreateCompiler(this.Name, this.code);
			this.compiler.SetActive(true);
			this.compiler.Dependancies = (from x in this.GetDependancies()
				select x.GetCompiler() into x
				where x != null
				select x).ToList<Compiler>();
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x0001BB70 File Offset: 0x00019D70
		private Compiler GetCompiler()
		{
			this.InitCode();
			return this.compiler;
		}

		/// <summary>
		/// Called by the filesystem when the code has changed
		/// </summary>
		// Token: 0x06000F7D RID: 3965 RVA: 0x0001BB7E File Offset: 0x00019D7E
		private void OnCodeChanged()
		{
			if (!this.IsActive)
			{
				return;
			}
			this.Recompile();
		}

		/// <summary>
		/// Force the assembly to be recompiled
		/// </summary>
		// Token: 0x06000F7E RID: 3966 RVA: 0x0001BB90 File Offset: 0x00019D90
		public void Recompile()
		{
			this.InitCode();
			if (this.compiler == null)
			{
				return;
			}
			this.compiler.Dependancies = (from x in this.GetDependancies()
				select x.compiler into x
				where x != null
				select x).ToList<Compiler>();
			CompileManager.MarkForRecompile(this.compiler);
			foreach (Addon dependant in this.GetDependancies())
			{
				if (!dependant.IsCompiled)
				{
					dependant.Recompile();
				}
			}
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x0001BC3D File Offset: 0x00019E3D
		private void DestroyCode()
		{
			Compiler compiler = this.compiler;
			if (compiler != null)
			{
				compiler.Dispose();
			}
			this.compiler = null;
		}

		// Token: 0x04001213 RID: 4627
		private Logger log;

		// Token: 0x04001214 RID: 4628
		internal BaseFileSystem content;

		// Token: 0x04001215 RID: 4629
		internal BaseFileSystem code;

		// Token: 0x04001216 RID: 4630
		private FileWatch code_watch;

		// Token: 0x04001217 RID: 4631
		private FileWatch shader_watch;

		// Token: 0x04001218 RID: 4632
		internal Compiler compiler;

		// Token: 0x04001219 RID: 4633
		private BaseFileSystem ActiveFileSystem;

		// Token: 0x0400121A RID: 4634
		private int dependantDepth;
	}
}
