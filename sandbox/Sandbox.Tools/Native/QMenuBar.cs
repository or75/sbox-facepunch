using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000052 RID: 82
	internal struct QMenuBar
	{
		// Token: 0x06000C55 RID: 3157 RVA: 0x000216F9 File Offset: 0x0001F8F9
		public static implicit operator IntPtr(QMenuBar value)
		{
			return value.self;
		}

		// Token: 0x06000C56 RID: 3158 RVA: 0x00021704 File Offset: 0x0001F904
		public static implicit operator QMenuBar(IntPtr value)
		{
			return new QMenuBar
			{
				self = value
			};
		}

		// Token: 0x06000C57 RID: 3159 RVA: 0x00021722 File Offset: 0x0001F922
		public static bool operator ==(QMenuBar c1, QMenuBar c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x00021735 File Offset: 0x0001F935
		public static bool operator !=(QMenuBar c1, QMenuBar c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x00021748 File Offset: 0x0001F948
		public override bool Equals(object obj)
		{
			if (obj is QMenuBar)
			{
				QMenuBar c = (QMenuBar)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x00021772 File Offset: 0x0001F972
		internal QMenuBar(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x0002177C File Offset: 0x0001F97C
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QMenuBar ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000C5C RID: 3164 RVA: 0x000217B8 File Offset: 0x0001F9B8
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x06000C5D RID: 3165 RVA: 0x000217CA File Offset: 0x0001F9CA
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x000217D5 File Offset: 0x0001F9D5
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x000217E8 File Offset: 0x0001F9E8
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QMenuBar was null when calling " + n);
			}
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x00021803 File Offset: 0x0001FA03
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x00021810 File Offset: 0x0001FA10
		public static implicit operator QWidget(QMenuBar value)
		{
			method to_QWidget_From_QMenuBar = QMenuBar.__N.To_QWidget_From_QMenuBar;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QMenuBar);
		}

		// Token: 0x06000C62 RID: 3170 RVA: 0x00021834 File Offset: 0x0001FA34
		public static explicit operator QMenuBar(QWidget value)
		{
			method from_QWidget_To_QMenuBar = QMenuBar.__N.From_QWidget_To_QMenuBar;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QMenuBar);
		}

		// Token: 0x06000C63 RID: 3171 RVA: 0x00021858 File Offset: 0x0001FA58
		public static implicit operator QObject(QMenuBar value)
		{
			method to_QObject_From_QMenuBar = QMenuBar.__N.To_QObject_From_QMenuBar;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QMenuBar);
		}

		// Token: 0x06000C64 RID: 3172 RVA: 0x0002187C File Offset: 0x0001FA7C
		public static explicit operator QMenuBar(QObject value)
		{
			method from_QObject_To_QMenuBar = QMenuBar.__N.From_QObject_To_QMenuBar;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QMenuBar);
		}

		// Token: 0x06000C65 RID: 3173 RVA: 0x000218A0 File Offset: 0x0001FAA0
		internal readonly void insertAction(QAction before, QAction action)
		{
			this.NullCheck("insertAction");
			method qmenBr_insertAction = QMenuBar.__N.QMenBr_insertAction;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, before, action, qmenBr_insertAction);
		}

		// Token: 0x06000C66 RID: 3174 RVA: 0x000218D8 File Offset: 0x0001FAD8
		internal readonly QAction addMenu(QMenu menu)
		{
			this.NullCheck("addMenu");
			method qmenBr_addMenu = QMenuBar.__N.QMenBr_addMenu;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr), this.self, menu, qmenBr_addMenu);
		}

		// Token: 0x06000C67 RID: 3175 RVA: 0x00021910 File Offset: 0x0001FB10
		internal readonly QAction insertMenu(QAction before, QMenu menu)
		{
			this.NullCheck("insertMenu");
			method qmenBr_insertMenu = QMenuBar.__N.QMenBr_insertMenu;
			return calli(System.IntPtr(System.IntPtr,System.IntPtr,System.IntPtr), this.self, before, menu, qmenBr_insertMenu);
		}

		// Token: 0x06000C68 RID: 3176 RVA: 0x0002194C File Offset: 0x0001FB4C
		internal readonly QAction addSeparator()
		{
			this.NullCheck("addSeparator");
			method qmenBr_addSeparator = QMenuBar.__N.QMenBr_addSeparator;
			return calli(System.IntPtr(System.IntPtr), this.self, qmenBr_addSeparator);
		}

		// Token: 0x06000C69 RID: 3177 RVA: 0x0002197C File Offset: 0x0001FB7C
		internal readonly void clear()
		{
			this.NullCheck("clear");
			method qmenBr_clear = QMenuBar.__N.QMenBr_clear;
			calli(System.Void(System.IntPtr), this.self, qmenBr_clear);
		}

		// Token: 0x06000C6A RID: 3178 RVA: 0x000219A8 File Offset: 0x0001FBA8
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qmenBr_isTopLevel = QMenuBar.__N.QMenBr_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_isTopLevel) > 0;
		}

		// Token: 0x06000C6B RID: 3179 RVA: 0x000219D8 File Offset: 0x0001FBD8
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qmenBr_isWindow = QMenuBar.__N.QMenBr_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_isWindow) > 0;
		}

		// Token: 0x06000C6C RID: 3180 RVA: 0x00021A08 File Offset: 0x0001FC08
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qmenBr_isModal = QMenuBar.__N.QMenBr_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_isModal) > 0;
		}

		// Token: 0x06000C6D RID: 3181 RVA: 0x00021A38 File Offset: 0x0001FC38
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qmenBr_setStyleSheet = QMenuBar.__N.QMenBr_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qmenBr_setStyleSheet);
		}

		// Token: 0x06000C6E RID: 3182 RVA: 0x00021A68 File Offset: 0x0001FC68
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qmenBr_windowTitle = QMenuBar.__N.QMenBr_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmenBr_windowTitle));
		}

		// Token: 0x06000C6F RID: 3183 RVA: 0x00021A98 File Offset: 0x0001FC98
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qmenBr_setWindowTitle = QMenuBar.__N.QMenBr_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qmenBr_setWindowTitle);
		}

		// Token: 0x06000C70 RID: 3184 RVA: 0x00021AC8 File Offset: 0x0001FCC8
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qmenBr_setWindowFlags = QMenuBar.__N.QMenBr_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qmenBr_setWindowFlags);
		}

		// Token: 0x06000C71 RID: 3185 RVA: 0x00021AF4 File Offset: 0x0001FCF4
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qmenBr_windowFlags = QMenuBar.__N.QMenBr_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qmenBr_windowFlags);
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x00021B20 File Offset: 0x0001FD20
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qmenBr_size = QMenuBar.__N.QMenBr_size;
			return calli(Vector3(System.IntPtr), this.self, qmenBr_size);
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x00021B4C File Offset: 0x0001FD4C
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qmenBr_resize = QMenuBar.__N.QMenBr_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmenBr_resize);
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x00021B78 File Offset: 0x0001FD78
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qmenBr_minimumSize = QMenuBar.__N.QMenBr_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qmenBr_minimumSize);
		}

		// Token: 0x06000C75 RID: 3189 RVA: 0x00021BA4 File Offset: 0x0001FDA4
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qmenBr_setMinimumSize = QMenuBar.__N.QMenBr_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmenBr_setMinimumSize);
		}

		// Token: 0x06000C76 RID: 3190 RVA: 0x00021BD0 File Offset: 0x0001FDD0
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qmenBr_maximumSize = QMenuBar.__N.QMenBr_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qmenBr_maximumSize);
		}

		// Token: 0x06000C77 RID: 3191 RVA: 0x00021BFC File Offset: 0x0001FDFC
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qmenBr_setMaximumSize = QMenuBar.__N.QMenBr_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmenBr_setMaximumSize);
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x00021C28 File Offset: 0x0001FE28
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qmenBr_pos = QMenuBar.__N.QMenBr_pos;
			return calli(Vector3(System.IntPtr), this.self, qmenBr_pos);
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x00021C54 File Offset: 0x0001FE54
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qmenBr_move = QMenuBar.__N.QMenBr_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qmenBr_move);
		}

		// Token: 0x06000C7A RID: 3194 RVA: 0x00021C80 File Offset: 0x0001FE80
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qmenBr_isEnabled = QMenuBar.__N.QMenBr_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_isEnabled) > 0;
		}

		// Token: 0x06000C7B RID: 3195 RVA: 0x00021CB0 File Offset: 0x0001FEB0
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qmenBr_setEnabled = QMenuBar.__N.QMenBr_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qmenBr_setEnabled);
		}

		// Token: 0x06000C7C RID: 3196 RVA: 0x00021CE4 File Offset: 0x0001FEE4
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qmenBr_setVisible = QMenuBar.__N.QMenBr_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qmenBr_setVisible);
		}

		// Token: 0x06000C7D RID: 3197 RVA: 0x00021D18 File Offset: 0x0001FF18
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qmenBr_setHidden = QMenuBar.__N.QMenBr_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qmenBr_setHidden);
		}

		// Token: 0x06000C7E RID: 3198 RVA: 0x00021D4C File Offset: 0x0001FF4C
		internal readonly void show()
		{
			this.NullCheck("show");
			method qmenBr_show = QMenuBar.__N.QMenBr_show;
			calli(System.Void(System.IntPtr), this.self, qmenBr_show);
		}

		// Token: 0x06000C7F RID: 3199 RVA: 0x00021D78 File Offset: 0x0001FF78
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qmenBr_hide = QMenuBar.__N.QMenBr_hide;
			calli(System.Void(System.IntPtr), this.self, qmenBr_hide);
		}

		// Token: 0x06000C80 RID: 3200 RVA: 0x00021DA4 File Offset: 0x0001FFA4
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qmenBr_showMinimized = QMenuBar.__N.QMenBr_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qmenBr_showMinimized);
		}

		// Token: 0x06000C81 RID: 3201 RVA: 0x00021DD0 File Offset: 0x0001FFD0
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qmenBr_showMaximized = QMenuBar.__N.QMenBr_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qmenBr_showMaximized);
		}

		// Token: 0x06000C82 RID: 3202 RVA: 0x00021DFC File Offset: 0x0001FFFC
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qmenBr_showFullScreen = QMenuBar.__N.QMenBr_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qmenBr_showFullScreen);
		}

		// Token: 0x06000C83 RID: 3203 RVA: 0x00021E28 File Offset: 0x00020028
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qmenBr_showNormal = QMenuBar.__N.QMenBr_showNormal;
			calli(System.Void(System.IntPtr), this.self, qmenBr_showNormal);
		}

		// Token: 0x06000C84 RID: 3204 RVA: 0x00021E54 File Offset: 0x00020054
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qmenBr_close = QMenuBar.__N.QMenBr_close;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_close) > 0;
		}

		// Token: 0x06000C85 RID: 3205 RVA: 0x00021E84 File Offset: 0x00020084
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qmenBr_raise = QMenuBar.__N.QMenBr_raise;
			calli(System.Void(System.IntPtr), this.self, qmenBr_raise);
		}

		// Token: 0x06000C86 RID: 3206 RVA: 0x00021EB0 File Offset: 0x000200B0
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qmenBr_lower = QMenuBar.__N.QMenBr_lower;
			calli(System.Void(System.IntPtr), this.self, qmenBr_lower);
		}

		// Token: 0x06000C87 RID: 3207 RVA: 0x00021EDC File Offset: 0x000200DC
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qmenBr_isVisible = QMenuBar.__N.QMenBr_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_isVisible) > 0;
		}

		// Token: 0x06000C88 RID: 3208 RVA: 0x00021F0C File Offset: 0x0002010C
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qmenBr_setAttribute = QMenuBar.__N.QMenBr_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qmenBr_setAttribute);
		}

		// Token: 0x06000C89 RID: 3209 RVA: 0x00021F40 File Offset: 0x00020140
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qmenBr_testAttribute = QMenuBar.__N.QMenBr_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qmenBr_testAttribute) > 0;
		}

		// Token: 0x06000C8A RID: 3210 RVA: 0x00021F70 File Offset: 0x00020170
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qmenBr_acceptDrops = QMenuBar.__N.QMenBr_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_acceptDrops) > 0;
		}

		// Token: 0x06000C8B RID: 3211 RVA: 0x00021FA0 File Offset: 0x000201A0
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qmenBr_setAcceptDrops = QMenuBar.__N.QMenBr_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qmenBr_setAcceptDrops);
		}

		// Token: 0x06000C8C RID: 3212 RVA: 0x00021FD4 File Offset: 0x000201D4
		internal readonly void update()
		{
			this.NullCheck("update");
			method qmenBr_update = QMenuBar.__N.QMenBr_update;
			calli(System.Void(System.IntPtr), this.self, qmenBr_update);
		}

		// Token: 0x06000C8D RID: 3213 RVA: 0x00022000 File Offset: 0x00020200
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qmenBr_repaint = QMenuBar.__N.QMenBr_repaint;
			calli(System.Void(System.IntPtr), this.self, qmenBr_repaint);
		}

		// Token: 0x06000C8E RID: 3214 RVA: 0x0002202C File Offset: 0x0002022C
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qmenBr_setCursor = QMenuBar.__N.QMenBr_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qmenBr_setCursor);
		}

		// Token: 0x06000C8F RID: 3215 RVA: 0x00022058 File Offset: 0x00020258
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qmenBr_unsetCursor = QMenuBar.__N.QMenBr_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qmenBr_unsetCursor);
		}

		// Token: 0x06000C90 RID: 3216 RVA: 0x00022084 File Offset: 0x00020284
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qmenBr_setWindowIcon = QMenuBar.__N.QMenBr_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qmenBr_setWindowIcon);
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x000220B4 File Offset: 0x000202B4
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qmenBr_setWindowIconText = QMenuBar.__N.QMenBr_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qmenBr_setWindowIconText);
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x000220E4 File Offset: 0x000202E4
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qmenBr_setWindowOpacity = QMenuBar.__N.QMenBr_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qmenBr_setWindowOpacity);
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x00022110 File Offset: 0x00020310
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qmenBr_windowOpacity = QMenuBar.__N.QMenBr_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qmenBr_windowOpacity);
		}

		// Token: 0x06000C94 RID: 3220 RVA: 0x0002213C File Offset: 0x0002033C
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qmenBr_isMinimized = QMenuBar.__N.QMenBr_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_isMinimized) > 0;
		}

		// Token: 0x06000C95 RID: 3221 RVA: 0x0002216C File Offset: 0x0002036C
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qmenBr_isMaximized = QMenuBar.__N.QMenBr_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_isMaximized) > 0;
		}

		// Token: 0x06000C96 RID: 3222 RVA: 0x0002219C File Offset: 0x0002039C
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qmenBr_isFullScreen = QMenuBar.__N.QMenBr_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_isFullScreen) > 0;
		}

		// Token: 0x06000C97 RID: 3223 RVA: 0x000221CC File Offset: 0x000203CC
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qmenBr_setMouseTracking = QMenuBar.__N.QMenBr_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qmenBr_setMouseTracking);
		}

		// Token: 0x06000C98 RID: 3224 RVA: 0x00022200 File Offset: 0x00020400
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qmenBr_hasMouseTracking = QMenuBar.__N.QMenBr_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_hasMouseTracking) > 0;
		}

		// Token: 0x06000C99 RID: 3225 RVA: 0x00022230 File Offset: 0x00020430
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qmenBr_underMouse = QMenuBar.__N.QMenBr_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_underMouse) > 0;
		}

		// Token: 0x06000C9A RID: 3226 RVA: 0x00022260 File Offset: 0x00020460
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qmenBr_mapToGlobal = QMenuBar.__N.QMenBr_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qmenBr_mapToGlobal);
		}

		// Token: 0x06000C9B RID: 3227 RVA: 0x0002228C File Offset: 0x0002048C
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qmenBr_mapFromGlobal = QMenuBar.__N.QMenBr_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qmenBr_mapFromGlobal);
		}

		// Token: 0x06000C9C RID: 3228 RVA: 0x000222B8 File Offset: 0x000204B8
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qmenBr_hasFocus = QMenuBar.__N.QMenBr_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_hasFocus) > 0;
		}

		// Token: 0x06000C9D RID: 3229 RVA: 0x000222E8 File Offset: 0x000204E8
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qmenBr_focusPolicy = QMenuBar.__N.QMenBr_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qmenBr_focusPolicy);
		}

		// Token: 0x06000C9E RID: 3230 RVA: 0x00022314 File Offset: 0x00020514
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qmenBr_setFocusPolicy = QMenuBar.__N.QMenBr_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qmenBr_setFocusPolicy);
		}

		// Token: 0x06000C9F RID: 3231 RVA: 0x00022340 File Offset: 0x00020540
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qmenBr_setFocusProxy = QMenuBar.__N.QMenBr_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qmenBr_setFocusProxy);
		}

		// Token: 0x06000CA0 RID: 3232 RVA: 0x00022370 File Offset: 0x00020570
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qmenBr_isActiveWindow = QMenuBar.__N.QMenBr_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_isActiveWindow) > 0;
		}

		// Token: 0x06000CA1 RID: 3233 RVA: 0x000223A0 File Offset: 0x000205A0
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qmenBr_updatesEnabled = QMenuBar.__N.QMenBr_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_updatesEnabled) > 0;
		}

		// Token: 0x06000CA2 RID: 3234 RVA: 0x000223D0 File Offset: 0x000205D0
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qmenBr_setUpdatesEnabled = QMenuBar.__N.QMenBr_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qmenBr_setUpdatesEnabled);
		}

		// Token: 0x06000CA3 RID: 3235 RVA: 0x00022404 File Offset: 0x00020604
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qmenBr_setFocus = QMenuBar.__N.QMenBr_setFocus;
			calli(System.Void(System.IntPtr), this.self, qmenBr_setFocus);
		}

		// Token: 0x06000CA4 RID: 3236 RVA: 0x00022430 File Offset: 0x00020630
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qmenBr_activateWindow = QMenuBar.__N.QMenBr_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qmenBr_activateWindow);
		}

		// Token: 0x06000CA5 RID: 3237 RVA: 0x0002245C File Offset: 0x0002065C
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qmenBr_clearFocus = QMenuBar.__N.QMenBr_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qmenBr_clearFocus);
		}

		// Token: 0x06000CA6 RID: 3238 RVA: 0x00022488 File Offset: 0x00020688
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qmenBr_setSizePolicy = QMenuBar.__N.QMenBr_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qmenBr_setSizePolicy);
		}

		// Token: 0x06000CA7 RID: 3239 RVA: 0x000224B8 File Offset: 0x000206B8
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qmenBr_devicePixelRatioF = QMenuBar.__N.QMenBr_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qmenBr_devicePixelRatioF);
		}

		// Token: 0x06000CA8 RID: 3240 RVA: 0x000224E4 File Offset: 0x000206E4
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qmenBr_saveGeometry = QMenuBar.__N.QMenBr_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qmenBr_saveGeometry));
		}

		// Token: 0x06000CA9 RID: 3241 RVA: 0x00022514 File Offset: 0x00020714
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qmenBr_restoreGeometry = QMenuBar.__N.QMenBr_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qmenBr_restoreGeometry) > 0;
		}

		// Token: 0x06000CAA RID: 3242 RVA: 0x00022548 File Offset: 0x00020748
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qmenBr_addAction = QMenuBar.__N.QMenBr_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qmenBr_addAction);
		}

		// Token: 0x06000CAB RID: 3243 RVA: 0x00022578 File Offset: 0x00020778
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qmenBr_removeAction = QMenuBar.__N.QMenBr_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qmenBr_removeAction);
		}

		// Token: 0x06000CAC RID: 3244 RVA: 0x000225A8 File Offset: 0x000207A8
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qmenBr_setParent = QMenuBar.__N.QMenBr_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qmenBr_setParent);
		}

		// Token: 0x06000CAD RID: 3245 RVA: 0x000225D8 File Offset: 0x000207D8
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qmenBr_parentWidget = QMenuBar.__N.QMenBr_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qmenBr_parentWidget);
		}

		// Token: 0x06000CAE RID: 3246 RVA: 0x00022608 File Offset: 0x00020808
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qmenBr_AddClassName = QMenuBar.__N.QMenBr_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qmenBr_AddClassName);
		}

		// Token: 0x06000CAF RID: 3247 RVA: 0x00022638 File Offset: 0x00020838
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qmenBr_Polish = QMenuBar.__N.QMenBr_Polish;
			calli(System.Void(System.IntPtr), this.self, qmenBr_Polish);
		}

		// Token: 0x06000CB0 RID: 3248 RVA: 0x00022664 File Offset: 0x00020864
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qmenBr_toolTip = QMenuBar.__N.QMenBr_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmenBr_toolTip));
		}

		// Token: 0x06000CB1 RID: 3249 RVA: 0x00022694 File Offset: 0x00020894
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qmenBr_setToolTip = QMenuBar.__N.QMenBr_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qmenBr_setToolTip);
		}

		// Token: 0x06000CB2 RID: 3250 RVA: 0x000226C4 File Offset: 0x000208C4
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qmenBr_statusTip = QMenuBar.__N.QMenBr_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qmenBr_statusTip));
		}

		// Token: 0x06000CB3 RID: 3251 RVA: 0x000226F4 File Offset: 0x000208F4
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qmenBr_setStatusTip = QMenuBar.__N.QMenBr_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qmenBr_setStatusTip);
		}

		// Token: 0x06000CB4 RID: 3252 RVA: 0x00022724 File Offset: 0x00020924
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qmenBr_toolTipDuration = QMenuBar.__N.QMenBr_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_toolTipDuration);
		}

		// Token: 0x06000CB5 RID: 3253 RVA: 0x00022750 File Offset: 0x00020950
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qmenBr_setToolTipDuration = QMenuBar.__N.QMenBr_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qmenBr_setToolTipDuration);
		}

		// Token: 0x06000CB6 RID: 3254 RVA: 0x0002277C File Offset: 0x0002097C
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qmenBr_autoFillBackground = QMenuBar.__N.QMenBr_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qmenBr_autoFillBackground) > 0;
		}

		// Token: 0x06000CB7 RID: 3255 RVA: 0x000227AC File Offset: 0x000209AC
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qmenBr_setAutoFillBackground = QMenuBar.__N.QMenBr_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qmenBr_setAutoFillBackground);
		}

		// Token: 0x0400005D RID: 93
		internal IntPtr self;

		// Token: 0x0200011E RID: 286
		internal static class __N
		{
			// Token: 0x04000E43 RID: 3651
			internal static method From_QWidget_To_QMenuBar;

			// Token: 0x04000E44 RID: 3652
			internal static method To_QWidget_From_QMenuBar;

			// Token: 0x04000E45 RID: 3653
			internal static method From_QObject_To_QMenuBar;

			// Token: 0x04000E46 RID: 3654
			internal static method To_QObject_From_QMenuBar;

			// Token: 0x04000E47 RID: 3655
			internal static method QMenBr_insertAction;

			// Token: 0x04000E48 RID: 3656
			internal static method QMenBr_addMenu;

			// Token: 0x04000E49 RID: 3657
			internal static method QMenBr_insertMenu;

			// Token: 0x04000E4A RID: 3658
			internal static method QMenBr_addSeparator;

			// Token: 0x04000E4B RID: 3659
			internal static method QMenBr_clear;

			// Token: 0x04000E4C RID: 3660
			internal static method QMenBr_isTopLevel;

			// Token: 0x04000E4D RID: 3661
			internal static method QMenBr_isWindow;

			// Token: 0x04000E4E RID: 3662
			internal static method QMenBr_isModal;

			// Token: 0x04000E4F RID: 3663
			internal static method QMenBr_setStyleSheet;

			// Token: 0x04000E50 RID: 3664
			internal static method QMenBr_windowTitle;

			// Token: 0x04000E51 RID: 3665
			internal static method QMenBr_setWindowTitle;

			// Token: 0x04000E52 RID: 3666
			internal static method QMenBr_setWindowFlags;

			// Token: 0x04000E53 RID: 3667
			internal static method QMenBr_windowFlags;

			// Token: 0x04000E54 RID: 3668
			internal static method QMenBr_size;

			// Token: 0x04000E55 RID: 3669
			internal static method QMenBr_resize;

			// Token: 0x04000E56 RID: 3670
			internal static method QMenBr_minimumSize;

			// Token: 0x04000E57 RID: 3671
			internal static method QMenBr_setMinimumSize;

			// Token: 0x04000E58 RID: 3672
			internal static method QMenBr_maximumSize;

			// Token: 0x04000E59 RID: 3673
			internal static method QMenBr_setMaximumSize;

			// Token: 0x04000E5A RID: 3674
			internal static method QMenBr_pos;

			// Token: 0x04000E5B RID: 3675
			internal static method QMenBr_move;

			// Token: 0x04000E5C RID: 3676
			internal static method QMenBr_isEnabled;

			// Token: 0x04000E5D RID: 3677
			internal static method QMenBr_setEnabled;

			// Token: 0x04000E5E RID: 3678
			internal static method QMenBr_setVisible;

			// Token: 0x04000E5F RID: 3679
			internal static method QMenBr_setHidden;

			// Token: 0x04000E60 RID: 3680
			internal static method QMenBr_show;

			// Token: 0x04000E61 RID: 3681
			internal static method QMenBr_hide;

			// Token: 0x04000E62 RID: 3682
			internal static method QMenBr_showMinimized;

			// Token: 0x04000E63 RID: 3683
			internal static method QMenBr_showMaximized;

			// Token: 0x04000E64 RID: 3684
			internal static method QMenBr_showFullScreen;

			// Token: 0x04000E65 RID: 3685
			internal static method QMenBr_showNormal;

			// Token: 0x04000E66 RID: 3686
			internal static method QMenBr_close;

			// Token: 0x04000E67 RID: 3687
			internal static method QMenBr_raise;

			// Token: 0x04000E68 RID: 3688
			internal static method QMenBr_lower;

			// Token: 0x04000E69 RID: 3689
			internal static method QMenBr_isVisible;

			// Token: 0x04000E6A RID: 3690
			internal static method QMenBr_setAttribute;

			// Token: 0x04000E6B RID: 3691
			internal static method QMenBr_testAttribute;

			// Token: 0x04000E6C RID: 3692
			internal static method QMenBr_acceptDrops;

			// Token: 0x04000E6D RID: 3693
			internal static method QMenBr_setAcceptDrops;

			// Token: 0x04000E6E RID: 3694
			internal static method QMenBr_update;

			// Token: 0x04000E6F RID: 3695
			internal static method QMenBr_repaint;

			// Token: 0x04000E70 RID: 3696
			internal static method QMenBr_setCursor;

			// Token: 0x04000E71 RID: 3697
			internal static method QMenBr_unsetCursor;

			// Token: 0x04000E72 RID: 3698
			internal static method QMenBr_setWindowIcon;

			// Token: 0x04000E73 RID: 3699
			internal static method QMenBr_setWindowIconText;

			// Token: 0x04000E74 RID: 3700
			internal static method QMenBr_setWindowOpacity;

			// Token: 0x04000E75 RID: 3701
			internal static method QMenBr_windowOpacity;

			// Token: 0x04000E76 RID: 3702
			internal static method QMenBr_isMinimized;

			// Token: 0x04000E77 RID: 3703
			internal static method QMenBr_isMaximized;

			// Token: 0x04000E78 RID: 3704
			internal static method QMenBr_isFullScreen;

			// Token: 0x04000E79 RID: 3705
			internal static method QMenBr_setMouseTracking;

			// Token: 0x04000E7A RID: 3706
			internal static method QMenBr_hasMouseTracking;

			// Token: 0x04000E7B RID: 3707
			internal static method QMenBr_underMouse;

			// Token: 0x04000E7C RID: 3708
			internal static method QMenBr_mapToGlobal;

			// Token: 0x04000E7D RID: 3709
			internal static method QMenBr_mapFromGlobal;

			// Token: 0x04000E7E RID: 3710
			internal static method QMenBr_hasFocus;

			// Token: 0x04000E7F RID: 3711
			internal static method QMenBr_focusPolicy;

			// Token: 0x04000E80 RID: 3712
			internal static method QMenBr_setFocusPolicy;

			// Token: 0x04000E81 RID: 3713
			internal static method QMenBr_setFocusProxy;

			// Token: 0x04000E82 RID: 3714
			internal static method QMenBr_isActiveWindow;

			// Token: 0x04000E83 RID: 3715
			internal static method QMenBr_updatesEnabled;

			// Token: 0x04000E84 RID: 3716
			internal static method QMenBr_setUpdatesEnabled;

			// Token: 0x04000E85 RID: 3717
			internal static method QMenBr_setFocus;

			// Token: 0x04000E86 RID: 3718
			internal static method QMenBr_activateWindow;

			// Token: 0x04000E87 RID: 3719
			internal static method QMenBr_clearFocus;

			// Token: 0x04000E88 RID: 3720
			internal static method QMenBr_setSizePolicy;

			// Token: 0x04000E89 RID: 3721
			internal static method QMenBr_devicePixelRatioF;

			// Token: 0x04000E8A RID: 3722
			internal static method QMenBr_saveGeometry;

			// Token: 0x04000E8B RID: 3723
			internal static method QMenBr_restoreGeometry;

			// Token: 0x04000E8C RID: 3724
			internal static method QMenBr_addAction;

			// Token: 0x04000E8D RID: 3725
			internal static method QMenBr_removeAction;

			// Token: 0x04000E8E RID: 3726
			internal static method QMenBr_setParent;

			// Token: 0x04000E8F RID: 3727
			internal static method QMenBr_parentWidget;

			// Token: 0x04000E90 RID: 3728
			internal static method QMenBr_AddClassName;

			// Token: 0x04000E91 RID: 3729
			internal static method QMenBr_Polish;

			// Token: 0x04000E92 RID: 3730
			internal static method QMenBr_toolTip;

			// Token: 0x04000E93 RID: 3731
			internal static method QMenBr_setToolTip;

			// Token: 0x04000E94 RID: 3732
			internal static method QMenBr_statusTip;

			// Token: 0x04000E95 RID: 3733
			internal static method QMenBr_setStatusTip;

			// Token: 0x04000E96 RID: 3734
			internal static method QMenBr_toolTipDuration;

			// Token: 0x04000E97 RID: 3735
			internal static method QMenBr_setToolTipDuration;

			// Token: 0x04000E98 RID: 3736
			internal static method QMenBr_autoFillBackground;

			// Token: 0x04000E99 RID: 3737
			internal static method QMenBr_setAutoFillBackground;
		}
	}
}
