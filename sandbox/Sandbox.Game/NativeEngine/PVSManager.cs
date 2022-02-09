using System;

namespace NativeEngine
{
	// Token: 0x02000046 RID: 70
	internal static class PVSManager
	{
		// Token: 0x0600095C RID: 2396 RVA: 0x00036CF0 File Offset: 0x00034EF0
		internal unsafe static void AddOriginToPVS(int handle, Vector3 origin, VisInfo pvsS)
		{
			method gpPVSM_AddOriginToPVS = PVSManager.__N.gpPVSM_AddOriginToPVS;
			calli(System.Void(System.Int32,Vector3*,System.IntPtr), handle, &origin, pvsS, gpPVSM_AddOriginToPVS);
		}

		// Token: 0x020001CB RID: 459
		internal static class __N
		{
			// Token: 0x04000E83 RID: 3715
			internal static method gpPVSM_AddOriginToPVS;
		}
	}
}
