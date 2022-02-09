using System;
using System.Collections.Generic;
using NativeEngine;

namespace Sandbox.UI
{
	/// <summary>
	/// Queue input events on here to be processed by the UISystem.
	/// </summary>
	// Token: 0x0200011E RID: 286
	internal static class InputEventQueue
	{
		// Token: 0x060015FD RID: 5629 RVA: 0x000584A8 File Offset: 0x000566A8
		internal static string NormalizeButtonName(string button)
		{
			button = button.ToLowerInvariant();
			if (button.StartsWith("key_"))
			{
				string text = button;
				int length = text.Length;
				int num = 4;
				int length2 = length - num;
				button = text.Substring(num, length2);
			}
			return button;
		}

		// Token: 0x060015FE RID: 5630 RVA: 0x000584E0 File Offset: 0x000566E0
		internal static void TickFocused(Panel focused)
		{
			int listSize = InputEventQueue.ButtonEvents.Count;
			for (int i = 0; i < listSize; i++)
			{
				ButtonEvent e;
				if (InputEventQueue.ButtonEvents.TryDequeue(out e) && focused != null)
				{
					focused.OnButtonEvent(e);
				}
			}
			listSize = InputEventQueue.KeyTyped.Count;
			for (int j = 0; j < listSize; j++)
			{
				char e2;
				if (InputEventQueue.KeyTyped.TryDequeue(out e2) && focused != null)
				{
					focused.OnKeyTyped(e2);
				}
			}
			listSize = InputEventQueue.ButtonTyped.Count;
			for (int k = 0; k < listSize; k++)
			{
				Tuple<string, KeyModifiers> e3;
				if (InputEventQueue.ButtonTyped.TryDequeue(out e3) && focused != null)
				{
					focused.OnButtonTyped(e3.Item1, e3.Item2);
				}
			}
		}

		// Token: 0x060015FF RID: 5631 RVA: 0x0005858C File Offset: 0x0005678C
		internal static void Tick(Panel hovered, Panel active)
		{
			if (InputEventQueue.MouseMovement != 0.0)
			{
				Panel moveRecv = hovered;
				if (active != null)
				{
					moveRecv = active;
				}
				if (moveRecv != null)
				{
					moveRecv.CreateEvent(new MousePanelEvent("onmousemove", moveRecv, "none"));
				}
				InputEventQueue.MouseMovement = 0.0;
			}
			int listSize = InputEventQueue.DoubleClicks.Count;
			for (int i = 0; i < listSize; i++)
			{
				string e;
				if (InputEventQueue.DoubleClicks.TryDequeue(out e) && hovered != null)
				{
					hovered.CreateEvent(new MousePanelEvent("ondoubleclick", hovered, e));
				}
			}
		}

		// Token: 0x06001600 RID: 5632 RVA: 0x00058620 File Offset: 0x00056820
		internal static void AddDoubleClick(string button)
		{
			button = InputEventQueue.NormalizeButtonName(button);
			InputEventQueue.DoubleClicks.Enqueue(button);
		}

		// Token: 0x06001601 RID: 5633 RVA: 0x00058638 File Offset: 0x00056838
		internal static void AddButtonEvent(string button, bool down)
		{
			button = InputEventQueue.NormalizeButtonName(button);
			ButtonEvent e = new ButtonEvent(button, down);
			InputEventQueue.ButtonEvents.Enqueue(e);
		}

		// Token: 0x06001602 RID: 5634 RVA: 0x00058660 File Offset: 0x00056860
		internal static void AddKeyTyped(char c)
		{
			InputEventQueue.KeyTyped.Enqueue(c);
		}

		// Token: 0x06001603 RID: 5635 RVA: 0x00058670 File Offset: 0x00056870
		internal static void AddButtonTyped(ButtonCode b, KeyModifiers km)
		{
			string buttonName = b.ToString().ToLower().Replace("key_", "");
			InputEventQueue.ButtonTyped.Enqueue(new Tuple<string, KeyModifiers>(buttonName, km));
		}

		// Token: 0x06001604 RID: 5636 RVA: 0x000586B0 File Offset: 0x000568B0
		internal static void MouseMoved(Vector2 delta)
		{
			InputEventQueue.MouseMovement += delta;
		}

		// Token: 0x0400057B RID: 1403
		private static Queue<ButtonEvent> ButtonEvents = new Queue<ButtonEvent>();

		// Token: 0x0400057C RID: 1404
		private static Queue<string> DoubleClicks = new Queue<string>();

		// Token: 0x0400057D RID: 1405
		private static Queue<Tuple<string, KeyModifiers>> ButtonTyped = new Queue<Tuple<string, KeyModifiers>>();

		// Token: 0x0400057E RID: 1406
		private static Queue<char> KeyTyped = new Queue<char>();

		// Token: 0x0400057F RID: 1407
		private static Vector2 MouseMovement;
	}
}
