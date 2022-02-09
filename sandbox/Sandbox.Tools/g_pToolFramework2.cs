using System;
using Native;

// Token: 0x0200001C RID: 28
internal static class g_pToolFramework2
{
	// Token: 0x06000214 RID: 532 RVA: 0x00007064 File Offset: 0x00005264
	internal static void BringEngineWindowToFront(QWidget returnTo)
	{
		method gpTlFr_BringEngineWindowToFront = g_pToolFramework2.__N.gpTlFr_BringEngineWindowToFront;
		calli(System.Void(System.IntPtr), returnTo, gpTlFr_BringEngineWindowToFront);
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00007083 File Offset: 0x00005283
	internal static void ReturnFromEngineWindow()
	{
		calli(System.Void(), g_pToolFramework2.__N.gpTlFr_ReturnFromEngineWindow);
	}

	// Token: 0x020000EC RID: 236
	internal static class __N
	{
		// Token: 0x04000626 RID: 1574
		internal static method gpTlFr_BringEngineWindowToFront;

		// Token: 0x04000627 RID: 1575
		internal static method gpTlFr_ReturnFromEngineWindow;
	}
}
