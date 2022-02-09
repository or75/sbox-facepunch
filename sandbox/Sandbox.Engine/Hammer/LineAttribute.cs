using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Draws a line in Hammer. You can have multiple of this attribute.
	/// </summary>
	// Token: 0x02000212 RID: 530
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class LineAttribute : MetaDataAttribute
	{
		/// <summary>
		/// Draws lines between this entity and all entites which have a key named '<paramref name="startKey">startKey</paramref>' and its value matches
		/// the value of our '<paramref name="startKeyValue">startKeyValue</paramref>'.
		/// </summary>
		/// <param name="startKey">Name of the key to search on other entities. This typically will be 'targetname'.</param>
		/// <param name="startKeyValue">Name of our key whose value will be used to match other entities.</param>
		/// <param name="onlySelected">Only draw the line when the entity is selected.</param>
		// Token: 0x06000D2D RID: 3373 RVA: 0x00016D18 File Offset: 0x00014F18
		public LineAttribute(string startKey, string startKeyValue, bool onlySelected = false)
		{
			this.color = "255 255 255";
			this.selectedOnly = onlySelected;
			this.startKey = startKey;
			this.startKeyValue = startKeyValue;
		}

		/// <summary>
		/// Draws lines between all entites, starting from each entity that has a key named '<paramref name="startKey">startKey</paramref>' and its value matches
		/// the value of our '<paramref name="startKeyValue">startKeyValue</paramref>' and going to each entity that has a key named <paramref name="endKey">endKey</paramref>
		/// with a value of '<paramref name="endKeyValue">endKeyValue</paramref>'s value.
		/// </summary>
		/// <param name="startKey">Name of the key to search on other entities. This typically will be 'targetname'.</param>
		/// <param name="startKeyValue">Name of our key whose value will be used to match other entities.</param>
		/// <param name="endKey">Name of the key to search on other entities.</param>
		/// <param name="endKeyValue">Name of our key whose value will be used to match other entities.</param>
		/// <param name="onlySelected">Only draw the line when the entity is selected.</param>
		// Token: 0x06000D2E RID: 3374 RVA: 0x00016D40 File Offset: 0x00014F40
		public LineAttribute(string startKey, string startKeyValue, string endKey, string endKeyValue, bool onlySelected = false)
			: this(startKey, startKeyValue, onlySelected)
		{
			this.endKey = endKey;
			this.endKeyValue = endKeyValue;
		}

		// Token: 0x06000D2F RID: 3375 RVA: 0x00016D5C File Offset: 0x00014F5C
		public override void AddHeader(StringBuilder sb)
		{
			if (this.selectedOnly)
			{
				sb.Append("selected_");
			}
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(10, 3, sb);
			appendInterpolatedStringHandler.AppendLiteral("line( ");
			appendInterpolatedStringHandler.AppendFormatted(this.color);
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.startKey.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.startKeyValue.QuoteSafe());
			sb.Append(ref appendInterpolatedStringHandler);
			if (!string.IsNullOrEmpty(this.endKey) && !string.IsNullOrEmpty(this.endKeyValue))
			{
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(4, 2, sb);
				appendInterpolatedStringHandler.AppendLiteral(", ");
				appendInterpolatedStringHandler.AppendFormatted(this.endKey.QuoteSafe());
				appendInterpolatedStringHandler.AppendLiteral(", ");
				appendInterpolatedStringHandler.AppendFormatted(this.endKeyValue.QuoteSafe());
				sb.Append(ref appendInterpolatedStringHandler);
			}
			sb.Append(" ) ");
		}

		// Token: 0x04000DF8 RID: 3576
		private bool selectedOnly;

		// Token: 0x04000DF9 RID: 3577
		private string color;

		// Token: 0x04000DFA RID: 3578
		private string startKey;

		// Token: 0x04000DFB RID: 3579
		private string startKeyValue;

		// Token: 0x04000DFC RID: 3580
		private string endKey;

		// Token: 0x04000DFD RID: 3581
		private string endKeyValue;
	}
}
