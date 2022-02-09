using System;
using System.Collections.Generic;

namespace Hammer
{
	/// <summary>
	/// Indicate to the map builder that any meshes associated with the entity should have a mesh physics type.
	/// </summary>
	// Token: 0x02000205 RID: 517
	[AttributeUsage(AttributeTargets.Class)]
	public class PhysicsTypeOverrideMeshAttribute : MetaDataAttribute
	{
		// Token: 0x06000D13 RID: 3347 RVA: 0x0001662C File Offset: 0x0001482C
		public override void AddTags(List<string> tags)
		{
			tags.Add("PhysicsTypeOverride_Mesh");
		}
	}
}
