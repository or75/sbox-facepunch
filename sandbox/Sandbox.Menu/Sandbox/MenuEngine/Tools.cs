using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using NativeEngine;
using Sandbox.Engine;
using Sandbox.Internal;
using Sandbox.UI;

namespace Sandbox.MenuEngine
{
	// Token: 0x02000013 RID: 19
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class Tools
	{
		// Token: 0x0600005E RID: 94 RVA: 0x00003794 File Offset: 0x00001994
		public static void OpenSourceFile(string filename, int line)
		{
			Host.AssertMenu("OpenSourceFile");
			CodeEditor.OpenSolution(filename, line);
		}

		// Token: 0x0600005F RID: 95 RVA: 0x000037A7 File Offset: 0x000019A7
		public static void DeveloperView(Rect rect)
		{
			SharedRendering.RenderRect = rect;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x000037AF File Offset: 0x000019AF
		public static void AddLogger(Action<LogEvent> logger)
		{
			Host.AssertMenu("AddLogger");
			Logging.OnMessage += logger;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x000037C1 File Offset: 0x000019C1
		public static void RemoveLogger(Action<LogEvent> logger)
		{
			Host.AssertMenu("RemoveLogger");
			Logging.OnMessage -= logger;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x000037D4 File Offset: 0x000019D4
		public static string[] AutoComplete(string text, int maxCount)
		{
			Host.AssertMenu("AutoComplete");
			return (from x in Console.AutoComplete(text).Split('\n', StringSplitOptions.RemoveEmptyEntries)
				orderby x
				select x).Take(maxCount).ToArray<string>();
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00003828 File Offset: 0x00001A28
		public static async Task CreateGame(Package package, Dictionary<string, string> details)
		{
			Host.AssertMenu("CreateGame");
			IMenuAddon.SetLoadingVisible(true);
			IMenuAddon.SetLoadingStatus("Creating Game", "");
			await Task.Delay(300);
			GameCreateHistory.OnCreateGame(package, details);
			InputService.InsertCommand(InputCommandSource.ICS_SERVER, "gamemode " + package.FullIdent + "\n", 0, 0);
			InputService.InsertCommand(InputCommandSource.ICS_SERVER, "host_timescale 1\n", 0, 0);
			string maxplayers;
			if (details.TryGetValue("maxplayers", out maxplayers))
			{
				InputService.InsertCommand(InputCommandSource.ICS_SERVER, "maxplayers " + maxplayers + "\n", 0, 0);
			}
			string isLan;
			if (details.TryGetValue("sv_lan", out isLan))
			{
				InputService.InsertCommand(InputCommandSource.ICS_SERVER, "sv_lan " + ((isLan == "True") ? "1" : "0") + "\n", 0, 0);
			}
			string password;
			if (details.TryGetValue("sv_password", out password))
			{
				InputService.InsertCommand(InputCommandSource.ICS_SERVER, "sv_password " + password.QuoteSafe() + "\n", 0, 0);
			}
			InputService.InsertCommand(InputCommandSource.ICS_SERVER, "changelevel " + details["map"] + "\n", 0, 0);
			Event.Run("menu.home.rebuild");
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00003873 File Offset: 0x00001A73
		public static void SetDevLayer(RootPanel panel)
		{
			Host.AssertMenu("SetDevLayer");
			panel.FullScreen = true;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x00003886 File Offset: 0x00001A86
		public static void SkipAllTransitions()
		{
			Host.AssertMenu("SkipAllTransitions");
			IClientDll current = IClientDll.Current;
			if (current != null)
			{
				current.RunEvent("ui.skiptransitions");
			}
			IMenuDll menuDll = IMenuDll.Current;
			if (menuDll == null)
			{
				return;
			}
			menuDll.RunEvent("ui.skiptransitions");
		}

		/// <summary>
		/// Init a stream service
		/// </summary>
		// Token: 0x06000066 RID: 102 RVA: 0x000038BC File Offset: 0x00001ABC
		public static async Task<bool> ConnectStream(StreamService service)
		{
			Host.AssertMenu("ConnectStream");
			return await Streamer.Init(service);
		}

		/// <summary>
		/// Init a stream service
		/// </summary>
		// Token: 0x06000067 RID: 103 RVA: 0x000038FF File Offset: 0x00001AFF
		public static void DisconnectStream()
		{
			Host.AssertMenu("DisconnectStream");
			Streamer.Shutdown();
		}
	}
}
