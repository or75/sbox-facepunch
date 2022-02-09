using System;

namespace Sandbox
{
	// Token: 0x02000091 RID: 145
	public interface INetworkSerializer
	{
		// Token: 0x06000F26 RID: 3878
		void Read(ref NetRead read);

		// Token: 0x06000F27 RID: 3879
		void Write(NetWrite write);
	}
}
