using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x02000137 RID: 311
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct AppProofOfPurchaseKeyResponse_t : ICallbackData
	{
		// Token: 0x060008B4 RID: 2228 RVA: 0x0000D95D File Offset: 0x0000BB5D
		internal string KeyUTF8()
		{
			return Encoding.UTF8.GetString(this.Key, 0, Array.IndexOf<byte>(this.Key, 0));
		}

		// Token: 0x1700015E RID: 350
		// (get) Token: 0x060008B5 RID: 2229 RVA: 0x0000D97C File Offset: 0x0000BB7C
		public int DataSize
		{
			get
			{
				return AppProofOfPurchaseKeyResponse_t._datasize;
			}
		}

		// Token: 0x1700015F RID: 351
		// (get) Token: 0x060008B6 RID: 2230 RVA: 0x0000D983 File Offset: 0x0000BB83
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.AppProofOfPurchaseKeyResponse;
			}
		}

		// Token: 0x04000B1D RID: 2845
		internal Result Result;

		// Token: 0x04000B1E RID: 2846
		internal uint AppID;

		// Token: 0x04000B1F RID: 2847
		internal uint CchKeyLength;

		// Token: 0x04000B20 RID: 2848
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)]
		internal byte[] Key;

		// Token: 0x04000B21 RID: 2849
		internal static int _datasize = Marshal.SizeOf(typeof(AppProofOfPurchaseKeyResponse_t));
	}
}
