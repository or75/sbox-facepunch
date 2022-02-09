using System;
using System.IO;

/// <summary>
/// A 32bit color, commonly used by things like vertex buffers.
///
/// The functionality on this is purposely left minimal so we're encouraged to use the regular Color struct.
/// </summary>
// Token: 0x02000012 RID: 18
public struct Color32 : IEquatable<Color32>
{
	// Token: 0x17000020 RID: 32
	// (get) Token: 0x06000063 RID: 99 RVA: 0x00004781 File Offset: 0x00002981
	// (set) Token: 0x06000064 RID: 100 RVA: 0x00004789 File Offset: 0x00002989
	public byte r
	{
		get
		{
			return this._r;
		}
		set
		{
			this._r = value;
		}
	}

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x06000065 RID: 101 RVA: 0x00004792 File Offset: 0x00002992
	// (set) Token: 0x06000066 RID: 102 RVA: 0x0000479A File Offset: 0x0000299A
	public byte g
	{
		get
		{
			return this._g;
		}
		set
		{
			this._g = value;
		}
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x06000067 RID: 103 RVA: 0x000047A3 File Offset: 0x000029A3
	// (set) Token: 0x06000068 RID: 104 RVA: 0x000047AB File Offset: 0x000029AB
	public byte b
	{
		get
		{
			return this._b;
		}
		set
		{
			this._b = value;
		}
	}

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x06000069 RID: 105 RVA: 0x000047B4 File Offset: 0x000029B4
	// (set) Token: 0x0600006A RID: 106 RVA: 0x000047BC File Offset: 0x000029BC
	public byte a
	{
		get
		{
			return this._a;
		}
		set
		{
			this._a = value;
		}
	}

	// Token: 0x17000024 RID: 36
	// (get) Token: 0x0600006B RID: 107 RVA: 0x000047C5 File Offset: 0x000029C5
	// (set) Token: 0x0600006C RID: 108 RVA: 0x000047CD File Offset: 0x000029CD
	public byte R
	{
		get
		{
			return this._r;
		}
		set
		{
			this._r = value;
		}
	}

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x0600006D RID: 109 RVA: 0x000047D6 File Offset: 0x000029D6
	// (set) Token: 0x0600006E RID: 110 RVA: 0x000047DE File Offset: 0x000029DE
	public byte G
	{
		get
		{
			return this._g;
		}
		set
		{
			this._g = value;
		}
	}

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x0600006F RID: 111 RVA: 0x000047E7 File Offset: 0x000029E7
	// (set) Token: 0x06000070 RID: 112 RVA: 0x000047EF File Offset: 0x000029EF
	public byte B
	{
		get
		{
			return this._b;
		}
		set
		{
			this._b = value;
		}
	}

	// Token: 0x17000027 RID: 39
	// (get) Token: 0x06000071 RID: 113 RVA: 0x000047F8 File Offset: 0x000029F8
	// (set) Token: 0x06000072 RID: 114 RVA: 0x00004800 File Offset: 0x00002A00
	public byte A
	{
		get
		{
			return this._a;
		}
		set
		{
			this._a = value;
		}
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00004809 File Offset: 0x00002A09
	public Color32(byte r, byte g, byte b, byte a = 255)
	{
		this._r = r;
		this._g = g;
		this._b = b;
		this._a = a;
	}

	// Token: 0x06000074 RID: 116 RVA: 0x00004828 File Offset: 0x00002A28
	public Color32(byte all)
	{
		this._r = all;
		this._g = all;
		this._b = all;
		this._a = all;
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00004848 File Offset: 0x00002A48
	public Color32(uint rgba)
	{
		this._r = (byte)(rgba & 255U);
		this._g = (byte)((rgba >> 8) & 255U);
		this._b = (byte)((rgba >> 16) & 255U);
		this._a = (byte)((rgba >> 24) & 255U);
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00004898 File Offset: 0x00002A98
	public Color32(int rgba)
	{
		this._r = (byte)(rgba & 255);
		this._g = (byte)((rgba >> 8) & 255);
		this._b = (byte)((rgba >> 16) & 255);
		this._a = (byte)((rgba >> 24) & 255);
	}

	// Token: 0x06000077 RID: 119 RVA: 0x000048E5 File Offset: 0x00002AE5
	public static implicit operator Color32(Color value)
	{
		return value.ToColor32(false);
	}

	// Token: 0x06000078 RID: 120 RVA: 0x000048EF File Offset: 0x00002AEF
	public Color ToColor()
	{
		return new Color((float)this.r / 255f, (float)this.g / 255f, (float)this.b / 255f, (float)this.a / 255f);
	}

	// Token: 0x06000079 RID: 121 RVA: 0x0000492C File Offset: 0x00002B2C
	public static Color32 Min(Color32 a, Color32 b)
	{
		return new Color32(Math.Min(a.r, b.r), Math.Min(a.g, b.g), Math.Min(a.b, b.b), Math.Min(a.a, b.a));
	}

	// Token: 0x0600007A RID: 122 RVA: 0x0000498C File Offset: 0x00002B8C
	public static Color32 Max(Color32 a, Color32 b)
	{
		return new Color32(Math.Max(a.r, b.r), Math.Max(a.g, b.g), Math.Max(a.b, b.b), Math.Max(a.a, b.a));
	}

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x0600007B RID: 123 RVA: 0x000049EC File Offset: 0x00002BEC
	public uint RGBA
	{
		get
		{
			uint num = (uint)(this._r & byte.MaxValue);
			uint g = (uint)(this._g & byte.MaxValue);
			uint b = (uint)(this._b & byte.MaxValue);
			uint a = (uint)(this._a & byte.MaxValue);
			return num | (g << 8) | (b << 16) | (a << 24);
		}
	}

	// Token: 0x0600007C RID: 124 RVA: 0x00004A3C File Offset: 0x00002C3C
	public override string ToString()
	{
		return string.Format("R:{0:0.00},G:{1:0.00},B:{2:0.00},A:{3:0.00}", new object[] { this.r, this.g, this.b, this.a });
	}

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x0600007D RID: 125 RVA: 0x00004A94 File Offset: 0x00002C94
	public string Hex
	{
		get
		{
			return string.Format("#{0}{1}{2}", this.R.ToString("X2"), this.G.ToString("X2"), this.B.ToString("X2"));
		}
	}

	// Token: 0x1700002A RID: 42
	public double this[int index]
	{
		get
		{
			switch (index)
			{
			case 0:
				return (double)this.r;
			case 1:
				return (double)this.g;
			case 2:
				return (double)this.b;
			case 3:
				return (double)this.a;
			default:
				throw new IndexOutOfRangeException();
			}
		}
	}

	// Token: 0x0600007F RID: 127 RVA: 0x00004B23 File Offset: 0x00002D23
	public void Write(BinaryWriter writer)
	{
		writer.Write(this.r);
		writer.Write(this.g);
		writer.Write(this.b);
		writer.Write(this.b);
	}

	// Token: 0x06000080 RID: 128 RVA: 0x00004B55 File Offset: 0x00002D55
	public static Color32 Read(BinaryReader reader)
	{
		return new Color32(reader.ReadByte(), reader.ReadByte(), reader.ReadByte(), reader.ReadByte());
	}

	// Token: 0x06000081 RID: 129 RVA: 0x00004B74 File Offset: 0x00002D74
	public static bool operator ==(Color32 left, Color32 right)
	{
		return left.Equals(right);
	}

	// Token: 0x06000082 RID: 130 RVA: 0x00004B7E File Offset: 0x00002D7E
	public static bool operator !=(Color32 left, Color32 right)
	{
		return !(left == right);
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00004B8C File Offset: 0x00002D8C
	public override bool Equals(object obj)
	{
		if (obj is Color32)
		{
			Color32 color = (Color32)obj;
			return this.Equals(color);
		}
		return false;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x00004BB4 File Offset: 0x00002DB4
	public bool Equals(Color32 o)
	{
		byte r = this._r;
		byte g = this._g;
		byte b = this._b;
		byte a = this._a;
		byte r2 = o._r;
		byte g2 = o._g;
		byte b2 = o._b;
		byte a2 = o._a;
		return r == r2 && g == g2 && b == b2 && a == a2;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00004C0F File Offset: 0x00002E0F
	public override int GetHashCode()
	{
		return HashCode.Combine<byte, byte, byte, byte>(this._r, this._g, this._b, this._a);
	}

	// Token: 0x0400001B RID: 27
	internal byte _r;

	// Token: 0x0400001C RID: 28
	internal byte _g;

	// Token: 0x0400001D RID: 29
	internal byte _b;

	// Token: 0x0400001E RID: 30
	internal byte _a;

	// Token: 0x0400001F RID: 31
	public static readonly Color32 White = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	// Token: 0x04000020 RID: 32
	public static readonly Color32 Gray = new Color32(128, 128, 128, byte.MaxValue);

	// Token: 0x04000021 RID: 33
	public static readonly Color32 Black = new Color32(0, 0, 0, byte.MaxValue);

	// Token: 0x04000022 RID: 34
	public static readonly Color32 Red = new Color32(byte.MaxValue, 0, 0, byte.MaxValue);

	// Token: 0x04000023 RID: 35
	public static readonly Color32 Green = new Color32(0, byte.MaxValue, 0, byte.MaxValue);

	// Token: 0x04000024 RID: 36
	public static readonly Color32 Blue = new Color32(0, 0, byte.MaxValue, byte.MaxValue);

	// Token: 0x04000025 RID: 37
	public static readonly Color32 Yellow = new Color32(byte.MaxValue, byte.MaxValue, 0, byte.MaxValue);

	// Token: 0x04000026 RID: 38
	public static readonly Color32 Cyan = new Color32(0, byte.MaxValue, byte.MaxValue, byte.MaxValue);

	// Token: 0x04000027 RID: 39
	public static readonly Color32 Magenta = new Color32(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);

	// Token: 0x04000028 RID: 40
	public static readonly Color32 Transparent = new Color32(0, 0, 0, 0);
}
