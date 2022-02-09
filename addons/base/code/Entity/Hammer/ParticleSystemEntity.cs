using System.ComponentModel.DataAnnotations;

namespace Sandbox
{
	/// <summary>
	/// A entity that represents and allows control of a single particle system.
	/// </summary>
    [Library( "info_particle_system" )]
	[Hammer.EntityTool( "Particle system", "Effects", "A particle system" )]
	[Hammer.EditorModel( "models/editor/cone_helper.vmdl" )]
	[Hammer.VisGroup( Hammer.VisGroup.Particles )]
	[Hammer.Particle]
	[Display( Name = "Particle System" ), Icon( "auto_fix_high" )]
	public partial class ParticleSystemEntity : Entity
	{
		// This needs to be coded to match what the engine version does, which is basically changing
		// a status networked variable serverside and letting the client create/destroy the particle
		// as appropriate clientside.. which makes more sense since the particle can be persistent between
		// dormancy periods.

		/// <summary>
		/// The name of the particle system.
		/// </summary>
		[Property( "effect_name" ), Hammer.EntityReportSource, FGDType( "particlesystem" )]
		public string ParticleSystemName { get; set; }

		/// <summary>
		/// Should this system start active when it enters a player's PVS?
		/// </summary>
		[Property( "start_active" )]
		public bool StartActive { get; set; } = true;

		/// <summary>
		/// Name of .PSF (Particle Snapshot File) to be loaded and used by this particle system (e.g. 'smoke_snapshot1')
		/// </summary>
		[Property( "snapshot_file" )]
		public string SnapshotFile { get; set; }

		// Control points, ew
		/// <summary>
		/// If set, control point 0 of the effect will be at this entity's location. (Otherwise it is at the info_particle_system origin)
		/// </summary>
		[Property( "cpoint0", Title = "Control Point 0"), FGDType( "target_destination" )] public string ControlPoint0 { get; set; }

		/// <summary>
		/// If set, control point 1 of the effect will be at this entity's location.
		/// </summary>
		[Property( "cpoint1", Title = "Control Point 1"), FGDType( "target_destination" )] public string ControlPoint1 { get; set; }

		/// <summary>
		/// If set, control point 2 of the effect will be at this entity's location. If control point 1 is not set, this will be ignored.
		/// </summary>
		[Property( "cpoint2", Title = "Control Point 2"), FGDType( "target_destination" )] public string ControlPoint2 { get; set; }
		[Property( "cpoint3" ), FGDType( "target_destination" )] public string ControlPoint3 { get; set; }
		[Property( "cpoint4" ), FGDType( "target_destination" )] public string ControlPoint4 { get; set; }
		[Property( "cpoint5" ), FGDType( "target_destination" )] public string ControlPoint5 { get; set; }
		[Property( "cpoint6" ), FGDType( "target_destination" )] public string ControlPoint6 { get; set; }
		[Property( "cpoint7" ), FGDType( "target_destination" )] public string ControlPoint7 { get; set; }
		[Property( "cpoint8" ), FGDType( "target_destination" )] public string ControlPoint8 { get; set; }
		[Property( "cpoint9" ), FGDType( "target_destination" )] public string ControlPoint9 { get; set; }
		[Property( "cpoint10" ), FGDType( "target_destination" )] public string ControlPoint10 { get; set; }
		[Property( "cpoint11" ), FGDType( "target_destination" )] public string ControlPoint11 { get; set; }
		[Property( "cpoint12" ), FGDType( "target_destination" )] public string ControlPoint12 { get; set; }
		[Property( "cpoint13" ), FGDType( "target_destination" )] public string ControlPoint13 { get; set; }
		[Property( "cpoint14" ), FGDType( "target_destination" )] public string ControlPoint14 { get; set; }
		[Property( "cpoint15" ), FGDType( "target_destination" )] public string ControlPoint15 { get; set; }
		[Property( "cpoint16" ), FGDType( "target_destination" )] public string ControlPoint16 { get; set; }
		[Property( "cpoint17" ), FGDType( "target_destination" )] public string ControlPoint17 { get; set; }
		[Property( "cpoint18" ), FGDType( "target_destination" )] public string ControlPoint18 { get; set; }
		[Property( "cpoint19" ), FGDType( "target_destination" )] public string ControlPoint19 { get; set; }
		[Property( "cpoint20" ), FGDType( "target_destination" )] public string ControlPoint20 { get; set; }
		[Property( "cpoint21" ), FGDType( "target_destination" )] public string ControlPoint21 { get; set; }
		[Property( "cpoint22" ), FGDType( "target_destination" )] public string ControlPoint22 { get; set; }
		[Property( "cpoint23" ), FGDType( "target_destination" )] public string ControlPoint23 { get; set; }
		[Property( "cpoint24" ), FGDType( "target_destination" )] public string ControlPoint24 { get; set; }
		[Property( "cpoint25" ), FGDType( "target_destination" )] public string ControlPoint25 { get; set; }
		[Property( "cpoint26" ), FGDType( "target_destination" )] public string ControlPoint26 { get; set; }
		[Property( "cpoint27" ), FGDType( "target_destination" )] public string ControlPoint27 { get; set; }
		[Property( "cpoint28" ), FGDType( "target_destination" )] public string ControlPoint28 { get; set; }
		[Property( "cpoint29" ), FGDType( "target_destination" )] public string ControlPoint29 { get; set; }
		[Property( "cpoint30" ), FGDType( "target_destination" )] public string ControlPoint30 { get; set; }
		[Property( "cpoint31" ), FGDType( "target_destination" )] public string ControlPoint31 { get; set; }
		[Property( "cpoint32" ), FGDType( "target_destination" )] public string ControlPoint32 { get; set; }
		[Property( "cpoint33" ), FGDType( "target_destination" )] public string ControlPoint33 { get; set; }
		[Property( "cpoint34" ), FGDType( "target_destination" )] public string ControlPoint34 { get; set; }
		[Property( "cpoint35" ), FGDType( "target_destination" )] public string ControlPoint35 { get; set; }
		[Property( "cpoint36" ), FGDType( "target_destination" )] public string ControlPoint36 { get; set; }
		[Property( "cpoint37" ), FGDType( "target_destination" )] public string ControlPoint37 { get; set; }
		[Property( "cpoint38" ), FGDType( "target_destination" )] public string ControlPoint38 { get; set; }
		[Property( "cpoint39" ), FGDType( "target_destination" )] public string ControlPoint39 { get; set; }
		[Property( "cpoint40" ), FGDType( "target_destination" )] public string ControlPoint40 { get; set; }
		[Property( "cpoint41" ), FGDType( "target_destination" )] public string ControlPoint41 { get; set; }
		[Property( "cpoint42" ), FGDType( "target_destination" )] public string ControlPoint42 { get; set; }
		[Property( "cpoint43" ), FGDType( "target_destination" )] public string ControlPoint43 { get; set; }
		[Property( "cpoint44" ), FGDType( "target_destination" )] public string ControlPoint44 { get; set; }
		[Property( "cpoint45" ), FGDType( "target_destination" )] public string ControlPoint45 { get; set; }
		[Property( "cpoint46" ), FGDType( "target_destination" )] public string ControlPoint46 { get; set; }
		[Property( "cpoint47" ), FGDType( "target_destination" )] public string ControlPoint47 { get; set; }
		[Property( "cpoint48" ), FGDType( "target_destination" )] public string ControlPoint48 { get; set; }
		[Property( "cpoint49" ), FGDType( "target_destination" )] public string ControlPoint49 { get; set; }
		[Property( "cpoint50" ), FGDType( "target_destination" )] public string ControlPoint50 { get; set; }
		[Property( "cpoint51" ), FGDType( "target_destination" )] public string ControlPoint51 { get; set; }
		[Property( "cpoint52" ), FGDType( "target_destination" )] public string ControlPoint52 { get; set; }
		[Property( "cpoint53" ), FGDType( "target_destination" )] public string ControlPoint53 { get; set; }
		[Property( "cpoint54" ), FGDType( "target_destination" )] public string ControlPoint54 { get; set; }
		[Property( "cpoint55" ), FGDType( "target_destination" )] public string ControlPoint55 { get; set; }
		[Property( "cpoint56" ), FGDType( "target_destination" )] public string ControlPoint56 { get; set; }
		[Property( "cpoint57" ), FGDType( "target_destination" )] public string ControlPoint57 { get; set; }
		[Property( "cpoint58" ), FGDType( "target_destination" )] public string ControlPoint58 { get; set; }
		[Property( "cpoint59" ), FGDType( "target_destination" )] public string ControlPoint59 { get; set; }
		[Property( "cpoint60" ), FGDType( "target_destination" )] public string ControlPoint60 { get; set; }
		[Property( "cpoint61" ), FGDType( "target_destination" )] public string ControlPoint61 { get; set; }
		[Property( "cpoint62" ), FGDType( "target_destination" )] public string ControlPoint62 { get; set; }
		[Property( "cpoint63" ), FGDType( "target_destination" )] public string ControlPoint63 { get; set; }

		/// <summary>
		/// If set and nonzero, control point 1 of the effect will use this point for its parent.
		/// </summary>
		[Property( "cpoint1_parent", Title = "Control Point 1's Parent" )] public int ControlPoint1_Parent { get; set; }
		[Property( "cpoint2_parent" )] public int ControlPoint2_Parent { get; set; }
		[Property( "cpoint3_parent" )] public int ControlPoint3_Parent { get; set; }
		[Property( "cpoint4_parent" )] public int ControlPoint4_Parent { get; set; }
		[Property( "cpoint5_parent" )] public int ControlPoint5_Parent { get; set; }
		[Property( "cpoint6_parent" )] public int ControlPoint6_Parent { get; set; }
		[Property( "cpoint7_parent" )] public int ControlPoint7_Parent { get; set; }

		public override void Spawn()
		{
			base.Spawn();

			Transmit = TransmitType.Always;
		}

		public Particles ActiveSystem { get; protected set; }

		/// <summary>
		///Tell the particle system to start emitting
		/// </summary>
		[Input]
		protected void Start()
		{
			ActiveSystem?.Destroy( true );
			ActiveSystem = Particles.Create( ParticleSystemName, this );
			UpdateControlPoints();
			if ( !string.IsNullOrEmpty( SnapshotFile ) ) ActiveSystem.SetSnapshot( 0, SnapshotFile );
		}

		void UpdateControlPoints()
		{
			// TODO: Reimplement in more automatic way
			Entity ent;

			ent = Entity.FindByName( ControlPoint0 );
			if ( ent == null ) ent = this;
			if ( ent == null ) return;
			ActiveSystem.SetEntity( 0, ent );

			ent = Entity.FindByName( ControlPoint1 );
			if ( ent == null ) return;
			ActiveSystem.SetEntity( 1, ent );

			ent = Entity.FindByName( ControlPoint2 );
			if ( ent == null ) return;
			ActiveSystem.SetEntity( 2, ent );

			ent = Entity.FindByName( ControlPoint3 );
			if ( ent == null ) return;
			ActiveSystem.SetEntity( 3, ent );
		}

		/// <summary>
		/// Tell the particle system to stop emitting.
		/// </summary>
		[Input]
		protected void Stop()
		{
			ActiveSystem?.Destroy( true );
			ActiveSystem = null;
		}

		/// <summary>
		/// Tell the particle system to stop emitting and play its End Cap Effect.
		/// </summary>
		[Input]
		protected void StopPlayEndCap()
		{
			ActiveSystem?.Destroy( false );
			//TODO: EndCap
			ActiveSystem = null;
		}

		/// <summary>
		/// Destroy the particle system and remove all particles immediately
		/// </summary>
		[Input]
		protected void DestroyImmediately()
		{
			ActiveSystem?.Destroy( true );
			ActiveSystem = null;
		}

		/// <summary>
		/// Set a Control Point via format - CP: X Y Z
		/// </summary>
		[Input]
		protected void SetControlPoint()
		{
			Log.Info( $"// TODO SetControlPoint: recv argument, parse etc" );
		}

		public override void OnClientActive()
		{
			if ( StartActive )
			{
				Start();
			}
		}
	}
}
