using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Internal.JsonConvert
{
	// Token: 0x02000192 RID: 402
	public class FGDCurveConverter : JsonConverter<FGDCurve>
	{
		// Token: 0x06001CC7 RID: 7367 RVA: 0x00072534 File Offset: 0x00070734
		public override FGDCurve Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return new FGDCurve(reader.GetString());
			}
			return null;
		}

		// Token: 0x06001CC8 RID: 7368 RVA: 0x0007254C File Offset: 0x0007074C
		public override void Write(Utf8JsonWriter writer, FGDCurve val, JsonSerializerOptions options)
		{
			throw new NotImplementedException("Cannot serialize FGDCurve.");
		}
	}
}
