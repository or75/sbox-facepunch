using System;
using System.Numerics;

namespace Sandbox
{
	// Token: 0x020002DE RID: 734
	internal static class MatrixExtension
	{
		/// <summary>
		/// Converts a <see cref="T:Matrix" /> from Source to SteamVr coordinate system and scale
		/// </summary>
		/// <remarks>
		/// Source: X=fowards, Y=left, Z=up, scale = inches.
		/// SteamVr: X=right, Y=up, Z=backwards, scale = meters.
		/// </remarks>
		// Token: 0x06001369 RID: 4969 RVA: 0x0002818C File Offset: 0x0002638C
		internal static Matrix SourceToSteamVrCoordinateSystem(this Matrix matrix)
		{
			Matrix4x4 i = matrix.Numerics;
			return new Matrix
			{
				Numerics = new Matrix4x4(i.M22, -i.M23, i.M21, -i.M24, -i.M32, i.M33, -i.M31, i.M34, i.M12, -i.M13, i.M11, -i.M14, -i.M42.InchToMeter(), i.M43.InchToMeter(), -i.M41.InchToMeter(), i.M44)
			};
		}
	}
}
