using System;
using System.Reflection;

namespace Sandbox.Upgraders
{
	// Token: 0x02000016 RID: 22
	internal static class ComparerHelper
	{
		/// <summary>
		/// Uses the <see cref="P:System.Collections.Generic.Dictionary`2.Comparer" /> or <see cref="P:System.Collections.Generic.HashSet`1.Comparer" /> property to
		/// fetch the equality comparer used by <paramref name="oldDictOrHashSet" />.
		/// </summary>
		/// <param name="oldDictOrHashSet">Dictionary or HashSet to get the equality comparer from.</param>
		/// <returns>An <see cref="T:System.Collections.Generic.IEqualityComparer`1" />.</returns>
		// Token: 0x060000BA RID: 186 RVA: 0x00005AD1 File Offset: 0x00003CD1
		public static object GetOldComparer(object oldDictOrHashSet)
		{
			return oldDictOrHashSet.GetType().GetProperty("Comparer", BindingFlags.Instance | BindingFlags.Public).GetValue(oldDictOrHashSet);
		}
	}
}
