using System;

namespace Steamworks.Data
{
	// Token: 0x020001DA RID: 474
	internal struct DepotId
	{
		// Token: 0x06000BBA RID: 3002 RVA: 0x000105F4 File Offset: 0x0000E7F4
		public static implicit operator DepotId(uint value)
		{
			return new DepotId
			{
				Value = value
			};
		}

		// Token: 0x06000BBB RID: 3003 RVA: 0x00010614 File Offset: 0x0000E814
		public static implicit operator DepotId(int value)
		{
			return new DepotId
			{
				Value = (uint)value
			};
		}

		// Token: 0x06000BBC RID: 3004 RVA: 0x00010632 File Offset: 0x0000E832
		public static implicit operator uint(DepotId value)
		{
			return value.Value;
		}

		// Token: 0x06000BBD RID: 3005 RVA: 0x0001063A File Offset: 0x0000E83A
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x04000D62 RID: 3426
		internal uint Value;
	}
}
