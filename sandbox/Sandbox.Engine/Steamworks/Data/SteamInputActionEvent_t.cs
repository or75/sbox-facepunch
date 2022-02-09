using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001AB RID: 427
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamInputActionEvent_t
	{
		// Token: 0x04000D12 RID: 3346
		internal ulong ControllerHandle;

		// Token: 0x04000D13 RID: 3347
		internal SteamInputActionEventType EEventType;
	}
}
