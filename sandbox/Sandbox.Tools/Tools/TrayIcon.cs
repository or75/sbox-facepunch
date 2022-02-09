using System;
using Native;
using Sandbox;
using Sandbox.Internal;

namespace Tools
{
	/// <summary>
	/// Like a widget - but is drawn
	/// </summary>
	// Token: 0x020000CB RID: 203
	public class TrayIcon : QObject
	{
		// Token: 0x060016CB RID: 5835 RVA: 0x00059FBC File Offset: 0x000581BC
		public TrayIcon(QObject parent)
		{
			InteropSystem.Alloc<TrayIcon>(this);
			this.NativeInit(CSystemTrayIcon.Create((parent != null) ? parent._object : default(QObject), this));
		}

		// Token: 0x17000193 RID: 403
		// (get) Token: 0x060016CC RID: 5836 RVA: 0x00059FFA File Offset: 0x000581FA
		// (set) Token: 0x060016CD RID: 5837 RVA: 0x0005A007 File Offset: 0x00058207
		public bool Visible
		{
			get
			{
				return this._trayIcon.isVisible();
			}
			set
			{
				if (value)
				{
					this._trayIcon.show();
					return;
				}
				this._trayIcon.hide();
			}
		}

		// Token: 0x060016CE RID: 5838 RVA: 0x0005A023 File Offset: 0x00058223
		public void SetIcon(string icon)
		{
			this._trayIcon.setIcon(icon);
		}

		// Token: 0x060016CF RID: 5839 RVA: 0x0005A031 File Offset: 0x00058231
		public void ShowMessage(string title, string message, string icon, float seconds)
		{
			this._trayIcon.showMessage(title, message, icon, (int)(seconds * 1000f));
		}

		// Token: 0x060016D0 RID: 5840 RVA: 0x0005A04A File Offset: 0x0005824A
		internal override void NativeInit(IntPtr ptr)
		{
			this._trayIcon = ptr;
			base.NativeInit(ptr);
		}

		// Token: 0x060016D1 RID: 5841 RVA: 0x0005A05F File Offset: 0x0005825F
		internal override void NativeShutdown()
		{
			this._trayIcon = default(CSystemTrayIcon);
			base.NativeShutdown();
		}

		// Token: 0x060016D2 RID: 5842 RVA: 0x0005A073 File Offset: 0x00058273
		internal void InternalActivated()
		{
			GlobalToolsNamespace.Log.Info("Icon Activated");
		}

		// Token: 0x060016D3 RID: 5843 RVA: 0x0005A084 File Offset: 0x00058284
		internal void InternalMessageClicked()
		{
			GlobalToolsNamespace.Log.Info("Message Clicked");
		}

		// Token: 0x040004AC RID: 1196
		internal CSystemTrayIcon _trayIcon;
	}
}
