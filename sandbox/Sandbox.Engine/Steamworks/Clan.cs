using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	// Token: 0x020000A9 RID: 169
	internal struct Clan
	{
		// Token: 0x0600068C RID: 1676 RVA: 0x0000A1FA File Offset: 0x000083FA
		internal Clan(SteamId id)
		{
			this.Id = id;
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x0600068D RID: 1677 RVA: 0x0000A203 File Offset: 0x00008403
		internal string Name
		{
			get
			{
				return SteamFriends.Internal.GetClanName(this.Id);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x0600068E RID: 1678 RVA: 0x0000A215 File Offset: 0x00008415
		internal string Tag
		{
			get
			{
				return SteamFriends.Internal.GetClanTag(this.Id);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x0600068F RID: 1679 RVA: 0x0000A227 File Offset: 0x00008427
		internal int ChatMemberCount
		{
			get
			{
				return SteamFriends.Internal.GetClanChatMemberCount(this.Id);
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x06000690 RID: 1680 RVA: 0x0000A239 File Offset: 0x00008439
		internal Friend Owner
		{
			get
			{
				return new Friend(SteamFriends.Internal.GetClanOwner(this.Id));
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x06000691 RID: 1681 RVA: 0x0000A250 File Offset: 0x00008450
		internal bool Public
		{
			get
			{
				return SteamFriends.Internal.IsClanPublic(this.Id);
			}
		}

		/// <summary>
		/// Is the clan an official game group?
		/// </summary>
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000692 RID: 1682 RVA: 0x0000A262 File Offset: 0x00008462
		internal bool Official
		{
			get
			{
				return SteamFriends.Internal.IsClanOfficialGameGroup(this.Id);
			}
		}

		/// <summary>
		/// Asynchronously fetches the officer list for a given clan
		/// </summary>
		/// <returns>Whether the request was successful or not</returns>
		// Token: 0x06000693 RID: 1683 RVA: 0x0000A274 File Offset: 0x00008474
		internal async Task<bool> RequestOfficerList()
		{
			ClanOfficerListResponse_t? req = await SteamFriends.Internal.RequestClanOfficerList(this.Id);
			return req != null && req.Value.Success > 0;
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0000A2BC File Offset: 0x000084BC
		internal IEnumerable<Friend> GetOfficers()
		{
			int num;
			for (int i = 0; i < SteamFriends.Internal.GetClanOfficerCount(this.Id); i = num + 1)
			{
				yield return new Friend(SteamFriends.Internal.GetClanOfficerByIndex(this.Id, i));
				num = i;
			}
			yield break;
		}

		// Token: 0x04000930 RID: 2352
		internal SteamId Id;
	}
}
