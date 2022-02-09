using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000153 RID: 339
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	internal struct SteamInputConfigurationLoaded_t : ICallbackData
	{
		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x0000DD6C File Offset: 0x0000BF6C
		public int DataSize
		{
			get
			{
				return SteamInputConfigurationLoaded_t._datasize;
			}
		}

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600090A RID: 2314 RVA: 0x0000DD73 File Offset: 0x0000BF73
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.SteamInputConfigurationLoaded;
			}
		}

		// Token: 0x04000B5E RID: 2910
		internal AppId AppID;

		// Token: 0x04000B5F RID: 2911
		internal ulong DeviceHandle;

		// Token: 0x04000B60 RID: 2912
		internal ulong MappingCreator;

		// Token: 0x04000B61 RID: 2913
		internal uint MajorRevision;

		// Token: 0x04000B62 RID: 2914
		internal uint MinorRevision;

		// Token: 0x04000B63 RID: 2915
		[MarshalAs(UnmanagedType.I1)]
		internal bool UsesSteamInputAPI;

		// Token: 0x04000B64 RID: 2916
		[MarshalAs(UnmanagedType.I1)]
		internal bool UsesGamepadAPI;

		// Token: 0x04000B65 RID: 2917
		internal static int _datasize = Marshal.SizeOf(typeof(SteamInputConfigurationLoaded_t));
	}
}
