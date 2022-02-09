using System;
using System.Runtime.CompilerServices;

// Token: 0x02000020 RID: 32
internal struct QDragLeaveEvent
{
	// Token: 0x06000267 RID: 615 RVA: 0x00007B79 File Offset: 0x00005D79
	public static implicit operator IntPtr(QDragLeaveEvent value)
	{
		return value.self;
	}

	// Token: 0x06000268 RID: 616 RVA: 0x00007B84 File Offset: 0x00005D84
	public static implicit operator QDragLeaveEvent(IntPtr value)
	{
		return new QDragLeaveEvent
		{
			self = value
		};
	}

	// Token: 0x06000269 RID: 617 RVA: 0x00007BA2 File Offset: 0x00005DA2
	public static bool operator ==(QDragLeaveEvent c1, QDragLeaveEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600026A RID: 618 RVA: 0x00007BB5 File Offset: 0x00005DB5
	public static bool operator !=(QDragLeaveEvent c1, QDragLeaveEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600026B RID: 619 RVA: 0x00007BC8 File Offset: 0x00005DC8
	public override bool Equals(object obj)
	{
		if (obj is QDragLeaveEvent)
		{
			QDragLeaveEvent c = (QDragLeaveEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600026C RID: 620 RVA: 0x00007BF2 File Offset: 0x00005DF2
	internal QDragLeaveEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00007BFC File Offset: 0x00005DFC
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QDragLeaveEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x0600026E RID: 622 RVA: 0x00007C38 File Offset: 0x00005E38
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x0600026F RID: 623 RVA: 0x00007C4A File Offset: 0x00005E4A
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000270 RID: 624 RVA: 0x00007C55 File Offset: 0x00005E55
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000271 RID: 625 RVA: 0x00007C68 File Offset: 0x00005E68
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QDragLeaveEvent was null when calling " + n);
		}
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00007C83 File Offset: 0x00005E83
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000273 RID: 627 RVA: 0x00007C90 File Offset: 0x00005E90
	public static implicit operator QEvent(QDragLeaveEvent value)
	{
		method to_QEvent_From_QDragLeaveEvent = QDragLeaveEvent.__N.To_QEvent_From_QDragLeaveEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QDragLeaveEvent);
	}

	// Token: 0x06000274 RID: 628 RVA: 0x00007CB4 File Offset: 0x00005EB4
	public static explicit operator QDragLeaveEvent(QEvent value)
	{
		method from_QEvent_To_QDragLeaveEvent = QDragLeaveEvent.__N.From_QEvent_To_QDragLeaveEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QDragLeaveEvent);
	}

	// Token: 0x06000275 RID: 629 RVA: 0x00007CD8 File Offset: 0x00005ED8
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qdrgLe_accept = QDragLeaveEvent.__N.QDrgLe_accept;
		calli(System.Void(System.IntPtr), this.self, qdrgLe_accept);
	}

	// Token: 0x06000276 RID: 630 RVA: 0x00007D04 File Offset: 0x00005F04
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qdrgLe_ignore = QDragLeaveEvent.__N.QDrgLe_ignore;
		calli(System.Void(System.IntPtr), this.self, qdrgLe_ignore);
	}

	// Token: 0x06000277 RID: 631 RVA: 0x00007D30 File Offset: 0x00005F30
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qdrgLe_isAccepted = QDragLeaveEvent.__N.QDrgLe_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qdrgLe_isAccepted) > 0;
	}

	// Token: 0x06000278 RID: 632 RVA: 0x00007D60 File Offset: 0x00005F60
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qdrgLe_spontaneous = QDragLeaveEvent.__N.QDrgLe_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qdrgLe_spontaneous) > 0;
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00007D90 File Offset: 0x00005F90
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qdrgLe_setAccepted = QDragLeaveEvent.__N.QDrgLe_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qdrgLe_setAccepted);
	}

	// Token: 0x0400001B RID: 27
	internal IntPtr self;

	// Token: 0x020000F0 RID: 240
	internal static class __N
	{
		// Token: 0x04000655 RID: 1621
		internal static method From_QEvent_To_QDragLeaveEvent;

		// Token: 0x04000656 RID: 1622
		internal static method To_QEvent_From_QDragLeaveEvent;

		// Token: 0x04000657 RID: 1623
		internal static method QDrgLe_accept;

		// Token: 0x04000658 RID: 1624
		internal static method QDrgLe_ignore;

		// Token: 0x04000659 RID: 1625
		internal static method QDrgLe_isAccepted;

		// Token: 0x0400065A RID: 1626
		internal static method QDrgLe_spontaneous;

		// Token: 0x0400065B RID: 1627
		internal static method QDrgLe_setAccepted;
	}
}
