using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Sandbox.Engine;
using Sandbox.Internal;

namespace Sandbox.Twitch
{
	// Token: 0x020002E3 RID: 739
	internal class TwitchClient
	{
		// Token: 0x06001389 RID: 5001 RVA: 0x000292A4 File Offset: 0x000274A4
		public async Task<bool> Connect()
		{
			bool result;
			if (this._webSocket != null)
			{
				result = false;
			}
			else
			{
				this.Username = Streamer.Username;
				this.UserId = Streamer.UserId;
				this._webSocket = new WebSocket(65536);
				this._webSocket.OnDisconnected += this.WebSocket_OnDisconnected;
				this._webSocket.OnMessageReceived += this.WebSocket_OnMessageReceived;
				int num = 0;
				try
				{
					await this._webSocket.Connect("wss://irc-ws.chat.twitch.tv:443", default(CancellationToken));
					await this._webSocket.Send("CAP REQ :twitch.tv/tags twitch.tv/commands twitch.tv/membership");
					await this._webSocket.Send("PASS oauth:" + Streamer.Token);
					await this._webSocket.Send("NICK " + this.Username);
					while (!this.fullyConnected)
					{
						await Task.Delay(100);
						if (this._webSocket == null)
						{
							return false;
						}
					}
					return true;
				}
				catch (Exception obj)
				{
					num = 1;
				}
				if (num == 1)
				{
					object obj;
					Exception e = (Exception)obj;
					this._webSocket = null;
					GlobalSystemNamespace.Log.Warning(e, FormattableStringFactory.Create("Failed to connect to {0}, trying again in 1 second", new object[] { "wss://irc-ws.chat.twitch.tv:443" }));
					await Task.Delay(1000);
					result = await this.Connect();
				}
			}
			return result;
		}

		// Token: 0x0600138A RID: 5002 RVA: 0x000292E7 File Offset: 0x000274E7
		public void Disconnect()
		{
			this.Disconnect(false);
		}

		// Token: 0x0600138B RID: 5003 RVA: 0x000292F0 File Offset: 0x000274F0
		internal void Disconnect(bool reconnect)
		{
			if (this._webSocket == null)
			{
				return;
			}
			this._reconnect = reconnect;
			this.Username = null;
			this._webSocket.Dispose();
			this._webSocket = null;
			this._channels.Clear();
		}

		// Token: 0x0600138C RID: 5004 RVA: 0x00029328 File Offset: 0x00027528
		public async void SendMessage(string message)
		{
			if (this._webSocket != null)
			{
				await this._webSocket.Send("PRIVMSG #" + this.Username + " :" + message);
			}
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x00029367 File Offset: 0x00027567
		public void ClearChat()
		{
			this.SendCommand("clear");
		}

		// Token: 0x0600138E RID: 5006 RVA: 0x00029374 File Offset: 0x00027574
		public void BanUser(string username, string reason)
		{
			this.SendCommand("ban " + username + " " + reason);
		}

		// Token: 0x0600138F RID: 5007 RVA: 0x0002938D File Offset: 0x0002758D
		public void UnbanUser(string username)
		{
			this.SendCommand("unban " + username);
		}

		// Token: 0x06001390 RID: 5008 RVA: 0x000293A0 File Offset: 0x000275A0
		public void TimeoutUser(string username, int duration, string reason)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 3);
			defaultInterpolatedStringHandler.AppendLiteral("timeout ");
			defaultInterpolatedStringHandler.AppendFormatted(username);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(duration);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted(reason);
			this.SendCommand(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06001391 RID: 5009 RVA: 0x00029400 File Offset: 0x00027600
		private async void SendCommand(string command)
		{
			if (this._webSocket != null)
			{
				await this._webSocket.Send("PRIVMSG #" + this.Username + " :/" + command);
			}
		}

		// Token: 0x06001392 RID: 5010 RVA: 0x0002943F File Offset: 0x0002763F
		private void IRC_OnConnected()
		{
			this._reconnect = true;
			this.fullyConnected = true;
			this.JoinChannel(this.Username);
		}

		// Token: 0x06001393 RID: 5011 RVA: 0x0002945C File Offset: 0x0002765C
		public async void JoinChannel(string channel)
		{
			if (this._webSocket != null)
			{
				if (!string.IsNullOrEmpty(channel))
				{
					await this._webSocket.Send("JOIN #" + channel.ToLower());
				}
			}
		}

		// Token: 0x06001394 RID: 5012 RVA: 0x0002949C File Offset: 0x0002769C
		public async void LeaveChannel(string channel)
		{
			if (this._webSocket != null)
			{
				if (!string.IsNullOrEmpty(channel))
				{
					await this._webSocket.Send("PART #" + channel.ToLower());
				}
			}
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x000294DC File Offset: 0x000276DC
		private static StreamChatMessage ParseChatMessage(IRCMessage ircMessage)
		{
			StreamChatMessage message = new StreamChatMessage
			{
				Channel = ircMessage.Channel,
				Message = ircMessage.Message,
				Username = ircMessage.User,
				DisplayName = null,
				Color = null,
				Badges = null
			};
			foreach (KeyValuePair<string, string> tag in ircMessage.Tags)
			{
				string key = tag.Key;
				if (!(key == "display-name"))
				{
					if (!(key == "color"))
					{
						if (key == "badges")
						{
							message.Badges = (string.IsNullOrEmpty(tag.Value) ? null : tag.Value.Split(',', StringSplitOptions.None));
						}
					}
					else
					{
						message.Color = tag.Value;
					}
				}
				else
				{
					message.DisplayName = tag.Value;
				}
			}
			if (string.IsNullOrEmpty(message.DisplayName))
			{
				message.DisplayName = message.Username;
			}
			return message;
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x00029610 File Offset: 0x00027810
		private void IRC_OnMessage(StreamChatMessage message)
		{
			if (string.IsNullOrWhiteSpace(message.Message))
			{
				return;
			}
			Streamer.RunEvent("stream.message", message);
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x00029634 File Offset: 0x00027834
		private async void IRC_OnPing()
		{
			if (this._webSocket != null)
			{
				await this._webSocket.Send("PONG");
			}
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x0002966B File Offset: 0x0002786B
		private void IRC_OnJoin(IRCMessage message)
		{
			if (message.User == this.Username)
			{
				this._channels.Add(message.Channel);
			}
			Streamer.RunEvent("stream.join", message.User);
		}

		// Token: 0x06001399 RID: 5017 RVA: 0x000296A1 File Offset: 0x000278A1
		private void IRC_OnPart(IRCMessage message)
		{
			if (message.User == this.Username)
			{
				this._channels.Remove(message.Channel);
			}
			Streamer.RunEvent("stream.leave", message.User);
		}

		// Token: 0x0600139A RID: 5018 RVA: 0x000296D8 File Offset: 0x000278D8
		private void HandleIRCMessage(IRCMessage message)
		{
			if (message.Message.Contains("Login authentication failed"))
			{
				this.Disconnect(false);
				return;
			}
			IRCCommand command = message.Command;
			switch (command)
			{
			case IRCCommand.Unknown:
			case IRCCommand.Notice:
			case IRCCommand.Pong:
				break;
			case IRCCommand.PrivMsg:
				this.IRC_OnMessage(TwitchClient.ParseChatMessage(message));
				return;
			case IRCCommand.Ping:
				this.IRC_OnPing();
				return;
			case IRCCommand.Join:
				this.IRC_OnJoin(message);
				return;
			case IRCCommand.Part:
				this.IRC_OnPart(message);
				return;
			default:
				if (command != IRCCommand.RPL_004)
				{
					return;
				}
				this.IRC_OnConnected();
				break;
			}
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x00029758 File Offset: 0x00027958
		private void WebSocket_OnMessageReceived(string message)
		{
			string[] stringSeparators = new string[] { "\r\n" };
			foreach (string line in message.Split(stringSeparators, StringSplitOptions.None))
			{
				if (line.Length > 1)
				{
					this.HandleIRCMessage(IRCParser.Parse(line));
				}
			}
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x000297A4 File Offset: 0x000279A4
		private void WebSocket_OnDisconnected(int status, string reason)
		{
			if (this._webSocket == null)
			{
				return;
			}
			this._webSocket = null;
			this._channels.Clear();
			if (reason == "Disposing")
			{
				this._reconnect = false;
			}
			if (this._reconnect)
			{
				this.Connect();
			}
		}

		// Token: 0x04001511 RID: 5393
		internal const string EndpointURL = "wss://irc-ws.chat.twitch.tv:443";

		// Token: 0x04001512 RID: 5394
		private WebSocket _webSocket;

		// Token: 0x04001513 RID: 5395
		internal string Username;

		// Token: 0x04001514 RID: 5396
		internal string UserId;

		// Token: 0x04001515 RID: 5397
		private bool _reconnect;

		// Token: 0x04001516 RID: 5398
		private List<string> _channels = new List<string>();

		// Token: 0x04001517 RID: 5399
		private bool fullyConnected;
	}
}
