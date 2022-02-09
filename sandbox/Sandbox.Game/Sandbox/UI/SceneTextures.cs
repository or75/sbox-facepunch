using System;
using NativeEngine;

namespace Sandbox.UI
{
	// Token: 0x0200010D RID: 269
	internal class SceneTextures : IDisposable
	{
		// Token: 0x17000336 RID: 822
		// (get) Token: 0x0600157B RID: 5499 RVA: 0x00055600 File Offset: 0x00053800
		// (set) Token: 0x0600157C RID: 5500 RVA: 0x00055608 File Offset: 0x00053808
		public Vector2 Size { get; set; }

		// Token: 0x17000337 RID: 823
		// (get) Token: 0x0600157D RID: 5501 RVA: 0x00055611 File Offset: 0x00053811
		// (set) Token: 0x0600157E RID: 5502 RVA: 0x00055619 File Offset: 0x00053819
		public Texture ColorTexture { get; set; }

		// Token: 0x17000338 RID: 824
		// (get) Token: 0x0600157F RID: 5503 RVA: 0x00055622 File Offset: 0x00053822
		// (set) Token: 0x06001580 RID: 5504 RVA: 0x0005562A File Offset: 0x0005382A
		public Texture DepthTexture { get; set; }

		// Token: 0x17000339 RID: 825
		// (get) Token: 0x06001581 RID: 5505 RVA: 0x00055633 File Offset: 0x00053833
		// (set) Token: 0x06001582 RID: 5506 RVA: 0x0005563B File Offset: 0x0005383B
		public RenderMultisampleType Multisample { get; private set; }

		// Token: 0x06001583 RID: 5507 RVA: 0x00055644 File Offset: 0x00053844
		public SceneTextures(Vector2 size)
		{
			this.Size = size;
			this.Multisample = RenderService.GetMultisampleType();
			this.ColorTexture = Texture.CreateRenderTarget().WithSize(this.Size).WithScreenFormat()
				.WithFormat(ImageFormat.RGBA16161616F)
				.WithScreenMultiSample()
				.Create(null, true, default(ReadOnlySpan<byte>), 0);
			this.DepthTexture = Texture.CreateRenderTarget().WithSize(this.Size).WithDepthFormat()
				.WithScreenMultiSample()
				.Create(null, true, default(ReadOnlySpan<byte>), 0);
		}

		// Token: 0x06001584 RID: 5508 RVA: 0x000556ED File Offset: 0x000538ED
		public void Dispose()
		{
			Texture colorTexture = this.ColorTexture;
			if (colorTexture != null)
			{
				colorTexture.Dispose();
			}
			Texture depthTexture = this.DepthTexture;
			if (depthTexture != null)
			{
				depthTexture.Dispose();
			}
			this.ColorTexture = null;
			this.DepthTexture = null;
		}
	}
}
