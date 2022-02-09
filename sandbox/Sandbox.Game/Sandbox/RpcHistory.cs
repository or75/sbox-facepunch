using System;
using System.Collections.Generic;

namespace Sandbox
{
	/// <summary>
	/// On the client prediction remembers every RPC called during a tick.
	/// When a RPC comes from the server we compare it to our history and if
	/// it doesn't exist then we call it.
	/// </summary>
	// Token: 0x020000CC RID: 204
	internal class RpcHistory
	{
		// Token: 0x06001262 RID: 4706 RVA: 0x0004D96C File Offset: 0x0004BB6C
		public static void Remember(string name, params object[] args)
		{
			RpcHistory.Storage.Add(new RpcHistory.RpcStorage
			{
				Tick = Time.Tick,
				Name = name,
				Args = args
			});
		}

		// Token: 0x06001263 RID: 4707 RVA: 0x0004D9A8 File Offset: 0x0004BBA8
		public static bool Contains(int currentTick, string name, params object[] args)
		{
			for (int i = 0; i < RpcHistory.Storage.Count; i++)
			{
				if (RpcHistory.Storage[i].Tick < currentTick)
				{
					RpcHistory.Storage.RemoveAt(i);
					i--;
				}
				else if (RpcHistory.Storage[i].Tick == currentTick && !(RpcHistory.Storage[i].Name != name) && RpcHistory.CompareArguments(args, RpcHistory.Storage[i].Args))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06001264 RID: 4708 RVA: 0x0004DA34 File Offset: 0x0004BC34
		private static bool CompareArguments(object[] incoming, object[] predicted)
		{
			if (incoming == null || predicted == null)
			{
				return predicted == incoming;
			}
			if (incoming.Length != predicted.Length)
			{
				return false;
			}
			for (int i = 0; i < incoming.Length; i++)
			{
				if (!RpcHistory.Compare(incoming[i], predicted[i]))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06001265 RID: 4709 RVA: 0x0004DA74 File Offset: 0x0004BC74
		private static bool Compare(object incoming, object predicted)
		{
			if (incoming == null)
			{
				return predicted == null;
			}
			if (predicted == null)
			{
				return incoming == null;
			}
			return incoming.Equals(predicted);
		}

		// Token: 0x040003D9 RID: 985
		private static List<RpcHistory.RpcStorage> Storage = new List<RpcHistory.RpcStorage>();

		// Token: 0x0200024A RID: 586
		private struct RpcStorage
		{
			// Token: 0x040011C8 RID: 4552
			public int Tick;

			// Token: 0x040011C9 RID: 4553
			public string Name;

			// Token: 0x040011CA RID: 4554
			public object[] Args;
		}
	}
}
