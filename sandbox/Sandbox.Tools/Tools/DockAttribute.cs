using System;
using System.Collections.Generic;
using System.Linq;
using Sandbox.Internal;

namespace Tools
{
	// Token: 0x02000079 RID: 121
	[AttributeUsage(AttributeTargets.Class)]
	public class DockAttribute : Attribute
	{
		// Token: 0x060012D8 RID: 4824 RVA: 0x00051924 File Offset: 0x0004FB24
		public static void RegisterWindow(string name, Window b)
		{
			DockAttribute.Targets[name] = b;
			IEnumerable<DockAttribute> all = DockAttribute.All;
			Func<DockAttribute, bool> <>9__0;
			Func<DockAttribute, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = (DockAttribute x) => x.Target == name);
			}
			foreach (DockAttribute dockAttribute in all.Where(predicate))
			{
				dockAttribute.Register();
			}
		}

		// Token: 0x060012D9 RID: 4825 RVA: 0x000519B0 File Offset: 0x0004FBB0
		public static void RegisterType(Type m, DockAttribute attr)
		{
			attr.typeInfo = m;
			DockAttribute.All.Add(attr);
			attr.Register();
		}

		// Token: 0x060012DA RID: 4826 RVA: 0x000519CA File Offset: 0x0004FBCA
		public static void UnregisterType(Type m, DockAttribute attr)
		{
			DockAttribute.All.Remove(attr);
			attr.Unregister();
		}

		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x060012DB RID: 4827 RVA: 0x000519DE File Offset: 0x0004FBDE
		// (set) Token: 0x060012DC RID: 4828 RVA: 0x000519E6 File Offset: 0x0004FBE6
		public string Target { get; set; }

		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060012DD RID: 4829 RVA: 0x000519EF File Offset: 0x0004FBEF
		// (set) Token: 0x060012DE RID: 4830 RVA: 0x000519F7 File Offset: 0x0004FBF7
		public string Name { get; set; }

		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060012DF RID: 4831 RVA: 0x00051A00 File Offset: 0x0004FC00
		// (set) Token: 0x060012E0 RID: 4832 RVA: 0x00051A08 File Offset: 0x0004FC08
		public string Icon { get; set; }

		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060012E1 RID: 4833 RVA: 0x00051A11 File Offset: 0x0004FC11
		// (set) Token: 0x060012E2 RID: 4834 RVA: 0x00051A19 File Offset: 0x0004FC19
		public DockArea DockArea { get; set; } = DockArea.Left;

		// Token: 0x060012E3 RID: 4835 RVA: 0x00051A22 File Offset: 0x0004FC22
		public DockAttribute(string target, string name, string icon = null)
		{
			this.Target = target;
			this.Name = name;
			this.Icon = icon;
		}

		// Token: 0x060012E4 RID: 4836 RVA: 0x00051A48 File Offset: 0x0004FC48
		private void Register()
		{
			Window window;
			if (DockAttribute.Targets.TryGetValue(this.Target, out window))
			{
				DockWidget dock = window.FindOrCreateDock(this.Name, this.Icon, this.DockArea, null);
				window.MenuBar.AddOption("View/" + this.Name, dock.GetToggleViewOption());
				dock.VisibilityChanged += delegate(bool b)
				{
					this.DockVisibilityChanged(dock, b);
				};
				if (dock.Visible)
				{
					this.DockVisibilityChanged(dock, true);
				}
			}
		}

		// Token: 0x060012E5 RID: 4837 RVA: 0x00051AEC File Offset: 0x0004FCEC
		private void Unregister()
		{
			Window window;
			if (DockAttribute.Targets.TryGetValue(this.Target, out window))
			{
				window.MenuBar.RemovePath("View/" + this.Name);
			}
		}

		// Token: 0x060012E6 RID: 4838 RVA: 0x00051B28 File Offset: 0x0004FD28
		private void DockVisibilityChanged(DockWidget dock, bool visible)
		{
			if (!visible)
			{
				Widget widget = dock.Widget;
				if (widget != null)
				{
					widget.Destroy();
				}
				dock.Widget = null;
				return;
			}
			if (dock.Widget != null)
			{
				return;
			}
			dock.Widget = GlobalToolsNamespace.Reflection.CreateType<Widget>(this.typeInfo, new object[] { dock });
		}

		// Token: 0x04000180 RID: 384
		private static Dictionary<string, Window> Targets = new Dictionary<string, Window>();

		// Token: 0x04000181 RID: 385
		private static List<DockAttribute> All = new List<DockAttribute>();

		// Token: 0x04000186 RID: 390
		internal Type typeInfo;
	}
}
