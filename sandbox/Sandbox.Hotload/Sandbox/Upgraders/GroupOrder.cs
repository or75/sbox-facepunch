using System;

namespace Sandbox.Upgraders
{
	// Token: 0x02000020 RID: 32
	public enum GroupOrder
	{
		/// <summary>
		/// Only use <see cref="T:Sandbox.Upgraders.AttemptBeforeAttribute" /> and <see cref="T:Sandbox.Upgraders.AttemptAfterAttribute" /> to
		/// determine ordering within a <see cref="T:Sandbox.Upgraders.UpgraderGroup" />.
		/// </summary>
		// Token: 0x04000041 RID: 65
		Default,
		/// <summary>
		/// Try to put this upgrader as close to the start of the given group as possible.
		/// </summary>
		// Token: 0x04000042 RID: 66
		First,
		/// <summary>
		/// Try to put this upgrader as close to the end of the given group as possible.
		/// </summary>
		// Token: 0x04000043 RID: 67
		Last
	}
}
