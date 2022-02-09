using System;
using NativeGlue;

namespace Sandbox
{
	// Token: 0x0200007C RID: 124
	public struct Sound
	{
		/// <summary>
		/// Set an override for the position and rotation of the local client's audio listener
		/// </summary>
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x06000CD3 RID: 3283 RVA: 0x00041323 File Offset: 0x0003F523
		// (set) Token: 0x06000CD4 RID: 3284 RVA: 0x0004132A File Offset: 0x0003F52A
		public static Transform? Listener { get; set; }

		/// <summary>
		/// Return the elapsed time from the start of the sound in seconds
		/// </summary>
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x06000CD5 RID: 3285 RVA: 0x00041332 File Offset: 0x0003F532
		public float ElapsedTime
		{
			get
			{
				return MathF.Max(GameSoundManager.GetElaspedTime((uint)this.Index), 0f);
			}
		}

		/// <summary>
		/// Returns if a song has finished playing
		/// </summary>
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x06000CD6 RID: 3286 RVA: 0x0004134A File Offset: 0x0003F54A
		public bool Finished
		{
			get
			{
				return GameSoundManager.GetElaspedTime((uint)this.Index) < 0f;
			}
		}

		/// <summary>
		/// Create a sound originating from a world position
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000CD7 RID: 3287 RVA: 0x00041360 File Offset: 0x0003F560
		public static Sound FromWorld(string name, Vector3 position)
		{
			Sound result;
			if (!Prediction.FirstTime || string.IsNullOrEmpty(name))
			{
				result = default(Sound);
				return result;
			}
			result = new Sound
			{
				Index = GameSoundManager.StartSoundEvent(Host.IsClient ? 0 : Prediction.CurrentHostIndex, name, position)
			};
			return result;
		}

		/// <summary>
		/// Create a sound originating from an entity
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000CD8 RID: 3288 RVA: 0x000413AC File Offset: 0x0003F5AC
		public static Sound FromEntity(string name, Entity entity)
		{
			if (!entity.IsValid())
			{
				entity = null;
			}
			Sound result;
			if (!Prediction.FirstTime || string.IsNullOrEmpty(name))
			{
				result = default(Sound);
				return result;
			}
			result = new Sound
			{
				Index = GameSoundManager.StartSoundEvent(Host.IsClient ? 0 : Prediction.CurrentHostIndex, name, entity.GetEntityIntPtr())
			};
			return result;
		}

		/// <summary>
		/// Create a sound originating from screen coordinates
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000CD9 RID: 3289 RVA: 0x00041408 File Offset: 0x0003F608
		public static Sound FromScreen(string name, float x = 0.5f, float y = 0.5f)
		{
			Sound result;
			if (!Prediction.FirstTime || string.IsNullOrEmpty(name))
			{
				result = default(Sound);
				return result;
			}
			result = new Sound
			{
				Index = GameSoundManager.StartSoundEvent(Host.IsClient ? 0 : Prediction.CurrentHostIndex, name, Vector3.Zero)
			};
			return result;
		}

		/// <summary>
		/// Stop the sound from playing
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000CDA RID: 3290 RVA: 0x00041458 File Offset: 0x0003F658
		public Sound Stop()
		{
			if (this.Index <= 0UL)
			{
				return this;
			}
			GameSoundManager.StopSoundEvent(this.Index);
			this.Index = 0UL;
			return this;
		}

		/// <summary>
		/// Set the volume of the sound
		/// </summary>
		/// <param name="volume"></param>
		/// <returns></returns>
		// Token: 0x06000CDB RID: 3291 RVA: 0x00041484 File Offset: 0x0003F684
		public Sound SetVolume(float volume)
		{
			if (this.Index <= 0UL)
			{
				return this;
			}
			GameSoundManager.SetVolume(this.Index, volume);
			return this;
		}

		/// <summary>
		/// Set pitch value (Note: this is always executed and is multiplied with the initial random pitch)
		/// </summary>
		// Token: 0x06000CDC RID: 3292 RVA: 0x000414A9 File Offset: 0x0003F6A9
		public Sound SetPitch(float pitch)
		{
			if (this.Index <= 0UL)
			{
				return this;
			}
			GameSoundManager.SetPitch(this.Index, pitch);
			return this;
		}

		/// <summary>
		/// Set random pitch value between min and max (Note: this is executed once)
		/// </summary>
		// Token: 0x06000CDD RID: 3293 RVA: 0x000414CE File Offset: 0x0003F6CE
		public Sound SetRandomPitch(float min, float max)
		{
			if (this.Index <= 0UL)
			{
				return this;
			}
			GameSoundManager.SetRandomPitch(this.Index, min, max);
			return this;
		}

		/// <summary>
		///  Set the world position that this sounds originates from
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000CDE RID: 3294 RVA: 0x000414F4 File Offset: 0x0003F6F4
		public Sound SetPosition(Vector3 position)
		{
			if (this.Index <= 0UL)
			{
				return this;
			}
			GameSoundManager.SetPosition(this.Index, position);
			return this;
		}

		// Token: 0x06000CDF RID: 3295 RVA: 0x0004151C File Offset: 0x0003F71C
		internal static void ResetListener()
		{
			Sound.Listener = null;
		}

		// Token: 0x06000CE0 RID: 3296 RVA: 0x00041538 File Offset: 0x0003F738
		public SoundStream CreateStream(int sampleRate = 44100, int channels = 1)
		{
			Host.AssertClientOrMenu("CreateStream");
			if (this.Index <= 0UL)
			{
				throw new ArgumentException("Trying to create sound stream on an invalid sound");
			}
			return new SoundStream
			{
				Index = this.Index,
				channels = (uint)channels,
				native = GameSoundManager.CreateAttachedOutputStream(this.Index, "vsnd_files", (uint)sampleRate, (uint)channels, 16U)
			};
		}

		// Token: 0x040001CE RID: 462
		public ulong Index;
	}
}
