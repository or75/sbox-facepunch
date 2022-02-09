using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Sandbox
{
	// Token: 0x02000003 RID: 3
	internal static class StringExtensions
	{
		// Token: 0x06000009 RID: 9 RVA: 0x0000258F File Offset: 0x0000078F
		public static string QuoteSafe(this string str)
		{
			str = str.Replace("\"", "\\\"").TrimEnd(new char[] { '\\' });
			return "\"" + str + "\"";
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000025C4 File Offset: 0x000007C4
		public static string[] SplitQuotesStrings(this string input)
		{
			input = input.Replace("\\\"", "&qute;");
			MatchCollection collection = StringExtensions.splitregex.Matches(input);
			string[] strArray = new string[collection.Count];
			for (int i = 0; i < collection.Count; i++)
			{
				strArray[i] = collection[i].Groups[1].Value;
				strArray[i] = strArray[i].Replace("&qute;", "\"");
			}
			return strArray;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x0000263C File Offset: 0x0000083C
		public static decimal ToDecimal(this string str, [Optional] decimal Default = 0m)
		{
			decimal res = Default;
			if (!decimal.TryParse(str, out res))
			{
				return 0m;
			}
			return res;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x0000265C File Offset: 0x0000085C
		public static float ToFloat(this string str, float Default = 0f)
		{
			return (float)str.ToDecimal((decimal)Default);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002670 File Offset: 0x00000870
		public static uint ToUInt(this string str, int Default = 0)
		{
			decimal num = str.ToDecimal(Default);
			if (num <= 0m)
			{
				return 0U;
			}
			if (!(num >= 4294967295m))
			{
				return (uint)num;
			}
			return uint.MaxValue;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000026B0 File Offset: 0x000008B0
		public static int ToInt(this string str, int Default = 0)
		{
			decimal num = str.ToDecimal(Default);
			if (num <= -2147483648m)
			{
				return int.MinValue;
			}
			if (!(num >= 2147483647m))
			{
				return (int)num;
			}
			return int.MaxValue;
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002700 File Offset: 0x00000900
		public static bool ToBool(this string str)
		{
			float f;
			return str != null && str.Length != 0 && !(str == "0") && ((char.IsDigit(str[0]) && str[0] != '0') || (!str.Equals("false", StringComparison.OrdinalIgnoreCase) && !str.Equals("no", StringComparison.OrdinalIgnoreCase) && !str.Equals("null", StringComparison.OrdinalIgnoreCase) && (!float.TryParse(str, out f) || f != 0f)));
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000278D File Offset: 0x0000098D
		public static string Truncate(this string str, int maxLength, string appendage = null)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}
			if (str.Length <= maxLength)
			{
				return str;
			}
			if (appendage != null)
			{
				maxLength -= appendage.Length;
			}
			str = str.Substring(0, maxLength);
			if (appendage == null)
			{
				return str;
			}
			return str + appendage;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000027C8 File Offset: 0x000009C8
		public static string TruncateFilename(this string str, int maxLength, string appendage = null)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}
			if (str.Length <= maxLength)
			{
				return str;
			}
			maxLength -= 3;
			int loops = 0;
			while (loops++ < 100)
			{
				List<string> parts = str.Split(StringExtensions.FilenameDelim).ToList<string>();
				parts.RemoveRange(parts.Count - 1 - loops, loops);
				if (parts.Count == 1)
				{
					return parts.Last<string>();
				}
				parts.Insert(parts.Count - 1, "...");
				string final = string.Join("/", parts.ToArray());
				if (final.Length < maxLength)
				{
					return final;
				}
			}
			return str.Split(StringExtensions.FilenameDelim).ToList<string>().Last<string>();
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002874 File Offset: 0x00000A74
		public static bool Contains(this string source, string toCheck, StringComparison comp)
		{
			return source.IndexOf(toCheck, comp) >= 0;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002884 File Offset: 0x00000A84
		public static string VariableCase(this string source)
		{
			source = source.Replace('_', ' ');
			source = source.Replace('-', ' ');
			source = source.Replace('.', ' ');
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(source).Replace(" ", "");
		}

		// Token: 0x06000014 RID: 20 RVA: 0x000028D4 File Offset: 0x00000AD4
		public static string Snippet(this string source, string find, int padding)
		{
			if (string.IsNullOrEmpty(find))
			{
				return string.Empty;
			}
			StringBuilder sb = new StringBuilder();
			for (int index = 0; index < source.Length; index += find.Length)
			{
				index = source.IndexOf(find, index, StringComparison.InvariantCultureIgnoreCase);
				if (index == -1)
				{
					break;
				}
				int startPos = (index - padding).Clamp(0, source.Length);
				int endPos = (startPos + find.Length + padding * 2).Clamp(0, source.Length);
				index = endPos;
				if (sb.Length > 0)
				{
					sb.Append(" ... ");
				}
				sb.Append(source.Substring(startPos, endPos - startPos));
			}
			return sb.ToString();
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002970 File Offset: 0x00000B70
		public static string RemoveBadCharacters(this string str)
		{
			str = new string(str.Where((char x) => !StringExtensions._badCharacters.Contains(x)).ToArray<char>());
			return str;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000029A4 File Offset: 0x00000BA4
		public static string Base64Encode(this string plainText)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000029B8 File Offset: 0x00000BB8
		public static string Base64Decode(this string base64EncodedData)
		{
			byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(base64EncodedBytes);
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000029D8 File Offset: 0x00000BD8
		public static object ToType(this string str, Type t)
		{
			if (t == typeof(float))
			{
				return str.ToFloat(0f);
			}
			if (t == typeof(double))
			{
				return (double)str.ToFloat(0f);
			}
			if (t == typeof(uint))
			{
				return str.ToUInt(0);
			}
			if (t == typeof(int))
			{
				return str.ToInt(0);
			}
			if (t == typeof(bool))
			{
				return str.ToBool();
			}
			if (t == typeof(string))
			{
				return str;
			}
			throw new Exception("ToType - need to add the ability to change from string to " + ((t != null) ? t.ToString() : null));
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002AB8 File Offset: 0x00000CB8
		public static int FastHash(this string str)
		{
			uint hash = 2166136261U;
			foreach (byte b in Encoding.Unicode.GetBytes(str))
			{
				hash ^= (uint)b;
				hash *= 16777619U;
			}
			return (int)hash;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002AF8 File Offset: 0x00000CF8
		public static string Columnize(this string str, int maxLength, bool right = false)
		{
			if (string.IsNullOrEmpty(str))
			{
				return str;
			}
			if (str.Length >= maxLength)
			{
				return str.Substring(0, maxLength);
			}
			string spaces = new string(' ', maxLength - str.Length);
			if (right)
			{
				return spaces + str;
			}
			return str + spaces;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002B43 File Offset: 0x00000D43
		public static bool WildcardMatch(this string str, string wildcard)
		{
			wildcard = Regex.Escape(wildcard).Replace("\\*", ".*");
			wildcard = "&" + wildcard + "$";
			return Regex.IsMatch(str, wildcard);
		}

		// Token: 0x04000001 RID: 1
		private static Regex splitregex = new Regex("\"(?<1>[^\"]+)\"|'(?<1>[^']+)'|(?<1>\\S+)", RegexOptions.Compiled);

		// Token: 0x04000002 RID: 2
		private static char[] FilenameDelim = new char[] { '/', '\\' };

		// Token: 0x04000003 RID: 3
		private static readonly char[] _badCharacters = new char[]
		{
			'\0', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\a', '\b', '\t',
			'\v', '\f', '\r', '\u000e', '\u000f', '\u0010', '\u0012', '\u0013', '\u0014', '\u0016',
			'\u0017', '\u0018', '\u0019', '\u001a', '\u001b', '\u001c', '\u001d', '\u001e', '\u001f', '\u00a0',
			'\u00ad', '\u2000', '\u2001', '\u2002', '\u2003', '\u2004', '\u2005', '\u2006', '\u2007', '\u2008',
			'\u2009', '\u200a', '\u200b', '\u200c', '\u200d', '\u200e', '\u200f', '‐', '‑', '‒',
			'–', '—', '―', '‖', '‗', '‘', '’', '‚', '‛', '“',
			'”', '„', '‟', '\u2028', '\u2029', '\u202f', '\u205f', '\u2060', '␠', '␢',
			'␣', '\u3000', '\ufeff'
		};
	}
}
