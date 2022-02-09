using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000017 RID: 23
internal struct CStatusBar
{
	// Token: 0x06000149 RID: 329 RVA: 0x000050CD File Offset: 0x000032CD
	public static implicit operator IntPtr(CStatusBar value)
	{
		return value.self;
	}

	// Token: 0x0600014A RID: 330 RVA: 0x000050D8 File Offset: 0x000032D8
	public static implicit operator CStatusBar(IntPtr value)
	{
		return new CStatusBar
		{
			self = value
		};
	}

	// Token: 0x0600014B RID: 331 RVA: 0x000050F6 File Offset: 0x000032F6
	public static bool operator ==(CStatusBar c1, CStatusBar c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600014C RID: 332 RVA: 0x00005109 File Offset: 0x00003309
	public static bool operator !=(CStatusBar c1, CStatusBar c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600014D RID: 333 RVA: 0x0000511C File Offset: 0x0000331C
	public override bool Equals(object obj)
	{
		if (obj is CStatusBar)
		{
			CStatusBar c = (CStatusBar)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600014E RID: 334 RVA: 0x00005146 File Offset: 0x00003346
	internal CStatusBar(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x00005150 File Offset: 0x00003350
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CStatusBar ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x06000150 RID: 336 RVA: 0x0000518C File Offset: 0x0000338C
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x06000151 RID: 337 RVA: 0x0000519E File Offset: 0x0000339E
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000152 RID: 338 RVA: 0x000051A9 File Offset: 0x000033A9
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000153 RID: 339 RVA: 0x000051BC File Offset: 0x000033BC
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CStatusBar was null when calling " + n);
		}
	}

	// Token: 0x06000154 RID: 340 RVA: 0x000051D7 File Offset: 0x000033D7
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000155 RID: 341 RVA: 0x000051E4 File Offset: 0x000033E4
	internal static QStatusBar Create(QWidget parent, StatusBar managedobj)
	{
		method csttsB_Create = CStatusBar.__N.CSttsB_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedobj == null) ? 0U : InteropSystem.GetAddress<StatusBar>(managedobj, true), csttsB_Create);
	}

	// Token: 0x04000013 RID: 19
	internal IntPtr self;

	// Token: 0x020000E7 RID: 231
	internal static class __N
	{
		// Token: 0x04000597 RID: 1431
		internal static method CSttsB_Create;
	}
}
