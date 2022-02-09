using System;
using NativeEngine;
using Sandbox.Engine;

namespace Sandbox
{
	// Token: 0x020000A3 RID: 163
	public static class Vector3Extensions
	{
		// Token: 0x060010DF RID: 4319 RVA: 0x00048D7C File Offset: 0x00046F7C
		public static Vector3 ToScreen(this Vector3 self)
		{
			if (!Host.IsMenu)
			{
				Host.AssertClient("ToScreen");
				Vector3 screen;
				int behind = ClientGlobal.ScreenTransform(self, out screen);
				if (!CurrentView.IsOrtho)
				{
					screen.x = (screen.x + 1f) / 2f;
					screen.y = (screen.y * -1f + 1f) / 2f;
					screen.z = (float)((behind == 1) ? (-1) : 1);
				}
				else
				{
					screen.x = (screen.x + 2f) / 2f;
					screen.y = (screen.y - 2f) / 2f * -1f;
					if (screen.x <= 0f || screen.x >= 1f || screen.y <= 0f || screen.y >= 1f)
					{
						screen.z = -1f;
					}
					else
					{
						screen.z = 1f;
					}
				}
				return screen;
			}
			IClientDll current = IClientDll.Current;
			if (current == null)
			{
				return default(Vector3);
			}
			return current.WorldToScreen(self);
		}
	}
}
