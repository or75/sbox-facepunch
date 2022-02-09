using System;

namespace Steamworks
{
	/// <summary>
	/// Gives us a generic way to get the CallbackId of structs
	/// </summary>
	// Token: 0x02000018 RID: 24
	internal interface ICallbackData
	{
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000018 RID: 24
		CallbackType CallbackType { get; }

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000019 RID: 25
		int DataSize { get; }
	}
}
