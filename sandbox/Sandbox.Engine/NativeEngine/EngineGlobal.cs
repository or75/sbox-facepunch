using System;
using System.Runtime.InteropServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200023A RID: 570
	internal static class EngineGlobal
	{
		// Token: 0x06000E81 RID: 3713 RVA: 0x00019A6C File Offset: 0x00017C6C
		internal static void Plat_ScreenToWindowCoords(IntPtr hwnd, ref int x, ref int y)
		{
			method global_Plat_ScreenToWindowCoords = EngineGlobal.__N.global_Plat_ScreenToWindowCoords;
			calli(System.Void(System.IntPtr,System.Int32&,System.Int32&), hwnd, ref x, ref y, global_Plat_ScreenToWindowCoords);
		}

		// Token: 0x06000E82 RID: 3714 RVA: 0x00019A88 File Offset: 0x00017C88
		internal static void Plat_WindowToScreenCoords(IntPtr hwnd, ref int x, ref int y)
		{
			method global_Plat_WindowToScreenCoords = EngineGlobal.__N.global_Plat_WindowToScreenCoords;
			calli(System.Void(System.IntPtr,System.Int32&,System.Int32&), hwnd, ref x, ref y, global_Plat_WindowToScreenCoords);
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x00019AA4 File Offset: 0x00017CA4
		internal static void Plat_MessageBox(string title, string message)
		{
			method global_Plat_MessageBox = EngineGlobal.__N.global_Plat_MessageBox;
			calli(System.Void(System.IntPtr,System.IntPtr), Interop.GetPointer(title), Interop.GetPointer(message), global_Plat_MessageBox);
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x00019ACC File Offset: 0x00017CCC
		internal static void SPROF_ENTER_SCOPE(IntPtr name, int r, int g, int b)
		{
			method global_SPROF_ENTER_SCOPE = EngineGlobal.__N.global_SPROF_ENTER_SCOPE;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32), name, r, g, b, global_SPROF_ENTER_SCOPE);
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x00019AE9 File Offset: 0x00017CE9
		internal static void SPROF_EXIT_SCOPE()
		{
			calli(System.Void(), EngineGlobal.__N.global_SPROF_EXIT_SCOPE);
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x06000E86 RID: 3718 RVA: 0x00019AF5 File Offset: 0x00017CF5
		// (set) Token: 0x06000E87 RID: 3719 RVA: 0x00019B06 File Offset: 0x00017D06
		internal static INetworkClientService g_pNetworkClientService
		{
			get
			{
				return EngineGlobal.__N.Get__global_g_pNetworkClientService();
			}
			set
			{
				EngineGlobal.__N.Set__global_g_pNetworkClientService(value);
			}
		}

		// Token: 0x0200039F RID: 927
		internal static class __N
		{
			// Token: 0x0400186E RID: 6254
			internal static method global_Plat_ScreenToWindowCoords;

			// Token: 0x0400186F RID: 6255
			internal static method global_Plat_WindowToScreenCoords;

			// Token: 0x04001870 RID: 6256
			internal static method global_Plat_MessageBox;

			// Token: 0x04001871 RID: 6257
			internal static method global_SPROF_ENTER_SCOPE;

			// Token: 0x04001872 RID: 6258
			internal static method global_SPROF_EXIT_SCOPE;

			// Token: 0x04001873 RID: 6259
			internal static EngineGlobal.__N._Get__global_g_pNetworkClientService Get__global_g_pNetworkClientService;

			// Token: 0x04001874 RID: 6260
			internal static EngineGlobal.__N._Set__global_g_pNetworkClientService Set__global_g_pNetworkClientService;

			// Token: 0x0200048B RID: 1163
			// (Invoke) Token: 0x060019DF RID: 6623
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr _Get__global_g_pNetworkClientService();

			// Token: 0x0200048C RID: 1164
			// (Invoke) Token: 0x060019E3 RID: 6627
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__global_g_pNetworkClientService(IntPtr val);
		}
	}
}
