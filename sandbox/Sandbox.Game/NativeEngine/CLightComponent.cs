using System;
using System.Runtime.CompilerServices;

namespace NativeEngine
{
	// Token: 0x0200002E RID: 46
	internal struct CLightComponent
	{
		// Token: 0x06000681 RID: 1665 RVA: 0x0002FAB0 File Offset: 0x0002DCB0
		public static implicit operator IntPtr(CLightComponent value)
		{
			return value.self;
		}

		// Token: 0x06000682 RID: 1666 RVA: 0x0002FAB8 File Offset: 0x0002DCB8
		public static implicit operator CLightComponent(IntPtr value)
		{
			return new CLightComponent
			{
				self = value
			};
		}

		// Token: 0x06000683 RID: 1667 RVA: 0x0002FAD6 File Offset: 0x0002DCD6
		public static bool operator ==(CLightComponent c1, CLightComponent c2)
		{
			return c1.self == c2.self;
		}

		// Token: 0x06000684 RID: 1668 RVA: 0x0002FAE9 File Offset: 0x0002DCE9
		public static bool operator !=(CLightComponent c1, CLightComponent c2)
		{
			return c1.self != c2.self;
		}

		// Token: 0x06000685 RID: 1669 RVA: 0x0002FAFC File Offset: 0x0002DCFC
		public override bool Equals(object obj)
		{
			if (obj is CLightComponent)
			{
				CLightComponent c = (CLightComponent)obj;
				return c == this;
			}
			return false;
		}

		// Token: 0x06000686 RID: 1670 RVA: 0x0002FB26 File Offset: 0x0002DD26
		internal CLightComponent(IntPtr ptr)
		{
			this.self = ptr;
		}

		// Token: 0x06000687 RID: 1671 RVA: 0x0002FB30 File Offset: 0x0002DD30
		public override string ToString()
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(16, 1);
			defaultInterpolatedStringHandler.AppendLiteral("CLightComponent ");
			defaultInterpolatedStringHandler.AppendFormatted<IntPtr>(this.self, "x");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x06000688 RID: 1672 RVA: 0x0002FB6C File Offset: 0x0002DD6C
		internal readonly bool IsNull
		{
			get
			{
				return this.self == IntPtr.Zero;
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x06000689 RID: 1673 RVA: 0x0002FB7E File Offset: 0x0002DD7E
		internal readonly bool IsValid
		{
			get
			{
				return !this.IsNull;
			}
		}

		// Token: 0x0600068A RID: 1674 RVA: 0x0002FB89 File Offset: 0x0002DD89
		internal readonly IntPtr GetPointerAssertIfNull()
		{
			this.NullCheck("GetPointerAssertIfNull");
			return this.self;
		}

		// Token: 0x0600068B RID: 1675 RVA: 0x0002FB9C File Offset: 0x0002DD9C
		internal readonly void NullCheck([CallerMemberName] string n = "")
		{
			if (this.IsNull)
			{
				throw new NullReferenceException("CLightComponent was null when calling " + n);
			}
		}

		// Token: 0x0600068C RID: 1676 RVA: 0x0002FBB7 File Offset: 0x0002DDB7
		public override int GetHashCode()
		{
			return this.self.GetHashCode();
		}

		// Token: 0x0600068D RID: 1677 RVA: 0x0002FBC4 File Offset: 0x0002DDC4
		internal readonly void SetEnabled(bool b)
		{
			this.NullCheck("SetEnabled");
			method clghtC_SetEnabled = CLightComponent.__N.CLghtC_SetEnabled;
			calli(System.Void(System.IntPtr,System.Int32), this.self, b ? 1 : 0, clghtC_SetEnabled);
		}

		// Token: 0x0600068E RID: 1678 RVA: 0x0002FBF8 File Offset: 0x0002DDF8
		internal readonly bool IsEnabled()
		{
			this.NullCheck("IsEnabled");
			method clghtC_IsEnabled = CLightComponent.__N.CLghtC_IsEnabled;
			return calli(System.Int32(System.IntPtr), this.self, clghtC_IsEnabled) > 0;
		}

		// Token: 0x0600068F RID: 1679 RVA: 0x0002FC28 File Offset: 0x0002DE28
		internal readonly void SetColor(Color32 c)
		{
			this.NullCheck("SetColor");
			method clghtC_SetColor = CLightComponent.__N.CLghtC_SetColor;
			calli(System.Void(System.IntPtr,Color32), this.self, c, clghtC_SetColor);
		}

		// Token: 0x06000690 RID: 1680 RVA: 0x0002FC54 File Offset: 0x0002DE54
		internal readonly uint GetColor()
		{
			this.NullCheck("GetColor");
			method clghtC_GetColor = CLightComponent.__N.CLghtC_GetColor;
			return calli(System.UInt32(System.IntPtr), this.self, clghtC_GetColor);
		}

		// Token: 0x06000691 RID: 1681 RVA: 0x0002FC80 File Offset: 0x0002DE80
		internal readonly void SetBrightness(float flBrightness)
		{
			this.NullCheck("SetBrightness");
			method clghtC_SetBrightness = CLightComponent.__N.CLghtC_SetBrightness;
			calli(System.Void(System.IntPtr,System.Single), this.self, flBrightness, clghtC_SetBrightness);
		}

		// Token: 0x06000692 RID: 1682 RVA: 0x0002FCAC File Offset: 0x0002DEAC
		internal readonly float GetBrightness()
		{
			this.NullCheck("GetBrightness");
			method clghtC_GetBrightness = CLightComponent.__N.CLghtC_GetBrightness;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetBrightness);
		}

		// Token: 0x06000693 RID: 1683 RVA: 0x0002FCD8 File Offset: 0x0002DED8
		internal readonly void SetBrightnessMultiplier(float flMult)
		{
			this.NullCheck("SetBrightnessMultiplier");
			method clghtC_SetBrightnessMultiplier = CLightComponent.__N.CLghtC_SetBrightnessMultiplier;
			calli(System.Void(System.IntPtr,System.Single), this.self, flMult, clghtC_SetBrightnessMultiplier);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0002FD04 File Offset: 0x0002DF04
		internal readonly float GetBrightnessMultiplier()
		{
			this.NullCheck("GetBrightnessMultiplier");
			method clghtC_GetBrightnessMultiplier = CLightComponent.__N.CLghtC_GetBrightnessMultiplier;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetBrightnessMultiplier);
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0002FD30 File Offset: 0x0002DF30
		internal readonly void SetFlicker(bool bFlicker)
		{
			this.NullCheck("SetFlicker");
			method clghtC_SetFlicker = CLightComponent.__N.CLghtC_SetFlicker;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bFlicker ? 1 : 0, clghtC_SetFlicker);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0002FD64 File Offset: 0x0002DF64
		internal readonly bool GetFlicker()
		{
			this.NullCheck("GetFlicker");
			method clghtC_GetFlicker = CLightComponent.__N.CLghtC_GetFlicker;
			return calli(System.Int32(System.IntPtr), this.self, clghtC_GetFlicker) > 0;
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0002FD94 File Offset: 0x0002DF94
		internal readonly void SetRange(float flRange)
		{
			this.NullCheck("SetRange");
			method clghtC_SetRange = CLightComponent.__N.CLghtC_SetRange;
			calli(System.Void(System.IntPtr,System.Single), this.self, flRange, clghtC_SetRange);
		}

		// Token: 0x06000698 RID: 1688 RVA: 0x0002FDC0 File Offset: 0x0002DFC0
		internal readonly float GetRange()
		{
			this.NullCheck("GetRange");
			method clghtC_GetRange = CLightComponent.__N.CLghtC_GetRange;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetRange);
		}

		// Token: 0x06000699 RID: 1689 RVA: 0x0002FDEC File Offset: 0x0002DFEC
		internal readonly void SetInnerConeAngle(float flTheta)
		{
			this.NullCheck("SetInnerConeAngle");
			method clghtC_SetInnerConeAngle = CLightComponent.__N.CLghtC_SetInnerConeAngle;
			calli(System.Void(System.IntPtr,System.Single), this.self, flTheta, clghtC_SetInnerConeAngle);
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0002FE18 File Offset: 0x0002E018
		internal readonly float GetInnerConeAngle()
		{
			this.NullCheck("GetInnerConeAngle");
			method clghtC_GetInnerConeAngle = CLightComponent.__N.CLghtC_GetInnerConeAngle;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetInnerConeAngle);
		}

		// Token: 0x0600069B RID: 1691 RVA: 0x0002FE44 File Offset: 0x0002E044
		internal readonly void SetOuterConeAngle(float flPhi)
		{
			this.NullCheck("SetOuterConeAngle");
			method clghtC_SetOuterConeAngle = CLightComponent.__N.CLghtC_SetOuterConeAngle;
			calli(System.Void(System.IntPtr,System.Single), this.self, flPhi, clghtC_SetOuterConeAngle);
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0002FE70 File Offset: 0x0002E070
		internal readonly float GetOuterConeAngle()
		{
			this.NullCheck("GetOuterConeAngle");
			method clghtC_GetOuterConeAngle = CLightComponent.__N.CLghtC_GetOuterConeAngle;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetOuterConeAngle);
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0002FE9C File Offset: 0x0002E09C
		internal readonly void SetFalloff(float flFalloff)
		{
			this.NullCheck("SetFalloff");
			method clghtC_SetFalloff = CLightComponent.__N.CLghtC_SetFalloff;
			calli(System.Void(System.IntPtr,System.Single), this.self, flFalloff, clghtC_SetFalloff);
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0002FEC8 File Offset: 0x0002E0C8
		internal readonly float GetFalloff()
		{
			this.NullCheck("GetFalloff");
			method clghtC_GetFalloff = CLightComponent.__N.CLghtC_GetFalloff;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetFalloff);
		}

		// Token: 0x0600069F RID: 1695 RVA: 0x0002FEF4 File Offset: 0x0002E0F4
		internal readonly void SetAttenuation0(float flAttenuation0)
		{
			this.NullCheck("SetAttenuation0");
			method clghtC_SetAttenuation = CLightComponent.__N.CLghtC_SetAttenuation0;
			calli(System.Void(System.IntPtr,System.Single), this.self, flAttenuation0, clghtC_SetAttenuation);
		}

		// Token: 0x060006A0 RID: 1696 RVA: 0x0002FF20 File Offset: 0x0002E120
		internal readonly float GetAttenuation0()
		{
			this.NullCheck("GetAttenuation0");
			method clghtC_GetAttenuation = CLightComponent.__N.CLghtC_GetAttenuation0;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetAttenuation);
		}

		// Token: 0x060006A1 RID: 1697 RVA: 0x0002FF4C File Offset: 0x0002E14C
		internal readonly void SetAttenuation1(float flAttenuation1)
		{
			this.NullCheck("SetAttenuation1");
			method clghtC_SetAttenuation = CLightComponent.__N.CLghtC_SetAttenuation1;
			calli(System.Void(System.IntPtr,System.Single), this.self, flAttenuation1, clghtC_SetAttenuation);
		}

		// Token: 0x060006A2 RID: 1698 RVA: 0x0002FF78 File Offset: 0x0002E178
		internal readonly float GetAttenuation1()
		{
			this.NullCheck("GetAttenuation1");
			method clghtC_GetAttenuation = CLightComponent.__N.CLghtC_GetAttenuation1;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetAttenuation);
		}

		// Token: 0x060006A3 RID: 1699 RVA: 0x0002FFA4 File Offset: 0x0002E1A4
		internal readonly void SetAttenuation2(float flAttenuation2)
		{
			this.NullCheck("SetAttenuation2");
			method clghtC_SetAttenuation = CLightComponent.__N.CLghtC_SetAttenuation2;
			calli(System.Void(System.IntPtr,System.Single), this.self, flAttenuation2, clghtC_SetAttenuation);
		}

		// Token: 0x060006A4 RID: 1700 RVA: 0x0002FFD0 File Offset: 0x0002E1D0
		internal readonly float GetAttenuation2()
		{
			this.NullCheck("GetAttenuation2");
			method clghtC_GetAttenuation = CLightComponent.__N.CLghtC_GetAttenuation2;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetAttenuation);
		}

		// Token: 0x060006A5 RID: 1701 RVA: 0x0002FFFC File Offset: 0x0002E1FC
		internal readonly void SetFogLightingMode(int nFogLightingMode)
		{
			this.NullCheck("SetFogLightingMode");
			method clghtC_SetFogLightingMode = CLightComponent.__N.CLghtC_SetFogLightingMode;
			calli(System.Void(System.IntPtr,System.Int32), this.self, nFogLightingMode, clghtC_SetFogLightingMode);
		}

		// Token: 0x060006A6 RID: 1702 RVA: 0x00030028 File Offset: 0x0002E228
		internal readonly int GetFogLightingMode()
		{
			this.NullCheck("GetFogLightingMode");
			method clghtC_GetFogLightingMode = CLightComponent.__N.CLghtC_GetFogLightingMode;
			return calli(System.Int32(System.IntPtr), this.self, clghtC_GetFogLightingMode);
		}

		// Token: 0x060006A7 RID: 1703 RVA: 0x00030054 File Offset: 0x0002E254
		internal readonly void SetFadeMinDistance(float flFadeMinDist)
		{
			this.NullCheck("SetFadeMinDistance");
			method clghtC_SetFadeMinDistance = CLightComponent.__N.CLghtC_SetFadeMinDistance;
			calli(System.Void(System.IntPtr,System.Single), this.self, flFadeMinDist, clghtC_SetFadeMinDistance);
		}

		// Token: 0x060006A8 RID: 1704 RVA: 0x00030080 File Offset: 0x0002E280
		internal readonly float GetFadeMinDistance()
		{
			this.NullCheck("GetFadeMinDistance");
			method clghtC_GetFadeMinDistance = CLightComponent.__N.CLghtC_GetFadeMinDistance;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetFadeMinDistance);
		}

		// Token: 0x060006A9 RID: 1705 RVA: 0x000300AC File Offset: 0x0002E2AC
		internal readonly void SetFadeMaxDistance(float flFadeMaxDist)
		{
			this.NullCheck("SetFadeMaxDistance");
			method clghtC_SetFadeMaxDistance = CLightComponent.__N.CLghtC_SetFadeMaxDistance;
			calli(System.Void(System.IntPtr,System.Single), this.self, flFadeMaxDist, clghtC_SetFadeMaxDistance);
		}

		// Token: 0x060006AA RID: 1706 RVA: 0x000300D8 File Offset: 0x0002E2D8
		internal readonly float GetFadeMaxDistance()
		{
			this.NullCheck("GetFadeMaxDistance");
			method clghtC_GetFadeMaxDistance = CLightComponent.__N.CLghtC_GetFadeMaxDistance;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetFadeMaxDistance);
		}

		// Token: 0x060006AB RID: 1707 RVA: 0x00030104 File Offset: 0x0002E304
		internal readonly void SetShadowFadeMinDistance(float flShadowFadeMinDist)
		{
			this.NullCheck("SetShadowFadeMinDistance");
			method clghtC_SetShadowFadeMinDistance = CLightComponent.__N.CLghtC_SetShadowFadeMinDistance;
			calli(System.Void(System.IntPtr,System.Single), this.self, flShadowFadeMinDist, clghtC_SetShadowFadeMinDistance);
		}

		// Token: 0x060006AC RID: 1708 RVA: 0x00030130 File Offset: 0x0002E330
		internal readonly float GetShadowFadeMinDistance()
		{
			this.NullCheck("GetShadowFadeMinDistance");
			method clghtC_GetShadowFadeMinDistance = CLightComponent.__N.CLghtC_GetShadowFadeMinDistance;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetShadowFadeMinDistance);
		}

		// Token: 0x060006AD RID: 1709 RVA: 0x0003015C File Offset: 0x0002E35C
		internal readonly void SetShadowFadeMaxDistance(float flShadowFadeMaxDist)
		{
			this.NullCheck("SetShadowFadeMaxDistance");
			method clghtC_SetShadowFadeMaxDistance = CLightComponent.__N.CLghtC_SetShadowFadeMaxDistance;
			calli(System.Void(System.IntPtr,System.Single), this.self, flShadowFadeMaxDist, clghtC_SetShadowFadeMaxDistance);
		}

		// Token: 0x060006AE RID: 1710 RVA: 0x00030188 File Offset: 0x0002E388
		internal readonly float GetShadowFadeMaxDistance()
		{
			this.NullCheck("GetShadowFadeMaxDistance");
			method clghtC_GetShadowFadeMaxDistance = CLightComponent.__N.CLghtC_GetShadowFadeMaxDistance;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetShadowFadeMaxDistance);
		}

		// Token: 0x060006AF RID: 1711 RVA: 0x000301B4 File Offset: 0x0002E3B4
		internal readonly void SetFogContributionStength(float flFogContributionStength)
		{
			this.NullCheck("SetFogContributionStength");
			method clghtC_SetFogContributionStength = CLightComponent.__N.CLghtC_SetFogContributionStength;
			calli(System.Void(System.IntPtr,System.Single), this.self, flFogContributionStength, clghtC_SetFogContributionStength);
		}

		// Token: 0x060006B0 RID: 1712 RVA: 0x000301E0 File Offset: 0x0002E3E0
		internal readonly float GetFogContributionStength()
		{
			this.NullCheck("GetFogContributionStength");
			method clghtC_GetFogContributionStength = CLightComponent.__N.CLghtC_GetFogContributionStength;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetFogContributionStength);
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x0003020C File Offset: 0x0002E40C
		internal readonly void SetDynamicShadows(bool bCastShadows)
		{
			this.NullCheck("SetDynamicShadows");
			method clghtC_SetDynamicShadows = CLightComponent.__N.CLghtC_SetDynamicShadows;
			calli(System.Void(System.IntPtr,System.Int32), this.self, bCastShadows ? 1 : 0, clghtC_SetDynamicShadows);
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00030240 File Offset: 0x0002E440
		internal readonly bool DynamicShadows()
		{
			this.NullCheck("DynamicShadows");
			method clghtC_DynamicShadows = CLightComponent.__N.CLghtC_DynamicShadows;
			return calli(System.Int32(System.IntPtr), this.self, clghtC_DynamicShadows) > 0;
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00030270 File Offset: 0x0002E470
		internal readonly void SetOrthoLightWidth(float flOrthoLightWidth)
		{
			this.NullCheck("SetOrthoLightWidth");
			method clghtC_SetOrthoLightWidth = CLightComponent.__N.CLghtC_SetOrthoLightWidth;
			calli(System.Void(System.IntPtr,System.Single), this.self, flOrthoLightWidth, clghtC_SetOrthoLightWidth);
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x0003029C File Offset: 0x0002E49C
		internal readonly float GetOrthoLightWidth()
		{
			this.NullCheck("GetOrthoLightWidth");
			method clghtC_GetOrthoLightWidth = CLightComponent.__N.CLghtC_GetOrthoLightWidth;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetOrthoLightWidth);
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x000302C8 File Offset: 0x0002E4C8
		internal readonly void SetOrthoLightHeight(float flOrthoLightHeight)
		{
			this.NullCheck("SetOrthoLightHeight");
			method clghtC_SetOrthoLightHeight = CLightComponent.__N.CLghtC_SetOrthoLightHeight;
			calli(System.Void(System.IntPtr,System.Single), this.self, flOrthoLightHeight, clghtC_SetOrthoLightHeight);
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x000302F4 File Offset: 0x0002E4F4
		internal readonly float GetOrthoLightHeight()
		{
			this.NullCheck("GetOrthoLightHeight");
			method clghtC_GetOrthoLightHeight = CLightComponent.__N.CLghtC_GetOrthoLightHeight;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetOrthoLightHeight);
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00030320 File Offset: 0x0002E520
		internal readonly void SetSkyColor(Color32 skyColor)
		{
			this.NullCheck("SetSkyColor");
			method clghtC_SetSkyColor = CLightComponent.__N.CLghtC_SetSkyColor;
			calli(System.Void(System.IntPtr,Color32), this.self, skyColor, clghtC_SetSkyColor);
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x0003034C File Offset: 0x0002E54C
		internal readonly uint GetSkyColor()
		{
			this.NullCheck("GetSkyColor");
			method clghtC_GetSkyColor = CLightComponent.__N.CLghtC_GetSkyColor;
			return calli(System.UInt32(System.IntPtr), this.self, clghtC_GetSkyColor);
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x00030378 File Offset: 0x0002E578
		internal readonly void SetSkyIntensity(float flSkyIntensity)
		{
			this.NullCheck("SetSkyIntensity");
			method clghtC_SetSkyIntensity = CLightComponent.__N.CLghtC_SetSkyIntensity;
			calli(System.Void(System.IntPtr,System.Single), this.self, flSkyIntensity, clghtC_SetSkyIntensity);
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x000303A4 File Offset: 0x0002E5A4
		internal readonly float GetSkyIntensity()
		{
			this.NullCheck("GetSkyIntensity");
			method clghtC_GetSkyIntensity = CLightComponent.__N.CLghtC_GetSkyIntensity;
			return calli(System.Single(System.IntPtr), this.self, clghtC_GetSkyIntensity);
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x000303D0 File Offset: 0x0002E5D0
		internal readonly void SetLightCookie(ITexture pszCookie)
		{
			this.NullCheck("SetLightCookie");
			method clghtC_SetLightCookie = CLightComponent.__N.CLghtC_SetLightCookie;
			calli(System.Void(System.IntPtr,System.IntPtr), this.self, pszCookie, clghtC_SetLightCookie);
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00030400 File Offset: 0x0002E600
		internal readonly ITexture GetLightCookie()
		{
			this.NullCheck("GetLightCookie");
			method clghtC_GetLightCookie = CLightComponent.__N.CLghtC_GetLightCookie;
			return calli(System.IntPtr(System.IntPtr), this.self, clghtC_GetLightCookie);
		}

		// Token: 0x040000AA RID: 170
		internal IntPtr self;

		// Token: 0x020001B3 RID: 435
		internal static class __N
		{
			// Token: 0x04000C5C RID: 3164
			internal static method CLghtC_SetEnabled;

			// Token: 0x04000C5D RID: 3165
			internal static method CLghtC_IsEnabled;

			// Token: 0x04000C5E RID: 3166
			internal static method CLghtC_SetColor;

			// Token: 0x04000C5F RID: 3167
			internal static method CLghtC_GetColor;

			// Token: 0x04000C60 RID: 3168
			internal static method CLghtC_SetBrightness;

			// Token: 0x04000C61 RID: 3169
			internal static method CLghtC_GetBrightness;

			// Token: 0x04000C62 RID: 3170
			internal static method CLghtC_SetBrightnessMultiplier;

			// Token: 0x04000C63 RID: 3171
			internal static method CLghtC_GetBrightnessMultiplier;

			// Token: 0x04000C64 RID: 3172
			internal static method CLghtC_SetFlicker;

			// Token: 0x04000C65 RID: 3173
			internal static method CLghtC_GetFlicker;

			// Token: 0x04000C66 RID: 3174
			internal static method CLghtC_SetRange;

			// Token: 0x04000C67 RID: 3175
			internal static method CLghtC_GetRange;

			// Token: 0x04000C68 RID: 3176
			internal static method CLghtC_SetInnerConeAngle;

			// Token: 0x04000C69 RID: 3177
			internal static method CLghtC_GetInnerConeAngle;

			// Token: 0x04000C6A RID: 3178
			internal static method CLghtC_SetOuterConeAngle;

			// Token: 0x04000C6B RID: 3179
			internal static method CLghtC_GetOuterConeAngle;

			// Token: 0x04000C6C RID: 3180
			internal static method CLghtC_SetFalloff;

			// Token: 0x04000C6D RID: 3181
			internal static method CLghtC_GetFalloff;

			// Token: 0x04000C6E RID: 3182
			internal static method CLghtC_SetAttenuation0;

			// Token: 0x04000C6F RID: 3183
			internal static method CLghtC_GetAttenuation0;

			// Token: 0x04000C70 RID: 3184
			internal static method CLghtC_SetAttenuation1;

			// Token: 0x04000C71 RID: 3185
			internal static method CLghtC_GetAttenuation1;

			// Token: 0x04000C72 RID: 3186
			internal static method CLghtC_SetAttenuation2;

			// Token: 0x04000C73 RID: 3187
			internal static method CLghtC_GetAttenuation2;

			// Token: 0x04000C74 RID: 3188
			internal static method CLghtC_SetFogLightingMode;

			// Token: 0x04000C75 RID: 3189
			internal static method CLghtC_GetFogLightingMode;

			// Token: 0x04000C76 RID: 3190
			internal static method CLghtC_SetFadeMinDistance;

			// Token: 0x04000C77 RID: 3191
			internal static method CLghtC_GetFadeMinDistance;

			// Token: 0x04000C78 RID: 3192
			internal static method CLghtC_SetFadeMaxDistance;

			// Token: 0x04000C79 RID: 3193
			internal static method CLghtC_GetFadeMaxDistance;

			// Token: 0x04000C7A RID: 3194
			internal static method CLghtC_SetShadowFadeMinDistance;

			// Token: 0x04000C7B RID: 3195
			internal static method CLghtC_GetShadowFadeMinDistance;

			// Token: 0x04000C7C RID: 3196
			internal static method CLghtC_SetShadowFadeMaxDistance;

			// Token: 0x04000C7D RID: 3197
			internal static method CLghtC_GetShadowFadeMaxDistance;

			// Token: 0x04000C7E RID: 3198
			internal static method CLghtC_SetFogContributionStength;

			// Token: 0x04000C7F RID: 3199
			internal static method CLghtC_GetFogContributionStength;

			// Token: 0x04000C80 RID: 3200
			internal static method CLghtC_SetDynamicShadows;

			// Token: 0x04000C81 RID: 3201
			internal static method CLghtC_DynamicShadows;

			// Token: 0x04000C82 RID: 3202
			internal static method CLghtC_SetOrthoLightWidth;

			// Token: 0x04000C83 RID: 3203
			internal static method CLghtC_GetOrthoLightWidth;

			// Token: 0x04000C84 RID: 3204
			internal static method CLghtC_SetOrthoLightHeight;

			// Token: 0x04000C85 RID: 3205
			internal static method CLghtC_GetOrthoLightHeight;

			// Token: 0x04000C86 RID: 3206
			internal static method CLghtC_SetSkyColor;

			// Token: 0x04000C87 RID: 3207
			internal static method CLghtC_GetSkyColor;

			// Token: 0x04000C88 RID: 3208
			internal static method CLghtC_SetSkyIntensity;

			// Token: 0x04000C89 RID: 3209
			internal static method CLghtC_GetSkyIntensity;

			// Token: 0x04000C8A RID: 3210
			internal static method CLghtC_SetLightCookie;

			// Token: 0x04000C8B RID: 3211
			internal static method CLghtC_GetLightCookie;
		}
	}
}
