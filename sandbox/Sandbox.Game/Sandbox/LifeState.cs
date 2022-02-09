using System;

namespace Sandbox
{
	// Token: 0x020000AB RID: 171
	public enum LifeState
	{
		/// <summary>
		/// Alive as normal
		/// </summary>
		// Token: 0x04000318 RID: 792
		Alive,
		/// <summary>
		/// Playing a death animation
		/// </summary>
		// Token: 0x04000319 RID: 793
		Dying,
		/// <summary>
		/// Dead, lying still
		/// </summary>
		// Token: 0x0400031A RID: 794
		Dead,
		/// <summary>
		/// Can respawn, usually waiting for some client action to respawn
		/// </summary>
		// Token: 0x0400031B RID: 795
		Respawnable,
		/// <summary>
		/// Is in the process of respawning
		/// </summary>
		// Token: 0x0400031C RID: 796
		Respawning
	}
}
