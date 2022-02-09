using System;
using System.Runtime.InteropServices;

namespace Steamworks
{
	// Token: 0x020000B8 RID: 184
	internal static class Platform
	{
		// Token: 0x0400095D RID: 2397
		internal const int StructPlatformPackSize = 8;

		// Token: 0x0400095E RID: 2398
		internal const string LibraryName = "steam_api64";

		// Token: 0x0400095F RID: 2399
		internal const CallingConvention CC = CallingConvention.Cdecl;

		// Token: 0x04000960 RID: 2400
		internal const int StructPackSize = 4;
	}
}
