using System;

namespace Sandbox
{
	// Token: 0x02000009 RID: 9
	public class TimingEntry
	{
		/// <summary>
		/// Total number of instances processed.
		/// </summary>
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000048 RID: 72 RVA: 0x00003B1A File Offset: 0x00001D1A
		// (set) Token: 0x06000049 RID: 73 RVA: 0x00003B22 File Offset: 0x00001D22
		public int Instances { get; set; }

		/// <summary>
		/// Total time taken processing instances.
		/// </summary>
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600004A RID: 74 RVA: 0x00003B2B File Offset: 0x00001D2B
		// (set) Token: 0x0600004B RID: 75 RVA: 0x00003B33 File Offset: 0x00001D33
		public double Milliseconds { get; set; }

		// Token: 0x0600004C RID: 76 RVA: 0x00003B3C File Offset: 0x00001D3C
		internal TimingEntry(int instances, TimeSpan timeSpan)
		{
			this.Instances = instances;
			this.Milliseconds = timeSpan.TotalMilliseconds;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003B58 File Offset: 0x00001D58
		public TimingEntry()
		{
		}
	}
}
