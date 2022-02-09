using System;

namespace Sandbox
{
	// Token: 0x02000029 RID: 41
	public static class Assert
	{
		// Token: 0x06000289 RID: 649 RVA: 0x0000AF4B File Offset: 0x0000914B
		public static void NotNull<T>(T obj)
		{
			if (obj == null)
			{
				throw new Exception("Assert: NotNull");
			}
		}

		// Token: 0x0600028A RID: 650 RVA: 0x0000AF60 File Offset: 0x00009160
		public static void AreEqual<T>(T a, T b)
		{
			if (!object.Equals(a, b))
			{
				throw new Exception("Assert: AreEqual");
			}
		}

		// Token: 0x0600028B RID: 651 RVA: 0x0000AF80 File Offset: 0x00009180
		public static void True(bool isValid)
		{
			if (!isValid)
			{
				throw new Exception("Assert: True");
			}
		}

		// Token: 0x0600028C RID: 652 RVA: 0x0000AF90 File Offset: 0x00009190
		public static void False(bool isValid)
		{
			if (isValid)
			{
				throw new Exception("Assert: False");
			}
		}
	}
}
