using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000048 RID: 72
	internal static class CSceneSystem
	{
		// Token: 0x0600095E RID: 2398 RVA: 0x00036D34 File Offset: 0x00034F34
		internal static void DeleteSceneObject(SceneObject pObj)
		{
			method gpScen_DeleteSceneObject = CSceneSystem.__N.gpScen_DeleteSceneObject;
			calli(System.Void(System.IntPtr), (pObj == null) ? IntPtr.Zero : pObj.native, gpScen_DeleteSceneObject);
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x00036D64 File Offset: 0x00034F64
		internal static void DeleteSceneObjectAtFrameEnd(SceneObject pObj)
		{
			method gpScen_DeleteSceneObjectAtFrameEnd = CSceneSystem.__N.gpScen_DeleteSceneObjectAtFrameEnd;
			calli(System.Void(System.IntPtr), (pObj == null) ? IntPtr.Zero : pObj.native, gpScen_DeleteSceneObjectAtFrameEnd);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00036D94 File Offset: 0x00034F94
		internal unsafe static Light CreateLight(LightDesc desc, SceneWorld pWorld, bool bIsStatic)
		{
			method gpScen_CreateLight = CSceneSystem.__N.gpScen_CreateLight;
			return HandleIndex.Get<Light>(calli(System.Int32(NativeEngine.LightDesc*,System.IntPtr,System.Int32), &desc, (pWorld == null) ? IntPtr.Zero : pWorld.native, bIsStatic ? 1 : 0, gpScen_CreateLight));
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00036DD4 File Offset: 0x00034FD4
		internal static SkyboxObject CreateSkyBox(IMaterial skyMaterial, SceneWorld world)
		{
			method gpScen_CreateSkyBox = CSceneSystem.__N.gpScen_CreateSkyBox;
			return HandleIndex.Get<SkyboxObject>(calli(System.Int32(System.IntPtr,System.IntPtr), skyMaterial, (world == null) ? IntPtr.Zero : world.native, gpScen_CreateSkyBox));
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x00036E10 File Offset: 0x00035010
		internal static void BeginRenderingDynamicView(ISceneView pView)
		{
			method gpScen_BeginRenderingDynamicView = CSceneSystem.__N.gpScen_BeginRenderingDynamicView;
			calli(System.Void(System.IntPtr), pView, gpScen_BeginRenderingDynamicView);
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x00036E30 File Offset: 0x00035030
		internal static ITexture GetWellKnownRenderTarget(SceneSystemWellKnownRenderTargetID a, SceneSystemRenderTargetSize b)
		{
			method gpScen_GetWellKnownRenderTarget = CSceneSystem.__N.gpScen_GetWellKnownRenderTarget;
			return calli(System.IntPtr(System.Int64,System.Int64), (long)a, (long)b, gpScen_GetWellKnownRenderTarget);
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x00036E54 File Offset: 0x00035054
		internal static ITexture GetWellKnownRenderTarget(SceneSystemWellKnownRenderTargetID nID, int nMinWidth, int nMinHeight)
		{
			method gpScen_f = CSceneSystem.__N.gpScen_f2;
			return calli(System.IntPtr(System.Int64,System.Int32,System.Int32), (long)nID, nMinWidth, nMinHeight, gpScen_f);
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x00036E78 File Offset: 0x00035078
		internal static ITexture GetWellKnownTexture(SceneSystemWellKnownTextureObjectID a)
		{
			method gpScen_GetWellKnownTexture = CSceneSystem.__N.gpScen_GetWellKnownTexture;
			return calli(System.IntPtr(System.Int64), (long)a, gpScen_GetWellKnownTexture);
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x00036E98 File Offset: 0x00035098
		internal static IMaterial GetWellKnownMaterialHandle(SceneSystemWellKnownMaterialObjectID a)
		{
			method gpScen_GetWellKnownMaterialHandle = CSceneSystem.__N.gpScen_GetWellKnownMaterialHandle;
			return calli(System.IntPtr(System.Int64), (long)a, gpScen_GetWellKnownMaterialHandle);
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x00036EB8 File Offset: 0x000350B8
		internal static void FinishRenderingViews()
		{
			calli(System.Void(), CSceneSystem.__N.gpScen_FinishRenderingViews);
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x00036EC4 File Offset: 0x000350C4
		internal static void WaitForRenderingToComplete()
		{
			calli(System.Void(), CSceneSystem.__N.gpScen_WaitForRenderingToComplete);
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x00036ED0 File Offset: 0x000350D0
		internal static bool IsWaitingOnRenderingJobs()
		{
			return calli(System.Int32(), CSceneSystem.__N.gpScen_IsWaitingOnRenderingJobs) > 0;
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x00036EDF File Offset: 0x000350DF
		internal static void FrameUpdate()
		{
			calli(System.Void(), CSceneSystem.__N.gpScen_FrameUpdate);
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x00036EEB File Offset: 0x000350EB
		internal static uint GetFinishRenderingViewsCounter()
		{
			return calli(System.UInt32(), CSceneSystem.__N.gpScen_GetFinishRenderingViewsCounter);
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x00036EF7 File Offset: 0x000350F7
		internal static bool ThreadIsInRenderingJob()
		{
			return calli(System.Int32(), CSceneSystem.__N.gpScen_ThreadIsInRenderingJob) > 0;
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x00036F06 File Offset: 0x00035106
		internal static float GetCurrentRenderTime()
		{
			return calli(System.Single(), CSceneSystem.__N.gpScen_GetCurrentRenderTime);
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00036F12 File Offset: 0x00035112
		internal static bool VolumetricFogEnabled()
		{
			return calli(System.Int32(), CSceneSystem.__N.gpScen_VolumetricFogEnabled) > 0;
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x00036F21 File Offset: 0x00035121
		internal static bool NonTexturedGradientFogEnabled()
		{
			return calli(System.Int32(), CSceneSystem.__N.gpScen_NonTexturedGradientFogEnabled) > 0;
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x00036F30 File Offset: 0x00035130
		internal static bool CubemapFogEnabled()
		{
			return calli(System.Int32(), CSceneSystem.__N.gpScen_CubemapFogEnabled) > 0;
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x00036F3F File Offset: 0x0003513F
		internal static bool CharacterDecalRendererEnabled()
		{
			return calli(System.Int32(), CSceneSystem.__N.gpScen_CharacterDecalRendererEnabled) > 0;
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x00036F4E File Offset: 0x0003514E
		internal static bool HDREnabled()
		{
			return calli(System.Int32(), CSceneSystem.__N.gpScen_HDREnabled) > 0;
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x00036F5D File Offset: 0x0003515D
		internal static bool UseMultiviewInstancing()
		{
			return calli(System.Int32(), CSceneSystem.__N.gpScen_UseMultiviewInstancing) > 0;
		}

		// Token: 0x020001CD RID: 461
		internal static class __N
		{
			// Token: 0x04000E85 RID: 3717
			internal static method gpScen_DeleteSceneObject;

			// Token: 0x04000E86 RID: 3718
			internal static method gpScen_DeleteSceneObjectAtFrameEnd;

			// Token: 0x04000E87 RID: 3719
			internal static method gpScen_CreateLight;

			// Token: 0x04000E88 RID: 3720
			internal static method gpScen_CreateSkyBox;

			// Token: 0x04000E89 RID: 3721
			internal static method gpScen_BeginRenderingDynamicView;

			// Token: 0x04000E8A RID: 3722
			internal static method gpScen_GetWellKnownRenderTarget;

			// Token: 0x04000E8B RID: 3723
			internal static method gpScen_f2;

			// Token: 0x04000E8C RID: 3724
			internal static method gpScen_GetWellKnownTexture;

			// Token: 0x04000E8D RID: 3725
			internal static method gpScen_GetWellKnownMaterialHandle;

			// Token: 0x04000E8E RID: 3726
			internal static method gpScen_FinishRenderingViews;

			// Token: 0x04000E8F RID: 3727
			internal static method gpScen_WaitForRenderingToComplete;

			// Token: 0x04000E90 RID: 3728
			internal static method gpScen_IsWaitingOnRenderingJobs;

			// Token: 0x04000E91 RID: 3729
			internal static method gpScen_FrameUpdate;

			// Token: 0x04000E92 RID: 3730
			internal static method gpScen_GetFinishRenderingViewsCounter;

			// Token: 0x04000E93 RID: 3731
			internal static method gpScen_ThreadIsInRenderingJob;

			// Token: 0x04000E94 RID: 3732
			internal static method gpScen_GetCurrentRenderTime;

			// Token: 0x04000E95 RID: 3733
			internal static method gpScen_VolumetricFogEnabled;

			// Token: 0x04000E96 RID: 3734
			internal static method gpScen_NonTexturedGradientFogEnabled;

			// Token: 0x04000E97 RID: 3735
			internal static method gpScen_CubemapFogEnabled;

			// Token: 0x04000E98 RID: 3736
			internal static method gpScen_CharacterDecalRendererEnabled;

			// Token: 0x04000E99 RID: 3737
			internal static method gpScen_HDREnabled;

			// Token: 0x04000E9A RID: 3738
			internal static method gpScen_UseMultiviewInstancing;
		}
	}
}
