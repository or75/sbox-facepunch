using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200022D RID: 557
	internal static class EngineGlue
	{
		// Token: 0x06000E41 RID: 3649 RVA: 0x000192DC File Offset: 0x000174DC
		internal static KeyValues3 JsonToKeyValues3(string json)
		{
			method engneG_JsonToKeyValues = EngineGlue.__N.EngneG_JsonToKeyValues3;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(json), engneG_JsonToKeyValues);
		}

		// Token: 0x06000E42 RID: 3650 RVA: 0x00019300 File Offset: 0x00017500
		internal static string KeyValues3ToJson(KeyValues3 kv)
		{
			method engneG_KeyValues3ToJson = EngineGlue.__N.EngneG_KeyValues3ToJson;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), kv, engneG_KeyValues3ToJson));
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x00019324 File Offset: 0x00017524
		internal static KeyValues3 LoadKeyValues3(string kvString)
		{
			method engneG_LoadKeyValues = EngineGlue.__N.EngneG_LoadKeyValues3;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(kvString), engneG_LoadKeyValues);
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x00019348 File Offset: 0x00017548
		internal static uint GetStringToken(string str)
		{
			method engneG_GetStringToken = EngineGlue.__N.EngneG_GetStringToken;
			return calli(System.UInt32(System.IntPtr), Interop.GetPointer(str), engneG_GetStringToken);
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x00019368 File Offset: 0x00017568
		internal static void SendClientUserInfo(string name, string val)
		{
			method engneG_SendClientUserInfo = EngineGlue.__N.EngneG_SendClientUserInfo;
			calli(System.Void(System.IntPtr,System.IntPtr), Interop.GetPointer(name), Interop.GetPointer(val), engneG_SendClientUserInfo);
		}

		// Token: 0x06000E46 RID: 3654 RVA: 0x0001938D File Offset: 0x0001758D
		internal static bool IsListenServer()
		{
			return calli(System.Int32(), EngineGlue.__N.EngneG_IsListenServer) > 0;
		}

		// Token: 0x06000E47 RID: 3655 RVA: 0x0001939C File Offset: 0x0001759C
		internal static string GetConvarValue(string name)
		{
			method engneG_GetConvarValue = EngineGlue.__N.EngneG_GetConvarValue;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), Interop.GetPointer(name), engneG_GetConvarValue));
		}

		// Token: 0x06000E48 RID: 3656 RVA: 0x000193C0 File Offset: 0x000175C0
		internal static float GetConvarValueFloat(string name, float defaultval)
		{
			method engneG_GetConvarValueFloat = EngineGlue.__N.EngneG_GetConvarValueFloat;
			return calli(System.Single(System.IntPtr,System.Single), Interop.GetPointer(name), defaultval, engneG_GetConvarValueFloat);
		}

		// Token: 0x06000E49 RID: 3657 RVA: 0x000193E0 File Offset: 0x000175E0
		internal static void SetConvarValue(string name, string value)
		{
			method engneG_SetConvarValue = EngineGlue.__N.EngneG_SetConvarValue;
			calli(System.Void(System.IntPtr,System.IntPtr), Interop.GetPointer(name), Interop.GetPointer(value), engneG_SetConvarValue);
		}

		// Token: 0x06000E4A RID: 3658 RVA: 0x00019408 File Offset: 0x00017608
		internal static void AddSearchPath(string path, string groupid, bool head)
		{
			method engneG_AddSearchPath = EngineGlue.__N.EngneG_AddSearchPath;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), Interop.GetPointer(path), Interop.GetPointer(groupid), head ? 1 : 0, engneG_AddSearchPath);
		}

		// Token: 0x06000E4B RID: 3659 RVA: 0x00019434 File Offset: 0x00017634
		internal static bool RemoveSearchPath(string path, string groupid)
		{
			method engneG_RemoveSearchPath = EngineGlue.__N.EngneG_RemoveSearchPath;
			return calli(System.Int32(System.IntPtr,System.IntPtr), Interop.GetPointer(path), Interop.GetPointer(groupid), engneG_RemoveSearchPath) > 0;
		}

		// Token: 0x02000392 RID: 914
		internal static class __N
		{
			// Token: 0x0400182E RID: 6190
			internal static method EngneG_JsonToKeyValues3;

			// Token: 0x0400182F RID: 6191
			internal static method EngneG_KeyValues3ToJson;

			// Token: 0x04001830 RID: 6192
			internal static method EngneG_LoadKeyValues3;

			// Token: 0x04001831 RID: 6193
			internal static method EngneG_GetStringToken;

			// Token: 0x04001832 RID: 6194
			internal static method EngneG_SendClientUserInfo;

			// Token: 0x04001833 RID: 6195
			internal static method EngneG_IsListenServer;

			// Token: 0x04001834 RID: 6196
			internal static method EngneG_GetConvarValue;

			// Token: 0x04001835 RID: 6197
			internal static method EngneG_GetConvarValueFloat;

			// Token: 0x04001836 RID: 6198
			internal static method EngneG_SetConvarValue;

			// Token: 0x04001837 RID: 6199
			internal static method EngneG_AddSearchPath;

			// Token: 0x04001838 RID: 6200
			internal static method EngneG_RemoveSearchPath;
		}
	}
}
