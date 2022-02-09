using System;

namespace Hammer
{
	/// <summary>
	/// Used to tell Hammer which automatic Visibility Groups an entity should belong to. See <see cref="T:Hammer.VisGroupAttribute">VisGroupAttribute</see>.
	/// </summary>
	// Token: 0x02000207 RID: 519
	public enum VisGroup
	{
		/// <summary>
		/// Entities that are primarily lights and that sort of thing.
		/// </summary>
		// Token: 0x04000DD9 RID: 3545
		Lighting,
		/// <summary>
		/// The purpose of these entities is to emit light and not much else.
		/// </summary>
		// Token: 0x04000DDA RID: 3546
		Sound,
		/// <summary>
		/// Pure logic entities, typically not shown in-game.
		/// </summary>
		// Token: 0x04000DDB RID: 3547
		Logic,
		/// <summary>
		/// Any sort of trigger volume, these usually don't show up in-game.
		/// </summary>
		// Token: 0x04000DDC RID: 3548
		Trigger,
		/// <summary>
		/// Entities that are related to nav meshes.
		/// </summary>
		// Token: 0x04000DDD RID: 3549
		Navigation,
		/// <summary>
		/// The main reason these exist is to create particle systems.
		/// </summary>
		// Token: 0x04000DDE RID: 3550
		Particles,
		/// <summary>
		/// Physics enabled entities.
		/// </summary>
		// Token: 0x04000DDF RID: 3551
		Physics,
		/// <summary>
		/// Entities that do not move via physics but are still intreactable with or otherwise non static.
		/// </summary>
		// Token: 0x04000DE0 RID: 3552
		Dynamic
	}
}
