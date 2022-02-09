using System;

namespace Tools
{
	// Token: 0x02000097 RID: 151
	internal enum DockWidgetFeatures
	{
		// Token: 0x040001FC RID: 508
		DockWidgetClosable = 1,
		// Token: 0x040001FD RID: 509
		DockWidgetMovable,
		// Token: 0x040001FE RID: 510
		DockWidgetFloatable = 4,
		// Token: 0x040001FF RID: 511
		DockWidgetVerticalTitleBar = 8,
		// Token: 0x04000200 RID: 512
		DockWidgetFeatureMask = 15,
		// Token: 0x04000201 RID: 513
		NoDockWidgetFeatures = 0,
		// Token: 0x04000202 RID: 514
		Reserved = 255
	}
}
