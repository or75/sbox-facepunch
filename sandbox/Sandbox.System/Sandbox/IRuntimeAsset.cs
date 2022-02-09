using System;

namespace Sandbox
{
	// Token: 0x02000030 RID: 48
	public interface IRuntimeAsset
	{
		/// <summary>
		/// If this is defined as a static we call this function on load with its
		/// full name. This allows you to set the name of your runtime asset to this 
		/// name - which should offers a degree of debuggability and uniqueness.
		/// </summary>
		// Token: 0x06000299 RID: 665 RVA: 0x0000B020 File Offset: 0x00009220
		void StaticRuntimeInit(string v)
		{
		}
	}
}
