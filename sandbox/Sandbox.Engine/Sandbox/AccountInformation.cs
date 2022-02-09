using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sandbox.Engine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000286 RID: 646
	internal class AccountInformation
	{
		// Token: 0x170002F7 RID: 759
		// (get) Token: 0x06000FE9 RID: 4073 RVA: 0x0001CDDB File Offset: 0x0001AFDB
		// (set) Token: 0x06000FEA RID: 4074 RVA: 0x0001CDE2 File Offset: 0x0001AFE2
		public static AccountInformation Current { get; private set; }

		/// <summary>
		/// Our steamid, redundant but here for verification
		/// </summary>
		// Token: 0x170002F8 RID: 760
		// (get) Token: 0x06000FEB RID: 4075 RVA: 0x0001CDEA File Offset: 0x0001AFEA
		// (set) Token: 0x06000FEC RID: 4076 RVA: 0x0001CDF2 File Offset: 0x0001AFF2
		public long Id { get; set; }

		/// <summary>
		/// If we borrowed this game, this is the real owner id
		/// </summary>
		// Token: 0x170002F9 RID: 761
		// (get) Token: 0x06000FED RID: 4077 RVA: 0x0001CDFB File Offset: 0x0001AFFB
		// (set) Token: 0x06000FEE RID: 4078 RVA: 0x0001CE03 File Offset: 0x0001B003
		public string OwnerId { get; set; }

		/// <summary>
		/// Currently just indicates if we're VAC banned
		/// </summary>
		// Token: 0x170002FA RID: 762
		// (get) Token: 0x06000FEF RID: 4079 RVA: 0x0001CE0C File Offset: 0x0001B00C
		// (set) Token: 0x06000FF0 RID: 4080 RVA: 0x0001CE14 File Offset: 0x0001B014
		public bool Banned { get; set; }

		/// <summary>
		/// A list of services that we have linked
		/// </summary>
		// Token: 0x170002FB RID: 763
		// (get) Token: 0x06000FF1 RID: 4081 RVA: 0x0001CE1D File Offset: 0x0001B01D
		// (set) Token: 0x06000FF2 RID: 4082 RVA: 0x0001CE25 File Offset: 0x0001B025
		public StreamService[] Links { get; set; }

		/// <summary>
		/// A list of organizations of which we're a member
		/// </summary>
		// Token: 0x170002FC RID: 764
		// (get) Token: 0x06000FF3 RID: 4083 RVA: 0x0001CE2E File Offset: 0x0001B02E
		// (set) Token: 0x06000FF4 RID: 4084 RVA: 0x0001CE36 File Offset: 0x0001B036
		public List<Package.Organization> Memberships { get; set; }

		/// <summary>
		/// A list of our last played games
		/// </summary>
		// Token: 0x170002FD RID: 765
		// (get) Token: 0x06000FF5 RID: 4085 RVA: 0x0001CE3F File Offset: 0x0001B03F
		// (set) Token: 0x06000FF6 RID: 4086 RVA: 0x0001CE47 File Offset: 0x0001B047
		public List<Package.Usage> Played { get; set; }

		/// <summary>
		/// A list of our favourited games
		/// </summary>
		// Token: 0x170002FE RID: 766
		// (get) Token: 0x06000FF7 RID: 4087 RVA: 0x0001CE50 File Offset: 0x0001B050
		// (set) Token: 0x06000FF8 RID: 4088 RVA: 0x0001CE58 File Offset: 0x0001B058
		public List<Package> Favourites { get; set; }

		/// <summary>
		/// Update Current
		/// </summary>
		// Token: 0x06000FF9 RID: 4089 RVA: 0x0001CE64 File Offset: 0x0001B064
		public static async Task Update()
		{
			AccountInformation.Current = await Api.GetAccountInformation();
			if (AccountInformation.Current == null)
			{
				GlobalSystemNamespace.Log.Warning("There was a problem retrieving account information");
			}
			else
			{
				AccountInformation accountInformation = AccountInformation.Current;
				if (accountInformation.Favourites == null)
				{
					accountInformation.Favourites = new List<Package>();
				}
				accountInformation = AccountInformation.Current;
				if (accountInformation.Played == null)
				{
					accountInformation.Played = new List<Package.Usage>();
				}
				accountInformation = AccountInformation.Current;
				if (accountInformation.Memberships == null)
				{
					accountInformation.Memberships = new List<Package.Organization>();
				}
				foreach (Package package in AccountInformation.Current.Favourites)
				{
					Package.Cache(package, true);
				}
				foreach (Package.Usage usage in AccountInformation.Current.Played)
				{
					Package.Cache(usage.Package, true);
				}
				IMenuDll menuDll = IMenuDll.Current;
				if (menuDll != null)
				{
					menuDll.RunEvent("menu.home.rebuild");
				}
			}
		}

		/// <summary>
		/// Helper - return true if Current.Favourites contains us
		/// </summary>
		// Token: 0x06000FFA RID: 4090 RVA: 0x0001CEA0 File Offset: 0x0001B0A0
		internal static bool IsFavourite(string fullIdent)
		{
			return AccountInformation.Current != null && AccountInformation.Current.Favourites.Any((Package x) => x.FullIdent == fullIdent);
		}

		/// <summary>
		/// Returns true if a user is a member of this organization
		/// </summary>
		// Token: 0x06000FFB RID: 4091 RVA: 0x0001CEE0 File Offset: 0x0001B0E0
		internal static bool HasOrganization(string ident)
		{
			return AccountInformation.Current != null && AccountInformation.Current.Memberships.Any((Package.Organization x) => x.Ident == ident);
		}
	}
}
