using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NativeEngine;

namespace Managed.SourceAssetSytem
{
	// Token: 0x0200006B RID: 107
	internal static class NativeInterop
	{
		// Token: 0x0600125E RID: 4702 RVA: 0x0004FFA8 File Offset: 0x0004E1A8
		private unsafe static void CheckStructSizes(int* struct_sizes)
		{
			string errors = "";
			int i = 0;
			if (234 != struct_sizes[i++])
			{
				errors += "Struct size header not found\n";
			}
			if (4 != struct_sizes[i++])
			{
				string str = errors;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 2);
				defaultInterpolatedStringHandler.AppendLiteral("M:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(4);
				defaultInterpolatedStringHandler.AppendLiteral("\tN:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(struct_sizes[i - 1]);
				defaultInterpolatedStringHandler.AppendLiteral("\tAssetLocation_t \n");
				errors = str + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (1 != struct_sizes[i++])
			{
				errors += "Struct size footer not found\n";
			}
			if (!string.IsNullOrEmpty(errors))
			{
				throw new Exception("Data structure size doesn't match:\n\n" + errors.Trim());
			}
		}

		// Token: 0x0600125F RID: 4703 RVA: 0x00050078 File Offset: 0x0004E278
		internal unsafe static void Initialize(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported)
		{
			int i = 0;
			NativeInterop._ErrorFunction onError = Marshal.GetDelegateForFunctionPointer<NativeInterop._ErrorFunction>(exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)]);
			try
			{
				if (hash != 55147)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Hash doesn't match ( ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(hash);
					defaultInterpolatedStringHandler.AppendLiteral(" != 55147 )");
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				NativeInterop.CheckStructSizes(struct_sizes);
				CUtlVectorAsset.__N.CUtlVe_DeleteThis = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlVectorAsset.__N.CUtlVe_Create = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlVectorAsset.__N.CUtlVe_Count = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				CUtlVectorAsset.__N.CUtlVe_Element = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_InitializePreviewSystem = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_ShowBuildThumbnailsDialog = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_RunPreviewFrame = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_GetThumbnailForAsset = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_IsLiveEmbeddedPreviewEnabled = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_SetLiveEmbeddedPreviewEnabled = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_GetEmbeddedPreviewBackgroundColor = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_SetEmbeddedPreviewBackgroundColor = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_ResetEmbeddedPreviewBackgroundColor = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_RefreshThumbnailForAsset = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_IsPreviewCameraLocked = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_SetPreviewCameraLocked = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_IsPreviewMenuEnabled = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_SetPreviewMenuEnabled = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetPreviewSystem.__N.gpAsse_UseIconForAsset = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetSystem.__N.gpAsse_FindAssetByFilename = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetSystem.__N.gpAsse_FindAssetByAssetRelativePath = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetSystem.__N.gpAsse_UpdateMods = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAssetSystem.__N.gpAsse_GetAllModsCount = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_GetFriendlyName_Transient = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_GetRelativePath_Transient = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_GetAbsolutePath_Transient = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_HasAnyFiles = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_IsCached = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_CanReload = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_GetAssetIndexInt = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_OpenInTool = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_GetAssetsIDependOn = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_GetAssetsIParent = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_GetAssetsIReference = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_GetAssetsDependingOnMe = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_GetAssetsReferencingMe = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				IAsset.__N.IAsset_GetAssetsParentingMe = (void*)exported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)];
				i = 0;
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Tools_AssetS_AssetAdded);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Tools_AssetS_AssetRemoved);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Tools_AssetS_AssetChanged);
				imported[(IntPtr)(i++) * (IntPtr)sizeof(IntPtr) / (IntPtr)sizeof(IntPtr)] = (IntPtr)ldftn(Tools_AssetS_AssetScanComplete);
			}
			catch (Exception ___e)
			{
				onError(___e.Message + "\n\n" + ___e.StackTrace);
			}
		}

		// Token: 0x0200012D RID: 301
		// (Invoke) Token: 0x060017D5 RID: 6101
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal delegate void _ErrorFunction(string message);
	}
}
