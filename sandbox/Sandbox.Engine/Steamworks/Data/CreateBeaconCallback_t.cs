using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200010A RID: 266
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct CreateBeaconCallback_t : ICallbackData
	{
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06000824 RID: 2084 RVA: 0x0000D1F2 File Offset: 0x0000B3F2
		public int DataSize
		{
			get
			{
				return CreateBeaconCallback_t._datasize;
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06000825 RID: 2085 RVA: 0x0000D1F9 File Offset: 0x0000B3F9
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.CreateBeaconCallback;
			}
		}

		// Token: 0x04000A64 RID: 2660
		internal Result Result;

		// Token: 0x04000A65 RID: 2661
		internal ulong BeaconID;

		// Token: 0x04000A66 RID: 2662
		internal static int _datasize = Marshal.SizeOf(typeof(CreateBeaconCallback_t));
	}
}
