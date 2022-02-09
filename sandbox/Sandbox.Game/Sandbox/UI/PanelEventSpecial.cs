using System;

namespace Sandbox.UI
{
	// Token: 0x0200014D RID: 333
	internal sealed class PanelEventSpecial : PanelAction
	{
		// Token: 0x06001937 RID: 6455 RVA: 0x0006A504 File Offset: 0x00068704
		internal override void Apply(Panel panel, Panel context)
		{
			panel.AddEventListener(this.EventName, delegate(PanelEvent e)
			{
				this.RunSpecialEvent(panel, context);
			});
		}

		// Token: 0x06001938 RID: 6456 RVA: 0x0006A54C File Offset: 0x0006874C
		private void RunSpecialEvent(Panel panel, Panel context)
		{
			string name = this.Name;
			if (name == "console")
			{
				ConsoleSystem.Run(this.CodeLine);
				return;
			}
			if (!(name == "event"))
			{
				panel.CreateEvent(this.Name, this.CodeLine, null);
				return;
			}
			if (context != null)
			{
				context.CreateEvent(this.CodeLine, null, null);
			}
		}

		// Token: 0x040006DE RID: 1758
		public string CodeLine;
	}
}
