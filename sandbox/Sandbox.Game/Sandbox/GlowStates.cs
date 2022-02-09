using System;

namespace Sandbox
{
	// Token: 0x0200008F RID: 143
	public enum GlowStates
	{
		/// <summary>Doesn't show any glow.</summary>
		// Token: 0x0400025E RID: 606
		Off,
		// Token: 0x0400025F RID: 607
		[Obsolete("Use GlowStates.Off")]
		GlowStateOff = 0,
		/// <summary>Glow appears when object is useable.</summary>
		// Token: 0x04000260 RID: 608
		Use,
		// Token: 0x04000261 RID: 609
		[Obsolete("Use GlowStates.Use")]
		GlowStateUse = 1,
		/// <summary>Glow appears when you look at object.</summary>
		// Token: 0x04000262 RID: 610
		LookAt,
		// Token: 0x04000263 RID: 611
		[Obsolete("Use GlowStates.LookAt")]
		GlowStateLookAt = 2,
		/// <summary>Glow is always enabled when active.</summary>
		// Token: 0x04000264 RID: 612
		On,
		// Token: 0x04000265 RID: 613
		[Obsolete("Use GlowStates.On")]
		GlowStateOn = 3
	}
}
