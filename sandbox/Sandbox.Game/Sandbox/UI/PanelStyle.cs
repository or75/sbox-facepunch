using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sandbox.UI
{
	// Token: 0x02000120 RID: 288
	public sealed class PanelStyle : Styles
	{
		// Token: 0x06001612 RID: 5650 RVA: 0x00058870 File Offset: 0x00056A70
		public override void Dirty()
		{
			this.isDirty = true;
		}

		// Token: 0x06001613 RID: 5651 RVA: 0x00058879 File Offset: 0x00056A79
		internal PanelStyle(Panel panel)
		{
			this.panel = panel;
			Host.AssertClientOrMenu(".ctor");
		}

		// Token: 0x06001614 RID: 5652 RVA: 0x000588B8 File Offset: 0x00056AB8
		internal bool BuildCached(ref LayoutCascade cascade)
		{
			if (!this.isDirty && !cascade.SelectorChanged)
			{
				return false;
			}
			this.isDirty = false;
			this.Cached.From(Styles.Default);
			List<StyleSelector> list = this.activeRules;
			if (list != null)
			{
				list.Clear();
			}
			SortedSet<StyleSelector> sortedSet = this.sortedRules;
			if (sortedSet != null)
			{
				sortedSet.Clear();
			}
			foreach (StyleSheet styleSheet in this.panel.AllStyleSheets.Reverse<StyleSheet>())
			{
				foreach (StyleBlock styleBlock in styleSheet.Nodes)
				{
					StyleSelector winningSelector = styleBlock.Test(this.panel);
					if (winningSelector != null)
					{
						if (this.activeRules == null)
						{
							this.activeRules = new List<StyleSelector>();
						}
						this.activeRules.Add(winningSelector);
						if (this.sortedRules == null)
						{
							this.sortedRules = new SortedSet<StyleSelector>(StyleOrderer.Instance);
						}
						this.sortedRules.Add(winningSelector);
					}
				}
			}
			int ruleguid = 0;
			if (this.activeRules != null)
			{
				foreach (StyleSelector entry in this.sortedRules)
				{
					this.Cached.Add(entry.Block.Styles);
					ruleguid = HashCode.Combine<int, StyleSelector>(ruleguid, entry);
				}
			}
			if (ruleguid != this.ActiveRulesGuid)
			{
				this.ActiveRulesGuid = ruleguid;
				cascade.SelectorChanged = true;
				if (this.LastActiveRules == null)
				{
					this.LastActiveRules = new List<StyleSelector>();
				}
				foreach (StyleSelector rule in this.activeRules.Except(this.LastActiveRules))
				{
					this.OnRuleAdded(rule);
				}
				foreach (StyleSelector rule2 in this.LastActiveRules.Except(this.activeRules))
				{
					this.OnRuleRemoved(rule2);
				}
				List<StyleSelector> ar = this.activeRules;
				this.activeRules = this.LastActiveRules;
				this.LastActiveRules = ar;
				this.activeRules.Clear();
			}
			this.Cached.Add(this);
			this.Cached.ApplyScale(cascade.Scale);
			return true;
		}

		// Token: 0x06001615 RID: 5653 RVA: 0x00058B5C File Offset: 0x00056D5C
		internal Styles BuildFinal(ref LayoutCascade cascade, out bool changed)
		{
			cascade.SkipTransitions = this.skipTransitions || cascade.SkipTransitions;
			changed = this.BuildCached(ref cascade);
			if (cascade.SkipTransitions)
			{
				this.panel.Transitions.Kill();
				this.skipTransitions = false;
			}
			else if (changed && this.Final != null)
			{
				this.panel.Transitions.Kill(this.Final);
				this.panel.Transitions.Add(this.Final, this.Cached);
			}
			this.Final.From(this.Cached);
			if (this.panel.Transitions.Run(this.Final))
			{
				changed = true;
			}
			cascade.ApplyCascading(this.Final);
			return this.Final;
		}

		// Token: 0x06001616 RID: 5654 RVA: 0x00058C26 File Offset: 0x00056E26
		public override bool Set(string property, string value)
		{
			this.isDirty = true;
			return base.Set(property, value);
		}

		// Token: 0x06001617 RID: 5655 RVA: 0x00058C37 File Offset: 0x00056E37
		internal void OnRuleAdded(StyleSelector selector)
		{
			if (selector.Block.Styles.SoundIn != null)
			{
				this.panel.PlaySound(selector.Block.Styles.SoundIn);
			}
		}

		// Token: 0x06001618 RID: 5656 RVA: 0x00058C66 File Offset: 0x00056E66
		internal void OnRuleRemoved(StyleSelector selector)
		{
			if (selector.Block.Styles.SoundOut != null)
			{
				this.panel.PlaySound(selector.Block.Styles.SoundOut);
			}
		}

		// Token: 0x06001619 RID: 5657 RVA: 0x00058C95 File Offset: 0x00056E95
		public void SetBackgroundImage(Texture texture)
		{
			base.BackgroundImage = texture;
		}

		// Token: 0x0600161A RID: 5658 RVA: 0x00058C9E File Offset: 0x00056E9E
		public void SetBackgroundImage(string image)
		{
			this.SetBackgroundImage(Texture.Load(FileSystem.Mounted, image, true));
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x00058CB4 File Offset: 0x00056EB4
		public async Task SetBackgroundImageAsync(string image)
		{
			Texture backgroundImage = await Texture.LoadAsync(FileSystem.Mounted, image, true);
			this.SetBackgroundImage(backgroundImage);
		}

		// Token: 0x0600161C RID: 5660 RVA: 0x00058D00 File Offset: 0x00056F00
		public void SetRect(Rect rect)
		{
			base.Left = new Length?(rect.left);
			base.Top = new Length?(rect.top);
			base.Width = new Length?(rect.width);
			base.Height = new Length?(rect.height);
			this.Dirty();
		}

		// Token: 0x04000583 RID: 1411
		private Panel panel;

		// Token: 0x04000584 RID: 1412
		internal Styles Cached = new Styles();

		// Token: 0x04000585 RID: 1413
		internal Styles Final = new Styles();

		/// <summary>
		/// This could be a local variable if we wanted to create a new class every time
		/// </summary>
		// Token: 0x04000586 RID: 1414
		private List<StyleSelector> activeRules;

		// Token: 0x04000587 RID: 1415
		private SortedSet<StyleSelector> sortedRules;

		/// <summary>
		/// Store the last active rules so we can compare them when they change and trigger sounds etc on new styles
		/// </summary>
		// Token: 0x04000588 RID: 1416
		private List<StyleSelector> LastActiveRules;

		/// <summary>
		/// Cache of the active rules that are applied, that way we can trigger stuff only if they actually changed
		/// </summary>
		// Token: 0x04000589 RID: 1417
		private int ActiveRulesGuid;

		// Token: 0x0400058A RID: 1418
		private bool isDirty = true;

		// Token: 0x0400058B RID: 1419
		internal bool skipTransitions = true;
	}
}
