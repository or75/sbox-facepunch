using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000BA RID: 186
	[Library]
	public class SpotLight : Light
	{
		/// <summary>
		/// Sets how much the spot light would spread, with inner and outer cone angles in degrees
		/// </summary>
		// Token: 0x1700024C RID: 588
		// (get) Token: 0x060011A5 RID: 4517 RVA: 0x0004AEA0 File Offset: 0x000490A0
		// (set) Token: 0x060011A6 RID: 4518 RVA: 0x0004AEDA File Offset: 0x000490DA
		public SpotLightCone SpotCone
		{
			get
			{
				return new SpotLightCone
				{
					Inner = this.lightNative.GetSpotInnerCone(),
					Outer = this.lightNative.GetSpotOuterCone()
				};
			}
			set
			{
				this.lightNative.SetSpotCone(value.Inner, value.Outer);
			}
		}

		// Token: 0x060011A7 RID: 4519 RVA: 0x0004AEF3 File Offset: 0x000490F3
		public SpotLight(Vector3 position, Color color)
			: base(position, 128f, color)
		{
			base.Position = position;
		}

		// Token: 0x060011A8 RID: 4520 RVA: 0x0004AF0C File Offset: 0x0004910C
		internal override void CreateThisNative(Vector3 pos, Color color, float radius)
		{
			try
			{
				HandleIndex.ForceNextObject(this);
				this.lightDesc = this.InitSpot(pos, color, Vector3.Forward);
				CSceneSystem.CreateLight(this.lightDesc, SceneWorld.Current, false);
			}
			finally
			{
				HandleIndex.UsedNextObject(this);
			}
		}

		// Token: 0x060011A9 RID: 4521 RVA: 0x0004AF60 File Offset: 0x00049160
		private LightDesc InitSpot(Vector3 pos, Color color, Vector3 dir)
		{
			LightDesc lightDesc = default(LightDesc);
			lightDesc.Clear();
			lightDesc.m_Type = LightType.LightSpot;
			lightDesc.m_Color = color;
			lightDesc.m_BounceColor = color;
			lightDesc.m_Position = pos;
			lightDesc.m_Direction = dir.Normal;
			lightDesc.m_Falloff = 0f;
			lightDesc.m_Theta = 1f;
			lightDesc.m_Phi = 30f;
			lightDesc.m_Range = 512f;
			lightDesc.m_Attenuation0 = 0f;
			lightDesc.m_Attenuation1 = 0f;
			lightDesc.m_Attenuation2 = 1f / lightDesc.m_Range;
			lightDesc.m_bRenderDiffuse = true;
			lightDesc.m_bRenderSpecular = true;
			lightDesc.m_bRenderTransmissive = true;
			lightDesc.m_bCastShadows = false;
			lightDesc.RecalculateDerivedValues(0.001f);
			return lightDesc;
		}
	}
}
