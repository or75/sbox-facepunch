using System;

namespace Sandbox.UI.Construct
{
	// Token: 0x02000153 RID: 339
	public static class ImageConstructor
	{
		// Token: 0x060019A9 RID: 6569 RVA: 0x0006BDA8 File Offset: 0x00069FA8
		public static Image Image(this PanelCreator self, string image = null, string classname = null)
		{
			Image control = self.panel.AddChild<Image>(null);
			if (image != null)
			{
				control.SetTexture(image);
			}
			if (classname != null)
			{
				control.AddClass(classname);
			}
			return control;
		}
	}
}
