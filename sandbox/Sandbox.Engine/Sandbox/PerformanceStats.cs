using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Sandbox
{
	// Token: 0x020002BB RID: 699
	public static class PerformanceStats
	{
		/// <summary>
		/// Get the time taken, in seconds, that were required to process the previous frame.
		/// </summary>
		// Token: 0x17000350 RID: 848
		// (get) Token: 0x060011AF RID: 4527 RVA: 0x00023B5D File Offset: 0x00021D5D
		// (set) Token: 0x060011B0 RID: 4528 RVA: 0x00023B64 File Offset: 0x00021D64
		public static double FrameTime { get; internal set; }

		/// <summary>
		/// The number of bytes that were allocated on the managed heap in the last frame.
		/// <remarks>This may not include allocations from threads other than the game thread.</remarks>
		/// </summary>
		// Token: 0x17000351 RID: 849
		// (get) Token: 0x060011B1 RID: 4529 RVA: 0x00023B6C File Offset: 0x00021D6C
		// (set) Token: 0x060011B2 RID: 4530 RVA: 0x00023B73 File Offset: 0x00021D73
		public static long BytesAllocated { get; internal set; }

		/// <summary>
		/// Number of generation 0 (fastest) garbage collections were done in the last frame.
		/// </summary>
		// Token: 0x17000352 RID: 850
		// (get) Token: 0x060011B3 RID: 4531 RVA: 0x00023B7B File Offset: 0x00021D7B
		// (set) Token: 0x060011B4 RID: 4532 RVA: 0x00023B82 File Offset: 0x00021D82
		public static int Gen0Collections { get; internal set; }

		/// <summary>
		/// Number of generation 1 (fast) garbage collections were done in the last frame.
		/// </summary>
		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060011B5 RID: 4533 RVA: 0x00023B8A File Offset: 0x00021D8A
		// (set) Token: 0x060011B6 RID: 4534 RVA: 0x00023B91 File Offset: 0x00021D91
		public static int Gen1Collections { get; internal set; }

		/// <summary>
		/// Number of generation 2 (slow) garbage collections were done in the last frame.
		/// </summary>
		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060011B7 RID: 4535 RVA: 0x00023B99 File Offset: 0x00021D99
		// (set) Token: 0x060011B8 RID: 4536 RVA: 0x00023BA0 File Offset: 0x00021DA0
		public static int Gen2Collections { get; internal set; }

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x060011B9 RID: 4537 RVA: 0x00023BA8 File Offset: 0x00021DA8
		// (set) Token: 0x060011BA RID: 4538 RVA: 0x00023BAF File Offset: 0x00021DAF
		public static PerformanceStats.Block LastSecond { get; internal set; }

		// Token: 0x060011BB RID: 4539 RVA: 0x00023BB8 File Offset: 0x00021DB8
		internal static bool Frame()
		{
			if (PerformanceStats._frameTimer == null)
			{
				PerformanceStats._frameTimer = Stopwatch.StartNew();
			}
			if (PerformanceStats._secondTimer == null)
			{
				PerformanceStats._secondTimer = Stopwatch.StartNew();
			}
			float frameMs = (float)PerformanceStats._frameTimer.Elapsed.TotalMilliseconds;
			PerformanceStats.FrameTime = PerformanceStats._frameTimer.Elapsed.TotalSeconds;
			PerformanceStats._frameTimer.Restart();
			long monitoringTotalAllocatedMemorySize = AppDomain.CurrentDomain.MonitoringTotalAllocatedMemorySize;
			PerformanceStats.BytesAllocated = monitoringTotalAllocatedMemorySize - PerformanceStats._prevAllocatedBytes;
			PerformanceStats._prevAllocatedBytes = monitoringTotalAllocatedMemorySize;
			int num = GC.CollectionCount(0);
			int gen = GC.CollectionCount(1);
			int gen2 = GC.CollectionCount(2);
			PerformanceStats.Gen0Collections = num - PerformanceStats._prevGen0;
			PerformanceStats.Gen1Collections = gen - PerformanceStats._prevGen1;
			PerformanceStats.Gen2Collections = gen2 - PerformanceStats._prevGen2;
			PerformanceStats._prevGen0 = num;
			PerformanceStats._prevGen1 = gen;
			PerformanceStats._prevGen2 = gen2;
			if (PerformanceStats.perf_time < 0f)
			{
				return false;
			}
			PerformanceStats._history.Add(new PerformanceStats.Block
			{
				FrameAvg = frameMs,
				ByteAlloc = (int)PerformanceStats.BytesAllocated,
				Gc0 = PerformanceStats.Gen0Collections,
				Gc1 = PerformanceStats.Gen1Collections,
				Gc2 = PerformanceStats.Gen2Collections
			});
			if (PerformanceStats._secondTimer.Elapsed.TotalMilliseconds < (double)PerformanceStats.perf_time)
			{
				return false;
			}
			PerformanceStats.Block ls = default(PerformanceStats.Block);
			ls.FrameAvg = PerformanceStats._history.Average((PerformanceStats.Block x) => x.FrameAvg);
			ls.FrameMin = PerformanceStats._history.Min((PerformanceStats.Block x) => x.FrameAvg);
			ls.FrameMax = PerformanceStats._history.Max((PerformanceStats.Block x) => x.FrameAvg);
			ls.ByteAlloc = PerformanceStats._history.Sum((PerformanceStats.Block x) => x.ByteAlloc);
			ls.Gc0 = PerformanceStats._history.Sum((PerformanceStats.Block x) => x.Gc0);
			ls.Gc1 = PerformanceStats._history.Sum((PerformanceStats.Block x) => x.Gc1);
			ls.Gc2 = PerformanceStats._history.Sum((PerformanceStats.Block x) => x.Gc2);
			ls.Mem = AppDomain.MonitoringSurvivedProcessMemorySize;
			PerformanceStats.LastSecond = ls;
			PerformanceStats._history.Clear();
			PerformanceStats._secondTimer.Restart();
			return true;
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x060011BC RID: 4540 RVA: 0x00023E79 File Offset: 0x00022079
		// (set) Token: 0x060011BD RID: 4541 RVA: 0x00023E80 File Offset: 0x00022080
		[ConsoleVariable(null)]
		public static float perf_time { get; set; } = 33.333332f;

		// Token: 0x060011BE RID: 4542 RVA: 0x00023E88 File Offset: 0x00022088
		internal static void FrameStage(double time, GameLoopStage stage, bool start)
		{
		}

		// Token: 0x0400140B RID: 5131
		private static Stopwatch _frameTimer;

		// Token: 0x0400140C RID: 5132
		private static Stopwatch _secondTimer;

		// Token: 0x0400140D RID: 5133
		private static List<PerformanceStats.Block> _history = new List<PerformanceStats.Block>(1024);

		// Token: 0x0400140E RID: 5134
		private static long _prevAllocatedBytes;

		// Token: 0x0400140F RID: 5135
		private static int _prevGen0;

		// Token: 0x04001410 RID: 5136
		private static int _prevGen1;

		// Token: 0x04001411 RID: 5137
		private static int _prevGen2;

		// Token: 0x0200040C RID: 1036
		public struct Block
		{
			// Token: 0x04001A2F RID: 6703
			public float FrameAvg;

			// Token: 0x04001A30 RID: 6704
			public float FrameMin;

			// Token: 0x04001A31 RID: 6705
			public float FrameMax;

			// Token: 0x04001A32 RID: 6706
			public int ByteAlloc;

			// Token: 0x04001A33 RID: 6707
			public int Gc0;

			// Token: 0x04001A34 RID: 6708
			public int Gc1;

			// Token: 0x04001A35 RID: 6709
			public int Gc2;

			// Token: 0x04001A36 RID: 6710
			public long Mem;
		}
	}
}
