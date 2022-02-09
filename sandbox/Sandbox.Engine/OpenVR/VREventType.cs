using System;

namespace OpenVR
{
	// Token: 0x0200000B RID: 11
	internal enum VREventType : uint
	{
		// Token: 0x0400000E RID: 14
		None,
		// Token: 0x0400000F RID: 15
		TrackedDeviceActivated = 100U,
		// Token: 0x04000010 RID: 16
		TrackedDeviceDeactivated,
		// Token: 0x04000011 RID: 17
		TrackedDeviceUpdated,
		// Token: 0x04000012 RID: 18
		TrackedDeviceUserInteractionStarted,
		// Token: 0x04000013 RID: 19
		TrackedDeviceUserInteractionEnded,
		// Token: 0x04000014 RID: 20
		IpdChanged,
		// Token: 0x04000015 RID: 21
		EnterStandbyMode,
		// Token: 0x04000016 RID: 22
		LeaveStandbyMode,
		// Token: 0x04000017 RID: 23
		TrackedDeviceRoleChanged,
		// Token: 0x04000018 RID: 24
		WatchdogWakeUpRequested,
		// Token: 0x04000019 RID: 25
		LensDistortionChanged,
		// Token: 0x0400001A RID: 26
		PropertyChanged,
		// Token: 0x0400001B RID: 27
		WirelessDisconnect,
		// Token: 0x0400001C RID: 28
		WirelessReconnect,
		// Token: 0x0400001D RID: 29
		ButtonPress = 200U,
		// Token: 0x0400001E RID: 30
		ButtonUnpress,
		// Token: 0x0400001F RID: 31
		ButtonTouch,
		// Token: 0x04000020 RID: 32
		ButtonUntouch,
		// Token: 0x04000021 RID: 33
		Modal_Cancel = 257U,
		// Token: 0x04000022 RID: 34
		MouseMove = 300U,
		// Token: 0x04000023 RID: 35
		MouseButtonDown,
		// Token: 0x04000024 RID: 36
		MouseButtonUp,
		// Token: 0x04000025 RID: 37
		FocusEnter,
		// Token: 0x04000026 RID: 38
		FocusLeave,
		// Token: 0x04000027 RID: 39
		ScrollDiscrete,
		// Token: 0x04000028 RID: 40
		TouchPadMove,
		// Token: 0x04000029 RID: 41
		OverlayFocusChanged,
		// Token: 0x0400002A RID: 42
		ReloadOverlays,
		// Token: 0x0400002B RID: 43
		ScrollSmooth,
		// Token: 0x0400002C RID: 44
		LockMousePosition,
		// Token: 0x0400002D RID: 45
		UnlockMousePosition,
		// Token: 0x0400002E RID: 46
		InputFocusCaptured = 400U,
		// Token: 0x0400002F RID: 47
		InputFocusReleased,
		// Token: 0x04000030 RID: 48
		SceneApplicationChanged = 404U,
		// Token: 0x04000031 RID: 49
		SceneFocusChanged,
		// Token: 0x04000032 RID: 50
		InputFocusChanged,
		// Token: 0x04000033 RID: 51
		SceneApplicationUsingWrongGraphicsAdapter = 408U,
		// Token: 0x04000034 RID: 52
		ActionBindingReloaded,
		// Token: 0x04000035 RID: 53
		HideRenderModels,
		// Token: 0x04000036 RID: 54
		ShowRenderModels,
		// Token: 0x04000037 RID: 55
		SceneApplicationStateChanged,
		// Token: 0x04000038 RID: 56
		ConsoleOpened = 420U,
		// Token: 0x04000039 RID: 57
		ConsoleClosed,
		// Token: 0x0400003A RID: 58
		OverlayShown = 500U,
		// Token: 0x0400003B RID: 59
		OverlayHidden,
		// Token: 0x0400003C RID: 60
		DashboardActivated,
		// Token: 0x0400003D RID: 61
		DashboardDeactivated,
		// Token: 0x0400003E RID: 62
		DashboardRequested = 505U,
		// Token: 0x0400003F RID: 63
		ResetDashboard,
		// Token: 0x04000040 RID: 64
		ImageLoaded = 508U,
		// Token: 0x04000041 RID: 65
		ShowKeyboard,
		// Token: 0x04000042 RID: 66
		HideKeyboard,
		// Token: 0x04000043 RID: 67
		OverlayGamepadFocusGained,
		// Token: 0x04000044 RID: 68
		OverlayGamepadFocusLost,
		// Token: 0x04000045 RID: 69
		OverlaySharedTextureChanged,
		// Token: 0x04000046 RID: 70
		ScreenshotTriggered = 516U,
		// Token: 0x04000047 RID: 71
		ImageFailed,
		// Token: 0x04000048 RID: 72
		DashboardOverlayCreated,
		// Token: 0x04000049 RID: 73
		SwitchGamepadFocus,
		// Token: 0x0400004A RID: 74
		RequestScreenshot,
		// Token: 0x0400004B RID: 75
		ScreenshotTaken,
		// Token: 0x0400004C RID: 76
		ScreenshotFailed,
		// Token: 0x0400004D RID: 77
		SubmitScreenshotToDashboard,
		// Token: 0x0400004E RID: 78
		ScreenshotProgressToDashboard,
		// Token: 0x0400004F RID: 79
		PrimaryDashboardDeviceChanged,
		// Token: 0x04000050 RID: 80
		RoomViewShown,
		// Token: 0x04000051 RID: 81
		RoomViewHidden,
		// Token: 0x04000052 RID: 82
		ShowUI,
		// Token: 0x04000053 RID: 83
		ShowDevTools,
		// Token: 0x04000054 RID: 84
		DesktopViewUpdating,
		// Token: 0x04000055 RID: 85
		DesktopViewReady,
		// Token: 0x04000056 RID: 86
		Notification_Shown = 600U,
		// Token: 0x04000057 RID: 87
		Notification_Hidden,
		// Token: 0x04000058 RID: 88
		Notification_BeginInteraction,
		// Token: 0x04000059 RID: 89
		Notification_Destroyed,
		// Token: 0x0400005A RID: 90
		Quit = 700U,
		// Token: 0x0400005B RID: 91
		ProcessQuit,
		// Token: 0x0400005C RID: 92
		QuitAcknowledged = 703U,
		// Token: 0x0400005D RID: 93
		DriverRequestedQuit,
		// Token: 0x0400005E RID: 94
		RestartRequested,
		// Token: 0x0400005F RID: 95
		ChaperoneDataHasChanged = 800U,
		// Token: 0x04000060 RID: 96
		ChaperoneUniverseHasChanged,
		// Token: 0x04000061 RID: 97
		ChaperoneTempDataHasChanged,
		// Token: 0x04000062 RID: 98
		ChaperoneSettingsHaveChanged,
		// Token: 0x04000063 RID: 99
		SeatedZeroPoseReset,
		// Token: 0x04000064 RID: 100
		ChaperoneFlushCache,
		// Token: 0x04000065 RID: 101
		ChaperoneRoomSetupStarting,
		// Token: 0x04000066 RID: 102
		ChaperoneRoomSetupFinished,
		// Token: 0x04000067 RID: 103
		StandingZeroPoseReset,
		// Token: 0x04000068 RID: 104
		AudioSettingsHaveChanged = 820U,
		// Token: 0x04000069 RID: 105
		BackgroundSettingHasChanged = 850U,
		// Token: 0x0400006A RID: 106
		CameraSettingsHaveChanged,
		// Token: 0x0400006B RID: 107
		ReprojectionSettingHasChanged,
		// Token: 0x0400006C RID: 108
		ModelSkinSettingsHaveChanged,
		// Token: 0x0400006D RID: 109
		EnvironmentSettingsHaveChanged,
		// Token: 0x0400006E RID: 110
		PowerSettingsHaveChanged,
		// Token: 0x0400006F RID: 111
		EnableHomeAppSettingsHaveChanged,
		// Token: 0x04000070 RID: 112
		SteamVRSectionSettingChanged,
		// Token: 0x04000071 RID: 113
		LighthouseSectionSettingChanged,
		// Token: 0x04000072 RID: 114
		NullSectionSettingChanged,
		// Token: 0x04000073 RID: 115
		UserInterfaceSectionSettingChanged,
		// Token: 0x04000074 RID: 116
		NotificationsSectionSettingChanged,
		// Token: 0x04000075 RID: 117
		KeyboardSectionSettingChanged,
		// Token: 0x04000076 RID: 118
		PerfSectionSettingChanged,
		// Token: 0x04000077 RID: 119
		DashboardSectionSettingChanged,
		// Token: 0x04000078 RID: 120
		WebInterfaceSectionSettingChanged,
		// Token: 0x04000079 RID: 121
		TrackersSectionSettingChanged,
		// Token: 0x0400007A RID: 122
		LastKnownSectionSettingChanged,
		// Token: 0x0400007B RID: 123
		DismissedWarningsSectionSettingChanged,
		// Token: 0x0400007C RID: 124
		GpuSpeedSectionSettingChanged,
		// Token: 0x0400007D RID: 125
		WindowsMRSectionSettingChanged,
		// Token: 0x0400007E RID: 126
		OtherSectionSettingChanged,
		// Token: 0x0400007F RID: 127
		StatusUpdate = 900U,
		// Token: 0x04000080 RID: 128
		WebInterface_InstallDriverCompleted = 950U,
		// Token: 0x04000081 RID: 129
		MCImageUpdated = 1000U,
		// Token: 0x04000082 RID: 130
		FirmwareUpdateStarted = 1100U,
		// Token: 0x04000083 RID: 131
		FirmwareUpdateFinished,
		// Token: 0x04000084 RID: 132
		KeyboardClosed = 1200U,
		// Token: 0x04000085 RID: 133
		KeyboardCharInput,
		// Token: 0x04000086 RID: 134
		KeyboardDone,
		// Token: 0x04000087 RID: 135
		ApplicationListUpdated = 1303U,
		// Token: 0x04000088 RID: 136
		ApplicationMimeTypeLoad,
		// Token: 0x04000089 RID: 137
		ProcessConnected = 1306U,
		// Token: 0x0400008A RID: 138
		ProcessDisconnected,
		// Token: 0x0400008B RID: 139
		Compositor_ChaperoneBoundsShown = 1410U,
		// Token: 0x0400008C RID: 140
		Compositor_ChaperoneBoundsHidden,
		// Token: 0x0400008D RID: 141
		Compositor_DisplayDisconnected,
		// Token: 0x0400008E RID: 142
		Compositor_DisplayReconnected,
		// Token: 0x0400008F RID: 143
		Compositor_HDCPError,
		// Token: 0x04000090 RID: 144
		Compositor_ApplicationNotResponding,
		// Token: 0x04000091 RID: 145
		Compositor_ApplicationResumed,
		// Token: 0x04000092 RID: 146
		Compositor_OutOfVideoMemory,
		// Token: 0x04000093 RID: 147
		Compositor_DisplayModeNotSupported,
		// Token: 0x04000094 RID: 148
		Compositor_StageOverrideReady,
		// Token: 0x04000095 RID: 149
		TrackedCamera_StartVideoStream = 1500U,
		// Token: 0x04000096 RID: 150
		TrackedCamera_StopVideoStream,
		// Token: 0x04000097 RID: 151
		TrackedCamera_PauseVideoStream,
		// Token: 0x04000098 RID: 152
		TrackedCamera_ResumeVideoStream,
		// Token: 0x04000099 RID: 153
		TrackedCamera_EditingSurface = 1550U,
		// Token: 0x0400009A RID: 154
		PerformanceTest_EnableCapture = 1600U,
		// Token: 0x0400009B RID: 155
		PerformanceTest_DisableCapture,
		// Token: 0x0400009C RID: 156
		PerformanceTest_FidelityLevel,
		// Token: 0x0400009D RID: 157
		MessageOverlay_Closed = 1650U,
		// Token: 0x0400009E RID: 158
		MessageOverlayCloseRequested,
		// Token: 0x0400009F RID: 159
		Input_HapticVibration = 1700U,
		// Token: 0x040000A0 RID: 160
		Input_BindingLoadFailed,
		// Token: 0x040000A1 RID: 161
		Input_BindingLoadSuccessful,
		// Token: 0x040000A2 RID: 162
		Input_ActionManifestReloaded,
		// Token: 0x040000A3 RID: 163
		Input_ActionManifestLoadFailed,
		// Token: 0x040000A4 RID: 164
		Input_ProgressUpdate,
		// Token: 0x040000A5 RID: 165
		Input_TrackerActivated,
		// Token: 0x040000A6 RID: 166
		Input_BindingsUpdated,
		// Token: 0x040000A7 RID: 167
		Input_BindingSubscriptionChanged,
		// Token: 0x040000A8 RID: 168
		SpatialAnchors_PoseUpdated = 1800U,
		// Token: 0x040000A9 RID: 169
		SpatialAnchors_DescriptorUpdated,
		// Token: 0x040000AA RID: 170
		SpatialAnchors_RequestPoseUpdate,
		// Token: 0x040000AB RID: 171
		SpatialAnchors_RequestDescriptorUpdate,
		// Token: 0x040000AC RID: 172
		SystemReport_Started = 1900U,
		// Token: 0x040000AD RID: 173
		Monitor_ShowHeadsetView = 2000U,
		// Token: 0x040000AE RID: 174
		Monitor_HideHeadsetView,
		// Token: 0x040000AF RID: 175
		VendorSpecific_Reserved_Start = 10000U,
		// Token: 0x040000B0 RID: 176
		VendorSpecific_Reserved_End = 19999U
	}
}
