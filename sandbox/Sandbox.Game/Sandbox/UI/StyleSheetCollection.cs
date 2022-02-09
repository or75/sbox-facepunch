using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Sandbox.UI
{
	// Token: 0x0200014A RID: 330
	public struct StyleSheetCollection
	{
		// Token: 0x060018F7 RID: 6391 RVA: 0x00068B82 File Offset: 0x00066D82
		internal StyleSheetCollection(Panel owner)
		{
			this = default(StyleSheetCollection);
			this.Owner = owner;
		}

		/// <summary>
		/// Add a stylesheet directly
		/// </summary>
		// Token: 0x060018F8 RID: 6392 RVA: 0x00068B92 File Offset: 0x00066D92
		public void Add(StyleSheet sheet)
		{
			if (sheet == null)
			{
				return;
			}
			if (this.List == null)
			{
				this.List = new List<StyleSheet>();
			}
			else if (this.List.Contains(sheet))
			{
				return;
			}
			this.List.Insert(0, sheet);
		}

		/// <summary>
		/// Load the stylesheet from a file
		/// </summary>
		// Token: 0x060018F9 RID: 6393 RVA: 0x00068BC9 File Offset: 0x00066DC9
		public void Load(string filename, bool inheritVariables = true)
		{
			this.Add(StyleSheet.FromFile(filename, inheritVariables ? this.CollectVariables() : null));
		}

		/// <summary>
		/// Load the stylesheet from a string
		/// </summary>
		// Token: 0x060018FA RID: 6394 RVA: 0x00068BE3 File Offset: 0x00066DE3
		public void Parse(string stylesheet, bool inheritVariables = true)
		{
			this.Add(StyleSheet.FromString(stylesheet, "string", inheritVariables ? this.CollectVariables() : null, false));
		}

		// Token: 0x060018FB RID: 6395 RVA: 0x00068C03 File Offset: 0x00066E03
		public void Remove(StyleSheet sheet)
		{
			if (this.List == null)
			{
				return;
			}
			this.List.Remove(sheet);
		}

		// Token: 0x060018FC RID: 6396 RVA: 0x00068C1B File Offset: 0x00066E1B
		[return: TupleElementNames(new string[] { "key", "value" })]
		public IEnumerable<ValueTuple<string, string>> CollectVariables()
		{
			if (this.Owner != null)
			{
				foreach (StyleSheet sheet in this.Owner.AllStyleSheets)
				{
					if (sheet.Variables != null)
					{
						foreach (KeyValuePair<string, string> v in sheet.Variables)
						{
							yield return new ValueTuple<string, string>(v.Key, v.Value);
						}
						Dictionary<string, string>.Enumerator enumerator2 = default(Dictionary<string, string>.Enumerator);
					}
				}
				IEnumerator<StyleSheet> enumerator = null;
			}
			yield break;
			yield break;
		}

		// Token: 0x040006D5 RID: 1749
		internal List<StyleSheet> List;

		// Token: 0x040006D6 RID: 1750
		internal Panel Owner;
	}
}
