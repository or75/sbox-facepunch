using System;
using System.Collections.Generic;

namespace Sandbox.EntityIO
{
	// Token: 0x0200016C RID: 364
	internal class OutputCollection : Dictionary<string, List<Output>>
	{
		// Token: 0x06001B60 RID: 7008 RVA: 0x0006E5B1 File Offset: 0x0006C7B1
		public OutputCollection()
			: base(StringComparer.OrdinalIgnoreCase)
		{
		}

		// Token: 0x06001B61 RID: 7009 RVA: 0x0006E5C0 File Offset: 0x0006C7C0
		public List<Output> GetOrCreate(string name)
		{
			List<Output> val;
			if (base.TryGetValue(name, out val))
			{
				return val;
			}
			List<Output> list = new List<Output>();
			base[name] = list;
			return list;
		}
	}
}
