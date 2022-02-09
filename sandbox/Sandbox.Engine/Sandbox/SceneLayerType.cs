using System;

namespace Sandbox
{
	// Token: 0x0200029D RID: 669
	public enum SceneLayerType
	{
		// Token: 0x04001347 RID: 4935
		Unknown,
		/// <summary>
		/// Translucent pass. We're rendering translucent objects in depth sorted order, from back to front.
		/// </summary>
		// Token: 0x04001348 RID: 4936
		Translucent,
		/// <summary>
		/// After the game is rendered the UI is drawn over the top
		/// </summary>
		// Token: 0x04001349 RID: 4937
		UI,
		/// <summary>
		/// Rendering shadows for the sun
		/// </summary>
		// Token: 0x0400134A RID: 4938
		SunShadow,
		/// <summary>
		/// Rendering dynamic shadows
		/// </summary>
		// Token: 0x0400134B RID: 4939
		Shadow,
		/// <summary>
		/// Translucent effects on the 1/4 texture
		/// </summary>
		// Token: 0x0400134C RID: 4940
		EffectsTranslucent,
		/// <summary>
		/// Opaque effects on the 1/4 texture
		/// </summary>
		// Token: 0x0400134D RID: 4941
		EffectsOpaque,
		/// <summary>
		/// Depth prepass to reduce overdraw
		/// </summary>
		// Token: 0x0400134E RID: 4942
		DepthPrepass,
		// Token: 0x0400134F RID: 4943
		Opaque,
		/// <summary>
		/// Post process yeah
		/// </summary>
		// Token: 0x04001350 RID: 4944
		PostProcess
	}
}
