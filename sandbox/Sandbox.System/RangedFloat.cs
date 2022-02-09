using System;
using System.Text.Json.Serialization;
using Sandbox;
using Sandbox.Internal.JsonConvert;

// Token: 0x0200001C RID: 28
[JsonConverter(typeof(RangedFloatConverter))]
public struct RangedFloat
{
	// Token: 0x06000134 RID: 308 RVA: 0x00007581 File Offset: 0x00005781
	public RangedFloat(float fixedValue)
	{
		this.x = fixedValue;
		this.y = fixedValue;
		this.z = 0f;
	}

	// Token: 0x06000135 RID: 309 RVA: 0x0000759C File Offset: 0x0000579C
	public RangedFloat(float min, float max)
	{
		this.x = min;
		this.y = max;
		this.z = 1f;
	}

	// Token: 0x06000136 RID: 310 RVA: 0x000075B7 File Offset: 0x000057B7
	public override string ToString()
	{
		return string.Format("{0:0.00},{1:0.00},{2:0.00}", this.x, this.y, this.z);
	}

	// Token: 0x06000137 RID: 311 RVA: 0x000075E4 File Offset: 0x000057E4
	public static implicit operator RangedFloat(float input)
	{
		return new RangedFloat(input);
	}

	// Token: 0x06000138 RID: 312 RVA: 0x000075EC File Offset: 0x000057EC
	public float GetValue()
	{
		if (this.z == 1f)
		{
			return Rand.Float(this.x, this.y);
		}
		return this.x;
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00007614 File Offset: 0x00005814
	public static RangedFloat Parse(string str)
	{
		str = str.Trim(new char[] { '[', ']', ' ', '\n', '\r', '\t', '"' });
		string[] p = str.Split(new char[] { ' ', ',', ';', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		if (p.Length != 3)
		{
			return default(RangedFloat);
		}
		return new RangedFloat
		{
			x = p[0].ToFloat(0f),
			y = p[1].ToFloat(0f),
			z = p[2].ToFloat(0f)
		};
	}

	// Token: 0x04000047 RID: 71
	public float x;

	// Token: 0x04000048 RID: 72
	public float y;

	// Token: 0x04000049 RID: 73
	public float z;
}
