using System;
using Sandbox.Engine;

namespace Sandbox
{
	// Token: 0x02000100 RID: 256
	public static class Mouse
	{
		// Token: 0x1700031C RID: 796
		// (get) Token: 0x060014F6 RID: 5366 RVA: 0x00053AEF File Offset: 0x00051CEF
		// (set) Token: 0x060014F7 RID: 5367 RVA: 0x00053AF6 File Offset: 0x00051CF6
		public static Vector2 Position { get; internal set; }

		// Token: 0x1700031D RID: 797
		// (get) Token: 0x060014F8 RID: 5368 RVA: 0x00053AFE File Offset: 0x00051CFE
		// (set) Token: 0x060014F9 RID: 5369 RVA: 0x00053B05 File Offset: 0x00051D05
		public static Vector2 Delta { get; internal set; }

		// Token: 0x1700031E RID: 798
		// (get) Token: 0x060014FA RID: 5370 RVA: 0x00053B0D File Offset: 0x00051D0D
		// (set) Token: 0x060014FB RID: 5371 RVA: 0x00053B14 File Offset: 0x00051D14
		public static bool Active
		{
			get
			{
				return Mouse.active;
			}
			internal set
			{
				if (Mouse.active == value)
				{
					return;
				}
				Mouse.active = value;
				Mouse.SetWantsInput(Host.IsClient ? 0 : 1, Mouse.active);
				if (!Mouse.active)
				{
					InputRouter.ClearMouseButtons();
				}
			}
		}

		// Token: 0x1700031F RID: 799
		// (get) Token: 0x060014FC RID: 5372 RVA: 0x00053B46 File Offset: 0x00051D46
		// (set) Token: 0x060014FD RID: 5373 RVA: 0x00053B4D File Offset: 0x00051D4D
		public static bool Visible
		{
			get
			{
				return Mouse.visible;
			}
			internal set
			{
				if (Mouse.visible == value)
				{
					return;
				}
				Mouse.visible = value;
				Mouse.SetWantsVisible(Host.IsClient ? 0 : 1, Mouse.visible);
				if (!Mouse.active)
				{
					InputRouter.ClearMouseButtons();
				}
			}
		}

		// Token: 0x040004E4 RID: 1252
		private static bool active;

		// Token: 0x040004E5 RID: 1253
		private static bool visible;
	}
}
