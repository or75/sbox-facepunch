using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Sandbox.Internal.JsonConvert
{
	// Token: 0x020002F2 RID: 754
	public class MaterialConverter : JsonConverter<Material>
	{
		// Token: 0x06001407 RID: 5127 RVA: 0x0002AC14 File Offset: 0x00028E14
		public override Material Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.String)
			{
				return Material.Load(reader.GetString());
			}
			GlobalSystemNamespace.Log.Warning(FormattableStringFactory.Create("Json couldn't convert from {0} to material", new object[] { reader.TokenType }));
			return null;
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x0002AC54 File Offset: 0x00028E54
		public override void Write(Utf8JsonWriter writer, Material val, JsonSerializerOptions options)
		{
			writer.WriteStringValue("<material>");
		}
	}
}
