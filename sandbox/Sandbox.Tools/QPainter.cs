using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x0200002D RID: 45
internal struct QPainter
{
	// Token: 0x060003DD RID: 989 RVA: 0x0000B0D5 File Offset: 0x000092D5
	public static implicit operator IntPtr(QPainter value)
	{
		return value.self;
	}

	// Token: 0x060003DE RID: 990 RVA: 0x0000B0E0 File Offset: 0x000092E0
	public static implicit operator QPainter(IntPtr value)
	{
		return new QPainter
		{
			self = value
		};
	}

	// Token: 0x060003DF RID: 991 RVA: 0x0000B0FE File Offset: 0x000092FE
	public static bool operator ==(QPainter c1, QPainter c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x0000B111 File Offset: 0x00009311
	public static bool operator !=(QPainter c1, QPainter c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x0000B124 File Offset: 0x00009324
	public override bool Equals(object obj)
	{
		if (obj is QPainter)
		{
			QPainter c = (QPainter)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x0000B14E File Offset: 0x0000934E
	internal QPainter(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x0000B158 File Offset: 0x00009358
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QPainter ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x060003E4 RID: 996 RVA: 0x0000B194 File Offset: 0x00009394
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x060003E5 RID: 997 RVA: 0x0000B1A6 File Offset: 0x000093A6
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x0000B1B1 File Offset: 0x000093B1
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x0000B1C4 File Offset: 0x000093C4
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QPainter was null when calling " + n);
		}
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x0000B1DF File Offset: 0x000093DF
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x0000B1EC File Offset: 0x000093EC
	internal readonly void drawLine(Vector3 p1, Vector3 p2)
	{
		this.NullCheck("drawLine");
		method qpnter_drawLine = QPainter.__N.QPnter_drawLine;
		calli(System.Void(System.IntPtr,Vector3,Vector3), this.self, p1, p2, qpnter_drawLine);
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x0000B218 File Offset: 0x00009418
	internal readonly void drawRoundedRect(QRectF rect, float xRadius, float yRadius)
	{
		this.NullCheck("drawRoundedRect");
		method qpnter_drawRoundedRect = QPainter.__N.QPnter_drawRoundedRect;
		calli(System.Void(System.IntPtr,QRectF,System.Single,System.Single), this.self, rect, xRadius, yRadius, qpnter_drawRoundedRect);
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x0000B248 File Offset: 0x00009448
	internal readonly void drawRect(QRectF rect)
	{
		this.NullCheck("drawRect");
		method qpnter_drawRect = QPainter.__N.QPnter_drawRect;
		calli(System.Void(System.IntPtr,QRectF), this.self, rect, qpnter_drawRect);
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x0000B274 File Offset: 0x00009474
	internal readonly void drawEllipse(QRectF r)
	{
		this.NullCheck("drawEllipse");
		method qpnter_drawEllipse = QPainter.__N.QPnter_drawEllipse;
		calli(System.Void(System.IntPtr,QRectF), this.self, r, qpnter_drawEllipse);
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x0000B2A0 File Offset: 0x000094A0
	internal readonly float opacity()
	{
		this.NullCheck("opacity");
		method qpnter_opacity = QPainter.__N.QPnter_opacity;
		return calli(System.Single(System.IntPtr), this.self, qpnter_opacity);
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x0000B2CC File Offset: 0x000094CC
	internal readonly void setOpacity(float opacity)
	{
		this.NullCheck("setOpacity");
		method qpnter_setOpacity = QPainter.__N.QPnter_setOpacity;
		calli(System.Void(System.IntPtr,System.Single), this.self, opacity, qpnter_setOpacity);
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x0000B2F8 File Offset: 0x000094F8
	internal readonly void setBrush(QBrush brush)
	{
		this.NullCheck("setBrush");
		method qpnter_setBrush = QPainter.__N.QPnter_setBrush;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, brush, qpnter_setBrush);
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x0000B328 File Offset: 0x00009528
	internal readonly void setPen(QPen pen)
	{
		this.NullCheck("setPen");
		method qpnter_setPen = QPainter.__N.QPnter_setPen;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, pen, qpnter_setPen);
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x0000B358 File Offset: 0x00009558
	internal readonly void drawText(QRectF r, int flags, string text, out QRectF size)
	{
		this.NullCheck("drawText");
		method qpnter_drawText = QPainter.__N.QPnter_drawText;
		calli(System.Void(System.IntPtr,QRectF,System.Int32,System.IntPtr,QRectF& modreq(System.Runtime.InteropServices.OutAttribute)), this.self, r, flags, Interop.GetWPointer(text), ref size, qpnter_drawText);
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x0000B38C File Offset: 0x0000958C
	internal readonly QRectF boundingRect(QRectF rect, int flags, string text)
	{
		this.NullCheck("boundingRect");
		method qpnter_boundingRect = QPainter.__N.QPnter_boundingRect;
		return calli(QRectF(System.IntPtr,QRectF,System.Int32,System.IntPtr), this.self, rect, flags, Interop.GetWPointer(text), qpnter_boundingRect);
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x0000B3C0 File Offset: 0x000095C0
	internal readonly void translate(Vector3 offset)
	{
		this.NullCheck("translate");
		method qpnter_translate = QPainter.__N.QPnter_translate;
		calli(System.Void(System.IntPtr,Vector3), this.self, offset, qpnter_translate);
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x0000B3EC File Offset: 0x000095EC
	internal readonly void drawPoint(Vector3 pt)
	{
		this.NullCheck("drawPoint");
		method qpnter_drawPoint = QPainter.__N.QPnter_drawPoint;
		calli(System.Void(System.IntPtr,Vector3), this.self, pt, qpnter_drawPoint);
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x0000B418 File Offset: 0x00009618
	internal readonly void setRenderHint(RenderHints hint, bool on)
	{
		this.NullCheck("setRenderHint");
		method qpnter_setRenderHint = QPainter.__N.QPnter_setRenderHint;
		calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)hint, on ? 1 : 0, qpnter_setRenderHint);
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x0000B44C File Offset: 0x0000964C
	internal readonly void drawPixmap(QRectF r, QPixmap pm, QRectF s)
	{
		this.NullCheck("drawPixmap");
		method qpnter_drawPixmap = QPainter.__N.QPnter_drawPixmap;
		calli(System.Void(System.IntPtr,QRectF,System.IntPtr,QRectF), this.self, r, pm, s, qpnter_drawPixmap);
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x0000B480 File Offset: 0x00009680
	internal readonly void drawTiledPixmap(QRectF rect, QPixmap pm, Vector3 offset)
	{
		this.NullCheck("drawTiledPixmap");
		method qpnter_drawTiledPixmap = QPainter.__N.QPnter_drawTiledPixmap;
		calli(System.Void(System.IntPtr,QRectF,System.IntPtr,Vector3), this.self, rect, pm, offset, qpnter_drawTiledPixmap);
	}

	// Token: 0x04000027 RID: 39
	internal IntPtr self;

	// Token: 0x020000FD RID: 253
	internal static class __N
	{
		// Token: 0x0400073B RID: 1851
		internal static method QPnter_drawLine;

		// Token: 0x0400073C RID: 1852
		internal static method QPnter_drawRoundedRect;

		// Token: 0x0400073D RID: 1853
		internal static method QPnter_drawRect;

		// Token: 0x0400073E RID: 1854
		internal static method QPnter_drawEllipse;

		// Token: 0x0400073F RID: 1855
		internal static method QPnter_opacity;

		// Token: 0x04000740 RID: 1856
		internal static method QPnter_setOpacity;

		// Token: 0x04000741 RID: 1857
		internal static method QPnter_setBrush;

		// Token: 0x04000742 RID: 1858
		internal static method QPnter_setPen;

		// Token: 0x04000743 RID: 1859
		internal static method QPnter_drawText;

		// Token: 0x04000744 RID: 1860
		internal static method QPnter_boundingRect;

		// Token: 0x04000745 RID: 1861
		internal static method QPnter_translate;

		// Token: 0x04000746 RID: 1862
		internal static method QPnter_drawPoint;

		// Token: 0x04000747 RID: 1863
		internal static method QPnter_setRenderHint;

		// Token: 0x04000748 RID: 1864
		internal static method QPnter_drawPixmap;

		// Token: 0x04000749 RID: 1865
		internal static method QPnter_drawTiledPixmap;
	}
}
