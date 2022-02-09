using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x02000169 RID: 361
	public struct WeldJoint : IPhysicsJoint
	{
		// Token: 0x06001B1E RID: 6942 RVA: 0x0006DD08 File Offset: 0x0006BF08
		public static implicit operator PhysicsJoint(WeldJoint value)
		{
			return value.self;
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06001B1F RID: 6943 RVA: 0x0006DD10 File Offset: 0x0006BF10
		public bool IsValid
		{
			get
			{
				return this.self.IsValid();
			}
		}

		// Token: 0x06001B20 RID: 6944 RVA: 0x0006DD1D File Offset: 0x0006BF1D
		public void Remove()
		{
			if (this.IsValid)
			{
				this.self.Remove();
				this.self = null;
			}
		}

		// Token: 0x06001B21 RID: 6945 RVA: 0x0006DD39 File Offset: 0x0006BF39
		public void OnBreak(PhysicsJoint.BreakDelegate fn)
		{
			if (this.IsValid)
			{
				this.self.OnBreak(fn);
			}
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06001B22 RID: 6946 RVA: 0x0006DD4F File Offset: 0x0006BF4F
		public bool IsActive
		{
			get
			{
				return this.IsValid && this.self.IsActive;
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06001B23 RID: 6947 RVA: 0x0006DD66 File Offset: 0x0006BF66
		// (set) Token: 0x06001B24 RID: 6948 RVA: 0x0006DD73 File Offset: 0x0006BF73
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

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x06001B25 RID: 6949 RVA: 0x0006DD81 File Offset: 0x0006BF81
		// (set) Token: 0x06001B26 RID: 6950 RVA: 0x0006DD8E File Offset: 0x0006BF8E
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

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x06001B27 RID: 6951 RVA: 0x0006DD9C File Offset: 0x0006BF9C
		// (set) Token: 0x06001B28 RID: 6952 RVA: 0x0006DDA9 File Offset: 0x0006BFA9
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

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x06001B29 RID: 6953 RVA: 0x0006DDB7 File Offset: 0x0006BFB7
		public PhysicsBody Body1
		{
			get
			{
				return this.self.Body1;
			}
		}

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x06001B2A RID: 6954 RVA: 0x0006DDC4 File Offset: 0x0006BFC4
		public PhysicsBody Body2
		{
			get
			{
				return this.self.Body2;
			}
		}

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x06001B2B RID: 6955 RVA: 0x0006DDD1 File Offset: 0x0006BFD1
		public Vector3 Anchor1
		{
			get
			{
				return this.self.Anchor1;
			}
		}

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x06001B2C RID: 6956 RVA: 0x0006DDDE File Offset: 0x0006BFDE
		public Vector3 Anchor2
		{
			get
			{
				return this.self.Anchor2;
			}
		}

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x06001B2D RID: 6957 RVA: 0x0006DDEB File Offset: 0x0006BFEB
		// (set) Token: 0x06001B2E RID: 6958 RVA: 0x0006DDF8 File Offset: 0x0006BFF8
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

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x06001B2F RID: 6959 RVA: 0x0006DE06 File Offset: 0x0006C006
		// (set) Token: 0x06001B30 RID: 6960 RVA: 0x0006DE13 File Offset: 0x0006C013
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

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x06001B31 RID: 6961 RVA: 0x0006DE21 File Offset: 0x0006C021
		public Rotation JointFrame1
		{
			get
			{
				return this.self.JointFrame1;
			}
		}

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x06001B32 RID: 6962 RVA: 0x0006DE2E File Offset: 0x0006C02E
		public Rotation JointFrame2
		{
			get
			{
				return this.self.JointFrame2;
			}
		}

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x06001B33 RID: 6963 RVA: 0x0006DE3B File Offset: 0x0006C03B
		// (set) Token: 0x06001B34 RID: 6964 RVA: 0x0006DE48 File Offset: 0x0006C048
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

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x06001B35 RID: 6965 RVA: 0x0006DE56 File Offset: 0x0006C056
		// (set) Token: 0x06001B36 RID: 6966 RVA: 0x0006DE63 File Offset: 0x0006C063
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

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x06001B37 RID: 6967 RVA: 0x0006DE71 File Offset: 0x0006C071
		// (set) Token: 0x06001B38 RID: 6968 RVA: 0x0006DE7E File Offset: 0x0006C07E
		public float LinearFrequency
		{
			get
			{
				return PhysJoints.Weld_GetLinearFrequency(this.self);
			}
			set
			{
				PhysJoints.Weld_SetLinearFrequency(this.self, value);
			}
		}

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x06001B39 RID: 6969 RVA: 0x0006DE8C File Offset: 0x0006C08C
		// (set) Token: 0x06001B3A RID: 6970 RVA: 0x0006DE99 File Offset: 0x0006C099
		public float LinearDampingRatio
		{
			get
			{
				return PhysJoints.Weld_GetLinearDampingRatio(this.self);
			}
			set
			{
				PhysJoints.Weld_SetLinearDampingRatio(this.self, value);
			}
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x06001B3B RID: 6971 RVA: 0x0006DEA7 File Offset: 0x0006C0A7
		// (set) Token: 0x06001B3C RID: 6972 RVA: 0x0006DEB4 File Offset: 0x0006C0B4
		public float MaxForce
		{
			get
			{
				return PhysJoints.Weld_GetMaxForce(this.self);
			}
			set
			{
				PhysJoints.Weld_SetMaxForce(this.self, value);
			}
		}

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x06001B3D RID: 6973 RVA: 0x0006DEC2 File Offset: 0x0006C0C2
		// (set) Token: 0x06001B3E RID: 6974 RVA: 0x0006DECF File Offset: 0x0006C0CF
		public float AngularFrequency
		{
			get
			{
				return PhysJoints.Weld_GetAngularFrequency(this.self);
			}
			set
			{
				PhysJoints.Weld_SetAngularFrequency(this.self, value);
			}
		}

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x06001B3F RID: 6975 RVA: 0x0006DEDD File Offset: 0x0006C0DD
		// (set) Token: 0x06001B40 RID: 6976 RVA: 0x0006DEEA File Offset: 0x0006C0EA
		public float AngularDampingRatio
		{
			get
			{
				return PhysJoints.Weld_GetAngularDampingRatio(this.self);
			}
			set
			{
				PhysJoints.Weld_SetAngularDampingRatio(this.self, value);
			}
		}

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x06001B41 RID: 6977 RVA: 0x0006DEF8 File Offset: 0x0006C0F8
		// (set) Token: 0x06001B42 RID: 6978 RVA: 0x0006DF05 File Offset: 0x0006C105
		public float MaxTorque
		{
			get
			{
				return PhysJoints.Weld_GetMaxTorque(this.self);
			}
			set
			{
				PhysJoints.Weld_SetMaxTorque(this.self, value);
			}
		}

		// Token: 0x06001B43 RID: 6979 RVA: 0x0006DF13 File Offset: 0x0006C113
		public void Reset()
		{
			PhysJoints.Weld_Reset(this.self);
		}

		// Token: 0x04000770 RID: 1904
		internal PhysicsJoint self;
	}
}
