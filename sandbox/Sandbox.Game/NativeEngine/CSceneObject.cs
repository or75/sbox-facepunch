using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000035 RID: 53
	internal struct CSceneObject
	{
		// Token: 0x06000801 RID: 2049 RVA: 0x00033909 File Offset: 0x00031B09
		public static implicit operator IntPtr(CSceneObject value)
		{
			return value.self;
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x00033914 File Offset: 0x00031B14
		public static implicit operator CSceneObject(IntPtr value)
		{
			return new CSceneObject
			{
				self = value
			};
		}

		// Token: 0x06000803 RID: 2051 RVA: 0x00033932 File Offset: 0x00031B32
		public static bool operator ==(CSceneObject c1, CSceneObject c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000804 RID: 2052 RVA: 0x00033945 File Offset: 0x00031B45
		public static bool operator !=(CSceneObject c1, CSceneObject c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000805 RID: 2053 RVA: 0x00033958 File Offset: 0x00031B58
		public override bool Equals(object obj)
		{
			if (obj is CSceneObject)
			{
				CSceneObject c = (CSceneObject)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x00033982 File Offset: 0x00031B82
		internal CSceneObject(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000807 RID: 2055 RVA: 0x0003398C File Offset: 0x00031B8C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CSceneObject ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x000339C8 File Offset: 0x00031BC8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000809 RID: 2057 RVA: 0x000339DA File Offset: 0x00031BDA
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x000339E5 File Offset: 0x00031BE5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x000339F8 File Offset: 0x00031BF8
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CSceneObject was null when calling " + n);
			}
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x00033A13 File Offset: 0x00031C13
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600080D RID: 2061 RVA: 0x00033A20 File Offset: 0x00031C20
		internal readonly void ChangeFlags(ESceneObjectFlags nNewFlags, ESceneObjectFlags nNewFlagsMask)
		{
			this.NullCheck("ChangeFlags");
			method cscene_f = CSceneObject.__N.CScene_f97;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, nNewFlags, nNewFlagsMask, cscene_f);
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x00033A4C File Offset: 0x00031C4C
		internal readonly void SetFlags(ESceneObjectFlags nFlagsToOR)
		{
			this.NullCheck("SetFlags");
			method cscene_f = CSceneObject.__N.CScene_f98;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToOR, cscene_f);
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x00033A78 File Offset: 0x00031C78
		internal readonly bool HasFlags(ESceneObjectFlags nFlags)
		{
			this.NullCheck("HasFlags");
			method cscene_f = CSceneObject.__N.CScene_f99;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, nFlags, cscene_f) > 0;
		}

		// Token: 0x06000810 RID: 2064 RVA: 0x00033AA8 File Offset: 0x00031CA8
		internal readonly ESceneObjectFlags GetFlags()
		{
			this.NullCheck("GetFlags");
			method cscene_f = CSceneObject.__N.CScene_f100;
			return calli(System.Int64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000811 RID: 2065 RVA: 0x00033AD4 File Offset: 0x00031CD4
		internal readonly ESceneObjectFlags GetOriginalFlags()
		{
			this.NullCheck("GetOriginalFlags");
			method cscene_f = CSceneObject.__N.CScene_f101;
			return calli(System.Int64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000812 RID: 2066 RVA: 0x00033B00 File Offset: 0x00031D00
		internal readonly void ClearFlags(ESceneObjectFlags nFlagsToClear)
		{
			this.NullCheck("ClearFlags");
			method cscene_f = CSceneObject.__N.CScene_f102;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToClear, cscene_f);
		}

		// Token: 0x06000813 RID: 2067 RVA: 0x00033B2C File Offset: 0x00031D2C
		internal readonly void SetCullDistance(float dist)
		{
			this.NullCheck("SetCullDistance");
			method cscene_f = CSceneObject.__N.CScene_f103;
			calli(System.Void(System.IntPtr,System.Single), this.self, dist, cscene_f);
		}

		// Token: 0x06000814 RID: 2068 RVA: 0x00033B58 File Offset: 0x00031D58
		internal unsafe readonly void SetLightingOrigin(Vector3 vPos, bool worldspace)
		{
			this.NullCheck("SetLightingOrigin");
			method cscene_f = CSceneObject.__N.CScene_f104;
			calli(System.Void(System.IntPtr,Vector3*,System.Int32), this.self, &vPos, worldspace ? 1 : 0, cscene_f);
		}

		// Token: 0x06000815 RID: 2069 RVA: 0x00033B8C File Offset: 0x00031D8C
		internal readonly Vector3 GetLightingOrigin()
		{
			this.NullCheck("GetLightingOrigin");
			method cscene_f = CSceneObject.__N.CScene_f105;
			return calli(Vector3(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000816 RID: 2070 RVA: 0x00033BB8 File Offset: 0x00031DB8
		internal readonly bool HasLightingOrigin()
		{
			this.NullCheck("HasLightingOrigin");
			method cscene_f = CSceneObject.__N.CScene_f106;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x06000817 RID: 2071 RVA: 0x00033BE8 File Offset: 0x00031DE8
		internal unsafe readonly void SetTintRGBA(Vector4 color)
		{
			this.NullCheck("SetTintRGBA");
			method cscene_f = CSceneObject.__N.CScene_f107;
			calli(System.Void(System.IntPtr,Vector4*), this.self, &color, cscene_f);
		}

		// Token: 0x06000818 RID: 2072 RVA: 0x00033C18 File Offset: 0x00031E18
		internal readonly Vector4 GetTintRGBA()
		{
			this.NullCheck("GetTintRGBA");
			method cscene_f = CSceneObject.__N.CScene_f108;
			return calli(Vector4(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000819 RID: 2073 RVA: 0x00033C44 File Offset: 0x00031E44
		internal readonly void SetAlphaFade(float nAlpha)
		{
			this.NullCheck("SetAlphaFade");
			method cscene_f = CSceneObject.__N.CScene_f109;
			calli(System.Void(System.IntPtr,System.Single), this.self, nAlpha, cscene_f);
		}

		// Token: 0x0600081A RID: 2074 RVA: 0x00033C70 File Offset: 0x00031E70
		internal readonly float GetAlphaFade()
		{
			this.NullCheck("GetAlphaFade");
			method cscene_f = CSceneObject.__N.CScene_f110;
			return calli(System.Single(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600081B RID: 2075 RVA: 0x00033C9C File Offset: 0x00031E9C
		internal readonly void SetMaterialOverride(IMaterial mat)
		{
			this.NullCheck("SetMaterialOverride");
			method cscene_f = CSceneObject.__N.CScene_f111;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, mat, cscene_f);
		}

		// Token: 0x0600081C RID: 2076 RVA: 0x00033CCC File Offset: 0x00031ECC
		internal readonly void ClearMaterialOverrideList()
		{
			this.NullCheck("ClearMaterialOverrideList");
			method cscene_f = CSceneObject.__N.CScene_f112;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600081D RID: 2077 RVA: 0x00033CF8 File Offset: 0x00031EF8
		internal readonly bool IsLoaded()
		{
			this.NullCheck("IsLoaded");
			method cscene_f = CSceneObject.__N.CScene_f113;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x0600081E RID: 2078 RVA: 0x00033D28 File Offset: 0x00031F28
		internal readonly bool IsRenderingEnabled()
		{
			this.NullCheck("IsRenderingEnabled");
			method cscene_f = CSceneObject.__N.CScene_f114;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x0600081F RID: 2079 RVA: 0x00033D58 File Offset: 0x00031F58
		internal readonly void SetLoaded()
		{
			this.NullCheck("SetLoaded");
			method cscene_f = CSceneObject.__N.CScene_f115;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x00033D84 File Offset: 0x00031F84
		internal readonly void ClearLoaded()
		{
			this.NullCheck("ClearLoaded");
			method cscene_f = CSceneObject.__N.CScene_f116;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x00033DB0 File Offset: 0x00031FB0
		internal readonly void DisableRendering()
		{
			this.NullCheck("DisableRendering");
			method cscene_f = CSceneObject.__N.CScene_f117;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000822 RID: 2082 RVA: 0x00033DDC File Offset: 0x00031FDC
		internal readonly void EnableRendering()
		{
			this.NullCheck("EnableRendering");
			method cscene_f = CSceneObject.__N.CScene_f118;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000823 RID: 2083 RVA: 0x00033E08 File Offset: 0x00032008
		internal readonly void SetRenderingEnabled(bool bEnabled)
		{
			this.NullCheck("SetRenderingEnabled");
			method cscene_f = CSceneObject.__N.CScene_f119;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnabled ? 1 : 0, cscene_f);
		}

		// Token: 0x06000824 RID: 2084 RVA: 0x00033E3C File Offset: 0x0003203C
		internal readonly float GetBoundingSphereRadius()
		{
			this.NullCheck("GetBoundingSphereRadius");
			method cscene_f = CSceneObject.__N.CScene_f120;
			return calli(System.Single(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000825 RID: 2085 RVA: 0x00033E68 File Offset: 0x00032068
		internal readonly void ScheduleDirtyUpdate()
		{
			this.NullCheck("ScheduleDirtyUpdate");
			method cscene_f = CSceneObject.__N.CScene_f121;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000826 RID: 2086 RVA: 0x00033E94 File Offset: 0x00032094
		internal readonly void UnscheduleDirtyUpdate()
		{
			this.NullCheck("UnscheduleDirtyUpdate");
			method cscene_f = CSceneObject.__N.CScene_f122;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000827 RID: 2087 RVA: 0x00033EC0 File Offset: 0x000320C0
		internal unsafe readonly void SetTransform(Transform tx)
		{
			this.NullCheck("SetTransform");
			method cscene_f = CSceneObject.__N.CScene_f123;
			calli(System.Void(System.IntPtr,Transform*), this.self, &tx, cscene_f);
		}

		// Token: 0x06000828 RID: 2088 RVA: 0x00033EF0 File Offset: 0x000320F0
		internal readonly Transform GetCTransform()
		{
			this.NullCheck("GetCTransform");
			method cscene_f = CSceneObject.__N.CScene_f124;
			return calli(Transform(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000829 RID: 2089 RVA: 0x00033F1C File Offset: 0x0003211C
		internal unsafe readonly void SetBounds(Vector3 mins, Vector3 maxs)
		{
			this.NullCheck("SetBounds");
			method cscene_f = CSceneObject.__N.CScene_f125;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), this.self, &mins, &maxs, cscene_f);
		}

		// Token: 0x0600082A RID: 2090 RVA: 0x00033F4C File Offset: 0x0003214C
		internal readonly SceneObject GetParent()
		{
			this.NullCheck("GetParent");
			method cscene_f = CSceneObject.__N.CScene_f126;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr), this.self, cscene_f));
		}

		// Token: 0x0600082B RID: 2091 RVA: 0x00033F7C File Offset: 0x0003217C
		internal readonly void AddChildObject(string nId, SceneObject pChild, uint nChildUpdateFlags)
		{
			this.NullCheck("AddChildObject");
			method cscene_f = CSceneObject.__N.CScene_f127;
			calli(System.Void(System.IntPtr,System.UInt32,System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nId), (pChild == null) ? IntPtr.Zero : pChild.native, nChildUpdateFlags, cscene_f);
		}

		// Token: 0x0600082C RID: 2092 RVA: 0x00033FC4 File Offset: 0x000321C4
		internal readonly void RemoveChild(SceneObject obj)
		{
			this.NullCheck("RemoveChild");
			method cscene_f = CSceneObject.__N.CScene_f128;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (obj == null) ? IntPtr.Zero : obj.native, cscene_f);
		}

		// Token: 0x0600082D RID: 2093 RVA: 0x00034004 File Offset: 0x00032204
		internal readonly CRenderAttributes GetAttributesPtrForModify()
		{
			this.NullCheck("GetAttributesPtrForModify");
			method cscene_f = CSceneObject.__N.CScene_f129;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600082E RID: 2094 RVA: 0x00034034 File Offset: 0x00032234
		internal readonly void EnableMeshGroups(ulong nMask)
		{
			this.NullCheck("EnableMeshGroups");
			method cscene_f = CSceneObject.__N.CScene_f130;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x0600082F RID: 2095 RVA: 0x00034060 File Offset: 0x00032260
		internal readonly void DisableMeshGroups(ulong nMask)
		{
			this.NullCheck("DisableMeshGroups");
			method cscene_f = CSceneObject.__N.CScene_f131;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x06000830 RID: 2096 RVA: 0x0003408C File Offset: 0x0003228C
		internal readonly void ResetMeshGroups(ulong nMask)
		{
			this.NullCheck("ResetMeshGroups");
			method cscene_f = CSceneObject.__N.CScene_f132;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x06000831 RID: 2097 RVA: 0x000340B8 File Offset: 0x000322B8
		internal readonly ulong GetCurrentMeshGroupMask()
		{
			this.NullCheck("GetCurrentMeshGroupMask");
			method cscene_f = CSceneObject.__N.CScene_f133;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000832 RID: 2098 RVA: 0x000340E4 File Offset: 0x000322E4
		internal readonly SceneWorld GetWorld()
		{
			this.NullCheck("GetWorld");
			method cscene_f = CSceneObject.__N.CScene_f134;
			return HandleIndex.Get<SceneWorld>(calli(System.Int32(System.IntPtr), this.self, cscene_f));
		}

		// Token: 0x06000833 RID: 2099 RVA: 0x00034114 File Offset: 0x00032314
		internal readonly void SetLOD(int nLOD)
		{
			this.NullCheck("SetLOD");
			method cscene_f = CSceneObject.__N.CScene_f135;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLOD, cscene_f);
		}

		// Token: 0x06000834 RID: 2100 RVA: 0x00034140 File Offset: 0x00032340
		internal readonly void DisableLOD()
		{
			this.NullCheck("DisableLOD");
			method cscene_f = CSceneObject.__N.CScene_f136;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000835 RID: 2101 RVA: 0x0003416C File Offset: 0x0003236C
		internal readonly ulong GetCurrentLODGroupMask()
		{
			this.NullCheck("GetCurrentLODGroupMask");
			method cscene_f = CSceneObject.__N.CScene_f137;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000836 RID: 2102 RVA: 0x00034198 File Offset: 0x00032398
		internal readonly int GetCurrentLODLevel()
		{
			this.NullCheck("GetCurrentLODLevel");
			method cscene_f = CSceneObject.__N.CScene_f138;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x000341C4 File Offset: 0x000323C4
		internal readonly IModel GetModelHandle()
		{
			this.NullCheck("GetModelHandle");
			method cscene_f = CSceneObject.__N.CScene_f139;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000838 RID: 2104 RVA: 0x000341F4 File Offset: 0x000323F4
		internal readonly void SetMaterialGroup(string token)
		{
			this.NullCheck("SetMaterialGroup");
			method cscene_f = CSceneObject.__N.CScene_f140;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(token), cscene_f);
		}

		// Token: 0x06000839 RID: 2105 RVA: 0x00034224 File Offset: 0x00032424
		internal readonly void SetBodyGroup(string token, int value)
		{
			this.NullCheck("SetBodyGroup");
			method cscene_f = CSceneObject.__N.CScene_f141;
			calli(System.Void(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(token), value, cscene_f);
		}

		// Token: 0x040000B1 RID: 177
		internal IntPtr self;

		// Token: 0x020001BA RID: 442
		internal static class __N
		{
			// Token: 0x04000D88 RID: 3464
			internal static method CScene_f97;

			// Token: 0x04000D89 RID: 3465
			internal static method CScene_f98;

			// Token: 0x04000D8A RID: 3466
			internal static method CScene_f99;

			// Token: 0x04000D8B RID: 3467
			internal static method CScene_f100;

			// Token: 0x04000D8C RID: 3468
			internal static method CScene_f101;

			// Token: 0x04000D8D RID: 3469
			internal static method CScene_f102;

			// Token: 0x04000D8E RID: 3470
			internal static method CScene_f103;

			// Token: 0x04000D8F RID: 3471
			internal static method CScene_f104;

			// Token: 0x04000D90 RID: 3472
			internal static method CScene_f105;

			// Token: 0x04000D91 RID: 3473
			internal static method CScene_f106;

			// Token: 0x04000D92 RID: 3474
			internal static method CScene_f107;

			// Token: 0x04000D93 RID: 3475
			internal static method CScene_f108;

			// Token: 0x04000D94 RID: 3476
			internal static method CScene_f109;

			// Token: 0x04000D95 RID: 3477
			internal static method CScene_f110;

			// Token: 0x04000D96 RID: 3478
			internal static method CScene_f111;

			// Token: 0x04000D97 RID: 3479
			internal static method CScene_f112;

			// Token: 0x04000D98 RID: 3480
			internal static method CScene_f113;

			// Token: 0x04000D99 RID: 3481
			internal static method CScene_f114;

			// Token: 0x04000D9A RID: 3482
			internal static method CScene_f115;

			// Token: 0x04000D9B RID: 3483
			internal static method CScene_f116;

			// Token: 0x04000D9C RID: 3484
			internal static method CScene_f117;

			// Token: 0x04000D9D RID: 3485
			internal static method CScene_f118;

			// Token: 0x04000D9E RID: 3486
			internal static method CScene_f119;

			// Token: 0x04000D9F RID: 3487
			internal static method CScene_f120;

			// Token: 0x04000DA0 RID: 3488
			internal static method CScene_f121;

			// Token: 0x04000DA1 RID: 3489
			internal static method CScene_f122;

			// Token: 0x04000DA2 RID: 3490
			internal static method CScene_f123;

			// Token: 0x04000DA3 RID: 3491
			internal static method CScene_f124;

			// Token: 0x04000DA4 RID: 3492
			internal static method CScene_f125;

			// Token: 0x04000DA5 RID: 3493
			internal static method CScene_f126;

			// Token: 0x04000DA6 RID: 3494
			internal static method CScene_f127;

			// Token: 0x04000DA7 RID: 3495
			internal static method CScene_f128;

			// Token: 0x04000DA8 RID: 3496
			internal static method CScene_f129;

			// Token: 0x04000DA9 RID: 3497
			internal static method CScene_f130;

			// Token: 0x04000DAA RID: 3498
			internal static method CScene_f131;

			// Token: 0x04000DAB RID: 3499
			internal static method CScene_f132;

			// Token: 0x04000DAC RID: 3500
			internal static method CScene_f133;

			// Token: 0x04000DAD RID: 3501
			internal static method CScene_f134;

			// Token: 0x04000DAE RID: 3502
			internal static method CScene_f135;

			// Token: 0x04000DAF RID: 3503
			internal static method CScene_f136;

			// Token: 0x04000DB0 RID: 3504
			internal static method CScene_f137;

			// Token: 0x04000DB1 RID: 3505
			internal static method CScene_f138;

			// Token: 0x04000DB2 RID: 3506
			internal static method CScene_f139;

			// Token: 0x04000DB3 RID: 3507
			internal static method CScene_f140;

			// Token: 0x04000DB4 RID: 3508
			internal static method CScene_f141;
		}
	}
}
