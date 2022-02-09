using System;
using System.Collections.Generic;
using Tools;

namespace Sandbox.Internal
{
	// Token: 0x02000070 RID: 112
	public static class GlobalToolsNamespace
	{
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600127F RID: 4735 RVA: 0x000507E7 File Offset: 0x0004E9E7
		public static Logger Log { get; } = new Logger("tools");

		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06001280 RID: 4736 RVA: 0x000507EE File Offset: 0x0004E9EE
		// (set) Token: 0x06001281 RID: 4737 RVA: 0x000507F5 File Offset: 0x0004E9F5
		public static TrayIcon ToolsTrayIcon { get; internal set; }

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06001282 RID: 4738 RVA: 0x000507FD File Offset: 0x0004E9FD
		// (set) Token: 0x06001283 RID: 4739 RVA: 0x00050804 File Offset: 0x0004EA04
		public static EditorMainWindow EditorWindow { get; internal set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06001284 RID: 4740 RVA: 0x0005080C File Offset: 0x0004EA0C
		// (set) Token: 0x06001285 RID: 4741 RVA: 0x00050813 File Offset: 0x0004EA13
		public static ReflectionSystem Reflection { get; internal set; }

		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06001286 RID: 4742 RVA: 0x0005081B File Offset: 0x0004EA1B
		// (set) Token: 0x06001287 RID: 4743 RVA: 0x00050822 File Offset: 0x0004EA22
		public static CookieContainer Cookie { get; internal set; }

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06001288 RID: 4744 RVA: 0x0005082A File Offset: 0x0004EA2A
		public static List<IPanel> RootPanels
		{
			get
			{
				return IPanel.GetAllRootPanels();
			}
		}
	}
}
