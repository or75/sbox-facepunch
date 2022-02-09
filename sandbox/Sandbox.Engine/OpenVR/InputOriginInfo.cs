using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace OpenVR
{
	// Token: 0x02000016 RID: 22
	internal struct InputOriginInfo
	{
		// Token: 0x04000114 RID: 276
		public ulong devicePath;

		// Token: 0x04000115 RID: 277
		public uint trackedDeviceIndex;

		// Token: 0x04000116 RID: 278
		[FixedBuffer(typeof(byte), 128)]
		public InputOriginInfo.<rchRenderModelComponentName>e__FixedBuffer rchRenderModelComponentName;

		// Token: 0x02000311 RID: 785
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 128)]
		public struct <rchRenderModelComponentName>e__FixedBuffer
		{
			// Token: 0x040015AE RID: 5550
			public byte FixedElementField;
		}
	}
}
