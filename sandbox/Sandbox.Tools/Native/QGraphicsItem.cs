using System;
using System.Runtime.CompilerServices;
using Tools;

namespace Native
{
	// Token: 0x02000047 RID: 71
	internal struct QGraphicsItem
	{
		// Token: 0x060008C7 RID: 2247 RVA: 0x00017E85 File Offset: 0x00016085
		public static implicit operator IntPtr(QGraphicsItem value)
		{
			return value.self;
		}

		// Token: 0x060008C8 RID: 2248 RVA: 0x00017E90 File Offset: 0x00016090
		public static implicit operator QGraphicsItem(IntPtr value)
		{
			return new QGraphicsItem
			{
				self = value
			};
		}

		// Token: 0x060008C9 RID: 2249 RVA: 0x00017EAE File Offset: 0x000160AE
		public static bool operator ==(QGraphicsItem c1, QGraphicsItem c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x00017EC1 File Offset: 0x000160C1
		public static bool operator !=(QGraphicsItem c1, QGraphicsItem c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x00017ED4 File Offset: 0x000160D4
		public override bool Equals(object obj)
		{
			if (obj is QGraphicsItem)
			{
				QGraphicsItem c = (QGraphicsItem)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060008CC RID: 2252 RVA: 0x00017EFE File Offset: 0x000160FE
		internal QGraphicsItem(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060008CD RID: 2253 RVA: 0x00017F08 File Offset: 0x00016108
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QGraphicsItem ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x00017F44 File Offset: 0x00016144
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060008CF RID: 2255 RVA: 0x00017F56 File Offset: 0x00016156
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00017F61 File Offset: 0x00016161
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x00017F74 File Offset: 0x00016174
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QGraphicsItem was null when calling " + n);
			}
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x00017F8F File Offset: 0x0001618F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x00017F9C File Offset: 0x0001619C
		internal readonly void DeleteThis()
		{
			this.NullCheck("DeleteThis");
			method qgrphc_DeleteThis = QGraphicsItem.__N.QGrphc_DeleteThis;
			calli(System.Void(System.IntPtr), this.self, qgrphc_DeleteThis);
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00017FC8 File Offset: 0x000161C8
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qgrphc_isVisible = QGraphicsItem.__N.QGrphc_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isVisible) > 0;
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00017FF8 File Offset: 0x000161F8
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qgrphc_setVisible = QGraphicsItem.__N.QGrphc_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qgrphc_setVisible);
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x0001802C File Offset: 0x0001622C
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qgrphc_isEnabled = QGraphicsItem.__N.QGrphc_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isEnabled) > 0;
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x0001805C File Offset: 0x0001625C
		internal readonly void setEnabled(bool enabled)
		{
			this.NullCheck("setEnabled");
			method qgrphc_setEnabled = QGraphicsItem.__N.QGrphc_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qgrphc_setEnabled);
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00018090 File Offset: 0x00016290
		internal readonly bool isSelected()
		{
			this.NullCheck("isSelected");
			method qgrphc_isSelected = QGraphicsItem.__N.QGrphc_isSelected;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isSelected) > 0;
		}

		// Token: 0x060008D9 RID: 2265 RVA: 0x000180C0 File Offset: 0x000162C0
		internal readonly void setSelected(bool selected)
		{
			this.NullCheck("setSelected");
			method qgrphc_setSelected = QGraphicsItem.__N.QGrphc_setSelected;
			calli(System.Void(System.IntPtr,System.Int32), this.self, selected ? 1 : 0, qgrphc_setSelected);
		}

		// Token: 0x060008DA RID: 2266 RVA: 0x000180F4 File Offset: 0x000162F4
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qgrphc_acceptDrops = QGraphicsItem.__N.QGrphc_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_acceptDrops) > 0;
		}

		// Token: 0x060008DB RID: 2267 RVA: 0x00018124 File Offset: 0x00016324
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qgrphc_setAcceptDrops = QGraphicsItem.__N.QGrphc_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qgrphc_setAcceptDrops);
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x00018158 File Offset: 0x00016358
		internal readonly float opacity()
		{
			this.NullCheck("opacity");
			method qgrphc_opacity = QGraphicsItem.__N.QGrphc_opacity;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_opacity);
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x00018184 File Offset: 0x00016384
		internal readonly float effectiveOpacity()
		{
			this.NullCheck("effectiveOpacity");
			method qgrphc_effectiveOpacity = QGraphicsItem.__N.QGrphc_effectiveOpacity;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_effectiveOpacity);
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x000181B0 File Offset: 0x000163B0
		internal readonly void setOpacity(float opacity)
		{
			this.NullCheck("setOpacity");
			method qgrphc_setOpacity = QGraphicsItem.__N.QGrphc_setOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, opacity, qgrphc_setOpacity);
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x000181DC File Offset: 0x000163DC
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qgrphc_pos = QGraphicsItem.__N.QGrphc_pos;
			return calli(Vector3(System.IntPtr), this.self, qgrphc_pos);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00018208 File Offset: 0x00016408
		internal readonly void setPos(Vector3 pos)
		{
			this.NullCheck("setPos");
			method qgrphc_setPos = QGraphicsItem.__N.QGrphc_setPos;
			calli(System.Void(System.IntPtr,Vector3), this.self, pos, qgrphc_setPos);
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x00018234 File Offset: 0x00016434
		internal readonly void setRotation(float angle)
		{
			this.NullCheck("setRotation");
			method qgrphc_setRotation = QGraphicsItem.__N.QGrphc_setRotation;
			calli(System.Void(System.IntPtr,System.Single), this.self, angle, qgrphc_setRotation);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00018260 File Offset: 0x00016460
		internal readonly float rotation()
		{
			this.NullCheck("rotation");
			method qgrphc_rotation = QGraphicsItem.__N.QGrphc_rotation;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_rotation);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0001828C File Offset: 0x0001648C
		internal readonly void setScale(float scale)
		{
			this.NullCheck("setScale");
			method qgrphc_setScale = QGraphicsItem.__N.QGrphc_setScale;
			calli(System.Void(System.IntPtr,System.Single), this.self, scale, qgrphc_setScale);
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x000182B8 File Offset: 0x000164B8
		internal readonly float scale()
		{
			this.NullCheck("scale");
			method qgrphc_scale = QGraphicsItem.__N.QGrphc_scale;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_scale);
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x000182E4 File Offset: 0x000164E4
		internal readonly float zValue()
		{
			this.NullCheck("zValue");
			method qgrphc_zValue = QGraphicsItem.__N.QGrphc_zValue;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_zValue);
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00018310 File Offset: 0x00016510
		internal readonly void setZValue(float z)
		{
			this.NullCheck("setZValue");
			method qgrphc_setZValue = QGraphicsItem.__N.QGrphc_setZValue;
			calli(System.Void(System.IntPtr,System.Single), this.self, z, qgrphc_setZValue);
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0001833C File Offset: 0x0001653C
		internal readonly GraphicsItemFlag flags()
		{
			this.NullCheck("flags");
			method qgrphc_flags = QGraphicsItem.__N.QGrphc_flags;
			return calli(System.Int64(System.IntPtr), this.self, qgrphc_flags);
		}

		// Token: 0x060008E8 RID: 2280 RVA: 0x00018368 File Offset: 0x00016568
		internal readonly void setFlag(GraphicsItemFlag flag, bool enabled)
		{
			this.NullCheck("setFlag");
			method qgrphc_setFlag = QGraphicsItem.__N.QGrphc_setFlag;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)flag, enabled ? 1 : 0, qgrphc_setFlag);
		}

		// Token: 0x060008E9 RID: 2281 RVA: 0x0001839C File Offset: 0x0001659C
		internal readonly void stackBefore(QGraphicsItem sibling)
		{
			this.NullCheck("stackBefore");
			method qgrphc_stackBefore = QGraphicsItem.__N.QGrphc_stackBefore;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, sibling, qgrphc_stackBefore);
		}

		// Token: 0x060008EA RID: 2282 RVA: 0x000183CC File Offset: 0x000165CC
		internal readonly void setParentItem(QGraphicsItem parent)
		{
			this.NullCheck("setParentItem");
			method qgrphc_setParentItem = QGraphicsItem.__N.QGrphc_setParentItem;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qgrphc_setParentItem);
		}

		// Token: 0x060008EB RID: 2283 RVA: 0x000183FC File Offset: 0x000165FC
		internal readonly void update()
		{
			this.NullCheck("update");
			method qgrphc_update = QGraphicsItem.__N.QGrphc_update;
			calli(System.Void(System.IntPtr), this.self, qgrphc_update);
		}

		// Token: 0x060008EC RID: 2284 RVA: 0x00018428 File Offset: 0x00016628
		internal readonly bool acceptHoverEvents()
		{
			this.NullCheck("acceptHoverEvents");
			method qgrphc_acceptHoverEvents = QGraphicsItem.__N.QGrphc_acceptHoverEvents;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_acceptHoverEvents) > 0;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00018458 File Offset: 0x00016658
		internal readonly void setAcceptHoverEvents(bool enabled)
		{
			this.NullCheck("setAcceptHoverEvents");
			method qgrphc_setAcceptHoverEvents = QGraphicsItem.__N.QGrphc_setAcceptHoverEvents;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qgrphc_setAcceptHoverEvents);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0001848C File Offset: 0x0001668C
		internal readonly Vector3 mapToItem(QGraphicsItem item, Vector3 point)
		{
			this.NullCheck("mapToItem");
			method qgrphc_mapToItem = QGraphicsItem.__N.QGrphc_mapToItem;
			return calli(Vector3(System.IntPtr,System.IntPtr,Vector3), this.self, item, point, qgrphc_mapToItem);
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x000184C0 File Offset: 0x000166C0
		internal readonly Vector3 mapToParent(Vector3 point)
		{
			this.NullCheck("mapToParent");
			method qgrphc_mapToParent = QGraphicsItem.__N.QGrphc_mapToParent;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_mapToParent);
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x000184EC File Offset: 0x000166EC
		internal readonly Vector3 mapToScene(Vector3 point)
		{
			this.NullCheck("mapToScene");
			method qgrphc_mapToScene = QGraphicsItem.__N.QGrphc_mapToScene;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_mapToScene);
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00018518 File Offset: 0x00016718
		internal readonly Vector3 mapFromItem(QGraphicsItem item, Vector3 point)
		{
			this.NullCheck("mapFromItem");
			method qgrphc_mapFromItem = QGraphicsItem.__N.QGrphc_mapFromItem;
			return calli(Vector3(System.IntPtr,System.IntPtr,Vector3), this.self, item, point, qgrphc_mapFromItem);
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0001854C File Offset: 0x0001674C
		internal readonly Vector3 mapFromParent(Vector3 point)
		{
			this.NullCheck("mapFromParent");
			method qgrphc_mapFromParent = QGraphicsItem.__N.QGrphc_mapFromParent;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_mapFromParent);
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x00018578 File Offset: 0x00016778
		internal readonly Vector3 mapFromScene(Vector3 point)
		{
			this.NullCheck("mapFromScene");
			method qgrphc_mapFromScene = QGraphicsItem.__N.QGrphc_mapFromScene;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_mapFromScene);
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x000185A4 File Offset: 0x000167A4
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qgrphc_setCursor = QGraphicsItem.__N.QGrphc_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qgrphc_setCursor);
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x000185D0 File Offset: 0x000167D0
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qgrphc_unsetCursor = QGraphicsItem.__N.QGrphc_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qgrphc_unsetCursor);
		}

		// Token: 0x04000052 RID: 82
		internal IntPtr self;

		// Token: 0x02000113 RID: 275
		internal static class __N
		{
			// Token: 0x04000B39 RID: 2873
			internal static method QGrphc_DeleteThis;

			// Token: 0x04000B3A RID: 2874
			internal static method QGrphc_isVisible;

			// Token: 0x04000B3B RID: 2875
			internal static method QGrphc_setVisible;

			// Token: 0x04000B3C RID: 2876
			internal static method QGrphc_isEnabled;

			// Token: 0x04000B3D RID: 2877
			internal static method QGrphc_setEnabled;

			// Token: 0x04000B3E RID: 2878
			internal static method QGrphc_isSelected;

			// Token: 0x04000B3F RID: 2879
			internal static method QGrphc_setSelected;

			// Token: 0x04000B40 RID: 2880
			internal static method QGrphc_acceptDrops;

			// Token: 0x04000B41 RID: 2881
			internal static method QGrphc_setAcceptDrops;

			// Token: 0x04000B42 RID: 2882
			internal static method QGrphc_opacity;

			// Token: 0x04000B43 RID: 2883
			internal static method QGrphc_effectiveOpacity;

			// Token: 0x04000B44 RID: 2884
			internal static method QGrphc_setOpacity;

			// Token: 0x04000B45 RID: 2885
			internal static method QGrphc_pos;

			// Token: 0x04000B46 RID: 2886
			internal static method QGrphc_setPos;

			// Token: 0x04000B47 RID: 2887
			internal static method QGrphc_setRotation;

			// Token: 0x04000B48 RID: 2888
			internal static method QGrphc_rotation;

			// Token: 0x04000B49 RID: 2889
			internal static method QGrphc_setScale;

			// Token: 0x04000B4A RID: 2890
			internal static method QGrphc_scale;

			// Token: 0x04000B4B RID: 2891
			internal static method QGrphc_zValue;

			// Token: 0x04000B4C RID: 2892
			internal static method QGrphc_setZValue;

			// Token: 0x04000B4D RID: 2893
			internal static method QGrphc_flags;

			// Token: 0x04000B4E RID: 2894
			internal static method QGrphc_setFlag;

			// Token: 0x04000B4F RID: 2895
			internal static method QGrphc_stackBefore;

			// Token: 0x04000B50 RID: 2896
			internal static method QGrphc_setParentItem;

			// Token: 0x04000B51 RID: 2897
			internal static method QGrphc_update;

			// Token: 0x04000B52 RID: 2898
			internal static method QGrphc_acceptHoverEvents;

			// Token: 0x04000B53 RID: 2899
			internal static method QGrphc_setAcceptHoverEvents;

			// Token: 0x04000B54 RID: 2900
			internal static method QGrphc_mapToItem;

			// Token: 0x04000B55 RID: 2901
			internal static method QGrphc_mapToParent;

			// Token: 0x04000B56 RID: 2902
			internal static method QGrphc_mapToScene;

			// Token: 0x04000B57 RID: 2903
			internal static method QGrphc_mapFromItem;

			// Token: 0x04000B58 RID: 2904
			internal static method QGrphc_mapFromParent;

			// Token: 0x04000B59 RID: 2905
			internal static method QGrphc_mapFromScene;

			// Token: 0x04000B5A RID: 2906
			internal static method QGrphc_setCursor;

			// Token: 0x04000B5B RID: 2907
			internal static method QGrphc_unsetCursor;
		}
	}
}
