using System;

namespace Sandbox
{
	/// <summary>
	/// This struct exists to differentiate the constructor of a handle object
	/// from the regular constructors. This way we can prevent clients creating
	/// the object manually, but still be able to create them at runtime.
	/// </summary>
	// Token: 0x020002B1 RID: 689
	internal struct HandleCreationData
	{
	}
}
