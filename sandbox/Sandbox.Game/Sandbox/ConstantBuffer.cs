using System;
using System.Runtime.InteropServices;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000E5 RID: 229
	public class ConstantBuffer : IDisposable
	{
		// Token: 0x170002DA RID: 730
		// (get) Token: 0x06001385 RID: 4997 RVA: 0x0004F704 File Offset: 0x0004D904
		public bool Valid
		{
			get
			{
				return this.bufferHandle != IntPtr.Zero && this.dataSize > 0;
			}
		}

		// Token: 0x170002DB RID: 731
		// (get) Token: 0x06001386 RID: 4998 RVA: 0x0004F723 File Offset: 0x0004D923
		public int Size
		{
			get
			{
				return this.dataSize;
			}
		}

		// Token: 0x06001387 RID: 4999 RVA: 0x0004F72B File Offset: 0x0004D92B
		internal ConstantBuffer(IntPtr native, int dataSize)
		{
			if (native == IntPtr.Zero)
			{
				throw new Exception("Constant buffer cannot be null!");
			}
			if (dataSize <= 0)
			{
				throw new Exception("Invalid data size!");
			}
			this.bufferHandle = native;
			this.dataSize = dataSize;
		}

		// Token: 0x06001388 RID: 5000 RVA: 0x0004F768 File Offset: 0x0004D968
		~ConstantBuffer()
		{
			this.Dispose();
		}

		/// <summary>
		/// Create a new constant buffer for shaders from a predefined struct
		/// </summary>
		/// <typeparam name="T">Underlying constant buffer struct</typeparam>
		/// <param name="inputStruct">Input starting constbuffer data</param>
		/// <param name="isDynamic">use dynamic constant buffer flag</param>
		// Token: 0x06001389 RID: 5001 RVA: 0x0004F794 File Offset: 0x0004D994
		public static ConstantBuffer Create<T>(T inputStruct, bool isDynamic = false) where T : struct
		{
			int structDataSize = Marshal.SizeOf<T>(inputStruct);
			IntPtr structPtr = Marshal.AllocHGlobal(structDataSize);
			ConstantBuffer result;
			try
			{
				Marshal.StructureToPtr<T>(inputStruct, structPtr, false);
				result = new ConstantBuffer(GameGlue.CreateConstantBuffer(isDynamic, structPtr, structDataSize), structDataSize);
			}
			finally
			{
				Marshal.FreeHGlobal(structPtr);
			}
			return result;
		}

		/// <summary>
		/// Updates the constant buffer contents. Note, the structure size needs to be identical to when the const buffer was first constructed
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="inputStruct"></param>
		/// <returns></returns>
		// Token: 0x0600138A RID: 5002 RVA: 0x0004F7E0 File Offset: 0x0004D9E0
		public bool Update<T>(T inputStruct) where T : struct
		{
			int structDataSize = Marshal.SizeOf<T>(inputStruct);
			if (structDataSize != this.dataSize)
			{
				throw new Exception("Struct size does not match constbuffer!");
			}
			Render.AssertRenderBlock();
			IntPtr structPtr = Marshal.AllocHGlobal(structDataSize);
			bool result;
			try
			{
				Marshal.StructureToPtr<T>(inputStruct, structPtr, false);
				result = GameGlue.UpdateConstantBuffer(Render.RenderContext, this.bufferHandle, structPtr, structDataSize);
			}
			finally
			{
				Marshal.FreeHGlobal(structPtr);
			}
			return result;
		}

		// Token: 0x0600138B RID: 5003 RVA: 0x0004F850 File Offset: 0x0004DA50
		public void Dispose()
		{
			if (this.Valid)
			{
				GameGlue.DestroyConstantBuffer(this.bufferHandle);
				this.dataSize = 0;
			}
		}

		// Token: 0x0400047B RID: 1147
		internal IntPtr bufferHandle;

		// Token: 0x0400047C RID: 1148
		internal int dataSize;
	}
}
