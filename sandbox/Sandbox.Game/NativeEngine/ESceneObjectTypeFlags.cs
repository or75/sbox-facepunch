using System;

namespace NativeEngine
{
	// Token: 0x02000017 RID: 23
	[Flags]
	internal enum ESceneObjectTypeFlags : uint
	{
		// Token: 0x0400007A RID: 122
		NONE = 0U,
		// Token: 0x0400007B RID: 123
		IS_PROCEDURAL = 1U,
		// Token: 0x0400007C RID: 124
		FROM_POOL = 2U,
		// Token: 0x0400007D RID: 125
		HAS_MESH_INSTANCE_DATA = 4U,
		// Token: 0x0400007E RID: 126
		DELETE_MESH_INSTANCE_DATA = 8U,
		// Token: 0x0400007F RID: 127
		NOT_BATCHABLE = 16U,
		/// For objects that can't be considered to be "owned" by the world they are in because they
		/// are owned by a manager. All this flag does is cause a warning when such an object is still
		/// in the world at world deletion time (a leak).
		// Token: 0x04000080 RID: 128
		SHOULD_BE_DELETED_BEFORE_WORLD = 32U,
		/// if this flag is set, then the object will not be deleted when deleting the world, and will not be queued for delete. It's assumed that this object is going to be deleted inside of the destructor of another sceneobject
		// Token: 0x04000081 RID: 129
		OWNED_BY_ANOTHER_SCENEOBJECT = 64U,
		/// We have a mixture of alpha-blended and non-alpha blended draws
		// Token: 0x04000082 RID: 130
		PARTIALLY_ALPHA_BLENDED = 128U,
		/// A unique batch flag that allows objects to draw in a separate batch from their original group
		// Token: 0x04000083 RID: 131
		UNIQUE_BATCH_GROUP = 256U
	}
}
