using System;
using System.Threading.Tasks;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x02000104 RID: 260
	public static class GameTask
	{
		// Token: 0x06001514 RID: 5396 RVA: 0x00053FBD File Offset: 0x000521BD
		internal static void Reset()
		{
			GameTask.source = new TaskSource(1);
		}

		// Token: 0x06001515 RID: 5397 RVA: 0x00053FCA File Offset: 0x000521CA
		public static Task Delay(int ms)
		{
			return GameTask.source.Delay(ms);
		}

		// Token: 0x06001516 RID: 5398 RVA: 0x00053FD7 File Offset: 0x000521D7
		public static Task DelaySeconds(float seconds)
		{
			return GameTask.Delay((int)(seconds * 1000f));
		}

		// Token: 0x06001517 RID: 5399 RVA: 0x00053FE6 File Offset: 0x000521E6
		public static Task DelayRealtime(int ms)
		{
			return GameTask.source.DelayRealtime(ms);
		}

		// Token: 0x06001518 RID: 5400 RVA: 0x00053FF3 File Offset: 0x000521F3
		public static Task DelayRealtimeSeconds(float seconds)
		{
			return GameTask.DelayRealtime((int)(seconds * 1000f));
		}

		// Token: 0x06001519 RID: 5401 RVA: 0x00054002 File Offset: 0x00052202
		public static SyncTask NextPhysicsFrame()
		{
			if (Host.IsServer)
			{
				return new SyncTask(MainThreadContext.PhysicsThinkServer, 0);
			}
			return new SyncTask(MainThreadContext.PhysicsThinkClient, 0);
		}

		// Token: 0x040004EA RID: 1258
		private static TaskSource source = new TaskSource(1);
	}
}
