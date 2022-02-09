using System;

namespace Sandbox
{
	// Token: 0x020002B8 RID: 696
	internal enum NetMsgType
	{
		// Token: 0x04001400 RID: 5120
		RequestFile = 1,
		// Token: 0x04001401 RID: 5121
		FileStart,
		// Token: 0x04001402 RID: 5122
		FileChunk,
		// Token: 0x04001403 RID: 5123
		GameData,
		// Token: 0x04001404 RID: 5124
		VoiceData
	}
}
