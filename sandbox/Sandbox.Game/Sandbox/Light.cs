using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000B6 RID: 182
	[Library]
	public class Light : SceneObject
	{
		// Token: 0x06001194 RID: 4500 RVA: 0x0004AC5C File Offset: 0x00048E5C
		internal Light()
		{
		}

		// Token: 0x06001195 RID: 4501 RVA: 0x0004AC64 File Offset: 0x00048E64
		internal Light(HandleCreationData _)
		{
		}

		/// <summary>
		/// Color and brightness of the light
		/// </summary>
		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06001196 RID: 4502 RVA: 0x0004AC6C File Offset: 0x00048E6C
		// (set) Token: 0x06001197 RID: 4503 RVA: 0x0004AC7E File Offset: 0x00048E7E
		public Color LightColor
		{
			get
			{
				return this.lightNative.GetColor();
			}
			set
			{
				this.lightNative.SetColor(value);
			}
		}

		/// <summary>
		/// Attenuation of how much brightness the light loses the more it travels
		/// </summary>
		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06001198 RID: 4504 RVA: 0x0004AC91 File Offset: 0x00048E91
		// (set) Token: 0x06001199 RID: 4505 RVA: 0x0004AC9E File Offset: 0x00048E9E
		public float Falloff
		{
			get
			{
				return this.lightNative.GetFalloff();
			}
			set
			{
				this.lightNative.SetFalloff(value);
			}
		}

		/// <summary>
		/// Radius of the light in units
		/// </summary>
		// Token: 0x1700024B RID: 587
		// (get) Token: 0x0600119A RID: 4506 RVA: 0x0004ACAC File Offset: 0x00048EAC
		// (set) Token: 0x0600119B RID: 4507 RVA: 0x0004ACB9 File Offset: 0x00048EB9
		public float Radius
		{
			get
			{
				return this.lightNative.GetRadius();
			}
			set
			{
				this.lightNative.SetRadius(value);
			}
		}

		// Token: 0x0600119C RID: 4508 RVA: 0x0004ACC7 File Offset: 0x00048EC7
		internal override void OnTransformChanged(Transform tx)
		{
			base.OnTransformChanged(tx);
			this.lightNative.SetWorldDirection(tx.Rotation.Forward);
			this.lightNative.SetWorldPosition(tx.Position);
		}

		// Token: 0x0600119D RID: 4509 RVA: 0x0004ACF8 File Offset: 0x00048EF8
		public Light(Vector3 position, float radius, Color color)
		{
			Host.AssertClientOrMenu(".ctor");
			this.CreateThisNative(position, color, radius);
			base.Position = position;
		}

		// Token: 0x0600119E RID: 4510 RVA: 0x0004AD1A File Offset: 0x00048F1A
		public static Light Point(Vector3 position, float radius, Color color)
		{
			return new Light(position, radius, color);
		}

		// Token: 0x0600119F RID: 4511 RVA: 0x0004AD24 File Offset: 0x00048F24
		internal override void OnNativeInit(CSceneObject ptr)
		{
			base.OnNativeInit(ptr);
			this.lightNative = (CSceneLightObject)ptr;
		}

		// Token: 0x060011A0 RID: 4512 RVA: 0x0004AD39 File Offset: 0x00048F39
		internal override void OnNativeDestroy()
		{
			base.OnNativeDestroy();
			this.lightNative = IntPtr.Zero;
		}

		// Token: 0x060011A1 RID: 4513 RVA: 0x0004AD54 File Offset: 0x00048F54
		internal virtual void CreateThisNative(Vector3 pos, Color color, float radius)
		{
			SceneWorld sceneWorld = SceneWorld.Current;
			if (sceneWorld == null || sceneWorld.native.IsNull)
			{
				throw new Exception("SceneWorld is NULL");
			}
			try
			{
				HandleIndex.ForceNextObject(this);
				this.lightDesc = this.InitPoint(pos, color, radius);
				Assert.AreEqual<Light>(CSceneSystem.CreateLight(this.lightDesc, sceneWorld, false), this);
			}
			finally
			{
				HandleIndex.UsedNextObject(this);
			}
		}

		// Token: 0x060011A2 RID: 4514 RVA: 0x0004ADC4 File Offset: 0x00048FC4
		private LightDesc InitPoint(Vector3 pos, Color color, float radius)
		{
			LightDesc i = default(LightDesc);
			i.Clear();
			i.m_Type = LightType.LightPoint;
			i.m_Color = color;
			i.m_BounceColor = color;
			i.m_Position = pos;
			i.m_Range = radius;
			i.m_Attenuation0 = 0f;
			i.m_Attenuation1 = 0f;
			i.m_Attenuation2 = 1f / radius;
			i.m_bRenderDiffuse = true;
			i.m_bRenderSpecular = true;
			i.m_bRenderTransmissive = true;
			i.m_bCastShadows = true;
			i.RecalculateDerivedValues(0.001f);
			return i;
		}

		// Token: 0x060011A3 RID: 4515 RVA: 0x0004AE68 File Offset: 0x00049068
		~Light()
		{
		}

		// Token: 0x0400037A RID: 890
		internal LightDesc lightDesc;

		// Token: 0x0400037B RID: 891
		internal CSceneLightObject lightNative;

		// Token: 0x0400037C RID: 892
		internal LightType lightType;
	}
}
