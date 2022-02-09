using System;

namespace Sandbox
{
	// Token: 0x02000058 RID: 88
	public static class IValidCheckExtension
	{
		/// <summary>
		/// returns false if IValid is null or .IsValid returns false
		/// </summary>
		// Token: 0x060003C9 RID: 969 RVA: 0x0001DCFB File Offset: 0x0001BEFB
		public static bool IsValid(this IValid obj)
		{
			return obj != null && obj.IsValid;
		}
	}
}
