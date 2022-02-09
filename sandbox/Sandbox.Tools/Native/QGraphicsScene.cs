using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace Native
{
	// Token: 0x02000049 RID: 73
	internal struct QGraphicsScene
	{
		// Token: 0x06000931 RID: 2353 RVA: 0x00018F82 File Offset: 0x00017182
		public static implicit operator IntPtr(QGraphicsScene value)
		{
			return value.self;
		}

		// Token: 0x06000932 RID: 2354 RVA: 0x00018F8C File Offset: 0x0001718C
		public static implicit operator QGraphicsScene(IntPtr value)
		{
			return new QGraphicsScene
			{
				self = value
			};
		}

		// Token: 0x06000933 RID: 2355 RVA: 0x00018FAA File Offset: 0x000171AA
		public static bool operator ==(QGraphicsScene c1, QGraphicsScene c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000934 RID: 2356 RVA: 0x00018FBD File Offset: 0x000171BD
		public static bool operator !=(QGraphicsScene c1, QGraphicsScene c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000935 RID: 2357 RVA: 0x00018FD0 File Offset: 0x000171D0
		public override bool Equals(object obj)
		{
			if (obj is QGraphicsScene)
			{
				QGraphicsScene c = (QGraphicsScene)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000936 RID: 2358 RVA: 0x00018FFA File Offset: 0x000171FA
		internal QGraphicsScene(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000937 RID: 2359 RVA: 0x00019004 File Offset: 0x00017204
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QGraphicsScene ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000938 RID: 2360 RVA: 0x00019040 File Offset: 0x00017240
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x06000939 RID: 2361 RVA: 0x00019052 File Offset: 0x00017252
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600093A RID: 2362 RVA: 0x0001905D File Offset: 0x0001725D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600093B RID: 2363 RVA: 0x00019070 File Offset: 0x00017270
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QGraphicsScene was null when calling " + n);
			}
		}

		// Token: 0x0600093C RID: 2364 RVA: 0x0001908B File Offset: 0x0001728B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600093D RID: 2365 RVA: 0x00019098 File Offset: 0x00017298
		public static implicit operator QObject(QGraphicsScene value)
		{
			method to_QObject_From_QGraphicsScene = QGraphicsScene.__N.To_QObject_From_QGraphicsScene;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QGraphicsScene);
		}

		// Token: 0x0600093E RID: 2366 RVA: 0x000190BC File Offset: 0x000172BC
		public static explicit operator QGraphicsScene(QObject value)
		{
			method from_QObject_To_QGraphicsScene = QGraphicsScene.__N.From_QObject_To_QGraphicsScene;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QGraphicsScene);
		}

		// Token: 0x0600093F RID: 2367 RVA: 0x000190E0 File Offset: 0x000172E0
		internal readonly QRectF sceneRect()
		{
			this.NullCheck("sceneRect");
			method qgrphc_sceneRect = QGraphicsScene.__N.QGrphc_sceneRect;
			return calli(QRectF(System.IntPtr), this.self, qgrphc_sceneRect);
		}

		// Token: 0x06000940 RID: 2368 RVA: 0x0001910C File Offset: 0x0001730C
		internal readonly void setSceneRect(QRectF rect)
		{
			this.NullCheck("setSceneRect");
			method qgrphc_setSceneRect = QGraphicsScene.__N.QGrphc_setSceneRect;
			calli(System.Void(System.IntPtr,QRectF), this.self, rect, qgrphc_setSceneRect);
		}

		// Token: 0x06000941 RID: 2369 RVA: 0x00019138 File Offset: 0x00017338
		internal readonly QRectF itemsBoundingRect()
		{
			this.NullCheck("itemsBoundingRect");
			method qgrphc_itemsBoundingRect = QGraphicsScene.__N.QGrphc_itemsBoundingRect;
			return calli(QRectF(System.IntPtr), this.self, qgrphc_itemsBoundingRect);
		}

		// Token: 0x06000942 RID: 2370 RVA: 0x00019164 File Offset: 0x00017364
		internal readonly void addItem(QGraphicsItem item)
		{
			this.NullCheck("addItem");
			method qgrphc_addItem = QGraphicsScene.__N.QGrphc_addItem;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, item, qgrphc_addItem);
		}

		// Token: 0x06000943 RID: 2371 RVA: 0x00019194 File Offset: 0x00017394
		internal readonly void removeItem(QGraphicsItem item)
		{
			this.NullCheck("removeItem");
			method qgrphc_removeItem = QGraphicsScene.__N.QGrphc_removeItem;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, item, qgrphc_removeItem);
		}

		// Token: 0x06000944 RID: 2372 RVA: 0x000191C4 File Offset: 0x000173C4
		internal readonly void deleteLater()
		{
			this.NullCheck("deleteLater");
			method qgrphc_deleteLater = QGraphicsScene.__N.QGrphc_deleteLater;
			calli(System.Void(System.IntPtr), this.self, qgrphc_deleteLater);
		}

		// Token: 0x06000945 RID: 2373 RVA: 0x000191F0 File Offset: 0x000173F0
		internal readonly string objectName()
		{
			this.NullCheck("objectName");
			method qgrphc_objectName = QGraphicsScene.__N.QGrphc_objectName;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qgrphc_objectName));
		}

		// Token: 0x06000946 RID: 2374 RVA: 0x00019220 File Offset: 0x00017420
		internal readonly void setObjectName(string name)
		{
			this.NullCheck("setObjectName");
			method qgrphc_setObjectName = QGraphicsScene.__N.QGrphc_setObjectName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qgrphc_setObjectName);
		}

		// Token: 0x06000947 RID: 2375 RVA: 0x00019250 File Offset: 0x00017450
		internal readonly void setProperty(string key, bool value)
		{
			this.NullCheck("setProperty");
			method qgrphc_setProperty = QGraphicsScene.__N.QGrphc_setProperty;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, qgrphc_setProperty);
		}

		// Token: 0x06000948 RID: 2376 RVA: 0x00019288 File Offset: 0x00017488
		internal readonly void setProperty(string key, float value)
		{
			this.NullCheck("setProperty");
			method qgrphc_f = QGraphicsScene.__N.QGrphc_f37;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, qgrphc_f);
		}

		// Token: 0x06000949 RID: 2377 RVA: 0x000192BC File Offset: 0x000174BC
		internal readonly void setProperty(string key, string value)
		{
			this.NullCheck("setProperty");
			method qgrphc_f = QGraphicsScene.__N.QGrphc_f38;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), qgrphc_f);
		}

		// Token: 0x04000054 RID: 84
		internal IntPtr self;

		// Token: 0x02000115 RID: 277
		internal static class __N
		{
			// Token: 0x04000B8B RID: 2955
			internal static method From_QObject_To_QGraphicsScene;

			// Token: 0x04000B8C RID: 2956
			internal static method To_QObject_From_QGraphicsScene;

			// Token: 0x04000B8D RID: 2957
			internal static method QGrphc_sceneRect;

			// Token: 0x04000B8E RID: 2958
			internal static method QGrphc_setSceneRect;

			// Token: 0x04000B8F RID: 2959
			internal static method QGrphc_itemsBoundingRect;

			// Token: 0x04000B90 RID: 2960
			internal static method QGrphc_addItem;

			// Token: 0x04000B91 RID: 2961
			internal static method QGrphc_removeItem;

			// Token: 0x04000B92 RID: 2962
			internal static method QGrphc_deleteLater;

			// Token: 0x04000B93 RID: 2963
			internal static method QGrphc_objectName;

			// Token: 0x04000B94 RID: 2964
			internal static method QGrphc_setObjectName;

			// Token: 0x04000B95 RID: 2965
			internal static method QGrphc_setProperty;

			// Token: 0x04000B96 RID: 2966
			internal static method QGrphc_f37;

			// Token: 0x04000B97 RID: 2967
			internal static method QGrphc_f38;
		}
	}
}
