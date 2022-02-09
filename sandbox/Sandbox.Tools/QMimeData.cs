using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;

// Token: 0x0200002A RID: 42
internal struct QMimeData
{
	// Token: 0x06000392 RID: 914 RVA: 0x0000A6E5 File Offset: 0x000088E5
	public static implicit operator IntPtr(QMimeData value)
	{
		return value.self;
	}

	// Token: 0x06000393 RID: 915 RVA: 0x0000A6F0 File Offset: 0x000088F0
	public static implicit operator QMimeData(IntPtr value)
	{
		return new QMimeData
		{
			self = value
		};
	}

	// Token: 0x06000394 RID: 916 RVA: 0x0000A70E File Offset: 0x0000890E
	public static bool operator ==(QMimeData c1, QMimeData c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000395 RID: 917 RVA: 0x0000A721 File Offset: 0x00008921
	public static bool operator !=(QMimeData c1, QMimeData c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000396 RID: 918 RVA: 0x0000A734 File Offset: 0x00008934
	public override bool Equals(object obj)
	{
		if (obj is QMimeData)
		{
			QMimeData c = (QMimeData)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000397 RID: 919 RVA: 0x0000A75E File Offset: 0x0000895E
	internal QMimeData(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000398 RID: 920 RVA: 0x0000A768 File Offset: 0x00008968
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QMimeData ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x06000399 RID: 921 RVA: 0x0000A7A4 File Offset: 0x000089A4
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x0600039A RID: 922 RVA: 0x0000A7B6 File Offset: 0x000089B6
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600039B RID: 923 RVA: 0x0000A7C1 File Offset: 0x000089C1
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600039C RID: 924 RVA: 0x0000A7D4 File Offset: 0x000089D4
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QMimeData was null when calling " + n);
		}
	}

	// Token: 0x0600039D RID: 925 RVA: 0x0000A7EF File Offset: 0x000089EF
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x0600039E RID: 926 RVA: 0x0000A7FC File Offset: 0x000089FC
	public static implicit operator QObject(QMimeData value)
	{
		method to_QObject_From_QMimeData = QMimeData.__N.To_QObject_From_QMimeData;
		return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QMimeData);
	}

	// Token: 0x0600039F RID: 927 RVA: 0x0000A820 File Offset: 0x00008A20
	public static explicit operator QMimeData(QObject value)
	{
		method from_QObject_To_QMimeData = QMimeData.__N.From_QObject_To_QMimeData;
		return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QMimeData);
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x0000A844 File Offset: 0x00008A44
	internal static QMimeData Create()
	{
		return calli(System.IntPtr(), QMimeData.__N.QMmeDt_Create);
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x0000A858 File Offset: 0x00008A58
	internal readonly string text()
	{
		this.NullCheck("text");
		method qmmeDt_text = QMimeData.__N.QMmeDt_text;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmmeDt_text));
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x0000A888 File Offset: 0x00008A88
	internal readonly void setText(string text)
	{
		this.NullCheck("setText");
		method qmmeDt_setText = QMimeData.__N.QMmeDt_setText;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qmmeDt_setText);
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x0000A8B8 File Offset: 0x00008AB8
	internal readonly string html()
	{
		this.NullCheck("html");
		method qmmeDt_html = QMimeData.__N.QMmeDt_html;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmmeDt_html));
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x0000A8E8 File Offset: 0x00008AE8
	internal readonly void setHtml(string html)
	{
		this.NullCheck("setHtml");
		method qmmeDt_setHtml = QMimeData.__N.QMmeDt_setHtml;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(html), qmmeDt_setHtml);
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x0000A918 File Offset: 0x00008B18
	internal readonly void clear()
	{
		this.NullCheck("clear");
		method qmmeDt_clear = QMimeData.__N.QMmeDt_clear;
		calli(System.Void(System.IntPtr), this.self, qmmeDt_clear);
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x0000A944 File Offset: 0x00008B44
	internal readonly void deleteLater()
	{
		this.NullCheck("deleteLater");
		method qmmeDt_deleteLater = QMimeData.__N.QMmeDt_deleteLater;
		calli(System.Void(System.IntPtr), this.self, qmmeDt_deleteLater);
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x0000A970 File Offset: 0x00008B70
	internal readonly string objectName()
	{
		this.NullCheck("objectName");
		method qmmeDt_objectName = QMimeData.__N.QMmeDt_objectName;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmmeDt_objectName));
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x0000A9A0 File Offset: 0x00008BA0
	internal readonly void setObjectName(string name)
	{
		this.NullCheck("setObjectName");
		method qmmeDt_setObjectName = QMimeData.__N.QMmeDt_setObjectName;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qmmeDt_setObjectName);
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x0000A9D0 File Offset: 0x00008BD0
	internal readonly void setProperty(string key, bool value)
	{
		this.NullCheck("setProperty");
		method qmmeDt_setProperty = QMimeData.__N.QMmeDt_setProperty;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, qmmeDt_setProperty);
	}

	// Token: 0x060003AA RID: 938 RVA: 0x0000AA08 File Offset: 0x00008C08
	internal readonly void setProperty(string key, float value)
	{
		this.NullCheck("setProperty");
		method qmmeDt_f = QMimeData.__N.QMmeDt_f2;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, qmmeDt_f);
	}

	// Token: 0x060003AB RID: 939 RVA: 0x0000AA3C File Offset: 0x00008C3C
	internal readonly void setProperty(string key, string value)
	{
		this.NullCheck("setProperty");
		method qmmeDt_f = QMimeData.__N.QMmeDt_f3;
		calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), qmmeDt_f);
	}

	// Token: 0x04000024 RID: 36
	internal IntPtr self;

	// Token: 0x020000FA RID: 250
	internal static class __N
	{
		// Token: 0x04000714 RID: 1812
		internal static method From_QObject_To_QMimeData;

		// Token: 0x04000715 RID: 1813
		internal static method To_QObject_From_QMimeData;

		// Token: 0x04000716 RID: 1814
		internal static method QMmeDt_Create;

		// Token: 0x04000717 RID: 1815
		internal static method QMmeDt_text;

		// Token: 0x04000718 RID: 1816
		internal static method QMmeDt_setText;

		// Token: 0x04000719 RID: 1817
		internal static method QMmeDt_html;

		// Token: 0x0400071A RID: 1818
		internal static method QMmeDt_setHtml;

		// Token: 0x0400071B RID: 1819
		internal static method QMmeDt_clear;

		// Token: 0x0400071C RID: 1820
		internal static method QMmeDt_deleteLater;

		// Token: 0x0400071D RID: 1821
		internal static method QMmeDt_objectName;

		// Token: 0x0400071E RID: 1822
		internal static method QMmeDt_setObjectName;

		// Token: 0x0400071F RID: 1823
		internal static method QMmeDt_setProperty;

		// Token: 0x04000720 RID: 1824
		internal static method QMmeDt_f2;

		// Token: 0x04000721 RID: 1825
		internal static method QMmeDt_f3;
	}
}
