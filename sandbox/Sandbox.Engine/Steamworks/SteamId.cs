using System;

namespace Steamworks
{
	// Token: 0x020000B3 RID: 179
	internal struct SteamId
	{
		// Token: 0x060006FC RID: 1788 RVA: 0x0000B208 File Offset: 0x00009408
		public static implicit operator SteamId(ulong value)
		{
			return new SteamId
			{
				Value = value
			};
		}

		// Token: 0x060006FD RID: 1789 RVA: 0x0000B226 File Offset: 0x00009426
		public static implicit operator ulong(SteamId value)
		{
			return value.Value;
		}

		// Token: 0x060006FE RID: 1790 RVA: 0x0000B22E File Offset: 0x0000942E
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x0000B23B File Offset: 0x0000943B
		public uint AccountId
		{
			get
			{
				return (uint)(this.Value & (ulong)(-1));
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x0000B247 File Offset: 0x00009447
		public bool IsValid
		{
			get
			{
				return this.Value > 0UL;
			}
		}

		// Token: 0x04000958 RID: 2392
		public ulong Value;
	}
}
