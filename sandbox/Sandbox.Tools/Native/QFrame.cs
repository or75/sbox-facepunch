using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000046 RID: 70
	internal struct QFrame
	{
		// Token: 0x06000869 RID: 2153 RVA: 0x00016EA9 File Offset: 0x000150A9
		public static implicit operator IntPtr(QFrame value)
		{
			return value.self;
		}

		// Token: 0x0600086A RID: 2154 RVA: 0x00016EB4 File Offset: 0x000150B4
		public static implicit operator QFrame(IntPtr value)
		{
			return new QFrame
			{
				self = value
			};
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x00016ED2 File Offset: 0x000150D2
		public static bool operator ==(QFrame c1, QFrame c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x00016EE5 File Offset: 0x000150E5
		public static bool operator !=(QFrame c1, QFrame c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600086D RID: 2157 RVA: 0x00016EF8 File Offset: 0x000150F8
		public override bool Equals(object obj)
		{
			if (obj is QFrame)
			{
				QFrame c = (QFrame)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600086E RID: 2158 RVA: 0x00016F22 File Offset: 0x00015122
		internal QFrame(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600086F RID: 2159 RVA: 0x00016F2C File Offset: 0x0001512C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QFrame ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x06000870 RID: 2160 RVA: 0x00016F67 File Offset: 0x00015167
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x06000871 RID: 2161 RVA: 0x00016F79 File Offset: 0x00015179
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x00016F84 File Offset: 0x00015184
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00016F97 File Offset: 0x00015197
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QFrame was null when calling " + n);
			}
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00016FB2 File Offset: 0x000151B2
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00016FC0 File Offset: 0x000151C0
		public static implicit operator QWidget(QFrame value)
		{
			method to_QWidget_From_QFrame = QFrame.__N.To_QWidget_From_QFrame;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QFrame);
		}

		// Token: 0x06000876 RID: 2166 RVA: 0x00016FE4 File Offset: 0x000151E4
		public static explicit operator QFrame(QWidget value)
		{
			method from_QWidget_To_QFrame = QFrame.__N.From_QWidget_To_QFrame;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QFrame);
		}

		// Token: 0x06000877 RID: 2167 RVA: 0x00017008 File Offset: 0x00015208
		public static implicit operator QObject(QFrame value)
		{
			method to_QObject_From_QFrame = QFrame.__N.To_QObject_From_QFrame;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QFrame);
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x0001702C File Offset: 0x0001522C
		public static explicit operator QFrame(QObject value)
		{
			method from_QObject_To_QFrame = QFrame.__N.From_QObject_To_QFrame;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QFrame);
		}

		// Token: 0x06000879 RID: 2169 RVA: 0x00017050 File Offset: 0x00015250
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qframe_isTopLevel = QFrame.__N.QFrame_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qframe_isTopLevel) > 0;
		}

		// Token: 0x0600087A RID: 2170 RVA: 0x00017080 File Offset: 0x00015280
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qframe_isWindow = QFrame.__N.QFrame_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qframe_isWindow) > 0;
		}

		// Token: 0x0600087B RID: 2171 RVA: 0x000170B0 File Offset: 0x000152B0
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qframe_isModal = QFrame.__N.QFrame_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qframe_isModal) > 0;
		}

		// Token: 0x0600087C RID: 2172 RVA: 0x000170E0 File Offset: 0x000152E0
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qframe_setStyleSheet = QFrame.__N.QFrame_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qframe_setStyleSheet);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00017110 File Offset: 0x00015310
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qframe_windowTitle = QFrame.__N.QFrame_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qframe_windowTitle));
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x00017140 File Offset: 0x00015340
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qframe_setWindowTitle = QFrame.__N.QFrame_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qframe_setWindowTitle);
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00017170 File Offset: 0x00015370
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qframe_setWindowFlags = QFrame.__N.QFrame_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qframe_setWindowFlags);
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x0001719C File Offset: 0x0001539C
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qframe_windowFlags = QFrame.__N.QFrame_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qframe_windowFlags);
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x000171C8 File Offset: 0x000153C8
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qframe_size = QFrame.__N.QFrame_size;
			return calli(Vector3(System.IntPtr), this.self, qframe_size);
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x000171F4 File Offset: 0x000153F4
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qframe_resize = QFrame.__N.QFrame_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qframe_resize);
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x00017220 File Offset: 0x00015420
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qframe_minimumSize = QFrame.__N.QFrame_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qframe_minimumSize);
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x0001724C File Offset: 0x0001544C
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qframe_setMinimumSize = QFrame.__N.QFrame_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qframe_setMinimumSize);
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x00017278 File Offset: 0x00015478
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qframe_maximumSize = QFrame.__N.QFrame_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qframe_maximumSize);
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x000172A4 File Offset: 0x000154A4
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qframe_setMaximumSize = QFrame.__N.QFrame_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qframe_setMaximumSize);
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x000172D0 File Offset: 0x000154D0
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qframe_pos = QFrame.__N.QFrame_pos;
			return calli(Vector3(System.IntPtr), this.self, qframe_pos);
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x000172FC File Offset: 0x000154FC
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qframe_move = QFrame.__N.QFrame_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qframe_move);
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00017328 File Offset: 0x00015528
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qframe_isEnabled = QFrame.__N.QFrame_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qframe_isEnabled) > 0;
		}

		// Token: 0x0600088A RID: 2186 RVA: 0x00017358 File Offset: 0x00015558
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qframe_setEnabled = QFrame.__N.QFrame_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qframe_setEnabled);
		}

		// Token: 0x0600088B RID: 2187 RVA: 0x0001738C File Offset: 0x0001558C
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qframe_setVisible = QFrame.__N.QFrame_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qframe_setVisible);
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x000173C0 File Offset: 0x000155C0
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qframe_setHidden = QFrame.__N.QFrame_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qframe_setHidden);
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x000173F4 File Offset: 0x000155F4
		internal readonly void show()
		{
			this.NullCheck("show");
			method qframe_show = QFrame.__N.QFrame_show;
			calli(System.Void(System.IntPtr), this.self, qframe_show);
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x00017420 File Offset: 0x00015620
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qframe_hide = QFrame.__N.QFrame_hide;
			calli(System.Void(System.IntPtr), this.self, qframe_hide);
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0001744C File Offset: 0x0001564C
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qframe_showMinimized = QFrame.__N.QFrame_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qframe_showMinimized);
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x00017478 File Offset: 0x00015678
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qframe_showMaximized = QFrame.__N.QFrame_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qframe_showMaximized);
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x000174A4 File Offset: 0x000156A4
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qframe_showFullScreen = QFrame.__N.QFrame_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qframe_showFullScreen);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x000174D0 File Offset: 0x000156D0
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qframe_showNormal = QFrame.__N.QFrame_showNormal;
			calli(System.Void(System.IntPtr), this.self, qframe_showNormal);
		}

		// Token: 0x06000893 RID: 2195 RVA: 0x000174FC File Offset: 0x000156FC
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qframe_close = QFrame.__N.QFrame_close;
			return calli(System.Int32(System.IntPtr), this.self, qframe_close) > 0;
		}

		// Token: 0x06000894 RID: 2196 RVA: 0x0001752C File Offset: 0x0001572C
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qframe_raise = QFrame.__N.QFrame_raise;
			calli(System.Void(System.IntPtr), this.self, qframe_raise);
		}

		// Token: 0x06000895 RID: 2197 RVA: 0x00017558 File Offset: 0x00015758
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qframe_lower = QFrame.__N.QFrame_lower;
			calli(System.Void(System.IntPtr), this.self, qframe_lower);
		}

		// Token: 0x06000896 RID: 2198 RVA: 0x00017584 File Offset: 0x00015784
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qframe_isVisible = QFrame.__N.QFrame_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qframe_isVisible) > 0;
		}

		// Token: 0x06000897 RID: 2199 RVA: 0x000175B4 File Offset: 0x000157B4
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qframe_setAttribute = QFrame.__N.QFrame_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qframe_setAttribute);
		}

		// Token: 0x06000898 RID: 2200 RVA: 0x000175E8 File Offset: 0x000157E8
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qframe_testAttribute = QFrame.__N.QFrame_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qframe_testAttribute) > 0;
		}

		// Token: 0x06000899 RID: 2201 RVA: 0x00017618 File Offset: 0x00015818
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qframe_acceptDrops = QFrame.__N.QFrame_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qframe_acceptDrops) > 0;
		}

		// Token: 0x0600089A RID: 2202 RVA: 0x00017648 File Offset: 0x00015848
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qframe_setAcceptDrops = QFrame.__N.QFrame_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qframe_setAcceptDrops);
		}

		// Token: 0x0600089B RID: 2203 RVA: 0x0001767C File Offset: 0x0001587C
		internal readonly void update()
		{
			this.NullCheck("update");
			method qframe_update = QFrame.__N.QFrame_update;
			calli(System.Void(System.IntPtr), this.self, qframe_update);
		}

		// Token: 0x0600089C RID: 2204 RVA: 0x000176A8 File Offset: 0x000158A8
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qframe_repaint = QFrame.__N.QFrame_repaint;
			calli(System.Void(System.IntPtr), this.self, qframe_repaint);
		}

		// Token: 0x0600089D RID: 2205 RVA: 0x000176D4 File Offset: 0x000158D4
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qframe_setCursor = QFrame.__N.QFrame_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qframe_setCursor);
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00017700 File Offset: 0x00015900
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qframe_unsetCursor = QFrame.__N.QFrame_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qframe_unsetCursor);
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x0001772C File Offset: 0x0001592C
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qframe_setWindowIcon = QFrame.__N.QFrame_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qframe_setWindowIcon);
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x0001775C File Offset: 0x0001595C
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qframe_setWindowIconText = QFrame.__N.QFrame_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qframe_setWindowIconText);
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x0001778C File Offset: 0x0001598C
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qframe_setWindowOpacity = QFrame.__N.QFrame_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qframe_setWindowOpacity);
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x000177B8 File Offset: 0x000159B8
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qframe_windowOpacity = QFrame.__N.QFrame_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qframe_windowOpacity);
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x000177E4 File Offset: 0x000159E4
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qframe_isMinimized = QFrame.__N.QFrame_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qframe_isMinimized) > 0;
		}

		// Token: 0x060008A4 RID: 2212 RVA: 0x00017814 File Offset: 0x00015A14
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qframe_isMaximized = QFrame.__N.QFrame_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qframe_isMaximized) > 0;
		}

		// Token: 0x060008A5 RID: 2213 RVA: 0x00017844 File Offset: 0x00015A44
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qframe_isFullScreen = QFrame.__N.QFrame_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qframe_isFullScreen) > 0;
		}

		// Token: 0x060008A6 RID: 2214 RVA: 0x00017874 File Offset: 0x00015A74
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qframe_setMouseTracking = QFrame.__N.QFrame_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qframe_setMouseTracking);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x000178A8 File Offset: 0x00015AA8
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qframe_hasMouseTracking = QFrame.__N.QFrame_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qframe_hasMouseTracking) > 0;
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x000178D8 File Offset: 0x00015AD8
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qframe_underMouse = QFrame.__N.QFrame_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qframe_underMouse) > 0;
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00017908 File Offset: 0x00015B08
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qframe_mapToGlobal = QFrame.__N.QFrame_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qframe_mapToGlobal);
		}

		// Token: 0x060008AA RID: 2218 RVA: 0x00017934 File Offset: 0x00015B34
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qframe_mapFromGlobal = QFrame.__N.QFrame_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qframe_mapFromGlobal);
		}

		// Token: 0x060008AB RID: 2219 RVA: 0x00017960 File Offset: 0x00015B60
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qframe_hasFocus = QFrame.__N.QFrame_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qframe_hasFocus) > 0;
		}

		// Token: 0x060008AC RID: 2220 RVA: 0x00017990 File Offset: 0x00015B90
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qframe_focusPolicy = QFrame.__N.QFrame_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qframe_focusPolicy);
		}

		// Token: 0x060008AD RID: 2221 RVA: 0x000179BC File Offset: 0x00015BBC
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qframe_setFocusPolicy = QFrame.__N.QFrame_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qframe_setFocusPolicy);
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x000179E8 File Offset: 0x00015BE8
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qframe_setFocusProxy = QFrame.__N.QFrame_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qframe_setFocusProxy);
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x00017A18 File Offset: 0x00015C18
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qframe_isActiveWindow = QFrame.__N.QFrame_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qframe_isActiveWindow) > 0;
		}

		// Token: 0x060008B0 RID: 2224 RVA: 0x00017A48 File Offset: 0x00015C48
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qframe_updatesEnabled = QFrame.__N.QFrame_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qframe_updatesEnabled) > 0;
		}

		// Token: 0x060008B1 RID: 2225 RVA: 0x00017A78 File Offset: 0x00015C78
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qframe_setUpdatesEnabled = QFrame.__N.QFrame_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qframe_setUpdatesEnabled);
		}

		// Token: 0x060008B2 RID: 2226 RVA: 0x00017AAC File Offset: 0x00015CAC
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qframe_setFocus = QFrame.__N.QFrame_setFocus;
			calli(System.Void(System.IntPtr), this.self, qframe_setFocus);
		}

		// Token: 0x060008B3 RID: 2227 RVA: 0x00017AD8 File Offset: 0x00015CD8
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qframe_activateWindow = QFrame.__N.QFrame_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qframe_activateWindow);
		}

		// Token: 0x060008B4 RID: 2228 RVA: 0x00017B04 File Offset: 0x00015D04
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qframe_clearFocus = QFrame.__N.QFrame_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qframe_clearFocus);
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00017B30 File Offset: 0x00015D30
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qframe_setSizePolicy = QFrame.__N.QFrame_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qframe_setSizePolicy);
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00017B60 File Offset: 0x00015D60
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qframe_devicePixelRatioF = QFrame.__N.QFrame_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qframe_devicePixelRatioF);
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00017B8C File Offset: 0x00015D8C
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qframe_saveGeometry = QFrame.__N.QFrame_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qframe_saveGeometry));
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x00017BBC File Offset: 0x00015DBC
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qframe_restoreGeometry = QFrame.__N.QFrame_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qframe_restoreGeometry) > 0;
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00017BF0 File Offset: 0x00015DF0
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qframe_addAction = QFrame.__N.QFrame_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qframe_addAction);
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x00017C20 File Offset: 0x00015E20
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qframe_removeAction = QFrame.__N.QFrame_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qframe_removeAction);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x00017C50 File Offset: 0x00015E50
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qframe_setParent = QFrame.__N.QFrame_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qframe_setParent);
		}

		// Token: 0x060008BC RID: 2236 RVA: 0x00017C80 File Offset: 0x00015E80
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qframe_parentWidget = QFrame.__N.QFrame_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qframe_parentWidget);
		}

		// Token: 0x060008BD RID: 2237 RVA: 0x00017CB0 File Offset: 0x00015EB0
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qframe_AddClassName = QFrame.__N.QFrame_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qframe_AddClassName);
		}

		// Token: 0x060008BE RID: 2238 RVA: 0x00017CE0 File Offset: 0x00015EE0
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qframe_Polish = QFrame.__N.QFrame_Polish;
			calli(System.Void(System.IntPtr), this.self, qframe_Polish);
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00017D0C File Offset: 0x00015F0C
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qframe_toolTip = QFrame.__N.QFrame_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qframe_toolTip));
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00017D3C File Offset: 0x00015F3C
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qframe_setToolTip = QFrame.__N.QFrame_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qframe_setToolTip);
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x00017D6C File Offset: 0x00015F6C
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qframe_statusTip = QFrame.__N.QFrame_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qframe_statusTip));
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00017D9C File Offset: 0x00015F9C
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qframe_setStatusTip = QFrame.__N.QFrame_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qframe_setStatusTip);
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x00017DCC File Offset: 0x00015FCC
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qframe_toolTipDuration = QFrame.__N.QFrame_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qframe_toolTipDuration);
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x00017DF8 File Offset: 0x00015FF8
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qframe_setToolTipDuration = QFrame.__N.QFrame_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qframe_setToolTipDuration);
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x00017E24 File Offset: 0x00016024
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qframe_autoFillBackground = QFrame.__N.QFrame_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qframe_autoFillBackground) > 0;
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x00017E54 File Offset: 0x00016054
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qframe_setAutoFillBackground = QFrame.__N.QFrame_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qframe_setAutoFillBackground);
		}

		// Token: 0x04000051 RID: 81
		internal IntPtr self;

		// Token: 0x02000112 RID: 274
		internal static class __N
		{
			// Token: 0x04000AE7 RID: 2791
			internal static method From_QWidget_To_QFrame;

			// Token: 0x04000AE8 RID: 2792
			internal static method To_QWidget_From_QFrame;

			// Token: 0x04000AE9 RID: 2793
			internal static method From_QObject_To_QFrame;

			// Token: 0x04000AEA RID: 2794
			internal static method To_QObject_From_QFrame;

			// Token: 0x04000AEB RID: 2795
			internal static method QFrame_isTopLevel;

			// Token: 0x04000AEC RID: 2796
			internal static method QFrame_isWindow;

			// Token: 0x04000AED RID: 2797
			internal static method QFrame_isModal;

			// Token: 0x04000AEE RID: 2798
			internal static method QFrame_setStyleSheet;

			// Token: 0x04000AEF RID: 2799
			internal static method QFrame_windowTitle;

			// Token: 0x04000AF0 RID: 2800
			internal static method QFrame_setWindowTitle;

			// Token: 0x04000AF1 RID: 2801
			internal static method QFrame_setWindowFlags;

			// Token: 0x04000AF2 RID: 2802
			internal static method QFrame_windowFlags;

			// Token: 0x04000AF3 RID: 2803
			internal static method QFrame_size;

			// Token: 0x04000AF4 RID: 2804
			internal static method QFrame_resize;

			// Token: 0x04000AF5 RID: 2805
			internal static method QFrame_minimumSize;

			// Token: 0x04000AF6 RID: 2806
			internal static method QFrame_setMinimumSize;

			// Token: 0x04000AF7 RID: 2807
			internal static method QFrame_maximumSize;

			// Token: 0x04000AF8 RID: 2808
			internal static method QFrame_setMaximumSize;

			// Token: 0x04000AF9 RID: 2809
			internal static method QFrame_pos;

			// Token: 0x04000AFA RID: 2810
			internal static method QFrame_move;

			// Token: 0x04000AFB RID: 2811
			internal static method QFrame_isEnabled;

			// Token: 0x04000AFC RID: 2812
			internal static method QFrame_setEnabled;

			// Token: 0x04000AFD RID: 2813
			internal static method QFrame_setVisible;

			// Token: 0x04000AFE RID: 2814
			internal static method QFrame_setHidden;

			// Token: 0x04000AFF RID: 2815
			internal static method QFrame_show;

			// Token: 0x04000B00 RID: 2816
			internal static method QFrame_hide;

			// Token: 0x04000B01 RID: 2817
			internal static method QFrame_showMinimized;

			// Token: 0x04000B02 RID: 2818
			internal static method QFrame_showMaximized;

			// Token: 0x04000B03 RID: 2819
			internal static method QFrame_showFullScreen;

			// Token: 0x04000B04 RID: 2820
			internal static method QFrame_showNormal;

			// Token: 0x04000B05 RID: 2821
			internal static method QFrame_close;

			// Token: 0x04000B06 RID: 2822
			internal static method QFrame_raise;

			// Token: 0x04000B07 RID: 2823
			internal static method QFrame_lower;

			// Token: 0x04000B08 RID: 2824
			internal static method QFrame_isVisible;

			// Token: 0x04000B09 RID: 2825
			internal static method QFrame_setAttribute;

			// Token: 0x04000B0A RID: 2826
			internal static method QFrame_testAttribute;

			// Token: 0x04000B0B RID: 2827
			internal static method QFrame_acceptDrops;

			// Token: 0x04000B0C RID: 2828
			internal static method QFrame_setAcceptDrops;

			// Token: 0x04000B0D RID: 2829
			internal static method QFrame_update;

			// Token: 0x04000B0E RID: 2830
			internal static method QFrame_repaint;

			// Token: 0x04000B0F RID: 2831
			internal static method QFrame_setCursor;

			// Token: 0x04000B10 RID: 2832
			internal static method QFrame_unsetCursor;

			// Token: 0x04000B11 RID: 2833
			internal static method QFrame_setWindowIcon;

			// Token: 0x04000B12 RID: 2834
			internal static method QFrame_setWindowIconText;

			// Token: 0x04000B13 RID: 2835
			internal static method QFrame_setWindowOpacity;

			// Token: 0x04000B14 RID: 2836
			internal static method QFrame_windowOpacity;

			// Token: 0x04000B15 RID: 2837
			internal static method QFrame_isMinimized;

			// Token: 0x04000B16 RID: 2838
			internal static method QFrame_isMaximized;

			// Token: 0x04000B17 RID: 2839
			internal static method QFrame_isFullScreen;

			// Token: 0x04000B18 RID: 2840
			internal static method QFrame_setMouseTracking;

			// Token: 0x04000B19 RID: 2841
			internal static method QFrame_hasMouseTracking;

			// Token: 0x04000B1A RID: 2842
			internal static method QFrame_underMouse;

			// Token: 0x04000B1B RID: 2843
			internal static method QFrame_mapToGlobal;

			// Token: 0x04000B1C RID: 2844
			internal static method QFrame_mapFromGlobal;

			// Token: 0x04000B1D RID: 2845
			internal static method QFrame_hasFocus;

			// Token: 0x04000B1E RID: 2846
			internal static method QFrame_focusPolicy;

			// Token: 0x04000B1F RID: 2847
			internal static method QFrame_setFocusPolicy;

			// Token: 0x04000B20 RID: 2848
			internal static method QFrame_setFocusProxy;

			// Token: 0x04000B21 RID: 2849
			internal static method QFrame_isActiveWindow;

			// Token: 0x04000B22 RID: 2850
			internal static method QFrame_updatesEnabled;

			// Token: 0x04000B23 RID: 2851
			internal static method QFrame_setUpdatesEnabled;

			// Token: 0x04000B24 RID: 2852
			internal static method QFrame_setFocus;

			// Token: 0x04000B25 RID: 2853
			internal static method QFrame_activateWindow;

			// Token: 0x04000B26 RID: 2854
			internal static method QFrame_clearFocus;

			// Token: 0x04000B27 RID: 2855
			internal static method QFrame_setSizePolicy;

			// Token: 0x04000B28 RID: 2856
			internal static method QFrame_devicePixelRatioF;

			// Token: 0x04000B29 RID: 2857
			internal static method QFrame_saveGeometry;

			// Token: 0x04000B2A RID: 2858
			internal static method QFrame_restoreGeometry;

			// Token: 0x04000B2B RID: 2859
			internal static method QFrame_addAction;

			// Token: 0x04000B2C RID: 2860
			internal static method QFrame_removeAction;

			// Token: 0x04000B2D RID: 2861
			internal static method QFrame_setParent;

			// Token: 0x04000B2E RID: 2862
			internal static method QFrame_parentWidget;

			// Token: 0x04000B2F RID: 2863
			internal static method QFrame_AddClassName;

			// Token: 0x04000B30 RID: 2864
			internal static method QFrame_Polish;

			// Token: 0x04000B31 RID: 2865
			internal static method QFrame_toolTip;

			// Token: 0x04000B32 RID: 2866
			internal static method QFrame_setToolTip;

			// Token: 0x04000B33 RID: 2867
			internal static method QFrame_statusTip;

			// Token: 0x04000B34 RID: 2868
			internal static method QFrame_setStatusTip;

			// Token: 0x04000B35 RID: 2869
			internal static method QFrame_toolTipDuration;

			// Token: 0x04000B36 RID: 2870
			internal static method QFrame_setToolTipDuration;

			// Token: 0x04000B37 RID: 2871
			internal static method QFrame_autoFillBackground;

			// Token: 0x04000B38 RID: 2872
			internal static method QFrame_setAutoFillBackground;
		}
	}
}
