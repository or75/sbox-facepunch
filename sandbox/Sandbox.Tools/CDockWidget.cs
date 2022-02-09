using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000010 RID: 16
internal struct CDockWidget
{
	// Token: 0x0600007B RID: 123 RVA: 0x00003332 File Offset: 0x00001532
	public static implicit operator IntPtr(CDockWidget value)
	{
		return value.self;
	}

	// Token: 0x0600007C RID: 124 RVA: 0x0000333C File Offset: 0x0000153C
	public static implicit operator CDockWidget(IntPtr value)
	{
		return new CDockWidget
		{
			self = value
		};
	}

	// Token: 0x0600007D RID: 125 RVA: 0x0000335A File Offset: 0x0000155A
	public static bool operator ==(CDockWidget c1, CDockWidget c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600007E RID: 126 RVA: 0x0000336D File Offset: 0x0000156D
	public static bool operator !=(CDockWidget c1, CDockWidget c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600007F RID: 127 RVA: 0x00003380 File Offset: 0x00001580
	public override bool Equals(object obj)
	{
		if (obj is CDockWidget)
		{
			CDockWidget c = (CDockWidget)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000080 RID: 128 RVA: 0x000033AA File Offset: 0x000015AA
	internal CDockWidget(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000081 RID: 129 RVA: 0x000033B4 File Offset: 0x000015B4
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CDockWidget ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000082 RID: 130 RVA: 0x000033F0 File Offset: 0x000015F0
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000083 RID: 131 RVA: 0x00003402 File Offset: 0x00001602
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000084 RID: 132 RVA: 0x0000340D File Offset: 0x0000160D
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00003420 File Offset: 0x00001620
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CDockWidget was null when calling " + n);
		}
	}

	// Token: 0x06000086 RID: 134 RVA: 0x0000343B File Offset: 0x0000163B
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00003448 File Offset: 0x00001648
	internal static QDockWidget Create(QWidget parent, DockWidget obj)
	{
		method cdckWd_Create = CDockWidget.__N.CDckWd_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (obj == null) ? 0U : InteropSystem.GetAddress<DockWidget>(obj, true), cdckWd_Create);
	}

	// Token: 0x0400000C RID: 12
	internal IntPtr self;

	// Token: 0x020000E0 RID: 224
	internal static class __N
	{
		// Token: 0x0400051D RID: 1309
		internal static method CDckWd_Create;
	}
}
