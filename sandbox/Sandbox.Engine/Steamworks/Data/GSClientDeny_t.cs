using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x0200018F RID: 399
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GSClientDeny_t : ICallbackData
	{
		// Token: 0x060009C2 RID: 2498 RVA: 0x0000E677 File Offset: 0x0000C877
		internal string OptionalTextUTF8()
		{
			return Encoding.UTF8.GetString(this.OptionalText, 0, Array.IndexOf<byte>(this.OptionalText, 0));
		}

		// Token: 0x1700020E RID: 526
		// (get) Token: 0x060009C3 RID: 2499 RVA: 0x0000E696 File Offset: 0x0000C896
		public int DataSize
		{
			get
			{
				return GSClientDeny_t._datasize;
			}
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x0000E69D File Offset: 0x0000C89D
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GSClientDeny;
			}
		}

		// Token: 0x04000C4D RID: 3149
		internal ulong SteamID;

		// Token: 0x04000C4E RID: 3150
		internal DenyReason DenyReason;

		// Token: 0x04000C4F RID: 3151
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		internal byte[] OptionalText;

		// Token: 0x04000C50 RID: 3152
		internal static int _datasize = Marshal.SizeOf(typeof(GSClientDeny_t));
	}
}
