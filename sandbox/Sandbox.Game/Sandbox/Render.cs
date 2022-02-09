using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NativeEngine;
using Sandbox.Internal;
using Sandbox.UI;

namespace Sandbox
{
	// Token: 0x020000EB RID: 235
	public static class Render
	{
		// Token: 0x170002E1 RID: 737
		// (get) Token: 0x060013B3 RID: 5043 RVA: 0x00050534 File Offset: 0x0004E734
		internal static CRenderAttributes Attributes
		{
			get
			{
				Render.AssertRenderBlock();
				return Render.attributes;
			}
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x00050540 File Offset: 0x0004E740
		public static void ClearAttributes()
		{
			Render.Attributes.Clear(true, true);
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x0005055C File Offset: 0x0004E75C
		public static void Set(string name, in int value)
		{
			Render.Attributes.SetIntValue(name, value);
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x0005057C File Offset: 0x0004E77C
		public static void Set(string name, in bool value)
		{
			Render.Attributes.SetBoolValue(name, value);
		}

		// Token: 0x060013B7 RID: 5047 RVA: 0x0005059C File Offset: 0x0004E79C
		public static void Set(string name, in string value)
		{
			Render.Attributes.SetStringValue(name, value);
		}

		// Token: 0x060013B8 RID: 5048 RVA: 0x000505BC File Offset: 0x0004E7BC
		public static void Set(string name, in float value)
		{
			Render.Attributes.SetFloatValue(name, value);
		}

		// Token: 0x060013B9 RID: 5049 RVA: 0x000505DC File Offset: 0x0004E7DC
		public static void Set(string name, Texture value, in int mipLevel = -1)
		{
			Render.Attributes.SetTextureValue(name, value.native, mipLevel);
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x00050600 File Offset: 0x0004E800
		public static void Set(string name, in Vector2 value)
		{
			Render.Attributes.SetVector2DValue(name, value);
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x00050624 File Offset: 0x0004E824
		public static void Set(string name, in Vector3 value)
		{
			Render.Attributes.SetVectorValue(name, value);
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x00050648 File Offset: 0x0004E848
		public static void Set(string name, in Vector4 value)
		{
			Render.Attributes.SetVector4DValue(name, value);
		}

		// Token: 0x060013BD RID: 5053 RVA: 0x0005066C File Offset: 0x0004E86C
		public static void Set(string name, in Matrix value)
		{
			Render.Attributes.SetVMatrixValue(name, value);
		}

		// Token: 0x060013BE RID: 5054 RVA: 0x00050690 File Offset: 0x0004E890
		public static void Set(string name, in ConstantBuffer value, in uint view = 0)
		{
			Render.Attributes.SetConstantBufferValue(name, value.bufferHandle, view);
		}

		// Token: 0x060013BF RID: 5055 RVA: 0x000506B4 File Offset: 0x0004E8B4
		public static void SetCombo(string name, byte value)
		{
			Render.Attributes.SetComboValue(name, value);
		}

		// Token: 0x060013C0 RID: 5056 RVA: 0x000506D0 File Offset: 0x0004E8D0
		public static void SetCombo(string name, bool value)
		{
			Render.SetCombo(name, value ? 1 : 0);
		}

		// Token: 0x170002E2 RID: 738
		// (get) Token: 0x060013C1 RID: 5057 RVA: 0x000506E0 File Offset: 0x0004E8E0
		internal static ISceneLayer SceneLayer
		{
			get
			{
				return Render.sceneLayer;
			}
		}

		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x060013C2 RID: 5058 RVA: 0x000506E7 File Offset: 0x0004E8E7
		internal static ISceneView SceneView
		{
			get
			{
				return Render.sceneView;
			}
		}

		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x060013C3 RID: 5059 RVA: 0x000506EE File Offset: 0x0004E8EE
		internal static IRenderContext RenderContext
		{
			get
			{
				return Render.renderContext;
			}
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060013C4 RID: 5060 RVA: 0x000506F5 File Offset: 0x0004E8F5
		public static SceneLayerType Layer
		{
			get
			{
				return Render._layer;
			}
		}

		// Token: 0x170002E6 RID: 742
		// (set) Token: 0x060013C5 RID: 5061 RVA: 0x000506FC File Offset: 0x0004E8FC
		internal static ZBufferMode ZBufferMode
		{
			set
			{
				if (Render._zBufferMode != null && Render._zBufferMode.Value == value)
				{
					return;
				}
				Render.AssertRenderBlock();
				Render._zBufferMode = new ZBufferMode?(value);
				SboxRender.SetZBufferMode(value);
			}
		}

		// Token: 0x170002E7 RID: 743
		// (set) Token: 0x060013C6 RID: 5062 RVA: 0x0005072E File Offset: 0x0004E92E
		public static BlendMode BlendMode
		{
			set
			{
				if (Render._blendMode != null && Render._blendMode.Value == value)
				{
					return;
				}
				Render.AssertRenderBlock();
				Render._blendMode = new BlendMode?(value);
				SboxRender.SetBlendMode(value);
			}
		}

		// Token: 0x170002E8 RID: 744
		// (set) Token: 0x060013C7 RID: 5063 RVA: 0x00050760 File Offset: 0x0004E960
		public static CullMode CullMode
		{
			set
			{
				Render.AssertRenderBlock();
				SboxRender.SetCullMode(value);
			}
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x00050770 File Offset: 0x0004E970
		internal static void RenderingBlockOpen(ISceneView view, IRenderContext context, ISceneLayer layer)
		{
			Render.sceneLayer = layer;
			Render.sceneView = view;
			Render.renderContext = context;
			Render._layer = Render.sceneLayer.LayerEnum;
			Render.attributes = context.GetAttributesPtrForModify();
			Render.Viewport = Render.sceneView.GetMainViewport().Rect;
			Render._zBufferMode = null;
			Render._blendMode = null;
			if (Render._buffer == null)
			{
				Render._buffer = new VertexBuffer();
			}
			if (Render._combos == null)
			{
				Render._combos = new Dictionary<int, byte>();
			}
			if (Render.Layer == SceneLayerType.Unknown)
			{
				GlobalGameNamespace.Log.Warning(FormattableStringFactory.Create("Unenummed Scene Layer Type: {0}", new object[] { Render.sceneLayer.GetDebugName() }));
			}
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x00050827 File Offset: 0x0004EA27
		internal static void RenderingBlockClose()
		{
			Render.sceneView = default(ISceneView);
			Render.renderContext = default(IRenderContext);
			Render.attributes = default(CRenderAttributes);
			Render.Viewport = default(Rect);
			Render._combos.Clear();
		}

		// Token: 0x060013CA RID: 5066 RVA: 0x0005085F File Offset: 0x0004EA5F
		internal static void AssertRenderBlock()
		{
			if (!Render.renderContext.IsValid)
			{
				throw new Exception("Tried to render outside of rendering block");
			}
		}

		// Token: 0x060013CB RID: 5067 RVA: 0x00050878 File Offset: 0x0004EA78
		internal static void AssertOutOfRenderBlock()
		{
			if (Render.renderContext.IsValid)
			{
				throw new Exception("Tried to execute inside of rendering block");
			}
		}

		// Token: 0x060013CC RID: 5068 RVA: 0x00050891 File Offset: 0x0004EA91
		internal static void SetSamplerStatePS(int samplerIndex, FilterMode filter, TextureAddressMode wrapU = TextureAddressMode.Wrap, TextureAddressMode wrapV = TextureAddressMode.Wrap, TextureAddressMode wrapW = TextureAddressMode.Wrap, ComparisonMode comparison = ComparisonMode.Less)
		{
			Render.AssertRenderBlock();
			Render.renderContext.SetSamplerStatePS(samplerIndex, filter, wrapU, wrapV, wrapW, comparison);
		}

		/// <summary>
		/// Get the vertex buffer
		/// </summary>
		// Token: 0x060013CD RID: 5069 RVA: 0x000508AA File Offset: 0x0004EAAA
		public static VertexBuffer GetDynamicVB(bool indexed = false)
		{
			Render._buffer.Init(indexed);
			return Render._buffer;
		}

		// Token: 0x060013CE RID: 5070 RVA: 0x000508BC File Offset: 0x0004EABC
		public static void SetLighting(SceneObject obj)
		{
			if (!obj.IsValid())
			{
				return;
			}
			SboxRender.SetLighting(obj);
		}

		/// <summary>
		/// Grabs the current frame buffer and stores it in 'FrameBufferCopyTexture'
		/// </summary>
		// Token: 0x060013CF RID: 5071 RVA: 0x000508CD File Offset: 0x0004EACD
		public static void CopyFrameBuffer(bool bCopyToHDR = false)
		{
			Render.AssertRenderBlock();
			SboxRender.GrabFrameBuffer(bCopyToHDR);
		}

		/// <summary>
		/// Grabs the current depth buffer and stores it in 'DepthBufferCopyTexture'
		/// </summary>
		// Token: 0x060013D0 RID: 5072 RVA: 0x000508DA File Offset: 0x0004EADA
		public static void CopyDepthBuffer()
		{
			Render.AssertRenderBlock();
			SboxRender.GrabDepthBuffer();
		}

		/// <summary>
		/// Grabs the current viewport buffer and stores it in 'FrameBufferCopyTexture'
		/// </summary>
		// Token: 0x060013D1 RID: 5073 RVA: 0x000508E6 File Offset: 0x0004EAE6
		internal static void CopyViewportBuffer(bool bCopyToHDR = false)
		{
			Render.AssertRenderBlock();
			SboxRender.GrabViewportBuffer(bCopyToHDR);
		}

		// Token: 0x060013D2 RID: 5074 RVA: 0x000508F3 File Offset: 0x0004EAF3
		public static void SetRenderTarget(Texture texture)
		{
			SboxRender.SetRenderTarget(texture.native);
		}

		// Token: 0x060013D3 RID: 5075 RVA: 0x00050900 File Offset: 0x0004EB00
		internal static void SetRenderTarget(RenderTargetDesc rtDesc)
		{
			SboxRender.SetRenderTarget(rtDesc);
		}

		// Token: 0x060013D4 RID: 5076 RVA: 0x00050908 File Offset: 0x0004EB08
		public static void RestoreRenderTarget()
		{
			SboxRender.RestoreRenderTarget();
		}

		// Token: 0x060013D5 RID: 5077 RVA: 0x00050910 File Offset: 0x0004EB10
		public static IDisposable RenderTarget(Texture texture)
		{
			Render.SetRenderTarget(texture);
			return default(Render.RenderTargetScope);
		}

		// Token: 0x060013D6 RID: 5078 RVA: 0x00050931 File Offset: 0x0004EB31
		public static void SetViewport(int x, int y, int width, int height)
		{
			SboxRender.SetViewport(x, y, width, height);
		}

		// Token: 0x060013D7 RID: 5079 RVA: 0x0005093C File Offset: 0x0004EB3C
		public static void SetViewport(Rect viewport)
		{
			SboxRender.SetViewport((int)viewport.left, (int)viewport.top, (int)viewport.width, (int)viewport.height);
		}

		// Token: 0x060013D8 RID: 5080 RVA: 0x00050964 File Offset: 0x0004EB64
		public static void Clear(bool color = true, bool depth = true)
		{
			SboxRender.Clear(default(Vector4), color, depth);
		}

		// Token: 0x060013D9 RID: 5081 RVA: 0x00050981 File Offset: 0x0004EB81
		public static void Clear(Vector4 color, bool depth = true)
		{
			SboxRender.Clear(color, true, depth);
		}

		// Token: 0x170002E9 RID: 745
		// (get) Token: 0x060013DA RID: 5082 RVA: 0x0005098B File Offset: 0x0004EB8B
		// (set) Token: 0x060013DB RID: 5083 RVA: 0x00050992 File Offset: 0x0004EB92
		internal static Color Color
		{
			get
			{
				return Render._color;
			}
			set
			{
				Render._color = value;
			}
		}

		// Token: 0x060013DC RID: 5084 RVA: 0x0005099A File Offset: 0x0004EB9A
		internal unsafe static void DrawIndexed(Vertex* vertices, int vertCount, ushort* indices, int indexCount)
		{
			Render.AssertRenderBlock();
			if (Render.Material == null)
			{
				return;
			}
			SboxRender.DrawIndexed(Render.Material.native, (IntPtr)((void*)vertices), vertCount, (IntPtr)((void*)indices), indexCount);
		}

		// Token: 0x060013DD RID: 5085 RVA: 0x000509C6 File Offset: 0x0004EBC6
		internal unsafe static void Draw(Vertex* vertices, int vertCount)
		{
			Render.AssertRenderBlock();
			if (Render.Material == null)
			{
				return;
			}
			SboxRender.Draw(Render.Material.native, (IntPtr)((void*)vertices), vertCount);
		}

		// Token: 0x060013DE RID: 5086 RVA: 0x000509EB File Offset: 0x0004EBEB
		public static void DrawScreenQuad()
		{
			Render.AssertRenderBlock();
			if (Render.Material == null)
			{
				return;
			}
			SboxRender.DrawScreenQuad(Render.Material.native);
		}

		// Token: 0x060013DF RID: 5087 RVA: 0x00050A09 File Offset: 0x0004EC09
		internal static void DrawScreenQuadEx(CRenderAttributes renderAttributes, bool useFullUvSpace = false)
		{
			Render.AssertRenderBlock();
			if (Render.Material == null)
			{
				return;
			}
			SboxRender.DrawScreenQuadEx(Render.Material.native, useFullUvSpace, renderAttributes);
		}

		// Token: 0x060013E0 RID: 5088 RVA: 0x00050A2C File Offset: 0x0004EC2C
		internal static void DrawQuad(in Rect rect)
		{
			Rect rect2 = rect;
			Vector2 pos = rect2.Position;
			rect2 = rect;
			Vector2 size = rect2.Size;
			Vector3 vector = pos;
			Vector3 vector2 = new Vector2(pos.x + size.x, pos.y);
			Vector3 vector3 = pos + size;
			Vector3 vector4 = new Vector2(pos.x, pos.y + size.y);
			Render.DrawQuad(vector, vector2, vector3, vector4);
		}

		// Token: 0x060013E1 RID: 5089 RVA: 0x00050AC0 File Offset: 0x0004ECC0
		internal unsafe static void DrawQuad(in Vector3 a, in Vector3 b, in Vector3 c, in Vector3 d)
		{
			Color32 color32 = Render.Color.ToColor32(false);
			Vector3 vector = Vector3.Cross(b - a, c - a);
			Vector3 normal = vector.Normal;
			vector = a - b;
			vector = vector.Normal;
			Vector4 right = new Vector4(vector, 1f);
			IntPtr intPtr;
			Vertex vertex;
			checked
			{
				intPtr = stackalloc byte[unchecked((UIntPtr)4) * (UIntPtr)sizeof(Vertex)];
				vertex = new Vertex(a, Vector2.Zero, color32)
				{
					Normal = normal,
					Tangent = right
				};
				*intPtr = vertex;
			}
			ref Vertex ptr = intPtr + (IntPtr)sizeof(Vertex);
			vertex = new Vertex(b, new Vector2(1f, 0f), color32)
			{
				Normal = normal,
				Tangent = right
			};
			ptr = vertex;
			ref Vertex ptr2 = intPtr + (IntPtr)2 * (IntPtr)sizeof(Vertex);
			vertex = new Vertex(c, new Vector2(1f, 1f), color32)
			{
				Normal = normal,
				Tangent = right
			};
			ptr2 = vertex;
			ref Vertex ptr3 = intPtr + (IntPtr)3 * (IntPtr)sizeof(Vertex);
			vertex = new Vertex(d, new Vector2(0f, 1f), color32)
			{
				Normal = normal,
				Tangent = right
			};
			ptr3 = vertex;
			Vertex* vertices = intPtr;
			IntPtr intPtr2 = stackalloc byte[(UIntPtr)12];
			*intPtr2 = 0;
			*(intPtr2 + 2) = 1;
			*(intPtr2 + (IntPtr)2 * 2) = 2;
			*(intPtr2 + (IntPtr)3 * 2) = 0;
			*(intPtr2 + (IntPtr)4 * 2) = 2;
			*(intPtr2 + (IntPtr)5 * 2) = 3;
			ushort* indices = intPtr2;
			Render.DrawIndexed(vertices, 4, indices, 6);
		}

		// Token: 0x060013E2 RID: 5090 RVA: 0x00050C78 File Offset: 0x0004EE78
		internal unsafe static void DrawQuad(Rect rect, Margin margin)
		{
			Vector2 pos = rect.Position;
			Vector2 size = rect.Size;
			Color32 color32 = Render.Color.ToColor32(false);
			float t = pos.y - margin.top;
			float i = pos.x - margin.left;
			float r = pos.x + size.x + margin.right;
			float b = pos.y + size.y + margin.bottom;
			float uvx = 1f / (rect.width + margin.width);
			float uvy = 1f / (rect.height + margin.height);
			float uvl = uvx * margin.left * -1f;
			float uvt = uvy * margin.top * -1f;
			float uvr = 1f + uvx * margin.right;
			float uvb = 1f + uvy * margin.bottom;
			IntPtr intPtr;
			checked
			{
				intPtr = stackalloc byte[unchecked((UIntPtr)4) * (UIntPtr)sizeof(Vertex)];
				*intPtr = new Vertex(new Vector2(i, t), new Vector2(uvl, uvt), color32);
			}
			*(intPtr + (IntPtr)sizeof(Vertex)) = new Vertex(new Vector2(r, t), new Vector2(uvr, uvt), color32);
			*(intPtr + (IntPtr)2 * (IntPtr)sizeof(Vertex)) = new Vertex(new Vector2(r, b), new Vector2(uvr, uvb), color32);
			*(intPtr + (IntPtr)3 * (IntPtr)sizeof(Vertex)) = new Vertex(new Vector2(i, b), new Vector2(uvl, uvb), color32);
			Vertex* vertices = intPtr;
			IntPtr intPtr2 = stackalloc byte[(UIntPtr)12];
			*intPtr2 = 0;
			*(intPtr2 + 2) = 1;
			*(intPtr2 + (IntPtr)2 * 2) = 2;
			*(intPtr2 + (IntPtr)3 * 2) = 0;
			*(intPtr2 + (IntPtr)4 * 2) = 2;
			*(intPtr2 + (IntPtr)5 * 2) = 3;
			ushort* indices = intPtr2;
			Render.DrawIndexed(vertices, 4, indices, 6);
		}

		// Token: 0x060013E3 RID: 5091 RVA: 0x00050E68 File Offset: 0x0004F068
		public static void DrawScene(Texture colorTexture, Texture depthTexture, Vector2 size, SceneWorld world, Vector3 position, Angles rotation, float fov, Color ambientColor = default(Color), Color clearColor = default(Color), float zNear = 0.1f, float zFar = 1000f, bool ortho = false)
		{
			Render.AssertRenderBlock();
			if (colorTexture == null || colorTexture.native.IsNull)
			{
				throw new ArgumentException("Invalid color texture");
			}
			if (depthTexture == null || depthTexture.native.IsNull)
			{
				throw new ArgumentException("Invalid color texture");
			}
			if (colorTexture.ImageFormat != ImageFormat.RGBA8888 && colorTexture.ImageFormat != ImageFormat.RGBA16161616F && colorTexture.ImageFormat != ImageFormat.RGBA32323232F)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(59, 4);
				defaultInterpolatedStringHandler.AppendLiteral("Color texture uses image format ");
				defaultInterpolatedStringHandler.AppendFormatted<ImageFormat>(colorTexture.ImageFormat);
				defaultInterpolatedStringHandler.AppendLiteral(", needs to be either ");
				defaultInterpolatedStringHandler.AppendFormatted<ImageFormat>(ImageFormat.RGBA8888);
				defaultInterpolatedStringHandler.AppendLiteral(", ");
				defaultInterpolatedStringHandler.AppendFormatted<ImageFormat>(ImageFormat.RGBA16161616F);
				defaultInterpolatedStringHandler.AppendLiteral(" or ");
				defaultInterpolatedStringHandler.AppendFormatted<ImageFormat>(ImageFormat.RGBA32323232F);
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (depthTexture.ImageFormat != ImageFormat.D24S8)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(46, 2);
				defaultInterpolatedStringHandler.AppendLiteral("Depth texture uses image format ");
				defaultInterpolatedStringHandler.AppendFormatted<ImageFormat>(depthTexture.ImageFormat);
				defaultInterpolatedStringHandler.AppendLiteral(", needs to be ");
				defaultInterpolatedStringHandler.AppendFormatted<ImageFormat>(ImageFormat.D24S8);
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			if (colorTexture.MultisampleType != depthTexture.MultisampleType)
			{
				throw new ArgumentException("Color and depth textures have multisampling mismatch");
			}
			if (!colorTexture.desc.m_nFlags.HasFlag(TextureSpecificationFlags.TSPEC_RENDER_TARGET))
			{
				throw new ArgumentException("Color texture is not a render target");
			}
			if (!depthTexture.desc.m_nFlags.HasFlag(TextureSpecificationFlags.TSPEC_RENDER_TARGET))
			{
				throw new ArgumentException("Depth texture is not a render target");
			}
			if (size.x <= 0f || size.y <= 0f)
			{
				return;
			}
			Transform cam = new Transform(position, Rotation.From(rotation), fov);
			Vector4 viewport = new Vector4(0f, 0f, size.x, size.y);
			SboxRender.RenderScene(world, cam, viewport, ambientColor, clearColor, zNear, zFar, ortho, colorTexture.native, depthTexture.native);
		}

		// Token: 0x170002EA RID: 746
		// (set) Token: 0x060013E4 RID: 5092 RVA: 0x0005106B File Offset: 0x0004F26B
		public static Rect ScissorRect
		{
			set
			{
				Render.AssertRenderBlock();
				Render.renderContext.SetScissorRect(value);
			}
		}

		// Token: 0x0400049B RID: 1179
		[ThreadStatic]
		private static Dictionary<int, byte> _combos;

		// Token: 0x0400049C RID: 1180
		[ThreadStatic]
		private static ISceneLayer sceneLayer;

		// Token: 0x0400049D RID: 1181
		[ThreadStatic]
		private static ISceneView sceneView;

		// Token: 0x0400049E RID: 1182
		[ThreadStatic]
		private static IRenderContext renderContext;

		// Token: 0x0400049F RID: 1183
		[ThreadStatic]
		private static CRenderAttributes attributes;

		// Token: 0x040004A0 RID: 1184
		[ThreadStatic]
		public static Rect Viewport;

		// Token: 0x040004A1 RID: 1185
		[ThreadStatic]
		public static Material Material;

		// Token: 0x040004A2 RID: 1186
		[ThreadStatic]
		private static SceneLayerType _layer;

		// Token: 0x040004A3 RID: 1187
		[ThreadStatic]
		private static VertexBuffer _buffer;

		// Token: 0x040004A4 RID: 1188
		[ThreadStatic]
		private static ZBufferMode? _zBufferMode;

		// Token: 0x040004A5 RID: 1189
		[ThreadStatic]
		private static BlendMode? _blendMode;

		// Token: 0x040004A6 RID: 1190
		[ThreadStatic]
		private static Color _color;

		// Token: 0x02000261 RID: 609
		public class Compute
		{
			// Token: 0x170005AF RID: 1455
			// (get) Token: 0x06001E98 RID: 7832 RVA: 0x000763BB File Offset: 0x000745BB
			internal static CRenderAttributes RenderAttributes
			{
				get
				{
					Render.AssertRenderBlock();
					return Render.attributes;
				}
			}

			// Token: 0x06001E99 RID: 7833 RVA: 0x000763C8 File Offset: 0x000745C8
			public Render.Compute WithAttribute(string name, int value)
			{
				Render.Compute.RenderAttributes.SetIntValue(name, value);
				return this;
			}

			// Token: 0x06001E9A RID: 7834 RVA: 0x000763E8 File Offset: 0x000745E8
			public Render.Compute WithAttribute(string name, bool value)
			{
				Render.Compute.RenderAttributes.SetBoolValue(name, value);
				return this;
			}

			// Token: 0x06001E9B RID: 7835 RVA: 0x00076408 File Offset: 0x00074608
			public Render.Compute WithAttribute(string name, string value)
			{
				Render.Compute.RenderAttributes.SetStringValue(name, value);
				return this;
			}

			// Token: 0x06001E9C RID: 7836 RVA: 0x00076428 File Offset: 0x00074628
			public Render.Compute WithAttribute(string name, float value)
			{
				Render.Compute.RenderAttributes.SetFloatValue(name, value);
				return this;
			}

			// Token: 0x06001E9D RID: 7837 RVA: 0x00076445 File Offset: 0x00074645
			public Render.Compute WithAttribute(string name, Texture value, int mipLevel = -1)
			{
				Render.attributes.SetTextureValue(name, value.native, mipLevel);
				return this;
			}

			// Token: 0x06001E9E RID: 7838 RVA: 0x0007645C File Offset: 0x0007465C
			public Render.Compute WithAttribute(string name, Vector2 value)
			{
				Render.Compute.RenderAttributes.SetVector2DValue(name, value);
				return this;
			}

			// Token: 0x06001E9F RID: 7839 RVA: 0x0007647C File Offset: 0x0007467C
			public Render.Compute WithAttribute(string name, Vector3 value)
			{
				Render.Compute.RenderAttributes.SetVectorValue(name, value);
				return this;
			}

			// Token: 0x06001EA0 RID: 7840 RVA: 0x0007649C File Offset: 0x0007469C
			public Render.Compute WithAttribute(string name, Vector4 value)
			{
				Render.Compute.RenderAttributes.SetVector4DValue(name, value);
				return this;
			}

			// Token: 0x06001EA1 RID: 7841 RVA: 0x000764BC File Offset: 0x000746BC
			public Render.Compute WithAttribute(string name, Matrix value)
			{
				Render.Compute.RenderAttributes.SetVMatrixValue(name, value);
				return this;
			}

			// Token: 0x06001EA2 RID: 7842 RVA: 0x000764DC File Offset: 0x000746DC
			public Render.Compute WithAttribute(string name, ConstantBuffer value, uint view = 0U)
			{
				Render.Compute.RenderAttributes.SetConstantBufferValue(name, value.bufferHandle, view);
				return this;
			}

			// Token: 0x06001EA3 RID: 7843 RVA: 0x00076500 File Offset: 0x00074700
			public Render.Compute WithCombo(string name, byte value)
			{
				Render.Compute.RenderAttributes.SetComboValue(name, value);
				return this;
			}

			// Token: 0x06001EA4 RID: 7844 RVA: 0x00076520 File Offset: 0x00074720
			public void ClearAttributes()
			{
				Render.Compute.RenderAttributes.Clear(true, true);
			}

			// Token: 0x06001EA5 RID: 7845 RVA: 0x0007653C File Offset: 0x0007473C
			public static Render.Compute Using(string computeShader)
			{
				Render.Compute compute = new Render.Compute();
				string shaderName = "_computeShader_" + computeShader.ToString();
				compute.ComputeMaterial = Material.Create(shaderName, computeShader);
				return compute;
			}

			// Token: 0x06001EA6 RID: 7846 RVA: 0x0007656C File Offset: 0x0007476C
			public static Render.Compute Using(Material material)
			{
				return new Render.Compute
				{
					ComputeMaterial = material
				};
			}

			// Token: 0x06001EA7 RID: 7847 RVA: 0x0007657C File Offset: 0x0007477C
			public Render.Compute Dispatch()
			{
				IRenderContext context = this.GetOrAcquireRenderContext();
				if (this.ComputeMaterial == null)
				{
					throw new Exception("Material for compute shader is null!");
				}
				if (!context.IsValid)
				{
					throw new Exception("Unable to get a valid render context for " + this.ComputeMaterial.Name + ", try to dispatch the Compute operation inside a render block.");
				}
				if (!this.ComputeMaterial.native.IsValid)
				{
					throw new Exception("Material for compute shader " + this.ComputeMaterial.Name + " not valid!");
				}
				if (this.ThreadCountX < 1 || this.ThreadCountY < 1 || this.ThreadCountZ < 1)
				{
					throw new Exception("Compute shader " + this.ComputeMaterial.Name + " has invalid thread count! ( {ThreadCountX}, {ThreadCountY}, {ThreadCountZ} )");
				}
				GameGlue.DispatchComputeShader(this.ComputeMaterial.native, context, Render.attributes, this.ThreadCountX, this.ThreadCountY, this.ThreadCountZ);
				return this;
			}

			// Token: 0x06001EA8 RID: 7848 RVA: 0x00076668 File Offset: 0x00074868
			internal IRenderContext GetOrAcquireRenderContext()
			{
				if (Render.renderContext.IsValid)
				{
					return Render.renderContext;
				}
				return default(IRenderContext);
			}

			// Token: 0x06001EA9 RID: 7849 RVA: 0x00076690 File Offset: 0x00074890
			public Render.Compute ThreadCount(int threadCountX = 1, int threadCountY = 1, int threadCountZ = 1)
			{
				this.ThreadCountX = threadCountX;
				this.ThreadCountY = threadCountY;
				this.ThreadCountZ = threadCountZ;
				return this;
			}

			// Token: 0x0400121E RID: 4638
			internal Material ComputeMaterial;

			// Token: 0x0400121F RID: 4639
			internal int ThreadCountX = 1;

			// Token: 0x04001220 RID: 4640
			internal int ThreadCountY = 1;

			// Token: 0x04001221 RID: 4641
			internal int ThreadCountZ = 1;
		}

		// Token: 0x02000262 RID: 610
		internal struct RenderTargetScope : IDisposable
		{
			// Token: 0x06001EAB RID: 7851 RVA: 0x000766C5 File Offset: 0x000748C5
			public void Dispose()
			{
				Render.RestoreRenderTarget();
			}
		}

		// Token: 0x02000263 RID: 611
		public static class UI
		{
			// Token: 0x06001EAC RID: 7852 RVA: 0x000766CC File Offset: 0x000748CC
			public static void Box(Rect rect, Color color, Vector4 corners = default(Vector4), BlendMode blendMode = BlendMode.AlphaBlend)
			{
				string name = "BoxPosition";
				Vector2 vector = new Vector2(rect.left, rect.top);
				Render.Set(name, vector);
				string name2 = "BoxSize";
				vector = new Vector2(rect.width, rect.height);
				Render.Set(name2, vector);
				Render.Set("BorderRadius", corners);
				Render.SetCombo("D_BORDER", 0);
				Render.SetCombo("D_BORDER_IMAGE", 0);
				Render.SetCombo("D_BACKGROUND_IMAGE", 0);
				Render.Material = Materials.Box;
				Render.BlendMode = blendMode;
				Render.Color = color;
				Render.DrawQuad(rect);
			}

			// Token: 0x06001EAD RID: 7853 RVA: 0x00076764 File Offset: 0x00074964
			public static void BoxWithBorder(Rect rect, Color color, float borderSize, Color borderColor, Vector4 corners = default(Vector4), BlendMode blendMode = BlendMode.AlphaBlend)
			{
				string name = "BoxPosition";
				Vector2 vector = new Vector2(rect.left, rect.top);
				Render.Set(name, vector);
				string name2 = "BoxSize";
				vector = new Vector2(rect.width, rect.height);
				Render.Set(name2, vector);
				Render.Set("BorderRadius", corners);
				Render.SetCombo("D_BORDER", 1);
				Render.SetCombo("D_BORDER_IMAGE", 0);
				Render.SetCombo("D_BACKGROUND_IMAGE", 0);
				string name3 = "BorderSize";
				Vector4 vector2 = new Vector4(borderSize);
				Render.Set(name3, vector2);
				string name4 = "BorderColorL";
				vector2 = borderColor;
				Render.Set(name4, vector2);
				string name5 = "BorderColorT";
				vector2 = borderColor;
				Render.Set(name5, vector2);
				string name6 = "BorderColorR";
				vector2 = borderColor;
				Render.Set(name6, vector2);
				string name7 = "BorderColorB";
				vector2 = borderColor;
				Render.Set(name7, vector2);
				Render.Material = Materials.Box;
				Render.BlendMode = blendMode;
				Render.Color = color;
				Render.DrawQuad(rect);
			}

			/// <summary>
			/// Draw text, stretched to fit inside the rect
			/// </summary>
			// Token: 0x06001EAE RID: 7854 RVA: 0x00076860 File Offset: 0x00074A60
			public static void TextStretched(Rect rect, Color color, string text, string font, float size, BlendMode blendMode = BlendMode.AlphaBlend, float? wrapWidth = null, int fontWeight = 400)
			{
				TextManager.TextBlock block = TextManager.Get(text, color, font, size, wrapWidth, fontWeight);
				block.MakeReady();
				string name = "Texture";
				Texture texture = block.Texture;
				int num = -1;
				Render.Set(name, texture, num);
				string name2 = "TextColor";
				Vector4 vector = color;
				Render.Set(name2, vector);
				Render.Material = Materials.Text;
				Render.BlendMode = blendMode;
				Render.Color = color;
				Render.DrawQuad(rect);
			}

			/// <summary>
			/// Draw text
			/// </summary>
			// Token: 0x06001EAF RID: 7855 RVA: 0x000768C8 File Offset: 0x00074AC8
			public static void Text(Vector3 position, Color color, string text, string font, float size, BlendMode blendMode = BlendMode.AlphaBlend, float? wrapWidth = null, int fontWeight = 400)
			{
				TextManager.TextBlock block = TextManager.Get(text, color, font, size, wrapWidth, fontWeight);
				block.MakeReady();
				string name = "Texture";
				Texture texture = block.Texture;
				int num = -1;
				Render.Set(name, texture, num);
				string name2 = "TextColor";
				Vector4 vector = color;
				Render.Set(name2, vector);
				Render.Material = Materials.Text;
				Render.BlendMode = blendMode;
				Render.Color = color;
				Rect rect = default(Rect);
				rect.Position = position;
				rect.Size = block.Texture.Size;
				Render.DrawQuad(rect);
			}

			// Token: 0x06001EB0 RID: 7856 RVA: 0x00076958 File Offset: 0x00074B58
			public static void Clip(Rect? rect)
			{
				if (rect == null)
				{
					Render.SetCombo("D_SCISSOR", 0);
					return;
				}
				string name = "ScissorRect";
				Vector4 vector = rect.Value.ToVector4();
				Render.Set(name, vector);
				Render.SetCombo("D_SCISSOR", 1);
			}

			// Token: 0x06001EB1 RID: 7857 RVA: 0x000769A4 File Offset: 0x00074BA4
			public static IDisposable MatrixScope(Matrix? matrix)
			{
				if (matrix == null)
				{
					return null;
				}
				Render.UI.PushMatrix(new Matrix?(matrix.Value));
				return default(Render.UI.MatrixScopePopper);
			}

			// Token: 0x06001EB2 RID: 7858 RVA: 0x000769DC File Offset: 0x00074BDC
			internal static void PushMatrix(Matrix? matrix)
			{
				if (Render.UI.MatrixStack == null)
				{
					Render.UI.MatrixStack = new Stack<Matrix>();
				}
				Render.UI.MatrixStack.Push(matrix.Value);
				string name = "TransformMat";
				Matrix value = matrix.Value;
				Render.Set(name, value);
			}

			// Token: 0x06001EB3 RID: 7859 RVA: 0x00076A20 File Offset: 0x00074C20
			internal static void PopMatrix()
			{
				if (Render.UI.MatrixStack == null)
				{
					return;
				}
				Render.UI.MatrixStack.Pop();
				Matrix top;
				if (Render.UI.MatrixStack.TryPeek(out top))
				{
					Render.Set("TransformMat", top);
					return;
				}
				string name = "TransformMat";
				Matrix identity = Matrix.Identity;
				Render.Set(name, identity);
			}

			// Token: 0x04001222 RID: 4642
			[ThreadStatic]
			private static Stack<Matrix> MatrixStack;

			// Token: 0x02000306 RID: 774
			internal struct MatrixScopePopper : IDisposable
			{
				// Token: 0x06002101 RID: 8449 RVA: 0x0007AA2C File Offset: 0x00078C2C
				public void Dispose()
				{
					Render.UI.PopMatrix();
				}
			}
		}
	}
}
