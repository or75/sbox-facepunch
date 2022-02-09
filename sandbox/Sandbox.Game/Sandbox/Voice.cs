using System;
using System.Buffers;
using NativeEngine;
using Steamworks;

namespace Sandbox
{
	// Token: 0x02000071 RID: 113
	public static class Voice
	{
		/// <summary>
		/// Do we want to send our mic input to server?
		/// </summary>
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x06000C6A RID: 3178 RVA: 0x0003FE12 File Offset: 0x0003E012
		public static bool Enabled
		{
			get
			{
				return SoundSystem.IsVoiceEnabled();
			}
		}

		/// <summary>
		/// Do we want to play back our own voice?
		/// </summary>
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x06000C6B RID: 3179 RVA: 0x0003FE19 File Offset: 0x0003E019
		public static bool Loopback
		{
			get
			{
				return SoundSystem.IsVoiceLoopbackEnabled();
			}
		}

		/// <summary>
		/// Available clientside, this is the sample rate that we're encoding our voice at
		/// </summary>
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x06000C6C RID: 3180 RVA: 0x0003FE20 File Offset: 0x0003E020
		public static int SampleRate
		{
			get
			{
				if (!Host.IsClient)
				{
					return 0;
				}
				return (int)SteamUser.SampleRate;
			}
		}

		/// <summary>
		/// Returns true if your voice is actually recording. This means you're pressing your PTT key (or have always talk on)
		/// and you're actually making noise that is being recorded and sent to other computers.
		/// </summary>
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06000C6D RID: 3181 RVA: 0x0003FE30 File Offset: 0x0003E030
		public static bool IsRecording
		{
			get
			{
				return Host.IsClient && SteamUser.VoiceRecord;
			}
		}

		/// <summary>
		/// Decode the passed data. Returns true on success and gives out a data and size.
		/// </summary>
		// Token: 0x06000C6E RID: 3182 RVA: 0x0003FE40 File Offset: 0x0003E040
		public unsafe static int Decode(Span<byte> data, Span<byte> outBuffer)
		{
			Host.AssertClient("Decode");
			fixed (byte* pinnableReference = data.GetPinnableReference())
			{
				void* value = (void*)pinnableReference;
				fixed (byte* pinnableReference2 = outBuffer.GetPinnableReference())
				{
					byte* outPtr = pinnableReference2;
					return SteamUser.DecompressVoice((IntPtr)value, data.Length, (IntPtr)((void*)outPtr), outBuffer.Length);
				}
			}
		}

		/// <summary>
		/// Play this voice data
		/// </summary>
		// Token: 0x06000C6F RID: 3183 RVA: 0x0003FE8C File Offset: 0x0003E08C
		internal static void Play(long playerId, Span<byte> data, bool encoded = true)
		{
			Host.AssertClient("Play");
			byte[] decodedData = ArrayPool<byte>.Shared.Rent(Math.Max(20480, data.Length * 4));
			if (encoded)
			{
				int len = Voice.Decode(data, decodedData);
				if (len == 0)
				{
					ArrayPool<byte>.Shared.Return(decodedData, false);
					return;
				}
				data = new Span<byte>(decodedData, 0, len);
			}
			float level = Voice.PlayVoiceInternal(data, playerId);
			if (decodedData != null)
			{
				ArrayPool<byte>.Shared.Return(decodedData, false);
			}
			GameBase gameBase = GameBase.Current;
			if (gameBase == null)
			{
				return;
			}
			gameBase.OnVoicePlayed(playerId, level);
		}

		/// <summary>
		/// Go through the data and try to work out the voice level
		/// </summary>
		// Token: 0x06000C70 RID: 3184 RVA: 0x0003FF14 File Offset: 0x0003E114
		internal unsafe static float ComputeVoiceLevel(short* samples, int sampleCount)
		{
			int minValue = 32767;
			int maxValue = -32768;
			for (int i = 0; i < sampleCount; i++)
			{
				short val = samples[i];
				minValue = Math.Min((int)val, minValue);
				maxValue = Math.Max((int)val, maxValue);
			}
			int delta = maxValue - minValue;
			return Math.Clamp((float)Math.Max(0, delta) / 32767f, 0f, 1f);
		}

		/// <summary>
		/// Actually send the voice data to the engine for playback.
		/// </summary>
		// Token: 0x06000C71 RID: 3185 RVA: 0x0003FF70 File Offset: 0x0003E170
		internal unsafe static float PlayVoiceInternal(Span<byte> data, long steamId)
		{
			if (data == null || data.Length <= 0)
			{
				return 0f;
			}
			int sampleCount = data.Length / 2;
			if (sampleCount <= 0)
			{
				return 0f;
			}
			fixed (byte* pinnableReference = data.GetPinnableReference())
			{
				byte* voiceDataPtr = pinnableReference;
				SoundSystem.AddVOIPData((ulong)steamId, -1, Voice.SampleRate, (IntPtr)((void*)voiceDataPtr), sampleCount, "CPlayerVoiceStream");
				return Voice.ComputeVoiceLevel((short*)voiceDataPtr, sampleCount);
			}
		}
	}
}
