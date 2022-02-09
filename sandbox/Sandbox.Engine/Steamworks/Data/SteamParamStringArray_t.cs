using System;
using System.Runtime.InteropServices;

namespace Steamworks.Data
{
	// Token: 0x020001A8 RID: 424
	[StructLayout(LayoutKind.Sequential, Pack = 8)]
	internal struct SteamParamStringArray_t
	{
		// Token: 0x04000D03 RID: 3331
		internal IntPtr Strings;

		// Token: 0x04000D04 RID: 3332
		internal int NumStrings;
	}
}
