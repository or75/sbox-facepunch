using System;
using System.Runtime.CompilerServices;

// Token: 0x0200002C RID: 44
internal struct QMoveEvent
{
	// Token: 0x060003C8 RID: 968 RVA: 0x0000AE35 File Offset: 0x00009035
	public static implicit operator IntPtr(QMoveEvent value)
	{
		return value.self;
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x0000AE40 File Offset: 0x00009040
	public static implicit operator QMoveEvent(IntPtr value)
	{
		return new QMoveEvent
		{
			self = value
		};
	}

	// Token: 0x060003CA RID: 970 RVA: 0x0000AE5E File Offset: 0x0000905E
	public static bool operator ==(QMoveEvent c1, QMoveEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x060003CB RID: 971 RVA: 0x0000AE71 File Offset: 0x00009071
	public static bool operator !=(QMoveEvent c1, QMoveEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x060003CC RID: 972 RVA: 0x0000AE84 File Offset: 0x00009084
	public override bool Equals(object obj)
	{
		if (obj is QMoveEvent)
		{
			QMoveEvent c = (QMoveEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x060003CD RID: 973 RVA: 0x0000AEAE File Offset: 0x000090AE
	internal QMoveEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x060003CE RID: 974 RVA: 0x0000AEB8 File Offset: 0x000090B8
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QMoveEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700003F RID: 63
	// (get) Token: 0x060003CF RID: 975 RVA: 0x0000AEF4 File Offset: 0x000090F4
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x060003D0 RID: 976 RVA: 0x0000AF06 File Offset: 0x00009106
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x0000AF11 File Offset: 0x00009111
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x0000AF24 File Offset: 0x00009124
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QMoveEvent was null when calling " + n);
		}
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x0000AF3F File Offset: 0x0000913F
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x0000AF4C File Offset: 0x0000914C
	public static implicit operator QEvent(QMoveEvent value)
	{
		method to_QEvent_From_QMoveEvent = QMoveEvent.__N.To_QEvent_From_QMoveEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QMoveEvent);
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x0000AF70 File Offset: 0x00009170
	public static explicit operator QMoveEvent(QEvent value)
	{
		method from_QEvent_To_QMoveEvent = QMoveEvent.__N.From_QEvent_To_QMoveEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QMoveEvent);
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x0000AF94 File Offset: 0x00009194
	internal readonly Vector3 pos()
	{
		this.NullCheck("pos");
		method qmveEv_pos = QMoveEvent.__N.QMveEv_pos;
		return calli(Vector3(System.IntPtr), this.self, qmveEv_pos);
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0000AFC0 File Offset: 0x000091C0
	internal readonly Vector3 oldPos()
	{
		this.NullCheck("oldPos");
		method qmveEv_oldPos = QMoveEvent.__N.QMveEv_oldPos;
		return calli(Vector3(System.IntPtr), this.self, qmveEv_oldPos);
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x0000AFEC File Offset: 0x000091EC
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qmveEv_accept = QMoveEvent.__N.QMveEv_accept;
		calli(System.Void(System.IntPtr), this.self, qmveEv_accept);
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x0000B018 File Offset: 0x00009218
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qmveEv_ignore = QMoveEvent.__N.QMveEv_ignore;
		calli(System.Void(System.IntPtr), this.self, qmveEv_ignore);
	}

	// Token: 0x060003DA RID: 986 RVA: 0x0000B044 File Offset: 0x00009244
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qmveEv_isAccepted = QMoveEvent.__N.QMveEv_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qmveEv_isAccepted) > 0;
	}

	// Token: 0x060003DB RID: 987 RVA: 0x0000B074 File Offset: 0x00009274
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qmveEv_spontaneous = QMoveEvent.__N.QMveEv_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qmveEv_spontaneous) > 0;
	}

	// Token: 0x060003DC RID: 988 RVA: 0x0000B0A4 File Offset: 0x000092A4
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qmveEv_setAccepted = QMoveEvent.__N.QMveEv_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qmveEv_setAccepted);
	}

	// Token: 0x04000026 RID: 38
	internal IntPtr self;

	// Token: 0x020000FC RID: 252
	internal static class __N
	{
		// Token: 0x04000732 RID: 1842
		internal static method From_QEvent_To_QMoveEvent;

		// Token: 0x04000733 RID: 1843
		internal static method To_QEvent_From_QMoveEvent;

		// Token: 0x04000734 RID: 1844
		internal static method QMveEv_pos;

		// Token: 0x04000735 RID: 1845
		internal static method QMveEv_oldPos;

		// Token: 0x04000736 RID: 1846
		internal static method QMveEv_accept;

		// Token: 0x04000737 RID: 1847
		internal static method QMveEv_ignore;

		// Token: 0x04000738 RID: 1848
		internal static method QMveEv_isAccepted;

		// Token: 0x04000739 RID: 1849
		internal static method QMveEv_spontaneous;

		// Token: 0x0400073A RID: 1850
		internal static method QMveEv_setAccepted;
	}
}
