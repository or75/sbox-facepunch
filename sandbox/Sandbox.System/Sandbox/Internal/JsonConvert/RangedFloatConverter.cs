using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Internal.JsonConvert
{
	// Token: 0x02000071 RID: 113
	public class RangedFloatConverter : JsonConverter<RangedFloat>
	{
		// Token: 0x060004BB RID: 1211 RVA: 0x00021988 File Offset: 0x0001FB88
		public override RangedFloat Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return RangedFloat.Parse(reader.GetString());
			}
			if (reader.TokenType == JsonTokenType.StartArray)
			{
				reader.Read();
				RangedFloat v = default(RangedFloat);
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
			GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("RangedFloatFromJson - unable to read from {0}", new object[] { reader.TokenType }));
			return default(RangedFloat);
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x00021A5E File Offset: 0x0001FC5E
		public override void Write(Utf8JsonWriter writer, RangedFloat val, JsonSerializerOptions options)
		{
			writer.WriteStringValue(val.ToString());
		}
	}
}
