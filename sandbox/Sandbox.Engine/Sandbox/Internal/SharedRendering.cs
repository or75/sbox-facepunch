using System;

namespace Sandbox.Internal
{
	// Token: 0x020002F0 RID: 752
	internal static class SharedRendering
	{
		/// <summary>
		/// Set from the menu context to tell the client context where we want to render the main viewport.
		/// </summary>
		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x060013FF RID: 5119 RVA: 0x0002AB87 File Offset: 0x00028D87
		// (set) Token: 0x06001400 RID: 5120 RVA: 0x0002AB8E File Offset: 0x00028D8E
		public static Rect RenderRect { get; internal set; }
	}
}
