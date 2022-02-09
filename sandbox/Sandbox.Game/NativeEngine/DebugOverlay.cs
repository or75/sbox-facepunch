using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200003D RID: 61
	internal static class DebugOverlay
	{
		// Token: 0x0600092D RID: 2349 RVA: 0x000366C4 File Offset: 0x000348C4
		internal unsafe static void Line(Vector3 vEndPoint0, Vector3 vEndPoint1, Color32 color, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_Line = DebugOverlay.__N.debgve_Line;
			calli(System.Void(Vector3*,Vector3*,Color32,System.Int32,System.Single), &vEndPoint0, &vEndPoint1, color, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_Line);
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x000366F0 File Offset: 0x000348F0
		internal unsafe static void Box(Vector3 vWorldMins, Vector3 vWorldMaxs, Color32 color, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_Box = DebugOverlay.__N.debgve_Box;
			calli(System.Void(Vector3*,Vector3*,Color32,System.Int32,System.Single), &vWorldMins, &vWorldMaxs, color, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_Box);
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x0003671C File Offset: 0x0003491C
		internal unsafe static void BoxAngles(Vector3 vOrigin, Vector3 vLocalMins, Vector3 vLocalMaxs, Rotation vOrientation, int r, int g, int b, int a, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_BoxAngles = DebugOverlay.__N.debgve_BoxAngles;
			calli(System.Void(Vector3*,Vector3*,Vector3*,Rotation*,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Single), &vOrigin, &vLocalMins, &vLocalMaxs, &vOrientation, r, g, b, a, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_BoxAngles);
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00036754 File Offset: 0x00034954
		internal unsafe static void SolidBoxAngles(Vector3 vOrigin, Vector3 vLocalMins, Vector3 vLocalMaxs, Rotation vOrientation, Color32 color, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_SolidBoxAngles = DebugOverlay.__N.debgve_SolidBoxAngles;
			calli(System.Void(Vector3*,Vector3*,Vector3*,Rotation*,Color32,System.Int32,System.Single), &vOrigin, &vLocalMins, &vLocalMaxs, &vOrientation, color, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_SolidBoxAngles);
		}

		// Token: 0x06000931 RID: 2353 RVA: 0x00036788 File Offset: 0x00034988
		internal unsafe static void Sphere(Vector3 vCenter, float flRadius, Color32 vecColor, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_Sphere = DebugOverlay.__N.debgve_Sphere;
			calli(System.Void(Vector3*,System.Single,Color32,System.Int32,System.Single), &vCenter, flRadius, vecColor, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_Sphere);
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x000367B0 File Offset: 0x000349B0
		internal unsafe static void Capsule(Vector3 vCenter1, Vector3 vCenter2, float flRadius, Color32 vecColor, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_Capsule = DebugOverlay.__N.debgve_Capsule;
			calli(System.Void(Vector3*,Vector3*,System.Single,Color32,System.Int32,System.Single), &vCenter1, &vCenter2, flRadius, vecColor, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_Capsule);
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x000367DC File Offset: 0x000349DC
		internal unsafe static void VectorText3D(Vector3 vPos, Vector3 vUp, Vector3 vLeft, string pStr, Color32 vColor, bool bCenter, float flTimeToLive)
		{
			method debgve_VectorText3D = DebugOverlay.__N.debgve_VectorText3D;
			calli(System.Void(Vector3*,Vector3*,Vector3*,System.IntPtr,Color32,System.Int32,System.Single), &vPos, &vUp, &vLeft, Interop.GetPointer(pStr), vColor, bCenter ? 1 : 0, flTimeToLive, debgve_VectorText3D);
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00036810 File Offset: 0x00034A10
		internal unsafe static void Text(Vector3 vOrigin, int nTextLineOffsetY, string pText, float flMaxDistToDisplay, Color32 c, float flTimeToLive)
		{
			method debgve_Text = DebugOverlay.__N.debgve_Text;
			calli(System.Void(Vector3*,System.Int32,System.IntPtr,System.Single,Color32,System.Single), &vOrigin, nTextLineOffsetY, Interop.GetPointer(pText), flMaxDistToDisplay, c, flTimeToLive, debgve_Text);
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00036838 File Offset: 0x00034A38
		internal static void ScreenTextOffset(float fXpos, float fYpos, int nTextLineOffsetY, string pText, int r, int g, int b, int a, float flTimeToLive)
		{
			method debgve_ScreenTextOffset = DebugOverlay.__N.debgve_ScreenTextOffset;
			calli(System.Void(System.Single,System.Single,System.Int32,System.IntPtr,System.Int32,System.Int32,System.Int32,System.Int32,System.Single), fXpos, fYpos, nTextLineOffsetY, Interop.GetPointer(pText), r, g, b, a, flTimeToLive, debgve_ScreenTextOffset);
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00036864 File Offset: 0x00034A64
		internal unsafe static void Axis(Vector3 vPosition, Rotation q, float flAxisLen, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_Axis = DebugOverlay.__N.debgve_Axis;
			calli(System.Void(Vector3*,Rotation*,System.Single,System.Int32,System.Single), &vPosition, &q, flAxisLen, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_Axis);
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00036890 File Offset: 0x00034A90
		internal unsafe static void Cross(Vector3 vPosition, float radius, Color32 color, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_Cross = DebugOverlay.__N.debgve_Cross;
			calli(System.Void(Vector3*,System.Single,Color32,System.Int32,System.Single), &vPosition, radius, color, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_Cross);
		}

		// Token: 0x06000938 RID: 2360 RVA: 0x000368B8 File Offset: 0x00034AB8
		internal unsafe static void Cross3D(Vector3 vPosition, Vector3 mins, Vector3 maxs, Color32 color, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_Cross3D = DebugOverlay.__N.debgve_Cross3D;
			calli(System.Void(Vector3*,Vector3*,Vector3*,Color32,System.Int32,System.Single), &vPosition, &mins, &maxs, color, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_Cross3D);
		}

		// Token: 0x06000939 RID: 2361 RVA: 0x000368E8 File Offset: 0x00034AE8
		internal unsafe static void Triangle(Vector3 p1, Vector3 p2, Vector3 p3, Color32 color, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_Triangle = DebugOverlay.__N.debgve_Triangle;
			calli(System.Void(Vector3*,Vector3*,Vector3*,Color32,System.Int32,System.Single), &p1, &p2, &p3, color, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_Triangle);
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x00036918 File Offset: 0x00034B18
		internal unsafe static void Circle(Vector3 vPosition, float radius, Color32 color, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_Circle = DebugOverlay.__N.debgve_Circle;
			calli(System.Void(Vector3*,System.Single,Color32,System.Int32,System.Single), &vPosition, radius, color, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_Circle);
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00036940 File Offset: 0x00034B40
		internal unsafe static void Circle(Vector3 vPosition, Rotation orientation, float radius, int r, int g, int b, int a, bool bNoDepthTest, float flTimeToLive)
		{
			method debgve_f = DebugOverlay.__N.debgve_f2;
			calli(System.Void(Vector3*,Rotation*,System.Single,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Single), &vPosition, &orientation, radius, r, g, b, a, bNoDepthTest ? 1 : 0, flTimeToLive, debgve_f);
		}

		// Token: 0x020001C2 RID: 450
		internal static class __N
		{
			// Token: 0x04000E54 RID: 3668
			internal static method debgve_Line;

			// Token: 0x04000E55 RID: 3669
			internal static method debgve_Box;

			// Token: 0x04000E56 RID: 3670
			internal static method debgve_BoxAngles;

			// Token: 0x04000E57 RID: 3671
			internal static method debgve_SolidBoxAngles;

			// Token: 0x04000E58 RID: 3672
			internal static method debgve_Sphere;

			// Token: 0x04000E59 RID: 3673
			internal static method debgve_Capsule;

			// Token: 0x04000E5A RID: 3674
			internal static method debgve_VectorText3D;

			// Token: 0x04000E5B RID: 3675
			internal static method debgve_Text;

			// Token: 0x04000E5C RID: 3676
			internal static method debgve_ScreenTextOffset;

			// Token: 0x04000E5D RID: 3677
			internal static method debgve_Axis;

			// Token: 0x04000E5E RID: 3678
			internal static method debgve_Cross;

			// Token: 0x04000E5F RID: 3679
			internal static method debgve_Cross3D;

			// Token: 0x04000E60 RID: 3680
			internal static method debgve_Triangle;

			// Token: 0x04000E61 RID: 3681
			internal static method debgve_Circle;

			// Token: 0x04000E62 RID: 3682
			internal static method debgve_f2;
		}
	}
}
