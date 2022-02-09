using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Internal.JsonConvert
{
	// Token: 0x02000070 RID: 112
	public class AnglesConverter : JsonConverter<Angles>
	{
		// Token: 0x060004B8 RID: 1208 RVA: 0x00021874 File Offset: 0x0001FA74
		public override Angles Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return Angles.Parse(reader.GetString());
			}
			if (reader.TokenType == JsonTokenType.StartArray)
			{
				reader.Read();
				Angles v = default(Angles);
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.pitch = reader.GetSingle();
					reader.Read();
				}
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.yaw = reader.GetSingle();
					reader.Read();
				}
				if (reader.TokenType == JsonTokenType.Number)
				{
					v.roll = reader.GetSingle();
					reader.Read();
				}
				while (reader.TokenType != JsonTokenType.EndArray)
				{
					reader.Read();
				}
				return v;
			}
			GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("AnglesConverter - unable to read from {0}", new object[] { reader.TokenType }));
			return default(Angles);
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x0002194A File Offset: 0x0001FB4A
		public override void Write(Utf8JsonWriter writer, Angles val, JsonSerializerOptions options)
		{
			writer.WriteStringValue(string.Format("{0:0.####},{1:0.####},{2:0.####}", val.pitch, val.yaw, val.roll));
		}
	}
}
