using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Sandbox.DataModel;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000289 RID: 649
	public class Package
	{
		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06001011 RID: 4113 RVA: 0x0001CFD0 File Offset: 0x0001B1D0
		// (set) Token: 0x06001012 RID: 4114 RVA: 0x0001CFD8 File Offset: 0x0001B1D8
		public Package.Organization Org { get; set; }

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06001013 RID: 4115 RVA: 0x0001CFE1 File Offset: 0x0001B1E1
		// (set) Token: 0x06001014 RID: 4116 RVA: 0x0001CFE9 File Offset: 0x0001B1E9
		public Package.DownloadDetail Download { get; set; }

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06001015 RID: 4117 RVA: 0x0001CFF2 File Offset: 0x0001B1F2
		public string FullIdent
		{
			get
			{
				return this.Org.Ident + "." + this.Ident;
			}
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06001016 RID: 4118 RVA: 0x0001D00F File Offset: 0x0001B20F
		// (set) Token: 0x06001017 RID: 4119 RVA: 0x0001D017 File Offset: 0x0001B217
		public string Ident { get; set; }

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x06001018 RID: 4120 RVA: 0x0001D020 File Offset: 0x0001B220
		// (set) Token: 0x06001019 RID: 4121 RVA: 0x0001D028 File Offset: 0x0001B228
		public string Title { get; set; }

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x0600101A RID: 4122 RVA: 0x0001D031 File Offset: 0x0001B231
		// (set) Token: 0x0600101B RID: 4123 RVA: 0x0001D039 File Offset: 0x0001B239
		public string Summary { get; set; }

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x0600101C RID: 4124 RVA: 0x0001D042 File Offset: 0x0001B242
		// (set) Token: 0x0600101D RID: 4125 RVA: 0x0001D04A File Offset: 0x0001B24A
		public string Description { get; set; }

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x0600101E RID: 4126 RVA: 0x0001D053 File Offset: 0x0001B253
		// (set) Token: 0x0600101F RID: 4127 RVA: 0x0001D05B File Offset: 0x0001B25B
		public string Thumb { get; set; }

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06001020 RID: 4128 RVA: 0x0001D064 File Offset: 0x0001B264
		// (set) Token: 0x06001021 RID: 4129 RVA: 0x0001D06C File Offset: 0x0001B26C
		public string Background { get; set; }

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06001022 RID: 4130 RVA: 0x0001D075 File Offset: 0x0001B275
		// (set) Token: 0x06001023 RID: 4131 RVA: 0x0001D07D File Offset: 0x0001B27D
		public string[] Tags { get; set; }

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06001024 RID: 4132 RVA: 0x0001D086 File Offset: 0x0001B286
		// (set) Token: 0x06001025 RID: 4133 RVA: 0x0001D08E File Offset: 0x0001B28E
		public Package.Type PackageType { get; set; }

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06001026 RID: 4134 RVA: 0x0001D097 File Offset: 0x0001B297
		public GameConfiguration GameConfiguration
		{
			get
			{
				if (this._gameconf == null)
				{
					this._gameconf = this.ConfigJson.Deserialize(() => GameConfiguration.Default);
				}
				return this._gameconf;
			}
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06001027 RID: 4135 RVA: 0x0001D0D7 File Offset: 0x0001B2D7
		// (set) Token: 0x06001028 RID: 4136 RVA: 0x0001D0DF File Offset: 0x0001B2DF
		public int UsersNow { get; set; }

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06001029 RID: 4137 RVA: 0x0001D0E8 File Offset: 0x0001B2E8
		// (set) Token: 0x0600102A RID: 4138 RVA: 0x0001D0F0 File Offset: 0x0001B2F0
		public int UsersDay { get; set; }

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x0600102B RID: 4139 RVA: 0x0001D0F9 File Offset: 0x0001B2F9
		// (set) Token: 0x0600102C RID: 4140 RVA: 0x0001D101 File Offset: 0x0001B301
		public int UsersMonth { get; set; }

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x0600102D RID: 4141 RVA: 0x0001D10A File Offset: 0x0001B30A
		// (set) Token: 0x0600102E RID: 4142 RVA: 0x0001D112 File Offset: 0x0001B312
		public int UsersTotal { get; set; }

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x0600102F RID: 4143 RVA: 0x0001D11B File Offset: 0x0001B31B
		// (set) Token: 0x06001030 RID: 4144 RVA: 0x0001D123 File Offset: 0x0001B323
		public int Favourited { get; set; }

		// Token: 0x1700031A RID: 794
		// (get) Token: 0x06001031 RID: 4145 RVA: 0x0001D12C File Offset: 0x0001B32C
		// (set) Token: 0x06001032 RID: 4146 RVA: 0x0001D134 File Offset: 0x0001B334
		public int VotesUp { get; set; }

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x06001033 RID: 4147 RVA: 0x0001D13D File Offset: 0x0001B33D
		// (set) Token: 0x06001034 RID: 4148 RVA: 0x0001D145 File Offset: 0x0001B345
		public int VotesDown { get; set; }

		// Token: 0x1700031C RID: 796
		// (get) Token: 0x06001035 RID: 4149 RVA: 0x0001D14E File Offset: 0x0001B34E
		// (set) Token: 0x06001036 RID: 4150 RVA: 0x0001D156 File Offset: 0x0001B356
		public int CategoryId { get; set; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x06001037 RID: 4151 RVA: 0x0001D15F File Offset: 0x0001B35F
		// (set) Token: 0x06001038 RID: 4152 RVA: 0x0001D167 File Offset: 0x0001B367
		public int SubCategoryId { get; set; }

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x06001039 RID: 4153 RVA: 0x0001D170 File Offset: 0x0001B370
		public bool IsFavourite
		{
			get
			{
				return AccountInformation.IsFavourite(this.FullIdent);
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x0600103A RID: 4154 RVA: 0x0001D17D File Offset: 0x0001B37D
		public bool CanEdit
		{
			get
			{
				return this.Org != null && AccountInformation.HasOrganization(this.Org.Ident);
			}
		}

		// Token: 0x17000320 RID: 800
		// (get) Token: 0x0600103B RID: 4155 RVA: 0x0001D199 File Offset: 0x0001B399
		// (set) Token: 0x0600103C RID: 4156 RVA: 0x0001D1A1 File Offset: 0x0001B3A1
		[JsonInclude]
		public string ConfigJson { get; internal set; }

		// Token: 0x17000321 RID: 801
		// (get) Token: 0x0600103D RID: 4157 RVA: 0x0001D1AA File Offset: 0x0001B3AA
		// (set) Token: 0x0600103E RID: 4158 RVA: 0x0001D1B2 File Offset: 0x0001B3B2
		public GameCategoryTypes GameCategory
		{
			get
			{
				return (GameCategoryTypes)this.CategoryId;
			}
			set
			{
				this.CategoryId = (int)value;
			}
		}

		/// <summary>
		/// When the entry was last updated. If these are different between packages 
		/// then something updated on the backend.
		/// </summary>
		// Token: 0x17000322 RID: 802
		// (get) Token: 0x0600103F RID: 4159 RVA: 0x0001D1BB File Offset: 0x0001B3BB
		// (set) Token: 0x06001040 RID: 4160 RVA: 0x0001D1C3 File Offset: 0x0001B3C3
		public int Updated { get; set; }

		// Token: 0x06001041 RID: 4161 RVA: 0x0001D1CC File Offset: 0x0001B3CC
		internal static void InitializeCache()
		{
			Package.Packages = new Dictionary<string, Package>(StringComparer.OrdinalIgnoreCase);
			Package.PartialPackages = new Dictionary<string, Package>(StringComparer.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Find package information
		/// </summary>
		// Token: 0x06001042 RID: 4162 RVA: 0x0001D1EC File Offset: 0x0001B3EC
		public static async Task<Package> Fetch(string ident, bool partial)
		{
			Package result;
			Package package;
			if (ident.StartsWith("local."))
			{
				result = Package.GetLocal().FirstOrDefault((Package x) => x.FullIdent == ident);
			}
			else if (Package.Packages.TryGetValue(ident, out package))
			{
				result = package;
			}
			else if (partial && Package.PartialPackages.TryGetValue(ident, out package))
			{
				result = package;
			}
			else if (!ident.Contains("."))
			{
				result = null;
			}
			else
			{
				package = await Api.GetAsset(ident);
				if (package == null)
				{
					result = Package.GetLocal().FirstOrDefault((Package x) => x.FullIdent == ident);
				}
				else
				{
					Package.Cache(package, false);
					result = package;
				}
			}
			return result;
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x0001D237 File Offset: 0x0001B437
		public static IEnumerable<Package> GetLocal()
		{
			foreach (LocalAddon addon in LocalAddon.All)
			{
				if (addon.Active)
				{
					Package val;
					if (Package.Packages.TryGetValue(addon.Config.FullIdent, out val))
					{
						yield return val;
					}
					else if (Package.PartialPackages.TryGetValue(addon.Config.FullIdent, out val))
					{
						yield return val;
					}
					else
					{
						Package p = new Package
						{
							PackageType = Package.Type.Gamemode,
							Ident = addon.Config.FullIdent,
							Title = addon.Config.Title,
							Org = new Package.Organization
							{
								Ident = "local"
							},
							Tags = Array.Empty<string>()
						};
						p.Org.Ident = addon.Config.Org;
						p.Ident = addon.Config.Ident;
						yield return p;
					}
				}
			}
			List<LocalAddon>.Enumerator enumerator = default(List<LocalAddon>.Enumerator);
			yield break;
			yield break;
		}

		/// <summary>
		/// Find the gamemode info. We might already have the information, in which case we'll return a cached version.
		/// </summary>
		// Token: 0x06001044 RID: 4164 RVA: 0x0001D240 File Offset: 0x0001B440
		internal static async Task<Package> FindAsync(string gamemode)
		{
			Package localPackage = Package.GetLocal().FirstOrDefault((Package x) => x.FullIdent == gamemode);
			Package result;
			if (localPackage != null)
			{
				result = localPackage;
			}
			else
			{
				Package info = await Package.Fetch(gamemode, false);
				if (info != null)
				{
					if (info.PackageType != Package.Type.Gamemode)
					{
						GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Found the asset but it's a {0} - we're looking for a gamemode", new object[] { info.PackageType }));
						result = null;
					}
					else
					{
						result = info;
					}
				}
				else
				{
					result = null;
				}
			}
			return result;
		}

		/// <summary>
		/// If we have this package information, try to get its name
		/// </summary>
		// Token: 0x06001045 RID: 4165 RVA: 0x0001D284 File Offset: 0x0001B484
		public static string GetCachedTitle(string ident)
		{
			Package package;
			if (Package.PartialPackages.TryGetValue(ident, out package))
			{
				return package.Title;
			}
			return ident;
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x0001D2A8 File Offset: 0x0001B4A8
		internal static void Cache(Package[] list, bool partial)
		{
			for (int i = 0; i < list.Length; i++)
			{
				Package.Cache(list[i], partial);
			}
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x0001D2CE File Offset: 0x0001B4CE
		internal static void Cache(Package package, bool partial)
		{
			if (partial)
			{
				Package.PartialPackages[package.FullIdent] = package;
				return;
			}
			Package.Packages[package.FullIdent] = package;
			Package.PartialPackages[package.FullIdent] = package;
		}

		// Token: 0x0400125C RID: 4700
		private GameConfiguration _gameconf;

		// Token: 0x04001268 RID: 4712
		private static Dictionary<string, Package> Packages;

		// Token: 0x04001269 RID: 4713
		private static Dictionary<string, Package> PartialPackages;

		// Token: 0x020003DA RID: 986
		public class Organization
		{
			// Token: 0x17000470 RID: 1136
			// (get) Token: 0x0600171B RID: 5915 RVA: 0x000356C5 File Offset: 0x000338C5
			// (set) Token: 0x0600171C RID: 5916 RVA: 0x000356CD File Offset: 0x000338CD
			public string Ident { get; set; }

			// Token: 0x17000471 RID: 1137
			// (get) Token: 0x0600171D RID: 5917 RVA: 0x000356D6 File Offset: 0x000338D6
			// (set) Token: 0x0600171E RID: 5918 RVA: 0x000356DE File Offset: 0x000338DE
			public string Title { get; set; }

			// Token: 0x17000472 RID: 1138
			// (get) Token: 0x0600171F RID: 5919 RVA: 0x000356E7 File Offset: 0x000338E7
			// (set) Token: 0x06001720 RID: 5920 RVA: 0x000356EF File Offset: 0x000338EF
			public string SocialTwitter { get; set; }

			// Token: 0x17000473 RID: 1139
			// (get) Token: 0x06001721 RID: 5921 RVA: 0x000356F8 File Offset: 0x000338F8
			// (set) Token: 0x06001722 RID: 5922 RVA: 0x00035700 File Offset: 0x00033900
			public string SocialWeb { get; set; }

			// Token: 0x17000474 RID: 1140
			// (get) Token: 0x06001723 RID: 5923 RVA: 0x00035709 File Offset: 0x00033909
			// (set) Token: 0x06001724 RID: 5924 RVA: 0x00035711 File Offset: 0x00033911
			public string Description { get; set; }

			// Token: 0x17000475 RID: 1141
			// (get) Token: 0x06001725 RID: 5925 RVA: 0x0003571A File Offset: 0x0003391A
			// (set) Token: 0x06001726 RID: 5926 RVA: 0x00035722 File Offset: 0x00033922
			public string Thumb { get; set; }

			// Token: 0x17000476 RID: 1142
			// (get) Token: 0x06001727 RID: 5927 RVA: 0x0003572B File Offset: 0x0003392B
			// (set) Token: 0x06001728 RID: 5928 RVA: 0x00035733 File Offset: 0x00033933
			public DateTimeOffset Created { get; set; }
		}

		// Token: 0x020003DB RID: 987
		public class Usage
		{
			// Token: 0x17000477 RID: 1143
			// (get) Token: 0x0600172A RID: 5930 RVA: 0x00035744 File Offset: 0x00033944
			// (set) Token: 0x0600172B RID: 5931 RVA: 0x0003574C File Offset: 0x0003394C
			public Package Package { get; set; }

			// Token: 0x17000478 RID: 1144
			// (get) Token: 0x0600172C RID: 5932 RVA: 0x00035755 File Offset: 0x00033955
			// (set) Token: 0x0600172D RID: 5933 RVA: 0x0003575D File Offset: 0x0003395D
			public int Minutes { get; set; }

			// Token: 0x17000479 RID: 1145
			// (get) Token: 0x0600172E RID: 5934 RVA: 0x00035766 File Offset: 0x00033966
			// (set) Token: 0x0600172F RID: 5935 RVA: 0x0003576E File Offset: 0x0003396E
			public DateTime LastSeen { get; set; }

			// Token: 0x1700047A RID: 1146
			// (get) Token: 0x06001730 RID: 5936 RVA: 0x00035777 File Offset: 0x00033977
			// (set) Token: 0x06001731 RID: 5937 RVA: 0x0003577F File Offset: 0x0003397F
			public DateTime FirstSeen { get; set; }
		}

		// Token: 0x020003DC RID: 988
		public class DownloadDetail
		{
			// Token: 0x1700047B RID: 1147
			// (get) Token: 0x06001733 RID: 5939 RVA: 0x00035790 File Offset: 0x00033990
			// (set) Token: 0x06001734 RID: 5940 RVA: 0x00035798 File Offset: 0x00033998
			public string Type { get; set; }

			// Token: 0x1700047C RID: 1148
			// (get) Token: 0x06001735 RID: 5941 RVA: 0x000357A1 File Offset: 0x000339A1
			// (set) Token: 0x06001736 RID: 5942 RVA: 0x000357A9 File Offset: 0x000339A9
			public uint Crc { get; set; }

			// Token: 0x1700047D RID: 1149
			// (get) Token: 0x06001737 RID: 5943 RVA: 0x000357B2 File Offset: 0x000339B2
			// (set) Token: 0x06001738 RID: 5944 RVA: 0x000357BA File Offset: 0x000339BA
			public int Size { get; set; }

			// Token: 0x1700047E RID: 1150
			// (get) Token: 0x06001739 RID: 5945 RVA: 0x000357C3 File Offset: 0x000339C3
			// (set) Token: 0x0600173A RID: 5946 RVA: 0x000357CB File Offset: 0x000339CB
			public string Url { get; set; }
		}

		// Token: 0x020003DD RID: 989
		public enum Type
		{
			// Token: 0x04001971 RID: 6513
			Map = 1,
			// Token: 0x04001972 RID: 6514
			Gamemode
		}

		// Token: 0x020003DE RID: 990
		public class Category
		{
			// Token: 0x1700047F RID: 1151
			// (get) Token: 0x0600173C RID: 5948 RVA: 0x000357DC File Offset: 0x000339DC
			// (set) Token: 0x0600173D RID: 5949 RVA: 0x000357E4 File Offset: 0x000339E4
			public string Title { get; set; }

			// Token: 0x17000480 RID: 1152
			// (get) Token: 0x0600173E RID: 5950 RVA: 0x000357ED File Offset: 0x000339ED
			// (set) Token: 0x0600173F RID: 5951 RVA: 0x000357F5 File Offset: 0x000339F5
			public string Description { get; set; }

			// Token: 0x17000481 RID: 1153
			// (get) Token: 0x06001740 RID: 5952 RVA: 0x000357FE File Offset: 0x000339FE
			// (set) Token: 0x06001741 RID: 5953 RVA: 0x00035806 File Offset: 0x00033A06
			public Package[] Packages { get; set; }
		}

		// Token: 0x020003DF RID: 991
		public struct CategoryInformation
		{
			// Token: 0x17000482 RID: 1154
			// (get) Token: 0x06001743 RID: 5955 RVA: 0x00035817 File Offset: 0x00033A17
			// (set) Token: 0x06001744 RID: 5956 RVA: 0x0003581F File Offset: 0x00033A1F
			public int Count { readonly get; set; }

			// Token: 0x17000483 RID: 1155
			// (get) Token: 0x06001745 RID: 5957 RVA: 0x00035828 File Offset: 0x00033A28
			// (set) Token: 0x06001746 RID: 5958 RVA: 0x00035830 File Offset: 0x00033A30
			public string Title { readonly get; set; }

			// Token: 0x17000484 RID: 1156
			// (get) Token: 0x06001747 RID: 5959 RVA: 0x00035839 File Offset: 0x00033A39
			// (set) Token: 0x06001748 RID: 5960 RVA: 0x00035841 File Offset: 0x00033A41
			public string Icon { readonly get; set; }

			// Token: 0x17000485 RID: 1157
			// (get) Token: 0x06001749 RID: 5961 RVA: 0x0003584A File Offset: 0x00033A4A
			// (set) Token: 0x0600174A RID: 5962 RVA: 0x00035852 File Offset: 0x00033A52
			public string Description { readonly get; set; }

			// Token: 0x17000486 RID: 1158
			// (get) Token: 0x0600174B RID: 5963 RVA: 0x0003585B File Offset: 0x00033A5B
			// (set) Token: 0x0600174C RID: 5964 RVA: 0x00035863 File Offset: 0x00033A63
			public int Id { readonly get; set; }
		}

		// Token: 0x020003E0 RID: 992
		public struct TagInformation
		{
			// Token: 0x17000487 RID: 1159
			// (get) Token: 0x0600174D RID: 5965 RVA: 0x0003586C File Offset: 0x00033A6C
			// (set) Token: 0x0600174E RID: 5966 RVA: 0x00035874 File Offset: 0x00033A74
			public string Key { readonly get; set; }

			// Token: 0x17000488 RID: 1160
			// (get) Token: 0x0600174F RID: 5967 RVA: 0x0003587D File Offset: 0x00033A7D
			// (set) Token: 0x06001750 RID: 5968 RVA: 0x00035885 File Offset: 0x00033A85
			public int Count { readonly get; set; }
		}

		// Token: 0x020003E1 RID: 993
		public class CategoryList
		{
			// Token: 0x17000489 RID: 1161
			// (get) Token: 0x06001751 RID: 5969 RVA: 0x0003588E File Offset: 0x00033A8E
			// (set) Token: 0x06001752 RID: 5970 RVA: 0x00035896 File Offset: 0x00033A96
			public Package.CategoryInformation[] Categories { get; set; }

			// Token: 0x1700048A RID: 1162
			// (get) Token: 0x06001753 RID: 5971 RVA: 0x0003589F File Offset: 0x00033A9F
			// (set) Token: 0x06001754 RID: 5972 RVA: 0x000358A7 File Offset: 0x00033AA7
			public Package.TagInformation[] Tags { get; set; }
		}
	}
}
