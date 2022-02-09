using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.MenuEngine
{
	// Token: 0x02000011 RID: 17
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class Account
	{
		/// <summary>
		/// Return true if the user has linked their account to a streamer service like twitch
		/// </summary>
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000059 RID: 89 RVA: 0x00003676 File Offset: 0x00001876
		public static bool HasLinkedStreamerServices
		{
			get
			{
				Host.AssertMenu("HasLinkedStreamerServices");
				if (AccountInformation.Current == null)
				{
					return false;
				}
				StreamService[] links = AccountInformation.Current.Links;
				return links != null && links.Length != 0;
			}
		}

		/// <summary>
		/// A list of favourites packages
		/// </summary>
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600005A RID: 90 RVA: 0x000036A0 File Offset: 0x000018A0
		public static IEnumerable<Package> Favourites
		{
			get
			{
				Host.AssertMenu("Favourites");
				AccountInformation accountInformation = AccountInformation.Current;
				IEnumerable<Package> enumerable = ((accountInformation != null) ? accountInformation.Favourites : null);
				return enumerable ?? Enumerable.Empty<Package>();
			}
		}

		/// <summary>
		/// A list of favourites packages
		/// </summary>
		// Token: 0x0600005B RID: 91 RVA: 0x000036D4 File Offset: 0x000018D4
		public static async Task SetFavourite(Package package, bool state)
		{
			Host.AssertMenu("SetFavourite");
			if (AccountInformation.Current != null)
			{
				if (state)
				{
					AccountInformation accountInformation = AccountInformation.Current;
					if (accountInformation.Favourites == null)
					{
						accountInformation.Favourites = new List<Package>();
					}
					AccountInformation.Current.Favourites.RemoveAll((Package x) => x.FullIdent == package.FullIdent);
					AccountInformation.Current.Favourites.Add(package);
				}
				else
				{
					List<Package> favourites = AccountInformation.Current.Favourites;
					if (favourites != null)
					{
						favourites.RemoveAll((Package x) => x.FullIdent == package.FullIdent);
					}
				}
				await Api.SetFavourite(package.FullIdent, state);
			}
		}

		/// <summary>
		/// Get a player's rank for a specific game
		/// </summary>
		// Token: 0x0600005C RID: 92 RVA: 0x00003720 File Offset: 0x00001920
		public static async Task<PlayerGameRank> FetchPlayerRankAsync(long playerId, string gameIdent)
		{
			Host.AssertMenu("FetchPlayerRankAsync");
			return await Api.GetPlayerRank(playerId, gameIdent);
		}
	}
}
