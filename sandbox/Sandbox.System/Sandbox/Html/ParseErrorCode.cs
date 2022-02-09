using System;

namespace Sandbox.Html
{
	/// <summary>
	/// Represents the type of parsing error.
	/// </summary>
	// Token: 0x02000065 RID: 101
	internal enum ParseErrorCode
	{
		/// <summary>
		/// A tag was not closed.
		/// </summary>
		// Token: 0x04000928 RID: 2344
		TagNotClosed,
		/// <summary>
		/// A tag was not opened.
		/// </summary>
		// Token: 0x04000929 RID: 2345
		TagNotOpened,
		/// <summary>
		/// There is a charset mismatch between stream and declared (META) encoding.
		/// </summary>
		// Token: 0x0400092A RID: 2346
		CharsetMismatch,
		/// <summary>
		/// An end tag was not required.
		/// </summary>
		// Token: 0x0400092B RID: 2347
		EndTagNotRequired,
		/// <summary>
		/// An end tag is invalid at this position.
		/// </summary>
		// Token: 0x0400092C RID: 2348
		EndTagInvalidHere
	}
}
