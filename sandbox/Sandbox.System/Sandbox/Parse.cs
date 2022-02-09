using System;
using System.Globalization;
using System.Linq;
using Sandbox.UI;

namespace Sandbox
{
	// Token: 0x02000059 RID: 89
	internal ref struct Parse
	{
		// Token: 0x060003CA RID: 970 RVA: 0x0001DD08 File Offset: 0x0001BF08
		public Parse(string value, string filename = "nofile")
		{
			this = default(Parse);
			this.FileName = filename;
			this.Text = value;
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060003CB RID: 971 RVA: 0x0001DD1F File Offset: 0x0001BF1F
		public int Length
		{
			get
			{
				return this.Text.Length;
			}
		}

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060003CC RID: 972 RVA: 0x0001DD2C File Offset: 0x0001BF2C
		public bool IsEnd
		{
			get
			{
				return this.Pointer >= this.Length;
			}
		}

		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060003CD RID: 973 RVA: 0x0001DD3F File Offset: 0x0001BF3F
		public char Current
		{
			get
			{
				if (!this.IsEnd)
				{
					return this.Text[this.Pointer];
				}
				return '\0';
			}
		}

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060003CE RID: 974 RVA: 0x0001DD5C File Offset: 0x0001BF5C
		public char Next
		{
			get
			{
				if (this.Pointer + 1 < this.Length)
				{
					return this.Text[this.Pointer + 1];
				}
				return '\0';
			}
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060003CF RID: 975 RVA: 0x0001DD83 File Offset: 0x0001BF83
		public bool IsWhitespace
		{
			get
			{
				return char.IsWhiteSpace(this.Current);
			}
		}

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x0001DD90 File Offset: 0x0001BF90
		public bool IsNewline
		{
			get
			{
				return this.Current == '\n' || this.Current == '\r';
			}
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060003D1 RID: 977 RVA: 0x0001DDA8 File Offset: 0x0001BFA8
		public bool IsDigit
		{
			get
			{
				return char.IsDigit(this.Current);
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x0001DDB5 File Offset: 0x0001BFB5
		public bool IsLetter
		{
			get
			{
				return char.IsLetter(this.Current);
			}
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0001DDC4 File Offset: 0x0001BFC4
		public Parse JumpToEndOfLine(bool afterNewline)
		{
			Parse p = this;
			while (!p.IsEnd && !p.IsNewline)
			{
				p.Pointer++;
			}
			if (afterNewline)
			{
				while (!p.IsEnd && p.IsNewline)
				{
					p.Pointer++;
				}
			}
			return p;
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0001DE1C File Offset: 0x0001C01C
		public bool IsOneOf(string chars)
		{
			return chars != null && chars.IndexOf(this.Current) >= 0;
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0001DE35 File Offset: 0x0001C035
		public string Read(int chars)
		{
			if (chars <= 0)
			{
				throw new Exception(string.Format("Tried to read {0} chars", chars));
			}
			string result = this.Text.Substring(this.Pointer, chars);
			this.Pointer += chars;
			return result;
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0001DE74 File Offset: 0x0001C074
		public string ReadRemaining(bool acceptNone = false)
		{
			if (this.IsEnd && acceptNone)
			{
				return string.Empty;
			}
			if (this.IsEnd)
			{
				throw new Exception("Tried to ReadRemaining but we're at the end");
			}
			string result = this.Text.Substring(this.Pointer);
			this.Pointer = this.Length;
			return result;
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0001DEC1 File Offset: 0x0001C0C1
		public Parse SkipWhitespaceAndNewlines(string andCharacters = null)
		{
			while (!this.IsEnd)
			{
				if (!this.IsWhitespace && !this.IsNewline && !this.IsOneOf(andCharacters))
				{
					return this;
				}
				this.Pointer++;
			}
			return this;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0001DF04 File Offset: 0x0001C104
		public string ReadUntilWhitespaceOrNewlineOrEnd(string andCharacters = null)
		{
			Parse p = this;
			while (!p.IsEnd && !p.IsNewline && !p.IsWhitespace && !this.IsOneOf(andCharacters))
			{
				p.Pointer++;
			}
			return this.Read(p.Pointer - this.Pointer);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0001DF60 File Offset: 0x0001C160
		public string ReadUntilWhitespaceOrNewlineOrEndAndObeyBrackets()
		{
			Parse p = this;
			int inside = 0;
			for (;;)
			{
				bool lineEnder = p.IsNewline || p.IsWhitespace;
				if (inside > 0)
				{
					lineEnder = false;
				}
				if (p.IsEnd || lineEnder)
				{
					break;
				}
				if (p.Is('(', 0, false))
				{
					inside++;
				}
				if (p.Is(')', 0, false))
				{
					inside--;
				}
				p.Pointer++;
			}
			return this.Read(p.Pointer - this.Pointer);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x0001DFE0 File Offset: 0x0001C1E0
		public string ReadInnerBrackets(char inner = '(', char outer = ')')
		{
			int inside = 0;
			int iStart = this.Pointer;
			while (!this.IsEnd)
			{
				if (this.Is(inner, 0, false))
				{
					if (inside == 0)
					{
						iStart = this.Pointer + 1;
					}
					inside++;
				}
				if (this.Is(outer, 0, false))
				{
					inside--;
					if (inside == 0)
					{
						int iEnd = this.Pointer;
						this.Pointer++;
						return this.Text.Substring(iStart, iEnd - iStart);
					}
				}
				this.Pointer++;
			}
			return null;
		}

		// Token: 0x060003DB RID: 987 RVA: 0x0001E064 File Offset: 0x0001C264
		public string ReadWord(string endOnCharacter = null, bool readUntilEnd = false)
		{
			Parse p = this;
			while (!p.IsEnd || readUntilEnd)
			{
				if (p.IsEnd || p.IsWhitespace || p.IsNewline || p.IsOneOf(endOnCharacter))
				{
					return this.Read(p.Pointer - this.Pointer);
				}
				p.Pointer++;
			}
			return null;
		}

		// Token: 0x060003DC RID: 988 RVA: 0x0001E0CC File Offset: 0x0001C2CC
		public string ReadChars(string chars = null, bool readUntilEnd = false)
		{
			Parse p = this;
			while (!p.IsEnd || readUntilEnd)
			{
				if (p.IsEnd || !p.IsOneOf(chars))
				{
					if (p.Pointer == this.Pointer)
					{
						return null;
					}
					return this.Read(p.Pointer - this.Pointer);
				}
				else
				{
					p.Pointer++;
				}
			}
			return null;
		}

		/// <summary>
		/// Reads a sentence until the next statement divided by ,
		/// Returns the sentence
		/// </summary>
		// Token: 0x060003DD RID: 989 RVA: 0x0001E134 File Offset: 0x0001C334
		public string ReadSentence()
		{
			Parse p = this;
			while (!p.Is(",", 0, false) && !p.IsEnd)
			{
				if (p.Is("(", 0, false))
				{
					while (!p.Is(")", 0, false))
					{
						if (p.IsEnd)
						{
							break;
						}
						p.Pointer++;
					}
				}
				else
				{
					p.Pointer++;
				}
			}
			return this.Read(p.Pointer - this.Pointer);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0001E1BC File Offset: 0x0001C3BC
		public string ReadUntil(string c1)
		{
			Parse p = this;
			while (!p.IsEnd)
			{
				if (p.IsOneOf(c1))
				{
					return this.Read(p.Pointer - this.Pointer);
				}
				p.Pointer++;
			}
			return null;
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0001E208 File Offset: 0x0001C408
		public string ReadUntilOrEnd(string c1, bool acceptNone = false)
		{
			Parse p = this;
			while (!p.IsEnd)
			{
				if (p.IsOneOf(c1))
				{
					if (p.Pointer == this.Pointer)
					{
						return string.Empty;
					}
					return this.Read(p.Pointer - this.Pointer);
				}
				else
				{
					p.Pointer++;
				}
			}
			return this.ReadRemaining(acceptNone);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x0001E26C File Offset: 0x0001C46C
		public ValueTuple<string, string> ReadKeyValue()
		{
			string text = this.ReadUntilOrEnd(":", false);
			if (string.IsNullOrWhiteSpace(text))
			{
				throw new Exception("Expected key " + this.FileAndLine);
			}
			this.Pointer++;
			if (this.IsEnd)
			{
				throw new Exception("Expected value " + this.FileAndLine);
			}
			string value = this.ReadUntilOrEnd(";", false);
			if (string.IsNullOrWhiteSpace(value))
			{
				throw new Exception("Expected value " + this.FileAndLine);
			}
			this.Pointer++;
			return new ValueTuple<string, string>(text.Trim(), value.Trim());
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x0001E318 File Offset: 0x0001C518
		public bool TryReadTime(out float val)
		{
			val = 0f;
			Parse p = this;
			p = p.SkipWhitespaceAndNewlines(null);
			int numStart = p.Pointer;
			while (!p.IsEnd)
			{
				if (p.IsDigit || p.Current == '.')
				{
					p.Pointer++;
				}
				else if (p.Current == 's' || p.Current == 'S')
				{
					int len = p.Pointer - numStart;
					float parsed;
					if (!float.TryParse(p.Text.Substring(numStart, len), NumberStyles.Float, CultureInfo.InvariantCulture, out parsed))
					{
						return false;
					}
					this.Pointer = p.Pointer + 1;
					val = parsed * 1000f;
					return true;
				}
				else
				{
					if (p.Current != 'm' && p.Current != 'M')
					{
						return false;
					}
					if (p.Next != 's' && p.Next == 'S')
					{
						return false;
					}
					int len2 = p.Pointer - numStart;
					float parsed2;
					if (!float.TryParse(p.Text.Substring(numStart, len2), NumberStyles.Float, CultureInfo.InvariantCulture, out parsed2))
					{
						return false;
					}
					this.Pointer = p.Pointer + 2;
					val = parsed2;
					return true;
				}
			}
			return false;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0001E448 File Offset: 0x0001C648
		internal bool TryReadLength(out Length outval)
		{
			outval = 0f;
			Parse p = this;
			if (p.IsEnd)
			{
				return false;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return false;
			}
			string w = p.ReadWord(null, true);
			if (w == null)
			{
				return false;
			}
			Length? v = Sandbox.UI.Length.Parse(w);
			if (v == null)
			{
				return false;
			}
			outval = v.Value;
			this.Pointer = p.Pointer;
			return true;
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x0001E4C8 File Offset: 0x0001C6C8
		public bool TryReadFloat(out float outval)
		{
			outval = 0f;
			Parse p = this;
			if (p.IsEnd)
			{
				return false;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return false;
			}
			string w = p.ReadChars("-0123456789.Ee", true);
			if (w == null)
			{
				return false;
			}
			if (!float.TryParse(w, NumberStyles.Float, CultureInfo.InvariantCulture, out outval))
			{
				return false;
			}
			this.Pointer += w.Length;
			return true;
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0001E540 File Offset: 0x0001C740
		internal bool TryReadColor(out Color outval)
		{
			outval = default(Color);
			Parse p = this;
			if (p.IsEnd)
			{
				return false;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return false;
			}
			int inside = 0;
			int numStart = p.Pointer;
			while (!p.IsEnd)
			{
				if (p.Current == '(')
				{
					inside++;
				}
				if (p.Current == ')')
				{
					inside--;
				}
				if (inside < 0)
				{
					return false;
				}
				if (inside == 0 && p.IsOneOf(" ;\t\n\r,"))
				{
					break;
				}
				p.Pointer++;
			}
			if (numStart == p.Pointer)
			{
				return false;
			}
			Color? color = Color.Parse(p.Text.Substring(numStart, p.Pointer - numStart));
			if (color == null)
			{
				return false;
			}
			this.Pointer = p.Pointer;
			outval = color.Value;
			return true;
		}

		/// <summary>
		/// Return true if the string at the pointer is this
		/// </summary>
		// Token: 0x060003E5 RID: 997 RVA: 0x0001E61C File Offset: 0x0001C81C
		public bool Is(string v, int offset = 0, bool ignorecase = false)
		{
			int len = v.Length;
			for (int i = 0; i < len; i++)
			{
				if (!this.Is(v[i], i, ignorecase))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Skip this string if it exists
		/// </summary>
		// Token: 0x060003E6 RID: 998 RVA: 0x0001E650 File Offset: 0x0001C850
		public bool TrySkip(string v, int offset = 0, bool ignorecase = false)
		{
			int len = v.Length;
			for (int i = 0; i < len; i++)
			{
				if (!this.Is(v[i], i, ignorecase))
				{
					return false;
				}
			}
			this.Pointer += len;
			return true;
		}

		/// <summary>
		/// Return true if the char at the pointer is this
		/// </summary>
		// Token: 0x060003E7 RID: 999 RVA: 0x0001E694 File Offset: 0x0001C894
		public bool Is(char v, int offset = 0, bool ignorecase = false)
		{
			int ptr = this.Pointer + offset;
			if (ptr >= this.Length)
			{
				return false;
			}
			if (ptr < 0)
			{
				return false;
			}
			if (ignorecase)
			{
				return char.ToLowerInvariant(this.Text[ptr]) == char.ToLowerInvariant(v);
			}
			return this.Text[ptr] == v;
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060003E8 RID: 1000 RVA: 0x0001E6E8 File Offset: 0x0001C8E8
		public string FileAndLine
		{
			get
			{
				int lines = this.Text.Substring(0, Math.Min(this.Pointer, this.Text.Length)).Count((char x) => x == '\n');
				return string.Format("[{0}:{1}]", this.FileName, lines);
			}
		}

		// Token: 0x040008C9 RID: 2249
		public string FileName;

		// Token: 0x040008CA RID: 2250
		public string Text;

		// Token: 0x040008CB RID: 2251
		public int Pointer;
	}
}
