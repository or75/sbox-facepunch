using System;

namespace Sandbox.Html
{
	/// <summary>
	/// Represents the type of a node.
	/// </summary>
	// Token: 0x02000063 RID: 99
	internal enum NodeType
	{
		/// <summary>
		/// The root of a document.
		/// </summary>
		// Token: 0x0400091D RID: 2333
		Document,
		/// <summary>
		/// An HTML element.
		/// </summary>
		// Token: 0x0400091E RID: 2334
		Element,
		/// <summary>
		/// An HTML comment.
		/// </summary>
		// Token: 0x0400091F RID: 2335
		Comment,
		/// <summary>
		/// A text node is always the child of an element or a document node.
		/// </summary>
		// Token: 0x04000920 RID: 2336
		Text
	}
}
