using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x020001AC RID: 428
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamUGCDetails_t
	{
		// Token: 0x06000A40 RID: 2624 RVA: 0x0000EE4A File Offset: 0x0000D04A
		internal string TitleUTF8()
		{
			return Encoding.UTF8.GetString(this.Title, 0, Array.IndexOf<byte>(this.Title, 0));
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x0000EE69 File Offset: 0x0000D069
		internal string DescriptionUTF8()
		{
			return Encoding.UTF8.GetString(this.Description, 0, Array.IndexOf<byte>(this.Description, 0));
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x0000EE88 File Offset: 0x0000D088
		internal string TagsUTF8()
		{
			return Encoding.UTF8.GetString(this.Tags, 0, Array.IndexOf<byte>(this.Tags, 0));
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x0000EEA7 File Offset: 0x0000D0A7
		internal string PchFileNameUTF8()
		{
			return Encoding.UTF8.GetString(this.PchFileName, 0, Array.IndexOf<byte>(this.PchFileName, 0));
		}

		// Token: 0x06000A44 RID: 2628 RVA: 0x0000EEC6 File Offset: 0x0000D0C6
		internal string URLUTF8()
		{
			return Encoding.UTF8.GetString(this.URL, 0, Array.IndexOf<byte>(this.URL, 0));
		}

		// Token: 0x04000D14 RID: 3348
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000D15 RID: 3349
		internal Result Result;

		// Token: 0x04000D16 RID: 3350
		internal WorkshopFileType FileType;

		// Token: 0x04000D17 RID: 3351
		internal AppId CreatorAppID;

		// Token: 0x04000D18 RID: 3352
		internal AppId ConsumerAppID;

		// Token: 0x04000D19 RID: 3353
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
		internal byte[] Title;

		// Token: 0x04000D1A RID: 3354
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8000)]
		internal byte[] Description;

		// Token: 0x04000D1B RID: 3355
		internal ulong SteamIDOwner;

		// Token: 0x04000D1C RID: 3356
		internal uint TimeCreated;

		// Token: 0x04000D1D RID: 3357
		internal uint TimeUpdated;

		// Token: 0x04000D1E RID: 3358
		internal uint TimeAddedToUserList;

		// Token: 0x04000D1F RID: 3359
		internal RemoteStoragePublishedFileVisibility Visibility;

		// Token: 0x04000D20 RID: 3360
		[MarshalAs(UnmanagedType.I1)]
		internal bool Banned;

		// Token: 0x04000D21 RID: 3361
		[MarshalAs(UnmanagedType.I1)]
		internal bool AcceptedForUse;

		// Token: 0x04000D22 RID: 3362
		[MarshalAs(UnmanagedType.I1)]
		internal bool TagsTruncated;

		// Token: 0x04000D23 RID: 3363
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)]
		internal byte[] Tags;

		// Token: 0x04000D24 RID: 3364
		internal ulong File;

		// Token: 0x04000D25 RID: 3365
		internal ulong PreviewFile;

		// Token: 0x04000D26 RID: 3366
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
		internal byte[] PchFileName;

		// Token: 0x04000D27 RID: 3367
		internal int FileSize;

		// Token: 0x04000D28 RID: 3368
		internal int PreviewFileSize;

		// Token: 0x04000D29 RID: 3369
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal byte[] URL;

		// Token: 0x04000D2A RID: 3370
		internal uint VotesUp;

		// Token: 0x04000D2B RID: 3371
		internal uint VotesDown;

		// Token: 0x04000D2C RID: 3372
		internal float Score;

		// Token: 0x04000D2D RID: 3373
		internal uint NumChildren;
	}
}
