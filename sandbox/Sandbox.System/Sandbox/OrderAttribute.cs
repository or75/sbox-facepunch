using System;

namespace Sandbox
{
	// Token: 0x0200002F RID: 47
	public abstract class OrderAttribute : Attribute
	{
		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000296 RID: 662 RVA: 0x0000B000 File Offset: 0x00009200
		// (set) Token: 0x06000297 RID: 663 RVA: 0x0000B008 File Offset: 0x00009208
		public int Value { get; set; }

		// Token: 0x06000298 RID: 664 RVA: 0x0000B011 File Offset: 0x00009211
		public OrderAttribute(int value)
		{
			this.Value = value;
		}
	}
}
