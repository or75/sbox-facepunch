using System;

namespace Sandbox
{
	/// <summary>
	/// Overrides the auto generated FGD type.
	/// </summary>
	// Token: 0x020002AA RID: 682
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Property)]
	public class FGDTypeAttribute : Attribute
	{
		/// <param name="type">The FGD type override.</param>
		/// <param name="editor">The name of a custom editor to use for this property.</param>
		/// <param name="editorArgs">Arguments for given editor override. Format depends on each editor.</param>
		// Token: 0x06001151 RID: 4433 RVA: 0x00022A08 File Offset: 0x00020C08
		public FGDTypeAttribute(string type, string editor = "", string editorArgs = "")
		{
			this.Type = type;
			this.Editor = (string.IsNullOrEmpty(editor) ? "" : (editor + "(" + editorArgs + ")"));
		}

		// Token: 0x0400138A RID: 5002
		public string Type;

		// Token: 0x0400138B RID: 5003
		public string Editor;
	}
}
