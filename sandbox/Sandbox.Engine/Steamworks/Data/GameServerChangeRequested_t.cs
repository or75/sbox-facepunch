using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x020000DC RID: 220
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GameServerChangeRequested_t : ICallbackData
	{
		// Token: 0x06000795 RID: 1941 RVA: 0x0000CADF File Offset: 0x0000ACDF
		internal string ServerUTF8()
		{
			return Encoding.UTF8.GetString(this.Server, 0, Array.IndexOf<byte>(this.Server, 0));
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0000CAFE File Offset: 0x0000ACFE
		internal string PasswordUTF8()
		{
			return Encoding.UTF8.GetString(this.Password, 0, Array.IndexOf<byte>(this.Password, 0));
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000797 RID: 1943 RVA: 0x0000CB1D File Offset: 0x0000AD1D
		public int DataSize
		{
			get
			{
				return GameServerChangeRequested_t._datasize;
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000798 RID: 1944 RVA: 0x0000CB24 File Offset: 0x0000AD24
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GameServerChangeRequested;
			}
		}

		// Token: 0x040009BA RID: 2490
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		internal byte[] Server;

		// Token: 0x040009BB RID: 2491
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		internal byte[] Password;

		// Token: 0x040009BC RID: 2492
		internal static int _datasize = Marshal.SizeOf(typeof(GameServerChangeRequested_t));
	}
}
