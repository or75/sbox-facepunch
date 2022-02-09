using System;
using System.Text;

namespace Steamworks
{
	// Token: 0x020000BF RID: 191
	internal struct Utf8StringPointer
	{
		// Token: 0x06000730 RID: 1840 RVA: 0x0000B870 File Offset: 0x00009A70
		public unsafe static implicit operator string(Utf8StringPointer p)
		{
			if (p.ptr == IntPtr.Zero)
			{
				return null;
			}
			byte* bytes = (byte*)(void*)p.ptr;
			int dataLen = 0;
			while (dataLen < 67108864 && bytes[dataLen] != 0)
			{
				dataLen++;
			}
			return Encoding.UTF8.GetString(bytes, dataLen);
		}

		// Token: 0x0400096C RID: 2412
		internal IntPtr ptr;
	}
}
