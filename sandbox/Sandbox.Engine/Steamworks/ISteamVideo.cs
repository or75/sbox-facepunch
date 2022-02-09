using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000039 RID: 57
	internal class ISteamVideo : SteamInterface
	{
		// Token: 0x06000524 RID: 1316 RVA: 0x0000672E File Offset: 0x0000492E
		internal ISteamVideo(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x06000525 RID: 1317
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamVideo_v002();

		// Token: 0x06000526 RID: 1318 RVA: 0x0000673D File Offset: 0x0000493D
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamVideo.SteamAPI_SteamVideo_v002();
		}

		// Token: 0x06000527 RID: 1319
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamVideo_GetVideoURL")]
		private static extern void _GetVideoURL(IntPtr self, AppId unVideoAppID);

		// Token: 0x06000528 RID: 1320 RVA: 0x00006744 File Offset: 0x00004944
		internal void GetVideoURL(AppId unVideoAppID)
		{
			ISteamVideo._GetVideoURL(this.Self, unVideoAppID);
		}

		// Token: 0x06000529 RID: 1321
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamVideo_IsBroadcasting")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _IsBroadcasting(IntPtr self, ref int pnNumViewers);

		// Token: 0x0600052A RID: 1322 RVA: 0x00006752 File Offset: 0x00004952
		internal bool IsBroadcasting(ref int pnNumViewers)
		{
			return ISteamVideo._IsBroadcasting(this.Self, ref pnNumViewers);
		}

		// Token: 0x0600052B RID: 1323
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamVideo_GetOPFSettings")]
		private static extern void _GetOPFSettings(IntPtr self, AppId unVideoAppID);

		// Token: 0x0600052C RID: 1324 RVA: 0x00006760 File Offset: 0x00004960
		internal void GetOPFSettings(AppId unVideoAppID)
		{
			ISteamVideo._GetOPFSettings(this.Self, unVideoAppID);
		}

		// Token: 0x0600052D RID: 1325
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamVideo_GetOPFStringForApp")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _GetOPFStringForApp(IntPtr self, AppId unVideoAppID, IntPtr pchBuffer, ref int pnBufferSize);

		// Token: 0x0600052E RID: 1326 RVA: 0x00006770 File Offset: 0x00004970
		internal bool GetOPFStringForApp(AppId unVideoAppID, out string pchBuffer, ref int pnBufferSize)
		{
			Helpers.Memory mempchBuffer = Helpers.TakeMemory();
			bool result;
			try
			{
				bool flag = ISteamVideo._GetOPFStringForApp(this.Self, unVideoAppID, mempchBuffer, ref pnBufferSize);
				pchBuffer = Helpers.MemoryToString(mempchBuffer);
				result = flag;
			}
			finally
			{
				((IDisposable)mempchBuffer).Dispose();
			}
			return result;
		}
	}
}
