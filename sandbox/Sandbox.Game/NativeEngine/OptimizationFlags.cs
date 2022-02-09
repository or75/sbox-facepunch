using System;

namespace NativeEngine
{
	// Token: 0x0200005B RID: 91
	[Flags]
	internal enum OptimizationFlags
	{
		// Token: 0x040000C8 RID: 200
		HasAttenuation0 = 1,
		// Token: 0x040000C9 RID: 201
		HasAttenuation1 = 2,
		// Token: 0x040000CA RID: 202
		HasAttenuation2 = 4,
		// Token: 0x040000CB RID: 203
		DerivedValuesCalced = 8,
		// Token: 0x040000CC RID: 204
		MixedShadows = 16,
		// Token: 0x040000CD RID: 205
		Baked = 32,
		// Token: 0x040000CE RID: 206
		HammerBaked = 128
	}
}
