using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000039 RID: 57
	internal struct CManagedGraphicsItem
	{
		// Token: 0x06000514 RID: 1300 RVA: 0x0000E20D File Offset: 0x0000C40D
		public static implicit operator IntPtr(CManagedGraphicsItem value)
		{
			return value.self;
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x0000E218 File Offset: 0x0000C418
		public static implicit operator CManagedGraphicsItem(IntPtr value)
		{
			return new CManagedGraphicsItem
			{
				self = value
			};
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0000E236 File Offset: 0x0000C436
		public static bool operator ==(CManagedGraphicsItem c1, CManagedGraphicsItem c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0000E249 File Offset: 0x0000C449
		public static bool operator !=(CManagedGraphicsItem c1, CManagedGraphicsItem c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0000E25C File Offset: 0x0000C45C
		public override bool Equals(object obj)
		{
			if (obj is CManagedGraphicsItem)
			{
				CManagedGraphicsItem c = (CManagedGraphicsItem)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x0000E286 File Offset: 0x0000C486
		internal CManagedGraphicsItem(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x0000E290 File Offset: 0x0000C490
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CManagedGraphicsItem ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x0000E2CC File Offset: 0x0000C4CC
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x0600051C RID: 1308 RVA: 0x0000E2DE File Offset: 0x0000C4DE
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0000E2E9 File Offset: 0x0000C4E9
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x0000E2FC File Offset: 0x0000C4FC
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CManagedGraphicsItem was null when calling " + n);
			}
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x0000E317 File Offset: 0x0000C517
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0000E324 File Offset: 0x0000C524
		public static implicit operator QGraphicsItem(CManagedGraphicsItem value)
		{
			method to_QGraphicsItem_From_CManagedGraphicsItem = CManagedGraphicsItem.__N.To_QGraphicsItem_From_CManagedGraphicsItem;
			return calli(System.IntPtr(System.IntPtr), value, to_QGraphicsItem_From_CManagedGraphicsItem);
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x0000E348 File Offset: 0x0000C548
		public static explicit operator CManagedGraphicsItem(QGraphicsItem value)
		{
			method from_QGraphicsItem_To_CManagedGraphicsItem = CManagedGraphicsItem.__N.From_QGraphicsItem_To_CManagedGraphicsItem;
			return calli(System.IntPtr(System.IntPtr), value, from_QGraphicsItem_To_CManagedGraphicsItem);
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x0000E36C File Offset: 0x0000C56C
		internal static CManagedGraphicsItem Create(QGraphicsItem parent, GraphicsItem managedObject)
		{
			method cmnged_Create = CManagedGraphicsItem.__N.CMnged_Create;
			return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (managedObject == null) ? 0U : InteropSystem.GetAddress<GraphicsItem>(managedObject, true), cmnged_Create);
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x0000E3A0 File Offset: 0x0000C5A0
		internal readonly void DeleteThis()
		{
			this.NullCheck("DeleteThis");
			method cmnged_DeleteThis = CManagedGraphicsItem.__N.CMnged_DeleteThis;
			calli(System.Void(System.IntPtr), this.self, cmnged_DeleteThis);
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x0000E3CC File Offset: 0x0000C5CC
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method cmnged_isVisible = CManagedGraphicsItem.__N.CMnged_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isVisible) > 0;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x0000E3FC File Offset: 0x0000C5FC
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method cmnged_setVisible = CManagedGraphicsItem.__N.CMnged_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, cmnged_setVisible);
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x0000E430 File Offset: 0x0000C630
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method cmnged_isEnabled = CManagedGraphicsItem.__N.CMnged_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isEnabled) > 0;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x0000E460 File Offset: 0x0000C660
		internal readonly void setEnabled(bool enabled)
		{
			this.NullCheck("setEnabled");
			method cmnged_setEnabled = CManagedGraphicsItem.__N.CMnged_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cmnged_setEnabled);
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x0000E494 File Offset: 0x0000C694
		internal readonly bool isSelected()
		{
			this.NullCheck("isSelected");
			method cmnged_isSelected = CManagedGraphicsItem.__N.CMnged_isSelected;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_isSelected) > 0;
		}

		// Token: 0x06000529 RID: 1321 RVA: 0x0000E4C4 File Offset: 0x0000C6C4
		internal readonly void setSelected(bool selected)
		{
			this.NullCheck("setSelected");
			method cmnged_setSelected = CManagedGraphicsItem.__N.CMnged_setSelected;
			calli(System.Void(System.IntPtr,System.Int32), this.self, selected ? 1 : 0, cmnged_setSelected);
		}

		// Token: 0x0600052A RID: 1322 RVA: 0x0000E4F8 File Offset: 0x0000C6F8
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method cmnged_acceptDrops = CManagedGraphicsItem.__N.CMnged_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_acceptDrops) > 0;
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x0000E528 File Offset: 0x0000C728
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method cmnged_setAcceptDrops = CManagedGraphicsItem.__N.CMnged_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, cmnged_setAcceptDrops);
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x0000E55C File Offset: 0x0000C75C
		internal readonly float opacity()
		{
			this.NullCheck("opacity");
			method cmnged_opacity = CManagedGraphicsItem.__N.CMnged_opacity;
			return calli(System.Single(System.IntPtr), this.self, cmnged_opacity);
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x0000E588 File Offset: 0x0000C788
		internal readonly float effectiveOpacity()
		{
			this.NullCheck("effectiveOpacity");
			method cmnged_effectiveOpacity = CManagedGraphicsItem.__N.CMnged_effectiveOpacity;
			return calli(System.Single(System.IntPtr), this.self, cmnged_effectiveOpacity);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x0000E5B4 File Offset: 0x0000C7B4
		internal readonly void setOpacity(float opacity)
		{
			this.NullCheck("setOpacity");
			method cmnged_setOpacity = CManagedGraphicsItem.__N.CMnged_setOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, opacity, cmnged_setOpacity);
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x0000E5E0 File Offset: 0x0000C7E0
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method cmnged_pos = CManagedGraphicsItem.__N.CMnged_pos;
			return calli(Vector3(System.IntPtr), this.self, cmnged_pos);
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x0000E60C File Offset: 0x0000C80C
		internal readonly void setPos(Vector3 pos)
		{
			this.NullCheck("setPos");
			method cmnged_setPos = CManagedGraphicsItem.__N.CMnged_setPos;
			calli(System.Void(System.IntPtr,Vector3), this.self, pos, cmnged_setPos);
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0000E638 File Offset: 0x0000C838
		internal readonly void setRotation(float angle)
		{
			this.NullCheck("setRotation");
			method cmnged_setRotation = CManagedGraphicsItem.__N.CMnged_setRotation;
			calli(System.Void(System.IntPtr,System.Single), this.self, angle, cmnged_setRotation);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x0000E664 File Offset: 0x0000C864
		internal readonly float rotation()
		{
			this.NullCheck("rotation");
			method cmnged_rotation = CManagedGraphicsItem.__N.CMnged_rotation;
			return calli(System.Single(System.IntPtr), this.self, cmnged_rotation);
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x0000E690 File Offset: 0x0000C890
		internal readonly void setScale(float scale)
		{
			this.NullCheck("setScale");
			method cmnged_setScale = CManagedGraphicsItem.__N.CMnged_setScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, scale, cmnged_setScale);
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x0000E6BC File Offset: 0x0000C8BC
		internal readonly float scale()
		{
			this.NullCheck("scale");
			method cmnged_scale = CManagedGraphicsItem.__N.CMnged_scale;
			return calli(System.Single(System.IntPtr), this.self, cmnged_scale);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x0000E6E8 File Offset: 0x0000C8E8
		internal readonly float zValue()
		{
			this.NullCheck("zValue");
			method cmnged_zValue = CManagedGraphicsItem.__N.CMnged_zValue;
			return calli(System.Single(System.IntPtr), this.self, cmnged_zValue);
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0000E714 File Offset: 0x0000C914
		internal readonly void setZValue(float z)
		{
			this.NullCheck("setZValue");
			method cmnged_setZValue = CManagedGraphicsItem.__N.CMnged_setZValue;
			calli(System.Void(System.IntPtr,System.Single), this.self, z, cmnged_setZValue);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x0000E740 File Offset: 0x0000C940
		internal readonly GraphicsItemFlag flags()
		{
			this.NullCheck("flags");
			method cmnged_flags = CManagedGraphicsItem.__N.CMnged_flags;
			return calli(System.Int64(System.IntPtr), this.self, cmnged_flags);
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x0000E76C File Offset: 0x0000C96C
		internal readonly void setFlag(GraphicsItemFlag flag, bool enabled)
		{
			this.NullCheck("setFlag");
			method cmnged_setFlag = CManagedGraphicsItem.__N.CMnged_setFlag;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)flag, enabled ? 1 : 0, cmnged_setFlag);
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0000E7A0 File Offset: 0x0000C9A0
		internal readonly void stackBefore(QGraphicsItem sibling)
		{
			this.NullCheck("stackBefore");
			method cmnged_stackBefore = CManagedGraphicsItem.__N.CMnged_stackBefore;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, sibling, cmnged_stackBefore);
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x0000E7D0 File Offset: 0x0000C9D0
		internal readonly void setParentItem(QGraphicsItem parent)
		{
			this.NullCheck("setParentItem");
			method cmnged_setParentItem = CManagedGraphicsItem.__N.CMnged_setParentItem;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, cmnged_setParentItem);
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x0000E800 File Offset: 0x0000CA00
		internal readonly void update()
		{
			this.NullCheck("update");
			method cmnged_update = CManagedGraphicsItem.__N.CMnged_update;
			calli(System.Void(System.IntPtr), this.self, cmnged_update);
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x0000E82C File Offset: 0x0000CA2C
		internal readonly bool acceptHoverEvents()
		{
			this.NullCheck("acceptHoverEvents");
			method cmnged_acceptHoverEvents = CManagedGraphicsItem.__N.CMnged_acceptHoverEvents;
			return calli(System.Int32(System.IntPtr), this.self, cmnged_acceptHoverEvents) > 0;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x0000E85C File Offset: 0x0000CA5C
		internal readonly void setAcceptHoverEvents(bool enabled)
		{
			this.NullCheck("setAcceptHoverEvents");
			method cmnged_setAcceptHoverEvents = CManagedGraphicsItem.__N.CMnged_setAcceptHoverEvents;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, cmnged_setAcceptHoverEvents);
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x0000E890 File Offset: 0x0000CA90
		internal readonly Vector3 mapToItem(QGraphicsItem item, Vector3 point)
		{
			this.NullCheck("mapToItem");
			method cmnged_mapToItem = CManagedGraphicsItem.__N.CMnged_mapToItem;
			return calli(Vector3(System.IntPtr,System.IntPtr,Vector3), this.self, item, point, cmnged_mapToItem);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0000E8C4 File Offset: 0x0000CAC4
		internal readonly Vector3 mapToParent(Vector3 point)
		{
			this.NullCheck("mapToParent");
			method cmnged_mapToParent = CManagedGraphicsItem.__N.CMnged_mapToParent;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, cmnged_mapToParent);
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x0000E8F0 File Offset: 0x0000CAF0
		internal readonly Vector3 mapToScene(Vector3 point)
		{
			this.NullCheck("mapToScene");
			method cmnged_mapToScene = CManagedGraphicsItem.__N.CMnged_mapToScene;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, cmnged_mapToScene);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x0000E91C File Offset: 0x0000CB1C
		internal readonly Vector3 mapFromItem(QGraphicsItem item, Vector3 point)
		{
			this.NullCheck("mapFromItem");
			method cmnged_mapFromItem = CManagedGraphicsItem.__N.CMnged_mapFromItem;
			return calli(Vector3(System.IntPtr,System.IntPtr,Vector3), this.self, item, point, cmnged_mapFromItem);
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x0000E950 File Offset: 0x0000CB50
		internal readonly Vector3 mapFromParent(Vector3 point)
		{
			this.NullCheck("mapFromParent");
			method cmnged_mapFromParent = CManagedGraphicsItem.__N.CMnged_mapFromParent;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, cmnged_mapFromParent);
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x0000E97C File Offset: 0x0000CB7C
		internal readonly Vector3 mapFromScene(Vector3 point)
		{
			this.NullCheck("mapFromScene");
			method cmnged_mapFromScene = CManagedGraphicsItem.__N.CMnged_mapFromScene;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, cmnged_mapFromScene);
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0000E9A8 File Offset: 0x0000CBA8
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method cmnged_setCursor = CManagedGraphicsItem.__N.CMnged_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, cmnged_setCursor);
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x0000E9D4 File Offset: 0x0000CBD4
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method cmnged_unsetCursor = CManagedGraphicsItem.__N.CMnged_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, cmnged_unsetCursor);
		}

		// Token: 0x04000045 RID: 69
		internal IntPtr self;

		// Token: 0x02000105 RID: 261
		internal static class __N
		{
			// Token: 0x04000822 RID: 2082
			internal static method From_QGraphicsItem_To_CManagedGraphicsItem;

			// Token: 0x04000823 RID: 2083
			internal static method To_QGraphicsItem_From_CManagedGraphicsItem;

			// Token: 0x04000824 RID: 2084
			internal static method CMnged_Create;

			// Token: 0x04000825 RID: 2085
			internal static method CMnged_DeleteThis;

			// Token: 0x04000826 RID: 2086
			internal static method CMnged_isVisible;

			// Token: 0x04000827 RID: 2087
			internal static method CMnged_setVisible;

			// Token: 0x04000828 RID: 2088
			internal static method CMnged_isEnabled;

			// Token: 0x04000829 RID: 2089
			internal static method CMnged_setEnabled;

			// Token: 0x0400082A RID: 2090
			internal static method CMnged_isSelected;

			// Token: 0x0400082B RID: 2091
			internal static method CMnged_setSelected;

			// Token: 0x0400082C RID: 2092
			internal static method CMnged_acceptDrops;

			// Token: 0x0400082D RID: 2093
			internal static method CMnged_setAcceptDrops;

			// Token: 0x0400082E RID: 2094
			internal static method CMnged_opacity;

			// Token: 0x0400082F RID: 2095
			internal static method CMnged_effectiveOpacity;

			// Token: 0x04000830 RID: 2096
			internal static method CMnged_setOpacity;

			// Token: 0x04000831 RID: 2097
			internal static method CMnged_pos;

			// Token: 0x04000832 RID: 2098
			internal static method CMnged_setPos;

			// Token: 0x04000833 RID: 2099
			internal static method CMnged_setRotation;

			// Token: 0x04000834 RID: 2100
			internal static method CMnged_rotation;

			// Token: 0x04000835 RID: 2101
			internal static method CMnged_setScale;

			// Token: 0x04000836 RID: 2102
			internal static method CMnged_scale;

			// Token: 0x04000837 RID: 2103
			internal static method CMnged_zValue;

			// Token: 0x04000838 RID: 2104
			internal static method CMnged_setZValue;

			// Token: 0x04000839 RID: 2105
			internal static method CMnged_flags;

			// Token: 0x0400083A RID: 2106
			internal static method CMnged_setFlag;

			// Token: 0x0400083B RID: 2107
			internal static method CMnged_stackBefore;

			// Token: 0x0400083C RID: 2108
			internal static method CMnged_setParentItem;

			// Token: 0x0400083D RID: 2109
			internal static method CMnged_update;

			// Token: 0x0400083E RID: 2110
			internal static method CMnged_acceptHoverEvents;

			// Token: 0x0400083F RID: 2111
			internal static method CMnged_setAcceptHoverEvents;

			// Token: 0x04000840 RID: 2112
			internal static method CMnged_mapToItem;

			// Token: 0x04000841 RID: 2113
			internal static method CMnged_mapToParent;

			// Token: 0x04000842 RID: 2114
			internal static method CMnged_mapToScene;

			// Token: 0x04000843 RID: 2115
			internal static method CMnged_mapFromItem;

			// Token: 0x04000844 RID: 2116
			internal static method CMnged_mapFromParent;

			// Token: 0x04000845 RID: 2117
			internal static method CMnged_mapFromScene;

			// Token: 0x04000846 RID: 2118
			internal static method CMnged_setCursor;

			// Token: 0x04000847 RID: 2119
			internal static method CMnged_unsetCursor;
		}
	}
}
