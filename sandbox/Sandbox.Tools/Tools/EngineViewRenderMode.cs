using System;
using System.ComponentModel.DataAnnotations;
using Sandbox;

namespace Tools
{
	// Token: 0x0200007E RID: 126
	public enum EngineViewRenderMode
	{
		// Token: 0x0400019E RID: 414
		[Display(Name = "Regular")]
		[Icon("photo")]
		Regular,
		// Token: 0x0400019F RID: 415
		[Display(Name = "Full Bright")]
		[Icon("lightbulb")]
		FullBright,
		// Token: 0x040001A0 RID: 416
		[Display(Name = "Normal Map")]
		[Icon("shuffle")]
		NormalMap = 21,
		// Token: 0x040001A1 RID: 417
		[Display(Name = "Albedo")]
		[Icon("palette")]
		Albedo = 10,
		// Token: 0x040001A2 RID: 418
		[Display(Name = "Diffuse")]
		[Icon("cloud")]
		Diffuse = 2,
		// Token: 0x040001A3 RID: 419
		[Display(Name = "Reflect")]
		[Icon("flare")]
		Reflect,
		// Token: 0x040001A4 RID: 420
		[Display(Name = "Ambient")]
		[Icon("hdr_weak")]
		Ambient = 44
	}
}
