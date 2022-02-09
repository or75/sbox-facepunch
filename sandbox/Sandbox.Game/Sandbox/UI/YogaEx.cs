using System;
using Facebook.Yoga;

namespace Sandbox.UI
{
	// Token: 0x02000129 RID: 297
	internal static class YogaEx
	{
		// Token: 0x0600170E RID: 5902 RVA: 0x0005C658 File Offset: 0x0005A858
		public static YogaValue ToYoga(this Length? self)
		{
			if (self == null)
			{
				return YogaEx.Undefined;
			}
			if (self.Value.Unit == LengthUnit.Auto)
			{
				return YogaValue.Auto();
			}
			if (self.Value.Unit == LengthUnit.Pixels)
			{
				return YogaValue.Point(self.Value.Value);
			}
			if (self.Value.Unit == LengthUnit.Percentage)
			{
				return YogaValue.Percent(self.Value.Value);
			}
			if (self.Value.Unit == LengthUnit.ViewHeight || self.Value.Unit == LengthUnit.ViewWidth || self.Value.Unit == LengthUnit.ViewMin || self.Value.Unit == LengthUnit.ViewMax)
			{
				return YogaValue.Point(self.Value.GetPixels(0f));
			}
			return YogaEx.Undefined;
		}

		// Token: 0x0600170F RID: 5903 RVA: 0x0005C71C File Offset: 0x0005A91C
		public static float ToFloat(this Length? self)
		{
			if (self == null)
			{
				return 0f;
			}
			LengthUnit unit = self.Value.Unit;
			return self.Value.Value;
		}

		// Token: 0x06001710 RID: 5904 RVA: 0x0005C75B File Offset: 0x0005A95B
		public static YogaPositionType ToYoga(this PositionMode? self)
		{
			if (self == null)
			{
				return YogaPositionType.Relative;
			}
			return (YogaPositionType)self.Value;
		}

		// Token: 0x06001711 RID: 5905 RVA: 0x0005C76F File Offset: 0x0005A96F
		public static YogaDisplay ToYoga(this DisplayMode? self)
		{
			if (self == null)
			{
				return YogaDisplay.Flex;
			}
			return (YogaDisplay)self.Value;
		}

		// Token: 0x06001712 RID: 5906 RVA: 0x0005C783 File Offset: 0x0005A983
		public static YogaWrap ToYoga(this Wrap? self)
		{
			if (self == null)
			{
				return YogaWrap.NoWrap;
			}
			return (YogaWrap)self.Value;
		}

		// Token: 0x06001713 RID: 5907 RVA: 0x0005C797 File Offset: 0x0005A997
		public static YogaAlign ToYoga(this Align? self, YogaAlign defaultval)
		{
			if (self == null)
			{
				return defaultval;
			}
			return (YogaAlign)self.Value;
		}

		// Token: 0x06001714 RID: 5908 RVA: 0x0005C7AB File Offset: 0x0005A9AB
		public static YogaFlexDirection ToYoga(this FlexDirection? self)
		{
			if (self == null)
			{
				return YogaFlexDirection.Row;
			}
			return (YogaFlexDirection)self.Value;
		}

		// Token: 0x06001715 RID: 5909 RVA: 0x0005C7BF File Offset: 0x0005A9BF
		public static YogaJustify ToYoga(this Justify? self)
		{
			if (self == null)
			{
				return YogaJustify.FlexStart;
			}
			return (YogaJustify)self.Value;
		}

		// Token: 0x06001716 RID: 5910 RVA: 0x0005C7D3 File Offset: 0x0005A9D3
		public static YogaOverflow ToYoga(this OverflowMode? self)
		{
			if (self == null)
			{
				return YogaOverflow.Visible;
			}
			return (YogaOverflow)self.Value;
		}

		// Token: 0x040005CC RID: 1484
		private static YogaValue Undefined = YogaValue.Undefined();

		// Token: 0x040005CD RID: 1485
		private static YogaValue Auto = YogaValue.Auto();
	}
}
