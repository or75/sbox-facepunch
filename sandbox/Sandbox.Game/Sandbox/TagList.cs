using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Sandbox.Internal.JsonConvert;

namespace Sandbox
{
	/// <summary>
	/// A wrapped HashSet[string]. A list of strings. Used for custom Entity properties.
	/// </summary>
	// Token: 0x02000086 RID: 134
	[JsonConverter(typeof(TagListConverter))]
	public class TagList : HashSet<string>
	{
		// Token: 0x06000E2D RID: 3629 RVA: 0x00044E51 File Offset: 0x00043051
		public TagList()
			: base(StringComparer.OrdinalIgnoreCase)
		{
		}

		// Token: 0x06000E2E RID: 3630 RVA: 0x00044E60 File Offset: 0x00043060
		public TagList(string tagStr)
			: base(StringComparer.OrdinalIgnoreCase)
		{
			foreach (string tag in tagStr.Split(",", StringSplitOptions.None))
			{
				base.Add(tag);
			}
		}

		// Token: 0x06000E2F RID: 3631 RVA: 0x00044E9F File Offset: 0x0004309F
		public static implicit operator TagList(string value)
		{
			return new TagList(value);
		}

		/// <summary>
		/// Removes or adds a tag based on the second argument.
		/// </summary>
		// Token: 0x06000E30 RID: 3632 RVA: 0x00044EA7 File Offset: 0x000430A7
		public void Set(string tag, bool on)
		{
			if (on)
			{
				base.Add(tag);
				return;
			}
			base.Remove(tag);
		}

		/// <summary>
		/// Removes a tag if it exists, adds it overwise.
		/// </summary>
		// Token: 0x06000E31 RID: 3633 RVA: 0x00044EBD File Offset: 0x000430BD
		public void Toggle(string tag)
		{
			if (base.Contains(tag))
			{
				base.Remove(tag);
				return;
			}
			base.Add(tag);
		}
	}
}
