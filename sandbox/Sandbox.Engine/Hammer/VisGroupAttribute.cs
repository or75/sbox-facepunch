using System;
using System.Collections.Generic;

namespace Hammer
{
	/// <summary>
	/// Makes the entity show up under given automatic visibility group in Hammer.
	/// </summary>
	// Token: 0x02000206 RID: 518
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class VisGroupAttribute : MetaDataAttribute
	{
		// Token: 0x06000D15 RID: 3349 RVA: 0x00016641 File Offset: 0x00014841
		public VisGroupAttribute(VisGroup group)
		{
			this.tag = group.ToString();
		}

		// Token: 0x06000D16 RID: 3350 RVA: 0x00016667 File Offset: 0x00014867
		public override void AddTags(List<string> tags)
		{
			tags.Add(this.tag);
		}

		// Token: 0x04000DD7 RID: 3543
		private string tag = "";
	}
}
