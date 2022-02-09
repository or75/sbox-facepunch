using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.UI
{
	/// <summary>
	/// A CSS selector like "Panel.button.red:hover .text"
	/// </summary>
	// Token: 0x02000148 RID: 328
	[Hotload.SkipAttribute]
	public sealed class StyleSelector
	{
		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x060018DB RID: 6363 RVA: 0x0006825A File Offset: 0x0006645A
		public int Score
		{
			get
			{
				if (this.Block != null)
				{
					return this.Block.LoadOrder + this.SelfScore * 1000;
				}
				return this.SelfScore;
			}
		}

		// Token: 0x060018DC RID: 6364 RVA: 0x00068283 File Offset: 0x00066483
		public void Finalize(StyleBlock block)
		{
			this.Block = block;
			this.UpdateScore();
		}

		// Token: 0x060018DD RID: 6365 RVA: 0x00068294 File Offset: 0x00066494
		private int UpdateScore()
		{
			this.SelfScore = 0;
			if (this.Element != null)
			{
				this.SelfScore++;
			}
			if (this.Classes != null)
			{
				this.SelfScore += this.Classes.Count<string>() * 10;
			}
			if (this.Flags != PseudoClass.None)
			{
				this.SelfScore += ((int)this.Flags).BitsSet() * 10;
			}
			if (this.NthChild != null)
			{
				this.SelfScore += 10;
			}
			if (this.Not != null)
			{
				this.SelfScore += this.Not.UpdateScore();
			}
			if (this.AnyOf != null)
			{
				this.SelfScore += this.AnyOf.Max((StyleSelector x) => x.UpdateScore());
			}
			if (this.DecendantOf != null)
			{
				this.SelfScore += this.DecendantOf.Max((StyleSelector x) => x.UpdateScore());
			}
			if (this.Parent != null)
			{
				this.SelfScore += this.Parent.UpdateScore();
			}
			return this.SelfScore;
		}

		// Token: 0x060018DE RID: 6366 RVA: 0x000683E0 File Offset: 0x000665E0
		public bool Test(Panel panel)
		{
			if (this.Flags != PseudoClass.None && (panel.PseudoClass & this.Flags) != this.Flags)
			{
				return false;
			}
			if (this.NthChild != null && !this.NthChild(panel))
			{
				return false;
			}
			if (this.Element != null && panel.ElementName != this.Element)
			{
				return false;
			}
			if (this.Classes != null && !panel.HasClasses(this.Classes))
			{
				return false;
			}
			if (this.Parent != null && !this.Parent.TestParent(panel.Parent, !this.ImmediateParent))
			{
				return false;
			}
			if (this.DecendantOf != null)
			{
				bool passed = false;
				using (List<StyleSelector>.Enumerator enumerator = this.DecendantOf.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.TestParent(panel.Parent, !this.ImmediateParent))
						{
							passed = true;
							break;
						}
					}
				}
				if (!passed)
				{
					return false;
				}
			}
			if (this.AnyOf != null)
			{
				bool passed2 = false;
				using (List<StyleSelector>.Enumerator enumerator = this.AnyOf.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Test(panel))
						{
							passed2 = true;
							break;
						}
					}
				}
				if (!passed2)
				{
					return false;
				}
			}
			return this.Not == null || !this.Not.Test(panel);
		}

		// Token: 0x060018DF RID: 6367 RVA: 0x00068554 File Offset: 0x00066754
		public bool TestParent(Panel panel, bool recusive = true)
		{
			return panel != null && (this.Test(panel) || (recusive && this.TestParent(panel.Parent, true)));
		}

		// Token: 0x040006C3 RID: 1731
		public StyleBlock Block;

		// Token: 0x040006C4 RID: 1732
		public string AsString;

		// Token: 0x040006C5 RID: 1733
		public HashSet<string> Classes;

		// Token: 0x040006C6 RID: 1734
		public string Element;

		// Token: 0x040006C7 RID: 1735
		public PseudoClass Flags;

		/// <summary>
		/// Descendant combinator
		/// A B
		/// Child combinator
		/// A &gt; B
		/// Adjacent sibling combinator
		/// A + B
		/// General sibling combinator
		/// A ~B
		/// </summary>
		// Token: 0x040006C8 RID: 1736
		public StyleSelector Parent;

		// Token: 0x040006C9 RID: 1737
		public StyleSelector Not;

		// Token: 0x040006CA RID: 1738
		public bool ImmediateParent;

		// Token: 0x040006CB RID: 1739
		public List<StyleSelector> AnyOf;

		// Token: 0x040006CC RID: 1740
		public List<StyleSelector> DecendantOf;

		// Token: 0x040006CD RID: 1741
		public int SelfScore;

		// Token: 0x040006CE RID: 1742
		public Func<Panel, bool> NthChild;
	}
}
