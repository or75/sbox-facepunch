using System;

namespace Sandbox
{
	/// <summary>
	/// An input action that can come from a mouse, keyboard or controller.
	/// </summary>
	// Token: 0x020000B2 RID: 178
	[Flags]
	public enum InputButton : ulong
	{
		// Token: 0x04000344 RID: 836
		Forward = 1UL,
		// Token: 0x04000345 RID: 837
		Back = 2UL,
		// Token: 0x04000346 RID: 838
		Left = 4UL,
		// Token: 0x04000347 RID: 839
		Right = 8UL,
		// Token: 0x04000348 RID: 840
		Jump = 16UL,
		// Token: 0x04000349 RID: 841
		Duck = 32UL,
		// Token: 0x0400034A RID: 842
		Run = 64UL,
		// Token: 0x0400034B RID: 843
		Walk = 128UL,
		// Token: 0x0400034C RID: 844
		Attack1 = 256UL,
		// Token: 0x0400034D RID: 845
		Attack2 = 512UL,
		// Token: 0x0400034E RID: 846
		Reload = 1024UL,
		// Token: 0x0400034F RID: 847
		Grenade = 2048UL,
		// Token: 0x04000350 RID: 848
		Drop = 4096UL,
		// Token: 0x04000351 RID: 849
		Use = 8192UL,
		// Token: 0x04000352 RID: 850
		Flashlight = 16384UL,
		// Token: 0x04000353 RID: 851
		View = 32768UL,
		// Token: 0x04000354 RID: 852
		Zoom = 65536UL,
		// Token: 0x04000355 RID: 853
		Menu = 131072UL,
		// Token: 0x04000356 RID: 854
		Score = 262144UL,
		// Token: 0x04000357 RID: 855
		Chat = 524288UL,
		// Token: 0x04000358 RID: 856
		Voice = 1048576UL,
		// Token: 0x04000359 RID: 857
		SlotNext = 2097152UL,
		// Token: 0x0400035A RID: 858
		SlotPrev = 4194304UL,
		// Token: 0x0400035B RID: 859
		Slot1 = 8388608UL,
		// Token: 0x0400035C RID: 860
		Slot2 = 16777216UL,
		// Token: 0x0400035D RID: 861
		Slot3 = 33554432UL,
		// Token: 0x0400035E RID: 862
		Slot4 = 67108864UL,
		// Token: 0x0400035F RID: 863
		Slot5 = 134217728UL,
		// Token: 0x04000360 RID: 864
		Slot6 = 268435456UL,
		// Token: 0x04000361 RID: 865
		Slot7 = 536870912UL,
		// Token: 0x04000362 RID: 866
		Slot8 = 1073741824UL,
		// Token: 0x04000363 RID: 867
		Slot9 = 2147483648UL,
		// Token: 0x04000364 RID: 868
		Slot0 = 4294967296UL,
		// Token: 0x04000365 RID: 869
		[Obsolete("Renamed to InputButton.SlotNext for clarity")]
		Next = 0UL,
		// Token: 0x04000366 RID: 870
		[Obsolete("Renamed to InputButton.SlotPrev for clarity")]
		Prev = 0UL,
		// Token: 0x04000367 RID: 871
		[Obsolete("This InputButton was never used and will be removed soon.")]
		Cancel = 0UL,
		// Token: 0x04000368 RID: 872
		[Obsolete("This InputButton was never used and will be removed soon.")]
		Alt1 = 0UL,
		// Token: 0x04000369 RID: 873
		[Obsolete("This InputButton was never used and will be removed soon.")]
		Alt2 = 0UL,
		// Token: 0x0400036A RID: 874
		[Obsolete("This InputButton was never used and will be removed soon.")]
		Weapon1 = 0UL,
		// Token: 0x0400036B RID: 875
		[Obsolete("This InputButton was never used and will be removed soon.")]
		Weapon2 = 0UL,
		// Token: 0x0400036C RID: 876
		[Obsolete("This InputButton was never used and will be removed soon.")]
		LookSpin = 0UL,
		// Token: 0x0400036D RID: 877
		[Obsolete("This InputButton was never used and will be removed soon.")]
		Grenade1 = 0UL,
		// Token: 0x0400036E RID: 878
		[Obsolete("This InputButton was never used and will be removed soon.")]
		Grenade2 = 0UL
	}
}
