using System;

namespace OpenVR
{
	// Token: 0x0200000C RID: 12
	internal struct VREvent
	{
		// Token: 0x040000B1 RID: 177
		public VREventType eventType;

		// Token: 0x040000B2 RID: 178
		public uint trackedDeviceIndex;

		// Token: 0x040000B3 RID: 179
		public float eventAgeSeconds;

		// Token: 0x040000B4 RID: 180
		public VREvent_Data data;
	}
}
