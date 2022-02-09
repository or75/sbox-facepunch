using System;
using System.Collections.Generic;
using System.Linq;
using Native;

namespace Tools
{
	// Token: 0x020000BF RID: 191
	public class Menu : Widget
	{
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06001604 RID: 5636 RVA: 0x000587F8 File Offset: 0x000569F8
		// (remove) Token: 0x06001605 RID: 5637 RVA: 0x00058830 File Offset: 0x00056A30
		public event Action AboutToShow;

		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06001606 RID: 5638 RVA: 0x00058868 File Offset: 0x00056A68
		// (remove) Token: 0x06001607 RID: 5639 RVA: 0x000588A0 File Offset: 0x00056AA0
		public event Action AboutToHide;

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x06001608 RID: 5640 RVA: 0x000588D5 File Offset: 0x00056AD5
		// (set) Token: 0x06001609 RID: 5641 RVA: 0x000588E2 File Offset: 0x00056AE2
		public string Title
		{
			get
			{
				return this._menu.title();
			}
			set
			{
				this._menu.setTitle(value);
			}
		}

		// Token: 0x0600160A RID: 5642 RVA: 0x000588F0 File Offset: 0x00056AF0
		internal Menu(QWidget widget)
		{
			this.NativeInit(widget);
		}

		// Token: 0x0600160B RID: 5643 RVA: 0x0005891C File Offset: 0x00056B1C
		public Menu(Widget parent = null)
		{
			QMenu ptr = QMenu.Create((parent != null) ? parent._widget : default(QWidget));
			this.NativeInit(ptr);
		}

		// Token: 0x0600160C RID: 5644 RVA: 0x0005896B File Offset: 0x00056B6B
		public Menu(string title, Widget parent = null)
			: this(parent)
		{
			this.Title = title;
		}

		// Token: 0x0600160D RID: 5645 RVA: 0x0005897C File Offset: 0x00056B7C
		internal override void NativeInit(IntPtr ptr)
		{
			this._menu = ptr;
			WidgetUtil.OnMenu_AboutToShow(ptr, base.Callback(new QObject.CallbackMethod(this.OnAboutToShow)));
			WidgetUtil.OnMenu_AboutToHide(ptr, base.Callback(new QObject.CallbackMethod(this.OnAboutToHide)));
			base.NativeInit(ptr);
		}

		// Token: 0x0600160E RID: 5646 RVA: 0x000589D8 File Offset: 0x00056BD8
		internal override void NativeShutdown()
		{
			base.NativeShutdown();
			this._menu = default(QMenu);
		}

		// Token: 0x0600160F RID: 5647 RVA: 0x000589EC File Offset: 0x00056BEC
		protected virtual void OnAboutToShow()
		{
			Action aboutToShow = this.AboutToShow;
			if (aboutToShow == null)
			{
				return;
			}
			aboutToShow();
		}

		// Token: 0x06001610 RID: 5648 RVA: 0x000589FE File Offset: 0x00056BFE
		protected virtual void OnAboutToHide()
		{
			Action aboutToHide = this.AboutToHide;
			if (aboutToHide == null)
			{
				return;
			}
			aboutToHide();
		}

		// Token: 0x06001611 RID: 5649 RVA: 0x00058A10 File Offset: 0x00056C10
		public virtual Option AddOption(string name, string icon = null, Action action = null, string shortcut = null)
		{
			Option o = new Option(this, name, icon, action);
			if (shortcut != null)
			{
				o.Shortcut = shortcut;
			}
			this._menu.insertAction(default(QAction), o._action);
			this.Options.Add(o);
			return o;
		}

		// Token: 0x06001612 RID: 5650 RVA: 0x00058A5C File Offset: 0x00056C5C
		public virtual Option AddOption(Option option)
		{
			this._menu.insertAction(default(QAction), option._action);
			this.Options.Add(option);
			return option;
		}

		// Token: 0x06001613 RID: 5651 RVA: 0x00058A90 File Offset: 0x00056C90
		public void GetPathTo(string path, List<Menu> list)
		{
			string[] parts = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
			if (parts.Length == 1)
			{
				return;
			}
			Menu menu = this.FindOrCreateMenu(parts[0]);
			if (menu == null)
			{
				return;
			}
			list.Add(menu);
			if (parts.Length <= 2)
			{
				return;
			}
			menu.GetPathTo(path.Substring(parts[0].Length + 1), list);
		}

		// Token: 0x06001614 RID: 5652 RVA: 0x00058AE4 File Offset: 0x00056CE4
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

		// Token: 0x17000163 RID: 355
		// (get) Token: 0x06001615 RID: 5653 RVA: 0x00058B52 File Offset: 0x00056D52
		public bool HasOptions
		{
			get
			{
				return this.Options.Count > 0;
			}
		}

		// Token: 0x17000164 RID: 356
		// (get) Token: 0x06001616 RID: 5654 RVA: 0x00058B62 File Offset: 0x00056D62
		public bool HasMenus
		{
			get
			{
				return this.Menus.Count > 0;
			}
		}

		// Token: 0x06001617 RID: 5655 RVA: 0x00058B74 File Offset: 0x00056D74
		public Menu AddMenu(string name)
		{
			Menu menu = new Menu(name, this);
			this._menu.addMenu(menu._menu);
			this.Menus.Add(menu);
			return menu;
		}

		// Token: 0x06001618 RID: 5656 RVA: 0x00058BA8 File Offset: 0x00056DA8
		public Option GetOption(string name)
		{
			return this.Options.FirstOrDefault((Option x) => x.Text == name);
		}

		// Token: 0x06001619 RID: 5657 RVA: 0x00058BDC File Offset: 0x00056DDC
		public void RemoveOption(string name)
		{
			Option o = this.GetOption(name);
			if (o == null)
			{
				return;
			}
			this.RemoveOption(o);
		}

		// Token: 0x0600161A RID: 5658 RVA: 0x00058BFC File Offset: 0x00056DFC
		public void RemoveOption(Option option)
		{
			this.Options.Remove(option);
			this._menu.removeAction(option._action);
		}

		// Token: 0x0600161B RID: 5659 RVA: 0x00058C1C File Offset: 0x00056E1C
		public Option AddSeparator()
		{
			return new Option(this._menu.addSeparator());
		}

		// Token: 0x0600161C RID: 5660 RVA: 0x00058C33 File Offset: 0x00056E33
		public void OpenAt(Vector2 position)
		{
			this._menu.exec(position);
		}

		// Token: 0x0600161D RID: 5661 RVA: 0x00058C46 File Offset: 0x00056E46
		public void Clear()
		{
			this._menu.clear();
		}

		// Token: 0x17000165 RID: 357
		// (get) Token: 0x0600161E RID: 5662 RVA: 0x00058C54 File Offset: 0x00056E54
		public Option SelectedOption
		{
			get
			{
				QAction a = this._menu.activeAction();
				if (a.IsNull)
				{
					return null;
				}
				if (this.lastActive != null && this.lastActive._action == a)
				{
					return this.lastActive;
				}
				this.lastActive = new Option(a);
				return this.lastActive;
			}
		}

		// Token: 0x04000484 RID: 1156
		internal QMenu _menu;

		// Token: 0x04000487 RID: 1159
		private List<Menu> Menus = new List<Menu>();

		// Token: 0x04000488 RID: 1160
		private List<Option> Options = new List<Option>();

		// Token: 0x04000489 RID: 1161
		private Option lastActive;
	}
}
