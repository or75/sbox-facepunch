using System;

namespace Tools
{
	// Token: 0x020000A2 RID: 162
	internal enum WindowFlags
	{
		// Token: 0x040003EB RID: 1003
		Widget,
		// Token: 0x040003EC RID: 1004
		Window,
		// Token: 0x040003ED RID: 1005
		Dialog = 3,
		// Token: 0x040003EE RID: 1006
		Sheet = 5,
		// Token: 0x040003EF RID: 1007
		Drawer = 7,
		// Token: 0x040003F0 RID: 1008
		Popup = 9,
		// Token: 0x040003F1 RID: 1009
		Tool = 11,
		// Token: 0x040003F2 RID: 1010
		ToolTip = 13,
		// Token: 0x040003F3 RID: 1011
		SplashScreen = 15,
		// Token: 0x040003F4 RID: 1012
		Desktop = 17,
		// Token: 0x040003F5 RID: 1013
		SubWindow,
		// Token: 0x040003F6 RID: 1014
		ForeignWindow = 33,
		// Token: 0x040003F7 RID: 1015
		CoverWindow = 65,
		// Token: 0x040003F8 RID: 1016
		WindowType_Mask = 255,
		// Token: 0x040003F9 RID: 1017
		MSWindowsFixedSizeDialogHint,
		// Token: 0x040003FA RID: 1018
		MSWindowsOwnDC = 512,
		// Token: 0x040003FB RID: 1019
		BypassWindowManagerHint = 1024,
		// Token: 0x040003FC RID: 1020
		X11BypassWindowManagerHint = 1024,
		// Token: 0x040003FD RID: 1021
		FramelessWindowHint = 2048,
		// Token: 0x040003FE RID: 1022
		WindowTitle = 4096,
		// Token: 0x040003FF RID: 1023
		WindowSystemMenuHint = 8192,
		// Token: 0x04000400 RID: 1024
		MinimizeButton = 16384,
		// Token: 0x04000401 RID: 1025
		MaximizeButton = 32768,
		// Token: 0x04000402 RID: 1026
		MinMaxButtons = 49152,
		// Token: 0x04000403 RID: 1027
		WindowContextHelpButtonHint = 65536,
		// Token: 0x04000404 RID: 1028
		WindowShadeButtonHint = 131072,
		// Token: 0x04000405 RID: 1029
		WindowStaysOnTopHint = 262144,
		// Token: 0x04000406 RID: 1030
		WindowTransparentForInput = 524288,
		// Token: 0x04000407 RID: 1031
		WindowOverridesSystemGestures = 1048576,
		// Token: 0x04000408 RID: 1032
		WindowDoesNotAcceptFocus = 2097152,
		// Token: 0x04000409 RID: 1033
		MaximizeUsingFullscreenGeometryHint = 4194304,
		// Token: 0x0400040A RID: 1034
		Customized = 33554432,
		// Token: 0x0400040B RID: 1035
		WindowStaysOnBottomHint = 67108864,
		// Token: 0x0400040C RID: 1036
		CloseButton = 134217728,
		// Token: 0x0400040D RID: 1037
		MacWindowToolBarButtonHint = 268435456,
		// Token: 0x0400040E RID: 1038
		BypassGraphicsProxyWidget = 536870912,
		// Token: 0x0400040F RID: 1039
		NoDropShadowWindowHint = 1073741824
	}
}
