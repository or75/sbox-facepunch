using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000247 RID: 583
	internal static class WindowsGlue
	{
		// Token: 0x06000F39 RID: 3897 RVA: 0x0001B26C File Offset: 0x0001946C
		internal static string FindFile()
		{
			return Interop.GetString(calli(System.IntPtr(), WindowsGlue.__N.WndwsG_FindFile));
		}

		// Token: 0x020003AC RID: 940
		internal static class __N
		{
			// Token: 0x040018D2 RID: 6354
			internal static method WndwsG_FindFile;
		}
	}
}
