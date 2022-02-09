using System;
using System.Collections.Generic;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x0200008E RID: 142
	public class DataModel : QObject
	{
		// Token: 0x06001401 RID: 5121 RVA: 0x00054C33 File Offset: 0x00052E33
		internal DataModel(IntPtr ptr)
		{
			this.NativeInit(ptr);
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x00054C50 File Offset: 0x00052E50
		public DataModel(QObject parent = null)
		{
			InteropSystem.Alloc<DataModel>(this);
			this.ModelIdx = InteropSystem.GetAddress<DataModel>(this, true);
			this._itemdelegate = CDataDelegate.Create((parent != null) ? parent._object : default(QObject), this);
			this.NativeInit(CDataModel.Create((parent != null) ? parent._object : default(QObject), this));
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x00054CC8 File Offset: 0x00052EC8
		internal void Add(DataNode node, int row, int column)
		{
			node.Index.ModelIdx = this.ModelIdx;
			node.Index.DataModel = this._datamodel;
			node.Index.Index = ++DataModel.UniqueIndex;
			this.Nodes[node.Index.Index] = node;
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x00054D2B File Offset: 0x00052F2B
		internal void Remove(DataNode node)
		{
			this.Nodes.Remove(node.Index.Index);
			node.Index = default(ModelIndex);
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x00054D50 File Offset: 0x00052F50
		internal override void NativeInit(IntPtr ptr)
		{
			this._datamodel = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x06001406 RID: 5126 RVA: 0x00054D65 File Offset: 0x00052F65
		internal override void NativeShutdown()
		{
			this._datamodel = default(CDataModel);
			this._itemdelegate = default(CDataDelegate);
			base.NativeShutdown();
		}

		// Token: 0x06001407 RID: 5127 RVA: 0x00054D85 File Offset: 0x00052F85
		public virtual void SetRoot(DataNode root)
		{
			this.Nodes.Clear();
			this.Nodes[0] = root;
			root.InitializeNode(null, this, 0, 0);
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x00054DAC File Offset: 0x00052FAC
		internal DataNode GetNode(ModelIndex idx)
		{
			DataNode node;
			if (this.Nodes.TryGetValue(idx.Index, out node))
			{
				return node;
			}
			return null;
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x00054DD4 File Offset: 0x00052FD4
		internal virtual ModelIndex GetIndex(ModelIndex parent, int r, int c)
		{
			DataNode parentNode = this.GetNode(parent);
			DataNode node = ((parentNode != null) ? parentNode.GetChildAt(r) : null) ?? null;
			if (node == null)
			{
				return default(ModelIndex);
			}
			if (node.Model == null)
			{
				node.InitializeNode(parentNode, this, r, c);
			}
			if (node.Index.Row != r)
			{
				node.RowChanged(r);
			}
			ModelIndex index = node.Index;
			index.Column = c;
			return index;
		}

		// Token: 0x0600140A RID: 5130 RVA: 0x00054E40 File Offset: 0x00053040
		internal virtual ModelIndex GetNodeParent(ModelIndex idx)
		{
			DataNode node = this.GetNode(idx);
			ModelIndex? modelIndex;
			if (node == null)
			{
				modelIndex = null;
			}
			else
			{
				DataNode parent = node.Parent;
				modelIndex = ((parent != null) ? new ModelIndex?(parent.Index) : null);
			}
			ModelIndex? modelIndex2 = modelIndex;
			if (modelIndex2 == null)
			{
				return new ModelIndex();
			}
			return modelIndex2.GetValueOrDefault();
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x00054E98 File Offset: 0x00053098
		internal virtual int GetNodeRows(ModelIndex idx)
		{
			DataNode node = this.GetNode(idx);
			if (node == null)
			{
				return 0;
			}
			return node.Rows;
		}

		// Token: 0x0600140C RID: 5132 RVA: 0x00054EAC File Offset: 0x000530AC
		internal virtual int GetNodeColumns(ModelIndex idx)
		{
			return this.GetNode(idx).Columns;
		}

		// Token: 0x0600140D RID: 5133 RVA: 0x00054EBA File Offset: 0x000530BA
		internal virtual DataNode.Flags GetNodeFlags(ModelIndex idx)
		{
			DataNode node = this.GetNode(idx);
			if (node == null)
			{
				return DataNode.Flags.None;
			}
			return node.GetFlags(idx.Column);
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x00054ED4 File Offset: 0x000530D4
		public ModelIndex GetIndex(int r, int c)
		{
			return new ModelIndex
			{
				Row = r,
				Column = c,
				Index = 0,
				ModelIdx = this.ModelIdx,
				DataModel = this._datamodel
			};
		}

		/// <summary>
		/// This tells it that this tree has changed, and everything from and under this one will need rethinking.
		/// This is called when a child is added or removed.
		/// </summary>
		// Token: 0x0600140F RID: 5135 RVA: 0x00054F20 File Offset: 0x00053120
		public void DataLayoutChanged(DataNode parent)
		{
			this._datamodel.LayoutChanged(parent.Index);
		}

		/// <summary>
		/// This tells it that this node has changed and will need to be redrawn (if visible)
		/// </summary>
		// Token: 0x06001410 RID: 5136 RVA: 0x00054F33 File Offset: 0x00053133
		public void DataChanged(DataNode node)
		{
			this._datamodel.DataChanged(node.Index);
		}

		// Token: 0x06001411 RID: 5137 RVA: 0x00054F46 File Offset: 0x00053146
		public virtual void OnItemSelection(ModelIndex index, bool selected)
		{
		}

		// Token: 0x06001412 RID: 5138 RVA: 0x00054F48 File Offset: 0x00053148
		public void DataLayoutChanged()
		{
			this._datamodel.LayoutChanged(default(ModelIndex));
		}

		// Token: 0x06001413 RID: 5139 RVA: 0x00054F6C File Offset: 0x0005316C
		internal virtual void InternalPaintItem(in ModelIndex index, IntPtr painter, int state, in QRectF nativeRect)
		{
			Rect rect = nativeRect.Rect;
			try
			{
				Paint.Start(painter, (StateFlag)state);
				DataNode node = this.GetNode(index);
				if (node != null)
				{
					node.PaintItem(rect, index.Column);
				}
			}
			finally
			{
				Paint.Finished();
			}
		}

		// Token: 0x06001414 RID: 5140 RVA: 0x00054FC4 File Offset: 0x000531C4
		internal virtual Vector2 SizeHint(ModelIndex index)
		{
			DataNode node = this.GetNode(index);
			if (node == null)
			{
				return new Vector2(18f, 18f);
			}
			return node.SizeHint(index.Column);
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x00054FEC File Offset: 0x000531EC
		public virtual string ToolTipHint(ModelIndex index)
		{
			return null;
		}

		// Token: 0x06001416 RID: 5142 RVA: 0x00054FEF File Offset: 0x000531EF
		public virtual string StatusTipHint(ModelIndex index)
		{
			return null;
		}

		// Token: 0x040001D7 RID: 471
		private static int UniqueIndex = 1;

		// Token: 0x040001D8 RID: 472
		private uint ModelIdx;

		// Token: 0x040001D9 RID: 473
		internal CDataModel _datamodel;

		// Token: 0x040001DA RID: 474
		internal CDataDelegate _itemdelegate;

		// Token: 0x040001DB RID: 475
		private Dictionary<int, DataNode> Nodes = new Dictionary<int, DataNode>();
	}
}
