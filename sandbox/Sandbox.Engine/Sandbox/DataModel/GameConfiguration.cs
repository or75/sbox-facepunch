using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Sandbox.DataModel
{
	// Token: 0x0200030C RID: 780
	[NullableContext(1)]
	[Nullable(0)]
	public class GameConfiguration
	{
		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x060014FE RID: 5374 RVA: 0x0002CDFC File Offset: 0x0002AFFC
		// (set) Token: 0x060014FF RID: 5375 RVA: 0x0002CE04 File Offset: 0x0002B004
		[Range(1f, 64f, 0.01f, true)]
		[Display(Name = "Minimum Players")]
		[Category("Multiplayer")]
		public int MinPlayers { get; set; } = 1;

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06001500 RID: 5376 RVA: 0x0002CE0D File Offset: 0x0002B00D
		// (set) Token: 0x06001501 RID: 5377 RVA: 0x0002CE15 File Offset: 0x0002B015
		[Range(1f, 64f, 0.01f, true)]
		[Display(Name = "Maximum Players")]
		[Category("Multiplayer")]
		public int MaxPlayers { get; set; } = 16;

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06001502 RID: 5378 RVA: 0x0002CE1E File Offset: 0x0002B01E
		// (set) Token: 0x06001503 RID: 5379 RVA: 0x0002CE26 File Offset: 0x0002B026
		public GameNetworkType NetworkType { get; set; }

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06001504 RID: 5380 RVA: 0x0002CE2F File Offset: 0x0002B02F
		// (set) Token: 0x06001505 RID: 5381 RVA: 0x0002CE37 File Offset: 0x0002B037
		[Display(Name = "Map List")]
		[Category("Maps")]
		public List<string> MapList { get; set; } = new List<string> { "facepunch.construct" };

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06001506 RID: 5382 RVA: 0x0002CE40 File Offset: 0x0002B040
		// (set) Token: 0x06001507 RID: 5383 RVA: 0x0002CE48 File Offset: 0x0002B048
		[Display(Name = "Map Selection Mode")]
		[Category("Maps")]
		public MapSelect MapSelection { get; set; }

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06001508 RID: 5384 RVA: 0x0002CE51 File Offset: 0x0002B051
		// (set) Token: 0x06001509 RID: 5385 RVA: 0x0002CE59 File Offset: 0x0002B059
		[Category("Leaderboards & Ranks")]
		[Display(Name = "Ranking Model")]
		public GameConfiguration.RankTypes RankType { get; set; }

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x0600150A RID: 5386 RVA: 0x0002CE62 File Offset: 0x0002B062
		// (set) Token: 0x0600150B RID: 5387 RVA: 0x0002CE6A File Offset: 0x0002B06A
		[Category("Leaderboards & Ranks")]
		[Display(Name = "Leaderboard Model")]
		public GameConfiguration.LeaderboardTypes LeaderboardType { get; set; }

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x0600150C RID: 5388 RVA: 0x0002CE73 File Offset: 0x0002B073
		// (set) Token: 0x0600150D RID: 5389 RVA: 0x0002CE7B File Offset: 0x0002B07B
		[Category("Leaderboards & Ranks")]
		[Display(Name = "Per-map Rankings")]
		public bool PerMapRanking { get; set; }

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x0600150E RID: 5390 RVA: 0x0002CE84 File Offset: 0x0002B084
		public static GameConfiguration Default
		{
			get
			{
				return new GameConfiguration();
			}
		}

		// Token: 0x02000477 RID: 1143
		[NullableContext(0)]
		public enum RankTypes
		{
			// Token: 0x04001C55 RID: 7253
			[Display(Name = "None")]
			[Icon("sentiment_dissatisfied")]
			None,
			// Token: 0x04001C56 RID: 7254
			[Display(Name = "Elo")]
			[Icon("sentiment_dissatisfied")]
			Elo,
			// Token: 0x04001C57 RID: 7255
			[Display(Name = "Best")]
			[Icon("sentiment_dissatisfied")]
			Best,
			// Token: 0x04001C58 RID: 7256
			[Display(Name = "Increment")]
			[Icon("sentiment_dissatisfied")]
			Increment
		}

		// Token: 0x02000478 RID: 1144
		[NullableContext(0)]
		public enum LeaderboardTypes
		{
			// Token: 0x04001C5A RID: 7258
			[Display(Name = "None")]
			[Icon("sentiment_dissatisfied")]
			None,
			// Token: 0x04001C5B RID: 7259
			[Display(Name = "Descending")]
			[Icon("sentiment_dissatisfied")]
			Descending,
			// Token: 0x04001C5C RID: 7260
			[Display(Name = "Ascending")]
			[Icon("sentiment_dissatisfied")]
			Ascending
		}
	}
}
