using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000245 RID: 581
	internal static class MeshGlue
	{
		// Token: 0x06000F1C RID: 3868 RVA: 0x0001ADE0 File Offset: 0x00018FE0
		internal static IMesh CreateRenderMesh(IMaterial material, int nPrimType)
		{
			method meshGl_CreateRenderMesh = MeshGlue.__N.MeshGl_CreateRenderMesh;
			return calli(System.IntPtr(System.IntPtr,System.Int32), material, nPrimType, meshGl_CreateRenderMesh);
		}

		// Token: 0x06000F1D RID: 3869 RVA: 0x0001AE08 File Offset: 0x00019008
		internal unsafe static IModel CreateModel(IMesh[] ArrayOfmeshes, int numMeshes)
		{
			if (ArrayOfmeshes == null)
			{
				IMesh* ArrayOfmeshes_array_ptr = null;
				method meshGl_CreateModel = MeshGlue.__N.MeshGl_CreateModel;
				return calli(System.IntPtr(NativeEngine.IMesh*,System.Int32), ArrayOfmeshes_array_ptr, numMeshes, meshGl_CreateModel);
			}
			fixed (IMesh* ptr = &ArrayOfmeshes[0])
			{
				IMesh* ArrayOfmeshes_array_ptr2 = ptr;
				method meshGl_CreateModel = MeshGlue.__N.MeshGl_CreateModel;
				return calli(System.IntPtr(NativeEngine.IMesh*,System.Int32), ArrayOfmeshes_array_ptr2, numMeshes, meshGl_CreateModel);
			}
		}

		// Token: 0x06000F1E RID: 3870 RVA: 0x0001AE50 File Offset: 0x00019050
		internal static IModel CreateModel2(float mass, bool bHullFromRender, bool bMeshFromRender, string surfaceProp, float lodSwitchDistance, IntPtr meshes, int numMeshes, IntPtr lodMasks, IntPtr vertices, int numVertices, IntPtr indices, int numIndices, IntPtr spheres, int numSpheres, IntPtr capsules, int numCapsules, IntPtr boxes, int numBoxes, IntPtr hulls, int numHulls, IntPtr meshShapes, int numMeshShapes, IntPtr bones, int numBones, string boneNames)
		{
			method meshGl_CreateModel = MeshGlue.__N.MeshGl_CreateModel2;
			return calli(System.IntPtr(System.Single,System.Int32,System.Int32,System.UInt32,System.Single,System.IntPtr,System.Int32,System.IntPtr,System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr), mass, bHullFromRender ? 1 : 0, bMeshFromRender ? 1 : 0, StringToken.FindOrCreate(surfaceProp), lodSwitchDistance, meshes, numMeshes, lodMasks, vertices, numVertices, indices, numIndices, spheres, numSpheres, capsules, numCapsules, boxes, numBoxes, hulls, numHulls, meshShapes, numMeshShapes, bones, numBones, Interop.GetPointer(boneNames), meshGl_CreateModel);
		}

		// Token: 0x06000F1F RID: 3871 RVA: 0x0001AEB4 File Offset: 0x000190B4
		internal static IModel CreateRawModel(string modelName, IMaterial materialName, IntPtr vertices, uint numVertices, IntPtr indices, uint numIndices, bool bCreateCollision)
		{
			method meshGl_CreateRawModel = MeshGlue.__N.MeshGl_CreateRawModel;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr,System.IntPtr,System.UInt32,System.IntPtr,System.UInt32,System.Int32), Interop.GetPointer(modelName), materialName, vertices, numVertices, indices, numIndices, bCreateCollision ? 1 : 0, meshGl_CreateRawModel);
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x0001AEEC File Offset: 0x000190EC
		internal static int GetModelNumVertices(IModel model)
		{
			method meshGl_GetModelNumVertices = MeshGlue.__N.MeshGl_GetModelNumVertices;
			return calli(System.Int32(System.IntPtr), model, meshGl_GetModelNumVertices);
		}

		// Token: 0x06000F21 RID: 3873 RVA: 0x0001AF0C File Offset: 0x0001910C
		internal static void GetModelVertices(IModel model, IntPtr vertices, uint numVertices)
		{
			method meshGl_GetModelVertices = MeshGlue.__N.MeshGl_GetModelVertices;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32), model, vertices, numVertices, meshGl_GetModelVertices);
		}

		// Token: 0x06000F22 RID: 3874 RVA: 0x0001AF30 File Offset: 0x00019130
		internal static int GetModelNumIndices(IModel model)
		{
			method meshGl_GetModelNumIndices = MeshGlue.__N.MeshGl_GetModelNumIndices;
			return calli(System.Int32(System.IntPtr), model, meshGl_GetModelNumIndices);
		}

		// Token: 0x06000F23 RID: 3875 RVA: 0x0001AF50 File Offset: 0x00019150
		internal static void GetModelIndices(IModel model, IntPtr indices, uint numIndices)
		{
			method meshGl_GetModelIndices = MeshGlue.__N.MeshGl_GetModelIndices;
			calli(System.Void(System.IntPtr,System.IntPtr,System.UInt32), model, indices, numIndices, meshGl_GetModelIndices);
		}

		// Token: 0x06000F24 RID: 3876 RVA: 0x0001AF74 File Offset: 0x00019174
		internal static void SetMeshMaterial(IMesh renderMesh, IMaterial material)
		{
			method meshGl_SetMeshMaterial = MeshGlue.__N.MeshGl_SetMeshMaterial;
			calli(System.Void(System.IntPtr,System.IntPtr), renderMesh, material, meshGl_SetMeshMaterial);
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x0001AF9C File Offset: 0x0001919C
		internal static void SetMeshPrimType(IMesh renderMesh, int nPrimType)
		{
			method meshGl_SetMeshPrimType = MeshGlue.__N.MeshGl_SetMeshPrimType;
			calli(System.Void(System.IntPtr,System.Int32), renderMesh, nPrimType, meshGl_SetMeshPrimType);
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x0001AFBC File Offset: 0x000191BC
		internal unsafe static void SetMeshBounds(IMesh renderMesh, Vector3 mins, Vector3 maxs)
		{
			method meshGl_SetMeshBounds = MeshGlue.__N.MeshGl_SetMeshBounds;
			calli(System.Void(System.IntPtr,Vector3*,Vector3*), renderMesh, &mins, &maxs, meshGl_SetMeshBounds);
		}

		// Token: 0x06000F27 RID: 3879 RVA: 0x0001AFE4 File Offset: 0x000191E4
		internal static void SetMeshVertexRange(IMesh renderMesh, int startVertex, int vertexCount)
		{
			method meshGl_SetMeshVertexRange = MeshGlue.__N.MeshGl_SetMeshVertexRange;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), renderMesh, startVertex, vertexCount, meshGl_SetMeshVertexRange);
		}

		// Token: 0x06000F28 RID: 3880 RVA: 0x0001B008 File Offset: 0x00019208
		internal static void SetMeshIndexRange(IMesh renderMesh, int startIndex, int indexCount)
		{
			method meshGl_SetMeshIndexRange = MeshGlue.__N.MeshGl_SetMeshIndexRange;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), renderMesh, startIndex, indexCount, meshGl_SetMeshIndexRange);
		}

		// Token: 0x06000F29 RID: 3881 RVA: 0x0001B02C File Offset: 0x0001922C
		internal static void SetMeshVertexBuffer(IMesh renderMesh, IntPtr hVB, bool bShared)
		{
			method meshGl_SetMeshVertexBuffer = MeshGlue.__N.MeshGl_SetMeshVertexBuffer;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), renderMesh, hVB, bShared ? 1 : 0, meshGl_SetMeshVertexBuffer);
		}

		// Token: 0x06000F2A RID: 3882 RVA: 0x0001B054 File Offset: 0x00019254
		internal static void SetMeshIndexBuffer(IMesh renderMesh, IntPtr hIB, bool bShared)
		{
			method meshGl_SetMeshIndexBuffer = MeshGlue.__N.MeshGl_SetMeshIndexBuffer;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), renderMesh, hIB, bShared ? 1 : 0, meshGl_SetMeshIndexBuffer);
		}

		// Token: 0x06000F2B RID: 3883 RVA: 0x0001B07C File Offset: 0x0001927C
		internal static IntPtr CreateVertexBuffer(int nElementSizeInBytes, int nElementCount, string fieldNames, IntPtr pFields, int nFields, IntPtr pData, int nDataSize)
		{
			method meshGl_CreateVertexBuffer = MeshGlue.__N.MeshGl_CreateVertexBuffer;
			return calli(System.IntPtr(System.Int32,System.Int32,System.IntPtr,System.IntPtr,System.Int32,System.IntPtr,System.Int32), nElementSizeInBytes, nElementCount, Interop.GetPointer(fieldNames), pFields, nFields, pData, nDataSize, meshGl_CreateVertexBuffer);
		}

		// Token: 0x06000F2C RID: 3884 RVA: 0x0001B0A4 File Offset: 0x000192A4
		internal static IntPtr CreateIndexBuffer(int nElementCount, bool b32Bit, IntPtr pData, int nDataSize)
		{
			method meshGl_CreateIndexBuffer = MeshGlue.__N.MeshGl_CreateIndexBuffer;
			return calli(System.IntPtr(System.Int32,System.Int32,System.IntPtr,System.Int32), nElementCount, b32Bit ? 1 : 0, pData, nDataSize, meshGl_CreateIndexBuffer);
		}

		// Token: 0x06000F2D RID: 3885 RVA: 0x0001B0C8 File Offset: 0x000192C8
		internal static void DestroyVertexBuffer(IntPtr hVB)
		{
			method meshGl_DestroyVertexBuffer = MeshGlue.__N.MeshGl_DestroyVertexBuffer;
			calli(System.Void(System.IntPtr), hVB, meshGl_DestroyVertexBuffer);
		}

		// Token: 0x06000F2E RID: 3886 RVA: 0x0001B0E4 File Offset: 0x000192E4
		internal static void DestroyIndexBuffer(IntPtr hIB)
		{
			method meshGl_DestroyIndexBuffer = MeshGlue.__N.MeshGl_DestroyIndexBuffer;
			calli(System.Void(System.IntPtr), hIB, meshGl_DestroyIndexBuffer);
		}

		// Token: 0x06000F2F RID: 3887 RVA: 0x0001B100 File Offset: 0x00019300
		internal static IntPtr LockVertexBuffer(IntPtr hVB, int nDataSize, int nDataOffset)
		{
			method meshGl_LockVertexBuffer = MeshGlue.__N.MeshGl_LockVertexBuffer;
			return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32), hVB, nDataSize, nDataOffset, meshGl_LockVertexBuffer);
		}

		// Token: 0x06000F30 RID: 3888 RVA: 0x0001B11C File Offset: 0x0001931C
		internal static void UnlockVertexBuffer(IntPtr hVB, IntPtr pData, int nDataSize, int nDataOffset)
		{
			method meshGl_UnlockVertexBuffer = MeshGlue.__N.MeshGl_UnlockVertexBuffer;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32,System.Int32), hVB, pData, nDataSize, nDataOffset, meshGl_UnlockVertexBuffer);
		}

		// Token: 0x06000F31 RID: 3889 RVA: 0x0001B13C File Offset: 0x0001933C
		internal static IntPtr LockIndexBuffer(IntPtr hIB, int nDataSize, int nDataOffset)
		{
			method meshGl_LockIndexBuffer = MeshGlue.__N.MeshGl_LockIndexBuffer;
			return calli(System.IntPtr(System.IntPtr,System.Int32,System.Int32), hIB, nDataSize, nDataOffset, meshGl_LockIndexBuffer);
		}

		// Token: 0x06000F32 RID: 3890 RVA: 0x0001B158 File Offset: 0x00019358
		internal static void UnlockIndexBuffer(IntPtr hIB, IntPtr pData, int nDataSize, int nDataOffset)
		{
			method meshGl_UnlockIndexBuffer = MeshGlue.__N.MeshGl_UnlockIndexBuffer;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32,System.Int32), hIB, pData, nDataSize, nDataOffset, meshGl_UnlockIndexBuffer);
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x0001B178 File Offset: 0x00019378
		internal static void SetVertexBufferData(IntPtr hVB, IntPtr pData, int nDataSize, int nDataOffset)
		{
			method meshGl_SetVertexBufferData = MeshGlue.__N.MeshGl_SetVertexBufferData;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32,System.Int32), hVB, pData, nDataSize, nDataOffset, meshGl_SetVertexBufferData);
		}

		// Token: 0x06000F34 RID: 3892 RVA: 0x0001B198 File Offset: 0x00019398
		internal static void SetIndexBufferData(IntPtr hIB, IntPtr pData, int nDataSize, int nDataOffset)
		{
			method meshGl_SetIndexBufferData = MeshGlue.__N.MeshGl_SetIndexBufferData;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32,System.Int32), hIB, pData, nDataSize, nDataOffset, meshGl_SetIndexBufferData);
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x0001B1B8 File Offset: 0x000193B8
		internal static IntPtr SetVertexBufferSize(IntPtr hVB, int nDataSize)
		{
			method meshGl_SetVertexBufferSize = MeshGlue.__N.MeshGl_SetVertexBufferSize;
			return calli(System.IntPtr(System.IntPtr,System.Int32), hVB, nDataSize, meshGl_SetVertexBufferSize);
		}

		// Token: 0x06000F36 RID: 3894 RVA: 0x0001B1D4 File Offset: 0x000193D4
		internal static IntPtr SetIndexBufferSize(IntPtr hIB, int nDataSize)
		{
			method meshGl_SetIndexBufferSize = MeshGlue.__N.MeshGl_SetIndexBufferSize;
			return calli(System.IntPtr(System.IntPtr,System.Int32), hIB, nDataSize, meshGl_SetIndexBufferSize);
		}

		// Token: 0x020003AA RID: 938
		internal static class __N
		{
			// Token: 0x040018B5 RID: 6325
			internal static method MeshGl_CreateRenderMesh;

			// Token: 0x040018B6 RID: 6326
			internal static method MeshGl_CreateModel;

			// Token: 0x040018B7 RID: 6327
			internal static method MeshGl_CreateModel2;

			// Token: 0x040018B8 RID: 6328
			internal static method MeshGl_CreateRawModel;

			// Token: 0x040018B9 RID: 6329
			internal static method MeshGl_GetModelNumVertices;

			// Token: 0x040018BA RID: 6330
			internal static method MeshGl_GetModelVertices;

			// Token: 0x040018BB RID: 6331
			internal static method MeshGl_GetModelNumIndices;

			// Token: 0x040018BC RID: 6332
			internal static method MeshGl_GetModelIndices;

			// Token: 0x040018BD RID: 6333
			internal static method MeshGl_SetMeshMaterial;

			// Token: 0x040018BE RID: 6334
			internal static method MeshGl_SetMeshPrimType;

			// Token: 0x040018BF RID: 6335
			internal static method MeshGl_SetMeshBounds;

			// Token: 0x040018C0 RID: 6336
			internal static method MeshGl_SetMeshVertexRange;

			// Token: 0x040018C1 RID: 6337
			internal static method MeshGl_SetMeshIndexRange;

			// Token: 0x040018C2 RID: 6338
			internal static method MeshGl_SetMeshVertexBuffer;

			// Token: 0x040018C3 RID: 6339
			internal static method MeshGl_SetMeshIndexBuffer;

			// Token: 0x040018C4 RID: 6340
			internal static method MeshGl_CreateVertexBuffer;

			// Token: 0x040018C5 RID: 6341
			internal static method MeshGl_CreateIndexBuffer;

			// Token: 0x040018C6 RID: 6342
			internal static method MeshGl_DestroyVertexBuffer;

			// Token: 0x040018C7 RID: 6343
			internal static method MeshGl_DestroyIndexBuffer;

			// Token: 0x040018C8 RID: 6344
			internal static method MeshGl_LockVertexBuffer;

			// Token: 0x040018C9 RID: 6345
			internal static method MeshGl_UnlockVertexBuffer;

			// Token: 0x040018CA RID: 6346
			internal static method MeshGl_LockIndexBuffer;

			// Token: 0x040018CB RID: 6347
			internal static method MeshGl_UnlockIndexBuffer;

			// Token: 0x040018CC RID: 6348
			internal static method MeshGl_SetVertexBufferData;

			// Token: 0x040018CD RID: 6349
			internal static method MeshGl_SetIndexBufferData;

			// Token: 0x040018CE RID: 6350
			internal static method MeshGl_SetVertexBufferSize;

			// Token: 0x040018CF RID: 6351
			internal static method MeshGl_SetIndexBufferSize;
		}
	}
}
