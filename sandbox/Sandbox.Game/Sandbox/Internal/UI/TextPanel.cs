using System;
using System.ComponentModel;
using Facebook.Yoga;
using Sandbox.UI;

namespace Sandbox.Internal.UI
{
	/// <summary>
	/// This is a simple text element. It's purely used to render text.
	/// It shouldn't have padding etc applied to it.
	/// </summary>
	// Token: 0x0200018E RID: 398
	public sealed class TextPanel : Panel
	{
		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06001C6B RID: 7275 RVA: 0x00071874 File Offset: 0x0006FA74
		// (set) Token: 0x06001C6C RID: 7276 RVA: 0x0007187C File Offset: 0x0006FA7C
		[Category("Content")]
		public string Text
		{
			get
			{
				return this._text;
			}
			set
			{
				if (this._text == value)
				{
					return;
				}
				this._text = value;
			}
		}

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06001C6D RID: 7277 RVA: 0x00071894 File Offset: 0x0006FA94
		public override bool HasContent
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Can be selected
		/// </summary>
		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06001C6E RID: 7278 RVA: 0x00071897 File Offset: 0x0006FA97
		// (set) Token: 0x06001C6F RID: 7279 RVA: 0x0007189F File Offset: 0x0006FA9F
		[Category("Selection")]
		public bool Selectable { get; set; } = true;

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06001C70 RID: 7280 RVA: 0x000718A8 File Offset: 0x0006FAA8
		// (set) Token: 0x06001C71 RID: 7281 RVA: 0x000718BB File Offset: 0x0006FABB
		[Category("Selection")]
		public bool ShouldDrawSelection
		{
			get
			{
				BaseTextBlock baseTextBlock = this.textBlock;
				return baseTextBlock != null && baseTextBlock.ShouldDrawSelection;
			}
			set
			{
				if (this.textBlock != null)
				{
					this.textBlock.ShouldDrawSelection = this.Selectable && value;
				}
			}
		}

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x06001C72 RID: 7282 RVA: 0x000718D8 File Offset: 0x0006FAD8
		// (set) Token: 0x06001C73 RID: 7283 RVA: 0x000718EB File Offset: 0x0006FAEB
		[Browsable(false)]
		public int SelectionStart
		{
			get
			{
				BaseTextBlock baseTextBlock = this.textBlock;
				if (baseTextBlock == null)
				{
					return 0;
				}
				return baseTextBlock.SelectionStart;
			}
			set
			{
				if (this.textBlock != null)
				{
					this.textBlock.SelectionStart = value;
				}
			}
		}

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x06001C74 RID: 7284 RVA: 0x00071901 File Offset: 0x0006FB01
		// (set) Token: 0x06001C75 RID: 7285 RVA: 0x00071914 File Offset: 0x0006FB14
		[Browsable(false)]
		public int SelectionEnd
		{
			get
			{
				BaseTextBlock baseTextBlock = this.textBlock;
				if (baseTextBlock == null)
				{
					return 0;
				}
				return baseTextBlock.SelectionEnd;
			}
			set
			{
				if (this.textBlock != null)
				{
					this.textBlock.SelectionEnd = value;
				}
			}
		}

		// Token: 0x06001C76 RID: 7286 RVA: 0x0007192A File Offset: 0x0006FB2A
		public TextPanel(Panel parent)
			: base(parent)
		{
			this.YogaNode.SetMeasureFunction(new MeasureFunction(this.MeasureText));
		}

		// Token: 0x06001C77 RID: 7287 RVA: 0x00071951 File Offset: 0x0006FB51
		public override void OnDeleted()
		{
			base.OnDeleted();
			BaseTextBlock baseTextBlock = this.textBlock;
			if (baseTextBlock != null)
			{
				baseTextBlock.Dispose();
			}
			this.textBlock = null;
		}

		// Token: 0x06001C78 RID: 7288 RVA: 0x00071974 File Offset: 0x0006FB74
		private YogaSize MeasureText(YogaNode node, float width, YogaMeasureMode widthMode, float height, YogaMeasureMode heightMode)
		{
			if (this.textBlock == null)
			{
				return new YogaSize
				{
					width = 2f,
					height = 10f
				};
			}
			Vector2 size = this.textBlock.Measure(width, height);
			return new YogaSize
			{
				width = size.x,
				height = size.y
			};
		}

		// Token: 0x06001C79 RID: 7289 RVA: 0x000719E0 File Offset: 0x0006FBE0
		public Rect GetCaretRect(int i)
		{
			Rect rect = this.textBlock.CaretRect(i);
			rect.Position += this.TextRect.Position;
			rect.width = 2f;
			return rect;
		}

		// Token: 0x06001C7A RID: 7290 RVA: 0x00071A24 File Offset: 0x0006FC24
		internal override void PreLayout(LayoutCascade cascade)
		{
			base.PreLayout(cascade);
			string text2;
			if ((text2 = base.Parent.ComputedStyle.Content) == null)
			{
				text2 = this.Text ?? string.Empty;
			}
			string text = text2;
			if (this.textBlock == null)
			{
				this.textBlock = new SkiaTextBlock();
			}
			this.textBlock.SetText(text);
			if (this.textBlock.UpdateStyles(base.Parent.ComputedStyle))
			{
				this.YogaNode.MarkDirty();
			}
		}

		// Token: 0x06001C7B RID: 7291 RVA: 0x00071AA0 File Offset: 0x0006FCA0
		public override void FinalLayout()
		{
			base.FinalLayout();
			if (!base.IsVisible)
			{
				return;
			}
			BaseTextBlock baseTextBlock = this.textBlock;
			if (baseTextBlock != null)
			{
				baseTextBlock.SizeFinalized(base.Parent.Box.RectInner.width, base.Parent.Box.RectInner.height);
			}
			this.TextRect = base.Parent.Box.RectInner;
			TextAlign? textAlign = base.Parent.ComputedStyle.TextAlign;
			TextAlign textAlign2 = TextAlign.Center;
			if ((textAlign.GetValueOrDefault() == textAlign2) & (textAlign != null))
			{
				this.TextRect.left = this.TextRect.left + (this.TextRect.width - this.textBlock.BlockSize.x) * 0.5f;
			}
			else
			{
				textAlign = base.Parent.ComputedStyle.TextAlign;
				textAlign2 = TextAlign.Right;
				if ((textAlign.GetValueOrDefault() == textAlign2) & (textAlign != null))
				{
					this.TextRect.left = this.TextRect.right - this.textBlock.BlockSize.x;
				}
			}
			Align? alignItems = base.Parent.ComputedStyle.AlignItems;
			Align align = Align.Center;
			if ((alignItems.GetValueOrDefault() == align) & (alignItems != null))
			{
				this.TextRect.top = this.TextRect.top + (this.TextRect.height - this.textBlock.BlockSize.y) * 0.5f;
			}
			else
			{
				alignItems = base.Parent.ComputedStyle.AlignItems;
				align = Align.FlexEnd;
				if ((alignItems.GetValueOrDefault() == align) & (alignItems != null))
				{
					this.TextRect.top = this.TextRect.bottom - this.textBlock.BlockSize.y;
				}
			}
			this.TextRect.Size = this.textBlock.BlockSize;
		}

		// Token: 0x06001C7C RID: 7292 RVA: 0x00071C73 File Offset: 0x0006FE73
		internal override void DrawContent(PanelRenderer renderer, ref RenderState state)
		{
			BaseTextBlock baseTextBlock = this.textBlock;
			if (baseTextBlock == null)
			{
				return;
			}
			baseTextBlock.Render(renderer, ref state, base.Parent.ComputedStyle, base.Parent.Box.RectInner);
		}

		// Token: 0x06001C7D RID: 7293 RVA: 0x00071CA4 File Offset: 0x0006FEA4
		public int GetLetterAt(Vector2 pos)
		{
			if (this.textBlock == null)
			{
				return -1;
			}
			pos += base.Parent.Box.Rect.Position - this.TextRect.Position;
			return this.textBlock.GetLetterAt(pos);
		}

		// Token: 0x06001C7E RID: 7294 RVA: 0x00071CF4 File Offset: 0x0006FEF4
		public int GetLetterAtScreenPosition(Vector2 pos)
		{
			return this.GetLetterAt(base.ScreenPositionToPanelPosition(pos));
		}

		// Token: 0x06001C7F RID: 7295 RVA: 0x00071D04 File Offset: 0x0006FF04
		private void CaretSantity()
		{
			if (this.SelectionStart > this.Text.Length)
			{
				this.SelectionStart = this.Text.Length;
			}
			if (this.SelectionEnd > this.Text.Length)
			{
				this.SelectionEnd = this.Text.Length;
			}
		}

		// Token: 0x06001C80 RID: 7296 RVA: 0x00071D59 File Offset: 0x0006FF59
		public bool HasSelection()
		{
			return this.ShouldDrawSelection && this.SelectionStart != this.SelectionEnd;
		}

		// Token: 0x06001C81 RID: 7297 RVA: 0x00071D78 File Offset: 0x0006FF78
		public string GetSelectedText()
		{
			if (this.Text == null || !this.HasSelection() || !this.Selectable)
			{
				return null;
			}
			this.CaretSantity();
			int s = Math.Min(this.SelectionStart, this.SelectionEnd);
			int e = Math.Max(this.SelectionStart, this.SelectionEnd);
			return this.Text.Substring(s, e - s);
		}

		// Token: 0x040007AF RID: 1967
		internal string _text;

		// Token: 0x040007B0 RID: 1968
		internal Rect TextRect;

		// Token: 0x040007B2 RID: 1970
		internal BaseTextBlock textBlock;
	}
}
