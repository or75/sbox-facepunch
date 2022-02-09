using System;
using System.Collections.Generic;

namespace Sandbox.Internal
{
	// Token: 0x020002EF RID: 751
	public interface IPanel
	{
		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x060013ED RID: 5101
		IPanel Parent { get; }

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x060013EE RID: 5102
		IEnumerable<IPanel> Children { get; }

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x060013EF RID: 5103
		int ChildrenCount { get; }

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x060013F0 RID: 5104
		string ElementName { get; }

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x060013F1 RID: 5105
		bool IsMainMenu { get; }

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x060013F2 RID: 5106
		bool IsGame { get; }

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x060013F3 RID: 5107
		bool IsVisible { get; }

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x060013F4 RID: 5108
		bool IsVisibleSelf { get; }

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x060013F5 RID: 5109
		bool IsCreatedByTemplate { get; }

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x060013F6 RID: 5110
		string Classes { get; }

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x060013F7 RID: 5111
		Rect Rect { get; }

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x060013F8 RID: 5112
		Rect InnerRect { get; }

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x060013F9 RID: 5113
		Rect OuterRect { get; }

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x060013FA RID: 5114
		Matrix? GlobalMatrix { get; }

		// Token: 0x060013FB RID: 5115
		IPanel GetPanelAt(Vector2 point, bool visibleOnly);

		// Token: 0x060013FC RID: 5116
		bool IsAncestor(IPanel panel);

		// Token: 0x060013FD RID: 5117 RVA: 0x0002AB74 File Offset: 0x00028D74
		internal static List<IPanel> GetAllRootPanels()
		{
			return IPanel.InspectablePanels;
		}

		// Token: 0x04001529 RID: 5417
		internal static List<IPanel> InspectablePanels = new List<IPanel>();
	}
}
