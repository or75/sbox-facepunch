using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x020000D7 RID: 215
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct StoreAuthURLResponse_t : ICallbackData
	{
		// Token: 0x06000785 RID: 1925 RVA: 0x0000CA0C File Offset: 0x0000AC0C
		internal string URLUTF8()
		{
			return Encoding.UTF8.GetString(this.URL, 0, Array.IndexOf<byte>(this.URL, 0));
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x0000CA2B File Offset: 0x0000AC2B
		public int DataSize
		{
			get
			{
				return StoreAuthURLResponse_t._datasize;
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000787 RID: 1927 RVA: 0x0000CA32 File Offset: 0x0000AC32
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.StoreAuthURLResponse;
			}
		}

		// Token: 0x040009A4 RID: 2468
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
		internal byte[] URL;

		// Token: 0x040009A5 RID: 2469
		internal static int _datasize = Marshal.SizeOf(typeof(StoreAuthURLResponse_t));
	}
}
