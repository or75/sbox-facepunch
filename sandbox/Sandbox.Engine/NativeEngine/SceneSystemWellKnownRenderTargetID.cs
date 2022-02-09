﻿using System;

namespace NativeEngine
{
	// Token: 0x02000269 RID: 617
	internal enum SceneSystemWellKnownRenderTargetID
	{
		/// <summary>
		/// a scratch render target texture for use for monitor rendering and other temp storage
		/// </summary>
		// Token: 0x04001142 RID: 4418
		SCENE_RTGT_SCRATCH_TEXTURE_8888,
		// Token: 0x04001143 RID: 4419
		SCENE_RTGT_SCRATCH_TEXTURE_1010102,
		// Token: 0x04001144 RID: 4420
		SCENE_RTGT_SCRATCH_DEPTHSTENCIL_TEXTURE,
		// Token: 0x04001145 RID: 4421
		SCENE_RTGT_SCRATCH_TEXTURE_16F16F,
		// Token: 0x04001146 RID: 4422
		SCENE_RTGT_SCRATCH_SCALABLE_AMBIENT_OBSCURANCE_MIPPED_DEPTH,
		// Token: 0x04001147 RID: 4423
		SCENE_RTGT_SCRATCH_TEXTURE_16161616F_MIPPED,
		// Token: 0x04001148 RID: 4424
		SCENE_RTGT_SCRATCH_TEXTURE_8888_MIPPED,
		// Token: 0x04001149 RID: 4425
		SCENE_RTGT_SCRATCH_TEXTURE_1010102_MIPPED,
		// Token: 0x0400114A RID: 4426
		SCENE_RTGT_SCRATCH_TEXTURE_16161616F,
		// Token: 0x0400114B RID: 4427
		SCENE_RTGT_COUNT
	}
}
