using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	// Token: 0x0200021A RID: 538
	[AttributeUsage(AttributeTargets.Class)]
	internal class GlobalAttribute : MetaDataAttribute
	{
		// Token: 0x06000D40 RID: 3392 RVA: 0x000172CB File Offset: 0x000154CB
		public GlobalAttribute(string global)
		{
			this.Global = global;
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x000172DC File Offset: 0x000154DC
		public override void AddHeader(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("global( ");
			appendInterpolatedStringHandler.AppendFormatted(this.Global.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" ) ");
			sb.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04000E08 RID: 3592
		internal string Global;
	}
}
