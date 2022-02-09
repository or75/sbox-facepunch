using System;
using System.Buffers;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Sandbox.Internal;

namespace Sandbox.Engine
{
	/// <summary>
	/// A WebSocket client for connecting to external services.
	/// </summary>
	/// <remarks>
	/// Events handlers will be called on the synchronization context that <see cref="M:Sandbox.Engine.WebSocket.Connect(System.String,System.Threading.CancellationToken)" /> was called on.
	/// </remarks>
	// Token: 0x02000303 RID: 771
	internal sealed class WebSocket : IDisposable
	{
		/// <summary>
		/// Returns true as long as a WebSocket connection is established.
		/// </summary>
		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x0600148E RID: 5262 RVA: 0x0002BF17 File Offset: 0x0002A117
		public bool IsConnected
		{
			get
			{
				ClientWebSocket socket = this._socket;
				return socket != null && socket.State == WebSocketState.Open;
			}
		}

		/// <summary>
		/// Get the sub-protocol that was negotiated during the opening handshake.
		/// </summary>
		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x0600148F RID: 5263 RVA: 0x0002BF2D File Offset: 0x0002A12D
		public string SubProtocol
		{
			get
			{
				ClientWebSocket socket = this._socket;
				if (socket == null)
				{
					return null;
				}
				return socket.SubProtocol;
			}
		}

		/// <summary>
		/// Event which fires when a text message is received from the server.
		/// </summary>
		// Token: 0x1400003D RID: 61
		// (add) Token: 0x06001490 RID: 5264 RVA: 0x0002BF40 File Offset: 0x0002A140
		// (remove) Token: 0x06001491 RID: 5265 RVA: 0x0002BF78 File Offset: 0x0002A178
		public event WebSocket.MessageReceivedHandler OnMessageReceived;

		/// <summary>
		/// Event which fires when a binary message is received from the server.
		/// </summary>
		// Token: 0x1400003E RID: 62
		// (add) Token: 0x06001492 RID: 5266 RVA: 0x0002BFB0 File Offset: 0x0002A1B0
		// (remove) Token: 0x06001493 RID: 5267 RVA: 0x0002BFE8 File Offset: 0x0002A1E8
		public event WebSocket.DataReceivedHandler OnDataReceived;

		/// <summary>
		/// Event which fires when the connection to the WebSocket service is lost, for any reason.
		/// </summary>
		// Token: 0x1400003F RID: 63
		// (add) Token: 0x06001494 RID: 5268 RVA: 0x0002C020 File Offset: 0x0002A220
		// (remove) Token: 0x06001495 RID: 5269 RVA: 0x0002C058 File Offset: 0x0002A258
		public event WebSocket.DisconnectedHandler OnDisconnected;

		/// <summary>
		/// Initialized a new WebSocket client.
		/// </summary>
		/// <param name="maxMessageSize">The maximum message size to allow from the server, in bytes. Default 64 KiB.</param>
		// Token: 0x06001496 RID: 5270 RVA: 0x0002C090 File Offset: 0x0002A290
		public WebSocket(int maxMessageSize = 65536)
		{
			if (maxMessageSize <= 0 || maxMessageSize > 4194304)
			{
				throw new ArgumentOutOfRangeException("maxMessageSize");
			}
			this._maxMessageSize = Math.Max(maxMessageSize, 4096);
			this._cts = new CancellationTokenSource();
			this._socket = new ClientWebSocket();
			this._outgoing = Channel.CreateBounded<WebSocket.Message>(new BoundedChannelOptions(10)
			{
				SingleReader = true,
				SingleWriter = false
			});
		}

		// Token: 0x06001497 RID: 5271 RVA: 0x0002C104 File Offset: 0x0002A304
		~WebSocket()
		{
			this.Dispose();
		}

		/// <summary>
		/// Cleans up resources used by the WebSocket client. This will also immediately close the connection if it is currently open.
		/// </summary>
		// Token: 0x06001498 RID: 5272 RVA: 0x0002C130 File Offset: 0x0002A330
		public void Dispose()
		{
			lock (this)
			{
				this.DispatchDisconnect(new WebSocketCloseStatus?((WebSocketCloseStatus)0), "Disposing");
				CancellationTokenSource cts = this._cts;
				if (cts != null)
				{
					cts.Cancel();
				}
				CancellationTokenSource cts2 = this._cts;
				if (cts2 != null)
				{
					cts2.Dispose();
				}
				this._cts = null;
				ClientWebSocket socket = this._socket;
				if (socket != null)
				{
					socket.Dispose();
				}
				this._socket = null;
				this._outgoing.Writer.TryComplete(null);
			}
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Add a sub-protocol to be negotiated during the WebSocket connection handshake.
		/// </summary>
		/// <param name="protocol"></param>
		// Token: 0x06001499 RID: 5273 RVA: 0x0002C1D0 File Offset: 0x0002A3D0
		public void AddSubProtocol(string protocol)
		{
			this.EnsureNotDisposed();
			if (this._socket.State != WebSocketState.None)
			{
				throw new InvalidOperationException("Cannot add sub-protocols while the WebSocket is connected.");
			}
			this._socket.Options.AddSubProtocol(protocol);
		}

		/// <summary>
		/// Establishes a connection to an external WebSocket service.
		/// </summary>
		/// <param name="websocketUri">The WebSocket URI to connect to. For example, "ws://hostname.local:1280/" for unencrypted WebSocket or "wss://hostname.local:1281/" for encrypted.</param>
		/// <param name="ct">A <see cref="T:System.Threading.CancellationToken" /> which allows the connection attempt to be aborted if necessary.</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.Task" /> which completes when the connection is established, or throws if it failed to connect.</returns>
		// Token: 0x0600149A RID: 5274 RVA: 0x0002C204 File Offset: 0x0002A404
		public async Task Connect(string websocketUri, CancellationToken ct = default(CancellationToken))
		{
			this.EnsureNotDisposed();
			if (this._socket.State != WebSocketState.None)
			{
				throw new InvalidOperationException("Connect may only be called once per WebSocket instance.");
			}
			Uri uri = WebSocket.ParseWebSocketUri(websocketUri);
			using (CancellationTokenSource linkedCt = CancellationTokenSource.CreateLinkedTokenSource(this._cts.Token, ct))
			{
				await this._socket.ConnectAsync(uri, linkedCt.Token);
				this.SendLoop();
				this.ReceiveLoop();
			}
		}

		/// <summary>
		/// Sends a text message to the WebSocket server.
		/// </summary>
		/// <param name="message">The message text to send. Must not be null.</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.ValueTask" /> which completes when the message was queued to be sent.</returns>
		// Token: 0x0600149B RID: 5275 RVA: 0x0002C258 File Offset: 0x0002A458
		public ValueTask Send(string message)
		{
			this.EnsureNotDisposed();
			if (message == null)
			{
				throw new ArgumentNullException("message");
			}
			int byteCount = Encoding.UTF8.GetByteCount(message);
			byte[] buffer = ArrayPool<byte>.Shared.Rent(byteCount);
			int length = Encoding.UTF8.GetBytes(message, buffer);
			return this._outgoing.Writer.WriteAsync(new WebSocket.Message
			{
				Type = WebSocketMessageType.Text,
				Data = new ArraySegment<byte>(buffer, 0, length)
			}, default(CancellationToken));
		}

		/// <summary>
		/// Sends a binary message to the WebSocket server.
		/// </summary>
		/// <remarks>
		/// The <see cref="M:Sandbox.Engine.WebSocket.Send(System.ArraySegment{System.Byte})" /> and <see cref="M:Sandbox.Engine.WebSocket.Send(System.Span{System.Byte})" /> overloads allow sending subsections of byte arrays.
		/// </remarks>
		/// <param name="data">The message data to send. Must not be null.</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.ValueTask" /> which completes when the message was queued to be sent.</returns>
		// Token: 0x0600149C RID: 5276 RVA: 0x0002C2DB File Offset: 0x0002A4DB
		public ValueTask Send(byte[] data)
		{
			this.EnsureNotDisposed();
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			return this.Send(data.AsSpan<byte>());
		}

		/// <summary>
		/// Sends a binary message to the WebSocket server.
		/// </summary>
		/// <param name="data">The message data to send. Must not be null.</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.ValueTask" /> which completes when the message was queued to be sent.</returns>
		// Token: 0x0600149D RID: 5277 RVA: 0x0002C2FD File Offset: 0x0002A4FD
		public ValueTask Send(ArraySegment<byte> data)
		{
			this.EnsureNotDisposed();
			if (data.Array == null)
			{
				throw new ArgumentNullException("data");
			}
			return this.Send(data.AsSpan<byte>());
		}

		/// <summary>
		/// Sends a binary message to the WebSocket server.
		/// </summary>
		/// <param name="data">The message data to send.</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.ValueTask" /> which completes when the message was queued to be sent.</returns>
		// Token: 0x0600149E RID: 5278 RVA: 0x0002C328 File Offset: 0x0002A528
		public ValueTask Send(Span<byte> data)
		{
			this.EnsureNotDisposed();
			byte[] buffer = ArrayPool<byte>.Shared.Rent(data.Length);
			data.CopyTo(buffer);
			WebSocket.Message message = new WebSocket.Message
			{
				Type = WebSocketMessageType.Binary,
				Data = new ArraySegment<byte>(buffer, 0, data.Length)
			};
			return this._outgoing.Writer.WriteAsync(message, this._cts.Token);
		}

		// Token: 0x0600149F RID: 5279 RVA: 0x0002C398 File Offset: 0x0002A598
		private void ReceiveLoop()
		{
			WebSocket.<ReceiveLoop>d__31 <ReceiveLoop>d__;
			<ReceiveLoop>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<ReceiveLoop>d__.<>4__this = this;
			<ReceiveLoop>d__.<>1__state = -1;
			<ReceiveLoop>d__.<>t__builder.Start<WebSocket.<ReceiveLoop>d__31>(ref <ReceiveLoop>d__);
		}

		// Token: 0x060014A0 RID: 5280 RVA: 0x0002C3D0 File Offset: 0x0002A5D0
		private void DispatchReceived(WebSocketMessageType type, byte[] buffer, int length)
		{
			Span<byte> data = new Span<byte>(buffer, 0, length);
			if (type == WebSocketMessageType.Text)
			{
				string messageText = Encoding.UTF8.GetString(data);
				try
				{
					WebSocket.MessageReceivedHandler onMessageReceived = this.OnMessageReceived;
					if (onMessageReceived != null)
					{
						onMessageReceived(messageText);
					}
					return;
				}
				catch (Exception e)
				{
					GlobalSystemNamespace.Log.Error(e);
					return;
				}
			}
			try
			{
				WebSocket.DataReceivedHandler onDataReceived = this.OnDataReceived;
				if (onDataReceived != null)
				{
					onDataReceived(data);
				}
			}
			catch (Exception e2)
			{
				GlobalSystemNamespace.Log.Error(e2);
			}
		}

		// Token: 0x060014A1 RID: 5281 RVA: 0x0002C45C File Offset: 0x0002A65C
		private void SendLoop()
		{
			WebSocket.<SendLoop>d__33 <SendLoop>d__;
			<SendLoop>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<SendLoop>d__.<>4__this = this;
			<SendLoop>d__.<>1__state = -1;
			<SendLoop>d__.<>t__builder.Start<WebSocket.<SendLoop>d__33>(ref <SendLoop>d__);
		}

		// Token: 0x060014A2 RID: 5282 RVA: 0x0002C493 File Offset: 0x0002A693
		private void Disconnect(WebSocketCloseStatus? status, string reason)
		{
			this.DispatchDisconnect(status, reason);
			this.Dispose();
		}

		// Token: 0x060014A3 RID: 5283 RVA: 0x0002C4A4 File Offset: 0x0002A6A4
		private void DispatchDisconnect(WebSocketCloseStatus? status, string reason)
		{
			if (this._dispatchedDisconnect)
			{
				return;
			}
			this._dispatchedDisconnect = true;
			try
			{
				WebSocket.DisconnectedHandler onDisconnected = this.OnDisconnected;
				if (onDisconnected != null)
				{
					onDisconnected((int)status.GetValueOrDefault((WebSocketCloseStatus)0), reason);
				}
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Error(e);
			}
		}

		// Token: 0x060014A4 RID: 5284 RVA: 0x0002C4FC File Offset: 0x0002A6FC
		private void EnsureNotDisposed()
		{
			lock (this)
			{
				if (this._cts == null)
				{
					throw new ObjectDisposedException("WebSocket");
				}
			}
		}

		// Token: 0x060014A5 RID: 5285 RVA: 0x0002C544 File Offset: 0x0002A744
		private static Uri ParseWebSocketUri(string websocketUri)
		{
			if (string.IsNullOrEmpty(websocketUri))
			{
				throw new ArgumentNullException("websocketUri");
			}
			Uri uri;
			if (!Uri.TryCreate(websocketUri, UriKind.Absolute, out uri))
			{
				throw new ArgumentException("WebSocket URI is not a valid URI.", "websocketUri");
			}
			if (uri.Scheme != "ws" && uri.Scheme != "wss")
			{
				throw new ArgumentException("WebSocket URI must use the ws:// or wss:// scheme.", "websocketUri");
			}
			return uri;
		}

		// Token: 0x04001556 RID: 5462
		[Hotload.SkipAttribute]
		private CancellationTokenSource _cts;

		// Token: 0x04001557 RID: 5463
		[Hotload.SkipAttribute]
		private ClientWebSocket _socket;

		// Token: 0x04001558 RID: 5464
		[Hotload.SkipAttribute]
		private readonly Channel<WebSocket.Message> _outgoing;

		// Token: 0x04001559 RID: 5465
		private readonly int _maxMessageSize;

		// Token: 0x0400155A RID: 5466
		private bool _dispatchedDisconnect;

		/// <summary>
		/// Event handler which processes text messages from the WebSocket service.
		/// </summary>
		/// <param name="message">The message text that was received.</param>
		// Token: 0x02000466 RID: 1126
		// (Invoke) Token: 0x06001980 RID: 6528
		public delegate void MessageReceivedHandler(string message);

		/// <summary>
		/// Event handler which processes binary messages from the WebSocket service.
		/// </summary>
		/// <param name="data">The binary message data that was received.</param>
		// Token: 0x02000467 RID: 1127
		// (Invoke) Token: 0x06001984 RID: 6532
		public delegate void DataReceivedHandler(Span<byte> data);

		/// <summary>
		/// Event handler which fires when the WebSocket disconnects from the server.
		/// </summary>
		/// <param name="status">The close status code from the server, or 0 if there was none. See known values here: https://developer.mozilla.org/en-US/docs/Web/API/CloseEvent</param>
		/// <param name="reason">The reason string for closing the connection. This may not be populated, may be from the server, or may be a client exception message.</param>
		// Token: 0x02000468 RID: 1128
		// (Invoke) Token: 0x06001988 RID: 6536
		public delegate void DisconnectedHandler(int status, string reason);

		// Token: 0x02000469 RID: 1129
		private class Message
		{
			// Token: 0x04001BF6 RID: 7158
			public WebSocketMessageType Type;

			// Token: 0x04001BF7 RID: 7159
			public ArraySegment<byte> Data;
		}
	}
}
