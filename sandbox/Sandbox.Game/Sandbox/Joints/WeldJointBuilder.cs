using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x02000168 RID: 360
	public struct WeldJointBuilder
	{
		// Token: 0x06001B0E RID: 6926 RVA: 0x0006DB84 File Offset: 0x0006BD84
		public WeldJointBuilder From(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(body, origin, basis);
			return this;
		}

		// Token: 0x06001B0F RID: 6927 RVA: 0x0006DB9A File Offset: 0x0006BD9A
		public WeldJointBuilder To(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(body, origin, basis);
			return this;
		}

		// Token: 0x06001B10 RID: 6928 RVA: 0x0006DBB0 File Offset: 0x0006BDB0
		public WeldJointBuilder From(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x06001B11 RID: 6929 RVA: 0x0006DBC8 File Offset: 0x0006BDC8
		public WeldJointBuilder To(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x06001B12 RID: 6930 RVA: 0x0006DBE0 File Offset: 0x0006BDE0
		public WeldJointBuilder From(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x06001B13 RID: 6931 RVA: 0x0006DBF8 File Offset: 0x0006BDF8
		public WeldJointBuilder To(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x06001B14 RID: 6932 RVA: 0x0006DC10 File Offset: 0x0006BE10
		public WeldJointBuilder StartsNotActive()
		{
			this.common.StartsNotActive();
			return this;
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x0006DC23 File Offset: 0x0006BE23
		public WeldJointBuilder WithCollisionsEnabled()
		{
			this.common.WithCollisionsEnabled();
			return this;
		}

		// Token: 0x06001B16 RID: 6934 RVA: 0x0006DC36 File Offset: 0x0006BE36
		public WeldJointBuilder WithBlockSolverEnabled()
		{
			this.common.WithBlockSolverEnabled();
			return this;
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x0006DC49 File Offset: 0x0006BE49
		public WeldJointBuilder WithFriction(float value)
		{
			this.common.friction = value;
			return this;
		}

		// Token: 0x06001B18 RID: 6936 RVA: 0x0006DC5D File Offset: 0x0006BE5D
		public WeldJointBuilder Breakable(float linearImpulse, float angularImpulse)
		{
			this.common.maxLinearConstraintImpulse = linearImpulse;
			this.common.maxAngularConstraintImpulse = angularImpulse;
			return this;
		}

		// Token: 0x06001B19 RID: 6937 RVA: 0x0006DC7D File Offset: 0x0006BE7D
		public WeldJointBuilder WithPivot(Vector3 globalPivot)
		{
			this.common.SetPivot(globalPivot);
			return this;
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x0006DC91 File Offset: 0x0006BE91
		public WeldJointBuilder WithBasis(Rotation globalBasis)
		{
			this.common.SetBasis(globalBasis);
			return this;
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x0006DCA5 File Offset: 0x0006BEA5
		public WeldJointBuilder WithLinearSpring(float frequency, float dampingRatio, float maxForce)
		{
			this.linearFrequency = frequency;
			this.linearDampingRatio = dampingRatio;
			this.linearMaxForce = maxForce;
			return this;
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x0006DCC2 File Offset: 0x0006BEC2
		public WeldJointBuilder WithAngularSpring(float frequency, float dampingRatio, float maxTorque)
		{
			this.angularFrequency = frequency;
			this.angularDampingRatio = dampingRatio;
			this.angularMaxTorque = maxTorque;
			return this;
		}

		/// <summary>
		/// Finish creation of joint
		/// </summary>
		// Token: 0x06001B1D RID: 6941 RVA: 0x0006DCE0 File Offset: 0x0006BEE0
		public WeldJoint Create()
		{
			return new WeldJoint
			{
				self = PhysJoints.AddWeldJoint(this)
			};
		}

		// Token: 0x04000769 RID: 1897
		internal PhysicsJointConfig common;

		// Token: 0x0400076A RID: 1898
		internal float linearFrequency;

		// Token: 0x0400076B RID: 1899
		internal float linearDampingRatio;

		// Token: 0x0400076C RID: 1900
		internal float linearMaxForce;

		// Token: 0x0400076D RID: 1901
		internal float angularFrequency;

		// Token: 0x0400076E RID: 1902
		internal float angularDampingRatio;

		// Token: 0x0400076F RID: 1903
		internal float angularMaxTorque;
	}
}
