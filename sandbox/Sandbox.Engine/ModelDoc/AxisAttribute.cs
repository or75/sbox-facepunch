using System;
using System.Collections.Generic;
using Sandbox.Internal;

namespace ModelDoc
{
	/// <summary>
	/// Draws 3 line axis visualization, which can set up to be manipulated via gizmos. You can have multiple of these.
	/// </summary>
	// Token: 0x020001F1 RID: 497
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class AxisAttribute : BaseTransformAttribute
	{
		/// <summary>
		/// Internal name of a boolean key that dictates whether this helper should draw or not. If unset, will draw always.
		/// </summary>
		// Token: 0x17000268 RID: 616
		// (get) Token: 0x06000C95 RID: 3221 RVA: 0x000158FF File Offset: 0x00013AFF
		// (set) Token: 0x06000C96 RID: 3222 RVA: 0x00015907 File Offset: 0x00013B07
		public string Enabled { get; set; }

		/// <summary>
		/// If set to true, when the node is selected a line will be drawn from the helper to the parent attachment/bone.
		/// </summary>
		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06000C97 RID: 3223 RVA: 0x00015910 File Offset: 0x00013B10
		// (set) Token: 0x06000C98 RID: 3224 RVA: 0x00015918 File Offset: 0x00013B18
		public bool ParentLine { get; set; }

		// Token: 0x06000C99 RID: 3225 RVA: 0x00015921 File Offset: 0x00013B21
		public AxisAttribute()
			: base("locator_axis")
		{
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x0001592E File Offset: 0x00013B2E
		protected override void AddKeys(Dictionary<string, object> dict)
		{
			dict.Add("enabled_key", this.Enabled);
			if (this.ParentLine)
			{
				dict.Add("draw_parent", true);
			}
		}
	}
}
