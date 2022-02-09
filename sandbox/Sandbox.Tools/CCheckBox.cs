using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x0200000C RID: 12
internal struct CCheckBox
{
	// Token: 0x06000035 RID: 53 RVA: 0x00002AC3 File Offset: 0x00000CC3
	public static implicit operator IntPtr(CCheckBox value)
	{
		return value.self;
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00002ACC File Offset: 0x00000CCC
	public static implicit operator CCheckBox(IntPtr value)
	{
		return new CCheckBox
		{
			self = value
		};
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00002AEA File Offset: 0x00000CEA
	public static bool operator ==(CCheckBox c1, CCheckBox c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00002AFD File Offset: 0x00000CFD
	public static bool operator !=(CCheckBox c1, CCheckBox c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00002B10 File Offset: 0x00000D10
	public override bool Equals(object obj)
	{
		if (obj is CCheckBox)
		{
			CCheckBox c = (CCheckBox)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002B3A File Offset: 0x00000D3A
	internal CCheckBox(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00002B44 File Offset: 0x00000D44
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CCheckBox ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x0600003C RID: 60 RVA: 0x00002B80 File Offset: 0x00000D80
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x0600003D RID: 61 RVA: 0x00002B92 File Offset: 0x00000D92
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00002B9D File Offset: 0x00000D9D
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00002BB0 File Offset: 0x00000DB0
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CCheckBox was null when calling " + n);
		}
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00002BCB File Offset: 0x00000DCB
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00002BD8 File Offset: 0x00000DD8
	internal static CCheckBox CreateCheckBox(QWidget parent, CheckBox managedobj)
	{
		method ccheck_CreateCheckBox = CCheckBox.__N.CCheck_CreateCheckBox;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedobj == null) ? 0U : InteropSystem.GetAddress<CheckBox>(managedobj, true), ccheck_CreateCheckBox);
	}

	// Token: 0x04000008 RID: 8
	internal IntPtr self;

	// Token: 0x020000DC RID: 220
	internal static class __N
	{
		// Token: 0x04000507 RID: 1287
		internal static method CCheck_CreateCheckBox;
	}
}
