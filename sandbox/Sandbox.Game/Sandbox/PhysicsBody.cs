using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NativeEngine;

namespace Sandbox
{
	/// <summary>
	/// Represents a physics object. An entity can have multiple physics objects. See <see cref="P:Sandbox.PhysicsBody.PhysicsGroup">PhysicsGroup</see>.
	/// A physics objects conists of one or more <see cref="T:Sandbox.PhysicsShape">PhysicsShape</see>s.
	/// </summary>
	// Token: 0x020000DA RID: 218
	public class PhysicsBody : IHandle
	{
		// Token: 0x060012E2 RID: 4834 RVA: 0x0004E947 File Offset: 0x0004CB47
		void IHandle.HandleInit(IntPtr ptr)
		{
			this.native = ptr;
		}

		// Token: 0x060012E3 RID: 4835 RVA: 0x0004E955 File Offset: 0x0004CB55
		void IHandle.HandleDestroy()
		{
			this.native = IntPtr.Zero;
		}

		// Token: 0x060012E4 RID: 4836 RVA: 0x0004E967 File Offset: 0x0004CB67
		bool IHandle.HandleValid()
		{
			return !this.native.IsNull;
		}

		// Token: 0x060012E5 RID: 4837 RVA: 0x0004E977 File Offset: 0x0004CB77
		public PhysicsBody()
		{
			this.CreateThisNative();
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x0004E985 File Offset: 0x0004CB85
		internal PhysicsBody(HandleCreationData _)
		{
		}

		// Token: 0x060012E7 RID: 4839 RVA: 0x0004E990 File Offset: 0x0004CB90
		internal void CreateThisNative()
		{
			try
			{
				HandleIndex.ForceNextObject(this);
				PhysicsWorld.AddBody();
			}
			finally
			{
				HandleIndex.UsedNextObject(this);
			}
		}

		// Token: 0x170002A4 RID: 676
		// (get) Token: 0x060012E8 RID: 4840 RVA: 0x0004E9C4 File Offset: 0x0004CBC4
		// (set) Token: 0x060012E9 RID: 4841 RVA: 0x0004E9D1 File Offset: 0x0004CBD1
		public Vector3 Position
		{
			get
			{
				return this.native.GetPosition();
			}
			set
			{
				this.native.SetPosition(value);
			}
		}

		// Token: 0x170002A5 RID: 677
		// (get) Token: 0x060012EA RID: 4842 RVA: 0x0004E9DF File Offset: 0x0004CBDF
		// (set) Token: 0x060012EB RID: 4843 RVA: 0x0004E9EC File Offset: 0x0004CBEC
		public Rotation Rotation
		{
			get
			{
				return this.native.GetOrientation();
			}
			set
			{
				this.native.SetOrientation(value);
			}
		}

		// Token: 0x170002A6 RID: 678
		// (get) Token: 0x060012EC RID: 4844 RVA: 0x0004E9FA File Offset: 0x0004CBFA
		public float Scale
		{
			get
			{
				return this.native.GetScale();
			}
		}

		// Token: 0x170002A7 RID: 679
		// (get) Token: 0x060012ED RID: 4845 RVA: 0x0004EA07 File Offset: 0x0004CC07
		// (set) Token: 0x060012EE RID: 4846 RVA: 0x0004EA14 File Offset: 0x0004CC14
		public Vector3 Velocity
		{
			get
			{
				return this.native.GetLinearVelocity();
			}
			set
			{
				this.native.SetLinearVelocity(value);
			}
		}

		// Token: 0x170002A8 RID: 680
		// (get) Token: 0x060012EF RID: 4847 RVA: 0x0004EA22 File Offset: 0x0004CC22
		// (set) Token: 0x060012F0 RID: 4848 RVA: 0x0004EA2F File Offset: 0x0004CC2F
		public Vector3 AngularVelocity
		{
			get
			{
				return this.native.GetAngularVelocity();
			}
			set
			{
				this.native.SetAngularVelocity(value);
			}
		}

		// Token: 0x170002A9 RID: 681
		// (get) Token: 0x060012F1 RID: 4849 RVA: 0x0004EA3D File Offset: 0x0004CC3D
		public Vector3 MassCenter
		{
			get
			{
				return this.native.GetMassCenter();
			}
		}

		// Token: 0x170002AA RID: 682
		// (get) Token: 0x060012F2 RID: 4850 RVA: 0x0004EA4A File Offset: 0x0004CC4A
		// (set) Token: 0x060012F3 RID: 4851 RVA: 0x0004EA57 File Offset: 0x0004CC57
		public Vector3 LocalMassCenter
		{
			get
			{
				return this.native.GetLocalMassCenter();
			}
			set
			{
				this.native.OverrideMassCenter(value);
			}
		}

		// Token: 0x170002AB RID: 683
		// (get) Token: 0x060012F4 RID: 4852 RVA: 0x0004EA65 File Offset: 0x0004CC65
		// (set) Token: 0x060012F5 RID: 4853 RVA: 0x0004EA72 File Offset: 0x0004CC72
		public float Mass
		{
			get
			{
				return this.native.GetMass();
			}
			set
			{
				this.native.SetMass(value);
			}
		}

		// Token: 0x170002AC RID: 684
		// (get) Token: 0x060012F6 RID: 4854 RVA: 0x0004EA80 File Offset: 0x0004CC80
		// (set) Token: 0x060012F7 RID: 4855 RVA: 0x0004EA8D File Offset: 0x0004CC8D
		public bool GravityEnabled
		{
			get
			{
				return this.native.IsGravityEnabled();
			}
			set
			{
				this.native.EnableGravity(value);
			}
		}

		// Token: 0x170002AD RID: 685
		// (get) Token: 0x060012F8 RID: 4856 RVA: 0x0004EA9B File Offset: 0x0004CC9B
		// (set) Token: 0x060012F9 RID: 4857 RVA: 0x0004EAA8 File Offset: 0x0004CCA8
		public float GravityScale
		{
			get
			{
				return this.native.GetGravityScale();
			}
			set
			{
				this.native.SetGravityScale(value);
			}
		}

		// Token: 0x060012FA RID: 4858 RVA: 0x0004EAB6 File Offset: 0x0004CCB6
		public void RemoveShadowController()
		{
			this.native.RemoveShadowController();
		}

		/// <summary>
		/// Allow Touch callbacks to be called
		/// </summary>
		// Token: 0x170002AE RID: 686
		// (get) Token: 0x060012FB RID: 4859 RVA: 0x0004EAC3 File Offset: 0x0004CCC3
		// (set) Token: 0x060012FC RID: 4860 RVA: 0x0004EAD0 File Offset: 0x0004CCD0
		public bool EnableTouch
		{
			get
			{
				return this.native.IsTouchEventEnabled();
			}
			set
			{
				if (value)
				{
					this.native.EnableTouchEvents();
					return;
				}
				this.native.DisableTouchEvents();
			}
		}

		// Token: 0x170002AF RID: 687
		// (get) Token: 0x060012FD RID: 4861 RVA: 0x0004EAEC File Offset: 0x0004CCEC
		// (set) Token: 0x060012FE RID: 4862 RVA: 0x0004EAF9 File Offset: 0x0004CCF9
		public PhysicsBodyType BodyType
		{
			get
			{
				return this.native.GetType_Native();
			}
			set
			{
				this.native.SetType(value);
			}
		}

		// Token: 0x170002B0 RID: 688
		// (set) Token: 0x060012FF RID: 4863 RVA: 0x0004EB07 File Offset: 0x0004CD07
		public bool EnableAutoSleeping
		{
			set
			{
				if (value)
				{
					this.native.EnableAutoSleeping();
					return;
				}
				this.native.DisableAutoSleeping();
			}
		}

		// Token: 0x170002B1 RID: 689
		// (get) Token: 0x06001300 RID: 4864 RVA: 0x0004EB23 File Offset: 0x0004CD23
		// (set) Token: 0x06001301 RID: 4865 RVA: 0x0004EB30 File Offset: 0x0004CD30
		public Transform Transform
		{
			get
			{
				return this.native.GetCTransform();
			}
			set
			{
				this.Position = value.Position;
				this.Rotation = value.Rotation;
			}
		}

		// Token: 0x170002B2 RID: 690
		// (get) Token: 0x06001302 RID: 4866 RVA: 0x0004EB4A File Offset: 0x0004CD4A
		public IEnumerable<PhysicsShape> Shapes
		{
			get
			{
				int shapeCount = this.ShapeCount;
				int num;
				for (int i = 0; i < shapeCount; i = num)
				{
					yield return this.GetShape(i);
					num = i + 1;
				}
				yield break;
			}
		}

		// Token: 0x170002B3 RID: 691
		// (get) Token: 0x06001303 RID: 4867 RVA: 0x0004EB5A File Offset: 0x0004CD5A
		public int ShapeCount
		{
			get
			{
				return this.native.GetShapeCount();
			}
		}

		// Token: 0x06001304 RID: 4868 RVA: 0x0004EB67 File Offset: 0x0004CD67
		public PhysicsShape GetShape(int index)
		{
			return this.native.GetShape(index);
		}

		// Token: 0x06001305 RID: 4869 RVA: 0x0004EB75 File Offset: 0x0004CD75
		public PhysicsShape AddSphereShape(Vector3 center, float radius, bool rebuildMass = true)
		{
			return this.native.AddSphereShape(center, radius, rebuildMass);
		}

		// Token: 0x06001306 RID: 4870 RVA: 0x0004EB85 File Offset: 0x0004CD85
		public PhysicsShape AddCapsuleShape(Vector3 center, Vector3 center2, float radius, bool rebuildMass = true)
		{
			return this.native.AddCapsuleShape(center, center2, radius, rebuildMass);
		}

		// Token: 0x06001307 RID: 4871 RVA: 0x0004EB97 File Offset: 0x0004CD97
		public PhysicsShape AddBoxShape(Vector3 position, Rotation rotation, Vector3 extent, bool rebuildMass = true)
		{
			return GameGlue.PhysicsAddBoxShape(this, position, rotation, extent.Abs(), rebuildMass);
		}

		// Token: 0x06001308 RID: 4872 RVA: 0x0004EBAA File Offset: 0x0004CDAA
		public PhysicsShape AddHullShape(Vector3 position, Rotation rotation, List<Vector3> points, bool rebuildMass = true)
		{
			return this.AddHullShape(position, rotation, CollectionsMarshal.AsSpan<Vector3>(points), rebuildMass);
		}

		// Token: 0x06001309 RID: 4873 RVA: 0x0004EBBC File Offset: 0x0004CDBC
		public unsafe PhysicsShape AddHullShape(Vector3 position, Rotation rotation, Span<Vector3> points, bool rebuildMass = true)
		{
			if (points == null || points.Length == 0)
			{
				return null;
			}
			fixed (Vector3* pinnableReference = points.GetPinnableReference())
			{
				Vector3* points_ptr = pinnableReference;
				return GameGlue.PhysicsAddHullShape(this, position, rotation, points.Length, (IntPtr)((void*)points_ptr), rebuildMass);
			}
		}

		// Token: 0x0600130A RID: 4874 RVA: 0x0004EC04 File Offset: 0x0004CE04
		public PhysicsShape AddMeshShape(List<Vector3> vertices, List<int> indices)
		{
			return this.AddMeshShape(CollectionsMarshal.AsSpan<Vector3>(vertices), CollectionsMarshal.AsSpan<int>(indices));
		}

		// Token: 0x0600130B RID: 4875 RVA: 0x0004EC18 File Offset: 0x0004CE18
		public unsafe PhysicsShape AddMeshShape(Span<Vector3> vertices, Span<int> indices)
		{
			if (vertices == null || vertices.Length == 0)
			{
				return null;
			}
			if (indices == null || indices.Length == 0)
			{
				return null;
			}
			fixed (Vector3* pinnableReference = vertices.GetPinnableReference())
			{
				Vector3* vertices_ptr = pinnableReference;
				fixed (int* pinnableReference2 = indices.GetPinnableReference())
				{
					int* indices_ptr = pinnableReference2;
					return GameGlue.PhysicsAddMeshShape(this, vertices.Length, (IntPtr)((void*)vertices_ptr), indices.Length, (IntPtr)((void*)indices_ptr));
				}
			}
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x0004EC8D File Offset: 0x0004CE8D
		public PhysicsShape AddCloneShape(PhysicsShape shape)
		{
			if (shape.native.IsNull)
			{
				throw new ArgumentException("Shape is invalid");
			}
			return this.native.AddCloneShape(shape);
		}

		// Token: 0x0600130D RID: 4877 RVA: 0x0004ECB3 File Offset: 0x0004CEB3
		public void RemoveShapes()
		{
			this.native.PurgeShapes();
		}

		// Token: 0x0600130E RID: 4878 RVA: 0x0004ECC0 File Offset: 0x0004CEC0
		public void RemoveShape(PhysicsShape shape, bool rebuildMass = true)
		{
			if (shape == null)
			{
				return;
			}
			if (shape.native.IsNull)
			{
				throw new ArgumentException("Shape is invalid");
			}
			if (shape.Body != this)
			{
				throw new ArgumentException("Shape doesn't belong to this body");
			}
			this.native.RemoveShape(shape);
			shape.native = IntPtr.Zero;
			if (rebuildMass)
			{
				this.native.BuildMass();
			}
		}

		// Token: 0x0600130F RID: 4879 RVA: 0x0004ED27 File Offset: 0x0004CF27
		public void RebuildMass()
		{
			this.native.BuildMass();
		}

		// Token: 0x06001310 RID: 4880 RVA: 0x0004ED34 File Offset: 0x0004CF34
		public void Remove()
		{
			if (!this.IsValid())
			{
				return;
			}
			PhysicsWorld.RemoveBody(this);
		}

		// Token: 0x06001311 RID: 4881 RVA: 0x0004ED45 File Offset: 0x0004CF45
		public void ApplyImpulse(Vector3 impulse)
		{
			this.native.ApplyLinearImpulse(impulse);
		}

		// Token: 0x06001312 RID: 4882 RVA: 0x0004ED53 File Offset: 0x0004CF53
		public void ApplyImpulseAt(Vector3 position, Vector3 velocity)
		{
			this.native.ApplyLinearImpulseAtWorldSpace(velocity, position);
		}

		// Token: 0x06001313 RID: 4883 RVA: 0x0004ED62 File Offset: 0x0004CF62
		public void ApplyAngularImpulse(Vector3 impulse)
		{
			this.native.ApplyAngularImpulse(impulse);
		}

		// Token: 0x06001314 RID: 4884 RVA: 0x0004ED70 File Offset: 0x0004CF70
		public void ApplyForce(Vector3 force)
		{
			this.native.ApplyForce(force);
		}

		// Token: 0x06001315 RID: 4885 RVA: 0x0004ED7E File Offset: 0x0004CF7E
		public void ApplyForceAt(Vector3 position, Vector3 force)
		{
			this.native.ApplyForceAt(force, position);
		}

		// Token: 0x06001316 RID: 4886 RVA: 0x0004ED8D File Offset: 0x0004CF8D
		public void ApplyTorque(Vector3 force)
		{
			this.native.ApplyTorque(force);
		}

		// Token: 0x06001317 RID: 4887 RVA: 0x0004ED9B File Offset: 0x0004CF9B
		public void ClearForces()
		{
			this.native.ClearForces();
		}

		// Token: 0x06001318 RID: 4888 RVA: 0x0004EDA8 File Offset: 0x0004CFA8
		public void ClearTorques()
		{
			this.native.ClearTorques();
		}

		// Token: 0x06001319 RID: 4889 RVA: 0x0004EDB5 File Offset: 0x0004CFB5
		public Vector3 GetVelocityAtPoint(Vector3 point)
		{
			return this.native.GetVelocityAtPoint(point);
		}

		// Token: 0x170002B4 RID: 692
		// (get) Token: 0x0600131A RID: 4890 RVA: 0x0004EDC3 File Offset: 0x0004CFC3
		// (set) Token: 0x0600131B RID: 4891 RVA: 0x0004EDD0 File Offset: 0x0004CFD0
		public bool Enabled
		{
			get
			{
				return this.native.IsEnabled();
			}
			set
			{
				if (value)
				{
					this.native.Enable();
					return;
				}
				this.native.Disable();
			}
		}

		// Token: 0x170002B5 RID: 693
		// (get) Token: 0x0600131C RID: 4892 RVA: 0x0004EDEC File Offset: 0x0004CFEC
		// (set) Token: 0x0600131D RID: 4893 RVA: 0x0004EDF9 File Offset: 0x0004CFF9
		public bool CollisionEnabled
		{
			get
			{
				return this.native.IsCollisionEnabled();
			}
			set
			{
				this.native.EnableCollisions(value);
			}
		}

		// Token: 0x170002B6 RID: 694
		// (get) Token: 0x0600131E RID: 4894 RVA: 0x0004EE07 File Offset: 0x0004D007
		// (set) Token: 0x0600131F RID: 4895 RVA: 0x0004EE14 File Offset: 0x0004D014
		public bool MotionEnabled
		{
			get
			{
				return this.native.IsMotionEnabled();
			}
			set
			{
				this.native.EnableMotion(value);
			}
		}

		/// <summary>
		/// Wake up this physics body. Physics bodies automatically go to sleep after a certain amount of time of inactivity to save on performance.
		/// </summary>
		// Token: 0x06001320 RID: 4896 RVA: 0x0004EE22 File Offset: 0x0004D022
		public void Wake()
		{
			this.native.Wake();
		}

		/// <summary>
		/// Put this physics body to sleep. Physics bodies automatically go to sleep after a certain amount of time of inactivity to save on performance.
		/// </summary>
		// Token: 0x06001321 RID: 4897 RVA: 0x0004EE2F File Offset: 0x0004D02F
		public void Sleep()
		{
			this.native.Sleep();
		}

		/// <summary>
		/// Returns the current sleep state of this physics body. Physics bodies automatically go to sleep after a certain amount of time of inactivity to save on performance.
		/// </summary>
		// Token: 0x06001322 RID: 4898 RVA: 0x0004EE3C File Offset: 0x0004D03C
		public bool IsSleeping()
		{
			return this.native.IsSleeping();
		}

		// Token: 0x170002B7 RID: 695
		// (get) Token: 0x06001323 RID: 4899 RVA: 0x0004EE49 File Offset: 0x0004D049
		// (set) Token: 0x06001324 RID: 4900 RVA: 0x0004EE56 File Offset: 0x0004D056
		public bool SpeculativeContactEnabled
		{
			get
			{
				return this.native.IsSpeculativeContactEnabled();
			}
			set
			{
				this.native.SetSpeculativeContactEnabled(value);
			}
		}

		// Token: 0x06001325 RID: 4901 RVA: 0x0004EE64 File Offset: 0x0004D064
		public void SetMinSolverIterations(int minVelocityIterations, int minPositionIterations)
		{
			this.native.SetMinSolverIterations(minVelocityIterations, minPositionIterations);
		}

		/// <summary>
		/// The physics body we are attached to, if any
		/// </summary>
		// Token: 0x170002B8 RID: 696
		// (get) Token: 0x06001326 RID: 4902 RVA: 0x0004EE73 File Offset: 0x0004D073
		// (set) Token: 0x06001327 RID: 4903 RVA: 0x0004EE7B File Offset: 0x0004D07B
		public PhysicsBody Parent { get; set; }

		// Token: 0x170002B9 RID: 697
		// (get) Token: 0x06001328 RID: 4904 RVA: 0x0004EE84 File Offset: 0x0004D084
		public PhysicsBody SelfOrParent
		{
			get
			{
				return this.Parent ?? this;
			}
		}

		/// <summary>
		/// The physics group we belong to.
		/// </summary>
		// Token: 0x170002BA RID: 698
		// (get) Token: 0x06001329 RID: 4905 RVA: 0x0004EE91 File Offset: 0x0004D091
		public PhysicsGroup PhysicsGroup
		{
			get
			{
				return GameGlue.GetPhysicsBodyAggregateInstance(this);
			}
		}

		/// <summary>
		/// The entity we belong to.
		/// </summary>
		// Token: 0x170002BB RID: 699
		// (get) Token: 0x0600132A RID: 4906 RVA: 0x0004EE99 File Offset: 0x0004D099
		public Entity Entity
		{
			get
			{
				return GameGlue.GetPhysicsBodyEntity(this);
			}
		}

		// Token: 0x0600132B RID: 4907 RVA: 0x0004EEA1 File Offset: 0x0004D0A1
		public Vector3 FindClosestPoint(Vector3 vec)
		{
			return this.native.FindClosestPointOnConvexShapes(vec);
		}

		// Token: 0x0600132C RID: 4908 RVA: 0x0004EEAF File Offset: 0x0004D0AF
		public void RemoveContacts(PhysicsBody otherBody)
		{
			if (otherBody.IsValid())
			{
				PhysicsWorld.RemoveContacts(this, otherBody);
			}
		}

		// Token: 0x170002BC RID: 700
		// (get) Token: 0x0600132D RID: 4909 RVA: 0x0004EEC0 File Offset: 0x0004D0C0
		// (set) Token: 0x0600132E RID: 4910 RVA: 0x0004EECD File Offset: 0x0004D0CD
		public float LinearDamping
		{
			get
			{
				return this.native.GetLinearDamping();
			}
			set
			{
				this.native.SetLinearDamping(value);
			}
		}

		// Token: 0x170002BD RID: 701
		// (get) Token: 0x0600132F RID: 4911 RVA: 0x0004EEDB File Offset: 0x0004D0DB
		// (set) Token: 0x06001330 RID: 4912 RVA: 0x0004EEE8 File Offset: 0x0004D0E8
		public float AngularDamping
		{
			get
			{
				return this.native.GetAngularDamping();
			}
			set
			{
				this.native.SetAngularDamping(value);
			}
		}

		// Token: 0x170002BE RID: 702
		// (get) Token: 0x06001331 RID: 4913 RVA: 0x0004EEF6 File Offset: 0x0004D0F6
		// (set) Token: 0x06001332 RID: 4914 RVA: 0x0004EF03 File Offset: 0x0004D103
		public float LinearDrag
		{
			get
			{
				return this.native.GetLinearDrag();
			}
			set
			{
				this.native.SetLinearDrag(value);
			}
		}

		// Token: 0x170002BF RID: 703
		// (get) Token: 0x06001333 RID: 4915 RVA: 0x0004EF11 File Offset: 0x0004D111
		// (set) Token: 0x06001334 RID: 4916 RVA: 0x0004EF1E File Offset: 0x0004D11E
		public float AngularDrag
		{
			get
			{
				return this.native.GetAngularDrag();
			}
			set
			{
				this.native.SetAngularDrag(value);
			}
		}

		// Token: 0x170002C0 RID: 704
		// (get) Token: 0x06001335 RID: 4917 RVA: 0x0004EF2C File Offset: 0x0004D12C
		// (set) Token: 0x06001336 RID: 4918 RVA: 0x0004EF39 File Offset: 0x0004D139
		public bool DragEnabled
		{
			get
			{
				return this.native.IsDragEnabled();
			}
			set
			{
				this.native.EnableDrag(value);
			}
		}

		// Token: 0x06001337 RID: 4919 RVA: 0x0004EF47 File Offset: 0x0004D147
		public BBox GetBounds()
		{
			return this.native.BuildBounds();
		}

		// Token: 0x170002C1 RID: 705
		// (get) Token: 0x06001338 RID: 4920 RVA: 0x0004EF54 File Offset: 0x0004D154
		public float Density
		{
			get
			{
				return this.native.GetDensity();
			}
		}

		/// <summary>
		/// Sets a physical properties on all child <see cref="T:Sandbox.PhysicsShape">PhysicsShape</see>s.
		/// </summary>
		// Token: 0x06001339 RID: 4921 RVA: 0x0004EF61 File Offset: 0x0004D161
		public void SetSurface(string surf)
		{
			this.native.SetMaterialIndex(surf);
		}

		// Token: 0x04000445 RID: 1093
		internal IPhysicsBody native;

		// Token: 0x04000447 RID: 1095
		public float WaterLevel;

		// Token: 0x04000448 RID: 1096
		public TimeSince LastWaterEffect;
	}
}
