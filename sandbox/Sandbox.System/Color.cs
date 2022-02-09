using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json.Serialization;
using Sandbox;
using Sandbox.Internal.JsonConvert;
using Sandbox.UI;

// Token: 0x02000010 RID: 16
[JsonConverter(typeof(ColorConverter))]
public struct Color : IEquatable<Color>
{
	// Token: 0x06000033 RID: 51 RVA: 0x000022A6 File Offset: 0x000004A6
	public Color(float r, float g, float b, float a = 1f)
	{
		this.r = r;
		this.g = g;
		this.b = b;
		this.a = a;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x000022C9 File Offset: 0x000004C9
	public Color(float all)
	{
		this.r = all;
		this.g = all;
		this.b = all;
		this.a = all;
	}

	// Token: 0x06000035 RID: 53 RVA: 0x000022EC File Offset: 0x000004EC
	public Color(uint rgba)
	{
		this.r = (rgba & 255U) / 255f;
		this.g = ((rgba >> 8) & 255U) / 255f;
		this.b = ((rgba >> 16) & 255U) / 255f;
		this.a = ((rgba >> 24) & 255U) / 255f;
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00002358 File Offset: 0x00000558
	public Color(int rgba)
	{
		this.r = (float)(rgba & 255) / 255f;
		this.g = (float)((rgba >> 8) & 255) / 255f;
		this.b = (float)((rgba >> 16) & 255) / 255f;
		this.a = (float)((rgba >> 24) & 255) / 255f;
	}

	/// <summary>
	/// Returns this colour with its alpha value changed
	/// </summary>
	/// <param name="alpha">The required alpha value, usually between 0-1</param>
	// Token: 0x06000037 RID: 55 RVA: 0x000023BD File Offset: 0x000005BD
	public Color WithAlpha(float alpha)
	{
		return new Color(this.r, this.g, this.b, alpha);
	}

	/// <summary>
	/// Returns this colour with its red value changed
	/// </summary>
	// Token: 0x06000038 RID: 56 RVA: 0x000023D7 File Offset: 0x000005D7
	public Color WithRed(float red)
	{
		return new Color(red, this.g, this.b, this.a);
	}

	/// <summary>
	/// Returns this colour with its green value changed
	/// </summary>
	// Token: 0x06000039 RID: 57 RVA: 0x000023F1 File Offset: 0x000005F1
	public Color WithGreen(float green)
	{
		return new Color(this.r, green, this.b, this.a);
	}

	/// <summary>
	/// Returns this colour with its blue value changed
	/// </summary>
	// Token: 0x0600003A RID: 58 RVA: 0x0000240B File Offset: 0x0000060B
	public Color WithBlue(float blue)
	{
		return new Color(this.r, this.g, blue, this.a);
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00002425 File Offset: 0x00000625
	public ColorHsv ToHsv()
	{
		return this;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00002432 File Offset: 0x00000632
	public ColorXYZ ToXYZ()
	{
		return this;
	}

	/// <summary>
	/// Convert to a Color32 (a 32 bit color value)
	/// </summary>
	/// <param name="srgb">If true we'll convert to  the srgb color space</param>
	// Token: 0x0600003D RID: 61 RVA: 0x00002440 File Offset: 0x00000640
	public Color32 ToColor32(bool srgb = false)
	{
		float FloatR = Math.Clamp(this.r, 0f, 1f);
		float FloatG = Math.Clamp(this.g, 0f, 1f);
		float FloatB = Math.Clamp(this.b, 0f, 1f);
		float FloatA = Math.Clamp(this.a, 0f, 1f);
		if (srgb)
		{
			FloatR = ((FloatR <= 0.0031308f) ? (FloatR * 12.92f) : (MathF.Pow(FloatR, 0.41666666f) * 1.055f - 0.055f));
			FloatG = ((FloatG <= 0.0031308f) ? (FloatG * 12.92f) : (MathF.Pow(FloatG, 0.41666666f) * 1.055f - 0.055f));
			FloatB = ((FloatB <= 0.0031308f) ? (FloatB * 12.92f) : (MathF.Pow(FloatB, 0.41666666f) * 1.055f - 0.055f));
		}
		return new Color32
		{
			R = (byte)(FloatR * 255.999f).FloorToInt(),
			G = (byte)(FloatG * 255.999f).FloorToInt(),
			B = (byte)(FloatB * 255.999f).FloorToInt(),
			A = (byte)(FloatA * 255.999f).FloorToInt()
		};
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00002580 File Offset: 0x00000780
	public static Color Min(Color a, Color b)
	{
		return new Color(Math.Min(a.r, b.r), Math.Min(a.g, b.g), Math.Min(a.b, b.b), Math.Min(a.a, b.a));
	}

	// Token: 0x0600003F RID: 63 RVA: 0x000025D8 File Offset: 0x000007D8
	public static Color Max(Color a, Color b)
	{
		return new Color(Math.Max(a.r, b.r), Math.Max(a.g, b.g), Math.Max(a.b, b.b), Math.Max(a.a, b.a));
	}

	// Token: 0x17000019 RID: 25
	// (get) Token: 0x06000040 RID: 64 RVA: 0x0000262E File Offset: 0x0000082E
	[JsonIgnore]
	public float Luminance
	{
		get
		{
			return 0.3f * this.r + 0.59f * this.g + 0.11f * this.b;
		}
	}

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x06000041 RID: 65 RVA: 0x00002658 File Offset: 0x00000858
	[JsonIgnore]
	public uint RGBA
	{
		get
		{
			uint num = (uint)((double)this.r * 255.0) & 255U;
			uint g = (uint)((double)this.g * 255.0) & 255U;
			uint b = (uint)((double)this.b * 255.0) & 255U;
			uint a = (uint)((double)this.a * 255.0) & 255U;
			return num | (g << 8) | (b << 16) | (a << 24);
		}
	}

	// Token: 0x06000042 RID: 66 RVA: 0x000026D8 File Offset: 0x000008D8
	public override string ToString()
	{
		return string.Format("R:{0:0.00},G:{1:0.00},B:{2:0.00},A:{3:0.00}", new object[] { this.r, this.g, this.b, this.a });
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x06000043 RID: 67 RVA: 0x00002730 File Offset: 0x00000930
	public bool IsRepresentableInHex
	{
		get
		{
			return this.r >= 0f && this.r <= 1f && this.g >= 0f && this.g <= 1f && this.b >= 0f && this.b <= 1f;
		}
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00002790 File Offset: 0x00000990
	public string ToString(bool hex, bool rgba)
	{
		if (this.IsRepresentableInHex && hex)
		{
			return this.Hex;
		}
		if (rgba)
		{
			return this.Rgba;
		}
		return this.ToString();
	}

	// Token: 0x06000045 RID: 69 RVA: 0x000027B9 File Offset: 0x000009B9
	public static Color operator *(Color c1, float f)
	{
		return new Color(c1.r * f, c1.g * f, c1.b * f, c1.a * f);
	}

	// Token: 0x06000046 RID: 70 RVA: 0x000027E0 File Offset: 0x000009E0
	public static Color operator +(Color c1, Color c2)
	{
		return new Color(c1.r + c2.r, c1.g + c2.g, c1.b + c2.b, c1.a + c2.a);
	}

	// Token: 0x06000047 RID: 71 RVA: 0x0000281B File Offset: 0x00000A1B
	public static Color operator -(Color c1, Color c2)
	{
		return new Color(c1.r - c2.r, c1.g - c2.g, c1.b - c2.b, c1.a - c2.a);
	}

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x06000048 RID: 72 RVA: 0x00002858 File Offset: 0x00000A58
	[JsonIgnore]
	public string Hex
	{
		get
		{
			return string.Format("#{0}{1}{2}{3}", new object[]
			{
				((byte)((double)this.r * 255.0)).ToString("X2"),
				((byte)((double)this.g * 255.0)).ToString("X2"),
				((byte)((double)this.b * 255.0)).ToString("X2"),
				((byte)((double)this.a * 255.0)).ToString("X2")
			});
		}
	}

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000049 RID: 73 RVA: 0x00002900 File Offset: 0x00000B00
	[JsonIgnore]
	public string Rgba
	{
		get
		{
			return string.Format("rgba( {0}, {1}, {2}, {3} )", new object[]
			{
				(double)this.r * 255.0,
				(double)this.g * 255.0,
				(double)this.b * 255.0,
				this.a
			});
		}
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00002976 File Offset: 0x00000B76
	public static implicit operator Color(Vector4 value)
	{
		return new Color(value.x, value.y, value.z, value.w);
	}

	// Token: 0x0600004B RID: 75 RVA: 0x0000299D File Offset: 0x00000B9D
	public static implicit operator Color(Vector3 value)
	{
		return new Color(value.x, value.y, value.z, 1f);
	}

	// Token: 0x0600004C RID: 76 RVA: 0x000029C0 File Offset: 0x00000BC0
	public static implicit operator Color(string value)
	{
		Color? color = Color.Parse(value);
		if (color == null)
		{
			return new Color(1f, 0f, 1f, 1f);
		}
		return color.GetValueOrDefault();
	}

	// Token: 0x1700001E RID: 30
	[JsonIgnore]
	public float this[int index]
	{
		get
		{
			switch (index)
			{
			case 0:
				return this.r;
			case 1:
				return this.g;
			case 2:
				return this.b;
			case 3:
				return this.a;
			default:
				throw new IndexOutOfRangeException();
			}
		}
		set
		{
			switch (index)
			{
			case 0:
				this.r = value;
				return;
			case 1:
				this.g = value;
				return;
			case 2:
				this.b = value;
				return;
			case 3:
				this.a = value;
				return;
			default:
				throw new IndexOutOfRangeException();
			}
		}
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00002A78 File Offset: 0x00000C78
	public static Color Average(Color[] values)
	{
		float r = 0f;
		float g = 0f;
		float b = 0f;
		float a = 0f;
		foreach (Color v in values)
		{
			r += v.r;
			g += v.g;
			b += v.b;
			a += v.a;
		}
		int count = values.Length;
		return new Color(r / (float)count, g / (float)count, b / (float)count, a / (float)count);
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x06000050 RID: 80 RVA: 0x00002B04 File Offset: 0x00000D04
	public static Color Random
	{
		get
		{
			switch (Rand.Int(6))
			{
			case 0:
				return Color.White;
			case 1:
				return Color.Red;
			case 2:
				return Color.Green;
			case 3:
				return Color.Blue;
			case 4:
				return Color.Yellow;
			case 5:
				return Color.Cyan;
			case 6:
				return Color.Magenta;
			default:
				return Color.Black;
			}
		}
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00002B6C File Offset: 0x00000D6C
	public static Color Lerp(Color a, Color b, float delta, bool clamped = true)
	{
		if (clamped && delta < 0f)
		{
			return a;
		}
		if (clamped && delta > 1f)
		{
			return b;
		}
		return new Color(a.r.LerpTo(b.r, delta, clamped), a.g.LerpTo(b.g, delta, clamped), a.b.LerpTo(b.b, delta, clamped), a.a.LerpTo(b.a, delta, clamped));
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00002BE4 File Offset: 0x00000DE4
	public static Color FromBytes(int r, int g, int b, int a = 255)
	{
		return new Color((float)r / 255f, (float)g / 255f, (float)b / 255f, (float)a / 255f);
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00002C0C File Offset: 0x00000E0C
	public static Color? Parse(string value)
	{
		Parse p = new Parse(value, "nofile");
		return Color.Parse(ref p, false);
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00002C30 File Offset: 0x00000E30
	internal static Color? Parse(ref Parse p, bool isColorFunction = false)
	{
		p = p.SkipWhitespaceAndNewlines(null);
		if (p.Current == '#')
		{
			Parse restoreP = p;
			p.Pointer++;
			string hex = p.ReadUntilOrEnd(" ", true);
			if (hex == null)
			{
				return null;
			}
			if (hex.Length == 3)
			{
				string r = hex.Substring(0, 1);
				string g = hex.Substring(1, 1);
				string b = hex.Substring(2, 1);
				hex = string.Concat(new string[] { r, r, g, g, b, b, "FF" });
			}
			if (hex.Length == 4)
			{
				string r2 = hex.Substring(0, 1);
				string g2 = hex.Substring(1, 1);
				string b2 = hex.Substring(2, 1);
				string a = hex.Substring(3, 1);
				hex = string.Concat(new string[] { r2, r2, g2, g2, b2, b2, a, a });
			}
			if (hex.Length == 6)
			{
				hex += "FF";
			}
			int color32;
			if (hex.Length == 8 && int.TryParse(hex, NumberStyles.HexNumber, null, out color32))
			{
				int num = (int)((byte)((color32 >> 24) & 255));
				byte G = (byte)((color32 >> 16) & 255);
				byte B = (byte)((color32 >> 8) & 255);
				byte A = (byte)(color32 & 255);
				return new Color?(Color.FromBytes(num, (int)G, (int)B, (int)A));
			}
			p = restoreP;
		}
		if (p.Is("rgb", 0, false))
		{
			Parse restoreP2 = p;
			p.Pointer += 3;
			if (p.Current == 'a')
			{
				p.Pointer++;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return null;
			}
			if (p.Current == '(' || isColorFunction)
			{
				if (!isColorFunction)
				{
					p.Pointer++;
				}
				float r3 = 0f;
				float g3 = 0f;
				float b3 = 0f;
				float alpha = 1f;
				p = p.SkipWhitespaceAndNewlines(null);
				if (p.IsEnd)
				{
					return null;
				}
				if (p.IsDigit)
				{
					if (!p.TryReadFloat(out r3))
					{
						return null;
					}
					if (p.Current == '%')
					{
						r3 = r3 / 100f * 255f;
						p.Pointer++;
					}
					p = p.SkipWhitespaceAndNewlines(",");
					if (!p.TryReadFloat(out g3))
					{
						return null;
					}
					if (p.Current == '%')
					{
						g3 = g3 / 100f * 255f;
						p.Pointer++;
					}
					p = p.SkipWhitespaceAndNewlines(",");
					if (!p.TryReadFloat(out b3))
					{
						return null;
					}
					if (p.Current == '%')
					{
						b3 = b3 / 100f * 255f;
						p.Pointer++;
					}
					p = p.SkipWhitespaceAndNewlines(",/");
					r3 /= 255f;
					g3 /= 255f;
					b3 /= 255f;
				}
				else
				{
					Color rgb;
					if (!p.TryReadColor(out rgb))
					{
						return null;
					}
					r3 = rgb.r;
					g3 = rgb.g;
					b3 = rgb.b;
					alpha = rgb.a;
					p = p.SkipWhitespaceAndNewlines(",/");
				}
				float _alpha;
				if (p.TryReadFloat(out _alpha))
				{
					if (p.Current == '%')
					{
						alpha = _alpha / 100f;
						p.Pointer++;
					}
					else
					{
						alpha = _alpha;
					}
					p = p.SkipWhitespaceAndNewlines(null);
				}
				if (p.Is(')', 0, false))
				{
					p.Pointer++;
					return new Color?(new Color(r3, g3, b3, alpha));
				}
			}
			p = restoreP2;
		}
		if (p.Is("hsl", 0, false))
		{
			Parse restoreP3 = p;
			p.Pointer += 3;
			if (p.Current == 'a')
			{
				p.Pointer++;
			}
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return null;
			}
			if (p.Current == '(' || isColorFunction)
			{
				if (!isColorFunction)
				{
					p.Pointer++;
				}
				float h = 0f;
				float s = 0f;
				float i = 0f;
				float a2 = 1f;
				if (!p.IsDigit)
				{
					return null;
				}
				if (!p.TryReadFloat(out h))
				{
					return null;
				}
				if (p.IsLetter)
				{
					h = StyleHelpers.RotationDegrees(h, p.ReadUntilWhitespaceOrNewlineOrEnd(","));
				}
				p = p.SkipWhitespaceAndNewlines(",");
				if (!p.TryReadFloat(out s))
				{
					return null;
				}
				p = p.SkipWhitespaceAndNewlines(",%");
				if (!p.TryReadFloat(out i))
				{
					return null;
				}
				p = p.SkipWhitespaceAndNewlines(",%");
				h %= 360f;
				s /= 100f;
				i /= 100f;
				p = p.SkipWhitespaceAndNewlines("/");
				if (p.TryReadFloat(out a2))
				{
					if (p.Current == '%')
					{
						a2 /= 100f;
						p.Pointer++;
					}
				}
				else
				{
					a2 = 1f;
				}
				if (p.Current != ')')
				{
					return null;
				}
				p.Pointer++;
				if (i < 0.5f)
				{
					s *= i;
				}
				else
				{
					s *= 1f - i;
				}
				return new Color?(new ColorHsv(h, 2f * s / (i + s), i + s, a2));
			}
			else
			{
				p = restoreP3;
			}
		}
		if (p.Is("lab", 0, false))
		{
			Parse restoreP4 = p;
			p.Pointer += 3;
			p = p.SkipWhitespaceAndNewlines(null);
			if (p.IsEnd)
			{
				return null;
			}
			if (p.Current == '(' || isColorFunction)
			{
				if (!isColorFunction)
				{
					p.Pointer++;
				}
				float alpha2 = 1f;
				float j;
				if (!p.TryReadFloat(out j))
				{
					return null;
				}
				if (p.Current != '%')
				{
					return null;
				}
				p = p.SkipWhitespaceAndNewlines(",%");
				j /= 100f;
				float a3;
				if (!p.TryReadFloat(out a3))
				{
					return null;
				}
				p = p.SkipWhitespaceAndNewlines(",");
				float b4;
				if (!p.TryReadFloat(out b4))
				{
					return null;
				}
				p = p.SkipWhitespaceAndNewlines(",/");
				float _alpha2;
				if (p.TryReadFloat(out _alpha2))
				{
					alpha2 = _alpha2;
					if (p.Current == '%')
					{
						alpha2 /= 100f;
						p.Pointer++;
					}
				}
				p = p.SkipWhitespaceAndNewlines(null);
				if (p.Current != ')')
				{
					return null;
				}
				p.Pointer++;
				return new Color?(ColorXYZ.FromLab(new Color(j, a3, b4, alpha2), true));
			}
			else
			{
				p = restoreP4;
			}
		}
		if (isColorFunction)
		{
			Parse restoreP5 = p;
			Color.ColorSpace colorSpace = Color.ColorSpace.Unknown;
			if (p.Is("a98-rgb", 0, false))
			{
				p.Pointer += 7;
				colorSpace = Color.ColorSpace.A98;
			}
			else if (p.Is("lab", 0, false))
			{
				p.Pointer += 3;
				colorSpace = Color.ColorSpace.Lab;
			}
			else if (p.Is("xyz-d50", 0, false))
			{
				p.Pointer += 7;
				colorSpace = Color.ColorSpace.XYZD50;
			}
			else if (p.Is("xyz-d65", 0, false))
			{
				p.Pointer += 7;
				colorSpace = Color.ColorSpace.XYZD65;
			}
			if (colorSpace != Color.ColorSpace.Unknown)
			{
				p = p.SkipWhitespaceAndNewlines(null);
				if (p.IsEnd)
				{
					return null;
				}
				float alpha3 = 1f;
				float r4;
				if (!p.TryReadFloat(out r4))
				{
					return null;
				}
				p = p.SkipWhitespaceAndNewlines(",");
				float g4;
				if (!p.TryReadFloat(out g4))
				{
					return null;
				}
				p = p.SkipWhitespaceAndNewlines(",");
				float b5;
				if (!p.TryReadFloat(out b5))
				{
					return null;
				}
				p = p.SkipWhitespaceAndNewlines(",/");
				float _alpha3;
				if (p.TryReadFloat(out _alpha3))
				{
					alpha3 = _alpha3;
				}
				Color curColor = new Color(r4, g4, b5, alpha3);
				switch (colorSpace)
				{
				case Color.ColorSpace.A98:
					return new Color?(ColorXYZ.FromA98(curColor));
				case Color.ColorSpace.Lab:
					return new Color?(ColorXYZ.FromLab(curColor, true));
				case Color.ColorSpace.XYZD50:
					return new Color?(new ColorXYZ(curColor.r, curColor.g, curColor.b, curColor.a).ToD65());
				case Color.ColorSpace.XYZD65:
					return new Color?(ColorXYZ.FromLab(curColor, true).ToD65());
				default:
					return null;
				}
			}
			else
			{
				p = restoreP5;
			}
		}
		if (p.IsDigit)
		{
			Parse restoreP6 = p;
			string s2 = p.ReadUntilOrEnd(" ", true);
			p = p.SkipWhitespaceAndNewlines(null);
			string g5 = p.ReadUntilOrEnd(" ", true);
			p = p.SkipWhitespaceAndNewlines(null);
			string b6 = p.ReadUntilOrEnd(" ", true);
			p = p.SkipWhitespaceAndNewlines(null);
			string a4 = "255";
			if (p.IsDigit)
			{
				a4 = p.ReadUntilOrEnd(" ", true);
				p = p.SkipWhitespaceAndNewlines(null);
			}
			int rValue;
			int gValue;
			int bValue;
			int aValue;
			if (int.TryParse(s2, NumberStyles.None, CultureInfo.InvariantCulture, out rValue) && int.TryParse(g5, NumberStyles.None, CultureInfo.InvariantCulture, out gValue) && int.TryParse(b6, NumberStyles.None, CultureInfo.InvariantCulture, out bValue) && int.TryParse(a4, NumberStyles.None, CultureInfo.InvariantCulture, out aValue))
			{
				return new Color?(Color.FromBytes(rValue, gValue, bValue, aValue));
			}
			p = restoreP6;
		}
		if (p.TrySkip("darken(", 0, false))
		{
			Color c;
			p.TryReadColor(out c);
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(",", 0, false))
			{
				return null;
			}
			p.SkipWhitespaceAndNewlines(null);
			Length len;
			if (!p.TryReadLength(out len))
			{
				return null;
			}
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(")", 0, false))
			{
				return null;
			}
			return new Color?(c.Darken(len.GetFraction(1f)));
		}
		else if (p.TrySkip("lighten(", 0, false))
		{
			Color c2;
			p.TryReadColor(out c2);
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(",", 0, false))
			{
				return null;
			}
			p.SkipWhitespaceAndNewlines(null);
			Length len2;
			if (!p.TryReadLength(out len2))
			{
				return null;
			}
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(")", 0, false))
			{
				return null;
			}
			return new Color?(c2.Lighten(len2.GetFraction(1f)));
		}
		else if (p.TrySkip("invert(", 0, false))
		{
			Color c3;
			p.TryReadColor(out c3);
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(")", 0, false))
			{
				return null;
			}
			return new Color?(c3.Invert());
		}
		else if (p.TrySkip("mix(", 0, false) || p.TrySkip("lerp(", 0, false))
		{
			Color a5;
			p.TryReadColor(out a5);
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(",", 0, false))
			{
				return null;
			}
			Color b7;
			p.TryReadColor(out b7);
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(",", 0, false))
			{
				return null;
			}
			p.SkipWhitespaceAndNewlines(null);
			Length len3;
			if (!p.TryReadLength(out len3))
			{
				return null;
			}
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(")", 0, false))
			{
				return null;
			}
			return new Color?(Color.Lerp(a5, b7, len3.GetFraction(1f), true));
		}
		else if (p.TrySkip("desaturate(", 0, false))
		{
			Color c4;
			p.TryReadColor(out c4);
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(",", 0, false))
			{
				return null;
			}
			p.SkipWhitespaceAndNewlines(null);
			Length len4;
			if (!p.TryReadLength(out len4))
			{
				return null;
			}
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(")", 0, false))
			{
				return null;
			}
			return new Color?(c4.Desaturate(len4.GetFraction(1f)));
		}
		else if (p.TrySkip("saturate(", 0, false))
		{
			Color c5;
			p.TryReadColor(out c5);
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(",", 0, false))
			{
				return null;
			}
			p.SkipWhitespaceAndNewlines(null);
			Length len5;
			if (!p.TryReadLength(out len5))
			{
				return null;
			}
			p.SkipWhitespaceAndNewlines(null);
			if (!p.TrySkip(")", 0, false))
			{
				return null;
			}
			return new Color?(c5.Saturate(len5.GetFraction(1f)));
		}
		else
		{
			if (p.TrySkip("color(", 0, false))
			{
				return Color.Parse(ref p, true);
			}
			if (p.IsLetter)
			{
				Parse restoreP7 = p;
				string color33 = p.ReadWord(",)", true);
				string colorValue;
				if (color33 != null && Color.WebColours.TryGetValue(color33, out colorValue))
				{
					return Color.Parse(colorValue);
				}
				p = restoreP7;
			}
			return null;
		}
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00003A31 File Offset: 0x00001C31
	public void Write(BinaryWriter writer)
	{
		writer.Write(this.r);
		writer.Write(this.g);
		writer.Write(this.b);
		writer.Write(this.a);
	}

	// Token: 0x06000056 RID: 86 RVA: 0x00003A63 File Offset: 0x00001C63
	public static Color Read(BinaryReader reader)
	{
		return new Color(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00003A84 File Offset: 0x00001C84
	public readonly Color Darken(float fraction)
	{
		Color c = this;
		c.r *= 1f - fraction;
		c.g *= 1f - fraction;
		c.b *= 1f - fraction;
		return c;
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00003AD0 File Offset: 0x00001CD0
	public readonly Color Lighten(float fraction)
	{
		Color c = this;
		c.r *= 1f + fraction;
		c.g *= 1f + fraction;
		c.b *= 1f + fraction;
		return c;
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00003B1C File Offset: 0x00001D1C
	public readonly Color Invert()
	{
		Color c = this;
		c.r = 1f - c.r;
		c.g = 1f - c.g;
		c.b = 1f - c.b;
		return c;
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00003B6C File Offset: 0x00001D6C
	public readonly Color Desaturate(float fraction)
	{
		ColorHsv c = this;
		c.Saturation *= 1f - fraction;
		return c;
	}

	// Token: 0x0600005B RID: 91 RVA: 0x00003BA0 File Offset: 0x00001DA0
	public readonly Color Saturate(float fraction)
	{
		ColorHsv c = this;
		c.Saturation *= 1f + fraction;
		return c;
	}

	/// <summary>
	/// Returns how many color components would be changed between this color and another color
	/// </summary>
	// Token: 0x0600005C RID: 92 RVA: 0x00003BD4 File Offset: 0x00001DD4
	public int ComponentCountChangedBetweenColors(Color b)
	{
		int componentsChanged = 0;
		Color colorDifference = this - b;
		for (int i = 0; i < 3; i++)
		{
			componentsChanged += ((colorDifference[i] != 0f) ? 1 : 0);
		}
		return componentsChanged;
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00003C13 File Offset: 0x00001E13
	public static bool operator ==(Color left, Color right)
	{
		return left.Equals(right);
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00003C1D File Offset: 0x00001E1D
	public static bool operator !=(Color left, Color right)
	{
		return !(left == right);
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00003C2C File Offset: 0x00001E2C
	public override bool Equals(object obj)
	{
		if (obj is Color)
		{
			Color o = (Color)obj;
			return this.Equals(o);
		}
		return false;
	}

	// Token: 0x06000060 RID: 96 RVA: 0x00003C54 File Offset: 0x00001E54
	public bool Equals(Color o)
	{
		float num = this.r;
		float num2 = this.g;
		float num3 = this.b;
		float num4 = this.a;
		float num5 = o.r;
		float num6 = o.g;
		float num7 = o.b;
		float num8 = o.a;
		return num == num5 && num2 == num6 && num3 == num7 && num4 == num8;
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00003CAF File Offset: 0x00001EAF
	public override int GetHashCode()
	{
		return HashCode.Combine<float, float, float, float>(this.r, this.g, this.b, this.a);
	}

	// Token: 0x04000008 RID: 8
	public float r;

	// Token: 0x04000009 RID: 9
	public float g;

	// Token: 0x0400000A RID: 10
	public float b;

	// Token: 0x0400000B RID: 11
	public float a;

	// Token: 0x0400000C RID: 12
	public static readonly Color White = new Color(1f, 1f, 1f, 1f);

	// Token: 0x0400000D RID: 13
	public static readonly Color Gray = new Color(0.5f, 0.5f, 0.5f, 1f);

	// Token: 0x0400000E RID: 14
	public static readonly Color Black = new Color(0f, 0f, 0f, 1f);

	// Token: 0x0400000F RID: 15
	public static readonly Color Red = new Color(1f, 0f, 0f, 1f);

	// Token: 0x04000010 RID: 16
	public static readonly Color Green = new Color(0f, 1f, 0f, 1f);

	// Token: 0x04000011 RID: 17
	public static readonly Color Blue = new Color(0f, 0f, 1f, 1f);

	// Token: 0x04000012 RID: 18
	public static readonly Color Yellow = new Color(1f, 1f, 0f, 1f);

	// Token: 0x04000013 RID: 19
	public static readonly Color Orange = new Color(1f, 0.6f, 0f, 1f);

	// Token: 0x04000014 RID: 20
	public static readonly Color Cyan = new Color(0f, 1f, 1f, 1f);

	// Token: 0x04000015 RID: 21
	public static readonly Color Magenta = new Color(1f, 0f, 1f, 1f);

	// Token: 0x04000016 RID: 22
	public static readonly Color Transparent = new Color(0f, 0f, 0f, 0f);

	// Token: 0x04000017 RID: 23
	private static Dictionary<string, string> WebColours = new Dictionary<string, string>
	{
		{ "aliceblue", "#F0F8FF" },
		{ "antiquewhite", "#FAEBD7" },
		{ "aqua", "#00FFFF" },
		{ "aquamarine", "#7FFFD4" },
		{ "azure", "#F0FFFF" },
		{ "beige", "#F5F5DC" },
		{ "bisque", "#FFE4C4" },
		{ "black", "#000000" },
		{ "blanchedalmond", "#FFEBCD" },
		{ "blue", "#0000FF" },
		{ "blueviolet", "#8A2BE2" },
		{ "brown", "#A52A2A" },
		{ "burlywood", "#DEB887" },
		{ "cadetblue", "#5F9EA0" },
		{ "chartreuse", "#7FFF00" },
		{ "chocolate", "#D2691E" },
		{ "coral", "#FF7F50" },
		{ "cornflowerblue", "#6495ED" },
		{ "cornsilk", "#FFF8DC" },
		{ "crimson", "#DC143C" },
		{ "cyan", "#00FFFF" },
		{ "darkblue", "#00008B" },
		{ "darkcyan", "#008B8B" },
		{ "darkgoldenrod", "#B8860B" },
		{ "darkgray", "#A9A9A9" },
		{ "darkgreen", "#006400" },
		{ "darkgrey", "#A9A9A9" },
		{ "darkkhaki", "#BDB76B" },
		{ "darkmagenta", "#8B008B" },
		{ "darkolivegreen", "#556B2F" },
		{ "darkorange", "#FF8C00" },
		{ "darkorchid", "#9932CC" },
		{ "darkred", "#8B0000" },
		{ "darksalmon", "#E9967A" },
		{ "darkseagreen", "#8FBC8F" },
		{ "darkslateblue", "#483D8B" },
		{ "darkslategray", "#2F4F4F" },
		{ "darkslategrey", "#2F4F4F" },
		{ "darkturquoise", "#00CED1" },
		{ "darkviolet", "#9400D3" },
		{ "deeppink", "#FF1493" },
		{ "deepskyblue", "#00BFFF" },
		{ "dimgray", "#696969" },
		{ "dimgrey", "#696969" },
		{ "dodgerblue", "#1E90FF" },
		{ "firebrick", "#B22222" },
		{ "floralwhite", "#FFFAF0" },
		{ "forestgreen", "#228B22" },
		{ "fuchsia", "#FF00FF" },
		{ "gainsboro", "#DCDCDC" },
		{ "ghostwhite", "#F8F8FF" },
		{ "gold", "#FFD700" },
		{ "goldenrod", "#DAA520" },
		{ "gray", "#808080" },
		{ "green", "#008000" },
		{ "greenyellow", "#ADFF2F" },
		{ "grey", "#808080" },
		{ "honeydew", "#F0FFF0" },
		{ "hotpink", "#FF69B4" },
		{ "indianred", "#CD5C5C" },
		{ "indigo", "#4B0082" },
		{ "ivory", "#FFFFF0" },
		{ "khaki", "#F0E68C" },
		{ "lavender", "#E6E6FA" },
		{ "lavenderblush", "#FFF0F5" },
		{ "lawngreen", "#7CFC00" },
		{ "lemonchiffon", "#FFFACD" },
		{ "lightblue", "#ADD8E6" },
		{ "lightcoral", "#F08080" },
		{ "lightcyan", "#E0FFFF" },
		{ "lightgoldenrodyellow", "#FAFAD2" },
		{ "lightgray", "#D3D3D3" },
		{ "lightgreen", "#90EE90" },
		{ "lightgrey", "#D3D3D3" },
		{ "lightpink", "#FFB6C1" },
		{ "lightsalmon", "#FFA07A" },
		{ "lightseagreen", "#20B2AA" },
		{ "lightskyblue", "#87CEFA" },
		{ "lightslategray", "#778899" },
		{ "lightslategrey", "#778899" },
		{ "lightsteelblue", "#B0C4DE" },
		{ "lightyellow", "#FFFFE0" },
		{ "lime", "#00FF00" },
		{ "limegreen", "#32CD32" },
		{ "linen", "#FAF0E6" },
		{ "magenta", "#FF00FF" },
		{ "maroon", "#800000" },
		{ "mediumaquamarine", "#66CDAA" },
		{ "mediumblue", "#0000CD" },
		{ "mediumorchid", "#BA55D3" },
		{ "mediumpurple", "#9370DB" },
		{ "mediumseagreen", "#3CB371" },
		{ "mediumslateblue", "#7B68EE" },
		{ "mediumspringgreen", "#00FA9A" },
		{ "mediumturquoise", "#48D1CC" },
		{ "mediumvioletred", "#C71585" },
		{ "midnightblue", "#191970" },
		{ "mintcream", "#F5FFFA" },
		{ "mistyrose", "#FFE4E1" },
		{ "moccasin", "#FFE4B5" },
		{ "navajowhite", "#FFDEAD" },
		{ "navy", "#000080" },
		{ "oldlace", "#FDF5E6" },
		{ "olive", "#808000" },
		{ "olivedrab", "#6B8E23" },
		{ "orange", "#FFA500" },
		{ "orangered", "#FF4500" },
		{ "orchid", "#DA70D6" },
		{ "palegoldenrod", "#EEE8AA" },
		{ "palegreen", "#98FB98" },
		{ "paleturquoise", "#AFEEEE" },
		{ "palevioletred", "#DB7093" },
		{ "papayawhip", "#FFEFD5" },
		{ "peachpuff", "#FFDAB9" },
		{ "peru", "#CD853F" },
		{ "pink", "#FFC0CB" },
		{ "plum", "#DDA0DD" },
		{ "powderblue", "#B0E0E6" },
		{ "purple", "#800080" },
		{ "rebeccapurple", "#663399" },
		{ "red", "#FF0000" },
		{ "rosybrown", "#BC8F8F" },
		{ "royalblue", "#4169E1" },
		{ "saddlebrown", "#8B4513" },
		{ "salmon", "#FA8072" },
		{ "sandybrown", "#F4A460" },
		{ "seagreen", "#2E8B57" },
		{ "seashell", "#FFF5EE" },
		{ "sienna", "#A0522D" },
		{ "silver", "#C0C0C0" },
		{ "skyblue", "#87CEEB" },
		{ "slateblue", "#6A5ACD" },
		{ "slategray", "#708090" },
		{ "slategrey", "#708090" },
		{ "snow", "#FFFAFA" },
		{ "springgreen", "#00FF7F" },
		{ "steelblue", "#4682B4" },
		{ "tan", "#D2B48C" },
		{ "teal", "#008080" },
		{ "thistle", "#D8BFD8" },
		{ "tomato", "#FF6347" },
		{ "transparent", "#AAAAAA00" },
		{ "turquoise", "#40E0D0" },
		{ "violet", "#EE82EE" },
		{ "wheat", "#F5DEB3" },
		{ "white", "#FFFFFF" },
		{ "whitesmoke", "#F5F5F5" },
		{ "yellow", "#FFFF00" },
		{ "yellowgreen", "#9ACD32" }
	};

	// Token: 0x02000077 RID: 119
	private enum ColorSpace
	{
		// Token: 0x04000942 RID: 2370
		Unknown,
		// Token: 0x04000943 RID: 2371
		A98,
		// Token: 0x04000944 RID: 2372
		Lab,
		// Token: 0x04000945 RID: 2373
		XYZD50,
		// Token: 0x04000946 RID: 2374
		XYZD65
	}
}
