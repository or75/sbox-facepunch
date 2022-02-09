using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// This is a path class, used with Hammer's Path Tool.
	/// </summary>
	// Token: 0x02000208 RID: 520
	[AttributeUsage(AttributeTargets.Class)]
	public class PathAttribute : MetaDataAttribute
	{
		/// <param name="nodeClassName">Class name of the node entity.</param>
		/// <param name="spawnEnts">If set to true, will actually create node entities. If set to false, node data will be serialized to a JSON key-value.</param>
		// Token: 0x06000D17 RID: 3351 RVA: 0x00016675 File Offset: 0x00014875
		public PathAttribute(string nodeClassName = null, bool spawnEnts = false)
		{
			this.NodeClassName = nodeClassName;
			this.SpawnEntities = spawnEnts;
		}

		// Token: 0x06000D18 RID: 3352 RVA: 0x0001668C File Offset: 0x0001488C
		public override void AddMetaData(StringBuilder sb)
		{
			if (this.NodeClassName != null)
			{
				StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(21, 1, sb);
				appendInterpolatedStringHandler.AppendLiteral("\tnode_entity_class = ");
				appendInterpolatedStringHandler.AppendFormatted(this.NodeClassName.QuoteSafe());
				sb.AppendLine(ref appendInterpolatedStringHandler);
			}
			if (this.SpawnEntities)
			{
				sb.AppendLine("\tspawn_node_entities = 1");
			}
		}

		// Token: 0x04000DE1 RID: 3553
		private string NodeClassName;

		// Token: 0x04000DE2 RID: 3554
		private bool SpawnEntities;
	}
}
