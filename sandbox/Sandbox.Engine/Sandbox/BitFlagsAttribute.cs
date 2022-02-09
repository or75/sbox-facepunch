using System;

namespace Sandbox
{
	/// <summary>
	/// This choices type is bitflags, so we should be able to choose more than one option at a time.
	/// </summary>
	// Token: 0x020002AC RID: 684
	[AttributeUsage(AttributeTargets.Property)]
	public class BitFlagsAttribute : FGDTypeAttribute
	{
		// Token: 0x06001153 RID: 4435 RVA: 0x00022AC4 File Offset: 0x00020CC4
		public BitFlagsAttribute()
			: base("flags", "BitFlags", "")
		{
		}
	}
}
