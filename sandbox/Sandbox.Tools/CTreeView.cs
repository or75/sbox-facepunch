using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x0200001A RID: 26
internal struct CTreeView
{
	// Token: 0x0600017F RID: 383 RVA: 0x00005775 File Offset: 0x00003975
	public static implicit operator IntPtr(CTreeView value)
	{
		return value.self;
	}

	// Token: 0x06000180 RID: 384 RVA: 0x00005780 File Offset: 0x00003980
	public static implicit operator CTreeView(IntPtr value)
	{
		return new CTreeView
		{
			self = value
		};
	}

	// Token: 0x06000181 RID: 385 RVA: 0x0000579E File Offset: 0x0000399E
	public static bool operator ==(CTreeView c1, CTreeView c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x06000182 RID: 386 RVA: 0x000057B1 File Offset: 0x000039B1
	public static bool operator !=(CTreeView c1, CTreeView c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x06000183 RID: 387 RVA: 0x000057C4 File Offset: 0x000039C4
	public override bool Equals(object obj)
	{
		if (obj is CTreeView)
		{
			CTreeView c = (CTreeView)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x06000184 RID: 388 RVA: 0x000057EE File Offset: 0x000039EE
	internal CTreeView(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x06000185 RID: 389 RVA: 0x000057F8 File Offset: 0x000039F8
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CTreeView ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x06000186 RID: 390 RVA: 0x00005834 File Offset: 0x00003A34
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x06000187 RID: 391 RVA: 0x00005846 File Offset: 0x00003A46
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x06000188 RID: 392 RVA: 0x00005851 File Offset: 0x00003A51
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x00005864 File Offset: 0x00003A64
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CTreeView was null when calling " + n);
		}
	}

	// Token: 0x0600018A RID: 394 RVA: 0x0000587F File Offset: 0x00003A7F
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x0600018B RID: 395 RVA: 0x0000588C File Offset: 0x00003A8C
	public static implicit operator QTreeView(CTreeView value)
	{
		method to_QTreeView_From_CTreeView = CTreeView.__N.To_QTreeView_From_CTreeView;
		return calli(System.IntPtr(System.IntPtr), value, to_QTreeView_From_CTreeView);
	}

	// Token: 0x0600018C RID: 396 RVA: 0x000058B0 File Offset: 0x00003AB0
	public static explicit operator CTreeView(QTreeView value)
	{
		method from_QTreeView_To_CTreeView = CTreeView.__N.From_QTreeView_To_CTreeView;
		return calli(System.IntPtr(System.IntPtr), value, from_QTreeView_To_CTreeView);
	}

	// Token: 0x0600018D RID: 397 RVA: 0x000058D4 File Offset: 0x00003AD4
	public static implicit operator QWidget(CTreeView value)
	{
		method to_QWidget_From_CTreeView = CTreeView.__N.To_QWidget_From_CTreeView;
		return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_CTreeView);
	}

	// Token: 0x0600018E RID: 398 RVA: 0x000058F8 File Offset: 0x00003AF8
	public static explicit operator CTreeView(QWidget value)
	{
		method from_QWidget_To_CTreeView = CTreeView.__N.From_QWidget_To_CTreeView;
		return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_CTreeView);
	}

	// Token: 0x0600018F RID: 399 RVA: 0x0000591C File Offset: 0x00003B1C
	public static implicit operator Native.QObject(CTreeView value)
	{
		method to_QObject_From_CTreeView = CTreeView.__N.To_QObject_From_CTreeView;
		return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_CTreeView);
	}

	// Token: 0x06000190 RID: 400 RVA: 0x00005940 File Offset: 0x00003B40
	public static explicit operator CTreeView(Native.QObject value)
	{
		method from_QObject_To_CTreeView = CTreeView.__N.From_QObject_To_CTreeView;
		return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_CTreeView);
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00005964 File Offset: 0x00003B64
	internal static CTreeView Create(QWidget parent, TreeView obj)
	{
		method ctreeV_Create = CTreeView.__N.CTreeV_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (obj == null) ? 0U : InteropSystem.GetAddress<TreeView>(obj, true), ctreeV_Create);
	}

	// Token: 0x06000192 RID: 402 RVA: 0x00005998 File Offset: 0x00003B98
	internal readonly void setModelInternal(CDataModel model)
	{
		this.NullCheck("setModelInternal");
		method ctreeV_setModelInternal = CTreeView.__N.CTreeV_setModelInternal;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, model, ctreeV_setModelInternal);
	}

	// Token: 0x06000193 RID: 403 RVA: 0x000059C8 File Offset: 0x00003BC8
	internal unsafe readonly void setIndexWidget(ModelIndex idx, QWidget w)
	{
		this.NullCheck("setIndexWidget");
		method ctreeV_setIndexWidget = CTreeView.__N.CTreeV_setIndexWidget;
		calli(System.Void(System.IntPtr,Tools.ModelIndex*,System.IntPtr), this.self, &idx, w, ctreeV_setIndexWidget);
	}

	// Token: 0x06000194 RID: 404 RVA: 0x000059FC File Offset: 0x00003BFC
	internal readonly bool isHeaderHidden()
	{
		this.NullCheck("isHeaderHidden");
		method ctreeV_isHeaderHidden = CTreeView.__N.CTreeV_isHeaderHidden;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isHeaderHidden) > 0;
	}

	// Token: 0x06000195 RID: 405 RVA: 0x00005A2C File Offset: 0x00003C2C
	internal readonly void setHeaderHidden(bool hide)
	{
		this.NullCheck("setHeaderHidden");
		method ctreeV_setHeaderHidden = CTreeView.__N.CTreeV_setHeaderHidden;
		calli(System.Void(System.IntPtr,System.Int32), this.self, hide ? 1 : 0, ctreeV_setHeaderHidden);
	}

	// Token: 0x06000196 RID: 406 RVA: 0x00005A60 File Offset: 0x00003C60
	internal readonly int autoExpandDelay()
	{
		this.NullCheck("autoExpandDelay");
		method ctreeV_autoExpandDelay = CTreeView.__N.CTreeV_autoExpandDelay;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_autoExpandDelay);
	}

	// Token: 0x06000197 RID: 407 RVA: 0x00005A8C File Offset: 0x00003C8C
	internal readonly void setAutoExpandDelay(int delay)
	{
		this.NullCheck("setAutoExpandDelay");
		method ctreeV_setAutoExpandDelay = CTreeView.__N.CTreeV_setAutoExpandDelay;
		calli(System.Void(System.IntPtr,System.Int32), this.self, delay, ctreeV_setAutoExpandDelay);
	}

	// Token: 0x06000198 RID: 408 RVA: 0x00005AB8 File Offset: 0x00003CB8
	internal readonly int indentation()
	{
		this.NullCheck("indentation");
		method ctreeV_indentation = CTreeView.__N.CTreeV_indentation;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_indentation);
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00005AE4 File Offset: 0x00003CE4
	internal readonly void setIndentation(int i)
	{
		this.NullCheck("setIndentation");
		method ctreeV_setIndentation = CTreeView.__N.CTreeV_setIndentation;
		calli(System.Void(System.IntPtr,System.Int32), this.self, i, ctreeV_setIndentation);
	}

	// Token: 0x0600019A RID: 410 RVA: 0x00005B10 File Offset: 0x00003D10
	internal readonly void resetIndentation()
	{
		this.NullCheck("resetIndentation");
		method ctreeV_resetIndentation = CTreeView.__N.CTreeV_resetIndentation;
		calli(System.Void(System.IntPtr), this.self, ctreeV_resetIndentation);
	}

	// Token: 0x0600019B RID: 411 RVA: 0x00005B3C File Offset: 0x00003D3C
	internal readonly bool itemsExpandable()
	{
		this.NullCheck("itemsExpandable");
		method ctreeV_itemsExpandable = CTreeView.__N.CTreeV_itemsExpandable;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_itemsExpandable) > 0;
	}

	// Token: 0x0600019C RID: 412 RVA: 0x00005B6C File Offset: 0x00003D6C
	internal readonly void setItemsExpandable(bool enable)
	{
		this.NullCheck("setItemsExpandable");
		method ctreeV_setItemsExpandable = CTreeView.__N.CTreeV_setItemsExpandable;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, ctreeV_setItemsExpandable);
	}

	// Token: 0x0600019D RID: 413 RVA: 0x00005BA0 File Offset: 0x00003DA0
	internal readonly bool expandsOnDoubleClick()
	{
		this.NullCheck("expandsOnDoubleClick");
		method ctreeV_expandsOnDoubleClick = CTreeView.__N.CTreeV_expandsOnDoubleClick;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_expandsOnDoubleClick) > 0;
	}

	// Token: 0x0600019E RID: 414 RVA: 0x00005BD0 File Offset: 0x00003DD0
	internal readonly void setExpandsOnDoubleClick(bool enable)
	{
		this.NullCheck("setExpandsOnDoubleClick");
		method ctreeV_setExpandsOnDoubleClick = CTreeView.__N.CTreeV_setExpandsOnDoubleClick;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, ctreeV_setExpandsOnDoubleClick);
	}

	// Token: 0x0600019F RID: 415 RVA: 0x00005C04 File Offset: 0x00003E04
	internal readonly int columnViewportPosition(int column)
	{
		this.NullCheck("columnViewportPosition");
		method ctreeV_columnViewportPosition = CTreeView.__N.CTreeV_columnViewportPosition;
		return calli(System.Int32(System.IntPtr,System.Int32), this.self, column, ctreeV_columnViewportPosition);
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x00005C30 File Offset: 0x00003E30
	internal readonly int columnWidth(int column)
	{
		this.NullCheck("columnWidth");
		method ctreeV_columnWidth = CTreeView.__N.CTreeV_columnWidth;
		return calli(System.Int32(System.IntPtr,System.Int32), this.self, column, ctreeV_columnWidth);
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x00005C5C File Offset: 0x00003E5C
	internal readonly void setColumnWidth(int column, int width)
	{
		this.NullCheck("setColumnWidth");
		method ctreeV_setColumnWidth = CTreeView.__N.CTreeV_setColumnWidth;
		calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, column, width, ctreeV_setColumnWidth);
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x00005C88 File Offset: 0x00003E88
	internal readonly int columnAt(int x)
	{
		this.NullCheck("columnAt");
		method ctreeV_columnAt = CTreeView.__N.CTreeV_columnAt;
		return calli(System.Int32(System.IntPtr,System.Int32), this.self, x, ctreeV_columnAt);
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x00005CB4 File Offset: 0x00003EB4
	internal readonly bool isColumnHidden(int column)
	{
		this.NullCheck("isColumnHidden");
		method ctreeV_isColumnHidden = CTreeView.__N.CTreeV_isColumnHidden;
		return calli(System.Int32(System.IntPtr,System.Int32), this.self, column, ctreeV_isColumnHidden) > 0;
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x00005CE4 File Offset: 0x00003EE4
	internal readonly void setColumnHidden(int column, bool hide)
	{
		this.NullCheck("setColumnHidden");
		method ctreeV_setColumnHidden = CTreeView.__N.CTreeV_setColumnHidden;
		calli(System.Void(System.IntPtr,System.Int32,System.Int32), this.self, column, hide ? 1 : 0, ctreeV_setColumnHidden);
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x00005D18 File Offset: 0x00003F18
	internal unsafe readonly bool isExpanded(ModelIndex index)
	{
		this.NullCheck("isExpanded");
		method ctreeV_isExpanded = CTreeView.__N.CTreeV_isExpanded;
		return calli(System.Int32(System.IntPtr,Tools.ModelIndex*), this.self, &index, ctreeV_isExpanded) > 0;
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x00005D48 File Offset: 0x00003F48
	internal unsafe readonly void setExpanded(ModelIndex index, bool expand)
	{
		this.NullCheck("setExpanded");
		method ctreeV_setExpanded = CTreeView.__N.CTreeV_setExpanded;
		calli(System.Void(System.IntPtr,Tools.ModelIndex*,System.Int32), this.self, &index, expand ? 1 : 0, ctreeV_setExpanded);
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00005D7C File Offset: 0x00003F7C
	internal readonly void setSortingEnabled(bool enable)
	{
		this.NullCheck("setSortingEnabled");
		method ctreeV_setSortingEnabled = CTreeView.__N.CTreeV_setSortingEnabled;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, ctreeV_setSortingEnabled);
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x00005DB0 File Offset: 0x00003FB0
	internal readonly bool isSortingEnabled()
	{
		this.NullCheck("isSortingEnabled");
		method ctreeV_isSortingEnabled = CTreeView.__N.CTreeV_isSortingEnabled;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isSortingEnabled) > 0;
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x00005DE0 File Offset: 0x00003FE0
	internal readonly void setAnimated(bool enable)
	{
		this.NullCheck("setAnimated");
		method ctreeV_setAnimated = CTreeView.__N.CTreeV_setAnimated;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, ctreeV_setAnimated);
	}

	// Token: 0x060001AA RID: 426 RVA: 0x00005E14 File Offset: 0x00004014
	internal readonly bool isAnimated()
	{
		this.NullCheck("isAnimated");
		method ctreeV_isAnimated = CTreeView.__N.CTreeV_isAnimated;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isAnimated) > 0;
	}

	// Token: 0x060001AB RID: 427 RVA: 0x00005E44 File Offset: 0x00004044
	internal readonly void setAllColumnsShowFocus(bool enable)
	{
		this.NullCheck("setAllColumnsShowFocus");
		method ctreeV_setAllColumnsShowFocus = CTreeView.__N.CTreeV_setAllColumnsShowFocus;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, ctreeV_setAllColumnsShowFocus);
	}

	// Token: 0x060001AC RID: 428 RVA: 0x00005E78 File Offset: 0x00004078
	internal readonly bool allColumnsShowFocus()
	{
		this.NullCheck("allColumnsShowFocus");
		method ctreeV_allColumnsShowFocus = CTreeView.__N.CTreeV_allColumnsShowFocus;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_allColumnsShowFocus) > 0;
	}

	// Token: 0x060001AD RID: 429 RVA: 0x00005EA8 File Offset: 0x000040A8
	internal readonly void setWordWrap(bool on)
	{
		this.NullCheck("setWordWrap");
		method ctreeV_setWordWrap = CTreeView.__N.CTreeV_setWordWrap;
		calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, ctreeV_setWordWrap);
	}

	// Token: 0x060001AE RID: 430 RVA: 0x00005EDC File Offset: 0x000040DC
	internal readonly bool wordWrap()
	{
		this.NullCheck("wordWrap");
		method ctreeV_wordWrap = CTreeView.__N.CTreeV_wordWrap;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_wordWrap) > 0;
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00005F0C File Offset: 0x0000410C
	internal readonly void setTreePosition(int logicalIndex)
	{
		this.NullCheck("setTreePosition");
		method ctreeV_setTreePosition = CTreeView.__N.CTreeV_setTreePosition;
		calli(System.Void(System.IntPtr,System.Int32), this.self, logicalIndex, ctreeV_setTreePosition);
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x00005F38 File Offset: 0x00004138
	internal readonly int treePosition()
	{
		this.NullCheck("treePosition");
		method ctreeV_treePosition = CTreeView.__N.CTreeV_treePosition;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_treePosition);
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x00005F64 File Offset: 0x00004164
	internal unsafe readonly QRectF visualRect(ModelIndex index)
	{
		this.NullCheck("visualRect");
		method ctreeV_visualRect = CTreeView.__N.CTreeV_visualRect;
		return calli(QRectF(System.IntPtr,Tools.ModelIndex*), this.self, &index, ctreeV_visualRect);
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00005F94 File Offset: 0x00004194
	internal unsafe readonly void scrollTo(ModelIndex index)
	{
		this.NullCheck("scrollTo");
		method ctreeV_scrollTo = CTreeView.__N.CTreeV_scrollTo;
		calli(System.Void(System.IntPtr,Tools.ModelIndex*), this.self, &index, ctreeV_scrollTo);
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x00005FC4 File Offset: 0x000041C4
	internal readonly ModelIndex indexAt(Vector3 p)
	{
		this.NullCheck("indexAt");
		method ctreeV_indexAt = CTreeView.__N.CTreeV_indexAt;
		return calli(Tools.ModelIndex(System.IntPtr,Vector3), this.self, p, ctreeV_indexAt);
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x00005FF0 File Offset: 0x000041F0
	internal unsafe readonly ModelIndex indexAbove(ModelIndex index)
	{
		this.NullCheck("indexAbove");
		method ctreeV_indexAbove = CTreeView.__N.CTreeV_indexAbove;
		return calli(Tools.ModelIndex(System.IntPtr,Tools.ModelIndex*), this.self, &index, ctreeV_indexAbove);
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x00006020 File Offset: 0x00004220
	internal unsafe readonly ModelIndex indexBelow(ModelIndex index)
	{
		this.NullCheck("indexBelow");
		method ctreeV_indexBelow = CTreeView.__N.CTreeV_indexBelow;
		return calli(Tools.ModelIndex(System.IntPtr,Tools.ModelIndex*), this.self, &index, ctreeV_indexBelow);
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x00006050 File Offset: 0x00004250
	internal readonly bool uniformRowHeights()
	{
		this.NullCheck("uniformRowHeights");
		method ctreeV_uniformRowHeights = CTreeView.__N.CTreeV_uniformRowHeights;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_uniformRowHeights) > 0;
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00006080 File Offset: 0x00004280
	internal readonly void setUniformRowHeights(bool uniform)
	{
		this.NullCheck("setUniformRowHeights");
		method ctreeV_setUniformRowHeights = CTreeView.__N.CTreeV_setUniformRowHeights;
		calli(System.Void(System.IntPtr,System.Int32), this.self, uniform ? 1 : 0, ctreeV_setUniformRowHeights);
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x000060B4 File Offset: 0x000042B4
	internal readonly void setItemDelegate(CDataDelegate del)
	{
		this.NullCheck("setItemDelegate");
		method ctreeV_setItemDelegate = CTreeView.__N.CTreeV_setItemDelegate;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, del, ctreeV_setItemDelegate);
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x000060E4 File Offset: 0x000042E4
	internal readonly bool isTopLevel()
	{
		this.NullCheck("isTopLevel");
		method ctreeV_isTopLevel = CTreeView.__N.CTreeV_isTopLevel;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isTopLevel) > 0;
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00006114 File Offset: 0x00004314
	internal readonly bool isWindow()
	{
		this.NullCheck("isWindow");
		method ctreeV_isWindow = CTreeView.__N.CTreeV_isWindow;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isWindow) > 0;
	}

	// Token: 0x060001BB RID: 443 RVA: 0x00006144 File Offset: 0x00004344
	internal readonly bool isModal()
	{
		this.NullCheck("isModal");
		method ctreeV_isModal = CTreeView.__N.CTreeV_isModal;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isModal) > 0;
	}

	// Token: 0x060001BC RID: 444 RVA: 0x00006174 File Offset: 0x00004374
	internal readonly void setStyleSheet(string sheet)
	{
		this.NullCheck("setStyleSheet");
		method ctreeV_setStyleSheet = CTreeView.__N.CTreeV_setStyleSheet;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), ctreeV_setStyleSheet);
	}

	// Token: 0x060001BD RID: 445 RVA: 0x000061A4 File Offset: 0x000043A4
	internal readonly string windowTitle()
	{
		this.NullCheck("windowTitle");
		method ctreeV_windowTitle = CTreeView.__N.CTreeV_windowTitle;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, ctreeV_windowTitle));
	}

	// Token: 0x060001BE RID: 446 RVA: 0x000061D4 File Offset: 0x000043D4
	internal readonly void setWindowTitle(string title)
	{
		this.NullCheck("setWindowTitle");
		method ctreeV_setWindowTitle = CTreeView.__N.CTreeV_setWindowTitle;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), ctreeV_setWindowTitle);
	}

	// Token: 0x060001BF RID: 447 RVA: 0x00006204 File Offset: 0x00004404
	internal readonly void setWindowFlags(WindowFlags type)
	{
		this.NullCheck("setWindowFlags");
		method ctreeV_setWindowFlags = CTreeView.__N.CTreeV_setWindowFlags;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, ctreeV_setWindowFlags);
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x00006230 File Offset: 0x00004430
	internal readonly WindowFlags windowFlags()
	{
		this.NullCheck("windowFlags");
		method ctreeV_windowFlags = CTreeView.__N.CTreeV_windowFlags;
		return calli(System.Int64(System.IntPtr), this.self, ctreeV_windowFlags);
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0000625C File Offset: 0x0000445C
	internal readonly Vector3 size()
	{
		this.NullCheck("size");
		method ctreeV_size = CTreeView.__N.CTreeV_size;
		return calli(Vector3(System.IntPtr), this.self, ctreeV_size);
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x00006288 File Offset: 0x00004488
	internal readonly void resize(Vector3 x)
	{
		this.NullCheck("resize");
		method ctreeV_resize = CTreeView.__N.CTreeV_resize;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, ctreeV_resize);
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x000062B4 File Offset: 0x000044B4
	internal readonly Vector3 minimumSize()
	{
		this.NullCheck("minimumSize");
		method ctreeV_minimumSize = CTreeView.__N.CTreeV_minimumSize;
		return calli(Vector3(System.IntPtr), this.self, ctreeV_minimumSize);
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x000062E0 File Offset: 0x000044E0
	internal readonly void setMinimumSize(Vector3 x)
	{
		this.NullCheck("setMinimumSize");
		method ctreeV_setMinimumSize = CTreeView.__N.CTreeV_setMinimumSize;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, ctreeV_setMinimumSize);
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x0000630C File Offset: 0x0000450C
	internal readonly Vector3 maximumSize()
	{
		this.NullCheck("maximumSize");
		method ctreeV_maximumSize = CTreeView.__N.CTreeV_maximumSize;
		return calli(Vector3(System.IntPtr), this.self, ctreeV_maximumSize);
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x00006338 File Offset: 0x00004538
	internal readonly void setMaximumSize(Vector3 x)
	{
		this.NullCheck("setMaximumSize");
		method ctreeV_setMaximumSize = CTreeView.__N.CTreeV_setMaximumSize;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, ctreeV_setMaximumSize);
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x00006364 File Offset: 0x00004564
	internal readonly Vector3 pos()
	{
		this.NullCheck("pos");
		method ctreeV_pos = CTreeView.__N.CTreeV_pos;
		return calli(Vector3(System.IntPtr), this.self, ctreeV_pos);
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x00006390 File Offset: 0x00004590
	internal readonly void move(Vector3 x)
	{
		this.NullCheck("move");
		method ctreeV_move = CTreeView.__N.CTreeV_move;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, ctreeV_move);
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x000063BC File Offset: 0x000045BC
	internal readonly bool isEnabled()
	{
		this.NullCheck("isEnabled");
		method ctreeV_isEnabled = CTreeView.__N.CTreeV_isEnabled;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isEnabled) > 0;
	}

	// Token: 0x060001CA RID: 458 RVA: 0x000063EC File Offset: 0x000045EC
	internal readonly void setEnabled(bool x)
	{
		this.NullCheck("setEnabled");
		method ctreeV_setEnabled = CTreeView.__N.CTreeV_setEnabled;
		calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, ctreeV_setEnabled);
	}

	// Token: 0x060001CB RID: 459 RVA: 0x00006420 File Offset: 0x00004620
	internal readonly void setVisible(bool visible)
	{
		this.NullCheck("setVisible");
		method ctreeV_setVisible = CTreeView.__N.CTreeV_setVisible;
		calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, ctreeV_setVisible);
	}

	// Token: 0x060001CC RID: 460 RVA: 0x00006454 File Offset: 0x00004654
	internal readonly void setHidden(bool hidden)
	{
		this.NullCheck("setHidden");
		method ctreeV_setHidden = CTreeView.__N.CTreeV_setHidden;
		calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, ctreeV_setHidden);
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00006488 File Offset: 0x00004688
	internal readonly void show()
	{
		this.NullCheck("show");
		method ctreeV_show = CTreeView.__N.CTreeV_show;
		calli(System.Void(System.IntPtr), this.self, ctreeV_show);
	}

	// Token: 0x060001CE RID: 462 RVA: 0x000064B4 File Offset: 0x000046B4
	internal readonly void hide()
	{
		this.NullCheck("hide");
		method ctreeV_hide = CTreeView.__N.CTreeV_hide;
		calli(System.Void(System.IntPtr), this.self, ctreeV_hide);
	}

	// Token: 0x060001CF RID: 463 RVA: 0x000064E0 File Offset: 0x000046E0
	internal readonly void showMinimized()
	{
		this.NullCheck("showMinimized");
		method ctreeV_showMinimized = CTreeView.__N.CTreeV_showMinimized;
		calli(System.Void(System.IntPtr), this.self, ctreeV_showMinimized);
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x0000650C File Offset: 0x0000470C
	internal readonly void showMaximized()
	{
		this.NullCheck("showMaximized");
		method ctreeV_showMaximized = CTreeView.__N.CTreeV_showMaximized;
		calli(System.Void(System.IntPtr), this.self, ctreeV_showMaximized);
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x00006538 File Offset: 0x00004738
	internal readonly void showFullScreen()
	{
		this.NullCheck("showFullScreen");
		method ctreeV_showFullScreen = CTreeView.__N.CTreeV_showFullScreen;
		calli(System.Void(System.IntPtr), this.self, ctreeV_showFullScreen);
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x00006564 File Offset: 0x00004764
	internal readonly void showNormal()
	{
		this.NullCheck("showNormal");
		method ctreeV_showNormal = CTreeView.__N.CTreeV_showNormal;
		calli(System.Void(System.IntPtr), this.self, ctreeV_showNormal);
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x00006590 File Offset: 0x00004790
	internal readonly bool close()
	{
		this.NullCheck("close");
		method ctreeV_close = CTreeView.__N.CTreeV_close;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_close) > 0;
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x000065C0 File Offset: 0x000047C0
	internal readonly void raise()
	{
		this.NullCheck("raise");
		method ctreeV_raise = CTreeView.__N.CTreeV_raise;
		calli(System.Void(System.IntPtr), this.self, ctreeV_raise);
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x000065EC File Offset: 0x000047EC
	internal readonly void lower()
	{
		this.NullCheck("lower");
		method ctreeV_lower = CTreeView.__N.CTreeV_lower;
		calli(System.Void(System.IntPtr), this.self, ctreeV_lower);
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x00006618 File Offset: 0x00004818
	internal readonly bool isVisible()
	{
		this.NullCheck("isVisible");
		method ctreeV_isVisible = CTreeView.__N.CTreeV_isVisible;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isVisible) > 0;
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x00006648 File Offset: 0x00004848
	internal readonly void setAttribute(Widget.Flag a, bool on)
	{
		this.NullCheck("setAttribute");
		method ctreeV_setAttribute = CTreeView.__N.CTreeV_setAttribute;
		calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, ctreeV_setAttribute);
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x0000667C File Offset: 0x0000487C
	internal readonly bool testAttribute(Widget.Flag a)
	{
		this.NullCheck("testAttribute");
		method ctreeV_testAttribute = CTreeView.__N.CTreeV_testAttribute;
		return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, ctreeV_testAttribute) > 0;
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x000066AC File Offset: 0x000048AC
	internal readonly bool acceptDrops()
	{
		this.NullCheck("acceptDrops");
		method ctreeV_acceptDrops = CTreeView.__N.CTreeV_acceptDrops;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_acceptDrops) > 0;
	}

	// Token: 0x060001DA RID: 474 RVA: 0x000066DC File Offset: 0x000048DC
	internal readonly void setAcceptDrops(bool on)
	{
		this.NullCheck("setAcceptDrops");
		method ctreeV_setAcceptDrops = CTreeView.__N.CTreeV_setAcceptDrops;
		calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, ctreeV_setAcceptDrops);
	}

	// Token: 0x060001DB RID: 475 RVA: 0x00006710 File Offset: 0x00004910
	internal readonly void update()
	{
		this.NullCheck("update");
		method ctreeV_update = CTreeView.__N.CTreeV_update;
		calli(System.Void(System.IntPtr), this.self, ctreeV_update);
	}

	// Token: 0x060001DC RID: 476 RVA: 0x0000673C File Offset: 0x0000493C
	internal readonly void repaint()
	{
		this.NullCheck("repaint");
		method ctreeV_repaint = CTreeView.__N.CTreeV_repaint;
		calli(System.Void(System.IntPtr), this.self, ctreeV_repaint);
	}

	// Token: 0x060001DD RID: 477 RVA: 0x00006768 File Offset: 0x00004968
	internal readonly void setCursor(CursorShape shape)
	{
		this.NullCheck("setCursor");
		method ctreeV_setCursor = CTreeView.__N.CTreeV_setCursor;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, ctreeV_setCursor);
	}

	// Token: 0x060001DE RID: 478 RVA: 0x00006794 File Offset: 0x00004994
	internal readonly void unsetCursor()
	{
		this.NullCheck("unsetCursor");
		method ctreeV_unsetCursor = CTreeView.__N.CTreeV_unsetCursor;
		calli(System.Void(System.IntPtr), this.self, ctreeV_unsetCursor);
	}

	// Token: 0x060001DF RID: 479 RVA: 0x000067C0 File Offset: 0x000049C0
	internal readonly void setWindowIcon(string icon)
	{
		this.NullCheck("setWindowIcon");
		method ctreeV_setWindowIcon = CTreeView.__N.CTreeV_setWindowIcon;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), ctreeV_setWindowIcon);
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x000067F0 File Offset: 0x000049F0
	internal readonly void setWindowIconText(string str)
	{
		this.NullCheck("setWindowIconText");
		method ctreeV_setWindowIconText = CTreeView.__N.CTreeV_setWindowIconText;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), ctreeV_setWindowIconText);
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x00006820 File Offset: 0x00004A20
	internal readonly void setWindowOpacity(float level)
	{
		this.NullCheck("setWindowOpacity");
		method ctreeV_setWindowOpacity = CTreeView.__N.CTreeV_setWindowOpacity;
		calli(System.Void(System.IntPtr,System.Single), this.self, level, ctreeV_setWindowOpacity);
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x0000684C File Offset: 0x00004A4C
	internal readonly float windowOpacity()
	{
		this.NullCheck("windowOpacity");
		method ctreeV_windowOpacity = CTreeView.__N.CTreeV_windowOpacity;
		return calli(System.Single(System.IntPtr), this.self, ctreeV_windowOpacity);
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x00006878 File Offset: 0x00004A78
	internal readonly bool isMinimized()
	{
		this.NullCheck("isMinimized");
		method ctreeV_isMinimized = CTreeView.__N.CTreeV_isMinimized;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isMinimized) > 0;
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x000068A8 File Offset: 0x00004AA8
	internal readonly bool isMaximized()
	{
		this.NullCheck("isMaximized");
		method ctreeV_isMaximized = CTreeView.__N.CTreeV_isMaximized;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isMaximized) > 0;
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x000068D8 File Offset: 0x00004AD8
	internal readonly bool isFullScreen()
	{
		this.NullCheck("isFullScreen");
		method ctreeV_isFullScreen = CTreeView.__N.CTreeV_isFullScreen;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isFullScreen) > 0;
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x00006908 File Offset: 0x00004B08
	internal readonly void setMouseTracking(bool enable)
	{
		this.NullCheck("setMouseTracking");
		method ctreeV_setMouseTracking = CTreeView.__N.CTreeV_setMouseTracking;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, ctreeV_setMouseTracking);
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0000693C File Offset: 0x00004B3C
	internal readonly bool hasMouseTracking()
	{
		this.NullCheck("hasMouseTracking");
		method ctreeV_hasMouseTracking = CTreeView.__N.CTreeV_hasMouseTracking;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_hasMouseTracking) > 0;
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0000696C File Offset: 0x00004B6C
	internal readonly bool underMouse()
	{
		this.NullCheck("underMouse");
		method ctreeV_underMouse = CTreeView.__N.CTreeV_underMouse;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_underMouse) > 0;
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x0000699C File Offset: 0x00004B9C
	internal readonly Vector3 mapToGlobal(Vector3 p)
	{
		this.NullCheck("mapToGlobal");
		method ctreeV_mapToGlobal = CTreeView.__N.CTreeV_mapToGlobal;
		return calli(Vector3(System.IntPtr,Vector3), this.self, p, ctreeV_mapToGlobal);
	}

	// Token: 0x060001EA RID: 490 RVA: 0x000069C8 File Offset: 0x00004BC8
	internal readonly Vector3 mapFromGlobal(Vector3 p)
	{
		this.NullCheck("mapFromGlobal");
		method ctreeV_mapFromGlobal = CTreeView.__N.CTreeV_mapFromGlobal;
		return calli(Vector3(System.IntPtr,Vector3), this.self, p, ctreeV_mapFromGlobal);
	}

	// Token: 0x060001EB RID: 491 RVA: 0x000069F4 File Offset: 0x00004BF4
	internal readonly bool hasFocus()
	{
		this.NullCheck("hasFocus");
		method ctreeV_hasFocus = CTreeView.__N.CTreeV_hasFocus;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_hasFocus) > 0;
	}

	// Token: 0x060001EC RID: 492 RVA: 0x00006A24 File Offset: 0x00004C24
	internal readonly FocusMode focusPolicy()
	{
		this.NullCheck("focusPolicy");
		method ctreeV_focusPolicy = CTreeView.__N.CTreeV_focusPolicy;
		return calli(System.Int64(System.IntPtr), this.self, ctreeV_focusPolicy);
	}

	// Token: 0x060001ED RID: 493 RVA: 0x00006A50 File Offset: 0x00004C50
	internal readonly void setFocusPolicy(FocusMode policy)
	{
		this.NullCheck("setFocusPolicy");
		method ctreeV_setFocusPolicy = CTreeView.__N.CTreeV_setFocusPolicy;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, ctreeV_setFocusPolicy);
	}

	// Token: 0x060001EE RID: 494 RVA: 0x00006A7C File Offset: 0x00004C7C
	internal readonly void setFocusProxy(QWidget widget)
	{
		this.NullCheck("setFocusProxy");
		method ctreeV_setFocusProxy = CTreeView.__N.CTreeV_setFocusProxy;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, ctreeV_setFocusProxy);
	}

	// Token: 0x060001EF RID: 495 RVA: 0x00006AAC File Offset: 0x00004CAC
	internal readonly bool isActiveWindow()
	{
		this.NullCheck("isActiveWindow");
		method ctreeV_isActiveWindow = CTreeView.__N.CTreeV_isActiveWindow;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_isActiveWindow) > 0;
	}

	// Token: 0x060001F0 RID: 496 RVA: 0x00006ADC File Offset: 0x00004CDC
	internal readonly bool updatesEnabled()
	{
		this.NullCheck("updatesEnabled");
		method ctreeV_updatesEnabled = CTreeView.__N.CTreeV_updatesEnabled;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_updatesEnabled) > 0;
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x00006B0C File Offset: 0x00004D0C
	internal readonly void setUpdatesEnabled(bool enable)
	{
		this.NullCheck("setUpdatesEnabled");
		method ctreeV_setUpdatesEnabled = CTreeView.__N.CTreeV_setUpdatesEnabled;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, ctreeV_setUpdatesEnabled);
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00006B40 File Offset: 0x00004D40
	internal readonly void setFocus()
	{
		this.NullCheck("setFocus");
		method ctreeV_setFocus = CTreeView.__N.CTreeV_setFocus;
		calli(System.Void(System.IntPtr), this.self, ctreeV_setFocus);
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x00006B6C File Offset: 0x00004D6C
	internal readonly void activateWindow()
	{
		this.NullCheck("activateWindow");
		method ctreeV_activateWindow = CTreeView.__N.CTreeV_activateWindow;
		calli(System.Void(System.IntPtr), this.self, ctreeV_activateWindow);
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x00006B98 File Offset: 0x00004D98
	internal readonly void clearFocus()
	{
		this.NullCheck("clearFocus");
		method ctreeV_clearFocus = CTreeView.__N.CTreeV_clearFocus;
		calli(System.Void(System.IntPtr), this.self, ctreeV_clearFocus);
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00006BC4 File Offset: 0x00004DC4
	internal readonly void setSizePolicy(SizeMode x, SizeMode y)
	{
		this.NullCheck("setSizePolicy");
		method ctreeV_setSizePolicy = CTreeView.__N.CTreeV_setSizePolicy;
		calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, ctreeV_setSizePolicy);
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x00006BF4 File Offset: 0x00004DF4
	internal readonly float devicePixelRatioF()
	{
		this.NullCheck("devicePixelRatioF");
		method ctreeV_devicePixelRatioF = CTreeView.__N.CTreeV_devicePixelRatioF;
		return calli(System.Single(System.IntPtr), this.self, ctreeV_devicePixelRatioF);
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x00006C20 File Offset: 0x00004E20
	internal readonly string saveGeometry()
	{
		this.NullCheck("saveGeometry");
		method ctreeV_saveGeometry = CTreeView.__N.CTreeV_saveGeometry;
		return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, ctreeV_saveGeometry));
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x00006C50 File Offset: 0x00004E50
	internal readonly bool restoreGeometry(string state)
	{
		this.NullCheck("restoreGeometry");
		method ctreeV_restoreGeometry = CTreeView.__N.CTreeV_restoreGeometry;
		return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), ctreeV_restoreGeometry) > 0;
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x00006C84 File Offset: 0x00004E84
	internal readonly void addAction(QAction action)
	{
		this.NullCheck("addAction");
		method ctreeV_addAction = CTreeView.__N.CTreeV_addAction;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, ctreeV_addAction);
	}

	// Token: 0x060001FA RID: 506 RVA: 0x00006CB4 File Offset: 0x00004EB4
	internal readonly void removeAction(QAction action)
	{
		this.NullCheck("removeAction");
		method ctreeV_removeAction = CTreeView.__N.CTreeV_removeAction;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, ctreeV_removeAction);
	}

	// Token: 0x060001FB RID: 507 RVA: 0x00006CE4 File Offset: 0x00004EE4
	internal readonly void setParent(QWidget parent)
	{
		this.NullCheck("setParent");
		method ctreeV_setParent = CTreeView.__N.CTreeV_setParent;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, ctreeV_setParent);
	}

	// Token: 0x060001FC RID: 508 RVA: 0x00006D14 File Offset: 0x00004F14
	internal readonly QWidget parentWidget()
	{
		this.NullCheck("parentWidget");
		method ctreeV_parentWidget = CTreeView.__N.CTreeV_parentWidget;
		return calli(System.IntPtr(System.IntPtr), this.self, ctreeV_parentWidget);
	}

	// Token: 0x060001FD RID: 509 RVA: 0x00006D44 File Offset: 0x00004F44
	internal readonly void AddClassName(string name)
	{
		this.NullCheck("AddClassName");
		method ctreeV_AddClassName = CTreeView.__N.CTreeV_AddClassName;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), ctreeV_AddClassName);
	}

	// Token: 0x060001FE RID: 510 RVA: 0x00006D74 File Offset: 0x00004F74
	internal readonly void Polish()
	{
		this.NullCheck("Polish");
		method ctreeV_Polish = CTreeView.__N.CTreeV_Polish;
		calli(System.Void(System.IntPtr), this.self, ctreeV_Polish);
	}

	// Token: 0x060001FF RID: 511 RVA: 0x00006DA0 File Offset: 0x00004FA0
	internal readonly string toolTip()
	{
		this.NullCheck("toolTip");
		method ctreeV_toolTip = CTreeView.__N.CTreeV_toolTip;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, ctreeV_toolTip));
	}

	// Token: 0x06000200 RID: 512 RVA: 0x00006DD0 File Offset: 0x00004FD0
	internal readonly void setToolTip(string str)
	{
		this.NullCheck("setToolTip");
		method ctreeV_setToolTip = CTreeView.__N.CTreeV_setToolTip;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), ctreeV_setToolTip);
	}

	// Token: 0x06000201 RID: 513 RVA: 0x00006E00 File Offset: 0x00005000
	internal readonly string statusTip()
	{
		this.NullCheck("statusTip");
		method ctreeV_statusTip = CTreeView.__N.CTreeV_statusTip;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, ctreeV_statusTip));
	}

	// Token: 0x06000202 RID: 514 RVA: 0x00006E30 File Offset: 0x00005030
	internal readonly void setStatusTip(string str)
	{
		this.NullCheck("setStatusTip");
		method ctreeV_setStatusTip = CTreeView.__N.CTreeV_setStatusTip;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), ctreeV_setStatusTip);
	}

	// Token: 0x06000203 RID: 515 RVA: 0x00006E60 File Offset: 0x00005060
	internal readonly int toolTipDuration()
	{
		this.NullCheck("toolTipDuration");
		method ctreeV_toolTipDuration = CTreeView.__N.CTreeV_toolTipDuration;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_toolTipDuration);
	}

	// Token: 0x06000204 RID: 516 RVA: 0x00006E8C File Offset: 0x0000508C
	internal readonly void setToolTipDuration(int x)
	{
		this.NullCheck("setToolTipDuration");
		method ctreeV_setToolTipDuration = CTreeView.__N.CTreeV_setToolTipDuration;
		calli(System.Void(System.IntPtr,System.Int32), this.self, x, ctreeV_setToolTipDuration);
	}

	// Token: 0x06000205 RID: 517 RVA: 0x00006EB8 File Offset: 0x000050B8
	internal readonly bool autoFillBackground()
	{
		this.NullCheck("autoFillBackground");
		method ctreeV_autoFillBackground = CTreeView.__N.CTreeV_autoFillBackground;
		return calli(System.Int32(System.IntPtr), this.self, ctreeV_autoFillBackground) > 0;
	}

	// Token: 0x06000206 RID: 518 RVA: 0x00006EE8 File Offset: 0x000050E8
	internal readonly void setAutoFillBackground(bool enabled)
	{
		this.NullCheck("setAutoFillBackground");
		method ctreeV_setAutoFillBackground = CTreeView.__N.CTreeV_setAutoFillBackground;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, ctreeV_setAutoFillBackground);
	}

	// Token: 0x04000016 RID: 22
	internal IntPtr self;

	// Token: 0x020000EA RID: 234
	internal static class __N
	{
		// Token: 0x040005A9 RID: 1449
		internal static method From_QTreeView_To_CTreeView;

		// Token: 0x040005AA RID: 1450
		internal static method To_QTreeView_From_CTreeView;

		// Token: 0x040005AB RID: 1451
		internal static method From_QWidget_To_CTreeView;

		// Token: 0x040005AC RID: 1452
		internal static method To_QWidget_From_CTreeView;

		// Token: 0x040005AD RID: 1453
		internal static method From_QObject_To_CTreeView;

		// Token: 0x040005AE RID: 1454
		internal static method To_QObject_From_CTreeView;

		// Token: 0x040005AF RID: 1455
		internal static method CTreeV_Create;

		// Token: 0x040005B0 RID: 1456
		internal static method CTreeV_setModelInternal;

		// Token: 0x040005B1 RID: 1457
		internal static method CTreeV_setIndexWidget;

		// Token: 0x040005B2 RID: 1458
		internal static method CTreeV_isHeaderHidden;

		// Token: 0x040005B3 RID: 1459
		internal static method CTreeV_setHeaderHidden;

		// Token: 0x040005B4 RID: 1460
		internal static method CTreeV_autoExpandDelay;

		// Token: 0x040005B5 RID: 1461
		internal static method CTreeV_setAutoExpandDelay;

		// Token: 0x040005B6 RID: 1462
		internal static method CTreeV_indentation;

		// Token: 0x040005B7 RID: 1463
		internal static method CTreeV_setIndentation;

		// Token: 0x040005B8 RID: 1464
		internal static method CTreeV_resetIndentation;

		// Token: 0x040005B9 RID: 1465
		internal static method CTreeV_itemsExpandable;

		// Token: 0x040005BA RID: 1466
		internal static method CTreeV_setItemsExpandable;

		// Token: 0x040005BB RID: 1467
		internal static method CTreeV_expandsOnDoubleClick;

		// Token: 0x040005BC RID: 1468
		internal static method CTreeV_setExpandsOnDoubleClick;

		// Token: 0x040005BD RID: 1469
		internal static method CTreeV_columnViewportPosition;

		// Token: 0x040005BE RID: 1470
		internal static method CTreeV_columnWidth;

		// Token: 0x040005BF RID: 1471
		internal static method CTreeV_setColumnWidth;

		// Token: 0x040005C0 RID: 1472
		internal static method CTreeV_columnAt;

		// Token: 0x040005C1 RID: 1473
		internal static method CTreeV_isColumnHidden;

		// Token: 0x040005C2 RID: 1474
		internal static method CTreeV_setColumnHidden;

		// Token: 0x040005C3 RID: 1475
		internal static method CTreeV_isExpanded;

		// Token: 0x040005C4 RID: 1476
		internal static method CTreeV_setExpanded;

		// Token: 0x040005C5 RID: 1477
		internal static method CTreeV_setSortingEnabled;

		// Token: 0x040005C6 RID: 1478
		internal static method CTreeV_isSortingEnabled;

		// Token: 0x040005C7 RID: 1479
		internal static method CTreeV_setAnimated;

		// Token: 0x040005C8 RID: 1480
		internal static method CTreeV_isAnimated;

		// Token: 0x040005C9 RID: 1481
		internal static method CTreeV_setAllColumnsShowFocus;

		// Token: 0x040005CA RID: 1482
		internal static method CTreeV_allColumnsShowFocus;

		// Token: 0x040005CB RID: 1483
		internal static method CTreeV_setWordWrap;

		// Token: 0x040005CC RID: 1484
		internal static method CTreeV_wordWrap;

		// Token: 0x040005CD RID: 1485
		internal static method CTreeV_setTreePosition;

		// Token: 0x040005CE RID: 1486
		internal static method CTreeV_treePosition;

		// Token: 0x040005CF RID: 1487
		internal static method CTreeV_visualRect;

		// Token: 0x040005D0 RID: 1488
		internal static method CTreeV_scrollTo;

		// Token: 0x040005D1 RID: 1489
		internal static method CTreeV_indexAt;

		// Token: 0x040005D2 RID: 1490
		internal static method CTreeV_indexAbove;

		// Token: 0x040005D3 RID: 1491
		internal static method CTreeV_indexBelow;

		// Token: 0x040005D4 RID: 1492
		internal static method CTreeV_uniformRowHeights;

		// Token: 0x040005D5 RID: 1493
		internal static method CTreeV_setUniformRowHeights;

		// Token: 0x040005D6 RID: 1494
		internal static method CTreeV_setItemDelegate;

		// Token: 0x040005D7 RID: 1495
		internal static method CTreeV_isTopLevel;

		// Token: 0x040005D8 RID: 1496
		internal static method CTreeV_isWindow;

		// Token: 0x040005D9 RID: 1497
		internal static method CTreeV_isModal;

		// Token: 0x040005DA RID: 1498
		internal static method CTreeV_setStyleSheet;

		// Token: 0x040005DB RID: 1499
		internal static method CTreeV_windowTitle;

		// Token: 0x040005DC RID: 1500
		internal static method CTreeV_setWindowTitle;

		// Token: 0x040005DD RID: 1501
		internal static method CTreeV_setWindowFlags;

		// Token: 0x040005DE RID: 1502
		internal static method CTreeV_windowFlags;

		// Token: 0x040005DF RID: 1503
		internal static method CTreeV_size;

		// Token: 0x040005E0 RID: 1504
		internal static method CTreeV_resize;

		// Token: 0x040005E1 RID: 1505
		internal static method CTreeV_minimumSize;

		// Token: 0x040005E2 RID: 1506
		internal static method CTreeV_setMinimumSize;

		// Token: 0x040005E3 RID: 1507
		internal static method CTreeV_maximumSize;

		// Token: 0x040005E4 RID: 1508
		internal static method CTreeV_setMaximumSize;

		// Token: 0x040005E5 RID: 1509
		internal static method CTreeV_pos;

		// Token: 0x040005E6 RID: 1510
		internal static method CTreeV_move;

		// Token: 0x040005E7 RID: 1511
		internal static method CTreeV_isEnabled;

		// Token: 0x040005E8 RID: 1512
		internal static method CTreeV_setEnabled;

		// Token: 0x040005E9 RID: 1513
		internal static method CTreeV_setVisible;

		// Token: 0x040005EA RID: 1514
		internal static method CTreeV_setHidden;

		// Token: 0x040005EB RID: 1515
		internal static method CTreeV_show;

		// Token: 0x040005EC RID: 1516
		internal static method CTreeV_hide;

		// Token: 0x040005ED RID: 1517
		internal static method CTreeV_showMinimized;

		// Token: 0x040005EE RID: 1518
		internal static method CTreeV_showMaximized;

		// Token: 0x040005EF RID: 1519
		internal static method CTreeV_showFullScreen;

		// Token: 0x040005F0 RID: 1520
		internal static method CTreeV_showNormal;

		// Token: 0x040005F1 RID: 1521
		internal static method CTreeV_close;

		// Token: 0x040005F2 RID: 1522
		internal static method CTreeV_raise;

		// Token: 0x040005F3 RID: 1523
		internal static method CTreeV_lower;

		// Token: 0x040005F4 RID: 1524
		internal static method CTreeV_isVisible;

		// Token: 0x040005F5 RID: 1525
		internal static method CTreeV_setAttribute;

		// Token: 0x040005F6 RID: 1526
		internal static method CTreeV_testAttribute;

		// Token: 0x040005F7 RID: 1527
		internal static method CTreeV_acceptDrops;

		// Token: 0x040005F8 RID: 1528
		internal static method CTreeV_setAcceptDrops;

		// Token: 0x040005F9 RID: 1529
		internal static method CTreeV_update;

		// Token: 0x040005FA RID: 1530
		internal static method CTreeV_repaint;

		// Token: 0x040005FB RID: 1531
		internal static method CTreeV_setCursor;

		// Token: 0x040005FC RID: 1532
		internal static method CTreeV_unsetCursor;

		// Token: 0x040005FD RID: 1533
		internal static method CTreeV_setWindowIcon;

		// Token: 0x040005FE RID: 1534
		internal static method CTreeV_setWindowIconText;

		// Token: 0x040005FF RID: 1535
		internal static method CTreeV_setWindowOpacity;

		// Token: 0x04000600 RID: 1536
		internal static method CTreeV_windowOpacity;

		// Token: 0x04000601 RID: 1537
		internal static method CTreeV_isMinimized;

		// Token: 0x04000602 RID: 1538
		internal static method CTreeV_isMaximized;

		// Token: 0x04000603 RID: 1539
		internal static method CTreeV_isFullScreen;

		// Token: 0x04000604 RID: 1540
		internal static method CTreeV_setMouseTracking;

		// Token: 0x04000605 RID: 1541
		internal static method CTreeV_hasMouseTracking;

		// Token: 0x04000606 RID: 1542
		internal static method CTreeV_underMouse;

		// Token: 0x04000607 RID: 1543
		internal static method CTreeV_mapToGlobal;

		// Token: 0x04000608 RID: 1544
		internal static method CTreeV_mapFromGlobal;

		// Token: 0x04000609 RID: 1545
		internal static method CTreeV_hasFocus;

		// Token: 0x0400060A RID: 1546
		internal static method CTreeV_focusPolicy;

		// Token: 0x0400060B RID: 1547
		internal static method CTreeV_setFocusPolicy;

		// Token: 0x0400060C RID: 1548
		internal static method CTreeV_setFocusProxy;

		// Token: 0x0400060D RID: 1549
		internal static method CTreeV_isActiveWindow;

		// Token: 0x0400060E RID: 1550
		internal static method CTreeV_updatesEnabled;

		// Token: 0x0400060F RID: 1551
		internal static method CTreeV_setUpdatesEnabled;

		// Token: 0x04000610 RID: 1552
		internal static method CTreeV_setFocus;

		// Token: 0x04000611 RID: 1553
		internal static method CTreeV_activateWindow;

		// Token: 0x04000612 RID: 1554
		internal static method CTreeV_clearFocus;

		// Token: 0x04000613 RID: 1555
		internal static method CTreeV_setSizePolicy;

		// Token: 0x04000614 RID: 1556
		internal static method CTreeV_devicePixelRatioF;

		// Token: 0x04000615 RID: 1557
		internal static method CTreeV_saveGeometry;

		// Token: 0x04000616 RID: 1558
		internal static method CTreeV_restoreGeometry;

		// Token: 0x04000617 RID: 1559
		internal static method CTreeV_addAction;

		// Token: 0x04000618 RID: 1560
		internal static method CTreeV_removeAction;

		// Token: 0x04000619 RID: 1561
		internal static method CTreeV_setParent;

		// Token: 0x0400061A RID: 1562
		internal static method CTreeV_parentWidget;

		// Token: 0x0400061B RID: 1563
		internal static method CTreeV_AddClassName;

		// Token: 0x0400061C RID: 1564
		internal static method CTreeV_Polish;

		// Token: 0x0400061D RID: 1565
		internal static method CTreeV_toolTip;

		// Token: 0x0400061E RID: 1566
		internal static method CTreeV_setToolTip;

		// Token: 0x0400061F RID: 1567
		internal static method CTreeV_statusTip;

		// Token: 0x04000620 RID: 1568
		internal static method CTreeV_setStatusTip;

		// Token: 0x04000621 RID: 1569
		internal static method CTreeV_toolTipDuration;

		// Token: 0x04000622 RID: 1570
		internal static method CTreeV_setToolTipDuration;

		// Token: 0x04000623 RID: 1571
		internal static method CTreeV_autoFillBackground;

		// Token: 0x04000624 RID: 1572
		internal static method CTreeV_setAutoFillBackground;
	}
}
