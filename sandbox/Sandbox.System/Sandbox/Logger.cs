using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using NLog;

namespace Sandbox
{
	// Token: 0x0200004D RID: 77
	public class Logger
	{
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000383 RID: 899 RVA: 0x0000D77D File Offset: 0x0000B97D
		// (set) Token: 0x06000384 RID: 900 RVA: 0x0000D785 File Offset: 0x0000B985
		public string Name { get; protected set; }

		// Token: 0x06000385 RID: 901 RVA: 0x0000D78E File Offset: 0x0000B98E
		public Logger(string name)
		{
			this.Name = name;
			this._log = LogManager.GetLogger(name);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x0000D7A9 File Offset: 0x0000B9A9
		public void Error(Exception exception, FormattableString message)
		{
			this.WriteToTargets(LogLevel.Error, exception, message, this.Name);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x0000D7BE File Offset: 0x0000B9BE
		public void Error(Exception exception, object message)
		{
			this.Error(exception, FormattableStringFactory.Create("{0}", new object[] { message }));
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000D7DB File Offset: 0x0000B9DB
		public void Warning(Exception exception, FormattableString message)
		{
			this.WriteToTargets(LogLevel.Warn, exception, message, this.Name);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x0000D7F0 File Offset: 0x0000B9F0
		public void Warning(Exception exception, object message)
		{
			this.Warning(exception, FormattableStringFactory.Create("{0}", new object[] { message }));
		}

		// Token: 0x0600038A RID: 906 RVA: 0x0000D80D File Offset: 0x0000BA0D
		public void Error(Exception exception)
		{
			this.WriteToTargets(LogLevel.Error, exception, exception.Message, this.Name);
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000D827 File Offset: 0x0000BA27
		public void Info(FormattableString message)
		{
			this.DoInfo(this.Name, message);
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0000D836 File Offset: 0x0000BA36
		public void Trace(FormattableString message)
		{
			this.DoTrace(this.Name, message);
		}

		// Token: 0x0600038D RID: 909 RVA: 0x0000D845 File Offset: 0x0000BA45
		public void Warning(FormattableString message)
		{
			this.DoWarning(this.Name, message);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x0000D854 File Offset: 0x0000BA54
		public void Error(FormattableString message)
		{
			this.DoError(this.Name, message);
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000D863 File Offset: 0x0000BA63
		internal void DoInfo(string loggerName, FormattableString message)
		{
			this.WriteToTargets(LogLevel.Info, null, message, loggerName);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x0000D873 File Offset: 0x0000BA73
		internal void DoTrace(string loggerName, FormattableString message)
		{
			this.WriteToTargets(LogLevel.Trace, null, message, loggerName);
		}

		// Token: 0x06000391 RID: 913 RVA: 0x0000D883 File Offset: 0x0000BA83
		internal void DoWarning(string loggerName, FormattableString message)
		{
			this.WriteToTargets(LogLevel.Warn, null, message, loggerName);
		}

		// Token: 0x06000392 RID: 914 RVA: 0x0000D893 File Offset: 0x0000BA93
		internal void DoError(string loggerName, FormattableString message)
		{
			this.WriteToTargets(LogLevel.Error, null, message, loggerName);
		}

		// Token: 0x06000393 RID: 915 RVA: 0x0000D8A3 File Offset: 0x0000BAA3
		public void Info(object message)
		{
			this.Info(FormattableStringFactory.Create("{0}", new object[] { message }));
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0000D8BF File Offset: 0x0000BABF
		public void Trace(object message)
		{
			this.Trace(FormattableStringFactory.Create("{0}", new object[] { message }));
		}

		// Token: 0x06000395 RID: 917 RVA: 0x0000D8DB File Offset: 0x0000BADB
		public void Warning(object message)
		{
			this.Warning(FormattableStringFactory.Create("{0}", new object[] { message }));
		}

		// Token: 0x06000396 RID: 918 RVA: 0x0000D8F7 File Offset: 0x0000BAF7
		public void Error(object message)
		{
			this.Error(FormattableStringFactory.Create("{0}", new object[] { message }));
		}

		// Token: 0x06000397 RID: 919 RVA: 0x0000D914 File Offset: 0x0000BB14
		private void WriteToTargets(LogLevel level, Exception ex, string message, string name = null)
		{
			LogEventInfo logEvent = LogEventInfo.Create(level, name, message);
			if (ex != null)
			{
				logEvent.Exception = ex;
			}
			else
			{
				StackTrace stackTrace = new StackTrace(2, true);
				logEvent.SetStackTrace(stackTrace, 0);
			}
			this._log.Log(logEvent);
		}

		// Token: 0x06000398 RID: 920 RVA: 0x0000D954 File Offset: 0x0000BB54
		private void WriteToTargets(LogLevel level, Exception ex, FormattableString message, string name = null)
		{
			string defaultMessage = message.ToString();
			object[] arguments = message.GetArguments();
			int i = 0;
			object[] args = arguments.Select(delegate(object x)
			{
				int i2 = i;
				i = i2 + 1;
				return Logger.WrapObject(x, i2);
			}).ToArray<object>();
			string htmlMessage = string.Format(message.Format, args);
			LogEventInfo logEvent = LogEventInfo.Create(level, name, defaultMessage);
			if (ex != null)
			{
				logEvent.Exception = ex;
			}
			else
			{
				StackTrace stackTrace = new StackTrace(2, true);
				logEvent.SetStackTrace(stackTrace, 0);
			}
			this._log.Log(logEvent);
			string stacktrace = null;
			if (logEvent.Exception != null)
			{
				stacktrace = GameLog.WriteExceptionDetails(logEvent.Exception);
			}
			if (stacktrace == null && logEvent.StackTrace != null)
			{
				stacktrace = logEvent.StackTrace.ToString();
			}
			LogLevel j = LogLevel.Trace;
			if (logEvent.Level == LogLevel.Info)
			{
				j = LogLevel.Info;
			}
			if (logEvent.Level == LogLevel.Warn)
			{
				j = LogLevel.Warn;
			}
			if (logEvent.Level == LogLevel.Error)
			{
				j = LogLevel.Error;
			}
			LogEvent e = new LogEvent
			{
				Level = j,
				Logger = logEvent.LoggerName,
				Message = defaultMessage,
				HtmlMessage = htmlMessage,
				Stack = stacktrace,
				Time = DateTime.Now,
				Arguments = arguments
			};
			Logging.Write(e);
		}

		// Token: 0x06000399 RID: 921 RVA: 0x0000DAAC File Offset: 0x0000BCAC
		private static object WrapObject(object o, int i)
		{
			if (o == null)
			{
				return "null";
			}
			if (o is string)
			{
				return o;
			}
			if (o.GetType().IsPrimitive)
			{
				return o;
			}
			return string.Format("<a href=\"arg:{0}\" style=\"\">{1}</a>", i, o);
		}

		// Token: 0x040000C9 RID: 201
		private Logger _log;
	}
}
