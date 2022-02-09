using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000019 RID: 25
internal struct CToolBar
{
	// Token: 0x06000172 RID: 370 RVA: 0x0000562E File Offset: 0x0000382E
	public static implicit operator IntPtr(CToolBar value)
	{
		return value.self;
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00005638 File Offset: 0x00003838
	public static implicit operator CToolBar(IntPtr value)
	{
		return new CToolBar
		{
			self = value
		};
	}

	// Token: 0x06000174 RID: 372 RVA: 0x00005656 File Offset: 0x00003856
	public static bool operator ==(CToolBar c1, CToolBar c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00005669 File Offset: 0x00003869
	public static bool operator !=(CToolBar c1, CToolBar c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000176 RID: 374 RVA: 0x0000567C File Offset: 0x0000387C
	public override bool Equals(object obj)
	{
		if (obj is CToolBar)
		{
			CToolBar c = (CToolBar)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000177 RID: 375 RVA: 0x000056A6 File Offset: 0x000038A6
	internal CToolBar(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000178 RID: 376 RVA: 0x000056B0 File Offset: 0x000038B0
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CToolBar ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000179 RID: 377 RVA: 0x000056EC File Offset: 0x000038EC
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x0600017A RID: 378 RVA: 0x000056FE File Offset: 0x000038FE
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600017B RID: 379 RVA: 0x00005709 File Offset: 0x00003909
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600017C RID: 380 RVA: 0x0000571C File Offset: 0x0000391C
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CToolBar was null when calling " + n);
		}
	}

	// Token: 0x0600017D RID: 381 RVA: 0x00005737 File Offset: 0x00003937
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00005744 File Offset: 0x00003944
	internal static QToolBar Create(QWidget parent, ToolBar managedobj)
	{
		method ctoolB_Create = CToolBar.__N.CToolB_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedobj == null) ? 0U : InteropSystem.GetAddress<ToolBar>(managedobj, true), ctoolB_Create);
	}

	// Token: 0x04000015 RID: 21
	internal IntPtr self;

	// Token: 0x020000E9 RID: 233
	internal static class __N
	{
		// Token: 0x040005A8 RID: 1448
		internal static method CToolB_Create;
	}
}
