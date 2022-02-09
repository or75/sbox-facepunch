using System;

namespace Steamworks.Data
{
	// Token: 0x020001C4 RID: 452
	internal struct HTTPCookieContainerHandle : IEquatable<HTTPCookieContainerHandle>, IComparable<HTTPCookieContainerHandle>
	{
		// Token: 0x06000B03 RID: 2819 RVA: 0x0000FA48 File Offset: 0x0000DC48
		public static implicit operator HTTPCookieContainerHandle(uint value)
		{
			return new HTTPCookieContainerHandle
			{
				Value = value
			};
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x0000FA66 File Offset: 0x0000DC66
		public static implicit operator uint(HTTPCookieContainerHandle value)
		{
			return value.Value;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0000FA6E File Offset: 0x0000DC6E
		public override string ToString()
		{
			return this.Value.ToString();
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0000FA7B File Offset: 0x0000DC7B
		public override int GetHashCode()
		{
			return this.Value.GetHashCode();
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x0000FA88 File Offset: 0x0000DC88
		public override bool Equals(object p)
		{
			return this.Equals((HTTPCookieContainerHandle)p);
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x0000FA96 File Offset: 0x0000DC96
		public bool Equals(HTTPCookieContainerHandle p)
		{
			return p.Value == this.Value;
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0000FAA6 File Offset: 0x0000DCA6
		public static bool operator ==(HTTPCookieContainerHandle a, HTTPCookieContainerHandle b)
		{
			return a.Equals(b);
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0000FAB0 File Offset: 0x0000DCB0
		public static bool operator !=(HTTPCookieContainerHandle a, HTTPCookieContainerHandle b)
		{
			return !a.Equals(b);
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0000FABD File Offset: 0x0000DCBD
		public int CompareTo(HTTPCookieContainerHandle other)
		{
			return this.Value.CompareTo(other.Value);
		}

		// Token: 0x04000D4D RID: 3405
		internal uint Value;
	}
}
