using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001AA RID: 426
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct P2PSessionState_t
	{
		// Token: 0x04000D0A RID: 3338
		internal byte ConnectionActive;

		// Token: 0x04000D0B RID: 3339
		internal byte Connecting;

		// Token: 0x04000D0C RID: 3340
		internal byte P2PSessionError;

		// Token: 0x04000D0D RID: 3341
		internal byte UsingRelay;

		// Token: 0x04000D0E RID: 3342
		internal int BytesQueuedForSend;

		// Token: 0x04000D0F RID: 3343
		internal int PacketsQueuedForSend;

		// Token: 0x04000D10 RID: 3344
		internal uint RemoteIP;

		// Token: 0x04000D11 RID: 3345
		internal ushort RemotePort;
	}
}
