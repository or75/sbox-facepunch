using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using NativeEngine;
using NativeGlue;
using Sandbox.AddonProvision;
using Sandbox.Engine;
using Sandbox.Internal;
using Sentry;

namespace Sandbox
{
	// Token: 0x020000A7 RID: 167
	[Hotload.SkipAttribute]
	internal static class GameLoop
	{
		// Token: 0x17000226 RID: 550
		// (get) Token: 0x060010F8 RID: 4344 RVA: 0x000491E6 File Offset: 0x000473E6
		// (set) Token: 0x060010F9 RID: 4345 RVA: 0x000491ED File Offset: 0x000473ED
		[ConVar.ReplicatedAttribute("gamemode")]
		public static string CurrentGamemode { get; set; } = "facepunch.sandbox";

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x060010FA RID: 4346 RVA: 0x000491F8 File Offset: 0x000473F8
		// (remove) Token: 0x060010FB RID: 4347 RVA: 0x0004922C File Offset: 0x0004742C
		public static event Action OnLoopStart;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x060010FC RID: 4348 RVA: 0x00049260 File Offset: 0x00047460
		// (remove) Token: 0x060010FD RID: 4349 RVA: 0x00049294 File Offset: 0x00047494
		public static event Action OnLoopEnd;

		// Token: 0x060010FE RID: 4350 RVA: 0x000492C7 File Offset: 0x000474C7
		private static int CountBaseTypes(Type t, int i = 0)
		{
			if (t == null)
			{
				return i;
			}
			return GameLoop.CountBaseTypes(t.BaseType, i + 1);
		}

		// Token: 0x060010FF RID: 4351 RVA: 0x000492E4 File Offset: 0x000474E4
		internal static void Init()
		{
			if (GlobalGameNamespace.Global.InGame)
			{
				GameLoop.log.Warning("Init called but already InGame");
			}
			GlobalGameNamespace.Global.IsStartup = true;
			GlobalGameNamespace.Global.IsClosing = false;
			GlobalGameNamespace.Global.InGame = true;
			GlobalGameNamespace.Global.PhysicsTimeScale = 1f;
			GlobalGameNamespace.Global.PhysicsSubSteps = 1;
			GlobalGameNamespace.Global.TimeScale = 1f;
			GlobalGameNamespace.Global.TickRate = 50;
			Action onLoopStart = GameLoop.OnLoopStart;
			if (onLoopStart != null)
			{
				onLoopStart();
			}
			try
			{
				Event.Init(GlobalGameNamespace.Log);
				Event.RegisterAssembly(null, GlobalGameNamespace.Global.Assembly);
				if (Host.IsServer)
				{
					if (GameBase.Current != null)
					{
						GameLoop.log.Warning("GameBase.Current isn't null!?");
					}
					IMenuAddon.SetLoadingStatus("Server Startup", "Compiling Gamemode");
					string currentGamemode = GameLoop.CurrentGamemode;
					ServerAddons.SwitchGamemode(GameLoop.CurrentGamemode, false);
					Task<bool> task = ServerAddons.CompileAndHotloadAsync();
					task.Wait();
					if (!task.Result)
					{
						InputService.InsertCommand(InputCommandSource.ICS_SERVER, "disconnect\n", 0, 0);
						IMenuAddon.ShowServerError("Coding Error", "We got errors when compiling the gamemode. If you're the author check the console for details. If you're not the author maybe get in touch and let them know that their gamemode is broken.");
						GlobalGameNamespace.Global.InGame = false;
						GameBase.Current = null;
					}
					else
					{
						Asset.LoadAll();
						try
						{
							Type[] array = (from x in Library.GetAll<GameBase>()
								orderby GameLoop.CountBaseTypes(x, 0) descending
								where !x.IsAbstract
								select x).ToArray<Type>();
							if (array.Length == 0)
							{
								throw new Exception("Couldn't find a gamemode!");
							}
							GameBase.Current = Library.Create<GameBase>(array[0]);
						}
						catch (Exception e)
						{
							GameBase.Current = null;
							GameLoop.log.Warning(e, FormattableStringFactory.Create("Error creating gamemode", Array.Empty<object>()));
							InputService.InsertCommand(InputCommandSource.ICS_SERVER, "disconnect\n", 0, 0);
							IMenuAddon.ShowServerError("Coding Error", "There was an error creating the gamemode, check the console for more details.");
							GlobalGameNamespace.Global.InGame = false;
							return;
						}
						NetworkAssetList.Initialize();
						GameLobby.FindOrCreateAsync(ServerContext.GamemodeIdent, ServerContext.MapIdent);
						SentrySdk.ConfigureScope(delegate(Scope scope)
						{
							scope.SetTag("host", "1");
							scope.SetTag("game", ServerContext.GamemodeIdent);
							scope.SetTag("map", ServerContext.MapIdent);
							scope.SetTag("maxplayers", ConsoleSystem.GetValue("maxplayers", null));
						});
						IMenuAddon.SetLoadingStatus("Server Startup", "Loading Map");
					}
				}
				else
				{
					GameLoop.LastScreenResolution = Screen.Size;
					Event.Register(GlobalGameNamespace.PostProcess);
				}
			}
			finally
			{
				GlobalGameNamespace.Global.IsStartup = false;
				GC.Collect();
			}
		}

		/// <summary>
		/// Server: Right before map entity spawn
		/// </summary>
		// Token: 0x06001100 RID: 4352 RVA: 0x00049578 File Offset: 0x00047778
		internal static void PreOnActivate()
		{
		}

		/// <summary>
		/// Server: Right after map entity spawn
		/// </summary>
		// Token: 0x06001101 RID: 4353 RVA: 0x0004957A File Offset: 0x0004777A
		internal static void PostOnActivate()
		{
			GameBase gameBase = GameBase.Current;
			if (gameBase != null)
			{
				gameBase.PostLevelLoaded();
			}
			if (Host.IsServer)
			{
				GameLoop.PrecacheModels();
			}
		}

		// Token: 0x06001102 RID: 4354 RVA: 0x00049598 File Offset: 0x00047798
		internal static void OnModelReloaded(IModel mdl)
		{
			Model model = Model.Get(mdl);
			if (model == null)
			{
				return;
			}
			model.OnReloaded();
		}

		// Token: 0x06001103 RID: 4355 RVA: 0x000495AC File Offset: 0x000477AC
		internal static void PrecacheModels()
		{
			foreach (Model model in Model.Loaded.Values)
			{
				if (model != null && !model.IsError)
				{
					Precache.Add(model.Name);
					Resources.EnsureResourceInManifest(model.Name);
				}
			}
		}

		// Token: 0x06001104 RID: 4356 RVA: 0x00049620 File Offset: 0x00047820
		internal static void OnClientPostOutput()
		{
			Host.AssertClient("OnClientPostOutput");
		}

		// Token: 0x06001105 RID: 4357 RVA: 0x0004962C File Offset: 0x0004782C
		internal static void ClientPutInServer(int entityId, string name, bool fakePlayer)
		{
			Host.AssertServer("ClientPutInServer");
			try
			{
				if (GameBase.Current == null)
				{
					throw new Exception("Trying to put client in server but we have no gamemode!");
				}
				Entity.ForceNextEntityIndex = entityId;
				ClientEntity client = new ClientEntity();
				if (fakePlayer)
				{
					client.AddFlag(EntityFlag.FL_FAKECLIENT);
				}
				client.IsBot = fakePlayer;
				client.Name = name;
				Input.UpdateForClient(client);
				GameBase gameBase = GameBase.Current;
				if (gameBase != null)
				{
					gameBase.ClientJoined(client);
				}
			}
			finally
			{
				Input.Clear();
				Entity.ForceNextEntityIndex = -1;
			}
		}

		// Token: 0x06001106 RID: 4358 RVA: 0x000496B4 File Offset: 0x000478B4
		internal static void UpdateAudioListener(ref Transform tx)
		{
			Host.AssertClient("UpdateAudioListener");
			if (Sound.Listener != null)
			{
				Transform listener = Sound.Listener.Value;
				tx.Position = listener.Position;
				tx.Rotation = listener.Rotation;
			}
		}

		// Token: 0x06001107 RID: 4359 RVA: 0x00049700 File Offset: 0x00047900
		internal static void GetView(ref ViewDesc viewDesc)
		{
			Host.AssertClient("GetView");
			if (GameBase.Current != null && Local.Client != null)
			{
				CameraSetup camSetup = new CameraSetup(viewDesc);
				camSetup = GameBase.Current.BuildCamera(camSetup);
				camSetup.ToViewDesc(ref viewDesc);
				CurrentView.Position = camSetup.Position;
				CurrentView.Rotation = camSetup.Rotation;
				CurrentView.FieldOfView = camSetup.FieldOfView;
				CurrentView.IsOrtho = camSetup.Ortho;
				CurrentView.OrthoSize = camSetup.OrthoSize;
				CurrentView.Viewer = camSetup.Viewer;
			}
			if (SharedRendering.RenderRect.width > 0f && SharedRendering.RenderRect.height > 0f)
			{
				viewDesc.X = (int)SharedRendering.RenderRect.left;
				viewDesc.Width = (int)SharedRendering.RenderRect.width;
				viewDesc.Y = (int)SharedRendering.RenderRect.top;
				viewDesc.Height = (int)SharedRendering.RenderRect.height;
			}
		}

		// Token: 0x06001108 RID: 4360 RVA: 0x000497FA File Offset: 0x000479FA
		internal static void OnClientPreOutput()
		{
			Host.AssertClient("OnClientPreOutput");
			Event.Run("prerender");
		}

		// Token: 0x06001109 RID: 4361 RVA: 0x00049810 File Offset: 0x00047A10
		internal static void ClientDisconnected(int entityId, int intreason, string name, ulong steamid, string v2)
		{
			Event.Run("client.disconnect");
			GameServices.PlayerLeave((long)steamid);
			ClientEntity player = Entity.FindByIndex(entityId) as ClientEntity;
			if (player != null)
			{
				GameBase gameBase = GameBase.Current;
				if (gameBase == null)
				{
					return;
				}
				gameBase.ClientDisconnect(player, (NetworkDisconnectionReason)intreason);
			}
		}

		// Token: 0x0600110A RID: 4362 RVA: 0x0004984F File Offset: 0x00047A4F
		internal static void PreRender()
		{
			if (Host.IsServer)
			{
				Event.Run("frame");
			}
		}

		// Token: 0x0600110B RID: 4363 RVA: 0x00049862 File Offset: 0x00047A62
		internal static void PrePhysicsStep(float dt)
		{
			float delta = Time.Delta;
			Time.Delta = dt;
			Event.Run("physics.prestep");
			Time.Delta = delta;
		}

		// Token: 0x0600110C RID: 4364 RVA: 0x0004987E File Offset: 0x00047A7E
		internal static void PostPhysicsStep(float dt)
		{
			float delta = Time.Delta;
			Time.Delta = dt;
			Event.Run("physics.poststep");
			Time.Delta = delta;
		}

		// Token: 0x0600110D RID: 4365 RVA: 0x0004989C File Offset: 0x00047A9C
		internal static void PhysicsImpactSound(int entity, Vector3 pos, float volume, float speed, int surfaceIndex, int surfaceHitIndex)
		{
			volume = volume.Clamp(0f, 1f);
			if (surfaceIndex >= 0)
			{
				Surface.FindByIndex(surfaceIndex).OnPhysicsImpact(pos, volume, speed);
			}
			if (surfaceHitIndex >= 0)
			{
				Surface.FindByIndex(surfaceHitIndex).OnPhysicsImpact(pos + Vector3.Down * 20f, volume * 0.5f, speed);
			}
		}

		// Token: 0x0600110E RID: 4366 RVA: 0x000498FD File Offset: 0x00047AFD
		internal static void OnPhysicsJointBreak(PhysicsJoint joint)
		{
			if (joint.IsValid())
			{
				joint.OnBreak();
			}
		}

		// Token: 0x0600110F RID: 4367 RVA: 0x0004990D File Offset: 0x00047B0D
		internal static void PhysicsThink()
		{
			if (Host.IsServer)
			{
				MainThreadContext.PhysicsThinkServer.ProcessQueue();
			}
			if (Host.IsClient)
			{
				MainThreadContext.PhysicsThinkClient.ProcessQueue();
			}
		}

		// Token: 0x06001110 RID: 4368 RVA: 0x00049931 File Offset: 0x00047B31
		internal static void RunBotCommands()
		{
			Bot.RunAll();
		}

		// Token: 0x06001111 RID: 4369 RVA: 0x00049938 File Offset: 0x00047B38
		internal static void ServerFrame_Think()
		{
			HotloadManager hotloadManager = GlobalGameNamespace.Global.HotloadManager;
			if (hotloadManager != null)
			{
				hotloadManager.Tick();
			}
			Event.Run("tick");
			Event.Run("server.tick");
			GameLoop.SharedTick();
			Var.WriteAll();
		}

		// Token: 0x06001112 RID: 4370 RVA: 0x0004996D File Offset: 0x00047B6D
		internal static float Server_GetTimeScale()
		{
			return GlobalGameNamespace.Global.TimeScale;
		}

		// Token: 0x06001113 RID: 4371 RVA: 0x00049979 File Offset: 0x00047B79
		internal static float Server_GetTickRate()
		{
			return (float)GlobalGameNamespace.Global.TickRate;
		}

		// Token: 0x06001114 RID: 4372 RVA: 0x00049986 File Offset: 0x00047B86
		internal static void OnFrameSimulateStart()
		{
			Event.Run("preframe");
		}

		// Token: 0x06001115 RID: 4373 RVA: 0x00049992 File Offset: 0x00047B92
		internal static void OnFrameSimulateEnd()
		{
			Event.Run("frame");
		}

		// Token: 0x06001116 RID: 4374 RVA: 0x000499A0 File Offset: 0x00047BA0
		internal static void ClientFrame_Think()
		{
			HotloadManager hotloadManager = GlobalGameNamespace.Global.HotloadManager;
			if (hotloadManager != null)
			{
				hotloadManager.Tick();
			}
			GlobalGameNamespace.Global.TimeScale = EngineGlue.GetConvarValueFloat("host_timescale", 1f);
			GlobalGameNamespace.Global._tickrate = (int)(1f / ClientGlobalVars.interval_per_tick);
			Vector2 screenResolution = Screen.Size;
			if (GameLoop.LastScreenResolution != screenResolution)
			{
				GameLoop.LastScreenResolution = screenResolution;
				Event.Run("screen.size.changed");
			}
			Event.Run("tick");
			Event.Run("client.tick");
			GameLoop.SharedTick();
		}

		// Token: 0x06001117 RID: 4375 RVA: 0x00049A2D File Offset: 0x00047C2D
		internal static void PostEntitySpawn()
		{
			Event.Run("entity.postspawn");
		}

		// Token: 0x06001118 RID: 4376 RVA: 0x00049A3C File Offset: 0x00047C3C
		private static void SharedTick()
		{
			float physicsTime = GlobalGameNamespace.Global.TickInterval * GlobalGameNamespace.Global.PhysicsTimeScale / (float)GlobalGameNamespace.Global.PhysicsSubSteps;
			PhysicsGameSystem.InitSubSteps(GlobalGameNamespace.Global.PhysicsSubSteps.Clamp(1, 1000), physicsTime);
		}

		/// <summary>
		/// The last thing that is ever called.
		/// This is right at the end after everything has been destroyed.
		/// </summary>
		// Token: 0x06001119 RID: 4377 RVA: 0x00049A86 File Offset: 0x00047C86
		internal static void LoopShutdown()
		{
			GameLoop.DoShutdown();
		}

		// Token: 0x0600111A RID: 4378 RVA: 0x00049A8D File Offset: 0x00047C8D
		internal static void OnDeactivate()
		{
			GameLoop.DoShutdown();
		}

		/// <summary>
		/// Called to clear the state. Because of spagetti code this is probably called in 4
		/// different places when disconnecting from a server.
		/// </summary>
		// Token: 0x0600111B RID: 4379 RVA: 0x00049A94 File Offset: 0x00047C94
		internal static void DoShutdown()
		{
			GlobalGameNamespace.Global.IsClosing = true;
			GlobalGameNamespace.Global.InGame = false;
			MainThreadContext instance = MainThreadContext.Instance;
			if (instance != null)
			{
				instance.ProcessQueue();
			}
			try
			{
				GameBase gameBase = GameBase.Current;
				if (gameBase != null)
				{
					gameBase.Shutdown();
				}
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
			}
			FullFileSystem.ClearSymLinks();
			GlobalGameNamespace.Global.GameInterface.OnShutdown();
			EntityManager.Shutdown();
			UISystem.DeleteAllRoots();
			GameBase.Current = null;
			NetworkAssetList.Shutdown();
			Asset.Clear();
			SearchPath.Clear();
			Content.Clear();
			BaseAddonProvider.ClearCache();
			Action onLoopEnd = GameLoop.OnLoopEnd;
			if (onLoopEnd != null)
			{
				onLoopEnd();
			}
			MainThreadContext instance2 = MainThreadContext.Instance;
			if (instance2 != null)
			{
				instance2.ProcessQueue();
			}
			MainThreadContext.Reset();
			SentrySdk.ConfigureScope(delegate(Scope scope)
			{
				scope.SetTag("host", "0");
				scope.SetTag("game", "");
				scope.SetTag("map", "");
				scope.SetTag("maxplayers", "0");
			});
		}

		/// <summary>
		/// Called when the local client was disconnected from the current server for any reason.
		/// </summary>
		// Token: 0x0600111C RID: 4380 RVA: 0x00049B80 File Offset: 0x00047D80
		internal static void NotifyDisconnect(int reasonCode, string reasonStr)
		{
			GameLobby.Leave();
			if (reasonCode == 2)
			{
				return;
			}
			string title = "Disconnected";
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(40, 2);
			defaultInterpolatedStringHandler.AppendLiteral("You were disconnected from the server.\n\n");
			defaultInterpolatedStringHandler.AppendFormatted<NetworkDisconnectionReason>((NetworkDisconnectionReason)reasonCode);
			defaultInterpolatedStringHandler.AppendFormatted(string.IsNullOrEmpty(reasonStr) ? "" : ("\n\nReason: " + reasonStr));
			IMenuAddon.ShowServerError(title, defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x040002EB RID: 747
		private static readonly Logger log = Logging.GetLogger(null);

		// Token: 0x040002EE RID: 750
		private static Vector2 LastScreenResolution = Vector2.Zero;
	}
}
