using System;

namespace Steamworks.Data
{
	// Token: 0x020001C3 RID: 451
	internal struct HTTPRequestHandle : IEquatable<HTTPRequestHandle>, IComparable<HTTPRequestHandle>
	{
		// Token: 0x06000AFA RID: 2810 RVA: 0x0000F9C0 File Offset: 0x0000DBC0
		public static implicit operator HTTPRequestHandle(uint value)
		{
			return new HTTPRequestHandle
			{
				Value = value
			};
		}

		// Token: 0x06000AFB RID: 2811 RVA: 0x0000F9DE File Offset: 0x0000DBDE
		public static implicit operator uint(HTTPRequestHandle value)
		{
			return value.Value;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0000F9E6 File Offset: 0x0000DBE6
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0000F9F3 File Offset: 0x0000DBF3
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0000FA00 File Offset: 0x0000DC00
		public override bool Equals(object p)
		{
			return this.Equals((HTTPRequestHandle)p);
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0000FA0E File Offset: 0x0000DC0E
		public bool Equals(HTTPRequestHandle p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x0000FA1E File Offset: 0x0000DC1E
		public static bool operator ==(HTTPRequestHandle a, HTTPRequestHandle b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x0000FA28 File Offset: 0x0000DC28
		public static bool operator !=(HTTPRequestHandle a, HTTPRequestHandle b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B02 RID: 2818 RVA: 0x0000FA35 File Offset: 0x0000DC35
		public int CompareTo(HTTPRequestHandle other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D4C RID: 3404
		internal uint Value;
	}
}
