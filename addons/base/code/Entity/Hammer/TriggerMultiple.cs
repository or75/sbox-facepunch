
namespace Sandbox
{
	/// <summary>
	/// A volume that can be triggered multiple times, including at an interval while something is inside the trigger volume.
	/// </summary>
	[Library( "trigger_multiple" )]
	[Hammer.Solid]
	public partial class TriggerMultiple : BaseTrigger
	{
		/// <summary>
		/// Amount of time, in seconds, after the trigger_multiple has triggered before it can be triggered again. If set to -1, it will never trigger again (in which case you should just use a trigger_once). This affects OnTrigger output.
		/// </summary>
		[Property( "wait", Title = "Delay before reset" )]
		public float Wait { get; set; } = 1;

		TimeSince TimeSinceTriggered;

		public override void Spawn()
		{
			base.Spawn();

			EnableTouchPersists = true;

			if ( Wait <= 0 ) Wait = 0.2f;
		}

		/// <summary>
		/// Called every "Delay before reset" seconds as long as at least one entity that passes filters is touching this trigger
		/// </summary>
		protected Output OnTrigger { get; set; }

		public virtual void OnTriggered( Entity other )
		{
			OnTrigger.Fire( other );
		}

		public override void Touch( Entity other )
		{
			base.Touch( other );

			if ( !Enabled ) return;
			if ( TimeSinceTriggered < Wait ) return;
			if ( TouchingEntityCount < 1 ) return;

			TimeSinceTriggered = 0;
			OnTriggered( other );
		}
	}
}
