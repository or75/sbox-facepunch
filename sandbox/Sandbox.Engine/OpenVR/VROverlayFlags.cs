using System;

namespace OpenVR
{
	// Token: 0x02000014 RID: 20
	internal enum VROverlayFlags
	{
		// Token: 0x040000ED RID: 237
		NoDashboardTab = 8,
		// Token: 0x040000EE RID: 238
		SendVRDiscreteScrollEvents = 64,
		// Token: 0x040000EF RID: 239
		SendVRTouchpadEvents = 128,
		// Token: 0x040000F0 RID: 240
		ShowTouchPadScrollWheel = 256,
		// Token: 0x040000F1 RID: 241
		TransferOwnershipToInternalProcess = 512,
		// Token: 0x040000F2 RID: 242
		SideBySide_Parallel = 1024,
		// Token: 0x040000F3 RID: 243
		SideBySide_Crossed = 2048,
		// Token: 0x040000F4 RID: 244
		Panorama = 4096,
		// Token: 0x040000F5 RID: 245
		StereoPanorama = 8192,
		// Token: 0x040000F6 RID: 246
		SortWithNonSceneOverlays = 16384,
		// Token: 0x040000F7 RID: 247
		VisibleInDashboard = 32768,
		// Token: 0x040000F8 RID: 248
		MakeOverlaysInteractiveIfVisible = 65536,
		// Token: 0x040000F9 RID: 249
		SendVRSmoothScrollEvents = 131072,
		// Token: 0x040000FA RID: 250
		ProtectedContent = 262144,
		// Token: 0x040000FB RID: 251
		HideLaserIntersection = 524288,
		// Token: 0x040000FC RID: 252
		WantsModalBehavior = 1048576,
		// Token: 0x040000FD RID: 253
		IsPremultiplied = 2097152
	}
}
