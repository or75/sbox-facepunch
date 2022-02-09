using System;
using System.Diagnostics;

namespace Sandbox
{
	// Token: 0x0200004F RID: 79
	public static class RealTime
	{
		/// <summary>
		/// The time since game startup
		/// </summary>
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x060003A4 RID: 932 RVA: 0x0000DD74 File Offset: 0x0000BF74
		public static float Now
		{
			get
			{
				return (float)RealTime.timeMeasure.Elapsed.TotalSeconds;
			}
		}

		/// <summary>
		/// The delta between the last frame and the current (for all intents and purposes)
		/// </summary>
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x0000DD94 File Offset: 0x0000BF94
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x0000DD9B File Offset: 0x0000BF9B
		public static float Delta { get; internal set; }

		// Token: 0x060003A7 RID: 935 RVA: 0x0000DDA3 File Offset: 0x0000BFA3
		internal static void Update(float now)
		{
			if (RealTime.LastTick > 0f)
			{
				RealTime.Delta = (now - RealTime.LastTick).Clamp(0f, 2f);
			}
			RealTime.LastTick = now;
		}

		// Token: 0x040000D1 RID: 209
		private static Stopwatch timeMeasure = Stopwatch.StartNew();

		// Token: 0x040000D3 RID: 211
		private static float LastTick;
	}
}
