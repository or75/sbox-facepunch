using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using SkiaSharp;
using Topten.RichTextKit;

namespace Sandbox.UI
{
	// Token: 0x02000114 RID: 276
	internal class FontManager : FontMapper
	{
		// Token: 0x060015A9 RID: 5545 RVA: 0x00056170 File Offset: 0x00054370
		public override SKTypeface TypefaceFromStyle(IStyle style, bool ignoreFontVariants)
		{
			int hash = HashCode.Combine<string, int, bool>(style.FontFamily, style.FontWeight, style.FontItalic);
			SKTypeface cachedFace;
			if (FontManager.Cache.TryGetValue(hash, out cachedFace))
			{
				return cachedFace;
			}
			SKTypeface f = this.TryToLoad(style.FontFamily, (float)style.FontWeight.Clamp(0, 950), style.FontItalic ? "italic" : "");
			if (f == null)
			{
				f = FontMapper.Default.TypefaceFromStyle(style, ignoreFontVariants);
			}
			FontManager.Cache[hash] = f;
			return f;
		}

		/// <summary>
		/// Try to find this font on disk
		/// </summary>
		// Token: 0x060015AA RID: 5546 RVA: 0x000561F8 File Offset: 0x000543F8
		private SKTypeface TryToLoad(string name, float weight, string extra)
		{
			name = name.Replace(" ", "").ToLower();
			extra = extra.ToLower();
			string weightName = this.WeightToText(weight);
			int hash = HashCode.Combine<string, string, string>(name, extra, weightName);
			SKTypeface cachedFace;
			if (FontManager.Cache.TryGetValue(hash, out cachedFace))
			{
				return cachedFace;
			}
			int hash2 = hash;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 3);
			defaultInterpolatedStringHandler.AppendLiteral("/fonts/");
			defaultInterpolatedStringHandler.AppendFormatted(name);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted(weightName);
			defaultInterpolatedStringHandler.AppendFormatted(extra);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			cachedFace = this.TryToLoad(hash2, defaultInterpolatedStringHandler.ToStringAndClear());
			if (cachedFace != null)
			{
				return cachedFace;
			}
			int hash3 = hash;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
			defaultInterpolatedStringHandler.AppendLiteral("/fonts/");
			defaultInterpolatedStringHandler.AppendFormatted(name);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted(weightName);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			cachedFace = this.TryToLoad(hash3, defaultInterpolatedStringHandler.ToStringAndClear());
			if (cachedFace != null)
			{
				return cachedFace;
			}
			if (weight != 400f)
			{
				weight = weight.Approach(400f, 100f);
				SKTypeface f = this.TryToLoad(name, weight, extra);
				if (f != null)
				{
					FontManager.Cache[hash] = f;
					return f;
				}
			}
			cachedFace = this.TryToLoad(hash, "/fonts/" + name + ".");
			if (cachedFace != null)
			{
				return cachedFace;
			}
			FontManager.Cache[hash] = null;
			return null;
		}

		// Token: 0x060015AB RID: 5547 RVA: 0x00056358 File Offset: 0x00054558
		private SKTypeface TryToLoad(int hash, string filename)
		{
			string ttf = filename + "ttf";
			if (FileSystem.Mounted.FileExists(ttf))
			{
				return this.LoadAndCache(hash, ttf);
			}
			string otf = filename + "otf";
			if (FileSystem.Mounted.FileExists(otf))
			{
				return this.LoadAndCache(hash, otf);
			}
			return null;
		}

		// Token: 0x060015AC RID: 5548 RVA: 0x000563AC File Offset: 0x000545AC
		private SKTypeface LoadAndCache(int hash, string fontName)
		{
			SKTypeface face = SKTypeface.FromStream(FileSystem.Mounted.OpenRead(fontName, FileMode.Open), 0);
			FontManager.Cache[hash] = face;
			return face;
		}

		/// <summary>
		/// Given a number, return the closest name weight
		/// </summary>
		// Token: 0x060015AD RID: 5549 RVA: 0x000563DC File Offset: 0x000545DC
		private string WeightToText(float weight)
		{
			if (weight >= 950f)
			{
				return "extrablack";
			}
			if (weight >= 900f)
			{
				return "black";
			}
			if (weight >= 800f)
			{
				return "extrabold";
			}
			if (weight >= 700f)
			{
				return "bold";
			}
			if (weight >= 600f)
			{
				return "semibold";
			}
			if (weight >= 500f)
			{
				return "medium";
			}
			if (weight >= 400f)
			{
				return "regular";
			}
			if (weight >= 350f)
			{
				return "semilight";
			}
			if (weight >= 300f)
			{
				return "light";
			}
			if (weight >= 200f)
			{
				return "extralight";
			}
			return "thin";
		}

		// Token: 0x04000546 RID: 1350
		public static FontManager Instance = new FontManager();

		// Token: 0x04000547 RID: 1351
		private static Dictionary<int, SKTypeface> Cache = new Dictionary<int, SKTypeface>();
	}
}
