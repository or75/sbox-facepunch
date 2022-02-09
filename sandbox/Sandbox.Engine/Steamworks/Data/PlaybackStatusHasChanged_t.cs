using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x0200013E RID: 318
	internal struct PlaybackStatusHasChanged_t : ICallbackData
	{
		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060008CA RID: 2250 RVA: 0x0000DA78 File Offset: 0x0000BC78
		public int DataSize
		{
			get
			{
				return PlaybackStatusHasChanged_t._datasize;
			}
		}

		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060008CB RID: 2251 RVA: 0x0000DA7F File Offset: 0x0000BC7F
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.PlaybackStatusHasChanged;
			}
		}

		// Token: 0x04000B35 RID: 2869
		internal static int _datasize = Marshal.SizeOf(typeof(PlaybackStatusHasChanged_t));
	}
}
