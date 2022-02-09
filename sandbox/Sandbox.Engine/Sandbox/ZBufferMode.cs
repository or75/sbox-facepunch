using System;

namespace Sandbox
{
	// Token: 0x020002A0 RID: 672
	public enum ZBufferMode
	{
		/// <summary>
		/// Don't test against the depth buffer, show this through everything.
		/// </summary>
		// Token: 0x04001362 RID: 4962
		None,
		/// <summary>
		/// Test against the depth buffer and write to it.
		/// </summary>
		// Token: 0x04001363 RID: 4963
		TestAndWrite,
		/// <summary>
		/// Test against the depth buffer but don't write to it.
		/// </summary>
		// Token: 0x04001364 RID: 4964
		NoWrite,
		/// <summary>
		/// Test against only those with higher depth and don't write to the depth buffer.
		/// </summary>
		// Token: 0x04001365 RID: 4965
		GreaterAndWrite,
		/// <summary>
		/// Test against only those with higher depth and write to the depth buffer.
		/// </summary>
		// Token: 0x04001366 RID: 4966
		GreaterNoWrite,
		/// <summary>
		/// Test against only those with equal depth and don't write to the depth buffer.
		/// </summary>
		// Token: 0x04001367 RID: 4967
		EqualNoWrite
	}
}
