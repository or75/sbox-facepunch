using System;

namespace Sandbox.UI
{
	// Token: 0x02000123 RID: 291
	public class PanelEvent
	{
		// Token: 0x060016FA RID: 5882 RVA: 0x0005C4E3 File Offset: 0x0005A6E3
		public PanelEvent(string event_name, Panel active)
		{
			this.Name = event_name;
			this.Target = active;
		}

		// Token: 0x060016FB RID: 5883 RVA: 0x0005C500 File Offset: 0x0005A700
		public bool Is(string name)
		{
			return string.Equals(name, this.Name, StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x060016FC RID: 5884 RVA: 0x0005C50F File Offset: 0x0005A70F
		public void StopPropagation()
		{
			this.Propagate = false;
		}

		// Token: 0x040005BB RID: 1467
		public string Name;

		// Token: 0x040005BC RID: 1468
		public object Value;

		// Token: 0x040005BD RID: 1469
		public float Time;

		// Token: 0x040005BE RID: 1470
		public Panel Target;

		// Token: 0x040005BF RID: 1471
		internal bool Propagate = true;
	}
}
