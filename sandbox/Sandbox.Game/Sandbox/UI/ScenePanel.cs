using System;
using NativeEngine;

namespace Sandbox.UI
{
	// Token: 0x0200010F RID: 271
	[Library("scene", Alias = new string[] { "scene" })]
	public class ScenePanel : Panel
	{
		// Token: 0x1700033A RID: 826
		// (get) Token: 0x06001586 RID: 5510 RVA: 0x00055727 File Offset: 0x00053927
		// (set) Token: 0x06001587 RID: 5511 RVA: 0x0005572F File Offset: 0x0005392F
		public SceneWorld World { get; set; }

		// Token: 0x1700033B RID: 827
		// (get) Token: 0x06001588 RID: 5512 RVA: 0x00055738 File Offset: 0x00053938
		// (set) Token: 0x06001589 RID: 5513 RVA: 0x00055740 File Offset: 0x00053940
		[Obsolete("Use CameraPosition instead")]
		public Vector3 Position
		{
			get
			{
				return this.CameraPosition;
			}
			set
			{
				this.CameraPosition = value;
			}
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x0600158A RID: 5514 RVA: 0x00055749 File Offset: 0x00053949
		// (set) Token: 0x0600158B RID: 5515 RVA: 0x00055751 File Offset: 0x00053951
		public Vector3 CameraPosition { get; set; }

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x0600158C RID: 5516 RVA: 0x0005575C File Offset: 0x0005395C
		// (set) Token: 0x0600158D RID: 5517 RVA: 0x00055777 File Offset: 0x00053977
		[Obsolete("Use CameraRotation instead")]
		public Angles Angles
		{
			get
			{
				return this.CameraRotation.Angles();
			}
			set
			{
				this.CameraRotation = Rotation.From(value);
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x0600158E RID: 5518 RVA: 0x00055785 File Offset: 0x00053985
		// (set) Token: 0x0600158F RID: 5519 RVA: 0x0005578D File Offset: 0x0005398D
		public Rotation CameraRotation { get; set; }

		// Token: 0x1700033F RID: 831
		// (get) Token: 0x06001590 RID: 5520 RVA: 0x00055796 File Offset: 0x00053996
		// (set) Token: 0x06001591 RID: 5521 RVA: 0x0005579E File Offset: 0x0005399E
		public float FieldOfView { get; set; } = 60f;

		// Token: 0x17000340 RID: 832
		// (get) Token: 0x06001592 RID: 5522 RVA: 0x000557A7 File Offset: 0x000539A7
		// (set) Token: 0x06001593 RID: 5523 RVA: 0x000557AF File Offset: 0x000539AF
		public Color AmbientColor { get; set; }

		// Token: 0x17000341 RID: 833
		// (get) Token: 0x06001594 RID: 5524 RVA: 0x000557B8 File Offset: 0x000539B8
		// (set) Token: 0x06001595 RID: 5525 RVA: 0x000557C0 File Offset: 0x000539C0
		public Color ClearColor { get; set; } = Color.Transparent;

		// Token: 0x17000342 RID: 834
		// (get) Token: 0x06001596 RID: 5526 RVA: 0x000557C9 File Offset: 0x000539C9
		// (set) Token: 0x06001597 RID: 5527 RVA: 0x000557D1 File Offset: 0x000539D1
		public float ZNear { get; set; } = 0.1f;

		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06001598 RID: 5528 RVA: 0x000557DA File Offset: 0x000539DA
		// (set) Token: 0x06001599 RID: 5529 RVA: 0x000557E2 File Offset: 0x000539E2
		public float ZFar { get; set; } = 1000f;

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x0600159A RID: 5530 RVA: 0x000557EB File Offset: 0x000539EB
		// (set) Token: 0x0600159B RID: 5531 RVA: 0x000557F3 File Offset: 0x000539F3
		public bool RenderOnce { get; set; }

		/// <summary>
		/// Decides whether we should render the camera as an orthographic camera or a perspective camera
		/// </summary>
		// Token: 0x17000345 RID: 837
		// (get) Token: 0x0600159C RID: 5532 RVA: 0x000557FC File Offset: 0x000539FC
		// (set) Token: 0x0600159D RID: 5533 RVA: 0x00055804 File Offset: 0x00053A04
		public bool Ortho { get; set; }

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x0600159E RID: 5534 RVA: 0x0005580D File Offset: 0x00053A0D
		public override bool HasContent
		{
			get
			{
				return this.World != null;
			}
		}

		// Token: 0x0600159F RID: 5535 RVA: 0x00055818 File Offset: 0x00053A18
		internal override void DrawContent(PanelRenderer renderer, ref RenderState state)
		{
			bool shouldRender = !this.RenderOnce;
			if (base.Box.RectInner.Size.x <= 0f)
			{
				return;
			}
			if (base.Box.RectInner.Size.y <= 0f)
			{
				return;
			}
			if (this.textures == null || this.textures.Size != base.Box.RectInner.Size || this.textures.Multisample != RenderService.GetMultisampleType())
			{
				SceneTextures sceneTextures = this.textures;
				if (sceneTextures != null)
				{
					sceneTextures.Dispose();
				}
				this.textures = null;
				this.textures = new SceneTextures(base.Box.RectInner.Size);
				shouldRender = true;
			}
			if (shouldRender)
			{
				renderer.DrawScene(this, this.textures.ColorTexture, this.textures.DepthTexture, this.World, this.CameraPosition, this.CameraRotation.Angles(), this.FieldOfView, this.AmbientColor, this.ClearColor, this.ZNear, this.ZFar, base.Box.RectInner, this.Ortho);
			}
			Render.SetCombo("D_SRGB_IMAGE", (this.textures.ColorTexture.MultisampleType != RenderMultisampleType.RENDER_MULTISAMPLE_NONE && this.textures.ColorTexture.ImageFormat == ImageFormat.RGBA8888) ? 1 : 0);
			renderer.DrawBackgroundTexture(this, this.textures.ColorTexture, state, Length.Contain);
			Render.SetCombo("D_SRGB_IMAGE", 0);
		}

		// Token: 0x060015A0 RID: 5536 RVA: 0x0005599F File Offset: 0x00053B9F
		public override void SetProperty(string name, string value)
		{
			base.SetProperty(name, value);
		}

		// Token: 0x04000516 RID: 1302
		internal SceneTextures textures;
	}
}
