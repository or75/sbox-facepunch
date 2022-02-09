using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000018 RID: 24
internal struct CSystemTrayIcon
{
	// Token: 0x06000156 RID: 342 RVA: 0x00005215 File Offset: 0x00003415
	public static implicit operator IntPtr(CSystemTrayIcon value)
	{
		return value.self;
	}

	// Token: 0x06000157 RID: 343 RVA: 0x00005220 File Offset: 0x00003420
	public static implicit operator CSystemTrayIcon(IntPtr value)
	{
		return new CSystemTrayIcon
		{
			self = value
		};
	}

	// Token: 0x06000158 RID: 344 RVA: 0x0000523E File Offset: 0x0000343E
	public static bool operator ==(CSystemTrayIcon c1, CSystemTrayIcon c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00005251 File Offset: 0x00003451
	public static bool operator !=(CSystemTrayIcon c1, CSystemTrayIcon c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x0600015A RID: 346 RVA: 0x00005264 File Offset: 0x00003464
	public override bool Equals(object obj)
	{
		if (obj is CSystemTrayIcon)
		{
			CSystemTrayIcon c = (CSystemTrayIcon)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x0600015B RID: 347 RVA: 0x0000528E File Offset: 0x0000348E
	internal CSystemTrayIcon(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x0600015C RID: 348 RVA: 0x00005298 File Offset: 0x00003498
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CSystemTrayIcon ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x0600015D RID: 349 RVA: 0x000052D4 File Offset: 0x000034D4
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x0600015E RID: 350 RVA: 0x000052E6 File Offset: 0x000034E6
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x0600015F RID: 351 RVA: 0x000052F1 File Offset: 0x000034F1
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00005304 File Offset: 0x00003504
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CSystemTrayIcon was null when calling " + n);
		}
	}

	// Token: 0x06000161 RID: 353 RVA: 0x0000531F File Offset: 0x0000351F
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x06000162 RID: 354 RVA: 0x0000532C File Offset: 0x0000352C
	public static implicit operator Native.QObject(CSystemTrayIcon value)
	{
		method to_QObject_From_CSystemTrayIcon = CSystemTrayIcon.__N.To_QObject_From_CSystemTrayIcon;
		return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_CSystemTrayIcon);
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00005350 File Offset: 0x00003550
	public static explicit operator CSystemTrayIcon(Native.QObject value)
	{
		method from_QObject_To_CSystemTrayIcon = CSystemTrayIcon.__N.From_QObject_To_CSystemTrayIcon;
		return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_CSystemTrayIcon);
	}

	// Token: 0x06000164 RID: 356 RVA: 0x00005374 File Offset: 0x00003574
	internal static CSystemTrayIcon Create(Native.QObject parent, TrayIcon managedObject)
	{
		method csyste_Create = CSystemTrayIcon.__N.CSyste_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedObject == null) ? 0U : InteropSystem.GetAddress<TrayIcon>(managedObject, true), csyste_Create);
	}

	// Token: 0x06000165 RID: 357 RVA: 0x000053A8 File Offset: 0x000035A8
	internal readonly void setIcon(string icon)
	{
		this.NullCheck("setIcon");
		method csyste_setIcon = CSystemTrayIcon.__N.CSyste_setIcon;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), csyste_setIcon);
	}

	// Token: 0x06000166 RID: 358 RVA: 0x000053D8 File Offset: 0x000035D8
	internal readonly void setToolTip(string tip)
	{
		this.NullCheck("setToolTip");
		method csyste_setToolTip = CSystemTrayIcon.__N.CSyste_setToolTip;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(tip), csyste_setToolTip);
	}

	// Token: 0x06000167 RID: 359 RVA: 0x00005408 File Offset: 0x00003608
	internal readonly bool isVisible()
	{
		this.NullCheck("isVisible");
		method csyste_isVisible = CSystemTrayIcon.__N.CSyste_isVisible;
		return calli(System.Int32(System.IntPtr), this.self, csyste_isVisible) > 0;
	}

	// Token: 0x06000168 RID: 360 RVA: 0x00005438 File Offset: 0x00003638
	internal readonly void showMessage(string title, string msg, string icon, int msecs)
	{
		this.NullCheck("showMessage");
		method csyste_showMessage = CSystemTrayIcon.__N.CSyste_showMessage;
		calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetWPointer(title), Interop.GetWPointer(msg), Interop.GetPointer(icon), msecs, csyste_showMessage);
	}

	// Token: 0x06000169 RID: 361 RVA: 0x00005478 File Offset: 0x00003678
	internal readonly void show()
	{
		this.NullCheck("show");
		method csyste_show = CSystemTrayIcon.__N.CSyste_show;
		calli(System.Void(System.IntPtr), this.self, csyste_show);
	}

	// Token: 0x0600016A RID: 362 RVA: 0x000054A4 File Offset: 0x000036A4
	internal readonly void hide()
	{
		this.NullCheck("hide");
		method csyste_hide = CSystemTrayIcon.__N.CSyste_hide;
		calli(System.Void(System.IntPtr), this.self, csyste_hide);
	}

	// Token: 0x0600016B RID: 363 RVA: 0x000054D0 File Offset: 0x000036D0
	internal readonly void setContextMenu(QMenu menu)
	{
		this.NullCheck("setContextMenu");
		method csyste_setContextMenu = CSystemTrayIcon.__N.CSyste_setContextMenu;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, menu, csyste_setContextMenu);
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00005500 File Offset: 0x00003700
	internal readonly void deleteLater()
	{
		this.NullCheck("deleteLater");
		method csyste_deleteLater = CSystemTrayIcon.__N.CSyste_deleteLater;
		calli(System.Void(System.IntPtr), this.self, csyste_deleteLater);
	}

	// Token: 0x0600016D RID: 365 RVA: 0x0000552C File Offset: 0x0000372C
	internal readonly string objectName()
	{
		this.NullCheck("objectName");
		method csyste_objectName = CSystemTrayIcon.__N.CSyste_objectName;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, csyste_objectName));
	}

	// Token: 0x0600016E RID: 366 RVA: 0x0000555C File Offset: 0x0000375C
	internal readonly void setObjectName(string name)
	{
		this.NullCheck("setObjectName");
		method csyste_setObjectName = CSystemTrayIcon.__N.CSyste_setObjectName;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), csyste_setObjectName);
	}

	// Token: 0x0600016F RID: 367 RVA: 0x0000558C File Offset: 0x0000378C
	internal readonly void setProperty(string key, bool value)
	{
		this.NullCheck("setProperty");
		method csyste_setProperty = CSystemTrayIcon.__N.CSyste_setProperty;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, csyste_setProperty);
	}

	// Token: 0x06000170 RID: 368 RVA: 0x000055C4 File Offset: 0x000037C4
	internal readonly void setProperty(string key, float value)
	{
		this.NullCheck("setProperty");
		method csyste_f = CSystemTrayIcon.__N.CSyste_f2;
		calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, csyste_f);
	}

	// Token: 0x06000171 RID: 369 RVA: 0x000055F8 File Offset: 0x000037F8
	internal readonly void setProperty(string key, string value)
	{
		this.NullCheck("setProperty");
		method csyste_f = CSystemTrayIcon.__N.CSyste_f3;
		calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), csyste_f);
	}

	// Token: 0x04000014 RID: 20
	internal IntPtr self;

	// Token: 0x020000E8 RID: 232
	internal static class __N
	{
		// Token: 0x04000598 RID: 1432
		internal static method From_QObject_To_CSystemTrayIcon;

		// Token: 0x04000599 RID: 1433
		internal static method To_QObject_From_CSystemTrayIcon;

		// Token: 0x0400059A RID: 1434
		internal static method CSyste_Create;

		// Token: 0x0400059B RID: 1435
		internal static method CSyste_setIcon;

		// Token: 0x0400059C RID: 1436
		internal static method CSyste_setToolTip;

		// Token: 0x0400059D RID: 1437
		internal static method CSyste_isVisible;

		// Token: 0x0400059E RID: 1438
		internal static method CSyste_showMessage;

		// Token: 0x0400059F RID: 1439
		internal static method CSyste_show;

		// Token: 0x040005A0 RID: 1440
		internal static method CSyste_hide;

		// Token: 0x040005A1 RID: 1441
		internal static method CSyste_setContextMenu;

		// Token: 0x040005A2 RID: 1442
		internal static method CSyste_deleteLater;

		// Token: 0x040005A3 RID: 1443
		internal static method CSyste_objectName;

		// Token: 0x040005A4 RID: 1444
		internal static method CSyste_setObjectName;

		// Token: 0x040005A5 RID: 1445
		internal static method CSyste_setProperty;

		// Token: 0x040005A6 RID: 1446
		internal static method CSyste_f2;

		// Token: 0x040005A7 RID: 1447
		internal static method CSyste_f3;
	}
}
