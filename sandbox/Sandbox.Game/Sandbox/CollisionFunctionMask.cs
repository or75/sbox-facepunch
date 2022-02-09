using System;

namespace Sandbox
{
	// Token: 0x020000D2 RID: 210
	[Flags]
	internal enum CollisionFunctionMask : byte
	{
		// Token: 0x040003EB RID: 1003
		EnableSolidContact = 1,
		// Token: 0x040003EC RID: 1004
		EnableTraceQuery = 2,
		// Token: 0x040003ED RID: 1005
		EnableTouchEvent = 4,
		// Token: 0x040003EE RID: 1006
		EnableSelfCollisions = 8,
		// Token: 0x040003EF RID: 1007
		IgnoreForHitboxTest = 16,
		// Token: 0x040003F0 RID: 1008
		EnableTouchPersists = 32
	}
}
