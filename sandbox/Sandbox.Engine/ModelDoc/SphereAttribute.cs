using System;
using System.Collections.Generic;
using Sandbox.Internal;

namespace ModelDoc
{
	/// <summary>
	/// Draws a sphere, which can be manipulated via gizmos. You can have multiple of these.
	/// </summary>
	// Token: 0x020001F3 RID: 499
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class SphereAttribute : BaseTransformAttribute
	{
		// Token: 0x1700026F RID: 623
		// (get) Token: 0x06000CA8 RID: 3240 RVA: 0x00015A52 File Offset: 0x00013C52
		// (set) Token: 0x06000CA9 RID: 3241 RVA: 0x00015A5A File Offset: 0x00013C5A
		internal string Radius { get; set; }

		// Token: 0x17000270 RID: 624
		// (get) Token: 0x06000CAA RID: 3242 RVA: 0x00015A63 File Offset: 0x00013C63
		// (set) Token: 0x06000CAB RID: 3243 RVA: 0x00015A6B File Offset: 0x00013C6B
		internal string Center { get; set; }

		/// <summary>
		/// If set, the semi-transparent sphere "wall"/surface will not be drawn.
		/// </summary>
		// Token: 0x17000271 RID: 625
		// (get) Token: 0x06000CAC RID: 3244 RVA: 0x00015A74 File Offset: 0x00013C74
		// (set) Token: 0x06000CAD RID: 3245 RVA: 0x00015A7C File Offset: 0x00013C7C
		public bool HideSurface { get; set; }

		// Token: 0x06000CAE RID: 3246 RVA: 0x00015A85 File Offset: 0x00013C85
		public SphereAttribute(string radiusKey, string centerKey = "")
			: base("sphere")
		{
			this.Radius = radiusKey;
			this.Center = centerKey;
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x00015AA0 File Offset: 0x00013CA0
		protected override void AddKeys(Dictionary<string, object> dict)
		{
			dict.Add("radius_key", this.Radius);
			dict.Add("center_key", this.Center);
			if (this.HideSurface)
			{
				dict.Add("draw_surface", false);
			}
		}
	}
}
