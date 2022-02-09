using System;
using System.Collections.Generic;

namespace Tools
{
	/// <summary>
	/// This could be public, but it needs a good clean up first
	/// </summary>
	// Token: 0x0200008F RID: 143
	internal class DataList<T> : DataModel
	{
		// Token: 0x06001418 RID: 5144 RVA: 0x00054FFA File Offset: 0x000531FA
		public DataList(QObject parent = null)
			: base(parent)
		{
		}

		// Token: 0x06001419 RID: 5145 RVA: 0x00055023 File Offset: 0x00053223
		public DataList(IEnumerable<T> items, QObject parent = null)
			: base(parent)
		{
			this.SetItems(items);
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x00055053 File Offset: 0x00053253
		internal override ModelIndex GetNodeParent(ModelIndex idx)
		{
			return new ModelIndex();
		}

		// Token: 0x0600141B RID: 5147 RVA: 0x0005505A File Offset: 0x0005325A
		internal override int GetNodeRows(ModelIndex idx)
		{
			if (idx.IsValid)
			{
				return 0;
			}
			return this.Items.Count;
		}

		// Token: 0x0600141C RID: 5148 RVA: 0x00055072 File Offset: 0x00053272
		internal override int GetNodeColumns(ModelIndex idx)
		{
			if (idx.IsValid)
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x0600141D RID: 5149 RVA: 0x00055080 File Offset: 0x00053280
		public void AddRange(IEnumerable<T> items)
		{
			this.Items.AddRange(items);
			base.DataLayoutChanged();
		}

		// Token: 0x0600141E RID: 5150 RVA: 0x00055094 File Offset: 0x00053294
		public void SetItems(IEnumerable<T> items)
		{
			this.Items.Clear();
			this.Items.AddRange(items);
			base.DataLayoutChanged();
		}

		// Token: 0x0600141F RID: 5151 RVA: 0x000550B4 File Offset: 0x000532B4
		public T GetValue(ModelIndex index)
		{
			if (index.Row < 0)
			{
				return default(T);
			}
			if (index.Row >= this.Items.Count)
			{
				return default(T);
			}
			return this.Items[index.Row];
		}

		// Token: 0x06001420 RID: 5152 RVA: 0x00055104 File Offset: 0x00053304
		internal override ModelIndex GetIndex(ModelIndex parent, int r, int c)
		{
			if (parent.IsValid)
			{
				return default(ModelIndex);
			}
			return base.GetIndex(r, c);
		}

		// Token: 0x06001421 RID: 5153 RVA: 0x0005512C File Offset: 0x0005332C
		internal override void InternalPaintItem(in ModelIndex index, IntPtr painter, int state, in QRectF nativeRect)
		{
			Rect rect = nativeRect.Rect;
			try
			{
				Paint.Start(painter, (StateFlag)state);
				T value = this.GetValue(index);
				this.OnPaintItem(value, rect);
			}
			finally
			{
				Paint.Finished();
			}
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x0005517C File Offset: 0x0005337C
		public virtual void OnPaintItem(in T value, in Rect rect)
		{
			Action<T, Rect> paintItem = this.PaintItem;
			if (paintItem == null)
			{
				return;
			}
			paintItem(value, rect);
		}

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06001423 RID: 5155 RVA: 0x0005519A File Offset: 0x0005339A
		// (set) Token: 0x06001424 RID: 5156 RVA: 0x000551A2 File Offset: 0x000533A2
		public Vector2 ItemSize { get; set; } = new Vector2(18f, 18f);

		// Token: 0x06001425 RID: 5157 RVA: 0x000551AB File Offset: 0x000533AB
		internal override Vector2 SizeHint(ModelIndex index)
		{
			return this.ItemSize;
		}

		// Token: 0x06001426 RID: 5158 RVA: 0x000551B3 File Offset: 0x000533B3
		internal override DataNode.Flags GetNodeFlags(ModelIndex idx)
		{
			return (DataNode.Flags)173;
		}

		// Token: 0x06001427 RID: 5159 RVA: 0x000551BA File Offset: 0x000533BA
		public override string ToolTipHint(ModelIndex index)
		{
			Func<T, string> getItemToolTip = this.GetItemToolTip;
			if (getItemToolTip == null)
			{
				return null;
			}
			return getItemToolTip(this.GetValue(index));
		}

		// Token: 0x06001428 RID: 5160 RVA: 0x000551D4 File Offset: 0x000533D4
		public override string StatusTipHint(ModelIndex index)
		{
			Func<T, string> getItemStatusTip = this.GetItemStatusTip;
			if (getItemStatusTip == null)
			{
				return null;
			}
			return getItemStatusTip(this.GetValue(index));
		}

		// Token: 0x06001429 RID: 5161 RVA: 0x000551EE File Offset: 0x000533EE
		public override void OnItemSelection(ModelIndex index, bool selected)
		{
			if (selected)
			{
				Action<T> onItemSelected = this.OnItemSelected;
				if (onItemSelected != null)
				{
					onItemSelected(this.GetValue(index));
				}
			}
			if (!selected)
			{
				Action<T> onItemUnSelected = this.OnItemUnSelected;
				if (onItemUnSelected == null)
				{
					return;
				}
				onItemUnSelected(this.GetValue(index));
			}
		}

		/// <summary>
		/// Mark an item as changed, will redraw it
		/// </summary>
		// Token: 0x0600142A RID: 5162 RVA: 0x00055228 File Offset: 0x00053428
		public void TellItemChanged(T item)
		{
			int idx = this.Items.IndexOf(item);
			if (idx < 0)
			{
				return;
			}
			this._datamodel.DataChanged(base.GetIndex(idx, 0));
		}

		// Token: 0x040001DC RID: 476
		private List<T> Items = new List<T>();

		// Token: 0x040001DD RID: 477
		public Action<T, Rect> PaintItem;

		// Token: 0x040001DF RID: 479
		public Func<T, string> GetItemToolTip;

		// Token: 0x040001E0 RID: 480
		public Func<T, string> GetItemStatusTip;

		// Token: 0x040001E1 RID: 481
		public Action<T> OnItemSelected;

		// Token: 0x040001E2 RID: 482
		public Action<T> OnItemUnSelected;
	}
}
