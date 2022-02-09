using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200004A RID: 74
	internal struct QGraphicsSimpleTextItem
	{
		// Token: 0x0600094A RID: 2378 RVA: 0x000192F2 File Offset: 0x000174F2
		public static implicit operator IntPtr(QGraphicsSimpleTextItem value)
		{
			return value.self;
		}

		// Token: 0x0600094B RID: 2379 RVA: 0x000192FC File Offset: 0x000174FC
		public static implicit operator QGraphicsSimpleTextItem(IntPtr value)
		{
			return new QGraphicsSimpleTextItem
			{
				self = value
			};
		}

		// Token: 0x0600094C RID: 2380 RVA: 0x0001931A File Offset: 0x0001751A
		public static bool operator ==(QGraphicsSimpleTextItem c1, QGraphicsSimpleTextItem c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600094D RID: 2381 RVA: 0x0001932D File Offset: 0x0001752D
		public static bool operator !=(QGraphicsSimpleTextItem c1, QGraphicsSimpleTextItem c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600094E RID: 2382 RVA: 0x00019340 File Offset: 0x00017540
		public override bool Equals(object obj)
		{
			if (obj is QGraphicsSimpleTextItem)
			{
				QGraphicsSimpleTextItem c = (QGraphicsSimpleTextItem)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x0001936A File Offset: 0x0001756A
		internal QGraphicsSimpleTextItem(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x00019374 File Offset: 0x00017574
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QGraphicsSimpleTextItem ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x06000951 RID: 2385 RVA: 0x000193B0 File Offset: 0x000175B0
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x06000952 RID: 2386 RVA: 0x000193C2 File Offset: 0x000175C2
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x000193CD File Offset: 0x000175CD
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x000193E0 File Offset: 0x000175E0
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QGraphicsSimpleTextItem was null when calling " + n);
			}
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x000193FB File Offset: 0x000175FB
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000956 RID: 2390 RVA: 0x00019408 File Offset: 0x00017608
		public static implicit operator QGraphicsItem(QGraphicsSimpleTextItem value)
		{
			method to_QGraphicsItem_From_QGraphicsSimpleTextItem = QGraphicsSimpleTextItem.__N.To_QGraphicsItem_From_QGraphicsSimpleTextItem;
			return calli(System.IntPtr(System.IntPtr), value, to_QGraphicsItem_From_QGraphicsSimpleTextItem);
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x0001942C File Offset: 0x0001762C
		public static explicit operator QGraphicsSimpleTextItem(QGraphicsItem value)
		{
			method from_QGraphicsItem_To_QGraphicsSimpleTextItem = QGraphicsSimpleTextItem.__N.From_QGraphicsItem_To_QGraphicsSimpleTextItem;
			return calli(System.IntPtr(System.IntPtr), value, from_QGraphicsItem_To_QGraphicsSimpleTextItem);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x00019450 File Offset: 0x00017650
		internal static QGraphicsSimpleTextItem Create(string text, QGraphicsItem parent)
		{
			method qgrphc_Create = QGraphicsSimpleTextItem.__N.QGrphc_Create;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr), Interop.GetWPointer(text), parent, qgrphc_Create);
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x0001947C File Offset: 0x0001767C
		internal readonly void setText(string text)
		{
			this.NullCheck("setText");
			method qgrphc_setText = QGraphicsSimpleTextItem.__N.QGrphc_setText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qgrphc_setText);
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x000194AC File Offset: 0x000176AC
		internal readonly string text()
		{
			this.NullCheck("text");
			method qgrphc_text = QGraphicsSimpleTextItem.__N.QGrphc_text;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qgrphc_text));
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x000194DC File Offset: 0x000176DC
		internal readonly void DeleteThis()
		{
			this.NullCheck("DeleteThis");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f49;
			calli(System.Void(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x0600095C RID: 2396 RVA: 0x00019508 File Offset: 0x00017708
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f50;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x0600095D RID: 2397 RVA: 0x00019538 File Offset: 0x00017738
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f51;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qgrphc_f);
		}

		// Token: 0x0600095E RID: 2398 RVA: 0x0001956C File Offset: 0x0001776C
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f52;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x0001959C File Offset: 0x0001779C
		internal readonly void setEnabled(bool enabled)
		{
			this.NullCheck("setEnabled");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f53;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x000195D0 File Offset: 0x000177D0
		internal readonly bool isSelected()
		{
			this.NullCheck("isSelected");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f54;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x00019600 File Offset: 0x00017800
		internal readonly void setSelected(bool selected)
		{
			this.NullCheck("setSelected");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f55;
			calli(System.Void(System.IntPtr,System.Int32), this.self, selected ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000962 RID: 2402 RVA: 0x00019634 File Offset: 0x00017834
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f56;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x06000963 RID: 2403 RVA: 0x00019664 File Offset: 0x00017864
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f57;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000964 RID: 2404 RVA: 0x00019698 File Offset: 0x00017898
		internal readonly float opacity()
		{
			this.NullCheck("opacity");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f58;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000965 RID: 2405 RVA: 0x000196C4 File Offset: 0x000178C4
		internal readonly float effectiveOpacity()
		{
			this.NullCheck("effectiveOpacity");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f59;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000966 RID: 2406 RVA: 0x000196F0 File Offset: 0x000178F0
		internal readonly void setOpacity(float opacity)
		{
			this.NullCheck("setOpacity");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f60;
			calli(System.Void(System.IntPtr,System.Single), this.self, opacity, qgrphc_f);
		}

		// Token: 0x06000967 RID: 2407 RVA: 0x0001971C File Offset: 0x0001791C
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f61;
			return calli(Vector3(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000968 RID: 2408 RVA: 0x00019748 File Offset: 0x00017948
		internal readonly void setPos(Vector3 pos)
		{
			this.NullCheck("setPos");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f62;
			calli(System.Void(System.IntPtr,Vector3), this.self, pos, qgrphc_f);
		}

		// Token: 0x06000969 RID: 2409 RVA: 0x00019774 File Offset: 0x00017974
		internal readonly void setRotation(float angle)
		{
			this.NullCheck("setRotation");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f63;
			calli(System.Void(System.IntPtr,System.Single), this.self, angle, qgrphc_f);
		}

		// Token: 0x0600096A RID: 2410 RVA: 0x000197A0 File Offset: 0x000179A0
		internal readonly float rotation()
		{
			this.NullCheck("rotation");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f64;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x0600096B RID: 2411 RVA: 0x000197CC File Offset: 0x000179CC
		internal readonly void setScale(float scale)
		{
			this.NullCheck("setScale");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f65;
			calli(System.Void(System.IntPtr,System.Single), this.self, scale, qgrphc_f);
		}

		// Token: 0x0600096C RID: 2412 RVA: 0x000197F8 File Offset: 0x000179F8
		internal readonly float scale()
		{
			this.NullCheck("scale");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f66;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x0600096D RID: 2413 RVA: 0x00019824 File Offset: 0x00017A24
		internal readonly float zValue()
		{
			this.NullCheck("zValue");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f67;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x0600096E RID: 2414 RVA: 0x00019850 File Offset: 0x00017A50
		internal readonly void setZValue(float z)
		{
			this.NullCheck("setZValue");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f68;
			calli(System.Void(System.IntPtr,System.Single), this.self, z, qgrphc_f);
		}

		// Token: 0x0600096F RID: 2415 RVA: 0x0001987C File Offset: 0x00017A7C
		internal readonly GraphicsItemFlag flags()
		{
			this.NullCheck("flags");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f69;
			return calli(System.Int64(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000970 RID: 2416 RVA: 0x000198A8 File Offset: 0x00017AA8
		internal readonly void setFlag(GraphicsItemFlag flag, bool enabled)
		{
			this.NullCheck("setFlag");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f70;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)flag, enabled ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000971 RID: 2417 RVA: 0x000198DC File Offset: 0x00017ADC
		internal readonly void stackBefore(QGraphicsItem sibling)
		{
			this.NullCheck("stackBefore");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f71;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, sibling, qgrphc_f);
		}

		// Token: 0x06000972 RID: 2418 RVA: 0x0001990C File Offset: 0x00017B0C
		internal readonly void setParentItem(QGraphicsItem parent)
		{
			this.NullCheck("setParentItem");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f72;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qgrphc_f);
		}

		// Token: 0x06000973 RID: 2419 RVA: 0x0001993C File Offset: 0x00017B3C
		internal readonly void update()
		{
			this.NullCheck("update");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f73;
			calli(System.Void(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x06000974 RID: 2420 RVA: 0x00019968 File Offset: 0x00017B68
		internal readonly bool acceptHoverEvents()
		{
			this.NullCheck("acceptHoverEvents");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f74;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x00019998 File Offset: 0x00017B98
		internal readonly void setAcceptHoverEvents(bool enabled)
		{
			this.NullCheck("setAcceptHoverEvents");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f75;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qgrphc_f);
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x000199CC File Offset: 0x00017BCC
		internal readonly Vector3 mapToItem(QGraphicsItem item, Vector3 point)
		{
			this.NullCheck("mapToItem");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f76;
			return calli(Vector3(System.IntPtr,System.IntPtr,Vector3), this.self, item, point, qgrphc_f);
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x00019A00 File Offset: 0x00017C00
		internal readonly Vector3 mapToParent(Vector3 point)
		{
			this.NullCheck("mapToParent");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f77;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_f);
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x00019A2C File Offset: 0x00017C2C
		internal readonly Vector3 mapToScene(Vector3 point)
		{
			this.NullCheck("mapToScene");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f78;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_f);
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x00019A58 File Offset: 0x00017C58
		internal readonly Vector3 mapFromItem(QGraphicsItem item, Vector3 point)
		{
			this.NullCheck("mapFromItem");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f79;
			return calli(Vector3(System.IntPtr,System.IntPtr,Vector3), this.self, item, point, qgrphc_f);
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x00019A8C File Offset: 0x00017C8C
		internal readonly Vector3 mapFromParent(Vector3 point)
		{
			this.NullCheck("mapFromParent");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f80;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_f);
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x00019AB8 File Offset: 0x00017CB8
		internal readonly Vector3 mapFromScene(Vector3 point)
		{
			this.NullCheck("mapFromScene");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f81;
			return calli(Vector3(System.IntPtr,Vector3), this.self, point, qgrphc_f);
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x00019AE4 File Offset: 0x00017CE4
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f82;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qgrphc_f);
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x00019B10 File Offset: 0x00017D10
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qgrphc_f = QGraphicsSimpleTextItem.__N.QGrphc_f83;
			calli(System.Void(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x04000055 RID: 85
		internal IntPtr self;

		// Token: 0x02000116 RID: 278
		internal static class __N
		{
			// Token: 0x04000B98 RID: 2968
			internal static method From_QGraphicsItem_To_QGraphicsSimpleTextItem;

			// Token: 0x04000B99 RID: 2969
			internal static method To_QGraphicsItem_From_QGraphicsSimpleTextItem;

			// Token: 0x04000B9A RID: 2970
			internal static method QGrphc_Create;

			// Token: 0x04000B9B RID: 2971
			internal static method QGrphc_setText;

			// Token: 0x04000B9C RID: 2972
			internal static method QGrphc_text;

			// Token: 0x04000B9D RID: 2973
			internal static method QGrphc_f49;

			// Token: 0x04000B9E RID: 2974
			internal static method QGrphc_f50;

			// Token: 0x04000B9F RID: 2975
			internal static method QGrphc_f51;

			// Token: 0x04000BA0 RID: 2976
			internal static method QGrphc_f52;

			// Token: 0x04000BA1 RID: 2977
			internal static method QGrphc_f53;

			// Token: 0x04000BA2 RID: 2978
			internal static method QGrphc_f54;

			// Token: 0x04000BA3 RID: 2979
			internal static method QGrphc_f55;

			// Token: 0x04000BA4 RID: 2980
			internal static method QGrphc_f56;

			// Token: 0x04000BA5 RID: 2981
			internal static method QGrphc_f57;

			// Token: 0x04000BA6 RID: 2982
			internal static method QGrphc_f58;

			// Token: 0x04000BA7 RID: 2983
			internal static method QGrphc_f59;

			// Token: 0x04000BA8 RID: 2984
			internal static method QGrphc_f60;

			// Token: 0x04000BA9 RID: 2985
			internal static method QGrphc_f61;

			// Token: 0x04000BAA RID: 2986
			internal static method QGrphc_f62;

			// Token: 0x04000BAB RID: 2987
			internal static method QGrphc_f63;

			// Token: 0x04000BAC RID: 2988
			internal static method QGrphc_f64;

			// Token: 0x04000BAD RID: 2989
			internal static method QGrphc_f65;

			// Token: 0x04000BAE RID: 2990
			internal static method QGrphc_f66;

			// Token: 0x04000BAF RID: 2991
			internal static method QGrphc_f67;

			// Token: 0x04000BB0 RID: 2992
			internal static method QGrphc_f68;

			// Token: 0x04000BB1 RID: 2993
			internal static method QGrphc_f69;

			// Token: 0x04000BB2 RID: 2994
			internal static method QGrphc_f70;

			// Token: 0x04000BB3 RID: 2995
			internal static method QGrphc_f71;

			// Token: 0x04000BB4 RID: 2996
			internal static method QGrphc_f72;

			// Token: 0x04000BB5 RID: 2997
			internal static method QGrphc_f73;

			// Token: 0x04000BB6 RID: 2998
			internal static method QGrphc_f74;

			// Token: 0x04000BB7 RID: 2999
			internal static method QGrphc_f75;

			// Token: 0x04000BB8 RID: 3000
			internal static method QGrphc_f76;

			// Token: 0x04000BB9 RID: 3001
			internal static method QGrphc_f77;

			// Token: 0x04000BBA RID: 3002
			internal static method QGrphc_f78;

			// Token: 0x04000BBB RID: 3003
			internal static method QGrphc_f79;

			// Token: 0x04000BBC RID: 3004
			internal static method QGrphc_f80;

			// Token: 0x04000BBD RID: 3005
			internal static method QGrphc_f81;

			// Token: 0x04000BBE RID: 3006
			internal static method QGrphc_f82;

			// Token: 0x04000BBF RID: 3007
			internal static method QGrphc_f83;
		}
	}
}
