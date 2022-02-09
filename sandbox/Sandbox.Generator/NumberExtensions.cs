using System;

namespace Sandbox
{
	// Token: 0x02000002 RID: 2
	internal static class NumberExtensions
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static string FormatBytes<T>(this T input, bool shortFormat = false) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
		{
			ulong i = (ulong)Convert.ChangeType(input, typeof(ulong));
			double readable = i;
			string suffix;
			if (i >= 1152921504606846976UL)
			{
				suffix = "eb";
				readable = i >> 50;
			}
			else if (i >= 1125899906842624UL)
			{
				suffix = "pb";
				readable = i >> 40;
			}
			else if (i >= 1099511627776UL)
			{
				suffix = "tb";
				readable = i >> 30;
			}
			else if (i >= 1073741824UL)
			{
				suffix = "gb";
				readable = i >> 20;
			}
			else if (i >= 1048576UL)
			{
				suffix = "mb";
				readable = i >> 10;
			}
			else
			{
				if (i < 1024UL)
				{
					return i.ToString("0b");
				}
				suffix = "kb";
				readable = i;
			}
			readable /= 1024.0;
			return readable.ToString(shortFormat ? "0" : "0.00") + suffix;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000214A File Offset: 0x0000034A
		public static T Clamp<T>(this T input, T min, T max) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
		{
			if (input.CompareTo(min) < 0)
			{
				return min;
			}
			if (input.CompareTo(max) > 0)
			{
				return max;
			}
			return input;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002173 File Offset: 0x00000373
		public static string FormatSeconds(this ulong i)
		{
			return ((long)i).FormatSeconds();
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000217C File Offset: 0x0000037C
		public static string FormatSeconds(this long s)
		{
			double i = Math.Floor((double)((float)s / 60f));
			double h = Math.Floor((double)((float)i / 60f));
			double d = Math.Floor((double)((float)h / 24f));
			double w = Math.Floor((double)((float)d / 7f));
			if (s < 60L)
			{
				return string.Format("{0}s", s);
			}
			if (i < 60.0)
			{
				return string.Format("{1}m{0}s", new object[]
				{
					s % 60L,
					i,
					h,
					d,
					w
				});
			}
			if (h < 48.0)
			{
				return string.Format("{2}h{1}m{0}s", new object[]
				{
					s % 60L,
					i % 60.0,
					h,
					d,
					w
				});
			}
			if (d < 7.0)
			{
				return string.Format("{3}d{2}h{1}m{0}s", new object[]
				{
					s % 60L,
					i % 60.0,
					h % 24.0,
					d % 7.0,
					w
				});
			}
			return string.Format("{4}w{3}d{2}h{1}m{0}s", new object[]
			{
				s % 60L,
				i % 60.0,
				h % 24.0,
				d % 7.0,
				w
			});
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000234D File Offset: 0x0000054D
		public static string FormatSecondsLong(this ulong i)
		{
			return ((long)i).FormatSecondsLong();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002358 File Offset: 0x00000558
		public static string FormatSecondsLong(this long s)
		{
			double i = Math.Floor((double)((float)s / 60f));
			double h = Math.Floor((double)((float)i / 60f));
			double d = Math.Floor((double)((float)h / 24f));
			double w = Math.Floor((double)((float)d / 7f));
			if (s < 60L)
			{
				return string.Format("{0} seconds", s);
			}
			if (i < 60.0)
			{
				return string.Format("{1} minutes, {0} seconds", new object[]
				{
					s % 60L,
					i,
					h,
					d,
					w
				});
			}
			if (h < 48.0)
			{
				return string.Format("{2} hours and {1} minutes", new object[]
				{
					s % 60L,
					i % 60.0,
					h,
					d,
					w
				});
			}
			if (d < 7.0)
			{
				return string.Format("{3} days, {2} hours and {1} minutes", new object[]
				{
					s % 60L,
					i % 60.0,
					h % 24.0,
					d % 7.0,
					w
				});
			}
			return string.Format("{3} days, {2} hours and {1} minutes", new object[]
			{
				s % 60L,
				i % 60.0,
				h % 24.0,
				d,
				w
			});
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000251F File Offset: 0x0000071F
		public static string FormatNumberShort(this ulong i)
		{
			return ((long)i).FormatNumberShort();
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002528 File Offset: 0x00000728
		public static string FormatNumberShort(this long num)
		{
			if (num >= 100000L)
			{
				return (num / 1000L).FormatNumberShort() + "K";
			}
			if (num >= 10000L)
			{
				return ((double)num / 1000.0).ToString("0.#") + "K";
			}
			return num.ToString("#,0");
		}
	}
}
