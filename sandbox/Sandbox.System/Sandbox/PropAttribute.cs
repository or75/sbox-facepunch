using System;

namespace Sandbox
{
	// Token: 0x02000034 RID: 52
	[Obsolete("Please change [Prop] to [Property]")]
	public class PropAttribute : PropertyAttribute
	{
		// Token: 0x060002D7 RID: 727 RVA: 0x0000B7E1 File Offset: 0x000099E1
		public PropAttribute()
		{
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0000B7E9 File Offset: 0x000099E9
		public PropAttribute(string name, string help = null)
			: base(name, help)
		{
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0000B7F3 File Offset: 0x000099F3
		public PropAttribute(string name, string title, string help = null)
			: base(name, title, help)
		{
		}
	}
}
