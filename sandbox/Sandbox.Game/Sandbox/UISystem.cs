using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox.Engine;
using Sandbox.Internal;
using Sandbox.UI;

namespace Sandbox
{
	// Token: 0x020000FE RID: 254
	internal static class UISystem
	{
		// Token: 0x1700031A RID: 794
		// (get) Token: 0x060014D3 RID: 5331 RVA: 0x000532CF File Offset: 0x000514CF
		internal static Input Input { get; } = new Input();

		// Token: 0x1700031B RID: 795
		// (get) Token: 0x060014D4 RID: 5332 RVA: 0x000532D6 File Offset: 0x000514D6
		internal static VROverlayInput VROverlayInput { get; } = new VROverlayInput();

		// Token: 0x060014D5 RID: 5333 RVA: 0x000532DD File Offset: 0x000514DD
		internal static void AddRoot(RootPanel rootPanel)
		{
			if (UISystem.RootPanels.Contains(rootPanel))
			{
				throw new Exception("Adding root panel twice");
			}
			UISystem.RootPanels.Add(rootPanel);
		}

		// Token: 0x060014D6 RID: 5334 RVA: 0x00053302 File Offset: 0x00051502
		internal static void RemoveRoot(RootPanel rootPanel)
		{
			UISystem.RootPanels.Remove(rootPanel);
		}

		// Token: 0x060014D7 RID: 5335 RVA: 0x00053310 File Offset: 0x00051510
		internal static void DeleteAllRoots()
		{
			foreach (RootPanel rootPanel in new List<RootPanel>(UISystem.RootPanels))
			{
				rootPanel.Delete(true);
				rootPanel.RemoveFromLists();
				UISystem.RootPanels.Remove(rootPanel);
			}
			UISystem.RunDeferredDeletion(true);
			UISystem.DeletionList.Clear();
		}

		// Token: 0x060014D8 RID: 5336 RVA: 0x0005338C File Offset: 0x0005158C
		internal static void Render()
		{
			Sandbox.Render.SetCombo("D_WORLDPANEL", 0);
			for (int i = UISystem.RootPanels.Count<RootPanel>() - 1; i >= 0; i--)
			{
				if (!UISystem.RootPanels[i].RenderedManually)
				{
					UISystem.RootPanels[i].Render();
				}
			}
		}

		// Token: 0x060014D9 RID: 5337 RVA: 0x000533DD File Offset: 0x000515DD
		internal static void Simulate()
		{
			Screen.UpdateFromEngine();
			UISystem.TickPanels();
			UISystem.TickInput();
			UISystem.PreLayout();
			UISystem.Layout();
			UISystem.PostLayout();
			UISystem.RunDeferredDeletion(false);
		}

		// Token: 0x060014DA RID: 5338 RVA: 0x00053404 File Offset: 0x00051604
		internal static void DirtyAllStyles()
		{
			for (int i = UISystem.RootPanels.Count<RootPanel>() - 1; i >= 0; i--)
			{
				UISystem.RootPanels[i].DirtyStylesRecursive();
			}
		}

		// Token: 0x060014DB RID: 5339 RVA: 0x00053438 File Offset: 0x00051638
		internal static void TickPanels()
		{
			for (int i = 0; i < UISystem.RootPanels.Count<RootPanel>(); i++)
			{
				UISystem.RootPanels[i].TickInternal();
			}
		}

		// Token: 0x060014DC RID: 5340 RVA: 0x0005346C File Offset: 0x0005166C
		internal static void PreLayout()
		{
			float width = Screen.Width;
			float height = Screen.Height;
			Rect rect = SharedRendering.RenderRect;
			Rect screenRect = new Rect(0f, 0f, width, height);
			if (rect.width <= 10f || rect.height <= 10f)
			{
				rect = screenRect;
			}
			for (int i = 0; i < UISystem.RootPanels.Count<RootPanel>(); i++)
			{
				UISystem.RootPanels[i].PreLayout(UISystem.RootPanels[i].FullScreen ? screenRect : rect);
			}
		}

		// Token: 0x060014DD RID: 5341 RVA: 0x00053500 File Offset: 0x00051700
		internal static void Layout()
		{
			for (int i = 0; i < UISystem.RootPanels.Count<RootPanel>(); i++)
			{
				UISystem.RootPanels[i].CalculateLayout();
			}
		}

		// Token: 0x060014DE RID: 5342 RVA: 0x00053534 File Offset: 0x00051734
		internal static void PostLayout()
		{
			for (int i = 0; i < UISystem.RootPanels.Count<RootPanel>(); i++)
			{
				UISystem.RootPanels[i].PostLayout();
			}
		}

		// Token: 0x060014DF RID: 5343 RVA: 0x00053568 File Offset: 0x00051768
		internal static void TickInput()
		{
			Mouse.Visible = UISystem.DoAnyPanelsWantMouseVisible();
			Mouse.Active = UISystem.DoAnyPanelsWantMouseInput();
			Mouse.SetWantsCapture(Host.IsClient ? 0 : 1, Panel.MouseCapture != null);
			InputRouter.NeedsKeyboardInput = InputFocus.Current != null;
			UISystem.Input.Tick(UISystem.RootPanels.Where((RootPanel p) => !p.IsWorldPanel));
			UISystem.VROverlayInput.Tick(null);
			WorldInputInternal.TickAll(UISystem.RootPanels.Where((RootPanel p) => p.IsWorldPanel));
			InputFocus.Tick(UISystem.RootPanels);
			InputEventQueue.TickFocused(InputFocus.Current);
			InputEventQueue.Tick(UISystem.Input.Hovered, UISystem.Input.Active);
			Mouse.Delta = default(Vector2);
			if (InputFocus.Current != null && InputFocus.Current.AcceptsFocus && InputFocus.Current.AcceptsImeInput)
			{
				Keyboard.Focused = InputFocus.Current;
			}
		}

		// Token: 0x060014E0 RID: 5344 RVA: 0x00053680 File Offset: 0x00051880
		private static bool DoAnyPanelsWantMouseVisible()
		{
			for (int i = 0; i < UISystem.RootPanels.Count; i++)
			{
				if (UISystem.RootPanels[i].IsVisible && !UISystem.RootPanels[i].IsWorldPanel && UISystem.RootPanels[i].WantsMouseInput != null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060014E1 RID: 5345 RVA: 0x000536DC File Offset: 0x000518DC
		private static bool DoAnyPanelsWantMouseInput()
		{
			for (int i = 0; i < UISystem.RootPanels.Count<RootPanel>(); i++)
			{
				if (UISystem.RootPanels[i].IsVisible && !UISystem.RootPanels[i].IsWorldPanel && UISystem.RootPanels[i].WantsMouseInput != null && !(UISystem.RootPanels[i].WantsMouseInput.ComputedStyle.PointerEvents != "all"))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// This panel should get deleted at some point
		/// </summary>
		// Token: 0x060014E2 RID: 5346 RVA: 0x0005375D File Offset: 0x0005195D
		internal static void AddDeferredDeletion(Panel panel)
		{
			UISystem.DeletionList.Add(panel);
		}

		/// <summary>
		/// Delete all panels that were deferred and are no longer playing outro transitions
		/// </summary>
		// Token: 0x060014E3 RID: 5347 RVA: 0x0005376C File Offset: 0x0005196C
		internal static void RunDeferredDeletion(bool force = false)
		{
			for (int i = 0; i < UISystem.DeletionList.Count; i++)
			{
				Panel p = UISystem.DeletionList[i];
				if (force || !p.HasActiveTransitions)
				{
					p.Delete(true);
					UISystem.DeletionList.RemoveAt(i);
					i--;
				}
			}
		}

		// Token: 0x060014E4 RID: 5348 RVA: 0x000537BC File Offset: 0x000519BC
		[Event.HotloadAttribute]
		public static void OnHotload()
		{
			for (int i = 0; i < UISystem.RootPanels.Count<RootPanel>(); i++)
			{
				UISystem.RootPanels[i].OnHotloaded();
			}
		}

		// Token: 0x040004DC RID: 1244
		[ThreadStatic]
		internal static PanelRenderer Renderer;

		// Token: 0x040004DF RID: 1247
		internal static List<RootPanel> RootPanels = new List<RootPanel>();

		// Token: 0x040004E0 RID: 1248
		internal static List<Panel> DeletionList = new List<Panel>();
	}
}
