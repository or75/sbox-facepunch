using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks.Data
{
	// Token: 0x02000109 RID: 265
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct JoinPartyCallback_t : ICallbackData
	{
		// Token: 0x06000820 RID: 2080 RVA: 0x0000D1AF File Offset: 0x0000B3AF
		internal string ConnectStringUTF8()
		{
			return Encoding.UTF8.GetString(this.ConnectString, 0, Array.IndexOf<byte>(this.ConnectString, 0));
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000821 RID: 2081 RVA: 0x0000D1CE File Offset: 0x0000B3CE
		public int DataSize
		{
			get
			{
				return JoinPartyCallback_t._datasize;
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06000822 RID: 2082 RVA: 0x0000D1D5 File Offset: 0x0000B3D5
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.JoinPartyCallback;
			}
		}

		// Token: 0x04000A5F RID: 2655
		internal Result Result;

		// Token: 0x04000A60 RID: 2656
		internal ulong BeaconID;

		// Token: 0x04000A61 RID: 2657
		internal ulong SteamIDBeaconOwner;

		// Token: 0x04000A62 RID: 2658
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
		internal byte[] ConnectString;

		// Token: 0x04000A63 RID: 2659
		internal static int _datasize = Marshal.SizeOf(typeof(JoinPartyCallback_t));
	}
}
