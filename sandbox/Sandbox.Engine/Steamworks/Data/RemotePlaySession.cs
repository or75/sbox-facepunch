using System;

namespace Steamworks.Data
{
	/// <summary>
	/// Represents a RemotePlaySession from the SteamRemotePlay interface
	/// </summary>
	// Token: 0x020001E9 RID: 489
	internal struct RemotePlaySession
	{
		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06000C12 RID: 3090 RVA: 0x000113FA File Offset: 0x0000F5FA
		// (set) Token: 0x06000C13 RID: 3091 RVA: 0x00011402 File Offset: 0x0000F602
		internal uint Id { readonly get; set; }

		// Token: 0x06000C14 RID: 3092 RVA: 0x0001140C File Offset: 0x0000F60C
		public override string ToString()
		{
			return this.Id.ToString();
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x00011428 File Offset: 0x0000F628
		public static implicit operator RemotePlaySession(uint value)
		{
			return new RemotePlaySession
			{
				Id = value
			};
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x00011446 File Offset: 0x0000F646
		public static implicit operator uint(RemotePlaySession value)
		{
			return value.Id;
		}

		/// <summary>
		/// Returns true if this session was valid when created. This will stay true even 
		/// after disconnection - so be sure to watch SteamRemotePlay.OnSessionDisconnected
		/// </summary>
		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06000C17 RID: 3095 RVA: 0x0001144F File Offset: 0x0000F64F
		internal bool IsValid
		{
			get
			{
				return this.Id > 0U;
			}
		}

		/// <summary>
		/// Get the SteamID of the connected user
		/// </summary>
		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x0001145A File Offset: 0x0000F65A
		internal SteamId SteamId
		{
			get
			{
				return SteamRemotePlay.Internal.GetSessionSteamID(this.Id);
			}
		}

		/// <summary>
		/// Get the name of the session client device
		/// </summary>
		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06000C19 RID: 3097 RVA: 0x00011471 File Offset: 0x0000F671
		internal string ClientName
		{
			get
			{
				return SteamRemotePlay.Internal.GetSessionClientName(this.Id);
			}
		}

		/// <summary>
		/// Get the name of the session client device
		/// </summary>
		// Token: 0x1700024F RID: 591
		// (get) Token: 0x06000C1A RID: 3098 RVA: 0x00011488 File Offset: 0x0000F688
		internal SteamDeviceFormFactor FormFactor
		{
			get
			{
				return SteamRemotePlay.Internal.GetSessionClientFormFactor(this.Id);
			}
		}
	}
}
