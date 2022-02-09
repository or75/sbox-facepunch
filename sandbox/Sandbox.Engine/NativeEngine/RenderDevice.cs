using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000235 RID: 565
	internal static class RenderDevice
	{
		// Token: 0x06000E6E RID: 3694 RVA: 0x00019810 File Offset: 0x00017A10
		internal static ITexture FindOrCreateFileTexture(string pFileName, RenderSystemAssetFileLoadMode nLoadMode)
		{
			method gpRend_FindOrCreateFileTexture = RenderDevice.__N.gpRend_FindOrCreateFileTexture;
			return calli(System.IntPtr(System.IntPtr,System.Int64), Interop.GetPointer(pFileName), (long)nLoadMode, gpRend_FindOrCreateFileTexture);
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x00019838 File Offset: 0x00017A38
		internal unsafe static ITexture FindOrCreateTexture2(string pResourceName, bool bIsAnonymous, TextureBuilder pDescriptor, IntPtr data, int dataSize)
		{
			method gpRend_FindOrCreateTexture = RenderDevice.__N.gpRend_FindOrCreateTexture2;
			return calli(System.IntPtr(System.IntPtr,System.Int32,Sandbox.TextureBuilder*,System.IntPtr,System.Int32), Interop.GetPointer(pResourceName), bIsAnonymous ? 1 : 0, &pDescriptor, data, dataSize, gpRend_FindOrCreateTexture);
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x0001986C File Offset: 0x00017A6C
		internal unsafe static void AsyncSetTextureData2(ITexture hTexture, IntPtr pData, int nDataSize, Rect3D rect)
		{
			method gpRend_AsyncSetTextureData = RenderDevice.__N.gpRend_AsyncSetTextureData2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32,Rect3D*), hTexture, pData, nDataSize, &rect, gpRend_AsyncSetTextureData);
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x00019890 File Offset: 0x00017A90
		internal unsafe static ITexture GetSwapChainTexture(SwapChainHandle swapChain, SwapChainBuffer bufferType)
		{
			method gpRend_GetSwapChainTexture = RenderDevice.__N.gpRend_GetSwapChainTexture;
			return calli(System.IntPtr(NativeEngine.SwapChainHandle*,System.Int64), &swapChain, (long)bufferType, gpRend_GetSwapChainTexture);
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x000198B4 File Offset: 0x00017AB4
		internal unsafe static CTextureDesc GetTextureDesc(ITexture hTexture)
		{
			method gpRend_GetTextureDesc = RenderDevice.__N.gpRend_GetTextureDesc;
			return *Unsafe.AsRef<CTextureDesc>((void*)calli(System.IntPtr(System.IntPtr), hTexture, gpRend_GetTextureDesc));
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x000198E4 File Offset: 0x00017AE4
		internal unsafe static CTextureDesc GetOnDiskTextureDesc(ITexture hTexture)
		{
			method gpRend_GetOnDiskTextureDesc = RenderDevice.__N.gpRend_GetOnDiskTextureDesc;
			return *Unsafe.AsRef<CTextureDesc>((void*)calli(System.IntPtr(System.IntPtr), hTexture, gpRend_GetOnDiskTextureDesc));
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x00019914 File Offset: 0x00017B14
		internal static RenderMultisampleType GetTextureMultisampleType(ITexture hTexture)
		{
			method gpRend_GetTextureMultisampleType = RenderDevice.__N.gpRend_GetTextureMultisampleType;
			return calli(System.Int64(System.IntPtr), hTexture, gpRend_GetTextureMultisampleType);
		}

		// Token: 0x0200039A RID: 922
		internal static class __N
		{
			// Token: 0x0400185B RID: 6235
			internal static method gpRend_FindOrCreateFileTexture;

			// Token: 0x0400185C RID: 6236
			internal static method gpRend_FindOrCreateTexture2;

			// Token: 0x0400185D RID: 6237
			internal static method gpRend_AsyncSetTextureData2;

			// Token: 0x0400185E RID: 6238
			internal static method gpRend_GetSwapChainTexture;

			// Token: 0x0400185F RID: 6239
			internal static method gpRend_GetTextureDesc;

			// Token: 0x04001860 RID: 6240
			internal static method gpRend_GetOnDiskTextureDesc;

			// Token: 0x04001861 RID: 6241
			internal static method gpRend_GetTextureMultisampleType;
		}
	}
}
