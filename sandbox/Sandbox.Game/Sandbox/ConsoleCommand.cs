using System;
using System.Linq;

namespace Sandbox
{
	// Token: 0x02000073 RID: 115
	internal struct ConsoleCommand
	{
		// Token: 0x06000C8C RID: 3212 RVA: 0x00040847 File Offset: 0x0003EA47
		internal ConsoleCommand(string name, string[] arguments)
		{
			this.Name = name;
			this.Arguments = arguments;
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x00040858 File Offset: 0x0003EA58
		internal string ToStringCommand()
		{
			if (this.Arguments == null)
			{
				return this.Name;
			}
			return this.Name + " " + string.Join(" ", this.Arguments.Select((string x) => (x ?? "").QuoteSafe()));
		}

		// Token: 0x040001AF RID: 431
		public string Name;

		// Token: 0x040001B0 RID: 432
		public string[] Arguments;
	}
}
