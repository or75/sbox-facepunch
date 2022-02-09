using System;

namespace NativeEngine
{
	// Token: 0x0200025A RID: 602
	internal struct InputEvent
	{
		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06000F3E RID: 3902 RVA: 0x0001B303 File Offset: 0x00019503
		public bool IsButtonPress
		{
			get
			{
				return this.EventType == InputEventType.ButtonPressed;
			}
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x0001B30E File Offset: 0x0001950E
		public bool IsShiftPressed
		{
			get
			{
				return this.IsButtonPress && (this.m_nData2 & 1) == 1;
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06000F40 RID: 3904 RVA: 0x0001B325 File Offset: 0x00019525
		public bool IControlPressed
		{
			get
			{
				return this.IsButtonPress && (this.m_nData2 & 2) == 2;
			}
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06000F41 RID: 3905 RVA: 0x0001B33C File Offset: 0x0001953C
		public bool IsAltPressed
		{
			get
			{
				return this.IsButtonPress && (this.m_nData2 & 4) == 4;
			}
		}

		// Token: 0x170002C2 RID: 706
		// (get) Token: 0x06000F42 RID: 3906 RVA: 0x0001B353 File Offset: 0x00019553
		public bool IsWinPressed
		{
			get
			{
				return this.IsButtonPress && (this.m_nData2 & 8) == 8;
			}
		}

		// Token: 0x170002C3 RID: 707
		// (get) Token: 0x06000F43 RID: 3907 RVA: 0x0001B36A File Offset: 0x0001956A
		public bool IsFingerPress
		{
			get
			{
				return this.IsButtonPress && (this.m_nData2 & 16) == 8;
			}
		}

		// Token: 0x0400106B RID: 4203
		public IntPtr m_hWnd;

		// Token: 0x0400106C RID: 4204
		public InputEventType EventType;

		// Token: 0x0400106D RID: 4205
		public int m_nTick;

		// Token: 0x0400106E RID: 4206
		public ulong m_nData;

		// Token: 0x0400106F RID: 4207
		public int m_nData2;

		// Token: 0x04001070 RID: 4208
		public int m_nData3;

		// Token: 0x04001071 RID: 4209
		public float m_fData;

		// Token: 0x04001072 RID: 4210
		public float m_fData2;
	}
}
