using System;
using System.Diagnostics;
using System.Web;

namespace Sandbox.Html
{
	/// <summary>
	/// Represents an HTML attribute.
	/// </summary>
	// Token: 0x0200005F RID: 95
	[DebuggerDisplay("Name: {Name}, Value: {Value}")]
	internal class Attribute
	{
		// Token: 0x06000422 RID: 1058 RVA: 0x0001F2F6 File Offset: 0x0001D4F6
		internal Attribute(Document ownerdocument)
		{
			this._text = ownerdocument.Text;
		}

		/// <summary>
		/// Gets the qualified name of the attribute.
		/// </summary>
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x0001F30C File Offset: 0x0001D50C
		public string Name
		{
			get
			{
				string result;
				if ((result = this._name) == null)
				{
					result = (this._name = this._text.Substring(this._namestartindex, this._namelength).ToLowerInvariant());
				}
				return result;
			}
		}

		/// <summary>
		/// Gets or sets the value of the attribute.
		/// </summary>
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x06000424 RID: 1060 RVA: 0x0001F348 File Offset: 0x0001D548
		public string Value
		{
			get
			{
				string result;
				if ((result = this._value) == null)
				{
					result = (this._value = this.GetValue());
				}
				return result;
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x0001F36E File Offset: 0x0001D56E
		private string GetValue()
		{
			if (this._valuestartindex <= 0)
			{
				return string.Empty;
			}
			if (this._valuelength <= 0)
			{
				return string.Empty;
			}
			return HttpUtility.HtmlDecode(this._text.Substring(this._valuestartindex, this._valuelength));
		}

		// Token: 0x040008E2 RID: 2274
		internal string _name;

		// Token: 0x040008E3 RID: 2275
		internal int _namelength;

		// Token: 0x040008E4 RID: 2276
		internal int _namestartindex;

		// Token: 0x040008E5 RID: 2277
		internal string _value;

		// Token: 0x040008E6 RID: 2278
		internal int _valuelength;

		// Token: 0x040008E7 RID: 2279
		internal int _valuestartindex;

		// Token: 0x040008E8 RID: 2280
		private string _text;
	}
}
