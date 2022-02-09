using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Sandbox
{
	// Token: 0x02000285 RID: 645
	[NullableContext(1)]
	[Nullable(0)]
	internal class GameDescription
	{
		// Token: 0x06000FD3 RID: 4051 RVA: 0x0001CC98 File Offset: 0x0001AE98
		public GameDescription(string gameName, string mapName)
		{
			this.Game = gameName;
			this.Map = mapName;
		}

		// Token: 0x170002EE RID: 750
		// (get) Token: 0x06000FD4 RID: 4052 RVA: 0x0001CCCF File Offset: 0x0001AECF
		// (set) Token: 0x06000FD5 RID: 4053 RVA: 0x0001CCD7 File Offset: 0x0001AED7
		public DateTimeOffset StartTime { get; set; }

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06000FD6 RID: 4054 RVA: 0x0001CCE0 File Offset: 0x0001AEE0
		// (set) Token: 0x06000FD7 RID: 4055 RVA: 0x0001CCE8 File Offset: 0x0001AEE8
		public DateTimeOffset EndTime { get; set; }

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06000FD8 RID: 4056 RVA: 0x0001CCF1 File Offset: 0x0001AEF1
		// (set) Token: 0x06000FD9 RID: 4057 RVA: 0x0001CCF9 File Offset: 0x0001AEF9
		public bool Abandoned { get; set; }

		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x06000FDA RID: 4058 RVA: 0x0001CD02 File Offset: 0x0001AF02
		// (set) Token: 0x06000FDB RID: 4059 RVA: 0x0001CD0A File Offset: 0x0001AF0A
		public bool AbandonedBecausePlayerLeave { get; set; }

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x06000FDC RID: 4060 RVA: 0x0001CD13 File Offset: 0x0001AF13
		// (set) Token: 0x06000FDD RID: 4061 RVA: 0x0001CD1B File Offset: 0x0001AF1B
		public List<GameDescription.LogEntry> Log { get; set; } = new List<GameDescription.LogEntry>();

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06000FDE RID: 4062 RVA: 0x0001CD24 File Offset: 0x0001AF24
		// (set) Token: 0x06000FDF RID: 4063 RVA: 0x0001CD2C File Offset: 0x0001AF2C
		public List<GameDescription.PlayerInfo> Players { get; set; } = new List<GameDescription.PlayerInfo>();

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06000FE0 RID: 4064 RVA: 0x0001CD35 File Offset: 0x0001AF35
		// (set) Token: 0x06000FE1 RID: 4065 RVA: 0x0001CD3D File Offset: 0x0001AF3D
		public string Game { get; set; }

		// Token: 0x170002F5 RID: 757
		// (get) Token: 0x06000FE2 RID: 4066 RVA: 0x0001CD46 File Offset: 0x0001AF46
		// (set) Token: 0x06000FE3 RID: 4067 RVA: 0x0001CD4E File Offset: 0x0001AF4E
		public string Map { get; set; }

		// Token: 0x06000FE4 RID: 4068 RVA: 0x0001CD58 File Offset: 0x0001AF58
		[NullableContext(2)]
		internal GameDescription.PlayerInfo FindPlayer(long steamId)
		{
			return this.Players.FirstOrDefault((GameDescription.PlayerInfo x) => x.UserId == steamId);
		}

		// Token: 0x06000FE5 RID: 4069 RVA: 0x0001CD8C File Offset: 0x0001AF8C
		internal GameDescription.PlayerInfo GetPlayer(long steamId, bool isBot)
		{
			GameDescription.PlayerInfo pl = this.FindPlayer(steamId);
			if (pl != null)
			{
				return pl;
			}
			pl = new GameDescription.PlayerInfo(steamId, isBot);
			this.Players.Add(pl);
			return pl;
		}

		// Token: 0x170002F6 RID: 758
		// (get) Token: 0x06000FE6 RID: 4070 RVA: 0x0001CDBB File Offset: 0x0001AFBB
		// (set) Token: 0x06000FE7 RID: 4071 RVA: 0x0001CDC3 File Offset: 0x0001AFC3
		public Dictionary<string, int> Assemblies { get; set; } = new Dictionary<string, int>();

		// Token: 0x06000FE8 RID: 4072 RVA: 0x0001CDCC File Offset: 0x0001AFCC
		public void AddAssembly(string name, int hash)
		{
			this.Assemblies[name] = hash;
		}

		// Token: 0x020003D3 RID: 979
		[NullableContext(2)]
		[Nullable(0)]
		internal class LogEntry
		{
			// Token: 0x060016F1 RID: 5873 RVA: 0x0003531F File Offset: 0x0003351F
			[NullableContext(1)]
			public LogEntry(string message)
			{
				this.Time = DateTime.UtcNow;
				this.Message = message;
			}

			// Token: 0x17000460 RID: 1120
			// (get) Token: 0x060016F2 RID: 5874 RVA: 0x0003533E File Offset: 0x0003353E
			// (set) Token: 0x060016F3 RID: 5875 RVA: 0x00035346 File Offset: 0x00033546
			public DateTimeOffset Time { get; set; }

			// Token: 0x17000461 RID: 1121
			// (get) Token: 0x060016F4 RID: 5876 RVA: 0x0003534F File Offset: 0x0003354F
			// (set) Token: 0x060016F5 RID: 5877 RVA: 0x00035357 File Offset: 0x00033557
			public string UserId { get; set; }

			// Token: 0x17000462 RID: 1122
			// (get) Token: 0x060016F6 RID: 5878 RVA: 0x00035360 File Offset: 0x00033560
			// (set) Token: 0x060016F7 RID: 5879 RVA: 0x00035368 File Offset: 0x00033568
			public string VictimId { get; set; }

			// Token: 0x17000463 RID: 1123
			// (get) Token: 0x060016F8 RID: 5880 RVA: 0x00035371 File Offset: 0x00033571
			// (set) Token: 0x060016F9 RID: 5881 RVA: 0x00035379 File Offset: 0x00033579
			[Nullable(1)]
			public string Message
			{
				[NullableContext(1)]
				get;
				[NullableContext(1)]
				set;
			}

			// Token: 0x17000464 RID: 1124
			// (get) Token: 0x060016FA RID: 5882 RVA: 0x00035382 File Offset: 0x00033582
			// (set) Token: 0x060016FB RID: 5883 RVA: 0x0003538A File Offset: 0x0003358A
			public int? Score { get; set; }
		}

		// Token: 0x020003D4 RID: 980
		[NullableContext(0)]
		internal class PlayerInfo
		{
			// Token: 0x060016FC RID: 5884 RVA: 0x00035393 File Offset: 0x00033593
			public PlayerInfo(long userid, bool isBot)
			{
				this.UserId = userid;
				this.Bot = isBot;
				this.FirstSeen = DateTime.UtcNow;
			}

			// Token: 0x17000465 RID: 1125
			// (get) Token: 0x060016FD RID: 5885 RVA: 0x000353B9 File Offset: 0x000335B9
			// (set) Token: 0x060016FE RID: 5886 RVA: 0x000353C1 File Offset: 0x000335C1
			public long UserId { get; set; }

			// Token: 0x17000466 RID: 1126
			// (get) Token: 0x060016FF RID: 5887 RVA: 0x000353CA File Offset: 0x000335CA
			// (set) Token: 0x06001700 RID: 5888 RVA: 0x000353D2 File Offset: 0x000335D2
			public bool Bot { get; set; }

			// Token: 0x17000467 RID: 1127
			// (get) Token: 0x06001701 RID: 5889 RVA: 0x000353DB File Offset: 0x000335DB
			// (set) Token: 0x06001702 RID: 5890 RVA: 0x000353E3 File Offset: 0x000335E3
			public bool FromStart { get; set; }

			// Token: 0x17000468 RID: 1128
			// (get) Token: 0x06001703 RID: 5891 RVA: 0x000353EC File Offset: 0x000335EC
			// (set) Token: 0x06001704 RID: 5892 RVA: 0x000353F4 File Offset: 0x000335F4
			public bool Disconnect { get; set; }

			// Token: 0x17000469 RID: 1129
			// (get) Token: 0x06001705 RID: 5893 RVA: 0x000353FD File Offset: 0x000335FD
			// (set) Token: 0x06001706 RID: 5894 RVA: 0x00035405 File Offset: 0x00033605
			public GameplayResult Result { get; set; }

			// Token: 0x1700046A RID: 1130
			// (get) Token: 0x06001707 RID: 5895 RVA: 0x0003540E File Offset: 0x0003360E
			// (set) Token: 0x06001708 RID: 5896 RVA: 0x00035416 File Offset: 0x00033616
			public float Score { get; set; }

			// Token: 0x1700046B RID: 1131
			// (get) Token: 0x06001709 RID: 5897 RVA: 0x0003541F File Offset: 0x0003361F
			// (set) Token: 0x0600170A RID: 5898 RVA: 0x00035427 File Offset: 0x00033627
			public DateTimeOffset FirstSeen { get; set; }

			// Token: 0x1700046C RID: 1132
			// (get) Token: 0x0600170B RID: 5899 RVA: 0x00035430 File Offset: 0x00033630
			// (set) Token: 0x0600170C RID: 5900 RVA: 0x00035438 File Offset: 0x00033638
			public DateTimeOffset LastSeen { get; set; }
		}
	}
}
