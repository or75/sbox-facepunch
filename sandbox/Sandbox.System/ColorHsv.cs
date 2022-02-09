using System;

// Token: 0x02000013 RID: 19
public struct ColorHsv
{
	// Token: 0x1700002B RID: 43
	// (get) Token: 0x06000087 RID: 135 RVA: 0x00004D29 File Offset: 0x00002F29
	// (set) Token: 0x06000088 RID: 136 RVA: 0x00004D31 File Offset: 0x00002F31
	public float Hue { readonly get; set; }

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x06000089 RID: 137 RVA: 0x00004D3A File Offset: 0x00002F3A
	// (set) Token: 0x0600008A RID: 138 RVA: 0x00004D42 File Offset: 0x00002F42
	public float Saturation { readonly get; set; }

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x0600008B RID: 139 RVA: 0x00004D4B File Offset: 0x00002F4B
	// (set) Token: 0x0600008C RID: 140 RVA: 0x00004D53 File Offset: 0x00002F53
	public float Value { readonly get; set; }

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x0600008D RID: 141 RVA: 0x00004D5C File Offset: 0x00002F5C
	// (set) Token: 0x0600008E RID: 142 RVA: 0x00004D64 File Offset: 0x00002F64
	public float Alpha { readonly get; set; }

	// Token: 0x0600008F RID: 143 RVA: 0x00004D6D File Offset: 0x00002F6D
	public ColorHsv(float h, float s, float v, float a = 1f)
	{
		this.Hue = h;
		this.Saturation = s;
		this.Value = v;
		this.Alpha = a;
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00004D8C File Offset: 0x00002F8C
	public override string ToString()
	{
		return string.Format("H:{0:0.###},S:{1:0.###},V:{2:0.###},A:{3:0.###}", new object[] { this.Hue, this.Saturation, this.Value, this.Alpha });
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00004DE1 File Offset: 0x00002FE1
	public Color ToColor()
	{
		return this;
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00004DEE File Offset: 0x00002FEE
	public ColorHsv WithHue(float hue)
	{
		return new ColorHsv(hue, this.Saturation, this.Value, this.Alpha);
	}

	// Token: 0x06000093 RID: 147 RVA: 0x00004E08 File Offset: 0x00003008
	public ColorHsv WithSaturation(float saturation)
	{
		return new ColorHsv(this.Hue, saturation, this.Value, this.Alpha);
	}

	// Token: 0x06000094 RID: 148 RVA: 0x00004E22 File Offset: 0x00003022
	public ColorHsv WithValue(float value)
	{
		return new ColorHsv(this.Hue, this.Saturation, value, this.Alpha);
	}

	// Token: 0x06000095 RID: 149 RVA: 0x00004E3C File Offset: 0x0000303C
	public ColorHsv WithAlpha(float alpha)
	{
		return new ColorHsv(this.Hue, this.Saturation, this.Value, alpha);
	}

	// Token: 0x06000096 RID: 150 RVA: 0x00004E58 File Offset: 0x00003058
	public static implicit operator ColorHsv(Color rgb)
	{
		float h = 0f;
		float min = MathF.Min(MathF.Min(rgb.r, rgb.g), rgb.b);
		float v = MathF.Max(MathF.Max(rgb.r, rgb.g), rgb.b);
		float delta = v - min;
		float s;
		if ((double)v == 0.0)
		{
			s = 0f;
		}
		else
		{
			s = delta / v;
		}
		if (s == 0f)
		{
			h = 0f;
		}
		else
		{
			if (rgb.r == v)
			{
				h = (rgb.g - rgb.b) / delta;
			}
			else if (rgb.g == v)
			{
				h = 2f + (rgb.b - rgb.r) / delta;
			}
			else if (rgb.b == v)
			{
				h = 4f + (rgb.r - rgb.g) / delta;
			}
			h *= 60f;
			if ((double)h < 0.0)
			{
				h += 360f;
			}
		}
		return new ColorHsv(h, s, v, rgb.a);
	}

	// Token: 0x06000097 RID: 151 RVA: 0x00004F60 File Offset: 0x00003160
	public static implicit operator Color(ColorHsv hsv)
	{
		if (hsv.Saturation == 0f)
		{
			return new Color(hsv.Value, hsv.Value, hsv.Value, hsv.Alpha);
		}
		hsv.Hue %= 360f;
		hsv.Hue /= 60f;
		int i = (int)Math.Truncate((double)hsv.Hue);
		float f = hsv.Hue - (float)i;
		float p = hsv.Value * (1f - hsv.Saturation);
		float q = hsv.Value * (1f - hsv.Saturation * f);
		float t = hsv.Value * (1f - hsv.Saturation * (1f - f));
		switch (i)
		{
		case 0:
			return new Color(hsv.Value, t, p, hsv.Alpha);
		case 1:
			return new Color(q, hsv.Value, p, hsv.Alpha);
		case 2:
			return new Color(p, hsv.Value, t, hsv.Alpha);
		case 3:
			return new Color(p, q, hsv.Value, hsv.Alpha);
		case 4:
			return new Color(t, p, hsv.Value, hsv.Alpha);
		default:
			return new Color(hsv.Value, p, q, hsv.Alpha);
		}
	}

	// Token: 0x06000098 RID: 152 RVA: 0x000050CD File Offset: 0x000032CD
	public static bool operator ==(ColorHsv left, ColorHsv right)
	{
		return left.Equals(right);
	}

	// Token: 0x06000099 RID: 153 RVA: 0x000050D7 File Offset: 0x000032D7
	public static bool operator !=(ColorHsv left, ColorHsv right)
	{
		return !(left == right);
	}

	// Token: 0x0600009A RID: 154 RVA: 0x000050E4 File Offset: 0x000032E4
	public override bool Equals(object obj)
	{
		if (obj is ColorHsv)
		{
			ColorHsv o = (ColorHsv)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x0600009B RID: 155 RVA: 0x0000510C File Offset: 0x0000330C
	public bool Equals(ColorHsv o)
	{
		float hue = this.Hue;
		float saturation = this.Saturation;
		float value = this.Value;
		float alpha = this.Alpha;
		float hue2 = o.Hue;
		float saturation2 = o.Saturation;
		float value2 = o.Value;
		float alpha2 = o.Alpha;
		return hue == hue2 && saturation == saturation2 && value == value2 && alpha == alpha2;
	}

	// Token: 0x0600009C RID: 156 RVA: 0x0000516B File Offset: 0x0000336B
	public override int GetHashCode()
	{
		return HashCode.Combine<float, float, float, float>(this.Hue, this.Saturation, this.Value, this.Alpha);
	}
}
