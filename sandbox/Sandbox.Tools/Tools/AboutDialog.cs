using System;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x02000071 RID: 113
	public static class AboutDialog
	{
		// Token: 0x0600128A RID: 4746 RVA: 0x00050844 File Offset: 0x0004EA44
		internal static void Open(QWidget dialogPtr)
		{
			Widget dialog = new Widget(dialogPtr);
			Event.Run<Widget>("about.open", dialog);
		}
	}
}
