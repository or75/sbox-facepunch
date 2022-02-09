using System;
using NativeEngine;
using Sandbox.Internal;

namespace Sandbox
{
	// Token: 0x020000EC RID: 236
	internal static class RenderingManager
	{
		// Token: 0x170002EB RID: 747
		// (get) Token: 0x060013E5 RID: 5093 RVA: 0x00051082 File Offset: 0x0004F282
		private static Texture RenderSource
		{
			get
			{
				if (!RenderingManager.PingPong)
				{
					return GlobalGameNamespace.PostProcess.PongTexture;
				}
				return GlobalGameNamespace.PostProcess.PingTexture;
			}
		}

		// Token: 0x170002EC RID: 748
		// (get) Token: 0x060013E6 RID: 5094 RVA: 0x000510A0 File Offset: 0x0004F2A0
		private static Texture RenderTarget
		{
			get
			{
				if (!RenderingManager.PingPong)
				{
					return GlobalGameNamespace.PostProcess.PingTexture;
				}
				return GlobalGameNamespace.PostProcess.PongTexture;
			}
		}

		/// <summary>
		/// Called from render thread
		/// </summary>
		// Token: 0x060013E7 RID: 5095 RVA: 0x000510C0 File Offset: 0x0004F2C0
		internal static void RenderUI()
		{
			Hotload hotload = GlobalGameNamespace.Global.HotloadManager.Hotload;
			lock (hotload)
			{
				Render.SetSamplerStatePS(0, FilterMode.Linear, TextureAddressMode.Clamp, TextureAddressMode.Clamp, TextureAddressMode.Wrap, ComparisonMode.Less);
				UISystem.Render();
				VROverlay.RenderAll();
			}
		}

		// Token: 0x060013E8 RID: 5096 RVA: 0x0005111C File Offset: 0x0004F31C
		internal static void BlockStart(ISceneView view, IRenderContext context, ISceneLayer layer)
		{
			Render.RenderingBlockOpen(view, context, layer);
		}

		// Token: 0x060013E9 RID: 5097 RVA: 0x00051126 File Offset: 0x0004F326
		internal static void BlockEnd()
		{
			Render.RenderingBlockClose();
		}

		// Token: 0x060013EA RID: 5098 RVA: 0x0005112D File Offset: 0x0004F32D
		internal static void RenderSceneObject(int objectId)
		{
			HandleIndex.Get<CustomSceneObject>(objectId).RenderInternal();
		}

		// Token: 0x060013EB RID: 5099 RVA: 0x0005113C File Offset: 0x0004F33C
		internal static void SetupPostProcessingBuffer()
		{
			Rect viewportRect = Render.SceneLayer.m_viewport.Rect;
			Render.SetViewport((int)viewportRect.left, (int)viewportRect.top, (int)viewportRect.width, (int)viewportRect.height);
			Render.SetRenderTarget(RenderingManager.RenderTarget);
			string name = "ColorBuffer";
			Texture renderSource = RenderingManager.RenderSource;
			int num = -1;
			Render.Set(name, renderSource, num);
		}

		// Token: 0x060013EC RID: 5100 RVA: 0x0005119F File Offset: 0x0004F39F
		internal static void FlipPostProcessingBuffer(bool doFlip = false)
		{
			if (doFlip)
			{
				RenderingManager.PingPong = !RenderingManager.PingPong;
			}
			RenderingManager.SetupPostProcessingBuffer();
		}

		// Token: 0x060013ED RID: 5101 RVA: 0x000511B8 File Offset: 0x0004F3B8
		internal static void PostProcess()
		{
			Hotload hotload = GlobalGameNamespace.Global.HotloadManager.Hotload;
			lock (hotload)
			{
				RenderingManager.PingPong = false;
				PostProcessSystem postProcess = GlobalGameNamespace.PostProcess;
				int layerCount = ((postProcess != null) ? postProcess.Count : 0);
				if (layerCount != 0)
				{
					RenderTargetDesc rtOriginal = Render.SceneLayer.GetRenderTargetDesc();
					Rect viewportRect = Render.SceneLayer.m_viewport.Rect;
					Render.SetRenderTarget(RenderingManager.RenderSource);
					Render.SetViewport(viewportRect);
					string name = "ColorBuffer";
					Texture value = new Texture(Render.SceneLayer.GetTextureValue("ColorBuffer"));
					int num = -1;
					Render.Set(name, value, num);
					GlobalGameNamespace.PostProcess.FramebufferBlit(false);
					for (int i = 0; i < layerCount; i++)
					{
						RenderingManager.FlipPostProcessingBuffer(false);
						GlobalGameNamespace.PostProcess.RenderEffect(i);
						RenderingManager.PingPong = !RenderingManager.PingPong;
					}
					Render.SetRenderTarget(rtOriginal);
					Render.SetViewport((int)viewportRect.left, (int)viewportRect.top, (int)viewportRect.width, (int)viewportRect.height);
					string name2 = "ColorBuffer";
					Texture renderSource = RenderingManager.RenderSource;
					num = -1;
					Render.Set(name2, renderSource, num);
					GlobalGameNamespace.PostProcess.FramebufferBlit(false);
				}
			}
		}

		// Token: 0x040004A7 RID: 1191
		private static bool PingPong;
	}
}
