using System;

namespace Native
{
	// Token: 0x02000061 RID: 97
	internal enum GraphicsItemFlag
	{
		// Token: 0x0400011A RID: 282
		ItemIsMovable = 1,
		// Token: 0x0400011B RID: 283
		ItemIsSelectable,
		// Token: 0x0400011C RID: 284
		ItemIsFocusable = 4,
		// Token: 0x0400011D RID: 285
		ItemClipsToShape = 8,
		// Token: 0x0400011E RID: 286
		ItemClipsChildrenToShape = 16,
		// Token: 0x0400011F RID: 287
		ItemIgnoresTransformations = 32,
		// Token: 0x04000120 RID: 288
		ItemIgnoresParentOpacity = 64,
		// Token: 0x04000121 RID: 289
		ItemDoesntPropagateOpacityToChildren = 128,
		// Token: 0x04000122 RID: 290
		ItemStacksBehindParent = 256,
		// Token: 0x04000123 RID: 291
		ItemUsesExtendedStyleOption = 512,
		// Token: 0x04000124 RID: 292
		ItemHasNoContents = 1024,
		// Token: 0x04000125 RID: 293
		ItemSendsGeometryChanges = 2048,
		// Token: 0x04000126 RID: 294
		ItemAcceptsInputMethod = 4096,
		// Token: 0x04000127 RID: 295
		ItemNegativeZStacksBehindParent = 8192,
		// Token: 0x04000128 RID: 296
		ItemIsPanel = 16384,
		// Token: 0x04000129 RID: 297
		ItemIsFocusScope = 32768,
		// Token: 0x0400012A RID: 298
		ItemSendsScenePositionChanges = 65536,
		// Token: 0x0400012B RID: 299
		ItemStopsClickFocusPropagation = 131072,
		// Token: 0x0400012C RID: 300
		ItemStopsFocusHandling = 262144,
		// Token: 0x0400012D RID: 301
		ItemContainsChildrenInShape = 524288
	}
}
