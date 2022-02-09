using System;
using System.Runtime.CompilerServices;

// Token: 0x02000023 RID: 35
internal struct QEvent
{
	// Token: 0x060002B0 RID: 688 RVA: 0x00008511 File Offset: 0x00006711
	public static implicit operator IntPtr(QEvent value)
	{
		return value.self;
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x0000851C File Offset: 0x0000671C
	public static implicit operator QEvent(IntPtr value)
	{
		return new QEvent
		{
			self = value
		};
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x0000853A File Offset: 0x0000673A
	public static bool operator ==(QEvent c1, QEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x0000854D File Offset: 0x0000674D
	public static bool operator !=(QEvent c1, QEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x00008560 File Offset: 0x00006760
	public override bool Equals(object obj)
	{
		if (obj is QEvent)
		{
			QEvent c = (QEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x0000858A File Offset: 0x0000678A
	internal QEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x00008594 File Offset: 0x00006794
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x060002B7 RID: 695 RVA: 0x000085CF File Offset: 0x000067CF
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x060002B8 RID: 696 RVA: 0x000085E1 File Offset: 0x000067E1
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x000085EC File Offset: 0x000067EC
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x060002BA RID: 698 RVA: 0x000085FF File Offset: 0x000067FF
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QEvent was null when calling " + n);
		}
	}

	// Token: 0x060002BB RID: 699 RVA: 0x0000861A File Offset: 0x0000681A
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x060002BC RID: 700 RVA: 0x00008628 File Offset: 0x00006828
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qevent_accept = QEvent.__N.QEvent_accept;
		calli(System.Void(System.IntPtr), this.self, qevent_accept);
	}

	// Token: 0x060002BD RID: 701 RVA: 0x00008654 File Offset: 0x00006854
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qevent_ignore = QEvent.__N.QEvent_ignore;
		calli(System.Void(System.IntPtr), this.self, qevent_ignore);
	}

	// Token: 0x060002BE RID: 702 RVA: 0x00008680 File Offset: 0x00006880
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qevent_isAccepted = QEvent.__N.QEvent_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qevent_isAccepted) > 0;
	}

	// Token: 0x060002BF RID: 703 RVA: 0x000086B0 File Offset: 0x000068B0
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qevent_spontaneous = QEvent.__N.QEvent_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qevent_spontaneous) > 0;
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x000086E0 File Offset: 0x000068E0
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qevent_setAccepted = QEvent.__N.QEvent_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qevent_setAccepted);
	}

	// Token: 0x0400001E RID: 30
	internal IntPtr self;

	// Token: 0x020000F3 RID: 243
	internal static class __N
	{
		// Token: 0x0400067A RID: 1658
		internal static method QEvent_accept;

		// Token: 0x0400067B RID: 1659
		internal static method QEvent_ignore;

		// Token: 0x0400067C RID: 1660
		internal static method QEvent_isAccepted;

		// Token: 0x0400067D RID: 1661
		internal static method QEvent_spontaneous;

		// Token: 0x0400067E RID: 1662
		internal static method QEvent_setAccepted;
	}
}
