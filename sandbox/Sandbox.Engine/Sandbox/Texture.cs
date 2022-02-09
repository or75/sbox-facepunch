using System;
using System.Buffers;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using NativeEngine;
using NativeGlue;
using Sandbox.TextureLoader;
using SkiaSharp;

namespace Sandbox
{
	// Token: 0x020002C9 RID: 713
	[Hotload.SkipAttribute]
	[ResourceType("vtex")]
	public class Texture : IDisposable
	{
		// Token: 0x06001239 RID: 4665 RVA: 0x00026454 File Offset: 0x00024654
		public static Texture2DBuilder Create(int width, int height, ImageFormat format = ImageFormat.RGBA8888)
		{
			return new Texture2DBuilder
			{
				Width = width,
				Height = height,
				Format = format
			};
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x00026484 File Offset: 0x00024684
		public static Texture3DBuilder CreateVolume(int width, int height, int depth, ImageFormat format = ImageFormat.RGBA8888)
		{
			return new Texture3DBuilder
			{
				Width = width,
				Height = height,
				Depth = depth,
				Format = format
			};
		}

		// Token: 0x0600123B RID: 4667 RVA: 0x000264BC File Offset: 0x000246BC
		public static TextureBuilder CreateCustom()
		{
			return default(TextureBuilder);
		}

		// Token: 0x0600123C RID: 4668 RVA: 0x000264D4 File Offset: 0x000246D4
		public static TextureCubeBuilder CreateCube()
		{
			return default(TextureCubeBuilder);
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x000264EC File Offset: 0x000246EC
		public static TextureArrayBuilder CreateArray()
		{
			return default(TextureArrayBuilder);
		}

		// Token: 0x0600123E RID: 4670 RVA: 0x00026504 File Offset: 0x00024704
		public static TextureBuilder CreateRenderTarget()
		{
			TextureBuilder builder = default(TextureBuilder);
			builder.common.m_nDepth = 1;
			if (builder.common.m_nNumMipLevels <= 0)
			{
				builder.common.m_nNumMipLevels = 1;
			}
			builder.common.m_nFlags = builder.common.m_nFlags | TextureSpecificationFlags.TSPEC_RENDER_TARGET;
			builder.common.m_nFlags = builder.common.m_nFlags | TextureSpecificationFlags.TSPEC_RENDER_TARGET_SAMPLEABLE;
			builder.m_nUsage = TextureUsage.TEXTURE_USAGE_GPU_ONLY;
			builder.m_nScope = TextureScope.TEXTURE_SCOPE_GLOBAL;
			return builder;
		}

		// Token: 0x0600123F RID: 4671 RVA: 0x00026574 File Offset: 0x00024774
		internal Texture(ITexture native)
		{
			if (native.IsNull)
			{
				throw new Exception("Texture pointer cannot be null!");
			}
			this.native = native;
			this.desc = RenderDevice.GetOnDiskTextureDesc(native);
		}

		// Token: 0x06001240 RID: 4672 RVA: 0x000265AC File Offset: 0x000247AC
		~Texture()
		{
			if (this.native.IsValid)
			{
				this.native.DestroyStrongHandle();
				this.native = default(ITexture);
			}
		}

		/// <summary>
		/// Replace our strong handle with a copy of the strong handle of the passed texture
		/// Which means that this texture will invisbly become that texture.
		/// I suspect that there might be a decent way to do this in native using the resource system.
		/// In which case we should change all this code to use that way instead of doing this.
		/// </summary>
		// Token: 0x06001241 RID: 4673 RVA: 0x000265F8 File Offset: 0x000247F8
		internal void CopyFrom(Texture texture)
		{
			this.Dispose();
			this.native = texture.native.CopyStrongHandle();
			this.desc = RenderDevice.GetOnDiskTextureDesc(this.native);
		}

		// Token: 0x1700036B RID: 875
		// (get) Token: 0x06001242 RID: 4674 RVA: 0x00026622 File Offset: 0x00024822
		internal CTextureDesc Desc
		{
			get
			{
				return this.desc;
			}
		}

		// Token: 0x1700036C RID: 876
		// (get) Token: 0x06001243 RID: 4675 RVA: 0x0002662A File Offset: 0x0002482A
		public int Width
		{
			get
			{
				return (int)this.Desc.m_nWidth;
			}
		}

		// Token: 0x1700036D RID: 877
		// (get) Token: 0x06001244 RID: 4676 RVA: 0x00026637 File Offset: 0x00024837
		public int Height
		{
			get
			{
				return (int)this.Desc.m_nHeight;
			}
		}

		/// <summary>
		/// Returns a Vector2 representing the size of the texure (width, height)
		/// </summary>
		// Token: 0x1700036E RID: 878
		// (get) Token: 0x06001245 RID: 4677 RVA: 0x00026644 File Offset: 0x00024844
		public Vector2 Size
		{
			get
			{
				return new Vector2((float)this.Width, (float)this.Height);
			}
		}

		// Token: 0x1700036F RID: 879
		// (get) Token: 0x06001246 RID: 4678 RVA: 0x00026659 File Offset: 0x00024859
		// (set) Token: 0x06001247 RID: 4679 RVA: 0x00026661 File Offset: 0x00024861
		public bool IsLoaded { get; internal set; } = true;

		// Token: 0x17000370 RID: 880
		// (get) Token: 0x06001248 RID: 4680 RVA: 0x0002666A File Offset: 0x0002486A
		public ImageFormat ImageFormat
		{
			get
			{
				return this.Desc.m_nImageFormat;
			}
		}

		// Token: 0x17000371 RID: 881
		// (get) Token: 0x06001249 RID: 4681 RVA: 0x00026677 File Offset: 0x00024877
		internal RenderMultisampleType MultisampleType
		{
			get
			{
				if (!this.native.IsValid)
				{
					return RenderMultisampleType.RENDER_MULTISAMPLE_NONE;
				}
				return RenderDevice.GetTextureMultisampleType(this.native);
			}
		}

		/// <summary>
		/// Will release the handle for this texture. If the texture isn't referenced by anything
		/// else it'll be released properly. This will happen anyway because it's called in the destructor.
		/// By calling it manually you're just telling the engine you're done with this texture right now
		/// instead of waiting for the garbage collector.
		/// </summary>
		// Token: 0x0600124A RID: 4682 RVA: 0x00026693 File Offset: 0x00024893
		public void Dispose()
		{
			if (!this.native.IsNull)
			{
				this.native.DestroyStrongHandle();
				this.native = IntPtr.Zero;
			}
		}

		// Token: 0x0600124B RID: 4683 RVA: 0x000266C0 File Offset: 0x000248C0
		internal void TryReload(BaseFileSystem filesystem, string filename)
		{
			Texture newTex = Texture.TryToLoad(filesystem, filename, false);
			if (newTex != null)
			{
				this.CopyFrom(newTex);
			}
		}

		// Token: 0x0600124C RID: 4684 RVA: 0x000266E0 File Offset: 0x000248E0
		public static Texture Load(BaseFileSystem filesystem, string filename, bool warnOnMissing = true)
		{
			if (string.IsNullOrWhiteSpace(filename))
			{
				return null;
			}
			filename = filename.NormalizeFilename(false);
			Texture tex = Texture.Find(filename);
			if (tex == null)
			{
				tex = Texture.TryToLoad(filesystem, filename, warnOnMissing);
				Texture.Loaded[filename] = new WeakReference<Texture>(tex);
			}
			return tex;
		}

		/// <summary>
		/// This version is able to load http images - but not images from disk
		/// </summary>
		// Token: 0x0600124D RID: 4685 RVA: 0x00026725 File Offset: 0x00024925
		public static Texture Load(string filename, bool warnOnMissing = true)
		{
			return Texture.Load(null, filename, warnOnMissing);
		}

		// Token: 0x0600124E RID: 4686 RVA: 0x00026730 File Offset: 0x00024930
		public static Texture LoadAvatar(long steamid)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("avatar:");
			defaultInterpolatedStringHandler.AppendFormatted<long>(steamid);
			return Texture.Load(defaultInterpolatedStringHandler.ToStringAndClear(), false);
		}

		// Token: 0x0600124F RID: 4687 RVA: 0x00026767 File Offset: 0x00024967
		public static Texture LoadAvatar(string steamid)
		{
			return Texture.Load("avatar:" + steamid, false);
		}

		// Token: 0x06001250 RID: 4688 RVA: 0x0002677C File Offset: 0x0002497C
		internal static void Hotload(BaseFileSystem filesystem, string filename)
		{
			WeakReference<Texture> texture;
			Texture target;
			if (Texture.Loaded.TryGetValue(filename, out texture) && texture.TryGetTarget(out target))
			{
				target.TryReload(filesystem, filename);
			}
		}

		// Token: 0x06001251 RID: 4689 RVA: 0x000267AA File Offset: 0x000249AA
		internal static Texture TryToLoad(BaseFileSystem filesystem, string filename, bool warnOnMissing = true)
		{
			if (ImageUrl.IsAppropriate(filename))
			{
				return ImageUrl.Load(filename, warnOnMissing);
			}
			if (filesystem != null && Image.IsAppropriate(filename))
			{
				return Image.Load(filesystem, filename, warnOnMissing);
			}
			if (Avatar.IsAppropriate(filename))
			{
				return Avatar.Load(filename);
			}
			return new Texture(Resources.GetTexture(filename));
		}

		/// <summary>
		/// Load a texture asyncronously. Will return when the texture is loaded and valid.
		/// This is useful when loading textures from the web.
		/// </summary>
		// Token: 0x06001252 RID: 4690 RVA: 0x000267EC File Offset: 0x000249EC
		public static async Task<Texture> LoadAsync(BaseFileSystem filesystem, string filename, bool warnOnMissing = true)
		{
			Texture t = Texture.Load(filesystem, filename, warnOnMissing);
			Texture result;
			if (t == null)
			{
				result = null;
			}
			else
			{
				while (!t.IsLoaded)
				{
					await Task.Delay(10);
				}
				result = t;
			}
			return result;
		}

		// Token: 0x06001253 RID: 4691 RVA: 0x00026840 File Offset: 0x00024A40
		public static Texture Find(string filename)
		{
			if (string.IsNullOrWhiteSpace(filename))
			{
				return null;
			}
			filename = filename.NormalizeFilename(false);
			WeakReference<Texture> val;
			Texture target;
			if (Texture.Loaded.TryGetValue(filename, out val) && val.TryGetTarget(out target))
			{
				return target;
			}
			return null;
		}

		// Token: 0x17000372 RID: 882
		// (get) Token: 0x06001254 RID: 4692 RVA: 0x0002687C File Offset: 0x00024A7C
		// (set) Token: 0x06001255 RID: 4693 RVA: 0x00026883 File Offset: 0x00024A83
		public static Texture Invalid { get; internal set; }

		// Token: 0x17000373 RID: 883
		// (get) Token: 0x06001256 RID: 4694 RVA: 0x0002688B File Offset: 0x00024A8B
		// (set) Token: 0x06001257 RID: 4695 RVA: 0x00026892 File Offset: 0x00024A92
		public static Texture White { get; internal set; }

		// Token: 0x17000374 RID: 884
		// (get) Token: 0x06001258 RID: 4696 RVA: 0x0002689A File Offset: 0x00024A9A
		// (set) Token: 0x06001259 RID: 4697 RVA: 0x000268A1 File Offset: 0x00024AA1
		public static Texture Transparent { get; internal set; }

		// Token: 0x0600125A RID: 4698 RVA: 0x000268AC File Offset: 0x00024AAC
		internal static void InitStaticTextures()
		{
			Texture.Invalid = Texture.Create(1, 1, ImageFormat.RGBA8888).WithData(new byte[] { byte.MaxValue, 0, byte.MaxValue, byte.MaxValue }).Finish();
			Texture.White = Texture.Create(1, 1, ImageFormat.RGBA8888).WithData(new byte[] { byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue }).Finish();
			Texture.Transparent = Texture.Create(1, 1, ImageFormat.RGBA8888).WithData(new byte[] { 128, 128, 128, 0 }).Finish();
		}

		// Token: 0x0600125B RID: 4699 RVA: 0x00026943 File Offset: 0x00024B43
		public void Update(ReadOnlySpan<byte> data, int x = 0, int y = 0, int width = 0, int height = 0)
		{
			this.UpdateInternal(data, x, y, 0, width, height, 1);
		}

		// Token: 0x0600125C RID: 4700 RVA: 0x00026954 File Offset: 0x00024B54
		private unsafe void UpdateInternal(ReadOnlySpan<byte> data, int x, int y, int z, int width, int height, int depth)
		{
			if (this.native.IsNull)
			{
				throw new ObjectDisposedException("Texture");
			}
			if (data == null)
			{
				throw new ArgumentException("Texture data should not be null");
			}
			int memRequired = ImageLoader.GetMemRequired(width, height, depth, this.ImageFormat, false);
			if (data.Length < memRequired)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(55, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Length);
				defaultInterpolatedStringHandler.AppendLiteral(" bytes is not enough data to update texture! ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(memRequired);
				defaultInterpolatedStringHandler.AppendLiteral(" required.");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			fixed (byte* pinnableReference = data.GetPinnableReference())
			{
				byte* dataPtr = pinnableReference;
				RenderDevice.AsyncSetTextureData2(this.native, (IntPtr)((void*)dataPtr), (data != null) ? data.Length : 0, new Rect3D(x, y, z, width, height, depth));
			}
		}

		// Token: 0x0400146D RID: 5229
		internal ITexture native;

		// Token: 0x0400146E RID: 5230
		internal CTextureDesc desc;

		// Token: 0x04001470 RID: 5232
		private static Dictionary<string, WeakReference<Texture>> Loaded = new Dictionary<string, WeakReference<Texture>>();

		// Token: 0x0200041A RID: 1050
		public static class Utils
		{
			// Token: 0x06001811 RID: 6161 RVA: 0x00038328 File Offset: 0x00036528
			[return: TupleElementNames(new string[] { "data", "byteCount" })]
			internal static ValueTuple<byte[], int> GenerateMipDataFromSKBitmap(SKBitmap bitmap, int numMips, SKFilterQuality quality = SKFilterQuality.High)
			{
				ValueTuple<byte[], int> result;
				using (Performance.Scope("GenerateMipDataFromSKBitmap"))
				{
					SKBitmap[] pixels = new SKBitmap[numMips];
					pixels[0] = bitmap;
					int byteCount = pixels[0].ByteCount;
					for (int i = 1; i < numMips; i++)
					{
						int d = (int)Math.Pow(2.0, (double)i);
						SKBitmap mip = new SKBitmap(bitmap.Width / d, bitmap.Height / d, false);
						bitmap.ScalePixels(mip, quality);
						pixels[i] = mip;
						byteCount += pixels[i].ByteCount;
					}
					byte[] imageData = ArrayPool<byte>.Shared.Rent(byteCount);
					int j = numMips - 1;
					int index = 0;
					while (j >= 0)
					{
						Marshal.Copy(pixels[j].GetPixels(), imageData, index, pixels[j].ByteCount);
						index += pixels[j].ByteCount;
						j--;
					}
					result = new ValueTuple<byte[], int>(imageData, byteCount);
				}
				return result;
			}
		}
	}
}
