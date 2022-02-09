using System;
using System.Runtime.CompilerServices;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020002CD RID: 717
	public struct TextureBuilder
	{
		// Token: 0x06001278 RID: 4728 RVA: 0x00026E3B File Offset: 0x0002503B
		public TextureBuilder WithStaticUsage()
		{
			this.m_nUsage = TextureUsage.TEXTURE_USAGE_STATIC;
			return this;
		}

		// Token: 0x06001279 RID: 4729 RVA: 0x00026E4A File Offset: 0x0002504A
		public TextureBuilder WithSemiStaticUsage()
		{
			this.m_nUsage = TextureUsage.TEXTURE_USAGE_SEMISTATIC;
			return this;
		}

		// Token: 0x0600127A RID: 4730 RVA: 0x00026E59 File Offset: 0x00025059
		public TextureBuilder WithDynamicUsage()
		{
			this.m_nUsage = TextureUsage.TEXTURE_USAGE_DYNAMIC;
			return this;
		}

		// Token: 0x0600127B RID: 4731 RVA: 0x00026E68 File Offset: 0x00025068
		public TextureBuilder WithGPUOnlyUsage()
		{
			this.m_nUsage = TextureUsage.TEXTURE_USAGE_GPU_ONLY;
			return this;
		}

		// Token: 0x0600127C RID: 4732 RVA: 0x00026E77 File Offset: 0x00025077
		public TextureBuilder WithSize(int width, int height)
		{
			this.common.m_nWidth = (short)width;
			this.common.m_nHeight = (short)height;
			return this;
		}

		// Token: 0x0600127D RID: 4733 RVA: 0x00026E99 File Offset: 0x00025099
		public TextureBuilder WithSize(Vector2 size)
		{
			this.common.m_nWidth = (short)size.x.CeilToInt();
			this.common.m_nHeight = (short)size.y.CeilToInt();
			return this;
		}

		// Token: 0x0600127E RID: 4734 RVA: 0x00026ED1 File Offset: 0x000250D1
		public TextureBuilder WithMultiSample2X()
		{
			this.m_nMultisampleType = RenderMultisampleType.RENDER_MULTISAMPLE_2X;
			return this;
		}

		// Token: 0x0600127F RID: 4735 RVA: 0x00026EE0 File Offset: 0x000250E0
		public TextureBuilder WithMultiSample4X()
		{
			this.m_nMultisampleType = RenderMultisampleType.RENDER_MULTISAMPLE_4X;
			return this;
		}

		// Token: 0x06001280 RID: 4736 RVA: 0x00026EEF File Offset: 0x000250EF
		public TextureBuilder WithMultiSample6X()
		{
			this.m_nMultisampleType = RenderMultisampleType.RENDER_MULTISAMPLE_6X;
			return this;
		}

		// Token: 0x06001281 RID: 4737 RVA: 0x00026EFE File Offset: 0x000250FE
		public TextureBuilder WithMultiSample8X()
		{
			this.m_nMultisampleType = RenderMultisampleType.RENDER_MULTISAMPLE_8X;
			return this;
		}

		// Token: 0x06001282 RID: 4738 RVA: 0x00026F0D File Offset: 0x0002510D
		public TextureBuilder WithMultiSample16X()
		{
			this.m_nMultisampleType = RenderMultisampleType.RENDER_MULTISAMPLE_16X;
			return this;
		}

		// Token: 0x06001283 RID: 4739 RVA: 0x00026F1C File Offset: 0x0002511C
		public TextureBuilder WithFormat(ImageFormat format)
		{
			this.common.m_nImageFormat = format;
			return this;
		}

		// Token: 0x06001284 RID: 4740 RVA: 0x00026F30 File Offset: 0x00025130
		public TextureBuilder WithScreenFormat()
		{
			this.common.m_nImageFormat = ImageFormat.RGBA8888;
			return this;
		}

		// Token: 0x06001285 RID: 4741 RVA: 0x00026F44 File Offset: 0x00025144
		public TextureBuilder WithScreenMultiSample()
		{
			this.m_nMultisampleType = RenderService.GetMultisampleType();
			return this;
		}

		// Token: 0x06001286 RID: 4742 RVA: 0x00026F57 File Offset: 0x00025157
		public TextureBuilder WithDepthFormat()
		{
			this.common.m_nImageFormat = ImageFormat.D24S8;
			return this;
		}

		/// <summary>
		/// Support binding the texture as a Unordered Access View in a compute or pixel shader.
		/// This is required for binding a texture within a compute shader
		/// </summary>
		/// <returns>TextureBuilder</returns>
		// Token: 0x06001287 RID: 4743 RVA: 0x00026F6C File Offset: 0x0002516C
		public TextureBuilder WithUAVBinding()
		{
			this.common.m_nFlags = this.common.m_nFlags | TextureSpecificationFlags.TSPEC_UAV;
			return this;
		}

		// Token: 0x06001288 RID: 4744 RVA: 0x00026F88 File Offset: 0x00025188
		public Texture Create(string name = null, bool anonymous = true, ReadOnlySpan<byte> data = default(ReadOnlySpan<byte>), int dataLength = 0)
		{
			if (this.common.m_nWidth <= 0 || this.common.m_nHeight <= 0)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(44, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Couldn't create texture - invalid size - ");
				defaultInterpolatedStringHandler.AppendFormatted<short>(this.common.m_nWidth);
				defaultInterpolatedStringHandler.AppendLiteral(" x ");
				defaultInterpolatedStringHandler.AppendFormatted<short>(this.common.m_nHeight);
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return this.CreateInternal(name, anonymous, data, dataLength);
		}

		// Token: 0x06001289 RID: 4745 RVA: 0x00027010 File Offset: 0x00025210
		internal unsafe Texture CreateInternal(string name, bool anonymous, ReadOnlySpan<byte> data, int dataLength = 0)
		{
			fixed (byte* pinnableReference = data.GetPinnableReference())
			{
				byte* dataPtr = pinnableReference;
				return new Texture(RenderDevice.FindOrCreateTexture2(string.IsNullOrEmpty(name) ? "unnamed" : name, anonymous, this, (IntPtr)((void*)dataPtr), dataLength));
			}
		}

		// Token: 0x0400147E RID: 5246
		internal TextureConfig common;

		// Token: 0x0400147F RID: 5247
		internal Color m_Reflectivity;

		// Token: 0x04001480 RID: 5248
		internal RenderMultisampleType m_nMultisampleType;

		// Token: 0x04001481 RID: 5249
		internal TextureUsage m_nUsage;

		// Token: 0x04001482 RID: 5250
		internal TextureScope m_nScope;

		// Token: 0x04001483 RID: 5251
		internal TextureOnDiskCompressionType m_compressionType;
	}
}
