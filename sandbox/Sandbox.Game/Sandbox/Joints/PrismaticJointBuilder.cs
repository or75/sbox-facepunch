using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x02000160 RID: 352
	public struct PrismaticJointBuilder
	{
		// Token: 0x06001A36 RID: 6710 RVA: 0x0006CCB5 File Offset: 0x0006AEB5
		public PrismaticJointBuilder From(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(body, origin, basis);
			return this;
		}

		// Token: 0x06001A37 RID: 6711 RVA: 0x0006CCCB File Offset: 0x0006AECB
		public PrismaticJointBuilder To(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(body, origin, basis);
			return this;
		}

		// Token: 0x06001A38 RID: 6712 RVA: 0x0006CCE1 File Offset: 0x0006AEE1
		public PrismaticJointBuilder From(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x06001A39 RID: 6713 RVA: 0x0006CCF9 File Offset: 0x0006AEF9
		public PrismaticJointBuilder To(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x06001A3A RID: 6714 RVA: 0x0006CD11 File Offset: 0x0006AF11
		public PrismaticJointBuilder From(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x06001A3B RID: 6715 RVA: 0x0006CD29 File Offset: 0x0006AF29
		public PrismaticJointBuilder To(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x06001A3C RID: 6716 RVA: 0x0006CD41 File Offset: 0x0006AF41
		public PrismaticJointBuilder StartsNotActive()
		{
			this.common.StartsNotActive();
			return this;
		}

		// Token: 0x06001A3D RID: 6717 RVA: 0x0006CD54 File Offset: 0x0006AF54
		public PrismaticJointBuilder WithCollisionsEnabled()
		{
			this.common.WithCollisionsEnabled();
			return this;
		}

		// Token: 0x06001A3E RID: 6718 RVA: 0x0006CD67 File Offset: 0x0006AF67
		public PrismaticJointBuilder WithBlockSolverEnabled()
		{
			this.common.WithBlockSolverEnabled();
			return this;
		}

		// Token: 0x06001A3F RID: 6719 RVA: 0x0006CD7A File Offset: 0x0006AF7A
		public PrismaticJointBuilder WithFriction(float value)
		{
			this.common.friction = value;
			return this;
		}

		// Token: 0x06001A40 RID: 6720 RVA: 0x0006CD8E File Offset: 0x0006AF8E
		public PrismaticJointBuilder Breakable(float linearImpulse, float angularImpulse)
		{
			this.common.maxLinearConstraintImpulse = linearImpulse;
			this.common.maxAngularConstraintImpulse = angularImpulse;
			return this;
		}

		// Token: 0x06001A41 RID: 6721 RVA: 0x0006CDAE File Offset: 0x0006AFAE
		public PrismaticJointBuilder WithPivot(Vector3 globalPivot)
		{
			this.common.SetPivot(globalPivot);
			return this;
		}

		// Token: 0x06001A42 RID: 6722 RVA: 0x0006CDC2 File Offset: 0x0006AFC2
		public PrismaticJointBuilder WithBasis(Rotation globalBasis)
		{
			this.common.SetBasis(globalBasis);
			return this;
		}

		// Token: 0x06001A43 RID: 6723 RVA: 0x0006CDD6 File Offset: 0x0006AFD6
		public PrismaticJointBuilder WithLimit(float min, float max)
		{
			this.m_bEnableLimit = true;
			this.m_flMinOffset = min;
			this.m_flMaxOffset = max;
			return this;
		}

		// Token: 0x06001A44 RID: 6724 RVA: 0x0006CDF3 File Offset: 0x0006AFF3
		public PrismaticJointBuilder WithPositionMotor(float targetOffset, float frequency, float dampingRatio)
		{
			this.motorMode = PhysicsJointMotorMode.Position;
			this.m_flMotorTargetOffset = targetOffset;
			this.m_flMotorFrequency = frequency;
			this.m_flMotorDampingRatio = dampingRatio;
			return this;
		}

		// Token: 0x06001A45 RID: 6725 RVA: 0x0006CE17 File Offset: 0x0006B017
		public PrismaticJointBuilder WithVelocityMotor(float targetVelocity, float maxForce)
		{
			this.motorMode = PhysicsJointMotorMode.Velocity;
			this.m_flMotorTargetVelocity = targetVelocity;
			this.m_flMotorMaxForce = maxForce;
			return this;
		}

		/// <summary>
		/// Finish creation of joint
		/// </summary>
		// Token: 0x06001A46 RID: 6726 RVA: 0x0006CE34 File Offset: 0x0006B034
		public PrismaticJoint Create()
		{
			return new PrismaticJoint
			{
				self = PhysJoints.AddPrismaticJoint(this)
			};
		}

		// Token: 0x04000744 RID: 1860
		internal PhysicsJointConfig common;

		// Token: 0x04000745 RID: 1861
		internal PhysicsJointMotorMode motorMode;

		// Token: 0x04000746 RID: 1862
		internal float m_flMotorTargetOffset;

		// Token: 0x04000747 RID: 1863
		internal float m_flMotorFrequency;

		// Token: 0x04000748 RID: 1864
		internal float m_flMotorDampingRatio;

		// Token: 0x04000749 RID: 1865
		internal float m_flMotorTargetVelocity;

		// Token: 0x0400074A RID: 1866
		internal float m_flMotorMaxForce;

		// Token: 0x0400074B RID: 1867
		internal bool m_bEnableLimit;

		// Token: 0x0400074C RID: 1868
		internal float m_flMinOffset;

		// Token: 0x0400074D RID: 1869
		internal float m_flMaxOffset;
	}
}
