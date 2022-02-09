using System;
using System.Collections.Generic;

namespace Hammer
{
	/// <summary>
	/// This is a point class entity (appears in Entity Tool), but does support being a brush entity (a mesh tied to an entity).
	/// </summary>
	// Token: 0x02000204 RID: 516
	[AttributeUsage(AttributeTargets.Class)]
	public class SupportsSolidAttribute : MetaDataAttribute
	{
		// Token: 0x06000D11 RID: 3345 RVA: 0x00016617 File Offset: 0x00014817
		public override void AddTags(List<string> tags)
		{
			tags.Add("SupportsSolids");
		}
	}
}
