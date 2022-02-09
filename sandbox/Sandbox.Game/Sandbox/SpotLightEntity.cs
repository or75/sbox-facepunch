using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Hammer;
using NativeEngine;

namespace Sandbox
{
	/// <summary>
	/// A directional spot light entity.
	/// </summary>
	// Token: 0x020000A1 RID: 161
	[Library("light_spot", Description = "A directional spot light entity.")]
	[EditorModel("models/editor/spot", 0, 255, 192, 255, 64, 64)]
	[EntityTool("Spot Light", "Lighting", "Spot light source")]
	[Sphere("lightsourceradius", 255, 255, 255, false, IsLean = true)]
	[VisGroup(VisGroup.Lighting)]
	[Light]
	[LightCone]
	[CanBeClientsideOnly]
	[SkipProperty("enable_shadows")]
	[Display(Name = "Spot Light")]
	[Icon("flashlight_on")]
	public class SpotLightEntity : ModelEntity
	{
		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06001085 RID: 4229 RVA: 0x000487FD File Offset: 0x000469FD
		internal override string NativeEntityClass
		{
			get
			{
				return "light_spot";
			}
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x00048804 File Offset: 0x00046A04
		public SpotLightEntity()
		{
			if (base.IsServer || base.IsClientOnly)
			{
				this.SetDefaults();
			}
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x0004887C File Offset: 0x00046A7C
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
			this.InnerConeAngle = 45f;
			this.OuterConeAngle = 60f;
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x00048900 File Offset: 0x00046B00
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

		// Token: 0x06001089 RID: 4233 RVA: 0x00048960 File Offset: 0x00046B60
		internal override void InternalDestruct()
		{
			base.InternalDestruct();
			this.lightComponent = default(CLightComponent);
		}

		// Token: 0x170001FC RID: 508
		// (get) Token: 0x0600108A RID: 4234 RVA: 0x00048974 File Offset: 0x00046B74
		// (set) Token: 0x0600108B RID: 4235 RVA: 0x00048981 File Offset: 0x00046B81
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

		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600108C RID: 4236 RVA: 0x0004898F File Offset: 0x00046B8F
		// (set) Token: 0x0600108D RID: 4237 RVA: 0x000489A1 File Offset: 0x00046BA1
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

		// Token: 0x170001FE RID: 510
		// (get) Token: 0x0600108E RID: 4238 RVA: 0x000489B6 File Offset: 0x00046BB6
		// (set) Token: 0x0600108F RID: 4239 RVA: 0x000489C3 File Offset: 0x00046BC3
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

		// Token: 0x170001FF RID: 511
		// (get) Token: 0x06001090 RID: 4240 RVA: 0x000489D1 File Offset: 0x00046BD1
		// (set) Token: 0x06001091 RID: 4241 RVA: 0x000489DE File Offset: 0x00046BDE
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
		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06001092 RID: 4242 RVA: 0x000489EC File Offset: 0x00046BEC
		// (set) Token: 0x06001093 RID: 4243 RVA: 0x000489F9 File Offset: 0x00046BF9
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

		/// <summary>
		/// Angular falloff exponent. Does not work with light cookies. Does not work with dynamic lighting.
		/// </summary>
		// Token: 0x17000201 RID: 513
		// (get) Token: 0x06001094 RID: 4244 RVA: 0x00048A07 File Offset: 0x00046C07
		// (set) Token: 0x06001095 RID: 4245 RVA: 0x00048A14 File Offset: 0x00046C14
		[Property]
		[DefaultValue(1f)]
		[Display(Description = "Angular falloff exponent. Does not work with light cookies. Does not work with dynamic lighting.")]
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

		// Token: 0x17000202 RID: 514
		// (get) Token: 0x06001096 RID: 4246 RVA: 0x00048A22 File Offset: 0x00046C22
		// (set) Token: 0x06001097 RID: 4247 RVA: 0x00048A2F File Offset: 0x00046C2F
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

		// Token: 0x17000203 RID: 515
		// (get) Token: 0x06001098 RID: 4248 RVA: 0x00048A3D File Offset: 0x00046C3D
		// (set) Token: 0x06001099 RID: 4249 RVA: 0x00048A4A File Offset: 0x00046C4A
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

		// Token: 0x17000204 RID: 516
		// (get) Token: 0x0600109A RID: 4250 RVA: 0x00048A58 File Offset: 0x00046C58
		// (set) Token: 0x0600109B RID: 4251 RVA: 0x00048A65 File Offset: 0x00046C65
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
		/// Inner cone angle. No angular falloff within this cone.
		/// </summary>
		// Token: 0x17000205 RID: 517
		// (get) Token: 0x0600109C RID: 4252 RVA: 0x00048A73 File Offset: 0x00046C73
		// (set) Token: 0x0600109D RID: 4253 RVA: 0x00048A80 File Offset: 0x00046C80
		[Property]
		[DefaultValue(45)]
		[Display(Description = "Inner cone angle. No angular falloff within this cone.")]
		public float InnerConeAngle
		{
			get
			{
				return this.lightComponent.GetInnerConeAngle();
			}
			set
			{
				this.lightComponent.SetInnerConeAngle(value);
			}
		}

		/// <summary>
		/// Outer cone angle.
		/// </summary>
		// Token: 0x17000206 RID: 518
		// (get) Token: 0x0600109E RID: 4254 RVA: 0x00048A8E File Offset: 0x00046C8E
		// (set) Token: 0x0600109F RID: 4255 RVA: 0x00048A9B File Offset: 0x00046C9B
		[Property]
		[DefaultValue(60)]
		[Display(Description = "Outer cone angle.")]
		public float OuterConeAngle
		{
			get
			{
				return this.lightComponent.GetOuterConeAngle();
			}
			set
			{
				this.lightComponent.SetOuterConeAngle(value);
			}
		}

		// Token: 0x17000207 RID: 519
		// (get) Token: 0x060010A0 RID: 4256 RVA: 0x00048AA9 File Offset: 0x00046CA9
		// (set) Token: 0x060010A1 RID: 4257 RVA: 0x00048AB6 File Offset: 0x00046CB6
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
		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060010A2 RID: 4258 RVA: 0x00048AC4 File Offset: 0x00046CC4
		// (set) Token: 0x060010A3 RID: 4259 RVA: 0x00048AD1 File Offset: 0x00046CD1
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
		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060010A4 RID: 4260 RVA: 0x00048ADF File Offset: 0x00046CDF
		// (set) Token: 0x060010A5 RID: 4261 RVA: 0x00048AEC File Offset: 0x00046CEC
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

		/// <summary>
		/// Distance at which the shadow starts to fade. (less than 0 = use 'Shadow End Fade Dist')
		/// </summary>
		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060010A6 RID: 4262 RVA: 0x00048AFA File Offset: 0x00046CFA
		// (set) Token: 0x060010A7 RID: 4263 RVA: 0x00048B07 File Offset: 0x00046D07
		[Property("shadowfademindist", null)]
		[Category("Shadows")]
		[DefaultValue(-250)]
		[Display(Name = "Shadow Start Fade Dist", Description = "Distance at which the shadow starts to fade. (less than 0 = use 'Shadow End Fade Dist')")]
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

		/// <summary>
		/// Maximum distance at which the shadow is visible. (0 = don't fade out)
		/// </summary>
		// Token: 0x1700020B RID: 523
		// (get) Token: 0x060010A8 RID: 4264 RVA: 0x00048B15 File Offset: 0x00046D15
		// (set) Token: 0x060010A9 RID: 4265 RVA: 0x00048B22 File Offset: 0x00046D22
		[Property("shadowfademaxdist", null)]
		[Category("Shadows")]
		[DefaultValue(1000)]
		[Display(Name = "Shadow End Fade Dist", Description = "Maximum distance at which the shadow is visible. (0 = don't fade out)")]
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

		// Token: 0x1700020C RID: 524
		// (get) Token: 0x060010AA RID: 4266 RVA: 0x00048B30 File Offset: 0x00046D30
		// (set) Token: 0x060010AB RID: 4267 RVA: 0x00048B42 File Offset: 0x00046D42
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

		// Token: 0x060010AC RID: 4268 RVA: 0x00048B4C File Offset: 0x00046D4C
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

		// Token: 0x1700020D RID: 525
		// (get) Token: 0x060010AD RID: 4269 RVA: 0x00048B97 File Offset: 0x00046D97
		// (set) Token: 0x060010AE RID: 4270 RVA: 0x00048B9F File Offset: 0x00046D9F
		[Property("fog_lighting", null)]
		[DefaultValue(SpotLightEntity.VolumetricFogType.None)]
		[Display(Description = "Volumetric Fogging - How should light interact with volumetric fogging.")]
		internal SpotLightEntity.VolumetricFogType FogLighting { get; set; }

		/// <summary>
		/// Overrides how much the light affects the fog. (if enabled)
		/// </summary>
		// Token: 0x1700020E RID: 526
		// (get) Token: 0x060010AF RID: 4271 RVA: 0x00048BA8 File Offset: 0x00046DA8
		// (set) Token: 0x060010B0 RID: 4272 RVA: 0x00048BB5 File Offset: 0x00046DB5
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

		// Token: 0x060010B1 RID: 4273 RVA: 0x00048BC3 File Offset: 0x00046DC3
		public void UseNoFog()
		{
			this.lightComponent.SetFogLightingMode(0);
		}

		// Token: 0x060010B2 RID: 4274 RVA: 0x00048BD1 File Offset: 0x00046DD1
		public void UseFog()
		{
			this.lightComponent.SetFogLightingMode(2);
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x00048BDF File Offset: 0x00046DDF
		public void UseFogNoShadows()
		{
			this.lightComponent.SetFogLightingMode(4);
		}

		// Token: 0x1700020F RID: 527
		// (get) Token: 0x060010B4 RID: 4276 RVA: 0x00048BED File Offset: 0x00046DED
		// (set) Token: 0x060010B5 RID: 4277 RVA: 0x00048BF5 File Offset: 0x00046DF5
		[Property]
		[Category("Shadows")]
		[DefaultValue(SpotLightEntity.ShadowType.Yes)]
		[Display(Description = "Whether this light casts shadows.")]
		internal SpotLightEntity.ShadowType CastShadows { get; set; } = SpotLightEntity.ShadowType.Yes;

		// Token: 0x17000210 RID: 528
		// (get) Token: 0x060010B6 RID: 4278 RVA: 0x00048BFE File Offset: 0x00046DFE
		// (set) Token: 0x060010B7 RID: 4279 RVA: 0x00048C06 File Offset: 0x00046E06
		[Property("nearclipplane", null)]
		[Category("Shadows")]
		[DefaultValue(1f)]
		[Display(Description = "Distance for near clip plane for shadow map.")]
		internal float ShadowNearClipPlane { get; set; } = 1f;

		// Token: 0x17000211 RID: 529
		// (get) Token: 0x060010B8 RID: 4280 RVA: 0x00048C0F File Offset: 0x00046E0F
		// (set) Token: 0x060010B9 RID: 4281 RVA: 0x00048C17 File Offset: 0x00046E17
		[Property]
		[Category("Shadows")]
		[DefaultValue(0)]
		[Display(Description = "0 = use default texture resolution")]
		internal int ShadowTextureWidth { get; set; }

		// Token: 0x17000212 RID: 530
		// (get) Token: 0x060010BA RID: 4282 RVA: 0x00048C20 File Offset: 0x00046E20
		// (set) Token: 0x060010BB RID: 4283 RVA: 0x00048C28 File Offset: 0x00046E28
		[Property]
		[Category("Shadows")]
		[DefaultValue(0)]
		[Display(Description = "0 = use default texture resolution")]
		internal int ShadowTextureHeight { get; set; }

		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060010BC RID: 4284 RVA: 0x00048C31 File Offset: 0x00046E31
		// (set) Token: 0x060010BD RID: 4285 RVA: 0x00048C39 File Offset: 0x00046E39
		[Property]
		[DefaultValue(true)]
		[Category("Rendering")]
		[Display(Description = "If true, this light renders into baked cube maps.")]
		internal bool RenderToCubemaps { get; set; } = true;

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060010BE RID: 4286 RVA: 0x00048C42 File Offset: 0x00046E42
		// (set) Token: 0x060010BF RID: 4287 RVA: 0x00048C4A File Offset: 0x00046E4A
		[Property]
		[DefaultValue(0)]
		[Category("Rendering")]
		[Display(Description = "When the number of visible lights exceeds the rendering budget, higher priority lights are chosen for rendering first.")]
		internal int Priority { get; set; }

		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060010C0 RID: 4288 RVA: 0x00048C53 File Offset: 0x00046E53
		// (set) Token: 0x060010C1 RID: 4289 RVA: 0x00048C5B File Offset: 0x00046E5B
		[Property]
		[Category("Rendering")]
		[Display(Description = "Semicolon-delimited list of light groups to affect.")]
		internal string LightGroup { get; set; }

		// Token: 0x17000216 RID: 534
		// (get) Token: 0x060010C2 RID: 4290 RVA: 0x00048C64 File Offset: 0x00046E64
		// (set) Token: 0x060010C3 RID: 4291 RVA: 0x00048C6C File Offset: 0x00046E6C
		[Property]
		[DefaultValue(2f)]
		[Category("Rendering")]
		[Display(Description = "The radius of the light source in game units.")]
		internal float LightSourceRadius { get; set; } = 2f;

		// Token: 0x17000217 RID: 535
		// (get) Token: 0x060010C4 RID: 4292 RVA: 0x00048C75 File Offset: 0x00046E75
		// (set) Token: 0x060010C5 RID: 4293 RVA: 0x00048C7D File Offset: 0x00046E7D
		[Property("baked_light_indexing", null)]
		[Category("Rendering")]
		[DefaultValue(true)]
		[Display(Description = "Allows direct light to be indexed if baked. Indexed lights have per-pixel quality specular lighting and normal map response.")]
		internal bool BakedLightIndexing { get; set; } = true;

		// Token: 0x17000218 RID: 536
		// (get) Token: 0x060010C6 RID: 4294 RVA: 0x00048C86 File Offset: 0x00046E86
		// (set) Token: 0x060010C7 RID: 4295 RVA: 0x00048C8E File Offset: 0x00046E8E
		[Property]
		[Category("Style")]
		[Display(Description = "Set a custom pattern of light brightness for this light. Pattern format is a string of characters, where 'a' is total darkness, 'z' fully bright. i.e. 'aaggnnttzz' would be a steppy fade in from dark to light.")]
		internal string Pattern { get; set; }

		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060010C8 RID: 4296 RVA: 0x00048C97 File Offset: 0x00046E97
		// (set) Token: 0x060010C9 RID: 4297 RVA: 0x00048C9F File Offset: 0x00046E9F
		[Property]
		[Category("Style")]
		[DefaultValue(SpotLightEntity.LightStyle.Normal)]
		internal SpotLightEntity.LightStyle Style { get; set; }

		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060010CA RID: 4298 RVA: 0x00048CA8 File Offset: 0x00046EA8
		// (set) Token: 0x060010CB RID: 4299 RVA: 0x00048CB0 File Offset: 0x00046EB0
		[Property]
		[Category("Rendering")]
		[DefaultValue(true)]
		[Display(Description = "Whether the light should affect diffuse surfaces.")]
		internal bool RenderDiffuse { get; set; } = true;

		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060010CC RID: 4300 RVA: 0x00048CB9 File Offset: 0x00046EB9
		// (set) Token: 0x060010CD RID: 4301 RVA: 0x00048CC1 File Offset: 0x00046EC1
		[Property]
		[Category("Rendering")]
		[DefaultValue(SpotLightEntity.RenderSpecularMode.On)]
		[Display(Description = "Whether the light should be visible in specular reflections.")]
		internal SpotLightEntity.RenderSpecularMode RenderSpecular { get; set; } = SpotLightEntity.RenderSpecularMode.On;

		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060010CE RID: 4302 RVA: 0x00048CCA File Offset: 0x00046ECA
		// (set) Token: 0x060010CF RID: 4303 RVA: 0x00048CD2 File Offset: 0x00046ED2
		[Property]
		[Category("Rendering")]
		[DefaultValue(true)]
		internal bool RenderTransmissive { get; set; } = true;

		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060010D0 RID: 4304 RVA: 0x00048CDB File Offset: 0x00046EDB
		// (set) Token: 0x060010D1 RID: 4305 RVA: 0x00048CE3 File Offset: 0x00046EE3
		[Property]
		[Display(Description = "How direct lighting should be represented")]
		[DefaultValue(SpotLightEntity.DirectLightMode.Baked)]
		internal SpotLightEntity.DirectLightMode DirectLight { get; set; } = SpotLightEntity.DirectLightMode.Baked;

		// Token: 0x1700021E RID: 542
		// (get) Token: 0x060010D2 RID: 4306 RVA: 0x00048CEC File Offset: 0x00046EEC
		// (set) Token: 0x060010D3 RID: 4307 RVA: 0x00048CF4 File Offset: 0x00046EF4
		[Property]
		[Display(Description = "How indirect lighting should be represented")]
		[DefaultValue(SpotLightEntity.IndirectLightMode.Baked)]
		internal SpotLightEntity.IndirectLightMode IndirectLight { get; set; } = SpotLightEntity.IndirectLightMode.Baked;

		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060010D4 RID: 4308 RVA: 0x00048CFD File Offset: 0x00046EFD
		// (set) Token: 0x060010D5 RID: 4309 RVA: 0x00048D05 File Offset: 0x00046F05
		[Property("bouncescale", null)]
		[DefaultValue(1)]
		internal float IndirectLightMultiplier { get; set; }

		// Token: 0x060010D6 RID: 4310 RVA: 0x00048D0E File Offset: 0x00046F0E
		[Input]
		public void SetLightEnabled(bool state)
		{
			this.Enabled = state;
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x00048D17 File Offset: 0x00046F17
		[Input]
		public void TurnOn()
		{
			this.Enabled = true;
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x00048D20 File Offset: 0x00046F20
		[Input]
		public void TurnOff()
		{
			this.Enabled = false;
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x00048D29 File Offset: 0x00046F29
		[Input]
		public void Toggle()
		{
			this.Enabled = !this.Enabled;
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x00048D3A File Offset: 0x00046F3A
		[Input]
		public void SetLightColor(Color color)
		{
			this.Color = color;
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x00048D43 File Offset: 0x00046F43
		[Input]
		public void SetLightBrightness(float brightness)
		{
			this.Brightness = brightness;
		}

		// Token: 0x040002D2 RID: 722
		private CLightComponent lightComponent;

		// Token: 0x0200022C RID: 556
		internal enum VolumetricFogType
		{
			// Token: 0x04001150 RID: 4432
			None,
			// Token: 0x04001151 RID: 4433
			Baked,
			// Token: 0x04001152 RID: 4434
			Dynamic,
			// Token: 0x04001153 RID: 4435
			BakedNoShadows,
			// Token: 0x04001154 RID: 4436
			DynamicNoShadows
		}

		// Token: 0x0200022D RID: 557
		internal enum ShadowType
		{
			// Token: 0x04001156 RID: 4438
			No,
			// Token: 0x04001157 RID: 4439
			Yes,
			// Token: 0x04001158 RID: 4440
			BakedOnly
		}

		// Token: 0x0200022E RID: 558
		internal enum LightStyle
		{
			// Token: 0x0400115A RID: 4442
			Normal,
			// Token: 0x0400115B RID: 4443
			FlickerA,
			// Token: 0x0400115C RID: 4444
			SlowStrongPulse,
			// Token: 0x0400115D RID: 4445
			CandleA,
			// Token: 0x0400115E RID: 4446
			FastStrobe,
			// Token: 0x0400115F RID: 4447
			GentlePulse,
			// Token: 0x04001160 RID: 4448
			FlickerB,
			// Token: 0x04001161 RID: 4449
			CandleB,
			// Token: 0x04001162 RID: 4450
			CandleC,
			// Token: 0x04001163 RID: 4451
			SlowStrobe,
			// Token: 0x04001164 RID: 4452
			FluorescentFlicker,
			// Token: 0x04001165 RID: 4453
			SlowPulseNoBlack
		}

		// Token: 0x0200022F RID: 559
		internal enum RenderSpecularMode
		{
			// Token: 0x04001167 RID: 4455
			Off,
			// Token: 0x04001168 RID: 4456
			On,
			// Token: 0x04001169 RID: 4457
			BakeIntoCubemaps
		}

		// Token: 0x02000230 RID: 560
		internal enum DirectLightMode
		{
			// Token: 0x0400116B RID: 4459
			None,
			// Token: 0x0400116C RID: 4460
			Baked,
			// Token: 0x0400116D RID: 4461
			PerPixel
		}

		// Token: 0x02000231 RID: 561
		internal enum IndirectLightMode
		{
			// Token: 0x0400116F RID: 4463
			None,
			// Token: 0x04001170 RID: 4464
			Baked
		}
	}
}
