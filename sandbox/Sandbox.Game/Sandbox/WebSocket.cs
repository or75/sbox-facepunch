using System;
using System.Buffers;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// A WebSocket client for connecting to external services.
	/// </summary>
	/// <remarks>
	/// Events handlers will be called on the synchronization context that <see cref="M:Sandbox.WebSocket.Connect(System.String,System.Threading.CancellationToken)" /> was called on.
	/// </remarks>
	// Token: 0x02000109 RID: 265
	public sealed class WebSocket : IDisposable
	{
		/// <summary>
		/// Returns true as long as a WebSocket connection is established.
		/// </summary>
		// Token: 0x17000332 RID: 818
		// (get) Token: 0x06001556 RID: 5462 RVA: 0x00054D73 File Offset: 0x00052F73
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
		// Token: 0x17000333 RID: 819
		// (get) Token: 0x06001557 RID: 5463 RVA: 0x00054D89 File Offset: 0x00052F89
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
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06001558 RID: 5464 RVA: 0x00054D9C File Offset: 0x00052F9C
		// (remove) Token: 0x06001559 RID: 5465 RVA: 0x00054DD4 File Offset: 0x00052FD4
		public event WebSocket.MessageReceivedHandler OnMessageReceived;

		/// <summary>
		/// Event which fires when a binary message is received from the server.
		/// </summary>
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600155A RID: 5466 RVA: 0x00054E0C File Offset: 0x0005300C
		// (remove) Token: 0x0600155B RID: 5467 RVA: 0x00054E44 File Offset: 0x00053044
		public event WebSocket.DataReceivedHandler OnDataReceived;

		/// <summary>
		/// Event which fires when the connection to the WebSocket service is lost, for any reason.
		/// </summary>
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600155C RID: 5468 RVA: 0x00054E7C File Offset: 0x0005307C
		// (remove) Token: 0x0600155D RID: 5469 RVA: 0x00054EB4 File Offset: 0x000530B4
		public event WebSocket.DisconnectedHandler OnDisconnected;

		/// <summary>
		/// Initialized a new WebSocket client.
		/// </summary>
		/// <param name="maxMessageSize">The maximum message size to allow from the server, in bytes. Default 64 KiB.</param>
		// Token: 0x0600155E RID: 5470 RVA: 0x00054EEC File Offset: 0x000530EC
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
			TaskSource.Cancellation.Register(new Action(this.Dispose));
		}

		// Token: 0x0600155F RID: 5471 RVA: 0x00054F78 File Offset: 0x00053178
		~WebSocket()
		{
			this.Dispose();
		}

		/// <summary>
		/// Cleans up resources used by the WebSocket client. This will also immediately close the connection if it is currently open.
		/// </summary>
		// Token: 0x06001560 RID: 5472 RVA: 0x00054FA4 File Offset: 0x000531A4
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
		// Token: 0x06001561 RID: 5473 RVA: 0x00055044 File Offset: 0x00053244
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
		// Token: 0x06001562 RID: 5474 RVA: 0x00055075 File Offset: 0x00053275
		public Task Connect(string websocketUri, CancellationToken ct = default(CancellationToken))
		{
			return this.Connect(websocketUri, null, ct);
		}

		/// <summary>
		/// Establishes a connection to an external WebSocket service.
		/// </summary>
		/// <param name="websocketUri">The WebSocket URI to connect to. For example, "ws://hostname.local:1280/" for unencrypted WebSocket or "wss://hostname.local:1281/" for encrypted.</param>
		/// <param name="headers">Headers to send with the connection request.</param>
		/// <param name="ct">A <see cref="T:System.Threading.CancellationToken" /> which allows the connection attempt to be aborted if necessary.</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.Task" /> which completes when the connection is established, or throws if it failed to connect.</returns>
		// Token: 0x06001563 RID: 5475 RVA: 0x00055080 File Offset: 0x00053280
		public async Task Connect(string websocketUri, Dictionary<string, string> headers, CancellationToken ct = default(CancellationToken))
		{
			this.EnsureNotDisposed();
			if (this._socket.State != WebSocketState.None)
			{
				throw new InvalidOperationException("Connect may only be called once per WebSocket instance.");
			}
			Uri uri = WebSocket.ParseWebSocketUri(websocketUri);
			if (!Http.IsAllowed(uri))
			{
				throw new InvalidOperationException("Access to '" + websocketUri + "' is not allowed.");
			}
			if (headers != null)
			{
				if (!Http.AreHeadersAllowed(headers))
				{
					throw new InvalidOperationException("Some of the specified headers are not allowed to be set.");
				}
				foreach (KeyValuePair<string, string> keyValuePair in headers)
				{
					string text;
					string text2;
					keyValuePair.Deconstruct(out text, out text2);
					string key = text;
					string value = text2;
					this._socket.Options.SetRequestHeader(key, value);
				}
			}
			this._socket.Options.SetRequestHeader("User-Agent", "facepunch-s&box");
			this._socket.Options.SetRequestHeader("Origin", "https://sbox.facepunch.com/");
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
		// Token: 0x06001564 RID: 5476 RVA: 0x000550DC File Offset: 0x000532DC
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
		/// The <see cref="M:Sandbox.WebSocket.Send(System.ArraySegment{System.Byte})" /> and <see cref="M:Sandbox.WebSocket.Send(System.Span{System.Byte})" /> overloads allow sending subsections of byte arrays.
		/// </remarks>
		/// <param name="data">The message data to send. Must not be null.</param>
		/// <returns>A <see cref="T:System.Threading.Tasks.ValueTask" /> which completes when the message was queued to be sent.</returns>
		// Token: 0x06001565 RID: 5477 RVA: 0x0005515F File Offset: 0x0005335F
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
		// Token: 0x06001566 RID: 5478 RVA: 0x00055181 File Offset: 0x00053381
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
		// Token: 0x06001567 RID: 5479 RVA: 0x000551AC File Offset: 0x000533AC
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

		// Token: 0x06001568 RID: 5480 RVA: 0x0005521C File Offset: 0x0005341C
		private void ReceiveLoop()
		{
			WebSocket.<ReceiveLoop>d__32 <ReceiveLoop>d__;
			<ReceiveLoop>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<ReceiveLoop>d__.<>4__this = this;
			<ReceiveLoop>d__.<>1__state = -1;
			<ReceiveLoop>d__.<>t__builder.Start<WebSocket.<ReceiveLoop>d__32>(ref <ReceiveLoop>d__);
		}

		// Token: 0x06001569 RID: 5481 RVA: 0x00055254 File Offset: 0x00053454
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
					GlobalGameNamespace.Log.Error(e);
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
				GlobalGameNamespace.Log.Error(e2);
			}
		}

		// Token: 0x0600156A RID: 5482 RVA: 0x000552E0 File Offset: 0x000534E0
		private void SendLoop()
		{
			WebSocket.<SendLoop>d__34 <SendLoop>d__;
			<SendLoop>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<SendLoop>d__.<>4__this = this;
			<SendLoop>d__.<>1__state = -1;
			<SendLoop>d__.<>t__builder.Start<WebSocket.<SendLoop>d__34>(ref <SendLoop>d__);
		}

		// Token: 0x0600156B RID: 5483 RVA: 0x00055317 File Offset: 0x00053517
		private void Disconnect(WebSocketCloseStatus? status, string reason)
		{
			this.DispatchDisconnect(status, reason);
			this.Dispose();
		}

		// Token: 0x0600156C RID: 5484 RVA: 0x00055328 File Offset: 0x00053528
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
				GlobalGameNamespace.Log.Error(e);
			}
		}

		// Token: 0x0600156D RID: 5485 RVA: 0x00055380 File Offset: 0x00053580
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

		// Token: 0x0600156E RID: 5486 RVA: 0x000553C8 File Offset: 0x000535C8
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

		// Token: 0x040004FF RID: 1279
		[Hotload.SkipAttribute]
		private CancellationTokenSource _cts;

		// Token: 0x04000500 RID: 1280
		[Hotload.SkipAttribute]
		private ClientWebSocket _socket;

		// Token: 0x04000501 RID: 1281
		[Hotload.SkipAttribute]
		private readonly Channel<WebSocket.Message> _outgoing;

		// Token: 0x04000502 RID: 1282
		private readonly int _maxMessageSize;

		// Token: 0x04000503 RID: 1283
		private bool _dispatchedDisconnect;

		/// <summary>
		/// Event handler which processes text messages from the WebSocket service.
		/// </summary>
		/// <param name="message">The message text that was received.</param>
		// Token: 0x0200026F RID: 623
		// (Invoke) Token: 0x06001EF7 RID: 7927
		public delegate void MessageReceivedHandler(string message);

		/// <summary>
		/// Event handler which processes binary messages from the WebSocket service.
		/// </summary>
		/// <param name="data">The binary message data that was received.</param>
		// Token: 0x02000270 RID: 624
		// (Invoke) Token: 0x06001EFB RID: 7931
		public delegate void DataReceivedHandler(Span<byte> data);

		/// <summary>
		/// Event handler which fires when the WebSocket disconnects from the server.
		/// </summary>
		/// <param name="status">The close status code from the server, or 0 if there was none. See known values here: https://developer.mozilla.org/en-US/docs/Web/API/CloseEvent</param>
		/// <param name="reason">The reason string for closing the connection. This may not be populated, may be from the server, or may be a client exception message.</param>
		// Token: 0x02000271 RID: 625
		// (Invoke) Token: 0x06001EFF RID: 7935
		public delegate void DisconnectedHandler(int status, string reason);

		// Token: 0x02000272 RID: 626
		private class Message
		{
			// Token: 0x04001249 RID: 4681
			public WebSocketMessageType Type;

			// Token: 0x0400124A RID: 4682
			public ArraySegment<byte> Data;
		}
	}
}
