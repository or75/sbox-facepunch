using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200013F RID: 319
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct VolumeHasChanged_t : ICallbackData
	{
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060008CD RID: 2253 RVA: 0x0000DA9C File Offset: 0x0000BC9C
		public int DataSize
		{
			get
			{
				return VolumeHasChanged_t._datasize;
			}
		}

		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060008CE RID: 2254 RVA: 0x0000DAA3 File Offset: 0x0000BCA3
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.VolumeHasChanged;
			}
		}

		// Token: 0x04000B36 RID: 2870
		internal float NewVolume;

		// Token: 0x04000B37 RID: 2871
		internal static int _datasize = Marshal.SizeOf(typeof(VolumeHasChanged_t));
	}
}
