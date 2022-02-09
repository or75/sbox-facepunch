using System;

namespace NativeEngine
{
	// Token: 0x02000259 RID: 601
	internal struct InputContextHandle
	{
		// Token: 0x06000F3D RID: 3901 RVA: 0x0001B2FA File Offset: 0x000194FA
		public InputContextHandle(IntPtr p)
		{
			this.pointer = p;
		}

		// Token: 0x0400106A RID: 4202
		public IntPtr pointer;
	}
}
