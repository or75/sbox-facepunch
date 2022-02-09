using System;
using System.Runtime.CompilerServices;
using Native;
using Tools;

// Token: 0x02000022 RID: 34
internal struct QDropEvent
{
	// Token: 0x06000296 RID: 662 RVA: 0x0000818D File Offset: 0x0000638D
	public static implicit operator IntPtr(QDropEvent value)
	{
		return value.self;
	}

	// Token: 0x06000297 RID: 663 RVA: 0x00008198 File Offset: 0x00006398
	public static implicit operator QDropEvent(IntPtr value)
	{
		return new QDropEvent
		{
			self = value
		};
	}

	// Token: 0x06000298 RID: 664 RVA: 0x000081B6 File Offset: 0x000063B6
	public static bool operator ==(QDropEvent c1, QDropEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000299 RID: 665 RVA: 0x000081C9 File Offset: 0x000063C9
	public static bool operator !=(QDropEvent c1, QDropEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600029A RID: 666 RVA: 0x000081DC File Offset: 0x000063DC
	public override bool Equals(object obj)
	{
		if (obj is QDropEvent)
		{
			QDropEvent c = (QDropEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600029B RID: 667 RVA: 0x00008206 File Offset: 0x00006406
	internal QDropEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600029C RID: 668 RVA: 0x00008210 File Offset: 0x00006410
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QDropEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x0600029D RID: 669 RVA: 0x0000824C File Offset: 0x0000644C
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x0600029E RID: 670 RVA: 0x0000825E File Offset: 0x0000645E
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600029F RID: 671 RVA: 0x00008269 File Offset: 0x00006469
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x0000827C File Offset: 0x0000647C
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QDropEvent was null when calling " + n);
		}
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x00008297 File Offset: 0x00006497
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x000082A4 File Offset: 0x000064A4
	public static implicit operator QEvent(QDropEvent value)
	{
		method to_QEvent_From_QDropEvent = QDropEvent.__N.To_QEvent_From_QDropEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QDropEvent);
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x000082C8 File Offset: 0x000064C8
	public static explicit operator QDropEvent(QEvent value)
	{
		method from_QEvent_To_QDropEvent = QDropEvent.__N.From_QEvent_To_QDropEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QDropEvent);
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x000082EC File Offset: 0x000064EC
	internal readonly void acceptProposedAction()
	{
		this.NullCheck("acceptProposedAction");
		method qdrpEv_acceptProposedAction = QDropEvent.__N.QDrpEv_acceptProposedAction;
		calli(System.Void(System.IntPtr), this.self, qdrpEv_acceptProposedAction);
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x00008318 File Offset: 0x00006518
	internal readonly QMimeData mimeData()
	{
		this.NullCheck("mimeData");
		method qdrpEv_mimeData = QDropEvent.__N.QDrpEv_mimeData;
		return calli(System.IntPtr(System.IntPtr), this.self, qdrpEv_mimeData);
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x00008348 File Offset: 0x00006548
	internal readonly Native.QObject source()
	{
		this.NullCheck("source");
		method qdrpEv_source = QDropEvent.__N.QDrpEv_source;
		return calli(System.IntPtr(System.IntPtr), this.self, qdrpEv_source);
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x00008378 File Offset: 0x00006578
	internal readonly Vector3 pos()
	{
		this.NullCheck("pos");
		method qdrpEv_pos = QDropEvent.__N.QDrpEv_pos;
		return calli(Vector3(System.IntPtr), this.self, qdrpEv_pos);
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x000083A4 File Offset: 0x000065A4
	internal readonly MouseButtons mouseButtons()
	{
		this.NullCheck("mouseButtons");
		method qdrpEv_mouseButtons = QDropEvent.__N.QDrpEv_mouseButtons;
		return calli(System.Int64(System.IntPtr), this.self, qdrpEv_mouseButtons);
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x000083D0 File Offset: 0x000065D0
	internal readonly KeyboardModifiers keyboardModifiers()
	{
		this.NullCheck("keyboardModifiers");
		method qdrpEv_keyboardModifiers = QDropEvent.__N.QDrpEv_keyboardModifiers;
		return calli(System.Int64(System.IntPtr), this.self, qdrpEv_keyboardModifiers);
	}

	// Token: 0x060002AA RID: 682 RVA: 0x000083FC File Offset: 0x000065FC
	internal readonly void setDropAction(DropAction action)
	{
		this.NullCheck("setDropAction");
		method qdrpEv_setDropAction = QDropEvent.__N.QDrpEv_setDropAction;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)action, qdrpEv_setDropAction);
	}

	// Token: 0x060002AB RID: 683 RVA: 0x00008428 File Offset: 0x00006628
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qdrpEv_accept = QDropEvent.__N.QDrpEv_accept;
		calli(System.Void(System.IntPtr), this.self, qdrpEv_accept);
	}

	// Token: 0x060002AC RID: 684 RVA: 0x00008454 File Offset: 0x00006654
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qdrpEv_ignore = QDropEvent.__N.QDrpEv_ignore;
		calli(System.Void(System.IntPtr), this.self, qdrpEv_ignore);
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00008480 File Offset: 0x00006680
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qdrpEv_isAccepted = QDropEvent.__N.QDrpEv_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qdrpEv_isAccepted) > 0;
	}

	// Token: 0x060002AE RID: 686 RVA: 0x000084B0 File Offset: 0x000066B0
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qdrpEv_spontaneous = QDropEvent.__N.QDrpEv_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qdrpEv_spontaneous) > 0;
	}

	// Token: 0x060002AF RID: 687 RVA: 0x000084E0 File Offset: 0x000066E0
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qdrpEv_setAccepted = QDropEvent.__N.QDrpEv_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qdrpEv_setAccepted);
	}

	// Token: 0x0400001D RID: 29
	internal IntPtr self;

	// Token: 0x020000F2 RID: 242
	internal static class __N
	{
		// Token: 0x0400066C RID: 1644
		internal static method From_QEvent_To_QDropEvent;

		// Token: 0x0400066D RID: 1645
		internal static method To_QEvent_From_QDropEvent;

		// Token: 0x0400066E RID: 1646
		internal static method QDrpEv_acceptProposedAction;

		// Token: 0x0400066F RID: 1647
		internal static method QDrpEv_mimeData;

		// Token: 0x04000670 RID: 1648
		internal static method QDrpEv_source;

		// Token: 0x04000671 RID: 1649
		internal static method QDrpEv_pos;

		// Token: 0x04000672 RID: 1650
		internal static method QDrpEv_mouseButtons;

		// Token: 0x04000673 RID: 1651
		internal static method QDrpEv_keyboardModifiers;

		// Token: 0x04000674 RID: 1652
		internal static method QDrpEv_setDropAction;

		// Token: 0x04000675 RID: 1653
		internal static method QDrpEv_accept;

		// Token: 0x04000676 RID: 1654
		internal static method QDrpEv_ignore;

		// Token: 0x04000677 RID: 1655
		internal static method QDrpEv_isAccepted;

		// Token: 0x04000678 RID: 1656
		internal static method QDrpEv_spontaneous;

		// Token: 0x04000679 RID: 1657
		internal static method QDrpEv_setAccepted;
	}
}
