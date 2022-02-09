using System;
using System.Runtime.InteropServices;
using NativeEngine;
using Sandbox;
using Sandbox.Engine;

namespace Managed.SandboxEngine
{
	// Token: 0x020001ED RID: 493
	internal static class Exports
	{
		/// <summary>
		/// Sandbox.Engine.Bootstrap.PreInit( ... )
		/// </summary>
		// Token: 0x06000C61 RID: 3169 RVA: 0x00011BB8 File Offset: 0x0000FDB8
		[UnmanagedCallersOnly]
		internal static int SandboEngine_Btstrp_PreInit(IntPtr gameFolder, int isDedicatedServer, int isRetail, int toolsMode)
		{
			int result;
			try
			{
				result = (Bootstrap.PreInit(Interop.GetString(gameFolder), isDedicatedServer != 0, isRetail != 0, toolsMode != 0) ? 1 : 0);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Engine.Bootstrap", "PreInit", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.Engine.Bootstrap.Init( ... )
		/// </summary>
		// Token: 0x06000C62 RID: 3170 RVA: 0x00011C0C File Offset: 0x0000FE0C
		[UnmanagedCallersOnly]
		internal static int SandboEngine_Btstrp_Init()
		{
			int result;
			try
			{
				result = (Bootstrap.Init() ? 1 : 0);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.Engine.Bootstrap", "Init", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.EngineLoop.EnterMainMenu( ... )
		/// </summary>
		// Token: 0x06000C63 RID: 3171 RVA: 0x00011C50 File Offset: 0x0000FE50
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_EnterMainMenu()
		{
			try
			{
				EngineLoop.EnterMainMenu();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "EnterMainMenu", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.LeaveMainMenu( ... )
		/// </summary>
		// Token: 0x06000C64 RID: 3172 RVA: 0x00011C88 File Offset: 0x0000FE88
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_LeaveMainMenu()
		{
			try
			{
				EngineLoop.LeaveMainMenu();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "LeaveMainMenu", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.EnterGame( ... )
		/// </summary>
		// Token: 0x06000C65 RID: 3173 RVA: 0x00011CC0 File Offset: 0x0000FEC0
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_EnterGame()
		{
			try
			{
				EngineLoop.EnterGame();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "EnterGame", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.LeaveGame( ... )
		/// </summary>
		// Token: 0x06000C66 RID: 3174 RVA: 0x00011CF8 File Offset: 0x0000FEF8
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_LeaveGame()
		{
			try
			{
				EngineLoop.LeaveGame();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "LeaveGame", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.ShowGameUI( ... )
		/// </summary>
		// Token: 0x06000C67 RID: 3175 RVA: 0x00011D30 File Offset: 0x0000FF30
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_ShowGameUI()
		{
			try
			{
				EngineLoop.ShowGameUI();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "ShowGameUI", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.HideGameUI( ... )
		/// </summary>
		// Token: 0x06000C68 RID: 3176 RVA: 0x00011D68 File Offset: 0x0000FF68
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_HideGameUI()
		{
			try
			{
				EngineLoop.HideGameUI();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "HideGameUI", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.FrameStart( ... )
		/// </summary>
		// Token: 0x06000C69 RID: 3177 RVA: 0x00011DA0 File Offset: 0x0000FFA0
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_FrameStart()
		{
			try
			{
				EngineLoop.FrameStart();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "FrameStart", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.FrameEnd( ... )
		/// </summary>
		// Token: 0x06000C6A RID: 3178 RVA: 0x00011DD8 File Offset: 0x0000FFD8
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_FrameEnd()
		{
			try
			{
				EngineLoop.FrameEnd();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "FrameEnd", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.FrameStage( ... )
		/// </summary>
		// Token: 0x06000C6B RID: 3179 RVA: 0x00011E10 File Offset: 0x00010010
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_FrameStage(double time, long stage, int start)
		{
			try
			{
				EngineLoop.FrameStage(time, (GameLoopStage)stage, start != 0);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "FrameStage", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.PreInput( ... )
		/// </summary>
		// Token: 0x06000C6C RID: 3180 RVA: 0x00011E50 File Offset: 0x00010050
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_PreInput()
		{
			try
			{
				EngineLoop.PreInput();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "PreInput", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.PostInput( ... )
		/// </summary>
		// Token: 0x06000C6D RID: 3181 RVA: 0x00011E88 File Offset: 0x00010088
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_PostInput()
		{
			try
			{
				EngineLoop.PostInput();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "PostInput", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.InitNetworkGameClient( ... )
		/// </summary>
		// Token: 0x06000C6E RID: 3182 RVA: 0x00011EC0 File Offset: 0x000100C0
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_InitNetworkGameClient(IntPtr cl)
		{
			try
			{
				EngineLoop.InitNetworkGameClient(cl);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "InitNetworkGameClient", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.InitServerSideClient( ... )
		/// </summary>
		// Token: 0x06000C6F RID: 3183 RVA: 0x00011F00 File Offset: 0x00010100
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_InitServerSideClient(IntPtr sl)
		{
			try
			{
				EngineLoop.InitServerSideClient(sl);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "InitServerSideClient", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.StartConnecting( ... )
		/// </summary>
		// Token: 0x06000C70 RID: 3184 RVA: 0x00011F40 File Offset: 0x00010140
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_StartConnecting()
		{
			try
			{
				EngineLoop.StartConnecting();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "StartConnecting", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.UpdateProgressBar( ... )
		/// </summary>
		// Token: 0x06000C71 RID: 3185 RVA: 0x00011F78 File Offset: 0x00010178
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_UpdateProgressBar(long progress)
		{
			try
			{
				EngineLoop.UpdateProgressBar((LevelLoadingProgress)progress);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "UpdateProgressBar", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.HandleInputEvent( ... )
		/// </summary>
		// Token: 0x06000C72 RID: 3186 RVA: 0x00011FB4 File Offset: 0x000101B4
		[UnmanagedCallersOnly]
		internal static int Sandbo_EngneL_HandleInputEvent(InputEvent ie)
		{
			int result;
			try
			{
				result = (EngineLoop.HandleInputEvent(ie) ? 1 : 0);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "HandleInputEvent", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.EngineLoop.ConvarFromClient( ... )
		/// </summary>
		// Token: 0x06000C73 RID: 3187 RVA: 0x00011FF8 File Offset: 0x000101F8
		[UnmanagedCallersOnly]
		internal static int Sandbo_EngneL_ConvarFromClient(int clientSlot, IntPtr name, IntPtr val)
		{
			int result;
			try
			{
				result = (EngineLoop.ConvarFromClient(clientSlot, Interop.GetString(name), Interop.GetString(val)) ? 1 : 0);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "ConvarFromClient", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.EngineLoop.SimulateUI( ... )
		/// </summary>
		// Token: 0x06000C74 RID: 3188 RVA: 0x00012048 File Offset: 0x00010248
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_SimulateUI()
		{
			try
			{
				EngineLoop.SimulateUI();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "SimulateUI", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.Print( ... )
		/// </summary>
		// Token: 0x06000C75 RID: 3189 RVA: 0x00012080 File Offset: 0x00010280
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_Print(int severitty, IntPtr logger, IntPtr message)
		{
			try
			{
				EngineLoop.Print(severitty, Interop.GetString(logger), Interop.GetString(message));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "Print", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.LoadStart( ... )
		/// </summary>
		// Token: 0x06000C76 RID: 3190 RVA: 0x000120C4 File Offset: 0x000102C4
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_LoadStart(IntPtr mapname)
		{
			try
			{
				EngineLoop.LoadStart(Interop.GetString(mapname));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "LoadStart", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.LoadLoop( ... )
		/// </summary>
		// Token: 0x06000C77 RID: 3191 RVA: 0x00012104 File Offset: 0x00010304
		[UnmanagedCallersOnly]
		internal static int Sandbo_EngneL_LoadLoop()
		{
			int result;
			try
			{
				result = (EngineLoop.LoadLoop() ? 1 : 0);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "LoadLoop", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.EngineLoop.HideLoadingPlaque( ... )
		/// </summary>
		// Token: 0x06000C78 RID: 3192 RVA: 0x00012148 File Offset: 0x00010348
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_HideLoadingPlaque()
		{
			try
			{
				EngineLoop.HideLoadingPlaque();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "HideLoadingPlaque", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.ResolveMapName( ... )
		/// </summary>
		// Token: 0x06000C79 RID: 3193 RVA: 0x00012180 File Offset: 0x00010380
		[UnmanagedCallersOnly]
		internal static IntPtr Sandbo_EngneL_ResolveMapName(IntPtr mapname)
		{
			IntPtr result;
			try
			{
				result = Interop.GetPointer(EngineLoop.ResolveMapName(Interop.GetString(mapname)));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "ResolveMapName", ___e);
				result = (IntPtr)0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.EngineLoop.ClientDisconnect( ... )
		/// </summary>
		// Token: 0x06000C7A RID: 3194 RVA: 0x000121C8 File Offset: 0x000103C8
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_ClientDisconnect(long reason, IntPtr strReason)
		{
			try
			{
				EngineLoop.ClientDisconnect((NetworkDisconnectionReason)reason, Interop.GetString(strReason));
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "ClientDisconnect", ___e);
			}
		}

		/// <summary>
		/// Sandbox.EngineLoop.Exiting( ... )
		/// </summary>
		// Token: 0x06000C7B RID: 3195 RVA: 0x00012208 File Offset: 0x00010408
		[UnmanagedCallersOnly]
		internal static void Sandbo_EngneL_Exiting()
		{
			try
			{
				EngineLoop.Exiting();
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.EngineLoop", "Exiting", ___e);
			}
		}

		/// <summary>
		/// Sandbox.INetworkClient.Shutdown( ... )
		/// </summary>
		// Token: 0x06000C7C RID: 3196 RVA: 0x00012240 File Offset: 0x00010440
		[UnmanagedCallersOnly]
		internal static void Sandbo_INetwr_Shutdown(uint self)
		{
			try
			{
				INetworkClient instance;
				if (InteropSystem.TryGetObject<INetworkClient>(self, out instance))
				{
					instance.Shutdown();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkClient", "Shutdown", ___e);
			}
		}

		/// <summary>
		/// Sandbox.INetworkClient.OnFullConnect( ... )
		/// </summary>
		// Token: 0x06000C7D RID: 3197 RVA: 0x00012284 File Offset: 0x00010484
		[UnmanagedCallersOnly]
		internal static void Sandbo_INetwr_OnFullConnect(uint self, IntPtr address)
		{
			try
			{
				INetworkClient instance;
				if (InteropSystem.TryGetObject<INetworkClient>(self, out instance))
				{
					instance.OnFullConnect(Interop.GetString(address));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkClient", "OnFullConnect", ___e);
			}
		}

		/// <summary>
		/// Sandbox.INetworkClient.OnNet( ... )
		/// </summary>
		// Token: 0x06000C7E RID: 3198 RVA: 0x000122D0 File Offset: 0x000104D0
		[UnmanagedCallersOnly]
		internal static void Sandbo_INetwr_OnNet(uint self, int type, IntPtr data, int len)
		{
			try
			{
				INetworkClient instance;
				if (InteropSystem.TryGetObject<INetworkClient>(self, out instance))
				{
					instance.OnNet(type, data, len);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkClient", "OnNet", ___e);
			}
		}

		/// <summary>
		/// Sandbox.INetworkClient.ProcessServerInfo( ... )
		/// </summary>
		// Token: 0x06000C7F RID: 3199 RVA: 0x00012318 File Offset: 0x00010518
		[UnmanagedCallersOnly]
		internal static int Sandbo_INetwr_ProcessServerInfo(uint self, IntPtr manifest, IntPtr mapname)
		{
			int result;
			try
			{
				INetworkClient instance;
				if (!InteropSystem.TryGetObject<INetworkClient>(self, out instance))
				{
					result = 0;
				}
				else
				{
					result = (instance.ProcessServerInfo(Interop.GetString(manifest), Interop.GetString(mapname)) ? 1 : 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkClient", "ProcessServerInfo", ___e);
				result = 0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.INetworkClient.SignOnState_New( ... )
		/// </summary>
		// Token: 0x06000C80 RID: 3200 RVA: 0x00012374 File Offset: 0x00010574
		[UnmanagedCallersOnly]
		internal static void Sandbo_INetwr_SignOnState_New(uint self, int playingDemo, int isListenServer)
		{
			try
			{
				INetworkClient instance;
				if (InteropSystem.TryGetObject<INetworkClient>(self, out instance))
				{
					instance.SignOnState_New(playingDemo != 0, isListenServer != 0);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkClient", "SignOnState_New", ___e);
			}
		}

		/// <summary>
		/// Sandbox.INetworkClient.SignOnState_Full( ... )
		/// </summary>
		// Token: 0x06000C81 RID: 3201 RVA: 0x000123C0 File Offset: 0x000105C0
		[UnmanagedCallersOnly]
		internal static void Sandbo_INetwr_SignOnState_Full(uint self)
		{
			try
			{
				INetworkClient instance;
				if (InteropSystem.TryGetObject<INetworkClient>(self, out instance))
				{
					instance.SignOnState_Full();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkClient", "SignOnState_Full", ___e);
			}
		}

		/// <summary>
		/// Sandbox.INetworkClient.Tick( ... )
		/// </summary>
		// Token: 0x06000C82 RID: 3202 RVA: 0x00012404 File Offset: 0x00010604
		[UnmanagedCallersOnly]
		internal static void Sandbo_INetwr_Tick(uint self)
		{
			try
			{
				INetworkClient instance;
				if (InteropSystem.TryGetObject<INetworkClient>(self, out instance))
				{
					instance.Tick();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkClient", "Tick", ___e);
			}
		}

		/// <summary>
		/// Sandbox.INetworkServer.Shutdown( ... )
		/// </summary>
		// Token: 0x06000C83 RID: 3203 RVA: 0x00012448 File Offset: 0x00010648
		[UnmanagedCallersOnly]
		internal static void Sandbo_INetwr_f2(uint self)
		{
			try
			{
				INetworkServer instance;
				if (InteropSystem.TryGetObject<INetworkServer>(self, out instance))
				{
					instance.Shutdown();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkServer", "Shutdown", ___e);
			}
		}

		/// <summary>
		/// Sandbox.INetworkServer.OnNet( ... )
		/// </summary>
		// Token: 0x06000C84 RID: 3204 RVA: 0x0001248C File Offset: 0x0001068C
		[UnmanagedCallersOnly]
		internal static void Sandbo_INetwr_f3(uint self, int type, IntPtr data, int len)
		{
			try
			{
				INetworkServer instance;
				if (InteropSystem.TryGetObject<INetworkServer>(self, out instance))
				{
					instance.OnNet(type, data, len);
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkServer", "OnNet", ___e);
			}
		}

		/// <summary>
		/// Sandbox.INetworkServer.Tick( ... )
		/// </summary>
		// Token: 0x06000C85 RID: 3205 RVA: 0x000124D4 File Offset: 0x000106D4
		[UnmanagedCallersOnly]
		internal static void Sandbo_INetwr_f4(uint self)
		{
			try
			{
				INetworkServer instance;
				if (InteropSystem.TryGetObject<INetworkServer>(self, out instance))
				{
					instance.Tick();
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkServer", "Tick", ___e);
			}
		}

		/// <summary>
		/// Sandbox.INetworkServer.FillServerInfo( ... )
		/// </summary>
		// Token: 0x06000C86 RID: 3206 RVA: 0x00012518 File Offset: 0x00010718
		[UnmanagedCallersOnly]
		internal static IntPtr Sandbo_INetwr_FillServerInfo(uint self, IntPtr mapname)
		{
			IntPtr result;
			try
			{
				INetworkServer instance;
				if (!InteropSystem.TryGetObject<INetworkServer>(self, out instance))
				{
					result = (IntPtr)0;
				}
				else
				{
					result = Interop.GetPointer(instance.FillServerInfo(Interop.GetString(mapname)));
				}
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.INetworkServer", "FillServerInfo", ___e);
				result = (IntPtr)0;
			}
			return result;
		}

		/// <summary>
		/// Sandbox.RealTime.Update( ... )
		/// </summary>
		// Token: 0x06000C87 RID: 3207 RVA: 0x00012570 File Offset: 0x00010770
		[UnmanagedCallersOnly]
		internal static void Sandbo_RelTme_Update(float time)
		{
			try
			{
				RealTime.Update(time);
			}
			catch (Exception ___e)
			{
				Interop.BindingException("Sandbox.RealTime", "Update", ___e);
			}
		}
	}
}
