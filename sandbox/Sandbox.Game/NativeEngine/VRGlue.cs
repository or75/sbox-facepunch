using System;
using OpenVR;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000024 RID: 36
	internal static class VRGlue
	{
		// Token: 0x060003A8 RID: 936 RVA: 0x000284EF File Offset: 0x000266EF
		internal static IVROverlay Overlay()
		{
			return calli(System.IntPtr(), VRGlue.__N.VRGlue_Overlay);
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x00028500 File Offset: 0x00026700
		internal static IVRInput Input()
		{
			return calli(System.IntPtr(), VRGlue.__N.VRGlue_Input);
		}

		// Token: 0x060003AA RID: 938 RVA: 0x00028514 File Offset: 0x00026714
		internal static VRTexture GetOpenVRTexture(ITexture texture)
		{
			method vrglue_GetOpenVRTexture = VRGlue.__N.VRGlue_GetOpenVRTexture;
			return calli(OpenVR.VRTexture(System.IntPtr), texture, vrglue_GetOpenVRTexture);
		}

		// Token: 0x060003AB RID: 939 RVA: 0x00028534 File Offset: 0x00026734
		internal static bool SetOpenVROverlayTexture(ulong handle, ITexture texture)
		{
			method vrglue_SetOpenVROverlayTexture = VRGlue.__N.VRGlue_SetOpenVROverlayTexture;
			return calli(System.Int32(System.UInt64,System.IntPtr), handle, texture, vrglue_SetOpenVROverlayTexture) > 0;
		}

		// Token: 0x060003AC RID: 940 RVA: 0x00028557 File Offset: 0x00026757
		internal static bool IsActive()
		{
			return calli(System.Int32(), VRGlue.__N.VRGlue_IsActive) > 0;
		}

		// Token: 0x060003AD RID: 941 RVA: 0x00028566 File Offset: 0x00026766
		internal static float GetWorldScale()
		{
			return calli(System.Single(), VRGlue.__N.VRGlue_GetWorldScale);
		}

		// Token: 0x060003AE RID: 942 RVA: 0x00028574 File Offset: 0x00026774
		internal static void SetWorldScale(float value)
		{
			method vrglue_SetWorldScale = VRGlue.__N.VRGlue_SetWorldScale;
			calli(System.Void(System.Single), value, vrglue_SetWorldScale);
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0002858E File Offset: 0x0002678E
		internal static Vector3 GetAnchorOffset()
		{
			return calli(Vector3(), VRGlue.__N.VRGlue_GetAnchorOffset);
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0002859C File Offset: 0x0002679C
		internal unsafe static void SetAnchorOffset(Vector3 vOffset)
		{
			method vrglue_SetAnchorOffset = VRGlue.__N.VRGlue_SetAnchorOffset;
			calli(System.Void(Vector3*), &vOffset, vrglue_SetAnchorOffset);
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x000285B8 File Offset: 0x000267B8
		internal static Angles GetAnchorAngles()
		{
			return calli(Angles(), VRGlue.__N.VRGlue_GetAnchorAngles);
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x000285C4 File Offset: 0x000267C4
		internal unsafe static void SetAnchorAngles(Angles qAngles)
		{
			method vrglue_SetAnchorAngles = VRGlue.__N.VRGlue_SetAnchorAngles;
			calli(System.Void(Angles*), &qAngles, vrglue_SetAnchorAngles);
		}

		// Token: 0x060003B3 RID: 947 RVA: 0x000285E0 File Offset: 0x000267E0
		internal static bool IsDashboardShowing()
		{
			return calli(System.Int32(), VRGlue.__N.VRGlue_IsDashboardShowing) > 0;
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x000285EF File Offset: 0x000267EF
		internal static bool IsSteamVRDrawingControllers()
		{
			return calli(System.Int32(), VRGlue.__N.VRGlue_IsSteamVRDrawingControllers) > 0;
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x000285FE File Offset: 0x000267FE
		internal static bool ShouldApplicationPause()
		{
			return calli(System.Int32(), VRGlue.__N.VRGlue_ShouldApplicationPause) > 0;
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x00028610 File Offset: 0x00026810
		internal static IModel GetModel(int index)
		{
			method vrglue_GetModel = VRGlue.__N.VRGlue_GetModel;
			return calli(System.IntPtr(System.Int32), index, vrglue_GetModel);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x00028630 File Offset: 0x00026830
		internal static string GetControllerTypeName(int index)
		{
			method vrglue_GetControllerTypeName = VRGlue.__N.VRGlue_GetControllerTypeName;
			return Interop.GetString(calli(System.IntPtr(System.Int32), index, vrglue_GetControllerTypeName));
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0002864F File Offset: 0x0002684F
		internal static bool IsLeftHandDominant()
		{
			return calli(System.Int32(), VRGlue.__N.VRGlue_IsLeftHandDominant) > 0;
		}

		// Token: 0x020001A9 RID: 425
		internal static class __N
		{
			// Token: 0x040009EF RID: 2543
			internal static method VRGlue_Overlay;

			// Token: 0x040009F0 RID: 2544
			internal static method VRGlue_Input;

			// Token: 0x040009F1 RID: 2545
			internal static method VRGlue_GetOpenVRTexture;

			// Token: 0x040009F2 RID: 2546
			internal static method VRGlue_SetOpenVROverlayTexture;

			// Token: 0x040009F3 RID: 2547
			internal static method VRGlue_IsActive;

			// Token: 0x040009F4 RID: 2548
			internal static method VRGlue_GetWorldScale;

			// Token: 0x040009F5 RID: 2549
			internal static method VRGlue_SetWorldScale;

			// Token: 0x040009F6 RID: 2550
			internal static method VRGlue_GetAnchorOffset;

			// Token: 0x040009F7 RID: 2551
			internal static method VRGlue_SetAnchorOffset;

			// Token: 0x040009F8 RID: 2552
			internal static method VRGlue_GetAnchorAngles;

			// Token: 0x040009F9 RID: 2553
			internal static method VRGlue_SetAnchorAngles;

			// Token: 0x040009FA RID: 2554
			internal static method VRGlue_IsDashboardShowing;

			// Token: 0x040009FB RID: 2555
			internal static method VRGlue_IsSteamVRDrawingControllers;

			// Token: 0x040009FC RID: 2556
			internal static method VRGlue_ShouldApplicationPause;

			// Token: 0x040009FD RID: 2557
			internal static method VRGlue_GetModel;

			// Token: 0x040009FE RID: 2558
			internal static method VRGlue_GetControllerTypeName;

			// Token: 0x040009FF RID: 2559
			internal static method VRGlue_IsLeftHandDominant;
		}
	}
}
