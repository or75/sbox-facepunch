using System;

namespace Steamworks
{
	// Token: 0x020000A8 RID: 168
	internal struct AppId
	{
		// Token: 0x06000688 RID: 1672 RVA: 0x0000A1A7 File Offset: 0x000083A7
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000689 RID: 1673 RVA: 0x0000A1B4 File Offset: 0x000083B4
		public static implicit operator AppId(uint value)
		{
			return new AppId
			{
				Value = value
			};
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0000A1D4 File Offset: 0x000083D4
		public static implicit operator AppId(int value)
		{
			return new AppId
			{
				Value = (uint)value
			};
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0000A1F2 File Offset: 0x000083F2
		public static implicit operator uint(AppId value)
		{
			return value.Value;
		}

		// Token: 0x0400092F RID: 2351
		internal uint Value;
	}
}
