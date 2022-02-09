using System;
using NativeEngine;
using NativeGlue;

namespace Sandbox
{
	// Token: 0x0200007D RID: 125
	public struct SoundStream : IDisposable
	{
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x0004159D File Offset: 0x0003F79D
		public bool IsValid
		{
			get
			{
				return this.native.IsValid && this.Index > 0UL;
			}
		}

		// Token: 0x170000CB RID: 203
		// (get) Token: 0x06000CE2 RID: 3298 RVA: 0x000415B8 File Offset: 0x0003F7B8
		public int QueuedSampleCount
		{
			get
			{
				if (!this.native.IsValid)
				{
					return 0;
				}
				return (int)this.native.QueuedSampleCount();
			}
		}

		// Token: 0x06000CE3 RID: 3299 RVA: 0x000415D4 File Offset: 0x0003F7D4
		public unsafe void WriteData(Span<short> data)
		{
			if (!this.native.IsValid)
			{
				throw new ArgumentException("Invalid sound stream");
			}
			if (data == null || data.Length <= 0)
			{
				return;
			}
			fixed (short* pinnableReference = data.GetPinnableReference())
			{
				short* data_ptr = pinnableReference;
				this.native.WriteAudioData((IntPtr)((void*)data_ptr), (uint)((long)data.Length / (long)((ulong)this.channels)), this.channels);
			}
		}

		// Token: 0x06000CE4 RID: 3300 RVA: 0x00041648 File Offset: 0x0003F848
		public SoundStream Stop()
		{
			if (this.native.IsValid)
			{
				return this;
			}
			GameSoundManager.DestroyOutputStream(this.native);
			this.native = IntPtr.Zero;
			return this;
		}

		// Token: 0x06000CE5 RID: 3301 RVA: 0x0004167F File Offset: 0x0003F87F
		public SoundStream SetVolume(float volume)
		{
			if (this.Index <= 0UL)
			{
				return this;
			}
			GameSoundManager.SetVolume(this.Index, volume);
			return this;
		}

		// Token: 0x06000CE6 RID: 3302 RVA: 0x000416A4 File Offset: 0x0003F8A4
		public SoundStream SetPosition(Vector3 position)
		{
			if (this.Index <= 0UL)
			{
				return this;
			}
			GameSoundManager.SetPosition(this.Index, position);
			return this;
		}

		// Token: 0x06000CE7 RID: 3303 RVA: 0x000416C9 File Offset: 0x0003F8C9
		public void Dispose()
		{
			this.Stop();
		}

		// Token: 0x040001CF RID: 463
		public ulong Index;

		// Token: 0x040001D0 RID: 464
		internal AudioOutputStream native;

		// Token: 0x040001D1 RID: 465
		internal uint channels;
	}
}
