using System;
using System.Collections.Generic;
using Sandbox.Html;

namespace Sandbox.UI
{
	// Token: 0x02000150 RID: 336
	internal sealed class TemplatePanel
	{
		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x06001954 RID: 6484 RVA: 0x0006AA0C File Offset: 0x00068C0C
		// (set) Token: 0x06001955 RID: 6485 RVA: 0x0006AA14 File Offset: 0x00068C14
		public Template Layout { get; set; }

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x06001956 RID: 6486 RVA: 0x0006AA1D File Offset: 0x00068C1D
		// (set) Token: 0x06001957 RID: 6487 RVA: 0x0006AA25 File Offset: 0x00068C25
		public TemplatePanel Parent { get; set; }

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06001958 RID: 6488 RVA: 0x0006AA2E File Offset: 0x00068C2E
		// (set) Token: 0x06001959 RID: 6489 RVA: 0x0006AA36 File Offset: 0x00068C36
		public List<TemplatePanel> Children { get; set; }

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x0600195A RID: 6490 RVA: 0x0006AA3F File Offset: 0x00068C3F
		// (set) Token: 0x0600195B RID: 6491 RVA: 0x0006AA47 File Offset: 0x00068C47
		public Dictionary<string, string> Attributes { get; set; }

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x0600195C RID: 6492 RVA: 0x0006AA50 File Offset: 0x00068C50
		// (set) Token: 0x0600195D RID: 6493 RVA: 0x0006AA58 File Offset: 0x00068C58
		public Dictionary<string, string> BindAttributes { get; set; }

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x0600195E RID: 6494 RVA: 0x0006AA61 File Offset: 0x00068C61
		// (set) Token: 0x0600195F RID: 6495 RVA: 0x0006AA69 File Offset: 0x00068C69
		internal List<PanelAction> Actions { get; set; }

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x06001960 RID: 6496 RVA: 0x0006AA72 File Offset: 0x00068C72
		// (set) Token: 0x06001961 RID: 6497 RVA: 0x0006AA7A File Offset: 0x00068C7A
		internal Node HtmlElement { get; set; }

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x06001962 RID: 6498 RVA: 0x0006AA83 File Offset: 0x00068C83
		// (set) Token: 0x06001963 RID: 6499 RVA: 0x0006AA8B File Offset: 0x00068C8B
		public string Name { get; set; }

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x06001964 RID: 6500 RVA: 0x0006AA94 File Offset: 0x00068C94
		// (set) Token: 0x06001965 RID: 6501 RVA: 0x0006AA9C File Offset: 0x00068C9C
		public string Slot { get; set; }

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06001966 RID: 6502 RVA: 0x0006AAA5 File Offset: 0x00068CA5
		// (set) Token: 0x06001967 RID: 6503 RVA: 0x0006AAAD File Offset: 0x00068CAD
		public string LayoutName { get; set; }

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06001968 RID: 6504 RVA: 0x0006AAB6 File Offset: 0x00068CB6
		// (set) Token: 0x06001969 RID: 6505 RVA: 0x0006AABE File Offset: 0x00068CBE
		public string TypeName { get; set; }

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x0600196A RID: 6506 RVA: 0x0006AAC7 File Offset: 0x00068CC7
		// (set) Token: 0x0600196B RID: 6507 RVA: 0x0006AACF File Offset: 0x00068CCF
		public string InnerHtml { get; set; }

		// Token: 0x0600196C RID: 6508 RVA: 0x0006AAD8 File Offset: 0x00068CD8
		public TemplatePanel(Template layout)
		{
			this.Layout = layout;
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x0006AAE7 File Offset: 0x00068CE7
		internal void AddChild(TemplatePanel cp)
		{
			if (this.Children == null)
			{
				this.Children = new List<TemplatePanel>();
			}
			this.Children.Add(cp);
			cp.Parent = this;
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x0006AB10 File Offset: 0x00068D10
		private void Create(Panel parent, Panel context)
		{
			try
			{
				this.RecurseCount++;
				if (this.RecurseCount > 10)
				{
					throw new Exception("Template recursion detected in " + this.Layout.Path);
				}
				Panel panel = Library.Create<Panel>(this.TypeName, false);
				if (panel == null)
				{
					panel = new Panel();
				}
				panel.ElementName = this.TypeName.ToLower();
				panel.CreatedByTemplate = this.Layout;
				this.Apply(panel, context, parent);
			}
			finally
			{
				this.RecurseCount--;
			}
		}

		// Token: 0x0600196F RID: 6511 RVA: 0x0006ABB0 File Offset: 0x00068DB0
		internal void Apply(Panel panel, Panel context, Panel parent)
		{
			panel.InternalPreTemplateApplied();
			if (!string.IsNullOrEmpty(this.Slot))
			{
				parent.OnTemplateSlot(this.HtmlElement, this.Slot, panel);
			}
			if (parent != null && panel.Parent == null)
			{
				panel.Parent = parent;
			}
			if (!panel.OnTemplateElement(this.HtmlElement))
			{
				this.ApplyChildren(panel, context);
			}
			if (this.Attributes != null)
			{
				foreach (KeyValuePair<string, string> attribute in this.Attributes)
				{
					panel.SetProperty(attribute.Key, attribute.Value);
				}
			}
			if (this.BindAttributes != null)
			{
				foreach (KeyValuePair<string, string> attribute2 in this.BindAttributes)
				{
					panel.SetBindProperty(context, attribute2.Key, attribute2.Value);
				}
			}
			if (!string.IsNullOrEmpty(this.InnerHtml))
			{
				panel.SetContent(this.InnerHtml);
			}
			this.ApplyEvents(panel, context);
			panel.InternalPostTemplateApplied();
		}

		// Token: 0x06001970 RID: 6512 RVA: 0x0006ACE8 File Offset: 0x00068EE8
		private void ApplyChildren(Panel panel, Panel context)
		{
			if (this.Children == null)
			{
				return;
			}
			foreach (TemplatePanel templatePanel in this.Children)
			{
				templatePanel.Create(panel, context);
			}
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x0006AD44 File Offset: 0x00068F44
		private void ApplyEvents(Panel panel, Panel context)
		{
			if (this.Actions == null)
			{
				return;
			}
			foreach (PanelAction panelAction in this.Actions)
			{
				panelAction.Apply(panel, context);
			}
		}

		// Token: 0x06001972 RID: 6514 RVA: 0x0006ADA0 File Offset: 0x00068FA0
		internal void AddAttribute(string name, string value)
		{
			if (name == "id")
			{
				this.Name = value;
				return;
			}
			if (name == "slot")
			{
				this.Slot = value.ToLower();
				return;
			}
			if (name.StartsWith("on") && name.Length > 3)
			{
				this.AddEventHandler(name, value);
				return;
			}
			if (name.StartsWith("@"))
			{
				if (this.BindAttributes == null)
				{
					this.BindAttributes = new Dictionary<string, string>();
				}
				Dictionary<string, string> bindAttributes = this.BindAttributes;
				int length = name.Length;
				int num = 1;
				int length2 = length - num;
				bindAttributes[name.Substring(num, length2)] = value;
				return;
			}
			if (this.Attributes == null)
			{
				this.Attributes = new Dictionary<string, string>();
			}
			this.Attributes[name] = value;
		}

		// Token: 0x06001973 RID: 6515 RVA: 0x0006AE60 File Offset: 0x00069060
		private void AddEventHandler(string name, string value)
		{
			if (this.Actions == null)
			{
				this.Actions = new List<PanelAction>();
			}
			PanelAction.Parse(name, value, this.Actions);
		}

		// Token: 0x040006E8 RID: 1768
		private static Logger log = Logging.GetLogger(null);

		// Token: 0x040006F5 RID: 1781
		private int RecurseCount;
	}
}
