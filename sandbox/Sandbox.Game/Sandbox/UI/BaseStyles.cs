using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Sandbox.Internal;

namespace Sandbox.UI
{
	// Token: 0x0200012F RID: 303
	public abstract class BaseStyles
	{
		// Token: 0x0600177F RID: 6015
		public abstract void Dirty();

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x06001780 RID: 6016 RVA: 0x0005F4B7 File Offset: 0x0005D6B7
		// (set) Token: 0x06001781 RID: 6017 RVA: 0x0005F4BF File Offset: 0x0005D6BF
		public string Content
		{
			get
			{
				return this._content;
			}
			set
			{
				if (this._content == value)
				{
					return;
				}
				this._content = value;
				this.Dirty();
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x06001782 RID: 6018 RVA: 0x0005F4DD File Offset: 0x0005D6DD
		// (set) Token: 0x06001783 RID: 6019 RVA: 0x0005F4E5 File Offset: 0x0005D6E5
		public Length? Width
		{
			get
			{
				return this._width;
			}
			set
			{
				if (this._width == value)
				{
					return;
				}
				this._width = value;
				this.Dirty();
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06001784 RID: 6020 RVA: 0x0005F503 File Offset: 0x0005D703
		// (set) Token: 0x06001785 RID: 6021 RVA: 0x0005F50B File Offset: 0x0005D70B
		public Length? MinWidth
		{
			get
			{
				return this._minwidth;
			}
			set
			{
				if (this._minwidth == value)
				{
					return;
				}
				this._minwidth = value;
				this.Dirty();
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06001786 RID: 6022 RVA: 0x0005F529 File Offset: 0x0005D729
		// (set) Token: 0x06001787 RID: 6023 RVA: 0x0005F531 File Offset: 0x0005D731
		public Length? MaxWidth
		{
			get
			{
				return this._maxwidth;
			}
			set
			{
				if (this._maxwidth == value)
				{
					return;
				}
				this._maxwidth = value;
				this.Dirty();
			}
		}

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06001788 RID: 6024 RVA: 0x0005F54F File Offset: 0x0005D74F
		// (set) Token: 0x06001789 RID: 6025 RVA: 0x0005F557 File Offset: 0x0005D757
		public Length? Height
		{
			get
			{
				return this._height;
			}
			set
			{
				if (this._height == value)
				{
					return;
				}
				this._height = value;
				this.Dirty();
			}
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x0600178A RID: 6026 RVA: 0x0005F575 File Offset: 0x0005D775
		// (set) Token: 0x0600178B RID: 6027 RVA: 0x0005F57D File Offset: 0x0005D77D
		public Length? MinHeight
		{
			get
			{
				return this._minheight;
			}
			set
			{
				if (this._minheight == value)
				{
					return;
				}
				this._minheight = value;
				this.Dirty();
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x0600178C RID: 6028 RVA: 0x0005F59B File Offset: 0x0005D79B
		// (set) Token: 0x0600178D RID: 6029 RVA: 0x0005F5A3 File Offset: 0x0005D7A3
		public Length? MaxHeight
		{
			get
			{
				return this._maxheight;
			}
			set
			{
				if (this._maxheight == value)
				{
					return;
				}
				this._maxheight = value;
				this.Dirty();
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x0600178E RID: 6030 RVA: 0x0005F5C1 File Offset: 0x0005D7C1
		// (set) Token: 0x0600178F RID: 6031 RVA: 0x0005F5C9 File Offset: 0x0005D7C9
		public Length? Left
		{
			get
			{
				return this._left;
			}
			set
			{
				if (this._left == value)
				{
					return;
				}
				this._left = value;
				this.Dirty();
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x06001790 RID: 6032 RVA: 0x0005F5E7 File Offset: 0x0005D7E7
		// (set) Token: 0x06001791 RID: 6033 RVA: 0x0005F5EF File Offset: 0x0005D7EF
		public Length? Top
		{
			get
			{
				return this._top;
			}
			set
			{
				if (this._top == value)
				{
					return;
				}
				this._top = value;
				this.Dirty();
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x06001792 RID: 6034 RVA: 0x0005F60D File Offset: 0x0005D80D
		// (set) Token: 0x06001793 RID: 6035 RVA: 0x0005F615 File Offset: 0x0005D815
		public Length? Right
		{
			get
			{
				return this._right;
			}
			set
			{
				if (this._right == value)
				{
					return;
				}
				this._right = value;
				this.Dirty();
			}
		}

		// Token: 0x170003BC RID: 956
		// (get) Token: 0x06001794 RID: 6036 RVA: 0x0005F633 File Offset: 0x0005D833
		// (set) Token: 0x06001795 RID: 6037 RVA: 0x0005F63B File Offset: 0x0005D83B
		public Length? Bottom
		{
			get
			{
				return this._bottom;
			}
			set
			{
				if (this._bottom == value)
				{
					return;
				}
				this._bottom = value;
				this.Dirty();
			}
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x06001796 RID: 6038 RVA: 0x0005F659 File Offset: 0x0005D859
		// (set) Token: 0x06001797 RID: 6039 RVA: 0x0005F664 File Offset: 0x0005D864
		public float? Opacity
		{
			get
			{
				return this._opacity;
			}
			set
			{
				float? opacity = this._opacity;
				float? num = value;
				if ((opacity.GetValueOrDefault() == num.GetValueOrDefault()) & (opacity != null == (num != null)))
				{
					return;
				}
				this._opacity = value;
				this.Dirty();
			}
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x06001798 RID: 6040 RVA: 0x0005F6AB File Offset: 0x0005D8AB
		// (set) Token: 0x06001799 RID: 6041 RVA: 0x0005F6B4 File Offset: 0x0005D8B4
		public Color? BackgroundColor
		{
			get
			{
				return this._backgroundcolor;
			}
			set
			{
				if (this._backgroundcolor == value)
				{
					return;
				}
				this._backgroundcolor = value;
				this.Dirty();
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x0600179A RID: 6042 RVA: 0x0005F70C File Offset: 0x0005D90C
		// (set) Token: 0x0600179B RID: 6043 RVA: 0x0005F714 File Offset: 0x0005D914
		public Length? PaddingLeft
		{
			get
			{
				return this._paddingleft;
			}
			set
			{
				if (this._paddingleft == value)
				{
					return;
				}
				this._paddingleft = value;
				this.Dirty();
			}
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x0600179C RID: 6044 RVA: 0x0005F732 File Offset: 0x0005D932
		// (set) Token: 0x0600179D RID: 6045 RVA: 0x0005F73A File Offset: 0x0005D93A
		public Length? PaddingTop
		{
			get
			{
				return this._paddingtop;
			}
			set
			{
				if (this._paddingtop == value)
				{
					return;
				}
				this._paddingtop = value;
				this.Dirty();
			}
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x0600179E RID: 6046 RVA: 0x0005F758 File Offset: 0x0005D958
		// (set) Token: 0x0600179F RID: 6047 RVA: 0x0005F760 File Offset: 0x0005D960
		public Length? PaddingRight
		{
			get
			{
				return this._paddingright;
			}
			set
			{
				if (this._paddingright == value)
				{
					return;
				}
				this._paddingright = value;
				this.Dirty();
			}
		}

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x060017A0 RID: 6048 RVA: 0x0005F77E File Offset: 0x0005D97E
		// (set) Token: 0x060017A1 RID: 6049 RVA: 0x0005F786 File Offset: 0x0005D986
		public Length? PaddingBottom
		{
			get
			{
				return this._paddingbottom;
			}
			set
			{
				if (this._paddingbottom == value)
				{
					return;
				}
				this._paddingbottom = value;
				this.Dirty();
			}
		}

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x060017A2 RID: 6050 RVA: 0x0005F7A4 File Offset: 0x0005D9A4
		// (set) Token: 0x060017A3 RID: 6051 RVA: 0x0005F7AC File Offset: 0x0005D9AC
		public Length? MarginLeft
		{
			get
			{
				return this._marginleft;
			}
			set
			{
				if (this._marginleft == value)
				{
					return;
				}
				this._marginleft = value;
				this.Dirty();
			}
		}

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x060017A4 RID: 6052 RVA: 0x0005F7CA File Offset: 0x0005D9CA
		// (set) Token: 0x060017A5 RID: 6053 RVA: 0x0005F7D2 File Offset: 0x0005D9D2
		public Length? MarginTop
		{
			get
			{
				return this._margintop;
			}
			set
			{
				if (this._margintop == value)
				{
					return;
				}
				this._margintop = value;
				this.Dirty();
			}
		}

		// Token: 0x170003C5 RID: 965
		// (get) Token: 0x060017A6 RID: 6054 RVA: 0x0005F7F0 File Offset: 0x0005D9F0
		// (set) Token: 0x060017A7 RID: 6055 RVA: 0x0005F7F8 File Offset: 0x0005D9F8
		public Length? MarginRight
		{
			get
			{
				return this._marginright;
			}
			set
			{
				if (this._marginright == value)
				{
					return;
				}
				this._marginright = value;
				this.Dirty();
			}
		}

		// Token: 0x170003C6 RID: 966
		// (get) Token: 0x060017A8 RID: 6056 RVA: 0x0005F816 File Offset: 0x0005DA16
		// (set) Token: 0x060017A9 RID: 6057 RVA: 0x0005F81E File Offset: 0x0005DA1E
		public Length? MarginBottom
		{
			get
			{
				return this._marginbottom;
			}
			set
			{
				if (this._marginbottom == value)
				{
					return;
				}
				this._marginbottom = value;
				this.Dirty();
			}
		}

		// Token: 0x170003C7 RID: 967
		// (get) Token: 0x060017AA RID: 6058 RVA: 0x0005F83C File Offset: 0x0005DA3C
		// (set) Token: 0x060017AB RID: 6059 RVA: 0x0005F844 File Offset: 0x0005DA44
		public Length? BorderTopLeftRadius
		{
			get
			{
				return this._bordertopleftradius;
			}
			set
			{
				if (this._bordertopleftradius == value)
				{
					return;
				}
				this._bordertopleftradius = value;
				this.Dirty();
			}
		}

		// Token: 0x170003C8 RID: 968
		// (get) Token: 0x060017AC RID: 6060 RVA: 0x0005F862 File Offset: 0x0005DA62
		// (set) Token: 0x060017AD RID: 6061 RVA: 0x0005F86A File Offset: 0x0005DA6A
		public Length? BorderTopRightRadius
		{
			get
			{
				return this._bordertoprightradius;
			}
			set
			{
				if (this._bordertoprightradius == value)
				{
					return;
				}
				this._bordertoprightradius = value;
				this.Dirty();
			}
		}

		// Token: 0x170003C9 RID: 969
		// (get) Token: 0x060017AE RID: 6062 RVA: 0x0005F888 File Offset: 0x0005DA88
		// (set) Token: 0x060017AF RID: 6063 RVA: 0x0005F890 File Offset: 0x0005DA90
		public Length? BorderBottomRightRadius
		{
			get
			{
				return this._borderbottomrightradius;
			}
			set
			{
				if (this._borderbottomrightradius == value)
				{
					return;
				}
				this._borderbottomrightradius = value;
				this.Dirty();
			}
		}

		// Token: 0x170003CA RID: 970
		// (get) Token: 0x060017B0 RID: 6064 RVA: 0x0005F8AE File Offset: 0x0005DAAE
		// (set) Token: 0x060017B1 RID: 6065 RVA: 0x0005F8B6 File Offset: 0x0005DAB6
		public Length? BorderBottomLeftRadius
		{
			get
			{
				return this._borderbottomleftradius;
			}
			set
			{
				if (this._borderbottomleftradius == value)
				{
					return;
				}
				this._borderbottomleftradius = value;
				this.Dirty();
			}
		}

		// Token: 0x170003CB RID: 971
		// (get) Token: 0x060017B2 RID: 6066 RVA: 0x0005F8D4 File Offset: 0x0005DAD4
		// (set) Token: 0x060017B3 RID: 6067 RVA: 0x0005F8DC File Offset: 0x0005DADC
		public Length? BorderLeftWidth
		{
			get
			{
				return this._borderleftwidth;
			}
			set
			{
				if (this._borderleftwidth == value)
				{
					return;
				}
				this._borderleftwidth = value;
				this.Dirty();
			}
		}

		// Token: 0x170003CC RID: 972
		// (get) Token: 0x060017B4 RID: 6068 RVA: 0x0005F8FA File Offset: 0x0005DAFA
		// (set) Token: 0x060017B5 RID: 6069 RVA: 0x0005F902 File Offset: 0x0005DB02
		public Length? BorderTopWidth
		{
			get
			{
				return this._bordertopwidth;
			}
			set
			{
				if (this._bordertopwidth == value)
				{
					return;
				}
				this._bordertopwidth = value;
				this.Dirty();
			}
		}

		// Token: 0x170003CD RID: 973
		// (get) Token: 0x060017B6 RID: 6070 RVA: 0x0005F920 File Offset: 0x0005DB20
		// (set) Token: 0x060017B7 RID: 6071 RVA: 0x0005F928 File Offset: 0x0005DB28
		public Length? BorderRightWidth
		{
			get
			{
				return this._borderrightwidth;
			}
			set
			{
				if (this._borderrightwidth == value)
				{
					return;
				}
				this._borderrightwidth = value;
				this.Dirty();
			}
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x060017B8 RID: 6072 RVA: 0x0005F946 File Offset: 0x0005DB46
		// (set) Token: 0x060017B9 RID: 6073 RVA: 0x0005F94E File Offset: 0x0005DB4E
		public Length? BorderBottomWidth
		{
			get
			{
				return this._borderbottomwidth;
			}
			set
			{
				if (this._borderbottomwidth == value)
				{
					return;
				}
				this._borderbottomwidth = value;
				this.Dirty();
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x060017BA RID: 6074 RVA: 0x0005F96C File Offset: 0x0005DB6C
		// (set) Token: 0x060017BB RID: 6075 RVA: 0x0005F974 File Offset: 0x0005DB74
		public Color? BorderLeftColor
		{
			get
			{
				return this._borderleftcolor;
			}
			set
			{
				if (this._borderleftcolor == value)
				{
					return;
				}
				this._borderleftcolor = value;
				this.Dirty();
			}
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x060017BC RID: 6076 RVA: 0x0005F9CC File Offset: 0x0005DBCC
		// (set) Token: 0x060017BD RID: 6077 RVA: 0x0005F9D4 File Offset: 0x0005DBD4
		public Color? BorderTopColor
		{
			get
			{
				return this._bordertopcolor;
			}
			set
			{
				if (this._bordertopcolor == value)
				{
					return;
				}
				this._bordertopcolor = value;
				this.Dirty();
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x060017BE RID: 6078 RVA: 0x0005FA2C File Offset: 0x0005DC2C
		// (set) Token: 0x060017BF RID: 6079 RVA: 0x0005FA34 File Offset: 0x0005DC34
		public Color? BorderRightColor
		{
			get
			{
				return this._borderrightcolor;
			}
			set
			{
				if (this._borderrightcolor == value)
				{
					return;
				}
				this._borderrightcolor = value;
				this.Dirty();
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x060017C0 RID: 6080 RVA: 0x0005FA8C File Offset: 0x0005DC8C
		// (set) Token: 0x060017C1 RID: 6081 RVA: 0x0005FA94 File Offset: 0x0005DC94
		public Color? BorderBottomColor
		{
			get
			{
				return this._borderbottomcolor;
			}
			set
			{
				if (this._borderbottomcolor == value)
				{
					return;
				}
				this._borderbottomcolor = value;
				this.Dirty();
			}
		}

		// Token: 0x170003D3 RID: 979
		// (get) Token: 0x060017C2 RID: 6082 RVA: 0x0005FAEC File Offset: 0x0005DCEC
		// (set) Token: 0x060017C3 RID: 6083 RVA: 0x0005FAF4 File Offset: 0x0005DCF4
		public Length? FontSize
		{
			get
			{
				return this._fontsize;
			}
			set
			{
				if (this._fontsize == value)
				{
					return;
				}
				this._fontsize = value;
				this.Dirty();
			}
		}

		// Token: 0x170003D4 RID: 980
		// (get) Token: 0x060017C4 RID: 6084 RVA: 0x0005FB12 File Offset: 0x0005DD12
		// (set) Token: 0x060017C5 RID: 6085 RVA: 0x0005FB1C File Offset: 0x0005DD1C
		public Color? FontColor
		{
			get
			{
				return this._fontcolor;
			}
			set
			{
				if (this._fontcolor == value)
				{
					return;
				}
				this._fontcolor = value;
				this.Dirty();
			}
		}

		// Token: 0x170003D5 RID: 981
		// (get) Token: 0x060017C6 RID: 6086 RVA: 0x0005FB74 File Offset: 0x0005DD74
		// (set) Token: 0x060017C7 RID: 6087 RVA: 0x0005FB7C File Offset: 0x0005DD7C
		public int? FontWeight
		{
			get
			{
				return this._fontweight;
			}
			set
			{
				int? fontweight = this._fontweight;
				int? num = value;
				if ((fontweight.GetValueOrDefault() == num.GetValueOrDefault()) & (fontweight != null == (num != null)))
				{
					return;
				}
				this._fontweight = value;
				this.Dirty();
			}
		}

		// Token: 0x170003D6 RID: 982
		// (get) Token: 0x060017C8 RID: 6088 RVA: 0x0005FBC3 File Offset: 0x0005DDC3
		// (set) Token: 0x060017C9 RID: 6089 RVA: 0x0005FBCB File Offset: 0x0005DDCB
		public string FontFamily
		{
			get
			{
				return this._fontfamily;
			}
			set
			{
				if (this._fontfamily == value)
				{
					return;
				}
				this._fontfamily = value;
				this.Dirty();
			}
		}

		// Token: 0x170003D7 RID: 983
		// (get) Token: 0x060017CA RID: 6090 RVA: 0x0005FBE9 File Offset: 0x0005DDE9
		// (set) Token: 0x060017CB RID: 6091 RVA: 0x0005FBF1 File Offset: 0x0005DDF1
		public string Cursor
		{
			get
			{
				return this._cursor;
			}
			set
			{
				if (this._cursor == value)
				{
					return;
				}
				this._cursor = value;
				this.Dirty();
			}
		}

		// Token: 0x170003D8 RID: 984
		// (get) Token: 0x060017CC RID: 6092 RVA: 0x0005FC0F File Offset: 0x0005DE0F
		// (set) Token: 0x060017CD RID: 6093 RVA: 0x0005FC17 File Offset: 0x0005DE17
		public string PointerEvents
		{
			get
			{
				return this._pointerevents;
			}
			set
			{
				if (this._pointerevents == value)
				{
					return;
				}
				this._pointerevents = value;
				this.Dirty();
			}
		}

		// Token: 0x170003D9 RID: 985
		// (get) Token: 0x060017CE RID: 6094 RVA: 0x0005FC35 File Offset: 0x0005DE35
		// (set) Token: 0x060017CF RID: 6095 RVA: 0x0005FC3D File Offset: 0x0005DE3D
		public string MixBlendMode
		{
			get
			{
				return this._mixblendmode;
			}
			set
			{
				if (this._mixblendmode == value)
				{
					return;
				}
				this._mixblendmode = value;
				this.Dirty();
			}
		}

		// Token: 0x170003DA RID: 986
		// (get) Token: 0x060017D0 RID: 6096 RVA: 0x0005FC5B File Offset: 0x0005DE5B
		// (set) Token: 0x060017D1 RID: 6097 RVA: 0x0005FC64 File Offset: 0x0005DE64
		public ColorInterpolation? ColorInterpolation
		{
			get
			{
				return this._colorinterpolation;
			}
			set
			{
				ColorInterpolation? colorinterpolation = this._colorinterpolation;
				ColorInterpolation? colorInterpolation = value;
				if ((colorinterpolation.GetValueOrDefault() == colorInterpolation.GetValueOrDefault()) & (colorinterpolation != null == (colorInterpolation != null)))
				{
					return;
				}
				this._colorinterpolation = value;
				this.Dirty();
			}
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x060017D2 RID: 6098 RVA: 0x0005FCAB File Offset: 0x0005DEAB
		// (set) Token: 0x060017D3 RID: 6099 RVA: 0x0005FCB4 File Offset: 0x0005DEB4
		public PositionMode? Position
		{
			get
			{
				return this._position;
			}
			set
			{
				PositionMode? position = this._position;
				PositionMode? positionMode = value;
				if ((position.GetValueOrDefault() == positionMode.GetValueOrDefault()) & (position != null == (positionMode != null)))
				{
					return;
				}
				this._position = value;
				this.Dirty();
			}
		}

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x060017D4 RID: 6100 RVA: 0x0005FCFB File Offset: 0x0005DEFB
		// (set) Token: 0x060017D5 RID: 6101 RVA: 0x0005FD04 File Offset: 0x0005DF04
		public OverflowMode? Overflow
		{
			get
			{
				return this._overflow;
			}
			set
			{
				OverflowMode? overflow = this._overflow;
				OverflowMode? overflowMode = value;
				if ((overflow.GetValueOrDefault() == overflowMode.GetValueOrDefault()) & (overflow != null == (overflowMode != null)))
				{
					return;
				}
				this._overflow = value;
				this.Dirty();
			}
		}

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x060017D6 RID: 6102 RVA: 0x0005FD4B File Offset: 0x0005DF4B
		// (set) Token: 0x060017D7 RID: 6103 RVA: 0x0005FD54 File Offset: 0x0005DF54
		public FlexDirection? FlexDirection
		{
			get
			{
				return this._flexdirection;
			}
			set
			{
				FlexDirection? flexdirection = this._flexdirection;
				FlexDirection? flexDirection = value;
				if ((flexdirection.GetValueOrDefault() == flexDirection.GetValueOrDefault()) & (flexdirection != null == (flexDirection != null)))
				{
					return;
				}
				this._flexdirection = value;
				this.Dirty();
			}
		}

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x060017D8 RID: 6104 RVA: 0x0005FD9B File Offset: 0x0005DF9B
		// (set) Token: 0x060017D9 RID: 6105 RVA: 0x0005FDA4 File Offset: 0x0005DFA4
		public Justify? JustifyContent
		{
			get
			{
				return this._justifycontent;
			}
			set
			{
				Justify? justifycontent = this._justifycontent;
				Justify? justify = value;
				if ((justifycontent.GetValueOrDefault() == justify.GetValueOrDefault()) & (justifycontent != null == (justify != null)))
				{
					return;
				}
				this._justifycontent = value;
				this.Dirty();
			}
		}

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x060017DA RID: 6106 RVA: 0x0005FDEB File Offset: 0x0005DFEB
		// (set) Token: 0x060017DB RID: 6107 RVA: 0x0005FDF4 File Offset: 0x0005DFF4
		public DisplayMode? Display
		{
			get
			{
				return this._display;
			}
			set
			{
				DisplayMode? display = this._display;
				DisplayMode? displayMode = value;
				if ((display.GetValueOrDefault() == displayMode.GetValueOrDefault()) & (display != null == (displayMode != null)))
				{
					return;
				}
				this._display = value;
				this.Dirty();
			}
		}

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x060017DC RID: 6108 RVA: 0x0005FE3B File Offset: 0x0005E03B
		// (set) Token: 0x060017DD RID: 6109 RVA: 0x0005FE44 File Offset: 0x0005E044
		public Wrap? FlexWrap
		{
			get
			{
				return this._flexwrap;
			}
			set
			{
				Wrap? flexwrap = this._flexwrap;
				Wrap? wrap = value;
				if ((flexwrap.GetValueOrDefault() == wrap.GetValueOrDefault()) & (flexwrap != null == (wrap != null)))
				{
					return;
				}
				this._flexwrap = value;
				this.Dirty();
			}
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x060017DE RID: 6110 RVA: 0x0005FE8B File Offset: 0x0005E08B
		// (set) Token: 0x060017DF RID: 6111 RVA: 0x0005FE94 File Offset: 0x0005E094
		public Align? AlignContent
		{
			get
			{
				return this._aligncontent;
			}
			set
			{
				Align? aligncontent = this._aligncontent;
				Align? align = value;
				if ((aligncontent.GetValueOrDefault() == align.GetValueOrDefault()) & (aligncontent != null == (align != null)))
				{
					return;
				}
				this._aligncontent = value;
				this.Dirty();
			}
		}

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x060017E0 RID: 6112 RVA: 0x0005FEDB File Offset: 0x0005E0DB
		// (set) Token: 0x060017E1 RID: 6113 RVA: 0x0005FEE4 File Offset: 0x0005E0E4
		public Align? AlignSelf
		{
			get
			{
				return this._alignself;
			}
			set
			{
				Align? alignself = this._alignself;
				Align? align = value;
				if ((alignself.GetValueOrDefault() == align.GetValueOrDefault()) & (alignself != null == (align != null)))
				{
					return;
				}
				this._alignself = value;
				this.Dirty();
			}
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x060017E2 RID: 6114 RVA: 0x0005FF2B File Offset: 0x0005E12B
		// (set) Token: 0x060017E3 RID: 6115 RVA: 0x0005FF34 File Offset: 0x0005E134
		public Align? AlignItems
		{
			get
			{
				return this._alignitems;
			}
			set
			{
				Align? alignitems = this._alignitems;
				Align? align = value;
				if ((alignitems.GetValueOrDefault() == align.GetValueOrDefault()) & (alignitems != null == (align != null)))
				{
					return;
				}
				this._alignitems = value;
				this.Dirty();
			}
		}

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x060017E4 RID: 6116 RVA: 0x0005FF7B File Offset: 0x0005E17B
		// (set) Token: 0x060017E5 RID: 6117 RVA: 0x0005FF83 File Offset: 0x0005E183
		public Length? FlexBasis
		{
			get
			{
				return this._flexbasis;
			}
			set
			{
				if (this._flexbasis == value)
				{
					return;
				}
				this._flexbasis = value;
				this.Dirty();
			}
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x060017E6 RID: 6118 RVA: 0x0005FFA1 File Offset: 0x0005E1A1
		// (set) Token: 0x060017E7 RID: 6119 RVA: 0x0005FFAC File Offset: 0x0005E1AC
		public float? FlexGrow
		{
			get
			{
				return this._flexgrow;
			}
			set
			{
				float? flexgrow = this._flexgrow;
				float? num = value;
				if ((flexgrow.GetValueOrDefault() == num.GetValueOrDefault()) & (flexgrow != null == (num != null)))
				{
					return;
				}
				this._flexgrow = value;
				this.Dirty();
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x060017E8 RID: 6120 RVA: 0x0005FFF3 File Offset: 0x0005E1F3
		// (set) Token: 0x060017E9 RID: 6121 RVA: 0x0005FFFC File Offset: 0x0005E1FC
		public float? FlexShrink
		{
			get
			{
				return this._flexshrink;
			}
			set
			{
				float? flexshrink = this._flexshrink;
				float? num = value;
				if ((flexshrink.GetValueOrDefault() == num.GetValueOrDefault()) & (flexshrink != null == (num != null)))
				{
					return;
				}
				this._flexshrink = value;
				this.Dirty();
			}
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x060017EA RID: 6122 RVA: 0x00060043 File Offset: 0x0005E243
		// (set) Token: 0x060017EB RID: 6123 RVA: 0x0006004C File Offset: 0x0005E24C
		public float? AspectRatio
		{
			get
			{
				return this._aspectratio;
			}
			set
			{
				float? aspectratio = this._aspectratio;
				float? num = value;
				if ((aspectratio.GetValueOrDefault() == num.GetValueOrDefault()) & (aspectratio != null == (num != null)))
				{
					return;
				}
				this._aspectratio = value;
				this.Dirty();
			}
		}

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x060017EC RID: 6124 RVA: 0x00060093 File Offset: 0x0005E293
		// (set) Token: 0x060017ED RID: 6125 RVA: 0x0006009C File Offset: 0x0005E29C
		public TextAlign? TextAlign
		{
			get
			{
				return this._textalign;
			}
			set
			{
				TextAlign? textalign = this._textalign;
				TextAlign? textAlign = value;
				if ((textalign.GetValueOrDefault() == textAlign.GetValueOrDefault()) & (textalign != null == (textAlign != null)))
				{
					return;
				}
				this._textalign = value;
				this.Dirty();
			}
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x060017EE RID: 6126 RVA: 0x000600E3 File Offset: 0x0005E2E3
		// (set) Token: 0x060017EF RID: 6127 RVA: 0x000600EC File Offset: 0x0005E2EC
		public TextDecoration? TextDecorationLine
		{
			get
			{
				return this._textdecorationline;
			}
			set
			{
				TextDecoration? textdecorationline = this._textdecorationline;
				TextDecoration? textDecoration = value;
				if ((textdecorationline.GetValueOrDefault() == textDecoration.GetValueOrDefault()) & (textdecorationline != null == (textDecoration != null)))
				{
					return;
				}
				this._textdecorationline = value;
				this.Dirty();
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x060017F0 RID: 6128 RVA: 0x00060133 File Offset: 0x0005E333
		// (set) Token: 0x060017F1 RID: 6129 RVA: 0x0006013C File Offset: 0x0005E33C
		public Color? TextDecorationColor
		{
			get
			{
				return this._textdecorationcolor;
			}
			set
			{
				if (this._textdecorationcolor == value)
				{
					return;
				}
				this._textdecorationcolor = value;
				this.Dirty();
			}
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x060017F2 RID: 6130 RVA: 0x00060194 File Offset: 0x0005E394
		// (set) Token: 0x060017F3 RID: 6131 RVA: 0x0006019C File Offset: 0x0005E39C
		public Length? TextDecorationThickness
		{
			get
			{
				return this._textdecorationthickness;
			}
			set
			{
				if (this._textdecorationthickness == value)
				{
					return;
				}
				this._textdecorationthickness = value;
				this.Dirty();
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x060017F4 RID: 6132 RVA: 0x000601BA File Offset: 0x0005E3BA
		// (set) Token: 0x060017F5 RID: 6133 RVA: 0x000601C4 File Offset: 0x0005E3C4
		public TextSkipInk? TextDecorationSkipInk
		{
			get
			{
				return this._textdecorationskipink;
			}
			set
			{
				TextSkipInk? textdecorationskipink = this._textdecorationskipink;
				TextSkipInk? textSkipInk = value;
				if ((textdecorationskipink.GetValueOrDefault() == textSkipInk.GetValueOrDefault()) & (textdecorationskipink != null == (textSkipInk != null)))
				{
					return;
				}
				this._textdecorationskipink = value;
				this.Dirty();
			}
		}

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x060017F6 RID: 6134 RVA: 0x0006020B File Offset: 0x0005E40B
		// (set) Token: 0x060017F7 RID: 6135 RVA: 0x00060214 File Offset: 0x0005E414
		public TextDecorationStyle? TextDecorationStyle
		{
			get
			{
				return this._textdecorationstyle;
			}
			set
			{
				TextDecorationStyle? textdecorationstyle = this._textdecorationstyle;
				TextDecorationStyle? textDecorationStyle = value;
				if ((textdecorationstyle.GetValueOrDefault() == textDecorationStyle.GetValueOrDefault()) & (textdecorationstyle != null == (textDecorationStyle != null)))
				{
					return;
				}
				this._textdecorationstyle = value;
				this.Dirty();
			}
		}

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x060017F8 RID: 6136 RVA: 0x0006025B File Offset: 0x0005E45B
		// (set) Token: 0x060017F9 RID: 6137 RVA: 0x00060263 File Offset: 0x0005E463
		public Length? TextUnderlineOffset
		{
			get
			{
				return this._textunderlineoffset;
			}
			set
			{
				if (this._textunderlineoffset == value)
				{
					return;
				}
				this._textunderlineoffset = value;
				this.Dirty();
			}
		}

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x060017FA RID: 6138 RVA: 0x00060281 File Offset: 0x0005E481
		// (set) Token: 0x060017FB RID: 6139 RVA: 0x00060289 File Offset: 0x0005E489
		public Length? TextOverlineOffset
		{
			get
			{
				return this._textoverlineoffset;
			}
			set
			{
				if (this._textoverlineoffset == value)
				{
					return;
				}
				this._textoverlineoffset = value;
				this.Dirty();
			}
		}

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x060017FC RID: 6140 RVA: 0x000602A7 File Offset: 0x0005E4A7
		// (set) Token: 0x060017FD RID: 6141 RVA: 0x000602AF File Offset: 0x0005E4AF
		public Length? TextLineThroughOffset
		{
			get
			{
				return this._textlinethroughoffset;
			}
			set
			{
				if (this._textlinethroughoffset == value)
				{
					return;
				}
				this._textlinethroughoffset = value;
				this.Dirty();
			}
		}

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x060017FE RID: 6142 RVA: 0x000602CD File Offset: 0x0005E4CD
		// (set) Token: 0x060017FF RID: 6143 RVA: 0x000602D8 File Offset: 0x0005E4D8
		public FontStyle? FontStyle
		{
			get
			{
				return this._fontstyle;
			}
			set
			{
				FontStyle? fontstyle = this._fontstyle;
				FontStyle? fontStyle = value;
				if ((fontstyle.GetValueOrDefault() == fontStyle.GetValueOrDefault()) & (fontstyle != null == (fontStyle != null)))
				{
					return;
				}
				this._fontstyle = value;
				this.Dirty();
			}
		}

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x06001800 RID: 6144 RVA: 0x0006031F File Offset: 0x0005E51F
		// (set) Token: 0x06001801 RID: 6145 RVA: 0x00060328 File Offset: 0x0005E528
		public PanelTransform? Transform
		{
			get
			{
				return this._transform;
			}
			set
			{
				if (this._transform == value)
				{
					return;
				}
				this._transform = value;
				this.Dirty();
			}
		}

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06001802 RID: 6146 RVA: 0x00060380 File Offset: 0x0005E580
		// (set) Token: 0x06001803 RID: 6147 RVA: 0x00060388 File Offset: 0x0005E588
		public TextTransform? TextTransform
		{
			get
			{
				return this._texttransform;
			}
			set
			{
				TextTransform? texttransform = this._texttransform;
				TextTransform? textTransform = value;
				if ((texttransform.GetValueOrDefault() == textTransform.GetValueOrDefault()) & (texttransform != null == (textTransform != null)))
				{
					return;
				}
				this._texttransform = value;
				this.Dirty();
			}
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06001804 RID: 6148 RVA: 0x000603CF File Offset: 0x0005E5CF
		// (set) Token: 0x06001805 RID: 6149 RVA: 0x000603D7 File Offset: 0x0005E5D7
		public Length? TransformOriginX
		{
			get
			{
				return this._transformoriginx;
			}
			set
			{
				if (this._transformoriginx == value)
				{
					return;
				}
				this._transformoriginx = value;
				this.Dirty();
			}
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06001806 RID: 6150 RVA: 0x000603F5 File Offset: 0x0005E5F5
		// (set) Token: 0x06001807 RID: 6151 RVA: 0x000603FD File Offset: 0x0005E5FD
		public Length? TransformOriginY
		{
			get
			{
				return this._transformoriginy;
			}
			set
			{
				if (this._transformoriginy == value)
				{
					return;
				}
				this._transformoriginy = value;
				this.Dirty();
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06001808 RID: 6152 RVA: 0x0006041B File Offset: 0x0005E61B
		// (set) Token: 0x06001809 RID: 6153 RVA: 0x00060423 File Offset: 0x0005E623
		public Length? LetterSpacing
		{
			get
			{
				return this._letterspacing;
			}
			set
			{
				if (this._letterspacing == value)
				{
					return;
				}
				this._letterspacing = value;
				this.Dirty();
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x0600180A RID: 6154 RVA: 0x00060441 File Offset: 0x0005E641
		// (set) Token: 0x0600180B RID: 6155 RVA: 0x00060449 File Offset: 0x0005E649
		public Texture TextBackgroundImage
		{
			get
			{
				return this._textbackgroundimage;
			}
			set
			{
				if (this._textbackgroundimage == value)
				{
					return;
				}
				this._textbackgroundimage = value;
				this.Dirty();
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x0600180C RID: 6156 RVA: 0x00060462 File Offset: 0x0005E662
		// (set) Token: 0x0600180D RID: 6157 RVA: 0x0006046A File Offset: 0x0005E66A
		public string WhiteSpace
		{
			get
			{
				return this._whitespace;
			}
			set
			{
				if (this._whitespace == value)
				{
					return;
				}
				this._whitespace = value;
				this.Dirty();
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x0600180E RID: 6158 RVA: 0x00060488 File Offset: 0x0005E688
		// (set) Token: 0x0600180F RID: 6159 RVA: 0x00060490 File Offset: 0x0005E690
		public int? ZIndex
		{
			get
			{
				return this._zindex;
			}
			set
			{
				int? zindex = this._zindex;
				int? num = value;
				if ((zindex.GetValueOrDefault() == num.GetValueOrDefault()) & (zindex != null == (num != null)))
				{
					return;
				}
				this._zindex = value;
				this.Dirty();
			}
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x06001810 RID: 6160 RVA: 0x000604D7 File Offset: 0x0005E6D7
		// (set) Token: 0x06001811 RID: 6161 RVA: 0x000604E0 File Offset: 0x0005E6E0
		public int? Order
		{
			get
			{
				return this._order;
			}
			set
			{
				int? order = this._order;
				int? num = value;
				if ((order.GetValueOrDefault() == num.GetValueOrDefault()) & (order != null == (num != null)))
				{
					return;
				}
				this._order = value;
				this.Dirty();
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x06001812 RID: 6162 RVA: 0x00060527 File Offset: 0x0005E727
		// (set) Token: 0x06001813 RID: 6163 RVA: 0x0006052F File Offset: 0x0005E72F
		public string SoundIn
		{
			get
			{
				return this._soundin;
			}
			set
			{
				if (this._soundin == value)
				{
					return;
				}
				this._soundin = value;
				this.Dirty();
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x06001814 RID: 6164 RVA: 0x0006054D File Offset: 0x0005E74D
		// (set) Token: 0x06001815 RID: 6165 RVA: 0x00060555 File Offset: 0x0005E755
		public string SoundOut
		{
			get
			{
				return this._soundout;
			}
			set
			{
				if (this._soundout == value)
				{
					return;
				}
				this._soundout = value;
				this.Dirty();
			}
		}

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x06001816 RID: 6166 RVA: 0x00060573 File Offset: 0x0005E773
		// (set) Token: 0x06001817 RID: 6167 RVA: 0x0006057C File Offset: 0x0005E77C
		public int? PixelSnap
		{
			get
			{
				return this._pixelsnap;
			}
			set
			{
				int? pixelsnap = this._pixelsnap;
				int? num = value;
				if ((pixelsnap.GetValueOrDefault() == num.GetValueOrDefault()) & (pixelsnap != null == (num != null)))
				{
					return;
				}
				this._pixelsnap = value;
				this.Dirty();
			}
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x06001818 RID: 6168 RVA: 0x000605C3 File Offset: 0x0005E7C3
		// (set) Token: 0x06001819 RID: 6169 RVA: 0x000605CB File Offset: 0x0005E7CB
		public Length? BackdropFilterBlur
		{
			get
			{
				return this._backdropfilterblur;
			}
			set
			{
				if (this._backdropfilterblur == value)
				{
					return;
				}
				this._backdropfilterblur = value;
				this.Dirty();
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x0600181A RID: 6170 RVA: 0x000605E9 File Offset: 0x0005E7E9
		// (set) Token: 0x0600181B RID: 6171 RVA: 0x000605F1 File Offset: 0x0005E7F1
		public Length? BackdropFilterBrightness
		{
			get
			{
				return this._backdropfilterbrightness;
			}
			set
			{
				if (this._backdropfilterbrightness == value)
				{
					return;
				}
				this._backdropfilterbrightness = value;
				this.Dirty();
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x0600181C RID: 6172 RVA: 0x0006060F File Offset: 0x0005E80F
		// (set) Token: 0x0600181D RID: 6173 RVA: 0x00060617 File Offset: 0x0005E817
		public Length? BackdropFilterContrast
		{
			get
			{
				return this._backdropfiltercontrast;
			}
			set
			{
				if (this._backdropfiltercontrast == value)
				{
					return;
				}
				this._backdropfiltercontrast = value;
				this.Dirty();
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x0600181E RID: 6174 RVA: 0x00060635 File Offset: 0x0005E835
		// (set) Token: 0x0600181F RID: 6175 RVA: 0x0006063D File Offset: 0x0005E83D
		public Length? BackdropFilterSaturate
		{
			get
			{
				return this._backdropfiltersaturate;
			}
			set
			{
				if (this._backdropfiltersaturate == value)
				{
					return;
				}
				this._backdropfiltersaturate = value;
				this.Dirty();
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x06001820 RID: 6176 RVA: 0x0006065B File Offset: 0x0005E85B
		// (set) Token: 0x06001821 RID: 6177 RVA: 0x00060663 File Offset: 0x0005E863
		public Length? BackdropFilterSepia
		{
			get
			{
				return this._backdropfiltersepia;
			}
			set
			{
				if (this._backdropfiltersepia == value)
				{
					return;
				}
				this._backdropfiltersepia = value;
				this.Dirty();
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x06001822 RID: 6178 RVA: 0x00060681 File Offset: 0x0005E881
		// (set) Token: 0x06001823 RID: 6179 RVA: 0x00060689 File Offset: 0x0005E889
		public Length? BackdropFilterInvert
		{
			get
			{
				return this._backdropfilterinvert;
			}
			set
			{
				if (this._backdropfilterinvert == value)
				{
					return;
				}
				this._backdropfilterinvert = value;
				this.Dirty();
			}
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x06001824 RID: 6180 RVA: 0x000606A7 File Offset: 0x0005E8A7
		// (set) Token: 0x06001825 RID: 6181 RVA: 0x000606AF File Offset: 0x0005E8AF
		public Length? BackdropFilterHueRotate
		{
			get
			{
				return this._backdropfilterhuerotate;
			}
			set
			{
				if (this._backdropfilterhuerotate == value)
				{
					return;
				}
				this._backdropfilterhuerotate = value;
				this.Dirty();
			}
		}

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x06001826 RID: 6182 RVA: 0x000606CD File Offset: 0x0005E8CD
		// (set) Token: 0x06001827 RID: 6183 RVA: 0x000606D5 File Offset: 0x0005E8D5
		public Length? FilterBlur
		{
			get
			{
				return this._filterblur;
			}
			set
			{
				if (this._filterblur == value)
				{
					return;
				}
				this._filterblur = value;
				this.Dirty();
			}
		}

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x06001828 RID: 6184 RVA: 0x000606F3 File Offset: 0x0005E8F3
		// (set) Token: 0x06001829 RID: 6185 RVA: 0x000606FB File Offset: 0x0005E8FB
		public Length? FilterSaturate
		{
			get
			{
				return this._filtersaturate;
			}
			set
			{
				if (this._filtersaturate == value)
				{
					return;
				}
				this._filtersaturate = value;
				this.Dirty();
			}
		}

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x0600182A RID: 6186 RVA: 0x00060719 File Offset: 0x0005E919
		// (set) Token: 0x0600182B RID: 6187 RVA: 0x00060721 File Offset: 0x0005E921
		public Length? FilterSepia
		{
			get
			{
				return this._filtersepia;
			}
			set
			{
				if (this._filtersepia == value)
				{
					return;
				}
				this._filtersepia = value;
				this.Dirty();
			}
		}

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x0600182C RID: 6188 RVA: 0x0006073F File Offset: 0x0005E93F
		// (set) Token: 0x0600182D RID: 6189 RVA: 0x00060747 File Offset: 0x0005E947
		public Length? FilterBrightness
		{
			get
			{
				return this._filterbrightness;
			}
			set
			{
				if (this._filterbrightness == value)
				{
					return;
				}
				this._filterbrightness = value;
				this.Dirty();
			}
		}

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x0600182E RID: 6190 RVA: 0x00060765 File Offset: 0x0005E965
		// (set) Token: 0x0600182F RID: 6191 RVA: 0x0006076D File Offset: 0x0005E96D
		public Length? FilterHueRotate
		{
			get
			{
				return this._filterhuerotate;
			}
			set
			{
				if (this._filterhuerotate == value)
				{
					return;
				}
				this._filterhuerotate = value;
				this.Dirty();
			}
		}

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x06001830 RID: 6192 RVA: 0x0006078B File Offset: 0x0005E98B
		// (set) Token: 0x06001831 RID: 6193 RVA: 0x00060793 File Offset: 0x0005E993
		public Length? FilterInvert
		{
			get
			{
				return this._filterinvert;
			}
			set
			{
				if (this._filterinvert == value)
				{
					return;
				}
				this._filterinvert = value;
				this.Dirty();
			}
		}

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x06001832 RID: 6194 RVA: 0x000607B1 File Offset: 0x0005E9B1
		// (set) Token: 0x06001833 RID: 6195 RVA: 0x000607B9 File Offset: 0x0005E9B9
		public Length? FilterContrast
		{
			get
			{
				return this._filtercontrast;
			}
			set
			{
				if (this._filtercontrast == value)
				{
					return;
				}
				this._filtercontrast = value;
				this.Dirty();
			}
		}

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x06001834 RID: 6196 RVA: 0x000607D7 File Offset: 0x0005E9D7
		// (set) Token: 0x06001835 RID: 6197 RVA: 0x000607E0 File Offset: 0x0005E9E0
		public Color? FilterTint
		{
			get
			{
				return this._filtertint;
			}
			set
			{
				if (this._filtertint == value)
				{
					return;
				}
				this._filtertint = value;
				this.Dirty();
			}
		}

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x06001836 RID: 6198 RVA: 0x00060838 File Offset: 0x0005EA38
		// (set) Token: 0x06001837 RID: 6199 RVA: 0x00060840 File Offset: 0x0005EA40
		public Texture BackgroundImage
		{
			get
			{
				return this._backgroundimage;
			}
			set
			{
				if (this._backgroundimage == value)
				{
					return;
				}
				this._backgroundimage = value;
				this.Dirty();
			}
		}

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x06001838 RID: 6200 RVA: 0x00060859 File Offset: 0x0005EA59
		// (set) Token: 0x06001839 RID: 6201 RVA: 0x00060861 File Offset: 0x0005EA61
		public Length? BackgroundSizeX
		{
			get
			{
				return this._backgroundsizex;
			}
			set
			{
				if (this._backgroundsizex == value)
				{
					return;
				}
				this._backgroundsizex = value;
				this.Dirty();
			}
		}

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x0600183A RID: 6202 RVA: 0x0006087F File Offset: 0x0005EA7F
		// (set) Token: 0x0600183B RID: 6203 RVA: 0x00060887 File Offset: 0x0005EA87
		public Length? BackgroundSizeY
		{
			get
			{
				return this._backgroundsizey;
			}
			set
			{
				if (this._backgroundsizey == value)
				{
					return;
				}
				this._backgroundsizey = value;
				this.Dirty();
			}
		}

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x0600183C RID: 6204 RVA: 0x000608A5 File Offset: 0x0005EAA5
		// (set) Token: 0x0600183D RID: 6205 RVA: 0x000608AD File Offset: 0x0005EAAD
		public Length? BackgroundPositionX
		{
			get
			{
				return this._backgroundpositionx;
			}
			set
			{
				if (this._backgroundpositionx == value)
				{
					return;
				}
				this._backgroundpositionx = value;
				this.Dirty();
			}
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x0600183E RID: 6206 RVA: 0x000608CB File Offset: 0x0005EACB
		// (set) Token: 0x0600183F RID: 6207 RVA: 0x000608D3 File Offset: 0x0005EAD3
		public Length? BackgroundPositionY
		{
			get
			{
				return this._backgroundpositiony;
			}
			set
			{
				if (this._backgroundpositiony == value)
				{
					return;
				}
				this._backgroundpositiony = value;
				this.Dirty();
			}
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x06001840 RID: 6208 RVA: 0x000608F1 File Offset: 0x0005EAF1
		// (set) Token: 0x06001841 RID: 6209 RVA: 0x000608FC File Offset: 0x0005EAFC
		public BackgroundRepeat? BackgroundRepeat
		{
			get
			{
				return this._backgroundrepeat;
			}
			set
			{
				BackgroundRepeat? backgroundrepeat = this._backgroundrepeat;
				BackgroundRepeat? backgroundRepeat = value;
				if ((backgroundrepeat.GetValueOrDefault() == backgroundRepeat.GetValueOrDefault()) & (backgroundrepeat != null == (backgroundRepeat != null)))
				{
					return;
				}
				this._backgroundrepeat = value;
				this.Dirty();
			}
		}

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06001842 RID: 6210 RVA: 0x00060943 File Offset: 0x0005EB43
		// (set) Token: 0x06001843 RID: 6211 RVA: 0x0006094B File Offset: 0x0005EB4B
		public Texture BorderImageSource
		{
			get
			{
				return this._borderimagesource;
			}
			set
			{
				if (this._borderimagesource == value)
				{
					return;
				}
				this._borderimagesource = value;
				this.Dirty();
			}
		}

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06001844 RID: 6212 RVA: 0x00060964 File Offset: 0x0005EB64
		// (set) Token: 0x06001845 RID: 6213 RVA: 0x0006096C File Offset: 0x0005EB6C
		public Length? BorderImageWidthLeft
		{
			get
			{
				return this._borderimagewidthleft;
			}
			set
			{
				if (this._borderimagewidthleft == value)
				{
					return;
				}
				this._borderimagewidthleft = value;
				this.Dirty();
			}
		}

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06001846 RID: 6214 RVA: 0x0006098A File Offset: 0x0005EB8A
		// (set) Token: 0x06001847 RID: 6215 RVA: 0x00060992 File Offset: 0x0005EB92
		public Length? BorderImageWidthRight
		{
			get
			{
				return this._borderimagewidthright;
			}
			set
			{
				if (this._borderimagewidthright == value)
				{
					return;
				}
				this._borderimagewidthright = value;
				this.Dirty();
			}
		}

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06001848 RID: 6216 RVA: 0x000609B0 File Offset: 0x0005EBB0
		// (set) Token: 0x06001849 RID: 6217 RVA: 0x000609B8 File Offset: 0x0005EBB8
		public Length? BorderImageWidthTop
		{
			get
			{
				return this._borderimagewidthtop;
			}
			set
			{
				if (this._borderimagewidthtop == value)
				{
					return;
				}
				this._borderimagewidthtop = value;
				this.Dirty();
			}
		}

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x0600184A RID: 6218 RVA: 0x000609D6 File Offset: 0x0005EBD6
		// (set) Token: 0x0600184B RID: 6219 RVA: 0x000609DE File Offset: 0x0005EBDE
		public Length? BorderImageWidthBottom
		{
			get
			{
				return this._borderimagewidthbottom;
			}
			set
			{
				if (this._borderimagewidthbottom == value)
				{
					return;
				}
				this._borderimagewidthbottom = value;
				this.Dirty();
			}
		}

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x0600184C RID: 6220 RVA: 0x000609FC File Offset: 0x0005EBFC
		// (set) Token: 0x0600184D RID: 6221 RVA: 0x00060A04 File Offset: 0x0005EC04
		public BorderImageFill? BorderImageFill
		{
			get
			{
				return this._borderimagefill;
			}
			set
			{
				BorderImageFill? borderimagefill = this._borderimagefill;
				BorderImageFill? borderImageFill = value;
				if ((borderimagefill.GetValueOrDefault() == borderImageFill.GetValueOrDefault()) & (borderimagefill != null == (borderImageFill != null)))
				{
					return;
				}
				this._borderimagefill = value;
				this.Dirty();
			}
		}

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x0600184E RID: 6222 RVA: 0x00060A4B File Offset: 0x0005EC4B
		// (set) Token: 0x0600184F RID: 6223 RVA: 0x00060A54 File Offset: 0x0005EC54
		public BorderImageRepeat? BorderImageRepeat
		{
			get
			{
				return this._borderimagerepeat;
			}
			set
			{
				BorderImageRepeat? borderimagerepeat = this._borderimagerepeat;
				BorderImageRepeat? borderImageRepeat = value;
				if ((borderimagerepeat.GetValueOrDefault() == borderImageRepeat.GetValueOrDefault()) & (borderimagerepeat != null == (borderImageRepeat != null)))
				{
					return;
				}
				this._borderimagerepeat = value;
				this.Dirty();
			}
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x06001850 RID: 6224 RVA: 0x00060A9B File Offset: 0x0005EC9B
		// (set) Token: 0x06001851 RID: 6225 RVA: 0x00060AA4 File Offset: 0x0005ECA4
		public Color? BackgroundTint
		{
			get
			{
				return this._backgroundtint;
			}
			set
			{
				if (this._backgroundtint == value)
				{
					return;
				}
				this._backgroundtint = value;
				this.Dirty();
			}
		}

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06001852 RID: 6226 RVA: 0x00060AFC File Offset: 0x0005ECFC
		// (set) Token: 0x06001853 RID: 6227 RVA: 0x00060B04 File Offset: 0x0005ED04
		public Length? BackgroundAngle
		{
			get
			{
				return this._backgroundangle;
			}
			set
			{
				if (this._backgroundangle == value)
				{
					return;
				}
				this._backgroundangle = value;
				this.Dirty();
			}
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06001854 RID: 6228 RVA: 0x00060B22 File Offset: 0x0005ED22
		// (set) Token: 0x06001855 RID: 6229 RVA: 0x00060B2A File Offset: 0x0005ED2A
		public Length? TextBackgroundAngle
		{
			get
			{
				return this._textbackgroundangle;
			}
			set
			{
				if (this._textbackgroundangle == value)
				{
					return;
				}
				this._textbackgroundangle = value;
				this.Dirty();
			}
		}

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06001856 RID: 6230 RVA: 0x00060B48 File Offset: 0x0005ED48
		// (set) Token: 0x06001857 RID: 6231 RVA: 0x00060B50 File Offset: 0x0005ED50
		public Color? TextStrokeColor
		{
			get
			{
				return this._textstrokecolor;
			}
			set
			{
				if (this._textstrokecolor == value)
				{
					return;
				}
				this._textstrokecolor = value;
				this.Dirty();
			}
		}

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06001858 RID: 6232 RVA: 0x00060BA8 File Offset: 0x0005EDA8
		// (set) Token: 0x06001859 RID: 6233 RVA: 0x00060BB0 File Offset: 0x0005EDB0
		public Length? TextStrokeWidth
		{
			get
			{
				return this._textstrokewidth;
			}
			set
			{
				if (this._textstrokewidth == value)
				{
					return;
				}
				this._textstrokewidth = value;
				this.Dirty();
			}
		}

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x0600185A RID: 6234 RVA: 0x00060BCE File Offset: 0x0005EDCE
		// (set) Token: 0x0600185B RID: 6235 RVA: 0x00060BD8 File Offset: 0x0005EDD8
		public ImageRendering? ImageRendering
		{
			get
			{
				return this._imagerendering;
			}
			set
			{
				ImageRendering? imagerendering = this._imagerendering;
				ImageRendering? imageRendering = value;
				if ((imagerendering.GetValueOrDefault() == imageRendering.GetValueOrDefault()) & (imagerendering != null == (imageRendering != null)))
				{
					return;
				}
				this._imagerendering = value;
				this.Dirty();
			}
		}

		// Token: 0x0600185C RID: 6236 RVA: 0x00060C20 File Offset: 0x0005EE20
		public virtual void Add(Styles a)
		{
			if (a._content != null)
			{
				this._content = a._content;
			}
			if (a._width != null)
			{
				this._width = a._width;
			}
			if (a._minwidth != null)
			{
				this._minwidth = a._minwidth;
			}
			if (a._maxwidth != null)
			{
				this._maxwidth = a._maxwidth;
			}
			if (a._height != null)
			{
				this._height = a._height;
			}
			if (a._minheight != null)
			{
				this._minheight = a._minheight;
			}
			if (a._maxheight != null)
			{
				this._maxheight = a._maxheight;
			}
			if (a._left != null)
			{
				this._left = a._left;
			}
			if (a._top != null)
			{
				this._top = a._top;
			}
			if (a._right != null)
			{
				this._right = a._right;
			}
			if (a._bottom != null)
			{
				this._bottom = a._bottom;
			}
			if (a._opacity != null)
			{
				this._opacity = a._opacity;
			}
			if (a._backgroundcolor != null)
			{
				this._backgroundcolor = a._backgroundcolor;
			}
			if (a._paddingleft != null)
			{
				this._paddingleft = a._paddingleft;
			}
			if (a._paddingtop != null)
			{
				this._paddingtop = a._paddingtop;
			}
			if (a._paddingright != null)
			{
				this._paddingright = a._paddingright;
			}
			if (a._paddingbottom != null)
			{
				this._paddingbottom = a._paddingbottom;
			}
			if (a._marginleft != null)
			{
				this._marginleft = a._marginleft;
			}
			if (a._margintop != null)
			{
				this._margintop = a._margintop;
			}
			if (a._marginright != null)
			{
				this._marginright = a._marginright;
			}
			if (a._marginbottom != null)
			{
				this._marginbottom = a._marginbottom;
			}
			if (a._bordertopleftradius != null)
			{
				this._bordertopleftradius = a._bordertopleftradius;
			}
			if (a._bordertoprightradius != null)
			{
				this._bordertoprightradius = a._bordertoprightradius;
			}
			if (a._borderbottomrightradius != null)
			{
				this._borderbottomrightradius = a._borderbottomrightradius;
			}
			if (a._borderbottomleftradius != null)
			{
				this._borderbottomleftradius = a._borderbottomleftradius;
			}
			if (a._borderleftwidth != null)
			{
				this._borderleftwidth = a._borderleftwidth;
			}
			if (a._bordertopwidth != null)
			{
				this._bordertopwidth = a._bordertopwidth;
			}
			if (a._borderrightwidth != null)
			{
				this._borderrightwidth = a._borderrightwidth;
			}
			if (a._borderbottomwidth != null)
			{
				this._borderbottomwidth = a._borderbottomwidth;
			}
			if (a._borderleftcolor != null)
			{
				this._borderleftcolor = a._borderleftcolor;
			}
			if (a._bordertopcolor != null)
			{
				this._bordertopcolor = a._bordertopcolor;
			}
			if (a._borderrightcolor != null)
			{
				this._borderrightcolor = a._borderrightcolor;
			}
			if (a._borderbottomcolor != null)
			{
				this._borderbottomcolor = a._borderbottomcolor;
			}
			if (a._fontsize != null)
			{
				this._fontsize = a._fontsize;
			}
			if (a._fontcolor != null)
			{
				this._fontcolor = a._fontcolor;
			}
			if (a._fontweight != null)
			{
				this._fontweight = a._fontweight;
			}
			if (a._fontfamily != null)
			{
				this._fontfamily = a._fontfamily;
			}
			if (a._cursor != null)
			{
				this._cursor = a._cursor;
			}
			if (a._pointerevents != null)
			{
				this._pointerevents = a._pointerevents;
			}
			if (a._mixblendmode != null)
			{
				this._mixblendmode = a._mixblendmode;
			}
			if (a._colorinterpolation != null)
			{
				this._colorinterpolation = a._colorinterpolation;
			}
			if (a._position != null)
			{
				this._position = a._position;
			}
			if (a._overflow != null)
			{
				this._overflow = a._overflow;
			}
			if (a._flexdirection != null)
			{
				this._flexdirection = a._flexdirection;
			}
			if (a._justifycontent != null)
			{
				this._justifycontent = a._justifycontent;
			}
			if (a._display != null)
			{
				this._display = a._display;
			}
			if (a._flexwrap != null)
			{
				this._flexwrap = a._flexwrap;
			}
			if (a._aligncontent != null)
			{
				this._aligncontent = a._aligncontent;
			}
			if (a._alignself != null)
			{
				this._alignself = a._alignself;
			}
			if (a._alignitems != null)
			{
				this._alignitems = a._alignitems;
			}
			if (a._flexbasis != null)
			{
				this._flexbasis = a._flexbasis;
			}
			if (a._flexgrow != null)
			{
				this._flexgrow = a._flexgrow;
			}
			if (a._flexshrink != null)
			{
				this._flexshrink = a._flexshrink;
			}
			if (a._aspectratio != null)
			{
				this._aspectratio = a._aspectratio;
			}
			if (a._textalign != null)
			{
				this._textalign = a._textalign;
			}
			if (a._textdecorationline != null)
			{
				this._textdecorationline = a._textdecorationline;
			}
			if (a._textdecorationcolor != null)
			{
				this._textdecorationcolor = a._textdecorationcolor;
			}
			if (a._textdecorationthickness != null)
			{
				this._textdecorationthickness = a._textdecorationthickness;
			}
			if (a._textdecorationskipink != null)
			{
				this._textdecorationskipink = a._textdecorationskipink;
			}
			if (a._textdecorationstyle != null)
			{
				this._textdecorationstyle = a._textdecorationstyle;
			}
			if (a._textunderlineoffset != null)
			{
				this._textunderlineoffset = a._textunderlineoffset;
			}
			if (a._textoverlineoffset != null)
			{
				this._textoverlineoffset = a._textoverlineoffset;
			}
			if (a._textlinethroughoffset != null)
			{
				this._textlinethroughoffset = a._textlinethroughoffset;
			}
			if (a._fontstyle != null)
			{
				this._fontstyle = a._fontstyle;
			}
			if (a._transform != null)
			{
				this._transform = a._transform;
			}
			if (a._texttransform != null)
			{
				this._texttransform = a._texttransform;
			}
			if (a._transformoriginx != null)
			{
				this._transformoriginx = a._transformoriginx;
			}
			if (a._transformoriginy != null)
			{
				this._transformoriginy = a._transformoriginy;
			}
			if (a._letterspacing != null)
			{
				this._letterspacing = a._letterspacing;
			}
			if (a._textbackgroundimage != null)
			{
				this._textbackgroundimage = a._textbackgroundimage;
			}
			if (a._whitespace != null)
			{
				this._whitespace = a._whitespace;
			}
			if (a._zindex != null)
			{
				this._zindex = a._zindex;
			}
			if (a._order != null)
			{
				this._order = a._order;
			}
			if (a._soundin != null)
			{
				this._soundin = a._soundin;
			}
			if (a._soundout != null)
			{
				this._soundout = a._soundout;
			}
			if (a._pixelsnap != null)
			{
				this._pixelsnap = a._pixelsnap;
			}
			if (a._backdropfilterblur != null)
			{
				this._backdropfilterblur = a._backdropfilterblur;
			}
			if (a._backdropfilterbrightness != null)
			{
				this._backdropfilterbrightness = a._backdropfilterbrightness;
			}
			if (a._backdropfiltercontrast != null)
			{
				this._backdropfiltercontrast = a._backdropfiltercontrast;
			}
			if (a._backdropfiltersaturate != null)
			{
				this._backdropfiltersaturate = a._backdropfiltersaturate;
			}
			if (a._backdropfiltersepia != null)
			{
				this._backdropfiltersepia = a._backdropfiltersepia;
			}
			if (a._backdropfilterinvert != null)
			{
				this._backdropfilterinvert = a._backdropfilterinvert;
			}
			if (a._backdropfilterhuerotate != null)
			{
				this._backdropfilterhuerotate = a._backdropfilterhuerotate;
			}
			if (a._filterblur != null)
			{
				this._filterblur = a._filterblur;
			}
			if (a._filtersaturate != null)
			{
				this._filtersaturate = a._filtersaturate;
			}
			if (a._filtersepia != null)
			{
				this._filtersepia = a._filtersepia;
			}
			if (a._filterbrightness != null)
			{
				this._filterbrightness = a._filterbrightness;
			}
			if (a._filterhuerotate != null)
			{
				this._filterhuerotate = a._filterhuerotate;
			}
			if (a._filterinvert != null)
			{
				this._filterinvert = a._filterinvert;
			}
			if (a._filtercontrast != null)
			{
				this._filtercontrast = a._filtercontrast;
			}
			if (a._filtertint != null)
			{
				this._filtertint = a._filtertint;
			}
			if (a._backgroundimage != null)
			{
				this._backgroundimage = a._backgroundimage;
			}
			if (a._backgroundsizex != null)
			{
				this._backgroundsizex = a._backgroundsizex;
			}
			if (a._backgroundsizey != null)
			{
				this._backgroundsizey = a._backgroundsizey;
			}
			if (a._backgroundpositionx != null)
			{
				this._backgroundpositionx = a._backgroundpositionx;
			}
			if (a._backgroundpositiony != null)
			{
				this._backgroundpositiony = a._backgroundpositiony;
			}
			if (a._backgroundrepeat != null)
			{
				this._backgroundrepeat = a._backgroundrepeat;
			}
			if (a._borderimagesource != null)
			{
				this._borderimagesource = a._borderimagesource;
			}
			if (a._borderimagewidthleft != null)
			{
				this._borderimagewidthleft = a._borderimagewidthleft;
			}
			if (a._borderimagewidthright != null)
			{
				this._borderimagewidthright = a._borderimagewidthright;
			}
			if (a._borderimagewidthtop != null)
			{
				this._borderimagewidthtop = a._borderimagewidthtop;
			}
			if (a._borderimagewidthbottom != null)
			{
				this._borderimagewidthbottom = a._borderimagewidthbottom;
			}
			if (a._borderimagefill != null)
			{
				this._borderimagefill = a._borderimagefill;
			}
			if (a._borderimagerepeat != null)
			{
				this._borderimagerepeat = a._borderimagerepeat;
			}
			if (a._backgroundtint != null)
			{
				this._backgroundtint = a._backgroundtint;
			}
			if (a._backgroundangle != null)
			{
				this._backgroundangle = a._backgroundangle;
			}
			if (a._textbackgroundangle != null)
			{
				this._textbackgroundangle = a._textbackgroundangle;
			}
			if (a._textstrokecolor != null)
			{
				this._textstrokecolor = a._textstrokecolor;
			}
			if (a._textstrokewidth != null)
			{
				this._textstrokewidth = a._textstrokewidth;
			}
			if (a._imagerendering != null)
			{
				this._imagerendering = a._imagerendering;
			}
		}

		// Token: 0x0600185D RID: 6237 RVA: 0x000618D0 File Offset: 0x0005FAD0
		public virtual void From(Styles a)
		{
			this._content = a._content;
			this._width = a._width;
			this._minwidth = a._minwidth;
			this._maxwidth = a._maxwidth;
			this._height = a._height;
			this._minheight = a._minheight;
			this._maxheight = a._maxheight;
			this._left = a._left;
			this._top = a._top;
			this._right = a._right;
			this._bottom = a._bottom;
			this._opacity = a._opacity;
			this._backgroundcolor = a._backgroundcolor;
			this._paddingleft = a._paddingleft;
			this._paddingtop = a._paddingtop;
			this._paddingright = a._paddingright;
			this._paddingbottom = a._paddingbottom;
			this._marginleft = a._marginleft;
			this._margintop = a._margintop;
			this._marginright = a._marginright;
			this._marginbottom = a._marginbottom;
			this._bordertopleftradius = a._bordertopleftradius;
			this._bordertoprightradius = a._bordertoprightradius;
			this._borderbottomrightradius = a._borderbottomrightradius;
			this._borderbottomleftradius = a._borderbottomleftradius;
			this._borderleftwidth = a._borderleftwidth;
			this._bordertopwidth = a._bordertopwidth;
			this._borderrightwidth = a._borderrightwidth;
			this._borderbottomwidth = a._borderbottomwidth;
			this._borderleftcolor = a._borderleftcolor;
			this._bordertopcolor = a._bordertopcolor;
			this._borderrightcolor = a._borderrightcolor;
			this._borderbottomcolor = a._borderbottomcolor;
			this._fontsize = a._fontsize;
			this._fontcolor = a._fontcolor;
			this._fontweight = a._fontweight;
			this._fontfamily = a._fontfamily;
			this._cursor = a._cursor;
			this._pointerevents = a._pointerevents;
			this._mixblendmode = a._mixblendmode;
			this._colorinterpolation = a._colorinterpolation;
			this._position = a._position;
			this._overflow = a._overflow;
			this._flexdirection = a._flexdirection;
			this._justifycontent = a._justifycontent;
			this._display = a._display;
			this._flexwrap = a._flexwrap;
			this._aligncontent = a._aligncontent;
			this._alignself = a._alignself;
			this._alignitems = a._alignitems;
			this._flexbasis = a._flexbasis;
			this._flexgrow = a._flexgrow;
			this._flexshrink = a._flexshrink;
			this._aspectratio = a._aspectratio;
			this._textalign = a._textalign;
			this._textdecorationline = a._textdecorationline;
			this._textdecorationcolor = a._textdecorationcolor;
			this._textdecorationthickness = a._textdecorationthickness;
			this._textdecorationskipink = a._textdecorationskipink;
			this._textdecorationstyle = a._textdecorationstyle;
			this._textunderlineoffset = a._textunderlineoffset;
			this._textoverlineoffset = a._textoverlineoffset;
			this._textlinethroughoffset = a._textlinethroughoffset;
			this._fontstyle = a._fontstyle;
			this._transform = a._transform;
			this._texttransform = a._texttransform;
			this._transformoriginx = a._transformoriginx;
			this._transformoriginy = a._transformoriginy;
			this._letterspacing = a._letterspacing;
			this._textbackgroundimage = a._textbackgroundimage;
			this._whitespace = a._whitespace;
			this._zindex = a._zindex;
			this._order = a._order;
			this._soundin = a._soundin;
			this._soundout = a._soundout;
			this._pixelsnap = a._pixelsnap;
			this._backdropfilterblur = a._backdropfilterblur;
			this._backdropfilterbrightness = a._backdropfilterbrightness;
			this._backdropfiltercontrast = a._backdropfiltercontrast;
			this._backdropfiltersaturate = a._backdropfiltersaturate;
			this._backdropfiltersepia = a._backdropfiltersepia;
			this._backdropfilterinvert = a._backdropfilterinvert;
			this._backdropfilterhuerotate = a._backdropfilterhuerotate;
			this._filterblur = a._filterblur;
			this._filtersaturate = a._filtersaturate;
			this._filtersepia = a._filtersepia;
			this._filterbrightness = a._filterbrightness;
			this._filterhuerotate = a._filterhuerotate;
			this._filterinvert = a._filterinvert;
			this._filtercontrast = a._filtercontrast;
			this._filtertint = a._filtertint;
			this._backgroundimage = a._backgroundimage;
			this._backgroundsizex = a._backgroundsizex;
			this._backgroundsizey = a._backgroundsizey;
			this._backgroundpositionx = a._backgroundpositionx;
			this._backgroundpositiony = a._backgroundpositiony;
			this._backgroundrepeat = a._backgroundrepeat;
			this._borderimagesource = a._borderimagesource;
			this._borderimagewidthleft = a._borderimagewidthleft;
			this._borderimagewidthright = a._borderimagewidthright;
			this._borderimagewidthtop = a._borderimagewidthtop;
			this._borderimagewidthbottom = a._borderimagewidthbottom;
			this._borderimagefill = a._borderimagefill;
			this._borderimagerepeat = a._borderimagerepeat;
			this._backgroundtint = a._backgroundtint;
			this._backgroundangle = a._backgroundangle;
			this._textbackgroundangle = a._textbackgroundangle;
			this._textstrokecolor = a._textstrokecolor;
			this._textstrokewidth = a._textstrokewidth;
			this._imagerendering = a._imagerendering;
		}

		// Token: 0x0600185E RID: 6238 RVA: 0x00061E08 File Offset: 0x00060008
		public virtual bool Set(string property, string value)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(property);
			if (num <= 2282599171U)
			{
				if (num <= 981102864U)
				{
					if (num <= 549768767U)
					{
						if (num <= 306900080U)
						{
							if (num <= 124421828U)
							{
								if (num != 1202117U)
								{
									if (num == 124421828U)
									{
										if (property == "pointer-events")
										{
											this.PointerEvents = value.TrimQuoted(true);
											return true;
										}
									}
								}
								else if (property == "backdrop-filter-hue-rotate")
								{
									this.BackdropFilterHueRotate = Length.Parse(value);
									return this.BackdropFilterHueRotate != null;
								}
							}
							else if (num != 161346943U)
							{
								if (num != 306346147U)
								{
									if (num == 306900080U)
									{
										if (property == "left")
										{
											this.Left = Length.Parse(value);
											return this.Left != null;
										}
									}
								}
								else if (property == "backdrop-filter-sepia")
								{
									this.BackdropFilterSepia = Length.Parse(value);
									return this.BackdropFilterSepia != null;
								}
							}
							else if (property == "aspect-ratio")
							{
								this.AspectRatio = new float?(float.Parse(value, CultureInfo.InvariantCulture));
								return this.AspectRatio != null;
							}
						}
						else if (num <= 439497487U)
						{
							if (num != 387234597U)
							{
								if (num == 439497487U)
								{
									if (property == "backdrop-filter-invert")
									{
										this.BackdropFilterInvert = Length.Parse(value);
										return this.BackdropFilterInvert != null;
									}
								}
							}
							else if (property == "mix-blend-mode")
							{
								this.MixBlendMode = value.TrimQuoted(true);
								return true;
							}
						}
						else if (num != 479145663U)
						{
							if (num != 541745458U)
							{
								if (num == 549768767U)
								{
									if (property == "font-family")
									{
										this.FontFamily = value.TrimQuoted(true);
										return true;
									}
								}
							}
							else if (property == "flex-grow")
							{
								this.FlexGrow = new float?(float.Parse(value, CultureInfo.InvariantCulture));
								return this.FlexGrow != null;
							}
						}
						else if (property == "filter-blur")
						{
							this.FilterBlur = Length.Parse(value);
							return this.FilterBlur != null;
						}
					}
					else if (num <= 805531780U)
					{
						if (num <= 608042953U)
						{
							if (num != 591265334U)
							{
								if (num == 608042953U)
								{
									if (property == "transform-origin-x")
									{
										this.TransformOriginX = Length.Parse(value);
										return this.TransformOriginX != null;
									}
								}
							}
							else if (property == "transform-origin-y")
							{
								this.TransformOriginY = Length.Parse(value);
								return this.TransformOriginY != null;
							}
						}
						else if (num != 615486885U)
						{
							if (num != 655343477U)
							{
								if (num == 805531780U)
								{
									if (property == "border-bottom-width")
									{
										this.BorderBottomWidth = Length.Parse(value);
										return this.BorderBottomWidth != null;
									}
								}
							}
							else if (property == "background-tint")
							{
								this.BackgroundTint = Color.Parse(value);
								return this.BackgroundTint != null;
							}
						}
						else if (property == "filter-brightness")
						{
							this.FilterBrightness = Length.Parse(value);
							return this.FilterBrightness != null;
						}
					}
					else if (num <= 892039382U)
					{
						if (num != 823368261U)
						{
							if (num != 863171135U)
							{
								if (num == 892039382U)
								{
									if (property == "font-color")
									{
										this.FontColor = Color.Parse(value);
										return this.FontColor != null;
									}
								}
							}
							else if (property == "max-height")
							{
								this.MaxHeight = Length.Parse(value);
								return this.MaxHeight != null;
							}
						}
						else if (property == "margin-top")
						{
							this.MarginTop = Length.Parse(value);
							return this.MarginTop != null;
						}
					}
					else if (num != 898763051U)
					{
						if (num != 977553589U)
						{
							if (num == 981102864U)
							{
								if (property == "filter-sepia")
								{
									this.FilterSepia = Length.Parse(value);
									return this.FilterSepia != null;
								}
							}
						}
						else if (property == "flex-basis")
						{
							this.FlexBasis = Length.Parse(value);
							return this.FlexBasis != null;
						}
					}
					else if (property == "text-stroke-color")
					{
						this.TextStrokeColor = Color.Parse(value);
						return this.TextStrokeColor != null;
					}
				}
				else if (num <= 1594274462U)
				{
					if (num <= 1266884988U)
					{
						if (num <= 1103135245U)
						{
							if (num != 1018753090U)
							{
								if (num == 1103135245U)
								{
									if (property == "border-right-width")
									{
										this.BorderRightWidth = Length.Parse(value);
										return this.BorderRightWidth != null;
									}
								}
							}
							else if (property == "border-bottom-left-radius")
							{
								this.BorderBottomLeftRadius = Length.Parse(value);
								return this.BorderBottomLeftRadius != null;
							}
						}
						else if (num != 1177978080U)
						{
							if (num != 1180794985U)
							{
								if (num == 1266884988U)
								{
									if (property == "filter-contrast")
									{
										this.FilterContrast = Length.Parse(value);
										return this.FilterContrast != null;
									}
								}
							}
							else if (property == "backdrop-filter-contrast")
							{
								this.BackdropFilterContrast = Length.Parse(value);
								return this.BackdropFilterContrast != null;
							}
						}
						else if (property == "margin-right")
						{
							this.MarginRight = Length.Parse(value);
							return this.MarginRight != null;
						}
					}
					else if (num <= 1347314282U)
					{
						if (num != 1306599407U)
						{
							if (num != 1319594794U)
							{
								if (num == 1347314282U)
								{
									if (property == "pixel-snap")
									{
										this.PixelSnap = new int?(int.Parse(value, CultureInfo.InvariantCulture));
										return this.PixelSnap != null;
									}
								}
							}
							else if (property == "bottom")
							{
								this.Bottom = Length.Parse(value);
								return this.Bottom != null;
							}
						}
						else if (property == "margin-left")
						{
							this.MarginLeft = Length.Parse(value);
							return this.MarginLeft != null;
						}
					}
					else if (num != 1466694928U)
					{
						if (num != 1525829549U)
						{
							if (num == 1594274462U)
							{
								if (property == "backdrop-filter-saturate")
								{
									this.BackdropFilterSaturate = Length.Parse(value);
									return this.BackdropFilterSaturate != null;
								}
							}
						}
						else if (property == "text-line-through-offset")
						{
							this.TextLineThroughOffset = Length.Parse(value);
							return this.TextLineThroughOffset != null;
						}
					}
					else if (property == "padding-top")
					{
						this.PaddingTop = Length.Parse(value);
						return this.PaddingTop != null;
					}
				}
				else if (num <= 2028154341U)
				{
					if (num <= 1703669005U)
					{
						if (num != 1686075782U)
						{
							if (num == 1703669005U)
							{
								if (property == "text-underline-offset")
								{
									this.TextUnderlineOffset = Length.Parse(value);
									return this.TextUnderlineOffset != null;
								}
							}
						}
						else if (property == "filter-invert")
						{
							this.FilterInvert = Length.Parse(value);
							return this.FilterInvert != null;
						}
					}
					else if (num != 1834955718U)
					{
						if (num != 1932267671U)
						{
							if (num == 2028154341U)
							{
								if (property == "right")
								{
									this.Right = Length.Parse(value);
									return this.Right != null;
								}
							}
						}
						else if (property == "order")
						{
							this.Order = new int?(int.Parse(value, CultureInfo.InvariantCulture));
							return this.Order != null;
						}
					}
					else if (property == "border-top-left-radius")
					{
						this.BorderTopLeftRadius = Length.Parse(value);
						return this.BorderTopLeftRadius != null;
					}
				}
				else if (num <= 2214501220U)
				{
					if (num != 2039958762U)
					{
						if (num != 2148321084U)
						{
							if (num == 2214501220U)
							{
								if (property == "backdrop-filter-brightness")
								{
									this.BackdropFilterBrightness = Length.Parse(value);
									return this.BackdropFilterBrightness != null;
								}
							}
						}
						else if (property == "z-index")
						{
							this.ZIndex = new int?(int.Parse(value, CultureInfo.InvariantCulture));
							return this.ZIndex != null;
						}
					}
					else if (property == "border-right-color")
					{
						this.BorderRightColor = Color.Parse(value);
						return this.BorderRightColor != null;
					}
				}
				else if (num != 2277983267U)
				{
					if (num != 2281257280U)
					{
						if (num == 2282599171U)
						{
							if (property == "border-bottom-right-radius")
							{
								this.BorderBottomRightRadius = Length.Parse(value);
								return this.BorderBottomRightRadius != null;
							}
						}
					}
					else if (property == "text-stroke-width")
					{
						this.TextStrokeWidth = Length.Parse(value);
						return this.TextStrokeWidth != null;
					}
				}
				else if (property == "background-angle")
				{
					this.BackgroundAngle = Length.Parse(value);
					return this.BackgroundAngle != null;
				}
			}
			else if (num <= 3233686895U)
			{
				if (num <= 2570238541U)
				{
					if (num <= 2502958641U)
					{
						if (num <= 2425137969U)
						{
							if (num != 2416839281U)
							{
								if (num == 2425137969U)
								{
									if (property == "letter-spacing")
									{
										this.LetterSpacing = Length.Parse(value);
										return this.LetterSpacing != null;
									}
								}
							}
							else if (property == "margin-bottom")
							{
								this.MarginBottom = Length.Parse(value);
								return this.MarginBottom != null;
							}
						}
						else if (num != 2428421058U)
						{
							if (num != 2434669848U)
							{
								if (num == 2502958641U)
								{
									if (property == "white-space")
									{
										this.WhiteSpace = value.TrimQuoted(true);
										return true;
									}
								}
							}
							else if (property == "text-decoration-thickness")
							{
								this.TextDecorationThickness = Length.Parse(value);
								return this.TextDecorationThickness != null;
							}
						}
						else if (property == "content")
						{
							this.Content = value.TrimQuoted(true);
							return true;
						}
					}
					else if (num <= 2508680735U)
					{
						if (num != 2505554471U)
						{
							if (num == 2508680735U)
							{
								if (property == "width")
								{
									this.Width = Length.Parse(value);
									return this.Width != null;
								}
							}
						}
						else if (property == "filter-saturate")
						{
							this.FilterSaturate = Length.Parse(value);
							return this.FilterSaturate != null;
						}
					}
					else if (num != 2537258143U)
					{
						if (num != 2560944639U)
						{
							if (num == 2570238541U)
							{
								if (property == "sound-out")
								{
									this.SoundOut = value.TrimQuoted(true);
									return true;
								}
							}
						}
						else if (property == "border-bottom-color")
						{
							this.BorderBottomColor = Color.Parse(value);
							return this.BorderBottomColor != null;
						}
					}
					else if (property == "filter-tint")
					{
						this.FilterTint = Color.Parse(value);
						return this.FilterTint != null;
					}
				}
				else if (num <= 2930062261U)
				{
					if (num <= 2802900028U)
					{
						if (num != 2679686814U)
						{
							if (num == 2802900028U)
							{
								if (property == "top")
								{
									this.Top = Length.Parse(value);
									return this.Top != null;
								}
							}
						}
						else if (property == "border-left-width")
						{
							this.BorderLeftWidth = Length.Parse(value);
							return this.BorderLeftWidth != null;
						}
					}
					else if (num != 2876783500U)
					{
						if (num != 2884213241U)
						{
							if (num == 2930062261U)
							{
								if (property == "border-left-color")
								{
									this.BorderLeftColor = Color.Parse(value);
									return this.BorderLeftColor != null;
								}
							}
						}
						else if (property == "border-image-width-right")
						{
							this.BorderImageWidthRight = Length.Parse(value);
							return this.BorderImageWidthRight != null;
						}
					}
					else if (property == "padding-left")
					{
						this.PaddingLeft = Length.Parse(value);
						return this.PaddingLeft != null;
					}
				}
				else if (num <= 3139525104U)
				{
					if (num != 2941675018U)
					{
						if (num != 3133968552U)
						{
							if (num == 3139525104U)
							{
								if (property == "border-image-width-top")
								{
									this.BorderImageWidthTop = Length.Parse(value);
									return this.BorderImageWidthTop != null;
								}
							}
						}
						else if (property == "max-width")
						{
							this.MaxWidth = Length.Parse(value);
							return this.MaxWidth != null;
						}
					}
					else if (property == "min-width")
					{
						this.MinWidth = Length.Parse(value);
						return this.MinWidth != null;
					}
				}
				else if (num != 3146211815U)
				{
					if (num != 3155874280U)
					{
						if (num == 3233686895U)
						{
							if (property == "border-top-right-radius")
							{
								this.BorderTopRightRadius = Length.Parse(value);
								return this.BorderTopRightRadius != null;
							}
						}
					}
					else if (property == "sound-in")
					{
						this.SoundIn = value.TrimQuoted(true);
						return true;
					}
				}
				else if (property == "text-background-angle")
				{
					this.TextBackgroundAngle = Length.Parse(value);
					return this.TextBackgroundAngle != null;
				}
			}
			else if (num <= 3676230927U)
			{
				if (num <= 3435279781U)
				{
					if (num <= 3328355879U)
					{
						if (num != 3247228931U)
						{
							if (num == 3328355879U)
							{
								if (property == "background-color")
								{
									this.BackgroundColor = Color.Parse(value);
									return this.BackgroundColor != null;
								}
							}
						}
						else if (property == "font-weight")
						{
							this.FontWeight = new int?(int.Parse(value, CultureInfo.InvariantCulture));
							return this.FontWeight != null;
						}
					}
					else if (num != 3334659430U)
					{
						if (num != 3391345689U)
						{
							if (num == 3435279781U)
							{
								if (property == "min-height")
								{
									this.MinHeight = Length.Parse(value);
									return this.MinHeight != null;
								}
							}
						}
						else if (property == "padding-right")
						{
							this.PaddingRight = Length.Parse(value);
							return this.PaddingRight != null;
						}
					}
					else if (property == "opacity")
					{
						this.Opacity = new float?(float.Parse(value, CultureInfo.InvariantCulture));
						return this.Opacity != null;
					}
				}
				else if (num <= 3568407124U)
				{
					if (num != 3504398499U)
					{
						if (num != 3563869816U)
						{
							if (num == 3568407124U)
							{
								if (property == "background-size-x")
								{
									this.BackgroundSizeX = Length.Parse(value);
									return this.BackgroundSizeX != null;
								}
							}
						}
						else if (property == "flex-shrink")
						{
							this.FlexShrink = new float?(float.Parse(value, CultureInfo.InvariantCulture));
							return this.FlexShrink != null;
						}
					}
					else if (property == "border-top-color")
					{
						this.BorderTopColor = Color.Parse(value);
						return this.BorderTopColor != null;
					}
				}
				else if (num != 3585184743U)
				{
					if (num != 3585981250U)
					{
						if (num == 3676230927U)
						{
							if (property == "text-overline-offset")
							{
								this.TextOverlineOffset = Length.Parse(value);
								return this.TextOverlineOffset != null;
							}
						}
					}
					else if (property == "height")
					{
						this.Height = Length.Parse(value);
						return this.Height != null;
					}
				}
				else if (property == "background-size-y")
				{
					this.BackgroundSizeY = Length.Parse(value);
					return this.BackgroundSizeY != null;
				}
			}
			else if (num <= 3823062945U)
			{
				if (num <= 3716873594U)
				{
					if (num != 3678833132U)
					{
						if (num == 3716873594U)
						{
							if (property == "backdrop-filter-blur")
							{
								this.BackdropFilterBlur = Length.Parse(value);
								return this.BackdropFilterBlur != null;
							}
						}
					}
					else if (property == "border-image-width-left")
					{
						this.BorderImageWidthLeft = Length.Parse(value);
						return this.BorderImageWidthLeft != null;
					}
				}
				else if (num != 3721866516U)
				{
					if (num != 3811979791U)
					{
						if (num == 3823062945U)
						{
							if (property == "text-decoration-color")
							{
								this.TextDecorationColor = Color.Parse(value);
								return this.TextDecorationColor != null;
							}
						}
					}
					else if (property == "cursor")
					{
						this.Cursor = value.TrimQuoted(true);
						return true;
					}
				}
				else if (property == "filter-hue-rotate")
				{
					this.FilterHueRotate = Length.Parse(value);
					return this.FilterHueRotate != null;
				}
			}
			else if (num <= 3905250041U)
			{
				if (num != 3860607080U)
				{
					if (num != 3888472422U)
					{
						if (num == 3905250041U)
						{
							if (property == "background-position-y")
							{
								this.BackgroundPositionY = Length.Parse(value);
								return this.BackgroundPositionY != null;
							}
						}
					}
					else if (property == "background-position-x")
					{
						this.BackgroundPositionX = Length.Parse(value);
						return this.BackgroundPositionX != null;
					}
				}
				else if (property == "border-top-width")
				{
					this.BorderTopWidth = Length.Parse(value);
					return this.BorderTopWidth != null;
				}
			}
			else if (num != 3975754638U)
			{
				if (num != 4024225262U)
				{
					if (num == 4284404126U)
					{
						if (property == "font-size")
						{
							this.FontSize = Length.Parse(value);
							return this.FontSize != null;
						}
					}
				}
				else if (property == "border-image-width-bottom")
				{
					this.BorderImageWidthBottom = Length.Parse(value);
					return this.BorderImageWidthBottom != null;
				}
			}
			else if (property == "padding-bottom")
			{
				this.PaddingBottom = Length.Parse(value);
				return this.PaddingBottom != null;
			}
			GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unknown Property: {0} / {1}", new object[] { property, value }));
			return false;
		}

		// Token: 0x0600185F RID: 6239 RVA: 0x000633B8 File Offset: 0x000615B8
		public override int GetHashCode()
		{
			return HashCode.Combine<int, ImageRendering?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Color?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Color?>(HashCode.Combine<int, BorderImageRepeat?>(HashCode.Combine<int, BorderImageFill?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Texture>(HashCode.Combine<int, BackgroundRepeat?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Texture>(HashCode.Combine<int, Color?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, int?>(HashCode.Combine<int, string>(HashCode.Combine<int, string>(HashCode.Combine<int, int?>(HashCode.Combine<int, int?>(HashCode.Combine<int, string>(HashCode.Combine<int, Texture>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, TextTransform?>(HashCode.Combine<int, PanelTransform?>(HashCode.Combine<int, FontStyle?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, TextDecorationStyle?>(HashCode.Combine<int, TextSkipInk?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Color?>(HashCode.Combine<int, TextDecoration?>(HashCode.Combine<int, TextAlign?>(HashCode.Combine<int, float?>(HashCode.Combine<int, float?>(HashCode.Combine<int, float?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Align?>(HashCode.Combine<int, Align?>(HashCode.Combine<int, Align?>(HashCode.Combine<int, Wrap?>(HashCode.Combine<int, DisplayMode?>(HashCode.Combine<int, Justify?>(HashCode.Combine<int, FlexDirection?>(HashCode.Combine<int, OverflowMode?>(HashCode.Combine<int, PositionMode?>(HashCode.Combine<int, ColorInterpolation?>(HashCode.Combine<int, string>(HashCode.Combine<int, string>(HashCode.Combine<int, string>(HashCode.Combine<int, string>(HashCode.Combine<int, int?>(HashCode.Combine<int, Color?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Color?>(HashCode.Combine<int, Color?>(HashCode.Combine<int, Color?>(HashCode.Combine<int, Color?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Color?>(HashCode.Combine<int, float?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, Length?>(HashCode.Combine<int, string>(0, this._content), this._width), this._minwidth), this._maxwidth), this._height), this._minheight), this._maxheight), this._left), this._top), this._right), this._bottom), this._opacity), this._backgroundcolor), this._paddingleft), this._paddingtop), this._paddingright), this._paddingbottom), this._marginleft), this._margintop), this._marginright), this._marginbottom), this._bordertopleftradius), this._bordertoprightradius), this._borderbottomrightradius), this._borderbottomleftradius), this._borderleftwidth), this._bordertopwidth), this._borderrightwidth), this._borderbottomwidth), this._borderleftcolor), this._bordertopcolor), this._borderrightcolor), this._borderbottomcolor), this._fontsize), this._fontcolor), this._fontweight), this._fontfamily), this._cursor), this._pointerevents), this._mixblendmode), this._colorinterpolation), this._position), this._overflow), this._flexdirection), this._justifycontent), this._display), this._flexwrap), this._aligncontent), this._alignself), this._alignitems), this._flexbasis), this._flexgrow), this._flexshrink), this._aspectratio), this._textalign), this._textdecorationline), this._textdecorationcolor), this._textdecorationthickness), this._textdecorationskipink), this._textdecorationstyle), this._textunderlineoffset), this._textoverlineoffset), this._textlinethroughoffset), this._fontstyle), this._transform), this._texttransform), this._transformoriginx), this._transformoriginy), this._letterspacing), this._textbackgroundimage), this._whitespace), this._zindex), this._order), this._soundin), this._soundout), this._pixelsnap), this._backdropfilterblur), this._backdropfilterbrightness), this._backdropfiltercontrast), this._backdropfiltersaturate), this._backdropfiltersepia), this._backdropfilterinvert), this._backdropfilterhuerotate), this._filterblur), this._filtersaturate), this._filtersepia), this._filterbrightness), this._filterhuerotate), this._filterinvert), this._filtercontrast), this._filtertint), this._backgroundimage), this._backgroundsizex), this._backgroundsizey), this._backgroundpositionx), this._backgroundpositiony), this._backgroundrepeat), this._borderimagesource), this._borderimagewidthleft), this._borderimagewidthright), this._borderimagewidthtop), this._borderimagewidthbottom), this._borderimagefill), this._borderimagerepeat), this._backgroundtint), this._backgroundangle), this._textbackgroundangle), this._textstrokecolor), this._textstrokewidth), this._imagerendering);
		}

		// Token: 0x040005EE RID: 1518
		internal string _content;

		// Token: 0x040005EF RID: 1519
		internal Length? _width;

		// Token: 0x040005F0 RID: 1520
		internal Length? _minwidth;

		// Token: 0x040005F1 RID: 1521
		internal Length? _maxwidth;

		// Token: 0x040005F2 RID: 1522
		internal Length? _height;

		// Token: 0x040005F3 RID: 1523
		internal Length? _minheight;

		// Token: 0x040005F4 RID: 1524
		internal Length? _maxheight;

		// Token: 0x040005F5 RID: 1525
		internal Length? _left;

		// Token: 0x040005F6 RID: 1526
		internal Length? _top;

		// Token: 0x040005F7 RID: 1527
		internal Length? _right;

		// Token: 0x040005F8 RID: 1528
		internal Length? _bottom;

		// Token: 0x040005F9 RID: 1529
		internal float? _opacity;

		// Token: 0x040005FA RID: 1530
		internal Color? _backgroundcolor;

		// Token: 0x040005FB RID: 1531
		internal Length? _paddingleft;

		// Token: 0x040005FC RID: 1532
		internal Length? _paddingtop;

		// Token: 0x040005FD RID: 1533
		internal Length? _paddingright;

		// Token: 0x040005FE RID: 1534
		internal Length? _paddingbottom;

		// Token: 0x040005FF RID: 1535
		internal Length? _marginleft;

		// Token: 0x04000600 RID: 1536
		internal Length? _margintop;

		// Token: 0x04000601 RID: 1537
		internal Length? _marginright;

		// Token: 0x04000602 RID: 1538
		internal Length? _marginbottom;

		// Token: 0x04000603 RID: 1539
		internal Length? _bordertopleftradius;

		// Token: 0x04000604 RID: 1540
		internal Length? _bordertoprightradius;

		// Token: 0x04000605 RID: 1541
		internal Length? _borderbottomrightradius;

		// Token: 0x04000606 RID: 1542
		internal Length? _borderbottomleftradius;

		// Token: 0x04000607 RID: 1543
		internal Length? _borderleftwidth;

		// Token: 0x04000608 RID: 1544
		internal Length? _bordertopwidth;

		// Token: 0x04000609 RID: 1545
		internal Length? _borderrightwidth;

		// Token: 0x0400060A RID: 1546
		internal Length? _borderbottomwidth;

		// Token: 0x0400060B RID: 1547
		internal Color? _borderleftcolor;

		// Token: 0x0400060C RID: 1548
		internal Color? _bordertopcolor;

		// Token: 0x0400060D RID: 1549
		internal Color? _borderrightcolor;

		// Token: 0x0400060E RID: 1550
		internal Color? _borderbottomcolor;

		// Token: 0x0400060F RID: 1551
		internal Length? _fontsize;

		// Token: 0x04000610 RID: 1552
		internal Color? _fontcolor;

		// Token: 0x04000611 RID: 1553
		internal int? _fontweight;

		// Token: 0x04000612 RID: 1554
		internal string _fontfamily;

		// Token: 0x04000613 RID: 1555
		internal string _cursor;

		// Token: 0x04000614 RID: 1556
		internal string _pointerevents;

		// Token: 0x04000615 RID: 1557
		internal string _mixblendmode;

		// Token: 0x04000616 RID: 1558
		internal ColorInterpolation? _colorinterpolation;

		// Token: 0x04000617 RID: 1559
		internal PositionMode? _position;

		// Token: 0x04000618 RID: 1560
		internal OverflowMode? _overflow;

		// Token: 0x04000619 RID: 1561
		internal FlexDirection? _flexdirection;

		// Token: 0x0400061A RID: 1562
		internal Justify? _justifycontent;

		// Token: 0x0400061B RID: 1563
		internal DisplayMode? _display;

		// Token: 0x0400061C RID: 1564
		internal Wrap? _flexwrap;

		// Token: 0x0400061D RID: 1565
		internal Align? _aligncontent;

		// Token: 0x0400061E RID: 1566
		internal Align? _alignself;

		// Token: 0x0400061F RID: 1567
		internal Align? _alignitems;

		// Token: 0x04000620 RID: 1568
		internal Length? _flexbasis;

		// Token: 0x04000621 RID: 1569
		internal float? _flexgrow;

		// Token: 0x04000622 RID: 1570
		internal float? _flexshrink;

		// Token: 0x04000623 RID: 1571
		internal float? _aspectratio;

		// Token: 0x04000624 RID: 1572
		internal TextAlign? _textalign;

		// Token: 0x04000625 RID: 1573
		internal TextDecoration? _textdecorationline;

		// Token: 0x04000626 RID: 1574
		internal Color? _textdecorationcolor;

		// Token: 0x04000627 RID: 1575
		internal Length? _textdecorationthickness;

		// Token: 0x04000628 RID: 1576
		internal TextSkipInk? _textdecorationskipink;

		// Token: 0x04000629 RID: 1577
		internal TextDecorationStyle? _textdecorationstyle;

		// Token: 0x0400062A RID: 1578
		internal Length? _textunderlineoffset;

		// Token: 0x0400062B RID: 1579
		internal Length? _textoverlineoffset;

		// Token: 0x0400062C RID: 1580
		internal Length? _textlinethroughoffset;

		// Token: 0x0400062D RID: 1581
		internal FontStyle? _fontstyle;

		// Token: 0x0400062E RID: 1582
		internal PanelTransform? _transform;

		// Token: 0x0400062F RID: 1583
		internal TextTransform? _texttransform;

		// Token: 0x04000630 RID: 1584
		internal Length? _transformoriginx;

		// Token: 0x04000631 RID: 1585
		internal Length? _transformoriginy;

		// Token: 0x04000632 RID: 1586
		internal Length? _letterspacing;

		// Token: 0x04000633 RID: 1587
		internal Texture _textbackgroundimage;

		// Token: 0x04000634 RID: 1588
		internal string _whitespace;

		// Token: 0x04000635 RID: 1589
		internal int? _zindex;

		// Token: 0x04000636 RID: 1590
		internal int? _order;

		// Token: 0x04000637 RID: 1591
		internal string _soundin;

		// Token: 0x04000638 RID: 1592
		internal string _soundout;

		// Token: 0x04000639 RID: 1593
		internal int? _pixelsnap;

		// Token: 0x0400063A RID: 1594
		internal Length? _backdropfilterblur;

		// Token: 0x0400063B RID: 1595
		internal Length? _backdropfilterbrightness;

		// Token: 0x0400063C RID: 1596
		internal Length? _backdropfiltercontrast;

		// Token: 0x0400063D RID: 1597
		internal Length? _backdropfiltersaturate;

		// Token: 0x0400063E RID: 1598
		internal Length? _backdropfiltersepia;

		// Token: 0x0400063F RID: 1599
		internal Length? _backdropfilterinvert;

		// Token: 0x04000640 RID: 1600
		internal Length? _backdropfilterhuerotate;

		// Token: 0x04000641 RID: 1601
		internal Length? _filterblur;

		// Token: 0x04000642 RID: 1602
		internal Length? _filtersaturate;

		// Token: 0x04000643 RID: 1603
		internal Length? _filtersepia;

		// Token: 0x04000644 RID: 1604
		internal Length? _filterbrightness;

		// Token: 0x04000645 RID: 1605
		internal Length? _filterhuerotate;

		// Token: 0x04000646 RID: 1606
		internal Length? _filterinvert;

		// Token: 0x04000647 RID: 1607
		internal Length? _filtercontrast;

		// Token: 0x04000648 RID: 1608
		internal Color? _filtertint;

		// Token: 0x04000649 RID: 1609
		internal Texture _backgroundimage;

		// Token: 0x0400064A RID: 1610
		internal Length? _backgroundsizex;

		// Token: 0x0400064B RID: 1611
		internal Length? _backgroundsizey;

		// Token: 0x0400064C RID: 1612
		internal Length? _backgroundpositionx;

		// Token: 0x0400064D RID: 1613
		internal Length? _backgroundpositiony;

		// Token: 0x0400064E RID: 1614
		internal BackgroundRepeat? _backgroundrepeat;

		// Token: 0x0400064F RID: 1615
		internal Texture _borderimagesource;

		// Token: 0x04000650 RID: 1616
		internal Length? _borderimagewidthleft;

		// Token: 0x04000651 RID: 1617
		internal Length? _borderimagewidthright;

		// Token: 0x04000652 RID: 1618
		internal Length? _borderimagewidthtop;

		// Token: 0x04000653 RID: 1619
		internal Length? _borderimagewidthbottom;

		// Token: 0x04000654 RID: 1620
		internal BorderImageFill? _borderimagefill;

		// Token: 0x04000655 RID: 1621
		internal BorderImageRepeat? _borderimagerepeat;

		// Token: 0x04000656 RID: 1622
		internal Color? _backgroundtint;

		// Token: 0x04000657 RID: 1623
		internal Length? _backgroundangle;

		// Token: 0x04000658 RID: 1624
		internal Length? _textbackgroundangle;

		// Token: 0x04000659 RID: 1625
		internal Color? _textstrokecolor;

		// Token: 0x0400065A RID: 1626
		internal Length? _textstrokewidth;

		// Token: 0x0400065B RID: 1627
		internal ImageRendering? _imagerendering;
	}
}
