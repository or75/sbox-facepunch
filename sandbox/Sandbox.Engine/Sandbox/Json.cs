using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox
{
	// Token: 0x0200028A RID: 650
	internal static class Json
	{
		// Token: 0x06001049 RID: 4169 RVA: 0x0001D310 File Offset: 0x0001B510
		public static T Deserialize<T>(this string json, Func<T> onFail)
		{
			T result;
			try
			{
				result = JsonSerializer.Deserialize<T>(json, Json.defaultSerializerSettings);
			}
			catch (Exception e)
			{
				if (onFail == null)
				{
					throw e;
				}
				result = onFail();
			}
			return result;
		}

		// Token: 0x0400126A RID: 4714
		private static JsonSerializerOptions defaultSerializerSettings = new JsonSerializerOptions
		{
			ReadCommentHandling = JsonCommentHandling.Skip,
			PropertyNameCaseInsensitive = true,
			IncludeFields = true,
			NumberHandling = JsonNumberHandling.AllowReadingFromString
		};
	}
}
