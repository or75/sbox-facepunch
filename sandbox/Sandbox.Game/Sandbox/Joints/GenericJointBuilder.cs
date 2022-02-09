using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x0200015E RID: 350
	public struct GenericJointBuilder
	{
		// Token: 0x060019F5 RID: 6645 RVA: 0x0006C7C9 File Offset: 0x0006A9C9
		public GenericJointBuilder From(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(body, origin, basis);
			return this;
		}

		// Token: 0x060019F6 RID: 6646 RVA: 0x0006C7DF File Offset: 0x0006A9DF
		public GenericJointBuilder To(PhysicsBody body, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(body, origin, basis);
			return this;
		}

		// Token: 0x060019F7 RID: 6647 RVA: 0x0006C7F5 File Offset: 0x0006A9F5
		public GenericJointBuilder From(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x060019F8 RID: 6648 RVA: 0x0006C80D File Offset: 0x0006AA0D
		public GenericJointBuilder To(ModelEntity ent, int bodyIndex = 0, Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyIndex, origin, basis);
			return this;
		}

		// Token: 0x060019F9 RID: 6649 RVA: 0x0006C825 File Offset: 0x0006AA25
		public GenericJointBuilder From(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.From(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x060019FA RID: 6650 RVA: 0x0006C83D File Offset: 0x0006AA3D
		public GenericJointBuilder To(ModelEntity ent, string bodyName = "", Vector3? origin = null, Rotation? basis = null)
		{
			this.common.To(ent, bodyName, origin, basis);
			return this;
		}

		// Token: 0x060019FB RID: 6651 RVA: 0x0006C855 File Offset: 0x0006AA55
		public GenericJointBuilder StartsNotActive()
		{
			this.common.StartsNotActive();
			return this;
		}

		// Token: 0x060019FC RID: 6652 RVA: 0x0006C868 File Offset: 0x0006AA68
		public GenericJointBuilder WithCollisionsEnabled()
		{
			this.common.WithCollisionsEnabled();
			return this;
		}

		// Token: 0x060019FD RID: 6653 RVA: 0x0006C87B File Offset: 0x0006AA7B
		public GenericJointBuilder WithBlockSolverEnabled()
		{
			this.common.WithBlockSolverEnabled();
			return this;
		}

		// Token: 0x060019FE RID: 6654 RVA: 0x0006C88E File Offset: 0x0006AA8E
		public GenericJointBuilder WithFriction(float value)
		{
			this.common.friction = value;
			return this;
		}

		// Token: 0x060019FF RID: 6655 RVA: 0x0006C8A2 File Offset: 0x0006AAA2
		public GenericJointBuilder Breakable(float linearImpulse, float angularImpulse)
		{
			this.common.maxLinearConstraintImpulse = linearImpulse;
			this.common.maxAngularConstraintImpulse = angularImpulse;
			return this;
		}

		// Token: 0x06001A00 RID: 6656 RVA: 0x0006C8C2 File Offset: 0x0006AAC2
		public GenericJointBuilder WithPivot(Vector3 globalPivot)
		{
			this.common.SetPivot(globalPivot);
			return this;
		}

		// Token: 0x06001A01 RID: 6657 RVA: 0x0006C8D6 File Offset: 0x0006AAD6
		public GenericJointBuilder WithBasis(Rotation globalBasis)
		{
			this.common.SetBasis(globalBasis);
			return this;
		}

		// Token: 0x06001A02 RID: 6658 RVA: 0x0006C8EA File Offset: 0x0006AAEA
		public GenericJointBuilder WithLinearMotionLocked()
		{
			this.x.m_nLinearMotions = JointMotion.Locked;
			this.y.m_nLinearMotions = JointMotion.Locked;
			this.z.m_nLinearMotions = JointMotion.Locked;
			return this;
		}

		// Token: 0x06001A03 RID: 6659 RVA: 0x0006C916 File Offset: 0x0006AB16
		public GenericJointBuilder WithAngularMotionLocked()
		{
			this.x.m_nAngularMotions = JointMotion.Locked;
			this.y.m_nAngularMotions = JointMotion.Locked;
			this.z.m_nAngularMotions = JointMotion.Locked;
			return this;
		}

		// Token: 0x06001A04 RID: 6660 RVA: 0x0006C942 File Offset: 0x0006AB42
		public GenericJointBuilder WithLinearMotionX(JointMotion motion)
		{
			this.x.m_nLinearMotions = motion;
			return this;
		}

		// Token: 0x06001A05 RID: 6661 RVA: 0x0006C956 File Offset: 0x0006AB56
		public GenericJointBuilder WithLinearFrequencyX(float frequency)
		{
			this.x.m_flLinearFrequencies = frequency;
			return this;
		}

		// Token: 0x06001A06 RID: 6662 RVA: 0x0006C96A File Offset: 0x0006AB6A
		public GenericJointBuilder WithLinearDampingRatioX(float dampingRatio)
		{
			this.x.m_flLinearDampingRatios = dampingRatio;
			return this;
		}

		// Token: 0x06001A07 RID: 6663 RVA: 0x0006C97E File Offset: 0x0006AB7E
		public GenericJointBuilder WithLinearImpulseX(float impulse)
		{
			this.x.m_flMaxLinearImpulses = impulse;
			return this;
		}

		// Token: 0x06001A08 RID: 6664 RVA: 0x0006C992 File Offset: 0x0006AB92
		public GenericJointBuilder WithLinearMotionY(JointMotion motion)
		{
			this.y.m_nLinearMotions = motion;
			return this;
		}

		// Token: 0x06001A09 RID: 6665 RVA: 0x0006C9A6 File Offset: 0x0006ABA6
		public GenericJointBuilder WithLinearFrequencyY(float frequency)
		{
			this.y.m_flLinearFrequencies = frequency;
			return this;
		}

		// Token: 0x06001A0A RID: 6666 RVA: 0x0006C9BA File Offset: 0x0006ABBA
		public GenericJointBuilder WithLinearDampingRatioY(float dampingRatio)
		{
			this.y.m_flLinearDampingRatios = dampingRatio;
			return this;
		}

		// Token: 0x06001A0B RID: 6667 RVA: 0x0006C9CE File Offset: 0x0006ABCE
		public GenericJointBuilder WithLinearImpulseY(float impulse)
		{
			this.y.m_flMaxLinearImpulses = impulse;
			return this;
		}

		// Token: 0x06001A0C RID: 6668 RVA: 0x0006C9E2 File Offset: 0x0006ABE2
		public GenericJointBuilder WithLinearMotionZ(JointMotion motion)
		{
			this.z.m_nLinearMotions = motion;
			return this;
		}

		// Token: 0x06001A0D RID: 6669 RVA: 0x0006C9F6 File Offset: 0x0006ABF6
		public GenericJointBuilder WithLinearFrequencyZ(float frequency)
		{
			this.z.m_flLinearFrequencies = frequency;
			return this;
		}

		// Token: 0x06001A0E RID: 6670 RVA: 0x0006CA0A File Offset: 0x0006AC0A
		public GenericJointBuilder WithLinearDampingRatioZ(float dampingRatio)
		{
			this.z.m_flLinearDampingRatios = dampingRatio;
			return this;
		}

		// Token: 0x06001A0F RID: 6671 RVA: 0x0006CA1E File Offset: 0x0006AC1E
		public GenericJointBuilder WithLinearImpulseZ(float impulse)
		{
			this.z.m_flMaxLinearImpulses = impulse;
			return this;
		}

		// Token: 0x06001A10 RID: 6672 RVA: 0x0006CA32 File Offset: 0x0006AC32
		public GenericJointBuilder WithAngularMotionX(JointMotion motion)
		{
			this.x.m_nAngularMotions = motion;
			return this;
		}

		// Token: 0x06001A11 RID: 6673 RVA: 0x0006CA46 File Offset: 0x0006AC46
		public GenericJointBuilder WithAngularFrequencyX(float frequency)
		{
			this.x.m_flAngularFrequencies = frequency;
			return this;
		}

		// Token: 0x06001A12 RID: 6674 RVA: 0x0006CA5A File Offset: 0x0006AC5A
		public GenericJointBuilder WithAngularDampingRatioX(float dampingRatio)
		{
			this.x.m_flAngularDampingRatios = dampingRatio;
			return this;
		}

		// Token: 0x06001A13 RID: 6675 RVA: 0x0006CA6E File Offset: 0x0006AC6E
		public GenericJointBuilder WithAngularImpulseX(float impulse)
		{
			this.x.m_flMaxAngularImpulses = impulse;
			return this;
		}

		// Token: 0x06001A14 RID: 6676 RVA: 0x0006CA82 File Offset: 0x0006AC82
		public GenericJointBuilder WithAngularMotionY(JointMotion motion)
		{
			this.y.m_nAngularMotions = motion;
			return this;
		}

		// Token: 0x06001A15 RID: 6677 RVA: 0x0006CA96 File Offset: 0x0006AC96
		public GenericJointBuilder WithAngularFrequencyY(float frequency)
		{
			this.y.m_flAngularFrequencies = frequency;
			return this;
		}

		// Token: 0x06001A16 RID: 6678 RVA: 0x0006CAAA File Offset: 0x0006ACAA
		public GenericJointBuilder WithAngularDampingRatioY(float dampingRatio)
		{
			this.y.m_flAngularDampingRatios = dampingRatio;
			return this;
		}

		// Token: 0x06001A17 RID: 6679 RVA: 0x0006CABE File Offset: 0x0006ACBE
		public GenericJointBuilder WithAngularImpulseY(float impulse)
		{
			this.y.m_flMaxAngularImpulses = impulse;
			return this;
		}

		// Token: 0x06001A18 RID: 6680 RVA: 0x0006CAD2 File Offset: 0x0006ACD2
		public GenericJointBuilder WithAngularMotionZ(JointMotion motion)
		{
			this.z.m_nAngularMotions = motion;
			return this;
		}

		// Token: 0x06001A19 RID: 6681 RVA: 0x0006CAE6 File Offset: 0x0006ACE6
		public GenericJointBuilder WithAngularFrequencyZ(float frequency)
		{
			this.z.m_flAngularFrequencies = frequency;
			return this;
		}

		// Token: 0x06001A1A RID: 6682 RVA: 0x0006CAFA File Offset: 0x0006ACFA
		public GenericJointBuilder WithAngularDampingRatioZ(float dampingRatio)
		{
			this.z.m_flAngularDampingRatios = dampingRatio;
			return this;
		}

		// Token: 0x06001A1B RID: 6683 RVA: 0x0006CB0E File Offset: 0x0006AD0E
		public GenericJointBuilder WithAngularImpulseZ(float impulse)
		{
			this.z.m_flMaxAngularImpulses = impulse;
			return this;
		}

		/// <summary>
		/// Finish creation of joint
		/// </summary>
		// Token: 0x06001A1C RID: 6684 RVA: 0x0006CB24 File Offset: 0x0006AD24
		public GenericJoint Create()
		{
			return new GenericJoint
			{
				self = PhysJoints.AddGenericJoint(this)
			};
		}

		// Token: 0x0400073F RID: 1855
		internal PhysicsJointConfig common;

		// Token: 0x04000740 RID: 1856
		internal GenericJointBuilder.Axis x;

		// Token: 0x04000741 RID: 1857
		internal GenericJointBuilder.Axis y;

		// Token: 0x04000742 RID: 1858
		internal GenericJointBuilder.Axis z;

		// Token: 0x020002B2 RID: 690
		internal struct Axis
		{
			// Token: 0x04001318 RID: 4888
			public JointMotion m_nLinearMotions;

			// Token: 0x04001319 RID: 4889
			public float m_flLinearFrequencies;

			// Token: 0x0400131A RID: 4890
			public float m_flLinearDampingRatios;

			// Token: 0x0400131B RID: 4891
			public float m_flMaxLinearImpulses;

			// Token: 0x0400131C RID: 4892
			public JointMotion m_nAngularMotions;

			// Token: 0x0400131D RID: 4893
			public float m_flAngularFrequencies;

			// Token: 0x0400131E RID: 4894
			public float m_flAngularDampingRatios;

			// Token: 0x0400131F RID: 4895
			public float m_flMaxAngularImpulses;
		}
	}
}
