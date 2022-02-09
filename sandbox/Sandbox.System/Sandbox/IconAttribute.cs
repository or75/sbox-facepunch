using System;

namespace Sandbox
{
	// Token: 0x0200002E RID: 46
	public class IconAttribute : TextValueAttribute
	{
		// Token: 0x06000294 RID: 660 RVA: 0x0000AFE3 File Offset: 0x000091E3
		public IconAttribute(MaterialIcon icon)
		{
			base.Value = MaterialIconUtility.Lookup(icon);
		}

		// Token: 0x06000295 RID: 661 RVA: 0x0000AFF7 File Offset: 0x000091F7
		public IconAttribute(string icon)
			: base(icon)
		{
		}
	}
}
