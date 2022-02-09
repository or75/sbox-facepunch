using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x02000032 RID: 50
	internal class ISteamMusicRemote : SteamInterface
	{
		// Token: 0x060003BF RID: 959 RVA: 0x00005AA8 File Offset: 0x00003CA8
		internal ISteamMusicRemote(bool IsGameServer)
		{
			base.SetupInterface(IsGameServer);
		}

		// Token: 0x060003C0 RID: 960
		[DllImport("steam_api64", CallingConvention = 2)]
		internal static extern IntPtr SteamAPI_SteamMusicRemote_v001();

		// Token: 0x060003C1 RID: 961 RVA: 0x00005AB7 File Offset: 0x00003CB7
		internal override IntPtr GetUserInterfacePointer()
		{
			return ISteamMusicRemote.SteamAPI_SteamMusicRemote_v001();
		}

		// Token: 0x060003C2 RID: 962
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_RegisterSteamMusicRemote")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _RegisterSteamMusicRemote(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName);

		// Token: 0x060003C3 RID: 963 RVA: 0x00005ABE File Offset: 0x00003CBE
		internal bool RegisterSteamMusicRemote([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchName)
		{
			return ISteamMusicRemote._RegisterSteamMusicRemote(this.Self, pchName);
		}

		// Token: 0x060003C4 RID: 964
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_DeregisterSteamMusicRemote")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _DeregisterSteamMusicRemote(IntPtr self);

		// Token: 0x060003C5 RID: 965 RVA: 0x00005ACC File Offset: 0x00003CCC
		internal bool DeregisterSteamMusicRemote()
		{
			return ISteamMusicRemote._DeregisterSteamMusicRemote(this.Self);
		}

		// Token: 0x060003C6 RID: 966
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_BIsCurrentMusicRemote")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BIsCurrentMusicRemote(IntPtr self);

		// Token: 0x060003C7 RID: 967 RVA: 0x00005AD9 File Offset: 0x00003CD9
		internal bool BIsCurrentMusicRemote()
		{
			return ISteamMusicRemote._BIsCurrentMusicRemote(this.Self);
		}

		// Token: 0x060003C8 RID: 968
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_BActivationSuccess")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _BActivationSuccess(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bValue);

		// Token: 0x060003C9 RID: 969 RVA: 0x00005AE6 File Offset: 0x00003CE6
		internal bool BActivationSuccess([MarshalAs(UnmanagedType.U1)] bool bValue)
		{
			return ISteamMusicRemote._BActivationSuccess(this.Self, bValue);
		}

		// Token: 0x060003CA RID: 970
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_SetDisplayName")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetDisplayName(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchDisplayName);

		// Token: 0x060003CB RID: 971 RVA: 0x00005AF4 File Offset: 0x00003CF4
		internal bool SetDisplayName([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchDisplayName)
		{
			return ISteamMusicRemote._SetDisplayName(this.Self, pchDisplayName);
		}

		// Token: 0x060003CC RID: 972
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_SetPNGIcon_64x64")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetPNGIcon_64x64(IntPtr self, IntPtr pvBuffer, uint cbBufferLength);

		// Token: 0x060003CD RID: 973 RVA: 0x00005B02 File Offset: 0x00003D02
		internal bool SetPNGIcon_64x64(IntPtr pvBuffer, uint cbBufferLength)
		{
			return ISteamMusicRemote._SetPNGIcon_64x64(this.Self, pvBuffer, cbBufferLength);
		}

		// Token: 0x060003CE RID: 974
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlayPrevious")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _EnablePlayPrevious(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bValue);

		// Token: 0x060003CF RID: 975 RVA: 0x00005B11 File Offset: 0x00003D11
		internal bool EnablePlayPrevious([MarshalAs(UnmanagedType.U1)] bool bValue)
		{
			return ISteamMusicRemote._EnablePlayPrevious(this.Self, bValue);
		}

		// Token: 0x060003D0 RID: 976
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlayNext")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _EnablePlayNext(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bValue);

		// Token: 0x060003D1 RID: 977 RVA: 0x00005B1F File Offset: 0x00003D1F
		internal bool EnablePlayNext([MarshalAs(UnmanagedType.U1)] bool bValue)
		{
			return ISteamMusicRemote._EnablePlayNext(this.Self, bValue);
		}

		// Token: 0x060003D2 RID: 978
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableShuffled")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _EnableShuffled(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bValue);

		// Token: 0x060003D3 RID: 979 RVA: 0x00005B2D File Offset: 0x00003D2D
		internal bool EnableShuffled([MarshalAs(UnmanagedType.U1)] bool bValue)
		{
			return ISteamMusicRemote._EnableShuffled(this.Self, bValue);
		}

		// Token: 0x060003D4 RID: 980
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableLooped")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _EnableLooped(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bValue);

		// Token: 0x060003D5 RID: 981 RVA: 0x00005B3B File Offset: 0x00003D3B
		internal bool EnableLooped([MarshalAs(UnmanagedType.U1)] bool bValue)
		{
			return ISteamMusicRemote._EnableLooped(this.Self, bValue);
		}

		// Token: 0x060003D6 RID: 982
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_EnableQueue")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _EnableQueue(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bValue);

		// Token: 0x060003D7 RID: 983 RVA: 0x00005B49 File Offset: 0x00003D49
		internal bool EnableQueue([MarshalAs(UnmanagedType.U1)] bool bValue)
		{
			return ISteamMusicRemote._EnableQueue(this.Self, bValue);
		}

		// Token: 0x060003D8 RID: 984
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_EnablePlaylists")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _EnablePlaylists(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bValue);

		// Token: 0x060003D9 RID: 985 RVA: 0x00005B57 File Offset: 0x00003D57
		internal bool EnablePlaylists([MarshalAs(UnmanagedType.U1)] bool bValue)
		{
			return ISteamMusicRemote._EnablePlaylists(this.Self, bValue);
		}

		// Token: 0x060003DA RID: 986
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdatePlaybackStatus")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _UpdatePlaybackStatus(IntPtr self, MusicStatus nStatus);

		// Token: 0x060003DB RID: 987 RVA: 0x00005B65 File Offset: 0x00003D65
		internal bool UpdatePlaybackStatus(MusicStatus nStatus)
		{
			return ISteamMusicRemote._UpdatePlaybackStatus(this.Self, nStatus);
		}

		// Token: 0x060003DC RID: 988
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateShuffled")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _UpdateShuffled(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bValue);

		// Token: 0x060003DD RID: 989 RVA: 0x00005B73 File Offset: 0x00003D73
		internal bool UpdateShuffled([MarshalAs(UnmanagedType.U1)] bool bValue)
		{
			return ISteamMusicRemote._UpdateShuffled(this.Self, bValue);
		}

		// Token: 0x060003DE RID: 990
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateLooped")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _UpdateLooped(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bValue);

		// Token: 0x060003DF RID: 991 RVA: 0x00005B81 File Offset: 0x00003D81
		internal bool UpdateLooped([MarshalAs(UnmanagedType.U1)] bool bValue)
		{
			return ISteamMusicRemote._UpdateLooped(this.Self, bValue);
		}

		// Token: 0x060003E0 RID: 992
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateVolume")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _UpdateVolume(IntPtr self, float flValue);

		// Token: 0x060003E1 RID: 993 RVA: 0x00005B8F File Offset: 0x00003D8F
		internal bool UpdateVolume(float flValue)
		{
			return ISteamMusicRemote._UpdateVolume(this.Self, flValue);
		}

		// Token: 0x060003E2 RID: 994
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryWillChange")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _CurrentEntryWillChange(IntPtr self);

		// Token: 0x060003E3 RID: 995 RVA: 0x00005B9D File Offset: 0x00003D9D
		internal bool CurrentEntryWillChange()
		{
			return ISteamMusicRemote._CurrentEntryWillChange(this.Self);
		}

		// Token: 0x060003E4 RID: 996
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryIsAvailable")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _CurrentEntryIsAvailable(IntPtr self, [MarshalAs(UnmanagedType.U1)] bool bAvailable);

		// Token: 0x060003E5 RID: 997 RVA: 0x00005BAA File Offset: 0x00003DAA
		internal bool CurrentEntryIsAvailable([MarshalAs(UnmanagedType.U1)] bool bAvailable)
		{
			return ISteamMusicRemote._CurrentEntryIsAvailable(this.Self, bAvailable);
		}

		// Token: 0x060003E6 RID: 998
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryText")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _UpdateCurrentEntryText(IntPtr self, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchText);

		// Token: 0x060003E7 RID: 999 RVA: 0x00005BB8 File Offset: 0x00003DB8
		internal bool UpdateCurrentEntryText([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchText)
		{
			return ISteamMusicRemote._UpdateCurrentEntryText(this.Self, pchText);
		}

		// Token: 0x060003E8 RID: 1000
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryElapsedSeconds")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _UpdateCurrentEntryElapsedSeconds(IntPtr self, int nValue);

		// Token: 0x060003E9 RID: 1001 RVA: 0x00005BC6 File Offset: 0x00003DC6
		internal bool UpdateCurrentEntryElapsedSeconds(int nValue)
		{
			return ISteamMusicRemote._UpdateCurrentEntryElapsedSeconds(this.Self, nValue);
		}

		// Token: 0x060003EA RID: 1002
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_UpdateCurrentEntryCoverArt")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _UpdateCurrentEntryCoverArt(IntPtr self, IntPtr pvBuffer, uint cbBufferLength);

		// Token: 0x060003EB RID: 1003 RVA: 0x00005BD4 File Offset: 0x00003DD4
		internal bool UpdateCurrentEntryCoverArt(IntPtr pvBuffer, uint cbBufferLength)
		{
			return ISteamMusicRemote._UpdateCurrentEntryCoverArt(this.Self, pvBuffer, cbBufferLength);
		}

		// Token: 0x060003EC RID: 1004
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_CurrentEntryDidChange")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _CurrentEntryDidChange(IntPtr self);

		// Token: 0x060003ED RID: 1005 RVA: 0x00005BE3 File Offset: 0x00003DE3
		internal bool CurrentEntryDidChange()
		{
			return ISteamMusicRemote._CurrentEntryDidChange(this.Self);
		}

		// Token: 0x060003EE RID: 1006
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_QueueWillChange")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _QueueWillChange(IntPtr self);

		// Token: 0x060003EF RID: 1007 RVA: 0x00005BF0 File Offset: 0x00003DF0
		internal bool QueueWillChange()
		{
			return ISteamMusicRemote._QueueWillChange(this.Self);
		}

		// Token: 0x060003F0 RID: 1008
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_ResetQueueEntries")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ResetQueueEntries(IntPtr self);

		// Token: 0x060003F1 RID: 1009 RVA: 0x00005BFD File Offset: 0x00003DFD
		internal bool ResetQueueEntries()
		{
			return ISteamMusicRemote._ResetQueueEntries(this.Self);
		}

		// Token: 0x060003F2 RID: 1010
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_SetQueueEntry")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetQueueEntry(IntPtr self, int nID, int nPosition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchEntryText);

		// Token: 0x060003F3 RID: 1011 RVA: 0x00005C0A File Offset: 0x00003E0A
		internal bool SetQueueEntry(int nID, int nPosition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchEntryText)
		{
			return ISteamMusicRemote._SetQueueEntry(this.Self, nID, nPosition, pchEntryText);
		}

		// Token: 0x060003F4 RID: 1012
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_SetCurrentQueueEntry")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetCurrentQueueEntry(IntPtr self, int nID);

		// Token: 0x060003F5 RID: 1013 RVA: 0x00005C1A File Offset: 0x00003E1A
		internal bool SetCurrentQueueEntry(int nID)
		{
			return ISteamMusicRemote._SetCurrentQueueEntry(this.Self, nID);
		}

		// Token: 0x060003F6 RID: 1014
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_QueueDidChange")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _QueueDidChange(IntPtr self);

		// Token: 0x060003F7 RID: 1015 RVA: 0x00005C28 File Offset: 0x00003E28
		internal bool QueueDidChange()
		{
			return ISteamMusicRemote._QueueDidChange(this.Self);
		}

		// Token: 0x060003F8 RID: 1016
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_PlaylistWillChange")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _PlaylistWillChange(IntPtr self);

		// Token: 0x060003F9 RID: 1017 RVA: 0x00005C35 File Offset: 0x00003E35
		internal bool PlaylistWillChange()
		{
			return ISteamMusicRemote._PlaylistWillChange(this.Self);
		}

		// Token: 0x060003FA RID: 1018
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_ResetPlaylistEntries")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _ResetPlaylistEntries(IntPtr self);

		// Token: 0x060003FB RID: 1019 RVA: 0x00005C42 File Offset: 0x00003E42
		internal bool ResetPlaylistEntries()
		{
			return ISteamMusicRemote._ResetPlaylistEntries(this.Self);
		}

		// Token: 0x060003FC RID: 1020
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_SetPlaylistEntry")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetPlaylistEntry(IntPtr self, int nID, int nPosition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchEntryText);

		// Token: 0x060003FD RID: 1021 RVA: 0x00005C4F File Offset: 0x00003E4F
		internal bool SetPlaylistEntry(int nID, int nPosition, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = Steamworks.Utf8StringToNative)] string pchEntryText)
		{
			return ISteamMusicRemote._SetPlaylistEntry(this.Self, nID, nPosition, pchEntryText);
		}

		// Token: 0x060003FE RID: 1022
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_SetCurrentPlaylistEntry")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _SetCurrentPlaylistEntry(IntPtr self, int nID);

		// Token: 0x060003FF RID: 1023 RVA: 0x00005C5F File Offset: 0x00003E5F
		internal bool SetCurrentPlaylistEntry(int nID)
		{
			return ISteamMusicRemote._SetCurrentPlaylistEntry(this.Self, nID);
		}

		// Token: 0x06000400 RID: 1024
		[DllImport("steam_api64", CallingConvention = 2, EntryPoint = "SteamAPI_ISteamMusicRemote_PlaylistDidChange")]
		[return: MarshalAs(UnmanagedType.I1)]
		private static extern bool _PlaylistDidChange(IntPtr self);

		// Token: 0x06000401 RID: 1025 RVA: 0x00005C6D File Offset: 0x00003E6D
		internal bool PlaylistDidChange()
		{
			return ISteamMusicRemote._PlaylistDidChange(this.Self);
		}
	}
}
