using System;
using System.Collections.Generic;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000B1 RID: 177
	public abstract class GraphicsItem : IValid
	{
		// Token: 0x060014F0 RID: 5360 RVA: 0x00056B0C File Offset: 0x00054D0C
		public GraphicsItem(GraphicsItem parent = null)
		{
			InteropSystem.Alloc<GraphicsItem>(this);
			CManagedGraphicsItem ptr = CManagedGraphicsItem.Create((parent != null) ? parent._graphicsitem : IntPtr.Zero, this);
			this.NativeInit(ptr);
			this.Parent = parent;
			this.SetFlag(GraphicsItemFlag.ItemNegativeZStacksBehindParent, true);
			this.SetFlag(GraphicsItemFlag.ItemSendsGeometryChanges, true);
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x060014F2 RID: 5362 RVA: 0x00056BDC File Offset: 0x00054DDC
		// (set) Token: 0x060014F1 RID: 5361 RVA: 0x00056B74 File Offset: 0x00054D74
		public GraphicsItem Parent
		{
			get
			{
				return this._parent;
			}
			set
			{
				if (this._parent == value)
				{
					return;
				}
				GraphicsItem parent = this._parent;
				if (parent != null)
				{
					parent.RemoveChild(this);
				}
				this._parent = value;
				GraphicsItem parent2 = this._parent;
				if (parent2 != null)
				{
					parent2.AddChild(this);
				}
				GraphicsItem parent3 = this._parent;
				this._graphicsitem.setParentItem((parent3 != null) ? parent3._graphicsitem : IntPtr.Zero);
			}
		}

		// Token: 0x060014F3 RID: 5363 RVA: 0x00056BE4 File Offset: 0x00054DE4
		public void Destroy()
		{
			if (!this._graphicsitem.IsValid)
			{
				return;
			}
			if (this.Scene != null)
			{
				this.Scene.RemoveInternal(this);
				this.Scene = null;
			}
			this.Parent = null;
			this.NativeShutdown();
		}

		// Token: 0x060014F4 RID: 5364 RVA: 0x00056C1C File Offset: 0x00054E1C
		protected void AddChild(GraphicsItem i)
		{
			if (this.Children == null)
			{
				this.Children = new List<GraphicsItem>();
			}
			this.Children.Add(i);
		}

		// Token: 0x060014F5 RID: 5365 RVA: 0x00056C3D File Offset: 0x00054E3D
		protected void RemoveChild(GraphicsItem i)
		{
			List<GraphicsItem> children = this.Children;
			if (children == null)
			{
				return;
			}
			children.Remove(i);
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060014F6 RID: 5366 RVA: 0x00056C51 File Offset: 0x00054E51
		bool IValid.IsValid
		{
			get
			{
				return this.IsValid;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060014F7 RID: 5367 RVA: 0x00056C59 File Offset: 0x00054E59
		public bool IsValid
		{
			get
			{
				return this._graphicsitem.IsValid;
			}
		}

		// Token: 0x060014F8 RID: 5368 RVA: 0x00056C66 File Offset: 0x00054E66
		internal virtual void NativeInit(QGraphicsItem ptr)
		{
			this._graphicsitem = ptr;
			GraphicsItem.AllByAddress[this._graphicsitem] = this;
		}

		// Token: 0x060014F9 RID: 5369 RVA: 0x00056C88 File Offset: 0x00054E88
		internal virtual void NativeShutdown()
		{
			InteropSystem.Free<GraphicsItem>(this);
			GraphicsItem.AllByAddress.Remove(this._graphicsitem);
			this._graphicsitem = default(QGraphicsItem);
			if (this.Children == null)
			{
				return;
			}
			foreach (GraphicsItem graphicsItem in this.Children)
			{
				graphicsItem.NativeShutdown();
			}
			this.Children.Clear();
			this.Children = null;
		}

		// Token: 0x060014FA RID: 5370 RVA: 0x00056D1C File Offset: 0x00054F1C
		internal static GraphicsItem Get(QGraphicsItem item)
		{
			GraphicsItem found;
			if (GraphicsItem.AllByAddress.TryGetValue(item, out found))
			{
				return found;
			}
			return null;
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060014FB RID: 5371 RVA: 0x00056D40 File Offset: 0x00054F40
		// (set) Token: 0x060014FC RID: 5372 RVA: 0x00056D52 File Offset: 0x00054F52
		public Vector2 Position
		{
			get
			{
				return this._graphicsitem.pos();
			}
			set
			{
				this._graphicsitem.setPos(value);
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060014FD RID: 5373 RVA: 0x00056D65 File Offset: 0x00054F65
		// (set) Token: 0x060014FE RID: 5374 RVA: 0x00056D72 File Offset: 0x00054F72
		public float Rotation
		{
			get
			{
				return this._graphicsitem.rotation();
			}
			set
			{
				this._graphicsitem.setRotation(value);
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060014FF RID: 5375 RVA: 0x00056D80 File Offset: 0x00054F80
		// (set) Token: 0x06001500 RID: 5376 RVA: 0x00056D8D File Offset: 0x00054F8D
		public float Scale
		{
			get
			{
				return this._graphicsitem.scale();
			}
			set
			{
				this._graphicsitem.setScale(value);
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06001501 RID: 5377 RVA: 0x00056D9B File Offset: 0x00054F9B
		// (set) Token: 0x06001502 RID: 5378 RVA: 0x00056DA4 File Offset: 0x00054FA4
		public bool Movable
		{
			get
			{
				return this.Has(GraphicsItemFlag.ItemIsMovable);
			}
			set
			{
				this.SetFlag(GraphicsItemFlag.ItemIsMovable, value);
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06001503 RID: 5379 RVA: 0x00056DAE File Offset: 0x00054FAE
		// (set) Token: 0x06001504 RID: 5380 RVA: 0x00056DB7 File Offset: 0x00054FB7
		public bool Selectable
		{
			get
			{
				return this.Has(GraphicsItemFlag.ItemIsSelectable);
			}
			set
			{
				this.SetFlag(GraphicsItemFlag.ItemIsSelectable, value);
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06001505 RID: 5381 RVA: 0x00056DC1 File Offset: 0x00054FC1
		// (set) Token: 0x06001506 RID: 5382 RVA: 0x00056DCA File Offset: 0x00054FCA
		public bool Focusable
		{
			get
			{
				return this.Has(GraphicsItemFlag.ItemIsFocusable);
			}
			set
			{
				this.SetFlag(GraphicsItemFlag.ItemIsFocusable, value);
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06001507 RID: 5383 RVA: 0x00056DD4 File Offset: 0x00054FD4
		// (set) Token: 0x06001508 RID: 5384 RVA: 0x00056DE1 File Offset: 0x00054FE1
		public bool HoverEvents
		{
			get
			{
				return this._graphicsitem.acceptHoverEvents();
			}
			set
			{
				this._graphicsitem.setAcceptHoverEvents(value);
			}
		}

		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06001509 RID: 5385 RVA: 0x00056DEF File Offset: 0x00054FEF
		// (set) Token: 0x0600150A RID: 5386 RVA: 0x00056DFC File Offset: 0x00054FFC
		public float ZIndex
		{
			get
			{
				return this._graphicsitem.zValue();
			}
			set
			{
				this._graphicsitem.setZValue(value);
			}
		}

		// Token: 0x0600150B RID: 5387 RVA: 0x00056E0A File Offset: 0x0005500A
		private bool Has(GraphicsItemFlag f)
		{
			return (this._graphicsitem.flags() & f) == f;
		}

		// Token: 0x0600150C RID: 5388 RVA: 0x00056E1C File Offset: 0x0005501C
		private void SetFlag(GraphicsItemFlag f, bool b)
		{
			this._graphicsitem.setFlag(f, b);
		}

		// Token: 0x0600150D RID: 5389 RVA: 0x00056E2C File Offset: 0x0005502C
		internal void InternalPaint(QPainter painter, int state)
		{
			Paint.Start(painter, (StateFlag)state);
			try
			{
				this.OnPaint();
			}
			finally
			{
				Paint.Finished();
			}
		}

		// Token: 0x0600150E RID: 5390 RVA: 0x00056E60 File Offset: 0x00055060
		protected virtual void OnPaint()
		{
		}

		// Token: 0x0600150F RID: 5391 RVA: 0x00056E62 File Offset: 0x00055062
		internal Vector2 InternalGetSize()
		{
			return this.Size;
		}

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06001510 RID: 5392 RVA: 0x00056E6A File Offset: 0x0005506A
		// (set) Token: 0x06001511 RID: 5393 RVA: 0x00056E72 File Offset: 0x00055072
		public virtual Vector2 Size { get; set; }

		// Token: 0x06001512 RID: 5394 RVA: 0x00056E7C File Offset: 0x0005507C
		internal void InternalMouseReleaseEvent(QGraphicsSceneMouseEvent e)
		{
			this.OnMouseReleased(new GraphicsMouseEvent
			{
				ptr = e
			});
		}

		// Token: 0x06001513 RID: 5395 RVA: 0x00056EA0 File Offset: 0x000550A0
		protected virtual void OnMouseReleased(GraphicsMouseEvent e)
		{
		}

		// Token: 0x06001514 RID: 5396 RVA: 0x00056EA4 File Offset: 0x000550A4
		internal void InternalMousePressEvent(QGraphicsSceneMouseEvent e)
		{
			this.OnMousePressed(new GraphicsMouseEvent
			{
				ptr = e
			});
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x00056EC8 File Offset: 0x000550C8
		protected virtual void OnMousePressed(GraphicsMouseEvent e)
		{
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x00056ECC File Offset: 0x000550CC
		internal void InternalMouseMoveEvent(QGraphicsSceneMouseEvent e)
		{
			this.OnMouseMove(new GraphicsMouseEvent
			{
				ptr = e
			});
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x00056EF0 File Offset: 0x000550F0
		protected virtual void OnMouseMove(GraphicsMouseEvent e)
		{
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x00056EF2 File Offset: 0x000550F2
		internal void InternalHoverEnterEvent(QGraphicsSceneHoverEvent e)
		{
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x00056EF4 File Offset: 0x000550F4
		internal void InternalHoverMoveEvent(QGraphicsSceneHoverEvent e)
		{
		}

		// Token: 0x0600151A RID: 5402 RVA: 0x00056EF6 File Offset: 0x000550F6
		internal void InternalHoverLeaveEvent(QGraphicsSceneHoverEvent e)
		{
		}

		// Token: 0x0600151B RID: 5403 RVA: 0x00056EF8 File Offset: 0x000550F8
		public void Update()
		{
			this._graphicsitem.update();
		}

		// Token: 0x0600151C RID: 5404 RVA: 0x00056F05 File Offset: 0x00055105
		public Vector2 ToScene(Vector2 pos)
		{
			return this._graphicsitem.mapToScene(pos);
		}

		// Token: 0x0600151D RID: 5405 RVA: 0x00056F1D File Offset: 0x0005511D
		public Vector2 FromScene(Vector2 pos)
		{
			return this._graphicsitem.mapFromScene(pos);
		}

		// Token: 0x0600151E RID: 5406 RVA: 0x00056F35 File Offset: 0x00055135
		public Vector2 ToParent(Vector2 pos)
		{
			return this._graphicsitem.mapToParent(pos);
		}

		// Token: 0x0600151F RID: 5407 RVA: 0x00056F4D File Offset: 0x0005514D
		public Vector2 FromParent(Vector2 pos)
		{
			return this._graphicsitem.mapFromParent(pos);
		}

		// Token: 0x06001520 RID: 5408 RVA: 0x00056F65 File Offset: 0x00055165
		public Vector2 ToItem(GraphicsItem item, Vector2 pos)
		{
			return this._graphicsitem.mapToItem(item._graphicsitem, pos);
		}

		// Token: 0x06001521 RID: 5409 RVA: 0x00056F83 File Offset: 0x00055183
		public Vector2 FromItem(GraphicsItem item, Vector2 pos)
		{
			return this._graphicsitem.mapFromItem(item._graphicsitem, pos);
		}

		// Token: 0x06001522 RID: 5410 RVA: 0x00056FA4 File Offset: 0x000551A4
		internal void InternalItemChange(int change)
		{
			if (change - 9 <= 1)
			{
				this.OnPositionChanged();
				return;
			}
		}

		// Token: 0x06001523 RID: 5411 RVA: 0x00056FC1 File Offset: 0x000551C1
		protected virtual void OnPositionChanged()
		{
		}

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06001524 RID: 5412 RVA: 0x00056FC3 File Offset: 0x000551C3
		// (set) Token: 0x06001525 RID: 5413 RVA: 0x00056FCB File Offset: 0x000551CB
		public CursorShape Cursor
		{
			get
			{
				return this._cursor;
			}
			set
			{
				this._cursor = value;
				if (this.Cursor == CursorShape.None)
				{
					this._graphicsitem.unsetCursor();
					return;
				}
				this._graphicsitem.setCursor(this.Cursor);
			}
		}

		// Token: 0x0400042E RID: 1070
		internal QGraphicsItem _graphicsitem;

		// Token: 0x0400042F RID: 1071
		private static Dictionary<IntPtr, GraphicsItem> AllByAddress = new Dictionary<IntPtr, GraphicsItem>();

		// Token: 0x04000430 RID: 1072
		private List<GraphicsItem> Children;

		// Token: 0x04000431 RID: 1073
		internal GraphicsScene Scene;

		// Token: 0x04000432 RID: 1074
		private GraphicsItem _parent;

		// Token: 0x04000434 RID: 1076
		private CursorShape _cursor = CursorShape.None;
	}
}
