
namespace Sandbox
{
	/// <summary>
	/// A simple trigger volume that fires once and then removes itself.
	/// </summary>
	[Library( "trigger_once" )]
	[Hammer.Solid]
	public partial class TriggerOnce : BaseTrigger
	{
		public override void Spawn()
		{
			base.Spawn();

			EnableTouchPersists = true;
		}

		public override void OnTouchStart( Entity other )
		{
			base.OnTouchStart( other );

			if ( !Enabled ) return;

			OnTriggered( other );

			_ = DeleteAsync( Time.Delta );
		}

		/// <summary>
		/// Called once at least a single entity that passes filters is touching this trigger, just before this trigger getting deleted
		/// </summary>
		protected Output OnTrigger { get; set; }

		public virtual void OnTriggered( Entity other )
		{
			OnTrigger.Fire( other );
		}
	}
}
