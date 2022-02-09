using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x02000163 RID: 355
	public struct RevoluteJoint : IPhysicsJoint
	{
		// Token: 0x06001A81 RID: 6785 RVA: 0x0006D254 File Offset: 0x0006B454
		public static implicit operator PhysicsJoint(RevoluteJoint value)
		{
			return value.self;
		}

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06001A82 RID: 6786 RVA: 0x0006D25C File Offset: 0x0006B45C
		public bool IsValid
		{
			get
			{
				return this.self.IsValid();
			}
		}

		// Token: 0x06001A83 RID: 6787 RVA: 0x0006D269 File Offset: 0x0006B469
		public void Remove()
		{
			if (this.IsValid)
			{
				this.self.Remove();
				this.self = null;
			}
		}

		// Token: 0x06001A84 RID: 6788 RVA: 0x0006D285 File Offset: 0x0006B485
		public void OnBreak(PhysicsJoint.BreakDelegate fn)
		{
			if (this.IsValid)
			{
				this.self.OnBreak(fn);
			}
		}

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06001A85 RID: 6789 RVA: 0x0006D29B File Offset: 0x0006B49B
		public bool IsActive
		{
			get
			{
				return this.IsValid && this.self.IsActive;
			}
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x06001A86 RID: 6790 RVA: 0x0006D2B2 File Offset: 0x0006B4B2
		// (set) Token: 0x06001A87 RID: 6791 RVA: 0x0006D2BF File Offset: 0x0006B4BF
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

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x06001A88 RID: 6792 RVA: 0x0006D2CD File Offset: 0x0006B4CD
		// (set) Token: 0x06001A89 RID: 6793 RVA: 0x0006D2DA File Offset: 0x0006B4DA
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

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x06001A8A RID: 6794 RVA: 0x0006D2E8 File Offset: 0x0006B4E8
		// (set) Token: 0x06001A8B RID: 6795 RVA: 0x0006D2F5 File Offset: 0x0006B4F5
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

		// Token: 0x170004A8 RID: 1192
		// (get) Token: 0x06001A8C RID: 6796 RVA: 0x0006D303 File Offset: 0x0006B503
		public PhysicsBody Body1
		{
			get
			{
				return this.self.Body1;
			}
		}

		// Token: 0x170004A9 RID: 1193
		// (get) Token: 0x06001A8D RID: 6797 RVA: 0x0006D310 File Offset: 0x0006B510
		public PhysicsBody Body2
		{
			get
			{
				return this.self.Body2;
			}
		}

		// Token: 0x170004AA RID: 1194
		// (get) Token: 0x06001A8E RID: 6798 RVA: 0x0006D31D File Offset: 0x0006B51D
		public Vector3 Anchor1
		{
			get
			{
				return this.self.Anchor1;
			}
		}

		// Token: 0x170004AB RID: 1195
		// (get) Token: 0x06001A8F RID: 6799 RVA: 0x0006D32A File Offset: 0x0006B52A
		public Vector3 Anchor2
		{
			get
			{
				return this.self.Anchor2;
			}
		}

		// Token: 0x170004AC RID: 1196
		// (get) Token: 0x06001A90 RID: 6800 RVA: 0x0006D337 File Offset: 0x0006B537
		// (set) Token: 0x06001A91 RID: 6801 RVA: 0x0006D344 File Offset: 0x0006B544
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

		// Token: 0x170004AD RID: 1197
		// (get) Token: 0x06001A92 RID: 6802 RVA: 0x0006D352 File Offset: 0x0006B552
		// (set) Token: 0x06001A93 RID: 6803 RVA: 0x0006D35F File Offset: 0x0006B55F
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

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x06001A94 RID: 6804 RVA: 0x0006D36D File Offset: 0x0006B56D
		public Rotation JointFrame1
		{
			get
			{
				return this.self.JointFrame1;
			}
		}

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06001A95 RID: 6805 RVA: 0x0006D37A File Offset: 0x0006B57A
		public Rotation JointFrame2
		{
			get
			{
				return this.self.JointFrame2;
			}
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06001A96 RID: 6806 RVA: 0x0006D387 File Offset: 0x0006B587
		// (set) Token: 0x06001A97 RID: 6807 RVA: 0x0006D394 File Offset: 0x0006B594
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

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06001A98 RID: 6808 RVA: 0x0006D3A2 File Offset: 0x0006B5A2
		// (set) Token: 0x06001A99 RID: 6809 RVA: 0x0006D3AF File Offset: 0x0006B5AF
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

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06001A9A RID: 6810 RVA: 0x0006D3BD File Offset: 0x0006B5BD
		// (set) Token: 0x06001A9B RID: 6811 RVA: 0x0006D3CA File Offset: 0x0006B5CA
		public PhysicsJointMotorMode MotorMode
		{
			get
			{
				return PhysJoints.Revolute_GetMotorMode(this.self);
			}
			set
			{
				PhysJoints.Revolute_SetMotorMode(this.self, value);
			}
		}

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x06001A9C RID: 6812 RVA: 0x0006D3D8 File Offset: 0x0006B5D8
		// (set) Token: 0x06001A9D RID: 6813 RVA: 0x0006D3E5 File Offset: 0x0006B5E5
		public float MotorTargetAngle
		{
			get
			{
				return PhysJoints.Revolute_GetMotorTargetAngle(this.self);
			}
			set
			{
				PhysJoints.Revolute_SetMotorTargetAngle(this.self, value);
			}
		}

		// Token: 0x170004B4 RID: 1204
		// (get) Token: 0x06001A9E RID: 6814 RVA: 0x0006D3F3 File Offset: 0x0006B5F3
		// (set) Token: 0x06001A9F RID: 6815 RVA: 0x0006D400 File Offset: 0x0006B600
		public float MotorFrequency
		{
			get
			{
				return PhysJoints.Revolute_GetMotorFrequency(this.self);
			}
			set
			{
				PhysJoints.Revolute_SetMotorFrequency(this.self, value);
			}
		}

		// Token: 0x170004B5 RID: 1205
		// (get) Token: 0x06001AA0 RID: 6816 RVA: 0x0006D40E File Offset: 0x0006B60E
		// (set) Token: 0x06001AA1 RID: 6817 RVA: 0x0006D41B File Offset: 0x0006B61B
		public float MotorDampingRatio
		{
			get
			{
				return PhysJoints.Revolute_GetMotorDampingRatio(this.self);
			}
			set
			{
				PhysJoints.Revolute_SetMotorDampingRatio(this.self, value);
			}
		}

		// Token: 0x170004B6 RID: 1206
		// (get) Token: 0x06001AA2 RID: 6818 RVA: 0x0006D429 File Offset: 0x0006B629
		// (set) Token: 0x06001AA3 RID: 6819 RVA: 0x0006D436 File Offset: 0x0006B636
		public float MotorTargetVelocity
		{
			get
			{
				return PhysJoints.Revolute_GetMotorTargetVelocity(this.self);
			}
			set
			{
				PhysJoints.Revolute_SetMotorTargetVelocity(this.self, value);
			}
		}

		// Token: 0x170004B7 RID: 1207
		// (get) Token: 0x06001AA4 RID: 6820 RVA: 0x0006D444 File Offset: 0x0006B644
		// (set) Token: 0x06001AA5 RID: 6821 RVA: 0x0006D451 File Offset: 0x0006B651
		public float MotorMaxTorque
		{
			get
			{
				return PhysJoints.Revolute_GetMotorMaxTorque(this.self);
			}
			set
			{
				PhysJoints.Revolute_SetMotorMaxTorque(this.self, value);
			}
		}

		// Token: 0x170004B8 RID: 1208
		// (set) Token: 0x06001AA6 RID: 6822 RVA: 0x0006D45F File Offset: 0x0006B65F
		public float MotorFriction
		{
			set
			{
				PhysJoints.Revolute_SetMotorFriction(this.self, value);
			}
		}

		// Token: 0x06001AA7 RID: 6823 RVA: 0x0006D46D File Offset: 0x0006B66D
		public void EnableLimit()
		{
			PhysJoints.Revolute_EnableLimit(this.self);
		}

		// Token: 0x06001AA8 RID: 6824 RVA: 0x0006D47A File Offset: 0x0006B67A
		public void DisableLimit()
		{
			PhysJoints.Revolute_DisableLimit(this.self);
		}

		// Token: 0x170004B9 RID: 1209
		// (get) Token: 0x06001AA9 RID: 6825 RVA: 0x0006D487 File Offset: 0x0006B687
		public bool IsLimitEnabled
		{
			get
			{
				return PhysJoints.Revolute_IsLimitEnabled(this.self);
			}
		}

		// Token: 0x170004BA RID: 1210
		// (get) Token: 0x06001AAA RID: 6826 RVA: 0x0006D494 File Offset: 0x0006B694
		// (set) Token: 0x06001AAB RID: 6827 RVA: 0x0006D4B7 File Offset: 0x0006B6B7
		public Vector2 LimitRange
		{
			get
			{
				float min;
				float max;
				PhysJoints.Revolute_GetLimitRange(this.self, out min, out max);
				return new Vector2(min, max);
			}
			set
			{
				PhysJoints.Revolute_SetLimitRange(this.self, value.x, value.y);
			}
		}

		// Token: 0x170004BB RID: 1211
		// (get) Token: 0x06001AAC RID: 6828 RVA: 0x0006D4D2 File Offset: 0x0006B6D2
		public float Angle
		{
			get
			{
				return PhysJoints.Revolute_GetAngle(this.self);
			}
		}

		// Token: 0x170004BC RID: 1212
		// (get) Token: 0x06001AAD RID: 6829 RVA: 0x0006D4DF File Offset: 0x0006B6DF
		public float AngleSpeed
		{
			get
			{
				return PhysJoints.Revolute_GetAngleSpeed(this.self);
			}
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06001AAE RID: 6830 RVA: 0x0006D4EC File Offset: 0x0006B6EC
		public Vector3 AngleAxis
		{
			get
			{
				return PhysJoints.Revolute_GetAngleAxis(this.self);
			}
		}

		// Token: 0x04000759 RID: 1881
		internal PhysicsJoint self;
	}
}
