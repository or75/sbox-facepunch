using System;

namespace Sandbox
{
	// Token: 0x02000055 RID: 85
	internal static class StyleHelpers
	{
		// Token: 0x060003C2 RID: 962 RVA: 0x0001DAE0 File Offset: 0x0001BCE0
		internal static float RotationDegrees(float val, string unit)
		{
			if (unit.StartsWith("grad"))
			{
				return val.GradiansToDegrees();
			}
			if (unit.StartsWith("rad"))
			{
				return val.RadianToDegree();
			}
			if (unit.StartsWith("turn"))
			{
				return val * 360f;
			}
			unit.StartsWith("deg");
			return val;
		}
	}
}
