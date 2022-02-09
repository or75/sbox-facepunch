using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Functions for accessing and manipulating Steam user information.
	/// This is also where the APIs for Steam Voice are exposed.
	/// </summary>
	// Token: 0x020000A5 RID: 165
	internal class SteamUser : SteamClientClass<SteamUser>
	{
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x0600060C RID: 1548 RVA: 0x00008BAD File Offset: 0x00006DAD
		internal static ISteamUser Internal
		{
			get
			{
				return SteamClientClass<SteamUser>.Interface as ISteamUser;
			}
		}

		// Token: 0x0600060D RID: 1549 RVA: 0x00008BB9 File Offset: 0x00006DB9
		internal override void InitializeInterface(bool server)
		{
			this.SetInterface(server, new ISteamUser(server));
			SteamUser.InstallEvents();
			SteamUser.richPresence = new Dictionary<string, string>();
			SteamUser.SampleRate = SteamUser.OptimalSampleRate;
		}

		// Token: 0x0600060E RID: 1550 RVA: 0x00008BE4 File Offset: 0x00006DE4
		internal static void InstallEvents()
		{
			Dispatch.Install<SteamServersConnected_t>(delegate(SteamServersConnected_t x)
			{
				Action onSteamServersConnected = SteamUser.OnSteamServersConnected;
				if (onSteamServersConnected == null)
				{
					return;
				}
				onSteamServersConnected();
			}, false);
			Dispatch.Install<SteamServerConnectFailure_t>(delegate(SteamServerConnectFailure_t x)
			{
				Action onSteamServerConnectFailure = SteamUser.OnSteamServerConnectFailure;
				if (onSteamServerConnectFailure == null)
				{
					return;
				}
				onSteamServerConnectFailure();
			}, false);
			Dispatch.Install<SteamServersDisconnected_t>(delegate(SteamServersDisconnected_t x)
			{
				Action onSteamServersDisconnected = SteamUser.OnSteamServersDisconnected;
				if (onSteamServersDisconnected == null)
				{
					return;
				}
				onSteamServersDisconnected();
			}, false);
			Dispatch.Install<ClientGameServerDeny_t>(delegate(ClientGameServerDeny_t x)
			{
				Action onClientGameServerDeny = SteamUser.OnClientGameServerDeny;
				if (onClientGameServerDeny == null)
				{
					return;
				}
				onClientGameServerDeny();
			}, false);
			Dispatch.Install<LicensesUpdated_t>(delegate(LicensesUpdated_t x)
			{
				Action onLicensesUpdated = SteamUser.OnLicensesUpdated;
				if (onLicensesUpdated == null)
				{
					return;
				}
				onLicensesUpdated();
			}, false);
			Dispatch.Install<ValidateAuthTicketResponse_t>(delegate(ValidateAuthTicketResponse_t x)
			{
				Action<SteamId, SteamId, AuthResponse> onValidateAuthTicketResponse = SteamUser.OnValidateAuthTicketResponse;
				if (onValidateAuthTicketResponse == null)
				{
					return;
				}
				onValidateAuthTicketResponse(x.SteamID, x.OwnerSteamID, x.AuthSessionResponse);
			}, false);
			Dispatch.Install<MicroTxnAuthorizationResponse_t>(delegate(MicroTxnAuthorizationResponse_t x)
			{
				Action<AppId, ulong, bool> onMicroTxnAuthorizationResponse = SteamUser.OnMicroTxnAuthorizationResponse;
				if (onMicroTxnAuthorizationResponse == null)
				{
					return;
				}
				onMicroTxnAuthorizationResponse(x.AppID, x.OrderID, x.Authorized > 0);
			}, false);
			Dispatch.Install<GameWebCallback_t>(delegate(GameWebCallback_t x)
			{
				Action<string> onGameWebCallback = SteamUser.OnGameWebCallback;
				if (onGameWebCallback == null)
				{
					return;
				}
				onGameWebCallback(x.URLUTF8());
			}, false);
			Dispatch.Install<GetAuthSessionTicketResponse_t>(delegate(GetAuthSessionTicketResponse_t x)
			{
				Action<GetAuthSessionTicketResponse_t> onGetAuthSessionTicketResponse = SteamUser.OnGetAuthSessionTicketResponse;
				if (onGetAuthSessionTicketResponse == null)
				{
					return;
				}
				onGetAuthSessionTicketResponse(x);
			}, false);
			Dispatch.Install<DurationControl_t>(delegate(DurationControl_t x)
			{
				Action<DurationControl> onDurationControl = SteamUser.OnDurationControl;
				if (onDurationControl == null)
				{
					return;
				}
				onDurationControl(new DurationControl
				{
					_inner = x
				});
			}, false);
		}

		/// <summary>
		/// Called when a connections to the Steam back-end has been established.
		/// This means the Steam client now has a working connection to the Steam servers. 
		/// Usually this will have occurred before the game has launched, and should only be seen if the 
		/// user has dropped connection due to a networking issue or a Steam server update.
		/// </summary>
		// Token: 0x14000023 RID: 35
		// (add) Token: 0x0600060F RID: 1551 RVA: 0x00008D64 File Offset: 0x00006F64
		// (remove) Token: 0x06000610 RID: 1552 RVA: 0x00008D98 File Offset: 0x00006F98
		internal static event Action OnSteamServersConnected;

		/// <summary>
		/// Called when a connection attempt has failed.
		/// This will occur periodically if the Steam client is not connected, 
		/// and has failed when retrying to establish a connection.
		/// </summary>
		// Token: 0x14000024 RID: 36
		// (add) Token: 0x06000611 RID: 1553 RVA: 0x00008DCC File Offset: 0x00006FCC
		// (remove) Token: 0x06000612 RID: 1554 RVA: 0x00008E00 File Offset: 0x00007000
		internal static event Action OnSteamServerConnectFailure;

		/// <summary>
		/// Called if the client has lost connection to the Steam servers.
		/// Real-time services will be disabled until a matching OnSteamServersConnected has been posted.
		/// </summary>
		// Token: 0x14000025 RID: 37
		// (add) Token: 0x06000613 RID: 1555 RVA: 0x00008E34 File Offset: 0x00007034
		// (remove) Token: 0x06000614 RID: 1556 RVA: 0x00008E68 File Offset: 0x00007068
		internal static event Action OnSteamServersDisconnected;

		/// <summary>
		/// Sent by the Steam server to the client telling it to disconnect from the specified game server, 
		/// which it may be in the process of or already connected to.
		/// The game client should immediately disconnect upon receiving this message.
		/// This can usually occur if the user doesn't have rights to play on the game server.
		/// </summary>
		// Token: 0x14000026 RID: 38
		// (add) Token: 0x06000615 RID: 1557 RVA: 0x00008E9C File Offset: 0x0000709C
		// (remove) Token: 0x06000616 RID: 1558 RVA: 0x00008ED0 File Offset: 0x000070D0
		internal static event Action OnClientGameServerDeny;

		/// <summary>
		/// Called whenever the users licenses (owned packages) changes.
		/// </summary>
		// Token: 0x14000027 RID: 39
		// (add) Token: 0x06000617 RID: 1559 RVA: 0x00008F04 File Offset: 0x00007104
		// (remove) Token: 0x06000618 RID: 1560 RVA: 0x00008F38 File Offset: 0x00007138
		internal static event Action OnLicensesUpdated;

		/// <summary>
		/// Called when an auth ticket has been validated. 
		/// The first parameter is the steamid of this user
		/// The second is the Steam ID that owns the game, this will be different from the first 
		/// if the game is being borrowed via Steam Family Sharing
		/// </summary>
		// Token: 0x14000028 RID: 40
		// (add) Token: 0x06000619 RID: 1561 RVA: 0x00008F6C File Offset: 0x0000716C
		// (remove) Token: 0x0600061A RID: 1562 RVA: 0x00008FA0 File Offset: 0x000071A0
		internal static event Action<SteamId, SteamId, AuthResponse> OnValidateAuthTicketResponse;

		/// <summary>
		/// Used internally for GetAuthSessionTicketAsync
		/// </summary>
		// Token: 0x14000029 RID: 41
		// (add) Token: 0x0600061B RID: 1563 RVA: 0x00008FD4 File Offset: 0x000071D4
		// (remove) Token: 0x0600061C RID: 1564 RVA: 0x00009008 File Offset: 0x00007208
		internal static event Action<GetAuthSessionTicketResponse_t> OnGetAuthSessionTicketResponse;

		/// <summary>
		/// Called when a user has responded to a microtransaction authorization request.
		/// ( appid, orderid, user authorized )
		/// </summary>
		// Token: 0x1400002A RID: 42
		// (add) Token: 0x0600061D RID: 1565 RVA: 0x0000903C File Offset: 0x0000723C
		// (remove) Token: 0x0600061E RID: 1566 RVA: 0x00009070 File Offset: 0x00007270
		internal static event Action<AppId, ulong, bool> OnMicroTxnAuthorizationResponse;

		/// <summary>
		/// Sent to your game in response to a steam://gamewebcallback/(appid)/command/stuff command from a user clicking a 
		/// link in the Steam overlay browser.
		/// You can use this to add support for external site signups where you want to pop back into the browser after some web page 
		/// signup sequence, and optionally get back some detail about that.
		/// </summary>
		// Token: 0x1400002B RID: 43
		// (add) Token: 0x0600061F RID: 1567 RVA: 0x000090A4 File Offset: 0x000072A4
		// (remove) Token: 0x06000620 RID: 1568 RVA: 0x000090D8 File Offset: 0x000072D8
		internal static event Action<string> OnGameWebCallback;

		/// <summary>
		/// Sent for games with enabled anti indulgence / duration control, for enabled users.
		/// Lets the game know whether persistent rewards or XP should be granted at normal rate, 
		/// half rate, or zero rate.
		/// </summary>
		// Token: 0x1400002C RID: 44
		// (add) Token: 0x06000621 RID: 1569 RVA: 0x0000910C File Offset: 0x0000730C
		// (remove) Token: 0x06000622 RID: 1570 RVA: 0x00009140 File Offset: 0x00007340
		internal static event Action<DurationControl> OnDurationControl;

		/// <summary>
		/// Starts/Stops voice recording.
		/// Once started, use GetAvailableVoice and GetVoice to get the data, and then call StopVoiceRecording 
		/// when the user has released their push-to-talk hotkey or the game session has completed.
		/// </summary>
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000623 RID: 1571 RVA: 0x00009173 File Offset: 0x00007373
		// (set) Token: 0x06000624 RID: 1572 RVA: 0x0000917A File Offset: 0x0000737A
		internal static bool VoiceRecord
		{
			get
			{
				return SteamUser._recordingVoice;
			}
			set
			{
				SteamUser._recordingVoice = value;
				if (value)
				{
					SteamUser.Internal.StartVoiceRecording();
					return;
				}
				SteamUser.Internal.StopVoiceRecording();
			}
		}

		/// <summary>
		/// Returns true if we have voice data waiting to be read
		/// </summary>
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000625 RID: 1573 RVA: 0x0000919C File Offset: 0x0000739C
		internal static bool HasVoiceData
		{
			get
			{
				uint szCompressed = 0U;
				uint deprecated = 0U;
				return SteamUser.Internal.GetAvailableVoice(ref szCompressed, ref deprecated, 0U) == VoiceResult.OK && szCompressed > 0U;
			}
		}

		/// <summary>
		/// Reads the voice data and returns the number of bytes written.
		/// The compressed data can be transmitted by your application and decoded back into raw audio data using 
		/// DecompressVoice on the other side. The compressed data provided is in an arbitrary format and is not meant to be played directly.
		/// This should be called once per frame, and at worst no more than four times a second to keep the microphone input delay as low as 
		/// possible. Calling this any less may result in gaps in the returned stream.
		/// </summary>
		// Token: 0x06000626 RID: 1574 RVA: 0x000091C4 File Offset: 0x000073C4
		internal unsafe static int ReadVoiceData(Stream stream)
		{
			if (!SteamUser.HasVoiceData)
			{
				return 0;
			}
			uint szWritten = 0U;
			uint deprecated = 0U;
			byte[] array;
			byte* b;
			if ((array = SteamUser.readBuffer) == null || array.Length == 0)
			{
				b = null;
			}
			else
			{
				b = &array[0];
			}
			if (SteamUser.Internal.GetVoice(true, (IntPtr)((void*)b), (uint)SteamUser.readBuffer.Length, ref szWritten, false, IntPtr.Zero, 0U, ref deprecated, 0U) != VoiceResult.OK)
			{
				return 0;
			}
			array = null;
			if (szWritten == 0U)
			{
				return 0;
			}
			stream.Write(SteamUser.readBuffer, 0, (int)szWritten);
			return (int)szWritten;
		}

		/// <summary>
		/// Reads the voice data and returns the bytes. You should obviously ideally be using
		/// ReadVoiceData because it won't be creating a new byte array every call. But this 
		/// makes it easier to get it working, so let the babies have their bottle.
		/// </summary>
		// Token: 0x06000627 RID: 1575 RVA: 0x00009238 File Offset: 0x00007438
		internal unsafe static byte[] ReadVoiceDataBytes()
		{
			if (!SteamUser.HasVoiceData)
			{
				return null;
			}
			uint szWritten = 0U;
			uint deprecated = 0U;
			byte[] array;
			byte* b;
			if ((array = SteamUser.readBuffer) == null || array.Length == 0)
			{
				b = null;
			}
			else
			{
				b = &array[0];
			}
			if (SteamUser.Internal.GetVoice(true, (IntPtr)((void*)b), (uint)SteamUser.readBuffer.Length, ref szWritten, false, IntPtr.Zero, 0U, ref deprecated, 0U) != VoiceResult.OK)
			{
				return null;
			}
			array = null;
			if (szWritten == 0U)
			{
				return null;
			}
			byte[] arry = new byte[szWritten];
			Array.Copy(SteamUser.readBuffer, 0L, arry, 0L, (long)((ulong)szWritten));
			return arry;
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000628 RID: 1576 RVA: 0x000092BA File Offset: 0x000074BA
		// (set) Token: 0x06000629 RID: 1577 RVA: 0x000092C1 File Offset: 0x000074C1
		internal static uint SampleRate
		{
			get
			{
				return SteamUser.sampleRate;
			}
			set
			{
				if (SteamUser.SampleRate < 11025U)
				{
					throw new Exception("Sample Rate must be between 11025 and 48000");
				}
				if (SteamUser.SampleRate > 48000U)
				{
					throw new Exception("Sample Rate must be between 11025 and 48000");
				}
				SteamUser.sampleRate = value;
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600062A RID: 1578 RVA: 0x000092F7 File Offset: 0x000074F7
		internal static uint OptimalSampleRate
		{
			get
			{
				return SteamUser.Internal.GetVoiceOptimalSampleRate();
			}
		}

		/// <summary>
		/// Decodes the compressed voice data returned by GetVoice.
		/// The output data is raw single-channel 16-bit PCM audio.The decoder supports any sample rate from 11025 to 48000.
		/// </summary>
		// Token: 0x0600062B RID: 1579 RVA: 0x00009304 File Offset: 0x00007504
		internal unsafe static int DecompressVoice(Stream input, int length, Stream output)
		{
			byte[] from = Helpers.TakeBuffer(length);
			byte[] to = Helpers.TakeBuffer(65536);
			using (MemoryStream s = new MemoryStream(from))
			{
				input.CopyTo(s);
			}
			uint szWritten = 0U;
			byte[] array;
			byte* frm;
			if ((array = from) == null || array.Length == 0)
			{
				frm = null;
			}
			else
			{
				frm = &array[0];
			}
			byte[] array2;
			byte* dst;
			if ((array2 = to) == null || array2.Length == 0)
			{
				dst = null;
			}
			else
			{
				dst = &array2[0];
			}
			if (SteamUser.Internal.DecompressVoice((IntPtr)((void*)frm), (uint)length, (IntPtr)((void*)dst), (uint)to.Length, ref szWritten, SteamUser.SampleRate) != VoiceResult.OK)
			{
				return 0;
			}
			array2 = null;
			array = null;
			if (szWritten == 0U)
			{
				return 0;
			}
			output.Write(to, 0, (int)szWritten);
			return (int)szWritten;
		}

		/// <summary>
		/// Lazy version
		/// </summary>
		// Token: 0x0600062C RID: 1580 RVA: 0x000093C8 File Offset: 0x000075C8
		internal unsafe static int DecompressVoice(byte[] from, Stream output)
		{
			byte[] to = Helpers.TakeBuffer(65536);
			uint szWritten = 0U;
			fixed (byte[] array = from)
			{
				byte* frm;
				if (from == null || array.Length == 0)
				{
					frm = null;
				}
				else
				{
					frm = &array[0];
				}
				byte[] array2;
				byte* dst;
				if ((array2 = to) == null || array2.Length == 0)
				{
					dst = null;
				}
				else
				{
					dst = &array2[0];
				}
				if (SteamUser.Internal.DecompressVoice((IntPtr)((void*)frm), (uint)from.Length, (IntPtr)((void*)dst), (uint)to.Length, ref szWritten, SteamUser.SampleRate) != VoiceResult.OK)
				{
					return 0;
				}
				array2 = null;
			}
			if (szWritten == 0U)
			{
				return 0;
			}
			output.Write(to, 0, (int)szWritten);
			return (int)szWritten;
		}

		/// <summary>
		/// Advanced and potentially fastest version - incase you know what you're doing
		/// </summary>
		// Token: 0x0600062D RID: 1581 RVA: 0x00009454 File Offset: 0x00007654
		internal static int DecompressVoice(IntPtr from, int length, IntPtr to, int bufferSize)
		{
			if (length <= 0)
			{
				throw new ArgumentException("length should be > 0 ");
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentException("bufferSize should be > 0 ");
			}
			uint szWritten = 0U;
			if (SteamUser.Internal.DecompressVoice(from, (uint)length, to, (uint)bufferSize, ref szWritten, SteamUser.SampleRate) != VoiceResult.OK)
			{
				return 0;
			}
			return (int)szWritten;
		}

		/// <summary>
		/// Retrieve a authentication ticket to be sent to the entity who wishes to authenticate you.
		/// </summary>
		// Token: 0x0600062E RID: 1582 RVA: 0x0000949C File Offset: 0x0000769C
		internal unsafe static AuthTicket GetAuthSessionTicket()
		{
			byte[] data = Helpers.TakeBuffer(1024);
			byte[] array;
			byte* b;
			if ((array = data) == null || array.Length == 0)
			{
				b = null;
			}
			else
			{
				b = &array[0];
			}
			uint ticketLength = 0U;
			uint ticket = SteamUser.Internal.GetAuthSessionTicket((IntPtr)((void*)b), data.Length, ref ticketLength);
			if (ticket == 0U)
			{
				return null;
			}
			return new AuthTicket
			{
				Data = data.Take((int)ticketLength).ToArray<byte>(),
				Handle = ticket
			};
		}

		/// <summary>
		/// Retrieve a authentication ticket to be sent to the entity who wishes to authenticate you.
		/// This waits for a positive response from the backend before returning the ticket. This means
		/// the ticket is definitely ready to go as soon as it returns. Will return null if the callback
		/// times out or returns negatively.
		/// </summary>
		// Token: 0x0600062F RID: 1583 RVA: 0x00009510 File Offset: 0x00007710
		internal static async Task<AuthTicket> GetAuthSessionTicketAsync(double timeoutSeconds = 10.0)
		{
			SteamUser.<>c__DisplayClass54_0 CS$<>8__locals1 = new SteamUser.<>c__DisplayClass54_0();
			CS$<>8__locals1.result = Result.Pending;
			CS$<>8__locals1.ticket = null;
			Stopwatch stopwatch = Stopwatch.StartNew();
			SteamUser.OnGetAuthSessionTicketResponse += CS$<>8__locals1.<GetAuthSessionTicketAsync>g__f|0;
			AuthTicket result;
			try
			{
				CS$<>8__locals1.ticket = SteamUser.GetAuthSessionTicket();
				if (CS$<>8__locals1.ticket == null)
				{
					result = null;
				}
				else
				{
					while (CS$<>8__locals1.result == Result.Pending)
					{
						await Task.Delay(10);
						if (stopwatch.Elapsed.TotalSeconds > timeoutSeconds)
						{
							CS$<>8__locals1.ticket.Cancel();
							return null;
						}
					}
					if (CS$<>8__locals1.result == Result.OK)
					{
						result = CS$<>8__locals1.ticket;
					}
					else
					{
						CS$<>8__locals1.ticket.Cancel();
						result = null;
					}
				}
			}
			finally
			{
				SteamUser.OnGetAuthSessionTicketResponse -= CS$<>8__locals1.<GetAuthSessionTicketAsync>g__f|0;
			}
			return result;
		}

		// Token: 0x06000630 RID: 1584 RVA: 0x00009554 File Offset: 0x00007754
		internal unsafe static BeginAuthResult BeginAuthSession(byte[] ticketData, SteamId steamid)
		{
			byte* ptr;
			if (ticketData == null || ticketData.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &ticketData[0];
			}
			return SteamUser.Internal.BeginAuthSession((IntPtr)((void*)ptr), ticketData.Length, steamid);
		}

		// Token: 0x06000631 RID: 1585 RVA: 0x0000958D File Offset: 0x0000778D
		internal static void EndAuthSession(SteamId steamid)
		{
			SteamUser.Internal.EndAuthSession(steamid);
		}

		/// <summary>
		/// Checks if the current users looks like they are behind a NAT device.
		/// This is only valid if the user is connected to the Steam servers and may not catch all forms of NAT.
		/// </summary>
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x06000632 RID: 1586 RVA: 0x0000959A File Offset: 0x0000779A
		internal static bool IsBehindNAT
		{
			get
			{
				return SteamUser.Internal.BIsBehindNAT();
			}
		}

		/// <summary>
		/// Gets the Steam level of the user, as shown on their Steam community profile.
		/// </summary>
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x06000633 RID: 1587 RVA: 0x000095A6 File Offset: 0x000077A6
		internal static int SteamLevel
		{
			get
			{
				return SteamUser.Internal.GetPlayerSteamLevel();
			}
		}

		/// <summary>
		/// Requests a URL which authenticates an in-game browser for store check-out, and then redirects to the specified URL.
		/// As long as the in-game browser accepts and handles session cookies, Steam microtransaction checkout pages will automatically recognize the user instead of presenting a login page.
		/// NOTE: The URL has a very short lifetime to prevent history-snooping attacks, so you should only call this API when you are about to launch the browser, or else immediately navigate to the result URL using a hidden browser window.
		/// NOTE: The resulting authorization cookie has an expiration time of one day, so it would be a good idea to request and visit a new auth URL every 12 hours.
		/// </summary>
		// Token: 0x06000634 RID: 1588 RVA: 0x000095B4 File Offset: 0x000077B4
		internal static async Task<string> GetStoreAuthUrlAsync(string url)
		{
			StoreAuthURLResponse_t? response = await SteamUser.Internal.RequestStoreAuthURL(url);
			string result;
			if (response == null)
			{
				result = null;
			}
			else
			{
				result = response.Value.URLUTF8();
			}
			return result;
		}

		/// <summary>
		/// Checks whether the current user has verified their phone number.
		/// </summary>
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000635 RID: 1589 RVA: 0x000095F7 File Offset: 0x000077F7
		internal static bool IsPhoneVerified
		{
			get
			{
				return SteamUser.Internal.BIsPhoneVerified();
			}
		}

		/// <summary>
		/// Checks whether the current user has Steam Guard two factor authentication enabled on their account.
		/// </summary>
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000636 RID: 1590 RVA: 0x00009603 File Offset: 0x00007803
		internal static bool IsTwoFactorEnabled
		{
			get
			{
				return SteamUser.Internal.BIsTwoFactorEnabled();
			}
		}

		/// <summary>
		/// Checks whether the user's phone number is used to uniquely identify them.
		/// </summary>
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000637 RID: 1591 RVA: 0x0000960F File Offset: 0x0000780F
		internal static bool IsPhoneIdentifying
		{
			get
			{
				return SteamUser.Internal.BIsPhoneIdentifying();
			}
		}

		/// <summary>
		/// Checks whether the current user's phone number is awaiting (re)verification.
		/// </summary>
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000638 RID: 1592 RVA: 0x0000961B File Offset: 0x0000781B
		internal static bool IsPhoneRequiringVerification
		{
			get
			{
				return SteamUser.Internal.BIsPhoneRequiringVerification();
			}
		}

		/// <summary>
		/// Requests an application ticket encrypted with the secret "encrypted app ticket key".
		/// The encryption key can be obtained from the Encrypted App Ticket Key page on the App Admin for your app.
		/// There can only be one call pending, and this call is subject to a 60 second rate limit.
		/// If you get a null result from this it's probably because you're calling it too often.
		/// This can fail if you don't have an encrypted ticket set for your app here https://partner.steamgames.com/apps/sdkauth/
		/// </summary>
		// Token: 0x06000639 RID: 1593 RVA: 0x00009628 File Offset: 0x00007828
		internal static async Task<byte[]> RequestEncryptedAppTicketAsync(byte[] dataToInclude)
		{
			IntPtr dataPtr = Marshal.AllocHGlobal(dataToInclude.Length);
			Marshal.Copy(dataToInclude, 0, dataPtr, dataToInclude.Length);
			byte[] result2;
			try
			{
				EncryptedAppTicketResponse_t? result = await SteamUser.Internal.RequestEncryptedAppTicket(dataPtr, dataToInclude.Length);
				if (result == null || result.Value.Result != Result.OK)
				{
					result2 = null;
				}
				else
				{
					IntPtr ticketData = Marshal.AllocHGlobal(1024);
					uint outSize = 0U;
					byte[] data = null;
					if (SteamUser.Internal.GetEncryptedAppTicket(ticketData, 1024, ref outSize))
					{
						data = new byte[outSize];
						Marshal.Copy(ticketData, data, 0, (int)outSize);
					}
					Marshal.FreeHGlobal(ticketData);
					result2 = data;
				}
			}
			finally
			{
				Marshal.FreeHGlobal(dataPtr);
			}
			return result2;
		}

		/// <summary>
		/// Requests an application ticket encrypted with the secret "encrypted app ticket key".
		/// The encryption key can be obtained from the Encrypted App Ticket Key page on the App Admin for your app.
		/// There can only be one call pending, and this call is subject to a 60 second rate limit.
		/// This can fail if you don't have an encrypted ticket set for your app here https://partner.steamgames.com/apps/sdkauth/
		/// </summary>
		// Token: 0x0600063A RID: 1594 RVA: 0x0000966C File Offset: 0x0000786C
		internal static async Task<byte[]> RequestEncryptedAppTicketAsync()
		{
			EncryptedAppTicketResponse_t? result = await SteamUser.Internal.RequestEncryptedAppTicket(IntPtr.Zero, 0);
			byte[] result2;
			if (result == null || result.Value.Result != Result.OK)
			{
				result2 = null;
			}
			else
			{
				IntPtr ticketData = Marshal.AllocHGlobal(1024);
				uint outSize = 0U;
				byte[] data = null;
				if (SteamUser.Internal.GetEncryptedAppTicket(ticketData, 1024, ref outSize))
				{
					data = new byte[outSize];
					Marshal.Copy(ticketData, data, 0, (int)outSize);
				}
				Marshal.FreeHGlobal(ticketData);
				result2 = data;
			}
			return result2;
		}

		/// <summary>
		/// Get anti indulgence / duration control
		/// </summary>
		// Token: 0x0600063B RID: 1595 RVA: 0x000096A8 File Offset: 0x000078A8
		internal static async Task<DurationControl> GetDurationControl()
		{
			DurationControl_t? response = await SteamUser.Internal.GetDurationControl();
			DurationControl result;
			if (response == null)
			{
				result = default(DurationControl);
			}
			else
			{
				result = new DurationControl
				{
					_inner = response.Value
				};
			}
			return result;
		}

		// Token: 0x04000916 RID: 2326
		private static Dictionary<string, string> richPresence;

		// Token: 0x04000921 RID: 2337
		private static bool _recordingVoice;

		// Token: 0x04000922 RID: 2338
		private static byte[] readBuffer = new byte[131072];

		// Token: 0x04000923 RID: 2339
		private static uint sampleRate = 48000U;
	}
}
