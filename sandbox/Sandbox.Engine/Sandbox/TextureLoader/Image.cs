using System;
using System.Buffers;
using System.IO;
using System.Runtime.CompilerServices;
using Sandbox.Internal;
using SkiaSharp;

namespace Sandbox.TextureLoader
{
	// Token: 0x020002E7 RID: 743
	public static class Image
	{
		// Token: 0x060013C2 RID: 5058 RVA: 0x0002A040 File Offset: 0x00028240
		internal static bool IsAppropriate(string url)
		{
			return url.EndsWith(".png") || url.EndsWith(".jpg");
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x0002A05C File Offset: 0x0002825C
		public static Texture Load(Stream stream)
		{
			Texture result;
			using (SKBitmap bitmap = SKBitmap.Decode(stream))
			{
				SKColorType colorType = bitmap.ColorType;
				ImageFormat format;
				if (colorType != SKColorType.Bgra8888)
				{
					if (colorType != SKColorType.Gray8)
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(34, 1);
						defaultInterpolatedStringHandler.AppendLiteral("bitmap.ColorType is ");
						defaultInterpolatedStringHandler.AppendFormatted<SKColorType>(bitmap.ColorType);
						defaultInterpolatedStringHandler.AppendLiteral(" - unsupported");
						throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					format = ImageFormat.I8;
				}
				else
				{
					format = ImageFormat.BGRA8888;
				}
				int numMips = (int)Math.Cbrt((double)Math.Min(bitmap.Width, bitmap.Height));
				ValueTuple<byte[], int> imageData = Texture.Utils.GenerateMipDataFromSKBitmap(bitmap, numMips, SKFilterQuality.High);
				Texture texture = Texture.Create(bitmap.Width, bitmap.Height, format).WithData(imageData.Item1, imageData.Item2).WithMips(numMips)
					.Finish();
				ArrayPool<byte>.Shared.Return(imageData.Item1, false);
				result = texture;
			}
			return result;
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x0002A15C File Offset: 0x0002835C
		public static Texture Load(BaseFileSystem filesystem, string filename, bool warnOnMissing = true)
		{
			filename = filename.Normalize();
			try
			{
				using (Stream stream = filesystem.OpenRead(filename, FileMode.Open))
				{
					return Image.Load(stream);
				}
			}
			catch (FileNotFoundException e)
			{
				if (warnOnMissing)
				{
					GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Image.Load: {0} not found ({1})", new object[] { filename, e.Message }));
				}
			}
			catch (Exception e2)
			{
				GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("{0}: {1}", new object[] { filename, e2.Message }));
			}
			return null;
		}
	}
}
