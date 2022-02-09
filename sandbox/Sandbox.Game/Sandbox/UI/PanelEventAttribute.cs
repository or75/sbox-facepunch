using System;

namespace Sandbox.UI
{
	// Token: 0x02000126 RID: 294
	public class PanelEventAttribute : Attribute
	{
		// Token: 0x17000398 RID: 920
		// (get) Token: 0x060016FF RID: 5887 RVA: 0x0005C560 File Offset: 0x0005A760
		// (set) Token: 0x06001700 RID: 5888 RVA: 0x0005C568 File Offset: 0x0005A768
		public string Name { get; set; }

		// Token: 0x06001701 RID: 5889 RVA: 0x0005C571 File Offset: 0x0005A771
		public PanelEventAttribute(string name = null)
		{
			this.Name = name;
		}
	}
}
