using System;
using System.Runtime.CompilerServices;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Displays a sphere in Hammer with a radius tied to given property and with given color.
	/// The sphere's radius can be manipulated in Hammer's 2D views. You can have multiple of these.
	/// </summary>
	// Token: 0x02000210 RID: 528
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class SphereAttribute : MetaDataAttribute
	{
		/// <param name="variableName">Name of the variable to use as sphere radius.</param>
		/// <param name="color">Color as an unsigned integer. For example 0xFF99CC, where 0xBBGGRR.</param>
		/// <param name="singleSelect">If this helper should show up when only 1 object is selected in Hammer.</param>
		// Token: 0x06000D27 RID: 3367 RVA: 0x00016A91 File Offset: 0x00014C91
		public SphereAttribute(string variableName, uint color, bool singleSelect = false)
		{
			this.variableName = variableName;
			this.color = new Color32(color);
			this.color.a = byte.MaxValue;
			this.singleSelect = singleSelect;
		}

		/// <param name="variableName">Name of the variable to use as sphere radius.</param>
		/// <param name="red">Red component of the sphere's color.</param>
		/// <param name="green">Green component of the sphere's color.</param>
		/// <param name="blue">Blue component of the sphere's color.</param>
		/// <param name="singleSelect">If this helper should show up when only 1 object is selected in Hammer.</param>
		// Token: 0x06000D28 RID: 3368 RVA: 0x00016AC3 File Offset: 0x00014CC3
		public SphereAttribute(string variableName = "radius", byte red = 255, byte green = 255, byte blue = 255, bool singleSelect = false)
		{
			this.variableName = variableName;
			this.color = new Color32(red, green, blue, byte.MaxValue);
			this.singleSelect = singleSelect;
		}

		/// <param name="radius">Range of the sphere to show.</param>
		/// <param name="red">Red component of the sphere's color.</param>
		/// <param name="green">Green component of the sphere's color.</param>
		/// <param name="blue">Blue component of the sphere's color.</param>
		/// <param name="singleSelect">If this helper should show up when only 1 object is selected in Hammer.</param>
		// Token: 0x06000D29 RID: 3369 RVA: 0x00016AF0 File Offset: 0x00014CF0
		public SphereAttribute(float radius, byte red = 255, byte green = 255, byte blue = 255, bool singleSelect = false)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<float>(radius);
			this.variableName = defaultInterpolatedStringHandler.ToStringAndClear();
			this.color = new Color32(red, green, blue, byte.MaxValue);
			this.singleSelect = singleSelect;
		}

		// Token: 0x06000D2A RID: 3370 RVA: 0x00016B40 File Offset: 0x00014D40
		public override void AddHeader(StringBuilder sb)
		{
			if (this.IsLean)
			{
				sb.Append("lean");
			}
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(8, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("sphere( ");
			appendInterpolatedStringHandler.AppendFormatted(this.variableName.QuoteSafe());
			sb.Append(ref appendInterpolatedStringHandler);
			if (this.color != Color32.White || this.singleSelect)
			{
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(6, 3, sb);
				appendInterpolatedStringHandler.AppendLiteral(", ");
				appendInterpolatedStringHandler.AppendFormatted<byte>(this.color.r);
				appendInterpolatedStringHandler.AppendLiteral(", ");
				appendInterpolatedStringHandler.AppendFormatted<byte>(this.color.g);
				appendInterpolatedStringHandler.AppendLiteral(", ");
				appendInterpolatedStringHandler.AppendFormatted<byte>(this.color.b);
				sb.Append(ref appendInterpolatedStringHandler);
			}
			if (this.singleSelect)
			{
				sb.Append(", singleSelect");
			}
			sb.Append(" ) ");
		}

		// Token: 0x04000DF1 RID: 3569
		private string variableName;

		// Token: 0x04000DF2 RID: 3570
		private Color32 color;

		// Token: 0x04000DF3 RID: 3571
		private bool singleSelect;

		/// <summary>
		/// If set to true, the sphere will appear as 3 circles in 3D view, rather than a wireframe sphere.
		/// </summary>
		// Token: 0x04000DF4 RID: 3572
		public bool IsLean;
	}
}
