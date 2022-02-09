using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sandbox.Internal;
using Sandbox.SolutionGenerator;

namespace Sandbox.DataModel
{
	// Token: 0x0200030B RID: 779
	public class AddonConfig
	{
		/// <summary>
		/// The directory housing this addon (todo)
		/// </summary>
		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x060014DE RID: 5342 RVA: 0x0002CB61 File Offset: 0x0002AD61
		// (set) Token: 0x060014DF RID: 5343 RVA: 0x0002CB69 File Offset: 0x0002AD69
		[JsonIgnore]
		[Browsable(false)]
		public DirectoryInfo Directory { get; set; }

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x060014E0 RID: 5344 RVA: 0x0002CB72 File Offset: 0x0002AD72
		// (set) Token: 0x060014E1 RID: 5345 RVA: 0x0002CB7A File Offset: 0x0002AD7A
		[Display(GroupName = "Assets", Order = 100, Name = "Shared Assets", Description = "Filters which assets should be sent to the client. This isn't great, we will replace it.")]
		public string SharedAssets { get; set; } = "*.*";

		/// <summary>
		/// The human readable title, for example "Sandbox", "Counter-Strike"
		/// </summary>
		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x060014E2 RID: 5346 RVA: 0x0002CB83 File Offset: 0x0002AD83
		// (set) Token: 0x060014E3 RID: 5347 RVA: 0x0002CB8B File Offset: 0x0002AD8B
		[Display(GroupName = "Setup", Order = -100, Name = "Title", Description = "The human readable title, for example \"Sandbox\", \"Counter - Strike\"")]
		public string Title { get; set; }

		/// <summary>
		/// The type of addon. Current valid values are "game"
		/// </summary>
		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x060014E4 RID: 5348 RVA: 0x0002CB94 File Offset: 0x0002AD94
		// (set) Token: 0x060014E5 RID: 5349 RVA: 0x0002CB9C File Offset: 0x0002AD9C
		[Display(GroupName = "Setup", Order = -90, Name = "Addon Type", Description = "Don't change this for christ's sake")]
		public string Type { get; set; }

		/// <summary>
		/// The ident of the org that owns this addon. For example "facepunch", "valve".
		/// </summary>
		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x060014E6 RID: 5350 RVA: 0x0002CBA5 File Offset: 0x0002ADA5
		// (set) Token: 0x060014E7 RID: 5351 RVA: 0x0002CBAD File Offset: 0x0002ADAD
		[Display(GroupName = "Setup", Order = -100, Name = "Organisation Ident", Description = "The ident of the org that owns this addon. Set to local if you don't have an org or are just testing.")]
		public string Org { get; set; }

		/// <summary>
		/// The ident of this addon. For example "sandbox", "cs" or "dm98"
		/// </summary>
		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x060014E8 RID: 5352 RVA: 0x0002CBB6 File Offset: 0x0002ADB6
		// (set) Token: 0x060014E9 RID: 5353 RVA: 0x0002CBBE File Offset: 0x0002ADBE
		[Display(GroupName = "Setup", Order = -100, Name = "Addon Ident", Description = "The ident of this addon. A short name with no special characters.")]
		public string Ident { get; set; }

		/// <summary>
		/// Returns a combination of Org and Ident - for example "facepunch.sandbox" or "valve.cs".
		/// </summary>
		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x060014EA RID: 5354 RVA: 0x0002CBC7 File Offset: 0x0002ADC7
		[Browsable(false)]
		[JsonIgnore]
		public string FullIdent
		{
			get
			{
				return this.Org + "." + this.Ident;
			}
		}

		/// <summary>
		/// The version of the addon file. Allows us to upgrade internally.
		/// </summary>
		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x060014EB RID: 5355 RVA: 0x0002CBDF File Offset: 0x0002ADDF
		// (set) Token: 0x060014EC RID: 5356 RVA: 0x0002CBE7 File Offset: 0x0002ADE7
		[Browsable(false)]
		public int Schema { get; set; }

		/// <summary>
		/// If this addon contains models, textures, sounds etc, this should be set to true.
		/// </summary>
		// Token: 0x17000422 RID: 1058
		// (get) Token: 0x060014ED RID: 5357 RVA: 0x0002CBF0 File Offset: 0x0002ADF0
		// (set) Token: 0x060014EE RID: 5358 RVA: 0x0002CBF8 File Offset: 0x0002ADF8
		[Display(GroupName = "Assets", Order = 100, Name = "Has Assets", Description = "Set to true if this addon has models, materials etc")]
		public bool HasAssets { get; set; }

		/// <summary>
		/// A relative path to the assets folder in your addon. HasAssets should be set to true.
		/// Leave this empty to use the root folder as the root of your addon path.
		/// </summary>
		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x060014EF RID: 5359 RVA: 0x0002CC01 File Offset: 0x0002AE01
		// (set) Token: 0x060014F0 RID: 5360 RVA: 0x0002CC09 File Offset: 0x0002AE09
		[Display(GroupName = "Assets", Order = 100, Name = "Assets Path", Description = "The relative path to your addon's assets. Leave this blank to use the root.")]
		public string AssetsPath { get; set; }

		/// <summary>
		/// If this addon contains code, this should be set to true
		/// </summary>
		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x060014F1 RID: 5361 RVA: 0x0002CC12 File Offset: 0x0002AE12
		// (set) Token: 0x060014F2 RID: 5362 RVA: 0x0002CC1A File Offset: 0x0002AE1A
		[Display(GroupName = "Code", Order = 200, Name = "Has Code", Description = "If this addon contains code, this should be set to true")]
		public bool HasCode { get; set; }

		/// <summary>
		/// A relative path to the code for your addon. HasCode should be set to true.
		/// Leave this empty if you want the root folder to host your code.
		/// </summary>
		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x060014F3 RID: 5363 RVA: 0x0002CC23 File Offset: 0x0002AE23
		// (set) Token: 0x060014F4 RID: 5364 RVA: 0x0002CC2B File Offset: 0x0002AE2B
		[Display(GroupName = "Code", Order = 210, Name = "Code Path", Description = "The relative path to your addon's code. The default is \"code\".")]
		public string CodePath { get; set; }

		/// <summary>
		/// For code, the default root namespace to use
		/// </summary>
		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x060014F5 RID: 5365 RVA: 0x0002CC34 File Offset: 0x0002AE34
		// (set) Token: 0x060014F6 RID: 5366 RVA: 0x0002CC3C File Offset: 0x0002AE3C
		[Display(GroupName = "Code", Order = 220, Name = "Root Namespace", Description = "The default namespace to use in your addon's code. Some nerds like to change this. The default is \"Sandbox\".")]
		public string RootNamespace { get; set; }

		// Token: 0x060014F7 RID: 5367 RVA: 0x0002CC45 File Offset: 0x0002AE45
		public override string ToString()
		{
			return this.FullIdent;
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x0002CC4D File Offset: 0x0002AE4D
		private bool AddonTypeUsesCode()
		{
			return this.Type == "game" || this.Type == "editor";
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x0002CC78 File Offset: 0x0002AE78
		internal void GenerateProject(Generator generator)
		{
			if (!this.AddonTypeUsesCode())
			{
				return;
			}
			if (!this.HasCode)
			{
				return;
			}
			if (this.Directory == null)
			{
				return;
			}
			generator.AddProject("Games", this.Ident, this.Directory.FullName + "/" + this.CodePath, this.RootNamespace).GlobalNamespaces.Add("Sandbox.Internal.GlobalGameNamespace");
		}

		// Token: 0x060014FA RID: 5370 RVA: 0x0002CCE4 File Offset: 0x0002AEE4
		internal void Init(string path)
		{
			this.Directory = new DirectoryInfo(Path.GetDirectoryName(path));
			if (this.Org == null)
			{
				this.Org = "local";
			}
			if (this.Ident == null)
			{
				this.Ident = this.Directory.Name.ToLower();
			}
		}

		// Token: 0x060014FB RID: 5371 RVA: 0x0002CD38 File Offset: 0x0002AF38
		internal bool Upgrade()
		{
			if (this.Schema == 1)
			{
				return false;
			}
			if (this.Schema < 1)
			{
				this.Type = "game";
				this.Title = this.Ident.ToTitleCase();
				this.RootNamespace = "Sandbox";
				this.HasAssets = true;
				this.AssetsPath = "";
				this.HasCode = true;
				this.CodePath = "code";
				this.SharedAssets = "*.*";
				this.Schema = 1;
				GlobalSystemNamespace.Log.Info(FormattableStringFactory.Create("Upgraded addon {0} schema from 0 > 1", new object[] { this }));
			}
			return true;
		}

		// Token: 0x060014FC RID: 5372 RVA: 0x0002CDD5 File Offset: 0x0002AFD5
		public string ToJson()
		{
			return JsonSerializer.Serialize<AddonConfig>(this, new JsonSerializerOptions
			{
				WriteIndented = true
			});
		}
	}
}
