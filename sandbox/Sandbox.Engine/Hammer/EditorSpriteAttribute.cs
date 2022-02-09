using System;
using System.Text;
using Sandbox;

namespace Hammer
{
	/// <summary>
	/// Declare a sprite to represent this entity in Hammer.
	/// </summary>
	/// <example>
	/// [Hammer.EditorSprite( "editor/ai_goal_follow.vmat" )]
	/// </example>
	// Token: 0x02000201 RID: 513
	[AttributeUsage(AttributeTargets.Class)]
	public class EditorSpriteAttribute : MetaDataAttribute
	{
		// Token: 0x06000D0C RID: 3340 RVA: 0x0001659A File Offset: 0x0001479A
		public EditorSpriteAttribute(string sprite)
		{
			this.sprite = sprite;
		}

		// Token: 0x06000D0D RID: 3341 RVA: 0x000165AC File Offset: 0x000147AC
		public override void AddHeader(StringBuilder sb)
		{
			StringBuilder.AppendInterpolatedStringHandler appendInterpolatedStringHandler = new StringBuilder.AppendInterpolatedStringHandler(15, 1, sb);
			appendInterpolatedStringHandler.AppendLiteral("iconsprite( ");
			appendInterpolatedStringHandler.AppendFormatted(this.sprite.QuoteSafe());
			appendInterpolatedStringHandler.AppendLiteral(" ) ");
			sb.Append(ref appendInterpolatedStringHandler);
		}

		// Token: 0x04000DD6 RID: 3542
		private string sprite;
	}
}
