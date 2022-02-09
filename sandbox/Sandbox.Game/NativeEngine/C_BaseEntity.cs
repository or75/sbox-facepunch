using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200001B RID: 27
	internal struct C_BaseEntity
	{
		// Token: 0x060001E8 RID: 488 RVA: 0x00023E9F File Offset: 0x0002209F
		public static implicit operator IntPtr(C_BaseEntity value)
		{
			return value.self;
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x00023EA8 File Offset: 0x000220A8
		public static implicit operator C_BaseEntity(IntPtr value)
		{
			return new C_BaseEntity
			{
				self = value
			};
		}

		// Token: 0x060001EA RID: 490 RVA: 0x00023EC6 File Offset: 0x000220C6
		public static bool operator ==(C_BaseEntity c1, C_BaseEntity c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00023ED9 File Offset: 0x000220D9
		public static bool operator !=(C_BaseEntity c1, C_BaseEntity c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00023EEC File Offset: 0x000220EC
		public override bool Equals(object obj)
		{
			if (obj is C_BaseEntity)
			{
				C_BaseEntity c = (C_BaseEntity)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x00023F16 File Offset: 0x00022116
		internal C_BaseEntity(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00023F20 File Offset: 0x00022120
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
			defaultInterpolatedStringHandler.AppendLiteral("C_BaseEntity ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060001EF RID: 495 RVA: 0x00023F5C File Offset: 0x0002215C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060001F0 RID: 496 RVA: 0x00023F6E File Offset: 0x0002216E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060001F1 RID: 497 RVA: 0x00023F79 File Offset: 0x00022179
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060001F2 RID: 498 RVA: 0x00023F8C File Offset: 0x0002218C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("C_BaseEntity was null when calling " + n);
			}
		}

		// Token: 0x060001F3 RID: 499 RVA: 0x00023FA7 File Offset: 0x000221A7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060001F4 RID: 500 RVA: 0x00023FB4 File Offset: 0x000221B4
		public static implicit operator CGameEntity(C_BaseEntity value)
		{
			method to_CGameEntity_From_C_BaseEntity = C_BaseEntity.__N.To_CGameEntity_From_C_BaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_CGameEntity_From_C_BaseEntity);
		}

		// Token: 0x060001F5 RID: 501 RVA: 0x00023FD8 File Offset: 0x000221D8
		public static explicit operator C_BaseEntity(CGameEntity value)
		{
			method from_CGameEntity_To_C_BaseEntity = C_BaseEntity.__N.From_CGameEntity_To_C_BaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_CGameEntity_To_C_BaseEntity);
		}

		// Token: 0x060001F6 RID: 502 RVA: 0x00023FFC File Offset: 0x000221FC
		public static implicit operator CEntityInstance(C_BaseEntity value)
		{
			method to_CEntityInstance_From_C_BaseEntity = C_BaseEntity.__N.To_CEntityInstance_From_C_BaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_CEntityInstance_From_C_BaseEntity);
		}

		// Token: 0x060001F7 RID: 503 RVA: 0x00024020 File Offset: 0x00022220
		public static explicit operator C_BaseEntity(CEntityInstance value)
		{
			method from_CEntityInstance_To_C_BaseEntity = C_BaseEntity.__N.From_CEntityInstance_To_C_BaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_CEntityInstance_To_C_BaseEntity);
		}

		// Token: 0x060001F8 RID: 504 RVA: 0x00024044 File Offset: 0x00022244
		public static implicit operator IHandleEntity(C_BaseEntity value)
		{
			method to_IHandleEntity_From_C_BaseEntity = C_BaseEntity.__N.To_IHandleEntity_From_C_BaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_IHandleEntity_From_C_BaseEntity);
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00024068 File Offset: 0x00022268
		public static explicit operator C_BaseEntity(IHandleEntity value)
		{
			method from_IHandleEntity_To_C_BaseEntity = C_BaseEntity.__N.From_IHandleEntity_To_C_BaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_IHandleEntity_To_C_BaseEntity);
		}

		// Token: 0x060001FA RID: 506 RVA: 0x0002408C File Offset: 0x0002228C
		internal readonly void InitializeEntityObject(Entity pointer)
		{
			this.NullCheck("InitializeEntityObject");
			method cbseEn_InitializeEntityObject = C_BaseEntity.__N.CBseEn_InitializeEntityObject;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, (pointer == null) ? 0U : InteropSystem.GetAddress<Entity>(pointer, true), cbseEn_InitializeEntityObject);
		}

		// Token: 0x060001FB RID: 507 RVA: 0x000240C4 File Offset: 0x000222C4
		internal readonly DataTable GetDataTable()
		{
			this.NullCheck("GetDataTable");
			method cbseEn_GetDataTable = C_BaseEntity.__N.CBseEn_GetDataTable;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetDataTable);
		}

		// Token: 0x060001FC RID: 508 RVA: 0x000240F4 File Offset: 0x000222F4
		internal readonly int GetEntityHandle()
		{
			this.NullCheck("GetEntityHandle");
			method cbseEn_GetEntityHandle = C_BaseEntity.__N.CBseEn_GetEntityHandle;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_GetEntityHandle);
		}

		// Token: 0x060001FD RID: 509 RVA: 0x00024120 File Offset: 0x00022320
		internal readonly string GetClassname()
		{
			this.NullCheck("GetClassname");
			method cbseEn_GetClassname = C_BaseEntity.__N.CBseEn_GetClassname;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetClassname));
		}

		// Token: 0x060001FE RID: 510 RVA: 0x00024150 File Offset: 0x00022350
		internal readonly string GetDebugName()
		{
			this.NullCheck("GetDebugName");
			method cbseEn_GetDebugName = C_BaseEntity.__N.CBseEn_GetDebugName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetDebugName));
		}

		// Token: 0x060001FF RID: 511 RVA: 0x00024180 File Offset: 0x00022380
		internal readonly int entindex()
		{
			this.NullCheck("entindex");
			method cbseEn_entindex = C_BaseEntity.__N.CBseEn_entindex;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_entindex);
		}

		// Token: 0x06000200 RID: 512 RVA: 0x000241AC File Offset: 0x000223AC
		internal unsafe readonly void SetLocalOrigin(Vector3 v)
		{
			this.NullCheck("SetLocalOrigin");
			method cbseEn_SetLocalOrigin = C_BaseEntity.__N.CBseEn_SetLocalOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbseEn_SetLocalOrigin);
		}

		// Token: 0x06000201 RID: 513 RVA: 0x000241DC File Offset: 0x000223DC
		internal readonly Vector3 GetLocalOrigin()
		{
			this.NullCheck("GetLocalOrigin");
			method cbseEn_GetLocalOrigin = C_BaseEntity.__N.CBseEn_GetLocalOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbseEn_GetLocalOrigin);
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00024208 File Offset: 0x00022408
		internal readonly Rotation GetLocalQuat()
		{
			this.NullCheck("GetLocalQuat");
			method cbseEn_GetLocalQuat = C_BaseEntity.__N.CBseEn_GetLocalQuat;
			return calli(Rotation(System.IntPtr), this.self, cbseEn_GetLocalQuat);
		}

		// Token: 0x06000203 RID: 515 RVA: 0x00024234 File Offset: 0x00022434
		internal unsafe readonly void SetLocalQuat(Rotation rot)
		{
			this.NullCheck("SetLocalQuat");
			method cbseEn_SetLocalQuat = C_BaseEntity.__N.CBseEn_SetLocalQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbseEn_SetLocalQuat);
		}

		// Token: 0x06000204 RID: 516 RVA: 0x00024264 File Offset: 0x00022464
		internal readonly Rotation GetAbsQuat()
		{
			this.NullCheck("GetAbsQuat");
			method cbseEn_GetAbsQuat = C_BaseEntity.__N.CBseEn_GetAbsQuat;
			return calli(Rotation(System.IntPtr), this.self, cbseEn_GetAbsQuat);
		}

		// Token: 0x06000205 RID: 517 RVA: 0x00024290 File Offset: 0x00022490
		internal unsafe readonly void SetAbsQuat(Rotation rot)
		{
			this.NullCheck("SetAbsQuat");
			method cbseEn_SetAbsQuat = C_BaseEntity.__N.CBseEn_SetAbsQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbseEn_SetAbsQuat);
		}

		// Token: 0x06000206 RID: 518 RVA: 0x000242C0 File Offset: 0x000224C0
		internal unsafe readonly void SetAbsOrigin(Vector3 origin)
		{
			this.NullCheck("SetAbsOrigin");
			method cbseEn_SetAbsOrigin = C_BaseEntity.__N.CBseEn_SetAbsOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbseEn_SetAbsOrigin);
		}

		// Token: 0x06000207 RID: 519 RVA: 0x000242F0 File Offset: 0x000224F0
		internal readonly Vector3 GetAbsOrigin()
		{
			this.NullCheck("GetAbsOrigin");
			method cbseEn_GetAbsOrigin = C_BaseEntity.__N.CBseEn_GetAbsOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbseEn_GetAbsOrigin);
		}

		// Token: 0x06000208 RID: 520 RVA: 0x0002431C File Offset: 0x0002251C
		internal readonly float GetAbsScale()
		{
			this.NullCheck("GetAbsScale");
			method cbseEn_GetAbsScale = C_BaseEntity.__N.CBseEn_GetAbsScale;
			return calli(System.Single(System.IntPtr), this.self, cbseEn_GetAbsScale);
		}

		// Token: 0x06000209 RID: 521 RVA: 0x00024348 File Offset: 0x00022548
		internal readonly void SetAbsScale(float flScale)
		{
			this.NullCheck("SetAbsScale");
			method cbseEn_SetAbsScale = C_BaseEntity.__N.CBseEn_SetAbsScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbseEn_SetAbsScale);
		}

		// Token: 0x0600020A RID: 522 RVA: 0x00024374 File Offset: 0x00022574
		internal readonly float GetLocalScale()
		{
			this.NullCheck("GetLocalScale");
			method cbseEn_GetLocalScale = C_BaseEntity.__N.CBseEn_GetLocalScale;
			return calli(System.Single(System.IntPtr), this.self, cbseEn_GetLocalScale);
		}

		// Token: 0x0600020B RID: 523 RVA: 0x000243A0 File Offset: 0x000225A0
		internal readonly void SetLocalScale(float flScale)
		{
			this.NullCheck("SetLocalScale");
			method cbseEn_SetLocalScale = C_BaseEntity.__N.CBseEn_SetLocalScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbseEn_SetLocalScale);
		}

		// Token: 0x0600020C RID: 524 RVA: 0x000243CC File Offset: 0x000225CC
		internal unsafe readonly void SetAbsVelocity(Vector3 origin)
		{
			this.NullCheck("SetAbsVelocity");
			method cbseEn_SetAbsVelocity = C_BaseEntity.__N.CBseEn_SetAbsVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbseEn_SetAbsVelocity);
		}

		// Token: 0x0600020D RID: 525 RVA: 0x000243FC File Offset: 0x000225FC
		internal readonly Vector3 GetAbsVelocity()
		{
			this.NullCheck("GetAbsVelocity");
			method cbseEn_GetAbsVelocity = C_BaseEntity.__N.CBseEn_GetAbsVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseEn_GetAbsVelocity);
		}

		// Token: 0x0600020E RID: 526 RVA: 0x00024428 File Offset: 0x00022628
		internal readonly void AddFlag(int flags)
		{
			this.NullCheck("AddFlag");
			method cbseEn_AddFlag = C_BaseEntity.__N.CBseEn_AddFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flags, cbseEn_AddFlag);
		}

		// Token: 0x0600020F RID: 527 RVA: 0x00024454 File Offset: 0x00022654
		internal readonly void RemoveFlag(int flagsToRemove)
		{
			this.NullCheck("RemoveFlag");
			method cbseEn_RemoveFlag = C_BaseEntity.__N.CBseEn_RemoveFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagsToRemove, cbseEn_RemoveFlag);
		}

		// Token: 0x06000210 RID: 528 RVA: 0x00024480 File Offset: 0x00022680
		internal readonly void ToggleFlag(int flagToToggle)
		{
			this.NullCheck("ToggleFlag");
			method cbseEn_ToggleFlag = C_BaseEntity.__N.CBseEn_ToggleFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagToToggle, cbseEn_ToggleFlag);
		}

		// Token: 0x06000211 RID: 529 RVA: 0x000244AC File Offset: 0x000226AC
		internal readonly void ClearFlags()
		{
			this.NullCheck("ClearFlags");
			method cbseEn_ClearFlags = C_BaseEntity.__N.CBseEn_ClearFlags;
			calli(System.Void(System.IntPtr), this.self, cbseEn_ClearFlags);
		}

		// Token: 0x06000212 RID: 530 RVA: 0x000244D8 File Offset: 0x000226D8
		internal readonly int GetFlags()
		{
			this.NullCheck("GetFlags");
			method cbseEn_GetFlags = C_BaseEntity.__N.CBseEn_GetFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_GetFlags);
		}

		// Token: 0x06000213 RID: 531 RVA: 0x00024504 File Offset: 0x00022704
		internal readonly void SetLifeState(LifeState state)
		{
			this.NullCheck("SetLifeState");
			method cbseEn_SetLifeState = C_BaseEntity.__N.CBseEn_SetLifeState;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)state, cbseEn_SetLifeState);
		}

		// Token: 0x06000214 RID: 532 RVA: 0x00024530 File Offset: 0x00022730
		internal readonly LifeState GetLifeState()
		{
			this.NullCheck("GetLifeState");
			method cbseEn_GetLifeState = C_BaseEntity.__N.CBseEn_GetLifeState;
			return calli(System.Int64(System.IntPtr), this.self, cbseEn_GetLifeState);
		}

		// Token: 0x06000215 RID: 533 RVA: 0x0002455C File Offset: 0x0002275C
		internal readonly int GetEffects()
		{
			this.NullCheck("GetEffects");
			method cbseEn_GetEffects = C_BaseEntity.__N.CBseEn_GetEffects;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_GetEffects);
		}

		// Token: 0x06000216 RID: 534 RVA: 0x00024588 File Offset: 0x00022788
		internal readonly void AddEffects(int nEffects)
		{
			this.NullCheck("AddEffects");
			method cbseEn_AddEffects = C_BaseEntity.__N.CBseEn_AddEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseEn_AddEffects);
		}

		// Token: 0x06000217 RID: 535 RVA: 0x000245B4 File Offset: 0x000227B4
		internal readonly void RemoveEffects(int nEffects)
		{
			this.NullCheck("RemoveEffects");
			method cbseEn_RemoveEffects = C_BaseEntity.__N.CBseEn_RemoveEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseEn_RemoveEffects);
		}

		// Token: 0x06000218 RID: 536 RVA: 0x000245E0 File Offset: 0x000227E0
		internal readonly void ClearEffects()
		{
			this.NullCheck("ClearEffects");
			method cbseEn_ClearEffects = C_BaseEntity.__N.CBseEn_ClearEffects;
			calli(System.Void(System.IntPtr), this.self, cbseEn_ClearEffects);
		}

		// Token: 0x06000219 RID: 537 RVA: 0x0002460C File Offset: 0x0002280C
		internal readonly void SetEffects(int nEffects)
		{
			this.NullCheck("SetEffects");
			method cbseEn_SetEffects = C_BaseEntity.__N.CBseEn_SetEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseEn_SetEffects);
		}

		// Token: 0x0600021A RID: 538 RVA: 0x00024638 File Offset: 0x00022838
		internal readonly bool IsEffectActive(int nEffectMask)
		{
			this.NullCheck("IsEffectActive");
			method cbseEn_IsEffectActive = C_BaseEntity.__N.CBseEn_IsEffectActive;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nEffectMask, cbseEn_IsEffectActive) > 0;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00024668 File Offset: 0x00022868
		internal readonly void CreateVPhysics()
		{
			this.NullCheck("CreateVPhysics");
			method cbseEn_CreateVPhysics = C_BaseEntity.__N.CBseEn_CreateVPhysics;
			calli(System.Void(System.IntPtr), this.self, cbseEn_CreateVPhysics);
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00024694 File Offset: 0x00022894
		internal unsafe readonly void ApplyAbsVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyAbsVelocityImpulse");
			method cbseEn_ApplyAbsVelocityImpulse = C_BaseEntity.__N.CBseEn_ApplyAbsVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbseEn_ApplyAbsVelocityImpulse);
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000246C4 File Offset: 0x000228C4
		internal unsafe readonly void ApplyLocalVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyLocalVelocityImpulse");
			method cbseEn_ApplyLocalVelocityImpulse = C_BaseEntity.__N.CBseEn_ApplyLocalVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbseEn_ApplyLocalVelocityImpulse);
		}

		// Token: 0x0600021E RID: 542 RVA: 0x000246F4 File Offset: 0x000228F4
		internal unsafe readonly void ApplyLocalAngularVelocityImpulse(Vector3 angImpulse)
		{
			this.NullCheck("ApplyLocalAngularVelocityImpulse");
			method cbseEn_ApplyLocalAngularVelocityImpulse = C_BaseEntity.__N.CBseEn_ApplyLocalAngularVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &angImpulse, cbseEn_ApplyLocalAngularVelocityImpulse);
		}

		// Token: 0x0600021F RID: 543 RVA: 0x00024724 File Offset: 0x00022924
		internal readonly void SetMoveType(MoveType val, MoveCollide moveCollide)
		{
			this.NullCheck("SetMoveType");
			method cbseEn_SetMoveType = C_BaseEntity.__N.CBseEn_SetMoveType;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (ulong)val, (ulong)moveCollide, cbseEn_SetMoveType);
		}

		// Token: 0x06000220 RID: 544 RVA: 0x00024754 File Offset: 0x00022954
		internal readonly MoveType GetMoveType()
		{
			this.NullCheck("GetMoveType");
			method cbseEn_GetMoveType = C_BaseEntity.__N.CBseEn_GetMoveType;
			return calli(System.Int64(System.IntPtr), this.self, cbseEn_GetMoveType);
		}

		// Token: 0x06000221 RID: 545 RVA: 0x00024780 File Offset: 0x00022980
		internal readonly void PhysicsEnableMotion(bool bEnable)
		{
			this.NullCheck("PhysicsEnableMotion");
			method cbseEn_PhysicsEnableMotion = C_BaseEntity.__N.CBseEn_PhysicsEnableMotion;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnable ? 1 : 0, cbseEn_PhysicsEnableMotion);
		}

		// Token: 0x06000222 RID: 546 RVA: 0x000247B4 File Offset: 0x000229B4
		internal readonly void FollowEntity(IntPtr pBaseEntity, bool bBoneMerge)
		{
			this.NullCheck("FollowEntity");
			method cbseEn_FollowEntity = C_BaseEntity.__N.CBseEn_FollowEntity;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pBaseEntity, bBoneMerge ? 1 : 0, cbseEn_FollowEntity);
		}

		// Token: 0x06000223 RID: 547 RVA: 0x000247E8 File Offset: 0x000229E8
		internal readonly void StopFollowingEntity()
		{
			this.NullCheck("StopFollowingEntity");
			method cbseEn_StopFollowingEntity = C_BaseEntity.__N.CBseEn_StopFollowingEntity;
			calli(System.Void(System.IntPtr), this.self, cbseEn_StopFollowingEntity);
		}

		// Token: 0x06000224 RID: 548 RVA: 0x00024814 File Offset: 0x00022A14
		internal readonly bool IsFollowingEntity()
		{
			this.NullCheck("IsFollowingEntity");
			method cbseEn_IsFollowingEntity = C_BaseEntity.__N.CBseEn_IsFollowingEntity;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_IsFollowingEntity) > 0;
		}

		// Token: 0x06000225 RID: 549 RVA: 0x00024844 File Offset: 0x00022A44
		internal readonly C_BaseEntity GetFollowedEntity()
		{
			this.NullCheck("GetFollowedEntity");
			method cbseEn_GetFollowedEntity = C_BaseEntity.__N.CBseEn_GetFollowedEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetFollowedEntity);
		}

		// Token: 0x06000226 RID: 550 RVA: 0x00024874 File Offset: 0x00022A74
		internal readonly PhysicsGroup VPhysicsGetAggregate()
		{
			this.NullCheck("VPhysicsGetAggregate");
			method cbseEn_VPhysicsGetAggregate = C_BaseEntity.__N.CBseEn_VPhysicsGetAggregate;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr), this.self, cbseEn_VPhysicsGetAggregate));
		}

		// Token: 0x06000227 RID: 551 RVA: 0x000248A4 File Offset: 0x00022AA4
		internal readonly Vector3 GetBaseVelocity()
		{
			this.NullCheck("GetBaseVelocity");
			method cbseEn_GetBaseVelocity = C_BaseEntity.__N.CBseEn_GetBaseVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseEn_GetBaseVelocity);
		}

		// Token: 0x06000228 RID: 552 RVA: 0x000248D0 File Offset: 0x00022AD0
		internal unsafe readonly void SetBaseVelocity(Vector3 v)
		{
			this.NullCheck("SetBaseVelocity");
			method cbseEn_SetBaseVelocity = C_BaseEntity.__N.CBseEn_SetBaseVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbseEn_SetBaseVelocity);
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00024900 File Offset: 0x00022B00
		internal readonly void SetGroundEntity(C_BaseEntity ground)
		{
			this.NullCheck("SetGroundEntity");
			method cbseEn_SetGroundEntity = C_BaseEntity.__N.CBseEn_SetGroundEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ground, cbseEn_SetGroundEntity);
		}

		// Token: 0x0600022A RID: 554 RVA: 0x00024930 File Offset: 0x00022B30
		internal readonly C_BaseEntity GetGroundEntity()
		{
			this.NullCheck("GetGroundEntity");
			method cbseEn_GetGroundEntity = C_BaseEntity.__N.CBseEn_GetGroundEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetGroundEntity);
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00024960 File Offset: 0x00022B60
		internal readonly string GetModelNameString()
		{
			this.NullCheck("GetModelNameString");
			method cbseEn_GetModelNameString = C_BaseEntity.__N.CBseEn_GetModelNameString;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetModelNameString));
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00024990 File Offset: 0x00022B90
		internal unsafe readonly void SetParent(C_BaseEntity parent, string nBoneOrAttachName, Transform pOffsetTransform)
		{
			this.NullCheck("SetParent");
			method cbseEn_SetParent = C_BaseEntity.__N.CBseEn_SetParent;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32,Transform*), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), &pOffsetTransform, cbseEn_SetParent);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x000249CC File Offset: 0x00022BCC
		internal readonly void SetParent(C_BaseEntity parent, string nBoneOrAttachName)
		{
			this.NullCheck("SetParent");
			method cbseEn_f = C_BaseEntity.__N.CBseEn_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), cbseEn_f);
		}

		// Token: 0x0600022E RID: 558 RVA: 0x00024A04 File Offset: 0x00022C04
		internal readonly C_BaseEntity GetParent()
		{
			this.NullCheck("GetParent");
			method cbseEn_GetParent = C_BaseEntity.__N.CBseEn_GetParent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetParent);
		}

		// Token: 0x0600022F RID: 559 RVA: 0x00024A34 File Offset: 0x00022C34
		internal readonly void ResetLatched()
		{
			this.NullCheck("ResetLatched");
			method cbseEn_ResetLatched = C_BaseEntity.__N.CBseEn_ResetLatched;
			calli(System.Void(System.IntPtr), this.self, cbseEn_ResetLatched);
		}

		// Token: 0x06000230 RID: 560 RVA: 0x00024A60 File Offset: 0x00022C60
		internal readonly void SetActiveChild(C_BaseEntity child)
		{
			this.NullCheck("SetActiveChild");
			method cbseEn_SetActiveChild = C_BaseEntity.__N.CBseEn_SetActiveChild;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbseEn_SetActiveChild);
		}

		// Token: 0x06000231 RID: 561 RVA: 0x00024A90 File Offset: 0x00022C90
		internal readonly C_BaseEntity GetActiveChild()
		{
			this.NullCheck("GetActiveChild");
			method cbseEn_GetActiveChild = C_BaseEntity.__N.CBseEn_GetActiveChild;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetActiveChild);
		}

		// Token: 0x06000232 RID: 562 RVA: 0x00024AC0 File Offset: 0x00022CC0
		internal readonly void SetOwnerEntity(C_BaseEntity child)
		{
			this.NullCheck("SetOwnerEntity");
			method cbseEn_SetOwnerEntity = C_BaseEntity.__N.CBseEn_SetOwnerEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbseEn_SetOwnerEntity);
		}

		// Token: 0x06000233 RID: 563 RVA: 0x00024AF0 File Offset: 0x00022CF0
		internal readonly C_BaseEntity GetOwnerEntity()
		{
			this.NullCheck("GetOwnerEntity");
			method cbseEn_GetOwnerEntity = C_BaseEntity.__N.CBseEn_GetOwnerEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetOwnerEntity);
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00024B20 File Offset: 0x00022D20
		internal readonly void EnableSceneObjectOverride(bool bEnableOverride)
		{
			this.NullCheck("EnableSceneObjectOverride");
			method cbseEn_EnableSceneObjectOverride = C_BaseEntity.__N.CBseEn_EnableSceneObjectOverride;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnableOverride ? 1 : 0, cbseEn_EnableSceneObjectOverride);
		}

		// Token: 0x06000235 RID: 565 RVA: 0x00024B54 File Offset: 0x00022D54
		internal readonly void SetSimulationTime(float time)
		{
			this.NullCheck("SetSimulationTime");
			method cbseEn_SetSimulationTime = C_BaseEntity.__N.CBseEn_SetSimulationTime;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbseEn_SetSimulationTime);
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00024B80 File Offset: 0x00022D80
		internal readonly bool HasSpawnFlags(int nFlags)
		{
			this.NullCheck("HasSpawnFlags");
			method cbseEn_HasSpawnFlags = C_BaseEntity.__N.CBseEn_HasSpawnFlags;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nFlags, cbseEn_HasSpawnFlags) > 0;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00024BB0 File Offset: 0x00022DB0
		internal readonly int GetSpawnFlags()
		{
			this.NullCheck("GetSpawnFlags");
			method cbseEn_GetSpawnFlags = C_BaseEntity.__N.CBseEn_GetSpawnFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_GetSpawnFlags);
		}

		// Token: 0x06000238 RID: 568 RVA: 0x00024BDC File Offset: 0x00022DDC
		internal readonly void AddSpawnFlags(int nFlags)
		{
			this.NullCheck("AddSpawnFlags");
			method cbseEn_AddSpawnFlags = C_BaseEntity.__N.CBseEn_AddSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbseEn_AddSpawnFlags);
		}

		// Token: 0x06000239 RID: 569 RVA: 0x00024C08 File Offset: 0x00022E08
		internal readonly void RemoveSpawnFlags(int nFlags)
		{
			this.NullCheck("RemoveSpawnFlags");
			method cbseEn_RemoveSpawnFlags = C_BaseEntity.__N.CBseEn_RemoveSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbseEn_RemoveSpawnFlags);
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00024C34 File Offset: 0x00022E34
		internal readonly void ClearSpawnFlags()
		{
			this.NullCheck("ClearSpawnFlags");
			method cbseEn_ClearSpawnFlags = C_BaseEntity.__N.CBseEn_ClearSpawnFlags;
			calli(System.Void(System.IntPtr), this.self, cbseEn_ClearSpawnFlags);
		}

		// Token: 0x0600023B RID: 571 RVA: 0x00024C60 File Offset: 0x00022E60
		internal readonly CLightComponent GetLightComponent()
		{
			this.NullCheck("GetLightComponent");
			method cbseEn_GetLightComponent = C_BaseEntity.__N.CBseEn_GetLightComponent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetLightComponent);
		}

		// Token: 0x0600023C RID: 572 RVA: 0x00024C90 File Offset: 0x00022E90
		internal unsafe readonly void SetLocalVelocity(Vector3 vecVelocity)
		{
			this.NullCheck("SetLocalVelocity");
			method cbseEn_SetLocalVelocity = C_BaseEntity.__N.CBseEn_SetLocalVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecVelocity, cbseEn_SetLocalVelocity);
		}

		// Token: 0x0600023D RID: 573 RVA: 0x00024CC0 File Offset: 0x00022EC0
		internal readonly Vector3 GetLocalVelocity()
		{
			this.NullCheck("GetLocalVelocity");
			method cbseEn_GetLocalVelocity = C_BaseEntity.__N.CBseEn_GetLocalVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseEn_GetLocalVelocity);
		}

		// Token: 0x0600023E RID: 574 RVA: 0x00024CEC File Offset: 0x00022EEC
		internal unsafe readonly void SetLocalAngularVelocity(Angles vecAngVelocity)
		{
			this.NullCheck("SetLocalAngularVelocity");
			method cbseEn_SetLocalAngularVelocity = C_BaseEntity.__N.CBseEn_SetLocalAngularVelocity;
			calli(System.Void(System.IntPtr,Angles*), this.self, &vecAngVelocity, cbseEn_SetLocalAngularVelocity);
		}

		// Token: 0x0600023F RID: 575 RVA: 0x00024D1C File Offset: 0x00022F1C
		internal readonly Angles GetLocalAngularVelocity()
		{
			this.NullCheck("GetLocalAngularVelocity");
			method cbseEn_GetLocalAngularVelocity = C_BaseEntity.__N.CBseEn_GetLocalAngularVelocity;
			return calli(Angles(System.IntPtr), this.self, cbseEn_GetLocalAngularVelocity);
		}

		// Token: 0x06000240 RID: 576 RVA: 0x00024D48 File Offset: 0x00022F48
		internal readonly void SetDebugBits(ulong nBitMask)
		{
			this.NullCheck("SetDebugBits");
			method cbseEn_SetDebugBits = C_BaseEntity.__N.CBseEn_SetDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseEn_SetDebugBits);
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00024D74 File Offset: 0x00022F74
		internal readonly bool HasDebugBitsSet(ulong nBitMask)
		{
			this.NullCheck("HasDebugBitsSet");
			method cbseEn_HasDebugBitsSet = C_BaseEntity.__N.CBseEn_HasDebugBitsSet;
			return calli(System.Int32(System.IntPtr,System.UInt64), this.self, nBitMask, cbseEn_HasDebugBitsSet) > 0;
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00024DA4 File Offset: 0x00022FA4
		internal readonly void ClearDebugBits(ulong nBitMask)
		{
			this.NullCheck("ClearDebugBits");
			method cbseEn_ClearDebugBits = C_BaseEntity.__N.CBseEn_ClearDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseEn_ClearDebugBits);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x00024DD0 File Offset: 0x00022FD0
		internal readonly void ToggleDebugBits(ulong nBitMask)
		{
			this.NullCheck("ToggleDebugBits");
			method cbseEn_ToggleDebugBits = C_BaseEntity.__N.CBseEn_ToggleDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseEn_ToggleDebugBits);
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00024DFC File Offset: 0x00022FFC
		internal readonly ulong GetDebugBits()
		{
			this.NullCheck("GetDebugBits");
			method cbseEn_GetDebugBits = C_BaseEntity.__N.CBseEn_GetDebugBits;
			return calli(System.UInt64(System.IntPtr), this.self, cbseEn_GetDebugBits);
		}

		// Token: 0x06000245 RID: 581 RVA: 0x00024E28 File Offset: 0x00023028
		internal readonly void MarkRenderHandleDirty()
		{
			this.NullCheck("MarkRenderHandleDirty");
			method cbseEn_MarkRenderHandleDirty = C_BaseEntity.__N.CBseEn_MarkRenderHandleDirty;
			calli(System.Void(System.IntPtr), this.self, cbseEn_MarkRenderHandleDirty);
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00024E54 File Offset: 0x00023054
		internal readonly void SetWaterEntity(C_BaseEntity ent)
		{
			this.NullCheck("SetWaterEntity");
			method cbseEn_SetWaterEntity = C_BaseEntity.__N.CBseEn_SetWaterEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ent, cbseEn_SetWaterEntity);
		}

		// Token: 0x06000247 RID: 583 RVA: 0x00024E84 File Offset: 0x00023084
		internal readonly Entity GetWaterEntity()
		{
			this.NullCheck("GetWaterEntity");
			method cbseEn_GetWaterEntity = C_BaseEntity.__N.CBseEn_GetWaterEntity;
			return InteropSystem.Get<Entity>(calli(System.UInt32(System.IntPtr), this.self, cbseEn_GetWaterEntity));
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00024EB4 File Offset: 0x000230B4
		internal readonly void WorldSpaceAABB(out Vector3 mins, out Vector3 maxs)
		{
			this.NullCheck("WorldSpaceAABB");
			method cbseEn_WorldSpaceAABB = C_BaseEntity.__N.CBseEn_WorldSpaceAABB;
			calli(System.Void(System.IntPtr,Vector3& modreq(System.Runtime.InteropServices.OutAttribute),Vector3& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, ref mins, ref maxs, cbseEn_WorldSpaceAABB);
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00024EE0 File Offset: 0x000230E0
		internal readonly void RemoveAllDecals()
		{
			this.NullCheck("RemoveAllDecals");
			method cbseEn_RemoveAllDecals = C_BaseEntity.__N.CBseEn_RemoveAllDecals;
			calli(System.Void(System.IntPtr), this.self, cbseEn_RemoveAllDecals);
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00024F0C File Offset: 0x0002310C
		internal readonly bool GetPredictable()
		{
			this.NullCheck("GetPredictable");
			method cbseEn_GetPredictable = C_BaseEntity.__N.CBseEn_GetPredictable;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_GetPredictable) > 0;
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00024F3C File Offset: 0x0002313C
		internal readonly string SB_GetEntityName()
		{
			this.NullCheck("SB_GetEntityName");
			method cbseEn_SB_GetEntityName = C_BaseEntity.__N.CBseEn_SB_GetEntityName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseEn_SB_GetEntityName));
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00024F6C File Offset: 0x0002316C
		internal readonly void SB_SetEntityName(string name)
		{
			this.NullCheck("SB_SetEntityName");
			method cbseEn_SB_SetEntityName = C_BaseEntity.__N.CBseEn_SB_SetEntityName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseEn_SB_SetEntityName);
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00024F9C File Offset: 0x0002319C
		internal readonly IntPtr GetData(int index, bool local, out int size)
		{
			this.NullCheck("GetData");
			method cbseEn_GetData = C_BaseEntity.__N.CBseEn_GetData;
			return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32,System.Int32& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, index, local ? 1 : 0, ref size, cbseEn_GetData);
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00024FD0 File Offset: 0x000231D0
		internal readonly bool IsServerOnly()
		{
			this.NullCheck("IsServerOnly");
			method cbseEn_IsServerOnly = C_BaseEntity.__N.CBseEn_IsServerOnly;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_IsServerOnly) > 0;
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00025000 File Offset: 0x00023200
		internal readonly bool IsClientOnly()
		{
			this.NullCheck("IsClientOnly");
			method cbseEn_IsClientOnly = C_BaseEntity.__N.CBseEn_IsClientOnly;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_IsClientOnly) > 0;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00025030 File Offset: 0x00023230
		internal readonly bool IsClientServerNetworked()
		{
			this.NullCheck("IsClientServerNetworked");
			method cbseEn_IsClientServerNetworked = C_BaseEntity.__N.CBseEn_IsClientServerNetworked;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_IsClientServerNetworked) > 0;
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000251 RID: 593 RVA: 0x0002505D File Offset: 0x0002325D
		// (set) Token: 0x06000252 RID: 594 RVA: 0x0002507F File Offset: 0x0002327F
		internal Entity EntityObject
		{
			get
			{
				this.NullCheck("EntityObject");
				return InteropSystem.Get<Entity>(C_BaseEntity.__N.Get__CBseEn_EntityObject(this.self));
			}
			set
			{
				this.NullCheck("EntityObject");
				C_BaseEntity.__N.Set__CBseEn_EntityObject(this.self, (value == null) ? 0U : InteropSystem.GetAddress<Entity>(value, true));
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000253 RID: 595 RVA: 0x000250A9 File Offset: 0x000232A9
		// (set) Token: 0x06000254 RID: 596 RVA: 0x000250C6 File Offset: 0x000232C6
		internal Vector3 m_EyePosOffset
		{
			get
			{
				this.NullCheck("m_EyePosOffset");
				return C_BaseEntity.__N.Get__CBseEn_m_EyePosOffset(this.self);
			}
			set
			{
				this.NullCheck("m_EyePosOffset");
				C_BaseEntity.__N.Set__CBseEn_m_EyePosOffset(this.self, value);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000255 RID: 597 RVA: 0x000250E4 File Offset: 0x000232E4
		// (set) Token: 0x06000256 RID: 598 RVA: 0x00025101 File Offset: 0x00023301
		internal Rotation m_EyeRotOffset
		{
			get
			{
				this.NullCheck("m_EyeRotOffset");
				return C_BaseEntity.__N.Get__CBseEn_m_EyeRotOffset(this.self);
			}
			set
			{
				this.NullCheck("m_EyeRotOffset");
				C_BaseEntity.__N.Set__CBseEn_m_EyeRotOffset(this.self, value);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000257 RID: 599 RVA: 0x0002511F File Offset: 0x0002331F
		// (set) Token: 0x06000258 RID: 600 RVA: 0x0002513C File Offset: 0x0002333C
		internal byte m_WaterLevel
		{
			get
			{
				this.NullCheck("m_WaterLevel");
				return C_BaseEntity.__N.Get__CBseEn_m_WaterLevel(this.self);
			}
			set
			{
				this.NullCheck("m_WaterLevel");
				C_BaseEntity.__N.Set__CBseEn_m_WaterLevel(this.self, value);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x06000259 RID: 601 RVA: 0x0002515A File Offset: 0x0002335A
		// (set) Token: 0x0600025A RID: 602 RVA: 0x00025177 File Offset: 0x00023377
		internal float m_fHealth
		{
			get
			{
				this.NullCheck("m_fHealth");
				return C_BaseEntity.__N.Get__CBseEn_m_fHealth(this.self);
			}
			set
			{
				this.NullCheck("m_fHealth");
				C_BaseEntity.__N.Set__CBseEn_m_fHealth(this.self, value);
			}
		}

		// Token: 0x0400009D RID: 157
		internal IntPtr self;

		// Token: 0x020001A0 RID: 416
		internal static class __N
		{
			// Token: 0x0400085F RID: 2143
			internal static method From_CGameEntity_To_C_BaseEntity;

			// Token: 0x04000860 RID: 2144
			internal static method To_CGameEntity_From_C_BaseEntity;

			// Token: 0x04000861 RID: 2145
			internal static method From_CEntityInstance_To_C_BaseEntity;

			// Token: 0x04000862 RID: 2146
			internal static method To_CEntityInstance_From_C_BaseEntity;

			// Token: 0x04000863 RID: 2147
			internal static method From_IHandleEntity_To_C_BaseEntity;

			// Token: 0x04000864 RID: 2148
			internal static method To_IHandleEntity_From_C_BaseEntity;

			// Token: 0x04000865 RID: 2149
			internal static method CBseEn_InitializeEntityObject;

			// Token: 0x04000866 RID: 2150
			internal static method CBseEn_GetDataTable;

			// Token: 0x04000867 RID: 2151
			internal static method CBseEn_GetEntityHandle;

			// Token: 0x04000868 RID: 2152
			internal static method CBseEn_GetClassname;

			// Token: 0x04000869 RID: 2153
			internal static method CBseEn_GetDebugName;

			// Token: 0x0400086A RID: 2154
			internal static method CBseEn_entindex;

			// Token: 0x0400086B RID: 2155
			internal static method CBseEn_SetLocalOrigin;

			// Token: 0x0400086C RID: 2156
			internal static method CBseEn_GetLocalOrigin;

			// Token: 0x0400086D RID: 2157
			internal static method CBseEn_GetLocalQuat;

			// Token: 0x0400086E RID: 2158
			internal static method CBseEn_SetLocalQuat;

			// Token: 0x0400086F RID: 2159
			internal static method CBseEn_GetAbsQuat;

			// Token: 0x04000870 RID: 2160
			internal static method CBseEn_SetAbsQuat;

			// Token: 0x04000871 RID: 2161
			internal static method CBseEn_SetAbsOrigin;

			// Token: 0x04000872 RID: 2162
			internal static method CBseEn_GetAbsOrigin;

			// Token: 0x04000873 RID: 2163
			internal static method CBseEn_GetAbsScale;

			// Token: 0x04000874 RID: 2164
			internal static method CBseEn_SetAbsScale;

			// Token: 0x04000875 RID: 2165
			internal static method CBseEn_GetLocalScale;

			// Token: 0x04000876 RID: 2166
			internal static method CBseEn_SetLocalScale;

			// Token: 0x04000877 RID: 2167
			internal static method CBseEn_SetAbsVelocity;

			// Token: 0x04000878 RID: 2168
			internal static method CBseEn_GetAbsVelocity;

			// Token: 0x04000879 RID: 2169
			internal static method CBseEn_AddFlag;

			// Token: 0x0400087A RID: 2170
			internal static method CBseEn_RemoveFlag;

			// Token: 0x0400087B RID: 2171
			internal static method CBseEn_ToggleFlag;

			// Token: 0x0400087C RID: 2172
			internal static method CBseEn_ClearFlags;

			// Token: 0x0400087D RID: 2173
			internal static method CBseEn_GetFlags;

			// Token: 0x0400087E RID: 2174
			internal static method CBseEn_SetLifeState;

			// Token: 0x0400087F RID: 2175
			internal static method CBseEn_GetLifeState;

			// Token: 0x04000880 RID: 2176
			internal static method CBseEn_GetEffects;

			// Token: 0x04000881 RID: 2177
			internal static method CBseEn_AddEffects;

			// Token: 0x04000882 RID: 2178
			internal static method CBseEn_RemoveEffects;

			// Token: 0x04000883 RID: 2179
			internal static method CBseEn_ClearEffects;

			// Token: 0x04000884 RID: 2180
			internal static method CBseEn_SetEffects;

			// Token: 0x04000885 RID: 2181
			internal static method CBseEn_IsEffectActive;

			// Token: 0x04000886 RID: 2182
			internal static method CBseEn_CreateVPhysics;

			// Token: 0x04000887 RID: 2183
			internal static method CBseEn_ApplyAbsVelocityImpulse;

			// Token: 0x04000888 RID: 2184
			internal static method CBseEn_ApplyLocalVelocityImpulse;

			// Token: 0x04000889 RID: 2185
			internal static method CBseEn_ApplyLocalAngularVelocityImpulse;

			// Token: 0x0400088A RID: 2186
			internal static method CBseEn_SetMoveType;

			// Token: 0x0400088B RID: 2187
			internal static method CBseEn_GetMoveType;

			// Token: 0x0400088C RID: 2188
			internal static method CBseEn_PhysicsEnableMotion;

			// Token: 0x0400088D RID: 2189
			internal static method CBseEn_FollowEntity;

			// Token: 0x0400088E RID: 2190
			internal static method CBseEn_StopFollowingEntity;

			// Token: 0x0400088F RID: 2191
			internal static method CBseEn_IsFollowingEntity;

			// Token: 0x04000890 RID: 2192
			internal static method CBseEn_GetFollowedEntity;

			// Token: 0x04000891 RID: 2193
			internal static method CBseEn_VPhysicsGetAggregate;

			// Token: 0x04000892 RID: 2194
			internal static method CBseEn_GetBaseVelocity;

			// Token: 0x04000893 RID: 2195
			internal static method CBseEn_SetBaseVelocity;

			// Token: 0x04000894 RID: 2196
			internal static method CBseEn_SetGroundEntity;

			// Token: 0x04000895 RID: 2197
			internal static method CBseEn_GetGroundEntity;

			// Token: 0x04000896 RID: 2198
			internal static method CBseEn_GetModelNameString;

			// Token: 0x04000897 RID: 2199
			internal static method CBseEn_SetParent;

			// Token: 0x04000898 RID: 2200
			internal static method CBseEn_f2;

			// Token: 0x04000899 RID: 2201
			internal static method CBseEn_GetParent;

			// Token: 0x0400089A RID: 2202
			internal static method CBseEn_ResetLatched;

			// Token: 0x0400089B RID: 2203
			internal static method CBseEn_SetActiveChild;

			// Token: 0x0400089C RID: 2204
			internal static method CBseEn_GetActiveChild;

			// Token: 0x0400089D RID: 2205
			internal static method CBseEn_SetOwnerEntity;

			// Token: 0x0400089E RID: 2206
			internal static method CBseEn_GetOwnerEntity;

			// Token: 0x0400089F RID: 2207
			internal static method CBseEn_EnableSceneObjectOverride;

			// Token: 0x040008A0 RID: 2208
			internal static method CBseEn_SetSimulationTime;

			// Token: 0x040008A1 RID: 2209
			internal static method CBseEn_HasSpawnFlags;

			// Token: 0x040008A2 RID: 2210
			internal static method CBseEn_GetSpawnFlags;

			// Token: 0x040008A3 RID: 2211
			internal static method CBseEn_AddSpawnFlags;

			// Token: 0x040008A4 RID: 2212
			internal static method CBseEn_RemoveSpawnFlags;

			// Token: 0x040008A5 RID: 2213
			internal static method CBseEn_ClearSpawnFlags;

			// Token: 0x040008A6 RID: 2214
			internal static method CBseEn_GetLightComponent;

			// Token: 0x040008A7 RID: 2215
			internal static method CBseEn_SetLocalVelocity;

			// Token: 0x040008A8 RID: 2216
			internal static method CBseEn_GetLocalVelocity;

			// Token: 0x040008A9 RID: 2217
			internal static method CBseEn_SetLocalAngularVelocity;

			// Token: 0x040008AA RID: 2218
			internal static method CBseEn_GetLocalAngularVelocity;

			// Token: 0x040008AB RID: 2219
			internal static method CBseEn_SetDebugBits;

			// Token: 0x040008AC RID: 2220
			internal static method CBseEn_HasDebugBitsSet;

			// Token: 0x040008AD RID: 2221
			internal static method CBseEn_ClearDebugBits;

			// Token: 0x040008AE RID: 2222
			internal static method CBseEn_ToggleDebugBits;

			// Token: 0x040008AF RID: 2223
			internal static method CBseEn_GetDebugBits;

			// Token: 0x040008B0 RID: 2224
			internal static method CBseEn_MarkRenderHandleDirty;

			// Token: 0x040008B1 RID: 2225
			internal static method CBseEn_SetWaterEntity;

			// Token: 0x040008B2 RID: 2226
			internal static method CBseEn_GetWaterEntity;

			// Token: 0x040008B3 RID: 2227
			internal static method CBseEn_WorldSpaceAABB;

			// Token: 0x040008B4 RID: 2228
			internal static method CBseEn_RemoveAllDecals;

			// Token: 0x040008B5 RID: 2229
			internal static method CBseEn_GetPredictable;

			// Token: 0x040008B6 RID: 2230
			internal static method CBseEn_SB_GetEntityName;

			// Token: 0x040008B7 RID: 2231
			internal static method CBseEn_SB_SetEntityName;

			// Token: 0x040008B8 RID: 2232
			internal static method CBseEn_GetData;

			// Token: 0x040008B9 RID: 2233
			internal static method CBseEn_IsServerOnly;

			// Token: 0x040008BA RID: 2234
			internal static method CBseEn_IsClientOnly;

			// Token: 0x040008BB RID: 2235
			internal static method CBseEn_IsClientServerNetworked;

			// Token: 0x040008BC RID: 2236
			internal static C_BaseEntity.__N._Get__CBseEn_EntityObject Get__CBseEn_EntityObject;

			// Token: 0x040008BD RID: 2237
			internal static C_BaseEntity.__N._Set__CBseEn_EntityObject Set__CBseEn_EntityObject;

			// Token: 0x040008BE RID: 2238
			internal static C_BaseEntity.__N._Get__CBseEn_m_EyePosOffset Get__CBseEn_m_EyePosOffset;

			// Token: 0x040008BF RID: 2239
			internal static C_BaseEntity.__N._Set__CBseEn_m_EyePosOffset Set__CBseEn_m_EyePosOffset;

			// Token: 0x040008C0 RID: 2240
			internal static C_BaseEntity.__N._Get__CBseEn_m_EyeRotOffset Get__CBseEn_m_EyeRotOffset;

			// Token: 0x040008C1 RID: 2241
			internal static C_BaseEntity.__N._Set__CBseEn_m_EyeRotOffset Set__CBseEn_m_EyeRotOffset;

			// Token: 0x040008C2 RID: 2242
			internal static C_BaseEntity.__N._Get__CBseEn_m_WaterLevel Get__CBseEn_m_WaterLevel;

			// Token: 0x040008C3 RID: 2243
			internal static C_BaseEntity.__N._Set__CBseEn_m_WaterLevel Set__CBseEn_m_WaterLevel;

			// Token: 0x040008C4 RID: 2244
			internal static C_BaseEntity.__N._Get__CBseEn_m_fHealth Get__CBseEn_m_fHealth;

			// Token: 0x040008C5 RID: 2245
			internal static C_BaseEntity.__N._Set__CBseEn_m_fHealth Set__CBseEn_m_fHealth;

			// Token: 0x020002C1 RID: 705
			// (Invoke) Token: 0x06002000 RID: 8192
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate uint _Get__CBseEn_EntityObject(IntPtr self);

			// Token: 0x020002C2 RID: 706
			// (Invoke) Token: 0x06002004 RID: 8196
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_EntityObject(IntPtr self, uint val);

			// Token: 0x020002C3 RID: 707
			// (Invoke) Token: 0x06002008 RID: 8200
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Vector3 _Get__CBseEn_m_EyePosOffset(IntPtr self);

			// Token: 0x020002C4 RID: 708
			// (Invoke) Token: 0x0600200C RID: 8204
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_EyePosOffset(IntPtr self, Vector3 val);

			// Token: 0x020002C5 RID: 709
			// (Invoke) Token: 0x06002010 RID: 8208
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Rotation _Get__CBseEn_m_EyeRotOffset(IntPtr self);

			// Token: 0x020002C6 RID: 710
			// (Invoke) Token: 0x06002014 RID: 8212
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_EyeRotOffset(IntPtr self, Rotation val);

			// Token: 0x020002C7 RID: 711
			// (Invoke) Token: 0x06002018 RID: 8216
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate byte _Get__CBseEn_m_WaterLevel(IntPtr self);

			// Token: 0x020002C8 RID: 712
			// (Invoke) Token: 0x0600201C RID: 8220
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_WaterLevel(IntPtr self, byte val);

			// Token: 0x020002C9 RID: 713
			// (Invoke) Token: 0x06002020 RID: 8224
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate float _Get__CBseEn_m_fHealth(IntPtr self);

			// Token: 0x020002CA RID: 714
			// (Invoke) Token: 0x06002024 RID: 8228
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_fHealth(IntPtr self, float val);
		}
	}
}
