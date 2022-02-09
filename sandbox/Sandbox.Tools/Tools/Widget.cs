using System;
using System.Collections.Generic;
using System.ComponentModel;
using Native;
using Sandbox;

namespace Tools
{
	// Token: 0x020000CD RID: 205
	public class Widget : QObject
	{
		// Token: 0x060016F1 RID: 5873 RVA: 0x0005A392 File Offset: 0x00058592
		internal Widget()
		{
		}

		// Token: 0x060016F2 RID: 5874 RVA: 0x0005A3A2 File Offset: 0x000585A2
		internal Widget(IntPtr widget)
		{
			this.NativeInit(widget);
		}

		// Token: 0x060016F3 RID: 5875 RVA: 0x0005A3BC File Offset: 0x000585BC
		public Widget(Widget parent)
		{
			InteropSystem.Alloc<Widget>(this);
			QWidget widget = CWidget.CreateWidget((parent != null) ? parent._widget : default(QWidget), this);
			this.NativeInit(widget);
		}

		// Token: 0x060016F4 RID: 5876 RVA: 0x0005A404 File Offset: 0x00058604
		internal override void NativeInit(IntPtr ptr)
		{
			this._widget = ptr;
			if (this._widget == default(QWidget))
			{
				throw new Exception("_widget was null!");
			}
			base.NativeInit(ptr);
			Type t = base.GetType();
			while (t != typeof(Widget))
			{
				this._widget.AddClassName(t.Name);
				t = t.BaseType;
			}
		}

		// Token: 0x060016F5 RID: 5877 RVA: 0x0005A478 File Offset: 0x00058678
		internal override void NativeShutdown()
		{
			this._widget = default(QWidget);
			base.NativeShutdown();
			FileWatch fileWatch = this.styleWatch;
			if (fileWatch == null)
			{
				return;
			}
			fileWatch.Dispose();
		}

		// Token: 0x17000198 RID: 408
		// (get) Token: 0x060016F6 RID: 5878 RVA: 0x0005A49C File Offset: 0x0005869C
		// (set) Token: 0x060016F7 RID: 5879 RVA: 0x0005A4A9 File Offset: 0x000586A9
		public bool Enabled
		{
			get
			{
				return this._widget.isEnabled();
			}
			set
			{
				this._widget.setEnabled(value);
			}
		}

		// Token: 0x17000199 RID: 409
		// (get) Token: 0x060016F8 RID: 5880 RVA: 0x0005A4B7 File Offset: 0x000586B7
		// (set) Token: 0x060016F9 RID: 5881 RVA: 0x0005A4D4 File Offset: 0x000586D4
		public Widget Parent
		{
			get
			{
				return QObject.FindOrCreate(this._widget.parentWidget()) as Widget;
			}
			set
			{
				if (value == this)
				{
					throw new Exception("Trying to parent to self");
				}
				this._widget.setParent((value != null) ? value._widget : default(QWidget));
			}
		}

		// Token: 0x1700019A RID: 410
		// (get) Token: 0x060016FA RID: 5882 RVA: 0x0005A50F File Offset: 0x0005870F
		// (set) Token: 0x060016FB RID: 5883 RVA: 0x0005A521 File Offset: 0x00058721
		public Vector2 Size
		{
			get
			{
				return this._widget.size();
			}
			set
			{
				this._widget.resize(value);
			}
		}

		/// <summary>
		/// This panel's rect at 0,0
		/// </summary>
		// Token: 0x1700019B RID: 411
		// (get) Token: 0x060016FC RID: 5884 RVA: 0x0005A534 File Offset: 0x00058734
		[Browsable(false)]
		public Rect LocalRect
		{
			get
			{
				return new Rect(0.0, this.Size);
			}
		}

		/// <summary>
		/// This panel's rect in screen coords
		/// </summary>
		// Token: 0x1700019C RID: 412
		// (get) Token: 0x060016FD RID: 5885 RVA: 0x0005A54F File Offset: 0x0005874F
		[Browsable(false)]
		public Rect ScreenRect
		{
			get
			{
				return new Rect(this.ScreenPosition, this.Size);
			}
		}

		/// <summary>
		/// Utility to interact with a widget's width - use Size where possible
		/// </summary>
		// Token: 0x1700019D RID: 413
		// (get) Token: 0x060016FE RID: 5886 RVA: 0x0005A564 File Offset: 0x00058764
		// (set) Token: 0x060016FF RID: 5887 RVA: 0x0005A580 File Offset: 0x00058780
		[Browsable(false)]
		public float Width
		{
			get
			{
				return this.Size.x;
			}
			set
			{
				this.Size = this.Size.WithX(value);
			}
		}

		/// <summary>
		/// Utility to interact with a widget's width - use Size where possible
		/// </summary>
		// Token: 0x1700019E RID: 414
		// (get) Token: 0x06001700 RID: 5888 RVA: 0x0005A5A4 File Offset: 0x000587A4
		// (set) Token: 0x06001701 RID: 5889 RVA: 0x0005A5C0 File Offset: 0x000587C0
		[Browsable(false)]
		public float Height
		{
			get
			{
				return this.Size.y;
			}
			set
			{
				this.Size = this.Size.WithY(value);
			}
		}

		// Token: 0x1700019F RID: 415
		// (get) Token: 0x06001702 RID: 5890 RVA: 0x0005A5E2 File Offset: 0x000587E2
		// (set) Token: 0x06001703 RID: 5891 RVA: 0x0005A5F4 File Offset: 0x000587F4
		public Vector2 MinimumSize
		{
			get
			{
				return this._widget.minimumSize();
			}
			set
			{
				this._widget.setMinimumSize(value);
			}
		}

		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x06001704 RID: 5892 RVA: 0x0005A607 File Offset: 0x00058807
		// (set) Token: 0x06001705 RID: 5893 RVA: 0x0005A619 File Offset: 0x00058819
		public Vector2 MaximumSize
		{
			get
			{
				return this._widget.maximumSize();
			}
			set
			{
				this._widget.setMaximumSize(value);
			}
		}

		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06001706 RID: 5894 RVA: 0x0005A62C File Offset: 0x0005882C
		// (set) Token: 0x06001707 RID: 5895 RVA: 0x0005A63E File Offset: 0x0005883E
		public Vector2 Position
		{
			get
			{
				return this._widget.pos();
			}
			set
			{
				this._widget.move(value);
			}
		}

		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06001708 RID: 5896 RVA: 0x0005A651 File Offset: 0x00058851
		// (set) Token: 0x06001709 RID: 5897 RVA: 0x0005A65E File Offset: 0x0005885E
		public bool Visible
		{
			get
			{
				return this._widget.isVisible();
			}
			set
			{
				this._widget.setVisible(value);
			}
		}

		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x0600170A RID: 5898 RVA: 0x0005A66C File Offset: 0x0005886C
		// (set) Token: 0x0600170B RID: 5899 RVA: 0x0005A679 File Offset: 0x00058879
		public string Name
		{
			get
			{
				return this._widget.objectName();
			}
			set
			{
				this._widget.setObjectName(value);
			}
		}

		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x0600170C RID: 5900 RVA: 0x0005A687 File Offset: 0x00058887
		// (set) Token: 0x0600170D RID: 5901 RVA: 0x0005A691 File Offset: 0x00058891
		public bool TranslucentBackground
		{
			get
			{
				return this.HasFlag(Widget.Flag.WA_TranslucentBackground);
			}
			set
			{
				this.SetFlag(Widget.Flag.WA_TranslucentBackground, value);
			}
		}

		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600170E RID: 5902 RVA: 0x0005A69C File Offset: 0x0005889C
		// (set) Token: 0x0600170F RID: 5903 RVA: 0x0005A6A6 File Offset: 0x000588A6
		public bool NoSystemBackground
		{
			get
			{
				return this.HasFlag(Widget.Flag.WA_NoSystemBackground);
			}
			set
			{
				this.SetFlag(Widget.Flag.WA_NoSystemBackground, value);
			}
		}

		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x06001710 RID: 5904 RVA: 0x0005A6B1 File Offset: 0x000588B1
		// (set) Token: 0x06001711 RID: 5905 RVA: 0x0005A6BB File Offset: 0x000588BB
		public bool TransparentForMouseEvents
		{
			get
			{
				return this.HasFlag(Widget.Flag.WA_TransparentForMouseEvents);
			}
			set
			{
				this.SetFlag(Widget.Flag.WA_TransparentForMouseEvents, value);
			}
		}

		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x06001712 RID: 5906 RVA: 0x0005A6C6 File Offset: 0x000588C6
		// (set) Token: 0x06001713 RID: 5907 RVA: 0x0005A6D0 File Offset: 0x000588D0
		public bool ShowWithoutActivating
		{
			get
			{
				return this.HasFlag(Widget.Flag.WA_ShowWithoutActivating);
			}
			set
			{
				this.SetFlag(Widget.Flag.WA_ShowWithoutActivating, value);
			}
		}

		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06001714 RID: 5908 RVA: 0x0005A6DB File Offset: 0x000588DB
		// (set) Token: 0x06001715 RID: 5909 RVA: 0x0005A6E8 File Offset: 0x000588E8
		public bool MouseTracking
		{
			get
			{
				return this._widget.hasMouseTracking();
			}
			set
			{
				this._widget.setMouseTracking(value);
			}
		}

		/// <summary>
		/// Accept drag and dropping shit on us
		/// </summary>
		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06001716 RID: 5910 RVA: 0x0005A6F6 File Offset: 0x000588F6
		// (set) Token: 0x06001717 RID: 5911 RVA: 0x0005A703 File Offset: 0x00058903
		public bool AcceptDrops
		{
			get
			{
				return this._widget.acceptDrops();
			}
			set
			{
				this._widget.setAcceptDrops(value);
			}
		}

		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06001718 RID: 5912 RVA: 0x0005A711 File Offset: 0x00058911
		// (set) Token: 0x06001719 RID: 5913 RVA: 0x0005A71E File Offset: 0x0005891E
		public bool IsFramelessWindow
		{
			get
			{
				return this.HasWindowFlag((WindowFlags)2049);
			}
			set
			{
				if (value)
				{
					this._widget.setWindowFlags((WindowFlags)2049);
					return;
				}
				this._widget.setWindowFlags(WindowFlags.Widget);
			}
		}

		// Token: 0x170001AB RID: 427
		// (get) Token: 0x0600171A RID: 5914 RVA: 0x0005A740 File Offset: 0x00058940
		// (set) Token: 0x0600171B RID: 5915 RVA: 0x0005A74A File Offset: 0x0005894A
		public bool IsTooltip
		{
			get
			{
				return this.HasWindowFlag(WindowFlags.ToolTip);
			}
			set
			{
				if (value)
				{
					this._widget.setWindowFlags(WindowFlags.ToolTip);
					return;
				}
				this._widget.setWindowFlags(WindowFlags.Widget);
			}
		}

		// Token: 0x170001AC RID: 428
		// (get) Token: 0x0600171C RID: 5916 RVA: 0x0005A769 File Offset: 0x00058969
		// (set) Token: 0x0600171D RID: 5917 RVA: 0x0005A773 File Offset: 0x00058973
		public bool IsPopup
		{
			get
			{
				return this.HasWindowFlag(WindowFlags.Popup);
			}
			set
			{
				if (value)
				{
					this._widget.setWindowFlags(WindowFlags.Popup);
					return;
				}
				this._widget.setWindowFlags(WindowFlags.Widget);
			}
		}

		/// <summary>
		/// The scale this widget is using (multipling Size by this value gives the actual native size)
		/// </summary>
		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600171E RID: 5918 RVA: 0x0005A792 File Offset: 0x00058992
		public float DpiScale
		{
			get
			{
				return this._widget.devicePixelRatioF();
			}
		}

		// Token: 0x0600171F RID: 5919 RVA: 0x0005A79F File Offset: 0x0005899F
		public void Focus(bool activateWindow = true)
		{
			if (activateWindow && !this._widget.isActiveWindow())
			{
				this._widget.activateWindow();
			}
			this._widget.setFocus();
		}

		// Token: 0x06001720 RID: 5920 RVA: 0x0005A7C7 File Offset: 0x000589C7
		public void Blur()
		{
			this._widget.clearFocus();
		}

		// Token: 0x170001AE RID: 430
		// (get) Token: 0x06001721 RID: 5921 RVA: 0x0005A7D4 File Offset: 0x000589D4
		public bool IsFocused
		{
			get
			{
				return this._widget.hasFocus();
			}
		}

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x06001722 RID: 5922 RVA: 0x0005A7E1 File Offset: 0x000589E1
		public bool IsActiveWindow
		{
			get
			{
				return this._widget.isActiveWindow();
			}
		}

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06001723 RID: 5923 RVA: 0x0005A7EE File Offset: 0x000589EE
		// (set) Token: 0x06001724 RID: 5924 RVA: 0x0005A7FB File Offset: 0x000589FB
		public FocusMode FocusMode
		{
			get
			{
				return this._widget.focusPolicy();
			}
			set
			{
				this._widget.setFocusPolicy(value);
			}
		}

		/// <summary>
		/// When adding a bunch of children to a widget it can be slow, as it draws after every add.
		/// You can fix that using this, by suspending the updates until you're done.
		/// </summary>
		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06001725 RID: 5925 RVA: 0x0005A809 File Offset: 0x00058A09
		// (set) Token: 0x06001726 RID: 5926 RVA: 0x0005A816 File Offset: 0x00058A16
		public bool UpdatesEnabled
		{
			get
			{
				return this._widget.updatesEnabled();
			}
			set
			{
				this._widget.setUpdatesEnabled(value);
			}
		}

		// Token: 0x06001727 RID: 5927 RVA: 0x0005A824 File Offset: 0x00058A24
		internal void SetFlag(Widget.Flag f, bool b)
		{
			this._widget.setAttribute(f, b);
		}

		// Token: 0x06001728 RID: 5928 RVA: 0x0005A833 File Offset: 0x00058A33
		internal bool HasFlag(Widget.Flag f)
		{
			return this._widget.testAttribute(f);
		}

		// Token: 0x06001729 RID: 5929 RVA: 0x0005A841 File Offset: 0x00058A41
		internal void SetWindowFlag(WindowFlags f, bool b)
		{
			this._widget.setWindowFlags(b ? (this._widget.windowFlags() & f) : (this._widget.windowFlags() & ~f));
		}

		// Token: 0x0600172A RID: 5930 RVA: 0x0005A86E File Offset: 0x00058A6E
		internal bool HasWindowFlag(WindowFlags f)
		{
			return this._widget.windowFlags().HasFlag(f);
		}

		// Token: 0x0600172B RID: 5931 RVA: 0x0005A88B File Offset: 0x00058A8B
		public void SetStyles(string sheet)
		{
			this._widget.setStyleSheet(sheet);
		}

		// Token: 0x0600172C RID: 5932 RVA: 0x0005A89C File Offset: 0x00058A9C
		public void SetStylesheetFile(string filename)
		{
			FileWatch fileWatch = this.styleWatch;
			if (fileWatch != null)
			{
				fileWatch.Dispose();
			}
			this.styleWatch = FileSystem.Mounted.Watch(filename);
			this.styleWatch.OnChanges += delegate(FileWatch x)
			{
				this.LoadStylesheetFile(filename);
			};
			this.LoadStylesheetFile(filename);
		}

		// Token: 0x0600172D RID: 5933 RVA: 0x0005A908 File Offset: 0x00058B08
		internal void LoadStylesheetFile(string filename)
		{
			string txt = FileSystem.Mounted.ReadAllText(filename);
			this.SetStyles(txt);
		}

		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x0600172E RID: 5934 RVA: 0x0005A928 File Offset: 0x00058B28
		public IEnumerable<Widget> Children
		{
			get
			{
				int c;
				QObject[] childs = base.GetChildren(out c);
				int num;
				for (int i = 0; i < c; i = num + 1)
				{
					Widget w = QObject.FindOrCreate(childs[i]) as Widget;
					if (w != null)
					{
						yield return w;
					}
					num = i;
				}
				yield break;
			}
		}

		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600172F RID: 5935 RVA: 0x0005A938 File Offset: 0x00058B38
		// (set) Token: 0x06001730 RID: 5936 RVA: 0x0005A940 File Offset: 0x00058B40
		public virtual CursorShape Cursor
		{
			get
			{
				return this._cursor;
			}
			set
			{
				this._cursor = value;
				if (this.Cursor == CursorShape.None)
				{
					this._widget.unsetCursor();
					return;
				}
				this._widget.setCursor(this.Cursor);
			}
		}

		/// <summary>
		/// Tell this widget that shit changed and it needs to refresh
		/// </summary>
		// Token: 0x06001731 RID: 5937 RVA: 0x0005A970 File Offset: 0x00058B70
		public virtual void Update()
		{
			this._widget.update();
		}

		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x06001732 RID: 5938 RVA: 0x0005A980 File Offset: 0x00058B80
		public Vector2 ScreenPosition
		{
			get
			{
				return this.ToScreen(default(Vector2));
			}
		}

		// Token: 0x06001733 RID: 5939 RVA: 0x0005A99C File Offset: 0x00058B9C
		public Vector2 ToScreen(Vector2 p)
		{
			return this._widget.mapToGlobal(p);
		}

		// Token: 0x06001734 RID: 5940 RVA: 0x0005A9B4 File Offset: 0x00058BB4
		public Vector2 FromScreen(Vector2 p)
		{
			return this._widget.mapFromGlobal(p);
		}

		// Token: 0x06001735 RID: 5941 RVA: 0x0005A9CC File Offset: 0x00058BCC
		public void PostKeyEvent(KeyCode key)
		{
			WidgetUtil.PostKeyEvent(this._widget, (int)key);
		}

		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x06001736 RID: 5942 RVA: 0x0005A9DA File Offset: 0x00058BDA
		// (set) Token: 0x06001737 RID: 5943 RVA: 0x0005A9E4 File Offset: 0x00058BE4
		public Widget FocusProxy
		{
			get
			{
				return this._focusProxy;
			}
			set
			{
				this._focusProxy = value;
				Widget focusProxy = this._focusProxy;
				this._widget.setFocusProxy((focusProxy != null) ? focusProxy._widget : default(QWidget));
			}
		}

		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x06001738 RID: 5944 RVA: 0x0005AA1D File Offset: 0x00058C1D
		public bool IsUnderMouse
		{
			get
			{
				return this._widget.underMouse();
			}
		}

		// Token: 0x06001739 RID: 5945 RVA: 0x0005AA2A File Offset: 0x00058C2A
		public void SetSizeMode(SizeMode horizontal, SizeMode vertical)
		{
			this._widget.setSizePolicy(horizontal, vertical);
		}

		// Token: 0x0600173A RID: 5946 RVA: 0x0005AA39 File Offset: 0x00058C39
		public string SaveGeometry()
		{
			return this._widget.saveGeometry();
		}

		// Token: 0x0600173B RID: 5947 RVA: 0x0005AA46 File Offset: 0x00058C46
		public void RestoreGeometry(string state)
		{
			this._widget.restoreGeometry(state);
		}

		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x0600173C RID: 5948 RVA: 0x0005AA55 File Offset: 0x00058C55
		// (set) Token: 0x0600173D RID: 5949 RVA: 0x0005AA62 File Offset: 0x00058C62
		public string ToolTip
		{
			get
			{
				return this._widget.toolTip();
			}
			set
			{
				this._widget.setToolTip(value);
			}
		}

		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x0600173E RID: 5950 RVA: 0x0005AA70 File Offset: 0x00058C70
		// (set) Token: 0x0600173F RID: 5951 RVA: 0x0005AA7D File Offset: 0x00058C7D
		public string StatusTip
		{
			get
			{
				return this._widget.statusTip();
			}
			set
			{
				this._widget.setStatusTip(value);
			}
		}

		// Token: 0x06001740 RID: 5952 RVA: 0x0005AA8B File Offset: 0x00058C8B
		protected virtual void Signal(WidgetSignal signal)
		{
			Widget parent = this.Parent;
			if (parent == null)
			{
				return;
			}
			parent.Signal(signal);
		}

		// Token: 0x06001741 RID: 5953 RVA: 0x0005AA9E File Offset: 0x00058C9E
		public void MakeSignal(string name)
		{
			this.Signal(new WidgetSignal
			{
				SourceWidget = this,
				Type = name
			});
		}

		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x06001742 RID: 5954 RVA: 0x0005AAB9 File Offset: 0x00058CB9
		// (set) Token: 0x06001743 RID: 5955 RVA: 0x0005AAC4 File Offset: 0x00058CC4
		public DataBind DataBinding
		{
			get
			{
				return this._dataBind;
			}
			set
			{
				if (this._dataBind == value)
				{
					return;
				}
				this._dataBind = value;
				if (value != null)
				{
					value.StartRead();
				}
				this.PullFromBinding();
				if (value != null)
				{
					value.EndRead();
				}
				if (this._dataBind != null)
				{
					this.Enabled = this._dataBind.IsWritable();
				}
			}
		}

		// Token: 0x06001744 RID: 5956 RVA: 0x0005AB14 File Offset: 0x00058D14
		public virtual void PullFromBinding()
		{
			if (this.DataBinding == null)
			{
				return;
			}
			this.DataBinding.StartRead();
			try
			{
				object val = this.DataBinding.GetValue();
				if (this.oldValue != val)
				{
					this.oldValue = val;
					this.DataValueChanged(val);
				}
			}
			finally
			{
				this.DataBinding.EndRead();
			}
		}

		// Token: 0x06001745 RID: 5957 RVA: 0x0005AB78 File Offset: 0x00058D78
		protected virtual void DataValueChanged(object obj)
		{
		}

		// Token: 0x06001746 RID: 5958 RVA: 0x0005AB7A File Offset: 0x00058D7A
		public virtual void PushToBinding()
		{
		}

		// Token: 0x06001747 RID: 5959 RVA: 0x0005AB7C File Offset: 0x00058D7C
		internal void InternalWheelEvent(QWheelEvent e)
		{
			this.OnWheel(new WheelEvent
			{
				ptr = e
			});
		}

		// Token: 0x06001748 RID: 5960 RVA: 0x0005ABA0 File Offset: 0x00058DA0
		protected virtual void OnWheel(WheelEvent e)
		{
		}

		// Token: 0x06001749 RID: 5961 RVA: 0x0005ABA4 File Offset: 0x00058DA4
		internal void InternalMouseReleaseEvent(QMouseEvent e)
		{
			this.OnMouseReleased(new MouseEvent
			{
				ptr = e
			});
		}

		// Token: 0x0600174A RID: 5962 RVA: 0x0005ABC8 File Offset: 0x00058DC8
		protected virtual void OnMouseReleased(MouseEvent e)
		{
			Action mouseRelease = this.MouseRelease;
			if (mouseRelease != null)
			{
				mouseRelease();
			}
			if (e.LeftMouseButton && this.canClick)
			{
				Vector2 hitPos = e.LocalPosition;
				if (!this.LocalRect.IsInside(hitPos))
				{
					return;
				}
				if (this.startClickPos.Distance(hitPos) > 6f)
				{
					return;
				}
				this.OnMouseClick(e);
			}
			if (e.RightMouseButton && this.canRightClick)
			{
				Vector2 hitPos2 = e.LocalPosition;
				if (!this.LocalRect.IsInside(hitPos2))
				{
					return;
				}
				if (this.startRightClickPos.Distance(hitPos2) > 6f)
				{
					return;
				}
				this.OnMouseRightClick(e);
			}
		}

		// Token: 0x0600174B RID: 5963 RVA: 0x0005AC74 File Offset: 0x00058E74
		protected virtual void OnMouseClick(MouseEvent e)
		{
			Action mouseClick = this.MouseClick;
			if (mouseClick == null)
			{
				return;
			}
			mouseClick();
		}

		// Token: 0x0600174C RID: 5964 RVA: 0x0005AC86 File Offset: 0x00058E86
		protected virtual void OnMouseRightClick(MouseEvent e)
		{
			Action mouseRightClick = this.MouseRightClick;
			if (mouseRightClick == null)
			{
				return;
			}
			mouseRightClick();
		}

		// Token: 0x0600174D RID: 5965 RVA: 0x0005AC98 File Offset: 0x00058E98
		internal void InternalMousePressEvent(QMouseEvent e)
		{
			this.OnMousePress(new MouseEvent
			{
				ptr = e
			});
		}

		// Token: 0x0600174E RID: 5966 RVA: 0x0005ACBC File Offset: 0x00058EBC
		protected virtual void OnMousePress(MouseEvent e)
		{
			if (e.LeftMouseButton)
			{
				this.canClick = !e.Accepted;
				this.startClickPos = e.LocalPosition;
			}
			if (e.RightMouseButton)
			{
				this.canRightClick = !e.Accepted;
				this.startRightClickPos = e.LocalPosition;
			}
			Action mousePress = this.MousePress;
			if (mousePress == null)
			{
				return;
			}
			mousePress();
		}

		// Token: 0x0600174F RID: 5967 RVA: 0x0005AD28 File Offset: 0x00058F28
		internal void InternalMouseMoveEvent(QMouseEvent e)
		{
			this.OnMouseMove(new MouseEvent
			{
				ptr = e
			});
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x0005AD4C File Offset: 0x00058F4C
		protected virtual void OnMouseMove(MouseEvent e)
		{
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0005AD4E File Offset: 0x00058F4E
		internal void InternalMouseEnterEvent(QMouseEvent e)
		{
			this.OnMouseEnter();
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x0005AD56 File Offset: 0x00058F56
		protected virtual void OnMouseEnter()
		{
		}

		// Token: 0x06001753 RID: 5971 RVA: 0x0005AD58 File Offset: 0x00058F58
		internal void InternalMouseLeaveEvent(QMouseEvent e)
		{
			this.OnMouseLeave();
		}

		// Token: 0x06001754 RID: 5972 RVA: 0x0005AD60 File Offset: 0x00058F60
		protected virtual void OnMouseLeave()
		{
		}

		// Token: 0x06001755 RID: 5973 RVA: 0x0005AD64 File Offset: 0x00058F64
		internal void InternalContextMenuEvent(QContextMenuEvent e)
		{
			this.OnContextMenu(new ContextMenuEvent
			{
				ptr = e
			});
		}

		// Token: 0x06001756 RID: 5974 RVA: 0x0005AD88 File Offset: 0x00058F88
		protected virtual void OnContextMenu(ContextMenuEvent e)
		{
		}

		// Token: 0x06001757 RID: 5975 RVA: 0x0005AD8C File Offset: 0x00058F8C
		internal void InternalMouseDoubleClickEvent(QMouseEvent e)
		{
			this.OnDoubleClick(new MouseEvent
			{
				ptr = e
			});
		}

		// Token: 0x06001758 RID: 5976 RVA: 0x0005ADB0 File Offset: 0x00058FB0
		protected virtual void OnDoubleClick(MouseEvent e)
		{
		}

		// Token: 0x06001759 RID: 5977 RVA: 0x0005ADB2 File Offset: 0x00058FB2
		internal void InternalKeyPressEvent(QKeyEvent e)
		{
			this.OnKeyPress(new KeyEvent(e));
		}

		// Token: 0x0600175A RID: 5978 RVA: 0x0005ADC0 File Offset: 0x00058FC0
		protected virtual void OnKeyPress(KeyEvent e)
		{
		}

		// Token: 0x0600175B RID: 5979 RVA: 0x0005ADC2 File Offset: 0x00058FC2
		internal void InternalFocusInEvent(FocusChangeReason reason)
		{
			this.OnFocus(reason);
		}

		// Token: 0x0600175C RID: 5980 RVA: 0x0005ADCB File Offset: 0x00058FCB
		protected virtual void OnFocus(FocusChangeReason reason)
		{
		}

		// Token: 0x0600175D RID: 5981 RVA: 0x0005ADCD File Offset: 0x00058FCD
		internal void InternalFocusOutEvent(FocusChangeReason reason)
		{
			this.OnBlur(reason);
		}

		// Token: 0x0600175E RID: 5982 RVA: 0x0005ADD6 File Offset: 0x00058FD6
		protected virtual void OnBlur(FocusChangeReason reason)
		{
		}

		// Token: 0x0600175F RID: 5983 RVA: 0x0005ADD8 File Offset: 0x00058FD8
		internal void InternalOnResizeEvent(QResizeEvent e)
		{
			this.OnResize();
		}

		// Token: 0x06001760 RID: 5984 RVA: 0x0005ADE0 File Offset: 0x00058FE0
		protected virtual void OnResize()
		{
		}

		// Token: 0x06001761 RID: 5985 RVA: 0x0005ADE2 File Offset: 0x00058FE2
		internal void InternalOnMoveEvent(QMoveEvent e)
		{
			this.OnMoved();
		}

		// Token: 0x06001762 RID: 5986 RVA: 0x0005ADEA File Offset: 0x00058FEA
		protected virtual void OnMoved()
		{
		}

		// Token: 0x06001763 RID: 5987 RVA: 0x0005ADEC File Offset: 0x00058FEC
		internal bool InternalPaintEvent(QPainter e)
		{
			this.skipDraw = true;
			Paint.Start(e, StateFlag.None);
			try
			{
				this.OnPaint();
			}
			finally
			{
				Paint.Finished();
			}
			return this.skipDraw;
		}

		// Token: 0x06001764 RID: 5988 RVA: 0x0005AE2C File Offset: 0x0005902C
		protected virtual void OnPaint()
		{
			this.skipDraw = false;
		}

		// Token: 0x06001765 RID: 5989 RVA: 0x0005AE35 File Offset: 0x00059035
		internal void InternalOnEvent(EventType e)
		{
			if (e == EventType.LayoutRequest || e == EventType.Resize)
			{
				this.DoLayout();
			}
			if (e == EventType.Show)
			{
				this.OnVisibilityChanged(true);
			}
			if (e == EventType.Hide)
			{
				this.OnVisibilityChanged(false);
			}
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x0005AE5F File Offset: 0x0005905F
		internal bool InternalFocusNextPrevChild(bool next)
		{
			if (next)
			{
				return this.FocusNext();
			}
			return this.FocusPrevious();
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x0005AE71 File Offset: 0x00059071
		protected virtual bool FocusNext()
		{
			return false;
		}

		// Token: 0x06001768 RID: 5992 RVA: 0x0005AE74 File Offset: 0x00059074
		protected virtual bool FocusPrevious()
		{
			return false;
		}

		// Token: 0x06001769 RID: 5993 RVA: 0x0005AE77 File Offset: 0x00059077
		protected virtual void DoLayout()
		{
		}

		// Token: 0x1400000C RID: 12
		// (add) Token: 0x0600176A RID: 5994 RVA: 0x0005AE7C File Offset: 0x0005907C
		// (remove) Token: 0x0600176B RID: 5995 RVA: 0x0005AEB4 File Offset: 0x000590B4
		public event Action<bool> VisibilityChanged;

		// Token: 0x0600176C RID: 5996 RVA: 0x0005AEE9 File Offset: 0x000590E9
		protected virtual void OnVisibilityChanged(bool visible)
		{
			Action<bool> visibilityChanged = this.VisibilityChanged;
			if (visibilityChanged == null)
			{
				return;
			}
			visibilityChanged(visible);
		}

		// Token: 0x170001BA RID: 442
		// (get) Token: 0x0600176D RID: 5997 RVA: 0x0005AEFC File Offset: 0x000590FC
		// (set) Token: 0x0600176E RID: 5998 RVA: 0x0005AF04 File Offset: 0x00059104
		public bool IsBeingDroppedOn { get; private set; }

		// Token: 0x0600176F RID: 5999 RVA: 0x0005AF0D File Offset: 0x0005910D
		internal bool InternalDragMoveEvent(QDragMoveEvent e)
		{
			return false;
		}

		// Token: 0x06001770 RID: 6000 RVA: 0x0005AF10 File Offset: 0x00059110
		internal bool InternalDragLeaveEvent(QDragLeaveEvent e)
		{
			this.IsBeingDroppedOn = false;
			this.Update();
			this.OnDragLeave();
			return false;
		}

		// Token: 0x06001771 RID: 6001 RVA: 0x0005AF28 File Offset: 0x00059128
		internal bool InternalDropEvent(QDropEvent e)
		{
			this.Update();
			DragData dd = new DragData(e.mimeData());
			DropAction action = this.OnDropEvent(dd);
			if (action != DropAction.Ignore)
			{
				e.setDropAction(action);
				e.accept();
				return true;
			}
			return false;
		}

		// Token: 0x06001772 RID: 6002 RVA: 0x0005AF68 File Offset: 0x00059168
		internal bool InternalDragEnterEvent(QDragEnterEvent e)
		{
			this.Update();
			DragData dd = new DragData(e.mimeData());
			DropAction action = this.OnDragEnter(dd);
			if (action != DropAction.Ignore)
			{
				e.setDropAction(action);
				e.accept();
				this.IsBeingDroppedOn = true;
				return true;
			}
			this.IsBeingDroppedOn = false;
			return false;
		}

		// Token: 0x06001773 RID: 6003 RVA: 0x0005AFB3 File Offset: 0x000591B3
		public virtual DropAction OnDragEnter(DragData data)
		{
			return DropAction.Ignore;
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x0005AFB6 File Offset: 0x000591B6
		public virtual void OnDragLeave()
		{
		}

		// Token: 0x06001775 RID: 6005 RVA: 0x0005AFB8 File Offset: 0x000591B8
		public virtual DropAction OnDropEvent(DragData data)
		{
			return DropAction.Ignore;
		}

		// Token: 0x06001776 RID: 6006 RVA: 0x0005AFBB File Offset: 0x000591BB
		public BoxLayout MakeTopToBottom()
		{
			return new BoxLayout(BoxLayout.Direction.TopToBottom, this);
		}

		// Token: 0x06001777 RID: 6007 RVA: 0x0005AFC4 File Offset: 0x000591C4
		public BoxLayout MakeBottomToTop()
		{
			return new BoxLayout(BoxLayout.Direction.BottomToTop, this);
		}

		// Token: 0x06001778 RID: 6008 RVA: 0x0005AFCD File Offset: 0x000591CD
		public BoxLayout MakeLeftToRight()
		{
			return new BoxLayout(BoxLayout.Direction.LeftToRight, this);
		}

		// Token: 0x040004B1 RID: 1201
		internal QWidget _widget;

		// Token: 0x040004B2 RID: 1202
		private FileWatch styleWatch;

		// Token: 0x040004B3 RID: 1203
		private CursorShape _cursor = CursorShape.None;

		// Token: 0x040004B4 RID: 1204
		private Widget _focusProxy;

		// Token: 0x040004B5 RID: 1205
		private DataBind _dataBind;

		// Token: 0x040004B6 RID: 1206
		private object oldValue;

		// Token: 0x040004B7 RID: 1207
		private bool canClick;

		// Token: 0x040004B8 RID: 1208
		private bool canRightClick;

		// Token: 0x040004B9 RID: 1209
		private Vector2 startClickPos;

		// Token: 0x040004BA RID: 1210
		private Vector2 startRightClickPos;

		// Token: 0x040004BB RID: 1211
		public Action MouseClick;

		// Token: 0x040004BC RID: 1212
		public Action MouseRightClick;

		// Token: 0x040004BD RID: 1213
		public Action MousePress;

		// Token: 0x040004BE RID: 1214
		public Action MouseRelease;

		// Token: 0x040004BF RID: 1215
		private bool skipDraw;

		// Token: 0x0200015A RID: 346
		internal enum Flag
		{
			// Token: 0x040012D5 RID: 4821
			WA_Disabled,
			// Token: 0x040012D6 RID: 4822
			WA_UnderMouse,
			// Token: 0x040012D7 RID: 4823
			WA_MouseTracking,
			// Token: 0x040012D8 RID: 4824
			WA_ContentsPropagated,
			// Token: 0x040012D9 RID: 4825
			WA_OpaquePaintEvent,
			// Token: 0x040012DA RID: 4826
			WA_StaticContents,
			// Token: 0x040012DB RID: 4827
			WA_LaidOut = 7,
			// Token: 0x040012DC RID: 4828
			WA_PaintOnScreen,
			// Token: 0x040012DD RID: 4829
			WA_NoSystemBackground,
			// Token: 0x040012DE RID: 4830
			WA_UpdatesDisabled,
			// Token: 0x040012DF RID: 4831
			WA_Mapped,
			// Token: 0x040012E0 RID: 4832
			WA_InputMethodEnabled = 14,
			// Token: 0x040012E1 RID: 4833
			WA_WState_Visible,
			// Token: 0x040012E2 RID: 4834
			WA_WState_Hidden,
			// Token: 0x040012E3 RID: 4835
			WA_ForceDisabled = 32,
			// Token: 0x040012E4 RID: 4836
			WA_KeyCompression,
			// Token: 0x040012E5 RID: 4837
			WA_PendingMoveEvent,
			// Token: 0x040012E6 RID: 4838
			WA_PendingResizeEvent,
			// Token: 0x040012E7 RID: 4839
			WA_SetPalette,
			// Token: 0x040012E8 RID: 4840
			WA_SetFont,
			// Token: 0x040012E9 RID: 4841
			WA_SetCursor,
			// Token: 0x040012EA RID: 4842
			WA_NoChildEventsFromChildren,
			// Token: 0x040012EB RID: 4843
			WA_WindowModified = 41,
			// Token: 0x040012EC RID: 4844
			WA_Resized,
			// Token: 0x040012ED RID: 4845
			WA_Moved,
			// Token: 0x040012EE RID: 4846
			WA_PendingUpdate,
			// Token: 0x040012EF RID: 4847
			WA_InvalidSize,
			// Token: 0x040012F0 RID: 4848
			WA_CustomWhatsThis = 47,
			// Token: 0x040012F1 RID: 4849
			WA_LayoutOnEntireRect,
			// Token: 0x040012F2 RID: 4850
			WA_OutsideWSRange,
			// Token: 0x040012F3 RID: 4851
			WA_GrabbedShortcut,
			// Token: 0x040012F4 RID: 4852
			WA_TransparentForMouseEvents,
			// Token: 0x040012F5 RID: 4853
			WA_PaintUnclipped,
			// Token: 0x040012F6 RID: 4854
			WA_SetWindowIcon,
			// Token: 0x040012F7 RID: 4855
			WA_NoMouseReplay,
			// Token: 0x040012F8 RID: 4856
			DeleteOnClose,
			// Token: 0x040012F9 RID: 4857
			WA_RightToLeft,
			// Token: 0x040012FA RID: 4858
			WA_SetLayoutDirection,
			// Token: 0x040012FB RID: 4859
			WA_NoChildEventsForParent,
			// Token: 0x040012FC RID: 4860
			WA_ForceUpdatesDisabled,
			// Token: 0x040012FD RID: 4861
			WA_WState_Created,
			// Token: 0x040012FE RID: 4862
			WA_WState_CompressKeys,
			// Token: 0x040012FF RID: 4863
			WA_WState_InPaintEvent,
			// Token: 0x04001300 RID: 4864
			WA_WState_Reparented,
			// Token: 0x04001301 RID: 4865
			WA_WState_ConfigPending,
			// Token: 0x04001302 RID: 4866
			WA_WState_Polished = 66,
			// Token: 0x04001303 RID: 4867
			WA_WState_DND,
			// Token: 0x04001304 RID: 4868
			WA_WState_OwnSizePolicy,
			// Token: 0x04001305 RID: 4869
			WA_WState_ExplicitShowHide,
			// Token: 0x04001306 RID: 4870
			WA_ShowModal,
			// Token: 0x04001307 RID: 4871
			WA_MouseNoMask,
			// Token: 0x04001308 RID: 4872
			WA_GroupLeader,
			// Token: 0x04001309 RID: 4873
			WA_NoMousePropagation,
			// Token: 0x0400130A RID: 4874
			WA_Hover,
			// Token: 0x0400130B RID: 4875
			WA_InputMethodTransparent,
			// Token: 0x0400130C RID: 4876
			WA_QuitOnClose,
			// Token: 0x0400130D RID: 4877
			WA_KeyboardFocusChange,
			// Token: 0x0400130E RID: 4878
			WA_AcceptDrops,
			// Token: 0x0400130F RID: 4879
			WA_DropSiteRegistered,
			// Token: 0x04001310 RID: 4880
			WA_ForceAcceptDrops = 79,
			// Token: 0x04001311 RID: 4881
			WA_WindowPropagation,
			// Token: 0x04001312 RID: 4882
			WA_NoX11EventCompression,
			// Token: 0x04001313 RID: 4883
			WA_TintedBackground,
			// Token: 0x04001314 RID: 4884
			WA_X11OpenGLOverlay,
			// Token: 0x04001315 RID: 4885
			WA_AlwaysShowToolTips,
			// Token: 0x04001316 RID: 4886
			WA_MacOpaqueSizeGrip,
			// Token: 0x04001317 RID: 4887
			WA_SetStyle,
			// Token: 0x04001318 RID: 4888
			WA_SetLocale,
			// Token: 0x04001319 RID: 4889
			WA_MacShowFocusRect,
			// Token: 0x0400131A RID: 4890
			WA_MacNormalSize,
			// Token: 0x0400131B RID: 4891
			WA_MacSmallSize,
			// Token: 0x0400131C RID: 4892
			WA_MacMiniSize,
			// Token: 0x0400131D RID: 4893
			WA_LayoutUsesWidgetRect,
			// Token: 0x0400131E RID: 4894
			WA_StyledBackground,
			// Token: 0x0400131F RID: 4895
			WA_CanHostQMdiSubWindowTitleBar = 95,
			// Token: 0x04001320 RID: 4896
			WA_MacAlwaysShowToolWindow,
			// Token: 0x04001321 RID: 4897
			WA_StyleSheet,
			// Token: 0x04001322 RID: 4898
			WA_ShowWithoutActivating,
			// Token: 0x04001323 RID: 4899
			WA_X11BypassTransientForHint,
			// Token: 0x04001324 RID: 4900
			WA_NativeWindow,
			// Token: 0x04001325 RID: 4901
			WA_DontCreateNativeAncestors,
			// Token: 0x04001326 RID: 4902
			WA_MacVariableSize,
			// Token: 0x04001327 RID: 4903
			WA_DontShowOnScreen,
			// Token: 0x04001328 RID: 4904
			WA_X11NetWmWindowTypeDesktop,
			// Token: 0x04001329 RID: 4905
			WA_X11NetWmWindowTypeDock,
			// Token: 0x0400132A RID: 4906
			WA_X11NetWmWindowTypeToolBar,
			// Token: 0x0400132B RID: 4907
			WA_X11NetWmWindowTypeMenu,
			// Token: 0x0400132C RID: 4908
			WA_X11NetWmWindowTypeUtility,
			// Token: 0x0400132D RID: 4909
			WA_X11NetWmWindowTypeSplash,
			// Token: 0x0400132E RID: 4910
			WA_X11NetWmWindowTypeDialog,
			// Token: 0x0400132F RID: 4911
			WA_X11NetWmWindowTypeDropDownMenu,
			// Token: 0x04001330 RID: 4912
			WA_X11NetWmWindowTypePopupMenu,
			// Token: 0x04001331 RID: 4913
			WA_X11NetWmWindowTypeToolTip,
			// Token: 0x04001332 RID: 4914
			WA_X11NetWmWindowTypeNotification,
			// Token: 0x04001333 RID: 4915
			WA_X11NetWmWindowTypeCombo,
			// Token: 0x04001334 RID: 4916
			WA_X11NetWmWindowTypeDND,
			// Token: 0x04001335 RID: 4917
			WA_SetWindowModality = 118,
			// Token: 0x04001336 RID: 4918
			WA_WState_WindowOpacitySet,
			// Token: 0x04001337 RID: 4919
			WA_TranslucentBackground,
			// Token: 0x04001338 RID: 4920
			WA_AcceptTouchEvents,
			// Token: 0x04001339 RID: 4921
			WA_WState_AcceptedTouchBeginEvent,
			// Token: 0x0400133A RID: 4922
			WA_TouchPadAcceptSingleTouchEvents,
			// Token: 0x0400133B RID: 4923
			WA_X11DoNotAcceptFocus = 126,
			// Token: 0x0400133C RID: 4924
			WA_MacNoShadow,
			// Token: 0x0400133D RID: 4925
			WA_AlwaysStackOnTop,
			// Token: 0x0400133E RID: 4926
			WA_TabletTracking,
			// Token: 0x0400133F RID: 4927
			WA_ContentsMarginsRespectsSafeArea,
			// Token: 0x04001340 RID: 4928
			WA_StyleSheetTarget,
			// Token: 0x04001341 RID: 4929
			WA_AttributeCount
		}
	}
}
