using System;
using System.Collections.Generic;
using System.Linq;
using NativeEngine;

namespace Sandbox
{
	// Token: 0x020000E6 RID: 230
	public class PostProcessSystem
	{
		// Token: 0x170002DC RID: 732
		// (get) Token: 0x0600138C RID: 5004 RVA: 0x0004F86C File Offset: 0x0004DA6C
		internal int Count
		{
			get
			{
				return this.Effects.Count;
			}
		}

		// Token: 0x0600138D RID: 5005 RVA: 0x0004F87C File Offset: 0x0004DA7C
		public PostProcessSystem()
		{
			Host.AssertClient(".ctor");
			SboxRender.HasPostProcessingLayers(false);
			this.BlitMaterial = Material.Load("materials/postprocess/passthrough.vmat");
			this.PingTexture = Texture.CreateRenderTarget().WithFormat(ImageFormat.RGBA16161616F).WithSize(Screen.Size)
				.Create("PP_PingTexture", true, default(ReadOnlySpan<byte>), 0);
			this.PongTexture = Texture.CreateRenderTarget().WithFormat(ImageFormat.RGBA16161616F).WithSize(Screen.Size)
				.Create("PP_PongTexture", true, default(ReadOnlySpan<byte>), 0);
		}

		// Token: 0x0600138E RID: 5006 RVA: 0x0004F930 File Offset: 0x0004DB30
		[Event.Screen.SizeChangedAttribute]
		internal void TickPostProcess()
		{
			this.PingTexture = Texture.CreateRenderTarget().WithFormat(ImageFormat.RGBA16161616F).WithSize(Screen.Size)
				.Create("PP_PingTexture", true, default(ReadOnlySpan<byte>), 0);
			this.PongTexture = Texture.CreateRenderTarget().WithFormat(ImageFormat.RGBA16161616F).WithSize(Screen.Size)
				.Create("PP_PongTexture", true, default(ReadOnlySpan<byte>), 0);
		}

		/// <summary>
		/// Add a new post-processing effect to the post-processing
		/// stack. This can only be called on the client and not on
		/// the server. Only call this once to add the effect, not to modify
		/// it or make changes
		/// </summary>
		/// <typeparam name="T">BasePostProcess</typeparam>
		/// <param name="value">The post-processing object</param>
		// Token: 0x0600138F RID: 5007 RVA: 0x0004F9B1 File Offset: 0x0004DBB1
		public void Add<T>(T value) where T : BasePostProcess
		{
			Host.AssertClient("Add");
			Render.AssertOutOfRenderBlock();
			this.Effects.Add(value);
			SboxRender.HasPostProcessingLayers(true);
		}

		/// <summary>
		/// Get an instance of the post-processing effect. It's recommended
		/// to keep a copy of your object you passed to PostProcess.Add instead
		/// of using this as it lets you create multiples of the same post processing effect
		/// </summary>
		/// <typeparam name="T">BasePostProcess</typeparam>
		/// <returns>The post-processing object passed into PostProcess.Add</returns>
		// Token: 0x06001390 RID: 5008 RVA: 0x0004F9DC File Offset: 0x0004DBDC
		public T Get<T>() where T : BasePostProcess
		{
			Host.AssertClient("Get");
			if (this.Count == 0)
			{
				return default(T);
			}
			return this.Effects.OfType<T>().First<T>();
		}

		// Token: 0x06001391 RID: 5009 RVA: 0x0004FA15 File Offset: 0x0004DC15
		internal void FramebufferBlit(bool fullUvSpace = false)
		{
			Host.AssertClient("FramebufferBlit");
			if (this.BlitMaterial == null)
			{
				return;
			}
			Render.SetCombo("D_NO_UV", false);
			Render.Material = this.BlitMaterial;
			Render.DrawScreenQuadEx(Render.Attributes, fullUvSpace);
		}

		// Token: 0x06001392 RID: 5010 RVA: 0x0004FA4B File Offset: 0x0004DC4B
		internal void FlipFramebuffer()
		{
			Host.AssertClient("FlipFramebuffer");
			RenderingManager.FlipPostProcessingBuffer(true);
		}

		/// <summary>
		/// Remove all post processing effects from the
		/// post processing stack
		/// </summary>
		// Token: 0x06001393 RID: 5011 RVA: 0x0004FA5D File Offset: 0x0004DC5D
		public void Clear()
		{
			Host.AssertClient("Clear");
			this.Effects.Clear();
			SboxRender.HasPostProcessingLayers(false);
		}

		// Token: 0x06001394 RID: 5012 RVA: 0x0004FA7A File Offset: 0x0004DC7A
		internal void RenderEffect(int layerId)
		{
			if (layerId < 0 || layerId >= this.Count)
			{
				return;
			}
			this.Effects[layerId].Render();
		}

		// Token: 0x0400047D RID: 1149
		private Material BlitMaterial;

		// Token: 0x0400047E RID: 1150
		internal Texture PingTexture;

		// Token: 0x0400047F RID: 1151
		internal Texture PongTexture;

		// Token: 0x04000480 RID: 1152
		private List<BasePostProcess> Effects = new List<BasePostProcess>();
	}
}
