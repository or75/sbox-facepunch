using System;
using Facebook.Yoga;

namespace Sandbox.UI
{
	// Token: 0x02000152 RID: 338
	internal sealed class YogaWrapper
	{
		// Token: 0x0600197E RID: 6526 RVA: 0x0006B23C File Offset: 0x0006943C
		public YogaWrapper()
		{
			this.YogaNode = new YogaNode(null);
		}

		// Token: 0x0600197F RID: 6527 RVA: 0x0006B250 File Offset: 0x00069450
		public void Dispose()
		{
			YogaNode yogaNode = this.YogaNode;
			if (yogaNode != null)
			{
				yogaNode.Clear();
			}
			YogaNode yogaNode2 = this.YogaNode;
			if (yogaNode2 != null)
			{
				yogaNode2.SetBaselineFunction(null);
			}
			YogaNode yogaNode3 = this.YogaNode;
			if (yogaNode3 != null)
			{
				yogaNode3.SetMeasureFunction(null);
			}
			this.YogaNode = null;
		}

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06001980 RID: 6528 RVA: 0x0006B290 File Offset: 0x00069490
		public Rect YogaRect
		{
			get
			{
				if (!this.YogaNode.HasNewLayout)
				{
					return this._yogaRect;
				}
				this.YogaNode.MarkLayoutSeen();
				this._yogaRect = new Rect(this.YogaNode.LayoutX, this.YogaNode.LayoutY, this.YogaNode.LayoutWidth, this.YogaNode.LayoutHeight);
				this.Margin.left = this.YogaNode.LayoutMarginLeft;
				this.Margin.right = this.YogaNode.LayoutMarginRight;
				this.Margin.top = this.YogaNode.LayoutMarginTop;
				this.Margin.bottom = this.YogaNode.LayoutMarginBottom;
				this.Padding.left = this.YogaNode.LayoutPaddingLeft;
				this.Padding.right = this.YogaNode.LayoutPaddingRight;
				this.Padding.top = this.YogaNode.LayoutPaddingTop;
				this.Padding.bottom = this.YogaNode.LayoutPaddingBottom;
				this.Border.left = this.YogaNode.BorderLeftWidth;
				this.Border.right = this.YogaNode.BorderRightWidth;
				this.Border.top = this.YogaNode.BorderTopWidth;
				this.Border.bottom = this.YogaNode.BorderBottomWidth;
				return this._yogaRect;
			}
		}

		// Token: 0x17000443 RID: 1091
		// (get) Token: 0x06001981 RID: 6529 RVA: 0x0006B401 File Offset: 0x00069601
		internal bool IsMeasureDefined
		{
			get
			{
				return this.YogaNode.IsMeasureDefined;
			}
		}

		// Token: 0x06001982 RID: 6530 RVA: 0x0006B40E File Offset: 0x0006960E
		internal void SetMeasureFunction(MeasureFunction measureText)
		{
			this.YogaNode.SetMeasureFunction(measureText);
		}

		// Token: 0x06001983 RID: 6531 RVA: 0x0006B41C File Offset: 0x0006961C
		internal void RemoveChild(YogaWrapper yogaNode)
		{
			this.YogaNode.RemoveChild(yogaNode.YogaNode);
		}

		// Token: 0x06001984 RID: 6532 RVA: 0x0006B42F File Offset: 0x0006962F
		internal void AddChild(YogaWrapper yogaNode)
		{
			this.YogaNode.AddChild(yogaNode.YogaNode);
		}

		// Token: 0x06001985 RID: 6533 RVA: 0x0006B442 File Offset: 0x00069642
		internal void CalculateLayout()
		{
			this.YogaNode.CalculateLayout();
		}

		// Token: 0x06001986 RID: 6534 RVA: 0x0006B44F File Offset: 0x0006964F
		internal void MarkDirty()
		{
			this.YogaNode.MarkDirty();
		}

		// Token: 0x17000444 RID: 1092
		// (set) Token: 0x06001987 RID: 6535 RVA: 0x0006B45C File Offset: 0x0006965C
		public Length? Width
		{
			set
			{
				if (this.Initialized && this._width == value)
				{
					return;
				}
				this._width = value;
				this.YogaNode.Width = (ref this._width).ToYoga();
			}
		}

		// Token: 0x17000445 RID: 1093
		// (set) Token: 0x06001988 RID: 6536 RVA: 0x0006B492 File Offset: 0x00069692
		public Length? Height
		{
			set
			{
				if (this.Initialized && this._height == value)
				{
					return;
				}
				this._height = value;
				this.YogaNode.Height = (ref this._height).ToYoga();
			}
		}

		// Token: 0x17000446 RID: 1094
		// (set) Token: 0x06001989 RID: 6537 RVA: 0x0006B4C8 File Offset: 0x000696C8
		public Length? MaxWidth
		{
			set
			{
				if (this.Initialized && this._maxwidth == value)
				{
					return;
				}
				this._maxwidth = value;
				this.YogaNode.MaxWidth = (ref this._maxwidth).ToYoga();
			}
		}

		// Token: 0x17000447 RID: 1095
		// (set) Token: 0x0600198A RID: 6538 RVA: 0x0006B4FE File Offset: 0x000696FE
		public Length? MaxHeight
		{
			set
			{
				if (this.Initialized && this._maxheight == value)
				{
					return;
				}
				this._maxheight = value;
				this.YogaNode.MaxHeight = (ref this._maxheight).ToYoga();
			}
		}

		// Token: 0x17000448 RID: 1096
		// (set) Token: 0x0600198B RID: 6539 RVA: 0x0006B534 File Offset: 0x00069734
		public Length? MinWidth
		{
			set
			{
				if (this.Initialized && this._minwidth == value)
				{
					return;
				}
				this._minwidth = value;
				this.YogaNode.MinWidth = (ref this._minwidth).ToYoga();
			}
		}

		// Token: 0x17000449 RID: 1097
		// (set) Token: 0x0600198C RID: 6540 RVA: 0x0006B56A File Offset: 0x0006976A
		public Length? MinHeight
		{
			set
			{
				if (this.Initialized && this._minheight == value)
				{
					return;
				}
				this._minheight = value;
				this.YogaNode.MinHeight = (ref this._minheight).ToYoga();
			}
		}

		// Token: 0x1700044A RID: 1098
		// (set) Token: 0x0600198D RID: 6541 RVA: 0x0006B5A0 File Offset: 0x000697A0
		public DisplayMode? Display
		{
			set
			{
				if (this.Initialized)
				{
					DisplayMode? display = this._display;
					DisplayMode? displayMode = value;
					if ((display.GetValueOrDefault() == displayMode.GetValueOrDefault()) & (display != null == (displayMode != null)))
					{
						return;
					}
				}
				this._display = value;
				this.YogaNode.Display = this._display.ToYoga();
			}
		}

		// Token: 0x1700044B RID: 1099
		// (set) Token: 0x0600198E RID: 6542 RVA: 0x0006B5FF File Offset: 0x000697FF
		public Length? Left
		{
			set
			{
				if (this.Initialized && this._left == value)
				{
					return;
				}
				this._left = value;
				this.YogaNode.Left = (ref this._left).ToYoga();
			}
		}

		// Token: 0x1700044C RID: 1100
		// (set) Token: 0x0600198F RID: 6543 RVA: 0x0006B635 File Offset: 0x00069835
		public Length? Right
		{
			set
			{
				if (this.Initialized && this._right == value)
				{
					return;
				}
				this._right = value;
				this.YogaNode.Right = (ref this._right).ToYoga();
			}
		}

		// Token: 0x1700044D RID: 1101
		// (set) Token: 0x06001990 RID: 6544 RVA: 0x0006B66B File Offset: 0x0006986B
		public Length? Top
		{
			set
			{
				if (this.Initialized && this._top == value)
				{
					return;
				}
				this._top = value;
				this.YogaNode.Top = (ref this._top).ToYoga();
			}
		}

		// Token: 0x1700044E RID: 1102
		// (set) Token: 0x06001991 RID: 6545 RVA: 0x0006B6A1 File Offset: 0x000698A1
		public Length? Bottom
		{
			set
			{
				if (this.Initialized && this._bottom == value)
				{
					return;
				}
				this._bottom = value;
				this.YogaNode.Bottom = (ref this._bottom).ToYoga();
			}
		}

		// Token: 0x1700044F RID: 1103
		// (set) Token: 0x06001992 RID: 6546 RVA: 0x0006B6D7 File Offset: 0x000698D7
		public Length? MarginLeft
		{
			set
			{
				if (this.Initialized && this._marginleft == value)
				{
					return;
				}
				this._marginleft = value;
				this.YogaNode.MarginLeft = (ref this._marginleft).ToYoga();
			}
		}

		// Token: 0x17000450 RID: 1104
		// (set) Token: 0x06001993 RID: 6547 RVA: 0x0006B70D File Offset: 0x0006990D
		public Length? MarginRight
		{
			set
			{
				if (this.Initialized && this._marginright == value)
				{
					return;
				}
				this._marginright = value;
				this.YogaNode.MarginRight = (ref this._marginright).ToYoga();
			}
		}

		// Token: 0x17000451 RID: 1105
		// (set) Token: 0x06001994 RID: 6548 RVA: 0x0006B743 File Offset: 0x00069943
		public Length? MarginTop
		{
			set
			{
				if (this.Initialized && this._margintop == value)
				{
					return;
				}
				this._margintop = value;
				this.YogaNode.MarginTop = (ref this._margintop).ToYoga();
			}
		}

		// Token: 0x17000452 RID: 1106
		// (set) Token: 0x06001995 RID: 6549 RVA: 0x0006B779 File Offset: 0x00069979
		public Length? MarginBottom
		{
			set
			{
				if (this.Initialized && this._marginbottom == value)
				{
					return;
				}
				this._marginbottom = value;
				this.YogaNode.MarginBottom = (ref this._marginbottom).ToYoga();
			}
		}

		// Token: 0x17000453 RID: 1107
		// (set) Token: 0x06001996 RID: 6550 RVA: 0x0006B7AF File Offset: 0x000699AF
		public Length? PaddingLeft
		{
			set
			{
				if (this.Initialized && this._paddingleft == value)
				{
					return;
				}
				this._paddingleft = value;
				this.YogaNode.PaddingLeft = (ref this._paddingleft).ToYoga();
			}
		}

		// Token: 0x17000454 RID: 1108
		// (set) Token: 0x06001997 RID: 6551 RVA: 0x0006B7E5 File Offset: 0x000699E5
		public Length? PaddingRight
		{
			set
			{
				if (this.Initialized && this._paddingright == value)
				{
					return;
				}
				this._paddingright = value;
				this.YogaNode.PaddingRight = (ref this._paddingright).ToYoga();
			}
		}

		// Token: 0x17000455 RID: 1109
		// (set) Token: 0x06001998 RID: 6552 RVA: 0x0006B81B File Offset: 0x00069A1B
		public Length? PaddingTop
		{
			set
			{
				if (this.Initialized && this._paddingtop == value)
				{
					return;
				}
				this._paddingtop = value;
				this.YogaNode.PaddingTop = (ref this._paddingtop).ToYoga();
			}
		}

		// Token: 0x17000456 RID: 1110
		// (set) Token: 0x06001999 RID: 6553 RVA: 0x0006B851 File Offset: 0x00069A51
		public Length? PaddingBottom
		{
			set
			{
				if (this.Initialized && this._paddingbottom == value)
				{
					return;
				}
				this._paddingbottom = value;
				this.YogaNode.PaddingBottom = (ref this._paddingbottom).ToYoga();
			}
		}

		// Token: 0x17000457 RID: 1111
		// (set) Token: 0x0600199A RID: 6554 RVA: 0x0006B887 File Offset: 0x00069A87
		public Length? BorderLeftWidth
		{
			set
			{
				if (this.Initialized && this._borderleft == value)
				{
					return;
				}
				this._borderleft = value;
				this.YogaNode.BorderLeftWidth = this._borderleft.ToFloat();
			}
		}

		// Token: 0x17000458 RID: 1112
		// (set) Token: 0x0600199B RID: 6555 RVA: 0x0006B8BD File Offset: 0x00069ABD
		public Length? BorderRightWidth
		{
			set
			{
				if (this.Initialized && this._borderright == value)
				{
					return;
				}
				this._borderright = value;
				this.YogaNode.BorderRightWidth = this._borderright.ToFloat();
			}
		}

		// Token: 0x17000459 RID: 1113
		// (set) Token: 0x0600199C RID: 6556 RVA: 0x0006B8F3 File Offset: 0x00069AF3
		public Length? BorderTopWidth
		{
			set
			{
				if (this.Initialized && this._bordertop == value)
				{
					return;
				}
				this._bordertop = value;
				this.YogaNode.BorderTopWidth = this._bordertop.ToFloat();
			}
		}

		// Token: 0x1700045A RID: 1114
		// (set) Token: 0x0600199D RID: 6557 RVA: 0x0006B929 File Offset: 0x00069B29
		public Length? BorderBottomWidth
		{
			set
			{
				if (this.Initialized && this._borderbottom == value)
				{
					return;
				}
				this._borderbottom = value;
				this.YogaNode.BorderBottomWidth = this._borderbottom.ToFloat();
			}
		}

		// Token: 0x1700045B RID: 1115
		// (set) Token: 0x0600199E RID: 6558 RVA: 0x0006B960 File Offset: 0x00069B60
		public PositionMode? PositionType
		{
			set
			{
				if (this.Initialized)
				{
					PositionMode? positionType = this._positionType;
					PositionMode? positionMode = value;
					if ((positionType.GetValueOrDefault() == positionMode.GetValueOrDefault()) & (positionType != null == (positionMode != null)))
					{
						return;
					}
				}
				this._positionType = value;
				this.YogaNode.PositionType = this._positionType.ToYoga();
			}
		}

		// Token: 0x1700045C RID: 1116
		// (set) Token: 0x0600199F RID: 6559 RVA: 0x0006B9C0 File Offset: 0x00069BC0
		public float? AspectRatio
		{
			set
			{
				if (this.Initialized)
				{
					float? aspectRatio = this._aspectRatio;
					float? num = value;
					if ((aspectRatio.GetValueOrDefault() == num.GetValueOrDefault()) & (aspectRatio != null == (num != null)))
					{
						return;
					}
				}
				this._aspectRatio = value;
				this.YogaNode.AspectRatio = this._aspectRatio ?? float.NaN;
			}
		}

		// Token: 0x1700045D RID: 1117
		// (set) Token: 0x060019A0 RID: 6560 RVA: 0x0006BA34 File Offset: 0x00069C34
		public float? FlexGrow
		{
			set
			{
				if (this.Initialized)
				{
					float? flexgrow = this._flexgrow;
					float? num = value;
					if ((flexgrow.GetValueOrDefault() == num.GetValueOrDefault()) & (flexgrow != null == (num != null)))
					{
						return;
					}
				}
				this._flexgrow = value;
				this.YogaNode.FlexGrow = this._flexgrow.GetValueOrDefault();
			}
		}

		// Token: 0x1700045E RID: 1118
		// (set) Token: 0x060019A1 RID: 6561 RVA: 0x0006BA94 File Offset: 0x00069C94
		public float? FlexShrink
		{
			set
			{
				if (this.Initialized)
				{
					float? flexshrink = this._flexshrink;
					float? num = value;
					if ((flexshrink.GetValueOrDefault() == num.GetValueOrDefault()) & (flexshrink != null == (num != null)))
					{
						return;
					}
				}
				this._flexshrink = value;
				this.YogaNode.FlexShrink = this._flexshrink ?? 1f;
			}
		}

		// Token: 0x1700045F RID: 1119
		// (set) Token: 0x060019A2 RID: 6562 RVA: 0x0006BB08 File Offset: 0x00069D08
		public Wrap? Wrap
		{
			set
			{
				if (this.Initialized)
				{
					Wrap? flexWrap = this._flexWrap;
					Wrap? wrap = value;
					if ((flexWrap.GetValueOrDefault() == wrap.GetValueOrDefault()) & (flexWrap != null == (wrap != null)))
					{
						return;
					}
				}
				this._flexWrap = value;
				this.YogaNode.Wrap = this._flexWrap.ToYoga();
			}
		}

		// Token: 0x17000460 RID: 1120
		// (set) Token: 0x060019A3 RID: 6563 RVA: 0x0006BB68 File Offset: 0x00069D68
		public Align? AlignContent
		{
			set
			{
				if (this.Initialized)
				{
					Align? aligncontent = this._aligncontent;
					Align? align = value;
					if ((aligncontent.GetValueOrDefault() == align.GetValueOrDefault()) & (aligncontent != null == (align != null)))
					{
						return;
					}
				}
				this._aligncontent = value;
				this.YogaNode.AlignContent = this._aligncontent.ToYoga(YogaAlign.FlexStart);
			}
		}

		// Token: 0x17000461 RID: 1121
		// (set) Token: 0x060019A4 RID: 6564 RVA: 0x0006BBC8 File Offset: 0x00069DC8
		public Align? AlignItems
		{
			set
			{
				if (this.Initialized)
				{
					Align? alignitems = this._alignitems;
					Align? align = value;
					if ((alignitems.GetValueOrDefault() == align.GetValueOrDefault()) & (alignitems != null == (align != null)))
					{
						return;
					}
				}
				this._alignitems = value;
				this.YogaNode.AlignItems = this._alignitems.ToYoga(YogaAlign.Stretch);
			}
		}

		// Token: 0x17000462 RID: 1122
		// (set) Token: 0x060019A5 RID: 6565 RVA: 0x0006BC28 File Offset: 0x00069E28
		public Align? AlignSelf
		{
			set
			{
				if (this.Initialized)
				{
					Align? alignself = this._alignself;
					Align? align = value;
					if ((alignself.GetValueOrDefault() == align.GetValueOrDefault()) & (alignself != null == (align != null)))
					{
						return;
					}
				}
				this._alignself = value;
				this.YogaNode.AlignSelf = this._alignself.ToYoga(YogaAlign.Auto);
			}
		}

		// Token: 0x17000463 RID: 1123
		// (set) Token: 0x060019A6 RID: 6566 RVA: 0x0006BC88 File Offset: 0x00069E88
		public FlexDirection? FlexDirection
		{
			set
			{
				if (this.Initialized)
				{
					FlexDirection? flexdirection = this._flexdirection;
					FlexDirection? flexDirection = value;
					if ((flexdirection.GetValueOrDefault() == flexDirection.GetValueOrDefault()) & (flexdirection != null == (flexDirection != null)))
					{
						return;
					}
				}
				this._flexdirection = value;
				this.YogaNode.FlexDirection = this._flexdirection.ToYoga();
			}
		}

		// Token: 0x17000464 RID: 1124
		// (set) Token: 0x060019A7 RID: 6567 RVA: 0x0006BCE8 File Offset: 0x00069EE8
		public Justify? JustifyContent
		{
			set
			{
				if (this.Initialized)
				{
					Justify? justifycontent = this._justifycontent;
					Justify? justify = value;
					if ((justifycontent.GetValueOrDefault() == justify.GetValueOrDefault()) & (justifycontent != null == (justify != null)))
					{
						return;
					}
				}
				this._justifycontent = value;
				this.YogaNode.JustifyContent = this._justifycontent.ToYoga();
			}
		}

		// Token: 0x17000465 RID: 1125
		// (set) Token: 0x060019A8 RID: 6568 RVA: 0x0006BD48 File Offset: 0x00069F48
		public OverflowMode? Overflow
		{
			set
			{
				if (this.Initialized)
				{
					OverflowMode? overflow = this._overflow;
					OverflowMode? overflowMode = value;
					if ((overflow.GetValueOrDefault() == overflowMode.GetValueOrDefault()) & (overflow != null == (overflowMode != null)))
					{
						return;
					}
				}
				this._overflow = value;
				this.YogaNode.Overflow = this._overflow.ToYoga();
			}
		}

		// Token: 0x040006FA RID: 1786
		public YogaNode YogaNode;

		// Token: 0x040006FB RID: 1787
		private Rect _yogaRect;

		// Token: 0x040006FC RID: 1788
		internal Margin Margin;

		// Token: 0x040006FD RID: 1789
		internal Margin Padding;

		// Token: 0x040006FE RID: 1790
		internal Margin Border;

		// Token: 0x040006FF RID: 1791
		internal bool Initialized;

		// Token: 0x04000700 RID: 1792
		private Length? _width;

		// Token: 0x04000701 RID: 1793
		private Length? _height;

		// Token: 0x04000702 RID: 1794
		private Length? _maxwidth;

		// Token: 0x04000703 RID: 1795
		private Length? _maxheight;

		// Token: 0x04000704 RID: 1796
		private Length? _minwidth;

		// Token: 0x04000705 RID: 1797
		private Length? _minheight;

		// Token: 0x04000706 RID: 1798
		private DisplayMode? _display;

		// Token: 0x04000707 RID: 1799
		private Length? _left;

		// Token: 0x04000708 RID: 1800
		private Length? _right;

		// Token: 0x04000709 RID: 1801
		private Length? _top;

		// Token: 0x0400070A RID: 1802
		private Length? _bottom;

		// Token: 0x0400070B RID: 1803
		private Length? _marginleft;

		// Token: 0x0400070C RID: 1804
		private Length? _marginright;

		// Token: 0x0400070D RID: 1805
		private Length? _margintop;

		// Token: 0x0400070E RID: 1806
		private Length? _marginbottom;

		// Token: 0x0400070F RID: 1807
		private Length? _paddingleft;

		// Token: 0x04000710 RID: 1808
		private Length? _paddingright;

		// Token: 0x04000711 RID: 1809
		private Length? _paddingtop;

		// Token: 0x04000712 RID: 1810
		private Length? _paddingbottom;

		// Token: 0x04000713 RID: 1811
		private Length? _borderleft;

		// Token: 0x04000714 RID: 1812
		private Length? _borderright;

		// Token: 0x04000715 RID: 1813
		private Length? _bordertop;

		// Token: 0x04000716 RID: 1814
		private Length? _borderbottom;

		// Token: 0x04000717 RID: 1815
		private PositionMode? _positionType;

		// Token: 0x04000718 RID: 1816
		private float? _aspectRatio;

		// Token: 0x04000719 RID: 1817
		private float? _flexgrow;

		// Token: 0x0400071A RID: 1818
		private float? _flexshrink;

		// Token: 0x0400071B RID: 1819
		private Wrap? _flexWrap;

		// Token: 0x0400071C RID: 1820
		private Align? _aligncontent;

		// Token: 0x0400071D RID: 1821
		private Align? _alignitems;

		// Token: 0x0400071E RID: 1822
		private Align? _alignself;

		// Token: 0x0400071F RID: 1823
		private FlexDirection? _flexdirection;

		// Token: 0x04000720 RID: 1824
		private Justify? _justifycontent;

		// Token: 0x04000721 RID: 1825
		private OverflowMode? _overflow;
	}
}
