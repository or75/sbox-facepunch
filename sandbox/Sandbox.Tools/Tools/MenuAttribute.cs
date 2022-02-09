using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Sandbox;

namespace Tools
{
	// Token: 0x0200007F RID: 127
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Property)]
	public class MenuAttribute : Attribute
	{
		// Token: 0x0600130B RID: 4875 RVA: 0x00052964 File Offset: 0x00050B64
		public static void RegisterMenuBar(string name, MenuBar b)
		{
			MenuAttribute.Targets[name] = b;
			IEnumerable<MenuAttribute> all = MenuAttribute.All;
			Func<MenuAttribute, bool> <>9__0;
			Func<MenuAttribute, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = (MenuAttribute x) => x.Target == name);
			}
			foreach (MenuAttribute menuAttribute in all.Where(predicate))
			{
				menuAttribute.Register();
			}
		}

		// Token: 0x0600130C RID: 4876 RVA: 0x000529F0 File Offset: 0x00050BF0
		public static void RegisterMethod(MethodInfo m, MenuAttribute attr)
		{
			attr.methodInfo = m;
			MenuAttribute.All.Add(attr);
			attr.Register();
		}

		// Token: 0x0600130D RID: 4877 RVA: 0x00052A0A File Offset: 0x00050C0A
		public static void UnregisterMethod(MethodInfo m, MenuAttribute attr)
		{
			MenuAttribute.All.Remove(attr);
			attr.Unregister();
		}

		// Token: 0x0600130E RID: 4878 RVA: 0x00052A1E File Offset: 0x00050C1E
		public static void RegisterProperty(PropertyInfo m, MenuAttribute attr)
		{
			attr.propertyInfo = m;
			MenuAttribute.All.Add(attr);
			attr.Register();
		}

		// Token: 0x0600130F RID: 4879 RVA: 0x00052A38 File Offset: 0x00050C38
		public static void UnregisterProperty(PropertyInfo m, MenuAttribute attr)
		{
			MenuAttribute.All.Remove(attr);
			attr.Unregister();
		}

		// Token: 0x170000BD RID: 189
		// (get) Token: 0x06001310 RID: 4880 RVA: 0x00052A4C File Offset: 0x00050C4C
		// (set) Token: 0x06001311 RID: 4881 RVA: 0x00052A54 File Offset: 0x00050C54
		public string Target { get; set; }

		// Token: 0x170000BE RID: 190
		// (get) Token: 0x06001312 RID: 4882 RVA: 0x00052A5D File Offset: 0x00050C5D
		// (set) Token: 0x06001313 RID: 4883 RVA: 0x00052A65 File Offset: 0x00050C65
		public string Path { get; set; }

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06001314 RID: 4884 RVA: 0x00052A6E File Offset: 0x00050C6E
		// (set) Token: 0x06001315 RID: 4885 RVA: 0x00052A76 File Offset: 0x00050C76
		public string Icon { get; set; }

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06001316 RID: 4886 RVA: 0x00052A7F File Offset: 0x00050C7F
		// (set) Token: 0x06001317 RID: 4887 RVA: 0x00052A87 File Offset: 0x00050C87
		public string Shortcut { get; set; }

		// Token: 0x06001318 RID: 4888 RVA: 0x00052A90 File Offset: 0x00050C90
		public MenuAttribute(string target, string path, string icon = null)
		{
			this.Target = target;
			this.Path = path;
			this.Icon = icon;
		}

		// Token: 0x06001319 RID: 4889 RVA: 0x00052AAD File Offset: 0x00050CAD
		public MenuAttribute(string target, string path, MaterialIcon icon)
		{
			this.Target = target;
			this.Path = path;
			this.Icon = MaterialIconUtility.Lookup(icon);
		}

		// Token: 0x0600131A RID: 4890 RVA: 0x00052AD0 File Offset: 0x00050CD0
		private void Register()
		{
			MenuBar menuBar;
			if (MenuAttribute.Targets.TryGetValue(this.Target, out menuBar))
			{
				if (this.methodInfo != null)
				{
					menuBar.AddOption(this.Path, this.Icon, delegate()
					{
						MethodInfo methodInfo = this.methodInfo;
						if (methodInfo == null)
						{
							return;
						}
						methodInfo.Invoke(null, null);
					}, this.Shortcut);
				}
				if (this.propertyInfo != null)
				{
					Option option = new Option(menuBar, "...", null, null);
					option.Checkable = true;
					option.Checked = (bool)this.propertyInfo.GetValue(null);
					Option option2 = option;
					option2.Triggered = (Action)Delegate.Combine(option2.Triggered, new Action(delegate()
					{
						this.propertyInfo.SetValue(null, option.Checked);
					}));
					if (this.Shortcut != null)
					{
						option.Shortcut = this.Shortcut;
					}
					menuBar.AddOption(this.Path, option);
				}
			}
		}

		// Token: 0x0600131B RID: 4891 RVA: 0x00052BD4 File Offset: 0x00050DD4
		private void Unregister()
		{
			MenuBar menuBar;
			if (MenuAttribute.Targets.TryGetValue(this.Target, out menuBar))
			{
				menuBar.RemovePath(this.Path);
			}
		}

		// Token: 0x040001A5 RID: 421
		private static Dictionary<string, MenuBar> Targets = new Dictionary<string, MenuBar>();

		// Token: 0x040001A6 RID: 422
		private static List<MenuAttribute> All = new List<MenuAttribute>();

		// Token: 0x040001AB RID: 427
		internal MethodInfo methodInfo;

		// Token: 0x040001AC RID: 428
		internal PropertyInfo propertyInfo;
	}
}
