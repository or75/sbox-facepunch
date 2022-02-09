using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Draws the door movement and the final open position in Hammer.
	/// </summary>
	// Token: 0x0200020C RID: 524
	[AttributeUsage(AttributeTargets.Class)]
	public class DoorHelperAttribute : MetaDataAttribute
	{
		// Token: 0x06000D1F RID: 3359 RVA: 0x000168C3 File Offset: 0x00014AC3
		public DoorHelperAttribute(string angleKV, string isLocalKV, string angleTypeKV, string distanceKV)
		{
			this.angleKV = angleKV;
			this.isLocalKV = isLocalKV;
			this.angleTypeKV = angleTypeKV;
			this.distanceKV = distanceKV;
		}

		// Token: 0x06000D20 RID: 3360 RVA: 0x000168E8 File Offset: 0x00014AE8
		public override void AddHeader(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(21, 4, sb);
			appendInterpolatedStringHandler.AppendLiteral("doorhelper( ");
			appendInterpolatedStringHandler.AppendFormatted(this.angleKV.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.isLocalKV.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.angleTypeKV.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.distanceKV.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" ) ");
			sb.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04000DE8 RID: 3560
		private string angleKV;

		// Token: 0x04000DE9 RID: 3561
		private string isLocalKV;

		// Token: 0x04000DEA RID: 3562
		private string angleTypeKV;

		// Token: 0x04000DEB RID: 3563
		private string distanceKV;
	}
}
