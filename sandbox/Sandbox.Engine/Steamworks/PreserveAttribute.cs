using System;

namespace Steamworks
{
	/// <summary>
	/// Prevent unity from stripping shit we depend on
	/// https://docs.unity3d.com/Manual/ManagedCodeStripping.html
	/// </summary>
	// Token: 0x020000B7 RID: 183
	internal class PreserveAttribute : Attribute
	{
	}
}
