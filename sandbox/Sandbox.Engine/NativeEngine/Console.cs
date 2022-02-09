using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000246 RID: 582
	internal static class Console
	{
		// Token: 0x06000F37 RID: 3895 RVA: 0x0001B1F0 File Offset: 0x000193F0
		internal unsafe static int GetAll(ConCommandBase[] ArrayOfbuffer, int maxSize, bool client, bool server)
		{
			if (ArrayOfbuffer == null)
			{
				ConCommandBase* ArrayOfbuffer_array_ptr = null;
				method ntveEn_Consol_GetAll = Console.__N.NtveEn_Consol_GetAll;
				return calli(System.Int32(NativeEngine.ConCommandBase*,System.Int32,System.Int32,System.Int32), ArrayOfbuffer_array_ptr, maxSize, client ? 1 : 0, server ? 1 : 0, ntveEn_Consol_GetAll);
			}
			fixed (ConCommandBase* ptr = &ArrayOfbuffer[0])
			{
				ConCommandBase* ArrayOfbuffer_array_ptr2 = ptr;
				method ntveEn_Consol_GetAll = Console.__N.NtveEn_Consol_GetAll;
				return calli(System.Int32(NativeEngine.ConCommandBase*,System.Int32,System.Int32,System.Int32), ArrayOfbuffer_array_ptr2, maxSize, client ? 1 : 0, server ? 1 : 0, ntveEn_Consol_GetAll);
			}
		}

		// Token: 0x06000F38 RID: 3896 RVA: 0x0001B248 File Offset: 0x00019448
		internal static string AutoComplete(string partial)
		{
			method ntveEn_Consol_AutoComplete = Console.__N.NtveEn_Consol_AutoComplete;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), Interop.GetPointer(partial), ntveEn_Consol_AutoComplete));
		}

		// Token: 0x020003AB RID: 939
		internal static class __N
		{
			// Token: 0x040018D0 RID: 6352
			internal static method NtveEn_Consol_GetAll;

			// Token: 0x040018D1 RID: 6353
			internal static method NtveEn_Consol_AutoComplete;
		}
	}
}
