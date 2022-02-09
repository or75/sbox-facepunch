using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Creates a resizable box helper that represents an orhographic projection from the entity's origin in Hammer.
	/// The size of the bounding box as defined by the level designer is put into given keys/properties.
	/// </summary>
	// Token: 0x02000215 RID: 533
	[AttributeUsage(AttributeTargets.Class)]
	public class OrthoBoundsHelperAttribute : MetaDataAttribute
	{
		// Token: 0x06000D37 RID: 3383 RVA: 0x000171D4 File Offset: 0x000153D4
		public OrthoBoundsHelperAttribute(string rangeKey, string widthKey, string heightKey)
		{
			this.rangeKey = rangeKey;
			this.widthKey = widthKey;
			this.heightKey = heightKey;
		}

		// Token: 0x06000D38 RID: 3384 RVA: 0x000171F4 File Offset: 0x000153F4
		public override void AddHeader(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(19, 3, sb);
			appendInterpolatedStringHandler.AppendLiteral("lightortho( ");
			appendInterpolatedStringHandler.AppendFormatted(this.rangeKey.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.widthKey.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.heightKey.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" ) ");
			sb.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04000E05 RID: 3589
		private string rangeKey;

		// Token: 0x04000E06 RID: 3590
		private string widthKey;

		// Token: 0x04000E07 RID: 3591
		private string heightKey;
	}
}
