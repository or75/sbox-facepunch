using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000024 RID: 36
	internal class ISteamGameSearch : SteamInterface
	{
		// Token: 0x0600015D RID: 349 RVA: 0x00004659 File Offset: 0x00002859
		internal ISteamGameSearch(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x0600015E RID: 350
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamGameSearch_v001();

		// Token: 0x0600015F RID: 351 RVA: 0x00004668 File Offset: 0x00002868
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamGameSearch.SteamAPI_SteamGameSearch_v001();
		}

		// Token: 0x06000160 RID: 352
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_AddGameSearchParams")]
		private static extern GameSearchErrorCode_t _AddGameSearchParams(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKeyToFind, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValuesToFind);

		// Token: 0x06000161 RID: 353 RVA: 0x0000466F File Offset: 0x0000286F
		internal GameSearchErrorCode_t AddGameSearchParams([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKeyToFind, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValuesToFind)
		{
			return ISteamGameSearch._AddGameSearchParams(this.Self, pchKeyToFind, pchValuesToFind);
		}

		// Token: 0x06000162 RID: 354
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_SearchForGameWithLobby")]
		private static extern GameSearchErrorCode_t _SearchForGameWithLobby(IntPtr self, SteamId steamIDLobby, int nPlayerMin, int nPlayerMax);

		// Token: 0x06000163 RID: 355 RVA: 0x0000467E File Offset: 0x0000287E
		internal GameSearchErrorCode_t SearchForGameWithLobby(SteamId steamIDLobby, int nPlayerMin, int nPlayerMax)
		{
			return ISteamGameSearch._SearchForGameWithLobby(this.Self, steamIDLobby, nPlayerMin, nPlayerMax);
		}

		// Token: 0x06000164 RID: 356
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_SearchForGameSolo")]
		private static extern GameSearchErrorCode_t _SearchForGameSolo(IntPtr self, int nPlayerMin, int nPlayerMax);

		// Token: 0x06000165 RID: 357 RVA: 0x0000468E File Offset: 0x0000288E
		internal GameSearchErrorCode_t SearchForGameSolo(int nPlayerMin, int nPlayerMax)
		{
			return ISteamGameSearch._SearchForGameSolo(this.Self, nPlayerMin, nPlayerMax);
		}

		// Token: 0x06000166 RID: 358
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_AcceptGame")]
		private static extern GameSearchErrorCode_t _AcceptGame(IntPtr self);

		// Token: 0x06000167 RID: 359 RVA: 0x0000469D File Offset: 0x0000289D
		internal GameSearchErrorCode_t AcceptGame()
		{
			return ISteamGameSearch._AcceptGame(this.Self);
		}

		// Token: 0x06000168 RID: 360
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_DeclineGame")]
		private static extern GameSearchErrorCode_t _DeclineGame(IntPtr self);

		// Token: 0x06000169 RID: 361 RVA: 0x000046AA File Offset: 0x000028AA
		internal GameSearchErrorCode_t DeclineGame()
		{
			return ISteamGameSearch._DeclineGame(this.Self);
		}

		// Token: 0x0600016A RID: 362
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_RetrieveConnectionDetails")]
		private static extern GameSearchErrorCode_t _RetrieveConnectionDetails(IntPtr self, SteamId steamIDHost, IntPtr pchConnectionDetails, int cubConnectionDetails);

		// Token: 0x0600016B RID: 363 RVA: 0x000046B8 File Offset: 0x000028B8
		internal GameSearchErrorCode_t RetrieveConnectionDetails(SteamId steamIDHost, out string pchConnectionDetails)
		{
			Helpers.Memory mempchConnectionDetails = Helpers.TakeMemory();
			GameSearchErrorCode_t result;
			try
			{
				GameSearchErrorCode_t gameSearchErrorCode_t = ISteamGameSearch._RetrieveConnectionDetails(this.Self, steamIDHost, mempchConnectionDetails, 32768);
				pchConnectionDetails = Helpers.MemoryToString(mempchConnectionDetails);
				result = gameSearchErrorCode_t;
			}
			finally
			{
				((IDisposable)mempchConnectionDetails).Dispose();
			}
			return result;
		}

		// Token: 0x0600016C RID: 364
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_EndGameSearch")]
		private static extern GameSearchErrorCode_t _EndGameSearch(IntPtr self);

		// Token: 0x0600016D RID: 365 RVA: 0x00004714 File Offset: 0x00002914
		internal GameSearchErrorCode_t EndGameSearch()
		{
			return ISteamGameSearch._EndGameSearch(this.Self);
		}

		// Token: 0x0600016E RID: 366
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_SetGameHostParams")]
		private static extern GameSearchErrorCode_t _SetGameHostParams(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue);

		// Token: 0x0600016F RID: 367 RVA: 0x00004721 File Offset: 0x00002921
		internal GameSearchErrorCode_t SetGameHostParams([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchKey, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchValue)
		{
			return ISteamGameSearch._SetGameHostParams(this.Self, pchKey, pchValue);
		}

		// Token: 0x06000170 RID: 368
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_SetConnectionDetails")]
		private static extern GameSearchErrorCode_t _SetConnectionDetails(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchConnectionDetails, int cubConnectionDetails);

		// Token: 0x06000171 RID: 369 RVA: 0x00004730 File Offset: 0x00002930
		internal GameSearchErrorCode_t SetConnectionDetails([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchConnectionDetails, int cubConnectionDetails)
		{
			return ISteamGameSearch._SetConnectionDetails(this.Self, pchConnectionDetails, cubConnectionDetails);
		}

		// Token: 0x06000172 RID: 370
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_RequestPlayersForGame")]
		private static extern GameSearchErrorCode_t _RequestPlayersForGame(IntPtr self, int nPlayerMin, int nPlayerMax, int nMaxTeamSize);

		// Token: 0x06000173 RID: 371 RVA: 0x0000473F File Offset: 0x0000293F
		internal GameSearchErrorCode_t RequestPlayersForGame(int nPlayerMin, int nPlayerMax, int nMaxTeamSize)
		{
			return ISteamGameSearch._RequestPlayersForGame(this.Self, nPlayerMin, nPlayerMax, nMaxTeamSize);
		}

		// Token: 0x06000174 RID: 372
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_HostConfirmGameStart")]
		private static extern GameSearchErrorCode_t _HostConfirmGameStart(IntPtr self, ulong ullUniqueGameID);

		// Token: 0x06000175 RID: 373 RVA: 0x0000474F File Offset: 0x0000294F
		internal GameSearchErrorCode_t HostConfirmGameStart(ulong ullUniqueGameID)
		{
			return ISteamGameSearch._HostConfirmGameStart(this.Self, ullUniqueGameID);
		}

		// Token: 0x06000176 RID: 374
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_CancelRequestPlayersForGame")]
		private static extern GameSearchErrorCode_t _CancelRequestPlayersForGame(IntPtr self);

		// Token: 0x06000177 RID: 375 RVA: 0x0000475D File Offset: 0x0000295D
		internal GameSearchErrorCode_t CancelRequestPlayersForGame()
		{
			return ISteamGameSearch._CancelRequestPlayersForGame(this.Self);
		}

		// Token: 0x06000178 RID: 376
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_SubmitPlayerResult")]
		private static extern GameSearchErrorCode_t _SubmitPlayerResult(IntPtr self, ulong ullUniqueGameID, SteamId steamIDPlayer, PlayerResult_t EPlayerResult);

		// Token: 0x06000179 RID: 377 RVA: 0x0000476A File Offset: 0x0000296A
		internal GameSearchErrorCode_t SubmitPlayerResult(ulong ullUniqueGameID, SteamId steamIDPlayer, PlayerResult_t EPlayerResult)
		{
			return ISteamGameSearch._SubmitPlayerResult(this.Self, ullUniqueGameID, steamIDPlayer, EPlayerResult);
		}

		// Token: 0x0600017A RID: 378
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamGameSearch_EndGame")]
		private static extern GameSearchErrorCode_t _EndGame(IntPtr self, ulong ullUniqueGameID);

		// Token: 0x0600017B RID: 379 RVA: 0x0000477A File Offset: 0x0000297A
		internal GameSearchErrorCode_t EndGame(ulong ullUniqueGameID)
		{
			return ISteamGameSearch._EndGame(this.Self, ullUniqueGameID);
		}
	}
}
