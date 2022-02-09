using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x0200001B RID: 27
internal struct CWidget
{
	// Token: 0x06000207 RID: 519 RVA: 0x00006F19 File Offset: 0x00005119
	public static implicit operator IntPtr(CWidget value)
	{
		return value.self;
	}

	// Token: 0x06000208 RID: 520 RVA: 0x00006F24 File Offset: 0x00005124
	public static implicit operator CWidget(IntPtr value)
	{
		return new CWidget
		{
			self = value
		};
	}

	// Token: 0x06000209 RID: 521 RVA: 0x00006F42 File Offset: 0x00005142
	public static bool operator ==(CWidget c1, CWidget c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600020A RID: 522 RVA: 0x00006F55 File Offset: 0x00005155
	public static bool operator !=(CWidget c1, CWidget c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600020B RID: 523 RVA: 0x00006F68 File Offset: 0x00005168
	public override bool Equals(object obj)
	{
		if (obj is CWidget)
		{
			CWidget c = (CWidget)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600020C RID: 524 RVA: 0x00006F92 File Offset: 0x00005192
	internal CWidget(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00006F9C File Offset: 0x0000519C
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CWidget ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x0600020E RID: 526 RVA: 0x00006FD7 File Offset: 0x000051D7
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x0600020F RID: 527 RVA: 0x00006FE9 File Offset: 0x000051E9
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000210 RID: 528 RVA: 0x00006FF4 File Offset: 0x000051F4
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000211 RID: 529 RVA: 0x00007007 File Offset: 0x00005207
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CWidget was null when calling " + n);
		}
	}

	// Token: 0x06000212 RID: 530 RVA: 0x00007022 File Offset: 0x00005222
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000213 RID: 531 RVA: 0x00007030 File Offset: 0x00005230
	internal static QWidget CreateWidget(QWidget parent, Widget managedObject)
	{
		method cwdget_CreateWidget = CWidget.__N.CWdget_CreateWidget;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedObject == null) ? 0U : InteropSystem.GetAddress<Widget>(managedObject, true), cwdget_CreateWidget);
	}

	// Token: 0x04000017 RID: 23
	internal IntPtr self;

	// Token: 0x020000EB RID: 235
	internal static class __N
	{
		// Token: 0x04000625 RID: 1573
		internal static method CWdget_CreateWidget;
	}
}
