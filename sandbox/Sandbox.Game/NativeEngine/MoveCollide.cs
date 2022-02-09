using System;

namespace NativeEngine
{
	// Token: 0x02000015 RID: 21
	internal enum MoveCollide : byte
	{
		// Token: 0x04000028 RID: 40
		MOVECOLLIDE_DEFAULT,
		// Token: 0x04000029 RID: 41
		MOVECOLLIDE_FLY_BOUNCE,
		// Token: 0x0400002A RID: 42
		MOVECOLLIDE_FLY_CUSTOM,
		// Token: 0x0400002B RID: 43
		MOVECOLLIDE_FLY_SLIDE,
		// Token: 0x0400002C RID: 44
		MOVECOLLIDE_COUNT,
		// Token: 0x0400002D RID: 45
		MOVECOLLIDE_MAX_BITS = 3
	}
}
