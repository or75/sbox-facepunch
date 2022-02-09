using System;
using System.Runtime.CompilerServices;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020002CA RID: 714
	public struct Texture2DBuilder
	{
		// Token: 0x17000375 RID: 885
		// (set) Token: 0x0600125E RID: 4702 RVA: 0x00026A46 File Offset: 0x00024C46
		internal int Width
		{
			set
			{
				this.config.common.m_nWidth = (short)value;
			}
		}

		// Token: 0x17000376 RID: 886
		// (set) Token: 0x0600125F RID: 4703 RVA: 0x00026A5A File Offset: 0x00024C5A
		internal int Height
		{
			set
			{
				this.config.common.m_nHeight = (short)value;
			}
		}

		// Token: 0x17000377 RID: 887
		// (set) Token: 0x06001260 RID: 4704 RVA: 0x00026A6E File Offset: 0x00024C6E
		internal ImageFormat Format
		{
			set
			{
				this.config.common.m_nImageFormat = value;
			}
		}

		// Token: 0x06001261 RID: 4705 RVA: 0x00026A81 File Offset: 0x00024C81
		public Texture2DBuilder WithName(string name)
		{
			this._name = name;
			return this;
		}

		// Token: 0x06001262 RID: 4706 RVA: 0x00026A90 File Offset: 0x00024C90
		public Texture2DBuilder WithFormat(ImageFormat format)
		{
			this.config.common.m_nImageFormat = format;
			return this;
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x00026AA9 File Offset: 0x00024CA9
		public Texture2DBuilder WithMips(int mips)
		{
			this.config.common.m_nNumMipLevels = (short)mips;
			return this;
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x00026AC3 File Offset: 0x00024CC3
		public Texture2DBuilder WithData(byte[] data)
		{
			return this.WithData(data, data.Length);
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x00026ACF File Offset: 0x00024CCF
		public Texture2DBuilder WithData(byte[] data, int dataLength)
		{
			if (dataLength > data.Length)
			{
				throw new Exception("dataLength > array size");
			}
			this._data = data;
			this._datalength = dataLength;
			return this;
		}

		// Token: 0x06001266 RID: 4710 RVA: 0x00026AF6 File Offset: 0x00024CF6
		internal Texture2DBuilder WithData(IntPtr ptr, int size)
		{
			this._dataptr = ptr;
			this._datalength = size;
			return this;
		}

		// Token: 0x06001267 RID: 4711 RVA: 0x00026B0C File Offset: 0x00024D0C
		public Texture2DBuilder WithStaticUsage()
		{
			this.config.WithStaticUsage();
			return this;
		}

		// Token: 0x06001268 RID: 4712 RVA: 0x00026B20 File Offset: 0x00024D20
		public Texture2DBuilder WithSemiStaticUsage()
		{
			this.config.WithSemiStaticUsage();
			return this;
		}

		// Token: 0x06001269 RID: 4713 RVA: 0x00026B34 File Offset: 0x00024D34
		public Texture2DBuilder WithDynamicUsage()
		{
			this.config.WithDynamicUsage();
			return this;
		}

		// Token: 0x0600126A RID: 4714 RVA: 0x00026B48 File Offset: 0x00024D48
		public Texture2DBuilder WithGPUOnlyUsage()
		{
			this.config.WithGPUOnlyUsage();
			return this;
		}

		/// <summary>
		/// Support binding the texture as a Unordered Access View in a compute or pixel shader.
		/// This is required for binding a texture within a compute shader
		/// </summary>
		/// <returns>Texture2DBuilder</returns>
		// Token: 0x0600126B RID: 4715 RVA: 0x00026B5C File Offset: 0x00024D5C
		public Texture2DBuilder WithUAVBinding()
		{
			this.config.WithUAVBinding();
			return this;
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x00026B70 File Offset: 0x00024D70
		public Texture Finish()
		{
			this.config.common.m_nDepth = 1;
			if (this.config.common.m_nNumMipLevels <= 0)
			{
				this.config.common.m_nNumMipLevels = 1;
			}
			if (this._dataptr != IntPtr.Zero || this._data != null)
			{
				int memRequired = ImageLoader.GetMemRequired((int)this.config.common.m_nWidth, (int)this.config.common.m_nHeight, (int)this.config.common.m_nDepth, this.config.common.m_nImageFormat, false);
				if (this._datalength < memRequired)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(55, 2);
					defaultInterpolatedStringHandler.AppendFormatted<int>(this._datalength);
					defaultInterpolatedStringHandler.AppendLiteral(" bytes is not enough data to create texture! ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(memRequired);
					defaultInterpolatedStringHandler.AppendLiteral(" required.");
					throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
				}
			}
			if (this._dataptr != IntPtr.Zero)
			{
				return new Texture(RenderDevice.FindOrCreateTexture2(string.IsNullOrEmpty(this._name) ? "unnamed" : this._name, true, this.config, this._dataptr, this._datalength));
			}
			return this.config.Create(string.IsNullOrEmpty(this._name) ? "unnamed" : this._name, true, this._data, this._datalength);
		}

		// Token: 0x04001474 RID: 5236
		internal TextureBuilder config;

		// Token: 0x04001475 RID: 5237
		internal string _name;

		// Token: 0x04001476 RID: 5238
		internal byte[] _data;

		// Token: 0x04001477 RID: 5239
		internal IntPtr _dataptr;

		// Token: 0x04001478 RID: 5240
		internal int _datalength;
	}
}
