using System;
using System.Runtime.CompilerServices;
using Sandbox;
using Tools;

namespace Native
{
	// Token: 0x02000059 RID: 89
	internal struct QScrollBar
	{
		// Token: 0x06000E66 RID: 3686 RVA: 0x00026EA5 File Offset: 0x000250A5
		public static implicit operator IntPtr(QScrollBar value)
		{
			return value.self;
		}

		// Token: 0x06000E67 RID: 3687 RVA: 0x00026EB0 File Offset: 0x000250B0
		public static implicit operator QScrollBar(IntPtr value)
		{
			return new QScrollBar
			{
				self = value
			};
		}

		// Token: 0x06000E68 RID: 3688 RVA: 0x00026ECE File Offset: 0x000250CE
		public static bool operator ==(QScrollBar c1, QScrollBar c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000E69 RID: 3689 RVA: 0x00026EE1 File Offset: 0x000250E1
		public static bool operator !=(QScrollBar c1, QScrollBar c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000E6A RID: 3690 RVA: 0x00026EF4 File Offset: 0x000250F4
		public override bool Equals(object obj)
		{
			if (obj is QScrollBar)
			{
				QScrollBar c = (QScrollBar)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000E6B RID: 3691 RVA: 0x00026F1E File Offset: 0x0002511E
		internal QScrollBar(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000E6C RID: 3692 RVA: 0x00026F28 File Offset: 0x00025128
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("QScrollBar ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000E6D RID: 3693 RVA: 0x00026F64 File Offset: 0x00025164
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000E6E RID: 3694 RVA: 0x00026F76 File Offset: 0x00025176
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x06000E6F RID: 3695 RVA: 0x00026F81 File Offset: 0x00025181
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x06000E70 RID: 3696 RVA: 0x00026F94 File Offset: 0x00025194
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("QScrollBar was null when calling " + n);
			}
		}

		// Token: 0x06000E71 RID: 3697 RVA: 0x00026FAF File Offset: 0x000251AF
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x06000E72 RID: 3698 RVA: 0x00026FBC File Offset: 0x000251BC
		public static implicit operator QWidget(QScrollBar value)
		{
			method to_QWidget_From_QScrollBar = QScrollBar.__N.To_QWidget_From_QScrollBar;
			return calli(System.IntPtr(System.IntPtr), value, to_QWidget_From_QScrollBar);
		}

		// Token: 0x06000E73 RID: 3699 RVA: 0x00026FE0 File Offset: 0x000251E0
		public static explicit operator QScrollBar(QWidget value)
		{
			method from_QWidget_To_QScrollBar = QScrollBar.__N.From_QWidget_To_QScrollBar;
			return calli(System.IntPtr(System.IntPtr), value, from_QWidget_To_QScrollBar);
		}

		// Token: 0x06000E74 RID: 3700 RVA: 0x00027004 File Offset: 0x00025204
		public static implicit operator QObject(QScrollBar value)
		{
			method to_QObject_From_QScrollBar = QScrollBar.__N.To_QObject_From_QScrollBar;
			return calli(System.IntPtr(System.IntPtr), value, to_QObject_From_QScrollBar);
		}

		// Token: 0x06000E75 RID: 3701 RVA: 0x00027028 File Offset: 0x00025228
		public static explicit operator QScrollBar(QObject value)
		{
			method from_QObject_To_QScrollBar = QScrollBar.__N.From_QObject_To_QScrollBar;
			return calli(System.IntPtr(System.IntPtr), value, from_QObject_To_QScrollBar);
		}

		// Token: 0x06000E76 RID: 3702 RVA: 0x0002704C File Offset: 0x0002524C
		internal readonly void setMinimum(int v)
		{
			this.NullCheck("setMinimum");
			method qscrll_setMinimum = QScrollBar.__N.QScrll_setMinimum;
			calli(System.Void(System.IntPtr,System.Int32), this.self, v, qscrll_setMinimum);
		}

		// Token: 0x06000E77 RID: 3703 RVA: 0x00027078 File Offset: 0x00025278
		internal readonly int minimum()
		{
			this.NullCheck("minimum");
			method qscrll_minimum = QScrollBar.__N.QScrll_minimum;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_minimum);
		}

		// Token: 0x06000E78 RID: 3704 RVA: 0x000270A4 File Offset: 0x000252A4
		internal readonly void setMaximum(int v)
		{
			this.NullCheck("setMaximum");
			method qscrll_setMaximum = QScrollBar.__N.QScrll_setMaximum;
			calli(System.Void(System.IntPtr,System.Int32), this.self, v, qscrll_setMaximum);
		}

		// Token: 0x06000E79 RID: 3705 RVA: 0x000270D0 File Offset: 0x000252D0
		internal readonly int maximum()
		{
			this.NullCheck("maximum");
			method qscrll_maximum = QScrollBar.__N.QScrll_maximum;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_maximum);
		}

		// Token: 0x06000E7A RID: 3706 RVA: 0x000270FC File Offset: 0x000252FC
		internal readonly void setSingleStep(int v)
		{
			this.NullCheck("setSingleStep");
			method qscrll_setSingleStep = QScrollBar.__N.QScrll_setSingleStep;
			calli(System.Void(System.IntPtr,System.Int32), this.self, v, qscrll_setSingleStep);
		}

		// Token: 0x06000E7B RID: 3707 RVA: 0x00027128 File Offset: 0x00025328
		internal readonly int singleStep()
		{
			this.NullCheck("singleStep");
			method qscrll_singleStep = QScrollBar.__N.QScrll_singleStep;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_singleStep);
		}

		// Token: 0x06000E7C RID: 3708 RVA: 0x00027154 File Offset: 0x00025354
		internal readonly void setPageStep(int v)
		{
			this.NullCheck("setPageStep");
			method qscrll_setPageStep = QScrollBar.__N.QScrll_setPageStep;
			calli(System.Void(System.IntPtr,System.Int32), this.self, v, qscrll_setPageStep);
		}

		// Token: 0x06000E7D RID: 3709 RVA: 0x00027180 File Offset: 0x00025380
		internal readonly int pageStep()
		{
			this.NullCheck("pageStep");
			method qscrll_pageStep = QScrollBar.__N.QScrll_pageStep;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_pageStep);
		}

		// Token: 0x06000E7E RID: 3710 RVA: 0x000271AC File Offset: 0x000253AC
		internal readonly void setTracking(bool enable)
		{
			this.NullCheck("setTracking");
			method qscrll_setTracking = QScrollBar.__N.QScrll_setTracking;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qscrll_setTracking);
		}

		// Token: 0x06000E7F RID: 3711 RVA: 0x000271E0 File Offset: 0x000253E0
		internal readonly bool hasTracking()
		{
			this.NullCheck("hasTracking");
			method qscrll_hasTracking = QScrollBar.__N.QScrll_hasTracking;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_hasTracking) > 0;
		}

		// Token: 0x06000E80 RID: 3712 RVA: 0x00027210 File Offset: 0x00025410
		internal readonly void setSliderDown(bool v)
		{
			this.NullCheck("setSliderDown");
			method qscrll_setSliderDown = QScrollBar.__N.QScrll_setSliderDown;
			calli(System.Void(System.IntPtr,System.Int32), this.self, v ? 1 : 0, qscrll_setSliderDown);
		}

		// Token: 0x06000E81 RID: 3713 RVA: 0x00027244 File Offset: 0x00025444
		internal readonly bool isSliderDown()
		{
			this.NullCheck("isSliderDown");
			method qscrll_isSliderDown = QScrollBar.__N.QScrll_isSliderDown;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_isSliderDown) > 0;
		}

		// Token: 0x06000E82 RID: 3714 RVA: 0x00027274 File Offset: 0x00025474
		internal readonly void setSliderPosition(int v)
		{
			this.NullCheck("setSliderPosition");
			method qscrll_setSliderPosition = QScrollBar.__N.QScrll_setSliderPosition;
			calli(System.Void(System.IntPtr,System.Int32), this.self, v, qscrll_setSliderPosition);
		}

		// Token: 0x06000E83 RID: 3715 RVA: 0x000272A0 File Offset: 0x000254A0
		internal readonly int sliderPosition()
		{
			this.NullCheck("sliderPosition");
			method qscrll_sliderPosition = QScrollBar.__N.QScrll_sliderPosition;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_sliderPosition);
		}

		// Token: 0x06000E84 RID: 3716 RVA: 0x000272CC File Offset: 0x000254CC
		internal readonly void setInvertedAppearance(bool v)
		{
			this.NullCheck("setInvertedAppearance");
			method qscrll_setInvertedAppearance = QScrollBar.__N.QScrll_setInvertedAppearance;
			calli(System.Void(System.IntPtr,System.Int32), this.self, v ? 1 : 0, qscrll_setInvertedAppearance);
		}

		// Token: 0x06000E85 RID: 3717 RVA: 0x00027300 File Offset: 0x00025500
		internal readonly bool invertedAppearance()
		{
			this.NullCheck("invertedAppearance");
			method qscrll_invertedAppearance = QScrollBar.__N.QScrll_invertedAppearance;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_invertedAppearance) > 0;
		}

		// Token: 0x06000E86 RID: 3718 RVA: 0x00027330 File Offset: 0x00025530
		internal readonly void setInvertedControls(bool v)
		{
			this.NullCheck("setInvertedControls");
			method qscrll_setInvertedControls = QScrollBar.__N.QScrll_setInvertedControls;
			calli(System.Void(System.IntPtr,System.Int32), this.self, v ? 1 : 0, qscrll_setInvertedControls);
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x00027364 File Offset: 0x00025564
		internal readonly bool invertedControls()
		{
			this.NullCheck("invertedControls");
			method qscrll_invertedControls = QScrollBar.__N.QScrll_invertedControls;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_invertedControls) > 0;
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x00027394 File Offset: 0x00025594
		internal readonly bool isTopLevel()
		{
			this.NullCheck("isTopLevel");
			method qscrll_f = QScrollBar.__N.QScrll_f2;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x000273C4 File Offset: 0x000255C4
		internal readonly bool isWindow()
		{
			this.NullCheck("isWindow");
			method qscrll_f = QScrollBar.__N.QScrll_f3;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x000273F4 File Offset: 0x000255F4
		internal readonly bool isModal()
		{
			this.NullCheck("isModal");
			method qscrll_f = QScrollBar.__N.QScrll_f4;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x00027424 File Offset: 0x00025624
		internal readonly void setStyleSheet(string sheet)
		{
			this.NullCheck("setStyleSheet");
			method qscrll_f = QScrollBar.__N.QScrll_f5;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(sheet), qscrll_f);
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x00027454 File Offset: 0x00025654
		internal readonly string windowTitle()
		{
			this.NullCheck("windowTitle");
			method qscrll_f = QScrollBar.__N.QScrll_f6;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qscrll_f));
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x00027484 File Offset: 0x00025684
		internal readonly void setWindowTitle(string title)
		{
			this.NullCheck("setWindowTitle");
			method qscrll_f = QScrollBar.__N.QScrll_f7;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(title), qscrll_f);
		}

		// Token: 0x06000E8E RID: 3726 RVA: 0x000274B4 File Offset: 0x000256B4
		internal readonly void setWindowFlags(WindowFlags type)
		{
			this.NullCheck("setWindowFlags");
			method qscrll_f = QScrollBar.__N.QScrll_f8;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)type, qscrll_f);
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x000274E0 File Offset: 0x000256E0
		internal readonly WindowFlags windowFlags()
		{
			this.NullCheck("windowFlags");
			method qscrll_f = QScrollBar.__N.QScrll_f9;
			return calli(System.Int64(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x0002750C File Offset: 0x0002570C
		internal readonly Vector3 size()
		{
			this.NullCheck("size");
			method qscrll_f = QScrollBar.__N.QScrll_f10;
			return calli(Vector3(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x00027538 File Offset: 0x00025738
		internal readonly void resize(Vector3 x)
		{
			this.NullCheck("resize");
			method qscrll_f = QScrollBar.__N.QScrll_f11;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qscrll_f);
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x00027564 File Offset: 0x00025764
		internal readonly Vector3 minimumSize()
		{
			this.NullCheck("minimumSize");
			method qscrll_f = QScrollBar.__N.QScrll_f12;
			return calli(Vector3(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000E93 RID: 3731 RVA: 0x00027590 File Offset: 0x00025790
		internal readonly void setMinimumSize(Vector3 x)
		{
			this.NullCheck("setMinimumSize");
			method qscrll_f = QScrollBar.__N.QScrll_f13;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qscrll_f);
		}

		// Token: 0x06000E94 RID: 3732 RVA: 0x000275BC File Offset: 0x000257BC
		internal readonly Vector3 maximumSize()
		{
			this.NullCheck("maximumSize");
			method qscrll_f = QScrollBar.__N.QScrll_f14;
			return calli(Vector3(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000E95 RID: 3733 RVA: 0x000275E8 File Offset: 0x000257E8
		internal readonly void setMaximumSize(Vector3 x)
		{
			this.NullCheck("setMaximumSize");
			method qscrll_f = QScrollBar.__N.QScrll_f15;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qscrll_f);
		}

		// Token: 0x06000E96 RID: 3734 RVA: 0x00027614 File Offset: 0x00025814
		internal readonly Vector3 pos()
		{
			this.NullCheck("pos");
			method qscrll_f = QScrollBar.__N.QScrll_f16;
			return calli(Vector3(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000E97 RID: 3735 RVA: 0x00027640 File Offset: 0x00025840
		internal readonly void move(Vector3 x)
		{
			this.NullCheck("move");
			method qscrll_f = QScrollBar.__N.QScrll_f17;
			calli(System.Void(System.IntPtr,Vector3), this.self, x, qscrll_f);
		}

		// Token: 0x06000E98 RID: 3736 RVA: 0x0002766C File Offset: 0x0002586C
		internal readonly bool isEnabled()
		{
			this.NullCheck("isEnabled");
			method qscrll_f = QScrollBar.__N.QScrll_f18;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000E99 RID: 3737 RVA: 0x0002769C File Offset: 0x0002589C
		internal readonly void setEnabled(bool x)
		{
			this.NullCheck("setEnabled");
			method qscrll_f = QScrollBar.__N.QScrll_f19;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x ? 1 : 0, qscrll_f);
		}

		// Token: 0x06000E9A RID: 3738 RVA: 0x000276D0 File Offset: 0x000258D0
		internal readonly void setVisible(bool visible)
		{
			this.NullCheck("setVisible");
			method qscrll_f = QScrollBar.__N.QScrll_f20;
			calli(System.Void(System.IntPtr,System.Int32), this.self, visible ? 1 : 0, qscrll_f);
		}

		// Token: 0x06000E9B RID: 3739 RVA: 0x00027704 File Offset: 0x00025904
		internal readonly void setHidden(bool hidden)
		{
			this.NullCheck("setHidden");
			method qscrll_f = QScrollBar.__N.QScrll_f21;
			calli(System.Void(System.IntPtr,System.Int32), this.self, hidden ? 1 : 0, qscrll_f);
		}

		// Token: 0x06000E9C RID: 3740 RVA: 0x00027738 File Offset: 0x00025938
		internal readonly void show()
		{
			this.NullCheck("show");
			method qscrll_f = QScrollBar.__N.QScrll_f22;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000E9D RID: 3741 RVA: 0x00027764 File Offset: 0x00025964
		internal readonly void hide()
		{
			this.NullCheck("hide");
			method qscrll_f = QScrollBar.__N.QScrll_f23;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000E9E RID: 3742 RVA: 0x00027790 File Offset: 0x00025990
		internal readonly void showMinimized()
		{
			this.NullCheck("showMinimized");
			method qscrll_f = QScrollBar.__N.QScrll_f24;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000E9F RID: 3743 RVA: 0x000277BC File Offset: 0x000259BC
		internal readonly void showMaximized()
		{
			this.NullCheck("showMaximized");
			method qscrll_f = QScrollBar.__N.QScrll_f25;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EA0 RID: 3744 RVA: 0x000277E8 File Offset: 0x000259E8
		internal readonly void showFullScreen()
		{
			this.NullCheck("showFullScreen");
			method qscrll_f = QScrollBar.__N.QScrll_f26;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EA1 RID: 3745 RVA: 0x00027814 File Offset: 0x00025A14
		internal readonly void showNormal()
		{
			this.NullCheck("showNormal");
			method qscrll_f = QScrollBar.__N.QScrll_f27;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EA2 RID: 3746 RVA: 0x00027840 File Offset: 0x00025A40
		internal readonly bool close()
		{
			this.NullCheck("close");
			method qscrll_f = QScrollBar.__N.QScrll_f28;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EA3 RID: 3747 RVA: 0x00027870 File Offset: 0x00025A70
		internal readonly void raise()
		{
			this.NullCheck("raise");
			method qscrll_f = QScrollBar.__N.QScrll_f29;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EA4 RID: 3748 RVA: 0x0002789C File Offset: 0x00025A9C
		internal readonly void lower()
		{
			this.NullCheck("lower");
			method qscrll_f = QScrollBar.__N.QScrll_f30;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EA5 RID: 3749 RVA: 0x000278C8 File Offset: 0x00025AC8
		internal readonly bool isVisible()
		{
			this.NullCheck("isVisible");
			method qscrll_f = QScrollBar.__N.QScrll_f31;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EA6 RID: 3750 RVA: 0x000278F8 File Offset: 0x00025AF8
		internal readonly void setAttribute(Widget.Flag a, bool on)
		{
			this.NullCheck("setAttribute");
			method qscrll_f = QScrollBar.__N.QScrll_f32;
			calli(System.Void(System.IntPtr,System.Int64,System.Int32), this.self, (long)a, on ? 1 : 0, qscrll_f);
		}

		// Token: 0x06000EA7 RID: 3751 RVA: 0x0002792C File Offset: 0x00025B2C
		internal readonly bool testAttribute(Widget.Flag a)
		{
			this.NullCheck("testAttribute");
			method qscrll_f = QScrollBar.__N.QScrll_f33;
			return calli(System.Int32(System.IntPtr,System.Int64), this.self, (long)a, qscrll_f) > 0;
		}

		// Token: 0x06000EA8 RID: 3752 RVA: 0x0002795C File Offset: 0x00025B5C
		internal readonly bool acceptDrops()
		{
			this.NullCheck("acceptDrops");
			method qscrll_f = QScrollBar.__N.QScrll_f34;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EA9 RID: 3753 RVA: 0x0002798C File Offset: 0x00025B8C
		internal readonly void setAcceptDrops(bool on)
		{
			this.NullCheck("setAcceptDrops");
			method qscrll_f = QScrollBar.__N.QScrll_f35;
			calli(System.Void(System.IntPtr,System.Int32), this.self, on ? 1 : 0, qscrll_f);
		}

		// Token: 0x06000EAA RID: 3754 RVA: 0x000279C0 File Offset: 0x00025BC0
		internal readonly void update()
		{
			this.NullCheck("update");
			method qscrll_f = QScrollBar.__N.QScrll_f36;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EAB RID: 3755 RVA: 0x000279EC File Offset: 0x00025BEC
		internal readonly void repaint()
		{
			this.NullCheck("repaint");
			method qscrll_f = QScrollBar.__N.QScrll_f37;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EAC RID: 3756 RVA: 0x00027A18 File Offset: 0x00025C18
		internal readonly void setCursor(CursorShape shape)
		{
			this.NullCheck("setCursor");
			method qscrll_f = QScrollBar.__N.QScrll_f38;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)shape, qscrll_f);
		}

		// Token: 0x06000EAD RID: 3757 RVA: 0x00027A44 File Offset: 0x00025C44
		internal readonly void unsetCursor()
		{
			this.NullCheck("unsetCursor");
			method qscrll_f = QScrollBar.__N.QScrll_f39;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EAE RID: 3758 RVA: 0x00027A70 File Offset: 0x00025C70
		internal readonly void setWindowIcon(string icon)
		{
			this.NullCheck("setWindowIcon");
			method qscrll_f = QScrollBar.__N.QScrll_f40;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(icon), qscrll_f);
		}

		// Token: 0x06000EAF RID: 3759 RVA: 0x00027AA0 File Offset: 0x00025CA0
		internal readonly void setWindowIconText(string str)
		{
			this.NullCheck("setWindowIconText");
			method qscrll_f = QScrollBar.__N.QScrll_f41;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qscrll_f);
		}

		// Token: 0x06000EB0 RID: 3760 RVA: 0x00027AD0 File Offset: 0x00025CD0
		internal readonly void setWindowOpacity(float level)
		{
			this.NullCheck("setWindowOpacity");
			method qscrll_f = QScrollBar.__N.QScrll_f42;
			calli(System.Void(System.IntPtr,System.Single), this.self, level, qscrll_f);
		}

		// Token: 0x06000EB1 RID: 3761 RVA: 0x00027AFC File Offset: 0x00025CFC
		internal readonly float windowOpacity()
		{
			this.NullCheck("windowOpacity");
			method qscrll_f = QScrollBar.__N.QScrll_f43;
			return calli(System.Single(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EB2 RID: 3762 RVA: 0x00027B28 File Offset: 0x00025D28
		internal readonly bool isMinimized()
		{
			this.NullCheck("isMinimized");
			method qscrll_f = QScrollBar.__N.QScrll_f44;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EB3 RID: 3763 RVA: 0x00027B58 File Offset: 0x00025D58
		internal readonly bool isMaximized()
		{
			this.NullCheck("isMaximized");
			method qscrll_f = QScrollBar.__N.QScrll_f45;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EB4 RID: 3764 RVA: 0x00027B88 File Offset: 0x00025D88
		internal readonly bool isFullScreen()
		{
			this.NullCheck("isFullScreen");
			method qscrll_f = QScrollBar.__N.QScrll_f46;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EB5 RID: 3765 RVA: 0x00027BB8 File Offset: 0x00025DB8
		internal readonly void setMouseTracking(bool enable)
		{
			this.NullCheck("setMouseTracking");
			method qscrll_f = QScrollBar.__N.QScrll_f47;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qscrll_f);
		}

		// Token: 0x06000EB6 RID: 3766 RVA: 0x00027BEC File Offset: 0x00025DEC
		internal readonly bool hasMouseTracking()
		{
			this.NullCheck("hasMouseTracking");
			method qscrll_f = QScrollBar.__N.QScrll_f48;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EB7 RID: 3767 RVA: 0x00027C1C File Offset: 0x00025E1C
		internal readonly bool underMouse()
		{
			this.NullCheck("underMouse");
			method qscrll_f = QScrollBar.__N.QScrll_f49;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EB8 RID: 3768 RVA: 0x00027C4C File Offset: 0x00025E4C
		internal readonly Vector3 mapToGlobal(Vector3 p)
		{
			this.NullCheck("mapToGlobal");
			method qscrll_f = QScrollBar.__N.QScrll_f50;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qscrll_f);
		}

		// Token: 0x06000EB9 RID: 3769 RVA: 0x00027C78 File Offset: 0x00025E78
		internal readonly Vector3 mapFromGlobal(Vector3 p)
		{
			this.NullCheck("mapFromGlobal");
			method qscrll_f = QScrollBar.__N.QScrll_f51;
			return calli(Vector3(System.IntPtr,Vector3), this.self, p, qscrll_f);
		}

		// Token: 0x06000EBA RID: 3770 RVA: 0x00027CA4 File Offset: 0x00025EA4
		internal readonly bool hasFocus()
		{
			this.NullCheck("hasFocus");
			method qscrll_f = QScrollBar.__N.QScrll_f52;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EBB RID: 3771 RVA: 0x00027CD4 File Offset: 0x00025ED4
		internal readonly FocusMode focusPolicy()
		{
			this.NullCheck("focusPolicy");
			method qscrll_f = QScrollBar.__N.QScrll_f53;
			return calli(System.Int64(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EBC RID: 3772 RVA: 0x00027D00 File Offset: 0x00025F00
		internal readonly void setFocusPolicy(FocusMode policy)
		{
			this.NullCheck("setFocusPolicy");
			method qscrll_f = QScrollBar.__N.QScrll_f54;
			calli(System.Void(System.IntPtr,System.Int64), this.self, (long)policy, qscrll_f);
		}

		// Token: 0x06000EBD RID: 3773 RVA: 0x00027D2C File Offset: 0x00025F2C
		internal readonly void setFocusProxy(QWidget widget)
		{
			this.NullCheck("setFocusProxy");
			method qscrll_f = QScrollBar.__N.QScrll_f55;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, widget, qscrll_f);
		}

		// Token: 0x06000EBE RID: 3774 RVA: 0x00027D5C File Offset: 0x00025F5C
		internal readonly bool isActiveWindow()
		{
			this.NullCheck("isActiveWindow");
			method qscrll_f = QScrollBar.__N.QScrll_f56;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EBF RID: 3775 RVA: 0x00027D8C File Offset: 0x00025F8C
		internal readonly bool updatesEnabled()
		{
			this.NullCheck("updatesEnabled");
			method qscrll_f = QScrollBar.__N.QScrll_f57;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000EC0 RID: 3776 RVA: 0x00027DBC File Offset: 0x00025FBC
		internal readonly void setUpdatesEnabled(bool enable)
		{
			this.NullCheck("setUpdatesEnabled");
			method qscrll_f = QScrollBar.__N.QScrll_f58;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enable ? 1 : 0, qscrll_f);
		}

		// Token: 0x06000EC1 RID: 3777 RVA: 0x00027DF0 File Offset: 0x00025FF0
		internal readonly void setFocus()
		{
			this.NullCheck("setFocus");
			method qscrll_f = QScrollBar.__N.QScrll_f59;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EC2 RID: 3778 RVA: 0x00027E1C File Offset: 0x0002601C
		internal readonly void activateWindow()
		{
			this.NullCheck("activateWindow");
			method qscrll_f = QScrollBar.__N.QScrll_f60;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EC3 RID: 3779 RVA: 0x00027E48 File Offset: 0x00026048
		internal readonly void clearFocus()
		{
			this.NullCheck("clearFocus");
			method qscrll_f = QScrollBar.__N.QScrll_f61;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EC4 RID: 3780 RVA: 0x00027E74 File Offset: 0x00026074
		internal readonly void setSizePolicy(SizeMode x, SizeMode y)
		{
			this.NullCheck("setSizePolicy");
			method qscrll_f = QScrollBar.__N.QScrll_f62;
			calli(System.Void(System.IntPtr,System.Int64,System.Int64), this.self, (long)x, (long)y, qscrll_f);
		}

		// Token: 0x06000EC5 RID: 3781 RVA: 0x00027EA4 File Offset: 0x000260A4
		internal readonly float devicePixelRatioF()
		{
			this.NullCheck("devicePixelRatioF");
			method qscrll_f = QScrollBar.__N.QScrll_f63;
			return calli(System.Single(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000EC6 RID: 3782 RVA: 0x00027ED0 File Offset: 0x000260D0
		internal readonly string saveGeometry()
		{
			this.NullCheck("saveGeometry");
			method qscrll_f = QScrollBar.__N.QScrll_f64;
			return Interop.GetString(calli(System.IntPtr(System.IntPtr), this.self, qscrll_f));
		}

		// Token: 0x06000EC7 RID: 3783 RVA: 0x00027F00 File Offset: 0x00026100
		internal readonly bool restoreGeometry(string state)
		{
			this.NullCheck("restoreGeometry");
			method qscrll_f = QScrollBar.__N.QScrll_f65;
			return calli(System.Int32(System.IntPtr,System.IntPtr), this.self, Interop.GetPointer(state), qscrll_f) > 0;
		}

		// Token: 0x06000EC8 RID: 3784 RVA: 0x00027F34 File Offset: 0x00026134
		internal readonly void addAction(QAction action)
		{
			this.NullCheck("addAction");
			method qscrll_f = QScrollBar.__N.QScrll_f66;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qscrll_f);
		}

		// Token: 0x06000EC9 RID: 3785 RVA: 0x00027F64 File Offset: 0x00026164
		internal readonly void removeAction(QAction action)
		{
			this.NullCheck("removeAction");
			method qscrll_f = QScrollBar.__N.QScrll_f67;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, action, qscrll_f);
		}

		// Token: 0x06000ECA RID: 3786 RVA: 0x00027F94 File Offset: 0x00026194
		internal readonly void setParent(QWidget parent)
		{
			this.NullCheck("setParent");
			method qscrll_f = QScrollBar.__N.QScrll_f68;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, parent, qscrll_f);
		}

		// Token: 0x06000ECB RID: 3787 RVA: 0x00027FC4 File Offset: 0x000261C4
		internal readonly QWidget parentWidget()
		{
			this.NullCheck("parentWidget");
			method qscrll_f = QScrollBar.__N.QScrll_f69;
			return calli(System.IntPtr(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000ECC RID: 3788 RVA: 0x00027FF4 File Offset: 0x000261F4
		internal readonly void AddClassName(string name)
		{
			this.NullCheck("AddClassName");
			method qscrll_f = QScrollBar.__N.QScrll_f70;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(name), qscrll_f);
		}

		// Token: 0x06000ECD RID: 3789 RVA: 0x00028024 File Offset: 0x00026224
		internal readonly void Polish()
		{
			this.NullCheck("Polish");
			method qscrll_f = QScrollBar.__N.QScrll_f71;
			calli(System.Void(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000ECE RID: 3790 RVA: 0x00028050 File Offset: 0x00026250
		internal readonly string toolTip()
		{
			this.NullCheck("toolTip");
			method qscrll_f = QScrollBar.__N.QScrll_f72;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qscrll_f));
		}

		// Token: 0x06000ECF RID: 3791 RVA: 0x00028080 File Offset: 0x00026280
		internal readonly void setToolTip(string str)
		{
			this.NullCheck("setToolTip");
			method qscrll_f = QScrollBar.__N.QScrll_f73;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qscrll_f);
		}

		// Token: 0x06000ED0 RID: 3792 RVA: 0x000280B0 File Offset: 0x000262B0
		internal readonly string statusTip()
		{
			this.NullCheck("statusTip");
			method qscrll_f = QScrollBar.__N.QScrll_f74;
			return Interop.GetWString(calli(System.IntPtr(System.IntPtr), this.self, qscrll_f));
		}

		// Token: 0x06000ED1 RID: 3793 RVA: 0x000280E0 File Offset: 0x000262E0
		internal readonly void setStatusTip(string str)
		{
			this.NullCheck("setStatusTip");
			method qscrll_f = QScrollBar.__N.QScrll_f75;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, Interop.GetWPointer(str), qscrll_f);
		}

		// Token: 0x06000ED2 RID: 3794 RVA: 0x00028110 File Offset: 0x00026310
		internal readonly int toolTipDuration()
		{
			this.NullCheck("toolTipDuration");
			method qscrll_f = QScrollBar.__N.QScrll_f76;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f);
		}

		// Token: 0x06000ED3 RID: 3795 RVA: 0x0002813C File Offset: 0x0002633C
		internal readonly void setToolTipDuration(int x)
		{
			this.NullCheck("setToolTipDuration");
			method qscrll_f = QScrollBar.__N.QScrll_f77;
			calli(System.Void(System.IntPtr,System.Int32), this.self, x, qscrll_f);
		}

		// Token: 0x06000ED4 RID: 3796 RVA: 0x00028168 File Offset: 0x00026368
		internal readonly bool autoFillBackground()
		{
			this.NullCheck("autoFillBackground");
			method qscrll_f = QScrollBar.__N.QScrll_f78;
			return calli(System.Int32(System.IntPtr), this.self, qscrll_f) > 0;
		}

		// Token: 0x06000ED5 RID: 3797 RVA: 0x00028198 File Offset: 0x00026398
		internal readonly void setAutoFillBackground(bool enabled)
		{
			this.NullCheck("setAutoFillBackground");
			method qscrll_f = QScrollBar.__N.QScrll_f79;
			calli(System.Void(System.IntPtr,System.Int32), this.self, enabled ? 1 : 0, qscrll_f);
		}

		// Token: 0x04000064 RID: 100
		internal IntPtr self;

		// Token: 0x02000125 RID: 293
		internal static class __N
		{
			// Token: 0x04001000 RID: 4096
			internal static method From_QWidget_To_QScrollBar;

			// Token: 0x04001001 RID: 4097
			internal static method To_QWidget_From_QScrollBar;

			// Token: 0x04001002 RID: 4098
			internal static method From_QObject_To_QScrollBar;

			// Token: 0x04001003 RID: 4099
			internal static method To_QObject_From_QScrollBar;

			// Token: 0x04001004 RID: 4100
			internal static method QScrll_setMinimum;

			// Token: 0x04001005 RID: 4101
			internal static method QScrll_minimum;

			// Token: 0x04001006 RID: 4102
			internal static method QScrll_setMaximum;

			// Token: 0x04001007 RID: 4103
			internal static method QScrll_maximum;

			// Token: 0x04001008 RID: 4104
			internal static method QScrll_setSingleStep;

			// Token: 0x04001009 RID: 4105
			internal static method QScrll_singleStep;

			// Token: 0x0400100A RID: 4106
			internal static method QScrll_setPageStep;

			// Token: 0x0400100B RID: 4107
			internal static method QScrll_pageStep;

			// Token: 0x0400100C RID: 4108
			internal static method QScrll_setTracking;

			// Token: 0x0400100D RID: 4109
			internal static method QScrll_hasTracking;

			// Token: 0x0400100E RID: 4110
			internal static method QScrll_setSliderDown;

			// Token: 0x0400100F RID: 4111
			internal static method QScrll_isSliderDown;

			// Token: 0x04001010 RID: 4112
			internal static method QScrll_setSliderPosition;

			// Token: 0x04001011 RID: 4113
			internal static method QScrll_sliderPosition;

			// Token: 0x04001012 RID: 4114
			internal static method QScrll_setInvertedAppearance;

			// Token: 0x04001013 RID: 4115
			internal static method QScrll_invertedAppearance;

			// Token: 0x04001014 RID: 4116
			internal static method QScrll_setInvertedControls;

			// Token: 0x04001015 RID: 4117
			internal static method QScrll_invertedControls;

			// Token: 0x04001016 RID: 4118
			internal static method QScrll_f2;

			// Token: 0x04001017 RID: 4119
			internal static method QScrll_f3;

			// Token: 0x04001018 RID: 4120
			internal static method QScrll_f4;

			// Token: 0x04001019 RID: 4121
			internal static method QScrll_f5;

			// Token: 0x0400101A RID: 4122
			internal static method QScrll_f6;

			// Token: 0x0400101B RID: 4123
			internal static method QScrll_f7;

			// Token: 0x0400101C RID: 4124
			internal static method QScrll_f8;

			// Token: 0x0400101D RID: 4125
			internal static method QScrll_f9;

			// Token: 0x0400101E RID: 4126
			internal static method QScrll_f10;

			// Token: 0x0400101F RID: 4127
			internal static method QScrll_f11;

			// Token: 0x04001020 RID: 4128
			internal static method QScrll_f12;

			// Token: 0x04001021 RID: 4129
			internal static method QScrll_f13;

			// Token: 0x04001022 RID: 4130
			internal static method QScrll_f14;

			// Token: 0x04001023 RID: 4131
			internal static method QScrll_f15;

			// Token: 0x04001024 RID: 4132
			internal static method QScrll_f16;

			// Token: 0x04001025 RID: 4133
			internal static method QScrll_f17;

			// Token: 0x04001026 RID: 4134
			internal static method QScrll_f18;

			// Token: 0x04001027 RID: 4135
			internal static method QScrll_f19;

			// Token: 0x04001028 RID: 4136
			internal static method QScrll_f20;

			// Token: 0x04001029 RID: 4137
			internal static method QScrll_f21;

			// Token: 0x0400102A RID: 4138
			internal static method QScrll_f22;

			// Token: 0x0400102B RID: 4139
			internal static method QScrll_f23;

			// Token: 0x0400102C RID: 4140
			internal static method QScrll_f24;

			// Token: 0x0400102D RID: 4141
			internal static method QScrll_f25;

			// Token: 0x0400102E RID: 4142
			internal static method QScrll_f26;

			// Token: 0x0400102F RID: 4143
			internal static method QScrll_f27;

			// Token: 0x04001030 RID: 4144
			internal static method QScrll_f28;

			// Token: 0x04001031 RID: 4145
			internal static method QScrll_f29;

			// Token: 0x04001032 RID: 4146
			internal static method QScrll_f30;

			// Token: 0x04001033 RID: 4147
			internal static method QScrll_f31;

			// Token: 0x04001034 RID: 4148
			internal static method QScrll_f32;

			// Token: 0x04001035 RID: 4149
			internal static method QScrll_f33;

			// Token: 0x04001036 RID: 4150
			internal static method QScrll_f34;

			// Token: 0x04001037 RID: 4151
			internal static method QScrll_f35;

			// Token: 0x04001038 RID: 4152
			internal static method QScrll_f36;

			// Token: 0x04001039 RID: 4153
			internal static method QScrll_f37;

			// Token: 0x0400103A RID: 4154
			internal static method QScrll_f38;

			// Token: 0x0400103B RID: 4155
			internal static method QScrll_f39;

			// Token: 0x0400103C RID: 4156
			internal static method QScrll_f40;

			// Token: 0x0400103D RID: 4157
			internal static method QScrll_f41;

			// Token: 0x0400103E RID: 4158
			internal static method QScrll_f42;

			// Token: 0x0400103F RID: 4159
			internal static method QScrll_f43;

			// Token: 0x04001040 RID: 4160
			internal static method QScrll_f44;

			// Token: 0x04001041 RID: 4161
			internal static method QScrll_f45;

			// Token: 0x04001042 RID: 4162
			internal static method QScrll_f46;

			// Token: 0x04001043 RID: 4163
			internal static method QScrll_f47;

			// Token: 0x04001044 RID: 4164
			internal static method QScrll_f48;

			// Token: 0x04001045 RID: 4165
			internal static method QScrll_f49;

			// Token: 0x04001046 RID: 4166
			internal static method QScrll_f50;

			// Token: 0x04001047 RID: 4167
			internal static method QScrll_f51;

			// Token: 0x04001048 RID: 4168
			internal static method QScrll_f52;

			// Token: 0x04001049 RID: 4169
			internal static method QScrll_f53;

			// Token: 0x0400104A RID: 4170
			internal static method QScrll_f54;

			// Token: 0x0400104B RID: 4171
			internal static method QScrll_f55;

			// Token: 0x0400104C RID: 4172
			internal static method QScrll_f56;

			// Token: 0x0400104D RID: 4173
			internal static method QScrll_f57;

			// Token: 0x0400104E RID: 4174
			internal static method QScrll_f58;

			// Token: 0x0400104F RID: 4175
			internal static method QScrll_f59;

			// Token: 0x04001050 RID: 4176
			internal static method QScrll_f60;

			// Token: 0x04001051 RID: 4177
			internal static method QScrll_f61;

			// Token: 0x04001052 RID: 4178
			internal static method QScrll_f62;

			// Token: 0x04001053 RID: 4179
			internal static method QScrll_f63;

			// Token: 0x04001054 RID: 4180
			internal static method QScrll_f64;

			// Token: 0x04001055 RID: 4181
			internal static method QScrll_f65;

			// Token: 0x04001056 RID: 4182
			internal static method QScrll_f66;

			// Token: 0x04001057 RID: 4183
			internal static method QScrll_f67;

			// Token: 0x04001058 RID: 4184
			internal static method QScrll_f68;

			// Token: 0x04001059 RID: 4185
			internal static method QScrll_f69;

			// Token: 0x0400105A RID: 4186
			internal static method QScrll_f70;

			// Token: 0x0400105B RID: 4187
			internal static method QScrll_f71;

			// Token: 0x0400105C RID: 4188
			internal static method QScrll_f72;

			// Token: 0x0400105D RID: 4189
			internal static method QScrll_f73;

			// Token: 0x0400105E RID: 4190
			internal static method QScrll_f74;

			// Token: 0x0400105F RID: 4191
			internal static method QScrll_f75;

			// Token: 0x04001060 RID: 4192
			internal static method QScrll_f76;

			// Token: 0x04001061 RID: 4193
			internal static method QScrll_f77;

			// Token: 0x04001062 RID: 4194
			internal static method QScrll_f78;

			// Token: 0x04001063 RID: 4195
			internal static method QScrll_f79;
		}
	}
}
