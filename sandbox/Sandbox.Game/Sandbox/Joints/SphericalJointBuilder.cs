using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x02000164 RID: 356
	public struct SphericalJointBuilder
	{
		// Token: 0x06001AAF RID: 6831 RVA: 0x0006D4F9 File Offset: 0x0006B6F9
		public SphericalJointBuilder From(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(body, origin, basis);
			return this;
		}

		// Token: 0x06001AB0 RID: 6832 RVA: 0x0006D50F File Offset: 0x0006B70F
		public SphericalJointBuilder To(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(body, origin, basis);
			return this;
		}

		// Token: 0x06001AB1 RID: 6833 RVA: 0x0006D525 File Offset: 0x0006B725
		public SphericalJointBuilder From(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x06001AB2 RID: 6834 RVA: 0x0006D53D File Offset: 0x0006B73D
		public SphericalJointBuilder To(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x06001AB3 RID: 6835 RVA: 0x0006D555 File Offset: 0x0006B755
		public SphericalJointBuilder From(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x06001AB4 RID: 6836 RVA: 0x0006D56D File Offset: 0x0006B76D
		public SphericalJointBuilder To(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x06001AB5 RID: 6837 RVA: 0x0006D585 File Offset: 0x0006B785
		public SphericalJointBuilder StartsNotActive()
		{
			this.common.StartsNotActive();
			return this;
		}

		// Token: 0x06001AB6 RID: 6838 RVA: 0x0006D598 File Offset: 0x0006B798
		public SphericalJointBuilder WithCollisionsEnabled()
		{
			this.common.WithCollisionsEnabled();
			return this;
		}

		// Token: 0x06001AB7 RID: 6839 RVA: 0x0006D5AB File Offset: 0x0006B7AB
		public SphericalJointBuilder WithBlockSolverEnabled()
		{
			this.common.WithBlockSolverEnabled();
			return this;
		}

		// Token: 0x06001AB8 RID: 6840 RVA: 0x0006D5BE File Offset: 0x0006B7BE
		public SphericalJointBuilder WithFriction(float value)
		{
			this.common.friction = value;
			return this;
		}

		// Token: 0x06001AB9 RID: 6841 RVA: 0x0006D5D2 File Offset: 0x0006B7D2
		public SphericalJointBuilder Breakable(float linearImpulse, float angularImpulse)
		{
			this.common.maxLinearConstraintImpulse = linearImpulse;
			this.common.maxAngularConstraintImpulse = angularImpulse;
			return this;
		}

		// Token: 0x06001ABA RID: 6842 RVA: 0x0006D5F2 File Offset: 0x0006B7F2
		public SphericalJointBuilder WithPivot(Vector3 globalPivot)
		{
			this.common.SetPivot(globalPivot);
			return this;
		}

		// Token: 0x06001ABB RID: 6843 RVA: 0x0006D606 File Offset: 0x0006B806
		public SphericalJointBuilder WithBasis(Rotation globalBasis)
		{
			this.common.SetBasis(globalBasis);
			return this;
		}

		/// <summary>
		/// Enables motor with angle target (Use angular spring to 'pull' towards target angle)
		/// </summary>
		/// <param name="targetRot">Angular motor target orientation</param>
		/// <param name="frequency">Angular motor frequency</param>
		/// <param name="dampingRatio">Angular motor damping ratio</param>
		/// <returns></returns>
		// Token: 0x06001ABC RID: 6844 RVA: 0x0006D61A File Offset: 0x0006B81A
		public SphericalJointBuilder WithAngleMotor(Rotation targetRot, float frequency, float dampingRatio)
		{
			this.motorMode = PhysicsJointMotorMode.Position;
			this.motorTargetOrientation = targetRot;
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
		// Token: 0x06001ABD RID: 6845 RVA: 0x0006D63E File Offset: 0x0006B83E
		public SphericalJointBuilder WithVelocityMotor(float targetVelocity, float maxTorque)
		{
			this.motorMode = PhysicsJointMotorMode.Velocity;
			this.motorTargetVelocity = targetVelocity;
			this.motorMaxTorque = maxTorque;
			return this;
		}

		/// <summary>
		/// Finish creation of joint
		/// </summary>
		// Token: 0x06001ABE RID: 6846 RVA: 0x0006D660 File Offset: 0x0006B860
		public SphericalJoint Create()
		{
			return new SphericalJoint
			{
				self = PhysJoints.AddSphericalJoint(this)
			};
		}

		// Token: 0x0400075A RID: 1882
		internal PhysicsJointConfig common;

		// Token: 0x0400075B RID: 1883
		internal PhysicsJointMotorMode motorMode;

		// Token: 0x0400075C RID: 1884
		internal Rotation motorTargetOrientation;

		// Token: 0x0400075D RID: 1885
		internal float motorFrequency;

		// Token: 0x0400075E RID: 1886
		internal float motorDampingRatio;

		// Token: 0x0400075F RID: 1887
		internal Vector3 motorTargetVelocity;

		// Token: 0x04000760 RID: 1888
		internal float motorMaxTorque;
	}
}
