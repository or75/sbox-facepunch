using System;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox.Engine
{
	// Token: 0x020002FE RID: 766
	internal static class Keyboard
	{
		// Token: 0x0600146D RID: 5229 RVA: 0x0002BA34 File Offset: 0x00029C34
		internal static void Tick()
		{
			if (Keyboard.Focused == null)
			{
				InputSystem.SetIMEAllowed(false);
				return;
			}
			InputSystem.SetIMEAllowed(true);
			Rect rect = Keyboard.Focused.Rect;
			InputSystem.SetIMETextLocation((int)rect.left, (int)rect.top, (int)rect.width, (int)rect.height);
			Keyboard.Focused = null;
		}

		// Token: 0x04001545 RID: 5445
		public static IPanel Focused;
	}
}
