using System;
using Sandbox;

namespace Native
{
	// Token: 0x02000040 RID: 64
	internal static class QApp
	{
		// Token: 0x060006C8 RID: 1736 RVA: 0x0001292C File Offset: 0x00010B2C
		internal static void setStyleSheet(string style)
		{
			method qApp_setStyleSheet = QApp.__N.qApp_setStyleSheet;
			calli(System.Void(System.IntPtr), Interop.GetWPointer(style), qApp_setStyleSheet);
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x0001294B File Offset: 0x00010B4B
		internal static void processEvents()
		{
			calli(System.Void(), QApp.__N.qApp_processEvents);
		}

		// Token: 0x0200010C RID: 268
		internal static class __N
		{
			// Token: 0x04000982 RID: 2434
			internal static method qApp_setStyleSheet;

			// Token: 0x04000983 RID: 2435
			internal static method qApp_processEvents;
		}
	}
}
