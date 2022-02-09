using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200003A RID: 58
	internal struct CManagedLineGraphicsItem
	{
		// Token: 0x06000546 RID: 1350 RVA: 0x0000E9FE File Offset: 0x0000CBFE
		public static implicit operator IntPtr(CManagedLineGraphicsItem value)
		{
			return value.self;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x0000EA08 File Offset: 0x0000CC08
		public static implicit operator CManagedLineGraphicsItem(IntPtr value)
		{
			return new CManagedLineGraphicsItem
			{
				self = value
			};
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x0000EA26 File Offset: 0x0000CC26
		public static bool operator ==(CManagedLineGraphicsItem c1, CManagedLineGraphicsItem c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x0000EA39 File Offset: 0x0000CC39
		public static bool operator !=(CManagedLineGraphicsItem c1, CManagedLineGraphicsItem c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x0000EA4C File Offset: 0x0000CC4C
		public override bool Equals(object obj)
		{
			if (obj is CManagedLineGraphicsItem)
			{
				CManagedLineGraphicsItem c = (CManagedLineGraphicsItem)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x0000EA76 File Offset: 0x0000CC76
		internal CManagedLineGraphicsItem(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x0000EA80 File Offset: 0x0000CC80
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CManagedLineGraphicsItem ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x0600054D RID: 1357 RVA: 0x0000EABC File Offset: 0x0000CCBC
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x0000EACE File Offset: 0x0000CCCE
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x0000EAD9 File Offset: 0x0000CCD9
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x0000EAEC File Offset: 0x0000CCEC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CManagedLineGraphicsItem was null when calling " + n);
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x0000EB07 File Offset: 0x0000CD07
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x0000EB14 File Offset: 0x0000CD14
		public static implicit operator CManagedGraphicsItem(CManagedLineGraphicsItem value)
		{
			method to_CManagedGraphicsItem_From_CManagedLineGraphicsItem = CManagedLineGraphicsItem.__N.To_CManagedGraphicsItem_From_CManagedLineGraphicsItem;
			return calli(System.IntPtr(System.IntPtr), value, to_CManagedGraphicsItem_From_CManagedLineGraphicsItem);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x0000EB38 File Offset: 0x0000CD38
		public static explicit operator CManagedLineGraphicsItem(CManagedGraphicsItem value)
		{
			method from_CManagedGraphicsItem_To_CManagedLineGraphicsItem = CManagedLineGraphicsItem.__N.From_CManagedGraphicsItem_To_CManagedLineGraphicsItem;
			return calli(System.IntPtr(System.IntPtr), value, from_CManagedGraphicsItem_To_CManagedLineGraphicsItem);
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x0000EB5C File Offset: 0x0000CD5C
		public static implicit operator QGraphicsItem(CManagedLineGraphicsItem value)
		{
			method to_QGraphicsItem_From_CManagedLineGraphicsItem = CManagedLineGraphicsItem.__N.To_QGraphicsItem_From_CManagedLineGraphicsItem;
			return calli(System.IntPtr(System.IntPtr), value, to_QGraphicsItem_From_CManagedLineGraphicsItem);
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x0000EB80 File Offset: 0x0000CD80
		public static explicit operator CManagedLineGraphicsItem(QGraphicsItem value)
		{
			method from_QGraphicsItem_To_CManagedLineGraphicsItem = CManagedLineGraphicsItem.__N.From_QGraphicsItem_To_CManagedLineGraphicsItem;
			return calli(System.IntPtr(System.IntPtr), value, from_QGraphicsItem_To_CManagedLineGraphicsItem);
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x0000EBA4 File Offset: 0x0000CDA4
		internal static CManagedLineGraphicsItem CreateLine(QGraphicsItem parent, GraphicsItem managedObject)
		{
			method cmnged_CreateLine = CManagedLineGraphicsItem.__N.CMnged_CreateLine;
			return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedObject == null) ? 0U : InteropSystem.GetAddress<GraphicsItem>(managedObject, true), cmnged_CreateLine);
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x0000EBD8 File Offset: 0x0000CDD8
		internal readonly void Clear()
		{
			this.NullCheck("Clear");
			method cmnged_Clear = CManagedLineGraphicsItem.__N.CMnged_Clear;
			calli(System.Void(System.IntPtr), this.self, cmnged_Clear);
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x0000EC04 File Offset: 0x0000CE04
		internal readonly void MoveTo(Vector3 p)
		{
			this.NullCheck("MoveTo");
			method cmnged_MoveTo = CManagedLineGraphicsItem.__N.CMnged_MoveTo;
			calli(System.Void(System.IntPtr,Vector3), this.self, p, cmnged_MoveTo);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x0000EC30 File Offset: 0x0000CE30
		internal readonly void LineTo(Vector3 p)
		{
			this.NullCheck("LineTo");
			method cmnged_LineTo = CManagedLineGraphicsItem.__N.CMnged_LineTo;
			calli(System.Void(System.IntPtr,Vector3), this.self, p, cmnged_LineTo);
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x0000EC5C File Offset: 0x0000CE5C
		internal readonly void CubicTo(Vector3 c1, Vector3 c2, Vector3 p)
		{
			this.NullCheck("CubicTo");
			method cmnged_CubicTo = CManagedLineGraphicsItem.__N.CMnged_CubicTo;
			calli(System.Void(System.IntPtr,Vector3,Vector3,Vector3), this.self, c1, c2, p, cmnged_CubicTo);
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x0000EC8C File Offset: 0x0000CE8C
		internal readonly void paint(QPainter painter)
		{
			this.NullCheck("paint");
			method cmnged_paint = CManagedLineGraphicsItem.__N.CMnged_paint;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, painter, cmnged_paint);
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x0000ECBC File Offset: 0x0000CEBC
		internal readonly void DeleteThis()
		{
			this.NullCheck("DeleteThis");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f2;
			calli(System.Void(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x0000ECE8 File Offset: 0x0000CEE8
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f3;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_f) > 0;
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x0000ED18 File Offset: 0x0000CF18
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f4;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, cmnged_f);
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x0000ED4C File Offset: 0x0000CF4C
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f5;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_f) > 0;
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x0000ED7C File Offset: 0x0000CF7C
		internal readonly void setEnabled(bool enabled)
		{
			this.NullCheck("setEnabled");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f6;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cmnged_f);
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x0000EDB0 File Offset: 0x0000CFB0
		internal readonly bool isSelected()
		{
			this.NullCheck("isSelected");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f7;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_f) > 0;
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x0000EDE0 File Offset: 0x0000CFE0
		internal readonly void setSelected(bool selected)
		{
			this.NullCheck("setSelected");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f8;
			calli(System.Void(System.IntPtr,System.Int32), this.self, selected ? 1 : 0, cmnged_f);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x0000EE14 File Offset: 0x0000D014
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f9;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_f) > 0;
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x0000EE44 File Offset: 0x0000D044
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f10;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, cmnged_f);
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x0000EE78 File Offset: 0x0000D078
		internal readonly float opacity()
		{
			this.NullCheck("opacity");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f11;
			return calli(System.Single(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x0000EEA4 File Offset: 0x0000D0A4
		internal readonly float effectiveOpacity()
		{
			this.NullCheck("effectiveOpacity");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f12;
			return calli(System.Single(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x0000EED0 File Offset: 0x0000D0D0
		internal readonly void setOpacity(float opacity)
		{
			this.NullCheck("setOpacity");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f13;
			calli(System.Void(System.IntPtr,System.Single), this.self, opacity, cmnged_f);
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x0000EEFC File Offset: 0x0000D0FC
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f14;
			return calli(Vector3(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0000EF28 File Offset: 0x0000D128
		internal readonly void setPos(Vector3 pos)
		{
			this.NullCheck("setPos");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f15;
			calli(System.Void(System.IntPtr,Vector3), this.self, pos, cmnged_f);
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x0000EF54 File Offset: 0x0000D154
		internal readonly void setRotation(float angle)
		{
			this.NullCheck("setRotation");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f16;
			calli(System.Void(System.IntPtr,System.Single), this.self, angle, cmnged_f);
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x0000EF80 File Offset: 0x0000D180
		internal readonly float rotation()
		{
			this.NullCheck("rotation");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f17;
			return calli(System.Single(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x0000EFAC File Offset: 0x0000D1AC
		internal readonly void setScale(float scale)
		{
			this.NullCheck("setScale");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f18;
			calli(System.Void(System.IntPtr,System.Single), this.self, scale, cmnged_f);
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x0000EFD8 File Offset: 0x0000D1D8
		internal readonly float scale()
		{
			this.NullCheck("scale");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f19;
			return calli(System.Single(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x0000F004 File Offset: 0x0000D204
		internal readonly float zValue()
		{
			this.NullCheck("zValue");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f20;
			return calli(System.Single(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x0000F030 File Offset: 0x0000D230
		internal readonly void setZValue(float z)
		{
			this.NullCheck("setZValue");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f21;
			calli(System.Void(System.IntPtr,System.Single), this.self, z, cmnged_f);
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0000F05C File Offset: 0x0000D25C
		internal readonly GraphicsItemFlag flags()
		{
			this.NullCheck("flags");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f22;
			return calli(System.Int64(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x0000F088 File Offset: 0x0000D288
		internal readonly void setFlag(GraphicsItemFlag flag, bool enabled)
		{
			this.NullCheck("setFlag");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f23;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)flag, enabled ? 1 : 0, cmnged_f);
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x0000F0BC File Offset: 0x0000D2BC
		internal readonly void stackBefore(QGraphicsItem sibling)
		{
			this.NullCheck("stackBefore");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f24;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, sibling, cmnged_f);
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x0000F0EC File Offset: 0x0000D2EC
		internal readonly void setParentItem(QGraphicsItem parent)
		{
			this.NullCheck("setParentItem");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f25;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, cmnged_f);
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x0000F11C File Offset: 0x0000D31C
		internal readonly void update()
		{
			this.NullCheck("update");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f26;
			calli(System.Void(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x0000F148 File Offset: 0x0000D348
		internal readonly bool acceptHoverEvents()
		{
			this.NullCheck("acceptHoverEvents");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f27;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_f) > 0;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0000F178 File Offset: 0x0000D378
		internal readonly void setAcceptHoverEvents(bool enabled)
		{
			this.NullCheck("setAcceptHoverEvents");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f28;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cmnged_f);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0000F1AC File Offset: 0x0000D3AC
		internal readonly Vector3 mapToItem(QGraphicsItem item, Vector3 point)
		{
			this.NullCheck("mapToItem");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f29;
			return calli(Vector3(System.IntPtr,System.IntPtr,Vector3), this.self, item, point, cmnged_f);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0000F1E0 File Offset: 0x0000D3E0
		internal readonly Vector3 mapToParent(Vector3 point)
		{
			this.NullCheck("mapToParent");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f30;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, cmnged_f);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x0000F20C File Offset: 0x0000D40C
		internal readonly Vector3 mapToScene(Vector3 point)
		{
			this.NullCheck("mapToScene");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f31;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, cmnged_f);
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x0000F238 File Offset: 0x0000D438
		internal readonly Vector3 mapFromItem(QGraphicsItem item, Vector3 point)
		{
			this.NullCheck("mapFromItem");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f32;
			return calli(Vector3(System.IntPtr,System.IntPtr,Vector3), this.self, item, point, cmnged_f);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x0000F26C File Offset: 0x0000D46C
		internal readonly Vector3 mapFromParent(Vector3 point)
		{
			this.NullCheck("mapFromParent");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f33;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, cmnged_f);
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x0000F298 File Offset: 0x0000D498
		internal readonly Vector3 mapFromScene(Vector3 point)
		{
			this.NullCheck("mapFromScene");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f34;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, cmnged_f);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x0000F2C4 File Offset: 0x0000D4C4
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f35;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, cmnged_f);
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x0000F2F0 File Offset: 0x0000D4F0
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method cmnged_f = CManagedLineGraphicsItem.__N.CMnged_f36;
			calli(System.Void(System.IntPtr), this.self, cmnged_f);
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x0600057F RID: 1407 RVA: 0x0000F31A File Offset: 0x0000D51A
		// (set) Token: 0x06000580 RID: 1408 RVA: 0x0000F337 File Offset: 0x0000D537
		internal float HitWidth
		{
			get
			{
				this.NullCheck("HitWidth");
				return CManagedLineGraphicsItem.__N.Get__CMnged_HitWidth(this.self);
			}
			set
			{
				this.NullCheck("HitWidth");
				CManagedLineGraphicsItem.__N.Set__CMnged_HitWidth(this.self, value);
			}
		}

		// Token: 0x04000046 RID: 70
		internal IntPtr self;

		// Token: 0x02000106 RID: 262
		internal static class __N
		{
			// Token: 0x04000848 RID: 2120
			internal static method From_CManagedGraphicsItem_To_CManagedLineGraphicsItem;

			// Token: 0x04000849 RID: 2121
			internal static method To_CManagedGraphicsItem_From_CManagedLineGraphicsItem;

			// Token: 0x0400084A RID: 2122
			internal static method From_QGraphicsItem_To_CManagedLineGraphicsItem;

			// Token: 0x0400084B RID: 2123
			internal static method To_QGraphicsItem_From_CManagedLineGraphicsItem;

			// Token: 0x0400084C RID: 2124
			internal static method CMnged_CreateLine;

			// Token: 0x0400084D RID: 2125
			internal static method CMnged_Clear;

			// Token: 0x0400084E RID: 2126
			internal static method CMnged_MoveTo;

			// Token: 0x0400084F RID: 2127
			internal static method CMnged_LineTo;

			// Token: 0x04000850 RID: 2128
			internal static method CMnged_CubicTo;

			// Token: 0x04000851 RID: 2129
			internal static method CMnged_paint;

			// Token: 0x04000852 RID: 2130
			internal static method CMnged_f2;

			// Token: 0x04000853 RID: 2131
			internal static method CMnged_f3;

			// Token: 0x04000854 RID: 2132
			internal static method CMnged_f4;

			// Token: 0x04000855 RID: 2133
			internal static method CMnged_f5;

			// Token: 0x04000856 RID: 2134
			internal static method CMnged_f6;

			// Token: 0x04000857 RID: 2135
			internal static method CMnged_f7;

			// Token: 0x04000858 RID: 2136
			internal static method CMnged_f8;

			// Token: 0x04000859 RID: 2137
			internal static method CMnged_f9;

			// Token: 0x0400085A RID: 2138
			internal static method CMnged_f10;

			// Token: 0x0400085B RID: 2139
			internal static method CMnged_f11;

			// Token: 0x0400085C RID: 2140
			internal static method CMnged_f12;

			// Token: 0x0400085D RID: 2141
			internal static method CMnged_f13;

			// Token: 0x0400085E RID: 2142
			internal static method CMnged_f14;

			// Token: 0x0400085F RID: 2143
			internal static method CMnged_f15;

			// Token: 0x04000860 RID: 2144
			internal static method CMnged_f16;

			// Token: 0x04000861 RID: 2145
			internal static method CMnged_f17;

			// Token: 0x04000862 RID: 2146
			internal static method CMnged_f18;

			// Token: 0x04000863 RID: 2147
			internal static method CMnged_f19;

			// Token: 0x04000864 RID: 2148
			internal static method CMnged_f20;

			// Token: 0x04000865 RID: 2149
			internal static method CMnged_f21;

			// Token: 0x04000866 RID: 2150
			internal static method CMnged_f22;

			// Token: 0x04000867 RID: 2151
			internal static method CMnged_f23;

			// Token: 0x04000868 RID: 2152
			internal static method CMnged_f24;

			// Token: 0x04000869 RID: 2153
			internal static method CMnged_f25;

			// Token: 0x0400086A RID: 2154
			internal static method CMnged_f26;

			// Token: 0x0400086B RID: 2155
			internal static method CMnged_f27;

			// Token: 0x0400086C RID: 2156
			internal static method CMnged_f28;

			// Token: 0x0400086D RID: 2157
			internal static method CMnged_f29;

			// Token: 0x0400086E RID: 2158
			internal static method CMnged_f30;

			// Token: 0x0400086F RID: 2159
			internal static method CMnged_f31;

			// Token: 0x04000870 RID: 2160
			internal static method CMnged_f32;

			// Token: 0x04000871 RID: 2161
			internal static method CMnged_f33;

			// Token: 0x04000872 RID: 2162
			internal static method CMnged_f34;

			// Token: 0x04000873 RID: 2163
			internal static method CMnged_f35;

			// Token: 0x04000874 RID: 2164
			internal static method CMnged_f36;

			// Token: 0x04000875 RID: 2165
			internal static CManagedLineGraphicsItem.__N._Get__CMnged_HitWidth Get__CMnged_HitWidth;

			// Token: 0x04000876 RID: 2166
			internal static CManagedLineGraphicsItem.__N._Set__CMnged_HitWidth Set__CMnged_HitWidth;

			// Token: 0x0200015F RID: 351
			// (Invoke) Token: 0x06001859 RID: 6233
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate float _Get__CMnged_HitWidth(IntPtr self);

			// Token: 0x02000160 RID: 352
			// (Invoke) Token: 0x0600185D RID: 6237
			[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
			internal delegate void _Set__CMnged_HitWidth(IntPtr self, float val);
		}
	}
}
