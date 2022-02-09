using System;

namespace Sandbox.UI
{
	// Token: 0x02000111 RID: 273
	[Flags]
	public enum PseudoClass
	{
		// Token: 0x04000536 RID: 1334
		None = 0,
		// Token: 0x04000537 RID: 1335
		Unknown = 2,
		// Token: 0x04000538 RID: 1336
		Hover = 4,
		// Token: 0x04000539 RID: 1337
		Active = 8,
		// Token: 0x0400053A RID: 1338
		Focus = 16,
		// Token: 0x0400053B RID: 1339
		Intro = 32,
		// Token: 0x0400053C RID: 1340
		Outro = 64,
		// Token: 0x0400053D RID: 1341
		Empty = 128,
		// Token: 0x0400053E RID: 1342
		FirstChild = 256,
		// Token: 0x0400053F RID: 1343
		LastChild = 512,
		// Token: 0x04000540 RID: 1344
		OnlyChild = 1024
	}
}
