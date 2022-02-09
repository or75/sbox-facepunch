using System;
using System.Collections.Generic;
using NativeEngine;
using Sandbox.Engine;
using Sandbox.UI;

namespace Sandbox
{
	// Token: 0x02000070 RID: 112
	internal static class InputRouter
	{
		// Token: 0x06000C5D RID: 3165 RVA: 0x0003F90F File Offset: 0x0003DB0F
		public static void ClearMouseButtons()
		{
			InputRouter.PressedButtons.RemoveAll((ButtonCode x) => InputRouter.IsMouseButton(x));
		}

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x06000C5E RID: 3166 RVA: 0x0003F93B File Offset: 0x0003DB3B
		// (set) Token: 0x06000C5F RID: 3167 RVA: 0x0003F942 File Offset: 0x0003DB42
		public static bool NeedsKeyboardInput
		{
			get
			{
				return InputRouter._needsKeyboardInput;
			}
			internal set
			{
				if (InputRouter._needsKeyboardInput == value)
				{
					return;
				}
				InputRouter._needsKeyboardInput = value;
				if (!InputRouter._needsKeyboardInput)
				{
					InputRouter.ReleaseButtons(true, false);
				}
			}
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x0003F964 File Offset: 0x0003DB64
		internal static bool HandleInputEvent(InputEvent data)
		{
			InputEventType eventType = data.EventType;
			switch (eventType)
			{
			case InputEventType.ButtonPressed:
			case InputEventType.ButtonReleased:
				if (InputRouter.IsGameButton((ButtonCode)data.m_nData))
				{
					return false;
				}
				if ((int)data.m_nData == 58)
				{
					IToolsDll toolsDll = IToolsDll.Current;
					if (toolsDll != null && toolsDll.ConsoleFocus())
					{
						return true;
					}
					if (data.EventType == InputEventType.ButtonPressed)
					{
						ConsoleSystem.Run("con_toggle");
					}
					return true;
				}
				else
				{
					if (InputRouter.IsMouseButton((ButtonCode)data.m_nData))
					{
						InputRouter.AltClickDelta = InputRouter.LastClickPos - Mouse.Position;
						InputRouter.LastClickPos = Mouse.Position;
						return InputRouter.OnMouseButton((ButtonCode)data.m_nData, data.EventType == InputEventType.ButtonPressed);
					}
					InputRouter.OnButton((ButtonCode)data.m_nData, data.EventType == InputEventType.ButtonPressed);
					return InputRouter.NeedsKeyboardInput;
				}
				break;
			case InputEventType.ButtonDoubleClick:
				if (Mouse.Active && InputRouter.AltClickDelta.Length < 10f)
				{
					InputEventQueue.AddDoubleClick(((ButtonCode)data.m_nData).ToString());
				}
				return Mouse.Active;
			case InputEventType.IE_AnalogValueChanged:
				return (data.m_nData == 2UL && Mouse.Active) || InputRouter.NeedsKeyboardInput;
			case InputEventType.IE_ButtonPressedRepeating:
				break;
			case InputEventType.CursorPositionChanged:
				return InputRouter.CursorPositionChanged(data.m_nData2, data.m_nData3, (int)(data.m_nData & (ulong)(-1)), (int)(data.m_nData >> 32));
			default:
				switch (eventType)
				{
				case InputEventType.KeyTyped:
					if (InputRouter.NeedsKeyboardInput)
					{
						InputEventQueue.AddKeyTyped((char)data.m_nData);
						return true;
					}
					return false;
				case InputEventType.KeyCodeTyped:
					if (InputRouter.IsGameButton((ButtonCode)data.m_nData))
					{
						return false;
					}
					if (InputRouter.NeedsKeyboardInput)
					{
						InputEventQueue.AddButtonTyped((ButtonCode)data.m_nData, new KeyModifiers(data.m_nData2));
						return true;
					}
					return false;
				case InputEventType.IE_IMEStartComposition:
				{
					if (!InputRouter.NeedsKeyboardInput)
					{
						return false;
					}
					Panel panel = InputFocus.Current;
					if (panel != null)
					{
						panel.CreateEvent("onimestart", null, null);
					}
					return true;
				}
				case InputEventType.IE_IMEComposition:
				{
					if (!InputRouter.NeedsKeyboardInput)
					{
						return false;
					}
					int mode = (int)data.m_nData;
					if ((mode & 2048) == 2048)
					{
						string str = InputSystem.GetIMEComposition(2048);
						if (str == null)
						{
							return false;
						}
						Panel panel2 = InputFocus.Current;
						if (panel2 != null)
						{
							panel2.CreateEvent("onime", str, null);
						}
					}
					if ((mode & 8) == 8)
					{
						string str2 = InputSystem.GetIMEComposition(8);
						if (str2 == null)
						{
							return false;
						}
						Panel panel3 = InputFocus.Current;
						if (panel3 != null)
						{
							panel3.CreateEvent("onime", str2, null);
						}
					}
					return true;
				}
				case InputEventType.IE_IMEEndComposition:
				{
					if (!InputRouter.NeedsKeyboardInput)
					{
						return false;
					}
					Panel panel4 = InputFocus.Current;
					if (panel4 != null)
					{
						panel4.CreateEvent("onimeend", null, null);
					}
					return true;
				}
				}
				break;
			}
			return InputRouter.NeedsKeyboardInput;
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x0003FC08 File Offset: 0x0003DE08
		private static bool CursorPositionChanged(int x, int y, int dx, int dy)
		{
			Mouse.Position = Mouse.Position;
			Mouse.Delta = new Vector2((float)dx, (float)dy);
			if (Mouse.MouseCapture)
			{
				Mouse.Delta = Mouse.CapturedMouseDelta;
			}
			if (Mouse.Delta != Vector2.Zero)
			{
				InputEventQueue.MouseMoved(Mouse.Delta);
			}
			return Mouse.Active;
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x0003FC60 File Offset: 0x0003DE60
		private static bool OnMouseButton(ButtonCode button, bool down)
		{
			if (!InputRouter.ShouldAcceptMouseButtons())
			{
				return false;
			}
			if (button == ButtonCode.MouseWheelDown)
			{
				if (down)
				{
					Input.MouseWheelValue += 1f;
				}
				return true;
			}
			if (button == ButtonCode.MouseWheelUp)
			{
				if (down)
				{
					Input.MouseWheelValue -= 1f;
				}
				return true;
			}
			if (InputRouter.PressedButtons.Contains(button) == down)
			{
				return true;
			}
			if (down)
			{
				InputRouter.PressedButtons.Add(button);
			}
			else
			{
				InputRouter.PressedButtons.Remove(button);
			}
			return true;
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x0003FCDD File Offset: 0x0003DEDD
		private static bool ShouldAcceptMouseButtons()
		{
			return Mouse.Visible && ((UISystem.Input.Hovered != null && UISystem.Input.Hovered.ComputedStyle.PointerEvents == "auto") || Mouse.Active);
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x0003FD1C File Offset: 0x0003DF1C
		private static bool OnButton(ButtonCode button, bool down)
		{
			if (!InputRouter.NeedsKeyboardInput)
			{
				return false;
			}
			if (InputRouter.PressedButtons.Contains(button) == down)
			{
				return true;
			}
			if (down)
			{
				InputRouter.PressedButtons.Add(button);
			}
			else
			{
				InputRouter.PressedButtons.Remove(button);
			}
			InputEventQueue.AddButtonEvent(button.ToString(), down);
			return true;
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x0003FD74 File Offset: 0x0003DF74
		private static void ReleaseButtons(bool keys, bool mouse)
		{
			foreach (ButtonCode button in InputRouter.PressedButtons.ToArray())
			{
				bool isMouse = InputRouter.IsMouseButton(button);
				if ((!isMouse || mouse) && (isMouse || keys))
				{
					if (!isMouse)
					{
						InputEventQueue.AddButtonEvent(button.ToString(), false);
					}
					InputRouter.PressedButtons.Remove(button);
				}
			}
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x0003FDD3 File Offset: 0x0003DFD3
		public static bool IsButtonDown(ButtonCode btton)
		{
			return InputRouter.PressedButtons.Contains(btton);
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x0003FDE0 File Offset: 0x0003DFE0
		private static bool IsMouseButton(ButtonCode btton)
		{
			return btton >= ButtonCode.MOUSE_FIRST && btton <= ButtonCode.MouseWheelDown;
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x0003FDF7 File Offset: 0x0003DFF7
		private static bool IsGameButton(ButtonCode btton)
		{
			return btton >= ButtonCode.KEY_F1 && btton <= ButtonCode.KEY_F12;
		}

		// Token: 0x040001A8 RID: 424
		internal static Vector2 LastClickPos;

		// Token: 0x040001A9 RID: 425
		internal static Vector2 AltClickDelta;

		// Token: 0x040001AA RID: 426
		public static List<ButtonCode> PressedButtons = new List<ButtonCode>();

		// Token: 0x040001AB RID: 427
		private static bool _needsKeyboardInput;
	}
}
