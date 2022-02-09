using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000044 RID: 68
	internal struct QComboBox
	{
		// Token: 0x0600077E RID: 1918 RVA: 0x00014661 File Offset: 0x00012861
		public static implicit operator IntPtr(QComboBox value)
		{
			return value.self;
		}

		// Token: 0x0600077F RID: 1919 RVA: 0x0001466C File Offset: 0x0001286C
		public static implicit operator QComboBox(IntPtr value)
		{
			return new QComboBox
			{
				self = value
			};
		}

		// Token: 0x06000780 RID: 1920 RVA: 0x0001468A File Offset: 0x0001288A
		public static bool operator ==(QComboBox c1, QComboBox c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000781 RID: 1921 RVA: 0x0001469D File Offset: 0x0001289D
		public static bool operator !=(QComboBox c1, QComboBox c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x000146B0 File Offset: 0x000128B0
		public override bool Equals(object obj)
		{
			if (obj is QComboBox)
			{
				QComboBox c = (QComboBox)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x000146DA File Offset: 0x000128DA
		internal QComboBox(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x000146E4 File Offset: 0x000128E4
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QComboBox ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x06000785 RID: 1925 RVA: 0x00014720 File Offset: 0x00012920
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x00014732 File Offset: 0x00012932
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000787 RID: 1927 RVA: 0x0001473D File Offset: 0x0001293D
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000788 RID: 1928 RVA: 0x00014750 File Offset: 0x00012950
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QComboBox was null when calling " + n);
			}
		}

		// Token: 0x06000789 RID: 1929 RVA: 0x0001476B File Offset: 0x0001296B
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x00014778 File Offset: 0x00012978
		public static implicit operator QWidget(QComboBox value)
		{
			method to_QWidget_From_QComboBox = QComboBox.__N.To_QWidget_From_QComboBox;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QComboBox);
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0001479C File Offset: 0x0001299C
		public static explicit operator QComboBox(QWidget value)
		{
			method from_QWidget_To_QComboBox = QComboBox.__N.From_QWidget_To_QComboBox;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QComboBox);
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x000147C0 File Offset: 0x000129C0
		public static implicit operator QObject(QComboBox value)
		{
			method to_QObject_From_QComboBox = QComboBox.__N.To_QObject_From_QComboBox;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QComboBox);
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x000147E4 File Offset: 0x000129E4
		public static explicit operator QComboBox(QObject value)
		{
			method from_QObject_To_QComboBox = QComboBox.__N.From_QObject_To_QComboBox;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QComboBox);
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x00014808 File Offset: 0x00012A08
		internal readonly int maxVisibleItems()
		{
			this.NullCheck("maxVisibleItems");
			method qcmbBx_maxVisibleItems = QComboBox.__N.QCmbBx_maxVisibleItems;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_maxVisibleItems);
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x00014834 File Offset: 0x00012A34
		internal readonly void setMaxVisibleItems(int maxItems)
		{
			this.NullCheck("setMaxVisibleItems");
			method qcmbBx_setMaxVisibleItems = QComboBox.__N.QCmbBx_setMaxVisibleItems;
			calli(System.Void(System.IntPtr,System.Int32), this.self, maxItems, qcmbBx_setMaxVisibleItems);
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x00014860 File Offset: 0x00012A60
		internal readonly int count()
		{
			this.NullCheck("count");
			method qcmbBx_count = QComboBox.__N.QCmbBx_count;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_count);
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0001488C File Offset: 0x00012A8C
		internal readonly void setMaxCount(int max)
		{
			this.NullCheck("setMaxCount");
			method qcmbBx_setMaxCount = QComboBox.__N.QCmbBx_setMaxCount;
			calli(System.Void(System.IntPtr,System.Int32), this.self, max, qcmbBx_setMaxCount);
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x000148B8 File Offset: 0x00012AB8
		internal readonly int maxCount()
		{
			this.NullCheck("maxCount");
			method qcmbBx_maxCount = QComboBox.__N.QCmbBx_maxCount;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_maxCount);
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x000148E4 File Offset: 0x00012AE4
		internal readonly bool duplicatesEnabled()
		{
			this.NullCheck("duplicatesEnabled");
			method qcmbBx_duplicatesEnabled = QComboBox.__N.QCmbBx_duplicatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_duplicatesEnabled) > 0;
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x00014914 File Offset: 0x00012B14
		internal readonly void setDuplicatesEnabled(bool enable)
		{
			this.NullCheck("setDuplicatesEnabled");
			method qcmbBx_setDuplicatesEnabled = QComboBox.__N.QCmbBx_setDuplicatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qcmbBx_setDuplicatesEnabled);
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x00014948 File Offset: 0x00012B48
		internal readonly void setFrame(bool x)
		{
			this.NullCheck("setFrame");
			method qcmbBx_setFrame = QComboBox.__N.QCmbBx_setFrame;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qcmbBx_setFrame);
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0001497C File Offset: 0x00012B7C
		internal readonly bool hasFrame()
		{
			this.NullCheck("hasFrame");
			method qcmbBx_hasFrame = QComboBox.__N.QCmbBx_hasFrame;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_hasFrame) > 0;
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x000149AC File Offset: 0x00012BAC
		internal readonly ComboBox.InsertMode insertPolicy()
		{
			this.NullCheck("insertPolicy");
			method qcmbBx_insertPolicy = QComboBox.__N.QCmbBx_insertPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qcmbBx_insertPolicy);
		}

		// Token: 0x06000798 RID: 1944 RVA: 0x000149D8 File Offset: 0x00012BD8
		internal readonly void setInsertPolicy(ComboBox.InsertMode policy)
		{
			this.NullCheck("setInsertPolicy");
			method qcmbBx_setInsertPolicy = QComboBox.__N.QCmbBx_setInsertPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qcmbBx_setInsertPolicy);
		}

		// Token: 0x06000799 RID: 1945 RVA: 0x00014A04 File Offset: 0x00012C04
		internal readonly int minimumContentsLength()
		{
			this.NullCheck("minimumContentsLength");
			method qcmbBx_minimumContentsLength = QComboBox.__N.QCmbBx_minimumContentsLength;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_minimumContentsLength);
		}

		// Token: 0x0600079A RID: 1946 RVA: 0x00014A30 File Offset: 0x00012C30
		internal readonly void setMinimumContentsLength(int characters)
		{
			this.NullCheck("setMinimumContentsLength");
			method qcmbBx_setMinimumContentsLength = QComboBox.__N.QCmbBx_setMinimumContentsLength;
			calli(System.Void(System.IntPtr,System.Int32), this.self, characters, qcmbBx_setMinimumContentsLength);
		}

		// Token: 0x0600079B RID: 1947 RVA: 0x00014A5C File Offset: 0x00012C5C
		internal readonly Vector3 iconSize()
		{
			this.NullCheck("iconSize");
			method qcmbBx_iconSize = QComboBox.__N.QCmbBx_iconSize;
			return calli(Vector3(System.IntPtr), this.self, qcmbBx_iconSize);
		}

		// Token: 0x0600079C RID: 1948 RVA: 0x00014A88 File Offset: 0x00012C88
		internal readonly void setIconSize(Vector3 size)
		{
			this.NullCheck("setIconSize");
			method qcmbBx_setIconSize = QComboBox.__N.QCmbBx_setIconSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, size, qcmbBx_setIconSize);
		}

		// Token: 0x0600079D RID: 1949 RVA: 0x00014AB4 File Offset: 0x00012CB4
		internal readonly bool isEditable()
		{
			this.NullCheck("isEditable");
			method qcmbBx_isEditable = QComboBox.__N.QCmbBx_isEditable;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_isEditable) > 0;
		}

		// Token: 0x0600079E RID: 1950 RVA: 0x00014AE4 File Offset: 0x00012CE4
		internal readonly void setEditable(bool editable)
		{
			this.NullCheck("setEditable");
			method qcmbBx_setEditable = QComboBox.__N.QCmbBx_setEditable;
			calli(System.Void(System.IntPtr,System.Int32), this.self, editable ? 1 : 0, qcmbBx_setEditable);
		}

		// Token: 0x0600079F RID: 1951 RVA: 0x00014B18 File Offset: 0x00012D18
		internal readonly void setLineEdit(QLineEdit edit)
		{
			this.NullCheck("setLineEdit");
			method qcmbBx_setLineEdit = QComboBox.__N.QCmbBx_setLineEdit;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, edit, qcmbBx_setLineEdit);
		}

		// Token: 0x060007A0 RID: 1952 RVA: 0x00014B48 File Offset: 0x00012D48
		internal readonly QLineEdit lineEdit()
		{
			this.NullCheck("lineEdit");
			method qcmbBx_lineEdit = QComboBox.__N.QCmbBx_lineEdit;
			return calli(System.IntPtr(System.IntPtr), this.self, qcmbBx_lineEdit);
		}

		// Token: 0x060007A1 RID: 1953 RVA: 0x00014B78 File Offset: 0x00012D78
		internal readonly int modelColumn()
		{
			this.NullCheck("modelColumn");
			method qcmbBx_modelColumn = QComboBox.__N.QCmbBx_modelColumn;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_modelColumn);
		}

		// Token: 0x060007A2 RID: 1954 RVA: 0x00014BA4 File Offset: 0x00012DA4
		internal readonly void setModelColumn(int visibleColumn)
		{
			this.NullCheck("setModelColumn");
			method qcmbBx_setModelColumn = QComboBox.__N.QCmbBx_setModelColumn;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visibleColumn, qcmbBx_setModelColumn);
		}

		// Token: 0x060007A3 RID: 1955 RVA: 0x00014BD0 File Offset: 0x00012DD0
		internal readonly int currentIndex()
		{
			this.NullCheck("currentIndex");
			method qcmbBx_currentIndex = QComboBox.__N.QCmbBx_currentIndex;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_currentIndex);
		}

		// Token: 0x060007A4 RID: 1956 RVA: 0x00014BFC File Offset: 0x00012DFC
		internal readonly string currentText()
		{
			this.NullCheck("currentText");
			method qcmbBx_currentText = QComboBox.__N.QCmbBx_currentText;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qcmbBx_currentText));
		}

		// Token: 0x060007A5 RID: 1957 RVA: 0x00014C2C File Offset: 0x00012E2C
		internal readonly string itemText(int index)
		{
			this.NullCheck("itemText");
			method qcmbBx_itemText = QComboBox.__N.QCmbBx_itemText;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr,System.Int32), this.self, index, qcmbBx_itemText));
		}

		// Token: 0x060007A6 RID: 1958 RVA: 0x00014C5C File Offset: 0x00012E5C
		internal readonly void addItem(string text)
		{
			this.NullCheck("addItem");
			method qcmbBx_addItem = QComboBox.__N.QCmbBx_addItem;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qcmbBx_addItem);
		}

		// Token: 0x060007A7 RID: 1959 RVA: 0x00014C8C File Offset: 0x00012E8C
		internal readonly void addItem(string icon, string text)
		{
			this.NullCheck("addItem");
			method qcmbBx_f = QComboBox.__N.QCmbBx_f2;
			calli(System.Void(System.IntPtr,System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), Interop.GetWPointer(text), qcmbBx_f);
		}

		// Token: 0x060007A8 RID: 1960 RVA: 0x00014CC4 File Offset: 0x00012EC4
		internal readonly void removeItem(int index)
		{
			this.NullCheck("removeItem");
			method qcmbBx_removeItem = QComboBox.__N.QCmbBx_removeItem;
			calli(System.Void(System.IntPtr,System.Int32), this.self, index, qcmbBx_removeItem);
		}

		// Token: 0x060007A9 RID: 1961 RVA: 0x00014CF0 File Offset: 0x00012EF0
		internal readonly void setItemText(int index, string text)
		{
			this.NullCheck("setItemText");
			method qcmbBx_setItemText = QComboBox.__N.QCmbBx_setItemText;
			calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), this.self, index, Interop.GetWPointer(text), qcmbBx_setItemText);
		}

		// Token: 0x060007AA RID: 1962 RVA: 0x00014D24 File Offset: 0x00012F24
		internal readonly void setItemIcon(int index, string icon)
		{
			this.NullCheck("setItemIcon");
			method qcmbBx_setItemIcon = QComboBox.__N.QCmbBx_setItemIcon;
			calli(System.Void(System.IntPtr,System.Int32,System.IntPtr), this.self, index, Interop.GetPointer(icon), qcmbBx_setItemIcon);
		}

		// Token: 0x060007AB RID: 1963 RVA: 0x00014D58 File Offset: 0x00012F58
		internal readonly void showPopup()
		{
			this.NullCheck("showPopup");
			method qcmbBx_showPopup = QComboBox.__N.QCmbBx_showPopup;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_showPopup);
		}

		// Token: 0x060007AC RID: 1964 RVA: 0x00014D84 File Offset: 0x00012F84
		internal readonly void hidePopup()
		{
			this.NullCheck("hidePopup");
			method qcmbBx_hidePopup = QComboBox.__N.QCmbBx_hidePopup;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_hidePopup);
		}

		// Token: 0x060007AD RID: 1965 RVA: 0x00014DB0 File Offset: 0x00012FB0
		internal readonly void clear()
		{
			this.NullCheck("clear");
			method qcmbBx_clear = QComboBox.__N.QCmbBx_clear;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_clear);
		}

		// Token: 0x060007AE RID: 1966 RVA: 0x00014DDC File Offset: 0x00012FDC
		internal readonly void clearEditText()
		{
			this.NullCheck("clearEditText");
			method qcmbBx_clearEditText = QComboBox.__N.QCmbBx_clearEditText;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_clearEditText);
		}

		// Token: 0x060007AF RID: 1967 RVA: 0x00014E08 File Offset: 0x00013008
		internal readonly void setEditText(string text)
		{
			this.NullCheck("setEditText");
			method qcmbBx_setEditText = QComboBox.__N.QCmbBx_setEditText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qcmbBx_setEditText);
		}

		// Token: 0x060007B0 RID: 1968 RVA: 0x00014E38 File Offset: 0x00013038
		internal readonly void setCurrentIndex(int index)
		{
			this.NullCheck("setCurrentIndex");
			method qcmbBx_setCurrentIndex = QComboBox.__N.QCmbBx_setCurrentIndex;
			calli(System.Void(System.IntPtr,System.Int32), this.self, index, qcmbBx_setCurrentIndex);
		}

		// Token: 0x060007B1 RID: 1969 RVA: 0x00014E64 File Offset: 0x00013064
		internal readonly void setCurrentText(string text)
		{
			this.NullCheck("setCurrentText");
			method qcmbBx_setCurrentText = QComboBox.__N.QCmbBx_setCurrentText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qcmbBx_setCurrentText);
		}

		// Token: 0x060007B2 RID: 1970 RVA: 0x00014E94 File Offset: 0x00013094
		internal readonly int findText(string text)
		{
			this.NullCheck("findText");
			method qcmbBx_findText = QComboBox.__N.QCmbBx_findText;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(text), qcmbBx_findText);
		}

		// Token: 0x060007B3 RID: 1971 RVA: 0x00014EC4 File Offset: 0x000130C4
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qcmbBx_isTopLevel = QComboBox.__N.QCmbBx_isTopLevel;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_isTopLevel) > 0;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x00014EF4 File Offset: 0x000130F4
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qcmbBx_isWindow = QComboBox.__N.QCmbBx_isWindow;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_isWindow) > 0;
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x00014F24 File Offset: 0x00013124
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qcmbBx_isModal = QComboBox.__N.QCmbBx_isModal;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_isModal) > 0;
		}

		// Token: 0x060007B6 RID: 1974 RVA: 0x00014F54 File Offset: 0x00013154
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qcmbBx_setStyleSheet = QComboBox.__N.QCmbBx_setStyleSheet;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qcmbBx_setStyleSheet);
		}

		// Token: 0x060007B7 RID: 1975 RVA: 0x00014F84 File Offset: 0x00013184
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qcmbBx_windowTitle = QComboBox.__N.QCmbBx_windowTitle;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qcmbBx_windowTitle));
		}

		// Token: 0x060007B8 RID: 1976 RVA: 0x00014FB4 File Offset: 0x000131B4
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qcmbBx_setWindowTitle = QComboBox.__N.QCmbBx_setWindowTitle;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qcmbBx_setWindowTitle);
		}

		// Token: 0x060007B9 RID: 1977 RVA: 0x00014FE4 File Offset: 0x000131E4
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qcmbBx_setWindowFlags = QComboBox.__N.QCmbBx_setWindowFlags;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qcmbBx_setWindowFlags);
		}

		// Token: 0x060007BA RID: 1978 RVA: 0x00015010 File Offset: 0x00013210
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qcmbBx_windowFlags = QComboBox.__N.QCmbBx_windowFlags;
			return calli(System.Int64(System.IntPtr), this.self, qcmbBx_windowFlags);
		}

		// Token: 0x060007BB RID: 1979 RVA: 0x0001503C File Offset: 0x0001323C
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qcmbBx_size = QComboBox.__N.QCmbBx_size;
			return calli(Vector3(System.IntPtr), this.self, qcmbBx_size);
		}

		// Token: 0x060007BC RID: 1980 RVA: 0x00015068 File Offset: 0x00013268
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qcmbBx_resize = QComboBox.__N.QCmbBx_resize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qcmbBx_resize);
		}

		// Token: 0x060007BD RID: 1981 RVA: 0x00015094 File Offset: 0x00013294
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qcmbBx_minimumSize = QComboBox.__N.QCmbBx_minimumSize;
			return calli(Vector3(System.IntPtr), this.self, qcmbBx_minimumSize);
		}

		// Token: 0x060007BE RID: 1982 RVA: 0x000150C0 File Offset: 0x000132C0
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qcmbBx_setMinimumSize = QComboBox.__N.QCmbBx_setMinimumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qcmbBx_setMinimumSize);
		}

		// Token: 0x060007BF RID: 1983 RVA: 0x000150EC File Offset: 0x000132EC
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qcmbBx_maximumSize = QComboBox.__N.QCmbBx_maximumSize;
			return calli(Vector3(System.IntPtr), this.self, qcmbBx_maximumSize);
		}

		// Token: 0x060007C0 RID: 1984 RVA: 0x00015118 File Offset: 0x00013318
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qcmbBx_setMaximumSize = QComboBox.__N.QCmbBx_setMaximumSize;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qcmbBx_setMaximumSize);
		}

		// Token: 0x060007C1 RID: 1985 RVA: 0x00015144 File Offset: 0x00013344
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qcmbBx_pos = QComboBox.__N.QCmbBx_pos;
			return calli(Vector3(System.IntPtr), this.self, qcmbBx_pos);
		}

		// Token: 0x060007C2 RID: 1986 RVA: 0x00015170 File Offset: 0x00013370
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qcmbBx_move = QComboBox.__N.QCmbBx_move;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qcmbBx_move);
		}

		// Token: 0x060007C3 RID: 1987 RVA: 0x0001519C File Offset: 0x0001339C
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qcmbBx_isEnabled = QComboBox.__N.QCmbBx_isEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_isEnabled) > 0;
		}

		// Token: 0x060007C4 RID: 1988 RVA: 0x000151CC File Offset: 0x000133CC
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qcmbBx_setEnabled = QComboBox.__N.QCmbBx_setEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qcmbBx_setEnabled);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x00015200 File Offset: 0x00013400
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qcmbBx_setVisible = QComboBox.__N.QCmbBx_setVisible;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qcmbBx_setVisible);
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00015234 File Offset: 0x00013434
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qcmbBx_setHidden = QComboBox.__N.QCmbBx_setHidden;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qcmbBx_setHidden);
		}

		// Token: 0x060007C7 RID: 1991 RVA: 0x00015268 File Offset: 0x00013468
		internal readonly void show()
		{
			this.NullCheck("show");
			method qcmbBx_show = QComboBox.__N.QCmbBx_show;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_show);
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x00015294 File Offset: 0x00013494
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qcmbBx_hide = QComboBox.__N.QCmbBx_hide;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_hide);
		}

		// Token: 0x060007C9 RID: 1993 RVA: 0x000152C0 File Offset: 0x000134C0
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qcmbBx_showMinimized = QComboBox.__N.QCmbBx_showMinimized;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_showMinimized);
		}

		// Token: 0x060007CA RID: 1994 RVA: 0x000152EC File Offset: 0x000134EC
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qcmbBx_showMaximized = QComboBox.__N.QCmbBx_showMaximized;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_showMaximized);
		}

		// Token: 0x060007CB RID: 1995 RVA: 0x00015318 File Offset: 0x00013518
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qcmbBx_showFullScreen = QComboBox.__N.QCmbBx_showFullScreen;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_showFullScreen);
		}

		// Token: 0x060007CC RID: 1996 RVA: 0x00015344 File Offset: 0x00013544
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qcmbBx_showNormal = QComboBox.__N.QCmbBx_showNormal;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_showNormal);
		}

		// Token: 0x060007CD RID: 1997 RVA: 0x00015370 File Offset: 0x00013570
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qcmbBx_close = QComboBox.__N.QCmbBx_close;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_close) > 0;
		}

		// Token: 0x060007CE RID: 1998 RVA: 0x000153A0 File Offset: 0x000135A0
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qcmbBx_raise = QComboBox.__N.QCmbBx_raise;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_raise);
		}

		// Token: 0x060007CF RID: 1999 RVA: 0x000153CC File Offset: 0x000135CC
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qcmbBx_lower = QComboBox.__N.QCmbBx_lower;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_lower);
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x000153F8 File Offset: 0x000135F8
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qcmbBx_isVisible = QComboBox.__N.QCmbBx_isVisible;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_isVisible) > 0;
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x00015428 File Offset: 0x00013628
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qcmbBx_setAttribute = QComboBox.__N.QCmbBx_setAttribute;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qcmbBx_setAttribute);
		}

		// Token: 0x060007D2 RID: 2002 RVA: 0x0001545C File Offset: 0x0001365C
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qcmbBx_testAttribute = QComboBox.__N.QCmbBx_testAttribute;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qcmbBx_testAttribute) > 0;
		}

		// Token: 0x060007D3 RID: 2003 RVA: 0x0001548C File Offset: 0x0001368C
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qcmbBx_acceptDrops = QComboBox.__N.QCmbBx_acceptDrops;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_acceptDrops) > 0;
		}

		// Token: 0x060007D4 RID: 2004 RVA: 0x000154BC File Offset: 0x000136BC
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qcmbBx_setAcceptDrops = QComboBox.__N.QCmbBx_setAcceptDrops;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qcmbBx_setAcceptDrops);
		}

		// Token: 0x060007D5 RID: 2005 RVA: 0x000154F0 File Offset: 0x000136F0
		internal readonly void update()
		{
			this.NullCheck("update");
			method qcmbBx_update = QComboBox.__N.QCmbBx_update;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_update);
		}

		// Token: 0x060007D6 RID: 2006 RVA: 0x0001551C File Offset: 0x0001371C
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qcmbBx_repaint = QComboBox.__N.QCmbBx_repaint;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_repaint);
		}

		// Token: 0x060007D7 RID: 2007 RVA: 0x00015548 File Offset: 0x00013748
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qcmbBx_setCursor = QComboBox.__N.QCmbBx_setCursor;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qcmbBx_setCursor);
		}

		// Token: 0x060007D8 RID: 2008 RVA: 0x00015574 File Offset: 0x00013774
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qcmbBx_unsetCursor = QComboBox.__N.QCmbBx_unsetCursor;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_unsetCursor);
		}

		// Token: 0x060007D9 RID: 2009 RVA: 0x000155A0 File Offset: 0x000137A0
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qcmbBx_setWindowIcon = QComboBox.__N.QCmbBx_setWindowIcon;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qcmbBx_setWindowIcon);
		}

		// Token: 0x060007DA RID: 2010 RVA: 0x000155D0 File Offset: 0x000137D0
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qcmbBx_setWindowIconText = QComboBox.__N.QCmbBx_setWindowIconText;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qcmbBx_setWindowIconText);
		}

		// Token: 0x060007DB RID: 2011 RVA: 0x00015600 File Offset: 0x00013800
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qcmbBx_setWindowOpacity = QComboBox.__N.QCmbBx_setWindowOpacity;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qcmbBx_setWindowOpacity);
		}

		// Token: 0x060007DC RID: 2012 RVA: 0x0001562C File Offset: 0x0001382C
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qcmbBx_windowOpacity = QComboBox.__N.QCmbBx_windowOpacity;
			return calli(System.Single(System.IntPtr), this.self, qcmbBx_windowOpacity);
		}

		// Token: 0x060007DD RID: 2013 RVA: 0x00015658 File Offset: 0x00013858
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qcmbBx_isMinimized = QComboBox.__N.QCmbBx_isMinimized;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_isMinimized) > 0;
		}

		// Token: 0x060007DE RID: 2014 RVA: 0x00015688 File Offset: 0x00013888
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qcmbBx_isMaximized = QComboBox.__N.QCmbBx_isMaximized;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_isMaximized) > 0;
		}

		// Token: 0x060007DF RID: 2015 RVA: 0x000156B8 File Offset: 0x000138B8
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qcmbBx_isFullScreen = QComboBox.__N.QCmbBx_isFullScreen;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_isFullScreen) > 0;
		}

		// Token: 0x060007E0 RID: 2016 RVA: 0x000156E8 File Offset: 0x000138E8
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qcmbBx_setMouseTracking = QComboBox.__N.QCmbBx_setMouseTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qcmbBx_setMouseTracking);
		}

		// Token: 0x060007E1 RID: 2017 RVA: 0x0001571C File Offset: 0x0001391C
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qcmbBx_hasMouseTracking = QComboBox.__N.QCmbBx_hasMouseTracking;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_hasMouseTracking) > 0;
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x0001574C File Offset: 0x0001394C
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qcmbBx_underMouse = QComboBox.__N.QCmbBx_underMouse;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_underMouse) > 0;
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x0001577C File Offset: 0x0001397C
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qcmbBx_mapToGlobal = QComboBox.__N.QCmbBx_mapToGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qcmbBx_mapToGlobal);
		}

		// Token: 0x060007E4 RID: 2020 RVA: 0x000157A8 File Offset: 0x000139A8
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qcmbBx_mapFromGlobal = QComboBox.__N.QCmbBx_mapFromGlobal;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qcmbBx_mapFromGlobal);
		}

		// Token: 0x060007E5 RID: 2021 RVA: 0x000157D4 File Offset: 0x000139D4
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qcmbBx_hasFocus = QComboBox.__N.QCmbBx_hasFocus;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_hasFocus) > 0;
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00015804 File Offset: 0x00013A04
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qcmbBx_focusPolicy = QComboBox.__N.QCmbBx_focusPolicy;
			return calli(System.Int64(System.IntPtr), this.self, qcmbBx_focusPolicy);
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x00015830 File Offset: 0x00013A30
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qcmbBx_setFocusPolicy = QComboBox.__N.QCmbBx_setFocusPolicy;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qcmbBx_setFocusPolicy);
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x0001585C File Offset: 0x00013A5C
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qcmbBx_setFocusProxy = QComboBox.__N.QCmbBx_setFocusProxy;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qcmbBx_setFocusProxy);
		}

		// Token: 0x060007E9 RID: 2025 RVA: 0x0001588C File Offset: 0x00013A8C
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qcmbBx_isActiveWindow = QComboBox.__N.QCmbBx_isActiveWindow;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_isActiveWindow) > 0;
		}

		// Token: 0x060007EA RID: 2026 RVA: 0x000158BC File Offset: 0x00013ABC
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qcmbBx_updatesEnabled = QComboBox.__N.QCmbBx_updatesEnabled;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_updatesEnabled) > 0;
		}

		// Token: 0x060007EB RID: 2027 RVA: 0x000158EC File Offset: 0x00013AEC
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qcmbBx_setUpdatesEnabled = QComboBox.__N.QCmbBx_setUpdatesEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qcmbBx_setUpdatesEnabled);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x00015920 File Offset: 0x00013B20
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qcmbBx_setFocus = QComboBox.__N.QCmbBx_setFocus;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_setFocus);
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x0001594C File Offset: 0x00013B4C
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qcmbBx_activateWindow = QComboBox.__N.QCmbBx_activateWindow;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_activateWindow);
		}

		// Token: 0x060007EE RID: 2030 RVA: 0x00015978 File Offset: 0x00013B78
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qcmbBx_clearFocus = QComboBox.__N.QCmbBx_clearFocus;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_clearFocus);
		}

		// Token: 0x060007EF RID: 2031 RVA: 0x000159A4 File Offset: 0x00013BA4
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qcmbBx_setSizePolicy = QComboBox.__N.QCmbBx_setSizePolicy;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qcmbBx_setSizePolicy);
		}

		// Token: 0x060007F0 RID: 2032 RVA: 0x000159D4 File Offset: 0x00013BD4
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qcmbBx_devicePixelRatioF = QComboBox.__N.QCmbBx_devicePixelRatioF;
			return calli(System.Single(System.IntPtr), this.self, qcmbBx_devicePixelRatioF);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x00015A00 File Offset: 0x00013C00
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qcmbBx_saveGeometry = QComboBox.__N.QCmbBx_saveGeometry;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qcmbBx_saveGeometry));
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x00015A30 File Offset: 0x00013C30
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qcmbBx_restoreGeometry = QComboBox.__N.QCmbBx_restoreGeometry;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qcmbBx_restoreGeometry) > 0;
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x00015A64 File Offset: 0x00013C64
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qcmbBx_addAction = QComboBox.__N.QCmbBx_addAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qcmbBx_addAction);
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00015A94 File Offset: 0x00013C94
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qcmbBx_removeAction = QComboBox.__N.QCmbBx_removeAction;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qcmbBx_removeAction);
		}

		// Token: 0x060007F5 RID: 2037 RVA: 0x00015AC4 File Offset: 0x00013CC4
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qcmbBx_setParent = QComboBox.__N.QCmbBx_setParent;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qcmbBx_setParent);
		}

		// Token: 0x060007F6 RID: 2038 RVA: 0x00015AF4 File Offset: 0x00013CF4
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qcmbBx_parentWidget = QComboBox.__N.QCmbBx_parentWidget;
			return calli(System.IntPtr(System.IntPtr), this.self, qcmbBx_parentWidget);
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x00015B24 File Offset: 0x00013D24
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qcmbBx_AddClassName = QComboBox.__N.QCmbBx_AddClassName;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qcmbBx_AddClassName);
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x00015B54 File Offset: 0x00013D54
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qcmbBx_Polish = QComboBox.__N.QCmbBx_Polish;
			calli(System.Void(System.IntPtr), this.self, qcmbBx_Polish);
		}

		// Token: 0x060007F9 RID: 2041 RVA: 0x00015B80 File Offset: 0x00013D80
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qcmbBx_toolTip = QComboBox.__N.QCmbBx_toolTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qcmbBx_toolTip));
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x00015BB0 File Offset: 0x00013DB0
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qcmbBx_setToolTip = QComboBox.__N.QCmbBx_setToolTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qcmbBx_setToolTip);
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x00015BE0 File Offset: 0x00013DE0
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qcmbBx_statusTip = QComboBox.__N.QCmbBx_statusTip;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qcmbBx_statusTip));
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x00015C10 File Offset: 0x00013E10
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qcmbBx_setStatusTip = QComboBox.__N.QCmbBx_setStatusTip;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qcmbBx_setStatusTip);
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x00015C40 File Offset: 0x00013E40
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qcmbBx_toolTipDuration = QComboBox.__N.QCmbBx_toolTipDuration;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_toolTipDuration);
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x00015C6C File Offset: 0x00013E6C
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qcmbBx_setToolTipDuration = QComboBox.__N.QCmbBx_setToolTipDuration;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qcmbBx_setToolTipDuration);
		}

		// Token: 0x060007FF RID: 2047 RVA: 0x00015C98 File Offset: 0x00013E98
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qcmbBx_autoFillBackground = QComboBox.__N.QCmbBx_autoFillBackground;
			return calli(System.Int32(System.IntPtr), this.self, qcmbBx_autoFillBackground) > 0;
		}

		// Token: 0x06000800 RID: 2048 RVA: 0x00015CC8 File Offset: 0x00013EC8
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qcmbBx_setAutoFillBackground = QComboBox.__N.QCmbBx_setAutoFillBackground;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qcmbBx_setAutoFillBackground);
		}

		// Token: 0x0400004F RID: 79
		internal IntPtr self;

		// Token: 0x02000110 RID: 272
		internal static class __N
		{
			// Token: 0x04000A14 RID: 2580
			internal static method From_QWidget_To_QComboBox;

			// Token: 0x04000A15 RID: 2581
			internal static method To_QWidget_From_QComboBox;

			// Token: 0x04000A16 RID: 2582
			internal static method From_QObject_To_QComboBox;

			// Token: 0x04000A17 RID: 2583
			internal static method To_QObject_From_QComboBox;

			// Token: 0x04000A18 RID: 2584
			internal static method QCmbBx_maxVisibleItems;

			// Token: 0x04000A19 RID: 2585
			internal static method QCmbBx_setMaxVisibleItems;

			// Token: 0x04000A1A RID: 2586
			internal static method QCmbBx_count;

			// Token: 0x04000A1B RID: 2587
			internal static method QCmbBx_setMaxCount;

			// Token: 0x04000A1C RID: 2588
			internal static method QCmbBx_maxCount;

			// Token: 0x04000A1D RID: 2589
			internal static method QCmbBx_duplicatesEnabled;

			// Token: 0x04000A1E RID: 2590
			internal static method QCmbBx_setDuplicatesEnabled;

			// Token: 0x04000A1F RID: 2591
			internal static method QCmbBx_setFrame;

			// Token: 0x04000A20 RID: 2592
			internal static method QCmbBx_hasFrame;

			// Token: 0x04000A21 RID: 2593
			internal static method QCmbBx_insertPolicy;

			// Token: 0x04000A22 RID: 2594
			internal static method QCmbBx_setInsertPolicy;

			// Token: 0x04000A23 RID: 2595
			internal static method QCmbBx_minimumContentsLength;

			// Token: 0x04000A24 RID: 2596
			internal static method QCmbBx_setMinimumContentsLength;

			// Token: 0x04000A25 RID: 2597
			internal static method QCmbBx_iconSize;

			// Token: 0x04000A26 RID: 2598
			internal static method QCmbBx_setIconSize;

			// Token: 0x04000A27 RID: 2599
			internal static method QCmbBx_isEditable;

			// Token: 0x04000A28 RID: 2600
			internal static method QCmbBx_setEditable;

			// Token: 0x04000A29 RID: 2601
			internal static method QCmbBx_setLineEdit;

			// Token: 0x04000A2A RID: 2602
			internal static method QCmbBx_lineEdit;

			// Token: 0x04000A2B RID: 2603
			internal static method QCmbBx_modelColumn;

			// Token: 0x04000A2C RID: 2604
			internal static method QCmbBx_setModelColumn;

			// Token: 0x04000A2D RID: 2605
			internal static method QCmbBx_currentIndex;

			// Token: 0x04000A2E RID: 2606
			internal static method QCmbBx_currentText;

			// Token: 0x04000A2F RID: 2607
			internal static method QCmbBx_itemText;

			// Token: 0x04000A30 RID: 2608
			internal static method QCmbBx_addItem;

			// Token: 0x04000A31 RID: 2609
			internal static method QCmbBx_f2;

			// Token: 0x04000A32 RID: 2610
			internal static method QCmbBx_removeItem;

			// Token: 0x04000A33 RID: 2611
			internal static method QCmbBx_setItemText;

			// Token: 0x04000A34 RID: 2612
			internal static method QCmbBx_setItemIcon;

			// Token: 0x04000A35 RID: 2613
			internal static method QCmbBx_showPopup;

			// Token: 0x04000A36 RID: 2614
			internal static method QCmbBx_hidePopup;

			// Token: 0x04000A37 RID: 2615
			internal static method QCmbBx_clear;

			// Token: 0x04000A38 RID: 2616
			internal static method QCmbBx_clearEditText;

			// Token: 0x04000A39 RID: 2617
			internal static method QCmbBx_setEditText;

			// Token: 0x04000A3A RID: 2618
			internal static method QCmbBx_setCurrentIndex;

			// Token: 0x04000A3B RID: 2619
			internal static method QCmbBx_setCurrentText;

			// Token: 0x04000A3C RID: 2620
			internal static method QCmbBx_findText;

			// Token: 0x04000A3D RID: 2621
			internal static method QCmbBx_isTopLevel;

			// Token: 0x04000A3E RID: 2622
			internal static method QCmbBx_isWindow;

			// Token: 0x04000A3F RID: 2623
			internal static method QCmbBx_isModal;

			// Token: 0x04000A40 RID: 2624
			internal static method QCmbBx_setStyleSheet;

			// Token: 0x04000A41 RID: 2625
			internal static method QCmbBx_windowTitle;

			// Token: 0x04000A42 RID: 2626
			internal static method QCmbBx_setWindowTitle;

			// Token: 0x04000A43 RID: 2627
			internal static method QCmbBx_setWindowFlags;

			// Token: 0x04000A44 RID: 2628
			internal static method QCmbBx_windowFlags;

			// Token: 0x04000A45 RID: 2629
			internal static method QCmbBx_size;

			// Token: 0x04000A46 RID: 2630
			internal static method QCmbBx_resize;

			// Token: 0x04000A47 RID: 2631
			internal static method QCmbBx_minimumSize;

			// Token: 0x04000A48 RID: 2632
			internal static method QCmbBx_setMinimumSize;

			// Token: 0x04000A49 RID: 2633
			internal static method QCmbBx_maximumSize;

			// Token: 0x04000A4A RID: 2634
			internal static method QCmbBx_setMaximumSize;

			// Token: 0x04000A4B RID: 2635
			internal static method QCmbBx_pos;

			// Token: 0x04000A4C RID: 2636
			internal static method QCmbBx_move;

			// Token: 0x04000A4D RID: 2637
			internal static method QCmbBx_isEnabled;

			// Token: 0x04000A4E RID: 2638
			internal static method QCmbBx_setEnabled;

			// Token: 0x04000A4F RID: 2639
			internal static method QCmbBx_setVisible;

			// Token: 0x04000A50 RID: 2640
			internal static method QCmbBx_setHidden;

			// Token: 0x04000A51 RID: 2641
			internal static method QCmbBx_show;

			// Token: 0x04000A52 RID: 2642
			internal static method QCmbBx_hide;

			// Token: 0x04000A53 RID: 2643
			internal static method QCmbBx_showMinimized;

			// Token: 0x04000A54 RID: 2644
			internal static method QCmbBx_showMaximized;

			// Token: 0x04000A55 RID: 2645
			internal static method QCmbBx_showFullScreen;

			// Token: 0x04000A56 RID: 2646
			internal static method QCmbBx_showNormal;

			// Token: 0x04000A57 RID: 2647
			internal static method QCmbBx_close;

			// Token: 0x04000A58 RID: 2648
			internal static method QCmbBx_raise;

			// Token: 0x04000A59 RID: 2649
			internal static method QCmbBx_lower;

			// Token: 0x04000A5A RID: 2650
			internal static method QCmbBx_isVisible;

			// Token: 0x04000A5B RID: 2651
			internal static method QCmbBx_setAttribute;

			// Token: 0x04000A5C RID: 2652
			internal static method QCmbBx_testAttribute;

			// Token: 0x04000A5D RID: 2653
			internal static method QCmbBx_acceptDrops;

			// Token: 0x04000A5E RID: 2654
			internal static method QCmbBx_setAcceptDrops;

			// Token: 0x04000A5F RID: 2655
			internal static method QCmbBx_update;

			// Token: 0x04000A60 RID: 2656
			internal static method QCmbBx_repaint;

			// Token: 0x04000A61 RID: 2657
			internal static method QCmbBx_setCursor;

			// Token: 0x04000A62 RID: 2658
			internal static method QCmbBx_unsetCursor;

			// Token: 0x04000A63 RID: 2659
			internal static method QCmbBx_setWindowIcon;

			// Token: 0x04000A64 RID: 2660
			internal static method QCmbBx_setWindowIconText;

			// Token: 0x04000A65 RID: 2661
			internal static method QCmbBx_setWindowOpacity;

			// Token: 0x04000A66 RID: 2662
			internal static method QCmbBx_windowOpacity;

			// Token: 0x04000A67 RID: 2663
			internal static method QCmbBx_isMinimized;

			// Token: 0x04000A68 RID: 2664
			internal static method QCmbBx_isMaximized;

			// Token: 0x04000A69 RID: 2665
			internal static method QCmbBx_isFullScreen;

			// Token: 0x04000A6A RID: 2666
			internal static method QCmbBx_setMouseTracking;

			// Token: 0x04000A6B RID: 2667
			internal static method QCmbBx_hasMouseTracking;

			// Token: 0x04000A6C RID: 2668
			internal static method QCmbBx_underMouse;

			// Token: 0x04000A6D RID: 2669
			internal static method QCmbBx_mapToGlobal;

			// Token: 0x04000A6E RID: 2670
			internal static method QCmbBx_mapFromGlobal;

			// Token: 0x04000A6F RID: 2671
			internal static method QCmbBx_hasFocus;

			// Token: 0x04000A70 RID: 2672
			internal static method QCmbBx_focusPolicy;

			// Token: 0x04000A71 RID: 2673
			internal static method QCmbBx_setFocusPolicy;

			// Token: 0x04000A72 RID: 2674
			internal static method QCmbBx_setFocusProxy;

			// Token: 0x04000A73 RID: 2675
			internal static method QCmbBx_isActiveWindow;

			// Token: 0x04000A74 RID: 2676
			internal static method QCmbBx_updatesEnabled;

			// Token: 0x04000A75 RID: 2677
			internal static method QCmbBx_setUpdatesEnabled;

			// Token: 0x04000A76 RID: 2678
			internal static method QCmbBx_setFocus;

			// Token: 0x04000A77 RID: 2679
			internal static method QCmbBx_activateWindow;

			// Token: 0x04000A78 RID: 2680
			internal static method QCmbBx_clearFocus;

			// Token: 0x04000A79 RID: 2681
			internal static method QCmbBx_setSizePolicy;

			// Token: 0x04000A7A RID: 2682
			internal static method QCmbBx_devicePixelRatioF;

			// Token: 0x04000A7B RID: 2683
			internal static method QCmbBx_saveGeometry;

			// Token: 0x04000A7C RID: 2684
			internal static method QCmbBx_restoreGeometry;

			// Token: 0x04000A7D RID: 2685
			internal static method QCmbBx_addAction;

			// Token: 0x04000A7E RID: 2686
			internal static method QCmbBx_removeAction;

			// Token: 0x04000A7F RID: 2687
			internal static method QCmbBx_setParent;

			// Token: 0x04000A80 RID: 2688
			internal static method QCmbBx_parentWidget;

			// Token: 0x04000A81 RID: 2689
			internal static method QCmbBx_AddClassName;

			// Token: 0x04000A82 RID: 2690
			internal static method QCmbBx_Polish;

			// Token: 0x04000A83 RID: 2691
			internal static method QCmbBx_toolTip;

			// Token: 0x04000A84 RID: 2692
			internal static method QCmbBx_setToolTip;

			// Token: 0x04000A85 RID: 2693
			internal static method QCmbBx_statusTip;

			// Token: 0x04000A86 RID: 2694
			internal static method QCmbBx_setStatusTip;

			// Token: 0x04000A87 RID: 2695
			internal static method QCmbBx_toolTipDuration;

			// Token: 0x04000A88 RID: 2696
			internal static method QCmbBx_setToolTipDuration;

			// Token: 0x04000A89 RID: 2697
			internal static method QCmbBx_autoFillBackground;

			// Token: 0x04000A8A RID: 2698
			internal static method QCmbBx_setAutoFillBackground;
		}
	}
}
