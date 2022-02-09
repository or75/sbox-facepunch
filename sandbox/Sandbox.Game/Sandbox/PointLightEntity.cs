using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Hammer;
using NativeEngine;

namespace Sandbox
{
	/// <summary>
	/// An omnidirectional light entity.
	/// </summary>
	// Token: 0x0200009F RID: 159
	[Library("light_omni", Description = "An omnidirectional light entity.")]
	[EditorModel("models/editor/omni", 0, 255, 192, 255, 64, 64)]
	[EntityTool("Point Light", "Lighting", "Omni directional point light source")]
	[Sphere("lightsourceradius", 255, 255, 255, false, IsLean = true)]
	[Sphere("range", 255, 255, 0, false)]
	[VisGroup(VisGroup.Lighting)]
	[Light]
	[SkipProperty("enable_shadows")]
	[Display(Name = "Point Light")]
	[Icon("wb_incandescent")]
	public class PointLightEntity : ModelEntity
	{
		// Token: 0x170001DA RID: 474
		// (get) Token: 0x0600102E RID: 4142 RVA: 0x00048239 File Offset: 0x00046439
		internal override string NativeEntityClass
		{
			get
			{
				return "light_omni";
			}
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x00048240 File Offset: 0x00046440
		public PointLightEntity()
		{
			if (base.IsServer || base.IsClientOnly)
			{
				this.SetDefaults();
			}
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x000482B8 File Offset: 0x000464B8
		private void SetDefaults()
		{
			this.Enabled = true;
			this.DynamicShadows = false;
			this.Range = 512f;
			this.Falloff = 1f;
			this.LinearAttenuation = 0f;
			this.QuadraticAttenuation = 1f;
			this.Brightness = 10f;
			this.Color = Color.White;
			this.FogStength = 1f;
			this.UseFog();
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x00048328 File Offset: 0x00046528
		internal override void OnNativeEntity(CEntityInstance ent)
		{
			base.OnNativeEntity(ent);
			if (this.clientEnt.IsValid)
			{
				this.lightComponent = this.clientEnt.GetLightComponent();
			}
			if (this.serverEnt.IsValid)
			{
				this.lightComponent = this.serverEnt.GetLightComponent();
			}
			Assert.True(this.lightComponent.IsValid);
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x00048388 File Offset: 0x00046588
		internal override void InternalDestruct()
		{
			base.InternalDestruct();
			this.lightComponent = default(CLightComponent);
		}

		// Token: 0x170001DB RID: 475
		// (get) Token: 0x06001033 RID: 4147 RVA: 0x0004839C File Offset: 0x0004659C
		// (set) Token: 0x06001034 RID: 4148 RVA: 0x000483A9 File Offset: 0x000465A9
		[Property]
		[DefaultValue(true)]
		public bool Enabled
		{
			get
			{
				return this.lightComponent.IsEnabled();
			}
			set
			{
				this.lightComponent.SetEnabled(value);
			}
		}

		// Token: 0x170001DC RID: 476
		// (get) Token: 0x06001035 RID: 4149 RVA: 0x000483B7 File Offset: 0x000465B7
		// (set) Token: 0x06001036 RID: 4150 RVA: 0x000483C9 File Offset: 0x000465C9
		[Property]
		[DefaultValue("255 255 255")]
		public Color Color
		{
			get
			{
				return new Color(this.lightComponent.GetColor());
			}
			set
			{
				this.lightComponent.SetColor(value.ToColor32(false));
			}
		}

		// Token: 0x170001DD RID: 477
		// (get) Token: 0x06001037 RID: 4151 RVA: 0x000483DE File Offset: 0x000465DE
		// (set) Token: 0x06001038 RID: 4152 RVA: 0x000483EB File Offset: 0x000465EB
		[Property]
		[DefaultValue(1)]
		public float Brightness
		{
			get
			{
				return this.lightComponent.GetBrightness();
			}
			set
			{
				this.lightComponent.SetBrightness(value);
			}
		}

		// Token: 0x170001DE RID: 478
		// (get) Token: 0x06001039 RID: 4153 RVA: 0x000483F9 File Offset: 0x000465F9
		// (set) Token: 0x0600103A RID: 4154 RVA: 0x00048406 File Offset: 0x00046606
		public float BrightnessMultiplier
		{
			get
			{
				return this.lightComponent.GetBrightnessMultiplier();
			}
			set
			{
				this.lightComponent.SetBrightnessMultiplier(value);
			}
		}

		/// <summary>
		/// Distance range for light. 0=infinite
		/// </summary>
		// Token: 0x170001DF RID: 479
		// (get) Token: 0x0600103B RID: 4155 RVA: 0x00048414 File Offset: 0x00046614
		// (set) Token: 0x0600103C RID: 4156 RVA: 0x00048421 File Offset: 0x00046621
		[Property]
		[DefaultValue(512)]
		[Display(Description = "Distance range for light. 0=infinite")]
		public float Range
		{
			get
			{
				return this.lightComponent.GetRange();
			}
			set
			{
				this.lightComponent.SetRange(value);
			}
		}

		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x0600103D RID: 4157 RVA: 0x0004842F File Offset: 0x0004662F
		// (set) Token: 0x0600103E RID: 4158 RVA: 0x0004843C File Offset: 0x0004663C
		public float Falloff
		{
			get
			{
				return this.lightComponent.GetFalloff();
			}
			set
			{
				this.lightComponent.SetFalloff(value);
			}
		}

		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x0600103F RID: 4159 RVA: 0x0004844A File Offset: 0x0004664A
		// (set) Token: 0x06001040 RID: 4160 RVA: 0x00048457 File Offset: 0x00046657
		[Property("attenuation1", null)]
		[DefaultValue(0)]
		[Category("Rendering")]
		public float LinearAttenuation
		{
			get
			{
				return this.lightComponent.GetAttenuation1();
			}
			set
			{
				this.lightComponent.SetAttenuation1(value);
			}
		}

		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06001041 RID: 4161 RVA: 0x00048465 File Offset: 0x00046665
		// (set) Token: 0x06001042 RID: 4162 RVA: 0x00048472 File Offset: 0x00046672
		[Property("attenuation2", null)]
		[DefaultValue(1)]
		[Category("Rendering")]
		public float QuadraticAttenuation
		{
			get
			{
				return this.lightComponent.GetAttenuation2();
			}
			set
			{
				this.lightComponent.SetAttenuation2(value);
			}
		}

		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06001043 RID: 4163 RVA: 0x00048480 File Offset: 0x00046680
		// (set) Token: 0x06001044 RID: 4164 RVA: 0x0004848D File Offset: 0x0004668D
		public bool Flicker
		{
			get
			{
				return this.lightComponent.GetFlicker();
			}
			set
			{
				this.lightComponent.SetFlicker(value);
			}
		}

		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06001045 RID: 4165 RVA: 0x0004849B File Offset: 0x0004669B
		// (set) Token: 0x06001046 RID: 4166 RVA: 0x000484A8 File Offset: 0x000466A8
		public bool DynamicShadows
		{
			get
			{
				return this.lightComponent.DynamicShadows();
			}
			set
			{
				this.lightComponent.SetDynamicShadows(value);
			}
		}

		/// <summary>
		/// Distance at which the light starts to fade. (less than 0 = use fademaxdist)
		/// </summary>
		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06001047 RID: 4167 RVA: 0x000484B6 File Offset: 0x000466B6
		// (set) Token: 0x06001048 RID: 4168 RVA: 0x000484C3 File Offset: 0x000466C3
		[Property("fademindist", null)]
		[Category("Fade Distance")]
		[DefaultValue(-250)]
		[Display(Description = "Distance at which the light starts to fade. (less than 0 = use fademaxdist)")]
		public float FadeDistanceMin
		{
			get
			{
				return this.lightComponent.GetFadeMinDistance();
			}
			set
			{
				this.lightComponent.SetFadeMinDistance(value);
			}
		}

		/// <summary>
		/// Maximum distance at which the light is visible. (0 = don't fade out)
		/// </summary>
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x06001049 RID: 4169 RVA: 0x000484D1 File Offset: 0x000466D1
		// (set) Token: 0x0600104A RID: 4170 RVA: 0x000484DE File Offset: 0x000466DE
		[Property("fademaxdist", null)]
		[Category("Fade Distance")]
		[DefaultValue(1250)]
		[Display(Description = "Maximum distance at which the light is visible. (0 = don't fade out)")]
		public float FadeDistanceMax
		{
			get
			{
				return this.lightComponent.GetFadeMaxDistance();
			}
			set
			{
				this.lightComponent.SetFadeMaxDistance(value);
			}
		}

		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x0600104B RID: 4171 RVA: 0x000484EC File Offset: 0x000466EC
		// (set) Token: 0x0600104C RID: 4172 RVA: 0x000484F9 File Offset: 0x000466F9
		public float ShadowFadeDistanceMin
		{
			get
			{
				return this.lightComponent.GetShadowFadeMinDistance();
			}
			set
			{
				this.lightComponent.SetShadowFadeMinDistance(value);
			}
		}

		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x0600104D RID: 4173 RVA: 0x00048507 File Offset: 0x00046707
		// (set) Token: 0x0600104E RID: 4174 RVA: 0x00048514 File Offset: 0x00046714
		public float ShadowFadeDistanceMax
		{
			get
			{
				return this.lightComponent.GetShadowFadeMaxDistance();
			}
			set
			{
				this.lightComponent.SetShadowFadeMaxDistance(value);
			}
		}

		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x0600104F RID: 4175 RVA: 0x00048522 File Offset: 0x00046722
		// (set) Token: 0x06001050 RID: 4176 RVA: 0x00048534 File Offset: 0x00046734
		[Obsolete("Does not function")]
		public Texture LightCookie
		{
			get
			{
				return new Texture(this.lightComponent.GetLightCookie());
			}
			set
			{
				this.SetLightCookieInternal(value);
			}
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x00048540 File Offset: 0x00046740
		internal async Task SetLightCookieInternal(Texture tex)
		{
			if (tex != null)
			{
				try
				{
					while (tex != null && !tex.IsLoaded)
					{
						await this.Task.DelaySeconds(0.1f);
					}
				}
				finally
				{
					if (this.lightComponent.IsValid)
					{
						this.lightComponent.SetLightCookie(tex.native);
					}
				}
			}
		}

		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06001052 RID: 4178 RVA: 0x0004858B File Offset: 0x0004678B
		// (set) Token: 0x06001053 RID: 4179 RVA: 0x00048593 File Offset: 0x00046793
		[Property("fog_lighting", null)]
		[DefaultValue(PointLightEntity.VolumetricFogType.None)]
		[Display(Description = "Volumetric Fogging - How should light interact with volumetric fogging.")]
		internal PointLightEntity.VolumetricFogType FogLighting { get; set; }

		/// <summary>
		/// Overrides how much the light affects the fog. (if enabled)
		/// </summary>
		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06001054 RID: 4180 RVA: 0x0004859C File Offset: 0x0004679C
		// (set) Token: 0x06001055 RID: 4181 RVA: 0x000485A9 File Offset: 0x000467A9
		[Property("fogcontributionstrength", null)]
		[DefaultValue(1f)]
		[Display(Description = "Overrides how much the light affects the fog. (if enabled)")]
		public float FogStength
		{
			get
			{
				return this.lightComponent.GetFogContributionStength();
			}
			set
			{
				this.lightComponent.SetFogContributionStength(value);
			}
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x000485B7 File Offset: 0x000467B7
		public void UseNoFog()
		{
			this.lightComponent.SetFogLightingMode(0);
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x000485C5 File Offset: 0x000467C5
		public void UseFog()
		{
			this.lightComponent.SetFogLightingMode(2);
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x000485D3 File Offset: 0x000467D3
		public void UseFogNoShadows()
		{
			this.lightComponent.SetFogLightingMode(4);
		}

		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06001059 RID: 4185 RVA: 0x000485E1 File Offset: 0x000467E1
		// (set) Token: 0x0600105A RID: 4186 RVA: 0x000485E9 File Offset: 0x000467E9
		[Property]
		[Category("Shadows")]
		[DefaultValue(PointLightEntity.ShadowType.Yes)]
		[Display(Description = "Whether this light casts shadows.")]
		internal PointLightEntity.ShadowType CastShadows { get; set; } = PointLightEntity.ShadowType.Yes;

		// Token: 0x170001ED RID: 493
		// (get) Token: 0x0600105B RID: 4187 RVA: 0x000485F2 File Offset: 0x000467F2
		// (set) Token: 0x0600105C RID: 4188 RVA: 0x000485FA File Offset: 0x000467FA
		[Property("nearclipplane", null)]
		[Category("Shadows")]
		[DefaultValue(1f)]
		[Display(Description = "Distance for near clip plane for shadow map.")]
		internal float ShadowNearClipPlane { get; set; } = 1f;

		// Token: 0x170001EE RID: 494
		// (get) Token: 0x0600105D RID: 4189 RVA: 0x00048603 File Offset: 0x00046803
		// (set) Token: 0x0600105E RID: 4190 RVA: 0x0004860B File Offset: 0x0004680B
		[Property]
		[DefaultValue(true)]
		[Category("Rendering")]
		[Display(Description = "If true, this light renders into baked cube maps.")]
		internal bool RenderToCubemaps { get; set; } = true;

		// Token: 0x170001EF RID: 495
		// (get) Token: 0x0600105F RID: 4191 RVA: 0x00048614 File Offset: 0x00046814
		// (set) Token: 0x06001060 RID: 4192 RVA: 0x0004861C File Offset: 0x0004681C
		[Property]
		[DefaultValue(0)]
		[Category("Rendering")]
		[Display(Description = "When the number of visible lights exceeds the rendering budget, higher priority lights are chosen for rendering first.")]
		internal int Priority { get; set; }

		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x06001061 RID: 4193 RVA: 0x00048625 File Offset: 0x00046825
		// (set) Token: 0x06001062 RID: 4194 RVA: 0x0004862D File Offset: 0x0004682D
		[Property]
		[Category("Rendering")]
		[Display(Description = "Semicolon-delimited list of light groups to affect.")]
		internal string LightGroup { get; set; }

		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06001063 RID: 4195 RVA: 0x00048636 File Offset: 0x00046836
		// (set) Token: 0x06001064 RID: 4196 RVA: 0x0004863E File Offset: 0x0004683E
		[Property]
		[DefaultValue(2f)]
		[Category("Rendering")]
		[Display(Description = "The radius of the light source in game units.")]
		internal float LightSourceRadius { get; set; } = 2f;

		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06001065 RID: 4197 RVA: 0x00048647 File Offset: 0x00046847
		// (set) Token: 0x06001066 RID: 4198 RVA: 0x0004864F File Offset: 0x0004684F
		[Property("baked_light_indexing", null)]
		[Category("Rendering")]
		[DefaultValue(true)]
		[Display(Description = "Allows direct light to be indexed if baked. Indexed lights have per-pixel quality specular lighting and normal map response")]
		internal bool BakedLightIndexing { get; set; } = true;

		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06001067 RID: 4199 RVA: 0x00048658 File Offset: 0x00046858
		// (set) Token: 0x06001068 RID: 4200 RVA: 0x00048660 File Offset: 0x00046860
		[Property]
		[Category("Style")]
		[Display(Description = "Set a custom pattern of light brightness for this light. Pattern format is a string of characters, where 'a' is total darkness, 'z' fully bright. i.e. 'aaggnnttzz' would be a steppy fade in from dark to light.")]
		internal string Pattern { get; set; }

		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x06001069 RID: 4201 RVA: 0x00048669 File Offset: 0x00046869
		// (set) Token: 0x0600106A RID: 4202 RVA: 0x00048671 File Offset: 0x00046871
		[Property]
		[Category("Style")]
		[DefaultValue(PointLightEntity.LightStyle.Normal)]
		internal PointLightEntity.LightStyle Style { get; set; }

		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x0600106B RID: 4203 RVA: 0x0004867A File Offset: 0x0004687A
		// (set) Token: 0x0600106C RID: 4204 RVA: 0x00048682 File Offset: 0x00046882
		[Property]
		[Category("Rendering")]
		[DefaultValue(true)]
		[Display(Description = "Whether the light should affect diffuse surfaces.")]
		internal bool RenderDiffuse { get; set; } = true;

		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x0600106D RID: 4205 RVA: 0x0004868B File Offset: 0x0004688B
		// (set) Token: 0x0600106E RID: 4206 RVA: 0x00048693 File Offset: 0x00046893
		[Property]
		[Category("Rendering")]
		[DefaultValue(PointLightEntity.RenderSpecularMode.On)]
		[Display(Description = "Whether the light should be visible in specular reflections.")]
		internal PointLightEntity.RenderSpecularMode RenderSpecular { get; set; } = PointLightEntity.RenderSpecularMode.On;

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x0600106F RID: 4207 RVA: 0x0004869C File Offset: 0x0004689C
		// (set) Token: 0x06001070 RID: 4208 RVA: 0x000486A4 File Offset: 0x000468A4
		[Property]
		[Category("Rendering")]
		[DefaultValue(true)]
		internal bool RenderTransmissive { get; set; } = true;

		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x06001071 RID: 4209 RVA: 0x000486AD File Offset: 0x000468AD
		// (set) Token: 0x06001072 RID: 4210 RVA: 0x000486B5 File Offset: 0x000468B5
		[Property]
		[Display(Description = "How direct lighting should be represented")]
		[DefaultValue(PointLightEntity.DirectLightMode.Baked)]
		internal PointLightEntity.DirectLightMode DirectLight { get; set; } = PointLightEntity.DirectLightMode.Baked;

		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x06001073 RID: 4211 RVA: 0x000486BE File Offset: 0x000468BE
		// (set) Token: 0x06001074 RID: 4212 RVA: 0x000486C6 File Offset: 0x000468C6
		[Property]
		[Display(Description = "How indirect lighting should be represented")]
		[DefaultValue(PointLightEntity.IndirectLightMode.Baked)]
		internal PointLightEntity.IndirectLightMode IndirectLight { get; set; } = PointLightEntity.IndirectLightMode.Baked;

		// Token: 0x170001FA RID: 506
		// (get) Token: 0x06001075 RID: 4213 RVA: 0x000486CF File Offset: 0x000468CF
		// (set) Token: 0x06001076 RID: 4214 RVA: 0x000486D7 File Offset: 0x000468D7
		[Property("bouncescale", null)]
		[DefaultValue(1)]
		internal float IndirectLightMultiplier { get; set; }

		// Token: 0x06001077 RID: 4215 RVA: 0x000486E0 File Offset: 0x000468E0
		[Input]
		public void SetLightEnabled(bool state)
		{
			this.Enabled = state;
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x000486E9 File Offset: 0x000468E9
		[Input]
		public void TurnOn()
		{
			this.Enabled = true;
		}

		// Token: 0x06001079 RID: 4217 RVA: 0x000486F2 File Offset: 0x000468F2
		[Input]
		public void TurnOff()
		{
			this.Enabled = false;
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x000486FB File Offset: 0x000468FB
		[Input]
		public void Toggle()
		{
			this.Enabled = !this.Enabled;
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x0004870C File Offset: 0x0004690C
		[Input]
		public void SetLightColor(Color color)
		{
			this.Color = color;
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x00048715 File Offset: 0x00046915
		[Input]
		public void SetLightBrightness(float brightness)
		{
			this.Brightness = brightness;
		}

		// Token: 0x040002BF RID: 703
		private CLightComponent lightComponent;

		// Token: 0x02000225 RID: 549
		internal enum VolumetricFogType
		{
			// Token: 0x04001129 RID: 4393
			None,
			// Token: 0x0400112A RID: 4394
			Baked,
			// Token: 0x0400112B RID: 4395
			Dynamic,
			// Token: 0x0400112C RID: 4396
			BakedNoShadows,
			// Token: 0x0400112D RID: 4397
			DynamicNoShadows
		}

		// Token: 0x02000226 RID: 550
		internal enum ShadowType
		{
			// Token: 0x0400112F RID: 4399
			No,
			// Token: 0x04001130 RID: 4400
			Yes,
			// Token: 0x04001131 RID: 4401
			BakedOnly
		}

		// Token: 0x02000227 RID: 551
		internal enum LightStyle
		{
			// Token: 0x04001133 RID: 4403
			Normal,
			// Token: 0x04001134 RID: 4404
			FlickerA,
			// Token: 0x04001135 RID: 4405
			SlowStrongPulse,
			// Token: 0x04001136 RID: 4406
			CandleA,
			// Token: 0x04001137 RID: 4407
			FastStrobe,
			// Token: 0x04001138 RID: 4408
			GentlePulse,
			// Token: 0x04001139 RID: 4409
			FlickerB,
			// Token: 0x0400113A RID: 4410
			CandleB,
			// Token: 0x0400113B RID: 4411
			CandleC,
			// Token: 0x0400113C RID: 4412
			SlowStrobe,
			// Token: 0x0400113D RID: 4413
			FluorescentFlicker,
			// Token: 0x0400113E RID: 4414
			SlowPulseNoBlack
		}

		// Token: 0x02000228 RID: 552
		internal enum RenderSpecularMode
		{
			// Token: 0x04001140 RID: 4416
			Off,
			// Token: 0x04001141 RID: 4417
			On,
			// Token: 0x04001142 RID: 4418
			BakeIntoCubemaps
		}

		// Token: 0x02000229 RID: 553
		internal enum DirectLightMode
		{
			// Token: 0x04001144 RID: 4420
			None,
			// Token: 0x04001145 RID: 4421
			Baked,
			// Token: 0x04001146 RID: 4422
			PerPixel
		}

		// Token: 0x0200022A RID: 554
		internal enum IndirectLightMode
		{
			// Token: 0x04001148 RID: 4424
			None,
			// Token: 0x04001149 RID: 4425
			Baked
		}
	}
}
