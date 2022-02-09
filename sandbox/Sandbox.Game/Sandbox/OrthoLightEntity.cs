using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Hammer;
using NativeEngine;

namespace Sandbox
{
	/// <summary>
	/// A directional, orthographic light entity.
	/// </summary>
	// Token: 0x02000095 RID: 149
	[Library("light_ortho", Description = "A directional, orthographic light entity.")]
	[EditorModel("models/editor/ortho", 0, 255, 192, 255, 64, 64)]
	[EntityTool("Orthographic Light", "Lighting", "Spot light source with orthographic projection.")]
	[OrthoBoundsHelper("range", "ortholightwidth", "ortholightheight")]
	[VisGroup(VisGroup.Lighting)]
	[Light]
	[CanBeClientsideOnly]
	[SkipProperty("enable_shadows")]
	[Display(Name = "Orthographic Light")]
	[Icon("highlight")]
	public class OrthoLightEntity : ModelEntity
	{
		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000F32 RID: 3890 RVA: 0x00046934 File Offset: 0x00044B34
		internal override string NativeEntityClass
		{
			get
			{
				return "light_ortho";
			}
		}

		// Token: 0x06000F33 RID: 3891 RVA: 0x0004693C File Offset: 0x00044B3C
		public OrthoLightEntity()
		{
			if (base.IsServer || base.IsClientOnly)
			{
				this.SetDefaults();
			}
		}

		// Token: 0x06000F34 RID: 3892 RVA: 0x000469BC File Offset: 0x00044BBC
		private void SetDefaults()
		{
			this.Enabled = true;
			this.DynamicShadows = false;
			this.Range = 512f;
			this.Falloff = 1f;
			this.Brightness = 10f;
			this.Color = Color.White;
			this.FogStength = 1f;
			this.UseFog();
			this.OrthoLightWidth = 100f;
			this.OrthoLightHeight = 100f;
		}

		// Token: 0x06000F35 RID: 3893 RVA: 0x00046A2C File Offset: 0x00044C2C
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

		// Token: 0x06000F36 RID: 3894 RVA: 0x00046A8C File Offset: 0x00044C8C
		internal override void InternalDestruct()
		{
			base.InternalDestruct();
			this.lightComponent = default(CLightComponent);
		}

		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000F37 RID: 3895 RVA: 0x00046AA0 File Offset: 0x00044CA0
		// (set) Token: 0x06000F38 RID: 3896 RVA: 0x00046AAD File Offset: 0x00044CAD
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

		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000F39 RID: 3897 RVA: 0x00046ABB File Offset: 0x00044CBB
		// (set) Token: 0x06000F3A RID: 3898 RVA: 0x00046ACD File Offset: 0x00044CCD
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

		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000F3B RID: 3899 RVA: 0x00046AE2 File Offset: 0x00044CE2
		// (set) Token: 0x06000F3C RID: 3900 RVA: 0x00046AEF File Offset: 0x00044CEF
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

		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000F3D RID: 3901 RVA: 0x00046AFD File Offset: 0x00044CFD
		// (set) Token: 0x06000F3E RID: 3902 RVA: 0x00046B0A File Offset: 0x00044D0A
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
		// Token: 0x17000181 RID: 385
		// (get) Token: 0x06000F3F RID: 3903 RVA: 0x00046B18 File Offset: 0x00044D18
		// (set) Token: 0x06000F40 RID: 3904 RVA: 0x00046B25 File Offset: 0x00044D25
		[Property]
		[DefaultValue(2048)]
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

		// Token: 0x17000182 RID: 386
		// (get) Token: 0x06000F41 RID: 3905 RVA: 0x00046B33 File Offset: 0x00044D33
		// (set) Token: 0x06000F42 RID: 3906 RVA: 0x00046B40 File Offset: 0x00044D40
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

		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000F43 RID: 3907 RVA: 0x00046B4E File Offset: 0x00044D4E
		// (set) Token: 0x06000F44 RID: 3908 RVA: 0x00046B5B File Offset: 0x00044D5B
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

		/// <summary>
		/// Distance at which the light starts to fade. (less than 0 = use fademaxdist)
		/// </summary>
		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000F45 RID: 3909 RVA: 0x00046B69 File Offset: 0x00044D69
		// (set) Token: 0x06000F46 RID: 3910 RVA: 0x00046B76 File Offset: 0x00044D76
		[Property("fademindist", null)]
		[Category("Fade Distance")]
		[DefaultValue(-250)]
		[Display(Description = "Distance at which the light starts to fade. (less than 0 = use 'Fade Distance Max')")]
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
		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000F47 RID: 3911 RVA: 0x00046B84 File Offset: 0x00044D84
		// (set) Token: 0x06000F48 RID: 3912 RVA: 0x00046B91 File Offset: 0x00044D91
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

		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000F49 RID: 3913 RVA: 0x00046B9F File Offset: 0x00044D9F
		// (set) Token: 0x06000F4A RID: 3914 RVA: 0x00046BAC File Offset: 0x00044DAC
		[Property]
		[DefaultValue(512)]
		[Display(Description = "Ortho light rectangle width.")]
		public float OrthoLightWidth
		{
			get
			{
				return this.lightComponent.GetOrthoLightWidth();
			}
			set
			{
				this.lightComponent.SetOrthoLightWidth(value);
			}
		}

		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000F4B RID: 3915 RVA: 0x00046BBA File Offset: 0x00044DBA
		// (set) Token: 0x06000F4C RID: 3916 RVA: 0x00046BC7 File Offset: 0x00044DC7
		[Property]
		[DefaultValue(512)]
		[Display(Description = "Ortho light rectangle height.")]
		public float OrthoLightHeight
		{
			get
			{
				return this.lightComponent.GetOrthoLightHeight();
			}
			set
			{
				this.lightComponent.SetOrthoLightHeight(value);
			}
		}

		// Token: 0x17000188 RID: 392
		// (get) Token: 0x06000F4D RID: 3917 RVA: 0x00046BD5 File Offset: 0x00044DD5
		// (set) Token: 0x06000F4E RID: 3918 RVA: 0x00046BE2 File Offset: 0x00044DE2
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

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x06000F4F RID: 3919 RVA: 0x00046BF0 File Offset: 0x00044DF0
		// (set) Token: 0x06000F50 RID: 3920 RVA: 0x00046C02 File Offset: 0x00044E02
		[Property]
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

		// Token: 0x06000F51 RID: 3921 RVA: 0x00046C0C File Offset: 0x00044E0C
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

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x06000F52 RID: 3922 RVA: 0x00046C57 File Offset: 0x00044E57
		// (set) Token: 0x06000F53 RID: 3923 RVA: 0x00046C5F File Offset: 0x00044E5F
		[Property("fog_lighting", null)]
		[DefaultValue(OrthoLightEntity.VolumetricFogType.Baked)]
		[Display(Description = "Volumetric Fogging - How should light interact with volumetric fogging.")]
		internal OrthoLightEntity.VolumetricFogType FogLighting { get; set; } = OrthoLightEntity.VolumetricFogType.Baked;

		/// <summary>
		/// Overrides how much the light affects the fog. (if enabled)
		/// </summary>
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000F54 RID: 3924 RVA: 0x00046C68 File Offset: 0x00044E68
		// (set) Token: 0x06000F55 RID: 3925 RVA: 0x00046C75 File Offset: 0x00044E75
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

		// Token: 0x06000F56 RID: 3926 RVA: 0x00046C83 File Offset: 0x00044E83
		public void UseNoFog()
		{
			this.lightComponent.SetFogLightingMode(0);
		}

		// Token: 0x06000F57 RID: 3927 RVA: 0x00046C91 File Offset: 0x00044E91
		public void UseFog()
		{
			this.lightComponent.SetFogLightingMode(2);
		}

		// Token: 0x06000F58 RID: 3928 RVA: 0x00046C9F File Offset: 0x00044E9F
		public void UseFogNoShadows()
		{
			this.lightComponent.SetFogLightingMode(4);
		}

		// Token: 0x1700018C RID: 396
		// (get) Token: 0x06000F59 RID: 3929 RVA: 0x00046CAD File Offset: 0x00044EAD
		// (set) Token: 0x06000F5A RID: 3930 RVA: 0x00046CB5 File Offset: 0x00044EB5
		[Property]
		[Category("Shadows")]
		[DefaultValue(OrthoLightEntity.ShadowType.Yes)]
		[Display(Description = "Whether this light casts shadows.")]
		internal OrthoLightEntity.ShadowType CastShadows { get; set; } = OrthoLightEntity.ShadowType.Yes;

		// Token: 0x1700018D RID: 397
		// (get) Token: 0x06000F5B RID: 3931 RVA: 0x00046CBE File Offset: 0x00044EBE
		// (set) Token: 0x06000F5C RID: 3932 RVA: 0x00046CC6 File Offset: 0x00044EC6
		[Property("nearclipplane", null)]
		[Category("Shadows")]
		[DefaultValue(1f)]
		[Display(Description = "Distance for near clip plane for shadow map.")]
		internal float ShadowNearClipPlane { get; set; } = 1f;

		// Token: 0x1700018E RID: 398
		// (get) Token: 0x06000F5D RID: 3933 RVA: 0x00046CCF File Offset: 0x00044ECF
		// (set) Token: 0x06000F5E RID: 3934 RVA: 0x00046CD7 File Offset: 0x00044ED7
		[Property]
		[Category("Shadows")]
		[DefaultValue(0)]
		[Display(Description = "0 = use default texture resolution")]
		internal int ShadowTextureWidth { get; set; }

		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000F5F RID: 3935 RVA: 0x00046CE0 File Offset: 0x00044EE0
		// (set) Token: 0x06000F60 RID: 3936 RVA: 0x00046CE8 File Offset: 0x00044EE8
		[Property]
		[Category("Shadows")]
		[DefaultValue(0)]
		[Display(Description = "0 = use default texture resolution")]
		internal int ShadowTextureHeight { get; set; }

		// Token: 0x17000190 RID: 400
		// (get) Token: 0x06000F61 RID: 3937 RVA: 0x00046CF1 File Offset: 0x00044EF1
		// (set) Token: 0x06000F62 RID: 3938 RVA: 0x00046CF9 File Offset: 0x00044EF9
		[Property("angulardiameter", null)]
		[DefaultValue(1f)]
		[Display(Description = "The angular extent of the sun for casting soft shadows. Higher numbers are more diffuse. 1 is a good starting value.")]
		internal float SunSpreadAngle { get; set; } = 1f;

		// Token: 0x17000191 RID: 401
		// (get) Token: 0x06000F63 RID: 3939 RVA: 0x00046D02 File Offset: 0x00044F02
		// (set) Token: 0x06000F64 RID: 3940 RVA: 0x00046D0A File Offset: 0x00044F0A
		[Property]
		[DefaultValue(true)]
		[Category("Rendering")]
		[Display(Description = "If true, this light renders into baked cube maps.")]
		internal bool RenderToCubemaps { get; set; } = true;

		// Token: 0x17000192 RID: 402
		// (get) Token: 0x06000F65 RID: 3941 RVA: 0x00046D13 File Offset: 0x00044F13
		// (set) Token: 0x06000F66 RID: 3942 RVA: 0x00046D1B File Offset: 0x00044F1B
		[Property]
		[DefaultValue(0)]
		[Category("Rendering")]
		[Display(Description = "When the number of visible lights exceeds the rendering budget, higher priority lights are chosen for rendering first.")]
		internal int Priority { get; set; }

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000F67 RID: 3943 RVA: 0x00046D24 File Offset: 0x00044F24
		// (set) Token: 0x06000F68 RID: 3944 RVA: 0x00046D2C File Offset: 0x00044F2C
		[Property]
		[Category("Rendering")]
		[Display(Description = "Semicolon-delimited list of light groups to affect.")]
		internal string LightGroup { get; set; }

		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000F69 RID: 3945 RVA: 0x00046D35 File Offset: 0x00044F35
		// (set) Token: 0x06000F6A RID: 3946 RVA: 0x00046D3D File Offset: 0x00044F3D
		[Property("baked_light_indexing", null)]
		[Category("Rendering")]
		[DefaultValue(true)]
		[Display(Description = "Allows direct light to be indexed if baked. Indexed lights have per-pixel quality specular lighting and normal map response.")]
		internal bool BakedLightIndexing { get; set; } = true;

		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000F6B RID: 3947 RVA: 0x00046D46 File Offset: 0x00044F46
		// (set) Token: 0x06000F6C RID: 3948 RVA: 0x00046D4E File Offset: 0x00044F4E
		[Property]
		[Category("Style")]
		[Display(Description = "Set a custom pattern of light brightness for this light. Pattern format is a string of characters, where 'a' is total darkness, 'z' fully bright. i.e. 'aaggnnttzz' would be a steppy fade in from dark to light.")]
		internal string Pattern { get; set; }

		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000F6D RID: 3949 RVA: 0x00046D57 File Offset: 0x00044F57
		// (set) Token: 0x06000F6E RID: 3950 RVA: 0x00046D5F File Offset: 0x00044F5F
		[Property]
		[Category("Style")]
		[DefaultValue(OrthoLightEntity.LightStyle.Normal)]
		internal OrthoLightEntity.LightStyle Style { get; set; }

		// Token: 0x17000197 RID: 407
		// (get) Token: 0x06000F6F RID: 3951 RVA: 0x00046D68 File Offset: 0x00044F68
		// (set) Token: 0x06000F70 RID: 3952 RVA: 0x00046D70 File Offset: 0x00044F70
		[Property]
		[Category("Rendering")]
		[DefaultValue(true)]
		[Display(Description = "Whether the light should affect diffuse surfaces.")]
		internal bool RenderDiffuse { get; set; } = true;

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x06000F71 RID: 3953 RVA: 0x00046D79 File Offset: 0x00044F79
		// (set) Token: 0x06000F72 RID: 3954 RVA: 0x00046D81 File Offset: 0x00044F81
		[Property]
		[Category("Rendering")]
		[DefaultValue(OrthoLightEntity.RenderSpecularMode.On)]
		[Display(Description = "Whether the light should be visible in specular reflections.")]
		internal OrthoLightEntity.RenderSpecularMode RenderSpecular { get; set; } = OrthoLightEntity.RenderSpecularMode.On;

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x06000F73 RID: 3955 RVA: 0x00046D8A File Offset: 0x00044F8A
		// (set) Token: 0x06000F74 RID: 3956 RVA: 0x00046D92 File Offset: 0x00044F92
		[Property]
		[Category("Rendering")]
		[DefaultValue(true)]
		internal bool RenderTransmissive { get; set; } = true;

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000F75 RID: 3957 RVA: 0x00046D9B File Offset: 0x00044F9B
		// (set) Token: 0x06000F76 RID: 3958 RVA: 0x00046DA3 File Offset: 0x00044FA3
		[Property]
		[Display(Description = "How direct lighting should be represented")]
		[DefaultValue(OrthoLightEntity.DirectLightMode.Baked)]
		internal OrthoLightEntity.DirectLightMode DirectLight { get; set; } = OrthoLightEntity.DirectLightMode.Baked;

		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000F77 RID: 3959 RVA: 0x00046DAC File Offset: 0x00044FAC
		// (set) Token: 0x06000F78 RID: 3960 RVA: 0x00046DB4 File Offset: 0x00044FB4
		[Property]
		[Display(Description = "How indirect lighting should be represented")]
		[DefaultValue(OrthoLightEntity.IndirectLightMode.Baked)]
		internal OrthoLightEntity.IndirectLightMode IndirectLight { get; set; } = OrthoLightEntity.IndirectLightMode.Baked;

		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000F79 RID: 3961 RVA: 0x00046DBD File Offset: 0x00044FBD
		// (set) Token: 0x06000F7A RID: 3962 RVA: 0x00046DC5 File Offset: 0x00044FC5
		[Property("bouncescale", null)]
		[DefaultValue(1)]
		internal float IndirectLightMultiplier { get; set; }

		// Token: 0x06000F7B RID: 3963 RVA: 0x00046DCE File Offset: 0x00044FCE
		[Input]
		public void SetLightEnabled(bool state)
		{
			this.Enabled = state;
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x00046DD7 File Offset: 0x00044FD7
		[Input]
		public void TurnOn()
		{
			this.Enabled = true;
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x00046DE0 File Offset: 0x00044FE0
		[Input]
		public void TurnOff()
		{
			this.Enabled = false;
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x00046DE9 File Offset: 0x00044FE9
		[Input]
		public void Toggle()
		{
			this.Enabled = !this.Enabled;
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x00046DFA File Offset: 0x00044FFA
		[Input]
		public void SetLightColor(Color color)
		{
			this.Color = color;
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x00046E03 File Offset: 0x00045003
		[Input]
		public void SetLightBrightness(float brightness)
		{
			this.Brightness = brightness;
		}

		// Token: 0x04000276 RID: 630
		private CLightComponent lightComponent;

		// Token: 0x02000215 RID: 533
		internal enum VolumetricFogType
		{
			// Token: 0x040010E8 RID: 4328
			None,
			// Token: 0x040010E9 RID: 4329
			Baked,
			// Token: 0x040010EA RID: 4330
			Dynamic,
			// Token: 0x040010EB RID: 4331
			BakedNoShadows,
			// Token: 0x040010EC RID: 4332
			DynamicNoShadows
		}

		// Token: 0x02000216 RID: 534
		internal enum ShadowType
		{
			// Token: 0x040010EE RID: 4334
			No,
			// Token: 0x040010EF RID: 4335
			Yes,
			// Token: 0x040010F0 RID: 4336
			BakedOnly
		}

		// Token: 0x02000217 RID: 535
		internal enum LightStyle
		{
			// Token: 0x040010F2 RID: 4338
			Normal,
			// Token: 0x040010F3 RID: 4339
			FlickerA,
			// Token: 0x040010F4 RID: 4340
			SlowStrongPulse,
			// Token: 0x040010F5 RID: 4341
			CandleA,
			// Token: 0x040010F6 RID: 4342
			FastStrobe,
			// Token: 0x040010F7 RID: 4343
			GentlePulse,
			// Token: 0x040010F8 RID: 4344
			FlickerB,
			// Token: 0x040010F9 RID: 4345
			CandleB,
			// Token: 0x040010FA RID: 4346
			CandleC,
			// Token: 0x040010FB RID: 4347
			SlowStrobe,
			// Token: 0x040010FC RID: 4348
			FluorescentFlicker,
			// Token: 0x040010FD RID: 4349
			SlowPulseNoBlack
		}

		// Token: 0x02000218 RID: 536
		internal enum RenderSpecularMode
		{
			// Token: 0x040010FF RID: 4351
			Off,
			// Token: 0x04001100 RID: 4352
			On,
			// Token: 0x04001101 RID: 4353
			BakeIntoCubemaps
		}

		// Token: 0x02000219 RID: 537
		internal enum DirectLightMode
		{
			// Token: 0x04001103 RID: 4355
			None,
			// Token: 0x04001104 RID: 4356
			Baked,
			// Token: 0x04001105 RID: 4357
			PerPixel
		}

		// Token: 0x0200021A RID: 538
		internal enum IndirectLightMode
		{
			// Token: 0x04001107 RID: 4359
			None,
			// Token: 0x04001108 RID: 4360
			Baked
		}
	}
}
