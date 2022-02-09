using System;

namespace Steamworks.Data
{
	// Token: 0x020001EA RID: 490
	internal struct Screenshot
	{
		/// <summary>
		/// Tags a user as being visible in the screenshot
		/// </summary>
		// Token: 0x06000C1B RID: 3099 RVA: 0x0001149F File Offset: 0x0000F69F
		internal bool TagUser(SteamId user)
		{
			return SteamScreenshots.Internal.TagUser(this.Value, user);
		}

		/// <summary>
		/// Tags a user as being visible in the screenshot
		/// </summary>
		// Token: 0x06000C1C RID: 3100 RVA: 0x000114B2 File Offset: 0x0000F6B2
		internal bool SetLocation(string location)
		{
			return SteamScreenshots.Internal.SetLocation(this.Value, location);
		}

		/// <summary>
		/// Tags a user as being visible in the screenshot
		/// </summary>
		// Token: 0x06000C1D RID: 3101 RVA: 0x000114C5 File Offset: 0x0000F6C5
		internal bool TagPublishedFile(PublishedFileId file)
		{
			return SteamScreenshots.Internal.TagPublishedFile(this.Value, file);
		}

		// Token: 0x04000D8E RID: 3470
		internal ScreenshotHandle Value;
	}
}
