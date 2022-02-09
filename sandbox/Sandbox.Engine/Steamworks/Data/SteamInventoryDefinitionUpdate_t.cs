using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000182 RID: 386
	internal struct SteamInventoryDefinitionUpdate_t : ICallbackData
	{
		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06000997 RID: 2455 RVA: 0x0000E427 File Offset: 0x0000C627
		public int DataSize
		{
			get
			{
				return SteamInventoryDefinitionUpdate_t._datasize;
			}
		}

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000998 RID: 2456 RVA: 0x0000E42E File Offset: 0x0000C62E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamInventoryDefinitionUpdate;
			}
		}

		// Token: 0x04000C26 RID: 3110
		internal static int _datasize = Marshal.SizeOf(typeof(SteamInventoryDefinitionUpdate_t));
	}
}
