using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x02000230 RID: 560
	internal static class GameUIService
	{
		// Token: 0x06000E56 RID: 3670 RVA: 0x00019590 File Offset: 0x00017790
		internal static void EnableUIMouse(bool b)
		{
			method gpGmeU_EnableUIMouse = GameUIService.__N.gpGmeU_EnableUIMouse;
			calli(System.Void(System.Int32), b ? 1 : 0, gpGmeU_EnableUIMouse);
		}

		// Token: 0x06000E57 RID: 3671 RVA: 0x000195B0 File Offset: 0x000177B0
		internal static void SetCursor(CursorType cursor)
		{
			method gpGmeU_SetCursor = GameUIService.__N.gpGmeU_SetCursor;
			calli(System.Void(System.Int64), (long)cursor, gpGmeU_SetCursor);
		}

		// Token: 0x02000395 RID: 917
		internal static class __N
		{
			// Token: 0x04001843 RID: 6211
			internal static method gpGmeU_EnableUIMouse;

			// Token: 0x04001844 RID: 6212
			internal static method gpGmeU_SetCursor;
		}
	}
}
