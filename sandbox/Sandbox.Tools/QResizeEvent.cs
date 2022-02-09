using System;
using System.Runtime.CompilerServices;

// Token: 0x0200002E RID: 46
internal struct QResizeEvent
{
	// Token: 0x060003F8 RID: 1016 RVA: 0x0000B4B2 File Offset: 0x000096B2
	public static implicit operator IntPtr(QResizeEvent value)
	{
		return value.self;
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x0000B4BC File Offset: 0x000096BC
	public static implicit operator QResizeEvent(IntPtr value)
	{
		return new QResizeEvent
		{
			self = value
		};
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x0000B4DA File Offset: 0x000096DA
	public static bool operator ==(QResizeEvent c1, QResizeEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x0000B4ED File Offset: 0x000096ED
	public static bool operator !=(QResizeEvent c1, QResizeEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x0000B500 File Offset: 0x00009700
	public override bool Equals(object obj)
	{
		if (obj is QResizeEvent)
		{
			QResizeEvent c = (QResizeEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x0000B52A File Offset: 0x0000972A
	internal QResizeEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x0000B534 File Offset: 0x00009734
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QResizeEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x060003FF RID: 1023 RVA: 0x0000B570 File Offset: 0x00009770
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x06000400 RID: 1024 RVA: 0x0000B582 File Offset: 0x00009782
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x0000B58D File Offset: 0x0000978D
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x0000B5A0 File Offset: 0x000097A0
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QResizeEvent was null when calling " + n);
		}
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x0000B5BB File Offset: 0x000097BB
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x0000B5C8 File Offset: 0x000097C8
	public static implicit operator QEvent(QResizeEvent value)
	{
		method to_QEvent_From_QResizeEvent = QResizeEvent.__N.To_QEvent_From_QResizeEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QResizeEvent);
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x0000B5EC File Offset: 0x000097EC
	public static explicit operator QResizeEvent(QEvent value)
	{
		method from_QEvent_To_QResizeEvent = QResizeEvent.__N.From_QEvent_To_QResizeEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QResizeEvent);
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x0000B610 File Offset: 0x00009810
	internal readonly Vector3 size()
	{
		this.NullCheck("size");
		method qresze_size = QResizeEvent.__N.QResze_size;
		return calli(Vector3(System.IntPtr), this.self, qresze_size);
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x0000B63C File Offset: 0x0000983C
	internal readonly Vector3 oldSize()
	{
		this.NullCheck("oldSize");
		method qresze_oldSize = QResizeEvent.__N.QResze_oldSize;
		return calli(Vector3(System.IntPtr), this.self, qresze_oldSize);
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x0000B668 File Offset: 0x00009868
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qresze_accept = QResizeEvent.__N.QResze_accept;
		calli(System.Void(System.IntPtr), this.self, qresze_accept);
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x0000B694 File Offset: 0x00009894
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qresze_ignore = QResizeEvent.__N.QResze_ignore;
		calli(System.Void(System.IntPtr), this.self, qresze_ignore);
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x0000B6C0 File Offset: 0x000098C0
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qresze_isAccepted = QResizeEvent.__N.QResze_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qresze_isAccepted) > 0;
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x0000B6F0 File Offset: 0x000098F0
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qresze_spontaneous = QResizeEvent.__N.QResze_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qresze_spontaneous) > 0;
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x0000B720 File Offset: 0x00009920
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qresze_setAccepted = QResizeEvent.__N.QResze_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qresze_setAccepted);
	}

	// Token: 0x04000028 RID: 40
	internal IntPtr self;

	// Token: 0x020000FE RID: 254
	internal static class __N
	{
		// Token: 0x0400074A RID: 1866
		internal static method From_QEvent_To_QResizeEvent;

		// Token: 0x0400074B RID: 1867
		internal static method To_QEvent_From_QResizeEvent;

		// Token: 0x0400074C RID: 1868
		internal static method QResze_size;

		// Token: 0x0400074D RID: 1869
		internal static method QResze_oldSize;

		// Token: 0x0400074E RID: 1870
		internal static method QResze_accept;

		// Token: 0x0400074F RID: 1871
		internal static method QResze_ignore;

		// Token: 0x04000750 RID: 1872
		internal static method QResze_isAccepted;

		// Token: 0x04000751 RID: 1873
		internal static method QResze_spontaneous;

		// Token: 0x04000752 RID: 1874
		internal static method QResze_setAccepted;
	}
}
