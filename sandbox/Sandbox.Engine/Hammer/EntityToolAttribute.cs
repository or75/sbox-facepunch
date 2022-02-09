using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Adds this entity to a given category in Hammer's Entity tool sidebar.
	/// </summary>
	// Token: 0x0200020A RID: 522
	[AttributeUsage(AttributeTargets.Class, Inherited = false)]
	public class EntityToolAttribute : MetaDataAttribute
	{
		// Token: 0x06000D1A RID: 3354 RVA: 0x000166F1 File Offset: 0x000148F1
		public EntityToolAttribute(string title, string category, string help = null)
		{
			this.Name = title;
			this.Category = category;
			this.Help = help;
		}

		// Token: 0x06000D1B RID: 3355 RVA: 0x00016710 File Offset: 0x00014910
		public override void AddMetaData(StringBuilder sb)
		{
			if (this.Name != null)
			{
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(20, 1, sb);
				appendInterpolatedStringHandler.AppendLiteral("\tentity_tool_name = ");
				appendInterpolatedStringHandler.AppendFormatted(this.Name.QuoteSafe());
				sb.AppendLine(ref appendInterpolatedStringHandler);
			}
			if (this.Category != null)
			{
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(21, 1, sb);
				appendInterpolatedStringHandler.AppendLiteral("\tentity_tool_group = ");
				appendInterpolatedStringHandler.AppendFormatted(this.Category.QuoteSafe());
				sb.AppendLine(ref appendInterpolatedStringHandler);
			}
			if (this.Help != null)
			{
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(19, 1, sb);
				appendInterpolatedStringHandler.AppendLiteral("\tentity_tool_tip = ");
				appendInterpolatedStringHandler.AppendFormatted(this.Help.QuoteSafe());
				sb.AppendLine(ref appendInterpolatedStringHandler);
			}
		}

		// Token: 0x04000DE3 RID: 3555
		private string Name;

		// Token: 0x04000DE4 RID: 3556
		private string Category;

		// Token: 0x04000DE5 RID: 3557
		private string Help;
	}
}
