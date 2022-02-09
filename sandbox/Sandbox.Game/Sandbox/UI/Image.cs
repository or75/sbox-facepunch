using System;
using Facebook.Yoga;

namespace Sandbox.UI
{
	// Token: 0x0200010C RID: 268
	[Library("image", Alias = new string[] { "img" })]
	public class Image : Panel
	{
		// Token: 0x17000334 RID: 820
		// (get) Token: 0x06001573 RID: 5491 RVA: 0x000554E5 File Offset: 0x000536E5
		// (set) Token: 0x06001574 RID: 5492 RVA: 0x000554ED File Offset: 0x000536ED
		public Texture Texture { get; set; }

		// Token: 0x17000335 RID: 821
		// (get) Token: 0x06001575 RID: 5493 RVA: 0x000554F6 File Offset: 0x000536F6
		public override bool HasContent
		{
			get
			{
				return this.Texture != null;
			}
		}

		// Token: 0x06001576 RID: 5494 RVA: 0x00055501 File Offset: 0x00053701
		public Image()
		{
			this.YogaNode.SetMeasureFunction(new MeasureFunction(this.MeasureTexture));
		}

		// Token: 0x06001577 RID: 5495 RVA: 0x00055520 File Offset: 0x00053720
		public void SetTexture(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				return;
			}
			this.Texture = Texture.Load(FileSystem.Mounted, name, true);
		}

		// Token: 0x06001578 RID: 5496 RVA: 0x00055540 File Offset: 0x00053740
		internal override void DrawContent(PanelRenderer renderer, ref RenderState state)
		{
			if (this.Texture == null)
			{
				return;
			}
			if (renderer != null)
			{
				renderer.DrawBackgroundTexture(this, this.Texture, state, Length.Cover);
			}
		}

		// Token: 0x06001579 RID: 5497 RVA: 0x0005556E File Offset: 0x0005376E
		public override void SetProperty(string name, string value)
		{
			base.SetProperty(name, value);
			if (name == "src")
			{
				this.SetTexture(value);
			}
		}

		// Token: 0x0600157A RID: 5498 RVA: 0x0005558C File Offset: 0x0005378C
		internal YogaSize MeasureTexture(YogaNode node, float width, YogaMeasureMode widthMode, float height, YogaMeasureMode heightMode)
		{
			if (this.Texture == null)
			{
				return new YogaSize
				{
					width = 0f,
					height = 0f
				};
			}
			return new YogaSize
			{
				width = (float)this.Texture.Width * base.ScaleToScreen,
				height = (float)this.Texture.Height * base.ScaleToScreen
			};
		}
	}
}
