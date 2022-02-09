using System;
using System.Collections.Generic;
using System.Text;
using Sandbox;
using Sandbox.Internal;

namespace ModelDoc
{
	// Token: 0x020001F9 RID: 505
	public class LineAttribute : BaseModelDocAttribute
	{
		/// <summary>
		/// Internal name of the key that dictates which bone to use as parent for start position.
		/// </summary>
		// Token: 0x1700027F RID: 639
		// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x00015DFF File Offset: 0x00013FFF
		// (set) Token: 0x06000CD6 RID: 3286 RVA: 0x00015E07 File Offset: 0x00014007
		public string BoneFrom { get; set; }

		/// <summary>
		/// Internal name of the key that dictates which attachment to use as parent for start position.
		/// </summary>
		// Token: 0x17000280 RID: 640
		// (get) Token: 0x06000CD7 RID: 3287 RVA: 0x00015E10 File Offset: 0x00014010
		// (set) Token: 0x06000CD8 RID: 3288 RVA: 0x00015E18 File Offset: 0x00014018
		public string AttachmentFrom { get; set; }

		/// <summary>
		/// Internal name of the key to read line start position from.
		/// </summary>
		// Token: 0x17000281 RID: 641
		// (get) Token: 0x06000CD9 RID: 3289 RVA: 0x00015E21 File Offset: 0x00014021
		// (set) Token: 0x06000CDA RID: 3290 RVA: 0x00015E29 File Offset: 0x00014029
		public string OriginFrom { get; set; }

		/// <summary>
		/// Internal name of the key that dictates which bone to use as parent for end position.
		/// </summary>
		// Token: 0x17000282 RID: 642
		// (get) Token: 0x06000CDB RID: 3291 RVA: 0x00015E32 File Offset: 0x00014032
		// (set) Token: 0x06000CDC RID: 3292 RVA: 0x00015E3A File Offset: 0x0001403A
		public string BoneTo { get; set; }

		/// <summary>
		/// Internal name of the key that dictates which attachment to use as parent for end position.
		/// </summary>
		// Token: 0x17000283 RID: 643
		// (get) Token: 0x06000CDD RID: 3293 RVA: 0x00015E43 File Offset: 0x00014043
		// (set) Token: 0x06000CDE RID: 3294 RVA: 0x00015E4B File Offset: 0x0001404B
		public string AttachmentTo { get; set; }

		/// <summary>
		/// Internal name of the key to read line end position from.
		/// </summary>
		// Token: 0x17000284 RID: 644
		// (get) Token: 0x06000CDF RID: 3295 RVA: 0x00015E54 File Offset: 0x00014054
		// (set) Token: 0x06000CE0 RID: 3296 RVA: 0x00015E5C File Offset: 0x0001405C
		public string OriginTo { get; set; }

		/// <summary>
		/// Internal name of the key that controls whether this helper is visible or not.
		/// </summary>
		// Token: 0x17000285 RID: 645
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x00015E65 File Offset: 0x00014065
		// (set) Token: 0x06000CE2 RID: 3298 RVA: 0x00015E6D File Offset: 0x0001406D
		public string Enabled { get; set; }

		/// <summary>
		/// A string formatted color for this helper. Format is "255 255 255"
		/// </summary>
		// Token: 0x17000286 RID: 646
		// (get) Token: 0x06000CE3 RID: 3299 RVA: 0x00015E76 File Offset: 0x00014076
		// (set) Token: 0x06000CE4 RID: 3300 RVA: 0x00015E7E File Offset: 0x0001407E
		public string Color { get; set; }

		/// <summary>
		/// The width of the line helper
		/// </summary>
		// Token: 0x17000287 RID: 647
		// (get) Token: 0x06000CE5 RID: 3301 RVA: 0x00015E87 File Offset: 0x00014087
		// (set) Token: 0x06000CE6 RID: 3302 RVA: 0x00015E8F File Offset: 0x0001408F
		public float Width { get; set; }

		// Token: 0x06000CE7 RID: 3303 RVA: 0x00015E98 File Offset: 0x00014098
		public LineAttribute()
			: base("line")
		{
		}

		// Token: 0x06000CE8 RID: 3304 RVA: 0x00015EA8 File Offset: 0x000140A8
		protected override void AddTransform(StringBuilder sb)
		{
			string transformFromKeys = "";
			if (!string.IsNullOrEmpty(this.OriginFrom))
			{
				transformFromKeys = transformFromKeys + "\t\torigin_key = " + this.OriginFrom.QuoteSafe() + "\r\n";
			}
			if (!string.IsNullOrEmpty(this.AttachmentFrom))
			{
				transformFromKeys = transformFromKeys + "\t\tattachment_key = " + this.AttachmentFrom.QuoteSafe() + "\r\n";
			}
			if (!string.IsNullOrEmpty(this.BoneFrom))
			{
				transformFromKeys = transformFromKeys + "\t\tbone_key = " + this.BoneFrom.QuoteSafe() + "\r\n";
			}
			if (!string.IsNullOrEmpty(transformFromKeys))
			{
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, sb);
				appendInterpolatedStringHandler.AppendLiteral("\tfrom =\r\n\t{\r\n");
				appendInterpolatedStringHandler.AppendFormatted(transformFromKeys);
				appendInterpolatedStringHandler.AppendLiteral("\t}");
				sb.AppendLine(ref appendInterpolatedStringHandler);
			}
			string transformToKeys = "";
			if (!string.IsNullOrEmpty(this.OriginTo))
			{
				transformToKeys = transformToKeys + "\t\torigin_key = " + this.OriginTo.QuoteSafe() + "\r\n";
			}
			if (!string.IsNullOrEmpty(this.AttachmentTo))
			{
				transformToKeys = transformToKeys + "\t\tattachment_key = " + this.AttachmentTo.QuoteSafe() + "\r\n";
			}
			if (!string.IsNullOrEmpty(this.BoneTo))
			{
				transformToKeys = transformToKeys + "\t\tbone_key = " + this.BoneTo.QuoteSafe() + "\r\n";
			}
			if (!string.IsNullOrEmpty(transformToKeys))
			{
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, sb);
				appendInterpolatedStringHandler.AppendLiteral("\tto =\r\n\t{\r\n");
				appendInterpolatedStringHandler.AppendFormatted(transformToKeys);
				appendInterpolatedStringHandler.AppendLiteral("\t}");
				sb.AppendLine(ref appendInterpolatedStringHandler);
			}
		}

		// Token: 0x06000CE9 RID: 3305 RVA: 0x00016034 File Offset: 0x00014234
		protected override void AddKeys(Dictionary<string, object> dict)
		{
			dict.Add("enabled_key", this.Enabled);
			dict.Add("color", this.Color);
			if (this.Width > 0f)
			{
				dict.Add("width", this.Width);
			}
		}
	}
}
