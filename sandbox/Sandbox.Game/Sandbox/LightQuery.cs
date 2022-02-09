using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000B8 RID: 184
	[Hotload.SkipAttribute]
	public static class LightQuery
	{
		// Token: 0x060011A4 RID: 4516 RVA: 0x0004AE90 File Offset: 0x00049090
		public static Color GetLightForPoint(Vector3 point)
		{
			return LightQueryGameSystem.GetLightForPoint(point);
		}
	}
}
