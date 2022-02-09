using System;

namespace Sandbox.Joints
{
	// Token: 0x0200015D RID: 349
	public struct ConicalJoint : IPhysicsJoint
	{
		// Token: 0x060019DC RID: 6620 RVA: 0x0006C660 File Offset: 0x0006A860
		public static implicit operator PhysicsJoint(ConicalJoint value)
		{
			return value.self;
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x060019DD RID: 6621 RVA: 0x0006C668 File Offset: 0x0006A868
		public bool IsValid
		{
			get
			{
				return this.self.IsValid();
			}
		}

		// Token: 0x060019DE RID: 6622 RVA: 0x0006C675 File Offset: 0x0006A875
		public void Remove()
		{
			if (this.IsValid)
			{
				this.self.Remove();
				this.self = null;
			}
		}

		// Token: 0x060019DF RID: 6623 RVA: 0x0006C691 File Offset: 0x0006A891
		public void OnBreak(PhysicsJoint.BreakDelegate fn)
		{
			if (this.IsValid)
			{
				this.self.OnBreak(fn);
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x060019E0 RID: 6624 RVA: 0x0006C6A7 File Offset: 0x0006A8A7
		public bool IsActive
		{
			get
			{
				return this.IsValid && this.self.IsActive;
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x060019E1 RID: 6625 RVA: 0x0006C6BE File Offset: 0x0006A8BE
		// (set) Token: 0x060019E2 RID: 6626 RVA: 0x0006C6CB File Offset: 0x0006A8CB
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

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x060019E3 RID: 6627 RVA: 0x0006C6D9 File Offset: 0x0006A8D9
		// (set) Token: 0x060019E4 RID: 6628 RVA: 0x0006C6E6 File Offset: 0x0006A8E6
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

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x060019E5 RID: 6629 RVA: 0x0006C6F4 File Offset: 0x0006A8F4
		// (set) Token: 0x060019E6 RID: 6630 RVA: 0x0006C701 File Offset: 0x0006A901
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

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x060019E7 RID: 6631 RVA: 0x0006C70F File Offset: 0x0006A90F
		public PhysicsBody Body1
		{
			get
			{
				return this.self.Body1;
			}
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x060019E8 RID: 6632 RVA: 0x0006C71C File Offset: 0x0006A91C
		public PhysicsBody Body2
		{
			get
			{
				return this.self.Body2;
			}
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x060019E9 RID: 6633 RVA: 0x0006C729 File Offset: 0x0006A929
		public Vector3 Anchor1
		{
			get
			{
				return this.self.Anchor1;
			}
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x060019EA RID: 6634 RVA: 0x0006C736 File Offset: 0x0006A936
		public Vector3 Anchor2
		{
			get
			{
				return this.self.Anchor2;
			}
		}

		// Token: 0x17000477 RID: 1143
		// (get) Token: 0x060019EB RID: 6635 RVA: 0x0006C743 File Offset: 0x0006A943
		// (set) Token: 0x060019EC RID: 6636 RVA: 0x0006C750 File Offset: 0x0006A950
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

		// Token: 0x17000478 RID: 1144
		// (get) Token: 0x060019ED RID: 6637 RVA: 0x0006C75E File Offset: 0x0006A95E
		// (set) Token: 0x060019EE RID: 6638 RVA: 0x0006C76B File Offset: 0x0006A96B
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

		// Token: 0x17000479 RID: 1145
		// (get) Token: 0x060019EF RID: 6639 RVA: 0x0006C779 File Offset: 0x0006A979
		public Rotation JointFrame1
		{
			get
			{
				return this.self.JointFrame1;
			}
		}

		// Token: 0x1700047A RID: 1146
		// (get) Token: 0x060019F0 RID: 6640 RVA: 0x0006C786 File Offset: 0x0006A986
		public Rotation JointFrame2
		{
			get
			{
				return this.self.JointFrame2;
			}
		}

		// Token: 0x1700047B RID: 1147
		// (get) Token: 0x060019F1 RID: 6641 RVA: 0x0006C793 File Offset: 0x0006A993
		// (set) Token: 0x060019F2 RID: 6642 RVA: 0x0006C7A0 File Offset: 0x0006A9A0
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

		// Token: 0x1700047C RID: 1148
		// (get) Token: 0x060019F3 RID: 6643 RVA: 0x0006C7AE File Offset: 0x0006A9AE
		// (set) Token: 0x060019F4 RID: 6644 RVA: 0x0006C7BB File Offset: 0x0006A9BB
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

		// Token: 0x0400073E RID: 1854
		internal PhysicsJoint self;
	}
}
