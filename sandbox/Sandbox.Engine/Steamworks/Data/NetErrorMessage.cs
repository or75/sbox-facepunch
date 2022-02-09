using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001D7 RID: 471
	internal struct NetErrorMessage
	{
		// Token: 0x04000D60 RID: 3424
		[FixedBuffer(typeof(char), 1024)]
		internal NetErrorMessage.<Value>e__FixedBuffer Value;

		// Token: 0x02000371 RID: 881
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 2048)]
		public struct <Value>e__FixedBuffer
		{
			// Token: 0x0400175F RID: 5983
			public char FixedElementField;
		}
	}
}
