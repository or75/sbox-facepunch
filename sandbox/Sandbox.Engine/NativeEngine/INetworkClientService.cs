using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000240 RID: 576
	internal struct INetworkClientService
	{
		// Token: 0x06000EBA RID: 3770 RVA: 0x0001A172 File Offset: 0x00018372
		public static implicit operator IntPtr(INetworkClientService value)
		{
			return value.self;
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x0001A17C File Offset: 0x0001837C
		public static implicit operator INetworkClientService(IntPtr value)
		{
			return new INetworkClientService
			{
				self = value
			};
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x0001A19A File Offset: 0x0001839A
		public static bool operator ==(INetworkClientService c1, INetworkClientService c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x0001A1AD File Offset: 0x000183AD
		public static bool operator !=(INetworkClientService c1, INetworkClientService c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x0001A1C0 File Offset: 0x000183C0
		public override bool Equals(object obj)
		{
			if (obj is INetworkClientService)
			{
				INetworkClientService c = (INetworkClientService)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x0001A1EA File Offset: 0x000183EA
		internal INetworkClientService(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x0001A1F4 File Offset: 0x000183F4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 1);
			defaultInterpolatedStringHandler.AppendLiteral("INetworkClientService ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x06000EC1 RID: 3777 RVA: 0x0001A230 File Offset: 0x00018430
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x06000EC2 RID: 3778 RVA: 0x0001A242 File Offset: 0x00018442
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x0001A24D File Offset: 0x0001844D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x0001A260 File Offset: 0x00018460
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("INetworkClientService was null when calling " + n);
			}
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x0001A27B File Offset: 0x0001847B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x0001A288 File Offset: 0x00018488
		internal readonly bool IsActiveInGame()
		{
			this.NullCheck("IsActiveInGame");
			method inetwr_IsActiveInGame = INetworkClientService.__N.INetwr_IsActiveInGame;
			return calli(System.Int32(System.IntPtr), this.self, inetwr_IsActiveInGame) > 0;
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x0001A2B8 File Offset: 0x000184B8
		internal readonly bool IsConnected()
		{
			this.NullCheck("IsConnected");
			method inetwr_IsConnected = INetworkClientService.__N.INetwr_IsConnected;
			return calli(System.Int32(System.IntPtr), this.self, inetwr_IsConnected) > 0;
		}

		// Token: 0x06000EC8 RID: 3784 RVA: 0x0001A2E8 File Offset: 0x000184E8
		internal readonly bool IsMultiplayer()
		{
			this.NullCheck("IsMultiplayer");
			method inetwr_IsMultiplayer = INetworkClientService.__N.INetwr_IsMultiplayer;
			return calli(System.Int32(System.IntPtr), this.self, inetwr_IsMultiplayer) > 0;
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x0001A318 File Offset: 0x00018518
		internal readonly bool IsPaused()
		{
			this.NullCheck("IsPaused");
			method inetwr_IsPaused = INetworkClientService.__N.INetwr_IsPaused;
			return calli(System.Int32(System.IntPtr), this.self, inetwr_IsPaused) > 0;
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x0001A348 File Offset: 0x00018548
		internal readonly bool IsDisconnecting()
		{
			this.NullCheck("IsDisconnecting");
			method inetwr_IsDisconnecting = INetworkClientService.__N.INetwr_IsDisconnecting;
			return calli(System.Int32(System.IntPtr), this.self, inetwr_IsDisconnecting) > 0;
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x0001A378 File Offset: 0x00018578
		internal readonly string GetDisconnectReason()
		{
			this.NullCheck("GetDisconnectReason");
			method inetwr_GetDisconnectReason = INetworkClientService.__N.INetwr_GetDisconnectReason;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, inetwr_GetDisconnectReason));
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x0001A3A8 File Offset: 0x000185A8
		internal readonly void SendStringCmd(InputCommandSource nSlot, string szCmdString)
		{
			this.NullCheck("SendStringCmd");
			method inetwr_SendStringCmd = INetworkClientService.__N.INetwr_SendStringCmd;
			calli(System.Void(System.IntPtr,System.Int64,System.IntPtr), this.self, (long)nSlot, Interop.GetPointer(szCmdString), inetwr_SendStringCmd);
		}

		// Token: 0x04000E46 RID: 3654
		internal IntPtr self;

		// Token: 0x020003A5 RID: 933
		internal static class __N
		{
			// Token: 0x0400188F RID: 6287
			internal static method INetwr_IsActiveInGame;

			// Token: 0x04001890 RID: 6288
			internal static method INetwr_IsConnected;

			// Token: 0x04001891 RID: 6289
			internal static method INetwr_IsMultiplayer;

			// Token: 0x04001892 RID: 6290
			internal static method INetwr_IsPaused;

			// Token: 0x04001893 RID: 6291
			internal static method INetwr_IsDisconnecting;

			// Token: 0x04001894 RID: 6292
			internal static method INetwr_GetDisconnectReason;

			// Token: 0x04001895 RID: 6293
			internal static method INetwr_SendStringCmd;
		}
	}
}
