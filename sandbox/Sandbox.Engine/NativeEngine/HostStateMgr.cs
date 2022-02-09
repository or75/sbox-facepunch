using System;

namespace NativeEngine
{
	// Token: 0x02000231 RID: 561
	internal static class HostStateMgr
	{
		// Token: 0x06000E58 RID: 3672 RVA: 0x000195CB File Offset: 0x000177CB
		internal static void RequestHS_Quit()
		{
			calli(System.Void(), HostStateMgr.__N.gpHstS_RequestHS_Quit);
		}

		// Token: 0x06000E59 RID: 3673 RVA: 0x000195D7 File Offset: 0x000177D7
		internal static void RequestHS_Idle()
		{
			calli(System.Void(), HostStateMgr.__N.gpHstS_RequestHS_Idle);
		}

		// Token: 0x02000396 RID: 918
		internal static class __N
		{
			// Token: 0x04001845 RID: 6213
			internal static method gpHstS_RequestHS_Quit;

			// Token: 0x04001846 RID: 6214
			internal static method gpHstS_RequestHS_Idle;
		}
	}
}
