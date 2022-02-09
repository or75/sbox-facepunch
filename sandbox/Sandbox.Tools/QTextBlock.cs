using System;
using System.Runtime.CompilerServices;
using Sandbox;

// Token: 0x0200002F RID: 47
public class QTextBlock : IDisposable
{
	// Token: 0x0600040D RID: 1037 RVA: 0x0000B751 File Offset: 0x00009951
	internal QTextBlock(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x0000B760 File Offset: 0x00009960
	~QTextBlock()
	{
		if (!this.IsNull)
		{
			MainThread.QueueDispose(this);
		}
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x0000B794 File Offset: 0x00009994
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QTextBlock ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x06000410 RID: 1040 RVA: 0x0000B7D0 File Offset: 0x000099D0
	internal bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x06000411 RID: 1041 RVA: 0x0000B7E2 File Offset: 0x000099E2
	internal bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x0000B7ED File Offset: 0x000099ED
	internal IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x0000B800 File Offset: 0x00009A00
	internal void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QTextBlock was null when calling " + n);
		}
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0000B81B File Offset: 0x00009A1B
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x0000B828 File Offset: 0x00009A28
	void IDisposable.Dispose()
	{
		if (this.IsNull)
		{
			return;
		}
		this.NullCheck("Dispose");
		try
		{
			method qtextB_Dispose = QTextBlock.__N.QTextB_Dispose;
			calli(System.Void(System.IntPtr), this.self, qtextB_Dispose);
		}
		finally
		{
			this.self = 0;
		}
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x0000B87C File Offset: 0x00009A7C
	internal int position()
	{
		this.NullCheck("position");
		method qtextB_position = QTextBlock.__N.QTextB_position;
		return calli(System.Int32(System.IntPtr), this.self, qtextB_position);
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0000B8A8 File Offset: 0x00009AA8
	internal int length()
	{
		this.NullCheck("length");
		method qtextB_length = QTextBlock.__N.QTextB_length;
		return calli(System.Int32(System.IntPtr), this.self, qtextB_length);
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x0000B8D4 File Offset: 0x00009AD4
	internal string text()
	{
		this.NullCheck("text");
		method qtextB_text = QTextBlock.__N.QTextB_text;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtextB_text));
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x0000B904 File Offset: 0x00009B04
	internal bool isVisible()
	{
		this.NullCheck("isVisible");
		method qtextB_isVisible = QTextBlock.__N.QTextB_isVisible;
		return calli(System.Int32(System.IntPtr), this.self, qtextB_isVisible) > 0;
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x0000B934 File Offset: 0x00009B34
	internal void setVisible(bool visible)
	{
		this.NullCheck("setVisible");
		method qtextB_setVisible = QTextBlock.__N.QTextB_setVisible;
		calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qtextB_setVisible);
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x0000B968 File Offset: 0x00009B68
	internal int blockNumber()
	{
		this.NullCheck("blockNumber");
		method qtextB_blockNumber = QTextBlock.__N.QTextB_blockNumber;
		return calli(System.Int32(System.IntPtr), this.self, qtextB_blockNumber);
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x0000B994 File Offset: 0x00009B94
	internal int firstLineNumber()
	{
		this.NullCheck("firstLineNumber");
		method qtextB_firstLineNumber = QTextBlock.__N.QTextB_firstLineNumber;
		return calli(System.Int32(System.IntPtr), this.self, qtextB_firstLineNumber);
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x0000B9C0 File Offset: 0x00009BC0
	internal void setLineCount(int count)
	{
		this.NullCheck("setLineCount");
		method qtextB_setLineCount = QTextBlock.__N.QTextB_setLineCount;
		calli(System.Void(System.IntPtr,System.Int32), this.self, count, qtextB_setLineCount);
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x0000B9EC File Offset: 0x00009BEC
	internal int lineCount()
	{
		this.NullCheck("lineCount");
		method qtextB_lineCount = QTextBlock.__N.QTextB_lineCount;
		return calli(System.Int32(System.IntPtr), this.self, qtextB_lineCount);
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x0000BA18 File Offset: 0x00009C18
	internal QTextBlock next()
	{
		this.NullCheck("next");
		method qtextB_next = QTextBlock.__N.QTextB_next;
		return new QTextBlock(calli(System.IntPtr(System.IntPtr), this.self, qtextB_next));
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x0000BA48 File Offset: 0x00009C48
	internal QTextBlock previous()
	{
		this.NullCheck("previous");
		method qtextB_previous = QTextBlock.__N.QTextB_previous;
		return new QTextBlock(calli(System.IntPtr(System.IntPtr), this.self, qtextB_previous));
	}

	// Token: 0x04000029 RID: 41
	internal IntPtr self;

	// Token: 0x020000FF RID: 255
	internal static class __N
	{
		// Token: 0x04000753 RID: 1875
		internal static method QTextB_Dispose;

		// Token: 0x04000754 RID: 1876
		internal static method QTextB_position;

		// Token: 0x04000755 RID: 1877
		internal static method QTextB_length;

		// Token: 0x04000756 RID: 1878
		internal static method QTextB_text;

		// Token: 0x04000757 RID: 1879
		internal static method QTextB_isVisible;

		// Token: 0x04000758 RID: 1880
		internal static method QTextB_setVisible;

		// Token: 0x04000759 RID: 1881
		internal static method QTextB_blockNumber;

		// Token: 0x0400075A RID: 1882
		internal static method QTextB_firstLineNumber;

		// Token: 0x0400075B RID: 1883
		internal static method QTextB_setLineCount;

		// Token: 0x0400075C RID: 1884
		internal static method QTextB_lineCount;

		// Token: 0x0400075D RID: 1885
		internal static method QTextB_next;

		// Token: 0x0400075E RID: 1886
		internal static method QTextB_previous;
	}
}
