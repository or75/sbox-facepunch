using System;

namespace Sandbox
{
	/// <summary>
	/// Default model archetypes.
	/// These types are defined in "tools/model_archetypes.txt".
	/// </summary>
	// Token: 0x020002A8 RID: 680
	public enum ModelArchetype
	{
		/// <summary>
		/// A static model. It can still have collisions, but they do not have physics.
		/// </summary>
		// Token: 0x04001384 RID: 4996
		static_prop_model = 1,
		/// <summary>
		/// Animated model. Typically no physics.
		/// </summary>
		// Token: 0x04001385 RID: 4997
		animated_model,
		/// <summary>
		/// A generic physics enabled model.
		/// </summary>
		// Token: 0x04001386 RID: 4998
		physics_prop_model = 4,
		/// <summary>
		/// A ragdoll type model.
		/// </summary>
		// Token: 0x04001387 RID: 4999
		jointed_physics_model = 8,
		/// <summary>
		/// A physics model that can be broken into other physics models.
		/// </summary>
		// Token: 0x04001388 RID: 5000
		breakable_prop_model = 16,
		/// <summary>
		/// A generic actor/NPC model.
		/// </summary>
		// Token: 0x04001389 RID: 5001
		generic_actor_model = 32
	}
}
