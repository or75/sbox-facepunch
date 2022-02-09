using System;

namespace Sandbox.UI
{
	// Token: 0x02000147 RID: 327
	public enum ColorInterpolation
	{
		/// <summary>
		/// Automatically pick between linear or lab based on the input
		/// </summary>
		// Token: 0x040006C0 RID: 1728
		Auto,
		/// <summary>
		/// Linearly interpolate
		/// </summary>
		// Token: 0x040006C1 RID: 1729
		Linear,
		/// <summary>
		/// Use the LAB color space for interpolation
		/// </summary>
		// Token: 0x040006C2 RID: 1730
		Lab
	}
}
