using System;
using Sandbox.UI;

namespace Sandbox
{
	// Token: 0x020000F2 RID: 242
	public class PanelSceneObject : CustomSceneObject
	{
		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06001425 RID: 5157 RVA: 0x00051B69 File Offset: 0x0004FD69
		// (set) Token: 0x06001426 RID: 5158 RVA: 0x00051B71 File Offset: 0x0004FD71
		public RootPanel Panel { get; protected set; }

		/// <summary>
		/// Set an override for the Z buffer mode. This affects how depth tests and writes are handled when
		/// rendering this.
		/// </summary>
		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x06001427 RID: 5159 RVA: 0x00051B7A File Offset: 0x0004FD7A
		// (set) Token: 0x06001428 RID: 5160 RVA: 0x00051B82 File Offset: 0x0004FD82
		public ZBufferMode ZBufferMode { get; set; } = ZBufferMode.TestAndWrite;

		// Token: 0x06001429 RID: 5161 RVA: 0x00051B8B File Offset: 0x0004FD8B
		public PanelSceneObject(RootPanel Panel)
		{
			Host.AssertClientOrMenu(".ctor");
			this.Panel = Panel;
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x00051BAC File Offset: 0x0004FDAC
		public override void RenderSceneObject()
		{
			Render.SetCombo("D_WORLDPANEL", 1);
			Matrix mat = Matrix.CreateRotation(Rotation.From(0f, 90f, 90f));
			mat *= Matrix.CreateScale(0.05f);
			Render.Set("WorldMat", mat);
			Render.ZBufferMode = this.ZBufferMode;
			RootPanel panel = this.Panel;
			if (panel == null)
			{
				return;
			}
			panel.Render();
		}

		// Token: 0x040004B9 RID: 1209
		public const float ScreenToWorldScale = 0.05f;
	}
}
