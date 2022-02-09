using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AB RID: 171
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct MotionState
	{
		// Token: 0x04000935 RID: 2357
		internal float RotQuatX;

		// Token: 0x04000936 RID: 2358
		internal float RotQuatY;

		// Token: 0x04000937 RID: 2359
		internal float RotQuatZ;

		// Token: 0x04000938 RID: 2360
		internal float RotQuatW;

		// Token: 0x04000939 RID: 2361
		internal float PosAccelX;

		// Token: 0x0400093A RID: 2362
		internal float PosAccelY;

		// Token: 0x0400093B RID: 2363
		internal float PosAccelZ;

		// Token: 0x0400093C RID: 2364
		internal float RotVelX;

		// Token: 0x0400093D RID: 2365
		internal float RotVelY;

		// Token: 0x0400093E RID: 2366
		internal float RotVelZ;
	}
}
