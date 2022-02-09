using System;

namespace Sandbox.UI
{
	// Token: 0x02000118 RID: 280
	internal class Selection
	{
		// Token: 0x060015CC RID: 5580 RVA: 0x00057C78 File Offset: 0x00055E78
		public void UpdateSelection(Panel root, Panel hovered, bool dragging, bool started, bool ended, Vector2 pos)
		{
			if (started)
			{
				this.SelectionStart = null;
				if (hovered == null)
				{
					return;
				}
				this.ClearSelection();
				this.SelectionStart = hovered;
				this.SelectionStartPos = this.SelectionStart.ScreenPositionToPanelPosition(pos);
				this.SelectionEndPos = this.SelectionStartPos;
				return;
			}
			else
			{
				if (this.SelectionStart == null)
				{
					return;
				}
				if (dragging || ended)
				{
					int hash = HashCode.Combine<Panel, Vector2, Vector2>(this.SelectionStart, this.SelectionStartPos, this.SelectionEndPos);
					this.SelectionEndPos = this.SelectionStart.ScreenPositionToPanelPosition(pos);
					if (HashCode.Combine<Panel, Vector2, Vector2>(this.SelectionStart, this.SelectionStartPos, this.SelectionEndPos) == hash)
					{
						return;
					}
					SelectionEvent e = new SelectionEvent("ondragselect", this.SelectionStart);
					e.StartPoint = this.SelectionStart.PanelPositionToScreenPosition(this.SelectionStartPos);
					e.EndPoint = this.SelectionStart.PanelPositionToScreenPosition(this.SelectionEndPos);
					e.SelectionRect = new Rect(e.StartPoint, default(Vector2));
					e.SelectionRect = e.SelectionRect.AddPoint(e.EndPoint);
					this.SelectionStart.CreateEvent(e);
				}
				return;
			}
		}

		// Token: 0x060015CD RID: 5581 RVA: 0x00057D95 File Offset: 0x00055F95
		private void ClearSelection()
		{
		}

		// Token: 0x04000560 RID: 1376
		private Panel SelectionStart;

		// Token: 0x04000561 RID: 1377
		private Vector2 SelectionStartPos;

		// Token: 0x04000562 RID: 1378
		private Vector2 SelectionEndPos;
	}
}
