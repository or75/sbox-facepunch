using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// A class to add functionality to the string library.
	/// A lot of these methods are also extensions, so you can use for example `str safe = badstring.QuoteSafe()`
	/// </summary>
	// Token: 0x02000048 RID: 72
	public static class StringX
	{
		/// <summary>
		/// Puts quote marks around a string. Internal quotes are backslashed.
		/// </summary>
		// Token: 0x0600034B RID: 843 RVA: 0x0000C980 File Offset: 0x0000AB80
		public static string QuoteSafe(this string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return "\"\"";
			}
			str = str.Replace("\"", "\\\"").TrimEnd('\\');
			return "\"" + str + "\"";
		}

		/// <summary>
		/// Puts a filename into the format /path/filename.ext (from path\FileName.EXT)
		/// </summary>
		// Token: 0x0600034C RID: 844 RVA: 0x0000C9B9 File Offset: 0x0000ABB9
		public static string NormalizeFilename(this string str, bool enforceInitialSlash = true)
		{
			str = str.ToLower().Replace('\\', '/');
			if (enforceInitialSlash && !str.StartsWith('/'))
			{
				str = str.Insert(0, "/");
			}
			return str;
		}

		/// <summary>
		/// in  : I am "splitting a" string "because it's fun "
		/// out : ["I", "am", "splitting a", "string", "because it's fun"]
		/// </summary>
		// Token: 0x0600034D RID: 845 RVA: 0x0000C9E8 File Offset: 0x0000ABE8
		public static string[] SplitQuotesStrings(this string input)
		{
			input = input.Replace("\\\"", "&qute;");
			MatchCollection collection = StringX.splitregex.Matches(input);
			string[] strArray = new string[collection.Count];
			for (int i = 0; i < collection.Count; i++)
			{
				strArray[i] = collection[i].Groups[1].Value;
				strArray[i] = strArray[i].Replace("&qute;", "\"");
			}
			return strArray;
		}

		/// <summary>
		/// 128-bit data type that returns sane results for almost any input.
		/// All other numeric types can cast from this.
		/// </summary>
		// Token: 0x0600034E RID: 846 RVA: 0x0000CA60 File Offset: 0x0000AC60
		public static decimal ToDecimal(this string str, [Optional] decimal Default = 0m)
		{
			decimal res;
			if (decimal.TryParse(str, out res))
			{
				return res;
			}
			return Default;
		}

		/// <summary>
		/// Convert to float, if not then return Default
		/// </summary>
		// Token: 0x0600034F RID: 847 RVA: 0x0000CA7C File Offset: 0x0000AC7C
		public static float ToFloat(this string str, float Default = 0f)
		{
			float res;
			if (float.TryParse(str, NumberStyles.Float, null, out res))
			{
				return res;
			}
			return Default;
		}

		/// <summary>
		/// Convert to uint, if not then return Default
		/// </summary>
		// Token: 0x06000350 RID: 848 RVA: 0x0000CA9C File Offset: 0x0000AC9C
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

		/// <summary>
		/// Convert to int, if not then return Default
		/// </summary>
		// Token: 0x06000351 RID: 849 RVA: 0x0000CADC File Offset: 0x0000ACDC
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

		/// <summary>
		/// Convert to int, if not then return Default
		/// </summary>
		// Token: 0x06000352 RID: 850 RVA: 0x0000CB2C File Offset: 0x0000AD2C
		public static ulong ToULong(this string str, ulong Default = 0UL)
		{
			ulong t;
			if (ulong.TryParse(str, out t))
			{
				return t;
			}
			return Default;
		}

		/// <summary>
		/// Try to convert to bool. Inputs can be true, false, yes, no, 0, 1, null (caps insensitive)
		/// </summary>
		// Token: 0x06000353 RID: 851 RVA: 0x0000CB48 File Offset: 0x0000AD48
		public static bool ToBool(this string str)
		{
			float f;
			return str != null && str.Length != 0 && !(str == "0") && ((char.IsDigit(str[0]) && str[0] != '0') || (!str.Equals("false", StringComparison.OrdinalIgnoreCase) && !str.Equals("no", StringComparison.OrdinalIgnoreCase) && !str.Equals("null", StringComparison.OrdinalIgnoreCase) && (!float.TryParse(str, out f) || f != 0f)));
		}

		/// <summary>
		/// If the string is longer than this amount of characters then truncate it
		/// If appendage is defined, it will be appended to the end of truncated strings (ie, "..")
		/// </summary>
		// Token: 0x06000354 RID: 852 RVA: 0x0000CBD5 File Offset: 0x0000ADD5
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

		/// <summary>
		/// If the string is longer than this amount of characters then truncate it
		/// If appendage is defined, it will be appended to the end of truncated strings (ie, "..")
		/// </summary>
		// Token: 0x06000355 RID: 853 RVA: 0x0000CC10 File Offset: 0x0000AE10
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
				List<string> parts = str.Split(StringX.FilenameDelim).ToList<string>();
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
			return str.Split(StringX.FilenameDelim).ToList<string>().Last<string>();
		}

		/// <summary>
		/// An extended Contains which takes a StringComparison.
		/// </summary>
		// Token: 0x06000356 RID: 854 RVA: 0x0000CCBA File Offset: 0x0000AEBA
		public static bool Contains(this string source, string toCheck, StringComparison comp)
		{
			return source.IndexOf(toCheck, comp) >= 0;
		}

		/// <summary>
		/// Given a large string, find all occurrances of a substring and return them with padding.
		/// This is useful in situations where you're searching for a word in a hug body of text, and
		/// want to show how it's used without displaying the whole text.
		/// </summary>
		// Token: 0x06000357 RID: 855 RVA: 0x0000CCCC File Offset: 0x0000AECC
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

		/// <summary>
		/// Convert a variable name to something more user friendly.
		/// </summary>
		// Token: 0x06000358 RID: 856 RVA: 0x0000CD68 File Offset: 0x0000AF68
		public static string ToTitleCase(this string source)
		{
			source = source.Replace('_', ' ');
			source = source.Replace('-', ' ');
			source = source.Replace('.', ' ');
			string output = "";
			for (int i = 0; i < source.Length; i++)
			{
				if (i == 0)
				{
					output += char.ToUpper(source[i]).ToString();
				}
				else
				{
					if ((char.IsUpper(source[i]) && char.IsLower(source[i - 1])) || (char.IsDigit(source[i]) && !char.IsDigit(source[i - 1])))
					{
						output += " ";
					}
					output += source[i].ToString();
				}
			}
			return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(output);
		}

		/// <summary>
		/// Removes bad, invisible characters that are commonly used to exploit.
		/// https://en.wikipedia.org/wiki/Zero-width_non-joiner
		/// </summary>
		// Token: 0x06000359 RID: 857 RVA: 0x0000CE44 File Offset: 0x0000B044
		public static string RemoveBadCharacters(this string str)
		{
			str = new string(str.Where((char x) => !StringX._badCharacters.Contains(x)).ToArray<char>());
			return str;
		}

		/// <summary>
		/// Convert to a base64 encoded string
		/// </summary>
		// Token: 0x0600035A RID: 858 RVA: 0x0000CE78 File Offset: 0x0000B078
		public static string Base64Encode(this string plainText)
		{
			return Convert.ToBase64String(Encoding.UTF8.GetBytes(plainText));
		}

		/// <summary>
		/// Convert from a base64 encoded string
		/// </summary>
		// Token: 0x0600035B RID: 859 RVA: 0x0000CE8C File Offset: 0x0000B08C
		public static string Base64Decode(this string base64EncodedData)
		{
			byte[] base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
			return Encoding.UTF8.GetString(base64EncodedBytes);
		}

		/// <summary>
		/// Try to politely convert from a string to another type
		/// </summary>
		// Token: 0x0600035C RID: 860 RVA: 0x0000CEAC File Offset: 0x0000B0AC
		public static object ToType(this string str, Type t)
		{
			object output;
			if (str.TryToType(t, out output))
			{
				return output;
			}
			throw new Exception("ToType - need to add the ability to change from string to " + ((t != null) ? t.ToString() : null));
		}

		/// <summary>
		/// Try to politely convert from a string to another type
		/// </summary>
		// Token: 0x0600035D RID: 861 RVA: 0x0000CEE4 File Offset: 0x0000B0E4
		public static bool TryToType(this string str, Type t, out object Value)
		{
			Value = null;
			if (t == typeof(float))
			{
				Value = str.ToFloat(0f);
				return true;
			}
			if (t == typeof(double))
			{
				Value = (double)str.ToFloat(0f);
				return true;
			}
			if (t == typeof(int))
			{
				Value = str.ToInt(0);
				return true;
			}
			if (t == typeof(uint))
			{
				Value = str.ToUInt(0);
				return true;
			}
			if (t == typeof(bool))
			{
				Value = str.ToBool();
				return true;
			}
			if (t == typeof(string))
			{
				Value = str;
				return true;
			}
			if (t == typeof(ulong))
			{
				Value = str.ToULong(0UL);
				return true;
			}
			if (t == typeof(Vector2))
			{
				Value = Vector2.Parse(str);
				return true;
			}
			if (t == typeof(Vector3))
			{
				Value = Vector3.Parse(str);
				return true;
			}
			if (t == typeof(Vector4))
			{
				Value = Vector4.Parse(str);
				return true;
			}
			if (t == typeof(Angles))
			{
				Value = Angles.Parse(str);
				return true;
			}
			if (t == typeof(Color))
			{
				Value = Color.Parse(str);
				return true;
			}
			if (t.IsEnum)
			{
				Value = Enum.Parse(t, str);
				return true;
			}
			if (t == typeof(Rotation))
			{
				Value = Rotation.Parse(str);
				if ((Rotation)Value == Rotation.Identity)
				{
					Angles ang = Angles.Parse(str);
					Value = Rotation.From(ang);
				}
				return true;
			}
			try
			{
				ConstructorInfo constr = t.GetConstructor(new Type[] { typeof(string) });
				if (constr != null)
				{
					object obj = constr.Invoke(new object[] { str });
					if (obj != null)
					{
						Value = obj;
						return true;
					}
				}
				if (t.Name == "Texture")
				{
					MethodInfo meth = t.GetMethod("Load", new Type[]
					{
						typeof(string),
						typeof(bool)
					});
					if (meth != null)
					{
						object obj2 = meth.Invoke(null, new object[] { str, true });
						if (obj2 != null)
						{
							Value = obj2;
							return true;
						}
					}
				}
			}
			catch (Exception e)
			{
				GlobalSystemNamespace.Log.Warning(e);
			}
			return false;
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000D1BC File Offset: 0x0000B3BC
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

		/// <summary>
		/// convert "string" into "string       " or "      string"
		/// </summary>
		// Token: 0x0600035F RID: 863 RVA: 0x0000D1FC File Offset: 0x0000B3FC
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

		/// <summary>
		/// Returns true if tjhis string matches a wildcard match
		/// </summary>
		// Token: 0x06000360 RID: 864 RVA: 0x0000D247 File Offset: 0x0000B447
		public static bool WildcardMatch(this string str, string wildcard)
		{
			wildcard = Regex.Escape(wildcard).Replace("\\*", ".*");
			wildcard = "^" + wildcard + "$";
			return Regex.IsMatch(str, wildcard);
		}

		/// <summary>
		/// The string might start and end in quotes ( ", ' ), remove those if that is the case.
		/// </summary>
		// Token: 0x06000361 RID: 865 RVA: 0x0000D27C File Offset: 0x0000B47C
		public static string TrimQuoted(this string str, bool ignoreSurroundingSpaces = false)
		{
			if (ignoreSurroundingSpaces)
			{
				str = str.Trim();
			}
			if (str[0] == '"')
			{
				string text = str;
				if (text[text.Length - 1] == '"')
				{
					string text2 = str;
					int length = text2.Length;
					int num = 1;
					int num2 = length - 1 - num;
					return text2.Substring(num, num2);
				}
			}
			if (str[0] == '\'')
			{
				string text3 = str;
				if (text3[text3.Length - 1] == '\'')
				{
					string text4 = str;
					int length2 = text4.Length;
					int num2 = 1;
					int num = length2 - 1 - num2;
					return text4.Substring(num2, num);
				}
			}
			return str;
		}

		// Token: 0x040000B6 RID: 182
		private static Regex splitregex = new Regex("\"(?<1>[^\"]+)?\"|'(?<1>[^']+)?'|(?<1>\\S+)", RegexOptions.Compiled);

		// Token: 0x040000B7 RID: 183
		private static char[] FilenameDelim = new char[] { '/', '\\' };

		// Token: 0x040000B8 RID: 184
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
