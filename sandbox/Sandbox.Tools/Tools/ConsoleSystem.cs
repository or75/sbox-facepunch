using System;
using NativeEngine;
using Sandbox;

namespace Tools
{
	// Token: 0x02000076 RID: 118
	[Hotload.SkipAttribute]
	public static class ConsoleSystem
	{
		// Token: 0x060012C2 RID: 4802 RVA: 0x000510E9 File Offset: 0x0004F2E9
		public static void SetValue(string name, object value)
		{
			EngineGlue.SetConvarValue(name, value.ToString());
		}

		// Token: 0x060012C3 RID: 4803 RVA: 0x000510F8 File Offset: 0x0004F2F8
		public static string GetValue(string name, string defaultValue = null)
		{
			string v = EngineGlue.GetConvarValue(name);
			if (v == null)
			{
				return defaultValue;
			}
			return v;
		}
	}
}
