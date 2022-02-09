using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Internal.JsonConvert
{
	// Token: 0x02000074 RID: 116
	public class Vector3Converter : JsonConverter<Vector3>
	{
		// Token: 0x060004C4 RID: 1220 RVA: 0x00021D50 File Offset: 0x0001FF50
		public override Vector3 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return Vector3.Parse(reader.GetString());
			}
			if (reader.TokenType == JsonTokenType.StartArray)
			{
				reader.Read();
				Vector3 v = default(Vector3);
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
				while (reader.TokenType != JsonTokenType.EndArray)
				{
					reader.Read();
				}
				return v;
			}
			GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Vector3FromJson - unable to read from {0}", new object[] { reader.TokenType }));
			return default(Vector3);
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x00021E26 File Offset: 0x00020026
		public override void Write(Utf8JsonWriter writer, Vector3 val, JsonSerializerOptions options)
		{
			writer.WriteStringValue(string.Format("{0:0.#################################},{1:0.#################################},{2:0.#################################}", val.x, val.y, val.z));
		}
	}
}
