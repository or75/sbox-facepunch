using System;
using System.Runtime.CompilerServices;

namespace Sandbox
{
	// Token: 0x0200005B RID: 91
	public static class ThreadSafe
	{
		// Token: 0x060003F4 RID: 1012 RVA: 0x0001E7F2 File Offset: 0x0001C9F2
		internal static void MarkMainThread()
		{
			ThreadSafe.IsMainThread = true;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x0001E7FA File Offset: 0x0001C9FA
		public static void AssertIsMainThread([CallerMemberName] string memberName = "")
		{
			if (ThreadSafe.IsMainThread)
			{
				return;
			}
			throw new Exception(memberName + " must be called on the main thread!");
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0001E814 File Offset: 0x0001CA14
		public static void AssertIsNotMainThread()
		{
			if (!ThreadSafe.IsMainThread)
			{
				return;
			}
			throw new Exception("This function must not be called on the main thread!");
		}

		// Token: 0x040008CD RID: 2253
		[ThreadStatic]
		public static bool IsMainThread;
	}
}
