using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
	// Token: 0x020002B7 RID: 695
	internal interface INetworkServer
	{
		// Token: 0x1700034E RID: 846
		// (get) Token: 0x0600119D RID: 4509
		int SessionId { get; }

		// Token: 0x0600119E RID: 4510
		void Shutdown();

		// Token: 0x0600119F RID: 4511
		void OnNet(int type, IntPtr data, int len);

		// Token: 0x060011A0 RID: 4512
		void Tick();

		// Token: 0x060011A1 RID: 4513
		string FillServerInfo(string serverInfo);

		// Token: 0x1700034F RID: 847
		// (get) Token: 0x060011A2 RID: 4514 RVA: 0x00023AC3 File Offset: 0x00021CC3
		// (set) Token: 0x060011A3 RID: 4515 RVA: 0x00023ACA File Offset: 0x00021CCA
		List<INetworkServer> All { get; set; } = new List<INetworkServer>();

		// Token: 0x060011A4 RID: 4516 RVA: 0x00023AD4 File Offset: 0x00021CD4
		public static INetworkServer FindBySessionId(int sessionId)
		{
			return INetworkServer.All.FirstOrDefault((INetworkServer x) => x.SessionId == sessionId);
		}

		// Token: 0x060011A5 RID: 4517
		void Disconnect(NetworkDisconnectionReason kicked);
	}
}
