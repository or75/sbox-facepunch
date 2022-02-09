using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace NativeEngine
{
	// Token: 0x02000263 RID: 611
	internal struct RenderTargetDesc
	{
		// Token: 0x170002C4 RID: 708
		// (get) Token: 0x06000F44 RID: 3908 RVA: 0x0001B382 File Offset: 0x00019582
		// (set) Token: 0x06000F45 RID: 3909 RVA: 0x0001B38A File Offset: 0x0001958A
		private long m_hDepthTarget { readonly get; set; }

		// Token: 0x170002C5 RID: 709
		// (get) Token: 0x06000F46 RID: 3910 RVA: 0x0001B393 File Offset: 0x00019593
		// (set) Token: 0x06000F47 RID: 3911 RVA: 0x0001B39B File Offset: 0x0001959B
		private int m_nDepthTargetIndex { readonly get; set; }

		// Token: 0x170002C6 RID: 710
		// (get) Token: 0x06000F48 RID: 3912 RVA: 0x0001B3A4 File Offset: 0x000195A4
		// (set) Token: 0x06000F49 RID: 3913 RVA: 0x0001B3AC File Offset: 0x000195AC
		private short m_nColorTargetCount { readonly get; set; }

		// Token: 0x170002C7 RID: 711
		// (get) Token: 0x06000F4A RID: 3914 RVA: 0x0001B3B5 File Offset: 0x000195B5
		// (set) Token: 0x06000F4B RID: 3915 RVA: 0x0001B3BD File Offset: 0x000195BD
		private RenderColorSpace m_allowSrgbWrite { readonly get; set; }

		// Token: 0x170002C8 RID: 712
		// (get) Token: 0x06000F4C RID: 3916 RVA: 0x0001B3C6 File Offset: 0x000195C6
		// (set) Token: 0x06000F4D RID: 3917 RVA: 0x0001B3CE File Offset: 0x000195CE
		private bool m_bReadOnlyDepthStencil { readonly get; set; }

		// Token: 0x040010FC RID: 4348
		[FixedBuffer(typeof(long), 8)]
		private RenderTargetDesc.<m_pColorTargets>e__FixedBuffer m_pColorTargets;

		// Token: 0x040010FE RID: 4350
		[FixedBuffer(typeof(int), 8)]
		private RenderTargetDesc.<m_nColorTargetIndices>e__FixedBuffer m_nColorTargetIndices;

		// Token: 0x020003AD RID: 941
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 32)]
		public struct <m_nColorTargetIndices>e__FixedBuffer
		{
			// Token: 0x040018D3 RID: 6355
			public int FixedElementField;
		}

		// Token: 0x020003AE RID: 942
		[CompilerGenerated]
		[UnsafeValueType]
		[StructLayout(LayoutKind.Sequential, Size = 64)]
		public struct <m_pColorTargets>e__FixedBuffer
		{
			// Token: 0x040018D4 RID: 6356
			public long FixedElementField;
		}
	}
}
