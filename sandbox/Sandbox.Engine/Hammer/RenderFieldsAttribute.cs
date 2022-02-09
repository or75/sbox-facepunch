using System;
using System.Text;

namespace Hammer
{
	/// <summary>
	/// Adds the render color and other related options to the entity class in Hammer.
	/// </summary>
	/// <example>
	/// [Hammer.RenderFields]
	/// </example>
	// Token: 0x0200020D RID: 525
	[AttributeUsage(AttributeTargets.Class)]
	public class RenderFieldsAttribute : MetaDataAttribute
	{
		// Token: 0x06000D22 RID: 3362 RVA: 0x00016997 File Offset: 0x00014B97
		public override void AddBody(StringBuilder sb)
		{
			sb.AppendLine("\trendercolor(color255) { alpha = true } : \"Color (R G B A)\" : \"255 255 255 255\" : \"The color tint of this entity.\"");
		}
	}
}
