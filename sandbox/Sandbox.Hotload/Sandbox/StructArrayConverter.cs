using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Sandbox
{
	// Token: 0x0200000F RID: 15
	internal abstract class StructArrayConverter : IDisposable
	{
		// Token: 0x0600007C RID: 124 RVA: 0x000047F4 File Offset: 0x000029F4
		public static StructArrayConverter Create(Type srcType, Type dstType)
		{
			return (StructArrayConverter)Activator.CreateInstance(typeof(StructArrayConverter<, >).MakeGenericType(new Type[] { srcType, dstType }));
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x0600007D RID: 125 RVA: 0x0000481D File Offset: 0x00002A1D
		// (set) Token: 0x0600007E RID: 126 RVA: 0x00004825 File Offset: 0x00002A25
		private protected IntPtr TempHandle { protected get; private set; }

		// Token: 0x0600007F RID: 127 RVA: 0x00004830 File Offset: 0x00002A30
		protected StructArrayConverter(Type srcType, int srcSize, Type dstType, int dstSize)
		{
			if (srcSize != dstSize)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(89, 5);
				defaultInterpolatedStringHandler.AppendLiteral("Cannot construct a ");
				defaultInterpolatedStringHandler.AppendFormatted("StructArrayConverter");
				defaultInterpolatedStringHandler.AppendLiteral(" with type arguments of ");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(srcType);
				defaultInterpolatedStringHandler.AppendLiteral(" and ");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(dstType);
				defaultInterpolatedStringHandler.AppendLiteral(" - structures are different sizes (");
				defaultInterpolatedStringHandler.AppendFormatted<int>(srcSize);
				defaultInterpolatedStringHandler.AppendLiteral(" vs ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(dstSize);
				defaultInterpolatedStringHandler.AppendLiteral(").");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			this.TempHandle = Marshal.AllocHGlobal(srcSize);
		}

		// Token: 0x06000080 RID: 128 RVA: 0x000048E3 File Offset: 0x00002AE3
		public void BlockCopy(Array src, Array dst)
		{
			this.OnBlockCopy(src, dst);
		}

		// Token: 0x06000081 RID: 129
		protected abstract void OnBlockCopy(Array src, Array dst);

		// Token: 0x06000082 RID: 130 RVA: 0x000048ED File Offset: 0x00002AED
		public void Dispose()
		{
			if (this.TempHandle != IntPtr.Zero)
			{
				Marshal.FreeHGlobal(this.TempHandle);
				this.TempHandle = IntPtr.Zero;
			}
		}
	}
}
