using System;

namespace Sandbox.UI
{
	// Token: 0x02000124 RID: 292
	public class MousePanelEvent : PanelEvent
	{
		// Token: 0x060016FD RID: 5885 RVA: 0x0005C518 File Offset: 0x0005A718
		public MousePanelEvent(string event_name, Panel active, string button)
			: base(event_name, active)
		{
			this.Name = event_name;
			this.Target = active;
			this.LocalPosition = this.Target.MousePosition;
			this.Button = button;
		}

		// Token: 0x040005C0 RID: 1472
		public Vector2 LocalPosition;

		// Token: 0x040005C1 RID: 1473
		public string Button;
	}
}
