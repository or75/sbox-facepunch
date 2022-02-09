using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace Hammer
{
	/// <summary>
	/// For point entities without visualization (model/sprite), sets the size of the box the entity will appear as in Hammer.
	/// </summary>
	// Token: 0x02000213 RID: 531
	[AttributeUsage(AttributeTargets.Class)]
	public class BoxSizeAttribute : MetaDataAttribute
	{
		// Token: 0x06000D30 RID: 3376 RVA: 0x00016E60 File Offset: 0x00015060
		public BoxSizeAttribute(float size)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted<float>(-size);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(-size);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(-size);
			this.mins = defaultInterpolatedStringHandler.ToStringAndClear();
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted<float>(size);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(size);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(size);
			this.maxs = defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06000D31 RID: 3377 RVA: 0x00016F04 File Offset: 0x00015104
		public BoxSizeAttribute(float minsX, float minsY, float minsZ)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted<float>(minsX);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(minsY);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(minsZ);
			this.mins = defaultInterpolatedStringHandler.ToStringAndClear();
			this.maxs = "";
		}

		// Token: 0x06000D32 RID: 3378 RVA: 0x00016F68 File Offset: 0x00015168
		public BoxSizeAttribute(float minsX, float minsY, float minsZ, float maxsX, float maxsY, float maxsZ)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted<float>(minsX);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(minsY);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(minsZ);
			this.mins = defaultInterpolatedStringHandler.ToStringAndClear();
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted<float>(maxsX);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(maxsY);
			defaultInterpolatedStringHandler.AppendLiteral(" ");
			defaultInterpolatedStringHandler.AppendFormatted<float>(maxsZ);
			this.maxs = defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x06000D33 RID: 3379 RVA: 0x0001700C File Offset: 0x0001520C
		public override void AddHeader(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("size( ");
			appendInterpolatedStringHandler.AppendFormatted(this.mins);
			sb.Append(ref appendInterpolatedStringHandler);
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(2, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.maxs);
			sb.Append(ref appendInterpolatedStringHandler);
			sb.Append(" ) ");
		}

		// Token: 0x04000DFE RID: 3582
		private string mins;

		// Token: 0x04000DFF RID: 3583
		private string maxs;
	}
}
