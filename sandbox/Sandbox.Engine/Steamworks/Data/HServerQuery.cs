using System;

namespace Steamworks.Data
{
	// Token: 0x020001B9 RID: 441
	internal struct HServerQuery : IEquatable<HServerQuery>, IComparable<HServerQuery>
	{
		// Token: 0x06000AA0 RID: 2720 RVA: 0x0000F470 File Offset: 0x0000D670
		public static implicit operator HServerQuery(int value)
		{
			return new HServerQuery
			{
				Value = value
			};
		}

		// Token: 0x06000AA1 RID: 2721 RVA: 0x0000F48E File Offset: 0x0000D68E
		public static implicit operator int(HServerQuery value)
		{
			return value.Value;
		}

		// Token: 0x06000AA2 RID: 2722 RVA: 0x0000F496 File Offset: 0x0000D696
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000AA3 RID: 2723 RVA: 0x0000F4A3 File Offset: 0x0000D6A3
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0000F4B0 File Offset: 0x0000D6B0
		public override bool Equals(object p)
		{
			return this.Equals((HServerQuery)p);
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x0000F4BE File Offset: 0x0000D6BE
		public bool Equals(HServerQuery p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x0000F4CE File Offset: 0x0000D6CE
		public static bool operator ==(HServerQuery a, HServerQuery b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x0000F4D8 File Offset: 0x0000D6D8
		public static bool operator !=(HServerQuery a, HServerQuery b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0000F4E5 File Offset: 0x0000D6E5
		public int CompareTo(HServerQuery other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D42 RID: 3394
		internal int Value;
	}
}
