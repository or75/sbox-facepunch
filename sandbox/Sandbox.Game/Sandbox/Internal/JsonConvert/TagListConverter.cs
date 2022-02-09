using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Internal.JsonConvert
{
	// Token: 0x02000191 RID: 401
	public class TagListConverter : JsonConverter<TagList>
	{
		// Token: 0x06001CC4 RID: 7364 RVA: 0x00072460 File Offset: 0x00070660
		public override TagList Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return new TagList(reader.GetString());
			}
			if (reader.TokenType == JsonTokenType.StartArray)
			{
				reader.Read();
				TagList tagList = new TagList();
				while (reader.TokenType != JsonTokenType.EndArray)
				{
					if (reader.TokenType == JsonTokenType.String)
					{
						tagList.Add(reader.GetString());
					}
					else if (reader.TokenType == JsonTokenType.Number)
					{
						tagList.Add(reader.GetSingle().ToString());
					}
					else
					{
						GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("TagListrFromJson - unable to read from {0}", new object[] { reader.TokenType }));
					}
					reader.Read();
				}
				return tagList;
			}
			return null;
		}

		// Token: 0x06001CC5 RID: 7365 RVA: 0x00072510 File Offset: 0x00070710
		public override void Write(Utf8JsonWriter writer, TagList val, JsonSerializerOptions options)
		{
			writer.WriteStringValue(string.Join(",", val) ?? "");
		}
	}
}
