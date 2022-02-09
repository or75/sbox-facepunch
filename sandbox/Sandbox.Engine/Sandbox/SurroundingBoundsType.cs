using System;

namespace Sandbox
{
	// Token: 0x0200029E RID: 670
	public enum SurroundingBoundsType : byte
	{
		/// <summary>
		/// To contain the object's OBB
		/// </summary>
		// Token: 0x04001352 RID: 4946
		Obb,
		/// <summary>
		/// The most expensive option. Work it out using the physics objects. If it's a ragdoll it'll
		/// contain each physics object.
		/// </summary>
		// Token: 0x04001353 RID: 4947
		Physics,
		// Token: 0x04001354 RID: 4948
		Hitboxes,
		/// <summary>
		/// Unused
		/// </summary>
		// Token: 0x04001355 RID: 4949
		Specified,
		/// <summary>
		/// Unused
		/// </summary>
		// Token: 0x04001356 RID: 4950
		GameCode,
		/// <summary>
		/// Unused
		/// </summary>
		// Token: 0x04001357 RID: 4951
		RotationExpanded,
		/// <summary>
		/// Unused
		/// </summary>
		// Token: 0x04001358 RID: 4952
		CollisionBoundsNotPhysics,
		/// <summary>
		/// Fuck knows: Computes the surrounding collision bounds from the current sequence box
		/// </summary>
		// Token: 0x04001359 RID: 4953
		RotationExpandedSequence
	}
}
