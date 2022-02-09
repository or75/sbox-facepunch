using System;

namespace Steamworks
{
	// Token: 0x020000B4 RID: 180
	internal static class Epoch
	{
		/// <summary>
		/// Returns the current Unix Epoch
		/// </summary>
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000701 RID: 1793 RVA: 0x0000B254 File Offset: 0x00009454
		internal static int Current
		{
			get
			{
				return (int)DateTime.UtcNow.Subtract(Epoch.epoch).TotalSeconds;
			}
		}

		/// <summary>
		/// Convert an epoch to a datetime
		/// </summary>
		// Token: 0x06000702 RID: 1794 RVA: 0x0000B27C File Offset: 0x0000947C
		internal static DateTime ToDateTime(decimal unixTime)
		{
			return Epoch.epoch.AddSeconds((double)(long)unixTime);
		}

		/// <summary>
		/// Convert a DateTime to a unix time
		/// </summary>
		// Token: 0x06000703 RID: 1795 RVA: 0x0000B290 File Offset: 0x00009490
		internal static uint FromDateTime(DateTime dt)
		{
			return (uint)dt.Subtract(Epoch.epoch).TotalSeconds;
		}

		// Token: 0x04000959 RID: 2393
		private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
	}
}
