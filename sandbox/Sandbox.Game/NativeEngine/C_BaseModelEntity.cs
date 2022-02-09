using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200001C RID: 28
	internal struct C_BaseModelEntity
	{
		// Token: 0x0600025B RID: 603 RVA: 0x00025195 File Offset: 0x00023395
		public static implicit operator IntPtr(C_BaseModelEntity value)
		{
			return value.self;
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000251A0 File Offset: 0x000233A0
		public static implicit operator C_BaseModelEntity(IntPtr value)
		{
			return new C_BaseModelEntity
			{
				self = value
			};
		}

		// Token: 0x0600025D RID: 605 RVA: 0x000251BE File Offset: 0x000233BE
		public static bool operator ==(C_BaseModelEntity c1, C_BaseModelEntity c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600025E RID: 606 RVA: 0x000251D1 File Offset: 0x000233D1
		public static bool operator !=(C_BaseModelEntity c1, C_BaseModelEntity c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000251E4 File Offset: 0x000233E4
		public override bool Equals(object obj)
		{
			if (obj is C_BaseModelEntity)
			{
				C_BaseModelEntity c = (C_BaseModelEntity)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0002520E File Offset: 0x0002340E
		internal C_BaseModelEntity(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00025218 File Offset: 0x00023418
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("C_BaseModelEntity ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000262 RID: 610 RVA: 0x00025254 File Offset: 0x00023454
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000263 RID: 611 RVA: 0x00025266 File Offset: 0x00023466
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x00025271 File Offset: 0x00023471
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00025284 File Offset: 0x00023484
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("C_BaseModelEntity was null when calling " + n);
			}
		}

		// Token: 0x06000266 RID: 614 RVA: 0x0002529F File Offset: 0x0002349F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x000252AC File Offset: 0x000234AC
		public static implicit operator C_BaseEntity(C_BaseModelEntity value)
		{
			method to_C_BaseEntity_From_C_BaseModelEntity = C_BaseModelEntity.__N.To_C_BaseEntity_From_C_BaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_C_BaseEntity_From_C_BaseModelEntity);
		}

		// Token: 0x06000268 RID: 616 RVA: 0x000252D0 File Offset: 0x000234D0
		public static explicit operator C_BaseModelEntity(C_BaseEntity value)
		{
			method from_C_BaseEntity_To_C_BaseModelEntity = C_BaseModelEntity.__N.From_C_BaseEntity_To_C_BaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_C_BaseEntity_To_C_BaseModelEntity);
		}

		// Token: 0x06000269 RID: 617 RVA: 0x000252F4 File Offset: 0x000234F4
		public static implicit operator CGameEntity(C_BaseModelEntity value)
		{
			method to_CGameEntity_From_C_BaseModelEntity = C_BaseModelEntity.__N.To_CGameEntity_From_C_BaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_CGameEntity_From_C_BaseModelEntity);
		}

		// Token: 0x0600026A RID: 618 RVA: 0x00025318 File Offset: 0x00023518
		public static explicit operator C_BaseModelEntity(CGameEntity value)
		{
			method from_CGameEntity_To_C_BaseModelEntity = C_BaseModelEntity.__N.From_CGameEntity_To_C_BaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_CGameEntity_To_C_BaseModelEntity);
		}

		// Token: 0x0600026B RID: 619 RVA: 0x0002533C File Offset: 0x0002353C
		public static implicit operator CEntityInstance(C_BaseModelEntity value)
		{
			method to_CEntityInstance_From_C_BaseModelEntity = C_BaseModelEntity.__N.To_CEntityInstance_From_C_BaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_CEntityInstance_From_C_BaseModelEntity);
		}

		// Token: 0x0600026C RID: 620 RVA: 0x00025360 File Offset: 0x00023560
		public static explicit operator C_BaseModelEntity(CEntityInstance value)
		{
			method from_CEntityInstance_To_C_BaseModelEntity = C_BaseModelEntity.__N.From_CEntityInstance_To_C_BaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_CEntityInstance_To_C_BaseModelEntity);
		}

		// Token: 0x0600026D RID: 621 RVA: 0x00025384 File Offset: 0x00023584
		public static implicit operator IHandleEntity(C_BaseModelEntity value)
		{
			method to_IHandleEntity_From_C_BaseModelEntity = C_BaseModelEntity.__N.To_IHandleEntity_From_C_BaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_IHandleEntity_From_C_BaseModelEntity);
		}

		// Token: 0x0600026E RID: 622 RVA: 0x000253A8 File Offset: 0x000235A8
		public static explicit operator C_BaseModelEntity(IHandleEntity value)
		{
			method from_IHandleEntity_To_C_BaseModelEntity = C_BaseModelEntity.__N.From_IHandleEntity_To_C_BaseModelEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_IHandleEntity_To_C_BaseModelEntity);
		}

		// Token: 0x0600026F RID: 623 RVA: 0x000253CC File Offset: 0x000235CC
		internal readonly CSkeletonInstance GetSkeletonInstance()
		{
			this.NullCheck("GetSkeletonInstance");
			method cbseMd_GetSkeletonInstance = C_BaseModelEntity.__N.CBseMd_GetSkeletonInstance;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetSkeletonInstance);
		}

		// Token: 0x06000270 RID: 624 RVA: 0x000253FC File Offset: 0x000235FC
		internal readonly void SetModelScale(float scale)
		{
			this.NullCheck("SetModelScale");
			method cbseMd_SetModelScale = C_BaseModelEntity.__N.CBseMd_SetModelScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, scale, cbseMd_SetModelScale);
		}

		// Token: 0x06000271 RID: 625 RVA: 0x00025428 File Offset: 0x00023628
		internal readonly float GetModelScale()
		{
			this.NullCheck("GetModelScale");
			method cbseMd_GetModelScale = C_BaseModelEntity.__N.CBseMd_GetModelScale;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetModelScale);
		}

		// Token: 0x06000272 RID: 626 RVA: 0x00025454 File Offset: 0x00023654
		internal readonly int GetNumBones()
		{
			this.NullCheck("GetNumBones");
			method cbseMd_GetNumBones = C_BaseModelEntity.__N.CBseMd_GetNumBones;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetNumBones);
		}

		// Token: 0x06000273 RID: 627 RVA: 0x00025480 File Offset: 0x00023680
		internal readonly int LookupBone(string szName)
		{
			this.NullCheck("LookupBone");
			method cbseMd_LookupBone = C_BaseModelEntity.__N.CBseMd_LookupBone;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(szName), cbseMd_LookupBone);
		}

		// Token: 0x06000274 RID: 628 RVA: 0x000254B0 File Offset: 0x000236B0
		internal readonly int GetAttachmentCount()
		{
			this.NullCheck("GetAttachmentCount");
			method cbseMd_GetAttachmentCount = C_BaseModelEntity.__N.CBseMd_GetAttachmentCount;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetAttachmentCount);
		}

		// Token: 0x06000275 RID: 629 RVA: 0x000254DC File Offset: 0x000236DC
		internal readonly float GetMinFadeDist()
		{
			this.NullCheck("GetMinFadeDist");
			method cbseMd_GetMinFadeDist = C_BaseModelEntity.__N.CBseMd_GetMinFadeDist;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetMinFadeDist);
		}

		// Token: 0x06000276 RID: 630 RVA: 0x00025508 File Offset: 0x00023708
		internal readonly float GetMaxFadeDist()
		{
			this.NullCheck("GetMaxFadeDist");
			method cbseMd_GetMaxFadeDist = C_BaseModelEntity.__N.CBseMd_GetMaxFadeDist;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetMaxFadeDist);
		}

		// Token: 0x06000277 RID: 631 RVA: 0x00025534 File Offset: 0x00023734
		internal readonly void SetModel(string name)
		{
			this.NullCheck("SetModel");
			method cbseMd_SetModel = C_BaseModelEntity.__N.CBseMd_SetModel;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseMd_SetModel);
		}

		// Token: 0x06000278 RID: 632 RVA: 0x00025564 File Offset: 0x00023764
		internal readonly void SetModelAsync(string name)
		{
			this.NullCheck("SetModelAsync");
			method cbseMd_SetModelAsync = C_BaseModelEntity.__N.CBseMd_SetModelAsync;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseMd_SetModelAsync);
		}

		// Token: 0x06000279 RID: 633 RVA: 0x00025594 File Offset: 0x00023794
		internal readonly IModel GetModel()
		{
			this.NullCheck("GetModel");
			method cbseMd_GetModel = C_BaseModelEntity.__N.CBseMd_GetModel;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetModel);
		}

		// Token: 0x0600027A RID: 634 RVA: 0x000255C4 File Offset: 0x000237C4
		internal readonly void SetModel(IModel model)
		{
			this.NullCheck("SetModel");
			method cbseMd_f = C_BaseModelEntity.__N.CBseMd_f2;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, model, cbseMd_f);
		}

		// Token: 0x0600027B RID: 635 RVA: 0x000255F4 File Offset: 0x000237F4
		internal readonly void SetBodygroup(int iGroup, int iValue)
		{
			this.NullCheck("SetBodygroup");
			method cbseMd_SetBodygroup = C_BaseModelEntity.__N.CBseMd_SetBodygroup;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, iGroup, iValue, cbseMd_SetBodygroup);
		}

		// Token: 0x0600027C RID: 636 RVA: 0x00025620 File Offset: 0x00023820
		internal readonly void SetBodygroupByName(string pName, int iValue)
		{
			this.NullCheck("SetBodygroupByName");
			method cbseMd_SetBodygroupByName = C_BaseModelEntity.__N.CBseMd_SetBodygroupByName;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(pName), iValue, cbseMd_SetBodygroupByName);
		}

		// Token: 0x0600027D RID: 637 RVA: 0x00025654 File Offset: 0x00023854
		internal readonly ulong GetRawMeshGroupMask()
		{
			this.NullCheck("GetRawMeshGroupMask");
			method cbseMd_GetRawMeshGroupMask = C_BaseModelEntity.__N.CBseMd_GetRawMeshGroupMask;
			return calli(System.UInt64(System.IntPtr), this.self, cbseMd_GetRawMeshGroupMask);
		}

		// Token: 0x0600027E RID: 638 RVA: 0x00025680 File Offset: 0x00023880
		internal readonly void SetRawMeshGroupMask_LegacyDoNotUse(ulong nBody)
		{
			this.NullCheck("SetRawMeshGroupMask_LegacyDoNotUse");
			method cbseMd_SetRawMeshGroupMask_LegacyDoNotUse = C_BaseModelEntity.__N.CBseMd_SetRawMeshGroupMask_LegacyDoNotUse;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBody, cbseMd_SetRawMeshGroupMask_LegacyDoNotUse);
		}

		// Token: 0x0600027F RID: 639 RVA: 0x000256AC File Offset: 0x000238AC
		internal readonly int GetSkinCount()
		{
			this.NullCheck("GetSkinCount");
			method cbseMd_GetSkinCount = C_BaseModelEntity.__N.CBseMd_GetSkinCount;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetSkinCount);
		}

		// Token: 0x06000280 RID: 640 RVA: 0x000256D8 File Offset: 0x000238D8
		internal readonly void SetSkin(int iSkin)
		{
			this.NullCheck("SetSkin");
			method cbseMd_SetSkin = C_BaseModelEntity.__N.CBseMd_SetSkin;
			calli(System.Void(System.IntPtr,System.Int32), this.self, iSkin, cbseMd_SetSkin);
		}

		// Token: 0x06000281 RID: 641 RVA: 0x00025704 File Offset: 0x00023904
		internal readonly void SetSkin(string skinName)
		{
			this.NullCheck("SetSkin");
			method cbseMd_f = C_BaseModelEntity.__N.CBseMd_f3;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(skinName), cbseMd_f);
		}

		// Token: 0x06000282 RID: 642 RVA: 0x00025734 File Offset: 0x00023934
		internal readonly int GetS1Skin()
		{
			this.NullCheck("GetS1Skin");
			method cbseMd_GetS1Skin = C_BaseModelEntity.__N.CBseMd_GetS1Skin;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetS1Skin);
		}

		// Token: 0x06000283 RID: 643 RVA: 0x00025760 File Offset: 0x00023960
		internal readonly CollisionProperty CollisionProp()
		{
			this.NullCheck("CollisionProp");
			method cbseMd_CollisionProp = C_BaseModelEntity.__N.CBseMd_CollisionProp;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_CollisionProp);
		}

		// Token: 0x06000284 RID: 644 RVA: 0x00025790 File Offset: 0x00023990
		internal readonly void SetRenderAlpha(byte alpha)
		{
			this.NullCheck("SetRenderAlpha");
			method cbseMd_SetRenderAlpha = C_BaseModelEntity.__N.CBseMd_SetRenderAlpha;
			calli(System.Void(System.IntPtr,System.Byte), this.self, alpha, cbseMd_SetRenderAlpha);
		}

		// Token: 0x06000285 RID: 645 RVA: 0x000257BC File Offset: 0x000239BC
		internal readonly byte GetRenderAlpha()
		{
			this.NullCheck("GetRenderAlpha");
			method cbseMd_GetRenderAlpha = C_BaseModelEntity.__N.CBseMd_GetRenderAlpha;
			return calli(System.Byte(System.IntPtr), this.self, cbseMd_GetRenderAlpha);
		}

		// Token: 0x06000286 RID: 646 RVA: 0x000257E8 File Offset: 0x000239E8
		internal readonly void SetRenderColor(byte r, byte g, byte b)
		{
			this.NullCheck("SetRenderColor");
			method cbseMd_SetRenderColor = C_BaseModelEntity.__N.CBseMd_SetRenderColor;
			calli(System.Void(System.IntPtr,System.Byte,System.Byte,System.Byte), this.self, r, g, b, cbseMd_SetRenderColor);
		}

		// Token: 0x06000287 RID: 647 RVA: 0x00025818 File Offset: 0x00023A18
		internal readonly void SetRenderColorAndAlpha(Color32 color)
		{
			this.NullCheck("SetRenderColorAndAlpha");
			method cbseMd_SetRenderColorAndAlpha = C_BaseModelEntity.__N.CBseMd_SetRenderColorAndAlpha;
			calli(System.Void(System.IntPtr,Color32), this.self, color, cbseMd_SetRenderColorAndAlpha);
		}

		// Token: 0x06000288 RID: 648 RVA: 0x00025844 File Offset: 0x00023A44
		internal readonly Color24 GetRenderColor()
		{
			this.NullCheck("GetRenderColor");
			method cbseMd_GetRenderColor = C_BaseModelEntity.__N.CBseMd_GetRenderColor;
			return calli(Color24(System.IntPtr), this.self, cbseMd_GetRenderColor);
		}

		// Token: 0x06000289 RID: 649 RVA: 0x00025870 File Offset: 0x00023A70
		internal readonly CGlowProperty GlowProp()
		{
			this.NullCheck("GlowProp");
			method cbseMd_GlowProp = C_BaseModelEntity.__N.CBseMd_GlowProp;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GlowProp);
		}

		// Token: 0x0600028A RID: 650 RVA: 0x000258A0 File Offset: 0x00023AA0
		internal readonly void SetSceneLayerID(string id)
		{
			this.NullCheck("SetSceneLayerID");
			method cbseMd_SetSceneLayerID = C_BaseModelEntity.__N.CBseMd_SetSceneLayerID;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, StringToken.FindOrCreate(id), cbseMd_SetSceneLayerID);
		}

		// Token: 0x0600028B RID: 651 RVA: 0x000258D0 File Offset: 0x00023AD0
		internal readonly int GetSceneObjectCount()
		{
			this.NullCheck("GetSceneObjectCount");
			method cbseMd_GetSceneObjectCount = C_BaseModelEntity.__N.CBseMd_GetSceneObjectCount;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetSceneObjectCount);
		}

		// Token: 0x0600028C RID: 652 RVA: 0x000258FC File Offset: 0x00023AFC
		internal readonly SceneObject GetSceneObject(int none)
		{
			this.NullCheck("GetSceneObject");
			method cbseMd_GetSceneObject = C_BaseModelEntity.__N.CBseMd_GetSceneObject;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr,System.Int32), this.self, none, cbseMd_GetSceneObject));
		}

		// Token: 0x0600028D RID: 653 RVA: 0x0002592C File Offset: 0x00023B2C
		internal readonly Transform GetBoneTransform(int bone)
		{
			this.NullCheck("GetBoneTransform");
			method cbseMd_GetBoneTransform = C_BaseModelEntity.__N.CBseMd_GetBoneTransform;
			return calli(Transform(System.IntPtr,System.Int32), this.self, bone, cbseMd_GetBoneTransform);
		}

		// Token: 0x0600028E RID: 654 RVA: 0x00025958 File Offset: 0x00023B58
		internal readonly void InitializeEntityObject(Entity pointer)
		{
			this.NullCheck("InitializeEntityObject");
			method cbseMd_InitializeEntityObject = C_BaseModelEntity.__N.CBseMd_InitializeEntityObject;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, (pointer == null) ? 0U : InteropSystem.GetAddress<Entity>(pointer, true), cbseMd_InitializeEntityObject);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x00025990 File Offset: 0x00023B90
		internal readonly DataTable GetDataTable()
		{
			this.NullCheck("GetDataTable");
			method cbseMd_GetDataTable = C_BaseModelEntity.__N.CBseMd_GetDataTable;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetDataTable);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x000259C0 File Offset: 0x00023BC0
		internal readonly int GetEntityHandle()
		{
			this.NullCheck("GetEntityHandle");
			method cbseMd_GetEntityHandle = C_BaseModelEntity.__N.CBseMd_GetEntityHandle;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetEntityHandle);
		}

		// Token: 0x06000291 RID: 657 RVA: 0x000259EC File Offset: 0x00023BEC
		internal readonly string GetClassname()
		{
			this.NullCheck("GetClassname");
			method cbseMd_GetClassname = C_BaseModelEntity.__N.CBseMd_GetClassname;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetClassname));
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00025A1C File Offset: 0x00023C1C
		internal readonly string GetDebugName()
		{
			this.NullCheck("GetDebugName");
			method cbseMd_GetDebugName = C_BaseModelEntity.__N.CBseMd_GetDebugName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetDebugName));
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00025A4C File Offset: 0x00023C4C
		internal readonly int entindex()
		{
			this.NullCheck("entindex");
			method cbseMd_entindex = C_BaseModelEntity.__N.CBseMd_entindex;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_entindex);
		}

		// Token: 0x06000294 RID: 660 RVA: 0x00025A78 File Offset: 0x00023C78
		internal unsafe readonly void SetLocalOrigin(Vector3 v)
		{
			this.NullCheck("SetLocalOrigin");
			method cbseMd_SetLocalOrigin = C_BaseModelEntity.__N.CBseMd_SetLocalOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbseMd_SetLocalOrigin);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x00025AA8 File Offset: 0x00023CA8
		internal readonly Vector3 GetLocalOrigin()
		{
			this.NullCheck("GetLocalOrigin");
			method cbseMd_GetLocalOrigin = C_BaseModelEntity.__N.CBseMd_GetLocalOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbseMd_GetLocalOrigin);
		}

		// Token: 0x06000296 RID: 662 RVA: 0x00025AD4 File Offset: 0x00023CD4
		internal readonly Rotation GetLocalQuat()
		{
			this.NullCheck("GetLocalQuat");
			method cbseMd_GetLocalQuat = C_BaseModelEntity.__N.CBseMd_GetLocalQuat;
			return calli(Rotation(System.IntPtr), this.self, cbseMd_GetLocalQuat);
		}

		// Token: 0x06000297 RID: 663 RVA: 0x00025B00 File Offset: 0x00023D00
		internal unsafe readonly void SetLocalQuat(Rotation rot)
		{
			this.NullCheck("SetLocalQuat");
			method cbseMd_SetLocalQuat = C_BaseModelEntity.__N.CBseMd_SetLocalQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbseMd_SetLocalQuat);
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00025B30 File Offset: 0x00023D30
		internal readonly Rotation GetAbsQuat()
		{
			this.NullCheck("GetAbsQuat");
			method cbseMd_GetAbsQuat = C_BaseModelEntity.__N.CBseMd_GetAbsQuat;
			return calli(Rotation(System.IntPtr), this.self, cbseMd_GetAbsQuat);
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00025B5C File Offset: 0x00023D5C
		internal unsafe readonly void SetAbsQuat(Rotation rot)
		{
			this.NullCheck("SetAbsQuat");
			method cbseMd_SetAbsQuat = C_BaseModelEntity.__N.CBseMd_SetAbsQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbseMd_SetAbsQuat);
		}

		// Token: 0x0600029A RID: 666 RVA: 0x00025B8C File Offset: 0x00023D8C
		internal unsafe readonly void SetAbsOrigin(Vector3 origin)
		{
			this.NullCheck("SetAbsOrigin");
			method cbseMd_SetAbsOrigin = C_BaseModelEntity.__N.CBseMd_SetAbsOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbseMd_SetAbsOrigin);
		}

		// Token: 0x0600029B RID: 667 RVA: 0x00025BBC File Offset: 0x00023DBC
		internal readonly Vector3 GetAbsOrigin()
		{
			this.NullCheck("GetAbsOrigin");
			method cbseMd_GetAbsOrigin = C_BaseModelEntity.__N.CBseMd_GetAbsOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbseMd_GetAbsOrigin);
		}

		// Token: 0x0600029C RID: 668 RVA: 0x00025BE8 File Offset: 0x00023DE8
		internal readonly float GetAbsScale()
		{
			this.NullCheck("GetAbsScale");
			method cbseMd_GetAbsScale = C_BaseModelEntity.__N.CBseMd_GetAbsScale;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetAbsScale);
		}

		// Token: 0x0600029D RID: 669 RVA: 0x00025C14 File Offset: 0x00023E14
		internal readonly void SetAbsScale(float flScale)
		{
			this.NullCheck("SetAbsScale");
			method cbseMd_SetAbsScale = C_BaseModelEntity.__N.CBseMd_SetAbsScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbseMd_SetAbsScale);
		}

		// Token: 0x0600029E RID: 670 RVA: 0x00025C40 File Offset: 0x00023E40
		internal readonly float GetLocalScale()
		{
			this.NullCheck("GetLocalScale");
			method cbseMd_GetLocalScale = C_BaseModelEntity.__N.CBseMd_GetLocalScale;
			return calli(System.Single(System.IntPtr), this.self, cbseMd_GetLocalScale);
		}

		// Token: 0x0600029F RID: 671 RVA: 0x00025C6C File Offset: 0x00023E6C
		internal readonly void SetLocalScale(float flScale)
		{
			this.NullCheck("SetLocalScale");
			method cbseMd_SetLocalScale = C_BaseModelEntity.__N.CBseMd_SetLocalScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbseMd_SetLocalScale);
		}

		// Token: 0x060002A0 RID: 672 RVA: 0x00025C98 File Offset: 0x00023E98
		internal unsafe readonly void SetAbsVelocity(Vector3 origin)
		{
			this.NullCheck("SetAbsVelocity");
			method cbseMd_SetAbsVelocity = C_BaseModelEntity.__N.CBseMd_SetAbsVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbseMd_SetAbsVelocity);
		}

		// Token: 0x060002A1 RID: 673 RVA: 0x00025CC8 File Offset: 0x00023EC8
		internal readonly Vector3 GetAbsVelocity()
		{
			this.NullCheck("GetAbsVelocity");
			method cbseMd_GetAbsVelocity = C_BaseModelEntity.__N.CBseMd_GetAbsVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseMd_GetAbsVelocity);
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00025CF4 File Offset: 0x00023EF4
		internal readonly void AddFlag(int flags)
		{
			this.NullCheck("AddFlag");
			method cbseMd_AddFlag = C_BaseModelEntity.__N.CBseMd_AddFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flags, cbseMd_AddFlag);
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00025D20 File Offset: 0x00023F20
		internal readonly void RemoveFlag(int flagsToRemove)
		{
			this.NullCheck("RemoveFlag");
			method cbseMd_RemoveFlag = C_BaseModelEntity.__N.CBseMd_RemoveFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagsToRemove, cbseMd_RemoveFlag);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00025D4C File Offset: 0x00023F4C
		internal readonly void ToggleFlag(int flagToToggle)
		{
			this.NullCheck("ToggleFlag");
			method cbseMd_ToggleFlag = C_BaseModelEntity.__N.CBseMd_ToggleFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagToToggle, cbseMd_ToggleFlag);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00025D78 File Offset: 0x00023F78
		internal readonly void ClearFlags()
		{
			this.NullCheck("ClearFlags");
			method cbseMd_ClearFlags = C_BaseModelEntity.__N.CBseMd_ClearFlags;
			calli(System.Void(System.IntPtr), this.self, cbseMd_ClearFlags);
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x00025DA4 File Offset: 0x00023FA4
		internal readonly int GetFlags()
		{
			this.NullCheck("GetFlags");
			method cbseMd_GetFlags = C_BaseModelEntity.__N.CBseMd_GetFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetFlags);
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00025DD0 File Offset: 0x00023FD0
		internal readonly void SetLifeState(LifeState state)
		{
			this.NullCheck("SetLifeState");
			method cbseMd_SetLifeState = C_BaseModelEntity.__N.CBseMd_SetLifeState;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)state, cbseMd_SetLifeState);
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00025DFC File Offset: 0x00023FFC
		internal readonly LifeState GetLifeState()
		{
			this.NullCheck("GetLifeState");
			method cbseMd_GetLifeState = C_BaseModelEntity.__N.CBseMd_GetLifeState;
			return calli(System.Int64(System.IntPtr), this.self, cbseMd_GetLifeState);
		}

		// Token: 0x060002A9 RID: 681 RVA: 0x00025E28 File Offset: 0x00024028
		internal readonly int GetEffects()
		{
			this.NullCheck("GetEffects");
			method cbseMd_GetEffects = C_BaseModelEntity.__N.CBseMd_GetEffects;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetEffects);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00025E54 File Offset: 0x00024054
		internal readonly void AddEffects(int nEffects)
		{
			this.NullCheck("AddEffects");
			method cbseMd_AddEffects = C_BaseModelEntity.__N.CBseMd_AddEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseMd_AddEffects);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00025E80 File Offset: 0x00024080
		internal readonly void RemoveEffects(int nEffects)
		{
			this.NullCheck("RemoveEffects");
			method cbseMd_RemoveEffects = C_BaseModelEntity.__N.CBseMd_RemoveEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseMd_RemoveEffects);
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00025EAC File Offset: 0x000240AC
		internal readonly void ClearEffects()
		{
			this.NullCheck("ClearEffects");
			method cbseMd_ClearEffects = C_BaseModelEntity.__N.CBseMd_ClearEffects;
			calli(System.Void(System.IntPtr), this.self, cbseMd_ClearEffects);
		}

		// Token: 0x060002AD RID: 685 RVA: 0x00025ED8 File Offset: 0x000240D8
		internal readonly void SetEffects(int nEffects)
		{
			this.NullCheck("SetEffects");
			method cbseMd_SetEffects = C_BaseModelEntity.__N.CBseMd_SetEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseMd_SetEffects);
		}

		// Token: 0x060002AE RID: 686 RVA: 0x00025F04 File Offset: 0x00024104
		internal readonly bool IsEffectActive(int nEffectMask)
		{
			this.NullCheck("IsEffectActive");
			method cbseMd_IsEffectActive = C_BaseModelEntity.__N.CBseMd_IsEffectActive;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nEffectMask, cbseMd_IsEffectActive) > 0;
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00025F34 File Offset: 0x00024134
		internal readonly void CreateVPhysics()
		{
			this.NullCheck("CreateVPhysics");
			method cbseMd_CreateVPhysics = C_BaseModelEntity.__N.CBseMd_CreateVPhysics;
			calli(System.Void(System.IntPtr), this.self, cbseMd_CreateVPhysics);
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x00025F60 File Offset: 0x00024160
		internal unsafe readonly void ApplyAbsVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyAbsVelocityImpulse");
			method cbseMd_ApplyAbsVelocityImpulse = C_BaseModelEntity.__N.CBseMd_ApplyAbsVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbseMd_ApplyAbsVelocityImpulse);
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00025F90 File Offset: 0x00024190
		internal unsafe readonly void ApplyLocalVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyLocalVelocityImpulse");
			method cbseMd_ApplyLocalVelocityImpulse = C_BaseModelEntity.__N.CBseMd_ApplyLocalVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbseMd_ApplyLocalVelocityImpulse);
		}

		// Token: 0x060002B2 RID: 690 RVA: 0x00025FC0 File Offset: 0x000241C0
		internal unsafe readonly void ApplyLocalAngularVelocityImpulse(Vector3 angImpulse)
		{
			this.NullCheck("ApplyLocalAngularVelocityImpulse");
			method cbseMd_ApplyLocalAngularVelocityImpulse = C_BaseModelEntity.__N.CBseMd_ApplyLocalAngularVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &angImpulse, cbseMd_ApplyLocalAngularVelocityImpulse);
		}

		// Token: 0x060002B3 RID: 691 RVA: 0x00025FF0 File Offset: 0x000241F0
		internal readonly void SetMoveType(MoveType val, MoveCollide moveCollide)
		{
			this.NullCheck("SetMoveType");
			method cbseMd_SetMoveType = C_BaseModelEntity.__N.CBseMd_SetMoveType;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (ulong)val, (ulong)moveCollide, cbseMd_SetMoveType);
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x00026020 File Offset: 0x00024220
		internal readonly MoveType GetMoveType()
		{
			this.NullCheck("GetMoveType");
			method cbseMd_GetMoveType = C_BaseModelEntity.__N.CBseMd_GetMoveType;
			return calli(System.Int64(System.IntPtr), this.self, cbseMd_GetMoveType);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0002604C File Offset: 0x0002424C
		internal readonly void PhysicsEnableMotion(bool bEnable)
		{
			this.NullCheck("PhysicsEnableMotion");
			method cbseMd_PhysicsEnableMotion = C_BaseModelEntity.__N.CBseMd_PhysicsEnableMotion;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnable ? 1 : 0, cbseMd_PhysicsEnableMotion);
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x00026080 File Offset: 0x00024280
		internal readonly void FollowEntity(IntPtr pBaseEntity, bool bBoneMerge)
		{
			this.NullCheck("FollowEntity");
			method cbseMd_FollowEntity = C_BaseModelEntity.__N.CBseMd_FollowEntity;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pBaseEntity, bBoneMerge ? 1 : 0, cbseMd_FollowEntity);
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x000260B4 File Offset: 0x000242B4
		internal readonly void StopFollowingEntity()
		{
			this.NullCheck("StopFollowingEntity");
			method cbseMd_StopFollowingEntity = C_BaseModelEntity.__N.CBseMd_StopFollowingEntity;
			calli(System.Void(System.IntPtr), this.self, cbseMd_StopFollowingEntity);
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x000260E0 File Offset: 0x000242E0
		internal readonly bool IsFollowingEntity()
		{
			this.NullCheck("IsFollowingEntity");
			method cbseMd_IsFollowingEntity = C_BaseModelEntity.__N.CBseMd_IsFollowingEntity;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_IsFollowingEntity) > 0;
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x00026110 File Offset: 0x00024310
		internal readonly C_BaseEntity GetFollowedEntity()
		{
			this.NullCheck("GetFollowedEntity");
			method cbseMd_GetFollowedEntity = C_BaseModelEntity.__N.CBseMd_GetFollowedEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetFollowedEntity);
		}

		// Token: 0x060002BA RID: 698 RVA: 0x00026140 File Offset: 0x00024340
		internal readonly PhysicsGroup VPhysicsGetAggregate()
		{
			this.NullCheck("VPhysicsGetAggregate");
			method cbseMd_VPhysicsGetAggregate = C_BaseModelEntity.__N.CBseMd_VPhysicsGetAggregate;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr), this.self, cbseMd_VPhysicsGetAggregate));
		}

		// Token: 0x060002BB RID: 699 RVA: 0x00026170 File Offset: 0x00024370
		internal readonly Vector3 GetBaseVelocity()
		{
			this.NullCheck("GetBaseVelocity");
			method cbseMd_GetBaseVelocity = C_BaseModelEntity.__N.CBseMd_GetBaseVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseMd_GetBaseVelocity);
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0002619C File Offset: 0x0002439C
		internal unsafe readonly void SetBaseVelocity(Vector3 v)
		{
			this.NullCheck("SetBaseVelocity");
			method cbseMd_SetBaseVelocity = C_BaseModelEntity.__N.CBseMd_SetBaseVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbseMd_SetBaseVelocity);
		}

		// Token: 0x060002BD RID: 701 RVA: 0x000261CC File Offset: 0x000243CC
		internal readonly void SetGroundEntity(C_BaseEntity ground)
		{
			this.NullCheck("SetGroundEntity");
			method cbseMd_SetGroundEntity = C_BaseModelEntity.__N.CBseMd_SetGroundEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ground, cbseMd_SetGroundEntity);
		}

		// Token: 0x060002BE RID: 702 RVA: 0x000261FC File Offset: 0x000243FC
		internal readonly C_BaseEntity GetGroundEntity()
		{
			this.NullCheck("GetGroundEntity");
			method cbseMd_GetGroundEntity = C_BaseModelEntity.__N.CBseMd_GetGroundEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetGroundEntity);
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0002622C File Offset: 0x0002442C
		internal readonly string GetModelNameString()
		{
			this.NullCheck("GetModelNameString");
			method cbseMd_GetModelNameString = C_BaseModelEntity.__N.CBseMd_GetModelNameString;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetModelNameString));
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x0002625C File Offset: 0x0002445C
		internal unsafe readonly void SetParent(C_BaseEntity parent, string nBoneOrAttachName, Transform pOffsetTransform)
		{
			this.NullCheck("SetParent");
			method cbseMd_SetParent = C_BaseModelEntity.__N.CBseMd_SetParent;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32,Transform*), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), &pOffsetTransform, cbseMd_SetParent);
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x00026298 File Offset: 0x00024498
		internal readonly void SetParent(C_BaseEntity parent, string nBoneOrAttachName)
		{
			this.NullCheck("SetParent");
			method cbseMd_f = C_BaseModelEntity.__N.CBseMd_f4;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), cbseMd_f);
		}

		// Token: 0x060002C2 RID: 706 RVA: 0x000262D0 File Offset: 0x000244D0
		internal readonly C_BaseEntity GetParent()
		{
			this.NullCheck("GetParent");
			method cbseMd_GetParent = C_BaseModelEntity.__N.CBseMd_GetParent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetParent);
		}

		// Token: 0x060002C3 RID: 707 RVA: 0x00026300 File Offset: 0x00024500
		internal readonly void ResetLatched()
		{
			this.NullCheck("ResetLatched");
			method cbseMd_ResetLatched = C_BaseModelEntity.__N.CBseMd_ResetLatched;
			calli(System.Void(System.IntPtr), this.self, cbseMd_ResetLatched);
		}

		// Token: 0x060002C4 RID: 708 RVA: 0x0002632C File Offset: 0x0002452C
		internal readonly void SetActiveChild(C_BaseEntity child)
		{
			this.NullCheck("SetActiveChild");
			method cbseMd_SetActiveChild = C_BaseModelEntity.__N.CBseMd_SetActiveChild;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbseMd_SetActiveChild);
		}

		// Token: 0x060002C5 RID: 709 RVA: 0x0002635C File Offset: 0x0002455C
		internal readonly C_BaseEntity GetActiveChild()
		{
			this.NullCheck("GetActiveChild");
			method cbseMd_GetActiveChild = C_BaseModelEntity.__N.CBseMd_GetActiveChild;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetActiveChild);
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0002638C File Offset: 0x0002458C
		internal readonly void SetOwnerEntity(C_BaseEntity child)
		{
			this.NullCheck("SetOwnerEntity");
			method cbseMd_SetOwnerEntity = C_BaseModelEntity.__N.CBseMd_SetOwnerEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbseMd_SetOwnerEntity);
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x000263BC File Offset: 0x000245BC
		internal readonly C_BaseEntity GetOwnerEntity()
		{
			this.NullCheck("GetOwnerEntity");
			method cbseMd_GetOwnerEntity = C_BaseModelEntity.__N.CBseMd_GetOwnerEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetOwnerEntity);
		}

		// Token: 0x060002C8 RID: 712 RVA: 0x000263EC File Offset: 0x000245EC
		internal readonly void EnableSceneObjectOverride(bool bEnableOverride)
		{
			this.NullCheck("EnableSceneObjectOverride");
			method cbseMd_EnableSceneObjectOverride = C_BaseModelEntity.__N.CBseMd_EnableSceneObjectOverride;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnableOverride ? 1 : 0, cbseMd_EnableSceneObjectOverride);
		}

		// Token: 0x060002C9 RID: 713 RVA: 0x00026420 File Offset: 0x00024620
		internal readonly void SetSimulationTime(float time)
		{
			this.NullCheck("SetSimulationTime");
			method cbseMd_SetSimulationTime = C_BaseModelEntity.__N.CBseMd_SetSimulationTime;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbseMd_SetSimulationTime);
		}

		// Token: 0x060002CA RID: 714 RVA: 0x0002644C File Offset: 0x0002464C
		internal readonly bool HasSpawnFlags(int nFlags)
		{
			this.NullCheck("HasSpawnFlags");
			method cbseMd_HasSpawnFlags = C_BaseModelEntity.__N.CBseMd_HasSpawnFlags;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nFlags, cbseMd_HasSpawnFlags) > 0;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0002647C File Offset: 0x0002467C
		internal readonly int GetSpawnFlags()
		{
			this.NullCheck("GetSpawnFlags");
			method cbseMd_GetSpawnFlags = C_BaseModelEntity.__N.CBseMd_GetSpawnFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetSpawnFlags);
		}

		// Token: 0x060002CC RID: 716 RVA: 0x000264A8 File Offset: 0x000246A8
		internal readonly void AddSpawnFlags(int nFlags)
		{
			this.NullCheck("AddSpawnFlags");
			method cbseMd_AddSpawnFlags = C_BaseModelEntity.__N.CBseMd_AddSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbseMd_AddSpawnFlags);
		}

		// Token: 0x060002CD RID: 717 RVA: 0x000264D4 File Offset: 0x000246D4
		internal readonly void RemoveSpawnFlags(int nFlags)
		{
			this.NullCheck("RemoveSpawnFlags");
			method cbseMd_RemoveSpawnFlags = C_BaseModelEntity.__N.CBseMd_RemoveSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbseMd_RemoveSpawnFlags);
		}

		// Token: 0x060002CE RID: 718 RVA: 0x00026500 File Offset: 0x00024700
		internal readonly void ClearSpawnFlags()
		{
			this.NullCheck("ClearSpawnFlags");
			method cbseMd_ClearSpawnFlags = C_BaseModelEntity.__N.CBseMd_ClearSpawnFlags;
			calli(System.Void(System.IntPtr), this.self, cbseMd_ClearSpawnFlags);
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0002652C File Offset: 0x0002472C
		internal readonly CLightComponent GetLightComponent()
		{
			this.NullCheck("GetLightComponent");
			method cbseMd_GetLightComponent = C_BaseModelEntity.__N.CBseMd_GetLightComponent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseMd_GetLightComponent);
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0002655C File Offset: 0x0002475C
		internal unsafe readonly void SetLocalVelocity(Vector3 vecVelocity)
		{
			this.NullCheck("SetLocalVelocity");
			method cbseMd_SetLocalVelocity = C_BaseModelEntity.__N.CBseMd_SetLocalVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecVelocity, cbseMd_SetLocalVelocity);
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0002658C File Offset: 0x0002478C
		internal readonly Vector3 GetLocalVelocity()
		{
			this.NullCheck("GetLocalVelocity");
			method cbseMd_GetLocalVelocity = C_BaseModelEntity.__N.CBseMd_GetLocalVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseMd_GetLocalVelocity);
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x000265B8 File Offset: 0x000247B8
		internal unsafe readonly void SetLocalAngularVelocity(Angles vecAngVelocity)
		{
			this.NullCheck("SetLocalAngularVelocity");
			method cbseMd_SetLocalAngularVelocity = C_BaseModelEntity.__N.CBseMd_SetLocalAngularVelocity;
			calli(System.Void(System.IntPtr,Angles*), this.self, &vecAngVelocity, cbseMd_SetLocalAngularVelocity);
		}

		// Token: 0x060002D3 RID: 723 RVA: 0x000265E8 File Offset: 0x000247E8
		internal readonly Angles GetLocalAngularVelocity()
		{
			this.NullCheck("GetLocalAngularVelocity");
			method cbseMd_GetLocalAngularVelocity = C_BaseModelEntity.__N.CBseMd_GetLocalAngularVelocity;
			return calli(Angles(System.IntPtr), this.self, cbseMd_GetLocalAngularVelocity);
		}

		// Token: 0x060002D4 RID: 724 RVA: 0x00026614 File Offset: 0x00024814
		internal readonly void SetDebugBits(ulong nBitMask)
		{
			this.NullCheck("SetDebugBits");
			method cbseMd_SetDebugBits = C_BaseModelEntity.__N.CBseMd_SetDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseMd_SetDebugBits);
		}

		// Token: 0x060002D5 RID: 725 RVA: 0x00026640 File Offset: 0x00024840
		internal readonly bool HasDebugBitsSet(ulong nBitMask)
		{
			this.NullCheck("HasDebugBitsSet");
			method cbseMd_HasDebugBitsSet = C_BaseModelEntity.__N.CBseMd_HasDebugBitsSet;
			return calli(System.Int32(System.IntPtr,System.UInt64), this.self, nBitMask, cbseMd_HasDebugBitsSet) > 0;
		}

		// Token: 0x060002D6 RID: 726 RVA: 0x00026670 File Offset: 0x00024870
		internal readonly void ClearDebugBits(ulong nBitMask)
		{
			this.NullCheck("ClearDebugBits");
			method cbseMd_ClearDebugBits = C_BaseModelEntity.__N.CBseMd_ClearDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseMd_ClearDebugBits);
		}

		// Token: 0x060002D7 RID: 727 RVA: 0x0002669C File Offset: 0x0002489C
		internal readonly void ToggleDebugBits(ulong nBitMask)
		{
			this.NullCheck("ToggleDebugBits");
			method cbseMd_ToggleDebugBits = C_BaseModelEntity.__N.CBseMd_ToggleDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseMd_ToggleDebugBits);
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x000266C8 File Offset: 0x000248C8
		internal readonly ulong GetDebugBits()
		{
			this.NullCheck("GetDebugBits");
			method cbseMd_GetDebugBits = C_BaseModelEntity.__N.CBseMd_GetDebugBits;
			return calli(System.UInt64(System.IntPtr), this.self, cbseMd_GetDebugBits);
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x000266F4 File Offset: 0x000248F4
		internal readonly void MarkRenderHandleDirty()
		{
			this.NullCheck("MarkRenderHandleDirty");
			method cbseMd_MarkRenderHandleDirty = C_BaseModelEntity.__N.CBseMd_MarkRenderHandleDirty;
			calli(System.Void(System.IntPtr), this.self, cbseMd_MarkRenderHandleDirty);
		}

		// Token: 0x060002DA RID: 730 RVA: 0x00026720 File Offset: 0x00024920
		internal readonly void SetWaterEntity(C_BaseEntity ent)
		{
			this.NullCheck("SetWaterEntity");
			method cbseMd_SetWaterEntity = C_BaseModelEntity.__N.CBseMd_SetWaterEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ent, cbseMd_SetWaterEntity);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x00026750 File Offset: 0x00024950
		internal readonly Entity GetWaterEntity()
		{
			this.NullCheck("GetWaterEntity");
			method cbseMd_GetWaterEntity = C_BaseModelEntity.__N.CBseMd_GetWaterEntity;
			return InteropSystem.Get<Entity>(calli(System.UInt32(System.IntPtr), this.self, cbseMd_GetWaterEntity));
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00026780 File Offset: 0x00024980
		internal readonly void WorldSpaceAABB(out Vector3 mins, out Vector3 maxs)
		{
			this.NullCheck("WorldSpaceAABB");
			method cbseMd_WorldSpaceAABB = C_BaseModelEntity.__N.CBseMd_WorldSpaceAABB;
			calli(System.Void(System.IntPtr,Vector3& modreq(System.Runtime.InteropServices.OutAttribute),Vector3& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, ref mins, ref maxs, cbseMd_WorldSpaceAABB);
		}

		// Token: 0x060002DD RID: 733 RVA: 0x000267AC File Offset: 0x000249AC
		internal readonly void RemoveAllDecals()
		{
			this.NullCheck("RemoveAllDecals");
			method cbseMd_RemoveAllDecals = C_BaseModelEntity.__N.CBseMd_RemoveAllDecals;
			calli(System.Void(System.IntPtr), this.self, cbseMd_RemoveAllDecals);
		}

		// Token: 0x060002DE RID: 734 RVA: 0x000267D8 File Offset: 0x000249D8
		internal readonly bool GetPredictable()
		{
			this.NullCheck("GetPredictable");
			method cbseMd_GetPredictable = C_BaseModelEntity.__N.CBseMd_GetPredictable;
			return calli(System.Int32(System.IntPtr), this.self, cbseMd_GetPredictable) > 0;
		}

		// Token: 0x060002DF RID: 735 RVA: 0x00026808 File Offset: 0x00024A08
		internal readonly string SB_GetEntityName()
		{
			this.NullCheck("SB_GetEntityName");
			method cbseMd_SB_GetEntityName = C_BaseModelEntity.__N.CBseMd_SB_GetEntityName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseMd_SB_GetEntityName));
		}

		// Token: 0x060002E0 RID: 736 RVA: 0x00026838 File Offset: 0x00024A38
		internal readonly void SB_SetEntityName(string name)
		{
			this.NullCheck("SB_SetEntityName");
			method cbseMd_SB_SetEntityName = C_BaseModelEntity.__N.CBseMd_SB_SetEntityName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseMd_SB_SetEntityName);
		}

		// Token: 0x060002E1 RID: 737 RVA: 0x00026868 File Offset: 0x00024A68
		internal readonly IntPtr GetData(int index, bool local, out int size)
		{
			this.NullCheck("GetData");
			method cbseMd_GetData = C_BaseModelEntity.__N.CBseMd_GetData;
			return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32,System.Int32& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, index, local ? 1 : 0, ref size, cbseMd_GetData);
		}

		// Token: 0x0400009E RID: 158
		internal IntPtr self;

		// Token: 0x020001A1 RID: 417
		internal static class __N
		{
			// Token: 0x040008C6 RID: 2246
			internal static method From_C_BaseEntity_To_C_BaseModelEntity;

			// Token: 0x040008C7 RID: 2247
			internal static method To_C_BaseEntity_From_C_BaseModelEntity;

			// Token: 0x040008C8 RID: 2248
			internal static method From_CGameEntity_To_C_BaseModelEntity;

			// Token: 0x040008C9 RID: 2249
			internal static method To_CGameEntity_From_C_BaseModelEntity;

			// Token: 0x040008CA RID: 2250
			internal static method From_CEntityInstance_To_C_BaseModelEntity;

			// Token: 0x040008CB RID: 2251
			internal static method To_CEntityInstance_From_C_BaseModelEntity;

			// Token: 0x040008CC RID: 2252
			internal static method From_IHandleEntity_To_C_BaseModelEntity;

			// Token: 0x040008CD RID: 2253
			internal static method To_IHandleEntity_From_C_BaseModelEntity;

			// Token: 0x040008CE RID: 2254
			internal static method CBseMd_GetSkeletonInstance;

			// Token: 0x040008CF RID: 2255
			internal static method CBseMd_SetModelScale;

			// Token: 0x040008D0 RID: 2256
			internal static method CBseMd_GetModelScale;

			// Token: 0x040008D1 RID: 2257
			internal static method CBseMd_GetNumBones;

			// Token: 0x040008D2 RID: 2258
			internal static method CBseMd_LookupBone;

			// Token: 0x040008D3 RID: 2259
			internal static method CBseMd_GetAttachmentCount;

			// Token: 0x040008D4 RID: 2260
			internal static method CBseMd_GetMinFadeDist;

			// Token: 0x040008D5 RID: 2261
			internal static method CBseMd_GetMaxFadeDist;

			// Token: 0x040008D6 RID: 2262
			internal static method CBseMd_SetModel;

			// Token: 0x040008D7 RID: 2263
			internal static method CBseMd_SetModelAsync;

			// Token: 0x040008D8 RID: 2264
			internal static method CBseMd_GetModel;

			// Token: 0x040008D9 RID: 2265
			internal static method CBseMd_f2;

			// Token: 0x040008DA RID: 2266
			internal static method CBseMd_SetBodygroup;

			// Token: 0x040008DB RID: 2267
			internal static method CBseMd_SetBodygroupByName;

			// Token: 0x040008DC RID: 2268
			internal static method CBseMd_GetRawMeshGroupMask;

			// Token: 0x040008DD RID: 2269
			internal static method CBseMd_SetRawMeshGroupMask_LegacyDoNotUse;

			// Token: 0x040008DE RID: 2270
			internal static method CBseMd_GetSkinCount;

			// Token: 0x040008DF RID: 2271
			internal static method CBseMd_SetSkin;

			// Token: 0x040008E0 RID: 2272
			internal static method CBseMd_f3;

			// Token: 0x040008E1 RID: 2273
			internal static method CBseMd_GetS1Skin;

			// Token: 0x040008E2 RID: 2274
			internal static method CBseMd_CollisionProp;

			// Token: 0x040008E3 RID: 2275
			internal static method CBseMd_SetRenderAlpha;

			// Token: 0x040008E4 RID: 2276
			internal static method CBseMd_GetRenderAlpha;

			// Token: 0x040008E5 RID: 2277
			internal static method CBseMd_SetRenderColor;

			// Token: 0x040008E6 RID: 2278
			internal static method CBseMd_SetRenderColorAndAlpha;

			// Token: 0x040008E7 RID: 2279
			internal static method CBseMd_GetRenderColor;

			// Token: 0x040008E8 RID: 2280
			internal static method CBseMd_GlowProp;

			// Token: 0x040008E9 RID: 2281
			internal static method CBseMd_SetSceneLayerID;

			// Token: 0x040008EA RID: 2282
			internal static method CBseMd_GetSceneObjectCount;

			// Token: 0x040008EB RID: 2283
			internal static method CBseMd_GetSceneObject;

			// Token: 0x040008EC RID: 2284
			internal static method CBseMd_GetBoneTransform;

			// Token: 0x040008ED RID: 2285
			internal static method CBseMd_InitializeEntityObject;

			// Token: 0x040008EE RID: 2286
			internal static method CBseMd_GetDataTable;

			// Token: 0x040008EF RID: 2287
			internal static method CBseMd_GetEntityHandle;

			// Token: 0x040008F0 RID: 2288
			internal static method CBseMd_GetClassname;

			// Token: 0x040008F1 RID: 2289
			internal static method CBseMd_GetDebugName;

			// Token: 0x040008F2 RID: 2290
			internal static method CBseMd_entindex;

			// Token: 0x040008F3 RID: 2291
			internal static method CBseMd_SetLocalOrigin;

			// Token: 0x040008F4 RID: 2292
			internal static method CBseMd_GetLocalOrigin;

			// Token: 0x040008F5 RID: 2293
			internal static method CBseMd_GetLocalQuat;

			// Token: 0x040008F6 RID: 2294
			internal static method CBseMd_SetLocalQuat;

			// Token: 0x040008F7 RID: 2295
			internal static method CBseMd_GetAbsQuat;

			// Token: 0x040008F8 RID: 2296
			internal static method CBseMd_SetAbsQuat;

			// Token: 0x040008F9 RID: 2297
			internal static method CBseMd_SetAbsOrigin;

			// Token: 0x040008FA RID: 2298
			internal static method CBseMd_GetAbsOrigin;

			// Token: 0x040008FB RID: 2299
			internal static method CBseMd_GetAbsScale;

			// Token: 0x040008FC RID: 2300
			internal static method CBseMd_SetAbsScale;

			// Token: 0x040008FD RID: 2301
			internal static method CBseMd_GetLocalScale;

			// Token: 0x040008FE RID: 2302
			internal static method CBseMd_SetLocalScale;

			// Token: 0x040008FF RID: 2303
			internal static method CBseMd_SetAbsVelocity;

			// Token: 0x04000900 RID: 2304
			internal static method CBseMd_GetAbsVelocity;

			// Token: 0x04000901 RID: 2305
			internal static method CBseMd_AddFlag;

			// Token: 0x04000902 RID: 2306
			internal static method CBseMd_RemoveFlag;

			// Token: 0x04000903 RID: 2307
			internal static method CBseMd_ToggleFlag;

			// Token: 0x04000904 RID: 2308
			internal static method CBseMd_ClearFlags;

			// Token: 0x04000905 RID: 2309
			internal static method CBseMd_GetFlags;

			// Token: 0x04000906 RID: 2310
			internal static method CBseMd_SetLifeState;

			// Token: 0x04000907 RID: 2311
			internal static method CBseMd_GetLifeState;

			// Token: 0x04000908 RID: 2312
			internal static method CBseMd_GetEffects;

			// Token: 0x04000909 RID: 2313
			internal static method CBseMd_AddEffects;

			// Token: 0x0400090A RID: 2314
			internal static method CBseMd_RemoveEffects;

			// Token: 0x0400090B RID: 2315
			internal static method CBseMd_ClearEffects;

			// Token: 0x0400090C RID: 2316
			internal static method CBseMd_SetEffects;

			// Token: 0x0400090D RID: 2317
			internal static method CBseMd_IsEffectActive;

			// Token: 0x0400090E RID: 2318
			internal static method CBseMd_CreateVPhysics;

			// Token: 0x0400090F RID: 2319
			internal static method CBseMd_ApplyAbsVelocityImpulse;

			// Token: 0x04000910 RID: 2320
			internal static method CBseMd_ApplyLocalVelocityImpulse;

			// Token: 0x04000911 RID: 2321
			internal static method CBseMd_ApplyLocalAngularVelocityImpulse;

			// Token: 0x04000912 RID: 2322
			internal static method CBseMd_SetMoveType;

			// Token: 0x04000913 RID: 2323
			internal static method CBseMd_GetMoveType;

			// Token: 0x04000914 RID: 2324
			internal static method CBseMd_PhysicsEnableMotion;

			// Token: 0x04000915 RID: 2325
			internal static method CBseMd_FollowEntity;

			// Token: 0x04000916 RID: 2326
			internal static method CBseMd_StopFollowingEntity;

			// Token: 0x04000917 RID: 2327
			internal static method CBseMd_IsFollowingEntity;

			// Token: 0x04000918 RID: 2328
			internal static method CBseMd_GetFollowedEntity;

			// Token: 0x04000919 RID: 2329
			internal static method CBseMd_VPhysicsGetAggregate;

			// Token: 0x0400091A RID: 2330
			internal static method CBseMd_GetBaseVelocity;

			// Token: 0x0400091B RID: 2331
			internal static method CBseMd_SetBaseVelocity;

			// Token: 0x0400091C RID: 2332
			internal static method CBseMd_SetGroundEntity;

			// Token: 0x0400091D RID: 2333
			internal static method CBseMd_GetGroundEntity;

			// Token: 0x0400091E RID: 2334
			internal static method CBseMd_GetModelNameString;

			// Token: 0x0400091F RID: 2335
			internal static method CBseMd_SetParent;

			// Token: 0x04000920 RID: 2336
			internal static method CBseMd_f4;

			// Token: 0x04000921 RID: 2337
			internal static method CBseMd_GetParent;

			// Token: 0x04000922 RID: 2338
			internal static method CBseMd_ResetLatched;

			// Token: 0x04000923 RID: 2339
			internal static method CBseMd_SetActiveChild;

			// Token: 0x04000924 RID: 2340
			internal static method CBseMd_GetActiveChild;

			// Token: 0x04000925 RID: 2341
			internal static method CBseMd_SetOwnerEntity;

			// Token: 0x04000926 RID: 2342
			internal static method CBseMd_GetOwnerEntity;

			// Token: 0x04000927 RID: 2343
			internal static method CBseMd_EnableSceneObjectOverride;

			// Token: 0x04000928 RID: 2344
			internal static method CBseMd_SetSimulationTime;

			// Token: 0x04000929 RID: 2345
			internal static method CBseMd_HasSpawnFlags;

			// Token: 0x0400092A RID: 2346
			internal static method CBseMd_GetSpawnFlags;

			// Token: 0x0400092B RID: 2347
			internal static method CBseMd_AddSpawnFlags;

			// Token: 0x0400092C RID: 2348
			internal static method CBseMd_RemoveSpawnFlags;

			// Token: 0x0400092D RID: 2349
			internal static method CBseMd_ClearSpawnFlags;

			// Token: 0x0400092E RID: 2350
			internal static method CBseMd_GetLightComponent;

			// Token: 0x0400092F RID: 2351
			internal static method CBseMd_SetLocalVelocity;

			// Token: 0x04000930 RID: 2352
			internal static method CBseMd_GetLocalVelocity;

			// Token: 0x04000931 RID: 2353
			internal static method CBseMd_SetLocalAngularVelocity;

			// Token: 0x04000932 RID: 2354
			internal static method CBseMd_GetLocalAngularVelocity;

			// Token: 0x04000933 RID: 2355
			internal static method CBseMd_SetDebugBits;

			// Token: 0x04000934 RID: 2356
			internal static method CBseMd_HasDebugBitsSet;

			// Token: 0x04000935 RID: 2357
			internal static method CBseMd_ClearDebugBits;

			// Token: 0x04000936 RID: 2358
			internal static method CBseMd_ToggleDebugBits;

			// Token: 0x04000937 RID: 2359
			internal static method CBseMd_GetDebugBits;

			// Token: 0x04000938 RID: 2360
			internal static method CBseMd_MarkRenderHandleDirty;

			// Token: 0x04000939 RID: 2361
			internal static method CBseMd_SetWaterEntity;

			// Token: 0x0400093A RID: 2362
			internal static method CBseMd_GetWaterEntity;

			// Token: 0x0400093B RID: 2363
			internal static method CBseMd_WorldSpaceAABB;

			// Token: 0x0400093C RID: 2364
			internal static method CBseMd_RemoveAllDecals;

			// Token: 0x0400093D RID: 2365
			internal static method CBseMd_GetPredictable;

			// Token: 0x0400093E RID: 2366
			internal static method CBseMd_SB_GetEntityName;

			// Token: 0x0400093F RID: 2367
			internal static method CBseMd_SB_SetEntityName;

			// Token: 0x04000940 RID: 2368
			internal static method CBseMd_GetData;
		}
	}
}
