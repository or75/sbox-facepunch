using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000229 RID: 553
	internal struct ServerSideClient
	{
		// Token: 0x06000DFD RID: 3581 RVA: 0x00018AFA File Offset: 0x00016CFA
		public static implicit operator IntPtr(ServerSideClient value)
		{
			return value.self;
		}

		// Token: 0x06000DFE RID: 3582 RVA: 0x00018B04 File Offset: 0x00016D04
		public static implicit operator ServerSideClient(IntPtr value)
		{
			return new ServerSideClient
			{
				self = value
			};
		}

		// Token: 0x06000DFF RID: 3583 RVA: 0x00018B22 File Offset: 0x00016D22
		public static bool operator ==(ServerSideClient c1, ServerSideClient c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000E00 RID: 3584 RVA: 0x00018B35 File Offset: 0x00016D35
		public static bool operator !=(ServerSideClient c1, ServerSideClient c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000E01 RID: 3585 RVA: 0x00018B48 File Offset: 0x00016D48
		public override bool Equals(object obj)
		{
			if (obj is ServerSideClient)
			{
				ServerSideClient c = (ServerSideClient)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000E02 RID: 3586 RVA: 0x00018B72 File Offset: 0x00016D72
		internal ServerSideClient(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000E03 RID: 3587 RVA: 0x00018B7C File Offset: 0x00016D7C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("ServerSideClient ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x06000E04 RID: 3588 RVA: 0x00018BB8 File Offset: 0x00016DB8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x06000E05 RID: 3589 RVA: 0x00018BCA File Offset: 0x00016DCA
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000E06 RID: 3590 RVA: 0x00018BD5 File Offset: 0x00016DD5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000E07 RID: 3591 RVA: 0x00018BE8 File Offset: 0x00016DE8
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("ServerSideClient was null when calling " + n);
			}
		}

		// Token: 0x06000E08 RID: 3592 RVA: 0x00018C03 File Offset: 0x00016E03
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000E09 RID: 3593 RVA: 0x00018C10 File Offset: 0x00016E10
		internal readonly void SetManaged(INetworkServer pointer)
		{
			this.NullCheck("SetManaged");
			method cserve_SetManaged = ServerSideClient.__N.CServe_SetManaged;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, (pointer == null) ? 0U : InteropSystem.GetAddress<INetworkServer>(pointer, true), cserve_SetManaged);
		}

		// Token: 0x06000E0A RID: 3594 RVA: 0x00018C48 File Offset: 0x00016E48
		internal readonly void SendCustomMessage(int id, IntPtr data, int dataLen)
		{
			this.NullCheck("SendCustomMessage");
			method cserve_SendCustomMessage = ServerSideClient.__N.CServe_SendCustomMessage;
			calli(System.Void(System.IntPtr,System.Int32,System.IntPtr,System.Int32), this.self, id, data, dataLen, cserve_SendCustomMessage);
		}

		// Token: 0x06000E0B RID: 3595 RVA: 0x00018C78 File Offset: 0x00016E78
		internal readonly int GetPlayerSlot()
		{
			this.NullCheck("GetPlayerSlot");
			method cserve_GetPlayerSlot = ServerSideClient.__N.CServe_GetPlayerSlot;
			return calli(System.Int32(System.IntPtr), this.self, cserve_GetPlayerSlot);
		}

		// Token: 0x06000E0C RID: 3596 RVA: 0x00018CA4 File Offset: 0x00016EA4
		internal readonly string GetClientName()
		{
			this.NullCheck("GetClientName");
			method cserve_GetClientName = ServerSideClient.__N.CServe_GetClientName;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, cserve_GetClientName));
		}

		// Token: 0x06000E0D RID: 3597 RVA: 0x00018CD4 File Offset: 0x00016ED4
		internal readonly int GetUserId()
		{
			this.NullCheck("GetUserId");
			method cserve_GetUserId = ServerSideClient.__N.CServe_GetUserId;
			return calli(System.Int32(System.IntPtr), this.self, cserve_GetUserId);
		}

		// Token: 0x06000E0E RID: 3598 RVA: 0x00018D00 File Offset: 0x00016F00
		internal readonly int PendingReliable()
		{
			this.NullCheck("PendingReliable");
			method cserve_PendingReliable = ServerSideClient.__N.CServe_PendingReliable;
			return calli(System.Int32(System.IntPtr), this.self, cserve_PendingReliable);
		}

		// Token: 0x06000E0F RID: 3599 RVA: 0x00018D2C File Offset: 0x00016F2C
		internal readonly void Disconnect(NetworkDisconnectionReason reason)
		{
			this.NullCheck("Disconnect");
			method cserve_Disconnect = ServerSideClient.__N.CServe_Disconnect;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)reason, cserve_Disconnect);
		}

		// Token: 0x04000E40 RID: 3648
		internal IntPtr self;

		// Token: 0x0200038E RID: 910
		internal static class __N
		{
			// Token: 0x0400181A RID: 6170
			internal static method CServe_SetManaged;

			// Token: 0x0400181B RID: 6171
			internal static method CServe_SendCustomMessage;

			// Token: 0x0400181C RID: 6172
			internal static method CServe_GetPlayerSlot;

			// Token: 0x0400181D RID: 6173
			internal static method CServe_GetClientName;

			// Token: 0x0400181E RID: 6174
			internal static method CServe_GetUserId;

			// Token: 0x0400181F RID: 6175
			internal static method CServe_PendingReliable;

			// Token: 0x04001820 RID: 6176
			internal static method CServe_Disconnect;
		}
	}
}
