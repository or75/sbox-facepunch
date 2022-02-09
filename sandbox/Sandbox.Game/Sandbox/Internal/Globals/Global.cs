using System;
using System.Reflection;
using NativeEngine;
using Sandbox.Engine;
using Steamworks;

namespace Sandbox.Internal.Globals
{
	// Token: 0x0200018F RID: 399
	public class Global
	{
		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x06001C82 RID: 7298 RVA: 0x00071DD8 File Offset: 0x0006FFD8
		public ulong AppId
		{
			get
			{
				return 590830UL;
			}
		}

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06001C83 RID: 7299 RVA: 0x00071DE0 File Offset: 0x0006FFE0
		internal Assembly Assembly { get; } = typeof(Global).Assembly;

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x06001C84 RID: 7300 RVA: 0x00071DE8 File Offset: 0x0006FFE8
		// (set) Token: 0x06001C85 RID: 7301 RVA: 0x00071DF0 File Offset: 0x0006FFF0
		internal ContextInterface GameInterface { get; set; }

		/// <summary>
		/// Return true if we're in a game (ie, not in the main menu)
		/// </summary>
		// Token: 0x17000520 RID: 1312
		// (get) Token: 0x06001C86 RID: 7302 RVA: 0x00071DF9 File Offset: 0x0006FFF9
		// (set) Token: 0x06001C87 RID: 7303 RVA: 0x00071E01 File Offset: 0x00070001
		public bool InGame { get; internal set; }

		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06001C88 RID: 7304 RVA: 0x00071E0A File Offset: 0x0007000A
		// (set) Token: 0x06001C89 RID: 7305 RVA: 0x00071E12 File Offset: 0x00070012
		public string MapName { get; internal set; } = "";

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x06001C8A RID: 7306 RVA: 0x00071E1B File Offset: 0x0007001B
		// (set) Token: 0x06001C8B RID: 7307 RVA: 0x00071E23 File Offset: 0x00070023
		public string GameName { get; internal set; } = "";

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x06001C8C RID: 7308 RVA: 0x00071E2C File Offset: 0x0007002C
		// (set) Token: 0x06001C8D RID: 7309 RVA: 0x00071E34 File Offset: 0x00070034
		public bool IsDedicatedServer { get; internal set; }

		/// <summary>
		/// Returns true if the game is running with tools enabled
		/// </summary>
		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x06001C8E RID: 7310 RVA: 0x00071E3D File Offset: 0x0007003D
		public bool IsToolsMode
		{
			get
			{
				return Bootstrap.IsToolsMode;
			}
		}

		// Token: 0x17000525 RID: 1317
		// (get) Token: 0x06001C8F RID: 7311 RVA: 0x00071E44 File Offset: 0x00070044
		// (set) Token: 0x06001C90 RID: 7312 RVA: 0x00071E4C File Offset: 0x0007004C
		public bool IsListenServer { get; internal set; }

		// Token: 0x17000526 RID: 1318
		// (get) Token: 0x06001C91 RID: 7313 RVA: 0x00071E55 File Offset: 0x00070055
		// (set) Token: 0x06001C92 RID: 7314 RVA: 0x00071E5D File Offset: 0x0007005D
		public bool IsPlayingDemo { get; internal set; }

		/// <summary>
		/// Set to true when the game is closing
		/// </summary>
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x06001C93 RID: 7315 RVA: 0x00071E66 File Offset: 0x00070066
		// (set) Token: 0x06001C94 RID: 7316 RVA: 0x00071E6E File Offset: 0x0007006E
		public bool IsClosing { get; internal set; }

		/// <summary>
		/// Amount of ticks to perform per second. Higher is smoother and more accurate but uses more
		/// power. Lower can be laggy and weird things can happen. Default is 60. This should only be
		/// set serverside in your game's constructor or Spawn method. It should not be changed mid-game.
		/// </summary>
		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06001C95 RID: 7317 RVA: 0x00071E77 File Offset: 0x00070077
		// (set) Token: 0x06001C96 RID: 7318 RVA: 0x00071E7F File Offset: 0x0007007F
		public int TickRate
		{
			get
			{
				return this._tickrate;
			}
			set
			{
				if (Host.IsServer)
				{
					if (!this.IsStartup)
					{
						throw new Exception("Global.TickRate can only be changed during startup");
					}
					this._tickrate = value;
				}
			}
		}

		/// <summary>
		/// 1 / TickRate
		/// </summary>
		// Token: 0x17000529 RID: 1321
		// (get) Token: 0x06001C97 RID: 7319 RVA: 0x00071EA2 File Offset: 0x000700A2
		public float TickInterval
		{
			get
			{
				return 1f / (float)this.TickRate;
			}
		}

		/// <summary>
		/// If you're seeing objects go through other objects or you have a low tickrate, you might
		/// want to increase the number of physics substeps. This breaks physics steps down into this 
		/// many substeps. The default is 1 and works pretty good.
		/// Be aware that the number of physics ticks per second is going to be tickrate * substeps. So 
		/// if you're ticking at 90 and you have SubSteps set to 1000 then you're going to do 90,000 steps 
		/// per second. So be careful here.
		/// </summary>
		// Token: 0x1700052A RID: 1322
		// (get) Token: 0x06001C98 RID: 7320 RVA: 0x00071EB1 File Offset: 0x000700B1
		// (set) Token: 0x06001C99 RID: 7321 RVA: 0x00071EB9 File Offset: 0x000700B9
		public int PhysicsSubSteps { get; set; } = 1;

		/// <summary>
		/// How fast (or slow) the physics should run.
		/// </summary>
		// Token: 0x1700052B RID: 1323
		// (get) Token: 0x06001C9A RID: 7322 RVA: 0x00071EC2 File Offset: 0x000700C2
		// (set) Token: 0x06001C9B RID: 7323 RVA: 0x00071ECA File Offset: 0x000700CA
		public float PhysicsTimeScale { get; set; } = 1f;

		/// <summary>
		/// Scale the time, globally
		/// </summary>
		// Token: 0x1700052C RID: 1324
		// (get) Token: 0x06001C9C RID: 7324 RVA: 0x00071ED3 File Offset: 0x000700D3
		// (set) Token: 0x06001C9D RID: 7325 RVA: 0x00071EDB File Offset: 0x000700DB
		public float TimeScale { get; set; } = 1f;

		/// <summary>
		/// Return true if we're running in Vr. Will always be false serverside.
		/// </summary>
		// Token: 0x1700052D RID: 1325
		// (get) Token: 0x06001C9E RID: 7326 RVA: 0x00071EE4 File Offset: 0x000700E4
		// (set) Token: 0x06001C9F RID: 7327 RVA: 0x00071EEC File Offset: 0x000700EC
		public bool IsRunningInVR { get; internal set; }

		/// <summary>
		/// Return true if we're running on a handheld device (the deck). Will always be false serverside.
		/// </summary>
		// Token: 0x1700052E RID: 1326
		// (get) Token: 0x06001CA0 RID: 7328 RVA: 0x00071EF5 File Offset: 0x000700F5
		// (set) Token: 0x06001CA1 RID: 7329 RVA: 0x00071EFD File Offset: 0x000700FD
		public bool IsRunningOnHandheld { get; internal set; }

		/// <summary>
		/// The server lobby. This is used for server configuration, persistence. It's possible
		/// to make a game that uses the lobby for communicating with other players.
		/// </summary>
		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x06001CA2 RID: 7330 RVA: 0x00071F06 File Offset: 0x00070106
		// (set) Token: 0x06001CA3 RID: 7331 RVA: 0x00071F0E File Offset: 0x0007010E
		public Lobby Lobby { get; internal set; }

		/// <summary>
		/// The manager of our hotload
		/// </summary>
		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x06001CA4 RID: 7332 RVA: 0x00071F17 File Offset: 0x00070117
		// (set) Token: 0x06001CA5 RID: 7333 RVA: 0x00071F1F File Offset: 0x0007011F
		internal HotloadManager HotloadManager { get; set; }

		/// <summary>
		/// Change the currently loaded level. This is serverside only.
		/// </summary>
		// Token: 0x06001CA6 RID: 7334 RVA: 0x00071F28 File Offset: 0x00070128
		public void ChangeLevel(string mapName)
		{
			Host.AssertServer("ChangeLevel");
			ServerEngine.ChangeLevel(mapName, "");
		}

		// Token: 0x06001CA7 RID: 7335 RVA: 0x00071F3F File Offset: 0x0007013F
		internal void Init()
		{
			if (Host.IsMenuOrClient)
			{
				this.IsRunningInVR = SteamUtils.IsSteamRunningInVR;
				this.IsRunningOnHandheld = SteamUtils.IsRunningOnSteamDeck;
			}
		}

		// Token: 0x040007B5 RID: 1973
		internal bool IsStartup;

		// Token: 0x040007BD RID: 1981
		internal int _tickrate = 60;
	}
}
