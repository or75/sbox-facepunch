using System;
using System.Runtime.InteropServices;

namespace OpenVR
{
	// Token: 0x0200000D RID: 13
	[StructLayout(LayoutKind.Explicit)]
	internal struct VREvent_Data
	{
		// Token: 0x040000B5 RID: 181
		[FieldOffset(0)]
		public VREvent_Reserved reserved;

		// Token: 0x040000B6 RID: 182
		[FieldOffset(0)]
		public VREvent_Mouse mouse;

		// Token: 0x040000B7 RID: 183
		[FieldOffset(0)]
		public VREvent_Scroll scroll;
	}
}
