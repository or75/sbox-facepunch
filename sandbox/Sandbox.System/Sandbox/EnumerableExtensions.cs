using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
	// Token: 0x02000042 RID: 66
	public static class EnumerableExtensions
	{
		// Token: 0x06000315 RID: 789 RVA: 0x0000BDF4 File Offset: 0x00009FF4
		public static IEnumerable<TValue> DistinctBy<TKey, TValue>(this IEnumerable<TValue> items, Func<TValue, TKey> keySelector) where TKey : IComparable<TKey>
		{
			HashSet<TKey> hashSet = new HashSet<TKey>();
			return items.Where((TValue v) => hashSet.Add(keySelector(v)));
		}
	}
}
