using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Internal.JsonConvert
{
	// Token: 0x0200006F RID: 111
	public class ColorConverter : JsonConverter<Color>
	{
		// Token: 0x060004B5 RID: 1205 RVA: 0x00021714 File Offset: 0x0001F914
		public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return Vector4.Parse(reader.GetString());
			}
			if (reader.TokenType == JsonTokenType.StartArray)
			{
				reader.Read();
				Color v = Color.White;
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.r = reader.GetSingle();
					reader.Read();
				}
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.g = reader.GetSingle();
					reader.Read();
				}
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.b = reader.GetSingle();
					reader.Read();
				}
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.a = reader.GetSingle();
					reader.Read();
				}
				while (reader.TokenType != JsonTokenType.EndArray)
				{
					reader.Read();
				}
				return v;
			}
			GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("ColorFromJson - unable to read from {0}", new object[] { reader.TokenType }));
			return default(Color);
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x00021810 File Offset: 0x0001FA10
		public override void Write(Utf8JsonWriter writer, Color val, JsonSerializerOptions options)
		{
			writer.WriteStringValue(string.Format("{0:0.#####},{1:0.#####},{2:0.#####},{3:0.#####}", new object[] { val.r, val.g, val.b, val.a }));
		}
	}
}
