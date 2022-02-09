using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000026 RID: 38
	internal struct CBaseEntity
	{
		// Token: 0x0600040E RID: 1038 RVA: 0x00029473 File Offset: 0x00027673
		public static implicit operator IntPtr(CBaseEntity value)
		{
			return value.self;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0002947C File Offset: 0x0002767C
		public static implicit operator CBaseEntity(IntPtr value)
		{
			return new CBaseEntity
			{
				self = value
			};
		}

		// Token: 0x06000410 RID: 1040 RVA: 0x0002949A File Offset: 0x0002769A
		public static bool operator ==(CBaseEntity c1, CBaseEntity c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000411 RID: 1041 RVA: 0x000294AD File Offset: 0x000276AD
		public static bool operator !=(CBaseEntity c1, CBaseEntity c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000412 RID: 1042 RVA: 0x000294C0 File Offset: 0x000276C0
		public override bool Equals(object obj)
		{
			if (obj is CBaseEntity)
			{
				CBaseEntity c = (CBaseEntity)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000413 RID: 1043 RVA: 0x000294EA File Offset: 0x000276EA
		internal CBaseEntity(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000414 RID: 1044 RVA: 0x000294F4 File Offset: 0x000276F4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CBaseEntity ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x00029530 File Offset: 0x00027730
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000416 RID: 1046 RVA: 0x00029542 File Offset: 0x00027742
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x0002954D File Offset: 0x0002774D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000418 RID: 1048 RVA: 0x00029560 File Offset: 0x00027760
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CBaseEntity was null when calling " + n);
			}
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x0002957B File Offset: 0x0002777B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x00029588 File Offset: 0x00027788
		public static implicit operator CGameEntity(CBaseEntity value)
		{
			method to_CGameEntity_From_CBaseEntity = CBaseEntity.__N.To_CGameEntity_From_CBaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_CGameEntity_From_CBaseEntity);
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x000295AC File Offset: 0x000277AC
		public static explicit operator CBaseEntity(CGameEntity value)
		{
			method from_CGameEntity_To_CBaseEntity = CBaseEntity.__N.From_CGameEntity_To_CBaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_CGameEntity_To_CBaseEntity);
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x000295D0 File Offset: 0x000277D0
		public static implicit operator CEntityInstance(CBaseEntity value)
		{
			method to_CEntityInstance_From_CBaseEntity = CBaseEntity.__N.To_CEntityInstance_From_CBaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_CEntityInstance_From_CBaseEntity);
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x000295F4 File Offset: 0x000277F4
		public static explicit operator CBaseEntity(CEntityInstance value)
		{
			method from_CEntityInstance_To_CBaseEntity = CBaseEntity.__N.From_CEntityInstance_To_CBaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_CEntityInstance_To_CBaseEntity);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00029618 File Offset: 0x00027818
		public static implicit operator IHandleEntity(CBaseEntity value)
		{
			method to_IHandleEntity_From_CBaseEntity = CBaseEntity.__N.To_IHandleEntity_From_CBaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_IHandleEntity_From_CBaseEntity);
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x0002963C File Offset: 0x0002783C
		public static explicit operator CBaseEntity(IHandleEntity value)
		{
			method from_IHandleEntity_To_CBaseEntity = CBaseEntity.__N.From_IHandleEntity_To_CBaseEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_IHandleEntity_To_CBaseEntity);
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00029660 File Offset: 0x00027860
		internal readonly DataTable GetDataTable()
		{
			this.NullCheck("GetDataTable");
			method cbseEn_GetDataTable = CBaseEntity.__N.CBseEn_GetDataTable;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetDataTable);
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00029690 File Offset: 0x00027890
		internal readonly int GetEntityHandle()
		{
			this.NullCheck("GetEntityHandle");
			method cbseEn_GetEntityHandle = CBaseEntity.__N.CBseEn_GetEntityHandle;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_GetEntityHandle);
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000296BC File Offset: 0x000278BC
		internal unsafe readonly void SetLocalOrigin(Vector3 v)
		{
			this.NullCheck("SetLocalOrigin");
			method cbseEn_SetLocalOrigin = CBaseEntity.__N.CBseEn_SetLocalOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbseEn_SetLocalOrigin);
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x000296EC File Offset: 0x000278EC
		internal readonly Vector3 GetLocalOrigin()
		{
			this.NullCheck("GetLocalOrigin");
			method cbseEn_GetLocalOrigin = CBaseEntity.__N.CBseEn_GetLocalOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbseEn_GetLocalOrigin);
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00029718 File Offset: 0x00027918
		internal unsafe readonly void SetAbsOrigin(Vector3 origin)
		{
			this.NullCheck("SetAbsOrigin");
			method cbseEn_SetAbsOrigin = CBaseEntity.__N.CBseEn_SetAbsOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbseEn_SetAbsOrigin);
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00029748 File Offset: 0x00027948
		internal unsafe readonly void SetAbsAngles(Angles angles)
		{
			this.NullCheck("SetAbsAngles");
			method cbseEn_SetAbsAngles = CBaseEntity.__N.CBseEn_SetAbsAngles;
			calli(System.Void(System.IntPtr,Angles*), this.self, &angles, cbseEn_SetAbsAngles);
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x00029778 File Offset: 0x00027978
		internal readonly string GetClassname()
		{
			this.NullCheck("GetClassname");
			method cbseEn_GetClassname = CBaseEntity.__N.CBseEn_GetClassname;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetClassname));
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000297A8 File Offset: 0x000279A8
		internal readonly Vector3 GetAbsOrigin()
		{
			this.NullCheck("GetAbsOrigin");
			method cbseEn_GetAbsOrigin = CBaseEntity.__N.CBseEn_GetAbsOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbseEn_GetAbsOrigin);
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x000297D4 File Offset: 0x000279D4
		internal readonly Angles GetAbsAngles()
		{
			this.NullCheck("GetAbsAngles");
			method cbseEn_GetAbsAngles = CBaseEntity.__N.CBseEn_GetAbsAngles;
			return calli(Angles(System.IntPtr), this.self, cbseEn_GetAbsAngles);
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x00029800 File Offset: 0x00027A00
		internal readonly void EnableLagCompensation(bool enabled)
		{
			this.NullCheck("EnableLagCompensation");
			method cbseEn_EnableLagCompensation = CBaseEntity.__N.CBseEn_EnableLagCompensation;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cbseEn_EnableLagCompensation);
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x00029834 File Offset: 0x00027A34
		internal readonly bool IsLagCompensationEnabled()
		{
			this.NullCheck("IsLagCompensationEnabled");
			method cbseEn_IsLagCompensationEnabled = CBaseEntity.__N.CBseEn_IsLagCompensationEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_IsLagCompensationEnabled) > 0;
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x00029864 File Offset: 0x00027A64
		internal readonly Rotation GetLocalQuat()
		{
			this.NullCheck("GetLocalQuat");
			method cbseEn_GetLocalQuat = CBaseEntity.__N.CBseEn_GetLocalQuat;
			return calli(Rotation(System.IntPtr), this.self, cbseEn_GetLocalQuat);
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x00029890 File Offset: 0x00027A90
		internal unsafe readonly void SetLocalQuat(Rotation rot)
		{
			this.NullCheck("SetLocalQuat");
			method cbseEn_SetLocalQuat = CBaseEntity.__N.CBseEn_SetLocalQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbseEn_SetLocalQuat);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x000298C0 File Offset: 0x00027AC0
		internal readonly Rotation GetAbsQuat()
		{
			this.NullCheck("GetAbsQuat");
			method cbseEn_GetAbsQuat = CBaseEntity.__N.CBseEn_GetAbsQuat;
			return calli(Rotation(System.IntPtr), this.self, cbseEn_GetAbsQuat);
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x000298EC File Offset: 0x00027AEC
		internal unsafe readonly void SetAbsQuat(Rotation rot)
		{
			this.NullCheck("SetAbsQuat");
			method cbseEn_SetAbsQuat = CBaseEntity.__N.CBseEn_SetAbsQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbseEn_SetAbsQuat);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0002991C File Offset: 0x00027B1C
		internal readonly float GetAbsScale()
		{
			this.NullCheck("GetAbsScale");
			method cbseEn_GetAbsScale = CBaseEntity.__N.CBseEn_GetAbsScale;
			return calli(System.Single(System.IntPtr), this.self, cbseEn_GetAbsScale);
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x00029948 File Offset: 0x00027B48
		internal readonly void SetAbsScale(float flScale)
		{
			this.NullCheck("SetAbsScale");
			method cbseEn_SetAbsScale = CBaseEntity.__N.CBseEn_SetAbsScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbseEn_SetAbsScale);
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x00029974 File Offset: 0x00027B74
		internal readonly float GetLocalScale()
		{
			this.NullCheck("GetLocalScale");
			method cbseEn_GetLocalScale = CBaseEntity.__N.CBseEn_GetLocalScale;
			return calli(System.Single(System.IntPtr), this.self, cbseEn_GetLocalScale);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x000299A0 File Offset: 0x00027BA0
		internal readonly void SetLocalScale(float flScale)
		{
			this.NullCheck("SetLocalScale");
			method cbseEn_SetLocalScale = CBaseEntity.__N.CBseEn_SetLocalScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbseEn_SetLocalScale);
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x000299CC File Offset: 0x00027BCC
		internal readonly int entindex()
		{
			this.NullCheck("entindex");
			method cbseEn_entindex = CBaseEntity.__N.CBseEn_entindex;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_entindex);
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x000299F8 File Offset: 0x00027BF8
		internal unsafe readonly void SetAbsVelocity(Vector3 origin)
		{
			this.NullCheck("SetAbsVelocity");
			method cbseEn_SetAbsVelocity = CBaseEntity.__N.CBseEn_SetAbsVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbseEn_SetAbsVelocity);
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x00029A28 File Offset: 0x00027C28
		internal readonly Vector3 GetAbsVelocity()
		{
			this.NullCheck("GetAbsVelocity");
			method cbseEn_GetAbsVelocity = CBaseEntity.__N.CBseEn_GetAbsVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseEn_GetAbsVelocity);
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x00029A54 File Offset: 0x00027C54
		internal readonly void AddFlag(int flags)
		{
			this.NullCheck("AddFlag");
			method cbseEn_AddFlag = CBaseEntity.__N.CBseEn_AddFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flags, cbseEn_AddFlag);
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x00029A80 File Offset: 0x00027C80
		internal readonly void RemoveFlag(int flagsToRemove)
		{
			this.NullCheck("RemoveFlag");
			method cbseEn_RemoveFlag = CBaseEntity.__N.CBseEn_RemoveFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagsToRemove, cbseEn_RemoveFlag);
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x00029AAC File Offset: 0x00027CAC
		internal readonly void ToggleFlag(int flagToToggle)
		{
			this.NullCheck("ToggleFlag");
			method cbseEn_ToggleFlag = CBaseEntity.__N.CBseEn_ToggleFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagToToggle, cbseEn_ToggleFlag);
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00029AD8 File Offset: 0x00027CD8
		internal readonly void ClearFlags()
		{
			this.NullCheck("ClearFlags");
			method cbseEn_ClearFlags = CBaseEntity.__N.CBseEn_ClearFlags;
			calli(System.Void(System.IntPtr), this.self, cbseEn_ClearFlags);
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00029B04 File Offset: 0x00027D04
		internal readonly int GetFlags()
		{
			this.NullCheck("GetFlags");
			method cbseEn_GetFlags = CBaseEntity.__N.CBseEn_GetFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_GetFlags);
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x00029B30 File Offset: 0x00027D30
		internal readonly void SetLifeState(LifeState state)
		{
			this.NullCheck("SetLifeState");
			method cbseEn_SetLifeState = CBaseEntity.__N.CBseEn_SetLifeState;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)state, cbseEn_SetLifeState);
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00029B5C File Offset: 0x00027D5C
		internal readonly LifeState GetLifeState()
		{
			this.NullCheck("GetLifeState");
			method cbseEn_GetLifeState = CBaseEntity.__N.CBseEn_GetLifeState;
			return calli(System.Int64(System.IntPtr), this.self, cbseEn_GetLifeState);
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00029B88 File Offset: 0x00027D88
		internal readonly int GetEffects()
		{
			this.NullCheck("GetEffects");
			method cbseEn_GetEffects = CBaseEntity.__N.CBseEn_GetEffects;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_GetEffects);
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x00029BB4 File Offset: 0x00027DB4
		internal readonly void AddEffects(int nEffects)
		{
			this.NullCheck("AddEffects");
			method cbseEn_AddEffects = CBaseEntity.__N.CBseEn_AddEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseEn_AddEffects);
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00029BE0 File Offset: 0x00027DE0
		internal readonly void RemoveEffects(int nEffects)
		{
			this.NullCheck("RemoveEffects");
			method cbseEn_RemoveEffects = CBaseEntity.__N.CBseEn_RemoveEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseEn_RemoveEffects);
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00029C0C File Offset: 0x00027E0C
		internal readonly void ClearEffects()
		{
			this.NullCheck("ClearEffects");
			method cbseEn_ClearEffects = CBaseEntity.__N.CBseEn_ClearEffects;
			calli(System.Void(System.IntPtr), this.self, cbseEn_ClearEffects);
		}

		// Token: 0x06000441 RID: 1089 RVA: 0x00029C38 File Offset: 0x00027E38
		internal readonly void SetEffects(int nEffects)
		{
			this.NullCheck("SetEffects");
			method cbseEn_SetEffects = CBaseEntity.__N.CBseEn_SetEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbseEn_SetEffects);
		}

		// Token: 0x06000442 RID: 1090 RVA: 0x00029C64 File Offset: 0x00027E64
		internal readonly bool IsEffectActive(int nEffectMask)
		{
			this.NullCheck("IsEffectActive");
			method cbseEn_IsEffectActive = CBaseEntity.__N.CBseEn_IsEffectActive;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nEffectMask, cbseEn_IsEffectActive) > 0;
		}

		// Token: 0x06000443 RID: 1091 RVA: 0x00029C94 File Offset: 0x00027E94
		internal readonly void CreateVPhysics()
		{
			this.NullCheck("CreateVPhysics");
			method cbseEn_CreateVPhysics = CBaseEntity.__N.CBseEn_CreateVPhysics;
			calli(System.Void(System.IntPtr), this.self, cbseEn_CreateVPhysics);
		}

		// Token: 0x06000444 RID: 1092 RVA: 0x00029CC0 File Offset: 0x00027EC0
		internal unsafe readonly void ApplyAbsVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyAbsVelocityImpulse");
			method cbseEn_ApplyAbsVelocityImpulse = CBaseEntity.__N.CBseEn_ApplyAbsVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbseEn_ApplyAbsVelocityImpulse);
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x00029CF0 File Offset: 0x00027EF0
		internal unsafe readonly void ApplyLocalVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyLocalVelocityImpulse");
			method cbseEn_ApplyLocalVelocityImpulse = CBaseEntity.__N.CBseEn_ApplyLocalVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbseEn_ApplyLocalVelocityImpulse);
		}

		// Token: 0x06000446 RID: 1094 RVA: 0x00029D20 File Offset: 0x00027F20
		internal unsafe readonly void ApplyLocalAngularVelocityImpulse(Vector3 angImpulse)
		{
			this.NullCheck("ApplyLocalAngularVelocityImpulse");
			method cbseEn_ApplyLocalAngularVelocityImpulse = CBaseEntity.__N.CBseEn_ApplyLocalAngularVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &angImpulse, cbseEn_ApplyLocalAngularVelocityImpulse);
		}

		// Token: 0x06000447 RID: 1095 RVA: 0x00029D50 File Offset: 0x00027F50
		internal readonly void SetMoveType(MoveType val, MoveCollide moveCollide)
		{
			this.NullCheck("SetMoveType");
			method cbseEn_SetMoveType = CBaseEntity.__N.CBseEn_SetMoveType;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (ulong)val, (ulong)moveCollide, cbseEn_SetMoveType);
		}

		// Token: 0x06000448 RID: 1096 RVA: 0x00029D80 File Offset: 0x00027F80
		internal readonly MoveType GetMoveType()
		{
			this.NullCheck("GetMoveType");
			method cbseEn_GetMoveType = CBaseEntity.__N.CBseEn_GetMoveType;
			return calli(System.Int64(System.IntPtr), this.self, cbseEn_GetMoveType);
		}

		// Token: 0x06000449 RID: 1097 RVA: 0x00029DAC File Offset: 0x00027FAC
		internal readonly void PhysicsEnableMotion(bool bEnable)
		{
			this.NullCheck("PhysicsEnableMotion");
			method cbseEn_PhysicsEnableMotion = CBaseEntity.__N.CBseEn_PhysicsEnableMotion;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnable ? 1 : 0, cbseEn_PhysicsEnableMotion);
		}

		// Token: 0x0600044A RID: 1098 RVA: 0x00029DE0 File Offset: 0x00027FE0
		internal readonly void FollowEntity(IntPtr pBaseEntity, bool bBoneMerge)
		{
			this.NullCheck("FollowEntity");
			method cbseEn_FollowEntity = CBaseEntity.__N.CBseEn_FollowEntity;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pBaseEntity, bBoneMerge ? 1 : 0, cbseEn_FollowEntity);
		}

		// Token: 0x0600044B RID: 1099 RVA: 0x00029E14 File Offset: 0x00028014
		internal readonly void StopFollowingEntity()
		{
			this.NullCheck("StopFollowingEntity");
			method cbseEn_StopFollowingEntity = CBaseEntity.__N.CBseEn_StopFollowingEntity;
			calli(System.Void(System.IntPtr), this.self, cbseEn_StopFollowingEntity);
		}

		// Token: 0x0600044C RID: 1100 RVA: 0x00029E40 File Offset: 0x00028040
		internal readonly bool IsFollowingEntity()
		{
			this.NullCheck("IsFollowingEntity");
			method cbseEn_IsFollowingEntity = CBaseEntity.__N.CBseEn_IsFollowingEntity;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_IsFollowingEntity) > 0;
		}

		// Token: 0x0600044D RID: 1101 RVA: 0x00029E70 File Offset: 0x00028070
		internal readonly CBaseEntity GetFollowedEntity()
		{
			this.NullCheck("GetFollowedEntity");
			method cbseEn_GetFollowedEntity = CBaseEntity.__N.CBseEn_GetFollowedEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetFollowedEntity);
		}

		// Token: 0x0600044E RID: 1102 RVA: 0x00029EA0 File Offset: 0x000280A0
		internal readonly PhysicsGroup VPhysicsGetAggregate()
		{
			this.NullCheck("VPhysicsGetAggregate");
			method cbseEn_VPhysicsGetAggregate = CBaseEntity.__N.CBseEn_VPhysicsGetAggregate;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr), this.self, cbseEn_VPhysicsGetAggregate));
		}

		// Token: 0x0600044F RID: 1103 RVA: 0x00029ED0 File Offset: 0x000280D0
		internal readonly Vector3 GetBaseVelocity()
		{
			this.NullCheck("GetBaseVelocity");
			method cbseEn_GetBaseVelocity = CBaseEntity.__N.CBseEn_GetBaseVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseEn_GetBaseVelocity);
		}

		// Token: 0x06000450 RID: 1104 RVA: 0x00029EFC File Offset: 0x000280FC
		internal unsafe readonly void SetBaseVelocity(Vector3 v)
		{
			this.NullCheck("SetBaseVelocity");
			method cbseEn_SetBaseVelocity = CBaseEntity.__N.CBseEn_SetBaseVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbseEn_SetBaseVelocity);
		}

		// Token: 0x06000451 RID: 1105 RVA: 0x00029F2C File Offset: 0x0002812C
		internal readonly void SetGroundEntity(CBaseEntity ground)
		{
			this.NullCheck("SetGroundEntity");
			method cbseEn_SetGroundEntity = CBaseEntity.__N.CBseEn_SetGroundEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ground, cbseEn_SetGroundEntity);
		}

		// Token: 0x06000452 RID: 1106 RVA: 0x00029F5C File Offset: 0x0002815C
		internal readonly CBaseEntity GetGroundEntity()
		{
			this.NullCheck("GetGroundEntity");
			method cbseEn_GetGroundEntity = CBaseEntity.__N.CBseEn_GetGroundEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetGroundEntity);
		}

		// Token: 0x06000453 RID: 1107 RVA: 0x00029F8C File Offset: 0x0002818C
		internal readonly string GetModelNameString()
		{
			this.NullCheck("GetModelNameString");
			method cbseEn_GetModelNameString = CBaseEntity.__N.CBseEn_GetModelNameString;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetModelNameString));
		}

		// Token: 0x06000454 RID: 1108 RVA: 0x00029FBC File Offset: 0x000281BC
		internal unsafe readonly void SetParent(CBaseEntity parent, string nBoneOrAttachName, Transform pOffsetTransform)
		{
			this.NullCheck("SetParent");
			method cbseEn_SetParent = CBaseEntity.__N.CBseEn_SetParent;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32,Transform*), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), &pOffsetTransform, cbseEn_SetParent);
		}

		// Token: 0x06000455 RID: 1109 RVA: 0x00029FF8 File Offset: 0x000281F8
		internal readonly void SetParent(CBaseEntity parent, string nBoneOrAttachName)
		{
			this.NullCheck("SetParent");
			method cbseEn_f = CBaseEntity.__N.CBseEn_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), cbseEn_f);
		}

		// Token: 0x06000456 RID: 1110 RVA: 0x0002A030 File Offset: 0x00028230
		internal readonly CBaseEntity GetParent()
		{
			this.NullCheck("GetParent");
			method cbseEn_GetParent = CBaseEntity.__N.CBseEn_GetParent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetParent);
		}

		// Token: 0x06000457 RID: 1111 RVA: 0x0002A060 File Offset: 0x00028260
		internal readonly void IncrementInterpolationFrame()
		{
			this.NullCheck("IncrementInterpolationFrame");
			method cbseEn_IncrementInterpolationFrame = CBaseEntity.__N.CBseEn_IncrementInterpolationFrame;
			calli(System.Void(System.IntPtr), this.self, cbseEn_IncrementInterpolationFrame);
		}

		// Token: 0x06000458 RID: 1112 RVA: 0x0002A08C File Offset: 0x0002828C
		internal readonly void DispatchUpdateTransmitState()
		{
			this.NullCheck("DispatchUpdateTransmitState");
			method cbseEn_DispatchUpdateTransmitState = CBaseEntity.__N.CBseEn_DispatchUpdateTransmitState;
			calli(System.Void(System.IntPtr), this.self, cbseEn_DispatchUpdateTransmitState);
		}

		// Token: 0x06000459 RID: 1113 RVA: 0x0002A0B8 File Offset: 0x000282B8
		internal readonly void SetActiveChild(CBaseEntity child)
		{
			this.NullCheck("SetActiveChild");
			method cbseEn_SetActiveChild = CBaseEntity.__N.CBseEn_SetActiveChild;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbseEn_SetActiveChild);
		}

		// Token: 0x0600045A RID: 1114 RVA: 0x0002A0E8 File Offset: 0x000282E8
		internal readonly CBaseEntity GetActiveChild()
		{
			this.NullCheck("GetActiveChild");
			method cbseEn_GetActiveChild = CBaseEntity.__N.CBseEn_GetActiveChild;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetActiveChild);
		}

		// Token: 0x0600045B RID: 1115 RVA: 0x0002A118 File Offset: 0x00028318
		internal readonly void SetOwnerEntity(CBaseEntity child)
		{
			this.NullCheck("SetOwnerEntity");
			method cbseEn_SetOwnerEntity = CBaseEntity.__N.CBseEn_SetOwnerEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbseEn_SetOwnerEntity);
		}

		// Token: 0x0600045C RID: 1116 RVA: 0x0002A148 File Offset: 0x00028348
		internal readonly CBaseEntity GetOwnerEntity()
		{
			this.NullCheck("GetOwnerEntity");
			method cbseEn_GetOwnerEntity = CBaseEntity.__N.CBseEn_GetOwnerEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetOwnerEntity);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0002A178 File Offset: 0x00028378
		internal readonly void SetSimulationTime(float time)
		{
			this.NullCheck("SetSimulationTime");
			method cbseEn_SetSimulationTime = CBaseEntity.__N.CBseEn_SetSimulationTime;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbseEn_SetSimulationTime);
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0002A1A4 File Offset: 0x000283A4
		internal readonly bool HasSpawnFlags(int nFlags)
		{
			this.NullCheck("HasSpawnFlags");
			method cbseEn_HasSpawnFlags = CBaseEntity.__N.CBseEn_HasSpawnFlags;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nFlags, cbseEn_HasSpawnFlags) > 0;
		}

		// Token: 0x0600045F RID: 1119 RVA: 0x0002A1D4 File Offset: 0x000283D4
		internal readonly int GetSpawnFlags()
		{
			this.NullCheck("GetSpawnFlags");
			method cbseEn_GetSpawnFlags = CBaseEntity.__N.CBseEn_GetSpawnFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_GetSpawnFlags);
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0002A200 File Offset: 0x00028400
		internal readonly void AddSpawnFlags(int nFlags)
		{
			this.NullCheck("AddSpawnFlags");
			method cbseEn_AddSpawnFlags = CBaseEntity.__N.CBseEn_AddSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbseEn_AddSpawnFlags);
		}

		// Token: 0x06000461 RID: 1121 RVA: 0x0002A22C File Offset: 0x0002842C
		internal readonly void RemoveSpawnFlags(int nFlags)
		{
			this.NullCheck("RemoveSpawnFlags");
			method cbseEn_RemoveSpawnFlags = CBaseEntity.__N.CBseEn_RemoveSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbseEn_RemoveSpawnFlags);
		}

		// Token: 0x06000462 RID: 1122 RVA: 0x0002A258 File Offset: 0x00028458
		internal readonly void ClearSpawnFlags()
		{
			this.NullCheck("ClearSpawnFlags");
			method cbseEn_ClearSpawnFlags = CBaseEntity.__N.CBseEn_ClearSpawnFlags;
			calli(System.Void(System.IntPtr), this.self, cbseEn_ClearSpawnFlags);
		}

		// Token: 0x06000463 RID: 1123 RVA: 0x0002A284 File Offset: 0x00028484
		internal readonly CLightComponent GetLightComponent()
		{
			this.NullCheck("GetLightComponent");
			method cbseEn_GetLightComponent = CBaseEntity.__N.CBseEn_GetLightComponent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbseEn_GetLightComponent);
		}

		// Token: 0x06000464 RID: 1124 RVA: 0x0002A2B4 File Offset: 0x000284B4
		internal readonly void SetMoveDoneTime(float time)
		{
			this.NullCheck("SetMoveDoneTime");
			method cbseEn_SetMoveDoneTime = CBaseEntity.__N.CBseEn_SetMoveDoneTime;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbseEn_SetMoveDoneTime);
		}

		// Token: 0x06000465 RID: 1125 RVA: 0x0002A2E0 File Offset: 0x000284E0
		internal readonly float GetMoveDoneTime()
		{
			this.NullCheck("GetMoveDoneTime");
			method cbseEn_GetMoveDoneTime = CBaseEntity.__N.CBseEn_GetMoveDoneTime;
			return calli(System.Single(System.IntPtr), this.self, cbseEn_GetMoveDoneTime);
		}

		// Token: 0x06000466 RID: 1126 RVA: 0x0002A30C File Offset: 0x0002850C
		internal unsafe readonly void SetLocalVelocity(Vector3 vecVelocity)
		{
			this.NullCheck("SetLocalVelocity");
			method cbseEn_SetLocalVelocity = CBaseEntity.__N.CBseEn_SetLocalVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecVelocity, cbseEn_SetLocalVelocity);
		}

		// Token: 0x06000467 RID: 1127 RVA: 0x0002A33C File Offset: 0x0002853C
		internal readonly Vector3 GetLocalVelocity()
		{
			this.NullCheck("GetLocalVelocity");
			method cbseEn_GetLocalVelocity = CBaseEntity.__N.CBseEn_GetLocalVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbseEn_GetLocalVelocity);
		}

		// Token: 0x06000468 RID: 1128 RVA: 0x0002A368 File Offset: 0x00028568
		internal unsafe readonly void SetLocalAngularVelocity(Angles vecAngVelocity)
		{
			this.NullCheck("SetLocalAngularVelocity");
			method cbseEn_SetLocalAngularVelocity = CBaseEntity.__N.CBseEn_SetLocalAngularVelocity;
			calli(System.Void(System.IntPtr,Angles*), this.self, &vecAngVelocity, cbseEn_SetLocalAngularVelocity);
		}

		// Token: 0x06000469 RID: 1129 RVA: 0x0002A398 File Offset: 0x00028598
		internal readonly Angles GetLocalAngularVelocity()
		{
			this.NullCheck("GetLocalAngularVelocity");
			method cbseEn_GetLocalAngularVelocity = CBaseEntity.__N.CBseEn_GetLocalAngularVelocity;
			return calli(Angles(System.IntPtr), this.self, cbseEn_GetLocalAngularVelocity);
		}

		// Token: 0x0600046A RID: 1130 RVA: 0x0002A3C4 File Offset: 0x000285C4
		internal readonly void SetDebugBits(ulong nBitMask)
		{
			this.NullCheck("SetDebugBits");
			method cbseEn_SetDebugBits = CBaseEntity.__N.CBseEn_SetDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseEn_SetDebugBits);
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x0002A3F0 File Offset: 0x000285F0
		internal readonly bool HasDebugBitsSet(ulong nBitMask)
		{
			this.NullCheck("HasDebugBitsSet");
			method cbseEn_HasDebugBitsSet = CBaseEntity.__N.CBseEn_HasDebugBitsSet;
			return calli(System.Int32(System.IntPtr,System.UInt64), this.self, nBitMask, cbseEn_HasDebugBitsSet) > 0;
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0002A420 File Offset: 0x00028620
		internal readonly void ClearDebugBits(ulong nBitMask)
		{
			this.NullCheck("ClearDebugBits");
			method cbseEn_ClearDebugBits = CBaseEntity.__N.CBseEn_ClearDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseEn_ClearDebugBits);
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0002A44C File Offset: 0x0002864C
		internal readonly void ToggleDebugBits(ulong nBitMask)
		{
			this.NullCheck("ToggleDebugBits");
			method cbseEn_ToggleDebugBits = CBaseEntity.__N.CBseEn_ToggleDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbseEn_ToggleDebugBits);
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0002A478 File Offset: 0x00028678
		internal readonly ulong GetDebugBits()
		{
			this.NullCheck("GetDebugBits");
			method cbseEn_GetDebugBits = CBaseEntity.__N.CBseEn_GetDebugBits;
			return calli(System.UInt64(System.IntPtr), this.self, cbseEn_GetDebugBits);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0002A4A4 File Offset: 0x000286A4
		internal readonly void SetWaterEntity(CBaseEntity ent)
		{
			this.NullCheck("SetWaterEntity");
			method cbseEn_SetWaterEntity = CBaseEntity.__N.CBseEn_SetWaterEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ent, cbseEn_SetWaterEntity);
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0002A4D4 File Offset: 0x000286D4
		internal readonly Entity GetWaterEntity()
		{
			this.NullCheck("GetWaterEntity");
			method cbseEn_GetWaterEntity = CBaseEntity.__N.CBseEn_GetWaterEntity;
			return InteropSystem.Get<Entity>(calli(System.UInt32(System.IntPtr), this.self, cbseEn_GetWaterEntity));
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0002A504 File Offset: 0x00028704
		internal readonly void WorldSpaceAABB(out Vector3 mins, out Vector3 maxs)
		{
			this.NullCheck("WorldSpaceAABB");
			method cbseEn_WorldSpaceAABB = CBaseEntity.__N.CBseEn_WorldSpaceAABB;
			calli(System.Void(System.IntPtr,Vector3& modreq(System.Runtime.InteropServices.OutAttribute),Vector3& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, ref mins, ref maxs, cbseEn_WorldSpaceAABB);
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0002A530 File Offset: 0x00028730
		internal readonly void RemoveAllDecals()
		{
			this.NullCheck("RemoveAllDecals");
			method cbseEn_RemoveAllDecals = CBaseEntity.__N.CBseEn_RemoveAllDecals;
			calli(System.Void(System.IntPtr), this.self, cbseEn_RemoveAllDecals);
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0002A55C File Offset: 0x0002875C
		internal readonly string SB_GetEntityName()
		{
			this.NullCheck("SB_GetEntityName");
			method cbseEn_SB_GetEntityName = CBaseEntity.__N.CBseEn_SB_GetEntityName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbseEn_SB_GetEntityName));
		}

		// Token: 0x06000474 RID: 1140 RVA: 0x0002A58C File Offset: 0x0002878C
		internal readonly void SB_SetEntityName(string name)
		{
			this.NullCheck("SB_SetEntityName");
			method cbseEn_SB_SetEntityName = CBaseEntity.__N.CBseEn_SB_SetEntityName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbseEn_SB_SetEntityName);
		}

		// Token: 0x06000475 RID: 1141 RVA: 0x0002A5BC File Offset: 0x000287BC
		internal readonly void SetData(int index, bool local, IntPtr data, int size)
		{
			this.NullCheck("SetData");
			method cbseEn_SetData = CBaseEntity.__N.CBseEn_SetData;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.IntPtr,System.Int32), this.self, index, local ? 1 : 0, data, size, cbseEn_SetData);
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0002A5F4 File Offset: 0x000287F4
		internal readonly void ClearData()
		{
			this.NullCheck("ClearData");
			method cbseEn_ClearData = CBaseEntity.__N.CBseEn_ClearData;
			calli(System.Void(System.IntPtr), this.self, cbseEn_ClearData);
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0002A620 File Offset: 0x00028820
		internal readonly bool IsServerOnly()
		{
			this.NullCheck("IsServerOnly");
			method cbseEn_IsServerOnly = CBaseEntity.__N.CBseEn_IsServerOnly;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_IsServerOnly) > 0;
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0002A650 File Offset: 0x00028850
		internal readonly bool IsClientOnly()
		{
			this.NullCheck("IsClientOnly");
			method cbseEn_IsClientOnly = CBaseEntity.__N.CBseEn_IsClientOnly;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_IsClientOnly) > 0;
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0002A680 File Offset: 0x00028880
		internal readonly bool IsClientServerNetworked()
		{
			this.NullCheck("IsClientServerNetworked");
			method cbseEn_IsClientServerNetworked = CBaseEntity.__N.CBseEn_IsClientServerNetworked;
			return calli(System.Int32(System.IntPtr), this.self, cbseEn_IsClientServerNetworked) > 0;
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x0002A6AD File Offset: 0x000288AD
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x0002A6CA File Offset: 0x000288CA
		internal int m_ManagedClassIdent
		{
			get
			{
				this.NullCheck("m_ManagedClassIdent");
				return CBaseEntity.__N.Get__CBseEn_m_ManagedClassIdent(this.self);
			}
			set
			{
				this.NullCheck("m_ManagedClassIdent");
				CBaseEntity.__N.Set__CBseEn_m_ManagedClassIdent(this.self, value);
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600047C RID: 1148 RVA: 0x0002A6E8 File Offset: 0x000288E8
		// (set) Token: 0x0600047D RID: 1149 RVA: 0x0002A70A File Offset: 0x0002890A
		internal Entity EntityObject
		{
			get
			{
				this.NullCheck("EntityObject");
				return InteropSystem.Get<Entity>(CBaseEntity.__N.Get__CBseEn_EntityObject(this.self));
			}
			set
			{
				this.NullCheck("EntityObject");
				CBaseEntity.__N.Set__CBseEn_EntityObject(this.self, (value == null) ? 0U : InteropSystem.GetAddress<Entity>(value, true));
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x0002A734 File Offset: 0x00028934
		// (set) Token: 0x0600047F RID: 1151 RVA: 0x0002A751 File Offset: 0x00028951
		internal int m_iTransmitMode
		{
			get
			{
				this.NullCheck("m_iTransmitMode");
				return CBaseEntity.__N.Get__CBseEn_m_iTransmitMode(this.self);
			}
			set
			{
				this.NullCheck("m_iTransmitMode");
				CBaseEntity.__N.Set__CBseEn_m_iTransmitMode(this.self, value);
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0002A76F File Offset: 0x0002896F
		// (set) Token: 0x06000481 RID: 1153 RVA: 0x0002A78C File Offset: 0x0002898C
		internal Vector3 m_EyePosOffset
		{
			get
			{
				this.NullCheck("m_EyePosOffset");
				return CBaseEntity.__N.Get__CBseEn_m_EyePosOffset(this.self);
			}
			set
			{
				this.NullCheck("m_EyePosOffset");
				CBaseEntity.__N.Set__CBseEn_m_EyePosOffset(this.self, value);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x0002A7AA File Offset: 0x000289AA
		// (set) Token: 0x06000483 RID: 1155 RVA: 0x0002A7C7 File Offset: 0x000289C7
		internal Rotation m_EyeRotOffset
		{
			get
			{
				this.NullCheck("m_EyeRotOffset");
				return CBaseEntity.__N.Get__CBseEn_m_EyeRotOffset(this.self);
			}
			set
			{
				this.NullCheck("m_EyeRotOffset");
				CBaseEntity.__N.Set__CBseEn_m_EyeRotOffset(this.self, value);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000484 RID: 1156 RVA: 0x0002A7E5 File Offset: 0x000289E5
		// (set) Token: 0x06000485 RID: 1157 RVA: 0x0002A802 File Offset: 0x00028A02
		internal byte m_WaterLevel
		{
			get
			{
				this.NullCheck("m_WaterLevel");
				return CBaseEntity.__N.Get__CBseEn_m_WaterLevel(this.self);
			}
			set
			{
				this.NullCheck("m_WaterLevel");
				CBaseEntity.__N.Set__CBseEn_m_WaterLevel(this.self, value);
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x0002A820 File Offset: 0x00028A20
		// (set) Token: 0x06000487 RID: 1159 RVA: 0x0002A83D File Offset: 0x00028A3D
		internal float m_fHealth
		{
			get
			{
				this.NullCheck("m_fHealth");
				return CBaseEntity.__N.Get__CBseEn_m_fHealth(this.self);
			}
			set
			{
				this.NullCheck("m_fHealth");
				CBaseEntity.__N.Set__CBseEn_m_fHealth(this.self, value);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x0002A85B File Offset: 0x00028A5B
		// (set) Token: 0x06000489 RID: 1161 RVA: 0x0002A878 File Offset: 0x00028A78
		internal int m_netHash
		{
			get
			{
				this.NullCheck("m_netHash");
				return CBaseEntity.__N.Get__CBseEn_m_netHash(this.self);
			}
			set
			{
				this.NullCheck("m_netHash");
				CBaseEntity.__N.Set__CBseEn_m_netHash(this.self, value);
			}
		}

		// Token: 0x040000A2 RID: 162
		internal IntPtr self;

		// Token: 0x020001AB RID: 427
		internal static class __N
		{
			// Token: 0x04000A49 RID: 2633
			internal static method From_CGameEntity_To_CBaseEntity;

			// Token: 0x04000A4A RID: 2634
			internal static method To_CGameEntity_From_CBaseEntity;

			// Token: 0x04000A4B RID: 2635
			internal static method From_CEntityInstance_To_CBaseEntity;

			// Token: 0x04000A4C RID: 2636
			internal static method To_CEntityInstance_From_CBaseEntity;

			// Token: 0x04000A4D RID: 2637
			internal static method From_IHandleEntity_To_CBaseEntity;

			// Token: 0x04000A4E RID: 2638
			internal static method To_IHandleEntity_From_CBaseEntity;

			// Token: 0x04000A4F RID: 2639
			internal static method CBseEn_GetDataTable;

			// Token: 0x04000A50 RID: 2640
			internal static method CBseEn_GetEntityHandle;

			// Token: 0x04000A51 RID: 2641
			internal static method CBseEn_SetLocalOrigin;

			// Token: 0x04000A52 RID: 2642
			internal static method CBseEn_GetLocalOrigin;

			// Token: 0x04000A53 RID: 2643
			internal static method CBseEn_SetAbsOrigin;

			// Token: 0x04000A54 RID: 2644
			internal static method CBseEn_SetAbsAngles;

			// Token: 0x04000A55 RID: 2645
			internal static method CBseEn_GetClassname;

			// Token: 0x04000A56 RID: 2646
			internal static method CBseEn_GetAbsOrigin;

			// Token: 0x04000A57 RID: 2647
			internal static method CBseEn_GetAbsAngles;

			// Token: 0x04000A58 RID: 2648
			internal static method CBseEn_EnableLagCompensation;

			// Token: 0x04000A59 RID: 2649
			internal static method CBseEn_IsLagCompensationEnabled;

			// Token: 0x04000A5A RID: 2650
			internal static method CBseEn_GetLocalQuat;

			// Token: 0x04000A5B RID: 2651
			internal static method CBseEn_SetLocalQuat;

			// Token: 0x04000A5C RID: 2652
			internal static method CBseEn_GetAbsQuat;

			// Token: 0x04000A5D RID: 2653
			internal static method CBseEn_SetAbsQuat;

			// Token: 0x04000A5E RID: 2654
			internal static method CBseEn_GetAbsScale;

			// Token: 0x04000A5F RID: 2655
			internal static method CBseEn_SetAbsScale;

			// Token: 0x04000A60 RID: 2656
			internal static method CBseEn_GetLocalScale;

			// Token: 0x04000A61 RID: 2657
			internal static method CBseEn_SetLocalScale;

			// Token: 0x04000A62 RID: 2658
			internal static method CBseEn_entindex;

			// Token: 0x04000A63 RID: 2659
			internal static method CBseEn_SetAbsVelocity;

			// Token: 0x04000A64 RID: 2660
			internal static method CBseEn_GetAbsVelocity;

			// Token: 0x04000A65 RID: 2661
			internal static method CBseEn_AddFlag;

			// Token: 0x04000A66 RID: 2662
			internal static method CBseEn_RemoveFlag;

			// Token: 0x04000A67 RID: 2663
			internal static method CBseEn_ToggleFlag;

			// Token: 0x04000A68 RID: 2664
			internal static method CBseEn_ClearFlags;

			// Token: 0x04000A69 RID: 2665
			internal static method CBseEn_GetFlags;

			// Token: 0x04000A6A RID: 2666
			internal static method CBseEn_SetLifeState;

			// Token: 0x04000A6B RID: 2667
			internal static method CBseEn_GetLifeState;

			// Token: 0x04000A6C RID: 2668
			internal static method CBseEn_GetEffects;

			// Token: 0x04000A6D RID: 2669
			internal static method CBseEn_AddEffects;

			// Token: 0x04000A6E RID: 2670
			internal static method CBseEn_RemoveEffects;

			// Token: 0x04000A6F RID: 2671
			internal static method CBseEn_ClearEffects;

			// Token: 0x04000A70 RID: 2672
			internal static method CBseEn_SetEffects;

			// Token: 0x04000A71 RID: 2673
			internal static method CBseEn_IsEffectActive;

			// Token: 0x04000A72 RID: 2674
			internal static method CBseEn_CreateVPhysics;

			// Token: 0x04000A73 RID: 2675
			internal static method CBseEn_ApplyAbsVelocityImpulse;

			// Token: 0x04000A74 RID: 2676
			internal static method CBseEn_ApplyLocalVelocityImpulse;

			// Token: 0x04000A75 RID: 2677
			internal static method CBseEn_ApplyLocalAngularVelocityImpulse;

			// Token: 0x04000A76 RID: 2678
			internal static method CBseEn_SetMoveType;

			// Token: 0x04000A77 RID: 2679
			internal static method CBseEn_GetMoveType;

			// Token: 0x04000A78 RID: 2680
			internal static method CBseEn_PhysicsEnableMotion;

			// Token: 0x04000A79 RID: 2681
			internal static method CBseEn_FollowEntity;

			// Token: 0x04000A7A RID: 2682
			internal static method CBseEn_StopFollowingEntity;

			// Token: 0x04000A7B RID: 2683
			internal static method CBseEn_IsFollowingEntity;

			// Token: 0x04000A7C RID: 2684
			internal static method CBseEn_GetFollowedEntity;

			// Token: 0x04000A7D RID: 2685
			internal static method CBseEn_VPhysicsGetAggregate;

			// Token: 0x04000A7E RID: 2686
			internal static method CBseEn_GetBaseVelocity;

			// Token: 0x04000A7F RID: 2687
			internal static method CBseEn_SetBaseVelocity;

			// Token: 0x04000A80 RID: 2688
			internal static method CBseEn_SetGroundEntity;

			// Token: 0x04000A81 RID: 2689
			internal static method CBseEn_GetGroundEntity;

			// Token: 0x04000A82 RID: 2690
			internal static method CBseEn_GetModelNameString;

			// Token: 0x04000A83 RID: 2691
			internal static method CBseEn_SetParent;

			// Token: 0x04000A84 RID: 2692
			internal static method CBseEn_f2;

			// Token: 0x04000A85 RID: 2693
			internal static method CBseEn_GetParent;

			// Token: 0x04000A86 RID: 2694
			internal static method CBseEn_IncrementInterpolationFrame;

			// Token: 0x04000A87 RID: 2695
			internal static method CBseEn_DispatchUpdateTransmitState;

			// Token: 0x04000A88 RID: 2696
			internal static method CBseEn_SetActiveChild;

			// Token: 0x04000A89 RID: 2697
			internal static method CBseEn_GetActiveChild;

			// Token: 0x04000A8A RID: 2698
			internal static method CBseEn_SetOwnerEntity;

			// Token: 0x04000A8B RID: 2699
			internal static method CBseEn_GetOwnerEntity;

			// Token: 0x04000A8C RID: 2700
			internal static method CBseEn_SetSimulationTime;

			// Token: 0x04000A8D RID: 2701
			internal static method CBseEn_HasSpawnFlags;

			// Token: 0x04000A8E RID: 2702
			internal static method CBseEn_GetSpawnFlags;

			// Token: 0x04000A8F RID: 2703
			internal static method CBseEn_AddSpawnFlags;

			// Token: 0x04000A90 RID: 2704
			internal static method CBseEn_RemoveSpawnFlags;

			// Token: 0x04000A91 RID: 2705
			internal static method CBseEn_ClearSpawnFlags;

			// Token: 0x04000A92 RID: 2706
			internal static method CBseEn_GetLightComponent;

			// Token: 0x04000A93 RID: 2707
			internal static method CBseEn_SetMoveDoneTime;

			// Token: 0x04000A94 RID: 2708
			internal static method CBseEn_GetMoveDoneTime;

			// Token: 0x04000A95 RID: 2709
			internal static method CBseEn_SetLocalVelocity;

			// Token: 0x04000A96 RID: 2710
			internal static method CBseEn_GetLocalVelocity;

			// Token: 0x04000A97 RID: 2711
			internal static method CBseEn_SetLocalAngularVelocity;

			// Token: 0x04000A98 RID: 2712
			internal static method CBseEn_GetLocalAngularVelocity;

			// Token: 0x04000A99 RID: 2713
			internal static method CBseEn_SetDebugBits;

			// Token: 0x04000A9A RID: 2714
			internal static method CBseEn_HasDebugBitsSet;

			// Token: 0x04000A9B RID: 2715
			internal static method CBseEn_ClearDebugBits;

			// Token: 0x04000A9C RID: 2716
			internal static method CBseEn_ToggleDebugBits;

			// Token: 0x04000A9D RID: 2717
			internal static method CBseEn_GetDebugBits;

			// Token: 0x04000A9E RID: 2718
			internal static method CBseEn_SetWaterEntity;

			// Token: 0x04000A9F RID: 2719
			internal static method CBseEn_GetWaterEntity;

			// Token: 0x04000AA0 RID: 2720
			internal static method CBseEn_WorldSpaceAABB;

			// Token: 0x04000AA1 RID: 2721
			internal static method CBseEn_RemoveAllDecals;

			// Token: 0x04000AA2 RID: 2722
			internal static method CBseEn_SB_GetEntityName;

			// Token: 0x04000AA3 RID: 2723
			internal static method CBseEn_SB_SetEntityName;

			// Token: 0x04000AA4 RID: 2724
			internal static method CBseEn_SetData;

			// Token: 0x04000AA5 RID: 2725
			internal static method CBseEn_ClearData;

			// Token: 0x04000AA6 RID: 2726
			internal static method CBseEn_IsServerOnly;

			// Token: 0x04000AA7 RID: 2727
			internal static method CBseEn_IsClientOnly;

			// Token: 0x04000AA8 RID: 2728
			internal static method CBseEn_IsClientServerNetworked;

			// Token: 0x04000AA9 RID: 2729
			internal static CBaseEntity.__N._Get__CBseEn_m_ManagedClassIdent Get__CBseEn_m_ManagedClassIdent;

			// Token: 0x04000AAA RID: 2730
			internal static CBaseEntity.__N._Set__CBseEn_m_ManagedClassIdent Set__CBseEn_m_ManagedClassIdent;

			// Token: 0x04000AAB RID: 2731
			internal static CBaseEntity.__N._Get__CBseEn_EntityObject Get__CBseEn_EntityObject;

			// Token: 0x04000AAC RID: 2732
			internal static CBaseEntity.__N._Set__CBseEn_EntityObject Set__CBseEn_EntityObject;

			// Token: 0x04000AAD RID: 2733
			internal static CBaseEntity.__N._Get__CBseEn_m_iTransmitMode Get__CBseEn_m_iTransmitMode;

			// Token: 0x04000AAE RID: 2734
			internal static CBaseEntity.__N._Set__CBseEn_m_iTransmitMode Set__CBseEn_m_iTransmitMode;

			// Token: 0x04000AAF RID: 2735
			internal static CBaseEntity.__N._Get__CBseEn_m_EyePosOffset Get__CBseEn_m_EyePosOffset;

			// Token: 0x04000AB0 RID: 2736
			internal static CBaseEntity.__N._Set__CBseEn_m_EyePosOffset Set__CBseEn_m_EyePosOffset;

			// Token: 0x04000AB1 RID: 2737
			internal static CBaseEntity.__N._Get__CBseEn_m_EyeRotOffset Get__CBseEn_m_EyeRotOffset;

			// Token: 0x04000AB2 RID: 2738
			internal static CBaseEntity.__N._Set__CBseEn_m_EyeRotOffset Set__CBseEn_m_EyeRotOffset;

			// Token: 0x04000AB3 RID: 2739
			internal static CBaseEntity.__N._Get__CBseEn_m_WaterLevel Get__CBseEn_m_WaterLevel;

			// Token: 0x04000AB4 RID: 2740
			internal static CBaseEntity.__N._Set__CBseEn_m_WaterLevel Set__CBseEn_m_WaterLevel;

			// Token: 0x04000AB5 RID: 2741
			internal static CBaseEntity.__N._Get__CBseEn_m_fHealth Get__CBseEn_m_fHealth;

			// Token: 0x04000AB6 RID: 2742
			internal static CBaseEntity.__N._Set__CBseEn_m_fHealth Set__CBseEn_m_fHealth;

			// Token: 0x04000AB7 RID: 2743
			internal static CBaseEntity.__N._Get__CBseEn_m_netHash Get__CBseEn_m_netHash;

			// Token: 0x04000AB8 RID: 2744
			internal static CBaseEntity.__N._Set__CBseEn_m_netHash Set__CBseEn_m_netHash;

			// Token: 0x020002E5 RID: 741
			// (Invoke) Token: 0x06002090 RID: 8336
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__CBseEn_m_ManagedClassIdent(IntPtr self);

			// Token: 0x020002E6 RID: 742
			// (Invoke) Token: 0x06002094 RID: 8340
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_ManagedClassIdent(IntPtr self, int val);

			// Token: 0x020002E7 RID: 743
			// (Invoke) Token: 0x06002098 RID: 8344
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate uint _Get__CBseEn_EntityObject(IntPtr self);

			// Token: 0x020002E8 RID: 744
			// (Invoke) Token: 0x0600209C RID: 8348
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_EntityObject(IntPtr self, uint val);

			// Token: 0x020002E9 RID: 745
			// (Invoke) Token: 0x060020A0 RID: 8352
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__CBseEn_m_iTransmitMode(IntPtr self);

			// Token: 0x020002EA RID: 746
			// (Invoke) Token: 0x060020A4 RID: 8356
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_iTransmitMode(IntPtr self, int val);

			// Token: 0x020002EB RID: 747
			// (Invoke) Token: 0x060020A8 RID: 8360
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Vector3 _Get__CBseEn_m_EyePosOffset(IntPtr self);

			// Token: 0x020002EC RID: 748
			// (Invoke) Token: 0x060020AC RID: 8364
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_EyePosOffset(IntPtr self, Vector3 val);

			// Token: 0x020002ED RID: 749
			// (Invoke) Token: 0x060020B0 RID: 8368
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate Rotation _Get__CBseEn_m_EyeRotOffset(IntPtr self);

			// Token: 0x020002EE RID: 750
			// (Invoke) Token: 0x060020B4 RID: 8372
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_EyeRotOffset(IntPtr self, Rotation val);

			// Token: 0x020002EF RID: 751
			// (Invoke) Token: 0x060020B8 RID: 8376
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate byte _Get__CBseEn_m_WaterLevel(IntPtr self);

			// Token: 0x020002F0 RID: 752
			// (Invoke) Token: 0x060020BC RID: 8380
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_WaterLevel(IntPtr self, byte val);

			// Token: 0x020002F1 RID: 753
			// (Invoke) Token: 0x060020C0 RID: 8384
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate float _Get__CBseEn_m_fHealth(IntPtr self);

			// Token: 0x020002F2 RID: 754
			// (Invoke) Token: 0x060020C4 RID: 8388
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_fHealth(IntPtr self, float val);

			// Token: 0x020002F3 RID: 755
			// (Invoke) Token: 0x060020C8 RID: 8392
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__CBseEn_m_netHash(IntPtr self);

			// Token: 0x020002F4 RID: 756
			// (Invoke) Token: 0x060020CC RID: 8396
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBseEn_m_netHash(IntPtr self, int val);
		}
	}
}
