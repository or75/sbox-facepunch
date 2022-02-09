using System;

namespace Steamworks.Data
{
	// Token: 0x020001C2 RID: 450
	internal struct ScreenshotHandle : IEquatable<ScreenshotHandle>, IComparable<ScreenshotHandle>
	{
		// Token: 0x06000AF1 RID: 2801 RVA: 0x0000F938 File Offset: 0x0000DB38
		public static implicit operator ScreenshotHandle(uint value)
		{
			return new ScreenshotHandle
			{
				Value = value
			};
		}

		// Token: 0x06000AF2 RID: 2802 RVA: 0x0000F956 File Offset: 0x0000DB56
		public static implicit operator uint(ScreenshotHandle value)
		{
			return value.Value;
		}

		// Token: 0x06000AF3 RID: 2803 RVA: 0x0000F95E File Offset: 0x0000DB5E
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000AF4 RID: 2804 RVA: 0x0000F96B File Offset: 0x0000DB6B
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000AF5 RID: 2805 RVA: 0x0000F978 File Offset: 0x0000DB78
		public override bool Equals(object p)
		{
			return this.Equals((ScreenshotHandle)p);
		}

		// Token: 0x06000AF6 RID: 2806 RVA: 0x0000F986 File Offset: 0x0000DB86
		public bool Equals(ScreenshotHandle p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000AF7 RID: 2807 RVA: 0x0000F996 File Offset: 0x0000DB96
		public static bool operator ==(ScreenshotHandle a, ScreenshotHandle b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000AF8 RID: 2808 RVA: 0x0000F9A0 File Offset: 0x0000DBA0
		public static bool operator !=(ScreenshotHandle a, ScreenshotHandle b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000AF9 RID: 2809 RVA: 0x0000F9AD File Offset: 0x0000DBAD
		public int CompareTo(ScreenshotHandle other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D4B RID: 3403
		internal uint Value;
	}
}
