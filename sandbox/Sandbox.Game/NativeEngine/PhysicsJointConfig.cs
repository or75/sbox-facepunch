using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000060 RID: 96
	internal struct PhysicsJointConfig
	{
		// Token: 0x06000BBF RID: 3007 RVA: 0x0003D5F9 File Offset: 0x0003B7F9
		private static PhysicsBody GetPhysicsBody(ModelEntity ent, int bodyIndex)
		{
			if (!ent.IsValid())
			{
				return null;
			}
			if (ent is WorldEntity)
			{
				return PhysicsWorld.WorldBody;
			}
			if (ent.PhysicsGroup != null)
			{
				return ent.PhysicsGroup.GetBody(bodyIndex);
			}
			return ent.PhysicsBody;
		}

		// Token: 0x06000BC0 RID: 3008 RVA: 0x0003D62E File Offset: 0x0003B82E
		private static PhysicsBody GetPhysicsBody(ModelEntity ent, string bodyName)
		{
			if (!ent.IsValid())
			{
				return null;
			}
			if (ent is WorldEntity)
			{
				return PhysicsWorld.WorldBody;
			}
			if (ent.PhysicsGroup != null)
			{
				return ent.PhysicsGroup.GetBody(bodyName);
			}
			return ent.PhysicsBody;
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x0003D663 File Offset: 0x0003B863
		public void From(ModelEntity ent, int bodyIndex, Vector3? origin = null, Rotation? basis = null)
		{
			this.From(PhysicsJointConfig.GetPhysicsBody(ent, bodyIndex), origin, basis);
		}

		// Token: 0x06000BC2 RID: 3010 RVA: 0x0003D675 File Offset: 0x0003B875
		public void To(ModelEntity ent, int bodyIndex, Vector3? origin = null, Rotation? basis = null)
		{
			this.To(PhysicsJointConfig.GetPhysicsBody(ent, bodyIndex), origin, basis);
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x0003D687 File Offset: 0x0003B887
		public void From(ModelEntity ent, string bodyName, Vector3? origin = null, Rotation? basis = null)
		{
			this.From(PhysicsJointConfig.GetPhysicsBody(ent, bodyName), origin, basis);
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x0003D699 File Offset: 0x0003B899
		public void To(ModelEntity ent, string bodyName, Vector3? origin = null, Rotation? basis = null)
		{
			this.To(PhysicsJointConfig.GetPhysicsBody(ent, bodyName), origin, basis);
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x0003D6AC File Offset: 0x0003B8AC
		public void From(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			if (body == null || body.native.IsNull)
			{
				return;
			}
			this.body1 = body.native;
			this.localOrigin1 = origin ?? Vector3.Zero;
			this.localBasis1 = basis ?? Rotation.Identity;
		}

		// Token: 0x06000BC6 RID: 3014 RVA: 0x0003D714 File Offset: 0x0003B914
		public void To(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			if (body == null || body.native.IsNull)
			{
				return;
			}
			this.body2 = body.native;
			this.localOrigin2 = origin ?? Vector3.Zero;
			this.localBasis2 = basis ?? Rotation.Identity;
		}

		// Token: 0x06000BC7 RID: 3015 RVA: 0x0003D77C File Offset: 0x0003B97C
		public void SetPivot(Vector3 globalPivot)
		{
			if (this.body1.IsNull || this.body2.IsNull)
			{
				return;
			}
			this.localOrigin1 = this.body1.TransformPointToLocal(globalPivot);
			this.localOrigin2 = this.body2.TransformPointToLocal(globalPivot);
		}

		// Token: 0x06000BC8 RID: 3016 RVA: 0x0003D7C8 File Offset: 0x0003B9C8
		public void SetBasis(Rotation globalBasis)
		{
			if (this.body1.IsNull || this.body2.IsNull)
			{
				return;
			}
			this.localBasis1 = this.body1.GetOrientation().Conjugate * globalBasis;
			this.localBasis2 = this.body2.GetOrientation().Conjugate * globalBasis;
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x0003D82E File Offset: 0x0003BA2E
		public void WithCollisionsEnabled()
		{
			this.enableCollision = 1;
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x0003D837 File Offset: 0x0003BA37
		public void WithBlockSolverEnabled()
		{
			this.useBlockSolver = 1;
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0003D840 File Offset: 0x0003BA40
		public void StartsNotActive()
		{
			this.startsNotActive = 1;
		}

		// Token: 0x0400010E RID: 270
		public IPhysicsBody body1;

		// Token: 0x0400010F RID: 271
		public IPhysicsBody body2;

		// Token: 0x04000110 RID: 272
		public Vector3 localOrigin1;

		// Token: 0x04000111 RID: 273
		public Rotation localBasis1;

		// Token: 0x04000112 RID: 274
		public Vector3 localOrigin2;

		// Token: 0x04000113 RID: 275
		public Rotation localBasis2;

		// Token: 0x04000114 RID: 276
		public byte startsNotActive;

		// Token: 0x04000115 RID: 277
		public byte enableCollision;

		// Token: 0x04000116 RID: 278
		public byte useBlockSolver;

		// Token: 0x04000117 RID: 279
		public float friction;

		// Token: 0x04000118 RID: 280
		public float maxLinearConstraintImpulse;

		// Token: 0x04000119 RID: 281
		public float maxAngularConstraintImpulse;
	}
}
