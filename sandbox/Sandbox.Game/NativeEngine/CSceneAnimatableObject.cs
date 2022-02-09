using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000032 RID: 50
	internal struct CSceneAnimatableObject
	{
		// Token: 0x06000737 RID: 1847 RVA: 0x000317AC File Offset: 0x0002F9AC
		public static implicit operator IntPtr(CSceneAnimatableObject value)
		{
			return value.self;
		}

		// Token: 0x06000738 RID: 1848 RVA: 0x000317B4 File Offset: 0x0002F9B4
		public static implicit operator CSceneAnimatableObject(IntPtr value)
		{
			return new CSceneAnimatableObject
			{
				self = value
			};
		}

		// Token: 0x06000739 RID: 1849 RVA: 0x000317D2 File Offset: 0x0002F9D2
		public static bool operator ==(CSceneAnimatableObject c1, CSceneAnimatableObject c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600073A RID: 1850 RVA: 0x000317E5 File Offset: 0x0002F9E5
		public static bool operator !=(CSceneAnimatableObject c1, CSceneAnimatableObject c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600073B RID: 1851 RVA: 0x000317F8 File Offset: 0x0002F9F8
		public override bool Equals(object obj)
		{
			if (obj is CSceneAnimatableObject)
			{
				CSceneAnimatableObject c = (CSceneAnimatableObject)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600073C RID: 1852 RVA: 0x00031822 File Offset: 0x0002FA22
		internal CSceneAnimatableObject(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600073D RID: 1853 RVA: 0x0003182C File Offset: 0x0002FA2C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(23, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CSceneAnimatableObject ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x0600073E RID: 1854 RVA: 0x00031868 File Offset: 0x0002FA68
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x0600073F RID: 1855 RVA: 0x0003187A File Offset: 0x0002FA7A
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000740 RID: 1856 RVA: 0x00031885 File Offset: 0x0002FA85
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000741 RID: 1857 RVA: 0x00031898 File Offset: 0x0002FA98
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CSceneAnimatableObject was null when calling " + n);
			}
		}

		// Token: 0x06000742 RID: 1858 RVA: 0x000318B3 File Offset: 0x0002FAB3
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000743 RID: 1859 RVA: 0x000318C0 File Offset: 0x0002FAC0
		public static implicit operator CSceneObject(CSceneAnimatableObject value)
		{
			method to_CSceneObject_From_CSceneAnimatableObject = CSceneAnimatableObject.__N.To_CSceneObject_From_CSceneAnimatableObject;
			return calli(System.IntPtr(System.IntPtr), value, to_CSceneObject_From_CSceneAnimatableObject);
		}

		// Token: 0x06000744 RID: 1860 RVA: 0x000318E4 File Offset: 0x0002FAE4
		public static explicit operator CSceneAnimatableObject(CSceneObject value)
		{
			method from_CSceneObject_To_CSceneAnimatableObject = CSceneAnimatableObject.__N.From_CSceneObject_To_CSceneAnimatableObject;
			return calli(System.IntPtr(System.IntPtr), value, from_CSceneObject_To_CSceneAnimatableObject);
		}

		// Token: 0x06000745 RID: 1861 RVA: 0x00031908 File Offset: 0x0002FB08
		internal unsafe readonly void SetWorldSpaceRenderBoneTransform(int nBoneIndex, Transform pRenderWorldTransform)
		{
			this.NullCheck("SetWorldSpaceRenderBoneTransform");
			method cscene_SetWorldSpaceRenderBoneTransform = CSceneAnimatableObject.__N.CScene_SetWorldSpaceRenderBoneTransform;
			calli(System.Void(System.IntPtr,System.Int32,Transform*), this.self, nBoneIndex, &pRenderWorldTransform, cscene_SetWorldSpaceRenderBoneTransform);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x00031938 File Offset: 0x0002FB38
		internal readonly Transform GetWorldSpaceRenderBoneTransform(int nBoneIndex)
		{
			this.NullCheck("GetWorldSpaceRenderBoneTransform");
			method cscene_GetWorldSpaceRenderBoneTransform = CSceneAnimatableObject.__N.CScene_GetWorldSpaceRenderBoneTransform;
			return calli(Transform(System.IntPtr,System.Int32), this.self, nBoneIndex, cscene_GetWorldSpaceRenderBoneTransform);
		}

		// Token: 0x06000747 RID: 1863 RVA: 0x00031964 File Offset: 0x0002FB64
		internal readonly Transform GetWorldSpaceRenderBoneTransform(string boneName)
		{
			this.NullCheck("GetWorldSpaceRenderBoneTransform");
			method cscene_f = CSceneAnimatableObject.__N.CScene_f2;
			return calli(Transform(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(boneName), cscene_f);
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x00031994 File Offset: 0x0002FB94
		internal readonly void Update(float dt)
		{
			this.NullCheck("Update");
			method cscene_Update = CSceneAnimatableObject.__N.CScene_Update;
			calli(System.Void(System.IntPtr,System.Single), this.self, dt, cscene_Update);
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x000319C0 File Offset: 0x0002FBC0
		internal readonly void SetGraphParameter(string name, bool val)
		{
			this.NullCheck("SetGraphParameter");
			method cscene_SetGraphParameter = CSceneAnimatableObject.__N.CScene_SetGraphParameter;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(name), val ? 1 : 0, cscene_SetGraphParameter);
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x000319F8 File Offset: 0x0002FBF8
		internal readonly void SetGraphParameter(string name, int val)
		{
			this.NullCheck("SetGraphParameter");
			method cscene_f = CSceneAnimatableObject.__N.CScene_f3;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(name), val, cscene_f);
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x00031A2C File Offset: 0x0002FC2C
		internal readonly void SetGraphParameter(string name, float val)
		{
			this.NullCheck("SetGraphParameter");
			method cscene_f = CSceneAnimatableObject.__N.CScene_f4;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(name), val, cscene_f);
		}

		// Token: 0x0600074C RID: 1868 RVA: 0x00031A60 File Offset: 0x0002FC60
		internal unsafe readonly void SetGraphParameter(string name, Vector3 val)
		{
			this.NullCheck("SetGraphParameter");
			method cscene_f = CSceneAnimatableObject.__N.CScene_f5;
			calli(System.Void(System.IntPtr,System.IntPtr,Vector3*), this.self, Interop.GetPointer(name), &val, cscene_f);
		}

		// Token: 0x0600074D RID: 1869 RVA: 0x00031A94 File Offset: 0x0002FC94
		internal unsafe readonly void SetGraphParameter(string name, Rotation val)
		{
			this.NullCheck("SetGraphParameter");
			method cscene_f = CSceneAnimatableObject.__N.CScene_f6;
			calli(System.Void(System.IntPtr,System.IntPtr,Rotation*), this.self, Interop.GetPointer(name), &val, cscene_f);
		}

		// Token: 0x0600074E RID: 1870 RVA: 0x00031AC8 File Offset: 0x0002FCC8
		internal readonly void ChangeFlags(ESceneObjectFlags nNewFlags, ESceneObjectFlags nNewFlagsMask)
		{
			this.NullCheck("ChangeFlags");
			method cscene_ChangeFlags = CSceneAnimatableObject.__N.CScene_ChangeFlags;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, nNewFlags, nNewFlagsMask, cscene_ChangeFlags);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x00031AF4 File Offset: 0x0002FCF4
		internal readonly void SetFlags(ESceneObjectFlags nFlagsToOR)
		{
			this.NullCheck("SetFlags");
			method cscene_SetFlags = CSceneAnimatableObject.__N.CScene_SetFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToOR, cscene_SetFlags);
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x00031B20 File Offset: 0x0002FD20
		internal readonly bool HasFlags(ESceneObjectFlags nFlags)
		{
			this.NullCheck("HasFlags");
			method cscene_HasFlags = CSceneAnimatableObject.__N.CScene_HasFlags;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, nFlags, cscene_HasFlags) > 0;
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x00031B50 File Offset: 0x0002FD50
		internal readonly ESceneObjectFlags GetFlags()
		{
			this.NullCheck("GetFlags");
			method cscene_GetFlags = CSceneAnimatableObject.__N.CScene_GetFlags;
			return calli(System.Int64(System.IntPtr), this.self, cscene_GetFlags);
		}

		// Token: 0x06000752 RID: 1874 RVA: 0x00031B7C File Offset: 0x0002FD7C
		internal readonly ESceneObjectFlags GetOriginalFlags()
		{
			this.NullCheck("GetOriginalFlags");
			method cscene_GetOriginalFlags = CSceneAnimatableObject.__N.CScene_GetOriginalFlags;
			return calli(System.Int64(System.IntPtr), this.self, cscene_GetOriginalFlags);
		}

		// Token: 0x06000753 RID: 1875 RVA: 0x00031BA8 File Offset: 0x0002FDA8
		internal readonly void ClearFlags(ESceneObjectFlags nFlagsToClear)
		{
			this.NullCheck("ClearFlags");
			method cscene_ClearFlags = CSceneAnimatableObject.__N.CScene_ClearFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToClear, cscene_ClearFlags);
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00031BD4 File Offset: 0x0002FDD4
		internal readonly void SetCullDistance(float dist)
		{
			this.NullCheck("SetCullDistance");
			method cscene_SetCullDistance = CSceneAnimatableObject.__N.CScene_SetCullDistance;
			calli(System.Void(System.IntPtr,System.Single), this.self, dist, cscene_SetCullDistance);
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00031C00 File Offset: 0x0002FE00
		internal unsafe readonly void SetLightingOrigin(Vector3 vPos, bool worldspace)
		{
			this.NullCheck("SetLightingOrigin");
			method cscene_SetLightingOrigin = CSceneAnimatableObject.__N.CScene_SetLightingOrigin;
			calli(System.Void(System.IntPtr,Vector3*,System.Int32), this.self, &vPos, worldspace ? 1 : 0, cscene_SetLightingOrigin);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00031C34 File Offset: 0x0002FE34
		internal readonly Vector3 GetLightingOrigin()
		{
			this.NullCheck("GetLightingOrigin");
			method cscene_GetLightingOrigin = CSceneAnimatableObject.__N.CScene_GetLightingOrigin;
			return calli(Vector3(System.IntPtr), this.self, cscene_GetLightingOrigin);
		}

		// Token: 0x06000757 RID: 1879 RVA: 0x00031C60 File Offset: 0x0002FE60
		internal readonly bool HasLightingOrigin()
		{
			this.NullCheck("HasLightingOrigin");
			method cscene_HasLightingOrigin = CSceneAnimatableObject.__N.CScene_HasLightingOrigin;
			return calli(System.Int32(System.IntPtr), this.self, cscene_HasLightingOrigin) > 0;
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00031C90 File Offset: 0x0002FE90
		internal unsafe readonly void SetTintRGBA(Vector4 color)
		{
			this.NullCheck("SetTintRGBA");
			method cscene_SetTintRGBA = CSceneAnimatableObject.__N.CScene_SetTintRGBA;
			calli(System.Void(System.IntPtr,Vector4*), this.self, &color, cscene_SetTintRGBA);
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00031CC0 File Offset: 0x0002FEC0
		internal readonly Vector4 GetTintRGBA()
		{
			this.NullCheck("GetTintRGBA");
			method cscene_GetTintRGBA = CSceneAnimatableObject.__N.CScene_GetTintRGBA;
			return calli(Vector4(System.IntPtr), this.self, cscene_GetTintRGBA);
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x00031CEC File Offset: 0x0002FEEC
		internal readonly void SetAlphaFade(float nAlpha)
		{
			this.NullCheck("SetAlphaFade");
			method cscene_SetAlphaFade = CSceneAnimatableObject.__N.CScene_SetAlphaFade;
			calli(System.Void(System.IntPtr,System.Single), this.self, nAlpha, cscene_SetAlphaFade);
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00031D18 File Offset: 0x0002FF18
		internal readonly float GetAlphaFade()
		{
			this.NullCheck("GetAlphaFade");
			method cscene_GetAlphaFade = CSceneAnimatableObject.__N.CScene_GetAlphaFade;
			return calli(System.Single(System.IntPtr), this.self, cscene_GetAlphaFade);
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00031D44 File Offset: 0x0002FF44
		internal readonly void SetMaterialOverride(IMaterial mat)
		{
			this.NullCheck("SetMaterialOverride");
			method cscene_SetMaterialOverride = CSceneAnimatableObject.__N.CScene_SetMaterialOverride;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, mat, cscene_SetMaterialOverride);
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00031D74 File Offset: 0x0002FF74
		internal readonly void ClearMaterialOverrideList()
		{
			this.NullCheck("ClearMaterialOverrideList");
			method cscene_ClearMaterialOverrideList = CSceneAnimatableObject.__N.CScene_ClearMaterialOverrideList;
			calli(System.Void(System.IntPtr), this.self, cscene_ClearMaterialOverrideList);
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00031DA0 File Offset: 0x0002FFA0
		internal readonly bool IsLoaded()
		{
			this.NullCheck("IsLoaded");
			method cscene_IsLoaded = CSceneAnimatableObject.__N.CScene_IsLoaded;
			return calli(System.Int32(System.IntPtr), this.self, cscene_IsLoaded) > 0;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x00031DD0 File Offset: 0x0002FFD0
		internal readonly bool IsRenderingEnabled()
		{
			this.NullCheck("IsRenderingEnabled");
			method cscene_IsRenderingEnabled = CSceneAnimatableObject.__N.CScene_IsRenderingEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cscene_IsRenderingEnabled) > 0;
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x00031E00 File Offset: 0x00030000
		internal readonly void SetLoaded()
		{
			this.NullCheck("SetLoaded");
			method cscene_SetLoaded = CSceneAnimatableObject.__N.CScene_SetLoaded;
			calli(System.Void(System.IntPtr), this.self, cscene_SetLoaded);
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x00031E2C File Offset: 0x0003002C
		internal readonly void ClearLoaded()
		{
			this.NullCheck("ClearLoaded");
			method cscene_ClearLoaded = CSceneAnimatableObject.__N.CScene_ClearLoaded;
			calli(System.Void(System.IntPtr), this.self, cscene_ClearLoaded);
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x00031E58 File Offset: 0x00030058
		internal readonly void DisableRendering()
		{
			this.NullCheck("DisableRendering");
			method cscene_DisableRendering = CSceneAnimatableObject.__N.CScene_DisableRendering;
			calli(System.Void(System.IntPtr), this.self, cscene_DisableRendering);
		}

		// Token: 0x06000763 RID: 1891 RVA: 0x00031E84 File Offset: 0x00030084
		internal readonly void EnableRendering()
		{
			this.NullCheck("EnableRendering");
			method cscene_EnableRendering = CSceneAnimatableObject.__N.CScene_EnableRendering;
			calli(System.Void(System.IntPtr), this.self, cscene_EnableRendering);
		}

		// Token: 0x06000764 RID: 1892 RVA: 0x00031EB0 File Offset: 0x000300B0
		internal readonly void SetRenderingEnabled(bool bEnabled)
		{
			this.NullCheck("SetRenderingEnabled");
			method cscene_SetRenderingEnabled = CSceneAnimatableObject.__N.CScene_SetRenderingEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnabled ? 1 : 0, cscene_SetRenderingEnabled);
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x00031EE4 File Offset: 0x000300E4
		internal readonly float GetBoundingSphereRadius()
		{
			this.NullCheck("GetBoundingSphereRadius");
			method cscene_GetBoundingSphereRadius = CSceneAnimatableObject.__N.CScene_GetBoundingSphereRadius;
			return calli(System.Single(System.IntPtr), this.self, cscene_GetBoundingSphereRadius);
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x00031F10 File Offset: 0x00030110
		internal readonly void ScheduleDirtyUpdate()
		{
			this.NullCheck("ScheduleDirtyUpdate");
			method cscene_ScheduleDirtyUpdate = CSceneAnimatableObject.__N.CScene_ScheduleDirtyUpdate;
			calli(System.Void(System.IntPtr), this.self, cscene_ScheduleDirtyUpdate);
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x00031F3C File Offset: 0x0003013C
		internal readonly void UnscheduleDirtyUpdate()
		{
			this.NullCheck("UnscheduleDirtyUpdate");
			method cscene_UnscheduleDirtyUpdate = CSceneAnimatableObject.__N.CScene_UnscheduleDirtyUpdate;
			calli(System.Void(System.IntPtr), this.self, cscene_UnscheduleDirtyUpdate);
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x00031F68 File Offset: 0x00030168
		internal unsafe readonly void SetTransform(Transform tx)
		{
			this.NullCheck("SetTransform");
			method cscene_SetTransform = CSceneAnimatableObject.__N.CScene_SetTransform;
			calli(System.Void(System.IntPtr,Transform*), this.self, &tx, cscene_SetTransform);
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00031F98 File Offset: 0x00030198
		internal readonly Transform GetCTransform()
		{
			this.NullCheck("GetCTransform");
			method cscene_GetCTransform = CSceneAnimatableObject.__N.CScene_GetCTransform;
			return calli(Transform(System.IntPtr), this.self, cscene_GetCTransform);
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x00031FC4 File Offset: 0x000301C4
		internal unsafe readonly void SetBounds(Vector3 mins, Vector3 maxs)
		{
			this.NullCheck("SetBounds");
			method cscene_SetBounds = CSceneAnimatableObject.__N.CScene_SetBounds;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), this.self, &mins, &maxs, cscene_SetBounds);
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00031FF4 File Offset: 0x000301F4
		internal readonly SceneObject GetParent()
		{
			this.NullCheck("GetParent");
			method cscene_GetParent = CSceneAnimatableObject.__N.CScene_GetParent;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr), this.self, cscene_GetParent));
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00032024 File Offset: 0x00030224
		internal readonly void AddChildObject(string nId, SceneObject pChild, uint nChildUpdateFlags)
		{
			this.NullCheck("AddChildObject");
			method cscene_AddChildObject = CSceneAnimatableObject.__N.CScene_AddChildObject;
			calli(System.Void(System.IntPtr,System.UInt32,System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nId), (pChild == null) ? IntPtr.Zero : pChild.native, nChildUpdateFlags, cscene_AddChildObject);
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x0003206C File Offset: 0x0003026C
		internal readonly void RemoveChild(SceneObject obj)
		{
			this.NullCheck("RemoveChild");
			method cscene_RemoveChild = CSceneAnimatableObject.__N.CScene_RemoveChild;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (obj == null) ? IntPtr.Zero : obj.native, cscene_RemoveChild);
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x000320AC File Offset: 0x000302AC
		internal readonly CRenderAttributes GetAttributesPtrForModify()
		{
			this.NullCheck("GetAttributesPtrForModify");
			method cscene_GetAttributesPtrForModify = CSceneAnimatableObject.__N.CScene_GetAttributesPtrForModify;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_GetAttributesPtrForModify);
		}

		// Token: 0x0600076F RID: 1903 RVA: 0x000320DC File Offset: 0x000302DC
		internal readonly void EnableMeshGroups(ulong nMask)
		{
			this.NullCheck("EnableMeshGroups");
			method cscene_EnableMeshGroups = CSceneAnimatableObject.__N.CScene_EnableMeshGroups;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_EnableMeshGroups);
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x00032108 File Offset: 0x00030308
		internal readonly void DisableMeshGroups(ulong nMask)
		{
			this.NullCheck("DisableMeshGroups");
			method cscene_DisableMeshGroups = CSceneAnimatableObject.__N.CScene_DisableMeshGroups;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_DisableMeshGroups);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00032134 File Offset: 0x00030334
		internal readonly void ResetMeshGroups(ulong nMask)
		{
			this.NullCheck("ResetMeshGroups");
			method cscene_ResetMeshGroups = CSceneAnimatableObject.__N.CScene_ResetMeshGroups;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cscene_ResetMeshGroups);
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x00032160 File Offset: 0x00030360
		internal readonly ulong GetCurrentMeshGroupMask()
		{
			this.NullCheck("GetCurrentMeshGroupMask");
			method cscene_GetCurrentMeshGroupMask = CSceneAnimatableObject.__N.CScene_GetCurrentMeshGroupMask;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_GetCurrentMeshGroupMask);
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0003218C File Offset: 0x0003038C
		internal readonly SceneWorld GetWorld()
		{
			this.NullCheck("GetWorld");
			method cscene_GetWorld = CSceneAnimatableObject.__N.CScene_GetWorld;
			return HandleIndex.Get<SceneWorld>(calli(System.Int32(System.IntPtr), this.self, cscene_GetWorld));
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x000321BC File Offset: 0x000303BC
		internal readonly void SetLOD(int nLOD)
		{
			this.NullCheck("SetLOD");
			method cscene_SetLOD = CSceneAnimatableObject.__N.CScene_SetLOD;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLOD, cscene_SetLOD);
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x000321E8 File Offset: 0x000303E8
		internal readonly void DisableLOD()
		{
			this.NullCheck("DisableLOD");
			method cscene_DisableLOD = CSceneAnimatableObject.__N.CScene_DisableLOD;
			calli(System.Void(System.IntPtr), this.self, cscene_DisableLOD);
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00032214 File Offset: 0x00030414
		internal readonly ulong GetCurrentLODGroupMask()
		{
			this.NullCheck("GetCurrentLODGroupMask");
			method cscene_GetCurrentLODGroupMask = CSceneAnimatableObject.__N.CScene_GetCurrentLODGroupMask;
			return calli(System.UInt64(System.IntPtr), this.self, cscene_GetCurrentLODGroupMask);
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x00032240 File Offset: 0x00030440
		internal readonly int GetCurrentLODLevel()
		{
			this.NullCheck("GetCurrentLODLevel");
			method cscene_GetCurrentLODLevel = CSceneAnimatableObject.__N.CScene_GetCurrentLODLevel;
			return calli(System.Int32(System.IntPtr), this.self, cscene_GetCurrentLODLevel);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0003226C File Offset: 0x0003046C
		internal readonly IModel GetModelHandle()
		{
			this.NullCheck("GetModelHandle");
			method cscene_GetModelHandle = CSceneAnimatableObject.__N.CScene_GetModelHandle;
			return calli(System.IntPtr(System.IntPtr), this.self, cscene_GetModelHandle);
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0003229C File Offset: 0x0003049C
		internal readonly void SetMaterialGroup(string token)
		{
			this.NullCheck("SetMaterialGroup");
			method cscene_SetMaterialGroup = CSceneAnimatableObject.__N.CScene_SetMaterialGroup;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(token), cscene_SetMaterialGroup);
		}

		// Token: 0x0600077A RID: 1914 RVA: 0x000322CC File Offset: 0x000304CC
		internal readonly void SetBodyGroup(string token, int value)
		{
			this.NullCheck("SetBodyGroup");
			method cscene_SetBodyGroup = CSceneAnimatableObject.__N.CScene_SetBodyGroup;
			calli(System.Void(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(token), value, cscene_SetBodyGroup);
		}

		// Token: 0x040000AE RID: 174
		internal IntPtr self;

		// Token: 0x020001B7 RID: 439
		internal static class __N
		{
			// Token: 0x04000CE2 RID: 3298
			internal static method From_CSceneObject_To_CSceneAnimatableObject;

			// Token: 0x04000CE3 RID: 3299
			internal static method To_CSceneObject_From_CSceneAnimatableObject;

			// Token: 0x04000CE4 RID: 3300
			internal static method CScene_SetWorldSpaceRenderBoneTransform;

			// Token: 0x04000CE5 RID: 3301
			internal static method CScene_GetWorldSpaceRenderBoneTransform;

			// Token: 0x04000CE6 RID: 3302
			internal static method CScene_f2;

			// Token: 0x04000CE7 RID: 3303
			internal static method CScene_Update;

			// Token: 0x04000CE8 RID: 3304
			internal static method CScene_SetGraphParameter;

			// Token: 0x04000CE9 RID: 3305
			internal static method CScene_f3;

			// Token: 0x04000CEA RID: 3306
			internal static method CScene_f4;

			// Token: 0x04000CEB RID: 3307
			internal static method CScene_f5;

			// Token: 0x04000CEC RID: 3308
			internal static method CScene_f6;

			// Token: 0x04000CED RID: 3309
			internal static method CScene_ChangeFlags;

			// Token: 0x04000CEE RID: 3310
			internal static method CScene_SetFlags;

			// Token: 0x04000CEF RID: 3311
			internal static method CScene_HasFlags;

			// Token: 0x04000CF0 RID: 3312
			internal static method CScene_GetFlags;

			// Token: 0x04000CF1 RID: 3313
			internal static method CScene_GetOriginalFlags;

			// Token: 0x04000CF2 RID: 3314
			internal static method CScene_ClearFlags;

			// Token: 0x04000CF3 RID: 3315
			internal static method CScene_SetCullDistance;

			// Token: 0x04000CF4 RID: 3316
			internal static method CScene_SetLightingOrigin;

			// Token: 0x04000CF5 RID: 3317
			internal static method CScene_GetLightingOrigin;

			// Token: 0x04000CF6 RID: 3318
			internal static method CScene_HasLightingOrigin;

			// Token: 0x04000CF7 RID: 3319
			internal static method CScene_SetTintRGBA;

			// Token: 0x04000CF8 RID: 3320
			internal static method CScene_GetTintRGBA;

			// Token: 0x04000CF9 RID: 3321
			internal static method CScene_SetAlphaFade;

			// Token: 0x04000CFA RID: 3322
			internal static method CScene_GetAlphaFade;

			// Token: 0x04000CFB RID: 3323
			internal static method CScene_SetMaterialOverride;

			// Token: 0x04000CFC RID: 3324
			internal static method CScene_ClearMaterialOverrideList;

			// Token: 0x04000CFD RID: 3325
			internal static method CScene_IsLoaded;

			// Token: 0x04000CFE RID: 3326
			internal static method CScene_IsRenderingEnabled;

			// Token: 0x04000CFF RID: 3327
			internal static method CScene_SetLoaded;

			// Token: 0x04000D00 RID: 3328
			internal static method CScene_ClearLoaded;

			// Token: 0x04000D01 RID: 3329
			internal static method CScene_DisableRendering;

			// Token: 0x04000D02 RID: 3330
			internal static method CScene_EnableRendering;

			// Token: 0x04000D03 RID: 3331
			internal static method CScene_SetRenderingEnabled;

			// Token: 0x04000D04 RID: 3332
			internal static method CScene_GetBoundingSphereRadius;

			// Token: 0x04000D05 RID: 3333
			internal static method CScene_ScheduleDirtyUpdate;

			// Token: 0x04000D06 RID: 3334
			internal static method CScene_UnscheduleDirtyUpdate;

			// Token: 0x04000D07 RID: 3335
			internal static method CScene_SetTransform;

			// Token: 0x04000D08 RID: 3336
			internal static method CScene_GetCTransform;

			// Token: 0x04000D09 RID: 3337
			internal static method CScene_SetBounds;

			// Token: 0x04000D0A RID: 3338
			internal static method CScene_GetParent;

			// Token: 0x04000D0B RID: 3339
			internal static method CScene_AddChildObject;

			// Token: 0x04000D0C RID: 3340
			internal static method CScene_RemoveChild;

			// Token: 0x04000D0D RID: 3341
			internal static method CScene_GetAttributesPtrForModify;

			// Token: 0x04000D0E RID: 3342
			internal static method CScene_EnableMeshGroups;

			// Token: 0x04000D0F RID: 3343
			internal static method CScene_DisableMeshGroups;

			// Token: 0x04000D10 RID: 3344
			internal static method CScene_ResetMeshGroups;

			// Token: 0x04000D11 RID: 3345
			internal static method CScene_GetCurrentMeshGroupMask;

			// Token: 0x04000D12 RID: 3346
			internal static method CScene_GetWorld;

			// Token: 0x04000D13 RID: 3347
			internal static method CScene_SetLOD;

			// Token: 0x04000D14 RID: 3348
			internal static method CScene_DisableLOD;

			// Token: 0x04000D15 RID: 3349
			internal static method CScene_GetCurrentLODGroupMask;

			// Token: 0x04000D16 RID: 3350
			internal static method CScene_GetCurrentLODLevel;

			// Token: 0x04000D17 RID: 3351
			internal static method CScene_GetModelHandle;

			// Token: 0x04000D18 RID: 3352
			internal static method CScene_SetMaterialGroup;

			// Token: 0x04000D19 RID: 3353
			internal static method CScene_SetBodyGroup;
		}
	}
}
