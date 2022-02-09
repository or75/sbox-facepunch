using System;
using Sandbox;

// Token: 0x02000025 RID: 37
internal static class QFontDatabase
{
	// Token: 0x06000333 RID: 819 RVA: 0x00009A94 File Offset: 0x00007C94
	internal static int addApplicationFont(string fileName)
	{
		method qfntDt_addApplicationFont = QFontDatabase.__N.QFntDt_addApplicationFont;
		return calli(System.Int32(System.IntPtr), Interop.GetWPointer(fileName), qfntDt_addApplicationFont);
	}

	// Token: 0x020000F5 RID: 245
	internal static class __N
	{
		// Token: 0x040006E5 RID: 1765
		internal static method QFntDt_addApplicationFont;
	}
}
