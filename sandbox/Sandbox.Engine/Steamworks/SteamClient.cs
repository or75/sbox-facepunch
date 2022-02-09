using System;
using System.Collections.Generic;

namespace Steamworks
{
	// Token: 0x0200009C RID: 156
	internal static class SteamClient
	{
		/// <summary>
		/// Initialize the steam client.
		/// If asyncCallbacks is false you need to call RunCallbacks manually every frame.
		/// </summary>
		// Token: 0x06000551 RID: 1361 RVA: 0x00006BC4 File Offset: 0x00004DC4
		internal static void Init(int appid)
		{
			if (SteamClient.initialized)
			{
				throw new Exception("Calling SteamClient.Init but is already initialized");
			}
			SteamClient.AppId = appid;
			SteamClient.initialized = true;
			SteamClient.AddInterface<SteamApps>();
			SteamClient.AddInterface<SteamFriends>();
			SteamClient.AddInterface<SteamInput>();
			SteamClient.AddInterface<SteamInventory>();
			SteamClient.AddInterface<SteamMatchmaking>();
			SteamClient.AddInterface<SteamMatchmakingServers>();
			SteamClient.AddInterface<SteamParental>();
			SteamClient.AddInterface<SteamScreenshots>();
			SteamClient.AddInterface<SteamUser>();
			SteamClient.AddInterface<SteamUserStats>();
			SteamClient.AddInterface<SteamUtils>();
			SteamClient.AddInterface<SteamRemotePlay>();
			SteamClient.SteamId = SteamUser.Internal.GetSteamID();
			SteamClient.Name = SteamFriends.Internal.GetPersonaName();
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00006C50 File Offset: 0x00004E50
		internal static void AddInterface<T>() where T : SteamClass, new()
		{
			T t = new T();
			t.InitializeInterface(false);
			SteamClient.openInterfaces.Add(t);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00006C80 File Offset: 0x00004E80
		internal static void ShutdownInterfaces()
		{
			foreach (SteamClass steamClass in SteamClient.openInterfaces)
			{
				steamClass.DestroyInterface(false);
			}
			SteamClient.openInterfaces.Clear();
		}

		/// <summary>
		/// Check if Steam is loaded and accessible.
		/// </summary>		
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000554 RID: 1364 RVA: 0x00006CDC File Offset: 0x00004EDC
		internal static bool IsValid
		{
			get
			{
				return SteamClient.initialized;
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00006CE3 File Offset: 0x00004EE3
		internal static void Shutdown()
		{
			if (!SteamClient.IsValid)
			{
				return;
			}
			SteamClient.Cleanup();
			SteamAPI.Shutdown();
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00006CF7 File Offset: 0x00004EF7
		internal static void Cleanup()
		{
			Dispatch.ShutdownClient();
			SteamClient.initialized = false;
			SteamClient.ShutdownInterfaces();
		}

		/// <summary>
		/// Checks if the current user's Steam client is connected to the Steam servers.
		/// If it's not then no real-time services provided by the Steamworks API will be enabled. The Steam 
		/// client will automatically be trying to recreate the connection as often as possible. When the 
		/// connection is restored a SteamServersConnected_t callback will be posted.
		/// You usually don't need to check for this yourself. All of the API calls that rely on this will 
		/// check internally. Forcefully disabling stuff when the player loses access is usually not a 
		/// very good experience for the player and you could be preventing them from accessing APIs that do not 
		/// need a live connection to Steam.
		/// </summary>
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x00006D09 File Offset: 0x00004F09
		internal static bool IsLoggedOn
		{
			get
			{
				return SteamUser.Internal.BLoggedOn();
			}
		}

		/// <summary>
		/// gets the status of the current user
		/// </summary>
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000558 RID: 1368 RVA: 0x00006D15 File Offset: 0x00004F15
		internal static FriendState State
		{
			get
			{
				return SteamFriends.Internal.GetPersonaState();
			}
		}

		/// <summary>
		/// Checks if your executable was launched through Steam and relaunches it through Steam if it wasn't
		///  this returns true then it starts the Steam client if required and launches your game again through it, 
		///  and you should quit your process as soon as possible. This effectively runs steam://run/AppId so it 
		///  may not relaunch the exact executable that called it, as it will always relaunch from the version 
		///  installed in your Steam library folder/
		///  Note that during development, when not launching via Steam, this might always return true.
		/// </summary>
		// Token: 0x06000559 RID: 1369 RVA: 0x00006D21 File Offset: 0x00004F21
		internal static bool RestartAppIfNecessary(uint appid)
		{
			return SteamAPI.RestartAppIfNecessary(appid);
		}

		/// <summary>
		/// Called in interfaces that rely on this being initialized
		/// </summary>
		// Token: 0x0600055A RID: 1370 RVA: 0x00006D29 File Offset: 0x00004F29
		internal static void ValidCheck()
		{
			if (!SteamClient.IsValid)
			{
				throw new Exception("SteamClient isn't initialized");
			}
		}

		// Token: 0x040008E9 RID: 2281
		private static bool initialized;

		// Token: 0x040008EA RID: 2282
		private static readonly List<SteamClass> openInterfaces = new List<SteamClass>();

		/// <summary>
		/// Gets the Steam ID of the account currently logged into the Steam client. This is 
		/// commonly called the 'current user', or 'local user'.
		/// A Steam ID is a unique identifier for a Steam accounts, Steam groups, Lobbies and Chat 
		/// rooms, and used to differentiate users in all parts of the Steamworks API.
		/// </summary>
		// Token: 0x040008EB RID: 2283
		internal static SteamId SteamId;

		/// <summary>
		/// returns the local players name - guaranteed to not be NULL.
		/// this is the same name as on the users community profile page
		/// </summary>
		// Token: 0x040008EC RID: 2284
		internal static string Name;

		/// <summary>
		/// returns the appID of the current process
		/// </summary>
		// Token: 0x040008ED RID: 2285
		internal static AppId AppId;
	}
}
