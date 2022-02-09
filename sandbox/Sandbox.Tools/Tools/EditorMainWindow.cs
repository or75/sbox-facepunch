using System;
using System.Collections.Generic;
using NativeEngine;
using Sandbox;
using Sandbox.Engine;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x0200007A RID: 122
	public class EditorMainWindow : Window
	{
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060012E8 RID: 4840 RVA: 0x00051B90 File Offset: 0x0004FD90
		// (set) Token: 0x060012E9 RID: 4841 RVA: 0x00051B98 File Offset: 0x0004FD98
		public Menu ToolsMenu { get; set; }

		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060012EA RID: 4842 RVA: 0x00051BA1 File Offset: 0x0004FDA1
		// (set) Token: 0x060012EB RID: 4843 RVA: 0x00051BA9 File Offset: 0x0004FDA9
		public Menu ViewsMenu { get; set; }

		// Token: 0x060012EC RID: 4844 RVA: 0x00051BB4 File Offset: 0x0004FDB4
		internal EditorMainWindow()
			: base(null)
		{
			base.Enabled = false;
			base.Title = "s&box editor";
			base.Canvas = new Frame(this);
			base.Canvas.MaximumSize = new Vector2(10000f, 0f);
			Menu menu = this.MenuBar.AddMenu("File");
			menu.AddOption("Open Visual Studio", null, delegate()
			{
				CodeEditor.OpenAddonSolution();
			}, "Ctrl+P");
			menu.AddSeparator();
			menu.AddOption("Quit", null, delegate()
			{
				HostStateMgr.RequestHS_Quit();
			}, "Ctrl+Q");
			this.MenuBar.AddMenu("Edit").AddOption("Nothing", null, null, null);
			this.ToolsMenu = this.MenuBar.AddMenu("Tools");
			this.ViewsMenu = this.MenuBar.AddMenu("View");
			this.MenuBar.AddMenu("Help").AddOption("Recreate Window", "", new Action(EditorMainWindow.Startup), null);
			this.ToolsBar = new ToolBar(this, "ToolsToolbar");
			base.AddToolBar(this.ToolsBar, ToolbarPosition.Top);
			this.ViewsMenu.AddOption("Restore Default Layout", null, new Action(this.DefaultLayout), null);
			this.ViewsMenu.AddSeparator();
			this.ConsoleWidget = new ConsoleWidget(this);
			DockWidget consoleDock = this.AddDock("Console", "text_snippet", DockArea.Bottom, this.ConsoleWidget);
			this.ViewsMenu.AddOption(consoleDock.GetToggleViewOption());
			this.GameDock = this.AddDock("Game", "smart_display", DockArea.Top, new GameFrame(this));
			this.ViewsMenu.AddOption(this.GameDock.GetToggleViewOption());
			GlobalToolsNamespace.EditorWindow = this;
			Event.Run<EditorMainWindow>("editor.created", this);
			DockWidget dockWidget = base.FindOrCreateDock("Inspector", "manage_search", DockArea.Right, null);
			dockWidget.MinimumSize = 300.0;
			dockWidget.Show();
			DockWidget dockWidget2 = base.FindOrCreateDock("Entity List", "emoji_objects", DockArea.Left, null);
			dockWidget2.MinimumSize = 300.0;
			dockWidget2.Show();
			DockWidget dockWidget3 = base.FindOrCreateDock("Addon Manager", "snippet_folder", DockArea.Left, "Entity List");
			dockWidget3.MinimumSize = 300.0;
			dockWidget3.Show();
			this.defaultState = base.SaveState(0);
			base.StateCookie = "SboxEditor";
			MenuAttribute.RegisterMenuBar("Editor", this.MenuBar);
			DockAttribute.RegisterWindow("Editor", this);
			this.RebuildTools();
			base.MakeMaximized();
		}

		// Token: 0x060012ED RID: 4845 RVA: 0x00051E82 File Offset: 0x00050082
		private void DefaultLayout()
		{
			base.RestoreState(this.defaultState);
		}

		// Token: 0x060012EE RID: 4846 RVA: 0x00051E90 File Offset: 0x00050090
		internal void ConsoleFocus()
		{
			this.ConsoleWidget.Input.Focus(true);
		}

		// Token: 0x060012EF RID: 4847 RVA: 0x00051EA4 File Offset: 0x000500A4
		private DockWidget AddDock(string title, string icon, DockArea area, Widget widget)
		{
			DockWidget dock = new DockWidget(title, icon, this, null);
			dock.Name = title + "DockWidget";
			dock.Widget = widget;
			base.Dock(dock, area, null);
			this.Docked[title] = dock;
			return dock;
		}

		// Token: 0x060012F0 RID: 4848 RVA: 0x00051EEB File Offset: 0x000500EB
		public override void OnClose(CloseEvent e)
		{
			if (GlobalToolsNamespace.EditorWindow == this)
			{
				HostStateMgr.RequestHS_Quit();
			}
			e.Ignore();
		}

		/// <summary>
		/// Called once to create the editor
		/// </summary>
		// Token: 0x060012F1 RID: 4849 RVA: 0x00051F01 File Offset: 0x00050101
		internal static void Startup()
		{
			EditorMainWindow editorWindow = GlobalToolsNamespace.EditorWindow;
			EditorMainWindow editorMainWindow = new EditorMainWindow();
			editorMainWindow.Size = new Vector2(1920f, 1080f);
			editorMainWindow.MakeMaximized();
			editorMainWindow.RestoreFromStateCookie();
			editorMainWindow.Show();
			if (editorWindow == null)
			{
				return;
			}
			editorWindow.Destroy();
		}

		// Token: 0x060012F2 RID: 4850 RVA: 0x00051F40 File Offset: 0x00050140
		[Event("tools.refresh")]
		private void RebuildTools()
		{
			ToolBar toolsBar = this.ToolsBar;
			if (toolsBar != null)
			{
				toolsBar.Clear();
			}
			Menu toolsMenu = this.ToolsMenu;
			if (toolsMenu != null)
			{
				toolsMenu.Clear();
			}
			using (IEnumerator<EngineTools.ToolDescription> enumerator = EngineTools.All.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					EngineTools.ToolDescription tool = enumerator.Current;
					Option option = this.ToolsBar.AddOption(tool.Name, tool.Icon, delegate()
					{
						EngineTools.ShowTool(tool.Name);
					});
					option.StatusText = tool.Description;
					option.Tooltip = tool.Name + " - " + tool.Description;
					Option option2 = this.ToolsMenu.AddOption(tool.Name, tool.Icon, delegate()
					{
						EngineTools.ShowTool(tool.Name);
					}, null);
					option2.StatusText = tool.Description;
					option2.Tooltip = tool.Name + " - " + tool.Description;
				}
			}
			this.ToolsBar.AddSeparator();
			this.ToolsMenu.AddSeparator();
			using (List<ToolAttribute>.Enumerator enumerator2 = ToolAttribute.All.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					ToolAttribute tool = enumerator2.Current;
					Option option3 = this.ToolsBar.AddOption(tool.Title, tool.Icon, delegate()
					{
						tool.Open();
					});
					option3.StatusText = tool.Description;
					option3.Tooltip = tool.Title + " - " + tool.Description;
					Option option4 = this.ToolsMenu.AddOption(tool.Title, tool.Icon, delegate()
					{
						tool.Open();
					}, null);
					option4.StatusText = tool.Description;
					option4.Tooltip = tool.Title + " - " + tool.Description;
				}
			}
		}

		// Token: 0x060012F3 RID: 4851 RVA: 0x000521AC File Offset: 0x000503AC
		[Event.FrameAttribute]
		public void Frame()
		{
			bool wantsFull = GameFrame.Singleton.FullScreen.IsChecked && !this.ConsoleWidget.Input.IsFocused;
			if (this.isFull == wantsFull)
			{
				return;
			}
			this.isFull = wantsFull;
			if (this.isFull)
			{
				GameFrame.Singleton.Parent = this;
				this.DoLayout();
			}
			else
			{
				this.GameDock.Widget = GameFrame.Singleton;
			}
			GameFrame.Singleton.Visible = true;
			GameFrame.Singleton.ResizeNextFrame();
		}

		// Token: 0x060012F4 RID: 4852 RVA: 0x00052234 File Offset: 0x00050434
		protected override void DoLayout()
		{
			if (this.isFull)
			{
				int frame = (base.IsMaximized ? 8 : 0);
				GameFrame.Singleton.Position = new Vector2((float)frame, base.MenuWidget.Size.y + (float)frame);
				GameFrame.Singleton.Size = base.Size - GameFrame.Singleton.Position - (double)frame - new Vector2(0f, base.StatusBar.Size.y + 4f);
				GameFrame.Singleton.SizeEngineWindow(true);
			}
		}

		// Token: 0x060012F5 RID: 4853 RVA: 0x000522E0 File Offset: 0x000504E0
		protected override void OnKeyPress(KeyEvent e)
		{
			base.OnKeyPress(e);
			if (e.Key >= KeyCode.F1 && e.Key <= KeyCode.F12)
			{
				string bindig = Input.GetBindingForButton(e.Key.ToString());
				if (!string.IsNullOrWhiteSpace(bindig))
				{
					Utility.RunCommand(bindig);
					e.Accepted = true;
				}
			}
		}

		// Token: 0x04000189 RID: 393
		private ConsoleWidget ConsoleWidget;

		// Token: 0x0400018A RID: 394
		private ToolBar ToolsBar;

		// Token: 0x0400018B RID: 395
		private DockWidget GameDock;

		// Token: 0x0400018C RID: 396
		private string defaultState;

		// Token: 0x0400018D RID: 397
		private Dictionary<string, DockWidget> Docked = new Dictionary<string, DockWidget>();

		// Token: 0x0400018E RID: 398
		private bool isFull;
	}
}
