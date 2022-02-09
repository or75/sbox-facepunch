using System;
using System.Collections.Generic;
using System.Text;

namespace Sandbox.Twitch
{
	// Token: 0x020002E0 RID: 736
	internal class IRCMessage
	{
		/// <summary>
		/// The channel the message was sent in
		/// </summary>
		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x0600136A RID: 4970 RVA: 0x0002822C File Offset: 0x0002642C
		public string Channel
		{
			get
			{
				if (!this.Params.StartsWith("#"))
				{
					return this.Params;
				}
				return this.Params.Remove(0, 1);
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x0600136B RID: 4971 RVA: 0x00028254 File Offset: 0x00026454
		public string Params
		{
			get
			{
				if (this._parameters == null || this._parameters.Length == 0)
				{
					return "";
				}
				return this._parameters[0];
			}
		}

		/// <summary>
		/// Message itself
		/// </summary>
		// Token: 0x170003CB RID: 971
		// (get) Token: 0x0600136C RID: 4972 RVA: 0x00028275 File Offset: 0x00026475
		public string Message
		{
			get
			{
				return this.Trailing;
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x0600136D RID: 4973 RVA: 0x0002827D File Offset: 0x0002647D
		public string Trailing
		{
			get
			{
				if (this._parameters == null || this._parameters.Length <= 1)
				{
					return "";
				}
				return this._parameters[this._parameters.Length - 1];
			}
		}

		/// <summary>
		/// Create an INCOMPLETE IrcMessage only carrying username
		/// </summary>
		/// <param name="user"></param>
		// Token: 0x0600136E RID: 4974 RVA: 0x000282A9 File Offset: 0x000264A9
		public IRCMessage(string user)
		{
			this._parameters = null;
			this.User = user;
			this.Hostmask = null;
			this.Command = IRCCommand.Unknown;
			this.Tags = null;
		}

		/// <summary>
		/// Create an IrcMessage
		/// </summary>
		/// <param name="command">IRC Command</param>
		/// <param name="parameters">Command params</param>
		/// <param name="hostmask">User</param>
		/// <param name="tags">IRCv3 tags</param>
		// Token: 0x0600136F RID: 4975 RVA: 0x000282D4 File Offset: 0x000264D4
		public IRCMessage(IRCCommand command, string[] parameters, string hostmask, Dictionary<string, string> tags = null)
		{
			int idx = hostmask.IndexOf('!');
			this.User = ((idx != -1) ? hostmask.Substring(0, idx) : hostmask);
			this.Hostmask = hostmask;
			this._parameters = parameters;
			this.Command = command;
			this.Tags = tags;
		}

		// Token: 0x06001370 RID: 4976 RVA: 0x00028324 File Offset: 0x00026524
		public new string ToString()
		{
			StringBuilder raw = new StringBuilder(32);
			if (this.Tags != null)
			{
				string[] tags = new string[this.Tags.Count];
				int i = 0;
				foreach (KeyValuePair<string, string> tag in this.Tags)
				{
					tags[i] = tag.Key + "=" + tag.Value;
					i++;
				}
				if (tags.Length != 0)
				{
					raw.Append("@").Append(string.Join(";", tags)).Append(" ");
				}
			}
			if (!string.IsNullOrEmpty(this.Hostmask))
			{
				raw.Append(":").Append(this.Hostmask).Append(" ");
			}
			raw.Append(this.Command.ToString().ToUpper().Replace("RPL_", ""));
			if (this._parameters.Length == 0)
			{
				return raw.ToString();
			}
			if (this._parameters[0] != null && this._parameters[0].Length > 0)
			{
				raw.Append(" ").Append(this._parameters[0]);
			}
			if (this._parameters.Length > 1 && this._parameters[1] != null && this._parameters[1].Length > 0)
			{
				raw.Append(" :").Append(this._parameters[1]);
			}
			return raw.ToString();
		}

		/// <summary>
		/// Command parameters
		/// </summary>
		// Token: 0x0400150A RID: 5386
		private readonly string[] _parameters;

		/// <summary>
		/// The user whose message it is
		/// </summary>
		// Token: 0x0400150B RID: 5387
		public readonly string User;

		/// <summary>
		/// Hostmask of the user
		/// </summary>
		// Token: 0x0400150C RID: 5388
		public readonly string Hostmask;

		/// <summary>
		/// Raw Command
		/// </summary>
		// Token: 0x0400150D RID: 5389
		public readonly IRCCommand Command;

		/// <summary>
		/// IRCv3 tags
		/// </summary>
		// Token: 0x0400150E RID: 5390
		public readonly Dictionary<string, string> Tags;
	}
}
