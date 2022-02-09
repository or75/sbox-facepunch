using System;
using System.Text;

namespace Hammer
{
	/// <summary>
	/// Used by light_environment entity internally.
	/// </summary>
	// Token: 0x0200021C RID: 540
	[AttributeUsage(AttributeTargets.Class)]
	internal class BakeAmbientOcclusionAttribute : MetaDataAttribute
	{
		// Token: 0x06000D44 RID: 3396 RVA: 0x00017385 File Offset: 0x00015585
		public override void AddHeader(StringBuilder sb)
		{
			sb.Append("bakeambientocclusion( ambient_occlusion, max_occlusion_distance, fully_occluded_fraction, occlusion_exponent ) ");
		}
	}
}
