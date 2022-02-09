using System;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Interface which provides access to a range of miscellaneous utility functions
	/// </summary>
	// Token: 0x020000A7 RID: 167
	internal class SteamUtils : SteamSharedClass<SteamUtils>
	{
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600065D RID: 1629 RVA: 0x00009C73 File Offset: 0x00007E73
		internal static ISteamUtils Internal
		{
			get
			{
				return SteamSharedClass<SteamUtils>.Interface as ISteamUtils;
			}
		}

		// Token: 0x0600065E RID: 1630 RVA: 0x00009C7F File Offset: 0x00007E7F
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamUtils(server));
			SteamUtils.InstallEvents(server);
		}

		// Token: 0x0600065F RID: 1631 RVA: 0x00009C94 File Offset: 0x00007E94
		internal static void InstallEvents(bool server)
		{
			Dispatch.Install<IPCountry_t>(delegate(IPCountry_t x)
			{
				Action onIpCountryChanged = SteamUtils.OnIpCountryChanged;
				if (onIpCountryChanged == null)
				{
					return;
				}
				onIpCountryChanged();
			}, server);
			Dispatch.Install<LowBatteryPower_t>(delegate(LowBatteryPower_t x)
			{
				Action<int> onLowBatteryPower = SteamUtils.OnLowBatteryPower;
				if (onLowBatteryPower == null)
				{
					return;
				}
				onLowBatteryPower((int)x.MinutesBatteryLeft);
			}, server);
			Dispatch.Install<SteamShutdown_t>(delegate(SteamShutdown_t x)
			{
				SteamUtils.SteamClosed();
			}, server);
			Dispatch.Install<GamepadTextInputDismissed_t>(delegate(GamepadTextInputDismissed_t x)
			{
				Action<bool> onGamepadTextInputDismissed = SteamUtils.OnGamepadTextInputDismissed;
				if (onGamepadTextInputDismissed == null)
				{
					return;
				}
				onGamepadTextInputDismissed(x.Submitted);
			}, server);
		}

		// Token: 0x06000660 RID: 1632 RVA: 0x00009D35 File Offset: 0x00007F35
		private static void SteamClosed()
		{
			SteamClient.Cleanup();
			Action onSteamShutdown = SteamUtils.OnSteamShutdown;
			if (onSteamShutdown == null)
			{
				return;
			}
			onSteamShutdown();
		}

		/// <summary>
		/// The country of the user changed
		/// </summary>
		// Token: 0x14000032 RID: 50
		// (add) Token: 0x06000661 RID: 1633 RVA: 0x00009D4C File Offset: 0x00007F4C
		// (remove) Token: 0x06000662 RID: 1634 RVA: 0x00009D80 File Offset: 0x00007F80
		internal static event Action OnIpCountryChanged;

		/// <summary>
		/// Fired when running on a laptop and less than 10 minutes of battery is left, fires then every minute
		/// The parameter is the number of minutes left
		/// </summary>
		// Token: 0x14000033 RID: 51
		// (add) Token: 0x06000663 RID: 1635 RVA: 0x00009DB4 File Offset: 0x00007FB4
		// (remove) Token: 0x06000664 RID: 1636 RVA: 0x00009DE8 File Offset: 0x00007FE8
		internal static event Action<int> OnLowBatteryPower;

		/// <summary>
		/// Called when Steam wants to shutdown
		/// </summary>
		// Token: 0x14000034 RID: 52
		// (add) Token: 0x06000665 RID: 1637 RVA: 0x00009E1C File Offset: 0x0000801C
		// (remove) Token: 0x06000666 RID: 1638 RVA: 0x00009E50 File Offset: 0x00008050
		internal static event Action OnSteamShutdown;

		/// <summary>
		/// Big Picture gamepad text input has been closed. Parameter is true if text was submitted, false if cancelled etc.
		/// </summary>
		// Token: 0x14000035 RID: 53
		// (add) Token: 0x06000667 RID: 1639 RVA: 0x00009E84 File Offset: 0x00008084
		// (remove) Token: 0x06000668 RID: 1640 RVA: 0x00009EB8 File Offset: 0x000080B8
		internal static event Action<bool> OnGamepadTextInputDismissed;

		/// <summary>
		/// Returns the number of seconds since the application was active
		/// </summary>
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000669 RID: 1641 RVA: 0x00009EEB File Offset: 0x000080EB
		internal static uint SecondsSinceAppActive
		{
			get
			{
				return SteamUtils.Internal.GetSecondsSinceAppActive();
			}
		}

		/// <summary>
		/// Returns the number of seconds since the user last moved the mouse etc
		/// </summary>
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x00009EF7 File Offset: 0x000080F7
		internal static uint SecondsSinceComputerActive
		{
			get
			{
				return SteamUtils.Internal.GetSecondsSinceComputerActive();
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x00009F03 File Offset: 0x00008103
		internal static Universe ConnectedUniverse
		{
			get
			{
				return SteamUtils.Internal.GetConnectedUniverse();
			}
		}

		/// <summary>
		/// Steam server time.  Number of seconds since January 1, 1970, GMT (i.e unix time)
		/// </summary>
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x0600066C RID: 1644 RVA: 0x00009F0F File Offset: 0x0000810F
		internal static DateTime SteamServerTime
		{
			get
			{
				return Epoch.ToDateTime(SteamUtils.Internal.GetServerRealTime());
			}
		}

		/// <summary>
		/// returns the 2 digit ISO 3166-1-alpha-2 format country code this client is running in (as looked up via an IP-to-location database)
		/// e.g "US" or "UK".
		/// </summary>
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600066D RID: 1645 RVA: 0x00009F25 File Offset: 0x00008125
		internal static string IpCountry
		{
			get
			{
				return SteamUtils.Internal.GetIPCountry();
			}
		}

		/// <summary>
		/// returns true if the image exists, and the buffer was successfully filled out
		/// results are returned in RGBA format
		/// the destination buffer size should be 4 * height * width * sizeof(char)
		/// </summary>
		// Token: 0x0600066E RID: 1646 RVA: 0x00009F31 File Offset: 0x00008131
		internal static bool GetImageSize(int image, out uint width, out uint height)
		{
			width = 0U;
			height = 0U;
			return SteamUtils.Internal.GetImageSize(image, ref width, ref height);
		}

		/// <summary>
		/// returns the image in RGBA format
		/// </summary>
		// Token: 0x0600066F RID: 1647 RVA: 0x00009F48 File Offset: 0x00008148
		internal static Image? GetImage(int image)
		{
			if (image == -1)
			{
				return null;
			}
			if (image == 0)
			{
				return null;
			}
			Image i = default(Image);
			if (!SteamUtils.GetImageSize(image, out i.Width, out i.Height))
			{
				return null;
			}
			uint size = i.Width * i.Height * 4U;
			byte[] buf = Helpers.TakeBuffer((int)size);
			if (!SteamUtils.Internal.GetImageRGBA(image, buf, (int)size))
			{
				return null;
			}
			i.Data = new byte[size];
			Array.Copy(buf, 0L, i.Data, 0L, (long)((ulong)size));
			return new Image?(i);
		}

		/// <summary>
		/// Returns true if we're using a battery (ie, a laptop not plugged in)
		/// </summary>
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x06000670 RID: 1648 RVA: 0x00009FED File Offset: 0x000081ED
		internal static bool UsingBatteryPower
		{
			get
			{
				return SteamUtils.Internal.GetCurrentBatteryPower() != byte.MaxValue;
			}
		}

		/// <summary>
		/// Returns battery power [0-1]
		/// </summary>
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x06000671 RID: 1649 RVA: 0x0000A003 File Offset: 0x00008203
		internal static float CurrentBatteryPower
		{
			get
			{
				return Math.Min((float)(SteamUtils.Internal.GetCurrentBatteryPower() / 100), 1f);
			}
		}

		/// <summary>
		/// Sets the position where the overlay instance for the currently calling game should show notifications.
		/// This position is per-game and if this function is called from outside of a game context it will do nothing.
		/// </summary>
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x06000672 RID: 1650 RVA: 0x0000A01D File Offset: 0x0000821D
		// (set) Token: 0x06000673 RID: 1651 RVA: 0x0000A024 File Offset: 0x00008224
		internal static NotificationPosition OverlayNotificationPosition
		{
			get
			{
				return SteamUtils.overlayNotificationPosition;
			}
			set
			{
				SteamUtils.overlayNotificationPosition = value;
				SteamUtils.Internal.SetOverlayNotificationPosition(value);
			}
		}

		/// <summary>
		/// Returns true if the overlay is running and the user can access it. The overlay process could take a few seconds to
		/// start and hook the game process, so this function will initially return false while the overlay is loading.
		/// </summary>
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000674 RID: 1652 RVA: 0x0000A037 File Offset: 0x00008237
		internal static bool IsOverlayEnabled
		{
			get
			{
				return SteamUtils.Internal.IsOverlayEnabled();
			}
		}

		/// <summary>
		/// Normally this call is unneeded if your game has a constantly running frame loop that calls the 
		/// D3D Present API, or OGL SwapBuffers API every frame.
		///
		/// However, if you have a game that only refreshes the screen on an event driven basis then that can break 
		/// the overlay, as it uses your Present/SwapBuffers calls to drive it's internal frame loop and it may also
		/// need to Present() to the screen any time an even needing a notification happens or when the overlay is
		/// brought up over the game by a user.  You can use this API to ask the overlay if it currently need a present
		/// in that case, and then you can check for this periodically (roughly 33hz is desirable) and make sure you
		/// refresh the screen with Present or SwapBuffers to allow the overlay to do it's work.
		/// </summary>
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000675 RID: 1653 RVA: 0x0000A043 File Offset: 0x00008243
		internal static bool DoesOverlayNeedPresent
		{
			get
			{
				return SteamUtils.Internal.BOverlayNeedsPresent();
			}
		}

		/// <summary>
		/// Asynchronous call to check if an executable file has been signed using the internal key set on the signing tab
		/// of the partner site, for example to refuse to load modified executable files.  
		/// </summary>
		// Token: 0x06000676 RID: 1654 RVA: 0x0000A050 File Offset: 0x00008250
		internal static async Task<CheckFileSignature> CheckFileSignatureAsync(string filename)
		{
			CheckFileSignature_t? r = await SteamUtils.Internal.CheckFileSignature(filename);
			if (r == null)
			{
				throw new Exception("Something went wrong");
			}
			return r.Value.CheckFileSignature;
		}

		/// <summary>
		/// Activates the Big Picture text input dialog which only supports gamepad input
		/// </summary>
		// Token: 0x06000677 RID: 1655 RVA: 0x0000A093 File Offset: 0x00008293
		internal static bool ShowGamepadTextInput(GamepadTextInputMode inputMode, GamepadTextInputLineMode lineInputMode, string description, int maxChars, string existingText = "")
		{
			return SteamUtils.Internal.ShowGamepadTextInput(inputMode, lineInputMode, description, (uint)maxChars, existingText);
		}

		/// <summary>
		/// Returns previously entered text
		/// </summary>
		// Token: 0x06000678 RID: 1656 RVA: 0x0000A0A8 File Offset: 0x000082A8
		internal static string GetEnteredGamepadText()
		{
			if (SteamUtils.Internal.GetEnteredGamepadTextLength() == 0U)
			{
				return string.Empty;
			}
			string strVal;
			if (!SteamUtils.Internal.GetEnteredGamepadTextInput(out strVal))
			{
				return string.Empty;
			}
			return strVal;
		}

		/// <summary>
		/// returns the language the steam client is running in, you probably want 
		/// Apps.CurrentGameLanguage instead, this is for very special usage cases
		/// </summary>
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000679 RID: 1657 RVA: 0x0000A0DC File Offset: 0x000082DC
		internal static string SteamUILanguage
		{
			get
			{
				return SteamUtils.Internal.GetSteamUILanguage();
			}
		}

		/// <summary>
		/// returns true if Steam itself is running in VR mode
		/// </summary>
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x0600067A RID: 1658 RVA: 0x0000A0E8 File Offset: 0x000082E8
		internal static bool IsSteamRunningInVR
		{
			get
			{
				return SteamUtils.Internal.IsSteamRunningInVR();
			}
		}

		/// <summary>
		/// Sets the inset of the overlay notification from the corner specified by SetOverlayNotificationPosition
		/// </summary>
		// Token: 0x0600067B RID: 1659 RVA: 0x0000A0F4 File Offset: 0x000082F4
		internal static void SetOverlayNotificationInset(int x, int y)
		{
			SteamUtils.Internal.SetOverlayNotificationInset(x, y);
		}

		/// <summary>
		/// returns true if Steam and the Steam Overlay are running in Big Picture mode
		/// Games much be launched through the Steam client to enable the Big Picture overlay. During development,
		/// a game can be added as a non-steam game to the developers library to test this feature
		/// </summary>
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x0600067C RID: 1660 RVA: 0x0000A102 File Offset: 0x00008302
		internal static bool IsSteamInBigPictureMode
		{
			get
			{
				return SteamUtils.Internal.IsSteamInBigPictureMode();
			}
		}

		/// <summary>
		/// ask SteamUI to create and render its OpenVR dashboard
		/// </summary>
		// Token: 0x0600067D RID: 1661 RVA: 0x0000A10E File Offset: 0x0000830E
		internal static void StartVRDashboard()
		{
			SteamUtils.Internal.StartVRDashboard();
		}

		/// <summary>
		/// Set whether the HMD content will be streamed via Steam In-Home Streaming
		/// If this is set to true, then the scene in the HMD headset will be streamed, and remote input will not be allowed.
		/// If this is set to false, then the application window will be streamed instead, and remote input will be allowed.
		/// The default is true unless "VRHeadsetStreaming" "0" is in the extended appinfo for a game.
		/// (this is useful for games that have asymmetric multiplayer gameplay)
		/// </summary>
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600067E RID: 1662 RVA: 0x0000A11A File Offset: 0x0000831A
		// (set) Token: 0x0600067F RID: 1663 RVA: 0x0000A126 File Offset: 0x00008326
		internal static bool VrHeadsetStreaming
		{
			get
			{
				return SteamUtils.Internal.IsVRHeadsetStreamingEnabled();
			}
			set
			{
				SteamUtils.Internal.SetVRHeadsetStreamingEnabled(value);
			}
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0000A133 File Offset: 0x00008333
		internal static bool IsCallComplete(SteamAPICall_t call, out bool failed)
		{
			failed = false;
			return SteamUtils.Internal.IsAPICallCompleted(call, ref failed);
		}

		/// <summary>
		/// Returns whether this steam client is a Steam China specific client, vs the global client
		/// </summary>
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000681 RID: 1665 RVA: 0x0000A144 File Offset: 0x00008344
		internal static bool IsSteamChinaLauncher
		{
			get
			{
				return SteamUtils.Internal.IsSteamChinaLauncher();
			}
		}

		/// <summary>
		/// Initializes text filtering, loading dictionaries for the language the game is running in.
		/// Users can customize the text filter behavior in their Steam Account preferences
		/// </summary>
		// Token: 0x06000682 RID: 1666 RVA: 0x0000A150 File Offset: 0x00008350
		internal static bool InitFilterText()
		{
			return SteamUtils.Internal.InitFilterText(0U);
		}

		/// <summary>
		/// Filters the provided input message and places the filtered result into pchOutFilteredText,
		/// using legally required filtering and additional filtering based on the context and user settings.
		/// </summary>
		// Token: 0x06000683 RID: 1667 RVA: 0x0000A160 File Offset: 0x00008360
		internal static string FilterText(TextFilteringContext context, SteamId sourceSteamID, string inputMessage)
		{
			string filteredString;
			SteamUtils.Internal.FilterText(context, sourceSteamID, inputMessage, out filteredString);
			return filteredString;
		}

		/// <summary>
		/// returns true if Steam itself is running on the Steam Deck
		/// </summary>
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000684 RID: 1668 RVA: 0x0000A17E File Offset: 0x0000837E
		internal static bool IsRunningOnSteamDeck
		{
			get
			{
				return SteamUtils.Internal.IsSteamRunningOnSteamDeck();
			}
		}

		/// <summary>
		/// In game launchers that don't have controller support you can call this to have 
		/// Steam Input translate the controller input into mouse/kb to navigate the launcher
		/// </summary>
		// Token: 0x06000685 RID: 1669 RVA: 0x0000A18A File Offset: 0x0000838A
		internal static void SetGameLauncherMode(bool mode)
		{
			SteamUtils.Internal.SetGameLauncherMode(mode);
		}

		// Token: 0x0400092E RID: 2350
		private static NotificationPosition overlayNotificationPosition = NotificationPosition.BottomRight;
	}
}
