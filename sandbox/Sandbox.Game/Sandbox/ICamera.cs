using System;

namespace Sandbox
{
	// Token: 0x0200006E RID: 110
	public abstract class ICamera : BaseNetworkable
	{
		// Token: 0x06000C59 RID: 3161
		public abstract void BuildInput(InputBuilder builder);

		// Token: 0x06000C5A RID: 3162
		public abstract void Build(ref CameraSetup camSetup);
	}
}
