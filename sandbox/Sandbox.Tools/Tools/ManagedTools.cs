using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x02000087 RID: 135
	internal static class ManagedTools
	{
		// Token: 0x0600138E RID: 5006 RVA: 0x00053BA4 File Offset: 0x00051DA4
		public static void InitStart()
		{
			Global.Assembly = typeof(ToolAddon).Assembly;
			Event.RegisterAssembly(null, Global.Assembly);
			Global.HotloadManager = new HotloadManager();
			Global.HotloadManager.Watch(Global.Assembly);
			Global.HotloadManager.Watch(typeof(EventAttribute).Assembly);
			Global.HotloadManager.OnSuccess += delegate()
			{
				Event.Run("hotloaded");
			};
			GlobalToolsNamespace.Reflection = new ReflectionSystem(GlobalToolsNamespace.Log);
			GlobalToolsNamespace.Reflection.AddStaticAssembly(Global.Assembly);
			GlobalToolsNamespace.Cookie = new CookieContainer("tools");
			foreach (string file in FileSystem.Root.FindFile("/addons/base/fonts/", "*.ttf", false))
			{
				QFontDatabase.addApplicationFont(FileSystem.Root.GetFullPath("/addons/base/fonts/" + file));
			}
			AddonManager.TryAddAddon(FileSystem.Root.GetFullPath("/addons/tools"));
			Application.ReloadStyles();
			EditorMainWindow.Startup();
			GlobalToolsNamespace.EditorWindow.StatusBar.ShowMessage("Loading..", 5f);
			QApp.processEvents();
			ManagedTools.CleanTempFolder();
		}

		// Token: 0x0600138F RID: 5007 RVA: 0x00053D00 File Offset: 0x00051F00
		public static void InitFinish()
		{
			FileSystem.Root.Watch("/addons/tools/resources/styles/*").OnChangedFile += delegate(string x)
			{
				Application.ReloadStyles();
			};
			GlobalToolsNamespace.ToolsTrayIcon = new TrayIcon(null);
			GlobalToolsNamespace.ToolsTrayIcon.SetIcon("tray/trayicon.png");
			GlobalToolsNamespace.ToolsTrayIcon.Visible = true;
			EditorMainWindow editorWindow = GlobalToolsNamespace.EditorWindow;
			if (editorWindow != null)
			{
				StatusBar statusBar = editorWindow.StatusBar;
				if (statusBar != null)
				{
					statusBar.ShowMessage("Tools Loading Finished..", 5f);
				}
			}
			QApp.processEvents();
			AddonManager.BlockForCompiles();
			ManagedTools.RunFrame();
			EditorMainWindow editorWindow2 = GlobalToolsNamespace.EditorWindow;
			if (editorWindow2 != null)
			{
				editorWindow2.RestoreFromStateCookie();
			}
			GlobalToolsNamespace.EditorWindow.Enabled = true;
		}

		// Token: 0x06001390 RID: 5008 RVA: 0x00053DB4 File Offset: 0x00051FB4
		public static void RunFrame()
		{
			MainThread.RunQueues();
			AddonManager.Frame();
			HotloadManager hotloadManager = Global.HotloadManager;
			if (hotloadManager != null)
			{
				hotloadManager.Tick();
			}
			Event.Run("frame");
		}

		// Token: 0x06001391 RID: 5009 RVA: 0x00053DDA File Offset: 0x00051FDA
		public static void Shutdown()
		{
			AddonManager.Shutdown();
		}

		/// <summary>
		/// This replaces the clean temp folder that was in engine.. which worked but it didn't
		/// delete empty folders - so it ended up taking a long time.
		/// </summary>
		// Token: 0x06001392 RID: 5010 RVA: 0x00053DE4 File Offset: 0x00051FE4
		private static void CleanTempFolder()
		{
			string valveTemp = Path.Combine(Path.GetTempPath(), "valve");
			if (!Directory.Exists(valveTemp))
			{
				return;
			}
			foreach (string file in Directory.EnumerateFiles(valveTemp, "*", SearchOption.AllDirectories))
			{
				if (!(File.GetLastWriteTime(file) > DateTime.Now.AddDays(-2.0)))
				{
					GlobalToolsNamespace.Log.Info("Cleanup old file: " + file);
					File.Delete(file);
				}
			}
			foreach (string dir in from x in Directory.EnumerateDirectories(valveTemp, "*", SearchOption.AllDirectories)
				orderby x.Length descending
				select x)
			{
				if (Directory.GetDirectories(dir).Count<string>() <= 0 && Directory.GetFiles(dir).Count<string>() <= 0)
				{
					GlobalToolsNamespace.Log.Info("Cleanup empty folder: " + dir);
					Directory.Delete(dir);
				}
			}
		}

		// Token: 0x06001393 RID: 5011 RVA: 0x00053F24 File Offset: 0x00052124
		internal static void NativeHook(string name, IntPtr arg0, IntPtr arg1, IntPtr arg2)
		{
			MethodInfo method = typeof(ManagedTools).GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			if (method == null)
			{
				GlobalToolsNamespace.Log.Warning(FormattableStringFactory.Create("Unknown tool hook: {0}", new object[] { name }));
				return;
			}
			ParameterInfo[] parameters = method.GetParameters();
			if (parameters.Length == 0)
			{
				if (method != null)
				{
					method.Invoke(null, null);
				}
				return;
			}
			if (parameters.Length == 1)
			{
				if (method != null)
				{
					method.Invoke(null, new object[] { arg0 });
				}
				return;
			}
		}

		/// <summary>
		///  Called when that little top right Tools menu is created in one of the tools
		/// </summary>
		// Token: 0x06001394 RID: 5012 RVA: 0x00053FAA File Offset: 0x000521AA
		internal static void OnToolMenuOpen(QWidget widget)
		{
		}

		/// <summary>
		/// Called when the tools menu is created the asset browser
		/// </summary>
		// Token: 0x06001395 RID: 5013 RVA: 0x00053FAC File Offset: 0x000521AC
		internal static void OnSource2ToolsMenu(QWidget widget)
		{
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x00053FAE File Offset: 0x000521AE
		internal static void GlobalMousePressed()
		{
			Event.Run("qt.mousepressed");
		}

		// Token: 0x06001397 RID: 5015 RVA: 0x00053FBC File Offset: 0x000521BC
		internal static bool GlobalKeyPressed(bool press, int iKey)
		{
			if (iKey == 126 || iKey == 96)
			{
				GlobalToolsNamespace.EditorWindow.Canvas.Focus(true);
				g_pToolFramework2.BringEngineWindowToFront(default(QWidget));
				return true;
			}
			return false;
		}

		// Token: 0x06001398 RID: 5016 RVA: 0x00053FF8 File Offset: 0x000521F8
		internal static void OnToolCommand(string v)
		{
			string[] parts = v.SplitQuotesStrings();
			if (parts.Length == 0)
			{
				return;
			}
			Event.Run("command " + parts[0]);
		}
	}
}
