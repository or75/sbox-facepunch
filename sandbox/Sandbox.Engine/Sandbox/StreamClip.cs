using System;
using Sandbox.Twitch;

namespace Sandbox
{
	// Token: 0x020002D5 RID: 725
	public struct StreamClip
	{
		// Token: 0x060012E9 RID: 4841 RVA: 0x000274EE File Offset: 0x000256EE
		internal StreamClip(TwitchAPI.CreateClipResponse clip)
		{
			this.EditUrl = clip.EditUrl;
			this.Id = clip.Id;
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x060012EA RID: 4842 RVA: 0x00027508 File Offset: 0x00025708
		// (set) Token: 0x060012EB RID: 4843 RVA: 0x00027510 File Offset: 0x00025710
		public string EditUrl { readonly get; internal set; }

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x060012EC RID: 4844 RVA: 0x00027519 File Offset: 0x00025719
		// (set) Token: 0x060012ED RID: 4845 RVA: 0x00027521 File Offset: 0x00025721
		public string Id { readonly get; internal set; }
	}
}
