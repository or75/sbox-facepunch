using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
	/// <summary>
	/// Contains information about an assembly hotload event, including any warnings or errors emitted,
	/// the time taken to process instances of different types, and the total number of instances processed.
	/// </summary>
	// Token: 0x0200000B RID: 11
	public sealed class HotloadResult
	{
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000051 RID: 81 RVA: 0x00003B89 File Offset: 0x00001D89
		// (set) Token: 0x06000052 RID: 82 RVA: 0x00003B91 File Offset: 0x00001D91
		public DateTime Created { get; set; } = DateTime.UtcNow;

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00003B9A File Offset: 0x00001D9A
		internal static HotloadResult NoActionSingleton { get; } = new HotloadResult
		{
			NoAction = true
		};

		/// <summary>
		/// Contains timing information for each type processed during the hotload.
		/// </summary>
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00003BA1 File Offset: 0x00001DA1
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00003BA9 File Offset: 0x00001DA9
		public Dictionary<string, TypeTimingEntry> Timings { get; set; } = new Dictionary<string, TypeTimingEntry>();

		/// <summary>
		/// If true, at least one error was emitted during the hotload. Information about the error(s) can
		/// be found in <see cref="P:Sandbox.HotloadResult.Errors" />.
		/// </summary>
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00003BB2 File Offset: 0x00001DB2
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00003BBA File Offset: 0x00001DBA
		public bool HasErrors { get; set; }

		/// <summary>
		/// If true, at least one warning was emitted during the hotload. Information about the error(s) can
		/// be found in <see cref="P:Sandbox.HotloadResult.Errors" />.
		/// </summary>
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00003BC3 File Offset: 0x00001DC3
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00003BCB File Offset: 0x00001DCB
		public bool HasWarnings { get; set; }

		/// <summary>
		/// If true, the hotload was skipped because no replacement assemblies were specified since the last
		/// hotload.
		/// </summary>
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00003BD4 File Offset: 0x00001DD4
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00003BDC File Offset: 0x00001DDC
		public bool NoAction { get; set; }

		/// <summary>
		/// Total time elapsed during the hotload (in milliseconds)
		/// </summary>
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00003BE5 File Offset: 0x00001DE5
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00003BED File Offset: 0x00001DED
		public double ProcessingTime { get; set; }

		/// <summary>
		/// If true, no errors were emitted during the hotload.
		/// </summary>
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00003BF6 File Offset: 0x00001DF6
		public bool Success
		{
			get
			{
				return !this.HasErrors;
			}
		}

		/// <summary>
		/// Total number of instances processed during the hotload.
		/// </summary>
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600005F RID: 95 RVA: 0x00003C01 File Offset: 0x00001E01
		// (set) Token: 0x06000060 RID: 96 RVA: 0x00003C09 File Offset: 0x00001E09
		public int InstancesProcessed { get; set; }

		/// <summary>
		/// Retrieves all warnings, errors and other messages emitted during the hotload.
		/// </summary>
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00003C12 File Offset: 0x00001E12
		// (set) Token: 0x06000062 RID: 98 RVA: 0x00003C1A File Offset: 0x00001E1A
		public List<HotloadResultEntry> Entries { get; set; } = new List<HotloadResultEntry>();

		/// <summary>
		/// Types that were automatically determined to be safely skippable.
		/// </summary>
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00003C23 File Offset: 0x00001E23
		// (set) Token: 0x06000064 RID: 100 RVA: 0x00003C2B File Offset: 0x00001E2B
		public List<string> AutoSkippedTypes { get; set; } = new List<string>();

		/// <summary>
		/// Retrieves all information messages emitted during the hotload.
		/// </summary>
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00003C34 File Offset: 0x00001E34
		public IEnumerable<HotloadResultEntry> Messages
		{
			get
			{
				return this.Entries.Where((HotloadResultEntry x) => x.Type == HotloadEntryType.Information);
			}
		}

		/// <summary>
		/// Retrieves all error messages emitted during the hotload.
		/// </summary>
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000066 RID: 102 RVA: 0x00003C60 File Offset: 0x00001E60
		public IEnumerable<HotloadResultEntry> Errors
		{
			get
			{
				return this.Entries.Where((HotloadResultEntry x) => x.Type == HotloadEntryType.Error);
			}
		}

		/// <summary>
		/// Retrieves all warning messages emitted during the hotload.
		/// </summary>
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00003C8C File Offset: 0x00001E8C
		public IEnumerable<HotloadResultEntry> Warnings
		{
			get
			{
				return this.Entries.Where((HotloadResultEntry x) => x.Type == HotloadEntryType.Warning);
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00003CB8 File Offset: 0x00001EB8
		internal void AddEntry(HotloadResultEntry entry)
		{
			this.Entries.Add(entry);
			this.HasWarnings |= entry.Type == HotloadEntryType.Warning;
			this.HasErrors |= entry.Type == HotloadEntryType.Error;
		}
	}
}
