using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000044 RID: 68
	internal static class NetworkStringTableContainer
	{
		// Token: 0x06000955 RID: 2389 RVA: 0x00036C40 File Offset: 0x00034E40
		internal static INetworkStringTable CreateStringTable(string tableName, int userdatafixedsize, int userdatanetworkbits, NetworkStringtableFlags flags)
		{
			method gpNetw_CreateStringTable = NetworkStringTableContainer.__N.gpNetw_CreateStringTable;
			return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32,System.Int64), Interop.GetPointer(tableName), userdatafixedsize, userdatanetworkbits, (long)flags, gpNetw_CreateStringTable);
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x00036C68 File Offset: 0x00034E68
		internal static void RemoveAllTables()
		{
			calli(System.Void(), NetworkStringTableContainer.__N.gpNetw_RemoveAllTables);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x00036C74 File Offset: 0x00034E74
		internal static INetworkStringTable FindTable(string name)
		{
			method gpNetw_FindTable = NetworkStringTableContainer.__N.gpNetw_FindTable;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(name), gpNetw_FindTable);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00036C98 File Offset: 0x00034E98
		internal static INetworkStringTable GetTable(int tableId)
		{
			method gpNetw_GetTable = NetworkStringTableContainer.__N.gpNetw_GetTable;
			return calli(System.IntPtr(System.Int32), tableId, gpNetw_GetTable);
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x00036CB7 File Offset: 0x00034EB7
		internal static int GetNumTables()
		{
			return calli(System.Int32(), NetworkStringTableContainer.__N.gpNetw_GetNumTables);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x00036CC3 File Offset: 0x00034EC3
		internal static string GetPrefix()
		{
			return Interop.GetString(calli(System.IntPtr(), NetworkStringTableContainer.__N.gpNetw_GetPrefix));
		}

		// Token: 0x020001C9 RID: 457
		internal static class __N
		{
			// Token: 0x04000E7C RID: 3708
			internal static method gpNetw_CreateStringTable;

			// Token: 0x04000E7D RID: 3709
			internal static method gpNetw_RemoveAllTables;

			// Token: 0x04000E7E RID: 3710
			internal static method gpNetw_FindTable;

			// Token: 0x04000E7F RID: 3711
			internal static method gpNetw_GetTable;

			// Token: 0x04000E80 RID: 3712
			internal static method gpNetw_GetNumTables;

			// Token: 0x04000E81 RID: 3713
			internal static method gpNetw_GetPrefix;
		}
	}
}
