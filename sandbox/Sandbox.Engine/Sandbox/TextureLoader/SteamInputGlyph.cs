using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Sandbox.Internal;
using SkiaSharp;
using Steamworks;

namespace Sandbox.TextureLoader
{
	// Token: 0x020002E8 RID: 744
	internal static class SteamInputGlyph
	{
		// Token: 0x060013C5 RID: 5061 RVA: 0x0002A210 File Offset: 0x00028410
		internal static Texture Load(InputActionOrigin origin, GlyphSize size, SteamInputGlyphStyle style)
		{
			Tuple<InputActionOrigin, GlyphSize, SteamInputGlyphStyle> tuple = Tuple.Create<InputActionOrigin, GlyphSize, SteamInputGlyphStyle>(origin, size, style);
			Texture cachedTexture;
			if (SteamInputGlyph.Loaded.TryGetValue(tuple, out cachedTexture))
			{
				return cachedTexture;
			}
			Texture result;
			try
			{
				Texture placeholder = Texture.Create(1, 1, ImageFormat.RGBA8888).Finish();
				placeholder.IsLoaded = false;
				SteamInputGlyph.LoadIntoTexture(origin, size, style, placeholder);
				SteamInputGlyph.Loaded[tuple] = placeholder;
				result = placeholder;
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't load glyph for action origin {0} ({1})", new object[] { origin, e.Message }));
				result = null;
			}
			return result;
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x0002A2B4 File Offset: 0x000284B4
		internal static async Task LoadIntoTexture(InputActionOrigin origin, GlyphSize size, SteamInputGlyphStyle style, Texture placeholder)
		{
			try
			{
				using (FileStream stream = File.OpenRead(SteamInput.Internal.GetGlyphPNGForActionOrigin(origin, size, (uint)style)))
				{
					ValueTuple<int, int, ImageFormat, int, byte[], int>? result = SteamInputGlyph.DecodeImageGetData(stream, origin.ToString(), size);
					if (result == null)
					{
						placeholder.IsLoaded = true;
					}
					else
					{
						Texture tex = Texture.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3).WithData(result.Value.Item5, result.Value.Item6).WithMips(result.Value.Item4)
							.Finish();
						placeholder.CopyFrom(tex);
						placeholder.IsLoaded = true;
						ArrayPool<byte>.Shared.Return(result.Value.Item5, false);
					}
				}
			}
			finally
			{
				placeholder.IsLoaded = true;
			}
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x0002A310 File Offset: 0x00028510
		[return: TupleElementNames(new string[] { "width", "height", "format", "numMips", "imageData", "byteCount" })]
		private static ValueTuple<int, int, ImageFormat, int, byte[], int>? DecodeImageGetData(Stream stream, string debugName, GlyphSize size)
		{
			ValueTuple<int, int, ImageFormat, int, byte[], int>? result;
			using (Performance.Scope("DecodeImageGetData"))
			{
				try
				{
					using (SKBitmap bitmap = SKBitmap.Decode(stream))
					{
						int width = bitmap.Width;
						int height = bitmap.Height;
						SKColorType colorType = bitmap.ColorType;
						ImageFormat format;
						if (colorType != SKColorType.Bgra8888)
						{
							if (colorType != SKColorType.Gray8)
							{
								GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("bitmap.ColorType is {0} - unsupported", new object[] { bitmap.ColorType }));
								result = null;
								return result;
							}
							format = ImageFormat.I8;
						}
						else
						{
							format = ImageFormat.BGRA8888;
						}
						int iSize = 32;
						switch (size)
						{
						case GlyphSize.Small:
							iSize = 32;
							break;
						case GlyphSize.Medium:
							iSize = 64;
							break;
						case GlyphSize.Large:
							iSize = 128;
							break;
						}
						if (height != iSize)
						{
							GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Resizing Steam Input glyph expected {0}x{1} got {2}x{3} ( {4} )", new object[] { iSize, iSize, width, height, debugName }));
							using (SKBitmap resizedBitmap = bitmap.Resize(new SKSizeI
							{
								Width = iSize,
								Height = iSize
							}, SKFilterQuality.High))
							{
								int rNBumMips = (int)Math.Cbrt((double)Math.Min(resizedBitmap.Width, resizedBitmap.Height));
								ValueTuple<byte[], int> rData = Texture.Utils.GenerateMipDataFromSKBitmap(resizedBitmap, rNBumMips, SKFilterQuality.High);
								return new ValueTuple<int, int, ImageFormat, int, byte[], int>?(new ValueTuple<int, int, ImageFormat, int, byte[], int>(iSize, iSize, format, rNBumMips, rData.Item1, rData.Item2));
							}
						}
						int numMips = (int)Math.Cbrt((double)Math.Min(bitmap.Width, bitmap.Height));
						ValueTuple<byte[], int> data = Texture.Utils.GenerateMipDataFromSKBitmap(bitmap, numMips, SKFilterQuality.High);
						result = new ValueTuple<int, int, ImageFormat, int, byte[], int>?(new ValueTuple<int, int, ImageFormat, int, byte[], int>(width, height, format, numMips, data.Item1, data.Item2));
					}
				}
				catch (Exception)
				{
					GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Error when decoding image: {0}", new object[] { debugName }));
					result = null;
				}
			}
			return result;
		}

		// Token: 0x0400151D RID: 5405
		internal static Dictionary<Tuple<InputActionOrigin, GlyphSize, SteamInputGlyphStyle>, Texture> Loaded = new Dictionary<Tuple<InputActionOrigin, GlyphSize, SteamInputGlyphStyle>, Texture>();
	}
}
