using System;
using System.Runtime.CompilerServices;
using Tools;

// Token: 0x0200002B RID: 43
internal struct QMouseEvent
{
	// Token: 0x060003AC RID: 940 RVA: 0x0000AA72 File Offset: 0x00008C72
	public static implicit operator IntPtr(QMouseEvent value)
	{
		return value.self;
	}

	// Token: 0x060003AD RID: 941 RVA: 0x0000AA7C File Offset: 0x00008C7C
	public static implicit operator QMouseEvent(IntPtr value)
	{
		return new QMouseEvent
		{
			self = value
		};
	}

	// Token: 0x060003AE RID: 942 RVA: 0x0000AA9A File Offset: 0x00008C9A
	public static bool operator ==(QMouseEvent c1, QMouseEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x060003AF RID: 943 RVA: 0x0000AAAD File Offset: 0x00008CAD
	public static bool operator !=(QMouseEvent c1, QMouseEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x0000AAC0 File Offset: 0x00008CC0
	public override bool Equals(object obj)
	{
		if (obj is QMouseEvent)
		{
			QMouseEvent c = (QMouseEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x060003B1 RID: 945 RVA: 0x0000AAEA File Offset: 0x00008CEA
	internal QMouseEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x060003B2 RID: 946 RVA: 0x0000AAF4 File Offset: 0x00008CF4
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QMouseEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x060003B3 RID: 947 RVA: 0x0000AB30 File Offset: 0x00008D30
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x060003B4 RID: 948 RVA: 0x0000AB42 File Offset: 0x00008D42
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x0000AB4D File Offset: 0x00008D4D
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x0000AB60 File Offset: 0x00008D60
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QMouseEvent was null when calling " + n);
		}
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x0000AB7B File Offset: 0x00008D7B
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x0000AB88 File Offset: 0x00008D88
	public static implicit operator QInputEvent(QMouseEvent value)
	{
		method to_QInputEvent_From_QMouseEvent = QMouseEvent.__N.To_QInputEvent_From_QMouseEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QInputEvent_From_QMouseEvent);
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x0000ABAC File Offset: 0x00008DAC
	public static explicit operator QMouseEvent(QInputEvent value)
	{
		method from_QInputEvent_To_QMouseEvent = QMouseEvent.__N.From_QInputEvent_To_QMouseEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QInputEvent_To_QMouseEvent);
	}

	// Token: 0x060003BA RID: 954 RVA: 0x0000ABD0 File Offset: 0x00008DD0
	public static implicit operator QEvent(QMouseEvent value)
	{
		method to_QEvent_From_QMouseEvent = QMouseEvent.__N.To_QEvent_From_QMouseEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QMouseEvent);
	}

	// Token: 0x060003BB RID: 955 RVA: 0x0000ABF4 File Offset: 0x00008DF4
	public static explicit operator QMouseEvent(QEvent value)
	{
		method from_QEvent_To_QMouseEvent = QMouseEvent.__N.From_QEvent_To_QMouseEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QMouseEvent);
	}

	// Token: 0x060003BC RID: 956 RVA: 0x0000AC18 File Offset: 0x00008E18
	internal readonly Vector3 localPos()
	{
		this.NullCheck("localPos");
		method qmseEv_localPos = QMouseEvent.__N.QMseEv_localPos;
		return calli(Vector3(System.IntPtr), this.self, qmseEv_localPos);
	}

	// Token: 0x060003BD RID: 957 RVA: 0x0000AC44 File Offset: 0x00008E44
	internal readonly Vector3 windowPos()
	{
		this.NullCheck("windowPos");
		method qmseEv_windowPos = QMouseEvent.__N.QMseEv_windowPos;
		return calli(Vector3(System.IntPtr), this.self, qmseEv_windowPos);
	}

	// Token: 0x060003BE RID: 958 RVA: 0x0000AC70 File Offset: 0x00008E70
	internal readonly Vector3 screenPos()
	{
		this.NullCheck("screenPos");
		method qmseEv_screenPos = QMouseEvent.__N.QMseEv_screenPos;
		return calli(Vector3(System.IntPtr), this.self, qmseEv_screenPos);
	}

	// Token: 0x060003BF RID: 959 RVA: 0x0000AC9C File Offset: 0x00008E9C
	internal readonly MouseButtons buttons()
	{
		this.NullCheck("buttons");
		method qmseEv_buttons = QMouseEvent.__N.QMseEv_buttons;
		return calli(System.Int64(System.IntPtr), this.self, qmseEv_buttons);
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x0000ACC8 File Offset: 0x00008EC8
	internal readonly MouseButtons button()
	{
		this.NullCheck("button");
		method qmseEv_button = QMouseEvent.__N.QMseEv_button;
		return calli(System.Int64(System.IntPtr), this.self, qmseEv_button);
	}

	// Token: 0x060003C1 RID: 961 RVA: 0x0000ACF4 File Offset: 0x00008EF4
	internal readonly KeyboardModifiers modifiers()
	{
		this.NullCheck("modifiers");
		method qmseEv_modifiers = QMouseEvent.__N.QMseEv_modifiers;
		return calli(System.Int64(System.IntPtr), this.self, qmseEv_modifiers);
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x0000AD20 File Offset: 0x00008F20
	internal readonly ulong timestamp()
	{
		this.NullCheck("timestamp");
		method qmseEv_timestamp = QMouseEvent.__N.QMseEv_timestamp;
		return calli(System.UInt64(System.IntPtr), this.self, qmseEv_timestamp);
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x0000AD4C File Offset: 0x00008F4C
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qmseEv_accept = QMouseEvent.__N.QMseEv_accept;
		calli(System.Void(System.IntPtr), this.self, qmseEv_accept);
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x0000AD78 File Offset: 0x00008F78
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qmseEv_ignore = QMouseEvent.__N.QMseEv_ignore;
		calli(System.Void(System.IntPtr), this.self, qmseEv_ignore);
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x0000ADA4 File Offset: 0x00008FA4
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qmseEv_isAccepted = QMouseEvent.__N.QMseEv_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qmseEv_isAccepted) > 0;
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x0000ADD4 File Offset: 0x00008FD4
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qmseEv_spontaneous = QMouseEvent.__N.QMseEv_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qmseEv_spontaneous) > 0;
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x0000AE04 File Offset: 0x00009004
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qmseEv_setAccepted = QMouseEvent.__N.QMseEv_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qmseEv_setAccepted);
	}

	// Token: 0x04000025 RID: 37
	internal IntPtr self;

	// Token: 0x020000FB RID: 251
	internal static class __N
	{
		// Token: 0x04000722 RID: 1826
		internal static method From_QInputEvent_To_QMouseEvent;

		// Token: 0x04000723 RID: 1827
		internal static method To_QInputEvent_From_QMouseEvent;

		// Token: 0x04000724 RID: 1828
		internal static method From_QEvent_To_QMouseEvent;

		// Token: 0x04000725 RID: 1829
		internal static method To_QEvent_From_QMouseEvent;

		// Token: 0x04000726 RID: 1830
		internal static method QMseEv_localPos;

		// Token: 0x04000727 RID: 1831
		internal static method QMseEv_windowPos;

		// Token: 0x04000728 RID: 1832
		internal static method QMseEv_screenPos;

		// Token: 0x04000729 RID: 1833
		internal static method QMseEv_buttons;

		// Token: 0x0400072A RID: 1834
		internal static method QMseEv_button;

		// Token: 0x0400072B RID: 1835
		internal static method QMseEv_modifiers;

		// Token: 0x0400072C RID: 1836
		internal static method QMseEv_timestamp;

		// Token: 0x0400072D RID: 1837
		internal static method QMseEv_accept;

		// Token: 0x0400072E RID: 1838
		internal static method QMseEv_ignore;

		// Token: 0x0400072F RID: 1839
		internal static method QMseEv_isAccepted;

		// Token: 0x04000730 RID: 1840
		internal static method QMseEv_spontaneous;

		// Token: 0x04000731 RID: 1841
		internal static method QMseEv_setAccepted;
	}
}
