using System;

namespace OpenVR
{
	// Token: 0x02000015 RID: 21
	internal enum VRInputError
	{
		// Token: 0x040000FF RID: 255
		None,
		// Token: 0x04000100 RID: 256
		NameNotFound,
		// Token: 0x04000101 RID: 257
		WrongType,
		// Token: 0x04000102 RID: 258
		InvalidHandle,
		// Token: 0x04000103 RID: 259
		InvalidParam,
		// Token: 0x04000104 RID: 260
		NoSteam,
		// Token: 0x04000105 RID: 261
		MaxCapacityReached,
		// Token: 0x04000106 RID: 262
		IPCError,
		// Token: 0x04000107 RID: 263
		NoActiveActionSet,
		// Token: 0x04000108 RID: 264
		InvalidDevice,
		// Token: 0x04000109 RID: 265
		InvalidSkeleton,
		// Token: 0x0400010A RID: 266
		InvalidBoneCount,
		// Token: 0x0400010B RID: 267
		InvalidCompressedData,
		// Token: 0x0400010C RID: 268
		NoData,
		// Token: 0x0400010D RID: 269
		BufferTooSmall,
		// Token: 0x0400010E RID: 270
		MismatchedActionManifest,
		// Token: 0x0400010F RID: 271
		MissingSkeletonData,
		// Token: 0x04000110 RID: 272
		InvalidBoneIndex,
		// Token: 0x04000111 RID: 273
		InvalidPriority,
		// Token: 0x04000112 RID: 274
		PermissionDenied,
		// Token: 0x04000113 RID: 275
		InvalidRenderModel
	}
}
