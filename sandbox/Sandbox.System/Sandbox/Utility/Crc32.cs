using System;
using System.Buffers;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox.Utility
{
	// Token: 0x0200006A RID: 106
	public static class Crc32
	{
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x00021464 File Offset: 0x0001F664
		private static uint[] ChecksumTable
		{
			get
			{
				if (Crc32.checksumTable != null)
				{
					return Crc32.checksumTable;
				}
				Crc32.checksumTable = Enumerable.Range(0, 256).Select(delegate(int i)
				{
					uint tableEntry = (uint)i;
					for (int j = 0; j < 8; j++)
					{
						tableEntry = (((tableEntry & 1U) != 0U) ? (3988292384U ^ (tableEntry >> 1)) : (tableEntry >> 1));
					}
					return tableEntry;
				}).ToArray<uint>();
				return Crc32.checksumTable;
			}
		}

		// Token: 0x060004A4 RID: 1188 RVA: 0x000214BC File Offset: 0x0001F6BC
		public static uint FromBytes(IEnumerable<byte> byteStream)
		{
			uint[] ct = Crc32.ChecksumTable;
			return ~byteStream.Aggregate(uint.MaxValue, (uint checksumRegister, byte currentByte) => ct[(int)((checksumRegister & 255U) ^ (uint)currentByte)] ^ (checksumRegister >> 8));
		}

		// Token: 0x060004A5 RID: 1189 RVA: 0x000214EE File Offset: 0x0001F6EE
		public static uint FromString(string str)
		{
			return Crc32.FromBytes(Encoding.ASCII.GetBytes(str));
		}

		// Token: 0x060004A6 RID: 1190 RVA: 0x00021500 File Offset: 0x0001F700
		public static async Task<uint> FromStreamAsync(Stream stream)
		{
			byte[] buffer = ArrayPool<byte>.Shared.Rent(262144);
			uint[] ct = Crc32.ChecksumTable;
			uint val = uint.MaxValue;
			for (;;)
			{
				int read = await stream.ReadAsync(buffer, 0, buffer.Length);
				if (read == 0)
				{
					break;
				}
				for (int i = 0; i < read; i++)
				{
					byte currentByte = buffer[i];
					val = ct[(int)((val & 255U) ^ (uint)currentByte)] ^ (val >> 8);
				}
			}
			ArrayPool<byte>.Shared.Return(buffer, false);
			return ~val;
		}

		// Token: 0x04000934 RID: 2356
		private const uint generator = 3988292384U;

		// Token: 0x04000935 RID: 2357
		private static uint[] checksumTable;
	}
}
