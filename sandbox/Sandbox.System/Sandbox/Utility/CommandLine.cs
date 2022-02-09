using System;
using System.Collections.Generic;

namespace Sandbox.Utility
{
	// Token: 0x02000069 RID: 105
	internal static class CommandLine
	{
		/// <summary>
		/// Returns the full command line, reconstructed from System.Environment.GetCommandLineArgs
		/// </summary>
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x0600049D RID: 1181 RVA: 0x0002129A File Offset: 0x0001F49A
		public static string Full
		{
			get
			{
				return CommandLine.commandline;
			}
		}

		// Token: 0x0600049E RID: 1182 RVA: 0x000212A4 File Offset: 0x0001F4A4
		static CommandLine()
		{
			if (CommandLine.commandline == "")
			{
				foreach (string arg in Environment.GetCommandLineArgs())
				{
					CommandLine.commandline = CommandLine.commandline + "\"" + arg + "\" ";
				}
			}
			if (CommandLine.commandline == "")
			{
				return;
			}
			string strKey = "";
			foreach (string var in CommandLine.commandline.SplitQuotesStrings())
			{
				if (var.Length != 0)
				{
					if (var[0] == '-' || var[0] == '+')
					{
						if (strKey != "" && !CommandLine.switches.ContainsKey(strKey))
						{
							CommandLine.switches.Add(strKey, "");
						}
						strKey = var;
					}
					else if (strKey != "")
					{
						if (!CommandLine.switches.ContainsKey(strKey))
						{
							CommandLine.switches.Add(strKey, var);
						}
						strKey = "";
					}
				}
			}
			if (strKey != "" && !CommandLine.switches.ContainsKey(strKey))
			{
				CommandLine.switches.Add(strKey, "");
			}
		}

		/// <summary>
		/// if ( HasSwitch( "-console" ) ) EnableConsole();
		/// </summary>
		// Token: 0x0600049F RID: 1183 RVA: 0x000213F0 File Offset: 0x0001F5F0
		public static bool HasSwitch(string strName)
		{
			return CommandLine.switches.ContainsKey(strName);
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00021400 File Offset: 0x0001F600
		public static string GetSwitch(string strName, string strDefault)
		{
			string strValue = "";
			if (!CommandLine.switches.TryGetValue(strName, out strValue))
			{
				return strDefault;
			}
			return strValue;
		}

		// Token: 0x060004A1 RID: 1185 RVA: 0x00021428 File Offset: 0x0001F628
		public static int GetSwitchInt(string strName, int iDefault)
		{
			string strValue = "";
			if (!CommandLine.switches.TryGetValue(strName, out strValue))
			{
				return iDefault;
			}
			int outval = iDefault;
			if (!int.TryParse(strValue, out outval))
			{
				return iDefault;
			}
			return outval;
		}

		/// <summary>
		/// Returns all command line values
		/// </summary>
		/// <returns></returns>
		// Token: 0x060004A2 RID: 1186 RVA: 0x0002145B File Offset: 0x0001F65B
		public static Dictionary<string, string> GetSwitches()
		{
			return CommandLine.switches;
		}

		// Token: 0x04000932 RID: 2354
		private static string commandline = "";

		// Token: 0x04000933 RID: 2355
		private static Dictionary<string, string> switches = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
	}
}
