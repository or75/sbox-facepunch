using System;

namespace Tools
{
	// Token: 0x020000A0 RID: 160
	public enum SizeMode
	{
		/// <summary>
		/// Can grow beyond its size hint if necessary
		/// </summary>
		// Token: 0x040003DF RID: 991
		CanGrow = 1,
		/// <summary>
		/// Should get as much space as possible.
		/// </summary>
		// Token: 0x040003E0 RID: 992
		Expand,
		/// <summary>
		/// can shrink below its size hint if necessary.
		/// </summary>
		// Token: 0x040003E1 RID: 993
		CanShrink = 4,
		/// <summary>
		/// Widget size is ignored, will get as much space as possible.
		/// </summary>
		// Token: 0x040003E2 RID: 994
		Ignore = 8,
		/// <summary>
		/// Default size mode - CanGrow and CanShrink
		/// </summary>
		// Token: 0x040003E3 RID: 995
		Default = 5
	}
}
