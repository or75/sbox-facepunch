using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000023 RID: 35
	internal static class SboxRender
	{
		// Token: 0x06000394 RID: 916 RVA: 0x00028254 File Offset: 0x00026454
		internal static void DrawIndexed(IMaterial material, IntPtr vertices, int numVertices, IntPtr indices, int numIndices)
		{
			method sbxRen_DrawIndexed = SboxRender.__N.SbxRen_DrawIndexed;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32,System.IntPtr,System.Int32), material, vertices, numVertices, indices, numIndices, sbxRen_DrawIndexed);
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00028278 File Offset: 0x00026478
		internal static void Draw(IMaterial material, IntPtr vertices, int numVertices)
		{
			method sbxRen_Draw = SboxRender.__N.SbxRen_Draw;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), material, vertices, numVertices, sbxRen_Draw);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0002829C File Offset: 0x0002649C
		internal static void DrawScreenQuad(IMaterial material)
		{
			method sbxRen_DrawScreenQuad = SboxRender.__N.SbxRen_DrawScreenQuad;
			calli(System.Void(System.IntPtr), material, sbxRen_DrawScreenQuad);
		}

		// Token: 0x06000397 RID: 919 RVA: 0x000282BC File Offset: 0x000264BC
		internal static void DrawScreenQuadEx(IMaterial material, bool bUseFullUVSpace, CRenderAttributes attributes)
		{
			method sbxRen_DrawScreenQuadEx = SboxRender.__N.SbxRen_DrawScreenQuadEx;
			calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), material, bUseFullUVSpace ? 1 : 0, attributes, sbxRen_DrawScreenQuadEx);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x000282E8 File Offset: 0x000264E8
		internal static void SetZBufferMode(ZBufferMode mode)
		{
			method sbxRen_SetZBufferMode = SboxRender.__N.SbxRen_SetZBufferMode;
			calli(System.Void(System.Int64), (long)mode, sbxRen_SetZBufferMode);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00028304 File Offset: 0x00026504
		internal static void SetBlendMode(BlendMode mode)
		{
			method sbxRen_SetBlendMode = SboxRender.__N.SbxRen_SetBlendMode;
			calli(System.Void(System.Int64), (long)mode, sbxRen_SetBlendMode);
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00028320 File Offset: 0x00026520
		internal static void SetCullMode(CullMode mode)
		{
			method sbxRen_SetCullMode = SboxRender.__N.SbxRen_SetCullMode;
			calli(System.Void(System.Int64), (long)mode, sbxRen_SetCullMode);
		}

		// Token: 0x0600039B RID: 923 RVA: 0x0002833C File Offset: 0x0002653C
		internal static void SetLighting(SceneObject obj)
		{
			method sbxRen_SetLighting = SboxRender.__N.SbxRen_SetLighting;
			calli(System.Void(System.IntPtr), (obj == null) ? IntPtr.Zero : obj.native, sbxRen_SetLighting);
		}

		// Token: 0x0600039C RID: 924 RVA: 0x0002836C File Offset: 0x0002656C
		internal unsafe static void RenderScene(SceneWorld world, Transform cam, Vector4 rect, Vector4 ambientColor, Vector4 clearColor, float zNear, float zFar, bool bOrtho, ITexture colorTexture, ITexture depthTexture)
		{
			method sbxRen_RenderScene = SboxRender.__N.SbxRen_RenderScene;
			calli(System.Void(System.IntPtr,Transform*,Vector4*,Vector4*,Vector4*,System.Single,System.Single,System.Int32,System.IntPtr,System.IntPtr), (world == null) ? IntPtr.Zero : world.native, &cam, &rect, &ambientColor, &clearColor, zNear, zFar, bOrtho ? 1 : 0, colorTexture, depthTexture, sbxRen_RenderScene);
		}

		// Token: 0x0600039D RID: 925 RVA: 0x000283C0 File Offset: 0x000265C0
		internal static void GrabFrameBuffer(bool bCopyToHDR)
		{
			method sbxRen_GrabFrameBuffer = SboxRender.__N.SbxRen_GrabFrameBuffer;
			calli(System.Void(System.Int32), bCopyToHDR ? 1 : 0, sbxRen_GrabFrameBuffer);
		}

		// Token: 0x0600039E RID: 926 RVA: 0x000283E0 File Offset: 0x000265E0
		internal static void GrabDepthBuffer()
		{
			calli(System.Void(), SboxRender.__N.SbxRen_GrabDepthBuffer);
		}

		// Token: 0x0600039F RID: 927 RVA: 0x000283EC File Offset: 0x000265EC
		internal static void GrabViewportBuffer(bool bCopyToHDR)
		{
			method sbxRen_GrabViewportBuffer = SboxRender.__N.SbxRen_GrabViewportBuffer;
			calli(System.Void(System.Int32), bCopyToHDR ? 1 : 0, sbxRen_GrabViewportBuffer);
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x0002840C File Offset: 0x0002660C
		internal static void SetRenderTarget(ITexture texture)
		{
			method sbxRen_SetRenderTarget = SboxRender.__N.SbxRen_SetRenderTarget;
			calli(System.Void(System.IntPtr), texture, sbxRen_SetRenderTarget);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0002842C File Offset: 0x0002662C
		internal unsafe static void SetRenderTarget(RenderTargetDesc rtDesc)
		{
			method sbxRen_f = SboxRender.__N.SbxRen_f2;
			calli(System.Void(NativeEngine.RenderTargetDesc*), &rtDesc, sbxRen_f);
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00028448 File Offset: 0x00026648
		internal static void RestoreRenderTarget()
		{
			calli(System.Void(), SboxRender.__N.SbxRen_RestoreRenderTarget);
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x00028454 File Offset: 0x00026654
		internal static void SetViewport(int x, int y, int w, int h)
		{
			method sbxRen_SetViewport = SboxRender.__N.SbxRen_SetViewport;
			calli(System.Void(System.Int32,System.Int32,System.Int32,System.Int32), x, y, w, h, sbxRen_SetViewport);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x00028474 File Offset: 0x00026674
		internal static void HasPostProcessingLayers(bool bHasLayers)
		{
			method sbxRen_HasPostProcessingLayers = SboxRender.__N.SbxRen_HasPostProcessingLayers;
			calli(System.Void(System.Int32), bHasLayers ? 1 : 0, sbxRen_HasPostProcessingLayers);
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x00028494 File Offset: 0x00026694
		internal unsafe static void Clear(Vector4 col, bool clearColor, bool clearDepth)
		{
			method sbxRen_Clear = SboxRender.__N.SbxRen_Clear;
			calli(System.Void(Vector4*,System.Int32,System.Int32), &col, clearColor ? 1 : 0, clearDepth ? 1 : 0, sbxRen_Clear);
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x000284BE File Offset: 0x000266BE
		internal static CRenderAttributes CreateRenderAttributes()
		{
			return calli(System.IntPtr(), SboxRender.__N.SbxRen_CreateRenderAttributes);
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x000284D0 File Offset: 0x000266D0
		internal static void DeleteRenderAttributes(CRenderAttributes attr)
		{
			method sbxRen_DeleteRenderAttributes = SboxRender.__N.SbxRen_DeleteRenderAttributes;
			calli(System.Void(System.IntPtr), attr, sbxRen_DeleteRenderAttributes);
		}

		// Token: 0x020001A8 RID: 424
		internal static class __N
		{
			// Token: 0x040009DB RID: 2523
			internal static method SbxRen_DrawIndexed;

			// Token: 0x040009DC RID: 2524
			internal static method SbxRen_Draw;

			// Token: 0x040009DD RID: 2525
			internal static method SbxRen_DrawScreenQuad;

			// Token: 0x040009DE RID: 2526
			internal static method SbxRen_DrawScreenQuadEx;

			// Token: 0x040009DF RID: 2527
			internal static method SbxRen_SetZBufferMode;

			// Token: 0x040009E0 RID: 2528
			internal static method SbxRen_SetBlendMode;

			// Token: 0x040009E1 RID: 2529
			internal static method SbxRen_SetCullMode;

			// Token: 0x040009E2 RID: 2530
			internal static method SbxRen_SetLighting;

			// Token: 0x040009E3 RID: 2531
			internal static method SbxRen_RenderScene;

			// Token: 0x040009E4 RID: 2532
			internal static method SbxRen_GrabFrameBuffer;

			// Token: 0x040009E5 RID: 2533
			internal static method SbxRen_GrabDepthBuffer;

			// Token: 0x040009E6 RID: 2534
			internal static method SbxRen_GrabViewportBuffer;

			// Token: 0x040009E7 RID: 2535
			internal static method SbxRen_SetRenderTarget;

			// Token: 0x040009E8 RID: 2536
			internal static method SbxRen_f2;

			// Token: 0x040009E9 RID: 2537
			internal static method SbxRen_RestoreRenderTarget;

			// Token: 0x040009EA RID: 2538
			internal static method SbxRen_SetViewport;

			// Token: 0x040009EB RID: 2539
			internal static method SbxRen_HasPostProcessingLayers;

			// Token: 0x040009EC RID: 2540
			internal static method SbxRen_Clear;

			// Token: 0x040009ED RID: 2541
			internal static method SbxRen_CreateRenderAttributes;

			// Token: 0x040009EE RID: 2542
			internal static method SbxRen_DeleteRenderAttributes;
		}
	}
}
