using System;
using System.Runtime.CompilerServices;
using Native;
using Tools;

// Token: 0x02000027 RID: 39
internal struct QGraphicsSceneMouseEvent
{
	// Token: 0x0600034A RID: 842 RVA: 0x00009D7D File Offset: 0x00007F7D
	public static implicit operator IntPtr(QGraphicsSceneMouseEvent value)
	{
		return value.self;
	}

	// Token: 0x0600034B RID: 843 RVA: 0x00009D88 File Offset: 0x00007F88
	public static implicit operator QGraphicsSceneMouseEvent(IntPtr value)
	{
		return new QGraphicsSceneMouseEvent
		{
			self = value
		};
	}

	// Token: 0x0600034C RID: 844 RVA: 0x00009DA6 File Offset: 0x00007FA6
	public static bool operator ==(QGraphicsSceneMouseEvent c1, QGraphicsSceneMouseEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600034D RID: 845 RVA: 0x00009DB9 File Offset: 0x00007FB9
	public static bool operator !=(QGraphicsSceneMouseEvent c1, QGraphicsSceneMouseEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600034E RID: 846 RVA: 0x00009DCC File Offset: 0x00007FCC
	public override bool Equals(object obj)
	{
		if (obj is QGraphicsSceneMouseEvent)
		{
			QGraphicsSceneMouseEvent c = (QGraphicsSceneMouseEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600034F RID: 847 RVA: 0x00009DF6 File Offset: 0x00007FF6
	internal QGraphicsSceneMouseEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000350 RID: 848 RVA: 0x00009E00 File Offset: 0x00008000
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QGraphicsSceneMouseEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000035 RID: 53
	// (get) Token: 0x06000351 RID: 849 RVA: 0x00009E3C File Offset: 0x0000803C
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x06000352 RID: 850 RVA: 0x00009E4E File Offset: 0x0000804E
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000353 RID: 851 RVA: 0x00009E59 File Offset: 0x00008059
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000354 RID: 852 RVA: 0x00009E6C File Offset: 0x0000806C
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QGraphicsSceneMouseEvent was null when calling " + n);
		}
	}

	// Token: 0x06000355 RID: 853 RVA: 0x00009E87 File Offset: 0x00008087
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000356 RID: 854 RVA: 0x00009E94 File Offset: 0x00008094
	public static implicit operator QEvent(QGraphicsSceneMouseEvent value)
	{
		method to_QEvent_From_QGraphicsSceneMouseEvent = QGraphicsSceneMouseEvent.__N.To_QEvent_From_QGraphicsSceneMouseEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QGraphicsSceneMouseEvent);
	}

	// Token: 0x06000357 RID: 855 RVA: 0x00009EB8 File Offset: 0x000080B8
	public static explicit operator QGraphicsSceneMouseEvent(QEvent value)
	{
		method from_QEvent_To_QGraphicsSceneMouseEvent = QGraphicsSceneMouseEvent.__N.From_QEvent_To_QGraphicsSceneMouseEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QGraphicsSceneMouseEvent);
	}

	// Token: 0x06000358 RID: 856 RVA: 0x00009EDC File Offset: 0x000080DC
	internal readonly QWidget widget()
	{
		this.NullCheck("widget");
		method qgrphc_f = QGraphicsSceneMouseEvent.__N.QGrphc_f40;
		return calli(System.IntPtr(System.IntPtr), this.self, qgrphc_f);
	}

	// Token: 0x06000359 RID: 857 RVA: 0x00009F0C File Offset: 0x0000810C
	internal readonly Vector3 pos()
	{
		this.NullCheck("pos");
		method qgrphc_f = QGraphicsSceneMouseEvent.__N.QGrphc_f41;
		return calli(Vector3(System.IntPtr), this.self, qgrphc_f);
	}

	// Token: 0x0600035A RID: 858 RVA: 0x00009F38 File Offset: 0x00008138
	internal readonly Vector3 scenePos()
	{
		this.NullCheck("scenePos");
		method qgrphc_f = QGraphicsSceneMouseEvent.__N.QGrphc_f42;
		return calli(Vector3(System.IntPtr), this.self, qgrphc_f);
	}

	// Token: 0x0600035B RID: 859 RVA: 0x00009F64 File Offset: 0x00008164
	internal readonly Vector3 screenPos()
	{
		this.NullCheck("screenPos");
		method qgrphc_f = QGraphicsSceneMouseEvent.__N.QGrphc_f43;
		return calli(Vector3(System.IntPtr), this.self, qgrphc_f);
	}

	// Token: 0x0600035C RID: 860 RVA: 0x00009F90 File Offset: 0x00008190
	internal readonly MouseButtons buttons()
	{
		this.NullCheck("buttons");
		method qgrphc_buttons = QGraphicsSceneMouseEvent.__N.QGrphc_buttons;
		return calli(System.Int64(System.IntPtr), this.self, qgrphc_buttons);
	}

	// Token: 0x0600035D RID: 861 RVA: 0x00009FBC File Offset: 0x000081BC
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qgrphc_f = QGraphicsSceneMouseEvent.__N.QGrphc_f44;
		calli(System.Void(System.IntPtr), this.self, qgrphc_f);
	}

	// Token: 0x0600035E RID: 862 RVA: 0x00009FE8 File Offset: 0x000081E8
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qgrphc_f = QGraphicsSceneMouseEvent.__N.QGrphc_f45;
		calli(System.Void(System.IntPtr), this.self, qgrphc_f);
	}

	// Token: 0x0600035F RID: 863 RVA: 0x0000A014 File Offset: 0x00008214
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qgrphc_f = QGraphicsSceneMouseEvent.__N.QGrphc_f46;
		return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
	}

	// Token: 0x06000360 RID: 864 RVA: 0x0000A044 File Offset: 0x00008244
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qgrphc_f = QGraphicsSceneMouseEvent.__N.QGrphc_f47;
		return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
	}

	// Token: 0x06000361 RID: 865 RVA: 0x0000A074 File Offset: 0x00008274
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qgrphc_f = QGraphicsSceneMouseEvent.__N.QGrphc_f48;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qgrphc_f);
	}

	// Token: 0x04000021 RID: 33
	internal IntPtr self;

	// Token: 0x020000F7 RID: 247
	internal static class __N
	{
		// Token: 0x040006F0 RID: 1776
		internal static method From_QEvent_To_QGraphicsSceneMouseEvent;

		// Token: 0x040006F1 RID: 1777
		internal static method To_QEvent_From_QGraphicsSceneMouseEvent;

		// Token: 0x040006F2 RID: 1778
		internal static method QGrphc_f40;

		// Token: 0x040006F3 RID: 1779
		internal static method QGrphc_f41;

		// Token: 0x040006F4 RID: 1780
		internal static method QGrphc_f42;

		// Token: 0x040006F5 RID: 1781
		internal static method QGrphc_f43;

		// Token: 0x040006F6 RID: 1782
		internal static method QGrphc_buttons;

		// Token: 0x040006F7 RID: 1783
		internal static method QGrphc_f44;

		// Token: 0x040006F8 RID: 1784
		internal static method QGrphc_f45;

		// Token: 0x040006F9 RID: 1785
		internal static method QGrphc_f46;

		// Token: 0x040006FA RID: 1786
		internal static method QGrphc_f47;

		// Token: 0x040006FB RID: 1787
		internal static method QGrphc_f48;
	}
}
