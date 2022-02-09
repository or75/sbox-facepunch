using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020002CB RID: 715
	public struct Texture3DBuilder
	{
		// Token: 0x17000378 RID: 888
		// (set) Token: 0x0600126D RID: 4717 RVA: 0x00026CE4 File Offset: 0x00024EE4
		internal int Width
		{
			set
			{
				this.config.common.m_nWidth = (short)value;
			}
		}

		// Token: 0x17000379 RID: 889
		// (set) Token: 0x0600126E RID: 4718 RVA: 0x00026CF8 File Offset: 0x00024EF8
		internal int Height
		{
			set
			{
				this.config.common.m_nHeight = (short)value;
			}
		}

		// Token: 0x1700037A RID: 890
		// (set) Token: 0x0600126F RID: 4719 RVA: 0x00026D0C File Offset: 0x00024F0C
		internal int Depth
		{
			set
			{
				this.config.common.m_nDepth = (short)value;
			}
		}

		// Token: 0x1700037B RID: 891
		// (set) Token: 0x06001270 RID: 4720 RVA: 0x00026D20 File Offset: 0x00024F20
		internal ImageFormat Format
		{
			set
			{
				this.config.common.m_nImageFormat = value;
			}
		}

		// Token: 0x06001271 RID: 4721 RVA: 0x00026D33 File Offset: 0x00024F33
		public Texture3DBuilder WithName(string name)
		{
			this._name = name;
			return this;
		}

		// Token: 0x06001272 RID: 4722 RVA: 0x00026D42 File Offset: 0x00024F42
		public Texture3DBuilder WithFormat(ImageFormat format)
		{
			this.config.common.m_nImageFormat = format;
			return this;
		}

		/// <summary>
		/// Support binding the texture as a Unordered Access View in a compute or pixel shader.
		/// This is required for binding a texture within a compute shader
		/// </summary>
		/// <returns>Texture3DBuilder</returns>
		// Token: 0x06001273 RID: 4723 RVA: 0x00026D5B File Offset: 0x00024F5B
		public Texture3DBuilder WithUAVBinding()
		{
			this.config.WithUAVBinding();
			return this;
		}

		// Token: 0x06001274 RID: 4724 RVA: 0x00026D6F File Offset: 0x00024F6F
		public Texture3DBuilder WithData(byte[] data)
		{
			this._data = data;
			this._datalength = data.Length;
			return this;
		}

		// Token: 0x06001275 RID: 4725 RVA: 0x00026D88 File Offset: 0x00024F88
		public Texture Finish()
		{
			this.config.common.m_nNumMipLevels = 1;
			this.config.common.m_nFlags = this.config.common.m_nFlags | TextureSpecificationFlags.TSPEC_VOLUME_TEXTURE;
			return this.config.Create(string.IsNullOrEmpty(this._name) ? "unnamed" : this._name, true, this._data, this._datalength);
		}

		// Token: 0x04001479 RID: 5241
		internal TextureBuilder config;

		// Token: 0x0400147A RID: 5242
		internal string _name;

		// Token: 0x0400147B RID: 5243
		internal byte[] _data;

		// Token: 0x0400147C RID: 5244
		internal int _datalength;
	}
}
