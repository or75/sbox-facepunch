using System;
using NativeEngine;
using Sandbox;

// Token: 0x0200000A RID: 10
internal static class ServerGlobal
{
	// Token: 0x06000021 RID: 33 RVA: 0x000029F8 File Offset: 0x00000BF8
	internal static void UTIL_Remove(CBaseEntity entity)
	{
		method global_UTIL_Remove = ServerGlobal.__N.global_UTIL_Remove;
		calli(System.Void(System.IntPtr), entity, global_UTIL_Remove);
	}

	// Token: 0x06000022 RID: 34 RVA: 0x00002A18 File Offset: 0x00000C18
	internal static CBaseEntity CreateEntityByName(string className, int iForceEdictIndex)
	{
		method global_CreateEntityByName = ServerGlobal.__N.global_CreateEntityByName;
		return calli(System.IntPtr(System.IntPtr,System.Int32), Interop.GetPointer(className), iForceEdictIndex, global_CreateEntityByName);
	}

	// Token: 0x02000195 RID: 405
	internal static class __N
	{
		// Token: 0x040007C7 RID: 1991
		internal static method global_UTIL_Remove;

		// Token: 0x040007C8 RID: 1992
		internal static method global_CreateEntityByName;
	}
}
