using System;

namespace Sandbox.Html
{
	/// <summary>
	/// Represents a parsing error found during document parsing.
	/// </summary>
	// Token: 0x02000064 RID: 100
	internal class ParseError
	{
		// Token: 0x06000484 RID: 1156 RVA: 0x00020EF0 File Offset: 0x0001F0F0
		internal ParseError(ParseErrorCode code, int line, int linePosition, int streamPosition, string sourceText, string reason)
		{
			this._code = code;
			this._line = line;
			this._linePosition = linePosition;
			this._streamPosition = streamPosition;
			this._sourceText = sourceText;
			this._reason = reason;
		}

		/// <summary>
		/// Gets the type of error.
		/// </summary>
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x06000485 RID: 1157 RVA: 0x00020F25 File Offset: 0x0001F125
		public ParseErrorCode Code
		{
			get
			{
				return this._code;
			}
		}

		/// <summary>
		/// Gets the line number of this error in the document.
		/// </summary>
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x06000486 RID: 1158 RVA: 0x00020F2D File Offset: 0x0001F12D
		public int Line
		{
			get
			{
				return this._line;
			}
		}

		/// <summary>
		/// Gets the column number of this error in the document.
		/// </summary>
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x00020F35 File Offset: 0x0001F135
		public int LinePosition
		{
			get
			{
				return this._linePosition;
			}
		}

		/// <summary>
		/// Gets a description for the error.
		/// </summary>
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x06000488 RID: 1160 RVA: 0x00020F3D File Offset: 0x0001F13D
		public string Reason
		{
			get
			{
				return this._reason;
			}
		}

		/// <summary>
		/// Gets the the full text of the line containing the error.
		/// </summary>
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x00020F45 File Offset: 0x0001F145
		public string SourceText
		{
			get
			{
				return this._sourceText;
			}
		}

		/// <summary>
		/// Gets the absolute stream position of this error in the document, relative to the start of the document.
		/// </summary>
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x00020F4D File Offset: 0x0001F14D
		public int StreamPosition
		{
			get
			{
				return this._streamPosition;
			}
		}

		// Token: 0x04000921 RID: 2337
		private ParseErrorCode _code;

		// Token: 0x04000922 RID: 2338
		private int _line;

		// Token: 0x04000923 RID: 2339
		private int _linePosition;

		// Token: 0x04000924 RID: 2340
		private string _reason;

		// Token: 0x04000925 RID: 2341
		private string _sourceText;

		// Token: 0x04000926 RID: 2342
		private int _streamPosition;
	}
}
