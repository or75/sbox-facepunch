using System;

namespace Sandbox.UI
{
	// Token: 0x0200012B RID: 299
	internal abstract class BaseTextBlock : IDisposable
	{
		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06001724 RID: 5924 RVA: 0x0005D661 File Offset: 0x0005B861
		// (set) Token: 0x06001725 RID: 5925 RVA: 0x0005D669 File Offset: 0x0005B869
		public string Text { get; internal set; }

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x06001726 RID: 5926 RVA: 0x0005D672 File Offset: 0x0005B872
		// (set) Token: 0x06001727 RID: 5927 RVA: 0x0005D67A File Offset: 0x0005B87A
		public int SelectionStart { get; internal set; }

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x06001728 RID: 5928 RVA: 0x0005D683 File Offset: 0x0005B883
		// (set) Token: 0x06001729 RID: 5929 RVA: 0x0005D68B File Offset: 0x0005B88B
		public int SelectionEnd { get; internal set; }

		/// <summary>
		/// Given a character position, where is the fucking caret
		/// </summary>
		// Token: 0x0600172A RID: 5930
		public abstract Rect CaretRect(int iPos);

		// Token: 0x0600172B RID: 5931 RVA: 0x0005D694 File Offset: 0x0005B894
		internal virtual void Render(PanelRenderer renderer, ref RenderState state, Styles currentStyle, Rect renderRect)
		{
		}

		// Token: 0x0600172C RID: 5932 RVA: 0x0005D696 File Offset: 0x0005B896
		internal void SetText(string text)
		{
			if (this.Text == text)
			{
				return;
			}
			this.Text = text;
			this.TimeSinceRebuild = 1000f;
		}

		// Token: 0x0600172D RID: 5933 RVA: 0x0005D6BE File Offset: 0x0005B8BE
		public virtual int GetLetterAt(Vector2 pos)
		{
			return -1;
		}

		// Token: 0x0600172E RID: 5934
		public abstract Vector2 Measure(float width, float height);

		// Token: 0x0600172F RID: 5935
		public abstract bool UpdateStyles(Styles computedStyle);

		// Token: 0x06001730 RID: 5936
		public abstract void SizeFinalized(float width, float height);

		// Token: 0x06001731 RID: 5937
		public abstract void Dispose();

		// Token: 0x040005D0 RID: 1488
		public bool ShouldDrawSelection;

		// Token: 0x040005D3 RID: 1491
		public RealTimeSince TimeSinceRebuild;

		// Token: 0x040005D4 RID: 1492
		public Vector2 BlockSize;
	}
}
