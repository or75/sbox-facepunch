using System;

namespace Sandbox.Joints
{
	// Token: 0x0200015F RID: 351
	public struct GenericJoint : IPhysicsJoint
	{
		// Token: 0x06001A1D RID: 6685 RVA: 0x0006CB4C File Offset: 0x0006AD4C
		public static implicit operator PhysicsJoint(GenericJoint value)
		{
			return value.self;
		}

		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06001A1E RID: 6686 RVA: 0x0006CB54 File Offset: 0x0006AD54
		public bool IsValid
		{
			get
			{
				return this.self.IsValid();
			}
		}

		// Token: 0x06001A1F RID: 6687 RVA: 0x0006CB61 File Offset: 0x0006AD61
		public void Remove()
		{
			if (this.IsValid)
			{
				this.self.Remove();
				this.self = null;
			}
		}

		// Token: 0x06001A20 RID: 6688 RVA: 0x0006CB7D File Offset: 0x0006AD7D
		public void OnBreak(PhysicsJoint.BreakDelegate fn)
		{
			if (this.IsValid)
			{
				this.self.OnBreak(fn);
			}
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06001A21 RID: 6689 RVA: 0x0006CB93 File Offset: 0x0006AD93
		public bool IsActive
		{
			get
			{
				return this.IsValid && this.self.IsActive;
			}
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06001A22 RID: 6690 RVA: 0x0006CBAA File Offset: 0x0006ADAA
		// (set) Token: 0x06001A23 RID: 6691 RVA: 0x0006CBB7 File Offset: 0x0006ADB7
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

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06001A24 RID: 6692 RVA: 0x0006CBC5 File Offset: 0x0006ADC5
		// (set) Token: 0x06001A25 RID: 6693 RVA: 0x0006CBD2 File Offset: 0x0006ADD2
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

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06001A26 RID: 6694 RVA: 0x0006CBE0 File Offset: 0x0006ADE0
		// (set) Token: 0x06001A27 RID: 6695 RVA: 0x0006CBED File Offset: 0x0006ADED
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

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06001A28 RID: 6696 RVA: 0x0006CBFB File Offset: 0x0006ADFB
		public PhysicsBody Body1
		{
			get
			{
				return this.self.Body1;
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06001A29 RID: 6697 RVA: 0x0006CC08 File Offset: 0x0006AE08
		public PhysicsBody Body2
		{
			get
			{
				return this.self.Body2;
			}
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06001A2A RID: 6698 RVA: 0x0006CC15 File Offset: 0x0006AE15
		public Vector3 Anchor1
		{
			get
			{
				return this.self.Anchor1;
			}
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06001A2B RID: 6699 RVA: 0x0006CC22 File Offset: 0x0006AE22
		public Vector3 Anchor2
		{
			get
			{
				return this.self.Anchor2;
			}
		}

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06001A2C RID: 6700 RVA: 0x0006CC2F File Offset: 0x0006AE2F
		// (set) Token: 0x06001A2D RID: 6701 RVA: 0x0006CC3C File Offset: 0x0006AE3C
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

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06001A2E RID: 6702 RVA: 0x0006CC4A File Offset: 0x0006AE4A
		// (set) Token: 0x06001A2F RID: 6703 RVA: 0x0006CC57 File Offset: 0x0006AE57
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

		// Token: 0x17000488 RID: 1160
		// (get) Token: 0x06001A30 RID: 6704 RVA: 0x0006CC65 File Offset: 0x0006AE65
		public Rotation JointFrame1
		{
			get
			{
				return this.self.JointFrame1;
			}
		}

		// Token: 0x17000489 RID: 1161
		// (get) Token: 0x06001A31 RID: 6705 RVA: 0x0006CC72 File Offset: 0x0006AE72
		public Rotation JointFrame2
		{
			get
			{
				return this.self.JointFrame2;
			}
		}

		// Token: 0x1700048A RID: 1162
		// (get) Token: 0x06001A32 RID: 6706 RVA: 0x0006CC7F File Offset: 0x0006AE7F
		// (set) Token: 0x06001A33 RID: 6707 RVA: 0x0006CC8C File Offset: 0x0006AE8C
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

		// Token: 0x1700048B RID: 1163
		// (get) Token: 0x06001A34 RID: 6708 RVA: 0x0006CC9A File Offset: 0x0006AE9A
		// (set) Token: 0x06001A35 RID: 6709 RVA: 0x0006CCA7 File Offset: 0x0006AEA7
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

		// Token: 0x04000743 RID: 1859
		internal PhysicsJoint self;
	}
}
