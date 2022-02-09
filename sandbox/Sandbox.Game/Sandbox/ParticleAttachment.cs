using System;
using Hammer;

namespace Sandbox
{
	// Token: 0x02000079 RID: 121
	public enum ParticleAttachment
	{
		/// <summary>
		/// Invalid particle attachment type.
		/// </summary>
		// Token: 0x040001B9 RID: 441
		[Skip]
		Invalid = -1,
		// Token: 0x040001BA RID: 442
		Origin,
		// Token: 0x040001BB RID: 443
		OriginFollow,
		// Token: 0x040001BC RID: 444
		CustomOrigin,
		// Token: 0x040001BD RID: 445
		CustomOriginFollow,
		// Token: 0x040001BE RID: 446
		Attachment,
		// Token: 0x040001BF RID: 447
		AttachmentFollow,
		// Token: 0x040001C0 RID: 448
		EyesFollow,
		// Token: 0x040001C1 RID: 449
		OverheadFollow,
		// Token: 0x040001C2 RID: 450
		WorldOrigin,
		// Token: 0x040001C3 RID: 451
		RootBoneFollow,
		// Token: 0x040001C4 RID: 452
		RenderOriginFollow,
		// Token: 0x040001C5 RID: 453
		CenterFollow = 13,
		// Token: 0x040001C6 RID: 454
		[Skip]
		Bone,
		// Token: 0x040001C7 RID: 455
		[Skip]
		BoneFollow
	}
}
