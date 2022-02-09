using System;
using System.Runtime.CompilerServices;
using Tools;

namespace Native
{
	// Token: 0x02000048 RID: 72
	internal struct QGraphicsProxyWidget
	{
		// Token: 0x060008F6 RID: 2294 RVA: 0x000185FA File Offset: 0x000167FA
		public static implicit operator IntPtr(QGraphicsProxyWidget value)
		{
			return value.self;
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x00018604 File Offset: 0x00016804
		public static implicit operator QGraphicsProxyWidget(IntPtr value)
		{
			return new QGraphicsProxyWidget
			{
				self = value
			};
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x00018622 File Offset: 0x00016822
		public static bool operator ==(QGraphicsProxyWidget c1, QGraphicsProxyWidget c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00018635 File Offset: 0x00016835
		public static bool operator !=(QGraphicsProxyWidget c1, QGraphicsProxyWidget c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x00018648 File Offset: 0x00016848
		public override bool Equals(object obj)
		{
			if (obj is QGraphicsProxyWidget)
			{
				QGraphicsProxyWidget c = (QGraphicsProxyWidget)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x00018672 File Offset: 0x00016872
		internal QGraphicsProxyWidget(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x0001867C File Offset: 0x0001687C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QGraphicsProxyWidget ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060008FD RID: 2301 RVA: 0x000186B8 File Offset: 0x000168B8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060008FE RID: 2302 RVA: 0x000186CA File Offset: 0x000168CA
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x060008FF RID: 2303 RVA: 0x000186D5 File Offset: 0x000168D5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000900 RID: 2304 RVA: 0x000186E8 File Offset: 0x000168E8
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QGraphicsProxyWidget was null when calling " + n);
			}
		}

		// Token: 0x06000901 RID: 2305 RVA: 0x00018703 File Offset: 0x00016903
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x00018710 File Offset: 0x00016910
		public static implicit operator QGraphicsItem(QGraphicsProxyWidget value)
		{
			method to_QGraphicsItem_From_QGraphicsProxyWidget = QGraphicsProxyWidget.__N.To_QGraphicsItem_From_QGraphicsProxyWidget;
			return calli(System.IntPtr(System.IntPtr), value, to_QGraphicsItem_From_QGraphicsProxyWidget);
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x00018734 File Offset: 0x00016934
		public static explicit operator QGraphicsProxyWidget(QGraphicsItem value)
		{
			method from_QGraphicsItem_To_QGraphicsProxyWidget = QGraphicsProxyWidget.__N.From_QGraphicsItem_To_QGraphicsProxyWidget;
			return calli(System.IntPtr(System.IntPtr), value, from_QGraphicsItem_To_QGraphicsProxyWidget);
		}

		// Token: 0x06000904 RID: 2308 RVA: 0x00018758 File Offset: 0x00016958
		internal readonly void setWidget(QWidget widget)
		{
			this.NullCheck("setWidget");
			method qgrphc_setWidget = QGraphicsProxyWidget.__N.QGrphc_setWidget;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qgrphc_setWidget);
		}

		// Token: 0x06000905 RID: 2309 RVA: 0x00018788 File Offset: 0x00016988
		internal readonly QWidget widget()
		{
			this.NullCheck("widget");
			method qgrphc_widget = QGraphicsProxyWidget.__N.QGrphc_widget;
			return calli(System.IntPtr(System.IntPtr), this.self, qgrphc_widget);
		}

		// Token: 0x06000906 RID: 2310 RVA: 0x000187B8 File Offset: 0x000169B8
		internal readonly void resize(Vector3 size)
		{
			this.NullCheck("resize");
			method qgrphc_resize = QGraphicsProxyWidget.__N.QGrphc_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, size, qgrphc_resize);
		}

		// Token: 0x06000907 RID: 2311 RVA: 0x000187E4 File Offset: 0x000169E4
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qgrphc_size = QGraphicsProxyWidget.__N.QGrphc_size;
			return calli(Vector3(System.IntPtr), this.self, qgrphc_size);
		}

		// Token: 0x06000908 RID: 2312 RVA: 0x00018810 File Offset: 0x00016A10
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qgrphc_minimumSize = QGraphicsProxyWidget.__N.QGrphc_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qgrphc_minimumSize);
		}

		// Token: 0x06000909 RID: 2313 RVA: 0x0001883C File Offset: 0x00016A3C
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qgrphc_setMinimumSize = QGraphicsProxyWidget.__N.QGrphc_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qgrphc_setMinimumSize);
		}

		// Token: 0x0600090A RID: 2314 RVA: 0x00018868 File Offset: 0x00016A68
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qgrphc_maximumSize = QGraphicsProxyWidget.__N.QGrphc_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qgrphc_maximumSize);
		}

		// Token: 0x0600090B RID: 2315 RVA: 0x00018894 File Offset: 0x00016A94
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qgrphc_setMaximumSize = QGraphicsProxyWidget.__N.QGrphc_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qgrphc_setMaximumSize);
		}

		// Token: 0x0600090C RID: 2316 RVA: 0x000188C0 File Offset: 0x00016AC0
		internal readonly void setAttribute(Widget.Flag none, bool on)
		{
			this.NullCheck("setAttribute");
			method qgrphc_setAttribute = QGraphicsProxyWidget.__N.QGrphc_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)none, on ? 1 : 0, qgrphc_setAttribute);
		}

		// Token: 0x0600090D RID: 2317 RVA: 0x000188F4 File Offset: 0x00016AF4
		internal readonly bool testAttribute(Widget.Flag attribute)
		{
			this.NullCheck("testAttribute");
			method qgrphc_testAttribute = QGraphicsProxyWidget.__N.QGrphc_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)attribute, qgrphc_testAttribute) > 0;
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00018924 File Offset: 0x00016B24
		internal readonly void DeleteThis()
		{
			this.NullCheck("DeleteThis");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f2;
			calli(System.Void(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00018950 File Offset: 0x00016B50
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f3;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00018980 File Offset: 0x00016B80
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f4;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x000189B4 File Offset: 0x00016BB4
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f5;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x000189E4 File Offset: 0x00016BE4
		internal readonly void setEnabled(bool enabled)
		{
			this.NullCheck("setEnabled");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f6;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000913 RID: 2323 RVA: 0x00018A18 File Offset: 0x00016C18
		internal readonly bool isSelected()
		{
			this.NullCheck("isSelected");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f7;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x06000914 RID: 2324 RVA: 0x00018A48 File Offset: 0x00016C48
		internal readonly void setSelected(bool selected)
		{
			this.NullCheck("setSelected");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f8;
			calli(System.Void(System.IntPtr,System.Int32), this.self, selected ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000915 RID: 2325 RVA: 0x00018A7C File Offset: 0x00016C7C
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f9;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x06000916 RID: 2326 RVA: 0x00018AAC File Offset: 0x00016CAC
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f10;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000917 RID: 2327 RVA: 0x00018AE0 File Offset: 0x00016CE0
		internal readonly float opacity()
		{
			this.NullCheck("opacity");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f11;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000918 RID: 2328 RVA: 0x00018B0C File Offset: 0x00016D0C
		internal readonly float effectiveOpacity()
		{
			this.NullCheck("effectiveOpacity");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f12;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000919 RID: 2329 RVA: 0x00018B38 File Offset: 0x00016D38
		internal readonly void setOpacity(float opacity)
		{
			this.NullCheck("setOpacity");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f13;
			calli(System.Void(System.IntPtr,System.Single), this.self, opacity, qgrphc_f);
		}

		// Token: 0x0600091A RID: 2330 RVA: 0x00018B64 File Offset: 0x00016D64
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f14;
			return calli(Vector3(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x0600091B RID: 2331 RVA: 0x00018B90 File Offset: 0x00016D90
		internal readonly void setPos(Vector3 pos)
		{
			this.NullCheck("setPos");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f15;
			calli(System.Void(System.IntPtr,Vector3), this.self, pos, qgrphc_f);
		}

		// Token: 0x0600091C RID: 2332 RVA: 0x00018BBC File Offset: 0x00016DBC
		internal readonly void setRotation(float angle)
		{
			this.NullCheck("setRotation");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f16;
			calli(System.Void(System.IntPtr,System.Single), this.self, angle, qgrphc_f);
		}

		// Token: 0x0600091D RID: 2333 RVA: 0x00018BE8 File Offset: 0x00016DE8
		internal readonly float rotation()
		{
			this.NullCheck("rotation");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f17;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x0600091E RID: 2334 RVA: 0x00018C14 File Offset: 0x00016E14
		internal readonly void setScale(float scale)
		{
			this.NullCheck("setScale");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f18;
			calli(System.Void(System.IntPtr,System.Single), this.self, scale, qgrphc_f);
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00018C40 File Offset: 0x00016E40
		internal readonly float scale()
		{
			this.NullCheck("scale");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f19;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00018C6C File Offset: 0x00016E6C
		internal readonly float zValue()
		{
			this.NullCheck("zValue");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f20;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x00018C98 File Offset: 0x00016E98
		internal readonly void setZValue(float z)
		{
			this.NullCheck("setZValue");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f21;
			calli(System.Void(System.IntPtr,System.Single), this.self, z, qgrphc_f);
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x00018CC4 File Offset: 0x00016EC4
		internal readonly GraphicsItemFlag flags()
		{
			this.NullCheck("flags");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f22;
			return calli(System.Int64(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00018CF0 File Offset: 0x00016EF0
		internal readonly void setFlag(GraphicsItemFlag flag, bool enabled)
		{
			this.NullCheck("setFlag");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f23;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)flag, enabled ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00018D24 File Offset: 0x00016F24
		internal readonly void stackBefore(QGraphicsItem sibling)
		{
			this.NullCheck("stackBefore");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f24;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, sibling, qgrphc_f);
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x00018D54 File Offset: 0x00016F54
		internal readonly void setParentItem(QGraphicsItem parent)
		{
			this.NullCheck("setParentItem");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f25;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qgrphc_f);
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00018D84 File Offset: 0x00016F84
		internal readonly void update()
		{
			this.NullCheck("update");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f26;
			calli(System.Void(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000927 RID: 2343 RVA: 0x00018DB0 File Offset: 0x00016FB0
		internal readonly bool acceptHoverEvents()
		{
			this.NullCheck("acceptHoverEvents");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f27;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00018DE0 File Offset: 0x00016FE0
		internal readonly void setAcceptHoverEvents(bool enabled)
		{
			this.NullCheck("setAcceptHoverEvents");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f28;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00018E14 File Offset: 0x00017014
		internal readonly Vector3 mapToItem(QGraphicsItem item, Vector3 point)
		{
			this.NullCheck("mapToItem");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f29;
			return calli(Vector3(System.IntPtr,System.IntPtr,Vector3), this.self, item, point, qgrphc_f);
		}

		// Token: 0x0600092A RID: 2346 RVA: 0x00018E48 File Offset: 0x00017048
		internal readonly Vector3 mapToParent(Vector3 point)
		{
			this.NullCheck("mapToParent");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f30;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_f);
		}

		// Token: 0x0600092B RID: 2347 RVA: 0x00018E74 File Offset: 0x00017074
		internal readonly Vector3 mapToScene(Vector3 point)
		{
			this.NullCheck("mapToScene");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f31;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_f);
		}

		// Token: 0x0600092C RID: 2348 RVA: 0x00018EA0 File Offset: 0x000170A0
		internal readonly Vector3 mapFromItem(QGraphicsItem item, Vector3 point)
		{
			this.NullCheck("mapFromItem");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f32;
			return calli(Vector3(System.IntPtr,System.IntPtr,Vector3), this.self, item, point, qgrphc_f);
		}

		// Token: 0x0600092D RID: 2349 RVA: 0x00018ED4 File Offset: 0x000170D4
		internal readonly Vector3 mapFromParent(Vector3 point)
		{
			this.NullCheck("mapFromParent");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f33;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_f);
		}

		// Token: 0x0600092E RID: 2350 RVA: 0x00018F00 File Offset: 0x00017100
		internal readonly Vector3 mapFromScene(Vector3 point)
		{
			this.NullCheck("mapFromScene");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f34;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_f);
		}

		// Token: 0x0600092F RID: 2351 RVA: 0x00018F2C File Offset: 0x0001712C
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f35;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qgrphc_f);
		}

		// Token: 0x06000930 RID: 2352 RVA: 0x00018F58 File Offset: 0x00017158
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qgrphc_f = QGraphicsProxyWidget.__N.QGrphc_f36;
			calli(System.Void(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x04000053 RID: 83
		internal IntPtr self;

		// Token: 0x02000114 RID: 276
		internal static class __N
		{
			// Token: 0x04000B5C RID: 2908
			internal static method From_QGraphicsItem_To_QGraphicsProxyWidget;

			// Token: 0x04000B5D RID: 2909
			internal static method To_QGraphicsItem_From_QGraphicsProxyWidget;

			// Token: 0x04000B5E RID: 2910
			internal static method QGrphc_setWidget;

			// Token: 0x04000B5F RID: 2911
			internal static method QGrphc_widget;

			// Token: 0x04000B60 RID: 2912
			internal static method QGrphc_resize;

			// Token: 0x04000B61 RID: 2913
			internal static method QGrphc_size;

			// Token: 0x04000B62 RID: 2914
			internal static method QGrphc_minimumSize;

			// Token: 0x04000B63 RID: 2915
			internal static method QGrphc_setMinimumSize;

			// Token: 0x04000B64 RID: 2916
			internal static method QGrphc_maximumSize;

			// Token: 0x04000B65 RID: 2917
			internal static method QGrphc_setMaximumSize;

			// Token: 0x04000B66 RID: 2918
			internal static method QGrphc_setAttribute;

			// Token: 0x04000B67 RID: 2919
			internal static method QGrphc_testAttribute;

			// Token: 0x04000B68 RID: 2920
			internal static method QGrphc_f2;

			// Token: 0x04000B69 RID: 2921
			internal static method QGrphc_f3;

			// Token: 0x04000B6A RID: 2922
			internal static method QGrphc_f4;

			// Token: 0x04000B6B RID: 2923
			internal static method QGrphc_f5;

			// Token: 0x04000B6C RID: 2924
			internal static method QGrphc_f6;

			// Token: 0x04000B6D RID: 2925
			internal static method QGrphc_f7;

			// Token: 0x04000B6E RID: 2926
			internal static method QGrphc_f8;

			// Token: 0x04000B6F RID: 2927
			internal static method QGrphc_f9;

			// Token: 0x04000B70 RID: 2928
			internal static method QGrphc_f10;

			// Token: 0x04000B71 RID: 2929
			internal static method QGrphc_f11;

			// Token: 0x04000B72 RID: 2930
			internal static method QGrphc_f12;

			// Token: 0x04000B73 RID: 2931
			internal static method QGrphc_f13;

			// Token: 0x04000B74 RID: 2932
			internal static method QGrphc_f14;

			// Token: 0x04000B75 RID: 2933
			internal static method QGrphc_f15;

			// Token: 0x04000B76 RID: 2934
			internal static method QGrphc_f16;

			// Token: 0x04000B77 RID: 2935
			internal static method QGrphc_f17;

			// Token: 0x04000B78 RID: 2936
			internal static method QGrphc_f18;

			// Token: 0x04000B79 RID: 2937
			internal static method QGrphc_f19;

			// Token: 0x04000B7A RID: 2938
			internal static method QGrphc_f20;

			// Token: 0x04000B7B RID: 2939
			internal static method QGrphc_f21;

			// Token: 0x04000B7C RID: 2940
			internal static method QGrphc_f22;

			// Token: 0x04000B7D RID: 2941
			internal static method QGrphc_f23;

			// Token: 0x04000B7E RID: 2942
			internal static method QGrphc_f24;

			// Token: 0x04000B7F RID: 2943
			internal static method QGrphc_f25;

			// Token: 0x04000B80 RID: 2944
			internal static method QGrphc_f26;

			// Token: 0x04000B81 RID: 2945
			internal static method QGrphc_f27;

			// Token: 0x04000B82 RID: 2946
			internal static method QGrphc_f28;

			// Token: 0x04000B83 RID: 2947
			internal static method QGrphc_f29;

			// Token: 0x04000B84 RID: 2948
			internal static method QGrphc_f30;

			// Token: 0x04000B85 RID: 2949
			internal static method QGrphc_f31;

			// Token: 0x04000B86 RID: 2950
			internal static method QGrphc_f32;

			// Token: 0x04000B87 RID: 2951
			internal static method QGrphc_f33;

			// Token: 0x04000B88 RID: 2952
			internal static method QGrphc_f34;

			// Token: 0x04000B89 RID: 2953
			internal static method QGrphc_f35;

			// Token: 0x04000B8A RID: 2954
			internal static method QGrphc_f36;
		}
	}
}
