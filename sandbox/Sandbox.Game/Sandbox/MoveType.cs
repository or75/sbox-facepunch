using System;

namespace Sandbox
{
	// Token: 0x02000090 RID: 144
	public enum MoveType : byte
	{
		// Token: 0x04000267 RID: 615
		None,
		// Token: 0x04000268 RID: 616
		MOVETYPE_ISOMETRIC,
		// Token: 0x04000269 RID: 617
		MOVETYPE_WALK,
		// Token: 0x0400026A RID: 618
		MOVETYPE_STEP,
		// Token: 0x0400026B RID: 619
		MOVETYPE_FLY,
		// Token: 0x0400026C RID: 620
		MOVETYPE_FLYGRAVITY,
		/// <summary>
		/// Use physics simulation
		/// </summary>
		// Token: 0x0400026D RID: 621
		Physics,
		/// <summary>
		/// no clip to world, push and crush
		/// </summary>
		// Token: 0x0400026E RID: 622
		Push,
		// Token: 0x0400026F RID: 623
		MOVETYPE_NOCLIP,
		// Token: 0x04000270 RID: 624
		MOVETYPE_LADDER,
		// Token: 0x04000271 RID: 625
		MOVETYPE_OBSERVER,
		// Token: 0x04000272 RID: 626
		MOVETYPE_CUSTOM,
		// Token: 0x04000273 RID: 627
		MOVETYPE_LAST = 11,
		// Token: 0x04000274 RID: 628
		MOVETYPE_MAX_BITS = 4
	}
}
