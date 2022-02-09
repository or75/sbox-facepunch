using System;

namespace Sandbox
{
	/// <summary>
	/// If an entity implements this it'll be usable by looking at it and pressing the USE button.
	/// </summary>
	// Token: 0x0200008D RID: 141
	public interface IUse
	{
		/// <summary>
		/// The (probably) player has used this entity. Return true if the player
		/// should continually use it. Return false when the player should stop using it.
		/// For example - a health charger will return true while the player is taking health.
		/// We're passing the player in as an entity so at some point
		/// if we want NPCs using shit, we can do that without the assumption.
		/// </summary>
		// Token: 0x06000E9D RID: 3741
		bool OnUse(Entity user);

		/// <summary>
		/// Should return true if the entity can use this entity.
		/// </summary>
		// Token: 0x06000E9E RID: 3742
		bool IsUsable(Entity user);
	}
}
