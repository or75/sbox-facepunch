using System;
using System.Collections.Generic;
using System.IO;

namespace Sandbox.Html
{
	/// <summary>
	/// Represents a complete HTML document.
	/// </summary>
	// Token: 0x02000060 RID: 96
	internal class Document
	{
		/// <summary>Gets the parsed text.</summary>
		/// <value>The parsed text.</value>
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x06000427 RID: 1063 RVA: 0x0001F3DE File Offset: 0x0001D5DE
		public string ParsedText
		{
			get
			{
				return this.Text;
			}
		}

		/// <summary>
		/// Defines the max level we would go deep into the html document. If this depth level is exceeded, and exception is
		/// thrown.
		/// </summary>
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x06000428 RID: 1064 RVA: 0x0001F3E6 File Offset: 0x0001D5E6
		internal static int MaxDepthLevel
		{
			get
			{
				return 256;
			}
		}

		/// <summary>
		/// Gets the root node of the document.
		/// </summary>
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x0001F3ED File Offset: 0x0001D5ED
		public Node DocumentNode
		{
			get
			{
				return this._documentnode;
			}
		}

		/// <summary>
		/// Gets a list of parse errors found in the document.
		/// </summary>
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x0600042A RID: 1066 RVA: 0x0001F3F5 File Offset: 0x0001D5F5
		public IEnumerable<ParseError> ParseErrors
		{
			get
			{
				return this._parseerrors;
			}
		}

		/// <summary>
		/// Determines if the specified character is considered as a whitespace character.
		/// </summary>
		/// <param name="c">The character to check.</param>
		/// <returns>true if if the specified character is considered as a whitespace character.</returns>
		// Token: 0x0600042B RID: 1067 RVA: 0x0001F3FD File Offset: 0x0001D5FD
		public static bool IsWhiteSpace(int c)
		{
			return c == 10 || c == 13 || c == 32 || c == 9;
		}

		/// <summary>
		/// Loads the HTML document from the specified TextReader.
		/// </summary>
		/// <param name="reader">The TextReader used to feed the HTML data into the document. May not be null.</param>
		// Token: 0x0600042C RID: 1068 RVA: 0x0001F418 File Offset: 0x0001D618
		public void Load(TextReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (this.OptionCheckSyntax)
			{
				this.Openednodes = new Dictionary<int, Node>();
			}
			else
			{
				this.Openednodes = null;
			}
			this.Text = reader.ReadToEnd();
			this._documentnode = this.CreateNode(NodeType.Document, 0);
			this.Parse();
			if (!this.OptionCheckSyntax || this.Openednodes == null)
			{
				return;
			}
			foreach (Node node in this.Openednodes.Values)
			{
				if (node._starttag)
				{
					this.AddError(ParseErrorCode.TagNotClosed, node._line, node._lineposition, node._streamposition, string.Empty, "End tag </" + node.Name + "> was not found");
				}
			}
			this.Openednodes.Clear();
		}

		/// <summary>
		/// Loads the HTML document from the specified string.
		/// </summary>
		/// <param name="html">String containing the HTML document to load. May not be null.</param>
		// Token: 0x0600042D RID: 1069 RVA: 0x0001F50C File Offset: 0x0001D70C
		public void LoadHtml(string html)
		{
			if (html == null)
			{
				throw new ArgumentNullException("html");
			}
			using (StringReader sr = new StringReader(html))
			{
				this.Load(sr);
			}
		}

		// Token: 0x0600042E RID: 1070 RVA: 0x0001F554 File Offset: 0x0001D754
		internal Node CreateNode(NodeType type, int index)
		{
			if (type == NodeType.Text)
			{
				return new TextNode(this, index);
			}
			return new Node(type, this, index);
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0001F56A File Offset: 0x0001D76A
		internal void SetIdForNode(Node node, string id)
		{
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0001F56C File Offset: 0x0001D76C
		internal void UpdateLastParentNode()
		{
			do
			{
				if (this._lastparentnode.Closed)
				{
					this._lastparentnode = this._lastparentnode.ParentNode;
				}
			}
			while (this._lastparentnode != null && this._lastparentnode.Closed);
			if (this._lastparentnode == null)
			{
				this._lastparentnode = this._documentnode;
			}
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0001F5C0 File Offset: 0x0001D7C0
		private void AddError(ParseErrorCode code, int line, int linePosition, int streamPosition, string sourceText, string reason)
		{
			ParseError err = new ParseError(code, line, linePosition, streamPosition, sourceText, reason);
			this._parseerrors.Add(err);
		}

		// Token: 0x06000432 RID: 1074 RVA: 0x0001F5E8 File Offset: 0x0001D7E8
		private void CloseCurrentNode()
		{
			if (this._currentnode.Closed)
			{
				return;
			}
			Node prev = this.Lastnodes.GetValueOrDefault(this._currentnode.Name, null);
			if (prev == null)
			{
				throw new Exception("Couldn't find previous tag");
			}
			this.Lastnodes[this._currentnode.Name] = prev._prevwithsamename;
			prev.CloseNode(this._currentnode, 0);
			if (this._lastparentnode != null)
			{
				this.UpdateLastParentNode();
			}
		}

		// Token: 0x06000433 RID: 1075 RVA: 0x0001F660 File Offset: 0x0001D860
		private void DecrementPosition()
		{
			this._index--;
			if (this._lineposition == 0)
			{
				this._lineposition = this._maxlineposition;
				this._line--;
				return;
			}
			this._lineposition--;
		}

		// Token: 0x06000434 RID: 1076 RVA: 0x0001F6AC File Offset: 0x0001D8AC
		private void IncrementPosition()
		{
			this._index++;
			this._maxlineposition = this._lineposition;
			if (this._c == 10)
			{
				this._lineposition = 0;
				this._line++;
				return;
			}
			this._lineposition++;
		}

		// Token: 0x06000435 RID: 1077 RVA: 0x0001F704 File Offset: 0x0001D904
		private bool IsValidTag()
		{
			return this._c == 60 && this._index < this.Text.Length && (char.IsLetter(this.Text[this._index]) || this.Text[this._index] == '/' || this.Text[this._index] == '?' || this.Text[this._index] == '!' || this.Text[this._index] == '%');
		}

		// Token: 0x06000436 RID: 1078 RVA: 0x0001F7A4 File Offset: 0x0001D9A4
		private bool NewCheck()
		{
			if (this._c != 60 || !this.IsValidTag())
			{
				return false;
			}
			if (!this.PushNodeEnd(this._index - 1, true))
			{
				this._index = this.Text.Length;
				return true;
			}
			this._state = Document.ParseState.WhichTag;
			if (this._index - 1 <= this.Text.Length - 2 && (this.Text[this._index] == '!' || this.Text[this._index] == '?'))
			{
				this.PushNodeStart(NodeType.Comment, this._index - 1, this._lineposition - 1);
				this.PushNodeNameStart(true, this._index);
				this.PushNodeNameEnd(this._index + 1);
				this._state = Document.ParseState.Comment;
				if (this._index < this.Text.Length - 2)
				{
					if (this.Text[this._index + 1] == '-' && this.Text[this._index + 2] == '-')
					{
						this._fullcomment = true;
					}
					else
					{
						this._fullcomment = false;
					}
				}
				return true;
			}
			this.PushNodeStart(NodeType.Element, this._index - 1, this._lineposition - 1);
			return true;
		}

		// Token: 0x06000437 RID: 1079 RVA: 0x0001F8E0 File Offset: 0x0001DAE0
		private void Parse()
		{
			int lastquote = 0;
			this.Lastnodes = new Dictionary<string, Node>();
			this._c = 0;
			this._fullcomment = false;
			this._parseerrors = new List<ParseError>();
			this._line = 1;
			this._lineposition = 0;
			this._maxlineposition = 0;
			this._state = Document.ParseState.Text;
			this._documentnode._innerlength = this.Text.Length;
			this._documentnode._outerlength = this.Text.Length;
			this._lastparentnode = this._documentnode;
			this._currentnode = this.CreateNode(NodeType.Text, 0);
			this._currentattribute = null;
			this._index = 0;
			this.PushNodeStart(NodeType.Text, 0, this._lineposition);
			while (this._index < this.Text.Length)
			{
				this._c = (int)this.Text[this._index];
				this.IncrementPosition();
				switch (this._state)
				{
				case Document.ParseState.Text:
					if (this.NewCheck())
					{
					}
					break;
				case Document.ParseState.WhichTag:
					if (!this.NewCheck())
					{
						if (this._c == 47)
						{
							this.PushNodeNameStart(false, this._index);
						}
						else
						{
							this.PushNodeNameStart(true, this._index - 1);
							this.DecrementPosition();
						}
						this._state = Document.ParseState.Tag;
					}
					break;
				case Document.ParseState.Tag:
					if (!this.NewCheck())
					{
						if (Document.IsWhiteSpace(this._c))
						{
							this.PushNodeNameEnd(this._index - 1);
							if (this._state == Document.ParseState.Tag)
							{
								this._state = Document.ParseState.BetweenAttributes;
							}
						}
						else if (this._c == 47)
						{
							this.PushNodeNameEnd(this._index - 1);
							if (this._state == Document.ParseState.Tag)
							{
								this._state = Document.ParseState.EmptyTag;
							}
						}
						else if (this._c == 62)
						{
							this.PushNodeNameEnd(this._index - 1);
							if (this._state == Document.ParseState.Tag)
							{
								if (!this.PushNodeEnd(this._index, false))
								{
									this._index = this.Text.Length;
								}
								else if (this._state == Document.ParseState.Tag)
								{
									this._state = Document.ParseState.Text;
									this.PushNodeStart(NodeType.Text, this._index, this._lineposition);
								}
							}
						}
					}
					break;
				case Document.ParseState.BetweenAttributes:
					if (!this.NewCheck() && !Document.IsWhiteSpace(this._c))
					{
						if (this._c == 47 || this._c == 63)
						{
							this._state = Document.ParseState.EmptyTag;
						}
						else if (this._c == 62)
						{
							if (!this.PushNodeEnd(this._index, false))
							{
								this._index = this.Text.Length;
							}
							else if (this._state == Document.ParseState.BetweenAttributes)
							{
								this._state = Document.ParseState.Text;
								this.PushNodeStart(NodeType.Text, this._index, this._lineposition);
							}
						}
						else
						{
							this.PushAttributeNameStart(this._index - 1, this._lineposition - 1);
							this._state = Document.ParseState.AttributeName;
						}
					}
					break;
				case Document.ParseState.EmptyTag:
					if (!this.NewCheck())
					{
						if (this._c == 62)
						{
							if (!this.PushNodeEnd(this._index, true))
							{
								this._index = this.Text.Length;
							}
							else if (this._state == Document.ParseState.EmptyTag)
							{
								this._state = Document.ParseState.Text;
								this.PushNodeStart(NodeType.Text, this._index, this._lineposition);
							}
						}
						else if (!Document.IsWhiteSpace(this._c))
						{
							this.DecrementPosition();
							this._state = Document.ParseState.BetweenAttributes;
						}
						else
						{
							this._state = Document.ParseState.BetweenAttributes;
						}
					}
					break;
				case Document.ParseState.AttributeName:
					if (!this.NewCheck())
					{
						if (Document.IsWhiteSpace(this._c))
						{
							this.PushAttributeNameEnd(this._index - 1);
							this._state = Document.ParseState.AttributeBeforeEquals;
						}
						else if (this._c == 61)
						{
							this.PushAttributeNameEnd(this._index - 1);
							this._state = Document.ParseState.AttributeAfterEquals;
						}
						else if (this._c == 62)
						{
							this.PushAttributeNameEnd(this._index - 1);
							if (!this.PushNodeEnd(this._index, false))
							{
								this._index = this.Text.Length;
							}
							else if (this._state == Document.ParseState.AttributeName)
							{
								this._state = Document.ParseState.Text;
								this.PushNodeStart(NodeType.Text, this._index, this._lineposition);
							}
						}
					}
					break;
				case Document.ParseState.AttributeBeforeEquals:
					if (!this.NewCheck() && !Document.IsWhiteSpace(this._c))
					{
						if (this._c == 62)
						{
							if (!this.PushNodeEnd(this._index, false))
							{
								this._index = this.Text.Length;
							}
							else if (this._state == Document.ParseState.AttributeBeforeEquals)
							{
								this._state = Document.ParseState.Text;
								this.PushNodeStart(NodeType.Text, this._index, this._lineposition);
							}
						}
						else if (this._c == 61)
						{
							this._state = Document.ParseState.AttributeAfterEquals;
						}
						else
						{
							this._state = Document.ParseState.BetweenAttributes;
							this.DecrementPosition();
						}
					}
					break;
				case Document.ParseState.AttributeAfterEquals:
					if (!this.NewCheck() && !Document.IsWhiteSpace(this._c))
					{
						if (this._c == 39 || this._c == 34)
						{
							this._state = Document.ParseState.QuotedAttributeValue;
							this.PushAttributeValueStart(this._index, this._c);
							lastquote = this._c;
						}
						else if (this._c == 62)
						{
							if (!this.PushNodeEnd(this._index, false))
							{
								this._index = this.Text.Length;
							}
							else if (this._state == Document.ParseState.AttributeAfterEquals)
							{
								this._state = Document.ParseState.Text;
								this.PushNodeStart(NodeType.Text, this._index, this._lineposition);
							}
						}
						else
						{
							this.PushAttributeValueStart(this._index - 1);
							this._state = Document.ParseState.AttributeValue;
						}
					}
					break;
				case Document.ParseState.AttributeValue:
					if (!this.NewCheck())
					{
						if (Document.IsWhiteSpace(this._c))
						{
							this.PushAttributeValueEnd(this._index - 1);
							this._state = Document.ParseState.BetweenAttributes;
						}
						else if (this._c == 62)
						{
							this.PushAttributeValueEnd(this._index - 1);
							if (!this.PushNodeEnd(this._index, false))
							{
								this._index = this.Text.Length;
							}
							else if (this._state == Document.ParseState.AttributeValue)
							{
								this._state = Document.ParseState.Text;
								this.PushNodeStart(NodeType.Text, this._index, this._lineposition);
							}
						}
					}
					break;
				case Document.ParseState.Comment:
					if (this._c == 62 && (!this._fullcomment || (this.Text[this._index - 2] == '-' && this.Text[this._index - 3] == '-') || (this.Text[this._index - 2] == '!' && this.Text[this._index - 3] == '-' && this.Text[this._index - 4] == '-')))
					{
						if (!this.PushNodeEnd(this._index, false))
						{
							this._index = this.Text.Length;
						}
						else
						{
							this._state = Document.ParseState.Text;
							this.PushNodeStart(NodeType.Text, this._index, this._lineposition);
						}
					}
					break;
				case Document.ParseState.QuotedAttributeValue:
					if (this._c == lastquote)
					{
						this.PushAttributeValueEnd(this._index - 1);
						this._state = Document.ParseState.BetweenAttributes;
					}
					break;
				case Document.ParseState.PcData:
					if (this._currentnode._namelength + 3 <= this.Text.Length - (this._index - 1) && string.Compare(this.Text.Substring(this._index - 1, this._currentnode._namelength + 2), "</" + this._currentnode.Name, StringComparison.OrdinalIgnoreCase) == 0)
					{
						int c = (int)this.Text[this._index - 1 + 2 + this._currentnode.Name.Length];
						if (c == 62 || Document.IsWhiteSpace(c))
						{
							Node script = this.CreateNode(NodeType.Text, this._currentnode._outerstartindex + this._currentnode._outerlength);
							script._outerlength = this._index - 1 - script._outerstartindex;
							script._streamposition = script._outerstartindex;
							script._line = this._currentnode.Line;
							script._lineposition = this._currentnode.LinePosition + this._currentnode._namelength + 2;
							this._currentnode.AppendChild(script);
							this.PushNodeStart(NodeType.Element, this._index - 1, this._lineposition - 1);
							this.PushNodeNameStart(false, this._index - 1 + 2);
							this._state = Document.ParseState.Tag;
							this.IncrementPosition();
						}
					}
					break;
				}
			}
			if (this._currentnode._namestartindex > 0)
			{
				this.PushNodeNameEnd(this._index);
			}
			this.PushNodeEnd(this._index, false);
			this.Lastnodes.Clear();
			this.DocumentNode.FixSelfClosingTags();
		}

		// Token: 0x06000438 RID: 1080 RVA: 0x000201D8 File Offset: 0x0001E3D8
		private void PushAttributeNameEnd(int index)
		{
			this._currentattribute._namelength = index - this._currentattribute._namestartindex;
			if (this._currentattribute.Name != null && !Document.BlockAttributes.Contains(this._currentattribute.Name))
			{
				this._currentnode.Attributes.Add(this._currentattribute);
			}
		}

		// Token: 0x06000439 RID: 1081 RVA: 0x00020237 File Offset: 0x0001E437
		private void PushAttributeNameStart(int index, int lineposition)
		{
			this._currentattribute = new Attribute(this);
			this._currentattribute._namestartindex = index;
		}

		// Token: 0x0600043A RID: 1082 RVA: 0x00020251 File Offset: 0x0001E451
		private void PushAttributeValueEnd(int index)
		{
			this._currentattribute._valuelength = index - this._currentattribute._valuestartindex;
		}

		// Token: 0x0600043B RID: 1083 RVA: 0x0002026B File Offset: 0x0001E46B
		private void PushAttributeValueStart(int index)
		{
			this.PushAttributeValueStart(index, 0);
		}

		// Token: 0x0600043C RID: 1084 RVA: 0x00020275 File Offset: 0x0001E475
		private void PushAttributeValueStart(int index, int quote)
		{
			this._currentattribute._valuestartindex = index;
		}

		// Token: 0x0600043D RID: 1085 RVA: 0x00020284 File Offset: 0x0001E484
		private bool PushNodeEnd(int index, bool close)
		{
			this._currentnode._outerlength = index - this._currentnode._outerstartindex;
			if (this._currentnode._nodetype == NodeType.Text || this._currentnode._nodetype == NodeType.Comment)
			{
				if (this._currentnode._nodetype != NodeType.Comment && this._currentnode._outerlength > 0)
				{
					this._currentnode._innerlength = this._currentnode._outerlength;
					this._currentnode._innerstartindex = this._currentnode._outerstartindex;
					if (this._lastparentnode != null)
					{
						this._lastparentnode.AppendChild(this._currentnode);
					}
				}
			}
			else if (this._currentnode._starttag && this._lastparentnode != this._currentnode)
			{
				if (this._lastparentnode != null)
				{
					this._lastparentnode.AppendChild(this._currentnode);
				}
				Node prev = this.Lastnodes.GetValueOrDefault(this._currentnode.Name, null);
				this._currentnode._prevwithsamename = prev;
				this.Lastnodes[this._currentnode.Name] = this._currentnode;
				if (this._currentnode.NodeType == NodeType.Document || this._currentnode.NodeType == NodeType.Element)
				{
					this._lastparentnode = this._currentnode;
				}
			}
			if (close || !this._currentnode._starttag)
			{
				this.CloseCurrentNode();
			}
			return true;
		}

		// Token: 0x0600043E RID: 1086 RVA: 0x000203EE File Offset: 0x0001E5EE
		private void PushNodeNameEnd(int index)
		{
			this._currentnode._namelength = index - this._currentnode._namestartindex;
		}

		// Token: 0x0600043F RID: 1087 RVA: 0x00020408 File Offset: 0x0001E608
		private void PushNodeNameStart(bool starttag, int index)
		{
			this._currentnode._starttag = starttag;
			this._currentnode._namestartindex = index;
		}

		// Token: 0x06000440 RID: 1088 RVA: 0x00020422 File Offset: 0x0001E622
		private void PushNodeStart(NodeType type, int index, int lineposition)
		{
			this._currentnode = this.CreateNode(type, index);
			this._currentnode._line = this._line;
			this._currentnode._lineposition = lineposition;
			this._currentnode._streamposition = index;
		}

		// Token: 0x040008E9 RID: 2281
		private int _c;

		// Token: 0x040008EA RID: 2282
		private Attribute _currentattribute;

		// Token: 0x040008EB RID: 2283
		private Node _currentnode;

		// Token: 0x040008EC RID: 2284
		private Node _documentnode;

		// Token: 0x040008ED RID: 2285
		private bool _fullcomment;

		// Token: 0x040008EE RID: 2286
		private int _index;

		// Token: 0x040008EF RID: 2287
		internal Dictionary<string, Node> Lastnodes = new Dictionary<string, Node>();

		// Token: 0x040008F0 RID: 2288
		private Node _lastparentnode;

		// Token: 0x040008F1 RID: 2289
		private int _line;

		// Token: 0x040008F2 RID: 2290
		private int _lineposition;

		// Token: 0x040008F3 RID: 2291
		private int _maxlineposition;

		// Token: 0x040008F4 RID: 2292
		internal Dictionary<int, Node> Openednodes;

		// Token: 0x040008F5 RID: 2293
		private List<ParseError> _parseerrors = new List<ParseError>();

		// Token: 0x040008F6 RID: 2294
		private Document.ParseState _state;

		/// <summary>The HtmlDocument Text. Careful if you modify it.</summary>
		// Token: 0x040008F7 RID: 2295
		public string Text;

		/// <summary>True to stay backward compatible with previous version of HAP. This option does not guarantee 100% compatibility.</summary>
		// Token: 0x040008F8 RID: 2296
		public bool BackwardCompatibility = true;

		/// <summary>
		/// Defines if non closed nodes will be checked at the end of parsing. Default is true.
		/// </summary>
		// Token: 0x040008F9 RID: 2297
		public bool OptionCheckSyntax = true;

		/// <summary>
		/// Defines the maximum length of source text or parse errors. Default is 100.
		/// </summary>
		// Token: 0x040008FA RID: 2298
		public int OptionExtractErrorSourceTextMaxLength = 100;

		/// <summary>
		/// The max number of nested child nodes. 
		/// Added to prevent stackoverflow problem when a page has tens of thousands of opening html tags with no closing tags 
		/// </summary>
		// Token: 0x040008FB RID: 2299
		public int OptionMaxNestedChildNodes;

		// Token: 0x040008FC RID: 2300
		internal static readonly string HtmlExceptionRefNotChild = "Reference node must be a child of this node";

		// Token: 0x040008FD RID: 2301
		internal static readonly string HtmlExceptionUseIdAttributeFalse = "You need to set UseIdAttribute property to true to enable this feature";

		// Token: 0x040008FE RID: 2302
		internal static readonly string HtmlExceptionClassDoesNotExist = "Class name doesn't exist";

		// Token: 0x040008FF RID: 2303
		internal static readonly string HtmlExceptionClassExists = "Class name already exists";

		// Token: 0x04000900 RID: 2304
		private static List<string> BlockAttributes = new List<string> { "\"", "'" };

		// Token: 0x02000085 RID: 133
		private enum ParseState
		{
			// Token: 0x0400095C RID: 2396
			Text,
			// Token: 0x0400095D RID: 2397
			WhichTag,
			// Token: 0x0400095E RID: 2398
			Tag,
			// Token: 0x0400095F RID: 2399
			BetweenAttributes,
			// Token: 0x04000960 RID: 2400
			EmptyTag,
			// Token: 0x04000961 RID: 2401
			AttributeName,
			// Token: 0x04000962 RID: 2402
			AttributeBeforeEquals,
			// Token: 0x04000963 RID: 2403
			AttributeAfterEquals,
			// Token: 0x04000964 RID: 2404
			AttributeValue,
			// Token: 0x04000965 RID: 2405
			Comment,
			// Token: 0x04000966 RID: 2406
			QuotedAttributeValue,
			// Token: 0x04000967 RID: 2407
			PcData
		}
	}
}
