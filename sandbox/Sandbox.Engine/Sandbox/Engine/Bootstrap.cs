using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using NativeEngine;
using Sandbox.Internal;
using Sandbox.Utility;
using Sentry;
using Steamworks;

namespace Sandbox.Engine
{
	// Token: 0x020002F4 RID: 756
	[Hotload.SkipAttribute]
	internal static class Bootstrap
	{
		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06001413 RID: 5139 RVA: 0x0002AE1B File Offset: 0x0002901B
		// (set) Token: 0x06001414 RID: 5140 RVA: 0x0002AE22 File Offset: 0x00029022
		[ConsoleVariable("rcon_port")]
		public static int RconPort { get; set; } = 29016;

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06001415 RID: 5141 RVA: 0x0002AE2A File Offset: 0x0002902A
		// (set) Token: 0x06001416 RID: 5142 RVA: 0x0002AE31 File Offset: 0x00029031
		[ConsoleVariable("console_enabled", Saved = true)]
		public static bool EnableDeveloperConsole { get; set; } = true;

		/// <summary>
		/// Called before anything else. This should should set up any low level stuff that
		/// might be relied on if static functions are called. 
		/// </summary>
		// Token: 0x06001417 RID: 5143 RVA: 0x0002AE3C File Offset: 0x0002903C
		internal static bool PreInit(string rootFolder, bool dedicatedserver, bool isRetail, bool toolsMode)
		{
			ThreadSafe.MarkMainThread();
			Environment.CurrentDirectory = rootFolder;
			Bootstrap.IsDedicatedServer = dedicatedserver;
			Bootstrap.IsToolsMode = toolsMode;
			MainThreadContext.Init();
			TaskScheduler.UnobservedTaskException += Bootstrap.TaskScheduler_UnobservedTaskException;
			AppDomain.CurrentDomain.UnhandledException += delegate(object _, UnhandledExceptionEventArgs args)
			{
				GlobalSystemNamespace.Log.Error(args.ExceptionObject as Exception, "AppDomain unhandled exception");
			};
			ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(([Nullable(1)] object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true));
			if (Thread.CurrentThread.CurrentCulture.Name != "en-US")
			{
				CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
				Thread.CurrentThread.CurrentCulture = culture;
				Thread.CurrentThread.CurrentUICulture = culture;
			}
			if (isRetail)
			{
				string version = "unknown";
				string versionPath = Path.Combine(rootFolder, ".version");
				if (File.Exists(versionPath))
				{
					string[] split = File.ReadAllText(versionPath).Split("\n", StringSplitOptions.None);
					version = split[0];
				}
				SentrySdk.Init(delegate(SentryOptions config)
				{
					config.Dsn = "https://e31cc8323de84cbc92db8a3884747f5d@o13219.ingest.sentry.io/5715364";
					config.Release = version;
					config.AutoSessionTracking = true;
				});
				Logging.OnException = delegate(Exception e)
				{
					SentrySdk.CaptureException(e);
				};
			}
			Logging.Enabled = true;
			Logging.PrintToConsole = dedicatedserver;
			EngineFileSystem.Initialize(rootFolder);
			EngineFileSystem.DoMounts();
			CompilerSetup.Initialize();
			if (!dedicatedserver)
			{
				new SandboxedLoadContext("Sandbox.Menu");
				new SandboxedLoadContext("Sandbox.Client");
				if (toolsMode)
				{
					new SandboxedLoadContext("Sandbox.Tools");
				}
			}
			new SandboxedLoadContext("Sandbox.Server");
			LocalAddon.LoadFromConfig();
			return true;
		}

		/// <summary>
		/// Called on exceptions from a task (delayed, because it'll only get called when the exception gets collected)
		/// TODO: Move this somewhere else
		/// </summary>
		// Token: 0x06001418 RID: 5144 RVA: 0x0002AFDC File Offset: 0x000291DC
		private static void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
		{
			AggregateException exception = e.Exception.Flatten();
			Bootstrap.log.Error(exception);
			foreach (Exception ex in exception.InnerExceptions)
			{
				Bootstrap.log.Error(ex);
			}
		}

		/// <summary>
		/// Called to initialize the engine.
		/// </summary>
		// Token: 0x06001419 RID: 5145 RVA: 0x0002B044 File Offset: 0x00029244
		internal static bool Init()
		{
			GroupTiming time = new GroupTiming();
			Assembly assembly = typeof(Bootstrap).GetTypeInfo().Assembly;
			IToolsDll toolsDll = IToolsDll.Current;
			if (toolsDll != null)
			{
				toolsDll.SetStatus("Bootstrap..");
			}
			Bootstrap.log.Trace("Bootstrap::Init");
			Package.InitializeCache();
			using (time.Record("AddonManager.AddAll"))
			{
				ServerAddons.Init();
			}
			using (time.Record("Server Init"))
			{
				IToolsDll toolsDll2 = IToolsDll.Current;
				if (toolsDll2 != null)
				{
					toolsDll2.SetStatus("Server Init..");
				}
				IServerDll serverDll = IServerDll.Current;
				if (serverDll != null)
				{
					serverDll.Init();
				}
			}
			using (time.Record("Menu Init"))
			{
				IToolsDll toolsDll3 = IToolsDll.Current;
				if (toolsDll3 != null)
				{
					toolsDll3.SetStatus("Menu Init..");
				}
				IMenuDll menuDll = IMenuDll.Current;
				if (menuDll != null)
				{
					menuDll.Init();
				}
			}
			using (time.Record("Client Init"))
			{
				IToolsDll toolsDll4 = IToolsDll.Current;
				if (toolsDll4 != null)
				{
					toolsDll4.SetStatus("Client Init..");
				}
				IClientDll current = IClientDll.Current;
				if (current != null)
				{
					current.Init();
				}
			}
			if (SteamClient.IsValid)
			{
				SentrySdk.ConfigureScope(delegate(Scope scope)
				{
					scope.User = new User
					{
						Username = SteamClient.Name,
						Id = SteamClient.SteamId.ToString()
					};
				});
			}
			new MinidumpReporter();
			PropertyAttribute.OnPropertyRegistered = delegate(string name)
			{
				StringToken.FindOrCreate(name);
			};
			return true;
		}

		// Token: 0x04001532 RID: 5426
		internal static bool IsDedicatedServer;

		// Token: 0x04001533 RID: 5427
		internal static bool IsToolsMode;

		// Token: 0x04001534 RID: 5428
		private static readonly Logger log = Logging.GetLogger(null);
	}
}
