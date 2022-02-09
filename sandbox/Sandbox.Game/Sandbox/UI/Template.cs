using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox.UI
{
	// Token: 0x0200014F RID: 335
	public sealed class Template
	{
		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x0600193C RID: 6460 RVA: 0x0006A5DC File Offset: 0x000687DC
		// (set) Token: 0x0600193D RID: 6461 RVA: 0x0006A5E4 File Offset: 0x000687E4
		public string Path { get; internal set; }

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x0600193E RID: 6462 RVA: 0x0006A5ED File Offset: 0x000687ED
		// (set) Token: 0x0600193F RID: 6463 RVA: 0x0006A5F5 File Offset: 0x000687F5
		internal FileWatch Watcher { get; set; }

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x06001940 RID: 6464 RVA: 0x0006A5FE File Offset: 0x000687FE
		// (set) Token: 0x06001941 RID: 6465 RVA: 0x0006A606 File Offset: 0x00068806
		internal TemplatePanel Root { get; set; }

		// Token: 0x06001942 RID: 6466 RVA: 0x0006A60F File Offset: 0x0006880F
		internal void Clear()
		{
			this.StyleLinks = new List<string>();
			this.Styles = "";
		}

		/// <summary>
		/// Applies the layout to this panel
		/// </summary>
		// Token: 0x06001943 RID: 6467 RVA: 0x0006A628 File Offset: 0x00068828
		internal void Apply(Panel panel)
		{
			if (!this.Panels.Contains(panel))
			{
				this.Panels.Add(panel);
			}
			this.ApplyStyles(panel);
			try
			{
				TemplatePanel root = this.Root;
				if (root != null)
				{
					root.Apply(panel, panel, null);
				}
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Warning(e, FormattableStringFactory.Create("Error applying template {0}", new object[] { this.Path }));
			}
		}

		/// <summary>
		/// Applies styles in this layout to this panel
		/// Since styles are applied to the root, this could
		/// and would obviously affect children too
		/// </summary>
		// Token: 0x06001944 RID: 6468 RVA: 0x0006A6A4 File Offset: 0x000688A4
		internal void ApplyStyles(Panel panel)
		{
			foreach (string style in this.StyleLinks)
			{
				panel.StyleSheet.Load(style, true);
			}
			if (!string.IsNullOrWhiteSpace(this.Styles))
			{
				Template.log.Info(FormattableStringFactory.Create("TODO: ApplyStyles (s) {0}", new object[] { this.Styles }));
			}
		}

		// Token: 0x06001945 RID: 6469 RVA: 0x0006A730 File Offset: 0x00068930
		internal void ApplyAll()
		{
			foreach (Panel panel in this.Panels)
			{
				this.Apply(panel);
			}
		}

		// Token: 0x06001946 RID: 6470 RVA: 0x0006A784 File Offset: 0x00068984
		internal void UnapplyAll()
		{
			foreach (Panel panel in this.Panels)
			{
				this.Unapply(panel, false);
			}
		}

		/// <summary>
		/// Tries to remove the effects of this layout
		/// from this panel.
		/// </summary>
		// Token: 0x06001947 RID: 6471 RVA: 0x0006A7D8 File Offset: 0x000689D8
		internal void Unapply(Panel panel, bool andForget)
		{
			if (andForget)
			{
				this.Forget(panel);
			}
			panel.DeleteTemplateChildren(this);
			this.RemoveStyles(panel);
			foreach (string text in this.StyleLinks)
			{
			}
		}

		/// <summary>
		/// Stop tracking this panel as part of the layout.
		/// This means it'll stop getting notified of layout changes
		/// </summary>
		// Token: 0x06001948 RID: 6472 RVA: 0x0006A83C File Offset: 0x00068A3C
		internal void Forget(Panel panel)
		{
			this.Panels.Remove(panel);
		}

		/// <summary>
		/// Remove any styles applied by this layout
		/// </summary>
		// Token: 0x06001949 RID: 6473 RVA: 0x0006A84B File Offset: 0x00068A4B
		internal void RemoveStyles(Panel panel)
		{
		}

		/// <summary>
		/// Load the layout from a string of html
		/// </summary>
		// Token: 0x0600194A RID: 6474 RVA: 0x0006A84D File Offset: 0x00068A4D
		internal void Load(string content)
		{
			if (string.IsNullOrEmpty(content))
			{
				this.Clear();
				return;
			}
			new TemplateParser(content, this).Parse();
		}

		/// <summary>
		/// Adds a link to a stylesheet for this layout
		/// </summary>
		// Token: 0x0600194B RID: 6475 RVA: 0x0006A86A File Offset: 0x00068A6A
		internal void AddStyleLink(string v)
		{
			if (this.StyleLinks.Contains(v))
			{
				return;
			}
			this.StyleLinks.Add(v);
		}

		/// <summary>
		/// Adds some raw css to our style for this layout
		/// </summary>
		// Token: 0x0600194C RID: 6476 RVA: 0x0006A887 File Offset: 0x00068A87
		internal void AddStyleString(string style)
		{
			this.Styles = this.Styles + "\n\n" + style + "\n\n";
		}

		// Token: 0x0600194D RID: 6477 RVA: 0x0006A8A5 File Offset: 0x00068AA5
		internal static void Init()
		{
			Template.layouts = new Dictionary<string, Template>();
		}

		// Token: 0x0600194E RID: 6478 RVA: 0x0006A8B4 File Offset: 0x00068AB4
		public static Template Get(string path)
		{
			path = FileSystem.NormalizeFilename(path);
			if (!string.IsNullOrEmpty(path) && path[0] != '/')
			{
				path = "/" + path;
			}
			Template layout;
			if (Template.layouts.TryGetValue(path, out layout))
			{
				return layout;
			}
			layout = new Template
			{
				Path = path
			};
			Template.LoadLayout(layout);
			Template.WatchFilename(layout);
			Template.layouts[path] = layout;
			return layout;
		}

		// Token: 0x0600194F RID: 6479 RVA: 0x0006A924 File Offset: 0x00068B24
		internal static bool LoadLayout(Template layout)
		{
			bool result;
			try
			{
				layout.Clear();
				string content = FileSystem.Mounted.ReadAllText(layout.Path);
				layout.Load(content);
				result = true;
			}
			catch (Exception e)
			{
				GlobalGameNamespace.Log.Error(e);
				result = false;
			}
			return result;
		}

		// Token: 0x06001950 RID: 6480 RVA: 0x0006A974 File Offset: 0x00068B74
		private static void ReloadLayout(Template layout)
		{
			layout.UnapplyAll();
			Template.LoadLayout(layout);
			layout.ApplyAll();
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x0006A98C File Offset: 0x00068B8C
		private static void WatchFilename(Template layout)
		{
			layout.Watcher = FileSystem.Mounted.Watch(layout.Path);
			layout.Watcher.OnChanges += delegate(FileWatch x)
			{
				Template.ReloadLayout(layout);
			};
		}

		// Token: 0x040006E0 RID: 1760
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x040006E3 RID: 1763
		internal List<string> StyleLinks;

		// Token: 0x040006E4 RID: 1764
		internal string Styles;

		// Token: 0x040006E6 RID: 1766
		internal HashSet<Panel> Panels = new HashSet<Panel>();

		// Token: 0x040006E7 RID: 1767
		private static Dictionary<string, Template> layouts = new Dictionary<string, Template>();
	}
}
