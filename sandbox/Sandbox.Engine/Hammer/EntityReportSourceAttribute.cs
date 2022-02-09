using System;
using System.Collections.Generic;

namespace Hammer
{
	/// <summary>
	/// Makes value of this property appear in the Source File column of the Entity Report dialog in Hammer.
	/// There can be only one of such properties.
	/// </summary>
	// Token: 0x02000217 RID: 535
	[AttributeUsage(AttributeTargets.Property)]
	public class EntityReportSourceAttribute : FieldMetaDataAttribute
	{
		// Token: 0x06000D3A RID: 3386 RVA: 0x00017285 File Offset: 0x00015485
		public override void AddMetaData(Dictionary<string, string> meta_data)
		{
			meta_data["report"] = "true";
		}
	}
}
