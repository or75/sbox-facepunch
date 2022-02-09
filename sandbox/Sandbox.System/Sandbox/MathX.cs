using System;

namespace Sandbox
{
	/// <summary>
	/// A class to add functionality to the math library that System.Math and System.MathF don't provide.
	/// A lot of these methods are also extensions, so you can use for example `int i = 1.0f.FloorToInt();`
	/// </summary>
	// Token: 0x02000043 RID: 67
	public static class MathX
	{
		// Token: 0x06000316 RID: 790 RVA: 0x0000BE2B File Offset: 0x0000A02B
		public static float DegreeToRadian(this float f)
		{
			return f * 0.0174533f;
		}

		// Token: 0x06000317 RID: 791 RVA: 0x0000BE34 File Offset: 0x0000A034
		public static float RadianToDegree(this float f)
		{
			return f * 57.2958f;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x0000BE3D File Offset: 0x0000A03D
		public static float GradiansToDegrees(this float f)
		{
			return f * 0.9f;
		}

		// Token: 0x06000319 RID: 793 RVA: 0x0000BE46 File Offset: 0x0000A046
		public static float GradiansToRadians(this float f)
		{
			return f * 0.015707964f;
		}

		// Token: 0x0600031A RID: 794 RVA: 0x0000BE4F File Offset: 0x0000A04F
		public static float MeterToInch(this float f)
		{
			return f * 39.37008f;
		}

		// Token: 0x0600031B RID: 795 RVA: 0x0000BE58 File Offset: 0x0000A058
		public static float InchToMeter(this float f)
		{
			return f * 0.0254f;
		}

		// Token: 0x0600031C RID: 796 RVA: 0x0000BE61 File Offset: 0x0000A061
		public static float InchToMilimeter(this float f)
		{
			return f * 0.0393701f;
		}

		/// <summary>
		/// Snap number to grid
		/// </summary>
		// Token: 0x0600031D RID: 797 RVA: 0x0000BE6A File Offset: 0x0000A06A
		public static float SnapToGrid(this float f, float gridSize)
		{
			return MathF.Round(f / gridSize) * gridSize;
		}

		/// <summary>
		/// Remove the fractional part and return the float as an integer.
		/// </summary>
		// Token: 0x0600031E RID: 798 RVA: 0x0000BE76 File Offset: 0x0000A076
		public static int FloorToInt(this float f)
		{
			return (int)MathF.Floor(f);
		}

		// Token: 0x0600031F RID: 799 RVA: 0x0000BE7F File Offset: 0x0000A07F
		public static float Floor(this float f)
		{
			return MathF.Floor(f);
		}

		// Token: 0x06000320 RID: 800 RVA: 0x0000BE87 File Offset: 0x0000A087
		public static int CeilToInt(this float f)
		{
			return (int)MathF.Ceiling(f);
		}

		// Token: 0x06000321 RID: 801 RVA: 0x0000BE90 File Offset: 0x0000A090
		private static void Order(ref float a, ref float b)
		{
			if (a <= b)
			{
				return;
			}
			float c = a;
			a = b;
			b = c;
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0000BEAE File Offset: 0x0000A0AE
		public static float Clamp(this float v, float min, float max)
		{
			MathX.Order(ref min, ref max);
			if (v < min)
			{
				return min;
			}
			if (v >= max)
			{
				return max;
			}
			return v;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0000BEC6 File Offset: 0x0000A0C6
		public static float LerpTo(this float from, float to, float delta, bool clamp = true)
		{
			if (clamp)
			{
				delta = delta.Clamp(0f, 1f);
			}
			return from + delta * (to - from);
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0000BEE4 File Offset: 0x0000A0E4
		public static float[] LerpTo(this float[] from, float[] to, float delta, bool clamp = true)
		{
			if (from == null)
			{
				return null;
			}
			if (to == null)
			{
				return from;
			}
			float[] output = new float[Math.Min(from.Length, to.Length)];
			for (int i = 0; i < output.Length; i++)
			{
				output[i] = from[i].LerpTo(to[i], delta, clamp);
			}
			return output;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0000BF2B File Offset: 0x0000A12B
		public static float Approach(this float f, float target, float delta)
		{
			if (f > target)
			{
				f -= delta;
				if (f < target)
				{
					return target;
				}
			}
			else
			{
				f += delta;
				if (f > target)
				{
					return target;
				}
			}
			return f;
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0000BF48 File Offset: 0x0000A148
		public static float LerpInverse(this float value, float a, float b, bool clamp = true)
		{
			if (clamp)
			{
				value = value.Clamp(a, b);
			}
			value -= a;
			b -= a;
			return value / b;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0000BF64 File Offset: 0x0000A164
		public static bool AlmostEqual(this float value, float b, float within = 0.0001f)
		{
			return MathF.Abs(value - b) <= within;
		}

		/// <summary>
		/// Does what you expected to happen when you did "a % b"
		/// </summary>
		// Token: 0x06000328 RID: 808 RVA: 0x0000BF74 File Offset: 0x0000A174
		public static float UnsignedMod(this float a, float b)
		{
			return a - b * (a / b).Floor();
		}

		/// <summary>
		/// Convert angle to between 0 - 360
		/// </summary>
		// Token: 0x06000329 RID: 809 RVA: 0x0000BF82 File Offset: 0x0000A182
		public static float NormalizeDegrees(this float degree)
		{
			degree %= 360f;
			if (degree < 0f)
			{
				degree += 360f;
			}
			return degree;
		}

		/// <summary>
		/// Remap a float value from a one range to another
		/// </summary>
		// Token: 0x0600032A RID: 810 RVA: 0x0000BF9F File Offset: 0x0000A19F
		public static float Remap(this float value, float oldLow, float oldHigh, float newLow = 0f, float newHigh = 1f)
		{
			return newLow + (value - oldLow) * (newHigh - newLow) / (oldHigh - oldLow);
		}

		/// <summary>
		/// Remap an integer value from a one range to another
		/// </summary>
		// Token: 0x0600032B RID: 811 RVA: 0x0000BFAF File Offset: 0x0000A1AF
		public static int Remap(this int value, int oldLow, int oldHigh, int newLow, int newHigh)
		{
			return newLow + (value - oldLow) * (newHigh - newLow) / (oldHigh - oldLow);
		}

		// Token: 0x040000AF RID: 175
		internal const float toDegrees = 57.2958f;

		// Token: 0x040000B0 RID: 176
		internal const float toRadians = 0.0174533f;

		// Token: 0x040000B1 RID: 177
		internal const float toGradiansDegrees = 0.9f;

		// Token: 0x040000B2 RID: 178
		internal const float toGradiansRadians = 0.015707964f;

		// Token: 0x040000B3 RID: 179
		internal const float toMeters = 0.0254f;

		// Token: 0x040000B4 RID: 180
		internal const float toInches = 39.37008f;

		// Token: 0x040000B5 RID: 181
		internal const float toMilimeters = 0.0393701f;
	}
}
