using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000011 RID: 17
internal struct CFrame
{
	// Token: 0x06000088 RID: 136 RVA: 0x00003479 File Offset: 0x00001679
	public static implicit operator IntPtr(CFrame value)
	{
		return value.self;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00003484 File Offset: 0x00001684
	public static implicit operator CFrame(IntPtr value)
	{
		return new CFrame
		{
			self = value
		};
	}

	// Token: 0x0600008A RID: 138 RVA: 0x000034A2 File Offset: 0x000016A2
	public static bool operator ==(CFrame c1, CFrame c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600008B RID: 139 RVA: 0x000034B5 File Offset: 0x000016B5
	public static bool operator !=(CFrame c1, CFrame c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600008C RID: 140 RVA: 0x000034C8 File Offset: 0x000016C8
	public override bool Equals(object obj)
	{
		if (obj is CFrame)
		{
			CFrame c = (CFrame)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600008D RID: 141 RVA: 0x000034F2 File Offset: 0x000016F2
	internal CFrame(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600008E RID: 142 RVA: 0x000034FC File Offset: 0x000016FC
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CFrame ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x0600008F RID: 143 RVA: 0x00003537 File Offset: 0x00001737
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000090 RID: 144 RVA: 0x00003549 File Offset: 0x00001749
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00003554 File Offset: 0x00001754
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00003567 File Offset: 0x00001767
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CFrame was null when calling " + n);
		}
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00003582 File Offset: 0x00001782
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00003590 File Offset: 0x00001790
	internal static CFrame CreateFrame(QWidget parent, Frame managedobj)
	{
		method cframe_CreateFrame = CFrame.__N.CFrame_CreateFrame;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedobj == null) ? 0U : InteropSystem.GetAddress<Frame>(managedobj, true), cframe_CreateFrame);
	}

	// Token: 0x0400000D RID: 13
	internal IntPtr self;

	// Token: 0x020000E1 RID: 225
	internal static class __N
	{
		// Token: 0x0400051E RID: 1310
		internal static method CFrame_CreateFrame;
	}
}
