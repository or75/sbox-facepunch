using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Managed.SourceServer;
using NativeEngine;
using Sandbox.AddonProvision;
using Sandbox.Engine;
using Sandbox.Internal;
using Sandbox.UI;
using SkiaSharp;

namespace Sandbox
{
	// Token: 0x02000007 RID: 7
	internal class ServerDll : ContextInterface, IServerDll, IBaseDll
	{
		// Token: 0x0600001A RID: 26 RVA: 0x0000263C File Offset: 0x0000083C
		public ServerDll()
		{
			GlobalGameNamespace.Global.GameInterface = this;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002650 File Offset: 0x00000850
		public override void Init()
		{
			GlobalGameNamespace.Global.Init();
			GameLoop.OnLoopStart += this.LoopStart;
			GameLoop.OnLoopEnd += this.LoopEnd;
			Library.AddAssembly(GlobalGameNamespace.Global.Assembly, null);
			ConsoleSystem.AddAssembly("Sandbox.Engine");
			ConsoleSystem.AddAssembly("Sandbox.System");
			ConsoleSystem.AddAssembly(GlobalGameNamespace.Global.Assembly);
			GlobalGameNamespace.Global.HotloadManager = new HotloadManager();
			GlobalGameNamespace.Global.HotloadManager.Watch(GlobalGameNamespace.Global.Assembly);
			GlobalGameNamespace.Global.HotloadManager.Watch(typeof(EventAttribute).Assembly);
			GlobalGameNamespace.Global.HotloadManager.Ignore<SKBitmap>();
			GlobalGameNamespace.Global.HotloadManager.OnSuccess += delegate()
			{
				Event.Run("hotloaded");
			};
			GlobalGameNamespace.Global.HotloadManager.PreSwap += delegate()
			{
				GameAssemblyManager.UpdateHash();
			};
		}

		// Token: 0x0600001C RID: 28 RVA: 0x0000276D File Offset: 0x0000096D
		internal override void OnShutdown()
		{
			base.OnShutdown();
			ServerAddons.ClearTransients();
			ServerAddons.DeactivateAll();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000277F File Offset: 0x0000097F
		public override void Tick()
		{
			base.Tick();
		}

		/// <summary>
		/// Called when a batch of compilers are compiled.
		/// </summary>
		// Token: 0x0600001E RID: 30 RVA: 0x00002788 File Offset: 0x00000988
		public async Task<bool> OnAddonsCompiled(Compiler[] compiled)
		{
			Host.AssertServer("OnAddonsCompiled");
			Compiler[] array = compiled;
			for (int i = 0; i < array.Length; i++)
			{
				using (MemoryStream dll_stream = new MemoryStream(array[i].AsmBinary))
				{
					if (!GameAssemblyManager.TestAccessControl(dll_stream, null))
					{
						return false;
					}
				}
			}
			await Task.Delay(5);
			foreach (Compiler compiler in compiled)
			{
				using (MemoryStream dll_stream2 = new MemoryStream(compiler.AsmBinary))
				{
					using (MemoryStream pdb_stream = new MemoryStream(compiler.SymBinary))
					{
						if (!GameAssemblyManager.OnAssembly(compiler.Name, dll_stream2, pdb_stream))
						{
							return false;
						}
					}
				}
			}
			await Task.Delay(5);
			GameAssemblyManager.UpdateHash();
			HotloadManager hotloadManager = GlobalGameNamespace.Global.HotloadManager;
			if (hotloadManager != null)
			{
				hotloadManager.DoSwap();
			}
			array = compiled;
			for (int i = 0; i < array.Length; i++)
			{
				this.AddAssemblyTransport(array[i]);
			}
			return true;
		}

		/// <summary>
		/// Add this assembly to the string table, which will send it to the client
		/// </summary>
		// Token: 0x0600001F RID: 31 RVA: 0x000027D4 File Offset: 0x000009D4
		private unsafe void AddAssemblyTransport(Compiler compiler)
		{
			if (!GlobalGameNamespace.Global.InGame)
			{
				return;
			}
			using (MemoryStream stream = new MemoryStream(32768))
			{
				AssemblyTransport.Write(stream, compiler);
				stream.Position = 0L;
				void* ptr = Unsafe.AsPointer<byte>(ref stream.GetBuffer()[0]);
				StringTables.Assemblies.SetWithData(compiler.Name, ptr, (int)stream.Length);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002850 File Offset: 0x00000A50
		public bool UserVarFromClient(int clientSlot, string key, string val)
		{
			ClientEntity.InternalSetUserVar(clientSlot + 1, key, val);
			return true;
		}

		/// <summary>
		/// Server is starting to load, kick it off
		/// </summary>
		// Token: 0x06000021 RID: 33 RVA: 0x00002860 File Offset: 0x00000A60
		public void ServerLoadStart()
		{
			FileSystem.Mounted = EngineFileSystem.ServerInit();
			GlobalGameNamespace.Global.MapName = ServerContext.MapIdent;
			GlobalGameNamespace.Global.GameName = ServerContext.GamemodeIdent;
			base.InitGamemodeData(GlobalGameNamespace.Global.GameName);
			IMenuAddon.SetLoadingVisible(true);
			this.ServerLoadTask = this.ServerLoad();
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000028B8 File Offset: 0x00000AB8
		private async Task<bool> ServerLoad()
		{
			this.downloadTokenSource = new CancellationTokenSource();
			TaskAwaiter<bool> taskAwaiter = Utility.FindAndDownloadGamemode(ServerContext.GamemodeIdent, this.downloadTokenSource.Token).GetAwaiter();
			TaskAwaiter<bool> taskAwaiter2;
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<bool>);
			}
			bool result;
			if (!taskAwaiter.GetResult())
			{
				IMenuAddon.ShowServerError("Couldn't Load Game", "There was a problem downloading the game " + ServerContext.GamemodeIdent + ". Check out the console for more information.");
				result = false;
			}
			else if (this.downloadTokenSource.IsCancellationRequested)
			{
				result = false;
			}
			else
			{
				taskAwaiter = Utility.FindAndDownloadMap(ServerContext.MapIdent, this.downloadTokenSource.Token).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter<bool>);
				}
				if (!taskAwaiter.GetResult())
				{
					IMenuAddon.ShowServerError("Couldn't Load Map", "There was a problem loading the map " + ServerContext.MapIdent + ". Check out the console for more information.");
					result = false;
				}
				else if (this.downloadTokenSource.IsCancellationRequested)
				{
					result = false;
				}
				else
				{
					this.downloadTokenSource.Dispose();
					this.downloadTokenSource = null;
					result = true;
				}
			}
			return result;
		}

		/// <summary>
		/// Server is loading, return true to finish loading
		/// </summary>
		// Token: 0x06000023 RID: 35 RVA: 0x000028FC File Offset: 0x00000AFC
		public bool ServerLoadLoop()
		{
			if (this.ServerLoadTask != null)
			{
				if (!this.ServerLoadTask.IsCompleted)
				{
					return false;
				}
				if (!this.ServerLoadTask.IsCompletedSuccessfully || !this.ServerLoadTask.Result)
				{
					if (this.ServerLoadTask.Exception != null)
					{
						GlobalGameNamespace.Log.Error(this.ServerLoadTask.Exception);
					}
					this.ServerLoadTask = null;
					InputService.InsertCommand(InputCommandSource.ICS_SERVER, "disconnect\n", 0, 0);
					return false;
				}
				this.ServerLoadTask = null;
			}
			IMenuAddon.SetLoadingStatus("Server Startup", "Init");
			return true;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00002989 File Offset: 0x00000B89
		public void LocalClientDisconnected()
		{
			CancellationTokenSource cancellationTokenSource = this.downloadTokenSource;
			if (cancellationTokenSource == null)
			{
				return;
			}
			cancellationTokenSource.Cancel();
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000299C File Offset: 0x00000B9C
		private void LoopStart()
		{
			GlobalGameNamespace.Reflection = new ReflectionSystem(GlobalGameNamespace.Log);
			GlobalGameNamespace.Reflection.AddStaticAssembly(GlobalGameNamespace.Global.Assembly);
			GameAssemblyManager.Init();
			Sound.ResetListener();
			Var.ClearWriteList();
			Prediction.Init();
			Precache.Init();
			StringPool.Init();
			Model.Init();
			WorldInputInternal.Clear();
			StyleSheet.InitStyleSheets();
			Template.Init();
			GameTask.Reset();
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002A03 File Offset: 0x00000C03
		private void LoopEnd()
		{
			GameAssemblyManager.Shutdown();
			Sound.ResetListener();
			Var.ClearWriteList();
			Precache.ClearCache();
			Model.Init();
			WorldInputInternal.Clear();
			GameTask.Reset();
			TaskSource.OnSessionEnded();
			ReflectionSystem reflection = GlobalGameNamespace.Reflection;
			if (reflection != null)
			{
				reflection.Shutdown();
			}
			GlobalGameNamespace.Reflection = null;
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00002A43 File Offset: 0x00000C43
		unsafe void IServerDll.InteropInit(int hash, IntPtr* exported, int* struct_sizes, IntPtr* imported)
		{
			NativeInterop.Initialize(hash, exported, struct_sizes, imported);
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00002A4F File Offset: 0x00000C4F
		void IServerDll.InitServerSideClient(ServerSideClient sl)
		{
			new NetworkServer(sl);
		}

		// Token: 0x04000008 RID: 8
		private Task<bool> ServerLoadTask;

		// Token: 0x04000009 RID: 9
		private CancellationTokenSource downloadTokenSource;
	}
}
