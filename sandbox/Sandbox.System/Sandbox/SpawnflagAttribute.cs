using System;

namespace Sandbox
{
	// Token: 0x02000037 RID: 55
	[AttributeUsage(AttributeTargets.Field)]
	public class SpawnflagAttribute : Attribute
	{
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060002F2 RID: 754 RVA: 0x0000BAEF File Offset: 0x00009CEF
		// (set) Token: 0x060002F3 RID: 755 RVA: 0x0000BAF7 File Offset: 0x00009CF7
		public string Name { get; set; }

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060002F4 RID: 756 RVA: 0x0000BB00 File Offset: 0x00009D00
		// (set) Token: 0x060002F5 RID: 757 RVA: 0x0000BB08 File Offset: 0x00009D08
		public string Help { get; set; }

		// Token: 0x060002F6 RID: 758 RVA: 0x0000BB11 File Offset: 0x00009D11
		public SpawnflagAttribute()
		{
		}

		// Token: 0x060002F7 RID: 759 RVA: 0x0000BB19 File Offset: 0x00009D19
		public SpawnflagAttribute(string help)
		{
			this.Help = help;
		}
	}
}
