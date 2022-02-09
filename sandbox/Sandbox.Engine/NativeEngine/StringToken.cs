using System;
using System.Collections.Concurrent;

namespace NativeEngine
{
	/// <summary>
	/// Creates and Caches the process of converting strings into uint32's which
	/// allow us to use CUtlStringToken arguments.
	///
	/// The tokens are just hashes of the string so we're probably safe enough to never 
	/// clear this, although it is a technical possibility for someone to call functions
	/// that take a StringToken with millions of random strings to make the Cache so full
	/// that calling FindOrCreate takes ages. So maybe we want to keep an eye on it.
	/// </summary>
	// Token: 0x0200024F RID: 591
	internal static class StringToken
	{
		// Token: 0x06000F3A RID: 3898 RVA: 0x0001B280 File Offset: 0x00019480
		public static uint FindOrCreate(string str)
		{
			if (str == null)
			{
				return 0U;
			}
			uint val;
			if (StringToken.Cache.TryGetValue(str, out val))
			{
				return val;
			}
			val = EngineGlue.GetStringToken(str);
			StringToken.Cache.TryAdd(str, val);
			StringToken.CacheReverse.TryAdd(val, str);
			return val;
		}

		// Token: 0x06000F3B RID: 3899 RVA: 0x0001B2C8 File Offset: 0x000194C8
		internal static string GetValue(uint token)
		{
			string val;
			StringToken.CacheReverse.TryGetValue(token, out val);
			return val;
		}

		// Token: 0x04000E52 RID: 3666
		private static ConcurrentDictionary<string, uint> Cache = new ConcurrentDictionary<string, uint>();

		// Token: 0x04000E53 RID: 3667
		private static ConcurrentDictionary<uint, string> CacheReverse = new ConcurrentDictionary<uint, string>();
	}
}
