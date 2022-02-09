using System;

namespace OpenVR
{
	// Token: 0x02000011 RID: 17
	internal enum VROverlayError
	{
		// Token: 0x040000C6 RID: 198
		None,
		// Token: 0x040000C7 RID: 199
		UnknownOverlay = 10,
		// Token: 0x040000C8 RID: 200
		InvalidHandle,
		// Token: 0x040000C9 RID: 201
		PermissionDenied,
		// Token: 0x040000CA RID: 202
		OverlayLimitExceeded,
		// Token: 0x040000CB RID: 203
		WrongVisibilityType,
		// Token: 0x040000CC RID: 204
		KeyTooLong,
		// Token: 0x040000CD RID: 205
		NameTooLong,
		// Token: 0x040000CE RID: 206
		KeyInUse,
		// Token: 0x040000CF RID: 207
		WrongTransformType,
		// Token: 0x040000D0 RID: 208
		InvalidTrackedDevice,
		// Token: 0x040000D1 RID: 209
		InvalidParameter,
		// Token: 0x040000D2 RID: 210
		ThumbnailCantBeDestroyed,
		// Token: 0x040000D3 RID: 211
		ArrayTooSmall,
		// Token: 0x040000D4 RID: 212
		RequestFailed,
		// Token: 0x040000D5 RID: 213
		InvalidTexture,
		// Token: 0x040000D6 RID: 214
		UnableToLoadFile,
		// Token: 0x040000D7 RID: 215
		KeyboardAlreadyInUse,
		// Token: 0x040000D8 RID: 216
		NoNeighbor,
		// Token: 0x040000D9 RID: 217
		TooManyMaskPrimitives = 29,
		// Token: 0x040000DA RID: 218
		BadMaskPrimitive,
		// Token: 0x040000DB RID: 219
		TextureAlreadyLocked,
		// Token: 0x040000DC RID: 220
		TextureLockCapacityReached,
		// Token: 0x040000DD RID: 221
		TextureNotLocked
	}
}
