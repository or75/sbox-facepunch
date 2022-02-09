using System;
using System.Runtime.CompilerServices;

namespace Tools
{
	// Token: 0x020000D6 RID: 214
	public class ConVarBind : DataBind
	{
		// Token: 0x060017C2 RID: 6082 RVA: 0x0005B9AD File Offset: 0x00059BAD
		public ConVarBind(string convar)
		{
			this.Target = convar;
		}

		// Token: 0x060017C3 RID: 6083 RVA: 0x0005B9BC File Offset: 0x00059BBC
		public override object GetValue()
		{
			return ConsoleSystem.GetValue(this.Target, null);
		}

		// Token: 0x060017C4 RID: 6084 RVA: 0x0005B9CA File Offset: 0x00059BCA
		public override Type GetTargetType()
		{
			return typeof(string);
		}

		// Token: 0x060017C5 RID: 6085 RVA: 0x0005B9D6 File Offset: 0x00059BD6
		public override bool IsWritable()
		{
			return true;
		}

		// Token: 0x060017C6 RID: 6086 RVA: 0x0005B9D9 File Offset: 0x00059BD9
		protected override void SetDataValue(object value)
		{
			ConsoleSystem.SetValue(this.Target, this.ConvertToString(value));
		}

		// Token: 0x060017C7 RID: 6087 RVA: 0x0005B9F0 File Offset: 0x00059BF0
		private string ConvertToString(object value)
		{
			if (value == null)
			{
				return "";
			}
			if (value.GetType().IsEnum)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<long>(Convert.ToInt64(value));
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return value.ToString();
		}

		// Token: 0x040004E1 RID: 1249
		public string Target;
	}
}
