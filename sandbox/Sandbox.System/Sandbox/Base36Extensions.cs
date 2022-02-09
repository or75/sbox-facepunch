using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox
{
	// Token: 0x0200003E RID: 62
	public static class Base36Extensions
	{
		/// <summary>
		/// Encode the given number into a Base36 string
		/// </summary>
		// Token: 0x06000301 RID: 769 RVA: 0x0000BB94 File Offset: 0x00009D94
		public static string ToBase36<T>(this T i) where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
		{
			long input = (long)Convert.ToDecimal(i);
			if (input < 0L)
			{
				throw new ArgumentOutOfRangeException("input", input, "input cannot be negative");
			}
			char[] clistarr = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
			Stack<char> result = new Stack<char>();
			while (input != 0L)
			{
				result.Push(clistarr[(int)(checked((IntPtr)(input % 36L)))]);
				input /= 36L;
			}
			return new string(result.ToArray());
		}

		/// <summary>
		/// Decode the Base36 Encoded string into a number
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		// Token: 0x06000302 RID: 770 RVA: 0x0000BC04 File Offset: 0x00009E04
		public static long FromBase36(this string input)
		{
			IEnumerable<char> enumerable = input.ToLower().Reverse<char>();
			long result = 0L;
			int pos = 0;
			foreach (char c in enumerable)
			{
				result += (long)"0123456789abcdefghijklmnopqrstuvwxyz".IndexOf(c) * (long)Math.Pow(36.0, (double)pos);
				pos++;
			}
			return result;
		}

		// Token: 0x040000AC RID: 172
		private const string CharList = "0123456789abcdefghijklmnopqrstuvwxyz";

		// Token: 0x040000AD RID: 173
		private static char[] CharArray = "0123456789abcdefghijklmnopqrstuvwxyz".ToCharArray();
	}
}
