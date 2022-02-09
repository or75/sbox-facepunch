
namespace Sandbox
{
	/// <summary>
	/// A trigger volume that damages entities that touch it.
	/// </summary>
	[Library( "trigger_hurt" )]
	[Hammer.Solid]
	public partial class TriggerHurt : BaseTrigger
	{
		/// <summary>
		/// Amount of damage to deal to touching entities per second.
		/// </summary>
		[Property( "damage", Title = "Damage" )]
		public float Damage { get; set; } = 10.0f;

		/// <summary>
		/// Fired when a player gets hurt by this trigger
		/// </summary>
		protected Output OnHurtPlayer { get; set; }

		/// <summary>
		/// Fired when anything BUT a player gets hurt by this trigger
		/// </summary>
		protected Output OnHurt { get; set; }

		[Event.Tick.Server]
		protected virtual void DealDamagePerTick()
		{
			if ( !Enabled )
				return;

			foreach ( var entity in TouchingEntities )
			{
				if ( !entity.IsValid() )
					continue;

				entity.TakeDamage( DamageInfo.Generic( Damage * Time.Delta ).WithAttacker( this ) );

				if ( entity.Tags.Has( "player" ) )
				{
					OnHurtPlayer.Fire( entity );
				}
				else
				{
					OnHurt.Fire( entity );
				}
			}
		}

		/// <summary>
		/// Sets the damage per second for this trigger_hurt
		/// </summary>
		[Input]
		protected void SetDamage( float damage )
		{
			Damage = damage;
		}
	}
}
