using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Hammer;
using NativeEngine;

namespace Sandbox
{
	/// <summary>
	/// A physics surface. This is applied to each <see cref="T:Sandbox.PhysicsShape">PhysicsShape</see> and controls its physical properties and physics related sounds.
	/// </summary>
	// Token: 0x02000069 RID: 105
	[AutoGenerate]
	[Library("surface", Description = "A physics surface. This is applied to each PhysicsShape and controls its physical properties and physics related sounds.")]
	public class Surface : Asset
	{
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000C0E RID: 3086 RVA: 0x0003E851 File Offset: 0x0003CA51
		// (set) Token: 0x06000C0F RID: 3087 RVA: 0x0003E859 File Offset: 0x0003CA59
		[Skip]
		public uint NameHash { get; internal set; }

		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000C10 RID: 3088 RVA: 0x0003E862 File Offset: 0x0003CA62
		// (set) Token: 0x06000C11 RID: 3089 RVA: 0x0003E86A File Offset: 0x0003CA6A
		[Skip]
		public int Index { get; internal set; }

		/// <summary>
		/// Filepath of the base surface. Use <see cref="M:Sandbox.Surface.SetBaseSurface(System.String)">SetBaseSurface</see> and <see cref="M:Sandbox.Surface.GetBaseSurface">GetBaseSurface</see>.
		/// </summary>
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000C12 RID: 3090 RVA: 0x0003E873 File Offset: 0x0003CA73
		// (set) Token: 0x06000C13 RID: 3091 RVA: 0x0003E87B File Offset: 0x0003CA7B
		[ResourceType("surface")]
		[Display(Description = "Fallback surface for empty fields on this surface.")]
		public string BaseSurface { get; set; }

		// Token: 0x06000C14 RID: 3092 RVA: 0x0003E884 File Offset: 0x0003CA84
		public Surface GetBaseSurface()
		{
			return Surface.All.Where((KeyValuePair<int, Surface> x) => x.Value.Path == this.BaseSurface && x.Value != this).FirstOrDefault<KeyValuePair<int, Surface>>().Value;
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x0003E8B4 File Offset: 0x0003CAB4
		public void SetBaseSurface(string name)
		{
			this.BaseSurface = Surface.All.Where((KeyValuePair<int, Surface> x) => x.Value.Name == name).FirstOrDefault<KeyValuePair<int, Surface>>().Value.Path;
		}

		/// <summary>
		/// A concise description explaining what this surface property should be used for.
		/// </summary>
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000C16 RID: 3094 RVA: 0x0003E8FC File Offset: 0x0003CAFC
		// (set) Token: 0x06000C17 RID: 3095 RVA: 0x0003E904 File Offset: 0x0003CB04
		[Display(Description = "A concise description explaining what this surface property should be used for.")]
		public string Description { get; set; }

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x06000C18 RID: 3096 RVA: 0x0003E90D File Offset: 0x0003CB0D
		// (set) Token: 0x06000C19 RID: 3097 RVA: 0x0003E915 File Offset: 0x0003CB15
		[MinMax(0f, 1f)]
		[Category("Physics")]
		[DefaultValue(0.8f)]
		public float Friction { get; set; } = 0.8f;

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x06000C1A RID: 3098 RVA: 0x0003E91E File Offset: 0x0003CB1E
		// (set) Token: 0x06000C1B RID: 3099 RVA: 0x0003E926 File Offset: 0x0003CB26
		[MinMax(0f, 1f)]
		[Category("Physics")]
		[DefaultValue(0.25f)]
		public float Elasticity { get; set; } = 0.25f;

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x06000C1C RID: 3100 RVA: 0x0003E92F File Offset: 0x0003CB2F
		// (set) Token: 0x06000C1D RID: 3101 RVA: 0x0003E937 File Offset: 0x0003CB37
		[MinMax(0f, 4000f)]
		[Category("Physics")]
		[DefaultValue(2000f)]
		public float Density { get; set; } = 2000f;

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x06000C1E RID: 3102 RVA: 0x0003E940 File Offset: 0x0003CB40
		// (set) Token: 0x06000C1F RID: 3103 RVA: 0x0003E948 File Offset: 0x0003CB48
		[MinMax(0f, 100f)]
		[Category("Physics")]
		[DefaultValue(-1f)]
		public float Thickness { get; set; } = -1f;

		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000C20 RID: 3104 RVA: 0x0003E951 File Offset: 0x0003CB51
		// (set) Token: 0x06000C21 RID: 3105 RVA: 0x0003E959 File Offset: 0x0003CB59
		[MinMax(0f, 100f)]
		[Category("Physics")]
		[DefaultValue(0f)]
		public float Dampening { get; set; }

		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000C22 RID: 3106 RVA: 0x0003E962 File Offset: 0x0003CB62
		// (set) Token: 0x06000C23 RID: 3107 RVA: 0x0003E96A File Offset: 0x0003CB6A
		[MinMax(0f, 100f)]
		[Category("Physics")]
		[DefaultValue(40f)]
		public float BounceThreshold { get; set; } = 40f;

		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000C24 RID: 3108 RVA: 0x0003E973 File Offset: 0x0003CB73
		// (set) Token: 0x06000C25 RID: 3109 RVA: 0x0003E97B File Offset: 0x0003CB7B
		public Surface.ImpactEffectData ImpactEffects { get; set; }

		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000C26 RID: 3110 RVA: 0x0003E984 File Offset: 0x0003CB84
		// (set) Token: 0x06000C27 RID: 3111 RVA: 0x0003E98C File Offset: 0x0003CB8C
		public Surface.SoundData Sounds { get; set; }

		// Token: 0x06000C28 RID: 3112 RVA: 0x0003E995 File Offset: 0x0003CB95
		public override string ToString()
		{
			return "Surface[" + base.Name + "]";
		}

		// Token: 0x06000C29 RID: 3113 RVA: 0x0003E9AC File Offset: 0x0003CBAC
		protected override void PostLoad()
		{
			this.Create();
		}

		// Token: 0x06000C2A RID: 3114 RVA: 0x0003E9B4 File Offset: 0x0003CBB4
		protected override void PostReload()
		{
			this.Create();
			this.Update();
		}

		// Token: 0x06000C2B RID: 3115 RVA: 0x0003E9C4 File Offset: 0x0003CBC4
		private void Update()
		{
			if (this.props.IsNull)
			{
				return;
			}
			if (PhysicsWorld.world.IsNull)
			{
				return;
			}
			foreach (PhysicsBody body in PhysicsWorld.Bodies)
			{
				if (body.IsValid())
				{
					body.native.UpdateSurfaceProperties(this.props);
				}
			}
		}

		// Token: 0x06000C2C RID: 3116 RVA: 0x0003EA48 File Offset: 0x0003CC48
		private void Create()
		{
			this.props = VPhysics2.GetSurfacePropertyController().AddProperty(base.Name, "default", this.Description ?? "");
			this.NameHash = this.props.m_nameHash;
			this.Index = this.props.m_nIndex;
			this.props.UpdatePhysics(this.Friction, this.Elasticity, this.Density, this.Thickness, this.Dampening, this.BounceThreshold);
			Surface.All[this.Index] = this;
		}

		/// <summary>
		/// Find a surface by its index in the array. This is the fastest way to lookup, so it's
		/// passed from things like Traces since the index is going to be the same. It's important to
		/// know that this index shouldn't be saved or networked because it could differ between loads or clients.
		/// Instead send the name hash and look up using that.
		/// </summary>
		// Token: 0x06000C2D RID: 3117 RVA: 0x0003EAE4 File Offset: 0x0003CCE4
		internal static Surface FindByIndex(int index)
		{
			Surface val;
			if (Surface.All.TryGetValue(index, out val))
			{
				return val;
			}
			if (Surface.All.Count == 0)
			{
				throw new Exception("Default Surface not found!");
			}
			return Surface.All[0];
		}

		/// <summary>
		/// Returns a Surface from its name, or null
		/// </summary>
		/// <param name="name">The name of a surface property to look up</param>
		/// <returns>The surface with given name, or null if such surface property doesn't exist</returns>
		// Token: 0x06000C2E RID: 3118 RVA: 0x0003EB24 File Offset: 0x0003CD24
		public static Surface FindByName(string name)
		{
			return Surface.All.FirstOrDefault((KeyValuePair<int, Surface> x) => x.Value.Name == name).Value;
		}

		// Token: 0x06000C2F RID: 3119 RVA: 0x0003EB5C File Offset: 0x0003CD5C
		internal void OnPhysicsImpact(Vector3 pos, float volume, float speed)
		{
			if (volume < 0.01f)
			{
				return;
			}
			string sound = this.Sounds.ImpactHard ?? this.Sounds.ImpactSoft;
			if (string.IsNullOrEmpty(sound))
			{
				if (this.GetBaseSurface() != null)
				{
					this.GetBaseSurface().OnPhysicsImpact(pos, volume, speed);
				}
				return;
			}
			if (!string.IsNullOrEmpty(this.Sounds.ImpactSoft) && speed < 150f)
			{
				sound = this.Sounds.ImpactSoft;
			}
			Sound.FromWorld(sound, pos).SetVolume(volume);
		}

		// Token: 0x04000180 RID: 384
		internal static Dictionary<int, Surface> All = new Dictionary<int, Surface>();

		// Token: 0x04000181 RID: 385
		internal CPhysSurfaceProperties props;

		// Token: 0x020001EB RID: 491
		public struct ImpactEffectData
		{
			/// <summary>
			/// Spawn one of these particles on impact.
			/// </summary>
			// Token: 0x17000539 RID: 1337
			// (get) Token: 0x06001D14 RID: 7444 RVA: 0x0007282F File Offset: 0x00070A2F
			// (set) Token: 0x06001D15 RID: 7445 RVA: 0x00072837 File Offset: 0x00070A37
			[Display(Description = "Spawn one of these particles on impact.")]
			[ResourceType("vpcf")]
			public string[] Regular { readonly get; set; }

			/// <summary>
			/// Spawn one of these particles when hit by a bullet.
			/// </summary>
			// Token: 0x1700053A RID: 1338
			// (get) Token: 0x06001D16 RID: 7446 RVA: 0x00072840 File Offset: 0x00070A40
			// (set) Token: 0x06001D17 RID: 7447 RVA: 0x00072848 File Offset: 0x00070A48
			[Display(Description = "Spawn one of these particles when hit by a bullet.")]
			[ResourceType("vpcf")]
			public string[] Bullet { readonly get; set; }

			/// <summary>
			/// Use one of these as the bullet impact decal.
			/// </summary>
			// Token: 0x1700053B RID: 1339
			// (get) Token: 0x06001D18 RID: 7448 RVA: 0x00072851 File Offset: 0x00070A51
			// (set) Token: 0x06001D19 RID: 7449 RVA: 0x00072859 File Offset: 0x00070A59
			[Display(Description = "Use one of these as the bullet impact decal.")]
			[ResourceType("decal")]
			public string[] BulletDecal { readonly get; set; }
		}

		// Token: 0x020001EC RID: 492
		public struct SoundData
		{
			// Token: 0x1700053C RID: 1340
			// (get) Token: 0x06001D1A RID: 7450 RVA: 0x00072862 File Offset: 0x00070A62
			// (set) Token: 0x06001D1B RID: 7451 RVA: 0x0007286A File Offset: 0x00070A6A
			[FGDType("sound", "", "")]
			public string FootLeft { readonly get; set; }

			// Token: 0x1700053D RID: 1341
			// (get) Token: 0x06001D1C RID: 7452 RVA: 0x00072873 File Offset: 0x00070A73
			// (set) Token: 0x06001D1D RID: 7453 RVA: 0x0007287B File Offset: 0x00070A7B
			[FGDType("sound", "", "")]
			public string FootRight { readonly get; set; }

			// Token: 0x1700053E RID: 1342
			// (get) Token: 0x06001D1E RID: 7454 RVA: 0x00072884 File Offset: 0x00070A84
			// (set) Token: 0x06001D1F RID: 7455 RVA: 0x0007288C File Offset: 0x00070A8C
			[FGDType("sound", "", "")]
			public string FootLaunch { readonly get; set; }

			// Token: 0x1700053F RID: 1343
			// (get) Token: 0x06001D20 RID: 7456 RVA: 0x00072895 File Offset: 0x00070A95
			// (set) Token: 0x06001D21 RID: 7457 RVA: 0x0007289D File Offset: 0x00070A9D
			[FGDType("sound", "", "")]
			public string FootLand { readonly get; set; }

			// Token: 0x17000540 RID: 1344
			// (get) Token: 0x06001D22 RID: 7458 RVA: 0x000728A6 File Offset: 0x00070AA6
			// (set) Token: 0x06001D23 RID: 7459 RVA: 0x000728AE File Offset: 0x00070AAE
			[FGDType("sound", "", "")]
			public string Bullet { readonly get; set; }

			// Token: 0x17000541 RID: 1345
			// (get) Token: 0x06001D24 RID: 7460 RVA: 0x000728B7 File Offset: 0x00070AB7
			// (set) Token: 0x06001D25 RID: 7461 RVA: 0x000728BF File Offset: 0x00070ABF
			[FGDType("sound", "", "")]
			public string SmoothScrape { readonly get; set; }

			// Token: 0x17000542 RID: 1346
			// (get) Token: 0x06001D26 RID: 7462 RVA: 0x000728C8 File Offset: 0x00070AC8
			// (set) Token: 0x06001D27 RID: 7463 RVA: 0x000728D0 File Offset: 0x00070AD0
			[FGDType("sound", "", "")]
			public string RoughScrape { readonly get; set; }

			// Token: 0x17000543 RID: 1347
			// (get) Token: 0x06001D28 RID: 7464 RVA: 0x000728D9 File Offset: 0x00070AD9
			// (set) Token: 0x06001D29 RID: 7465 RVA: 0x000728E1 File Offset: 0x00070AE1
			[FGDType("sound", "", "")]
			public string ImpactHard { readonly get; set; }

			// Token: 0x17000544 RID: 1348
			// (get) Token: 0x06001D2A RID: 7466 RVA: 0x000728EA File Offset: 0x00070AEA
			// (set) Token: 0x06001D2B RID: 7467 RVA: 0x000728F2 File Offset: 0x00070AF2
			[FGDType("sound", "", "")]
			public string ImpactSoft { readonly get; set; }
		}
	}
}
