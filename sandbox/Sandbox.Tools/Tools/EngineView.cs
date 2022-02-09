using System;

namespace Tools
{
	// Token: 0x0200007C RID: 124
	public class EngineView : Frame
	{
		// Token: 0x060012FA RID: 4858 RVA: 0x000523B9 File Offset: 0x000505B9
		internal EngineView(Widget parent)
		{
			this.NativeInit(WidgetUtil.CreateMainWindowWidget(parent._widget));
		}
	}
}
