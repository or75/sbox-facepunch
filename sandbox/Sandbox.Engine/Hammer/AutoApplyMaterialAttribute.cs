using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Apply this material to the mesh when tying one to this class. Typically used for triggers.
	/// </summary>
	// Token: 0x020001FE RID: 510
	[AttributeUsage(AttributeTargets.Class)]
	public class AutoApplyMaterialAttribute : MetaDataAttribute
	{
		// Token: 0x06000CF4 RID: 3316 RVA: 0x000160B9 File Offset: 0x000142B9
		public AutoApplyMaterialAttribute(string MaterialName = "materials/tools/toolstrigger.vmat")
		{
			this.Value = MaterialName;
		}

		// Token: 0x06000CF5 RID: 3317 RVA: 0x000160C8 File Offset: 0x000142C8
		public override void AddMetaData(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(23, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("\tauto_apply_material = ");
			appendInterpolatedStringHandler.AppendFormatted(this.Value.QuoteSafe());
			sb.AppendLine(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04000DCC RID: 3532
		private string Value;
	}
}
