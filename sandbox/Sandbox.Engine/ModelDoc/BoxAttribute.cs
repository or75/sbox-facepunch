using System;
using System.Collections.Generic;
using Sandbox.Internal;

namespace ModelDoc
{
	/// <summary>
	/// Draws a box, which can be manipulated via gizmos. You can have multiple of these.
	/// </summary>
	// Token: 0x020001F2 RID: 498
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class BoxAttribute : BaseTransformAttribute
	{
		// Token: 0x1700026A RID: 618
		// (get) Token: 0x06000C9B RID: 3227 RVA: 0x0001595A File Offset: 0x00013B5A
		// (set) Token: 0x06000C9C RID: 3228 RVA: 0x00015962 File Offset: 0x00013B62
		internal string Dimensions { get; set; }

		// Token: 0x1700026B RID: 619
		// (get) Token: 0x06000C9D RID: 3229 RVA: 0x0001596B File Offset: 0x00013B6B
		// (set) Token: 0x06000C9E RID: 3230 RVA: 0x00015973 File Offset: 0x00013B73
		internal string Mins { get; set; }

		// Token: 0x1700026C RID: 620
		// (get) Token: 0x06000C9F RID: 3231 RVA: 0x0001597C File Offset: 0x00013B7C
		// (set) Token: 0x06000CA0 RID: 3232 RVA: 0x00015984 File Offset: 0x00013B84
		internal string Maxs { get; set; }

		/// <summary>
		/// If set, the semi-transparent box "walls" will not be drawn.
		/// </summary>
		// Token: 0x1700026D RID: 621
		// (get) Token: 0x06000CA1 RID: 3233 RVA: 0x0001598D File Offset: 0x00013B8D
		// (set) Token: 0x06000CA2 RID: 3234 RVA: 0x00015995 File Offset: 0x00013B95
		public bool HideSurface { get; set; }

		/// <summary>
		/// If set, gizmos will be shown in transform mode to quickly move/scale the box.
		/// For "dimensions" box Origin/Angles must be set.
		/// </summary>
		// Token: 0x1700026E RID: 622
		// (get) Token: 0x06000CA3 RID: 3235 RVA: 0x0001599E File Offset: 0x00013B9E
		// (set) Token: 0x06000CA4 RID: 3236 RVA: 0x000159A6 File Offset: 0x00013BA6
		public bool ShowGizmos { get; set; }

		/// <summary>
		/// Store the box's dimensions in a single key, acting as (maxs-mins) which assumes the box's center is at the models origin.
		/// The box's center can be set up to be movable via "Origin" property and rotatable via "Angles" property.
		/// </summary>
		/// <param name="dimensionsKey">Internal name of a key on the node that will store the dimensions of the box.</param>
		// Token: 0x06000CA5 RID: 3237 RVA: 0x000159AF File Offset: 0x00013BAF
		public BoxAttribute(string dimensionsKey)
			: base("box")
		{
			this.Dimensions = dimensionsKey;
		}

		/// <summary>
		/// Store the box's dimensions in 2 keys as Mins and Maxs. This type cannot be rotated.
		/// </summary>
		/// <param name="minsKey">Internal name of a key on the node that will store the mins of the box.</param>
		/// <param name="maxsKey">Internal name of a key on the node that will store the maxs of the box.</param>
		// Token: 0x06000CA6 RID: 3238 RVA: 0x000159C3 File Offset: 0x00013BC3
		public BoxAttribute(string minsKey, string maxsKey)
			: base("box")
		{
			this.Mins = minsKey;
			this.Maxs = maxsKey;
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x000159E0 File Offset: 0x00013BE0
		protected override void AddKeys(Dictionary<string, object> dict)
		{
			dict.Add("dimensions_key", this.Dimensions);
			dict.Add("min_key", this.Mins);
			dict.Add("max_key", this.Maxs);
			if (this.ShowGizmos)
			{
				dict.Add("transform_gizmo", true);
			}
			if (this.HideSurface)
			{
				dict.Add("draw_surface", false);
			}
		}
	}
}
