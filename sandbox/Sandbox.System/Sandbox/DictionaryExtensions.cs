using System;
using System.Collections.Generic;

namespace Sandbox
{
	// Token: 0x02000041 RID: 65
	public static class DictionaryExtensions
	{
		/// <summary>
		/// If the key doesn't exist it is created and returned
		/// </summary>
		// Token: 0x06000312 RID: 786 RVA: 0x0000BD3C File Offset: 0x00009F3C
		public static TValue GetOrCreate<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key) where TValue : new()
		{
			TValue val;
			if (dict.TryGetValue(key, out val))
			{
				return val;
			}
			val = new TValue();
			dict.Add(key, val);
			return val;
		}

		// Token: 0x06000313 RID: 787 RVA: 0x0000BD68 File Offset: 0x00009F68
		public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
		{
			TValue value;
			if (!dict.TryGetValue(key, out value))
			{
				return defaultValue;
			}
			return value;
		}

		/// <summary>
		/// Clones the dictionary. Doesn't clone the values.
		/// </summary>
		// Token: 0x06000314 RID: 788 RVA: 0x0000BD84 File Offset: 0x00009F84
		public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this Dictionary<TKey, TValue> dict)
		{
			Dictionary<TKey, TValue> ret = new Dictionary<TKey, TValue>(dict.Count, dict.Comparer);
			foreach (KeyValuePair<TKey, TValue> entry in dict)
			{
				ret.Add(entry.Key, entry.Value);
			}
			return ret;
		}
	}
}
