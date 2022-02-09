using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	// Token: 0x020000B5 RID: 181
	internal static class Helpers
	{
		// Token: 0x06000705 RID: 1797 RVA: 0x0000B2C9 File Offset: 0x000094C9
		internal static Helpers.Memory TakeMemory()
		{
			return Helpers.Memory.Take();
		}

		/// <summary>
		/// Returns a buffer. This will get returned and reused later on.
		/// We shouldn't really be using this anymore. 
		/// </summary>
		// Token: 0x06000706 RID: 1798 RVA: 0x0000B2D0 File Offset: 0x000094D0
		internal static byte[] TakeBuffer(int minSize)
		{
			byte[][] bufferPool = Helpers.BufferPool;
			byte[] result;
			lock (bufferPool)
			{
				Helpers.BufferPoolIndex++;
				if (Helpers.BufferPoolIndex >= Helpers.BufferPool.Length)
				{
					Helpers.BufferPoolIndex = 0;
				}
				if (Helpers.BufferPool[Helpers.BufferPoolIndex] == null)
				{
					Helpers.BufferPool[Helpers.BufferPoolIndex] = new byte[262144];
				}
				if (Helpers.BufferPool[Helpers.BufferPoolIndex].Length < minSize)
				{
					Helpers.BufferPool[Helpers.BufferPoolIndex] = new byte[minSize + 1024];
				}
				result = Helpers.BufferPool[Helpers.BufferPoolIndex];
			}
			return result;
		}

		// Token: 0x06000707 RID: 1799 RVA: 0x0000B380 File Offset: 0x00009580
		internal unsafe static string MemoryToString(IntPtr ptr)
		{
			int len = 0;
			while (len < 32768 && ((byte*)(void*)ptr)[len] != 0)
			{
				len++;
			}
			if (len == 0)
			{
				return string.Empty;
			}
			return Encoding.UTF8.GetString((byte*)(void*)ptr, len);
		}

		// Token: 0x06000708 RID: 1800 RVA: 0x0000B3C4 File Offset: 0x000095C4
		internal unsafe static string MemoryToString(IntPtr ptr, int len)
		{
			if (len == 0)
			{
				return string.Empty;
			}
			return Encoding.UTF8.GetString((byte*)(void*)ptr, len);
		}

		// Token: 0x0400095A RID: 2394
		internal const int MemoryBufferSize = 32768;

		// Token: 0x0400095B RID: 2395
		private static byte[][] BufferPool = new byte[4][];

		// Token: 0x0400095C RID: 2396
		private static int BufferPoolIndex;

		// Token: 0x02000364 RID: 868
		internal struct Memory : IDisposable
		{
			// Token: 0x1700044F RID: 1103
			// (get) Token: 0x0600164A RID: 5706 RVA: 0x000317C6 File Offset: 0x0002F9C6
			// (set) Token: 0x0600164B RID: 5707 RVA: 0x000317CE File Offset: 0x0002F9CE
			internal IntPtr Ptr { readonly get; private set; }

			// Token: 0x0600164C RID: 5708 RVA: 0x000317D7 File Offset: 0x0002F9D7
			public static implicit operator IntPtr(in Helpers.Memory m)
			{
				return m.Ptr;
			}

			// Token: 0x0600164D RID: 5709 RVA: 0x000317E0 File Offset: 0x0002F9E0
			internal unsafe static Helpers.Memory Take()
			{
				Queue<IntPtr> bufferBag = Helpers.Memory.BufferBag;
				IntPtr ptr;
				lock (bufferBag)
				{
					ptr = ((Helpers.Memory.BufferBag.Count > 0) ? Helpers.Memory.BufferBag.Dequeue() : Marshal.AllocHGlobal(32768));
				}
				*(byte*)(void*)ptr = 0;
				return new Helpers.Memory
				{
					Ptr = ptr
				};
			}

			// Token: 0x0600164E RID: 5710 RVA: 0x00031858 File Offset: 0x0002FA58
			public void Dispose()
			{
				if (this.Ptr == IntPtr.Zero)
				{
					return;
				}
				Queue<IntPtr> bufferBag = Helpers.Memory.BufferBag;
				lock (bufferBag)
				{
					if (Helpers.Memory.BufferBag.Count < 4)
					{
						Helpers.Memory.BufferBag.Enqueue(this.Ptr);
					}
					else
					{
						Marshal.FreeHGlobal(this.Ptr);
					}
				}
				this.Ptr = IntPtr.Zero;
			}

			// Token: 0x04001720 RID: 5920
			private const int MaxBagSize = 4;

			// Token: 0x04001721 RID: 5921
			private static readonly Queue<IntPtr> BufferBag = new Queue<IntPtr>();
		}
	}
}
