using System;
using System.Collections.Generic;
using System.Linq;

namespace Tools
{
	// Token: 0x020000BE RID: 190
	public class ListView<T> : ListView
	{
		// Token: 0x060015F1 RID: 5617 RVA: 0x0005869E File Offset: 0x0005689E
		public ListView(Widget parent = null)
			: base(parent)
		{
			this.Data = new DataList<T>(this);
			base.SetModel(this.Data);
		}

		// Token: 0x060015F2 RID: 5618 RVA: 0x000586BF File Offset: 0x000568BF
		public ListView(IEnumerable<T> items, Widget parent = null)
			: base(parent)
		{
			this.Data = new DataList<T>(items, this);
			base.SetModel(this.Data);
		}

		// Token: 0x060015F3 RID: 5619 RVA: 0x000586E1 File Offset: 0x000568E1
		public void AddRange(IEnumerable<T> items)
		{
			this.Data.AddRange(items);
		}

		// Token: 0x060015F4 RID: 5620 RVA: 0x000586EF File Offset: 0x000568EF
		public void SetItems(IEnumerable<T> items)
		{
			this.Data.SetItems(items);
		}

		// Token: 0x060015F5 RID: 5621 RVA: 0x000586FD File Offset: 0x000568FD
		public void TellItemChanged(T item)
		{
			this.Data.TellItemChanged(item);
		}

		/// <summary>
		/// Event to paint the item
		/// </summary>
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060015F6 RID: 5622 RVA: 0x0005870B File Offset: 0x0005690B
		// (set) Token: 0x060015F7 RID: 5623 RVA: 0x00058718 File Offset: 0x00056918
		public Action<T, Rect> ItemPaint
		{
			get
			{
				return this.Data.PaintItem;
			}
			set
			{
				this.Data.PaintItem = value;
			}
		}

		/// <summary>
		/// Event called when item is selected
		/// </summary>
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x060015F8 RID: 5624 RVA: 0x00058726 File Offset: 0x00056926
		// (set) Token: 0x060015F9 RID: 5625 RVA: 0x00058733 File Offset: 0x00056933
		public Action<T> ItemSelected
		{
			get
			{
				return this.Data.OnItemSelected;
			}
			set
			{
				this.Data.OnItemSelected = value;
			}
		}

		/// <summary>
		/// Event called when a context menu should be opened for items. The Vector2 is the screen position where we think the menu should popup.
		/// </summary>
		// Token: 0x1700015D RID: 349
		// (get) Token: 0x060015FA RID: 5626 RVA: 0x00058741 File Offset: 0x00056941
		// (set) Token: 0x060015FB RID: 5627 RVA: 0x00058749 File Offset: 0x00056949
		public Action<List<T>, Vector2> ItemContext { get; set; }

		/// <summary>
		/// Event called to retrieve the text to show in the status bar when hovering
		/// </summary>
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060015FC RID: 5628 RVA: 0x00058752 File Offset: 0x00056952
		// (set) Token: 0x060015FD RID: 5629 RVA: 0x0005875F File Offset: 0x0005695F
		public Func<T, string> ItemGetStatusTip
		{
			get
			{
				return this.Data.GetItemStatusTip;
			}
			set
			{
				this.Data.GetItemStatusTip = value;
			}
		}

		/// <summary>
		/// Event called to retrieve the tooltip to show when hovering
		/// </summary>
		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060015FE RID: 5630 RVA: 0x0005876D File Offset: 0x0005696D
		// (set) Token: 0x060015FF RID: 5631 RVA: 0x0005877A File Offset: 0x0005697A
		public Func<T, string> ItemGetToolTip
		{
			get
			{
				return this.Data.GetItemToolTip;
			}
			set
			{
				this.Data.GetItemToolTip = value;
			}
		}

		/// <summary>
		/// The preferred size of the items (todo make this an evbent)
		/// </summary>
		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06001600 RID: 5632 RVA: 0x00058788 File Offset: 0x00056988
		// (set) Token: 0x06001601 RID: 5633 RVA: 0x00058795 File Offset: 0x00056995
		public Vector2 ItemSize
		{
			get
			{
				return this.Data.ItemSize;
			}
			set
			{
				this.Data.ItemSize = value;
			}
		}

		// Token: 0x17000161 RID: 353
		// (get) Token: 0x06001602 RID: 5634 RVA: 0x000587A3 File Offset: 0x000569A3
		public IEnumerable<T> SelectedItems
		{
			get
			{
				if (base.HasSelectedItems)
				{
					QModelIndexList selected = this._selectionmodel.selectedIndexes();
					foreach (ModelIndex item in selected.Enumerate())
					{
						yield return this.Data.GetValue(item);
					}
					IEnumerator<ModelIndex> enumerator = null;
				}
				yield break;
				yield break;
			}
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x000587B4 File Offset: 0x000569B4
		protected override void OnMouseRightClick(MouseEvent e)
		{
			if (!base.HasSelectedItems)
			{
				return;
			}
			List<T> items = this.SelectedItems.ToList<T>();
			if (!items.Any<T>())
			{
				return;
			}
			Action<List<T>, Vector2> itemContext = this.ItemContext;
			if (itemContext == null)
			{
				return;
			}
			itemContext(items, e.ScreenPosition);
		}

		// Token: 0x04000482 RID: 1154
		private DataList<T> Data;
	}
}
