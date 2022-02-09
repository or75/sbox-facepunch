using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020002C1 RID: 705
	public class Mesh
	{
		// Token: 0x060011CC RID: 4556 RVA: 0x00024134 File Offset: 0x00022334
		public Mesh()
			: this(null, MeshPrimitiveType.Triangles)
		{
		}

		// Token: 0x060011CD RID: 4557 RVA: 0x00024140 File Offset: 0x00022340
		public Mesh(Material material, MeshPrimitiveType primType = MeshPrimitiveType.Triangles)
		{
			this.native = MeshGlue.CreateRenderMesh((material != null) ? material.native : IntPtr.Zero, (int)Mesh.MeshPrimTypeToRenderPrimType(primType));
			if (this.native.IsNull)
			{
				throw new Exception("RenderMesh pointer cannot be null!");
			}
			this.instanceId = this.native.GetBindingPtr().ToInt64();
		}

		// Token: 0x060011CE RID: 4558 RVA: 0x000241AA File Offset: 0x000223AA
		private Mesh(IMesh native, long instanceId)
		{
			if (native.IsNull)
			{
				throw new Exception("RenderMesh pointer cannot be null!");
			}
			this.native = native;
			this.instanceId = instanceId;
		}

		// Token: 0x060011CF RID: 4559 RVA: 0x000241D4 File Offset: 0x000223D4
		~Mesh()
		{
			this.native.DestroyStrongHandle();
			this.native = default(IMesh);
		}

		// Token: 0x17000358 RID: 856
		// (get) Token: 0x060011D0 RID: 4560 RVA: 0x00024214 File Offset: 0x00022414
		public bool IsValid
		{
			get
			{
				return this.native.IsValid && this.native.IsStrongHandleValid();
			}
		}

		// Token: 0x17000359 RID: 857
		// (set) Token: 0x060011D1 RID: 4561 RVA: 0x00024230 File Offset: 0x00022430
		public MeshPrimitiveType PrimitiveType
		{
			set
			{
				MeshGlue.SetMeshPrimType(this.native, (int)Mesh.MeshPrimTypeToRenderPrimType(value));
			}
		}

		// Token: 0x1700035A RID: 858
		// (set) Token: 0x060011D2 RID: 4562 RVA: 0x00024243 File Offset: 0x00022443
		public Material Material
		{
			set
			{
				MeshGlue.SetMeshMaterial(this.native, (value != null) ? value.native : IntPtr.Zero);
			}
		}

		// Token: 0x1700035B RID: 859
		// (set) Token: 0x060011D3 RID: 4563 RVA: 0x00024265 File Offset: 0x00022465
		public BBox Bounds
		{
			set
			{
				this.SetBounds(value.Mins, value.Maxs);
			}
		}

		/// <summary>
		/// Set the render bounds of this mesh, default is infinite
		/// </summary>
		// Token: 0x060011D4 RID: 4564 RVA: 0x00024279 File Offset: 0x00022479
		public void SetBounds(Vector3 mins, Vector3 maxs)
		{
			MeshGlue.SetMeshBounds(this.native, mins, maxs);
		}

		/// <summary>
		/// Set how many vertices this mesh draws (if there's no index buffer)
		/// </summary>
		// Token: 0x060011D5 RID: 4565 RVA: 0x00024288 File Offset: 0x00022488
		public void SetVertexRange(int start, int count)
		{
			MeshGlue.SetMeshVertexRange(this.native, start, count);
		}

		/// <summary>
		/// Set how many indices this mesh draws
		/// </summary>
		// Token: 0x060011D6 RID: 4566 RVA: 0x00024297 File Offset: 0x00022497
		public void SetIndexRange(int start, int count)
		{
			MeshGlue.SetMeshIndexRange(this.native, start, count);
		}

		// Token: 0x060011D7 RID: 4567 RVA: 0x000242A8 File Offset: 0x000224A8
		public void CreateBuffers(VertexBuffer vb, bool calculateBounds = true)
		{
			Span<Vertex> vertices_span = CollectionsMarshal.AsSpan<Vertex>(vb.Vertex);
			this.CreateVertexBuffer<Vertex>(vb.Vertex.Count, Vertex.Layout, vertices_span);
			if (vb.Indexed)
			{
				int[] indices = new int[vb.Index.Count];
				for (int i = 0; i < indices.Length; i++)
				{
					indices[i] = (int)vb.Index[i];
				}
				this.CreateIndexBuffer(vb.Index.Count, indices);
			}
			if (calculateBounds)
			{
				BBox bounds = default(BBox);
				foreach (Vertex v in vb.Vertex)
				{
					bounds = bounds.AddPoint(v.Position);
				}
				this.Bounds = bounds;
			}
		}

		// Token: 0x060011D8 RID: 4568 RVA: 0x00024388 File Offset: 0x00022588
		private static RenderPrimitiveType MeshPrimTypeToRenderPrimType(MeshPrimitiveType primType)
		{
			RenderPrimitiveType renderPrimType;
			switch (primType)
			{
			case MeshPrimitiveType.Points:
				renderPrimType = RenderPrimitiveType.RENDER_PRIM_POINTS;
				break;
			case MeshPrimitiveType.Lines:
				renderPrimType = RenderPrimitiveType.RENDER_PRIM_LINES;
				break;
			case MeshPrimitiveType.LineStrip:
				renderPrimType = RenderPrimitiveType.RENDER_PRIM_LINE_STRIP;
				break;
			case MeshPrimitiveType.Triangles:
				renderPrimType = RenderPrimitiveType.RENDER_PRIM_TRIANGLES;
				break;
			case MeshPrimitiveType.TriangleStrip:
				renderPrimType = RenderPrimitiveType.RENDER_PRIM_TRIANGLE_STRIP;
				break;
			default:
				renderPrimType = RenderPrimitiveType.RENDER_PRIM_TRIANGLES;
				break;
			}
			return renderPrimType;
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x060011D9 RID: 4569 RVA: 0x000243C8 File Offset: 0x000225C8
		public bool HasIndexBuffer
		{
			get
			{
				return this.ib.IsValid;
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x060011DA RID: 4570 RVA: 0x000243D5 File Offset: 0x000225D5
		public int IndexCount
		{
			get
			{
				if (!this.HasIndexBuffer)
				{
					return 0;
				}
				return this.ib.elementCount;
			}
		}

		/// <summary>
		/// Create a index buffer with a number of indices
		/// </summary>
		// Token: 0x060011DB RID: 4571 RVA: 0x000243EC File Offset: 0x000225EC
		public void CreateIndexBuffer(int indexCount, List<int> data)
		{
			this.CreateIndexBuffer(indexCount, CollectionsMarshal.AsSpan<int>(data));
		}

		/// <summary>
		/// Create a index buffer with a number of indices
		/// </summary>
		// Token: 0x060011DC RID: 4572 RVA: 0x000243FC File Offset: 0x000225FC
		public unsafe void CreateIndexBuffer(int indexCount, Span<int> data = default(Span<int>))
		{
			if (this.ib.IsValid)
			{
				throw new Exception("Index buffer has already been created");
			}
			if (indexCount <= 0)
			{
				throw new ArgumentException("Creating index buffer with zero index count");
			}
			fixed (int* pinnableReference = data.GetPinnableReference())
			{
				int* data_ptr = pinnableReference;
				IntPtr handle = MeshGlue.CreateIndexBuffer(indexCount, true, (IntPtr)((void*)data_ptr), (data != null) ? (data.Length * 4) : 0);
				if (handle == IntPtr.Zero)
				{
					throw new Exception("Failed to create index buffer");
				}
				this.ib.native = handle;
				this.ib.lockData = IntPtr.Zero;
				this.ib.elementCount = indexCount;
				this.ib.lockDataSize = 0;
				this.ib.lockDataOffset = 0;
				this.ib.locked = false;
				MeshGlue.SetMeshIndexBuffer(this.native, this.ib.native, false);
				this.SetIndexRange(0, this.ib.elementCount);
			}
		}

		/// <summary>
		/// Set data of this buffer
		/// </summary>
		// Token: 0x060011DD RID: 4573 RVA: 0x000244F3 File Offset: 0x000226F3
		public void SetIndexBufferData(List<int> data, int elementOffset = 0)
		{
			this.SetIndexBufferData(CollectionsMarshal.AsSpan<int>(data), elementOffset);
		}

		/// <summary>
		/// Set data of this buffer
		/// </summary>
		// Token: 0x060011DE RID: 4574 RVA: 0x00024504 File Offset: 0x00022704
		public unsafe void SetIndexBufferData(Span<int> data, int elementOffset = 0)
		{
			if (!this.ib.IsValid)
			{
				throw new Exception("Index buffer has not been created");
			}
			if (this.ib.locked)
			{
				throw new Exception("Index buffer is currently locked");
			}
			if (data == null || data.Length == 0)
			{
				throw new ArgumentException("Invalid data for index buffer");
			}
			int elementCount = data.Length;
			if (elementOffset < 0 || elementOffset + elementCount > this.ib.elementCount)
			{
				throw new ArgumentException("Setting index buffer data out of range");
			}
			int elementSize = 4;
			int dataSize = elementCount * elementSize;
			int dataOffset = elementOffset * elementSize;
			fixed (int* pinnableReference = data.GetPinnableReference())
			{
				int* data_ptr = pinnableReference;
				MeshGlue.SetIndexBufferData(this.ib.native, (IntPtr)((void*)data_ptr), dataSize, dataOffset);
			}
		}

		/// <summary>
		/// Resize the index buffer
		/// </summary>
		// Token: 0x060011DF RID: 4575 RVA: 0x000245C0 File Offset: 0x000227C0
		public void SetIndexBufferSize(int elementCount)
		{
			if (!this.ib.IsValid)
			{
				throw new Exception("Index buffer has not been created");
			}
			if (this.ib.locked)
			{
				throw new Exception("Index buffer is currently locked");
			}
			if (this.ib.elementCount == elementCount)
			{
				return;
			}
			IntPtr handle = MeshGlue.SetIndexBufferSize(this.ib.native, elementCount);
			this.ib.native = handle;
			this.ib.elementCount = elementCount;
			MeshGlue.SetMeshIndexBuffer(this.native, this.ib.native, false);
		}

		// Token: 0x060011E0 RID: 4576 RVA: 0x00024650 File Offset: 0x00022850
		private Span<int> LockIndexBuffer(int elementCount, int elementOffset)
		{
			if (!this.ib.IsValid)
			{
				return null;
			}
			if (this.ib.locked)
			{
				return null;
			}
			if (elementCount <= 0)
			{
				throw new ArgumentException("Locking index buffer with zero element count");
			}
			if (elementOffset < 0)
			{
				throw new ArgumentException("Locking index buffer with negative element offset");
			}
			if (elementOffset + elementCount > this.ib.elementCount)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(53, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Locking index buffer outside elements allocated (");
				defaultInterpolatedStringHandler.AppendFormatted<int>(elementOffset + elementCount);
				defaultInterpolatedStringHandler.AppendLiteral(" > ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.ib.elementCount);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			int elementSize = 4;
			this.ib.lockDataSize = elementCount * elementSize;
			this.ib.lockDataOffset = elementOffset * elementSize;
			this.ib.lockData = MeshGlue.LockIndexBuffer(this.ib.native, this.ib.lockDataSize, this.ib.lockDataOffset);
			if (this.ib.lockData == IntPtr.Zero)
			{
				this.ib.lockDataSize = 0;
				this.ib.lockDataOffset = 0;
				return null;
			}
			this.ib.locked = true;
			return new Span<int>(this.ib.lockData.ToPointer(), elementCount);
		}

		// Token: 0x060011E1 RID: 4577 RVA: 0x000247B4 File Offset: 0x000229B4
		private void UnlockIndexBuffer()
		{
			if (!this.ib.IsValid)
			{
				return;
			}
			if (!this.ib.locked)
			{
				return;
			}
			MeshGlue.UnlockIndexBuffer(this.ib.native, this.ib.lockData, this.ib.lockDataSize, this.ib.lockDataOffset);
			this.ib.lockData = IntPtr.Zero;
			this.ib.lockDataSize = 0;
			this.ib.lockDataOffset = 0;
			this.ib.locked = false;
		}

		/// <summary>
		/// Lock all the memory in this buffer so you can write to it
		/// </summary>
		// Token: 0x060011E2 RID: 4578 RVA: 0x00024844 File Offset: 0x00022A44
		public void LockIndexBuffer(Mesh.IndexBufferLockHandler handler)
		{
			Span<int> data = this.LockIndexBuffer(this.ib.elementCount, 0);
			if (this.ib.locked)
			{
				handler(data);
				this.UnlockIndexBuffer();
			}
		}

		/// <summary>
		/// Lock a specific amount of the memory in this buffer so you can write to it
		/// </summary>
		// Token: 0x060011E3 RID: 4579 RVA: 0x00024880 File Offset: 0x00022A80
		public void LockIndexBuffer(int elementCount, Mesh.IndexBufferLockHandler handler)
		{
			Span<int> data = this.LockIndexBuffer(elementCount, 0);
			if (this.ib.locked)
			{
				handler(data);
				this.UnlockIndexBuffer();
			}
		}

		/// <summary>
		/// Lock a region of memory in this buffer so you can write to it
		/// </summary>
		// Token: 0x060011E4 RID: 4580 RVA: 0x000248B0 File Offset: 0x00022AB0
		public void LockIndexBuffer(int elementOffset, int elementCount, Mesh.IndexBufferLockHandler handler)
		{
			Span<int> data = this.LockIndexBuffer(elementCount, elementOffset);
			if (this.ib.locked)
			{
				handler(data);
				this.UnlockIndexBuffer();
			}
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x060011E5 RID: 4581 RVA: 0x000248E0 File Offset: 0x00022AE0
		public bool HasVertexBuffer
		{
			get
			{
				return this.vb.IsValid;
			}
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x060011E6 RID: 4582 RVA: 0x000248ED File Offset: 0x00022AED
		public int VertexCount
		{
			get
			{
				if (!this.HasVertexBuffer)
				{
					return 0;
				}
				return this.vb.elementCount;
			}
		}

		/// <summary>
		/// Create a vertex buffer with a number of vertices, an array of vertex attributes can be passed in
		/// </summary>
		// Token: 0x060011E7 RID: 4583 RVA: 0x00024904 File Offset: 0x00022B04
		public void CreateVertexBuffer<[IsUnmanaged] T>(int vertexCount, VertexAttribute[] layout, List<T> data) where T : struct, ValueType
		{
			this.CreateVertexBuffer<T>(vertexCount, layout, CollectionsMarshal.AsSpan<T>(data));
		}

		/// <summary>
		/// Create a vertex buffer with a number of vertices, an array of vertex attributes can be passed in
		/// </summary>
		// Token: 0x060011E8 RID: 4584 RVA: 0x00024914 File Offset: 0x00022B14
		public unsafe void CreateVertexBuffer<[IsUnmanaged] T>(int vertexCount, VertexAttribute[] layout, Span<T> data = default(Span<T>)) where T : struct, ValueType
		{
			if (this.vb.IsValid)
			{
				throw new Exception("Vertex buffer has already been created");
			}
			if (vertexCount <= 0)
			{
				throw new ArgumentException("Creating vertex buffer with zero vertex count");
			}
			int vertexSize = Marshal.SizeOf<T>();
			if (vertexSize <= 0)
			{
				throw new ArgumentException("Creating vertex buffer with zero vertex size");
			}
			if (layout == null || layout.Length == 0)
			{
				throw new ArgumentException("Vertex layout is required");
			}
			if (layout.Length > 16)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(56, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Vertex layout supports up to 16 vertex fields, you have ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(layout.Length);
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			int layoutSize = 0;
			int fieldCount = 0;
			StringBuilder sb = new StringBuilder();
			foreach (VertexAttribute attribute in layout)
			{
				if (attribute.Components == 0)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 1);
					defaultInterpolatedStringHandler.AppendLiteral("Zero components in vertex attribute ");
					defaultInterpolatedStringHandler.AppendFormatted<VertexAttributeType>(attribute.Type);
					throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				if (attribute.Components > 4)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(65, 2);
					defaultInterpolatedStringHandler.AppendLiteral("Too many components in vertex attribute ");
					defaultInterpolatedStringHandler.AppendFormatted<VertexAttributeType>(attribute.Type);
					defaultInterpolatedStringHandler.AppendLiteral(", 4 is the max, you have ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(attribute.Components);
					throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				int fieldSize = Mesh.vertexAttributeFormatSizes[(int)attribute.Format] * attribute.Components;
				string fieldName = Mesh.vertexAttributeTypeNames[(int)attribute.Type];
				ColorFormat format = attribute.GetColorFormat();
				if (format == ColorFormat.COLOR_FORMAT_UNKNOWN)
				{
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(56, 3);
					defaultInterpolatedStringHandler.AppendLiteral("Unknown/Unsupported vertex attribute color format (");
					defaultInterpolatedStringHandler.AppendFormatted<VertexAttributeType>(attribute.Type);
					defaultInterpolatedStringHandler.AppendLiteral(" ");
					defaultInterpolatedStringHandler.AppendFormatted<int>(attribute.Components);
					defaultInterpolatedStringHandler.AppendLiteral(" ");
					defaultInterpolatedStringHandler.AppendFormatted<VertexAttributeFormat>(attribute.Format);
					defaultInterpolatedStringHandler.AppendLiteral("'s)");
					throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
				}
				Mesh.vertexFields[fieldCount] = new VertexField
				{
					Format = format,
					Offset = layoutSize,
					NameSize = fieldName.Length,
					NameOffset = sb.Length,
					SemanticIndex = attribute.SemanticIndex
				};
				sb.Append(fieldName);
				layoutSize += fieldSize;
				fieldCount++;
			}
			if (layoutSize != vertexSize)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(68, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Vertex size mismatch with vertex layout (layout size ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(layoutSize);
				defaultInterpolatedStringHandler.AppendLiteral(", vertex size ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(vertexSize);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			VertexField[] array;
			VertexField* fields_ptr;
			if ((array = Mesh.vertexFields) == null || array.Length == 0)
			{
				fields_ptr = null;
			}
			else
			{
				fields_ptr = &array[0];
			}
			fixed (T* pinnableReference = data.GetPinnableReference())
			{
				T* data_ptr = pinnableReference;
				IntPtr handle = MeshGlue.CreateVertexBuffer(vertexSize, vertexCount, sb.ToString(), (IntPtr)((void*)fields_ptr), fieldCount, (IntPtr)((void*)data_ptr), (data != null) ? (data.Length * vertexSize) : 0);
				if (handle == IntPtr.Zero)
				{
					throw new Exception("Failed to create vertex buffer");
				}
				this.vb.native = handle;
				this.vb.lockData = IntPtr.Zero;
				this.vb.elementCount = vertexCount;
				this.vb.elementSize = vertexSize;
				this.vb.elementType = typeof(T);
				this.vb.lockDataSize = 0;
				this.vb.lockDataOffset = 0;
				this.vb.locked = false;
				MeshGlue.SetMeshVertexBuffer(this.native, this.vb.native, false);
				this.SetVertexRange(0, this.vb.elementCount);
			}
			array = null;
		}

		/// <summary>
		/// Set data of this buffer
		/// </summary>
		// Token: 0x060011E9 RID: 4585 RVA: 0x00024CD5 File Offset: 0x00022ED5
		public void SetVertexBufferData<[IsUnmanaged] T>(List<T> data, int elementOffset = 0) where T : struct, ValueType
		{
			this.SetVertexBufferData<T>(CollectionsMarshal.AsSpan<T>(data), elementOffset);
		}

		/// <summary>
		/// Set data of this buffer
		/// </summary>
		// Token: 0x060011EA RID: 4586 RVA: 0x00024CE4 File Offset: 0x00022EE4
		public unsafe void SetVertexBufferData<[IsUnmanaged] T>(Span<T> data, int elementOffset = 0) where T : struct, ValueType
		{
			if (!this.vb.IsValid)
			{
				throw new Exception("Vertex buffer has not been created");
			}
			if (this.vb.locked)
			{
				throw new Exception("Vertex buffer is currently locked");
			}
			if (this.vb.elementType != typeof(T))
			{
				throw new ArgumentException("Invalid vertex type for vertex buffer");
			}
			if (data == null || data.Length == 0)
			{
				throw new ArgumentException("Invalid data for vertex buffer");
			}
			int elementCount = data.Length;
			if (elementOffset < 0 || elementOffset + elementCount > this.vb.elementCount)
			{
				throw new ArgumentException("Setting vertex buffer data out of range");
			}
			int elementSize = Marshal.SizeOf<T>();
			int dataSize = elementCount * elementSize;
			int dataOffset = elementOffset * elementSize;
			fixed (T* pinnableReference = data.GetPinnableReference())
			{
				T* data_ptr = pinnableReference;
				MeshGlue.SetVertexBufferData(this.vb.native, (IntPtr)((void*)data_ptr), dataSize, dataOffset);
			}
		}

		/// <summary>
		/// Resize the vertex buffer
		/// </summary>
		// Token: 0x060011EB RID: 4587 RVA: 0x00024DCC File Offset: 0x00022FCC
		public void SetVertexBufferSize(int elementCount)
		{
			if (!this.vb.IsValid)
			{
				throw new Exception("Vertex buffer has not been created");
			}
			if (this.vb.locked)
			{
				throw new Exception("Vertex buffer is currently locked");
			}
			if (this.vb.elementCount == elementCount)
			{
				return;
			}
			IntPtr handle = MeshGlue.SetVertexBufferSize(this.vb.native, elementCount);
			this.vb.native = handle;
			this.vb.elementCount = elementCount;
			MeshGlue.SetMeshVertexBuffer(this.native, this.vb.native, false);
		}

		// Token: 0x060011EC RID: 4588 RVA: 0x00024E5C File Offset: 0x0002305C
		private Span<T> LockVertexBuffer<T>(int elementCount, int elementOffset)
		{
			if (!this.vb.IsValid)
			{
				return null;
			}
			if (this.vb.locked)
			{
				return null;
			}
			if (elementCount <= 0)
			{
				throw new ArgumentException("Locking vertex buffer with zero element count");
			}
			if (elementOffset < 0)
			{
				throw new ArgumentException("Locking vertex buffer with negative element offset");
			}
			if (elementOffset + elementCount > this.vb.elementCount)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(54, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Locking vertex buffer outside elements allocated (");
				defaultInterpolatedStringHandler.AppendFormatted<int>(elementOffset + elementCount);
				defaultInterpolatedStringHandler.AppendLiteral(" > ");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.vb.elementCount);
				defaultInterpolatedStringHandler.AppendLiteral(")");
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (Marshal.SizeOf<T>() != this.vb.elementSize)
			{
				throw new ArgumentException("Locking vertex buffer with incorrect element type");
			}
			this.vb.lockDataSize = elementCount * this.vb.elementSize;
			this.vb.lockDataOffset = elementOffset * this.vb.elementSize;
			this.vb.lockData = MeshGlue.LockVertexBuffer(this.vb.native, this.vb.lockDataSize, this.vb.lockDataOffset);
			if (this.vb.lockData == IntPtr.Zero)
			{
				this.vb.lockDataSize = 0;
				this.vb.lockDataOffset = 0;
				return null;
			}
			this.vb.locked = true;
			return new Span<T>(this.vb.lockData.ToPointer(), elementCount);
		}

		// Token: 0x060011ED RID: 4589 RVA: 0x00024FEC File Offset: 0x000231EC
		private void UnlockVertexBuffer()
		{
			if (!this.vb.IsValid)
			{
				return;
			}
			if (!this.vb.locked)
			{
				return;
			}
			MeshGlue.UnlockVertexBuffer(this.vb.native, this.vb.lockData, this.vb.lockDataSize, this.vb.lockDataOffset);
			this.vb.lockData = IntPtr.Zero;
			this.vb.lockDataSize = 0;
			this.vb.lockDataOffset = 0;
			this.vb.locked = false;
		}

		/// <summary>
		/// Lock all the memory in this buffer so you can write to it
		/// </summary>
		// Token: 0x060011EE RID: 4590 RVA: 0x0002507C File Offset: 0x0002327C
		public void LockVertexBuffer<T>(Mesh.VertexBufferLockHandler<T> handler)
		{
			Span<T> data = this.LockVertexBuffer<T>(this.vb.elementCount, 0);
			if (this.vb.locked)
			{
				handler(data);
				this.UnlockVertexBuffer();
			}
		}

		/// <summary>
		/// Lock a specific amount of the memory in this buffer so you can write to it
		/// </summary>
		// Token: 0x060011EF RID: 4591 RVA: 0x000250B8 File Offset: 0x000232B8
		public void LockVertexBuffer<T>(int elementCount, Mesh.VertexBufferLockHandler<T> handler)
		{
			Span<T> data = this.LockVertexBuffer<T>(elementCount, 0);
			if (this.vb.locked)
			{
				handler(data);
				this.UnlockVertexBuffer();
			}
		}

		/// <summary>
		/// Lock a region of memory in this buffer so you can write to it
		/// </summary>
		// Token: 0x060011F0 RID: 4592 RVA: 0x000250E8 File Offset: 0x000232E8
		public void LockVertexBuffer<T>(int elementOffset, int elementCount, Mesh.VertexBufferLockHandler<T> handler)
		{
			Span<T> data = this.LockVertexBuffer<T>(elementCount, elementOffset);
			if (this.vb.locked)
			{
				handler(data);
				this.UnlockVertexBuffer();
			}
		}

		// Token: 0x04001430 RID: 5168
		internal IMesh native;

		// Token: 0x04001431 RID: 5169
		internal long instanceId;

		// Token: 0x04001432 RID: 5170
		private Mesh.IndexBufferDesc ib;

		// Token: 0x04001433 RID: 5171
		private static readonly int[] vertexAttributeFormatSizes = new int[] { 4, 2, 4, 4, 2, 2, 1, 1 };

		// Token: 0x04001434 RID: 5172
		private static readonly string[] vertexAttributeTypeNames = new string[] { "position", "normal", "tangent", "texcoord", "color", "blendindices", "blendweight" };

		// Token: 0x04001435 RID: 5173
		private static readonly VertexField[] vertexFields = new VertexField[16];

		// Token: 0x04001436 RID: 5174
		private Mesh.VertexBufferDesc vb;

		// Token: 0x0200040F RID: 1039
		private struct IndexBufferDesc
		{
			// Token: 0x17000496 RID: 1174
			// (get) Token: 0x06001803 RID: 6147 RVA: 0x000382B5 File Offset: 0x000364B5
			public bool IsValid
			{
				get
				{
					return this.native != IntPtr.Zero && this.elementCount > 0;
				}
			}

			// Token: 0x04001A40 RID: 6720
			public IntPtr native;

			// Token: 0x04001A41 RID: 6721
			public IntPtr lockData;

			// Token: 0x04001A42 RID: 6722
			public int elementCount;

			// Token: 0x04001A43 RID: 6723
			public int lockDataSize;

			// Token: 0x04001A44 RID: 6724
			public int lockDataOffset;

			// Token: 0x04001A45 RID: 6725
			public bool locked;
		}

		// Token: 0x02000410 RID: 1040
		// (Invoke) Token: 0x06001805 RID: 6149
		public delegate void IndexBufferLockHandler(Span<int> data);

		// Token: 0x02000411 RID: 1041
		private struct VertexBufferDesc
		{
			// Token: 0x17000497 RID: 1175
			// (get) Token: 0x06001808 RID: 6152 RVA: 0x000382D4 File Offset: 0x000364D4
			public bool IsValid
			{
				get
				{
					return this.native != IntPtr.Zero && this.elementSize > 0 && this.elementType != null;
				}
			}

			// Token: 0x04001A46 RID: 6726
			public IntPtr native;

			// Token: 0x04001A47 RID: 6727
			public IntPtr lockData;

			// Token: 0x04001A48 RID: 6728
			public int elementSize;

			// Token: 0x04001A49 RID: 6729
			public int elementCount;

			// Token: 0x04001A4A RID: 6730
			public Type elementType;

			// Token: 0x04001A4B RID: 6731
			public int lockDataSize;

			// Token: 0x04001A4C RID: 6732
			public int lockDataOffset;

			// Token: 0x04001A4D RID: 6733
			public bool locked;
		}

		// Token: 0x02000412 RID: 1042
		// (Invoke) Token: 0x0600180A RID: 6154
		public delegate void VertexBufferLockHandler<T>(Span<T> data);
	}
}
