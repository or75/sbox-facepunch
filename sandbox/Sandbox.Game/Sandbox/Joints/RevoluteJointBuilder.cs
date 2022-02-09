using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x02000162 RID: 354
	public struct RevoluteJointBuilder
	{
		// Token: 0x06001A70 RID: 6768 RVA: 0x0006D0AB File Offset: 0x0006B2AB
		public RevoluteJointBuilder From(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(body, origin, basis);
			return this;
		}

		// Token: 0x06001A71 RID: 6769 RVA: 0x0006D0C1 File Offset: 0x0006B2C1
		public RevoluteJointBuilder To(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(body, origin, basis);
			return this;
		}

		// Token: 0x06001A72 RID: 6770 RVA: 0x0006D0D7 File Offset: 0x0006B2D7
		public RevoluteJointBuilder From(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x06001A73 RID: 6771 RVA: 0x0006D0EF File Offset: 0x0006B2EF
		public RevoluteJointBuilder To(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x06001A74 RID: 6772 RVA: 0x0006D107 File Offset: 0x0006B307
		public RevoluteJointBuilder From(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x06001A75 RID: 6773 RVA: 0x0006D11F File Offset: 0x0006B31F
		public RevoluteJointBuilder To(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x06001A76 RID: 6774 RVA: 0x0006D137 File Offset: 0x0006B337
		public RevoluteJointBuilder StartsNotActive()
		{
			this.common.StartsNotActive();
			return this;
		}

		// Token: 0x06001A77 RID: 6775 RVA: 0x0006D14A File Offset: 0x0006B34A
		public RevoluteJointBuilder WithCollisionsEnabled()
		{
			this.common.WithCollisionsEnabled();
			return this;
		}

		// Token: 0x06001A78 RID: 6776 RVA: 0x0006D15D File Offset: 0x0006B35D
		public RevoluteJointBuilder WithBlockSolverEnabled()
		{
			this.common.WithBlockSolverEnabled();
			return this;
		}

		// Token: 0x06001A79 RID: 6777 RVA: 0x0006D170 File Offset: 0x0006B370
		public RevoluteJointBuilder WithFriction(float value)
		{
			this.common.friction = value;
			return this;
		}

		// Token: 0x06001A7A RID: 6778 RVA: 0x0006D184 File Offset: 0x0006B384
		public RevoluteJointBuilder Breakable(float linearImpulse, float angularImpulse)
		{
			this.common.maxLinearConstraintImpulse = linearImpulse;
			this.common.maxAngularConstraintImpulse = angularImpulse;
			return this;
		}

		// Token: 0x06001A7B RID: 6779 RVA: 0x0006D1A4 File Offset: 0x0006B3A4
		public RevoluteJointBuilder WithPivot(Vector3 globalPivot)
		{
			this.common.SetPivot(globalPivot);
			return this;
		}

		// Token: 0x06001A7C RID: 6780 RVA: 0x0006D1B8 File Offset: 0x0006B3B8
		public RevoluteJointBuilder WithBasis(Rotation globalBasis)
		{
			this.common.SetBasis(globalBasis);
			return this;
		}

		/// <summary>
		/// Enables hinge limit
		/// </summary>
		/// <param name="minAngle">Minimum hinge angle in degrees</param>
		/// <param name="maxAngle">Maximum hinge angle in degrees</param>
		/// <returns></returns>
		// Token: 0x06001A7D RID: 6781 RVA: 0x0006D1CC File Offset: 0x0006B3CC
		public RevoluteJointBuilder WithLimitEnabled(float minAngle, float maxAngle)
		{
			this.enableLimit = 1;
			this.limitMinAngle = minAngle;
			this.limitMaxAngle = maxAngle;
			return this;
		}

		/// <summary>
		/// Enables motor with angle target (Use angular spring to 'pull' towards target angle)
		/// </summary>
		/// <param name="targetAngle">Angular motor target angle</param>
		/// <param name="frequency">Angular motor frequency</param>
		/// <param name="dampingRatio">Angular motor damping ratio</param>
		/// <returns></returns>
		// Token: 0x06001A7E RID: 6782 RVA: 0x0006D1E9 File Offset: 0x0006B3E9
		public RevoluteJointBuilder WithAngleMotor(float targetAngle, float frequency, float dampingRatio)
		{
			this.motorMode = PhysicsJointMotorMode.Position;
			this.motorTargetAngle = targetAngle;
			this.motorFrequency = frequency;
			this.motorDampingRatio = dampingRatio;
			return this;
		}

		/// <summary>
		/// Enables motor with velocity target (Use torque to reach desired relative velocity)
		/// </summary>
		/// <param name="targetVelocity">Angular motor target velocity</param>
		/// <param name="maxTorque">Angular motor maximum torque to reach target velocity</param>
		/// <returns></returns>
		// Token: 0x06001A7F RID: 6783 RVA: 0x0006D20D File Offset: 0x0006B40D
		public RevoluteJointBuilder WithVelocityMotor(float targetVelocity, float maxTorque)
		{
			this.motorMode = PhysicsJointMotorMode.Velocity;
			this.motorTargetVelocity = targetVelocity;
			this.motorMaxTorque = maxTorque;
			return this;
		}

		/// <summary>
		/// Finish creation of joint
		/// </summary>
		// Token: 0x06001A80 RID: 6784 RVA: 0x0006D22C File Offset: 0x0006B42C
		public RevoluteJoint Create()
		{
			return new RevoluteJoint
			{
				self = PhysJoints.AddRevoluteJoint(this)
			};
		}

		// Token: 0x0400074F RID: 1871
		internal PhysicsJointConfig common;

		// Token: 0x04000750 RID: 1872
		internal PhysicsJointMotorMode motorMode;

		// Token: 0x04000751 RID: 1873
		internal float motorTargetAngle;

		// Token: 0x04000752 RID: 1874
		internal float motorFrequency;

		// Token: 0x04000753 RID: 1875
		internal float motorDampingRatio;

		// Token: 0x04000754 RID: 1876
		internal float motorTargetVelocity;

		// Token: 0x04000755 RID: 1877
		internal float motorMaxTorque;

		// Token: 0x04000756 RID: 1878
		internal byte enableLimit;

		// Token: 0x04000757 RID: 1879
		internal float limitMinAngle;

		// Token: 0x04000758 RID: 1880
		internal float limitMaxAngle;
	}
}
