using System;

namespace Steamworks
{
	// Token: 0x02000047 RID: 71
	internal enum BroadcastUploadResult
	{
		// Token: 0x040002DD RID: 733
		None,
		// Token: 0x040002DE RID: 734
		OK,
		// Token: 0x040002DF RID: 735
		InitFailed,
		// Token: 0x040002E0 RID: 736
		FrameFailed,
		// Token: 0x040002E1 RID: 737
		Timeout,
		// Token: 0x040002E2 RID: 738
		BandwidthExceeded,
		// Token: 0x040002E3 RID: 739
		LowFPS,
		// Token: 0x040002E4 RID: 740
		MissingKeyFrames,
		// Token: 0x040002E5 RID: 741
		NoConnection,
		// Token: 0x040002E6 RID: 742
		RelayFailed,
		// Token: 0x040002E7 RID: 743
		SettingsChanged,
		// Token: 0x040002E8 RID: 744
		MissingAudio,
		// Token: 0x040002E9 RID: 745
		TooFarBehind,
		// Token: 0x040002EA RID: 746
		TranscodeBehind,
		// Token: 0x040002EB RID: 747
		NotAllowedToPlay,
		// Token: 0x040002EC RID: 748
		Busy,
		// Token: 0x040002ED RID: 749
		Banned,
		// Token: 0x040002EE RID: 750
		AlreadyActive,
		// Token: 0x040002EF RID: 751
		ForcedOff,
		// Token: 0x040002F0 RID: 752
		AudioBehind,
		// Token: 0x040002F1 RID: 753
		Shutdown,
		// Token: 0x040002F2 RID: 754
		Disconnect,
		// Token: 0x040002F3 RID: 755
		VideoInitFailed,
		// Token: 0x040002F4 RID: 756
		AudioInitFailed
	}
}
