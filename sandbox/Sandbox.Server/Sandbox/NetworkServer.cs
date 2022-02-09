using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;
using NativeEngine;
using Sandbox.Engine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000006 RID: 6
	internal class NetworkServer : INetworkServer
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000009 RID: 9 RVA: 0x00002203 File Offset: 0x00000403
		public string ClientName
		{
			get
			{
				if (!this.native.IsNull)
				{
					return this.native.GetClientName();
				}
				return "NULL";
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002223 File Offset: 0x00000423
		public int SessionId
		{
			get
			{
				if (!this.native.IsNull)
				{
					return this.native.GetUserId();
				}
				return -1;
			}
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000223F File Offset: 0x0000043F
		public NetworkServer(ServerSideClient cl)
		{
			InteropSystem.Alloc<NetworkServer>(this);
			this.native = cl;
			this.native.SetManaged(this);
			INetworkServer.All.Add(this);
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002276 File Offset: 0x00000476
		public void Shutdown()
		{
			FileSend fileTransfer = this.FileTransfer;
			if (fileTransfer != null)
			{
				fileTransfer.Dispose();
			}
			this.FileTransfer = null;
			InteropSystem.Free<NetworkServer>(this);
			this.native = IntPtr.Zero;
			INetworkServer.All.Remove(this);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x000022B2 File Offset: 0x000004B2
		internal unsafe void Send(NetMsgType type, void* data, int length)
		{
			this.native.SendCustomMessage((int)type, (IntPtr)data, length);
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000022C8 File Offset: 0x000004C8
		internal unsafe void Send<[IsUnmanaged] T>(NetMsgType type, T o) where T : struct, ValueType
		{
			void* ptr = Unsafe.AsPointer<T>(ref o);
			this.Send(type, ptr, sizeof(T));
		}

		// Token: 0x0600000F RID: 15 RVA: 0x000022EC File Offset: 0x000004EC
		internal unsafe void SendJson<T>(NetMsgType type, T o)
		{
			byte[] bytes = JsonSerializer.SerializeToUtf8Bytes<T>(o, null);
			void* ptr = Unsafe.AsPointer<byte>(ref bytes[0]);
			this.Send(type, ptr, bytes.Length);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000231C File Offset: 0x0000051C
		public unsafe void OnNet(int type, IntPtr data, int len)
		{
			Span<byte> span = new Span<byte>((void*)data, len);
			if (type == 1)
			{
				this.NetMsg_RequestFile(span);
				return;
			}
			if (type != 5)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("NetworkServer - unhandled message type {0}", new object[] { type }));
				return;
			}
			this.NetMsg_VoiceData(span);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002378 File Offset: 0x00000578
		private void NetMsg_RequestFile(Span<byte> span)
		{
			if (span.Length != 4)
			{
				throw new Exception("Invalid file request");
			}
			int fileId = MemoryMarshal.Read<int>(span);
			this.FileTransfer.Queue(fileId);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000023B4 File Offset: 0x000005B4
		private void NetMsg_VoiceData(Span<byte> span)
		{
			if (span == null || span.Length == 0)
			{
				return;
			}
			if (GameBase.Current == null)
			{
				return;
			}
			Client sourcePlayer = Client.All.FirstOrDefault((Client x) => x.SessionId == this.SessionId);
			if (!sourcePlayer.IsValid())
			{
				return;
			}
			foreach (Client receiver in Client.All)
			{
				if (GameBase.Current.CanHearPlayerVoice(sourcePlayer, receiver))
				{
					this.SendPlayerVoiceMessage(receiver, sourcePlayer, span);
				}
			}
		}

		/// <summary>
		/// Send player voice to another player
		/// </summary>
		// Token: 0x06000013 RID: 19 RVA: 0x00002450 File Offset: 0x00000650
		public unsafe void SendPlayerVoiceMessage(Client to, Client from, Span<byte> voiceData)
		{
			if (!to.IsValid())
			{
				return;
			}
			if (!from.IsValid())
			{
				return;
			}
			NetworkServer client = INetworkServer.FindBySessionId(to.SessionId) as NetworkServer;
			if (client == null)
			{
				return;
			}
			fixed (byte* pinnableReference = voiceData.GetPinnableReference())
			{
				byte* ptr = pinnableReference;
				client.SendVoiceData(from.PlayerId, (void*)ptr, voiceData.Length);
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000024A8 File Offset: 0x000006A8
		internal unsafe void SendVoiceData(long steamId, void* data, int length)
		{
			if (data == null || length == 0)
			{
				return;
			}
			if (NetworkServer.VoiceBuffer == IntPtr.Zero)
			{
				NetworkServer.VoiceBufferSize = 4096;
				NetworkServer.VoiceBuffer = Marshal.AllocHGlobal(NetworkServer.VoiceBufferSize);
			}
			int dataSize = 0;
			byte* dataPtr = (byte*)(void*)NetworkServer.VoiceBuffer;
			Unsafe.Write<long>((void*)dataPtr, steamId);
			dataSize += Unsafe.SizeOf<long>();
			dataPtr += dataSize;
			int voiceDataSize = Math.Min(length, NetworkServer.VoiceBufferSize - dataSize);
			Unsafe.CopyBlock((void*)dataPtr, data, (uint)voiceDataSize);
			dataSize += voiceDataSize;
			this.native.SendCustomMessage(5, NetworkServer.VoiceBuffer, dataSize);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002534 File Offset: 0x00000734
		public void Tick()
		{
			if (this.FileTransfer != null)
			{
				this.FileTransfer.Tick(this);
			}
		}

		// Token: 0x06000016 RID: 22 RVA: 0x0000254C File Offset: 0x0000074C
		public string FillServerInfo(string mapname)
		{
			if (ServerAddons.LastGamemodeAddon == null)
			{
				throw new Exception("Client asking for server info but we have no active gamemode addon?");
			}
			ServerInfo si = default(ServerInfo);
			si.MountedAddons = new List<string> { "base" };
			si.GameIdent = ServerContext.GamemodeIdent;
			si.MapIdent = ServerContext.MapIdent;
			si.RequiredContent = (from x in Content.All
				where x.ClientShouldInstall
				select x.Ident).ToArray<string>();
			return JsonSerializer.Serialize<ServerInfo>(si, null);
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002602 File Offset: 0x00000802
		public int PendingReliable
		{
			get
			{
				if (!this.native.IsNull)
				{
					return this.native.PendingReliable();
				}
				return 0;
			}
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000261E File Offset: 0x0000081E
		public void Disconnect(NetworkDisconnectionReason reason)
		{
			this.native.Disconnect(reason);
		}

		// Token: 0x04000004 RID: 4
		private ServerSideClient native;

		// Token: 0x04000005 RID: 5
		private FileSend FileTransfer = new FileSend();

		// Token: 0x04000006 RID: 6
		internal static IntPtr VoiceBuffer;

		// Token: 0x04000007 RID: 7
		internal static int VoiceBufferSize;
	}
}
