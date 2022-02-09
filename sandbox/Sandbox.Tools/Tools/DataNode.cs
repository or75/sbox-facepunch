using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox;

namespace Tools
{
	// Token: 0x02000090 RID: 144
	public class DataNode
	{
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600142B RID: 5163 RVA: 0x0005525A File Offset: 0x0005345A
		// (set) Token: 0x0600142C RID: 5164 RVA: 0x00055262 File Offset: 0x00053462
		public DataNode Parent { get; private set; }

		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600142D RID: 5165 RVA: 0x0005526B File Offset: 0x0005346B
		// (set) Token: 0x0600142E RID: 5166 RVA: 0x00055273 File Offset: 0x00053473
		public DataModel Model { get; internal set; }

		// Token: 0x06001430 RID: 5168 RVA: 0x00055290 File Offset: 0x00053490
		internal void InitializeNode(DataNode Parent, DataModel Model, int row, int column)
		{
			Assert.NotNull<DataModel>(Model);
			this.Parent = Parent;
			this.Model = Model;
			this.Index = new ModelIndex
			{
				Row = row,
				Column = column
			};
			Model.Add(this, row, column);
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x000552DA File Offset: 0x000534DA
		public virtual DataNode CreateChildNode(int row)
		{
			return null;
		}

		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06001432 RID: 5170 RVA: 0x000552DD File Offset: 0x000534DD
		public virtual int Columns
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06001433 RID: 5171 RVA: 0x000552E0 File Offset: 0x000534E0
		public virtual int Rows
		{
			get
			{
				return this.FilteredChildren.Count<DataNode>();
			}
		}

		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06001434 RID: 5172 RVA: 0x000552ED File Offset: 0x000534ED
		protected IEnumerable<DataNode> FilteredChildren
		{
			get
			{
				return this.ChildNodes.Where((DataNode x) => x.IsVisible());
			}
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x00055319 File Offset: 0x00053519
		public virtual bool IsVisible()
		{
			return true;
		}

		// Token: 0x06001436 RID: 5174 RVA: 0x0005531C File Offset: 0x0005351C
		internal DataNode GetChildAt(int row)
		{
			DataNode x = this.FilteredChildren.Skip(row).FirstOrDefault<DataNode>();
			if (x != null)
			{
				return x;
			}
			DataNode node = this.CreateChildNode(row);
			if (node == null)
			{
				return null;
			}
			this.AddChild(node);
			if (!node.IsVisible())
			{
				return null;
			}
			return node;
		}

		// Token: 0x06001437 RID: 5175 RVA: 0x00055360 File Offset: 0x00053560
		public virtual void AddChild(DataNode node)
		{
			if (!this.ChildNodes.Contains(node))
			{
				this.ChildNodes.Add(node);
			}
			if (this.Model == null)
			{
				return;
			}
			node.InitializeNode(this, this.Model, this.ChildNodes.Count - 1, 0);
			this.SortChildren();
			this.MarkChanged();
		}

		// Token: 0x06001438 RID: 5176 RVA: 0x000553B8 File Offset: 0x000535B8
		public void AddChildAfter(DataNode peer, DataNode node)
		{
			Assert.True(this.ChildNodes.Contains(peer));
			Assert.False(this.ChildNodes.Contains(node));
			int index = this.ChildNodes.IndexOf(peer) + 1;
			this.ChildNodes.Insert(index, node);
			if (this.Model == null)
			{
				return;
			}
			node.InitializeNode(this, this.Model, index, 0);
			this.SortChildren();
			this.MarkChanged();
		}

		// Token: 0x06001439 RID: 5177 RVA: 0x00055428 File Offset: 0x00053628
		public void AddChildBefore(DataNode peer, DataNode node)
		{
			Assert.True(this.ChildNodes.Contains(peer));
			Assert.False(this.ChildNodes.Contains(node));
			int index = this.ChildNodes.IndexOf(peer);
			this.ChildNodes.Insert(index, node);
			if (this.Model == null)
			{
				return;
			}
			node.InitializeNode(this, this.Model, index, 0);
			this.SortChildren();
			this.MarkChanged();
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x00055498 File Offset: 0x00053698
		public virtual void Remove()
		{
			if (this.Parent != null)
			{
				this.Parent.RemoveChild(this);
				DataModel model = this.Model;
				if (model != null)
				{
					model.Remove(this);
				}
				this.Parent = null;
				this.Model = null;
				this.Index = default(ModelIndex);
			}
		}

		// Token: 0x0600143B RID: 5179 RVA: 0x000554E5 File Offset: 0x000536E5
		public virtual void RemoveChild(DataNode node)
		{
			this.ChildNodes.IndexOf(node);
			this.ChildNodes.Remove(node);
			this.SortChildren();
			this.MarkChanged();
		}

		// Token: 0x0600143C RID: 5180 RVA: 0x0005550D File Offset: 0x0005370D
		internal void RowChanged(int r)
		{
			if (this.Index.Row == r)
			{
				return;
			}
			this.Index.Row = r;
		}

		// Token: 0x0600143D RID: 5181 RVA: 0x0005552A File Offset: 0x0005372A
		public virtual DataNode.Flags GetFlags(int column)
		{
			return (DataNode.Flags)33;
		}

		// Token: 0x0600143E RID: 5182 RVA: 0x0005552E File Offset: 0x0005372E
		internal void SetSelected(bool b)
		{
			if (b)
			{
				this.OnNodeSelected();
				return;
			}
			this.OnNodeUnselected();
		}

		// Token: 0x0600143F RID: 5183 RVA: 0x00055540 File Offset: 0x00053740
		protected virtual void OnNodeUnselected()
		{
			DataModel model = this.Model;
			if (model == null)
			{
				return;
			}
			model.OnItemSelection(this.Index, false);
		}

		// Token: 0x06001440 RID: 5184 RVA: 0x00055559 File Offset: 0x00053759
		protected virtual void OnNodeSelected()
		{
			DataModel model = this.Model;
			if (model == null)
			{
				return;
			}
			model.OnItemSelection(this.Index, true);
		}

		// Token: 0x06001441 RID: 5185 RVA: 0x00055572 File Offset: 0x00053772
		public void MarkChanged()
		{
			DataModel model = this.Model;
			if (model == null)
			{
				return;
			}
			model.DataLayoutChanged(this);
		}

		// Token: 0x06001442 RID: 5186 RVA: 0x00055585 File Offset: 0x00053785
		public void DataChanged()
		{
			DataModel model = this.Model;
			if (model == null)
			{
				return;
			}
			model.DataChanged(this);
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x00055598 File Offset: 0x00053798
		public virtual DataNode WithValue(object o)
		{
			return this.ChildNodes.Select((DataNode x) => x.WithValue(x)).FirstOrDefault((DataNode x) => x != null);
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x000555F3 File Offset: 0x000537F3
		public virtual void PaintItem(in Rect rect, int column)
		{
			Paint.DrawText(rect, "PaintItem unimplemented", TextFlag.LeftCenter);
		}

		// Token: 0x06001445 RID: 5189 RVA: 0x00055606 File Offset: 0x00053806
		public virtual Vector2 SizeHint(int column)
		{
			return new Vector2(18f, 18f);
		}

		// Token: 0x06001446 RID: 5190 RVA: 0x00055617 File Offset: 0x00053817
		protected virtual void SortChildren()
		{
		}

		// Token: 0x040001E5 RID: 485
		internal ModelIndex Index;

		// Token: 0x040001E6 RID: 486
		public List<DataNode> ChildNodes = new List<DataNode>();

		// Token: 0x02000146 RID: 326
		public enum Flags
		{
			// Token: 0x04001296 RID: 4758
			None,
			// Token: 0x04001297 RID: 4759
			IsSelectable,
			// Token: 0x04001298 RID: 4760
			IsEditable,
			// Token: 0x04001299 RID: 4761
			IsDragEnabled = 4,
			// Token: 0x0400129A RID: 4762
			IsDropEnabled = 8,
			// Token: 0x0400129B RID: 4763
			IsUserCheckable = 16,
			// Token: 0x0400129C RID: 4764
			IsEnabled = 32,
			// Token: 0x0400129D RID: 4765
			NeverHasChildren = 128
		}
	}
}
