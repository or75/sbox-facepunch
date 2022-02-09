using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.UI
{
	// Token: 0x0200011B RID: 283
	internal class WorldInputInternal : Input
	{
		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060015E3 RID: 5603 RVA: 0x00057F0D File Offset: 0x0005610D
		// (set) Token: 0x060015E4 RID: 5604 RVA: 0x00057F15 File Offset: 0x00056115
		internal bool Enabled { get; set; } = true;

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060015E5 RID: 5605 RVA: 0x00057F1E File Offset: 0x0005611E
		// (set) Token: 0x060015E6 RID: 5606 RVA: 0x00057F26 File Offset: 0x00056126
		internal Ray Ray { get; set; }

		// Token: 0x060015E7 RID: 5607 RVA: 0x00057F2F File Offset: 0x0005612F
		public WorldInputInternal()
		{
			WorldInputInternal.WorldInputs.Add(new WeakReference<WorldInputInternal>(this, false));
		}

		// Token: 0x060015E8 RID: 5608 RVA: 0x00057F5A File Offset: 0x0005615A
		internal static void Clear()
		{
			WorldInputInternal.WorldInputs.Clear();
		}

		// Token: 0x060015E9 RID: 5609 RVA: 0x00057F68 File Offset: 0x00056168
		internal static void TickAll(IEnumerable<RootPanel> panels)
		{
			for (int i = WorldInputInternal.WorldInputs.Count - 1; i >= 0; i--)
			{
				WorldInputInternal input;
				if (!WorldInputInternal.WorldInputs[i].TryGetTarget(out input))
				{
					WorldInputInternal.WorldInputs.RemoveAt(i);
				}
				else
				{
					input.Tick(panels);
				}
			}
		}

		// Token: 0x060015EA RID: 5610 RVA: 0x00057FB4 File Offset: 0x000561B4
		internal override void Tick(IEnumerable<RootPanel> panels)
		{
			if (!this.Enabled)
			{
				base.SetHovered(null);
				return;
			}
			bool hoveredAny = false;
			InputData inputData = this.GetInputData();
			List<RootPanel> worldPanels = new List<RootPanel>();
			foreach (RootPanel panel in panels.Where((RootPanel p) => p.WantsMouseInput != null))
			{
				if (panel.RayToLocalPosition(this.Ray, out panel.WorldCursor, out panel.WorldDistance))
				{
					worldPanels.Add(panel);
				}
			}
			foreach (RootPanel panel2 in worldPanels.OrderBy((RootPanel x) => x.WorldDistance))
			{
				inputData.MousePos = panel2.WorldCursor;
				if (this.UpdateMouse(panel2, inputData))
				{
					hoveredAny = true;
					break;
				}
			}
			if (!hoveredAny)
			{
				base.SetHovered(null);
			}
			this.SimulateEvents();
		}

		// Token: 0x060015EB RID: 5611 RVA: 0x000580E0 File Offset: 0x000562E0
		internal override InputData GetInputData()
		{
			if (this.UseMouseInput)
			{
				return base.GetInputData();
			}
			return new InputData
			{
				Mouse0 = this.MouseLeftPressed,
				Mouse2 = this.MouseRightPressed,
				MouseWheel = this.MouseScroll
			};
		}

		// Token: 0x060015EC RID: 5612 RVA: 0x0005812C File Offset: 0x0005632C
		internal override bool UpdateMouse(RootPanel root, InputData data)
		{
			this.MouseMovement += this.LastMousePosition - data.MousePos;
			this.LastMousePosition = data.MousePos;
			if (!this.MouseStates[0].Pressed && data.Mouse0)
			{
				if (this.LastClickTimeSince < 0.25f && this.LastClickRoot == root && (this.LastClickPos - data.MousePos).Length < 50f / root.Scale)
				{
					this.DoubleClicks.Enqueue("mouseleft");
				}
				this.LastClickRoot = root;
				this.LastClickPos = data.MousePos;
				this.LastClickTimeSince = 0f;
			}
			return base.UpdateMouse(root, data);
		}

		// Token: 0x060015ED RID: 5613 RVA: 0x00058200 File Offset: 0x00056400
		internal void SimulateEvents()
		{
			int listSize = this.DoubleClicks.Count;
			for (int i = 0; i < listSize; i++)
			{
				string e;
				if (this.DoubleClicks.TryDequeue(out e))
				{
					Panel hovered = base.Hovered;
					if (hovered != null)
					{
						hovered.CreateEvent(new MousePanelEvent("ondoubleclick", base.Hovered, e));
					}
				}
			}
			if (this.MouseMovement != 0.0)
			{
				Panel moveRecv = base.Hovered;
				if (base.Active != null)
				{
					moveRecv = base.Active;
				}
				if (moveRecv != null)
				{
					moveRecv.CreateEvent(new MousePanelEvent("onmousemove", moveRecv, "none"));
				}
				this.MouseMovement = 0.0;
			}
		}

		// Token: 0x04000564 RID: 1380
		internal static List<WeakReference<WorldInputInternal>> WorldInputs = new List<WeakReference<WorldInputInternal>>();

		// Token: 0x04000567 RID: 1383
		internal bool MouseLeftPressed;

		// Token: 0x04000568 RID: 1384
		internal bool MouseRightPressed;

		// Token: 0x04000569 RID: 1385
		internal float MouseScroll;

		// Token: 0x0400056A RID: 1386
		internal bool UseMouseInput;

		// Token: 0x0400056B RID: 1387
		internal Panel LastClickRoot;

		// Token: 0x0400056C RID: 1388
		internal Vector2 LastClickPos;

		// Token: 0x0400056D RID: 1389
		internal RealTimeSince LastClickTimeSince;

		// Token: 0x0400056E RID: 1390
		internal const float MaxAltClickDelta = 50f;

		// Token: 0x0400056F RID: 1391
		internal Queue<string> DoubleClicks = new Queue<string>();

		// Token: 0x04000570 RID: 1392
		internal Vector2 MouseMovement;

		// Token: 0x04000571 RID: 1393
		internal Vector2 LastMousePosition;
	}
}
