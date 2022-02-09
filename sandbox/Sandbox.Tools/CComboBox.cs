using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x0200000D RID: 13
internal struct CComboBox
{
	// Token: 0x06000042 RID: 66 RVA: 0x00002C09 File Offset: 0x00000E09
	public static implicit operator IntPtr(CComboBox value)
	{
		return value.self;
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00002C14 File Offset: 0x00000E14
	public static implicit operator CComboBox(IntPtr value)
	{
		return new CComboBox
		{
			self = value
		};
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00002C32 File Offset: 0x00000E32
	public static bool operator ==(CComboBox c1, CComboBox c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00002C45 File Offset: 0x00000E45
	public static bool operator !=(CComboBox c1, CComboBox c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00002C58 File Offset: 0x00000E58
	public override bool Equals(object obj)
	{
		if (obj is CComboBox)
		{
			CComboBox c = (CComboBox)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00002C82 File Offset: 0x00000E82
	internal CComboBox(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00002C8C File Offset: 0x00000E8C
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CComboBox ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x06000049 RID: 73 RVA: 0x00002CC8 File Offset: 0x00000EC8
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000006 RID: 6
	// (get) Token: 0x0600004A RID: 74 RVA: 0x00002CDA File Offset: 0x00000EDA
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00002CE5 File Offset: 0x00000EE5
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00002CF8 File Offset: 0x00000EF8
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CComboBox was null when calling " + n);
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00002D13 File Offset: 0x00000F13
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00002D20 File Offset: 0x00000F20
	internal static QComboBox Create(QWidget parent, ComboBox managedobj)
	{
		method ccmbBx_Create = CComboBox.__N.CCmbBx_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedobj == null) ? 0U : InteropSystem.GetAddress<ComboBox>(managedobj, true), ccmbBx_Create);
	}

	// Token: 0x04000009 RID: 9
	internal IntPtr self;

	// Token: 0x020000DD RID: 221
	internal static class __N
	{
		// Token: 0x04000508 RID: 1288
		internal static method CCmbBx_Create;
	}
}
