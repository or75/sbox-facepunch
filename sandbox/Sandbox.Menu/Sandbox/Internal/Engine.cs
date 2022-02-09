using System;
using System.Collections.Generic;

namespace Sandbox.Internal
{
	// Token: 0x0200000F RID: 15
	public static class Engine
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000045 RID: 69 RVA: 0x0000346F File Offset: 0x0000166F
		public static List<EntityEntry> Entities
		{
			get
			{
				Host.AssertMenu("Entities");
				return EntityRegistry.EntriesList;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000046 RID: 70 RVA: 0x00003480 File Offset: 0x00001680
		public static List<IPanel> RootPanels
		{
			get
			{
				Host.AssertMenu("RootPanels");
				return IPanel.GetAllRootPanels();
			}
		}
	}
}
