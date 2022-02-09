using System;
using System.Collections.Generic;
using System.Text;
using Hammer;

namespace Sandbox.Internal
{
	// Token: 0x020002E9 RID: 745
	public class BaseModelDocAttribute : MetaDataAttribute
	{
		// Token: 0x060013C9 RID: 5065 RVA: 0x0002A58C File Offset: 0x0002878C
		public BaseModelDocAttribute(string name)
		{
			this.HelperName = name;
		}

		// Token: 0x060013CA RID: 5066 RVA: 0x0002A5A8 File Offset: 0x000287A8
		public override void AddHeader(StringBuilder sb)
		{
			if (sb[sb.Length - 1] != '\n')
			{
				sb.Append("\r\n");
			}
			sb.AppendLine(this.HelperName);
			sb.AppendLine("{");
			this.AddTransform(sb);
			Dictionary<string, object> KVs = new Dictionary<string, object>();
			this.AddKeys(KVs);
			foreach (KeyValuePair<string, object> pair in KVs)
			{
				if (pair.Value != null && (!(pair.Value is string) || !string.IsNullOrEmpty((string)pair.Value)))
				{
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, sb);
					appendInterpolatedStringHandler.AppendLiteral("\t");
					appendInterpolatedStringHandler.AppendFormatted(pair.Key.QuoteSafe());
					appendInterpolatedStringHandler.AppendLiteral(" = ");
					appendInterpolatedStringHandler.AppendFormatted((pair.Value is string) ? ((string)pair.Value).QuoteSafe() : pair.Value.ToString().ToLower());
					sb.AppendLine(ref appendInterpolatedStringHandler);
				}
			}
			sb.AppendLine("}");
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x0002A6F4 File Offset: 0x000288F4
		protected virtual void AddTransform(StringBuilder sb)
		{
		}

		// Token: 0x060013CC RID: 5068 RVA: 0x0002A6F6 File Offset: 0x000288F6
		protected virtual void AddKeys(Dictionary<string, object> dict)
		{
		}

		// Token: 0x0400151E RID: 5406
		internal string HelperName = "";
	}
}
