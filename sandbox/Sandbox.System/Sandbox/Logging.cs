using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using NLog;
using NLog.Config;
using NLog.Targets;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x0200004E RID: 78
	public static class Logging
	{
		// Token: 0x0600039A RID: 922 RVA: 0x0000DAE4 File Offset: 0x0000BCE4
		static Logging()
		{
			LoggingConfiguration config = new LoggingConfiguration();
			GameLog gameLog = new GameLog();
			FileTarget file = new FileTarget
			{
				FileName = Environment.CurrentDirectory + "/logs/Log.log",
				ArchiveOldFileOnStartup = true,
				OpenFileCacheSize = 10,
				MaxArchiveFiles = 20,
				KeepFileOpen = true,
				Layout = "${date}\t${logger}\t${message}\t${exception:format=ToString}"
			};
			config.AddTarget("file", file);
			config.AddTarget("console", gameLog);
			config.AddTarget("null", new NullTarget());
			config.LoggingRules.Clear();
			config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, config.FindTargetByName("file")));
			config.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, gameLog));
			LogManager.Configuration = config;
			AppDomain.CurrentDomain.ProcessExit += delegate([Nullable(2)] object x, EventArgs y)
			{
				LogManager.Shutdown();
			};
		}

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x0600039B RID: 923 RVA: 0x0000DBFA File Offset: 0x0000BDFA
		// (set) Token: 0x0600039C RID: 924 RVA: 0x0000DC01 File Offset: 0x0000BE01
		public static bool Enabled { get; set; } = true;

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x0600039D RID: 925 RVA: 0x0000DC09 File Offset: 0x0000BE09
		// (set) Token: 0x0600039E RID: 926 RVA: 0x0000DC10 File Offset: 0x0000BE10
		internal static bool PrintToConsole { get; set; } = true;

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600039F RID: 927 RVA: 0x0000DC18 File Offset: 0x0000BE18
		// (remove) Token: 0x060003A0 RID: 928 RVA: 0x0000DC4C File Offset: 0x0000BE4C
		internal static event Action<LogEvent> OnMessage;

		// Token: 0x060003A1 RID: 929 RVA: 0x0000DC80 File Offset: 0x0000BE80
		internal static void Write(in LogEvent e)
		{
			if (ThreadSafe.IsMainThread && Logging.callDepth < 3)
			{
				try
				{
					Logging.callDepth++;
					Action<LogEvent> onMessage = Logging.OnMessage;
					if (onMessage == null)
					{
						return;
					}
					onMessage(e);
					return;
				}
				finally
				{
					Logging.callDepth--;
				}
			}
			Logging.QueuedMessages.Writer.TryWrite(e);
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x0000DCF4 File Offset: 0x0000BEF4
		internal static void PushQueuedMessages()
		{
			ThreadSafe.AssertIsMainThread("PushQueuedMessages");
			LogEvent msg;
			while (Logging.QueuedMessages.Reader.TryRead(out msg))
			{
				try
				{
					Action<LogEvent> onMessage = Logging.OnMessage;
					if (onMessage != null)
					{
						onMessage(msg);
					}
					continue;
				}
				catch (Exception e)
				{
					GlobalSystemNamespace.Log.Error(e);
					continue;
				}
				break;
			}
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x0000DD50 File Offset: 0x0000BF50
		public static Logger GetLogger(string name = null)
		{
			if (name == null)
			{
				name = new StackFrame(1, false).GetMethod().DeclaringType.Name;
			}
			return new Logger(name);
		}

		// Token: 0x040000CE RID: 206
		internal static Action<Exception> OnException;

		// Token: 0x040000CF RID: 207
		private static Channel<LogEvent> QueuedMessages = Channel.CreateUnbounded<LogEvent>();

		// Token: 0x040000D0 RID: 208
		private static int callDepth = 0;
	}
}
