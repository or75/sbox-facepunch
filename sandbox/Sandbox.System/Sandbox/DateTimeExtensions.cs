using System;

namespace Sandbox
{
	// Token: 0x02000040 RID: 64
	public static class DateTimeExtensions
	{
		// Token: 0x0600030E RID: 782 RVA: 0x0000BCE8 File Offset: 0x00009EE8
		public static int GetEpoch(this DateTime d)
		{
			return (int)(d - DateTimeExtensions.epoch).TotalSeconds;
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0000BD09 File Offset: 0x00009F09
		public static DateTime ToDateTime(this int d)
		{
			return DateTimeExtensions.epoch.AddSeconds((double)d);
		}

		// Token: 0x06000310 RID: 784 RVA: 0x0000BD17 File Offset: 0x00009F17
		public static DateTime ToDateTime(this long d)
		{
			return DateTimeExtensions.epoch.AddSeconds((double)d);
		}

		// Token: 0x040000AE RID: 174
		private static DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
	}
}
