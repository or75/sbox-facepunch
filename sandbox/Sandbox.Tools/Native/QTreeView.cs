using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200005D RID: 93
	internal struct QTreeView
	{
		// Token: 0x06001007 RID: 4103 RVA: 0x0002B5D5 File Offset: 0x000297D5
		public static implicit operator IntPtr(QTreeView value)
		{
			return value.self;
		}

		// Token: 0x06001008 RID: 4104 RVA: 0x0002B5E0 File Offset: 0x000297E0
		public static implicit operator QTreeView(IntPtr value)
		{
			return new QTreeView
			{
				self = value
			};
		}

		// Token: 0x06001009 RID: 4105 RVA: 0x0002B5FE File Offset: 0x000297FE
		public static bool operator ==(QTreeView c1, QTreeView c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x0600100A RID: 4106 RVA: 0x0002B611 File Offset: 0x00029811
		public static bool operator !=(QTreeView c1, QTreeView c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x0600100B RID: 4107 RVA: 0x0002B624 File Offset: 0x00029824
		public override bool Equals(object obj)
		{
			if (obj is QTreeView)
			{
				QTreeView c = (QTreeView)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x0600100C RID: 4108 RVA: 0x0002B64E File Offset: 0x0002984E
		internal QTreeView(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x0600100D RID: 4109 RVA: 0x0002B658 File Offset: 0x00029858
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QTreeView ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600100E RID: 4110 RVA: 0x0002B694 File Offset: 0x00029894
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600100F RID: 4111 RVA: 0x0002B6A6 File Offset: 0x000298A6
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06001010 RID: 4112 RVA: 0x0002B6B1 File Offset: 0x000298B1
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06001011 RID: 4113 RVA: 0x0002B6C4 File Offset: 0x000298C4
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QTreeView was null when calling " + n);
			}
		}

		// Token: 0x06001012 RID: 4114 RVA: 0x0002B6DF File Offset: 0x000298DF
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06001013 RID: 4115 RVA: 0x0002B6EC File Offset: 0x000298EC
		public static implicit operator QWidget(QTreeView value)
		{
			method to_QWidget_From_QTreeView = QTreeView.__N.To_QWidget_From_QTreeView;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QTreeView);
		}

		// Token: 0x06001014 RID: 4116 RVA: 0x0002B710 File Offset: 0x00029910
		public static explicit operator QTreeView(QWidget value)
		{
			method from_QWidget_To_QTreeView = QTreeView.__N.From_QWidget_To_QTreeView;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QTreeView);
		}

		// Token: 0x06001015 RID: 4117 RVA: 0x0002B734 File Offset: 0x00029934
		public static implicit operator QObject(QTreeView value)
		{
			method to_QObject_From_QTreeView = QTreeView.__N.To_QObject_From_QTreeView;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QTreeView);
		}

		// Token: 0x06001016 RID: 4118 RVA: 0x0002B758 File Offset: 0x00029958
		public static explicit operator QTreeView(QObject value)
		{
			method from_QObject_To_QTreeView = QTreeView.__N.From_QObject_To_QTreeView;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QTreeView);
		}

		// Token: 0x06001017 RID: 4119 RVA: 0x0002B77C File Offset: 0x0002997C
		internal unsafe readonly void setIndexWidget(ModelIndex idx, QWidget w)
		{
			this.NullCheck("setIndexWidget");
			method qtreeV_setIndexWidget = QTreeView.__N.QTreeV_setIndexWidget;
			calli(System.Void(System.IntPtr,Tools.ModelIndex*,System.IntPtr), this.self, &idx, w, qtreeV_setIndexWidget);
		}

		// Token: 0x06001018 RID: 4120 RVA: 0x0002B7B0 File Offset: 0x000299B0
		internal readonly bool isHeaderHidden()
		{
			this.NullCheck("isHeaderHidden");
			method qtreeV_isHeaderHidden = QTreeView.__N.QTreeV_isHeaderHidden;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isHeaderHidden) > 0;
		}

		// Token: 0x06001019 RID: 4121 RVA: 0x0002B7E0 File Offset: 0x000299E0
		internal readonly void setHeaderHidden(bool hide)
		{
			this.NullCheck("setHeaderHidden");
			method qtreeV_setHeaderHidden = QTreeView.__N.QTreeV_setHeaderHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hide ? 1 : 0, qtreeV_setHeaderHidden);
		}

		// Token: 0x0600101A RID: 4122 RVA: 0x0002B814 File Offset: 0x00029A14
		internal readonly int autoExpandDelay()
		{
			this.NullCheck("autoExpandDelay");
			method qtreeV_autoExpandDelay = QTreeView.__N.QTreeV_autoExpandDelay;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_autoExpandDelay);
		}

		// Token: 0x0600101B RID: 4123 RVA: 0x0002B840 File Offset: 0x00029A40
		internal readonly void setAutoExpandDelay(int delay)
		{
			this.NullCheck("setAutoExpandDelay");
			method qtreeV_setAutoExpandDelay = QTreeView.__N.QTreeV_setAutoExpandDelay;
			calli(System.Void(System.IntPtr,System.Int32), this.self, delay, qtreeV_setAutoExpandDelay);
		}

		// Token: 0x0600101C RID: 4124 RVA: 0x0002B86C File Offset: 0x00029A6C
		internal readonly int indentation()
		{
			this.NullCheck("indentation");
			method qtreeV_indentation = QTreeView.__N.QTreeV_indentation;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_indentation);
		}

		// Token: 0x0600101D RID: 4125 RVA: 0x0002B898 File Offset: 0x00029A98
		internal readonly void setIndentation(int i)
		{
			this.NullCheck("setIndentation");
			method qtreeV_setIndentation = QTreeView.__N.QTreeV_setIndentation;
			calli(System.Void(System.IntPtr,System.Int32), this.self, i, qtreeV_setIndentation);
		}

		// Token: 0x0600101E RID: 4126 RVA: 0x0002B8C4 File Offset: 0x00029AC4
		internal readonly void resetIndentation()
		{
			this.NullCheck("resetIndentation");
			method qtreeV_resetIndentation = QTreeView.__N.QTreeV_resetIndentation;
			calli(System.Void(System.IntPtr), this.self, qtreeV_resetIndentation);
		}

		// Token: 0x0600101F RID: 4127 RVA: 0x0002B8F0 File Offset: 0x00029AF0
		internal readonly bool itemsExpandable()
		{
			this.NullCheck("itemsExpandable");
			method qtreeV_itemsExpandable = QTreeView.__N.QTreeV_itemsExpandable;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_itemsExpandable) > 0;
		}

		// Token: 0x06001020 RID: 4128 RVA: 0x0002B920 File Offset: 0x00029B20
		internal readonly void setItemsExpandable(bool enable)
		{
			this.NullCheck("setItemsExpandable");
			method qtreeV_setItemsExpandable = QTreeView.__N.QTreeV_setItemsExpandable;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtreeV_setItemsExpandable);
		}

		// Token: 0x06001021 RID: 4129 RVA: 0x0002B954 File Offset: 0x00029B54
		internal readonly bool expandsOnDoubleClick()
		{
			this.NullCheck("expandsOnDoubleClick");
			method qtreeV_expandsOnDoubleClick = QTreeView.__N.QTreeV_expandsOnDoubleClick;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_expandsOnDoubleClick) > 0;
		}

		// Token: 0x06001022 RID: 4130 RVA: 0x0002B984 File Offset: 0x00029B84
		internal readonly void setExpandsOnDoubleClick(bool enable)
		{
			this.NullCheck("setExpandsOnDoubleClick");
			method qtreeV_setExpandsOnDoubleClick = QTreeView.__N.QTreeV_setExpandsOnDoubleClick;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtreeV_setExpandsOnDoubleClick);
		}

		// Token: 0x06001023 RID: 4131 RVA: 0x0002B9B8 File Offset: 0x00029BB8
		internal readonly int columnViewportPosition(int column)
		{
			this.NullCheck("columnViewportPosition");
			method qtreeV_columnViewportPosition = QTreeView.__N.QTreeV_columnViewportPosition;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, column, qtreeV_columnViewportPosition);
		}

		// Token: 0x06001024 RID: 4132 RVA: 0x0002B9E4 File Offset: 0x00029BE4
		internal readonly int columnWidth(int column)
		{
			this.NullCheck("columnWidth");
			method qtreeV_columnWidth = QTreeView.__N.QTreeV_columnWidth;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, column, qtreeV_columnWidth);
		}

		// Token: 0x06001025 RID: 4133 RVA: 0x0002BA10 File Offset: 0x00029C10
		internal readonly void setColumnWidth(int column, int width)
		{
			this.NullCheck("setColumnWidth");
			method qtreeV_setColumnWidth = QTreeView.__N.QTreeV_setColumnWidth;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, column, width, qtreeV_setColumnWidth);
		}

		// Token: 0x06001026 RID: 4134 RVA: 0x0002BA3C File Offset: 0x00029C3C
		internal readonly int columnAt(int x)
		{
			this.NullCheck("columnAt");
			method qtreeV_columnAt = QTreeView.__N.QTreeV_columnAt;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, x, qtreeV_columnAt);
		}

		// Token: 0x06001027 RID: 4135 RVA: 0x0002BA68 File Offset: 0x00029C68
		internal readonly bool isColumnHidden(int column)
		{
			this.NullCheck("isColumnHidden");
			method qtreeV_isColumnHidden = QTreeView.__N.QTreeV_isColumnHidden;
			return calli(System.Int32(System.IntPtr,System.Int32), this.self, column, qtreeV_isColumnHidden) > 0;
		}

		// Token: 0x06001028 RID: 4136 RVA: 0x0002BA98 File Offset: 0x00029C98
		internal readonly void setColumnHidden(int column, bool hide)
		{
			this.NullCheck("setColumnHidden");
			method qtreeV_setColumnHidden = QTreeView.__N.QTreeV_setColumnHidden;
			calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, column, hide ? 1 : 0, qtreeV_setColumnHidden);
		}

		// Token: 0x06001029 RID: 4137 RVA: 0x0002BACC File Offset: 0x00029CCC
		internal unsafe readonly bool isExpanded(ModelIndex index)
		{
			this.NullCheck("isExpanded");
			method qtreeV_isExpanded = QTreeView.__N.QTreeV_isExpanded;
			return calli(System.Int32(System.IntPtr,Tools.ModelIndex*), this.self, &index, qtreeV_isExpanded) > 0;
		}

		// Token: 0x0600102A RID: 4138 RVA: 0x0002BAFC File Offset: 0x00029CFC
		internal unsafe readonly void setExpanded(ModelIndex index, bool expand)
		{
			this.NullCheck("setExpanded");
			method qtreeV_setExpanded = QTreeView.__N.QTreeV_setExpanded;
			calli(System.Void(System.IntPtr,Tools.ModelIndex*,System.Int32), this.self, &index, expand ? 1 : 0, qtreeV_setExpanded);
		}

		// Token: 0x0600102B RID: 4139 RVA: 0x0002BB30 File Offset: 0x00029D30
		internal readonly void setSortingEnabled(bool enable)
		{
			this.NullCheck("setSortingEnabled");
			method qtreeV_setSortingEnabled = QTreeView.__N.QTreeV_setSortingEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtreeV_setSortingEnabled);
		}

		// Token: 0x0600102C RID: 4140 RVA: 0x0002BB64 File Offset: 0x00029D64
		internal readonly bool isSortingEnabled()
		{
			this.NullCheck("isSortingEnabled");
			method qtreeV_isSortingEnabled = QTreeView.__N.QTreeV_isSortingEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isSortingEnabled) > 0;
		}

		// Token: 0x0600102D RID: 4141 RVA: 0x0002BB94 File Offset: 0x00029D94
		internal readonly void setAnimated(bool enable)
		{
			this.NullCheck("setAnimated");
			method qtreeV_setAnimated = QTreeView.__N.QTreeV_setAnimated;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtreeV_setAnimated);
		}

		// Token: 0x0600102E RID: 4142 RVA: 0x0002BBC8 File Offset: 0x00029DC8
		internal readonly bool isAnimated()
		{
			this.NullCheck("isAnimated");
			method qtreeV_isAnimated = QTreeView.__N.QTreeV_isAnimated;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isAnimated) > 0;
		}

		// Token: 0x0600102F RID: 4143 RVA: 0x0002BBF8 File Offset: 0x00029DF8
		internal readonly void setAllColumnsShowFocus(bool enable)
		{
			this.NullCheck("setAllColumnsShowFocus");
			method qtreeV_setAllColumnsShowFocus = QTreeView.__N.QTreeV_setAllColumnsShowFocus;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtreeV_setAllColumnsShowFocus);
		}

		// Token: 0x06001030 RID: 4144 RVA: 0x0002BC2C File Offset: 0x00029E2C
		internal readonly bool allColumnsShowFocus()
		{
			this.NullCheck("allColumnsShowFocus");
			method qtreeV_allColumnsShowFocus = QTreeView.__N.QTreeV_allColumnsShowFocus;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_allColumnsShowFocus) > 0;
		}

		// Token: 0x06001031 RID: 4145 RVA: 0x0002BC5C File Offset: 0x00029E5C
		internal readonly void setWordWrap(bool on)
		{
			this.NullCheck("setWordWrap");
			method qtreeV_setWordWrap = QTreeView.__N.QTreeV_setWordWrap;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qtreeV_setWordWrap);
		}

		// Token: 0x06001032 RID: 4146 RVA: 0x0002BC90 File Offset: 0x00029E90
		internal readonly bool wordWrap()
		{
			this.NullCheck("wordWrap");
			method qtreeV_wordWrap = QTreeView.__N.QTreeV_wordWrap;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_wordWrap) > 0;
		}

		// Token: 0x06001033 RID: 4147 RVA: 0x0002BCC0 File Offset: 0x00029EC0
		internal readonly void setTreePosition(int logicalIndex)
		{
			this.NullCheck("setTreePosition");
			method qtreeV_setTreePosition = QTreeView.__N.QTreeV_setTreePosition;
			calli(System.Void(System.IntPtr,System.Int32), this.self, logicalIndex, qtreeV_setTreePosition);
		}

		// Token: 0x06001034 RID: 4148 RVA: 0x0002BCEC File Offset: 0x00029EEC
		internal readonly int treePosition()
		{
			this.NullCheck("treePosition");
			method qtreeV_treePosition = QTreeView.__N.QTreeV_treePosition;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_treePosition);
		}

		// Token: 0x06001035 RID: 4149 RVA: 0x0002BD18 File Offset: 0x00029F18
		internal unsafe readonly QRectF visualRect(ModelIndex index)
		{
			this.NullCheck("visualRect");
			method qtreeV_visualRect = QTreeView.__N.QTreeV_visualRect;
			return calli(QRectF(System.IntPtr,Tools.ModelIndex*), this.self, &index, qtreeV_visualRect);
		}

		// Token: 0x06001036 RID: 4150 RVA: 0x0002BD48 File Offset: 0x00029F48
		internal unsafe readonly void scrollTo(ModelIndex index)
		{
			this.NullCheck("scrollTo");
			method qtreeV_scrollTo = QTreeView.__N.QTreeV_scrollTo;
			calli(System.Void(System.IntPtr,Tools.ModelIndex*), this.self, &index, qtreeV_scrollTo);
		}

		// Token: 0x06001037 RID: 4151 RVA: 0x0002BD78 File Offset: 0x00029F78
		internal readonly ModelIndex indexAt(Vector3 p)
		{
			this.NullCheck("indexAt");
			method qtreeV_indexAt = QTreeView.__N.QTreeV_indexAt;
			return calli(Tools.ModelIndex(System.IntPtr,Vector3), this.self, p, qtreeV_indexAt);
		}

		// Token: 0x06001038 RID: 4152 RVA: 0x0002BDA4 File Offset: 0x00029FA4
		internal unsafe readonly ModelIndex indexAbove(ModelIndex index)
		{
			this.NullCheck("indexAbove");
			method qtreeV_indexAbove = QTreeView.__N.QTreeV_indexAbove;
			return calli(Tools.ModelIndex(System.IntPtr,Tools.ModelIndex*), this.self, &index, qtreeV_indexAbove);
		}

		// Token: 0x06001039 RID: 4153 RVA: 0x0002BDD4 File Offset: 0x00029FD4
		internal unsafe readonly ModelIndex indexBelow(ModelIndex index)
		{
			this.NullCheck("indexBelow");
			method qtreeV_indexBelow = QTreeView.__N.QTreeV_indexBelow;
			return calli(Tools.ModelIndex(System.IntPtr,Tools.ModelIndex*), this.self, &index, qtreeV_indexBelow);
		}

		// Token: 0x0600103A RID: 4154 RVA: 0x0002BE04 File Offset: 0x0002A004
		internal readonly bool uniformRowHeights()
		{
			this.NullCheck("uniformRowHeights");
			method qtreeV_uniformRowHeights = QTreeView.__N.QTreeV_uniformRowHeights;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_uniformRowHeights) > 0;
		}

		// Token: 0x0600103B RID: 4155 RVA: 0x0002BE34 File Offset: 0x0002A034
		internal readonly void setUniformRowHeights(bool uniform)
		{
			this.NullCheck("setUniformRowHeights");
			method qtreeV_setUniformRowHeights = QTreeView.__N.QTreeV_setUniformRowHeights;
			calli(System.Void(System.IntPtr,System.Int32), this.self, uniform ? 1 : 0, qtreeV_setUniformRowHeights);
		}

		// Token: 0x0600103C RID: 4156 RVA: 0x0002BE68 File Offset: 0x0002A068
		internal readonly void setItemDelegate(CDataDelegate del)
		{
			this.NullCheck("setItemDelegate");
			method qtreeV_setItemDelegate = QTreeView.__N.QTreeV_setItemDelegate;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, del, qtreeV_setItemDelegate);
		}

		// Token: 0x0600103D RID: 4157 RVA: 0x0002BE98 File Offset: 0x0002A098
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qtreeV_isTopLevel = QTreeView.__N.QTreeV_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isTopLevel) > 0;
		}

		// Token: 0x0600103E RID: 4158 RVA: 0x0002BEC8 File Offset: 0x0002A0C8
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qtreeV_isWindow = QTreeView.__N.QTreeV_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isWindow) > 0;
		}

		// Token: 0x0600103F RID: 4159 RVA: 0x0002BEF8 File Offset: 0x0002A0F8
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qtreeV_isModal = QTreeView.__N.QTreeV_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isModal) > 0;
		}

		// Token: 0x06001040 RID: 4160 RVA: 0x0002BF28 File Offset: 0x0002A128
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qtreeV_setStyleSheet = QTreeView.__N.QTreeV_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qtreeV_setStyleSheet);
		}

		// Token: 0x06001041 RID: 4161 RVA: 0x0002BF58 File Offset: 0x0002A158
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qtreeV_windowTitle = QTreeView.__N.QTreeV_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtreeV_windowTitle));
		}

		// Token: 0x06001042 RID: 4162 RVA: 0x0002BF88 File Offset: 0x0002A188
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qtreeV_setWindowTitle = QTreeView.__N.QTreeV_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qtreeV_setWindowTitle);
		}

		// Token: 0x06001043 RID: 4163 RVA: 0x0002BFB8 File Offset: 0x0002A1B8
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qtreeV_setWindowFlags = QTreeView.__N.QTreeV_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qtreeV_setWindowFlags);
		}

		// Token: 0x06001044 RID: 4164 RVA: 0x0002BFE4 File Offset: 0x0002A1E4
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qtreeV_windowFlags = QTreeView.__N.QTreeV_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qtreeV_windowFlags);
		}

		// Token: 0x06001045 RID: 4165 RVA: 0x0002C010 File Offset: 0x0002A210
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qtreeV_size = QTreeView.__N.QTreeV_size;
			return calli(Vector3(System.IntPtr), this.self, qtreeV_size);
		}

		// Token: 0x06001046 RID: 4166 RVA: 0x0002C03C File Offset: 0x0002A23C
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qtreeV_resize = QTreeView.__N.QTreeV_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtreeV_resize);
		}

		// Token: 0x06001047 RID: 4167 RVA: 0x0002C068 File Offset: 0x0002A268
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qtreeV_minimumSize = QTreeView.__N.QTreeV_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qtreeV_minimumSize);
		}

		// Token: 0x06001048 RID: 4168 RVA: 0x0002C094 File Offset: 0x0002A294
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qtreeV_setMinimumSize = QTreeView.__N.QTreeV_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtreeV_setMinimumSize);
		}

		// Token: 0x06001049 RID: 4169 RVA: 0x0002C0C0 File Offset: 0x0002A2C0
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qtreeV_maximumSize = QTreeView.__N.QTreeV_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qtreeV_maximumSize);
		}

		// Token: 0x0600104A RID: 4170 RVA: 0x0002C0EC File Offset: 0x0002A2EC
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qtreeV_setMaximumSize = QTreeView.__N.QTreeV_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtreeV_setMaximumSize);
		}

		// Token: 0x0600104B RID: 4171 RVA: 0x0002C118 File Offset: 0x0002A318
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qtreeV_pos = QTreeView.__N.QTreeV_pos;
			return calli(Vector3(System.IntPtr), this.self, qtreeV_pos);
		}

		// Token: 0x0600104C RID: 4172 RVA: 0x0002C144 File Offset: 0x0002A344
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qtreeV_move = QTreeView.__N.QTreeV_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qtreeV_move);
		}

		// Token: 0x0600104D RID: 4173 RVA: 0x0002C170 File Offset: 0x0002A370
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qtreeV_isEnabled = QTreeView.__N.QTreeV_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isEnabled) > 0;
		}

		// Token: 0x0600104E RID: 4174 RVA: 0x0002C1A0 File Offset: 0x0002A3A0
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qtreeV_setEnabled = QTreeView.__N.QTreeV_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qtreeV_setEnabled);
		}

		// Token: 0x0600104F RID: 4175 RVA: 0x0002C1D4 File Offset: 0x0002A3D4
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qtreeV_setVisible = QTreeView.__N.QTreeV_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qtreeV_setVisible);
		}

		// Token: 0x06001050 RID: 4176 RVA: 0x0002C208 File Offset: 0x0002A408
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qtreeV_setHidden = QTreeView.__N.QTreeV_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qtreeV_setHidden);
		}

		// Token: 0x06001051 RID: 4177 RVA: 0x0002C23C File Offset: 0x0002A43C
		internal readonly void show()
		{
			this.NullCheck("show");
			method qtreeV_show = QTreeView.__N.QTreeV_show;
			calli(System.Void(System.IntPtr), this.self, qtreeV_show);
		}

		// Token: 0x06001052 RID: 4178 RVA: 0x0002C268 File Offset: 0x0002A468
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qtreeV_hide = QTreeView.__N.QTreeV_hide;
			calli(System.Void(System.IntPtr), this.self, qtreeV_hide);
		}

		// Token: 0x06001053 RID: 4179 RVA: 0x0002C294 File Offset: 0x0002A494
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qtreeV_showMinimized = QTreeView.__N.QTreeV_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qtreeV_showMinimized);
		}

		// Token: 0x06001054 RID: 4180 RVA: 0x0002C2C0 File Offset: 0x0002A4C0
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qtreeV_showMaximized = QTreeView.__N.QTreeV_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qtreeV_showMaximized);
		}

		// Token: 0x06001055 RID: 4181 RVA: 0x0002C2EC File Offset: 0x0002A4EC
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qtreeV_showFullScreen = QTreeView.__N.QTreeV_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qtreeV_showFullScreen);
		}

		// Token: 0x06001056 RID: 4182 RVA: 0x0002C318 File Offset: 0x0002A518
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qtreeV_showNormal = QTreeView.__N.QTreeV_showNormal;
			calli(System.Void(System.IntPtr), this.self, qtreeV_showNormal);
		}

		// Token: 0x06001057 RID: 4183 RVA: 0x0002C344 File Offset: 0x0002A544
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qtreeV_close = QTreeView.__N.QTreeV_close;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_close) > 0;
		}

		// Token: 0x06001058 RID: 4184 RVA: 0x0002C374 File Offset: 0x0002A574
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qtreeV_raise = QTreeView.__N.QTreeV_raise;
			calli(System.Void(System.IntPtr), this.self, qtreeV_raise);
		}

		// Token: 0x06001059 RID: 4185 RVA: 0x0002C3A0 File Offset: 0x0002A5A0
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qtreeV_lower = QTreeView.__N.QTreeV_lower;
			calli(System.Void(System.IntPtr), this.self, qtreeV_lower);
		}

		// Token: 0x0600105A RID: 4186 RVA: 0x0002C3CC File Offset: 0x0002A5CC
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qtreeV_isVisible = QTreeView.__N.QTreeV_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isVisible) > 0;
		}

		// Token: 0x0600105B RID: 4187 RVA: 0x0002C3FC File Offset: 0x0002A5FC
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qtreeV_setAttribute = QTreeView.__N.QTreeV_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qtreeV_setAttribute);
		}

		// Token: 0x0600105C RID: 4188 RVA: 0x0002C430 File Offset: 0x0002A630
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qtreeV_testAttribute = QTreeView.__N.QTreeV_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qtreeV_testAttribute) > 0;
		}

		// Token: 0x0600105D RID: 4189 RVA: 0x0002C460 File Offset: 0x0002A660
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qtreeV_acceptDrops = QTreeView.__N.QTreeV_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_acceptDrops) > 0;
		}

		// Token: 0x0600105E RID: 4190 RVA: 0x0002C490 File Offset: 0x0002A690
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qtreeV_setAcceptDrops = QTreeView.__N.QTreeV_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qtreeV_setAcceptDrops);
		}

		// Token: 0x0600105F RID: 4191 RVA: 0x0002C4C4 File Offset: 0x0002A6C4
		internal readonly void update()
		{
			this.NullCheck("update");
			method qtreeV_update = QTreeView.__N.QTreeV_update;
			calli(System.Void(System.IntPtr), this.self, qtreeV_update);
		}

		// Token: 0x06001060 RID: 4192 RVA: 0x0002C4F0 File Offset: 0x0002A6F0
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qtreeV_repaint = QTreeView.__N.QTreeV_repaint;
			calli(System.Void(System.IntPtr), this.self, qtreeV_repaint);
		}

		// Token: 0x06001061 RID: 4193 RVA: 0x0002C51C File Offset: 0x0002A71C
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qtreeV_setCursor = QTreeView.__N.QTreeV_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qtreeV_setCursor);
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x0002C548 File Offset: 0x0002A748
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qtreeV_unsetCursor = QTreeView.__N.QTreeV_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qtreeV_unsetCursor);
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x0002C574 File Offset: 0x0002A774
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qtreeV_setWindowIcon = QTreeView.__N.QTreeV_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qtreeV_setWindowIcon);
		}

		// Token: 0x06001064 RID: 4196 RVA: 0x0002C5A4 File Offset: 0x0002A7A4
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qtreeV_setWindowIconText = QTreeView.__N.QTreeV_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qtreeV_setWindowIconText);
		}

		// Token: 0x06001065 RID: 4197 RVA: 0x0002C5D4 File Offset: 0x0002A7D4
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qtreeV_setWindowOpacity = QTreeView.__N.QTreeV_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qtreeV_setWindowOpacity);
		}

		// Token: 0x06001066 RID: 4198 RVA: 0x0002C600 File Offset: 0x0002A800
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qtreeV_windowOpacity = QTreeView.__N.QTreeV_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qtreeV_windowOpacity);
		}

		// Token: 0x06001067 RID: 4199 RVA: 0x0002C62C File Offset: 0x0002A82C
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qtreeV_isMinimized = QTreeView.__N.QTreeV_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isMinimized) > 0;
		}

		// Token: 0x06001068 RID: 4200 RVA: 0x0002C65C File Offset: 0x0002A85C
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qtreeV_isMaximized = QTreeView.__N.QTreeV_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isMaximized) > 0;
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x0002C68C File Offset: 0x0002A88C
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qtreeV_isFullScreen = QTreeView.__N.QTreeV_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isFullScreen) > 0;
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x0002C6BC File Offset: 0x0002A8BC
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qtreeV_setMouseTracking = QTreeView.__N.QTreeV_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtreeV_setMouseTracking);
		}

		// Token: 0x0600106B RID: 4203 RVA: 0x0002C6F0 File Offset: 0x0002A8F0
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qtreeV_hasMouseTracking = QTreeView.__N.QTreeV_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_hasMouseTracking) > 0;
		}

		// Token: 0x0600106C RID: 4204 RVA: 0x0002C720 File Offset: 0x0002A920
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qtreeV_underMouse = QTreeView.__N.QTreeV_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_underMouse) > 0;
		}

		// Token: 0x0600106D RID: 4205 RVA: 0x0002C750 File Offset: 0x0002A950
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qtreeV_mapToGlobal = QTreeView.__N.QTreeV_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qtreeV_mapToGlobal);
		}

		// Token: 0x0600106E RID: 4206 RVA: 0x0002C77C File Offset: 0x0002A97C
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qtreeV_mapFromGlobal = QTreeView.__N.QTreeV_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qtreeV_mapFromGlobal);
		}

		// Token: 0x0600106F RID: 4207 RVA: 0x0002C7A8 File Offset: 0x0002A9A8
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qtreeV_hasFocus = QTreeView.__N.QTreeV_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_hasFocus) > 0;
		}

		// Token: 0x06001070 RID: 4208 RVA: 0x0002C7D8 File Offset: 0x0002A9D8
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qtreeV_focusPolicy = QTreeView.__N.QTreeV_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qtreeV_focusPolicy);
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x0002C804 File Offset: 0x0002AA04
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qtreeV_setFocusPolicy = QTreeView.__N.QTreeV_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qtreeV_setFocusPolicy);
		}

		// Token: 0x06001072 RID: 4210 RVA: 0x0002C830 File Offset: 0x0002AA30
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qtreeV_setFocusProxy = QTreeView.__N.QTreeV_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qtreeV_setFocusProxy);
		}

		// Token: 0x06001073 RID: 4211 RVA: 0x0002C860 File Offset: 0x0002AA60
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qtreeV_isActiveWindow = QTreeView.__N.QTreeV_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_isActiveWindow) > 0;
		}

		// Token: 0x06001074 RID: 4212 RVA: 0x0002C890 File Offset: 0x0002AA90
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qtreeV_updatesEnabled = QTreeView.__N.QTreeV_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_updatesEnabled) > 0;
		}

		// Token: 0x06001075 RID: 4213 RVA: 0x0002C8C0 File Offset: 0x0002AAC0
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qtreeV_setUpdatesEnabled = QTreeView.__N.QTreeV_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qtreeV_setUpdatesEnabled);
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x0002C8F4 File Offset: 0x0002AAF4
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qtreeV_setFocus = QTreeView.__N.QTreeV_setFocus;
			calli(System.Void(System.IntPtr), this.self, qtreeV_setFocus);
		}

		// Token: 0x06001077 RID: 4215 RVA: 0x0002C920 File Offset: 0x0002AB20
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qtreeV_activateWindow = QTreeView.__N.QTreeV_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qtreeV_activateWindow);
		}

		// Token: 0x06001078 RID: 4216 RVA: 0x0002C94C File Offset: 0x0002AB4C
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qtreeV_clearFocus = QTreeView.__N.QTreeV_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qtreeV_clearFocus);
		}

		// Token: 0x06001079 RID: 4217 RVA: 0x0002C978 File Offset: 0x0002AB78
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qtreeV_setSizePolicy = QTreeView.__N.QTreeV_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qtreeV_setSizePolicy);
		}

		// Token: 0x0600107A RID: 4218 RVA: 0x0002C9A8 File Offset: 0x0002ABA8
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qtreeV_devicePixelRatioF = QTreeView.__N.QTreeV_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qtreeV_devicePixelRatioF);
		}

		// Token: 0x0600107B RID: 4219 RVA: 0x0002C9D4 File Offset: 0x0002ABD4
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qtreeV_saveGeometry = QTreeView.__N.QTreeV_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qtreeV_saveGeometry));
		}

		// Token: 0x0600107C RID: 4220 RVA: 0x0002CA04 File Offset: 0x0002AC04
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qtreeV_restoreGeometry = QTreeView.__N.QTreeV_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qtreeV_restoreGeometry) > 0;
		}

		// Token: 0x0600107D RID: 4221 RVA: 0x0002CA38 File Offset: 0x0002AC38
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qtreeV_addAction = QTreeView.__N.QTreeV_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qtreeV_addAction);
		}

		// Token: 0x0600107E RID: 4222 RVA: 0x0002CA68 File Offset: 0x0002AC68
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qtreeV_removeAction = QTreeView.__N.QTreeV_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qtreeV_removeAction);
		}

		// Token: 0x0600107F RID: 4223 RVA: 0x0002CA98 File Offset: 0x0002AC98
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qtreeV_setParent = QTreeView.__N.QTreeV_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qtreeV_setParent);
		}

		// Token: 0x06001080 RID: 4224 RVA: 0x0002CAC8 File Offset: 0x0002ACC8
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qtreeV_parentWidget = QTreeView.__N.QTreeV_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qtreeV_parentWidget);
		}

		// Token: 0x06001081 RID: 4225 RVA: 0x0002CAF8 File Offset: 0x0002ACF8
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qtreeV_AddClassName = QTreeView.__N.QTreeV_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qtreeV_AddClassName);
		}

		// Token: 0x06001082 RID: 4226 RVA: 0x0002CB28 File Offset: 0x0002AD28
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qtreeV_Polish = QTreeView.__N.QTreeV_Polish;
			calli(System.Void(System.IntPtr), this.self, qtreeV_Polish);
		}

		// Token: 0x06001083 RID: 4227 RVA: 0x0002CB54 File Offset: 0x0002AD54
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qtreeV_toolTip = QTreeView.__N.QTreeV_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtreeV_toolTip));
		}

		// Token: 0x06001084 RID: 4228 RVA: 0x0002CB84 File Offset: 0x0002AD84
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qtreeV_setToolTip = QTreeView.__N.QTreeV_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qtreeV_setToolTip);
		}

		// Token: 0x06001085 RID: 4229 RVA: 0x0002CBB4 File Offset: 0x0002ADB4
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qtreeV_statusTip = QTreeView.__N.QTreeV_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qtreeV_statusTip));
		}

		// Token: 0x06001086 RID: 4230 RVA: 0x0002CBE4 File Offset: 0x0002ADE4
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qtreeV_setStatusTip = QTreeView.__N.QTreeV_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qtreeV_setStatusTip);
		}

		// Token: 0x06001087 RID: 4231 RVA: 0x0002CC14 File Offset: 0x0002AE14
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qtreeV_toolTipDuration = QTreeView.__N.QTreeV_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_toolTipDuration);
		}

		// Token: 0x06001088 RID: 4232 RVA: 0x0002CC40 File Offset: 0x0002AE40
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qtreeV_setToolTipDuration = QTreeView.__N.QTreeV_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qtreeV_setToolTipDuration);
		}

		// Token: 0x06001089 RID: 4233 RVA: 0x0002CC6C File Offset: 0x0002AE6C
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qtreeV_autoFillBackground = QTreeView.__N.QTreeV_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qtreeV_autoFillBackground) > 0;
		}

		// Token: 0x0600108A RID: 4234 RVA: 0x0002CC9C File Offset: 0x0002AE9C
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qtreeV_setAutoFillBackground = QTreeView.__N.QTreeV_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qtreeV_setAutoFillBackground);
		}

		// Token: 0x04000068 RID: 104
		internal IntPtr self;

		// Token: 0x02000129 RID: 297
		internal static class __N
		{
			// Token: 0x04001171 RID: 4465
			internal static method From_QWidget_To_QTreeView;

			// Token: 0x04001172 RID: 4466
			internal static method To_QWidget_From_QTreeView;

			// Token: 0x04001173 RID: 4467
			internal static method From_QObject_To_QTreeView;

			// Token: 0x04001174 RID: 4468
			internal static method To_QObject_From_QTreeView;

			// Token: 0x04001175 RID: 4469
			internal static method QTreeV_setIndexWidget;

			// Token: 0x04001176 RID: 4470
			internal static method QTreeV_isHeaderHidden;

			// Token: 0x04001177 RID: 4471
			internal static method QTreeV_setHeaderHidden;

			// Token: 0x04001178 RID: 4472
			internal static method QTreeV_autoExpandDelay;

			// Token: 0x04001179 RID: 4473
			internal static method QTreeV_setAutoExpandDelay;

			// Token: 0x0400117A RID: 4474
			internal static method QTreeV_indentation;

			// Token: 0x0400117B RID: 4475
			internal static method QTreeV_setIndentation;

			// Token: 0x0400117C RID: 4476
			internal static method QTreeV_resetIndentation;

			// Token: 0x0400117D RID: 4477
			internal static method QTreeV_itemsExpandable;

			// Token: 0x0400117E RID: 4478
			internal static method QTreeV_setItemsExpandable;

			// Token: 0x0400117F RID: 4479
			internal static method QTreeV_expandsOnDoubleClick;

			// Token: 0x04001180 RID: 4480
			internal static method QTreeV_setExpandsOnDoubleClick;

			// Token: 0x04001181 RID: 4481
			internal static method QTreeV_columnViewportPosition;

			// Token: 0x04001182 RID: 4482
			internal static method QTreeV_columnWidth;

			// Token: 0x04001183 RID: 4483
			internal static method QTreeV_setColumnWidth;

			// Token: 0x04001184 RID: 4484
			internal static method QTreeV_columnAt;

			// Token: 0x04001185 RID: 4485
			internal static method QTreeV_isColumnHidden;

			// Token: 0x04001186 RID: 4486
			internal static method QTreeV_setColumnHidden;

			// Token: 0x04001187 RID: 4487
			internal static method QTreeV_isExpanded;

			// Token: 0x04001188 RID: 4488
			internal static method QTreeV_setExpanded;

			// Token: 0x04001189 RID: 4489
			internal static method QTreeV_setSortingEnabled;

			// Token: 0x0400118A RID: 4490
			internal static method QTreeV_isSortingEnabled;

			// Token: 0x0400118B RID: 4491
			internal static method QTreeV_setAnimated;

			// Token: 0x0400118C RID: 4492
			internal static method QTreeV_isAnimated;

			// Token: 0x0400118D RID: 4493
			internal static method QTreeV_setAllColumnsShowFocus;

			// Token: 0x0400118E RID: 4494
			internal static method QTreeV_allColumnsShowFocus;

			// Token: 0x0400118F RID: 4495
			internal static method QTreeV_setWordWrap;

			// Token: 0x04001190 RID: 4496
			internal static method QTreeV_wordWrap;

			// Token: 0x04001191 RID: 4497
			internal static method QTreeV_setTreePosition;

			// Token: 0x04001192 RID: 4498
			internal static method QTreeV_treePosition;

			// Token: 0x04001193 RID: 4499
			internal static method QTreeV_visualRect;

			// Token: 0x04001194 RID: 4500
			internal static method QTreeV_scrollTo;

			// Token: 0x04001195 RID: 4501
			internal static method QTreeV_indexAt;

			// Token: 0x04001196 RID: 4502
			internal static method QTreeV_indexAbove;

			// Token: 0x04001197 RID: 4503
			internal static method QTreeV_indexBelow;

			// Token: 0x04001198 RID: 4504
			internal static method QTreeV_uniformRowHeights;

			// Token: 0x04001199 RID: 4505
			internal static method QTreeV_setUniformRowHeights;

			// Token: 0x0400119A RID: 4506
			internal static method QTreeV_setItemDelegate;

			// Token: 0x0400119B RID: 4507
			internal static method QTreeV_isTopLevel;

			// Token: 0x0400119C RID: 4508
			internal static method QTreeV_isWindow;

			// Token: 0x0400119D RID: 4509
			internal static method QTreeV_isModal;

			// Token: 0x0400119E RID: 4510
			internal static method QTreeV_setStyleSheet;

			// Token: 0x0400119F RID: 4511
			internal static method QTreeV_windowTitle;

			// Token: 0x040011A0 RID: 4512
			internal static method QTreeV_setWindowTitle;

			// Token: 0x040011A1 RID: 4513
			internal static method QTreeV_setWindowFlags;

			// Token: 0x040011A2 RID: 4514
			internal static method QTreeV_windowFlags;

			// Token: 0x040011A3 RID: 4515
			internal static method QTreeV_size;

			// Token: 0x040011A4 RID: 4516
			internal static method QTreeV_resize;

			// Token: 0x040011A5 RID: 4517
			internal static method QTreeV_minimumSize;

			// Token: 0x040011A6 RID: 4518
			internal static method QTreeV_setMinimumSize;

			// Token: 0x040011A7 RID: 4519
			internal static method QTreeV_maximumSize;

			// Token: 0x040011A8 RID: 4520
			internal static method QTreeV_setMaximumSize;

			// Token: 0x040011A9 RID: 4521
			internal static method QTreeV_pos;

			// Token: 0x040011AA RID: 4522
			internal static method QTreeV_move;

			// Token: 0x040011AB RID: 4523
			internal static method QTreeV_isEnabled;

			// Token: 0x040011AC RID: 4524
			internal static method QTreeV_setEnabled;

			// Token: 0x040011AD RID: 4525
			internal static method QTreeV_setVisible;

			// Token: 0x040011AE RID: 4526
			internal static method QTreeV_setHidden;

			// Token: 0x040011AF RID: 4527
			internal static method QTreeV_show;

			// Token: 0x040011B0 RID: 4528
			internal static method QTreeV_hide;

			// Token: 0x040011B1 RID: 4529
			internal static method QTreeV_showMinimized;

			// Token: 0x040011B2 RID: 4530
			internal static method QTreeV_showMaximized;

			// Token: 0x040011B3 RID: 4531
			internal static method QTreeV_showFullScreen;

			// Token: 0x040011B4 RID: 4532
			internal static method QTreeV_showNormal;

			// Token: 0x040011B5 RID: 4533
			internal static method QTreeV_close;

			// Token: 0x040011B6 RID: 4534
			internal static method QTreeV_raise;

			// Token: 0x040011B7 RID: 4535
			internal static method QTreeV_lower;

			// Token: 0x040011B8 RID: 4536
			internal static method QTreeV_isVisible;

			// Token: 0x040011B9 RID: 4537
			internal static method QTreeV_setAttribute;

			// Token: 0x040011BA RID: 4538
			internal static method QTreeV_testAttribute;

			// Token: 0x040011BB RID: 4539
			internal static method QTreeV_acceptDrops;

			// Token: 0x040011BC RID: 4540
			internal static method QTreeV_setAcceptDrops;

			// Token: 0x040011BD RID: 4541
			internal static method QTreeV_update;

			// Token: 0x040011BE RID: 4542
			internal static method QTreeV_repaint;

			// Token: 0x040011BF RID: 4543
			internal static method QTreeV_setCursor;

			// Token: 0x040011C0 RID: 4544
			internal static method QTreeV_unsetCursor;

			// Token: 0x040011C1 RID: 4545
			internal static method QTreeV_setWindowIcon;

			// Token: 0x040011C2 RID: 4546
			internal static method QTreeV_setWindowIconText;

			// Token: 0x040011C3 RID: 4547
			internal static method QTreeV_setWindowOpacity;

			// Token: 0x040011C4 RID: 4548
			internal static method QTreeV_windowOpacity;

			// Token: 0x040011C5 RID: 4549
			internal static method QTreeV_isMinimized;

			// Token: 0x040011C6 RID: 4550
			internal static method QTreeV_isMaximized;

			// Token: 0x040011C7 RID: 4551
			internal static method QTreeV_isFullScreen;

			// Token: 0x040011C8 RID: 4552
			internal static method QTreeV_setMouseTracking;

			// Token: 0x040011C9 RID: 4553
			internal static method QTreeV_hasMouseTracking;

			// Token: 0x040011CA RID: 4554
			internal static method QTreeV_underMouse;

			// Token: 0x040011CB RID: 4555
			internal static method QTreeV_mapToGlobal;

			// Token: 0x040011CC RID: 4556
			internal static method QTreeV_mapFromGlobal;

			// Token: 0x040011CD RID: 4557
			internal static method QTreeV_hasFocus;

			// Token: 0x040011CE RID: 4558
			internal static method QTreeV_focusPolicy;

			// Token: 0x040011CF RID: 4559
			internal static method QTreeV_setFocusPolicy;

			// Token: 0x040011D0 RID: 4560
			internal static method QTreeV_setFocusProxy;

			// Token: 0x040011D1 RID: 4561
			internal static method QTreeV_isActiveWindow;

			// Token: 0x040011D2 RID: 4562
			internal static method QTreeV_updatesEnabled;

			// Token: 0x040011D3 RID: 4563
			internal static method QTreeV_setUpdatesEnabled;

			// Token: 0x040011D4 RID: 4564
			internal static method QTreeV_setFocus;

			// Token: 0x040011D5 RID: 4565
			internal static method QTreeV_activateWindow;

			// Token: 0x040011D6 RID: 4566
			internal static method QTreeV_clearFocus;

			// Token: 0x040011D7 RID: 4567
			internal static method QTreeV_setSizePolicy;

			// Token: 0x040011D8 RID: 4568
			internal static method QTreeV_devicePixelRatioF;

			// Token: 0x040011D9 RID: 4569
			internal static method QTreeV_saveGeometry;

			// Token: 0x040011DA RID: 4570
			internal static method QTreeV_restoreGeometry;

			// Token: 0x040011DB RID: 4571
			internal static method QTreeV_addAction;

			// Token: 0x040011DC RID: 4572
			internal static method QTreeV_removeAction;

			// Token: 0x040011DD RID: 4573
			internal static method QTreeV_setParent;

			// Token: 0x040011DE RID: 4574
			internal static method QTreeV_parentWidget;

			// Token: 0x040011DF RID: 4575
			internal static method QTreeV_AddClassName;

			// Token: 0x040011E0 RID: 4576
			internal static method QTreeV_Polish;

			// Token: 0x040011E1 RID: 4577
			internal static method QTreeV_toolTip;

			// Token: 0x040011E2 RID: 4578
			internal static method QTreeV_setToolTip;

			// Token: 0x040011E3 RID: 4579
			internal static method QTreeV_statusTip;

			// Token: 0x040011E4 RID: 4580
			internal static method QTreeV_setStatusTip;

			// Token: 0x040011E5 RID: 4581
			internal static method QTreeV_toolTipDuration;

			// Token: 0x040011E6 RID: 4582
			internal static method QTreeV_setToolTipDuration;

			// Token: 0x040011E7 RID: 4583
			internal static method QTreeV_autoFillBackground;

			// Token: 0x040011E8 RID: 4584
			internal static method QTreeV_setAutoFillBackground;
		}
	}
}
