using System;
using System.Text;

namespace Hammer
{
	/// <summary>
	/// Used by light_environment entity internally.
	/// </summary>
	// Token: 0x0200021D RID: 541
	[AttributeUsage(AttributeTargets.Class)]
	internal class BakeSkyLightAttribute : MetaDataAttribute
	{
		// Token: 0x06000D46 RID: 3398 RVA: 0x0001739B File Offset: 0x0001559B
		public override void AddHeader(StringBuilder sb)
		{
			sb.Append("bakeskylight( skycolor, skyintensity, lower_hemisphere_is_black, skytexture, skytexturescale, skyambientbounce, sunlightminbrightness ) ");
		}
	}
}
