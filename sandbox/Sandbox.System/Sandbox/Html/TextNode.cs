using System;
using System.Web;

namespace Sandbox.Html
{
	/// <summary>
	/// Represents an HTML text node.
	/// </summary>
	// Token: 0x02000066 RID: 102
	internal class TextNode : Node
	{
		// Token: 0x0600048B RID: 1163 RVA: 0x00020F55 File Offset: 0x0001F155
		internal TextNode(Document ownerdocument, int index)
			: base(NodeType.Text, ownerdocument, index)
		{
		}

		/// <summary>
		/// Gets or Sets the HTML between the start and end tags of the object. In the case of a text node, it is equals to OuterHtml.
		/// </summary>
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x0600048C RID: 1164 RVA: 0x00020F60 File Offset: 0x0001F160
		public override string InnerHtml
		{
			get
			{
				return this.OuterHtml;
			}
		}

		/// <summary>
		/// Gets or Sets the object and its content in HTML.
		/// </summary>
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x00020F68 File Offset: 0x0001F168
		public override string OuterHtml
		{
			get
			{
				string result;
				if ((result = this._text) == null)
				{
					result = (this._text = HttpUtility.HtmlDecode(base.OuterHtml));
				}
				return result;
			}
		}

		// Token: 0x0400092D RID: 2349
		private string _text;
	}
}
