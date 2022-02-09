using System;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox.Engine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000298 RID: 664
	[Hotload.SkipAttribute]
	internal static class EngineLoop
	{
		/// <summary>
		/// Main menu loop has started
		/// </summary>
		// Token: 0x060010D8 RID: 4312 RVA: 0x0001F6BC File Offset: 0x0001D8BC
		internal static void EnterMainMenu()
		{
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll == null)
			{
				return;
			}
			menuDll.SwitchToMainuMenu();
		}

		/// <summary>
		/// Main menu loop has ended
		/// </summary>
		// Token: 0x060010D9 RID: 4313 RVA: 0x0001F6CD File Offset: 0x0001D8CD
		internal static void LeaveMainMenu()
		{
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x0001F6CF File Offset: 0x0001D8CF
		internal static void StartConnecting()
		{
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll == null)
			{
				return;
			}
			menuDll.StartConnecting();
		}

		/// <summary>
		/// Start game loop
		/// </summary>
		// Token: 0x060010DB RID: 4315 RVA: 0x0001F6E0 File Offset: 0x0001D8E0
		internal static void EnterGame()
		{
		}

		/// <summary>
		/// Leave game loop
		/// </summary>
		// Token: 0x060010DC RID: 4316 RVA: 0x0001F6E2 File Offset: 0x0001D8E2
		internal static void LeaveGame()
		{
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x0001F6E4 File Offset: 0x0001D8E4
		internal static void ShowGameUI()
		{
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll == null)
			{
				return;
			}
			menuDll.ShowMenu(true);
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x0001F6F6 File Offset: 0x0001D8F6
		internal static void HideGameUI()
		{
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll == null)
			{
				return;
			}
			menuDll.ShowMenu(false);
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x0001F708 File Offset: 0x0001D908
		internal static void FrameStart()
		{
			ThreadSafe.AssertIsMainThread("FrameStart");
			MainThread.RunQueues();
			EngineLoop.UpdatePerformance();
			MainThreadContext instance = MainThreadContext.Instance;
			if (instance != null)
			{
				instance.ProcessQueue();
			}
			FileWatch.Tick();
			ServerAddons.Tick();
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll != null)
			{
				menuDll.Tick();
			}
			IClientDll current = IClientDll.Current;
			if (current != null)
			{
				current.Tick();
			}
			IServerDll serverDll = IServerDll.Current;
			if (serverDll != null)
			{
				serverDll.Tick();
			}
			MainThreadContext instance2 = MainThreadContext.Instance;
			if (instance2 != null)
			{
				instance2.ProcessQueue();
			}
			Logging.PushQueuedMessages();
			if (!Bootstrap.IsDedicatedServer)
			{
				Mouse.Tick();
				Keyboard.Tick();
			}
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x0001F799 File Offset: 0x0001D999
		internal static void FrameEnd()
		{
			ThreadSafe.AssertIsMainThread("FrameEnd");
			IStreamService currentService = Streamer.CurrentService;
			if (currentService != null)
			{
				currentService.Tick();
			}
			MainThreadContext instance = MainThreadContext.Instance;
			if (instance != null)
			{
				instance.ProcessQueue();
			}
			Interop.Free();
			MainThread.RunQueues();
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x0001F7D3 File Offset: 0x0001D9D3
		private static void UpdatePerformance()
		{
			PerformanceStats.Frame();
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x0001F7DB File Offset: 0x0001D9DB
		internal static void PreInput()
		{
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x0001F7DD File Offset: 0x0001D9DD
		internal static void PostInput()
		{
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x0001F7DF File Offset: 0x0001D9DF
		internal static void InitNetworkGameClient(NetworkGameClient cl)
		{
			IClientDll current = IClientDll.Current;
			if (current == null)
			{
				return;
			}
			current.InitNetworkGameClient(cl);
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x0001F7F1 File Offset: 0x0001D9F1
		internal static void InitServerSideClient(ServerSideClient sl)
		{
			IServerDll serverDll = IServerDll.Current;
			if (serverDll == null)
			{
				return;
			}
			serverDll.InitServerSideClient(sl);
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x0001F803 File Offset: 0x0001DA03
		internal static void UpdateProgressBar(LevelLoadingProgress e)
		{
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll == null)
			{
				return;
			}
			menuDll.UpdateProgressBar(e);
		}

		/// <summary>
		/// An input event from the engine has arrived. This could be a mouse move, key press etc.
		/// We let the menu have a go at it first, if it doesn't swallow it, we pass it to the client.
		/// </summary>
		// Token: 0x060010E7 RID: 4327 RVA: 0x0001F815 File Offset: 0x0001DA15
		internal static bool HandleInputEvent(InputEvent data)
		{
			Mouse.UpdateMousePosition(data);
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll != null && menuDll.HandleInputEvent(data))
			{
				return true;
			}
			IClientDll current = IClientDll.Current;
			return current != null && current.HandleInputEvent(data);
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0001F844 File Offset: 0x0001DA44
		internal static bool ConvarFromClient(int clientSlot, string key, string val)
		{
			IServerDll serverDll = IServerDll.Current;
			return serverDll != null && serverDll.UserVarFromClient(clientSlot, key, val);
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x0001F85C File Offset: 0x0001DA5C
		internal static void SimulateUI()
		{
			ThreadSafe.AssertIsMainThread("SimulateUI");
			using (Performance.Scope("Client Simulate UI"))
			{
				IClientDll current = IClientDll.Current;
				if (current != null)
				{
					current.SimulateUI();
				}
			}
			using (Performance.Scope("Menu Simulate UI"))
			{
				IMenuDll menuDll = IMenuDll.Current;
				if (menuDll != null)
				{
					menuDll.SimulateUI();
				}
			}
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x0001F8E0 File Offset: 0x0001DAE0
		internal static void Print(int severity, string logger, string message)
		{
			EngineLoop.partial += message;
			if (!EngineLoop.partial.Contains("\n"))
			{
				return;
			}
			if (EngineLoop.partial.EndsWith('\n'))
			{
				message = EngineLoop.partial;
				EngineLoop.partial = "";
			}
			else
			{
				int i = EngineLoop.partial.LastIndexOf('\n');
				message = EngineLoop.partial.Substring(0, i);
				EngineLoop.partial = EngineLoop.partial.Substring(i);
			}
			message = message.TrimEnd(new char[] { '\n', '\r' });
			if (severity == 0)
			{
				EngineLoop.nativeLogger.DoTrace(logger, FormattableStringFactory.Create("{0}", new object[] { message }));
				return;
			}
			if (severity == 1)
			{
				EngineLoop.nativeLogger.DoInfo(logger, FormattableStringFactory.Create("{0}", new object[] { message }));
				return;
			}
			if (severity == 2)
			{
				EngineLoop.nativeLogger.DoWarning(logger, FormattableStringFactory.Create("{0}", new object[] { message }));
				return;
			}
			EngineLoop.nativeLogger.DoError(logger, FormattableStringFactory.Create("{0}", new object[] { message }));
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x0001F9FD File Offset: 0x0001DBFD
		internal static void Print(bool debug, string message)
		{
			message = message.TrimEnd(new char[] { '\n', '\r' });
			if (debug)
			{
				EngineLoop.nativeLogger.Trace(message);
				return;
			}
			EngineLoop.nativeLogger.Info(message);
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x0001FA31 File Offset: 0x0001DC31
		internal static void LoadStart(string mapname)
		{
			ServerContext.GamemodeIdent = EngineGlue.GetConvarValue("gamemode");
			ServerContext.MapIdent = mapname;
			IServerDll serverDll = IServerDll.Current;
			if (serverDll == null)
			{
				return;
			}
			serverDll.ServerLoadStart();
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x0001FA57 File Offset: 0x0001DC57
		internal static bool LoadLoop()
		{
			IServerDll serverDll = IServerDll.Current;
			return serverDll != null && serverDll.ServerLoadLoop();
		}

		/// <summary>
		/// Called when we're ready to render the world for the first time.
		/// </summary>
		// Token: 0x060010EE RID: 4334 RVA: 0x0001FA69 File Offset: 0x0001DC69
		internal static void HideLoadingPlaque()
		{
			IMenuAddon.SetLoadingVisible(false);
		}

		// Token: 0x060010EF RID: 4335 RVA: 0x0001FA74 File Offset: 0x0001DC74
		internal static string ResolveMapName(string mapname)
		{
			if (mapname.StartsWith("/"))
			{
				string text = mapname;
				int length = text.Length;
				int num = 1;
				int num2 = length - num;
				mapname = text.Substring(num, num2);
			}
			if (mapname.StartsWith("maps/"))
			{
				string text2 = mapname;
				int length2 = text2.Length;
				int num2 = 5;
				int num = length2 - num2;
				mapname = text2.Substring(num2, num);
			}
			if (!mapname.Contains('.'))
			{
				return mapname;
			}
			return mapname.Split('.', 2, StringSplitOptions.None)[1];
		}

		// Token: 0x060010F0 RID: 4336 RVA: 0x0001FADD File Offset: 0x0001DCDD
		internal static void ClientDisconnect(NetworkDisconnectionReason reason, string strReason)
		{
			if (reason == NetworkDisconnectionReason.CLIENT_NO_MAP)
			{
				IMenuAddon.ShowServerError("Couldn't Find Map", "We couldn't find the map '" + strReason + "'. This is probably a problem with the package. If you're the author check out the console for the reason why it couldn't be loaded. If you're not the author please choose a different map.");
				return;
			}
			IServerDll serverDll = IServerDll.Current;
			if (serverDll == null)
			{
				return;
			}
			serverDll.LocalClientDisconnected();
		}

		/// <summary>
		/// Game is closing
		/// </summary>
		// Token: 0x060010F1 RID: 4337 RVA: 0x0001FB10 File Offset: 0x0001DD10
		internal static void Exiting()
		{
			GlobalSystemNamespace.Log.Info("EngineLoop::Exiting");
			IToolsDll toolsDll = IToolsDll.Current;
			if (toolsDll != null)
			{
				toolsDll.Exiting();
			}
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll != null)
			{
				menuDll.Exiting();
			}
			IClientDll current = IClientDll.Current;
			if (current != null)
			{
				current.Exiting();
			}
			IServerDll serverDll = IServerDll.Current;
			if (serverDll == null)
			{
				return;
			}
			serverDll.Exiting();
		}

		// Token: 0x060010F2 RID: 4338 RVA: 0x0001FB6B File Offset: 0x0001DD6B
		internal static void FrameStage(double time, GameLoopStage stage, bool start)
		{
			PerformanceStats.FrameStage(time, stage, start);
		}

		// Token: 0x040012A3 RID: 4771
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x040012A4 RID: 4772
		private static Logger nativeLogger = Logging.GetLogger("Native");

		// Token: 0x040012A5 RID: 4773
		private static string partial = "";
	}
}
