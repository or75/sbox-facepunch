using System;

namespace Steamworks.Data
{
	// Token: 0x0200019C RID: 412
	internal static class Defines
	{
		// Token: 0x04000C81 RID: 3201
		internal static readonly AppId k_uAppIdInvalid = 0;

		// Token: 0x04000C82 RID: 3202
		internal static readonly DepotId_t k_uDepotIdInvalid = 0U;

		// Token: 0x04000C83 RID: 3203
		internal static readonly SteamAPICall_t k_uAPICallInvalid = 0UL;

		// Token: 0x04000C84 RID: 3204
		internal static readonly PartyBeaconID_t k_ulPartyBeaconIdInvalid = 0UL;

		// Token: 0x04000C85 RID: 3205
		internal static readonly HAuthTicket k_HAuthTicketInvalid = 0U;

		// Token: 0x04000C86 RID: 3206
		internal static readonly uint k_unSteamAccountIDMask = uint.MaxValue;

		// Token: 0x04000C87 RID: 3207
		internal static readonly uint k_unSteamAccountInstanceMask = 1048575U;

		// Token: 0x04000C88 RID: 3208
		internal static readonly uint k_unSteamUserDefaultInstance = 1U;

		// Token: 0x04000C89 RID: 3209
		internal static readonly int k_cchGameExtraInfoMax = 64;

		// Token: 0x04000C8A RID: 3210
		internal static readonly int k_cchMaxFriendsGroupName = 64;

		// Token: 0x04000C8B RID: 3211
		internal static readonly int k_cFriendsGroupLimit = 100;

		// Token: 0x04000C8C RID: 3212
		internal static readonly FriendsGroupID_t k_FriendsGroupID_Invalid = -1;

		// Token: 0x04000C8D RID: 3213
		internal static readonly int k_cEnumerateFollowersMax = 50;

		// Token: 0x04000C8E RID: 3214
		internal static readonly uint k_cubChatMetadataMax = 8192U;

		// Token: 0x04000C8F RID: 3215
		internal static readonly int k_cbMaxGameServerGameDir = 32;

		// Token: 0x04000C90 RID: 3216
		internal static readonly int k_cbMaxGameServerMapName = 32;

		// Token: 0x04000C91 RID: 3217
		internal static readonly int k_cbMaxGameServerGameDescription = 64;

		// Token: 0x04000C92 RID: 3218
		internal static readonly int k_cbMaxGameServerName = 64;

		// Token: 0x04000C93 RID: 3219
		internal static readonly int k_cbMaxGameServerTags = 128;

		// Token: 0x04000C94 RID: 3220
		internal static readonly int k_cbMaxGameServerGameData = 2048;

		// Token: 0x04000C95 RID: 3221
		internal static readonly int HSERVERQUERY_INVALID = -1;

		// Token: 0x04000C96 RID: 3222
		internal static readonly uint k_unFavoriteFlagNone = 0U;

		// Token: 0x04000C97 RID: 3223
		internal static readonly uint k_unFavoriteFlagFavorite = 1U;

		// Token: 0x04000C98 RID: 3224
		internal static readonly uint k_unFavoriteFlagHistory = 2U;

		// Token: 0x04000C99 RID: 3225
		internal static readonly uint k_unMaxCloudFileChunkSize = 104857600U;

		// Token: 0x04000C9A RID: 3226
		internal static readonly PublishedFileId k_PublishedFileIdInvalid = 0UL;

		// Token: 0x04000C9B RID: 3227
		internal static readonly UGCHandle_t k_UGCHandleInvalid = ulong.MaxValue;

		// Token: 0x04000C9C RID: 3228
		internal static readonly PublishedFileUpdateHandle_t k_PublishedFileUpdateHandleInvalid = ulong.MaxValue;

		// Token: 0x04000C9D RID: 3229
		internal static readonly UGCFileWriteStreamHandle_t k_UGCFileStreamHandleInvalid = ulong.MaxValue;

		// Token: 0x04000C9E RID: 3230
		internal static readonly uint k_cchPublishedDocumentTitleMax = 129U;

		// Token: 0x04000C9F RID: 3231
		internal static readonly uint k_cchPublishedDocumentDescriptionMax = 8000U;

		// Token: 0x04000CA0 RID: 3232
		internal static readonly uint k_cchPublishedDocumentChangeDescriptionMax = 8000U;

		// Token: 0x04000CA1 RID: 3233
		internal static readonly uint k_unEnumeratePublishedFilesMaxResults = 50U;

		// Token: 0x04000CA2 RID: 3234
		internal static readonly uint k_cchTagListMax = 1025U;

		// Token: 0x04000CA3 RID: 3235
		internal static readonly uint k_cchFilenameMax = 260U;

		// Token: 0x04000CA4 RID: 3236
		internal static readonly uint k_cchPublishedFileURLMax = 256U;

		// Token: 0x04000CA5 RID: 3237
		internal static readonly int k_cubAppProofOfPurchaseKeyMax = 240;

		// Token: 0x04000CA6 RID: 3238
		internal static readonly uint k_nScreenshotMaxTaggedUsers = 32U;

		// Token: 0x04000CA7 RID: 3239
		internal static readonly uint k_nScreenshotMaxTaggedPublishedFiles = 32U;

		// Token: 0x04000CA8 RID: 3240
		internal static readonly int k_cubUFSTagTypeMax = 255;

		// Token: 0x04000CA9 RID: 3241
		internal static readonly int k_cubUFSTagValueMax = 255;

		// Token: 0x04000CAA RID: 3242
		internal static readonly int k_ScreenshotThumbWidth = 200;

		// Token: 0x04000CAB RID: 3243
		internal static readonly UGCQueryHandle_t k_UGCQueryHandleInvalid = ulong.MaxValue;

		// Token: 0x04000CAC RID: 3244
		internal static readonly UGCUpdateHandle_t k_UGCUpdateHandleInvalid = ulong.MaxValue;

		// Token: 0x04000CAD RID: 3245
		internal static readonly uint kNumUGCResultsPerPage = 50U;

		// Token: 0x04000CAE RID: 3246
		internal static readonly uint k_cchDeveloperMetadataMax = 5000U;

		// Token: 0x04000CAF RID: 3247
		internal static readonly uint INVALID_HTMLBROWSER = 0U;

		// Token: 0x04000CB0 RID: 3248
		internal static readonly InventoryItemId k_SteamItemInstanceIDInvalid = ulong.MaxValue;

		// Token: 0x04000CB1 RID: 3249
		internal static readonly SteamInventoryResult_t k_SteamInventoryResultInvalid = -1;

		// Token: 0x04000CB2 RID: 3250
		internal static readonly SteamInventoryUpdateHandle_t k_SteamInventoryUpdateHandleInvalid = ulong.MaxValue;

		// Token: 0x04000CB3 RID: 3251
		internal static readonly HSteamNetPollGroup k_HSteamNetPollGroup_Invalid = 0U;

		// Token: 0x04000CB4 RID: 3252
		internal static readonly int k_cchMaxSteamNetworkingErrMsg = 1024;

		// Token: 0x04000CB5 RID: 3253
		internal static readonly int k_cchSteamNetworkingMaxConnectionCloseReason = 128;

		// Token: 0x04000CB6 RID: 3254
		internal static readonly int k_cchSteamNetworkingMaxConnectionDescription = 128;

		// Token: 0x04000CB7 RID: 3255
		internal static readonly int k_cchSteamNetworkingMaxConnectionAppName = 32;

		// Token: 0x04000CB8 RID: 3256
		internal static readonly int k_nSteamNetworkConnectionInfoFlags_Unauthenticated = 1;

		// Token: 0x04000CB9 RID: 3257
		internal static readonly int k_nSteamNetworkConnectionInfoFlags_Unencrypted = 2;

		// Token: 0x04000CBA RID: 3258
		internal static readonly int k_nSteamNetworkConnectionInfoFlags_LoopbackBuffers = 4;

		// Token: 0x04000CBB RID: 3259
		internal static readonly int k_nSteamNetworkConnectionInfoFlags_Fast = 8;

		// Token: 0x04000CBC RID: 3260
		internal static readonly int k_nSteamNetworkConnectionInfoFlags_Relayed = 16;

		// Token: 0x04000CBD RID: 3261
		internal static readonly int k_nSteamNetworkConnectionInfoFlags_DualWifi = 32;

		// Token: 0x04000CBE RID: 3262
		internal static readonly int k_cbMaxSteamNetworkingSocketsMessageSizeSend = 524288;

		// Token: 0x04000CBF RID: 3263
		internal static readonly int k_nSteamNetworkingSend_Unreliable = 0;

		// Token: 0x04000CC0 RID: 3264
		internal static readonly int k_nSteamNetworkingSend_NoNagle = 1;

		// Token: 0x04000CC1 RID: 3265
		internal static readonly int k_nSteamNetworkingSend_UnreliableNoNagle = Defines.k_nSteamNetworkingSend_Unreliable | Defines.k_nSteamNetworkingSend_NoNagle;

		// Token: 0x04000CC2 RID: 3266
		internal static readonly int k_nSteamNetworkingSend_NoDelay = 4;

		// Token: 0x04000CC3 RID: 3267
		internal static readonly int k_nSteamNetworkingSend_UnreliableNoDelay = Defines.k_nSteamNetworkingSend_Unreliable | Defines.k_nSteamNetworkingSend_NoDelay | Defines.k_nSteamNetworkingSend_NoNagle;

		// Token: 0x04000CC4 RID: 3268
		internal static readonly int k_nSteamNetworkingSend_Reliable = 8;

		// Token: 0x04000CC5 RID: 3269
		internal static readonly int k_nSteamNetworkingSend_ReliableNoNagle = Defines.k_nSteamNetworkingSend_Reliable | Defines.k_nSteamNetworkingSend_NoNagle;

		// Token: 0x04000CC6 RID: 3270
		internal static readonly int k_nSteamNetworkingSend_UseCurrentThread = 16;

		// Token: 0x04000CC7 RID: 3271
		internal static readonly int k_nSteamNetworkingSend_AutoRestartBrokenSession = 32;

		// Token: 0x04000CC8 RID: 3272
		internal static readonly int k_cchMaxSteamNetworkingPingLocationString = 1024;

		// Token: 0x04000CC9 RID: 3273
		internal static readonly int k_nSteamNetworkingPing_Failed = -1;

		// Token: 0x04000CCA RID: 3274
		internal static readonly int k_nSteamNetworkingPing_Unknown = -2;

		// Token: 0x04000CCB RID: 3275
		internal static readonly int k_nSteamNetworkingConfig_P2P_Transport_ICE_Enable_Default = -1;

		// Token: 0x04000CCC RID: 3276
		internal static readonly int k_nSteamNetworkingConfig_P2P_Transport_ICE_Enable_Disable = 0;

		// Token: 0x04000CCD RID: 3277
		internal static readonly int k_nSteamNetworkingConfig_P2P_Transport_ICE_Enable_Relay = 1;

		// Token: 0x04000CCE RID: 3278
		internal static readonly int k_nSteamNetworkingConfig_P2P_Transport_ICE_Enable_Private = 2;

		// Token: 0x04000CCF RID: 3279
		internal static readonly int k_nSteamNetworkingConfig_P2P_Transport_ICE_Enable_Public = 4;

		// Token: 0x04000CD0 RID: 3280
		internal static readonly int k_nSteamNetworkingConfig_P2P_Transport_ICE_Enable_All = int.MaxValue;

		// Token: 0x04000CD1 RID: 3281
		internal static readonly SteamNetworkingPOPID k_SteamDatagramPOPID_dev = 6579574U;

		// Token: 0x04000CD2 RID: 3282
		internal static readonly ushort STEAMGAMESERVER_QUERY_PORT_SHARED = ushort.MaxValue;

		// Token: 0x04000CD3 RID: 3283
		internal static readonly ushort MASTERSERVERUPDATERPORT_USEGAMESOCKETSHARE = Defines.STEAMGAMESERVER_QUERY_PORT_SHARED;

		// Token: 0x04000CD4 RID: 3284
		internal static readonly uint k_cbSteamDatagramMaxSerializedTicket = 512U;

		// Token: 0x04000CD5 RID: 3285
		internal static readonly uint k_cbMaxSteamDatagramGameCoordinatorServerLoginAppData = 2048U;

		// Token: 0x04000CD6 RID: 3286
		internal static readonly uint k_cbMaxSteamDatagramGameCoordinatorServerLoginSerialized = 4096U;

		// Token: 0x04000CD7 RID: 3287
		internal static readonly int k_cbSteamNetworkingSocketsFakeUDPPortRecommendedMTU = 1200;

		// Token: 0x04000CD8 RID: 3288
		internal static readonly int k_cbSteamNetworkingSocketsFakeUDPPortMaxMessageSize = 4096;
	}
}
