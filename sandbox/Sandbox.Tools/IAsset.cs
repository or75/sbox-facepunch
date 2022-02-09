using System;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox;

// Token: 0x0200000A RID: 10
internal struct IAsset
{
	// Token: 0x0600001A RID: 26 RVA: 0x000024AC File Offset: 0x000006AC
	public static implicit operator IntPtr(global::IAsset value)
	{
		return value.self;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x000024B4 File Offset: 0x000006B4
	public static implicit operator global::IAsset(IntPtr value)
	{
		return new global::IAsset
		{
			self = value
		};
	}

	// Token: 0x0600001C RID: 28 RVA: 0x000024D2 File Offset: 0x000006D2
	public static bool operator ==(global::IAsset c1, global::IAsset c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x000024E5 File Offset: 0x000006E5
	public static bool operator !=(global::IAsset c1, global::IAsset c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600001E RID: 30 RVA: 0x000024F8 File Offset: 0x000006F8
	public override bool Equals(object obj)
	{
		if (obj is global::IAsset)
		{
			global::IAsset c = (global::IAsset)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600001F RID: 31 RVA: 0x00002522 File Offset: 0x00000722
	internal IAsset(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000020 RID: 32 RVA: 0x0000252C File Offset: 0x0000072C
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
		defaultInterpolatedStringHandler.AppendLiteral("IAsset ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000021 RID: 33 RVA: 0x00002567 File Offset: 0x00000767
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000022 RID: 34 RVA: 0x00002579 File Offset: 0x00000779
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000023 RID: 35 RVA: 0x00002584 File Offset: 0x00000784
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000024 RID: 36 RVA: 0x00002597 File Offset: 0x00000797
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("IAsset was null when calling " + n);
		}
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000025B2 File Offset: 0x000007B2
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000026 RID: 38 RVA: 0x000025C0 File Offset: 0x000007C0
	internal readonly string GetFriendlyName_Transient()
	{
		this.NullCheck("GetFriendlyName_Transient");
		method iasset_GetFriendlyName_Transient = global::IAsset.__N.IAsset_GetFriendlyName_Transient;
		return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, iasset_GetFriendlyName_Transient));
	}

	// Token: 0x06000027 RID: 39 RVA: 0x000025F0 File Offset: 0x000007F0
	internal readonly string GetRelativePath_Transient(AssetLocation_t source)
	{
		this.NullCheck("GetRelativePath_Transient");
		method iasset_GetRelativePath_Transient = global::IAsset.__N.IAsset_GetRelativePath_Transient;
		return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int64), this.self, (long)source, iasset_GetRelativePath_Transient));
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002624 File Offset: 0x00000824
	internal readonly string GetAbsolutePath_Transient(AssetLocation_t source)
	{
		this.NullCheck("GetAbsolutePath_Transient");
		method iasset_GetAbsolutePath_Transient = global::IAsset.__N.IAsset_GetAbsolutePath_Transient;
		return Interop.GetString(calli(System.IntPtr(System.IntPtr,System.Int64), this.self, (long)source, iasset_GetAbsolutePath_Transient));
	}

	// Token: 0x06000029 RID: 41 RVA: 0x00002658 File Offset: 0x00000858
	internal readonly bool HasAnyFiles()
	{
		this.NullCheck("HasAnyFiles");
		method iasset_HasAnyFiles = global::IAsset.__N.IAsset_HasAnyFiles;
		return calli(System.Int32(System.IntPtr), this.self, iasset_HasAnyFiles) > 0;
	}

	// Token: 0x0600002A RID: 42 RVA: 0x00002688 File Offset: 0x00000888
	internal readonly bool IsCached()
	{
		this.NullCheck("IsCached");
		method iasset_IsCached = global::IAsset.__N.IAsset_IsCached;
		return calli(System.Int32(System.IntPtr), this.self, iasset_IsCached) > 0;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000026B8 File Offset: 0x000008B8
	internal readonly bool CanReload()
	{
		this.NullCheck("CanReload");
		method iasset_CanReload = global::IAsset.__N.IAsset_CanReload;
		return calli(System.Int32(System.IntPtr), this.self, iasset_CanReload) > 0;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x000026E8 File Offset: 0x000008E8
	internal readonly uint GetAssetIndexInt()
	{
		this.NullCheck("GetAssetIndexInt");
		method iasset_GetAssetIndexInt = global::IAsset.__N.IAsset_GetAssetIndexInt;
		return calli(System.UInt32(System.IntPtr), this.self, iasset_GetAssetIndexInt);
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002714 File Offset: 0x00000914
	internal readonly bool OpenInTool()
	{
		this.NullCheck("OpenInTool");
		method iasset_OpenInTool = global::IAsset.__N.IAsset_OpenInTool;
		return calli(System.Int32(System.IntPtr), this.self, iasset_OpenInTool) > 0;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002744 File Offset: 0x00000944
	internal readonly void GetAssetsIDependOn(CUtlVectorAsset pOutAssetsIDependOn, bool bDeep)
	{
		this.NullCheck("GetAssetsIDependOn");
		method iasset_GetAssetsIDependOn = global::IAsset.__N.IAsset_GetAssetsIDependOn;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pOutAssetsIDependOn, bDeep ? 1 : 0, iasset_GetAssetsIDependOn);
	}

	// Token: 0x0600002F RID: 47 RVA: 0x0000277C File Offset: 0x0000097C
	internal readonly void GetAssetsIParent(CUtlVectorAsset pOutChildren, bool bDeep)
	{
		this.NullCheck("GetAssetsIParent");
		method iasset_GetAssetsIParent = global::IAsset.__N.IAsset_GetAssetsIParent;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pOutChildren, bDeep ? 1 : 0, iasset_GetAssetsIParent);
	}

	// Token: 0x06000030 RID: 48 RVA: 0x000027B4 File Offset: 0x000009B4
	internal readonly void GetAssetsIReference(CUtlVectorAsset pOutReferencers, bool bDeep)
	{
		this.NullCheck("GetAssetsIReference");
		method iasset_GetAssetsIReference = global::IAsset.__N.IAsset_GetAssetsIReference;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pOutReferencers, bDeep ? 1 : 0, iasset_GetAssetsIReference);
	}

	// Token: 0x06000031 RID: 49 RVA: 0x000027EC File Offset: 0x000009EC
	internal readonly void GetAssetsDependingOnMe(CUtlVectorAsset pOutDependencies, bool bDeep)
	{
		this.NullCheck("GetAssetsDependingOnMe");
		method iasset_GetAssetsDependingOnMe = global::IAsset.__N.IAsset_GetAssetsDependingOnMe;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pOutDependencies, bDeep ? 1 : 0, iasset_GetAssetsDependingOnMe);
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00002824 File Offset: 0x00000A24
	internal readonly void GetAssetsReferencingMe(CUtlVectorAsset pOutReferencers, bool bDeep)
	{
		this.NullCheck("GetAssetsReferencingMe");
		method iasset_GetAssetsReferencingMe = global::IAsset.__N.IAsset_GetAssetsReferencingMe;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pOutReferencers, bDeep ? 1 : 0, iasset_GetAssetsReferencingMe);
	}

	// Token: 0x06000033 RID: 51 RVA: 0x0000285C File Offset: 0x00000A5C
	internal readonly void GetAssetsParentingMe(CUtlVectorAsset pOutParents, bool bDeep)
	{
		this.NullCheck("GetAssetsParentingMe");
		method iasset_GetAssetsParentingMe = global::IAsset.__N.IAsset_GetAssetsParentingMe;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pOutParents, bDeep ? 1 : 0, iasset_GetAssetsParentingMe);
	}

	// Token: 0x04000007 RID: 7
	internal IntPtr self;

	// Token: 0x020000DB RID: 219
	internal static class __N
	{
		// Token: 0x040004F9 RID: 1273
		internal static method IAsset_GetFriendlyName_Transient;

		// Token: 0x040004FA RID: 1274
		internal static method IAsset_GetRelativePath_Transient;

		// Token: 0x040004FB RID: 1275
		internal static method IAsset_GetAbsolutePath_Transient;

		// Token: 0x040004FC RID: 1276
		internal static method IAsset_HasAnyFiles;

		// Token: 0x040004FD RID: 1277
		internal static method IAsset_IsCached;

		// Token: 0x040004FE RID: 1278
		internal static method IAsset_CanReload;

		// Token: 0x040004FF RID: 1279
		internal static method IAsset_GetAssetIndexInt;

		// Token: 0x04000500 RID: 1280
		internal static method IAsset_OpenInTool;

		// Token: 0x04000501 RID: 1281
		internal static method IAsset_GetAssetsIDependOn;

		// Token: 0x04000502 RID: 1282
		internal static method IAsset_GetAssetsIParent;

		// Token: 0x04000503 RID: 1283
		internal static method IAsset_GetAssetsIReference;

		// Token: 0x04000504 RID: 1284
		internal static method IAsset_GetAssetsDependingOnMe;

		// Token: 0x04000505 RID: 1285
		internal static method IAsset_GetAssetsReferencingMe;

		// Token: 0x04000506 RID: 1286
		internal static method IAsset_GetAssetsParentingMe;
	}
}
