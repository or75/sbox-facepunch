using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using NativeEngine;
using Sandbox.AddonProvision;
using Sandbox.Engine;
using Sandbox.Internal;
using Steamworks;

namespace Sandbox
{
	/// <summary>
	/// A Clientside Client-&gt;Server connection. This exists before the player
	/// or anything else and exists for the duration of the connection to the server.
	/// </summary>
	// Token: 0x0200000A RID: 10
	internal class NetworkClient : INetworkClient
	{
		/// <summary>
		/// Called during connection. The client looks at the Assets table and decides whether they should
		/// download any files.
		/// </summary>
		// Token: 0x06000028 RID: 40 RVA: 0x000027A8 File Offset: 0x000009A8
		private async Task<bool> DownloadContent(CancellationToken cancelToken)
		{
			bool result;
			try
			{
				if (((this.ServerInfo != null) ? this.ServerInfo.GetValueOrDefault().RequiredContent : null) == null)
				{
					GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("ServerInfo?.RequiredContent was null.. this shouldn't happen", Array.Empty<object>()));
					result = false;
				}
				else
				{
					foreach (string item in this.ServerInfo.Value.RequiredContent)
					{
						await this.DownloadContent(item, cancelToken);
					}
					string[] array = null;
					result = true;
				}
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Warning(e, "Error when downloading content");
				result = false;
			}
			return result;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000027F4 File Offset: 0x000009F4
		private async Task<bool> DownloadContent(string ident, CancellationToken cancelToken)
		{
			Package package = await Package.Fetch(ident, false);
			Package assetInfo = package;
			bool result;
			if (assetInfo == null)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't get info for {0}", new object[] { ident }));
				result = false;
			}
			else if (assetInfo.Download == null)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Asset info {0} was missing download information", new object[] { ident }));
				result = false;
			}
			else
			{
				IMenuAddon.SetLoadingStatus("Downloading Content", "Downloading '" + ident + "'");
				BaseAddonProvider provider = BaseAddonProvider.FindProvider(assetInfo.Download.Type, assetInfo.Download.Url, new BaseAddonProvider.ProgressDelegate(IMenuAddon.DownloadProgressCallback));
				if (provider == null)
				{
					GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Couldn't find provider for {0} to download \"{1}\"", new object[]
					{
						ident,
						assetInfo.Download.Type
					}));
					result = false;
				}
				else
				{
					await Task.Delay(16);
					BaseFileSystem filesystem = await provider.Download(cancelToken);
					if (filesystem == null)
					{
						GlobalGameNamespace.Log.Trace(FormattableStringFactory.Create("Failed to download {0} type \"{1}\"", new object[]
						{
							ident,
							assetInfo.Download.Type
						}));
						result = false;
					}
					else
					{
						if ((new Content(filesystem) != null = 
						{
							Ident = assetInfo.FullIdent
						}) == null)
						{
							filesystem.Dispose();
						}
						await Task.Delay(16);
						result = true;
					}
				}
			}
			return result;
		}

		/// <summary>
		/// If true then we've completed sign on and are in the game
		/// </summary>
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600002A RID: 42 RVA: 0x0000283F File Offset: 0x00000A3F
		// (set) Token: 0x0600002B RID: 43 RVA: 0x00002847 File Offset: 0x00000A47
		internal bool Ready { get; private set; }

		// Token: 0x0600002C RID: 44 RVA: 0x00002850 File Offset: 0x00000A50
		public NetworkClient(NetworkGameClient cl)
		{
			Host.AssertClient(".ctor");
			InteropSystem.Alloc<NetworkClient>(this);
			this.native = cl;
			this.native.SetManaged(this);
		}

		/// <summary>
		/// Called on disconnect
		/// </summary>
		// Token: 0x0600002D RID: 45 RVA: 0x00002888 File Offset: 0x00000A88
		public void Shutdown()
		{
			Host.AssertClient("Shutdown");
			Task.Run(() => Api.CloseActivity());
			InteropSystem.Free<NetworkClient>(this);
			this.native = IntPtr.Zero;
			CancellationTokenSource cancellationTokenSource = this.downloadTokenSource;
			if (cancellationTokenSource != null)
			{
				cancellationTokenSource.Cancel();
			}
			this.DownloadingFiles.Clear();
			GameLoop.DoShutdown();
		}

		// Token: 0x0600002E RID: 46 RVA: 0x000028FB File Offset: 0x00000AFB
		public void OnFullConnect(string address)
		{
		}

		/// <summary>
		/// Send this value to the server
		/// </summary>
		// Token: 0x0600002F RID: 47 RVA: 0x00002900 File Offset: 0x00000B00
		internal unsafe void Send<[IsUnmanaged] T>(NetMsgType type, T o) where T : struct, ValueType
		{
			void* ptr = Unsafe.AsPointer<T>(ref o);
			this.native.SendCustomMessage((int)type, (IntPtr)ptr, sizeof(T));
		}

		/// <summary>
		/// Send a message of this type to the server
		/// </summary>
		// Token: 0x06000030 RID: 48 RVA: 0x0000292D File Offset: 0x00000B2D
		internal unsafe void Send(NetMsgType type, void* data, int length)
		{
			this.native.SendCustomMessage((int)type, (IntPtr)data, length);
		}

		/// <summary>
		/// Send a JSON message to the server
		/// </summary>
		// Token: 0x06000031 RID: 49 RVA: 0x00002944 File Offset: 0x00000B44
		internal unsafe void SendJson<T>(NetMsgType type, T o)
		{
			byte[] bytes = JsonSerializer.SerializeToUtf8Bytes<T>(o, null);
			void* ptr = Unsafe.AsPointer<byte>(ref bytes[0]);
			this.native.SendCustomMessage((int)type, (IntPtr)ptr, bytes.Length);
		}

		/// <summary>
		/// Called when receiving a message from the server
		/// </summary>
		// Token: 0x06000032 RID: 50 RVA: 0x0000297C File Offset: 0x00000B7C
		public unsafe void OnNet(int type, IntPtr data, int len)
		{
			Span<byte> span = new Span<byte>((void*)data, len);
			switch (type)
			{
			case 2:
				this.NetMsg_FileStart(span);
				return;
			case 3:
				this.NetMsg_FileChunk(span);
				return;
			case 4:
				return;
			case 5:
				this.NetMsg_VoiceData(span);
				return;
			default:
				return;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000029CC File Offset: 0x00000BCC
		public void SignOnState_New(bool playingDemo, bool isListenServer)
		{
			this.Ready = true;
			GlobalGameNamespace.Global.IsPlayingDemo = playingDemo;
			GlobalGameNamespace.Global.IsListenServer = isListenServer;
			FileSystem.Mounted.WatchEnabled = false;
			foreach (string addonName in this.ServerInfo.Value.MountedAddons)
			{
				foreach (BaseFileSystem path in ServerAddons.FindAddonPaths(addonName))
				{
					FileSystem.Mounted.Mount(path);
				}
			}
			this.JoinTask = this.JoinAsync();
			ConsoleSystem.SendUserVars();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002A9C File Offset: 0x00000C9C
		public async Task<bool> JoinAsync()
		{
			this.downloadTokenSource = new CancellationTokenSource();
			IMenuAddon.SetLoadingStatus("Downloading Content", "");
			TaskAwaiter<bool> taskAwaiter = this.DownloadContent(this.downloadTokenSource.Token).GetAwaiter();
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
				result = false;
			}
			else
			{
				if (GlobalGameNamespace.Global.IsListenServer)
				{
					FileSystem.Mounted.Mount(EngineFileSystem.Server);
				}
				if (!GlobalGameNamespace.Global.IsPlayingDemo && !GlobalGameNamespace.Global.IsListenServer)
				{
					IMenuAddon.SetLoadingStatus("Downloading Files", "");
					await this.RequestAnyFiles(this.downloadTokenSource.Token);
					while (this.DownloadingFiles.Count > 0)
					{
						await Task.Delay(10);
					}
				}
				this.downloadTokenSource.Dispose();
				this.downloadTokenSource = null;
				IMenuAddon.SetLoadingStatus("Precache", "");
				await Task.Delay(20);
				if (this.native.IsNull)
				{
					result = false;
				}
				else
				{
					Precache.ClientConnected();
					IMenuAddon.SetLoadingStatus("Signing On", "");
					await Task.Delay(20);
					if (this.native.IsNull)
					{
						result = false;
					}
					else
					{
						FileSystem.Mounted.WatchEnabled = true;
						GameAssemblyManager.ClientSignonFull();
						this.native.FinishSignonState_New();
						ClientEngine.FlashWindow();
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002ADF File Offset: 0x00000CDF
		public void SignOnState_Full()
		{
			Host.AssertClient("SignOnState_Full");
			HotloadManager hotloadManager = GlobalGameNamespace.Global.HotloadManager;
			if (hotloadManager != null)
			{
				hotloadManager.Tick();
			}
			Asset.LoadAll();
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002B08 File Offset: 0x00000D08
		public void Tick()
		{
			if (!this.Ready)
			{
				return;
			}
			if (this.JoinTask == null)
			{
				this.TryUpdateActivity();
				this.VoiceRead();
				return;
			}
			if (!this.JoinTask.IsCompleted)
			{
				return;
			}
			if (!this.JoinTask.IsCompletedSuccessfully || !this.JoinTask.Result)
			{
				GlobalGameNamespace.Log.Warning(this.JoinTask.Exception, "Joining failed, disconnecting...");
				InputService.InsertCommand(InputCommandSource.ICS_SERVER, "disconnect\n", 0, 0);
			}
			this.JoinTask = null;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002B8C File Offset: 0x00000D8C
		private unsafe void VoiceRead()
		{
			if (!SteamUser.HasVoiceData)
			{
				return;
			}
			byte[] voiceData = SteamUser.ReadVoiceDataBytes();
			if (voiceData == null || voiceData.Length == 0)
			{
				return;
			}
			if (!Voice.Enabled)
			{
				return;
			}
			void* ptr = Unsafe.AsPointer<byte>(ref voiceData[0]);
			this.Send(NetMsgType.VoiceData, ptr, voiceData.Length);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002BD0 File Offset: 0x00000DD0
		private void NetMsg_VoiceData(Span<byte> span)
		{
			if (span == null || span.Length <= 8)
			{
				return;
			}
			long steamId = MemoryMarshal.Read<long>(span);
			if (!GlobalGameNamespace.Global.IsPlayingDemo && steamId == Local.PlayerId && !Voice.Loopback)
			{
				return;
			}
			Span<byte> span2 = span;
			int length = span2.Length;
			int num = 8;
			int length2 = length - num;
			span = span2.Slice(num, length2);
			Voice.Play(steamId, span, true);
		}

		/// <summary>
		/// The server has sent information about itself. Return false if we shouldn't connect.
		/// </summary>
		// Token: 0x06000039 RID: 57 RVA: 0x00002C40 File Offset: 0x00000E40
		public bool ProcessServerInfo(string manifest, string mapname)
		{
			if (string.IsNullOrEmpty(manifest))
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Manifest was empty - can't join this server", Array.Empty<object>()));
				return false;
			}
			this.ServerInfo = new ServerInfo?(JsonSerializer.Deserialize<ServerInfo>(manifest, null));
			GlobalGameNamespace.Global.MapName = this.ServerInfo.Value.MapIdent;
			GlobalGameNamespace.Global.GameName = this.ServerInfo.Value.GameIdent;
			IClientDll current = IClientDll.Current;
			if (current != null)
			{
				current.OnServerInfo(GlobalGameNamespace.Global.GameName, GlobalGameNamespace.Global.MapName);
			}
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll != null)
			{
				menuDll.OnServerInfo(GlobalGameNamespace.Global.GameName, GlobalGameNamespace.Global.MapName);
			}
			this.UpdateActivity(true);
			return true;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002D0C File Offset: 0x00000F0C
		internal void TryUpdateActivity()
		{
			if (this.timeSinceUpdatedActivity < 300f)
			{
				return;
			}
			this.UpdateActivity(false);
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002D28 File Offset: 0x00000F28
		internal void UpdateActivity(bool initial)
		{
			if (this.ServerInfo == null)
			{
				return;
			}
			this.timeSinceUpdatedActivity = 0f;
			Task.Run(() => Api.UpdateActivity(this.ServerInfo.Value.GameIdent, this.ServerInfo.Value.MapIdent, initial));
		}

		/// <summary>
		/// Called during connection. The client looks at the Assets table and decides whether they should
		/// download any files.
		/// </summary>
		// Token: 0x0600003C RID: 60 RVA: 0x00002D7C File Offset: 0x00000F7C
		private async Task<bool> RequestAnyFiles(CancellationToken cancelToken)
		{
			bool isListenServer = GlobalGameNamespace.Global.IsListenServer;
			bool result;
			if (false)
			{
				GlobalGameNamespace.Log.Info("Skipping Downloads - we're a the listen server host");
				result = false;
			}
			else
			{
				int stringCount = StringTables.Assets.Count();
				StringTables.Assets.OnStringAddedOrChanged = new Action<int>(this.OnFileChanged);
				bool requested = false;
				List<Task<int>> tasks = new List<Task<int>>();
				for (int i = 0; i < stringCount; i++)
				{
					tasks.Add(this.ShouldRequestFile(i));
				}
				await Task.WhenAll<int>(tasks);
				if (!this.native.IsValid)
				{
					throw new TaskCanceledException();
				}
				this.DownloadingFiles.AddRange(from x in tasks
					select x.Result into x
					where x >= 0
					select x);
				int[] array = this.DownloadingFiles.ToArray();
				for (int j = 0; j < array.Length; j++)
				{
					this.Send<int>(NetMsgType.RequestFile, array[j]);
					await Task.Delay(100);
					if (!this.native.IsValid)
					{
						throw new TaskCanceledException();
					}
				}
				array = null;
				result = requested;
			}
			return result;
		}

		/// <summary>
		/// Called when a value changes in the Assets string table. This means
		/// that the CRC of a file has changed or been added.
		/// </summary>
		// Token: 0x0600003D RID: 61 RVA: 0x00002DBF File Offset: 0x00000FBF
		private void OnFileChanged(int index)
		{
			if (!this.native.IsValid)
			{
				return;
			}
			this.Send<int>(NetMsgType.RequestFile, index);
		}

		/// <summary>
		/// Checks for the existing file and returns a positive value if
		/// we should request this file.
		/// </summary>
		// Token: 0x0600003E RID: 62 RVA: 0x00002DD8 File Offset: 0x00000FD8
		private async Task<int> ShouldRequestFile(int i)
		{
			string str = StringTables.Assets.GetString(i);
			NetworkAssetList.AssetData data = StringTables.Assets.GetData<NetworkAssetList.AssetData>(i);
			uint crc = await FileSystem.Mounted.GetCRC(str);
			int result;
			if (crc == data.Crc)
			{
				result = -1;
			}
			else
			{
				string cacheName = DownloadedAssets.GetCacheName(str, data.Crc);
				crc = await EngineFileSystem.DownloadedFiles.GetCRC(cacheName);
				if (crc == data.Crc)
				{
					this.FlagDownloadedFile(str, EngineFileSystem.DownloadedFiles.GetFullPath(cacheName));
					await DownloadedAssets.AddFileAsync(str, cacheName);
					result = -1;
				}
				else
				{
					if (crc > 0U)
					{
						GlobalGameNamespace.Log.Info(FormattableStringFactory.Create("Requesting file {0} (crc different to one on disk {1} vs {2})", new object[] { str, crc, data.Crc }));
					}
					result = i;
				}
			}
			return result;
		}

		/// <summary>
		/// Server has started sending a file from the server.
		/// </summary>
		// Token: 0x0600003F RID: 63 RVA: 0x00002E24 File Offset: 0x00001024
		private void NetMsg_FileStart(Span<byte> span)
		{
			int fileid = MemoryMarshal.Read<int>(span);
			if (this.FileRecv != null)
			{
				throw new Exception("FileRecv isn't null!");
			}
			NetworkAssetList.AssetData data = StringTables.Assets.GetData<NetworkAssetList.AssetData>(fileid);
			this.FileRecv = new FileRecv();
			this.FileRecv.Id = fileid;
			this.FileRecv.Filename = StringTables.Assets.GetString(fileid);
			this.FileRecv.CRC = data.Crc;
			this.FileRecv.TotalSize = data.Size;
			this.FileRecv.Start = DateTime.Now;
			string title = null;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(27, 2);
			defaultInterpolatedStringHandler.AppendLiteral("Downloading '");
			defaultInterpolatedStringHandler.AppendFormatted(this.FileRecv.Filename);
			defaultInterpolatedStringHandler.AppendLiteral("' (");
			defaultInterpolatedStringHandler.AppendFormatted<int>(this.DownloadingFiles.Count);
			defaultInterpolatedStringHandler.AppendLiteral(" Remaining)");
			IMenuAddon.SetLoadingStatus(title, defaultInterpolatedStringHandler.ToStringAndClear());
			NetworkClient.log.Info(FormattableStringFactory.Create("Downloading '{0}' ({1})", new object[]
			{
				this.FileRecv.Filename,
				this.FileRecv.TotalSize.FormatBytes(false)
			}));
		}

		/// <summary>
		/// Got a file chunk from the server
		/// </summary>
		// Token: 0x06000040 RID: 64 RVA: 0x00002F58 File Offset: 0x00001158
		private void NetMsg_FileChunk(Span<byte> span)
		{
			if (this.FileRecv == null)
			{
				throw new Exception("FileRecv Is null!");
			}
			this.FileRecv.OnChunk(span);
			IMenuAddon.DownloadProgressCallback(this.FileRecv.DownloadedSize, (long)((ulong)this.FileRecv.TotalSize));
			if (this.FileRecv.IsComplete)
			{
				this.DownloadingFiles.Remove(this.FileRecv.Id);
				TimeSpan taken = DateTime.Now - this.FileRecv.Start;
				double megabitspersecond = this.FileRecv.TotalSize / taken.TotalSeconds / 1024.0 / 1024.0 * 8.0;
				NetworkClient.log.Info(FormattableStringFactory.Create("\t- '{0}' ({1:0.00}Mbps)", new object[]
				{
					this.FileRecv.Filename,
					megabitspersecond
				}));
				this.FlagDownloadedFile(StringTables.Assets.GetString(this.FileRecv.Id), EngineFileSystem.DownloadedFiles.GetFullPath(DownloadedAssets.GetCacheName(this.FileRecv.Filename, this.FileRecv.CRC)));
				this.FileRecv = null;
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00003089 File Offset: 0x00001289
		private void FlagDownloadedFile(string path, string cacheName)
		{
			if (!GlobalGameNamespace.Global.IsListenServer)
			{
				FullFileSystem.AddSymLink(path, "GAME", cacheName);
			}
		}

		// Token: 0x0400000C RID: 12
		private static readonly Logger log = Logging.GetLogger(null);

		// Token: 0x0400000D RID: 13
		private NetworkGameClient native;

		// Token: 0x0400000E RID: 14
		private ServerInfo? ServerInfo;

		// Token: 0x0400000F RID: 15
		internal FileRecv FileRecv;

		// Token: 0x04000011 RID: 17
		private Task<bool> JoinTask;

		// Token: 0x04000012 RID: 18
		private CancellationTokenSource downloadTokenSource;

		// Token: 0x04000013 RID: 19
		private RealTimeSince timeSinceUpdatedActivity;

		// Token: 0x04000014 RID: 20
		private List<int> DownloadingFiles = new List<int>();
	}
}
