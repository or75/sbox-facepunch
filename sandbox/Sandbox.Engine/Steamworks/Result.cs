using System;

namespace Steamworks
{
	// Token: 0x0200003C RID: 60
	internal enum Result
	{
		// Token: 0x040001FE RID: 510
		None,
		// Token: 0x040001FF RID: 511
		OK,
		// Token: 0x04000200 RID: 512
		Fail,
		// Token: 0x04000201 RID: 513
		NoConnection,
		// Token: 0x04000202 RID: 514
		InvalidPassword = 5,
		// Token: 0x04000203 RID: 515
		LoggedInElsewhere,
		// Token: 0x04000204 RID: 516
		InvalidProtocolVer,
		// Token: 0x04000205 RID: 517
		InvalidParam,
		// Token: 0x04000206 RID: 518
		FileNotFound,
		// Token: 0x04000207 RID: 519
		Busy,
		// Token: 0x04000208 RID: 520
		InvalidState,
		// Token: 0x04000209 RID: 521
		InvalidName,
		// Token: 0x0400020A RID: 522
		InvalidEmail,
		// Token: 0x0400020B RID: 523
		DuplicateName,
		// Token: 0x0400020C RID: 524
		AccessDenied,
		// Token: 0x0400020D RID: 525
		Timeout,
		// Token: 0x0400020E RID: 526
		Banned,
		// Token: 0x0400020F RID: 527
		AccountNotFound,
		// Token: 0x04000210 RID: 528
		InvalidSteamID,
		// Token: 0x04000211 RID: 529
		ServiceUnavailable,
		// Token: 0x04000212 RID: 530
		NotLoggedOn,
		// Token: 0x04000213 RID: 531
		Pending,
		// Token: 0x04000214 RID: 532
		EncryptionFailure,
		// Token: 0x04000215 RID: 533
		InsufficientPrivilege,
		// Token: 0x04000216 RID: 534
		LimitExceeded,
		// Token: 0x04000217 RID: 535
		Revoked,
		// Token: 0x04000218 RID: 536
		Expired,
		// Token: 0x04000219 RID: 537
		AlreadyRedeemed,
		// Token: 0x0400021A RID: 538
		DuplicateRequest,
		// Token: 0x0400021B RID: 539
		AlreadyOwned,
		// Token: 0x0400021C RID: 540
		IPNotFound,
		// Token: 0x0400021D RID: 541
		PersistFailed,
		// Token: 0x0400021E RID: 542
		LockingFailed,
		// Token: 0x0400021F RID: 543
		LogonSessionReplaced,
		// Token: 0x04000220 RID: 544
		ConnectFailed,
		// Token: 0x04000221 RID: 545
		HandshakeFailed,
		// Token: 0x04000222 RID: 546
		IOFailure,
		// Token: 0x04000223 RID: 547
		RemoteDisconnect,
		// Token: 0x04000224 RID: 548
		ShoppingCartNotFound,
		// Token: 0x04000225 RID: 549
		Blocked,
		// Token: 0x04000226 RID: 550
		Ignored,
		// Token: 0x04000227 RID: 551
		NoMatch,
		// Token: 0x04000228 RID: 552
		AccountDisabled,
		// Token: 0x04000229 RID: 553
		ServiceReadOnly,
		// Token: 0x0400022A RID: 554
		AccountNotFeatured,
		// Token: 0x0400022B RID: 555
		AdministratorOK,
		// Token: 0x0400022C RID: 556
		ContentVersion,
		// Token: 0x0400022D RID: 557
		TryAnotherCM,
		// Token: 0x0400022E RID: 558
		PasswordRequiredToKickSession,
		// Token: 0x0400022F RID: 559
		AlreadyLoggedInElsewhere,
		// Token: 0x04000230 RID: 560
		Suspended,
		// Token: 0x04000231 RID: 561
		Cancelled,
		// Token: 0x04000232 RID: 562
		DataCorruption,
		// Token: 0x04000233 RID: 563
		DiskFull,
		// Token: 0x04000234 RID: 564
		RemoteCallFailed,
		// Token: 0x04000235 RID: 565
		PasswordUnset,
		// Token: 0x04000236 RID: 566
		ExternalAccountUnlinked,
		// Token: 0x04000237 RID: 567
		PSNTicketInvalid,
		// Token: 0x04000238 RID: 568
		ExternalAccountAlreadyLinked,
		// Token: 0x04000239 RID: 569
		RemoteFileConflict,
		// Token: 0x0400023A RID: 570
		IllegalPassword,
		// Token: 0x0400023B RID: 571
		SameAsPreviousValue,
		// Token: 0x0400023C RID: 572
		AccountLogonDenied,
		// Token: 0x0400023D RID: 573
		CannotUseOldPassword,
		// Token: 0x0400023E RID: 574
		InvalidLoginAuthCode,
		// Token: 0x0400023F RID: 575
		AccountLogonDeniedNoMail,
		// Token: 0x04000240 RID: 576
		HardwareNotCapableOfIPT,
		// Token: 0x04000241 RID: 577
		IPTInitError,
		// Token: 0x04000242 RID: 578
		ParentalControlRestricted,
		// Token: 0x04000243 RID: 579
		FacebookQueryError,
		// Token: 0x04000244 RID: 580
		ExpiredLoginAuthCode,
		// Token: 0x04000245 RID: 581
		IPLoginRestrictionFailed,
		// Token: 0x04000246 RID: 582
		AccountLockedDown,
		// Token: 0x04000247 RID: 583
		AccountLogonDeniedVerifiedEmailRequired,
		// Token: 0x04000248 RID: 584
		NoMatchingURL,
		// Token: 0x04000249 RID: 585
		BadResponse,
		// Token: 0x0400024A RID: 586
		RequirePasswordReEntry,
		// Token: 0x0400024B RID: 587
		ValueOutOfRange,
		// Token: 0x0400024C RID: 588
		UnexpectedError,
		// Token: 0x0400024D RID: 589
		Disabled,
		// Token: 0x0400024E RID: 590
		InvalidCEGSubmission,
		// Token: 0x0400024F RID: 591
		RestrictedDevice,
		// Token: 0x04000250 RID: 592
		RegionLocked,
		// Token: 0x04000251 RID: 593
		RateLimitExceeded,
		// Token: 0x04000252 RID: 594
		AccountLoginDeniedNeedTwoFactor,
		// Token: 0x04000253 RID: 595
		ItemDeleted,
		// Token: 0x04000254 RID: 596
		AccountLoginDeniedThrottle,
		// Token: 0x04000255 RID: 597
		TwoFactorCodeMismatch,
		// Token: 0x04000256 RID: 598
		TwoFactorActivationCodeMismatch,
		// Token: 0x04000257 RID: 599
		AccountAssociatedToMultiplePartners,
		// Token: 0x04000258 RID: 600
		NotModified,
		// Token: 0x04000259 RID: 601
		NoMobileDevice,
		// Token: 0x0400025A RID: 602
		TimeNotSynced,
		// Token: 0x0400025B RID: 603
		SmsCodeFailed,
		// Token: 0x0400025C RID: 604
		AccountLimitExceeded,
		// Token: 0x0400025D RID: 605
		AccountActivityLimitExceeded,
		// Token: 0x0400025E RID: 606
		PhoneActivityLimitExceeded,
		// Token: 0x0400025F RID: 607
		RefundToWallet,
		// Token: 0x04000260 RID: 608
		EmailSendFailure,
		// Token: 0x04000261 RID: 609
		NotSettled,
		// Token: 0x04000262 RID: 610
		NeedCaptcha,
		// Token: 0x04000263 RID: 611
		GSLTDenied,
		// Token: 0x04000264 RID: 612
		GSOwnerDenied,
		// Token: 0x04000265 RID: 613
		InvalidItemType,
		// Token: 0x04000266 RID: 614
		IPBanned,
		// Token: 0x04000267 RID: 615
		GSLTExpired,
		// Token: 0x04000268 RID: 616
		InsufficientFunds,
		// Token: 0x04000269 RID: 617
		TooManyPending,
		// Token: 0x0400026A RID: 618
		NoSiteLicensesFound,
		// Token: 0x0400026B RID: 619
		WGNetworkSendExceeded,
		// Token: 0x0400026C RID: 620
		AccountNotFriends,
		// Token: 0x0400026D RID: 621
		LimitedUserAccount,
		// Token: 0x0400026E RID: 622
		CantRemoveItem,
		// Token: 0x0400026F RID: 623
		AccountDeleted,
		// Token: 0x04000270 RID: 624
		ExistingUserCancelledLicense,
		// Token: 0x04000271 RID: 625
		CommunityCooldown,
		// Token: 0x04000272 RID: 626
		NoLauncherSpecified,
		// Token: 0x04000273 RID: 627
		MustAgreeToSSA,
		// Token: 0x04000274 RID: 628
		LauncherMigrated,
		// Token: 0x04000275 RID: 629
		SteamRealmMismatch,
		// Token: 0x04000276 RID: 630
		InvalidSignature,
		// Token: 0x04000277 RID: 631
		ParseFailure,
		// Token: 0x04000278 RID: 632
		NoVerifiedPhone
	}
}
