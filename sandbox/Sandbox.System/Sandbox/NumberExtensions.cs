using System;

namespace Sandbox
{
	// Token: 0x02000044 RID: 68
	public static class NumberExtensions
	{
		/// <summary>
		/// Given a number, will format as a memory value, ie 10gb, 4mb
		/// </summary>
		// Token: 0x0600032C RID: 812 RVA: 0x0000BFC0 File Offset: 0x0000A1C0
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

		/// <summary>
		/// Clamp a number between two values
		/// </summary>
		// Token: 0x0600032D RID: 813 RVA: 0x0000C0BA File Offset: 0x0000A2BA
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

		// Token: 0x0600032E RID: 814 RVA: 0x0000C0E3 File Offset: 0x0000A2E3
		public static string FormatSeconds(this ulong i)
		{
			return ((long)i).FormatSeconds();
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0000C0EC File Offset: 0x0000A2EC
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

		// Token: 0x06000330 RID: 816 RVA: 0x0000C2BD File Offset: 0x0000A4BD
		public static string FormatSecondsLong(this ulong i)
		{
			return ((long)i).FormatSecondsLong();
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000C2C8 File Offset: 0x0000A4C8
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

		// Token: 0x06000332 RID: 818 RVA: 0x0000C48F File Offset: 0x0000A68F
		public static string FormatNumberShort(this ulong i)
		{
			return ((long)i).FormatNumberShort();
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000C498 File Offset: 0x0000A698
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

		/// <summary>
		/// Does what you expected to happen when you did "a % b"
		/// </summary>
		// Token: 0x06000334 RID: 820 RVA: 0x0000C4FF File Offset: 0x0000A6FF
		public static int UnsignedMod(this int a, int b)
		{
			return (Math.Abs(a * b) + a) % b;
		}

		/// <summary>
		/// Returns the number of bits set in an integer. This us usually used for flags to count
		/// the amount of flags set.
		/// </summary>
		// Token: 0x06000335 RID: 821 RVA: 0x0000C50D File Offset: 0x0000A70D
		public static int BitsSet(this int i)
		{
			i -= (i >> 1) & 1431655765;
			i = (i & 858993459) + ((i >> 2) & 858993459);
			i = (i + (i >> 4)) & 252645135;
			return i * 16843009 >> 24;
		}

		/// <summary>
		/// Return single if 1 else plural
		/// </summary>
		// Token: 0x06000336 RID: 822 RVA: 0x0000C546 File Offset: 0x0000A746
		public static string Plural(this int a, string single, string plural)
		{
			if (a == 1)
			{
				return single;
			}
			if (a == -1)
			{
				return single;
			}
			return plural;
		}

		/// <summary>
		/// Change 1 to 1st, 2 to 2nd etc
		/// </summary>
		// Token: 0x06000337 RID: 823 RVA: 0x0000C558 File Offset: 0x0000A758
		public static string FormatWithSuffix(this int num)
		{
			string number = num.ToString();
			if (number.EndsWith("11"))
			{
				return number + "th";
			}
			if (number.EndsWith("12"))
			{
				return number + "th";
			}
			if (number.EndsWith("13"))
			{
				return number + "th";
			}
			if (number.EndsWith("1"))
			{
				return number + "st";
			}
			if (number.EndsWith("2"))
			{
				return number + "nd";
			}
			if (number.EndsWith("3"))
			{
				return number + "rd";
			}
			return number + "th";
		}
	}
}
