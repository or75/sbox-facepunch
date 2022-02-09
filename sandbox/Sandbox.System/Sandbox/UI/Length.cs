using System;
using System.Globalization;

namespace Sandbox.UI
{
	/// <summary>
	/// A variable unit based length. ie, could be a percentage or a pixel length
	/// </summary>
	// Token: 0x0200005C RID: 92
	public struct Length : IEquatable<Length>
	{
		/// <summary>
		/// Convert to a pixel value. Use the dimension to work out percentage values.
		/// </summary>
		// Token: 0x060003F7 RID: 1015 RVA: 0x0001E828 File Offset: 0x0001CA28
		public float GetPixels(float dimension)
		{
			if (this.Unit == LengthUnit.Percentage)
			{
				return dimension * (this.Value / 100f);
			}
			if (this.Unit == LengthUnit.ViewWidth)
			{
				return Length.RootSize.x * (this.Value / 100f);
			}
			if (this.Unit == LengthUnit.ViewHeight)
			{
				return Length.RootSize.y * (this.Value / 100f);
			}
			if (this.Unit == LengthUnit.ViewMin)
			{
				return Math.Min(Length.RootSize.x, Length.RootSize.y) * (this.Value / 100f);
			}
			if (this.Unit == LengthUnit.ViewMax)
			{
				return Math.Max(Length.RootSize.x, Length.RootSize.y) * (this.Value / 100f);
			}
			return this.Value;
		}

		/// <summary>
		/// Get the pixel size but also evaluate content size to support use Start, End, Center
		/// </summary>
		// Token: 0x060003F8 RID: 1016 RVA: 0x0001E8F5 File Offset: 0x0001CAF5
		public float GetPixels(float dimension, float contentSize)
		{
			if (this.Unit == LengthUnit.Start)
			{
				return 0f;
			}
			if (this.Unit == LengthUnit.End)
			{
				return dimension - contentSize;
			}
			if (this.Unit == LengthUnit.Center)
			{
				return (dimension - contentSize) * 0.5f;
			}
			return this.GetPixels(dimension);
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x0001E930 File Offset: 0x0001CB30
		public static implicit operator Length(float value)
		{
			return new Length
			{
				Value = value,
				Unit = LengthUnit.Pixels
			};
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x0001E956 File Offset: 0x0001CB56
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0001E969 File Offset: 0x0001CB69
		public override int GetHashCode()
		{
			return HashCode.Combine<float, LengthUnit>(this.Value, this.Unit);
		}

		/// <summary>
		/// Lerp from one length to another. 
		/// </summary>
		/// <param name="a">Length at delta 0</param>
		/// <param name="b">Length at delta 1</param>
		/// <param name="delta">The interpolation stage</param>
		/// <param name="dimension">The width or height of the parent to use when working out percentage lengths</param>
		/// <returns>The lerped Length</returns>
		// Token: 0x060003FC RID: 1020 RVA: 0x0001E97C File Offset: 0x0001CB7C
		internal static Length? Lerp(Length a, Length b, float delta, float dimension)
		{
			float x = a.GetPixels(dimension);
			float diff = b.GetPixels(dimension) - x;
			return new Length?(x + diff * delta);
		}

		/// <summary>
		/// Lerp from one length to another. 
		/// </summary>
		/// <param name="a">Length at delta 0</param>
		/// <param name="b">Length at delta 1</param>
		/// <param name="delta">The interpolation stage</param>
		/// <returns>The lerped Length</returns>
		// Token: 0x060003FD RID: 1021 RVA: 0x0001E9AC File Offset: 0x0001CBAC
		internal static Length? Lerp(Length a, Length b, float delta)
		{
			if (a.Unit != b.Unit)
			{
				return new Length?(b);
			}
			return new Length?(new Length
			{
				Unit = a.Unit,
				Value = a.Value.LerpTo(b.Value, delta, false)
			});
		}

		/// <summary>
		/// Create a length in pixels
		/// </summary>
		/// <param name="pixels">The amount of pixels for this length</param>
		/// <returns>A new length</returns>
		// Token: 0x060003FE RID: 1022 RVA: 0x0001EA04 File Offset: 0x0001CC04
		public static Length? Pixels(float pixels)
		{
			return new Length?(new Length
			{
				Value = pixels,
				Unit = LengthUnit.Pixels
			});
		}

		/// <summary>
		/// Create a length in percents
		/// </summary>
		/// <param name="percent">The amount of percent for this (0-100)</param>
		/// <returns>A new length</returns>
		// Token: 0x060003FF RID: 1023 RVA: 0x0001EA30 File Offset: 0x0001CC30
		public static Length? Percent(float percent)
		{
			return new Length?(new Length
			{
				Value = percent,
				Unit = LengthUnit.Percentage
			});
		}

		/// <summary>
		/// Create a length based on the view height
		/// </summary>
		/// <param name="percentage">The amount of percent for this (0-100)</param>
		/// <returns>A new length</returns>
		// Token: 0x06000400 RID: 1024 RVA: 0x0001EA5C File Offset: 0x0001CC5C
		public static Length? ViewHeight(float percentage)
		{
			return new Length?(new Length
			{
				Value = percentage,
				Unit = LengthUnit.ViewHeight
			});
		}

		/// <summary>
		/// Create a length based on the view width
		/// </summary>
		/// <param name="percentage">The amount of percent for this (0-100)</param>
		/// <returns>A new length</returns>
		// Token: 0x06000401 RID: 1025 RVA: 0x0001EA88 File Offset: 0x0001CC88
		public static Length? ViewWidth(float percentage)
		{
			return new Length?(new Length
			{
				Value = percentage,
				Unit = LengthUnit.ViewWidth
			});
		}

		/// <summary>
		/// Create a length based on the the maximum of the screen size
		/// </summary>
		/// <param name="percentage">The amount of percent for this (0-100)</param>
		/// <returns>A new length</returns>
		// Token: 0x06000402 RID: 1026 RVA: 0x0001EAB4 File Offset: 0x0001CCB4
		public static Length? ViewMax(float percentage)
		{
			return new Length?(new Length
			{
				Value = percentage,
				Unit = LengthUnit.ViewMax
			});
		}

		/// <summary>
		/// Create a length based on the the minimum of the screen size
		/// </summary>
		/// <param name="percentage">The amount of percent for this (0-100)</param>
		/// <returns>A new length</returns>
		// Token: 0x06000403 RID: 1027 RVA: 0x0001EAE0 File Offset: 0x0001CCE0
		public static Length? ViewMin(float percentage)
		{
			return new Length?(new Length
			{
				Value = percentage,
				Unit = LengthUnit.ViewMin
			});
		}

		/// <summary>
		/// Create a length in percents
		/// </summary>
		/// <param name="fraction">The fraction of a percent (0 = 0%, 1 = 100%)</param>
		/// <returns>A new length</returns>
		// Token: 0x06000404 RID: 1028 RVA: 0x0001EB0B File Offset: 0x0001CD0B
		public static Length? Fraction(float fraction)
		{
			return Length.Percent(fraction * 100f);
		}

		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x06000405 RID: 1029 RVA: 0x0001EB1C File Offset: 0x0001CD1C
		public static Length Auto
		{
			get
			{
				return new Length
				{
					Unit = LengthUnit.Auto
				};
			}
		}

		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x06000406 RID: 1030 RVA: 0x0001EB3C File Offset: 0x0001CD3C
		public static Length Contain
		{
			get
			{
				return new Length
				{
					Unit = LengthUnit.Contain
				};
			}
		}

		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x06000407 RID: 1031 RVA: 0x0001EB5C File Offset: 0x0001CD5C
		public static Length Cover
		{
			get
			{
				return new Length
				{
					Unit = LengthUnit.Cover
				};
			}
		}

		/// <summary>
		/// Parse a length. This is used by the stylesheet parsing system.
		/// </summary>
		/// <param name="value">A length represented by a string</param>
		/// <example>Length.Parse( "100px" )</example>
		/// <example>Length.Parse( "56%" )</example>
		/// <returns></returns>
		// Token: 0x06000408 RID: 1032 RVA: 0x0001EB7C File Offset: 0x0001CD7C
		public static Length? Parse(string value)
		{
			if (value == "center")
			{
				return new Length?(new Length
				{
					Unit = LengthUnit.Center
				});
			}
			if (value == "left" || value == "top")
			{
				return new Length?(new Length
				{
					Unit = LengthUnit.Start
				});
			}
			if (value == "right" || value == "bottom")
			{
				return new Length?(new Length
				{
					Unit = LengthUnit.End
				});
			}
			if (value == "cover")
			{
				return new Length?(Length.Cover);
			}
			if (value == "contain")
			{
				return new Length?(Length.Contain);
			}
			if (value == "auto")
			{
				return new Length?(Length.Auto);
			}
			int pc = value.IndexOf('%');
			if (pc > 0)
			{
				return Length.Percent(float.Parse(value.Substring(0, pc), CultureInfo.InvariantCulture));
			}
			int p = value.IndexOf('p');
			int x = value.IndexOf('x');
			if (p > 0 && x == p + 1)
			{
				return Length.Pixels(float.Parse(value.Substring(0, p), CultureInfo.InvariantCulture));
			}
			int d = value.IndexOf('d');
			int e = value.IndexOf('e');
			int g = value.IndexOf('g');
			if (d > 0 && e == d + 1 && g == d + 2)
			{
				return Length.Pixels(float.Parse(value.Substring(0, d), CultureInfo.InvariantCulture));
			}
			int v = value.IndexOf('v');
			int h = value.IndexOf('h');
			if (v > 0 && h == v + 1)
			{
				return Length.ViewHeight(float.Parse(value.Substring(0, v), CultureInfo.InvariantCulture));
			}
			int w = value.IndexOf('w');
			if (v > 0 && w == v + 1)
			{
				return Length.ViewWidth(float.Parse(value.Substring(0, v), CultureInfo.InvariantCulture));
			}
			int i = value.IndexOf('m');
			int j = value.IndexOf('i');
			int k = value.IndexOf('n');
			if (v > 0 && i == v + 1 && j == v + 2 && k == v + 3)
			{
				return Length.ViewMin(float.Parse(value.Substring(0, v), CultureInfo.InvariantCulture));
			}
			int a = value.IndexOf('a');
			if (v > 0 && i == v + 1 && a == v + 2 && x == v + 3)
			{
				return Length.ViewMax(float.Parse(value.Substring(0, v), CultureInfo.InvariantCulture));
			}
			float fnum;
			if (float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out fnum))
			{
				return Length.Pixels(fnum);
			}
			return null;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x0001EE20 File Offset: 0x0001D020
		public bool Equals(Length other)
		{
			float value = this.Value;
			LengthUnit unit = this.Unit;
			float value2 = other.Value;
			LengthUnit unit2 = other.Unit;
			return value == value2 && unit == unit2;
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0001EE51 File Offset: 0x0001D051
		public static bool operator ==(Length lhs, Length rhs)
		{
			return lhs.Equals(rhs);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0001EE5B File Offset: 0x0001D05B
		public static bool operator !=(Length lhs, Length rhs)
		{
			return !lhs.Equals(rhs);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x0001EE68 File Offset: 0x0001D068
		public static bool operator ==(Length? lhs, Length? rhs)
		{
			return (lhs == null && rhs == null) || (lhs != null && rhs != null && lhs.Value.Equals(rhs.Value));
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x0001EEB8 File Offset: 0x0001D0B8
		public static bool operator !=(Length? lhs, Length? rhs)
		{
			return (lhs != null || rhs != null) && (lhs == null || rhs == null || !lhs.Value.Equals(rhs.Value));
		}

		/// <summary>
		/// If it's a %, will return 0-1. If not it'll return its value.
		/// </summary>
		// Token: 0x0600040E RID: 1038 RVA: 0x0001EF08 File Offset: 0x0001D108
		internal float GetFraction(float f = 1f)
		{
			return this.GetPixels(1f) * f;
		}

		// Token: 0x0600040F RID: 1039 RVA: 0x0001EF18 File Offset: 0x0001D118
		public override string ToString()
		{
			if (this.Unit == LengthUnit.Pixels)
			{
				return string.Format("{0}px", this.Value);
			}
			if (this.Unit == LengthUnit.Percentage)
			{
				return string.Format("{0}%", this.Value);
			}
			return string.Format("{0}", this.Unit);
		}

		// Token: 0x040008CE RID: 2254
		public float Value;

		// Token: 0x040008CF RID: 2255
		public LengthUnit Unit;

		/// <summary>
		/// The current root panel size. This is required for vh, vw, vmin and vmax. This is set During PreLayout, Layout and PostLayout
		/// </summary>
		// Token: 0x040008D0 RID: 2256
		internal static Vector2 RootSize;
	}
}
