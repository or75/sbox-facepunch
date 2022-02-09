using System;

namespace Sandbox.UI
{
	// Token: 0x02000125 RID: 293
	public class SelectionEvent : PanelEvent
	{
		// Token: 0x060016FE RID: 5886 RVA: 0x0005C548 File Offset: 0x0005A748
		public SelectionEvent(string event_name, Panel active)
			: base(event_name, active)
		{
			this.Name = event_name;
			this.Target = active;
		}

		// Token: 0x040005C2 RID: 1474
		public Rect SelectionRect;

		// Token: 0x040005C3 RID: 1475
		public Vector2 StartPoint;

		// Token: 0x040005C4 RID: 1476
		public Vector2 EndPoint;
	}
}
