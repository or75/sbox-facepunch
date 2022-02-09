using System;

namespace Hammer
{
	/// <summary>
	/// This is a brush based enity class. It can only be a mesh tied to an entity. If this is not used, the entity will be considered a point class and will only appear in the Entity Tool.
	/// </summary>
	// Token: 0x02000203 RID: 515
	[AttributeUsage(AttributeTargets.Class)]
	public class SolidAttribute : Attribute
	{
	}
}
