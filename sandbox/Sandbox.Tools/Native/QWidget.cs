using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200005E RID: 94
	internal struct QWidget
	{
		// Token: 0x0600108B RID: 4235 RVA: 0x0002CCCD File Offset: 0x0002AECD
		public static implicit operator IntPtr(QWidget value)
		{
			return value.self;
		}

		// Token: 0x0600108C RID: 4236 RVA: 0x0002CCD8 File Offset: 0x0002AED8
		public static implicit operator QWidget(IntPtr value)
		{
			return new QWidget
			{
				self = value
			};
		}

		// Token: 0x0600108D RID: 4237 RVA: 0x0002CCF6 File Offset: 0x0002AEF6
		public static bool operator ==(QWidget c1, QWidget c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600108E RID: 4238 RVA: 0x0002CD09 File Offset: 0x0002AF09
		public static bool operator !=(QWidget c1, QWidget c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600108F RID: 4239 RVA: 0x0002CD1C File Offset: 0x0002AF1C
		public override bool Equals(object obj)
		{
			if (obj is QWidget)
			{
				QWidget c = (QWidget)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06001090 RID: 4240 RVA: 0x0002CD46 File Offset: 0x0002AF46
		internal QWidget(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06001091 RID: 4241 RVA: 0x0002CD50 File Offset: 0x0002AF50
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(8, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QWidget ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x06001092 RID: 4242 RVA: 0x0002CD8B File Offset: 0x0002AF8B
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06001093 RID: 4243 RVA: 0x0002CD9D File Offset: 0x0002AF9D
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06001094 RID: 4244 RVA: 0x0002CDA8 File Offset: 0x0002AFA8
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06001095 RID: 4245 RVA: 0x0002CDBB File Offset: 0x0002AFBB
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QWidget was null when calling " + n);
			}
		}

		// Token: 0x06001096 RID: 4246 RVA: 0x0002CDD6 File Offset: 0x0002AFD6
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06001097 RID: 4247 RVA: 0x0002CDE4 File Offset: 0x0002AFE4
		public static implicit operator QObject(QWidget value)
		{
			method to_QObject_From_QWidget = QWidget.__N.To_QObject_From_QWidget;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QWidget);
		}

		// Token: 0x06001098 RID: 4248 RVA: 0x0002CE08 File Offset: 0x0002B008
		public static explicit operator QWidget(QObject value)
		{
			method from_QObject_To_QWidget = QWidget.__N.From_QObject_To_QWidget;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QWidget);
		}

		// Token: 0x06001099 RID: 4249 RVA: 0x0002CE2C File Offset: 0x0002B02C
		internal static QWidget CreateWidget(QWidget parent)
		{
			method qwdget_CreateWidget = QWidget.__N.QWdget_CreateWidget;
			return calli(System.IntPtr(System.IntPtr), parent, qwdget_CreateWidget);
		}

		// Token: 0x0600109A RID: 4250 RVA: 0x0002CE50 File Offset: 0x0002B050
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qwdget_isTopLevel = QWidget.__N.QWdget_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_isTopLevel) > 0;
		}

		// Token: 0x0600109B RID: 4251 RVA: 0x0002CE80 File Offset: 0x0002B080
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qwdget_isWindow = QWidget.__N.QWdget_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_isWindow) > 0;
		}

		// Token: 0x0600109C RID: 4252 RVA: 0x0002CEB0 File Offset: 0x0002B0B0
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qwdget_isModal = QWidget.__N.QWdget_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_isModal) > 0;
		}

		// Token: 0x0600109D RID: 4253 RVA: 0x0002CEE0 File Offset: 0x0002B0E0
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qwdget_setStyleSheet = QWidget.__N.QWdget_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qwdget_setStyleSheet);
		}

		// Token: 0x0600109E RID: 4254 RVA: 0x0002CF10 File Offset: 0x0002B110
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qwdget_windowTitle = QWidget.__N.QWdget_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qwdget_windowTitle));
		}

		// Token: 0x0600109F RID: 4255 RVA: 0x0002CF40 File Offset: 0x0002B140
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qwdget_setWindowTitle = QWidget.__N.QWdget_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qwdget_setWindowTitle);
		}

		// Token: 0x060010A0 RID: 4256 RVA: 0x0002CF70 File Offset: 0x0002B170
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qwdget_setWindowFlags = QWidget.__N.QWdget_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qwdget_setWindowFlags);
		}

		// Token: 0x060010A1 RID: 4257 RVA: 0x0002CF9C File Offset: 0x0002B19C
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qwdget_windowFlags = QWidget.__N.QWdget_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qwdget_windowFlags);
		}

		// Token: 0x060010A2 RID: 4258 RVA: 0x0002CFC8 File Offset: 0x0002B1C8
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qwdget_size = QWidget.__N.QWdget_size;
			return calli(Vector3(System.IntPtr), this.self, qwdget_size);
		}

		// Token: 0x060010A3 RID: 4259 RVA: 0x0002CFF4 File Offset: 0x0002B1F4
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qwdget_resize = QWidget.__N.QWdget_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qwdget_resize);
		}

		// Token: 0x060010A4 RID: 4260 RVA: 0x0002D020 File Offset: 0x0002B220
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qwdget_minimumSize = QWidget.__N.QWdget_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qwdget_minimumSize);
		}

		// Token: 0x060010A5 RID: 4261 RVA: 0x0002D04C File Offset: 0x0002B24C
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qwdget_setMinimumSize = QWidget.__N.QWdget_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qwdget_setMinimumSize);
		}

		// Token: 0x060010A6 RID: 4262 RVA: 0x0002D078 File Offset: 0x0002B278
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qwdget_maximumSize = QWidget.__N.QWdget_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qwdget_maximumSize);
		}

		// Token: 0x060010A7 RID: 4263 RVA: 0x0002D0A4 File Offset: 0x0002B2A4
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qwdget_setMaximumSize = QWidget.__N.QWdget_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qwdget_setMaximumSize);
		}

		// Token: 0x060010A8 RID: 4264 RVA: 0x0002D0D0 File Offset: 0x0002B2D0
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qwdget_pos = QWidget.__N.QWdget_pos;
			return calli(Vector3(System.IntPtr), this.self, qwdget_pos);
		}

		// Token: 0x060010A9 RID: 4265 RVA: 0x0002D0FC File Offset: 0x0002B2FC
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qwdget_move = QWidget.__N.QWdget_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qwdget_move);
		}

		// Token: 0x060010AA RID: 4266 RVA: 0x0002D128 File Offset: 0x0002B328
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qwdget_isEnabled = QWidget.__N.QWdget_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_isEnabled) > 0;
		}

		// Token: 0x060010AB RID: 4267 RVA: 0x0002D158 File Offset: 0x0002B358
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qwdget_setEnabled = QWidget.__N.QWdget_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qwdget_setEnabled);
		}

		// Token: 0x060010AC RID: 4268 RVA: 0x0002D18C File Offset: 0x0002B38C
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qwdget_setVisible = QWidget.__N.QWdget_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qwdget_setVisible);
		}

		// Token: 0x060010AD RID: 4269 RVA: 0x0002D1C0 File Offset: 0x0002B3C0
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qwdget_setHidden = QWidget.__N.QWdget_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qwdget_setHidden);
		}

		// Token: 0x060010AE RID: 4270 RVA: 0x0002D1F4 File Offset: 0x0002B3F4
		internal readonly void show()
		{
			this.NullCheck("show");
			method qwdget_show = QWidget.__N.QWdget_show;
			calli(System.Void(System.IntPtr), this.self, qwdget_show);
		}

		// Token: 0x060010AF RID: 4271 RVA: 0x0002D220 File Offset: 0x0002B420
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qwdget_hide = QWidget.__N.QWdget_hide;
			calli(System.Void(System.IntPtr), this.self, qwdget_hide);
		}

		// Token: 0x060010B0 RID: 4272 RVA: 0x0002D24C File Offset: 0x0002B44C
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qwdget_showMinimized = QWidget.__N.QWdget_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qwdget_showMinimized);
		}

		// Token: 0x060010B1 RID: 4273 RVA: 0x0002D278 File Offset: 0x0002B478
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qwdget_showMaximized = QWidget.__N.QWdget_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qwdget_showMaximized);
		}

		// Token: 0x060010B2 RID: 4274 RVA: 0x0002D2A4 File Offset: 0x0002B4A4
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qwdget_showFullScreen = QWidget.__N.QWdget_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qwdget_showFullScreen);
		}

		// Token: 0x060010B3 RID: 4275 RVA: 0x0002D2D0 File Offset: 0x0002B4D0
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qwdget_showNormal = QWidget.__N.QWdget_showNormal;
			calli(System.Void(System.IntPtr), this.self, qwdget_showNormal);
		}

		// Token: 0x060010B4 RID: 4276 RVA: 0x0002D2FC File Offset: 0x0002B4FC
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qwdget_close = QWidget.__N.QWdget_close;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_close) > 0;
		}

		// Token: 0x060010B5 RID: 4277 RVA: 0x0002D32C File Offset: 0x0002B52C
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qwdget_raise = QWidget.__N.QWdget_raise;
			calli(System.Void(System.IntPtr), this.self, qwdget_raise);
		}

		// Token: 0x060010B6 RID: 4278 RVA: 0x0002D358 File Offset: 0x0002B558
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qwdget_lower = QWidget.__N.QWdget_lower;
			calli(System.Void(System.IntPtr), this.self, qwdget_lower);
		}

		// Token: 0x060010B7 RID: 4279 RVA: 0x0002D384 File Offset: 0x0002B584
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qwdget_isVisible = QWidget.__N.QWdget_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_isVisible) > 0;
		}

		// Token: 0x060010B8 RID: 4280 RVA: 0x0002D3B4 File Offset: 0x0002B5B4
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qwdget_setAttribute = QWidget.__N.QWdget_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qwdget_setAttribute);
		}

		// Token: 0x060010B9 RID: 4281 RVA: 0x0002D3E8 File Offset: 0x0002B5E8
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qwdget_testAttribute = QWidget.__N.QWdget_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qwdget_testAttribute) > 0;
		}

		// Token: 0x060010BA RID: 4282 RVA: 0x0002D418 File Offset: 0x0002B618
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qwdget_acceptDrops = QWidget.__N.QWdget_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_acceptDrops) > 0;
		}

		// Token: 0x060010BB RID: 4283 RVA: 0x0002D448 File Offset: 0x0002B648
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qwdget_setAcceptDrops = QWidget.__N.QWdget_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qwdget_setAcceptDrops);
		}

		// Token: 0x060010BC RID: 4284 RVA: 0x0002D47C File Offset: 0x0002B67C
		internal readonly void update()
		{
			this.NullCheck("update");
			method qwdget_update = QWidget.__N.QWdget_update;
			calli(System.Void(System.IntPtr), this.self, qwdget_update);
		}

		// Token: 0x060010BD RID: 4285 RVA: 0x0002D4A8 File Offset: 0x0002B6A8
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qwdget_repaint = QWidget.__N.QWdget_repaint;
			calli(System.Void(System.IntPtr), this.self, qwdget_repaint);
		}

		// Token: 0x060010BE RID: 4286 RVA: 0x0002D4D4 File Offset: 0x0002B6D4
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qwdget_setCursor = QWidget.__N.QWdget_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qwdget_setCursor);
		}

		// Token: 0x060010BF RID: 4287 RVA: 0x0002D500 File Offset: 0x0002B700
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qwdget_unsetCursor = QWidget.__N.QWdget_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qwdget_unsetCursor);
		}

		// Token: 0x060010C0 RID: 4288 RVA: 0x0002D52C File Offset: 0x0002B72C
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qwdget_setWindowIcon = QWidget.__N.QWdget_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qwdget_setWindowIcon);
		}

		// Token: 0x060010C1 RID: 4289 RVA: 0x0002D55C File Offset: 0x0002B75C
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qwdget_setWindowIconText = QWidget.__N.QWdget_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qwdget_setWindowIconText);
		}

		// Token: 0x060010C2 RID: 4290 RVA: 0x0002D58C File Offset: 0x0002B78C
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qwdget_setWindowOpacity = QWidget.__N.QWdget_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qwdget_setWindowOpacity);
		}

		// Token: 0x060010C3 RID: 4291 RVA: 0x0002D5B8 File Offset: 0x0002B7B8
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qwdget_windowOpacity = QWidget.__N.QWdget_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qwdget_windowOpacity);
		}

		// Token: 0x060010C4 RID: 4292 RVA: 0x0002D5E4 File Offset: 0x0002B7E4
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qwdget_isMinimized = QWidget.__N.QWdget_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_isMinimized) > 0;
		}

		// Token: 0x060010C5 RID: 4293 RVA: 0x0002D614 File Offset: 0x0002B814
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qwdget_isMaximized = QWidget.__N.QWdget_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_isMaximized) > 0;
		}

		// Token: 0x060010C6 RID: 4294 RVA: 0x0002D644 File Offset: 0x0002B844
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qwdget_isFullScreen = QWidget.__N.QWdget_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_isFullScreen) > 0;
		}

		// Token: 0x060010C7 RID: 4295 RVA: 0x0002D674 File Offset: 0x0002B874
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qwdget_setMouseTracking = QWidget.__N.QWdget_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qwdget_setMouseTracking);
		}

		// Token: 0x060010C8 RID: 4296 RVA: 0x0002D6A8 File Offset: 0x0002B8A8
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qwdget_hasMouseTracking = QWidget.__N.QWdget_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_hasMouseTracking) > 0;
		}

		// Token: 0x060010C9 RID: 4297 RVA: 0x0002D6D8 File Offset: 0x0002B8D8
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qwdget_underMouse = QWidget.__N.QWdget_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_underMouse) > 0;
		}

		// Token: 0x060010CA RID: 4298 RVA: 0x0002D708 File Offset: 0x0002B908
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qwdget_mapToGlobal = QWidget.__N.QWdget_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qwdget_mapToGlobal);
		}

		// Token: 0x060010CB RID: 4299 RVA: 0x0002D734 File Offset: 0x0002B934
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qwdget_mapFromGlobal = QWidget.__N.QWdget_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qwdget_mapFromGlobal);
		}

		// Token: 0x060010CC RID: 4300 RVA: 0x0002D760 File Offset: 0x0002B960
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qwdget_hasFocus = QWidget.__N.QWdget_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_hasFocus) > 0;
		}

		// Token: 0x060010CD RID: 4301 RVA: 0x0002D790 File Offset: 0x0002B990
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qwdget_focusPolicy = QWidget.__N.QWdget_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qwdget_focusPolicy);
		}

		// Token: 0x060010CE RID: 4302 RVA: 0x0002D7BC File Offset: 0x0002B9BC
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qwdget_setFocusPolicy = QWidget.__N.QWdget_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qwdget_setFocusPolicy);
		}

		// Token: 0x060010CF RID: 4303 RVA: 0x0002D7E8 File Offset: 0x0002B9E8
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qwdget_setFocusProxy = QWidget.__N.QWdget_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qwdget_setFocusProxy);
		}

		// Token: 0x060010D0 RID: 4304 RVA: 0x0002D818 File Offset: 0x0002BA18
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qwdget_isActiveWindow = QWidget.__N.QWdget_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_isActiveWindow) > 0;
		}

		// Token: 0x060010D1 RID: 4305 RVA: 0x0002D848 File Offset: 0x0002BA48
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qwdget_updatesEnabled = QWidget.__N.QWdget_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_updatesEnabled) > 0;
		}

		// Token: 0x060010D2 RID: 4306 RVA: 0x0002D878 File Offset: 0x0002BA78
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qwdget_setUpdatesEnabled = QWidget.__N.QWdget_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qwdget_setUpdatesEnabled);
		}

		// Token: 0x060010D3 RID: 4307 RVA: 0x0002D8AC File Offset: 0x0002BAAC
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qwdget_setFocus = QWidget.__N.QWdget_setFocus;
			calli(System.Void(System.IntPtr), this.self, qwdget_setFocus);
		}

		// Token: 0x060010D4 RID: 4308 RVA: 0x0002D8D8 File Offset: 0x0002BAD8
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qwdget_activateWindow = QWidget.__N.QWdget_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qwdget_activateWindow);
		}

		// Token: 0x060010D5 RID: 4309 RVA: 0x0002D904 File Offset: 0x0002BB04
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qwdget_clearFocus = QWidget.__N.QWdget_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qwdget_clearFocus);
		}

		// Token: 0x060010D6 RID: 4310 RVA: 0x0002D930 File Offset: 0x0002BB30
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qwdget_setSizePolicy = QWidget.__N.QWdget_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qwdget_setSizePolicy);
		}

		// Token: 0x060010D7 RID: 4311 RVA: 0x0002D960 File Offset: 0x0002BB60
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qwdget_devicePixelRatioF = QWidget.__N.QWdget_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qwdget_devicePixelRatioF);
		}

		// Token: 0x060010D8 RID: 4312 RVA: 0x0002D98C File Offset: 0x0002BB8C
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qwdget_saveGeometry = QWidget.__N.QWdget_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qwdget_saveGeometry));
		}

		// Token: 0x060010D9 RID: 4313 RVA: 0x0002D9BC File Offset: 0x0002BBBC
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qwdget_restoreGeometry = QWidget.__N.QWdget_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qwdget_restoreGeometry) > 0;
		}

		// Token: 0x060010DA RID: 4314 RVA: 0x0002D9F0 File Offset: 0x0002BBF0
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qwdget_addAction = QWidget.__N.QWdget_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qwdget_addAction);
		}

		// Token: 0x060010DB RID: 4315 RVA: 0x0002DA20 File Offset: 0x0002BC20
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qwdget_removeAction = QWidget.__N.QWdget_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qwdget_removeAction);
		}

		// Token: 0x060010DC RID: 4316 RVA: 0x0002DA50 File Offset: 0x0002BC50
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qwdget_setParent = QWidget.__N.QWdget_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qwdget_setParent);
		}

		// Token: 0x060010DD RID: 4317 RVA: 0x0002DA80 File Offset: 0x0002BC80
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qwdget_parentWidget = QWidget.__N.QWdget_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qwdget_parentWidget);
		}

		// Token: 0x060010DE RID: 4318 RVA: 0x0002DAB0 File Offset: 0x0002BCB0
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qwdget_AddClassName = QWidget.__N.QWdget_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qwdget_AddClassName);
		}

		// Token: 0x060010DF RID: 4319 RVA: 0x0002DAE0 File Offset: 0x0002BCE0
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qwdget_Polish = QWidget.__N.QWdget_Polish;
			calli(System.Void(System.IntPtr), this.self, qwdget_Polish);
		}

		// Token: 0x060010E0 RID: 4320 RVA: 0x0002DB0C File Offset: 0x0002BD0C
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qwdget_toolTip = QWidget.__N.QWdget_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qwdget_toolTip));
		}

		// Token: 0x060010E1 RID: 4321 RVA: 0x0002DB3C File Offset: 0x0002BD3C
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qwdget_setToolTip = QWidget.__N.QWdget_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qwdget_setToolTip);
		}

		// Token: 0x060010E2 RID: 4322 RVA: 0x0002DB6C File Offset: 0x0002BD6C
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qwdget_statusTip = QWidget.__N.QWdget_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qwdget_statusTip));
		}

		// Token: 0x060010E3 RID: 4323 RVA: 0x0002DB9C File Offset: 0x0002BD9C
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qwdget_setStatusTip = QWidget.__N.QWdget_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qwdget_setStatusTip);
		}

		// Token: 0x060010E4 RID: 4324 RVA: 0x0002DBCC File Offset: 0x0002BDCC
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qwdget_toolTipDuration = QWidget.__N.QWdget_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_toolTipDuration);
		}

		// Token: 0x060010E5 RID: 4325 RVA: 0x0002DBF8 File Offset: 0x0002BDF8
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qwdget_setToolTipDuration = QWidget.__N.QWdget_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qwdget_setToolTipDuration);
		}

		// Token: 0x060010E6 RID: 4326 RVA: 0x0002DC24 File Offset: 0x0002BE24
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qwdget_autoFillBackground = QWidget.__N.QWdget_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qwdget_autoFillBackground) > 0;
		}

		// Token: 0x060010E7 RID: 4327 RVA: 0x0002DC54 File Offset: 0x0002BE54
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qwdget_setAutoFillBackground = QWidget.__N.QWdget_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qwdget_setAutoFillBackground);
		}

		// Token: 0x060010E8 RID: 4328 RVA: 0x0002DC88 File Offset: 0x0002BE88
		internal readonly void deleteLater()
		{
			this.NullCheck("deleteLater");
			method qwdget_deleteLater = QWidget.__N.QWdget_deleteLater;
			calli(System.Void(System.IntPtr), this.self, qwdget_deleteLater);
		}

		// Token: 0x060010E9 RID: 4329 RVA: 0x0002DCB4 File Offset: 0x0002BEB4
		internal readonly string objectName()
		{
			this.NullCheck("objectName");
			method qwdget_objectName = QWidget.__N.QWdget_objectName;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qwdget_objectName));
		}

		// Token: 0x060010EA RID: 4330 RVA: 0x0002DCE4 File Offset: 0x0002BEE4
		internal readonly void setObjectName(string name)
		{
			this.NullCheck("setObjectName");
			method qwdget_setObjectName = QWidget.__N.QWdget_setObjectName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qwdget_setObjectName);
		}

		// Token: 0x060010EB RID: 4331 RVA: 0x0002DD14 File Offset: 0x0002BF14
		internal readonly void setProperty(string key, bool value)
		{
			this.NullCheck("setProperty");
			method qwdget_setProperty = QWidget.__N.QWdget_setProperty;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Int32), this.self, Interop.GetPointer(key), value ? 1 : 0, qwdget_setProperty);
		}

		// Token: 0x060010EC RID: 4332 RVA: 0x0002DD4C File Offset: 0x0002BF4C
		internal readonly void setProperty(string key, float value)
		{
			this.NullCheck("setProperty");
			method qwdget_f = QWidget.__N.QWdget_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.Single), this.self, Interop.GetPointer(key), value, qwdget_f);
		}

		// Token: 0x060010ED RID: 4333 RVA: 0x0002DD80 File Offset: 0x0002BF80
		internal readonly void setProperty(string key, string value)
		{
			this.NullCheck("setProperty");
			method qwdget_f = QWidget.__N.QWdget_f3;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(key), Interop.GetPointer(value), qwdget_f);
		}

		// Token: 0x04000069 RID: 105
		internal IntPtr self;

		// Token: 0x0200012A RID: 298
		internal static class __N
		{
			// Token: 0x040011E9 RID: 4585
			internal static method From_QObject_To_QWidget;

			// Token: 0x040011EA RID: 4586
			internal static method To_QObject_From_QWidget;

			// Token: 0x040011EB RID: 4587
			internal static method QWdget_CreateWidget;

			// Token: 0x040011EC RID: 4588
			internal static method QWdget_isTopLevel;

			// Token: 0x040011ED RID: 4589
			internal static method QWdget_isWindow;

			// Token: 0x040011EE RID: 4590
			internal static method QWdget_isModal;

			// Token: 0x040011EF RID: 4591
			internal static method QWdget_setStyleSheet;

			// Token: 0x040011F0 RID: 4592
			internal static method QWdget_windowTitle;

			// Token: 0x040011F1 RID: 4593
			internal static method QWdget_setWindowTitle;

			// Token: 0x040011F2 RID: 4594
			internal static method QWdget_setWindowFlags;

			// Token: 0x040011F3 RID: 4595
			internal static method QWdget_windowFlags;

			// Token: 0x040011F4 RID: 4596
			internal static method QWdget_size;

			// Token: 0x040011F5 RID: 4597
			internal static method QWdget_resize;

			// Token: 0x040011F6 RID: 4598
			internal static method QWdget_minimumSize;

			// Token: 0x040011F7 RID: 4599
			internal static method QWdget_setMinimumSize;

			// Token: 0x040011F8 RID: 4600
			internal static method QWdget_maximumSize;

			// Token: 0x040011F9 RID: 4601
			internal static method QWdget_setMaximumSize;

			// Token: 0x040011FA RID: 4602
			internal static method QWdget_pos;

			// Token: 0x040011FB RID: 4603
			internal static method QWdget_move;

			// Token: 0x040011FC RID: 4604
			internal static method QWdget_isEnabled;

			// Token: 0x040011FD RID: 4605
			internal static method QWdget_setEnabled;

			// Token: 0x040011FE RID: 4606
			internal static method QWdget_setVisible;

			// Token: 0x040011FF RID: 4607
			internal static method QWdget_setHidden;

			// Token: 0x04001200 RID: 4608
			internal static method QWdget_show;

			// Token: 0x04001201 RID: 4609
			internal static method QWdget_hide;

			// Token: 0x04001202 RID: 4610
			internal static method QWdget_showMinimized;

			// Token: 0x04001203 RID: 4611
			internal static method QWdget_showMaximized;

			// Token: 0x04001204 RID: 4612
			internal static method QWdget_showFullScreen;

			// Token: 0x04001205 RID: 4613
			internal static method QWdget_showNormal;

			// Token: 0x04001206 RID: 4614
			internal static method QWdget_close;

			// Token: 0x04001207 RID: 4615
			internal static method QWdget_raise;

			// Token: 0x04001208 RID: 4616
			internal static method QWdget_lower;

			// Token: 0x04001209 RID: 4617
			internal static method QWdget_isVisible;

			// Token: 0x0400120A RID: 4618
			internal static method QWdget_setAttribute;

			// Token: 0x0400120B RID: 4619
			internal static method QWdget_testAttribute;

			// Token: 0x0400120C RID: 4620
			internal static method QWdget_acceptDrops;

			// Token: 0x0400120D RID: 4621
			internal static method QWdget_setAcceptDrops;

			// Token: 0x0400120E RID: 4622
			internal static method QWdget_update;

			// Token: 0x0400120F RID: 4623
			internal static method QWdget_repaint;

			// Token: 0x04001210 RID: 4624
			internal static method QWdget_setCursor;

			// Token: 0x04001211 RID: 4625
			internal static method QWdget_unsetCursor;

			// Token: 0x04001212 RID: 4626
			internal static method QWdget_setWindowIcon;

			// Token: 0x04001213 RID: 4627
			internal static method QWdget_setWindowIconText;

			// Token: 0x04001214 RID: 4628
			internal static method QWdget_setWindowOpacity;

			// Token: 0x04001215 RID: 4629
			internal static method QWdget_windowOpacity;

			// Token: 0x04001216 RID: 4630
			internal static method QWdget_isMinimized;

			// Token: 0x04001217 RID: 4631
			internal static method QWdget_isMaximized;

			// Token: 0x04001218 RID: 4632
			internal static method QWdget_isFullScreen;

			// Token: 0x04001219 RID: 4633
			internal static method QWdget_setMouseTracking;

			// Token: 0x0400121A RID: 4634
			internal static method QWdget_hasMouseTracking;

			// Token: 0x0400121B RID: 4635
			internal static method QWdget_underMouse;

			// Token: 0x0400121C RID: 4636
			internal static method QWdget_mapToGlobal;

			// Token: 0x0400121D RID: 4637
			internal static method QWdget_mapFromGlobal;

			// Token: 0x0400121E RID: 4638
			internal static method QWdget_hasFocus;

			// Token: 0x0400121F RID: 4639
			internal static method QWdget_focusPolicy;

			// Token: 0x04001220 RID: 4640
			internal static method QWdget_setFocusPolicy;

			// Token: 0x04001221 RID: 4641
			internal static method QWdget_setFocusProxy;

			// Token: 0x04001222 RID: 4642
			internal static method QWdget_isActiveWindow;

			// Token: 0x04001223 RID: 4643
			internal static method QWdget_updatesEnabled;

			// Token: 0x04001224 RID: 4644
			internal static method QWdget_setUpdatesEnabled;

			// Token: 0x04001225 RID: 4645
			internal static method QWdget_setFocus;

			// Token: 0x04001226 RID: 4646
			internal static method QWdget_activateWindow;

			// Token: 0x04001227 RID: 4647
			internal static method QWdget_clearFocus;

			// Token: 0x04001228 RID: 4648
			internal static method QWdget_setSizePolicy;

			// Token: 0x04001229 RID: 4649
			internal static method QWdget_devicePixelRatioF;

			// Token: 0x0400122A RID: 4650
			internal static method QWdget_saveGeometry;

			// Token: 0x0400122B RID: 4651
			internal static method QWdget_restoreGeometry;

			// Token: 0x0400122C RID: 4652
			internal static method QWdget_addAction;

			// Token: 0x0400122D RID: 4653
			internal static method QWdget_removeAction;

			// Token: 0x0400122E RID: 4654
			internal static method QWdget_setParent;

			// Token: 0x0400122F RID: 4655
			internal static method QWdget_parentWidget;

			// Token: 0x04001230 RID: 4656
			internal static method QWdget_AddClassName;

			// Token: 0x04001231 RID: 4657
			internal static method QWdget_Polish;

			// Token: 0x04001232 RID: 4658
			internal static method QWdget_toolTip;

			// Token: 0x04001233 RID: 4659
			internal static method QWdget_setToolTip;

			// Token: 0x04001234 RID: 4660
			internal static method QWdget_statusTip;

			// Token: 0x04001235 RID: 4661
			internal static method QWdget_setStatusTip;

			// Token: 0x04001236 RID: 4662
			internal static method QWdget_toolTipDuration;

			// Token: 0x04001237 RID: 4663
			internal static method QWdget_setToolTipDuration;

			// Token: 0x04001238 RID: 4664
			internal static method QWdget_autoFillBackground;

			// Token: 0x04001239 RID: 4665
			internal static method QWdget_setAutoFillBackground;

			// Token: 0x0400123A RID: 4666
			internal static method QWdget_deleteLater;

			// Token: 0x0400123B RID: 4667
			internal static method QWdget_objectName;

			// Token: 0x0400123C RID: 4668
			internal static method QWdget_setObjectName;

			// Token: 0x0400123D RID: 4669
			internal static method QWdget_setProperty;

			// Token: 0x0400123E RID: 4670
			internal static method QWdget_f2;

			// Token: 0x0400123F RID: 4671
			internal static method QWdget_f3;
		}
	}
}
