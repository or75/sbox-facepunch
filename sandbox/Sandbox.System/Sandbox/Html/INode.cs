using System;
using System.Collections.Generic;

namespace Sandbox.Html
{
	// Token: 0x02000061 RID: 97
	public interface INode
	{
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x06000442 RID: 1090
		bool IsElement { get; }

		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x06000443 RID: 1091
		bool IsText { get; }

		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x06000444 RID: 1092
		bool IsComment { get; }

		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000445 RID: 1093
		string OuterHtml { get; }

		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000446 RID: 1094
		string InnerHtml { get; }

		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x06000447 RID: 1095
		IEnumerable<INode> Children { get; }

		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x06000448 RID: 1096
		string Name { get; }

		// Token: 0x06000449 RID: 1097
		string GetAttribute(string name, string def = "");

		// Token: 0x0600044A RID: 1098
		int GetAttributeInt(string name, int def = 0);

		// Token: 0x0600044B RID: 1099
		float GetAttributeFloat(string name, float def = 0f);

		// Token: 0x0600044C RID: 1100
		bool GetAttributeBool(string name, bool def = false);

		// Token: 0x0600044D RID: 1101
		T GetAttribute<T>(string name, T def = default(T));
	}
}
