using System;
using System.Runtime.CompilerServices;
using Native;
using Tools;

// Token: 0x02000021 RID: 33
internal struct QDragMoveEvent
{
	// Token: 0x0600027A RID: 634 RVA: 0x00007DC1 File Offset: 0x00005FC1
	public static implicit operator IntPtr(QDragMoveEvent value)
	{
		return value.self;
	}

	// Token: 0x0600027B RID: 635 RVA: 0x00007DCC File Offset: 0x00005FCC
	public static implicit operator QDragMoveEvent(IntPtr value)
	{
		return new QDragMoveEvent
		{
			self = value
		};
	}

	// Token: 0x0600027C RID: 636 RVA: 0x00007DEA File Offset: 0x00005FEA
	public static bool operator ==(QDragMoveEvent c1, QDragMoveEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x0600027D RID: 637 RVA: 0x00007DFD File Offset: 0x00005FFD
	public static bool operator !=(QDragMoveEvent c1, QDragMoveEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600027E RID: 638 RVA: 0x00007E10 File Offset: 0x00006010
	public override bool Equals(object obj)
	{
		if (obj is QDragMoveEvent)
		{
			QDragMoveEvent c = (QDragMoveEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600027F RID: 639 RVA: 0x00007E3A File Offset: 0x0000603A
	internal QDragMoveEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000280 RID: 640 RVA: 0x00007E44 File Offset: 0x00006044
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QDragMoveEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700002B RID: 43
	// (get) Token: 0x06000281 RID: 641 RVA: 0x00007E80 File Offset: 0x00006080
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x06000282 RID: 642 RVA: 0x00007E92 File Offset: 0x00006092
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000283 RID: 643 RVA: 0x00007E9D File Offset: 0x0000609D
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00007EB0 File Offset: 0x000060B0
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QDragMoveEvent was null when calling " + n);
		}
	}

	// Token: 0x06000285 RID: 645 RVA: 0x00007ECB File Offset: 0x000060CB
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00007ED8 File Offset: 0x000060D8
	public static implicit operator QDropEvent(QDragMoveEvent value)
	{
		method to_QDropEvent_From_QDragMoveEvent = QDragMoveEvent.__N.To_QDropEvent_From_QDragMoveEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QDropEvent_From_QDragMoveEvent);
	}

	// Token: 0x06000287 RID: 647 RVA: 0x00007EFC File Offset: 0x000060FC
	public static explicit operator QDragMoveEvent(QDropEvent value)
	{
		method from_QDropEvent_To_QDragMoveEvent = QDragMoveEvent.__N.From_QDropEvent_To_QDragMoveEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QDropEvent_To_QDragMoveEvent);
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00007F20 File Offset: 0x00006120
	public static implicit operator QEvent(QDragMoveEvent value)
	{
		method to_QEvent_From_QDragMoveEvent = QDragMoveEvent.__N.To_QEvent_From_QDragMoveEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QDragMoveEvent);
	}

	// Token: 0x06000289 RID: 649 RVA: 0x00007F44 File Offset: 0x00006144
	public static explicit operator QDragMoveEvent(QEvent value)
	{
		method from_QEvent_To_QDragMoveEvent = QDragMoveEvent.__N.From_QEvent_To_QDragMoveEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QDragMoveEvent);
	}

	// Token: 0x0600028A RID: 650 RVA: 0x00007F68 File Offset: 0x00006168
	internal readonly void acceptProposedAction()
	{
		this.NullCheck("acceptProposedAction");
		method qdrgMv_acceptProposedAction = QDragMoveEvent.__N.QDrgMv_acceptProposedAction;
		calli(System.Void(System.IntPtr), this.self, qdrgMv_acceptProposedAction);
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00007F94 File Offset: 0x00006194
	internal readonly QMimeData mimeData()
	{
		this.NullCheck("mimeData");
		method qdrgMv_mimeData = QDragMoveEvent.__N.QDrgMv_mimeData;
		return calli(System.IntPtr(System.IntPtr), this.self, qdrgMv_mimeData);
	}

	// Token: 0x0600028C RID: 652 RVA: 0x00007FC4 File Offset: 0x000061C4
	internal readonly Native.QObject source()
	{
		this.NullCheck("source");
		method qdrgMv_source = QDragMoveEvent.__N.QDrgMv_source;
		return calli(System.IntPtr(System.IntPtr), this.self, qdrgMv_source);
	}

	// Token: 0x0600028D RID: 653 RVA: 0x00007FF4 File Offset: 0x000061F4
	internal readonly Vector3 pos()
	{
		this.NullCheck("pos");
		method qdrgMv_pos = QDragMoveEvent.__N.QDrgMv_pos;
		return calli(Vector3(System.IntPtr), this.self, qdrgMv_pos);
	}

	// Token: 0x0600028E RID: 654 RVA: 0x00008020 File Offset: 0x00006220
	internal readonly MouseButtons mouseButtons()
	{
		this.NullCheck("mouseButtons");
		method qdrgMv_mouseButtons = QDragMoveEvent.__N.QDrgMv_mouseButtons;
		return calli(System.Int64(System.IntPtr), this.self, qdrgMv_mouseButtons);
	}

	// Token: 0x0600028F RID: 655 RVA: 0x0000804C File Offset: 0x0000624C
	internal readonly KeyboardModifiers keyboardModifiers()
	{
		this.NullCheck("keyboardModifiers");
		method qdrgMv_keyboardModifiers = QDragMoveEvent.__N.QDrgMv_keyboardModifiers;
		return calli(System.Int64(System.IntPtr), this.self, qdrgMv_keyboardModifiers);
	}

	// Token: 0x06000290 RID: 656 RVA: 0x00008078 File Offset: 0x00006278
	internal readonly void setDropAction(DropAction action)
	{
		this.NullCheck("setDropAction");
		method qdrgMv_setDropAction = QDragMoveEvent.__N.QDrgMv_setDropAction;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)action, qdrgMv_setDropAction);
	}

	// Token: 0x06000291 RID: 657 RVA: 0x000080A4 File Offset: 0x000062A4
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qdrgMv_accept = QDragMoveEvent.__N.QDrgMv_accept;
		calli(System.Void(System.IntPtr), this.self, qdrgMv_accept);
	}

	// Token: 0x06000292 RID: 658 RVA: 0x000080D0 File Offset: 0x000062D0
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qdrgMv_ignore = QDragMoveEvent.__N.QDrgMv_ignore;
		calli(System.Void(System.IntPtr), this.self, qdrgMv_ignore);
	}

	// Token: 0x06000293 RID: 659 RVA: 0x000080FC File Offset: 0x000062FC
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qdrgMv_isAccepted = QDragMoveEvent.__N.QDrgMv_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qdrgMv_isAccepted) > 0;
	}

	// Token: 0x06000294 RID: 660 RVA: 0x0000812C File Offset: 0x0000632C
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qdrgMv_spontaneous = QDragMoveEvent.__N.QDrgMv_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qdrgMv_spontaneous) > 0;
	}

	// Token: 0x06000295 RID: 661 RVA: 0x0000815C File Offset: 0x0000635C
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qdrgMv_setAccepted = QDragMoveEvent.__N.QDrgMv_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qdrgMv_setAccepted);
	}

	// Token: 0x0400001C RID: 28
	internal IntPtr self;

	// Token: 0x020000F1 RID: 241
	internal static class __N
	{
		// Token: 0x0400065C RID: 1628
		internal static method From_QDropEvent_To_QDragMoveEvent;

		// Token: 0x0400065D RID: 1629
		internal static method To_QDropEvent_From_QDragMoveEvent;

		// Token: 0x0400065E RID: 1630
		internal static method From_QEvent_To_QDragMoveEvent;

		// Token: 0x0400065F RID: 1631
		internal static method To_QEvent_From_QDragMoveEvent;

		// Token: 0x04000660 RID: 1632
		internal static method QDrgMv_acceptProposedAction;

		// Token: 0x04000661 RID: 1633
		internal static method QDrgMv_mimeData;

		// Token: 0x04000662 RID: 1634
		internal static method QDrgMv_source;

		// Token: 0x04000663 RID: 1635
		internal static method QDrgMv_pos;

		// Token: 0x04000664 RID: 1636
		internal static method QDrgMv_mouseButtons;

		// Token: 0x04000665 RID: 1637
		internal static method QDrgMv_keyboardModifiers;

		// Token: 0x04000666 RID: 1638
		internal static method QDrgMv_setDropAction;

		// Token: 0x04000667 RID: 1639
		internal static method QDrgMv_accept;

		// Token: 0x04000668 RID: 1640
		internal static method QDrgMv_ignore;

		// Token: 0x04000669 RID: 1641
		internal static method QDrgMv_isAccepted;

		// Token: 0x0400066A RID: 1642
		internal static method QDrgMv_spontaneous;

		// Token: 0x0400066B RID: 1643
		internal static method QDrgMv_setAccepted;
	}
}
