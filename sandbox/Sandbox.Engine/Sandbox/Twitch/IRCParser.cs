using System;
using System.Collections.Generic;

namespace Sandbox.Twitch
{
	// Token: 0x020002E1 RID: 737
	internal static class IRCParser
	{
		/// <summary>
		/// Parses a raw IRC message into a IRCMessage.
		/// </summary>
		// Token: 0x06001371 RID: 4977 RVA: 0x000284C4 File Offset: 0x000266C4
		public static IRCMessage Parse(string raw)
		{
			Dictionary<string, string> tagDict = new Dictionary<string, string>();
			IRCParser.State state = IRCParser.State.None;
			int[] starts = new int[6];
			int[] lens = new int[6];
			for (int i = 0; i < raw.Length; i++)
			{
				lens[(int)state] = i - starts[(int)state] - 1;
				if (state == IRCParser.State.None && raw[i] == '@')
				{
					state = IRCParser.State.V3;
					i = (starts[(int)state] = i + 1);
					int start = i;
					string key = null;
					while (i < raw.Length)
					{
						if (raw[i] == '=')
						{
							key = raw.Substring(start, i - start);
							start = i + 1;
						}
						else if (raw[i] == ';')
						{
							if (key == null)
							{
								tagDict[raw.Substring(start, i - start)] = "1";
							}
							else
							{
								tagDict[key] = raw.Substring(start, i - start);
							}
							start = i + 1;
						}
						else if (raw[i] == ' ')
						{
							if (key == null)
							{
								tagDict[raw.Substring(start, i - start)] = "1";
								break;
							}
							tagDict[key] = raw.Substring(start, i - start);
							break;
						}
						i++;
					}
				}
				else if (state < IRCParser.State.Prefix && raw[i] == ':')
				{
					state = IRCParser.State.Prefix;
					i = (starts[(int)state] = i + 1);
				}
				else if (state < IRCParser.State.Command)
				{
					state = IRCParser.State.Command;
					starts[(int)state] = i;
				}
				else
				{
					if (state < IRCParser.State.Trailing && raw[i] == ':')
					{
						state = IRCParser.State.Trailing;
						starts[(int)state] = i + 1;
						break;
					}
					if ((state < IRCParser.State.Trailing && raw[i] == '+') || (state < IRCParser.State.Trailing && raw[i] == '-'))
					{
						state = IRCParser.State.Trailing;
						starts[(int)state] = i;
						break;
					}
					if (state == IRCParser.State.Command)
					{
						state = IRCParser.State.Param;
						starts[(int)state] = i;
					}
				}
				while (i < raw.Length && raw[i] != ' ')
				{
					i++;
				}
			}
			lens[(int)state] = raw.Length - starts[(int)state];
			string cmd = raw.Substring(starts[3], lens[3]);
			IRCCommand command = IRCCommand.Unknown;
			uint num = <PrivateImplementationDetails>.ComputeStringHash(cmd);
			if (num <= 2561111319U)
			{
				if (num <= 1162767579U)
				{
					if (num <= 613830808U)
					{
						if (num != 43150473U)
						{
							if (num != 603386935U)
							{
								if (num == 613830808U)
								{
									if (cmd == "PASS")
									{
										command = IRCCommand.Pass;
									}
								}
							}
							else if (cmd == "PONG")
							{
								command = IRCCommand.Pong;
							}
						}
						else if (cmd == "PING")
						{
							command = IRCCommand.Ping;
						}
					}
					else if (num <= 1043585426U)
					{
						if (num != 630461332U)
						{
							if (num == 1043585426U)
							{
								if (cmd == "GLOBALUSERSTATE")
								{
									command = IRCCommand.GlobalUserState;
								}
							}
						}
						else if (cmd == "PART")
						{
							command = IRCCommand.Part;
						}
					}
					else if (num != 1146928018U)
					{
						if (num == 1162767579U)
						{
							if (cmd == "CAP")
							{
								command = IRCCommand.Cap;
							}
						}
					}
					else if (cmd == "353")
					{
						command = IRCCommand.RPL_353;
					}
				}
				else if (num <= 1998532429U)
				{
					if (num != 1369134898U)
					{
						if (num != 1958281977U)
						{
							if (num == 1998532429U)
							{
								if (cmd == "WHISPER")
								{
									command = IRCCommand.Whisper;
								}
							}
						}
						else if (cmd == "JOIN")
						{
							command = IRCCommand.Join;
						}
					}
					else if (cmd == "HOSTTARGET")
					{
						command = IRCCommand.HostTarget;
					}
				}
				else if (num <= 2132309426U)
				{
					if (num != 2029756220U)
					{
						if (num == 2132309426U)
						{
							if (cmd == "USERNOTICE")
							{
								command = IRCCommand.UserNotice;
							}
						}
					}
					else if (cmd == "CLEARCHAT")
					{
						command = IRCCommand.ClearChat;
					}
				}
				else if (num != 2509909495U)
				{
					if (num == 2561111319U)
					{
						if (cmd == "USERSTATE")
						{
							command = IRCCommand.UserState;
						}
					}
				}
				else if (cmd == "CLEARMSG")
				{
					command = IRCCommand.ClearMsg;
				}
			}
			else if (num <= 3579285415U)
			{
				if (num <= 2888337414U)
				{
					if (num != 2744757958U)
					{
						if (num != 2876042605U)
						{
							if (num == 2888337414U)
							{
								if (cmd == "SERVERCHANGE")
								{
									command = IRCCommand.ServerChange;
								}
							}
						}
						else if (cmd == "PRIVMSG")
						{
							command = IRCCommand.PrivMsg;
						}
					}
					else if (cmd == "RECONNECT")
					{
						command = IRCCommand.Reconnect;
					}
				}
				else if (num <= 3512174939U)
				{
					if (num != 3478472606U)
					{
						if (num == 3512174939U)
						{
							if (cmd == "376")
							{
								command = IRCCommand.RPL_376;
							}
						}
					}
					else if (cmd == "366")
					{
						command = IRCCommand.RPL_366;
					}
				}
				else if (num != 3528952558U)
				{
					if (num == 3579285415U)
					{
						if (cmd == "372")
						{
							command = IRCCommand.RPL_372;
						}
					}
				}
				else if (cmd == "375")
				{
					command = IRCCommand.RPL_375;
				}
			}
			else if (num <= 3838523700U)
			{
				if (num <= 3667541486U)
				{
					if (num != 3593007890U)
					{
						if (num == 3667541486U)
						{
							if (cmd == "NICK")
							{
								command = IRCCommand.Nick;
							}
						}
					}
					else if (cmd == "MODE")
					{
						command = IRCCommand.Mode;
					}
				}
				else if (num != 3788190843U)
				{
					if (num == 3838523700U)
					{
						if (cmd == "001")
						{
							command = IRCCommand.RPL_001;
						}
					}
				}
				else if (cmd == "004")
				{
					command = IRCCommand.RPL_004;
				}
			}
			else if (num <= 3888856557U)
			{
				if (num != 3872078938U)
				{
					if (num == 3888856557U)
					{
						if (cmd == "002")
						{
							command = IRCCommand.RPL_002;
						}
					}
				}
				else if (cmd == "003")
				{
					command = IRCCommand.RPL_003;
				}
			}
			else if (num != 3981314255U)
			{
				if (num == 3983032113U)
				{
					if (cmd == "NOTICE")
					{
						command = IRCCommand.Notice;
					}
				}
			}
			else if (cmd == "ROOMSTATE")
			{
				command = IRCCommand.RoomState;
			}
			string parameters = raw.Substring(starts[4], lens[4]);
			string message = raw.Substring(starts[5], lens[5]);
			string hostmask = raw.Substring(starts[2], lens[2]);
			return new IRCMessage(command, new string[] { parameters, message }, hostmask, tagDict);
		}

		// Token: 0x02000422 RID: 1058
		private enum State
		{
			// Token: 0x04001A87 RID: 6791
			None,
			// Token: 0x04001A88 RID: 6792
			V3,
			// Token: 0x04001A89 RID: 6793
			Prefix,
			// Token: 0x04001A8A RID: 6794
			Command,
			// Token: 0x04001A8B RID: 6795
			Param,
			// Token: 0x04001A8C RID: 6796
			Trailing
		}
	}
}
