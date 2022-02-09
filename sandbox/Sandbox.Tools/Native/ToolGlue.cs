using System;
using Sandbox;

namespace Native
{
	// Token: 0x0200005F RID: 95
	internal static class ToolGlue
	{
		// Token: 0x060010EE RID: 4334 RVA: 0x0002DDB8 File Offset: 0x0002BFB8
		internal static void ShowTool(string nam)
		{
			method toolGl_ShowTool = ToolGlue.__N.ToolGl_ShowTool;
			calli(System.Void(System.IntPtr), Interop.GetPointer(nam), toolGl_ShowTool);
		}

		// Token: 0x0200012B RID: 299
		internal static class __N
		{
			// Token: 0x04001240 RID: 4672
			internal static method ToolGl_ShowTool;
		}
	}
}
