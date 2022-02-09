using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000AC RID: 172
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	internal struct DigitalState
	{
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000696 RID: 1686 RVA: 0x0000A2DC File Offset: 0x000084DC
		public bool Pressed
		{
			get
			{
				return this.BState > 0;
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000697 RID: 1687 RVA: 0x0000A2E7 File Offset: 0x000084E7
		public bool Active
		{
			get
			{
				return this.BActive > 0;
			}
		}

		// Token: 0x0400093F RID: 2367
		[MarshalAs(UnmanagedType.I1)]
		internal byte BState;

		// Token: 0x04000940 RID: 2368
		[MarshalAs(UnmanagedType.I1)]
		internal byte BActive;
	}
}
