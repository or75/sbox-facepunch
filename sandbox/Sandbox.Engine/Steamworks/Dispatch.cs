using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Sandbox.Internal;
using Steamworks.Data;

namespace Steamworks
{
	/// <summary>
	/// Responsible for all callback/callresult handling
	///
	/// This manually pumps Steam's message queue and dispatches those
	/// events to any waiting callbacks/callresults.
	/// </summary>
	// Token: 0x0200001A RID: 26
	internal static class Dispatch
	{
		/// <summary>
		/// Called if an exception happens during a callback/callresult.
		/// This is needed because the exception isn't always accessible when running
		/// async.. and can fail silently. With this hooked you won't be stuck wondering
		/// what happened.
		/// </summary>
		// Token: 0x0600001D RID: 29 RVA: 0x000024A8 File Offset: 0x000006A8
		internal static void OnClientCallback(int type, IntPtr data, int dataSize)
		{
			try
			{
				Dispatch.ProcessCallback((CallbackType)type, data, dataSize, false);
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Error(e);
			}
		}

		/// <summary>
		/// A callback is a general global message
		/// </summary>
		// Token: 0x0600001E RID: 30 RVA: 0x000024E0 File Offset: 0x000006E0
		private static void ProcessCallback(CallbackType type, IntPtr data, int dataSize, bool isServer)
		{
			if (type == CallbackType.SteamAPICallCompleted)
			{
				Dispatch.ProcessResult(type, data, dataSize);
				return;
			}
			List<Dispatch.Callback> list;
			if (Dispatch.Callbacks.TryGetValue(type, out list))
			{
				Dispatch.actionsToCall.Clear();
				foreach (Dispatch.Callback item in list)
				{
					if (item.server == isServer)
					{
						Dispatch.actionsToCall.Add(item.action);
					}
				}
				foreach (Action<IntPtr> action in Dispatch.actionsToCall)
				{
					action(data);
				}
				Dispatch.actionsToCall.Clear();
			}
		}

		/// <summary>
		/// Given a callback, try to turn it into a string
		/// </summary>
		// Token: 0x0600001F RID: 31 RVA: 0x000025B8 File Offset: 0x000007B8
		internal static string CallbackToString(CallbackType type, IntPtr data, int expectedsize)
		{
			Type t;
			if (!CallbackTypeFactory.All.TryGetValue(type, out t))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 1);
				defaultInterpolatedStringHandler.AppendLiteral("[");
				defaultInterpolatedStringHandler.AppendFormatted<CallbackType>(type);
				defaultInterpolatedStringHandler.AppendLiteral(" not in sdk]");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			object strct = data.ToType(t);
			if (strct == null)
			{
				return "[null]";
			}
			string str = "";
			FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (fields.Length == 0)
			{
				return "[no fields]";
			}
			int columnSize = fields.Max((FieldInfo x) => x.Name.Length) + 1;
			if (columnSize < 10)
			{
				columnSize = 10;
			}
			foreach (FieldInfo field in fields)
			{
				int spaces = columnSize - field.Name.Length;
				if (spaces < 0)
				{
					spaces = 0;
				}
				string str2 = str;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 3);
				defaultInterpolatedStringHandler.AppendFormatted(new string(' ', spaces));
				defaultInterpolatedStringHandler.AppendFormatted(field.Name);
				defaultInterpolatedStringHandler.AppendLiteral(": ");
				defaultInterpolatedStringHandler.AppendFormatted<object>(field.GetValue(strct));
				defaultInterpolatedStringHandler.AppendLiteral("\n");
				str = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
			return str.Trim('\n');
		}

		/// <summary>
		/// A result is a reply to a specific command
		/// </summary>
		// Token: 0x06000020 RID: 32 RVA: 0x00002704 File Offset: 0x00000904
		private static void ProcessResult(CallbackType type, IntPtr data, int dataSize)
		{
			SteamAPICallCompleted_t result = data.ToType<SteamAPICallCompleted_t>();
			Dispatch.ResultCallback callbackInfo;
			if (!Dispatch.ResultCallbacks.TryGetValue(result.AsyncCall, out callbackInfo))
			{
				return;
			}
			Dispatch.ResultCallbacks.Remove(result.AsyncCall);
			callbackInfo.continuation();
		}

		/// <summary>
		/// Watch for a steam api call
		/// </summary>
		// Token: 0x06000021 RID: 33 RVA: 0x0000274C File Offset: 0x0000094C
		internal static void OnCallComplete<T>(SteamAPICall_t call, Action continuation, bool server) where T : struct, ICallbackData
		{
			Dispatch.ResultCallbacks[call.Value] = new Dispatch.ResultCallback
			{
				continuation = continuation,
				server = server
			};
		}

		/// <summary>
		/// Install a global callback. The passed function will get called if it's all good.
		/// </summary>
		// Token: 0x06000022 RID: 34 RVA: 0x00002784 File Offset: 0x00000984
		internal static void Install<T>(Action<T> p, bool server = false) where T : ICallbackData
		{
			T t = default(T);
			CallbackType type = t.CallbackType;
			List<Dispatch.Callback> list;
			if (!Dispatch.Callbacks.TryGetValue(type, out list))
			{
				list = new List<Dispatch.Callback>();
				Dispatch.Callbacks[type] = list;
			}
			list.Add(new Dispatch.Callback
			{
				action = delegate(IntPtr x)
				{
					p(x.ToType<T>());
				},
				server = server
			});
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002800 File Offset: 0x00000A00
		internal static void ShutdownServer()
		{
			foreach (KeyValuePair<CallbackType, List<Dispatch.Callback>> callback in Dispatch.Callbacks)
			{
				Dispatch.Callbacks[callback.Key].RemoveAll((Dispatch.Callback x) => x.server);
			}
			Dispatch.ResultCallbacks = Dispatch.ResultCallbacks.Where((KeyValuePair<ulong, Dispatch.ResultCallback> x) => !x.Value.server).ToDictionary((KeyValuePair<ulong, Dispatch.ResultCallback> x) => x.Key, (KeyValuePair<ulong, Dispatch.ResultCallback> x) => x.Value);
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000028F4 File Offset: 0x00000AF4
		internal static void ShutdownClient()
		{
			foreach (KeyValuePair<CallbackType, List<Dispatch.Callback>> callback in Dispatch.Callbacks)
			{
				Dispatch.Callbacks[callback.Key].RemoveAll((Dispatch.Callback x) => !x.server);
			}
			Dispatch.ResultCallbacks = Dispatch.ResultCallbacks.Where((KeyValuePair<ulong, Dispatch.ResultCallback> x) => x.Value.server).ToDictionary((KeyValuePair<ulong, Dispatch.ResultCallback> x) => x.Key, (KeyValuePair<ulong, Dispatch.ResultCallback> x) => x.Value);
		}

		/// <summary>
		/// To be safe we don't call the continuation functions while iterating
		/// the Callback list. This is maybe overly safe because the only way this
		/// could be an issue is if the callback list is modified in the continuation
		/// which would only happen if starting or shutting down in the callback.
		/// </summary>
		// Token: 0x0400011C RID: 284
		private static List<Action<IntPtr>> actionsToCall = new List<Action<IntPtr>>();

		// Token: 0x0400011D RID: 285
		private static Dictionary<ulong, Dispatch.ResultCallback> ResultCallbacks = new Dictionary<ulong, Dispatch.ResultCallback>();

		// Token: 0x0400011E RID: 286
		private static Dictionary<CallbackType, List<Dispatch.Callback>> Callbacks = new Dictionary<CallbackType, List<Dispatch.Callback>>();

		// Token: 0x02000312 RID: 786
		private struct ResultCallback
		{
			// Token: 0x040015AF RID: 5551
			internal Action continuation;

			// Token: 0x040015B0 RID: 5552
			internal bool server;
		}

		// Token: 0x02000313 RID: 787
		private struct Callback
		{
			// Token: 0x040015B1 RID: 5553
			internal Action<IntPtr> action;

			// Token: 0x040015B2 RID: 5554
			internal bool server;
		}
	}
}
