using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000BD RID: 189
	public class ListView : Widget
	{
		// Token: 0x060015CE RID: 5582 RVA: 0x0005829C File Offset: 0x0005649C
		public void SetModel(DataModel model)
		{
			if (this._clistview.IsValid)
			{
				this._clistview.setModelInternal(model._datamodel);
				this._clistview.setItemDelegate(model._itemdelegate);
			}
			this._selectionmodel = this._treeview.selectionModel();
		}

		// Token: 0x060015CF RID: 5583 RVA: 0x000582EC File Offset: 0x000564EC
		public void SetModel(DataNode node)
		{
			using (new SuspendUpdates(this))
			{
				DataModel model = new DataModel(this);
				model.SetRoot(node);
				this.SetModel(model);
			}
		}

		// Token: 0x060015D0 RID: 5584 RVA: 0x00058338 File Offset: 0x00056538
		internal ListView(IntPtr ptr)
		{
			this.NativeInit(ptr);
		}

		// Token: 0x060015D1 RID: 5585 RVA: 0x00058348 File Offset: 0x00056548
		public ListView(Widget parent = null)
		{
			InteropSystem.Alloc<ListView>(this);
			this._clistview = CListView.Create((parent != null) ? parent._widget : default(QWidget), this);
			this.NativeInit(this._clistview);
			base.MouseTracking = true;
			this.AutoResize = true;
			this.Wrapping = true;
			this.UniformSizes = true;
			this.Vertical = false;
		}

		// Token: 0x060015D2 RID: 5586 RVA: 0x000583B5 File Offset: 0x000565B5
		internal override void NativeInit(IntPtr ptr)
		{
			this._treeview = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060015D3 RID: 5587 RVA: 0x000583CA File Offset: 0x000565CA
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._treeview = default(QListView);
			this._clistview = default(CListView);
		}

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060015D4 RID: 5588 RVA: 0x000583EA File Offset: 0x000565EA
		// (set) Token: 0x060015D5 RID: 5589 RVA: 0x000583FA File Offset: 0x000565FA
		public bool Vertical
		{
			get
			{
				return this._treeview.flow() == Flow.TopToBottom;
			}
			set
			{
				this._treeview.setFlow(value ? Flow.TopToBottom : Flow.LeftToRight);
			}
		}

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060015D6 RID: 5590 RVA: 0x0005840E File Offset: 0x0005660E
		// (set) Token: 0x060015D7 RID: 5591 RVA: 0x00058420 File Offset: 0x00056620
		public Vector2 GridSize
		{
			get
			{
				return this._treeview.gridSize();
			}
			set
			{
				this._treeview.setGridSize(value);
			}
		}

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060015D8 RID: 5592 RVA: 0x00058433 File Offset: 0x00056633
		// (set) Token: 0x060015D9 RID: 5593 RVA: 0x00058443 File Offset: 0x00056643
		public bool IconMode
		{
			get
			{
				return this._treeview.viewMode() == ViewMode.IconMode;
			}
			set
			{
				this._treeview.setViewMode(value ? ViewMode.IconMode : ViewMode.ListMode);
			}
		}

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060015DA RID: 5594 RVA: 0x00058457 File Offset: 0x00056657
		// (set) Token: 0x060015DB RID: 5595 RVA: 0x00058467 File Offset: 0x00056667
		public bool AutoResize
		{
			get
			{
				return this._treeview.resizeMode() == ResizeMode.Adjust;
			}
			set
			{
				this._treeview.setResizeMode(value ? ResizeMode.Adjust : ResizeMode.Fixed);
			}
		}

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060015DC RID: 5596 RVA: 0x0005847B File Offset: 0x0005667B
		// (set) Token: 0x060015DD RID: 5597 RVA: 0x00058488 File Offset: 0x00056688
		public bool Wrapping
		{
			get
			{
				return this._treeview.isWrapping();
			}
			set
			{
				this._treeview.setWrapping(value);
			}
		}

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060015DE RID: 5598 RVA: 0x00058496 File Offset: 0x00056696
		// (set) Token: 0x060015DF RID: 5599 RVA: 0x000584A3 File Offset: 0x000566A3
		public bool UniformSizes
		{
			get
			{
				return this._treeview.uniformItemSizes();
			}
			set
			{
				this._treeview.setUniformItemSizes(value);
			}
		}

		// Token: 0x060015E0 RID: 5600 RVA: 0x000584B4 File Offset: 0x000566B4
		public void Clear()
		{
			if (this._clistview.IsValid)
			{
				this._clistview.setModelInternal(default(CDataModel));
			}
		}

		// Token: 0x060015E1 RID: 5601 RVA: 0x000584E2 File Offset: 0x000566E2
		internal void InternalItemPressed(ModelIndex index)
		{
		}

		// Token: 0x060015E2 RID: 5602 RVA: 0x000584E4 File Offset: 0x000566E4
		internal void InternalItemClicked(ModelIndex index)
		{
		}

		// Token: 0x060015E3 RID: 5603 RVA: 0x000584E6 File Offset: 0x000566E6
		internal void InternalItemDoubleClicked(ModelIndex index)
		{
		}

		// Token: 0x060015E4 RID: 5604 RVA: 0x000584E8 File Offset: 0x000566E8
		protected override void OnMouseRightClick(MouseEvent e)
		{
			base.OnMouseRightClick(e);
		}

		// Token: 0x060015E5 RID: 5605 RVA: 0x000584F4 File Offset: 0x000566F4
		internal void InternalCurrentChanged(ModelIndex current, ModelIndex previous)
		{
			DataNode p = previous.Node;
			DataNode c = current.Node;
			if (p != null)
			{
				this.OnUnselected(p);
			}
			if (c != null)
			{
				this.OnSelected(c);
			}
			if (previous.IsValid)
			{
				DataModel model = previous.Model;
				if (model != null)
				{
					model.OnItemSelection(previous, false);
				}
			}
			if (current.IsValid)
			{
				DataModel model2 = current.Model;
				if (model2 == null)
				{
					return;
				}
				model2.OnItemSelection(current, true);
			}
		}

		// Token: 0x060015E6 RID: 5606 RVA: 0x0005855E File Offset: 0x0005675E
		protected virtual void OnUnselected(DataNode node)
		{
			if (node != null)
			{
				node.SetSelected(false);
			}
		}

		// Token: 0x060015E7 RID: 5607 RVA: 0x0005856A File Offset: 0x0005676A
		protected virtual void OnSelected(DataNode node)
		{
			if (node != null)
			{
				node.SetSelected(true);
			}
		}

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060015E8 RID: 5608 RVA: 0x00058576 File Offset: 0x00056776
		// (set) Token: 0x060015E9 RID: 5609 RVA: 0x0005857E File Offset: 0x0005677E
		public DataNode HoveredNode { get; private set; }

		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060015EA RID: 5610 RVA: 0x00058588 File Offset: 0x00056788
		// (remove) Token: 0x060015EB RID: 5611 RVA: 0x000585C0 File Offset: 0x000567C0
		public event Action<DataNode> HoveredNodeChanged;

		// Token: 0x060015EC RID: 5612 RVA: 0x000585F8 File Offset: 0x000567F8
		protected override void OnMouseMove(MouseEvent e)
		{
			base.OnMouseMove(e);
			DataNode node = this.GetNodeAt(e.LocalPosition);
			this.UpdateHoveredNode(node);
		}

		// Token: 0x060015ED RID: 5613 RVA: 0x00058621 File Offset: 0x00056821
		protected void UpdateHoveredNode(DataNode node)
		{
			if (this.HoveredNode == node)
			{
				return;
			}
			this.HoveredNode = node;
			Action<DataNode> hoveredNodeChanged = this.HoveredNodeChanged;
			if (hoveredNodeChanged == null)
			{
				return;
			}
			hoveredNodeChanged(this.HoveredNode);
		}

		// Token: 0x060015EE RID: 5614 RVA: 0x0005864A File Offset: 0x0005684A
		protected override void OnMouseLeave()
		{
			base.OnMouseLeave();
			this.UpdateHoveredNode(null);
		}

		// Token: 0x060015EF RID: 5615 RVA: 0x0005865C File Offset: 0x0005685C
		public DataNode GetNodeAt(Vector2 point)
		{
			return this._treeview.indexAt(point).Node;
		}

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060015F0 RID: 5616 RVA: 0x00058682 File Offset: 0x00056882
		public bool HasSelectedItems
		{
			get
			{
				return !this._selectionmodel.IsNull && this._selectionmodel.hasSelection();
			}
		}

		// Token: 0x0400047D RID: 1149
		internal QListView _treeview;

		// Token: 0x0400047E RID: 1150
		internal CListView _clistview;

		// Token: 0x0400047F RID: 1151
		internal QItemSelectionModel _selectionmodel;
	}
}
