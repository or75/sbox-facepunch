using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x02000186 RID: 390
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GetVideoURLResult_t : ICallbackData
	{
		// Token: 0x060009A4 RID: 2468 RVA: 0x0000E4D6 File Offset: 0x0000C6D6
		internal string URLUTF8()
		{
			return Encoding.UTF8.GetString(this.URL, 0, Array.IndexOf<byte>(this.URL, 0));
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x0000E4F5 File Offset: 0x0000C6F5
		public int DataSize
		{
			get
			{
				return GetVideoURLResult_t._datasize;
			}
		}

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x060009A6 RID: 2470 RVA: 0x0000E4FC File Offset: 0x0000C6FC
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GetVideoURLResult;
			}
		}

		// Token: 0x04000C33 RID: 3123
		internal Result Result;

		// Token: 0x04000C34 RID: 3124
		internal AppId VideoAppID;

		// Token: 0x04000C35 RID: 3125
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal byte[] URL;

		// Token: 0x04000C36 RID: 3126
		internal static int _datasize = Marshal.SizeOf(typeof(GetVideoURLResult_t));
	}
}
