using System;

namespace Sandbox
{
	// Token: 0x020000A9 RID: 169
	[Flags]
	public enum DamageFlags
	{
		// Token: 0x040002F9 RID: 761
		Generic = 0,
		// Token: 0x040002FA RID: 762
		Crush = 1,
		// Token: 0x040002FB RID: 763
		Bullet = 2,
		// Token: 0x040002FC RID: 764
		Slash = 4,
		// Token: 0x040002FD RID: 765
		Burn = 8,
		// Token: 0x040002FE RID: 766
		Vehicle = 16,
		// Token: 0x040002FF RID: 767
		Fall = 32,
		// Token: 0x04000300 RID: 768
		Blast = 64,
		// Token: 0x04000301 RID: 769
		Blunt = 128,
		// Token: 0x04000302 RID: 770
		Shock = 256,
		// Token: 0x04000303 RID: 771
		Sonic = 512,
		// Token: 0x04000304 RID: 772
		Beam = 1024,
		// Token: 0x04000305 RID: 773
		PhysicsImpact = 2048,
		// Token: 0x04000306 RID: 774
		DoNotGib = 4096,
		// Token: 0x04000307 RID: 775
		AlwaysGib = 8192,
		// Token: 0x04000308 RID: 776
		Drown = 16384,
		// Token: 0x04000309 RID: 777
		Paralyze = 32768,
		// Token: 0x0400030A RID: 778
		NerveGas = 65536,
		// Token: 0x0400030B RID: 779
		Poison = 131072,
		// Token: 0x0400030C RID: 780
		Radiation = 262144,
		// Token: 0x0400030D RID: 781
		DrownRecover = 524288,
		// Token: 0x0400030E RID: 782
		Acid = 1048576,
		// Token: 0x0400030F RID: 783
		Cook = 2097152,
		// Token: 0x04000310 RID: 784
		NoRadgoll = 4194304,
		// Token: 0x04000311 RID: 785
		Physgun = 8388608,
		// Token: 0x04000312 RID: 786
		Plasma = 16777216,
		// Token: 0x04000313 RID: 787
		Dissolve = 67108864,
		// Token: 0x04000314 RID: 788
		BlastWaterSurface = 134217728,
		// Token: 0x04000315 RID: 789
		Direct = 268435456,
		// Token: 0x04000316 RID: 790
		Buckshot = 536870912
	}
}
