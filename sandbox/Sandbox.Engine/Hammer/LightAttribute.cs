using System;
using System.Text;

namespace Hammer
{
	/// <summary>
	/// Internally marks this class in Hammer as a light.
	/// </summary>
	// Token: 0x02000218 RID: 536
	[AttributeUsage(AttributeTargets.Class)]
	internal class LightAttribute : MetaDataAttribute
	{
		// Token: 0x06000D3C RID: 3388 RVA: 0x0001729F File Offset: 0x0001549F
		public override void AddHeader(StringBuilder sb)
		{
			sb.Append("light() ");
		}
	}
}
