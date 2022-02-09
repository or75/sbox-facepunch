using System;

namespace Steamworks
{
	/// <summary>
	/// Functions for clients to access matchmaking services, favorites, and to operate on game lobbies
	/// </summary>
	// Token: 0x020000A1 RID: 161
	internal class SteamMatchmakingServers : SteamClientClass<SteamMatchmakingServers>
	{
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060005E3 RID: 1507 RVA: 0x00008669 File Offset: 0x00006869
		internal static ISteamMatchmakingServers Internal
		{
			get
			{
				return SteamClientClass<SteamMatchmakingServers>.Interface as ISteamMatchmakingServers;
			}
		}

		// Token: 0x060005E4 RID: 1508 RVA: 0x00008675 File Offset: 0x00006875
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamMatchmakingServers(server));
		}
	}
}
