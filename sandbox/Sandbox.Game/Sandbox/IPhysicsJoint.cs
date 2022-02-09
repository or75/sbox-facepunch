using System;

namespace Sandbox
{
	// Token: 0x020000D8 RID: 216
	public interface IPhysicsJoint
	{
		// Token: 0x060012C6 RID: 4806
		void Remove();

		// Token: 0x060012C7 RID: 4807
		void OnBreak(PhysicsJoint.BreakDelegate fn);

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x060012C8 RID: 4808
		bool IsValid { get; }

		// Token: 0x17000296 RID: 662
		// (get) Token: 0x060012C9 RID: 4809
		bool IsActive { get; }

		// Token: 0x17000297 RID: 663
		// (get) Token: 0x060012CA RID: 4810
		// (set) Token: 0x060012CB RID: 4811
		bool EnableCollision { get; set; }

		// Token: 0x17000298 RID: 664
		// (get) Token: 0x060012CC RID: 4812
		// (set) Token: 0x060012CD RID: 4813
		bool EnableLinearConstraint { get; set; }

		// Token: 0x17000299 RID: 665
		// (get) Token: 0x060012CE RID: 4814
		// (set) Token: 0x060012CF RID: 4815
		bool EnableAngularConstraint { get; set; }

		// Token: 0x1700029A RID: 666
		// (get) Token: 0x060012D0 RID: 4816
		PhysicsBody Body1 { get; }

		// Token: 0x1700029B RID: 667
		// (get) Token: 0x060012D1 RID: 4817
		PhysicsBody Body2 { get; }

		// Token: 0x1700029C RID: 668
		// (get) Token: 0x060012D2 RID: 4818
		Vector3 Anchor1 { get; }

		// Token: 0x1700029D RID: 669
		// (get) Token: 0x060012D3 RID: 4819
		Vector3 Anchor2 { get; }

		// Token: 0x1700029E RID: 670
		// (get) Token: 0x060012D4 RID: 4820
		// (set) Token: 0x060012D5 RID: 4821
		Vector3 LocalAnchor1 { get; set; }

		// Token: 0x1700029F RID: 671
		// (get) Token: 0x060012D6 RID: 4822
		// (set) Token: 0x060012D7 RID: 4823
		Vector3 LocalAnchor2 { get; set; }

		// Token: 0x170002A0 RID: 672
		// (get) Token: 0x060012D8 RID: 4824
		Rotation JointFrame1 { get; }

		// Token: 0x170002A1 RID: 673
		// (get) Token: 0x060012D9 RID: 4825
		Rotation JointFrame2 { get; }

		// Token: 0x170002A2 RID: 674
		// (get) Token: 0x060012DA RID: 4826
		// (set) Token: 0x060012DB RID: 4827
		Rotation LocalJointFrame1 { get; set; }

		// Token: 0x170002A3 RID: 675
		// (get) Token: 0x060012DC RID: 4828
		// (set) Token: 0x060012DD RID: 4829
		Rotation LocalJointFrame2 { get; set; }
	}
}
