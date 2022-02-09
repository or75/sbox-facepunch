using System;
using System.Collections.Generic;

namespace Sandbox.UI
{
	// Token: 0x0200011F RID: 287
	public class InputFocus
	{
		// Token: 0x17000358 RID: 856
		// (get) Token: 0x06001606 RID: 5638 RVA: 0x000586EC File Offset: 0x000568EC
		// (set) Token: 0x06001607 RID: 5639 RVA: 0x000586F3 File Offset: 0x000568F3
		public static Panel Current { get; internal set; }

		// Token: 0x17000359 RID: 857
		// (get) Token: 0x06001608 RID: 5640 RVA: 0x000586FB File Offset: 0x000568FB
		// (set) Token: 0x06001609 RID: 5641 RVA: 0x00058702 File Offset: 0x00056902
		public static Panel Next { get; internal set; }

		// Token: 0x1700035A RID: 858
		// (get) Token: 0x0600160A RID: 5642 RVA: 0x0005870A File Offset: 0x0005690A
		// (set) Token: 0x0600160B RID: 5643 RVA: 0x00058711 File Offset: 0x00056911
		private static bool PendingChange { get; set; }

		/// <summary>
		/// Set the focus to this panel (or its nearest ancestor with AcceptsFocus).
		/// Note that Current won't change until the next frame.
		/// </summary>
		// Token: 0x0600160C RID: 5644 RVA: 0x00058719 File Offset: 0x00056919
		public static bool Set(Panel panel)
		{
			return InputFocus.TrySetOrParent(panel);
		}

		/// <summary>
		/// Clear focus away from this panel.
		/// </summary>
		// Token: 0x0600160D RID: 5645 RVA: 0x00058721 File Offset: 0x00056921
		public static bool Clear(Panel panel)
		{
			InputFocus.Next = null;
			InputFocus.PendingChange = true;
			return true;
		}

		// Token: 0x0600160E RID: 5646 RVA: 0x00058730 File Offset: 0x00056930
		private static bool TrySetOrParent(Panel panel)
		{
			if (panel == null)
			{
				return false;
			}
			if (InputFocus.Next == panel)
			{
				return true;
			}
			if (panel.AcceptsFocus)
			{
				InputFocus.Next = panel;
				InputFocus.PendingChange = true;
				return true;
			}
			return InputFocus.TrySetOrParent(panel.Parent);
		}

		// Token: 0x0600160F RID: 5647 RVA: 0x00058764 File Offset: 0x00056964
		internal static void Tick(IEnumerable<RootPanel> rootPanels)
		{
			if (InputFocus.Current != null && !InputFocus.IsPanelEligibleForFocus(InputFocus.Current) && (!InputFocus.PendingChange || InputFocus.Next == InputFocus.Current))
			{
				InputFocus.Next = null;
				InputFocus.PendingChange = true;
			}
			if (InputFocus.PendingChange && InputFocus.Next != null && !InputFocus.Next.AcceptsFocus)
			{
				InputFocus.Next = null;
				InputFocus.PendingChange = false;
			}
			if (InputFocus.PendingChange)
			{
				InputFocus.PendingChange = false;
				if (InputFocus.Current != InputFocus.Next)
				{
					if (InputFocus.Current != null)
					{
						Panel.Switch(PseudoClass.Focus, false, InputFocus.Current, InputFocus.Next);
						InputFocus.Current.CreateEvent(new PanelEvent("onblur", InputFocus.Current));
					}
					InputFocus.Current = InputFocus.Next;
					Panel.Switch(PseudoClass.Focus, true, InputFocus.Current, null);
					Panel panel = InputFocus.Current;
					if (panel != null)
					{
						panel.CreateEvent(new PanelEvent("onfocus", InputFocus.Current));
					}
				}
			}
			InputFocus.Next = null;
		}

		// Token: 0x06001610 RID: 5648 RVA: 0x00058851 File Offset: 0x00056A51
		private static bool IsPanelEligibleForFocus(Panel panel)
		{
			return panel.IsVisible && panel.AcceptsFocus;
		}
	}
}
