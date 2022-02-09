using System;
using System.Runtime.CompilerServices;
using Tools;

namespace Native
{
	// Token: 0x0200003E RID: 62
	internal struct QAbstractScrollArea
	{
		// Token: 0x06000685 RID: 1669 RVA: 0x00011F3D File Offset: 0x0001013D
		public static implicit operator IntPtr(QAbstractScrollArea value)
		{
			return value.self;
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x00011F48 File Offset: 0x00010148
		public static implicit operator QAbstractScrollArea(IntPtr value)
		{
			return new QAbstractScrollArea
			{
				self = value
			};
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x00011F66 File Offset: 0x00010166
		public static bool operator ==(QAbstractScrollArea c1, QAbstractScrollArea c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000688 RID: 1672 RVA: 0x00011F79 File Offset: 0x00010179
		public static bool operator !=(QAbstractScrollArea c1, QAbstractScrollArea c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x00011F8C File Offset: 0x0001018C
		public override bool Equals(object obj)
		{
			if (obj is QAbstractScrollArea)
			{
				QAbstractScrollArea c = (QAbstractScrollArea)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x00011FB6 File Offset: 0x000101B6
		internal QAbstractScrollArea(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x00011FC0 File Offset: 0x000101C0
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QAbstractScrollArea ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600068C RID: 1676 RVA: 0x00011FFC File Offset: 0x000101FC
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x0001200E File Offset: 0x0001020E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x00012019 File Offset: 0x00010219
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0001202C File Offset: 0x0001022C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QAbstractScrollArea was null when calling " + n);
			}
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x00012047 File Offset: 0x00010247
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x00012054 File Offset: 0x00010254
		public static implicit operator QFrame(QAbstractScrollArea value)
		{
			method to_QFrame_From_QAbstractScrollArea = QAbstractScrollArea.__N.To_QFrame_From_QAbstractScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, to_QFrame_From_QAbstractScrollArea);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x00012078 File Offset: 0x00010278
		public static explicit operator QAbstractScrollArea(QFrame value)
		{
			method from_QFrame_To_QAbstractScrollArea = QAbstractScrollArea.__N.From_QFrame_To_QAbstractScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, from_QFrame_To_QAbstractScrollArea);
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0001209C File Offset: 0x0001029C
		public static implicit operator QWidget(QAbstractScrollArea value)
		{
			method to_QWidget_From_QAbstractScrollArea = QAbstractScrollArea.__N.To_QWidget_From_QAbstractScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QAbstractScrollArea);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x000120C0 File Offset: 0x000102C0
		public static explicit operator QAbstractScrollArea(QWidget value)
		{
			method from_QWidget_To_QAbstractScrollArea = QAbstractScrollArea.__N.From_QWidget_To_QAbstractScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QAbstractScrollArea);
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x000120E4 File Offset: 0x000102E4
		public static implicit operator QObject(QAbstractScrollArea value)
		{
			method to_QObject_From_QAbstractScrollArea = QAbstractScrollArea.__N.To_QObject_From_QAbstractScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QAbstractScrollArea);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x00012108 File Offset: 0x00010308
		public static explicit operator QAbstractScrollArea(QObject value)
		{
			method from_QObject_To_QAbstractScrollArea = QAbstractScrollArea.__N.From_QObject_To_QAbstractScrollArea;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QAbstractScrollArea);
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0001212C File Offset: 0x0001032C
		internal readonly QScrollBar horizontalScrollBar()
		{
			this.NullCheck("horizontalScrollBar");
			method qabstr_horizontalScrollBar = QAbstractScrollArea.__N.QAbstr_horizontalScrollBar;
			return calli(System.IntPtr(System.IntPtr), this.self, qabstr_horizontalScrollBar);
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0001215C File Offset: 0x0001035C
		internal readonly QScrollBar verticalScrollBar()
		{
			this.NullCheck("verticalScrollBar");
			method qabstr_verticalScrollBar = QAbstractScrollArea.__N.QAbstr_verticalScrollBar;
			return calli(System.IntPtr(System.IntPtr), this.self, qabstr_verticalScrollBar);
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0001218C File Offset: 0x0001038C
		internal readonly ScrollbarMode horizontalScrollBarPolicy()
		{
			this.NullCheck("horizontalScrollBarPolicy");
			method qabstr_horizontalScrollBarPolicy = QAbstractScrollArea.__N.QAbstr_horizontalScrollBarPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qabstr_horizontalScrollBarPolicy);
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x000121B8 File Offset: 0x000103B8
		internal readonly void setHorizontalScrollBarPolicy(ScrollbarMode m)
		{
			this.NullCheck("setHorizontalScrollBarPolicy");
			method qabstr_setHorizontalScrollBarPolicy = QAbstractScrollArea.__N.QAbstr_setHorizontalScrollBarPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)m, qabstr_setHorizontalScrollBarPolicy);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x000121E4 File Offset: 0x000103E4
		internal readonly ScrollbarMode verticalScrollBarPolicy()
		{
			this.NullCheck("verticalScrollBarPolicy");
			method qabstr_verticalScrollBarPolicy = QAbstractScrollArea.__N.QAbstr_verticalScrollBarPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qabstr_verticalScrollBarPolicy);
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x00012210 File Offset: 0x00010410
		internal readonly void setVerticalScrollBarPolicy(ScrollbarMode m)
		{
			this.NullCheck("setVerticalScrollBarPolicy");
			method qabstr_setVerticalScrollBarPolicy = QAbstractScrollArea.__N.QAbstr_setVerticalScrollBarPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)m, qabstr_setVerticalScrollBarPolicy);
		}

		// Token: 0x0400004A RID: 74
		internal IntPtr self;

		// Token: 0x0200010A RID: 266
		internal static class __N
		{
			// Token: 0x04000957 RID: 2391
			internal static method From_QFrame_To_QAbstractScrollArea;

			// Token: 0x04000958 RID: 2392
			internal static method To_QFrame_From_QAbstractScrollArea;

			// Token: 0x04000959 RID: 2393
			internal static method From_QWidget_To_QAbstractScrollArea;

			// Token: 0x0400095A RID: 2394
			internal static method To_QWidget_From_QAbstractScrollArea;

			// Token: 0x0400095B RID: 2395
			internal static method From_QObject_To_QAbstractScrollArea;

			// Token: 0x0400095C RID: 2396
			internal static method To_QObject_From_QAbstractScrollArea;

			// Token: 0x0400095D RID: 2397
			internal static method QAbstr_horizontalScrollBar;

			// Token: 0x0400095E RID: 2398
			internal static method QAbstr_verticalScrollBar;

			// Token: 0x0400095F RID: 2399
			internal static method QAbstr_horizontalScrollBarPolicy;

			// Token: 0x04000960 RID: 2400
			internal static method QAbstr_setHorizontalScrollBarPolicy;

			// Token: 0x04000961 RID: 2401
			internal static method QAbstr_verticalScrollBarPolicy;

			// Token: 0x04000962 RID: 2402
			internal static method QAbstr_setVerticalScrollBarPolicy;
		}
	}
}
