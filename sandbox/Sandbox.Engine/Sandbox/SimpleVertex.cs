using System;

namespace Sandbox
{
	// Token: 0x020002C8 RID: 712
	public struct SimpleVertex
	{
		// Token: 0x06001237 RID: 4663 RVA: 0x000263DA File Offset: 0x000245DA
		public SimpleVertex(Vector3 position, Vector3 normal, Vector3 tangent, Vector2 texcoord)
		{
			this.position = position;
			this.normal = normal;
			this.tangent = tangent;
			this.texcoord = texcoord;
		}

		// Token: 0x04001468 RID: 5224
		public Vector3 position;

		// Token: 0x04001469 RID: 5225
		public Vector3 normal;

		// Token: 0x0400146A RID: 5226
		public Vector3 tangent;

		// Token: 0x0400146B RID: 5227
		public Vector2 texcoord;

		// Token: 0x0400146C RID: 5228
		public static readonly VertexAttribute[] Layout = new VertexAttribute[]
		{
			new VertexAttribute(VertexAttributeType.Position, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttribute(VertexAttributeType.Normal, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttribute(VertexAttributeType.Tangent, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttribute(VertexAttributeType.TexCoord, VertexAttributeFormat.Float32, 2, 0)
		};
	}
}
