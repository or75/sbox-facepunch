using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NativeEngine
{
	// Token: 0x0200027A RID: 634
	internal struct VrSkeletalSummaryData_t
	{
		// Token: 0x040011E6 RID: 4582
		[FixedBuffer(typeof(float), 5)]
		public VrSkeletalSummaryData_t.<m_flFingerCurl>e__FixedBuffer m_flFingerCurl;

		// Token: 0x040011E7 RID: 4583
		[FixedBuffer(typeof(float), 4)]
		public VrSkeletalSummaryData_t.<m_flFingerSplay>e__FixedBuffer m_flFingerSplay;

		// Token: 0x020003B3 RID: 947
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 20)]
		public struct <m_flFingerCurl>e__FixedBuffer
		{
			// Token: 0x040018D9 RID: 6361
			public float FixedElementField;
		}

		// Token: 0x020003B4 RID: 948
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 16)]
		public struct <m_flFingerSplay>e__FixedBuffer
		{
			// Token: 0x040018DA RID: 6362
			public float FixedElementField;
		}
	}
}
