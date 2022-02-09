using System;
using System.Collections.Generic;
using Sandbox.Internal;

namespace ModelDoc
{
	/// <summary>
	/// A helper used for VR hand purposes.
	/// </summary>
	// Token: 0x020001F8 RID: 504
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	public class HandPoseAttribute : BaseModelDocAttribute
	{
		/// <summary>
		/// Internal name of the key to store position in.
		/// </summary>
		// Token: 0x17000279 RID: 633
		// (get) Token: 0x06000CC7 RID: 3271 RVA: 0x00015CF1 File Offset: 0x00013EF1
		// (set) Token: 0x06000CC8 RID: 3272 RVA: 0x00015CF9 File Offset: 0x00013EF9
		internal string Origin { get; set; }

		/// <summary>
		/// Internal name of the key to store angles in.
		/// </summary>
		// Token: 0x1700027A RID: 634
		// (get) Token: 0x06000CC9 RID: 3273 RVA: 0x00015D02 File Offset: 0x00013F02
		// (set) Token: 0x06000CCA RID: 3274 RVA: 0x00015D0A File Offset: 0x00013F0A
		internal string Angles { get; set; }

		/// <summary>
		/// Path to a model to use.
		/// </summary>
		// Token: 0x1700027B RID: 635
		// (get) Token: 0x06000CCB RID: 3275 RVA: 0x00015D13 File Offset: 0x00013F13
		// (set) Token: 0x06000CCC RID: 3276 RVA: 0x00015D1B File Offset: 0x00013F1B
		internal string Model { get; set; }

		/// <summary>
		/// Whether this helper represenets the right hand or not.
		/// This decides the names of the bones the helper will try to use.
		/// </summary>
		// Token: 0x1700027C RID: 636
		// (get) Token: 0x06000CCD RID: 3277 RVA: 0x00015D24 File Offset: 0x00013F24
		// (set) Token: 0x06000CCE RID: 3278 RVA: 0x00015D2C File Offset: 0x00013F2C
		internal bool IsRightHand { get; set; }

		/// <summary>
		/// Text label this helper will have when hovered/selected.
		/// </summary>
		// Token: 0x1700027D RID: 637
		// (get) Token: 0x06000CCF RID: 3279 RVA: 0x00015D35 File Offset: 0x00013F35
		// (set) Token: 0x06000CD0 RID: 3280 RVA: 0x00015D3D File Offset: 0x00013F3D
		public string Label { get; set; }

		/// <summary>
		/// Internal name of the key that controls whether this helper is visible or not.
		/// </summary>
		// Token: 0x1700027E RID: 638
		// (get) Token: 0x06000CD1 RID: 3281 RVA: 0x00015D46 File Offset: 0x00013F46
		// (set) Token: 0x06000CD2 RID: 3282 RVA: 0x00015D4E File Offset: 0x00013F4E
		public string Enabled { get; set; }

		/// <param name="originKey">Internal name of the key to store position in.</param>
		/// <param name="anglesKey">Internal name of the key to store angles in.</param>
		/// <param name="model">Path to a model to use.</param>
		/// <param name="isRightHand">Whether this helper represenets the right hand or not. This decides the names of the bones the helper will try to use.</param>
		// Token: 0x06000CD3 RID: 3283 RVA: 0x00015D57 File Offset: 0x00013F57
		public HandPoseAttribute(string originKey, string anglesKey, string model, bool isRightHand)
			: base("hand_pose")
		{
			this.Origin = originKey;
			this.Angles = anglesKey;
			this.Model = model;
			this.IsRightHand = isRightHand;
		}

		// Token: 0x06000CD4 RID: 3284 RVA: 0x00015D84 File Offset: 0x00013F84
		protected override void AddKeys(Dictionary<string, object> dict)
		{
			dict.Add("enabled_key", this.Enabled);
			dict.Add("origin_key", this.Origin);
			dict.Add("angles_key", this.Angles);
			dict.Add("label", this.Label);
			dict.Add("model", this.Model);
			if (this.IsRightHand)
			{
				dict.Add("is_right_hand", true);
			}
		}
	}
}
