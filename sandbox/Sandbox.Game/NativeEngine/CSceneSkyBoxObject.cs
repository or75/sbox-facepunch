using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000037 RID: 55
	internal struct CSceneSkyBoxObject
	{
		// Token: 0x06000876 RID: 2166 RVA: 0x00034C19 File Offset: 0x00032E19
		public static implicit operator IntPtr(CSceneSkyBoxObject value)
		{
			return value.self;
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00034C24 File Offset: 0x00032E24
		public static implicit operator CSceneSkyBoxObject(IntPtr value)
		{
			return new CSceneSkyBoxObject
			{
				self = value
			};
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00034C42 File Offset: 0x00032E42
		public static bool operator ==(CSceneSkyBoxObject c1, CSceneSkyBoxObject c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00034C55 File Offset: 0x00032E55
		public static bool operator !=(CSceneSkyBoxObject c1, CSceneSkyBoxObject c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00034C68 File Offset: 0x00032E68
		public override bool Equals(object obj)
		{
			if (obj is CSceneSkyBoxObject)
			{
				CSceneSkyBoxObject c = (CSceneSkyBoxObject)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x00034C92 File Offset: 0x00032E92
		internal CSceneSkyBoxObject(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x00034C9C File Offset: 0x00032E9C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(19, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CSceneSkyBoxObject ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600087D RID: 2173 RVA: 0x00034CD8 File Offset: 0x00032ED8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x00034CEA File Offset: 0x00032EEA
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00034CF5 File Offset: 0x00032EF5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00034D08 File Offset: 0x00032F08
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CSceneSkyBoxObject was null when calling " + n);
			}
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x00034D23 File Offset: 0x00032F23
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x00034D30 File Offset: 0x00032F30
		public static implicit operator CSceneObject(CSceneSkyBoxObject value)
		{
			method to_CSceneObject_From_CSceneSkyBoxObject = CSceneSkyBoxObject.__N.To_CSceneObject_From_CSceneSkyBoxObject;
			return calli(System.IntPtr(System.IntPtr), value, to_CSceneObject_From_CSceneSkyBoxObject);
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00034D54 File Offset: 0x00032F54
		public static explicit operator CSceneSkyBoxObject(CSceneObject value)
		{
			method from_CSceneObject_To_CSceneSkyBoxObject = CSceneSkyBoxObject.__N.From_CSceneObject_To_CSceneSkyBoxObject;
			return calli(System.IntPtr(System.IntPtr), value, from_CSceneObject_To_CSceneSkyBoxObject);
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x00034D78 File Offset: 0x00032F78
		internal unsafe readonly void SetLighting_ConstantColorHemisphere(Vector3 vSkyColor)
		{
			this.NullCheck("SetLighting_ConstantColorHemisphere");
			method cscene_SetLighting_ConstantColorHemisphere = CSceneSkyBoxObject.__N.CScene_SetLighting_ConstantColorHemisphere;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vSkyColor, cscene_SetLighting_ConstantColorHemisphere);
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00034DA8 File Offset: 0x00032FA8
		internal readonly void SetLighting_Samples(IntPtr pSkyColors, IntPtr pSkyDirections, int nSkyColors)
		{
			this.NullCheck("SetLighting_Samples");
			method cscene_SetLighting_Samples = CSceneSkyBoxObject.__N.CScene_SetLighting_Samples;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr,System.Int32), this.self, pSkyColors, pSkyDirections, nSkyColors, cscene_SetLighting_Samples);
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x00034DD8 File Offset: 0x00032FD8
		internal readonly IMaterial GetMaterial()
		{
			this.NullCheck("GetMaterial");
			method cscene_GetMaterial = CSceneSkyBoxObject.__N.CScene_GetMaterial;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_GetMaterial);
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00034E08 File Offset: 0x00033008
		internal readonly void SetMaterial(IMaterial hMaterial)
		{
			this.NullCheck("SetMaterial");
			method cscene_SetMaterial = CSceneSkyBoxObject.__N.CScene_SetMaterial;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, hMaterial, cscene_SetMaterial);
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00034E38 File Offset: 0x00033038
		internal unsafe readonly void SetSkyTint(Vector3 vTint)
		{
			this.NullCheck("SetSkyTint");
			method cscene_SetSkyTint = CSceneSkyBoxObject.__N.CScene_SetSkyTint;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vTint, cscene_SetSkyTint);
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00034E68 File Offset: 0x00033068
		internal readonly Vector3 GetSkyTint()
		{
			this.NullCheck("GetSkyTint");
			method cscene_GetSkyTint = CSceneSkyBoxObject.__N.CScene_GetSkyTint;
			return calli(Vector3(System.IntPtr), this.self, cscene_GetSkyTint);
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00034E94 File Offset: 0x00033094
		internal readonly void SetFogType(int nType)
		{
			this.NullCheck("SetFogType");
			method cscene_SetFogType = CSceneSkyBoxObject.__N.CScene_SetFogType;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nType, cscene_SetFogType);
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x00034EC0 File Offset: 0x000330C0
		internal readonly int GetFogType()
		{
			this.NullCheck("GetFogType");
			method cscene_GetFogType = CSceneSkyBoxObject.__N.CScene_GetFogType;
			return calli(System.Int32(System.IntPtr), this.self, cscene_GetFogType);
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x00034EEC File Offset: 0x000330EC
		internal readonly void SetAngularFogParams(float flFogMinStart, float flFogMinEnd, float flFogMaxStart, float flFogMaxEnd)
		{
			this.NullCheck("SetAngularFogParams");
			method cscene_SetAngularFogParams = CSceneSkyBoxObject.__N.CScene_SetAngularFogParams;
			calli(System.Void(System.IntPtr,System.Single,System.Single,System.Single,System.Single), this.self, flFogMinStart, flFogMinEnd, flFogMaxStart, flFogMaxEnd, cscene_SetAngularFogParams);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x00034F1C File Offset: 0x0003311C
		internal readonly float GetFogMinStart()
		{
			this.NullCheck("GetFogMinStart");
			method cscene_GetFogMinStart = CSceneSkyBoxObject.__N.CScene_GetFogMinStart;
			return calli(System.Single(System.IntPtr), this.self, cscene_GetFogMinStart);
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00034F48 File Offset: 0x00033148
		internal readonly float GetFogMinEnd()
		{
			this.NullCheck("GetFogMinEnd");
			method cscene_GetFogMinEnd = CSceneSkyBoxObject.__N.CScene_GetFogMinEnd;
			return calli(System.Single(System.IntPtr), this.self, cscene_GetFogMinEnd);
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x00034F74 File Offset: 0x00033174
		internal readonly float GetFogMaxStart()
		{
			this.NullCheck("GetFogMaxStart");
			method cscene_GetFogMaxStart = CSceneSkyBoxObject.__N.CScene_GetFogMaxStart;
			return calli(System.Single(System.IntPtr), this.self, cscene_GetFogMaxStart);
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00034FA0 File Offset: 0x000331A0
		internal readonly float GetFogMaxEnd()
		{
			this.NullCheck("GetFogMaxEnd");
			method cscene_GetFogMaxEnd = CSceneSkyBoxObject.__N.CScene_GetFogMaxEnd;
			return calli(System.Single(System.IntPtr), this.self, cscene_GetFogMaxEnd);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x00034FCC File Offset: 0x000331CC
		internal readonly void ChangeFlags(ESceneObjectFlags nNewFlags, ESceneObjectFlags nNewFlagsMask)
		{
			this.NullCheck("ChangeFlags");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f187;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, nNewFlags, nNewFlagsMask, cscene_f);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x00034FF8 File Offset: 0x000331F8
		internal readonly void SetFlags(ESceneObjectFlags nFlagsToOR)
		{
			this.NullCheck("SetFlags");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f188;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToOR, cscene_f);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x00035024 File Offset: 0x00033224
		internal readonly bool HasFlags(ESceneObjectFlags nFlags)
		{
			this.NullCheck("HasFlags");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f189;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, nFlags, cscene_f) > 0;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x00035054 File Offset: 0x00033254
		internal readonly ESceneObjectFlags GetFlags()
		{
			this.NullCheck("GetFlags");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f190;
			return calli(System.Int64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00035080 File Offset: 0x00033280
		internal readonly ESceneObjectFlags GetOriginalFlags()
		{
			this.NullCheck("GetOriginalFlags");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f191;
			return calli(System.Int64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x000350AC File Offset: 0x000332AC
		internal readonly void ClearFlags(ESceneObjectFlags nFlagsToClear)
		{
			this.NullCheck("ClearFlags");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f192;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToClear, cscene_f);
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x000350D8 File Offset: 0x000332D8
		internal readonly void SetCullDistance(float dist)
		{
			this.NullCheck("SetCullDistance");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f193;
			calli(System.Void(System.IntPtr,System.Single), this.self, dist, cscene_f);
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x00035104 File Offset: 0x00033304
		internal unsafe readonly void SetLightingOrigin(Vector3 vPos, bool worldspace)
		{
			this.NullCheck("SetLightingOrigin");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f194;
			calli(System.Void(System.IntPtr,Vector3*,System.Int32), this.self, &vPos, worldspace ? 1 : 0, cscene_f);
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00035138 File Offset: 0x00033338
		internal readonly Vector3 GetLightingOrigin()
		{
			this.NullCheck("GetLightingOrigin");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f195;
			return calli(Vector3(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00035164 File Offset: 0x00033364
		internal readonly bool HasLightingOrigin()
		{
			this.NullCheck("HasLightingOrigin");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f196;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x00035194 File Offset: 0x00033394
		internal unsafe readonly void SetTintRGBA(Vector4 color)
		{
			this.NullCheck("SetTintRGBA");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f197;
			calli(System.Void(System.IntPtr,Vector4*), this.self, &color, cscene_f);
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x000351C4 File Offset: 0x000333C4
		internal readonly Vector4 GetTintRGBA()
		{
			this.NullCheck("GetTintRGBA");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f198;
			return calli(Vector4(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x000351F0 File Offset: 0x000333F0
		internal readonly void SetAlphaFade(float nAlpha)
		{
			this.NullCheck("SetAlphaFade");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f199;
			calli(System.Void(System.IntPtr,System.Single), this.self, nAlpha, cscene_f);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x0003521C File Offset: 0x0003341C
		internal readonly float GetAlphaFade()
		{
			this.NullCheck("GetAlphaFade");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f200;
			return calli(System.Single(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x00035248 File Offset: 0x00033448
		internal readonly void SetMaterialOverride(IMaterial mat)
		{
			this.NullCheck("SetMaterialOverride");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f201;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, mat, cscene_f);
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00035278 File Offset: 0x00033478
		internal readonly void ClearMaterialOverrideList()
		{
			this.NullCheck("ClearMaterialOverrideList");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f202;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x000352A4 File Offset: 0x000334A4
		internal readonly bool IsLoaded()
		{
			this.NullCheck("IsLoaded");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f203;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000352D4 File Offset: 0x000334D4
		internal readonly bool IsRenderingEnabled()
		{
			this.NullCheck("IsRenderingEnabled");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f204;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x00035304 File Offset: 0x00033504
		internal readonly void SetLoaded()
		{
			this.NullCheck("SetLoaded");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f205;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00035330 File Offset: 0x00033530
		internal readonly void ClearLoaded()
		{
			this.NullCheck("ClearLoaded");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f206;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x0003535C File Offset: 0x0003355C
		internal readonly void DisableRendering()
		{
			this.NullCheck("DisableRendering");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f207;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00035388 File Offset: 0x00033588
		internal readonly void EnableRendering()
		{
			this.NullCheck("EnableRendering");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f208;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x000353B4 File Offset: 0x000335B4
		internal readonly void SetRenderingEnabled(bool bEnabled)
		{
			this.NullCheck("SetRenderingEnabled");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f209;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnabled ? 1 : 0, cscene_f);
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x000353E8 File Offset: 0x000335E8
		internal readonly float GetBoundingSphereRadius()
		{
			this.NullCheck("GetBoundingSphereRadius");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f210;
			return calli(System.Single(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00035414 File Offset: 0x00033614
		internal readonly void ScheduleDirtyUpdate()
		{
			this.NullCheck("ScheduleDirtyUpdate");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f211;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x00035440 File Offset: 0x00033640
		internal readonly void UnscheduleDirtyUpdate()
		{
			this.NullCheck("UnscheduleDirtyUpdate");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f212;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x0003546C File Offset: 0x0003366C
		internal unsafe readonly void SetTransform(Transform tx)
		{
			this.NullCheck("SetTransform");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f213;
			calli(System.Void(System.IntPtr,Transform*), this.self, &tx, cscene_f);
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x0003549C File Offset: 0x0003369C
		internal readonly Transform GetCTransform()
		{
			this.NullCheck("GetCTransform");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f214;
			return calli(Transform(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x000354C8 File Offset: 0x000336C8
		internal unsafe readonly void SetBounds(Vector3 mins, Vector3 maxs)
		{
			this.NullCheck("SetBounds");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f215;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), this.self, &mins, &maxs, cscene_f);
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x000354F8 File Offset: 0x000336F8
		internal readonly SceneObject GetParent()
		{
			this.NullCheck("GetParent");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f216;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr), this.self, cscene_f));
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00035528 File Offset: 0x00033728
		internal readonly void AddChildObject(string nId, SceneObject pChild, uint nChildUpdateFlags)
		{
			this.NullCheck("AddChildObject");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f217;
			calli(System.Void(System.IntPtr,System.UInt32,System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nId), (pChild == null) ? IntPtr.Zero : pChild.native, nChildUpdateFlags, cscene_f);
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00035570 File Offset: 0x00033770
		internal readonly void RemoveChild(SceneObject obj)
		{
			this.NullCheck("RemoveChild");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f218;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (obj == null) ? IntPtr.Zero : obj.native, cscene_f);
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x000355B0 File Offset: 0x000337B0
		internal readonly CRenderAttributes GetAttributesPtrForModify()
		{
			this.NullCheck("GetAttributesPtrForModify");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f219;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x000355E0 File Offset: 0x000337E0
		internal readonly void EnableMeshGroups(ulong nMask)
		{
			this.NullCheck("EnableMeshGroups");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f220;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x0003560C File Offset: 0x0003380C
		internal readonly void DisableMeshGroups(ulong nMask)
		{
			this.NullCheck("DisableMeshGroups");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f221;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00035638 File Offset: 0x00033838
		internal readonly void ResetMeshGroups(ulong nMask)
		{
			this.NullCheck("ResetMeshGroups");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f222;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00035664 File Offset: 0x00033864
		internal readonly ulong GetCurrentMeshGroupMask()
		{
			this.NullCheck("GetCurrentMeshGroupMask");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f223;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00035690 File Offset: 0x00033890
		internal readonly SceneWorld GetWorld()
		{
			this.NullCheck("GetWorld");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f224;
			return HandleIndex.Get<SceneWorld>(calli(System.Int32(System.IntPtr), this.self, cscene_f));
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x000356C0 File Offset: 0x000338C0
		internal readonly void SetLOD(int nLOD)
		{
			this.NullCheck("SetLOD");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f225;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLOD, cscene_f);
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x000356EC File Offset: 0x000338EC
		internal readonly void DisableLOD()
		{
			this.NullCheck("DisableLOD");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f226;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00035718 File Offset: 0x00033918
		internal readonly ulong GetCurrentLODGroupMask()
		{
			this.NullCheck("GetCurrentLODGroupMask");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f227;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00035744 File Offset: 0x00033944
		internal readonly int GetCurrentLODLevel()
		{
			this.NullCheck("GetCurrentLODLevel");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f228;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00035770 File Offset: 0x00033970
		internal readonly IModel GetModelHandle()
		{
			this.NullCheck("GetModelHandle");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f229;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x000357A0 File Offset: 0x000339A0
		internal readonly void SetMaterialGroup(string token)
		{
			this.NullCheck("SetMaterialGroup");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f230;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(token), cscene_f);
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x000357D0 File Offset: 0x000339D0
		internal readonly void SetBodyGroup(string token, int value)
		{
			this.NullCheck("SetBodyGroup");
			method cscene_f = CSceneSkyBoxObject.__N.CScene_f231;
			calli(System.Void(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(token), value, cscene_f);
		}

		// Token: 0x040000B3 RID: 179
		internal IntPtr self;

		// Token: 0x020001BC RID: 444
		internal static class __N
		{
			// Token: 0x04000DE5 RID: 3557
			internal static method From_CSceneObject_To_CSceneSkyBoxObject;

			// Token: 0x04000DE6 RID: 3558
			internal static method To_CSceneObject_From_CSceneSkyBoxObject;

			// Token: 0x04000DE7 RID: 3559
			internal static method CScene_SetLighting_ConstantColorHemisphere;

			// Token: 0x04000DE8 RID: 3560
			internal static method CScene_SetLighting_Samples;

			// Token: 0x04000DE9 RID: 3561
			internal static method CScene_GetMaterial;

			// Token: 0x04000DEA RID: 3562
			internal static method CScene_SetMaterial;

			// Token: 0x04000DEB RID: 3563
			internal static method CScene_SetSkyTint;

			// Token: 0x04000DEC RID: 3564
			internal static method CScene_GetSkyTint;

			// Token: 0x04000DED RID: 3565
			internal static method CScene_SetFogType;

			// Token: 0x04000DEE RID: 3566
			internal static method CScene_GetFogType;

			// Token: 0x04000DEF RID: 3567
			internal static method CScene_SetAngularFogParams;

			// Token: 0x04000DF0 RID: 3568
			internal static method CScene_GetFogMinStart;

			// Token: 0x04000DF1 RID: 3569
			internal static method CScene_GetFogMinEnd;

			// Token: 0x04000DF2 RID: 3570
			internal static method CScene_GetFogMaxStart;

			// Token: 0x04000DF3 RID: 3571
			internal static method CScene_GetFogMaxEnd;

			// Token: 0x04000DF4 RID: 3572
			internal static method CScene_f187;

			// Token: 0x04000DF5 RID: 3573
			internal static method CScene_f188;

			// Token: 0x04000DF6 RID: 3574
			internal static method CScene_f189;

			// Token: 0x04000DF7 RID: 3575
			internal static method CScene_f190;

			// Token: 0x04000DF8 RID: 3576
			internal static method CScene_f191;

			// Token: 0x04000DF9 RID: 3577
			internal static method CScene_f192;

			// Token: 0x04000DFA RID: 3578
			internal static method CScene_f193;

			// Token: 0x04000DFB RID: 3579
			internal static method CScene_f194;

			// Token: 0x04000DFC RID: 3580
			internal static method CScene_f195;

			// Token: 0x04000DFD RID: 3581
			internal static method CScene_f196;

			// Token: 0x04000DFE RID: 3582
			internal static method CScene_f197;

			// Token: 0x04000DFF RID: 3583
			internal static method CScene_f198;

			// Token: 0x04000E00 RID: 3584
			internal static method CScene_f199;

			// Token: 0x04000E01 RID: 3585
			internal static method CScene_f200;

			// Token: 0x04000E02 RID: 3586
			internal static method CScene_f201;

			// Token: 0x04000E03 RID: 3587
			internal static method CScene_f202;

			// Token: 0x04000E04 RID: 3588
			internal static method CScene_f203;

			// Token: 0x04000E05 RID: 3589
			internal static method CScene_f204;

			// Token: 0x04000E06 RID: 3590
			internal static method CScene_f205;

			// Token: 0x04000E07 RID: 3591
			internal static method CScene_f206;

			// Token: 0x04000E08 RID: 3592
			internal static method CScene_f207;

			// Token: 0x04000E09 RID: 3593
			internal static method CScene_f208;

			// Token: 0x04000E0A RID: 3594
			internal static method CScene_f209;

			// Token: 0x04000E0B RID: 3595
			internal static method CScene_f210;

			// Token: 0x04000E0C RID: 3596
			internal static method CScene_f211;

			// Token: 0x04000E0D RID: 3597
			internal static method CScene_f212;

			// Token: 0x04000E0E RID: 3598
			internal static method CScene_f213;

			// Token: 0x04000E0F RID: 3599
			internal static method CScene_f214;

			// Token: 0x04000E10 RID: 3600
			internal static method CScene_f215;

			// Token: 0x04000E11 RID: 3601
			internal static method CScene_f216;

			// Token: 0x04000E12 RID: 3602
			internal static method CScene_f217;

			// Token: 0x04000E13 RID: 3603
			internal static method CScene_f218;

			// Token: 0x04000E14 RID: 3604
			internal static method CScene_f219;

			// Token: 0x04000E15 RID: 3605
			internal static method CScene_f220;

			// Token: 0x04000E16 RID: 3606
			internal static method CScene_f221;

			// Token: 0x04000E17 RID: 3607
			internal static method CScene_f222;

			// Token: 0x04000E18 RID: 3608
			internal static method CScene_f223;

			// Token: 0x04000E19 RID: 3609
			internal static method CScene_f224;

			// Token: 0x04000E1A RID: 3610
			internal static method CScene_f225;

			// Token: 0x04000E1B RID: 3611
			internal static method CScene_f226;

			// Token: 0x04000E1C RID: 3612
			internal static method CScene_f227;

			// Token: 0x04000E1D RID: 3613
			internal static method CScene_f228;

			// Token: 0x04000E1E RID: 3614
			internal static method CScene_f229;

			// Token: 0x04000E1F RID: 3615
			internal static method CScene_f230;

			// Token: 0x04000E20 RID: 3616
			internal static method CScene_f231;
		}
	}
}
