using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Internal.JsonConvert
{
	// Token: 0x02000072 RID: 114
	public class RotationConverter : JsonConverter<Rotation>
	{
		// Token: 0x060004BE RID: 1214 RVA: 0x00021A7C File Offset: 0x0001FC7C
		public override Rotation Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return Rotation.Parse(reader.GetString());
			}
			if (reader.TokenType == JsonTokenType.StartArray)
			{
				reader.Read();
				Rotation v = default(Rotation);
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.x = reader.GetSingle();
					reader.Read();
				}
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.y = reader.GetSingle();
					reader.Read();
				}
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.z = reader.GetSingle();
					reader.Read();
				}
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.w = reader.GetSingle();
					reader.Read();
				}
				while (reader.TokenType != JsonTokenType.EndArray)
				{
					reader.Read();
				}
				return v;
			}
			GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("RotationConverter - unable to read from {0}", new object[] { reader.TokenType }));
			return default(Rotation);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x00021B74 File Offset: 0x0001FD74
		public override void Write(Utf8JsonWriter writer, Rotation val, JsonSerializerOptions options)
		{
			writer.WriteStringValue(string.Format("{0:0.#################################},{1:0.#################################},{2:0.#################################},{3:0.#################################}", new object[] { val.x, val.y, val.z, val.w }));
		}
	}
}
