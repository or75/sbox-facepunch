using System;

namespace Sandbox.UI
{
	// Token: 0x0200012C RID: 300
	public static class Materials
	{
		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06001733 RID: 5939 RVA: 0x0005D6C9 File Offset: 0x0005B8C9
		// (set) Token: 0x06001734 RID: 5940 RVA: 0x0005D6D0 File Offset: 0x0005B8D0
		public static Material Box { get; internal set; }

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06001735 RID: 5941 RVA: 0x0005D6D8 File Offset: 0x0005B8D8
		// (set) Token: 0x06001736 RID: 5942 RVA: 0x0005D6DF File Offset: 0x0005B8DF
		public static Material BoxShadow { get; internal set; }

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x06001737 RID: 5943 RVA: 0x0005D6E7 File Offset: 0x0005B8E7
		// (set) Token: 0x06001738 RID: 5944 RVA: 0x0005D6EE File Offset: 0x0005B8EE
		public static Material Text { get; internal set; }

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x06001739 RID: 5945 RVA: 0x0005D6F6 File Offset: 0x0005B8F6
		// (set) Token: 0x0600173A RID: 5946 RVA: 0x0005D6FD File Offset: 0x0005B8FD
		public static Material BackdropFilter { get; internal set; }

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x0600173B RID: 5947 RVA: 0x0005D705 File Offset: 0x0005B905
		// (set) Token: 0x0600173C RID: 5948 RVA: 0x0005D70C File Offset: 0x0005B90C
		public static Material Filter { get; internal set; }

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x0600173D RID: 5949 RVA: 0x0005D714 File Offset: 0x0005B914
		// (set) Token: 0x0600173E RID: 5950 RVA: 0x0005D71B File Offset: 0x0005B91B
		public static Material Blur { get; internal set; }

		// Token: 0x0600173F RID: 5951 RVA: 0x0005D724 File Offset: 0x0005B924
		internal static void Init()
		{
			Materials.Box = Material.Load("materials/ui/cssbox.vmat");
			Materials.BoxShadow = Material.Load("materials/ui/cssshadow.vmat");
			Materials.Text = Material.Load("materials/ui/text.vmat");
			Materials.BackdropFilter = Material.Load("materials/ui/backdropfilter.vmat");
			Materials.Filter = Material.Load("materials/ui/filter.vmat");
			Materials.Blur = Material.Load("materials/ui/blur.vmat");
		}
	}
}
