using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200010D RID: 269
	internal struct AvailableBeaconLocationsUpdated_t : ICallbackData
	{
		// Token: 0x1700010A RID: 266
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x0000D25E File Offset: 0x0000B45E
		public int DataSize
		{
			get
			{
				return AvailableBeaconLocationsUpdated_t._datasize;
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x0600082E RID: 2094 RVA: 0x0000D265 File Offset: 0x0000B465
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.AvailableBeaconLocationsUpdated;
			}
		}

		// Token: 0x04000A6C RID: 2668
		internal static int _datasize = Marshal.SizeOf(typeof(AvailableBeaconLocationsUpdated_t));
	}
}
