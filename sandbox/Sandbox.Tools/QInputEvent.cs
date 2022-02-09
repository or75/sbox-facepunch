using System;
using System.Runtime.CompilerServices;
using Tools;

// Token: 0x02000028 RID: 40
internal struct QInputEvent
{
	// Token: 0x06000362 RID: 866 RVA: 0x0000A0A5 File Offset: 0x000082A5
	public static implicit operator IntPtr(QInputEvent value)
	{
		return value.self;
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0000A0B0 File Offset: 0x000082B0
	public static implicit operator QInputEvent(IntPtr value)
	{
		return new QInputEvent
		{
			self = value
		};
	}

	// Token: 0x06000364 RID: 868 RVA: 0x0000A0CE File Offset: 0x000082CE
	public static bool operator ==(QInputEvent c1, QInputEvent c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000365 RID: 869 RVA: 0x0000A0E1 File Offset: 0x000082E1
	public static bool operator !=(QInputEvent c1, QInputEvent c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000366 RID: 870 RVA: 0x0000A0F4 File Offset: 0x000082F4
	public override bool Equals(object obj)
	{
		if (obj is QInputEvent)
		{
			QInputEvent c = (QInputEvent)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000367 RID: 871 RVA: 0x0000A11E File Offset: 0x0000831E
	internal QInputEvent(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000368 RID: 872 RVA: 0x0000A128 File Offset: 0x00008328
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QInputEvent ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x06000369 RID: 873 RVA: 0x0000A164 File Offset: 0x00008364
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x0600036A RID: 874 RVA: 0x0000A176 File Offset: 0x00008376
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600036B RID: 875 RVA: 0x0000A181 File Offset: 0x00008381
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600036C RID: 876 RVA: 0x0000A194 File Offset: 0x00008394
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QInputEvent was null when calling " + n);
		}
	}

	// Token: 0x0600036D RID: 877 RVA: 0x0000A1AF File Offset: 0x000083AF
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x0600036E RID: 878 RVA: 0x0000A1BC File Offset: 0x000083BC
	public static implicit operator QEvent(QInputEvent value)
	{
		method to_QEvent_From_QInputEvent = QInputEvent.__N.To_QEvent_From_QInputEvent;
		return calli(System.IntPtr(System.IntPtr), value, to_QEvent_From_QInputEvent);
	}

	// Token: 0x0600036F RID: 879 RVA: 0x0000A1E0 File Offset: 0x000083E0
	public static explicit operator QInputEvent(QEvent value)
	{
		method from_QEvent_To_QInputEvent = QInputEvent.__N.From_QEvent_To_QInputEvent;
		return calli(System.IntPtr(System.IntPtr), value, from_QEvent_To_QInputEvent);
	}

	// Token: 0x06000370 RID: 880 RVA: 0x0000A204 File Offset: 0x00008404
	internal readonly KeyboardModifiers modifiers()
	{
		this.NullCheck("modifiers");
		method qinptE_modifiers = QInputEvent.__N.QInptE_modifiers;
		return calli(System.Int64(System.IntPtr), this.self, qinptE_modifiers);
	}

	// Token: 0x06000371 RID: 881 RVA: 0x0000A230 File Offset: 0x00008430
	internal readonly ulong timestamp()
	{
		this.NullCheck("timestamp");
		method qinptE_timestamp = QInputEvent.__N.QInptE_timestamp;
		return calli(System.UInt64(System.IntPtr), this.self, qinptE_timestamp);
	}

	// Token: 0x06000372 RID: 882 RVA: 0x0000A25C File Offset: 0x0000845C
	internal readonly void accept()
	{
		this.NullCheck("accept");
		method qinptE_accept = QInputEvent.__N.QInptE_accept;
		calli(System.Void(System.IntPtr), this.self, qinptE_accept);
	}

	// Token: 0x06000373 RID: 883 RVA: 0x0000A288 File Offset: 0x00008488
	internal readonly void ignore()
	{
		this.NullCheck("ignore");
		method qinptE_ignore = QInputEvent.__N.QInptE_ignore;
		calli(System.Void(System.IntPtr), this.self, qinptE_ignore);
	}

	// Token: 0x06000374 RID: 884 RVA: 0x0000A2B4 File Offset: 0x000084B4
	internal readonly bool isAccepted()
	{
		this.NullCheck("isAccepted");
		method qinptE_isAccepted = QInputEvent.__N.QInptE_isAccepted;
		return calli(System.Int32(System.IntPtr), this.self, qinptE_isAccepted) > 0;
	}

	// Token: 0x06000375 RID: 885 RVA: 0x0000A2E4 File Offset: 0x000084E4
	internal readonly bool spontaneous()
	{
		this.NullCheck("spontaneous");
		method qinptE_spontaneous = QInputEvent.__N.QInptE_spontaneous;
		return calli(System.Int32(System.IntPtr), this.self, qinptE_spontaneous) > 0;
	}

	// Token: 0x06000376 RID: 886 RVA: 0x0000A314 File Offset: 0x00008514
	internal readonly void setAccepted(bool accepted)
	{
		this.NullCheck("setAccepted");
		method qinptE_setAccepted = QInputEvent.__N.QInptE_setAccepted;
		calli(System.Void(System.IntPtr,System.Int32), this.self, accepted ? 1 : 0, qinptE_setAccepted);
	}

	// Token: 0x04000022 RID: 34
	internal IntPtr self;

	// Token: 0x020000F8 RID: 248
	internal static class __N
	{
		// Token: 0x040006FC RID: 1788
		internal static method From_QEvent_To_QInputEvent;

		// Token: 0x040006FD RID: 1789
		internal static method To_QEvent_From_QInputEvent;

		// Token: 0x040006FE RID: 1790
		internal static method QInptE_modifiers;

		// Token: 0x040006FF RID: 1791
		internal static method QInptE_timestamp;

		// Token: 0x04000700 RID: 1792
		internal static method QInptE_accept;

		// Token: 0x04000701 RID: 1793
		internal static method QInptE_ignore;

		// Token: 0x04000702 RID: 1794
		internal static method QInptE_isAccepted;

		// Token: 0x04000703 RID: 1795
		internal static method QInptE_spontaneous;

		// Token: 0x04000704 RID: 1796
		internal static method QInptE_setAccepted;
	}
}
