using System;

namespace Sandbox
{
	// Token: 0x02000299 RID: 665
	public enum BlendMode
	{
		/// <summary>
		/// dest.rgb = src.rgb
		/// </summary>
		// Token: 0x040012A7 RID: 4775
		Rgb,
		/// <summary>
		/// no write to dest
		/// </summary>
		// Token: 0x040012A8 RID: 4776
		NoWrite,
		/// <summary>
		/// dest.rgba = src.rgba
		/// </summary>
		// Token: 0x040012A9 RID: 4777
		Rgba,
		/// <summary>
		/// dest.rgb = lerp( dest.rgb, src.srb, src.a )
		/// </summary>
		// Token: 0x040012AA RID: 4778
		AlphaBlend,
		/// <summary>
		/// dest.rgb = src.rgb * src.a + dest.rgb
		/// </summary>
		// Token: 0x040012AB RID: 4779
		Additive,
		/// <summary>
		/// dest.rgb += src.rgb
		/// </summary>
		// Token: 0x040012AC RID: 4780
		AdditiveIgnoreAlpha,
		/// <summary>
		/// dest.rgba *= src.rgba
		/// </summary>
		// Token: 0x040012AD RID: 4781
		Multiply
	}
}
