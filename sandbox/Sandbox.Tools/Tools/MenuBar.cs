using System;
using System.Collections.Generic;
using System.Linq;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000C0 RID: 192
	public class MenuBar : Widget
	{
		// Token: 0x0600161F RID: 5663 RVA: 0x00058CB1 File Offset: 0x00056EB1
		internal MenuBar(QMenuBar widget)
		{
			this.NativeInit(widget);
		}

		// Token: 0x06001620 RID: 5664 RVA: 0x00058CD0 File Offset: 0x00056ED0
		public MenuBar(Widget parent)
		{
			InteropSystem.Alloc<MenuBar>(this);
			this.NativeInit(CMenuBar.Create((parent != null) ? parent._widget : default(QWidget), this));
		}

		// Token: 0x06001621 RID: 5665 RVA: 0x00058D19 File Offset: 0x00056F19
		internal override void NativeInit(IntPtr ptr)
		{
			this._menubar = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x06001622 RID: 5666 RVA: 0x00058D2E File Offset: 0x00056F2E
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._menubar = default(QMenuBar);
		}

		// Token: 0x06001623 RID: 5667 RVA: 0x00058D44 File Offset: 0x00056F44
		public Option AddOption(string path, string icon = null, Action action = null, string shortcut = null)
		{
			string[] parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
			return this.GetPathTo(path).Last<Menu>().AddOption(parts.Last<string>(), icon, action, shortcut);
		}

		// Token: 0x06001624 RID: 5668 RVA: 0x00058D78 File Offset: 0x00056F78
		public void AddOption(string path, Option option)
		{
			string[] parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
			IEnumerable<Menu> pathTo = this.GetPathTo(path);
			option.Text = parts.Last<string>();
			pathTo.Last<Menu>().AddOption(option);
		}

		// Token: 0x06001625 RID: 5669 RVA: 0x00058DB0 File Offset: 0x00056FB0
		public void RemovePath(string path)
		{
			string[] parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
			List<Menu> menus = this.GetPathTo(path);
			if (menus.Count == 0)
			{
				return;
			}
			menus.Last<Menu>().RemoveOption(parts.Last<string>());
			menus.Reverse();
			foreach (Menu menu in menus)
			{
				if (menu.HasOptions)
				{
					break;
				}
				if (menu.HasMenus)
				{
					break;
				}
				menu.Destroy();
			}
		}

		// Token: 0x06001626 RID: 5670 RVA: 0x00058E44 File Offset: 0x00057044
		public List<Menu> GetPathTo(string path)
		{
			List<Menu> list = new List<Menu>();
			string[] parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length == 1)
			{
				return null;
			}
			Menu menu = this.FindOrCreateMenu(parts[0]);
			if (menu == null)
			{
				return null;
			}
			list.Add(menu);
			if (parts.Length <= 2)
			{
				return list;
			}
			menu.GetPathTo(path.Substring(parts[0].Length + 1), list);
			return list;
		}

		// Token: 0x06001627 RID: 5671 RVA: 0x00058EA0 File Offset: 0x000570A0
		public Menu FindOrCreateMenu(string name)
		{
			this.Menus.RemoveAll((Menu x) => !x.IsValid);
			Menu i = this.Menus.FirstOrDefault((Menu x) => x.Title == name);
			if (i != null)
			{
				return i;
			}
			return this.AddMenu(name);
		}

		// Token: 0x06001628 RID: 5672 RVA: 0x00058F0E File Offset: 0x0005710E
		public Option AddSeparator()
		{
			return new Option(this._menubar.addSeparator());
		}

		// Token: 0x06001629 RID: 5673 RVA: 0x00058F28 File Offset: 0x00057128
		public Menu AddMenu(string name)
		{
			Menu i = new Menu(name, this);
			this._menubar.addMenu(i._menu);
			this.Menus.Add(i);
			return i;
		}

		// Token: 0x0600162A RID: 5674 RVA: 0x00058F5C File Offset: 0x0005715C
		public Menu AddMenu(string icon, string name)
		{
			Menu i = new Menu(name, this);
			this._menubar.addMenu(i._menu);
			return i;
		}

		// Token: 0x0600162B RID: 5675 RVA: 0x00058F84 File Offset: 0x00057184
		public void Clear()
		{
			this._menubar.clear();
		}

		// Token: 0x0400048A RID: 1162
		internal QMenuBar _menubar;

		// Token: 0x0400048B RID: 1163
		private List<Menu> Menus = new List<Menu>();
	}
}
