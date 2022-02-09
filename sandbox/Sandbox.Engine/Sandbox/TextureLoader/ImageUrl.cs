using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Sandbox.Internal;
using SkiaSharp;

namespace Sandbox.TextureLoader
{
	// Token: 0x020002E6 RID: 742
	internal static class ImageUrl
	{
		// Token: 0x060013BD RID: 5053 RVA: 0x00029E0F File Offset: 0x0002800F
		internal static bool IsAppropriate(string url)
		{
			return url.StartsWith("https://");
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x00029E1C File Offset: 0x0002801C
		internal static Texture Load(string filename, bool warnOnMissing)
		{
			Texture cachedTexture;
			if (ImageUrl.Loaded.TryGetValue(filename, out cachedTexture))
			{
				return cachedTexture;
			}
			Texture result;
			try
			{
				Texture placeholder = Texture.Create(1, 1, ImageFormat.RGBA8888).Finish();
				placeholder.IsLoaded = false;
				ImageUrl.LoadIntoTexture(filename, placeholder);
				ImageUrl.Loaded[filename] = placeholder;
				result = placeholder;
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't Load from Url {0} ({1})", new object[] { filename, e.Message }));
				result = null;
			}
			return result;
		}

		// Token: 0x060013BF RID: 5055 RVA: 0x00029EAC File Offset: 0x000280AC
		internal static async Task LoadIntoTexture(string url, Texture placeholder)
		{
			if (ImageUrl.HttpClient == null)
			{
				ImageUrl.HttpClient = new HttpClient();
			}
			string url2 = url;
			try
			{
				Stream stream2 = await ImageUrl.HttpClient.GetStreamAsync(url);
				using (Stream stream = stream2)
				{
					ValueTuple<int, int, ImageFormat, int, byte[], int>? result = await Task.Run<ValueTuple<int, int, ImageFormat, int, byte[], int>?>(() => ImageUrl.DecodeImageGetData(stream, url));
					if (result == null)
					{
						placeholder.IsLoaded = true;
					}
					else
					{
						placeholder.CopyFrom(Texture.Create(result.Value.Item1, result.Value.Item2, result.Value.Item3).WithData(result.Value.Item5, result.Value.Item6).WithMips(result.Value.Item4)
							.Finish());
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

		// Token: 0x060013C0 RID: 5056 RVA: 0x00029EF8 File Offset: 0x000280F8
		[return: TupleElementNames(new string[] { "width", "height", "format", "numMips", "imageData", "byteCount" })]
		private static ValueTuple<int, int, ImageFormat, int, byte[], int>? DecodeImageGetData(Stream stream, string debugName)
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

		/// <summary>
		/// For textures loaded from the web we want to keep them around a bit longer
		/// </summary>
		// Token: 0x0400151B RID: 5403
		private static Dictionary<string, Texture> Loaded = new Dictionary<string, Texture>();

		// Token: 0x0400151C RID: 5404
		private static HttpClient HttpClient;
	}
}
