using System;
using Sandbox;

// Token: 0x02000014 RID: 20
public struct ColorXYZ
{
	// Token: 0x1700002F RID: 47
	// (get) Token: 0x0600009D RID: 157 RVA: 0x0000518A File Offset: 0x0000338A
	// (set) Token: 0x0600009E RID: 158 RVA: 0x00005192 File Offset: 0x00003392
	public float X { readonly get; set; }

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x0600009F RID: 159 RVA: 0x0000519B File Offset: 0x0000339B
	// (set) Token: 0x060000A0 RID: 160 RVA: 0x000051A3 File Offset: 0x000033A3
	public float Y { readonly get; set; }

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x060000A1 RID: 161 RVA: 0x000051AC File Offset: 0x000033AC
	// (set) Token: 0x060000A2 RID: 162 RVA: 0x000051B4 File Offset: 0x000033B4
	public float Z { readonly get; set; }

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x060000A3 RID: 163 RVA: 0x000051BD File Offset: 0x000033BD
	// (set) Token: 0x060000A4 RID: 164 RVA: 0x000051C5 File Offset: 0x000033C5
	public float A { readonly get; set; }

	// Token: 0x060000A5 RID: 165 RVA: 0x000051CE File Offset: 0x000033CE
	public ColorXYZ(float x, float y, float z, float a = 1f)
	{
		this.X = x;
		this.Y = y;
		this.Z = z;
		this.A = a;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x000051F0 File Offset: 0x000033F0
	public override string ToString()
	{
		return string.Format("X:{0:0.###},Y:{1:0.###},Z:{2:0.###},A:{3:0.###}", new object[] { this.X, this.Y, this.Z, this.A });
	}

	/// <summary>
	/// Convert XYZ to standard RGB
	/// </summary>
	// Token: 0x060000A7 RID: 167 RVA: 0x00005245 File Offset: 0x00003445
	public Color ToColor()
	{
		return this;
	}

	/// <summary>
	/// Convert from D65 to D50 as reference white value
	/// </summary>
	// Token: 0x060000A8 RID: 168 RVA: 0x00005254 File Offset: 0x00003454
	public ColorXYZ ToD50()
	{
		return new ColorXYZ
		{
			X = this.X * 1.0479298f + this.Y * 0.022946794f + -0.05019223f * this.Z,
			Y = this.X * 0.029627815f + this.Y * 0.99043447f + -0.017073825f * this.Z,
			Z = this.X * -0.009243058f + this.Y * 0.015055145f + 0.75187427f * this.Z,
			A = this.A
		};
	}

	/// <summary>
	/// Convert from D50 to D65 as reference white value
	/// </summary>
	// Token: 0x060000A9 RID: 169 RVA: 0x00005300 File Offset: 0x00003500
	public ColorXYZ ToD65()
	{
		return new ColorXYZ
		{
			X = this.X * 0.9554734f + this.Y * -0.023098538f + 0.06325931f * this.Z,
			Y = this.X * -0.028369706f + this.Y * 1.0099955f + 0.021041399f * this.Z,
			Z = this.X * 0.012314002f + this.Y * -0.020507697f + 1.3303659f * this.Z,
			A = this.A
		};
	}

	/// <summary>
	/// Convert from the Adobe 1998 RGB Color space to XYZ
	/// </summary>
	// Token: 0x060000AA RID: 170 RVA: 0x000053AC File Offset: 0x000035AC
	public static ColorXYZ FromA98(Color a98Color)
	{
		for (int i = 0; i < 3; i++)
		{
			a98Color[i] = MathF.Pow(a98Color[i], 2.1992188f);
		}
		return new ColorXYZ
		{
			X = a98Color.r * 0.57667f + a98Color.g * 0.18555f + a98Color.b * 0.18819f,
			Y = a98Color.r * 0.29738f + a98Color.g * 0.62735f + a98Color.b * 0.07527f,
			Z = a98Color.r * 0.02703f + a98Color.g * 0.07069f + a98Color.b * 0.9911f,
			A = a98Color.a
		};
	}

	/// <summary>
	/// Convert from the Lab Color space to XYZ
	/// </summary>
	// Token: 0x060000AB RID: 171 RVA: 0x0000547C File Offset: 0x0000367C
	public static ColorXYZ FromLab(Color labColor, bool scaleToReference = true)
	{
		float a = (labColor.r + 16f) / 116f;
		float L = labColor.g / 500f + a;
		float b = a - labColor.b / 200f;
		ColorXYZ resultLab = new ColorXYZ(L, a, b, labColor.a);
		for (int i = 0; i < 3; i++)
		{
			float aPow = resultLab[i] * resultLab[i] * resultLab[i];
			if (aPow > 0.008856f)
			{
				resultLab[i] = aPow;
			}
			else
			{
				resultLab[i] = (resultLab[i] - 0.13793103f) / 7.787f;
			}
		}
		if (scaleToReference)
		{
			resultLab.X *= ColorXYZ.D50Reference[0];
			resultLab.Y *= ColorXYZ.D50Reference[1];
			resultLab.Z *= ColorXYZ.D50Reference[2];
		}
		return resultLab;
	}

	// Token: 0x060000AC RID: 172 RVA: 0x00005570 File Offset: 0x00003770
	public static ColorXYZ FromLab(ColorXYZ labColor, bool scaleToReference = true)
	{
		return ColorXYZ.FromLab(new Color(labColor.X, labColor.Y, labColor.Z, labColor.A), scaleToReference);
	}

	// Token: 0x060000AD RID: 173 RVA: 0x0000559C File Offset: 0x0000379C
	public static ColorXYZ ToLab(ColorXYZ color, bool scaleFromReference = true)
	{
		for (int i = 0; i < 3; i++)
		{
			if (scaleFromReference)
			{
				ref ColorXYZ ptr = ref color;
				int index = i;
				ptr[index] /= ColorXYZ.D65Reference[i];
			}
			if (color[i] > 0.008856f)
			{
				color[i] = MathF.Pow(color[i], 0.333f);
			}
			else
			{
				color[i] = 7.787f * color[i] + 0.13793103f;
			}
		}
		return new ColorXYZ
		{
			X = 116f * color.Y - 16f,
			Y = 500f * (color.X - color.Y),
			Z = 200f * (color.Y - color.Z),
			A = color.A
		};
	}

	/// <summary>
	/// Convert from XYZ -&gt; Standard RGB
	/// </summary>
	// Token: 0x060000AE RID: 174 RVA: 0x00005684 File Offset: 0x00003884
	public static implicit operator Color(ColorXYZ xyzColor)
	{
		Color c = new Color
		{
			r = 3.2404542f * xyzColor.X - 1.5371385f * xyzColor.Y - 0.4985314f * xyzColor.Z,
			g = -0.969266f * xyzColor.X + 1.8760108f * xyzColor.Y + 0.041556f * xyzColor.Z,
			b = 0.0556434f * xyzColor.X - 0.2040259f * xyzColor.Y + 1.0572252f * xyzColor.Z,
			a = xyzColor.A
		};
		for (int i = 0; i < 3; i++)
		{
			if (c[i] > 0.0031308f)
			{
				c[i] = 1.055f * MathF.Pow(c[i], 0.41666666f) - 0.055f;
			}
			else
			{
				ref Color ptr = ref c;
				int index = i;
				ptr[index] *= 12.92f;
			}
			c[i] = Math.Clamp(c[i], 0f, 1f);
		}
		return c;
	}

	/// <summary>
	/// Linearly interpolate from one color to another
	/// </summary>
	// Token: 0x060000AF RID: 175 RVA: 0x000057B8 File Offset: 0x000039B8
	public static ColorXYZ Lerp(ColorXYZ a, ColorXYZ b, float delta, bool clamped = true)
	{
		if (clamped && delta < 0f)
		{
			return a;
		}
		if (clamped && delta > 1f)
		{
			return b;
		}
		a = ColorXYZ.ToLab(a, false);
		b = ColorXYZ.ToLab(b, false);
		return ColorXYZ.FromLab(new ColorXYZ
		{
			X = a.X.LerpTo(b.X, delta, true),
			Y = a.Y.LerpTo(b.Y, delta, true),
			Z = a.Z.LerpTo(b.Z, delta, true),
			A = a.A.LerpTo(b.A, delta, true)
		}, false);
	}

	/// <summary>
	/// Convert standard RGB to XYZ
	/// </summary>
	// Token: 0x060000B0 RID: 176 RVA: 0x00005870 File Offset: 0x00003A70
	public static implicit operator ColorXYZ(Color rgbColor)
	{
		for (int i = 0; i < 3; i++)
		{
			if (rgbColor[i] > 0.04045f)
			{
				rgbColor[i] = MathF.Pow((rgbColor[i] + 0.055f) / 1.055f, 2.4f);
			}
			else
			{
				ref Color ptr = ref rgbColor;
				int index = i;
				ptr[index] /= 12.92f;
			}
		}
		return new ColorXYZ
		{
			X = 0.4124564f * rgbColor.r + 0.3575761f * rgbColor.g + 0.1804375f * rgbColor.b,
			Y = 0.2126729f * rgbColor.r + 0.7151522f * rgbColor.g + 0.072175f * rgbColor.b,
			Z = 0.0193339f * rgbColor.r + 0.119192f * rgbColor.g + 0.9503041f * rgbColor.b,
			A = rgbColor.a
		};
	}

	// Token: 0x17000033 RID: 51
	public float this[int index]
	{
		get
		{
			switch (index)
			{
			case 0:
				return this.X;
			case 1:
				return this.Y;
			case 2:
				return this.Z;
			case 3:
				return this.A;
			default:
				throw new IndexOutOfRangeException();
			}
		}
		set
		{
			switch (index)
			{
			case 0:
				this.X = value;
				return;
			case 1:
				this.Y = value;
				return;
			case 2:
				this.Z = value;
				return;
			case 3:
				this.A = value;
				return;
			default:
				throw new IndexOutOfRangeException();
			}
		}
	}

	// Token: 0x04000031 RID: 49
	private static readonly float[] D50Reference = new float[] { 0.9642957f, 1f, 0.8251046f };

	// Token: 0x04000032 RID: 50
	private static readonly float[] D65Reference = new float[] { 0.9504559f, 1f, 1.0890578f };
}
