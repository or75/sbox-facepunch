using System;
using System.Runtime.CompilerServices;

namespace Native
{
	// Token: 0x02000042 RID: 66
	internal struct QBrush : IDisposable
	{
		// Token: 0x060006F4 RID: 1780 RVA: 0x00012FD6 File Offset: 0x000111D6
		public static implicit operator IntPtr(QBrush value)
		{
			return value.self;
		}

		// Token: 0x060006F5 RID: 1781 RVA: 0x00012FE0 File Offset: 0x000111E0
		public static implicit operator QBrush(IntPtr value)
		{
			return new QBrush
			{
				self = value
			};
		}

		// Token: 0x060006F6 RID: 1782 RVA: 0x00012FFE File Offset: 0x000111FE
		public static bool operator ==(QBrush c1, QBrush c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x00013011 File Offset: 0x00011211
		public static bool operator !=(QBrush c1, QBrush c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00013024 File Offset: 0x00011224
		public override bool Equals(object obj)
		{
			if (obj is QBrush)
			{
				QBrush c = (QBrush)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x0001304E File Offset: 0x0001124E
		internal QBrush(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060006FA RID: 1786 RVA: 0x00013058 File Offset: 0x00011258
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QBrush ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060006FB RID: 1787 RVA: 0x00013093 File Offset: 0x00011293
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060006FC RID: 1788 RVA: 0x000130A5 File Offset: 0x000112A5
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x000130B0 File Offset: 0x000112B0
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x000130C3 File Offset: 0x000112C3
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QBrush was null when calling " + n);
			}
		}

		// Token: 0x060006FF RID: 1791 RVA: 0x000130DE File Offset: 0x000112DE
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000700 RID: 1792 RVA: 0x000130EC File Offset: 0x000112EC
		void IDisposable.Dispose()
		{
			if (this.IsNull)
			{
				return;
			}
			this.NullCheck("Dispose");
			method qbrush_Dispose = QBrush.__N.QBrush_Dispose;
			calli(System.Void(System.IntPtr), this.self, qbrush_Dispose);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x0001311F File Offset: 0x0001131F
		internal static QBrush Create()
		{
			return calli(System.IntPtr(), QBrush.__N.QBrush_Create);
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00013130 File Offset: 0x00011330
		internal static QBrush FromImage(QPixmap pixmap)
		{
			method qbrush_FromImage = QBrush.__N.QBrush_FromImage;
			return calli(System.IntPtr(System.IntPtr), pixmap, qbrush_FromImage);
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x00013154 File Offset: 0x00011354
		internal static QBrush CreateFromColor(Color32 color)
		{
			method qbrush_CreateFromColor = QBrush.__N.QBrush_CreateFromColor;
			return calli(System.IntPtr(Color32), color, qbrush_CreateFromColor);
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x00013174 File Offset: 0x00011374
		internal readonly void setColor(Color32 color)
		{
			this.NullCheck("setColor");
			method qbrush_setColor = QBrush.__N.QBrush_setColor;
			calli(System.Void(System.IntPtr,Color32), this.self, color, qbrush_setColor);
		}

		// Token: 0x0400004D RID: 77
		internal IntPtr self;

		// Token: 0x0200010E RID: 270
		internal static class __N
		{
			// Token: 0x040009A2 RID: 2466
			internal static method QBrush_Dispose;

			// Token: 0x040009A3 RID: 2467
			internal static method QBrush_Create;

			// Token: 0x040009A4 RID: 2468
			internal static method QBrush_FromImage;

			// Token: 0x040009A5 RID: 2469
			internal static method QBrush_CreateFromColor;

			// Token: 0x040009A6 RID: 2470
			internal static method QBrush_setColor;
		}
	}
}
