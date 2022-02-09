using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000024 RID: 36
internal struct QFileDialog
{
	// Token: 0x060002C1 RID: 705 RVA: 0x00008711 File Offset: 0x00006911
	public static implicit operator IntPtr(QFileDialog value)
	{
		return value.self;
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x0000871C File Offset: 0x0000691C
	public static implicit operator QFileDialog(IntPtr value)
	{
		return new QFileDialog
		{
			self = value
		};
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x0000873A File Offset: 0x0000693A
	public static bool operator ==(QFileDialog c1, QFileDialog c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x0000874D File Offset: 0x0000694D
	public static bool operator !=(QFileDialog c1, QFileDialog c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x00008760 File Offset: 0x00006960
	public override bool Equals(object obj)
	{
		if (obj is QFileDialog)
		{
			QFileDialog c = (QFileDialog)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x060002C6 RID: 710 RVA: 0x0000878A File Offset: 0x0000698A
	internal QFileDialog(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x060002C7 RID: 711 RVA: 0x00008794 File Offset: 0x00006994
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
		defaultInterpolatedStringHandler.AppendLiteral("QFileDialog ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x060002C8 RID: 712 RVA: 0x000087D0 File Offset: 0x000069D0
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x060002C9 RID: 713 RVA: 0x000087E2 File Offset: 0x000069E2
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x060002CA RID: 714 RVA: 0x000087ED File Offset: 0x000069ED
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x060002CB RID: 715 RVA: 0x00008800 File Offset: 0x00006A00
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("QFileDialog was null when calling " + n);
		}
	}

	// Token: 0x060002CC RID: 716 RVA: 0x0000881B File Offset: 0x00006A1B
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x060002CD RID: 717 RVA: 0x00008828 File Offset: 0x00006A28
	public static implicit operator QWidget(QFileDialog value)
	{
		method to_QWidget_From_QFileDialog = QFileDialog.__N.To_QWidget_From_QFileDialog;
		return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QFileDialog);
	}

	// Token: 0x060002CE RID: 718 RVA: 0x0000884C File Offset: 0x00006A4C
	public static explicit operator QFileDialog(QWidget value)
	{
		method from_QWidget_To_QFileDialog = QFileDialog.__N.From_QWidget_To_QFileDialog;
		return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QFileDialog);
	}

	// Token: 0x060002CF RID: 719 RVA: 0x00008870 File Offset: 0x00006A70
	public static implicit operator Native.QObject(QFileDialog value)
	{
		method to_QObject_From_QFileDialog = QFileDialog.__N.To_QObject_From_QFileDialog;
		return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QFileDialog);
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x00008894 File Offset: 0x00006A94
	public static explicit operator QFileDialog(Native.QObject value)
	{
		method from_QObject_To_QFileDialog = QFileDialog.__N.From_QObject_To_QFileDialog;
		return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QFileDialog);
	}

	// Token: 0x060002D1 RID: 721 RVA: 0x000088B8 File Offset: 0x00006AB8
	internal static QFileDialog Create(QWidget parent)
	{
		method qfleDl_Create = QFileDialog.__N.QFleDl_Create;
		return calli(System.IntPtr(System.IntPtr), parent, qfleDl_Create);
	}

	// Token: 0x060002D2 RID: 722 RVA: 0x000088DC File Offset: 0x00006ADC
	internal readonly int exec()
	{
		this.NullCheck("exec");
		method qfleDl_exec = QFileDialog.__N.QFleDl_exec;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_exec);
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x00008908 File Offset: 0x00006B08
	internal readonly void setModal(bool modal)
	{
		this.NullCheck("setModal");
		method qfleDl_setModal = QFileDialog.__N.QFleDl_setModal;
		calli(System.Void(System.IntPtr,System.Int32), this.self, modal ? 1 : 0, qfleDl_setModal);
	}

	// Token: 0x060002D4 RID: 724 RVA: 0x0000893C File Offset: 0x00006B3C
	internal readonly void setResult(int r)
	{
		this.NullCheck("setResult");
		method qfleDl_setResult = QFileDialog.__N.QFleDl_setResult;
		calli(System.Void(System.IntPtr,System.Int32), this.self, r, qfleDl_setResult);
	}

	// Token: 0x060002D5 RID: 725 RVA: 0x00008968 File Offset: 0x00006B68
	internal readonly void setDirectory(string directory)
	{
		this.NullCheck("setDirectory");
		method qfleDl_setDirectory = QFileDialog.__N.QFleDl_setDirectory;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(directory), qfleDl_setDirectory);
	}

	// Token: 0x060002D6 RID: 726 RVA: 0x00008998 File Offset: 0x00006B98
	internal readonly string directory()
	{
		this.NullCheck("directory");
		method qfleDl_directory = QFileDialog.__N.QFleDl_directory;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qfleDl_directory));
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x000089C8 File Offset: 0x00006BC8
	internal readonly void selectFile(string filename)
	{
		this.NullCheck("selectFile");
		method qfleDl_selectFile = QFileDialog.__N.QFleDl_selectFile;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(filename), qfleDl_selectFile);
	}

	// Token: 0x060002D8 RID: 728 RVA: 0x000089F8 File Offset: 0x00006BF8
	internal readonly void setNameFilter(string filter)
	{
		this.NullCheck("setNameFilter");
		method qfleDl_setNameFilter = QFileDialog.__N.QFleDl_setNameFilter;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(filter), qfleDl_setNameFilter);
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x00008A28 File Offset: 0x00006C28
	internal readonly QStringList nameFilters()
	{
		this.NullCheck("nameFilters");
		method qfleDl_nameFilters = QFileDialog.__N.QFleDl_nameFilters;
		return new QStringList(calli(System.IntPtr(System.IntPtr), this.self, qfleDl_nameFilters));
	}

	// Token: 0x060002DA RID: 730 RVA: 0x00008A58 File Offset: 0x00006C58
	internal readonly void selectNameFilter(string filter)
	{
		this.NullCheck("selectNameFilter");
		method qfleDl_selectNameFilter = QFileDialog.__N.QFleDl_selectNameFilter;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(filter), qfleDl_selectNameFilter);
	}

	// Token: 0x060002DB RID: 731 RVA: 0x00008A88 File Offset: 0x00006C88
	internal readonly string selectedMimeTypeFilter()
	{
		this.NullCheck("selectedMimeTypeFilter");
		method qfleDl_selectedMimeTypeFilter = QFileDialog.__N.QFleDl_selectedMimeTypeFilter;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qfleDl_selectedMimeTypeFilter));
	}

	// Token: 0x060002DC RID: 732 RVA: 0x00008AB8 File Offset: 0x00006CB8
	internal readonly string selectedNameFilter()
	{
		this.NullCheck("selectedNameFilter");
		method qfleDl_selectedNameFilter = QFileDialog.__N.QFleDl_selectedNameFilter;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qfleDl_selectedNameFilter));
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00008AE8 File Offset: 0x00006CE8
	internal readonly void setAcceptMode(FileDialog.AcceptMode mode)
	{
		this.NullCheck("setAcceptMode");
		method qfleDl_setAcceptMode = QFileDialog.__N.QFleDl_setAcceptMode;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)mode, qfleDl_setAcceptMode);
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00008B14 File Offset: 0x00006D14
	internal readonly FileDialog.AcceptMode acceptMode()
	{
		this.NullCheck("acceptMode");
		method qfleDl_acceptMode = QFileDialog.__N.QFleDl_acceptMode;
		return calli(System.Int64(System.IntPtr), this.self, qfleDl_acceptMode);
	}

	// Token: 0x060002DF RID: 735 RVA: 0x00008B40 File Offset: 0x00006D40
	internal readonly void setDefaultSuffix(string suffix)
	{
		this.NullCheck("setDefaultSuffix");
		method qfleDl_setDefaultSuffix = QFileDialog.__N.QFleDl_setDefaultSuffix;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(suffix), qfleDl_setDefaultSuffix);
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x00008B70 File Offset: 0x00006D70
	internal readonly string defaultSuffix()
	{
		this.NullCheck("defaultSuffix");
		method qfleDl_defaultSuffix = QFileDialog.__N.QFleDl_defaultSuffix;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qfleDl_defaultSuffix));
	}

	// Token: 0x060002E1 RID: 737 RVA: 0x00008BA0 File Offset: 0x00006DA0
	internal readonly QStringList selectedFiles()
	{
		this.NullCheck("selectedFiles");
		method qfleDl_selectedFiles = QFileDialog.__N.QFleDl_selectedFiles;
		return new QStringList(calli(System.IntPtr(System.IntPtr), this.self, qfleDl_selectedFiles));
	}

	// Token: 0x060002E2 RID: 738 RVA: 0x00008BD0 File Offset: 0x00006DD0
	internal readonly void setFileMode(FileDialog.FileMode mode)
	{
		this.NullCheck("setFileMode");
		method qfleDl_setFileMode = QFileDialog.__N.QFleDl_setFileMode;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)mode, qfleDl_setFileMode);
	}

	// Token: 0x060002E3 RID: 739 RVA: 0x00008BFC File Offset: 0x00006DFC
	internal readonly FileDialog.FileMode fileMode()
	{
		this.NullCheck("fileMode");
		method qfleDl_fileMode = QFileDialog.__N.QFleDl_fileMode;
		return calli(System.Int64(System.IntPtr), this.self, qfleDl_fileMode);
	}

	// Token: 0x060002E4 RID: 740 RVA: 0x00008C28 File Offset: 0x00006E28
	internal readonly void setOption(FileDialog.Option option, bool on)
	{
		this.NullCheck("setOption");
		method qfleDl_setOption = QFileDialog.__N.QFleDl_setOption;
		calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)option, on ? 1 : 0, qfleDl_setOption);
	}

	// Token: 0x060002E5 RID: 741 RVA: 0x00008C5C File Offset: 0x00006E5C
	internal readonly bool isTopLevel()
	{
		this.NullCheck("isTopLevel");
		method qfleDl_isTopLevel = QFileDialog.__N.QFleDl_isTopLevel;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_isTopLevel) > 0;
	}

	// Token: 0x060002E6 RID: 742 RVA: 0x00008C8C File Offset: 0x00006E8C
	internal readonly bool isWindow()
	{
		this.NullCheck("isWindow");
		method qfleDl_isWindow = QFileDialog.__N.QFleDl_isWindow;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_isWindow) > 0;
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x00008CBC File Offset: 0x00006EBC
	internal readonly bool isModal()
	{
		this.NullCheck("isModal");
		method qfleDl_isModal = QFileDialog.__N.QFleDl_isModal;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_isModal) > 0;
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x00008CEC File Offset: 0x00006EEC
	internal readonly void setStyleSheet(string sheet)
	{
		this.NullCheck("setStyleSheet");
		method qfleDl_setStyleSheet = QFileDialog.__N.QFleDl_setStyleSheet;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qfleDl_setStyleSheet);
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x00008D1C File Offset: 0x00006F1C
	internal readonly string windowTitle()
	{
		this.NullCheck("windowTitle");
		method qfleDl_windowTitle = QFileDialog.__N.QFleDl_windowTitle;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qfleDl_windowTitle));
	}

	// Token: 0x060002EA RID: 746 RVA: 0x00008D4C File Offset: 0x00006F4C
	internal readonly void setWindowTitle(string title)
	{
		this.NullCheck("setWindowTitle");
		method qfleDl_setWindowTitle = QFileDialog.__N.QFleDl_setWindowTitle;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qfleDl_setWindowTitle);
	}

	// Token: 0x060002EB RID: 747 RVA: 0x00008D7C File Offset: 0x00006F7C
	internal readonly void setWindowFlags(WindowFlags type)
	{
		this.NullCheck("setWindowFlags");
		method qfleDl_setWindowFlags = QFileDialog.__N.QFleDl_setWindowFlags;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qfleDl_setWindowFlags);
	}

	// Token: 0x060002EC RID: 748 RVA: 0x00008DA8 File Offset: 0x00006FA8
	internal readonly WindowFlags windowFlags()
	{
		this.NullCheck("windowFlags");
		method qfleDl_windowFlags = QFileDialog.__N.QFleDl_windowFlags;
		return calli(System.Int64(System.IntPtr), this.self, qfleDl_windowFlags);
	}

	// Token: 0x060002ED RID: 749 RVA: 0x00008DD4 File Offset: 0x00006FD4
	internal readonly Vector3 size()
	{
		this.NullCheck("size");
		method qfleDl_size = QFileDialog.__N.QFleDl_size;
		return calli(Vector3(System.IntPtr), this.self, qfleDl_size);
	}

	// Token: 0x060002EE RID: 750 RVA: 0x00008E00 File Offset: 0x00007000
	internal readonly void resize(Vector3 x)
	{
		this.NullCheck("resize");
		method qfleDl_resize = QFileDialog.__N.QFleDl_resize;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, qfleDl_resize);
	}

	// Token: 0x060002EF RID: 751 RVA: 0x00008E2C File Offset: 0x0000702C
	internal readonly Vector3 minimumSize()
	{
		this.NullCheck("minimumSize");
		method qfleDl_minimumSize = QFileDialog.__N.QFleDl_minimumSize;
		return calli(Vector3(System.IntPtr), this.self, qfleDl_minimumSize);
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x00008E58 File Offset: 0x00007058
	internal readonly void setMinimumSize(Vector3 x)
	{
		this.NullCheck("setMinimumSize");
		method qfleDl_setMinimumSize = QFileDialog.__N.QFleDl_setMinimumSize;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, qfleDl_setMinimumSize);
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x00008E84 File Offset: 0x00007084
	internal readonly Vector3 maximumSize()
	{
		this.NullCheck("maximumSize");
		method qfleDl_maximumSize = QFileDialog.__N.QFleDl_maximumSize;
		return calli(Vector3(System.IntPtr), this.self, qfleDl_maximumSize);
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x00008EB0 File Offset: 0x000070B0
	internal readonly void setMaximumSize(Vector3 x)
	{
		this.NullCheck("setMaximumSize");
		method qfleDl_setMaximumSize = QFileDialog.__N.QFleDl_setMaximumSize;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, qfleDl_setMaximumSize);
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x00008EDC File Offset: 0x000070DC
	internal readonly Vector3 pos()
	{
		this.NullCheck("pos");
		method qfleDl_pos = QFileDialog.__N.QFleDl_pos;
		return calli(Vector3(System.IntPtr), this.self, qfleDl_pos);
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x00008F08 File Offset: 0x00007108
	internal readonly void move(Vector3 x)
	{
		this.NullCheck("move");
		method qfleDl_move = QFileDialog.__N.QFleDl_move;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, qfleDl_move);
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x00008F34 File Offset: 0x00007134
	internal readonly bool isEnabled()
	{
		this.NullCheck("isEnabled");
		method qfleDl_isEnabled = QFileDialog.__N.QFleDl_isEnabled;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_isEnabled) > 0;
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x00008F64 File Offset: 0x00007164
	internal readonly void setEnabled(bool x)
	{
		this.NullCheck("setEnabled");
		method qfleDl_setEnabled = QFileDialog.__N.QFleDl_setEnabled;
		calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qfleDl_setEnabled);
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x00008F98 File Offset: 0x00007198
	internal readonly void setVisible(bool visible)
	{
		this.NullCheck("setVisible");
		method qfleDl_setVisible = QFileDialog.__N.QFleDl_setVisible;
		calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qfleDl_setVisible);
	}

	// Token: 0x060002F8 RID: 760 RVA: 0x00008FCC File Offset: 0x000071CC
	internal readonly void setHidden(bool hidden)
	{
		this.NullCheck("setHidden");
		method qfleDl_setHidden = QFileDialog.__N.QFleDl_setHidden;
		calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qfleDl_setHidden);
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x00009000 File Offset: 0x00007200
	internal readonly void show()
	{
		this.NullCheck("show");
		method qfleDl_show = QFileDialog.__N.QFleDl_show;
		calli(System.Void(System.IntPtr), this.self, qfleDl_show);
	}

	// Token: 0x060002FA RID: 762 RVA: 0x0000902C File Offset: 0x0000722C
	internal readonly void hide()
	{
		this.NullCheck("hide");
		method qfleDl_hide = QFileDialog.__N.QFleDl_hide;
		calli(System.Void(System.IntPtr), this.self, qfleDl_hide);
	}

	// Token: 0x060002FB RID: 763 RVA: 0x00009058 File Offset: 0x00007258
	internal readonly void showMinimized()
	{
		this.NullCheck("showMinimized");
		method qfleDl_showMinimized = QFileDialog.__N.QFleDl_showMinimized;
		calli(System.Void(System.IntPtr), this.self, qfleDl_showMinimized);
	}

	// Token: 0x060002FC RID: 764 RVA: 0x00009084 File Offset: 0x00007284
	internal readonly void showMaximized()
	{
		this.NullCheck("showMaximized");
		method qfleDl_showMaximized = QFileDialog.__N.QFleDl_showMaximized;
		calli(System.Void(System.IntPtr), this.self, qfleDl_showMaximized);
	}

	// Token: 0x060002FD RID: 765 RVA: 0x000090B0 File Offset: 0x000072B0
	internal readonly void showFullScreen()
	{
		this.NullCheck("showFullScreen");
		method qfleDl_showFullScreen = QFileDialog.__N.QFleDl_showFullScreen;
		calli(System.Void(System.IntPtr), this.self, qfleDl_showFullScreen);
	}

	// Token: 0x060002FE RID: 766 RVA: 0x000090DC File Offset: 0x000072DC
	internal readonly void showNormal()
	{
		this.NullCheck("showNormal");
		method qfleDl_showNormal = QFileDialog.__N.QFleDl_showNormal;
		calli(System.Void(System.IntPtr), this.self, qfleDl_showNormal);
	}

	// Token: 0x060002FF RID: 767 RVA: 0x00009108 File Offset: 0x00007308
	internal readonly bool close()
	{
		this.NullCheck("close");
		method qfleDl_close = QFileDialog.__N.QFleDl_close;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_close) > 0;
	}

	// Token: 0x06000300 RID: 768 RVA: 0x00009138 File Offset: 0x00007338
	internal readonly void raise()
	{
		this.NullCheck("raise");
		method qfleDl_raise = QFileDialog.__N.QFleDl_raise;
		calli(System.Void(System.IntPtr), this.self, qfleDl_raise);
	}

	// Token: 0x06000301 RID: 769 RVA: 0x00009164 File Offset: 0x00007364
	internal readonly void lower()
	{
		this.NullCheck("lower");
		method qfleDl_lower = QFileDialog.__N.QFleDl_lower;
		calli(System.Void(System.IntPtr), this.self, qfleDl_lower);
	}

	// Token: 0x06000302 RID: 770 RVA: 0x00009190 File Offset: 0x00007390
	internal readonly bool isVisible()
	{
		this.NullCheck("isVisible");
		method qfleDl_isVisible = QFileDialog.__N.QFleDl_isVisible;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_isVisible) > 0;
	}

	// Token: 0x06000303 RID: 771 RVA: 0x000091C0 File Offset: 0x000073C0
	internal readonly void setAttribute(Widget.Flag a, bool on)
	{
		this.NullCheck("setAttribute");
		method qfleDl_setAttribute = QFileDialog.__N.QFleDl_setAttribute;
		calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qfleDl_setAttribute);
	}

	// Token: 0x06000304 RID: 772 RVA: 0x000091F4 File Offset: 0x000073F4
	internal readonly bool testAttribute(Widget.Flag a)
	{
		this.NullCheck("testAttribute");
		method qfleDl_testAttribute = QFileDialog.__N.QFleDl_testAttribute;
		return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qfleDl_testAttribute) > 0;
	}

	// Token: 0x06000305 RID: 773 RVA: 0x00009224 File Offset: 0x00007424
	internal readonly bool acceptDrops()
	{
		this.NullCheck("acceptDrops");
		method qfleDl_acceptDrops = QFileDialog.__N.QFleDl_acceptDrops;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_acceptDrops) > 0;
	}

	// Token: 0x06000306 RID: 774 RVA: 0x00009254 File Offset: 0x00007454
	internal readonly void setAcceptDrops(bool on)
	{
		this.NullCheck("setAcceptDrops");
		method qfleDl_setAcceptDrops = QFileDialog.__N.QFleDl_setAcceptDrops;
		calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qfleDl_setAcceptDrops);
	}

	// Token: 0x06000307 RID: 775 RVA: 0x00009288 File Offset: 0x00007488
	internal readonly void update()
	{
		this.NullCheck("update");
		method qfleDl_update = QFileDialog.__N.QFleDl_update;
		calli(System.Void(System.IntPtr), this.self, qfleDl_update);
	}

	// Token: 0x06000308 RID: 776 RVA: 0x000092B4 File Offset: 0x000074B4
	internal readonly void repaint()
	{
		this.NullCheck("repaint");
		method qfleDl_repaint = QFileDialog.__N.QFleDl_repaint;
		calli(System.Void(System.IntPtr), this.self, qfleDl_repaint);
	}

	// Token: 0x06000309 RID: 777 RVA: 0x000092E0 File Offset: 0x000074E0
	internal readonly void setCursor(CursorShape shape)
	{
		this.NullCheck("setCursor");
		method qfleDl_setCursor = QFileDialog.__N.QFleDl_setCursor;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qfleDl_setCursor);
	}

	// Token: 0x0600030A RID: 778 RVA: 0x0000930C File Offset: 0x0000750C
	internal readonly void unsetCursor()
	{
		this.NullCheck("unsetCursor");
		method qfleDl_unsetCursor = QFileDialog.__N.QFleDl_unsetCursor;
		calli(System.Void(System.IntPtr), this.self, qfleDl_unsetCursor);
	}

	// Token: 0x0600030B RID: 779 RVA: 0x00009338 File Offset: 0x00007538
	internal readonly void setWindowIcon(string icon)
	{
		this.NullCheck("setWindowIcon");
		method qfleDl_setWindowIcon = QFileDialog.__N.QFleDl_setWindowIcon;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qfleDl_setWindowIcon);
	}

	// Token: 0x0600030C RID: 780 RVA: 0x00009368 File Offset: 0x00007568
	internal readonly void setWindowIconText(string str)
	{
		this.NullCheck("setWindowIconText");
		method qfleDl_setWindowIconText = QFileDialog.__N.QFleDl_setWindowIconText;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qfleDl_setWindowIconText);
	}

	// Token: 0x0600030D RID: 781 RVA: 0x00009398 File Offset: 0x00007598
	internal readonly void setWindowOpacity(float level)
	{
		this.NullCheck("setWindowOpacity");
		method qfleDl_setWindowOpacity = QFileDialog.__N.QFleDl_setWindowOpacity;
		calli(System.Void(System.IntPtr,System.Single), this.self, level, qfleDl_setWindowOpacity);
	}

	// Token: 0x0600030E RID: 782 RVA: 0x000093C4 File Offset: 0x000075C4
	internal readonly float windowOpacity()
	{
		this.NullCheck("windowOpacity");
		method qfleDl_windowOpacity = QFileDialog.__N.QFleDl_windowOpacity;
		return calli(System.Single(System.IntPtr), this.self, qfleDl_windowOpacity);
	}

	// Token: 0x0600030F RID: 783 RVA: 0x000093F0 File Offset: 0x000075F0
	internal readonly bool isMinimized()
	{
		this.NullCheck("isMinimized");
		method qfleDl_isMinimized = QFileDialog.__N.QFleDl_isMinimized;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_isMinimized) > 0;
	}

	// Token: 0x06000310 RID: 784 RVA: 0x00009420 File Offset: 0x00007620
	internal readonly bool isMaximized()
	{
		this.NullCheck("isMaximized");
		method qfleDl_isMaximized = QFileDialog.__N.QFleDl_isMaximized;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_isMaximized) > 0;
	}

	// Token: 0x06000311 RID: 785 RVA: 0x00009450 File Offset: 0x00007650
	internal readonly bool isFullScreen()
	{
		this.NullCheck("isFullScreen");
		method qfleDl_isFullScreen = QFileDialog.__N.QFleDl_isFullScreen;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_isFullScreen) > 0;
	}

	// Token: 0x06000312 RID: 786 RVA: 0x00009480 File Offset: 0x00007680
	internal readonly void setMouseTracking(bool enable)
	{
		this.NullCheck("setMouseTracking");
		method qfleDl_setMouseTracking = QFileDialog.__N.QFleDl_setMouseTracking;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qfleDl_setMouseTracking);
	}

	// Token: 0x06000313 RID: 787 RVA: 0x000094B4 File Offset: 0x000076B4
	internal readonly bool hasMouseTracking()
	{
		this.NullCheck("hasMouseTracking");
		method qfleDl_hasMouseTracking = QFileDialog.__N.QFleDl_hasMouseTracking;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_hasMouseTracking) > 0;
	}

	// Token: 0x06000314 RID: 788 RVA: 0x000094E4 File Offset: 0x000076E4
	internal readonly bool underMouse()
	{
		this.NullCheck("underMouse");
		method qfleDl_underMouse = QFileDialog.__N.QFleDl_underMouse;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_underMouse) > 0;
	}

	// Token: 0x06000315 RID: 789 RVA: 0x00009514 File Offset: 0x00007714
	internal readonly Vector3 mapToGlobal(Vector3 p)
	{
		this.NullCheck("mapToGlobal");
		method qfleDl_mapToGlobal = QFileDialog.__N.QFleDl_mapToGlobal;
		return calli(Vector3(System.IntPtr,Vector3), this.self, p, qfleDl_mapToGlobal);
	}

	// Token: 0x06000316 RID: 790 RVA: 0x00009540 File Offset: 0x00007740
	internal readonly Vector3 mapFromGlobal(Vector3 p)
	{
		this.NullCheck("mapFromGlobal");
		method qfleDl_mapFromGlobal = QFileDialog.__N.QFleDl_mapFromGlobal;
		return calli(Vector3(System.IntPtr,Vector3), this.self, p, qfleDl_mapFromGlobal);
	}

	// Token: 0x06000317 RID: 791 RVA: 0x0000956C File Offset: 0x0000776C
	internal readonly bool hasFocus()
	{
		this.NullCheck("hasFocus");
		method qfleDl_hasFocus = QFileDialog.__N.QFleDl_hasFocus;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_hasFocus) > 0;
	}

	// Token: 0x06000318 RID: 792 RVA: 0x0000959C File Offset: 0x0000779C
	internal readonly FocusMode focusPolicy()
	{
		this.NullCheck("focusPolicy");
		method qfleDl_focusPolicy = QFileDialog.__N.QFleDl_focusPolicy;
		return calli(System.Int64(System.IntPtr), this.self, qfleDl_focusPolicy);
	}

	// Token: 0x06000319 RID: 793 RVA: 0x000095C8 File Offset: 0x000077C8
	internal readonly void setFocusPolicy(FocusMode policy)
	{
		this.NullCheck("setFocusPolicy");
		method qfleDl_setFocusPolicy = QFileDialog.__N.QFleDl_setFocusPolicy;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qfleDl_setFocusPolicy);
	}

	// Token: 0x0600031A RID: 794 RVA: 0x000095F4 File Offset: 0x000077F4
	internal readonly void setFocusProxy(QWidget widget)
	{
		this.NullCheck("setFocusProxy");
		method qfleDl_setFocusProxy = QFileDialog.__N.QFleDl_setFocusProxy;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qfleDl_setFocusProxy);
	}

	// Token: 0x0600031B RID: 795 RVA: 0x00009624 File Offset: 0x00007824
	internal readonly bool isActiveWindow()
	{
		this.NullCheck("isActiveWindow");
		method qfleDl_isActiveWindow = QFileDialog.__N.QFleDl_isActiveWindow;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_isActiveWindow) > 0;
	}

	// Token: 0x0600031C RID: 796 RVA: 0x00009654 File Offset: 0x00007854
	internal readonly bool updatesEnabled()
	{
		this.NullCheck("updatesEnabled");
		method qfleDl_updatesEnabled = QFileDialog.__N.QFleDl_updatesEnabled;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_updatesEnabled) > 0;
	}

	// Token: 0x0600031D RID: 797 RVA: 0x00009684 File Offset: 0x00007884
	internal readonly void setUpdatesEnabled(bool enable)
	{
		this.NullCheck("setUpdatesEnabled");
		method qfleDl_setUpdatesEnabled = QFileDialog.__N.QFleDl_setUpdatesEnabled;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qfleDl_setUpdatesEnabled);
	}

	// Token: 0x0600031E RID: 798 RVA: 0x000096B8 File Offset: 0x000078B8
	internal readonly void setFocus()
	{
		this.NullCheck("setFocus");
		method qfleDl_setFocus = QFileDialog.__N.QFleDl_setFocus;
		calli(System.Void(System.IntPtr), this.self, qfleDl_setFocus);
	}

	// Token: 0x0600031F RID: 799 RVA: 0x000096E4 File Offset: 0x000078E4
	internal readonly void activateWindow()
	{
		this.NullCheck("activateWindow");
		method qfleDl_activateWindow = QFileDialog.__N.QFleDl_activateWindow;
		calli(System.Void(System.IntPtr), this.self, qfleDl_activateWindow);
	}

	// Token: 0x06000320 RID: 800 RVA: 0x00009710 File Offset: 0x00007910
	internal readonly void clearFocus()
	{
		this.NullCheck("clearFocus");
		method qfleDl_clearFocus = QFileDialog.__N.QFleDl_clearFocus;
		calli(System.Void(System.IntPtr), this.self, qfleDl_clearFocus);
	}

	// Token: 0x06000321 RID: 801 RVA: 0x0000973C File Offset: 0x0000793C
	internal readonly void setSizePolicy(SizeMode x, SizeMode y)
	{
		this.NullCheck("setSizePolicy");
		method qfleDl_setSizePolicy = QFileDialog.__N.QFleDl_setSizePolicy;
		calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qfleDl_setSizePolicy);
	}

	// Token: 0x06000322 RID: 802 RVA: 0x0000976C File Offset: 0x0000796C
	internal readonly float devicePixelRatioF()
	{
		this.NullCheck("devicePixelRatioF");
		method qfleDl_devicePixelRatioF = QFileDialog.__N.QFleDl_devicePixelRatioF;
		return calli(System.Single(System.IntPtr), this.self, qfleDl_devicePixelRatioF);
	}

	// Token: 0x06000323 RID: 803 RVA: 0x00009798 File Offset: 0x00007998
	internal readonly string saveGeometry()
	{
		this.NullCheck("saveGeometry");
		method qfleDl_saveGeometry = QFileDialog.__N.QFleDl_saveGeometry;
		return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qfleDl_saveGeometry));
	}

	// Token: 0x06000324 RID: 804 RVA: 0x000097C8 File Offset: 0x000079C8
	internal readonly bool restoreGeometry(string state)
	{
		this.NullCheck("restoreGeometry");
		method qfleDl_restoreGeometry = QFileDialog.__N.QFleDl_restoreGeometry;
		return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qfleDl_restoreGeometry) > 0;
	}

	// Token: 0x06000325 RID: 805 RVA: 0x000097FC File Offset: 0x000079FC
	internal readonly void addAction(QAction action)
	{
		this.NullCheck("addAction");
		method qfleDl_addAction = QFileDialog.__N.QFleDl_addAction;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qfleDl_addAction);
	}

	// Token: 0x06000326 RID: 806 RVA: 0x0000982C File Offset: 0x00007A2C
	internal readonly void removeAction(QAction action)
	{
		this.NullCheck("removeAction");
		method qfleDl_removeAction = QFileDialog.__N.QFleDl_removeAction;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qfleDl_removeAction);
	}

	// Token: 0x06000327 RID: 807 RVA: 0x0000985C File Offset: 0x00007A5C
	internal readonly void setParent(QWidget parent)
	{
		this.NullCheck("setParent");
		method qfleDl_setParent = QFileDialog.__N.QFleDl_setParent;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qfleDl_setParent);
	}

	// Token: 0x06000328 RID: 808 RVA: 0x0000988C File Offset: 0x00007A8C
	internal readonly QWidget parentWidget()
	{
		this.NullCheck("parentWidget");
		method qfleDl_parentWidget = QFileDialog.__N.QFleDl_parentWidget;
		return calli(System.IntPtr(System.IntPtr), this.self, qfleDl_parentWidget);
	}

	// Token: 0x06000329 RID: 809 RVA: 0x000098BC File Offset: 0x00007ABC
	internal readonly void AddClassName(string name)
	{
		this.NullCheck("AddClassName");
		method qfleDl_AddClassName = QFileDialog.__N.QFleDl_AddClassName;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qfleDl_AddClassName);
	}

	// Token: 0x0600032A RID: 810 RVA: 0x000098EC File Offset: 0x00007AEC
	internal readonly void Polish()
	{
		this.NullCheck("Polish");
		method qfleDl_Polish = QFileDialog.__N.QFleDl_Polish;
		calli(System.Void(System.IntPtr), this.self, qfleDl_Polish);
	}

	// Token: 0x0600032B RID: 811 RVA: 0x00009918 File Offset: 0x00007B18
	internal readonly string toolTip()
	{
		this.NullCheck("toolTip");
		method qfleDl_toolTip = QFileDialog.__N.QFleDl_toolTip;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qfleDl_toolTip));
	}

	// Token: 0x0600032C RID: 812 RVA: 0x00009948 File Offset: 0x00007B48
	internal readonly void setToolTip(string str)
	{
		this.NullCheck("setToolTip");
		method qfleDl_setToolTip = QFileDialog.__N.QFleDl_setToolTip;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qfleDl_setToolTip);
	}

	// Token: 0x0600032D RID: 813 RVA: 0x00009978 File Offset: 0x00007B78
	internal readonly string statusTip()
	{
		this.NullCheck("statusTip");
		method qfleDl_statusTip = QFileDialog.__N.QFleDl_statusTip;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qfleDl_statusTip));
	}

	// Token: 0x0600032E RID: 814 RVA: 0x000099A8 File Offset: 0x00007BA8
	internal readonly void setStatusTip(string str)
	{
		this.NullCheck("setStatusTip");
		method qfleDl_setStatusTip = QFileDialog.__N.QFleDl_setStatusTip;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qfleDl_setStatusTip);
	}

	// Token: 0x0600032F RID: 815 RVA: 0x000099D8 File Offset: 0x00007BD8
	internal readonly int toolTipDuration()
	{
		this.NullCheck("toolTipDuration");
		method qfleDl_toolTipDuration = QFileDialog.__N.QFleDl_toolTipDuration;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_toolTipDuration);
	}

	// Token: 0x06000330 RID: 816 RVA: 0x00009A04 File Offset: 0x00007C04
	internal readonly void setToolTipDuration(int x)
	{
		this.NullCheck("setToolTipDuration");
		method qfleDl_setToolTipDuration = QFileDialog.__N.QFleDl_setToolTipDuration;
		calli(System.Void(System.IntPtr,System.Int32), this.self, x, qfleDl_setToolTipDuration);
	}

	// Token: 0x06000331 RID: 817 RVA: 0x00009A30 File Offset: 0x00007C30
	internal readonly bool autoFillBackground()
	{
		this.NullCheck("autoFillBackground");
		method qfleDl_autoFillBackground = QFileDialog.__N.QFleDl_autoFillBackground;
		return calli(System.Int32(System.IntPtr), this.self, qfleDl_autoFillBackground) > 0;
	}

	// Token: 0x06000332 RID: 818 RVA: 0x00009A60 File Offset: 0x00007C60
	internal readonly void setAutoFillBackground(bool enabled)
	{
		this.NullCheck("setAutoFillBackground");
		method qfleDl_setAutoFillBackground = QFileDialog.__N.QFleDl_setAutoFillBackground;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qfleDl_setAutoFillBackground);
	}

	// Token: 0x0400001F RID: 31
	internal IntPtr self;

	// Token: 0x020000F4 RID: 244
	internal static class __N
	{
		// Token: 0x0400067F RID: 1663
		internal static method From_QWidget_To_QFileDialog;

		// Token: 0x04000680 RID: 1664
		internal static method To_QWidget_From_QFileDialog;

		// Token: 0x04000681 RID: 1665
		internal static method From_QObject_To_QFileDialog;

		// Token: 0x04000682 RID: 1666
		internal static method To_QObject_From_QFileDialog;

		// Token: 0x04000683 RID: 1667
		internal static method QFleDl_Create;

		// Token: 0x04000684 RID: 1668
		internal static method QFleDl_exec;

		// Token: 0x04000685 RID: 1669
		internal static method QFleDl_setModal;

		// Token: 0x04000686 RID: 1670
		internal static method QFleDl_setResult;

		// Token: 0x04000687 RID: 1671
		internal static method QFleDl_setDirectory;

		// Token: 0x04000688 RID: 1672
		internal static method QFleDl_directory;

		// Token: 0x04000689 RID: 1673
		internal static method QFleDl_selectFile;

		// Token: 0x0400068A RID: 1674
		internal static method QFleDl_setNameFilter;

		// Token: 0x0400068B RID: 1675
		internal static method QFleDl_nameFilters;

		// Token: 0x0400068C RID: 1676
		internal static method QFleDl_selectNameFilter;

		// Token: 0x0400068D RID: 1677
		internal static method QFleDl_selectedMimeTypeFilter;

		// Token: 0x0400068E RID: 1678
		internal static method QFleDl_selectedNameFilter;

		// Token: 0x0400068F RID: 1679
		internal static method QFleDl_setAcceptMode;

		// Token: 0x04000690 RID: 1680
		internal static method QFleDl_acceptMode;

		// Token: 0x04000691 RID: 1681
		internal static method QFleDl_setDefaultSuffix;

		// Token: 0x04000692 RID: 1682
		internal static method QFleDl_defaultSuffix;

		// Token: 0x04000693 RID: 1683
		internal static method QFleDl_selectedFiles;

		// Token: 0x04000694 RID: 1684
		internal static method QFleDl_setFileMode;

		// Token: 0x04000695 RID: 1685
		internal static method QFleDl_fileMode;

		// Token: 0x04000696 RID: 1686
		internal static method QFleDl_setOption;

		// Token: 0x04000697 RID: 1687
		internal static method QFleDl_isTopLevel;

		// Token: 0x04000698 RID: 1688
		internal static method QFleDl_isWindow;

		// Token: 0x04000699 RID: 1689
		internal static method QFleDl_isModal;

		// Token: 0x0400069A RID: 1690
		internal static method QFleDl_setStyleSheet;

		// Token: 0x0400069B RID: 1691
		internal static method QFleDl_windowTitle;

		// Token: 0x0400069C RID: 1692
		internal static method QFleDl_setWindowTitle;

		// Token: 0x0400069D RID: 1693
		internal static method QFleDl_setWindowFlags;

		// Token: 0x0400069E RID: 1694
		internal static method QFleDl_windowFlags;

		// Token: 0x0400069F RID: 1695
		internal static method QFleDl_size;

		// Token: 0x040006A0 RID: 1696
		internal static method QFleDl_resize;

		// Token: 0x040006A1 RID: 1697
		internal static method QFleDl_minimumSize;

		// Token: 0x040006A2 RID: 1698
		internal static method QFleDl_setMinimumSize;

		// Token: 0x040006A3 RID: 1699
		internal static method QFleDl_maximumSize;

		// Token: 0x040006A4 RID: 1700
		internal static method QFleDl_setMaximumSize;

		// Token: 0x040006A5 RID: 1701
		internal static method QFleDl_pos;

		// Token: 0x040006A6 RID: 1702
		internal static method QFleDl_move;

		// Token: 0x040006A7 RID: 1703
		internal static method QFleDl_isEnabled;

		// Token: 0x040006A8 RID: 1704
		internal static method QFleDl_setEnabled;

		// Token: 0x040006A9 RID: 1705
		internal static method QFleDl_setVisible;

		// Token: 0x040006AA RID: 1706
		internal static method QFleDl_setHidden;

		// Token: 0x040006AB RID: 1707
		internal static method QFleDl_show;

		// Token: 0x040006AC RID: 1708
		internal static method QFleDl_hide;

		// Token: 0x040006AD RID: 1709
		internal static method QFleDl_showMinimized;

		// Token: 0x040006AE RID: 1710
		internal static method QFleDl_showMaximized;

		// Token: 0x040006AF RID: 1711
		internal static method QFleDl_showFullScreen;

		// Token: 0x040006B0 RID: 1712
		internal static method QFleDl_showNormal;

		// Token: 0x040006B1 RID: 1713
		internal static method QFleDl_close;

		// Token: 0x040006B2 RID: 1714
		internal static method QFleDl_raise;

		// Token: 0x040006B3 RID: 1715
		internal static method QFleDl_lower;

		// Token: 0x040006B4 RID: 1716
		internal static method QFleDl_isVisible;

		// Token: 0x040006B5 RID: 1717
		internal static method QFleDl_setAttribute;

		// Token: 0x040006B6 RID: 1718
		internal static method QFleDl_testAttribute;

		// Token: 0x040006B7 RID: 1719
		internal static method QFleDl_acceptDrops;

		// Token: 0x040006B8 RID: 1720
		internal static method QFleDl_setAcceptDrops;

		// Token: 0x040006B9 RID: 1721
		internal static method QFleDl_update;

		// Token: 0x040006BA RID: 1722
		internal static method QFleDl_repaint;

		// Token: 0x040006BB RID: 1723
		internal static method QFleDl_setCursor;

		// Token: 0x040006BC RID: 1724
		internal static method QFleDl_unsetCursor;

		// Token: 0x040006BD RID: 1725
		internal static method QFleDl_setWindowIcon;

		// Token: 0x040006BE RID: 1726
		internal static method QFleDl_setWindowIconText;

		// Token: 0x040006BF RID: 1727
		internal static method QFleDl_setWindowOpacity;

		// Token: 0x040006C0 RID: 1728
		internal static method QFleDl_windowOpacity;

		// Token: 0x040006C1 RID: 1729
		internal static method QFleDl_isMinimized;

		// Token: 0x040006C2 RID: 1730
		internal static method QFleDl_isMaximized;

		// Token: 0x040006C3 RID: 1731
		internal static method QFleDl_isFullScreen;

		// Token: 0x040006C4 RID: 1732
		internal static method QFleDl_setMouseTracking;

		// Token: 0x040006C5 RID: 1733
		internal static method QFleDl_hasMouseTracking;

		// Token: 0x040006C6 RID: 1734
		internal static method QFleDl_underMouse;

		// Token: 0x040006C7 RID: 1735
		internal static method QFleDl_mapToGlobal;

		// Token: 0x040006C8 RID: 1736
		internal static method QFleDl_mapFromGlobal;

		// Token: 0x040006C9 RID: 1737
		internal static method QFleDl_hasFocus;

		// Token: 0x040006CA RID: 1738
		internal static method QFleDl_focusPolicy;

		// Token: 0x040006CB RID: 1739
		internal static method QFleDl_setFocusPolicy;

		// Token: 0x040006CC RID: 1740
		internal static method QFleDl_setFocusProxy;

		// Token: 0x040006CD RID: 1741
		internal static method QFleDl_isActiveWindow;

		// Token: 0x040006CE RID: 1742
		internal static method QFleDl_updatesEnabled;

		// Token: 0x040006CF RID: 1743
		internal static method QFleDl_setUpdatesEnabled;

		// Token: 0x040006D0 RID: 1744
		internal static method QFleDl_setFocus;

		// Token: 0x040006D1 RID: 1745
		internal static method QFleDl_activateWindow;

		// Token: 0x040006D2 RID: 1746
		internal static method QFleDl_clearFocus;

		// Token: 0x040006D3 RID: 1747
		internal static method QFleDl_setSizePolicy;

		// Token: 0x040006D4 RID: 1748
		internal static method QFleDl_devicePixelRatioF;

		// Token: 0x040006D5 RID: 1749
		internal static method QFleDl_saveGeometry;

		// Token: 0x040006D6 RID: 1750
		internal static method QFleDl_restoreGeometry;

		// Token: 0x040006D7 RID: 1751
		internal static method QFleDl_addAction;

		// Token: 0x040006D8 RID: 1752
		internal static method QFleDl_removeAction;

		// Token: 0x040006D9 RID: 1753
		internal static method QFleDl_setParent;

		// Token: 0x040006DA RID: 1754
		internal static method QFleDl_parentWidget;

		// Token: 0x040006DB RID: 1755
		internal static method QFleDl_AddClassName;

		// Token: 0x040006DC RID: 1756
		internal static method QFleDl_Polish;

		// Token: 0x040006DD RID: 1757
		internal static method QFleDl_toolTip;

		// Token: 0x040006DE RID: 1758
		internal static method QFleDl_setToolTip;

		// Token: 0x040006DF RID: 1759
		internal static method QFleDl_statusTip;

		// Token: 0x040006E0 RID: 1760
		internal static method QFleDl_setStatusTip;

		// Token: 0x040006E1 RID: 1761
		internal static method QFleDl_toolTipDuration;

		// Token: 0x040006E2 RID: 1762
		internal static method QFleDl_setToolTipDuration;

		// Token: 0x040006E3 RID: 1763
		internal static method QFleDl_autoFillBackground;

		// Token: 0x040006E4 RID: 1764
		internal static method QFleDl_setAutoFillBackground;
	}
}
