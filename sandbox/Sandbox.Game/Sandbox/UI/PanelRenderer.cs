using System;
using System.Collections.Generic;
using Sandbox.Internal;

namespace Sandbox.UI
{
	// Token: 0x0200012D RID: 301
	internal sealed class PanelRenderer
	{
		// Token: 0x06001740 RID: 5952 RVA: 0x0005D78C File Offset: 0x0005B98C
		private void DrawBackdropBlur(Panel panel, Styles style, Color color)
		{
			if (style.BackdropFilterBlur == null)
			{
				return;
			}
			if (style.BackdropFilterBlur.Value.Value.AlmostEqual(0f, 0.01f))
			{
				return;
			}
			float amount = style.BackdropFilterBlur.Value.GetPixels(1f);
			Sandbox.Render.Material = Materials.Blur;
			Sandbox.Render.BlendMode = this.OverrideBlendMode;
			Sandbox.Render.Color = color;
			for (amount = amount.Clamp(0f, 500f); amount > 0f; amount -= 10f)
			{
				string name = "BlurScale";
				float num = MathF.Min(amount, 10f);
				Sandbox.Render.Set(name, num);
				Sandbox.Render.CopyViewportBuffer(false);
				Sandbox.Render.DrawQuad(panel.Box.Rect);
			}
		}

		// Token: 0x06001741 RID: 5953 RVA: 0x0005D858 File Offset: 0x0005BA58
		private void DrawBackdropFilters(Panel panel)
		{
			Styles style = panel.ComputedStyle;
			if (style == null)
			{
				return;
			}
			Length? length = style.BackdropFilterBrightness;
			bool flag;
			if (length == null)
			{
				length = style.BackdropFilterContrast;
				if (length == null)
				{
					length = style.BackdropFilterSaturate;
					if (length == null)
					{
						length = style.BackdropFilterSepia;
						if (length == null)
						{
							length = style.BackdropFilterInvert;
							if (length == null)
							{
								length = style.BackdropFilterHueRotate;
								flag = length != null;
								goto IL_72;
							}
						}
					}
				}
			}
			flag = true;
			IL_72:
			bool hasBackdropFilter = flag;
			if (!hasBackdropFilter)
			{
				length = style.BackdropFilterBlur;
				if (length == null)
				{
					return;
				}
			}
			Rect rect = panel.Box.Rect;
			float opacity = style.Opacity ?? 1f;
			float size = (rect.width + rect.height) * 0.5f;
			Color color = Color.White.WithAlpha(opacity);
			string name = "BoxSize";
			Vector2 size2 = panel.Box.Rect.Size;
			Sandbox.Render.Set(name, size2);
			this.SetBorderRadius(style, size);
			this.DrawBackdropBlur(panel, style, color);
			if (!hasBackdropFilter)
			{
				return;
			}
			string name2 = "Brightness";
			length = style.BackdropFilterBrightness;
			float num = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 1f);
			Sandbox.Render.Set(name2, num);
			string name3 = "Contrast";
			length = style.BackdropFilterContrast;
			num = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 1f);
			Sandbox.Render.Set(name3, num);
			string name4 = "Saturate";
			length = style.BackdropFilterSaturate;
			num = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 1f);
			Sandbox.Render.Set(name4, num);
			string name5 = "Sepia";
			length = style.BackdropFilterSepia;
			num = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 0f);
			Sandbox.Render.Set(name5, num);
			string name6 = "Invert";
			length = style.BackdropFilterInvert;
			num = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 0f);
			Sandbox.Render.Set(name6, num);
			string name7 = "HueRotate";
			length = style.BackdropFilterHueRotate;
			num = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 0f);
			Sandbox.Render.Set(name7, num);
			Sandbox.Render.Material = Materials.BackdropFilter;
			Sandbox.Render.BlendMode = this.OverrideBlendMode;
			Sandbox.Render.Color = color;
			Sandbox.Render.CopyViewportBuffer(false);
			Sandbox.Render.DrawQuad(rect);
		}

		// Token: 0x06001742 RID: 5954 RVA: 0x0005DB04 File Offset: 0x0005BD04
		public Rect StartClip(Rect rect)
		{
			Rect scissor = this.Scissor;
			this.Scissor.left = MathF.Max(rect.left, this.Scissor.left);
			this.Scissor.top = MathF.Max(rect.top, this.Scissor.top);
			this.Scissor.right = MathF.Min(rect.right, this.Scissor.right);
			this.Scissor.bottom = MathF.Min(rect.bottom, this.Scissor.bottom);
			string name = "ScissorRect";
			Vector4 vector = this.Scissor.ToVector4();
			Sandbox.Render.Set(name, vector);
			Sandbox.Render.SetCombo("D_SCISSOR", 1);
			return scissor;
		}

		// Token: 0x06001743 RID: 5955 RVA: 0x0005DBC0 File Offset: 0x0005BDC0
		public void EndClip(Rect rect)
		{
			if (rect.width == 0f && rect.height == 0f)
			{
				Sandbox.Render.SetCombo("D_SCISSOR", 0);
			}
			else
			{
				string name = "ScissorRect";
				Vector4 vector = rect.ToVector4();
				Sandbox.Render.Set(name, vector);
				Sandbox.Render.SetCombo("D_SCISSOR", 1);
			}
			this.Scissor = rect;
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06001744 RID: 5956 RVA: 0x0005DC1C File Offset: 0x0005BE1C
		// (set) Token: 0x06001745 RID: 5957 RVA: 0x0005DC24 File Offset: 0x0005BE24
		public Rect Screen { get; internal set; }

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06001746 RID: 5958 RVA: 0x0005DC2D File Offset: 0x0005BE2D
		// (set) Token: 0x06001747 RID: 5959 RVA: 0x0005DC34 File Offset: 0x0005BE34
		[ClientVar(null, Help = "Enable/disabling culling panel rendering based on overflow != visible. Turning this on or off should never affect visibility because the actual rendering should be culled using stencils. If it does, then the culling logic is wrong.")]
		public static bool ui_cull { get; set; } = true;

		// Token: 0x06001748 RID: 5960 RVA: 0x0005DC3C File Offset: 0x0005BE3C
		public void Render(RootPanel panel)
		{
			this.Screen = panel.PanelBounds;
			this.Scissor = this.Screen;
			this.MatrixStack.Clear();
			this.MatrixStack.Push(Matrix.Identity);
			this.Matrix = Matrix.Identity;
			this.RenderModeStack.Clear();
			this.RenderModeStack.Push("normal");
			this.RenderMode = null;
			this.SetRenderMode("normal");
			Stack<PanelRenderer.LayerEntry> layerStack = this.LayerStack;
			if (layerStack != null)
			{
				layerStack.Clear();
			}
			string name = "LayerMat";
			Matrix identity = Matrix.Identity;
			Sandbox.Render.Set(name, identity);
			this.EndClip(this.Scissor);
			this.Render(panel, new RenderState
			{
				X = this.Screen.left,
				Y = this.Screen.top,
				Width = this.Screen.width,
				Height = this.Screen.height
			});
		}

		/// <summary>
		/// Render a panel
		/// </summary>
		// Token: 0x06001749 RID: 5961 RVA: 0x0005DD44 File Offset: 0x0005BF44
		public void Render(Panel panel, RenderState state)
		{
			if (panel.ComputedStyle == null)
			{
				return;
			}
			if (!panel.IsVisible)
			{
				return;
			}
			if (PanelRenderer.ui_cull && !this.Scissor.IsInside(panel.Box.Rect, false))
			{
				return;
			}
			Styles computedStyle = panel.ComputedStyle;
			bool isClipping = ((computedStyle != null) ? computedStyle.Overflow : null).GetValueOrDefault() > OverflowMode.Visible;
			bool pushed = this.PushMatrix(panel);
			bool renderMode = this.PushRenderMode(panel);
			using (Performance.Scope("Panel Render"))
			{
				this.DrawBoxShadow(panel, ref state);
				panel.PushLayer(this);
				panel.DrawBackground(this, ref state);
				if (panel.HasContent)
				{
					try
					{
						panel.DrawContent(this, ref state);
					}
					catch (Exception e)
					{
						GlobalGameNamespace.Log.Error(e);
					}
				}
			}
			if (panel.HasChildren)
			{
				int childCount = panel.ChildrenCount;
				Rect prevClip = this.Scissor;
				if (isClipping)
				{
					this.StartClip(panel.Box.ClipRect);
				}
				if (childCount > 1)
				{
					using (Performance.Scope("Sort Children"))
					{
						panel._renderChildren.Sort((Panel x, Panel y) => x.GetRenderOrderIndex() - y.GetRenderOrderIndex());
					}
				}
				using (Performance.Scope("Render Children"))
				{
					for (int i = 0; i < childCount; i++)
					{
						this.Render(panel._renderChildren[i], state);
					}
				}
				if (isClipping)
				{
					this.EndClip(prevClip);
				}
			}
			panel.PopLayer(this);
			if (pushed)
			{
				this.PopMatrix();
			}
			if (renderMode)
			{
				this.PopRenderMode();
			}
		}

		// Token: 0x0600174A RID: 5962 RVA: 0x0005DF20 File Offset: 0x0005C120
		internal void PushLayer(Texture texture, Matrix mat)
		{
			if (this.LayerStack == null)
			{
				this.LayerStack = new Stack<PanelRenderer.LayerEntry>();
			}
			Sandbox.Render.SetRenderTarget(texture);
			Sandbox.Render.Set("LayerMat", mat);
			Sandbox.Render.Clear(true, true);
			this.LayerStack.Push(new PanelRenderer.LayerEntry
			{
				Texture = texture,
				Matrix = mat
			});
		}

		// Token: 0x0600174B RID: 5963 RVA: 0x0005DF80 File Offset: 0x0005C180
		internal void PopLayer()
		{
			this.LayerStack.Pop();
			PanelRenderer.LayerEntry top;
			if (this.LayerStack.TryPeek(out top))
			{
				Sandbox.Render.SetRenderTarget(top.Texture);
				Sandbox.Render.Set("LayerMat", top.Matrix);
				return;
			}
			Sandbox.Render.RestoreRenderTarget();
			string name = "LayerMat";
			Matrix identity = Matrix.Identity;
			Sandbox.Render.Set(name, identity);
		}

		// Token: 0x0600174C RID: 5964 RVA: 0x0005DFDC File Offset: 0x0005C1DC
		private void SetColor(string v, Color color, float opacity)
		{
			if (opacity < 1f)
			{
				color.a *= opacity;
			}
			Vector4 vector = color;
			Sandbox.Render.Set(v, vector);
		}

		// Token: 0x0600174D RID: 5965 RVA: 0x0005E010 File Offset: 0x0005C210
		private bool ShouldDrawBackground(Panel panel)
		{
			Styles style = panel.ComputedStyle;
			return style != null && (style.BackgroundColor != null || (style.BorderLeftColor != null && style.BorderLeftWidth != null) || (style.BorderTopColor != null && style.BorderTopWidth != null) || (style.BorderRightColor != null && style.BorderRightWidth != null) || (style.BorderBottomColor != null && style.BorderBottomWidth != null) || (style.BackgroundImage != null && style.BackgroundImage != Texture.Invalid));
		}

		// Token: 0x0600174E RID: 5966 RVA: 0x0005E0DC File Offset: 0x0005C2DC
		private void SetBorderRadius(Styles style, float size)
		{
			Length? length = style.BorderBottomRightRadius;
			float x = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			length = style.BorderTopRightRadius;
			float y = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			length = style.BorderBottomLeftRadius;
			float z = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			length = style.BorderTopLeftRadius;
			Vector4 borderRadius = new Vector4(x, y, z, (length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			Sandbox.Render.Set("BorderRadius", borderRadius);
		}

		// Token: 0x0600174F RID: 5967 RVA: 0x0005E198 File Offset: 0x0005C398
		internal void DrawBackgroundTexture(Panel panel, Texture texture, in RenderState state, Length defaultSize)
		{
			Styles style = panel.ComputedStyle;
			if (style == null)
			{
				return;
			}
			if (texture == Texture.Invalid)
			{
				texture = null;
			}
			Rect rect = panel.Box.Rect;
			float opacity = style.Opacity ?? 1f;
			Color color = style.BackgroundColor ?? Color.Transparent;
			color.a *= opacity;
			float size = (rect.width + rect.height) * 0.5f;
			Length? length = style.BorderLeftWidth;
			float x2 = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			length = style.BorderTopWidth;
			float y2 = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			length = style.BorderRightWidth;
			float z = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			length = style.BorderBottomWidth;
			Vector4 borderSize = new Vector4(x2, y2, z, (length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			string name = "BoxPosition";
			Vector2 vector = new Vector2(rect.left, rect.top);
			Sandbox.Render.Set(name, vector);
			string name2 = "BoxSize";
			vector = new Vector2(rect.width, rect.height);
			Sandbox.Render.Set(name2, vector);
			this.SetBorderRadius(style, size);
			if (borderSize.x == 0f && borderSize.y == 0f && borderSize.z == 0f && borderSize.w == 0f)
			{
				Sandbox.Render.SetCombo("D_BORDER", 0);
			}
			else
			{
				Sandbox.Render.SetCombo("D_BORDER", 1);
				Sandbox.Render.Set("BorderSize", borderSize);
				this.SetColor("BorderColorL", style.BorderLeftColor ?? Color.Black, opacity);
				this.SetColor("BorderColorT", style.BorderTopColor ?? Color.Black, opacity);
				this.SetColor("BorderColorR", style.BorderRightColor ?? Color.Black, opacity);
				this.SetColor("BorderColorB", style.BorderBottomColor ?? Color.Black, opacity);
			}
			if (style.BorderImageSource != null)
			{
				string name3 = "BorderImageTexture";
				Texture borderImageSource = style.BorderImageSource;
				int num = -1;
				Sandbox.Render.Set(name3, borderImageSource, num);
				string name4 = "BorderImageSlice";
				length = style.BorderImageWidthLeft;
				float x3 = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
				length = style.BorderImageWidthTop;
				float y3 = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
				length = style.BorderImageWidthRight;
				float z2 = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
				length = style.BorderImageWidthBottom;
				Vector4 vector2 = new Vector4(x3, y3, z2, (length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
				Sandbox.Render.Set(name4, vector2);
				string name5 = "D_BORDER_IMAGE";
				BorderImageRepeat? borderImageRepeat = style.BorderImageRepeat;
				BorderImageRepeat borderImageRepeat2 = BorderImageRepeat.Stretch;
				Sandbox.Render.SetCombo(name5, ((borderImageRepeat.GetValueOrDefault() == borderImageRepeat2) & (borderImageRepeat != null)) ? 2 : 1);
				string name6 = "D_BORDER_IMAGE_FILL";
				BorderImageFill? borderImageFill = style.BorderImageFill;
				BorderImageFill borderImageFill2 = BorderImageFill.Filled;
				Sandbox.Render.SetCombo(name6, ((borderImageFill.GetValueOrDefault() == borderImageFill2) & (borderImageFill != null)) ? 1 : 0);
			}
			else
			{
				Sandbox.Render.SetCombo("D_BORDER_IMAGE", 0);
			}
			if (texture != null)
			{
				float x = 0f;
				float y = 0f;
				float w = (float)texture.Width;
				float h = (float)texture.Height;
				length = style.BackgroundSizeX;
				Length sizeX = length ?? defaultSize;
				float aspect = h / w;
				bool cover = false;
				if (sizeX.Unit == LengthUnit.Cover)
				{
					w = rect.width;
					h = w * aspect;
					if (h < rect.height)
					{
						h = rect.height;
						w = h / aspect;
					}
					cover = true;
				}
				else if (sizeX.Unit == LengthUnit.Contain)
				{
					w = rect.width;
					h = w * aspect;
					if (h > rect.height)
					{
						h = rect.height;
						w = h / aspect;
					}
				}
				else if (sizeX.Unit != LengthUnit.Auto && (sizeX.Unit == LengthUnit.Pixels || sizeX.Unit == LengthUnit.Percentage))
				{
					length = style.BackgroundSizeX;
					w = ((length != null) ? length.GetValueOrDefault().GetPixels(rect.width) : w);
					length = style.BackgroundSizeY;
					h = ((length != null) ? length.GetValueOrDefault().GetPixels(rect.height) : h);
					length = style.BackgroundSizeX;
					if (length != null && length.GetValueOrDefault().Unit == LengthUnit.Pixels)
					{
						w *= panel.ScaleToScreen;
					}
					length = style.BackgroundSizeY;
					if (length != null && length.GetValueOrDefault().Unit == LengthUnit.Pixels)
					{
						h *= panel.ScaleToScreen;
					}
				}
				length = style.BackgroundPositionX;
				x = ((length != null) ? length.GetValueOrDefault().GetPixels(rect.width, w) : x);
				length = style.BackgroundPositionY;
				y = ((length != null) ? length.GetValueOrDefault().GetPixels(rect.height, h) : y);
				string name7 = "Texture";
				Texture value = texture;
				int num = -1;
				Sandbox.Render.Set(name7, value, num);
				string name8 = "BgPos";
				Vector4 vector2 = new Vector4(x, y, w, h);
				Sandbox.Render.Set(name8, vector2);
				string name9 = "BgAngle";
				length = style.BackgroundAngle;
				float num2 = ((length != null) ? length.GetValueOrDefault().GetPixels(1f) : 0f);
				Sandbox.Render.Set(name9, num2);
				Sandbox.Render.SetCombo("D_BACKGROUND_IMAGE", 1);
				Sandbox.Render.SetCombo("D_TEXTURE_FILTERING", (byte)style.ImageRendering.GetValueOrDefault());
				Sandbox.Render.SetCombo("D_BACKGROUND_REPEAT", (byte)(cover ? BackgroundRepeat.Clamp : style.BackgroundRepeat.GetValueOrDefault()));
				this.SetColor("BgTint", style.BackgroundTint ?? Color.White, opacity);
				string name10 = "BgRepeat";
				num = (int)style.BackgroundRepeat.GetValueOrDefault();
				Sandbox.Render.Set(name10, num);
			}
			else
			{
				Sandbox.Render.SetCombo("D_BACKGROUND_IMAGE", 0);
			}
			Sandbox.Render.Material = Materials.Box;
			Sandbox.Render.BlendMode = this.OverrideBlendMode;
			Sandbox.Render.Color = color;
			Sandbox.Render.DrawQuad(rect);
		}

		// Token: 0x06001750 RID: 5968 RVA: 0x0005E8A0 File Offset: 0x0005CAA0
		public void DrawBoxShadow(Panel panel, ref RenderState state, Shadow shadow)
		{
			if (shadow.Color.a <= 0f)
			{
				return;
			}
			Styles style = panel.ComputedStyle;
			Rect rect = panel.Box.Rect;
			float size = (rect.width + rect.height) * 0.5f;
			Vector2 shadowOffset = new Vector2(shadow.OffsetX, shadow.OffsetY);
			Rect shadowrect = rect + shadowOffset;
			float blur = shadow.Blur;
			float spread = shadow.Spread;
			shadowrect = shadowrect.Grow(spread, spread, spread, spread);
			float opacity = style.Opacity ?? 1f;
			Color color = shadow.Color;
			color.a *= opacity;
			string name = "BoxPosition";
			Vector2 vector = new Vector2(shadowrect.left, shadowrect.top);
			Sandbox.Render.Set(name, vector);
			string name2 = "BoxSize";
			vector = new Vector2(shadowrect.width, shadowrect.height);
			Sandbox.Render.Set(name2, vector);
			string name3 = "BorderRadius";
			Length? length = style.BorderBottomRightRadius;
			float x = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			length = style.BorderTopRightRadius;
			float y = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			length = style.BorderBottomLeftRadius;
			float z = ((length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			length = style.BorderTopLeftRadius;
			Vector4 vector2 = new Vector4(x, y, z, (length != null) ? length.GetValueOrDefault().GetPixels(size) : 0f);
			Sandbox.Render.Set(name3, vector2);
			Sandbox.Render.Set("ShadowWidth", blur);
			Sandbox.Render.Material = Materials.BoxShadow;
			Sandbox.Render.BlendMode = this.OverrideBlendMode;
			Sandbox.Render.Color = color;
			Sandbox.Render.DrawQuad(shadowrect, new Margin(blur * 0.5f));
		}

		// Token: 0x06001751 RID: 5969 RVA: 0x0005EA94 File Offset: 0x0005CC94
		internal void DrawScene(Panel panel, Texture colorTexture, Texture depthTexture, SceneWorld world, Vector3 position, Angles angles, float fieldOfView, Color ambientColor, Color clearColor, float zNear, float zFar, Rect rect, bool ortho)
		{
			if (panel.ComputedStyle == null)
			{
				return;
			}
			Sandbox.Render.DrawScene(colorTexture, depthTexture, rect.Size, world, position, angles, fieldOfView, ambientColor, clearColor, zNear, zFar, ortho);
		}

		// Token: 0x06001752 RID: 5970 RVA: 0x0005EACA File Offset: 0x0005CCCA
		public void DrawBackground(Panel panel, in RenderState state)
		{
			this.DrawBackdropFilters(panel);
			if (!this.ShouldDrawBackground(panel))
			{
				return;
			}
			Styles computedStyle = panel.ComputedStyle;
			this.DrawBackgroundTexture(panel, (computedStyle != null) ? computedStyle.BackgroundImage : null, state, Length.Auto);
		}

		/// <summary>
		/// Should draw the box shadow, if your renderer supports this
		/// </summary>
		// Token: 0x06001753 RID: 5971 RVA: 0x0005EAFC File Offset: 0x0005CCFC
		public void DrawBoxShadow(Panel panel, ref RenderState state)
		{
			foreach (Shadow shadow in panel.ComputedStyle.BoxShadow)
			{
				this.DrawBoxShadow(panel, ref state, shadow);
			}
		}

		// Token: 0x06001754 RID: 5972 RVA: 0x0005EB58 File Offset: 0x0005CD58
		public void DrawRect(Rect rect, Color color)
		{
			this.DrawRect(rect, Texture.White, color);
		}

		// Token: 0x06001755 RID: 5973 RVA: 0x0005EB68 File Offset: 0x0005CD68
		public void DrawRect(Rect rect, Texture texture, Color color)
		{
			string name = "BoxPosition";
			Vector2 vector = new Vector2(rect.left, rect.top);
			Sandbox.Render.Set(name, vector);
			string name2 = "BoxSize";
			vector = new Vector2(rect.width, rect.height);
			Sandbox.Render.Set(name2, vector);
			string name3 = "BorderRadius";
			Vector4 vector2 = default(Vector4);
			Sandbox.Render.Set(name3, vector2);
			string name4 = "BorderSize";
			vector2 = default(Vector4);
			Sandbox.Render.Set(name4, vector2);
			string name5 = "Texture";
			int num = -1;
			Sandbox.Render.Set(name5, texture, num);
			Sandbox.Render.SetCombo("D_BACKGROUND_IMAGE", 1);
			string name6 = "BgPos";
			vector2 = new Vector4(0f, 0f, rect.width, rect.height);
			Sandbox.Render.Set(name6, vector2);
			Sandbox.Render.Material = Materials.Box;
			Sandbox.Render.BlendMode = this.OverrideBlendMode;
			Sandbox.Render.Color = color;
			Sandbox.Render.DrawQuad(rect);
		}

		// Token: 0x06001756 RID: 5974 RVA: 0x0005EC3F File Offset: 0x0005CE3F
		internal void PopMatrix()
		{
			this.MatrixStack.Pop();
			this.Matrix = this.MatrixStack.Peek();
			this.SetMatrix(this.Matrix);
		}

		// Token: 0x06001757 RID: 5975 RVA: 0x0005EC6A File Offset: 0x0005CE6A
		internal void PushMatrix(Matrix mat)
		{
			this.MatrixStack.Push(mat);
			this.SetMatrix(mat);
		}

		// Token: 0x06001758 RID: 5976 RVA: 0x0005EC7F File Offset: 0x0005CE7F
		private void SetMatrix(Matrix mat)
		{
			this.Matrix = mat;
			Sandbox.Render.Set("TransformMat", mat);
		}

		// Token: 0x06001759 RID: 5977 RVA: 0x0005EC94 File Offset: 0x0005CE94
		private bool PushMatrix(Panel panel)
		{
			Styles style = panel.ComputedStyle;
			Panel parent = panel.Parent;
			Matrix? matrix = ((parent != null) ? parent.GlobalMatrix : null);
			panel.GlobalMatrix = ((matrix != null) ? matrix : null);
			panel.LocalMatrix = null;
			if (style.Transform == null)
			{
				return false;
			}
			Vector3 origin = panel.Box.Rect.Position;
			if (style.TransformOriginX != null)
			{
				origin.x += style.TransformOriginX.Value.GetPixels(panel.Box.Rect.width);
			}
			else
			{
				origin.x += panel.Box.Rect.width * 0.5f;
			}
			if (style.TransformOriginY != null)
			{
				origin.y += style.TransformOriginY.Value.GetPixels(panel.Box.Rect.height);
			}
			else
			{
				origin.y += panel.Box.Rect.height * 0.5f;
			}
			this.Matrix *= Matrix.CreateTranslation(-origin);
			this.Matrix *= style.Transform.Value.Transform;
			this.Matrix *= Matrix.CreateTranslation(origin);
			Matrix mi = this.Matrix.Inverted;
			if (panel.GlobalMatrix != null)
			{
				panel.LocalMatrix = new Matrix?(panel.GlobalMatrix.Value.Inverted * mi);
			}
			else
			{
				panel.LocalMatrix = new Matrix?(mi);
			}
			panel.GlobalMatrix = new Matrix?(mi);
			this.PushMatrix(this.Matrix);
			return true;
		}

		// Token: 0x0600175A RID: 5978 RVA: 0x0005EEB5 File Offset: 0x0005D0B5
		private void PopRenderMode()
		{
			this.RenderModeStack.Pop();
			this.SetRenderMode(this.RenderModeStack.Peek());
		}

		// Token: 0x0600175B RID: 5979 RVA: 0x0005EED4 File Offset: 0x0005D0D4
		private bool PushRenderMode(Panel panel)
		{
			Styles style = panel.ComputedStyle;
			if (style.MixBlendMode == null)
			{
				return false;
			}
			if (this.RenderMode == style.MixBlendMode)
			{
				return false;
			}
			this.RenderModeStack.Push(this.RenderMode);
			this.SetRenderMode(style.MixBlendMode);
			return true;
		}

		// Token: 0x0600175C RID: 5980 RVA: 0x0005EF25 File Offset: 0x0005D125
		private void SetRenderMode(string renderMode)
		{
			this.RenderMode = renderMode;
			this.OverrideBlendMode = BlendMode.AlphaBlend;
			if (renderMode == "lighten")
			{
				this.OverrideBlendMode = BlendMode.Additive;
			}
			if (renderMode == "multiply")
			{
				this.OverrideBlendMode = BlendMode.Multiply;
			}
		}

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x0600175D RID: 5981 RVA: 0x0005EF5D File Offset: 0x0005D15D
		// (set) Token: 0x0600175E RID: 5982 RVA: 0x0005EF64 File Offset: 0x0005D164
		[ClientVar(null, Help = "Enable drawing text")]
		public static bool ui_drawtext { get; set; } = true;

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x0600175F RID: 5983 RVA: 0x0005EF6C File Offset: 0x0005D16C
		// (set) Token: 0x06001760 RID: 5984 RVA: 0x0005EF73 File Offset: 0x0005D173
		[ClientVar(null, Help = "Enable drawing text shadows")]
		public static bool ui_drawtextshadow { get; set; } = true;

		// Token: 0x06001761 RID: 5985 RVA: 0x0005EF7C File Offset: 0x0005D17C
		internal void DrawTextBlock(Texture texture, Rect rect, Styles style)
		{
			if (!PanelRenderer.ui_drawtext)
			{
				return;
			}
			float opacity = style.Opacity ?? 1f;
			Color color = Color.White;
			color.a *= opacity;
			if (color.a <= 0f)
			{
				return;
			}
			string name = "Texture";
			int num = -1;
			Sandbox.Render.Set(name, texture, num);
			string name2 = "TextColor";
			Color color2 = style.FontColor ?? Color.Black;
			Vector4 vector = color2;
			Sandbox.Render.Set(name2, vector);
			if (style.TextBackgroundImage != null)
			{
				Sandbox.Render.SetCombo("D_TEXT_BACKGROUND_IMAGE", true);
				string name3 = "TextBackgroundImage";
				Texture textBackgroundImage = style.TextBackgroundImage;
				num = -1;
				Sandbox.Render.Set(name3, textBackgroundImage, num);
				string name4 = "TextBackgroundAngle";
				Length? length;
				float num2 = ((style.TextBackgroundAngle != null) ? length.GetValueOrDefault().GetPixels(1f) : 0f);
				Sandbox.Render.Set(name4, num2);
			}
			else
			{
				Sandbox.Render.SetCombo("D_TEXT_BACKGROUND_IMAGE", false);
			}
			Sandbox.Render.Material = Materials.Text;
			Sandbox.Render.BlendMode = this.OverrideBlendMode;
			Sandbox.Render.Color = color;
			Rect rect2 = rect.Floor();
			Sandbox.Render.DrawQuad(rect2);
		}

		// Token: 0x040005DB RID: 1499
		public Rect Scissor;

		// Token: 0x040005DE RID: 1502
		private Stack<PanelRenderer.LayerEntry> LayerStack;

		// Token: 0x040005DF RID: 1503
		internal Matrix Matrix;

		// Token: 0x040005E0 RID: 1504
		private Stack<Matrix> MatrixStack = new Stack<Matrix>();

		// Token: 0x040005E1 RID: 1505
		private string RenderMode;

		// Token: 0x040005E2 RID: 1506
		private Stack<string> RenderModeStack = new Stack<string>();

		// Token: 0x040005E3 RID: 1507
		private BlendMode OverrideBlendMode = BlendMode.AlphaBlend;

		// Token: 0x0200028C RID: 652
		private struct LayerEntry
		{
			// Token: 0x040012BE RID: 4798
			public Texture Texture;

			// Token: 0x040012BF RID: 4799
			public Matrix Matrix;
		}
	}
}
