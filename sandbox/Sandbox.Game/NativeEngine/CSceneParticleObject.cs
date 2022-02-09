using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000036 RID: 54
	internal struct CSceneParticleObject
	{
		// Token: 0x0600083A RID: 2106 RVA: 0x00034255 File Offset: 0x00032455
		public static implicit operator IntPtr(CSceneParticleObject value)
		{
			return value.self;
		}

		// Token: 0x0600083B RID: 2107 RVA: 0x00034260 File Offset: 0x00032460
		public static implicit operator CSceneParticleObject(IntPtr value)
		{
			return new CSceneParticleObject
			{
				self = value
			};
		}

		// Token: 0x0600083C RID: 2108 RVA: 0x0003427E File Offset: 0x0003247E
		public static bool operator ==(CSceneParticleObject c1, CSceneParticleObject c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600083D RID: 2109 RVA: 0x00034291 File Offset: 0x00032491
		public static bool operator !=(CSceneParticleObject c1, CSceneParticleObject c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600083E RID: 2110 RVA: 0x000342A4 File Offset: 0x000324A4
		public override bool Equals(object obj)
		{
			if (obj is CSceneParticleObject)
			{
				CSceneParticleObject c = (CSceneParticleObject)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600083F RID: 2111 RVA: 0x000342CE File Offset: 0x000324CE
		internal CSceneParticleObject(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000840 RID: 2112 RVA: 0x000342D8 File Offset: 0x000324D8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CSceneParticleObject ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x00034314 File Offset: 0x00032514
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000842 RID: 2114 RVA: 0x00034326 File Offset: 0x00032526
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000843 RID: 2115 RVA: 0x00034331 File Offset: 0x00032531
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000844 RID: 2116 RVA: 0x00034344 File Offset: 0x00032544
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CSceneParticleObject was null when calling " + n);
			}
		}

		// Token: 0x06000845 RID: 2117 RVA: 0x0003435F File Offset: 0x0003255F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000846 RID: 2118 RVA: 0x0003436C File Offset: 0x0003256C
		public static implicit operator CSceneObject(CSceneParticleObject value)
		{
			method to_CSceneObject_From_CSceneParticleObject = CSceneParticleObject.__N.To_CSceneObject_From_CSceneParticleObject;
			return calli(System.IntPtr(System.IntPtr), value, to_CSceneObject_From_CSceneParticleObject);
		}

		// Token: 0x06000847 RID: 2119 RVA: 0x00034390 File Offset: 0x00032590
		public static explicit operator CSceneParticleObject(CSceneObject value)
		{
			method from_CSceneObject_To_CSceneParticleObject = CSceneParticleObject.__N.From_CSceneObject_To_CSceneParticleObject;
			return calli(System.IntPtr(System.IntPtr), value, from_CSceneObject_To_CSceneParticleObject);
		}

		// Token: 0x06000848 RID: 2120 RVA: 0x000343B4 File Offset: 0x000325B4
		internal readonly IParticleCollection GetParticles()
		{
			this.NullCheck("GetParticles");
			method cscene_GetParticles = CSceneParticleObject.__N.CScene_GetParticles;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_GetParticles);
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x000343E4 File Offset: 0x000325E4
		internal readonly void ChangeFlags(ESceneObjectFlags nNewFlags, ESceneObjectFlags nNewFlagsMask)
		{
			this.NullCheck("ChangeFlags");
			method cscene_f = CSceneParticleObject.__N.CScene_f142;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, nNewFlags, nNewFlagsMask, cscene_f);
		}

		// Token: 0x0600084A RID: 2122 RVA: 0x00034410 File Offset: 0x00032610
		internal readonly void SetFlags(ESceneObjectFlags nFlagsToOR)
		{
			this.NullCheck("SetFlags");
			method cscene_f = CSceneParticleObject.__N.CScene_f143;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToOR, cscene_f);
		}

		// Token: 0x0600084B RID: 2123 RVA: 0x0003443C File Offset: 0x0003263C
		internal readonly bool HasFlags(ESceneObjectFlags nFlags)
		{
			this.NullCheck("HasFlags");
			method cscene_f = CSceneParticleObject.__N.CScene_f144;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, nFlags, cscene_f) > 0;
		}

		// Token: 0x0600084C RID: 2124 RVA: 0x0003446C File Offset: 0x0003266C
		internal readonly ESceneObjectFlags GetFlags()
		{
			this.NullCheck("GetFlags");
			method cscene_f = CSceneParticleObject.__N.CScene_f145;
			return calli(System.Int64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x00034498 File Offset: 0x00032698
		internal readonly ESceneObjectFlags GetOriginalFlags()
		{
			this.NullCheck("GetOriginalFlags");
			method cscene_f = CSceneParticleObject.__N.CScene_f146;
			return calli(System.Int64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600084E RID: 2126 RVA: 0x000344C4 File Offset: 0x000326C4
		internal readonly void ClearFlags(ESceneObjectFlags nFlagsToClear)
		{
			this.NullCheck("ClearFlags");
			method cscene_f = CSceneParticleObject.__N.CScene_f147;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToClear, cscene_f);
		}

		// Token: 0x0600084F RID: 2127 RVA: 0x000344F0 File Offset: 0x000326F0
		internal readonly void SetCullDistance(float dist)
		{
			this.NullCheck("SetCullDistance");
			method cscene_f = CSceneParticleObject.__N.CScene_f148;
			calli(System.Void(System.IntPtr,System.Single), this.self, dist, cscene_f);
		}

		// Token: 0x06000850 RID: 2128 RVA: 0x0003451C File Offset: 0x0003271C
		internal unsafe readonly void SetLightingOrigin(Vector3 vPos, bool worldspace)
		{
			this.NullCheck("SetLightingOrigin");
			method cscene_f = CSceneParticleObject.__N.CScene_f149;
			calli(System.Void(System.IntPtr,Vector3*,System.Int32), this.self, &vPos, worldspace ? 1 : 0, cscene_f);
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x00034550 File Offset: 0x00032750
		internal readonly Vector3 GetLightingOrigin()
		{
			this.NullCheck("GetLightingOrigin");
			method cscene_f = CSceneParticleObject.__N.CScene_f150;
			return calli(Vector3(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0003457C File Offset: 0x0003277C
		internal readonly bool HasLightingOrigin()
		{
			this.NullCheck("HasLightingOrigin");
			method cscene_f = CSceneParticleObject.__N.CScene_f151;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x000345AC File Offset: 0x000327AC
		internal unsafe readonly void SetTintRGBA(Vector4 color)
		{
			this.NullCheck("SetTintRGBA");
			method cscene_f = CSceneParticleObject.__N.CScene_f152;
			calli(System.Void(System.IntPtr,Vector4*), this.self, &color, cscene_f);
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x000345DC File Offset: 0x000327DC
		internal readonly Vector4 GetTintRGBA()
		{
			this.NullCheck("GetTintRGBA");
			method cscene_f = CSceneParticleObject.__N.CScene_f153;
			return calli(Vector4(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000855 RID: 2133 RVA: 0x00034608 File Offset: 0x00032808
		internal readonly void SetAlphaFade(float nAlpha)
		{
			this.NullCheck("SetAlphaFade");
			method cscene_f = CSceneParticleObject.__N.CScene_f154;
			calli(System.Void(System.IntPtr,System.Single), this.self, nAlpha, cscene_f);
		}

		// Token: 0x06000856 RID: 2134 RVA: 0x00034634 File Offset: 0x00032834
		internal readonly float GetAlphaFade()
		{
			this.NullCheck("GetAlphaFade");
			method cscene_f = CSceneParticleObject.__N.CScene_f155;
			return calli(System.Single(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000857 RID: 2135 RVA: 0x00034660 File Offset: 0x00032860
		internal readonly void SetMaterialOverride(IMaterial mat)
		{
			this.NullCheck("SetMaterialOverride");
			method cscene_f = CSceneParticleObject.__N.CScene_f156;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, mat, cscene_f);
		}

		// Token: 0x06000858 RID: 2136 RVA: 0x00034690 File Offset: 0x00032890
		internal readonly void ClearMaterialOverrideList()
		{
			this.NullCheck("ClearMaterialOverrideList");
			method cscene_f = CSceneParticleObject.__N.CScene_f157;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000859 RID: 2137 RVA: 0x000346BC File Offset: 0x000328BC
		internal readonly bool IsLoaded()
		{
			this.NullCheck("IsLoaded");
			method cscene_f = CSceneParticleObject.__N.CScene_f158;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x0600085A RID: 2138 RVA: 0x000346EC File Offset: 0x000328EC
		internal readonly bool IsRenderingEnabled()
		{
			this.NullCheck("IsRenderingEnabled");
			method cscene_f = CSceneParticleObject.__N.CScene_f159;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x0600085B RID: 2139 RVA: 0x0003471C File Offset: 0x0003291C
		internal readonly void SetLoaded()
		{
			this.NullCheck("SetLoaded");
			method cscene_f = CSceneParticleObject.__N.CScene_f160;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600085C RID: 2140 RVA: 0x00034748 File Offset: 0x00032948
		internal readonly void ClearLoaded()
		{
			this.NullCheck("ClearLoaded");
			method cscene_f = CSceneParticleObject.__N.CScene_f161;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600085D RID: 2141 RVA: 0x00034774 File Offset: 0x00032974
		internal readonly void DisableRendering()
		{
			this.NullCheck("DisableRendering");
			method cscene_f = CSceneParticleObject.__N.CScene_f162;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x000347A0 File Offset: 0x000329A0
		internal readonly void EnableRendering()
		{
			this.NullCheck("EnableRendering");
			method cscene_f = CSceneParticleObject.__N.CScene_f163;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x000347CC File Offset: 0x000329CC
		internal readonly void SetRenderingEnabled(bool bEnabled)
		{
			this.NullCheck("SetRenderingEnabled");
			method cscene_f = CSceneParticleObject.__N.CScene_f164;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnabled ? 1 : 0, cscene_f);
		}

		// Token: 0x06000860 RID: 2144 RVA: 0x00034800 File Offset: 0x00032A00
		internal readonly float GetBoundingSphereRadius()
		{
			this.NullCheck("GetBoundingSphereRadius");
			method cscene_f = CSceneParticleObject.__N.CScene_f165;
			return calli(System.Single(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000861 RID: 2145 RVA: 0x0003482C File Offset: 0x00032A2C
		internal readonly void ScheduleDirtyUpdate()
		{
			this.NullCheck("ScheduleDirtyUpdate");
			method cscene_f = CSceneParticleObject.__N.CScene_f166;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x00034858 File Offset: 0x00032A58
		internal readonly void UnscheduleDirtyUpdate()
		{
			this.NullCheck("UnscheduleDirtyUpdate");
			method cscene_f = CSceneParticleObject.__N.CScene_f167;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x00034884 File Offset: 0x00032A84
		internal unsafe readonly void SetTransform(Transform tx)
		{
			this.NullCheck("SetTransform");
			method cscene_f = CSceneParticleObject.__N.CScene_f168;
			calli(System.Void(System.IntPtr,Transform*), this.self, &tx, cscene_f);
		}

		// Token: 0x06000864 RID: 2148 RVA: 0x000348B4 File Offset: 0x00032AB4
		internal readonly Transform GetCTransform()
		{
			this.NullCheck("GetCTransform");
			method cscene_f = CSceneParticleObject.__N.CScene_f169;
			return calli(Transform(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000865 RID: 2149 RVA: 0x000348E0 File Offset: 0x00032AE0
		internal unsafe readonly void SetBounds(Vector3 mins, Vector3 maxs)
		{
			this.NullCheck("SetBounds");
			method cscene_f = CSceneParticleObject.__N.CScene_f170;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), this.self, &mins, &maxs, cscene_f);
		}

		// Token: 0x06000866 RID: 2150 RVA: 0x00034910 File Offset: 0x00032B10
		internal readonly SceneObject GetParent()
		{
			this.NullCheck("GetParent");
			method cscene_f = CSceneParticleObject.__N.CScene_f171;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr), this.self, cscene_f));
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00034940 File Offset: 0x00032B40
		internal readonly void AddChildObject(string nId, SceneObject pChild, uint nChildUpdateFlags)
		{
			this.NullCheck("AddChildObject");
			method cscene_f = CSceneParticleObject.__N.CScene_f172;
			calli(System.Void(System.IntPtr,System.UInt32,System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nId), (pChild == null) ? IntPtr.Zero : pChild.native, nChildUpdateFlags, cscene_f);
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00034988 File Offset: 0x00032B88
		internal readonly void RemoveChild(SceneObject obj)
		{
			this.NullCheck("RemoveChild");
			method cscene_f = CSceneParticleObject.__N.CScene_f173;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (obj == null) ? IntPtr.Zero : obj.native, cscene_f);
		}

		// Token: 0x06000869 RID: 2153 RVA: 0x000349C8 File Offset: 0x00032BC8
		internal readonly CRenderAttributes GetAttributesPtrForModify()
		{
			this.NullCheck("GetAttributesPtrForModify");
			method cscene_f = CSceneParticleObject.__N.CScene_f174;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x000349F8 File Offset: 0x00032BF8
		internal readonly void EnableMeshGroups(ulong nMask)
		{
			this.NullCheck("EnableMeshGroups");
			method cscene_f = CSceneParticleObject.__N.CScene_f175;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00034A24 File Offset: 0x00032C24
		internal readonly void DisableMeshGroups(ulong nMask)
		{
			this.NullCheck("DisableMeshGroups");
			method cscene_f = CSceneParticleObject.__N.CScene_f176;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x00034A50 File Offset: 0x00032C50
		internal readonly void ResetMeshGroups(ulong nMask)
		{
			this.NullCheck("ResetMeshGroups");
			method cscene_f = CSceneParticleObject.__N.CScene_f177;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x00034A7C File Offset: 0x00032C7C
		internal readonly ulong GetCurrentMeshGroupMask()
		{
			this.NullCheck("GetCurrentMeshGroupMask");
			method cscene_f = CSceneParticleObject.__N.CScene_f178;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00034AA8 File Offset: 0x00032CA8
		internal readonly SceneWorld GetWorld()
		{
			this.NullCheck("GetWorld");
			method cscene_f = CSceneParticleObject.__N.CScene_f179;
			return HandleIndex.Get<SceneWorld>(calli(System.Int32(System.IntPtr), this.self, cscene_f));
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00034AD8 File Offset: 0x00032CD8
		internal readonly void SetLOD(int nLOD)
		{
			this.NullCheck("SetLOD");
			method cscene_f = CSceneParticleObject.__N.CScene_f180;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLOD, cscene_f);
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00034B04 File Offset: 0x00032D04
		internal readonly void DisableLOD()
		{
			this.NullCheck("DisableLOD");
			method cscene_f = CSceneParticleObject.__N.CScene_f181;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00034B30 File Offset: 0x00032D30
		internal readonly ulong GetCurrentLODGroupMask()
		{
			this.NullCheck("GetCurrentLODGroupMask");
			method cscene_f = CSceneParticleObject.__N.CScene_f182;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00034B5C File Offset: 0x00032D5C
		internal readonly int GetCurrentLODLevel()
		{
			this.NullCheck("GetCurrentLODLevel");
			method cscene_f = CSceneParticleObject.__N.CScene_f183;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00034B88 File Offset: 0x00032D88
		internal readonly IModel GetModelHandle()
		{
			this.NullCheck("GetModelHandle");
			method cscene_f = CSceneParticleObject.__N.CScene_f184;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00034BB8 File Offset: 0x00032DB8
		internal readonly void SetMaterialGroup(string token)
		{
			this.NullCheck("SetMaterialGroup");
			method cscene_f = CSceneParticleObject.__N.CScene_f185;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(token), cscene_f);
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00034BE8 File Offset: 0x00032DE8
		internal readonly void SetBodyGroup(string token, int value)
		{
			this.NullCheck("SetBodyGroup");
			method cscene_f = CSceneParticleObject.__N.CScene_f186;
			calli(System.Void(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(token), value, cscene_f);
		}

		// Token: 0x040000B2 RID: 178
		internal IntPtr self;

		// Token: 0x020001BB RID: 443
		internal static class __N
		{
			// Token: 0x04000DB5 RID: 3509
			internal static method From_CSceneObject_To_CSceneParticleObject;

			// Token: 0x04000DB6 RID: 3510
			internal static method To_CSceneObject_From_CSceneParticleObject;

			// Token: 0x04000DB7 RID: 3511
			internal static method CScene_GetParticles;

			// Token: 0x04000DB8 RID: 3512
			internal static method CScene_f142;

			// Token: 0x04000DB9 RID: 3513
			internal static method CScene_f143;

			// Token: 0x04000DBA RID: 3514
			internal static method CScene_f144;

			// Token: 0x04000DBB RID: 3515
			internal static method CScene_f145;

			// Token: 0x04000DBC RID: 3516
			internal static method CScene_f146;

			// Token: 0x04000DBD RID: 3517
			internal static method CScene_f147;

			// Token: 0x04000DBE RID: 3518
			internal static method CScene_f148;

			// Token: 0x04000DBF RID: 3519
			internal static method CScene_f149;

			// Token: 0x04000DC0 RID: 3520
			internal static method CScene_f150;

			// Token: 0x04000DC1 RID: 3521
			internal static method CScene_f151;

			// Token: 0x04000DC2 RID: 3522
			internal static method CScene_f152;

			// Token: 0x04000DC3 RID: 3523
			internal static method CScene_f153;

			// Token: 0x04000DC4 RID: 3524
			internal static method CScene_f154;

			// Token: 0x04000DC5 RID: 3525
			internal static method CScene_f155;

			// Token: 0x04000DC6 RID: 3526
			internal static method CScene_f156;

			// Token: 0x04000DC7 RID: 3527
			internal static method CScene_f157;

			// Token: 0x04000DC8 RID: 3528
			internal static method CScene_f158;

			// Token: 0x04000DC9 RID: 3529
			internal static method CScene_f159;

			// Token: 0x04000DCA RID: 3530
			internal static method CScene_f160;

			// Token: 0x04000DCB RID: 3531
			internal static method CScene_f161;

			// Token: 0x04000DCC RID: 3532
			internal static method CScene_f162;

			// Token: 0x04000DCD RID: 3533
			internal static method CScene_f163;

			// Token: 0x04000DCE RID: 3534
			internal static method CScene_f164;

			// Token: 0x04000DCF RID: 3535
			internal static method CScene_f165;

			// Token: 0x04000DD0 RID: 3536
			internal static method CScene_f166;

			// Token: 0x04000DD1 RID: 3537
			internal static method CScene_f167;

			// Token: 0x04000DD2 RID: 3538
			internal static method CScene_f168;

			// Token: 0x04000DD3 RID: 3539
			internal static method CScene_f169;

			// Token: 0x04000DD4 RID: 3540
			internal static method CScene_f170;

			// Token: 0x04000DD5 RID: 3541
			internal static method CScene_f171;

			// Token: 0x04000DD6 RID: 3542
			internal static method CScene_f172;

			// Token: 0x04000DD7 RID: 3543
			internal static method CScene_f173;

			// Token: 0x04000DD8 RID: 3544
			internal static method CScene_f174;

			// Token: 0x04000DD9 RID: 3545
			internal static method CScene_f175;

			// Token: 0x04000DDA RID: 3546
			internal static method CScene_f176;

			// Token: 0x04000DDB RID: 3547
			internal static method CScene_f177;

			// Token: 0x04000DDC RID: 3548
			internal static method CScene_f178;

			// Token: 0x04000DDD RID: 3549
			internal static method CScene_f179;

			// Token: 0x04000DDE RID: 3550
			internal static method CScene_f180;

			// Token: 0x04000DDF RID: 3551
			internal static method CScene_f181;

			// Token: 0x04000DE0 RID: 3552
			internal static method CScene_f182;

			// Token: 0x04000DE1 RID: 3553
			internal static method CScene_f183;

			// Token: 0x04000DE2 RID: 3554
			internal static method CScene_f184;

			// Token: 0x04000DE3 RID: 3555
			internal static method CScene_f185;

			// Token: 0x04000DE4 RID: 3556
			internal static method CScene_f186;
		}
	}
}
