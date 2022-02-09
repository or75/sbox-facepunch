using System;
using System.Collections.Generic;
using NativeEngine;
using Sandbox.Joints;

namespace Sandbox
{
	// Token: 0x020000D7 RID: 215
	public class PhysicsJoint : IHandle
	{
		/// <summary>
		/// Is this a ConicalJoint
		/// </summary>
		// Token: 0x17000278 RID: 632
		// (get) Token: 0x06001293 RID: 4755 RVA: 0x0004E333 File Offset: 0x0004C533
		public bool IsConicalJoint
		{
			get
			{
				return this.JointType == PhysicsJointType.CONICAL_JOINT;
			}
		}

		/// <summary>
		/// Start creation of Conical joint
		/// </summary>
		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06001294 RID: 4756 RVA: 0x0004E340 File Offset: 0x0004C540
		public static ConicalJointBuilder Conical
		{
			get
			{
				return new ConicalJointBuilder
				{
					common = new PhysicsJointConfig
					{
						localBasis1 = Rotation.Identity,
						localBasis2 = Rotation.Identity
					},
					motorMode = PhysicsJointMotorMode.Disabled
				};
			}
		}

		/// <summary>
		/// Implicit conversion to GenericJoint
		/// </summary>
		// Token: 0x06001295 RID: 4757 RVA: 0x0004E388 File Offset: 0x0004C588
		public static implicit operator ConicalJoint(PhysicsJoint value)
		{
			if (!value.IsConicalJoint)
			{
				throw new Exception("Can't implicitly convert joint to ConicalJoint");
			}
			return new ConicalJoint
			{
				self = value
			};
		}

		/// <summary>
		/// Is this a GenericJoint
		/// </summary>
		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06001296 RID: 4758 RVA: 0x0004E3B9 File Offset: 0x0004C5B9
		public bool IsGenericJoint
		{
			get
			{
				return this.JointType == PhysicsJointType.GENERIC_JOINT;
			}
		}

		/// <summary>
		/// Start creation of Generic joint
		/// </summary>
		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06001297 RID: 4759 RVA: 0x0004E3C8 File Offset: 0x0004C5C8
		public static GenericJointBuilder Generic
		{
			get
			{
				return new GenericJointBuilder
				{
					common = new PhysicsJointConfig
					{
						localBasis1 = Rotation.Identity,
						localBasis2 = Rotation.Identity
					}
				};
			}
		}

		/// <summary>
		/// Implicit conversion to GenericJoint
		/// </summary>
		// Token: 0x06001298 RID: 4760 RVA: 0x0004E408 File Offset: 0x0004C608
		public static implicit operator GenericJoint(PhysicsJoint value)
		{
			if (!value.IsGenericJoint)
			{
				throw new Exception("Can't implicitly convert joint to GenericJoint");
			}
			return new GenericJoint
			{
				self = value
			};
		}

		/// <summary>
		/// Is this a PrismaticJoint
		/// </summary>
		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06001299 RID: 4761 RVA: 0x0004E439 File Offset: 0x0004C639
		public bool IsPrismaticJoint
		{
			get
			{
				return this.JointType == PhysicsJointType.PRISMATIC_JOINT;
			}
		}

		/// <summary>
		/// Start creation of Prismatic joint
		/// </summary>
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x0600129A RID: 4762 RVA: 0x0004E444 File Offset: 0x0004C644
		public static PrismaticJointBuilder Prismatic
		{
			get
			{
				return new PrismaticJointBuilder
				{
					common = new PhysicsJointConfig
					{
						localBasis1 = Rotation.Identity,
						localBasis2 = Rotation.Identity
					},
					motorMode = PhysicsJointMotorMode.Disabled
				};
			}
		}

		/// <summary>
		/// Implicit conversion to PrismaticJoint
		/// </summary>
		// Token: 0x0600129B RID: 4763 RVA: 0x0004E48C File Offset: 0x0004C68C
		public static implicit operator PrismaticJoint(PhysicsJoint value)
		{
			if (!value.IsPrismaticJoint)
			{
				throw new Exception("Can't implicitly convert joint to PrismaticJoint");
			}
			return new PrismaticJoint
			{
				self = value
			};
		}

		/// <summary>
		/// Is this a RevoluteJoint
		/// </summary>
		// Token: 0x1700027E RID: 638
		// (get) Token: 0x0600129C RID: 4764 RVA: 0x0004E4BD File Offset: 0x0004C6BD
		public bool IsRevoluteJoint
		{
			get
			{
				return this.JointType == PhysicsJointType.REVOLUTE_JOINT;
			}
		}

		/// <summary>
		/// Start creation of Revolute joint
		/// </summary>
		// Token: 0x1700027F RID: 639
		// (get) Token: 0x0600129D RID: 4765 RVA: 0x0004E4C8 File Offset: 0x0004C6C8
		public static RevoluteJointBuilder Revolute
		{
			get
			{
				return new RevoluteJointBuilder
				{
					common = new PhysicsJointConfig
					{
						localBasis1 = Rotation.Identity,
						localBasis2 = Rotation.Identity
					},
					motorMode = PhysicsJointMotorMode.Disabled
				};
			}
		}

		/// <summary>
		/// Implicit conversion to RevoluteJoint
		/// </summary>
		// Token: 0x0600129E RID: 4766 RVA: 0x0004E510 File Offset: 0x0004C710
		public static implicit operator RevoluteJoint(PhysicsJoint value)
		{
			if (!value.IsRevoluteJoint)
			{
				throw new Exception("Can't implicitly convert joint to RevoluteJoint");
			}
			return new RevoluteJoint
			{
				self = value
			};
		}

		/// <summary>
		/// Is this a SphericalJoint
		/// </summary>
		// Token: 0x17000280 RID: 640
		// (get) Token: 0x0600129F RID: 4767 RVA: 0x0004E541 File Offset: 0x0004C741
		public bool IsSphericalJoint
		{
			get
			{
				return this.JointType == PhysicsJointType.SPHERICAL_JOINT;
			}
		}

		/// <summary>
		/// Start creation of Spherical joint
		/// </summary>
		// Token: 0x17000281 RID: 641
		// (get) Token: 0x060012A0 RID: 4768 RVA: 0x0004E54C File Offset: 0x0004C74C
		public static SphericalJointBuilder Spherical
		{
			get
			{
				return new SphericalJointBuilder
				{
					common = new PhysicsJointConfig
					{
						localBasis1 = Rotation.Identity,
						localBasis2 = Rotation.Identity
					},
					motorMode = PhysicsJointMotorMode.Disabled
				};
			}
		}

		/// <summary>
		/// Implicit conversion to SphericalJoint
		/// </summary>
		// Token: 0x060012A1 RID: 4769 RVA: 0x0004E594 File Offset: 0x0004C794
		public static implicit operator SphericalJoint(PhysicsJoint value)
		{
			if (!value.IsSphericalJoint)
			{
				throw new Exception("Can't implicitly convert joint to SphericalJoint");
			}
			return new SphericalJoint
			{
				self = value
			};
		}

		/// <summary>
		/// Is this a SpringJoint
		/// </summary>
		// Token: 0x17000282 RID: 642
		// (get) Token: 0x060012A2 RID: 4770 RVA: 0x0004E5C5 File Offset: 0x0004C7C5
		public bool IsSpringJoint
		{
			get
			{
				return this.JointType == PhysicsJointType.SPRING;
			}
		}

		/// <summary>
		/// Start creation of Spring joint
		/// </summary>
		// Token: 0x17000283 RID: 643
		// (get) Token: 0x060012A3 RID: 4771 RVA: 0x0004E5D0 File Offset: 0x0004C7D0
		public static SpringJointBuilder Spring
		{
			get
			{
				return new SpringJointBuilder
				{
					common = new PhysicsJointConfig
					{
						localBasis1 = Rotation.Identity,
						localBasis2 = Rotation.Identity
					},
					m_flFrequency = 5f,
					m_flDampingRatio = 0.7f,
					m_flReferenceMass = 0f,
					m_flMinRestLength = 0f,
					m_flMaxRestLength = 0f
				};
			}
		}

		/// <summary>
		/// Implicit conversion to SpringJoint
		/// </summary>
		// Token: 0x060012A4 RID: 4772 RVA: 0x0004E64C File Offset: 0x0004C84C
		public static implicit operator SpringJoint(PhysicsJoint value)
		{
			if (!value.IsSpringJoint)
			{
				throw new Exception("Can't implicitly convert joint to SpringJoint");
			}
			return new SpringJoint
			{
				self = value
			};
		}

		/// <summary>
		/// Is this a WeldJoint
		/// </summary>
		// Token: 0x17000284 RID: 644
		// (get) Token: 0x060012A5 RID: 4773 RVA: 0x0004E67D File Offset: 0x0004C87D
		public bool IsWeldJoint
		{
			get
			{
				return this.JointType == PhysicsJointType.WELD_JOINT;
			}
		}

		/// <summary>
		/// Start creation of Weld joint
		/// </summary>
		// Token: 0x17000285 RID: 645
		// (get) Token: 0x060012A6 RID: 4774 RVA: 0x0004E688 File Offset: 0x0004C888
		public static WeldJointBuilder Weld
		{
			get
			{
				return new WeldJointBuilder
				{
					common = new PhysicsJointConfig
					{
						localBasis1 = Rotation.Identity,
						localBasis2 = Rotation.Identity
					}
				};
			}
		}

		/// <summary>
		/// Implicit conversion to WeldJoint
		/// </summary>
		// Token: 0x060012A7 RID: 4775 RVA: 0x0004E6C8 File Offset: 0x0004C8C8
		public static implicit operator WeldJoint(PhysicsJoint value)
		{
			if (!value.IsWeldJoint)
			{
				throw new Exception("Can't implicitly convert joint to WeldJoint");
			}
			return new WeldJoint
			{
				self = value
			};
		}

		// Token: 0x060012A8 RID: 4776 RVA: 0x0004E6F9 File Offset: 0x0004C8F9
		void IHandle.HandleInit(IntPtr ptr)
		{
			this.native = ptr;
		}

		// Token: 0x060012A9 RID: 4777 RVA: 0x0004E707 File Offset: 0x0004C907
		void IHandle.HandleDestroy()
		{
			this.native = IntPtr.Zero;
		}

		// Token: 0x060012AA RID: 4778 RVA: 0x0004E719 File Offset: 0x0004C919
		bool IHandle.HandleValid()
		{
			return !this.native.IsNull;
		}

		// Token: 0x060012AB RID: 4779 RVA: 0x0004E729 File Offset: 0x0004C929
		internal PhysicsJoint()
		{
		}

		// Token: 0x060012AC RID: 4780 RVA: 0x0004E73C File Offset: 0x0004C93C
		internal PhysicsJoint(HandleCreationData _)
		{
		}

		// Token: 0x17000286 RID: 646
		// (get) Token: 0x060012AD RID: 4781 RVA: 0x0004E74F File Offset: 0x0004C94F
		internal PhysicsJointType JointType
		{
			get
			{
				return this.native.GetType_Native();
			}
		}

		// Token: 0x060012AE RID: 4782 RVA: 0x0004E75C File Offset: 0x0004C95C
		public void Remove()
		{
			PhysicsWorld.RemoveJoint(this);
		}

		// Token: 0x060012AF RID: 4783 RVA: 0x0004E768 File Offset: 0x0004C968
		internal void OnBreak()
		{
			foreach (PhysicsJoint.BreakDelegate breakDelegate in this.breakDelegates)
			{
				breakDelegate();
			}
		}

		// Token: 0x060012B0 RID: 4784 RVA: 0x0004E7B8 File Offset: 0x0004C9B8
		public void OnBreak(PhysicsJoint.BreakDelegate fn)
		{
			this.breakDelegates.Add(fn);
		}

		// Token: 0x17000287 RID: 647
		// (get) Token: 0x060012B1 RID: 4785 RVA: 0x0004E7C6 File Offset: 0x0004C9C6
		public PhysicsBody Body1
		{
			get
			{
				return this.native.GetBody1();
			}
		}

		// Token: 0x17000288 RID: 648
		// (get) Token: 0x060012B2 RID: 4786 RVA: 0x0004E7D3 File Offset: 0x0004C9D3
		public PhysicsBody Body2
		{
			get
			{
				return this.native.GetBody2();
			}
		}

		// Token: 0x17000289 RID: 649
		// (get) Token: 0x060012B3 RID: 4787 RVA: 0x0004E7E0 File Offset: 0x0004C9E0
		public Vector3 Anchor1
		{
			get
			{
				return this.native.GetAnchor1();
			}
		}

		// Token: 0x1700028A RID: 650
		// (get) Token: 0x060012B4 RID: 4788 RVA: 0x0004E7ED File Offset: 0x0004C9ED
		public Vector3 Anchor2
		{
			get
			{
				return this.native.GetAnchor2();
			}
		}

		// Token: 0x1700028B RID: 651
		// (get) Token: 0x060012B5 RID: 4789 RVA: 0x0004E7FA File Offset: 0x0004C9FA
		// (set) Token: 0x060012B6 RID: 4790 RVA: 0x0004E807 File Offset: 0x0004CA07
		public Vector3 LocalAnchor1
		{
			get
			{
				return this.native.GetLocalAnchor1();
			}
			set
			{
				this.native.SetLocalAnchor1(value);
			}
		}

		// Token: 0x1700028C RID: 652
		// (get) Token: 0x060012B7 RID: 4791 RVA: 0x0004E815 File Offset: 0x0004CA15
		// (set) Token: 0x060012B8 RID: 4792 RVA: 0x0004E822 File Offset: 0x0004CA22
		public Vector3 LocalAnchor2
		{
			get
			{
				return this.native.GetLocalAnchor2();
			}
			set
			{
				this.native.SetLocalAnchor2(value);
			}
		}

		// Token: 0x1700028D RID: 653
		// (get) Token: 0x060012B9 RID: 4793 RVA: 0x0004E830 File Offset: 0x0004CA30
		public Rotation JointFrame1
		{
			get
			{
				return this.native.GetJointFrame1();
			}
		}

		// Token: 0x1700028E RID: 654
		// (get) Token: 0x060012BA RID: 4794 RVA: 0x0004E83D File Offset: 0x0004CA3D
		public Rotation JointFrame2
		{
			get
			{
				return this.native.GetJointFrame2();
			}
		}

		// Token: 0x1700028F RID: 655
		// (get) Token: 0x060012BB RID: 4795 RVA: 0x0004E84A File Offset: 0x0004CA4A
		// (set) Token: 0x060012BC RID: 4796 RVA: 0x0004E857 File Offset: 0x0004CA57
		public Rotation LocalJointFrame1
		{
			get
			{
				return this.native.GetLocalJointFrame1();
			}
			set
			{
				this.native.SetLocalJointFrame1(value);
			}
		}

		// Token: 0x17000290 RID: 656
		// (get) Token: 0x060012BD RID: 4797 RVA: 0x0004E865 File Offset: 0x0004CA65
		// (set) Token: 0x060012BE RID: 4798 RVA: 0x0004E872 File Offset: 0x0004CA72
		public Rotation LocalJointFrame2
		{
			get
			{
				return this.native.GetLocalJointFrame2();
			}
			set
			{
				this.native.SetLocalJointFrame2(value);
			}
		}

		// Token: 0x17000291 RID: 657
		// (get) Token: 0x060012BF RID: 4799 RVA: 0x0004E880 File Offset: 0x0004CA80
		public bool IsActive
		{
			get
			{
				return this.native.IsActive();
			}
		}

		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060012C0 RID: 4800 RVA: 0x0004E88D File Offset: 0x0004CA8D
		// (set) Token: 0x060012C1 RID: 4801 RVA: 0x0004E89A File Offset: 0x0004CA9A
		public bool EnableCollision
		{
			get
			{
				return this.native.IsCollisionEnabled();
			}
			set
			{
				if (value)
				{
					this.native.EnableCollision();
					return;
				}
				this.native.DisableCollision();
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x060012C2 RID: 4802 RVA: 0x0004E8B6 File Offset: 0x0004CAB6
		// (set) Token: 0x060012C3 RID: 4803 RVA: 0x0004E8C3 File Offset: 0x0004CAC3
		public bool EnableLinearConstraint
		{
			get
			{
				return this.native.IsLinearConstraintEnabled();
			}
			set
			{
				if (value)
				{
					this.native.EnableLinearConstraint();
					return;
				}
				this.native.DisableLinearConstraint();
			}
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x060012C4 RID: 4804 RVA: 0x0004E8DF File Offset: 0x0004CADF
		// (set) Token: 0x060012C5 RID: 4805 RVA: 0x0004E8EC File Offset: 0x0004CAEC
		public bool EnableAngularConstraint
		{
			get
			{
				return this.native.IsAngularConstraintEnabled();
			}
			set
			{
				if (value)
				{
					this.native.EnableAngularConstraint();
					return;
				}
				this.native.DisableAngularConstraint();
			}
		}

		// Token: 0x04000443 RID: 1091
		internal IPhysicsJoint native;

		// Token: 0x04000444 RID: 1092
		internal List<PhysicsJoint.BreakDelegate> breakDelegates = new List<PhysicsJoint.BreakDelegate>();

		// Token: 0x0200024D RID: 589
		// (Invoke) Token: 0x06001E11 RID: 7697
		public delegate void BreakDelegate();
	}
}
