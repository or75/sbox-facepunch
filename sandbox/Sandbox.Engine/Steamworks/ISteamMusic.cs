using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000031 RID: 49
	internal class ISteamMusic : SteamInterface
	{
		// Token: 0x060003AA RID: 938 RVA: 0x00005A1C File Offset: 0x00003C1C
		internal ISteamMusic(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x060003AB RID: 939
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamMusic_v001();

		// Token: 0x060003AC RID: 940 RVA: 0x00005A2B File Offset: 0x00003C2B
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamMusic.SteamAPI_SteamMusic_v001();
		}

		// Token: 0x060003AD RID: 941
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusic_BIsEnabled")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsEnabled(IntPtr self);

		// Token: 0x060003AE RID: 942 RVA: 0x00005A32 File Offset: 0x00003C32
		internal bool BIsEnabled()
		{
			return ISteamMusic._BIsEnabled(this.Self);
		}

		// Token: 0x060003AF RID: 943
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusic_BIsPlaying")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsPlaying(IntPtr self);

		// Token: 0x060003B0 RID: 944 RVA: 0x00005A3F File Offset: 0x00003C3F
		internal bool BIsPlaying()
		{
			return ISteamMusic._BIsPlaying(this.Self);
		}

		// Token: 0x060003B1 RID: 945
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusic_GetPlaybackStatus")]
		private static extern MusicStatus _GetPlaybackStatus(IntPtr self);

		// Token: 0x060003B2 RID: 946 RVA: 0x00005A4C File Offset: 0x00003C4C
		internal MusicStatus GetPlaybackStatus()
		{
			return ISteamMusic._GetPlaybackStatus(this.Self);
		}

		// Token: 0x060003B3 RID: 947
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusic_Play")]
		private static extern void _Play(IntPtr self);

		// Token: 0x060003B4 RID: 948 RVA: 0x00005A59 File Offset: 0x00003C59
		internal void Play()
		{
			ISteamMusic._Play(this.Self);
		}

		// Token: 0x060003B5 RID: 949
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusic_Pause")]
		private static extern void _Pause(IntPtr self);

		// Token: 0x060003B6 RID: 950 RVA: 0x00005A66 File Offset: 0x00003C66
		internal void Pause()
		{
			ISteamMusic._Pause(this.Self);
		}

		// Token: 0x060003B7 RID: 951
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusic_PlayPrevious")]
		private static extern void _PlayPrevious(IntPtr self);

		// Token: 0x060003B8 RID: 952 RVA: 0x00005A73 File Offset: 0x00003C73
		internal void PlayPrevious()
		{
			ISteamMusic._PlayPrevious(this.Self);
		}

		// Token: 0x060003B9 RID: 953
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusic_PlayNext")]
		private static extern void _PlayNext(IntPtr self);

		// Token: 0x060003BA RID: 954 RVA: 0x00005A80 File Offset: 0x00003C80
		internal void PlayNext()
		{
			ISteamMusic._PlayNext(this.Self);
		}

		// Token: 0x060003BB RID: 955
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusic_SetVolume")]
		private static extern void _SetVolume(IntPtr self, float flVolume);

		// Token: 0x060003BC RID: 956 RVA: 0x00005A8D File Offset: 0x00003C8D
		internal void SetVolume(float flVolume)
		{
			ISteamMusic._SetVolume(this.Self, flVolume);
		}

		// Token: 0x060003BD RID: 957
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusic_GetVolume")]
		private static extern float _GetVolume(IntPtr self);

		// Token: 0x060003BE RID: 958 RVA: 0x00005A9B File Offset: 0x00003C9B
		internal float GetVolume()
		{
			return ISteamMusic._GetVolume(this.Self);
		}
	}
}
