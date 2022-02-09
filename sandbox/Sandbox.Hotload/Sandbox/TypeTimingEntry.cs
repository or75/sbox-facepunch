using System;
using System.Collections.Generic;

namespace Sandbox
{
	/// <summary>
	/// Holds information about the number of instances and total time taken when
	/// processing instances of a specific type.
	/// </summary>
	// Token: 0x0200000A RID: 10
	public class TypeTimingEntry : TimingEntry
	{
		/// <summary>
		/// The full names and instance count for each static field that instances were found under.
		/// Only populated if <see cref="P:Sandbox.Hotload.TraceRoots" /> is set to true.
		/// </summary>
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600004E RID: 78 RVA: 0x00003B60 File Offset: 0x00001D60
		public Dictionary<string, TimingEntry> Roots { get; }

		// Token: 0x0600004F RID: 79 RVA: 0x00003B68 File Offset: 0x00001D68
		internal TypeTimingEntry(bool traceRoots)
		{
			this.Roots = (traceRoots ? new Dictionary<string, TimingEntry>() : null);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003B81 File Offset: 0x00001D81
		public TypeTimingEntry()
		{
		}
	}
}
