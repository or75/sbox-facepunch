using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Draws a frustum that doesn't contribute to bounds calculations.
	/// </summary>
	// Token: 0x0200020F RID: 527
	[AttributeUsage(AttributeTargets.Class)]
	public class FrustumBoundlessAttribute : MetaDataAttribute
	{
		// Token: 0x06000D25 RID: 3365 RVA: 0x000169E9 File Offset: 0x00014BE9
		public FrustumBoundlessAttribute(string fovKV, string zNearKV, string zFarKV)
		{
			this.fovKV = fovKV;
			this.zNearKV = zNearKV;
			this.zFarKV = zFarKV;
		}

		// Token: 0x06000D26 RID: 3366 RVA: 0x00016A08 File Offset: 0x00014C08
		public override void AddHeader(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(26, 3, sb);
			appendInterpolatedStringHandler.AppendLiteral("frustum_boundless( ");
			appendInterpolatedStringHandler.AppendFormatted(this.fovKV.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.zNearKV.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.zFarKV.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" ) ");
			sb.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04000DEE RID: 3566
		private string fovKV;

		// Token: 0x04000DEF RID: 3567
		private string zNearKV;

		// Token: 0x04000DF0 RID: 3568
		private string zFarKV;
	}
}
