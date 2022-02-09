using System;
using System.Runtime.InteropServices;

namespace Sandbox
{
	// Token: 0x020000EE RID: 238
	public static class VertexBufferExtension
	{
		/// <summary>
		/// Draw this mesh using Material
		/// </summary>
		// Token: 0x060013F1 RID: 5105 RVA: 0x0005141C File Offset: 0x0004F61C
		public unsafe static void Draw(this VertexBuffer self, Material material)
		{
			Render.Material = material;
			if (self.Indexed)
			{
				int icount = self.Index.Count;
				int vcount = self.Vertex.Count;
				if (icount < 3)
				{
					return;
				}
				Span<Vertex> vspan = CollectionsMarshal.AsSpan<Vertex>(self.Vertex);
				Span<ushort> ispan = CollectionsMarshal.AsSpan<ushort>(self.Index);
				fixed (Vertex* ptr = vspan[0])
				{
					Vertex* vertices = ptr;
					fixed (ushort* ptr2 = ispan[0])
					{
						ushort* imem = ptr2;
						Render.DrawIndexed(vertices, vcount, imem, icount);
					}
				}
				return;
			}
			else
			{
				int vcount2 = self.Vertex.Count;
				if (vcount2 < 3)
				{
					return;
				}
				fixed (Vertex* ptr = CollectionsMarshal.AsSpan<Vertex>(self.Vertex)[0])
				{
					Render.Draw(ptr, vcount2);
				}
				return;
			}
		}
	}
}
