using System;

namespace Sandbox
{
	/// <summary>
	/// Internal bit flags for glyph styles, matches Steam Input ones.
	/// </summary>
	// Token: 0x020000B0 RID: 176
	[Flags]
	internal enum GlyphStyleMask
	{
		// Token: 0x0400032B RID: 811
		Knockout = 0,
		// Token: 0x0400032C RID: 812
		Light = 1,
		// Token: 0x0400032D RID: 813
		Dark = 2,
		// Token: 0x0400032E RID: 814
		NeutralColorABXY = 16,
		// Token: 0x0400032F RID: 815
		SolidABXY = 32
	}
}
