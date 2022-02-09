using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Internal.JsonConvert
{
	// Token: 0x02000075 RID: 117
	public class Vector4Converter : JsonConverter<Vector4>
	{
		// Token: 0x060004C7 RID: 1223 RVA: 0x00021E64 File Offset: 0x00020064
		public override Vector4 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return Vector4.Parse(reader.GetString());
			}
			if (reader.TokenType == JsonTokenType.StartArray)
			{
				reader.Read();
				Vector4 v = default(Vector4);
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
			GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Vector4FromJson - unable to read from {0}", new object[] { reader.TokenType }));
			return default(Vector4);
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x00021F5A File Offset: 0x0002015A
		public override void Write(Utf8JsonWriter writer, Vector4 val, JsonSerializerOptions options)
		{
			writer.WriteStringValue(val.ToString());
		}
	}
}
