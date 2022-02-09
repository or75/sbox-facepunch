using System;
using System.Runtime.CompilerServices;
using Native;
using Tools;

// Token: 0x0200001F RID: 31
internal struct QDragEnterEvent
{
	// Token: 0x06000249 RID: 585 RVA: 0x00007766 File Offset: 0x00005966
	public static implicit operator IntPtr(QDragEnterEvent value)
	{
		return value.self;
	}

	// Token: 0x0600024A RID: 586 RVA: 0x00007770 File Offset: 0x00005970
	public static implicit operator QDragEnterEvent(IntPtr value)
	{
		return new QDragEnterEvent
		{
			self = value
		};
	}

	// Token: 0x0600024B RID: 587 RVA: 0x0000778E File Offset: 0x0000598E
	public static bool operator ==(QDragEnterEvent c1, QDragEnterEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600024C RID: 588 RVA: 0x000077A1 File Offset: 0x000059A1
	public static bool operator !=(QDragEnterEvent c1, QDragEnterEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600024D RID: 589 RVA: 0x000077B4 File Offset: 0x000059B4
	public override bool Equals(object obj)
	{
		if (obj is QDragEnterEvent)
		{
			QDragEnterEvent c = (QDragEnterEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600024E RID: 590 RVA: 0x000077DE File Offset: 0x000059DE
	internal QDragEnterEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600024F RID: 591 RVA: 0x000077E8 File Offset: 0x000059E8
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QDragEnterEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x06000250 RID: 592 RVA: 0x00007824 File Offset: 0x00005A24
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x06000251 RID: 593 RVA: 0x00007836 File Offset: 0x00005A36
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000252 RID: 594 RVA: 0x00007841 File Offset: 0x00005A41
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000253 RID: 595 RVA: 0x00007854 File Offset: 0x00005A54
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QDragEnterEvent was null when calling " + n);
		}
	}

	// Token: 0x06000254 RID: 596 RVA: 0x0000786F File Offset: 0x00005A6F
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0000787C File Offset: 0x00005A7C
	public static implicit operator QDragMoveEvent(QDragEnterEvent value)
	{
		method to_QDragMoveEvent_From_QDragEnterEvent = QDragEnterEvent.__N.To_QDragMoveEvent_From_QDragEnterEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QDragMoveEvent_From_QDragEnterEvent);
	}

	// Token: 0x06000256 RID: 598 RVA: 0x000078A0 File Offset: 0x00005AA0
	public static explicit operator QDragEnterEvent(QDragMoveEvent value)
	{
		method from_QDragMoveEvent_To_QDragEnterEvent = QDragEnterEvent.__N.From_QDragMoveEvent_To_QDragEnterEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QDragMoveEvent_To_QDragEnterEvent);
	}

	// Token: 0x06000257 RID: 599 RVA: 0x000078C4 File Offset: 0x00005AC4
	public static implicit operator QDropEvent(QDragEnterEvent value)
	{
		method to_QDropEvent_From_QDragEnterEvent = QDragEnterEvent.__N.To_QDropEvent_From_QDragEnterEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QDropEvent_From_QDragEnterEvent);
	}

	// Token: 0x06000258 RID: 600 RVA: 0x000078E8 File Offset: 0x00005AE8
	public static explicit operator QDragEnterEvent(QDropEvent value)
	{
		method from_QDropEvent_To_QDragEnterEvent = QDragEnterEvent.__N.From_QDropEvent_To_QDragEnterEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QDropEvent_To_QDragEnterEvent);
	}

	// Token: 0x06000259 RID: 601 RVA: 0x0000790C File Offset: 0x00005B0C
	public static implicit operator QEvent(QDragEnterEvent value)
	{
		method to_QEvent_From_QDragEnterEvent = QDragEnterEvent.__N.To_QEvent_From_QDragEnterEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QDragEnterEvent);
	}

	// Token: 0x0600025A RID: 602 RVA: 0x00007930 File Offset: 0x00005B30
	public static explicit operator QDragEnterEvent(QEvent value)
	{
		method from_QEvent_To_QDragEnterEvent = QDragEnterEvent.__N.From_QEvent_To_QDragEnterEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QDragEnterEvent);
	}

	// Token: 0x0600025B RID: 603 RVA: 0x00007954 File Offset: 0x00005B54
	internal readonly void acceptProposedAction()
	{
		this.NullCheck("acceptProposedAction");
		method qdrgEn_acceptProposedAction = QDragEnterEvent.__N.QDrgEn_acceptProposedAction;
		calli(System.Void(System.IntPtr), this.self, qdrgEn_acceptProposedAction);
	}

	// Token: 0x0600025C RID: 604 RVA: 0x00007980 File Offset: 0x00005B80
	internal readonly QMimeData mimeData()
	{
		this.NullCheck("mimeData");
		method qdrgEn_mimeData = QDragEnterEvent.__N.QDrgEn_mimeData;
		return calli(System.IntPtr(System.IntPtr), this.self, qdrgEn_mimeData);
	}

	// Token: 0x0600025D RID: 605 RVA: 0x000079B0 File Offset: 0x00005BB0
	internal readonly Native.QObject source()
	{
		this.NullCheck("source");
		method qdrgEn_source = QDragEnterEvent.__N.QDrgEn_source;
		return calli(System.IntPtr(System.IntPtr), this.self, qdrgEn_source);
	}

	// Token: 0x0600025E RID: 606 RVA: 0x000079E0 File Offset: 0x00005BE0
	internal readonly Vector3 pos()
	{
		this.NullCheck("pos");
		method qdrgEn_pos = QDragEnterEvent.__N.QDrgEn_pos;
		return calli(Vector3(System.IntPtr), this.self, qdrgEn_pos);
	}

	// Token: 0x0600025F RID: 607 RVA: 0x00007A0C File Offset: 0x00005C0C
	internal readonly MouseButtons mouseButtons()
	{
		this.NullCheck("mouseButtons");
		method qdrgEn_mouseButtons = QDragEnterEvent.__N.QDrgEn_mouseButtons;
		return calli(System.Int64(System.IntPtr), this.self, qdrgEn_mouseButtons);
	}

	// Token: 0x06000260 RID: 608 RVA: 0x00007A38 File Offset: 0x00005C38
	internal readonly KeyboardModifiers keyboardModifiers()
	{
		this.NullCheck("keyboardModifiers");
		method qdrgEn_keyboardModifiers = QDragEnterEvent.__N.QDrgEn_keyboardModifiers;
		return calli(System.Int64(System.IntPtr), this.self, qdrgEn_keyboardModifiers);
	}

	// Token: 0x06000261 RID: 609 RVA: 0x00007A64 File Offset: 0x00005C64
	internal readonly void setDropAction(DropAction action)
	{
		this.NullCheck("setDropAction");
		method qdrgEn_setDropAction = QDragEnterEvent.__N.QDrgEn_setDropAction;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)action, qdrgEn_setDropAction);
	}

	// Token: 0x06000262 RID: 610 RVA: 0x00007A90 File Offset: 0x00005C90
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qdrgEn_accept = QDragEnterEvent.__N.QDrgEn_accept;
		calli(System.Void(System.IntPtr), this.self, qdrgEn_accept);
	}

	// Token: 0x06000263 RID: 611 RVA: 0x00007ABC File Offset: 0x00005CBC
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qdrgEn_ignore = QDragEnterEvent.__N.QDrgEn_ignore;
		calli(System.Void(System.IntPtr), this.self, qdrgEn_ignore);
	}

	// Token: 0x06000264 RID: 612 RVA: 0x00007AE8 File Offset: 0x00005CE8
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qdrgEn_isAccepted = QDragEnterEvent.__N.QDrgEn_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qdrgEn_isAccepted) > 0;
	}

	// Token: 0x06000265 RID: 613 RVA: 0x00007B18 File Offset: 0x00005D18
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qdrgEn_spontaneous = QDragEnterEvent.__N.QDrgEn_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qdrgEn_spontaneous) > 0;
	}

	// Token: 0x06000266 RID: 614 RVA: 0x00007B48 File Offset: 0x00005D48
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qdrgEn_setAccepted = QDragEnterEvent.__N.QDrgEn_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qdrgEn_setAccepted);
	}

	// Token: 0x0400001A RID: 26
	internal IntPtr self;

	// Token: 0x020000EF RID: 239
	internal static class __N
	{
		// Token: 0x04000643 RID: 1603
		internal static method From_QDragMoveEvent_To_QDragEnterEvent;

		// Token: 0x04000644 RID: 1604
		internal static method To_QDragMoveEvent_From_QDragEnterEvent;

		// Token: 0x04000645 RID: 1605
		internal static method From_QDropEvent_To_QDragEnterEvent;

		// Token: 0x04000646 RID: 1606
		internal static method To_QDropEvent_From_QDragEnterEvent;

		// Token: 0x04000647 RID: 1607
		internal static method From_QEvent_To_QDragEnterEvent;

		// Token: 0x04000648 RID: 1608
		internal static method To_QEvent_From_QDragEnterEvent;

		// Token: 0x04000649 RID: 1609
		internal static method QDrgEn_acceptProposedAction;

		// Token: 0x0400064A RID: 1610
		internal static method QDrgEn_mimeData;

		// Token: 0x0400064B RID: 1611
		internal static method QDrgEn_source;

		// Token: 0x0400064C RID: 1612
		internal static method QDrgEn_pos;

		// Token: 0x0400064D RID: 1613
		internal static method QDrgEn_mouseButtons;

		// Token: 0x0400064E RID: 1614
		internal static method QDrgEn_keyboardModifiers;

		// Token: 0x0400064F RID: 1615
		internal static method QDrgEn_setDropAction;

		// Token: 0x04000650 RID: 1616
		internal static method QDrgEn_accept;

		// Token: 0x04000651 RID: 1617
		internal static method QDrgEn_ignore;

		// Token: 0x04000652 RID: 1618
		internal static method QDrgEn_isAccepted;

		// Token: 0x04000653 RID: 1619
		internal static method QDrgEn_spontaneous;

		// Token: 0x04000654 RID: 1620
		internal static method QDrgEn_setAccepted;
	}
}
