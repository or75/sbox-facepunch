using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x0200015C RID: 348
	public struct ConicalJointBuilder
	{
		// Token: 0x060019CC RID: 6604 RVA: 0x0006C4E1 File Offset: 0x0006A6E1
		public ConicalJointBuilder From(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(body, origin, basis);
			return this;
		}

		// Token: 0x060019CD RID: 6605 RVA: 0x0006C4F7 File Offset: 0x0006A6F7
		public ConicalJointBuilder To(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(body, origin, basis);
			return this;
		}

		// Token: 0x060019CE RID: 6606 RVA: 0x0006C50D File Offset: 0x0006A70D
		public ConicalJointBuilder From(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x060019CF RID: 6607 RVA: 0x0006C525 File Offset: 0x0006A725
		public ConicalJointBuilder To(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x060019D0 RID: 6608 RVA: 0x0006C53D File Offset: 0x0006A73D
		public ConicalJointBuilder From(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x060019D1 RID: 6609 RVA: 0x0006C555 File Offset: 0x0006A755
		public ConicalJointBuilder To(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x060019D2 RID: 6610 RVA: 0x0006C56D File Offset: 0x0006A76D
		public ConicalJointBuilder StartsNotActive()
		{
			this.common.StartsNotActive();
			return this;
		}

		// Token: 0x060019D3 RID: 6611 RVA: 0x0006C580 File Offset: 0x0006A780
		public ConicalJointBuilder WithCollisionsEnabled()
		{
			this.common.WithCollisionsEnabled();
			return this;
		}

		// Token: 0x060019D4 RID: 6612 RVA: 0x0006C593 File Offset: 0x0006A793
		public ConicalJointBuilder WithBlockSolverEnabled()
		{
			this.common.WithBlockSolverEnabled();
			return this;
		}

		// Token: 0x060019D5 RID: 6613 RVA: 0x0006C5A6 File Offset: 0x0006A7A6
		public ConicalJointBuilder WithFriction(float value)
		{
			this.common.friction = value;
			return this;
		}

		// Token: 0x060019D6 RID: 6614 RVA: 0x0006C5BA File Offset: 0x0006A7BA
		public ConicalJointBuilder Breakable(float linearImpulse, float angularImpulse)
		{
			this.common.maxLinearConstraintImpulse = linearImpulse;
			this.common.maxAngularConstraintImpulse = angularImpulse;
			return this;
		}

		// Token: 0x060019D7 RID: 6615 RVA: 0x0006C5DA File Offset: 0x0006A7DA
		public ConicalJointBuilder WithPivot(Vector3 globalPivot)
		{
			this.common.SetPivot(globalPivot);
			return this;
		}

		// Token: 0x060019D8 RID: 6616 RVA: 0x0006C5EE File Offset: 0x0006A7EE
		public ConicalJointBuilder WithBasis(Rotation globalBasis)
		{
			this.common.SetBasis(globalBasis);
			return this;
		}

		// Token: 0x060019D9 RID: 6617 RVA: 0x0006C602 File Offset: 0x0006A802
		public ConicalJointBuilder WithSwingLimit(float swingLimit)
		{
			this.m_bEnableSwingLimit = true;
			this.m_flSwingLimit = swingLimit;
			return this;
		}

		// Token: 0x060019DA RID: 6618 RVA: 0x0006C618 File Offset: 0x0006A818
		public ConicalJointBuilder WithTwistLimit(float minTwistLimit, float maxTwistLimit)
		{
			this.m_bEnableTwistLimit = true;
			this.m_flMinTwistAngle = minTwistLimit;
			this.m_flMaxTwistAngle = maxTwistLimit;
			return this;
		}

		/// <summary>
		/// Finish creation of joint
		/// </summary>
		// Token: 0x060019DB RID: 6619 RVA: 0x0006C638 File Offset: 0x0006A838
		public ConicalJoint Create()
		{
			return new ConicalJoint
			{
				self = PhysJoints.AddConicalJoint(this)
			};
		}

		// Token: 0x04000732 RID: 1842
		internal PhysicsJointConfig common;

		// Token: 0x04000733 RID: 1843
		internal PhysicsJointMotorMode motorMode;

		// Token: 0x04000734 RID: 1844
		internal Rotation m_qMotorTargetOrientation;

		// Token: 0x04000735 RID: 1845
		internal float m_flMotorFrequency;

		// Token: 0x04000736 RID: 1846
		internal float m_flMotorDampingRatio;

		// Token: 0x04000737 RID: 1847
		internal Vector3 m_vMotorTargetVelocity;

		// Token: 0x04000738 RID: 1848
		internal float m_flMotorMaxTorque;

		// Token: 0x04000739 RID: 1849
		internal bool m_bEnableSwingLimit;

		// Token: 0x0400073A RID: 1850
		internal float m_flSwingLimit;

		// Token: 0x0400073B RID: 1851
		internal bool m_bEnableTwistLimit;

		// Token: 0x0400073C RID: 1852
		internal float m_flMinTwistAngle;

		// Token: 0x0400073D RID: 1853
		internal float m_flMaxTwistAngle;
	}
}
