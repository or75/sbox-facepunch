using System;

namespace Sandbox.Joints
{
	// Token: 0x02000165 RID: 357
	public struct SphericalJoint : IPhysicsJoint
	{
		// Token: 0x06001ABF RID: 6847 RVA: 0x0006D688 File Offset: 0x0006B888
		public static implicit operator PhysicsJoint(SphericalJoint value)
		{
			return value.self;
		}

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06001AC0 RID: 6848 RVA: 0x0006D690 File Offset: 0x0006B890
		public bool IsValid
		{
			get
			{
				return this.self.IsValid();
			}
		}

		// Token: 0x06001AC1 RID: 6849 RVA: 0x0006D69D File Offset: 0x0006B89D
		public void Remove()
		{
			if (this.IsValid)
			{
				this.self.Remove();
				this.self = null;
			}
		}

		// Token: 0x06001AC2 RID: 6850 RVA: 0x0006D6B9 File Offset: 0x0006B8B9
		public void OnBreak(PhysicsJoint.BreakDelegate fn)
		{
			if (this.IsValid)
			{
				this.self.OnBreak(fn);
			}
		}

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06001AC3 RID: 6851 RVA: 0x0006D6CF File Offset: 0x0006B8CF
		public bool IsActive
		{
			get
			{
				return this.IsValid && this.self.IsActive;
			}
		}

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06001AC4 RID: 6852 RVA: 0x0006D6E6 File Offset: 0x0006B8E6
		// (set) Token: 0x06001AC5 RID: 6853 RVA: 0x0006D6F3 File Offset: 0x0006B8F3
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

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06001AC6 RID: 6854 RVA: 0x0006D701 File Offset: 0x0006B901
		// (set) Token: 0x06001AC7 RID: 6855 RVA: 0x0006D70E File Offset: 0x0006B90E
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

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x06001AC8 RID: 6856 RVA: 0x0006D71C File Offset: 0x0006B91C
		// (set) Token: 0x06001AC9 RID: 6857 RVA: 0x0006D729 File Offset: 0x0006B929
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

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x06001ACA RID: 6858 RVA: 0x0006D737 File Offset: 0x0006B937
		public PhysicsBody Body1
		{
			get
			{
				return this.self.Body1;
			}
		}

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x06001ACB RID: 6859 RVA: 0x0006D744 File Offset: 0x0006B944
		public PhysicsBody Body2
		{
			get
			{
				return this.self.Body2;
			}
		}

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06001ACC RID: 6860 RVA: 0x0006D751 File Offset: 0x0006B951
		public Vector3 Anchor1
		{
			get
			{
				return this.self.Anchor1;
			}
		}

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06001ACD RID: 6861 RVA: 0x0006D75E File Offset: 0x0006B95E
		public Vector3 Anchor2
		{
			get
			{
				return this.self.Anchor2;
			}
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06001ACE RID: 6862 RVA: 0x0006D76B File Offset: 0x0006B96B
		// (set) Token: 0x06001ACF RID: 6863 RVA: 0x0006D778 File Offset: 0x0006B978
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

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06001AD0 RID: 6864 RVA: 0x0006D786 File Offset: 0x0006B986
		// (set) Token: 0x06001AD1 RID: 6865 RVA: 0x0006D793 File Offset: 0x0006B993
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

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x06001AD2 RID: 6866 RVA: 0x0006D7A1 File Offset: 0x0006B9A1
		public Rotation JointFrame1
		{
			get
			{
				return this.self.JointFrame1;
			}
		}

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x06001AD3 RID: 6867 RVA: 0x0006D7AE File Offset: 0x0006B9AE
		public Rotation JointFrame2
		{
			get
			{
				return this.self.JointFrame2;
			}
		}

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x06001AD4 RID: 6868 RVA: 0x0006D7BB File Offset: 0x0006B9BB
		// (set) Token: 0x06001AD5 RID: 6869 RVA: 0x0006D7C8 File Offset: 0x0006B9C8
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

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x06001AD6 RID: 6870 RVA: 0x0006D7D6 File Offset: 0x0006B9D6
		// (set) Token: 0x06001AD7 RID: 6871 RVA: 0x0006D7E3 File Offset: 0x0006B9E3
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

		// Token: 0x04000761 RID: 1889
		internal PhysicsJoint self;
	}
}
