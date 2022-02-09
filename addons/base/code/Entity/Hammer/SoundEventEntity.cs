
namespace Sandbox
{
	/// <summary>
	/// Plays a sound event from a point. The point can be this entity or a specified entity's position.
	/// </summary>
    [Library( "snd_event_point" )]
	[Hammer.EditorSprite( "editor/snd_event.vmat" )]
	[Hammer.VisGroup( Hammer.VisGroup.Sound )]
	public partial class SoundEventEntity : Entity
	{
		/// <summary>
		/// Name of the sound to play.
		/// </summary>
		[Property( "soundName" ), FGDType( "sound" )]
		public string SoundName { get; set; }

		/// <summary>
		/// The entity to use as the origin of the sound playback. If not set, will play from this snd_event_point.
		/// </summary>
		[Property( "sourceEntityName" ), FGDType( "target_destination" )]
		public string SourceEntityName { get; set; }

		/// <summary>
		/// Start the sound on spawn
		/// </summary>
		[Property( "startOnSpawn" )]
		public bool StartOnSpawn { get; set; }

		/// <summary>
		/// Stop the sound before starting to play it again
		/// </summary>
		[Property( "stopOnNew", Title = "Stop before repeat" )]
		public bool StopOnNew { get; set; }


		//[Property( "toLocalPlayer" )]
		//public bool ToLocalPlayer { get; set; }

		public Sound PlayingSound { get; protected set; }

		/// <summary>
		/// Start the sound event. If an entity name is provided, the sound will originate from that entity
		/// </summary>
		[Input]
		protected void StartSound()
		{
			var source = Entity.FindByName( SourceEntityName, this );

			if ( StopOnNew )
				PlayingSound.Stop();

			PlayingSound = Sound.FromWorld( SoundName, source.Position );
			// BUG: Plays sound from 0 0 0 when source == this
			// PlayingSound = Sound.FromEntity( SoundName, source );

			// PlayingSound.duration;
			// fire output OnSoundFinished in duration
		}

		/// <summary>
		/// Stop the sound event
		/// </summary>
		[Input]
		protected void StopSound()
		{
			PlayingSound.Stop();
			PlayingSound = default;
		}

		public override void OnClientActive()
		{
			if ( StartOnSpawn )
			{
				StartSound();
			}
		}
	}
}
