using System;

namespace Sandbox
{
	// Token: 0x020000BF RID: 191
	public enum NavAreaAttribute : ulong
	{
		/// <summary>
		/// Must crouch to use this node/area
		/// </summary>
		// Token: 0x04000392 RID: 914
		Crouch = 1UL,
		/// <summary>
		/// Must jump to traverse this area (only used during generation)
		/// </summary>
		// Token: 0x04000393 RID: 915
		Jump,
		/// <summary>
		/// Do not adjust for obstacles, just move along area
		/// </summary>
		// Token: 0x04000394 RID: 916
		Precise = 4UL,
		/// <summary>
		/// Inhibit discontinuity jumping
		/// </summary>
		// Token: 0x04000395 RID: 917
		NoJump = 8UL,
		/// <summary>
		/// Avoid this area unless alternatives are too dangerous
		/// </summary>
		// Token: 0x04000396 RID: 918
		Avoid = 128UL,
		/// <summary>
		/// This area represents stairs, do not attempt to climb or jump them - just walk up
		/// </summary>
		// Token: 0x04000397 RID: 919
		Stairs = 4096UL,
		/// <summary>
		/// Don't merge this area with adjacent areas
		/// </summary>
		// Token: 0x04000398 RID: 920
		NoMerge = 8192UL,
		/// <summary>
		/// This nav area is the climb point on the tip of an obstacle
		/// </summary>
		// Token: 0x04000399 RID: 921
		ObstacleTop = 16384UL,
		/// <summary>
		/// This nav area is adjacent to a drop of at least CliffHeight
		/// </summary>
		// Token: 0x0400039A RID: 922
		Cliff = 32768UL
	}
}
