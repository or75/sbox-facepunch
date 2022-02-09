using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Displays text in Hammer on the entity.
	/// </summary>
	// Token: 0x02000211 RID: 529
	[AttributeUsage(AttributeTargets.Class)]
	public class TextAttribute : MetaDataAttribute
	{
		/// <param name="text">The text to display.</param>
		/// <param name="offsetVariable">The name of the property that will act as the position of the text.</param>
		/// <param name="worldspace">Whether the position from the variable should be interpreted in world space (true) or in local space (false).</param>
		// Token: 0x06000D2B RID: 3371 RVA: 0x00016C3D File Offset: 0x00014E3D
		public TextAttribute(string text = "", string offsetVariable = "origin", bool worldspace = false)
		{
			this.offsetVariable = offsetVariable;
			this.text = text.Replace("\n", "\\n");
			this.local = !worldspace;
		}

		// Token: 0x06000D2C RID: 3372 RVA: 0x00016C6C File Offset: 0x00014E6C
		public override void AddHeader(StringBuilder sb)
		{
			sb.Append("text");
			if (this.local)
			{
				sb.Append("_local");
			}
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("( ");
			appendInterpolatedStringHandler.AppendFormatted(this.offsetVariable.QuoteSafe());
			sb.Append(ref appendInterpolatedStringHandler);
			if (!string.IsNullOrEmpty(this.text))
			{
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, sb);
				appendInterpolatedStringHandler.AppendLiteral(", ");
				appendInterpolatedStringHandler.AppendFormatted(this.text.QuoteSafe());
				sb.Append(ref appendInterpolatedStringHandler);
			}
			sb.Append(" ) ");
		}

		// Token: 0x04000DF5 RID: 3573
		private string offsetVariable;

		// Token: 0x04000DF6 RID: 3574
		private string text;

		// Token: 0x04000DF7 RID: 3575
		private bool local;
	}
}
