using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Sandbox
{
	// Token: 0x02000047 RID: 71
	public static class StreamExtension
	{
		// Token: 0x06000343 RID: 835 RVA: 0x0000C806 File Offset: 0x0000AA06
		public static T ReadStructureFromStream<T>(this Stream stream, long offset)
		{
			stream.Seek(offset, SeekOrigin.Begin);
			return stream.ReadStructureFromStream<T>();
		}

		// Token: 0x06000344 RID: 836 RVA: 0x0000C818 File Offset: 0x0000AA18
		public unsafe static T ReadStructureFromStream<T>(this Stream stream)
		{
			int num = Marshal.SizeOf(typeof(T));
			Span<byte> byteSpan = new Span<byte>(stackalloc byte[(UIntPtr)num], num);
			stream.Read(byteSpan);
			fixed (byte* pinnableReference = byteSpan.GetPinnableReference())
			{
				return Marshal.PtrToStructure<T>((IntPtr)((void*)pinnableReference));
			}
		}

		// Token: 0x06000345 RID: 837 RVA: 0x0000C85C File Offset: 0x0000AA5C
		public static byte[] ReadByteArrayFromStream(this Stream stream, long offset, uint count)
		{
			byte[] byteArray = new byte[count];
			stream.Seek(offset, SeekOrigin.Begin);
			stream.Read(byteArray, 0, (int)count);
			return byteArray;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000C884 File Offset: 0x0000AA84
		public static T[] ReadStructuresFromStream<T>(this Stream stream, long offset, uint count)
		{
			stream.Seek(offset, SeekOrigin.Begin);
			return stream.ReadStructuresFromStream(count);
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0000C896 File Offset: 0x0000AA96
		public static void ReadStructuresFromStream<T>(this Stream stream, long offset, uint count, T[] destArray, int destIndex = 0)
		{
			stream.Seek(offset, SeekOrigin.Begin);
			stream.ReadStructuresFromStream(count, destArray, destIndex);
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0000C8AC File Offset: 0x0000AAAC
		public static T[] ReadStructuresFromStream<T>(this Stream stream, uint count)
		{
			T[] array = new T[count];
			stream.ReadStructuresFromStream(count, array, 0);
			return array;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0000C8CC File Offset: 0x0000AACC
		public unsafe static void ReadStructuresFromStream<T>(this Stream stream, uint count, T[] destArray, int destIndex = 0)
		{
			int size = Marshal.SizeOf(typeof(T));
			int num = size * (int)count;
			Span<byte> byteSpan = new Span<byte>(stackalloc byte[(UIntPtr)num], num);
			stream.Read(byteSpan);
			fixed (byte* pinnableReference = byteSpan.GetPinnableReference())
			{
				byte* ptr = pinnableReference;
				int i = 0;
				while ((long)i < (long)((ulong)count))
				{
					destArray[destIndex + i] = Marshal.PtrToStructure<T>((IntPtr)((void*)(ptr + i * size)));
					i++;
				}
			}
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0000C940 File Offset: 0x0000AB40
		public static string ReadNullTerminatedString(this Stream stream, long offset)
		{
			stream.Seek(offset, SeekOrigin.Begin);
			List<byte> bytes = new List<byte>();
			int b;
			while ((b = stream.ReadByte()) != 0)
			{
				bytes.Add((byte)b);
			}
			return Encoding.UTF8.GetString(bytes.ToArray());
		}
	}
}
