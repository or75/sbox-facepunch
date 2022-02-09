using System;
using Sandbox.Internal;
using Steamworks;

namespace Sandbox
{
	/// <summary>
	/// This is the engine connection to the game entity. 
	/// You should derive your game from Sandbox.Game rather than this.
	/// </summary>
	// Token: 0x020000A5 RID: 165
	public abstract class GameBase : Entity
	{
		// Token: 0x060010E7 RID: 4327 RVA: 0x00048EE4 File Offset: 0x000470E4
		public GameBase()
		{
			GameBase.Current = this;
			base.Transmit = TransmitType.Always;
			if (Host.IsMenuOrClient)
			{
				SteamFriends.SetRichPresence("steam_display", "#StatusGame");
				SteamFriends.SetRichPresence("gametitle", base.ClassInfo.Title);
				SteamFriends.SetRichPresence("map", GlobalGameNamespace.Global.MapName);
				SteamFriends.SetRichPresence("gamename", base.ClassInfo.Name);
			}
		}

		// Token: 0x17000224 RID: 548
		// (get) Token: 0x060010E8 RID: 4328 RVA: 0x00048F5C File Offset: 0x0004715C
		// (set) Token: 0x060010E9 RID: 4329 RVA: 0x00048F63 File Offset: 0x00047163
		internal static GameBase Current { get; set; }

		/// <summary>
		/// Called when the server is going away
		/// </summary>
		// Token: 0x060010EA RID: 4330
		public abstract void Shutdown();

		/// <summary>
		/// Client has joined the server. Create their puppets.
		/// </summary>
		// Token: 0x060010EB RID: 4331
		public abstract void ClientJoined(Client cl);

		/// <summary>
		/// Client has disconnected from the server. Remove their entities etc.
		/// </summary>
		// Token: 0x060010EC RID: 4332
		public abstract void ClientDisconnect(Client cl, NetworkDisconnectionReason reason);

		/// <summary>
		/// Can we hear the player's voice. If not we won't send the data to this client.
		/// </summary>
		// Token: 0x060010ED RID: 4333
		public abstract bool CanHearPlayerVoice(Client source, Client dest);

		// Token: 0x060010EE RID: 4334
		public abstract void PostLevelLoaded();

		/// <summary>
		/// Update the camera setup
		/// </summary>
		// Token: 0x060010EF RID: 4335
		public abstract CameraSetup BuildCamera(CameraSetup camSetup);

		/// <summary>
		/// Someone is speaking via voice chat. This might be someone in your game, 
		/// or in your party, or in your lobby.
		/// </summary>
		// Token: 0x060010F0 RID: 4336
		public abstract void OnVoicePlayed(long playerId, float level);

		// Token: 0x060010F1 RID: 4337 RVA: 0x00048F6B File Offset: 0x0004716B
		[Obsolete("OnVoicePlayed no longer takes a ulong playerid, switch it to a long")]
		public virtual void OnVoicePlayed(ulong playerId, float level)
		{
		}
	}
}
