using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000049 RID: 73
	internal static class GameGlue
	{
		// Token: 0x06000974 RID: 2420 RVA: 0x00036F6C File Offset: 0x0003516C
		internal static void SendMessageToClient(int clientid, IntPtr pData, int dataSize)
		{
			method gmeGle_SendMessageToClient = GameGlue.__N.GmeGle_SendMessageToClient;
			calli(System.Void(System.Int32,System.IntPtr,System.Int32), clientid, pData, dataSize, gmeGle_SendMessageToClient);
		}

		// Token: 0x06000975 RID: 2421 RVA: 0x00036F88 File Offset: 0x00035188
		internal static void SendMessageToAllClients(IntPtr pData, int dataSize)
		{
			method gmeGle_SendMessageToAllClients = GameGlue.__N.GmeGle_SendMessageToAllClients;
			calli(System.Void(System.IntPtr,System.Int32), pData, dataSize, gmeGle_SendMessageToAllClients);
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00036FA4 File Offset: 0x000351A4
		internal static void SendMessageToPVS(IntPtr pData, int dataSize, IntPtr entity)
		{
			method gmeGle_SendMessageToPVS = GameGlue.__N.GmeGle_SendMessageToPVS;
			calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), pData, dataSize, entity, gmeGle_SendMessageToPVS);
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x00036FC0 File Offset: 0x000351C0
		internal static int CreateFakeClient(string botName)
		{
			method gmeGle_CreateFakeClient = GameGlue.__N.GmeGle_CreateFakeClient;
			return calli(System.Int32(System.IntPtr), Interop.GetPointer(botName), gmeGle_CreateFakeClient);
		}

		// Token: 0x06000978 RID: 2424 RVA: 0x00036FE0 File Offset: 0x000351E0
		internal static SceneWorld CreateSceneWorld(bool menu)
		{
			method gmeGle_CreateSceneWorld = GameGlue.__N.GmeGle_CreateSceneWorld;
			return HandleIndex.Get<SceneWorld>(calli(System.Int32(System.Int32), menu ? 1 : 0, gmeGle_CreateSceneWorld));
		}

		// Token: 0x06000979 RID: 2425 RVA: 0x00037008 File Offset: 0x00035208
		internal static void DestroySceneWorld(SceneWorld pSceneWorld)
		{
			method gmeGle_DestroySceneWorld = GameGlue.__N.GmeGle_DestroySceneWorld;
			calli(System.Void(System.IntPtr), (pSceneWorld == null) ? IntPtr.Zero : pSceneWorld.native, gmeGle_DestroySceneWorld);
		}

		// Token: 0x0600097A RID: 2426 RVA: 0x00037038 File Offset: 0x00035238
		internal static SceneWorld GetCurrentSceneWorld(bool menu)
		{
			method gmeGle_GetCurrentSceneWorld = GameGlue.__N.GmeGle_GetCurrentSceneWorld;
			return HandleIndex.Get<SceneWorld>(calli(System.Int32(System.Int32), menu ? 1 : 0, gmeGle_GetCurrentSceneWorld));
		}

		// Token: 0x0600097B RID: 2427 RVA: 0x00037060 File Offset: 0x00035260
		internal unsafe static LightDesc RecalculateLightDescDerivatives(LightDesc lightDesc)
		{
			method gmeGle_RecalculateLightDescDerivatives = GameGlue.__N.GmeGle_RecalculateLightDescDerivatives;
			return calli(NativeEngine.LightDesc(NativeEngine.LightDesc*), &lightDesc, gmeGle_RecalculateLightDescDerivatives);
		}

		// Token: 0x0600097C RID: 2428 RVA: 0x0003707C File Offset: 0x0003527C
		internal unsafe static SceneObject CreateAnimSceneObject(IModel model, Transform modelToWorld, ESceneObjectFlags nFlags, ESceneObjectTypeFlags nObjectTypeFlags, SceneWorld pWorld)
		{
			method gmeGle_CreateAnimSceneObject = GameGlue.__N.GmeGle_CreateAnimSceneObject;
			return HandleIndex.Get<SceneObject>(calli(System.Int32(System.IntPtr,Transform*,System.Int64,System.Int64,System.IntPtr), model, &modelToWorld, nFlags, (ulong)nObjectTypeFlags, (pWorld == null) ? IntPtr.Zero : pWorld.native, gmeGle_CreateAnimSceneObject));
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x000370C0 File Offset: 0x000352C0
		internal static void CurrentSceneWorldChanged(SceneWorld pSceneWorld)
		{
			method gmeGle_CurrentSceneWorldChanged = GameGlue.__N.GmeGle_CurrentSceneWorldChanged;
			calli(System.Void(System.IntPtr), (pSceneWorld == null) ? IntPtr.Zero : pSceneWorld.native, gmeGle_CurrentSceneWorldChanged);
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x000370F0 File Offset: 0x000352F0
		internal static bool HasLiquidMaterial(IntPtr model)
		{
			method gmeGle_HasLiquidMaterial = GameGlue.__N.GmeGle_HasLiquidMaterial;
			return calli(System.Int32(System.IntPtr), model, gmeGle_HasLiquidMaterial) > 0;
		}

		// Token: 0x0600097F RID: 2431 RVA: 0x00037110 File Offset: 0x00035310
		internal static IntPtr CreateConstantBuffer(bool bIsDynamic, IntPtr pData, int dataSize)
		{
			method gmeGle_CreateConstantBuffer = GameGlue.__N.GmeGle_CreateConstantBuffer;
			return calli(System.IntPtr(System.Int32,System.IntPtr,System.Int32), bIsDynamic ? 1 : 0, pData, dataSize, gmeGle_CreateConstantBuffer);
		}

		// Token: 0x06000980 RID: 2432 RVA: 0x00037134 File Offset: 0x00035334
		internal static void DestroyConstantBuffer(IntPtr pHandle)
		{
			method gmeGle_DestroyConstantBuffer = GameGlue.__N.GmeGle_DestroyConstantBuffer;
			calli(System.Void(System.IntPtr), pHandle, gmeGle_DestroyConstantBuffer);
		}

		// Token: 0x06000981 RID: 2433 RVA: 0x00037150 File Offset: 0x00035350
		internal static bool UpdateConstantBuffer(IntPtr pRenderContext, IntPtr pHandle, IntPtr pData, int bufferSize)
		{
			method gmeGle_UpdateConstantBuffer = GameGlue.__N.GmeGle_UpdateConstantBuffer;
			return calli(System.Int32(System.IntPtr,System.IntPtr,System.IntPtr,System.Int32), pRenderContext, pHandle, pData, bufferSize, gmeGle_UpdateConstantBuffer) > 0;
		}

		// Token: 0x06000982 RID: 2434 RVA: 0x00037170 File Offset: 0x00035370
		internal static void DispatchComputeShader(IMaterial pMaterial, IntPtr context, CRenderAttributes attributes, int iThreadX, int iThreadY, int iThreadZ)
		{
			method gmeGle_DispatchComputeShader = GameGlue.__N.GmeGle_DispatchComputeShader;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr,System.Int32,System.Int32,System.Int32), pMaterial, context, attributes, iThreadX, iThreadY, iThreadZ, gmeGle_DispatchComputeShader);
		}

		// Token: 0x06000983 RID: 2435 RVA: 0x0003719B File Offset: 0x0003539B
		internal static IVPhysics2World GetCurrentPhysicsWorld()
		{
			return calli(System.IntPtr(), GameGlue.__N.GmeGle_GetCurrentPhysicsWorld);
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x000371AC File Offset: 0x000353AC
		internal static PhysicsGroup GetPhysicsBodyAggregateInstance(PhysicsBody body)
		{
			method gmeGle_GetPhysicsBodyAggregateInstance = GameGlue.__N.GmeGle_GetPhysicsBodyAggregateInstance;
			return HandleIndex.Get<PhysicsGroup>(calli(System.Int32(System.IntPtr), (body == null) ? IntPtr.Zero : body.native, gmeGle_GetPhysicsBodyAggregateInstance));
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x000371E0 File Offset: 0x000353E0
		internal static Entity GetPhysicsBodyEntity(PhysicsBody body)
		{
			method gmeGle_GetPhysicsBodyEntity = GameGlue.__N.GmeGle_GetPhysicsBodyEntity;
			return InteropSystem.Get<Entity>(calli(System.UInt32(System.IntPtr), (body == null) ? IntPtr.Zero : body.native, gmeGle_GetPhysicsBodyEntity));
		}

		// Token: 0x06000986 RID: 2438 RVA: 0x00037213 File Offset: 0x00035413
		internal static Entity GetWorldEntity()
		{
			return InteropSystem.Get<Entity>(calli(System.UInt32(), GameGlue.__N.GmeGle_GetWorldEntity));
		}

		// Token: 0x06000987 RID: 2439 RVA: 0x00037224 File Offset: 0x00035424
		internal unsafe static void PhysicsQueryEntitiesInSphere(Vector3 vCenter, float flRadius, CUtlVectorOverlapResult ents)
		{
			method gmeGle_PhysicsQueryEntitiesInSphere = GameGlue.__N.GmeGle_PhysicsQueryEntitiesInSphere;
			calli(System.Void(Vector3*,System.Single,System.IntPtr), &vCenter, flRadius, ents, gmeGle_PhysicsQueryEntitiesInSphere);
		}

		// Token: 0x06000988 RID: 2440 RVA: 0x00037248 File Offset: 0x00035448
		internal unsafe static void PhysicsQueryEntitiesInBox(BBox box, CUtlVectorOverlapResult ents)
		{
			method gmeGle_PhysicsQueryEntitiesInBox = GameGlue.__N.GmeGle_PhysicsQueryEntitiesInBox;
			calli(System.Void(BBox*,System.IntPtr), &box, ents, gmeGle_PhysicsQueryEntitiesInBox);
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x0003726C File Offset: 0x0003546C
		internal static void PhysicsWakeAllBodies(IVPhysics2World pPhysWorld)
		{
			method gmeGle_PhysicsWakeAllBodies = GameGlue.__N.GmeGle_PhysicsWakeAllBodies;
			calli(System.Void(System.IntPtr), pPhysWorld, gmeGle_PhysicsWakeAllBodies);
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x0003728C File Offset: 0x0003548C
		internal unsafe static PhysicsShape PhysicsAddBoxShape(PhysicsBody pBody, Vector3 position, Rotation rotation, Vector3 extent, bool rebuildMass)
		{
			method gmeGle_PhysicsAddBoxShape = GameGlue.__N.GmeGle_PhysicsAddBoxShape;
			return HandleIndex.Get<PhysicsShape>(calli(System.Int32(System.IntPtr,Vector3*,Rotation*,Vector3*,System.Int32), (pBody == null) ? IntPtr.Zero : pBody.native, &position, &rotation, &extent, rebuildMass ? 1 : 0, gmeGle_PhysicsAddBoxShape));
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x000372D0 File Offset: 0x000354D0
		internal unsafe static PhysicsShape PhysicsAddHullShape(PhysicsBody pBody, Vector3 position, Rotation rotation, int numVertices, IntPtr vertices, bool rebuildMass)
		{
			method gmeGle_PhysicsAddHullShape = GameGlue.__N.GmeGle_PhysicsAddHullShape;
			return HandleIndex.Get<PhysicsShape>(calli(System.Int32(System.IntPtr,Vector3*,Rotation*,System.Int32,System.IntPtr,System.Int32), (pBody == null) ? IntPtr.Zero : pBody.native, &position, &rotation, numVertices, vertices, rebuildMass ? 1 : 0, gmeGle_PhysicsAddHullShape));
		}

		// Token: 0x0600098C RID: 2444 RVA: 0x00037314 File Offset: 0x00035514
		internal static PhysicsShape PhysicsAddMeshShape(PhysicsBody pBody, int numVertices, IntPtr vertices, int numIndices, IntPtr indices)
		{
			method gmeGle_PhysicsAddMeshShape = GameGlue.__N.GmeGle_PhysicsAddMeshShape;
			return HandleIndex.Get<PhysicsShape>(calli(System.Int32(System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr), (pBody == null) ? IntPtr.Zero : pBody.native, numVertices, vertices, numIndices, indices, gmeGle_PhysicsAddMeshShape));
		}

		// Token: 0x0600098D RID: 2445 RVA: 0x0003734C File Offset: 0x0003554C
		internal static void PhysicsUpdateMeshShape(PhysicsShape pShape, int numVertices, IntPtr vertices, int numIndices, IntPtr indices)
		{
			method gmeGle_PhysicsUpdateMeshShape = GameGlue.__N.GmeGle_PhysicsUpdateMeshShape;
			calli(System.Void(System.IntPtr,System.Int32,System.IntPtr,System.Int32,System.IntPtr), (pShape == null) ? IntPtr.Zero : pShape.native, numVertices, vertices, numIndices, indices, gmeGle_PhysicsUpdateMeshShape);
		}

		// Token: 0x0600098E RID: 2446 RVA: 0x00037380 File Offset: 0x00035580
		internal unsafe static void SetSceneMonitorObjectFrustum(SceneMonitorObject pObject, Transform cam, float zNear, float zFar, float aspect)
		{
			method gmeGle_SetSceneMonitorObjectFrustum = GameGlue.__N.GmeGle_SetSceneMonitorObjectFrustum;
			calli(System.Void(System.IntPtr,Transform*,System.Single,System.Single,System.Single), (pObject == null) ? IntPtr.Zero : pObject.native, &cam, zNear, zFar, aspect, gmeGle_SetSceneMonitorObjectFrustum);
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x000373B8 File Offset: 0x000355B8
		internal unsafe static void SetSceneMonitorObjectClearColor(SceneMonitorObject pObject, Vector4 clearColor)
		{
			method gmeGle_SetSceneMonitorObjectClearColor = GameGlue.__N.GmeGle_SetSceneMonitorObjectClearColor;
			calli(System.Void(System.IntPtr,Vector4*), (pObject == null) ? IntPtr.Zero : pObject.native, &clearColor, gmeGle_SetSceneMonitorObjectClearColor);
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x000373EC File Offset: 0x000355EC
		internal static void SetSceneMonitorObjectRenderTargets(SceneMonitorObject pObject, ITexture hColorTarget, ITexture hDepthTarget)
		{
			method gmeGle_SetSceneMonitorObjectRenderTargets = GameGlue.__N.GmeGle_SetSceneMonitorObjectRenderTargets;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), (pObject == null) ? IntPtr.Zero : pObject.native, hColorTarget, hDepthTarget, gmeGle_SetSceneMonitorObjectRenderTargets);
		}

		// Token: 0x06000991 RID: 2449 RVA: 0x00037428 File Offset: 0x00035628
		internal static void SetSceneMonitorObjectRenderShadows(SceneMonitorObject pObject, bool bRenderShadows)
		{
			method gmeGle_SetSceneMonitorObjectRenderShadows = GameGlue.__N.GmeGle_SetSceneMonitorObjectRenderShadows;
			calli(System.Void(System.IntPtr,System.Int32), (pObject == null) ? IntPtr.Zero : pObject.native, bRenderShadows ? 1 : 0, gmeGle_SetSceneMonitorObjectRenderShadows);
		}

		// Token: 0x06000992 RID: 2450 RVA: 0x00037460 File Offset: 0x00035660
		internal static void SetAnimGraphPreview(IntPtr pEntity)
		{
			method gmeGle_SetAnimGraphPreview = GameGlue.__N.GmeGle_SetAnimGraphPreview;
			calli(System.Void(System.IntPtr), pEntity, gmeGle_SetAnimGraphPreview);
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0003747C File Offset: 0x0003567C
		internal static string GetInputButtonBinding(ulong button)
		{
			method gmeGle_GetInputButtonBinding = GameGlue.__N.GmeGle_GetInputButtonBinding;
			return Interop.GetString(calli(System.IntPtr(System.UInt64), button, gmeGle_GetInputButtonBinding));
		}

		// Token: 0x020001CE RID: 462
		internal static class __N
		{
			// Token: 0x04000E9B RID: 3739
			internal static method GmeGle_SendMessageToClient;

			// Token: 0x04000E9C RID: 3740
			internal static method GmeGle_SendMessageToAllClients;

			// Token: 0x04000E9D RID: 3741
			internal static method GmeGle_SendMessageToPVS;

			// Token: 0x04000E9E RID: 3742
			internal static method GmeGle_CreateFakeClient;

			// Token: 0x04000E9F RID: 3743
			internal static method GmeGle_CreateSceneWorld;

			// Token: 0x04000EA0 RID: 3744
			internal static method GmeGle_DestroySceneWorld;

			// Token: 0x04000EA1 RID: 3745
			internal static method GmeGle_GetCurrentSceneWorld;

			// Token: 0x04000EA2 RID: 3746
			internal static method GmeGle_RecalculateLightDescDerivatives;

			// Token: 0x04000EA3 RID: 3747
			internal static method GmeGle_CreateAnimSceneObject;

			// Token: 0x04000EA4 RID: 3748
			internal static method GmeGle_CurrentSceneWorldChanged;

			// Token: 0x04000EA5 RID: 3749
			internal static method GmeGle_HasLiquidMaterial;

			// Token: 0x04000EA6 RID: 3750
			internal static method GmeGle_CreateConstantBuffer;

			// Token: 0x04000EA7 RID: 3751
			internal static method GmeGle_DestroyConstantBuffer;

			// Token: 0x04000EA8 RID: 3752
			internal static method GmeGle_UpdateConstantBuffer;

			// Token: 0x04000EA9 RID: 3753
			internal static method GmeGle_DispatchComputeShader;

			// Token: 0x04000EAA RID: 3754
			internal static method GmeGle_GetCurrentPhysicsWorld;

			// Token: 0x04000EAB RID: 3755
			internal static method GmeGle_GetPhysicsBodyAggregateInstance;

			// Token: 0x04000EAC RID: 3756
			internal static method GmeGle_GetPhysicsBodyEntity;

			// Token: 0x04000EAD RID: 3757
			internal static method GmeGle_GetWorldEntity;

			// Token: 0x04000EAE RID: 3758
			internal static method GmeGle_PhysicsQueryEntitiesInSphere;

			// Token: 0x04000EAF RID: 3759
			internal static method GmeGle_PhysicsQueryEntitiesInBox;

			// Token: 0x04000EB0 RID: 3760
			internal static method GmeGle_PhysicsWakeAllBodies;

			// Token: 0x04000EB1 RID: 3761
			internal static method GmeGle_PhysicsAddBoxShape;

			// Token: 0x04000EB2 RID: 3762
			internal static method GmeGle_PhysicsAddHullShape;

			// Token: 0x04000EB3 RID: 3763
			internal static method GmeGle_PhysicsAddMeshShape;

			// Token: 0x04000EB4 RID: 3764
			internal static method GmeGle_PhysicsUpdateMeshShape;

			// Token: 0x04000EB5 RID: 3765
			internal static method GmeGle_SetSceneMonitorObjectFrustum;

			// Token: 0x04000EB6 RID: 3766
			internal static method GmeGle_SetSceneMonitorObjectClearColor;

			// Token: 0x04000EB7 RID: 3767
			internal static method GmeGle_SetSceneMonitorObjectRenderTargets;

			// Token: 0x04000EB8 RID: 3768
			internal static method GmeGle_SetSceneMonitorObjectRenderShadows;

			// Token: 0x04000EB9 RID: 3769
			internal static method GmeGle_SetAnimGraphPreview;

			// Token: 0x04000EBA RID: 3770
			internal static method GmeGle_GetInputButtonBinding;
		}
	}
}
