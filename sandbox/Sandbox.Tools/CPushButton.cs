using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000016 RID: 22
internal struct CPushButton
{
	// Token: 0x0600013C RID: 316 RVA: 0x00004F85 File Offset: 0x00003185
	public static implicit operator IntPtr(CPushButton value)
	{
		return value.self;
	}

	// Token: 0x0600013D RID: 317 RVA: 0x00004F90 File Offset: 0x00003190
	public static implicit operator CPushButton(IntPtr value)
	{
		return new CPushButton
		{
			self = value
		};
	}

	// Token: 0x0600013E RID: 318 RVA: 0x00004FAE File Offset: 0x000031AE
	public static bool operator ==(CPushButton c1, CPushButton c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600013F RID: 319 RVA: 0x00004FC1 File Offset: 0x000031C1
	public static bool operator !=(CPushButton c1, CPushButton c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000140 RID: 320 RVA: 0x00004FD4 File Offset: 0x000031D4
	public override bool Equals(object obj)
	{
		if (obj is CPushButton)
		{
			CPushButton c = (CPushButton)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00004FFE File Offset: 0x000031FE
	internal CPushButton(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00005008 File Offset: 0x00003208
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CPushButton ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x06000143 RID: 323 RVA: 0x00005044 File Offset: 0x00003244
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x06000144 RID: 324 RVA: 0x00005056 File Offset: 0x00003256
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000145 RID: 325 RVA: 0x00005061 File Offset: 0x00003261
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000146 RID: 326 RVA: 0x00005074 File Offset: 0x00003274
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CPushButton was null when calling " + n);
		}
	}

	// Token: 0x06000147 RID: 327 RVA: 0x0000508F File Offset: 0x0000328F
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000148 RID: 328 RVA: 0x0000509C File Offset: 0x0000329C
	internal static CPushButton CreatePushButton(QWidget parent, Button managedobj)
	{
		method cpshBt_CreatePushButton = CPushButton.__N.CPshBt_CreatePushButton;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedobj == null) ? 0U : InteropSystem.GetAddress<Button>(managedobj, true), cpshBt_CreatePushButton);
	}

	// Token: 0x04000012 RID: 18
	internal IntPtr self;

	// Token: 0x020000E6 RID: 230
	internal static class __N
	{
		// Token: 0x04000596 RID: 1430
		internal static method CPshBt_CreatePushButton;
	}
}
