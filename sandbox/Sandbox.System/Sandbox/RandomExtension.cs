using System;
using System.Collections.Generic;

namespace Sandbox
{
	// Token: 0x02000045 RID: 69
	public static class RandomExtension
	{
		/// <summary>
		/// Returns a double between min and max
		/// </summary>
		// Token: 0x06000338 RID: 824 RVA: 0x0000C60E File Offset: 0x0000A80E
		public static double Double(this Random self, double min, double max)
		{
			return min + (max - min) * self.NextDouble();
		}

		/// <summary>
		/// Returns a random float between min and max
		/// </summary>
		// Token: 0x06000339 RID: 825 RVA: 0x0000C61C File Offset: 0x0000A81C
		public static float Float(this Random self, float min, float max)
		{
			return min + (max - min) * (float)self.NextDouble();
		}

		/// <summary>
		/// Returns a random float between 0 and max (or 1)
		/// </summary>
		// Token: 0x0600033A RID: 826 RVA: 0x0000C62B File Offset: 0x0000A82B
		public static float Float(this Random self, float max = 1f)
		{
			return self.Float(0f, max);
		}

		/// <summary>
		/// Returns a random double between 0 and max (or 1)
		/// </summary>
		// Token: 0x0600033B RID: 827 RVA: 0x0000C639 File Offset: 0x0000A839
		public static double Double(Random self, double max = 1.0)
		{
			return self.Double(0.0, max);
		}

		/// <summary>
		/// Returns a random int between min and max (inclusive)
		/// </summary>
		// Token: 0x0600033C RID: 828 RVA: 0x0000C64B File Offset: 0x0000A84B
		public static int Int(this Random self, int min, int max)
		{
			return self.Next(min, max + 1);
		}

		/// <summary>
		/// Returns a random int between 0 and max (inclusive)
		/// </summary>
		// Token: 0x0600033D RID: 829 RVA: 0x0000C657 File Offset: 0x0000A857
		public static int Int(this Random self, int max)
		{
			return self.Int(0, max);
		}

		/// <summary>
		/// Returns a random Color
		/// </summary>
		// Token: 0x0600033E RID: 830 RVA: 0x0000C664 File Offset: 0x0000A864
		public static Color Color(this Random self)
		{
			float h = self.Float(0f, 255f);
			float s = 0f;
			float brightness = 255f * 1.4f / 255f;
			brightness *= 0.7f / (0.01f + (float)Math.Sqrt((double)brightness));
			brightness = Math.Clamp(brightness, 0f, 1f);
			Vector3 hue = ((h < 86f) ? new Vector3((85f - h) / 85f, (h - 0f) / 85f, 0f) : ((h < 171f) ? new Vector3(0f, (170f - h) / 85f, (h - 85f) / 85f) : new Vector3((h - 170f) / 85f, 0f, (255f - h) / 84f)));
			Vector3 color = (hue + s / 255f * (Vector3.One - hue)) * brightness;
			return new Color(color.x, color.y, color.z, 1f);
		}

		/// <summary>
		/// Returns a random value in an array
		/// </summary>
		// Token: 0x0600033F RID: 831 RVA: 0x0000C787 File Offset: 0x0000A987
		public static T FromArray<T>(this Random self, T[] array, T defVal = default(T))
		{
			if (array == null || array.Length == 0)
			{
				return defVal;
			}
			return array[self.Next(0, array.Length)];
		}

		/// <summary>
		/// Returns a random value in a list
		/// </summary>
		// Token: 0x06000340 RID: 832 RVA: 0x0000C7A2 File Offset: 0x0000A9A2
		public static T FromList<T>(this Random self, List<T> array, T defVal = default(T))
		{
			if (array == null || array.Count == 0)
			{
				return defVal;
			}
			return array[self.Next(0, array.Count)];
		}
	}
}
