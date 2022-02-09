using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000020 RID: 32
	internal static class ClientGlobal
	{
		// Token: 0x06000361 RID: 865 RVA: 0x00027D2C File Offset: 0x00025F2C
		internal static void UTIL_Remove(C_BaseEntity entity)
		{
			method global_UTIL_Remove = ClientGlobal.__N.global_UTIL_Remove;
			calli(System.Void(System.IntPtr), entity, global_UTIL_Remove);
		}

		// Token: 0x06000362 RID: 866 RVA: 0x00027D4C File Offset: 0x00025F4C
		internal unsafe static int ScreenTransform(Vector3 point, out Vector3 screen)
		{
			method global_ScreenTransform = ClientGlobal.__N.global_ScreenTransform;
			return calli(System.Int32(Vector3*,Vector3& modreq(System.Runtime.InteropServices.OutAttribute)), &point, ref screen, global_ScreenTransform);
		}

		// Token: 0x06000363 RID: 867 RVA: 0x00027D69 File Offset: 0x00025F69
		internal static void SteamClientInit()
		{
			calli(System.Void(), ClientGlobal.__N.global_SteamClientInit);
		}

		// Token: 0x06000364 RID: 868 RVA: 0x00027D75 File Offset: 0x00025F75
		internal static void SteamClientShutdown()
		{
			calli(System.Void(), ClientGlobal.__N.global_SteamClientShutdown);
		}

		// Token: 0x06000365 RID: 869 RVA: 0x00027D81 File Offset: 0x00025F81
		internal static void SteamAPI_RunCallbacks()
		{
			calli(System.Void(), ClientGlobal.__N.global_SteamAPI_RunCallbacks);
		}

		// Token: 0x06000366 RID: 870 RVA: 0x00027D90 File Offset: 0x00025F90
		internal static int SDL_SetClipboardText(string text)
		{
			method global_SDL_SetClipboardText = ClientGlobal.__N.global_SDL_SetClipboardText;
			return calli(System.Int32(System.IntPtr), Interop.GetPointer(text), global_SDL_SetClipboardText);
		}

		// Token: 0x06000367 RID: 871 RVA: 0x00027DAF File Offset: 0x00025FAF
		internal static string SDL_GetClipboardText()
		{
			return Interop.GetString(calli(System.IntPtr(), ClientGlobal.__N.global_SDL_GetClipboardText));
		}

		// Token: 0x06000368 RID: 872 RVA: 0x00027DC0 File Offset: 0x00025FC0
		internal static bool SDL_HasClipboardText()
		{
			return calli(System.Int32(), ClientGlobal.__N.global_SDL_HasClipboardText) > 0;
		}

		// Token: 0x020001A5 RID: 421
		internal static class __N
		{
			// Token: 0x040009B4 RID: 2484
			internal static method global_UTIL_Remove;

			// Token: 0x040009B5 RID: 2485
			internal static method global_ScreenTransform;

			// Token: 0x040009B6 RID: 2486
			internal static method global_SteamClientInit;

			// Token: 0x040009B7 RID: 2487
			internal static method global_SteamClientShutdown;

			// Token: 0x040009B8 RID: 2488
			internal static method global_SteamAPI_RunCallbacks;

			// Token: 0x040009B9 RID: 2489
			internal static method global_SDL_SetClipboardText;

			// Token: 0x040009BA RID: 2490
			internal static method global_SDL_GetClipboardText;

			// Token: 0x040009BB RID: 2491
			internal static method global_SDL_HasClipboardText;
		}
	}
}
