using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x02000118 RID: 280
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct RemoteStorageGetPublishedFileDetailsResult_t : ICallbackData
	{
		// Token: 0x06000850 RID: 2128 RVA: 0x0000D428 File Offset: 0x0000B628
		internal string TitleUTF8()
		{
			return Encoding.UTF8.GetString(this.Title, 0, Array.IndexOf<byte>(this.Title, 0));
		}

		// Token: 0x06000851 RID: 2129 RVA: 0x0000D447 File Offset: 0x0000B647
		internal string DescriptionUTF8()
		{
			return Encoding.UTF8.GetString(this.Description, 0, Array.IndexOf<byte>(this.Description, 0));
		}

		// Token: 0x06000852 RID: 2130 RVA: 0x0000D466 File Offset: 0x0000B666
		internal string TagsUTF8()
		{
			return Encoding.UTF8.GetString(this.Tags, 0, Array.IndexOf<byte>(this.Tags, 0));
		}

		// Token: 0x06000853 RID: 2131 RVA: 0x0000D485 File Offset: 0x0000B685
		internal string PchFileNameUTF8()
		{
			return Encoding.UTF8.GetString(this.PchFileName, 0, Array.IndexOf<byte>(this.PchFileName, 0));
		}

		// Token: 0x06000854 RID: 2132 RVA: 0x0000D4A4 File Offset: 0x0000B6A4
		internal string URLUTF8()
		{
			return Encoding.UTF8.GetString(this.URL, 0, Array.IndexOf<byte>(this.URL, 0));
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000855 RID: 2133 RVA: 0x0000D4C3 File Offset: 0x0000B6C3
		public int DataSize
		{
			get
			{
				return RemoteStorageGetPublishedFileDetailsResult_t._datasize;
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000856 RID: 2134 RVA: 0x0000D4CA File Offset: 0x0000B6CA
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.RemoteStorageGetPublishedFileDetailsResult;
			}
		}

		// Token: 0x04000A95 RID: 2709
		internal Result Result;

		// Token: 0x04000A96 RID: 2710
		internal PublishedFileId PublishedFileId;

		// Token: 0x04000A97 RID: 2711
		internal AppId CreatorAppID;

		// Token: 0x04000A98 RID: 2712
		internal AppId ConsumerAppID;

		// Token: 0x04000A99 RID: 2713
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 129)]
		internal byte[] Title;

		// Token: 0x04000A9A RID: 2714
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8000)]
		internal byte[] Description;

		// Token: 0x04000A9B RID: 2715
		internal ulong File;

		// Token: 0x04000A9C RID: 2716
		internal ulong PreviewFile;

		// Token: 0x04000A9D RID: 2717
		internal ulong SteamIDOwner;

		// Token: 0x04000A9E RID: 2718
		internal uint TimeCreated;

		// Token: 0x04000A9F RID: 2719
		internal uint TimeUpdated;

		// Token: 0x04000AA0 RID: 2720
		internal RemoteStoragePublishedFileVisibility Visibility;

		// Token: 0x04000AA1 RID: 2721
		[MarshalAs(UnmanagedType.I1)]
		internal bool Banned;

		// Token: 0x04000AA2 RID: 2722
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1025)]
		internal byte[] Tags;

		// Token: 0x04000AA3 RID: 2723
		[MarshalAs(UnmanagedType.I1)]
		internal bool TagsTruncated;

		// Token: 0x04000AA4 RID: 2724
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
		internal byte[] PchFileName;

		// Token: 0x04000AA5 RID: 2725
		internal int FileSize;

		// Token: 0x04000AA6 RID: 2726
		internal int PreviewFileSize;

		// Token: 0x04000AA7 RID: 2727
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal byte[] URL;

		// Token: 0x04000AA8 RID: 2728
		internal WorkshopFileType FileType;

		// Token: 0x04000AA9 RID: 2729
		[MarshalAs(UnmanagedType.I1)]
		internal bool AcceptedForUse;

		// Token: 0x04000AAA RID: 2730
		internal static int _datasize = Marshal.SizeOf(typeof(RemoteStorageGetPublishedFileDetailsResult_t));
	}
}
