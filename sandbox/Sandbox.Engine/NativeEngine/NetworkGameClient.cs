using System;
using System.Runtime.CompilerServices;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000223 RID: 547
	internal struct NetworkGameClient
	{
		// Token: 0x06000D84 RID: 3460 RVA: 0x00017C63 File Offset: 0x00015E63
		public static implicit operator IntPtr(NetworkGameClient value)
		{
			return value.self;
		}

		// Token: 0x06000D85 RID: 3461 RVA: 0x00017C6C File Offset: 0x00015E6C
		public static implicit operator NetworkGameClient(IntPtr value)
		{
			return new NetworkGameClient
			{
				self = value
			};
		}

		// Token: 0x06000D86 RID: 3462 RVA: 0x00017C8A File Offset: 0x00015E8A
		public static bool operator ==(NetworkGameClient c1, NetworkGameClient c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000D87 RID: 3463 RVA: 0x00017C9D File Offset: 0x00015E9D
		public static bool operator !=(NetworkGameClient c1, NetworkGameClient c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000D88 RID: 3464 RVA: 0x00017CB0 File Offset: 0x00015EB0
		public override bool Equals(object obj)
		{
			if (obj is NetworkGameClient)
			{
				NetworkGameClient c = (NetworkGameClient)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000D89 RID: 3465 RVA: 0x00017CDA File Offset: 0x00015EDA
		internal NetworkGameClient(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000D8A RID: 3466 RVA: 0x00017CE4 File Offset: 0x00015EE4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("NetworkGameClient ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x06000D8B RID: 3467 RVA: 0x00017D20 File Offset: 0x00015F20
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x06000D8C RID: 3468 RVA: 0x00017D32 File Offset: 0x00015F32
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000D8D RID: 3469 RVA: 0x00017D3D File Offset: 0x00015F3D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000D8E RID: 3470 RVA: 0x00017D50 File Offset: 0x00015F50
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("NetworkGameClient was null when calling " + n);
			}
		}

		// Token: 0x06000D8F RID: 3471 RVA: 0x00017D6B File Offset: 0x00015F6B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000D90 RID: 3472 RVA: 0x00017D78 File Offset: 0x00015F78
		internal readonly void SetManaged(INetworkClient pointer)
		{
			this.NullCheck("SetManaged");
			method cnetwr_SetManaged = NetworkGameClient.__N.CNetwr_SetManaged;
			calli(System.Void(System.IntPtr,System.UInt32), this.self, (pointer == null) ? 0U : InteropSystem.GetAddress<INetworkClient>(pointer, true), cnetwr_SetManaged);
		}

		// Token: 0x06000D91 RID: 3473 RVA: 0x00017DB0 File Offset: 0x00015FB0
		internal readonly void FinishSignonState_New()
		{
			this.NullCheck("FinishSignonState_New");
			method cnetwr_FinishSignonState_New = NetworkGameClient.__N.CNetwr_FinishSignonState_New;
			calli(System.Void(System.IntPtr), this.self, cnetwr_FinishSignonState_New);
		}

		// Token: 0x06000D92 RID: 3474 RVA: 0x00017DDC File Offset: 0x00015FDC
		internal readonly void SendCustomMessage(int id, IntPtr data, int dataLen)
		{
			this.NullCheck("SendCustomMessage");
			method cnetwr_SendCustomMessage = NetworkGameClient.__N.CNetwr_SendCustomMessage;
			calli(System.Void(System.IntPtr,System.Int32,System.IntPtr,System.Int32), this.self, id, data, dataLen, cnetwr_SendCustomMessage);
		}

		// Token: 0x04000E3A RID: 3642
		internal IntPtr self;

		// Token: 0x02000388 RID: 904
		internal static class __N
		{
			// Token: 0x040017E9 RID: 6121
			internal static method CNetwr_SetManaged;

			// Token: 0x040017EA RID: 6122
			internal static method CNetwr_FinishSignonState_New;

			// Token: 0x040017EB RID: 6123
			internal static method CNetwr_SendCustomMessage;
		}
	}
}
