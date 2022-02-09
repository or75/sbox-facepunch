using System;

namespace Sandbox
{
	// Token: 0x0200002A RID: 42
	public abstract class TextValueAttribute : Attribute
	{
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x0600028D RID: 653 RVA: 0x0000AFA0 File Offset: 0x000091A0
		// (set) Token: 0x0600028E RID: 654 RVA: 0x0000AFA8 File Offset: 0x000091A8
		public string Value { get; set; }

		// Token: 0x0600028F RID: 655 RVA: 0x0000AFB1 File Offset: 0x000091B1
		public TextValueAttribute()
		{
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000AFB9 File Offset: 0x000091B9
		public TextValueAttribute(string value)
		{
			this.Value = value;
		}
	}
}
