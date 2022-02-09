using System;
using System.Collections.Generic;

namespace Sandbox.UI
{
	// Token: 0x02000119 RID: 281
	internal class VROverlayInput : Input
	{
		// Token: 0x060015CF RID: 5583 RVA: 0x00057DA0 File Offset: 0x00055FA0
		internal override void Tick(IEnumerable<RootPanel> panels)
		{
			Panel oldHovered = base.Hovered;
			VROverlayPanel focusedOverlayPanel = VROverlay.Focused as VROverlayPanel;
			if (focusedOverlayPanel == null)
			{
				base.SetHovered(null);
				return;
			}
			if (!this.UpdateMouse(focusedOverlayPanel.RootPanel, focusedOverlayPanel.InputData))
			{
				base.SetHovered(null);
			}
			else if (base.Hovered != oldHovered && base.Hovered.HasHovered)
			{
				focusedOverlayPanel.TriggerLaserMouseHapticVibration(0.05f, 1f, 0.2f);
			}
			focusedOverlayPanel.InputData.MouseWheel = 0f;
		}
	}
}
