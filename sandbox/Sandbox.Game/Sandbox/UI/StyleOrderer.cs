using System;
using System.Collections.Generic;

namespace Sandbox.UI
{
	// Token: 0x02000121 RID: 289
	internal class StyleOrderer : IComparer<StyleSelector>
	{
		// Token: 0x0600161D RID: 5661 RVA: 0x00058D6D File Offset: 0x00056F6D
		public int Compare(StyleSelector x, StyleSelector y)
		{
			return x.Score - y.Score;
		}

		// Token: 0x0400058C RID: 1420
		internal static StyleOrderer Instance = new StyleOrderer();
	}
}
