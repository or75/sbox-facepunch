using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Sandbox
{
	// Token: 0x02000010 RID: 16
	internal class StructArrayConverter<TSrc, TDst> : StructArrayConverter where TSrc : struct where TDst : struct
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00004917 File Offset: 0x00002B17
		public StructArrayConverter()
			: base(typeof(TSrc), Marshal.SizeOf<TSrc>(), typeof(TDst), Marshal.SizeOf<TDst>())
		{
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00004940 File Offset: 0x00002B40
		protected override void OnBlockCopy(Array src, Array dst)
		{
			if (src.Rank != 1 || dst.Rank != 1)
			{
				throw new NotImplementedException("Block copy of arrays with ranks larger than 1 is not implemented.");
			}
			if (src.Length != dst.Length)
			{
				throw new ArgumentException("Both src and dst arrays must have the same length.");
			}
			TSrc[] srcArr = src as TSrc[];
			if (srcArr == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Expected ");
				defaultInterpolatedStringHandler.AppendFormatted("src");
				defaultInterpolatedStringHandler.AppendLiteral(" to have element type ");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(TSrc));
				defaultInterpolatedStringHandler.AppendLiteral(".");
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear(), "src");
			}
			TDst[] dstArr = dst as TDst[];
			if (dstArr == null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Expected ");
				defaultInterpolatedStringHandler.AppendFormatted("dst");
				defaultInterpolatedStringHandler.AppendLiteral(" to have element type ");
				defaultInterpolatedStringHandler.AppendFormatted<Type>(typeof(TDst));
				defaultInterpolatedStringHandler.AppendLiteral(".");
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear(), "dst");
			}
			IntPtr handle = base.TempHandle;
			if (handle == IntPtr.Zero)
			{
				throw new ObjectDisposedException("StructArrayConverter");
			}
			int length = src.Length;
			for (int i = 0; i < length; i++)
			{
				Marshal.StructureToPtr<TSrc>(srcArr[i], handle, false);
				dstArr[i] = Marshal.PtrToStructure<TDst>(handle);
			}
		}
	}
}
