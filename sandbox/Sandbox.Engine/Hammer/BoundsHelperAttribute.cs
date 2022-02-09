using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Creates a resizable box helper in Hammer which outputs the size of the bounding box defined by the level designer into given keys/properties.
	/// You can have multiple of this attribute.
	/// </summary>
	// Token: 0x02000214 RID: 532
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public class BoundsHelperAttribute : MetaDataAttribute
	{
		/// <summary>
		/// Creates a box helper that outputs the size of the bounding box defined by the level designer as mins and maxs
		/// </summary>
		/// <param name="minsKey">The internal key name to output "mins" size to.</param>
		/// <param name="maxsKey">The internal key name to output "maxs" size to.</param>
		/// <param name="autoCenter">If set to true, editing this box in Hammer will automatically move the entity to the center of the box.</param>
		/// <param name="worldAliged">If set, the helper box will ignore entity rotation.</param>
		// Token: 0x06000D34 RID: 3380 RVA: 0x00017081 File Offset: 0x00015281
		public BoundsHelperAttribute(string minsKey, string maxsKey, bool autoCenter = false, bool worldAliged = false)
		{
			this.minsKey = minsKey;
			this.maxsKey = maxsKey;
			this.autoCenter = autoCenter;
			this.isWorldAligned = worldAliged;
		}

		/// <summary>
		/// Creates a box helper that outputs the size of the bounding box defined by the level designer as extents (maxs - mins).
		/// This assumes the entity is in the center of the box.
		/// </summary>
		/// <param name="extentsKey">The internal key name to output "extents" size to. This is the result of (maxs - mins).</param>
		/// <param name="worldAliged">If set, the helper box will ignore entity rotation.</param>
		// Token: 0x06000D35 RID: 3381 RVA: 0x000170A6 File Offset: 0x000152A6
		public BoundsHelperAttribute(string extentsKey, bool worldAliged = false)
		{
			this.extentsKey = extentsKey;
			this.autoCenter = false;
			this.isWorldAligned = worldAliged;
		}

		// Token: 0x06000D36 RID: 3382 RVA: 0x000170C4 File Offset: 0x000152C4
		public override void AddHeader(StringBuilder sb)
		{
			string type = "oriented";
			if (this.isWorldAligned)
			{
				type = "world_aligned";
			}
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler;
			if (!string.IsNullOrEmpty(this.extentsKey))
			{
				appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(18, 2, sb);
				appendInterpolatedStringHandler.AppendLiteral("centered_box_");
				appendInterpolatedStringHandler.AppendFormatted(type);
				appendInterpolatedStringHandler.AppendLiteral("( ");
				appendInterpolatedStringHandler.AppendFormatted(this.extentsKey.QuoteSafe());
				appendInterpolatedStringHandler.AppendLiteral(" ) ");
				sb.Append(ref appendInterpolatedStringHandler);
				return;
			}
			appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(11, 4, sb);
			appendInterpolatedStringHandler.AppendLiteral("box_");
			appendInterpolatedStringHandler.AppendFormatted(type);
			appendInterpolatedStringHandler.AppendLiteral("( ");
			appendInterpolatedStringHandler.AppendFormatted(this.minsKey.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(", ");
			appendInterpolatedStringHandler.AppendFormatted(this.maxsKey.QuoteSafe());
			appendInterpolatedStringHandler.AppendFormatted(this.autoCenter ? ", AutoCenter" : "");
			appendInterpolatedStringHandler.AppendLiteral(" ) ");
			sb.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04000E00 RID: 3584
		private string minsKey;

		// Token: 0x04000E01 RID: 3585
		private string maxsKey;

		// Token: 0x04000E02 RID: 3586
		private string extentsKey;

		// Token: 0x04000E03 RID: 3587
		private bool autoCenter;

		// Token: 0x04000E04 RID: 3588
		private bool isWorldAligned;
	}
}
