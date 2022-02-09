using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x020000D6 RID: 214
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GameWebCallback_t : ICallbackData
	{
		// Token: 0x06000781 RID: 1921 RVA: 0x0000C9C9 File Offset: 0x0000ABC9
		internal string URLUTF8()
		{
			return Encoding.UTF8.GetString(this.URL, 0, Array.IndexOf<byte>(this.URL, 0));
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000782 RID: 1922 RVA: 0x0000C9E8 File Offset: 0x0000ABE8
		public int DataSize
		{
			get
			{
				return GameWebCallback_t._datasize;
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000783 RID: 1923 RVA: 0x0000C9EF File Offset: 0x0000ABEF
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GameWebCallback;
			}
		}

		// Token: 0x040009A2 RID: 2466
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal byte[] URL;

		// Token: 0x040009A3 RID: 2467
		internal static int _datasize = Marshal.SizeOf(typeof(GameWebCallback_t));
	}
}
