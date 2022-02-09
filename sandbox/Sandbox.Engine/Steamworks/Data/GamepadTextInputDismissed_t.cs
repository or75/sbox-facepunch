using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020000F3 RID: 243
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct GamepadTextInputDismissed_t : ICallbackData
	{
		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x060007DE RID: 2014 RVA: 0x0000CE97 File Offset: 0x0000B097
		public int DataSize
		{
			get
			{
				return GamepadTextInputDismissed_t._datasize;
			}
		}

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x0000CE9E File Offset: 0x0000B09E
		public CallbackType CallbackType
		{
			get
			{
				return CallbackType.GamepadTextInputDismissed;
			}
		}

		// Token: 0x04000A01 RID: 2561
		[MarshalAs(UnmanagedType.I1)]
		internal bool Submitted;

		// Token: 0x04000A02 RID: 2562
		internal uint SubmittedText;

		// Token: 0x04000A03 RID: 2563
		internal static int _datasize = Marshal.SizeOf(typeof(GamepadTextInputDismissed_t));
	}
}
