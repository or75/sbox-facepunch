using System;

namespace Sandbox
{
	// Token: 0x020000E8 RID: 232
	public class MaterialPostProcess : BasePostProcess
	{
		// Token: 0x060013A8 RID: 5032 RVA: 0x0004FC1D File Offset: 0x0004DE1D
		public MaterialPostProcess(string _materialToLoad)
		{
			this.PPMaterial = Material.Load(_materialToLoad);
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x0004FC31 File Offset: 0x0004DE31
		public MaterialPostProcess(Material _material)
		{
			this.PPMaterial = _material;
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x0004FC40 File Offset: 0x0004DE40
		public override void Render()
		{
			if (this.PPMaterial == null)
			{
				return;
			}
			Sandbox.Render.Material = this.PPMaterial;
			base.RenderScreenQuad(false);
		}

		// Token: 0x04000482 RID: 1154
		private Material PPMaterial;
	}
}
