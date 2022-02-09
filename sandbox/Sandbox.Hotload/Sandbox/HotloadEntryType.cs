using System;

namespace Sandbox
{
	/// <summary>
	/// Used to categorize messages emitted when performing a hotload.
	/// </summary>
	// Token: 0x02000007 RID: 7
	public enum HotloadEntryType
	{
		/// <summary>
		/// Used for messages related to debugging or profiling.
		/// </summary>
		// Token: 0x04000013 RID: 19
		Information,
		/// <summary>
		/// Used for messages warning about potential issues.
		/// </summary>
		// Token: 0x04000014 RID: 20
		Warning,
		/// <summary>
		/// Used for messages reporting a failed instance replacement.
		/// </summary>
		// Token: 0x04000015 RID: 21
		Error
	}
}
