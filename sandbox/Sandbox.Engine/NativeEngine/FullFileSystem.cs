using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200022F RID: 559
	internal static class FullFileSystem
	{
		// Token: 0x06000E52 RID: 3666 RVA: 0x0001950C File Offset: 0x0001770C
		internal static string GetSymLink(string pPath, string pathID)
		{
			method gpFllF_GetSymLink = FullFileSystem.__N.gpFllF_GetSymLink;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.IntPtr), Interop.GetPointer(pPath), Interop.GetPointer(pathID), gpFllF_GetSymLink));
		}

		// Token: 0x06000E53 RID: 3667 RVA: 0x00019538 File Offset: 0x00017738
		internal static void AddSymLink(string pPath, string pathID, string realPath)
		{
			method gpFllF_AddSymLink = FullFileSystem.__N.gpFllF_AddSymLink;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), Interop.GetPointer(pPath), Interop.GetPointer(pathID), Interop.GetPointer(realPath), gpFllF_AddSymLink);
		}

		// Token: 0x06000E54 RID: 3668 RVA: 0x00019563 File Offset: 0x00017763
		internal static void ClearSymLinks()
		{
			calli(System.Void(), FullFileSystem.__N.gpFllF_ClearSymLinks);
		}

		// Token: 0x06000E55 RID: 3669 RVA: 0x00019570 File Offset: 0x00017770
		internal static void AddAddonsSearchPaths(bool addContentPaths)
		{
			method gpFllF_AddAddonsSearchPaths = FullFileSystem.__N.gpFllF_AddAddonsSearchPaths;
			calli(System.Void(System.Int32), addContentPaths ? 1 : 0, gpFllF_AddAddonsSearchPaths);
		}

		// Token: 0x02000394 RID: 916
		internal static class __N
		{
			// Token: 0x0400183F RID: 6207
			internal static method gpFllF_GetSymLink;

			// Token: 0x04001840 RID: 6208
			internal static method gpFllF_AddSymLink;

			// Token: 0x04001841 RID: 6209
			internal static method gpFllF_ClearSymLinks;

			// Token: 0x04001842 RID: 6210
			internal static method gpFllF_AddAddonsSearchPaths;
		}
	}
}
