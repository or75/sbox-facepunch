using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200023C RID: 572
	internal static class RenderDeviceManager
	{
		// Token: 0x06000E8D RID: 3725 RVA: 0x00019BAC File Offset: 0x00017DAC
		internal static int GetConfigInt(string name)
		{
			method glue_Render_GetConfigInt = RenderDeviceManager.__N.Glue_Render_GetConfigInt;
			return calli(System.Int32(System.IntPtr), Interop.GetPointer(name), glue_Render_GetConfigInt);
		}

		// Token: 0x06000E8E RID: 3726 RVA: 0x00019BCC File Offset: 0x00017DCC
		internal static void SetConfigInt(string name, int val)
		{
			method glue_Render_SetConfigInt = RenderDeviceManager.__N.Glue_Render_SetConfigInt;
			calli(System.Void(System.IntPtr,System.Int32), Interop.GetPointer(name), val, glue_Render_SetConfigInt);
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x00019BEC File Offset: 0x00017DEC
		internal static void WriteVideoConfig()
		{
			calli(System.Void(), RenderDeviceManager.__N.Glue_Render_WriteVideoConfig);
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x00019BF8 File Offset: 0x00017DF8
		internal static void ResetVideoConfig()
		{
			calli(System.Void(), RenderDeviceManager.__N.Glue_Render_ResetVideoConfig);
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x00019C04 File Offset: 0x00017E04
		internal static void ChangeVideoMode(bool fullscreen, bool noborder, bool vsync, int width, int height)
		{
			method glue_Render_ChangeVideoMode = RenderDeviceManager.__N.Glue_Render_ChangeVideoMode;
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32), fullscreen ? 1 : 0, noborder ? 1 : 0, vsync ? 1 : 0, width, height, glue_Render_ChangeVideoMode);
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x00019C38 File Offset: 0x00017E38
		internal unsafe static int GetDisplayModes(VideoDisplayMode[] ArrayOfmodes, int max, bool windowed)
		{
			if (ArrayOfmodes == null)
			{
				VideoDisplayMode* ArrayOfmodes_array_ptr = null;
				method glue_Render_GetDisplayModes = RenderDeviceManager.__N.Glue_Render_GetDisplayModes;
				return calli(System.Int32(Sandbox.VideoDisplayMode*,System.Int32,System.Int32), ArrayOfmodes_array_ptr, max, windowed ? 1 : 0, glue_Render_GetDisplayModes);
			}
			fixed (VideoDisplayMode* ptr = &ArrayOfmodes[0])
			{
				VideoDisplayMode* ArrayOfmodes_array_ptr2 = ptr;
				method glue_Render_GetDisplayModes = RenderDeviceManager.__N.Glue_Render_GetDisplayModes;
				return calli(System.Int32(Sandbox.VideoDisplayMode*,System.Int32,System.Int32), ArrayOfmodes_array_ptr2, max, windowed ? 1 : 0, glue_Render_GetDisplayModes);
			}
		}

		// Token: 0x020003A1 RID: 929
		internal static class __N
		{
			// Token: 0x0400187A RID: 6266
			internal static method Glue_Render_GetConfigInt;

			// Token: 0x0400187B RID: 6267
			internal static method Glue_Render_SetConfigInt;

			// Token: 0x0400187C RID: 6268
			internal static method Glue_Render_WriteVideoConfig;

			// Token: 0x0400187D RID: 6269
			internal static method Glue_Render_ResetVideoConfig;

			// Token: 0x0400187E RID: 6270
			internal static method Glue_Render_ChangeVideoMode;

			// Token: 0x0400187F RID: 6271
			internal static method Glue_Render_GetDisplayModes;
		}
	}
}
