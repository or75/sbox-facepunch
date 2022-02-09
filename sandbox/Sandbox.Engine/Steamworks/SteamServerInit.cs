using System;
using System.Net;

namespace Steamworks
{
	/// <summary>
	/// Used to set up the server. 
	/// The variables in here are all required to be set, and can't be changed once the server is created.
	/// </summary>
	// Token: 0x020000B2 RID: 178
	internal struct SteamServerInit
	{
		// Token: 0x060006F9 RID: 1785 RVA: 0x0000B178 File Offset: 0x00009378
		internal SteamServerInit(string modDir, string gameDesc)
		{
			this.DedicatedServer = true;
			this.ModDir = modDir;
			this.GameDescription = gameDesc;
			this.GamePort = 27015;
			this.QueryPort = 27016;
			this.Secure = true;
			this.VersionString = "1.0.0.0";
			this.IpAddress = null;
			this.SteamPort = 0;
		}

		/// <summary>
		/// Set the Steam quert port 
		/// </summary>
		// Token: 0x060006FA RID: 1786 RVA: 0x0000B1D0 File Offset: 0x000093D0
		internal SteamServerInit WithRandomSteamPort()
		{
			this.SteamPort = (ushort)new Random().Next(10000, 60000);
			return this;
		}

		/// <summary>
		/// If you pass MASTERSERVERUPDATERPORT_USEGAMESOCKETSHARE into usQueryPort, then it causes the game server API to use 
		/// "GameSocketShare" mode, which means that the game is responsible for sending and receiving UDP packets for the master
		/// server updater.
		///
		/// More info about this here: https://partner.steamgames.com/doc/api/ISteamGameServer#HandleIncomingPacket
		/// </summary>
		// Token: 0x060006FB RID: 1787 RVA: 0x0000B1F3 File Offset: 0x000093F3
		internal SteamServerInit WithQueryShareGamePort()
		{
			this.QueryPort = ushort.MaxValue;
			return this;
		}

		// Token: 0x0400094F RID: 2383
		internal IPAddress IpAddress;

		// Token: 0x04000950 RID: 2384
		internal ushort SteamPort;

		// Token: 0x04000951 RID: 2385
		internal ushort GamePort;

		// Token: 0x04000952 RID: 2386
		internal ushort QueryPort;

		// Token: 0x04000953 RID: 2387
		internal bool Secure;

		/// <summary>
		/// The version string is usually in the form x.x.x.x, and is used by the master server to detect when the server is out of date.
		/// If you go into the dedicated server tab on steamworks you'll be able to server the latest version. If this version number is
		/// less than that latest version then your server won't show.
		/// </summary>
		// Token: 0x04000954 RID: 2388
		internal string VersionString;

		/// <summary>
		/// This should be the same directory game where gets installed into. Just the folder name, not the whole path. I.e. "Rust", "Garrysmod".
		/// </summary>
		// Token: 0x04000955 RID: 2389
		internal string ModDir;

		/// <summary>
		/// The game description. Setting this to the full name of your game is recommended.
		/// </summary>
		// Token: 0x04000956 RID: 2390
		internal string GameDescription;

		/// <summary>
		/// Is a dedicated server
		/// </summary>
		// Token: 0x04000957 RID: 2391
		internal bool DedicatedServer;
	}
}
