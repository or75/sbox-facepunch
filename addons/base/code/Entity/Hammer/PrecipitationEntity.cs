using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sandbox
{
	/// <summary>
	/// A brush entity that creates rain and snow inside its volume.
	/// </summary>
	[Library( "func_precipitation" )]
	[Hammer.AutoApplyMaterial( "materials/tools/toolsprecipitation.vmat" )]
	[Hammer.Solid]
	public partial class PrecipitationEntity : ModelEntity
	{
		[Property, Display( Name = "Particle Effect Inner Near" ), ResourceType( "vpcf" ), Category( "Particle System" )]
		[Internal.DefaultValue( "particles/precipitation/rain_inner.vpcf" )]
		[Net] public string InnerNearEffect { get; set; }

		[Property, Display( Name = "Particle Effect Inner Far" ), ResourceType( "vpcf" ), Category( "Particle System" )]
		[Internal.DefaultValue( "particles/precipitation/rain_inner.vpcf" )]
		[Net] public string InnerFarEffect { get; set; }

		[Property, Display( Name = "Particle Effect Outer" ), ResourceType( "vpcf" ), Category( "Particle System" )]
		[Internal.DefaultValue( "particles/precipitation/rain_outer.vpcf" )]
		[Net] public string OuterEffect { get; set; }

		[Property, Display( Name = "Inner Near Distance" ), Category( "Distance" )]
		[Internal.DefaultValue( 32.0f )]
		[Net] public float InnerNearDistance { get; set; }

		[Property, Display( Name = "Inner Far Distance" ), Category( "Distance" )]
		[Internal.DefaultValue( 180.0f )]
		[Net] public float InnerFarDistance { get; set; }

		/// <summary>
		/// Set the Tint of the Particle, which will set control point 4 on the particle system.
		/// </summary>
		[Property, Display( Name = "Particle Tint" )]
		[Internal.DefaultValue( "255 255 255 255" )]
		[Net] public Color particleTint { get; set; }

		/// <summary>
		/// Sets if the particles are running by default
		/// </summary>
		[Property, Display( Name = "Start On" )]
		[Internal.DefaultValue( true )]
		[Net] public bool isRunning { get; set; }

		/// <summary>
		/// Sets the time particles take to fade in or out when turned on or off
		/// </summary>
		[Property, Display( Name = "Fade Time" )]
		[Internal.DefaultValue( 5.0f )]
		[Net] public float fadingTime { get; set; }

		/// <summary>
		/// Set the Density of the Particle, which will set control point 3 on the particle system.
		/// </summary>
		[Property, Display( Name = "Density" )]
		[Internal.DefaultValue( 100.0f )]
		[Net] public float Density { get; set; }

		[ConVar.Replicated( "precipitation_density" )]
		public static float DensityScale { get; set; } = 1.0f;

		private Particles InnerNearParticles;
		private Particles InnerFarParticles;
		private Particles OuterParticles;

		private TimeUntil ParticleFadeTime;
		private bool IsFading = false;

		//This should probably check if there is anything above the player
		private const float HeightOffset = 180.0f;

		public override void ClientSpawn()
		{
			base.ClientSpawn();

			InnerNearParticles = Particles.Create( InnerNearEffect );
			InnerFarParticles = Particles.Create( InnerFarEffect );
			OuterParticles = Particles.Create( OuterEffect );

		}

		[ClientRpc]
		public void SetActive( bool isActive )
		{
			ParticleFadeTime = fadingTime;
			IsFading = true;
		}

		/// <summary>
		/// Change the density via input.
		/// </summary>
		[Input]
		public void ChangeDensity( float densitychanged ) => Density = densitychanged;

		/// <summary>
		/// Start the particles.
		/// </summary>
		[Input]
		public void Start()
		{
			if ( !isRunning )
			{
				isRunning = true;
				SetActive( true );
			}
		}

		/// <summary>
		/// Stop the particles.
		/// </summary>
		[Input]
		public void Stop()
		{
			if ( isRunning )
			{
				isRunning = false;
				SetActive( false );
			}
		}
		/// <summary>
		/// Freezes Particles in current state.
		/// </summary>
		[Input]
		public void FreezeParticles()
		{
			SetParticleState( false );
		}
		/// <summary>
		/// UnFreezes Particles in current state.
		/// </summary>
		[Input]
		public void UnFreezeParticles()
		{
			SetParticleState( true );
		}

		/// <summary>
		/// Slow or speed up particles. 1 = normal, 0.5  half speed, 2 = twice the speed.
		/// </summary>
		[Input]
		public void ParticleTimeScale( float particletimescale )
		{
			SetParticleTimeScale ( particletimescale );
		}

		[Event.Tick.Client]
		protected void ClientTick()
		{
			var forward = CurrentView.Rotation.Forward.WithZ( 0 ).Normal;
			var density = Density * DensityScale;
			var densityModifier = 1.0f;

			if ( IsFading )
			{
				if ( !isRunning ) densityModifier = 1.0f - ParticleFadeTime.Fraction;
				else densityModifier = ParticleFadeTime.Fraction;

				if ( ParticleFadeTime )
				{
					IsFading = false;
				}
			}

			if ( !isRunning ) densityModifier = 0.0f;

			density *= densityModifier;

			if ( OuterParticles != null )
			{
				OuterParticles.SetEntity( 2, Local.Pawn );
				OuterParticles.SetPosition( 1, CurrentView.Position + Vector3.Up * HeightOffset );
				OuterParticles.SetPosition( 3, Vector3.OneX * density );
				OuterParticles.SetPosition( 4, particleTint * 255 );

			}

			if ( InnerNearParticles != null )
			{
				InnerNearParticles.SetEntity( 2, Local.Pawn );
				InnerNearParticles.SetPosition( 1, CurrentView.Position + Vector3.Up * HeightOffset + forward * InnerNearDistance );
				InnerNearParticles.SetPosition( 3, Vector3.OneX * density );
				InnerNearParticles.SetPosition( 4, particleTint * 255 );

			}

			if ( InnerFarParticles != null )
			{
				InnerFarParticles.SetEntity( 2, Local.Pawn );
				InnerFarParticles.SetPosition( 1, CurrentView.Position + Vector3.Up * HeightOffset + forward * InnerFarDistance );
				InnerFarParticles.SetPosition( 3, Vector3.OneX * density );
				InnerFarParticles.SetPosition( 4, particleTint * 255 );

			}
		}

		[ClientRpc]
		public void SetParticleState( bool newState )
		{
			if ( OuterParticles != null )
			{
				OuterParticles.Simulating = newState;
			}

			if ( InnerNearParticles != null )
			{
				InnerNearParticles.Simulating = newState;
			}

			if ( InnerFarParticles != null )
			{
				InnerFarParticles.Simulating = newState;
			}
		}
		[ClientRpc]
		public void SetParticleTimeScale( float timeScale )
		{
			if ( OuterParticles != null )
			{
				OuterParticles.TimeScale = timeScale;
			}

			if ( InnerNearParticles != null )
			{
				InnerNearParticles.TimeScale = timeScale;
			}

			if ( InnerFarParticles != null )
			{
				InnerFarParticles.TimeScale = timeScale;
			}
		}

	}
}
