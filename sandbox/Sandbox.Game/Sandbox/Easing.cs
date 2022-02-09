using System;
using System.Collections.Generic;

namespace Sandbox
{
	/// <summary>
	/// Easing functions used for transitions
	/// </summary>
	// Token: 0x020000FF RID: 255
	public static class Easing
	{
		// Token: 0x060014E6 RID: 5350 RVA: 0x00053818 File Offset: 0x00051A18
		public static float EaseInOut(float f)
		{
			return Easing.ExpoInOut(f);
		}

		// Token: 0x060014E7 RID: 5351 RVA: 0x00053820 File Offset: 0x00051A20
		public static float EaseIn(float f)
		{
			return Easing.QuadraticIn(f);
		}

		// Token: 0x060014E8 RID: 5352 RVA: 0x00053828 File Offset: 0x00051A28
		public static float EaseOut(float f)
		{
			return Easing.QuadraticOut(f);
		}

		// Token: 0x060014E9 RID: 5353 RVA: 0x00053830 File Offset: 0x00051A30
		public static float Linear(float f)
		{
			return f;
		}

		// Token: 0x060014EA RID: 5354 RVA: 0x00053833 File Offset: 0x00051A33
		public static float QuadraticIn(float f)
		{
			return f * f;
		}

		// Token: 0x060014EB RID: 5355 RVA: 0x00053838 File Offset: 0x00051A38
		public static float QuadraticOut(float f)
		{
			return f * (2f - f);
		}

		// Token: 0x060014EC RID: 5356 RVA: 0x00053843 File Offset: 0x00051A43
		public static float QuadraticInOut(float f)
		{
			if ((f *= 2f) >= 1f)
			{
				return -0.5f * ((f -= 1f) * (f - 2f) - 1f);
			}
			return 0.5f * f * f;
		}

		// Token: 0x060014ED RID: 5357 RVA: 0x0005387E File Offset: 0x00051A7E
		public static float ExpoIn(float f)
		{
			if (f != 0f)
			{
				return MathF.Pow(1024f, f - 1f);
			}
			return 0f;
		}

		// Token: 0x060014EE RID: 5358 RVA: 0x0005389F File Offset: 0x00051A9F
		public static float ExpoOut(float f)
		{
			if (f != 1f)
			{
				return 1f - MathF.Pow(2f, -10f * f);
			}
			return 1f;
		}

		// Token: 0x060014EF RID: 5359 RVA: 0x000538C6 File Offset: 0x00051AC6
		public static float ExpoInOut(float f)
		{
			if ((double)f >= 0.5)
			{
				return Easing.ExpoOut((f - 0.5f) * 2f) * 0.5f + 0.5f;
			}
			return Easing.ExpoIn(f * 2f) * 0.5f;
		}

		// Token: 0x060014F0 RID: 5360 RVA: 0x00053906 File Offset: 0x00051B06
		public static float BounceIn(float f)
		{
			return 1f - Easing.BounceOut(1f - f);
		}

		// Token: 0x060014F1 RID: 5361 RVA: 0x0005391C File Offset: 0x00051B1C
		public static float BounceOut(float f)
		{
			if (f < 0.36363637f)
			{
				return 7.5625f * f * f;
			}
			if (f < 0.72727275f)
			{
				return 7.5625f * (f -= 0.54545456f) * f + 0.75f;
			}
			if (f >= 0.90909094f)
			{
				return 7.5625f * (f -= 0.95454544f) * f + 0.984375f;
			}
			return 7.5625f * (f -= 0.8181818f) * f + 0.9375f;
		}

		// Token: 0x060014F2 RID: 5362 RVA: 0x00053995 File Offset: 0x00051B95
		public static float BounceInOut(float f)
		{
			if ((double)f >= 0.5)
			{
				return Easing.BounceOut((f - 0.5f) * 2f) * 0.5f + 0.5f;
			}
			return Easing.BounceIn(f * 2f) * 0.5f;
		}

		/// <summary>
		/// Add an easing function. 
		/// If the function already exists we silently return.
		/// </summary>
		// Token: 0x060014F3 RID: 5363 RVA: 0x000539D5 File Offset: 0x00051BD5
		internal static void AddFunction(string name, Easing.Function func)
		{
			if (Easing._functions.ContainsKey(name))
			{
				return;
			}
			Easing._functions[name] = func;
		}

		/// <summary>
		/// Get an easing function by name (ie, "ease-in").
		/// If the function doesn't exist we return QuadraticInOut
		/// </summary>
		// Token: 0x060014F4 RID: 5364 RVA: 0x000539F4 File Offset: 0x00051BF4
		internal static Easing.Function GetFunction(string name)
		{
			Easing.Function f;
			if (Easing._functions.TryGetValue(name, out f))
			{
				return f;
			}
			return new Easing.Function(Easing.QuadraticInOut);
		}

		// Token: 0x040004E1 RID: 1249
		private static Dictionary<string, Easing.Function> _functions = new Dictionary<string, Easing.Function>
		{
			{
				"linear",
				new Easing.Function(Easing.Linear)
			},
			{
				"ease",
				new Easing.Function(Easing.QuadraticInOut)
			},
			{
				"ease-in-out",
				new Easing.Function(Easing.ExpoInOut)
			},
			{
				"ease-out",
				new Easing.Function(Easing.EaseOut)
			},
			{
				"ease-in",
				new Easing.Function(Easing.QuadraticIn)
			},
			{
				"bounce-in",
				new Easing.Function(Easing.BounceIn)
			},
			{
				"bounce-out",
				new Easing.Function(Easing.BounceOut)
			},
			{
				"bounce-in-out",
				new Easing.Function(Easing.BounceInOut)
			}
		};

		/// <summary>
		/// An easing function that transforms the linear input into non linear output.
		/// </summary>
		/// <param name="delta">A linear input value from 0 to 1</param>
		/// <returns>The resulting non linear output value, from 0 to 1</returns>
		// Token: 0x0200026A RID: 618
		// (Invoke) Token: 0x06001EEB RID: 7915
		public delegate float Function(float delta);
	}
}
