using System;
using System.Text;

namespace Hammer
{
	/// <summary>
	/// The light_spot visualizer.
	/// </summary>
	// Token: 0x02000219 RID: 537
	[AttributeUsage(AttributeTargets.Class)]
	internal class LightConeAttribute : MetaDataAttribute
	{
		// Token: 0x06000D3E RID: 3390 RVA: 0x000172B5 File Offset: 0x000154B5
		public override void AddHeader(StringBuilder sb)
		{
			sb.Append("lightcone() ");
		}
	}
}
