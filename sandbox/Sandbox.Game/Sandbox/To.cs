using System;
using System.Collections;
using System.Collections.Generic;

namespace Sandbox
{
	/// <summary>
	/// A wrapper to define which clients to send network things to. This
	/// aims to make code more readable by having the target argument in generated
	/// functions be more obvious and visible.
	/// </summary>
	// Token: 0x020000CD RID: 205
	public struct To : IEnumerable<Client>, IEnumerable
	{
		/// <summary>
		/// Send to a single client (the client owner of this pawn)
		/// </summary>
		// Token: 0x06001268 RID: 4712 RVA: 0x0004DAA1 File Offset: 0x0004BCA1
		public static To Single(Entity pawn)
		{
			return To.Single((pawn != null) ? pawn.Client : null);
		}

		/// <summary>
		/// Send to a single client
		/// </summary>
		// Token: 0x06001269 RID: 4713 RVA: 0x0004DAB4 File Offset: 0x0004BCB4
		public static To Single(Client client)
		{
			return new To
			{
				singleTarget = client
			};
		}

		/// <summary>
		/// Send to multiple clients
		/// </summary>
		// Token: 0x0600126A RID: 4714 RVA: 0x0004DAD4 File Offset: 0x0004BCD4
		public static To Multiple(IEnumerable<Client> clients)
		{
			return new To
			{
				multipleTarget = clients
			};
		}

		/// <summary>
		/// The same as To.Multiple( Client.All )
		/// </summary>
		// Token: 0x17000275 RID: 629
		// (get) Token: 0x0600126B RID: 4715 RVA: 0x0004DAF2 File Offset: 0x0004BCF2
		public static To Everyone
		{
			get
			{
				return To.Multiple(Client.All);
			}
		}

		// Token: 0x0600126C RID: 4716 RVA: 0x0004DAFE File Offset: 0x0004BCFE
		public IEnumerator<Client> GetEnumerator()
		{
			if (this.singleTarget != null)
			{
				yield return this.singleTarget;
			}
			if (this.multipleTarget != null)
			{
				foreach (Client client in this.multipleTarget)
				{
					yield return client;
				}
				IEnumerator<Client> enumerator = null;
			}
			yield break;
			yield break;
		}

		// Token: 0x0600126D RID: 4717 RVA: 0x0004DB12 File Offset: 0x0004BD12
		IEnumerator IEnumerable.GetEnumerator()
		{
			if (this.singleTarget != null)
			{
				yield return this.singleTarget;
			}
			if (this.multipleTarget != null)
			{
				foreach (Client client in this.multipleTarget)
				{
					yield return client;
				}
				IEnumerator<Client> enumerator = null;
			}
			yield break;
			yield break;
		}

		// Token: 0x0600126E RID: 4718 RVA: 0x0004DB28 File Offset: 0x0004BD28
		public void SendCommand(string command)
		{
			foreach (Client client in this)
			{
				if (client != null)
				{
					client.SendCommandToClient(command);
				}
			}
		}

		// Token: 0x040003DA RID: 986
		internal Client singleTarget;

		// Token: 0x040003DB RID: 987
		internal IEnumerable<Client> multipleTarget;
	}
}
