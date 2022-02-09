using System;
using System.Collections.ObjectModel;
using System.Text;
using NLog;
using NLog.Targets;

namespace Sandbox
{
	// Token: 0x0200004A RID: 74
	[Target("GameLog")]
	internal sealed class GameLog : Target
	{
		// Token: 0x0600036C RID: 876 RVA: 0x0000D3B8 File Offset: 0x0000B5B8
		protected override void Write(LogEventInfo logEvent)
		{
			object obj = this.syncRoot;
			lock (obj)
			{
				this.ProtectedWrite(logEvent);
			}
		}

		// Token: 0x0600036D RID: 877 RVA: 0x0000D3FC File Offset: 0x0000B5FC
		private void ProtectedWrite(LogEventInfo logEvent)
		{
			string stacktrace = null;
			if (logEvent.Exception != null)
			{
				stacktrace = GameLog.WriteExceptionDetails(logEvent.Exception);
			}
			if (stacktrace == null && logEvent.StackTrace != null)
			{
				stacktrace = logEvent.StackTrace.ToString();
			}
			LogLevel i = LogLevel.Trace;
			if (logEvent.Level == LogLevel.Info)
			{
				i = LogLevel.Info;
			}
			if (logEvent.Level == LogLevel.Warn)
			{
				i = LogLevel.Warn;
			}
			if (logEvent.Level == LogLevel.Error)
			{
				i = LogLevel.Error;
			}
			LogEvent e = new LogEvent
			{
				Level = i,
				Logger = logEvent.LoggerName,
				Message = logEvent.FormattedMessage,
				Stack = stacktrace,
				Time = DateTime.Now
			};
			if (logEvent.Exception != null && logEvent.Level == LogLevel.Error)
			{
				Action<Exception> onException = Logging.OnException;
				if (onException != null)
				{
					onException(logEvent.Exception);
				}
			}
			if (Logging.PrintToConsole)
			{
				DateTime now = DateTime.Now;
				Console.ForegroundColor = ConsoleColor.Cyan;
				Console.Write(now.ToString("hh:mm:ss "));
				string logger = e.Logger ?? " ";
				if (logger.Length > 8)
				{
					logger = logger.Substring(0, 8);
				}
				if (logger.Length < 8)
				{
					logger += new string(' ', 8 - logger.Length);
				}
				Console.ForegroundColor = ConsoleColor.Green;
				Console.Write(logger);
				Console.ForegroundColor = this.GetConsoleColor(e);
				string[] lines = logEvent.FormattedMessage.Split(new char[] { '\n', '\r' });
				Console.WriteLine(" " + lines[0]);
				for (int j = 1; j < lines.Length; j++)
				{
					Console.WriteLine("                 " + lines[j]);
				}
			}
		}

		// Token: 0x0600036E RID: 878 RVA: 0x0000D5C8 File Offset: 0x0000B7C8
		private ConsoleColor GetConsoleColor(LogEvent e)
		{
			if (e.Level == LogLevel.Trace)
			{
				return ConsoleColor.DarkGray;
			}
			if (e.Level == LogLevel.Error)
			{
				return ConsoleColor.Red;
			}
			if (e.Level == LogLevel.Warn)
			{
				return ConsoleColor.Yellow;
			}
			return ConsoleColor.White;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x0000D5F4 File Offset: 0x0000B7F4
		internal static string WriteExceptionDetails(Exception exception)
		{
			if (exception == null)
			{
				return null;
			}
			StringBuilder sb = new StringBuilder();
			GameLog.UnwrapException(exception, sb);
			return sb.ToString();
		}

		// Token: 0x06000370 RID: 880 RVA: 0x0000D61C File Offset: 0x0000B81C
		private static void UnwrapException(Exception exception, StringBuilder sb)
		{
			Exception baseException = exception.GetBaseException();
			AggregateException aggregate = baseException as AggregateException;
			if (aggregate == null)
			{
				GameLog.PrintException(baseException, sb);
				return;
			}
			ReadOnlyCollection<Exception> innerExceptions = aggregate.InnerExceptions;
			if (innerExceptions.Count == 0)
			{
				GameLog.PrintException(aggregate, sb);
				return;
			}
			if (innerExceptions.Count == 1)
			{
				GameLog.UnwrapException(innerExceptions[0], sb);
				return;
			}
			sb.AppendLine(string.Format("Aggregate of {0} exceptions:", innerExceptions.Count));
			for (int i = 0; i < innerExceptions.Count; i++)
			{
				sb.AppendLine(string.Format(">>> Exception {0}:", i));
				GameLog.UnwrapException(innerExceptions[0], sb);
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x0000D6C4 File Offset: 0x0000B8C4
		private static void PrintException(Exception exception, StringBuilder sb)
		{
			sb.AppendLine(((exception != null) ? exception.ToString() : null) ?? "<null>");
		}

		// Token: 0x040000BB RID: 187
		private readonly object syncRoot = new object();
	}
}
