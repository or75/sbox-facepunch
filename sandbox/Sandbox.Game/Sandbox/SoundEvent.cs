using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox
{
	/// <summary>
	/// A sound event.
	/// </summary>
	// Token: 0x02000068 RID: 104
	[AutoGenerate]
	[Library("sound", Description = "A sound event.")]
	public class SoundEvent : Asset, IRuntimeAsset
	{
		/// <summary>
		/// Is this sound 2D?
		/// </summary>
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000BF7 RID: 3063 RVA: 0x0003E5CE File Offset: 0x0003C7CE
		// (set) Token: 0x06000BF8 RID: 3064 RVA: 0x0003E5D6 File Offset: 0x0003C7D6
		[Display(Name = "UI", Description = "Is this sound 2D?")]
		public bool UI { get; set; }

		/// <summary>
		/// How loud the sound should be.
		/// </summary>
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x06000BF9 RID: 3065 RVA: 0x0003E5DF File Offset: 0x0003C7DF
		// (set) Token: 0x06000BFA RID: 3066 RVA: 0x0003E5E7 File Offset: 0x0003C7E7
		[DefaultValue(1f)]
		[Display(Description = "How loud the sound should be.")]
		public float Volume { get; set; } = 1f;

		/// <summary>
		/// How much to vary the volume by.
		/// </summary>
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x06000BFB RID: 3067 RVA: 0x0003E5F0 File Offset: 0x0003C7F0
		// (set) Token: 0x06000BFC RID: 3068 RVA: 0x0003E5F8 File Offset: 0x0003C7F8
		[Display(Name = "Volume Random", Description = "How much to vary the volume by.")]
		public float VolumeRandom { get; set; }

		/// <summary>
		/// The base pitch of the sound.
		/// </summary>
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x06000BFD RID: 3069 RVA: 0x0003E601 File Offset: 0x0003C801
		// (set) Token: 0x06000BFE RID: 3070 RVA: 0x0003E609 File Offset: 0x0003C809
		[DefaultValue(1f)]
		[Display(Description = "The base pitch of the sound.")]
		public float Pitch { get; set; } = 1f;

		/// <summary>
		/// How much to vary the pitch by
		/// </summary>
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x06000BFF RID: 3071 RVA: 0x0003E612 File Offset: 0x0003C812
		// (set) Token: 0x06000C00 RID: 3072 RVA: 0x0003E61A File Offset: 0x0003C81A
		[Display(Name = "Pitch Random", Description = "How much to vary the pitch by.")]
		public float PitchRandom { get; set; }

		/// <summary>
		/// The furthest away to hear this sound.
		/// </summary>
		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x06000C01 RID: 3073 RVA: 0x0003E623 File Offset: 0x0003C823
		// (set) Token: 0x06000C02 RID: 3074 RVA: 0x0003E62B File Offset: 0x0003C82B
		[DefaultValue(2000f)]
		[Display(Name = "Max Distance", Description = "The furthest away to hear this sound.")]
		public float DistanceMax { get; set; } = 2000f;

		/// <summary>
		/// A random sound from the list will be selected to be played.
		/// </summary>
		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000C03 RID: 3075 RVA: 0x0003E634 File Offset: 0x0003C834
		// (set) Token: 0x06000C04 RID: 3076 RVA: 0x0003E63C File Offset: 0x0003C83C
		[ResourceType("vsnd")]
		[Display(Description = "A random sound from the list will be selected to be played.")]
		public List<string> Sounds { get; set; }

		/// <summary>
		/// Selection strategy to use when picking from multiple sounds.
		/// </summary>
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x06000C05 RID: 3077 RVA: 0x0003E645 File Offset: 0x0003C845
		// (set) Token: 0x06000C06 RID: 3078 RVA: 0x0003E64D File Offset: 0x0003C84D
		[Display(Name = "Selection Mode", Description = "Selection strategy to use when picking from multiple sounds.")]
		[DefaultValue(SoundEvent.SoundSelectionMode.Random)]
		public SoundEvent.SoundSelectionMode SelectionMode { get; set; } = SoundEvent.SoundSelectionMode.Random;

		// Token: 0x06000C07 RID: 3079 RVA: 0x0003E656 File Offset: 0x0003C856
		public SoundEvent()
		{
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x0003E688 File Offset: 0x0003C888
		public SoundEvent(string soundName, float volume = 0.5f)
		{
			this.Volume = volume;
			this.Sounds = new List<string> { soundName };
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x0003E6DC File Offset: 0x0003C8DC
		public void StaticRuntimeInit(string name)
		{
			base.Name = name;
			this.Create();
		}

		/// <summary>
		/// Called after the asset is loaded from disk
		/// </summary>
		// Token: 0x06000C0A RID: 3082 RVA: 0x0003E6EB File Offset: 0x0003C8EB
		protected override void PostLoad()
		{
			this.Create();
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x0003E6F3 File Offset: 0x0003C8F3
		protected override void PostReload()
		{
			this.Create();
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x0003E6FC File Offset: 0x0003C8FC
		public void Create()
		{
			if (string.IsNullOrEmpty(base.Name))
			{
				GlobalGameNamespace.Log.Warning("SoundEvent: No name specified");
				return;
			}
			string type = (this.UI ? "ui" : "general");
			float delay = 0f;
			List<string> sounds = this.Sounds;
			IEnumerable<string> vsnd_files;
			if (sounds == null)
			{
				vsnd_files = null;
			}
			else
			{
				vsnd_files = sounds.Select((string x) => System.IO.Path.ChangeExtension(x, ".vsnd"));
			}
			KeyValues3 kv = EngineGlue.JsonToKeyValues3(JsonSerializer.Serialize(new
			{
				type = type,
				delay = delay,
				vsnd_files = vsnd_files,
				volume_min = this.Volume - this.VolumeRandom,
				volume_max = this.Volume + this.VolumeRandom,
				pitch_min = this.Pitch - this.PitchRandom,
				pitch_max = this.Pitch + this.PitchRandom,
				limiter_on = 1f,
				limiter_max = 3f,
				limiter_match_entity = 1f,
				limiter_match_sevent = 1f,
				distance_min = 10f,
				distance_max = this.DistanceMax,
				vsnd_files_random = SoundEvent.SelectionModeStrings[(int)this.SelectionMode]
			}, new JsonSerializerOptions
			{
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
			}));
			try
			{
				SoundEventManager.AddSoundEvent(base.Name, kv);
			}
			finally
			{
				kv.DeleteThis();
			}
		}

		// Token: 0x0400017F RID: 383
		private static string[] SelectionModeStrings = new string[] { "index", "forward", "backward", "random", "random_exclusive", "random_weighted" };

		// Token: 0x020001E9 RID: 489
		public enum SoundSelectionMode
		{
			// Token: 0x04001060 RID: 4192
			Forward = 1,
			// Token: 0x04001061 RID: 4193
			Backward,
			// Token: 0x04001062 RID: 4194
			Random,
			// Token: 0x04001063 RID: 4195
			RandomExclusive
		}
	}
}
