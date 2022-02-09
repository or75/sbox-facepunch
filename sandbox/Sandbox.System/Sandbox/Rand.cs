using System;
using System.Collections.Generic;

namespace Sandbox
{
	/// <summary>
	/// Provide unseeded random values
	/// </summary>
	// Token: 0x0200005A RID: 90
	public static class Rand
	{
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x0001E752 File Offset: 0x0001C952
		private static Random CurrentRandom
		{
			get
			{
				if (Rand._random == null)
				{
					Rand._random = new Random();
				}
				return Rand._random;
			}
		}

		/// <summary>
		/// Sets the seed for these static classes
		/// </summary>
		// Token: 0x060003EA RID: 1002 RVA: 0x0001E76A File Offset: 0x0001C96A
		public static void SetSeed(int seed)
		{
			Rand._random = new Random(seed);
		}

		/// <summary>
		/// Returns a double between min and max
		/// </summary>
		// Token: 0x060003EB RID: 1003 RVA: 0x0001E777 File Offset: 0x0001C977
		public static double Double(double min, double max)
		{
			return Rand.CurrentRandom.Double(min, max);
		}

		/// <summary>
		/// Returns a random float between min and max
		/// </summary>
		// Token: 0x060003EC RID: 1004 RVA: 0x0001E785 File Offset: 0x0001C985
		public static float Float(float min, float max)
		{
			return Rand.CurrentRandom.Float(min, max);
		}

		/// <summary>
		/// Returns a random float between 0 and max (or 1)
		/// </summary>
		// Token: 0x060003ED RID: 1005 RVA: 0x0001E793 File Offset: 0x0001C993
		public static float Float(float max = 1f)
		{
			return Rand.Float(0f, max);
		}

		/// <summary>
		/// Returns a random double between 0 and max (or 1)
		/// </summary>
		// Token: 0x060003EE RID: 1006 RVA: 0x0001E7A0 File Offset: 0x0001C9A0
		public static double Double(double max = 1.0)
		{
			return Rand.Double(0.0, max);
		}

		/// <summary>
		/// Returns a random int between min and max (inclusive)
		/// </summary>
		// Token: 0x060003EF RID: 1007 RVA: 0x0001E7B1 File Offset: 0x0001C9B1
		public static int Int(int min, int max)
		{
			return Rand.CurrentRandom.Next(min, max + 1);
		}

		/// <summary>
		/// Returns a random int between 0 and max (inclusive)
		/// </summary>
		// Token: 0x060003F0 RID: 1008 RVA: 0x0001E7C1 File Offset: 0x0001C9C1
		public static int Int(int max)
		{
			return Rand.Int(0, max);
		}

		/// <summary>
		/// Returns a random Color
		/// </summary>
		// Token: 0x060003F1 RID: 1009 RVA: 0x0001E7CA File Offset: 0x0001C9CA
		public static Color Color()
		{
			return Rand.CurrentRandom.Color();
		}

		/// <summary>
		/// Returns a random value in an array
		/// </summary>
		// Token: 0x060003F2 RID: 1010 RVA: 0x0001E7D6 File Offset: 0x0001C9D6
		public static T FromArray<T>(T[] array, T defVal = default(T))
		{
			return Rand.CurrentRandom.FromArray(array, defVal);
		}

		/// <summary>
		/// Returns a random value in a list
		/// </summary>
		// Token: 0x060003F3 RID: 1011 RVA: 0x0001E7E4 File Offset: 0x0001C9E4
		public static T FromList<T>(List<T> array, T defVal = default(T))
		{
			return Rand.CurrentRandom.FromList(array, defVal);
		}

		// Token: 0x040008CC RID: 2252
		[ThreadStatic]
		private static Random _random;
	}
}
