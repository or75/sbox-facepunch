using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200022E RID: 558
	internal static class ICVar
	{
		// Token: 0x06000E4C RID: 3660 RVA: 0x0001945C File Offset: 0x0001765C
		internal static int AllocateDLLIdentifier()
		{
			return calli(System.Int32(), ICVar.__N.g_pCVa_AllocateDLLIdentifier);
		}

		// Token: 0x06000E4D RID: 3661 RVA: 0x00019468 File Offset: 0x00017668
		internal static void RegisterConCommand(ConCommandBase command)
		{
			method g_pCVa_RegisterConCommand = ICVar.__N.g_pCVa_RegisterConCommand;
			calli(System.Void(System.IntPtr), command, g_pCVa_RegisterConCommand);
		}

		// Token: 0x06000E4E RID: 3662 RVA: 0x00019488 File Offset: 0x00017688
		internal static void UnregisterConCommand(ConCommandBase command)
		{
			method g_pCVa_UnregisterConCommand = ICVar.__N.g_pCVa_UnregisterConCommand;
			calli(System.Void(System.IntPtr), command, g_pCVa_UnregisterConCommand);
		}

		// Token: 0x06000E4F RID: 3663 RVA: 0x000194A8 File Offset: 0x000176A8
		internal static void UnregisterConCommands(int dllIdent)
		{
			method g_pCVa_UnregisterConCommands = ICVar.__N.g_pCVa_UnregisterConCommands;
			calli(System.Void(System.Int32), dllIdent, g_pCVa_UnregisterConCommands);
		}

		// Token: 0x06000E50 RID: 3664 RVA: 0x000194C4 File Offset: 0x000176C4
		internal static string GetCommandLineValue(string name)
		{
			method g_pCVa_GetCommandLineValue = ICVar.__N.g_pCVa_GetCommandLineValue;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), Interop.GetPointer(name), g_pCVa_GetCommandLineValue));
		}

		// Token: 0x06000E51 RID: 3665 RVA: 0x000194E8 File Offset: 0x000176E8
		internal static ConCommandBase FindCommandBase(string name)
		{
			method g_pCVa_FindCommandBase = ICVar.__N.g_pCVa_FindCommandBase;
			return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(name), g_pCVa_FindCommandBase);
		}

		// Token: 0x02000393 RID: 915
		internal static class __N
		{
			// Token: 0x04001839 RID: 6201
			internal static method g_pCVa_AllocateDLLIdentifier;

			// Token: 0x0400183A RID: 6202
			internal static method g_pCVa_RegisterConCommand;

			// Token: 0x0400183B RID: 6203
			internal static method g_pCVa_UnregisterConCommand;

			// Token: 0x0400183C RID: 6204
			internal static method g_pCVa_UnregisterConCommands;

			// Token: 0x0400183D RID: 6205
			internal static method g_pCVa_GetCommandLineValue;

			// Token: 0x0400183E RID: 6206
			internal static method g_pCVa_FindCommandBase;
		}
	}
}
