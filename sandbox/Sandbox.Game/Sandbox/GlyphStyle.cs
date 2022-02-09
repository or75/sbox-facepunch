using System;

namespace Sandbox
{
	/// <summary>
	///
	/// </summary>
	// Token: 0x020000AF RID: 175
	public struct GlyphStyle
	{
		/// <summary>
		/// ABXY Buttons will match the base style color instead of their normal associated color
		/// </summary>
		// Token: 0x0600115C RID: 4444 RVA: 0x00049F64 File Offset: 0x00048164
		public readonly GlyphStyle WithNeutralColorABXY()
		{
			return new GlyphStyle
			{
				Style = (this.Style | GlyphStyleMask.NeutralColorABXY)
			};
		}

		/// <summary>
		/// ABXY Buttons will have a solid fill
		/// </summary>
		// Token: 0x0600115D RID: 4445 RVA: 0x00049F8C File Offset: 0x0004818C
		public readonly GlyphStyle WithSolidABXY()
		{
			return new GlyphStyle
			{
				Style = (this.Style | GlyphStyleMask.SolidABXY)
			};
		}

		// Token: 0x04000326 RID: 806
		internal GlyphStyleMask Style;

		/// <summary>
		/// Face buttons will have colored labels/outlines on a knocked out background
		/// Rest of inputs will have white detail/borders on a knocked out background
		/// </summary>
		// Token: 0x04000327 RID: 807
		public static readonly GlyphStyle Knockout = new GlyphStyle
		{
			Style = GlyphStyleMask.Knockout
		};

		/// <summary>
		/// Black detail/borders on a white background
		/// </summary>
		// Token: 0x04000328 RID: 808
		public static readonly GlyphStyle Light = new GlyphStyle
		{
			Style = GlyphStyleMask.Light
		};

		/// <summary>
		/// White detail/borders on a black background
		/// </summary>
		// Token: 0x04000329 RID: 809
		public static readonly GlyphStyle Dark = new GlyphStyle
		{
			Style = GlyphStyleMask.Dark
		};
	}
}
