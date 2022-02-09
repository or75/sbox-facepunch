using System;
using System.IO;

namespace Sandbox
{
	// Token: 0x020002BA RID: 698
	public static class PrimitiveTypes
	{
		// Token: 0x060011A7 RID: 4519 RVA: 0x00023B10 File Offset: 0x00021D10
		public static bool Read(this bool self, BinaryReader reader)
		{
			return reader.ReadBoolean();
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x00023B18 File Offset: 0x00021D18
		public static void Write(this bool self, BinaryWriter writer)
		{
			writer.Write(self);
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x00023B21 File Offset: 0x00021D21
		public static int Read(this int self, BinaryReader reader)
		{
			return reader.ReadInt32();
		}

		// Token: 0x060011AA RID: 4522 RVA: 0x00023B29 File Offset: 0x00021D29
		public static void Write(this int self, BinaryWriter writer)
		{
			writer.Write(self);
		}

		// Token: 0x060011AB RID: 4523 RVA: 0x00023B32 File Offset: 0x00021D32
		public static float Read(this float self, BinaryReader reader)
		{
			return reader.ReadSingle();
		}

		// Token: 0x060011AC RID: 4524 RVA: 0x00023B3A File Offset: 0x00021D3A
		public static void Write(this float self, BinaryWriter writer)
		{
			writer.Write(self);
		}

		// Token: 0x060011AD RID: 4525 RVA: 0x00023B43 File Offset: 0x00021D43
		public static string Read(this string self, BinaryReader reader)
		{
			return reader.ReadString();
		}

		// Token: 0x060011AE RID: 4526 RVA: 0x00023B4B File Offset: 0x00021D4B
		public static void Write(this string self, BinaryWriter writer)
		{
			writer.Write(self ?? string.Empty);
		}
	}
}
