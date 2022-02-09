using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020002CC RID: 716
	public struct TextureArrayBuilder
	{
		/// <summary>
		/// Support binding the texture as a Unordered Access View in a compute or pixel shader.
		/// This is required for binding a texture within a compute shader
		/// </summary>
		/// <returns>TextureArrayBuilder</returns>
		// Token: 0x06001276 RID: 4726 RVA: 0x00026DF6 File Offset: 0x00024FF6
		public TextureArrayBuilder WithUAVBinding()
		{
			this.config.WithUAVBinding();
			return this;
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x00026E0A File Offset: 0x0002500A
		public Texture Finish(string name = null, bool anonymous = true, byte[] data = null)
		{
			this.config.common.m_nFlags = this.config.common.m_nFlags | TextureSpecificationFlags.TSPEC_TEXTURE_ARRAY;
			return this.config.Create(name, anonymous, data, data.Length);
		}

		// Token: 0x0400147D RID: 5245
		internal TextureBuilder config;
	}
}
