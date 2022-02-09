using System;
using System.Runtime.CompilerServices;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Declare a model to represent this entity in Hammer.
	/// </summary>
	// Token: 0x02000200 RID: 512
	[AttributeUsage(AttributeTargets.Class)]
	public class EditorModelAttribute : MetaDataAttribute
	{
		/// <summary>
		/// Whether the model should cast shadows in the editor.
		/// </summary>
		// Token: 0x1700028C RID: 652
		// (get) Token: 0x06000D02 RID: 3330 RVA: 0x0001634D File Offset: 0x0001454D
		// (set) Token: 0x06000D03 RID: 3331 RVA: 0x00016355 File Offset: 0x00014555
		public bool CastShadows { get; set; }

		/// <summary>
		/// Don't reorient bounds. This is used for things that have fixed bounds in the game, like info_player_start.
		/// </summary>
		// Token: 0x1700028D RID: 653
		// (get) Token: 0x06000D04 RID: 3332 RVA: 0x0001635E File Offset: 0x0001455E
		// (set) Token: 0x06000D05 RID: 3333 RVA: 0x00016366 File Offset: 0x00014566
		public bool FixedBounds { get; set; }

		/// <summary>
		/// Tint color for this editor model instance when the entity it represets is static.
		/// </summary>
		// Token: 0x1700028E RID: 654
		// (get) Token: 0x06000D06 RID: 3334 RVA: 0x0001636F File Offset: 0x0001456F
		// (set) Token: 0x06000D07 RID: 3335 RVA: 0x00016377 File Offset: 0x00014577
		private Color32 StaticColor { get; set; }

		/// <summary>
		/// Tint color for this editor model instance when the entity it represets is dynamic.
		/// </summary>
		// Token: 0x1700028F RID: 655
		// (get) Token: 0x06000D08 RID: 3336 RVA: 0x00016380 File Offset: 0x00014580
		// (set) Token: 0x06000D09 RID: 3337 RVA: 0x00016388 File Offset: 0x00014588
		private Color32 DynamicColor { get; set; }

		// Token: 0x06000D0A RID: 3338 RVA: 0x00016391 File Offset: 0x00014591
		public EditorModelAttribute(string model, byte staticRed = 255, byte staticGreen = 255, byte statcBlue = 255, byte dynamicRed = 255, byte dynamicGreen = 255, byte dynamicBlue = 255)
		{
			this.Model = model;
			this.StaticColor = new Color32(staticRed, staticGreen, statcBlue, byte.MaxValue);
			this.DynamicColor = new Color32(dynamicRed, dynamicGreen, dynamicBlue, byte.MaxValue);
		}

		// Token: 0x06000D0B RID: 3339 RVA: 0x000163CC File Offset: 0x000145CC
		public override void AddHeader(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(13, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("editormodel( ");
			appendInterpolatedStringHandler.AppendFormatted(this.Model.QuoteSafe());
			sb.Append(ref appendInterpolatedStringHandler);
			if (this.CastShadows)
			{
				sb.Append(", castshadows");
			}
			if (this.FixedBounds)
			{
				sb.Append(", fixedbounds");
			}
			if (this.StaticColor != Color32.White)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 3);
				defaultInterpolatedStringHandler.AppendLiteral("\"");
				defaultInterpolatedStringHandler.AppendFormatted<byte>(this.StaticColor.r);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted<byte>(this.StaticColor.g);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted<byte>(this.StaticColor.b);
				defaultInterpolatedStringHandler.AppendLiteral("\"");
				string clrS = defaultInterpolatedStringHandler.ToStringAndClear();
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 3);
				defaultInterpolatedStringHandler.AppendLiteral("\"");
				defaultInterpolatedStringHandler.AppendFormatted<byte>(this.DynamicColor.r);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted<byte>(this.DynamicColor.g);
				defaultInterpolatedStringHandler.AppendLiteral(" ");
				defaultInterpolatedStringHandler.AppendFormatted<byte>(this.DynamicColor.b);
				defaultInterpolatedStringHandler.AppendLiteral("\"");
				string clrD = defaultInterpolatedStringHandler.ToStringAndClear();
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(19, 2, sb);
				appendInterpolatedStringHandler.AppendLiteral(", lightModeTint, ");
				appendInterpolatedStringHandler.AppendFormatted(clrS);
				appendInterpolatedStringHandler.AppendLiteral(", ");
				appendInterpolatedStringHandler.AppendFormatted(clrD);
				sb.Append(ref appendInterpolatedStringHandler);
			}
			sb.Append(" ) ");
		}

		// Token: 0x04000DD1 RID: 3537
		private string Model;
	}
}
