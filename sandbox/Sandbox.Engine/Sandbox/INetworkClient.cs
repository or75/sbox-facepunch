using System;

namespace Sandbox
{
	// Token: 0x020002B6 RID: 694
	internal interface INetworkClient
	{
		// Token: 0x06001196 RID: 4502
		void Shutdown();

		// Token: 0x06001197 RID: 4503
		void OnNet(int type, IntPtr data, int len);

		// Token: 0x06001198 RID: 4504
		bool ProcessServerInfo(string manifest, string mapname);

		// Token: 0x06001199 RID: 4505
		void SignOnState_New(bool playingDemo, bool isListenServer);

		// Token: 0x0600119A RID: 4506
		void SignOnState_Full();

		// Token: 0x0600119B RID: 4507
		void Tick();

		// Token: 0x0600119C RID: 4508
		void OnFullConnect(string address);
	}
}
