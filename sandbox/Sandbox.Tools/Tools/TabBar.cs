using System;
using Native;

namespace Tools
{
	// Token: 0x020000C6 RID: 198
	public class TabBar : Widget
	{
		// Token: 0x06001675 RID: 5749 RVA: 0x000596D6 File Offset: 0x000578D6
		internal TabBar(QTabBar widget)
		{
			this.NativeInit(widget);
		}

		// Token: 0x06001676 RID: 5750 RVA: 0x000596EA File Offset: 0x000578EA
		internal override void NativeInit(IntPtr ptr)
		{
			this._tabbar = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x06001677 RID: 5751 RVA: 0x000596FF File Offset: 0x000578FF
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._tabbar = default(QTabBar);
		}

		// Token: 0x0400049B RID: 1179
		private QTabBar _tabbar;
	}
}
