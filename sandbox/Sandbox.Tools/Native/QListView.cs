using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x0200004F RID: 79
	internal struct QListView
	{
		// Token: 0x06000AFB RID: 2811 RVA: 0x0001DB81 File Offset: 0x0001BD81
		public static implicit operator IntPtr(QListView value)
		{
			return value.self;
		}

		// Token: 0x06000AFC RID: 2812 RVA: 0x0001DB8C File Offset: 0x0001BD8C
		public static implicit operator QListView(IntPtr value)
		{
			return new QListView
			{
				self = value
			};
		}

		// Token: 0x06000AFD RID: 2813 RVA: 0x0001DBAA File Offset: 0x0001BDAA
		public static bool operator ==(QListView c1, QListView c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000AFE RID: 2814 RVA: 0x0001DBBD File Offset: 0x0001BDBD
		public static bool operator !=(QListView c1, QListView c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000AFF RID: 2815 RVA: 0x0001DBD0 File Offset: 0x0001BDD0
		public override bool Equals(object obj)
		{
			if (obj is QListView)
			{
				QListView c = (QListView)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000B00 RID: 2816 RVA: 0x0001DBFA File Offset: 0x0001BDFA
		internal QListView(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000B01 RID: 2817 RVA: 0x0001DC04 File Offset: 0x0001BE04
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QListView ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000B02 RID: 2818 RVA: 0x0001DC40 File Offset: 0x0001BE40
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000B03 RID: 2819 RVA: 0x0001DC52 File Offset: 0x0001BE52
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000B04 RID: 2820 RVA: 0x0001DC5D File Offset: 0x0001BE5D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0001DC70 File Offset: 0x0001BE70
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QListView was null when calling " + n);
			}
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0001DC8B File Offset: 0x0001BE8B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x0001DC98 File Offset: 0x0001BE98
		public static implicit operator QWidget(QListView value)
		{
			method to_QWidget_From_QListView = QListView.__N.To_QWidget_From_QListView;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QListView);
		}

		// Token: 0x06000B08 RID: 2824 RVA: 0x0001DCBC File Offset: 0x0001BEBC
		public static explicit operator QListView(QWidget value)
		{
			method from_QWidget_To_QListView = QListView.__N.From_QWidget_To_QListView;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QListView);
		}

		// Token: 0x06000B09 RID: 2825 RVA: 0x0001DCE0 File Offset: 0x0001BEE0
		public static implicit operator QObject(QListView value)
		{
			method to_QObject_From_QListView = QListView.__N.To_QObject_From_QListView;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QListView);
		}

		// Token: 0x06000B0A RID: 2826 RVA: 0x0001DD04 File Offset: 0x0001BF04
		public static explicit operator QListView(QObject value)
		{
			method from_QObject_To_QListView = QListView.__N.From_QObject_To_QListView;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QListView);
		}

		// Token: 0x06000B0B RID: 2827 RVA: 0x0001DD28 File Offset: 0x0001BF28
		internal readonly void setItemDelegate(CDataDelegate del)
		{
			this.NullCheck("setItemDelegate");
			method qlstVe_setItemDelegate = QListView.__N.QLstVe_setItemDelegate;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, del, qlstVe_setItemDelegate);
		}

		// Token: 0x06000B0C RID: 2828 RVA: 0x0001DD58 File Offset: 0x0001BF58
		internal readonly bool uniformItemSizes()
		{
			this.NullCheck("uniformItemSizes");
			method qlstVe_uniformItemSizes = QListView.__N.QLstVe_uniformItemSizes;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_uniformItemSizes) > 0;
		}

		// Token: 0x06000B0D RID: 2829 RVA: 0x0001DD88 File Offset: 0x0001BF88
		internal readonly void setUniformItemSizes(bool uniform)
		{
			this.NullCheck("setUniformItemSizes");
			method qlstVe_setUniformItemSizes = QListView.__N.QLstVe_setUniformItemSizes;
			calli(System.Void(System.IntPtr,System.Int32), this.self, uniform ? 1 : 0, qlstVe_setUniformItemSizes);
		}

		// Token: 0x06000B0E RID: 2830 RVA: 0x0001DDBC File Offset: 0x0001BFBC
		internal readonly void setModelColumn(int column)
		{
			this.NullCheck("setModelColumn");
			method qlstVe_setModelColumn = QListView.__N.QLstVe_setModelColumn;
			calli(System.Void(System.IntPtr,System.Int32), this.self, column, qlstVe_setModelColumn);
		}

		// Token: 0x06000B0F RID: 2831 RVA: 0x0001DDE8 File Offset: 0x0001BFE8
		internal readonly int modelColumn()
		{
			this.NullCheck("modelColumn");
			method qlstVe_modelColumn = QListView.__N.QLstVe_modelColumn;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_modelColumn);
		}

		// Token: 0x06000B10 RID: 2832 RVA: 0x0001DE14 File Offset: 0x0001C014
		internal readonly void setWordWrap(bool on)
		{
			this.NullCheck("setWordWrap");
			method qlstVe_setWordWrap = QListView.__N.QLstVe_setWordWrap;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qlstVe_setWordWrap);
		}

		// Token: 0x06000B11 RID: 2833 RVA: 0x0001DE48 File Offset: 0x0001C048
		internal readonly bool wordWrap()
		{
			this.NullCheck("wordWrap");
			method qlstVe_wordWrap = QListView.__N.QLstVe_wordWrap;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_wordWrap) > 0;
		}

		// Token: 0x06000B12 RID: 2834 RVA: 0x0001DE78 File Offset: 0x0001C078
		internal readonly void setWrapping(bool on)
		{
			this.NullCheck("setWrapping");
			method qlstVe_setWrapping = QListView.__N.QLstVe_setWrapping;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qlstVe_setWrapping);
		}

		// Token: 0x06000B13 RID: 2835 RVA: 0x0001DEAC File Offset: 0x0001C0AC
		internal readonly bool isWrapping()
		{
			this.NullCheck("isWrapping");
			method qlstVe_isWrapping = QListView.__N.QLstVe_isWrapping;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_isWrapping) > 0;
		}

		// Token: 0x06000B14 RID: 2836 RVA: 0x0001DEDC File Offset: 0x0001C0DC
		internal readonly void setViewMode(ViewMode mode)
		{
			this.NullCheck("setViewMode");
			method qlstVe_setViewMode = QListView.__N.QLstVe_setViewMode;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)mode, qlstVe_setViewMode);
		}

		// Token: 0x06000B15 RID: 2837 RVA: 0x0001DF08 File Offset: 0x0001C108
		internal readonly ViewMode viewMode()
		{
			this.NullCheck("viewMode");
			method qlstVe_viewMode = QListView.__N.QLstVe_viewMode;
			return calli(System.Int64(System.IntPtr), this.self, qlstVe_viewMode);
		}

		// Token: 0x06000B16 RID: 2838 RVA: 0x0001DF34 File Offset: 0x0001C134
		internal readonly void setLayoutMode(LayoutMode mode)
		{
			this.NullCheck("setLayoutMode");
			method qlstVe_setLayoutMode = QListView.__N.QLstVe_setLayoutMode;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)mode, qlstVe_setLayoutMode);
		}

		// Token: 0x06000B17 RID: 2839 RVA: 0x0001DF60 File Offset: 0x0001C160
		internal readonly LayoutMode layoutMode()
		{
			this.NullCheck("layoutMode");
			method qlstVe_layoutMode = QListView.__N.QLstVe_layoutMode;
			return calli(System.Int64(System.IntPtr), this.self, qlstVe_layoutMode);
		}

		// Token: 0x06000B18 RID: 2840 RVA: 0x0001DF8C File Offset: 0x0001C18C
		internal readonly void setFlow(Flow flow)
		{
			this.NullCheck("setFlow");
			method qlstVe_setFlow = QListView.__N.QLstVe_setFlow;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)flow, qlstVe_setFlow);
		}

		// Token: 0x06000B19 RID: 2841 RVA: 0x0001DFB8 File Offset: 0x0001C1B8
		internal readonly Flow flow()
		{
			this.NullCheck("flow");
			method qlstVe_flow = QListView.__N.QLstVe_flow;
			return calli(System.Int64(System.IntPtr), this.self, qlstVe_flow);
		}

		// Token: 0x06000B1A RID: 2842 RVA: 0x0001DFE4 File Offset: 0x0001C1E4
		internal readonly void setMovement(Movement movement)
		{
			this.NullCheck("setMovement");
			method qlstVe_setMovement = QListView.__N.QLstVe_setMovement;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)movement, qlstVe_setMovement);
		}

		// Token: 0x06000B1B RID: 2843 RVA: 0x0001E010 File Offset: 0x0001C210
		internal readonly Movement movement()
		{
			this.NullCheck("movement");
			method qlstVe_movement = QListView.__N.QLstVe_movement;
			return calli(System.Int64(System.IntPtr), this.self, qlstVe_movement);
		}

		// Token: 0x06000B1C RID: 2844 RVA: 0x0001E03C File Offset: 0x0001C23C
		internal readonly void setResizeMode(ResizeMode movement)
		{
			this.NullCheck("setResizeMode");
			method qlstVe_setResizeMode = QListView.__N.QLstVe_setResizeMode;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)movement, qlstVe_setResizeMode);
		}

		// Token: 0x06000B1D RID: 2845 RVA: 0x0001E068 File Offset: 0x0001C268
		internal readonly ResizeMode resizeMode()
		{
			this.NullCheck("resizeMode");
			method qlstVe_resizeMode = QListView.__N.QLstVe_resizeMode;
			return calli(System.Int64(System.IntPtr), this.self, qlstVe_resizeMode);
		}

		// Token: 0x06000B1E RID: 2846 RVA: 0x0001E094 File Offset: 0x0001C294
		internal readonly void setBatchSize(int batchSize)
		{
			this.NullCheck("setBatchSize");
			method qlstVe_setBatchSize = QListView.__N.QLstVe_setBatchSize;
			calli(System.Void(System.IntPtr,System.Int32), this.self, batchSize, qlstVe_setBatchSize);
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0001E0C0 File Offset: 0x0001C2C0
		internal readonly int batchSize()
		{
			this.NullCheck("batchSize");
			method qlstVe_batchSize = QListView.__N.QLstVe_batchSize;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_batchSize);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0001E0EC File Offset: 0x0001C2EC
		internal readonly void setGridSize(Vector3 size)
		{
			this.NullCheck("setGridSize");
			method qlstVe_setGridSize = QListView.__N.QLstVe_setGridSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, size, qlstVe_setGridSize);
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x0001E118 File Offset: 0x0001C318
		internal readonly Vector3 gridSize()
		{
			this.NullCheck("gridSize");
			method qlstVe_gridSize = QListView.__N.QLstVe_gridSize;
			return calli(Vector3(System.IntPtr), this.self, qlstVe_gridSize);
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x0001E144 File Offset: 0x0001C344
		internal unsafe readonly QRectF visualRect(ModelIndex index)
		{
			this.NullCheck("visualRect");
			method qlstVe_visualRect = QListView.__N.QLstVe_visualRect;
			return calli(QRectF(System.IntPtr,Tools.ModelIndex*), this.self, &index, qlstVe_visualRect);
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x0001E174 File Offset: 0x0001C374
		internal unsafe readonly void scrollTo(ModelIndex index)
		{
			this.NullCheck("scrollTo");
			method qlstVe_scrollTo = QListView.__N.QLstVe_scrollTo;
			calli(System.Void(System.IntPtr,Tools.ModelIndex*), this.self, &index, qlstVe_scrollTo);
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x0001E1A4 File Offset: 0x0001C3A4
		internal readonly ModelIndex indexAt(Vector3 p)
		{
			this.NullCheck("indexAt");
			method qlstVe_indexAt = QListView.__N.QLstVe_indexAt;
			return calli(Tools.ModelIndex(System.IntPtr,Vector3), this.self, p, qlstVe_indexAt);
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0001E1D0 File Offset: 0x0001C3D0
		internal unsafe readonly void setRootIndex(ModelIndex index)
		{
			this.NullCheck("setRootIndex");
			method qlstVe_setRootIndex = QListView.__N.QLstVe_setRootIndex;
			calli(System.Void(System.IntPtr,Tools.ModelIndex*), this.self, &index, qlstVe_setRootIndex);
		}

		// Token: 0x06000B26 RID: 2854 RVA: 0x0001E200 File Offset: 0x0001C400
		internal readonly ModelIndex rootIndex()
		{
			this.NullCheck("rootIndex");
			method qlstVe_rootIndex = QListView.__N.QLstVe_rootIndex;
			return calli(Tools.ModelIndex(System.IntPtr), this.self, qlstVe_rootIndex);
		}

		// Token: 0x06000B27 RID: 2855 RVA: 0x0001E22C File Offset: 0x0001C42C
		internal readonly QItemSelectionModel selectionModel()
		{
			this.NullCheck("selectionModel");
			method qlstVe_selectionModel = QListView.__N.QLstVe_selectionModel;
			return calli(System.IntPtr(System.IntPtr), this.self, qlstVe_selectionModel);
		}

		// Token: 0x06000B28 RID: 2856 RVA: 0x0001E25C File Offset: 0x0001C45C
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qlstVe_isTopLevel = QListView.__N.QLstVe_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_isTopLevel) > 0;
		}

		// Token: 0x06000B29 RID: 2857 RVA: 0x0001E28C File Offset: 0x0001C48C
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qlstVe_isWindow = QListView.__N.QLstVe_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_isWindow) > 0;
		}

		// Token: 0x06000B2A RID: 2858 RVA: 0x0001E2BC File Offset: 0x0001C4BC
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qlstVe_isModal = QListView.__N.QLstVe_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_isModal) > 0;
		}

		// Token: 0x06000B2B RID: 2859 RVA: 0x0001E2EC File Offset: 0x0001C4EC
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qlstVe_setStyleSheet = QListView.__N.QLstVe_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qlstVe_setStyleSheet);
		}

		// Token: 0x06000B2C RID: 2860 RVA: 0x0001E31C File Offset: 0x0001C51C
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qlstVe_windowTitle = QListView.__N.QLstVe_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlstVe_windowTitle));
		}

		// Token: 0x06000B2D RID: 2861 RVA: 0x0001E34C File Offset: 0x0001C54C
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qlstVe_setWindowTitle = QListView.__N.QLstVe_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qlstVe_setWindowTitle);
		}

		// Token: 0x06000B2E RID: 2862 RVA: 0x0001E37C File Offset: 0x0001C57C
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qlstVe_setWindowFlags = QListView.__N.QLstVe_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qlstVe_setWindowFlags);
		}

		// Token: 0x06000B2F RID: 2863 RVA: 0x0001E3A8 File Offset: 0x0001C5A8
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qlstVe_windowFlags = QListView.__N.QLstVe_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qlstVe_windowFlags);
		}

		// Token: 0x06000B30 RID: 2864 RVA: 0x0001E3D4 File Offset: 0x0001C5D4
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qlstVe_size = QListView.__N.QLstVe_size;
			return calli(Vector3(System.IntPtr), this.self, qlstVe_size);
		}

		// Token: 0x06000B31 RID: 2865 RVA: 0x0001E400 File Offset: 0x0001C600
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qlstVe_resize = QListView.__N.QLstVe_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlstVe_resize);
		}

		// Token: 0x06000B32 RID: 2866 RVA: 0x0001E42C File Offset: 0x0001C62C
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qlstVe_minimumSize = QListView.__N.QLstVe_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qlstVe_minimumSize);
		}

		// Token: 0x06000B33 RID: 2867 RVA: 0x0001E458 File Offset: 0x0001C658
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qlstVe_setMinimumSize = QListView.__N.QLstVe_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlstVe_setMinimumSize);
		}

		// Token: 0x06000B34 RID: 2868 RVA: 0x0001E484 File Offset: 0x0001C684
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qlstVe_maximumSize = QListView.__N.QLstVe_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qlstVe_maximumSize);
		}

		// Token: 0x06000B35 RID: 2869 RVA: 0x0001E4B0 File Offset: 0x0001C6B0
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qlstVe_setMaximumSize = QListView.__N.QLstVe_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlstVe_setMaximumSize);
		}

		// Token: 0x06000B36 RID: 2870 RVA: 0x0001E4DC File Offset: 0x0001C6DC
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qlstVe_pos = QListView.__N.QLstVe_pos;
			return calli(Vector3(System.IntPtr), this.self, qlstVe_pos);
		}

		// Token: 0x06000B37 RID: 2871 RVA: 0x0001E508 File Offset: 0x0001C708
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qlstVe_move = QListView.__N.QLstVe_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qlstVe_move);
		}

		// Token: 0x06000B38 RID: 2872 RVA: 0x0001E534 File Offset: 0x0001C734
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qlstVe_isEnabled = QListView.__N.QLstVe_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_isEnabled) > 0;
		}

		// Token: 0x06000B39 RID: 2873 RVA: 0x0001E564 File Offset: 0x0001C764
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qlstVe_setEnabled = QListView.__N.QLstVe_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qlstVe_setEnabled);
		}

		// Token: 0x06000B3A RID: 2874 RVA: 0x0001E598 File Offset: 0x0001C798
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qlstVe_setVisible = QListView.__N.QLstVe_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qlstVe_setVisible);
		}

		// Token: 0x06000B3B RID: 2875 RVA: 0x0001E5CC File Offset: 0x0001C7CC
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qlstVe_setHidden = QListView.__N.QLstVe_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qlstVe_setHidden);
		}

		// Token: 0x06000B3C RID: 2876 RVA: 0x0001E600 File Offset: 0x0001C800
		internal readonly void show()
		{
			this.NullCheck("show");
			method qlstVe_show = QListView.__N.QLstVe_show;
			calli(System.Void(System.IntPtr), this.self, qlstVe_show);
		}

		// Token: 0x06000B3D RID: 2877 RVA: 0x0001E62C File Offset: 0x0001C82C
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qlstVe_hide = QListView.__N.QLstVe_hide;
			calli(System.Void(System.IntPtr), this.self, qlstVe_hide);
		}

		// Token: 0x06000B3E RID: 2878 RVA: 0x0001E658 File Offset: 0x0001C858
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qlstVe_showMinimized = QListView.__N.QLstVe_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qlstVe_showMinimized);
		}

		// Token: 0x06000B3F RID: 2879 RVA: 0x0001E684 File Offset: 0x0001C884
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qlstVe_showMaximized = QListView.__N.QLstVe_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qlstVe_showMaximized);
		}

		// Token: 0x06000B40 RID: 2880 RVA: 0x0001E6B0 File Offset: 0x0001C8B0
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qlstVe_showFullScreen = QListView.__N.QLstVe_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qlstVe_showFullScreen);
		}

		// Token: 0x06000B41 RID: 2881 RVA: 0x0001E6DC File Offset: 0x0001C8DC
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qlstVe_showNormal = QListView.__N.QLstVe_showNormal;
			calli(System.Void(System.IntPtr), this.self, qlstVe_showNormal);
		}

		// Token: 0x06000B42 RID: 2882 RVA: 0x0001E708 File Offset: 0x0001C908
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qlstVe_close = QListView.__N.QLstVe_close;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_close) > 0;
		}

		// Token: 0x06000B43 RID: 2883 RVA: 0x0001E738 File Offset: 0x0001C938
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qlstVe_raise = QListView.__N.QLstVe_raise;
			calli(System.Void(System.IntPtr), this.self, qlstVe_raise);
		}

		// Token: 0x06000B44 RID: 2884 RVA: 0x0001E764 File Offset: 0x0001C964
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qlstVe_lower = QListView.__N.QLstVe_lower;
			calli(System.Void(System.IntPtr), this.self, qlstVe_lower);
		}

		// Token: 0x06000B45 RID: 2885 RVA: 0x0001E790 File Offset: 0x0001C990
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qlstVe_isVisible = QListView.__N.QLstVe_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_isVisible) > 0;
		}

		// Token: 0x06000B46 RID: 2886 RVA: 0x0001E7C0 File Offset: 0x0001C9C0
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qlstVe_setAttribute = QListView.__N.QLstVe_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qlstVe_setAttribute);
		}

		// Token: 0x06000B47 RID: 2887 RVA: 0x0001E7F4 File Offset: 0x0001C9F4
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qlstVe_testAttribute = QListView.__N.QLstVe_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qlstVe_testAttribute) > 0;
		}

		// Token: 0x06000B48 RID: 2888 RVA: 0x0001E824 File Offset: 0x0001CA24
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qlstVe_acceptDrops = QListView.__N.QLstVe_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_acceptDrops) > 0;
		}

		// Token: 0x06000B49 RID: 2889 RVA: 0x0001E854 File Offset: 0x0001CA54
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qlstVe_setAcceptDrops = QListView.__N.QLstVe_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qlstVe_setAcceptDrops);
		}

		// Token: 0x06000B4A RID: 2890 RVA: 0x0001E888 File Offset: 0x0001CA88
		internal readonly void update()
		{
			this.NullCheck("update");
			method qlstVe_update = QListView.__N.QLstVe_update;
			calli(System.Void(System.IntPtr), this.self, qlstVe_update);
		}

		// Token: 0x06000B4B RID: 2891 RVA: 0x0001E8B4 File Offset: 0x0001CAB4
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qlstVe_repaint = QListView.__N.QLstVe_repaint;
			calli(System.Void(System.IntPtr), this.self, qlstVe_repaint);
		}

		// Token: 0x06000B4C RID: 2892 RVA: 0x0001E8E0 File Offset: 0x0001CAE0
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qlstVe_setCursor = QListView.__N.QLstVe_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qlstVe_setCursor);
		}

		// Token: 0x06000B4D RID: 2893 RVA: 0x0001E90C File Offset: 0x0001CB0C
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qlstVe_unsetCursor = QListView.__N.QLstVe_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qlstVe_unsetCursor);
		}

		// Token: 0x06000B4E RID: 2894 RVA: 0x0001E938 File Offset: 0x0001CB38
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qlstVe_setWindowIcon = QListView.__N.QLstVe_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qlstVe_setWindowIcon);
		}

		// Token: 0x06000B4F RID: 2895 RVA: 0x0001E968 File Offset: 0x0001CB68
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qlstVe_setWindowIconText = QListView.__N.QLstVe_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qlstVe_setWindowIconText);
		}

		// Token: 0x06000B50 RID: 2896 RVA: 0x0001E998 File Offset: 0x0001CB98
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qlstVe_setWindowOpacity = QListView.__N.QLstVe_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qlstVe_setWindowOpacity);
		}

		// Token: 0x06000B51 RID: 2897 RVA: 0x0001E9C4 File Offset: 0x0001CBC4
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qlstVe_windowOpacity = QListView.__N.QLstVe_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qlstVe_windowOpacity);
		}

		// Token: 0x06000B52 RID: 2898 RVA: 0x0001E9F0 File Offset: 0x0001CBF0
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qlstVe_isMinimized = QListView.__N.QLstVe_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_isMinimized) > 0;
		}

		// Token: 0x06000B53 RID: 2899 RVA: 0x0001EA20 File Offset: 0x0001CC20
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qlstVe_isMaximized = QListView.__N.QLstVe_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_isMaximized) > 0;
		}

		// Token: 0x06000B54 RID: 2900 RVA: 0x0001EA50 File Offset: 0x0001CC50
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qlstVe_isFullScreen = QListView.__N.QLstVe_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_isFullScreen) > 0;
		}

		// Token: 0x06000B55 RID: 2901 RVA: 0x0001EA80 File Offset: 0x0001CC80
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qlstVe_setMouseTracking = QListView.__N.QLstVe_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qlstVe_setMouseTracking);
		}

		// Token: 0x06000B56 RID: 2902 RVA: 0x0001EAB4 File Offset: 0x0001CCB4
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qlstVe_hasMouseTracking = QListView.__N.QLstVe_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_hasMouseTracking) > 0;
		}

		// Token: 0x06000B57 RID: 2903 RVA: 0x0001EAE4 File Offset: 0x0001CCE4
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qlstVe_underMouse = QListView.__N.QLstVe_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_underMouse) > 0;
		}

		// Token: 0x06000B58 RID: 2904 RVA: 0x0001EB14 File Offset: 0x0001CD14
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qlstVe_mapToGlobal = QListView.__N.QLstVe_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qlstVe_mapToGlobal);
		}

		// Token: 0x06000B59 RID: 2905 RVA: 0x0001EB40 File Offset: 0x0001CD40
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qlstVe_mapFromGlobal = QListView.__N.QLstVe_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qlstVe_mapFromGlobal);
		}

		// Token: 0x06000B5A RID: 2906 RVA: 0x0001EB6C File Offset: 0x0001CD6C
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qlstVe_hasFocus = QListView.__N.QLstVe_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_hasFocus) > 0;
		}

		// Token: 0x06000B5B RID: 2907 RVA: 0x0001EB9C File Offset: 0x0001CD9C
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qlstVe_focusPolicy = QListView.__N.QLstVe_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qlstVe_focusPolicy);
		}

		// Token: 0x06000B5C RID: 2908 RVA: 0x0001EBC8 File Offset: 0x0001CDC8
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qlstVe_setFocusPolicy = QListView.__N.QLstVe_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qlstVe_setFocusPolicy);
		}

		// Token: 0x06000B5D RID: 2909 RVA: 0x0001EBF4 File Offset: 0x0001CDF4
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qlstVe_setFocusProxy = QListView.__N.QLstVe_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qlstVe_setFocusProxy);
		}

		// Token: 0x06000B5E RID: 2910 RVA: 0x0001EC24 File Offset: 0x0001CE24
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qlstVe_isActiveWindow = QListView.__N.QLstVe_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_isActiveWindow) > 0;
		}

		// Token: 0x06000B5F RID: 2911 RVA: 0x0001EC54 File Offset: 0x0001CE54
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qlstVe_updatesEnabled = QListView.__N.QLstVe_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_updatesEnabled) > 0;
		}

		// Token: 0x06000B60 RID: 2912 RVA: 0x0001EC84 File Offset: 0x0001CE84
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qlstVe_setUpdatesEnabled = QListView.__N.QLstVe_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qlstVe_setUpdatesEnabled);
		}

		// Token: 0x06000B61 RID: 2913 RVA: 0x0001ECB8 File Offset: 0x0001CEB8
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qlstVe_setFocus = QListView.__N.QLstVe_setFocus;
			calli(System.Void(System.IntPtr), this.self, qlstVe_setFocus);
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0001ECE4 File Offset: 0x0001CEE4
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qlstVe_activateWindow = QListView.__N.QLstVe_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qlstVe_activateWindow);
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x0001ED10 File Offset: 0x0001CF10
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qlstVe_clearFocus = QListView.__N.QLstVe_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qlstVe_clearFocus);
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x0001ED3C File Offset: 0x0001CF3C
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qlstVe_setSizePolicy = QListView.__N.QLstVe_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qlstVe_setSizePolicy);
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x0001ED6C File Offset: 0x0001CF6C
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qlstVe_devicePixelRatioF = QListView.__N.QLstVe_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qlstVe_devicePixelRatioF);
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0001ED98 File Offset: 0x0001CF98
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qlstVe_saveGeometry = QListView.__N.QLstVe_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qlstVe_saveGeometry));
		}

		// Token: 0x06000B67 RID: 2919 RVA: 0x0001EDC8 File Offset: 0x0001CFC8
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qlstVe_restoreGeometry = QListView.__N.QLstVe_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qlstVe_restoreGeometry) > 0;
		}

		// Token: 0x06000B68 RID: 2920 RVA: 0x0001EDFC File Offset: 0x0001CFFC
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qlstVe_addAction = QListView.__N.QLstVe_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qlstVe_addAction);
		}

		// Token: 0x06000B69 RID: 2921 RVA: 0x0001EE2C File Offset: 0x0001D02C
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qlstVe_removeAction = QListView.__N.QLstVe_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qlstVe_removeAction);
		}

		// Token: 0x06000B6A RID: 2922 RVA: 0x0001EE5C File Offset: 0x0001D05C
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qlstVe_setParent = QListView.__N.QLstVe_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qlstVe_setParent);
		}

		// Token: 0x06000B6B RID: 2923 RVA: 0x0001EE8C File Offset: 0x0001D08C
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qlstVe_parentWidget = QListView.__N.QLstVe_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qlstVe_parentWidget);
		}

		// Token: 0x06000B6C RID: 2924 RVA: 0x0001EEBC File Offset: 0x0001D0BC
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qlstVe_AddClassName = QListView.__N.QLstVe_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qlstVe_AddClassName);
		}

		// Token: 0x06000B6D RID: 2925 RVA: 0x0001EEEC File Offset: 0x0001D0EC
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qlstVe_Polish = QListView.__N.QLstVe_Polish;
			calli(System.Void(System.IntPtr), this.self, qlstVe_Polish);
		}

		// Token: 0x06000B6E RID: 2926 RVA: 0x0001EF18 File Offset: 0x0001D118
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qlstVe_toolTip = QListView.__N.QLstVe_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlstVe_toolTip));
		}

		// Token: 0x06000B6F RID: 2927 RVA: 0x0001EF48 File Offset: 0x0001D148
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qlstVe_setToolTip = QListView.__N.QLstVe_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qlstVe_setToolTip);
		}

		// Token: 0x06000B70 RID: 2928 RVA: 0x0001EF78 File Offset: 0x0001D178
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qlstVe_statusTip = QListView.__N.QLstVe_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qlstVe_statusTip));
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0001EFA8 File Offset: 0x0001D1A8
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qlstVe_setStatusTip = QListView.__N.QLstVe_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qlstVe_setStatusTip);
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0001EFD8 File Offset: 0x0001D1D8
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qlstVe_toolTipDuration = QListView.__N.QLstVe_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_toolTipDuration);
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0001F004 File Offset: 0x0001D204
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qlstVe_setToolTipDuration = QListView.__N.QLstVe_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qlstVe_setToolTipDuration);
		}

		// Token: 0x06000B74 RID: 2932 RVA: 0x0001F030 File Offset: 0x0001D230
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qlstVe_autoFillBackground = QListView.__N.QLstVe_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qlstVe_autoFillBackground) > 0;
		}

		// Token: 0x06000B75 RID: 2933 RVA: 0x0001F060 File Offset: 0x0001D260
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qlstVe_setAutoFillBackground = QListView.__N.QLstVe_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qlstVe_setAutoFillBackground);
		}

		// Token: 0x0400005A RID: 90
		internal IntPtr self;

		// Token: 0x0200011B RID: 283
		internal static class __N
		{
			// Token: 0x04000D0D RID: 3341
			internal static method From_QWidget_To_QListView;

			// Token: 0x04000D0E RID: 3342
			internal static method To_QWidget_From_QListView;

			// Token: 0x04000D0F RID: 3343
			internal static method From_QObject_To_QListView;

			// Token: 0x04000D10 RID: 3344
			internal static method To_QObject_From_QListView;

			// Token: 0x04000D11 RID: 3345
			internal static method QLstVe_setItemDelegate;

			// Token: 0x04000D12 RID: 3346
			internal static method QLstVe_uniformItemSizes;

			// Token: 0x04000D13 RID: 3347
			internal static method QLstVe_setUniformItemSizes;

			// Token: 0x04000D14 RID: 3348
			internal static method QLstVe_setModelColumn;

			// Token: 0x04000D15 RID: 3349
			internal static method QLstVe_modelColumn;

			// Token: 0x04000D16 RID: 3350
			internal static method QLstVe_setWordWrap;

			// Token: 0x04000D17 RID: 3351
			internal static method QLstVe_wordWrap;

			// Token: 0x04000D18 RID: 3352
			internal static method QLstVe_setWrapping;

			// Token: 0x04000D19 RID: 3353
			internal static method QLstVe_isWrapping;

			// Token: 0x04000D1A RID: 3354
			internal static method QLstVe_setViewMode;

			// Token: 0x04000D1B RID: 3355
			internal static method QLstVe_viewMode;

			// Token: 0x04000D1C RID: 3356
			internal static method QLstVe_setLayoutMode;

			// Token: 0x04000D1D RID: 3357
			internal static method QLstVe_layoutMode;

			// Token: 0x04000D1E RID: 3358
			internal static method QLstVe_setFlow;

			// Token: 0x04000D1F RID: 3359
			internal static method QLstVe_flow;

			// Token: 0x04000D20 RID: 3360
			internal static method QLstVe_setMovement;

			// Token: 0x04000D21 RID: 3361
			internal static method QLstVe_movement;

			// Token: 0x04000D22 RID: 3362
			internal static method QLstVe_setResizeMode;

			// Token: 0x04000D23 RID: 3363
			internal static method QLstVe_resizeMode;

			// Token: 0x04000D24 RID: 3364
			internal static method QLstVe_setBatchSize;

			// Token: 0x04000D25 RID: 3365
			internal static method QLstVe_batchSize;

			// Token: 0x04000D26 RID: 3366
			internal static method QLstVe_setGridSize;

			// Token: 0x04000D27 RID: 3367
			internal static method QLstVe_gridSize;

			// Token: 0x04000D28 RID: 3368
			internal static method QLstVe_visualRect;

			// Token: 0x04000D29 RID: 3369
			internal static method QLstVe_scrollTo;

			// Token: 0x04000D2A RID: 3370
			internal static method QLstVe_indexAt;

			// Token: 0x04000D2B RID: 3371
			internal static method QLstVe_setRootIndex;

			// Token: 0x04000D2C RID: 3372
			internal static method QLstVe_rootIndex;

			// Token: 0x04000D2D RID: 3373
			internal static method QLstVe_selectionModel;

			// Token: 0x04000D2E RID: 3374
			internal static method QLstVe_isTopLevel;

			// Token: 0x04000D2F RID: 3375
			internal static method QLstVe_isWindow;

			// Token: 0x04000D30 RID: 3376
			internal static method QLstVe_isModal;

			// Token: 0x04000D31 RID: 3377
			internal static method QLstVe_setStyleSheet;

			// Token: 0x04000D32 RID: 3378
			internal static method QLstVe_windowTitle;

			// Token: 0x04000D33 RID: 3379
			internal static method QLstVe_setWindowTitle;

			// Token: 0x04000D34 RID: 3380
			internal static method QLstVe_setWindowFlags;

			// Token: 0x04000D35 RID: 3381
			internal static method QLstVe_windowFlags;

			// Token: 0x04000D36 RID: 3382
			internal static method QLstVe_size;

			// Token: 0x04000D37 RID: 3383
			internal static method QLstVe_resize;

			// Token: 0x04000D38 RID: 3384
			internal static method QLstVe_minimumSize;

			// Token: 0x04000D39 RID: 3385
			internal static method QLstVe_setMinimumSize;

			// Token: 0x04000D3A RID: 3386
			internal static method QLstVe_maximumSize;

			// Token: 0x04000D3B RID: 3387
			internal static method QLstVe_setMaximumSize;

			// Token: 0x04000D3C RID: 3388
			internal static method QLstVe_pos;

			// Token: 0x04000D3D RID: 3389
			internal static method QLstVe_move;

			// Token: 0x04000D3E RID: 3390
			internal static method QLstVe_isEnabled;

			// Token: 0x04000D3F RID: 3391
			internal static method QLstVe_setEnabled;

			// Token: 0x04000D40 RID: 3392
			internal static method QLstVe_setVisible;

			// Token: 0x04000D41 RID: 3393
			internal static method QLstVe_setHidden;

			// Token: 0x04000D42 RID: 3394
			internal static method QLstVe_show;

			// Token: 0x04000D43 RID: 3395
			internal static method QLstVe_hide;

			// Token: 0x04000D44 RID: 3396
			internal static method QLstVe_showMinimized;

			// Token: 0x04000D45 RID: 3397
			internal static method QLstVe_showMaximized;

			// Token: 0x04000D46 RID: 3398
			internal static method QLstVe_showFullScreen;

			// Token: 0x04000D47 RID: 3399
			internal static method QLstVe_showNormal;

			// Token: 0x04000D48 RID: 3400
			internal static method QLstVe_close;

			// Token: 0x04000D49 RID: 3401
			internal static method QLstVe_raise;

			// Token: 0x04000D4A RID: 3402
			internal static method QLstVe_lower;

			// Token: 0x04000D4B RID: 3403
			internal static method QLstVe_isVisible;

			// Token: 0x04000D4C RID: 3404
			internal static method QLstVe_setAttribute;

			// Token: 0x04000D4D RID: 3405
			internal static method QLstVe_testAttribute;

			// Token: 0x04000D4E RID: 3406
			internal static method QLstVe_acceptDrops;

			// Token: 0x04000D4F RID: 3407
			internal static method QLstVe_setAcceptDrops;

			// Token: 0x04000D50 RID: 3408
			internal static method QLstVe_update;

			// Token: 0x04000D51 RID: 3409
			internal static method QLstVe_repaint;

			// Token: 0x04000D52 RID: 3410
			internal static method QLstVe_setCursor;

			// Token: 0x04000D53 RID: 3411
			internal static method QLstVe_unsetCursor;

			// Token: 0x04000D54 RID: 3412
			internal static method QLstVe_setWindowIcon;

			// Token: 0x04000D55 RID: 3413
			internal static method QLstVe_setWindowIconText;

			// Token: 0x04000D56 RID: 3414
			internal static method QLstVe_setWindowOpacity;

			// Token: 0x04000D57 RID: 3415
			internal static method QLstVe_windowOpacity;

			// Token: 0x04000D58 RID: 3416
			internal static method QLstVe_isMinimized;

			// Token: 0x04000D59 RID: 3417
			internal static method QLstVe_isMaximized;

			// Token: 0x04000D5A RID: 3418
			internal static method QLstVe_isFullScreen;

			// Token: 0x04000D5B RID: 3419
			internal static method QLstVe_setMouseTracking;

			// Token: 0x04000D5C RID: 3420
			internal static method QLstVe_hasMouseTracking;

			// Token: 0x04000D5D RID: 3421
			internal static method QLstVe_underMouse;

			// Token: 0x04000D5E RID: 3422
			internal static method QLstVe_mapToGlobal;

			// Token: 0x04000D5F RID: 3423
			internal static method QLstVe_mapFromGlobal;

			// Token: 0x04000D60 RID: 3424
			internal static method QLstVe_hasFocus;

			// Token: 0x04000D61 RID: 3425
			internal static method QLstVe_focusPolicy;

			// Token: 0x04000D62 RID: 3426
			internal static method QLstVe_setFocusPolicy;

			// Token: 0x04000D63 RID: 3427
			internal static method QLstVe_setFocusProxy;

			// Token: 0x04000D64 RID: 3428
			internal static method QLstVe_isActiveWindow;

			// Token: 0x04000D65 RID: 3429
			internal static method QLstVe_updatesEnabled;

			// Token: 0x04000D66 RID: 3430
			internal static method QLstVe_setUpdatesEnabled;

			// Token: 0x04000D67 RID: 3431
			internal static method QLstVe_setFocus;

			// Token: 0x04000D68 RID: 3432
			internal static method QLstVe_activateWindow;

			// Token: 0x04000D69 RID: 3433
			internal static method QLstVe_clearFocus;

			// Token: 0x04000D6A RID: 3434
			internal static method QLstVe_setSizePolicy;

			// Token: 0x04000D6B RID: 3435
			internal static method QLstVe_devicePixelRatioF;

			// Token: 0x04000D6C RID: 3436
			internal static method QLstVe_saveGeometry;

			// Token: 0x04000D6D RID: 3437
			internal static method QLstVe_restoreGeometry;

			// Token: 0x04000D6E RID: 3438
			internal static method QLstVe_addAction;

			// Token: 0x04000D6F RID: 3439
			internal static method QLstVe_removeAction;

			// Token: 0x04000D70 RID: 3440
			internal static method QLstVe_setParent;

			// Token: 0x04000D71 RID: 3441
			internal static method QLstVe_parentWidget;

			// Token: 0x04000D72 RID: 3442
			internal static method QLstVe_AddClassName;

			// Token: 0x04000D73 RID: 3443
			internal static method QLstVe_Polish;

			// Token: 0x04000D74 RID: 3444
			internal static method QLstVe_toolTip;

			// Token: 0x04000D75 RID: 3445
			internal static method QLstVe_setToolTip;

			// Token: 0x04000D76 RID: 3446
			internal static method QLstVe_statusTip;

			// Token: 0x04000D77 RID: 3447
			internal static method QLstVe_setStatusTip;

			// Token: 0x04000D78 RID: 3448
			internal static method QLstVe_toolTipDuration;

			// Token: 0x04000D79 RID: 3449
			internal static method QLstVe_setToolTipDuration;

			// Token: 0x04000D7A RID: 3450
			internal static method QLstVe_autoFillBackground;

			// Token: 0x04000D7B RID: 3451
			internal static method QLstVe_setAutoFillBackground;
		}
	}
}
