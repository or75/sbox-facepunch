using System;

namespace Sandbox.UI
{
	/// <summary>
	/// If no name is passed, we will look next to the name of the file with this attribute
	/// </summary>
	// Token: 0x0200014E RID: 334
	public sealed class UseTemplateAttribute : Attribute
	{
		// Token: 0x0600193A RID: 6458 RVA: 0x0006A5C5 File Offset: 0x000687C5
		public UseTemplateAttribute()
		{
		}

		// Token: 0x0600193B RID: 6459 RVA: 0x0006A5CD File Offset: 0x000687CD
		public UseTemplateAttribute(string name)
		{
			this.Name = name;
		}

		// Token: 0x040006DF RID: 1759
		public string Name;
	}
}
