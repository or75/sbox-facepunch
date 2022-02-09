using System;
using Native;

// Token: 0x02000008 RID: 8
internal static class IAssetPreviewSystem
{
	// Token: 0x06000007 RID: 7 RVA: 0x000022D4 File Offset: 0x000004D4
	internal static void InitializePreviewSystem(bool bLoadCachedThumbnails)
	{
		method gpAsse_InitializePreviewSystem = IAssetPreviewSystem.__N.gpAsse_InitializePreviewSystem;
		calli(System.Void(System.Int32), bLoadCachedThumbnails ? 1 : 0, gpAsse_InitializePreviewSystem);
	}

	// Token: 0x06000008 RID: 8 RVA: 0x000022F4 File Offset: 0x000004F4
	internal static void ShowBuildThumbnailsDialog()
	{
		calli(System.Void(), IAssetPreviewSystem.__N.gpAsse_ShowBuildThumbnailsDialog);
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002300 File Offset: 0x00000500
	internal static void RunPreviewFrame()
	{
		calli(System.Void(), IAssetPreviewSystem.__N.gpAsse_RunPreviewFrame);
	}

	// Token: 0x0600000A RID: 10 RVA: 0x0000230C File Offset: 0x0000050C
	internal static bool GetThumbnailForAsset(IAsset pAsset, QPixmap pOutPixmap, bool allowGenerate)
	{
		method gpAsse_GetThumbnailForAsset = IAssetPreviewSystem.__N.gpAsse_GetThumbnailForAsset;
		return calli(System.Int32(System.IntPtr,System.IntPtr,System.Int32), pAsset, pOutPixmap, allowGenerate ? 1 : 0, gpAsse_GetThumbnailForAsset) > 0;
	}

	// Token: 0x0600000B RID: 11 RVA: 0x0000233B File Offset: 0x0000053B
	internal static bool IsLiveEmbeddedPreviewEnabled()
	{
		return calli(System.Int32(), IAssetPreviewSystem.__N.gpAsse_IsLiveEmbeddedPreviewEnabled) > 0;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x0000234C File Offset: 0x0000054C
	internal static void SetLiveEmbeddedPreviewEnabled(bool bEnable)
	{
		method gpAsse_SetLiveEmbeddedPreviewEnabled = IAssetPreviewSystem.__N.gpAsse_SetLiveEmbeddedPreviewEnabled;
		calli(System.Void(System.Int32), bEnable ? 1 : 0, gpAsse_SetLiveEmbeddedPreviewEnabled);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x0000236C File Offset: 0x0000056C
	internal static Color32 GetEmbeddedPreviewBackgroundColor()
	{
		return calli(Color32(), IAssetPreviewSystem.__N.gpAsse_GetEmbeddedPreviewBackgroundColor);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x00002378 File Offset: 0x00000578
	internal static void SetEmbeddedPreviewBackgroundColor(Color32 c, bool bDirtyThumbnails)
	{
		method gpAsse_SetEmbeddedPreviewBackgroundColor = IAssetPreviewSystem.__N.gpAsse_SetEmbeddedPreviewBackgroundColor;
		calli(System.Void(Color32,System.Int32), c, bDirtyThumbnails ? 1 : 0, gpAsse_SetEmbeddedPreviewBackgroundColor);
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002399 File Offset: 0x00000599
	internal static void ResetEmbeddedPreviewBackgroundColor()
	{
		calli(System.Void(), IAssetPreviewSystem.__N.gpAsse_ResetEmbeddedPreviewBackgroundColor);
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000023A8 File Offset: 0x000005A8
	internal static void RefreshThumbnailForAsset(IAsset pAsset)
	{
		method gpAsse_RefreshThumbnailForAsset = IAssetPreviewSystem.__N.gpAsse_RefreshThumbnailForAsset;
		calli(System.Void(System.IntPtr), pAsset, gpAsse_RefreshThumbnailForAsset);
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000023C7 File Offset: 0x000005C7
	internal static bool IsPreviewCameraLocked()
	{
		return calli(System.Int32(), IAssetPreviewSystem.__N.gpAsse_IsPreviewCameraLocked) > 0;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000023D8 File Offset: 0x000005D8
	internal static void SetPreviewCameraLocked(bool bEnable)
	{
		method gpAsse_SetPreviewCameraLocked = IAssetPreviewSystem.__N.gpAsse_SetPreviewCameraLocked;
		calli(System.Void(System.Int32), bEnable ? 1 : 0, gpAsse_SetPreviewCameraLocked);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000023F8 File Offset: 0x000005F8
	internal static bool IsPreviewMenuEnabled()
	{
		return calli(System.Int32(), IAssetPreviewSystem.__N.gpAsse_IsPreviewMenuEnabled) > 0;
	}

	// Token: 0x06000014 RID: 20 RVA: 0x00002408 File Offset: 0x00000608
	internal static void SetPreviewMenuEnabled(bool bEnable)
	{
		method gpAsse_SetPreviewMenuEnabled = IAssetPreviewSystem.__N.gpAsse_SetPreviewMenuEnabled;
		calli(System.Void(System.Int32), bEnable ? 1 : 0, gpAsse_SetPreviewMenuEnabled);
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002428 File Offset: 0x00000628
	internal static bool UseIconForAsset(IAsset pAsset)
	{
		method gpAsse_UseIconForAsset = IAssetPreviewSystem.__N.gpAsse_UseIconForAsset;
		return calli(System.Int32(System.IntPtr), pAsset, gpAsse_UseIconForAsset) > 0;
	}

	// Token: 0x020000D9 RID: 217
	internal static class __N
	{
		// Token: 0x040004E6 RID: 1254
		internal static method gpAsse_InitializePreviewSystem;

		// Token: 0x040004E7 RID: 1255
		internal static method gpAsse_ShowBuildThumbnailsDialog;

		// Token: 0x040004E8 RID: 1256
		internal static method gpAsse_RunPreviewFrame;

		// Token: 0x040004E9 RID: 1257
		internal static method gpAsse_GetThumbnailForAsset;

		// Token: 0x040004EA RID: 1258
		internal static method gpAsse_IsLiveEmbeddedPreviewEnabled;

		// Token: 0x040004EB RID: 1259
		internal static method gpAsse_SetLiveEmbeddedPreviewEnabled;

		// Token: 0x040004EC RID: 1260
		internal static method gpAsse_GetEmbeddedPreviewBackgroundColor;

		// Token: 0x040004ED RID: 1261
		internal static method gpAsse_SetEmbeddedPreviewBackgroundColor;

		// Token: 0x040004EE RID: 1262
		internal static method gpAsse_ResetEmbeddedPreviewBackgroundColor;

		// Token: 0x040004EF RID: 1263
		internal static method gpAsse_RefreshThumbnailForAsset;

		// Token: 0x040004F0 RID: 1264
		internal static method gpAsse_IsPreviewCameraLocked;

		// Token: 0x040004F1 RID: 1265
		internal static method gpAsse_SetPreviewCameraLocked;

		// Token: 0x040004F2 RID: 1266
		internal static method gpAsse_IsPreviewMenuEnabled;

		// Token: 0x040004F3 RID: 1267
		internal static method gpAsse_SetPreviewMenuEnabled;

		// Token: 0x040004F4 RID: 1268
		internal static method gpAsse_UseIconForAsset;
	}
}
