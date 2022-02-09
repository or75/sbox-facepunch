using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020002C4 RID: 708
	public struct VertexAttribute
	{
		// Token: 0x060011F2 RID: 4594 RVA: 0x0002518A File Offset: 0x0002338A
		public VertexAttribute(VertexAttributeType type, VertexAttributeFormat format, int components = 3, int semanticIndex = 0)
		{
			this.Type = type;
			this.Format = format;
			this.Components = components;
			this.SemanticIndex = semanticIndex;
		}

		// Token: 0x060011F3 RID: 4595 RVA: 0x000251AC File Offset: 0x000233AC
		internal ColorFormat GetColorFormat()
		{
			if (this.Components > 4 || this.Components == 0)
			{
				return ColorFormat.COLOR_FORMAT_UNKNOWN;
			}
			if ((this.Type == VertexAttributeType.Color || this.Type == VertexAttributeType.BlendWeights) && this.Format == VertexAttributeFormat.UInt8)
			{
				ColorFormat result;
				switch (this.Components)
				{
				case 1:
					result = ColorFormat.COLOR_FORMAT_R8_UNORM;
					break;
				case 2:
					result = ColorFormat.COLOR_FORMAT_R8G8_UNORM;
					break;
				case 3:
					result = ColorFormat.COLOR_FORMAT_UNKNOWN;
					break;
				case 4:
					result = ColorFormat.COLOR_FORMAT_R8G8B8A8_UNORM;
					break;
				default:
					result = ColorFormat.COLOR_FORMAT_UNKNOWN;
					break;
				}
				return result;
			}
			switch (this.Format)
			{
			case VertexAttributeFormat.Float32:
				return VertexAttribute.Float32FormatTable[this.Components];
			case VertexAttributeFormat.Float16:
			case VertexAttributeFormat.SInt16:
			case VertexAttributeFormat.UInt16:
			case VertexAttributeFormat.SInt8:
				return ColorFormat.COLOR_FORMAT_UNKNOWN;
			case VertexAttributeFormat.SInt32:
				return VertexAttribute.SInt32FormatTable[this.Components];
			case VertexAttributeFormat.UInt32:
				return VertexAttribute.UInt32FormatTable[this.Components];
			case VertexAttributeFormat.UInt8:
				return VertexAttribute.UInt8FormatTable[this.Components];
			default:
				return ColorFormat.COLOR_FORMAT_UNKNOWN;
			}
		}

		// Token: 0x04001448 RID: 5192
		public VertexAttributeType Type;

		// Token: 0x04001449 RID: 5193
		public VertexAttributeFormat Format;

		// Token: 0x0400144A RID: 5194
		public int Components;

		// Token: 0x0400144B RID: 5195
		public int SemanticIndex;

		// Token: 0x0400144C RID: 5196
		internal static readonly ColorFormat[] Float32FormatTable = new ColorFormat[]
		{
			ColorFormat.COLOR_FORMAT_UNKNOWN,
			ColorFormat.COLOR_FORMAT_R32_FLOAT,
			ColorFormat.COLOR_FORMAT_R32G32_FLOAT,
			ColorFormat.COLOR_FORMAT_R32G32B32_FLOAT,
			ColorFormat.COLOR_FORMAT_R32G32B32A32_FLOAT
		};

		// Token: 0x0400144D RID: 5197
		internal static readonly ColorFormat[] UInt32FormatTable = new ColorFormat[]
		{
			ColorFormat.COLOR_FORMAT_UNKNOWN,
			ColorFormat.COLOR_FORMAT_R32_UINT,
			ColorFormat.COLOR_FORMAT_R32G32_UINT,
			ColorFormat.COLOR_FORMAT_R32G32B32_UINT,
			ColorFormat.COLOR_FORMAT_R32G32B32A32_UINT
		};

		// Token: 0x0400144E RID: 5198
		internal static readonly ColorFormat[] SInt32FormatTable = new ColorFormat[]
		{
			ColorFormat.COLOR_FORMAT_UNKNOWN,
			ColorFormat.COLOR_FORMAT_R32_SINT,
			ColorFormat.COLOR_FORMAT_R32G32_SINT,
			ColorFormat.COLOR_FORMAT_R32G32B32_SINT,
			ColorFormat.COLOR_FORMAT_R32G32B32A32_SINT
		};

		// Token: 0x0400144F RID: 5199
		internal static readonly ColorFormat[] UInt8FormatTable = new ColorFormat[]
		{
			ColorFormat.COLOR_FORMAT_UNKNOWN,
			ColorFormat.COLOR_FORMAT_R8_UINT,
			ColorFormat.COLOR_FORMAT_R8G8_UINT,
			ColorFormat.COLOR_FORMAT_UNKNOWN,
			ColorFormat.COLOR_FORMAT_R8G8B8A8_UINT
		};
	}
}
