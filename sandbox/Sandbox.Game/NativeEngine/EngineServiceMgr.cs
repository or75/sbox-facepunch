using System;

namespace NativeEngine
{
	// Token: 0x02000040 RID: 64
	internal static class EngineServiceMgr
	{
		// Token: 0x06000947 RID: 2375 RVA: 0x00036AC0 File Offset: 0x00034CC0
		internal static int GetEngineDeviceWidth()
		{
			return calli(System.Int32(), EngineServiceMgr.__N.gpEngn_GetEngineDeviceWidth);
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00036ACC File Offset: 0x00034CCC
		internal static int GetEngineDeviceHeight()
		{
			return calli(System.Int32(), EngineServiceMgr.__N.gpEngn_GetEngineDeviceHeight);
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x00036AD8 File Offset: 0x00034CD8
		internal static void GetEngineSwapChainSize(out int w, out int h)
		{
			method gpEngn_GetEngineSwapChainSize = EngineServiceMgr.__N.gpEngn_GetEngineSwapChainSize;
			calli(System.Void(System.Int32& modreq(System.Runtime.InteropServices.OutAttribute),System.Int32& modreq(System.Runtime.InteropServices.OutAttribute)), ref w, ref h, gpEngn_GetEngineSwapChainSize);
		}

		// Token: 0x0600094A RID: 2378 RVA: 0x00036AF3 File Offset: 0x00034CF3
		internal static bool IsLoopSwitchQueued()
		{
			return calli(System.Int32(), EngineServiceMgr.__N.gpEngn_IsLoopSwitchQueued) > 0;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x00036B02 File Offset: 0x00034D02
		internal static bool IsLoopSwitchRequested()
		{
			return calli(System.Int32(), EngineServiceMgr.__N.gpEngn_IsLoopSwitchRequested) > 0;
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x00036B11 File Offset: 0x00034D11
		internal static bool IsLoadingLevel()
		{
			return calli(System.Int32(), EngineServiceMgr.__N.gpEngn_IsLoadingLevel) > 0;
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x00036B20 File Offset: 0x00034D20
		internal static bool IsInGameLoop()
		{
			return calli(System.Int32(), EngineServiceMgr.__N.gpEngn_IsInGameLoop) > 0;
		}

		// Token: 0x020001C5 RID: 453
		internal static class __N
		{
			// Token: 0x04000E6E RID: 3694
			internal static method gpEngn_GetEngineDeviceWidth;

			// Token: 0x04000E6F RID: 3695
			internal static method gpEngn_GetEngineDeviceHeight;

			// Token: 0x04000E70 RID: 3696
			internal static method gpEngn_GetEngineSwapChainSize;

			// Token: 0x04000E71 RID: 3697
			internal static method gpEngn_IsLoopSwitchQueued;

			// Token: 0x04000E72 RID: 3698
			internal static method gpEngn_IsLoopSwitchRequested;

			// Token: 0x04000E73 RID: 3699
			internal static method gpEngn_IsLoadingLevel;

			// Token: 0x04000E74 RID: 3700
			internal static method gpEngn_IsInGameLoop;
		}
	}
}
