using System;
using System.Collections.Generic;

namespace Sandbox.UI
{
	/// <summary>
	/// A CSS rule - ie ".chin { width: 100%; height: 100%; }"
	/// </summary>
	// Token: 0x02000138 RID: 312
	[Hotload.SkipAttribute]
	public sealed class StyleBlock
	{
		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x0600188C RID: 6284 RVA: 0x00064604 File Offset: 0x00062804
		// (set) Token: 0x0600188D RID: 6285 RVA: 0x0006460C File Offset: 0x0006280C
		public List<StyleSelector> Selectors { get; private set; }

		// Token: 0x0600188E RID: 6286 RVA: 0x00064618 File Offset: 0x00062818
		internal StyleSelector Test(Panel panel)
		{
			if (this.Selectors == null)
			{
				return null;
			}
			for (int i = 0; i < this.Selectors.Count; i++)
			{
				if (this.Selectors[i].Test(panel))
				{
					return this.Selectors[i];
				}
			}
			return null;
		}

		// Token: 0x0600188F RID: 6287 RVA: 0x00064668 File Offset: 0x00062868
		public bool SetSelector(string selector, StyleBlock parent = null)
		{
			this.Selectors = StyleParser.Selector(selector, parent);
			if (this.Selectors == null)
			{
				return false;
			}
			foreach (StyleSelector styleSelector in this.Selectors)
			{
				styleSelector.Finalize(this);
			}
			return true;
		}

		// Token: 0x04000679 RID: 1657
		internal int LoadOrder;

		// Token: 0x0400067B RID: 1659
		public Styles Styles;
	}
}
