using System;
using Sandbox;

// Token: 0x02000009 RID: 9
internal static class IAssetSystem
{
	// Token: 0x06000016 RID: 22 RVA: 0x0000244C File Offset: 0x0000064C
	internal static global::IAsset FindAssetByFilename(string pFilename)
	{
		method gpAsse_FindAssetByFilename = IAssetSystem.__N.gpAsse_FindAssetByFilename;
		return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(pFilename), gpAsse_FindAssetByFilename);
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002470 File Offset: 0x00000670
	internal static global::IAsset FindAssetByAssetRelativePath(string pFilename)
	{
		method gpAsse_FindAssetByAssetRelativePath = IAssetSystem.__N.gpAsse_FindAssetByAssetRelativePath;
		return calli(System.IntPtr(System.IntPtr), Interop.GetPointer(pFilename), gpAsse_FindAssetByAssetRelativePath);
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002494 File Offset: 0x00000694
	internal static void UpdateMods()
	{
		calli(System.Void(), IAssetSystem.__N.gpAsse_UpdateMods);
	}

	// Token: 0x06000019 RID: 25 RVA: 0x000024A0 File Offset: 0x000006A0
	internal static int GetAllModsCount()
	{
		return calli(System.Int32(), IAssetSystem.__N.gpAsse_GetAllModsCount);
	}

	// Token: 0x020000DA RID: 218
	internal static class __N
	{
		// Token: 0x040004F5 RID: 1269
		internal static method gpAsse_FindAssetByFilename;

		// Token: 0x040004F6 RID: 1270
		internal static method gpAsse_FindAssetByAssetRelativePath;

		// Token: 0x040004F7 RID: 1271
		internal static method gpAsse_UpdateMods;

		// Token: 0x040004F8 RID: 1272
		internal static method gpAsse_GetAllModsCount;
	}
}
