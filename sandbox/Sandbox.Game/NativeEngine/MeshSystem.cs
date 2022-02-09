using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000043 RID: 67
	internal static class MeshSystem
	{
		// Token: 0x06000954 RID: 2388 RVA: 0x00036BF8 File Offset: 0x00034DF8
		internal unsafe static SceneObject CreateSceneObject(IModel model, Transform modelToWorld, string pDescName, ESceneObjectFlags nFlags, ESceneObjectTypeFlags nObjectTypeFlags, SceneWorld pWorld)
		{
			method gpMesh_CreateSceneObject = MeshSystem.__N.gpMesh_CreateSceneObject;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr,Transform*,System.IntPtr,System.Int64,System.Int64,System.IntPtr), model, &modelToWorld, Interop.GetPointer(pDescName), nFlags, (ulong)nObjectTypeFlags, (pWorld == null) ? IntPtr.Zero : pWorld.native, gpMesh_CreateSceneObject));
		}

		// Token: 0x020001C8 RID: 456
		internal static class __N
		{
			// Token: 0x04000E7B RID: 3707
			internal static method gpMesh_CreateSceneObject;
		}
	}
}
