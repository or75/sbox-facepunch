using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x02000088 RID: 136
	public static class Application
	{
		// Token: 0x06001399 RID: 5017 RVA: 0x00054023 File Offset: 0x00052223
		public static void SetStyle(string style)
		{
			QApp.setStyleSheet(style);
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x0005402C File Offset: 0x0005222C
		internal static void ReloadStyles()
		{
			string sheet = "";
			foreach (string file in FileSystem.Root.FindFile("/addons/tools/resources/styles/", "*.css", false))
			{
				string txt = FileSystem.Root.ReadAllText("/addons/tools/resources/styles/" + file);
				sheet = sheet + "\n" + txt + "\n";
			}
			Application.SetStyle(sheet);
		}
	}
}
