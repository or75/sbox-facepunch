using System;
using System.Runtime.CompilerServices;

namespace Steamworks.Data
{
	// Token: 0x020001E0 RID: 480
	internal struct Image
	{
		// Token: 0x06000BCB RID: 3019 RVA: 0x000106F0 File Offset: 0x0000E8F0
		internal Color GetPixel(int x, int y)
		{
			if (x < 0 || (long)x >= (long)((ulong)this.Width))
			{
				throw new Exception("x out of bounds");
			}
			if (y < 0 || (long)y >= (long)((ulong)this.Height))
			{
				throw new Exception("y out of bounds");
			}
			Color c = default(Color);
			long i = ((long)y * (long)((ulong)this.Width) + (long)x) * 4L;
			checked
			{
				c.r = this.Data[(int)((IntPtr)i)];
				c.g = this.Data[(int)((IntPtr)(unchecked(i + 1L)))];
				c.b = this.Data[(int)((IntPtr)(unchecked(i + 2L)))];
				c.a = this.Data[(int)((IntPtr)(unchecked(i + 3L)))];
				return c;
			}
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x00010794 File Offset: 0x0000E994
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 3);
			defaultInterpolatedStringHandler.AppendFormatted<uint>(this.Width);
			defaultInterpolatedStringHandler.AppendLiteral("x");
			defaultInterpolatedStringHandler.AppendFormatted<uint>(this.Height);
			defaultInterpolatedStringHandler.AppendLiteral(" (");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.Length);
			defaultInterpolatedStringHandler.AppendLiteral("bytes)");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x04000D6E RID: 3438
		internal uint Width;

		// Token: 0x04000D6F RID: 3439
		internal uint Height;

		// Token: 0x04000D70 RID: 3440
		internal byte[] Data;
	}
}
