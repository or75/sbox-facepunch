using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sandbox.UI
{
	// Token: 0x0200012A RID: 298
	internal static class StyleParser
	{
		/// <summary>
		/// Parse the styles as you would if they were passed in an sytle="width: 100px" attribute
		/// </summary>
		// Token: 0x06001717 RID: 5911 RVA: 0x0005C7E8 File Offset: 0x0005A9E8
		internal static Styles ParseStyles(string v, Styles s)
		{
			Parse p = new Parse
			{
				Text = v
			};
			while (!p.IsEnd)
			{
				p = p.SkipWhitespaceAndNewlines(":;");
				if (p.Current == ':')
				{
					throw new Exception("Parsing error - unexpected ':' at ");
				}
				string name = p.ReadUntil(":");
				if (name == null)
				{
					break;
				}
				Console.WriteLine(name);
				p.Pointer++;
				p = p.SkipWhitespaceAndNewlines(null);
				string value = p.ReadUntilOrEnd(";", false);
				if (value == null)
				{
					break;
				}
				Console.WriteLine(value);
				p.Pointer++;
				s.Set(name, value);
				p = p.SkipWhitespaceAndNewlines(null);
			}
			return s;
		}

		/// <summary>
		/// Here we divide the selectors into groups
		/// .fucker, .cocks, .hairy
		/// </summary>
		// Token: 0x06001718 RID: 5912 RVA: 0x0005C89C File Offset: 0x0005AA9C
		public static List<StyleSelector> Selector(string rule_string, StyleBlock parent = null)
		{
			List<StyleSelector> list = new List<StyleSelector>();
			Parse p = new Parse(rule_string, "nofile");
			while (!p.IsEnd)
			{
				p = p.SkipWhitespaceAndNewlines(null);
				if (p.IsEnd)
				{
					break;
				}
				if (p.Current == ',')
				{
					throw new Exception("Invalid Selector: " + rule_string);
				}
				StyleSelector ss = StyleParser.ParseSelector(p.ReadUntilOrEnd(",", false).Trim(), parent);
				if (ss == null)
				{
					return null;
				}
				list.Add(ss);
				if (!p.IsEnd && p.Current == ',')
				{
					p.Pointer++;
				}
			}
			return list;
		}

		// Token: 0x06001719 RID: 5913 RVA: 0x0005C93C File Offset: 0x0005AB3C
		public static StyleSelector ParseSelector(string rule_string, StyleBlock parent = null)
		{
			Parse p = new Parse(rule_string, "nofile");
			StyleSelector lastRule = null;
			while (!p.IsEnd)
			{
				p = p.SkipWhitespaceAndNewlines(null);
				if (p.IsEnd)
				{
					break;
				}
				bool immediateParent = false;
				if (p.Is('>', 0, false))
				{
					p.Pointer++;
					p = p.SkipWhitespaceAndNewlines(null);
					immediateParent = true;
				}
				StyleSelector rule = StyleParser.ParseSingleSelector(p.ReadUntilWhitespaceOrNewlineOrEndAndObeyBrackets(), parent);
				if (rule == null)
				{
					return null;
				}
				rule.Parent = lastRule;
				rule.ImmediateParent = immediateParent;
				lastRule = rule;
			}
			if (lastRule != null)
			{
				lastRule.AsString = rule_string.Trim();
				if (parent != null)
				{
					string parentRules = string.Join(", ", parent.Selectors.Select((StyleSelector x) => x.AsString));
					if (lastRule.AsString.StartsWith('&'))
					{
						lastRule.AsString = parentRules + lastRule.AsString.Substring(1);
					}
					else
					{
						lastRule.AsString = parentRules + " " + lastRule.AsString;
					}
				}
			}
			return lastRule;
		}

		/// <summary>
		/// Parse a single rule, which as "panel.closed.error:hover"
		/// </summary>
		/// <returns></returns>
		// Token: 0x0600171A RID: 5914 RVA: 0x0005CA4C File Offset: 0x0005AC4C
		public static StyleSelector ParseSingleSelector(string rule_string, StyleBlock parent)
		{
			string seperators = ".:";
			StyleSelector rule = new StyleSelector();
			rule.AsString = rule_string.Trim();
			Parse p = new Parse(rule_string, "nofile");
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.Current == '&')
			{
				p.Pointer++;
				if (parent == null)
				{
					throw new Exception("Starts with & but has no parent block \"" + rule_string + "\"");
				}
				rule.AnyOf = parent.Selectors;
			}
			else if (p.Current == '>')
			{
				p.Pointer++;
				if (parent == null)
				{
					throw new Exception("Starts with > but has no parent block \"" + rule_string + "\"");
				}
				rule.DecendantOf = parent.Selectors;
				rule.ImmediateParent = true;
			}
			else if (parent != null)
			{
				rule.DecendantOf = parent.Selectors;
			}
			while (!p.IsEnd)
			{
				if (p.Current == '.')
				{
					p.Pointer++;
					if (p.IsEnd || p.IsOneOf(seperators))
					{
						throw new Exception("Invalid Rule \"" + rule_string + "\"");
					}
					string classname = p.ReadUntilOrEnd(".:", false).ToLower();
					if (rule.Classes == null)
					{
						rule.Classes = new HashSet<string>();
					}
					rule.Classes.Add(classname);
				}
				else if (p.Current == ':')
				{
					p.Pointer++;
					if (p.IsEnd || p.IsOneOf(seperators))
					{
						throw new Exception("Invalid Rule \"" + rule_string + "\"");
					}
					StyleParser.ReadPseudoClass(rule, ref p);
				}
				else
				{
					rule.Element = p.ReadUntilOrEnd(".:", false).ToLower();
				}
			}
			return rule;
		}

		// Token: 0x0600171B RID: 5915 RVA: 0x0005CC0C File Offset: 0x0005AE0C
		private static void ReadPseudoClass(StyleSelector rule, ref Parse p)
		{
			if (p.Is("not", 0, true))
			{
				p.Pointer += 3;
				string inner = p.ReadInnerBrackets('(', ')');
				if (string.IsNullOrEmpty(inner))
				{
					return;
				}
				rule.Not = StyleParser.ParseSelector(inner, null);
				return;
			}
			else
			{
				if (!p.Is("nth-child", 0, true))
				{
					string flagname = p.ReadUntilOrEnd(".:", false).ToLower();
					uint num = <PrivateImplementationDetails>.ComputeStringHash(flagname);
					if (num <= 1892592429U)
					{
						if (num <= 413646574U)
						{
							if (num != 337658899U)
							{
								if (num == 413646574U)
								{
									if (flagname == "empty")
									{
										rule.Flags |= PseudoClass.Empty;
										return;
									}
								}
							}
							else if (flagname == "focus")
							{
								rule.Flags |= PseudoClass.Focus;
								return;
							}
						}
						else if (num != 775786673U)
						{
							if (num == 1892592429U)
							{
								if (flagname == "hover")
								{
									rule.Flags |= PseudoClass.Hover;
									return;
								}
							}
						}
						else if (flagname == "intro")
						{
							rule.Flags |= PseudoClass.Intro;
							return;
						}
					}
					else if (num <= 2532379786U)
					{
						if (num != 1948179948U)
						{
							if (num == 2532379786U)
							{
								if (flagname == "last-child")
								{
									rule.Flags |= PseudoClass.LastChild;
									return;
								}
							}
						}
						else if (flagname == "only-child")
						{
							rule.Flags |= PseudoClass.OnlyChild;
							return;
						}
					}
					else if (num != 2800449960U)
					{
						if (num != 3015706674U)
						{
							if (num == 3648362799U)
							{
								if (flagname == "active")
								{
									rule.Flags |= PseudoClass.Active;
									return;
								}
							}
						}
						else if (flagname == "first-child")
						{
							rule.Flags |= PseudoClass.FirstChild;
							return;
						}
					}
					else if (flagname == "outro")
					{
						rule.Flags |= PseudoClass.Outro;
						return;
					}
					throw new Exception("Unsupported Pseudo Class \"" + flagname + "\"");
				}
				p.Pointer += "nth-child".Length;
				string inner2 = p.ReadInnerBrackets('(', ')');
				if (string.IsNullOrEmpty(inner2))
				{
					return;
				}
				StyleParser.ParseNthChild(rule, inner2.Trim());
				return;
			}
		}

		// Token: 0x0600171C RID: 5916 RVA: 0x0005CEA4 File Offset: 0x0005B0A4
		private static void ParseNthChild(StyleSelector rule, string inner)
		{
			int intValue;
			if (int.TryParse(inner, out intValue))
			{
				rule.NthChild = (Panel p) => p.SiblingIndex == intValue;
				return;
			}
			if (string.Equals(inner, "odd", StringComparison.OrdinalIgnoreCase))
			{
				rule.NthChild = (Panel p) => p.SiblingIndex % 2 == 1;
				return;
			}
			if (string.Equals(inner, "even", StringComparison.OrdinalIgnoreCase))
			{
				rule.NthChild = (Panel p) => p.SiblingIndex % 2 == 0;
				return;
			}
			throw new Exception("unsupported NthChild \"" + inner + "\"");
		}

		// Token: 0x0600171D RID: 5917 RVA: 0x0005CF58 File Offset: 0x0005B158
		public static StyleSheet ParseSheet(string content, string filename = "none", IEnumerable<ValueTuple<string, string>> variables = null)
		{
			StyleParser.IncludeLoops = 0;
			StyleSheet sheet = new StyleSheet();
			sheet.AddVariables(variables);
			StyleParser.ParseToSheet(content, filename, sheet);
			return sheet;
		}

		// Token: 0x0600171E RID: 5918 RVA: 0x0005CF84 File Offset: 0x0005B184
		private static void ParseToSheet(string content, string filename, StyleSheet sheet)
		{
			StyleParser.IncludeLoops++;
			filename = filename.NormalizeFilename(true);
			sheet.AddFilename(filename);
			content = StyleParser.StripComments(content);
			Parse p = new Parse(content, filename);
			while (!p.IsEnd)
			{
				p = p.SkipWhitespaceAndNewlines(null);
				if (p.IsEnd)
				{
					break;
				}
				string selector = p.ReadUntilOrEnd("{;$@", false);
				if (selector == null)
				{
					throw new Exception("Parse Error, expected class name " + p.FileAndLine);
				}
				if (p.IsEnd)
				{
					throw new Exception("Parse Error, unexpected end " + p.FileAndLine);
				}
				if (!StyleParser.ParseVariable(ref p, sheet) && !StyleParser.ParseImport(ref p, sheet, filename))
				{
					if (p.Current != '{')
					{
						DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(35, 2);
						defaultInterpolatedStringHandler.AppendLiteral("Parse Error, unexpected character ");
						defaultInterpolatedStringHandler.AppendFormatted<char>(p.Current);
						defaultInterpolatedStringHandler.AppendLiteral(" ");
						defaultInterpolatedStringHandler.AppendFormatted(p.FileAndLine);
						throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
					}
					if (p.Current == '{')
					{
						StyleParser.ReadStyleBlock(ref p, selector, sheet, null);
					}
				}
			}
			StyleParser.IncludeLoops--;
		}

		// Token: 0x0600171F RID: 5919 RVA: 0x0005D0B8 File Offset: 0x0005B2B8
		private static bool ParseVariable(ref Parse p, StyleSheet sheet)
		{
			if (p.Current != '$')
			{
				return false;
			}
			ValueTuple<string, string> valueTuple = p.ReadKeyValue();
			string key = valueTuple.Item1;
			string value = valueTuple.Item2;
			bool isDefault = value.EndsWith("!default", StringComparison.OrdinalIgnoreCase);
			if (isDefault)
			{
				string text = value;
				int length = text.Length - 8 - 0;
				value = text.Substring(0, length).Trim();
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 3);
			defaultInterpolatedStringHandler.AppendLiteral("Found [");
			defaultInterpolatedStringHandler.AppendFormatted(key);
			defaultInterpolatedStringHandler.AppendLiteral("] = [");
			defaultInterpolatedStringHandler.AppendFormatted(value);
			defaultInterpolatedStringHandler.AppendLiteral("] (");
			defaultInterpolatedStringHandler.AppendFormatted<bool>(isDefault);
			defaultInterpolatedStringHandler.AppendLiteral(")");
			Console.WriteLine(defaultInterpolatedStringHandler.ToStringAndClear());
			sheet.SetVariable(key, value, isDefault);
			return true;
		}

		// Token: 0x06001720 RID: 5920 RVA: 0x0005D178 File Offset: 0x0005B378
		private static void TryImport(StyleSheet sheet, string filename, string includeFileAndLine)
		{
			if (!FileSystem.Mounted.FileExists(filename))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Missing import ");
				defaultInterpolatedStringHandler.AppendFormatted(filename);
				defaultInterpolatedStringHandler.AppendLiteral(" (");
				defaultInterpolatedStringHandler.AppendFormatted(includeFileAndLine);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				throw new Exception(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			StyleParser.ParseToSheet(FileSystem.Mounted.ReadAllText(filename), filename, sheet);
		}

		// Token: 0x06001721 RID: 5921 RVA: 0x0005D1F0 File Offset: 0x0005B3F0
		private static bool ParseImport(ref Parse p, StyleSheet sheet, string filename)
		{
			if (p.Current != '@')
			{
				return false;
			}
			string word = p.ReadWord(" ", true);
			if (string.IsNullOrWhiteSpace(word))
			{
				throw new Exception("Expected word after @ " + p.FileAndLine);
			}
			if (!(word == "@import"))
			{
				throw new Exception("Unknown rule " + word + " " + p.FileAndLine);
			}
			if (StyleParser.IncludeLoops > 10)
			{
				throw new Exception("Possible infinite @import loop " + p.FileAndLine);
			}
			string thisRoot = Path.GetDirectoryName(filename);
			string text = p.ReadUntilOrEnd(";", false);
			if (string.IsNullOrWhiteSpace(text))
			{
				throw new Exception("Expected files then ; after @import " + p.FileAndLine);
			}
			string[] array = text.Split(',', StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				string cleanFile = array[i].Trim(new char[] { ' ', '"', '\'' });
				if (!Path.HasExtension(cleanFile))
				{
					cleanFile = "_" + cleanFile + ".scss";
				}
				string localPath = Path.Combine(thisRoot, cleanFile).ToLower();
				if (!FileSystem.Mounted.FileExists(localPath))
				{
					localPath = cleanFile.ToLower();
				}
				StyleParser.TryImport(sheet, localPath, p.FileAndLine);
			}
			if (p.Is(';', 0, false))
			{
				p.Pointer++;
			}
			return true;
		}

		// Token: 0x06001722 RID: 5922 RVA: 0x0005D34C File Offset: 0x0005B54C
		private static void ReadStyleBlock(ref Parse p, string selectors, StyleSheet sheet, StyleBlock parentNode)
		{
			if (p.Current != '{')
			{
				throw new Exception("Block doesn't start with { " + p.FileAndLine);
			}
			p.Pointer++;
			p = p.SkipWhitespaceAndNewlines(null);
			StyleBlock node = new StyleBlock();
			node.LoadOrder = sheet.Nodes.Count<StyleBlock>();
			node.SetSelector(selectors, parentNode);
			sheet.Nodes.Add(node);
			Styles styles = new Styles();
			while (!p.IsEnd)
			{
				string content = p.ReadUntilOrEnd(";{}", false);
				if (content == null)
				{
					throw new Exception("Parse Error, expected class name " + p.FileAndLine);
				}
				if (p.Current == '{')
				{
					StyleParser.ReadStyleBlock(ref p, content, sheet, node);
				}
				else
				{
					if (p.Current == ';')
					{
						Console.WriteLine("Style Set: " + content);
						try
						{
							content = sheet.ReplaceVariables(content);
						}
						catch (Exception ex)
						{
							throw new Exception(ex.Message + " " + p.FileAndLine);
						}
						styles.SetInternal(content, p.FileAndLine);
						p.Pointer++;
						p = p.SkipWhitespaceAndNewlines(null);
					}
					if (p.Current == '}')
					{
						p.Pointer++;
						node.Styles = styles;
						return;
					}
				}
			}
			throw new Exception("Unexpected end of block " + p.FileAndLine);
		}

		// Token: 0x06001723 RID: 5923 RVA: 0x0005D4B8 File Offset: 0x0005B6B8
		public static string StripComments(string v)
		{
			if (string.IsNullOrWhiteSpace(v))
			{
				return v;
			}
			StringBuilder builder = new StringBuilder();
			Parse p = new Parse(v, "nofile");
			int lastSafe = 0;
			bool commentCanFollow = true;
			while (!p.IsEnd)
			{
				if (commentCanFollow && p.Is('/', 0, false))
				{
					p.Pointer++;
					if (p.IsEnd)
					{
						throw new Exception("Parse error (file ends in /)");
					}
					if (p.Is('/', 0, false))
					{
						p.Pointer++;
						builder.Append(v.Substring(lastSafe, p.Pointer - 2 - lastSafe));
						p = p.JumpToEndOfLine(false);
						lastSafe = Math.Min(p.Pointer, p.Length);
					}
					if (p.Is('*', 0, false))
					{
						p.Pointer++;
						if (p.IsEnd)
						{
							throw new Exception("Parse error (file ends in *)");
						}
						builder.Append(v.Substring(lastSafe, p.Pointer - 2 - lastSafe));
						while (!p.IsEnd)
						{
							if (p.Is('*', 0, false) && p.Next == '/')
							{
								p.Pointer += 2;
								lastSafe = Math.Min(p.Pointer, p.Length);
								goto IL_14C;
							}
							p.Pointer++;
						}
						throw new Exception("Unterminated Multiline Comment");
					}
				}
				IL_14C:
				commentCanFollow = !p.Is(':', 0, false);
				p.Pointer++;
			}
			builder.Append(v.Substring(lastSafe, Math.Min(v.Length - lastSafe, p.Pointer - lastSafe)));
			return builder.ToString();
		}

		// Token: 0x040005CE RID: 1486
		[ThreadStatic]
		private static int IncludeLoops;
	}
}
