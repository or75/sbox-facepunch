using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200018A RID: 394
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamRemotePlaySessionDisconnected_t : ICallbackData
	{
		// Token: 0x17000204 RID: 516
		// (get) Token: 0x060009B1 RID: 2481 RVA: 0x0000E585 File Offset: 0x0000C785
		public int DataSize
		{
			get
			{
				return SteamRemotePlaySessionDisconnected_t._datasize;
			}
		}

		// Token: 0x17000205 RID: 517
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x0000E58C File Offset: 0x0000C78C
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamRemotePlaySessionDisconnected;
			}
		}

		// Token: 0x04000C3D RID: 3133
		internal uint SessionID;

		// Token: 0x04000C3E RID: 3134
		internal static int _datasize = Marshal.SizeOf(typeof(SteamRemotePlaySessionDisconnected_t));
	}
}
