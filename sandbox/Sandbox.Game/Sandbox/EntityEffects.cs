using System;

namespace Sandbox
{
	/// <summary>
	/// Note - most of these aren't used
	/// </summary>
	// Token: 0x02000089 RID: 137
	internal enum EntityEffects
	{
		// Token: 0x0400020E RID: 526
		HiddenCastsShadows = 1,
		/// <summary>
		/// Copy the parent's nodraw..
		/// </summary>
		// Token: 0x0400020F RID: 527
		HiddenInFirstPerson = 8,
		// Token: 0x04000210 RID: 528
		NoShadow = 16,
		// Token: 0x04000211 RID: 529
		NoDraw = 32,
		// Token: 0x04000212 RID: 530
		NoReceiveShadow = 64,
		/// <summary>
		/// Change the render layer to viewmodel
		/// </summary>
		// Token: 0x04000213 RID: 531
		DrawAsViewModel = 128,
		// Token: 0x04000214 RID: 532
		ShadowOnly = 256,
		/// <summary>
		/// similar to ignorez to draw over world but still having depth info
		/// </summary>
		// Token: 0x04000215 RID: 533
		DrawOverDepth = 2048,
		// Token: 0x04000216 RID: 534
		SpawnedWithMap = 4096
	}
}
