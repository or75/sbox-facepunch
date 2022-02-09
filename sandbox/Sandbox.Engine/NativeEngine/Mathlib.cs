using System;

namespace NativeEngine
{
	// Token: 0x0200023B RID: 571
	internal static class Mathlib
	{
		// Token: 0x06000E88 RID: 3720 RVA: 0x00019B18 File Offset: 0x00017D18
		internal unsafe static float ImprovedPerlinNoise(Vector3 pnt)
		{
			method glblMt_ImprovedPerlinNoise = Mathlib.__N.glblMt_ImprovedPerlinNoise;
			return calli(System.Single(Vector3*), &pnt, glblMt_ImprovedPerlinNoise);
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x00019B34 File Offset: 0x00017D34
		internal unsafe static float SparseConvolutionNoise(Vector3 pnt)
		{
			method glblMt_SparseConvolutionNoise = Mathlib.__N.glblMt_SparseConvolutionNoise;
			return calli(System.Single(Vector3*), &pnt, glblMt_SparseConvolutionNoise);
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x00019B50 File Offset: 0x00017D50
		internal unsafe static float SparseConvolutionNoiseNormalized(Vector3 pnt)
		{
			method glblMt_SparseConvolutionNoiseNormalized = Mathlib.__N.glblMt_SparseConvolutionNoiseNormalized;
			return calli(System.Single(Vector3*), &pnt, glblMt_SparseConvolutionNoiseNormalized);
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x00019B6C File Offset: 0x00017D6C
		internal unsafe static float FractalNoise(Vector3 pnt, int n_octaves)
		{
			method glblMt_FractalNoise = Mathlib.__N.glblMt_FractalNoise;
			return calli(System.Single(Vector3*,System.Int32), &pnt, n_octaves, glblMt_FractalNoise);
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x00019B8C File Offset: 0x00017D8C
		internal unsafe static float Turbulence(Vector3 pnt, int n_octaves)
		{
			method glblMt_Turbulence = Mathlib.__N.glblMt_Turbulence;
			return calli(System.Single(Vector3*,System.Int32), &pnt, n_octaves, glblMt_Turbulence);
		}

		// Token: 0x020003A0 RID: 928
		internal static class __N
		{
			// Token: 0x04001875 RID: 6261
			internal static method glblMt_ImprovedPerlinNoise;

			// Token: 0x04001876 RID: 6262
			internal static method glblMt_SparseConvolutionNoise;

			// Token: 0x04001877 RID: 6263
			internal static method glblMt_SparseConvolutionNoiseNormalized;

			// Token: 0x04001878 RID: 6264
			internal static method glblMt_FractalNoise;

			// Token: 0x04001879 RID: 6265
			internal static method glblMt_Turbulence;
		}
	}
}
