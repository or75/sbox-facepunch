using System;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000F4 RID: 244
	public class SceneParticleObject : SceneObject
	{
		// Token: 0x06001459 RID: 5209 RVA: 0x00052089 File Offset: 0x00050289
		internal SceneParticleObject()
		{
		}

		// Token: 0x0600145A RID: 5210 RVA: 0x00052091 File Offset: 0x00050291
		internal SceneParticleObject(HandleCreationData _)
		{
		}

		// Token: 0x17000301 RID: 769
		// (get) Token: 0x0600145B RID: 5211 RVA: 0x00052099 File Offset: 0x00050299
		internal IParticleCollection Particles
		{
			get
			{
				return this.particleNative.GetParticles();
			}
		}

		// Token: 0x17000302 RID: 770
		// (get) Token: 0x0600145D RID: 5213 RVA: 0x000520C4 File Offset: 0x000502C4
		// (set) Token: 0x0600145C RID: 5212 RVA: 0x000520A8 File Offset: 0x000502A8
		public bool RenderParticles
		{
			get
			{
				return this.Particles.GetRenderingEnabled();
			}
			set
			{
				this.Particles.SetRenderingEnabled(value);
			}
		}

		// Token: 0x0600145E RID: 5214 RVA: 0x000520E0 File Offset: 0x000502E0
		public bool IsControlPointSet(int index)
		{
			return this.Particles.IsControlPointSet(index);
		}

		// Token: 0x0600145F RID: 5215 RVA: 0x000520FC File Offset: 0x000502FC
		public Vector3 GetControlPointPosition(int index)
		{
			return this.Particles.GetControlPointPosition(index);
		}

		// Token: 0x06001460 RID: 5216 RVA: 0x00052118 File Offset: 0x00050318
		internal override void OnNativeInit(CSceneObject ptr)
		{
			base.OnNativeInit(ptr);
			this.particleNative = (CSceneParticleObject)ptr;
		}

		// Token: 0x06001461 RID: 5217 RVA: 0x0005212D File Offset: 0x0005032D
		internal override void OnNativeDestroy()
		{
			base.OnNativeDestroy();
			this.particleNative = default(CSceneParticleObject);
		}

		// Token: 0x040004BF RID: 1215
		private CSceneParticleObject particleNative;
	}
}
