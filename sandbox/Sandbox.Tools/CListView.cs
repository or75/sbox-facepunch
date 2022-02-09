using System;
using System.Runtime.CompilerServices;
using Native;
using Sandbox;
using Tools;

// Token: 0x02000013 RID: 19
internal struct CListView
{
	// Token: 0x060000A3 RID: 163 RVA: 0x0000373C File Offset: 0x0000193C
	public static implicit operator IntPtr(CListView value)
	{
		return value.self;
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x00003744 File Offset: 0x00001944
	public static implicit operator CListView(IntPtr value)
	{
		return new CListView
		{
			self = value
		};
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00003762 File Offset: 0x00001962
	public static bool operator ==(CListView c1, CListView c2)
	{
		return c1.self == c2.self;
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00003775 File Offset: 0x00001975
	public static bool operator !=(CListView c1, CListView c2)
	{
		return c1.self != c2.self;
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x00003788 File Offset: 0x00001988
	public override bool Equals(object obj)
	{
		if (obj is CListView)
		{
			CListView c = (CListView)obj;
			return c == this;
		}
		return false;
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x000037B2 File Offset: 0x000019B2
	internal CListView(IntPtr ptr)
	{
		this.self = ptr;
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x000037BC File Offset: 0x000019BC
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("CListView ");
		defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x17000011 RID: 17
	// (get) Token: 0x060000AA RID: 170 RVA: 0x000037F8 File Offset: 0x000019F8
	internal readonly bool IsNull
	{
		get
		{
			return this.self == IntPtr.Zero;
		}
	}

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x060000AB RID: 171 RVA: 0x0000380A File Offset: 0x00001A0A
	internal readonly bool IsValid
	{
		get
		{
			return !this.IsNull;
		}
	}

	// Token: 0x060000AC RID: 172 RVA: 0x00003815 File Offset: 0x00001A15
	internal readonly IntPtr GetPointerAssertIfNull()
	{
		this.NullCheck("GetPointerAssertIfNull");
		return this.self;
	}

	// Token: 0x060000AD RID: 173 RVA: 0x00003828 File Offset: 0x00001A28
	internal readonly void NullCheck([CallerMemberName] string n = "")
	{
		if (this.IsNull)
		{
			throw new NullReferenceException("CListView was null when calling " + n);
		}
	}

	// Token: 0x060000AE RID: 174 RVA: 0x00003843 File Offset: 0x00001A43
	public override int GetHashCode()
	{
		return this.self.GetHashCode();
	}

	// Token: 0x060000AF RID: 175 RVA: 0x00003850 File Offset: 0x00001A50
	public static implicit operator QListView(CListView value)
	{
		method to_QListView_From_CListView = CListView.__N.To_QListView_From_CListView;
		return calli(System.IntPtr(System.IntPtr), value, to_QListView_From_CListView);
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00003874 File Offset: 0x00001A74
	public static explicit operator CListView(QListView value)
	{
		method from_QListView_To_CListView = CListView.__N.From_QListView_To_CListView;
		return calli(System.IntPtr(System.IntPtr), value, from_QListView_To_CListView);
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00003898 File Offset: 0x00001A98
	public static implicit operator QWidget(CListView value)
	{
		method to_QWidget_From_CListView = CListView.__N.To_QWidget_From_CListView;
		return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_CListView);
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x000038BC File Offset: 0x00001ABC
	public static explicit operator CListView(QWidget value)
	{
		method from_QWidget_To_CListView = CListView.__N.From_QWidget_To_CListView;
		return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_CListView);
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x000038E0 File Offset: 0x00001AE0
	public static implicit operator Native.QObject(CListView value)
	{
		method to_QObject_From_CListView = CListView.__N.To_QObject_From_CListView;
		return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_CListView);
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x00003904 File Offset: 0x00001B04
	public static explicit operator CListView(Native.QObject value)
	{
		method from_QObject_To_CListView = CListView.__N.From_QObject_To_CListView;
		return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_CListView);
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x00003928 File Offset: 0x00001B28
	internal static CListView Create(QWidget parent, ListView obj)
	{
		method clstVe_Create = CListView.__N.CLstVe_Create;
		return calli(System.IntPtr(System.IntPtr,System.UInt32), parent, (obj == null) ? 0U : InteropSystem.GetAddress<ListView>(obj, true), clstVe_Create);
	}

	// Token: 0x060000B6 RID: 182 RVA: 0x0000395C File Offset: 0x00001B5C
	internal readonly void setModelInternal(CDataModel model)
	{
		this.NullCheck("setModelInternal");
		method clstVe_setModelInternal = CListView.__N.CLstVe_setModelInternal;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, model, clstVe_setModelInternal);
	}

	// Token: 0x060000B7 RID: 183 RVA: 0x0000398C File Offset: 0x00001B8C
	internal readonly void setItemDelegate(CDataDelegate del)
	{
		this.NullCheck("setItemDelegate");
		method clstVe_setItemDelegate = CListView.__N.CLstVe_setItemDelegate;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, del, clstVe_setItemDelegate);
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x000039BC File Offset: 0x00001BBC
	internal readonly bool uniformItemSizes()
	{
		this.NullCheck("uniformItemSizes");
		method clstVe_uniformItemSizes = CListView.__N.CLstVe_uniformItemSizes;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_uniformItemSizes) > 0;
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x000039EC File Offset: 0x00001BEC
	internal readonly void setUniformItemSizes(bool uniform)
	{
		this.NullCheck("setUniformItemSizes");
		method clstVe_setUniformItemSizes = CListView.__N.CLstVe_setUniformItemSizes;
		calli(System.Void(System.IntPtr,System.Int32), this.self, uniform ? 1 : 0, clstVe_setUniformItemSizes);
	}

	// Token: 0x060000BA RID: 186 RVA: 0x00003A20 File Offset: 0x00001C20
	internal readonly void setModelColumn(int column)
	{
		this.NullCheck("setModelColumn");
		method clstVe_setModelColumn = CListView.__N.CLstVe_setModelColumn;
		calli(System.Void(System.IntPtr,System.Int32), this.self, column, clstVe_setModelColumn);
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00003A4C File Offset: 0x00001C4C
	internal readonly int modelColumn()
	{
		this.NullCheck("modelColumn");
		method clstVe_modelColumn = CListView.__N.CLstVe_modelColumn;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_modelColumn);
	}

	// Token: 0x060000BC RID: 188 RVA: 0x00003A78 File Offset: 0x00001C78
	internal readonly void setWordWrap(bool on)
	{
		this.NullCheck("setWordWrap");
		method clstVe_setWordWrap = CListView.__N.CLstVe_setWordWrap;
		calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, clstVe_setWordWrap);
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00003AAC File Offset: 0x00001CAC
	internal readonly bool wordWrap()
	{
		this.NullCheck("wordWrap");
		method clstVe_wordWrap = CListView.__N.CLstVe_wordWrap;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_wordWrap) > 0;
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00003ADC File Offset: 0x00001CDC
	internal readonly void setWrapping(bool on)
	{
		this.NullCheck("setWrapping");
		method clstVe_setWrapping = CListView.__N.CLstVe_setWrapping;
		calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, clstVe_setWrapping);
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00003B10 File Offset: 0x00001D10
	internal readonly bool isWrapping()
	{
		this.NullCheck("isWrapping");
		method clstVe_isWrapping = CListView.__N.CLstVe_isWrapping;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_isWrapping) > 0;
	}

	// Token: 0x060000C0 RID: 192 RVA: 0x00003B40 File Offset: 0x00001D40
	internal readonly void setViewMode(ViewMode mode)
	{
		this.NullCheck("setViewMode");
		method clstVe_setViewMode = CListView.__N.CLstVe_setViewMode;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)mode, clstVe_setViewMode);
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00003B6C File Offset: 0x00001D6C
	internal readonly ViewMode viewMode()
	{
		this.NullCheck("viewMode");
		method clstVe_viewMode = CListView.__N.CLstVe_viewMode;
		return calli(System.Int64(System.IntPtr), this.self, clstVe_viewMode);
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x00003B98 File Offset: 0x00001D98
	internal readonly void setLayoutMode(LayoutMode mode)
	{
		this.NullCheck("setLayoutMode");
		method clstVe_setLayoutMode = CListView.__N.CLstVe_setLayoutMode;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)mode, clstVe_setLayoutMode);
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x00003BC4 File Offset: 0x00001DC4
	internal readonly LayoutMode layoutMode()
	{
		this.NullCheck("layoutMode");
		method clstVe_layoutMode = CListView.__N.CLstVe_layoutMode;
		return calli(System.Int64(System.IntPtr), this.self, clstVe_layoutMode);
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00003BF0 File Offset: 0x00001DF0
	internal readonly void setFlow(Flow flow)
	{
		this.NullCheck("setFlow");
		method clstVe_setFlow = CListView.__N.CLstVe_setFlow;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)flow, clstVe_setFlow);
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00003C1C File Offset: 0x00001E1C
	internal readonly Flow flow()
	{
		this.NullCheck("flow");
		method clstVe_flow = CListView.__N.CLstVe_flow;
		return calli(System.Int64(System.IntPtr), this.self, clstVe_flow);
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x00003C48 File Offset: 0x00001E48
	internal readonly void setMovement(Movement movement)
	{
		this.NullCheck("setMovement");
		method clstVe_setMovement = CListView.__N.CLstVe_setMovement;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)movement, clstVe_setMovement);
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00003C74 File Offset: 0x00001E74
	internal readonly Movement movement()
	{
		this.NullCheck("movement");
		method clstVe_movement = CListView.__N.CLstVe_movement;
		return calli(System.Int64(System.IntPtr), this.self, clstVe_movement);
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00003CA0 File Offset: 0x00001EA0
	internal readonly void setResizeMode(ResizeMode movement)
	{
		this.NullCheck("setResizeMode");
		method clstVe_setResizeMode = CListView.__N.CLstVe_setResizeMode;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)movement, clstVe_setResizeMode);
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00003CCC File Offset: 0x00001ECC
	internal readonly ResizeMode resizeMode()
	{
		this.NullCheck("resizeMode");
		method clstVe_resizeMode = CListView.__N.CLstVe_resizeMode;
		return calli(System.Int64(System.IntPtr), this.self, clstVe_resizeMode);
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00003CF8 File Offset: 0x00001EF8
	internal readonly void setBatchSize(int batchSize)
	{
		this.NullCheck("setBatchSize");
		method clstVe_setBatchSize = CListView.__N.CLstVe_setBatchSize;
		calli(System.Void(System.IntPtr,System.Int32), this.self, batchSize, clstVe_setBatchSize);
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00003D24 File Offset: 0x00001F24
	internal readonly int batchSize()
	{
		this.NullCheck("batchSize");
		method clstVe_batchSize = CListView.__N.CLstVe_batchSize;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_batchSize);
	}

	// Token: 0x060000CC RID: 204 RVA: 0x00003D50 File Offset: 0x00001F50
	internal readonly void setGridSize(Vector3 size)
	{
		this.NullCheck("setGridSize");
		method clstVe_setGridSize = CListView.__N.CLstVe_setGridSize;
		calli(System.Void(System.IntPtr,Vector3), this.self, size, clstVe_setGridSize);
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00003D7C File Offset: 0x00001F7C
	internal readonly Vector3 gridSize()
	{
		this.NullCheck("gridSize");
		method clstVe_gridSize = CListView.__N.CLstVe_gridSize;
		return calli(Vector3(System.IntPtr), this.self, clstVe_gridSize);
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00003DA8 File Offset: 0x00001FA8
	internal unsafe readonly QRectF visualRect(ModelIndex index)
	{
		this.NullCheck("visualRect");
		method clstVe_visualRect = CListView.__N.CLstVe_visualRect;
		return calli(QRectF(System.IntPtr,Tools.ModelIndex*), this.self, &index, clstVe_visualRect);
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00003DD8 File Offset: 0x00001FD8
	internal unsafe readonly void scrollTo(ModelIndex index)
	{
		this.NullCheck("scrollTo");
		method clstVe_scrollTo = CListView.__N.CLstVe_scrollTo;
		calli(System.Void(System.IntPtr,Tools.ModelIndex*), this.self, &index, clstVe_scrollTo);
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00003E08 File Offset: 0x00002008
	internal readonly ModelIndex indexAt(Vector3 p)
	{
		this.NullCheck("indexAt");
		method clstVe_indexAt = CListView.__N.CLstVe_indexAt;
		return calli(Tools.ModelIndex(System.IntPtr,Vector3), this.self, p, clstVe_indexAt);
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00003E34 File Offset: 0x00002034
	internal unsafe readonly void setRootIndex(ModelIndex index)
	{
		this.NullCheck("setRootIndex");
		method clstVe_setRootIndex = CListView.__N.CLstVe_setRootIndex;
		calli(System.Void(System.IntPtr,Tools.ModelIndex*), this.self, &index, clstVe_setRootIndex);
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00003E64 File Offset: 0x00002064
	internal readonly ModelIndex rootIndex()
	{
		this.NullCheck("rootIndex");
		method clstVe_rootIndex = CListView.__N.CLstVe_rootIndex;
		return calli(Tools.ModelIndex(System.IntPtr), this.self, clstVe_rootIndex);
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00003E90 File Offset: 0x00002090
	internal readonly QItemSelectionModel selectionModel()
	{
		this.NullCheck("selectionModel");
		method clstVe_selectionModel = CListView.__N.CLstVe_selectionModel;
		return calli(System.IntPtr(System.IntPtr), this.self, clstVe_selectionModel);
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00003EC0 File Offset: 0x000020C0
	internal readonly bool isTopLevel()
	{
		this.NullCheck("isTopLevel");
		method clstVe_isTopLevel = CListView.__N.CLstVe_isTopLevel;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_isTopLevel) > 0;
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x00003EF0 File Offset: 0x000020F0
	internal readonly bool isWindow()
	{
		this.NullCheck("isWindow");
		method clstVe_isWindow = CListView.__N.CLstVe_isWindow;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_isWindow) > 0;
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00003F20 File Offset: 0x00002120
	internal readonly bool isModal()
	{
		this.NullCheck("isModal");
		method clstVe_isModal = CListView.__N.CLstVe_isModal;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_isModal) > 0;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00003F50 File Offset: 0x00002150
	internal readonly void setStyleSheet(string sheet)
	{
		this.NullCheck("setStyleSheet");
		method clstVe_setStyleSheet = CListView.__N.CLstVe_setStyleSheet;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), clstVe_setStyleSheet);
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00003F80 File Offset: 0x00002180
	internal readonly string windowTitle()
	{
		this.NullCheck("windowTitle");
		method clstVe_windowTitle = CListView.__N.CLstVe_windowTitle;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, clstVe_windowTitle));
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00003FB0 File Offset: 0x000021B0
	internal readonly void setWindowTitle(string title)
	{
		this.NullCheck("setWindowTitle");
		method clstVe_setWindowTitle = CListView.__N.CLstVe_setWindowTitle;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), clstVe_setWindowTitle);
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00003FE0 File Offset: 0x000021E0
	internal readonly void setWindowFlags(WindowFlags type)
	{
		this.NullCheck("setWindowFlags");
		method clstVe_setWindowFlags = CListView.__N.CLstVe_setWindowFlags;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, clstVe_setWindowFlags);
	}

	// Token: 0x060000DB RID: 219 RVA: 0x0000400C File Offset: 0x0000220C
	internal readonly WindowFlags windowFlags()
	{
		this.NullCheck("windowFlags");
		method clstVe_windowFlags = CListView.__N.CLstVe_windowFlags;
		return calli(System.Int64(System.IntPtr), this.self, clstVe_windowFlags);
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00004038 File Offset: 0x00002238
	internal readonly Vector3 size()
	{
		this.NullCheck("size");
		method clstVe_size = CListView.__N.CLstVe_size;
		return calli(Vector3(System.IntPtr), this.self, clstVe_size);
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00004064 File Offset: 0x00002264
	internal readonly void resize(Vector3 x)
	{
		this.NullCheck("resize");
		method clstVe_resize = CListView.__N.CLstVe_resize;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, clstVe_resize);
	}

	// Token: 0x060000DE RID: 222 RVA: 0x00004090 File Offset: 0x00002290
	internal readonly Vector3 minimumSize()
	{
		this.NullCheck("minimumSize");
		method clstVe_minimumSize = CListView.__N.CLstVe_minimumSize;
		return calli(Vector3(System.IntPtr), this.self, clstVe_minimumSize);
	}

	// Token: 0x060000DF RID: 223 RVA: 0x000040BC File Offset: 0x000022BC
	internal readonly void setMinimumSize(Vector3 x)
	{
		this.NullCheck("setMinimumSize");
		method clstVe_setMinimumSize = CListView.__N.CLstVe_setMinimumSize;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, clstVe_setMinimumSize);
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x000040E8 File Offset: 0x000022E8
	internal readonly Vector3 maximumSize()
	{
		this.NullCheck("maximumSize");
		method clstVe_maximumSize = CListView.__N.CLstVe_maximumSize;
		return calli(Vector3(System.IntPtr), this.self, clstVe_maximumSize);
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00004114 File Offset: 0x00002314
	internal readonly void setMaximumSize(Vector3 x)
	{
		this.NullCheck("setMaximumSize");
		method clstVe_setMaximumSize = CListView.__N.CLstVe_setMaximumSize;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, clstVe_setMaximumSize);
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00004140 File Offset: 0x00002340
	internal readonly Vector3 pos()
	{
		this.NullCheck("pos");
		method clstVe_pos = CListView.__N.CLstVe_pos;
		return calli(Vector3(System.IntPtr), this.self, clstVe_pos);
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x0000416C File Offset: 0x0000236C
	internal readonly void move(Vector3 x)
	{
		this.NullCheck("move");
		method clstVe_move = CListView.__N.CLstVe_move;
		calli(System.Void(System.IntPtr,Vector3), this.self, x, clstVe_move);
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00004198 File Offset: 0x00002398
	internal readonly bool isEnabled()
	{
		this.NullCheck("isEnabled");
		method clstVe_isEnabled = CListView.__N.CLstVe_isEnabled;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_isEnabled) > 0;
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x000041C8 File Offset: 0x000023C8
	internal readonly void setEnabled(bool x)
	{
		this.NullCheck("setEnabled");
		method clstVe_setEnabled = CListView.__N.CLstVe_setEnabled;
		calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, clstVe_setEnabled);
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x000041FC File Offset: 0x000023FC
	internal readonly void setVisible(bool visible)
	{
		this.NullCheck("setVisible");
		method clstVe_setVisible = CListView.__N.CLstVe_setVisible;
		calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, clstVe_setVisible);
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x00004230 File Offset: 0x00002430
	internal readonly void setHidden(bool hidden)
	{
		this.NullCheck("setHidden");
		method clstVe_setHidden = CListView.__N.CLstVe_setHidden;
		calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, clstVe_setHidden);
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00004264 File Offset: 0x00002464
	internal readonly void show()
	{
		this.NullCheck("show");
		method clstVe_show = CListView.__N.CLstVe_show;
		calli(System.Void(System.IntPtr), this.self, clstVe_show);
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x00004290 File Offset: 0x00002490
	internal readonly void hide()
	{
		this.NullCheck("hide");
		method clstVe_hide = CListView.__N.CLstVe_hide;
		calli(System.Void(System.IntPtr), this.self, clstVe_hide);
	}

	// Token: 0x060000EA RID: 234 RVA: 0x000042BC File Offset: 0x000024BC
	internal readonly void showMinimized()
	{
		this.NullCheck("showMinimized");
		method clstVe_showMinimized = CListView.__N.CLstVe_showMinimized;
		calli(System.Void(System.IntPtr), this.self, clstVe_showMinimized);
	}

	// Token: 0x060000EB RID: 235 RVA: 0x000042E8 File Offset: 0x000024E8
	internal readonly void showMaximized()
	{
		this.NullCheck("showMaximized");
		method clstVe_showMaximized = CListView.__N.CLstVe_showMaximized;
		calli(System.Void(System.IntPtr), this.self, clstVe_showMaximized);
	}

	// Token: 0x060000EC RID: 236 RVA: 0x00004314 File Offset: 0x00002514
	internal readonly void showFullScreen()
	{
		this.NullCheck("showFullScreen");
		method clstVe_showFullScreen = CListView.__N.CLstVe_showFullScreen;
		calli(System.Void(System.IntPtr), this.self, clstVe_showFullScreen);
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00004340 File Offset: 0x00002540
	internal readonly void showNormal()
	{
		this.NullCheck("showNormal");
		method clstVe_showNormal = CListView.__N.CLstVe_showNormal;
		calli(System.Void(System.IntPtr), this.self, clstVe_showNormal);
	}

	// Token: 0x060000EE RID: 238 RVA: 0x0000436C File Offset: 0x0000256C
	internal readonly bool close()
	{
		this.NullCheck("close");
		method clstVe_close = CListView.__N.CLstVe_close;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_close) > 0;
	}

	// Token: 0x060000EF RID: 239 RVA: 0x0000439C File Offset: 0x0000259C
	internal readonly void raise()
	{
		this.NullCheck("raise");
		method clstVe_raise = CListView.__N.CLstVe_raise;
		calli(System.Void(System.IntPtr), this.self, clstVe_raise);
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x000043C8 File Offset: 0x000025C8
	internal readonly void lower()
	{
		this.NullCheck("lower");
		method clstVe_lower = CListView.__N.CLstVe_lower;
		calli(System.Void(System.IntPtr), this.self, clstVe_lower);
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x000043F4 File Offset: 0x000025F4
	internal readonly bool isVisible()
	{
		this.NullCheck("isVisible");
		method clstVe_isVisible = CListView.__N.CLstVe_isVisible;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_isVisible) > 0;
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x00004424 File Offset: 0x00002624
	internal readonly void setAttribute(Widget.Flag a, bool on)
	{
		this.NullCheck("setAttribute");
		method clstVe_setAttribute = CListView.__N.CLstVe_setAttribute;
		calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, clstVe_setAttribute);
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x00004458 File Offset: 0x00002658
	internal readonly bool testAttribute(Widget.Flag a)
	{
		this.NullCheck("testAttribute");
		method clstVe_testAttribute = CListView.__N.CLstVe_testAttribute;
		return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, clstVe_testAttribute) > 0;
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x00004488 File Offset: 0x00002688
	internal readonly bool acceptDrops()
	{
		this.NullCheck("acceptDrops");
		method clstVe_acceptDrops = CListView.__N.CLstVe_acceptDrops;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_acceptDrops) > 0;
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x000044B8 File Offset: 0x000026B8
	internal readonly void setAcceptDrops(bool on)
	{
		this.NullCheck("setAcceptDrops");
		method clstVe_setAcceptDrops = CListView.__N.CLstVe_setAcceptDrops;
		calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, clstVe_setAcceptDrops);
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x000044EC File Offset: 0x000026EC
	internal readonly void update()
	{
		this.NullCheck("update");
		method clstVe_update = CListView.__N.CLstVe_update;
		calli(System.Void(System.IntPtr), this.self, clstVe_update);
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x00004518 File Offset: 0x00002718
	internal readonly void repaint()
	{
		this.NullCheck("repaint");
		method clstVe_repaint = CListView.__N.CLstVe_repaint;
		calli(System.Void(System.IntPtr), this.self, clstVe_repaint);
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x00004544 File Offset: 0x00002744
	internal readonly void setCursor(CursorShape shape)
	{
		this.NullCheck("setCursor");
		method clstVe_setCursor = CListView.__N.CLstVe_setCursor;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, clstVe_setCursor);
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x00004570 File Offset: 0x00002770
	internal readonly void unsetCursor()
	{
		this.NullCheck("unsetCursor");
		method clstVe_unsetCursor = CListView.__N.CLstVe_unsetCursor;
		calli(System.Void(System.IntPtr), this.self, clstVe_unsetCursor);
	}

	// Token: 0x060000FA RID: 250 RVA: 0x0000459C File Offset: 0x0000279C
	internal readonly void setWindowIcon(string icon)
	{
		this.NullCheck("setWindowIcon");
		method clstVe_setWindowIcon = CListView.__N.CLstVe_setWindowIcon;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), clstVe_setWindowIcon);
	}

	// Token: 0x060000FB RID: 251 RVA: 0x000045CC File Offset: 0x000027CC
	internal readonly void setWindowIconText(string str)
	{
		this.NullCheck("setWindowIconText");
		method clstVe_setWindowIconText = CListView.__N.CLstVe_setWindowIconText;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), clstVe_setWindowIconText);
	}

	// Token: 0x060000FC RID: 252 RVA: 0x000045FC File Offset: 0x000027FC
	internal readonly void setWindowOpacity(float level)
	{
		this.NullCheck("setWindowOpacity");
		method clstVe_setWindowOpacity = CListView.__N.CLstVe_setWindowOpacity;
		calli(System.Void(System.IntPtr,System.Single), this.self, level, clstVe_setWindowOpacity);
	}

	// Token: 0x060000FD RID: 253 RVA: 0x00004628 File Offset: 0x00002828
	internal readonly float windowOpacity()
	{
		this.NullCheck("windowOpacity");
		method clstVe_windowOpacity = CListView.__N.CLstVe_windowOpacity;
		return calli(System.Single(System.IntPtr), this.self, clstVe_windowOpacity);
	}

	// Token: 0x060000FE RID: 254 RVA: 0x00004654 File Offset: 0x00002854
	internal readonly bool isMinimized()
	{
		this.NullCheck("isMinimized");
		method clstVe_isMinimized = CListView.__N.CLstVe_isMinimized;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_isMinimized) > 0;
	}

	// Token: 0x060000FF RID: 255 RVA: 0x00004684 File Offset: 0x00002884
	internal readonly bool isMaximized()
	{
		this.NullCheck("isMaximized");
		method clstVe_isMaximized = CListView.__N.CLstVe_isMaximized;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_isMaximized) > 0;
	}

	// Token: 0x06000100 RID: 256 RVA: 0x000046B4 File Offset: 0x000028B4
	internal readonly bool isFullScreen()
	{
		this.NullCheck("isFullScreen");
		method clstVe_isFullScreen = CListView.__N.CLstVe_isFullScreen;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_isFullScreen) > 0;
	}

	// Token: 0x06000101 RID: 257 RVA: 0x000046E4 File Offset: 0x000028E4
	internal readonly void setMouseTracking(bool enable)
	{
		this.NullCheck("setMouseTracking");
		method clstVe_setMouseTracking = CListView.__N.CLstVe_setMouseTracking;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, clstVe_setMouseTracking);
	}

	// Token: 0x06000102 RID: 258 RVA: 0x00004718 File Offset: 0x00002918
	internal readonly bool hasMouseTracking()
	{
		this.NullCheck("hasMouseTracking");
		method clstVe_hasMouseTracking = CListView.__N.CLstVe_hasMouseTracking;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_hasMouseTracking) > 0;
	}

	// Token: 0x06000103 RID: 259 RVA: 0x00004748 File Offset: 0x00002948
	internal readonly bool underMouse()
	{
		this.NullCheck("underMouse");
		method clstVe_underMouse = CListView.__N.CLstVe_underMouse;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_underMouse) > 0;
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00004778 File Offset: 0x00002978
	internal readonly Vector3 mapToGlobal(Vector3 p)
	{
		this.NullCheck("mapToGlobal");
		method clstVe_mapToGlobal = CListView.__N.CLstVe_mapToGlobal;
		return calli(Vector3(System.IntPtr,Vector3), this.self, p, clstVe_mapToGlobal);
	}

	// Token: 0x06000105 RID: 261 RVA: 0x000047A4 File Offset: 0x000029A4
	internal readonly Vector3 mapFromGlobal(Vector3 p)
	{
		this.NullCheck("mapFromGlobal");
		method clstVe_mapFromGlobal = CListView.__N.CLstVe_mapFromGlobal;
		return calli(Vector3(System.IntPtr,Vector3), this.self, p, clstVe_mapFromGlobal);
	}

	// Token: 0x06000106 RID: 262 RVA: 0x000047D0 File Offset: 0x000029D0
	internal readonly bool hasFocus()
	{
		this.NullCheck("hasFocus");
		method clstVe_hasFocus = CListView.__N.CLstVe_hasFocus;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_hasFocus) > 0;
	}

	// Token: 0x06000107 RID: 263 RVA: 0x00004800 File Offset: 0x00002A00
	internal readonly FocusMode focusPolicy()
	{
		this.NullCheck("focusPolicy");
		method clstVe_focusPolicy = CListView.__N.CLstVe_focusPolicy;
		return calli(System.Int64(System.IntPtr), this.self, clstVe_focusPolicy);
	}

	// Token: 0x06000108 RID: 264 RVA: 0x0000482C File Offset: 0x00002A2C
	internal readonly void setFocusPolicy(FocusMode policy)
	{
		this.NullCheck("setFocusPolicy");
		method clstVe_setFocusPolicy = CListView.__N.CLstVe_setFocusPolicy;
		calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, clstVe_setFocusPolicy);
	}

	// Token: 0x06000109 RID: 265 RVA: 0x00004858 File Offset: 0x00002A58
	internal readonly void setFocusProxy(QWidget widget)
	{
		this.NullCheck("setFocusProxy");
		method clstVe_setFocusProxy = CListView.__N.CLstVe_setFocusProxy;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, clstVe_setFocusProxy);
	}

	// Token: 0x0600010A RID: 266 RVA: 0x00004888 File Offset: 0x00002A88
	internal readonly bool isActiveWindow()
	{
		this.NullCheck("isActiveWindow");
		method clstVe_isActiveWindow = CListView.__N.CLstVe_isActiveWindow;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_isActiveWindow) > 0;
	}

	// Token: 0x0600010B RID: 267 RVA: 0x000048B8 File Offset: 0x00002AB8
	internal readonly bool updatesEnabled()
	{
		this.NullCheck("updatesEnabled");
		method clstVe_updatesEnabled = CListView.__N.CLstVe_updatesEnabled;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_updatesEnabled) > 0;
	}

	// Token: 0x0600010C RID: 268 RVA: 0x000048E8 File Offset: 0x00002AE8
	internal readonly void setUpdatesEnabled(bool enable)
	{
		this.NullCheck("setUpdatesEnabled");
		method clstVe_setUpdatesEnabled = CListView.__N.CLstVe_setUpdatesEnabled;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, clstVe_setUpdatesEnabled);
	}

	// Token: 0x0600010D RID: 269 RVA: 0x0000491C File Offset: 0x00002B1C
	internal readonly void setFocus()
	{
		this.NullCheck("setFocus");
		method clstVe_setFocus = CListView.__N.CLstVe_setFocus;
		calli(System.Void(System.IntPtr), this.self, clstVe_setFocus);
	}

	// Token: 0x0600010E RID: 270 RVA: 0x00004948 File Offset: 0x00002B48
	internal readonly void activateWindow()
	{
		this.NullCheck("activateWindow");
		method clstVe_activateWindow = CListView.__N.CLstVe_activateWindow;
		calli(System.Void(System.IntPtr), this.self, clstVe_activateWindow);
	}

	// Token: 0x0600010F RID: 271 RVA: 0x00004974 File Offset: 0x00002B74
	internal readonly void clearFocus()
	{
		this.NullCheck("clearFocus");
		method clstVe_clearFocus = CListView.__N.CLstVe_clearFocus;
		calli(System.Void(System.IntPtr), this.self, clstVe_clearFocus);
	}

	// Token: 0x06000110 RID: 272 RVA: 0x000049A0 File Offset: 0x00002BA0
	internal readonly void setSizePolicy(SizeMode x, SizeMode y)
	{
		this.NullCheck("setSizePolicy");
		method clstVe_setSizePolicy = CListView.__N.CLstVe_setSizePolicy;
		calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, clstVe_setSizePolicy);
	}

	// Token: 0x06000111 RID: 273 RVA: 0x000049D0 File Offset: 0x00002BD0
	internal readonly float devicePixelRatioF()
	{
		this.NullCheck("devicePixelRatioF");
		method clstVe_devicePixelRatioF = CListView.__N.CLstVe_devicePixelRatioF;
		return calli(System.Single(System.IntPtr), this.self, clstVe_devicePixelRatioF);
	}

	// Token: 0x06000112 RID: 274 RVA: 0x000049FC File Offset: 0x00002BFC
	internal readonly string saveGeometry()
	{
		this.NullCheck("saveGeometry");
		method clstVe_saveGeometry = CListView.__N.CLstVe_saveGeometry;
		return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, clstVe_saveGeometry));
	}

	// Token: 0x06000113 RID: 275 RVA: 0x00004A2C File Offset: 0x00002C2C
	internal readonly bool restoreGeometry(string state)
	{
		this.NullCheck("restoreGeometry");
		method clstVe_restoreGeometry = CListView.__N.CLstVe_restoreGeometry;
		return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), clstVe_restoreGeometry) > 0;
	}

	// Token: 0x06000114 RID: 276 RVA: 0x00004A60 File Offset: 0x00002C60
	internal readonly void addAction(QAction action)
	{
		this.NullCheck("addAction");
		method clstVe_addAction = CListView.__N.CLstVe_addAction;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, clstVe_addAction);
	}

	// Token: 0x06000115 RID: 277 RVA: 0x00004A90 File Offset: 0x00002C90
	internal readonly void removeAction(QAction action)
	{
		this.NullCheck("removeAction");
		method clstVe_removeAction = CListView.__N.CLstVe_removeAction;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, clstVe_removeAction);
	}

	// Token: 0x06000116 RID: 278 RVA: 0x00004AC0 File Offset: 0x00002CC0
	internal readonly void setParent(QWidget parent)
	{
		this.NullCheck("setParent");
		method clstVe_setParent = CListView.__N.CLstVe_setParent;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, clstVe_setParent);
	}

	// Token: 0x06000117 RID: 279 RVA: 0x00004AF0 File Offset: 0x00002CF0
	internal readonly QWidget parentWidget()
	{
		this.NullCheck("parentWidget");
		method clstVe_parentWidget = CListView.__N.CLstVe_parentWidget;
		return calli(System.IntPtr(System.IntPtr), this.self, clstVe_parentWidget);
	}

	// Token: 0x06000118 RID: 280 RVA: 0x00004B20 File Offset: 0x00002D20
	internal readonly void AddClassName(string name)
	{
		this.NullCheck("AddClassName");
		method clstVe_AddClassName = CListView.__N.CLstVe_AddClassName;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), clstVe_AddClassName);
	}

	// Token: 0x06000119 RID: 281 RVA: 0x00004B50 File Offset: 0x00002D50
	internal readonly void Polish()
	{
		this.NullCheck("Polish");
		method clstVe_Polish = CListView.__N.CLstVe_Polish;
		calli(System.Void(System.IntPtr), this.self, clstVe_Polish);
	}

	// Token: 0x0600011A RID: 282 RVA: 0x00004B7C File Offset: 0x00002D7C
	internal readonly string toolTip()
	{
		this.NullCheck("toolTip");
		method clstVe_toolTip = CListView.__N.CLstVe_toolTip;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, clstVe_toolTip));
	}

	// Token: 0x0600011B RID: 283 RVA: 0x00004BAC File Offset: 0x00002DAC
	internal readonly void setToolTip(string str)
	{
		this.NullCheck("setToolTip");
		method clstVe_setToolTip = CListView.__N.CLstVe_setToolTip;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), clstVe_setToolTip);
	}

	// Token: 0x0600011C RID: 284 RVA: 0x00004BDC File Offset: 0x00002DDC
	internal readonly string statusTip()
	{
		this.NullCheck("statusTip");
		method clstVe_statusTip = CListView.__N.CLstVe_statusTip;
		return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, clstVe_statusTip));
	}

	// Token: 0x0600011D RID: 285 RVA: 0x00004C0C File Offset: 0x00002E0C
	internal readonly void setStatusTip(string str)
	{
		this.NullCheck("setStatusTip");
		method clstVe_setStatusTip = CListView.__N.CLstVe_setStatusTip;
		calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), clstVe_setStatusTip);
	}

	// Token: 0x0600011E RID: 286 RVA: 0x00004C3C File Offset: 0x00002E3C
	internal readonly int toolTipDuration()
	{
		this.NullCheck("toolTipDuration");
		method clstVe_toolTipDuration = CListView.__N.CLstVe_toolTipDuration;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_toolTipDuration);
	}

	// Token: 0x0600011F RID: 287 RVA: 0x00004C68 File Offset: 0x00002E68
	internal readonly void setToolTipDuration(int x)
	{
		this.NullCheck("setToolTipDuration");
		method clstVe_setToolTipDuration = CListView.__N.CLstVe_setToolTipDuration;
		calli(System.Void(System.IntPtr,System.Int32), this.self, x, clstVe_setToolTipDuration);
	}

	// Token: 0x06000120 RID: 288 RVA: 0x00004C94 File Offset: 0x00002E94
	internal readonly bool autoFillBackground()
	{
		this.NullCheck("autoFillBackground");
		method clstVe_autoFillBackground = CListView.__N.CLstVe_autoFillBackground;
		return calli(System.Int32(System.IntPtr), this.self, clstVe_autoFillBackground) > 0;
	}

	// Token: 0x06000121 RID: 289 RVA: 0x00004CC4 File Offset: 0x00002EC4
	internal readonly void setAutoFillBackground(bool enabled)
	{
		this.NullCheck("setAutoFillBackground");
		method clstVe_setAutoFillBackground = CListView.__N.CLstVe_setAutoFillBackground;
		calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, clstVe_setAutoFillBackground);
	}

	// Token: 0x0400000F RID: 15
	internal IntPtr self;

	// Token: 0x020000E3 RID: 227
	internal static class __N
	{
		// Token: 0x04000521 RID: 1313
		internal static method From_QListView_To_CListView;

		// Token: 0x04000522 RID: 1314
		internal static method To_QListView_From_CListView;

		// Token: 0x04000523 RID: 1315
		internal static method From_QWidget_To_CListView;

		// Token: 0x04000524 RID: 1316
		internal static method To_QWidget_From_CListView;

		// Token: 0x04000525 RID: 1317
		internal static method From_QObject_To_CListView;

		// Token: 0x04000526 RID: 1318
		internal static method To_QObject_From_CListView;

		// Token: 0x04000527 RID: 1319
		internal static method CLstVe_Create;

		// Token: 0x04000528 RID: 1320
		internal static method CLstVe_setModelInternal;

		// Token: 0x04000529 RID: 1321
		internal static method CLstVe_setItemDelegate;

		// Token: 0x0400052A RID: 1322
		internal static method CLstVe_uniformItemSizes;

		// Token: 0x0400052B RID: 1323
		internal static method CLstVe_setUniformItemSizes;

		// Token: 0x0400052C RID: 1324
		internal static method CLstVe_setModelColumn;

		// Token: 0x0400052D RID: 1325
		internal static method CLstVe_modelColumn;

		// Token: 0x0400052E RID: 1326
		internal static method CLstVe_setWordWrap;

		// Token: 0x0400052F RID: 1327
		internal static method CLstVe_wordWrap;

		// Token: 0x04000530 RID: 1328
		internal static method CLstVe_setWrapping;

		// Token: 0x04000531 RID: 1329
		internal static method CLstVe_isWrapping;

		// Token: 0x04000532 RID: 1330
		internal static method CLstVe_setViewMode;

		// Token: 0x04000533 RID: 1331
		internal static method CLstVe_viewMode;

		// Token: 0x04000534 RID: 1332
		internal static method CLstVe_setLayoutMode;

		// Token: 0x04000535 RID: 1333
		internal static method CLstVe_layoutMode;

		// Token: 0x04000536 RID: 1334
		internal static method CLstVe_setFlow;

		// Token: 0x04000537 RID: 1335
		internal static method CLstVe_flow;

		// Token: 0x04000538 RID: 1336
		internal static method CLstVe_setMovement;

		// Token: 0x04000539 RID: 1337
		internal static method CLstVe_movement;

		// Token: 0x0400053A RID: 1338
		internal static method CLstVe_setResizeMode;

		// Token: 0x0400053B RID: 1339
		internal static method CLstVe_resizeMode;

		// Token: 0x0400053C RID: 1340
		internal static method CLstVe_setBatchSize;

		// Token: 0x0400053D RID: 1341
		internal static method CLstVe_batchSize;

		// Token: 0x0400053E RID: 1342
		internal static method CLstVe_setGridSize;

		// Token: 0x0400053F RID: 1343
		internal static method CLstVe_gridSize;

		// Token: 0x04000540 RID: 1344
		internal static method CLstVe_visualRect;

		// Token: 0x04000541 RID: 1345
		internal static method CLstVe_scrollTo;

		// Token: 0x04000542 RID: 1346
		internal static method CLstVe_indexAt;

		// Token: 0x04000543 RID: 1347
		internal static method CLstVe_setRootIndex;

		// Token: 0x04000544 RID: 1348
		internal static method CLstVe_rootIndex;

		// Token: 0x04000545 RID: 1349
		internal static method CLstVe_selectionModel;

		// Token: 0x04000546 RID: 1350
		internal static method CLstVe_isTopLevel;

		// Token: 0x04000547 RID: 1351
		internal static method CLstVe_isWindow;

		// Token: 0x04000548 RID: 1352
		internal static method CLstVe_isModal;

		// Token: 0x04000549 RID: 1353
		internal static method CLstVe_setStyleSheet;

		// Token: 0x0400054A RID: 1354
		internal static method CLstVe_windowTitle;

		// Token: 0x0400054B RID: 1355
		internal static method CLstVe_setWindowTitle;

		// Token: 0x0400054C RID: 1356
		internal static method CLstVe_setWindowFlags;

		// Token: 0x0400054D RID: 1357
		internal static method CLstVe_windowFlags;

		// Token: 0x0400054E RID: 1358
		internal static method CLstVe_size;

		// Token: 0x0400054F RID: 1359
		internal static method CLstVe_resize;

		// Token: 0x04000550 RID: 1360
		internal static method CLstVe_minimumSize;

		// Token: 0x04000551 RID: 1361
		internal static method CLstVe_setMinimumSize;

		// Token: 0x04000552 RID: 1362
		internal static method CLstVe_maximumSize;

		// Token: 0x04000553 RID: 1363
		internal static method CLstVe_setMaximumSize;

		// Token: 0x04000554 RID: 1364
		internal static method CLstVe_pos;

		// Token: 0x04000555 RID: 1365
		internal static method CLstVe_move;

		// Token: 0x04000556 RID: 1366
		internal static method CLstVe_isEnabled;

		// Token: 0x04000557 RID: 1367
		internal static method CLstVe_setEnabled;

		// Token: 0x04000558 RID: 1368
		internal static method CLstVe_setVisible;

		// Token: 0x04000559 RID: 1369
		internal static method CLstVe_setHidden;

		// Token: 0x0400055A RID: 1370
		internal static method CLstVe_show;

		// Token: 0x0400055B RID: 1371
		internal static method CLstVe_hide;

		// Token: 0x0400055C RID: 1372
		internal static method CLstVe_showMinimized;

		// Token: 0x0400055D RID: 1373
		internal static method CLstVe_showMaximized;

		// Token: 0x0400055E RID: 1374
		internal static method CLstVe_showFullScreen;

		// Token: 0x0400055F RID: 1375
		internal static method CLstVe_showNormal;

		// Token: 0x04000560 RID: 1376
		internal static method CLstVe_close;

		// Token: 0x04000561 RID: 1377
		internal static method CLstVe_raise;

		// Token: 0x04000562 RID: 1378
		internal static method CLstVe_lower;

		// Token: 0x04000563 RID: 1379
		internal static method CLstVe_isVisible;

		// Token: 0x04000564 RID: 1380
		internal static method CLstVe_setAttribute;

		// Token: 0x04000565 RID: 1381
		internal static method CLstVe_testAttribute;

		// Token: 0x04000566 RID: 1382
		internal static method CLstVe_acceptDrops;

		// Token: 0x04000567 RID: 1383
		internal static method CLstVe_setAcceptDrops;

		// Token: 0x04000568 RID: 1384
		internal static method CLstVe_update;

		// Token: 0x04000569 RID: 1385
		internal static method CLstVe_repaint;

		// Token: 0x0400056A RID: 1386
		internal static method CLstVe_setCursor;

		// Token: 0x0400056B RID: 1387
		internal static method CLstVe_unsetCursor;

		// Token: 0x0400056C RID: 1388
		internal static method CLstVe_setWindowIcon;

		// Token: 0x0400056D RID: 1389
		internal static method CLstVe_setWindowIconText;

		// Token: 0x0400056E RID: 1390
		internal static method CLstVe_setWindowOpacity;

		// Token: 0x0400056F RID: 1391
		internal static method CLstVe_windowOpacity;

		// Token: 0x04000570 RID: 1392
		internal static method CLstVe_isMinimized;

		// Token: 0x04000571 RID: 1393
		internal static method CLstVe_isMaximized;

		// Token: 0x04000572 RID: 1394
		internal static method CLstVe_isFullScreen;

		// Token: 0x04000573 RID: 1395
		internal static method CLstVe_setMouseTracking;

		// Token: 0x04000574 RID: 1396
		internal static method CLstVe_hasMouseTracking;

		// Token: 0x04000575 RID: 1397
		internal static method CLstVe_underMouse;

		// Token: 0x04000576 RID: 1398
		internal static method CLstVe_mapToGlobal;

		// Token: 0x04000577 RID: 1399
		internal static method CLstVe_mapFromGlobal;

		// Token: 0x04000578 RID: 1400
		internal static method CLstVe_hasFocus;

		// Token: 0x04000579 RID: 1401
		internal static method CLstVe_focusPolicy;

		// Token: 0x0400057A RID: 1402
		internal static method CLstVe_setFocusPolicy;

		// Token: 0x0400057B RID: 1403
		internal static method CLstVe_setFocusProxy;

		// Token: 0x0400057C RID: 1404
		internal static method CLstVe_isActiveWindow;

		// Token: 0x0400057D RID: 1405
		internal static method CLstVe_updatesEnabled;

		// Token: 0x0400057E RID: 1406
		internal static method CLstVe_setUpdatesEnabled;

		// Token: 0x0400057F RID: 1407
		internal static method CLstVe_setFocus;

		// Token: 0x04000580 RID: 1408
		internal static method CLstVe_activateWindow;

		// Token: 0x04000581 RID: 1409
		internal static method CLstVe_clearFocus;

		// Token: 0x04000582 RID: 1410
		internal static method CLstVe_setSizePolicy;

		// Token: 0x04000583 RID: 1411
		internal static method CLstVe_devicePixelRatioF;

		// Token: 0x04000584 RID: 1412
		internal static method CLstVe_saveGeometry;

		// Token: 0x04000585 RID: 1413
		internal static method CLstVe_restoreGeometry;

		// Token: 0x04000586 RID: 1414
		internal static method CLstVe_addAction;

		// Token: 0x04000587 RID: 1415
		internal static method CLstVe_removeAction;

		// Token: 0x04000588 RID: 1416
		internal static method CLstVe_setParent;

		// Token: 0x04000589 RID: 1417
		internal static method CLstVe_parentWidget;

		// Token: 0x0400058A RID: 1418
		internal static method CLstVe_AddClassName;

		// Token: 0x0400058B RID: 1419
		internal static method CLstVe_Polish;

		// Token: 0x0400058C RID: 1420
		internal static method CLstVe_toolTip;

		// Token: 0x0400058D RID: 1421
		internal static method CLstVe_setToolTip;

		// Token: 0x0400058E RID: 1422
		internal static method CLstVe_statusTip;

		// Token: 0x0400058F RID: 1423
		internal static method CLstVe_setStatusTip;

		// Token: 0x04000590 RID: 1424
		internal static method CLstVe_toolTipDuration;

		// Token: 0x04000591 RID: 1425
		internal static method CLstVe_setToolTipDuration;

		// Token: 0x04000592 RID: 1426
		internal static method CLstVe_autoFillBackground;

		// Token: 0x04000593 RID: 1427
		internal static method CLstVe_setAutoFillBackground;
	}
}
