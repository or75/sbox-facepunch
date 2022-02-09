using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000037 RID: 55
	internal struct CAction
	{
		// Token: 0x0600046D RID: 1133 RVA: 0x0000C5B7 File Offset: 0x0000A7B7
		public static implicit operator IntPtr(CAction value)
		{
			return value.self;
		}

		// Token: 0x0600046E RID: 1134 RVA: 0x0000C5C0 File Offset: 0x0000A7C0
		public static implicit operator CAction(IntPtr value)
		{
			return new CAction
			{
				self = value
			};
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0000C5DE File Offset: 0x0000A7DE
		public static bool operator ==(CAction c1, CAction c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000470 RID: 1136 RVA: 0x0000C5F1 File Offset: 0x0000A7F1
		public static bool operator !=(CAction c1, CAction c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000471 RID: 1137 RVA: 0x0000C604 File Offset: 0x0000A804
		public override bool Equals(object obj)
		{
			if (obj is CAction)
			{
				CAction c = (CAction)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000472 RID: 1138 RVA: 0x0000C62E File Offset: 0x0000A82E
		internal CAction(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000473 RID: 1139 RVA: 0x0000C638 File Offset: 0x0000A838
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CAction ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x0000C673 File Offset: 0x0000A873
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000475 RID: 1141 RVA: 0x0000C685 File Offset: 0x0000A885
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000476 RID: 1142 RVA: 0x0000C690 File Offset: 0x0000A890
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000477 RID: 1143 RVA: 0x0000C6A3 File Offset: 0x0000A8A3
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CAction was null when calling " + n);
			}
		}

		// Token: 0x06000478 RID: 1144 RVA: 0x0000C6BE File Offset: 0x0000A8BE
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000479 RID: 1145 RVA: 0x0000C6CC File Offset: 0x0000A8CC
		public static implicit operator QAction(CAction value)
		{
			method to_QAction_From_CAction = CAction.__N.To_QAction_From_CAction;
			return calli(System.IntPtr(System.IntPtr), value, to_QAction_From_CAction);
		}

		// Token: 0x0600047A RID: 1146 RVA: 0x0000C6F0 File Offset: 0x0000A8F0
		public static explicit operator CAction(QAction value)
		{
			method from_QAction_To_CAction = CAction.__N.From_QAction_To_CAction;
			return calli(System.IntPtr(System.IntPtr), value, from_QAction_To_CAction);
		}

		// Token: 0x0600047B RID: 1147 RVA: 0x0000C714 File Offset: 0x0000A914
		public static implicit operator QObject(CAction value)
		{
			method to_QObject_From_CAction = CAction.__N.To_QObject_From_CAction;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_CAction);
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000C738 File Offset: 0x0000A938
		public static explicit operator CAction(QObject value)
		{
			method from_QObject_To_CAction = CAction.__N.From_QObject_To_CAction;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_CAction);
		}

		// Token: 0x0600047D RID: 1149 RVA: 0x0000C75C File Offset: 0x0000A95C
		internal static CAction Create(QObject parent, Option action)
		{
			method cactio_Create = CAction.__N.CActio_Create;
			return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (action == null) ? 0U : InteropSystem.GetAddress<Option>(action, true), cactio_Create);
		}

		// Token: 0x0600047E RID: 1150 RVA: 0x0000C790 File Offset: 0x0000A990
		internal readonly void setText(string text)
		{
			this.NullCheck("setText");
			method cactio_setText = CAction.__N.CActio_setText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), cactio_setText);
		}

		// Token: 0x0600047F RID: 1151 RVA: 0x0000C7C0 File Offset: 0x0000A9C0
		internal readonly string text()
		{
			this.NullCheck("text");
			method cactio_text = CAction.__N.CActio_text;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cactio_text));
		}

		// Token: 0x06000480 RID: 1152 RVA: 0x0000C7F0 File Offset: 0x0000A9F0
		internal readonly void setIcon(string icon)
		{
			this.NullCheck("setIcon");
			method cactio_setIcon = CAction.__N.CActio_setIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), cactio_setIcon);
		}

		// Token: 0x06000481 RID: 1153 RVA: 0x0000C820 File Offset: 0x0000AA20
		internal readonly void setToolTip(string tip)
		{
			this.NullCheck("setToolTip");
			method cactio_setToolTip = CAction.__N.CActio_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(tip), cactio_setToolTip);
		}

		// Token: 0x06000482 RID: 1154 RVA: 0x0000C850 File Offset: 0x0000AA50
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method cactio_toolTip = CAction.__N.CActio_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cactio_toolTip));
		}

		// Token: 0x06000483 RID: 1155 RVA: 0x0000C880 File Offset: 0x0000AA80
		internal readonly void setStatusTip(string statusTip)
		{
			this.NullCheck("setStatusTip");
			method cactio_setStatusTip = CAction.__N.CActio_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(statusTip), cactio_setStatusTip);
		}

		// Token: 0x06000484 RID: 1156 RVA: 0x0000C8B0 File Offset: 0x0000AAB0
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method cactio_statusTip = CAction.__N.CActio_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cactio_statusTip));
		}

		// Token: 0x06000485 RID: 1157 RVA: 0x0000C8E0 File Offset: 0x0000AAE0
		internal readonly void setSeparator(bool b)
		{
			this.NullCheck("setSeparator");
			method cactio_setSeparator = CAction.__N.CActio_setSeparator;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, cactio_setSeparator);
		}

		// Token: 0x06000486 RID: 1158 RVA: 0x0000C914 File Offset: 0x0000AB14
		internal readonly bool isSeparator()
		{
			this.NullCheck("isSeparator");
			method cactio_isSeparator = CAction.__N.CActio_isSeparator;
			return calli(System.Int32(System.IntPtr), this.self, cactio_isSeparator) > 0;
		}

		// Token: 0x06000487 RID: 1159 RVA: 0x0000C944 File Offset: 0x0000AB44
		internal readonly void setCheckable(bool B)
		{
			this.NullCheck("setCheckable");
			method cactio_setCheckable = CAction.__N.CActio_setCheckable;
			calli(System.Void(System.IntPtr,System.Int32), this.self, B ? 1 : 0, cactio_setCheckable);
		}

		// Token: 0x06000488 RID: 1160 RVA: 0x0000C978 File Offset: 0x0000AB78
		internal readonly bool isCheckable()
		{
			this.NullCheck("isCheckable");
			method cactio_isCheckable = CAction.__N.CActio_isCheckable;
			return calli(System.Int32(System.IntPtr), this.self, cactio_isCheckable) > 0;
		}

		// Token: 0x06000489 RID: 1161 RVA: 0x0000C9A8 File Offset: 0x0000ABA8
		internal readonly bool isChecked()
		{
			this.NullCheck("isChecked");
			method cactio_isChecked = CAction.__N.CActio_isChecked;
			return calli(System.Int32(System.IntPtr), this.self, cactio_isChecked) > 0;
		}

		// Token: 0x0600048A RID: 1162 RVA: 0x0000C9D8 File Offset: 0x0000ABD8
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method cactio_isEnabled = CAction.__N.CActio_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cactio_isEnabled) > 0;
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0000CA08 File Offset: 0x0000AC08
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method cactio_isVisible = CAction.__N.CActio_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, cactio_isVisible) > 0;
		}

		// Token: 0x0600048C RID: 1164 RVA: 0x0000CA38 File Offset: 0x0000AC38
		internal readonly void setChecked(bool b)
		{
			this.NullCheck("setChecked");
			method cactio_setChecked = CAction.__N.CActio_setChecked;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, cactio_setChecked);
		}

		// Token: 0x0600048D RID: 1165 RVA: 0x0000CA6C File Offset: 0x0000AC6C
		internal readonly void setEnabled(bool b)
		{
			this.NullCheck("setEnabled");
			method cactio_setEnabled = CAction.__N.CActio_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, cactio_setEnabled);
		}

		// Token: 0x0600048E RID: 1166 RVA: 0x0000CAA0 File Offset: 0x0000ACA0
		internal readonly void setIconVisibleInMenu(bool visible)
		{
			this.NullCheck("setIconVisibleInMenu");
			method cactio_setIconVisibleInMenu = CAction.__N.CActio_setIconVisibleInMenu;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, cactio_setIconVisibleInMenu);
		}

		// Token: 0x0600048F RID: 1167 RVA: 0x0000CAD4 File Offset: 0x0000ACD4
		internal readonly bool isIconVisibleInMenu()
		{
			this.NullCheck("isIconVisibleInMenu");
			method cactio_isIconVisibleInMenu = CAction.__N.CActio_isIconVisibleInMenu;
			return calli(System.Int32(System.IntPtr), this.self, cactio_isIconVisibleInMenu) > 0;
		}

		// Token: 0x06000490 RID: 1168 RVA: 0x0000CB04 File Offset: 0x0000AD04
		internal readonly void setShortcutVisibleInContextMenu(bool show)
		{
			this.NullCheck("setShortcutVisibleInContextMenu");
			method cactio_setShortcutVisibleInContextMenu = CAction.__N.CActio_setShortcutVisibleInContextMenu;
			calli(System.Void(System.IntPtr,System.Int32), this.self, show ? 1 : 0, cactio_setShortcutVisibleInContextMenu);
		}

		// Token: 0x06000491 RID: 1169 RVA: 0x0000CB38 File Offset: 0x0000AD38
		internal readonly bool isShortcutVisibleInContextMenu()
		{
			this.NullCheck("isShortcutVisibleInContextMenu");
			method cactio_isShortcutVisibleInContextMenu = CAction.__N.CActio_isShortcutVisibleInContextMenu;
			return calli(System.Int32(System.IntPtr), this.self, cactio_isShortcutVisibleInContextMenu) > 0;
		}

		// Token: 0x06000492 RID: 1170 RVA: 0x0000CB68 File Offset: 0x0000AD68
		internal readonly void trigger()
		{
			this.NullCheck("trigger");
			method cactio_trigger = CAction.__N.CActio_trigger;
			calli(System.Void(System.IntPtr), this.self, cactio_trigger);
		}

		// Token: 0x06000493 RID: 1171 RVA: 0x0000CB94 File Offset: 0x0000AD94
		internal readonly void setMenu(QMenu menu)
		{
			this.NullCheck("setMenu");
			method cactio_setMenu = CAction.__N.CActio_setMenu;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, menu, cactio_setMenu);
		}

		// Token: 0x06000494 RID: 1172 RVA: 0x0000CBC4 File Offset: 0x0000ADC4
		internal readonly void setShortcut(string str)
		{
			this.NullCheck("setShortcut");
			method cactio_setShortcut = CAction.__N.CActio_setShortcut;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), cactio_setShortcut);
		}

		// Token: 0x06000495 RID: 1173 RVA: 0x0000CBF4 File Offset: 0x0000ADF4
		internal readonly void deleteLater()
		{
			this.NullCheck("deleteLater");
			method cactio_deleteLater = CAction.__N.CActio_deleteLater;
			calli(System.Void(System.IntPtr), this.self, cactio_deleteLater);
		}

		// Token: 0x06000496 RID: 1174 RVA: 0x0000CC20 File Offset: 0x0000AE20
		internal readonly string objectName()
		{
			this.NullCheck("objectName");
			method cactio_objectName = CAction.__N.CActio_objectName;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, cactio_objectName));
		}

		// Token: 0x06000497 RID: 1175 RVA: 0x0000CC50 File Offset: 0x0000AE50
		internal readonly void setObjectName(string name)
		{
			this.NullCheck("setObjectName");
			method cactio_setObjectName = CAction.__N.CActio_setObjectName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), cactio_setObjectName);
		}

		// Token: 0x06000498 RID: 1176 RVA: 0x0000CC80 File Offset: 0x0000AE80
		internal readonly void setProperty(string key, bool value)
		{
			this.NullCheck("setProperty");
			method cactio_setProperty = CAction.__N.CActio_setProperty;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, cactio_setProperty);
		}

		// Token: 0x06000499 RID: 1177 RVA: 0x0000CCB8 File Offset: 0x0000AEB8
		internal readonly void setProperty(string key, float value)
		{
			this.NullCheck("setProperty");
			method cactio_f = CAction.__N.CActio_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, cactio_f);
		}

		// Token: 0x0600049A RID: 1178 RVA: 0x0000CCEC File Offset: 0x0000AEEC
		internal readonly void setProperty(string key, string value)
		{
			this.NullCheck("setProperty");
			method cactio_f = CAction.__N.CActio_f3;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), cactio_f);
		}

		// Token: 0x04000043 RID: 67
		internal IntPtr self;

		// Token: 0x02000103 RID: 259
		internal static class __N
		{
			// Token: 0x04000793 RID: 1939
			internal static method From_QAction_To_CAction;

			// Token: 0x04000794 RID: 1940
			internal static method To_QAction_From_CAction;

			// Token: 0x04000795 RID: 1941
			internal static method From_QObject_To_CAction;

			// Token: 0x04000796 RID: 1942
			internal static method To_QObject_From_CAction;

			// Token: 0x04000797 RID: 1943
			internal static method CActio_Create;

			// Token: 0x04000798 RID: 1944
			internal static method CActio_setText;

			// Token: 0x04000799 RID: 1945
			internal static method CActio_text;

			// Token: 0x0400079A RID: 1946
			internal static method CActio_setIcon;

			// Token: 0x0400079B RID: 1947
			internal static method CActio_setToolTip;

			// Token: 0x0400079C RID: 1948
			internal static method CActio_toolTip;

			// Token: 0x0400079D RID: 1949
			internal static method CActio_setStatusTip;

			// Token: 0x0400079E RID: 1950
			internal static method CActio_statusTip;

			// Token: 0x0400079F RID: 1951
			internal static method CActio_setSeparator;

			// Token: 0x040007A0 RID: 1952
			internal static method CActio_isSeparator;

			// Token: 0x040007A1 RID: 1953
			internal static method CActio_setCheckable;

			// Token: 0x040007A2 RID: 1954
			internal static method CActio_isCheckable;

			// Token: 0x040007A3 RID: 1955
			internal static method CActio_isChecked;

			// Token: 0x040007A4 RID: 1956
			internal static method CActio_isEnabled;

			// Token: 0x040007A5 RID: 1957
			internal static method CActio_isVisible;

			// Token: 0x040007A6 RID: 1958
			internal static method CActio_setChecked;

			// Token: 0x040007A7 RID: 1959
			internal static method CActio_setEnabled;

			// Token: 0x040007A8 RID: 1960
			internal static method CActio_setIconVisibleInMenu;

			// Token: 0x040007A9 RID: 1961
			internal static method CActio_isIconVisibleInMenu;

			// Token: 0x040007AA RID: 1962
			internal static method CActio_setShortcutVisibleInContextMenu;

			// Token: 0x040007AB RID: 1963
			internal static method CActio_isShortcutVisibleInContextMenu;

			// Token: 0x040007AC RID: 1964
			internal static method CActio_trigger;

			// Token: 0x040007AD RID: 1965
			internal static method CActio_setMenu;

			// Token: 0x040007AE RID: 1966
			internal static method CActio_setShortcut;

			// Token: 0x040007AF RID: 1967
			internal static method CActio_deleteLater;

			// Token: 0x040007B0 RID: 1968
			internal static method CActio_objectName;

			// Token: 0x040007B1 RID: 1969
			internal static method CActio_setObjectName;

			// Token: 0x040007B2 RID: 1970
			internal static method CActio_setProperty;

			// Token: 0x040007B3 RID: 1971
			internal static method CActio_f2;

			// Token: 0x040007B4 RID: 1972
			internal static method CActio_f3;
		}
	}
}
