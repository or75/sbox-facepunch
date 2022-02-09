using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200002B RID: 43
	internal struct CGameEntity
	{
		// Token: 0x0600062C RID: 1580 RVA: 0x0002EEAA File Offset: 0x0002D0AA
		public static implicit operator IntPtr(CGameEntity value)
		{
			return value.self;
		}

		// Token: 0x0600062D RID: 1581 RVA: 0x0002EEB4 File Offset: 0x0002D0B4
		public static implicit operator CGameEntity(IntPtr value)
		{
			return new CGameEntity
			{
				self = value
			};
		}

		// Token: 0x0600062E RID: 1582 RVA: 0x0002EED2 File Offset: 0x0002D0D2
		public static bool operator ==(CGameEntity c1, CGameEntity c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600062F RID: 1583 RVA: 0x0002EEE5 File Offset: 0x0002D0E5
		public static bool operator !=(CGameEntity c1, CGameEntity c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x0002EEF8 File Offset: 0x0002D0F8
		public override bool Equals(object obj)
		{
			if (obj is CGameEntity)
			{
				CGameEntity c = (CGameEntity)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0002EF22 File Offset: 0x0002D122
		internal CGameEntity(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000632 RID: 1586 RVA: 0x0002EF2C File Offset: 0x0002D12C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CGameEntity ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x0002EF68 File Offset: 0x0002D168
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x06000634 RID: 1588 RVA: 0x0002EF7A File Offset: 0x0002D17A
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000635 RID: 1589 RVA: 0x0002EF85 File Offset: 0x0002D185
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000636 RID: 1590 RVA: 0x0002EF98 File Offset: 0x0002D198
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CGameEntity was null when calling " + n);
			}
		}

		// Token: 0x06000637 RID: 1591 RVA: 0x0002EFB3 File Offset: 0x0002D1B3
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000638 RID: 1592 RVA: 0x0002EFC0 File Offset: 0x0002D1C0
		public static implicit operator CEntityInstance(CGameEntity value)
		{
			method to_CEntityInstance_From_CGameEntity = CGameEntity.__N.To_CEntityInstance_From_CGameEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_CEntityInstance_From_CGameEntity);
		}

		// Token: 0x06000639 RID: 1593 RVA: 0x0002EFE4 File Offset: 0x0002D1E4
		public static explicit operator CGameEntity(CEntityInstance value)
		{
			method from_CEntityInstance_To_CGameEntity = CGameEntity.__N.From_CEntityInstance_To_CGameEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_CEntityInstance_To_CGameEntity);
		}

		// Token: 0x0600063A RID: 1594 RVA: 0x0002F008 File Offset: 0x0002D208
		public static implicit operator IHandleEntity(CGameEntity value)
		{
			method to_IHandleEntity_From_CGameEntity = CGameEntity.__N.To_IHandleEntity_From_CGameEntity;
			return calli(System.IntPtr(System.IntPtr), value, to_IHandleEntity_From_CGameEntity);
		}

		// Token: 0x0600063B RID: 1595 RVA: 0x0002F02C File Offset: 0x0002D22C
		public static explicit operator CGameEntity(IHandleEntity value)
		{
			method from_IHandleEntity_To_CGameEntity = CGameEntity.__N.From_IHandleEntity_To_CGameEntity;
			return calli(System.IntPtr(System.IntPtr), value, from_IHandleEntity_To_CGameEntity);
		}

		// Token: 0x0600063C RID: 1596 RVA: 0x0002F050 File Offset: 0x0002D250
		internal readonly bool IsServerOnly()
		{
			this.NullCheck("IsServerOnly");
			method cgmeEn_IsServerOnly = CGameEntity.__N.CGmeEn_IsServerOnly;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsServerOnly) > 0;
		}

		// Token: 0x0600063D RID: 1597 RVA: 0x0002F080 File Offset: 0x0002D280
		internal readonly bool IsClientOnly()
		{
			this.NullCheck("IsClientOnly");
			method cgmeEn_IsClientOnly = CGameEntity.__N.CGmeEn_IsClientOnly;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsClientOnly) > 0;
		}

		// Token: 0x0600063E RID: 1598 RVA: 0x0002F0B0 File Offset: 0x0002D2B0
		internal readonly bool IsClientServerNetworked()
		{
			this.NullCheck("IsClientServerNetworked");
			method cgmeEn_IsClientServerNetworked = CGameEntity.__N.CGmeEn_IsClientServerNetworked;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsClientServerNetworked) > 0;
		}

		// Token: 0x0600063F RID: 1599 RVA: 0x0002F0E0 File Offset: 0x0002D2E0
		internal readonly void OnSave()
		{
			this.NullCheck("OnSave");
			method cgmeEn_OnSave = CGameEntity.__N.CGmeEn_OnSave;
			calli(System.Void(System.IntPtr), this.self, cgmeEn_OnSave);
		}

		// Token: 0x06000640 RID: 1600 RVA: 0x0002F10C File Offset: 0x0002D30C
		internal readonly void OnRestore()
		{
			this.NullCheck("OnRestore");
			method cgmeEn_OnRestore = CGameEntity.__N.CGmeEn_OnRestore;
			calli(System.Void(System.IntPtr), this.self, cgmeEn_OnRestore);
		}

		// Token: 0x06000641 RID: 1601 RVA: 0x0002F138 File Offset: 0x0002D338
		internal readonly int ObjectCaps()
		{
			this.NullCheck("ObjectCaps");
			method cgmeEn_ObjectCaps = CGameEntity.__N.CGmeEn_ObjectCaps;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_ObjectCaps);
		}

		// Token: 0x06000642 RID: 1602 RVA: 0x0002F164 File Offset: 0x0002D364
		internal readonly void NetworkStateChanged()
		{
			this.NullCheck("NetworkStateChanged");
			method cgmeEn_NetworkStateChanged = CGameEntity.__N.CGmeEn_NetworkStateChanged;
			calli(System.Void(System.IntPtr), this.self, cgmeEn_NetworkStateChanged);
		}

		// Token: 0x06000643 RID: 1603 RVA: 0x0002F190 File Offset: 0x0002D390
		internal readonly void NetworkStateChangedLog(string pVarName, string pMsg)
		{
			this.NullCheck("NetworkStateChangedLog");
			method cgmeEn_NetworkStateChangedLog = CGameEntity.__N.CGmeEn_NetworkStateChangedLog;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pVarName), Interop.GetPointer(pMsg), cgmeEn_NetworkStateChangedLog);
		}

		// Token: 0x06000644 RID: 1604 RVA: 0x0002F1C8 File Offset: 0x0002D3C8
		internal readonly bool IsCapableOfNetworking()
		{
			this.NullCheck("IsCapableOfNetworking");
			method cgmeEn_IsCapableOfNetworking = CGameEntity.__N.CGmeEn_IsCapableOfNetworking;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsCapableOfNetworking) > 0;
		}

		// Token: 0x06000645 RID: 1605 RVA: 0x0002F1F8 File Offset: 0x0002D3F8
		internal readonly bool IsNetworked()
		{
			this.NullCheck("IsNetworked");
			method cgmeEn_IsNetworked = CGameEntity.__N.CGmeEn_IsNetworked;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsNetworked) > 0;
		}

		// Token: 0x06000646 RID: 1606 RVA: 0x0002F228 File Offset: 0x0002D428
		internal readonly bool IsAuthoritative()
		{
			this.NullCheck("IsAuthoritative");
			method cgmeEn_IsAuthoritative = CGameEntity.__N.CGmeEn_IsAuthoritative;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsAuthoritative) > 0;
		}

		// Token: 0x06000647 RID: 1607 RVA: 0x0002F258 File Offset: 0x0002D458
		internal readonly bool IsDormant()
		{
			this.NullCheck("IsDormant");
			method cgmeEn_IsDormant = CGameEntity.__N.CGmeEn_IsDormant;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsDormant) > 0;
		}

		// Token: 0x06000648 RID: 1608 RVA: 0x0002F288 File Offset: 0x0002D488
		internal readonly bool IsMarkedForDeletion()
		{
			this.NullCheck("IsMarkedForDeletion");
			method cgmeEn_IsMarkedForDeletion = CGameEntity.__N.CGmeEn_IsMarkedForDeletion;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsMarkedForDeletion) > 0;
		}

		// Token: 0x06000649 RID: 1609 RVA: 0x0002F2B8 File Offset: 0x0002D4B8
		internal readonly bool IsSpawnInProgress()
		{
			this.NullCheck("IsSpawnInProgress");
			method cgmeEn_IsSpawnInProgress = CGameEntity.__N.CGmeEn_IsSpawnInProgress;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsSpawnInProgress) > 0;
		}

		// Token: 0x0600064A RID: 1610 RVA: 0x0002F2E8 File Offset: 0x0002D4E8
		internal readonly bool IsConstructionInProgress()
		{
			this.NullCheck("IsConstructionInProgress");
			method cgmeEn_IsConstructionInProgress = CGameEntity.__N.CGmeEn_IsConstructionInProgress;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsConstructionInProgress) > 0;
		}

		// Token: 0x0600064B RID: 1611 RVA: 0x0002F318 File Offset: 0x0002D518
		internal readonly bool IsDeletionInProgress()
		{
			this.NullCheck("IsDeletionInProgress");
			method cgmeEn_IsDeletionInProgress = CGameEntity.__N.CGmeEn_IsDeletionInProgress;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsDeletionInProgress) > 0;
		}

		// Token: 0x0600064C RID: 1612 RVA: 0x0002F348 File Offset: 0x0002D548
		internal readonly bool IsPreSpawn()
		{
			this.NullCheck("IsPreSpawn");
			method cgmeEn_IsPreSpawn = CGameEntity.__N.CGmeEn_IsPreSpawn;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsPreSpawn) > 0;
		}

		// Token: 0x0600064D RID: 1613 RVA: 0x0002F378 File Offset: 0x0002D578
		internal readonly bool IsInEntityDatabase()
		{
			this.NullCheck("IsInEntityDatabase");
			method cgmeEn_IsInEntityDatabase = CGameEntity.__N.CGmeEn_IsInEntityDatabase;
			return calli(System.Int32(System.IntPtr), this.self, cgmeEn_IsInEntityDatabase) > 0;
		}

		// Token: 0x0600064E RID: 1614 RVA: 0x0002F3A8 File Offset: 0x0002D5A8
		internal readonly void SetEntityName(string pName)
		{
			this.NullCheck("SetEntityName");
			method cgmeEn_SetEntityName = CGameEntity.__N.CGmeEn_SetEntityName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pName), cgmeEn_SetEntityName);
		}

		// Token: 0x0600064F RID: 1615 RVA: 0x0002F3D8 File Offset: 0x0002D5D8
		internal readonly string GetEntityNameAsCStr()
		{
			this.NullCheck("GetEntityNameAsCStr");
			method cgmeEn_GetEntityNameAsCStr = CGameEntity.__N.CGmeEn_GetEntityNameAsCStr;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cgmeEn_GetEntityNameAsCStr));
		}

		// Token: 0x06000650 RID: 1616 RVA: 0x0002F408 File Offset: 0x0002D608
		internal readonly bool NameMatches(string pszNameOrWildcard)
		{
			this.NullCheck("NameMatches");
			method cgmeEn_NameMatches = CGameEntity.__N.CGmeEn_NameMatches;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pszNameOrWildcard), cgmeEn_NameMatches) > 0;
		}

		// Token: 0x06000651 RID: 1617 RVA: 0x0002F43C File Offset: 0x0002D63C
		internal readonly string GetDebugName()
		{
			this.NullCheck("GetDebugName");
			method cgmeEn_GetDebugName = CGameEntity.__N.CGmeEn_GetDebugName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cgmeEn_GetDebugName));
		}

		// Token: 0x06000652 RID: 1618 RVA: 0x0002F46C File Offset: 0x0002D66C
		internal readonly string GetClassNameAsCStr()
		{
			this.NullCheck("GetClassNameAsCStr");
			method cgmeEn_GetClassNameAsCStr = CGameEntity.__N.CGmeEn_GetClassNameAsCStr;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cgmeEn_GetClassNameAsCStr));
		}

		// Token: 0x06000653 RID: 1619 RVA: 0x0002F49C File Offset: 0x0002D69C
		internal readonly bool ClassMatches(string pszClassNameOrWildcard)
		{
			this.NullCheck("ClassMatches");
			method cgmeEn_ClassMatches = CGameEntity.__N.CGmeEn_ClassMatches;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pszClassNameOrWildcard), cgmeEn_ClassMatches) > 0;
		}

		// Token: 0x06000654 RID: 1620 RVA: 0x0002F4D0 File Offset: 0x0002D6D0
		internal readonly uint GetSizeOf()
		{
			this.NullCheck("GetSizeOf");
			method cgmeEn_GetSizeOf = CGameEntity.__N.CGmeEn_GetSizeOf;
			return calli(System.UInt32(System.IntPtr), this.self, cgmeEn_GetSizeOf);
		}

		// Token: 0x06000655 RID: 1621 RVA: 0x0002F4FC File Offset: 0x0002D6FC
		internal readonly CBaseHandle GetRefEHandle()
		{
			this.NullCheck("GetRefEHandle");
			method cgmeEn_GetRefEHandle = CGameEntity.__N.CGmeEn_GetRefEHandle;
			return calli(NativeEngine.CBaseHandle(System.IntPtr), this.self, cgmeEn_GetRefEHandle);
		}

		// Token: 0x040000A7 RID: 167
		internal IntPtr self;

		// Token: 0x020001B0 RID: 432
		internal static class __N
		{
			// Token: 0x04000C2B RID: 3115
			internal static method From_CEntityInstance_To_CGameEntity;

			// Token: 0x04000C2C RID: 3116
			internal static method To_CEntityInstance_From_CGameEntity;

			// Token: 0x04000C2D RID: 3117
			internal static method From_IHandleEntity_To_CGameEntity;

			// Token: 0x04000C2E RID: 3118
			internal static method To_IHandleEntity_From_CGameEntity;

			// Token: 0x04000C2F RID: 3119
			internal static method CGmeEn_IsServerOnly;

			// Token: 0x04000C30 RID: 3120
			internal static method CGmeEn_IsClientOnly;

			// Token: 0x04000C31 RID: 3121
			internal static method CGmeEn_IsClientServerNetworked;

			// Token: 0x04000C32 RID: 3122
			internal static method CGmeEn_OnSave;

			// Token: 0x04000C33 RID: 3123
			internal static method CGmeEn_OnRestore;

			// Token: 0x04000C34 RID: 3124
			internal static method CGmeEn_ObjectCaps;

			// Token: 0x04000C35 RID: 3125
			internal static method CGmeEn_NetworkStateChanged;

			// Token: 0x04000C36 RID: 3126
			internal static method CGmeEn_NetworkStateChangedLog;

			// Token: 0x04000C37 RID: 3127
			internal static method CGmeEn_IsCapableOfNetworking;

			// Token: 0x04000C38 RID: 3128
			internal static method CGmeEn_IsNetworked;

			// Token: 0x04000C39 RID: 3129
			internal static method CGmeEn_IsAuthoritative;

			// Token: 0x04000C3A RID: 3130
			internal static method CGmeEn_IsDormant;

			// Token: 0x04000C3B RID: 3131
			internal static method CGmeEn_IsMarkedForDeletion;

			// Token: 0x04000C3C RID: 3132
			internal static method CGmeEn_IsSpawnInProgress;

			// Token: 0x04000C3D RID: 3133
			internal static method CGmeEn_IsConstructionInProgress;

			// Token: 0x04000C3E RID: 3134
			internal static method CGmeEn_IsDeletionInProgress;

			// Token: 0x04000C3F RID: 3135
			internal static method CGmeEn_IsPreSpawn;

			// Token: 0x04000C40 RID: 3136
			internal static method CGmeEn_IsInEntityDatabase;

			// Token: 0x04000C41 RID: 3137
			internal static method CGmeEn_SetEntityName;

			// Token: 0x04000C42 RID: 3138
			internal static method CGmeEn_GetEntityNameAsCStr;

			// Token: 0x04000C43 RID: 3139
			internal static method CGmeEn_NameMatches;

			// Token: 0x04000C44 RID: 3140
			internal static method CGmeEn_GetDebugName;

			// Token: 0x04000C45 RID: 3141
			internal static method CGmeEn_GetClassNameAsCStr;

			// Token: 0x04000C46 RID: 3142
			internal static method CGmeEn_ClassMatches;

			// Token: 0x04000C47 RID: 3143
			internal static method CGmeEn_GetSizeOf;

			// Token: 0x04000C48 RID: 3144
			internal static method CGmeEn_GetRefEHandle;
		}
	}
}
