using System;

namespace Sandbox
{
	// Token: 0x02000081 RID: 129
	public enum NavBlockerType
	{
		/// <summary>
		/// An "avoidance" obstacle. Places a height-based obstruction onto nav areas.
		/// </summary>
		// Token: 0x040001D9 RID: 473
		AVOID = 1,
		/// <summary>
		/// An obstacle that marks entire areas it intersects with as blocked.
		/// </summary>
		// Token: 0x040001DA RID: 474
		AREA,
		/// <summary>
		/// An obstacle that blocks nav, possibly cutting nav or triggering dynamic generation.
		/// </summary>
		// Token: 0x040001DB RID: 475
		BLOCK
	}
}
