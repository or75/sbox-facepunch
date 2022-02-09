using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Used by light_environment entity internally.
	/// </summary>
	// Token: 0x0200021B RID: 539
	[AttributeUsage(AttributeTargets.Class)]
	internal class BakeAmbientLightAttribute : MetaDataAttribute
	{
		// Token: 0x06000D42 RID: 3394 RVA: 0x00017329 File Offset: 0x00015529
		public BakeAmbientLightAttribute(string clrKey)
		{
			this.AmbientColor = clrKey;
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x00017338 File Offset: 0x00015538
		public override void AddHeader(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(21, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("bakeambientlight( ");
			appendInterpolatedStringHandler.AppendFormatted(this.AmbientColor.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" ) ");
			sb.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04000E09 RID: 3593
		internal string AmbientColor;
	}
}
