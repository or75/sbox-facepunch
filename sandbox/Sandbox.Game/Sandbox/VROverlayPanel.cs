using System;
using NativeEngine;
using OpenVR;
using Sandbox.UI;

namespace Sandbox
{
	/// <summary>
	/// <para>A <see cref="T:Sandbox.VROverlay" /> that draws and handles input of a <see cref="T:Sandbox.UI.RootPanel" />.</para>
	///
	/// <para>VR overlays draw over the top of the 3D scene, they will not be affected by lighting,
	/// post processing effects or anything else in the world.<br />
	/// This makes them ideal for HUDs or menus, or anything else that should be local to the
	/// HMD or tracked devices.</para>
	///
	/// <para>If you need something in the world, consider using WorldPanel
	/// and <see cref="T:Sandbox.UI.WorldInput" /> instead.</para>
	/// </summary>
	// Token: 0x02000107 RID: 263
	public sealed class VROverlayPanel : VROverlay
	{
		// Token: 0x17000331 RID: 817
		// (get) Token: 0x0600154E RID: 5454 RVA: 0x00054AC4 File Offset: 0x00052CC4
		// (set) Token: 0x0600154F RID: 5455 RVA: 0x00054ACC File Offset: 0x00052CCC
		public RootPanel RootPanel { get; set; }

		// Token: 0x06001550 RID: 5456 RVA: 0x00054AD8 File Offset: 0x00052CD8
		public VROverlayPanel(RootPanel panel)
		{
			this.RootPanel = panel;
			this.RootPanel.RenderedManually = true;
			this.RootPanel.IsVR = true;
			VROverlay.Assert(VRGlue.Overlay().SetOverlayInputMethod(this.handle, VROverlayInputMethod.Mouse));
			this.CreateRenderTarget();
		}

		// Token: 0x06001551 RID: 5457 RVA: 0x00054B29 File Offset: 0x00052D29
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			this.RootPanel.Delete(true);
		}

		// Token: 0x06001552 RID: 5458 RVA: 0x00054B40 File Offset: 0x00052D40
		internal void CreateRenderTarget()
		{
			this._boundsSize = this.RootPanel.PanelBounds.Size;
			base.Texture = Texture.CreateRenderTarget().WithSize(this._boundsSize).WithScreenFormat()
				.WithScreenMultiSample()
				.Create(null, true, default(ReadOnlySpan<byte>), 0);
			base.MouseScale = this._boundsSize;
		}

		// Token: 0x06001553 RID: 5459 RVA: 0x00054BB0 File Offset: 0x00052DB0
		internal override void Render()
		{
			if (this.RootPanel == null)
			{
				return;
			}
			if (!base.Visible)
			{
				return;
			}
			if (this.RootPanel.WantsMouseInput != null && !this._interactiveIfVisible)
			{
				VROverlay.Assert(VRGlue.Overlay().SetOverlayFlag(this.handle, VROverlayFlags.MakeOverlaysInteractiveIfVisible, this._interactiveIfVisible = true));
			}
			else if (this.RootPanel.WantsMouseInput == null && this._interactiveIfVisible)
			{
				VROverlay.Assert(VRGlue.Overlay().SetOverlayFlag(this.handle, VROverlayFlags.MakeOverlaysInteractiveIfVisible, this._interactiveIfVisible = false));
			}
			this.RenderUI();
			base.Render();
		}

		// Token: 0x06001554 RID: 5460 RVA: 0x00054C58 File Offset: 0x00052E58
		internal void RenderUI()
		{
			Sandbox.Render.AssertRenderBlock();
			if (this.RootPanel.PanelBounds.Size != this._boundsSize)
			{
				this.CreateRenderTarget();
			}
			using (Sandbox.Render.RenderTarget(base.Texture))
			{
				Sandbox.Render.SetSamplerStatePS(0, FilterMode.Linear, TextureAddressMode.Clamp, TextureAddressMode.Clamp, TextureAddressMode.Wrap, ComparisonMode.Less);
				Sandbox.Render.SetCombo("D_WORLDPANEL", 0);
				Sandbox.Render.SetViewport(0, 0, (int)this.RootPanel.PanelBounds.Size.x, (int)this.RootPanel.PanelBounds.Size.y);
				Sandbox.Render.Clear(true, true);
				this.RootPanel.Render();
				Sandbox.Render.SetViewport((int)Sandbox.Render.Viewport.Position.x, (int)Sandbox.Render.Viewport.Position.y, (int)Sandbox.Render.Viewport.width, (int)Sandbox.Render.Viewport.height);
			}
		}

		// Token: 0x040004FC RID: 1276
		internal Vector2 _boundsSize;

		// Token: 0x040004FD RID: 1277
		internal bool _interactiveIfVisible;
	}
}
