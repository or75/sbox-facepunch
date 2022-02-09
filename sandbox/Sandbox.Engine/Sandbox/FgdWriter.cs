using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Hammer;
using ModelDoc;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020002A7 RID: 679
	internal static class FgdWriter
	{
		// Token: 0x06001141 RID: 4417 RVA: 0x00020BFC File Offset: 0x0001EDFC
		private static string ParamType(Type t, string defaultValue, Dictionary<string, string> structOut = null)
		{
			if (t == typeof(int))
			{
				return "integer";
			}
			if (t == typeof(float))
			{
				return "float";
			}
			if (t == typeof(double))
			{
				return "float";
			}
			if (t == typeof(bool))
			{
				return "boolean";
			}
			if (t == typeof(Vector3))
			{
				return "vector";
			}
			if (t == typeof(Vector2))
			{
				return "vector2";
			}
			if (t == typeof(string))
			{
				return "string";
			}
			if (t == typeof(Rotation))
			{
				return "angle";
			}
			if (t == typeof(Angles))
			{
				return "angle";
			}
			if (t == typeof(Color))
			{
				return "color255";
			}
			if (t == typeof(RangedFloat))
			{
				return "vector";
			}
			if (t.Name == "TagList")
			{
				return "tags";
			}
			if (t.Name == "FGDCurve")
			{
				return "curve";
			}
			if (t.Name == "SoundEvent")
			{
				return "sound";
			}
			if (t.Name == "Material")
			{
				return "material";
			}
			if (t.IsEnum)
			{
				return "choices";
			}
			if (t.IsAssignableTo(typeof(IAsset)))
			{
				return defaultValue;
			}
			FGDTypeAttribute fgdTypeAttr = t.GetCustomAttribute(false);
			if (fgdTypeAttr != null)
			{
				return fgdTypeAttr.Type;
			}
			Type nullableType = Nullable.GetUnderlyingType(t);
			if (nullableType != null)
			{
				return FgdWriter.ParamType(nullableType, defaultValue, structOut);
			}
			if (t.IsGenericType && (t.GetGenericTypeDefinition() == typeof(List<>) || t.GetGenericTypeDefinition() == typeof(IList<>) || t.GetGenericTypeDefinition() == typeof(IReadOnlyList<>)))
			{
				string type = FgdWriter.ParamType(t.GetGenericArguments()[0], null, structOut);
				if (type != null)
				{
					return "array:" + type;
				}
			}
			if (t.IsArray)
			{
				string type2 = FgdWriter.ParamType(t.GetElementType(), null, structOut);
				if (type2 != null)
				{
					return "array:" + type2;
				}
			}
			bool isStruct = t.IsValueType && !t.IsPrimitive && !t.IsEnum;
			if (structOut != null && (t.IsClass || isStruct))
			{
				return FgdWriter.AssetStructToString(t, structOut);
			}
			return defaultValue;
		}

		// Token: 0x06001142 RID: 4418 RVA: 0x00020E85 File Offset: 0x0001F085
		private static string ParamEditor(Type t)
		{
			if (t == typeof(RangedFloat))
			{
				return "Ranged()";
			}
			return "";
		}

		// Token: 0x06001143 RID: 4419 RVA: 0x00020EA4 File Offset: 0x0001F0A4
		private static string GetDefaultString(object defaultValue)
		{
			if (defaultValue is int)
			{
				return defaultValue.ToString();
			}
			if (defaultValue is float)
			{
				return defaultValue.ToString().QuoteSafe();
			}
			if (defaultValue is double)
			{
				return defaultValue.ToString().QuoteSafe();
			}
			if (defaultValue is bool)
			{
				if (!(bool)defaultValue)
				{
					return "0";
				}
				return "1";
			}
			else
			{
				if (defaultValue is string)
				{
					return defaultValue.ToString().QuoteSafe();
				}
				if (defaultValue.GetType().IsEnum)
				{
					return Convert.ToInt32(defaultValue).ToString();
				}
				return "";
			}
		}

		// Token: 0x06001144 RID: 4420 RVA: 0x00020F3C File Offset: 0x0001F13C
		public static void TypeToString(Type t, StringBuilder str, string baseName)
		{
			if (!t.HasBaseType("Sandbox.Entity") && !t.HasAttribute(typeof(PathNodeAttribute)))
			{
				return;
			}
			if (t.GetCustomAttribute(false) != null)
			{
				return;
			}
			LibraryAttribute la = t.GetCustomAttribute(false);
			if (la == null)
			{
				return;
			}
			if (string.IsNullOrWhiteSpace(la.Name))
			{
				return;
			}
			if (la.Name.Contains(' '))
			{
				return;
			}
			if (la.Name.Contains('\n'))
			{
				return;
			}
			string description = la.Description;
			Sandbox.Internal.DescriptionAttribute descAtt = t.GetCustomAttributes<Sandbox.Internal.DescriptionAttribute>().FirstOrDefault<Sandbox.Internal.DescriptionAttribute>();
			if (string.IsNullOrEmpty(description) && descAtt != null && descAtt.Value != null)
			{
				description = descAtt.Value;
			}
			MetaDataAttribute[] md = t.GetCustomAttributes<MetaDataAttribute>().ToArray<MetaDataAttribute>();
			string baseType = "PointClass";
			if (t.HasAttribute(typeof(SolidAttribute)))
			{
				baseType = "SolidClass";
			}
			if (t.HasAttribute(typeof(PathAttribute)))
			{
				baseType = "PathClass";
			}
			if (t.HasAttribute(typeof(PathNodeAttribute)))
			{
				baseType = "PathNodeClass";
			}
			str.AppendLine("//");
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(3, 1, str);
			appendInterpolatedStringHandler.AppendLiteral("// ");
			appendInterpolatedStringHandler.AppendFormatted(t.FullName);
			str.AppendLine(ref appendInterpolatedStringHandler);
			str.AppendLine("//");
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, str);
			appendInterpolatedStringHandler.AppendLiteral("@");
			appendInterpolatedStringHandler.AppendFormatted(baseType);
			appendInterpolatedStringHandler.AppendLiteral(" ");
			str.Append(ref appendInterpolatedStringHandler);
			if (t.HasBaseType("Sandbox.Entity"))
			{
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(7, 1, str);
				appendInterpolatedStringHandler.AppendLiteral("base(");
				appendInterpolatedStringHandler.AppendFormatted(baseName);
				appendInterpolatedStringHandler.AppendLiteral(") ");
				str.Append(ref appendInterpolatedStringHandler);
			}
			FgdWriter.AddTags(md, str);
			MetaDataAttribute[] array = md;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddHeader(str);
			}
			FgdWriter.AddFromMetaData(md, str);
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 2, str);
			appendInterpolatedStringHandler.AppendLiteral("= ");
			appendInterpolatedStringHandler.AppendFormatted(la.Name);
			appendInterpolatedStringHandler.AppendLiteral(" : ");
			appendInterpolatedStringHandler.AppendFormatted(description.QuoteSafe().Replace("\r\n", "\" +\r\n\t\""));
			str.AppendLine(ref appendInterpolatedStringHandler);
			str.AppendLine("[");
			array = md;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddBody(str);
			}
			FgdWriter.WriteProperties(t, str, null);
			if (t.GetCustomAttribute<CanBeClientsideOnlyAttribute>() != null)
			{
				str.AppendLine("\tclientSideEntity(boolean) [ group=\"Misc\" ] : \"Create as client-only entity\" : 0 : \"If set, the entity will spawn on client only.\"");
			}
			FgdWriter.WriteInputs(t, str);
			FgdWriter.WriteOutputs(t, str);
			str.AppendLine("]");
			str.AppendLine("");
		}

		// Token: 0x06001145 RID: 4421 RVA: 0x000211F8 File Offset: 0x0001F3F8
		public static void ModelGameDataTypeToString(Type t, StringBuilder str, Dictionary<string, string> fgdStructs)
		{
			if (t.GetCustomAttribute(false) != null)
			{
				return;
			}
			GameDataAttribute gdAttr = t.GetCustomAttribute(false);
			string nodeName;
			string description;
			if (gdAttr == null)
			{
				LibraryAttribute libAttr = t.GetCustomAttribute(false);
				if (libAttr == null)
				{
					return;
				}
				nodeName = libAttr.Name;
				description = libAttr.Description;
			}
			else
			{
				nodeName = gdAttr.Name;
				description = gdAttr.Description;
			}
			if (string.IsNullOrWhiteSpace(nodeName))
			{
				return;
			}
			if (nodeName.Contains(' '))
			{
				return;
			}
			if (nodeName.Contains('\n'))
			{
				return;
			}
			Sandbox.Internal.DescriptionAttribute descAtt = t.GetCustomAttributes<Sandbox.Internal.DescriptionAttribute>().FirstOrDefault<Sandbox.Internal.DescriptionAttribute>();
			if (string.IsNullOrEmpty(description) && descAtt != null && descAtt.Value != null)
			{
				description = descAtt.Value;
			}
			MetaDataAttribute[] md = t.GetCustomAttributes<MetaDataAttribute>().ToArray<MetaDataAttribute>();
			str.AppendLine("//");
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(3, 1, str);
			appendInterpolatedStringHandler.AppendLiteral("// ");
			appendInterpolatedStringHandler.AppendFormatted(t.FullName);
			str.AppendLine(ref appendInterpolatedStringHandler);
			str.AppendLine("//");
			str.Append((t.GetInterface("Sandbox.IModelBreakCommand") != null && gdAttr == null) ? "@ModelBreakCommand " : "@ModelGameData ");
			if (gdAttr != null && gdAttr.AllowMultiple)
			{
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(19, 1, str);
				appendInterpolatedStringHandler.AppendLiteral("game_data_list( ");
				appendInterpolatedStringHandler.AppendFormatted(gdAttr.ListName ?? (gdAttr.Name + "_list"));
				appendInterpolatedStringHandler.AppendLiteral(" ) ");
				str.Append(ref appendInterpolatedStringHandler);
			}
			FgdWriter.AddTags(md, str);
			MetaDataAttribute[] array = md;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddHeader(str);
			}
			FgdWriter.AddFromMetaData(md, str);
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 2, str);
			appendInterpolatedStringHandler.AppendLiteral("= ");
			appendInterpolatedStringHandler.AppendFormatted(nodeName);
			appendInterpolatedStringHandler.AppendLiteral(" : ");
			appendInterpolatedStringHandler.AppendFormatted(description.QuoteSafe());
			str.AppendLine(ref appendInterpolatedStringHandler);
			str.AppendLine("[");
			array = md;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddBody(str);
			}
			FgdWriter.WriteProperties(t, str, fgdStructs);
			str.AppendLine("]");
			str.AppendLine("");
		}

		// Token: 0x06001146 RID: 4422 RVA: 0x00021430 File Offset: 0x0001F630
		public static void AssetTypeToString(Type t, StringBuilder str)
		{
			LibraryAttribute la = t.GetCustomAttribute(false);
			if (la == null)
			{
				return;
			}
			if (string.IsNullOrWhiteSpace(la.Name))
			{
				return;
			}
			if (la.Name.Contains(' '))
			{
				return;
			}
			if (la.Name.Contains('\n'))
			{
				return;
			}
			string description = la.Description;
			Sandbox.Internal.DescriptionAttribute descAtt = t.GetCustomAttributes<Sandbox.Internal.DescriptionAttribute>().FirstOrDefault<Sandbox.Internal.DescriptionAttribute>();
			if (string.IsNullOrEmpty(description) && descAtt != null && descAtt.Value != null)
			{
				description = descAtt.Value;
			}
			MetaDataAttribute[] md = t.GetCustomAttributes<MetaDataAttribute>().ToArray<MetaDataAttribute>();
			str.AppendLine("//");
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(3, 1, str);
			appendInterpolatedStringHandler.AppendLiteral("// ");
			appendInterpolatedStringHandler.AppendFormatted(t.FullName);
			str.AppendLine(ref appendInterpolatedStringHandler);
			str.AppendLine("//");
			str.Append("@BaseClass ");
			FgdWriter.AddTags(md, str);
			MetaDataAttribute[] array = md;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddHeader(str);
			}
			FgdWriter.AddFromMetaData(md, str);
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 2, str);
			appendInterpolatedStringHandler.AppendLiteral("= ");
			appendInterpolatedStringHandler.AppendFormatted(la.Name);
			appendInterpolatedStringHandler.AppendLiteral(" : ");
			appendInterpolatedStringHandler.AppendFormatted(description.QuoteSafe());
			str.AppendLine(ref appendInterpolatedStringHandler);
			str.AppendLine("[");
			array = md;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddBody(str);
			}
			Dictionary<string, string> assetStructs = new Dictionary<string, string>();
			FgdWriter.WriteProperties(t, str, assetStructs);
			str.AppendLine("]");
			str.AppendLine("");
			StringBuilder assetStructStr = new StringBuilder();
			foreach (KeyValuePair<string, string> item in assetStructs)
			{
				assetStructStr.Append(item.Value);
			}
			str.Insert(0, assetStructStr.ToString());
		}

		// Token: 0x06001147 RID: 4423 RVA: 0x00021638 File Offset: 0x0001F838
		public static string AssetStructToString(Type t, Dictionary<string, string> assetStructs)
		{
			string fgdType = t.FullName;
			fgdType = fgdType.Replace('.', '_');
			fgdType = fgdType.Replace('+', '_');
			if (assetStructs.ContainsKey(fgdType))
			{
				return "struct:" + fgdType;
			}
			assetStructs[fgdType] = "";
			StringBuilder str = new StringBuilder();
			MetaDataAttribute[] md = t.GetCustomAttributes<MetaDataAttribute>().ToArray<MetaDataAttribute>();
			str.AppendLine("//");
			StringBuilder stringBuilder = str;
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(3, 1, stringBuilder);
			appendInterpolatedStringHandler.AppendLiteral("// ");
			appendInterpolatedStringHandler.AppendFormatted(t.FullName);
			stringBuilder2.AppendLine(ref appendInterpolatedStringHandler);
			str.AppendLine("//");
			str.Append("@struct ");
			FgdWriter.AddTags(md, str);
			MetaDataAttribute[] array = md;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddHeader(str);
			}
			FgdWriter.AddFromMetaData(md, str);
			stringBuilder = str;
			StringBuilder stringBuilder3 = stringBuilder;
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, stringBuilder);
			appendInterpolatedStringHandler.AppendLiteral("= ");
			appendInterpolatedStringHandler.AppendFormatted(fgdType);
			stringBuilder3.AppendLine(ref appendInterpolatedStringHandler);
			str.AppendLine("[");
			array = md;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].AddBody(str);
			}
			FgdWriter.WriteProperties(t, str, assetStructs);
			str.AppendLine("]");
			str.AppendLine("");
			assetStructs[fgdType] = str.ToString();
			return "struct:" + fgdType;
		}

		// Token: 0x06001148 RID: 4424 RVA: 0x000217A4 File Offset: 0x0001F9A4
		private static void WriteProperties(Type t, StringBuilder str, Dictionary<string, string> structOut = null)
		{
			PropertyInfo[] properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy);
			bool isJSON = true;
			PropertyInfo[] array = properties;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].GetCustomAttribute(true) != null)
				{
					isJSON = false;
					break;
				}
			}
			foreach (PropertyInfo prop in properties)
			{
				if (prop.CanWrite)
				{
					if (prop.PropertyType == t)
					{
						GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("FGDWriter: Ignoring property {0}.{1} that has same type {2} as its parent.", new object[] { t.Name, prop.Name, prop.PropertyType }));
					}
					else if (prop.GetCustomAttribute(true) == null)
					{
						string propName = "";
						string propTitle = "";
						string propDesc = "";
						if (isJSON)
						{
							JsonPropertyNameAttribute jsonName = prop.GetCustomAttribute(true);
							if (jsonName != null)
							{
								propName = jsonName.Name;
							}
						}
						else
						{
							PropertyAttribute propAttr = prop.GetCustomAttribute(true);
							if (propAttr == null)
							{
								goto IL_8D2;
							}
							propAttr.InitFromMember(prop, null);
							propName = propAttr.Name.ToLower();
							propTitle = propAttr.Title;
							propDesc = propAttr.Help;
						}
						DisplayNameAttribute titleAttr = prop.GetCustomAttribute(true);
						if (titleAttr != null)
						{
							propTitle = titleAttr.DisplayName;
						}
						if (string.IsNullOrEmpty(propName))
						{
							propName = prop.Name.ToLower();
						}
						if (string.IsNullOrEmpty(propTitle))
						{
							propTitle = prop.Name.ToTitleCase();
						}
						if (string.IsNullOrEmpty(propDesc))
						{
							Sandbox.Internal.DescriptionAttribute desc = prop.GetCustomAttributes<Sandbox.Internal.DescriptionAttribute>().FirstOrDefault<Sandbox.Internal.DescriptionAttribute>();
							if (desc != null)
							{
								propDesc = desc.Value;
							}
						}
						DisplayAttribute displayAttribute = prop.GetCustomAttribute(true);
						if (displayAttribute != null)
						{
							propDesc = displayAttribute.Description ?? propDesc;
							propTitle = displayAttribute.Name ?? propTitle;
						}
						bool shouldSkip = false;
						using (IEnumerator<SkipPropertyAttribute> enumerator = t.GetCustomAttributes<SkipPropertyAttribute>().GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								if (enumerator.Current.PropertyName == propName)
								{
									shouldSkip = true;
									break;
								}
							}
						}
						if (!shouldSkip)
						{
							string defaultValue = "";
							DefaultValueAttribute dv = prop.GetCustomAttribute<DefaultValueAttribute>();
							if (dv != null && dv.Value != null)
							{
								defaultValue = FgdWriter.GetDefaultString(dv.Value);
							}
							DefaultValueAttribute dv2 = prop.GetCustomAttribute<DefaultValueAttribute>();
							if (dv2 != null && dv2.Value != null)
							{
								defaultValue = FgdWriter.GetDefaultString(dv2.Value);
							}
							if (string.IsNullOrEmpty(defaultValue) && (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(int) || prop.PropertyType == typeof(float)))
							{
								defaultValue = "0";
							}
							Dictionary<string, string> keyvalues = new Dictionary<string, string>();
							CategoryAttribute catAttr = prop.GetCustomAttribute(false);
							if (catAttr != null && !string.IsNullOrEmpty(catAttr.Category))
							{
								keyvalues["group"] = catAttr.Category.QuoteSafe();
							}
							if (Nullable.GetUnderlyingType(prop.PropertyType) != null)
							{
								keyvalues["nullable"] = "true";
							}
							foreach (FieldMetaDataAttribute fieldMetaDataAttribute in prop.GetCustomAttributes<FieldMetaDataAttribute>())
							{
								fieldMetaDataAttribute.AddMetaData(keyvalues);
							}
							string fgdType = FgdWriter.ParamType(prop.PropertyType, "string", structOut);
							string editor = FgdWriter.ParamEditor(prop.PropertyType);
							FGDTypeAttribute fgdAttr = prop.GetCustomAttribute<FGDTypeAttribute>();
							if (fgdAttr != null)
							{
								fgdType = fgdAttr.Type;
								if (prop.PropertyType.IsArray || prop.PropertyType.IsAssignableTo(typeof(IList)))
								{
									fgdType = "array:" + fgdType;
								}
								if (!string.IsNullOrEmpty(fgdAttr.Editor))
								{
									editor = fgdAttr.Editor;
								}
							}
							if (string.IsNullOrEmpty(editor) && prop.PropertyType.IsAssignableTo(typeof(IAsset)))
							{
								LibraryAttribute customAttribute = prop.PropertyType.GetCustomAttribute<LibraryAttribute>();
								string assetname = ((customAttribute != null) ? customAttribute.Name : null) ?? prop.PropertyType.Name;
								editor = "AssetBrowse(" + assetname.ToLower() + ")";
							}
							if (!string.IsNullOrEmpty(editor))
							{
								keyvalues["editor"] = "\"" + editor + "\"";
							}
							string metadataStr = string.Join(" ", keyvalues.Select((KeyValuePair<string, string> x) => x.Key + " = " + x.Value));
							if (!string.IsNullOrEmpty(metadataStr))
							{
								metadataStr = "{ " + metadataStr + " } ";
							}
							if (fgdType == "flags")
							{
								IEnumerable<FieldInfo> enumerable = from e in prop.PropertyType.GetFields()
									where e.IsLiteral
									select e;
								int defaultValueInt = defaultValue.ToInt(0);
								StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 5, str);
								appendInterpolatedStringHandler.AppendLiteral("\t");
								appendInterpolatedStringHandler.AppendFormatted(propName);
								appendInterpolatedStringHandler.AppendLiteral("(");
								appendInterpolatedStringHandler.AppendFormatted(fgdType);
								appendInterpolatedStringHandler.AppendLiteral(") ");
								appendInterpolatedStringHandler.AppendFormatted(metadataStr);
								appendInterpolatedStringHandler.AppendLiteral(": ");
								appendInterpolatedStringHandler.AppendFormatted(propTitle.QuoteSafe());
								appendInterpolatedStringHandler.AppendLiteral(" : : ");
								appendInterpolatedStringHandler.AppendFormatted(propDesc.QuoteSafe());
								appendInterpolatedStringHandler.AppendLiteral(" =");
								str.AppendLine(ref appendInterpolatedStringHandler);
								str.AppendLine("\t[");
								foreach (FieldInfo fieldInfo in enumerable)
								{
									string name = fieldInfo.Name.ToTitleCase();
									object value = fieldInfo.GetRawConstantValue();
									appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 3, str);
									appendInterpolatedStringHandler.AppendLiteral("\t\t");
									appendInterpolatedStringHandler.AppendFormatted<object>(value);
									appendInterpolatedStringHandler.AppendLiteral(" : ");
									appendInterpolatedStringHandler.AppendFormatted(name.QuoteSafe());
									appendInterpolatedStringHandler.AppendLiteral(" : ");
									appendInterpolatedStringHandler.AppendFormatted(((defaultValueInt & (int)value) == 0) ? "0" : "1");
									str.AppendLine(ref appendInterpolatedStringHandler);
								}
								str.AppendLine("\t]");
							}
							else if (prop.PropertyType.IsEnum)
							{
								IEnumerable<FieldInfo> enumFields = from e in prop.PropertyType.GetFields()
									where e.IsLiteral
									select e;
								if (defaultValue == "")
								{
									FieldInfo firstField = enumFields.FirstOrDefault<FieldInfo>();
									if (firstField != null)
									{
										defaultValue = firstField.GetRawConstantValue().ToString();
									}
									int num;
									if (!int.TryParse(defaultValue, out num))
									{
										defaultValue = defaultValue.QuoteSafe();
									}
								}
								StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(14, 6, str);
								appendInterpolatedStringHandler.AppendLiteral("\t");
								appendInterpolatedStringHandler.AppendFormatted(propName);
								appendInterpolatedStringHandler.AppendLiteral("(");
								appendInterpolatedStringHandler.AppendFormatted(fgdType);
								appendInterpolatedStringHandler.AppendLiteral(") ");
								appendInterpolatedStringHandler.AppendFormatted(metadataStr);
								appendInterpolatedStringHandler.AppendLiteral(": ");
								appendInterpolatedStringHandler.AppendFormatted(propTitle.QuoteSafe());
								appendInterpolatedStringHandler.AppendLiteral(" : ");
								appendInterpolatedStringHandler.AppendFormatted(defaultValue);
								appendInterpolatedStringHandler.AppendLiteral(" : ");
								appendInterpolatedStringHandler.AppendFormatted(propDesc.QuoteSafe());
								appendInterpolatedStringHandler.AppendLiteral(" =");
								str.AppendLine(ref appendInterpolatedStringHandler);
								str.AppendLine("\t[");
								foreach (FieldInfo enumField in enumFields)
								{
									if (enumField.GetCustomAttribute<SkipAttribute>() == null)
									{
										string name2 = enumField.Name.ToTitleCase();
										string value2 = enumField.GetRawConstantValue().ToString();
										appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(5, 2, str);
										appendInterpolatedStringHandler.AppendLiteral("\t\t");
										int num;
										appendInterpolatedStringHandler.AppendFormatted(int.TryParse(value2, out num) ? value2 : value2.QuoteSafe());
										appendInterpolatedStringHandler.AppendLiteral(" : ");
										appendInterpolatedStringHandler.AppendFormatted(name2.QuoteSafe());
										str.AppendLine(ref appendInterpolatedStringHandler);
									}
								}
								str.AppendLine("\t]");
							}
							else
							{
								StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 6, str);
								appendInterpolatedStringHandler.AppendLiteral("\t");
								appendInterpolatedStringHandler.AppendFormatted(propName);
								appendInterpolatedStringHandler.AppendLiteral("(");
								appendInterpolatedStringHandler.AppendFormatted(fgdType);
								appendInterpolatedStringHandler.AppendLiteral(") ");
								appendInterpolatedStringHandler.AppendFormatted(metadataStr);
								appendInterpolatedStringHandler.AppendLiteral(": ");
								appendInterpolatedStringHandler.AppendFormatted(propTitle.QuoteSafe());
								appendInterpolatedStringHandler.AppendLiteral(" : ");
								appendInterpolatedStringHandler.AppendFormatted(defaultValue);
								appendInterpolatedStringHandler.AppendLiteral(" : ");
								appendInterpolatedStringHandler.AppendFormatted(propDesc.QuoteSafe());
								str.AppendLine(ref appendInterpolatedStringHandler);
							}
						}
					}
				}
				IL_8D2:;
			}
			FgdWriter.SearchRecursivelyForSpawnflags(t, str);
		}

		// Token: 0x06001149 RID: 4425 RVA: 0x000220CC File Offset: 0x000202CC
		private static bool SearchRecursivelyForSpawnflags(Type type, StringBuilder str)
		{
			foreach (Type subType in type.GetNestedTypes(BindingFlags.Public | BindingFlags.NonPublic))
			{
				SpawnflagsAttribute spawnflagsAttr = subType.GetCustomAttribute(true);
				if (spawnflagsAttr != null)
				{
					if (subType.IsEnum)
					{
						str.AppendLine("\tspawnflags(flags) = [");
						foreach (FieldInfo enumField in subType.GetFields())
						{
							if (enumField.IsLiteral)
							{
								string name = enumField.Name.ToTitleCase();
								int value = (int)enumField.GetRawConstantValue();
								SpawnflagAttribute spawnflag = enumField.GetCustomAttribute(false);
								if (spawnflag != null)
								{
									if (!string.IsNullOrEmpty(spawnflag.Name))
									{
										name = spawnflag.Name.ToTitleCase();
									}
									if (!string.IsNullOrEmpty(spawnflag.Help))
									{
										name = name + " (" + spawnflag.Help + ")";
									}
								}
								StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 3, str);
								appendInterpolatedStringHandler.AppendLiteral("\t\t");
								appendInterpolatedStringHandler.AppendFormatted<int>(value);
								appendInterpolatedStringHandler.AppendLiteral(" : ");
								appendInterpolatedStringHandler.AppendFormatted(name.QuoteSafe());
								appendInterpolatedStringHandler.AppendLiteral(" : ");
								appendInterpolatedStringHandler.AppendFormatted<int>(((spawnflagsAttr.Default & value) == 0) ? 0 : 1);
								str.AppendLine(ref appendInterpolatedStringHandler);
							}
						}
						str.AppendLine("\t]");
						return true;
					}
					GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Unsupported type {0} with [Spawnflags] attribute!", new object[] { subType.Name }));
				}
			}
			return type.BaseType != null && FgdWriter.SearchRecursivelyForSpawnflags(type.BaseType, str);
		}

		// Token: 0x0600114A RID: 4426 RVA: 0x0002227C File Offset: 0x0002047C
		private static void WriteInputs(Type t, StringBuilder str)
		{
			bool written = false;
			foreach (MethodInfo prop in t.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
			{
				InputAttribute input = prop.GetCustomAttribute(true);
				if (input != null)
				{
					input.InitFromMember(prop, null);
					bool shouldSkip = false;
					using (IEnumerator<SkipPropertyAttribute> enumerator = t.GetCustomAttributes<SkipPropertyAttribute>().GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							if (enumerator.Current.PropertyName == input.Name)
							{
								shouldSkip = true;
								break;
							}
						}
					}
					if (!shouldSkip)
					{
						ParameterInfo[] parameters = prop.GetParameters();
						string arg = "void";
						if (parameters != null && parameters.Length != 0)
						{
							if (parameters[0].Name == "activator")
							{
								if (parameters.Length > 1)
								{
									arg = FgdWriter.ParamType(parameters[1].ParameterType, "void", null);
								}
							}
							else
							{
								arg = FgdWriter.ParamType(parameters[0].ParameterType, "void", null);
							}
						}
						if (!written)
						{
							str.AppendLine("");
						}
						written = true;
						StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(12, 3, str);
						appendInterpolatedStringHandler.AppendLiteral("\tinput ");
						appendInterpolatedStringHandler.AppendFormatted(input.Name);
						appendInterpolatedStringHandler.AppendLiteral("(");
						appendInterpolatedStringHandler.AppendFormatted(arg);
						appendInterpolatedStringHandler.AppendLiteral(") : ");
						appendInterpolatedStringHandler.AppendFormatted(input.Help.QuoteSafe());
						str.AppendLine(ref appendInterpolatedStringHandler);
					}
				}
			}
		}

		// Token: 0x0600114B RID: 4427 RVA: 0x00022400 File Offset: 0x00020600
		private static void WriteOutputs(Type t, StringBuilder str)
		{
			bool written = false;
			foreach (PropertyInfo prop in t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy))
			{
				if (!(prop.PropertyType.FullName != "Sandbox.Entity+Output") || prop.PropertyType.FullName.StartsWith("Sandbox.Entity+Output`1"))
				{
					string name = prop.Name;
					string description = "";
					string fgdType = "void";
					if (prop.PropertyType.IsGenericType)
					{
						fgdType = FgdWriter.ParamType(prop.PropertyType.GenericTypeArguments[0], "void", null);
					}
					Sandbox.Internal.DescriptionAttribute desc = prop.GetCustomAttributes<Sandbox.Internal.DescriptionAttribute>().FirstOrDefault<Sandbox.Internal.DescriptionAttribute>();
					if (desc != null && desc.Value != null)
					{
						description = desc.Value;
					}
					if (!written)
					{
						str.AppendLine("");
					}
					written = true;
					StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 3, str);
					appendInterpolatedStringHandler.AppendLiteral("\toutput ");
					appendInterpolatedStringHandler.AppendFormatted(name);
					appendInterpolatedStringHandler.AppendLiteral("(");
					appendInterpolatedStringHandler.AppendFormatted(fgdType);
					appendInterpolatedStringHandler.AppendLiteral(") : ");
					appendInterpolatedStringHandler.AppendFormatted(description.QuoteSafe());
					str.AppendLine(ref appendInterpolatedStringHandler);
				}
			}
		}

		/// <summary>
		/// Create the metadata section, if it has metadata properties
		/// </summary>
		// Token: 0x0600114C RID: 4428 RVA: 0x00022530 File Offset: 0x00020730
		private static void AddFromMetaData(MetaDataAttribute[] md, StringBuilder str)
		{
			if (md.Length == 0)
			{
				return;
			}
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < md.Length; i++)
			{
				md[i].AddMetaData(sb);
			}
			if (sb.Length == 0)
			{
				return;
			}
			str.AppendLine("");
			str.AppendLine("metadata");
			str.AppendLine("{");
			str.Append(sb);
			str.AppendLine("}");
		}

		/// <summary>
		/// Create the tags section
		/// </summary>
		// Token: 0x0600114D RID: 4429 RVA: 0x000225A4 File Offset: 0x000207A4
		private static void AddTags(MetaDataAttribute[] md, StringBuilder str)
		{
			if (md.Length == 0)
			{
				return;
			}
			List<string> tags = new List<string>();
			for (int i = 0; i < md.Length; i++)
			{
				md[i].AddTags(tags);
			}
			if (tags.Count == 0)
			{
				return;
			}
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(9, 1, str);
			appendInterpolatedStringHandler.AppendLiteral("tags( ");
			appendInterpolatedStringHandler.AppendFormatted(string.Join(", ", tags));
			appendInterpolatedStringHandler.AppendLiteral(" ) ");
			str.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x0600114E RID: 4430 RVA: 0x00022620 File Offset: 0x00020820
		public static bool AssemblyToString(Assembly a, StringBuilder str, string name)
		{
			string baseName = "BaseProperties_" + Regex.Replace(name, "[^A-Za-z0-9_]", "_");
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, str);
			appendInterpolatedStringHandler.AppendLiteral("\r\n@BaseClass = ");
			appendInterpolatedStringHandler.AppendFormatted(baseName);
			str.AppendLine(ref appendInterpolatedStringHandler);
			str.AppendLine("[");
			str.AppendLine("\tparentname(target_destination) [ group=\"Hierarchy\" ] : \"Parent\" : : \"The name of this entity's parent in the movement hierarchy. Entities with parents move with their parent.\"");
			str.AppendLine("\tparentAttachmentName(parentAttachment) [ group=\"Hierarchy\" ] : \"Parent Model Bone/Attachment Name\" : : \"The name of the bone or attachment to attach to on the entity's parent in the movement hierarchy. Use !bonemerge to use bone-merge style attachment.\"\r\n");
			str.AppendLine("\tuseLocalOffset(boolean) [ group=\"Hierarchy\" ] : \"Use Model Attachment offsets\" : 0 : \"Whether to respect the specified local offset when doing the initial hierarchical attachment to its parent.\"");
			str.AppendLine("\tlocal.origin(vector) [ group=\"Hierarchy\" ] : \"Model Attachment position offset\" : : \"Offset in the local space of the parent model's attachment/bone to use in hierarchy. Not used if you are not using parent attachment.\"");
			str.AppendLine("\tlocal.angles(angle) [ group=\"Hierarchy\" ] : \"Model Attachment angular offset\" : : \"Angular offset in the local space of the parent model's attachment/bone to use in hierarchy. Not used if you are not using parent attachment.\"");
			str.AppendLine("\tlocal.scales(vector) [ group=\"Hierarchy\" ] : \"Model Attachment scale\" : : \"Scale in the local space of the parent model's attachment/bone to use in hierarchy. Not used if you are not using parent attachment.\"\r\n");
			str.AppendLine("\ttargetname(target_source) : \"Name\" : : \"The name that other entities refer to this entity by.\"");
			str.AppendLine("\ttags(tags) : \"Tags\" : \"\" : \"A list of general purpose tags for this entity, for interactions with other entities such as triggers.\"");
			str.AppendLine("]\r\n");
			int startIndex = str.Length;
			Type[] types = a.GetTypes();
			for (int i = 0; i < types.Length; i++)
			{
				FgdWriter.TypeToString(types[i], str, baseName);
			}
			return startIndex != str.Length;
		}

		// Token: 0x0600114F RID: 4431 RVA: 0x00022724 File Offset: 0x00020924
		internal static void WriteForAssembly(BaseFileSystem filesystem, string location, string name, Assembly asm)
		{
			StringBuilder sb = new StringBuilder();
			bool flag = FgdWriter.AssemblyToString(asm, sb, name);
			string generated = sb.ToString();
			string fn = location + "/" + name + ".fgd";
			if (flag && (!filesystem.FileExists(fn) || generated != filesystem.ReadAllText(fn)))
			{
				filesystem.CreateDirectory(location ?? "");
				filesystem.WriteAllText(fn, generated);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
			foreach (Type type in from x in asm.GetTypes()
				where x.IsAssignableTo(typeof(IAsset))
				select x)
			{
				if (type.GetCustomAttribute<AutoGenerateAttribute>() != null)
				{
					LibraryAttribute library = type.GetCustomAttribute<LibraryAttribute>();
					if (library != null)
					{
						StringBuilder sb2 = new StringBuilder();
						FgdWriter.AssetTypeToString(type, sb2);
						string generated2 = sb2.ToString();
						defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 2);
						defaultInterpolatedStringHandler.AppendLiteral("/");
						defaultInterpolatedStringHandler.AppendFormatted(location);
						defaultInterpolatedStringHandler.AppendLiteral("/");
						defaultInterpolatedStringHandler.AppendFormatted(library.Name);
						defaultInterpolatedStringHandler.AppendLiteral(".asset");
						string target = defaultInterpolatedStringHandler.ToStringAndClear();
						if (!filesystem.FileExists(target) || generated2 != filesystem.ReadAllText(target))
						{
							filesystem.CreateDirectory(location ?? "");
							filesystem.WriteAllText(target, generated2);
						}
					}
				}
			}
			StringBuilder sb3 = new StringBuilder();
			Dictionary<string, string> fgdStructs = new Dictionary<string, string>();
			foreach (Type t in from x in asm.GetTypes()
				where x.HasAttribute(typeof(GameDataAttribute)) || x.GetInterface("Sandbox.IModelBreakCommand") != null
				select x)
			{
				FgdWriter.ModelGameDataTypeToString(t, sb3, fgdStructs);
			}
			StringBuilder fgdStructsStr = new StringBuilder();
			foreach (KeyValuePair<string, string> item in fgdStructs)
			{
				fgdStructsStr.Append(item.Value);
			}
			sb3.Insert(0, fgdStructsStr.ToString());
			string generated3 = sb3.ToString();
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 2);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(location);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted(name);
			defaultInterpolatedStringHandler.AppendLiteral("_modeldata.fgd");
			string target2 = defaultInterpolatedStringHandler.ToStringAndClear();
			if (!string.IsNullOrEmpty(generated3) && (!filesystem.FileExists(target2) || generated3 != filesystem.ReadAllText(target2)))
			{
				filesystem.CreateDirectory(location ?? "");
				filesystem.WriteAllText(target2, generated3);
			}
		}
	}
}
