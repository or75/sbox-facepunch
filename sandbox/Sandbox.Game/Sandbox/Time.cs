using System;
using NativeGlue;

namespace Sandbox
{
	// Token: 0x020000F8 RID: 248
	public class Time
	{
		/// <summary>
		/// The time since game startup
		/// </summary>
		// Token: 0x1700030F RID: 783
		// (get) Token: 0x0600148B RID: 5259 RVA: 0x000525DB File Offset: 0x000507DB
		// (set) Token: 0x0600148C RID: 5260 RVA: 0x000525E2 File Offset: 0x000507E2
		public static float Now { get; set; }

		/// <summary>
		/// The delta between the last frame and the current (for all intents and purposes)
		/// </summary>
		// Token: 0x17000310 RID: 784
		// (get) Token: 0x0600148D RID: 5261 RVA: 0x000525EA File Offset: 0x000507EA
		// (set) Token: 0x0600148E RID: 5262 RVA: 0x000525F1 File Offset: 0x000507F1
		public static float Delta { get; set; }

		/// <summary>
		/// The current tick number that is being simulated.
		/// </summary>
		// Token: 0x17000311 RID: 785
		// (get) Token: 0x0600148F RID: 5263 RVA: 0x000525F9 File Offset: 0x000507F9
		// (set) Token: 0x06001490 RID: 5264 RVA: 0x00052600 File Offset: 0x00050800
		public static int Tick { get; set; }

		/// <summary>
		/// Gets the current DSP time
		/// </summary>
		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06001491 RID: 5265 RVA: 0x00052608 File Offset: 0x00050808
		public static double Sound
		{
			get
			{
				return GameSoundManager.AudioStateHostTime();
			}
		}

		/// <summary>
		/// Gets the current delta between two DSP frames
		/// </summary>
		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06001492 RID: 5266 RVA: 0x0005260F File Offset: 0x0005080F
		public static double SoundDelta
		{
			get
			{
				return GameSoundManager.AudioStateFrameTime();
			}
		}

		// Token: 0x06001493 RID: 5267 RVA: 0x00052616 File Offset: 0x00050816
		internal static void Update(float time, float delta, int tickCount)
		{
			Time.Now = time;
			Time.Delta = delta;
			Time.Tick = tickCount;
		}
	}
}
