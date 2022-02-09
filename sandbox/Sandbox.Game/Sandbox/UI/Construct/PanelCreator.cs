using System;

namespace Sandbox.UI.Construct
{
	// Token: 0x02000155 RID: 341
	public ref struct PanelCreator
	{
		// Token: 0x060019AD RID: 6573 RVA: 0x0006BEBC File Offset: 0x0006A0BC
		internal PanelCreator(Panel panel)
		{
			this.panel = panel;
		}

		// Token: 0x060019AE RID: 6574 RVA: 0x0006BEC5 File Offset: 0x0006A0C5
		public Panel Panel()
		{
			return this.panel.AddChild<Panel>(null);
		}

		// Token: 0x060019AF RID: 6575 RVA: 0x0006BED3 File Offset: 0x0006A0D3
		public Panel Panel(string classname)
		{
			Panel panel = this.panel.AddChild<Panel>(null);
			panel.AddClass(classname);
			return panel;
		}

		// Token: 0x04000722 RID: 1826
		public Panel panel;
	}
}
