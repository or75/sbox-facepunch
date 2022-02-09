using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x0200002D RID: 45
	internal struct CGlowProperty
	{
		// Token: 0x06000663 RID: 1635 RVA: 0x0002F666 File Offset: 0x0002D866
		public static implicit operator IntPtr(CGlowProperty value)
		{
			return value.self;
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0002F670 File Offset: 0x0002D870
		public static implicit operator CGlowProperty(IntPtr value)
		{
			return new CGlowProperty
			{
				self = value
			};
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x0002F68E File Offset: 0x0002D88E
		public static bool operator ==(CGlowProperty c1, CGlowProperty c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x0002F6A1 File Offset: 0x0002D8A1
		public static bool operator !=(CGlowProperty c1, CGlowProperty c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x0002F6B4 File Offset: 0x0002D8B4
		public override bool Equals(object obj)
		{
			if (obj is CGlowProperty)
			{
				CGlowProperty c = (CGlowProperty)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x0002F6DE File Offset: 0x0002D8DE
		internal CGlowProperty(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x0002F6E8 File Offset: 0x0002D8E8
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(14, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CGlowProperty ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x0600066A RID: 1642 RVA: 0x0002F724 File Offset: 0x0002D924
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x0600066B RID: 1643 RVA: 0x0002F736 File Offset: 0x0002D936
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600066C RID: 1644 RVA: 0x0002F741 File Offset: 0x0002D941
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600066D RID: 1645 RVA: 0x0002F754 File Offset: 0x0002D954
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CGlowProperty was null when calling " + n);
			}
		}

		// Token: 0x0600066E RID: 1646 RVA: 0x0002F76F File Offset: 0x0002D96F
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600066F RID: 1647 RVA: 0x0002F77C File Offset: 0x0002D97C
		internal readonly void SetGlowState(int iType)
		{
			this.NullCheck("SetGlowState");
			method cglwPr_SetGlowState = CGlowProperty.__N.CGlwPr_SetGlowState;
			calli(System.Void(System.IntPtr,System.Int32), this.self, iType, cglwPr_SetGlowState);
		}

		// Token: 0x06000670 RID: 1648 RVA: 0x0002F7A8 File Offset: 0x0002D9A8
		internal readonly void SetGlowRange(int nRange)
		{
			this.NullCheck("SetGlowRange");
			method cglwPr_SetGlowRange = CGlowProperty.__N.CGlwPr_SetGlowRange;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nRange, cglwPr_SetGlowRange);
		}

		// Token: 0x06000671 RID: 1649 RVA: 0x0002F7D4 File Offset: 0x0002D9D4
		internal readonly void SetGlowRangeMin(int nRangeMin)
		{
			this.NullCheck("SetGlowRangeMin");
			method cglwPr_SetGlowRangeMin = CGlowProperty.__N.CGlwPr_SetGlowRangeMin;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nRangeMin, cglwPr_SetGlowRangeMin);
		}

		// Token: 0x06000672 RID: 1650 RVA: 0x0002F800 File Offset: 0x0002DA00
		internal readonly void SetGlowTeam(int iTeam)
		{
			this.NullCheck("SetGlowTeam");
			method cglwPr_SetGlowTeam = CGlowProperty.__N.CGlwPr_SetGlowTeam;
			calli(System.Void(System.IntPtr,System.Int32), this.self, iTeam, cglwPr_SetGlowTeam);
		}

		// Token: 0x06000673 RID: 1651 RVA: 0x0002F82C File Offset: 0x0002DA2C
		internal unsafe readonly void SetGlowColorOverride(Vector3 color)
		{
			this.NullCheck("SetGlowColorOverride");
			method cglwPr_SetGlowColorOverride = CGlowProperty.__N.CGlwPr_SetGlowColorOverride;
			calli(System.Void(System.IntPtr,Vector3*), this.self, &color, cglwPr_SetGlowColorOverride);
		}

		// Token: 0x06000674 RID: 1652 RVA: 0x0002F85C File Offset: 0x0002DA5C
		internal readonly int GetGlowState()
		{
			this.NullCheck("GetGlowState");
			method cglwPr_GetGlowState = CGlowProperty.__N.CGlwPr_GetGlowState;
			return calli(System.Int32(System.IntPtr), this.self, cglwPr_GetGlowState);
		}

		// Token: 0x06000675 RID: 1653 RVA: 0x0002F888 File Offset: 0x0002DA88
		internal readonly int GetGlowRange()
		{
			this.NullCheck("GetGlowRange");
			method cglwPr_GetGlowRange = CGlowProperty.__N.CGlwPr_GetGlowRange;
			return calli(System.Int32(System.IntPtr), this.self, cglwPr_GetGlowRange);
		}

		// Token: 0x06000676 RID: 1654 RVA: 0x0002F8B4 File Offset: 0x0002DAB4
		internal readonly int GetGlowRangeMin()
		{
			this.NullCheck("GetGlowRangeMin");
			method cglwPr_GetGlowRangeMin = CGlowProperty.__N.CGlwPr_GetGlowRangeMin;
			return calli(System.Int32(System.IntPtr), this.self, cglwPr_GetGlowRangeMin);
		}

		// Token: 0x06000677 RID: 1655 RVA: 0x0002F8E0 File Offset: 0x0002DAE0
		internal readonly int GetGlowTeam()
		{
			this.NullCheck("GetGlowTeam");
			method cglwPr_GetGlowTeam = CGlowProperty.__N.CGlwPr_GetGlowTeam;
			return calli(System.Int32(System.IntPtr), this.self, cglwPr_GetGlowTeam);
		}

		// Token: 0x06000678 RID: 1656 RVA: 0x0002F90C File Offset: 0x0002DB0C
		internal readonly Vector3 GetGlowColorOverride()
		{
			this.NullCheck("GetGlowColorOverride");
			method cglwPr_GetGlowColorOverride = CGlowProperty.__N.CGlwPr_GetGlowColorOverride;
			return calli(Vector3(System.IntPtr), this.self, cglwPr_GetGlowColorOverride);
		}

		// Token: 0x06000679 RID: 1657 RVA: 0x0002F938 File Offset: 0x0002DB38
		internal readonly void StartGlowing()
		{
			this.NullCheck("StartGlowing");
			method cglwPr_StartGlowing = CGlowProperty.__N.CGlwPr_StartGlowing;
			calli(System.Void(System.IntPtr), this.self, cglwPr_StartGlowing);
		}

		// Token: 0x0600067A RID: 1658 RVA: 0x0002F964 File Offset: 0x0002DB64
		internal readonly void StopGlowing()
		{
			this.NullCheck("StopGlowing");
			method cglwPr_StopGlowing = CGlowProperty.__N.CGlwPr_StopGlowing;
			calli(System.Void(System.IntPtr), this.self, cglwPr_StopGlowing);
		}

		// Token: 0x0600067B RID: 1659 RVA: 0x0002F990 File Offset: 0x0002DB90
		internal readonly void MarkOwnerDirty()
		{
			this.NullCheck("MarkOwnerDirty");
			method cglwPr_MarkOwnerDirty = CGlowProperty.__N.CGlwPr_MarkOwnerDirty;
			calli(System.Void(System.IntPtr), this.self, cglwPr_MarkOwnerDirty);
		}

		// Token: 0x0600067C RID: 1660 RVA: 0x0002F9BC File Offset: 0x0002DBBC
		internal readonly bool IsGlowing()
		{
			this.NullCheck("IsGlowing");
			method cglwPr_IsGlowing = CGlowProperty.__N.CGlwPr_IsGlowing;
			return calli(System.Int32(System.IntPtr), this.self, cglwPr_IsGlowing) > 0;
		}

		// Token: 0x0600067D RID: 1661 RVA: 0x0002F9EC File Offset: 0x0002DBEC
		internal readonly void SetFlashing(bool bFlash)
		{
			this.NullCheck("SetFlashing");
			method cglwPr_SetFlashing = CGlowProperty.__N.CGlwPr_SetFlashing;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bFlash ? 1 : 0, cglwPr_SetFlashing);
		}

		// Token: 0x0600067E RID: 1662 RVA: 0x0002FA20 File Offset: 0x0002DC20
		internal readonly bool IsFlashing()
		{
			this.NullCheck("IsFlashing");
			method cglwPr_IsFlashing = CGlowProperty.__N.CGlwPr_IsFlashing;
			return calli(System.Int32(System.IntPtr), this.self, cglwPr_IsFlashing) > 0;
		}

		// Token: 0x0600067F RID: 1663 RVA: 0x0002FA50 File Offset: 0x0002DC50
		internal readonly IMaterial GetGlowMaterialOverride()
		{
			this.NullCheck("GetGlowMaterialOverride");
			method cglwPr_GetGlowMaterialOverride = CGlowProperty.__N.CGlwPr_GetGlowMaterialOverride;
			return calli(System.IntPtr(System.IntPtr), this.self, cglwPr_GetGlowMaterialOverride);
		}

		// Token: 0x06000680 RID: 1664 RVA: 0x0002FA80 File Offset: 0x0002DC80
		internal readonly void SetGlowMaterialOverride(IMaterial material)
		{
			this.NullCheck("SetGlowMaterialOverride");
			method cglwPr_SetGlowMaterialOverride = CGlowProperty.__N.CGlwPr_SetGlowMaterialOverride;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, material, cglwPr_SetGlowMaterialOverride);
		}

		// Token: 0x040000A9 RID: 169
		internal IntPtr self;

		// Token: 0x020001B2 RID: 434
		internal static class __N
		{
			// Token: 0x04000C4A RID: 3146
			internal static method CGlwPr_SetGlowState;

			// Token: 0x04000C4B RID: 3147
			internal static method CGlwPr_SetGlowRange;

			// Token: 0x04000C4C RID: 3148
			internal static method CGlwPr_SetGlowRangeMin;

			// Token: 0x04000C4D RID: 3149
			internal static method CGlwPr_SetGlowTeam;

			// Token: 0x04000C4E RID: 3150
			internal static method CGlwPr_SetGlowColorOverride;

			// Token: 0x04000C4F RID: 3151
			internal static method CGlwPr_GetGlowState;

			// Token: 0x04000C50 RID: 3152
			internal static method CGlwPr_GetGlowRange;

			// Token: 0x04000C51 RID: 3153
			internal static method CGlwPr_GetGlowRangeMin;

			// Token: 0x04000C52 RID: 3154
			internal static method CGlwPr_GetGlowTeam;

			// Token: 0x04000C53 RID: 3155
			internal static method CGlwPr_GetGlowColorOverride;

			// Token: 0x04000C54 RID: 3156
			internal static method CGlwPr_StartGlowing;

			// Token: 0x04000C55 RID: 3157
			internal static method CGlwPr_StopGlowing;

			// Token: 0x04000C56 RID: 3158
			internal static method CGlwPr_MarkOwnerDirty;

			// Token: 0x04000C57 RID: 3159
			internal static method CGlwPr_IsGlowing;

			// Token: 0x04000C58 RID: 3160
			internal static method CGlwPr_SetFlashing;

			// Token: 0x04000C59 RID: 3161
			internal static method CGlwPr_IsFlashing;

			// Token: 0x04000C5A RID: 3162
			internal static method CGlwPr_GetGlowMaterialOverride;

			// Token: 0x04000C5B RID: 3163
			internal static method CGlwPr_SetGlowMaterialOverride;
		}
	}
}
