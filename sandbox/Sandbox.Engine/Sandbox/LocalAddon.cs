using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sandbox.DataModel;
using Sandbox.Internal;
using Sandbox.SolutionGenerator;

namespace Sandbox
{
	// Token: 0x0200027F RID: 639
	public class LocalAddon
	{
		/// <summary>
		/// Absolute path to the .addon file
		/// </summary>
		// Token: 0x170002DC RID: 732
		// (get) Token: 0x06000F83 RID: 3971 RVA: 0x0001BCC8 File Offset: 0x00019EC8
		// (set) Token: 0x06000F84 RID: 3972 RVA: 0x0001BCD0 File Offset: 0x00019ED0
		public string Path { get; set; }

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x06000F85 RID: 3973 RVA: 0x0001BCD9 File Offset: 0x00019ED9
		// (set) Token: 0x06000F86 RID: 3974 RVA: 0x0001BCE1 File Offset: 0x00019EE1
		public bool Active { get; set; }

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x06000F87 RID: 3975 RVA: 0x0001BCEA File Offset: 0x00019EEA
		// (set) Token: 0x06000F88 RID: 3976 RVA: 0x0001BCF2 File Offset: 0x00019EF2
		[JsonIgnore]
		public bool Broken { get; set; }

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x06000F89 RID: 3977 RVA: 0x0001BCFB File Offset: 0x00019EFB
		// (set) Token: 0x06000F8A RID: 3978 RVA: 0x0001BD03 File Offset: 0x00019F03
		[JsonIgnore]
		public AddonConfig Config { get; set; }

		// Token: 0x06000F8B RID: 3979 RVA: 0x0001BD0C File Offset: 0x00019F0C
		internal bool HasIdent(string ident)
		{
			AddonConfig config = this.Config;
			return ((config != null) ? config.FullIdent : null) == ident;
		}

		// Token: 0x06000F8C RID: 3980 RVA: 0x0001BD28 File Offset: 0x00019F28
		private void Load()
		{
			if (!this.Path.EndsWith(".addon"))
			{
				this.Path = System.IO.Path.Combine(this.Path, ".addon");
			}
			try
			{
				string text = File.ReadAllText(this.Path);
				this.Config = JsonSerializer.Deserialize<AddonConfig>(text, null);
				this.Config.Init(this.Path);
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(e, FormattableStringFactory.Create("Addon config error ({0}) - deactivating addon", new object[] { e.Message }));
				this.Broken = true;
				this.Active = false;
			}
		}

		// Token: 0x06000F8D RID: 3981 RVA: 0x0001BDD0 File Offset: 0x00019FD0
		private void Save()
		{
			if (this.Config == null)
			{
				return;
			}
			if (!this.Path.EndsWith(".addon"))
			{
				return;
			}
			string json = this.Config.ToJson();
			File.WriteAllText(this.Path, json);
		}

		// Token: 0x06000F8E RID: 3982 RVA: 0x0001BE11 File Offset: 0x0001A011
		internal static void LoadFromConfig()
		{
			LocalAddon.All = EngineFileSystem.Config.ReadJsonOrDefault<List<LocalAddon>>("/addons.json", LocalAddon.All);
			LocalAddon.Initialize();
		}

		// Token: 0x06000F8F RID: 3983 RVA: 0x0001BE34 File Offset: 0x0001A034
		internal static void Initialize()
		{
			foreach (LocalAddon localAddon in LocalAddon.All)
			{
				localAddon.Load();
			}
			if (LocalAddon.All.RemoveAll((LocalAddon x) => x.Broken) > 0)
			{
				LocalAddon.SaveAll();
			}
			try
			{
				LocalAddon.GenerateSolution();
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(e, FormattableStringFactory.Create("Exception when generating solution", Array.Empty<object>()));
			}
		}

		// Token: 0x06000F90 RID: 3984 RVA: 0x0001BEE8 File Offset: 0x0001A0E8
		internal static void SaveAll()
		{
			EngineFileSystem.Config.WriteJson<List<LocalAddon>>("/addons.json", LocalAddon.All);
			foreach (LocalAddon localAddon in LocalAddon.All)
			{
				localAddon.Save();
			}
		}

		// Token: 0x06000F91 RID: 3985 RVA: 0x0001BF4C File Offset: 0x0001A14C
		internal static void GenerateSolution()
		{
			Generator generator = new Generator();
			ProjectInfo projectInfo = generator.AddProject("Core", "base", EngineFileSystem.Root.GetFullPath("/addons/base/code/"), "Sandbox");
			projectInfo.GlobalNamespaces.Add("Sandbox.Internal.GlobalGameNamespace");
			projectInfo.IsBaseProject = true;
			ProjectInfo projectInfo2 = generator.AddProject("Core", "menu", EngineFileSystem.Root.GetFullPath("/addons/menu/code/"), "Sandbox");
			projectInfo2.References.Add("Sandbox.Menu.dll");
			projectInfo2.GlobalNamespaces.Add("Sandbox.Internal.GlobalGameNamespace");
			ProjectInfo projectInfo3 = generator.AddProject("Tools", "tools", EngineFileSystem.Root.GetFullPath("/addons/tools/"), "Sandbox.Tools");
			projectInfo3.References.Add("Sandbox.Tools.dll");
			projectInfo3.References.Remove("Sandbox.Game.dll");
			projectInfo3.GlobalNamespaces.Add("Sandbox.Internal.GlobalToolsNamespace");
			projectInfo3.IsBaseProject = true;
			foreach (LocalAddon addon in LocalAddon.All)
			{
				if (addon.Active)
				{
					AddonConfig config = addon.Config;
					if (config != null)
					{
						config.GenerateProject(generator);
					}
				}
			}
			generator.Run("sbox.exe", "bin/managed", "s&box.sln", EngineFileSystem.Root.GetFullPath("/"));
		}

		// Token: 0x06000F92 RID: 3986 RVA: 0x0001C0B4 File Offset: 0x0001A2B4
		internal static LocalAddon AddFromFile(string path)
		{
			if (!path.EndsWith(".addon"))
			{
				path = System.IO.Path.Combine(path, ".addon");
			}
			string cleanPath = System.IO.Path.GetFullPath(path);
			if (LocalAddon.All.Where((LocalAddon a) => a.Path == cleanPath).Any<LocalAddon>())
			{
				throw new Exception("Addon is already added. (" + cleanPath + ")");
			}
			LocalAddon addon = new LocalAddon
			{
				Path = cleanPath,
				Active = true
			};
			addon.Load();
			if (addon.Broken)
			{
				throw new Exception("Couldn't add addon.");
			}
			if (addon.Config.Upgrade())
			{
				addon.Save();
			}
			LocalAddon.All.Add(addon);
			LocalAddon.SaveAll();
			LocalAddon.Initialize();
			return addon;
		}

		// Token: 0x06000F93 RID: 3987 RVA: 0x0001C180 File Offset: 0x0001A380
		internal static void Remove(LocalAddon addon)
		{
			if (!LocalAddon.All.Remove(addon))
			{
				return;
			}
			LocalAddon.SaveAll();
			LocalAddon.Initialize();
		}

		// Token: 0x06000F94 RID: 3988 RVA: 0x0001C19C File Offset: 0x0001A39C
		internal static LocalAddon FindByIdent(string ident)
		{
			return LocalAddon.All.FirstOrDefault((LocalAddon x) => x.HasIdent(ident));
		}

		// Token: 0x0400121F RID: 4639
		internal static List<LocalAddon> All = new List<LocalAddon>();
	}
}
