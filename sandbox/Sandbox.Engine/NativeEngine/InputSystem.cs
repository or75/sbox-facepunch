using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000233 RID: 563
	internal static class InputSystem
	{
		// Token: 0x06000E60 RID: 3680 RVA: 0x00019680 File Offset: 0x00017880
		internal static void GetCursorPosition(out int x, out int y, IntPtr window)
		{
			method gpInpt_GetCursorPosition = InputSystem.__N.gpInpt_GetCursorPosition;
			calli(System.Void(System.Int32& modreq(System.Runtime.InteropServices.OutAttribute),System.Int32& modreq(System.Runtime.InteropServices.OutAttribute),System.IntPtr), ref x, ref y, window, gpInpt_GetCursorPosition);
		}

		// Token: 0x06000E61 RID: 3681 RVA: 0x0001969C File Offset: 0x0001789C
		internal static void SetCursorPosition(int x, int y, IntPtr window)
		{
			method gpInpt_SetCursorPosition = InputSystem.__N.gpInpt_SetCursorPosition;
			calli(System.Void(System.Int32,System.Int32,System.IntPtr), x, y, window, gpInpt_SetCursorPosition);
		}

		// Token: 0x06000E62 RID: 3682 RVA: 0x000196B8 File Offset: 0x000178B8
		internal static bool HasMouseFocus()
		{
			return calli(System.Int32(), InputSystem.__N.gpInpt_f2) > 0;
		}

		// Token: 0x06000E63 RID: 3683 RVA: 0x000196C7 File Offset: 0x000178C7
		internal static bool IsAppActive()
		{
			return calli(System.Int32(), InputSystem.__N.gpInpt_f3) > 0;
		}

		// Token: 0x06000E64 RID: 3684 RVA: 0x000196D6 File Offset: 0x000178D6
		internal static bool IsIMEAllowed()
		{
			return calli(System.Int32(), InputSystem.__N.gpInpt_IsIMEAllowed) > 0;
		}

		// Token: 0x06000E65 RID: 3685 RVA: 0x000196E8 File Offset: 0x000178E8
		internal static void SetIMEAllowed(bool bAllowed)
		{
			method gpInpt_SetIMEAllowed = InputSystem.__N.gpInpt_SetIMEAllowed;
			calli(System.Void(System.Int32), bAllowed ? 1 : 0, gpInpt_SetIMEAllowed);
		}

		// Token: 0x06000E66 RID: 3686 RVA: 0x00019708 File Offset: 0x00017908
		internal static void SetIMETextLocation(int x, int y, int nWidth, int nHeight)
		{
			method gpInpt_SetIMETextLocation = InputSystem.__N.gpInpt_SetIMETextLocation;
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), x, y, nWidth, nHeight, gpInpt_SetIMETextLocation);
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x00019725 File Offset: 0x00017925
		internal static void DismissIME()
		{
			calli(System.Void(), InputSystem.__N.gpInpt_DismissIME);
		}

		// Token: 0x06000E68 RID: 3688 RVA: 0x00019734 File Offset: 0x00017934
		internal static string GetIMEComposition(int flags)
		{
			method gpInpt_GetIMEComposition = InputSystem.__N.gpInpt_GetIMEComposition;
			return Interop.GetString(calli(System.IntPtr(System.Int32), flags, gpInpt_GetIMEComposition));
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x00019754 File Offset: 0x00017954
		internal static string CodeToString(ButtonCode code)
		{
			method gpInpt_CodeToString = InputSystem.__N.gpInpt_CodeToString;
			return Interop.GetString(calli(System.IntPtr(System.Int64), (long)code, gpInpt_CodeToString));
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x00019774 File Offset: 0x00017974
		internal static ButtonCode StringToButtonCode(string pString)
		{
			method gpInpt_StringToButtonCode = InputSystem.__N.gpInpt_StringToButtonCode;
			return calli(System.Int64(System.IntPtr), Interop.GetPointer(pString), gpInpt_StringToButtonCode);
		}

		// Token: 0x02000398 RID: 920
		internal static class __N
		{
			// Token: 0x0400184D RID: 6221
			internal static method gpInpt_GetCursorPosition;

			// Token: 0x0400184E RID: 6222
			internal static method gpInpt_SetCursorPosition;

			// Token: 0x0400184F RID: 6223
			internal static method gpInpt_f2;

			// Token: 0x04001850 RID: 6224
			internal static method gpInpt_f3;

			// Token: 0x04001851 RID: 6225
			internal static method gpInpt_IsIMEAllowed;

			// Token: 0x04001852 RID: 6226
			internal static method gpInpt_SetIMEAllowed;

			// Token: 0x04001853 RID: 6227
			internal static method gpInpt_SetIMETextLocation;

			// Token: 0x04001854 RID: 6228
			internal static method gpInpt_DismissIME;

			// Token: 0x04001855 RID: 6229
			internal static method gpInpt_GetIMEComposition;

			// Token: 0x04001856 RID: 6230
			internal static method gpInpt_CodeToString;

			// Token: 0x04001857 RID: 6231
			internal static method gpInpt_StringToButtonCode;
		}
	}
}
