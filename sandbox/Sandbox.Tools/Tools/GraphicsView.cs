using System;
using Native;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x020000AE RID: 174
	public class GraphicsView : Widget
	{
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x060014CD RID: 5325 RVA: 0x00056718 File Offset: 0x00054918
		// (set) Token: 0x060014CE RID: 5326 RVA: 0x00056738 File Offset: 0x00054938
		public Rect SceneRect
		{
			get
			{
				return this._graphicsview.sceneRect().Rect;
			}
			set
			{
				this._graphicsview.setSceneRect(value);
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x060014CF RID: 5327 RVA: 0x0005674B File Offset: 0x0005494B
		// (set) Token: 0x060014D0 RID: 5328 RVA: 0x00056753 File Offset: 0x00054953
		public Vector2 Scale
		{
			get
			{
				return this._scale;
			}
			set
			{
				this._scale = value;
				this.BuildTransform();
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x060014D1 RID: 5329 RVA: 0x00056762 File Offset: 0x00054962
		// (set) Token: 0x060014D2 RID: 5330 RVA: 0x0005676A File Offset: 0x0005496A
		public float Rotation
		{
			get
			{
				return this._rotate;
			}
			set
			{
				this._rotate = value;
				this.BuildTransform();
			}
		}

		// Token: 0x060014D3 RID: 5331 RVA: 0x0005677C File Offset: 0x0005497C
		public void Zoom(float adjust, Vector2 viewpos)
		{
			Vector2 mousePosBefore = this.ToScene(viewpos);
			this._graphicsview.scale(adjust, adjust);
			Vector2 delta = this.ToScene(viewpos) - mousePosBefore;
			this._graphicsview.translate(delta.x, delta.y);
		}

		// Token: 0x060014D4 RID: 5332 RVA: 0x000567C8 File Offset: 0x000549C8
		public void Translate(Vector2 delta)
		{
			if (delta.Length <= 0.001f)
			{
				return;
			}
			GraphicsView.ViewportAnchorType old = this.TransformAnchor;
			this.TransformAnchor = GraphicsView.ViewportAnchorType.NoAnchor;
			this._graphicsview.translate(delta.x, delta.y);
			this.TransformAnchor = old;
		}

		// Token: 0x060014D5 RID: 5333 RVA: 0x00056814 File Offset: 0x00054A14
		private void BuildTransform()
		{
			GlobalToolsNamespace.Log.Info("Build Transform");
			this._graphicsview.resetTransform();
			this._graphicsview.scale(this._scale.x, this._scale.y);
			this._graphicsview.rotate(this._rotate);
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x00056870 File Offset: 0x00054A70
		public GraphicsView(Widget parent = null)
		{
			InteropSystem.Alloc<GraphicsView>(this);
			this.NativeInit(WidgetUtil.CreateGraphicsView((parent != null) ? parent._widget : default(QWidget), this));
			this.Scene = new GraphicsScene(this);
			this._graphicsview.setScene(this.Scene._scene);
			this.TransformAnchor = GraphicsView.ViewportAnchorType.NoAnchor;
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x000568EB File Offset: 0x00054AEB
		public Vector2 ToScene(Vector2 pos)
		{
			return this._graphicsview.mapToScene(pos);
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x00056903 File Offset: 0x00054B03
		public Vector2 FromScene(Vector2 pos)
		{
			return this._graphicsview.mapFromScene(pos);
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x060014D9 RID: 5337 RVA: 0x0005691B File Offset: 0x00054B1B
		// (set) Token: 0x060014DA RID: 5338 RVA: 0x00056923 File Offset: 0x00054B23
		internal GraphicsScene Scene { get; set; }

		// Token: 0x060014DB RID: 5339 RVA: 0x0005692C File Offset: 0x00054B2C
		internal override void NativeInit(IntPtr ptr)
		{
			this._graphicsview = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x00056941 File Offset: 0x00054B41
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._graphicsview = default(QGraphicsView);
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x00056955 File Offset: 0x00054B55
		public void CenterOn(Vector2 center)
		{
			this._graphicsview.centerOn(center);
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x060014DE RID: 5342 RVA: 0x00056968 File Offset: 0x00054B68
		// (set) Token: 0x060014DF RID: 5343 RVA: 0x00056975 File Offset: 0x00054B75
		public ScrollbarMode HorizontalScrollbar
		{
			get
			{
				return this._graphicsview.horizontalScrollBarPolicy();
			}
			set
			{
				this._graphicsview.setHorizontalScrollBarPolicy(value);
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x060014E0 RID: 5344 RVA: 0x00056983 File Offset: 0x00054B83
		// (set) Token: 0x060014E1 RID: 5345 RVA: 0x00056990 File Offset: 0x00054B90
		public ScrollbarMode VerticalScrollbar
		{
			get
			{
				return this._graphicsview.verticalScrollBarPolicy();
			}
			set
			{
				this._graphicsview.setVerticalScrollBarPolicy(value);
			}
		}

		// Token: 0x060014E2 RID: 5346 RVA: 0x000569A0 File Offset: 0x00054BA0
		public void SetBackgroundImage(string image)
		{
			using (QBrush brush = QBrush.FromImage(Pixmap.FromFile(image).ptr))
			{
				this._graphicsview.setBackgroundBrush(brush);
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x060014E3 RID: 5347 RVA: 0x000569EC File Offset: 0x00054BEC
		// (set) Token: 0x060014E4 RID: 5348 RVA: 0x000569F9 File Offset: 0x00054BF9
		public GraphicsView.ViewportAnchorType TransformAnchor
		{
			get
			{
				return this._graphicsview.transformationAnchor();
			}
			set
			{
				this._graphicsview.setTransformationAnchor(value);
			}
		}

		// Token: 0x060014E5 RID: 5349 RVA: 0x00056A07 File Offset: 0x00054C07
		public GraphicsItem GetItemAt(Vector2 scenePosition)
		{
			return GraphicsItem.Get(this._graphicsview.itemAt(this.FromScene(scenePosition)));
		}

		// Token: 0x060014E6 RID: 5350 RVA: 0x00056A25 File Offset: 0x00054C25
		public void Add(GraphicsItem t)
		{
			this.Scene.Add(t);
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x00056A33 File Offset: 0x00054C33
		public GraphicsWidget Add(Widget t)
		{
			return this.Scene.Add(t);
		}

		// Token: 0x17000123 RID: 291
		// (set) Token: 0x060014E8 RID: 5352 RVA: 0x00056A41 File Offset: 0x00054C41
		public bool Antialiasing
		{
			set
			{
				this._graphicsview.setRenderHint(RenderHints.Antialiasing, value);
			}
		}

		// Token: 0x17000124 RID: 292
		// (set) Token: 0x060014E9 RID: 5353 RVA: 0x00056A50 File Offset: 0x00054C50
		public bool TextAntialiasing
		{
			set
			{
				this._graphicsview.setRenderHint(RenderHints.TextAntialiasing, value);
			}
		}

		// Token: 0x17000125 RID: 293
		// (set) Token: 0x060014EA RID: 5354 RVA: 0x00056A5F File Offset: 0x00054C5F
		public bool BilinearFiltering
		{
			set
			{
				this._graphicsview.setRenderHint(RenderHints.SmoothPixmapTransform, value);
			}
		}

		// Token: 0x04000423 RID: 1059
		private QGraphicsView _graphicsview;

		// Token: 0x04000424 RID: 1060
		private Vector2 _scale = 1.0;

		// Token: 0x04000425 RID: 1061
		private float _rotate;

		// Token: 0x0200014E RID: 334
		public enum ViewportAnchorType
		{
			// Token: 0x040012BD RID: 4797
			NoAnchor,
			// Token: 0x040012BE RID: 4798
			AnchorViewCenter,
			// Token: 0x040012BF RID: 4799
			AnchorUnderMouse
		}
	}
}
