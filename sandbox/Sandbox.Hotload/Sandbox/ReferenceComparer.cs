using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sandbox
{
	// Token: 0x0200000D RID: 13
	internal class ReferenceComparer : IEqualityComparer<object>
	{
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000072 RID: 114 RVA: 0x000042DE File Offset: 0x000024DE
		public static IEqualityComparer<object> Singleton { get; } = new ReferenceComparer();

		// Token: 0x06000073 RID: 115 RVA: 0x000042E5 File Offset: 0x000024E5
		private ReferenceComparer()
		{
		}

		// Token: 0x06000074 RID: 116 RVA: 0x000042ED File Offset: 0x000024ED
		bool IEqualityComparer<object>.Equals(object x, object y)
		{
			return x == y;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x000042F3 File Offset: 0x000024F3
		public int GetHashCode(object obj)
		{
			return RuntimeHelpers.GetHashCode(obj);
		}
	}
}
