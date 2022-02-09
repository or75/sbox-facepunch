using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000256 RID: 598
	internal struct CTextureDesc
	{
		// Token: 0x04001042 RID: 4162
		public short m_nWidth;

		// Token: 0x04001043 RID: 4163
		public short m_nHeight;

		// Token: 0x04001044 RID: 4164
		public short m_nDepth;

		// Token: 0x04001045 RID: 4165
		public short m_nNumMipLevels;

		// Token: 0x04001046 RID: 4166
		public TextureDecodingFlags m_nDecodeFlags;

		// Token: 0x04001047 RID: 4167
		public ImageFormat m_nImageFormat;

		// Token: 0x04001048 RID: 4168
		public TextureSpecificationFlags m_nFlags;

		// Token: 0x04001049 RID: 4169
		public short m_nDisplayRectWidth;

		// Token: 0x0400104A RID: 4170
		public short m_nDisplayRectHeight;

		// Token: 0x0400104B RID: 4171
		public short m_nMotionVectorsMaxDistanceInPixels;
	}
}
