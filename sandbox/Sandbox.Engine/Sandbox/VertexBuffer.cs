using System;
using System.Collections.Generic;

namespace Sandbox
{
	// Token: 0x020002D0 RID: 720
	public class VertexBuffer
	{
		// Token: 0x1700037C RID: 892
		// (get) Token: 0x0600128F RID: 4751 RVA: 0x000271A8 File Offset: 0x000253A8
		// (set) Token: 0x06001290 RID: 4752 RVA: 0x000271B0 File Offset: 0x000253B0
		public bool Indexed { get; private set; }

		// Token: 0x06001291 RID: 4753 RVA: 0x000271B9 File Offset: 0x000253B9
		public virtual void Clear()
		{
			this.Vertex.Clear();
			this.Index.Clear();
			this.Default = default(Vertex);
		}

		// Token: 0x06001292 RID: 4754 RVA: 0x000271DD File Offset: 0x000253DD
		public virtual void Init(bool useIndexBuffer)
		{
			this.Indexed = useIndexBuffer;
			this.Clear();
		}

		/// <summary>
		/// Add a vertex
		/// </summary>
		// Token: 0x06001293 RID: 4755 RVA: 0x000271EC File Offset: 0x000253EC
		public void Add(Vertex v)
		{
			this.Vertex.Add(v);
		}

		/// <summary>
		/// Add an index. This is relative to the top of the vertex buffer. So 0 is Vertex.Count., 1 is Vertex.Count -1
		/// </summary>
		// Token: 0x06001294 RID: 4756 RVA: 0x000271FA File Offset: 0x000253FA
		public void AddIndex(int i)
		{
			this.AddRawIndex(this.Vertex.Count - i);
		}

		/// <summary>
		/// Add an index. This is relative to the top of the vertex buffer. So 0 is Vertex.Count.
		/// </summary>
		// Token: 0x06001295 RID: 4757 RVA: 0x0002720F File Offset: 0x0002540F
		public void AddTriangleIndex(int a, int b, int c)
		{
			this.AddIndex(a);
			this.AddIndex(b);
			this.AddIndex(c);
		}

		/// <summary>
		/// Add an index. This is relative to the top of the vertex buffer. So 0 is Vertex.Count.
		/// </summary>
		// Token: 0x06001296 RID: 4758 RVA: 0x00027226 File Offset: 0x00025426
		public void AddRawIndex(int i)
		{
			this.Index.Add((ushort)i);
		}

		// Token: 0x0400148E RID: 5262
		internal List<Vertex> Vertex = new List<Vertex>(32);

		// Token: 0x0400148F RID: 5263
		internal List<ushort> Index = new List<ushort>(32);

		// Token: 0x04001491 RID: 5265
		public Vertex Default;
	}
}
