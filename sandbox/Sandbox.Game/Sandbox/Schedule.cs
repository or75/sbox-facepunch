using System;
using System.Collections.Generic;

namespace Sandbox
{
	// Token: 0x020000F7 RID: 247
	internal static class Schedule
	{
		// Token: 0x06001488 RID: 5256 RVA: 0x00052524 File Offset: 0x00050724
		public static Schedule.Handle Add(string debugName, double timeBetween, Action action)
		{
			Schedule.Handle handle = default(Schedule.Handle);
			ulong num = Schedule.currentHandle;
			Schedule.currentHandle = num + 1UL;
			handle.Value = num;
			handle.DebugName = debugName;
			handle.Action = action;
			handle.TimeBetween = timeBetween;
			handle.TimeSinceRun = 0f;
			Schedule.Handle h = handle;
			Schedule.handles.Add(h);
			return h;
		}

		// Token: 0x06001489 RID: 5257 RVA: 0x00052588 File Offset: 0x00050788
		public static void Run()
		{
			for (int i = 0; i < Schedule.handles.Count; i++)
			{
				Schedule.handles[i] = Schedule.handles[i].Call();
			}
		}

		// Token: 0x040004C4 RID: 1220
		private static ulong currentHandle = 1UL;

		// Token: 0x040004C5 RID: 1221
		public static List<Schedule.Handle> handles = new List<Schedule.Handle>();

		// Token: 0x02000268 RID: 616
		public struct Handle
		{
			// Token: 0x170005C2 RID: 1474
			// (get) Token: 0x06001EE3 RID: 7907 RVA: 0x00076F29 File Offset: 0x00075129
			// (set) Token: 0x06001EE4 RID: 7908 RVA: 0x00076F31 File Offset: 0x00075131
			public string DebugName { readonly get; internal set; }

			// Token: 0x06001EE5 RID: 7909 RVA: 0x00076F3A File Offset: 0x0007513A
			public Schedule.Handle Call()
			{
				if ((double)this.TimeSinceRun < this.TimeBetween)
				{
					return this;
				}
				this.TimeSinceRun = 0f;
				this.Action();
				return this;
			}

			// Token: 0x0400122E RID: 4654
			public ulong Value;

			// Token: 0x0400122F RID: 4655
			public Action Action;

			// Token: 0x04001230 RID: 4656
			public RealTimeSince TimeSinceRun;

			// Token: 0x04001231 RID: 4657
			public double TimeBetween;
		}
	}
}
