using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Exposes a wide range of information and actions for applications and Downloadable Content (DLC).
	/// </summary>
	// Token: 0x0200009B RID: 155
	internal class SteamApps : SteamSharedClass<SteamApps>
	{
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600052F RID: 1327 RVA: 0x000067C8 File Offset: 0x000049C8
		internal static ISteamApps Internal
		{
			get
			{
				return SteamSharedClass<SteamApps>.Interface as ISteamApps;
			}
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x000067D4 File Offset: 0x000049D4
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamApps(server));
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x000067E4 File Offset: 0x000049E4
		internal static void InstallEvents()
		{
			Dispatch.Install<DlcInstalled_t>(delegate(DlcInstalled_t x)
			{
				Action<AppId> onDlcInstalled = SteamApps.OnDlcInstalled;
				if (onDlcInstalled == null)
				{
					return;
				}
				onDlcInstalled(x.AppID);
			}, false);
			Dispatch.Install<NewUrlLaunchParameters_t>(delegate(NewUrlLaunchParameters_t x)
			{
				Action onNewLaunchParameters = SteamApps.OnNewLaunchParameters;
				if (onNewLaunchParameters == null)
				{
					return;
				}
				onNewLaunchParameters();
			}, false);
		}

		/// <summary>
		/// posted after the user gains ownership of DLC and that DLC is installed
		/// </summary>
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000532 RID: 1330 RVA: 0x0000683C File Offset: 0x00004A3C
		// (remove) Token: 0x06000533 RID: 1331 RVA: 0x00006870 File Offset: 0x00004A70
		internal static event Action<AppId> OnDlcInstalled;

		/// <summary>
		/// posted after the user gains executes a Steam URL with command line or query parameters
		/// such as steam://run/appid//-commandline/?param1=value1(and)param2=value2(and)param3=value3 etc
		/// while the game is already running.  The new params can be queried
		/// with GetLaunchQueryParam and GetLaunchCommandLine
		/// </summary>
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000534 RID: 1332 RVA: 0x000068A4 File Offset: 0x00004AA4
		// (remove) Token: 0x06000535 RID: 1333 RVA: 0x000068D8 File Offset: 0x00004AD8
		internal static event Action OnNewLaunchParameters;

		/// <summary>
		/// Checks if the active user is subscribed to the current App ID
		/// </summary>
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000536 RID: 1334 RVA: 0x0000690B File Offset: 0x00004B0B
		internal static bool IsSubscribed
		{
			get
			{
				return SteamApps.Internal.BIsSubscribed();
			}
		}

		/// <summary>
		/// Check if user borrowed this game via Family Sharing, If true, call GetAppOwner() to get the lender SteamID
		/// </summary>
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000537 RID: 1335 RVA: 0x00006917 File Offset: 0x00004B17
		internal static bool IsSubscribedFromFamilySharing
		{
			get
			{
				return SteamApps.Internal.BIsSubscribedFromFamilySharing();
			}
		}

		/// <summary>
		/// Checks if the license owned by the user provides low violence depots.
		/// Low violence depots are useful for copies sold in countries that have content restrictions
		/// </summary>
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000538 RID: 1336 RVA: 0x00006923 File Offset: 0x00004B23
		internal static bool IsLowViolence
		{
			get
			{
				return SteamApps.Internal.BIsLowViolence();
			}
		}

		/// <summary>
		/// Checks whether the current App ID license is for Cyber Cafes.
		/// </summary>
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000539 RID: 1337 RVA: 0x0000692F File Offset: 0x00004B2F
		internal static bool IsCybercafe
		{
			get
			{
				return SteamApps.Internal.BIsCybercafe();
			}
		}

		/// <summary>
		/// CChecks if the user has a VAC ban on their account
		/// </summary>
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x0600053A RID: 1338 RVA: 0x0000693B File Offset: 0x00004B3B
		internal static bool IsVACBanned
		{
			get
			{
				return SteamApps.Internal.BIsVACBanned();
			}
		}

		/// <summary>
		/// Gets the current language that the user has set.
		/// This falls back to the Steam UI language if the user hasn't explicitly picked a language for the title.
		/// </summary>
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600053B RID: 1339 RVA: 0x00006947 File Offset: 0x00004B47
		internal static string GameLanguage
		{
			get
			{
				return SteamApps.Internal.GetCurrentGameLanguage();
			}
		}

		/// <summary>
		/// Gets a list of the languages the current app supports.
		/// </summary>
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600053C RID: 1340 RVA: 0x00006953 File Offset: 0x00004B53
		internal static string[] AvailableLanguages
		{
			get
			{
				return SteamApps.Internal.GetAvailableGameLanguages().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
			}
		}

		/// <summary>
		/// Checks if the active user is subscribed to a specified AppId.
		/// Only use this if you need to check ownership of another game related to yours, a demo for example.
		/// </summary>
		// Token: 0x0600053D RID: 1341 RVA: 0x00006970 File Offset: 0x00004B70
		internal static bool IsSubscribedToApp(AppId appid)
		{
			return SteamApps.Internal.BIsSubscribedApp(appid.Value);
		}

		/// <summary>
		/// Checks if the user owns a specific DLC and if the DLC is installed
		/// </summary>
		// Token: 0x0600053E RID: 1342 RVA: 0x00006987 File Offset: 0x00004B87
		internal static bool IsDlcInstalled(AppId appid)
		{
			return SteamApps.Internal.BIsDlcInstalled(appid.Value);
		}

		/// <summary>
		/// Returns the time of the purchase of the app
		/// </summary>
		// Token: 0x0600053F RID: 1343 RVA: 0x0000699E File Offset: 0x00004B9E
		internal static DateTime PurchaseTime(AppId appid = default(AppId))
		{
			if (appid == 0U)
			{
				appid = SteamClient.AppId;
			}
			return Epoch.ToDateTime(SteamApps.Internal.GetEarliestPurchaseUnixTime(appid.Value));
		}

		/// <summary>
		/// Checks if the user is subscribed to the current app through a free weekend
		/// This function will return false for users who have a retail or other type of license
		/// Before using, please ask your Valve technical contact how to package and secure your free weekened
		/// </summary>
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000540 RID: 1344 RVA: 0x000069CE File Offset: 0x00004BCE
		internal static bool IsSubscribedFromFreeWeekend
		{
			get
			{
				return SteamApps.Internal.BIsSubscribedFromFreeWeekend();
			}
		}

		/// <summary>
		/// Returns metadata for all available DLC
		/// </summary>
		// Token: 0x06000541 RID: 1345 RVA: 0x000069DA File Offset: 0x00004BDA
		internal static IEnumerable<DlcInformation> DlcInformation()
		{
			AppId appid = default(AppId);
			bool available = false;
			int num;
			for (int i = 0; i < SteamApps.Internal.GetDLCCount(); i = num + 1)
			{
				string strVal;
				if (SteamApps.Internal.BGetDLCDataByIndex(i, ref appid, ref available, out strVal))
				{
					yield return new DlcInformation
					{
						AppId = appid.Value,
						Name = strVal,
						Available = available
					};
				}
				num = i;
			}
			yield break;
		}

		/// <summary>
		/// Install/Uninstall control for optional DLC
		/// </summary>
		// Token: 0x06000542 RID: 1346 RVA: 0x000069E3 File Offset: 0x00004BE3
		internal static void InstallDlc(AppId appid)
		{
			SteamApps.Internal.InstallDLC(appid.Value);
		}

		/// <summary>
		/// Install/Uninstall control for optional DLC
		/// </summary>
		// Token: 0x06000543 RID: 1347 RVA: 0x000069FA File Offset: 0x00004BFA
		internal static void UninstallDlc(AppId appid)
		{
			SteamApps.Internal.UninstallDLC(appid.Value);
		}

		/// <summary>
		/// Returns null if we're not on a beta branch, else the name of the branch
		/// </summary>
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x00006A14 File Offset: 0x00004C14
		internal static string CurrentBetaName
		{
			get
			{
				string strVal;
				if (!SteamApps.Internal.GetCurrentBetaName(out strVal))
				{
					return null;
				}
				return strVal;
			}
		}

		/// <summary>
		/// Allows you to force verify game content on next launch.
		///
		/// If you detect the game is out-of-date(for example, by having the client detect a version mismatch with a server),
		/// you can call use MarkContentCorrupt to force a verify, show a message to the user, and then quit.
		/// </summary>
		// Token: 0x06000545 RID: 1349 RVA: 0x00006A32 File Offset: 0x00004C32
		internal static void MarkContentCorrupt(bool missingFilesOnly)
		{
			SteamApps.Internal.MarkContentCorrupt(missingFilesOnly);
		}

		/// <summary>
		/// Gets a list of all installed depots for a given App ID in mount order
		/// </summary>
		// Token: 0x06000546 RID: 1350 RVA: 0x00006A40 File Offset: 0x00004C40
		internal static IEnumerable<DepotId> InstalledDepots(AppId appid = default(AppId))
		{
			if (appid == 0U)
			{
				appid = SteamClient.AppId;
			}
			DepotId_t[] depots = new DepotId_t[32];
			uint count = SteamApps.Internal.GetInstalledDepots(appid.Value, depots, (uint)depots.Length);
			int i = 0;
			while ((long)i < (long)((ulong)count))
			{
				yield return new DepotId
				{
					Value = depots[i].Value
				};
				int num = i;
				i = num + 1;
			}
			yield break;
		}

		/// <summary>
		/// Gets the install folder for a specific AppID.
		/// This works even if the application is not installed, based on where the game would be installed with the default Steam library location.
		/// </summary>
		// Token: 0x06000547 RID: 1351 RVA: 0x00006A50 File Offset: 0x00004C50
		internal static string AppInstallDir(AppId appid = default(AppId))
		{
			if (appid == 0U)
			{
				appid = SteamClient.AppId;
			}
			string strVal;
			if (SteamApps.Internal.GetAppInstallDir(appid.Value, out strVal) == 0U)
			{
				return null;
			}
			return strVal;
		}

		/// <summary>
		/// The app may not actually be owned by the current user, they may have it left over from a free weekend, etc.
		/// </summary>
		// Token: 0x06000548 RID: 1352 RVA: 0x00006A88 File Offset: 0x00004C88
		internal static bool IsAppInstalled(AppId appid)
		{
			return SteamApps.Internal.BIsAppInstalled(appid.Value);
		}

		/// <summary>
		/// Gets the Steam ID of the original owner of the current app. If it's different from the current user then it is borrowed..
		/// </summary>
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000549 RID: 1353 RVA: 0x00006A9F File Offset: 0x00004C9F
		internal static SteamId AppOwner
		{
			get
			{
				return SteamApps.Internal.GetAppOwner().Value;
			}
		}

		/// <summary>
		/// Gets the associated launch parameter if the game is run via steam://run/appid/?param1=value1;param2=value2;param3=value3 etc.
		/// Parameter names starting with the character '@' are reserved for internal use and will always return an empty string.
		/// Parameter names starting with an underscore '_' are reserved for steam features -- they can be queried by the game, 
		/// but it is advised that you not param names beginning with an underscore for your own features.
		/// </summary>
		// Token: 0x0600054A RID: 1354 RVA: 0x00006AB5 File Offset: 0x00004CB5
		internal static string GetLaunchParam(string param)
		{
			return SteamApps.Internal.GetLaunchQueryParam(param);
		}

		/// <summary>
		/// Gets the download progress for optional DLC.
		/// </summary>
		// Token: 0x0600054B RID: 1355 RVA: 0x00006AC4 File Offset: 0x00004CC4
		internal static DownloadProgress DlcDownloadProgress(AppId appid)
		{
			ulong punBytesDownloaded = 0UL;
			ulong punBytesTotal = 0UL;
			if (!SteamApps.Internal.GetDlcDownloadProgress(appid.Value, ref punBytesDownloaded, ref punBytesTotal))
			{
				return default(DownloadProgress);
			}
			return new DownloadProgress
			{
				BytesDownloaded = punBytesDownloaded,
				BytesTotal = punBytesTotal,
				Active = true
			};
		}

		/// <summary>
		/// Gets the buildid of this app, may change at any time based on backend updates to the game.
		/// Defaults to 0 if you're not running a build downloaded from steam.
		/// </summary>
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600054C RID: 1356 RVA: 0x00006B1D File Offset: 0x00004D1D
		internal static int BuildId
		{
			get
			{
				return SteamApps.Internal.GetAppBuildId();
			}
		}

		/// <summary>
		/// Asynchronously retrieves metadata details about a specific file in the depot manifest.
		/// Currently provides:
		/// </summary>
		// Token: 0x0600054D RID: 1357 RVA: 0x00006B2C File Offset: 0x00004D2C
		internal static async Task<FileDetails?> GetFileDetailsAsync(string filename)
		{
			FileDetailsResult_t? r = await SteamApps.Internal.GetFileDetails(filename);
			FileDetails? result;
			if (r == null || r.Value.Result != Result.OK)
			{
				result = null;
			}
			else
			{
				FileDetails value = default(FileDetails);
				value.SizeInBytes = r.Value.FileSize;
				value.Flags = r.Value.Flags;
				value.Sha1 = string.Join("", r.Value.FileSHA.Select((byte x) => x.ToString("x")));
				result = new FileDetails?(value);
			}
			return result;
		}

		/// <summary>
		/// Get command line if game was launched via Steam URL, e.g. steam://run/appid//command line/.
		/// This method of passing a connect string (used when joining via rich presence, accepting an
		/// invite, etc) is preferable to passing the connect string on the operating system command
		/// line, which is a security risk.  In order for rich presence joins to go through this
		/// path and not be placed on the OS command line, you must set a value in your app's
		/// configuration on Steam.  Ask Valve for help with this.
		/// </summary>
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600054E RID: 1358 RVA: 0x00006B70 File Offset: 0x00004D70
		internal static string CommandLine
		{
			get
			{
				string strVal;
				SteamApps.Internal.GetLaunchCommandLine(out strVal);
				return strVal;
			}
		}

		/// <summary>
		///  check if game is a timed trial with limited playtime
		/// </summary>
		// Token: 0x0600054F RID: 1359 RVA: 0x00006B8C File Offset: 0x00004D8C
		internal static bool IsTimedTrial(out int secondsAllowed, out int secondsPlayed)
		{
			uint a = 0U;
			uint b = 0U;
			secondsAllowed = 0;
			secondsPlayed = 0;
			if (!SteamApps.Internal.BIsTimedTrial(ref a, ref b))
			{
				return false;
			}
			secondsAllowed = (int)a;
			secondsPlayed = (int)b;
			return true;
		}
	}
}
