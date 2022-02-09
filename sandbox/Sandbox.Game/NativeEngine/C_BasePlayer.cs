using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200001D RID: 29
	internal struct C_BasePlayer
	{
		// Token: 0x060002E2 RID: 738 RVA: 0x0002689B File Offset: 0x00024A9B
		public static implicit operator IntPtr(C_BasePlayer value)
		{
			return value.self;
		}

		// Token: 0x060002E3 RID: 739 RVA: 0x000268A4 File Offset: 0x00024AA4
		public static implicit operator C_BasePlayer(IntPtr value)
		{
			return new C_BasePlayer
			{
				self = value
			};
		}

		// Token: 0x060002E4 RID: 740 RVA: 0x000268C2 File Offset: 0x00024AC2
		public static bool operator ==(C_BasePlayer c1, C_BasePlayer c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060002E5 RID: 741 RVA: 0x000268D5 File Offset: 0x00024AD5
		public static bool operator !=(C_BasePlayer c1, C_BasePlayer c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060002E6 RID: 742 RVA: 0x000268E8 File Offset: 0x00024AE8
		public override bool Equals(object obj)
		{
			if (obj is C_BasePlayer)
			{
				C_BasePlayer c = (C_BasePlayer)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060002E7 RID: 743 RVA: 0x00026912 File Offset: 0x00024B12
		internal C_BasePlayer(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060002E8 RID: 744 RVA: 0x0002691C File Offset: 0x00024B1C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
			defaultInterpolatedStringHandler.AppendLiteral("C_BasePlayer ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060002E9 RID: 745 RVA: 0x00026958 File Offset: 0x00024B58
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060002EA RID: 746 RVA: 0x0002696A File Offset: 0x00024B6A
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060002EB RID: 747 RVA: 0x00026975 File Offset: 0x00024B75
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x00026988 File Offset: 0x00024B88
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("C_BasePlayer was null when calling " + n);
			}
		}

		// Token: 0x060002ED RID: 749 RVA: 0x000269A3 File Offset: 0x00024BA3
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060002EE RID: 750 RVA: 0x000269B0 File Offset: 0x00024BB0
		public static implicit operator C_BaseEntity(C_BasePlayer value)
		{
			method to_C_BaseEntity_From_C_BasePlayer = C_BasePlayer.__N.To_C_BaseEntity_From_C_BasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, to_C_BaseEntity_From_C_BasePlayer);
		}

		// Token: 0x060002EF RID: 751 RVA: 0x000269D4 File Offset: 0x00024BD4
		public static explicit operator C_BasePlayer(C_BaseEntity value)
		{
			method from_C_BaseEntity_To_C_BasePlayer = C_BasePlayer.__N.From_C_BaseEntity_To_C_BasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, from_C_BaseEntity_To_C_BasePlayer);
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x000269F8 File Offset: 0x00024BF8
		public static implicit operator CGameEntity(C_BasePlayer value)
		{
			method to_CGameEntity_From_C_BasePlayer = C_BasePlayer.__N.To_CGameEntity_From_C_BasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, to_CGameEntity_From_C_BasePlayer);
		}

		// Token: 0x060002F1 RID: 753 RVA: 0x00026A1C File Offset: 0x00024C1C
		public static explicit operator C_BasePlayer(CGameEntity value)
		{
			method from_CGameEntity_To_C_BasePlayer = C_BasePlayer.__N.From_CGameEntity_To_C_BasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, from_CGameEntity_To_C_BasePlayer);
		}

		// Token: 0x060002F2 RID: 754 RVA: 0x00026A40 File Offset: 0x00024C40
		public static implicit operator CEntityInstance(C_BasePlayer value)
		{
			method to_CEntityInstance_From_C_BasePlayer = C_BasePlayer.__N.To_CEntityInstance_From_C_BasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, to_CEntityInstance_From_C_BasePlayer);
		}

		// Token: 0x060002F3 RID: 755 RVA: 0x00026A64 File Offset: 0x00024C64
		public static explicit operator C_BasePlayer(CEntityInstance value)
		{
			method from_CEntityInstance_To_C_BasePlayer = C_BasePlayer.__N.From_CEntityInstance_To_C_BasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, from_CEntityInstance_To_C_BasePlayer);
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x00026A88 File Offset: 0x00024C88
		public static implicit operator IHandleEntity(C_BasePlayer value)
		{
			method to_IHandleEntity_From_C_BasePlayer = C_BasePlayer.__N.To_IHandleEntity_From_C_BasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, to_IHandleEntity_From_C_BasePlayer);
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00026AAC File Offset: 0x00024CAC
		public static explicit operator C_BasePlayer(IHandleEntity value)
		{
			method from_IHandleEntity_To_C_BasePlayer = C_BasePlayer.__N.From_IHandleEntity_To_C_BasePlayer;
			return calli(System.IntPtr(System.IntPtr), value, from_IHandleEntity_To_C_BasePlayer);
		}

		// Token: 0x060002F6 RID: 758 RVA: 0x00026AD0 File Offset: 0x00024CD0
		internal readonly string GetPlayerName()
		{
			this.NullCheck("GetPlayerName");
			method cbsePl_GetPlayerName = C_BasePlayer.__N.CBsePl_GetPlayerName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetPlayerName));
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x00026B00 File Offset: 0x00024D00
		internal readonly int GetUserID()
		{
			this.NullCheck("GetUserID");
			method cbsePl_GetUserID = C_BasePlayer.__N.CBsePl_GetUserID;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetUserID);
		}

		// Token: 0x060002F8 RID: 760 RVA: 0x00026B2C File Offset: 0x00024D2C
		internal readonly bool IsLocalPlayer()
		{
			this.NullCheck("IsLocalPlayer");
			method cbsePl_IsLocalPlayer = C_BasePlayer.__N.CBsePl_IsLocalPlayer;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsLocalPlayer) > 0;
		}

		// Token: 0x060002F9 RID: 761 RVA: 0x00026B5C File Offset: 0x00024D5C
		internal readonly void UpdateButtonState(int buttons)
		{
			this.NullCheck("UpdateButtonState");
			method cbsePl_UpdateButtonState = C_BasePlayer.__N.CBsePl_UpdateButtonState;
			calli(System.Void(System.IntPtr,System.Int32), this.self, buttons, cbsePl_UpdateButtonState);
		}

		// Token: 0x060002FA RID: 762 RVA: 0x00026B88 File Offset: 0x00024D88
		internal unsafe readonly void SetPreviouslyPredictedOrigin(Vector3 v)
		{
			this.NullCheck("SetPreviouslyPredictedOrigin");
			method cbsePl_SetPreviouslyPredictedOrigin = C_BasePlayer.__N.CBsePl_SetPreviouslyPredictedOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbsePl_SetPreviouslyPredictedOrigin);
		}

		// Token: 0x060002FB RID: 763 RVA: 0x00026BB8 File Offset: 0x00024DB8
		internal readonly ulong GetSteamIDAsUInt64()
		{
			this.NullCheck("GetSteamIDAsUInt64");
			method cbsePl_GetSteamIDAsUInt = C_BasePlayer.__N.CBsePl_GetSteamIDAsUInt64;
			return calli(System.UInt64(System.IntPtr), this.self, cbsePl_GetSteamIDAsUInt);
		}

		// Token: 0x060002FC RID: 764 RVA: 0x00026BE4 File Offset: 0x00024DE4
		internal readonly void InitializeEntityObject(Entity pointer)
		{
			this.NullCheck("InitializeEntityObject");
			method cbsePl_InitializeEntityObject = C_BasePlayer.__N.CBsePl_InitializeEntityObject;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, (pointer == null) ? 0U : InteropSystem.GetAddress<Entity>(pointer, true), cbsePl_InitializeEntityObject);
		}

		// Token: 0x060002FD RID: 765 RVA: 0x00026C1C File Offset: 0x00024E1C
		internal readonly DataTable GetDataTable()
		{
			this.NullCheck("GetDataTable");
			method cbsePl_GetDataTable = C_BasePlayer.__N.CBsePl_GetDataTable;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetDataTable);
		}

		// Token: 0x060002FE RID: 766 RVA: 0x00026C4C File Offset: 0x00024E4C
		internal readonly int GetEntityHandle()
		{
			this.NullCheck("GetEntityHandle");
			method cbsePl_GetEntityHandle = C_BasePlayer.__N.CBsePl_GetEntityHandle;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetEntityHandle);
		}

		// Token: 0x060002FF RID: 767 RVA: 0x00026C78 File Offset: 0x00024E78
		internal readonly string GetClassname()
		{
			this.NullCheck("GetClassname");
			method cbsePl_GetClassname = C_BasePlayer.__N.CBsePl_GetClassname;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetClassname));
		}

		// Token: 0x06000300 RID: 768 RVA: 0x00026CA8 File Offset: 0x00024EA8
		internal readonly string GetDebugName()
		{
			this.NullCheck("GetDebugName");
			method cbsePl_GetDebugName = C_BasePlayer.__N.CBsePl_GetDebugName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetDebugName));
		}

		// Token: 0x06000301 RID: 769 RVA: 0x00026CD8 File Offset: 0x00024ED8
		internal readonly int entindex()
		{
			this.NullCheck("entindex");
			method cbsePl_entindex = C_BasePlayer.__N.CBsePl_entindex;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_entindex);
		}

		// Token: 0x06000302 RID: 770 RVA: 0x00026D04 File Offset: 0x00024F04
		internal unsafe readonly void SetLocalOrigin(Vector3 v)
		{
			this.NullCheck("SetLocalOrigin");
			method cbsePl_SetLocalOrigin = C_BasePlayer.__N.CBsePl_SetLocalOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbsePl_SetLocalOrigin);
		}

		// Token: 0x06000303 RID: 771 RVA: 0x00026D34 File Offset: 0x00024F34
		internal readonly Vector3 GetLocalOrigin()
		{
			this.NullCheck("GetLocalOrigin");
			method cbsePl_GetLocalOrigin = C_BasePlayer.__N.CBsePl_GetLocalOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbsePl_GetLocalOrigin);
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00026D60 File Offset: 0x00024F60
		internal readonly Rotation GetLocalQuat()
		{
			this.NullCheck("GetLocalQuat");
			method cbsePl_GetLocalQuat = C_BasePlayer.__N.CBsePl_GetLocalQuat;
			return calli(Rotation(System.IntPtr), this.self, cbsePl_GetLocalQuat);
		}

		// Token: 0x06000305 RID: 773 RVA: 0x00026D8C File Offset: 0x00024F8C
		internal unsafe readonly void SetLocalQuat(Rotation rot)
		{
			this.NullCheck("SetLocalQuat");
			method cbsePl_SetLocalQuat = C_BasePlayer.__N.CBsePl_SetLocalQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbsePl_SetLocalQuat);
		}

		// Token: 0x06000306 RID: 774 RVA: 0x00026DBC File Offset: 0x00024FBC
		internal readonly Rotation GetAbsQuat()
		{
			this.NullCheck("GetAbsQuat");
			method cbsePl_GetAbsQuat = C_BasePlayer.__N.CBsePl_GetAbsQuat;
			return calli(Rotation(System.IntPtr), this.self, cbsePl_GetAbsQuat);
		}

		// Token: 0x06000307 RID: 775 RVA: 0x00026DE8 File Offset: 0x00024FE8
		internal unsafe readonly void SetAbsQuat(Rotation rot)
		{
			this.NullCheck("SetAbsQuat");
			method cbsePl_SetAbsQuat = C_BasePlayer.__N.CBsePl_SetAbsQuat;
			calli(System.Void(System.IntPtr,Rotation*), this.self, &rot, cbsePl_SetAbsQuat);
		}

		// Token: 0x06000308 RID: 776 RVA: 0x00026E18 File Offset: 0x00025018
		internal unsafe readonly void SetAbsOrigin(Vector3 origin)
		{
			this.NullCheck("SetAbsOrigin");
			method cbsePl_SetAbsOrigin = C_BasePlayer.__N.CBsePl_SetAbsOrigin;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbsePl_SetAbsOrigin);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00026E48 File Offset: 0x00025048
		internal readonly Vector3 GetAbsOrigin()
		{
			this.NullCheck("GetAbsOrigin");
			method cbsePl_GetAbsOrigin = C_BasePlayer.__N.CBsePl_GetAbsOrigin;
			return calli(Vector3(System.IntPtr), this.self, cbsePl_GetAbsOrigin);
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00026E74 File Offset: 0x00025074
		internal readonly float GetAbsScale()
		{
			this.NullCheck("GetAbsScale");
			method cbsePl_GetAbsScale = C_BasePlayer.__N.CBsePl_GetAbsScale;
			return calli(System.Single(System.IntPtr), this.self, cbsePl_GetAbsScale);
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00026EA0 File Offset: 0x000250A0
		internal readonly void SetAbsScale(float flScale)
		{
			this.NullCheck("SetAbsScale");
			method cbsePl_SetAbsScale = C_BasePlayer.__N.CBsePl_SetAbsScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbsePl_SetAbsScale);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00026ECC File Offset: 0x000250CC
		internal readonly float GetLocalScale()
		{
			this.NullCheck("GetLocalScale");
			method cbsePl_GetLocalScale = C_BasePlayer.__N.CBsePl_GetLocalScale;
			return calli(System.Single(System.IntPtr), this.self, cbsePl_GetLocalScale);
		}

		// Token: 0x0600030D RID: 781 RVA: 0x00026EF8 File Offset: 0x000250F8
		internal readonly void SetLocalScale(float flScale)
		{
			this.NullCheck("SetLocalScale");
			method cbsePl_SetLocalScale = C_BasePlayer.__N.CBsePl_SetLocalScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, flScale, cbsePl_SetLocalScale);
		}

		// Token: 0x0600030E RID: 782 RVA: 0x00026F24 File Offset: 0x00025124
		internal unsafe readonly void SetAbsVelocity(Vector3 origin)
		{
			this.NullCheck("SetAbsVelocity");
			method cbsePl_SetAbsVelocity = C_BasePlayer.__N.CBsePl_SetAbsVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &origin, cbsePl_SetAbsVelocity);
		}

		// Token: 0x0600030F RID: 783 RVA: 0x00026F54 File Offset: 0x00025154
		internal readonly Vector3 GetAbsVelocity()
		{
			this.NullCheck("GetAbsVelocity");
			method cbsePl_GetAbsVelocity = C_BasePlayer.__N.CBsePl_GetAbsVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbsePl_GetAbsVelocity);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x00026F80 File Offset: 0x00025180
		internal readonly void AddFlag(int flags)
		{
			this.NullCheck("AddFlag");
			method cbsePl_AddFlag = C_BasePlayer.__N.CBsePl_AddFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flags, cbsePl_AddFlag);
		}

		// Token: 0x06000311 RID: 785 RVA: 0x00026FAC File Offset: 0x000251AC
		internal readonly void RemoveFlag(int flagsToRemove)
		{
			this.NullCheck("RemoveFlag");
			method cbsePl_RemoveFlag = C_BasePlayer.__N.CBsePl_RemoveFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagsToRemove, cbsePl_RemoveFlag);
		}

		// Token: 0x06000312 RID: 786 RVA: 0x00026FD8 File Offset: 0x000251D8
		internal readonly void ToggleFlag(int flagToToggle)
		{
			this.NullCheck("ToggleFlag");
			method cbsePl_ToggleFlag = C_BasePlayer.__N.CBsePl_ToggleFlag;
			calli(System.Void(System.IntPtr,System.Int32), this.self, flagToToggle, cbsePl_ToggleFlag);
		}

		// Token: 0x06000313 RID: 787 RVA: 0x00027004 File Offset: 0x00025204
		internal readonly void ClearFlags()
		{
			this.NullCheck("ClearFlags");
			method cbsePl_ClearFlags = C_BasePlayer.__N.CBsePl_ClearFlags;
			calli(System.Void(System.IntPtr), this.self, cbsePl_ClearFlags);
		}

		// Token: 0x06000314 RID: 788 RVA: 0x00027030 File Offset: 0x00025230
		internal readonly int GetFlags()
		{
			this.NullCheck("GetFlags");
			method cbsePl_GetFlags = C_BasePlayer.__N.CBsePl_GetFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetFlags);
		}

		// Token: 0x06000315 RID: 789 RVA: 0x0002705C File Offset: 0x0002525C
		internal readonly void SetLifeState(LifeState state)
		{
			this.NullCheck("SetLifeState");
			method cbsePl_SetLifeState = C_BasePlayer.__N.CBsePl_SetLifeState;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)state, cbsePl_SetLifeState);
		}

		// Token: 0x06000316 RID: 790 RVA: 0x00027088 File Offset: 0x00025288
		internal readonly LifeState GetLifeState()
		{
			this.NullCheck("GetLifeState");
			method cbsePl_GetLifeState = C_BasePlayer.__N.CBsePl_GetLifeState;
			return calli(System.Int64(System.IntPtr), this.self, cbsePl_GetLifeState);
		}

		// Token: 0x06000317 RID: 791 RVA: 0x000270B4 File Offset: 0x000252B4
		internal readonly int GetEffects()
		{
			this.NullCheck("GetEffects");
			method cbsePl_GetEffects = C_BasePlayer.__N.CBsePl_GetEffects;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetEffects);
		}

		// Token: 0x06000318 RID: 792 RVA: 0x000270E0 File Offset: 0x000252E0
		internal readonly void AddEffects(int nEffects)
		{
			this.NullCheck("AddEffects");
			method cbsePl_AddEffects = C_BasePlayer.__N.CBsePl_AddEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbsePl_AddEffects);
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0002710C File Offset: 0x0002530C
		internal readonly void RemoveEffects(int nEffects)
		{
			this.NullCheck("RemoveEffects");
			method cbsePl_RemoveEffects = C_BasePlayer.__N.CBsePl_RemoveEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbsePl_RemoveEffects);
		}

		// Token: 0x0600031A RID: 794 RVA: 0x00027138 File Offset: 0x00025338
		internal readonly void ClearEffects()
		{
			this.NullCheck("ClearEffects");
			method cbsePl_ClearEffects = C_BasePlayer.__N.CBsePl_ClearEffects;
			calli(System.Void(System.IntPtr), this.self, cbsePl_ClearEffects);
		}

		// Token: 0x0600031B RID: 795 RVA: 0x00027164 File Offset: 0x00025364
		internal readonly void SetEffects(int nEffects)
		{
			this.NullCheck("SetEffects");
			method cbsePl_SetEffects = C_BasePlayer.__N.CBsePl_SetEffects;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nEffects, cbsePl_SetEffects);
		}

		// Token: 0x0600031C RID: 796 RVA: 0x00027190 File Offset: 0x00025390
		internal readonly bool IsEffectActive(int nEffectMask)
		{
			this.NullCheck("IsEffectActive");
			method cbsePl_IsEffectActive = C_BasePlayer.__N.CBsePl_IsEffectActive;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nEffectMask, cbsePl_IsEffectActive) > 0;
		}

		// Token: 0x0600031D RID: 797 RVA: 0x000271C0 File Offset: 0x000253C0
		internal readonly void CreateVPhysics()
		{
			this.NullCheck("CreateVPhysics");
			method cbsePl_CreateVPhysics = C_BasePlayer.__N.CBsePl_CreateVPhysics;
			calli(System.Void(System.IntPtr), this.self, cbsePl_CreateVPhysics);
		}

		// Token: 0x0600031E RID: 798 RVA: 0x000271EC File Offset: 0x000253EC
		internal unsafe readonly void ApplyAbsVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyAbsVelocityImpulse");
			method cbsePl_ApplyAbsVelocityImpulse = C_BasePlayer.__N.CBsePl_ApplyAbsVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbsePl_ApplyAbsVelocityImpulse);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0002721C File Offset: 0x0002541C
		internal unsafe readonly void ApplyLocalVelocityImpulse(Vector3 vecImpulse)
		{
			this.NullCheck("ApplyLocalVelocityImpulse");
			method cbsePl_ApplyLocalVelocityImpulse = C_BasePlayer.__N.CBsePl_ApplyLocalVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecImpulse, cbsePl_ApplyLocalVelocityImpulse);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0002724C File Offset: 0x0002544C
		internal unsafe readonly void ApplyLocalAngularVelocityImpulse(Vector3 angImpulse)
		{
			this.NullCheck("ApplyLocalAngularVelocityImpulse");
			method cbsePl_ApplyLocalAngularVelocityImpulse = C_BasePlayer.__N.CBsePl_ApplyLocalAngularVelocityImpulse;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &angImpulse, cbsePl_ApplyLocalAngularVelocityImpulse);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0002727C File Offset: 0x0002547C
		internal readonly void SetMoveType(MoveType val, MoveCollide moveCollide)
		{
			this.NullCheck("SetMoveType");
			method cbsePl_SetMoveType = C_BasePlayer.__N.CBsePl_SetMoveType;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (ulong)val, (ulong)moveCollide, cbsePl_SetMoveType);
		}

		// Token: 0x06000322 RID: 802 RVA: 0x000272AC File Offset: 0x000254AC
		internal readonly MoveType GetMoveType()
		{
			this.NullCheck("GetMoveType");
			method cbsePl_GetMoveType = C_BasePlayer.__N.CBsePl_GetMoveType;
			return calli(System.Int64(System.IntPtr), this.self, cbsePl_GetMoveType);
		}

		// Token: 0x06000323 RID: 803 RVA: 0x000272D8 File Offset: 0x000254D8
		internal readonly void PhysicsEnableMotion(bool bEnable)
		{
			this.NullCheck("PhysicsEnableMotion");
			method cbsePl_PhysicsEnableMotion = C_BasePlayer.__N.CBsePl_PhysicsEnableMotion;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnable ? 1 : 0, cbsePl_PhysicsEnableMotion);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0002730C File Offset: 0x0002550C
		internal readonly void FollowEntity(IntPtr pBaseEntity, bool bBoneMerge)
		{
			this.NullCheck("FollowEntity");
			method cbsePl_FollowEntity = C_BasePlayer.__N.CBsePl_FollowEntity;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, pBaseEntity, bBoneMerge ? 1 : 0, cbsePl_FollowEntity);
		}

		// Token: 0x06000325 RID: 805 RVA: 0x00027340 File Offset: 0x00025540
		internal readonly void StopFollowingEntity()
		{
			this.NullCheck("StopFollowingEntity");
			method cbsePl_StopFollowingEntity = C_BasePlayer.__N.CBsePl_StopFollowingEntity;
			calli(System.Void(System.IntPtr), this.self, cbsePl_StopFollowingEntity);
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0002736C File Offset: 0x0002556C
		internal readonly bool IsFollowingEntity()
		{
			this.NullCheck("IsFollowingEntity");
			method cbsePl_IsFollowingEntity = C_BasePlayer.__N.CBsePl_IsFollowingEntity;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsFollowingEntity) > 0;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0002739C File Offset: 0x0002559C
		internal readonly C_BaseEntity GetFollowedEntity()
		{
			this.NullCheck("GetFollowedEntity");
			method cbsePl_GetFollowedEntity = C_BasePlayer.__N.CBsePl_GetFollowedEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetFollowedEntity);
		}

		// Token: 0x06000328 RID: 808 RVA: 0x000273CC File Offset: 0x000255CC
		internal readonly PhysicsGroup VPhysicsGetAggregate()
		{
			this.NullCheck("VPhysicsGetAggregate");
			method cbsePl_VPhysicsGetAggregate = C_BasePlayer.__N.CBsePl_VPhysicsGetAggregate;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr), this.self, cbsePl_VPhysicsGetAggregate));
		}

		// Token: 0x06000329 RID: 809 RVA: 0x000273FC File Offset: 0x000255FC
		internal readonly Vector3 GetBaseVelocity()
		{
			this.NullCheck("GetBaseVelocity");
			method cbsePl_GetBaseVelocity = C_BasePlayer.__N.CBsePl_GetBaseVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbsePl_GetBaseVelocity);
		}

		// Token: 0x0600032A RID: 810 RVA: 0x00027428 File Offset: 0x00025628
		internal unsafe readonly void SetBaseVelocity(Vector3 v)
		{
			this.NullCheck("SetBaseVelocity");
			method cbsePl_SetBaseVelocity = C_BasePlayer.__N.CBsePl_SetBaseVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &v, cbsePl_SetBaseVelocity);
		}

		// Token: 0x0600032B RID: 811 RVA: 0x00027458 File Offset: 0x00025658
		internal readonly void SetGroundEntity(C_BaseEntity ground)
		{
			this.NullCheck("SetGroundEntity");
			method cbsePl_SetGroundEntity = C_BasePlayer.__N.CBsePl_SetGroundEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ground, cbsePl_SetGroundEntity);
		}

		// Token: 0x0600032C RID: 812 RVA: 0x00027488 File Offset: 0x00025688
		internal readonly C_BaseEntity GetGroundEntity()
		{
			this.NullCheck("GetGroundEntity");
			method cbsePl_GetGroundEntity = C_BasePlayer.__N.CBsePl_GetGroundEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetGroundEntity);
		}

		// Token: 0x0600032D RID: 813 RVA: 0x000274B8 File Offset: 0x000256B8
		internal readonly string GetModelNameString()
		{
			this.NullCheck("GetModelNameString");
			method cbsePl_GetModelNameString = C_BasePlayer.__N.CBsePl_GetModelNameString;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetModelNameString));
		}

		// Token: 0x0600032E RID: 814 RVA: 0x000274E8 File Offset: 0x000256E8
		internal unsafe readonly void SetParent(C_BaseEntity parent, string nBoneOrAttachName, Transform pOffsetTransform)
		{
			this.NullCheck("SetParent");
			method cbsePl_SetParent = C_BasePlayer.__N.CBsePl_SetParent;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32,Transform*), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), &pOffsetTransform, cbsePl_SetParent);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x00027524 File Offset: 0x00025724
		internal readonly void SetParent(C_BaseEntity parent, string nBoneOrAttachName)
		{
			this.NullCheck("SetParent");
			method cbsePl_f = C_BasePlayer.__N.CBsePl_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32), this.self, parent, StringToken.FindOrCreate(nBoneOrAttachName), cbsePl_f);
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0002755C File Offset: 0x0002575C
		internal readonly C_BaseEntity GetParent()
		{
			this.NullCheck("GetParent");
			method cbsePl_GetParent = C_BasePlayer.__N.CBsePl_GetParent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetParent);
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0002758C File Offset: 0x0002578C
		internal readonly void ResetLatched()
		{
			this.NullCheck("ResetLatched");
			method cbsePl_ResetLatched = C_BasePlayer.__N.CBsePl_ResetLatched;
			calli(System.Void(System.IntPtr), this.self, cbsePl_ResetLatched);
		}

		// Token: 0x06000332 RID: 818 RVA: 0x000275B8 File Offset: 0x000257B8
		internal readonly void SetActiveChild(C_BaseEntity child)
		{
			this.NullCheck("SetActiveChild");
			method cbsePl_SetActiveChild = C_BasePlayer.__N.CBsePl_SetActiveChild;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbsePl_SetActiveChild);
		}

		// Token: 0x06000333 RID: 819 RVA: 0x000275E8 File Offset: 0x000257E8
		internal readonly C_BaseEntity GetActiveChild()
		{
			this.NullCheck("GetActiveChild");
			method cbsePl_GetActiveChild = C_BasePlayer.__N.CBsePl_GetActiveChild;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetActiveChild);
		}

		// Token: 0x06000334 RID: 820 RVA: 0x00027618 File Offset: 0x00025818
		internal readonly void SetOwnerEntity(C_BaseEntity child)
		{
			this.NullCheck("SetOwnerEntity");
			method cbsePl_SetOwnerEntity = C_BasePlayer.__N.CBsePl_SetOwnerEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, child, cbsePl_SetOwnerEntity);
		}

		// Token: 0x06000335 RID: 821 RVA: 0x00027648 File Offset: 0x00025848
		internal readonly C_BaseEntity GetOwnerEntity()
		{
			this.NullCheck("GetOwnerEntity");
			method cbsePl_GetOwnerEntity = C_BasePlayer.__N.CBsePl_GetOwnerEntity;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetOwnerEntity);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x00027678 File Offset: 0x00025878
		internal readonly void EnableSceneObjectOverride(bool bEnableOverride)
		{
			this.NullCheck("EnableSceneObjectOverride");
			method cbsePl_EnableSceneObjectOverride = C_BasePlayer.__N.CBsePl_EnableSceneObjectOverride;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bEnableOverride ? 1 : 0, cbsePl_EnableSceneObjectOverride);
		}

		// Token: 0x06000337 RID: 823 RVA: 0x000276AC File Offset: 0x000258AC
		internal readonly void SetSimulationTime(float time)
		{
			this.NullCheck("SetSimulationTime");
			method cbsePl_SetSimulationTime = C_BasePlayer.__N.CBsePl_SetSimulationTime;
			calli(System.Void(System.IntPtr,System.Single), this.self, time, cbsePl_SetSimulationTime);
		}

		// Token: 0x06000338 RID: 824 RVA: 0x000276D8 File Offset: 0x000258D8
		internal readonly bool HasSpawnFlags(int nFlags)
		{
			this.NullCheck("HasSpawnFlags");
			method cbsePl_HasSpawnFlags = C_BasePlayer.__N.CBsePl_HasSpawnFlags;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, nFlags, cbsePl_HasSpawnFlags) > 0;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x00027708 File Offset: 0x00025908
		internal readonly int GetSpawnFlags()
		{
			this.NullCheck("GetSpawnFlags");
			method cbsePl_GetSpawnFlags = C_BasePlayer.__N.CBsePl_GetSpawnFlags;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetSpawnFlags);
		}

		// Token: 0x0600033A RID: 826 RVA: 0x00027734 File Offset: 0x00025934
		internal readonly void AddSpawnFlags(int nFlags)
		{
			this.NullCheck("AddSpawnFlags");
			method cbsePl_AddSpawnFlags = C_BasePlayer.__N.CBsePl_AddSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbsePl_AddSpawnFlags);
		}

		// Token: 0x0600033B RID: 827 RVA: 0x00027760 File Offset: 0x00025960
		internal readonly void RemoveSpawnFlags(int nFlags)
		{
			this.NullCheck("RemoveSpawnFlags");
			method cbsePl_RemoveSpawnFlags = C_BasePlayer.__N.CBsePl_RemoveSpawnFlags;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFlags, cbsePl_RemoveSpawnFlags);
		}

		// Token: 0x0600033C RID: 828 RVA: 0x0002778C File Offset: 0x0002598C
		internal readonly void ClearSpawnFlags()
		{
			this.NullCheck("ClearSpawnFlags");
			method cbsePl_ClearSpawnFlags = C_BasePlayer.__N.CBsePl_ClearSpawnFlags;
			calli(System.Void(System.IntPtr), this.self, cbsePl_ClearSpawnFlags);
		}

		// Token: 0x0600033D RID: 829 RVA: 0x000277B8 File Offset: 0x000259B8
		internal readonly CLightComponent GetLightComponent()
		{
			this.NullCheck("GetLightComponent");
			method cbsePl_GetLightComponent = C_BasePlayer.__N.CBsePl_GetLightComponent;
			return calli(System.IntPtr(System.IntPtr), this.self, cbsePl_GetLightComponent);
		}

		// Token: 0x0600033E RID: 830 RVA: 0x000277E8 File Offset: 0x000259E8
		internal unsafe readonly void SetLocalVelocity(Vector3 vecVelocity)
		{
			this.NullCheck("SetLocalVelocity");
			method cbsePl_SetLocalVelocity = C_BasePlayer.__N.CBsePl_SetLocalVelocity;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &vecVelocity, cbsePl_SetLocalVelocity);
		}

		// Token: 0x0600033F RID: 831 RVA: 0x00027818 File Offset: 0x00025A18
		internal readonly Vector3 GetLocalVelocity()
		{
			this.NullCheck("GetLocalVelocity");
			method cbsePl_GetLocalVelocity = C_BasePlayer.__N.CBsePl_GetLocalVelocity;
			return calli(Vector3(System.IntPtr), this.self, cbsePl_GetLocalVelocity);
		}

		// Token: 0x06000340 RID: 832 RVA: 0x00027844 File Offset: 0x00025A44
		internal unsafe readonly void SetLocalAngularVelocity(Angles vecAngVelocity)
		{
			this.NullCheck("SetLocalAngularVelocity");
			method cbsePl_SetLocalAngularVelocity = C_BasePlayer.__N.CBsePl_SetLocalAngularVelocity;
			calli(System.Void(System.IntPtr,Angles*), this.self, &vecAngVelocity, cbsePl_SetLocalAngularVelocity);
		}

		// Token: 0x06000341 RID: 833 RVA: 0x00027874 File Offset: 0x00025A74
		internal readonly Angles GetLocalAngularVelocity()
		{
			this.NullCheck("GetLocalAngularVelocity");
			method cbsePl_GetLocalAngularVelocity = C_BasePlayer.__N.CBsePl_GetLocalAngularVelocity;
			return calli(Angles(System.IntPtr), this.self, cbsePl_GetLocalAngularVelocity);
		}

		// Token: 0x06000342 RID: 834 RVA: 0x000278A0 File Offset: 0x00025AA0
		internal readonly void SetDebugBits(ulong nBitMask)
		{
			this.NullCheck("SetDebugBits");
			method cbsePl_SetDebugBits = C_BasePlayer.__N.CBsePl_SetDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbsePl_SetDebugBits);
		}

		// Token: 0x06000343 RID: 835 RVA: 0x000278CC File Offset: 0x00025ACC
		internal readonly bool HasDebugBitsSet(ulong nBitMask)
		{
			this.NullCheck("HasDebugBitsSet");
			method cbsePl_HasDebugBitsSet = C_BasePlayer.__N.CBsePl_HasDebugBitsSet;
			return calli(System.Int32(System.IntPtr,System.UInt64), this.self, nBitMask, cbsePl_HasDebugBitsSet) > 0;
		}

		// Token: 0x06000344 RID: 836 RVA: 0x000278FC File Offset: 0x00025AFC
		internal readonly void ClearDebugBits(ulong nBitMask)
		{
			this.NullCheck("ClearDebugBits");
			method cbsePl_ClearDebugBits = C_BasePlayer.__N.CBsePl_ClearDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbsePl_ClearDebugBits);
		}

		// Token: 0x06000345 RID: 837 RVA: 0x00027928 File Offset: 0x00025B28
		internal readonly void ToggleDebugBits(ulong nBitMask)
		{
			this.NullCheck("ToggleDebugBits");
			method cbsePl_ToggleDebugBits = C_BasePlayer.__N.CBsePl_ToggleDebugBits;
			calli(System.Void(System.IntPtr,System.UInt64), this.self, nBitMask, cbsePl_ToggleDebugBits);
		}

		// Token: 0x06000346 RID: 838 RVA: 0x00027954 File Offset: 0x00025B54
		internal readonly ulong GetDebugBits()
		{
			this.NullCheck("GetDebugBits");
			method cbsePl_GetDebugBits = C_BasePlayer.__N.CBsePl_GetDebugBits;
			return calli(System.UInt64(System.IntPtr), this.self, cbsePl_GetDebugBits);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x00027980 File Offset: 0x00025B80
		internal readonly void MarkRenderHandleDirty()
		{
			this.NullCheck("MarkRenderHandleDirty");
			method cbsePl_MarkRenderHandleDirty = C_BasePlayer.__N.CBsePl_MarkRenderHandleDirty;
			calli(System.Void(System.IntPtr), this.self, cbsePl_MarkRenderHandleDirty);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x000279AC File Offset: 0x00025BAC
		internal readonly void SetWaterEntity(C_BaseEntity ent)
		{
			this.NullCheck("SetWaterEntity");
			method cbsePl_SetWaterEntity = C_BasePlayer.__N.CBsePl_SetWaterEntity;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, ent, cbsePl_SetWaterEntity);
		}

		// Token: 0x06000349 RID: 841 RVA: 0x000279DC File Offset: 0x00025BDC
		internal readonly Entity GetWaterEntity()
		{
			this.NullCheck("GetWaterEntity");
			method cbsePl_GetWaterEntity = C_BasePlayer.__N.CBsePl_GetWaterEntity;
			return InteropSystem.Get<Entity>(calli(System.UInt32(System.IntPtr), this.self, cbsePl_GetWaterEntity));
		}

		// Token: 0x0600034A RID: 842 RVA: 0x00027A0C File Offset: 0x00025C0C
		internal readonly void WorldSpaceAABB(out Vector3 mins, out Vector3 maxs)
		{
			this.NullCheck("WorldSpaceAABB");
			method cbsePl_WorldSpaceAABB = C_BasePlayer.__N.CBsePl_WorldSpaceAABB;
			calli(System.Void(System.IntPtr,Vector3& modreq(System.Runtime.InteropServices.OutAttribute),Vector3& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, ref mins, ref maxs, cbsePl_WorldSpaceAABB);
		}

		// Token: 0x0600034B RID: 843 RVA: 0x00027A38 File Offset: 0x00025C38
		internal readonly void RemoveAllDecals()
		{
			this.NullCheck("RemoveAllDecals");
			method cbsePl_RemoveAllDecals = C_BasePlayer.__N.CBsePl_RemoveAllDecals;
			calli(System.Void(System.IntPtr), this.self, cbsePl_RemoveAllDecals);
		}

		// Token: 0x0600034C RID: 844 RVA: 0x00027A64 File Offset: 0x00025C64
		internal readonly bool GetPredictable()
		{
			this.NullCheck("GetPredictable");
			method cbsePl_GetPredictable = C_BasePlayer.__N.CBsePl_GetPredictable;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_GetPredictable) > 0;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x00027A94 File Offset: 0x00025C94
		internal readonly string SB_GetEntityName()
		{
			this.NullCheck("SB_GetEntityName");
			method cbsePl_SB_GetEntityName = C_BasePlayer.__N.CBsePl_SB_GetEntityName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cbsePl_SB_GetEntityName));
		}

		// Token: 0x0600034E RID: 846 RVA: 0x00027AC4 File Offset: 0x00025CC4
		internal readonly void SB_SetEntityName(string name)
		{
			this.NullCheck("SB_SetEntityName");
			method cbsePl_SB_SetEntityName = C_BasePlayer.__N.CBsePl_SB_SetEntityName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(name), cbsePl_SB_SetEntityName);
		}

		// Token: 0x0600034F RID: 847 RVA: 0x00027AF4 File Offset: 0x00025CF4
		internal readonly IntPtr GetData(int index, bool local, out int size)
		{
			this.NullCheck("GetData");
			method cbsePl_GetData = C_BasePlayer.__N.CBsePl_GetData;
			return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32,System.Int32& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, index, local ? 1 : 0, ref size, cbsePl_GetData);
		}

		// Token: 0x06000350 RID: 848 RVA: 0x00027B28 File Offset: 0x00025D28
		internal readonly bool IsServerOnly()
		{
			this.NullCheck("IsServerOnly");
			method cbsePl_IsServerOnly = C_BasePlayer.__N.CBsePl_IsServerOnly;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsServerOnly) > 0;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x00027B58 File Offset: 0x00025D58
		internal readonly bool IsClientOnly()
		{
			this.NullCheck("IsClientOnly");
			method cbsePl_IsClientOnly = C_BasePlayer.__N.CBsePl_IsClientOnly;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsClientOnly) > 0;
		}

		// Token: 0x06000352 RID: 850 RVA: 0x00027B88 File Offset: 0x00025D88
		internal readonly bool IsClientServerNetworked()
		{
			this.NullCheck("IsClientServerNetworked");
			method cbsePl_IsClientServerNetworked = C_BasePlayer.__N.CBsePl_IsClientServerNetworked;
			return calli(System.Int32(System.IntPtr), this.self, cbsePl_IsClientServerNetworked) > 0;
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000353 RID: 851 RVA: 0x00027BB5 File Offset: 0x00025DB5
		// (set) Token: 0x06000354 RID: 852 RVA: 0x00027BD2 File Offset: 0x00025DD2
		internal float m_flMaxspeed
		{
			get
			{
				this.NullCheck("m_flMaxspeed");
				return C_BasePlayer.__N.Get__CBsePl_m_flMaxspeed(this.self);
			}
			set
			{
				this.NullCheck("m_flMaxspeed");
				C_BasePlayer.__N.Set__CBsePl_m_flMaxspeed(this.self, value);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000355 RID: 853 RVA: 0x00027BF0 File Offset: 0x00025DF0
		// (set) Token: 0x06000356 RID: 854 RVA: 0x00027C12 File Offset: 0x00025E12
		internal C_BaseEntity m_Pawn
		{
			get
			{
				this.NullCheck("m_Pawn");
				return C_BasePlayer.__N.Get__CBsePl_m_Pawn(this.self);
			}
			set
			{
				this.NullCheck("m_Pawn");
				C_BasePlayer.__N.Set__CBsePl_m_Pawn(this.self, value);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000357 RID: 855 RVA: 0x00027C35 File Offset: 0x00025E35
		// (set) Token: 0x06000358 RID: 856 RVA: 0x00027C52 File Offset: 0x00025E52
		internal int m_Ping
		{
			get
			{
				this.NullCheck("m_Ping");
				return C_BasePlayer.__N.Get__CBsePl_m_Ping(this.self);
			}
			set
			{
				this.NullCheck("m_Ping");
				C_BasePlayer.__N.Set__CBsePl_m_Ping(this.self, value);
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x06000359 RID: 857 RVA: 0x00027C70 File Offset: 0x00025E70
		// (set) Token: 0x0600035A RID: 858 RVA: 0x00027C8D File Offset: 0x00025E8D
		internal int m_PacketLoss
		{
			get
			{
				this.NullCheck("m_PacketLoss");
				return C_BasePlayer.__N.Get__CBsePl_m_PacketLoss(this.self);
			}
			set
			{
				this.NullCheck("m_PacketLoss");
				C_BasePlayer.__N.Set__CBsePl_m_PacketLoss(this.self, value);
			}
		}

		// Token: 0x0400009F RID: 159
		internal IntPtr self;

		// Token: 0x020001A2 RID: 418
		internal static class __N
		{
			// Token: 0x04000941 RID: 2369
			internal static method From_C_BaseEntity_To_C_BasePlayer;

			// Token: 0x04000942 RID: 2370
			internal static method To_C_BaseEntity_From_C_BasePlayer;

			// Token: 0x04000943 RID: 2371
			internal static method From_CGameEntity_To_C_BasePlayer;

			// Token: 0x04000944 RID: 2372
			internal static method To_CGameEntity_From_C_BasePlayer;

			// Token: 0x04000945 RID: 2373
			internal static method From_CEntityInstance_To_C_BasePlayer;

			// Token: 0x04000946 RID: 2374
			internal static method To_CEntityInstance_From_C_BasePlayer;

			// Token: 0x04000947 RID: 2375
			internal static method From_IHandleEntity_To_C_BasePlayer;

			// Token: 0x04000948 RID: 2376
			internal static method To_IHandleEntity_From_C_BasePlayer;

			// Token: 0x04000949 RID: 2377
			internal static method CBsePl_GetPlayerName;

			// Token: 0x0400094A RID: 2378
			internal static method CBsePl_GetUserID;

			// Token: 0x0400094B RID: 2379
			internal static method CBsePl_IsLocalPlayer;

			// Token: 0x0400094C RID: 2380
			internal static method CBsePl_UpdateButtonState;

			// Token: 0x0400094D RID: 2381
			internal static method CBsePl_SetPreviouslyPredictedOrigin;

			// Token: 0x0400094E RID: 2382
			internal static method CBsePl_GetSteamIDAsUInt64;

			// Token: 0x0400094F RID: 2383
			internal static method CBsePl_InitializeEntityObject;

			// Token: 0x04000950 RID: 2384
			internal static method CBsePl_GetDataTable;

			// Token: 0x04000951 RID: 2385
			internal static method CBsePl_GetEntityHandle;

			// Token: 0x04000952 RID: 2386
			internal static method CBsePl_GetClassname;

			// Token: 0x04000953 RID: 2387
			internal static method CBsePl_GetDebugName;

			// Token: 0x04000954 RID: 2388
			internal static method CBsePl_entindex;

			// Token: 0x04000955 RID: 2389
			internal static method CBsePl_SetLocalOrigin;

			// Token: 0x04000956 RID: 2390
			internal static method CBsePl_GetLocalOrigin;

			// Token: 0x04000957 RID: 2391
			internal static method CBsePl_GetLocalQuat;

			// Token: 0x04000958 RID: 2392
			internal static method CBsePl_SetLocalQuat;

			// Token: 0x04000959 RID: 2393
			internal static method CBsePl_GetAbsQuat;

			// Token: 0x0400095A RID: 2394
			internal static method CBsePl_SetAbsQuat;

			// Token: 0x0400095B RID: 2395
			internal static method CBsePl_SetAbsOrigin;

			// Token: 0x0400095C RID: 2396
			internal static method CBsePl_GetAbsOrigin;

			// Token: 0x0400095D RID: 2397
			internal static method CBsePl_GetAbsScale;

			// Token: 0x0400095E RID: 2398
			internal static method CBsePl_SetAbsScale;

			// Token: 0x0400095F RID: 2399
			internal static method CBsePl_GetLocalScale;

			// Token: 0x04000960 RID: 2400
			internal static method CBsePl_SetLocalScale;

			// Token: 0x04000961 RID: 2401
			internal static method CBsePl_SetAbsVelocity;

			// Token: 0x04000962 RID: 2402
			internal static method CBsePl_GetAbsVelocity;

			// Token: 0x04000963 RID: 2403
			internal static method CBsePl_AddFlag;

			// Token: 0x04000964 RID: 2404
			internal static method CBsePl_RemoveFlag;

			// Token: 0x04000965 RID: 2405
			internal static method CBsePl_ToggleFlag;

			// Token: 0x04000966 RID: 2406
			internal static method CBsePl_ClearFlags;

			// Token: 0x04000967 RID: 2407
			internal static method CBsePl_GetFlags;

			// Token: 0x04000968 RID: 2408
			internal static method CBsePl_SetLifeState;

			// Token: 0x04000969 RID: 2409
			internal static method CBsePl_GetLifeState;

			// Token: 0x0400096A RID: 2410
			internal static method CBsePl_GetEffects;

			// Token: 0x0400096B RID: 2411
			internal static method CBsePl_AddEffects;

			// Token: 0x0400096C RID: 2412
			internal static method CBsePl_RemoveEffects;

			// Token: 0x0400096D RID: 2413
			internal static method CBsePl_ClearEffects;

			// Token: 0x0400096E RID: 2414
			internal static method CBsePl_SetEffects;

			// Token: 0x0400096F RID: 2415
			internal static method CBsePl_IsEffectActive;

			// Token: 0x04000970 RID: 2416
			internal static method CBsePl_CreateVPhysics;

			// Token: 0x04000971 RID: 2417
			internal static method CBsePl_ApplyAbsVelocityImpulse;

			// Token: 0x04000972 RID: 2418
			internal static method CBsePl_ApplyLocalVelocityImpulse;

			// Token: 0x04000973 RID: 2419
			internal static method CBsePl_ApplyLocalAngularVelocityImpulse;

			// Token: 0x04000974 RID: 2420
			internal static method CBsePl_SetMoveType;

			// Token: 0x04000975 RID: 2421
			internal static method CBsePl_GetMoveType;

			// Token: 0x04000976 RID: 2422
			internal static method CBsePl_PhysicsEnableMotion;

			// Token: 0x04000977 RID: 2423
			internal static method CBsePl_FollowEntity;

			// Token: 0x04000978 RID: 2424
			internal static method CBsePl_StopFollowingEntity;

			// Token: 0x04000979 RID: 2425
			internal static method CBsePl_IsFollowingEntity;

			// Token: 0x0400097A RID: 2426
			internal static method CBsePl_GetFollowedEntity;

			// Token: 0x0400097B RID: 2427
			internal static method CBsePl_VPhysicsGetAggregate;

			// Token: 0x0400097C RID: 2428
			internal static method CBsePl_GetBaseVelocity;

			// Token: 0x0400097D RID: 2429
			internal static method CBsePl_SetBaseVelocity;

			// Token: 0x0400097E RID: 2430
			internal static method CBsePl_SetGroundEntity;

			// Token: 0x0400097F RID: 2431
			internal static method CBsePl_GetGroundEntity;

			// Token: 0x04000980 RID: 2432
			internal static method CBsePl_GetModelNameString;

			// Token: 0x04000981 RID: 2433
			internal static method CBsePl_SetParent;

			// Token: 0x04000982 RID: 2434
			internal static method CBsePl_f2;

			// Token: 0x04000983 RID: 2435
			internal static method CBsePl_GetParent;

			// Token: 0x04000984 RID: 2436
			internal static method CBsePl_ResetLatched;

			// Token: 0x04000985 RID: 2437
			internal static method CBsePl_SetActiveChild;

			// Token: 0x04000986 RID: 2438
			internal static method CBsePl_GetActiveChild;

			// Token: 0x04000987 RID: 2439
			internal static method CBsePl_SetOwnerEntity;

			// Token: 0x04000988 RID: 2440
			internal static method CBsePl_GetOwnerEntity;

			// Token: 0x04000989 RID: 2441
			internal static method CBsePl_EnableSceneObjectOverride;

			// Token: 0x0400098A RID: 2442
			internal static method CBsePl_SetSimulationTime;

			// Token: 0x0400098B RID: 2443
			internal static method CBsePl_HasSpawnFlags;

			// Token: 0x0400098C RID: 2444
			internal static method CBsePl_GetSpawnFlags;

			// Token: 0x0400098D RID: 2445
			internal static method CBsePl_AddSpawnFlags;

			// Token: 0x0400098E RID: 2446
			internal static method CBsePl_RemoveSpawnFlags;

			// Token: 0x0400098F RID: 2447
			internal static method CBsePl_ClearSpawnFlags;

			// Token: 0x04000990 RID: 2448
			internal static method CBsePl_GetLightComponent;

			// Token: 0x04000991 RID: 2449
			internal static method CBsePl_SetLocalVelocity;

			// Token: 0x04000992 RID: 2450
			internal static method CBsePl_GetLocalVelocity;

			// Token: 0x04000993 RID: 2451
			internal static method CBsePl_SetLocalAngularVelocity;

			// Token: 0x04000994 RID: 2452
			internal static method CBsePl_GetLocalAngularVelocity;

			// Token: 0x04000995 RID: 2453
			internal static method CBsePl_SetDebugBits;

			// Token: 0x04000996 RID: 2454
			internal static method CBsePl_HasDebugBitsSet;

			// Token: 0x04000997 RID: 2455
			internal static method CBsePl_ClearDebugBits;

			// Token: 0x04000998 RID: 2456
			internal static method CBsePl_ToggleDebugBits;

			// Token: 0x04000999 RID: 2457
			internal static method CBsePl_GetDebugBits;

			// Token: 0x0400099A RID: 2458
			internal static method CBsePl_MarkRenderHandleDirty;

			// Token: 0x0400099B RID: 2459
			internal static method CBsePl_SetWaterEntity;

			// Token: 0x0400099C RID: 2460
			internal static method CBsePl_GetWaterEntity;

			// Token: 0x0400099D RID: 2461
			internal static method CBsePl_WorldSpaceAABB;

			// Token: 0x0400099E RID: 2462
			internal static method CBsePl_RemoveAllDecals;

			// Token: 0x0400099F RID: 2463
			internal static method CBsePl_GetPredictable;

			// Token: 0x040009A0 RID: 2464
			internal static method CBsePl_SB_GetEntityName;

			// Token: 0x040009A1 RID: 2465
			internal static method CBsePl_SB_SetEntityName;

			// Token: 0x040009A2 RID: 2466
			internal static method CBsePl_GetData;

			// Token: 0x040009A3 RID: 2467
			internal static method CBsePl_IsServerOnly;

			// Token: 0x040009A4 RID: 2468
			internal static method CBsePl_IsClientOnly;

			// Token: 0x040009A5 RID: 2469
			internal static method CBsePl_IsClientServerNetworked;

			// Token: 0x040009A6 RID: 2470
			internal static C_BasePlayer.__N._Get__CBsePl_m_flMaxspeed Get__CBsePl_m_flMaxspeed;

			// Token: 0x040009A7 RID: 2471
			internal static C_BasePlayer.__N._Set__CBsePl_m_flMaxspeed Set__CBsePl_m_flMaxspeed;

			// Token: 0x040009A8 RID: 2472
			internal static C_BasePlayer.__N._Get__CBsePl_m_Pawn Get__CBsePl_m_Pawn;

			// Token: 0x040009A9 RID: 2473
			internal static C_BasePlayer.__N._Set__CBsePl_m_Pawn Set__CBsePl_m_Pawn;

			// Token: 0x040009AA RID: 2474
			internal static C_BasePlayer.__N._Get__CBsePl_m_Ping Get__CBsePl_m_Ping;

			// Token: 0x040009AB RID: 2475
			internal static C_BasePlayer.__N._Set__CBsePl_m_Ping Set__CBsePl_m_Ping;

			// Token: 0x040009AC RID: 2476
			internal static C_BasePlayer.__N._Get__CBsePl_m_PacketLoss Get__CBsePl_m_PacketLoss;

			// Token: 0x040009AD RID: 2477
			internal static C_BasePlayer.__N._Set__CBsePl_m_PacketLoss Set__CBsePl_m_PacketLoss;

			// Token: 0x020002CB RID: 715
			// (Invoke) Token: 0x06002028 RID: 8232
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate float _Get__CBsePl_m_flMaxspeed(IntPtr self);

			// Token: 0x020002CC RID: 716
			// (Invoke) Token: 0x0600202C RID: 8236
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBsePl_m_flMaxspeed(IntPtr self, float val);

			// Token: 0x020002CD RID: 717
			// (Invoke) Token: 0x06002030 RID: 8240
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate IntPtr _Get__CBsePl_m_Pawn(IntPtr self);

			// Token: 0x020002CE RID: 718
			// (Invoke) Token: 0x06002034 RID: 8244
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBsePl_m_Pawn(IntPtr self, IntPtr val);

			// Token: 0x020002CF RID: 719
			// (Invoke) Token: 0x06002038 RID: 8248
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__CBsePl_m_Ping(IntPtr self);

			// Token: 0x020002D0 RID: 720
			// (Invoke) Token: 0x0600203C RID: 8252
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBsePl_m_Ping(IntPtr self, int val);

			// Token: 0x020002D1 RID: 721
			// (Invoke) Token: 0x06002040 RID: 8256
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate int _Get__CBsePl_m_PacketLoss(IntPtr self);

			// Token: 0x020002D2 RID: 722
			// (Invoke) Token: 0x06002044 RID: 8260
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CBsePl_m_PacketLoss(IntPtr self, int val);
		}
	}
}
