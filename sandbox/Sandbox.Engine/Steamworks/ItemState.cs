using System;

namespace Steamworks
{
	// Token: 0x0200008A RID: 138
	internal enum ItemState
	{
		// Token: 0x04000811 RID: 2065
		None,
		// Token: 0x04000812 RID: 2066
		Subscribed,
		// Token: 0x04000813 RID: 2067
		LegacyItem,
		// Token: 0x04000814 RID: 2068
		Installed = 4,
		// Token: 0x04000815 RID: 2069
		NeedsUpdate = 8,
		// Token: 0x04000816 RID: 2070
		Downloading = 16,
		// Token: 0x04000817 RID: 2071
		DownloadPending = 32
	}
}
