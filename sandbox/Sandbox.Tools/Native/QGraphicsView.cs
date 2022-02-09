using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200004B RID: 75
	internal struct QGraphicsView
	{
		// Token: 0x0600097E RID: 2430 RVA: 0x00019B3A File Offset: 0x00017D3A
		public static implicit operator IntPtr(QGraphicsView value)
		{
			return value.self;
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x00019B44 File Offset: 0x00017D44
		public static implicit operator QGraphicsView(IntPtr value)
		{
			return new QGraphicsView
			{
				self = value
			};
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x00019B62 File Offset: 0x00017D62
		public static bool operator ==(QGraphicsView c1, QGraphicsView c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00019B75 File Offset: 0x00017D75
		public static bool operator !=(QGraphicsView c1, QGraphicsView c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x00019B88 File Offset: 0x00017D88
		public override bool Equals(object obj)
		{
			if (obj is QGraphicsView)
			{
				QGraphicsView c = (QGraphicsView)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x00019BB2 File Offset: 0x00017DB2
		internal QGraphicsView(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x00019BBC File Offset: 0x00017DBC
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QGraphicsView ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000985 RID: 2437 RVA: 0x00019BF8 File Offset: 0x00017DF8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00019C0A File Offset: 0x00017E0A
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x00019C15 File Offset: 0x00017E15
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x00019C28 File Offset: 0x00017E28
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QGraphicsView was null when calling " + n);
			}
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x00019C43 File Offset: 0x00017E43
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00019C50 File Offset: 0x00017E50
		public static implicit operator QFrame(QGraphicsView value)
		{
			method to_QFrame_From_QGraphicsView = QGraphicsView.__N.To_QFrame_From_QGraphicsView;
			return calli(System.IntPtr(System.IntPtr), value, to_QFrame_From_QGraphicsView);
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x00019C74 File Offset: 0x00017E74
		public static explicit operator QGraphicsView(QFrame value)
		{
			method from_QFrame_To_QGraphicsView = QGraphicsView.__N.From_QFrame_To_QGraphicsView;
			return calli(System.IntPtr(System.IntPtr), value, from_QFrame_To_QGraphicsView);
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00019C98 File Offset: 0x00017E98
		public static implicit operator QWidget(QGraphicsView value)
		{
			method to_QWidget_From_QGraphicsView = QGraphicsView.__N.To_QWidget_From_QGraphicsView;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QGraphicsView);
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x00019CBC File Offset: 0x00017EBC
		public static explicit operator QGraphicsView(QWidget value)
		{
			method from_QWidget_To_QGraphicsView = QGraphicsView.__N.From_QWidget_To_QGraphicsView;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QGraphicsView);
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00019CE0 File Offset: 0x00017EE0
		public static implicit operator QObject(QGraphicsView value)
		{
			method to_QObject_From_QGraphicsView = QGraphicsView.__N.To_QObject_From_QGraphicsView;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QGraphicsView);
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x00019D04 File Offset: 0x00017F04
		public static explicit operator QGraphicsView(QObject value)
		{
			method from_QObject_To_QGraphicsView = QGraphicsView.__N.From_QObject_To_QGraphicsView;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QGraphicsView);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00019D28 File Offset: 0x00017F28
		internal readonly bool isInteractive()
		{
			this.NullCheck("isInteractive");
			method qgrphc_isInteractive = QGraphicsView.__N.QGrphc_isInteractive;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isInteractive) > 0;
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00019D58 File Offset: 0x00017F58
		internal readonly void setInteractive(bool allowed)
		{
			this.NullCheck("setInteractive");
			method qgrphc_setInteractive = QGraphicsView.__N.QGrphc_setInteractive;
			calli(System.Void(System.IntPtr,System.Int32), this.self, allowed ? 1 : 0, qgrphc_setInteractive);
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x00019D8C File Offset: 0x00017F8C
		internal readonly void resetTransform()
		{
			this.NullCheck("resetTransform");
			method qgrphc_resetTransform = QGraphicsView.__N.QGrphc_resetTransform;
			calli(System.Void(System.IntPtr), this.self, qgrphc_resetTransform);
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x00019DB8 File Offset: 0x00017FB8
		internal readonly void rotate(float angle)
		{
			this.NullCheck("rotate");
			method qgrphc_rotate = QGraphicsView.__N.QGrphc_rotate;
			calli(System.Void(System.IntPtr,System.Single), this.self, angle, qgrphc_rotate);
		}

		// Token: 0x06000994 RID: 2452 RVA: 0x00019DE4 File Offset: 0x00017FE4
		internal readonly void scale(float sx, float sy)
		{
			this.NullCheck("scale");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f84;
			calli(System.Void(System.IntPtr,System.Single,System.Single), this.self, sx, sy, qgrphc_f);
		}

		// Token: 0x06000995 RID: 2453 RVA: 0x00019E10 File Offset: 0x00018010
		internal readonly void shear(float sh, float sv)
		{
			this.NullCheck("shear");
			method qgrphc_shear = QGraphicsView.__N.QGrphc_shear;
			calli(System.Void(System.IntPtr,System.Single,System.Single), this.self, sh, sv, qgrphc_shear);
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x00019E3C File Offset: 0x0001803C
		internal readonly void translate(float dx, float dy)
		{
			this.NullCheck("translate");
			method qgrphc_translate = QGraphicsView.__N.QGrphc_translate;
			calli(System.Void(System.IntPtr,System.Single,System.Single), this.self, dx, dy, qgrphc_translate);
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00019E68 File Offset: 0x00018068
		internal readonly void centerOn(Vector3 xy)
		{
			this.NullCheck("centerOn");
			method qgrphc_centerOn = QGraphicsView.__N.QGrphc_centerOn;
			calli(System.Void(System.IntPtr,Vector3), this.self, xy, qgrphc_centerOn);
		}

		// Token: 0x06000998 RID: 2456 RVA: 0x00019E94 File Offset: 0x00018094
		internal readonly void ensureVisible(QRectF rect, int xmargin, int ymargin)
		{
			this.NullCheck("ensureVisible");
			method qgrphc_ensureVisible = QGraphicsView.__N.QGrphc_ensureVisible;
			calli(System.Void(System.IntPtr,QRectF,System.Int32,System.Int32), this.self, rect, xmargin, ymargin, qgrphc_ensureVisible);
		}

		// Token: 0x06000999 RID: 2457 RVA: 0x00019EC4 File Offset: 0x000180C4
		internal readonly void fitInView(QRectF rect)
		{
			this.NullCheck("fitInView");
			method qgrphc_fitInView = QGraphicsView.__N.QGrphc_fitInView;
			calli(System.Void(System.IntPtr,QRectF), this.self, rect, qgrphc_fitInView);
		}

		// Token: 0x0600099A RID: 2458 RVA: 0x00019EF0 File Offset: 0x000180F0
		internal readonly QRectF sceneRect()
		{
			this.NullCheck("sceneRect");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f85;
			return calli(QRectF(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x00019F1C File Offset: 0x0001811C
		internal readonly void setSceneRect(QRectF rect)
		{
			this.NullCheck("setSceneRect");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f86;
			calli(System.Void(System.IntPtr,QRectF), this.self, rect, qgrphc_f);
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x00019F48 File Offset: 0x00018148
		internal readonly QGraphicsScene scene()
		{
			this.NullCheck("scene");
			method qgrphc_scene = QGraphicsView.__N.QGrphc_scene;
			return calli(System.IntPtr(System.IntPtr), this.self, qgrphc_scene);
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x00019F78 File Offset: 0x00018178
		internal readonly void setScene(QGraphicsScene scene)
		{
			this.NullCheck("setScene");
			method qgrphc_setScene = QGraphicsView.__N.QGrphc_setScene;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, scene, qgrphc_setScene);
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x00019FA8 File Offset: 0x000181A8
		internal readonly ScrollbarMode horizontalScrollBarPolicy()
		{
			this.NullCheck("horizontalScrollBarPolicy");
			method qgrphc_horizontalScrollBarPolicy = QGraphicsView.__N.QGrphc_horizontalScrollBarPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qgrphc_horizontalScrollBarPolicy);
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x00019FD4 File Offset: 0x000181D4
		internal readonly void setHorizontalScrollBarPolicy(ScrollbarMode m)
		{
			this.NullCheck("setHorizontalScrollBarPolicy");
			method qgrphc_setHorizontalScrollBarPolicy = QGraphicsView.__N.QGrphc_setHorizontalScrollBarPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)m, qgrphc_setHorizontalScrollBarPolicy);
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0001A000 File Offset: 0x00018200
		internal readonly ScrollbarMode verticalScrollBarPolicy()
		{
			this.NullCheck("verticalScrollBarPolicy");
			method qgrphc_verticalScrollBarPolicy = QGraphicsView.__N.QGrphc_verticalScrollBarPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qgrphc_verticalScrollBarPolicy);
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x0001A02C File Offset: 0x0001822C
		internal readonly void setVerticalScrollBarPolicy(ScrollbarMode m)
		{
			this.NullCheck("setVerticalScrollBarPolicy");
			method qgrphc_setVerticalScrollBarPolicy = QGraphicsView.__N.QGrphc_setVerticalScrollBarPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)m, qgrphc_setVerticalScrollBarPolicy);
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0001A058 File Offset: 0x00018258
		internal readonly void setBackgroundBrush(QBrush brush)
		{
			this.NullCheck("setBackgroundBrush");
			method qgrphc_setBackgroundBrush = QGraphicsView.__N.QGrphc_setBackgroundBrush;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, brush, qgrphc_setBackgroundBrush);
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0001A088 File Offset: 0x00018288
		internal readonly GraphicsView.ViewportAnchorType transformationAnchor()
		{
			this.NullCheck("transformationAnchor");
			method qgrphc_transformationAnchor = QGraphicsView.__N.QGrphc_transformationAnchor;
			return calli(System.Int64(System.IntPtr), this.self, qgrphc_transformationAnchor);
		}

		// Token: 0x060009A4 RID: 2468 RVA: 0x0001A0B4 File Offset: 0x000182B4
		internal readonly void setTransformationAnchor(GraphicsView.ViewportAnchorType anchor)
		{
			this.NullCheck("setTransformationAnchor");
			method qgrphc_setTransformationAnchor = QGraphicsView.__N.QGrphc_setTransformationAnchor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)anchor, qgrphc_setTransformationAnchor);
		}

		// Token: 0x060009A5 RID: 2469 RVA: 0x0001A0E0 File Offset: 0x000182E0
		internal readonly Vector3 mapToScene(Vector3 pos)
		{
			this.NullCheck("mapToScene");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f87;
			return calli(Vector3(System.IntPtr,Vector3), this.self, pos, qgrphc_f);
		}

		// Token: 0x060009A6 RID: 2470 RVA: 0x0001A10C File Offset: 0x0001830C
		internal readonly Vector3 mapFromScene(Vector3 pos)
		{
			this.NullCheck("mapFromScene");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f88;
			return calli(Vector3(System.IntPtr,Vector3), this.self, pos, qgrphc_f);
		}

		// Token: 0x060009A7 RID: 2471 RVA: 0x0001A138 File Offset: 0x00018338
		internal readonly void setRenderHint(RenderHints hint, bool on)
		{
			this.NullCheck("setRenderHint");
			method qgrphc_setRenderHint = QGraphicsView.__N.QGrphc_setRenderHint;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)hint, on ? 1 : 0, qgrphc_setRenderHint);
		}

		// Token: 0x060009A8 RID: 2472 RVA: 0x0001A16C File Offset: 0x0001836C
		internal readonly QGraphicsItem itemAt(Vector3 pos)
		{
			this.NullCheck("itemAt");
			method qgrphc_itemAt = QGraphicsView.__N.QGrphc_itemAt;
			return calli(System.IntPtr(System.IntPtr,Vector3), this.self, pos, qgrphc_itemAt);
		}

		// Token: 0x060009A9 RID: 2473 RVA: 0x0001A19C File Offset: 0x0001839C
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qgrphc_isTopLevel = QGraphicsView.__N.QGrphc_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isTopLevel) > 0;
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x0001A1CC File Offset: 0x000183CC
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qgrphc_isWindow = QGraphicsView.__N.QGrphc_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isWindow) > 0;
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x0001A1FC File Offset: 0x000183FC
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qgrphc_isModal = QGraphicsView.__N.QGrphc_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isModal) > 0;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0001A22C File Offset: 0x0001842C
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qgrphc_setStyleSheet = QGraphicsView.__N.QGrphc_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qgrphc_setStyleSheet);
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x0001A25C File Offset: 0x0001845C
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qgrphc_windowTitle = QGraphicsView.__N.QGrphc_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qgrphc_windowTitle));
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x0001A28C File Offset: 0x0001848C
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qgrphc_setWindowTitle = QGraphicsView.__N.QGrphc_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qgrphc_setWindowTitle);
		}

		// Token: 0x060009AF RID: 2479 RVA: 0x0001A2BC File Offset: 0x000184BC
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qgrphc_setWindowFlags = QGraphicsView.__N.QGrphc_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qgrphc_setWindowFlags);
		}

		// Token: 0x060009B0 RID: 2480 RVA: 0x0001A2E8 File Offset: 0x000184E8
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qgrphc_windowFlags = QGraphicsView.__N.QGrphc_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qgrphc_windowFlags);
		}

		// Token: 0x060009B1 RID: 2481 RVA: 0x0001A314 File Offset: 0x00018514
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f89;
			return calli(Vector3(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x060009B2 RID: 2482 RVA: 0x0001A340 File Offset: 0x00018540
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f90;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qgrphc_f);
		}

		// Token: 0x060009B3 RID: 2483 RVA: 0x0001A36C File Offset: 0x0001856C
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f91;
			return calli(Vector3(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x060009B4 RID: 2484 RVA: 0x0001A398 File Offset: 0x00018598
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f92;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qgrphc_f);
		}

		// Token: 0x060009B5 RID: 2485 RVA: 0x0001A3C4 File Offset: 0x000185C4
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f93;
			return calli(Vector3(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x060009B6 RID: 2486 RVA: 0x0001A3F0 File Offset: 0x000185F0
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f94;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qgrphc_f);
		}

		// Token: 0x060009B7 RID: 2487 RVA: 0x0001A41C File Offset: 0x0001861C
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f95;
			return calli(Vector3(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x060009B8 RID: 2488 RVA: 0x0001A448 File Offset: 0x00018648
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qgrphc_move = QGraphicsView.__N.QGrphc_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qgrphc_move);
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x0001A474 File Offset: 0x00018674
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f96;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0001A4A4 File Offset: 0x000186A4
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f97;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qgrphc_f);
		}

		// Token: 0x060009BB RID: 2491 RVA: 0x0001A4D8 File Offset: 0x000186D8
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f98;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qgrphc_f);
		}

		// Token: 0x060009BC RID: 2492 RVA: 0x0001A50C File Offset: 0x0001870C
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qgrphc_setHidden = QGraphicsView.__N.QGrphc_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qgrphc_setHidden);
		}

		// Token: 0x060009BD RID: 2493 RVA: 0x0001A540 File Offset: 0x00018740
		internal readonly void show()
		{
			this.NullCheck("show");
			method qgrphc_show = QGraphicsView.__N.QGrphc_show;
			calli(System.Void(System.IntPtr), this.self, qgrphc_show);
		}

		// Token: 0x060009BE RID: 2494 RVA: 0x0001A56C File Offset: 0x0001876C
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qgrphc_hide = QGraphicsView.__N.QGrphc_hide;
			calli(System.Void(System.IntPtr), this.self, qgrphc_hide);
		}

		// Token: 0x060009BF RID: 2495 RVA: 0x0001A598 File Offset: 0x00018798
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qgrphc_showMinimized = QGraphicsView.__N.QGrphc_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qgrphc_showMinimized);
		}

		// Token: 0x060009C0 RID: 2496 RVA: 0x0001A5C4 File Offset: 0x000187C4
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qgrphc_showMaximized = QGraphicsView.__N.QGrphc_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qgrphc_showMaximized);
		}

		// Token: 0x060009C1 RID: 2497 RVA: 0x0001A5F0 File Offset: 0x000187F0
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qgrphc_showFullScreen = QGraphicsView.__N.QGrphc_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qgrphc_showFullScreen);
		}

		// Token: 0x060009C2 RID: 2498 RVA: 0x0001A61C File Offset: 0x0001881C
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qgrphc_showNormal = QGraphicsView.__N.QGrphc_showNormal;
			calli(System.Void(System.IntPtr), this.self, qgrphc_showNormal);
		}

		// Token: 0x060009C3 RID: 2499 RVA: 0x0001A648 File Offset: 0x00018848
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qgrphc_close = QGraphicsView.__N.QGrphc_close;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_close) > 0;
		}

		// Token: 0x060009C4 RID: 2500 RVA: 0x0001A678 File Offset: 0x00018878
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qgrphc_raise = QGraphicsView.__N.QGrphc_raise;
			calli(System.Void(System.IntPtr), this.self, qgrphc_raise);
		}

		// Token: 0x060009C5 RID: 2501 RVA: 0x0001A6A4 File Offset: 0x000188A4
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qgrphc_lower = QGraphicsView.__N.QGrphc_lower;
			calli(System.Void(System.IntPtr), this.self, qgrphc_lower);
		}

		// Token: 0x060009C6 RID: 2502 RVA: 0x0001A6D0 File Offset: 0x000188D0
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f99;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x060009C7 RID: 2503 RVA: 0x0001A700 File Offset: 0x00018900
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f100;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qgrphc_f);
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0001A734 File Offset: 0x00018934
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f101;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qgrphc_f) > 0;
		}

		// Token: 0x060009C9 RID: 2505 RVA: 0x0001A764 File Offset: 0x00018964
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f102;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_f) > 0;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x0001A794 File Offset: 0x00018994
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f103;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qgrphc_f);
		}

		// Token: 0x060009CB RID: 2507 RVA: 0x0001A7C8 File Offset: 0x000189C8
		internal readonly void update()
		{
			this.NullCheck("update");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f104;
			calli(System.Void(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x060009CC RID: 2508 RVA: 0x0001A7F4 File Offset: 0x000189F4
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qgrphc_repaint = QGraphicsView.__N.QGrphc_repaint;
			calli(System.Void(System.IntPtr), this.self, qgrphc_repaint);
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x0001A820 File Offset: 0x00018A20
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f105;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qgrphc_f);
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x0001A84C File Offset: 0x00018A4C
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qgrphc_f = QGraphicsView.__N.QGrphc_f106;
			calli(System.Void(System.IntPtr), this.self, qgrphc_f);
		}

		// Token: 0x060009CF RID: 2511 RVA: 0x0001A878 File Offset: 0x00018A78
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qgrphc_setWindowIcon = QGraphicsView.__N.QGrphc_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qgrphc_setWindowIcon);
		}

		// Token: 0x060009D0 RID: 2512 RVA: 0x0001A8A8 File Offset: 0x00018AA8
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qgrphc_setWindowIconText = QGraphicsView.__N.QGrphc_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qgrphc_setWindowIconText);
		}

		// Token: 0x060009D1 RID: 2513 RVA: 0x0001A8D8 File Offset: 0x00018AD8
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qgrphc_setWindowOpacity = QGraphicsView.__N.QGrphc_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qgrphc_setWindowOpacity);
		}

		// Token: 0x060009D2 RID: 2514 RVA: 0x0001A904 File Offset: 0x00018B04
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qgrphc_windowOpacity = QGraphicsView.__N.QGrphc_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_windowOpacity);
		}

		// Token: 0x060009D3 RID: 2515 RVA: 0x0001A930 File Offset: 0x00018B30
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qgrphc_isMinimized = QGraphicsView.__N.QGrphc_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isMinimized) > 0;
		}

		// Token: 0x060009D4 RID: 2516 RVA: 0x0001A960 File Offset: 0x00018B60
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qgrphc_isMaximized = QGraphicsView.__N.QGrphc_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isMaximized) > 0;
		}

		// Token: 0x060009D5 RID: 2517 RVA: 0x0001A990 File Offset: 0x00018B90
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qgrphc_isFullScreen = QGraphicsView.__N.QGrphc_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isFullScreen) > 0;
		}

		// Token: 0x060009D6 RID: 2518 RVA: 0x0001A9C0 File Offset: 0x00018BC0
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qgrphc_setMouseTracking = QGraphicsView.__N.QGrphc_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qgrphc_setMouseTracking);
		}

		// Token: 0x060009D7 RID: 2519 RVA: 0x0001A9F4 File Offset: 0x00018BF4
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qgrphc_hasMouseTracking = QGraphicsView.__N.QGrphc_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_hasMouseTracking) > 0;
		}

		// Token: 0x060009D8 RID: 2520 RVA: 0x0001AA24 File Offset: 0x00018C24
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qgrphc_underMouse = QGraphicsView.__N.QGrphc_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_underMouse) > 0;
		}

		// Token: 0x060009D9 RID: 2521 RVA: 0x0001AA54 File Offset: 0x00018C54
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qgrphc_mapToGlobal = QGraphicsView.__N.QGrphc_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qgrphc_mapToGlobal);
		}

		// Token: 0x060009DA RID: 2522 RVA: 0x0001AA80 File Offset: 0x00018C80
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qgrphc_mapFromGlobal = QGraphicsView.__N.QGrphc_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qgrphc_mapFromGlobal);
		}

		// Token: 0x060009DB RID: 2523 RVA: 0x0001AAAC File Offset: 0x00018CAC
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qgrphc_hasFocus = QGraphicsView.__N.QGrphc_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_hasFocus) > 0;
		}

		// Token: 0x060009DC RID: 2524 RVA: 0x0001AADC File Offset: 0x00018CDC
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qgrphc_focusPolicy = QGraphicsView.__N.QGrphc_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qgrphc_focusPolicy);
		}

		// Token: 0x060009DD RID: 2525 RVA: 0x0001AB08 File Offset: 0x00018D08
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qgrphc_setFocusPolicy = QGraphicsView.__N.QGrphc_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qgrphc_setFocusPolicy);
		}

		// Token: 0x060009DE RID: 2526 RVA: 0x0001AB34 File Offset: 0x00018D34
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qgrphc_setFocusProxy = QGraphicsView.__N.QGrphc_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qgrphc_setFocusProxy);
		}

		// Token: 0x060009DF RID: 2527 RVA: 0x0001AB64 File Offset: 0x00018D64
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qgrphc_isActiveWindow = QGraphicsView.__N.QGrphc_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_isActiveWindow) > 0;
		}

		// Token: 0x060009E0 RID: 2528 RVA: 0x0001AB94 File Offset: 0x00018D94
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qgrphc_updatesEnabled = QGraphicsView.__N.QGrphc_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_updatesEnabled) > 0;
		}

		// Token: 0x060009E1 RID: 2529 RVA: 0x0001ABC4 File Offset: 0x00018DC4
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qgrphc_setUpdatesEnabled = QGraphicsView.__N.QGrphc_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qgrphc_setUpdatesEnabled);
		}

		// Token: 0x060009E2 RID: 2530 RVA: 0x0001ABF8 File Offset: 0x00018DF8
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qgrphc_setFocus = QGraphicsView.__N.QGrphc_setFocus;
			calli(System.Void(System.IntPtr), this.self, qgrphc_setFocus);
		}

		// Token: 0x060009E3 RID: 2531 RVA: 0x0001AC24 File Offset: 0x00018E24
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qgrphc_activateWindow = QGraphicsView.__N.QGrphc_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qgrphc_activateWindow);
		}

		// Token: 0x060009E4 RID: 2532 RVA: 0x0001AC50 File Offset: 0x00018E50
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qgrphc_clearFocus = QGraphicsView.__N.QGrphc_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qgrphc_clearFocus);
		}

		// Token: 0x060009E5 RID: 2533 RVA: 0x0001AC7C File Offset: 0x00018E7C
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qgrphc_setSizePolicy = QGraphicsView.__N.QGrphc_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qgrphc_setSizePolicy);
		}

		// Token: 0x060009E6 RID: 2534 RVA: 0x0001ACAC File Offset: 0x00018EAC
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qgrphc_devicePixelRatioF = QGraphicsView.__N.QGrphc_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qgrphc_devicePixelRatioF);
		}

		// Token: 0x060009E7 RID: 2535 RVA: 0x0001ACD8 File Offset: 0x00018ED8
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qgrphc_saveGeometry = QGraphicsView.__N.QGrphc_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qgrphc_saveGeometry));
		}

		// Token: 0x060009E8 RID: 2536 RVA: 0x0001AD08 File Offset: 0x00018F08
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qgrphc_restoreGeometry = QGraphicsView.__N.QGrphc_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qgrphc_restoreGeometry) > 0;
		}

		// Token: 0x060009E9 RID: 2537 RVA: 0x0001AD3C File Offset: 0x00018F3C
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qgrphc_addAction = QGraphicsView.__N.QGrphc_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qgrphc_addAction);
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0001AD6C File Offset: 0x00018F6C
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qgrphc_removeAction = QGraphicsView.__N.QGrphc_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qgrphc_removeAction);
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x0001AD9C File Offset: 0x00018F9C
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qgrphc_setParent = QGraphicsView.__N.QGrphc_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qgrphc_setParent);
		}

		// Token: 0x060009EC RID: 2540 RVA: 0x0001ADCC File Offset: 0x00018FCC
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qgrphc_parentWidget = QGraphicsView.__N.QGrphc_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qgrphc_parentWidget);
		}

		// Token: 0x060009ED RID: 2541 RVA: 0x0001ADFC File Offset: 0x00018FFC
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qgrphc_AddClassName = QGraphicsView.__N.QGrphc_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qgrphc_AddClassName);
		}

		// Token: 0x060009EE RID: 2542 RVA: 0x0001AE2C File Offset: 0x0001902C
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qgrphc_Polish = QGraphicsView.__N.QGrphc_Polish;
			calli(System.Void(System.IntPtr), this.self, qgrphc_Polish);
		}

		// Token: 0x060009EF RID: 2543 RVA: 0x0001AE58 File Offset: 0x00019058
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qgrphc_toolTip = QGraphicsView.__N.QGrphc_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qgrphc_toolTip));
		}

		// Token: 0x060009F0 RID: 2544 RVA: 0x0001AE88 File Offset: 0x00019088
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qgrphc_setToolTip = QGraphicsView.__N.QGrphc_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qgrphc_setToolTip);
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x0001AEB8 File Offset: 0x000190B8
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qgrphc_statusTip = QGraphicsView.__N.QGrphc_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qgrphc_statusTip));
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x0001AEE8 File Offset: 0x000190E8
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qgrphc_setStatusTip = QGraphicsView.__N.QGrphc_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qgrphc_setStatusTip);
		}

		// Token: 0x060009F3 RID: 2547 RVA: 0x0001AF18 File Offset: 0x00019118
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qgrphc_toolTipDuration = QGraphicsView.__N.QGrphc_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_toolTipDuration);
		}

		// Token: 0x060009F4 RID: 2548 RVA: 0x0001AF44 File Offset: 0x00019144
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qgrphc_setToolTipDuration = QGraphicsView.__N.QGrphc_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qgrphc_setToolTipDuration);
		}

		// Token: 0x060009F5 RID: 2549 RVA: 0x0001AF70 File Offset: 0x00019170
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qgrphc_autoFillBackground = QGraphicsView.__N.QGrphc_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qgrphc_autoFillBackground) > 0;
		}

		// Token: 0x060009F6 RID: 2550 RVA: 0x0001AFA0 File Offset: 0x000191A0
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qgrphc_setAutoFillBackground = QGraphicsView.__N.QGrphc_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qgrphc_setAutoFillBackground);
		}

		// Token: 0x04000056 RID: 86
		internal IntPtr self;

		// Token: 0x02000117 RID: 279
		internal static class __N
		{
			// Token: 0x04000BC0 RID: 3008
			internal static method From_QFrame_To_QGraphicsView;

			// Token: 0x04000BC1 RID: 3009
			internal static method To_QFrame_From_QGraphicsView;

			// Token: 0x04000BC2 RID: 3010
			internal static method From_QWidget_To_QGraphicsView;

			// Token: 0x04000BC3 RID: 3011
			internal static method To_QWidget_From_QGraphicsView;

			// Token: 0x04000BC4 RID: 3012
			internal static method From_QObject_To_QGraphicsView;

			// Token: 0x04000BC5 RID: 3013
			internal static method To_QObject_From_QGraphicsView;

			// Token: 0x04000BC6 RID: 3014
			internal static method QGrphc_isInteractive;

			// Token: 0x04000BC7 RID: 3015
			internal static method QGrphc_setInteractive;

			// Token: 0x04000BC8 RID: 3016
			internal static method QGrphc_resetTransform;

			// Token: 0x04000BC9 RID: 3017
			internal static method QGrphc_rotate;

			// Token: 0x04000BCA RID: 3018
			internal static method QGrphc_f84;

			// Token: 0x04000BCB RID: 3019
			internal static method QGrphc_shear;

			// Token: 0x04000BCC RID: 3020
			internal static method QGrphc_translate;

			// Token: 0x04000BCD RID: 3021
			internal static method QGrphc_centerOn;

			// Token: 0x04000BCE RID: 3022
			internal static method QGrphc_ensureVisible;

			// Token: 0x04000BCF RID: 3023
			internal static method QGrphc_fitInView;

			// Token: 0x04000BD0 RID: 3024
			internal static method QGrphc_f85;

			// Token: 0x04000BD1 RID: 3025
			internal static method QGrphc_f86;

			// Token: 0x04000BD2 RID: 3026
			internal static method QGrphc_scene;

			// Token: 0x04000BD3 RID: 3027
			internal static method QGrphc_setScene;

			// Token: 0x04000BD4 RID: 3028
			internal static method QGrphc_horizontalScrollBarPolicy;

			// Token: 0x04000BD5 RID: 3029
			internal static method QGrphc_setHorizontalScrollBarPolicy;

			// Token: 0x04000BD6 RID: 3030
			internal static method QGrphc_verticalScrollBarPolicy;

			// Token: 0x04000BD7 RID: 3031
			internal static method QGrphc_setVerticalScrollBarPolicy;

			// Token: 0x04000BD8 RID: 3032
			internal static method QGrphc_setBackgroundBrush;

			// Token: 0x04000BD9 RID: 3033
			internal static method QGrphc_transformationAnchor;

			// Token: 0x04000BDA RID: 3034
			internal static method QGrphc_setTransformationAnchor;

			// Token: 0x04000BDB RID: 3035
			internal static method QGrphc_f87;

			// Token: 0x04000BDC RID: 3036
			internal static method QGrphc_f88;

			// Token: 0x04000BDD RID: 3037
			internal static method QGrphc_setRenderHint;

			// Token: 0x04000BDE RID: 3038
			internal static method QGrphc_itemAt;

			// Token: 0x04000BDF RID: 3039
			internal static method QGrphc_isTopLevel;

			// Token: 0x04000BE0 RID: 3040
			internal static method QGrphc_isWindow;

			// Token: 0x04000BE1 RID: 3041
			internal static method QGrphc_isModal;

			// Token: 0x04000BE2 RID: 3042
			internal static method QGrphc_setStyleSheet;

			// Token: 0x04000BE3 RID: 3043
			internal static method QGrphc_windowTitle;

			// Token: 0x04000BE4 RID: 3044
			internal static method QGrphc_setWindowTitle;

			// Token: 0x04000BE5 RID: 3045
			internal static method QGrphc_setWindowFlags;

			// Token: 0x04000BE6 RID: 3046
			internal static method QGrphc_windowFlags;

			// Token: 0x04000BE7 RID: 3047
			internal static method QGrphc_f89;

			// Token: 0x04000BE8 RID: 3048
			internal static method QGrphc_f90;

			// Token: 0x04000BE9 RID: 3049
			internal static method QGrphc_f91;

			// Token: 0x04000BEA RID: 3050
			internal static method QGrphc_f92;

			// Token: 0x04000BEB RID: 3051
			internal static method QGrphc_f93;

			// Token: 0x04000BEC RID: 3052
			internal static method QGrphc_f94;

			// Token: 0x04000BED RID: 3053
			internal static method QGrphc_f95;

			// Token: 0x04000BEE RID: 3054
			internal static method QGrphc_move;

			// Token: 0x04000BEF RID: 3055
			internal static method QGrphc_f96;

			// Token: 0x04000BF0 RID: 3056
			internal static method QGrphc_f97;

			// Token: 0x04000BF1 RID: 3057
			internal static method QGrphc_f98;

			// Token: 0x04000BF2 RID: 3058
			internal static method QGrphc_setHidden;

			// Token: 0x04000BF3 RID: 3059
			internal static method QGrphc_show;

			// Token: 0x04000BF4 RID: 3060
			internal static method QGrphc_hide;

			// Token: 0x04000BF5 RID: 3061
			internal static method QGrphc_showMinimized;

			// Token: 0x04000BF6 RID: 3062
			internal static method QGrphc_showMaximized;

			// Token: 0x04000BF7 RID: 3063
			internal static method QGrphc_showFullScreen;

			// Token: 0x04000BF8 RID: 3064
			internal static method QGrphc_showNormal;

			// Token: 0x04000BF9 RID: 3065
			internal static method QGrphc_close;

			// Token: 0x04000BFA RID: 3066
			internal static method QGrphc_raise;

			// Token: 0x04000BFB RID: 3067
			internal static method QGrphc_lower;

			// Token: 0x04000BFC RID: 3068
			internal static method QGrphc_f99;

			// Token: 0x04000BFD RID: 3069
			internal static method QGrphc_f100;

			// Token: 0x04000BFE RID: 3070
			internal static method QGrphc_f101;

			// Token: 0x04000BFF RID: 3071
			internal static method QGrphc_f102;

			// Token: 0x04000C00 RID: 3072
			internal static method QGrphc_f103;

			// Token: 0x04000C01 RID: 3073
			internal static method QGrphc_f104;

			// Token: 0x04000C02 RID: 3074
			internal static method QGrphc_repaint;

			// Token: 0x04000C03 RID: 3075
			internal static method QGrphc_f105;

			// Token: 0x04000C04 RID: 3076
			internal static method QGrphc_f106;

			// Token: 0x04000C05 RID: 3077
			internal static method QGrphc_setWindowIcon;

			// Token: 0x04000C06 RID: 3078
			internal static method QGrphc_setWindowIconText;

			// Token: 0x04000C07 RID: 3079
			internal static method QGrphc_setWindowOpacity;

			// Token: 0x04000C08 RID: 3080
			internal static method QGrphc_windowOpacity;

			// Token: 0x04000C09 RID: 3081
			internal static method QGrphc_isMinimized;

			// Token: 0x04000C0A RID: 3082
			internal static method QGrphc_isMaximized;

			// Token: 0x04000C0B RID: 3083
			internal static method QGrphc_isFullScreen;

			// Token: 0x04000C0C RID: 3084
			internal static method QGrphc_setMouseTracking;

			// Token: 0x04000C0D RID: 3085
			internal static method QGrphc_hasMouseTracking;

			// Token: 0x04000C0E RID: 3086
			internal static method QGrphc_underMouse;

			// Token: 0x04000C0F RID: 3087
			internal static method QGrphc_mapToGlobal;

			// Token: 0x04000C10 RID: 3088
			internal static method QGrphc_mapFromGlobal;

			// Token: 0x04000C11 RID: 3089
			internal static method QGrphc_hasFocus;

			// Token: 0x04000C12 RID: 3090
			internal static method QGrphc_focusPolicy;

			// Token: 0x04000C13 RID: 3091
			internal static method QGrphc_setFocusPolicy;

			// Token: 0x04000C14 RID: 3092
			internal static method QGrphc_setFocusProxy;

			// Token: 0x04000C15 RID: 3093
			internal static method QGrphc_isActiveWindow;

			// Token: 0x04000C16 RID: 3094
			internal static method QGrphc_updatesEnabled;

			// Token: 0x04000C17 RID: 3095
			internal static method QGrphc_setUpdatesEnabled;

			// Token: 0x04000C18 RID: 3096
			internal static method QGrphc_setFocus;

			// Token: 0x04000C19 RID: 3097
			internal static method QGrphc_activateWindow;

			// Token: 0x04000C1A RID: 3098
			internal static method QGrphc_clearFocus;

			// Token: 0x04000C1B RID: 3099
			internal static method QGrphc_setSizePolicy;

			// Token: 0x04000C1C RID: 3100
			internal static method QGrphc_devicePixelRatioF;

			// Token: 0x04000C1D RID: 3101
			internal static method QGrphc_saveGeometry;

			// Token: 0x04000C1E RID: 3102
			internal static method QGrphc_restoreGeometry;

			// Token: 0x04000C1F RID: 3103
			internal static method QGrphc_addAction;

			// Token: 0x04000C20 RID: 3104
			internal static method QGrphc_removeAction;

			// Token: 0x04000C21 RID: 3105
			internal static method QGrphc_setParent;

			// Token: 0x04000C22 RID: 3106
			internal static method QGrphc_parentWidget;

			// Token: 0x04000C23 RID: 3107
			internal static method QGrphc_AddClassName;

			// Token: 0x04000C24 RID: 3108
			internal static method QGrphc_Polish;

			// Token: 0x04000C25 RID: 3109
			internal static method QGrphc_toolTip;

			// Token: 0x04000C26 RID: 3110
			internal static method QGrphc_setToolTip;

			// Token: 0x04000C27 RID: 3111
			internal static method QGrphc_statusTip;

			// Token: 0x04000C28 RID: 3112
			internal static method QGrphc_setStatusTip;

			// Token: 0x04000C29 RID: 3113
			internal static method QGrphc_toolTipDuration;

			// Token: 0x04000C2A RID: 3114
			internal static method QGrphc_setToolTipDuration;

			// Token: 0x04000C2B RID: 3115
			internal static method QGrphc_autoFillBackground;

			// Token: 0x04000C2C RID: 3116
			internal static method QGrphc_setAutoFillBackground;
		}
	}
}
