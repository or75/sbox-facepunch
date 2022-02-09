using System;

namespace Sandbox
{
	// Token: 0x020002BD RID: 701
	internal enum GameLoopStage
	{
		// Token: 0x04001417 RID: 5143
		MainLoop,
		// Token: 0x04001418 RID: 5144
		ClientIO,
		// Token: 0x04001419 RID: 5145
		ToolFrame,
		// Token: 0x0400141A RID: 5146
		GameUISimulate,
		// Token: 0x0400141B RID: 5147
		OnClientOutput,
		// Token: 0x0400141C RID: 5148
		WaitForRenderingToComplete,
		// Token: 0x0400141D RID: 5149
		ServerTick,
		// Token: 0x0400141E RID: 5150
		ClientRecv,
		// Token: 0x0400141F RID: 5151
		ClientPredict,
		// Token: 0x04001420 RID: 5152
		ClientTick,
		// Token: 0x04001421 RID: 5153
		ClientFrameSimulate,
		// Token: 0x04001422 RID: 5154
		Count
	}
}
