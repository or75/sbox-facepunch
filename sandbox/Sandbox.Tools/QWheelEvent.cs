using System;
using System.Runtime.CompilerServices;
using Tools;

// Token: 0x02000031 RID: 49
internal struct QWheelEvent
{
	// Token: 0x06000445 RID: 1093 RVA: 0x0000BFF2 File Offset: 0x0000A1F2
	public static implicit operator IntPtr(QWheelEvent value)
	{
		return value.self;
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x0000BFFC File Offset: 0x0000A1FC
	public static implicit operator QWheelEvent(IntPtr value)
	{
		return new QWheelEvent
		{
			self = value
		};
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x0000C01A File Offset: 0x0000A21A
	public static bool operator ==(QWheelEvent c1, QWheelEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x0000C02D File Offset: 0x0000A22D
	public static bool operator !=(QWheelEvent c1, QWheelEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0000C040 File Offset: 0x0000A240
	public override bool Equals(object obj)
	{
		if (obj is QWheelEvent)
		{
			QWheelEvent c = (QWheelEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0000C06A File Offset: 0x0000A26A
	internal QWheelEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0000C074 File Offset: 0x0000A274
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QWheelEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x0600044C RID: 1100 RVA: 0x0000C0B0 File Offset: 0x0000A2B0
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x0600044D RID: 1101 RVA: 0x0000C0C2 File Offset: 0x0000A2C2
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600044E RID: 1102 RVA: 0x0000C0CD File Offset: 0x0000A2CD
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x0000C0E0 File Offset: 0x0000A2E0
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QWheelEvent was null when calling " + n);
		}
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x0000C0FB File Offset: 0x0000A2FB
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000451 RID: 1105 RVA: 0x0000C108 File Offset: 0x0000A308
	public static implicit operator QInputEvent(QWheelEvent value)
	{
		method to_QInputEvent_From_QWheelEvent = QWheelEvent.__N.To_QInputEvent_From_QWheelEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QInputEvent_From_QWheelEvent);
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x0000C12C File Offset: 0x0000A32C
	public static explicit operator QWheelEvent(QInputEvent value)
	{
		method from_QInputEvent_To_QWheelEvent = QWheelEvent.__N.From_QInputEvent_To_QWheelEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QInputEvent_To_QWheelEvent);
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x0000C150 File Offset: 0x0000A350
	public static implicit operator QEvent(QWheelEvent value)
	{
		method to_QEvent_From_QWheelEvent = QWheelEvent.__N.To_QEvent_From_QWheelEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QWheelEvent);
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x0000C174 File Offset: 0x0000A374
	public static explicit operator QWheelEvent(QEvent value)
	{
		method from_QEvent_To_QWheelEvent = QWheelEvent.__N.From_QEvent_To_QWheelEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QWheelEvent);
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x0000C198 File Offset: 0x0000A398
	internal readonly Vector3 pixelDelta()
	{
		this.NullCheck("pixelDelta");
		method qwheel_pixelDelta = QWheelEvent.__N.QWheel_pixelDelta;
		return calli(Vector3(System.IntPtr), this.self, qwheel_pixelDelta);
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x0000C1C4 File Offset: 0x0000A3C4
	internal readonly Vector3 angleDelta()
	{
		this.NullCheck("angleDelta");
		method qwheel_angleDelta = QWheelEvent.__N.QWheel_angleDelta;
		return calli(Vector3(System.IntPtr), this.self, qwheel_angleDelta);
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x0000C1F0 File Offset: 0x0000A3F0
	internal readonly Vector3 position()
	{
		this.NullCheck("position");
		method qwheel_position = QWheelEvent.__N.QWheel_position;
		return calli(Vector3(System.IntPtr), this.self, qwheel_position);
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x0000C21C File Offset: 0x0000A41C
	internal readonly Vector3 globalPosition()
	{
		this.NullCheck("globalPosition");
		method qwheel_globalPosition = QWheelEvent.__N.QWheel_globalPosition;
		return calli(Vector3(System.IntPtr), this.self, qwheel_globalPosition);
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x0000C248 File Offset: 0x0000A448
	internal readonly MouseButtons buttons()
	{
		this.NullCheck("buttons");
		method qwheel_buttons = QWheelEvent.__N.QWheel_buttons;
		return calli(System.Int64(System.IntPtr), this.self, qwheel_buttons);
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x0000C274 File Offset: 0x0000A474
	internal readonly KeyboardModifiers modifiers()
	{
		this.NullCheck("modifiers");
		method qwheel_modifiers = QWheelEvent.__N.QWheel_modifiers;
		return calli(System.Int64(System.IntPtr), this.self, qwheel_modifiers);
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x0000C2A0 File Offset: 0x0000A4A0
	internal readonly ulong timestamp()
	{
		this.NullCheck("timestamp");
		method qwheel_timestamp = QWheelEvent.__N.QWheel_timestamp;
		return calli(System.UInt64(System.IntPtr), this.self, qwheel_timestamp);
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x0000C2CC File Offset: 0x0000A4CC
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qwheel_accept = QWheelEvent.__N.QWheel_accept;
		calli(System.Void(System.IntPtr), this.self, qwheel_accept);
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x0000C2F8 File Offset: 0x0000A4F8
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qwheel_ignore = QWheelEvent.__N.QWheel_ignore;
		calli(System.Void(System.IntPtr), this.self, qwheel_ignore);
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x0000C324 File Offset: 0x0000A524
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qwheel_isAccepted = QWheelEvent.__N.QWheel_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qwheel_isAccepted) > 0;
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x0000C354 File Offset: 0x0000A554
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qwheel_spontaneous = QWheelEvent.__N.QWheel_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qwheel_spontaneous) > 0;
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x0000C384 File Offset: 0x0000A584
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qwheel_setAccepted = QWheelEvent.__N.QWheel_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qwheel_setAccepted);
	}

	// Token: 0x0400002B RID: 43
	internal IntPtr self;

	// Token: 0x02000101 RID: 257
	internal static class __N
	{
		// Token: 0x04000777 RID: 1911
		internal static method From_QInputEvent_To_QWheelEvent;

		// Token: 0x04000778 RID: 1912
		internal static method To_QInputEvent_From_QWheelEvent;

		// Token: 0x04000779 RID: 1913
		internal static method From_QEvent_To_QWheelEvent;

		// Token: 0x0400077A RID: 1914
		internal static method To_QEvent_From_QWheelEvent;

		// Token: 0x0400077B RID: 1915
		internal static method QWheel_pixelDelta;

		// Token: 0x0400077C RID: 1916
		internal static method QWheel_angleDelta;

		// Token: 0x0400077D RID: 1917
		internal static method QWheel_position;

		// Token: 0x0400077E RID: 1918
		internal static method QWheel_globalPosition;

		// Token: 0x0400077F RID: 1919
		internal static method QWheel_buttons;

		// Token: 0x04000780 RID: 1920
		internal static method QWheel_modifiers;

		// Token: 0x04000781 RID: 1921
		internal static method QWheel_timestamp;

		// Token: 0x04000782 RID: 1922
		internal static method QWheel_accept;

		// Token: 0x04000783 RID: 1923
		internal static method QWheel_ignore;

		// Token: 0x04000784 RID: 1924
		internal static method QWheel_isAccepted;

		// Token: 0x04000785 RID: 1925
		internal static method QWheel_spontaneous;

		// Token: 0x04000786 RID: 1926
		internal static method QWheel_setAccepted;
	}
}
