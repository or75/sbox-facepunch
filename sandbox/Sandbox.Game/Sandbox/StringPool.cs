using System;
using System.Collections.Generic;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000CF RID: 207
	internal static class StringPool
	{
		// Token: 0x06001275 RID: 4725 RVA: 0x0004DCA4 File Offset: 0x0004BEA4
		internal static void Init()
		{
			if (Host.IsClient)
			{
				StringTables.StringPool.OnStringAddedOrChanged = new Action<int>(StringPool.OnStringAddedOrChanged);
			}
			if (Host.IsServer)
			{
				StringPool.GetIdent("__invalid");
			}
			StringPool.StringTo.Clear();
			StringPool.StringFrom.Clear();
		}

		/// <summary>
		/// String table changed
		/// </summary>
		// Token: 0x06001276 RID: 4726 RVA: 0x0004DCF4 File Offset: 0x0004BEF4
		internal static void OnStringAddedOrChanged(int entryId)
		{
			Host.AssertClient("OnStringAddedOrChanged");
			string str = StringTables.StringPool.GetString(entryId);
			StringPool.StringTo[entryId] = str;
			StringPool.StringFrom[str] = entryId;
			StringToken.FindOrCreate(str);
		}

		// Token: 0x06001277 RID: 4727 RVA: 0x0004DD38 File Offset: 0x0004BF38
		public static int GetIdent(string str)
		{
			int val;
			if (StringPool.StringFrom.TryGetValue(str, out val))
			{
				return val;
			}
			if (Host.IsServer)
			{
				int i = StringTables.StringPool.Set(str);
				StringPool.StringTo[i] = str;
				StringPool.StringFrom[str] = i;
				return i;
			}
			throw new Exception("GetIdent called with missing/invalid string");
		}

		// Token: 0x06001278 RID: 4728 RVA: 0x0004DD90 File Offset: 0x0004BF90
		public static string GetString(int id)
		{
			string val;
			if (StringPool.StringTo.TryGetValue(id, out val))
			{
				return val;
			}
			return null;
		}

		// Token: 0x040003DD RID: 989
		private static readonly Dictionary<int, string> StringTo = new Dictionary<int, string>();

		// Token: 0x040003DE RID: 990
		private static readonly Dictionary<string, int> StringFrom = new Dictionary<string, int>();
	}
}
