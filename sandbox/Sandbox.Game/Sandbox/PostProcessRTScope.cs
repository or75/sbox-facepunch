using System;

namespace Sandbox
{
	/// <summary>
	/// Returns the post processing ColorBuffer, Viewport and Render Target back
	/// to the original settings for this pass. This is mainly used for rendering
	/// something to a texture on a pass
	/// </summary>
	// Token: 0x020000E9 RID: 233
	internal struct PostProcessRTScope : IDisposable
	{
		// Token: 0x060013AB RID: 5035 RVA: 0x0004FC5D File Offset: 0x0004DE5D
		public void Dispose()
		{
			RenderingManager.SetupPostProcessingBuffer();
		}
	}
}
