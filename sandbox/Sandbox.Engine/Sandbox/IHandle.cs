using System;

namespace Sandbox
{
	/// <summary>
	/// A base interface that all handles should use
	/// </summary>
	// Token: 0x020002B0 RID: 688
	internal interface IHandle
	{
		// Token: 0x06001183 RID: 4483
		bool HandleValid();

		// Token: 0x06001184 RID: 4484
		void HandleInit(IntPtr ptr);

		// Token: 0x06001185 RID: 4485
		void HandleDestroy();
	}
}
