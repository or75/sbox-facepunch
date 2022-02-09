using System;

namespace Sandbox
{
	// Token: 0x020000D3 RID: 211
	public enum CollisionGroup
	{
		/// <summary>
		/// This will *ALWAYS* collide
		/// This group does not generate contacts or interact with any other groups by default
		/// </summary>
		// Token: 0x040003F2 RID: 1010
		Always,
		/// <summary>
		/// Never collide with anything
		/// </summary>
		// Token: 0x040003F3 RID: 1011
		Never,
		/// <summary>
		/// Trigger layer, never collides with anything, only triggers/interacts
		/// </summary>
		// Token: 0x040003F4 RID: 1012
		Trigger,
		/// <summary>
		/// Conditionally solid means that the collision response will be zero or as defined in the table when there are matching interactions
		/// </summary>
		// Token: 0x040003F5 RID: 1013
		ConditionallySolid,
		/// <summary>
		/// standard dynamic rigid object, finite mass
		/// </summary>
		// Token: 0x040003F6 RID: 1014
		Default,
		/// <summary>
		/// Collides with nothing but world and static stuff
		/// </summary>
		// Token: 0x040003F7 RID: 1015
		Debris,
		/// <summary>
		/// Collides with everything except other interactive debris or debris
		/// </summary>
		// Token: 0x040003F8 RID: 1016
		DebrisInteractive,
		/// <summary>
		/// Collides with everything except interactive debris or debris
		/// </summary>
		// Token: 0x040003F9 RID: 1017
		Interactive,
		// Token: 0x040003FA RID: 1018
		Player,
		// Token: 0x040003FB RID: 1019
		Prop = 24,
		// Token: 0x040003FC RID: 1020
		Weapon = 14
	}
}
