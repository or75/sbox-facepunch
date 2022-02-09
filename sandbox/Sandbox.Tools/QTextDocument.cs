using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;

// Token: 0x02000030 RID: 48
internal struct QTextDocument
{
	// Token: 0x06000421 RID: 1057 RVA: 0x0000BA77 File Offset: 0x00009C77
	public static implicit operator IntPtr(QTextDocument value)
	{
		return value.self;
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x0000BA80 File Offset: 0x00009C80
	public static implicit operator QTextDocument(IntPtr value)
	{
		return new QTextDocument
		{
			self = value
		};
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x0000BA9E File Offset: 0x00009C9E
	public static bool operator ==(QTextDocument c1, QTextDocument c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x0000BAB1 File Offset: 0x00009CB1
	public static bool operator !=(QTextDocument c1, QTextDocument c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x0000BAC4 File Offset: 0x00009CC4
	public override bool Equals(object obj)
	{
		if (obj is QTextDocument)
		{
			QTextDocument c = (QTextDocument)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x0000BAEE File Offset: 0x00009CEE
	internal QTextDocument(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x0000BAF8 File Offset: 0x00009CF8
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QTextDocument ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x06000428 RID: 1064 RVA: 0x0000BB34 File Offset: 0x00009D34
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000048 RID: 72
	// (get) Token: 0x06000429 RID: 1065 RVA: 0x0000BB46 File Offset: 0x00009D46
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x0000BB51 File Offset: 0x00009D51
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x0000BB64 File Offset: 0x00009D64
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QTextDocument was null when calling " + n);
		}
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x0000BB7F File Offset: 0x00009D7F
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x0000BB8C File Offset: 0x00009D8C
	public static implicit operator QObject(QTextDocument value)
	{
		method to_QObject_From_QTextDocument = QTextDocument.__N.To_QObject_From_QTextDocument;
		return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QTextDocument);
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x0000BBB0 File Offset: 0x00009DB0
	public static explicit operator QTextDocument(QObject value)
	{
		method from_QObject_To_QTextDocument = QTextDocument.__N.From_QObject_To_QTextDocument;
		return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QTextDocument);
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x0000BBD4 File Offset: 0x00009DD4
	internal readonly string toRawText()
	{
		this.NullCheck("toRawText");
		method qtextD_toRawText = QTextDocument.__N.QTextD_toRawText;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtextD_toRawText));
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x0000BC04 File Offset: 0x00009E04
	internal readonly string toPlainText()
	{
		this.NullCheck("toPlainText");
		method qtextD_toPlainText = QTextDocument.__N.QTextD_toPlainText;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtextD_toPlainText));
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x0000BC34 File Offset: 0x00009E34
	internal readonly void setPlainText(string text)
	{
		this.NullCheck("setPlainText");
		method qtextD_setPlainText = QTextDocument.__N.QTextD_setPlainText;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qtextD_setPlainText);
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0000BC64 File Offset: 0x00009E64
	internal readonly void setDefaultStyleSheet(string sheet)
	{
		this.NullCheck("setDefaultStyleSheet");
		method qtextD_setDefaultStyleSheet = QTextDocument.__N.QTextD_setDefaultStyleSheet;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qtextD_setDefaultStyleSheet);
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x0000BC94 File Offset: 0x00009E94
	internal readonly int blockCount()
	{
		this.NullCheck("blockCount");
		method qtextD_blockCount = QTextDocument.__N.QTextD_blockCount;
		return calli(System.Int32(System.IntPtr), this.self, qtextD_blockCount);
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x0000BCC0 File Offset: 0x00009EC0
	internal readonly int lineCount()
	{
		this.NullCheck("lineCount");
		method qtextD_lineCount = QTextDocument.__N.QTextD_lineCount;
		return calli(System.Int32(System.IntPtr), this.self, qtextD_lineCount);
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x0000BCEC File Offset: 0x00009EEC
	internal readonly int characterCount()
	{
		this.NullCheck("characterCount");
		method qtextD_characterCount = QTextDocument.__N.QTextD_characterCount;
		return calli(System.Int32(System.IntPtr), this.self, qtextD_characterCount);
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x0000BD18 File Offset: 0x00009F18
	internal readonly bool isModified()
	{
		this.NullCheck("isModified");
		method qtextD_isModified = QTextDocument.__N.QTextD_isModified;
		return calli(System.Int32(System.IntPtr), this.self, qtextD_isModified) > 0;
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x0000BD48 File Offset: 0x00009F48
	internal readonly int pageCount()
	{
		this.NullCheck("pageCount");
		method qtextD_pageCount = QTextDocument.__N.QTextD_pageCount;
		return calli(System.Int32(System.IntPtr), this.self, qtextD_pageCount);
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0000BD74 File Offset: 0x00009F74
	internal readonly QTextBlock findBlock(int pos)
	{
		this.NullCheck("findBlock");
		method qtextD_findBlock = QTextDocument.__N.QTextD_findBlock;
		return new QTextBlock(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, pos, qtextD_findBlock));
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x0000BDA4 File Offset: 0x00009FA4
	internal readonly QTextBlock findBlockByNumber(int blockNumber)
	{
		this.NullCheck("findBlockByNumber");
		method qtextD_findBlockByNumber = QTextDocument.__N.QTextD_findBlockByNumber;
		return new QTextBlock(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, blockNumber, qtextD_findBlockByNumber));
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x0000BDD4 File Offset: 0x00009FD4
	internal readonly QTextBlock findBlockByLineNumber(int blockNumber)
	{
		this.NullCheck("findBlockByLineNumber");
		method qtextD_findBlockByLineNumber = QTextDocument.__N.QTextD_findBlockByLineNumber;
		return new QTextBlock(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, blockNumber, qtextD_findBlockByLineNumber));
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x0000BE04 File Offset: 0x0000A004
	internal readonly QTextBlock begin()
	{
		this.NullCheck("begin");
		method qtextD_begin = QTextDocument.__N.QTextD_begin;
		return new QTextBlock(calli(System.IntPtr(System.IntPtr), this.self, qtextD_begin));
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x0000BE34 File Offset: 0x0000A034
	internal readonly QTextBlock end()
	{
		this.NullCheck("end");
		method qtextD_end = QTextDocument.__N.QTextD_end;
		return new QTextBlock(calli(System.IntPtr(System.IntPtr), this.self, qtextD_end));
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x0000BE64 File Offset: 0x0000A064
	internal readonly QTextBlock firstBlock()
	{
		this.NullCheck("firstBlock");
		method qtextD_firstBlock = QTextDocument.__N.QTextD_firstBlock;
		return new QTextBlock(calli(System.IntPtr(System.IntPtr), this.self, qtextD_firstBlock));
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x0000BE94 File Offset: 0x0000A094
	internal readonly QTextBlock lastBlock()
	{
		this.NullCheck("lastBlock");
		method qtextD_lastBlock = QTextDocument.__N.QTextD_lastBlock;
		return new QTextBlock(calli(System.IntPtr(System.IntPtr), this.self, qtextD_lastBlock));
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0000BEC4 File Offset: 0x0000A0C4
	internal readonly void deleteLater()
	{
		this.NullCheck("deleteLater");
		method qtextD_deleteLater = QTextDocument.__N.QTextD_deleteLater;
		calli(System.Void(System.IntPtr), this.self, qtextD_deleteLater);
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
	internal readonly string objectName()
	{
		this.NullCheck("objectName");
		method qtextD_objectName = QTextDocument.__N.QTextD_objectName;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtextD_objectName));
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x0000BF20 File Offset: 0x0000A120
	internal readonly void setObjectName(string name)
	{
		this.NullCheck("setObjectName");
		method qtextD_setObjectName = QTextDocument.__N.QTextD_setObjectName;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qtextD_setObjectName);
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x0000BF50 File Offset: 0x0000A150
	internal readonly void setProperty(string key, bool value)
	{
		this.NullCheck("setProperty");
		method qtextD_setProperty = QTextDocument.__N.QTextD_setProperty;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, qtextD_setProperty);
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x0000BF88 File Offset: 0x0000A188
	internal readonly void setProperty(string key, float value)
	{
		this.NullCheck("setProperty");
		method qtextD_f = QTextDocument.__N.QTextD_f2;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, qtextD_f);
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x0000BFBC File Offset: 0x0000A1BC
	internal readonly void setProperty(string key, string value)
	{
		this.NullCheck("setProperty");
		method qtextD_f = QTextDocument.__N.QTextD_f3;
		calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), qtextD_f);
	}

	// Token: 0x0400002A RID: 42
	internal IntPtr self;

	// Token: 0x02000100 RID: 256
	internal static class __N
	{
		// Token: 0x0400075F RID: 1887
		internal static method From_QObject_To_QTextDocument;

		// Token: 0x04000760 RID: 1888
		internal static method To_QObject_From_QTextDocument;

		// Token: 0x04000761 RID: 1889
		internal static method QTextD_toRawText;

		// Token: 0x04000762 RID: 1890
		internal static method QTextD_toPlainText;

		// Token: 0x04000763 RID: 1891
		internal static method QTextD_setPlainText;

		// Token: 0x04000764 RID: 1892
		internal static method QTextD_setDefaultStyleSheet;

		// Token: 0x04000765 RID: 1893
		internal static method QTextD_blockCount;

		// Token: 0x04000766 RID: 1894
		internal static method QTextD_lineCount;

		// Token: 0x04000767 RID: 1895
		internal static method QTextD_characterCount;

		// Token: 0x04000768 RID: 1896
		internal static method QTextD_isModified;

		// Token: 0x04000769 RID: 1897
		internal static method QTextD_pageCount;

		// Token: 0x0400076A RID: 1898
		internal static method QTextD_findBlock;

		// Token: 0x0400076B RID: 1899
		internal static method QTextD_findBlockByNumber;

		// Token: 0x0400076C RID: 1900
		internal static method QTextD_findBlockByLineNumber;

		// Token: 0x0400076D RID: 1901
		internal static method QTextD_begin;

		// Token: 0x0400076E RID: 1902
		internal static method QTextD_end;

		// Token: 0x0400076F RID: 1903
		internal static method QTextD_firstBlock;

		// Token: 0x04000770 RID: 1904
		internal static method QTextD_lastBlock;

		// Token: 0x04000771 RID: 1905
		internal static method QTextD_deleteLater;

		// Token: 0x04000772 RID: 1906
		internal static method QTextD_objectName;

		// Token: 0x04000773 RID: 1907
		internal static method QTextD_setObjectName;

		// Token: 0x04000774 RID: 1908
		internal static method QTextD_setProperty;

		// Token: 0x04000775 RID: 1909
		internal static method QTextD_f2;

		// Token: 0x04000776 RID: 1910
		internal static method QTextD_f3;
	}
}
