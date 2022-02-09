using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200002F RID: 47
	internal struct CManagedSceneObject
	{
		// Token: 0x060006BD RID: 1725 RVA: 0x0003042F File Offset: 0x0002E62F
		public static implicit operator IntPtr(CManagedSceneObject value)
		{
			return value.self;
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00030438 File Offset: 0x0002E638
		public static implicit operator CManagedSceneObject(IntPtr value)
		{
			return new CManagedSceneObject
			{
				self = value
			};
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00030456 File Offset: 0x0002E656
		public static bool operator ==(CManagedSceneObject c1, CManagedSceneObject c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00030469 File Offset: 0x0002E669
		public static bool operator !=(CManagedSceneObject c1, CManagedSceneObject c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x0003047C File Offset: 0x0002E67C
		public override bool Equals(object obj)
		{
			if (obj is CManagedSceneObject)
			{
				CManagedSceneObject c = (CManagedSceneObject)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x000304A6 File Offset: 0x0002E6A6
		internal CManagedSceneObject(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x000304B0 File Offset: 0x0002E6B0
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CManagedSceneObject ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x000304EC File Offset: 0x0002E6EC
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x000304FE File Offset: 0x0002E6FE
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x00030509 File Offset: 0x0002E709
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0003051C File Offset: 0x0002E71C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CManagedSceneObject was null when calling " + n);
			}
		}

		// Token: 0x060006C8 RID: 1736 RVA: 0x00030537 File Offset: 0x0002E737
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060006C9 RID: 1737 RVA: 0x00030544 File Offset: 0x0002E744
		public static implicit operator CSceneObject(CManagedSceneObject value)
		{
			method to_CSceneObject_From_CManagedSceneObject = CManagedSceneObject.__N.To_CSceneObject_From_CManagedSceneObject;
			return calli(System.IntPtr(System.IntPtr), value, to_CSceneObject_From_CManagedSceneObject);
		}

		// Token: 0x060006CA RID: 1738 RVA: 0x00030568 File Offset: 0x0002E768
		public static explicit operator CManagedSceneObject(CSceneObject value)
		{
			method from_CSceneObject_To_CManagedSceneObject = CManagedSceneObject.__N.From_CSceneObject_To_CManagedSceneObject;
			return calli(System.IntPtr(System.IntPtr), value, from_CSceneObject_To_CManagedSceneObject);
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x0003058C File Offset: 0x0002E78C
		internal static CustomSceneObject Create(SceneWorld world)
		{
			method cmnged_Create = CManagedSceneObject.__N.CMnged_Create;
			return HandleIndex.Get<CustomSceneObject>(calli(System.Int32(System.IntPtr), (world == null) ? IntPtr.Zero : world.native, cmnged_Create));
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x000305C0 File Offset: 0x0002E7C0
		internal readonly void ChangeFlags(ESceneObjectFlags nNewFlags, ESceneObjectFlags nNewFlagsMask)
		{
			this.NullCheck("ChangeFlags");
			method cmnged_ChangeFlags = CManagedSceneObject.__N.CMnged_ChangeFlags;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, nNewFlags, nNewFlagsMask, cmnged_ChangeFlags);
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x000305EC File Offset: 0x0002E7EC
		internal readonly void SetFlags(ESceneObjectFlags nFlagsToOR)
		{
			this.NullCheck("SetFlags");
			method cmnged_SetFlags = CManagedSceneObject.__N.CMnged_SetFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToOR, cmnged_SetFlags);
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x00030618 File Offset: 0x0002E818
		internal readonly bool HasFlags(ESceneObjectFlags nFlags)
		{
			this.NullCheck("HasFlags");
			method cmnged_HasFlags = CManagedSceneObject.__N.CMnged_HasFlags;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, nFlags, cmnged_HasFlags) > 0;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x00030648 File Offset: 0x0002E848
		internal readonly ESceneObjectFlags GetFlags()
		{
			this.NullCheck("GetFlags");
			method cmnged_GetFlags = CManagedSceneObject.__N.CMnged_GetFlags;
			return calli(System.Int64(System.IntPtr), this.self, cmnged_GetFlags);
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x00030674 File Offset: 0x0002E874
		internal readonly ESceneObjectFlags GetOriginalFlags()
		{
			this.NullCheck("GetOriginalFlags");
			method cmnged_GetOriginalFlags = CManagedSceneObject.__N.CMnged_GetOriginalFlags;
			return calli(System.Int64(System.IntPtr), this.self, cmnged_GetOriginalFlags);
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x000306A0 File Offset: 0x0002E8A0
		internal readonly void ClearFlags(ESceneObjectFlags nFlagsToClear)
		{
			this.NullCheck("ClearFlags");
			method cmnged_ClearFlags = CManagedSceneObject.__N.CMnged_ClearFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, nFlagsToClear, cmnged_ClearFlags);
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x000306CC File Offset: 0x0002E8CC
		internal readonly void SetCullDistance(float dist)
		{
			this.NullCheck("SetCullDistance");
			method cmnged_SetCullDistance = CManagedSceneObject.__N.CMnged_SetCullDistance;
			calli(System.Void(System.IntPtr,System.Single), this.self, dist, cmnged_SetCullDistance);
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x000306F8 File Offset: 0x0002E8F8
		internal unsafe readonly void SetLightingOrigin(Vector3 vPos, bool worldspace)
		{
			this.NullCheck("SetLightingOrigin");
			method cmnged_SetLightingOrigin = CManagedSceneObject.__N.CMnged_SetLightingOrigin;
			calli(System.Void(System.IntPtr,Vector3*,System.Int32), this.self, &vPos, worldspace ? 1 : 0, cmnged_SetLightingOrigin);
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x0003072C File Offset: 0x0002E92C
		internal readonly Vector3 GetLightingOrigin()
		{
			this.NullCheck("GetLightingOrigin");
			method cmnged_GetLightingOrigin = CManagedSceneObject.__N.CMnged_GetLightingOrigin;
			return calli(Vector3(System.IntPtr), this.self, cmnged_GetLightingOrigin);
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x00030758 File Offset: 0x0002E958
		internal readonly bool HasLightingOrigin()
		{
			this.NullCheck("HasLightingOrigin");
			method cmnged_HasLightingOrigin = CManagedSceneObject.__N.CMnged_HasLightingOrigin;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_HasLightingOrigin) > 0;
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00030788 File Offset: 0x0002E988
		internal unsafe readonly void SetTintRGBA(Vector4 color)
		{
			this.NullCheck("SetTintRGBA");
			method cmnged_SetTintRGBA = CManagedSceneObject.__N.CMnged_SetTintRGBA;
			calli(System.Void(System.IntPtr,Vector4*), this.self, &color, cmnged_SetTintRGBA);
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x000307B8 File Offset: 0x0002E9B8
		internal readonly Vector4 GetTintRGBA()
		{
			this.NullCheck("GetTintRGBA");
			method cmnged_GetTintRGBA = CManagedSceneObject.__N.CMnged_GetTintRGBA;
			return calli(Vector4(System.IntPtr), this.self, cmnged_GetTintRGBA);
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x000307E4 File Offset: 0x0002E9E4
		internal readonly void SetAlphaFade(float nAlpha)
		{
			this.NullCheck("SetAlphaFade");
			method cmnged_SetAlphaFade = CManagedSceneObject.__N.CMnged_SetAlphaFade;
			calli(System.Void(System.IntPtr,System.Single), this.self, nAlpha, cmnged_SetAlphaFade);
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00030810 File Offset: 0x0002EA10
		internal readonly float GetAlphaFade()
		{
			this.NullCheck("GetAlphaFade");
			method cmnged_GetAlphaFade = CManagedSceneObject.__N.CMnged_GetAlphaFade;
			return calli(System.Single(System.IntPtr), this.self, cmnged_GetAlphaFade);
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x0003083C File Offset: 0x0002EA3C
		internal readonly void SetMaterialOverride(IMaterial mat)
		{
			this.NullCheck("SetMaterialOverride");
			method cmnged_SetMaterialOverride = CManagedSceneObject.__N.CMnged_SetMaterialOverride;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, mat, cmnged_SetMaterialOverride);
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x0003086C File Offset: 0x0002EA6C
		internal readonly void ClearMaterialOverrideList()
		{
			this.NullCheck("ClearMaterialOverrideList");
			method cmnged_ClearMaterialOverrideList = CManagedSceneObject.__N.CMnged_ClearMaterialOverrideList;
			calli(System.Void(System.IntPtr), this.self, cmnged_ClearMaterialOverrideList);
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x00030898 File Offset: 0x0002EA98
		internal readonly bool IsLoaded()
		{
			this.NullCheck("IsLoaded");
			method cmnged_IsLoaded = CManagedSceneObject.__N.CMnged_IsLoaded;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_IsLoaded) > 0;
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x000308C8 File Offset: 0x0002EAC8
		internal readonly bool IsRenderingEnabled()
		{
			this.NullCheck("IsRenderingEnabled");
			method cmnged_IsRenderingEnabled = CManagedSceneObject.__N.CMnged_IsRenderingEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_IsRenderingEnabled) > 0;
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x000308F8 File Offset: 0x0002EAF8
		internal readonly void SetLoaded()
		{
			this.NullCheck("SetLoaded");
			method cmnged_SetLoaded = CManagedSceneObject.__N.CMnged_SetLoaded;
			calli(System.Void(System.IntPtr), this.self, cmnged_SetLoaded);
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00030924 File Offset: 0x0002EB24
		internal readonly void ClearLoaded()
		{
			this.NullCheck("ClearLoaded");
			method cmnged_ClearLoaded = CManagedSceneObject.__N.CMnged_ClearLoaded;
			calli(System.Void(System.IntPtr), this.self, cmnged_ClearLoaded);
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00030950 File Offset: 0x0002EB50
		internal readonly void DisableRendering()
		{
			this.NullCheck("DisableRendering");
			method cmnged_DisableRendering = CManagedSceneObject.__N.CMnged_DisableRendering;
			calli(System.Void(System.IntPtr), this.self, cmnged_DisableRendering);
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x0003097C File Offset: 0x0002EB7C
		internal readonly void EnableRendering()
		{
			this.NullCheck("EnableRendering");
			method cmnged_EnableRendering = CManagedSceneObject.__N.CMnged_EnableRendering;
			calli(System.Void(System.IntPtr), this.self, cmnged_EnableRendering);
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x000309A8 File Offset: 0x0002EBA8
		internal readonly void SetRenderingEnabled(bool bEnabled)
		{
			this.NullCheck("SetRenderingEnabled");
			method cmnged_SetRenderingEnabled = CManagedSceneObject.__N.CMnged_SetRenderingEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnabled ? 1 : 0, cmnged_SetRenderingEnabled);
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x000309DC File Offset: 0x0002EBDC
		internal readonly float GetBoundingSphereRadius()
		{
			this.NullCheck("GetBoundingSphereRadius");
			method cmnged_GetBoundingSphereRadius = CManagedSceneObject.__N.CMnged_GetBoundingSphereRadius;
			return calli(System.Single(System.IntPtr), this.self, cmnged_GetBoundingSphereRadius);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00030A08 File Offset: 0x0002EC08
		internal readonly void ScheduleDirtyUpdate()
		{
			this.NullCheck("ScheduleDirtyUpdate");
			method cmnged_ScheduleDirtyUpdate = CManagedSceneObject.__N.CMnged_ScheduleDirtyUpdate;
			calli(System.Void(System.IntPtr), this.self, cmnged_ScheduleDirtyUpdate);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00030A34 File Offset: 0x0002EC34
		internal readonly void UnscheduleDirtyUpdate()
		{
			this.NullCheck("UnscheduleDirtyUpdate");
			method cmnged_UnscheduleDirtyUpdate = CManagedSceneObject.__N.CMnged_UnscheduleDirtyUpdate;
			calli(System.Void(System.IntPtr), this.self, cmnged_UnscheduleDirtyUpdate);
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00030A60 File Offset: 0x0002EC60
		internal unsafe readonly void SetTransform(Transform tx)
		{
			this.NullCheck("SetTransform");
			method cmnged_SetTransform = CManagedSceneObject.__N.CMnged_SetTransform;
			calli(System.Void(System.IntPtr,Transform*), this.self, &tx, cmnged_SetTransform);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00030A90 File Offset: 0x0002EC90
		internal readonly Transform GetCTransform()
		{
			this.NullCheck("GetCTransform");
			method cmnged_GetCTransform = CManagedSceneObject.__N.CMnged_GetCTransform;
			return calli(Transform(System.IntPtr), this.self, cmnged_GetCTransform);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00030ABC File Offset: 0x0002ECBC
		internal unsafe readonly void SetBounds(Vector3 mins, Vector3 maxs)
		{
			this.NullCheck("SetBounds");
			method cmnged_SetBounds = CManagedSceneObject.__N.CMnged_SetBounds;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), this.self, &mins, &maxs, cmnged_SetBounds);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00030AEC File Offset: 0x0002ECEC
		internal readonly SceneObject GetParent()
		{
			this.NullCheck("GetParent");
			method cmnged_GetParent = CManagedSceneObject.__N.CMnged_GetParent;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr), this.self, cmnged_GetParent));
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00030B1C File Offset: 0x0002ED1C
		internal readonly void AddChildObject(string nId, SceneObject pChild, uint nChildUpdateFlags)
		{
			this.NullCheck("AddChildObject");
			method cmnged_AddChildObject = CManagedSceneObject.__N.CMnged_AddChildObject;
			calli(System.Void(System.IntPtr,System.UInt32,System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(nId), (pChild == null) ? IntPtr.Zero : pChild.native, nChildUpdateFlags, cmnged_AddChildObject);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00030B64 File Offset: 0x0002ED64
		internal readonly void RemoveChild(SceneObject obj)
		{
			this.NullCheck("RemoveChild");
			method cmnged_RemoveChild = CManagedSceneObject.__N.CMnged_RemoveChild;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, (obj == null) ? IntPtr.Zero : obj.native, cmnged_RemoveChild);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00030BA4 File Offset: 0x0002EDA4
		internal readonly CRenderAttributes GetAttributesPtrForModify()
		{
			this.NullCheck("GetAttributesPtrForModify");
			method cmnged_GetAttributesPtrForModify = CManagedSceneObject.__N.CMnged_GetAttributesPtrForModify;
			return calli(System.IntPtr(System.IntPtr), this.self, cmnged_GetAttributesPtrForModify);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00030BD4 File Offset: 0x0002EDD4
		internal readonly void EnableMeshGroups(ulong nMask)
		{
			this.NullCheck("EnableMeshGroups");
			method cmnged_EnableMeshGroups = CManagedSceneObject.__N.CMnged_EnableMeshGroups;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cmnged_EnableMeshGroups);
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00030C00 File Offset: 0x0002EE00
		internal readonly void DisableMeshGroups(ulong nMask)
		{
			this.NullCheck("DisableMeshGroups");
			method cmnged_DisableMeshGroups = CManagedSceneObject.__N.CMnged_DisableMeshGroups;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cmnged_DisableMeshGroups);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00030C2C File Offset: 0x0002EE2C
		internal readonly void ResetMeshGroups(ulong nMask)
		{
			this.NullCheck("ResetMeshGroups");
			method cmnged_ResetMeshGroups = CManagedSceneObject.__N.CMnged_ResetMeshGroups;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nMask, cmnged_ResetMeshGroups);
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x00030C58 File Offset: 0x0002EE58
		internal readonly ulong GetCurrentMeshGroupMask()
		{
			this.NullCheck("GetCurrentMeshGroupMask");
			method cmnged_GetCurrentMeshGroupMask = CManagedSceneObject.__N.CMnged_GetCurrentMeshGroupMask;
			return calli(System.UInt64(System.IntPtr), this.self, cmnged_GetCurrentMeshGroupMask);
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00030C84 File Offset: 0x0002EE84
		internal readonly SceneWorld GetWorld()
		{
			this.NullCheck("GetWorld");
			method cmnged_GetWorld = CManagedSceneObject.__N.CMnged_GetWorld;
			return HandleIndex.Get<SceneWorld>(calli(System.Int32(System.IntPtr), this.self, cmnged_GetWorld));
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00030CB4 File Offset: 0x0002EEB4
		internal readonly void SetLOD(int nLOD)
		{
			this.NullCheck("SetLOD");
			method cmnged_SetLOD = CManagedSceneObject.__N.CMnged_SetLOD;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nLOD, cmnged_SetLOD);
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00030CE0 File Offset: 0x0002EEE0
		internal readonly void DisableLOD()
		{
			this.NullCheck("DisableLOD");
			method cmnged_DisableLOD = CManagedSceneObject.__N.CMnged_DisableLOD;
			calli(System.Void(System.IntPtr), this.self, cmnged_DisableLOD);
		}

		// Token: 0x060006F4 RID: 1780 RVA: 0x00030D0C File Offset: 0x0002EF0C
		internal readonly ulong GetCurrentLODGroupMask()
		{
			this.NullCheck("GetCurrentLODGroupMask");
			method cmnged_GetCurrentLODGroupMask = CManagedSceneObject.__N.CMnged_GetCurrentLODGroupMask;
			return calli(System.UInt64(System.IntPtr), this.self, cmnged_GetCurrentLODGroupMask);
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00030D38 File Offset: 0x0002EF38
		internal readonly int GetCurrentLODLevel()
		{
			this.NullCheck("GetCurrentLODLevel");
			method cmnged_GetCurrentLODLevel = CManagedSceneObject.__N.CMnged_GetCurrentLODLevel;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_GetCurrentLODLevel);
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00030D64 File Offset: 0x0002EF64
		internal readonly IModel GetModelHandle()
		{
			this.NullCheck("GetModelHandle");
			method cmnged_GetModelHandle = CManagedSceneObject.__N.CMnged_GetModelHandle;
			return calli(System.IntPtr(System.IntPtr), this.self, cmnged_GetModelHandle);
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00030D94 File Offset: 0x0002EF94
		internal readonly void SetMaterialGroup(string token)
		{
			this.NullCheck("SetMaterialGroup");
			method cmnged_SetMaterialGroup = CManagedSceneObject.__N.CMnged_SetMaterialGroup;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(token), cmnged_SetMaterialGroup);
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00030DC4 File Offset: 0x0002EFC4
		internal readonly void SetBodyGroup(string token, int value)
		{
			this.NullCheck("SetBodyGroup");
			method cmnged_SetBodyGroup = CManagedSceneObject.__N.CMnged_SetBodyGroup;
			calli(System.Void(System.IntPtr,System.UInt32,System.Int32), this.self, StringToken.FindOrCreate(token), value, cmnged_SetBodyGroup);
		}

		// Token: 0x040000AB RID: 171
		internal IntPtr self;

		// Token: 0x020001B4 RID: 436
		internal static class __N
		{
			// Token: 0x04000C8C RID: 3212
			internal static method From_CSceneObject_To_CManagedSceneObject;

			// Token: 0x04000C8D RID: 3213
			internal static method To_CSceneObject_From_CManagedSceneObject;

			// Token: 0x04000C8E RID: 3214
			internal static method CMnged_Create;

			// Token: 0x04000C8F RID: 3215
			internal static method CMnged_ChangeFlags;

			// Token: 0x04000C90 RID: 3216
			internal static method CMnged_SetFlags;

			// Token: 0x04000C91 RID: 3217
			internal static method CMnged_HasFlags;

			// Token: 0x04000C92 RID: 3218
			internal static method CMnged_GetFlags;

			// Token: 0x04000C93 RID: 3219
			internal static method CMnged_GetOriginalFlags;

			// Token: 0x04000C94 RID: 3220
			internal static method CMnged_ClearFlags;

			// Token: 0x04000C95 RID: 3221
			internal static method CMnged_SetCullDistance;

			// Token: 0x04000C96 RID: 3222
			internal static method CMnged_SetLightingOrigin;

			// Token: 0x04000C97 RID: 3223
			internal static method CMnged_GetLightingOrigin;

			// Token: 0x04000C98 RID: 3224
			internal static method CMnged_HasLightingOrigin;

			// Token: 0x04000C99 RID: 3225
			internal static method CMnged_SetTintRGBA;

			// Token: 0x04000C9A RID: 3226
			internal static method CMnged_GetTintRGBA;

			// Token: 0x04000C9B RID: 3227
			internal static method CMnged_SetAlphaFade;

			// Token: 0x04000C9C RID: 3228
			internal static method CMnged_GetAlphaFade;

			// Token: 0x04000C9D RID: 3229
			internal static method CMnged_SetMaterialOverride;

			// Token: 0x04000C9E RID: 3230
			internal static method CMnged_ClearMaterialOverrideList;

			// Token: 0x04000C9F RID: 3231
			internal static method CMnged_IsLoaded;

			// Token: 0x04000CA0 RID: 3232
			internal static method CMnged_IsRenderingEnabled;

			// Token: 0x04000CA1 RID: 3233
			internal static method CMnged_SetLoaded;

			// Token: 0x04000CA2 RID: 3234
			internal static method CMnged_ClearLoaded;

			// Token: 0x04000CA3 RID: 3235
			internal static method CMnged_DisableRendering;

			// Token: 0x04000CA4 RID: 3236
			internal static method CMnged_EnableRendering;

			// Token: 0x04000CA5 RID: 3237
			internal static method CMnged_SetRenderingEnabled;

			// Token: 0x04000CA6 RID: 3238
			internal static method CMnged_GetBoundingSphereRadius;

			// Token: 0x04000CA7 RID: 3239
			internal static method CMnged_ScheduleDirtyUpdate;

			// Token: 0x04000CA8 RID: 3240
			internal static method CMnged_UnscheduleDirtyUpdate;

			// Token: 0x04000CA9 RID: 3241
			internal static method CMnged_SetTransform;

			// Token: 0x04000CAA RID: 3242
			internal static method CMnged_GetCTransform;

			// Token: 0x04000CAB RID: 3243
			internal static method CMnged_SetBounds;

			// Token: 0x04000CAC RID: 3244
			internal static method CMnged_GetParent;

			// Token: 0x04000CAD RID: 3245
			internal static method CMnged_AddChildObject;

			// Token: 0x04000CAE RID: 3246
			internal static method CMnged_RemoveChild;

			// Token: 0x04000CAF RID: 3247
			internal static method CMnged_GetAttributesPtrForModify;

			// Token: 0x04000CB0 RID: 3248
			internal static method CMnged_EnableMeshGroups;

			// Token: 0x04000CB1 RID: 3249
			internal static method CMnged_DisableMeshGroups;

			// Token: 0x04000CB2 RID: 3250
			internal static method CMnged_ResetMeshGroups;

			// Token: 0x04000CB3 RID: 3251
			internal static method CMnged_GetCurrentMeshGroupMask;

			// Token: 0x04000CB4 RID: 3252
			internal static method CMnged_GetWorld;

			// Token: 0x04000CB5 RID: 3253
			internal static method CMnged_SetLOD;

			// Token: 0x04000CB6 RID: 3254
			internal static method CMnged_DisableLOD;

			// Token: 0x04000CB7 RID: 3255
			internal static method CMnged_GetCurrentLODGroupMask;

			// Token: 0x04000CB8 RID: 3256
			internal static method CMnged_GetCurrentLODLevel;

			// Token: 0x04000CB9 RID: 3257
			internal static method CMnged_GetModelHandle;

			// Token: 0x04000CBA RID: 3258
			internal static method CMnged_SetMaterialGroup;

			// Token: 0x04000CBB RID: 3259
			internal static method CMnged_SetBodyGroup;
		}
	}
}
