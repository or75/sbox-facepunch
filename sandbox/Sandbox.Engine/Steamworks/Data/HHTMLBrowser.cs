using System;

namespace Steamworks.Data
{
	// Token: 0x020001CF RID: 463
	internal struct HHTMLBrowser : IEquatable<HHTMLBrowser>, IComparable<HHTMLBrowser>
	{
		// Token: 0x06000B66 RID: 2918 RVA: 0x00010020 File Offset: 0x0000E220
		public static implicit operator HHTMLBrowser(uint value)
		{
			return new HHTMLBrowser
			{
				Value = value
			};
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x0001003E File Offset: 0x0000E23E
		public static implicit operator uint(HHTMLBrowser value)
		{
			return value.Value;
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x00010046 File Offset: 0x0000E246
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x00010053 File Offset: 0x0000E253
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x00010060 File Offset: 0x0000E260
		public override bool Equals(object p)
		{
			return this.Equals((HHTMLBrowser)p);
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0001006E File Offset: 0x0000E26E
		public bool Equals(HHTMLBrowser p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0001007E File Offset: 0x0000E27E
		public static bool operator ==(HHTMLBrowser a, HHTMLBrowser b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x00010088 File Offset: 0x0000E288
		public static bool operator !=(HHTMLBrowser a, HHTMLBrowser b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x00010095 File Offset: 0x0000E295
		public int CompareTo(HHTMLBrowser other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D58 RID: 3416
		internal uint Value;
	}
}
