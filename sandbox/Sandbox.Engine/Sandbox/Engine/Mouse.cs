using System;
using System.Linq;
using NativeEngine;

namespace Sandbox.Engine
{
	// Token: 0x020002FF RID: 767
	internal static class Mouse
	{
		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x0600146E RID: 5230 RVA: 0x0002BA89 File Offset: 0x00029C89
		// (set) Token: 0x0600146F RID: 5231 RVA: 0x0002BA90 File Offset: 0x00029C90
		public static Vector2 Position { get; internal set; }

		/// <summary>
		/// When the mouse is captured we can use this to work out the move delta.
		/// </summary>
		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x06001470 RID: 5232 RVA: 0x0002BA98 File Offset: 0x00029C98
		public static Vector2 CapturedMouseDelta
		{
			get
			{
				return Mouse.Position - Mouse.MouseCapturePos;
			}
		}

		// Token: 0x06001471 RID: 5233 RVA: 0x0002BAAC File Offset: 0x00029CAC
		internal static void Tick()
		{
			Mouse.TickVisible(Mouse.wantsMouse.Any((MouseMode x) => x.Visible), Mouse.wantsMouse.Any((MouseMode x) => x.Input));
			bool any_capture = Mouse.wantsMouse.Any((MouseMode x) => x.Capture);
			Mouse.MouseCapture = (!Mouse.wantsMouse[0].Visible || Mouse.wantsMouse[0].Capture) && any_capture;
			GameUIService.SetCursor(Mouse.CursorType);
		}

		/// <summary>
		///
		/// </summary>
		// Token: 0x06001472 RID: 5234 RVA: 0x0002BB78 File Offset: 0x00029D78
		internal static void TickVisible(bool visible, bool input)
		{
			if (Mouse.oldCursorActive == visible)
			{
				return;
			}
			Mouse.oldCursorActive = visible;
			if (!visible)
			{
				Mouse.lastActivePosition = Mouse.Position;
			}
			GameUIService.EnableUIMouse(Mouse.oldCursorActive);
			if (visible && Mouse.lastActivePosition.Length > 0f)
			{
				InputSystem.SetCursorPosition((int)Mouse.lastActivePosition.x, (int)Mouse.lastActivePosition.y, Mouse.lastActiveHwnd);
				Mouse.Position = Mouse.lastActivePosition;
			}
		}

		// Token: 0x06001473 RID: 5235 RVA: 0x0002BBEC File Offset: 0x00029DEC
		internal static void UpdateMousePosition(InputEvent data)
		{
			if (data.EventType != InputEventType.CursorPositionChanged)
			{
				return;
			}
			int x = data.m_nData2;
			int y = data.m_nData3;
			EngineGlobal.Plat_ScreenToWindowCoords(data.m_hWnd, ref x, ref y);
			Mouse.lastActiveHwnd = data.m_hWnd;
			Mouse.Position = new Vector2((float)x, (float)y);
			if (Mouse.MouseCapture)
			{
				InputSystem.SetCursorPosition((int)Mouse.MouseCapturePos.x, (int)Mouse.MouseCapturePos.y, Mouse.lastActiveHwnd);
			}
		}

		/// <summary>
		/// Called by the context
		/// </summary>
		// Token: 0x06001474 RID: 5236 RVA: 0x0002BC60 File Offset: 0x00029E60
		internal static void SetWantsInput(int index, bool visible)
		{
			Mouse.wantsMouse[index].Input = visible;
		}

		// Token: 0x06001475 RID: 5237 RVA: 0x0002BC73 File Offset: 0x00029E73
		internal static void SetWantsVisible(int index, bool visible)
		{
			Mouse.wantsMouse[index].Visible = visible;
		}

		// Token: 0x06001476 RID: 5238 RVA: 0x0002BC86 File Offset: 0x00029E86
		internal static void SetWantsCapture(int index, bool capture)
		{
			Mouse.wantsMouse[index].Capture = capture;
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x06001477 RID: 5239 RVA: 0x0002BC99 File Offset: 0x00029E99
		// (set) Token: 0x06001478 RID: 5240 RVA: 0x0002BCA0 File Offset: 0x00029EA0
		internal static bool MouseCapture
		{
			get
			{
				return Mouse.mousecapture;
			}
			set
			{
				if (Mouse.mousecapture == value)
				{
					return;
				}
				Mouse.mousecapture = value;
				if (Mouse.mousecapture)
				{
					Mouse.MouseCapturePos = Mouse.Position;
				}
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06001479 RID: 5241 RVA: 0x0002BCC2 File Offset: 0x00029EC2
		// (set) Token: 0x0600147A RID: 5242 RVA: 0x0002BCC9 File Offset: 0x00029EC9
		public static CursorType CursorType { get; internal set; }

		// Token: 0x04001547 RID: 5447
		private static Vector2 MouseCapturePos;

		// Token: 0x04001548 RID: 5448
		private static Vector2 lastActivePosition;

		// Token: 0x04001549 RID: 5449
		private static IntPtr lastActiveHwnd;

		// Token: 0x0400154A RID: 5450
		private static bool oldCursorActive;

		// Token: 0x0400154B RID: 5451
		private static MouseMode[] wantsMouse = new MouseMode[2];

		// Token: 0x0400154C RID: 5452
		private static bool mousecapture;
	}
}
