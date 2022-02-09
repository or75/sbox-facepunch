using System;

namespace Sandbox.UI
{
	// Token: 0x02000127 RID: 295
	internal class PanelLayer : IDisposable
	{
		// Token: 0x17000399 RID: 921
		// (get) Token: 0x06001702 RID: 5890 RVA: 0x0005C580 File Offset: 0x0005A780
		// (set) Token: 0x06001703 RID: 5891 RVA: 0x0005C588 File Offset: 0x0005A788
		public Vector2 Size { get; set; }

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x06001704 RID: 5892 RVA: 0x0005C591 File Offset: 0x0005A791
		// (set) Token: 0x06001705 RID: 5893 RVA: 0x0005C599 File Offset: 0x0005A799
		public Texture Texture { get; set; }

		// Token: 0x06001706 RID: 5894 RVA: 0x0005C5A4 File Offset: 0x0005A7A4
		public PanelLayer(Vector2 size)
		{
			this.Size = size;
			this.Texture = Texture.CreateRenderTarget().WithSize(this.Size).Create(null, true, default(ReadOnlySpan<byte>), 0);
		}

		// Token: 0x06001707 RID: 5895 RVA: 0x0005C5EB File Offset: 0x0005A7EB
		public void Dispose()
		{
			Texture texture = this.Texture;
			if (texture != null)
			{
				texture.Dispose();
			}
			this.Texture = null;
		}
	}
}
