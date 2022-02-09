using System;

namespace Sandbox
{
	// Token: 0x020002CF RID: 719
	public struct Vertex
	{
		// Token: 0x0600128C RID: 4748 RVA: 0x00027096 File Offset: 0x00025296
		public Vertex(Vector3 position, Vector4 texCoord0, Color32 color)
		{
			this = default(Vertex);
			this.Position = position;
			this.TexCoord0 = texCoord0;
			this.Color = color;
		}

		// Token: 0x0600128D RID: 4749 RVA: 0x000270B4 File Offset: 0x000252B4
		public Vertex(Vector3 position, Vector3 normal, Vector3 tangent, Vector4 texCoord0)
		{
			this = default(Vertex);
			this.Position = position;
			this.Normal = normal;
			this.Tangent = new Vector4(tangent.x, tangent.y, tangent.z, -1f);
			this.TexCoord0 = texCoord0;
			this.Color = Color32.White;
		}

		// Token: 0x04001485 RID: 5253
		public Vector3 Position;

		// Token: 0x04001486 RID: 5254
		public Color32 Color;

		// Token: 0x04001487 RID: 5255
		public Vector3 Normal;

		// Token: 0x04001488 RID: 5256
		public Vector4 TexCoord0;

		// Token: 0x04001489 RID: 5257
		public Vector4 TexCoord1;

		// Token: 0x0400148A RID: 5258
		public Vector4 TexCoord2;

		// Token: 0x0400148B RID: 5259
		public Vector4 TexCoord3;

		// Token: 0x0400148C RID: 5260
		public Vector4 Tangent;

		// Token: 0x0400148D RID: 5261
		public static readonly VertexAttribute[] Layout = new VertexAttribute[]
		{
			new VertexAttribute(VertexAttributeType.Position, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttribute(VertexAttributeType.Color, VertexAttributeFormat.UInt8, 4, 0),
			new VertexAttribute(VertexAttributeType.Normal, VertexAttributeFormat.Float32, 3, 0),
			new VertexAttribute(VertexAttributeType.TexCoord, VertexAttributeFormat.Float32, 4, 0),
			new VertexAttribute(VertexAttributeType.TexCoord, VertexAttributeFormat.Float32, 4, 1),
			new VertexAttribute(VertexAttributeType.TexCoord, VertexAttributeFormat.Float32, 4, 2),
			new VertexAttribute(VertexAttributeType.TexCoord, VertexAttributeFormat.Float32, 4, 3),
			new VertexAttribute(VertexAttributeType.Tangent, VertexAttributeFormat.Float32, 4, 0)
		};
	}
}
