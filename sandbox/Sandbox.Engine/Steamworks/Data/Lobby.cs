using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Steamworks.Data
{
	// Token: 0x020001E6 RID: 486
	internal struct Lobby
	{
		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000BDD RID: 3037 RVA: 0x00010BBD File Offset: 0x0000EDBD
		// (set) Token: 0x06000BDE RID: 3038 RVA: 0x00010BC5 File Offset: 0x0000EDC5
		public SteamId Id { readonly get; internal set; }

		// Token: 0x06000BDF RID: 3039 RVA: 0x00010BCE File Offset: 0x0000EDCE
		public Lobby(SteamId id)
		{
			this.Id = id;
		}

		/// <summary>
		/// Try to join this room. Will return RoomEnter.Success on success,
		/// and anything else is a failure
		/// </summary>
		// Token: 0x06000BE0 RID: 3040 RVA: 0x00010BD8 File Offset: 0x0000EDD8
		internal async Task<RoomEnter> Join()
		{
			LobbyEnter_t? result = await SteamMatchmaking.Internal.JoinLobby(this.Id);
			RoomEnter result2;
			if (result == null)
			{
				result2 = RoomEnter.Error;
			}
			else
			{
				result2 = (RoomEnter)result.Value.EChatRoomEnterResponse;
			}
			return result2;
		}

		/// <summary>
		/// Leave a lobby; this will take effect immediately on the client side
		/// other users in the lobby will be notified by a LobbyChatUpdate_t callback
		/// </summary>
		// Token: 0x06000BE1 RID: 3041 RVA: 0x00010C20 File Offset: 0x0000EE20
		public void Leave()
		{
			SteamMatchmaking.Internal.LeaveLobby(this.Id);
		}

		/// <summary>
		/// Invite another user to the lobby
		/// will return true if the invite is successfully sent, whether or not the target responds
		/// returns false if the local user is not connected to the Steam servers
		/// </summary>
		// Token: 0x06000BE2 RID: 3042 RVA: 0x00010C32 File Offset: 0x0000EE32
		public bool InviteFriend(SteamId steamid)
		{
			return SteamMatchmaking.Internal.InviteUserToLobby(this.Id, steamid);
		}

		/// <summary>
		/// returns the number of users in the specified lobby
		/// </summary>
		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000BE3 RID: 3043 RVA: 0x00010C45 File Offset: 0x0000EE45
		public int MemberCount
		{
			get
			{
				return SteamMatchmaking.Internal.GetNumLobbyMembers(this.Id);
			}
		}

		/// <summary>
		/// Returns current members. Need to be in the lobby to see the users.
		/// </summary>
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000BE4 RID: 3044 RVA: 0x00010C57 File Offset: 0x0000EE57
		public IEnumerable<Friend> Members
		{
			get
			{
				int num;
				for (int i = 0; i < this.MemberCount; i = num + 1)
				{
					yield return new Friend(SteamMatchmaking.Internal.GetLobbyMemberByIndex(this.Id, i));
					num = i;
				}
				yield break;
			}
		}

		/// <summary>
		/// Get data associated with this lobby
		/// </summary>
		// Token: 0x06000BE5 RID: 3045 RVA: 0x00010C6C File Offset: 0x0000EE6C
		public string GetData(string key)
		{
			return SteamMatchmaking.Internal.GetLobbyData(this.Id, key);
		}

		/// <summary>
		/// Get data associated with this lobby
		/// </summary>
		// Token: 0x06000BE6 RID: 3046 RVA: 0x00010C80 File Offset: 0x0000EE80
		public bool SetData(string key, string value)
		{
			if (key.Length > 255)
			{
				throw new ArgumentException("Key should be < 255 chars", "key");
			}
			if (value != null && value.Length > 8192)
			{
				throw new ArgumentException("Value should be < 8192 chars", "key");
			}
			return SteamMatchmaking.Internal.SetLobbyData(this.Id, key, value);
		}

		/// <summary>
		/// Removes a metadata key from the lobby
		/// </summary>
		// Token: 0x06000BE7 RID: 3047 RVA: 0x00010CDC File Offset: 0x0000EEDC
		public bool DeleteData(string key)
		{
			return SteamMatchmaking.Internal.DeleteLobbyData(this.Id, key);
		}

		/// <summary>
		/// Get all data for this lobby
		/// </summary>
		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000BE8 RID: 3048 RVA: 0x00010CEF File Offset: 0x0000EEEF
		public IEnumerable<KeyValuePair<string, string>> Data
		{
			get
			{
				int cnt = SteamMatchmaking.Internal.GetLobbyDataCount(this.Id);
				int num;
				for (int i = 0; i < cnt; i = num + 1)
				{
					string a;
					string b;
					if (SteamMatchmaking.Internal.GetLobbyDataByIndex(this.Id, i, out a, out b))
					{
						yield return new KeyValuePair<string, string>(a, b);
					}
					num = i;
				}
				yield break;
			}
		}

		/// <summary>
		/// Gets per-user metadata for someone in this lobby
		/// </summary>
		// Token: 0x06000BE9 RID: 3049 RVA: 0x00010D04 File Offset: 0x0000EF04
		public string GetMemberData(Friend member, string key)
		{
			return SteamMatchmaking.Internal.GetLobbyMemberData(this.Id, member.Id, key);
		}

		/// <summary>
		/// Sets per-user metadata (for the local user implicitly)
		/// </summary>
		// Token: 0x06000BEA RID: 3050 RVA: 0x00010D1D File Offset: 0x0000EF1D
		public void SetMemberData(string key, string value)
		{
			SteamMatchmaking.Internal.SetLobbyMemberData(this.Id, key, value);
		}

		/// <summary>
		/// Sends a string to the chat room
		/// </summary>
		// Token: 0x06000BEB RID: 3051 RVA: 0x00010D34 File Offset: 0x0000EF34
		public bool SendChatString(string message)
		{
			byte[] data = Encoding.UTF8.GetBytes(message + "\0");
			return this.SendChatBytes(data);
		}

		/// <summary>
		/// Sends bytes the the chat room
		/// this isn't exposed because there's no way to read raw bytes atm, 
		/// and I figure people can send json if they want something more advanced
		/// </summary>
		// Token: 0x06000BEC RID: 3052 RVA: 0x00010D60 File Offset: 0x0000EF60
		internal unsafe bool SendChatBytes(byte[] data)
		{
			byte* ptr;
			if (data == null || data.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &data[0];
			}
			return SteamMatchmaking.Internal.SendLobbyChatMsg(this.Id, (IntPtr)((void*)ptr), data.Length);
		}

		/// <summary>
		/// Refreshes metadata for a lobby you're not necessarily in right now
		/// you never do this for lobbies you're a member of, only if your
		/// this will send down all the metadata associated with a lobby
		/// this is an asynchronous call
		/// returns false if the local user is not connected to the Steam servers
		/// results will be returned by a LobbyDataUpdate_t callback
		/// if the specified lobby doesn't exist, LobbyDataUpdate_t::m_bSuccess will be set to false
		/// </summary>
		// Token: 0x06000BED RID: 3053 RVA: 0x00010D9E File Offset: 0x0000EF9E
		public bool Refresh()
		{
			return SteamMatchmaking.Internal.RequestLobbyData(this.Id);
		}

		/// <summary>
		/// Max members able to join this lobby. Cannot be over 250.
		/// Can only be set by the owner
		/// </summary>
		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000BEE RID: 3054 RVA: 0x00010DB0 File Offset: 0x0000EFB0
		// (set) Token: 0x06000BEF RID: 3055 RVA: 0x00010DC2 File Offset: 0x0000EFC2
		public int MaxMembers
		{
			get
			{
				return SteamMatchmaking.Internal.GetLobbyMemberLimit(this.Id);
			}
			set
			{
				SteamMatchmaking.Internal.SetLobbyMemberLimit(this.Id, value);
			}
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x00010DD6 File Offset: 0x0000EFD6
		public bool SetPublic()
		{
			return SteamMatchmaking.Internal.SetLobbyType(this.Id, LobbyType.Public);
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x00010DE9 File Offset: 0x0000EFE9
		public bool SetPrivate()
		{
			return SteamMatchmaking.Internal.SetLobbyType(this.Id, LobbyType.Private);
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x00010DFC File Offset: 0x0000EFFC
		public bool SetInvisible()
		{
			return SteamMatchmaking.Internal.SetLobbyType(this.Id, LobbyType.Invisible);
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x00010E0F File Offset: 0x0000F00F
		public bool SetFriendsOnly()
		{
			return SteamMatchmaking.Internal.SetLobbyType(this.Id, LobbyType.FriendsOnly);
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x00010E22 File Offset: 0x0000F022
		public bool SetJoinable(bool b)
		{
			return SteamMatchmaking.Internal.SetLobbyJoinable(this.Id, b);
		}

		/// <summary>
		/// [SteamID variant]
		/// Allows the owner to set the game server associated with the lobby. Triggers the 
		/// Steammatchmaking.OnLobbyGameCreated event.
		/// </summary>
		// Token: 0x06000BF5 RID: 3061 RVA: 0x00010E35 File Offset: 0x0000F035
		public void SetGameServer(SteamId steamServer)
		{
			SteamMatchmaking.Internal.SetLobbyGameServer(this.Id, 0U, 0, steamServer);
		}

		/// <summary>
		/// [IP/Port variant]
		/// Allows the owner to set the game server associated with the lobby. Triggers the 
		/// Steammatchmaking.OnLobbyGameCreated event.
		/// </summary>
		// Token: 0x06000BF6 RID: 3062 RVA: 0x00010E4C File Offset: 0x0000F04C
		public void SetGameServer(string ip, ushort port)
		{
			IPAddress add;
			if (!IPAddress.TryParse(ip, out add))
			{
				throw new ArgumentException("IP address for server is invalid");
			}
			SteamMatchmaking.Internal.SetLobbyGameServer(this.Id, add.IpToInt32(), port, default(SteamId));
		}

		/// <summary>
		/// Gets the details of the lobby's game server, if set. Returns true if the lobby is 
		/// valid and has a server set, otherwise returns false.
		/// </summary>
		// Token: 0x06000BF7 RID: 3063 RVA: 0x00010E8E File Offset: 0x0000F08E
		public bool GetGameServer(out uint ip, out ushort port, out SteamId serverId)
		{
			ip = 0U;
			port = 0;
			serverId = default(SteamId);
			return SteamMatchmaking.Internal.GetLobbyGameServer(this.Id, ref ip, ref port, ref serverId);
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000BF8 RID: 3064 RVA: 0x00010EB0 File Offset: 0x0000F0B0
		public SteamId GameServerSteamId
		{
			get
			{
				uint ip;
				ushort port;
				SteamId steamid;
				if (this.GetGameServer(out ip, out port, out steamid))
				{
					return steamid;
				}
				return default(SteamId);
			}
		}

		/// <summary>
		/// You must be the lobby owner to set the owner
		/// </summary>
		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x00010ED6 File Offset: 0x0000F0D6
		// (set) Token: 0x06000BFA RID: 3066 RVA: 0x00010EED File Offset: 0x0000F0ED
		public Friend Owner
		{
			get
			{
				return new Friend(SteamMatchmaking.Internal.GetLobbyOwner(this.Id));
			}
			set
			{
				SteamMatchmaking.Internal.SetLobbyOwner(this.Id, value.Id);
			}
		}

		/// <summary>
		/// Check if the specified SteamId owns the lobby
		/// </summary>
		// Token: 0x06000BFB RID: 3067 RVA: 0x00010F06 File Offset: 0x0000F106
		public bool IsOwnedBy(SteamId k)
		{
			return this.Owner.Id == k;
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x00010F20 File Offset: 0x0000F120
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 3);
			defaultInterpolatedStringHandler.AppendFormatted<SteamId>(this.Id);
			defaultInterpolatedStringHandler.AppendLiteral(" [");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.MemberCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.MaxMembers);
			defaultInterpolatedStringHandler.AppendLiteral("]");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
	}
}
