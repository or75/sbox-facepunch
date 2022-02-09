using System;
using NativeEngine;

/// <summary>
/// All of these functions should return between -1 and 1
/// </summary>
// Token: 0x02000008 RID: 8
public static class Noise
{
	// Token: 0x0600000E RID: 14 RVA: 0x0000228B File Offset: 0x0000048B
	public static float Perlin(float x, float y, float z)
	{
		return Mathlib.ImprovedPerlinNoise(new Vector3(x, y, z));
	}

	// Token: 0x0600000F RID: 15 RVA: 0x0000229A File Offset: 0x0000049A
	public static float SparseConvolution(float x, float y = 0f, float z = 0f)
	{
		return (Mathlib.SparseConvolutionNoise(new Vector3(x, y, z)) - 0.5f) * 2f;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x000022B5 File Offset: 0x000004B5
	public static float SparseConvolutionNormalized(float x, float y = 0f, float z = 0f)
	{
		return (Mathlib.SparseConvolutionNoiseNormalized(new Vector3(x, y, z)) - 0.5f) * 2f;
	}

	// Token: 0x06000011 RID: 17 RVA: 0x000022D0 File Offset: 0x000004D0
	public static float Fractal(int octaves, float x, float y = 0f, float z = 0f)
	{
		return (Mathlib.FractalNoise(new Vector3(x, y, z), octaves) - 0.5f) * 2f;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000022EC File Offset: 0x000004EC
	public static float Turbulence(int octaves, float x, float y = 0f, float z = 0f)
	{
		return (Mathlib.Turbulence(new Vector3(x, y, z), octaves) - 0.5f) * 2f;
	}
}
