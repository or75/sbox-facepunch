using System;
using System.Collections.Generic;

namespace Hammer
{
	/// <summary>
	/// Makes this propery have a numeric slider with (if the FGD type is numeric) with given min/max values.
	/// </summary>
	// Token: 0x0200020E RID: 526
	[AttributeUsage(AttributeTargets.Property)]
	public class MinMaxAttribute : FieldMetaDataAttribute
	{
		// Token: 0x06000D23 RID: 3363 RVA: 0x000169A5 File Offset: 0x00014BA5
		public MinMaxAttribute(float min, float max)
		{
			this.MinValue = min;
			this.MaxValue = max;
		}

		// Token: 0x06000D24 RID: 3364 RVA: 0x000169BB File Offset: 0x00014BBB
		public override void AddMetaData(Dictionary<string, string> meta_data)
		{
			meta_data["min"] = this.MinValue.ToString();
			meta_data["max"] = this.MaxValue.ToString();
		}

		// Token: 0x04000DEC RID: 3564
		private float MinValue;

		// Token: 0x04000DED RID: 3565
		private float MaxValue;
	}
}
