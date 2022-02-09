using System;
using System.Collections.Generic;
using System.Linq;
using NativeEngine;
using Sandbox.Engine;

namespace Sandbox.UI
{
	// Token: 0x02000117 RID: 279
	internal class Input
	{
		/// <summary>
		/// Panel we're currently hovered over
		/// </summary>
		// Token: 0x17000348 RID: 840
		// (get) Token: 0x060015C0 RID: 5568 RVA: 0x000575B7 File Offset: 0x000557B7
		// (set) Token: 0x060015C1 RID: 5569 RVA: 0x000575BF File Offset: 0x000557BF
		public Panel Hovered { get; private set; }

		/// <summary>
		/// Panel we're currently pressing down
		/// </summary>
		// Token: 0x17000349 RID: 841
		// (get) Token: 0x060015C2 RID: 5570 RVA: 0x000575C8 File Offset: 0x000557C8
		// (set) Token: 0x060015C3 RID: 5571 RVA: 0x000575D0 File Offset: 0x000557D0
		public Panel Active { get; private set; }

		// Token: 0x060015C4 RID: 5572 RVA: 0x000575DC File Offset: 0x000557DC
		public Input()
		{
			this.MouseStates = new Input.MouseButtonState[5];
			for (int i = 0; i < 5; i++)
			{
				this.MouseStates[i] = new Input.MouseButtonState(this, ButtonCode.MOUSE_FIRST + i);
			}
		}

		// Token: 0x060015C5 RID: 5573 RVA: 0x00057628 File Offset: 0x00055828
		internal virtual void Tick(IEnumerable<RootPanel> panels)
		{
			bool hoveredAny = false;
			InputData inputData = this.GetInputData();
			if (Mouse.Visible)
			{
				foreach (RootPanel panel in panels)
				{
					if (this.UpdateMouse(panel, inputData))
					{
						hoveredAny = true;
						break;
					}
				}
			}
			if (!hoveredAny)
			{
				this.SetHovered(null);
			}
		}

		// Token: 0x060015C6 RID: 5574 RVA: 0x00057694 File Offset: 0x00055894
		internal virtual InputData GetInputData()
		{
			InputData d = default(InputData);
			d.MousePos = Mouse.Position;
			d.Mouse0 = InputRouter.IsButtonDown(ButtonCode.MOUSE_FIRST);
			d.Mouse1 = InputRouter.IsButtonDown(ButtonCode.MouseMiddle);
			d.Mouse2 = InputRouter.IsButtonDown(ButtonCode.MouseRight);
			d.Mouse3 = InputRouter.IsButtonDown(ButtonCode.MouseBack);
			d.Mouse4 = InputRouter.IsButtonDown(ButtonCode.MouseForward);
			d.MouseWheel = Input.MouseWheelValue;
			Input.MouseWheelValue = 0f;
			return d;
		}

		/// <summary>
		/// The cursor should change. Name could be null, meaning default.
		/// </summary>
		// Token: 0x060015C7 RID: 5575 RVA: 0x00057724 File Offset: 0x00055924
		public virtual void SetCursor(string name)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(name);
			CursorType ct;
			if (num <= 2740943146U)
			{
				if (num <= 407568404U)
				{
					if (num != 240734749U)
					{
						if (num != 381168941U)
						{
							if (num != 407568404U)
							{
								goto IL_17B;
							}
							if (!(name == "move"))
							{
								goto IL_17B;
							}
							ct = CursorType.SizeALL;
							goto IL_1A5;
						}
						else
						{
							if (!(name == "ns-resize"))
							{
								goto IL_17B;
							}
							ct = CursorType.SizeNS;
							goto IL_1A5;
						}
					}
					else if (!(name == "hourglass"))
					{
						goto IL_17B;
					}
				}
				else if (num != 2301512864U)
				{
					if (num != 2485285859U)
					{
						if (num != 2740943146U)
						{
							goto IL_17B;
						}
						if (!(name == "pointer"))
						{
							goto IL_17B;
						}
						goto IL_1A2;
					}
					else
					{
						if (!(name == "ibeam"))
						{
							goto IL_17B;
						}
						goto IL_192;
					}
				}
				else if (!(name == "wait"))
				{
					goto IL_17B;
				}
				ct = CursorType.HourGlass;
				goto IL_1A5;
			}
			if (num <= 3300536096U)
			{
				if (num != 2913447899U)
				{
					if (num != 3185987134U)
					{
						if (num == 3300536096U)
						{
							if (name == "hand")
							{
								goto IL_1A2;
							}
						}
					}
					else if (name == "text")
					{
						goto IL_192;
					}
				}
				else if (name == "none")
				{
					ct = CursorType.None;
					goto IL_1A5;
				}
			}
			else if (num != 3406319174U)
			{
				if (num != 3490291555U)
				{
					if (num == 4288701760U)
					{
						if (name == "ew-resize")
						{
							ct = CursorType.SizeWE;
							goto IL_1A5;
						}
					}
				}
				else if (name == "crosshair")
				{
					ct = CursorType.Crosshair;
					goto IL_1A5;
				}
			}
			else if (name == "progress")
			{
				ct = CursorType.WaitArrow;
				goto IL_1A5;
			}
			IL_17B:
			ct = CursorType.Arrow;
			goto IL_1A5;
			IL_192:
			ct = CursorType.IBeam;
			goto IL_1A5;
			IL_1A2:
			ct = CursorType.Hand;
			IL_1A5:
			if (Mouse.MouseCapture)
			{
				ct = CursorType.None;
			}
			Mouse.CursorType = ct;
		}

		// Token: 0x060015C8 RID: 5576 RVA: 0x000578E8 File Offset: 0x00055AE8
		internal virtual bool UpdateMouse(RootPanel root, InputData data)
		{
			if (!this.UpdateHovered(root, data.MousePos))
			{
				return false;
			}
			bool leftMousePressed = !this.MouseStates[0].Pressed && data.Mouse0;
			bool leftMouseReleased = this.MouseStates[0].Pressed && !data.Mouse0;
			this.MouseStates[0].Update(data.Mouse0, this.Hovered);
			this.MouseStates[1].Update(data.Mouse2, this.Hovered);
			this.MouseStates[2].Update(data.Mouse1, this.Hovered);
			this.MouseStates[3].Update(data.Mouse3, this.Hovered);
			this.MouseStates[4].Update(data.Mouse4, this.Hovered);
			this.Active = null;
			if (this.MouseStates[2].Active != null)
			{
				this.Active = this.MouseStates[2].Active;
			}
			if (this.MouseStates[1].Active != null)
			{
				this.Active = this.MouseStates[1].Active;
			}
			if (this.MouseStates[0].Active != null)
			{
				this.Active = this.MouseStates[0].Active;
			}
			if (this.Hovered != null && data.MouseWheel != 0f)
			{
				this.Hovered.OnMouseWheel(data.MouseWheel);
			}
			this.Selection.UpdateSelection(root, this.Hovered, data.Mouse0, leftMousePressed, leftMouseReleased, data.MousePos);
			return true;
		}

		// Token: 0x060015C9 RID: 5577 RVA: 0x00057A6C File Offset: 0x00055C6C
		private bool UpdateHovered(Panel panel, Vector2 pos)
		{
			Panel current = null;
			if (!this.CheckHover(panel, pos, ref current))
			{
				return false;
			}
			this.SetHovered(current);
			return true;
		}

		// Token: 0x060015CA RID: 5578 RVA: 0x00057A94 File Offset: 0x00055C94
		internal void SetHovered(Panel current)
		{
			if (current != this.Hovered)
			{
				if (this.Hovered != null)
				{
					Panel.Switch(PseudoClass.Hover, false, this.Hovered, current);
					this.Hovered.CreateEvent(new MousePanelEvent("onmouseout", this.Hovered, "none"));
				}
				this.Hovered = current;
				if (this.Hovered != null)
				{
					if (this.Active == null || this.Active == this.Hovered)
					{
						Panel.Switch(PseudoClass.Hover, true, this.Hovered, null);
					}
					this.Hovered.CreateEvent(new MousePanelEvent("onmouseover", this.Hovered, "none"));
				}
			}
			if (this.Hovered != null)
			{
				Styles computedStyle = this.Hovered.ComputedStyle;
				string cursor = ((computedStyle != null) ? computedStyle.Cursor : null);
				this.SetCursor(cursor);
			}
		}

		// Token: 0x060015CB RID: 5579 RVA: 0x00057B60 File Offset: 0x00055D60
		private bool CheckHover(Panel panel, Vector2 pos, ref Panel current)
		{
			bool found = false;
			if (!panel.IsVisible)
			{
				return false;
			}
			if (panel.ComputedStyle == null)
			{
				return false;
			}
			Matrix? matrix;
			pos = ((panel.LocalMatrix != null) ? matrix.GetValueOrDefault().Transform(pos) : pos);
			bool flag = panel.IsInside(pos);
			if (flag && panel.ComputedStyle.PointerEvents != "none")
			{
				current = panel;
				found = true;
			}
			if (!flag)
			{
				Styles computedStyle = panel.ComputedStyle;
				if (((computedStyle != null) ? computedStyle.Overflow : null).GetValueOrDefault() != OverflowMode.Visible)
				{
					return found;
				}
			}
			foreach (Panel child in panel.Children.OrderBy((Panel x) => x.GetRenderOrderIndex()))
			{
				found = this.CheckHover(child, pos, ref current) || found;
			}
			return found;
		}

		// Token: 0x0400055C RID: 1372
		public string LastCursor;

		// Token: 0x0400055D RID: 1373
		public Selection Selection = new Selection();

		// Token: 0x0400055E RID: 1374
		internal static float MouseWheelValue;

		// Token: 0x0400055F RID: 1375
		internal Input.MouseButtonState[] MouseStates;

		// Token: 0x02000279 RID: 633
		internal class MouseButtonState
		{
			// Token: 0x170005C3 RID: 1475
			// (get) Token: 0x06001F10 RID: 7952 RVA: 0x000780B2 File Offset: 0x000762B2
			// (set) Token: 0x06001F11 RID: 7953 RVA: 0x000780BA File Offset: 0x000762BA
			public Input Input { get; set; }

			// Token: 0x170005C4 RID: 1476
			// (get) Token: 0x06001F12 RID: 7954 RVA: 0x000780C3 File Offset: 0x000762C3
			// (set) Token: 0x06001F13 RID: 7955 RVA: 0x000780CB File Offset: 0x000762CB
			public ButtonCode MouseButton { get; set; }

			// Token: 0x06001F14 RID: 7956 RVA: 0x000780D4 File Offset: 0x000762D4
			public MouseButtonState(Input input, ButtonCode i)
			{
				this.Input = input;
				this.MouseButton = i;
			}

			// Token: 0x06001F15 RID: 7957 RVA: 0x000780EA File Offset: 0x000762EA
			public void Update(bool down, Panel hovered)
			{
				if (this.Pressed == down)
				{
					return;
				}
				this.Pressed = down;
				if (down)
				{
					this.OnPressed(hovered);
					return;
				}
				this.OnReleased(hovered);
			}

			// Token: 0x06001F16 RID: 7958 RVA: 0x00078110 File Offset: 0x00076310
			private string GetMouseButtonName(ButtonCode bc)
			{
				if (bc == ButtonCode.MOUSE_FIRST)
				{
					return "mouseleft";
				}
				if (bc == ButtonCode.MouseRight)
				{
					return "mouseright";
				}
				if (bc == ButtonCode.MouseMiddle)
				{
					return "mousemiddle";
				}
				if (bc == ButtonCode.MouseBack)
				{
					return "mouseback";
				}
				if (bc == ButtonCode.MouseForward)
				{
					return "mouseforward";
				}
				return bc.ToString().ToLower();
			}

			// Token: 0x06001F17 RID: 7959 RVA: 0x00078178 File Offset: 0x00076378
			private void OnPressed(Panel hovered)
			{
				if (this.MouseButton == ButtonCode.MouseBack)
				{
					if (hovered != null)
					{
						hovered.CreateEvent(new PanelEvent("onback", hovered));
					}
					return;
				}
				if (this.MouseButton == ButtonCode.MouseForward)
				{
					if (hovered != null)
					{
						hovered.CreateEvent(new PanelEvent("onforward", hovered));
					}
					return;
				}
				this.Active = hovered;
				IClientDll current = IClientDll.Current;
				if (current != null)
				{
					current.RunEvent("ui.closepopups", hovered);
				}
				IMenuDll menuDll = IMenuDll.Current;
				if (menuDll != null)
				{
					menuDll.RunEvent("ui.closepopups", hovered);
				}
				if (this.Active == null)
				{
					return;
				}
				Panel.Switch(PseudoClass.Active, true, this.Active, null);
				if (this.MouseButton >= ButtonCode.MOUSE_FIRST && this.MouseButton <= ButtonCode.MouseRight)
				{
					this.Active.CreateEvent(new MousePanelEvent("onmousedown", this.Active, this.GetMouseButtonName(this.MouseButton)));
				}
				this.Active.Focus();
				this.Active.OnButtonEvent(new ButtonEvent(this.MouseButton, true));
			}

			// Token: 0x06001F18 RID: 7960 RVA: 0x00078278 File Offset: 0x00076478
			private void OnReleased(Panel hovered)
			{
				if (this.MouseButton == ButtonCode.MouseBack || this.MouseButton == ButtonCode.MouseForward)
				{
					return;
				}
				if (hovered == this.Active)
				{
					this.Active.CreateEvent(new MousePanelEvent("onmouseup", this.Active, this.GetMouseButtonName(this.MouseButton)));
					if (this.MouseButton == ButtonCode.MOUSE_FIRST)
					{
						this.Active.CreateEvent(new MousePanelEvent("onclick", this.Active, this.GetMouseButtonName(this.MouseButton)));
					}
					else if (this.MouseButton == ButtonCode.MouseMiddle)
					{
						this.Active.CreateEvent(new MousePanelEvent("onmiddleclick", this.Active, this.GetMouseButtonName(this.MouseButton)));
					}
					else if (this.MouseButton == ButtonCode.MouseRight)
					{
						this.Active.CreateEvent(new MousePanelEvent("onrightclick", this.Active, this.GetMouseButtonName(this.MouseButton)));
					}
				}
				else
				{
					this.Active.CreateEvent(new MousePanelEvent("onmouseup", this.Active, this.GetMouseButtonName(this.MouseButton)));
					Panel.Switch(PseudoClass.Hover, false, this.Active, hovered);
				}
				Panel.Switch(PseudoClass.Active, false, this.Active, null);
				this.Active.OnButtonEvent(new ButtonEvent(this.MouseButton, false));
				this.Active = null;
			}

			// Token: 0x04001274 RID: 4724
			public bool Pressed;

			// Token: 0x04001275 RID: 4725
			public Panel Active;
		}
	}
}
