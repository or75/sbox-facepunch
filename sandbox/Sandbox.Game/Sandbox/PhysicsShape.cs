using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NativeEngine;

namespace Sandbox
{
	/// <summary>
	/// Represents a basic, convex shape. A <see cref="T:Sandbox.PhysicsBody">PhysicsBody</see> consists of one or more of these.
	/// </summary>
	// Token: 0x020000E0 RID: 224
	public class PhysicsShape : IHandle
	{
		// Token: 0x06001358 RID: 4952 RVA: 0x0004F1AB File Offset: 0x0004D3AB
		void IHandle.HandleInit(IntPtr ptr)
		{
			this.native = ptr;
		}

		// Token: 0x06001359 RID: 4953 RVA: 0x0004F1B9 File Offset: 0x0004D3B9
		void IHandle.HandleDestroy()
		{
			this.native = IntPtr.Zero;
		}

		// Token: 0x0600135A RID: 4954 RVA: 0x0004F1CB File Offset: 0x0004D3CB
		bool IHandle.HandleValid()
		{
			return !this.native.IsNull;
		}

		// Token: 0x0600135B RID: 4955 RVA: 0x0004F1DB File Offset: 0x0004D3DB
		internal PhysicsShape()
		{
		}

		// Token: 0x0600135C RID: 4956 RVA: 0x0004F1E3 File Offset: 0x0004D3E3
		internal PhysicsShape(HandleCreationData _)
		{
		}

		/// <summary>
		/// The physics body we belong to.
		/// </summary>
		// Token: 0x170002CC RID: 716
		// (get) Token: 0x0600135D RID: 4957 RVA: 0x0004F1EB File Offset: 0x0004D3EB
		public PhysicsBody Body
		{
			get
			{
				return this.native.GetOwnerBody();
			}
		}

		// Token: 0x170002CD RID: 717
		// (get) Token: 0x0600135E RID: 4958 RVA: 0x0004F1F8 File Offset: 0x0004D3F8
		public Vector3 Scale
		{
			get
			{
				return this.native.GetScale();
			}
		}

		// Token: 0x170002CE RID: 718
		// (get) Token: 0x0600135F RID: 4959 RVA: 0x0004F205 File Offset: 0x0004D405
		internal PhysicsShapeType ShapeType
		{
			get
			{
				return this.native.GetType_Native();
			}
		}

		/// <summary>
		/// Enable contact, trace and touch
		/// </summary>
		// Token: 0x06001360 RID: 4960 RVA: 0x0004F214 File Offset: 0x0004D414
		public void EnableAllCollision()
		{
			CollisionFunctionMask mask = CollisionFunctionMask.EnableSolidContact | CollisionFunctionMask.EnableTraceQuery | CollisionFunctionMask.EnableTouchEvent;
			this.native.AddCollisionFunctionMask((byte)mask);
		}

		/// <summary>
		/// Disable contact, trace and touch
		/// </summary>
		// Token: 0x06001361 RID: 4961 RVA: 0x0004F230 File Offset: 0x0004D430
		public void DisableAllCollision()
		{
			CollisionFunctionMask mask = CollisionFunctionMask.EnableSolidContact | CollisionFunctionMask.EnableTraceQuery | CollisionFunctionMask.EnableTouchEvent;
			this.native.RemoveCollisionFunctionMask((byte)mask);
		}

		// Token: 0x06001362 RID: 4962 RVA: 0x0004F24B File Offset: 0x0004D44B
		public void EnableSolidContact()
		{
			this.native.AddCollisionFunctionMask(1);
		}

		// Token: 0x06001363 RID: 4963 RVA: 0x0004F259 File Offset: 0x0004D459
		public void EnableTraceQuery()
		{
			this.native.AddCollisionFunctionMask(2);
		}

		// Token: 0x06001364 RID: 4964 RVA: 0x0004F267 File Offset: 0x0004D467
		public void EnableTouchEvent()
		{
			this.native.AddCollisionFunctionMask(4);
		}

		// Token: 0x06001365 RID: 4965 RVA: 0x0004F275 File Offset: 0x0004D475
		public void DisableSolidContact()
		{
			this.native.RemoveCollisionFunctionMask(1);
		}

		// Token: 0x06001366 RID: 4966 RVA: 0x0004F283 File Offset: 0x0004D483
		public void DisableTraceQuery()
		{
			this.native.RemoveCollisionFunctionMask(2);
		}

		// Token: 0x06001367 RID: 4967 RVA: 0x0004F291 File Offset: 0x0004D491
		public void DisableTouchEvent()
		{
			this.native.RemoveCollisionFunctionMask(4);
		}

		/// <summary>
		/// Is this a MeshShape
		/// </summary>
		// Token: 0x170002CF RID: 719
		// (get) Token: 0x06001368 RID: 4968 RVA: 0x0004F29F File Offset: 0x0004D49F
		public bool IsMeshShape
		{
			get
			{
				return this.ShapeType == PhysicsShapeType.SHAPE_MESH;
			}
		}

		/// <summary>
		/// Is this a HullShape
		/// </summary>
		// Token: 0x170002D0 RID: 720
		// (get) Token: 0x06001369 RID: 4969 RVA: 0x0004F2AA File Offset: 0x0004D4AA
		public bool IsHullShape
		{
			get
			{
				return this.ShapeType == PhysicsShapeType.SHAPE_HULL;
			}
		}

		/// <summary>
		/// Is this a SphereShape
		/// </summary>
		// Token: 0x170002D1 RID: 721
		// (get) Token: 0x0600136A RID: 4970 RVA: 0x0004F2B5 File Offset: 0x0004D4B5
		public bool IsSphereShape
		{
			get
			{
				return this.ShapeType == PhysicsShapeType.SHAPE_SPHERE;
			}
		}

		/// <summary>
		/// Is this a CapsuleShape
		/// </summary>
		// Token: 0x170002D2 RID: 722
		// (get) Token: 0x0600136B RID: 4971 RVA: 0x0004F2C0 File Offset: 0x0004D4C0
		public bool IsCapsuleShape
		{
			get
			{
				return this.ShapeType == PhysicsShapeType.SHAPE_CAPSULE;
			}
		}

		/// <summary>
		/// Recreate the collision mesh (Only if this physics shape is type Mesh)
		/// </summary>
		// Token: 0x0600136C RID: 4972 RVA: 0x0004F2CB File Offset: 0x0004D4CB
		public void UpdateMesh(List<Vector3> vertices, List<int> indices)
		{
			this.UpdateMesh(CollectionsMarshal.AsSpan<Vector3>(vertices), CollectionsMarshal.AsSpan<int>(indices));
		}

		/// <summary>
		/// Recreate the collision mesh (Only if this physics shape is type Mesh)
		/// </summary>
		// Token: 0x0600136D RID: 4973 RVA: 0x0004F2E0 File Offset: 0x0004D4E0
		public unsafe void UpdateMesh(Span<Vector3> vertices, Span<int> indices)
		{
			if (this.ShapeType != PhysicsShapeType.SHAPE_MESH)
			{
				throw new Exception("PhysicsShape is not type Mesh");
			}
			if (vertices == null || vertices.Length == 0)
			{
				return;
			}
			if (indices == null || indices.Length == 0)
			{
				return;
			}
			fixed (Vector3* pinnableReference = vertices.GetPinnableReference())
			{
				Vector3* vertices_ptr = pinnableReference;
				fixed (int* pinnableReference2 = indices.GetPinnableReference())
				{
					int* indices_ptr = pinnableReference2;
					GameGlue.PhysicsUpdateMeshShape(this, vertices.Length, (IntPtr)((void*)vertices_ptr), indices.Length, (IntPtr)((void*)indices_ptr));
				}
			}
		}

		// Token: 0x0400046A RID: 1130
		internal IPhysicsShape native;
	}
}
