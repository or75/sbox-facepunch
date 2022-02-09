using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Hammer;
using NativeEngine;

namespace Sandbox
{
	/// <summary>
	/// An environment light entity. This acts the sun.
	/// </summary>
	// Token: 0x0200008B RID: 139
	[Library("light_environment", Description = "Sets the color and angle of the light from the sun and sky.<br/><br/>\r\nTypical setup:<br/>\r\n1. Create an <b>env_sky</b> entity to use as your skybox<br/>\r\n2. Create a <b>light_environment</b> entity and set <b>Sky IBL Source</b> to the name of the <b>env_sky</b> entity<br/>\r\n3. Right-click on your <b>light_environment</b> entity and select 'Selected environment light -> Estimate lighting from HDR skybox'<br/>\r\n4. Adjust angle and brightness of the sunlight as you see fit")]
	[EntityTool("Environment Light", "Lighting", "Entity which defines the primary lighting for the map.")]
	[EditorModel("models/editor/sun", 255, 255, 0, 255, 64, 64)]
	[VisGroup(VisGroup.Lighting)]
	[Light]
	[Global("sun")]
	[BakeAmbientLight("ambient_color")]
	[BakeAmbientOcclusion]
	[BakeSkyLight]
	[SkipProperty("enable_shadows")]
	public class EnvironmentLightEntity : ModelEntity
	{
		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06000E42 RID: 3650 RVA: 0x00044FF4 File Offset: 0x000431F4
		internal override string NativeEntityClass
		{
			get
			{
				return "light_environment";
			}
		}

		// Token: 0x06000E43 RID: 3651 RVA: 0x00044FFC File Offset: 0x000431FC
		public EnvironmentLightEntity()
		{
			if (base.IsServer || base.IsClientOnly)
			{
				this.SetDefaults();
			}
		}

		// Token: 0x06000E44 RID: 3652 RVA: 0x000450BF File Offset: 0x000432BF
		private void SetDefaults()
		{
			this.Enabled = true;
			this.Brightness = 10f;
			this.Color = Color.White;
			this.SkyColor = Color.White;
			this.SkyIntensity = 1f;
		}

		// Token: 0x06000E45 RID: 3653 RVA: 0x000450F4 File Offset: 0x000432F4
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

		// Token: 0x06000E46 RID: 3654 RVA: 0x00045154 File Offset: 0x00043354
		internal override void InternalDestruct()
		{
			base.InternalDestruct();
			this.lightComponent = default(CLightComponent);
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000E47 RID: 3655 RVA: 0x00045168 File Offset: 0x00043368
		// (set) Token: 0x06000E48 RID: 3656 RVA: 0x00045175 File Offset: 0x00043375
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

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000E49 RID: 3657 RVA: 0x00045183 File Offset: 0x00043383
		// (set) Token: 0x06000E4A RID: 3658 RVA: 0x00045195 File Offset: 0x00043395
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

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000E4B RID: 3659 RVA: 0x000451AA File Offset: 0x000433AA
		// (set) Token: 0x06000E4C RID: 3660 RVA: 0x000451B7 File Offset: 0x000433B7
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

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000E4D RID: 3661 RVA: 0x000451C5 File Offset: 0x000433C5
		// (set) Token: 0x06000E4E RID: 3662 RVA: 0x000451D7 File Offset: 0x000433D7
		[Property]
		[DefaultValue("255 255 255")]
		[Category("Sky")]
		public Color SkyColor
		{
			get
			{
				return new Color(this.lightComponent.GetSkyColor());
			}
			set
			{
				this.lightComponent.SetSkyColor(value.ToColor32(false));
			}
		}

		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000E4F RID: 3663 RVA: 0x000451EC File Offset: 0x000433EC
		// (set) Token: 0x06000E50 RID: 3664 RVA: 0x000451F9 File Offset: 0x000433F9
		[Property]
		[DefaultValue(1)]
		[Category("Sky")]
		public float SkyIntensity
		{
			get
			{
				return this.lightComponent.GetSkyIntensity();
			}
			set
			{
				this.lightComponent.SetSkyIntensity(value);
			}
		}

		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000E51 RID: 3665 RVA: 0x00045207 File Offset: 0x00043407
		// (set) Token: 0x06000E52 RID: 3666 RVA: 0x0004520F File Offset: 0x0004340F
		[Property("fog_lighting", null)]
		[DefaultValue(EnvironmentLightEntity.VolumetricFogType.Baked)]
		[Display(Description = "Volumetric Fogging - How should light interact with volumetric fogging.")]
		internal EnvironmentLightEntity.VolumetricFogType FogLighting { get; set; } = EnvironmentLightEntity.VolumetricFogType.Baked;

		/// <summary>
		/// Overrides how much the light affects the fog. (if enabled)
		/// </summary>
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x06000E53 RID: 3667 RVA: 0x00045218 File Offset: 0x00043418
		// (set) Token: 0x06000E54 RID: 3668 RVA: 0x00045225 File Offset: 0x00043425
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

		// Token: 0x17000131 RID: 305
		// (get) Token: 0x06000E55 RID: 3669 RVA: 0x00045233 File Offset: 0x00043433
		// (set) Token: 0x06000E56 RID: 3670 RVA: 0x0004523B File Offset: 0x0004343B
		[Property("angulardiameter", null)]
		[DefaultValue(1f)]
		[Display(Description = "The angular extent of the sun for casting soft shadows. Higher numbers are more diffuse. 1 is a good starting value.")]
		internal float SunAngle { get; set; } = 1f;

		// Token: 0x17000132 RID: 306
		// (get) Token: 0x06000E57 RID: 3671 RVA: 0x00045244 File Offset: 0x00043444
		// (set) Token: 0x06000E58 RID: 3672 RVA: 0x0004524C File Offset: 0x0004344C
		[Property]
		[Category("Shadows")]
		[DefaultValue(EnvironmentLightEntity.ShadowType.Yes)]
		[Display(Description = "Whether this light casts shadows.")]
		internal EnvironmentLightEntity.ShadowType CastShadows { get; set; } = EnvironmentLightEntity.ShadowType.Yes;

		// Token: 0x17000133 RID: 307
		// (get) Token: 0x06000E59 RID: 3673 RVA: 0x00045255 File Offset: 0x00043455
		// (set) Token: 0x06000E5A RID: 3674 RVA: 0x0004525D File Offset: 0x0004345D
		[Property("nearclipplane", null)]
		[Category("Shadows")]
		[DefaultValue(1f)]
		[Display(Description = "Distance for near clip plane for shadow map.")]
		internal float ShadowNearClipPlane { get; set; } = 1f;

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000E5B RID: 3675 RVA: 0x00045266 File Offset: 0x00043466
		// (set) Token: 0x06000E5C RID: 3676 RVA: 0x0004526E File Offset: 0x0004346E
		[Property("numcascades", null)]
		[Category("Shadows")]
		[DefaultValue(3)]
		[MinMax(1f, 3f)]
		[Display(Description = "Number of shadow cascades to use.")]
		internal int CascadeAmount { get; set; } = 3;

		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000E5D RID: 3677 RVA: 0x00045277 File Offset: 0x00043477
		// (set) Token: 0x06000E5E RID: 3678 RVA: 0x0004527F File Offset: 0x0004347F
		[Property]
		[Category("Shadows")]
		[DefaultValue(0f)]
		internal float ShadowCascadeDistance0 { get; set; }

		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000E5F RID: 3679 RVA: 0x00045288 File Offset: 0x00043488
		// (set) Token: 0x06000E60 RID: 3680 RVA: 0x00045290 File Offset: 0x00043490
		[Property]
		[Category("Shadows")]
		[DefaultValue(0f)]
		internal float ShadowCascadeDistance1 { get; set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000E61 RID: 3681 RVA: 0x00045299 File Offset: 0x00043499
		// (set) Token: 0x06000E62 RID: 3682 RVA: 0x000452A1 File Offset: 0x000434A1
		[Property]
		[Category("Shadows")]
		[DefaultValue(0f)]
		internal float ShadowCascadeDistance2 { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000E63 RID: 3683 RVA: 0x000452AA File Offset: 0x000434AA
		// (set) Token: 0x06000E64 RID: 3684 RVA: 0x000452B2 File Offset: 0x000434B2
		[Property]
		[Category("Shadows")]
		[DefaultValue(0f)]
		internal float ShadowCascadeResolution0 { get; set; }

		// Token: 0x17000139 RID: 313
		// (get) Token: 0x06000E65 RID: 3685 RVA: 0x000452BB File Offset: 0x000434BB
		// (set) Token: 0x06000E66 RID: 3686 RVA: 0x000452C3 File Offset: 0x000434C3
		[Property]
		[Category("Shadows")]
		[DefaultValue(0f)]
		internal float ShadowCascadeResolution1 { get; set; }

		// Token: 0x1700013A RID: 314
		// (get) Token: 0x06000E67 RID: 3687 RVA: 0x000452CC File Offset: 0x000434CC
		// (set) Token: 0x06000E68 RID: 3688 RVA: 0x000452D4 File Offset: 0x000434D4
		[Property]
		[Category("Shadows")]
		[DefaultValue(0f)]
		internal float ShadowCascadeResolution2 { get; set; }

		// Token: 0x1700013B RID: 315
		// (get) Token: 0x06000E69 RID: 3689 RVA: 0x000452DD File Offset: 0x000434DD
		// (set) Token: 0x06000E6A RID: 3690 RVA: 0x000452E5 File Offset: 0x000434E5
		[Property]
		[DefaultValue(true)]
		[Category("Rendering")]
		[Display(Description = "If true, this light renders into baked cube maps.")]
		internal bool RenderToCubemaps { get; set; } = true;

		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000E6B RID: 3691 RVA: 0x000452EE File Offset: 0x000434EE
		// (set) Token: 0x06000E6C RID: 3692 RVA: 0x000452F6 File Offset: 0x000434F6
		[Property]
		[DefaultValue(0)]
		[Category("Rendering")]
		[Display(Description = "When the number of visible lights exceeds the rendering budget, higher priority lights are chosen for rendering first.")]
		internal int Priority { get; set; }

		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000E6D RID: 3693 RVA: 0x000452FF File Offset: 0x000434FF
		// (set) Token: 0x06000E6E RID: 3694 RVA: 0x00045307 File Offset: 0x00043507
		[Property]
		[Category("Rendering")]
		[Display(Description = "Semicolon-delimited list of light groups to affect.")]
		internal string LightGroup { get; set; }

		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000E6F RID: 3695 RVA: 0x00045310 File Offset: 0x00043510
		// (set) Token: 0x06000E70 RID: 3696 RVA: 0x00045318 File Offset: 0x00043518
		[Property("baked_light_indexing", null)]
		[Category("Rendering")]
		[DefaultValue(true)]
		[Display(Description = "Allows direct light to be indexed if baked. Indexed lights have per-pixel quality specular lighting and normal map response")]
		internal bool BakedLightIndexing { get; set; } = true;

		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000E71 RID: 3697 RVA: 0x00045321 File Offset: 0x00043521
		// (set) Token: 0x06000E72 RID: 3698 RVA: 0x00045329 File Offset: 0x00043529
		[Property("lower_hemisphere_is_black", null)]
		[Category("Sky")]
		[DefaultValue(true)]
		internal bool LowerHemisphereIsBlack { get; set; } = true;

		// Token: 0x17000140 RID: 320
		// (get) Token: 0x06000E73 RID: 3699 RVA: 0x00045332 File Offset: 0x00043532
		// (set) Token: 0x06000E74 RID: 3700 RVA: 0x0004533A File Offset: 0x0004353A
		[Property("skytexture", null)]
		[FGDType("target_destination", "", "")]
		[Category("Sky")]
		[Display(Name = "Sky IBL Source", Description = "env_sky entity, lat-long/h-cross/v-cross skybox image, or sky material to use for sky IBL.")]
		internal string SkyTexture { get; set; }

		// Token: 0x17000141 RID: 321
		// (get) Token: 0x06000E75 RID: 3701 RVA: 0x00045343 File Offset: 0x00043543
		// (set) Token: 0x06000E76 RID: 3702 RVA: 0x0004534B File Offset: 0x0004354B
		[Property]
		[Category("Sky")]
		[DefaultValue(1f)]
		[Display(Name = "Sky IBL Scale", Description = "Scale value for IBL intensity fine-tuning.")]
		internal float SkyTextureScale { get; set; } = 1f;

		// Token: 0x17000142 RID: 322
		// (get) Token: 0x06000E77 RID: 3703 RVA: 0x00045354 File Offset: 0x00043554
		// (set) Token: 0x06000E78 RID: 3704 RVA: 0x0004535C File Offset: 0x0004355C
		[Property("skyambientbounce", null)]
		[Category("Ambient Lighting")]
		[DefaultValue("147 147 147")]
		internal Color SkyAmbientBounceColor { get; set; }

		// Token: 0x17000143 RID: 323
		// (get) Token: 0x06000E79 RID: 3705 RVA: 0x00045365 File Offset: 0x00043565
		// (set) Token: 0x06000E7A RID: 3706 RVA: 0x0004536D File Offset: 0x0004356D
		[Property]
		[Category("Sky")]
		[DefaultValue(32f)]
		[Display(Name = "Sun Light Minimum Brightness Threshold", Description = "Brightness beyond which pixels in the Sky IBL Source are considered to be coming from the sun.")]
		internal float SunLightMinBrightness { get; set; } = 32f;

		// Token: 0x17000144 RID: 324
		// (get) Token: 0x06000E7B RID: 3707 RVA: 0x00045376 File Offset: 0x00043576
		// (set) Token: 0x06000E7C RID: 3708 RVA: 0x0004537E File Offset: 0x0004357E
		[Property("ambient_occlusion", null)]
		[Category("Ambient Occlusion")]
		[DefaultValue(false)]
		internal bool AmbientOcclusion { get; set; }

		// Token: 0x17000145 RID: 325
		// (get) Token: 0x06000E7D RID: 3709 RVA: 0x00045387 File Offset: 0x00043587
		// (set) Token: 0x06000E7E RID: 3710 RVA: 0x0004538F File Offset: 0x0004358F
		[Property("max_occlusion_distance", null)]
		[Category("Ambient Occlusion")]
		[DefaultValue(16f)]
		internal float MaxOcclusionDistance { get; set; } = 16f;

		// Token: 0x17000146 RID: 326
		// (get) Token: 0x06000E7F RID: 3711 RVA: 0x00045398 File Offset: 0x00043598
		// (set) Token: 0x06000E80 RID: 3712 RVA: 0x000453A0 File Offset: 0x000435A0
		[Property("fully_occluded_fraction", null)]
		[Category("Ambient Occlusion")]
		[DefaultValue(1f)]
		internal float FullyOccludedFraction { get; set; } = 1f;

		// Token: 0x17000147 RID: 327
		// (get) Token: 0x06000E81 RID: 3713 RVA: 0x000453A9 File Offset: 0x000435A9
		// (set) Token: 0x06000E82 RID: 3714 RVA: 0x000453B1 File Offset: 0x000435B1
		[Property("occlusion_exponent", null)]
		[Category("Ambient Occlusion")]
		[DefaultValue(1f)]
		internal float OcclusionExponent { get; set; } = 1f;

		// Token: 0x17000148 RID: 328
		// (get) Token: 0x06000E83 RID: 3715 RVA: 0x000453BA File Offset: 0x000435BA
		// (set) Token: 0x06000E84 RID: 3716 RVA: 0x000453C2 File Offset: 0x000435C2
		[Property("ambient_color", null)]
		[Category("Ambient Lighting")]
		[DefaultValue("0 0 0")]
		internal Color AmbientColor { get; set; }

		// Token: 0x17000149 RID: 329
		// (get) Token: 0x06000E85 RID: 3717 RVA: 0x000453CB File Offset: 0x000435CB
		// (set) Token: 0x06000E86 RID: 3718 RVA: 0x000453D3 File Offset: 0x000435D3
		[Property]
		[Category("Style")]
		[Display(Description = "Set a custom pattern of light brightness for this light. Pattern format is a string of characters, where 'a' is total darkness, 'z' fully bright. i.e. 'aaggnnttzz' would be a steppy fade in from dark to light.")]
		internal string Pattern { get; set; }

		// Token: 0x1700014A RID: 330
		// (get) Token: 0x06000E87 RID: 3719 RVA: 0x000453DC File Offset: 0x000435DC
		// (set) Token: 0x06000E88 RID: 3720 RVA: 0x000453E4 File Offset: 0x000435E4
		[Property]
		[Category("Style")]
		[DefaultValue(EnvironmentLightEntity.LightStyle.Normal)]
		internal EnvironmentLightEntity.LightStyle Style { get; set; }

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x06000E89 RID: 3721 RVA: 0x000453ED File Offset: 0x000435ED
		// (set) Token: 0x06000E8A RID: 3722 RVA: 0x000453F5 File Offset: 0x000435F5
		[Property]
		[Category("Rendering")]
		[DefaultValue(true)]
		[Display(Description = "Whether the light should affect diffuse surfaces.")]
		internal bool RenderDiffuse { get; set; } = true;

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x06000E8B RID: 3723 RVA: 0x000453FE File Offset: 0x000435FE
		// (set) Token: 0x06000E8C RID: 3724 RVA: 0x00045406 File Offset: 0x00043606
		[Property]
		[Category("Rendering")]
		[DefaultValue(EnvironmentLightEntity.RenderSpecularMode.On)]
		[Display(Description = "Whether the light should be visible in specular reflections.")]
		internal EnvironmentLightEntity.RenderSpecularMode RenderSpecular { get; set; } = EnvironmentLightEntity.RenderSpecularMode.On;

		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000E8D RID: 3725 RVA: 0x0004540F File Offset: 0x0004360F
		// (set) Token: 0x06000E8E RID: 3726 RVA: 0x00045417 File Offset: 0x00043617
		[Property]
		[Category("Rendering")]
		[DefaultValue(true)]
		internal bool RenderTransmissive { get; set; } = true;

		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000E8F RID: 3727 RVA: 0x00045420 File Offset: 0x00043620
		// (set) Token: 0x06000E90 RID: 3728 RVA: 0x00045428 File Offset: 0x00043628
		[Property]
		[Display(Description = "How direct lighting should be represented")]
		[DefaultValue(EnvironmentLightEntity.DirectLightMode.Baked)]
		internal EnvironmentLightEntity.DirectLightMode DirectLight { get; set; } = EnvironmentLightEntity.DirectLightMode.Baked;

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000E91 RID: 3729 RVA: 0x00045431 File Offset: 0x00043631
		// (set) Token: 0x06000E92 RID: 3730 RVA: 0x00045439 File Offset: 0x00043639
		[Property]
		[Display(Description = "How indirect lighting should be represented")]
		[DefaultValue(EnvironmentLightEntity.IndirectLightMode.Baked)]
		internal EnvironmentLightEntity.IndirectLightMode IndirectLight { get; set; } = EnvironmentLightEntity.IndirectLightMode.Baked;

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000E93 RID: 3731 RVA: 0x00045442 File Offset: 0x00043642
		// (set) Token: 0x06000E94 RID: 3732 RVA: 0x0004544A File Offset: 0x0004364A
		[Property("bouncescale", null)]
		[DefaultValue(1)]
		internal float IndirectLightMultiplier { get; set; }

		// Token: 0x04000232 RID: 562
		private CLightComponent lightComponent;

		// Token: 0x0200020C RID: 524
		internal enum VolumetricFogType
		{
			// Token: 0x040010B6 RID: 4278
			None,
			// Token: 0x040010B7 RID: 4279
			Baked,
			// Token: 0x040010B8 RID: 4280
			Dynamic,
			// Token: 0x040010B9 RID: 4281
			BakedNoShadows,
			// Token: 0x040010BA RID: 4282
			DynamicNoShadows
		}

		// Token: 0x0200020D RID: 525
		internal enum ShadowType
		{
			// Token: 0x040010BC RID: 4284
			No,
			// Token: 0x040010BD RID: 4285
			Yes,
			// Token: 0x040010BE RID: 4286
			BakedOnly
		}

		// Token: 0x0200020E RID: 526
		internal enum LightStyle
		{
			// Token: 0x040010C0 RID: 4288
			Normal,
			// Token: 0x040010C1 RID: 4289
			FlickerA,
			// Token: 0x040010C2 RID: 4290
			SlowStrongPulse,
			// Token: 0x040010C3 RID: 4291
			CandleA,
			// Token: 0x040010C4 RID: 4292
			FastStrobe,
			// Token: 0x040010C5 RID: 4293
			GentlePulse,
			// Token: 0x040010C6 RID: 4294
			FlickerB,
			// Token: 0x040010C7 RID: 4295
			CandleB,
			// Token: 0x040010C8 RID: 4296
			CandleC,
			// Token: 0x040010C9 RID: 4297
			SlowStrobe,
			// Token: 0x040010CA RID: 4298
			FluorescentFlicker,
			// Token: 0x040010CB RID: 4299
			SlowPulseNoBlack
		}

		// Token: 0x0200020F RID: 527
		internal enum RenderSpecularMode
		{
			// Token: 0x040010CD RID: 4301
			Off,
			// Token: 0x040010CE RID: 4302
			On,
			// Token: 0x040010CF RID: 4303
			BakeIntoCubemaps
		}

		// Token: 0x02000210 RID: 528
		internal enum DirectLightMode
		{
			// Token: 0x040010D1 RID: 4305
			None,
			// Token: 0x040010D2 RID: 4306
			Baked,
			// Token: 0x040010D3 RID: 4307
			PerPixel
		}

		// Token: 0x02000211 RID: 529
		internal enum IndirectLightMode
		{
			// Token: 0x040010D5 RID: 4309
			None,
			// Token: 0x040010D6 RID: 4310
			Baked
		}
	}
}
