using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000F5 RID: 245
	internal struct FloatingGamepadTextInputDismissed_t : ICallbackData
	{
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x060007E4 RID: 2020 RVA: 0x0000CEDF File Offset: 0x0000B0DF
		public int DataSize
		{
			get
			{
				return FloatingGamepadTextInputDismissed_t._datasize;
			}
		}

		// Token: 0x170000DB RID: 219
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x0000CEE6 File Offset: 0x0000B0E6
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.FloatingGamepadTextInputDismissed;
			}
		}

		// Token: 0x04000A05 RID: 2565
		internal static int _datasize = Marshal.SizeOf(typeof(FloatingGamepadTextInputDismissed_t));
	}
}
