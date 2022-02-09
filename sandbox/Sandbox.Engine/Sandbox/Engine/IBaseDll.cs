using System;

namespace Sandbox.Engine
{
	// Token: 0x020002F5 RID: 757
	internal interface IBaseDll
	{
		// Token: 0x0600141B RID: 5147 RVA: 0x0002B211 File Offset: 0x00029411
		void Init()
		{
		}

		// Token: 0x0600141C RID: 5148 RVA: 0x0002B213 File Offset: 0x00029413
		void Tick()
		{
		}

		// Token: 0x0600141D RID: 5149
		void RunEvent(string name);

		// Token: 0x0600141E RID: 5150
		void RunEvent(string name, object argument);

		// Token: 0x0600141F RID: 5151 RVA: 0x0002B215 File Offset: 0x00029415
		void Exiting()
		{
		}
	}
}
