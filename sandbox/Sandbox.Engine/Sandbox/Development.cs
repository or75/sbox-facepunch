using System;

namespace Sandbox
{
	// Token: 0x02000296 RID: 662
	public static class Development
	{
		// Token: 0x060010CF RID: 4303 RVA: 0x0001F669 File Offset: 0x0001D869
		public static void Notice(string category, string icon, string title, int seconds = 5, string type = "success", string information = null)
		{
			IMenuAddon.ShowDevNotice(category, icon, title, seconds, type, information);
		}
	}
}
