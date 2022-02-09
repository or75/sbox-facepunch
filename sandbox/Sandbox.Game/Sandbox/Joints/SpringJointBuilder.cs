using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x02000166 RID: 358
	public struct SpringJointBuilder
	{
		// Token: 0x06001AD8 RID: 6872 RVA: 0x0006D7F1 File Offset: 0x0006B9F1
		public SpringJointBuilder From(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(body, origin, basis);
			return this;
		}

		// Token: 0x06001AD9 RID: 6873 RVA: 0x0006D807 File Offset: 0x0006BA07
		public SpringJointBuilder To(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(body, origin, basis);
			return this;
		}

		// Token: 0x06001ADA RID: 6874 RVA: 0x0006D81D File Offset: 0x0006BA1D
		public SpringJointBuilder From(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x06001ADB RID: 6875 RVA: 0x0006D835 File Offset: 0x0006BA35
		public SpringJointBuilder To(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x06001ADC RID: 6876 RVA: 0x0006D84D File Offset: 0x0006BA4D
		public SpringJointBuilder From(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x06001ADD RID: 6877 RVA: 0x0006D865 File Offset: 0x0006BA65
		public SpringJointBuilder To(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x06001ADE RID: 6878 RVA: 0x0006D87D File Offset: 0x0006BA7D
		public SpringJointBuilder StartsNotActive()
		{
			this.common.StartsNotActive();
			return this;
		}

		// Token: 0x06001ADF RID: 6879 RVA: 0x0006D890 File Offset: 0x0006BA90
		public SpringJointBuilder WithCollisionsEnabled()
		{
			this.common.WithCollisionsEnabled();
			return this;
		}

		// Token: 0x06001AE0 RID: 6880 RVA: 0x0006D8A3 File Offset: 0x0006BAA3
		public SpringJointBuilder WithBlockSolverEnabled()
		{
			this.common.WithBlockSolverEnabled();
			return this;
		}

		// Token: 0x06001AE1 RID: 6881 RVA: 0x0006D8B6 File Offset: 0x0006BAB6
		public SpringJointBuilder WithFriction(float value)
		{
			this.common.friction = value;
			return this;
		}

		// Token: 0x06001AE2 RID: 6882 RVA: 0x0006D8CA File Offset: 0x0006BACA
		public SpringJointBuilder Breakable(float linearImpulse, float angularImpulse)
		{
			this.common.maxLinearConstraintImpulse = linearImpulse;
			this.common.maxAngularConstraintImpulse = angularImpulse;
			return this;
		}

		// Token: 0x06001AE3 RID: 6883 RVA: 0x0006D8EA File Offset: 0x0006BAEA
		public SpringJointBuilder WithPivot(Vector3 globalPivot)
		{
			this.common.SetPivot(globalPivot);
			return this;
		}

		// Token: 0x06001AE4 RID: 6884 RVA: 0x0006D8FE File Offset: 0x0006BAFE
		public SpringJointBuilder WithBasis(Rotation globalBasis)
		{
			this.common.SetBasis(globalBasis);
			return this;
		}

		// Token: 0x06001AE5 RID: 6885 RVA: 0x0006D912 File Offset: 0x0006BB12
		public SpringJointBuilder WithFrequency(float frequency)
		{
			this.m_flFrequency = frequency;
			return this;
		}

		// Token: 0x06001AE6 RID: 6886 RVA: 0x0006D921 File Offset: 0x0006BB21
		public SpringJointBuilder WithDampingRatio(float dampingRatio)
		{
			this.m_flDampingRatio = dampingRatio;
			return this;
		}

		// Token: 0x06001AE7 RID: 6887 RVA: 0x0006D930 File Offset: 0x0006BB30
		public SpringJointBuilder WithReferenceMass(float referenceMass)
		{
			this.m_flReferenceMass = referenceMass;
			return this;
		}

		// Token: 0x06001AE8 RID: 6888 RVA: 0x0006D93F File Offset: 0x0006BB3F
		public SpringJointBuilder WithMinRestLength(float minRestLength)
		{
			this.m_flMinRestLength = minRestLength;
			return this;
		}

		// Token: 0x06001AE9 RID: 6889 RVA: 0x0006D94E File Offset: 0x0006BB4E
		public SpringJointBuilder WithMaxRestLength(float maxRestLength)
		{
			this.m_flMaxRestLength = maxRestLength;
			return this;
		}

		/// <summary>
		/// Finish creation of joint
		/// </summary>
		// Token: 0x06001AEA RID: 6890 RVA: 0x0006D960 File Offset: 0x0006BB60
		public SpringJoint Create()
		{
			return new SpringJoint
			{
				self = PhysJoints.AddSpringJoint(this)
			};
		}

		// Token: 0x04000762 RID: 1890
		internal PhysicsJointConfig common;

		// Token: 0x04000763 RID: 1891
		internal float m_flFrequency;

		// Token: 0x04000764 RID: 1892
		internal float m_flDampingRatio;

		// Token: 0x04000765 RID: 1893
		internal float m_flReferenceMass;

		// Token: 0x04000766 RID: 1894
		internal float m_flMinRestLength;

		// Token: 0x04000767 RID: 1895
		internal float m_flMaxRestLength;
	}
}
