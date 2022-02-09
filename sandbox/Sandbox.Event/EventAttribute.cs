using System;

namespace Sandbox
{
	// Token: 0x02000003 RID: 3
	[AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
	public class EventAttribute : Attribute
	{
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000008 RID: 8 RVA: 0x000020F8 File Offset: 0x000002F8
		// (set) Token: 0x06000009 RID: 9 RVA: 0x00002100 File Offset: 0x00000300
		public string EventName { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10 RVA: 0x00002109 File Offset: 0x00000309
		// (set) Token: 0x0600000B RID: 11 RVA: 0x00002111 File Offset: 0x00000311
		public int Priority { get; set; }

		// Token: 0x0600000C RID: 12 RVA: 0x0000211A File Offset: 0x0000031A
		public EventAttribute(string eventName)
		{
			this.EventName = eventName;
		}
	}
}
