using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace Native
{
	// Token: 0x0200003F RID: 63
	internal struct QAction
	{
		// Token: 0x0600069D RID: 1693 RVA: 0x0001223C File Offset: 0x0001043C
		public static implicit operator IntPtr(QAction value)
		{
			return value.self;
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x00012244 File Offset: 0x00010444
		public static implicit operator QAction(IntPtr value)
		{
			return new QAction
			{
				self = value
			};
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x00012262 File Offset: 0x00010462
		public static bool operator ==(QAction c1, QAction c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x00012275 File Offset: 0x00010475
		public static bool operator !=(QAction c1, QAction c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x00012288 File Offset: 0x00010488
		public override bool Equals(object obj)
		{
			if (obj is QAction)
			{
				QAction c = (QAction)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x000122B2 File Offset: 0x000104B2
		internal QAction(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x000122BC File Offset: 0x000104BC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QAction ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060006A4 RID: 1700 RVA: 0x000122F7 File Offset: 0x000104F7
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060006A5 RID: 1701 RVA: 0x00012309 File Offset: 0x00010509
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00012314 File Offset: 0x00010514
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00012327 File Offset: 0x00010527
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QAction was null when calling " + n);
			}
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00012342 File Offset: 0x00010542
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x00012350 File Offset: 0x00010550
		public static implicit operator QObject(QAction value)
		{
			method to_QObject_From_QAction = QAction.__N.To_QObject_From_QAction;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QAction);
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x00012374 File Offset: 0x00010574
		public static explicit operator QAction(QObject value)
		{
			method from_QObject_To_QAction = QAction.__N.From_QObject_To_QAction;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QAction);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00012398 File Offset: 0x00010598
		internal readonly void setText(string text)
		{
			this.NullCheck("setText");
			method qactio_setText = QAction.__N.QActio_setText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qactio_setText);
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x000123C8 File Offset: 0x000105C8
		internal readonly string text()
		{
			this.NullCheck("text");
			method qactio_text = QAction.__N.QActio_text;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qactio_text));
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x000123F8 File Offset: 0x000105F8
		internal readonly void setIcon(string icon)
		{
			this.NullCheck("setIcon");
			method qactio_setIcon = QAction.__N.QActio_setIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qactio_setIcon);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00012428 File Offset: 0x00010628
		internal readonly void setToolTip(string tip)
		{
			this.NullCheck("setToolTip");
			method qactio_setToolTip = QAction.__N.QActio_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(tip), qactio_setToolTip);
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x00012458 File Offset: 0x00010658
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qactio_toolTip = QAction.__N.QActio_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qactio_toolTip));
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x00012488 File Offset: 0x00010688
		internal readonly void setStatusTip(string statusTip)
		{
			this.NullCheck("setStatusTip");
			method qactio_setStatusTip = QAction.__N.QActio_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(statusTip), qactio_setStatusTip);
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x000124B8 File Offset: 0x000106B8
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qactio_statusTip = QAction.__N.QActio_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qactio_statusTip));
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x000124E8 File Offset: 0x000106E8
		internal readonly void setSeparator(bool b)
		{
			this.NullCheck("setSeparator");
			method qactio_setSeparator = QAction.__N.QActio_setSeparator;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qactio_setSeparator);
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x0001251C File Offset: 0x0001071C
		internal readonly bool isSeparator()
		{
			this.NullCheck("isSeparator");
			method qactio_isSeparator = QAction.__N.QActio_isSeparator;
			return calli(System.Int32(System.IntPtr), this.self, qactio_isSeparator) > 0;
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0001254C File Offset: 0x0001074C
		internal readonly void setCheckable(bool B)
		{
			this.NullCheck("setCheckable");
			method qactio_setCheckable = QAction.__N.QActio_setCheckable;
			calli(System.Void(System.IntPtr,System.Int32), this.self, B ? 1 : 0, qactio_setCheckable);
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x00012580 File Offset: 0x00010780
		internal readonly bool isCheckable()
		{
			this.NullCheck("isCheckable");
			method qactio_isCheckable = QAction.__N.QActio_isCheckable;
			return calli(System.Int32(System.IntPtr), this.self, qactio_isCheckable) > 0;
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x000125B0 File Offset: 0x000107B0
		internal readonly bool isChecked()
		{
			this.NullCheck("isChecked");
			method qactio_isChecked = QAction.__N.QActio_isChecked;
			return calli(System.Int32(System.IntPtr), this.self, qactio_isChecked) > 0;
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x000125E0 File Offset: 0x000107E0
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qactio_isEnabled = QAction.__N.QActio_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qactio_isEnabled) > 0;
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x00012610 File Offset: 0x00010810
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qactio_isVisible = QAction.__N.QActio_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qactio_isVisible) > 0;
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00012640 File Offset: 0x00010840
		internal readonly void setChecked(bool b)
		{
			this.NullCheck("setChecked");
			method qactio_setChecked = QAction.__N.QActio_setChecked;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qactio_setChecked);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x00012674 File Offset: 0x00010874
		internal readonly void setEnabled(bool b)
		{
			this.NullCheck("setEnabled");
			method qactio_setEnabled = QAction.__N.QActio_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, qactio_setEnabled);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x000126A8 File Offset: 0x000108A8
		internal readonly void setIconVisibleInMenu(bool visible)
		{
			this.NullCheck("setIconVisibleInMenu");
			method qactio_setIconVisibleInMenu = QAction.__N.QActio_setIconVisibleInMenu;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qactio_setIconVisibleInMenu);
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x000126DC File Offset: 0x000108DC
		internal readonly bool isIconVisibleInMenu()
		{
			this.NullCheck("isIconVisibleInMenu");
			method qactio_isIconVisibleInMenu = QAction.__N.QActio_isIconVisibleInMenu;
			return calli(System.Int32(System.IntPtr), this.self, qactio_isIconVisibleInMenu) > 0;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x0001270C File Offset: 0x0001090C
		internal readonly void setShortcutVisibleInContextMenu(bool show)
		{
			this.NullCheck("setShortcutVisibleInContextMenu");
			method qactio_setShortcutVisibleInContextMenu = QAction.__N.QActio_setShortcutVisibleInContextMenu;
			calli(System.Void(System.IntPtr,System.Int32), this.self, show ? 1 : 0, qactio_setShortcutVisibleInContextMenu);
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00012740 File Offset: 0x00010940
		internal readonly bool isShortcutVisibleInContextMenu()
		{
			this.NullCheck("isShortcutVisibleInContextMenu");
			method qactio_isShortcutVisibleInContextMenu = QAction.__N.QActio_isShortcutVisibleInContextMenu;
			return calli(System.Int32(System.IntPtr), this.self, qactio_isShortcutVisibleInContextMenu) > 0;
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00012770 File Offset: 0x00010970
		internal readonly void trigger()
		{
			this.NullCheck("trigger");
			method qactio_trigger = QAction.__N.QActio_trigger;
			calli(System.Void(System.IntPtr), this.self, qactio_trigger);
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x0001279C File Offset: 0x0001099C
		internal readonly void setMenu(QMenu menu)
		{
			this.NullCheck("setMenu");
			method qactio_setMenu = QAction.__N.QActio_setMenu;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, menu, qactio_setMenu);
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x000127CC File Offset: 0x000109CC
		internal readonly void setShortcut(string str)
		{
			this.NullCheck("setShortcut");
			method qactio_setShortcut = QAction.__N.QActio_setShortcut;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qactio_setShortcut);
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x000127FC File Offset: 0x000109FC
		internal readonly void deleteLater()
		{
			this.NullCheck("deleteLater");
			method qactio_deleteLater = QAction.__N.QActio_deleteLater;
			calli(System.Void(System.IntPtr), this.self, qactio_deleteLater);
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x00012828 File Offset: 0x00010A28
		internal readonly string objectName()
		{
			this.NullCheck("objectName");
			method qactio_objectName = QAction.__N.QActio_objectName;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qactio_objectName));
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x00012858 File Offset: 0x00010A58
		internal readonly void setObjectName(string name)
		{
			this.NullCheck("setObjectName");
			method qactio_setObjectName = QAction.__N.QActio_setObjectName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qactio_setObjectName);
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x00012888 File Offset: 0x00010A88
		internal readonly void setProperty(string key, bool value)
		{
			this.NullCheck("setProperty");
			method qactio_setProperty = QAction.__N.QActio_setProperty;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, qactio_setProperty);
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x000128C0 File Offset: 0x00010AC0
		internal readonly void setProperty(string key, float value)
		{
			this.NullCheck("setProperty");
			method qactio_f = QAction.__N.QActio_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, qactio_f);
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x000128F4 File Offset: 0x00010AF4
		internal readonly void setProperty(string key, string value)
		{
			this.NullCheck("setProperty");
			method qactio_f = QAction.__N.QActio_f3;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), qactio_f);
		}

		// Token: 0x0400004B RID: 75
		internal IntPtr self;

		// Token: 0x0200010B RID: 267
		internal static class __N
		{
			// Token: 0x04000963 RID: 2403
			internal static method From_QObject_To_QAction;

			// Token: 0x04000964 RID: 2404
			internal static method To_QObject_From_QAction;

			// Token: 0x04000965 RID: 2405
			internal static method QActio_setText;

			// Token: 0x04000966 RID: 2406
			internal static method QActio_text;

			// Token: 0x04000967 RID: 2407
			internal static method QActio_setIcon;

			// Token: 0x04000968 RID: 2408
			internal static method QActio_setToolTip;

			// Token: 0x04000969 RID: 2409
			internal static method QActio_toolTip;

			// Token: 0x0400096A RID: 2410
			internal static method QActio_setStatusTip;

			// Token: 0x0400096B RID: 2411
			internal static method QActio_statusTip;

			// Token: 0x0400096C RID: 2412
			internal static method QActio_setSeparator;

			// Token: 0x0400096D RID: 2413
			internal static method QActio_isSeparator;

			// Token: 0x0400096E RID: 2414
			internal static method QActio_setCheckable;

			// Token: 0x0400096F RID: 2415
			internal static method QActio_isCheckable;

			// Token: 0x04000970 RID: 2416
			internal static method QActio_isChecked;

			// Token: 0x04000971 RID: 2417
			internal static method QActio_isEnabled;

			// Token: 0x04000972 RID: 2418
			internal static method QActio_isVisible;

			// Token: 0x04000973 RID: 2419
			internal static method QActio_setChecked;

			// Token: 0x04000974 RID: 2420
			internal static method QActio_setEnabled;

			// Token: 0x04000975 RID: 2421
			internal static method QActio_setIconVisibleInMenu;

			// Token: 0x04000976 RID: 2422
			internal static method QActio_isIconVisibleInMenu;

			// Token: 0x04000977 RID: 2423
			internal static method QActio_setShortcutVisibleInContextMenu;

			// Token: 0x04000978 RID: 2424
			internal static method QActio_isShortcutVisibleInContextMenu;

			// Token: 0x04000979 RID: 2425
			internal static method QActio_trigger;

			// Token: 0x0400097A RID: 2426
			internal static method QActio_setMenu;

			// Token: 0x0400097B RID: 2427
			internal static method QActio_setShortcut;

			// Token: 0x0400097C RID: 2428
			internal static method QActio_deleteLater;

			// Token: 0x0400097D RID: 2429
			internal static method QActio_objectName;

			// Token: 0x0400097E RID: 2430
			internal static method QActio_setObjectName;

			// Token: 0x0400097F RID: 2431
			internal static method QActio_setProperty;

			// Token: 0x04000980 RID: 2432
			internal static method QActio_f2;

			// Token: 0x04000981 RID: 2433
			internal static method QActio_f3;
		}
	}
}
