using System;

namespace Sandbox
{
	// Token: 0x020000EA RID: 234
	public class StandardPostProcess : BasePostProcess
	{
		// Token: 0x060013AC RID: 5036 RVA: 0x0004FC64 File Offset: 0x0004DE64
		public StandardPostProcess()
		{
			Host.AssertClient(".ctor");
			this.PostProcessPass1 = Material.Load("materials/postprocess/standard_pass1.vmat");
			this.PostProcessPass2 = Material.Load("materials/postprocess/standard_pass2.vmat");
			this.PostProcessDof = Material.Load("materials/postprocess/standard_dof.vmat");
			this.PostProcessPass3 = Material.Load("materials/postprocess/standard_pass3.vmat");
			this.LastScreenSize = Screen.Size;
			this.DofHalfResSize = this.LastScreenSize * 0.5f;
			this.DofCocLut = Texture.CreateRenderTarget().WithFormat(ImageFormat.R16F).WithSize(this.LastScreenSize)
				.Create("Dof_CocLut", true, default(ReadOnlySpan<byte>), 0);
			this.DofCocLutBlur = Texture.CreateRenderTarget().WithFormat(ImageFormat.R16F).WithSize(this.LastScreenSize)
				.Create("Dof_CocLutBlur", true, default(ReadOnlySpan<byte>), 0);
			this.DofDownscale2 = Texture.CreateRenderTarget().WithFormat(ImageFormat.RGBA16161616F).WithSize(this.DofHalfResSize)
				.Create("Dof_Half2", true, default(ReadOnlySpan<byte>), 0);
			this.DofDownscale = Texture.CreateRenderTarget().WithFormat(ImageFormat.RGBA16161616F).WithSize(this.DofHalfResSize)
				.Create("Dof_Half", true, default(ReadOnlySpan<byte>), 0);
			this.DofUpscale = Texture.CreateRenderTarget().WithFormat(ImageFormat.RGBA16161616F).WithSize(this.LastScreenSize)
				.Create("Dof_Full", true, default(ReadOnlySpan<byte>), 0);
			this.Falloff.parent = this;
			this.Pixelate.parent = this;
			this.LensDistortion.parent = this;
			this.PaniniProjection.parent = this;
			this.ChromaticAberration.parent = this;
			this.MotionBlur.parent = this;
			this.Sharpen.parent = this;
			this.Blur.parent = this;
			this.DepthOfField.parent = this;
			this.ColorOverlay.parent = this;
			this.Saturate.parent = this;
			this.FilmGrain.parent = this;
			this.Vignette.parent = this;
			Event.Register(this);
			Event.Register(this.DepthOfField);
		}

		/// <summary>
		/// We use this to monitor recreation of render targets on resolution changes. We can't do this in
		/// post processing because we cannot create textures in the render block
		/// </summary>
		// Token: 0x060013AD RID: 5037 RVA: 0x0004FF48 File Offset: 0x0004E148
		[Event.Screen.SizeChangedAttribute]
		private void OnScreenSizeChanged()
		{
			this.LastScreenSize = Screen.Size;
			this.DofHalfResSize = this.LastScreenSize * 0.5f;
			this.DofCocLut = Texture.CreateRenderTarget().WithFormat(ImageFormat.R16F).WithSize(this.LastScreenSize)
				.Create("Dof_CocLut", true, default(ReadOnlySpan<byte>), 0);
			this.DofCocLutBlur = Texture.CreateRenderTarget().WithFormat(ImageFormat.R16F).WithSize(this.LastScreenSize)
				.Create("Dof_CocLutBlur", true, default(ReadOnlySpan<byte>), 0);
			this.DofDownscale2 = Texture.CreateRenderTarget().WithFormat(ImageFormat.RGBA16161616F).WithSize(this.DofHalfResSize)
				.Create("Dof_Half2", true, default(ReadOnlySpan<byte>), 0);
			this.DofDownscale = Texture.CreateRenderTarget().WithFormat(ImageFormat.RGBA16161616F).WithSize(this.DofHalfResSize)
				.Create("Dof_Half", true, default(ReadOnlySpan<byte>), 0);
			this.DofUpscale = Texture.CreateRenderTarget().WithFormat(ImageFormat.RGBA16161616F).WithSize(this.LastScreenSize)
				.Create("Dof_Full", true, default(ReadOnlySpan<byte>), 0);
		}

		// Token: 0x170002DD RID: 733
		// (get) Token: 0x060013AE RID: 5038 RVA: 0x000500A0 File Offset: 0x0004E2A0
		private bool HasPass1
		{
			get
			{
				return this.PostProcessPass1 != null && (this.Pixelate.Enabled || this.LensDistortion.Enabled || this.PaniniProjection.Enabled || this.ChromaticAberration.Enabled || this.MotionBlur.Enabled || this.Sharpen.Enabled);
			}
		}

		// Token: 0x170002DE RID: 734
		// (get) Token: 0x060013AF RID: 5039 RVA: 0x00050105 File Offset: 0x0004E305
		private bool HasPass2
		{
			get
			{
				return this.PostProcessPass2 != null && this.Blur.Enabled;
			}
		}

		// Token: 0x170002DF RID: 735
		// (get) Token: 0x060013B0 RID: 5040 RVA: 0x0005011C File Offset: 0x0004E31C
		private bool HasDof
		{
			get
			{
				return this.PostProcessDof != null && this.DepthOfField.Enabled;
			}
		}

		// Token: 0x170002E0 RID: 736
		// (get) Token: 0x060013B1 RID: 5041 RVA: 0x00050133 File Offset: 0x0004E333
		private bool HasPass3
		{
			get
			{
				return this.PostProcessPass3 != null && (this.ColorOverlay.Enabled || this.Saturate.Enabled || this.FilmGrain.Enabled || this.Vignette.Enabled);
			}
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x00050174 File Offset: 0x0004E374
		public override void Render()
		{
			int passCount = (this.HasPass1 ? 1 : 0) + (this.HasPass2 ? 1 : 0) + (this.HasDof ? 1 : 0) + (this.HasPass3 ? 1 : 0);
			if (passCount == 0)
			{
				base.Passthrough();
				return;
			}
			passCount--;
			if (this.HasPass1)
			{
				Sandbox.Render.Material = this.PostProcessPass1;
				if (this.PaniniProjection.Enabled)
				{
					string name = "CameraFOV";
					float num = CurrentView.FieldOfView.DegreeToRadian();
					Sandbox.Render.Set(name, num);
				}
				base.RenderScreenQuad(false);
				if (passCount > 0)
				{
					base.NextPass();
					passCount--;
				}
			}
			if (this.HasPass2)
			{
				Sandbox.Render.Material = this.PostProcessPass2;
				base.RenderScreenQuad(false);
				if (passCount > 0)
				{
					base.NextPass();
					passCount--;
				}
			}
			if (this.HasDof)
			{
				Sandbox.Render.Material = this.PostProcessDof;
				base.SetCombo("D_DOF_PASS", 0);
				using (base.ScopedRenderTarget())
				{
					Sandbox.Render.SetViewport(0, 0, (int)this.DofHalfResSize.x, (int)this.DofHalfResSize.y);
					Sandbox.Render.SetRenderTarget(this.DofDownscale);
					base.RenderScreenQuad(false);
				}
				base.SetCombo("D_DOF_PASS", 1);
				string name2 = "ColorDownscaleBuffer";
				Texture dofDownscale = this.DofDownscale;
				int num2 = -1;
				base.Set(name2, dofDownscale, num2);
				using (base.ScopedRenderTarget())
				{
					Sandbox.Render.SetViewport(0, 0, (int)this.LastScreenSize.x, (int)this.LastScreenSize.y);
					Sandbox.Render.SetRenderTarget(this.DofCocLut);
					base.RenderScreenQuad(false);
				}
				string name3 = "CocLut";
				Texture dofCocLut = this.DofCocLut;
				num2 = -1;
				base.Set(name3, dofCocLut, num2);
				base.SetCombo("D_DOF_PASS", 2);
				using (base.ScopedRenderTarget())
				{
					Sandbox.Render.SetViewport(0, 0, (int)this.LastScreenSize.x, (int)this.LastScreenSize.y);
					Sandbox.Render.SetRenderTarget(this.DofCocLutBlur);
					base.RenderScreenQuad(true);
				}
				string name4 = "CocLut";
				Texture dofCocLutBlur = this.DofCocLutBlur;
				num2 = -1;
				base.Set(name4, dofCocLutBlur, num2);
				base.SetCombo("D_DOF_PASS", 3);
				using (base.ScopedRenderTarget())
				{
					Sandbox.Render.SetViewport(0, 0, (int)this.DofHalfResSize.x, (int)this.DofHalfResSize.y);
					Sandbox.Render.SetRenderTarget(this.DofDownscale2);
					base.RenderScreenQuad(true);
				}
				string name5 = "ColorDownscaleBuffer";
				Texture dofDownscale2 = this.DofDownscale2;
				num2 = -1;
				base.Set(name5, dofDownscale2, num2);
				base.SetCombo("D_DOF_PASS", 4);
				using (base.ScopedRenderTarget())
				{
					Sandbox.Render.SetViewport(0, 0, (int)this.DofHalfResSize.x, (int)this.DofHalfResSize.y);
					Sandbox.Render.SetRenderTarget(this.DofDownscale);
					base.RenderScreenQuad(true);
				}
				base.SetCombo("D_DOF_PASS", 5);
				string name6 = "ColorDownscaleBuffer";
				Texture dofDownscale3 = this.DofDownscale;
				num2 = -1;
				base.Set(name6, dofDownscale3, num2);
				using (base.ScopedRenderTarget())
				{
					Sandbox.Render.SetViewport(0, 0, (int)this.LastScreenSize.x, (int)this.LastScreenSize.y);
					Sandbox.Render.SetRenderTarget(this.DofUpscale);
					base.RenderScreenQuad(true);
				}
				string name7 = "ColorUpscaleBuffer";
				Texture dofUpscale = this.DofUpscale;
				num2 = -1;
				base.Set(name7, dofUpscale, num2);
				base.SetCombo("D_DOF_PASS", 6);
				base.RenderScreenQuad(false);
				if (passCount > 0)
				{
					base.NextPass();
					passCount--;
				}
			}
			if (this.HasPass3)
			{
				Sandbox.Render.Material = this.PostProcessPass3;
				base.RenderScreenQuad(false);
			}
		}

		// Token: 0x04000483 RID: 1155
		private Material PostProcessPass1;

		// Token: 0x04000484 RID: 1156
		private Material PostProcessPass2;

		// Token: 0x04000485 RID: 1157
		private Material PostProcessDof;

		// Token: 0x04000486 RID: 1158
		private Texture DofCocLut;

		// Token: 0x04000487 RID: 1159
		private Texture DofCocLutBlur;

		// Token: 0x04000488 RID: 1160
		private Texture DofDownscale;

		// Token: 0x04000489 RID: 1161
		private Texture DofDownscale2;

		// Token: 0x0400048A RID: 1162
		private Texture DofUpscale;

		// Token: 0x0400048B RID: 1163
		private Vector2 LastScreenSize;

		// Token: 0x0400048C RID: 1164
		private Vector2 DofHalfResSize;

		// Token: 0x0400048D RID: 1165
		private Material PostProcessPass3;

		/// <summary>
		/// Fall-Off allows you to adjust the distance of influence for most of the
		/// post processing effects. This is used as a modifier to adjust how much
		/// influence the post processing effect has based on a start and end distance.
		/// This allows you to fade a post-processing effect based on how far away
		/// a point is in the world. It's like depth of field but for
		/// all post processing effects.
		/// </summary>
		// Token: 0x0400048E RID: 1166
		public StandardPostProcess.FalloffSettings Falloff = new StandardPostProcess.FalloffSettings();

		/// <summary>
		/// Pixelate lets you define how many pixels should be drawn on the screen
		/// at once. This is identical to scaling your screen down to a specific size
		/// and resizing it back to it's original use using a nearest neighbour filter.
		/// </summary>
		// Token: 0x0400048F RID: 1167
		public StandardPostProcess.PixelateSettings Pixelate = new StandardPostProcess.PixelateSettings();

		/// <summary>
		/// Lens Distortion is used to mainly create a "barrel" distortion or a "fish-eye"
		/// effect. Both parameters control how the distorted the image becomes. This is done
		/// by making the lens a more concave or a more convex shape
		/// </summary>
		// Token: 0x04000490 RID: 1168
		public StandardPostProcess.LensDistortionSettings LensDistortion = new StandardPostProcess.LensDistortionSettings();

		/// <summary>
		/// Panini Projection distorts the view similar to what lens distortion does, however
		/// it's distorted in a way to give the feel of having a wider field of view. The
		/// sides of the view is distorted to allow for this
		/// </summary>
		// Token: 0x04000491 RID: 1169
		public StandardPostProcess.PaniniProjectionSettings PaniniProjection = new StandardPostProcess.PaniniProjectionSettings();

		/// <summary>
		/// Chromatic Aberration is how much the seperate color channels should
		/// seperate. As this is in UV space, the color channel seperation should be extremely minimal
		/// (close to zero) values.
		/// </summary>
		// Token: 0x04000492 RID: 1170
		public StandardPostProcess.ChromaticAberrationSettings ChromaticAberration = new StandardPostProcess.ChromaticAberrationSettings();

		/// <summary>
		/// Motion blur defines how much an object should blur(based on the current view)
		/// depending on how fast it's moving. The faster the user looks around, the more the
		/// objects will blur.
		/// </summary>
		// Token: 0x04000493 RID: 1171
		public StandardPostProcess.MotionBlurSettings MotionBlur = new StandardPostProcess.MotionBlurSettings();

		/// <summary>
		/// Sharpen brings emphasis on edges and smaller details. As this is
		/// increased, the edges and details become more defined in the scene
		/// </summary>
		// Token: 0x04000494 RID: 1172
		public StandardPostProcess.SharpenSettings Sharpen = new StandardPostProcess.SharpenSettings();

		/// <summary>
		/// Blur does a simple gaussian blur on the current view.
		/// </summary>
		// Token: 0x04000495 RID: 1173
		public StandardPostProcess.BlurSettings Blur = new StandardPostProcess.BlurSettings();

		/// <summary>
		/// Depth of field is used to emulate an actual camera with focus. It allows
		/// the user to keep objects in focus and adjust various other settings to emulate
		/// how a film camera works.
		/// </summary>
		// Token: 0x04000496 RID: 1174
		public StandardPostProcess.DepthOfFieldSettings DepthOfField = new StandardPostProcess.DepthOfFieldSettings();

		/// <summary>
		/// Color Overlays allow tinting, mixing or completely changing the color of the
		/// current view. This allows for tinting how the world looks or implementation of
		/// such effects such as flashing
		/// </summary>
		// Token: 0x04000497 RID: 1175
		public StandardPostProcess.ColorOverlaySettings ColorOverlay = new StandardPostProcess.ColorOverlaySettings();

		/// <summary>
		/// Saturation defines how saturated a view is. A saturation of 0 leads to 
		/// a black and white view, whereas a saturation of 1 leads to the regular view.
		/// </summary>
		// Token: 0x04000498 RID: 1176
		public StandardPostProcess.SaturateSettings Saturate = new StandardPostProcess.SaturateSettings();

		/// <summary>
		/// Film grain introduces noise to the screen. The noise can be customised to
		/// introduce more noise in darker areas. This allows the emulation of a camera
		/// sensor.
		/// </summary>
		// Token: 0x04000499 RID: 1177
		public StandardPostProcess.FilmGrainSettings FilmGrain = new StandardPostProcess.FilmGrainSettings();

		/// <summary>
		/// This creates a vignette or a sort of black border around the the edges of the screen.
		/// This is faily used to bring attention to the center of the frame
		/// </summary>
		// Token: 0x0400049A RID: 1178
		public StandardPostProcess.VignetteSettings Vignette = new StandardPostProcess.VignetteSettings();

		// Token: 0x02000254 RID: 596
		public class FalloffSettings
		{
			/// <summary>
			/// Enables distance based fall off on all of the post processing effects
			/// </summary>
			// Token: 0x17000578 RID: 1400
			// (set) Token: 0x06001E44 RID: 7748 RVA: 0x00075B7F File Offset: 0x00073D7F
			public bool Enabled
			{
				set
				{
					this.parent.SetCombo("D_FALLOFF", value);
				}
			}

			/// <summary>
			/// The distance(in units) on where the post processing effect should begin
			/// </summary>
			// Token: 0x17000579 RID: 1401
			// (set) Token: 0x06001E45 RID: 7749 RVA: 0x00075B92 File Offset: 0x00073D92
			public float StartDistance
			{
				set
				{
					this.parent.Set("standard.falloff.start", value);
				}
			}

			/// <summary>
			/// The distance(in units) on how far the post processing effect should be before it reaches full intensity
			/// </summary>
			// Token: 0x1700057A RID: 1402
			// (set) Token: 0x06001E46 RID: 7750 RVA: 0x00075BA6 File Offset: 0x00073DA6
			public float EndDistance
			{
				set
				{
					this.parent.Set("standard.falloff.end", value);
				}
			}

			/// <summary>
			/// The fall off exponent to adjust how quickly the falloff should happen
			/// A range from 0.001 -&gt; 8 seems to work best
			/// </summary>
			// Token: 0x1700057B RID: 1403
			// (set) Token: 0x06001E47 RID: 7751 RVA: 0x00075BBA File Offset: 0x00073DBA
			public float Exponent
			{
				set
				{
					this.parent.Set("standard.falloff.exponent", value);
				}
			}

			// Token: 0x040011FC RID: 4604
			internal BasePostProcess parent;
		}

		// Token: 0x02000255 RID: 597
		public class PixelateSettings
		{
			/// <summary>
			/// Enable pixelation post processing
			/// </summary>
			// Token: 0x1700057C RID: 1404
			// (get) Token: 0x06001E4A RID: 7754 RVA: 0x00075BF0 File Offset: 0x00073DF0
			// (set) Token: 0x06001E49 RID: 7753 RVA: 0x00075BD6 File Offset: 0x00073DD6
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_PIXELATE", value);
					this._enabled = value;
				}
			}

			/// <summary>
			/// Enable the usage of the post processing distance fall off for this
			/// post processing effect
			/// </summary>
			// Token: 0x1700057D RID: 1405
			// (set) Token: 0x06001E4B RID: 7755 RVA: 0x00075BF8 File Offset: 0x00073DF8
			public bool UseFalloff
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.pixelate.falloff";
					float num = (value ? 0f : 1f);
					basePostProcess.Set(name, num);
				}
			}

			/// <summary>
			/// Amount of pixels on the x/y axis of the screen.
			/// </summary>
			// Token: 0x1700057E RID: 1406
			// (set) Token: 0x06001E4C RID: 7756 RVA: 0x00075C27 File Offset: 0x00073E27
			public Vector2 PixelCount
			{
				set
				{
					this.parent.Set("standard.pixelate.pixel_count", value);
				}
			}

			// Token: 0x040011FD RID: 4605
			internal BasePostProcess parent;

			// Token: 0x040011FE RID: 4606
			internal bool _enabled;
		}

		// Token: 0x02000256 RID: 598
		public class LensDistortionSettings
		{
			// Token: 0x1700057F RID: 1407
			// (get) Token: 0x06001E4F RID: 7759 RVA: 0x00075C5D File Offset: 0x00073E5D
			// (set) Token: 0x06001E4E RID: 7758 RVA: 0x00075C43 File Offset: 0x00073E43
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_LENS_DISTORTION", value);
					this._enabled = value;
				}
			}

			/// <summary>
			/// Lens distortion multiplier 1
			/// The range should be from -1.0 -&gt; 1.0
			/// Positive values = More Convex
			/// Negative values = More Concave
			/// </summary>
			// Token: 0x17000580 RID: 1408
			// (set) Token: 0x06001E50 RID: 7760 RVA: 0x00075C65 File Offset: 0x00073E65
			public float K1
			{
				set
				{
					this.parent.Set("standard.lensdistortion.k1", value);
				}
			}

			/// <summary>
			/// Lens distortion multiplier 2.
			/// The range should be from -1.0 -&gt; 1.0
			/// Positive values = More Convex
			/// Negative values = More Concave
			/// </summary>
			// Token: 0x17000581 RID: 1409
			// (set) Token: 0x06001E51 RID: 7761 RVA: 0x00075C79 File Offset: 0x00073E79
			public float K2
			{
				set
				{
					this.parent.Set("standard.lensdistortion.k2", value);
				}
			}

			// Token: 0x040011FF RID: 4607
			internal BasePostProcess parent;

			// Token: 0x04001200 RID: 4608
			internal bool _enabled;
		}

		// Token: 0x02000257 RID: 599
		public class PaniniProjectionSettings
		{
			/// <summary>
			/// Enable Panini Projection
			/// </summary>
			// Token: 0x17000582 RID: 1410
			// (get) Token: 0x06001E54 RID: 7764 RVA: 0x00075CAF File Offset: 0x00073EAF
			// (set) Token: 0x06001E53 RID: 7763 RVA: 0x00075C95 File Offset: 0x00073E95
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_PANINI_PROJECTION", value);
					this._enabled = value;
				}
			}

			/// <summary>
			/// How intense the panini projection should be?
			/// A range from 0-&gt;1 seems to work best here
			/// </summary>
			// Token: 0x17000583 RID: 1411
			// (set) Token: 0x06001E55 RID: 7765 RVA: 0x00075CB7 File Offset: 0x00073EB7
			public float Amount
			{
				set
				{
					this.parent.Set("standard.paniniprojection.amount", value);
				}
			}

			/// <summary>
			/// How much of the excess view should be cropped
			/// Range 0-&gt;1
			/// </summary>
			// Token: 0x17000584 RID: 1412
			// (set) Token: 0x06001E56 RID: 7766 RVA: 0x00075CCB File Offset: 0x00073ECB
			public float Crop
			{
				set
				{
					this.parent.Set("standard.paniniprojection.crop", value);
				}
			}

			// Token: 0x04001201 RID: 4609
			internal BasePostProcess parent;

			// Token: 0x04001202 RID: 4610
			internal bool _enabled;
		}

		// Token: 0x02000258 RID: 600
		public class ChromaticAberrationSettings
		{
			/// <summary>
			/// Enable chromatic abberation
			/// </summary>
			// Token: 0x17000585 RID: 1413
			// (get) Token: 0x06001E59 RID: 7769 RVA: 0x00075D01 File Offset: 0x00073F01
			// (set) Token: 0x06001E58 RID: 7768 RVA: 0x00075CE7 File Offset: 0x00073EE7
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_CHROMATIC_ABERRATION", value);
					this._enabled = value;
				}
			}

			/// <summary>
			/// Enable the usage of the post processing distance fall off for this
			/// post processing effect
			/// </summary>
			// Token: 0x17000586 RID: 1414
			// (set) Token: 0x06001E5A RID: 7770 RVA: 0x00075D0C File Offset: 0x00073F0C
			public bool UseFalloff
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.chromaticaberration.falloff";
					float num = (value ? 0f : 1f);
					basePostProcess.Set(name, num);
				}
			}

			/// <summary>
			/// The pixel offset for each color channel. These values should
			/// be very small as it's in UV space. (0.004 for example)
			/// X = Red
			/// Y = Green
			/// Z = Blue
			/// </summary>
			// Token: 0x17000587 RID: 1415
			// (set) Token: 0x06001E5B RID: 7771 RVA: 0x00075D3B File Offset: 0x00073F3B
			public Vector3 Offset
			{
				set
				{
					this.parent.Set("standard.chromaticaberration.amount", value);
				}
			}

			// Token: 0x04001203 RID: 4611
			internal BasePostProcess parent;

			// Token: 0x04001204 RID: 4612
			internal bool _enabled;
		}

		// Token: 0x02000259 RID: 601
		public class MotionBlurSettings
		{
			/// <summary>
			/// Enable motion blur
			/// </summary>
			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x06001E5E RID: 7774 RVA: 0x00075D7F File Offset: 0x00073F7F
			// (set) Token: 0x06001E5D RID: 7773 RVA: 0x00075D57 File Offset: 0x00073F57
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_MOTION_BLUR", value && this._samples > 0);
					this._enabled = value;
				}
			}

			/// <summary>
			/// Enable the usage of the post processing distance fall off for this
			/// post processing effect
			/// </summary>
			// Token: 0x17000589 RID: 1417
			// (set) Token: 0x06001E5F RID: 7775 RVA: 0x00075D88 File Offset: 0x00073F88
			public bool UseFalloff
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.motionblur.falloff";
					float num = (value ? 0f : 1f);
					basePostProcess.Set(name, num);
				}
			}

			/// <summary>
			/// How strong the motion blur should be.
			/// Smaller values seem to work better here, default value is ~0.05f
			/// </summary>
			// Token: 0x1700058A RID: 1418
			// (set) Token: 0x06001E60 RID: 7776 RVA: 0x00075DB7 File Offset: 0x00073FB7
			public float Scale
			{
				set
				{
					this.parent.Set("standard.motionblur.scale", value);
				}
			}

			/// <summary>
			/// How many blur samples we should take. The higher this value is the
			/// more expensive it is. This value determines how smooth the blur will be
			/// </summary>
			// Token: 0x1700058B RID: 1419
			// (set) Token: 0x06001E61 RID: 7777 RVA: 0x00075DCC File Offset: 0x00073FCC
			public int Samples
			{
				set
				{
					this._samples = value;
					this.parent.Set("standard.motionblur.samples", value);
					if (value <= 0)
					{
						this.parent.SetCombo("D_MOTION_BLUR", false);
						return;
					}
					this.parent.SetCombo("D_MOTION_BLUR", this._enabled);
				}
			}

			// Token: 0x04001205 RID: 4613
			internal BasePostProcess parent;

			// Token: 0x04001206 RID: 4614
			internal bool _enabled;

			// Token: 0x04001207 RID: 4615
			internal int _samples = 16;
		}

		// Token: 0x0200025A RID: 602
		public class SharpenSettings
		{
			/// <summary>
			/// Enable sharpen post processing
			/// </summary>
			// Token: 0x1700058C RID: 1420
			// (get) Token: 0x06001E64 RID: 7780 RVA: 0x00075E48 File Offset: 0x00074048
			// (set) Token: 0x06001E63 RID: 7779 RVA: 0x00075E2E File Offset: 0x0007402E
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_SHARPEN", value);
					this._enabled = value;
				}
			}

			/// <summary>
			/// Enable the usage of the post processing distance fall off for this
			/// post processing effect
			/// </summary>
			// Token: 0x1700058D RID: 1421
			// (set) Token: 0x06001E65 RID: 7781 RVA: 0x00075E50 File Offset: 0x00074050
			public bool UseFalloff
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.sharpen.falloff";
					float num = (value ? 0f : 1f);
					basePostProcess.Set(name, num);
				}
			}

			/// <summary>
			/// How strong the sharpening effect should be.
			/// This is a range from 0-&gt;1 however the range can be
			/// higher to yield and even stronger effect
			/// </summary>
			// Token: 0x1700058E RID: 1422
			// (set) Token: 0x06001E66 RID: 7782 RVA: 0x00075E7F File Offset: 0x0007407F
			public float Strength
			{
				set
				{
					this.parent.Set("standard.sharpen.strength", value);
				}
			}

			// Token: 0x04001208 RID: 4616
			internal BasePostProcess parent;

			// Token: 0x04001209 RID: 4617
			internal bool _enabled;
		}

		// Token: 0x0200025B RID: 603
		public class BlurSettings
		{
			/// <summary>
			/// Enable blur post processing
			/// </summary>
			// Token: 0x1700058F RID: 1423
			// (get) Token: 0x06001E69 RID: 7785 RVA: 0x00075EB5 File Offset: 0x000740B5
			// (set) Token: 0x06001E68 RID: 7784 RVA: 0x00075E9B File Offset: 0x0007409B
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_BLUR", value);
					this._enabled = value;
				}
			}

			/// <summary>
			/// Enable the usage of the post processing distance fall off for this
			/// post processing effect
			/// </summary>
			// Token: 0x17000590 RID: 1424
			// (set) Token: 0x06001E6A RID: 7786 RVA: 0x00075EC0 File Offset: 0x000740C0
			public bool UseFalloff
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.blur.falloff";
					float num = (value ? 0f : 1f);
					basePostProcess.Set(name, num);
				}
			}

			/// <summary>
			/// Set how strong/the size of the blur is.
			/// Range 0-&gt;1
			/// </summary>
			// Token: 0x17000591 RID: 1425
			// (set) Token: 0x06001E6B RID: 7787 RVA: 0x00075EEF File Offset: 0x000740EF
			public float Strength
			{
				set
				{
					this.parent.Set("standard.blur.size", value);
				}
			}

			// Token: 0x0400120A RID: 4618
			internal BasePostProcess parent;

			// Token: 0x0400120B RID: 4619
			internal bool _enabled;
		}

		// Token: 0x0200025C RID: 604
		public class DepthOfFieldSettings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06001E6E RID: 7790 RVA: 0x00075F25 File Offset: 0x00074125
			// (set) Token: 0x06001E6D RID: 7789 RVA: 0x00075F0B File Offset: 0x0007410B
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_DOF", value);
					this._enabled = value;
				}
			}

			/// <summary>
			/// Defines the current camera sensors width in mm. By default we have this as 35mm
			/// </summary>
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x06001E70 RID: 7792 RVA: 0x00075F3C File Offset: 0x0007413C
			// (set) Token: 0x06001E6F RID: 7791 RVA: 0x00075F2D File Offset: 0x0007412D
			public float FilmWidth
			{
				get
				{
					return this.filmWidth;
				}
				set
				{
					this.filmWidth = value;
					this.UpdateFilmWidth();
				}
			}

			/// <summary>
			/// Provide an aditional blur on our circle of confusion to remove harsh transitions from in focus objects to out of focus objects
			/// </summary>
			// Token: 0x17000594 RID: 1428
			// (set) Token: 0x06001E71 RID: 7793 RVA: 0x00075F44 File Offset: 0x00074144
			public bool BlurCircleOfConfusion
			{
				set
				{
					this.parent.SetCombo("D_DOF_BLUR_COC", value);
				}
			}

			/// <summary>
			/// Allow in focus objects to bleed their colors into out of focus objects
			/// </summary>
			// Token: 0x17000595 RID: 1429
			// (set) Token: 0x06001E72 RID: 7794 RVA: 0x00075F57 File Offset: 0x00074157
			public bool BleedFocusEdge
			{
				set
				{
					this.parent.SetCombo("D_DOF_COC_IGNORE_ELIPSON", value);
				}
			}

			/// <summary>
			/// Defines how expensive the depth of field blur is, the higher the quality the slower it is.
			/// If you're using a small radius, a lower quality looks nearly identical for much higher speed
			/// </summary>
			// Token: 0x17000596 RID: 1430
			// (set) Token: 0x06001E73 RID: 7795 RVA: 0x00075F6A File Offset: 0x0007416A
			public StandardPostProcess.DepthOfFieldSettings.DofQuality Quality
			{
				set
				{
					this.parent.SetCombo("D_DOF_QUALITY", (byte)value);
				}
			}

			/// <summary>
			/// Ability to color the scene for what's out of focus. This is meant to give a more stylized look to your scenes.
			/// </summary>
			// Token: 0x17000597 RID: 1431
			// (set) Token: 0x06001E74 RID: 7796 RVA: 0x00075F7E File Offset: 0x0007417E
			public StandardPostProcess.DepthOfFieldSettings.BlurColorMode BlurColoringMode
			{
				set
				{
					this.parent.SetCombo("D_DOF_COLOR_BLUR", (byte)value);
				}
			}

			/// <summary>
			/// Sets the out of focus color, this only works if the BlurColoringMode is set to BlurColorMode.Colorize
			/// </summary>
			// Token: 0x17000598 RID: 1432
			// (set) Token: 0x06001E75 RID: 7797 RVA: 0x00075F94 File Offset: 0x00074194
			public Color BlurColor
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.dof.blurcolor";
					Vector4 vector = value;
					basePostProcess.Set(name, vector);
				}
			}

			/// <summary>
			/// Define how much we should blur what's out of focus
			/// </summary>
			// Token: 0x17000599 RID: 1433
			// (set) Token: 0x06001E76 RID: 7798 RVA: 0x00075FBB File Offset: 0x000741BB
			public float Radius
			{
				set
				{
					this.parent.Set("standard.dof.radius", value);
					this.calculatedRadius = value;
					this.UpdateMaxCoC();
				}
			}

			/// <summary>
			/// Define where our point of focus is. This is in engine units or inches
			/// </summary>
			// Token: 0x1700059A RID: 1434
			// (set) Token: 0x06001E77 RID: 7799 RVA: 0x00075FDC File Offset: 0x000741DC
			public float FocalPoint
			{
				set
				{
					this.calculatedFocalPoint = value.InchToMilimeter();
					this.UpdateLens();
				}
			}

			/// <summary>
			/// Define what our current F-Stop/Appeture size is
			/// </summary>
			// Token: 0x1700059B RID: 1435
			// (set) Token: 0x06001E78 RID: 7800 RVA: 0x00075FF0 File Offset: 0x000741F0
			public float FStop
			{
				set
				{
					this.calculatedFStop = value;
					this.UpdateLens();
				}
			}

			/// <summary>
			/// Define our current focal length, this is in engine units or inches
			/// </summary>
			// Token: 0x1700059C RID: 1436
			// (set) Token: 0x06001E79 RID: 7801 RVA: 0x00075FFF File Offset: 0x000741FF
			public float FocalLength
			{
				set
				{
					this.calculatedFocalLength = value.InchToMilimeter();
					this.UpdateLens();
				}
			}

			// Token: 0x06001E7A RID: 7802 RVA: 0x00076013 File Offset: 0x00074213
			[Event.Screen.SizeChangedAttribute]
			private void UpdateFilmWidth()
			{
				this.calculatedFilmHeight = this.filmWidth * 1.5f * (Screen.Height / 1080f);
				this.UpdateLens();
				this.UpdateMaxCoC();
			}

			// Token: 0x06001E7B RID: 7803 RVA: 0x00076040 File Offset: 0x00074240
			private void UpdateLens()
			{
				float focusPlane = Math.Max(this.calculatedFocalPoint, this.calculatedFocalLength);
				float lens = this.calculatedFocalLength * this.calculatedFocalLength / (this.calculatedFStop * (focusPlane - this.calculatedFocalLength) * this.calculatedFilmHeight * 2f);
				this.parent.Set("standard.dof.lens", lens);
				this.parent.Set("standard.dof.focusplane", focusPlane);
			}

			// Token: 0x06001E7C RID: 7804 RVA: 0x000760B0 File Offset: 0x000742B0
			private void UpdateMaxCoC()
			{
				float blurRadius = this.calculatedRadius * 4f * 6f;
				BasePostProcess basePostProcess = this.parent;
				string name = "standard.dof.maxcoc";
				float num = MathF.Min(0.05f, blurRadius / Screen.Height);
				basePostProcess.Set(name, num);
			}

			// Token: 0x0400120C RID: 4620
			private const float FilmAspect = 1.5f;

			// Token: 0x0400120D RID: 4621
			private float filmWidth = 0.024f;

			// Token: 0x0400120E RID: 4622
			private float calculatedFilmHeight = 0.024f;

			// Token: 0x0400120F RID: 4623
			private float calculatedFocalLength = 0.05f;

			// Token: 0x04001210 RID: 4624
			private float calculatedFStop = 5.6f;

			// Token: 0x04001211 RID: 4625
			private float calculatedFocalPoint = 64f.InchToMilimeter();

			// Token: 0x04001212 RID: 4626
			private float calculatedRadius;

			// Token: 0x04001213 RID: 4627
			internal BasePostProcess parent;

			// Token: 0x04001214 RID: 4628
			internal bool _enabled;

			// Token: 0x02000303 RID: 771
			public enum DofQuality
			{
				// Token: 0x04001366 RID: 4966
				Low,
				// Token: 0x04001367 RID: 4967
				Medium,
				// Token: 0x04001368 RID: 4968
				High
			}

			/// <summary>
			/// Out of focus coloring modes
			/// </summary>
			// Token: 0x02000304 RID: 772
			public enum BlurColorMode
			{
				// Token: 0x0400136A RID: 4970
				None,
				// Token: 0x0400136B RID: 4971
				Colorize,
				// Token: 0x0400136C RID: 4972
				Grayscale
			}
		}

		// Token: 0x0200025D RID: 605
		public class ColorOverlaySettings
		{
			/// <summary>
			/// Enable the color overlay
			/// </summary>
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06001E7F RID: 7807 RVA: 0x00076178 File Offset: 0x00074378
			// (set) Token: 0x06001E7E RID: 7806 RVA: 0x00076143 File Offset: 0x00074343
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this._enabled = value;
					if (!value)
					{
						this.parent.SetCombo("D_COLOR_OVERLAY", 0);
						return;
					}
					this.parent.SetCombo("D_COLOR_OVERLAY", (byte)this._mode);
				}
			}

			/// <summary>
			/// Enable the usage of the post processing distance fall off for this
			/// post processing effect
			/// </summary>
			// Token: 0x1700059E RID: 1438
			// (set) Token: 0x06001E80 RID: 7808 RVA: 0x00076180 File Offset: 0x00074380
			public bool UseFalloff
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.coloroverlay.falloff";
					float num = (value ? 0f : 1f);
					basePostProcess.Set(name, num);
				}
			}

			/// <summary>
			/// Determine which color overlay we should use
			/// </summary>
			// Token: 0x1700059F RID: 1439
			// (set) Token: 0x06001E81 RID: 7809 RVA: 0x000761AF File Offset: 0x000743AF
			public StandardPostProcess.ColorOverlaySettings.OverlayMode Mode
			{
				set
				{
					this._mode = value;
					if (this._enabled)
					{
						this.parent.SetCombo("D_COLOR_OVERLAY", (byte)value);
					}
				}
			}

			/// <summary>
			/// The color which should be used with the color overlay
			/// </summary>
			// Token: 0x170005A0 RID: 1440
			// (set) Token: 0x06001E82 RID: 7810 RVA: 0x000761D4 File Offset: 0x000743D4
			public Color Color
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.coloroverlay.color";
					Vector3 vector = new Vector3(value);
					basePostProcess.Set(name, vector);
				}
			}

			/// <summary>
			/// How much the color overlays influence is. This is a value between
			/// 0.0f -&gt; 1.0f
			/// </summary>
			// Token: 0x170005A1 RID: 1441
			// (set) Token: 0x06001E83 RID: 7811 RVA: 0x000761FF File Offset: 0x000743FF
			public float Amount
			{
				set
				{
					this.parent.Set("standard.coloroverlay.amount", value);
				}
			}

			// Token: 0x04001215 RID: 4629
			internal BasePostProcess parent;

			// Token: 0x04001216 RID: 4630
			private StandardPostProcess.ColorOverlaySettings.OverlayMode _mode = StandardPostProcess.ColorOverlaySettings.OverlayMode.Additive;

			// Token: 0x04001217 RID: 4631
			private bool _enabled;

			/// <summary>
			/// Color overlay mode to use
			/// </summary>
			// Token: 0x02000305 RID: 773
			public enum OverlayMode
			{
				// Token: 0x0400136E RID: 4974
				Additive = 1,
				// Token: 0x0400136F RID: 4975
				Multiply,
				// Token: 0x04001370 RID: 4976
				Mix
			}
		}

		// Token: 0x0200025E RID: 606
		public class SaturateSettings
		{
			/// <summary>
			/// Enable the saturation post processing effect
			/// </summary>
			// Token: 0x170005A2 RID: 1442
			// (get) Token: 0x06001E86 RID: 7814 RVA: 0x0007623C File Offset: 0x0007443C
			// (set) Token: 0x06001E85 RID: 7813 RVA: 0x00076222 File Offset: 0x00074422
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_SATURATE", value);
					this._enabled = value;
				}
			}

			/// <summary>
			/// Enable the usage of the post processing distance fall off for this
			/// post processing effect
			/// </summary>
			// Token: 0x170005A3 RID: 1443
			// (set) Token: 0x06001E87 RID: 7815 RVA: 0x00076244 File Offset: 0x00074444
			public bool UseFalloff
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.saturate.falloff";
					float num = (value ? 0f : 1f);
					basePostProcess.Set(name, num);
				}
			}

			/// <summary>
			/// How saturated our view should be. A value of 
			/// 0 is a grayscale result whereas 1 is no change. Any
			/// value greater than 1 will lead to an over-saturated or
			/// "deepfried" look
			/// </summary>
			// Token: 0x170005A4 RID: 1444
			// (set) Token: 0x06001E88 RID: 7816 RVA: 0x00076273 File Offset: 0x00074473
			public float Amount
			{
				set
				{
					this.parent.Set("standard.saturate.amount", value);
				}
			}

			// Token: 0x04001218 RID: 4632
			internal BasePostProcess parent;

			// Token: 0x04001219 RID: 4633
			internal bool _enabled;
		}

		// Token: 0x0200025F RID: 607
		public class FilmGrainSettings
		{
			/// <summary>
			/// Enable the grain post processing
			/// </summary>
			// Token: 0x170005A5 RID: 1445
			// (get) Token: 0x06001E8B RID: 7819 RVA: 0x000762A9 File Offset: 0x000744A9
			// (set) Token: 0x06001E8A RID: 7818 RVA: 0x0007628F File Offset: 0x0007448F
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_FILM_GRAIN", value);
					this._enabled = value;
				}
			}

			/// <summary>
			/// Enable the usage of the post processing distance fall off for this
			/// post processing effect
			/// </summary>
			// Token: 0x170005A6 RID: 1446
			// (set) Token: 0x06001E8C RID: 7820 RVA: 0x000762B4 File Offset: 0x000744B4
			public bool UseFalloff
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.grain.falloff";
					float num = (value ? 0f : 1f);
					basePostProcess.Set(name, num);
				}
			}

			/// <summary>
			/// How intense the grain output should be. This is a value
			/// from 0-&gt;1
			/// </summary>
			// Token: 0x170005A7 RID: 1447
			// (set) Token: 0x06001E8D RID: 7821 RVA: 0x000762E3 File Offset: 0x000744E3
			public float Intensity
			{
				set
				{
					this.parent.Set("standard.grain.intensity", value);
				}
			}

			/// <summary>
			/// How responsive the grain should be to light values. A result
			/// of 0 will lead to the grain being very responsive everywhere
			/// whereas a value of 1 will lead to the grain only being responsive in darker
			/// areas.
			/// The range is from 0-&gt;1
			/// </summary>
			// Token: 0x170005A8 RID: 1448
			// (set) Token: 0x06001E8E RID: 7822 RVA: 0x000762F7 File Offset: 0x000744F7
			public float Response
			{
				set
				{
					this.parent.Set("standard.grain.response", value);
				}
			}

			// Token: 0x0400121A RID: 4634
			internal BasePostProcess parent;

			// Token: 0x0400121B RID: 4635
			internal bool _enabled;
		}

		// Token: 0x02000260 RID: 608
		public class VignetteSettings
		{
			/// <summary>
			/// Enables vignette post processing
			/// </summary>
			// Token: 0x170005A9 RID: 1449
			// (get) Token: 0x06001E91 RID: 7825 RVA: 0x0007632D File Offset: 0x0007452D
			// (set) Token: 0x06001E90 RID: 7824 RVA: 0x00076313 File Offset: 0x00074513
			public bool Enabled
			{
				get
				{
					return this._enabled;
				}
				set
				{
					this.parent.SetCombo("D_VIGNETTE", value);
					this._enabled = value;
				}
			}

			/// <summary>
			/// The color of the vignette or the "border"
			/// </summary>
			// Token: 0x170005AA RID: 1450
			// (set) Token: 0x06001E92 RID: 7826 RVA: 0x00076338 File Offset: 0x00074538
			public Color Color
			{
				set
				{
					BasePostProcess basePostProcess = this.parent;
					string name = "standard.vignette.color";
					Vector3 vector = new Vector3(value);
					basePostProcess.Set(name, vector);
				}
			}

			/// <summary>
			/// How strong the vignette is. This is a value between 0 -&gt; 1
			/// </summary>
			// Token: 0x170005AB RID: 1451
			// (set) Token: 0x06001E93 RID: 7827 RVA: 0x00076363 File Offset: 0x00074563
			public float Intensity
			{
				set
				{
					this.parent.Set("standard.vignette.intensity", value);
				}
			}

			/// <summary>
			/// How much fall off or how blurry the vignette is
			/// </summary>
			// Token: 0x170005AC RID: 1452
			// (set) Token: 0x06001E94 RID: 7828 RVA: 0x00076377 File Offset: 0x00074577
			public float Smoothness
			{
				set
				{
					this.parent.Set("standard.vignette.smoothness", value);
				}
			}

			/// <summary>
			/// How circular or round the vignette is
			/// </summary>
			// Token: 0x170005AD RID: 1453
			// (set) Token: 0x06001E95 RID: 7829 RVA: 0x0007638B File Offset: 0x0007458B
			public float Roundness
			{
				set
				{
					this.parent.Set("standard.vignette.roundness", value);
				}
			}

			/// <summary>
			/// The center of the vignette in relation to UV space. This means
			/// a value of {0.5, 0.5} is the center of the screen
			/// </summary>
			// Token: 0x170005AE RID: 1454
			// (set) Token: 0x06001E96 RID: 7830 RVA: 0x0007639F File Offset: 0x0007459F
			public Vector2 Center
			{
				set
				{
					this.parent.Set("standard.vignette.center", value);
				}
			}

			// Token: 0x0400121C RID: 4636
			internal BasePostProcess parent;

			// Token: 0x0400121D RID: 4637
			internal bool _enabled;
		}
	}
}
