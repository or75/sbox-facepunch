using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000DA RID: 218
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct PersonaStateChange_t : ICallbackData
	{
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600078F RID: 1935 RVA: 0x0000CA97 File Offset: 0x0000AC97
		public int DataSize
		{
			get
			{
				return PersonaStateChange_t._datasize;
			}
		}

		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000790 RID: 1936 RVA: 0x0000CA9E File Offset: 0x0000AC9E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.PersonaStateChange;
			}
		}

		// Token: 0x040009B5 RID: 2485
		internal ulong SteamID;

		// Token: 0x040009B6 RID: 2486
		internal int ChangeFlags;

		// Token: 0x040009B7 RID: 2487
		internal static int _datasize = Marshal.SizeOf(typeof(PersonaStateChange_t));
	}
}
