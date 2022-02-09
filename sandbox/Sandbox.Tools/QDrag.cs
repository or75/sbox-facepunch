using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;

// Token: 0x0200001E RID: 30
internal struct QDrag
{
	// Token: 0x0600022F RID: 559 RVA: 0x000073CD File Offset: 0x000055CD
	public static implicit operator IntPtr(QDrag value)
	{
		return value.self;
	}

	// Token: 0x06000230 RID: 560 RVA: 0x000073D8 File Offset: 0x000055D8
	public static implicit operator QDrag(IntPtr value)
	{
		return new QDrag
		{
			self = value
		};
	}

	// Token: 0x06000231 RID: 561 RVA: 0x000073F6 File Offset: 0x000055F6
	public static bool operator ==(QDrag c1, QDrag c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000232 RID: 562 RVA: 0x00007409 File Offset: 0x00005609
	public static bool operator !=(QDrag c1, QDrag c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000233 RID: 563 RVA: 0x0000741C File Offset: 0x0000561C
	public override bool Equals(object obj)
	{
		if (obj is QDrag)
		{
			QDrag c = (QDrag)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000234 RID: 564 RVA: 0x00007446 File Offset: 0x00005646
	internal QDrag(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000235 RID: 565 RVA: 0x00007450 File Offset: 0x00005650
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QDrag ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x06000236 RID: 566 RVA: 0x0000748B File Offset: 0x0000568B
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x06000237 RID: 567 RVA: 0x0000749D File Offset: 0x0000569D
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000238 RID: 568 RVA: 0x000074A8 File Offset: 0x000056A8
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000239 RID: 569 RVA: 0x000074BB File Offset: 0x000056BB
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QDrag was null when calling " + n);
		}
	}

	// Token: 0x0600023A RID: 570 RVA: 0x000074D6 File Offset: 0x000056D6
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x0600023B RID: 571 RVA: 0x000074E4 File Offset: 0x000056E4
	public static implicit operator QObject(QDrag value)
	{
		method to_QObject_From_QDrag = QDrag.__N.To_QObject_From_QDrag;
		return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QDrag);
	}

	// Token: 0x0600023C RID: 572 RVA: 0x00007508 File Offset: 0x00005708
	public static explicit operator QDrag(QObject value)
	{
		method from_QObject_To_QDrag = QDrag.__N.From_QObject_To_QDrag;
		return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QDrag);
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0000752C File Offset: 0x0000572C
	internal static QDrag Create(QObject dragSource)
	{
		method qdrag_Create = QDrag.__N.QDrag_Create;
		return calli(System.IntPtr(System.IntPtr), dragSource, qdrag_Create);
	}

	// Token: 0x0600023E RID: 574 RVA: 0x00007550 File Offset: 0x00005750
	internal readonly void setPixmap(QPixmap icon)
	{
		this.NullCheck("setPixmap");
		method qdrag_setPixmap = QDrag.__N.QDrag_setPixmap;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, icon, qdrag_setPixmap);
	}

	// Token: 0x0600023F RID: 575 RVA: 0x00007580 File Offset: 0x00005780
	internal readonly void setHotSpot(Vector3 hotspot)
	{
		this.NullCheck("setHotSpot");
		method qdrag_setHotSpot = QDrag.__N.QDrag_setHotSpot;
		calli(System.Void(System.IntPtr,Vector3), this.self, hotspot, qdrag_setHotSpot);
	}

	// Token: 0x06000240 RID: 576 RVA: 0x000075AC File Offset: 0x000057AC
	internal readonly void setMimeData(QMimeData data)
	{
		this.NullCheck("setMimeData");
		method qdrag_setMimeData = QDrag.__N.QDrag_setMimeData;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, data, qdrag_setMimeData);
	}

	// Token: 0x06000241 RID: 577 RVA: 0x000075DC File Offset: 0x000057DC
	internal readonly QMimeData mimeData()
	{
		this.NullCheck("mimeData");
		method qdrag_mimeData = QDrag.__N.QDrag_mimeData;
		return calli(System.IntPtr(System.IntPtr), this.self, qdrag_mimeData);
	}

	// Token: 0x06000242 RID: 578 RVA: 0x0000760C File Offset: 0x0000580C
	internal readonly void exec()
	{
		this.NullCheck("exec");
		method qdrag_exec = QDrag.__N.QDrag_exec;
		calli(System.Void(System.IntPtr), this.self, qdrag_exec);
	}

	// Token: 0x06000243 RID: 579 RVA: 0x00007638 File Offset: 0x00005838
	internal readonly void deleteLater()
	{
		this.NullCheck("deleteLater");
		method qdrag_deleteLater = QDrag.__N.QDrag_deleteLater;
		calli(System.Void(System.IntPtr), this.self, qdrag_deleteLater);
	}

	// Token: 0x06000244 RID: 580 RVA: 0x00007664 File Offset: 0x00005864
	internal readonly string objectName()
	{
		this.NullCheck("objectName");
		method qdrag_objectName = QDrag.__N.QDrag_objectName;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qdrag_objectName));
	}

	// Token: 0x06000245 RID: 581 RVA: 0x00007694 File Offset: 0x00005894
	internal readonly void setObjectName(string name)
	{
		this.NullCheck("setObjectName");
		method qdrag_setObjectName = QDrag.__N.QDrag_setObjectName;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qdrag_setObjectName);
	}

	// Token: 0x06000246 RID: 582 RVA: 0x000076C4 File Offset: 0x000058C4
	internal readonly void setProperty(string key, bool value)
	{
		this.NullCheck("setProperty");
		method qdrag_setProperty = QDrag.__N.QDrag_setProperty;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, qdrag_setProperty);
	}

	// Token: 0x06000247 RID: 583 RVA: 0x000076FC File Offset: 0x000058FC
	internal readonly void setProperty(string key, float value)
	{
		this.NullCheck("setProperty");
		method qdrag_f = QDrag.__N.QDrag_f2;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, qdrag_f);
	}

	// Token: 0x06000248 RID: 584 RVA: 0x00007730 File Offset: 0x00005930
	internal readonly void setProperty(string key, string value)
	{
		this.NullCheck("setProperty");
		method qdrag_f = QDrag.__N.QDrag_f3;
		calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), qdrag_f);
	}

	// Token: 0x04000019 RID: 25
	internal IntPtr self;

	// Token: 0x020000EE RID: 238
	internal static class __N
	{
		// Token: 0x04000635 RID: 1589
		internal static method From_QObject_To_QDrag;

		// Token: 0x04000636 RID: 1590
		internal static method To_QObject_From_QDrag;

		// Token: 0x04000637 RID: 1591
		internal static method QDrag_Create;

		// Token: 0x04000638 RID: 1592
		internal static method QDrag_setPixmap;

		// Token: 0x04000639 RID: 1593
		internal static method QDrag_setHotSpot;

		// Token: 0x0400063A RID: 1594
		internal static method QDrag_setMimeData;

		// Token: 0x0400063B RID: 1595
		internal static method QDrag_mimeData;

		// Token: 0x0400063C RID: 1596
		internal static method QDrag_exec;

		// Token: 0x0400063D RID: 1597
		internal static method QDrag_deleteLater;

		// Token: 0x0400063E RID: 1598
		internal static method QDrag_objectName;

		// Token: 0x0400063F RID: 1599
		internal static method QDrag_setObjectName;

		// Token: 0x04000640 RID: 1600
		internal static method QDrag_setProperty;

		// Token: 0x04000641 RID: 1601
		internal static method QDrag_f2;

		// Token: 0x04000642 RID: 1602
		internal static method QDrag_f3;
	}
}
