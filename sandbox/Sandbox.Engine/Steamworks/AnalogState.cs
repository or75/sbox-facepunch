using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AA RID: 170
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct AnalogState
	{
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000695 RID: 1685 RVA: 0x0000A2D1 File Offset: 0x000084D1
		internal bool Active
		{
			get
			{
				return this.BActive > 0;
			}
		}

		// Token: 0x04000931 RID: 2353
		internal InputSourceMode EMode;

		// Token: 0x04000932 RID: 2354
		internal float X;

		// Token: 0x04000933 RID: 2355
		internal float Y;

		// Token: 0x04000934 RID: 2356
		internal byte BActive;
	}
}
