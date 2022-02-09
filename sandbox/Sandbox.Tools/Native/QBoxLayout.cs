using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000041 RID: 65
	internal struct QBoxLayout
	{
		// Token: 0x060006CA RID: 1738 RVA: 0x00012957 File Offset: 0x00010B57
		public static implicit operator IntPtr(QBoxLayout value)
		{
			return value.self;
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00012960 File Offset: 0x00010B60
		public static implicit operator QBoxLayout(IntPtr value)
		{
			return new QBoxLayout
			{
				self = value
			};
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0001297E File Offset: 0x00010B7E
		public static bool operator ==(QBoxLayout c1, QBoxLayout c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x00012991 File Offset: 0x00010B91
		public static bool operator !=(QBoxLayout c1, QBoxLayout c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x000129A4 File Offset: 0x00010BA4
		public override bool Equals(object obj)
		{
			if (obj is QBoxLayout)
			{
				QBoxLayout c = (QBoxLayout)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x000129CE File Offset: 0x00010BCE
		internal QBoxLayout(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x000129D8 File Offset: 0x00010BD8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QBoxLayout ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x00012A14 File Offset: 0x00010C14
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060006D2 RID: 1746 RVA: 0x00012A26 File Offset: 0x00010C26
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060006D3 RID: 1747 RVA: 0x00012A31 File Offset: 0x00010C31
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060006D4 RID: 1748 RVA: 0x00012A44 File Offset: 0x00010C44
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QBoxLayout was null when calling " + n);
			}
		}

		// Token: 0x060006D5 RID: 1749 RVA: 0x00012A5F File Offset: 0x00010C5F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060006D6 RID: 1750 RVA: 0x00012A6C File Offset: 0x00010C6C
		public static implicit operator QLayout(QBoxLayout value)
		{
			method to_QLayout_From_QBoxLayout = QBoxLayout.__N.To_QLayout_From_QBoxLayout;
			return calli(System.IntPtr(System.IntPtr), value, to_QLayout_From_QBoxLayout);
		}

		// Token: 0x060006D7 RID: 1751 RVA: 0x00012A90 File Offset: 0x00010C90
		public static explicit operator QBoxLayout(QLayout value)
		{
			method from_QLayout_To_QBoxLayout = QBoxLayout.__N.From_QLayout_To_QBoxLayout;
			return calli(System.IntPtr(System.IntPtr), value, from_QLayout_To_QBoxLayout);
		}

		// Token: 0x060006D8 RID: 1752 RVA: 0x00012AB4 File Offset: 0x00010CB4
		public static implicit operator QObject(QBoxLayout value)
		{
			method to_QObject_From_QBoxLayout = QBoxLayout.__N.To_QObject_From_QBoxLayout;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QBoxLayout);
		}

		// Token: 0x060006D9 RID: 1753 RVA: 0x00012AD8 File Offset: 0x00010CD8
		public static explicit operator QBoxLayout(QObject value)
		{
			method from_QObject_To_QBoxLayout = QBoxLayout.__N.From_QObject_To_QBoxLayout;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QBoxLayout);
		}

		// Token: 0x060006DA RID: 1754 RVA: 0x00012AFC File Offset: 0x00010CFC
		internal static QBoxLayout Create(BoxLayout.Direction direction, QWidget parent)
		{
			method qbxLyt_Create = QBoxLayout.__N.QBxLyt_Create;
			return calli(System.IntPtr(System.Int64,System.IntPtr), (long)direction, parent, qbxLyt_Create);
		}

		// Token: 0x060006DB RID: 1755 RVA: 0x00012B24 File Offset: 0x00010D24
		internal readonly BoxLayout.Direction direction()
		{
			this.NullCheck("direction");
			method qbxLyt_direction = QBoxLayout.__N.QBxLyt_direction;
			return calli(System.Int64(System.IntPtr), this.self, qbxLyt_direction);
		}

		// Token: 0x060006DC RID: 1756 RVA: 0x00012B50 File Offset: 0x00010D50
		internal readonly void setDirection(BoxLayout.Direction none)
		{
			this.NullCheck("setDirection");
			method qbxLyt_setDirection = QBoxLayout.__N.QBxLyt_setDirection;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)none, qbxLyt_setDirection);
		}

		// Token: 0x060006DD RID: 1757 RVA: 0x00012B7C File Offset: 0x00010D7C
		internal readonly void addSpacing(int size)
		{
			this.NullCheck("addSpacing");
			method qbxLyt_addSpacing = QBoxLayout.__N.QBxLyt_addSpacing;
			calli(System.Void(System.IntPtr,System.Int32), this.self, size, qbxLyt_addSpacing);
		}

		// Token: 0x060006DE RID: 1758 RVA: 0x00012BA8 File Offset: 0x00010DA8
		internal readonly void addStretch(int stretch)
		{
			this.NullCheck("addStretch");
			method qbxLyt_addStretch = QBoxLayout.__N.QBxLyt_addStretch;
			calli(System.Void(System.IntPtr,System.Int32), this.self, stretch, qbxLyt_addStretch);
		}

		// Token: 0x060006DF RID: 1759 RVA: 0x00012BD4 File Offset: 0x00010DD4
		internal readonly bool setStretchFactor(QWidget w, int stretch)
		{
			this.NullCheck("setStretchFactor");
			method qbxLyt_setStretchFactor = QBoxLayout.__N.QBxLyt_setStretchFactor;
			return calli(System.Int32(System.IntPtr,System.IntPtr,System.Int32), this.self, w, stretch, qbxLyt_setStretchFactor) > 0;
		}

		// Token: 0x060006E0 RID: 1760 RVA: 0x00012C08 File Offset: 0x00010E08
		internal readonly bool setStretchFactor(QLayout l, int stretch)
		{
			this.NullCheck("setStretchFactor");
			method qbxLyt_f = QBoxLayout.__N.QBxLyt_f2;
			return calli(System.Int32(System.IntPtr,System.IntPtr,System.Int32), this.self, l, stretch, qbxLyt_f) > 0;
		}

		// Token: 0x060006E1 RID: 1761 RVA: 0x00012C3C File Offset: 0x00010E3C
		internal readonly void setStretch(int index, int stretch)
		{
			this.NullCheck("setStretch");
			method qbxLyt_setStretch = QBoxLayout.__N.QBxLyt_setStretch;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, index, stretch, qbxLyt_setStretch);
		}

		// Token: 0x060006E2 RID: 1762 RVA: 0x00012C68 File Offset: 0x00010E68
		internal readonly int stretch(int index)
		{
			this.NullCheck("stretch");
			method qbxLyt_stretch = QBoxLayout.__N.QBxLyt_stretch;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, index, qbxLyt_stretch);
		}

		// Token: 0x060006E3 RID: 1763 RVA: 0x00012C94 File Offset: 0x00010E94
		internal readonly void addWidget(QWidget w, int stretch)
		{
			this.NullCheck("addWidget");
			method qbxLyt_addWidget = QBoxLayout.__N.QBxLyt_addWidget;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, w, stretch, qbxLyt_addWidget);
		}

		// Token: 0x060006E4 RID: 1764 RVA: 0x00012CC8 File Offset: 0x00010EC8
		internal readonly void addLayout(QLayout w, int stretch)
		{
			this.NullCheck("addLayout");
			method qbxLyt_addLayout = QBoxLayout.__N.QBxLyt_addLayout;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, w, stretch, qbxLyt_addLayout);
		}

		// Token: 0x060006E5 RID: 1765 RVA: 0x00012CFC File Offset: 0x00010EFC
		internal readonly int spacing()
		{
			this.NullCheck("spacing");
			method qbxLyt_spacing = QBoxLayout.__N.QBxLyt_spacing;
			return calli(System.Int32(System.IntPtr), this.self, qbxLyt_spacing);
		}

		// Token: 0x060006E6 RID: 1766 RVA: 0x00012D28 File Offset: 0x00010F28
		internal readonly void setSpacing(int spacing)
		{
			this.NullCheck("setSpacing");
			method qbxLyt_setSpacing = QBoxLayout.__N.QBxLyt_setSpacing;
			calli(System.Void(System.IntPtr,System.Int32), this.self, spacing, qbxLyt_setSpacing);
		}

		// Token: 0x060006E7 RID: 1767 RVA: 0x00012D54 File Offset: 0x00010F54
		internal readonly void setContentsMargins(int left, int top, int right, int bottom)
		{
			this.NullCheck("setContentsMargins");
			method qbxLyt_setContentsMargins = QBoxLayout.__N.QBxLyt_setContentsMargins;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32,System.Int32), this.self, left, top, right, bottom, qbxLyt_setContentsMargins);
		}

		// Token: 0x060006E8 RID: 1768 RVA: 0x00012D84 File Offset: 0x00010F84
		internal readonly void addWidget(QWidget w)
		{
			this.NullCheck("addWidget");
			method qbxLyt_f = QBoxLayout.__N.QBxLyt_f3;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, w, qbxLyt_f);
		}

		// Token: 0x060006E9 RID: 1769 RVA: 0x00012DB4 File Offset: 0x00010FB4
		internal readonly void removeWidget(QWidget w)
		{
			this.NullCheck("removeWidget");
			method qbxLyt_removeWidget = QBoxLayout.__N.QBxLyt_removeWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, w, qbxLyt_removeWidget);
		}

		// Token: 0x060006EA RID: 1770 RVA: 0x00012DE4 File Offset: 0x00010FE4
		internal readonly void addItem(QLayout w)
		{
			this.NullCheck("addItem");
			method qbxLyt_addItem = QBoxLayout.__N.QBxLyt_addItem;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, w, qbxLyt_addItem);
		}

		// Token: 0x060006EB RID: 1771 RVA: 0x00012E14 File Offset: 0x00011014
		internal readonly void removeItem(QLayout w)
		{
			this.NullCheck("removeItem");
			method qbxLyt_removeItem = QBoxLayout.__N.QBxLyt_removeItem;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, w, qbxLyt_removeItem);
		}

		// Token: 0x060006EC RID: 1772 RVA: 0x00012E44 File Offset: 0x00011044
		internal readonly void setEnabled(bool b)
		{
			this.NullCheck("setEnabled");
			method qbxLyt_setEnabled = QBoxLayout.__N.QBxLyt_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qbxLyt_setEnabled);
		}

		// Token: 0x060006ED RID: 1773 RVA: 0x00012E78 File Offset: 0x00011078
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qbxLyt_isEnabled = QBoxLayout.__N.QBxLyt_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qbxLyt_isEnabled) > 0;
		}

		// Token: 0x060006EE RID: 1774 RVA: 0x00012EA8 File Offset: 0x000110A8
		internal readonly void deleteLater()
		{
			this.NullCheck("deleteLater");
			method qbxLyt_deleteLater = QBoxLayout.__N.QBxLyt_deleteLater;
			calli(System.Void(System.IntPtr), this.self, qbxLyt_deleteLater);
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x00012ED4 File Offset: 0x000110D4
		internal readonly string objectName()
		{
			this.NullCheck("objectName");
			method qbxLyt_objectName = QBoxLayout.__N.QBxLyt_objectName;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qbxLyt_objectName));
		}

		// Token: 0x060006F0 RID: 1776 RVA: 0x00012F04 File Offset: 0x00011104
		internal readonly void setObjectName(string name)
		{
			this.NullCheck("setObjectName");
			method qbxLyt_setObjectName = QBoxLayout.__N.QBxLyt_setObjectName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qbxLyt_setObjectName);
		}

		// Token: 0x060006F1 RID: 1777 RVA: 0x00012F34 File Offset: 0x00011134
		internal readonly void setProperty(string key, bool value)
		{
			this.NullCheck("setProperty");
			method qbxLyt_setProperty = QBoxLayout.__N.QBxLyt_setProperty;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, qbxLyt_setProperty);
		}

		// Token: 0x060006F2 RID: 1778 RVA: 0x00012F6C File Offset: 0x0001116C
		internal readonly void setProperty(string key, float value)
		{
			this.NullCheck("setProperty");
			method qbxLyt_f = QBoxLayout.__N.QBxLyt_f4;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, qbxLyt_f);
		}

		// Token: 0x060006F3 RID: 1779 RVA: 0x00012FA0 File Offset: 0x000111A0
		internal readonly void setProperty(string key, string value)
		{
			this.NullCheck("setProperty");
			method qbxLyt_f = QBoxLayout.__N.QBxLyt_f5;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), qbxLyt_f);
		}

		// Token: 0x0400004C RID: 76
		internal IntPtr self;

		// Token: 0x0200010D RID: 269
		internal static class __N
		{
			// Token: 0x04000984 RID: 2436
			internal static method From_QLayout_To_QBoxLayout;

			// Token: 0x04000985 RID: 2437
			internal static method To_QLayout_From_QBoxLayout;

			// Token: 0x04000986 RID: 2438
			internal static method From_QObject_To_QBoxLayout;

			// Token: 0x04000987 RID: 2439
			internal static method To_QObject_From_QBoxLayout;

			// Token: 0x04000988 RID: 2440
			internal static method QBxLyt_Create;

			// Token: 0x04000989 RID: 2441
			internal static method QBxLyt_direction;

			// Token: 0x0400098A RID: 2442
			internal static method QBxLyt_setDirection;

			// Token: 0x0400098B RID: 2443
			internal static method QBxLyt_addSpacing;

			// Token: 0x0400098C RID: 2444
			internal static method QBxLyt_addStretch;

			// Token: 0x0400098D RID: 2445
			internal static method QBxLyt_setStretchFactor;

			// Token: 0x0400098E RID: 2446
			internal static method QBxLyt_f2;

			// Token: 0x0400098F RID: 2447
			internal static method QBxLyt_setStretch;

			// Token: 0x04000990 RID: 2448
			internal static method QBxLyt_stretch;

			// Token: 0x04000991 RID: 2449
			internal static method QBxLyt_addWidget;

			// Token: 0x04000992 RID: 2450
			internal static method QBxLyt_addLayout;

			// Token: 0x04000993 RID: 2451
			internal static method QBxLyt_spacing;

			// Token: 0x04000994 RID: 2452
			internal static method QBxLyt_setSpacing;

			// Token: 0x04000995 RID: 2453
			internal static method QBxLyt_setContentsMargins;

			// Token: 0x04000996 RID: 2454
			internal static method QBxLyt_f3;

			// Token: 0x04000997 RID: 2455
			internal static method QBxLyt_removeWidget;

			// Token: 0x04000998 RID: 2456
			internal static method QBxLyt_addItem;

			// Token: 0x04000999 RID: 2457
			internal static method QBxLyt_removeItem;

			// Token: 0x0400099A RID: 2458
			internal static method QBxLyt_setEnabled;

			// Token: 0x0400099B RID: 2459
			internal static method QBxLyt_isEnabled;

			// Token: 0x0400099C RID: 2460
			internal static method QBxLyt_deleteLater;

			// Token: 0x0400099D RID: 2461
			internal static method QBxLyt_objectName;

			// Token: 0x0400099E RID: 2462
			internal static method QBxLyt_setObjectName;

			// Token: 0x0400099F RID: 2463
			internal static method QBxLyt_setProperty;

			// Token: 0x040009A0 RID: 2464
			internal static method QBxLyt_f4;

			// Token: 0x040009A1 RID: 2465
			internal static method QBxLyt_f5;
		}
	}
}
