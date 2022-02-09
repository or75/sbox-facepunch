using System;
using System.Text;
using Hammer;
using Sandbox;

namespace ModelDoc
{
	/// <summary>
	/// Adds a custom editor widget to the game data node.
	/// Currently only 1 option is available - "HandPosePairEditor"
	/// </summary>
	// Token: 0x020001F7 RID: 503
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
	public class EditorWidgetAttribute : MetaDataAttribute
	{
		// Token: 0x06000CC5 RID: 3269 RVA: 0x00015C94 File Offset: 0x00013E94
		public EditorWidgetAttribute(string editor)
		{
			this.Editor = editor;
		}

		// Token: 0x06000CC6 RID: 3270 RVA: 0x00015CA4 File Offset: 0x00013EA4
		public override void AddHeader(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(25, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("custom_editor_widget( ");
			appendInterpolatedStringHandler.AppendFormatted(this.Editor.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" ) ");
			sb.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04000DBB RID: 3515
		internal string Editor;
	}
}
