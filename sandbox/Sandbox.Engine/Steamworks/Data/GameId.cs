using System;

namespace Steamworks.Data
{
	// Token: 0x020001DF RID: 479
	internal struct GameId
	{
		// Token: 0x06000BC9 RID: 3017 RVA: 0x000106C8 File Offset: 0x0000E8C8
		public static implicit operator GameId(ulong value)
		{
			return new GameId
			{
				Value = value
			};
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x000106E6 File Offset: 0x0000E8E6
		public static implicit operator ulong(GameId value)
		{
			return value.Value;
		}

		// Token: 0x04000D6D RID: 3437
		internal ulong Value;
	}
}
