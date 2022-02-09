using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x0200000E RID: 14
internal struct CDataDelegate
{
	// Token: 0x0600004F RID: 79 RVA: 0x00002D51 File Offset: 0x00000F51
	public static implicit operator IntPtr(CDataDelegate value)
	{
		return value.self;
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00002D5C File Offset: 0x00000F5C
	public static implicit operator CDataDelegate(IntPtr value)
	{
		return new CDataDelegate
		{
			self = value
		};
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00002D7A File Offset: 0x00000F7A
	public static bool operator ==(CDataDelegate c1, CDataDelegate c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00002D8D File Offset: 0x00000F8D
	public static bool operator !=(CDataDelegate c1, CDataDelegate c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00002DA0 File Offset: 0x00000FA0
	public override bool Equals(object obj)
	{
		if (obj is CDataDelegate)
		{
			CDataDelegate c = (CDataDelegate)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00002DCA File Offset: 0x00000FCA
	internal CDataDelegate(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00002DD4 File Offset: 0x00000FD4
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CDataDelegate ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x06000056 RID: 86 RVA: 0x00002E10 File Offset: 0x00001010
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x06000057 RID: 87 RVA: 0x00002E22 File Offset: 0x00001022
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00002E2D File Offset: 0x0000102D
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00002E40 File Offset: 0x00001040
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CDataDelegate was null when calling " + n);
		}
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00002E5B File Offset: 0x0000105B
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00002E68 File Offset: 0x00001068
	public static implicit operator Native.QObject(CDataDelegate value)
	{
		method to_QObject_From_CDataDelegate = CDataDelegate.__N.To_QObject_From_CDataDelegate;
		return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_CDataDelegate);
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00002E8C File Offset: 0x0000108C
	public static explicit operator CDataDelegate(Native.QObject value)
	{
		method from_QObject_To_CDataDelegate = CDataDelegate.__N.From_QObject_To_CDataDelegate;
		return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_CDataDelegate);
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00002EB0 File Offset: 0x000010B0
	internal static CDataDelegate Create(Native.QObject parent, DataModel obj)
	{
		method cdtDel_Create = CDataDelegate.__N.CDtDel_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (obj == null) ? 0U : InteropSystem.GetAddress<DataModel>(obj, true), cdtDel_Create);
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00002EE4 File Offset: 0x000010E4
	internal readonly void deleteLater()
	{
		this.NullCheck("deleteLater");
		method cdtDel_deleteLater = CDataDelegate.__N.CDtDel_deleteLater;
		calli(System.Void(System.IntPtr), this.self, cdtDel_deleteLater);
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00002F10 File Offset: 0x00001110
	internal readonly string objectName()
	{
		this.NullCheck("objectName");
		method cdtDel_objectName = CDataDelegate.__N.CDtDel_objectName;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cdtDel_objectName));
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00002F40 File Offset: 0x00001140
	internal readonly void setObjectName(string name)
	{
		this.NullCheck("setObjectName");
		method cdtDel_setObjectName = CDataDelegate.__N.CDtDel_setObjectName;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), cdtDel_setObjectName);
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00002F70 File Offset: 0x00001170
	internal readonly void setProperty(string key, bool value)
	{
		this.NullCheck("setProperty");
		method cdtDel_setProperty = CDataDelegate.__N.CDtDel_setProperty;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, cdtDel_setProperty);
	}

	// Token: 0x06000062 RID: 98 RVA: 0x00002FA8 File Offset: 0x000011A8
	internal readonly void setProperty(string key, float value)
	{
		this.NullCheck("setProperty");
		method cdtDel_f = CDataDelegate.__N.CDtDel_f2;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, cdtDel_f);
	}

	// Token: 0x06000063 RID: 99 RVA: 0x00002FDC File Offset: 0x000011DC
	internal readonly void setProperty(string key, string value)
	{
		this.NullCheck("setProperty");
		method cdtDel_f = CDataDelegate.__N.CDtDel_f3;
		calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), cdtDel_f);
	}

	// Token: 0x0400000A RID: 10
	internal IntPtr self;

	// Token: 0x020000DE RID: 222
	internal static class __N
	{
		// Token: 0x04000509 RID: 1289
		internal static method From_QObject_To_CDataDelegate;

		// Token: 0x0400050A RID: 1290
		internal static method To_QObject_From_CDataDelegate;

		// Token: 0x0400050B RID: 1291
		internal static method CDtDel_Create;

		// Token: 0x0400050C RID: 1292
		internal static method CDtDel_deleteLater;

		// Token: 0x0400050D RID: 1293
		internal static method CDtDel_objectName;

		// Token: 0x0400050E RID: 1294
		internal static method CDtDel_setObjectName;

		// Token: 0x0400050F RID: 1295
		internal static method CDtDel_setProperty;

		// Token: 0x04000510 RID: 1296
		internal static method CDtDel_f2;

		// Token: 0x04000511 RID: 1297
		internal static method CDtDel_f3;
	}
}
