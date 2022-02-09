using System;

namespace Steamworks
{
	// Token: 0x0200003D RID: 61
	internal enum VoiceResult
	{
		// Token: 0x0400027A RID: 634
		OK,
		// Token: 0x0400027B RID: 635
		NotInitialized,
		// Token: 0x0400027C RID: 636
		NotRecording,
		// Token: 0x0400027D RID: 637
		NoData,
		// Token: 0x0400027E RID: 638
		BufferTooSmall,
		// Token: 0x0400027F RID: 639
		DataCorrupted,
		// Token: 0x04000280 RID: 640
		Restricted,
		// Token: 0x04000281 RID: 641
		UnsupportedCodec,
		// Token: 0x04000282 RID: 642
		ReceiverOutOfDate,
		// Token: 0x04000283 RID: 643
		ReceiverDidNotAnswer
	}
}
