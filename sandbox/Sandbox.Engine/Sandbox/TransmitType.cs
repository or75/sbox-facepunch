using System;

namespace Sandbox
{
	// Token: 0x0200029F RID: 671
	public enum TransmitType
	{
		// Token: 0x0400135B RID: 4955
		Default,
		// Token: 0x0400135C RID: 4956
		Always,
		// Token: 0x0400135D RID: 4957
		Never,
		// Token: 0x0400135E RID: 4958
		[Obsolete("Renamed to Pvs")]
		Culled,
		/// <summary>
		/// Entity will be networked if it's in a client (or its Pawn's) PVS
		/// </summary>
		// Token: 0x0400135F RID: 4959
		Pvs = 3,
		// Token: 0x04001360 RID: 4960
		Owner
	}
}
