using System;
using Managed.SourceClient;
using NativeEngine;
using Sandbox.Engine;
using Sandbox.Internal;
using Sandbox.UI;
using SkiaSharp;

namespace Sandbox
{
	// Token: 0x02000007 RID: 7
	internal class ClientDll : ContextInterface, IClientDll, IBaseDll
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000021AC File Offset: 0x000003AC
		public ClientDll()
		{
			GlobalGameNamespace.Global.GameInterface = this;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000021C0 File Offset: 0x000003C0
		public override void Init()
		{
			GlobalGameNamespace.Global.Init();
			GameLoop.OnLoopStart += this.LoopStart;
			GameLoop.OnLoopEnd += this.LoopEnd;
			Library.AddAssembly(GlobalGameNamespace.Global.Assembly, null);
			ConsoleSystem.AddAssembly("Sandbox.Engine");
			ConsoleSystem.AddAssembly("Sandbox.System");
			ConsoleSystem.AddAssembly(GlobalGameNamespace.Global.Assembly);
			GlobalGameNamespace.Cookie = new CookieContainer("client");
			GlobalGameNamespace.Global.HotloadManager = new HotloadManager();
			GlobalGameNamespace.Global.HotloadManager.Watch(GlobalGameNamespace.Global.Assembly);
			GlobalGameNamespace.Global.HotloadManager.Watch(typeof(EventAttribute).Assembly);
			GlobalGameNamespace.Global.HotloadManager.Ignore<SKBitmap>();
			GlobalGameNamespace.Global.HotloadManager.OnSuccess += delegate()
			{
				Development.Notice("hotload", "\ud83d\udd25", "Client Hotloaded", 3, "success", null);
			};
			GlobalGameNamespace.Global.HotloadManager.OnSuccess += delegate()
			{
				Event.Run("hotloaded");
			};
			GlobalGameNamespace.Global.HotloadManager.OnFail += delegate()
			{
				Development.Notice("hotload", "\ud83d\udd25", "Hotload Failed", 3, "success", null);
			};
			GlobalGameNamespace.Global.HotloadManager.PreSwap += delegate()
			{
				GameAssemblyManager.UpdateHash();
			};
			Materials.Init();
			Texture.InitStaticTextures();
			Screen.UpdateFromEngine();
			FgdWriter.WriteForAssembly(EngineFileSystem.Root, "addons/base/config", "engine", GlobalGameNamespace.Global.Assembly);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002378 File Offset: 0x00000578
		public static void FilesystemInit()
		{
			DownloadedAssets.Init();
			AggFileSystem aggFileSystem = new AggFileSystem();
			aggFileSystem.Watch("*.*").OnChangedFile += ClientDll.OnClientFileChanged;
			FileSystem.Mounted = aggFileSystem;
			FileSystem.Mounted.Mount(DownloadedAssets.FileSystem);
			FileSystem.Mounted.CreateAndMount(EngineFileSystem.Root, "/core");
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000023D4 File Offset: 0x000005D4
		private static void OnClientFileChanged(string filename)
		{
			Texture.Hotload(FileSystem.Mounted, filename);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000023E1 File Offset: 0x000005E1
		public void RunCommandFromInputBuffer(int slot, string command)
		{
			ConsoleSystem.RunCommandFromInputBuffer(command);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000023E9 File Offset: 0x000005E9
		public override void Tick()
		{
			HotloadManager hotloadManager = GlobalGameNamespace.Global.HotloadManager;
			if (hotloadManager != null)
			{
				hotloadManager.Tick();
			}
			GlobalGameNamespace.Global.InGame = ClientEngine.IsInGame();
			ClientGlobal.SteamAPI_RunCallbacks();
			Controller.Tick(GlobalGameNamespace.Global.InGame);
			base.Tick();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002429 File Offset: 0x00000629
		public bool HandleInputEvent(InputEvent data)
		{
			return InputRouter.HandleInputEvent(data);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002431 File Offset: 0x00000631
		public void SimulateUI()
		{
			VROverlay.UpdateAll();
			UISystem.Simulate();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000243D File Offset: 0x0000063D
		public Vector3 WorldToScreen(Vector3 vector3)
		{
			return vector3.ToScreen();
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002445 File Offset: 0x00000645
		unsafe void IClientDll.InitInterop(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported)
		{
			NativeInterop.Initialize(hash, exported, struct_sizes, imported);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002451 File Offset: 0x00000651
		void IClientDll.InitNetworkGameClient(NetworkGameClient cl)
		{
			new NetworkClient(cl);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000245C File Offset: 0x0000065C
		void IClientDll.OnServerInfo(string game, string map)
		{
			string[] parts = game.Split('.', 2, StringSplitOptions.None);
			if (parts.Length == 2)
			{
				EngineFileSystem.Data.CreateDirectory(parts[0]);
				FileSystem.OrganizationData = EngineFileSystem.Data.CreateSubSystem(parts[0]);
				FileSystem.OrganizationData.CreateDirectory(parts[1]);
				FileSystem.Data = FileSystem.OrganizationData.CreateSubSystem(parts[1]);
				return;
			}
			if (parts.Length == 1)
			{
				EngineFileSystem.Data.CreateDirectory(".local");
				FileSystem.OrganizationData = EngineFileSystem.Data.CreateSubSystem(".local");
				FileSystem.OrganizationData.CreateDirectory(parts[0]);
				FileSystem.Data = FileSystem.OrganizationData.CreateSubSystem(parts[0]);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002504 File Offset: 0x00000704
		private void LoopStart()
		{
			GlobalGameNamespace.Reflection = new ReflectionSystem(GlobalGameNamespace.Log);
			GlobalGameNamespace.Reflection.AddStaticAssembly(GlobalGameNamespace.Global.Assembly);
			ClientDll.FilesystemInit();
			GameAssemblyManager.Init();
			Sound.ResetListener();
			VR.Init();
			Var.ClearWriteList();
			Prediction.Init();
			Precache.Init();
			StringPool.Init();
			Model.Init();
			WorldInputInternal.Clear();
			StyleSheet.InitStyleSheets();
			Template.Init();
			GameTask.Reset();
			GlobalGameNamespace.PostProcess = new PostProcessSystem();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002580 File Offset: 0x00000780
		private void LoopEnd()
		{
			ReflectionSystem reflection = GlobalGameNamespace.Reflection;
			if (reflection != null)
			{
				reflection.Shutdown();
			}
			GlobalGameNamespace.Reflection = null;
			GlobalGameNamespace.Cookie.StopTimer();
			GlobalGameNamespace.Cookie.Save();
			GameAssemblyManager.Shutdown();
			ClientDll.FilesystemInit();
			Sound.ResetListener();
			Var.ClearWriteList();
			Precache.ClearCache();
			Model.Init();
			WorldInputInternal.Clear();
			SpeechRecognition.Reset();
			VROverlay.DisposeAll();
			GameTask.Reset();
			TaskSource.OnSessionEnded();
		}
	}
}
