using System;
using Sandbox.UI;
using Steamworks;

namespace Sandbox
{
	// Token: 0x0200009D RID: 157
	public static class Local
	{
		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x0600101C RID: 4124 RVA: 0x000480DB File Offset: 0x000462DB
		// (set) Token: 0x0600101D RID: 4125 RVA: 0x000480E2 File Offset: 0x000462E2
		public static Client Client { get; internal set; }

		// Token: 0x170001D2 RID: 466
		// (get) Token: 0x0600101E RID: 4126 RVA: 0x000480EA File Offset: 0x000462EA
		public static Entity Pawn
		{
			get
			{
				Client client = Local.Client;
				if (client == null)
				{
					return null;
				}
				return client.Pawn;
			}
		}

		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x0600101F RID: 4127 RVA: 0x000480FC File Offset: 0x000462FC
		public static long PlayerId
		{
			get
			{
				return (long)SteamClient.SteamId.Value;
			}
		}

		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06001020 RID: 4128 RVA: 0x00048108 File Offset: 0x00046308
		public static string DisplayName
		{
			get
			{
				string result;
				if ((result = SteamClient.Name) == null)
				{
					Client client = Local.Client;
					result = ((client != null) ? client.Name : null) ?? "Unnammed";
				}
				return result;
			}
		}

		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06001021 RID: 4129 RVA: 0x0004812D File Offset: 0x0004632D
		// (set) Token: 0x06001022 RID: 4130 RVA: 0x00048134 File Offset: 0x00046334
		public static RootPanel Hud { get; set; }

		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x06001023 RID: 4131 RVA: 0x0004813C File Offset: 0x0004633C
		[Obsolete("Use PlayerId instead")]
		public static ulong SteamId
		{
			get
			{
				return SteamClient.SteamId;
			}
		}
	}
}
