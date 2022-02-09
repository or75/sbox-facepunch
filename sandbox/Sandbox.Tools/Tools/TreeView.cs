using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000CC RID: 204
	public class TreeView : Widget
	{
		// Token: 0x060016D4 RID: 5844 RVA: 0x0005A095 File Offset: 0x00058295
		public void SetModel(DataModel model)
		{
			if (this._ctreeView.IsValid)
			{
				this._ctreeView.setModelInternal(model._datamodel);
				this._ctreeView.setItemDelegate(model._itemdelegate);
			}
		}

		// Token: 0x060016D5 RID: 5845 RVA: 0x0005A0C8 File Offset: 0x000582C8
		public void SetModel(DataNode node)
		{
			using (new SuspendUpdates(this))
			{
				DataModel model = new DataModel(this);
				model.SetRoot(node);
				this.SetModel(model);
			}
		}

		// Token: 0x060016D6 RID: 5846 RVA: 0x0005A114 File Offset: 0x00058314
		internal TreeView(IntPtr ptr)
		{
			this.NativeInit(ptr);
		}

		// Token: 0x060016D7 RID: 5847 RVA: 0x0005A124 File Offset: 0x00058324
		public TreeView(Widget parent = null)
		{
			InteropSystem.Alloc<TreeView>(this);
			this._ctreeView = CTreeView.Create((parent != null) ? parent._widget : default(QWidget), this);
			this.NativeInit(this._ctreeView);
			base.MouseTracking = true;
		}

		// Token: 0x060016D8 RID: 5848 RVA: 0x0005A175 File Offset: 0x00058375
		internal override void NativeInit(IntPtr ptr)
		{
			this._treeview = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060016D9 RID: 5849 RVA: 0x0005A18A File Offset: 0x0005838A
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._treeview = default(QTreeView);
			this._ctreeView = default(CTreeView);
		}

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x060016DA RID: 5850 RVA: 0x0005A1AA File Offset: 0x000583AA
		// (set) Token: 0x060016DB RID: 5851 RVA: 0x0005A1BA File Offset: 0x000583BA
		public bool ShowHeader
		{
			get
			{
				return !this._treeview.isHeaderHidden();
			}
			set
			{
				this._treeview.setHeaderHidden(!value);
			}
		}

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x060016DC RID: 5852 RVA: 0x0005A1CB File Offset: 0x000583CB
		// (set) Token: 0x060016DD RID: 5853 RVA: 0x0005A1D8 File Offset: 0x000583D8
		public bool SortingEnabled
		{
			get
			{
				return this._treeview.isSortingEnabled();
			}
			set
			{
				this._treeview.setSortingEnabled(value);
			}
		}

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x060016DE RID: 5854 RVA: 0x0005A1E6 File Offset: 0x000583E6
		// (set) Token: 0x060016DF RID: 5855 RVA: 0x0005A1F3 File Offset: 0x000583F3
		public bool UniformRowHeights
		{
			get
			{
				return this._treeview.uniformRowHeights();
			}
			set
			{
				this._treeview.setUniformRowHeights(value);
			}
		}

		// Token: 0x060016E0 RID: 5856 RVA: 0x0005A204 File Offset: 0x00058404
		public void Clear()
		{
			if (this._ctreeView.IsValid)
			{
				this._ctreeView.setModelInternal(default(CDataModel));
			}
		}

		// Token: 0x060016E1 RID: 5857 RVA: 0x0005A232 File Offset: 0x00058432
		internal void InternalItemPressed(ModelIndex index)
		{
		}

		// Token: 0x060016E2 RID: 5858 RVA: 0x0005A234 File Offset: 0x00058434
		internal void InternalItemClicked(ModelIndex index)
		{
		}

		// Token: 0x060016E3 RID: 5859 RVA: 0x0005A236 File Offset: 0x00058436
		internal void InternalItemDoubleClicked(ModelIndex index)
		{
		}

		// Token: 0x060016E4 RID: 5860 RVA: 0x0005A238 File Offset: 0x00058438
		internal void InternalItemExpanded(ModelIndex index)
		{
		}

		// Token: 0x060016E5 RID: 5861 RVA: 0x0005A23A File Offset: 0x0005843A
		internal void InternalItemCollapsed(ModelIndex index)
		{
		}

		// Token: 0x060016E6 RID: 5862 RVA: 0x0005A23C File Offset: 0x0005843C
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
		}

		// Token: 0x060016E7 RID: 5863 RVA: 0x0005A26D File Offset: 0x0005846D
		protected virtual void OnUnselected(DataNode node)
		{
			if (node != null)
			{
				node.SetSelected(false);
			}
		}

		// Token: 0x060016E8 RID: 5864 RVA: 0x0005A279 File Offset: 0x00058479
		protected virtual void OnSelected(DataNode node)
		{
			if (node != null)
			{
				node.SetSelected(true);
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x060016E9 RID: 5865 RVA: 0x0005A285 File Offset: 0x00058485
		// (set) Token: 0x060016EA RID: 5866 RVA: 0x0005A28D File Offset: 0x0005848D
		public DataNode HoveredNode { get; private set; }

		// Token: 0x1400000B RID: 11
		// (add) Token: 0x060016EB RID: 5867 RVA: 0x0005A298 File Offset: 0x00058498
		// (remove) Token: 0x060016EC RID: 5868 RVA: 0x0005A2D0 File Offset: 0x000584D0
		public event Action<DataNode> HoveredNodeChanged;

		// Token: 0x060016ED RID: 5869 RVA: 0x0005A308 File Offset: 0x00058508
		protected override void OnMouseMove(MouseEvent e)
		{
			base.OnMouseMove(e);
			DataNode node = this.GetNodeAt(e.LocalPosition);
			this.UpdateHoveredNode(node);
		}

		// Token: 0x060016EE RID: 5870 RVA: 0x0005A331 File Offset: 0x00058531
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

		// Token: 0x060016EF RID: 5871 RVA: 0x0005A35A File Offset: 0x0005855A
		protected override void OnMouseLeave()
		{
			base.OnMouseLeave();
			this.UpdateHoveredNode(null);
		}

		// Token: 0x060016F0 RID: 5872 RVA: 0x0005A36C File Offset: 0x0005856C
		public DataNode GetNodeAt(Vector2 point)
		{
			return this._treeview.indexAt(point).Node;
		}

		// Token: 0x040004AD RID: 1197
		internal QTreeView _treeview;

		// Token: 0x040004AE RID: 1198
		internal CTreeView _ctreeView;
	}
}
