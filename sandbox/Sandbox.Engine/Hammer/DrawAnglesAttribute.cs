using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Draws the movement direction in Hammer.
	/// </summary>
	/// <example>
	/// [Hammer.DrawAngles( "movedir", "movedir_islocal" )]
	/// </example>
	// Token: 0x0200020B RID: 523
	[AttributeUsage(AttributeTargets.Class)]
	public class DrawAnglesAttribute : MetaDataAttribute
	{
		// Token: 0x06000D1C RID: 3356 RVA: 0x000167D1 File Offset: 0x000149D1
		public DrawAnglesAttribute()
		{
		}

		// Token: 0x06000D1D RID: 3357 RVA: 0x000167D9 File Offset: 0x000149D9
		public DrawAnglesAttribute(string angleKV, string isLocalKV = null)
		{
			this.angleKV = angleKV;
			this.isLocalKV = isLocalKV;
		}

		// Token: 0x06000D1E RID: 3358 RVA: 0x000167F0 File Offset: 0x000149F0
		public override void AddHeader(StringBuilder sb)
		{
			if (string.IsNullOrEmpty(this.angleKV))
			{
				sb.Append("drawangles() ");
				return;
			}
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler;
			if (string.IsNullOrEmpty(this.isLocalKV))
			{
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, sb);
				appendInterpolatedStringHandler.AppendLiteral("drawangles( ");
				appendInterpolatedStringHandler.AppendFormatted(this.angleKV.QuoteSafe());
				appendInterpolatedStringHandler.AppendLiteral(" ) ");
				sb.Append(ref appendInterpolatedStringHandler);
				return;
			}
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(17, 2, sb);
			appendInterpolatedStringHandler.AppendLiteral("drawangles( ");
			appendInterpolatedStringHandler.AppendFormatted(this.angleKV.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.isLocalKV.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" ) ");
			sb.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04000DE6 RID: 3558
		private string angleKV;

		// Token: 0x04000DE7 RID: 3559
		private string isLocalKV;
	}
}
