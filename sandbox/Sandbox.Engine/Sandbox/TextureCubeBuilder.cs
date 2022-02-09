using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020002CE RID: 718
	public struct TextureCubeBuilder
	{
		/// <summary>
		/// Support binding the texture as a Unordered Access View in a compute or pixel shader.
		/// This is required for binding a texture within a compute shader
		/// </summary>
		/// <returns>TextureCubeBuilder</returns>
		// Token: 0x0600128A RID: 4746 RVA: 0x00027051 File Offset: 0x00025251
		public TextureCubeBuilder WithUAVBinding()
		{
			this.config.WithUAVBinding();
			return this;
		}

		// Token: 0x0600128B RID: 4747 RVA: 0x00027065 File Offset: 0x00025265
		public Texture Finish(string name = null, bool anonymous = true, byte[] data = null)
		{
			this.config.common.m_nFlags = this.config.common.m_nFlags | TextureSpecificationFlags.TSPEC_CUBE_TEXTURE;
			return this.config.Create(name, anonymous, data, data.Length);
		}

		// Token: 0x04001484 RID: 5252
		internal TextureBuilder config;
	}
}
