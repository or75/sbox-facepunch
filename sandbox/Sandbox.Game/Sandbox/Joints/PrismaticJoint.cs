using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x02000161 RID: 353
	public struct PrismaticJoint : IPhysicsJoint
	{
		// Token: 0x06001A47 RID: 6727 RVA: 0x0006CE5C File Offset: 0x0006B05C
		public static implicit operator PhysicsJoint(PrismaticJoint value)
		{
			return value.self;
		}

		// Token: 0x1700048C RID: 1164
		// (get) Token: 0x06001A48 RID: 6728 RVA: 0x0006CE64 File Offset: 0x0006B064
		public bool IsValid
		{
			get
			{
				return this.self.IsValid();
			}
		}

		// Token: 0x06001A49 RID: 6729 RVA: 0x0006CE71 File Offset: 0x0006B071
		public void Remove()
		{
			if (this.IsValid)
			{
				this.self.Remove();
				this.self = null;
			}
		}

		// Token: 0x06001A4A RID: 6730 RVA: 0x0006CE8D File Offset: 0x0006B08D
		public void OnBreak(PhysicsJoint.BreakDelegate fn)
		{
			if (this.IsValid)
			{
				this.self.OnBreak(fn);
			}
		}

		// Token: 0x1700048D RID: 1165
		// (get) Token: 0x06001A4B RID: 6731 RVA: 0x0006CEA3 File Offset: 0x0006B0A3
		public bool IsActive
		{
			get
			{
				return this.IsValid && this.self.IsActive;
			}
		}

		// Token: 0x1700048E RID: 1166
		// (get) Token: 0x06001A4C RID: 6732 RVA: 0x0006CEBA File Offset: 0x0006B0BA
		// (set) Token: 0x06001A4D RID: 6733 RVA: 0x0006CEC7 File Offset: 0x0006B0C7
		public bool EnableCollision
		{
			get
			{
				return this.self.EnableCollision;
			}
			set
			{
				this.self.EnableCollision = value;
			}
		}

		// Token: 0x1700048F RID: 1167
		// (get) Token: 0x06001A4E RID: 6734 RVA: 0x0006CED5 File Offset: 0x0006B0D5
		// (set) Token: 0x06001A4F RID: 6735 RVA: 0x0006CEE2 File Offset: 0x0006B0E2
		public bool EnableLinearConstraint
		{
			get
			{
				return this.self.EnableLinearConstraint;
			}
			set
			{
				this.self.EnableLinearConstraint = value;
			}
		}

		// Token: 0x17000490 RID: 1168
		// (get) Token: 0x06001A50 RID: 6736 RVA: 0x0006CEF0 File Offset: 0x0006B0F0
		// (set) Token: 0x06001A51 RID: 6737 RVA: 0x0006CEFD File Offset: 0x0006B0FD
		public bool EnableAngularConstraint
		{
			get
			{
				return this.self.EnableAngularConstraint;
			}
			set
			{
				this.self.EnableAngularConstraint = value;
			}
		}

		// Token: 0x17000491 RID: 1169
		// (get) Token: 0x06001A52 RID: 6738 RVA: 0x0006CF0B File Offset: 0x0006B10B
		public PhysicsBody Body1
		{
			get
			{
				return this.self.Body1;
			}
		}

		// Token: 0x17000492 RID: 1170
		// (get) Token: 0x06001A53 RID: 6739 RVA: 0x0006CF18 File Offset: 0x0006B118
		public PhysicsBody Body2
		{
			get
			{
				return this.self.Body2;
			}
		}

		// Token: 0x17000493 RID: 1171
		// (get) Token: 0x06001A54 RID: 6740 RVA: 0x0006CF25 File Offset: 0x0006B125
		public Vector3 Anchor1
		{
			get
			{
				return this.self.Anchor1;
			}
		}

		// Token: 0x17000494 RID: 1172
		// (get) Token: 0x06001A55 RID: 6741 RVA: 0x0006CF32 File Offset: 0x0006B132
		public Vector3 Anchor2
		{
			get
			{
				return this.self.Anchor2;
			}
		}

		// Token: 0x17000495 RID: 1173
		// (get) Token: 0x06001A56 RID: 6742 RVA: 0x0006CF3F File Offset: 0x0006B13F
		// (set) Token: 0x06001A57 RID: 6743 RVA: 0x0006CF4C File Offset: 0x0006B14C
		public Vector3 LocalAnchor1
		{
			get
			{
				return this.self.LocalAnchor1;
			}
			set
			{
				this.self.LocalAnchor1 = value;
			}
		}

		// Token: 0x17000496 RID: 1174
		// (get) Token: 0x06001A58 RID: 6744 RVA: 0x0006CF5A File Offset: 0x0006B15A
		// (set) Token: 0x06001A59 RID: 6745 RVA: 0x0006CF67 File Offset: 0x0006B167
		public Vector3 LocalAnchor2
		{
			get
			{
				return this.self.LocalAnchor2;
			}
			set
			{
				this.self.LocalAnchor2 = value;
			}
		}

		// Token: 0x17000497 RID: 1175
		// (get) Token: 0x06001A5A RID: 6746 RVA: 0x0006CF75 File Offset: 0x0006B175
		public Rotation JointFrame1
		{
			get
			{
				return this.self.JointFrame1;
			}
		}

		// Token: 0x17000498 RID: 1176
		// (get) Token: 0x06001A5B RID: 6747 RVA: 0x0006CF82 File Offset: 0x0006B182
		public Rotation JointFrame2
		{
			get
			{
				return this.self.JointFrame2;
			}
		}

		// Token: 0x17000499 RID: 1177
		// (get) Token: 0x06001A5C RID: 6748 RVA: 0x0006CF8F File Offset: 0x0006B18F
		// (set) Token: 0x06001A5D RID: 6749 RVA: 0x0006CF9C File Offset: 0x0006B19C
		public Rotation LocalJointFrame1
		{
			get
			{
				return this.self.LocalJointFrame1;
			}
			set
			{
				this.self.LocalJointFrame1 = value;
			}
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06001A5E RID: 6750 RVA: 0x0006CFAA File Offset: 0x0006B1AA
		// (set) Token: 0x06001A5F RID: 6751 RVA: 0x0006CFB7 File Offset: 0x0006B1B7
		public Rotation LocalJointFrame2
		{
			get
			{
				return this.self.LocalJointFrame2;
			}
			set
			{
				this.self.LocalJointFrame2 = value;
			}
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06001A60 RID: 6752 RVA: 0x0006CFC5 File Offset: 0x0006B1C5
		// (set) Token: 0x06001A61 RID: 6753 RVA: 0x0006CFD2 File Offset: 0x0006B1D2
		public PhysicsJointMotorMode MotorMode
		{
			get
			{
				return PhysJoints.Prismatic_GetMotorMode(this.self);
			}
			set
			{
				PhysJoints.Prismatic_SetMotorMode(this.self, value);
			}
		}

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06001A62 RID: 6754 RVA: 0x0006CFE0 File Offset: 0x0006B1E0
		// (set) Token: 0x06001A63 RID: 6755 RVA: 0x0006CFED File Offset: 0x0006B1ED
		public float MotorTargetOffset
		{
			get
			{
				return PhysJoints.Prismatic_GetMotorTargetOffset(this.self);
			}
			set
			{
				PhysJoints.Prismatic_SetMotorTargetOffset(this.self, value);
			}
		}

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06001A64 RID: 6756 RVA: 0x0006CFFB File Offset: 0x0006B1FB
		// (set) Token: 0x06001A65 RID: 6757 RVA: 0x0006D008 File Offset: 0x0006B208
		public float MotorFrequency
		{
			get
			{
				return PhysJoints.Prismatic_GetMotorFrequency(this.self);
			}
			set
			{
				PhysJoints.Prismatic_SetMotorFrequency(this.self, value);
			}
		}

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06001A66 RID: 6758 RVA: 0x0006D016 File Offset: 0x0006B216
		// (set) Token: 0x06001A67 RID: 6759 RVA: 0x0006D023 File Offset: 0x0006B223
		public float MotorDampingRatio
		{
			get
			{
				return PhysJoints.Prismatic_GetMotorDampingRatio(this.self);
			}
			set
			{
				PhysJoints.Prismatic_SetMotorDampingRatio(this.self, value);
			}
		}

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x06001A68 RID: 6760 RVA: 0x0006D031 File Offset: 0x0006B231
		// (set) Token: 0x06001A69 RID: 6761 RVA: 0x0006D03E File Offset: 0x0006B23E
		public float MotorTargetVelocity
		{
			get
			{
				return PhysJoints.Prismatic_GetMotorTargetVelocity(this.self);
			}
			set
			{
				PhysJoints.Prismatic_SetMotorTargetVelocity(this.self, value);
			}
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x06001A6A RID: 6762 RVA: 0x0006D04C File Offset: 0x0006B24C
		// (set) Token: 0x06001A6B RID: 6763 RVA: 0x0006D059 File Offset: 0x0006B259
		public float MotorMaxForce
		{
			get
			{
				return PhysJoints.Prismatic_GetMotorMaxForce(this.self);
			}
			set
			{
				PhysJoints.Prismatic_SetMotorMaxForce(this.self, value);
			}
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06001A6C RID: 6764 RVA: 0x0006D067 File Offset: 0x0006B267
		// (set) Token: 0x06001A6D RID: 6765 RVA: 0x0006D074 File Offset: 0x0006B274
		public bool EnableLimit
		{
			get
			{
				return PhysJoints.Prismatic_IsLimitEnabled(this.self);
			}
			set
			{
				if (value)
				{
					PhysJoints.Prismatic_EnableLimit(this.self);
					return;
				}
				PhysJoints.Prismatic_DisableLimit(this.self);
			}
		}

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06001A6E RID: 6766 RVA: 0x0006D090 File Offset: 0x0006B290
		// (set) Token: 0x06001A6F RID: 6767 RVA: 0x0006D09D File Offset: 0x0006B29D
		public Vector2 LimitRange
		{
			get
			{
				return PhysJoints.Prismatic_GetLimitRange(this.self);
			}
			set
			{
				PhysJoints.Prismatic_SetLimitRange(this.self, value);
			}
		}

		// Token: 0x0400074E RID: 1870
		internal PhysicsJoint self;
	}
}
