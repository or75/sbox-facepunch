using System;

namespace Sandbox.UI
{
	// Token: 0x02000110 RID: 272
	public struct LayoutCascade
	{
		/// <summary>
		/// Some properties cascade from their parent onto children if the children
		/// don't set them. Things like font size, color, cursor.
		/// </summary>
		// Token: 0x060015A2 RID: 5538 RVA: 0x000559E0 File Offset: 0x00053BE0
		internal void ApplyCascading(Styles cached)
		{
			if (cached.PixelSnap == null)
			{
				cached.PixelSnap = this.PixelSnap;
			}
			else
			{
				this.PixelSnap = cached.PixelSnap;
			}
			if (cached.TextTransform == null)
			{
				cached.TextTransform = this.TextTransform;
			}
			else
			{
				this.TextTransform = cached.TextTransform;
			}
			if (cached.Cursor == null)
			{
				cached.Cursor = this.Cursor;
			}
			else
			{
				this.Cursor = cached.Cursor;
			}
			if (cached.PointerEvents == null)
			{
				cached.PointerEvents = this.PointerEvents;
			}
			else
			{
				this.PointerEvents = cached.PointerEvents;
			}
			if (cached.FontSize == null)
			{
				cached.FontSize = this.FontSize;
			}
			else
			{
				this.FontSize = cached.FontSize;
			}
			if (cached.FontColor == null)
			{
				cached.FontColor = this.FontColor;
			}
			else
			{
				this.FontColor = cached.FontColor;
			}
			if (cached.TextStrokeColor == null)
			{
				cached.TextStrokeColor = this.TextStrokeColor;
			}
			else
			{
				this.TextStrokeColor = cached.TextStrokeColor;
			}
			if (cached.TextStrokeWidth == null)
			{
				cached.TextStrokeWidth = this.TextStrokeWidth;
			}
			else
			{
				this.TextStrokeWidth = cached.TextStrokeWidth;
			}
			if (cached.FontWeight == null)
			{
				cached.FontWeight = this.FontWeight;
			}
			else
			{
				this.FontWeight = cached.FontWeight;
			}
			if (cached.TextAlign == null)
			{
				cached.TextAlign = this.TextAlign;
			}
			else
			{
				this.TextAlign = cached.TextAlign;
			}
			if (cached.FontFamily == null)
			{
				cached.FontFamily = this.FontFamily;
			}
			else
			{
				this.FontFamily = cached.FontFamily;
			}
			if (cached.WhiteSpace == null)
			{
				cached.WhiteSpace = this.WhiteSpace;
			}
			else
			{
				this.WhiteSpace = cached.WhiteSpace;
			}
			if (cached.MixBlendMode == null)
			{
				cached.MixBlendMode = this.MixBlendMode;
			}
			else
			{
				this.MixBlendMode = cached.MixBlendMode;
			}
			if (cached.TextDecorationLine == null)
			{
				cached.TextDecorationLine = this.TextDecorationLine;
			}
			else
			{
				this.TextDecorationLine = cached.TextDecorationLine;
			}
			if (cached.TextDecorationColor == null)
			{
				cached.TextDecorationColor = this.TextDecorationColor;
			}
			else
			{
				this.TextDecorationColor = cached.TextDecorationColor;
			}
			if (cached.TextDecorationThickness == null)
			{
				cached.TextDecorationThickness = this.TextDecorationThickness;
			}
			else
			{
				this.TextDecorationThickness = cached.TextDecorationThickness;
			}
			if (cached.TextDecorationSkipInk == null)
			{
				cached.TextDecorationSkipInk = this.TextDecorationSkipInk;
			}
			else
			{
				this.TextDecorationSkipInk = cached.TextDecorationSkipInk;
			}
			if (cached.TextDecorationStyle == null)
			{
				cached.TextDecorationStyle = this.TextDecorationStyle;
			}
			else
			{
				this.TextDecorationStyle = cached.TextDecorationStyle;
			}
			if (cached.FontStyle == null)
			{
				cached.FontStyle = this.FontStyle;
			}
			else
			{
				this.FontStyle = cached.FontStyle;
			}
			if (cached.LetterSpacing == null)
			{
				cached.LetterSpacing = this.LetterSpacing;
			}
			else
			{
				this.LetterSpacing = cached.LetterSpacing;
			}
			if (cached.TextUnderlineOffset == null)
			{
				cached.TextUnderlineOffset = this.TextUnderlineOffset;
			}
			else
			{
				this.TextUnderlineOffset = cached.TextUnderlineOffset;
			}
			if (cached.TextOverlineOffset == null)
			{
				cached.TextOverlineOffset = this.TextOverlineOffset;
			}
			else
			{
				this.TextOverlineOffset = cached.TextOverlineOffset;
			}
			if (cached.TextLineThroughOffset == null)
			{
				cached.TextLineThroughOffset = this.TextLineThroughOffset;
			}
			else
			{
				this.TextLineThroughOffset = cached.TextLineThroughOffset;
			}
			if (cached.ColorInterpolation == null)
			{
				cached.ColorInterpolation = this.ColorInterpolation;
			}
			else
			{
				this.ColorInterpolation = cached.ColorInterpolation;
			}
			if (cached.TextShadow.Count == 0)
			{
				if (this.TextShadow != null)
				{
					cached.TextShadow.AddRange(this.TextShadow);
				}
			}
			else
			{
				this.TextShadow = cached.TextShadow;
			}
			if (cached.Opacity != null)
			{
				this.Opacity *= cached.Opacity.Value;
			}
			cached.Opacity = new float?(this.Opacity);
		}

		// Token: 0x04000517 RID: 1303
		public bool SelectorChanged;

		// Token: 0x04000518 RID: 1304
		public bool SkipTransitions;

		// Token: 0x04000519 RID: 1305
		internal RootPanel Root;

		// Token: 0x0400051A RID: 1306
		public Vector2 Scale;

		// Token: 0x0400051B RID: 1307
		public string Cursor;

		// Token: 0x0400051C RID: 1308
		public string PointerEvents;

		// Token: 0x0400051D RID: 1309
		public string FontFamily;

		// Token: 0x0400051E RID: 1310
		public string MixBlendMode;

		// Token: 0x0400051F RID: 1311
		public string WhiteSpace;

		// Token: 0x04000520 RID: 1312
		public Length? FontSize;

		// Token: 0x04000521 RID: 1313
		public Color? FontColor;

		// Token: 0x04000522 RID: 1314
		public int? FontWeight;

		// Token: 0x04000523 RID: 1315
		public float Opacity;

		// Token: 0x04000524 RID: 1316
		public TextAlign? TextAlign;

		// Token: 0x04000525 RID: 1317
		public ShadowList TextShadow;

		// Token: 0x04000526 RID: 1318
		public int? PixelSnap;

		// Token: 0x04000527 RID: 1319
		public FontStyle? FontStyle;

		// Token: 0x04000528 RID: 1320
		public TextDecoration? TextDecorationLine;

		// Token: 0x04000529 RID: 1321
		public TextSkipInk? TextDecorationSkipInk;

		// Token: 0x0400052A RID: 1322
		public TextDecorationStyle? TextDecorationStyle;

		// Token: 0x0400052B RID: 1323
		public Color? TextDecorationColor;

		// Token: 0x0400052C RID: 1324
		public Length? TextDecorationThickness;

		// Token: 0x0400052D RID: 1325
		public Length? LetterSpacing;

		// Token: 0x0400052E RID: 1326
		public TextTransform? TextTransform;

		// Token: 0x0400052F RID: 1327
		public Color? TextStrokeColor;

		// Token: 0x04000530 RID: 1328
		public Length? TextStrokeWidth;

		// Token: 0x04000531 RID: 1329
		public Length? TextUnderlineOffset;

		// Token: 0x04000532 RID: 1330
		public Length? TextOverlineOffset;

		// Token: 0x04000533 RID: 1331
		public Length? TextLineThroughOffset;

		// Token: 0x04000534 RID: 1332
		public ColorInterpolation? ColorInterpolation;
	}
}
