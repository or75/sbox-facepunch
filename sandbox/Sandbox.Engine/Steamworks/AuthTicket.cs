using System;

namespace Steamworks
{
	// Token: 0x02000019 RID: 25
	internal class AuthTicket : IDisposable
	{
		/// <summary>
		/// Cancels a ticket. 
		/// You should cancel your ticket when you close the game or leave a server.
		/// </summary>
		// Token: 0x0600001A RID: 26 RVA: 0x00002469 File Offset: 0x00000669
		internal void Cancel()
		{
			if (this.Handle != 0U)
			{
				SteamUser.Internal.CancelAuthTicket(this.Handle);
			}
			this.Handle = 0U;
			this.Data = null;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002496 File Offset: 0x00000696
		public void Dispose()
		{
			this.Cancel();
		}

		// Token: 0x0400011A RID: 282
		internal byte[] Data;

		// Token: 0x0400011B RID: 283
		internal uint Handle;
	}
}
