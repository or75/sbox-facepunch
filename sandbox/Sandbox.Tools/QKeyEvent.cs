using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

// Token: 0x02000029 RID: 41
internal struct QKeyEvent
{
	// Token: 0x06000377 RID: 887 RVA: 0x0000A345 File Offset: 0x00008545
	public static implicit operator IntPtr(QKeyEvent value)
	{
		return value.self;
	}

	// Token: 0x06000378 RID: 888 RVA: 0x0000A350 File Offset: 0x00008550
	public static implicit operator QKeyEvent(IntPtr value)
	{
		return new QKeyEvent
		{
			self = value
		};
	}

	// Token: 0x06000379 RID: 889 RVA: 0x0000A36E File Offset: 0x0000856E
	public static bool operator ==(QKeyEvent c1, QKeyEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600037A RID: 890 RVA: 0x0000A381 File Offset: 0x00008581
	public static bool operator !=(QKeyEvent c1, QKeyEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600037B RID: 891 RVA: 0x0000A394 File Offset: 0x00008594
	public override bool Equals(object obj)
	{
		if (obj is QKeyEvent)
		{
			QKeyEvent c = (QKeyEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600037C RID: 892 RVA: 0x0000A3BE File Offset: 0x000085BE
	internal QKeyEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600037D RID: 893 RVA: 0x0000A3C8 File Offset: 0x000085C8
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QKeyEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x0600037E RID: 894 RVA: 0x0000A404 File Offset: 0x00008604
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x0600037F RID: 895 RVA: 0x0000A416 File Offset: 0x00008616
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000380 RID: 896 RVA: 0x0000A421 File Offset: 0x00008621
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000381 RID: 897 RVA: 0x0000A434 File Offset: 0x00008634
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QKeyEvent was null when calling " + n);
		}
	}

	// Token: 0x06000382 RID: 898 RVA: 0x0000A44F File Offset: 0x0000864F
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000383 RID: 899 RVA: 0x0000A45C File Offset: 0x0000865C
	public static implicit operator QInputEvent(QKeyEvent value)
	{
		method to_QInputEvent_From_QKeyEvent = QKeyEvent.__N.To_QInputEvent_From_QKeyEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QInputEvent_From_QKeyEvent);
	}

	// Token: 0x06000384 RID: 900 RVA: 0x0000A480 File Offset: 0x00008680
	public static explicit operator QKeyEvent(QInputEvent value)
	{
		method from_QInputEvent_To_QKeyEvent = QKeyEvent.__N.From_QInputEvent_To_QKeyEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QInputEvent_To_QKeyEvent);
	}

	// Token: 0x06000385 RID: 901 RVA: 0x0000A4A4 File Offset: 0x000086A4
	public static implicit operator QEvent(QKeyEvent value)
	{
		method to_QEvent_From_QKeyEvent = QKeyEvent.__N.To_QEvent_From_QKeyEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QKeyEvent);
	}

	// Token: 0x06000386 RID: 902 RVA: 0x0000A4C8 File Offset: 0x000086C8
	public static explicit operator QKeyEvent(QEvent value)
	{
		method from_QEvent_To_QKeyEvent = QKeyEvent.__N.From_QEvent_To_QKeyEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QKeyEvent);
	}

	// Token: 0x06000387 RID: 903 RVA: 0x0000A4EC File Offset: 0x000086EC
	internal readonly string text()
	{
		this.NullCheck("text");
		method qkeyEv_text = QKeyEvent.__N.QKeyEv_text;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qkeyEv_text));
	}

	// Token: 0x06000388 RID: 904 RVA: 0x0000A51C File Offset: 0x0000871C
	internal readonly bool isAutoRepeat()
	{
		this.NullCheck("isAutoRepeat");
		method qkeyEv_isAutoRepeat = QKeyEvent.__N.QKeyEv_isAutoRepeat;
		return calli(System.Int32(System.IntPtr), this.self, qkeyEv_isAutoRepeat) > 0;
	}

	// Token: 0x06000389 RID: 905 RVA: 0x0000A54C File Offset: 0x0000874C
	internal readonly int count()
	{
		this.NullCheck("count");
		method qkeyEv_count = QKeyEvent.__N.QKeyEv_count;
		return calli(System.Int32(System.IntPtr), this.self, qkeyEv_count);
	}

	// Token: 0x0600038A RID: 906 RVA: 0x0000A578 File Offset: 0x00008778
	internal readonly int key()
	{
		this.NullCheck("key");
		method qkeyEv_key = QKeyEvent.__N.QKeyEv_key;
		return calli(System.Int32(System.IntPtr), this.self, qkeyEv_key);
	}

	// Token: 0x0600038B RID: 907 RVA: 0x0000A5A4 File Offset: 0x000087A4
	internal readonly KeyboardModifiers modifiers()
	{
		this.NullCheck("modifiers");
		method qkeyEv_modifiers = QKeyEvent.__N.QKeyEv_modifiers;
		return calli(System.Int64(System.IntPtr), this.self, qkeyEv_modifiers);
	}

	// Token: 0x0600038C RID: 908 RVA: 0x0000A5D0 File Offset: 0x000087D0
	internal readonly ulong timestamp()
	{
		this.NullCheck("timestamp");
		method qkeyEv_timestamp = QKeyEvent.__N.QKeyEv_timestamp;
		return calli(System.UInt64(System.IntPtr), this.self, qkeyEv_timestamp);
	}

	// Token: 0x0600038D RID: 909 RVA: 0x0000A5FC File Offset: 0x000087FC
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qkeyEv_accept = QKeyEvent.__N.QKeyEv_accept;
		calli(System.Void(System.IntPtr), this.self, qkeyEv_accept);
	}

	// Token: 0x0600038E RID: 910 RVA: 0x0000A628 File Offset: 0x00008828
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qkeyEv_ignore = QKeyEvent.__N.QKeyEv_ignore;
		calli(System.Void(System.IntPtr), this.self, qkeyEv_ignore);
	}

	// Token: 0x0600038F RID: 911 RVA: 0x0000A654 File Offset: 0x00008854
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qkeyEv_isAccepted = QKeyEvent.__N.QKeyEv_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qkeyEv_isAccepted) > 0;
	}

	// Token: 0x06000390 RID: 912 RVA: 0x0000A684 File Offset: 0x00008884
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qkeyEv_spontaneous = QKeyEvent.__N.QKeyEv_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qkeyEv_spontaneous) > 0;
	}

	// Token: 0x06000391 RID: 913 RVA: 0x0000A6B4 File Offset: 0x000088B4
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qkeyEv_setAccepted = QKeyEvent.__N.QKeyEv_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qkeyEv_setAccepted);
	}

	// Token: 0x04000023 RID: 35
	internal IntPtr self;

	// Token: 0x020000F9 RID: 249
	internal static class __N
	{
		// Token: 0x04000705 RID: 1797
		internal static method From_QInputEvent_To_QKeyEvent;

		// Token: 0x04000706 RID: 1798
		internal static method To_QInputEvent_From_QKeyEvent;

		// Token: 0x04000707 RID: 1799
		internal static method From_QEvent_To_QKeyEvent;

		// Token: 0x04000708 RID: 1800
		internal static method To_QEvent_From_QKeyEvent;

		// Token: 0x04000709 RID: 1801
		internal static method QKeyEv_text;

		// Token: 0x0400070A RID: 1802
		internal static method QKeyEv_isAutoRepeat;

		// Token: 0x0400070B RID: 1803
		internal static method QKeyEv_count;

		// Token: 0x0400070C RID: 1804
		internal static method QKeyEv_key;

		// Token: 0x0400070D RID: 1805
		internal static method QKeyEv_modifiers;

		// Token: 0x0400070E RID: 1806
		internal static method QKeyEv_timestamp;

		// Token: 0x0400070F RID: 1807
		internal static method QKeyEv_accept;

		// Token: 0x04000710 RID: 1808
		internal static method QKeyEv_ignore;

		// Token: 0x04000711 RID: 1809
		internal static method QKeyEv_isAccepted;

		// Token: 0x04000712 RID: 1810
		internal static method QKeyEv_spontaneous;

		// Token: 0x04000713 RID: 1811
		internal static method QKeyEv_setAccepted;
	}
}
