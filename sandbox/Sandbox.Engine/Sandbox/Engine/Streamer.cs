using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Sandbox.Internal;
using Sandbox.Twitch;

namespace Sandbox.Engine
{
	// Token: 0x02000302 RID: 770
	internal static class Streamer
	{
		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06001480 RID: 5248 RVA: 0x0002BD83 File Offset: 0x00029F83
		// (set) Token: 0x06001481 RID: 5249 RVA: 0x0002BD9C File Offset: 0x00029F9C
		internal static Api.ServiceToken ServiceToken
		{
			get
			{
				if (Streamer._serviceToken == null)
				{
					throw new Exception("No service token");
				}
				return Streamer._serviceToken;
			}
			private set
			{
				Streamer._serviceToken = value;
			}
		}

		/// <summary>
		/// Your own username
		/// </summary>
		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06001482 RID: 5250 RVA: 0x0002BDA4 File Offset: 0x00029FA4
		public static string Username
		{
			get
			{
				return Streamer.ServiceToken.Name;
			}
		}

		/// <summary>
		/// Your own user id
		/// </summary>
		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06001483 RID: 5251 RVA: 0x0002BDB0 File Offset: 0x00029FB0
		public static string UserId
		{
			get
			{
				return Streamer.ServiceToken.Id;
			}
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06001484 RID: 5252 RVA: 0x0002BDBC File Offset: 0x00029FBC
		internal static string Token
		{
			get
			{
				return Streamer.ServiceToken.Token;
			}
		}

		/// <summary>
		/// The service type (ie "Twitch")
		/// </summary>
		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x06001485 RID: 5253 RVA: 0x0002BDC8 File Offset: 0x00029FC8
		// (set) Token: 0x06001486 RID: 5254 RVA: 0x0002BDCF File Offset: 0x00029FCF
		public static StreamService ServiceType { get; private set; }

		/// <summary>
		/// Are we connected to a service
		/// </summary>
		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x06001487 RID: 5255 RVA: 0x0002BDD7 File Offset: 0x00029FD7
		public static bool IsActive
		{
			get
			{
				return Streamer.CurrentService != null;
			}
		}

		// Token: 0x06001488 RID: 5256 RVA: 0x0002BDE1 File Offset: 0x00029FE1
		internal static void RunEvent(string name)
		{
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll != null)
			{
				menuDll.RunEvent(name);
			}
			IClientDll current = IClientDll.Current;
			if (current == null)
			{
				return;
			}
			current.RunEvent(name);
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x0002BE04 File Offset: 0x0002A004
		internal static void RunEvent(string name, object argument)
		{
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll != null)
			{
				menuDll.RunEvent(name, argument);
			}
			IClientDll current = IClientDll.Current;
			if (current == null)
			{
				return;
			}
			current.RunEvent(name, argument);
		}

		// Token: 0x0600148A RID: 5258 RVA: 0x0002BE2C File Offset: 0x0002A02C
		private static async Task<bool> Init(IStreamService service, Api.ServiceToken token)
		{
			Streamer._serviceToken = token;
			Streamer.CurrentService = service;
			Streamer.ServiceType = ((Streamer.CurrentService != null) ? Streamer.CurrentService.ServiceType : StreamService.None);
			TaskAwaiter<bool> taskAwaiter = Streamer.CurrentService.Connect().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<bool> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<bool>);
			}
			bool result;
			if (!taskAwaiter.GetResult())
			{
				Streamer.ServiceType = StreamService.None;
				Streamer.CurrentService = null;
				GlobalSystemNamespace.Log.Info("Connection failed.");
				result = false;
			}
			else
			{
				GlobalSystemNamespace.Log.Info("Connected");
				result = true;
			}
			return result;
		}

		// Token: 0x0600148B RID: 5259 RVA: 0x0002BE78 File Offset: 0x0002A078
		internal static async Task<bool> Init(StreamService serviceType)
		{
			bool result;
			if (Streamer.CurrentService != null)
			{
				GlobalSystemNamespace.Log.Warning("Tried to start stream but already connected");
				result = false;
			}
			else
			{
				GlobalSystemNamespace.Log.Info("Getting Service Token..");
				IStreamService service = null;
				Api.ServiceToken token = await Streamer.GetLinkedService(serviceType);
				if (token == null)
				{
					GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't retrieve token for {0} (open https://sbox.facepunch.com/link)", new object[] { serviceType }));
					result = false;
				}
				else
				{
					GlobalSystemNamespace.Log.Info("Creating Service..");
					if (serviceType == StreamService.Twitch)
					{
						service = new TwitchService();
					}
					result = await Streamer.Init(service, token);
				}
			}
			return result;
		}

		// Token: 0x0600148C RID: 5260 RVA: 0x0002BEBC File Offset: 0x0002A0BC
		private static async Task<Api.ServiceToken> GetLinkedService(StreamService serviceType)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<StreamService>(serviceType);
			string serviceName = defaultInterpolatedStringHandler.ToStringAndClear();
			serviceName = serviceName.ToLower();
			Api.ServiceToken result;
			try
			{
				result = await Api.GetLinkedService(serviceName);
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600148D RID: 5261 RVA: 0x0002BEFF File Offset: 0x0002A0FF
		internal static void Shutdown()
		{
			IStreamService currentService = Streamer.CurrentService;
			if (currentService != null)
			{
				currentService.Disconnect();
			}
			Streamer.CurrentService = null;
		}

		// Token: 0x04001552 RID: 5458
		internal static IStreamService CurrentService;

		// Token: 0x04001553 RID: 5459
		internal static StreamBroadcast CurrentBroadcast;

		// Token: 0x04001554 RID: 5460
		internal static Api.ServiceToken _serviceToken;
	}
}
