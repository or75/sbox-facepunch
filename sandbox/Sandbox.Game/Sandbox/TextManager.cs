using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Sandbox.UI;
using SkiaSharp;
using Topten.RichTextKit;

namespace Sandbox
{
	/// <summary>
	/// Render text at runtime
	/// </summary>
	// Token: 0x020000ED RID: 237
	internal static class TextManager
	{
		// Token: 0x060013EE RID: 5102 RVA: 0x0005130C File Offset: 0x0004F50C
		internal static TextManager.TextBlock Get(string text, Color color, string font, float size, float? wrapWidth, int fontWeight)
		{
			if (string.IsNullOrWhiteSpace(text))
			{
				throw new ArgumentException("text cannot be empty");
			}
			int hash = HashCode.Combine<string, Color, string, float, float?, int>(text, color, font, size, wrapWidth, fontWeight);
			TextManager.TextBlock textBlock;
			if (TextManager.Dictionary.TryGetValue(hash, out textBlock))
			{
				return textBlock;
			}
			textBlock = new TextManager.TextBlock(text, color, font, size, wrapWidth, fontWeight);
			TextManager.Dictionary[hash] = textBlock;
			return textBlock;
		}

		// Token: 0x060013EF RID: 5103 RVA: 0x00051368 File Offset: 0x0004F568
		[Event.FrameAttribute]
		internal static void Cleanup()
		{
			if (TextManager.timeSinceRan < 5f)
			{
				return;
			}
			TextManager.timeSinceRan = 0f;
			int count = TextManager.Dictionary.Count;
			int deleted = 0;
			foreach (KeyValuePair<int, TextManager.TextBlock> item in TextManager.Dictionary)
			{
				if (item.Value.TimeSinceUsed >= 10f)
				{
					item.Value.Dispose();
					TextManager.Dictionary.TryRemove(item);
					deleted++;
				}
			}
		}

		// Token: 0x040004A8 RID: 1192
		private static ConcurrentDictionary<int, TextManager.TextBlock> Dictionary = new ConcurrentDictionary<int, TextManager.TextBlock>();

		// Token: 0x040004A9 RID: 1193
		private static RealTimeSince timeSinceRan;

		// Token: 0x02000264 RID: 612
		public class TextBlock : IDisposable
		{
			// Token: 0x06001EB4 RID: 7860 RVA: 0x00076A6D File Offset: 0x00074C6D
			public TextBlock(string text, Color color, string font, float size, float? wrapWidth = null, int fontWeight = 400)
			{
				this.Text = text;
				this.FontFamily = font;
				this.FontSize = size;
				this.FontColor = color;
				this.FontWeight = fontWeight;
				this.WrapWidth = wrapWidth;
			}

			// Token: 0x06001EB5 RID: 7861 RVA: 0x00076AA2 File Offset: 0x00074CA2
			public virtual void Dispose()
			{
				Texture texture = this.Texture;
				if (texture != null)
				{
					texture.Dispose();
				}
				this.Texture = null;
			}

			// Token: 0x06001EB6 RID: 7862 RVA: 0x00076ABC File Offset: 0x00074CBC
			public void MakeReady()
			{
				this.TimeSinceUsed = 0f;
				if (this.Texture != null)
				{
					return;
				}
				Style style = new Style();
				style.FontFamily = this.FontFamily;
				style.FontSize = this.FontSize;
				style.FontWeight = this.FontWeight;
				style.FontItalic = false;
				style.TextColor = this.FontColor.ToSk();
				style.Underline = UnderlineStyle.None;
				style.StrikeThrough = StrikeThroughStyle.None;
				style.LetterSpacing = 0f;
				Topten.RichTextKit.TextBlock block = new Topten.RichTextKit.TextBlock();
				block.FontMapper = FontManager.Instance;
				block.MaxWidth = this.WrapWidth;
				block.AddText(this.Text, style);
				int width = block.MeasuredWidth.CeilToInt().Clamp(2, 4096);
				int height = block.MeasuredHeight.CeilToInt().Clamp(2, 4096);
				using (SKBitmap bitmap = new SKBitmap(width, height, SKColorType.Bgra8888, SKAlphaType.Premul))
				{
					using (SKCanvas canvas = new SKCanvas(bitmap))
					{
						TextPaintOptions o = new TextPaintOptions();
						o.Edging = SKFontEdging.Antialias;
						o.Hinting = SKFontHinting.Full;
						SKColor c = this.FontColor.ToSk().WithAlpha(0);
						canvas.Clear(c);
						block.Paint(canvas, o);
						this.Texture = Texture.Create(width, height, ImageFormat.BGRA8888).WithData(bitmap.GetPixels(), width * height * bitmap.BytesPerPixel).WithDynamicUsage()
							.Finish();
					}
				}
			}

			// Token: 0x04001223 RID: 4643
			public Texture Texture;

			// Token: 0x04001224 RID: 4644
			private string Text;

			// Token: 0x04001225 RID: 4645
			private string FontFamily;

			// Token: 0x04001226 RID: 4646
			private float FontSize;

			// Token: 0x04001227 RID: 4647
			private int FontWeight;

			// Token: 0x04001228 RID: 4648
			private Color FontColor;

			// Token: 0x04001229 RID: 4649
			private float? WrapWidth;

			// Token: 0x0400122A RID: 4650
			public RealTimeSince TimeSinceUsed;
		}
	}
}
