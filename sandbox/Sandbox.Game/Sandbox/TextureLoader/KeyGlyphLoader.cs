using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Sandbox.UI;
using SkiaSharp;
using Topten.RichTextKit;

namespace Sandbox.TextureLoader
{
	// Token: 0x0200016A RID: 362
	internal static class KeyGlyphLoader
	{
		// Token: 0x06001B44 RID: 6980 RVA: 0x0006DF20 File Offset: 0x0006C120
		internal static Texture Load(string key, InputGlyphSize size = InputGlyphSize.Small, GlyphStyle style = default(GlyphStyle))
		{
			Tuple<string, InputGlyphSize, GlyphStyle> tuple = Tuple.Create<string, InputGlyphSize, GlyphStyle>(key, size, style);
			Texture cachedTexture;
			if (KeyGlyphLoader.Loaded.TryGetValue(tuple, out cachedTexture))
			{
				return cachedTexture;
			}
			if (KeyGlyphLoader.SpecialGlyphs.ContainsKey(key))
			{
				KeyGlyphLoader.Loaded[tuple] = KeyGlyphLoader.LoadSpecialGlyph(key, size, style);
				return KeyGlyphLoader.Loaded[tuple];
			}
			Texture placeholder = Texture.Create(1, 1, ImageFormat.RGBA8888).Finish();
			placeholder.IsLoaded = false;
			KeyGlyphLoader.LoadIntoTexture(key, size, style, placeholder);
			KeyGlyphLoader.Loaded[tuple] = placeholder;
			return placeholder;
		}

		// Token: 0x06001B45 RID: 6981 RVA: 0x0006DFA4 File Offset: 0x0006C1A4
		internal static Texture LoadSpecialGlyph(string key, InputGlyphSize size, GlyphStyle style)
		{
			string name = KeyGlyphLoader.SpecialGlyphs[key];
			string text;
			switch (style.Style & (GlyphStyleMask)15)
			{
			case GlyphStyleMask.Knockout:
				text = "knockout";
				break;
			case GlyphStyleMask.Light:
				text = "light";
				break;
			case GlyphStyleMask.Dark:
				text = "dark";
				break;
			default:
				text = "knockout";
				break;
			}
			string styleName = text;
			switch (size)
			{
			case InputGlyphSize.Small:
				text = "sm";
				break;
			case InputGlyphSize.Medium:
				text = "md";
				break;
			case InputGlyphSize.Large:
				text = "lg";
				break;
			default:
				text = "sm";
				break;
			}
			string sizeName = text;
			BaseFileSystem mounted = FileSystem.Mounted;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 3);
			defaultInterpolatedStringHandler.AppendLiteral("/ui/input/");
			defaultInterpolatedStringHandler.AppendFormatted(styleName);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(name);
			defaultInterpolatedStringHandler.AppendLiteral("_");
			defaultInterpolatedStringHandler.AppendFormatted(sizeName);
			defaultInterpolatedStringHandler.AppendLiteral(".png");
			return Texture.Load(mounted, defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x06001B46 RID: 6982 RVA: 0x0006E098 File Offset: 0x0006C298
		private static async Task LoadIntoTexture(string key, InputGlyphSize size, GlyphStyle style, Texture placeholder)
		{
			Texture result = KeyGlyphLoader.DrawGlyph(key, size, style);
			placeholder.CopyFrom(result);
			placeholder.IsLoaded = true;
		}

		/// <summary>
		/// Draws a key glyph of the specified size to a Texture.
		/// In a "Knockout" style where the text is cut out, matching Steam Input glyphs.
		/// </summary>
		// Token: 0x06001B47 RID: 6983 RVA: 0x0006E0F4 File Offset: 0x0006C2F4
		private static Texture DrawGlyph(string text, InputGlyphSize size, GlyphStyle style)
		{
			int height = size.ToPixels();
			SKColor BackgroundColor = SKColors.White;
			GlyphStyleMask styleNoMod = style.Style & (GlyphStyleMask)15;
			Style TextStyle = new Style
			{
				FontFamily = "Poppins",
				FontSize = (float)(height / 2),
				FontWeight = 700
			};
			switch (styleNoMod)
			{
			case GlyphStyleMask.Knockout:
				TextStyle.TextColor = SKColors.White;
				BackgroundColor = SKColors.White;
				break;
			case GlyphStyleMask.Light:
				TextStyle.TextColor = KeyGlyphLoader.LightForeground;
				BackgroundColor = KeyGlyphLoader.LightBackground;
				break;
			case GlyphStyleMask.Dark:
				TextStyle.TextColor = KeyGlyphLoader.DarkForeground;
				BackgroundColor = KeyGlyphLoader.DarkBackground;
				break;
			}
			TextBlock TextBlock = new TextBlock
			{
				FontMapper = FontManager.Instance,
				MaxHeight = new float?((float)height),
				Alignment = TextAlignment.Center
			};
			TextBlock.AddText(text, TextStyle);
			int width = Math.Max(height, (int)MathF.Floor(TextBlock.MeasuredWidth) + height / 2);
			float textYOffset = ((float)height - TextBlock.MeasuredHeight) / 2f;
			TextBlock.MaxWidth = new float?((float)width);
			Texture result;
			using (SKBitmap bitmap = new SKBitmap(width, height, SKColorType.Bgra8888, SKAlphaType.Unpremul))
			{
				using (SKCanvas canvas = new SKCanvas(bitmap))
				{
					canvas.Clear(SKColors.White.WithAlpha(0));
					TextPaintOptions o = new TextPaintOptions
					{
						Edging = SKFontEdging.Antialias,
						Hinting = SKFontHinting.Full
					};
					if (styleNoMod == GlyphStyleMask.Knockout)
					{
						TextBlock.Paint(canvas, new SKPoint(0f, textYOffset), o);
						SKPaint rectPaint = new SKPaint
						{
							BlendMode = SKBlendMode.SrcOut,
							Color = BackgroundColor,
							IsAntialias = true
						};
						canvas.DrawRoundRect(1f, 1f, (float)(width - 2), (float)(height - 2), (float)(height / 4), (float)(height / 4), rectPaint);
					}
					else
					{
						SKPaint rectPaint2 = new SKPaint
						{
							Color = BackgroundColor,
							IsAntialias = true
						};
						canvas.DrawRoundRect(1f, 1f, (float)(width - 2), (float)(height - 2), (float)(height / 4), (float)(height / 4), rectPaint2);
						TextBlock.Paint(canvas, new SKPoint(0f, textYOffset), o);
					}
					result = Texture.Create(width, height, ImageFormat.BGRA8888).WithData(bitmap.GetPixels(), width * height * bitmap.BytesPerPixel).WithDynamicUsage()
						.Finish();
				}
			}
			return result;
		}

		// Token: 0x04000771 RID: 1905
		private static readonly SKColor LightBackground = SKColors.White;

		// Token: 0x04000772 RID: 1906
		private static readonly SKColor LightForeground = new SKColor(14, 20, 27);

		// Token: 0x04000773 RID: 1907
		private static readonly SKColor DarkBackground = new SKColor(14, 20, 27);

		// Token: 0x04000774 RID: 1908
		private static readonly SKColor DarkForeground = SKColors.White;

		// Token: 0x04000775 RID: 1909
		private static readonly Dictionary<string, string> SpecialGlyphs = new Dictionary<string, string>
		{
			{ "MOUSE1", "shared_mouse_l_click" },
			{ "MOUSE2", "shared_mouse_r_click" },
			{ "MOUSE3", "shared_mouse_mid_click" },
			{ "MOUSE4", "shared_mouse_4" },
			{ "MOUSE5", "shared_mouse_5" },
			{ "MWHEELUP", "shared_mouse_scroll_up" },
			{ "MWHEELDOWN", "shared_mouse_scroll_down" }
		};

		// Token: 0x04000776 RID: 1910
		private static readonly Dictionary<Tuple<string, InputGlyphSize, GlyphStyle>, Texture> Loaded = new Dictionary<Tuple<string, InputGlyphSize, GlyphStyle>, Texture>();
	}
}
