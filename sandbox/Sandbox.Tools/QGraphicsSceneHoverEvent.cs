using System;
using System.Runtime.CompilerServices;

// Token: 0x02000026 RID: 38
internal struct QGraphicsSceneHoverEvent
{
	// Token: 0x06000334 RID: 820 RVA: 0x00009AB3 File Offset: 0x00007CB3
	public static implicit operator IntPtr(QGraphicsSceneHoverEvent value)
	{
		return value.self;
	}

	// Token: 0x06000335 RID: 821 RVA: 0x00009ABC File Offset: 0x00007CBC
	public static implicit operator QGraphicsSceneHoverEvent(IntPtr value)
	{
		return new QGraphicsSceneHoverEvent
		{
			self = value
		};
	}

	// Token: 0x06000336 RID: 822 RVA: 0x00009ADA File Offset: 0x00007CDA
	public static bool operator ==(QGraphicsSceneHoverEvent c1, QGraphicsSceneHoverEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000337 RID: 823 RVA: 0x00009AED File Offset: 0x00007CED
	public static bool operator !=(QGraphicsSceneHoverEvent c1, QGraphicsSceneHoverEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000338 RID: 824 RVA: 0x00009B00 File Offset: 0x00007D00
	public override bool Equals(object obj)
	{
		if (obj is QGraphicsSceneHoverEvent)
		{
			QGraphicsSceneHoverEvent c = (QGraphicsSceneHoverEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000339 RID: 825 RVA: 0x00009B2A File Offset: 0x00007D2A
	internal QGraphicsSceneHoverEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600033A RID: 826 RVA: 0x00009B34 File Offset: 0x00007D34
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QGraphicsSceneHoverEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x0600033B RID: 827 RVA: 0x00009B70 File Offset: 0x00007D70
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x0600033C RID: 828 RVA: 0x00009B82 File Offset: 0x00007D82
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600033D RID: 829 RVA: 0x00009B8D File Offset: 0x00007D8D
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600033E RID: 830 RVA: 0x00009BA0 File Offset: 0x00007DA0
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QGraphicsSceneHoverEvent was null when calling " + n);
		}
	}

	// Token: 0x0600033F RID: 831 RVA: 0x00009BBB File Offset: 0x00007DBB
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000340 RID: 832 RVA: 0x00009BC8 File Offset: 0x00007DC8
	public static implicit operator QEvent(QGraphicsSceneHoverEvent value)
	{
		method to_QEvent_From_QGraphicsSceneHoverEvent = QGraphicsSceneHoverEvent.__N.To_QEvent_From_QGraphicsSceneHoverEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QGraphicsSceneHoverEvent);
	}

	// Token: 0x06000341 RID: 833 RVA: 0x00009BEC File Offset: 0x00007DEC
	public static explicit operator QGraphicsSceneHoverEvent(QEvent value)
	{
		method from_QEvent_To_QGraphicsSceneHoverEvent = QGraphicsSceneHoverEvent.__N.From_QEvent_To_QGraphicsSceneHoverEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QGraphicsSceneHoverEvent);
	}

	// Token: 0x06000342 RID: 834 RVA: 0x00009C10 File Offset: 0x00007E10
	internal readonly Vector3 pos()
	{
		this.NullCheck("pos");
		method qgrphc_f = QGraphicsSceneHoverEvent.__N.QGrphc_f39;
		return calli(Vector3(System.IntPtr), this.self, qgrphc_f);
	}

	// Token: 0x06000343 RID: 835 RVA: 0x00009C3C File Offset: 0x00007E3C
	internal readonly Vector3 scenePos()
	{
		this.NullCheck("scenePos");
		method qgrphc_scenePos = QGraphicsSceneHoverEvent.__N.QGrphc_scenePos;
		return calli(Vector3(System.IntPtr), this.self, qgrphc_scenePos);
	}

	// Token: 0x06000344 RID: 836 RVA: 0x00009C68 File Offset: 0x00007E68
	internal readonly Vector3 screenPos()
	{
		this.NullCheck("screenPos");
		method qgrphc_screenPos = QGraphicsSceneHoverEvent.__N.QGrphc_screenPos;
		return calli(Vector3(System.IntPtr), this.self, qgrphc_screenPos);
	}

	// Token: 0x06000345 RID: 837 RVA: 0x00009C94 File Offset: 0x00007E94
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qgrphc_accept = QGraphicsSceneHoverEvent.__N.QGrphc_accept;
		calli(System.Void(System.IntPtr), this.self, qgrphc_accept);
	}

	// Token: 0x06000346 RID: 838 RVA: 0x00009CC0 File Offset: 0x00007EC0
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qgrphc_ignore = QGraphicsSceneHoverEvent.__N.QGrphc_ignore;
		calli(System.Void(System.IntPtr), this.self, qgrphc_ignore);
	}

	// Token: 0x06000347 RID: 839 RVA: 0x00009CEC File Offset: 0x00007EEC
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qgrphc_isAccepted = QGraphicsSceneHoverEvent.__N.QGrphc_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qgrphc_isAccepted) > 0;
	}

	// Token: 0x06000348 RID: 840 RVA: 0x00009D1C File Offset: 0x00007F1C
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qgrphc_spontaneous = QGraphicsSceneHoverEvent.__N.QGrphc_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qgrphc_spontaneous) > 0;
	}

	// Token: 0x06000349 RID: 841 RVA: 0x00009D4C File Offset: 0x00007F4C
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qgrphc_setAccepted = QGraphicsSceneHoverEvent.__N.QGrphc_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qgrphc_setAccepted);
	}

	// Token: 0x04000020 RID: 32
	internal IntPtr self;

	// Token: 0x020000F6 RID: 246
	internal static class __N
	{
		// Token: 0x040006E6 RID: 1766
		internal static method From_QEvent_To_QGraphicsSceneHoverEvent;

		// Token: 0x040006E7 RID: 1767
		internal static method To_QEvent_From_QGraphicsSceneHoverEvent;

		// Token: 0x040006E8 RID: 1768
		internal static method QGrphc_f39;

		// Token: 0x040006E9 RID: 1769
		internal static method QGrphc_scenePos;

		// Token: 0x040006EA RID: 1770
		internal static method QGrphc_screenPos;

		// Token: 0x040006EB RID: 1771
		internal static method QGrphc_accept;

		// Token: 0x040006EC RID: 1772
		internal static method QGrphc_ignore;

		// Token: 0x040006ED RID: 1773
		internal static method QGrphc_isAccepted;

		// Token: 0x040006EE RID: 1774
		internal static method QGrphc_spontaneous;

		// Token: 0x040006EF RID: 1775
		internal static method QGrphc_setAccepted;
	}
}
