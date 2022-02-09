using System;
using System.Text;

namespace Hammer
{
	/// <summary>
	/// Tells Hammer that this entity has a particle effect keyvalue that needs to be visualized.
	/// </summary>
	// Token: 0x02000202 RID: 514
	[AttributeUsage(AttributeTargets.Class)]
	public class ParticleAttribute : MetaDataAttribute
	{
		// Token: 0x06000D0E RID: 3342 RVA: 0x000165F9 File Offset: 0x000147F9
		public override void AddHeader(StringBuilder sb)
		{
			sb.Append("particle() ");
		}
	}
}
