using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SkiaSharp;
using Topten.RichTextKit;

namespace Sandbox.UI
{
	// Token: 0x02000115 RID: 277
	internal sealed class SkiaTextBlock : BaseTextBlock
	{
		// Token: 0x17000347 RID: 839
		// (get) Token: 0x060015B0 RID: 5552 RVA: 0x00056498 File Offset: 0x00054698
		// (set) Token: 0x060015B1 RID: 5553 RVA: 0x0005649F File Offset: 0x0005469F
		[ClientVar(null, Help = "Enable rendering text to textures")]
		public static bool ui_rendertext { get; set; } = true;

		// Token: 0x060015B2 RID: 5554 RVA: 0x000564A8 File Offset: 0x000546A8
		public override Vector2 Measure(float width, float height)
		{
			if (!float.IsNaN(width))
			{
				width = (float)width.CeilToInt();
			}
			int hash = (int)width;
			if (this.NoWrap)
			{
				width = float.NaN;
			}
			Vector2 size;
			if (this.SizeCache.TryGetValue(hash, out size))
			{
				return size;
			}
			this.Block.MaxWidth = (float.IsNaN(width) ? null : new float?(width + 1f));
			Vector2 s = new Vector2((float)this.Block.MeasuredWidth.CeilToInt(), (float)this.Block.MeasuredHeight.CeilToInt());
			if (this.NoWrap && !float.IsNaN(width))
			{
				s.x = MathF.Min(s.x, width);
			}
			this.SizeCache[hash] = s;
			return s;
		}

		// Token: 0x060015B3 RID: 5555 RVA: 0x00056570 File Offset: 0x00054770
		private void WaitTextureReady()
		{
			if (this.TextureRebuild == null)
			{
				return;
			}
			using (Performance.Scope("TextBlock.WaitRebuild"))
			{
				this.TextureRebuild.Wait();
				this.TextureRebuild = null;
			}
		}

		/// <summary>
		/// Proper Rendering
		/// </summary>
		// Token: 0x060015B4 RID: 5556 RVA: 0x000565C0 File Offset: 0x000547C0
		internal override void Render(PanelRenderer renderer, ref RenderState state, Styles currentStyle, Rect textrect)
		{
			this.WaitTextureReady();
			if (this.Texture == null)
			{
				return;
			}
			if (this.BlockSize == 0.0)
			{
				return;
			}
			TextAlign? textAlign = currentStyle.TextAlign;
			TextAlign textAlign2 = TextAlign.Center;
			if ((textAlign.GetValueOrDefault() == textAlign2) & (textAlign != null))
			{
				textrect.left += (textrect.width - this.BlockSize.x) * 0.5f;
			}
			else
			{
				textAlign = currentStyle.TextAlign;
				textAlign2 = TextAlign.Right;
				if ((textAlign.GetValueOrDefault() == textAlign2) & (textAlign != null))
				{
					textrect.left = textrect.right - this.BlockSize.x;
				}
			}
			Align? alignItems = currentStyle.AlignItems;
			Align align = Align.Center;
			if ((alignItems.GetValueOrDefault() == align) & (alignItems != null))
			{
				textrect.top += (textrect.height - this.BlockSize.y) * 0.5f;
			}
			else
			{
				alignItems = currentStyle.AlignItems;
				align = Align.FlexEnd;
				if ((alignItems.GetValueOrDefault() == align) & (alignItems != null))
				{
					textrect.top = textrect.bottom - this.BlockSize.y;
				}
			}
			textrect.Size = this.Texture.Size;
			textrect.Position -= this.EffectMargin.Position;
			renderer.DrawTextBlock(this.Texture, textrect, currentStyle);
		}

		// Token: 0x060015B5 RID: 5557 RVA: 0x0005672C File Offset: 0x0005492C
		public override Rect CaretRect(int iPos)
		{
			CaretPosition cp = new CaretPosition
			{
				AltPosition = false,
				CodePointIndex = iPos
			};
			CaretInfo pos = this.Block.GetCaretInfo(cp);
			float xPosition = pos.CaretRectangle.Left;
			float yPosition = pos.CaretRectangle.Top;
			if (iPos <= this.Block.Length && iPos > 0 && base.Text[iPos - 1] == '\n')
			{
				int fontRunIndex = this.Block.FindFontRunForCodePointIndex(0);
				CaretInfo ci = this.Block.GetCaretInfo(new CaretPosition
				{
					AltPosition = false,
					CodePointIndex = 0
				});
				if (fontRunIndex >= 0)
				{
					FontRun fr = this.Block.FontRuns[fontRunIndex];
					xPosition = ci.CaretRectangle.Left;
					yPosition += fr.Line.BaseLine + fr.Descent;
				}
			}
			return new Rect(xPosition, yPosition, pos.CaretRectangle.Width, pos.CaretRectangle.Height);
		}

		// Token: 0x060015B6 RID: 5558 RVA: 0x00056836 File Offset: 0x00054A36
		public override int GetLetterAt(Vector2 pos)
		{
			if (this.Block == null)
			{
				return -1;
			}
			return this.Block.HitTest(pos.x, pos.y).ClosestCodePointIndex;
		}

		// Token: 0x060015B7 RID: 5559 RVA: 0x00056860 File Offset: 0x00054A60
		public override bool UpdateStyles(Styles style)
		{
			if (this.TimeSinceRebuild < 0.033333335f)
			{
				return false;
			}
			string fontFamily = style.FontFamily ?? "Arial";
			Color fontColor = style.FontColor ?? Color.Black;
			Length? length = style.FontSize;
			this.FontSize = ((length != null) ? length.GetValueOrDefault().GetPixels(100f) : 13f);
			this.FontSize = MathF.Round(this.FontSize * 20f) / 20f;
			this.FontWeight = style.FontWeight;
			this.TextAlign = style.TextAlign ?? TextAlign.Left;
			this.TextDecoration = style.TextDecorationLine.GetValueOrDefault();
			this.FontStyle = style.FontStyle.GetValueOrDefault();
			this.AlignItems = style.AlignItems ?? Align.FlexStart;
			this.LetterSpacing = style.LetterSpacing;
			this.NoWrap = style.WhiteSpace != null && style.WhiteSpace == "nowrap";
			this.TextTransform = style.TextTransform;
			int hash = HashCode.Combine<float, Color, string, int?, TextAlign, bool, TextDecoration, FontStyle>(this.FontSize, fontColor, fontFamily, this.FontWeight, this.TextAlign, this.NoWrap, this.TextDecoration, this.FontStyle);
			hash = HashCode.Combine<int, Length?, TextTransform?, string, int, int, bool, ShadowList>(hash, this.LetterSpacing, this.TextTransform, base.Text, base.SelectionStart, base.SelectionEnd, this.ShouldDrawSelection, style.TextShadow);
			hash = HashCode.Combine<int, Length?, Color?, Color?, Length?, TextSkipInk?, TextDecorationStyle?>(hash, style.TextStrokeWidth, style.TextStrokeColor, style.TextDecorationColor, style.TextDecorationThickness, style.TextDecorationSkipInk, style.TextDecorationStyle);
			hash = HashCode.Combine<int, Length?, Length?, Length?>(hash, style.TextUnderlineOffset, style.TextOverlineOffset, style.TextLineThroughOffset);
			if (this.FontHash == hash && this.Block != null)
			{
				return false;
			}
			this.TimeSinceRebuild = 0f;
			this.FontHash = hash;
			if (this.Style == null)
			{
				this.Style = new Style();
			}
			this.Style.FontFamily = fontFamily;
			this.Style.FontSize = this.FontSize;
			this.Style.FontWeight = this.FontWeight ?? 400;
			this.Style.FontItalic = this.FontStyle > FontStyle.None;
			this.Style.TextColor = fontColor.ToSk();
			this.Style.Underline = UnderlineStyle.None;
			this.Style.StrokeInkSkip = style.TextDecorationSkipInk.GetValueOrDefault() == TextSkipInk.All;
			Style style2 = this.Style;
			length = style.TextUnderlineOffset;
			style2.UnderlineOffset = ((length != null) ? length.GetValueOrDefault().GetPixels(100f) : 0f);
			Style style3 = this.Style;
			length = style.TextOverlineOffset;
			style3.OverlineOffset = ((length != null) ? length.GetValueOrDefault().GetPixels(100f) : 0f);
			Style style4 = this.Style;
			length = style.TextLineThroughOffset;
			style4.StrikeThroughOffset = ((length != null) ? length.GetValueOrDefault().GetPixels(100f) : 0f);
			TextDecorationStyle? textDecorationStyle = style.TextDecorationStyle;
			if (textDecorationStyle != null)
			{
				switch (textDecorationStyle.GetValueOrDefault())
				{
				case TextDecorationStyle.Solid:
					this.Style.UnderlineStrokeType = UnderlineType.Solid;
					goto IL_3E8;
				case TextDecorationStyle.Double:
					this.Style.UnderlineStrokeType = UnderlineType.Double;
					goto IL_3E8;
				case TextDecorationStyle.Dotted:
					this.Style.UnderlineStrokeType = UnderlineType.Dotted;
					goto IL_3E8;
				case TextDecorationStyle.Dashed:
					this.Style.UnderlineStrokeType = UnderlineType.Dashed;
					goto IL_3E8;
				case TextDecorationStyle.Wavy:
					this.Style.UnderlineStrokeType = UnderlineType.Wavy;
					goto IL_3E8;
				}
			}
			this.Style.UnderlineStrokeType = UnderlineType.Solid;
			IL_3E8:
			this.Style.UnderlineColor = new SKColor?((style.TextDecorationColor ?? fontColor).ToSk());
			Style style5 = this.Style;
			length = style.TextDecorationThickness;
			style5.StrokeThickness = ((length != null) ? new float?(length.GetValueOrDefault().GetPixels(100f)) : null);
			this.Style.Underline |= (((this.TextDecoration & TextDecoration.Underline) != TextDecoration.None) ? UnderlineStyle.Gapped : UnderlineStyle.None);
			this.Style.Underline |= (((this.TextDecoration & TextDecoration.Overline) != TextDecoration.None) ? UnderlineStyle.Overline : UnderlineStyle.None);
			this.Style.StrikeThrough = (((this.TextDecoration & TextDecoration.LineThrough) != TextDecoration.None) ? StrikeThroughStyle.Solid : StrikeThroughStyle.None);
			this.Style.LetterSpacing = ((this.LetterSpacing != null) ? this.LetterSpacing.GetValueOrDefault().GetPixels(1000f) : 0f);
			this.Style.ClearEffects();
			this.EffectMargin = default(Margin);
			if (style.TextShadow != null && !style.TextShadow.IsNone)
			{
				foreach (Shadow shadow in style.TextShadow)
				{
					TextEffect effect = TextEffect.DropShadow(shadow.Color.ToSk(), shadow.OffsetX, shadow.OffsetY, shadow.Blur);
					effect.Width += shadow.Blur * 0.25f;
					effect.BlurSize = MathF.Max(effect.BlurSize, 0.01f);
					this.Style.AddEffect(effect);
					float shadowSize = (effect.Width + shadow.Blur) * 2f;
					this.EffectMargin.left = (float)MathF.Max(this.EffectMargin.left, shadowSize + -shadow.OffsetX).CeilToInt();
					this.EffectMargin.right = (float)MathF.Max(this.EffectMargin.right, shadowSize + shadow.OffsetX).CeilToInt();
					this.EffectMargin.top = (float)MathF.Max(this.EffectMargin.top, shadowSize + -shadow.OffsetY).CeilToInt();
					this.EffectMargin.bottom = (float)MathF.Max(this.EffectMargin.bottom, shadowSize + shadow.OffsetY).CeilToInt();
				}
			}
			length = style.TextStrokeWidth;
			if (length != null)
			{
				length = style.TextStrokeWidth;
				if (length.Value.Value > 0f)
				{
					Color c = style.TextStrokeColor ?? style.FontColor ?? Color.Black;
					length = style.TextStrokeWidth;
					float size = length.Value.GetPixels(1f);
					TextEffect effect2 = TextEffect.Outline(c.ToSk(), size);
					effect2.StrokeMiter = 10f + MathF.Sin(RealTime.Now * 10f) * 10f;
					effect2.StrkeJoin = SKStrokeJoin.Round;
					this.Style.AddEffect(effect2);
					this.EffectMargin.left = (float)MathF.Max(this.EffectMargin.left, size).CeilToInt();
					this.EffectMargin.right = (float)MathF.Max(this.EffectMargin.right, size).CeilToInt();
					this.EffectMargin.top = (float)MathF.Max(this.EffectMargin.top, size).CeilToInt();
					this.EffectMargin.bottom = (float)MathF.Max(this.EffectMargin.bottom, size).CeilToInt();
				}
			}
			if (this.Block == null)
			{
				this.Block = new TextBlock();
				this.Block.FontMapper = FontManager.Instance;
			}
			this.Block.Clear();
			this.Block.AddText(this.FixedText(base.Text), this.Style);
			this.SizeCache.Clear();
			this.ReleaseTexture();
			return true;
		}

		// Token: 0x060015B8 RID: 5560 RVA: 0x000570C0 File Offset: 0x000552C0
		private void ReleaseTexture()
		{
			this.WaitTextureReady();
			if (this.Texture == null)
			{
				return;
			}
			Texture texture = this.Texture;
			if (texture != null)
			{
				texture.Dispose();
			}
			this.Texture = null;
		}

		/// <summary>
		/// Called on layout. We should decide here if we actually need to rebuild
		/// </summary>
		// Token: 0x060015B9 RID: 5561 RVA: 0x000570EC File Offset: 0x000552EC
		public override void SizeFinalized(float width, float height)
		{
			this.WaitTextureReady();
			width = (float)width.CeilToInt();
			height = (float)height.CeilToInt();
			int sizeHash = this.Measure(width, height).GetHashCode();
			if (this.lastSizeHash != sizeHash)
			{
				this.ReleaseTexture();
				this.lastSizeHash = sizeHash;
				if (base.Text.Length == 0)
				{
					this.BlockSize = new Vector2((float)this.Block.MeasuredWidth.CeilToInt().Clamp(2, 4096), (float)this.Block.MeasuredHeight.CeilToInt().Clamp(2, 4096));
				}
			}
			if (base.Text.Length == 0)
			{
				return;
			}
			if (this.Texture == null)
			{
				this.RebuildTexture(width, height);
			}
		}

		/// <summary>
		/// Actually recreate the texture
		/// </summary>
		// Token: 0x060015BA RID: 5562 RVA: 0x000571AC File Offset: 0x000553AC
		private void RebuildTexture(float maxwidth, float maxheight)
		{
			if (!SkiaTextBlock.ui_rendertext)
			{
				return;
			}
			bool flag = base.Text.Length == 0;
			bool computeMipMaps = this.TextTransform != null;
			this.Block.MaxWidth = (this.NoWrap ? null : new float?((float)(maxwidth.CeilToInt() + 1)));
			int width = this.Block.MeasuredWidth.CeilToInt().Clamp(2, 4096);
			int height = this.Block.MeasuredHeight.CeilToInt().Clamp(2, 4096);
			if (this.Style.LetterSpacing < 0f)
			{
				width += Math.Abs((int)MathF.Floor(this.Style.LetterSpacing));
			}
			this.BlockSize = new Vector2((float)width, (float)height);
			Vector2 marginEdge = this.EffectMargin.EdgeSize;
			width += marginEdge.x.CeilToInt();
			height += marginEdge.y.CeilToInt();
			if (flag)
			{
				return;
			}
			using (Performance.Scope("TextBlock.RebuildTexture"))
			{
				using (SKBitmap bitmap = new SKBitmap(width, height, SKColorType.Bgra8888, SKAlphaType.Unpremul))
				{
					using (SKCanvas canvas = new SKCanvas(bitmap))
					{
						TextPaintOptions o = new TextPaintOptions();
						o.Edging = SKFontEdging.Antialias;
						o.Hinting = SKFontHinting.Full;
						canvas.Clear(this.Style.TextColor.WithAlpha(0));
						if (this.ShouldDrawSelection && (base.SelectionStart > 0 || base.SelectionEnd > 0))
						{
							o.Selection = new TextRange?(new TextRange(base.SelectionStart, base.SelectionEnd, false));
							o.SelectionColor = Color.Yellow.ToSk();
						}
						this.Block.Paint(canvas, new SKPoint(this.EffectMargin.left, this.EffectMargin.top), o);
						if (!computeMipMaps)
						{
							this.Texture = Texture.Create(width, height, ImageFormat.BGRA8888).WithData(bitmap.GetPixels(), width * height * bitmap.BytesPerPixel).WithDynamicUsage()
								.Finish();
						}
						else
						{
							int numMips = (int)Math.Cbrt((double)Math.Min(bitmap.Width, bitmap.Height));
							ValueTuple<byte[], int> imageData = Texture.Utils.GenerateMipDataFromSKBitmap(bitmap, numMips, SKFilterQuality.Low);
							this.Texture = Texture.Create(width, height, ImageFormat.BGRA8888).WithData(imageData.Item1, imageData.Item2).WithMips(numMips)
								.Finish();
							ArrayPool<byte>.Shared.Return(imageData.Item1, false);
						}
					}
				}
			}
		}

		// Token: 0x060015BB RID: 5563 RVA: 0x00057498 File Offset: 0x00055698
		private string FixedText(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return ".";
			}
			text = text.Replace("\t", " ");
			text = text.Replace("\r\n", new string('\u2029', 1));
			text = text.Replace('\n', '\u2029');
			if (this.TextTransform != null)
			{
				switch (this.TextTransform.Value)
				{
				case Sandbox.UI.TextTransform.Capitalize:
					text = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(text);
					break;
				case Sandbox.UI.TextTransform.Uppercase:
					text = text.ToUpperInvariant();
					break;
				case Sandbox.UI.TextTransform.Lowercase:
					text = text.ToLowerInvariant();
					break;
				}
			}
			return text;
		}

		// Token: 0x060015BC RID: 5564 RVA: 0x00057547 File Offset: 0x00055747
		public override void Dispose()
		{
			this.ReleaseTexture();
			this.Block = null;
			this.Style = null;
			this.SizeCache = null;
		}

		// Token: 0x04000549 RID: 1353
		private Texture Texture;

		// Token: 0x0400054A RID: 1354
		private TextBlock Block;

		// Token: 0x0400054B RID: 1355
		private Style Style;

		// Token: 0x0400054C RID: 1356
		private int FontHash;

		// Token: 0x0400054D RID: 1357
		private float FontSize;

		// Token: 0x0400054E RID: 1358
		private int? FontWeight;

		// Token: 0x0400054F RID: 1359
		private TextAlign TextAlign;

		// Token: 0x04000550 RID: 1360
		private TextDecoration TextDecoration;

		// Token: 0x04000551 RID: 1361
		private FontStyle FontStyle;

		// Token: 0x04000552 RID: 1362
		private TextTransform? TextTransform;

		// Token: 0x04000553 RID: 1363
		private Length? LetterSpacing;

		// Token: 0x04000554 RID: 1364
		private Align AlignItems;

		// Token: 0x04000555 RID: 1365
		private bool NoWrap;

		// Token: 0x04000556 RID: 1366
		private Margin EffectMargin;

		// Token: 0x04000557 RID: 1367
		private Dictionary<int, Vector2> SizeCache = new Dictionary<int, Vector2>();

		// Token: 0x04000558 RID: 1368
		private int lastSizeHash;

		// Token: 0x04000559 RID: 1369
		private Task TextureRebuild;
	}
}
