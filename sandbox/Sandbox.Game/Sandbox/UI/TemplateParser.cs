using System;
using System.IO;
using System.Linq;
using Sandbox.Html;

namespace Sandbox.UI
{
	// Token: 0x02000151 RID: 337
	internal sealed class TemplateParser
	{
		// Token: 0x06001975 RID: 6517 RVA: 0x0006AE9C File Offset: 0x0006909C
		public TemplateParser(string html, Template layout)
		{
			this.layout = layout;
			this.rootNode = Node.Parse(html);
		}

		// Token: 0x06001976 RID: 6518 RVA: 0x0006AEB8 File Offset: 0x000690B8
		internal void Parse()
		{
			bool foundRoot = false;
			foreach (Node child in this.rootNode.ChildNodes)
			{
				if (child.IsElement)
				{
					if (child.Name == "link")
					{
						this.ParseLinkTag(child);
					}
					else if (child.Name == "style")
					{
						this.ParseStyleTag(child);
					}
					else if (!foundRoot)
					{
						this.ParsePanelRoot(child);
						foundRoot = true;
					}
				}
			}
		}

		// Token: 0x06001977 RID: 6519 RVA: 0x0006AF58 File Offset: 0x00069158
		private void ParseLinkTag(Node child)
		{
			if (child.GetAttribute("rel", "") == "stylesheet")
			{
				this.layout.AddStyleLink(this.LinkPath(child.GetAttribute("href", "").Trim()));
			}
		}

		// Token: 0x06001978 RID: 6520 RVA: 0x0006AFA8 File Offset: 0x000691A8
		private string LinkPath(string link)
		{
			if (link.StartsWith("./"))
			{
				link = link.Substring(2);
			}
			if (link.StartsWith('/'))
			{
				return link;
			}
			return Path.Combine(Path.GetDirectoryName(this.layout.Path), link).Replace('\\', '/');
		}

		// Token: 0x06001979 RID: 6521 RVA: 0x0006AFF6 File Offset: 0x000691F6
		private void ParseStyleTag(Node child)
		{
			this.layout.AddStyleString(child.InnerHtml);
		}

		// Token: 0x0600197A RID: 6522 RVA: 0x0006B009 File Offset: 0x00069209
		private void ParsePanelRoot(Node node)
		{
			this.layout.Root = new TemplatePanel(this.layout);
			this.ParsePanel(node, this.layout.Root);
		}

		// Token: 0x0600197B RID: 6523 RVA: 0x0006B034 File Offset: 0x00069234
		private void ParsePanel(Node node, TemplatePanel panel)
		{
			panel.HtmlElement = node;
			panel.TypeName = node.Name;
			foreach (Attribute attribute in node.Attributes)
			{
				panel.AddAttribute(attribute.Name, attribute.Value);
			}
			this.ParseChildren(node, panel);
			if (panel.Children == null && !string.IsNullOrWhiteSpace(node.InnerHtml))
			{
				panel.InnerHtml = node.InnerHtml;
			}
			panel.LayoutName = node.Name.GetHashCode().ToString("x");
		}

		// Token: 0x0600197C RID: 6524 RVA: 0x0006B0EC File Offset: 0x000692EC
		private void ParseChildren(Node node, TemplatePanel parent)
		{
			if (node.ChildNodes.Where((Node x) => x.IsElement).All((Node x) => TemplateParser.labelElements.Contains(x.Name.ToLower())))
			{
				return;
			}
			foreach (Node childNode in node.ChildNodes)
			{
				if (childNode.IsElement)
				{
					TemplatePanel childPanel = new TemplatePanel(this.layout);
					parent.AddChild(childPanel);
					this.ParsePanel(childNode, childPanel);
				}
			}
		}

		// Token: 0x040006F6 RID: 1782
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x040006F7 RID: 1783
		private Node rootNode;

		// Token: 0x040006F8 RID: 1784
		private Template layout;

		// Token: 0x040006F9 RID: 1785
		private static readonly string[] labelElements = new string[]
		{
			"a", "b", "br", "i", "em", "p", "strong", "span", "h1", "h2",
			"font", "pre", "code"
		};
	}
}
