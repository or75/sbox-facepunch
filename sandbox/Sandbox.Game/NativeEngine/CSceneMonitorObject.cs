using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000034 RID: 52
	internal struct CSceneMonitorObject
	{
		// Token: 0x060007C5 RID: 1989 RVA: 0x00032F45 File Offset: 0x00031145
		public static implicit operator IntPtr(CSceneMonitorObject value)
		{
			return value.self;
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00032F50 File Offset: 0x00031150
		public static implicit operator CSceneMonitorObject(IntPtr value)
		{
			return new CSceneMonitorObject
			{
				self = value
			};
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00032F6E File Offset: 0x0003116E
		public static bool operator ==(CSceneMonitorObject c1, CSceneMonitorObject c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x00032F81 File Offset: 0x00031181
		public static bool operator !=(CSceneMonitorObject c1, CSceneMonitorObject c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x00032F94 File Offset: 0x00031194
		public override bool Equals(object obj)
		{
			if (obj is CSceneMonitorObject)
			{
				CSceneMonitorObject c = (CSceneMonitorObject)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x00032FBE File Offset: 0x000311BE
		internal CSceneMonitorObject(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x00032FC8 File Offset: 0x000311C8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CSceneMonitorObject ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060007CC RID: 1996 RVA: 0x00033004 File Offset: 0x00031204
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060007CD RID: 1997 RVA: 0x00033016 File Offset: 0x00031216
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x00033021 File Offset: 0x00031221
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x00033034 File Offset: 0x00031234
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CSceneMonitorObject was null when calling " + n);
			}
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0003304F File Offset: 0x0003124F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0003305C File Offset: 0x0003125C
		public static implicit operator CSceneObject(CSceneMonitorObject value)
		{
			method to_CSceneObject_From_CSceneMonitorObject = CSceneMonitorObject.__N.To_CSceneObject_From_CSceneMonitorObject;
			return calli(System.IntPtr(System.IntPtr), value, to_CSceneObject_From_CSceneMonitorObject);
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x00033080 File Offset: 0x00031280
		public static explicit operator CSceneMonitorObject(CSceneObject value)
		{
			method from_CSceneObject_To_CSceneMonitorObject = CSceneMonitorObject.__N.From_CSceneObject_To_CSceneMonitorObject;
			return calli(System.IntPtr(System.IntPtr), value, from_CSceneObject_To_CSceneMonitorObject);
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x000330A4 File Offset: 0x000312A4
		internal readonly CRenderAttributes GetMonitorAttributesPtrForModify()
		{
			this.NullCheck("GetMonitorAttributesPtrForModify");
			method cscene_GetMonitorAttributesPtrForModify = CSceneMonitorObject.__N.CScene_GetMonitorAttributesPtrForModify;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_GetMonitorAttributesPtrForModify);
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x000330D4 File Offset: 0x000312D4
		internal readonly void ChangeFlags(ESceneObjectFlags nNewFlags, ESceneObjectFlags nNewFlagsMask)
		{
			this.NullCheck("ChangeFlags");
			method cscene_f = CSceneMonitorObject.__N.CScene_f52;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, nNewFlags, nNewFlagsMask, cscene_f);
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x00033100 File Offset: 0x00031300
		internal readonly void SetFlags(ESceneObjectFlags nFlagsToOR)
		{
			this.NullCheck("SetFlags");
			method cscene_f = CSceneMonitorObject.__N.CScene_f53;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToOR, cscene_f);
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0003312C File Offset: 0x0003132C
		internal readonly bool HasFlags(ESceneObjectFlags nFlags)
		{
			this.NullCheck("HasFlags");
			method cscene_f = CSceneMonitorObject.__N.CScene_f54;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, nFlags, cscene_f) > 0;
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x0003315C File Offset: 0x0003135C
		internal readonly ESceneObjectFlags GetFlags()
		{
			this.NullCheck("GetFlags");
			method cscene_f = CSceneMonitorObject.__N.CScene_f55;
			return calli(System.Int64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00033188 File Offset: 0x00031388
		internal readonly ESceneObjectFlags GetOriginalFlags()
		{
			this.NullCheck("GetOriginalFlags");
			method cscene_f = CSceneMonitorObject.__N.CScene_f56;
			return calli(System.Int64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x000331B4 File Offset: 0x000313B4
		internal readonly void ClearFlags(ESceneObjectFlags nFlagsToClear)
		{
			this.NullCheck("ClearFlags");
			method cscene_f = CSceneMonitorObject.__N.CScene_f57;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToClear, cscene_f);
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x000331E0 File Offset: 0x000313E0
		internal readonly void SetCullDistance(float dist)
		{
			this.NullCheck("SetCullDistance");
			method cscene_f = CSceneMonitorObject.__N.CScene_f58;
			calli(System.Void(System.IntPtr,System.Single), this.self, dist, cscene_f);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x0003320C File Offset: 0x0003140C
		internal unsafe readonly void SetLightingOrigin(Vector3 vPos, bool worldspace)
		{
			this.NullCheck("SetLightingOrigin");
			method cscene_f = CSceneMonitorObject.__N.CScene_f59;
			calli(System.Void(System.IntPtr,Vector3*,System.Int32), this.self, &vPos, worldspace ? 1 : 0, cscene_f);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x00033240 File Offset: 0x00031440
		internal readonly Vector3 GetLightingOrigin()
		{
			this.NullCheck("GetLightingOrigin");
			method cscene_f = CSceneMonitorObject.__N.CScene_f60;
			return calli(Vector3(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x0003326C File Offset: 0x0003146C
		internal readonly bool HasLightingOrigin()
		{
			this.NullCheck("HasLightingOrigin");
			method cscene_f = CSceneMonitorObject.__N.CScene_f61;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x0003329C File Offset: 0x0003149C
		internal unsafe readonly void SetTintRGBA(Vector4 color)
		{
			this.NullCheck("SetTintRGBA");
			method cscene_f = CSceneMonitorObject.__N.CScene_f62;
			calli(System.Void(System.IntPtr,Vector4*), this.self, &color, cscene_f);
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x000332CC File Offset: 0x000314CC
		internal readonly Vector4 GetTintRGBA()
		{
			this.NullCheck("GetTintRGBA");
			method cscene_f = CSceneMonitorObject.__N.CScene_f63;
			return calli(Vector4(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x000332F8 File Offset: 0x000314F8
		internal readonly void SetAlphaFade(float nAlpha)
		{
			this.NullCheck("SetAlphaFade");
			method cscene_f = CSceneMonitorObject.__N.CScene_f64;
			calli(System.Void(System.IntPtr,System.Single), this.self, nAlpha, cscene_f);
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x00033324 File Offset: 0x00031524
		internal readonly float GetAlphaFade()
		{
			this.NullCheck("GetAlphaFade");
			method cscene_f = CSceneMonitorObject.__N.CScene_f65;
			return calli(System.Single(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x00033350 File Offset: 0x00031550
		internal readonly void SetMaterialOverride(IMaterial mat)
		{
			this.NullCheck("SetMaterialOverride");
			method cscene_f = CSceneMonitorObject.__N.CScene_f66;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, mat, cscene_f);
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x00033380 File Offset: 0x00031580
		internal readonly void ClearMaterialOverrideList()
		{
			this.NullCheck("ClearMaterialOverrideList");
			method cscene_f = CSceneMonitorObject.__N.CScene_f67;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x000333AC File Offset: 0x000315AC
		internal readonly bool IsLoaded()
		{
			this.NullCheck("IsLoaded");
			method cscene_f = CSceneMonitorObject.__N.CScene_f68;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x000333DC File Offset: 0x000315DC
		internal readonly bool IsRenderingEnabled()
		{
			this.NullCheck("IsRenderingEnabled");
			method cscene_f = CSceneMonitorObject.__N.CScene_f69;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x0003340C File Offset: 0x0003160C
		internal readonly void SetLoaded()
		{
			this.NullCheck("SetLoaded");
			method cscene_f = CSceneMonitorObject.__N.CScene_f70;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x00033438 File Offset: 0x00031638
		internal readonly void ClearLoaded()
		{
			this.NullCheck("ClearLoaded");
			method cscene_f = CSceneMonitorObject.__N.CScene_f71;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x00033464 File Offset: 0x00031664
		internal readonly void DisableRendering()
		{
			this.NullCheck("DisableRendering");
			method cscene_f = CSceneMonitorObject.__N.CScene_f72;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x00033490 File Offset: 0x00031690
		internal readonly void EnableRendering()
		{
			this.NullCheck("EnableRendering");
			method cscene_f = CSceneMonitorObject.__N.CScene_f73;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x000334BC File Offset: 0x000316BC
		internal readonly void SetRenderingEnabled(bool bEnabled)
		{
			this.NullCheck("SetRenderingEnabled");
			method cscene_f = CSceneMonitorObject.__N.CScene_f74;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnabled ? 1 : 0, cscene_f);
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x000334F0 File Offset: 0x000316F0
		internal readonly float GetBoundingSphereRadius()
		{
			this.NullCheck("GetBoundingSphereRadius");
			method cscene_f = CSceneMonitorObject.__N.CScene_f75;
			return calli(System.Single(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x0003351C File Offset: 0x0003171C
		internal readonly void ScheduleDirtyUpdate()
		{
			this.NullCheck("ScheduleDirtyUpdate");
			method cscene_f = CSceneMonitorObject.__N.CScene_f76;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x00033548 File Offset: 0x00031748
		internal readonly void UnscheduleDirtyUpdate()
		{
			this.NullCheck("UnscheduleDirtyUpdate");
			method cscene_f = CSceneMonitorObject.__N.CScene_f77;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x00033574 File Offset: 0x00031774
		internal unsafe readonly void SetTransform(Transform tx)
		{
			this.NullCheck("SetTransform");
			method cscene_f = CSceneMonitorObject.__N.CScene_f78;
			calli(System.Void(System.IntPtr,Transform*), this.self, &tx, cscene_f);
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x000335A4 File Offset: 0x000317A4
		internal readonly Transform GetCTransform()
		{
			this.NullCheck("GetCTransform");
			method cscene_f = CSceneMonitorObject.__N.CScene_f79;
			return calli(Transform(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x000335D0 File Offset: 0x000317D0
		internal unsafe readonly void SetBounds(Vector3 mins, Vector3 maxs)
		{
			this.NullCheck("SetBounds");
			method cscene_f = CSceneMonitorObject.__N.CScene_f80;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), this.self, &mins, &maxs, cscene_f);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x00033600 File Offset: 0x00031800
		internal readonly SceneObject GetParent()
		{
			this.NullCheck("GetParent");
			method cscene_f = CSceneMonitorObject.__N.CScene_f81;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr), this.self, cscene_f));
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x00033630 File Offset: 0x00031830
		internal readonly void AddChildObject(string nId, SceneObject pChild, uint nChildUpdateFlags)
		{
			this.NullCheck("AddChildObject");
			method cscene_f = CSceneMonitorObject.__N.CScene_f82;
			calli(System.Void(System.IntPtr,System.UInt32,System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nId), (pChild == null) ? IntPtr.Zero : pChild.native, nChildUpdateFlags, cscene_f);
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x00033678 File Offset: 0x00031878
		internal readonly void RemoveChild(SceneObject obj)
		{
			this.NullCheck("RemoveChild");
			method cscene_f = CSceneMonitorObject.__N.CScene_f83;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (obj == null) ? IntPtr.Zero : obj.native, cscene_f);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x000336B8 File Offset: 0x000318B8
		internal readonly CRenderAttributes GetAttributesPtrForModify()
		{
			this.NullCheck("GetAttributesPtrForModify");
			method cscene_f = CSceneMonitorObject.__N.CScene_f84;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x000336E8 File Offset: 0x000318E8
		internal readonly void EnableMeshGroups(ulong nMask)
		{
			this.NullCheck("EnableMeshGroups");
			method cscene_f = CSceneMonitorObject.__N.CScene_f85;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00033714 File Offset: 0x00031914
		internal readonly void DisableMeshGroups(ulong nMask)
		{
			this.NullCheck("DisableMeshGroups");
			method cscene_f = CSceneMonitorObject.__N.CScene_f86;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x00033740 File Offset: 0x00031940
		internal readonly void ResetMeshGroups(ulong nMask)
		{
			this.NullCheck("ResetMeshGroups");
			method cscene_f = CSceneMonitorObject.__N.CScene_f87;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0003376C File Offset: 0x0003196C
		internal readonly ulong GetCurrentMeshGroupMask()
		{
			this.NullCheck("GetCurrentMeshGroupMask");
			method cscene_f = CSceneMonitorObject.__N.CScene_f88;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00033798 File Offset: 0x00031998
		internal readonly SceneWorld GetWorld()
		{
			this.NullCheck("GetWorld");
			method cscene_f = CSceneMonitorObject.__N.CScene_f89;
			return HandleIndex.Get<SceneWorld>(calli(System.Int32(System.IntPtr), this.self, cscene_f));
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x000337C8 File Offset: 0x000319C8
		internal readonly void SetLOD(int nLOD)
		{
			this.NullCheck("SetLOD");
			method cscene_f = CSceneMonitorObject.__N.CScene_f90;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLOD, cscene_f);
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x000337F4 File Offset: 0x000319F4
		internal readonly void DisableLOD()
		{
			this.NullCheck("DisableLOD");
			method cscene_f = CSceneMonitorObject.__N.CScene_f91;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x00033820 File Offset: 0x00031A20
		internal readonly ulong GetCurrentLODGroupMask()
		{
			this.NullCheck("GetCurrentLODGroupMask");
			method cscene_f = CSceneMonitorObject.__N.CScene_f92;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0003384C File Offset: 0x00031A4C
		internal readonly int GetCurrentLODLevel()
		{
			this.NullCheck("GetCurrentLODLevel");
			method cscene_f = CSceneMonitorObject.__N.CScene_f93;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00033878 File Offset: 0x00031A78
		internal readonly IModel GetModelHandle()
		{
			this.NullCheck("GetModelHandle");
			method cscene_f = CSceneMonitorObject.__N.CScene_f94;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x000338A8 File Offset: 0x00031AA8
		internal readonly void SetMaterialGroup(string token)
		{
			this.NullCheck("SetMaterialGroup");
			method cscene_f = CSceneMonitorObject.__N.CScene_f95;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(token), cscene_f);
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x000338D8 File Offset: 0x00031AD8
		internal readonly void SetBodyGroup(string token, int value)
		{
			this.NullCheck("SetBodyGroup");
			method cscene_f = CSceneMonitorObject.__N.CScene_f96;
			calli(System.Void(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(token), value, cscene_f);
		}

		// Token: 0x040000B0 RID: 176
		internal IntPtr self;

		// Token: 0x020001B9 RID: 441
		internal static class __N
		{
			// Token: 0x04000D58 RID: 3416
			internal static method From_CSceneObject_To_CSceneMonitorObject;

			// Token: 0x04000D59 RID: 3417
			internal static method To_CSceneObject_From_CSceneMonitorObject;

			// Token: 0x04000D5A RID: 3418
			internal static method CScene_GetMonitorAttributesPtrForModify;

			// Token: 0x04000D5B RID: 3419
			internal static method CScene_f52;

			// Token: 0x04000D5C RID: 3420
			internal static method CScene_f53;

			// Token: 0x04000D5D RID: 3421
			internal static method CScene_f54;

			// Token: 0x04000D5E RID: 3422
			internal static method CScene_f55;

			// Token: 0x04000D5F RID: 3423
			internal static method CScene_f56;

			// Token: 0x04000D60 RID: 3424
			internal static method CScene_f57;

			// Token: 0x04000D61 RID: 3425
			internal static method CScene_f58;

			// Token: 0x04000D62 RID: 3426
			internal static method CScene_f59;

			// Token: 0x04000D63 RID: 3427
			internal static method CScene_f60;

			// Token: 0x04000D64 RID: 3428
			internal static method CScene_f61;

			// Token: 0x04000D65 RID: 3429
			internal static method CScene_f62;

			// Token: 0x04000D66 RID: 3430
			internal static method CScene_f63;

			// Token: 0x04000D67 RID: 3431
			internal static method CScene_f64;

			// Token: 0x04000D68 RID: 3432
			internal static method CScene_f65;

			// Token: 0x04000D69 RID: 3433
			internal static method CScene_f66;

			// Token: 0x04000D6A RID: 3434
			internal static method CScene_f67;

			// Token: 0x04000D6B RID: 3435
			internal static method CScene_f68;

			// Token: 0x04000D6C RID: 3436
			internal static method CScene_f69;

			// Token: 0x04000D6D RID: 3437
			internal static method CScene_f70;

			// Token: 0x04000D6E RID: 3438
			internal static method CScene_f71;

			// Token: 0x04000D6F RID: 3439
			internal static method CScene_f72;

			// Token: 0x04000D70 RID: 3440
			internal static method CScene_f73;

			// Token: 0x04000D71 RID: 3441
			internal static method CScene_f74;

			// Token: 0x04000D72 RID: 3442
			internal static method CScene_f75;

			// Token: 0x04000D73 RID: 3443
			internal static method CScene_f76;

			// Token: 0x04000D74 RID: 3444
			internal static method CScene_f77;

			// Token: 0x04000D75 RID: 3445
			internal static method CScene_f78;

			// Token: 0x04000D76 RID: 3446
			internal static method CScene_f79;

			// Token: 0x04000D77 RID: 3447
			internal static method CScene_f80;

			// Token: 0x04000D78 RID: 3448
			internal static method CScene_f81;

			// Token: 0x04000D79 RID: 3449
			internal static method CScene_f82;

			// Token: 0x04000D7A RID: 3450
			internal static method CScene_f83;

			// Token: 0x04000D7B RID: 3451
			internal static method CScene_f84;

			// Token: 0x04000D7C RID: 3452
			internal static method CScene_f85;

			// Token: 0x04000D7D RID: 3453
			internal static method CScene_f86;

			// Token: 0x04000D7E RID: 3454
			internal static method CScene_f87;

			// Token: 0x04000D7F RID: 3455
			internal static method CScene_f88;

			// Token: 0x04000D80 RID: 3456
			internal static method CScene_f89;

			// Token: 0x04000D81 RID: 3457
			internal static method CScene_f90;

			// Token: 0x04000D82 RID: 3458
			internal static method CScene_f91;

			// Token: 0x04000D83 RID: 3459
			internal static method CScene_f92;

			// Token: 0x04000D84 RID: 3460
			internal static method CScene_f93;

			// Token: 0x04000D85 RID: 3461
			internal static method CScene_f94;

			// Token: 0x04000D86 RID: 3462
			internal static method CScene_f95;

			// Token: 0x04000D87 RID: 3463
			internal static method CScene_f96;
		}
	}
}
