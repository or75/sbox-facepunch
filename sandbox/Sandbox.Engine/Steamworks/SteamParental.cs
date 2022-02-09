using System;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Undocumented Parental Settings
	/// </summary>
	// Token: 0x020000A2 RID: 162
	internal class SteamParental : SteamSharedClass<SteamParental>
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060005E6 RID: 1510 RVA: 0x0000868C File Offset: 0x0000688C
		internal static ISteamParentalSettings Internal
		{
			get
			{
				return SteamSharedClass<SteamParental>.Interface as ISteamParentalSettings;
			}
		}

		// Token: 0x060005E7 RID: 1511 RVA: 0x00008698 File Offset: 0x00006898
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamParentalSettings(server));
			SteamParental.InstallEvents(server);
		}

		// Token: 0x060005E8 RID: 1512 RVA: 0x000086AD File Offset: 0x000068AD
		internal static void InstallEvents(bool server)
		{
			Dispatch.Install<SteamParentalSettingsChanged_t>(delegate(SteamParentalSettingsChanged_t x)
			{
				Action onSettingsChanged = SteamParental.OnSettingsChanged;
				if (onSettingsChanged == null)
				{
					return;
				}
				onSettingsChanged();
			}, server);
		}

		/// <summary>
		/// Parental Settings Changed
		/// </summary>
		// Token: 0x1400001D RID: 29
		// (add) Token: 0x060005E9 RID: 1513 RVA: 0x000086D4 File Offset: 0x000068D4
		// (remove) Token: 0x060005EA RID: 1514 RVA: 0x00008708 File Offset: 0x00006908
		internal static event Action OnSettingsChanged;

		/// <summary>
		///
		/// </summary>
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060005EB RID: 1515 RVA: 0x0000873B File Offset: 0x0000693B
		internal static bool IsParentalLockEnabled
		{
			get
			{
				return SteamParental.Internal.BIsParentalLockEnabled();
			}
		}

		/// <summary>
		///
		/// </summary>
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060005EC RID: 1516 RVA: 0x00008747 File Offset: 0x00006947
		internal static bool IsParentalLockLocked
		{
			get
			{
				return SteamParental.Internal.BIsParentalLockLocked();
			}
		}

		/// <summary>
		///
		/// </summary>
		// Token: 0x060005ED RID: 1517 RVA: 0x00008753 File Offset: 0x00006953
		internal static bool IsAppBlocked(AppId app)
		{
			return SteamParental.Internal.BIsAppBlocked(app.Value);
		}

		/// <summary>
		///
		/// </summary>
		// Token: 0x060005EE RID: 1518 RVA: 0x0000876A File Offset: 0x0000696A
		internal static bool BIsAppInBlockList(AppId app)
		{
			return SteamParental.Internal.BIsAppInBlockList(app.Value);
		}

		/// <summary>
		///
		/// </summary>
		// Token: 0x060005EF RID: 1519 RVA: 0x00008781 File Offset: 0x00006981
		internal static bool IsFeatureBlocked(ParentalFeature feature)
		{
			return SteamParental.Internal.BIsFeatureBlocked(feature);
		}

		/// <summary>
		///
		/// </summary>
		// Token: 0x060005F0 RID: 1520 RVA: 0x0000878E File Offset: 0x0000698E
		internal static bool BIsFeatureInBlockList(ParentalFeature feature)
		{
			return SteamParental.Internal.BIsFeatureInBlockList(feature);
		}
	}
}
