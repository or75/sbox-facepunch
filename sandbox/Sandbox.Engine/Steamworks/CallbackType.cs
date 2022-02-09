using System;

namespace Steamworks
{
	// Token: 0x0200001E RID: 30
	internal enum CallbackType
	{
		// Token: 0x04000120 RID: 288
		SteamServersConnected = 101,
		// Token: 0x04000121 RID: 289
		SteamServerConnectFailure,
		// Token: 0x04000122 RID: 290
		SteamServersDisconnected,
		// Token: 0x04000123 RID: 291
		ClientGameServerDeny = 113,
		// Token: 0x04000124 RID: 292
		GSPolicyResponse = 115,
		// Token: 0x04000125 RID: 293
		IPCFailure = 117,
		// Token: 0x04000126 RID: 294
		LicensesUpdated = 125,
		// Token: 0x04000127 RID: 295
		ValidateAuthTicketResponse = 143,
		// Token: 0x04000128 RID: 296
		MicroTxnAuthorizationResponse = 152,
		// Token: 0x04000129 RID: 297
		EncryptedAppTicketResponse = 154,
		// Token: 0x0400012A RID: 298
		GetAuthSessionTicketResponse = 163,
		// Token: 0x0400012B RID: 299
		GameWebCallback,
		// Token: 0x0400012C RID: 300
		StoreAuthURLResponse,
		// Token: 0x0400012D RID: 301
		MarketEligibilityResponse,
		// Token: 0x0400012E RID: 302
		DurationControl,
		// Token: 0x0400012F RID: 303
		GSClientApprove = 201,
		// Token: 0x04000130 RID: 304
		GSClientDeny,
		// Token: 0x04000131 RID: 305
		GSClientKick,
		// Token: 0x04000132 RID: 306
		GSClientAchievementStatus = 206,
		// Token: 0x04000133 RID: 307
		GSGameplayStats,
		// Token: 0x04000134 RID: 308
		GSClientGroupStatus,
		// Token: 0x04000135 RID: 309
		GSReputation,
		// Token: 0x04000136 RID: 310
		AssociateWithClanResult,
		// Token: 0x04000137 RID: 311
		ComputeNewPlayerCompatibilityResult,
		// Token: 0x04000138 RID: 312
		PersonaStateChange = 304,
		// Token: 0x04000139 RID: 313
		GameOverlayActivated = 331,
		// Token: 0x0400013A RID: 314
		GameServerChangeRequested,
		// Token: 0x0400013B RID: 315
		GameLobbyJoinRequested,
		// Token: 0x0400013C RID: 316
		AvatarImageLoaded,
		// Token: 0x0400013D RID: 317
		ClanOfficerListResponse,
		// Token: 0x0400013E RID: 318
		FriendRichPresenceUpdate,
		// Token: 0x0400013F RID: 319
		GameRichPresenceJoinRequested,
		// Token: 0x04000140 RID: 320
		GameConnectedClanChatMsg,
		// Token: 0x04000141 RID: 321
		GameConnectedChatJoin,
		// Token: 0x04000142 RID: 322
		GameConnectedChatLeave,
		// Token: 0x04000143 RID: 323
		DownloadClanActivityCountsResult,
		// Token: 0x04000144 RID: 324
		JoinClanChatRoomCompletionResult,
		// Token: 0x04000145 RID: 325
		GameConnectedFriendChatMsg,
		// Token: 0x04000146 RID: 326
		FriendsGetFollowerCount,
		// Token: 0x04000147 RID: 327
		FriendsIsFollowing,
		// Token: 0x04000148 RID: 328
		FriendsEnumerateFollowingList,
		// Token: 0x04000149 RID: 329
		SetPersonaNameResponse,
		// Token: 0x0400014A RID: 330
		UnreadChatMessagesChanged,
		// Token: 0x0400014B RID: 331
		OverlayBrowserProtocolNavigation,
		// Token: 0x0400014C RID: 332
		FavoritesListChanged = 502,
		// Token: 0x0400014D RID: 333
		LobbyInvite,
		// Token: 0x0400014E RID: 334
		LobbyEnter,
		// Token: 0x0400014F RID: 335
		LobbyDataUpdate,
		// Token: 0x04000150 RID: 336
		LobbyChatUpdate,
		// Token: 0x04000151 RID: 337
		LobbyChatMsg,
		// Token: 0x04000152 RID: 338
		LobbyGameCreated = 509,
		// Token: 0x04000153 RID: 339
		LobbyMatchList,
		// Token: 0x04000154 RID: 340
		LobbyKicked = 512,
		// Token: 0x04000155 RID: 341
		LobbyCreated,
		// Token: 0x04000156 RID: 342
		PSNGameBootInviteResult = 515,
		// Token: 0x04000157 RID: 343
		FavoritesListAccountsUpdated,
		// Token: 0x04000158 RID: 344
		IPCountry = 701,
		// Token: 0x04000159 RID: 345
		LowBatteryPower,
		// Token: 0x0400015A RID: 346
		SteamAPICallCompleted,
		// Token: 0x0400015B RID: 347
		SteamShutdown,
		// Token: 0x0400015C RID: 348
		CheckFileSignature,
		// Token: 0x0400015D RID: 349
		GamepadTextInputDismissed = 714,
		// Token: 0x0400015E RID: 350
		AppResumingFromSuspend = 736,
		// Token: 0x0400015F RID: 351
		FloatingGamepadTextInputDismissed = 738,
		// Token: 0x04000160 RID: 352
		DlcInstalled = 1005,
		// Token: 0x04000161 RID: 353
		RegisterActivationCodeResponse = 1008,
		// Token: 0x04000162 RID: 354
		NewUrlLaunchParameters = 1014,
		// Token: 0x04000163 RID: 355
		AppProofOfPurchaseKeyResponse = 1021,
		// Token: 0x04000164 RID: 356
		FileDetailsResult = 1023,
		// Token: 0x04000165 RID: 357
		TimedTrialStatus = 1030,
		// Token: 0x04000166 RID: 358
		UserStatsReceived = 1101,
		// Token: 0x04000167 RID: 359
		UserStatsStored,
		// Token: 0x04000168 RID: 360
		UserAchievementStored,
		// Token: 0x04000169 RID: 361
		LeaderboardFindResult,
		// Token: 0x0400016A RID: 362
		LeaderboardScoresDownloaded,
		// Token: 0x0400016B RID: 363
		LeaderboardScoreUploaded,
		// Token: 0x0400016C RID: 364
		NumberOfCurrentPlayers,
		// Token: 0x0400016D RID: 365
		UserStatsUnloaded,
		// Token: 0x0400016E RID: 366
		GSStatsUnloaded = 1108,
		// Token: 0x0400016F RID: 367
		UserAchievementIconFetched,
		// Token: 0x04000170 RID: 368
		GlobalAchievementPercentagesReady,
		// Token: 0x04000171 RID: 369
		LeaderboardUGCSet,
		// Token: 0x04000172 RID: 370
		GlobalStatsReceived,
		// Token: 0x04000173 RID: 371
		P2PSessionRequest = 1202,
		// Token: 0x04000174 RID: 372
		P2PSessionConnectFail,
		// Token: 0x04000175 RID: 373
		SteamNetConnectionStatusChangedCallback = 1221,
		// Token: 0x04000176 RID: 374
		SteamNetAuthenticationStatus,
		// Token: 0x04000177 RID: 375
		SteamNetworkingFakeIPResult,
		// Token: 0x04000178 RID: 376
		SteamNetworkingMessagesSessionRequest = 1251,
		// Token: 0x04000179 RID: 377
		SteamNetworkingMessagesSessionFailed,
		// Token: 0x0400017A RID: 378
		SteamRelayNetworkStatus = 1281,
		// Token: 0x0400017B RID: 379
		RemoteStorageFileShareResult = 1307,
		// Token: 0x0400017C RID: 380
		RemoteStoragePublishFileResult = 1309,
		// Token: 0x0400017D RID: 381
		RemoteStorageDeletePublishedFileResult = 1311,
		// Token: 0x0400017E RID: 382
		RemoteStorageEnumerateUserPublishedFilesResult,
		// Token: 0x0400017F RID: 383
		RemoteStorageSubscribePublishedFileResult,
		// Token: 0x04000180 RID: 384
		RemoteStorageEnumerateUserSubscribedFilesResult,
		// Token: 0x04000181 RID: 385
		RemoteStorageUnsubscribePublishedFileResult,
		// Token: 0x04000182 RID: 386
		RemoteStorageUpdatePublishedFileResult,
		// Token: 0x04000183 RID: 387
		RemoteStorageDownloadUGCResult,
		// Token: 0x04000184 RID: 388
		RemoteStorageGetPublishedFileDetailsResult,
		// Token: 0x04000185 RID: 389
		RemoteStorageEnumerateWorkshopFilesResult,
		// Token: 0x04000186 RID: 390
		RemoteStorageGetPublishedItemVoteDetailsResult,
		// Token: 0x04000187 RID: 391
		RemoteStoragePublishedFileSubscribed,
		// Token: 0x04000188 RID: 392
		RemoteStoragePublishedFileUnsubscribed,
		// Token: 0x04000189 RID: 393
		RemoteStoragePublishedFileDeleted,
		// Token: 0x0400018A RID: 394
		RemoteStorageUpdateUserPublishedItemVoteResult,
		// Token: 0x0400018B RID: 395
		RemoteStorageUserVoteDetails,
		// Token: 0x0400018C RID: 396
		RemoteStorageEnumerateUserSharedWorkshopFilesResult,
		// Token: 0x0400018D RID: 397
		RemoteStorageSetUserPublishedFileActionResult,
		// Token: 0x0400018E RID: 398
		RemoteStorageEnumeratePublishedFilesByUserActionResult,
		// Token: 0x0400018F RID: 399
		RemoteStoragePublishFileProgress,
		// Token: 0x04000190 RID: 400
		RemoteStoragePublishedFileUpdated,
		// Token: 0x04000191 RID: 401
		RemoteStorageFileWriteAsyncComplete,
		// Token: 0x04000192 RID: 402
		RemoteStorageFileReadAsyncComplete,
		// Token: 0x04000193 RID: 403
		RemoteStorageLocalFileChange,
		// Token: 0x04000194 RID: 404
		GSStatsReceived = 1800,
		// Token: 0x04000195 RID: 405
		GSStatsStored,
		// Token: 0x04000196 RID: 406
		HTTPRequestCompleted = 2101,
		// Token: 0x04000197 RID: 407
		HTTPRequestHeadersReceived,
		// Token: 0x04000198 RID: 408
		HTTPRequestDataReceived,
		// Token: 0x04000199 RID: 409
		ScreenshotReady = 2301,
		// Token: 0x0400019A RID: 410
		ScreenshotRequested,
		// Token: 0x0400019B RID: 411
		SteamInputDeviceConnected = 2801,
		// Token: 0x0400019C RID: 412
		SteamInputDeviceDisconnected,
		// Token: 0x0400019D RID: 413
		SteamInputConfigurationLoaded,
		// Token: 0x0400019E RID: 414
		SteamUGCQueryCompleted = 3401,
		// Token: 0x0400019F RID: 415
		SteamUGCRequestUGCDetailsResult,
		// Token: 0x040001A0 RID: 416
		CreateItemResult,
		// Token: 0x040001A1 RID: 417
		SubmitItemUpdateResult,
		// Token: 0x040001A2 RID: 418
		ItemInstalled,
		// Token: 0x040001A3 RID: 419
		DownloadItemResult,
		// Token: 0x040001A4 RID: 420
		UserFavoriteItemsListChanged,
		// Token: 0x040001A5 RID: 421
		SetUserItemVoteResult,
		// Token: 0x040001A6 RID: 422
		GetUserItemVoteResult,
		// Token: 0x040001A7 RID: 423
		StartPlaytimeTrackingResult,
		// Token: 0x040001A8 RID: 424
		StopPlaytimeTrackingResult,
		// Token: 0x040001A9 RID: 425
		AddUGCDependencyResult,
		// Token: 0x040001AA RID: 426
		RemoveUGCDependencyResult,
		// Token: 0x040001AB RID: 427
		AddAppDependencyResult,
		// Token: 0x040001AC RID: 428
		RemoveAppDependencyResult,
		// Token: 0x040001AD RID: 429
		GetAppDependenciesResult,
		// Token: 0x040001AE RID: 430
		DeleteItemResult,
		// Token: 0x040001AF RID: 431
		UserSubscribedItemsListChanged,
		// Token: 0x040001B0 RID: 432
		WorkshopEULAStatus = 3420,
		// Token: 0x040001B1 RID: 433
		SteamAppInstalled = 3901,
		// Token: 0x040001B2 RID: 434
		SteamAppUninstalled,
		// Token: 0x040001B3 RID: 435
		PlaybackStatusHasChanged = 4001,
		// Token: 0x040001B4 RID: 436
		VolumeHasChanged,
		// Token: 0x040001B5 RID: 437
		MusicPlayerWantsVolume = 4011,
		// Token: 0x040001B6 RID: 438
		MusicPlayerSelectsQueueEntry,
		// Token: 0x040001B7 RID: 439
		MusicPlayerSelectsPlaylistEntry,
		// Token: 0x040001B8 RID: 440
		MusicPlayerRemoteWillActivate = 4101,
		// Token: 0x040001B9 RID: 441
		MusicPlayerRemoteWillDeactivate,
		// Token: 0x040001BA RID: 442
		MusicPlayerRemoteToFront,
		// Token: 0x040001BB RID: 443
		MusicPlayerWillQuit,
		// Token: 0x040001BC RID: 444
		MusicPlayerWantsPlay,
		// Token: 0x040001BD RID: 445
		MusicPlayerWantsPause,
		// Token: 0x040001BE RID: 446
		MusicPlayerWantsPlayPrevious,
		// Token: 0x040001BF RID: 447
		MusicPlayerWantsPlayNext,
		// Token: 0x040001C0 RID: 448
		MusicPlayerWantsShuffled,
		// Token: 0x040001C1 RID: 449
		MusicPlayerWantsLooped,
		// Token: 0x040001C2 RID: 450
		MusicPlayerWantsPlayingRepeatStatus = 4114,
		// Token: 0x040001C3 RID: 451
		HTML_BrowserReady = 4501,
		// Token: 0x040001C4 RID: 452
		HTML_NeedsPaint,
		// Token: 0x040001C5 RID: 453
		HTML_StartRequest,
		// Token: 0x040001C6 RID: 454
		HTML_CloseBrowser,
		// Token: 0x040001C7 RID: 455
		HTML_URLChanged,
		// Token: 0x040001C8 RID: 456
		HTML_FinishedRequest,
		// Token: 0x040001C9 RID: 457
		HTML_OpenLinkInNewTab,
		// Token: 0x040001CA RID: 458
		HTML_ChangedTitle,
		// Token: 0x040001CB RID: 459
		HTML_SearchResults,
		// Token: 0x040001CC RID: 460
		HTML_CanGoBackAndForward,
		// Token: 0x040001CD RID: 461
		HTML_HorizontalScroll,
		// Token: 0x040001CE RID: 462
		HTML_VerticalScroll,
		// Token: 0x040001CF RID: 463
		HTML_LinkAtPosition,
		// Token: 0x040001D0 RID: 464
		HTML_JSAlert,
		// Token: 0x040001D1 RID: 465
		HTML_JSConfirm,
		// Token: 0x040001D2 RID: 466
		HTML_FileOpenDialog,
		// Token: 0x040001D3 RID: 467
		HTML_NewWindow = 4521,
		// Token: 0x040001D4 RID: 468
		HTML_SetCursor,
		// Token: 0x040001D5 RID: 469
		HTML_StatusText,
		// Token: 0x040001D6 RID: 470
		HTML_ShowToolTip,
		// Token: 0x040001D7 RID: 471
		HTML_UpdateToolTip,
		// Token: 0x040001D8 RID: 472
		HTML_HideToolTip,
		// Token: 0x040001D9 RID: 473
		HTML_BrowserRestarted,
		// Token: 0x040001DA RID: 474
		GetVideoURLResult = 4611,
		// Token: 0x040001DB RID: 475
		GetOPFSettingsResult = 4624,
		// Token: 0x040001DC RID: 476
		SteamInventoryResultReady = 4700,
		// Token: 0x040001DD RID: 477
		SteamInventoryFullUpdate,
		// Token: 0x040001DE RID: 478
		SteamInventoryDefinitionUpdate,
		// Token: 0x040001DF RID: 479
		SteamInventoryEligiblePromoItemDefIDs,
		// Token: 0x040001E0 RID: 480
		SteamInventoryStartPurchaseResult,
		// Token: 0x040001E1 RID: 481
		SteamInventoryRequestPricesResult,
		// Token: 0x040001E2 RID: 482
		SteamParentalSettingsChanged = 5001,
		// Token: 0x040001E3 RID: 483
		SearchForGameProgressCallback = 5201,
		// Token: 0x040001E4 RID: 484
		SearchForGameResultCallback,
		// Token: 0x040001E5 RID: 485
		RequestPlayersForGameProgressCallback = 5211,
		// Token: 0x040001E6 RID: 486
		RequestPlayersForGameResultCallback,
		// Token: 0x040001E7 RID: 487
		RequestPlayersForGameFinalResultCallback,
		// Token: 0x040001E8 RID: 488
		SubmitPlayerResultResultCallback,
		// Token: 0x040001E9 RID: 489
		EndGameResultCallback,
		// Token: 0x040001EA RID: 490
		JoinPartyCallback = 5301,
		// Token: 0x040001EB RID: 491
		CreateBeaconCallback,
		// Token: 0x040001EC RID: 492
		ReservationNotificationCallback,
		// Token: 0x040001ED RID: 493
		ChangeNumOpenSlotsCallback,
		// Token: 0x040001EE RID: 494
		AvailableBeaconLocationsUpdated,
		// Token: 0x040001EF RID: 495
		ActiveBeaconsUpdated,
		// Token: 0x040001F0 RID: 496
		SteamRemotePlaySessionConnected = 5701,
		// Token: 0x040001F1 RID: 497
		SteamRemotePlaySessionDisconnected
	}
}
