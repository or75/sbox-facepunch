using System;
using System.Runtime.CompilerServices;
using Tools;

// Token: 0x0200001D RID: 29
internal struct QContextMenuEvent
{
	// Token: 0x06000216 RID: 534 RVA: 0x0000708F File Offset: 0x0000528F
	public static implicit operator IntPtr(QContextMenuEvent value)
	{
		return value.self;
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00007098 File Offset: 0x00005298
	public static implicit operator QContextMenuEvent(IntPtr value)
	{
		return new QContextMenuEvent
		{
			self = value
		};
	}

	// Token: 0x06000218 RID: 536 RVA: 0x000070B6 File Offset: 0x000052B6
	public static bool operator ==(QContextMenuEvent c1, QContextMenuEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000219 RID: 537 RVA: 0x000070C9 File Offset: 0x000052C9
	public static bool operator !=(QContextMenuEvent c1, QContextMenuEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600021A RID: 538 RVA: 0x000070DC File Offset: 0x000052DC
	public override bool Equals(object obj)
	{
		if (obj is QContextMenuEvent)
		{
			QContextMenuEvent c = (QContextMenuEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600021B RID: 539 RVA: 0x00007106 File Offset: 0x00005306
	internal QContextMenuEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600021C RID: 540 RVA: 0x00007110 File Offset: 0x00005310
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QContextMenuEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x0600021D RID: 541 RVA: 0x0000714C File Offset: 0x0000534C
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x0600021E RID: 542 RVA: 0x0000715E File Offset: 0x0000535E
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600021F RID: 543 RVA: 0x00007169 File Offset: 0x00005369
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000220 RID: 544 RVA: 0x0000717C File Offset: 0x0000537C
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QContextMenuEvent was null when calling " + n);
		}
	}

	// Token: 0x06000221 RID: 545 RVA: 0x00007197 File Offset: 0x00005397
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000222 RID: 546 RVA: 0x000071A4 File Offset: 0x000053A4
	public static implicit operator QInputEvent(QContextMenuEvent value)
	{
		method to_QInputEvent_From_QContextMenuEvent = QContextMenuEvent.__N.To_QInputEvent_From_QContextMenuEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QInputEvent_From_QContextMenuEvent);
	}

	// Token: 0x06000223 RID: 547 RVA: 0x000071C8 File Offset: 0x000053C8
	public static explicit operator QContextMenuEvent(QInputEvent value)
	{
		method from_QInputEvent_To_QContextMenuEvent = QContextMenuEvent.__N.From_QInputEvent_To_QContextMenuEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QInputEvent_To_QContextMenuEvent);
	}

	// Token: 0x06000224 RID: 548 RVA: 0x000071EC File Offset: 0x000053EC
	public static implicit operator QEvent(QContextMenuEvent value)
	{
		method to_QEvent_From_QContextMenuEvent = QContextMenuEvent.__N.To_QEvent_From_QContextMenuEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QContextMenuEvent);
	}

	// Token: 0x06000225 RID: 549 RVA: 0x00007210 File Offset: 0x00005410
	public static explicit operator QContextMenuEvent(QEvent value)
	{
		method from_QEvent_To_QContextMenuEvent = QContextMenuEvent.__N.From_QEvent_To_QContextMenuEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QContextMenuEvent);
	}

	// Token: 0x06000226 RID: 550 RVA: 0x00007234 File Offset: 0x00005434
	internal readonly Vector3 pos()
	{
		this.NullCheck("pos");
		method qcntex_pos = QContextMenuEvent.__N.QCntex_pos;
		return calli(Vector3(System.IntPtr), this.self, qcntex_pos);
	}

	// Token: 0x06000227 RID: 551 RVA: 0x00007260 File Offset: 0x00005460
	internal readonly Vector3 globalPos()
	{
		this.NullCheck("globalPos");
		method qcntex_globalPos = QContextMenuEvent.__N.QCntex_globalPos;
		return calli(Vector3(System.IntPtr), this.self, qcntex_globalPos);
	}

	// Token: 0x06000228 RID: 552 RVA: 0x0000728C File Offset: 0x0000548C
	internal readonly KeyboardModifiers modifiers()
	{
		this.NullCheck("modifiers");
		method qcntex_modifiers = QContextMenuEvent.__N.QCntex_modifiers;
		return calli(System.Int64(System.IntPtr), this.self, qcntex_modifiers);
	}

	// Token: 0x06000229 RID: 553 RVA: 0x000072B8 File Offset: 0x000054B8
	internal readonly ulong timestamp()
	{
		this.NullCheck("timestamp");
		method qcntex_timestamp = QContextMenuEvent.__N.QCntex_timestamp;
		return calli(System.UInt64(System.IntPtr), this.self, qcntex_timestamp);
	}

	// Token: 0x0600022A RID: 554 RVA: 0x000072E4 File Offset: 0x000054E4
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qcntex_accept = QContextMenuEvent.__N.QCntex_accept;
		calli(System.Void(System.IntPtr), this.self, qcntex_accept);
	}

	// Token: 0x0600022B RID: 555 RVA: 0x00007310 File Offset: 0x00005510
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qcntex_ignore = QContextMenuEvent.__N.QCntex_ignore;
		calli(System.Void(System.IntPtr), this.self, qcntex_ignore);
	}

	// Token: 0x0600022C RID: 556 RVA: 0x0000733C File Offset: 0x0000553C
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qcntex_isAccepted = QContextMenuEvent.__N.QCntex_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qcntex_isAccepted) > 0;
	}

	// Token: 0x0600022D RID: 557 RVA: 0x0000736C File Offset: 0x0000556C
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qcntex_spontaneous = QContextMenuEvent.__N.QCntex_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qcntex_spontaneous) > 0;
	}

	// Token: 0x0600022E RID: 558 RVA: 0x0000739C File Offset: 0x0000559C
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qcntex_setAccepted = QContextMenuEvent.__N.QCntex_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qcntex_setAccepted);
	}

	// Token: 0x04000018 RID: 24
	internal IntPtr self;

	// Token: 0x020000ED RID: 237
	internal static class __N
	{
		// Token: 0x04000628 RID: 1576
		internal static method From_QInputEvent_To_QContextMenuEvent;

		// Token: 0x04000629 RID: 1577
		internal static method To_QInputEvent_From_QContextMenuEvent;

		// Token: 0x0400062A RID: 1578
		internal static method From_QEvent_To_QContextMenuEvent;

		// Token: 0x0400062B RID: 1579
		internal static method To_QEvent_From_QContextMenuEvent;

		// Token: 0x0400062C RID: 1580
		internal static method QCntex_pos;

		// Token: 0x0400062D RID: 1581
		internal static method QCntex_globalPos;

		// Token: 0x0400062E RID: 1582
		internal static method QCntex_modifiers;

		// Token: 0x0400062F RID: 1583
		internal static method QCntex_timestamp;

		// Token: 0x04000630 RID: 1584
		internal static method QCntex_accept;

		// Token: 0x04000631 RID: 1585
		internal static method QCntex_ignore;

		// Token: 0x04000632 RID: 1586
		internal static method QCntex_isAccepted;

		// Token: 0x04000633 RID: 1587
		internal static method QCntex_spontaneous;

		// Token: 0x04000634 RID: 1588
		internal static method QCntex_setAccepted;
	}
}
