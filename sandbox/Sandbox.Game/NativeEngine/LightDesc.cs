using System;
using Sandbox;

namespace NativeEngine
{
	// Token: 0x0200005C RID: 92
	internal struct LightDesc
	{
		// Token: 0x06000BB5 RID: 2997 RVA: 0x0003CA48 File Offset: 0x0003AC48
		internal void Clear()
		{
			this.m_Type = LightType.LightDirectional;
			this.m_Color = Vector3.Zero;
			this.m_BounceColor = Vector3.Zero;
			this.m_Range = 0f;
			this.m_Falloff = 0f;
			this.m_Attenuation0 = 0f;
			this.m_Attenuation1 = 0f;
			this.m_Attenuation2 = 0f;
			this.m_Theta = 0f;
			this.m_Phi = 0f;
			this.m_lightCookie = default(ITexture);
			this.m_nLightGroupCount = 0;
			this.m_lightGroups = 0U;
			this.m_bCastShadows = true;
			this.m_nShadowWidth = 0;
			this.m_nShadowHeight = 0;
			this.m_nShadowCascadeCount = 1;
			this.m_flShadowCascadeDistance0 = 0f;
			this.m_flShadowCascadeDistance1 = 0f;
			this.m_flShadowCascadeDistance2 = 0f;
			this.m_flShadowCascadeDistance3 = 0f;
			this.m_nShadowCascadeResolution0 = 0;
			this.m_nShadowCascadeResolution1 = 0;
			this.m_nShadowCascadeResolution2 = 0;
			this.m_nShadowCascadeResolution3 = 0;
			this.m_nBakeLightIndex = -1;
			this.m_flBakeLightIndexScale = 1f;
			this.m_bUsesIndexedBakedLighting = true;
			this.m_bRenderDiffuse = true;
			this.m_bRenderSpecular = true;
			this.m_bRenderTransmissive = true;
			this.m_nPriority = 0;
			this.m_Shape = LightSourceShape_t.LIGHT_SOURCE_SHAPE_SPHERE;
			this.m_flLightSourceDim0 = 0f;
			this.m_flLightSourceDim1 = 0f;
			this.m_flLightSourceSize0 = 0f;
			this.m_flLightSourceSize1 = 0f;
			this.m_flPrecomputedMaxRange = 0f;
			this.m_flFogContributionStength = 1f;
			this.m_flNearClipPlane = 1f;
			this.m_nFogLightingMode = 0;
			this.m_Position = Vector3.Zero;
			this.m_Direction = Vector3.Zero;
			this.m_ThetaDot = 0f;
			this.m_PhiDot = 0f;
			this.m_TanPhi = 0f;
			this.m_OneOverThetaDotMinusPhiDot = 0f;
			this.m_Truncation = 0f;
			this.m_vecUp = Vector3.Zero;
			this.m_Flags = (OptimizationFlags)0;
			this.m_nEnvProbeId = 0;
			this.m_vMinBounds = Vector3.Zero;
			this.m_vMaxBounds = Vector3.Zero;
		}

		// Token: 0x06000BB6 RID: 2998 RVA: 0x0003CC49 File Offset: 0x0003AE49
		internal double DegToRad(double angle)
		{
			return 0.017453292519943295 * angle;
		}

		// Token: 0x06000BB7 RID: 2999 RVA: 0x0003CC58 File Offset: 0x0003AE58
		internal void VectorVectorsFLU(Vector3 vForward, out Vector3 vLeft, out Vector3 vUp)
		{
			vLeft = default(Vector3);
			vUp = default(Vector3);
			if ((double)Math.Abs(vForward.x) < 0.001 && (double)Math.Abs(vForward.y) < 0.001)
			{
				vLeft = new Vector3(0f, 1f, 0f);
				vUp = new Vector3(-vForward.z, 0f, 0f);
				return;
			}
			Vector3 vFakeUp = new Vector3(0f, 0f, 1f);
			vLeft = Vector3.Cross(vFakeUp, vForward).Normal;
			vUp = Vector3.Cross(vForward, vLeft).Normal;
		}

		// Token: 0x06000BB8 RID: 3000 RVA: 0x0003CD20 File Offset: 0x0003AF20
		internal bool SolveQuadratic(float a, float b, float c, out float root1, out float root2)
		{
			root1 = 0f;
			root2 = 0f;
			if (a == 0f)
			{
				if (b != 0f)
				{
					root1 = (root2 = -c / b);
					return true;
				}
				if (c == 0f)
				{
					root1 = (root2 = 0f);
					return true;
				}
				return false;
			}
			else
			{
				float tmp = b * b - 4f * a * c;
				if (tmp < 0f)
				{
					return false;
				}
				tmp = (float)Math.Sqrt((double)tmp);
				root1 = (-b + tmp) / (2f * a);
				root2 = (-b - tmp) / (2f * a);
				return true;
			}
		}

		// Token: 0x06000BB9 RID: 3001 RVA: 0x0003CDB8 File Offset: 0x0003AFB8
		internal float DistanceAtWhichBrightnessIsLessThan(float flAmount)
		{
			float flBrightness = 0.2126f * this.m_Color.x + 0.7152f * this.m_Color.y + 0.0722f * this.m_Color.z;
			if ((double)flBrightness > 0.0)
			{
				flAmount /= flBrightness;
				float a = flAmount * this.m_Attenuation2;
				float b = flAmount * this.m_Attenuation1;
				float c = flAmount * this.m_Attenuation0 - 1f;
				float r0;
				float r;
				if (this.SolveQuadratic(a, b, c, out r0, out r))
				{
					return Math.Max(0f, Math.Max(r0, r));
				}
			}
			return 0f;
		}

		// Token: 0x06000BBA RID: 3002 RVA: 0x0003CE58 File Offset: 0x0003B058
		public void RecalculateDerivedValues(float truncationErrorTolerance = 0.001f)
		{
			this.m_Flags &= ~(OptimizationFlags.HasAttenuation0 | OptimizationFlags.HasAttenuation1 | OptimizationFlags.HasAttenuation2);
			this.m_Flags |= OptimizationFlags.DerivedValuesCalced;
			if (this.m_Attenuation0 > 0f)
			{
				this.m_Flags |= OptimizationFlags.HasAttenuation0;
			}
			if (this.m_Attenuation1 > 0f)
			{
				this.m_Flags |= OptimizationFlags.HasAttenuation1;
			}
			if (this.m_Attenuation2 > 0f)
			{
				this.m_Flags |= OptimizationFlags.HasAttenuation2;
			}
			if (this.m_Type == LightType.LightSpot)
			{
				this.m_ThetaDot = (float)Math.Cos(this.DegToRad((double)this.m_Theta));
				this.m_PhiDot = (float)Math.Cos(this.DegToRad((double)this.m_Phi));
				this.m_TanPhi = (float)Math.Tan(Math.Min(1.5706963539123535, this.DegToRad((double)this.m_Phi)));
				float flSpread = this.m_ThetaDot - this.m_PhiDot;
				if (flSpread > 1E-10f)
				{
					this.m_OneOverThetaDotMinusPhiDot = 1f / flSpread;
				}
				else
				{
					this.m_OneOverThetaDotMinusPhiDot = 1f;
				}
			}
			else
			{
				this.m_ThetaDot = 1f;
				this.m_PhiDot = 1f;
				this.m_TanPhi = 1f;
			}
			if (this.m_Type == LightType.LightDirectional)
			{
				this.m_Position = this.m_Direction;
				this.m_Position *= 2000000f;
			}
			if ((this.m_Type == LightType.LightPoint || this.m_Type == LightType.LightSpot) && this.m_Attenuation0 == 0f && truncationErrorTolerance > 0f)
			{
				float flRange = this.DistanceAtWhichBrightnessIsLessThan(truncationErrorTolerance);
				this.m_Range = ((this.m_Range <= 0f) ? flRange : Math.Min(flRange, this.m_Range));
			}
			if (this.m_Attenuation0 > 0f || this.m_Range <= 0f)
			{
				this.m_Truncation = 0f;
			}
			else
			{
				this.m_Truncation = 1f / (0.0001f + this.m_Range * this.m_Attenuation1 + this.m_Range * this.m_Range * this.m_Attenuation2);
			}
			this.m_vMinBounds = new Vector3(float.MaxValue);
			this.m_vMaxBounds = new Vector3(float.MaxValue);
			switch (this.m_Type)
			{
			case LightType.LightPoint:
			{
				Vector3 vRadius = new Vector3(this.m_Range, this.m_Range, this.m_Range);
				this.m_vMinBounds = this.m_Position - vRadius;
				this.m_vMaxBounds = this.m_Position + vRadius;
				return;
			}
			case LightType.LightDirectional:
				this.m_vMinBounds = new Vector3(float.MinValue, float.MinValue, float.MinValue);
				this.m_vMaxBounds = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
				return;
			case LightType.LightSpot:
			{
				Vector3 vLeft = this.m_Direction;
				Vector3 vUp;
				this.VectorVectorsFLU(this.m_Direction, out vLeft, out vUp);
				float flSinPhi = (float)Math.Sin(this.DegToRad((double)this.m_Phi));
				float flCosPhi = (float)Math.Cos(this.DegToRad((double)this.m_Phi));
				float flExtentsAtMidPoint = this.m_Range * flSinPhi;
				Vector3[] pnts = new Vector3[8];
				Vector3 vMidPoint = this.m_Position + this.m_Direction * this.m_Range * flCosPhi;
				Vector3 vFarPoint = this.m_Position + this.m_Direction * this.m_Range;
				pnts[0] = vMidPoint - vLeft * flExtentsAtMidPoint - vUp * flExtentsAtMidPoint;
				pnts[1] = vMidPoint + vLeft * flExtentsAtMidPoint - vUp * flExtentsAtMidPoint;
				pnts[2] = vMidPoint - vLeft * flExtentsAtMidPoint + vUp * flExtentsAtMidPoint;
				pnts[3] = vMidPoint + vLeft * flExtentsAtMidPoint + vUp * flExtentsAtMidPoint;
				pnts[4] = vFarPoint - vLeft * flExtentsAtMidPoint - vUp * flExtentsAtMidPoint;
				pnts[5] = vFarPoint + vLeft * flExtentsAtMidPoint - vUp * flExtentsAtMidPoint;
				pnts[6] = vFarPoint - vLeft * flExtentsAtMidPoint + vUp * flExtentsAtMidPoint;
				pnts[7] = vFarPoint + vLeft * flExtentsAtMidPoint + vUp * flExtentsAtMidPoint;
				this.m_vMinBounds = this.m_Position;
				this.m_vMaxBounds = this.m_Position;
				if (this.m_Shape == LightSourceShape_t.LIGHT_SOURCE_SHAPE_SPHERE)
				{
					this.m_vMinBounds -= new Vector3(this.m_flLightSourceDim0, this.m_flLightSourceDim0, this.m_flLightSourceDim0);
					this.m_vMaxBounds += new Vector3(this.m_flLightSourceDim0, this.m_flLightSourceDim0, this.m_flLightSourceDim0);
					for (int i = 0; i < pnts.Length; i++)
					{
						this.m_vMinBounds = Vector3.Min(pnts[i], this.m_vMinBounds);
						this.m_vMaxBounds = Vector3.Max(pnts[i], this.m_vMaxBounds);
					}
					Vector3 vRadius2 = new Vector3(this.m_Range, this.m_Range, this.m_Range);
					this.m_vMinBounds = Vector3.Max(this.m_vMinBounds, this.m_Position - vRadius2);
					this.m_vMaxBounds = Vector3.Min(this.m_vMaxBounds, this.m_Position + vRadius2);
					return;
				}
				throw new Exception("Unhandled light shape!");
			}
			case LightType.LightOrtho:
			{
				Vector3 vTangent = Vector3.Cross(this.m_Direction, this.m_vecUp);
				float flHw = this.m_flLightSourceSize0 * 0.5f;
				float flHh = this.m_flLightSourceSize1 * 0.5f;
				Vector3[] vPoints = new Vector3[8];
				vPoints[0] = this.m_Position - flHw * vTangent - flHh * this.m_vecUp;
				vPoints[1] = this.m_Position + flHw * vTangent - flHh * this.m_vecUp;
				vPoints[2] = this.m_Position + flHw * vTangent + flHh * this.m_vecUp;
				vPoints[3] = this.m_Position - flHw * vTangent + flHh * this.m_vecUp;
				vPoints[4] = vPoints[0] + this.m_Direction * this.m_Range;
				vPoints[5] = vPoints[1] + this.m_Direction * this.m_Range;
				vPoints[6] = vPoints[2] + this.m_Direction * this.m_Range;
				vPoints[7] = vPoints[3] + this.m_Direction * this.m_Range;
				this.m_vMinBounds = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
				this.m_vMaxBounds = new Vector3(float.MinValue, float.MinValue, float.MinValue);
				for (int j = 0; j < vPoints.Length; j++)
				{
					this.m_vMinBounds = Vector3.Min(vPoints[j], this.m_vMinBounds);
					this.m_vMaxBounds = Vector3.Max(vPoints[j], this.m_vMaxBounds);
				}
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x040000CF RID: 207
		public LightType m_Type;

		// Token: 0x040000D0 RID: 208
		public Vector3 m_Color;

		// Token: 0x040000D1 RID: 209
		public Vector3 m_BounceColor;

		// Token: 0x040000D2 RID: 210
		public float m_Range;

		// Token: 0x040000D3 RID: 211
		public float m_Falloff;

		// Token: 0x040000D4 RID: 212
		public float m_Attenuation0;

		// Token: 0x040000D5 RID: 213
		public float m_Attenuation1;

		// Token: 0x040000D6 RID: 214
		public float m_Attenuation2;

		// Token: 0x040000D7 RID: 215
		public float m_Theta;

		// Token: 0x040000D8 RID: 216
		public float m_Phi;

		// Token: 0x040000D9 RID: 217
		public ITexture m_lightCookie;

		// Token: 0x040000DA RID: 218
		public int m_nLightGroupCount;

		// Token: 0x040000DB RID: 219
		public uint m_lightGroups;

		// Token: 0x040000DC RID: 220
		public bool m_bCastShadows;

		// Token: 0x040000DD RID: 221
		public int m_nShadowWidth;

		// Token: 0x040000DE RID: 222
		public int m_nShadowHeight;

		// Token: 0x040000DF RID: 223
		public int m_nShadowCascadeCount;

		// Token: 0x040000E0 RID: 224
		public float m_flShadowCascadeDistance0;

		// Token: 0x040000E1 RID: 225
		public float m_flShadowCascadeDistance1;

		// Token: 0x040000E2 RID: 226
		public float m_flShadowCascadeDistance2;

		// Token: 0x040000E3 RID: 227
		public float m_flShadowCascadeDistance3;

		// Token: 0x040000E4 RID: 228
		public int m_nShadowCascadeResolution0;

		// Token: 0x040000E5 RID: 229
		public int m_nShadowCascadeResolution1;

		// Token: 0x040000E6 RID: 230
		public int m_nShadowCascadeResolution2;

		// Token: 0x040000E7 RID: 231
		public int m_nShadowCascadeResolution3;

		// Token: 0x040000E8 RID: 232
		public bool m_bUsesIndexedBakedLighting;

		// Token: 0x040000E9 RID: 233
		public int m_nBakeLightIndex;

		// Token: 0x040000EA RID: 234
		public float m_flBakeLightIndexScale;

		// Token: 0x040000EB RID: 235
		public int m_nFogLightingMode;

		// Token: 0x040000EC RID: 236
		public bool m_bRenderDiffuse;

		// Token: 0x040000ED RID: 237
		public bool m_bRenderSpecular;

		// Token: 0x040000EE RID: 238
		public bool m_bRenderTransmissive;

		// Token: 0x040000EF RID: 239
		public int m_nPriority;

		// Token: 0x040000F0 RID: 240
		public LightSourceShape_t m_Shape;

		// Token: 0x040000F1 RID: 241
		public float m_flLightSourceDim0;

		// Token: 0x040000F2 RID: 242
		public float m_flLightSourceDim1;

		// Token: 0x040000F3 RID: 243
		public float m_flLightSourceSize0;

		// Token: 0x040000F4 RID: 244
		public float m_flLightSourceSize1;

		// Token: 0x040000F5 RID: 245
		public float m_flPrecomputedMaxRange;

		// Token: 0x040000F6 RID: 246
		public float m_flFogContributionStength;

		// Token: 0x040000F7 RID: 247
		public float m_flNearClipPlane;

		// Token: 0x040000F8 RID: 248
		public Vector3 m_Position;

		// Token: 0x040000F9 RID: 249
		public Vector3 m_Direction;

		// Token: 0x040000FA RID: 250
		public Vector3 m_vecUp;

		// Token: 0x040000FB RID: 251
		public float m_ThetaDot;

		// Token: 0x040000FC RID: 252
		public float m_PhiDot;

		// Token: 0x040000FD RID: 253
		public float m_TanPhi;

		// Token: 0x040000FE RID: 254
		public float m_OneOverThetaDotMinusPhiDot;

		// Token: 0x040000FF RID: 255
		public float m_Truncation;

		// Token: 0x04000100 RID: 256
		public OptimizationFlags m_Flags;

		// Token: 0x04000101 RID: 257
		public int m_nEnvProbeId;

		// Token: 0x04000102 RID: 258
		public Vector3 m_vMinBounds;

		// Token: 0x04000103 RID: 259
		public Vector3 m_vMaxBounds;
	}
}
