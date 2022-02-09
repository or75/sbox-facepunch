using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000232 RID: 562
	internal static class InputService
	{
		// Token: 0x06000E5A RID: 3674 RVA: 0x000195E4 File Offset: 0x000177E4
		internal static void InsertCommand(InputCommandSource nSource, string pText, int nTickDelay, int nCommandLimit)
		{
			method gpInpt_InsertCommand = InputService.__N.gpInpt_InsertCommand;
			calli(System.Void(System.Int64,System.IntPtr,System.Int32,System.Int32), (long)nSource, Interop.GetPointer(pText), nTickDelay, nCommandLimit, gpInpt_InsertCommand);
		}

		// Token: 0x06000E5B RID: 3675 RVA: 0x00019607 File Offset: 0x00017807
		internal static bool IsAppActive()
		{
			return calli(System.Int32(), InputService.__N.gpInpt_IsAppActive) > 0;
		}

		// Token: 0x06000E5C RID: 3676 RVA: 0x00019616 File Offset: 0x00017816
		internal static bool HasMouseFocus()
		{
			return calli(System.Int32(), InputService.__N.gpInpt_HasMouseFocus) > 0;
		}

		// Token: 0x06000E5D RID: 3677 RVA: 0x00019625 File Offset: 0x00017825
		internal static int GetFrameCount()
		{
			return calli(System.Int32(), InputService.__N.gpInpt_GetFrameCount);
		}

		// Token: 0x06000E5E RID: 3678 RVA: 0x00019634 File Offset: 0x00017834
		internal static string Key_NameForBinding(string binding, int userid)
		{
			method gpInpt_Key_NameForBinding = InputService.__N.gpInpt_Key_NameForBinding;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int32), Interop.GetPointer(binding), userid, gpInpt_Key_NameForBinding));
		}

		// Token: 0x06000E5F RID: 3679 RVA: 0x0001965C File Offset: 0x0001785C
		internal static string GetBinding(ButtonCode button, int userid)
		{
			method gpInpt_GetBinding = InputService.__N.gpInpt_GetBinding;
			return Interop.GetString(calli(System.IntPtr(System.Int64,System.Int32), (long)button, userid, gpInpt_GetBinding));
		}

		// Token: 0x02000397 RID: 919
		internal static class __N
		{
			// Token: 0x04001847 RID: 6215
			internal static method gpInpt_InsertCommand;

			// Token: 0x04001848 RID: 6216
			internal static method gpInpt_IsAppActive;

			// Token: 0x04001849 RID: 6217
			internal static method gpInpt_HasMouseFocus;

			// Token: 0x0400184A RID: 6218
			internal static method gpInpt_GetFrameCount;

			// Token: 0x0400184B RID: 6219
			internal static method gpInpt_Key_NameForBinding;

			// Token: 0x0400184C RID: 6220
			internal static method gpInpt_GetBinding;
		}
	}
}
