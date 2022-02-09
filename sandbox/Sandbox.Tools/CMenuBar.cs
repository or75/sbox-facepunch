using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000014 RID: 20
internal struct CMenuBar
{
	// Token: 0x06000122 RID: 290 RVA: 0x00004CF5 File Offset: 0x00002EF5
	public static implicit operator IntPtr(CMenuBar value)
	{
		return value.self;
	}

	// Token: 0x06000123 RID: 291 RVA: 0x00004D00 File Offset: 0x00002F00
	public static implicit operator CMenuBar(IntPtr value)
	{
		return new CMenuBar
		{
			self = value
		};
	}

	// Token: 0x06000124 RID: 292 RVA: 0x00004D1E File Offset: 0x00002F1E
	public static bool operator ==(CMenuBar c1, CMenuBar c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000125 RID: 293 RVA: 0x00004D31 File Offset: 0x00002F31
	public static bool operator !=(CMenuBar c1, CMenuBar c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000126 RID: 294 RVA: 0x00004D44 File Offset: 0x00002F44
	public override bool Equals(object obj)
	{
		if (obj is CMenuBar)
		{
			CMenuBar c = (CMenuBar)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x00004D6E File Offset: 0x00002F6E
	internal CMenuBar(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000128 RID: 296 RVA: 0x00004D78 File Offset: 0x00002F78
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CMenuBar ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000129 RID: 297 RVA: 0x00004DB4 File Offset: 0x00002FB4
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x0600012A RID: 298 RVA: 0x00004DC6 File Offset: 0x00002FC6
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600012B RID: 299 RVA: 0x00004DD1 File Offset: 0x00002FD1
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00004DE4 File Offset: 0x00002FE4
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CMenuBar was null when calling " + n);
		}
	}

	// Token: 0x0600012D RID: 301 RVA: 0x00004DFF File Offset: 0x00002FFF
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x0600012E RID: 302 RVA: 0x00004E0C File Offset: 0x0000300C
	internal static QMenuBar Create(QWidget parent, MenuBar menubar)
	{
		method cmenBr_Create = CMenuBar.__N.CMenBr_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (menubar == null) ? 0U : InteropSystem.GetAddress<MenuBar>(menubar, true), cmenBr_Create);
	}

	// Token: 0x04000010 RID: 16
	internal IntPtr self;

	// Token: 0x020000E4 RID: 228
	internal static class __N
	{
		// Token: 0x04000594 RID: 1428
		internal static method CMenBr_Create;
	}
}
