using System;
using NativeEngine;

namespace Sandbox.Joints
{
	// Token: 0x02000167 RID: 359
	public struct SpringJoint : IPhysicsJoint
	{
		// Token: 0x06001AEB RID: 6891 RVA: 0x0006D988 File Offset: 0x0006BB88
		public static implicit operator PhysicsJoint(SpringJoint value)
		{
			return value.self;
		}

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x06001AEC RID: 6892 RVA: 0x0006D990 File Offset: 0x0006BB90
		public bool IsValid
		{
			get
			{
				return this.self.IsValid();
			}
		}

		// Token: 0x06001AED RID: 6893 RVA: 0x0006D99D File Offset: 0x0006BB9D
		public void Remove()
		{
			if (this.IsValid)
			{
				this.self.Remove();
				this.self = null;
			}
		}

		// Token: 0x06001AEE RID: 6894 RVA: 0x0006D9B9 File Offset: 0x0006BBB9
		public void OnBreak(PhysicsJoint.BreakDelegate fn)
		{
			if (this.IsValid)
			{
				this.self.OnBreak(fn);
			}
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x06001AEF RID: 6895 RVA: 0x0006D9CF File Offset: 0x0006BBCF
		public bool IsActive
		{
			get
			{
				return this.IsValid && this.self.IsActive;
			}
		}

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06001AF0 RID: 6896 RVA: 0x0006D9E6 File Offset: 0x0006BBE6
		// (set) Token: 0x06001AF1 RID: 6897 RVA: 0x0006D9F3 File Offset: 0x0006BBF3
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

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06001AF2 RID: 6898 RVA: 0x0006DA01 File Offset: 0x0006BC01
		// (set) Token: 0x06001AF3 RID: 6899 RVA: 0x0006DA0E File Offset: 0x0006BC0E
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

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06001AF4 RID: 6900 RVA: 0x0006DA1C File Offset: 0x0006BC1C
		// (set) Token: 0x06001AF5 RID: 6901 RVA: 0x0006DA29 File Offset: 0x0006BC29
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

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x06001AF6 RID: 6902 RVA: 0x0006DA37 File Offset: 0x0006BC37
		public PhysicsBody Body1
		{
			get
			{
				return this.self.Body1;
			}
		}

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x06001AF7 RID: 6903 RVA: 0x0006DA44 File Offset: 0x0006BC44
		public PhysicsBody Body2
		{
			get
			{
				return this.self.Body2;
			}
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x06001AF8 RID: 6904 RVA: 0x0006DA51 File Offset: 0x0006BC51
		public Vector3 Anchor1
		{
			get
			{
				return this.self.Anchor1;
			}
		}

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x06001AF9 RID: 6905 RVA: 0x0006DA5E File Offset: 0x0006BC5E
		public Vector3 Anchor2
		{
			get
			{
				return this.self.Anchor2;
			}
		}

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x06001AFA RID: 6906 RVA: 0x0006DA6B File Offset: 0x0006BC6B
		// (set) Token: 0x06001AFB RID: 6907 RVA: 0x0006DA78 File Offset: 0x0006BC78
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

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x06001AFC RID: 6908 RVA: 0x0006DA86 File Offset: 0x0006BC86
		// (set) Token: 0x06001AFD RID: 6909 RVA: 0x0006DA93 File Offset: 0x0006BC93
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

		// Token: 0x170004D8 RID: 1240
		// (get) Token: 0x06001AFE RID: 6910 RVA: 0x0006DAA1 File Offset: 0x0006BCA1
		public Rotation JointFrame1
		{
			get
			{
				return this.self.JointFrame1;
			}
		}

		// Token: 0x170004D9 RID: 1241
		// (get) Token: 0x06001AFF RID: 6911 RVA: 0x0006DAAE File Offset: 0x0006BCAE
		public Rotation JointFrame2
		{
			get
			{
				return this.self.JointFrame2;
			}
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x06001B00 RID: 6912 RVA: 0x0006DABB File Offset: 0x0006BCBB
		// (set) Token: 0x06001B01 RID: 6913 RVA: 0x0006DAC8 File Offset: 0x0006BCC8
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

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x06001B02 RID: 6914 RVA: 0x0006DAD6 File Offset: 0x0006BCD6
		// (set) Token: 0x06001B03 RID: 6915 RVA: 0x0006DAE3 File Offset: 0x0006BCE3
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

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x06001B04 RID: 6916 RVA: 0x0006DAF1 File Offset: 0x0006BCF1
		// (set) Token: 0x06001B05 RID: 6917 RVA: 0x0006DAFE File Offset: 0x0006BCFE
		public float Frequency
		{
			get
			{
				return PhysJoints.Spring_GetFrequency(this.self);
			}
			set
			{
				PhysJoints.Spring_SetFrequency(this.self, value);
			}
		}

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x06001B06 RID: 6918 RVA: 0x0006DB0C File Offset: 0x0006BD0C
		// (set) Token: 0x06001B07 RID: 6919 RVA: 0x0006DB19 File Offset: 0x0006BD19
		public float DampingRatio
		{
			get
			{
				return PhysJoints.Spring_GetDampingRatio(this.self);
			}
			set
			{
				PhysJoints.Spring_SetDampingRatio(this.self, value);
			}
		}

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x06001B08 RID: 6920 RVA: 0x0006DB27 File Offset: 0x0006BD27
		// (set) Token: 0x06001B09 RID: 6921 RVA: 0x0006DB34 File Offset: 0x0006BD34
		public float ReferenceMass
		{
			get
			{
				return PhysJoints.Spring_GetReferenceMass(this.self);
			}
			set
			{
				PhysJoints.Spring_SetReferenceMass(this.self, value);
			}
		}

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x06001B0A RID: 6922 RVA: 0x0006DB42 File Offset: 0x0006BD42
		// (set) Token: 0x06001B0B RID: 6923 RVA: 0x0006DB4F File Offset: 0x0006BD4F
		public float RestLengthMin
		{
			get
			{
				return PhysJoints.Spring_GetRestLengthMin(this.self);
			}
			set
			{
				PhysJoints.Spring_SetRestLength(this.self, value, this.RestLengthMax);
			}
		}

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06001B0C RID: 6924 RVA: 0x0006DB63 File Offset: 0x0006BD63
		// (set) Token: 0x06001B0D RID: 6925 RVA: 0x0006DB70 File Offset: 0x0006BD70
		public float RestLengthMax
		{
			get
			{
				return PhysJoints.Spring_GetRestLengthMax(this.self);
			}
			set
			{
				PhysJoints.Spring_SetRestLength(this.self, this.RestLengthMin, value);
			}
		}

		// Token: 0x04000768 RID: 1896
		internal PhysicsJoint self;
	}
}
