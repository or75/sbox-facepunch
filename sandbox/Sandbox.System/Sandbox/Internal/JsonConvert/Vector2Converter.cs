using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Internal.JsonConvert
{
	// Token: 0x02000073 RID: 115
	public class Vector2Converter : JsonConverter<Vector2>
	{
		// Token: 0x060004C1 RID: 1217 RVA: 0x00021BDC File Offset: 0x0001FDDC
		public override Vector2 Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return Vector2.Parse(reader.GetString());
			}
			if (reader.TokenType == JsonTokenType.StartArray)
			{
				reader.Read();
				Vector2 v = default(Vector2);
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
				while (reader.TokenType != JsonTokenType.EndArray)
				{
					reader.Read();
				}
				return v;
			}
			if (reader.TokenType == JsonTokenType.StartObject)
			{
				reader.Read();
				Vector2 v2 = default(Vector2);
				while (reader.TokenType != JsonTokenType.EndObject)
				{
					if (reader.TokenType == JsonTokenType.PropertyName)
					{
						string name = reader.GetString();
						reader.Read();
						if (reader.TokenType == JsonTokenType.Number)
						{
							float val = reader.GetSingle();
							if (name == "x")
							{
								v2.x = val;
							}
							if (name == "y")
							{
								v2.x = val;
							}
						}
						reader.Read();
					}
					else
					{
						reader.Read();
					}
				}
				return v2;
			}
			GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Vector2FromJson - unable to read from {0}", new object[] { reader.TokenType }));
			return default(Vector2);
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x00021D1C File Offset: 0x0001FF1C
		public override void Write(Utf8JsonWriter writer, Vector2 val, JsonSerializerOptions options)
		{
			writer.WriteStringValue(string.Format("{0:0.#################################},{1:0.#################################}", val.x, val.y));
		}
	}
}
