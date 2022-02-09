using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x02000166 RID: 358
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct WorkshopEULAStatus_t : ICallbackData
	{
		// Token: 0x170001BC RID: 444
		// (get) Token: 0x06000943 RID: 2371 RVA: 0x0000E037 File Offset: 0x0000C237
		public int DataSize
		{
			get
			{
				return WorkshopEULAStatus_t._datasize;
			}
		}

		// Token: 0x170001BD RID: 445
		// (get) Token: 0x06000944 RID: 2372 RVA: 0x0000E03E File Offset: 0x0000C23E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.WorkshopEULAStatus;
			}
		}

		// Token: 0x04000BAC RID: 2988
		internal Result Result;

		// Token: 0x04000BAD RID: 2989
		internal AppId AppID;

		// Token: 0x04000BAE RID: 2990
		internal uint Version;

		// Token: 0x04000BAF RID: 2991
		internal uint TAction;

		// Token: 0x04000BB0 RID: 2992
		[MarshalAs(UnmanagedType.I1)]
		internal bool Accepted;

		// Token: 0x04000BB1 RID: 2993
		[MarshalAs(UnmanagedType.I1)]
		internal bool NeedsAction;

		// Token: 0x04000BB2 RID: 2994
		internal static int _datasize = Marshal.SizeOf(typeof(WorkshopEULAStatus_t));
	}
}
