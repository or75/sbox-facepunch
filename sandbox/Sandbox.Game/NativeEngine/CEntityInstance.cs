using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200002A RID: 42
	internal struct CEntityInstance
	{
		// Token: 0x06000607 RID: 1543 RVA: 0x0002E906 File Offset: 0x0002CB06
		public static implicit operator IntPtr(CEntityInstance value)
		{
			return value.self;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x0002E910 File Offset: 0x0002CB10
		public static implicit operator CEntityInstance(IntPtr value)
		{
			return new CEntityInstance
			{
				self = value
			};
		}

		// Token: 0x06000609 RID: 1545 RVA: 0x0002E92E File Offset: 0x0002CB2E
		public static bool operator ==(CEntityInstance c1, CEntityInstance c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600060A RID: 1546 RVA: 0x0002E941 File Offset: 0x0002CB41
		public static bool operator !=(CEntityInstance c1, CEntityInstance c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600060B RID: 1547 RVA: 0x0002E954 File Offset: 0x0002CB54
		public override bool Equals(object obj)
		{
			if (obj is CEntityInstance)
			{
				CEntityInstance c = (CEntityInstance)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600060C RID: 1548 RVA: 0x0002E97E File Offset: 0x0002CB7E
		internal CEntityInstance(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x0002E988 File Offset: 0x0002CB88
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CEntityInstance ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x0600060E RID: 1550 RVA: 0x0002E9C4 File Offset: 0x0002CBC4
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x0600060F RID: 1551 RVA: 0x0002E9D6 File Offset: 0x0002CBD6
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000610 RID: 1552 RVA: 0x0002E9E1 File Offset: 0x0002CBE1
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000611 RID: 1553 RVA: 0x0002E9F4 File Offset: 0x0002CBF4
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CEntityInstance was null when calling " + n);
			}
		}

		// Token: 0x06000612 RID: 1554 RVA: 0x0002EA0F File Offset: 0x0002CC0F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000613 RID: 1555 RVA: 0x0002EA1C File Offset: 0x0002CC1C
		public static implicit operator IHandleEntity(CEntityInstance value)
		{
			method to_IHandleEntity_From_CEntityInstance = CEntityInstance.__N.To_IHandleEntity_From_CEntityInstance;
			return calli(System.IntPtr(System.IntPtr), value, to_IHandleEntity_From_CEntityInstance);
		}

		// Token: 0x06000614 RID: 1556 RVA: 0x0002EA40 File Offset: 0x0002CC40
		public static explicit operator CEntityInstance(IHandleEntity value)
		{
			method from_IHandleEntity_To_CEntityInstance = CEntityInstance.__N.From_IHandleEntity_To_CEntityInstance;
			return calli(System.IntPtr(System.IntPtr), value, from_IHandleEntity_To_CEntityInstance);
		}

		// Token: 0x06000615 RID: 1557 RVA: 0x0002EA64 File Offset: 0x0002CC64
		internal readonly void OnSave()
		{
			this.NullCheck("OnSave");
			method centty_OnSave = CEntityInstance.__N.CEntty_OnSave;
			calli(System.Void(System.IntPtr), this.self, centty_OnSave);
		}

		// Token: 0x06000616 RID: 1558 RVA: 0x0002EA90 File Offset: 0x0002CC90
		internal readonly void OnRestore()
		{
			this.NullCheck("OnRestore");
			method centty_OnRestore = CEntityInstance.__N.CEntty_OnRestore;
			calli(System.Void(System.IntPtr), this.self, centty_OnRestore);
		}

		// Token: 0x06000617 RID: 1559 RVA: 0x0002EABC File Offset: 0x0002CCBC
		internal readonly int ObjectCaps()
		{
			this.NullCheck("ObjectCaps");
			method centty_ObjectCaps = CEntityInstance.__N.CEntty_ObjectCaps;
			return calli(System.Int32(System.IntPtr), this.self, centty_ObjectCaps);
		}

		// Token: 0x06000618 RID: 1560 RVA: 0x0002EAE8 File Offset: 0x0002CCE8
		internal readonly void NetworkStateChanged()
		{
			this.NullCheck("NetworkStateChanged");
			method centty_NetworkStateChanged = CEntityInstance.__N.CEntty_NetworkStateChanged;
			calli(System.Void(System.IntPtr), this.self, centty_NetworkStateChanged);
		}

		// Token: 0x06000619 RID: 1561 RVA: 0x0002EB14 File Offset: 0x0002CD14
		internal readonly void NetworkStateChangedLog(string pVarName, string pMsg)
		{
			this.NullCheck("NetworkStateChangedLog");
			method centty_NetworkStateChangedLog = CEntityInstance.__N.CEntty_NetworkStateChangedLog;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pVarName), Interop.GetPointer(pMsg), centty_NetworkStateChangedLog);
		}

		// Token: 0x0600061A RID: 1562 RVA: 0x0002EB4C File Offset: 0x0002CD4C
		internal readonly bool IsCapableOfNetworking()
		{
			this.NullCheck("IsCapableOfNetworking");
			method centty_IsCapableOfNetworking = CEntityInstance.__N.CEntty_IsCapableOfNetworking;
			return calli(System.Int32(System.IntPtr), this.self, centty_IsCapableOfNetworking) > 0;
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x0002EB7C File Offset: 0x0002CD7C
		internal readonly bool IsNetworked()
		{
			this.NullCheck("IsNetworked");
			method centty_IsNetworked = CEntityInstance.__N.CEntty_IsNetworked;
			return calli(System.Int32(System.IntPtr), this.self, centty_IsNetworked) > 0;
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x0002EBAC File Offset: 0x0002CDAC
		internal readonly bool IsAuthoritative()
		{
			this.NullCheck("IsAuthoritative");
			method centty_IsAuthoritative = CEntityInstance.__N.CEntty_IsAuthoritative;
			return calli(System.Int32(System.IntPtr), this.self, centty_IsAuthoritative) > 0;
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x0002EBDC File Offset: 0x0002CDDC
		internal readonly bool IsDormant()
		{
			this.NullCheck("IsDormant");
			method centty_IsDormant = CEntityInstance.__N.CEntty_IsDormant;
			return calli(System.Int32(System.IntPtr), this.self, centty_IsDormant) > 0;
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x0002EC0C File Offset: 0x0002CE0C
		internal readonly bool IsMarkedForDeletion()
		{
			this.NullCheck("IsMarkedForDeletion");
			method centty_IsMarkedForDeletion = CEntityInstance.__N.CEntty_IsMarkedForDeletion;
			return calli(System.Int32(System.IntPtr), this.self, centty_IsMarkedForDeletion) > 0;
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x0002EC3C File Offset: 0x0002CE3C
		internal readonly bool IsSpawnInProgress()
		{
			this.NullCheck("IsSpawnInProgress");
			method centty_IsSpawnInProgress = CEntityInstance.__N.CEntty_IsSpawnInProgress;
			return calli(System.Int32(System.IntPtr), this.self, centty_IsSpawnInProgress) > 0;
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x0002EC6C File Offset: 0x0002CE6C
		internal readonly bool IsConstructionInProgress()
		{
			this.NullCheck("IsConstructionInProgress");
			method centty_IsConstructionInProgress = CEntityInstance.__N.CEntty_IsConstructionInProgress;
			return calli(System.Int32(System.IntPtr), this.self, centty_IsConstructionInProgress) > 0;
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x0002EC9C File Offset: 0x0002CE9C
		internal readonly bool IsDeletionInProgress()
		{
			this.NullCheck("IsDeletionInProgress");
			method centty_IsDeletionInProgress = CEntityInstance.__N.CEntty_IsDeletionInProgress;
			return calli(System.Int32(System.IntPtr), this.self, centty_IsDeletionInProgress) > 0;
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x0002ECCC File Offset: 0x0002CECC
		internal readonly bool IsPreSpawn()
		{
			this.NullCheck("IsPreSpawn");
			method centty_IsPreSpawn = CEntityInstance.__N.CEntty_IsPreSpawn;
			return calli(System.Int32(System.IntPtr), this.self, centty_IsPreSpawn) > 0;
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x0002ECFC File Offset: 0x0002CEFC
		internal readonly bool IsInEntityDatabase()
		{
			this.NullCheck("IsInEntityDatabase");
			method centty_IsInEntityDatabase = CEntityInstance.__N.CEntty_IsInEntityDatabase;
			return calli(System.Int32(System.IntPtr), this.self, centty_IsInEntityDatabase) > 0;
		}

		// Token: 0x06000624 RID: 1572 RVA: 0x0002ED2C File Offset: 0x0002CF2C
		internal readonly void SetEntityName(string pName)
		{
			this.NullCheck("SetEntityName");
			method centty_SetEntityName = CEntityInstance.__N.CEntty_SetEntityName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pName), centty_SetEntityName);
		}

		// Token: 0x06000625 RID: 1573 RVA: 0x0002ED5C File Offset: 0x0002CF5C
		internal readonly string GetEntityNameAsCStr()
		{
			this.NullCheck("GetEntityNameAsCStr");
			method centty_GetEntityNameAsCStr = CEntityInstance.__N.CEntty_GetEntityNameAsCStr;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, centty_GetEntityNameAsCStr));
		}

		// Token: 0x06000626 RID: 1574 RVA: 0x0002ED8C File Offset: 0x0002CF8C
		internal readonly bool NameMatches(string pszNameOrWildcard)
		{
			this.NullCheck("NameMatches");
			method centty_NameMatches = CEntityInstance.__N.CEntty_NameMatches;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pszNameOrWildcard), centty_NameMatches) > 0;
		}

		// Token: 0x06000627 RID: 1575 RVA: 0x0002EDC0 File Offset: 0x0002CFC0
		internal readonly string GetDebugName()
		{
			this.NullCheck("GetDebugName");
			method centty_GetDebugName = CEntityInstance.__N.CEntty_GetDebugName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, centty_GetDebugName));
		}

		// Token: 0x06000628 RID: 1576 RVA: 0x0002EDF0 File Offset: 0x0002CFF0
		internal readonly string GetClassNameAsCStr()
		{
			this.NullCheck("GetClassNameAsCStr");
			method centty_GetClassNameAsCStr = CEntityInstance.__N.CEntty_GetClassNameAsCStr;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, centty_GetClassNameAsCStr));
		}

		// Token: 0x06000629 RID: 1577 RVA: 0x0002EE20 File Offset: 0x0002D020
		internal readonly bool ClassMatches(string pszClassNameOrWildcard)
		{
			this.NullCheck("ClassMatches");
			method centty_f = CEntityInstance.__N.CEntty_f2;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(pszClassNameOrWildcard), centty_f) > 0;
		}

		// Token: 0x0600062A RID: 1578 RVA: 0x0002EE54 File Offset: 0x0002D054
		internal readonly uint GetSizeOf()
		{
			this.NullCheck("GetSizeOf");
			method centty_GetSizeOf = CEntityInstance.__N.CEntty_GetSizeOf;
			return calli(System.UInt32(System.IntPtr), this.self, centty_GetSizeOf);
		}

		// Token: 0x0600062B RID: 1579 RVA: 0x0002EE80 File Offset: 0x0002D080
		internal readonly CBaseHandle GetRefEHandle()
		{
			this.NullCheck("GetRefEHandle");
			method centty_GetRefEHandle = CEntityInstance.__N.CEntty_GetRefEHandle;
			return calli(NativeEngine.CBaseHandle(System.IntPtr), this.self, centty_GetRefEHandle);
		}

		// Token: 0x040000A6 RID: 166
		internal IntPtr self;

		// Token: 0x020001AF RID: 431
		internal static class __N
		{
			// Token: 0x04000C12 RID: 3090
			internal static method From_IHandleEntity_To_CEntityInstance;

			// Token: 0x04000C13 RID: 3091
			internal static method To_IHandleEntity_From_CEntityInstance;

			// Token: 0x04000C14 RID: 3092
			internal static method CEntty_OnSave;

			// Token: 0x04000C15 RID: 3093
			internal static method CEntty_OnRestore;

			// Token: 0x04000C16 RID: 3094
			internal static method CEntty_ObjectCaps;

			// Token: 0x04000C17 RID: 3095
			internal static method CEntty_NetworkStateChanged;

			// Token: 0x04000C18 RID: 3096
			internal static method CEntty_NetworkStateChangedLog;

			// Token: 0x04000C19 RID: 3097
			internal static method CEntty_IsCapableOfNetworking;

			// Token: 0x04000C1A RID: 3098
			internal static method CEntty_IsNetworked;

			// Token: 0x04000C1B RID: 3099
			internal static method CEntty_IsAuthoritative;

			// Token: 0x04000C1C RID: 3100
			internal static method CEntty_IsDormant;

			// Token: 0x04000C1D RID: 3101
			internal static method CEntty_IsMarkedForDeletion;

			// Token: 0x04000C1E RID: 3102
			internal static method CEntty_IsSpawnInProgress;

			// Token: 0x04000C1F RID: 3103
			internal static method CEntty_IsConstructionInProgress;

			// Token: 0x04000C20 RID: 3104
			internal static method CEntty_IsDeletionInProgress;

			// Token: 0x04000C21 RID: 3105
			internal static method CEntty_IsPreSpawn;

			// Token: 0x04000C22 RID: 3106
			internal static method CEntty_IsInEntityDatabase;

			// Token: 0x04000C23 RID: 3107
			internal static method CEntty_SetEntityName;

			// Token: 0x04000C24 RID: 3108
			internal static method CEntty_GetEntityNameAsCStr;

			// Token: 0x04000C25 RID: 3109
			internal static method CEntty_NameMatches;

			// Token: 0x04000C26 RID: 3110
			internal static method CEntty_GetDebugName;

			// Token: 0x04000C27 RID: 3111
			internal static method CEntty_GetClassNameAsCStr;

			// Token: 0x04000C28 RID: 3112
			internal static method CEntty_f2;

			// Token: 0x04000C29 RID: 3113
			internal static method CEntty_GetSizeOf;

			// Token: 0x04000C2A RID: 3114
			internal static method CEntty_GetRefEHandle;
		}
	}
}
