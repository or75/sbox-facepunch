using System;

namespace Sandbox
{
	// Token: 0x0200006F RID: 111
	public struct KeyModifiers
	{
		// Token: 0x06000C5C RID: 3164 RVA: 0x0003F8CF File Offset: 0x0003DACF
		internal KeyModifiers(int data)
		{
			this.Shift = (data & 1) == 1;
			this.Ctrl = (data & 2) == 2;
			this.Alt = (data & 4) == 4;
			this.Windows = (data & 8) == 8;
			this.FingerPress = (data & 16) == 16;
		}

		// Token: 0x040001A3 RID: 419
		public bool Shift;

		// Token: 0x040001A4 RID: 420
		public bool Alt;

		// Token: 0x040001A5 RID: 421
		public bool Windows;

		// Token: 0x040001A6 RID: 422
		internal bool FingerPress;

		// Token: 0x040001A7 RID: 423
		public bool Ctrl;
	}
}
