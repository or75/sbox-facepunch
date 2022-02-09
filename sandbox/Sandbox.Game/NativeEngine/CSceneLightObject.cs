using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000033 RID: 51
	internal struct CSceneLightObject
	{
		// Token: 0x0600077B RID: 1915 RVA: 0x000322FD File Offset: 0x000304FD
		public static implicit operator IntPtr(CSceneLightObject value)
		{
			return value.self;
		}

		// Token: 0x0600077C RID: 1916 RVA: 0x00032308 File Offset: 0x00030508
		public static implicit operator CSceneLightObject(IntPtr value)
		{
			return new CSceneLightObject
			{
				self = value
			};
		}

		// Token: 0x0600077D RID: 1917 RVA: 0x00032326 File Offset: 0x00030526
		public static bool operator ==(CSceneLightObject c1, CSceneLightObject c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600077E RID: 1918 RVA: 0x00032339 File Offset: 0x00030539
		public static bool operator !=(CSceneLightObject c1, CSceneLightObject c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0003234C File Offset: 0x0003054C
		public override bool Equals(object obj)
		{
			if (obj is CSceneLightObject)
			{
				CSceneLightObject c = (CSceneLightObject)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x00032376 File Offset: 0x00030576
		internal CSceneLightObject(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x00032380 File Offset: 0x00030580
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CSceneLightObject ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000782 RID: 1922 RVA: 0x000323BC File Offset: 0x000305BC
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x000323CE File Offset: 0x000305CE
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x000323D9 File Offset: 0x000305D9
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x000323EC File Offset: 0x000305EC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CSceneLightObject was null when calling " + n);
			}
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x00032407 File Offset: 0x00030607
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x00032414 File Offset: 0x00030614
		public static implicit operator CSceneObject(CSceneLightObject value)
		{
			method to_CSceneObject_From_CSceneLightObject = CSceneLightObject.__N.To_CSceneObject_From_CSceneLightObject;
			return calli(System.IntPtr(System.IntPtr), value, to_CSceneObject_From_CSceneLightObject);
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00032438 File Offset: 0x00030638
		public static explicit operator CSceneLightObject(CSceneObject value)
		{
			method from_CSceneObject_To_CSceneLightObject = CSceneLightObject.__N.From_CSceneObject_To_CSceneLightObject;
			return calli(System.IntPtr(System.IntPtr), value, from_CSceneObject_To_CSceneLightObject);
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0003245C File Offset: 0x0003065C
		internal unsafe readonly bool UpdateLight(LightDesc pLightDesc)
		{
			this.NullCheck("UpdateLight");
			method cscene_UpdateLight = CSceneLightObject.__N.CScene_UpdateLight;
			return calli(System.Int32(System.IntPtr,NativeEngine.LightDesc*), this.self, &pLightDesc, cscene_UpdateLight) > 0;
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0003248C File Offset: 0x0003068C
		internal unsafe readonly LightDesc GetLightDescForModify()
		{
			this.NullCheck("GetLightDescForModify");
			method cscene_GetLightDescForModify = CSceneLightObject.__N.CScene_GetLightDescForModify;
			return *Unsafe.AsRef<LightDesc>((void*)calli(System.IntPtr(System.IntPtr), this.self, cscene_GetLightDescForModify));
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x000324C8 File Offset: 0x000306C8
		internal unsafe readonly void SetWorldPosition(Vector3 pos)
		{
			this.NullCheck("SetWorldPosition");
			method cscene_SetWorldPosition = CSceneLightObject.__N.CScene_SetWorldPosition;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &pos, cscene_SetWorldPosition);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x000324F8 File Offset: 0x000306F8
		internal readonly Vector3 GetWorldPosition()
		{
			this.NullCheck("GetWorldPosition");
			method cscene_GetWorldPosition = CSceneLightObject.__N.CScene_GetWorldPosition;
			return calli(Vector3(System.IntPtr), this.self, cscene_GetWorldPosition);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x00032524 File Offset: 0x00030724
		internal unsafe readonly void SetWorldDirection(Vector3 dir)
		{
			this.NullCheck("SetWorldDirection");
			method cscene_SetWorldDirection = CSceneLightObject.__N.CScene_SetWorldDirection;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &dir, cscene_SetWorldDirection);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00032554 File Offset: 0x00030754
		internal readonly Vector3 GetWorldDirection()
		{
			this.NullCheck("GetWorldDirection");
			method cscene_GetWorldDirection = CSceneLightObject.__N.CScene_GetWorldDirection;
			return calli(Vector3(System.IntPtr), this.self, cscene_GetWorldDirection);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00032580 File Offset: 0x00030780
		internal unsafe readonly void SetColor(Vector3 color)
		{
			this.NullCheck("SetColor");
			method cscene_SetColor = CSceneLightObject.__N.CScene_SetColor;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &color, cscene_SetColor);
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x000325B0 File Offset: 0x000307B0
		internal readonly Vector3 GetColor()
		{
			this.NullCheck("GetColor");
			method cscene_GetColor = CSceneLightObject.__N.CScene_GetColor;
			return calli(Vector3(System.IntPtr), this.self, cscene_GetColor);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x000325DC File Offset: 0x000307DC
		internal readonly void SetFalloff(float falloff)
		{
			this.NullCheck("SetFalloff");
			method cscene_SetFalloff = CSceneLightObject.__N.CScene_SetFalloff;
			calli(System.Void(System.IntPtr,System.Single), this.self, falloff, cscene_SetFalloff);
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x00032608 File Offset: 0x00030808
		internal readonly float GetFalloff()
		{
			this.NullCheck("GetFalloff");
			method cscene_GetFalloff = CSceneLightObject.__N.CScene_GetFalloff;
			return calli(System.Single(System.IntPtr), this.self, cscene_GetFalloff);
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x00032634 File Offset: 0x00030834
		internal readonly void SetRadius(float radius)
		{
			this.NullCheck("SetRadius");
			method cscene_SetRadius = CSceneLightObject.__N.CScene_SetRadius;
			calli(System.Void(System.IntPtr,System.Single), this.self, radius, cscene_SetRadius);
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x00032660 File Offset: 0x00030860
		internal readonly float GetRadius()
		{
			this.NullCheck("GetRadius");
			method cscene_GetRadius = CSceneLightObject.__N.CScene_GetRadius;
			return calli(System.Single(System.IntPtr), this.self, cscene_GetRadius);
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0003268C File Offset: 0x0003088C
		internal readonly void SetSpotCone(float inner, float outer)
		{
			this.NullCheck("SetSpotCone");
			method cscene_SetSpotCone = CSceneLightObject.__N.CScene_SetSpotCone;
			calli(System.Void(System.IntPtr,System.Single,System.Single), this.self, inner, outer, cscene_SetSpotCone);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x000326B8 File Offset: 0x000308B8
		internal readonly float GetSpotInnerCone()
		{
			this.NullCheck("GetSpotInnerCone");
			method cscene_GetSpotInnerCone = CSceneLightObject.__N.CScene_GetSpotInnerCone;
			return calli(System.Single(System.IntPtr), this.self, cscene_GetSpotInnerCone);
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x000326E4 File Offset: 0x000308E4
		internal readonly float GetSpotOuterCone()
		{
			this.NullCheck("GetSpotOuterCone");
			method cscene_GetSpotOuterCone = CSceneLightObject.__N.CScene_GetSpotOuterCone;
			return calli(System.Single(System.IntPtr), this.self, cscene_GetSpotOuterCone);
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x00032710 File Offset: 0x00030910
		internal readonly void ChangeFlags(ESceneObjectFlags nNewFlags, ESceneObjectFlags nNewFlagsMask)
		{
			this.NullCheck("ChangeFlags");
			method cscene_f = CSceneLightObject.__N.CScene_f7;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, nNewFlags, nNewFlagsMask, cscene_f);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x0003273C File Offset: 0x0003093C
		internal readonly void SetFlags(ESceneObjectFlags nFlagsToOR)
		{
			this.NullCheck("SetFlags");
			method cscene_f = CSceneLightObject.__N.CScene_f8;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToOR, cscene_f);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00032768 File Offset: 0x00030968
		internal readonly bool HasFlags(ESceneObjectFlags nFlags)
		{
			this.NullCheck("HasFlags");
			method cscene_f = CSceneLightObject.__N.CScene_f9;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, nFlags, cscene_f) > 0;
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00032798 File Offset: 0x00030998
		internal readonly ESceneObjectFlags GetFlags()
		{
			this.NullCheck("GetFlags");
			method cscene_f = CSceneLightObject.__N.CScene_f10;
			return calli(System.Int64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x000327C4 File Offset: 0x000309C4
		internal readonly ESceneObjectFlags GetOriginalFlags()
		{
			this.NullCheck("GetOriginalFlags");
			method cscene_f = CSceneLightObject.__N.CScene_f11;
			return calli(System.Int64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x000327F0 File Offset: 0x000309F0
		internal readonly void ClearFlags(ESceneObjectFlags nFlagsToClear)
		{
			this.NullCheck("ClearFlags");
			method cscene_f = CSceneLightObject.__N.CScene_f12;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToClear, cscene_f);
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x0003281C File Offset: 0x00030A1C
		internal readonly void SetCullDistance(float dist)
		{
			this.NullCheck("SetCullDistance");
			method cscene_f = CSceneLightObject.__N.CScene_f13;
			calli(System.Void(System.IntPtr,System.Single), this.self, dist, cscene_f);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00032848 File Offset: 0x00030A48
		internal unsafe readonly void SetLightingOrigin(Vector3 vPos, bool worldspace)
		{
			this.NullCheck("SetLightingOrigin");
			method cscene_f = CSceneLightObject.__N.CScene_f14;
			calli(System.Void(System.IntPtr,Vector3*,System.Int32), this.self, &vPos, worldspace ? 1 : 0, cscene_f);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x0003287C File Offset: 0x00030A7C
		internal readonly Vector3 GetLightingOrigin()
		{
			this.NullCheck("GetLightingOrigin");
			method cscene_f = CSceneLightObject.__N.CScene_f15;
			return calli(Vector3(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x000328A8 File Offset: 0x00030AA8
		internal readonly bool HasLightingOrigin()
		{
			this.NullCheck("HasLightingOrigin");
			method cscene_f = CSceneLightObject.__N.CScene_f16;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x000328D8 File Offset: 0x00030AD8
		internal unsafe readonly void SetTintRGBA(Vector4 color)
		{
			this.NullCheck("SetTintRGBA");
			method cscene_f = CSceneLightObject.__N.CScene_f17;
			calli(System.Void(System.IntPtr,Vector4*), this.self, &color, cscene_f);
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00032908 File Offset: 0x00030B08
		internal readonly Vector4 GetTintRGBA()
		{
			this.NullCheck("GetTintRGBA");
			method cscene_f = CSceneLightObject.__N.CScene_f18;
			return calli(Vector4(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x00032934 File Offset: 0x00030B34
		internal readonly void SetAlphaFade(float nAlpha)
		{
			this.NullCheck("SetAlphaFade");
			method cscene_f = CSceneLightObject.__N.CScene_f19;
			calli(System.Void(System.IntPtr,System.Single), this.self, nAlpha, cscene_f);
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00032960 File Offset: 0x00030B60
		internal readonly float GetAlphaFade()
		{
			this.NullCheck("GetAlphaFade");
			method cscene_f = CSceneLightObject.__N.CScene_f20;
			return calli(System.Single(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x0003298C File Offset: 0x00030B8C
		internal readonly void SetMaterialOverride(IMaterial mat)
		{
			this.NullCheck("SetMaterialOverride");
			method cscene_f = CSceneLightObject.__N.CScene_f21;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, mat, cscene_f);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x000329BC File Offset: 0x00030BBC
		internal readonly void ClearMaterialOverrideList()
		{
			this.NullCheck("ClearMaterialOverrideList");
			method cscene_f = CSceneLightObject.__N.CScene_f22;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x000329E8 File Offset: 0x00030BE8
		internal readonly bool IsLoaded()
		{
			this.NullCheck("IsLoaded");
			method cscene_f = CSceneLightObject.__N.CScene_f23;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x00032A18 File Offset: 0x00030C18
		internal readonly bool IsRenderingEnabled()
		{
			this.NullCheck("IsRenderingEnabled");
			method cscene_f = CSceneLightObject.__N.CScene_f24;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f) > 0;
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00032A48 File Offset: 0x00030C48
		internal readonly void SetLoaded()
		{
			this.NullCheck("SetLoaded");
			method cscene_f = CSceneLightObject.__N.CScene_f25;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00032A74 File Offset: 0x00030C74
		internal readonly void ClearLoaded()
		{
			this.NullCheck("ClearLoaded");
			method cscene_f = CSceneLightObject.__N.CScene_f26;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00032AA0 File Offset: 0x00030CA0
		internal readonly void DisableRendering()
		{
			this.NullCheck("DisableRendering");
			method cscene_f = CSceneLightObject.__N.CScene_f27;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x00032ACC File Offset: 0x00030CCC
		internal readonly void EnableRendering()
		{
			this.NullCheck("EnableRendering");
			method cscene_f = CSceneLightObject.__N.CScene_f28;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x00032AF8 File Offset: 0x00030CF8
		internal readonly void SetRenderingEnabled(bool bEnabled)
		{
			this.NullCheck("SetRenderingEnabled");
			method cscene_f = CSceneLightObject.__N.CScene_f29;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnabled ? 1 : 0, cscene_f);
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00032B2C File Offset: 0x00030D2C
		internal readonly float GetBoundingSphereRadius()
		{
			this.NullCheck("GetBoundingSphereRadius");
			method cscene_f = CSceneLightObject.__N.CScene_f30;
			return calli(System.Single(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00032B58 File Offset: 0x00030D58
		internal readonly void ScheduleDirtyUpdate()
		{
			this.NullCheck("ScheduleDirtyUpdate");
			method cscene_f = CSceneLightObject.__N.CScene_f31;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00032B84 File Offset: 0x00030D84
		internal readonly void UnscheduleDirtyUpdate()
		{
			this.NullCheck("UnscheduleDirtyUpdate");
			method cscene_f = CSceneLightObject.__N.CScene_f32;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x00032BB0 File Offset: 0x00030DB0
		internal unsafe readonly void SetTransform(Transform tx)
		{
			this.NullCheck("SetTransform");
			method cscene_f = CSceneLightObject.__N.CScene_f33;
			calli(System.Void(System.IntPtr,Transform*), this.self, &tx, cscene_f);
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00032BE0 File Offset: 0x00030DE0
		internal readonly Transform GetCTransform()
		{
			this.NullCheck("GetCTransform");
			method cscene_f = CSceneLightObject.__N.CScene_f34;
			return calli(Transform(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00032C0C File Offset: 0x00030E0C
		internal unsafe readonly void SetBounds(Vector3 mins, Vector3 maxs)
		{
			this.NullCheck("SetBounds");
			method cscene_f = CSceneLightObject.__N.CScene_f35;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), this.self, &mins, &maxs, cscene_f);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00032C3C File Offset: 0x00030E3C
		internal readonly SceneObject GetParent()
		{
			this.NullCheck("GetParent");
			method cscene_f = CSceneLightObject.__N.CScene_f36;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr), this.self, cscene_f));
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x00032C6C File Offset: 0x00030E6C
		internal readonly void AddChildObject(string nId, SceneObject pChild, uint nChildUpdateFlags)
		{
			this.NullCheck("AddChildObject");
			method cscene_f = CSceneLightObject.__N.CScene_f37;
			calli(System.Void(System.IntPtr,System.UInt32,System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nId), (pChild == null) ? IntPtr.Zero : pChild.native, nChildUpdateFlags, cscene_f);
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x00032CB4 File Offset: 0x00030EB4
		internal readonly void RemoveChild(SceneObject obj)
		{
			this.NullCheck("RemoveChild");
			method cscene_f = CSceneLightObject.__N.CScene_f38;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (obj == null) ? IntPtr.Zero : obj.native, cscene_f);
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00032CF4 File Offset: 0x00030EF4
		internal readonly CRenderAttributes GetAttributesPtrForModify()
		{
			this.NullCheck("GetAttributesPtrForModify");
			method cscene_f = CSceneLightObject.__N.CScene_f39;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00032D24 File Offset: 0x00030F24
		internal readonly void EnableMeshGroups(ulong nMask)
		{
			this.NullCheck("EnableMeshGroups");
			method cscene_f = CSceneLightObject.__N.CScene_f40;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x00032D50 File Offset: 0x00030F50
		internal readonly void DisableMeshGroups(ulong nMask)
		{
			this.NullCheck("DisableMeshGroups");
			method cscene_f = CSceneLightObject.__N.CScene_f41;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x00032D7C File Offset: 0x00030F7C
		internal readonly void ResetMeshGroups(ulong nMask)
		{
			this.NullCheck("ResetMeshGroups");
			method cscene_f = CSceneLightObject.__N.CScene_f42;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_f);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x00032DA8 File Offset: 0x00030FA8
		internal readonly ulong GetCurrentMeshGroupMask()
		{
			this.NullCheck("GetCurrentMeshGroupMask");
			method cscene_f = CSceneLightObject.__N.CScene_f43;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x00032DD4 File Offset: 0x00030FD4
		internal readonly SceneWorld GetWorld()
		{
			this.NullCheck("GetWorld");
			method cscene_f = CSceneLightObject.__N.CScene_f44;
			return HandleIndex.Get<SceneWorld>(calli(System.Int32(System.IntPtr), this.self, cscene_f));
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x00032E04 File Offset: 0x00031004
		internal readonly void SetLOD(int nLOD)
		{
			this.NullCheck("SetLOD");
			method cscene_f = CSceneLightObject.__N.CScene_f45;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLOD, cscene_f);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x00032E30 File Offset: 0x00031030
		internal readonly void DisableLOD()
		{
			this.NullCheck("DisableLOD");
			method cscene_f = CSceneLightObject.__N.CScene_f46;
			calli(System.Void(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00032E5C File Offset: 0x0003105C
		internal readonly ulong GetCurrentLODGroupMask()
		{
			this.NullCheck("GetCurrentLODGroupMask");
			method cscene_f = CSceneLightObject.__N.CScene_f47;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00032E88 File Offset: 0x00031088
		internal readonly int GetCurrentLODLevel()
		{
			this.NullCheck("GetCurrentLODLevel");
			method cscene_f = CSceneLightObject.__N.CScene_f48;
			return calli(System.Int32(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00032EB4 File Offset: 0x000310B4
		internal readonly IModel GetModelHandle()
		{
			this.NullCheck("GetModelHandle");
			method cscene_f = CSceneLightObject.__N.CScene_f49;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_f);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x00032EE4 File Offset: 0x000310E4
		internal readonly void SetMaterialGroup(string token)
		{
			this.NullCheck("SetMaterialGroup");
			method cscene_f = CSceneLightObject.__N.CScene_f50;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(token), cscene_f);
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x00032F14 File Offset: 0x00031114
		internal readonly void SetBodyGroup(string token, int value)
		{
			this.NullCheck("SetBodyGroup");
			method cscene_f = CSceneLightObject.__N.CScene_f51;
			calli(System.Void(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(token), value, cscene_f);
		}

		// Token: 0x040000AF RID: 175
		internal IntPtr self;

		// Token: 0x020001B8 RID: 440
		internal static class __N
		{
			// Token: 0x04000D1A RID: 3354
			internal static method From_CSceneObject_To_CSceneLightObject;

			// Token: 0x04000D1B RID: 3355
			internal static method To_CSceneObject_From_CSceneLightObject;

			// Token: 0x04000D1C RID: 3356
			internal static method CScene_UpdateLight;

			// Token: 0x04000D1D RID: 3357
			internal static method CScene_GetLightDescForModify;

			// Token: 0x04000D1E RID: 3358
			internal static method CScene_SetWorldPosition;

			// Token: 0x04000D1F RID: 3359
			internal static method CScene_GetWorldPosition;

			// Token: 0x04000D20 RID: 3360
			internal static method CScene_SetWorldDirection;

			// Token: 0x04000D21 RID: 3361
			internal static method CScene_GetWorldDirection;

			// Token: 0x04000D22 RID: 3362
			internal static method CScene_SetColor;

			// Token: 0x04000D23 RID: 3363
			internal static method CScene_GetColor;

			// Token: 0x04000D24 RID: 3364
			internal static method CScene_SetFalloff;

			// Token: 0x04000D25 RID: 3365
			internal static method CScene_GetFalloff;

			// Token: 0x04000D26 RID: 3366
			internal static method CScene_SetRadius;

			// Token: 0x04000D27 RID: 3367
			internal static method CScene_GetRadius;

			// Token: 0x04000D28 RID: 3368
			internal static method CScene_SetSpotCone;

			// Token: 0x04000D29 RID: 3369
			internal static method CScene_GetSpotInnerCone;

			// Token: 0x04000D2A RID: 3370
			internal static method CScene_GetSpotOuterCone;

			// Token: 0x04000D2B RID: 3371
			internal static method CScene_f7;

			// Token: 0x04000D2C RID: 3372
			internal static method CScene_f8;

			// Token: 0x04000D2D RID: 3373
			internal static method CScene_f9;

			// Token: 0x04000D2E RID: 3374
			internal static method CScene_f10;

			// Token: 0x04000D2F RID: 3375
			internal static method CScene_f11;

			// Token: 0x04000D30 RID: 3376
			internal static method CScene_f12;

			// Token: 0x04000D31 RID: 3377
			internal static method CScene_f13;

			// Token: 0x04000D32 RID: 3378
			internal static method CScene_f14;

			// Token: 0x04000D33 RID: 3379
			internal static method CScene_f15;

			// Token: 0x04000D34 RID: 3380
			internal static method CScene_f16;

			// Token: 0x04000D35 RID: 3381
			internal static method CScene_f17;

			// Token: 0x04000D36 RID: 3382
			internal static method CScene_f18;

			// Token: 0x04000D37 RID: 3383
			internal static method CScene_f19;

			// Token: 0x04000D38 RID: 3384
			internal static method CScene_f20;

			// Token: 0x04000D39 RID: 3385
			internal static method CScene_f21;

			// Token: 0x04000D3A RID: 3386
			internal static method CScene_f22;

			// Token: 0x04000D3B RID: 3387
			internal static method CScene_f23;

			// Token: 0x04000D3C RID: 3388
			internal static method CScene_f24;

			// Token: 0x04000D3D RID: 3389
			internal static method CScene_f25;

			// Token: 0x04000D3E RID: 3390
			internal static method CScene_f26;

			// Token: 0x04000D3F RID: 3391
			internal static method CScene_f27;

			// Token: 0x04000D40 RID: 3392
			internal static method CScene_f28;

			// Token: 0x04000D41 RID: 3393
			internal static method CScene_f29;

			// Token: 0x04000D42 RID: 3394
			internal static method CScene_f30;

			// Token: 0x04000D43 RID: 3395
			internal static method CScene_f31;

			// Token: 0x04000D44 RID: 3396
			internal static method CScene_f32;

			// Token: 0x04000D45 RID: 3397
			internal static method CScene_f33;

			// Token: 0x04000D46 RID: 3398
			internal static method CScene_f34;

			// Token: 0x04000D47 RID: 3399
			internal static method CScene_f35;

			// Token: 0x04000D48 RID: 3400
			internal static method CScene_f36;

			// Token: 0x04000D49 RID: 3401
			internal static method CScene_f37;

			// Token: 0x04000D4A RID: 3402
			internal static method CScene_f38;

			// Token: 0x04000D4B RID: 3403
			internal static method CScene_f39;

			// Token: 0x04000D4C RID: 3404
			internal static method CScene_f40;

			// Token: 0x04000D4D RID: 3405
			internal static method CScene_f41;

			// Token: 0x04000D4E RID: 3406
			internal static method CScene_f42;

			// Token: 0x04000D4F RID: 3407
			internal static method CScene_f43;

			// Token: 0x04000D50 RID: 3408
			internal static method CScene_f44;

			// Token: 0x04000D51 RID: 3409
			internal static method CScene_f45;

			// Token: 0x04000D52 RID: 3410
			internal static method CScene_f46;

			// Token: 0x04000D53 RID: 3411
			internal static method CScene_f47;

			// Token: 0x04000D54 RID: 3412
			internal static method CScene_f48;

			// Token: 0x04000D55 RID: 3413
			internal static method CScene_f49;

			// Token: 0x04000D56 RID: 3414
			internal static method CScene_f50;

			// Token: 0x04000D57 RID: 3415
			internal static method CScene_f51;
		}
	}
}
