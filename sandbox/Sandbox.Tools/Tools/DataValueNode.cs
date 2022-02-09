using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Tools
{
	// Token: 0x02000091 RID: 145
	public class DataValueNode<T> : DataNode where T : class
	{
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06001447 RID: 5191 RVA: 0x00055619 File Offset: 0x00053819
		// (set) Token: 0x06001448 RID: 5192 RVA: 0x00055621 File Offset: 0x00053821
		public T Value { get; set; }

		// Token: 0x06001449 RID: 5193 RVA: 0x0005562A File Offset: 0x0005382A
		public DataValueNode()
		{
		}

		// Token: 0x0600144A RID: 5194 RVA: 0x00055632 File Offset: 0x00053832
		public DataValueNode(T val)
		{
			this.Value = val;
			this.Root = this;
		}

		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600144B RID: 5195 RVA: 0x00055648 File Offset: 0x00053848
		public override int Rows
		{
			get
			{
				DataValueNode<T> root = this.Root;
				if (((root != null) ? root.OnGetChildren : null) != null)
				{
					return this.Root.OnGetChildren(this.Value).Count<T>();
				}
				return base.Rows;
			}
		}

		// Token: 0x0600144C RID: 5196 RVA: 0x00055680 File Offset: 0x00053880
		public override bool IsVisible()
		{
			DataValueNode<T> root = this.Root;
			bool? flag;
			if (root == null)
			{
				flag = null;
			}
			else
			{
				Func<T, bool> shouldShowItem = root.ShouldShowItem;
				flag = ((shouldShowItem != null) ? new bool?(shouldShowItem(this.Value)) : null);
			}
			return flag ?? true;
		}

		// Token: 0x0600144D RID: 5197 RVA: 0x000556DC File Offset: 0x000538DC
		public override void AddChild(DataNode node)
		{
			DataValueNode<T> i = node as DataValueNode<T>;
			if (i != null)
			{
				i.Root = this.Root;
			}
			base.AddChild(node);
		}

		// Token: 0x0600144E RID: 5198 RVA: 0x00055708 File Offset: 0x00053908
		public override DataNode CreateChildNode(int row)
		{
			if (this.Root == null || this.Root.OnGetChildren == null)
			{
				return base.CreateChildNode(row);
			}
			DataValueNode<T> root = this.Root;
			T t;
			if (root == null)
			{
				t = default(T);
			}
			else
			{
				Func<T, IEnumerable<T>> onGetChildren = root.OnGetChildren;
				t = ((onGetChildren != null) ? onGetChildren(this.Value).Skip(row).FirstOrDefault<T>() : default(T));
			}
			T t2;
			if ((t2 = t) == null)
			{
				t2 = default(T);
			}
			T c = t2;
			if (c == null)
			{
				return base.CreateChildNode(row);
			}
			return new DataValueNode<T>
			{
				Root = this.Root,
				Value = c
			};
		}

		// Token: 0x0600144F RID: 5199 RVA: 0x000557AC File Offset: 0x000539AC
		protected override void OnNodeSelected()
		{
			DataValueNode<T> root = this.Root;
			if (root == null)
			{
				return;
			}
			Action<T> onSelected = root.OnSelected;
			if (onSelected == null)
			{
				return;
			}
			onSelected(this.Value);
		}

		// Token: 0x06001450 RID: 5200 RVA: 0x000557D0 File Offset: 0x000539D0
		public override void PaintItem(in Rect rect, int column)
		{
			DataValueNode<T> root = this.Root;
			if (((root != null) ? root.OnPaintItem : null) == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<T>(this.Value);
				Paint.DrawText(rect, defaultInterpolatedStringHandler.ToStringAndClear(), TextFlag.LeftCenter);
				return;
			}
			Action<T, Rect, int> onPaintItem = this.Root.OnPaintItem;
			if (onPaintItem == null)
			{
				return;
			}
			onPaintItem(this.Value, rect, column);
		}

		// Token: 0x06001451 RID: 5201 RVA: 0x00055840 File Offset: 0x00053A40
		public virtual void FindAndRemove(T v)
		{
			if (this.Value == v)
			{
				this.Remove();
				return;
			}
			List<DataNode> childNodes = this.ChildNodes;
			if (childNodes == null || childNodes.Count == 0)
			{
				return;
			}
			for (int i = this.ChildNodes.Count - 1; i >= 0; i--)
			{
				DataValueNode<T> t = this.ChildNodes[i] as DataValueNode<T>;
				if (t != null)
				{
					t.FindAndRemove(v);
				}
			}
		}

		// Token: 0x06001452 RID: 5202 RVA: 0x000558B0 File Offset: 0x00053AB0
		public virtual U FindNodeWithValue<U>(T v) where U : DataValueNode<T>
		{
			if (this.Value == v)
			{
				return this as U;
			}
			List<DataNode> childNodes = this.ChildNodes;
			if (childNodes == null || childNodes.Count == 0)
			{
				return default(U);
			}
			for (int i = this.ChildNodes.Count - 1; i >= 0; i--)
			{
				U t = this.ChildNodes[i] as U;
				if (t != null)
				{
					U j = t.FindNodeWithValue<U>(v);
					if (j != null)
					{
						return j;
					}
				}
			}
			return default(U);
		}

		// Token: 0x06001453 RID: 5203 RVA: 0x00055954 File Offset: 0x00053B54
		protected override void SortChildren()
		{
			DataValueNode<T>.<>c__DisplayClass21_0 CS$<>8__locals1 = new DataValueNode<T>.<>c__DisplayClass21_0();
			DataValueNode<T> root = this.Root;
			if (((root != null) ? root.SortBy : null) == null)
			{
				return;
			}
			DataValueNode<T>.<>c__DisplayClass21_0 CS$<>8__locals2 = CS$<>8__locals1;
			DataValueNode<T> root2 = this.Root;
			CS$<>8__locals2.sort = ((root2 != null) ? root2.SortBy : null);
			this.ChildNodes.Sort(delegate(DataNode a, DataNode b)
			{
				IComparable comparable = CS$<>8__locals1.sort((a as DataValueNode<T>).Value);
				IComparable bb = CS$<>8__locals1.sort((b as DataValueNode<T>).Value);
				return comparable.CompareTo(bb);
			});
		}

		// Token: 0x040001E8 RID: 488
		private DataValueNode<T> Root;

		// Token: 0x040001E9 RID: 489
		public Action<T, Rect, int> OnPaintItem;

		// Token: 0x040001EA RID: 490
		public Func<T, IEnumerable<T>> OnGetChildren;

		// Token: 0x040001EB RID: 491
		public Action<T> OnSelected;

		// Token: 0x040001EC RID: 492
		public Func<T, IComparable> SortBy;

		// Token: 0x040001ED RID: 493
		public Func<T, bool> ShouldShowItem;
	}
}
