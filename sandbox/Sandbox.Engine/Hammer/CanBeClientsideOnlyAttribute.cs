using System;

namespace Hammer
{
	/// <summary>
	/// Adds a property in Hammer that dictates whether the entity will be spawned on server or client.
	/// </summary>
	// Token: 0x02000216 RID: 534
	[AttributeUsage(AttributeTargets.Class)]
	public class CanBeClientsideOnlyAttribute : Attribute
	{
	}
}
