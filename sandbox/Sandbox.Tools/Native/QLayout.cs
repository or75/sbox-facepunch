using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace Native
{
	// Token: 0x0200004D RID: 77
	internal struct QLayout
	{
		// Token: 0x06000A65 RID: 2661 RVA: 0x0001C27D File Offset: 0x0001A47D
		public static implicit operator IntPtr(QLayout value)
		{
			return value.self;
		}

		// Token: 0x06000A66 RID: 2662 RVA: 0x0001C288 File Offset: 0x0001A488
		public static implicit operator QLayout(IntPtr value)
		{
			return new QLayout
			{
				self = value
			};
		}

		// Token: 0x06000A67 RID: 2663 RVA: 0x0001C2A6 File Offset: 0x0001A4A6
		public static bool operator ==(QLayout c1, QLayout c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000A68 RID: 2664 RVA: 0x0001C2B9 File Offset: 0x0001A4B9
		public static bool operator !=(QLayout c1, QLayout c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000A69 RID: 2665 RVA: 0x0001C2CC File Offset: 0x0001A4CC
		public override bool Equals(object obj)
		{
			if (obj is QLayout)
			{
				QLayout c = (QLayout)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000A6A RID: 2666 RVA: 0x0001C2F6 File Offset: 0x0001A4F6
		internal QLayout(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000A6B RID: 2667 RVA: 0x0001C300 File Offset: 0x0001A500
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QLayout ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000A6C RID: 2668 RVA: 0x0001C33B File Offset: 0x0001A53B
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000A6D RID: 2669 RVA: 0x0001C34D File Offset: 0x0001A54D
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000A6E RID: 2670 RVA: 0x0001C358 File Offset: 0x0001A558
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000A6F RID: 2671 RVA: 0x0001C36B File Offset: 0x0001A56B
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QLayout was null when calling " + n);
			}
		}

		// Token: 0x06000A70 RID: 2672 RVA: 0x0001C386 File Offset: 0x0001A586
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000A71 RID: 2673 RVA: 0x0001C394 File Offset: 0x0001A594
		public static implicit operator QObject(QLayout value)
		{
			method to_QObject_From_QLayout = QLayout.__N.To_QObject_From_QLayout;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QLayout);
		}

		// Token: 0x06000A72 RID: 2674 RVA: 0x0001C3B8 File Offset: 0x0001A5B8
		public static explicit operator QLayout(QObject value)
		{
			method from_QObject_To_QLayout = QLayout.__N.From_QObject_To_QLayout;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QLayout);
		}

		// Token: 0x06000A73 RID: 2675 RVA: 0x0001C3DC File Offset: 0x0001A5DC
		internal readonly int spacing()
		{
			this.NullCheck("spacing");
			method qlayou_spacing = QLayout.__N.QLayou_spacing;
			return calli(System.Int32(System.IntPtr), this.self, qlayou_spacing);
		}

		// Token: 0x06000A74 RID: 2676 RVA: 0x0001C408 File Offset: 0x0001A608
		internal readonly void setSpacing(int spacing)
		{
			this.NullCheck("setSpacing");
			method qlayou_setSpacing = QLayout.__N.QLayou_setSpacing;
			calli(System.Void(System.IntPtr,System.Int32), this.self, spacing, qlayou_setSpacing);
		}

		// Token: 0x06000A75 RID: 2677 RVA: 0x0001C434 File Offset: 0x0001A634
		internal readonly void setContentsMargins(int left, int top, int right, int bottom)
		{
			this.NullCheck("setContentsMargins");
			method qlayou_setContentsMargins = QLayout.__N.QLayou_setContentsMargins;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32,System.Int32,System.Int32), this.self, left, top, right, bottom, qlayou_setContentsMargins);
		}

		// Token: 0x06000A76 RID: 2678 RVA: 0x0001C464 File Offset: 0x0001A664
		internal readonly void addWidget(QWidget w)
		{
			this.NullCheck("addWidget");
			method qlayou_addWidget = QLayout.__N.QLayou_addWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, w, qlayou_addWidget);
		}

		// Token: 0x06000A77 RID: 2679 RVA: 0x0001C494 File Offset: 0x0001A694
		internal readonly void removeWidget(QWidget w)
		{
			this.NullCheck("removeWidget");
			method qlayou_removeWidget = QLayout.__N.QLayou_removeWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, w, qlayou_removeWidget);
		}

		// Token: 0x06000A78 RID: 2680 RVA: 0x0001C4C4 File Offset: 0x0001A6C4
		internal readonly void addItem(QLayout w)
		{
			this.NullCheck("addItem");
			method qlayou_addItem = QLayout.__N.QLayou_addItem;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, w, qlayou_addItem);
		}

		// Token: 0x06000A79 RID: 2681 RVA: 0x0001C4F4 File Offset: 0x0001A6F4
		internal readonly void removeItem(QLayout w)
		{
			this.NullCheck("removeItem");
			method qlayou_removeItem = QLayout.__N.QLayou_removeItem;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, w, qlayou_removeItem);
		}

		// Token: 0x06000A7A RID: 2682 RVA: 0x0001C524 File Offset: 0x0001A724
		internal readonly void setEnabled(bool b)
		{
			this.NullCheck("setEnabled");
			method qlayou_setEnabled = QLayout.__N.QLayou_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qlayou_setEnabled);
		}

		// Token: 0x06000A7B RID: 2683 RVA: 0x0001C558 File Offset: 0x0001A758
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qlayou_isEnabled = QLayout.__N.QLayou_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qlayou_isEnabled) > 0;
		}

		// Token: 0x06000A7C RID: 2684 RVA: 0x0001C588 File Offset: 0x0001A788
		internal readonly void deleteLater()
		{
			this.NullCheck("deleteLater");
			method qlayou_deleteLater = QLayout.__N.QLayou_deleteLater;
			calli(System.Void(System.IntPtr), this.self, qlayou_deleteLater);
		}

		// Token: 0x06000A7D RID: 2685 RVA: 0x0001C5B4 File Offset: 0x0001A7B4
		internal readonly string objectName()
		{
			this.NullCheck("objectName");
			method qlayou_objectName = QLayout.__N.QLayou_objectName;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlayou_objectName));
		}

		// Token: 0x06000A7E RID: 2686 RVA: 0x0001C5E4 File Offset: 0x0001A7E4
		internal readonly void setObjectName(string name)
		{
			this.NullCheck("setObjectName");
			method qlayou_setObjectName = QLayout.__N.QLayou_setObjectName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qlayou_setObjectName);
		}

		// Token: 0x06000A7F RID: 2687 RVA: 0x0001C614 File Offset: 0x0001A814
		internal readonly void setProperty(string key, bool value)
		{
			this.NullCheck("setProperty");
			method qlayou_setProperty = QLayout.__N.QLayou_setProperty;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, qlayou_setProperty);
		}

		// Token: 0x06000A80 RID: 2688 RVA: 0x0001C64C File Offset: 0x0001A84C
		internal readonly void setProperty(string key, float value)
		{
			this.NullCheck("setProperty");
			method qlayou_f = QLayout.__N.QLayou_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, qlayou_f);
		}

		// Token: 0x06000A81 RID: 2689 RVA: 0x0001C680 File Offset: 0x0001A880
		internal readonly void setProperty(string key, string value)
		{
			this.NullCheck("setProperty");
			method qlayou_f = QLayout.__N.QLayou_f3;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), qlayou_f);
		}

		// Token: 0x04000058 RID: 88
		internal IntPtr self;

		// Token: 0x02000119 RID: 281
		internal static class __N
		{
			// Token: 0x04000C8F RID: 3215
			internal static method From_QObject_To_QLayout;

			// Token: 0x04000C90 RID: 3216
			internal static method To_QObject_From_QLayout;

			// Token: 0x04000C91 RID: 3217
			internal static method QLayou_spacing;

			// Token: 0x04000C92 RID: 3218
			internal static method QLayou_setSpacing;

			// Token: 0x04000C93 RID: 3219
			internal static method QLayou_setContentsMargins;

			// Token: 0x04000C94 RID: 3220
			internal static method QLayou_addWidget;

			// Token: 0x04000C95 RID: 3221
			internal static method QLayou_removeWidget;

			// Token: 0x04000C96 RID: 3222
			internal static method QLayou_addItem;

			// Token: 0x04000C97 RID: 3223
			internal static method QLayou_removeItem;

			// Token: 0x04000C98 RID: 3224
			internal static method QLayou_setEnabled;

			// Token: 0x04000C99 RID: 3225
			internal static method QLayou_isEnabled;

			// Token: 0x04000C9A RID: 3226
			internal static method QLayou_deleteLater;

			// Token: 0x04000C9B RID: 3227
			internal static method QLayou_objectName;

			// Token: 0x04000C9C RID: 3228
			internal static method QLayou_setObjectName;

			// Token: 0x04000C9D RID: 3229
			internal static method QLayou_setProperty;

			// Token: 0x04000C9E RID: 3230
			internal static method QLayou_f2;

			// Token: 0x04000C9F RID: 3231
			internal static method QLayou_f3;
		}
	}
}
