using System;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Undocumented Parental Settings
	/// </summary>
	// Token: 0x020000A4 RID: 164
	internal class SteamScreenshots : SteamClientClass<SteamScreenshots>
	{
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060005FD RID: 1533 RVA: 0x00008927 File Offset: 0x00006B27
		internal static ISteamScreenshots Internal
		{
			get
			{
				return SteamClientClass<SteamScreenshots>.Interface as ISteamScreenshots;
			}
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x00008933 File Offset: 0x00006B33
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamScreenshots(server));
			SteamScreenshots.InstallEvents();
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x00008948 File Offset: 0x00006B48
		internal static void InstallEvents()
		{
			Dispatch.Install<ScreenshotRequested_t>(delegate(ScreenshotRequested_t x)
			{
				Action onScreenshotRequested = SteamScreenshots.OnScreenshotRequested;
				if (onScreenshotRequested == null)
				{
					return;
				}
				onScreenshotRequested();
			}, false);
			Dispatch.Install<ScreenshotReady_t>(delegate(ScreenshotReady_t x)
			{
				if (x.Result != Result.OK)
				{
					Action<Result> onScreenshotFailed = SteamScreenshots.OnScreenshotFailed;
					if (onScreenshotFailed == null)
					{
						return;
					}
					onScreenshotFailed(x.Result);
					return;
				}
				else
				{
					Action<Screenshot> onScreenshotReady = SteamScreenshots.OnScreenshotReady;
					if (onScreenshotReady == null)
					{
						return;
					}
					onScreenshotReady(new Screenshot
					{
						Value = x.Local
					});
					return;
				}
			}, false);
		}

		/// <summary>
		/// A screenshot has been requested by the user from the Steam screenshot hotkey. 
		/// This will only be called if Hooked is true, in which case Steam 
		/// will not take the screenshot itself.
		/// </summary>
		// Token: 0x14000020 RID: 32
		// (add) Token: 0x06000600 RID: 1536 RVA: 0x000089A0 File Offset: 0x00006BA0
		// (remove) Token: 0x06000601 RID: 1537 RVA: 0x000089D4 File Offset: 0x00006BD4
		internal static event Action OnScreenshotRequested;

		/// <summary>
		/// A screenshot successfully written or otherwise added to the library and can now be tagged.
		/// </summary>
		// Token: 0x14000021 RID: 33
		// (add) Token: 0x06000602 RID: 1538 RVA: 0x00008A08 File Offset: 0x00006C08
		// (remove) Token: 0x06000603 RID: 1539 RVA: 0x00008A3C File Offset: 0x00006C3C
		internal static event Action<Screenshot> OnScreenshotReady;

		/// <summary>
		/// A screenshot attempt failed
		/// </summary>
		// Token: 0x14000022 RID: 34
		// (add) Token: 0x06000604 RID: 1540 RVA: 0x00008A70 File Offset: 0x00006C70
		// (remove) Token: 0x06000605 RID: 1541 RVA: 0x00008AA4 File Offset: 0x00006CA4
		internal static event Action<Result> OnScreenshotFailed;

		/// <summary>
		/// Writes a screenshot to the user's screenshot library given the raw image data, which must be in RGB format.
		/// The return value is a handle that is valid for the duration of the game process and can be used to apply tags.
		/// </summary>
		// Token: 0x06000606 RID: 1542 RVA: 0x00008AD8 File Offset: 0x00006CD8
		internal unsafe static Screenshot? WriteScreenshot(byte[] data, int width, int height)
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
			ScreenshotHandle handle = SteamScreenshots.Internal.WriteScreenshot((IntPtr)((void*)ptr), (uint)data.Length, width, height);
			if (handle.Value == 0U)
			{
				return null;
			}
			return new Screenshot?(new Screenshot
			{
				Value = handle
			});
		}

		/// <summary>
		/// Adds a screenshot to the user's screenshot library from disk.  If a thumbnail is provided, it must be 200 pixels wide and the same aspect ratio
		/// as the screenshot, otherwise a thumbnail will be generated if the user uploads the screenshot.  The screenshots must be in either JPEG or TGA format.
		/// The return value is a handle that is valid for the duration of the game process and can be used to apply tags.
		/// JPEG, TGA, and PNG formats are supported.
		/// </summary>
		// Token: 0x06000607 RID: 1543 RVA: 0x00008B3C File Offset: 0x00006D3C
		internal static Screenshot? AddScreenshot(string filename, string thumbnail, int width, int height)
		{
			ScreenshotHandle handle = SteamScreenshots.Internal.AddScreenshotToLibrary(filename, thumbnail, width, height);
			if (handle.Value == 0U)
			{
				return null;
			}
			return new Screenshot?(new Screenshot
			{
				Value = handle
			});
		}

		/// <summary>
		/// Causes the Steam overlay to take a screenshot.  
		/// If screenshots are being hooked by the game then a 
		/// ScreenshotRequested callback is sent back to the game instead. 
		/// </summary>
		// Token: 0x06000608 RID: 1544 RVA: 0x00008B80 File Offset: 0x00006D80
		internal static void TriggerScreenshot()
		{
			SteamScreenshots.Internal.TriggerScreenshot();
		}

		/// <summary>
		/// Toggles whether the overlay handles screenshots when the user presses the screenshot hotkey, or if the game handles them.
		/// Hooking is disabled by default, and only ever enabled if you do so with this function.
		/// If the hooking is enabled, then the ScreenshotRequested_t callback will be sent if the user presses the hotkey or 
		/// when TriggerScreenshot is called, and then the game is expected to call WriteScreenshot or AddScreenshotToLibrary in response.
		/// </summary>
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000609 RID: 1545 RVA: 0x00008B8C File Offset: 0x00006D8C
		// (set) Token: 0x0600060A RID: 1546 RVA: 0x00008B98 File Offset: 0x00006D98
		internal static bool Hooked
		{
			get
			{
				return SteamScreenshots.Internal.IsScreenshotsHooked();
			}
			set
			{
				SteamScreenshots.Internal.HookScreenshots(value);
			}
		}
	}
}
