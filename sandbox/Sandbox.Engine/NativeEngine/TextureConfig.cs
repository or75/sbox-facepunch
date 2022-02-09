using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200027D RID: 637
	internal struct TextureConfig
	{
		// Token: 0x04001203 RID: 4611
		public short m_nWidth;

		// Token: 0x04001204 RID: 4612
		public short m_nHeight;

		// Token: 0x04001205 RID: 4613
		public short m_nDepth;

		// Token: 0x04001206 RID: 4614
		public short m_nNumMipLevels;

		// Token: 0x04001207 RID: 4615
		public TextureDecodingFlags m_nDecodeFlags;

		// Token: 0x04001208 RID: 4616
		public ImageFormat m_nImageFormat;

		// Token: 0x04001209 RID: 4617
		public TextureSpecificationFlags m_nFlags;

		// Token: 0x0400120A RID: 4618
		public short m_nDisplayRectWidth;

		// Token: 0x0400120B RID: 4619
		public short m_nDisplayRectHeight;

		// Token: 0x0400120C RID: 4620
		public short m_nMotionVectorsMaxDistanceInPixels;
	}
}
