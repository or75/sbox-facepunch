using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Managed.SourceClient;
using Managed.SourceMenu;
using NativeEngine;
using Sandbox.Engine;
using Sandbox.Internal;
using Sandbox.UI;
using Sandbox.Utility;
using Sentry;
using SkiaSharp;
using Steamworks;

namespace Sandbox
{
	// Token: 0x0200000B RID: 11
	internal class MenuDll : ContextInterface, IMenuDll, IBaseDll
	{
		// Token: 0x0600001F RID: 31 RVA: 0x00002AE4 File Offset: 0x00000CE4
		public MenuDll()
		{
			GlobalGameNamespace.Global.GameInterface = this;
			AggFileSystem AddonCode = new AggFileSystem();
			AddonCode.CreateAndMount(EngineFileSystem.Addons, "/base/code");
			AddonCode.CreateAndMount(EngineFileSystem.Addons, "/menu/code");
			GameAssemblyManager.Init();
			MenuDll.Compiler = new Compiler("menu_composite", AddonCode);
			MenuDll.Compiler.References.Add("Sandbox.Menu");
			MenuDll.Compiler.GlobalNamespaces.Add("static Sandbox.Internal.GlobalGameNamespace");
			AddonCode.Watch("*.cs").OnChanges += delegate(FileWatch w)
			{
				this.RecompileMenu();
			};
			MenuDll.Compiler.Build();
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002B90 File Offset: 0x00000D90
		public override void Init()
		{
			GroupTiming time = new GroupTiming();
			using (time.Record("Hotload Init"))
			{
				GlobalGameNamespace.Global.HotloadManager = new HotloadManager();
				GlobalGameNamespace.Global.HotloadManager.Watch(GlobalGameNamespace.Global.Assembly);
				GlobalGameNamespace.Global.HotloadManager.Watch(typeof(EventAttribute).Assembly);
				GlobalGameNamespace.Global.HotloadManager.Ignore<SKBitmap>();
			}
			using (time.Record("Library.AddAssembly"))
			{
				GlobalGameNamespace.Reflection = new ReflectionSystem(GlobalGameNamespace.Log);
				GlobalGameNamespace.Reflection.AddStaticAssembly(GlobalGameNamespace.Global.Assembly);
				Library.AddAssembly(GlobalGameNamespace.Global.Assembly, null);
			}
			using (time.Record("ConsoleSystem.AddAssembly"))
			{
				ConsoleSystem.AddAssembly("Sandbox.Engine");
				ConsoleSystem.AddAssembly("Sandbox.System");
				ConsoleSystem.AddAssembly(GlobalGameNamespace.Global.Assembly);
				ConsoleSystem.AddAssembly(typeof(MenuDll).Assembly);
			}
			using (time.Record("Screen.UpdateFromEngine"))
			{
				Screen.UpdateFromEngine();
			}
			using (time.Record("Materials.Init"))
			{
				Materials.Init();
				Texture.InitStaticTextures();
			}
			using (time.Record("Init Steam"))
			{
				ClientGlobal.SteamClientInit();
				SteamClient.Init(590830);
				AccountInformation.Update();
			}
			using (time.Record("Init Steam Input"))
			{
				Controller.Init();
			}
			using (time.Record("Global.Init"))
			{
				GlobalGameNamespace.Global.Init();
			}
			using (time.Record("Cookie.Load"))
			{
				GlobalGameNamespace.Cookie = new CookieContainer("menu");
			}
			using (time.Record("LoopEvent.Init"))
			{
				GameAssemblyManager.Init();
				Sound.ResetListener();
				VR.Init();
				Var.ClearWriteList();
				Prediction.Init();
				Precache.Init();
				StringPool.Init();
				Model.Init();
				StyleSheet.InitStyleSheets();
				Template.Init();
				GameTask.Reset();
			}
			Lobby.InitSteamCallbacks();
			using (time.Record("InitAsync"))
			{
				MenuDll.InitAsync();
			}
		}

		/// <summary>
		/// Wait for compile to finish and then load the menu
		/// </summary>
		// Token: 0x06000021 RID: 33 RVA: 0x00002E78 File Offset: 0x00001078
		internal static async Task InitAsync()
		{
			Host.AssertMenu("InitAsync");
			try
			{
				if (IMenuAddon.Current != null)
				{
					GlobalGameNamespace.Log.Info("Aready inited?");
				}
				else
				{
					while (MenuDll.Compiler.Building)
					{
						IToolsDll toolsDll = IToolsDll.Current;
						if (toolsDll != null)
						{
							toolsDll.SetStatus("Building Menu..");
						}
						await Task.Delay(5);
					}
					if (!MenuDll.Compiler.BuildSuccess)
					{
						IToolsDll toolsDll2 = IToolsDll.Current;
						if (toolsDll2 != null)
						{
							toolsDll2.SetStatus("Menu Build Failed!");
						}
						EngineGlobal.Plat_MessageBox("Menu Compile Errors", string.Join("\n", from x in MenuDll.Compiler.GetErrors()
							select x.Replace("\r", "")));
						throw new Exception("Menu didn't compile. Can't continue.");
					}
					IToolsDll toolsDll3 = IToolsDll.Current;
					if (toolsDll3 != null)
					{
						toolsDll3.SetStatus("Loading Menu..");
					}
					List<string> errorsWL = new List<string>();
					if (!GameAssemblyManager.ForceLoadCompiler(MenuDll.Compiler, errorsWL))
					{
						EngineGlobal.Plat_MessageBox("Menu Load Error", "Couldn't load menu assembly\n\n" + string.Join("\n", errorsWL.Select((string x) => x.Replace("\r", "").Insert(0, "Not in whitelist: "))));
						throw new Exception("Menu couldn't load. Can't continue.");
					}
					IToolsDll toolsDll4 = IToolsDll.Current;
					if (toolsDll4 != null)
					{
						toolsDll4.SetStatus("Loading Assets..");
					}
					Asset.LoadAll();
					IMenuAddon.Current = Library.Create<IMenuAddon>("MenuSystem", true);
					if (IMenuAddon.Current == null)
					{
						EngineGlobal.Plat_MessageBox("Menu Load Error", "Couldn't create MenuSystem!");
						throw new Exception("Menu couldn't load. Can't continue.");
					}
					if (IMenuAddon.Current != null)
					{
						IToolsDll toolsDll5 = IToolsDll.Current;
						if (toolsDll5 != null)
						{
							toolsDll5.SetStatus("Creating Menu..");
						}
						IMenuAddon menuAddon = IMenuAddon.Current;
						if (menuAddon != null)
						{
							menuAddon.Init();
						}
					}
					IToolsDll toolsDll6 = IToolsDll.Current;
					if (toolsDll6 != null)
					{
						toolsDll6.SetStatus("Ready!");
					}
				}
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002EB3 File Offset: 0x000010B3
		public void RunCommandFromInputBuffer(int slot, string command)
		{
			ConsoleSystem.RunCommandFromInputBuffer(command);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002EBB File Offset: 0x000010BB
		public override void Tick()
		{
			GlobalGameNamespace.Global.InGame = ClientEngine.IsInGame();
			ClientGlobal.SteamAPI_RunCallbacks();
			Time.Update(RealTime.Now, RealTime.Delta, 0);
			Controller.Tick(GlobalGameNamespace.Global.InGame);
			base.Tick();
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002EF8 File Offset: 0x000010F8
		public void UpdateProgressBar(LevelLoadingProgress e)
		{
			if (e == LevelLoadingProgress.SPAWNSERVER)
			{
				IMenuAddon.SetLoadingStatus("Server Startup", "Spawning Server");
				return;
			}
			switch (e)
			{
			case LevelLoadingProgress.CREATENETWORKSTRINGTABLES:
				IMenuAddon.SetLoadingStatus("Server Startup", "Compiling");
				return;
			case LevelLoadingProgress.PRECACHEWORLD:
			case LevelLoadingProgress.CLEARWORLD:
			case LevelLoadingProgress.PRECACHE:
			case LevelLoadingProgress.BEGINCONNECT:
			case LevelLoadingProgress.SIGNONCONNECT:
			case LevelLoadingProgress.PROCESSSTRINGTABLE:
			case LevelLoadingProgress.SIGNONNEW:
			case LevelLoadingProgress.SENDSIGNONDATA:
			case LevelLoadingProgress.SIGNONSPAWN:
				return;
			case LevelLoadingProgress.LEVELINIT:
				IMenuAddon.SetLoadingStatus("Server Startup", "Level Init");
				return;
			case LevelLoadingProgress.ACTIVATESERVER:
				IMenuAddon.SetLoadingStatus("Client Startup", "Entering Server");
				return;
			case LevelLoadingProgress.SIGNONCHALLENGE:
				IMenuAddon.SetLoadingStatus("Client Startup", "Connecting");
				return;
			case LevelLoadingProgress.SIGNONCONNECTED:
				IMenuAddon.SetLoadingStatus("Client Startup", "Connected");
				return;
			case LevelLoadingProgress.PROCESSSERVERINFO:
				IMenuAddon.SetLoadingStatus("Client Startup", "Got Server Info");
				return;
			case LevelLoadingProgress.SENDCLIENTINFO:
				IMenuAddon.SetLoadingStatus("Client Startup", "Sending Client Info");
				return;
			case LevelLoadingProgress.CREATEENTITIES:
				IMenuAddon.SetLoadingStatus("Client Startup", "Create Entities");
				return;
			case LevelLoadingProgress.FULLYCONNECTED:
				IMenuAddon.SetLoadingStatus("Client Startup", "Funny Collected");
				return;
			case LevelLoadingProgress.PRECACHELIGHTING:
				IMenuAddon.SetLoadingStatus("Client Startup", "Precache Lighting");
				return;
			case LevelLoadingProgress.READYTOPLAY:
				IMenuAddon.SetLoadingStatus("Client Startup", "Ready To Play");
				return;
			default:
				return;
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00003022 File Offset: 0x00001222
		public void ShowMenu(bool show)
		{
			IMenuAddon menuAddon = IMenuAddon.Current;
			if (menuAddon == null)
			{
				return;
			}
			menuAddon.SetMenuScreen(show);
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00003034 File Offset: 0x00001234
		public void StartConnecting()
		{
			IMenuAddon.SetLoadingVisible(true);
			IMenuAddon.SetLoadingStatus("Connecting", "");
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000304B File Offset: 0x0000124B
		public void UpdateLoading(string status)
		{
			IMenuAddon menuAddon = IMenuAddon.Current;
			if (menuAddon == null)
			{
				return;
			}
			menuAddon.OnLoadProgress(0f, status, "", "");
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000306C File Offset: 0x0000126C
		public void SwitchToMainuMenu()
		{
			this.ShowMenu(true);
			IMenuAddon.SetLoadingVisible(false);
			SteamFriends.SetRichPresence("steam_display", "#StatusMenu");
			SteamFriends.SetRichPresence("gametitle", "menu");
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000309B File Offset: 0x0000129B
		public void OnLevelLoadingFinished()
		{
			IMenuAddon.SetLoadingVisible(false);
			this.ShowMenu(false);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000030AA File Offset: 0x000012AA
		public bool HandleInputEvent(InputEvent data)
		{
			return InputRouter.HandleInputEvent(data);
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000030B2 File Offset: 0x000012B2
		public void SimulateUI()
		{
			VROverlay.UpdateAll();
			UISystem.Simulate();
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000030C0 File Offset: 0x000012C0
		private async Task RecompileMenu()
		{
			Development.Notice("menu_compiler", "\ud83e\udd28", "Compiling Menu", 30, "working", null);
			await MenuDll.Compiler.Build();
			if (!MenuDll.Compiler.BuildSuccess)
			{
				Development.Notice("menu_compiler", "\ud83d\udc80", "Menu Compile Failed", 60, "error", string.Join("\n\n", MenuDll.Compiler.GetErrors()));
			}
			else
			{
				Development.Notice("menu_compiler", "\ud83d\ude0d", "Compiling Menu", 3, "success", null);
				GameAssemblyManager.ForceLoadCompiler(MenuDll.Compiler, null);
				GlobalGameNamespace.Global.HotloadManager.DoSwap();
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x000030FC File Offset: 0x000012FC
		internal static void RenderUI()
		{
			Host.AssertMenu("RenderUI");
			Hotload hotload = GlobalGameNamespace.Global.HotloadManager.Hotload;
			lock (hotload)
			{
				Event.Run("frame");
				Render.SetSamplerStatePS(0, FilterMode.Linear, TextureAddressMode.Clamp, TextureAddressMode.Clamp, TextureAddressMode.Wrap, ComparisonMode.Less);
				UISystem.Render();
				VROverlay.RenderAll();
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x0000316C File Offset: 0x0000136C
		[MenuCmd("menu_reload")]
		public static void Recreate()
		{
			IMenuAddon menuAddon = IMenuAddon.Current;
			if (menuAddon != null)
			{
				menuAddon.Shutdown();
			}
			IMenuAddon menuAddon2 = IMenuAddon.Current;
			if (menuAddon2 == null)
			{
				return;
			}
			menuAddon2.Init();
		}

		/// <summary>
		/// A command has been run. We have to route it like this from the client instance.
		/// </summary>
		// Token: 0x0600002F RID: 47 RVA: 0x0000318D File Offset: 0x0000138D
		public void DispatchCommand(string name, string args, long flaglong, int client)
		{
			ConsoleSystem.RunCommand(name, args, (CommandFlags)flaglong, client);
		}

		// Token: 0x06000030 RID: 48 RVA: 0x0000319C File Offset: 0x0000139C
		public void OnServerInfo(string gameIdent, string mapIdent)
		{
			GlobalGameNamespace.Global.MapName = mapIdent;
			GlobalGameNamespace.Global.GameName = gameIdent;
			SentrySdk.ConfigureScope(delegate(Scope scope)
			{
				scope.SetTag("host", GlobalGameNamespace.Global.IsListenServer ? "1" : "0");
				scope.SetTag("game", gameIdent);
				scope.SetTag("map", mapIdent);
			});
		}

		// Token: 0x06000031 RID: 49 RVA: 0x000031EE File Offset: 0x000013EE
		internal static void BlockStart(ISceneView view, IRenderContext context, ISceneLayer layer)
		{
			Render.RenderingBlockOpen(view, context, layer);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000031F8 File Offset: 0x000013F8
		internal static void BlockEnd()
		{
			Render.RenderingBlockClose();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000031FF File Offset: 0x000013FF
		unsafe void IMenuDll.InitInterop_Client(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported)
		{
			NativeInterop.Initialize(hash, exported, struct_sizes, imported);
		}

		// Token: 0x06000034 RID: 52 RVA: 0x0000320B File Offset: 0x0000140B
		unsafe void IMenuDll.InitInterop_Menu(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported)
		{
			NativeInterop.Initialize(hash, exported, struct_sizes, imported);
		}

		// Token: 0x0400000A RID: 10
		public static Compiler Compiler;
	}
}
