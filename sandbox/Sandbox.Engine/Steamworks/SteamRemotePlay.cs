using System;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Functions that provide information about Steam Remote Play sessions, streaming your game content to another computer or to a Steam Link app or hardware.
	/// </summary>
	// Token: 0x020000A3 RID: 163
	internal class SteamRemotePlay : SteamClientClass<SteamRemotePlay>
	{
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060005F2 RID: 1522 RVA: 0x000087A3 File Offset: 0x000069A3
		internal static ISteamRemotePlay Internal
		{
			get
			{
				return SteamClientClass<SteamRemotePlay>.Interface as ISteamRemotePlay;
			}
		}

		// Token: 0x060005F3 RID: 1523 RVA: 0x000087AF File Offset: 0x000069AF
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamRemotePlay(server));
			this.InstallEvents(server);
		}

		// Token: 0x060005F4 RID: 1524 RVA: 0x000087C8 File Offset: 0x000069C8
		internal void InstallEvents(bool server)
		{
			Dispatch.Install<SteamRemotePlaySessionConnected_t>(delegate(SteamRemotePlaySessionConnected_t x)
			{
				Action<RemotePlaySession> onSessionConnected = SteamRemotePlay.OnSessionConnected;
				if (onSessionConnected == null)
				{
					return;
				}
				onSessionConnected(x.SessionID);
			}, server);
			Dispatch.Install<SteamRemotePlaySessionDisconnected_t>(delegate(SteamRemotePlaySessionDisconnected_t x)
			{
				Action<RemotePlaySession> onSessionDisconnected = SteamRemotePlay.OnSessionDisconnected;
				if (onSessionDisconnected == null)
				{
					return;
				}
				onSessionDisconnected(x.SessionID);
			}, server);
		}

		/// <summary>
		/// Called when a session is connected
		/// </summary>
		// Token: 0x1400001E RID: 30
		// (add) Token: 0x060005F5 RID: 1525 RVA: 0x00008820 File Offset: 0x00006A20
		// (remove) Token: 0x060005F6 RID: 1526 RVA: 0x00008854 File Offset: 0x00006A54
		internal static event Action<RemotePlaySession> OnSessionConnected;

		/// <summary>
		/// Called when a session becomes disconnected
		/// </summary>
		// Token: 0x1400001F RID: 31
		// (add) Token: 0x060005F7 RID: 1527 RVA: 0x00008888 File Offset: 0x00006A88
		// (remove) Token: 0x060005F8 RID: 1528 RVA: 0x000088BC File Offset: 0x00006ABC
		internal static event Action<RemotePlaySession> OnSessionDisconnected;

		/// <summary>
		/// Get the number of currently connected Steam Remote Play sessions
		/// </summary>
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060005F9 RID: 1529 RVA: 0x000088EF File Offset: 0x00006AEF
		internal static int SessionCount
		{
			get
			{
				return (int)SteamRemotePlay.Internal.GetSessionCount();
			}
		}

		/// <summary>
		/// Get the currently connected Steam Remote Play session ID at the specified index.
		/// IsValid will return false if it's out of bounds
		/// </summary>
		// Token: 0x060005FA RID: 1530 RVA: 0x000088FB File Offset: 0x00006AFB
		internal static RemotePlaySession GetSession(int index)
		{
			return SteamRemotePlay.Internal.GetSessionID(index).Value;
		}

		/// <summary>
		/// Invite a friend to Remote Play Together
		/// This returns false if the invite can't be sent
		/// </summary>
		// Token: 0x060005FB RID: 1531 RVA: 0x00008912 File Offset: 0x00006B12
		internal static bool SendInvite(SteamId steamid)
		{
			return SteamRemotePlay.Internal.BSendRemotePlayTogetherInvite(steamid);
		}
	}
}
